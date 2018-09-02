namespace VgsTiledMap.Ags
{
    using System;
    using System.Collections.Generic;
    using VgsMap.Tile;
    using VgsMap.Tile.Web;

    public class ConfigGeodanGeoserver : IConfig
    {
        private static double[] ScalesGeodan = new double[] { 3276.0, 1092.0, 364.0, 122.0, 40.5, 13.5, 4.5, 1.5, 0.5, 0.1666666667 };

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
                string uriString = ConfigurationHelper.GetConfig().AppSettings.Settings["GeoserverUrl"].Value;
                List<string> list2 = new List<string>();
                list2.Add("lufo2009");
                List<string> layers = list2;
                Dictionary<string, string> customParameters = new Dictionary<string, string>();
                customParameters.Add("seriveparam", "ortho10");
                return new WmscRequest(new Uri(uriString), Schema, layers, new List<string>(), customParameters);
            }
        }

        public static ITileSchema Schema
        {
            get
            {
                TileSchema schema = new TileSchema();
                int num = 0;
                foreach (double num2 in ScalesGeodan)
                {
                    Resolution resolution2 = new Resolution();
                    resolution2.Id = num.ToString();
                    resolution2.UnitsPerPixel = num2;
                    Resolution item = resolution2;
                    schema.Resolutions.Add(item);
                    num++;
                }
                schema.Height = 0x100;
                schema.Width = 0x100;
                schema.Extent = new Extent(0.0, 300000.0, 300000.0, 660000.0);
                schema.OriginX = 0.0;
                schema.OriginY = 300000.0;
                schema.Name = "GeodanGeoserver";
                schema.Format = "jpg";
                schema.Axis = AxisDirection.Normal;
                schema.Srs = "EPSG:28992";
                return schema;
            }
        }
    }
}

