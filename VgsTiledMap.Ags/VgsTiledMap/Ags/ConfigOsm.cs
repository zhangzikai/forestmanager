namespace VgsTiledMap.Ags
{
    using System;
    using VgsMap.Tile;
    using VgsMap.Tile.Web;

    public class ConfigOsm : IConfig
    {
        private OsmMapType osmMapType;

        public ConfigOsm(OsmMapType maptype)
        {
            this.osmMapType = maptype;
        }

        public ITileSource CreateTileSource()
        {
            ITileSource source = null;
            if (this.osmMapType == OsmMapType.Default)
            {
                return new OsmTileSource();
            }
            if (this.osmMapType == OsmMapType.Mapnik)
            {
                return new OsmMapnikTileSource();
            }
            if (this.osmMapType == OsmMapType.Cycle)
            {
                source = new OsmCycleTileSource();
            }
            return source;
        }
    }
}

