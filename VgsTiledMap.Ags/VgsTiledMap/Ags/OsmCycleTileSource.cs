namespace VgsTiledMap.Ags
{
    using System;
    using VgsMap.Tile.PreDefined;
    using VgsMap.Tile.Web;

    public class OsmCycleTileSource : TmsTileSource
    {
        public OsmCycleTileSource() : base(new Uri("http://b.andy.sandbox.cloudmade.com/tiles/cycle"), new SphericalMercatorInvertedWorldSchema())
        {
        }
    }
}

