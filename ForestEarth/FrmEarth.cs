namespace ForestEarth
{
    using AxEviaEarthLib;
    using DevExpress.LookAndFeel;
    using DevExpress.XtraEditors;
    using DevExpress.XtraNavBar;
    using EarthBusiness;
    using EarthBusiness.BusiHelp;
    using EvEarthDriverLib;
    using EviaEarthLib;
    using EviaEarthVectorLib;
    using ForestEarth.EarthHelp;
    using OSGeo.OGR;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Runtime.CompilerServices;
    using System.Text;
    using System.Windows.Forms;

    /// <summary>
    /// 森林资源三维电子沙盘
    /// </summary>
    public class FrmEarth : Form
    {
        private AxEviaEarthControl axEviaEarthControl1;
        private System.ComponentModel.IContainer components;
        private DefaultLookAndFeel defaultLookAndFeel1;
        private ClsDbHandler m_clsDbHandler;
        private string m_connString = string.Empty;
        private IEviaEarthControl m_earthControl;
        private FrmFly m_ff;
        private bool m_identifying;
        private FrmInformation m_inforForm;
        private bool m_isFirestThemControlAdd = true;
        private bool m_isFirstAdminLocate = true;
        private bool m_isFirstForeLandAdd = true;
        private bool m_isFirstForestAdd = true;
        private bool m_isFlying;
        private bool m_ucThematicControlSet;
        private string m_updateYear = string.Empty;
        private FrmIdentifyInfo m_xbInfoForm;
        private NavBarControl navBarControl1;
        private NavBarGroup navBarGroup1;
        private NavBarGroup navBarGroup2;
        private NavBarGroup navBarGroup3;
        private NavBarGroup navBarGroup4;
        private NavBarGroup navBarGroup5;
        private NavBarGroup navBarGroup6;
        private NavBarGroup navBarGroup7;
        private NavBarGroup navBarGroup8;
        private NavBarGroupControlContainer navBarGroupControlContainer1;
        private NavBarGroupControlContainer navBarGroupControlContainer2;
        private NavBarGroupControlContainer navBarGroupControlContainer3;
        private NavBarGroupControlContainer navBarGroupControlContainer4;
        private NavBarGroupControlContainer navBarGroupControlContainer5;
        private NavBarGroupControlContainer navBarGroupControlContainer6;
        private NavBarGroupControlContainer navBarGroupControlContainer7;
        private NavBarItem nbi_around;
        private NavBarItem nbi_fullExtent;
        private NavBarItem nbi_identify;
        private NavBarItem nbi_pan;
        private NavBarItem nbi_sysConfig;
        private NavBarItem nbi_xbLocate;
        private NavBarItem nbi_xyLocate;
        private Panel panel_fly;
        private Panel panel_hotPot;
        private Panel panel_legend;
        private SplitterControl splitterControl1;
        private UCAdminLocate ucAdminLocate1;
        private UCForeLandQuery ucForeLandQuery1;
        private UCForestQuery ucForestQuery1;
        private UCThematicControl ucThematicControl1;

        public FrmEarth(string connStr, string year)
        {
            this.InitializeComponent();
            this.m_connString = connStr;
            this.m_updateYear = year;
        }

        private void AddFormToPanel(Form f, Panel p)
        {
            f.FormBorderStyle = FormBorderStyle.None;
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            p.Controls.Add(f);
            f.Show();
        }

        private void AddPoint(double lon, double lat, string id, IFeature pFeature)
        {
            IPlaceMark mark = new PlaceMarkClass();
            IPoint point = new pointClass();
            IEGCoord coord = new EGCoordClass();
            coord.Longitude = lon;
            coord.Latitude = lat;
            coord.Altitude = 0.0;
            point.coord = coord as EGCoord;
            mark.Geometry = point;
            mark.ID = id;
            IStyle style = new styleClass();
            style.MouseReact = true;
            style.AutoHighlight = true;
            IIconStyle iconStyle = style.IconStyle;
            IEvPicture picture = new EvPictureClass();
            ILink link = new EvLinkClass();
            string str = AppDomain.CurrentDomain.BaseDirectory + "label.png";
            link.Href = str;
            picture.Link = link as EvLink;
            iconStyle.Texture = picture;
            IStyleSelector selector = style;
            mark.StyleSelector = selector;
            EviaEarthVectorLib.IContainer container = pFeature as EviaEarthVectorLib.IContainer;
            container.Features.AppendChild(mark);
        }

        private void axEviaEarthControl1_OnCameraChanged(object sender, EventArgs e)
        {
            IEvEarthScene evEarthScene = this.axEviaEarthControl1.Scene.EvEarthScene as IEvEarthScene;
            IEvEarthCamera camera = evEarthScene.Camera as IEvEarthCamera;
            if (camera != null)
            {
                IEVObjectManager kmlManager = evEarthScene.KmlManager as IEVObjectManager;
                if (kmlManager != null)
                {
                    IScreenOverlay overlay = kmlManager.FindFeatureByID("compass_north2012", null) as IScreenOverlay;
                    if (overlay != null)
                    {
                        double heading = camera.Heading;
                        overlay.Rotation = -heading;
                    }
                }
            }
        }

        private void axEviaEarthControl1_OnMouseDown(object sender, _IEviaEarthControlEvents_OnMouseDownEvent e)
        {
            if (this.m_isFlying)
            {
                if (this.m_ff != null)
                {
                    this.m_ff.OnMouseDown(e.button, e.shift, e.x, e.y);
                }
            }
            else if (this.m_identifying && (e.button == 1))
            {
                double num;
                double num2;
                double num3;
                this.m_earthControl.Scene.WinToBL(e.x, e.y, out num, out num2, out num3);
                this.DoIdentify(num, num2);
            }
        }

        private void axEviaEarthControl1_OnObjectMouseDown(object sender, _IEviaEarthControlEvents_OnObjectMouseDownEvent e)
        {
            IFeature nodeObject = e.pObj.NodeObject as IFeature;
            if (nodeObject != null)
            {
                string iD = nodeObject.ID;
                int oid = Convert.ToInt32(iD.Substring(0, iD.LastIndexOf("+")));
                string tableName = iD.Substring(iD.LastIndexOf("+") + 1);
                XbIdentifyInfo zTXbInfoByOid = this.m_clsDbHandler.GetZTXbInfoByOid(oid, tableName);
                if (zTXbInfoByOid != null)
                {
                    this.ShowXbInforForm(zTXbInfoByOid);
                    try
                    {
                        string geoString = zTXbInfoByOid.GeoString;
                        if (!string.IsNullOrEmpty(geoString))
                        {
                            Geometry geometry2 = Ogr.CreateGeometryFromWkt(ref geoString, null).Simplify(0.0001);
                            if (geometry2 != null)
                            {
                                geometry2.ExportToWkt(out geoString);
                            }
                            else
                            {
                                geoString = zTXbInfoByOid.GeoString;
                            }
                            this.m_earthControl.Display.ShowGeoData(geoString, (uint) System.Drawing.Color.Yellow.ToArgb(), 6f, false);
                        }
                    }
                    catch
                    {
                    }
                }
            }
        }

        private void axEviaEarthControl1_OnSceneReady(object sender, _IEviaEarthControlEvents_OnSceneReadyEvent e)
        {
            Timer timer = new Timer();
            timer.Interval = 20;
            timer.Tick += new EventHandler(this.t_Tick);
            timer.Start();
        }

        public void ClearTargetIcon()
        {
            IEVObjectManager manager = this.QueryKMLManager(this.m_earthControl.Scene.EvEarthScene as IEvEarthScene);
            if ((manager != null) && (manager.Features != null))
            {
                long count = manager.Features.Count;
                for (int i = 0; i < count; i++)
                {
                    IFeature child = manager.Features.GetChild(i) as IFeature;
                    if ((child != null) && (child.Name.CompareTo("QueryLabel2013") == 0))
                    {
                        manager.Features.RemoveChild(child);
                        return;
                    }
                }
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void DoIdentify(double lon, double lat)
        {
            XbIdentifyInfo identify = this.m_clsDbHandler.GetXbInfoByLonLatOrXbid(lon, lat, string.Empty);
            if (identify != null)
            {
                this.ShowXbInforForm(identify);
                try
                {
                    string geoString = identify.GeoString;
                    if (!string.IsNullOrEmpty(geoString))
                    {
                        Geometry geometry2 = Ogr.CreateGeometryFromWkt(ref geoString, null).Simplify(0.0001);
                        if (geometry2 != null)
                        {
                            geometry2.ExportToWkt(out geoString);
                        }
                        else
                        {
                            geoString = identify.GeoString;
                        }
                        this.m_earthControl.Display.ShowGeoData(geoString, (uint) System.Drawing.Color.Yellow.ToArgb(), 6f, false);
                    }
                }
                catch
                {
                }
            }
        }

        private void FlashMap(string mapName, string issz)
        {
            this.ucThematicControl1.FlashMap(mapName, issz);
        }

        private void FlyToDestinationByGeoString(string geostring, bool isXb)
        {
            string val = geostring;
            Geometry geometry = Ogr.CreateGeometryFromWkt(ref val, null);
            Envelope env = new Envelope();
            geometry.GetEnvelope(env);
            this.m_earthControl.ViewPoint.FlyToBox(env.MaxX, env.MinX, env.MinY, env.MaxY, 4.0);
            Geometry geometry2 = null;
            if (isXb)
            {
                geometry2 = geometry.Simplify(0.0001);
            }
            else
            {
                geometry2 = geometry.Simplify(0.0005);
            }
            if (geometry2 != null)
            {
                geometry2.ExportToWkt(out val);
            }
            this.m_earthControl.Display.ShowGeoData(val, (uint) System.Drawing.Color.Yellow.ToArgb(), 6f, false);
        }

        private void FrmEarth_Load(object sender, EventArgs e)
        {
            try
            {
                this.defaultLookAndFeel1.LookAndFeel.SkinName = "Blue";
                this.m_earthControl = this.axEviaEarthControl1.Control;
                IEvEarthScene evEarthScene = this.m_earthControl.Scene.EvEarthScene as IEvEarthScene;
                evEarthScene.ShowLogo = false;
                evEarthScene.RegisterCode("Evia Earth2.1-2012");
                if (!string.IsNullOrEmpty(ClsConfigManage.PathEarthService))
                {
                    this.m_earthControl.Scene.Navigate(ClsConfigManage.PathEarthService);
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("三维窗体初始化失败，可能的原因：" + exception.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void FrmEarth_Shown(object sender, EventArgs e)
        {
            this.m_clsDbHandler = new ClsDbHandler();
            this.m_clsDbHandler.UpdateYear = this.m_updateYear;
            this.m_clsDbHandler.SqlConnectionString = this.m_connString;
            FrmHotPot f = new FrmHotPot(this.m_earthControl);
            this.AddFormToPanel(f, this.panel_hotPot);
            this.m_ff = new FrmFly(this.m_earthControl);
            this.AddFormToPanel(this.m_ff, this.panel_fly);
            FrmLegend legend = new FrmLegend();
            this.AddFormToPanel(legend, this.panel_legend);
        }

        private void fxl_OnComboSelected(object sender, XbIdentifyInfo result, bool isXb)
        {
            this.FlyToDestinationByGeoString(result.GeoString, isXb);
            this.ShowXbInforForm(result);
        }

        private void GenerateBallon(double x, double y, string msg)
        {
            try
            {
                this.m_earthControl.Display.TooltipModel = 1;
                string xmlText = "<html xmlns=\"http://www.w3.org/1999/xhtml\" ><head><title>Evia Earth</title></head>";
                xmlText = xmlText + msg + "</html>";
                this.m_earthControl.Display.ShowInformation(x, y, 0.0, xmlText);
            }
            catch (Exception exception)
            {
                MessageBox.Show("方法GenerateBallon生成气泡出错，可能的原因：" + exception.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmEarth));
            this.navBarControl1 = new DevExpress.XtraNavBar.NavBarControl();
            this.navBarGroup1 = new DevExpress.XtraNavBar.NavBarGroup();
            this.nbi_sysConfig = new DevExpress.XtraNavBar.NavBarItem();
            this.nbi_fullExtent = new DevExpress.XtraNavBar.NavBarItem();
            this.nbi_pan = new DevExpress.XtraNavBar.NavBarItem();
            this.nbi_around = new DevExpress.XtraNavBar.NavBarItem();
            this.nbi_xyLocate = new DevExpress.XtraNavBar.NavBarItem();
            this.nbi_xbLocate = new DevExpress.XtraNavBar.NavBarItem();
            this.nbi_identify = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarGroupControlContainer1 = new DevExpress.XtraNavBar.NavBarGroupControlContainer();
            this.ucAdminLocate1 = new EarthBusiness.BusiHelp.UCAdminLocate();
            this.navBarGroupControlContainer2 = new DevExpress.XtraNavBar.NavBarGroupControlContainer();
            this.ucThematicControl1 = new ForestEarth.EarthHelp.UCThematicControl();
            this.navBarGroupControlContainer3 = new DevExpress.XtraNavBar.NavBarGroupControlContainer();
            this.panel_hotPot = new System.Windows.Forms.Panel();
            this.navBarGroupControlContainer4 = new DevExpress.XtraNavBar.NavBarGroupControlContainer();
            this.panel_fly = new System.Windows.Forms.Panel();
            this.navBarGroupControlContainer5 = new DevExpress.XtraNavBar.NavBarGroupControlContainer();
            this.panel_legend = new System.Windows.Forms.Panel();
            this.navBarGroupControlContainer6 = new DevExpress.XtraNavBar.NavBarGroupControlContainer();
            this.ucForeLandQuery1 = new EarthBusiness.BusiHelp.UCForeLandQuery();
            this.navBarGroupControlContainer7 = new DevExpress.XtraNavBar.NavBarGroupControlContainer();
            this.ucForestQuery1 = new EarthBusiness.BusiHelp.UCForestQuery();
            this.navBarGroup2 = new DevExpress.XtraNavBar.NavBarGroup();
            this.navBarGroup7 = new DevExpress.XtraNavBar.NavBarGroup();
            this.navBarGroup8 = new DevExpress.XtraNavBar.NavBarGroup();
            this.navBarGroup3 = new DevExpress.XtraNavBar.NavBarGroup();
            this.navBarGroup4 = new DevExpress.XtraNavBar.NavBarGroup();
            this.navBarGroup5 = new DevExpress.XtraNavBar.NavBarGroup();
            this.navBarGroup6 = new DevExpress.XtraNavBar.NavBarGroup();
            this.splitterControl1 = new DevExpress.XtraEditors.SplitterControl();
            this.defaultLookAndFeel1 = new DevExpress.LookAndFeel.DefaultLookAndFeel();
            this.axEviaEarthControl1 = new AxEviaEarthLib.AxEviaEarthControl();
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl1)).BeginInit();
            this.navBarControl1.SuspendLayout();
            this.navBarGroupControlContainer1.SuspendLayout();
            this.navBarGroupControlContainer2.SuspendLayout();
            this.navBarGroupControlContainer3.SuspendLayout();
            this.navBarGroupControlContainer4.SuspendLayout();
            this.navBarGroupControlContainer5.SuspendLayout();
            this.navBarGroupControlContainer6.SuspendLayout();
            this.navBarGroupControlContainer7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axEviaEarthControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // navBarControl1
            // 
            this.navBarControl1.ActiveGroup = this.navBarGroup1;
            this.navBarControl1.Controls.Add(this.navBarGroupControlContainer1);
            this.navBarControl1.Controls.Add(this.navBarGroupControlContainer2);
            this.navBarControl1.Controls.Add(this.navBarGroupControlContainer3);
            this.navBarControl1.Controls.Add(this.navBarGroupControlContainer4);
            this.navBarControl1.Controls.Add(this.navBarGroupControlContainer5);
            this.navBarControl1.Controls.Add(this.navBarGroupControlContainer6);
            this.navBarControl1.Controls.Add(this.navBarGroupControlContainer7);
            this.navBarControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.navBarControl1.Groups.AddRange(new DevExpress.XtraNavBar.NavBarGroup[] {
            this.navBarGroup1,
            this.navBarGroup2,
            this.navBarGroup7,
            this.navBarGroup8,
            this.navBarGroup3,
            this.navBarGroup4,
            this.navBarGroup5,
            this.navBarGroup6});
            this.navBarControl1.Items.AddRange(new DevExpress.XtraNavBar.NavBarItem[] {
            this.nbi_sysConfig,
            this.nbi_fullExtent,
            this.nbi_pan,
            this.nbi_around,
            this.nbi_xyLocate,
            this.nbi_xbLocate,
            this.nbi_identify});
            this.navBarControl1.Location = new System.Drawing.Point(0, 0);
            this.navBarControl1.Name = "navBarControl1";
            this.navBarControl1.OptionsNavPane.ExpandedWidth = 242;
            this.navBarControl1.PaintStyleKind = DevExpress.XtraNavBar.NavBarViewKind.NavigationPane;
            this.navBarControl1.Size = new System.Drawing.Size(242, 461);
            this.navBarControl1.TabIndex = 0;
            this.navBarControl1.Text = "navBarControl1";
            this.navBarControl1.ActiveGroupChanged += new DevExpress.XtraNavBar.NavBarGroupEventHandler(this.navBarControl1_ActiveGroupChanged);
            // 
            // navBarGroup1
            // 
            this.navBarGroup1.Caption = "通用查询";
            this.navBarGroup1.Expanded = true;
            this.navBarGroup1.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.SmallIconsList;
            this.navBarGroup1.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.nbi_sysConfig),
            new DevExpress.XtraNavBar.NavBarItemLink(this.nbi_fullExtent),
            new DevExpress.XtraNavBar.NavBarItemLink(this.nbi_pan),
            new DevExpress.XtraNavBar.NavBarItemLink(this.nbi_around),
            new DevExpress.XtraNavBar.NavBarItemLink(this.nbi_xyLocate),
            new DevExpress.XtraNavBar.NavBarItemLink(this.nbi_xbLocate),
            new DevExpress.XtraNavBar.NavBarItemLink(this.nbi_identify)});
            this.navBarGroup1.Name = "navBarGroup1";
            this.navBarGroup1.TopVisibleLinkIndex = 2;
            // 
            // nbi_sysConfig
            // 
            this.nbi_sysConfig.Caption = "      三维服务配置";
            this.nbi_sysConfig.Name = "nbi_sysConfig";
            this.nbi_sysConfig.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nbi_sysConfig_LinkClicked);
            // 
            // nbi_fullExtent
            // 
            this.nbi_fullExtent.Caption = "      地图初始范围";
            this.nbi_fullExtent.Name = "nbi_fullExtent";
            this.nbi_fullExtent.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nbi_fullExtent_LinkClicked);
            // 
            // nbi_pan
            // 
            this.nbi_pan.Caption = "      三维漫游（默认工具）";
            this.nbi_pan.Name = "nbi_pan";
            this.nbi_pan.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nbi_pan_LinkClicked);
            // 
            // nbi_around
            // 
            this.nbi_around.Caption = "      三维环绕浏览";
            this.nbi_around.Name = "nbi_around";
            this.nbi_around.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nbi_around_LinkClicked);
            // 
            // nbi_xyLocate
            // 
            this.nbi_xyLocate.Caption = "      坐标定位";
            this.nbi_xyLocate.Name = "nbi_xyLocate";
            this.nbi_xyLocate.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nbi_xyLocate_LinkClicked);
            // 
            // nbi_xbLocate
            // 
            this.nbi_xbLocate.Caption = "      小班定位";
            this.nbi_xbLocate.Name = "nbi_xbLocate";
            this.nbi_xbLocate.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nbi_xbLocate_LinkClicked);
            // 
            // nbi_identify
            // 
            this.nbi_identify.Caption = "      小班信息查询";
            this.nbi_identify.Name = "nbi_identify";
            this.nbi_identify.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nbi_identify_LinkClicked);
            // 
            // navBarGroupControlContainer1
            // 
            this.navBarGroupControlContainer1.Controls.Add(this.ucAdminLocate1);
            this.navBarGroupControlContainer1.Name = "navBarGroupControlContainer1";
            this.navBarGroupControlContainer1.Size = new System.Drawing.Size(242, 146);
            this.navBarGroupControlContainer1.TabIndex = 0;
            // 
            // ucAdminLocate1
            // 
            this.ucAdminLocate1.ClassDbHandler = null;
            this.ucAdminLocate1.ConnectionString = "";
            this.ucAdminLocate1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucAdminLocate1.Location = new System.Drawing.Point(0, 0);
            this.ucAdminLocate1.Name = "ucAdminLocate1";
            this.ucAdminLocate1.Size = new System.Drawing.Size(242, 146);
            this.ucAdminLocate1.TabIndex = 0;
            this.ucAdminLocate1.UpdateYear = "";
            // 
            // navBarGroupControlContainer2
            // 
            this.navBarGroupControlContainer2.Controls.Add(this.ucThematicControl1);
            this.navBarGroupControlContainer2.Name = "navBarGroupControlContainer2";
            this.navBarGroupControlContainer2.Size = new System.Drawing.Size(242, 146);
            this.navBarGroupControlContainer2.TabIndex = 1;
            // 
            // ucThematicControl1
            // 
            this.ucThematicControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucThematicControl1.EarthControl = null;
            this.ucThematicControl1.Location = new System.Drawing.Point(0, 0);
            this.ucThematicControl1.Name = "ucThematicControl1";
            this.ucThematicControl1.Size = new System.Drawing.Size(242, 146);
            this.ucThematicControl1.TabIndex = 0;
            // 
            // navBarGroupControlContainer3
            // 
            this.navBarGroupControlContainer3.Controls.Add(this.panel_hotPot);
            this.navBarGroupControlContainer3.Name = "navBarGroupControlContainer3";
            this.navBarGroupControlContainer3.Size = new System.Drawing.Size(242, 146);
            this.navBarGroupControlContainer3.TabIndex = 2;
            // 
            // panel_hotPot
            // 
            this.panel_hotPot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_hotPot.Location = new System.Drawing.Point(0, 0);
            this.panel_hotPot.Name = "panel_hotPot";
            this.panel_hotPot.Size = new System.Drawing.Size(242, 146);
            this.panel_hotPot.TabIndex = 0;
            // 
            // navBarGroupControlContainer4
            // 
            this.navBarGroupControlContainer4.Controls.Add(this.panel_fly);
            this.navBarGroupControlContainer4.Name = "navBarGroupControlContainer4";
            this.navBarGroupControlContainer4.Size = new System.Drawing.Size(242, 146);
            this.navBarGroupControlContainer4.TabIndex = 3;
            // 
            // panel_fly
            // 
            this.panel_fly.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_fly.Location = new System.Drawing.Point(0, 0);
            this.panel_fly.Name = "panel_fly";
            this.panel_fly.Size = new System.Drawing.Size(242, 146);
            this.panel_fly.TabIndex = 0;
            // 
            // navBarGroupControlContainer5
            // 
            this.navBarGroupControlContainer5.Controls.Add(this.panel_legend);
            this.navBarGroupControlContainer5.Name = "navBarGroupControlContainer5";
            this.navBarGroupControlContainer5.Size = new System.Drawing.Size(242, 146);
            this.navBarGroupControlContainer5.TabIndex = 4;
            // 
            // panel_legend
            // 
            this.panel_legend.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_legend.Location = new System.Drawing.Point(0, 0);
            this.panel_legend.Name = "panel_legend";
            this.panel_legend.Size = new System.Drawing.Size(242, 146);
            this.panel_legend.TabIndex = 0;
            // 
            // navBarGroupControlContainer6
            // 
            this.navBarGroupControlContainer6.Controls.Add(this.ucForeLandQuery1);
            this.navBarGroupControlContainer6.Name = "navBarGroupControlContainer6";
            this.navBarGroupControlContainer6.Size = new System.Drawing.Size(242, 146);
            this.navBarGroupControlContainer6.TabIndex = 5;
            // 
            // ucForeLandQuery1
            // 
            this.ucForeLandQuery1.ClassDbHandler = null;
            this.ucForeLandQuery1.ConnectionString = "";
            this.ucForeLandQuery1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucForeLandQuery1.Location = new System.Drawing.Point(0, 0);
            this.ucForeLandQuery1.Name = "ucForeLandQuery1";
            this.ucForeLandQuery1.Size = new System.Drawing.Size(242, 146);
            this.ucForeLandQuery1.TabIndex = 3;
            this.ucForeLandQuery1.UpdateYear = "";
            // 
            // navBarGroupControlContainer7
            // 
            this.navBarGroupControlContainer7.Controls.Add(this.ucForestQuery1);
            this.navBarGroupControlContainer7.Name = "navBarGroupControlContainer7";
            this.navBarGroupControlContainer7.Size = new System.Drawing.Size(242, 146);
            this.navBarGroupControlContainer7.TabIndex = 6;
            // 
            // ucForestQuery1
            // 
            this.ucForestQuery1.ClassDbHandler = null;
            this.ucForestQuery1.ConnectionString = "";
            this.ucForestQuery1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucForestQuery1.Location = new System.Drawing.Point(0, 0);
            this.ucForestQuery1.Name = "ucForestQuery1";
            this.ucForestQuery1.Size = new System.Drawing.Size(242, 146);
            this.ucForestQuery1.TabIndex = 0;
            this.ucForestQuery1.UpdateYear = "";
            // 
            // navBarGroup2
            // 
            this.navBarGroup2.Caption = "行政定位";
            this.navBarGroup2.ControlContainer = this.navBarGroupControlContainer1;
            this.navBarGroup2.GroupClientHeight = 80;
            this.navBarGroup2.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.ControlContainer;
            this.navBarGroup2.Name = "navBarGroup2";
            // 
            // navBarGroup7
            // 
            this.navBarGroup7.Caption = "林地查询";
            this.navBarGroup7.ControlContainer = this.navBarGroupControlContainer6;
            this.navBarGroup7.GroupClientHeight = 80;
            this.navBarGroup7.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.ControlContainer;
            this.navBarGroup7.Name = "navBarGroup7";
            // 
            // navBarGroup8
            // 
            this.navBarGroup8.Caption = "资源查询";
            this.navBarGroup8.ControlContainer = this.navBarGroupControlContainer7;
            this.navBarGroup8.GroupClientHeight = 80;
            this.navBarGroup8.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.ControlContainer;
            this.navBarGroup8.Name = "navBarGroup8";
            // 
            // navBarGroup3
            // 
            this.navBarGroup3.Caption = "专题浏览";
            this.navBarGroup3.ControlContainer = this.navBarGroupControlContainer2;
            this.navBarGroup3.GroupClientHeight = 80;
            this.navBarGroup3.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.ControlContainer;
            this.navBarGroup3.Name = "navBarGroup3";
            // 
            // navBarGroup4
            // 
            this.navBarGroup4.Caption = "热点管理";
            this.navBarGroup4.ControlContainer = this.navBarGroupControlContainer3;
            this.navBarGroup4.GroupClientHeight = 80;
            this.navBarGroup4.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.ControlContainer;
            this.navBarGroup4.Name = "navBarGroup4";
            // 
            // navBarGroup5
            // 
            this.navBarGroup5.Caption = "动画模拟";
            this.navBarGroup5.ControlContainer = this.navBarGroupControlContainer4;
            this.navBarGroup5.GroupClientHeight = 80;
            this.navBarGroup5.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.ControlContainer;
            this.navBarGroup5.Name = "navBarGroup5";
            // 
            // navBarGroup6
            // 
            this.navBarGroup6.Caption = "地图图例";
            this.navBarGroup6.ControlContainer = this.navBarGroupControlContainer5;
            this.navBarGroup6.GroupClientHeight = 80;
            this.navBarGroup6.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.ControlContainer;
            this.navBarGroup6.Name = "navBarGroup6";
            // 
            // splitterControl1
            // 
            this.splitterControl1.Location = new System.Drawing.Point(242, 0);
            this.splitterControl1.Name = "splitterControl1";
            this.splitterControl1.Size = new System.Drawing.Size(5, 461);
            this.splitterControl1.TabIndex = 1;
            this.splitterControl1.TabStop = false;
            // 
            // axEviaEarthControl1
            // 
            this.axEviaEarthControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axEviaEarthControl1.Enabled = true;
            this.axEviaEarthControl1.Location = new System.Drawing.Point(247, 0);
            this.axEviaEarthControl1.Name = "axEviaEarthControl1";
            this.axEviaEarthControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axEviaEarthControl1.OcxState")));
            this.axEviaEarthControl1.Size = new System.Drawing.Size(493, 461);
            this.axEviaEarthControl1.TabIndex = 2;
            this.axEviaEarthControl1.OnMouseDown += new AxEviaEarthLib._IEviaEarthControlEvents_OnMouseDownEventHandler(this.axEviaEarthControl1_OnMouseDown);
            this.axEviaEarthControl1.OnSceneReady += new AxEviaEarthLib._IEviaEarthControlEvents_OnSceneReadyEventHandler(this.axEviaEarthControl1_OnSceneReady);
            this.axEviaEarthControl1.OnObjectMouseDown += new AxEviaEarthLib._IEviaEarthControlEvents_OnObjectMouseDownEventHandler(this.axEviaEarthControl1_OnObjectMouseDown);
            this.axEviaEarthControl1.OnCameraChanged += new System.EventHandler(this.axEviaEarthControl1_OnCameraChanged);
            // 
            // FrmEarth
            // 
            this.ClientSize = new System.Drawing.Size(740, 461);
            this.Controls.Add(this.axEviaEarthControl1);
            this.Controls.Add(this.splitterControl1);
            this.Controls.Add(this.navBarControl1);
            this.Name = "FrmEarth";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "森林资源三维电子沙盘";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmEarth_Load);
            this.Shown += new System.EventHandler(this.FrmEarth_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl1)).EndInit();
            this.navBarControl1.ResumeLayout(false);
            this.navBarGroupControlContainer1.ResumeLayout(false);
            this.navBarGroupControlContainer2.ResumeLayout(false);
            this.navBarGroupControlContainer3.ResumeLayout(false);
            this.navBarGroupControlContainer4.ResumeLayout(false);
            this.navBarGroupControlContainer5.ResumeLayout(false);
            this.navBarGroupControlContainer6.ResumeLayout(false);
            this.navBarGroupControlContainer7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.axEviaEarthControl1)).EndInit();
            this.ResumeLayout(false);

        }

        private void LabelFeatures(LindQueryResult result)
        {
            IEVObjectManager pMgr = this.QueryKMLManager(this.m_earthControl.Scene.EvEarthScene as IEvEarthScene);
            if (pMgr != null)
            {
                IFeature pFeature = this.SearchFeature("QueryLabel2013", pMgr);
                if (pFeature != null)
                {
                    for (int i = 0; i < result.Points.Count; i++)
                    {
                        PointLabel label = result.Points[i];
                        StringBuilder builder = new StringBuilder();
                        builder.Append(label.OID).Append("+").Append(label.TableName);
                        this.AddPoint(label.X, label.Y, builder.ToString(), pFeature);
                    }
                }
            }
        }

        private void LabelLindResultFeatures(LindResultQuery result)
        {
            IEVObjectManager pMgr = this.QueryKMLManager(this.m_earthControl.Scene.EvEarthScene as IEvEarthScene);
            if (pMgr != null)
            {
                IFeature pFeature = this.SearchFeature("QueryLabel2013", pMgr);
                if (pFeature != null)
                {
                    for (int i = 0; i < result.PointsAdd.Count; i++)
                    {
                        PointLabel label = result.PointsAdd[i];
                        StringBuilder builder = new StringBuilder();
                        builder.Append(label.OID).Append("+").Append(label.TableName);
                        this.AddPoint(label.X, label.Y, builder.ToString(), pFeature);
                    }
                    for (int j = 0; j < result.PointsPlus.Count; j++)
                    {
                        PointLabel label2 = result.PointsPlus[j];
                        StringBuilder builder2 = new StringBuilder();
                        builder2.Append(label2.OID).Append("+").Append(label2.TableName);
                        this.AddPoint(label2.X, label2.Y, builder2.ToString(), pFeature);
                    }
                }
            }
        }

        private void navBarControl1_ActiveGroupChanged(object sender, NavBarGroupEventArgs e)
        {
            if (e.Group.Caption.Equals("动画模拟"))
            {
                this.m_isFlying = true;
            }
            else if (e.Group.Caption.Equals("行政定位"))
            {
                if (this.m_isFirstAdminLocate)
                {
                    this.ucAdminLocate1.ClassDbHandler = this.m_clsDbHandler;
                    this.ucAdminLocate1.UpdateYear = this.m_updateYear;
                    this.ucAdminLocate1.ConnectionString = this.m_connString;
                    this.ucAdminLocate1.OnTreeDoubleClick += new UCAdminLocate.TreeDoubleClick(this.ucAdminLocate1_OnTreeDoubleClick);
                    this.m_isFirstAdminLocate = false;
                }
                this.m_isFlying = false;
            }
            else if (e.Group.Caption.Equals("林地查询"))
            {
                if (this.m_isFirstForeLandAdd)
                {
                    this.ucForeLandQuery1.ClassDbHandler = this.m_clsDbHandler;
                    this.ucForeLandQuery1.UpdateYear = this.m_updateYear;
                    this.ucForeLandQuery1.ConnectionString = this.m_connString;
                    this.ucForeLandQuery1.OnLindResultQueryClear += new UCForeLandQuery.DoLindResultQueryClear(this.ucForeLandQuery1_OnLindResultQueryClear);
                    this.ucForeLandQuery1.OnLindResultQuery += new UCForeLandQuery.DoLindResultQuery(this.ucForeLandQuery1_OnLindResultQuery);
                    this.ucForeLandQuery1.OnLindChangeQueryClear += new UCForeLandQuery.DoLindChangeQueryClear(this.ucForeLandQuery1_OnLindChangeQueryClear);
                    this.ucForeLandQuery1.OnLindChangeQuery += new UCForeLandQuery.DoLindChangeQuery(this.ucForeLandQuery1_OnLindChangeQuery);
                    this.ucForeLandQuery1.OnXbGridViewDoubleClick += new UCForeLandQuery.FlyToXB(this.ucForeLandQuery1_OnXbGridViewDoubleClick);
                    this.m_isFirstForeLandAdd = false;
                }
                this.m_isFlying = false;
            }
            else if (e.Group.Caption.Equals("资源查询"))
            {
                if (this.m_isFirstForestAdd)
                {
                    this.ucForestQuery1.ClassDbHandler = this.m_clsDbHandler;
                    this.ucForestQuery1.UpdateYear = this.m_updateYear;
                    this.ucForestQuery1.ConnectionString = this.m_connString;
                    this.ucForestQuery1.OnForestThemQueryComplete += new UCForestQuery.FlashThemMap(this.ucForestQuery1_OnForestThemQueryComplete);
                    this.ucForestQuery1.OnThemQueryResultClear += new UCForestQuery.ClearSelectThemMap(this.ucForestQuery1_OnThemQueryResultClear);
                    this.ucForestQuery1.OnXbGridViewDoubleClick += new UCForestQuery.FlyToXB(this.ucForestQuery1_OnXbGridViewDoubleClick);
                    this.ucForestQuery1.OnBusinessQueryComplete += new UCForestQuery.LabelPoints(this.ucForestQuery1_OnBusinessQueryComplete);
                    this.ucForestQuery1.OnLabelPointsClear += new UCForestQuery.ClearLabelPoints(this.ucForestQuery1_OnLabelPointsClear);
                    this.m_isFirstForestAdd = false;
                }
            }
            else if (e.Group.Caption.Equals("专题浏览"))
            {
                if (this.m_isFirestThemControlAdd)
                {
                    this.ucThematicControl1.OnThemTreeNodeCheck += new UCThematicControl.GetThemAreaXJ(this.ucThematicControl1_OnThemTreeNodeCheck);
                    this.m_isFirestThemControlAdd = false;
                }
            }
            else
            {
                this.m_isFlying = false;
            }
        }

        private void nbi_around_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            try
            {
                CameraController cameraControl = this.m_earthControl.CameraControl;
                IEvEarthScene evEarthScene = this.m_earthControl.Scene.EvEarthScene as IEvEarthScene;
                IEvEarthCamera camera = evEarthScene.Camera as IEvEarthCamera;
                EvEarthLookAt lookAt = camera.GetLookAt();
                cameraControl.Surround(lookAt.Longitude, lookAt.Latitude, lookAt.Altitude, 2.0, camera.Altitude, lookAt.Range);
            }
            catch (Exception exception)
            {
                MessageBox.Show("环绕工具调用出错，可能的原因：" + exception.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void nbi_fullExtent_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            this.ZoomToConty();
        }

        private void nbi_identify_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            this.m_identifying = true;
            IEvEarthApplication pluginsMgr = this.m_earthControl.PluginsMgr as IEvEarthApplication;
            pluginsMgr.ToolMsg = "xbIdentifing";
        }

        private void nbi_pan_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            IEvEarthApplication pluginsMgr = this.axEviaEarthControl1.PluginsMgr as IEvEarthApplication;
            pluginsMgr.ToolMsg = "";
            this.m_identifying = false;
        }

        private void nbi_sysConfig_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            FrmServiceConfig config = new FrmServiceConfig();
            config.ShowDialog();
            config.Dispose();
            if (config.CreateESConfigXml)
            {
                MessageBox.Show("设置的参数将在下次启动本窗体时生效！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void nbi_xbLocate_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            FrmXbLocate locate = new FrmXbLocate(this.m_connString, this.m_updateYear);
            locate.OnComboSelected += new FrmXbLocate.ComboSelected(this.fxl_OnComboSelected);
            locate.ShowDialog();
            locate.Dispose();
        }

        private void nbi_xyLocate_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            try
            {
                this.m_earthControl.PluginsMgr.ExeCmd("0251B6F1-BF1C-41f4-B042-BFF0A63A291E", "EvPosition");
            }
            catch (Exception exception)
            {
                MessageBox.Show("坐标定位出错，可能的原因：" + exception.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private IEVObjectManager QueryKMLManager(IEvEarthScene scene)
        {
            IEvEarthNodeEx ex = scene as IEvEarthNodeEx;
            IEVObjectManager pNode = null;
            for (int i = 0; i < ex.ChildCount; i++)
            {
                pNode = ex.get_Child(i) as IEVObjectManager;
                if (pNode != null)
                {
                    break;
                }
            }
            if (pNode == null)
            {
                pNode = new EVObjectManagerClass();
                ex.AddChild(pNode);
                IEvEarthNode node = pNode as IEvEarthNode;
                node.NodeName = "VectorManager";
            }
            return pNode;
        }

        private IFeature SearchFeature(string name, IEVObjectManager pMgr)
        {
            if (pMgr.Features == null)
            {
                return null;
            }
            long count = pMgr.Features.Count;
            for (int i = 0; i < count; i++)
            {
                IFeature child = pMgr.Features.GetChild(i) as IFeature;
                if ((child != null) && (child.Name.CompareTo(name) == 0))
                {
                    return child;
                }
            }
            IKmlLayer layer = new KmlLayerClass();
            layer.Name = name;
            pMgr.Features.AppendChild(layer);
            return layer;
        }

        private void SetLayerVisible(string mapName, bool visible)
        {
            this.ucThematicControl1.SelectNodeByText(mapName, visible);
        }

        private void ShowXbInforForm(XbIdentifyInfo identify)
        {
            this.m_xbInfoForm = ClsConfigManage.XbInfoForm;
            if ((this.m_xbInfoForm != null) && this.m_xbInfoForm.Visible)
            {
                this.m_xbInfoForm.Visible = false;
                this.m_xbInfoForm.IdentifyResult = identify.XbInfoTable;
                this.m_xbInfoForm.Visible = true;
            }
            else
            {
                this.m_xbInfoForm = new FrmIdentifyInfo();
                this.m_xbInfoForm.IdentifyResult = identify.XbInfoTable;
                this.m_xbInfoForm.Show(this);
                ClsConfigManage.XbInfoForm = this.m_xbInfoForm;
            }
        }

        private void t_Tick(object sender, EventArgs e)
        {
            this.ZoomToConty();
            (sender as Timer).Stop();
        }

        private void ucAdminLocate1_OnTreeDoubleClick(object sender, AdminLocateStatisInfo result)
        {
            try
            {
                this.FlyToDestinationByGeoString(result.GeoString, false);
                if ((this.m_inforForm != null) && this.m_inforForm.Visible)
                {
                    this.m_inforForm.Visible = false;
                    this.m_inforForm.Information = result.ForestInfo;
                    this.m_inforForm.Visible = true;
                }
                else
                {
                    this.m_inforForm = new FrmInformation();
                    this.m_inforForm.Information = result.ForestInfo;
                    Point point = new Point();
                    point.X = (Screen.PrimaryScreen.WorkingArea.Width / 2) - 0xe1;
                    point.Y = 20;
                    this.m_inforForm.Location = point;
                    this.m_inforForm.Show(this);
                    ClsConfigManage.InformationForm = this.m_inforForm;
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("解析信息出错，可能的原因：" + exception.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void ucForeLandQuery1_OnLindChangeQuery(object sender, LindQueryResult result)
        {
            if ((result != null) && (result.Points.Count > 0))
            {
                this.ClearTargetIcon();
                this.LabelFeatures(result);
            }
        }

        private void ucForeLandQuery1_OnLindChangeQueryClear(object sender, bool clear)
        {
            if (clear)
            {
                this.ClearTargetIcon();
            }
        }

        private void ucForeLandQuery1_OnLindResultQuery(object sender, LindResultQuery result)
        {
            if ((((result != null) && (result.PointsAdd != null)) && ((result.PointsAdd.Count > 0) && (result.PointsPlus != null))) && (result.PointsPlus.Count > 0))
            {
                this.ClearTargetIcon();
                this.LabelLindResultFeatures(result);
            }
        }

        private void ucForeLandQuery1_OnLindResultQueryClear(object sender, bool clear)
        {
            if (clear)
            {
                this.ClearTargetIcon();
            }
        }

        private void ucForeLandQuery1_OnXbGridViewDoubleClick(object sender, int oid, string tableName)
        {
            XbIdentifyInfo zTXbInfoByOid = this.m_clsDbHandler.GetZTXbInfoByOid(oid, tableName);
            if (zTXbInfoByOid != null)
            {
                this.FlyToDestinationByGeoString(zTXbInfoByOid.GeoString, true);
                this.ShowXbInforForm(zTXbInfoByOid);
            }
        }

        private void ucForestQuery1_OnBusinessQueryComplete(object sender, LindQueryResult result)
        {
            if ((result != null) && (result.Points.Count > 0))
            {
                this.ClearTargetIcon();
                this.LabelFeatures(result);
            }
        }

        private void ucForestQuery1_OnForestThemQueryComplete(object sender, string mapName, string issz)
        {
            this.FlashMap(mapName, issz);
        }

        private void ucForestQuery1_OnLabelPointsClear(object sender, bool clear)
        {
            if (clear)
            {
                this.ClearTargetIcon();
            }
        }

        private void ucForestQuery1_OnThemQueryResultClear(object sender, string mapName)
        {
            if (!string.IsNullOrEmpty(mapName))
            {
                this.SetLayerVisible(mapName, false);
            }
        }

        private void ucForestQuery1_OnXbGridViewDoubleClick(object sender, int oid, string tableName)
        {
            XbIdentifyInfo zTXbInfoByOid = this.m_clsDbHandler.GetZTXbInfoByOid(oid, tableName);
            if (zTXbInfoByOid != null)
            {
                this.FlyToDestinationByGeoString(zTXbInfoByOid.GeoString, true);
                this.ShowXbInforForm(zTXbInfoByOid);
            }
        }

        private void ucThematicControl1_OnThemTreeNodeCheck(object sender, string whereClasue)
        {
            try
            {
                double num3;
                double num4;
                double num5;
                string themAreaXJString = this.m_clsDbHandler.GetThemAreaXJString(whereClasue);
                int winx = this.navBarControl1.Width + 50;
                int winy = 0;
                this.m_earthControl.Scene.WinToBL(winx, winy, out num3, out num4, out num5);
                this.GenerateBallon(num3, num4, themAreaXJString);
            }
            catch (Exception exception)
            {
                MessageBox.Show("方法ucThematicControl1_OnThemTreeNodeCheck处理出错，可能的原因：" + exception.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void ZoomToConty()
        {
            try
            {
                if (this.m_earthControl != null)
                {
                    IEvEarthFolder rootFolder = ((IEvEarthScene) this.m_earthControl.Scene.EvEarthScene).Doc.RootFolder;
                    if (rootFolder != null)
                    {
                        for (int i = 0; i < rootFolder.ChildCount; i++)
                        {
                            IEvEarthLayer child = rootFolder.GetChild(i);
                            if (child.Name.Contains("乡界"))
                            {
                                this.m_earthControl.ViewPoint.FlyToBox(child.MaxGeo.x, child.MinGeo.x, child.MinGeo.z, child.MaxGeo.z, 1.0);
                                break;
                            }
                        }
                    }
                    if (!this.m_ucThematicControlSet)
                    {
                        this.ucThematicControl1.EarthControl = this.m_earthControl;
                        this.m_ucThematicControlSet = true;
                    }
                }
            }
            catch
            {
            }
        }

        private delegate void ResultHandle(object sender, AdminLocateStatisInfo result);
    }
}

