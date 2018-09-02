namespace GDB.SQLServerExpress.vTasks.vControls
{
    using System;

    internal class Record
    {
        private string _source;
        private string _target;

        public string Source
        {
            get
            {
                return this._source;
            }
            set
            {
                this._source = value;
            }
        }

        public string Target
        {
            get
            {
                return this._target;
            }
            set
            {
                this._target = value;
            }
        }
    }
}

