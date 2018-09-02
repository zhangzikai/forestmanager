namespace VgsTiledMap.Ags
{
    using ESRI.ArcGIS.ADF.COMSupport;
    using ESRI.ArcGIS.ArcMapUI;
    using ESRI.ArcGIS.Carto;
    using ESRI.ArcGIS.Display;
    using ESRI.ArcGIS.esriSystem;
    using ESRI.ArcGIS.Framework;
    using ESRI.ArcGIS.Geodatabase;
    using ESRI.ArcGIS.Geometry;
    using log4net;
    using stdole;
    using System;
    using System.Drawing;
    using System.Runtime.InteropServices;
    using VgsMap.Tile;
    using VgsTiledMap.Ags.VgsTile.Configs;

    [ClassInterface(ClassInterfaceType.None), ProgId("VgsTiledMap.Ags.VgsArcTileLayer"), Guid("684A898E-14A7-4d3f-9B13-F2E3FA26C5FD")]
    public class VgsArcTileLayer : ILayer, ILayerPosition, IGeoDataset, IPersistVariant, ILayer2, IMapLevel, ILayerDrawingProperties, ILayerGeneralProperties, IDisplayAdmin2, ISymbolLevels, ILayerEffects, IDisplayFilterManager, IDisplayAdmin
    {
        private IApplication application;
        private short brightness;
        private bool cached;
        private string cacheDir;
        private IConfig config;
        private short contrast;
        private int currentLevel;
        private ISpatialReference dataSpatialReference;
        private ITransparencyDisplayFilter displayFilter;
        private bool drawingPropsDirty;
        private EnumArcVgsTileLayer enumVgsArcTiledLayer;
        private IEnvelope envelope;
        public const string GUID = "684A898E-14A7-4d3f-9B13-F2E3FA26C5FD";
        private double lastMaximumScale;
        private string layerDescription;
        private ISpatialReference layerSpatialReference;
        private double layerWeight;
        private static readonly log4net.ILog logger = LogManager.GetLogger("VgsMapTileAgsSystemLogger");
        private IMap map;
        private int mapLevel;
        private double maximumScale;
        private double minimumScale;
        private string name;
        private bool scaleRangeReadOnly;
        private ITileSchema schema;
        private bool showCopyRightInfo;
        private bool showTips;
        private int supportedDrawPhases;
        private bool supportsInteractive;
        private ITileSource tileSource;
        private int tileTimeOut;
        private short transparency;
        private bool useSymbolLevels;
        private bool visible;

        public VgsArcTileLayer()
        {
            this.name = "VgsTiledMap.Ags.VgsArcTileLayer";
            this.scaleRangeReadOnly = true;
            this.supportedDrawPhases = -1;
            this.layerWeight = 101.0;
            this.supportsInteractive = true;
            IApplication application = Activator.CreateInstance(Type.GetTypeFromProgID("esriFramework.AppRef")) as IApplication;
            this.application = application;
        }

        public VgsArcTileLayer(IMap arcMap, IConfig config)
        {
            this.name = "VgsTiledMap.Ags.VgsArcTileLayer";
            this.scaleRangeReadOnly = true;
            this.supportedDrawPhases = -1;
            this.layerWeight = 101.0;
            this.supportsInteractive = true;
            this.map = arcMap;
            this.config = config;
            if (config is ConfigLindi)
            {
                this.enumVgsArcTiledLayer = EnumArcVgsTileLayer.VgsTiled;
            }
            else
            {
                this.enumVgsArcTiledLayer = EnumArcVgsTileLayer.WMSC;
            }
            this.InitializeLayer();
        }

        public VgsArcTileLayer(IApplication application, EnumArcVgsTileLayer enumArcTilerLayer)
        {
            this.name = "VgsTiledMap.Ags.VgsArcTileLayer";
            this.scaleRangeReadOnly = true;
            this.supportedDrawPhases = -1;
            this.layerWeight = 101.0;
            this.supportsInteractive = true;
            this.config = ConfigHelper.GetConfig(enumArcTilerLayer);
            this.application = application;
            this.enumVgsArcTiledLayer = enumArcTilerLayer;
            this.InitializeLayer();
        }

        public VgsArcTileLayer(IApplication application, IConfig config)
        {
            this.name = "VgsTiledMap.Ags.VgsArcTileLayer";
            this.scaleRangeReadOnly = true;
            this.supportedDrawPhases = -1;
            this.layerWeight = 101.0;
            this.supportsInteractive = true;
            this.application = application;
            this.config = config;
            if (config is ConfigLindi)
            {
                this.enumVgsArcTiledLayer = EnumArcVgsTileLayer.VgsTiled;
            }
            else
            {
                this.enumVgsArcTiledLayer = EnumArcVgsTileLayer.WMSC;
            }
            this.InitializeLayer();
        }

        public VgsArcTileLayer(IApplication app, EnumArcVgsTileLayer EnumVgsArcTiledLayer, string TmsUrl, bool overwriteUrls)
        {
            this.name = "VgsTiledMap.Ags.VgsArcTileLayer";
            this.scaleRangeReadOnly = true;
            this.supportedDrawPhases = -1;
            this.layerWeight = 101.0;
            this.supportsInteractive = true;
            this.config = ConfigHelper.GetConfig(EnumVgsArcTiledLayer, TmsUrl, overwriteUrls);
            this.application = app;
            this.enumVgsArcTiledLayer = EnumVgsArcTiledLayer;
            this.InitializeLayer();
        }

        public void Draw(esriDrawPhase drawPhase, IDisplay display, ITrackCancel trackCancel)
        {
            if (((drawPhase == esriDrawPhase.esriDPGeography) && this.Valid) && this.Visible)
            {
                try
                {
                    if ((this.map == null) && (this.application != null))
                    {
                        IMxDocument document = (IMxDocument) this.application.Document;
                        this.map = document.FocusMap;
                    }
                    if (this.map != null)
                    {
                        IActiveView map = this.map as IActiveView;
                        this.envelope = map.Extent;
                        VgsTilerHelper helper = new VgsTilerHelper(this.cacheDir, this.tileTimeOut);
                        if (this.displayFilter == null)
                        {
                            this.InitializeLayer();
                        }
                        if (this.application != null)
                        {
                            helper.Draw(this.application, map, this.config, trackCancel, this.layerSpatialReference, this.enumVgsArcTiledLayer, ref this.currentLevel, this.tileSource, display);
                        }
                        else
                        {
                            helper.Draw(map, this.config, trackCancel, this.layerSpatialReference, this.enumVgsArcTiledLayer, ref this.currentLevel, this.tileSource, display);
                        }
                        this.DrawAttribute();
                    }
                }
                catch (Exception)
                {
                }
            }
        }

        private void DrawAttribute()
        {
            IActiveView map = this.map as IActiveView;
            PointClass class2 = new PointClass();
            class2.SpatialReference = this.layerSpatialReference;
            IPoint shape = class2;
            shape = map.Extent.LowerLeft;
            shape.X += (map.Extent.LowerRight.X - map.Extent.LowerLeft.X) / 15.0;
            shape.Y += (map.Extent.UpperLeft.Y - map.Extent.LowerLeft.Y) / 30.0;
            ITextSymbol symbol = new TextSymbolClass();
            System.Drawing.Font font = new System.Drawing.Font("Arial", 12f, FontStyle.Bold);
            symbol.Font = (IFontDisp) OLE.GetIFontDispFromFont(font);
            IColor color = new RgbColorClass();
            color.RGB = 0xff0000;
            symbol.Color = color;
            map.ScreenDisplay.SetSymbol((ISymbol) symbol);
            if (this.showCopyRightInfo)
            {
                map.ScreenDisplay.DrawText(shape, "林地一张图数据服务@2012");
            }
            map.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, map.Extent);
        }

        public string get_TipText(double x, double y, double Tolerance)
        {
            return "林地一张图数据管理";
        }

        private IEnvelope GetDefaultEnvelope()
        {
            VgsMap.Tile.Extent extent = this.schema.Extent;
            EnvelopeClass class2 = new EnvelopeClass();
            class2.XMin = extent.MinX;
            class2.XMax = extent.MaxX;
            class2.YMin = extent.MinY;
            class2.YMax = extent.MaxY;
            class2.SpatialReference = this.dataSpatialReference;
            return class2;
        }

        private void InitializeLayer()
        {
            if (this.application != null)
            {
                IMxDocument document = (IMxDocument) this.application.Document;
                this.map = document.FocusMap;
            }
            if (this.map != null)
            {
                this.cacheDir = CacheSettings.GetCacheFolder();
                this.tileTimeOut = CacheSettings.GetTileTimeOut();
                SpatialReferences references = new SpatialReferences();
                this.tileSource = this.config.CreateTileSource();
                this.schema = this.tileSource.Schema;
                this.dataSpatialReference = references.GetSpatialReference(this.schema.Srs);
                this.envelope = this.GetDefaultEnvelope();
                if (this.map.SpatialReference == null)
                {
                    this.map.SpatialReference = this.dataSpatialReference;
                }
                if (this.map.LayerCount == 0)
                {
                    this.envelope.Project(this.map.SpatialReference);
                    ((IActiveView) this.map).Extent = this.envelope;
                }
                this.displayFilter = new TransparencyDisplayFilterClass();
            }
        }

        public void Load(IVariantStream Stream)
        {
            try
            {
                string str;
                string str3;
                this.name = (string) Stream.Read();
                this.visible = (bool) Stream.Read();
                this.enumVgsArcTiledLayer = (EnumArcVgsTileLayer) Stream.Read();
                EnumArcVgsTileLayer enumVgsArcTiledLayer = this.enumVgsArcTiledLayer;
                if (enumVgsArcTiledLayer != EnumArcVgsTileLayer.TMS)
                {
                    if (enumVgsArcTiledLayer == EnumArcVgsTileLayer.InvertedTMS)
                    {
                        goto Label_006F;
                    }
                    if (((enumVgsArcTiledLayer != EnumArcVgsTileLayer.VgsTiled) && (enumVgsArcTiledLayer != EnumArcVgsTileLayer.VgsSatellite)) && (enumVgsArcTiledLayer != EnumArcVgsTileLayer.EviaTiledSatellite))
                    {
                        goto Label_008C;
                    }
                    goto Label_009D;
                }
                string url = (string) Stream.Read();
                this.config = ConfigHelper.GetTmsConfig(url, true);
                goto Label_00E2;
            Label_006F:
                str = (string) Stream.Read();
                this.config = ConfigHelper.GetConfig(EnumArcVgsTileLayer.InvertedTMS, str, true);
                goto Label_00E2;
            Label_008C:
                this.config = ConfigHelper.GetConfig(this.enumVgsArcTiledLayer);
            Label_009D:
                str3 = (string) Stream.Read();
                string lyrname = (string) Stream.Read();
                string lyrType = (string) Stream.Read();
                string lyrYear = (string) Stream.Read();
                this.config = new ConfigLindi(str3, lyrname, lyrYear, lyrType);
            Label_00E2:
                this.InitializeLayer();
                this.map = null;
                Util.SetVgsTiledMapPropertyPage(this.application, this);
            }
            catch (Exception)
            {
            }
        }

        public void Save(IVariantStream Stream)
        {
            Stream.Write(this.name);
            Stream.Write(this.visible);
            Stream.Write(this.enumVgsArcTiledLayer);
            EnumArcVgsTileLayer enumVgsArcTiledLayer = this.enumVgsArcTiledLayer;
            switch (enumVgsArcTiledLayer)
            {
                case EnumArcVgsTileLayer.VgsTiled:
                case EnumArcVgsTileLayer.VgsSatellite:
                case EnumArcVgsTileLayer.EviaTiledSatellite:
                {
                    ConfigLindi lindi = this.config as ConfigLindi;
                    if (lindi != null)
                    {
                        Stream.Write(lindi.BaseUrl);
                        Stream.Write(lindi.LyrName);
                        string tType = lindi.TType;
                        if (string.IsNullOrEmpty(tType))
                        {
                            tType = "png";
                        }
                        Stream.Write(tType);
                        tType = lindi.LyrYear;
                        Stream.Write(tType);
                    }
                    return;
                }
            }
            if (enumVgsArcTiledLayer != EnumArcVgsTileLayer.TMS)
            {
                if (enumVgsArcTiledLayer != EnumArcVgsTileLayer.InvertedTMS)
                {
                    return;
                }
            }
            else
            {
                ConfigTms tms = this.config as ConfigTms;
                Stream.Write(tms.Url);
                return;
            }
            ConfigInvertedTMS config = this.config as ConfigInvertedTMS;
            Stream.Write(config.Url);
        }

        public IEnvelope AreaOfInterest
        {
            get
            {
                return this.envelope;
            }
            set
            {
                this.envelope = value;
            }
        }

        public short Brightness
        {
            get
            {
                return this.brightness;
            }
            set
            {
                this.brightness = value;
            }
        }

        public bool Cached
        {
            get
            {
                return this.cached;
            }
            set
            {
                this.cached = value;
            }
        }

        public short Contrast
        {
            get
            {
                return this.contrast;
            }
            set
            {
                this.contrast = value;
            }
        }

        public int CurrentLevel
        {
            get
            {
                return this.currentLevel;
            }
            set
            {
                this.currentLevel = value;
            }
        }

        public IDisplayFilter DisplayFilter
        {
            get
            {
                return this.displayFilter;
            }
            set
            {
                this.displayFilter = (ITransparencyDisplayFilter) value;
            }
        }

        public bool DoesBlending
        {
            get
            {
                return true;
            }
        }

        public bool DrawingPropsDirty
        {
            get
            {
                return this.drawingPropsDirty;
            }
            set
            {
                this.drawingPropsDirty = value;
            }
        }

        public EnumArcVgsTileLayer EnumArcTilerLayer
        {
            get
            {
                return this.enumVgsArcTiledLayer;
            }
            set
            {
                this.enumVgsArcTiledLayer = value;
            }
        }

        public IEnvelope Extent
        {
            get
            {
                return this.GetDefaultEnvelope();
            }
        }

        public UID ID
        {
            get
            {
                UIDClass class2 = new UIDClass();
                class2.Value = "{684A898E-14A7-4d3f-9B13-F2E3FA26C5FD}";
                return class2;
            }
        }

        public double LastMaximumScale
        {
            get
            {
                return this.lastMaximumScale;
            }
        }

        public double LastMinimumScale
        {
            get
            {
                return this.LastMaximumScale;
            }
        }

        public string LayerDescription
        {
            get
            {
                return this.layerDescription;
            }
            set
            {
                this.layerDescription = value;
            }
        }

        public double LayerWeight
        {
            get
            {
                return this.layerWeight;
            }
            set
            {
                this.layerWeight = value;
            }
        }

        public int MapLevel
        {
            get
            {
                return this.mapLevel;
            }
            set
            {
                this.mapLevel = value;
            }
        }

        public double MaximumScale
        {
            get
            {
                return this.maximumScale;
            }
            set
            {
                this.maximumScale = value;
            }
        }

        public double MinimumScale
        {
            get
            {
                return this.minimumScale;
            }
            set
            {
                this.minimumScale = value;
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }

        public bool RequiresBanding
        {
            get
            {
                return true;
            }
        }

        public bool ScaleRangeReadOnly
        {
            get
            {
                return this.scaleRangeReadOnly;
            }
        }

        public bool ShowTips
        {
            get
            {
                return this.showTips;
            }
            set
            {
                this.showTips = value;
            }
        }

        public ISpatialReference SpatialReference
        {
            get
            {
                return this.layerSpatialReference;
            }
            set
            {
                this.layerSpatialReference = value;
            }
        }

        public int SupportedDrawPhases
        {
            get
            {
                return this.supportedDrawPhases;
            }
        }

        public bool SupportsBrightnessChange
        {
            get
            {
                return true;
            }
        }

        public bool SupportsContrastChange
        {
            get
            {
                return true;
            }
        }

        public bool SupportsInteractive
        {
            get
            {
                return this.supportsInteractive;
            }
            set
            {
                this.supportsInteractive = value;
            }
        }

        public bool SupportsTransparency
        {
            get
            {
                return true;
            }
        }

        public short Transparency
        {
            get
            {
                return this.transparency;
            }
            set
            {
                this.transparency = value;
            }
        }

        public bool UsesFilter
        {
            get
            {
                return true;
            }
        }

        public bool UseSymbolLevels
        {
            get
            {
                return this.useSymbolLevels;
            }
            set
            {
                this.useSymbolLevels = value;
            }
        }

        public bool Valid
        {
            get
            {
                return true;
            }
        }

        public bool Visible
        {
            get
            {
                return this.visible;
            }
            set
            {
                this.visible = value;
                if (!this.visible)
                {
                    ((IGraphicsContainer) this.map).DeleteAllElements();
                }
            }
        }
    }
}

