namespace VgsTiledMap.Ags.VgsTile.Vgs
{
    using System;
    using System.Globalization;
    using VgsMap.Tile;

    public class VgsLindiTileSchema : TileSchema
    {
        public VgsLindiTileSchema()
        {
            double[] numArray = new double[] { 
                0.3515625, 0.17578125, 0.087890625, 0.0439453125, 0.02197265625, 0.010986328125, 0.0054931640625, 0.00274658203125, 0.001373291015625, 0.0006866455078125, 0.00034332275390625, 0.000171661376953125, 8.58306884765625E-05, 4.29153442382812E-05, 2.14576721191406E-05, 1.07288360595703E-05,
                5.36441802978516E-06
            };
            int num = 0;
            foreach (double num2 in numArray)
            {
                Resolution item = new Resolution();
                item.Id = num.ToString(CultureInfo.InvariantCulture);
                item.UnitsPerPixel = num2;
                base.Resolutions.Add(item);
                num++;
            }
            base.Height = 0x100;
            base.Width = 0x100;
            base.Extent = new Extent(-180.0, -90.0, 180.0, 90.0);
            base.OriginX = 0.0;
            base.OriginY = 0.0;
            base.Name = "XiAn80";
            base.Format = "png";
            base.Axis = AxisDirection.Normal;
            base.Srs = "EPSG:4610";
        }

        public string SrsWkt
        {
            get
            {
                return "GEOGCS[\"Xian 1980\",DATUM[\"D_Xian_1980\",SPHEROID[\"Xian_1980\",6378140,298.257]],PRIMEM[\"Greenwich\",0],UNIT[\"Degree\",0.017453292519943295]]";
            }
        }
    }
}

