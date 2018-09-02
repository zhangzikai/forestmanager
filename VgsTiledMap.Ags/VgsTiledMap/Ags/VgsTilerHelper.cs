namespace VgsTiledMap.Ags
{
    using ESRI.ArcGIS.Carto;
    using ESRI.ArcGIS.DataSourcesRaster;
    using ESRI.ArcGIS.Display;
    using ESRI.ArcGIS.esriSystem;
    using ESRI.ArcGIS.Framework;
    using ESRI.ArcGIS.Geodatabase;
    using ESRI.ArcGIS.Geometry;
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Threading;
    using VgsMap.Tile;
    using VgsMap.Tile.Cache;
    using VgsMap.Tile.Web;
    using VgsTiledMap.Ags.VgsTile.Configs;

    public class VgsTilerHelper
    {
        private int _currentLevel;
        private IActiveView activeView;
        private IApplication application;
        private static string cacheDir;
        private IConfig config;
        private static ISpatialReference dataSpatialReference;
        private IDisplay display;
        private static EnumArcVgsTileLayer enumArcTilerLayer;
        private static FileCache fileCache;
        private static ISpatialReference layerSpatialReference;
        private bool needReproject;
        private Random random = new Random((int) DateTime.Now.Ticks);
        private static WebTileProvider tileProvider;
        private IList<TileInfo> tiles;
        private static ITileSource tileSource;
        private static int tileTimeOut;
        private static ITrackCancel trackCancel;

        public VgsTilerHelper(string cacheDir, int tileTimeOut)
        {
            VgsTilerHelper.cacheDir = cacheDir;
            VgsTilerHelper.tileTimeOut = tileTimeOut;
        }

        private static bool CreateRaster(TileInfo tile, byte[] bytes, string name)
        {
            ITileSchema schema = tileSource.Schema;
            FileInfo info = new FileInfo(name);
            WriteWorldFile(name.Replace(info.Extension, "." + GetWorldFile(schema.Format)), tile.Extent, schema);
            return true;
        }

        private static void downloadTile(object tile)
        {
            object[] objArray = (object[]) tile;
            if (objArray.Length != 2)
            {
                throw new ArgumentException("Two parameters expected");
            }
            TileInfo info = (TileInfo) objArray[0];
            MultipleThreadResetEvent event2 = (MultipleThreadResetEvent) objArray[1];
            try
            {
                if (!trackCancel.Continue())
                {
                    event2.SetOne();
                    return;
                }
                byte[] bitmap = GetBitmap(tileProvider.Request.GetUri(info));
                if (bitmap != null)
                {
                    string fileName = fileCache.GetFileName(info.Index);
                    fileCache.Add(info.Index, bitmap);
                    CreateRaster(info, bitmap, fileName);
                }
            }
            catch (Exception)
            {
            }
            event2.SetOne();
        }

        private void DownloadTiles(object args)
        {
            try
            {
                ManualResetEvent event2 = args as ManualResetEvent;
                IList<TileInfo> list = new List<TileInfo>();
                for (int i = 0; i < this.tiles.Count; i++)
                {
                    if (!fileCache.Exists(this.tiles[i].Index))
                    {
                        list.Add(this.tiles[i]);
                    }
                    else
                    {
                        string fileName = fileCache.GetFileName(this.tiles[i].Index);
                        FileInfo info = new FileInfo(fileName);
                        TimeSpan span = (TimeSpan) (DateTime.Now - info.LastWriteTime);
                        if (span.Days > tileTimeOut)
                        {
                            System.IO.File.Delete(fileName);
                            list.Add(this.tiles[i]);
                        }
                    }
                }
                if (list.Count > 0)
                {
                    MultipleThreadResetEvent event3 = new MultipleThreadResetEvent(list.Count);
                    for (int j = 0; j < list.Count; j++)
                    {
                        object state = new object[] { list[j], event3 };
                        ThreadPool.SetMaxThreads(20, 20);
                        ThreadPool.QueueUserWorkItem(new WaitCallback(VgsTilerHelper.downloadTile), state);
                    }
                    event3.WaitAll();
                }
                event2.Set();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Draw(IActiveView activeView, IConfig config, ITrackCancel trackCancel, ISpatialReference layerSpatialReference, EnumArcVgsTileLayer enumArcTilerLayer, ref int currentLevel, ITileSource tileSource, IDisplay display)
        {
            this.activeView = activeView;
            this.config = config;
            VgsTilerHelper.tileSource = tileSource;
            VgsTilerHelper.trackCancel = trackCancel;
            VgsTilerHelper.layerSpatialReference = layerSpatialReference;
            VgsTilerHelper.enumArcTilerLayer = enumArcTilerLayer;
            this._currentLevel = currentLevel;
            fileCache = GetFileCache(config);
            tileProvider = (WebTileProvider) tileSource.Provider;
            this.display = display;
            if (!activeView.Extent.IsEmpty)
            {
                this.tiles = this.GetTiles(activeView, config);
                currentLevel = this._currentLevel;
                if (this.config != null)
                {
                    ConfigLindi lindi1 = this.config as ConfigLindi;
                }
                if (this.tiles.Count > 0)
                {
                    ManualResetEvent parameter = new ManualResetEvent(false);
                    new Thread(new ParameterizedThreadStart(this.DownloadTiles)).Start(parameter);
                    parameter.WaitOne();
                    if ((layerSpatialReference != null) && (dataSpatialReference != null))
                    {
                        this.needReproject = layerSpatialReference.FactoryCode != dataSpatialReference.FactoryCode;
                    }
                    foreach (TileInfo info in this.tiles)
                    {
                        if (info != null)
                        {
                            string fileName = fileCache.GetFileName(info.Index);
                            if (System.IO.File.Exists(fileName))
                            {
                                IEnvelope env = this.GetEnv(info.Extent);
                                this.DrawRaster(fileName, env, trackCancel);
                            }
                        }
                    }
                }
            }
        }

        public void Draw(IApplication application, IActiveView activeView, IConfig config, ITrackCancel trackCancel, ISpatialReference layerSpatialReference, EnumArcVgsTileLayer enumArcTilerLayer, ref int currentLevel, ITileSource tileSource, IDisplay display)
        {
            this.application = application;
            this.activeView = activeView;
            this.config = config;
            VgsTilerHelper.tileSource = tileSource;
            VgsTilerHelper.trackCancel = trackCancel;
            VgsTilerHelper.layerSpatialReference = layerSpatialReference;
            VgsTilerHelper.enumArcTilerLayer = enumArcTilerLayer;
            this._currentLevel = currentLevel;
            fileCache = GetFileCache(config);
            tileProvider = (WebTileProvider) tileSource.Provider;
            this.display = display;
            if (!activeView.Extent.IsEmpty)
            {
                this.tiles = this.GetTiles(activeView, config);
                currentLevel = this._currentLevel;
                if (this.config != null)
                {
                    ConfigLindi lindi1 = this.config as ConfigLindi;
                }
                if (this.tiles.Count > 0)
                {
                    application.StatusBar.ProgressBar.MinRange = 0;
                    application.StatusBar.ProgressBar.MaxRange = this.tiles.Count;
                    application.StatusBar.ProgressBar.Show();
                    ManualResetEvent parameter = new ManualResetEvent(false);
                    new Thread(new ParameterizedThreadStart(this.DownloadTiles)).Start(parameter);
                    parameter.WaitOne();
                    if ((layerSpatialReference != null) && (dataSpatialReference != null))
                    {
                        this.needReproject = layerSpatialReference.FactoryCode != dataSpatialReference.FactoryCode;
                    }
                    foreach (TileInfo info in this.tiles)
                    {
                        application.StatusBar.ProgressBar.Step();
                        if (info != null)
                        {
                            string fileName = fileCache.GetFileName(info.Index);
                            if (System.IO.File.Exists(fileName))
                            {
                                IEnvelope env = this.GetEnv(info.Extent);
                                this.DrawRaster(fileName, env, trackCancel);
                            }
                        }
                    }
                    application.StatusBar.ProgressBar.Hide();
                }
            }
        }

        private void DrawRaster(string file, IEnvelope env, ITrackCancel trackCancel)
        {
            try
            {
                ITileSchema schema = tileSource.Schema;
                IRasterLayer layer = new RasterLayerClass();
                layer.CreateFromFilePath(file);
                IRasterProps raster = (IRasterProps) layer.Raster;
                raster.SpatialReference = dataSpatialReference;
                raster.Height = schema.Height;
                raster.Width = schema.Width;
                if (this.needReproject)
                {
                    IRasterGeometryProc proc = new RasterGeometryProcClass();
                    object missing = Type.Missing;
                    proc.ProjectFast(layerSpatialReference, rstResamplingTypes.RSP_NearestNeighbor, ref missing, layer.Raster);
                }
                layer.SpatialReference = layerSpatialReference;
                layer.Draw(esriDrawPhase.esriDPGeography, this.display, null);
                this.activeView.PartialRefresh(esriViewDrawPhase.esriViewGeography, trackCancel, env);
            }
            catch (Exception)
            {
            }
        }

        public static byte[] GetBitmap(Uri uri)
        {
            byte[] buffer = null;
            string userAgent = "Mozilla/5.0 (Windows; U; Windows NT 5.1; en-US; rv:1.8.1.14) Gecko/20080404 Firefox/2.0.0.14";
            string referer = string.Empty;
            try
            {
                buffer = RequestHelper.FetchImage(uri, userAgent, referer, false);
            }
            catch (WebException)
            {
            }
            return buffer;
        }

        private static string GetCacheDirectory(IConfig config, EnumArcVgsTileLayer layerType)
        {
            string str = string.Format("{0}{1}{2}", cacheDir, System.IO.Path.DirectorySeparatorChar, layerType.ToString());
            if (((layerType == EnumArcVgsTileLayer.VgsTiled) || (layerType == EnumArcVgsTileLayer.VgsSatellite)) || (layerType == EnumArcVgsTileLayer.EviaTiledSatellite))
            {
                str = string.Format("{0}{1}{2}", str, System.IO.Path.DirectorySeparatorChar, ((ConfigLindi) config).LyrPathNam);
            }
            if ((enumArcTilerLayer != EnumArcVgsTileLayer.TMS) && (enumArcTilerLayer != EnumArcVgsTileLayer.InvertedTMS))
            {
                return str;
            }
            string str2 = (enumArcTilerLayer == EnumArcVgsTileLayer.TMS) ? ((ConfigTms) config).Url : ((ConfigInvertedTMS) config).Url;
            string str3 = str2.Substring(7, str2.Length - 7).Replace("/", "-").Replace(":", "-");
            if (str3.EndsWith("-"))
            {
                str3 = str3.Substring(0, str3.Length - 1);
            }
            return string.Format("{0}{1}{2}{3}{4}", new object[] { cacheDir, System.IO.Path.DirectorySeparatorChar, layerType.ToString(), System.IO.Path.DirectorySeparatorChar, str3 });
        }

        private PointF GetCenterPoint(IEnvelope env)
        {
            PointF tf = new PointF();
            tf.X = Convert.ToSingle((double) (env.XMin + ((env.XMax - env.XMin) / 2.0)));
            tf.Y = Convert.ToSingle((double) (env.YMin + ((env.YMax - env.YMin) / 2.0)));
            return tf;
        }

        private IEnvelope GetEnv(Extent extent)
        {
            EnvelopeClass class2 = new EnvelopeClass();
            class2.XMin = extent.MinX;
            class2.XMax = extent.MaxX;
            class2.YMin = extent.MinY;
            class2.YMax = extent.MaxY;
            return class2;
        }

        private static FileCache GetFileCache(IConfig config)
        {
            ITileSchema schema = tileSource.Schema;
            dataSpatialReference = new SpatialReferences().GetSpatialReference(schema.Srs);
            string cacheDirectory = GetCacheDirectory(config, enumArcTilerLayer);
            string format = schema.Format;
            if (format.Contains("image/"))
            {
                format = format.Substring(6, schema.Format.Length - 6);
            }
            if (format.Contains("png8"))
            {
                format = format.Replace("png8", "png");
            }
            return new FileCache(cacheDirectory, format);
        }

        private float GetMapResolution(IEnvelope env, int mapWidth)
        {
            double num = env.XMax - env.XMin;
            return Convert.ToSingle((double) (num / ((double) mapWidth)));
        }

        private IList<TileInfo> GetTiles(IActiveView activeView, IConfig config)
        {
            ITileSchema schema = tileSource.Schema;
            IEnvelope env = Projector.ProjectEnvelope(activeView.Extent, schema.Srs);
            int right = activeView.ExportFrame.right;
            int bottom = activeView.ExportFrame.bottom;
            float mapResolution = this.GetMapResolution(env, right);
            PointF centerPoint = this.GetCenterPoint(env);
            double newResolution = 0.0;
            int level = Utilities.GetNearestLevel(schema.Resolutions, (double) mapResolution, ref newResolution);
            if (level > 14)
            {
                level = 14;
            }
            Transform transform = new Transform(centerPoint, (float) (newResolution * 1.2), (float) right, (float) bottom);
            this._currentLevel = level;
            return Enumerable.ToList<TileInfo>(schema.GetTilesInView(transform.Extent, level));
        }

        private static string GetWorldFile(string format)
        {
            string str = string.Empty;
            format = format.Contains("image/") ? format.Substring(6, format.Length - 6) : format;
            if (format == "jpg")
            {
                str = "jgw";
            }
            if (format == "jpeg")
            {
                return "jgw";
            }
            if (format == "png")
            {
                return "pgw";
            }
            if (format == "png8")
            {
                return "pgw";
            }
            if (format == "tif")
            {
                str = "tfw";
            }
            return str;
        }

        private static void WriteWorldFile(string f, Extent extent, ITileSchema schema)
        {
            using (StreamWriter writer = new StreamWriter(f))
            {
                double num = (extent.MaxX - extent.MinX) / ((double) schema.Width);
                double num2 = (extent.MaxY - extent.MinY) / ((double) schema.Height);
                writer.WriteLine(num.ToString());
                writer.WriteLine("0");
                writer.WriteLine("0");
                writer.WriteLine((num2 *= -1.0).ToString());
                writer.WriteLine(extent.MinX.ToString());
                writer.WriteLine(extent.MaxY.ToString());
                writer.Close();
            }
        }
    }
}

