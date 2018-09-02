namespace Print
{
    using System;

    public class ClsPageIndex
    {
        private short _pageIndex;

        public short PageIndex
        {
            get
            {
                return this._pageIndex;
            }
            set
            {
                this._pageIndex = value;
            }
        }
    }
}

