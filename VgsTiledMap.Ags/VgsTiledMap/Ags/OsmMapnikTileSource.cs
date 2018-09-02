namespace VgsTiledMap.Ags
{
    using System;
    using VgsMap.Tile.PreDefined;
    using VgsMap.Tile.Web;

    public class OsmMapnikTileSource : TmsTileSource
    {
        public OsmMapnikTileSource() : base(new Uri("http://b.tah.openstreetmap.org/Tiles/tile"), new SphericalMercatorInvertedWorldSchema())
        {
        }
    }
}

