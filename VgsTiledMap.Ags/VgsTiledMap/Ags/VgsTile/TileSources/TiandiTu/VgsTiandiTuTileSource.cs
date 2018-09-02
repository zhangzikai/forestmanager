namespace VgsTiledMap.Ags.VgsTile.TileSources.TiandiTu
{
    using System;
    using VgsMap.Tile;
    using VgsMap.Tile.Cache;
    using VgsMap.Tile.Web;

    public sealed class VgsTiandiTuTileSource : ITileSource
    {
        private readonly WebTileProvider _tileProvider;
        private readonly TileSchema _tileSchema;
        public const string UserAgent = "Mozilla/5.0 (Windows; U; Windows NT 6.0; en-US; rv:1.9.1.7) Gecko/20091221 Firefox/3.5.7";

        public VgsTiandiTuTileSource(IRequest request) : this(request, new NullCache())
        {
        }

        public VgsTiandiTuTileSource(IRequest request, ITileCache<byte[]> tileCache)
        {
            this._tileSchema = new VgsTiandiTuSchema();
            this._tileProvider = new WebTileProvider(request, tileCache, "Mozilla/5.0 (Windows; U; Windows NT 6.0; en-US; rv:1.9.1.7) Gecko/20091221 Firefox/3.5.7", "", false);
        }

        public ITileProvider Provider
        {
            get
            {
                return this._tileProvider;
            }
        }

        public ITileSchema Schema
        {
            get
            {
                return this._tileSchema;
            }
        }
    }
}

