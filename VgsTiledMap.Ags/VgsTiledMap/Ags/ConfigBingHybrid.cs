namespace VgsTiledMap.Ags
{
    using System;
    using System.Configuration;
    using VgsMap.Tile;
    using VgsMap.Tile.Web;

    public class ConfigBingHybrid : IConfig
    {
        public ITileSource CreateTileSource()
        {
            System.Configuration.Configuration config = ConfigurationHelper.GetConfig();
            return new BingTileSource(config.AppSettings.Settings["BingUrl"].Value, config.AppSettings.Settings["BingToken"].Value, BingMapType.Hybrid);
        }
    }
}

