namespace VgsTiledMap.Ags
{
    using System;
    using System.Runtime.CompilerServices;

    public class TileMap
    {
      

        public TileMap()
        {
            this.OverwriteUrls = true;
        }

        public static int Compare(TileMap a, TileMap b)
        {
            return a.Title.CompareTo(b.Title);
        }

        public string Href
        {
            get;
            set;
        }

        public bool OverwriteUrls
        {
            get;
            set;
        }

        public string Profile
        {
            get;
            set;
        }

        public string Srs
        {
            get;
            set;
        }

        public string Title
        {
            get;
            set;
        }

        public string Type
        {
            get;
            set;
        }
    }
}

