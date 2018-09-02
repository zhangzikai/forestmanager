namespace GDB.SQLServerExpress
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Threading;
    using System.Windows.Forms;

    public abstract class Task
    {
        protected Thread _callThread;
        protected System.Exception _exception;
        protected int _progress = -1;
        protected object _result;
        protected TaskStatus _taskState;
        protected Thread _workThread;

        public event TaskEventHandler TaskAbort;

        public event TaskEventHandler TaskCancel;

        public event TaskEventHandler TaskProgressChanged;

        public event TaskEventHandler TaskStatusChanged;

        public event TaskEventHandler TaskThrowError;

        protected Task()
        {
        }

        public bool AbortTask()
        {
            bool flag = false;
            lock (this)
            {
                if ((this._taskState != TaskStatus.Running) || (this._workThread == null))
                {
                    return flag;
                }
                if (this._workThread.ThreadState != ThreadState.Stopped)
                {
                    this._workThread.Abort();
                }
                Thread.Sleep(2);
                if (this._workThread.ThreadState == ThreadState.Stopped)
                {
                    this._taskState = TaskStatus.Aborted;
                    flag = true;
                }
                else
                {
                    this._taskState = TaskStatus.AbortPending;
                    flag = false;
                }
                this.FireStatusChangedEvent(this._taskState, this._result);
            }
            return flag;
        }

        protected void AsyncInvoke(TaskEventHandler eventhandler, TaskEventArgs args)
        {
            foreach (TaskEventHandler handler in eventhandler.GetInvocationList())
            {
                if (handler.Target is Control)
                {
                    Control target = handler.Target as Control;
                    try
                    {
                        target.BeginInvoke(handler, new object[] { this, args });
                    }
                    catch (System.Exception)
                    {
                    }
                }
                else
                {
                    handler.BeginInvoke(this, args, null, null);
                }
            }
        }

        protected void EndWorkBack(IAsyncResult ar)
        {
            bool flag = false;
            bool flag2 = false;
            try
            {
                this._result = ((TaskDelegate) ar.AsyncState).EndInvoke(ar);
            }
            catch (System.Exception exception)
            {
                flag = true;
                this._exception = exception;
                if (exception.GetType() == typeof(ThreadAbortException))
                {
                    flag2 = true;
                    this.FireAbortEvent(this._progress, this._exception);
                }
                else
                {
                    this.FireThrowErrorEvent(this._progress, this._exception);
                }
            }
            lock (this)
            {
                if (flag)
                {
                    if (flag2)
                    {
                        this._taskState = TaskStatus.Aborted;
                    }
                    else
                    {
                        this._taskState = TaskStatus.ThrowErrorStoped;
                    }
                }
                else
                {
                    this._taskState = TaskStatus.Stopped;
                }
                this.FireStatusChangedEvent(this._taskState, this._result);
            }
        }

        protected void FireAbortEvent(int progress, object result)
        {
            if (this.TaskAbort != null)
            {
                TaskEventArgs args = new TaskEventArgs(progress, result);
                this.AsyncInvoke(this.TaskAbort, args);
            }
        }

        protected void FireCancelEvent(int progress, object result)
        {
            if (this.TaskCancel != null)
            {
                TaskEventArgs args = new TaskEventArgs(progress, result);
                this.AsyncInvoke(this.TaskCancel, args);
            }
        }

        protected void FireProgressChangedEvent(int progress, object result)
        {
            if (this.TaskProgressChanged != null)
            {
                TaskEventArgs args = new TaskEventArgs(progress, result);
                this.AsyncInvoke(this.TaskProgressChanged, args);
            }
        }

        protected void FireStatusChangedEvent(TaskStatus status, object result)
        {
            if (this.TaskStatusChanged != null)
            {
                TaskEventArgs args = new TaskEventArgs(status, result);
                this.AsyncInvoke(this.TaskStatusChanged, args);
            }
        }

        protected void FireThrowErrorEvent(int progress, object result)
        {
            if (this.TaskThrowError != null)
            {
                TaskEventArgs args = new TaskEventArgs(progress, result);
                this.AsyncInvoke(this.TaskThrowError, args);
            }
        }

        public bool StartTask(params object[] args)
        {
            return this.StartTask(new TaskDelegate(this.Work), args);
        }

        public bool StartTask(TaskDelegate worker, params object[] args)
        {
            bool flag = false;
            lock (this)
            {
                if (this.IsStop && (worker != null))
                {
                    this._result = null;
                    this._callThread = Thread.CurrentThread;
                    worker.BeginInvoke(args, new AsyncCallback(this.EndWorkBack), worker);
                    this._taskState = TaskStatus.Running;
                    this.FireStatusChangedEvent(this._taskState, null);
                    flag = true;
                }
            }
            return flag;
        }

        public virtual bool StopTask()
        {
            bool flag = false;
            lock (this)
            {
                if (this._taskState == TaskStatus.Running)
                {
                    this._taskState = TaskStatus.CancelPending;
                    this.FireStatusChangedEvent(this._taskState, this._result);
                    flag = true;
                }
            }
            return flag;
        }

        public virtual object Work(params object[] args)
        {
            Thread.CurrentThread.IsBackground = true;
            this._workThread = Thread.CurrentThread;
            this._result = null;
            return null;
        }

        public Thread CallThread
        {
            get
            {
                return this._callThread;
            }
        }

        public System.Exception Exception
        {
            get
            {
                return this._exception;
            }
        }

        protected bool IsStop
        {
            get
            {
                switch (this._taskState)
                {
                    case TaskStatus.Stopped:
                    case TaskStatus.Aborted:
                    case TaskStatus.ThrowErrorStoped:
                        return true;
                }
                return false;
            }
        }

        public int Progress
        {
            get
            {
                return this._progress;
            }
        }

        public object Result
        {
            get
            {
                return this._result;
            }
        }

        public TaskStatus TaskState
        {
            get
            {
                return this._taskState;
            }
        }

        public Thread WordThread
        {
            get
            {
                return this._workThread;
            }
        }
    }
}

