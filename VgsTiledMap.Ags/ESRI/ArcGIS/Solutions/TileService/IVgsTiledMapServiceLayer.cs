namespace ESRI.ArcGIS.Solutions.TileService
{
    using System;
    using System.Net;
    using System.Runtime.InteropServices;

    [Guid("D73DCF6E-BD35-48ff-8CDF-53ADBC76B687")]
    public interface IVgsTiledMapServiceLayer
    {
        string GetTileUrl(int level, int row, int col);
        int MemoryCacheCapacity { get; set; }
        double MemoryCacheSize { get; }
        WebProxy Proxy { get; set; }
        int Timeout { get; set; }
        bool UseMemoryCache { get; set; }
        string UserAgent { get; set; }
        int getLevelByNearestScale(double scale);
    }
}

