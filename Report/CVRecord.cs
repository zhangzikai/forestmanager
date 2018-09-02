namespace Report
{
    using System;

    internal class CVRecord
    {
        private object _code;
        private string _value;

        public CVRecord(object pCode, string pValue)
        {
            this._code = pCode;
            this._value = pValue;
        }

        public object Code
        {
            get
            {
                return this._code;
            }
        }

        public string Value
        {
            get
            {
                return this._value;
            }
        }
    }
}

