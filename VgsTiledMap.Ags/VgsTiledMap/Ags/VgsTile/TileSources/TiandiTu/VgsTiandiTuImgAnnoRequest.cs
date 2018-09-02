namespace VgsTiledMap.Ags.VgsTile.TileSources.TiandiTu
{
    using System;
    using VgsMap.Tile;
    using VgsMap.Tile.Web;

    public sealed class VgsTiandiTuImgAnnoRequest : IRequest
    {
        private string _baseServer1 = "http://tile{0}.tianditu.com/DataServer?T={1}&X={2}&Y={3}&L={4}&&d={5}";

        public Uri GetUri(TileInfo info)
        {
            int num = int.Parse(info.Index.LevelId);
            string str = string.Empty;
            string str2 = string.Empty;
            if (num <= 10)
            {
                str2 = "A0610_ImgAnno";
            }
            else if ((num >= 11) && (num <= 14))
            {
                str2 = "B0530_eImgAnno";
            }
            else if ((num > 14) && (num < 0x13))
            {
                str2 = "siweiAnno68";
            }
            else
            {
                str = "http://www.tianditu.com/js/GeoSurfJSAPI/img/blank.gif";
            }
            if (string.IsNullOrEmpty(str))
            {
                int num2 = (new Random().Next(1, 100) / 100) * 3;
                object[] args = new object[] { num2, str2, info.Index.Row, info.Index.Col, num, new DateTime().ToLongTimeString() };
                str = string.Format(this._baseServer1, args);
            }
            return new Uri(str);
        }
    }
}

