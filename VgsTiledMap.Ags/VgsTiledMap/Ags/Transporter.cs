namespace VgsTiledMap.Ags
{
    using System;
    using System.Runtime.CompilerServices;
    using VgsMap.Tile;
    using VgsMap.Tile.Cache;
    using VgsMap.Tile.Web;

    public class Transporter
    {
      

        public string CacheDir
        {
            get;
            set;
        }

        public VgsMap.Tile.Cache.FileCache FileCache
        {
            get;
            set;
        }

        public ITileSchema Schema
        {
            get;
            set;
        }

        public VgsTiledMap.Ags.Transform Transform
        {
            get;
            set;
        }

        public VgsMap.Tile.Web.WebTileProvider WebTileProvider
        {
            get;
            set;
        }
    }
}

