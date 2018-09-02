namespace VgsTiledMap.Ags
{
    using VgsMap.Tile;

    public interface IConfig
    {
        ITileSource CreateTileSource();
    }
}

