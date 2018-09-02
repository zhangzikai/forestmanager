namespace ESRI.ArcGIS.Solutions.TileService
{
    using ESRI.ArcGIS.Carto;
    using ESRI.ArcGIS.Display;
    using ESRI.ArcGIS.esriSystem;
    using ESRI.ArcGIS.Geodatabase;
    using ESRI.ArcGIS.Geometry;
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Drawing.Imaging;
    using System.IO;
    using System.Net;
    using System.Runtime.InteropServices;
    using System.Threading;

    [ClassInterface(ClassInterfaceType.None), Guid("909BD8C2-F24F-4500-B63F-BED1E9DDD836"), ProgId("ESRI.ArcGIS.Solutions.TileService.TiledMapServiceLayer")]
    public abstract class VgsTiledMapServiceLayer : VgsTiledCustomLayerBase, IVgsTiledMapServiceLayer
    {
        private int _layerInstanceID;
        private static int _layerUniqueId = 1;
        public WebProxy _Proxy;
        protected ESRI.ArcGIS.Solutions.TileService.TileInfo _tileInfo;
        public int _Timeout = 0x7530;
        private bool _UseMemoryCache = true;
        public string _UserAgent = "Mozilla/5.0 (Windows; U; Windows NT 6.0; en-US; rv:1.9.1.7) Gecko/20091221 Firefox/3.5.7";
        private ImageAttributes imageAttributes = new ImageAttributes();
        private readonly ReaderWriterLock kiberCacheLock = new ReaderWriterLock();
        private Dictionary<string, ImageTileInfo> pendingTiles = new Dictionary<string, ImageTileInfo>(100);
        private readonly VgsKiberTileCache TilesInMemory = new VgsKiberTileCache();

        public VgsTiledMapServiceLayer()
        {
            _layerUniqueId++;
            this._layerInstanceID = _layerUniqueId;
            this.imageAttributes.SetWrapMode(WrapMode.TileFlipXY);
        }

        private void AddTileToMemoryCache(RawTile tile, MemoryStream data)
        {
            this.kiberCacheLock.AcquireWriterLock(-1);
            try
            {
                if (!this.TilesInMemory.ContainsKey(tile))
                {
                    this.TilesInMemory.Add(tile, data);
                }
            }
            finally
            {
                this.kiberCacheLock.ReleaseWriterLock();
            }
        }

        private Extent caculateExtent(IDisplay disp, int row, int col, int level)
        {
            double resolution = this.TileInfo.Lods[level].Resolution;
            double minX = this.TileInfo.Origin.X + ((this.TileInfo.Width * col) * resolution);
            double maxY = this.TileInfo.Origin.Y - ((this.TileInfo.Height * row) * resolution);
            return new Extent(minX, maxY - (this.TileInfo.Height * resolution), minX + (this.TileInfo.Width * resolution), maxY);
        }

        protected Graphics CreateGraphics(IDisplay disp)
        {
            return Graphics.FromHdc(new IntPtr(disp.hDC));
        }

        private void downloadTile(ImageTileInfo data)
        {
            if (!string.IsNullOrEmpty(data.Url))
            {
                string tileKey = data.TileKey;
                if (data.Image == null)
                {
                    data.Image = this.GetImageFromUrl(data.Url);
                    if (this.UseMemoryCache)
                    {
                        RawTile tile = new RawTile(this._layerInstanceID, data.Row, data.Column, data.Level);
                        MemoryStream stream = new MemoryStream();
                        if (data.Image != null)
                        {
                            data.Image.Save(stream, ImageFormat.Png);
                            this.AddTileToMemoryCache(tile, stream);
                        }
                    }
                }
            }
        }

        private void downloadTiles(IDisplay disp, int level, double resolution, int startCol, int startRow, int endCol, int endRow)
        {
            this.pendingTiles.Clear();
            for (int i = startRow; i <= endRow; i++)
            {
                for (int j = startCol; j <= endCol; j++)
                {
                    Extent extent = this.caculateExtent(disp, i, j, level);
                    Image image = null;
                    if (this.UseMemoryCache)
                    {
                        image = this.getFromCache(i, j, level);
                    }
                    string key = this.GetTileUrl(level, i, j);
                    if (!this.pendingTiles.ContainsKey(key))
                    {
                        ImageTileInfo data = new ImageTileInfo(i, j, level, key, extent);
                        if (image != null)
                        {
                            data.Image = image;
                        }
                        this.downloadTile(data);
                        lock (this.pendingTiles)
                        {
                            this.pendingTiles.Add(data.Url, data);
                        }
                    }
                }
            }
        }

        public override void Draw(esriDrawPhase DrawPhase, IDisplay Display, ITrackCancel TrackCancel)
        {
            if ((DrawPhase == esriDrawPhase.esriDPGeography) && (Display != null))
            {
                double scaleRatio = Display.DisplayTransformation.ScaleRatio;
                int level = this.getLevelByNearestScale(scaleRatio);
                int[] numArray = this.getTileSpanWithin(Display.DisplayTransformation.VisibleBounds, level);
                if ((numArray[2] >= 0) || (numArray[3] >= 0))
                {
                    double resolution = this.TileInfo.Lods[level].Resolution;
                    this.downloadTiles(Display, level, resolution, numArray[0], numArray[1], numArray[2], numArray[3]);
                    using (Graphics graphics = this.CreateGraphics(Display))
                    {
                        IPoint mapPoint = new PointClass();
                        IPoint point2 = new PointClass();
                        foreach (ImageTileInfo info in this.pendingTiles.Values)
                        {
                            if (info.Image != null)
                            {
                                int num4;
                                int num5;
                                int num6;
                                int num7;
                                mapPoint.PutCoords(info.Extent.MinX, info.Extent.MinY);
                                point2.PutCoords(info.Extent.MaxX, info.Extent.MaxY);
                                Display.DisplayTransformation.FromMapPoint(mapPoint, out num4, out num5);
                                Display.DisplayTransformation.FromMapPoint(point2, out num6, out num7);
                                graphics.DrawImage(info.Image, new Rectangle(num4, num7, num6 - num4, num5 - num7), 0, 0, this.TileInfo.Width, this.TileInfo.Height, GraphicsUnit.Pixel, this.imageAttributes);
                            }
                        }
                    }
                }
                IInvalidArea area = new InvalidAreaClass();
                area.Add(Display.DisplayTransformation.VisibleBounds);
                area.Display = Display as IScreenDisplay;
                area.Invalidate(-1);
            }
        }

        protected Image getFromCache(int row, int col, int level)
        {
            RawTile tile = new RawTile(this._layerInstanceID, row, col, level);
            MemoryStream tileFromMemoryCache = this.GetTileFromMemoryCache(tile);
            if (tileFromMemoryCache == null)
            {
                return null;
            }
            return Image.FromStream(tileFromMemoryCache);
        }

        private Image GetImageFromUrl(string url)
        {
            HttpWebRequest request = (HttpWebRequest) WebRequest.Create(url);
            request.ServicePoint.ConnectionLimit = 50;
            request.Proxy = (this.Proxy != null) ? this.Proxy : WebRequest.DefaultWebProxy;
            request.UserAgent = this.UserAgent;
            request.Timeout = this.Timeout;
            request.ReadWriteTimeout = 0x2710;
            request.Accept = "text/html, application/xml;q=0.9, application/xhtml+xml, image/png, image/jpeg, image/gif, image/x-xbitmap, */*;q=0.1";
            request.Headers["Accept-Encoding"] = "deflate, gzip, x-gzip, identity, *;q=0";
            request.KeepAlive = true;
            try
            {
                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {
                    using (Stream stream = response.GetResponseStream())
                    {
                        return Image.FromStream(stream, true, true);
                    }
                }
            }
            catch (WebException)
            {
            }
            return null;
        }

        private int getLevelByNearestResolution(double resolution)
        {
            int index = 0;
            for (int i = 1; i < this.TileInfo.Lods.Length; i++)
            {
                if (Math.Abs((double) (this.TileInfo.Lods[i].Resolution - resolution)) < Math.Abs((double) (this.TileInfo.Lods[index].Resolution - resolution)))
                {
                    index = i;
                }
            }
            return index;
        }

        public int getLevelByNearestScale(double scale)
        {
            int index = 0;
            for (int i = 1; i < this.TileInfo.Lods.Length; i++)
            {
                if (Math.Abs((double) (this.TileInfo.Lods[i].Scale - scale)) < Math.Abs((double) (this.TileInfo.Lods[index].Scale - scale)))
                {
                    index = i;
                }
            }
            return index;
        }

        private MemoryStream GetTileFromMemoryCache(RawTile tile)
        {
            this.kiberCacheLock.AcquireReaderLock(-1);
            try
            {
                MemoryStream stream = null;
                if (this.TilesInMemory.TryGetValue(tile, out stream))
                {
                    return stream;
                }
            }
            finally
            {
                this.kiberCacheLock.ReleaseReaderLock();
            }
            return null;
        }

        private int[] getTileSpanWithin(IEnvelope envelope, int level)
        {
            envelope.Intersect(this.Extent);
            if (envelope != null)
            {
                double x = 0.0;
                double y = 0.0;
                if (this.TileInfo.Origin != null)
                {
                    x = this.TileInfo.Origin.X;
                    y = this.TileInfo.Origin.Y;
                }
                else
                {
                    x = this.Extent.XMin;
                    y = this.Extent.YMax;
                }
                Lod lod = this.TileInfo.Lods[level];
                double resolution = lod.Resolution;
                int num4 = (int) Math.Floor((double) (((envelope.XMin - x) + (lod.Resolution * 0.5)) / (resolution * this.TileInfo.Width)));
                int num5 = (int) Math.Floor((double) (((y - envelope.YMax) + (lod.Resolution * 0.5)) / (resolution * this.TileInfo.Height)));
                if (num4 < 0)
                {
                    num4 = 0;
                }
                if (num5 < 0)
                {
                    num5 = 0;
                }
                int num6 = (int) Math.Floor((double) (((envelope.XMax - x) - (lod.Resolution * 0.5)) / (resolution * this.TileInfo.Width)));
                int num7 = (int) Math.Floor((double) (((y - envelope.YMin) - (lod.Resolution * 0.5)) / (resolution * this.TileInfo.Height)));
                return new int[] { num4, num5, num6, num7 };
            }
            int[] numArray = new int[4];
            numArray[2] = -1;
            numArray[3] = -1;
            return numArray;
        }

        public abstract string GetTileUrl(int level, int row, int col);

        public int MemoryCacheCapacity
        {
            get
            {
                int memoryCacheCapacity;
                this.kiberCacheLock.AcquireReaderLock(-1);
                try
                {
                    memoryCacheCapacity = this.TilesInMemory.MemoryCacheCapacity;
                }
                finally
                {
                    this.kiberCacheLock.ReleaseReaderLock();
                }
                return memoryCacheCapacity;
            }
            set
            {
                this.kiberCacheLock.AcquireWriterLock(-1);
                try
                {
                    this.TilesInMemory.MemoryCacheCapacity = value;
                }
                finally
                {
                    this.kiberCacheLock.ReleaseWriterLock();
                }
            }
        }

        public double MemoryCacheSize
        {
            get
            {
                double memoryCacheSize;
                this.kiberCacheLock.AcquireReaderLock(-1);
                try
                {
                    memoryCacheSize = this.TilesInMemory.MemoryCacheSize;
                }
                finally
                {
                    this.kiberCacheLock.ReleaseReaderLock();
                }
                return memoryCacheSize;
            }
        }

        public WebProxy Proxy
        {
            get
            {
                return this._Proxy;
            }
            set
            {
                this._Proxy = value;
            }
        }

        public ESRI.ArcGIS.Solutions.TileService.TileInfo TileInfo
        {
            get
            {
                return this._tileInfo;
            }
            set
            {
                this._tileInfo = value;
            }
        }

        public int Timeout
        {
            get
            {
                return this._Timeout;
            }
            set
            {
                this._Timeout = value;
            }
        }

        public bool UseMemoryCache
        {
            get
            {
                return this._UseMemoryCache;
            }
            set
            {
                this._UseMemoryCache = value;
            }
        }

        public string UserAgent
        {
            get
            {
                return this._UserAgent;
            }
            set
            {
                this._UserAgent = value;
            }
        }
    }
}

