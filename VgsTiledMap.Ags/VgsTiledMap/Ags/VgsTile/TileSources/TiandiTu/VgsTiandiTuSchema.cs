namespace VgsTiledMap.Ags.VgsTile.TileSources.TiandiTu
{
    using System;
    using System.Globalization;
    using VgsMap.Tile;

    public sealed class VgsTiandiTuSchema : TileSchema
    {
        public VgsTiandiTuSchema()
        {
            double[] numArray = new double[] { 0.351563, 0.175781, 0.0878906, 0.0439453, 0.0219727, 0.0109863, 0.00549316, 0.00274658, 0.00137329, 0.000686646, 0.000343323, 0.000171661, 8.58307E-05, 4.29153E-05, 2.14577E-05 };
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
            base.OriginX = -180.0;
            base.OriginY = 90.0;
            base.Name = "New2000";
            base.Format = "png";
            base.Axis = AxisDirection.Normal;
            base.Srs = "EPSG:4326";
        }
    }
}

