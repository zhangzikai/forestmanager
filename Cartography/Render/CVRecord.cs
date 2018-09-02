namespace Cartography.Render
{
    using System;

    internal class CVRecord
    {
        private string _code;
        private string _value;

        public CVRecord(string pCode, string pValue)
        {
            this._code = pCode;
            this._value = pValue;
        }

        public string Code
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

