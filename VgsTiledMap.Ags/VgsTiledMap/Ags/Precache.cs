namespace VgsTiledMap.Ags
{
    using ESRI.ArcGIS.Carto;
    using ESRI.ArcGIS.Geometry;
    using log4net;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.Linq;
    using System.Windows.Forms;
    using VgsMap.Tile;
    using VgsMap.Tile.Cache;
    using VgsMap.Tile.Web;
    using VgsTiledMap.Ags.VgsTile.Forms;

    public class Precache
    {
        private BackgroundWorker bwPrecache;
        private string cacheDir = string.Empty;
        private EnumArcVgsTileLayer enumArctilerLayer;
        private IActiveView esriActiveView;
        private VgsPreCacheStatusForm formStatus;
        private ISpatialReference layerSpatialReference;
        private static readonly ILog logger = LogManager.GetLogger("VgsMapTileAgsSystemLogger");
        private IntPtr pntr;

        public Precache(IntPtr Pntr, IActiveView EsriActiveView, EnumArcVgsTileLayer EnumArctilerLayer, ISpatialReference LayerSpatialReference, string CacheDir)
        {
            this.esriActiveView = EsriActiveView;
            this.enumArctilerLayer = EnumArctilerLayer;
            this.layerSpatialReference = LayerSpatialReference;
            this.cacheDir = CacheDir;
            this.pntr = Pntr;
        }

        private void backgroundWorkerPrecache_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            Transporter argument = (Transporter) e.Argument;
            for (int i = 0; i < argument.Schema.Resolutions.Count; i++)
            {
                IList<TileInfo> list = null;
                string userState = string.Empty;
                try
                {
                    list = Enumerable.ToList<TileInfo>(argument.Schema.GetTilesInView(argument.Transform.Extent, i));
                }
                catch (Exception)
                {
                    list = null;
                }
                if (list != null)
                {
                    long num2 = 0L;
                    foreach (TileInfo info in list)
                    {
                        num2 += 1L;
                        try
                        {
                            byte[] image = RequestHelper.FetchImage(argument.WebTileProvider.Request.GetUri(info));
                            argument.FileCache.Add(info.Index, image);
                            userState = string.Format("缩放级别：{0}，正在下载Tile {1}， 共计 {2}", i + 1, num2, list.Count);
                        }
                        catch (Exception)
                        {
                        }
                        if (worker != null)
                        {
                            worker.WorkerReportsProgress = true;
                            worker.ReportProgress(0, userState);
                        }
                    }
                }
            }
        }

        private void backgroundWorkerPrecache_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            string message = e.UserState.ToString();
            if (this.formStatus == null)
            {
                this.formStatus = new VgsPreCacheStatusForm(this);
            }
            this.formStatus.SetStatusMessage(message);
        }

        private void backgroundWorkerPrecache_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show(e.Error.Message);
            }
            else if (!e.Cancelled)
            {
                MessageBox.Show(string.Format("The folder '{0}' has been created and contains the OSM levels. You can copy them to a memory card for further use.", this.cacheDir));
            }
            this.formStatus.Close();
        }

        public void CancelWork()
        {
            this.bwPrecache.CancelAsync();
        }

        private PointF GetCenterPoint(IEnvelope env)
        {
            PointF tf = new PointF();
            tf.X = Convert.ToSingle((double) (env.XMin + ((env.XMax - env.XMin) / 2.0)));
            tf.Y = Convert.ToSingle((double) (env.YMin + ((env.YMax - env.YMin) / 2.0)));
            return tf;
        }

        private float GetMapResolution(IEnvelope env, int mapWidth)
        {
            double num = env.XMax - env.XMin;
            return Convert.ToSingle((double) (num / ((double) mapWidth)));
        }

        private void InitializeBackgroundWorker()
        {
            this.bwPrecache = new BackgroundWorker();
            this.bwPrecache.DoWork += new DoWorkEventHandler(this.backgroundWorkerPrecache_DoWork);
            this.bwPrecache.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.backgroundWorkerPrecache_RunWorkerCompleted);
            this.bwPrecache.ProgressChanged += new ProgressChangedEventHandler(this.backgroundWorkerPrecache_ProgressChanged);
        }

        public void RunPrecacher()
        {
            IEnvelope extent = this.esriActiveView.Extent;
            ITileSource source = ConfigHelper.GetConfig(this.enumArctilerLayer).CreateTileSource();
            ITileSchema schema = source.Schema;
            FileCache cache = new FileCache(this.cacheDir, schema.Format);
            extent = Projector.ProjectEnvelope(extent, schema.Srs);
            new SpatialReferences().GetSpatialReference(schema.Srs);
            int right = this.esriActiveView.ExportFrame.right;
            int bottom = this.esriActiveView.ExportFrame.bottom;
            float mapResolution = this.GetMapResolution(extent, right);
            Transform transform = new Transform(this.GetCenterPoint(extent), mapResolution, (float) right, (float) bottom);
            WebTileProvider provider = (WebTileProvider) source.Provider;
            this.formStatus = new VgsPreCacheStatusForm(this);
            NativeWindow owner = new NativeWindow();
            owner.AssignHandle(this.pntr);
            this.formStatus.Show(owner);
            Transporter transporter2 = new Transporter();
            transporter2.Schema = schema;
            transporter2.Transform = transform;
            transporter2.WebTileProvider = provider;
            transporter2.FileCache = cache;
            transporter2.CacheDir = this.cacheDir;
            Transporter argument = transporter2;
            this.InitializeBackgroundWorker();
            this.bwPrecache.RunWorkerAsync(argument);
        }
    }
}

