namespace VgsTiledMap.Ags
{
    using System;
    using VgsMap.Tile.PreDefined;

    public class SpatialCloudSchema : SphericalMercatorWorldSchema
    {
        public SpatialCloudSchema()
        {
            base.Format = "jpg";
            base.Name = "SpatialCloud";
        }
    }
}

