namespace Cartography.Render
{
    using System;
    using System.Drawing;

    internal class Record
    {
        private object _checked;
        private string _count;
        private string _fieldValue;
        private Bitmap _image;
        private string _label;

        public Record(object pChecked, Bitmap pImage, string pValue, string pLabel, string pCount)
        {
            this._checked = pChecked;
            this._image = pImage;
            this._fieldValue = pValue;
            this._label = pLabel;
            this._count = pCount;
        }

        public object Checked
        {
            get
            {
                return this._checked;
            }
            set
            {
                this._checked = value;
            }
        }

        public string Count
        {
            get
            {
                return this._count;
            }
            set
            {
                this._count = value;
            }
        }

        public string FieldValue
        {
            get
            {
                return this._fieldValue;
            }
            set
            {
                this._fieldValue = value;
            }
        }

        public Bitmap Image
        {
            get
            {
                return this._image;
            }
            set
            {
                this._image = value;
            }
        }

        public string Label
        {
            get
            {
                return this._label;
            }
            set
            {
                this._label = value;
            }
        }
    }
}

