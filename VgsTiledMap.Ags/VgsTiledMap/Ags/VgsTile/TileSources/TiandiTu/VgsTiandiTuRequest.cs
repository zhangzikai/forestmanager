namespace VgsTiledMap.Ags.VgsTile.TileSources.TiandiTu
{
    using System;
    using VgsMap.Tile;
    using VgsMap.Tile.Web;

    public sealed class VgsTiandiTuRequest : IRequest
    {
        private string _baseDomain = "http://tile";
        private string _baseServer1 = ".tianditu.com/DataServer?T=A0512_EMap";
        private string _baseServer2 = ".tainditu.com/DataServer?T=B0627_EMap112";
        private string _baseServer3 = ".tianditu.com/DataServer?T=siwei0608";

        public Uri GetUri(TileInfo info)
        {
            int num = int.Parse(info.Index.LevelId);
            string str = string.Empty;
            if (num < 10)
            {
                str = this._baseServer1;
            }
            else if ((num == 10) || (num == 11))
            {
                str = this._baseServer2;
            }
            else
            {
                str = this._baseServer3;
            }
            int num2 = ((int) (Math.Round((double) (new Random().Next(1, 100) / 100)) * 6.0)) + 1;
            return new Uri(string.Format("{0}{1}{2}&X={3}&Y={4}&L={5}", new object[] { this._baseDomain, num2, str, info.Index.Col, info.Index.Row, int.Parse(info.Index.LevelId) + 1 }));
        }
    }
}

