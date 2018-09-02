namespace VgsTiledMap.Ags.VgsTile.TileSources.TiandiTu
{
    using System;
    using VgsMap.Tile;
    using VgsMap.Tile.Web;

    public sealed class VgsTiandiTuAnnoRequest : IRequest
    {
        private string _baseDomain = "http://tile";
        private string _baseServer = ".tianditu.com/DataServer?T=AB0512_Anno";

        public Uri GetUri(TileInfo info)
        {
            int num = ((int) Math.Round((double) ((new Random().Next(1, 100) / 100) * 6))) + 1;
            return new Uri(string.Format("{0}{1}{2}&X={3}&Y={4}&L={5}", new object[] { this._baseDomain, num, this._baseServer, info.Index.Col, info.Index.Row, int.Parse(info.Index.LevelId) + 1 }));
        }
    }
}

