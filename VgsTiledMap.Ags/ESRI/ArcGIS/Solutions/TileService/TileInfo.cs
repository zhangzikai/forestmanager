namespace ESRI.ArcGIS.Solutions.TileService
{
    using ESRI.ArcGIS.Geometry;
    using System;

    public sealed class TileInfo
    {
        private int _height;
        private Lod[] _lods;
        private IPoint _origin;
        private ISpatialReference _spatialRef;
        private int _width;

        public TileInfo()
        {
            this._width = 0x100;
            this._height = 0x100;
        }

        public TileInfo(int size, IPoint origin, ISpatialReference srf)
        {
            this._width = 0x100;
            this._height = 0x100;
            this._width = size;
            this._height = size;
            this._origin = ((ICloneable) origin).Clone() as IPoint;
            this._spatialRef = ((ICloneable) srf).Clone() as ISpatialReference;
        }

        public TileInfo(int size, IPoint origin, ISpatialReference srf, Lod[] lods)
        {
            this._width = 0x100;
            this._height = 0x100;
            this._width = size;
            this._height = size;
            this._origin = ((ICloneable) origin).Clone() as IPoint;
            this._spatialRef = ((ICloneable) srf).Clone() as ISpatialReference;
            this._lods = lods;
        }

        public int Height
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

        public Lod[] Lods
        {
            get
            {
                return this._lods;
            }
            set
            {
                this._lods = value;
            }
        }

        public IPoint Origin
        {
            get
            {
                return this._origin;
            }
            set
            {
                this._origin = value;
            }
        }

        public ISpatialReference SpatialReference
        {
            get
            {
                return this._spatialRef;
            }
            set
            {
                this._spatialRef = value;
            }
        }

        public int Width
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
    }
}

