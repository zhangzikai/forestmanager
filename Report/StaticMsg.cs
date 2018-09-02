namespace Report
{
    using System;

    /// <summary>
    /// 静态的信息类
    /// </summary>
    public class StaticMsg
    {
        private string _endMsg;
        private string _exceptionMsg;
        private bool _start;
        private string _startMsg;
        private int _staticReportCount;
        private string _tableInfo;
        private int _threadMsg;
        private string _title;
        private string _verb;

        /// <summary>
        /// 结束的信息
        /// </summary>
        public string EndMessage
        {
            get
            {
                return this._endMsg;
            }
            set
            {
                this._endMsg = value;
            }
        }

        /// <summary>
        /// 例外的信息
        /// </summary>
        public string ExceptionMessage
        {
            get
            {
                return this._exceptionMsg;
            }
            set
            {
                this._exceptionMsg = value;
            }
        }

        /// <summary>
        /// 判断是否开始
        /// </summary>
        public bool Start
        {
            get
            {
                return this._start;
            }
            set
            {
                this._start = value;
            }
        }

        /// <summary>
        /// 开始信息
        /// </summary>
        public string StartMessage
        {
            get
            {
                return this._startMsg;
            }
            set
            {
                this._startMsg = value;
            }
        }

        /// <summary>
        /// 静态的报表数量
        /// </summary>
        public int StaticReportCount
        {
            get
            {
                return this._staticReportCount;
            }
            set
            {
                this._staticReportCount = value;
            }
        }

        /// <summary>
        /// 表单信息
        /// </summary>
        public string TableInfo
        {
            get
            {
                return this._tableInfo;
            }
            set
            {
                this._tableInfo = value;
            }
        }

        /// <summary>
        /// 县城信息
        /// </summary>
        public int ThreadMsg
        {
            get
            {
                return this._threadMsg;
            }
            set
            {
                this._threadMsg = value;
            }
        }

        /// <summary>
        /// 标题
        /// </summary>
        public string Title
        {
            get
            {
                return this._title;
            }
            set
            {
                this._title = value;
            }
        }

        public string Verb
        {
            get
            {
                return this._verb;
            }
            set
            {
                this._verb = value;
            }
        }
    }
}

