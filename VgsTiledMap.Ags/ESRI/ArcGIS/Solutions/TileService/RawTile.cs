namespace ESRI.ArcGIS.Solutions.TileService
{
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    internal struct RawTile
    {
        public int ID;
        public int Row;
        public int Column;
        public int Level;
        public RawTile(int id, int row, int col, int level)
        {
            this.ID = id;
            this.Row = row;
            this.Column = col;
            this.Level = level;
        }

        internal string getKey()
        {
            return string.Format("{0}_{1}", this.ID, ImageTileInfo.GetTileKey(this.Row, this.Column, this.Level));
        }

        public override string ToString()
        {
            return string.Concat(new object[] { this.ID.ToString(), " at level ", this.Level, ", Row: ", this.Row, ",Column: ", this.Column });
        }
    }
}

