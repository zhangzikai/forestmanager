namespace VgsTiledMap.Ags
{
    using System;
    using VgsMap.Tile;
    using VgsMap.Tile.Web;

    public class ConfigGoogle : IConfig
    {
        private GoogleMapType mapType = GoogleMapType.GoogleMap;

        public ConfigGoogle(GoogleMapType mapType)
        {
            this.mapType = mapType;
        }

        public ITileSource CreateTileSource()
        {
            ConfigurationHelper.GetConfig();
            return new GoogleTileSource(this.mapType);
        }
    }
}

