namespace GDB.SQLServerExpress
{
    using System;

    public class TaskEventArgs : EventArgs
    {
        public string Message;
        public int Progress;
        public object Result;
        public TaskStatus Status;

        public TaskEventArgs(TaskStatus status)
        {
            this.Status = status;
        }

        public TaskEventArgs(int progress)
        {
            this.Progress = progress;
            this.Status = TaskStatus.Running;
        }

        public TaskEventArgs(TaskStatus status, object result)
        {
            this.Status = status;
            this.Result = result;
        }

        public TaskEventArgs(int progress, object result)
        {
            this.Progress = progress;
            this.Status = TaskStatus.Running;
            this.Result = result;
        }

        public TaskEventArgs(TaskStatus status, string message, object result)
        {
            this.Status = status;
            this.Message = message;
            this.Result = result;
        }

        public TaskEventArgs(int progress, string message, object result)
        {
            this.Progress = progress;
            this.Status = TaskStatus.Running;
            this.Message = message;
            this.Result = result;
        }

        public TaskEventArgs(TaskStatus status, int progress, string message, object result)
        {
            this.Status = status;
            this.Progress = progress;
            this.Message = message;
            this.Result = result;
        }
    }
}

