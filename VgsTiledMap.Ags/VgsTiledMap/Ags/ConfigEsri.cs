namespace VgsTiledMap.Ags
{
    using System;
    using VgsMap.Tile;
    using VgsMap.Tile.Web;

    public class ConfigEsri : IConfig
    {
        public ITileSource CreateTileSource()
        {
            return new TileSource(Provider, Schema);
        }

        private static ITileProvider Provider
        {
            get
            {
                return new WebTileProvider(RequestBuilder);
            }
        }

        private static IRequest RequestBuilder
        {
            get
            {
                return new BasicRequest("http://server.arcgisonline.com/ArcGIS/rest/services/ESRI_StreetMap_World_2D/MapServer/tile/{0}/{2}/{1}");
            }
        }

        private static ITileSchema Schema
        {
            get
            {
                double[] numArray = new double[] { 0.3515625, 0.17578125, 0.087890625, 0.0439453125, 0.02197265625, 0.010986328125, 0.0054931640625, 0.00274658203125, 0.001373291015625, 0.0006866455078125, 0.00034332275390625, 0.000171661376953125, 8.58306884765629E-05, 4.29153442382814E-05, 2.14576721191407E-05, 1.07288360595703E-05 };
                TileSchema schema = new TileSchema();
                int num = 0;
                foreach (double num2 in numArray)
                {
                    Resolution resolution2 = new Resolution();
                    resolution2.Id = num.ToString();
                    resolution2.UnitsPerPixel = num2;
                    Resolution item = resolution2;
                    schema.Resolutions.Add(item);
                    num++;
                }
                schema.Height = 0x200;
                schema.Width = 0x200;
                schema.Extent = new Extent(-180.0, -90.0, 180.0, 90.0);
                schema.OriginX = -180.0;
                schema.OriginY = 90.0;
                schema.Name = "ESRI";
                schema.Format = "jpg";
                schema.Axis = AxisDirection.InvertedY;
                schema.Srs = "EPSG:4326";
                return schema;
            }
        }
    }
}

