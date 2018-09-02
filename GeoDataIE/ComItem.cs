namespace GeoDataIE
{
    using System;

    public class ComItem
    {
        private object pValue;
        private string sName = "";

        public string Name
        {
            get
            {
                return this.sName;
            }
            set
            {
                this.sName = value;
            }
        }

        public object Value
        {
            get
            {
                return this.pValue;
            }
            set
            {
                this.pValue = value;
            }
        }
    }
}

