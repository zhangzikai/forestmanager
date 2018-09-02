namespace VgsTiledMap.Ags
{
    using System;
    using System.IO;
    using System.Net;
    using System.Runtime.CompilerServices;
    using VgsMap.Tile;
    using VgsMap.Tile.Web.TmsService;

    public class ConfigTms : IConfig
    {
     
        private bool overwriteUrls;

        public ConfigTms(string url, bool OverwriteUrls)
        {
            this.Url = url;
            this.overwriteUrls = OverwriteUrls;
        }

        public ITileSource CreateTileSource()
        {
            HttpWebRequest request = (HttpWebRequest) WebRequest.Create(this.Url);
            request.UserAgent = "Mozilla/5.0 (Windows; U; Windows NT 5.1; en-US; rv:1.8.1.14) Gecko/20080404 Firefox/2.0.0.14";
            Stream responseStream = ((HttpWebResponse) request.GetResponse()).GetResponseStream();
            if (this.overwriteUrls)
            {
                return TileMapParser.CreateTileSource(responseStream, this.Url, null);
            }
            return TileMapParser.CreateTileSource(responseStream);
        }

        public string Url
        {
            get;
            set;
        }
    }
}

