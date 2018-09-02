namespace VgsTiledMap.Ags
{
    using System;
    using System.Collections.Generic;
    using VgsMap.Tile;
    using VgsMap.Tile.PreDefined;
    using VgsMap.Tile.Web;

    public class ConfigGeoserver : IConfig
    {
        public ITileSource CreateTileSource()
        {
            string uriString = "http://geoserver.nl/tiles/tilecache.aspx/1.0.0/world_GM/";
            Dictionary<string, string> customParameters = new Dictionary<string, string>();
            customParameters.Add("seriveparam", "ortho10");
            TmsRequest request = new TmsRequest(new Uri(uriString), "png", customParameters);
            return new TileSource(new WebTileProvider(request), new SphericalMercatorWorldSchema());
        }
    }
}

