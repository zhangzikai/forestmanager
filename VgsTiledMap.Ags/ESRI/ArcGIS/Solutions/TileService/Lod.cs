namespace ESRI.ArcGIS.Solutions.TileService
{
    using System;

    public sealed class Lod : IComparable<Lod>
    {
        private int _level;
        private double _res;
        private double _scale;

        public Lod(int level, double scale)
        {
            this._level = level;
            this._scale = scale;
            this._res = ((scale / 100.0) * 2.54) / 96.0;
        }

        public Lod(int level, double resolution, double scale)
        {
            this._level = level;
            this._res = resolution;
            this._scale = scale;
        }

        public int CompareTo(Lod other)
        {
            return this._res.CompareTo(other.Resolution);
        }

        public int Level
        {
            get
            {
                return this._level;
            }
            set
            {
                this._level = value;
            }
        }

        public double Resolution
        {
            get
            {
                return this._res;
            }
            set
            {
                this._res = value;
            }
        }

        public double Scale
        {
            get
            {
                return this._scale;
            }
            set
            {
                this._scale = value;
            }
        }
    }
}

