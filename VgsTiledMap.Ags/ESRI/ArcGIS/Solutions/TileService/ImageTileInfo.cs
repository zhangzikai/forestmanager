namespace ESRI.ArcGIS.Solutions.TileService
{
    using System;
    using System.Drawing;

    public class ImageTileInfo
    {
        private int _col;
        private ESRI.ArcGIS.Solutions.TileService.Extent _extent;
        private System.Drawing.Image _image;
        private int _level;
        private int _row;
        private string _url;

        public ImageTileInfo(int row, int col, int level, string url, ESRI.ArcGIS.Solutions.TileService.Extent extent)
        {
            this._row = row;
            this._col = col;
            this._level = level;
            this._url = url;
            this._extent = extent;
        }

        public static string GetTileKey(int Row, int Column, int Level)
        {
            return string.Format("{0}_{1}_{2}", Row, Column, Level);
        }

        public int Column
        {
            get
            {
                return this._col;
            }
            set
            {
                this._col = value;
            }
        }

        public ESRI.ArcGIS.Solutions.TileService.Extent Extent
        {
            get
            {
                return this._extent;
            }
            set
            {
                this._extent = value;
            }
        }

        public System.Drawing.Image Image
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

        public int Row
        {
            get
            {
                return this._row;
            }
            set
            {
                this._row = value;
            }
        }

        public string TileKey
        {
            get
            {
                return GetTileKey(this.Row, this.Column, this.Level);
            }
        }

        public string Url
        {
            get
            {
                return this._url;
            }
            set
            {
                this._url = value;
            }
        }
    }
}

