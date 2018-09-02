namespace VgsTiledMap.Ags
{
    using System;
    using VgsMap.Tile;
    using VgsMap.Tile.Web;

    public class ConfigSOSO : IConfig
    {
        private SOSOMapType mapType = SOSOMapType.SOSOMap;

        public ConfigSOSO(SOSOMapType mapType)
        {
            this.mapType = mapType;
        }

        public ITileSource CreateTileSource()
        {
            ConfigurationHelper.GetConfig();
            return new SOSOTileSource(this.mapType);
        }
    }
}

