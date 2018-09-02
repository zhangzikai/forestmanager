namespace VgsTiledMap.Ags
{
    using System;
    using System.Collections.Generic;
    using VgsMap.Tile;
    using VgsMap.Tile.Web;

    public class SpatialCloudTileSource : ITileSource
    {
        private Dictionary<string, string> customParams;
        private string loginid;
        private string password;
        private WebTileProvider tileProvider;
        private TileSchema tileSchema;

        public SpatialCloudTileSource(Uri url, string loginid, string password)
        {
            this.loginid = loginid;
            this.password = password;
            this.tileSchema = new SpatialCloudSchema();
            this.customParams = new Dictionary<string, string>();
            this.customParams.Add("loginid", loginid);
            this.customParams.Add("viewer", "viewer");
            TmsRequest request = new TmsRequest(url, this.tileSchema.Format, this.customParams);
            this.tileProvider = new WebTileProvider(request);
        }

        public string AuthSign
        {
            set
            {
                if (this.customParams.ContainsKey("authSign"))
                {
                    this.customParams.Remove("authSign");
                }
                this.customParams.Add("authSign", value);
            }
        }

        public string LoginId
        {
            get
            {
                return this.loginid;
            }
        }

        public string Password
        {
            get
            {
                return this.password;
            }
        }

        public ITileProvider Provider
        {
            get
            {
                return this.tileProvider;
            }
        }

        public ITileSchema Schema
        {
            get
            {
                return this.tileSchema;
            }
        }
    }
}

