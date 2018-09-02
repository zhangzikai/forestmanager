namespace VgsTiledMap.Ags.VgsTile.TileSources.TiandiTu
{
    using System;
    using VgsMap.Tile;
    using VgsMap.Tile.Web;

    public sealed class VgsTiandituImgRequest : IRequest
    {
        private string _baseServer1 = "http://tile{0}.tianditu.com/DataServer?T={1}&X={2}&Y={3}&L={4}&d={5}";

        public Uri GetUri(TileInfo info)
        {
            int num2;
            int num = int.Parse(info.Index.LevelId);
            string str = string.Empty;
            if (num <= 10)
            {
                str = "sbsm0210";
            }
            else
            {
                switch (num)
                {
                    case 11:
                        str = "e11";
                        goto Label_006C;

                    case 12:
                        str = "e12";
                        goto Label_006C;

                    case 13:
                        str = "e13";
                        goto Label_006C;

                    case 14:
                        str = "eastdawnall";
                        goto Label_006C;
                }
                if ((num >= 15) && (num <= 0x12))
                {
                    str = "sbsm1518";
                }
            }
        Label_006C:
            num2 = ((int) (Math.Round((double) (((double) new Random().Next(1, 100)) / 100.0)) * 3.0)) + 1;
            object[] args = new object[] { num2, str, info.Index.Row, info.Index.Col, num, new DateTime().ToLongTimeString() };
            return new Uri(string.Format(this._baseServer1, args));
        }
    }
}

