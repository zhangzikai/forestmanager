namespace VgsTiledMap.Ags.VgsTile.Vgs
{
    using System;
    using System.Globalization;
    using System.Runtime.CompilerServices;
    using VgsMap.Tile;
    using VgsMap.Tile.Web;

    public class VgsLindTileRequest : IRequest
    {
      

        public VgsLindTileRequest(string baseUrl, string lyrname) : this(baseUrl, lyrname, string.Empty, "png")
        {
        }

        public VgsLindTileRequest(string baseUrl, string lyrname, string year, string type)
        {
            this.BaseUrl = baseUrl;
            this.LyrName = lyrname;
            this.Year = year;
            if (string.IsNullOrEmpty(type))
            {
                type = "png";
            }
            this.TType = type;
        }

        public Uri GetUri(TileInfo tileInfo)
        {
            int col = tileInfo.Index.Col;
            int row = tileInfo.Index.Row;
            string uriString = string.Empty;
            if (string.IsNullOrEmpty(this.Year))
            {
                uriString = string.Format(CultureInfo.InvariantCulture, this.BaseUrl + "/vgst/{0}/{1}/{2}/{3}/{4}", new object[] { this.LyrName, col, row, tileInfo.Index.LevelId, this.TType });
            }
            else
            {
                uriString = string.Format(CultureInfo.InvariantCulture, this.BaseUrl + "/vgst/{0}/{1}/{2}/{3}/{4}/{5}", new object[] { this.LyrName, this.Year, col, row, tileInfo.Index.LevelId, this.TType });
            }
            return new Uri(uriString);
        }

        public string BaseUrl
        {
            get;
            set;
        }

        public string LyrName
        {
            get;
            set;
        }

        public string TType
        {
            get;
            set;
        }

        public string Year
        {
            get;
            set;
        }
    }
}

