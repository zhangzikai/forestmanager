namespace ESRI.ArcGIS.Solutions.TileService
{
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct Extent
    {
        private double _minX;
        private double _minY;
        private double _maxX;
        private double _maxY;
        public Extent(double minX, double minY, double maxX, double maxY)
        {
            this._minX = minX;
            this._minY = minY;
            this._maxX = maxX;
            this._maxY = maxY;
        }

        public double MinX
        {
            get
            {
                return this._minX;
            }
            set
            {
                this._minX = value;
            }
        }
        public double MinY
        {
            get
            {
                return this._minY;
            }
            set
            {
                this._minY = value;
            }
        }
        public double MaxX
        {
            get
            {
                return this._maxX;
            }
            set
            {
                this._maxX = value;
            }
        }
        public double MaxY
        {
            get
            {
                return this._maxY;
            }
            set
            {
                this._maxY = value;
            }
        }
    }
}

