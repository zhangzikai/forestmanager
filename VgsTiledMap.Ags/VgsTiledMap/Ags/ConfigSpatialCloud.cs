namespace VgsTiledMap.Ags
{
    using System;
    using System.Configuration;
    using VgsMap.Tile;

    public class ConfigSpatialCloud : IConfig
    {
        public ITileSource CreateTileSource()
        {
            System.Configuration.Configuration config = ConfigurationHelper.GetConfig();
            string uriString = config.AppSettings.Settings["SpatialCloudUrl"].Value;
            return new SpatialCloudTileSource(new Uri(uriString), config.AppSettings.Settings["SpatialCloudUsername"].Value, config.AppSettings.Settings["SpatialCloudPassword"].Value);
        }
    }
}

