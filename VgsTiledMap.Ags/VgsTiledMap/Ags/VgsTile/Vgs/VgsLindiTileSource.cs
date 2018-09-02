namespace VgsTiledMap.Ags.VgsTile.Vgs
{
    using System;
    using VgsMap.Tile;
    using VgsMap.Tile.Cache;
    using VgsMap.Tile.Web;

    public class VgsLindiTileSource : ITileSource
    {
        private readonly WebTileProvider _tileProvider;
        private readonly TileSchema _tileSchema;
        public const string UserAgent = "Mozilla/5.0 (Windows; U; Windows NT 6.0; en-US; rv:1.9.1.7) Gecko/20091221 Firefox/3.5.7";

        public VgsLindiTileSource(VgsTiledMap.Ags.VgsTile.Vgs.VgsLindTileRequest request) : this(request, new NullCache())
        {
        }

        public VgsLindiTileSource(VgsTiledMap.Ags.VgsTile.Vgs.VgsLindTileRequest request, ITileCache<byte[]> tileCache)
        {
            this._tileSchema = new VgsTiledMap.Ags.VgsTile.Vgs.VgsLindiTileSchema();
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

