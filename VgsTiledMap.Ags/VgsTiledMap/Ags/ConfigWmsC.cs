namespace VgsTiledMap.Ags
{
    using System;
    using VgsMap.Tile;

    public class ConfigWmsC : IConfig
    {
        private ITileSource tileSource;

        public ConfigWmsC(ITileSource tileSource)
        {
            this.tileSource = tileSource;
        }

        public ITileSource CreateTileSource()
        {
            return this.tileSource;
        }
    }
}

