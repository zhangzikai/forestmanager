namespace AttributesEdit
{
    using System;

    public class ZLComboItem
    {
        private bool bEnable = true;
        private int iLevel;
        private string sName;
        private string sValue;

        public ZLComboItem(string name, string value)
        {
            this.sName = name;
            this.sValue = value;
            this.bEnable = true;
            this.iLevel = 0;
        }

        public bool Enable
        {
            get
            {
                return this.bEnable;
            }
            set
            {
                this.bEnable = value;
            }
        }

        public int Level
        {
            get
            {
                return this.iLevel;
            }
            set
            {
                this.iLevel = value;
            }
        }

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

        public string Value
        {
            get
            {
                return this.sValue;
            }
            set
            {
                this.sValue = value;
            }
        }
    }
}

