namespace Cartography.Render
{
    using ESRI.ArcGIS.Display;
    using System;

    internal class ValueClass
    {
        private string _heading;
        private string _label;
        private ISymbol _symbol;
        private string _value;

        public ValueClass(string pValue, string pHeading, string pLabel, ISymbol pSymbol)
        {
            this._value = pValue;
            this._heading = pHeading;
            this._label = pLabel;
            this._symbol = pSymbol;
        }

        public string Heading
        {
            get
            {
                return this._heading;
            }
        }

        public string Label
        {
            get
            {
                return this._label;
            }
        }

        public ISymbol Symbol
        {
            get
            {
                return this._symbol;
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

