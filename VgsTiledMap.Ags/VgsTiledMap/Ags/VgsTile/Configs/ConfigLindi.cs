namespace VgsTiledMap.Ags.VgsTile.Configs
{
    using System;
    using System.Configuration;
    using System.Runtime.CompilerServices;
    using VgsMap.Tile;
    using VgsTiledMap.Ags;
    using VgsTiledMap.Ags.VgsTile.Vgs;

    public class ConfigLindi : IConfig
    {
     

        public ConfigLindi(string baseUrl, string lyrname, string lyrYear, string lyrType)
        {
            this.LyrName = lyrname;
            this.LyrYear = lyrYear;
            this.BaseUrl = baseUrl;
            this.TType = lyrType;
            if (string.IsNullOrEmpty(this.TType))
            {
                this.TType = "png";
            }
        }

        public ITileSource CreateTileSource()
        {
            if (string.IsNullOrEmpty(this.BaseUrl))
            {
                KeyValueConfigurationElement element = ConfigurationHelper.GetConfig().AppSettings.Settings["VgsUrl"];
                if (element != null)
                {
                    this.BaseUrl = element.Value;
                }
            }
            return new VgsTiledMap.Ags.VgsTile.Vgs.VgsLindiTileSource(new VgsTiledMap.Ags.VgsTile.Vgs.VgsLindTileRequest(this.BaseUrl, this.LyrName, this.LyrYear, this.TType));
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

        public string LyrPathNam
        {
            get
            {
                if (string.IsNullOrEmpty(this.LyrYear))
                {
                    return this.LyrName;
                }
                return (this.LyrName + "_" + this.LyrYear);
            }
        }

        public string LyrYear
        {
            get;
            set;
        }

        public int MaxLevel
        {
            get;
            set;
        }

        public int MinLevel
        {
            get;
            set;
        }

        public string TType
        {
            get;
            set;
        }
    }
}

