namespace Print
{
    using ESRI.ArcGIS.Carto;
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct MapPageSet
    {
        private esriPageFormID _id;
        private short _orienTation;
        private double _width;
        private double _height;
        private static double _overlap;
        public esriPageFormID ID
        {
            get
            {
                return this._id;
            }
            set
            {
                this._id = value;
            }
        }
        public short OrienTation
        {
            get
            {
                return this._orienTation;
            }
            set
            {
                this._orienTation = value;
            }
        }
        public double Width
        {
            get
            {
                return this._width;
            }
            set
            {
                this._width = value;
            }
        }
        public double Height
        {
            get
            {
                return this._height;
            }
            set
            {
                this._height = value;
            }
        }
        public static double OverLap
        {
            get
            {
                return _overlap;
            }
            set
            {
                _overlap = value;
            }
        }
        static MapPageSet()
        {
            _overlap = -1.0;
        }
    }
}

