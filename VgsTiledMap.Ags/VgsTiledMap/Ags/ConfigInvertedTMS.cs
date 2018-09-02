namespace VgsTiledMap.Ags
{
    using System;
    using System.Net;
    using VgsMap.Tile;
    using VgsMap.Tile.PreDefined;
    using VgsMap.Tile.Web.TmsService;

    public class ConfigInvertedTMS : IConfig
    {
        private string url;

        public ConfigInvertedTMS(string Url)
        {
            this.url = Url;
        }

        public ITileSource CreateTileSource()
        {
            HttpWebRequest request = (HttpWebRequest) WebRequest.Create(this.url);
            request.UserAgent = "Mozilla/5.0 (Windows; U; Windows NT 5.1; en-US; rv:1.8.1.14) Gecko/20080404 Firefox/2.0.0.14";
            HttpWebResponse response = (HttpWebResponse) request.GetResponse();
            return new TileSource(TileMapParser.CreateTileSource(response.GetResponseStream()).Provider, new SphericalMercatorInvertedWorldSchema());
        }

        public string Url
        {
            get
            {
                return this.url;
            }
            set
            {
                this.url = value;
            }
        }
    }
}

