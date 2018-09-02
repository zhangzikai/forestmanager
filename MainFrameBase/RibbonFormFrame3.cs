namespace MainFrameBase
{
    using DevExpress.LookAndFeel;
    using DevExpress.Utils;
    using DevExpress.XtraBars;
    using DevExpress.XtraBars.Docking;
    using DevExpress.XtraBars.Ribbon;
    using DevExpress.XtraEditors.Controls;
    using DevExpress.XtraEditors.Repository;
    using DevExpress.XtraTab;
    using ESRI.ArcGIS.Controls;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class RibbonFormFrame3 : RibbonForm
    {
        public ApplicationMenu applicationMenu1;
        public AxLicenseControl axLicenseControl1;
        public AxTOCControl axTOCControl;
        private Bar bar1;
        private Bar bar2;
        private Bar bar3;
        private BarButtonItem barButtonItem1;
        private BarButtonItem barButtonItem2;
        public BarButtonItem barButtonItemHelp;
        public BarButtonItem barButtonItemToolbox;
        public BarButtonItem barButtonItemToolView;
        private BarDockControl barDockControlBottom;
        private BarDockControl barDockControlLeft;
        private BarDockControl barDockControlRight;
        private BarDockControl barDockControlTop;
        public BarEditItem barEditItemScale;
        private BarManager barManager1;
        public BarStaticItem barStaticItemInfo;
        public BarStaticItem barStaticItemLocation1;
        public BarStaticItem barStaticItemLocation2;
        public BarStaticItem barStaticItemLocation3;
        public BarStaticItem barStaticItemScale;
        private IContainer components;
        public DefaultLookAndFeel defaultLookAndFeel1;
        public DockManager dockManager1;
        public DockPanel dockPanelBottom;
        public ControlContainer dockPanelBottom_Container;
        public DockPanel dockPanelEdit;
        public ControlContainer dockPanelEdit_Container;
        public DockPanel dockPanelToolbox;
        public ControlContainer dockPanelToolbox_Container;
        public DevExpress.Utils.ImageCollection imageCollection1;
        public DevExpress.Utils.ImageCollection imageCollection2;
        protected AxMapControl MapControlEdit;
        protected AxPageLayoutControl PageLayoutControlEdit;
        private Panel panelFull;
        public RepositoryItemComboBox repositoryItemComboBox1;
        public RibbonControl ribbon;
        public RibbonPage ribbonPageCheck;
        public RibbonPage ribbonPageDataEdit;
        public RibbonPage ribbonPageGraphics;
        public RibbonPage ribbonPageQuery;
        public RibbonPage ribbonPageTransfer;
        public RibbonStatusBar ribbonStatusBar;
        public XtraTabPage tabPageMapContol;
        public XtraTabPage tabPagePagelayoutContol;
        public TextBox textBox1;
        public XtraTabControl xtraTabMain;
        public XtraTabPage xtraTabPageIdentify;
        public XtraTabPage xtraTabPageQuery;
        public XtraTabPage xtraTabPageTOC;
        public XtraTabControl xtraTabToolbox;

        public RibbonFormFrame3()
        {
            this.InitializeComponent();
            this.defaultLookAndFeel1.LookAndFeel.SkinName = "Blue";
        }

        protected override void Dispose(bool disposing)
        {
            try
            {
                if (disposing && (this.components != null))
                {
                    this.components.Dispose();
                }
                base.Dispose(disposing);
            }
            catch (Exception)
            {
            }
        }

        public void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RibbonFormFrame3));
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.applicationMenu1 = new DevExpress.XtraBars.Ribbon.ApplicationMenu(this.components);
            this.imageCollection1 = new DevExpress.Utils.ImageCollection(this.components);
            this.barButtonItemToolbox = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemToolView = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemHelp = new DevExpress.XtraBars.BarButtonItem();
            this.barStaticItemInfo = new DevExpress.XtraBars.BarStaticItem();
            this.barStaticItemLocation1 = new DevExpress.XtraBars.BarStaticItem();
            this.barStaticItemLocation2 = new DevExpress.XtraBars.BarStaticItem();
            this.barStaticItemLocation3 = new DevExpress.XtraBars.BarStaticItem();
            this.barStaticItemScale = new DevExpress.XtraBars.BarStaticItem();
            this.barEditItemScale = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.imageCollection2 = new DevExpress.Utils.ImageCollection(this.components);
            this.ribbonPageDataEdit = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageCheck = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageQuery = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGraphics = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageTransfer = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.defaultLookAndFeel1 = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            this.dockManager1 = new DevExpress.XtraBars.Docking.DockManager(this.components);
            this.dockPanelEdit = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanelEdit_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.dockPanelBottom = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanelBottom_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.panelFull = new System.Windows.Forms.Panel();
            this.xtraTabMain = new DevExpress.XtraTab.XtraTabControl();
            this.tabPageMapContol = new DevExpress.XtraTab.XtraTabPage();
            this.MapControlEdit = new ESRI.ArcGIS.Controls.AxMapControl();
            this.axLicenseControl1 = new ESRI.ArcGIS.Controls.AxLicenseControl();
            this.tabPagePagelayoutContol = new DevExpress.XtraTab.XtraTabPage();
            this.PageLayoutControlEdit = new ESRI.ArcGIS.Controls.AxPageLayoutControl();
            this.dockPanelToolbox = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanelToolbox_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.xtraTabToolbox = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPageTOC = new DevExpress.XtraTab.XtraTabPage();
            this.axTOCControl = new ESRI.ArcGIS.Controls.AxTOCControl();
            this.xtraTabPageIdentify = new DevExpress.XtraTab.XtraTabPage();
            this.xtraTabPageQuery = new DevExpress.XtraTab.XtraTabPage();
            this.textBox1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.applicationMenu1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).BeginInit();
            this.dockPanelEdit.SuspendLayout();
            this.dockPanelBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            this.panelFull.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabMain)).BeginInit();
            this.xtraTabMain.SuspendLayout();
            this.tabPageMapContol.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MapControlEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl1)).BeginInit();
            this.tabPagePagelayoutContol.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PageLayoutControlEdit)).BeginInit();
            this.dockPanelToolbox.SuspendLayout();
            this.dockPanelToolbox_Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabToolbox)).BeginInit();
            this.xtraTabToolbox.SuspendLayout();
            this.xtraTabPageTOC.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axTOCControl)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbon
            // 
            this.ribbon.ApplicationButtonDropDownControl = this.applicationMenu1;
            this.ribbon.ApplicationButtonText = null;
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.Images = this.imageCollection1;
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbon.ExpandCollapseItem,
            this.barButtonItemToolbox,
            this.barButtonItemToolView,
            this.barButtonItemHelp,
            this.barStaticItemInfo,
            this.barStaticItemLocation1,
            this.barStaticItemLocation2,
            this.barStaticItemLocation3,
            this.barStaticItemScale,
            this.barEditItemScale,
            this.barButtonItem2,
            this.barButtonItem1});
            this.ribbon.LargeImages = this.imageCollection2;
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.MaxItemId = 19;
            this.ribbon.Name = "ribbon";
            this.ribbon.PageHeaderItemLinks.Add(this.barButtonItemHelp);
            this.ribbon.PageHeaderItemLinks.Add(this.barButtonItem2);
            this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPageDataEdit,
            this.ribbonPageCheck,
            this.ribbonPageQuery,
            this.ribbonPageGraphics,
            this.ribbonPageTransfer});
            this.ribbon.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemComboBox1});
            this.ribbon.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbon.Size = new System.Drawing.Size(1016, 149);
            this.ribbon.StatusBar = this.ribbonStatusBar;
            // 
            // applicationMenu1
            // 
            this.applicationMenu1.MenuDrawMode = DevExpress.XtraBars.MenuDrawMode.LargeImagesText;
            this.applicationMenu1.Name = "applicationMenu1";
            this.applicationMenu1.Ribbon = this.ribbon;
            // 
            // imageCollection1
            // 
            this.imageCollection1.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection1.ImageStream")));
            this.imageCollection1.Images.SetKeyName(0, "stock_draw-freeform-line-16.png");
            this.imageCollection1.Images.SetKeyName(1, "stock_draw-freeform-line-filled-16.png");
            this.imageCollection1.Images.SetKeyName(2, "stock_draw-polygon-filled-16.png");
            this.imageCollection1.Images.SetKeyName(3, "web_(edit)_16x16.gif");
            this.imageCollection1.Images.SetKeyName(4, "drawing_pen-16.png");
            this.imageCollection1.Images.SetKeyName(5, "compass4.png");
            this.imageCollection1.Images.SetKeyName(6, "monitor_16.png");
            this.imageCollection1.Images.SetKeyName(7, "clipboard_16.png");
            this.imageCollection1.Images.SetKeyName(8, "folder_16.png");
            this.imageCollection1.Images.SetKeyName(9, "plus_16.png");
            this.imageCollection1.Images.SetKeyName(10, "print_16.png");
            this.imageCollection1.Images.SetKeyName(11, "document_16.png");
            this.imageCollection1.Images.SetKeyName(12, "statistics_16.png");
            this.imageCollection1.Images.SetKeyName(13, "up_16.png");
            this.imageCollection1.Images.SetKeyName(14, "home_16.png");
            this.imageCollection1.Images.SetKeyName(15, "down_16.png");
            this.imageCollection1.Images.SetKeyName(16, "bubble_16.png");
            this.imageCollection1.Images.SetKeyName(17, "left_16.png");
            this.imageCollection1.Images.SetKeyName(18, "right_16.png");
            this.imageCollection1.Images.SetKeyName(19, "label_16.png");
            this.imageCollection1.Images.SetKeyName(20, "delete_16.png");
            this.imageCollection1.Images.SetKeyName(21, "flag_16.png");
            this.imageCollection1.Images.SetKeyName(22, "info_16.png");
            this.imageCollection1.Images.SetKeyName(23, "clock_16.png");
            this.imageCollection1.Images.SetKeyName(24, "search_16.png");
            this.imageCollection1.Images.SetKeyName(25, "globe_16.png");
            this.imageCollection1.Images.SetKeyName(26, "input-edit.png");
            this.imageCollection1.Images.SetKeyName(27, "searchCAAWLE08.png");
            this.imageCollection1.Images.SetKeyName(28, "searchCA4F6CNX.png");
            this.imageCollection1.Images.SetKeyName(29, "web-search.png");
            this.imageCollection1.Images.SetKeyName(30, "home0.png");
            this.imageCollection1.Images.SetKeyName(31, "agt_reload16.png");
            this.imageCollection1.Images.SetKeyName(32, "blue-document-search-result.png");
            this.imageCollection1.Images.SetKeyName(33, "sql-join-left-exclude.png");
            this.imageCollection1.Images.SetKeyName(34, "arrow-circle-225-left.png");
            this.imageCollection1.Images.SetKeyName(35, "blue-folder-open-document-text.png");
            this.imageCollection1.Images.SetKeyName(36, "clipboard_paste_document_text.png");
            this.imageCollection1.Images.SetKeyName(37, "folder_open_document_text.png");
            this.imageCollection1.Images.SetKeyName(38, "hammer_screwdriver.png");
            this.imageCollection1.Images.SetKeyName(39, "layers__pencil.png");
            this.imageCollection1.Images.SetKeyName(40, "layers00.png");
            this.imageCollection1.Images.SetKeyName(41, "layers__plus.png");
            this.imageCollection1.Images.SetKeyName(42, "layers-ungroup.png");
            this.imageCollection1.Images.SetKeyName(43, "layer--arrow.png");
            this.imageCollection1.Images.SetKeyName(44, "layer--pencil.png");
            this.imageCollection1.Images.SetKeyName(45, "layer-vector.png");
            this.imageCollection1.Images.SetKeyName(46, "layer-resize.png");
            this.imageCollection1.Images.SetKeyName(47, "layer-resize-actual.png");
            this.imageCollection1.Images.SetKeyName(48, "layer-select.png");
            this.imageCollection1.Images.SetKeyName(49, "layer-select-point.png");
            this.imageCollection1.Images.SetKeyName(50, "layer-shaded-relief-add.png");
            this.imageCollection1.Images.SetKeyName(51, "layer-shape-curve.png");
            this.imageCollection1.Images.SetKeyName(52, "layer-shape-ellipse.png");
            this.imageCollection1.Images.SetKeyName(53, "layer-shape-line.png");
            this.imageCollection1.Images.SetKeyName(54, "layer-shape-polygon.png");
            this.imageCollection1.Images.SetKeyName(55, "layer-transparent.png");
            this.imageCollection1.Images.SetKeyName(56, "hand.png");
            this.imageCollection1.Images.SetKeyName(57, "comments-edit.png");
            this.imageCollection1.Images.SetKeyName(58, "computer.png");
            this.imageCollection1.Images.SetKeyName(59, "copy2.png");
            this.imageCollection1.Images.SetKeyName(60, "cut2.png");
            this.imageCollection1.Images.SetKeyName(61, "doc-edit.png");
            this.imageCollection1.Images.SetKeyName(62, "overlay-edit.png");
            this.imageCollection1.Images.SetKeyName(63, "paste.png");
            this.imageCollection1.Images.SetKeyName(64, "previous.png");
            this.imageCollection1.Images.SetKeyName(65, "news-send.png");
            this.imageCollection1.Images.SetKeyName(66, "home.png");
            this.imageCollection1.Images.SetKeyName(67, "image.png");
            this.imageCollection1.Images.SetKeyName(68, "image-edit.png");
            this.imageCollection1.Images.SetKeyName(69, "image-info.png");
            this.imageCollection1.Images.SetKeyName(70, "image-ok.png");
            this.imageCollection1.Images.SetKeyName(71, "image-send.png");
            this.imageCollection1.Images.SetKeyName(72, "info.png");
            this.imageCollection1.Images.SetKeyName(73, "next.png");
            this.imageCollection1.Images.SetKeyName(74, "search-add.png");
            this.imageCollection1.Images.SetKeyName(75, "search-del.png");
            this.imageCollection1.Images.SetKeyName(76, "eye.png");
            this.imageCollection1.Images.SetKeyName(77, "tree2.png");
            this.imageCollection1.Images.SetKeyName(78, "disk.png");
            this.imageCollection1.Images.SetKeyName(79, "1259760497_color_swatch_2.png");
            this.imageCollection1.Images.SetKeyName(80, "arrow_circle_double.png");
            this.imageCollection1.Images.SetKeyName(81, "arrow-circle-135-left.png");
            this.imageCollection1.Images.SetKeyName(82, "arrow-in.png");
            this.imageCollection1.Images.SetKeyName(83, "arrow-out.png");
            this.imageCollection1.Images.SetKeyName(84, "folder_find16.png");
            this.imageCollection1.Images.SetKeyName(85, "gtk-execute16.png");
            this.imageCollection1.Images.SetKeyName(86, "hand.png");
            this.imageCollection1.Images.SetKeyName(87, "hand_point.png");
            this.imageCollection1.Images.SetKeyName(88, "image_arrow.png");
            this.imageCollection1.Images.SetKeyName(89, "map_edit2.png");
            this.imageCollection1.Images.SetKeyName(90, "map_go.png");
            this.imageCollection1.Images.SetKeyName(91, "map_magnify2.png");
            this.imageCollection1.Images.SetKeyName(92, "map2.png");
            this.imageCollection1.Images.SetKeyName(93, "map4.png");
            this.imageCollection1.Images.SetKeyName(94, "map--arrow.png");
            this.imageCollection1.Images.SetKeyName(95, "map--minus.png");
            this.imageCollection1.Images.SetKeyName(96, "map--pencil.png");
            this.imageCollection1.Images.SetKeyName(97, "map-pin.png");
            this.imageCollection1.Images.SetKeyName(98, "map--plus.png");
            this.imageCollection1.Images.SetKeyName(99, "maps.png");
            this.imageCollection1.Images.SetKeyName(100, "maps--arrow.png");
            this.imageCollection1.Images.SetKeyName(101, "maps--minus.png");
            this.imageCollection1.Images.SetKeyName(102, "maps--pencil3.png");
            this.imageCollection1.Images.SetKeyName(103, "maps--plus.png");
            this.imageCollection1.Images.SetKeyName(104, "maps-stack.png");
            this.imageCollection1.Images.SetKeyName(105, "pathing3.png");
            this.imageCollection1.Images.SetKeyName(106, "picture_pencil.png");
            this.imageCollection1.Images.SetKeyName(107, "table__arrow.png");
            this.imageCollection1.Images.SetKeyName(108, "upload.png");
            this.imageCollection1.Images.SetKeyName(109, "circle.ico");
            this.imageCollection1.Images.SetKeyName(110, "complain.ico");
            this.imageCollection1.Images.SetKeyName(111, "copy.ico");
            this.imageCollection1.Images.SetKeyName(112, "cut.ico");
            this.imageCollection1.Images.SetKeyName(113, "DATA16.ICO");
            this.imageCollection1.Images.SetKeyName(114, "disk.png");
            this.imageCollection1.Images.SetKeyName(115, "find_doc.ico");
            this.imageCollection1.Images.SetKeyName(116, "fullscrn.ico");
            this.imageCollection1.Images.SetKeyName(117, "fw_convert2_icon.gif");
            this.imageCollection1.Images.SetKeyName(118, "IMBigToolbarShare.ico");
            this.imageCollection1.Images.SetKeyName(119, "IMSmallToolbarPicture.ico");
            this.imageCollection1.Images.SetKeyName(120, "mdf_ndf_dbfiles.ico");
            this.imageCollection1.Images.SetKeyName(121, "transaction_logfile.ico");
            this.imageCollection1.Images.SetKeyName(122, "money.ico");
            this.imageCollection1.Images.SetKeyName(123, "export.ico");
            this.imageCollection1.Images.SetKeyName(124, "NetDiskButton.ico");
            this.imageCollection1.Images.SetKeyName(125, "Title.ico");
            this.imageCollection1.Images.SetKeyName(126, "PAD_HCUR.ICO");
            this.imageCollection1.Images.SetKeyName(127, "PAD_HOL.ICO");
            this.imageCollection1.Images.SetKeyName(128, "PAD_ILL.ICO");
            this.imageCollection1.Images.SetKeyName(129, "PAD_SJOB.ICO");
            this.imageCollection1.Images.SetKeyName(130, "pae_misc.ico");
            this.imageCollection1.Images.SetKeyName(131, "blank16.ico");
            this.imageCollection1.Images.SetKeyName(132, "PART16.ICO");
            this.imageCollection1.Images.SetKeyName(133, "tick16.ico");
            this.imageCollection1.Images.SetKeyName(134, "PushMsgInfo.ico");
            this.imageCollection1.Images.SetKeyName(135, "SearchButton.ico");
            this.imageCollection1.Images.SetKeyName(136, "setting.ico");
            this.imageCollection1.Images.SetKeyName(137, "15.png");
            this.imageCollection1.Images.SetKeyName(138, "16.png");
            this.imageCollection1.Images.SetKeyName(139, "17.png");
            this.imageCollection1.Images.SetKeyName(140, "18.png");
            this.imageCollection1.Images.SetKeyName(141, "19.png");
            this.imageCollection1.Images.SetKeyName(142, "20.png");
            this.imageCollection1.Images.SetKeyName(143, "21.png");
            this.imageCollection1.Images.SetKeyName(144, "22.png");
            this.imageCollection1.Images.SetKeyName(145, "31.png");
            this.imageCollection1.Images.SetKeyName(146, "200891810552320503.gif");
            this.imageCollection1.Images.SetKeyName(147, "BaseTools.Bitmap.bmpFolder2.bmp");
            this.imageCollection1.Images.SetKeyName(148, "chart.png");
            this.imageCollection1.Images.SetKeyName(149, "chart_line.png");
            this.imageCollection1.Images.SetKeyName(150, "chart_line_add.png");
            this.imageCollection1.Images.SetKeyName(151, "chart_line_delete.png");
            this.imageCollection1.Images.SetKeyName(152, "chart_line_edit.png");
            this.imageCollection1.Images.SetKeyName(153, "chart_pie.png");
            this.imageCollection1.Images.SetKeyName(154, "chart_pie_edit.png");
            this.imageCollection1.Images.SetKeyName(155, "cmy.png");
            this.imageCollection1.Images.SetKeyName(156, "control_add_blue.png");
            this.imageCollection1.Images.SetKeyName(157, "control_end_blue.png");
            this.imageCollection1.Images.SetKeyName(158, "control_fastforward_blue.png");
            this.imageCollection1.Images.SetKeyName(159, "control_pause_blue.png");
            this.imageCollection1.Images.SetKeyName(160, "control_play_blue.png");
            this.imageCollection1.Images.SetKeyName(161, "control_power_blue.png");
            this.imageCollection1.Images.SetKeyName(162, "control_record_blue.png");
            this.imageCollection1.Images.SetKeyName(163, "control_remove_blue.png");
            this.imageCollection1.Images.SetKeyName(164, "control_rewind_blue.png");
            this.imageCollection1.Images.SetKeyName(165, "control_start_blue.png");
            this.imageCollection1.Images.SetKeyName(166, "control_stop_blue.png");
            this.imageCollection1.Images.SetKeyName(167, "creditcards.png");
            this.imageCollection1.Images.SetKeyName(168, "cross.png");
            this.imageCollection1.Images.SetKeyName(169, "cut.png");
            this.imageCollection1.Images.SetKeyName(170, "Feedicons_v2_010.png");
            this.imageCollection1.Images.SetKeyName(171, "Feedicons_v2_011.png");
            this.imageCollection1.Images.SetKeyName(172, "flag blue.png");
            this.imageCollection1.Images.SetKeyName(173, "flag red.png");
            this.imageCollection1.Images.SetKeyName(174, "flag yellow.png");
            this.imageCollection1.Images.SetKeyName(175, "home.png");
            this.imageCollection1.Images.SetKeyName(176, "hot.bmp");
            this.imageCollection1.Images.SetKeyName(177, "image_edit.png");
            this.imageCollection1.Images.SetKeyName(178, "layout_content.png");
            this.imageCollection1.Images.SetKeyName(179, "magifier_zoom_out.png");
            this.imageCollection1.Images.SetKeyName(180, "magnifier.png");
            this.imageCollection1.Images.SetKeyName(181, "magnifier_zoom_in.png");
            this.imageCollection1.Images.SetKeyName(182, "overlays.png");
            this.imageCollection1.Images.SetKeyName(183, "page_landscape_shot.png");
            this.imageCollection1.Images.SetKeyName(184, "page_paste.png");
            this.imageCollection1.Images.SetKeyName(185, "pencil.png");
            this.imageCollection1.Images.SetKeyName(186, "pencil_add.png");
            this.imageCollection1.Images.SetKeyName(187, "pencil_delete.png");
            this.imageCollection1.Images.SetKeyName(188, "pencil_go.png");
            this.imageCollection1.Images.SetKeyName(189, "photo.png");
            this.imageCollection1.Images.SetKeyName(190, "picture.png");
            this.imageCollection1.Images.SetKeyName(191, "plugin.png");
            this.imageCollection1.Images.SetKeyName(192, "plugin_add.png");
            this.imageCollection1.Images.SetKeyName(193, "plugin_delete.png");
            this.imageCollection1.Images.SetKeyName(194, "plugin_edit.png");
            this.imageCollection1.Images.SetKeyName(195, "rgb.png");
            this.imageCollection1.Images.SetKeyName(196, "shape_group.png");
            this.imageCollection1.Images.SetKeyName(197, "shape_handles.png");
            this.imageCollection1.Images.SetKeyName(198, "shape_shade_a.png");
            this.imageCollection1.Images.SetKeyName(199, "shape_shadow_toggle.png");
            this.imageCollection1.Images.SetKeyName(200, "table.png");
            this.imageCollection1.Images.SetKeyName(201, "table_add.png");
            this.imageCollection1.Images.SetKeyName(202, "table_cell.png");
            this.imageCollection1.Images.SetKeyName(203, "table_delete.png");
            this.imageCollection1.Images.SetKeyName(204, "table_edit.png");
            this.imageCollection1.Images.SetKeyName(205, "table_multiple.png");
            this.imageCollection1.Images.SetKeyName(206, "table_refresh.png");
            this.imageCollection1.Images.SetKeyName(207, "table_relationship.png");
            this.imageCollection1.Images.SetKeyName(208, "table_row.png");
            this.imageCollection1.Images.SetKeyName(209, "vector.png");
            this.imageCollection1.Images.SetKeyName(210, "vector_add.png");
            this.imageCollection1.Images.SetKeyName(211, "vector_delete.png");
            this.imageCollection1.Images.SetKeyName(212, "world.png");
            this.imageCollection1.Images.SetKeyName(213, "world_add.png");
            this.imageCollection1.Images.SetKeyName(214, "world_delete.png");
            this.imageCollection1.Images.SetKeyName(215, "world_edit.png");
            this.imageCollection1.Images.SetKeyName(216, "world_go.png");
            this.imageCollection1.Images.SetKeyName(217, "zoom.png");
            this.imageCollection1.Images.SetKeyName(218, "zoom_in.png");
            this.imageCollection1.Images.SetKeyName(219, "zoom_out.png");
            this.imageCollection1.Images.SetKeyName(220, "(00,02).png");
            this.imageCollection1.Images.SetKeyName(221, "(00,12).png");
            this.imageCollection1.Images.SetKeyName(222, "(00,17).png");
            this.imageCollection1.Images.SetKeyName(223, "(00,26).png");
            this.imageCollection1.Images.SetKeyName(224, "(00,33).png");
            this.imageCollection1.Images.SetKeyName(225, "(00,39).png");
            this.imageCollection1.Images.SetKeyName(226, "(00,40).png");
            this.imageCollection1.Images.SetKeyName(227, "(01,25).png");
            this.imageCollection1.Images.SetKeyName(228, "(01,26).png");
            this.imageCollection1.Images.SetKeyName(229, "(01,39).png");
            this.imageCollection1.Images.SetKeyName(230, "(01,49).png");
            this.imageCollection1.Images.SetKeyName(231, "(02,27).png");
            this.imageCollection1.Images.SetKeyName(232, "(03,26).png");
            this.imageCollection1.Images.SetKeyName(233, "(03,29).png");
            this.imageCollection1.Images.SetKeyName(234, "(03,32).png");
            this.imageCollection1.Images.SetKeyName(235, "(03,42).png");
            this.imageCollection1.Images.SetKeyName(236, "(04,42).png");
            this.imageCollection1.Images.SetKeyName(237, "(04,43).png");
            this.imageCollection1.Images.SetKeyName(238, "(05,16).png");
            this.imageCollection1.Images.SetKeyName(239, "(05,37).png");
            this.imageCollection1.Images.SetKeyName(240, "(05,49).png");
            this.imageCollection1.Images.SetKeyName(241, "(06,08).png");
            this.imageCollection1.Images.SetKeyName(242, "(06,09).png");
            this.imageCollection1.Images.SetKeyName(243, "(06,30).png");
            this.imageCollection1.Images.SetKeyName(244, "(06,37).png");
            this.imageCollection1.Images.SetKeyName(245, "(07,06).png");
            this.imageCollection1.Images.SetKeyName(246, "(07,21).png");
            this.imageCollection1.Images.SetKeyName(247, "(07,30).png");
            this.imageCollection1.Images.SetKeyName(248, "(08,31).png");
            this.imageCollection1.Images.SetKeyName(249, "(08,40).png");
            this.imageCollection1.Images.SetKeyName(250, "(09,09).png");
            this.imageCollection1.Images.SetKeyName(251, "(09,13).png");
            this.imageCollection1.Images.SetKeyName(252, "(09,21).png");
            this.imageCollection1.Images.SetKeyName(253, "(10,24).png");
            this.imageCollection1.Images.SetKeyName(254, "(10,49).png");
            this.imageCollection1.Images.SetKeyName(255, "(12,11).png");
            this.imageCollection1.Images.SetKeyName(256, "(12,42).png");
            this.imageCollection1.Images.SetKeyName(257, "(13,15).png");
            this.imageCollection1.Images.SetKeyName(258, "(13,49).png");
            this.imageCollection1.Images.SetKeyName(259, "(17,03).png");
            this.imageCollection1.Images.SetKeyName(260, "(17,46).png");
            this.imageCollection1.Images.SetKeyName(261, "(17,49).png");
            this.imageCollection1.Images.SetKeyName(262, "(18,13).png");
            this.imageCollection1.Images.SetKeyName(263, "(18,48).png");
            this.imageCollection1.Images.SetKeyName(264, "(19,01).png");
            this.imageCollection1.Images.SetKeyName(265, "(20,31).png");
            this.imageCollection1.Images.SetKeyName(266, "(22,04).png");
            this.imageCollection1.Images.SetKeyName(267, "(24,15).png");
            this.imageCollection1.Images.SetKeyName(268, "(27,15).png");
            this.imageCollection1.Images.SetKeyName(269, "(27,39).png");
            this.imageCollection1.Images.SetKeyName(270, "(28,09).png");
            this.imageCollection1.Images.SetKeyName(271, "(28,34).png");
            this.imageCollection1.Images.SetKeyName(272, "(29,04).png");
            this.imageCollection1.Images.SetKeyName(273, "(37,29).png");
            this.imageCollection1.Images.SetKeyName(274, "(37,34).png");
            this.imageCollection1.Images.SetKeyName(275, "(38,01).png");
            this.imageCollection1.Images.SetKeyName(276, "(39,47).png");
            this.imageCollection1.Images.SetKeyName(277, "(43,01).png");
            this.imageCollection1.Images.SetKeyName(278, "(43,02).png");
            this.imageCollection1.Images.SetKeyName(279, "(44,30).png");
            this.imageCollection1.Images.SetKeyName(280, "(46,25).png");
            this.imageCollection1.Images.SetKeyName(281, "(46,48).png");
            this.imageCollection1.Images.SetKeyName(282, "(47,01).png");
            this.imageCollection1.Images.SetKeyName(283, "(47,38).png");
            this.imageCollection1.Images.SetKeyName(284, "(48,48).png");
            this.imageCollection1.Images.SetKeyName(285, "(71).gif");
            this.imageCollection1.Images.SetKeyName(286, "(104).gif");
            this.imageCollection1.Images.SetKeyName(287, "(181).gif");
            this.imageCollection1.Images.SetKeyName(288, "(245).gif");
            this.imageCollection1.Images.SetKeyName(289, "(321).gif");
            this.imageCollection1.Images.SetKeyName(290, "(322).gif");
            this.imageCollection1.Images.SetKeyName(291, "(323).gif");
            this.imageCollection1.Images.SetKeyName(292, "(492).gif");
            this.imageCollection1.Images.SetKeyName(293, "(493).gif");
            this.imageCollection1.Images.SetKeyName(294, "(709).gif");
            this.imageCollection1.Images.SetKeyName(295, "help.png");
            this.imageCollection1.Images.SetKeyName(296, "information.png");
            this.imageCollection1.Images.SetKeyName(297, "application_view_gallery.png");
            this.imageCollection1.Images.SetKeyName(298, "application_view_tile.png");
            this.imageCollection1.Images.SetKeyName(299, "imac.png");
            this.imageCollection1.Images.SetKeyName(300, "image.png");
            this.imageCollection1.Images.SetKeyName(301, "image_add.png");
            this.imageCollection1.Images.SetKeyName(302, "image_delete.png");
            this.imageCollection1.Images.SetKeyName(303, "image_edit.png");
            // 
            // barButtonItemToolbox
            // 
            this.barButtonItemToolbox.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            this.barButtonItemToolbox.Caption = "工具箱";
            this.barButtonItemToolbox.Description = "工具箱";
            this.barButtonItemToolbox.Id = 2;
            this.barButtonItemToolbox.ImageIndex = 38;
            this.barButtonItemToolbox.Name = "barButtonItemToolbox";
            // 
            // barButtonItemToolView
            // 
            this.barButtonItemToolView.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            this.barButtonItemToolView.Caption = "最小化功能区";
            this.barButtonItemToolView.Description = "最小化功能区";
            this.barButtonItemToolView.Id = 3;
            this.barButtonItemToolView.ImageIndex = 47;
            this.barButtonItemToolView.Name = "barButtonItemToolView";
            // 
            // barButtonItemHelp
            // 
            this.barButtonItemHelp.Caption = "帮助";
            this.barButtonItemHelp.Id = 4;
            this.barButtonItemHelp.ImageIndex = 295;
            this.barButtonItemHelp.Name = "barButtonItemHelp";
            // 
            // barStaticItemInfo
            // 
            this.barStaticItemInfo.Caption = "信息";
            this.barStaticItemInfo.Id = 12;
            this.barStaticItemInfo.Name = "barStaticItemInfo";
            this.barStaticItemInfo.TextAlignment = System.Drawing.StringAlignment.Near;
            this.barStaticItemInfo.Width = 200;
            // 
            // barStaticItemLocation1
            // 
            this.barStaticItemLocation1.Caption = "经纬度                                     ";
            this.barStaticItemLocation1.Id = 13;
            this.barStaticItemLocation1.Name = "barStaticItemLocation1";
            this.barStaticItemLocation1.TextAlignment = System.Drawing.StringAlignment.Near;
            this.barStaticItemLocation1.Width = 200;
            // 
            // barStaticItemLocation2
            // 
            this.barStaticItemLocation2.Caption = "大地坐标";
            this.barStaticItemLocation2.Id = 14;
            this.barStaticItemLocation2.Name = "barStaticItemLocation2";
            this.barStaticItemLocation2.TextAlignment = System.Drawing.StringAlignment.Near;
            this.barStaticItemLocation2.Width = 220;
            // 
            // barStaticItemLocation3
            // 
            this.barStaticItemLocation3.Caption = "页面坐标";
            this.barStaticItemLocation3.Id = 15;
            this.barStaticItemLocation3.Name = "barStaticItemLocation3";
            this.barStaticItemLocation3.TextAlignment = System.Drawing.StringAlignment.Near;
            this.barStaticItemLocation3.Width = 200;
            // 
            // barStaticItemScale
            // 
            this.barStaticItemScale.Caption = "比例尺";
            this.barStaticItemScale.Id = 16;
            this.barStaticItemScale.Name = "barStaticItemScale";
            this.barStaticItemScale.TextAlignment = System.Drawing.StringAlignment.Near;
            this.barStaticItemScale.Width = 50;
            // 
            // barEditItemScale
            // 
            this.barEditItemScale.Edit = this.repositoryItemComboBox1;
            this.barEditItemScale.EditValue = "1:10000";
            this.barEditItemScale.Id = 17;
            this.barEditItemScale.Name = "barEditItemScale";
            this.barEditItemScale.Width = 100;
            // 
            // repositoryItemComboBox1
            // 
            this.repositoryItemComboBox1.AutoHeight = false;
            this.repositoryItemComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemComboBox1.Items.AddRange(new object[] {
            "1:500",
            "1:1000",
            "1:5000",
            "1:10000",
            "1:25000",
            "1:50000",
            "1:100000",
            "1:200000",
            "1:500000",
            "1:1000000",
            "1:5000000"});
            this.repositoryItemComboBox1.Name = "repositoryItemComboBox1";
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Caption = "barButtonItem2";
            this.barButtonItem2.Id = 18;
            this.barButtonItem2.ImageIndex = 218;
            this.barButtonItem2.LargeImageIndex = 35;
            this.barButtonItem2.Name = "barButtonItem2";
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "barButtonItem1";
            this.barButtonItem1.Id = 19;
            this.barButtonItem1.ImageIndex = 212;
            this.barButtonItem1.LargeImageIndex = 69;
            this.barButtonItem1.Name = "barButtonItem1";
            // 
            // imageCollection2
            // 
            this.imageCollection2.ImageSize = new System.Drawing.Size(32, 32);
            this.imageCollection2.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection2.ImageStream")));
            this.imageCollection2.Images.SetKeyName(0, "1263972323_Undo.png");
            this.imageCollection2.Images.SetKeyName(1, "1263972445_Redo.png");
            this.imageCollection2.Images.SetKeyName(2, "1263972353_edit-undo.png");
            this.imageCollection2.Images.SetKeyName(3, "application_view_gallery.png");
            this.imageCollection2.Images.SetKeyName(4, "application_view_icons.png");
            this.imageCollection2.Images.SetKeyName(5, "application_view_tile.png");
            this.imageCollection2.Images.SetKeyName(6, "applications.png");
            this.imageCollection2.Images.SetKeyName(7, "area_chart_32.png");
            this.imageCollection2.Images.SetKeyName(8, "book_edit.png");
            this.imageCollection2.Images.SetKeyName(9, "calendar_view_month.png");
            this.imageCollection2.Images.SetKeyName(10, "chart_bar.png");
            this.imageCollection2.Images.SetKeyName(11, "chart_pie.png");
            this.imageCollection2.Images.SetKeyName(12, "clock_red.png");
            this.imageCollection2.Images.SetKeyName(13, "color_swatch.png");
            this.imageCollection2.Images.SetKeyName(14, "cut.png");
            this.imageCollection2.Images.SetKeyName(15, "disk.png");
            this.imageCollection2.Images.SetKeyName(16, "door_out.png");
            this.imageCollection2.Images.SetKeyName(17, "eye.png");
            this.imageCollection2.Images.SetKeyName(18, "folder.png");
            this.imageCollection2.Images.SetKeyName(19, "folder_edit.png");
            this.imageCollection2.Images.SetKeyName(20, "folder_explore.png");
            this.imageCollection2.Images.SetKeyName(21, "folder_find.png");
            this.imageCollection2.Images.SetKeyName(22, "folder_image.png");
            this.imageCollection2.Images.SetKeyName(23, "folder_table.png");
            this.imageCollection2.Images.SetKeyName(24, "forward.png");
            this.imageCollection2.Images.SetKeyName(25, "gtk-execute32.png");
            this.imageCollection2.Images.SetKeyName(26, "hand32.png");
            this.imageCollection2.Images.SetKeyName(27, "hand32-2.png");
            this.imageCollection2.Images.SetKeyName(28, "help2.png");
            this.imageCollection2.Images.SetKeyName(29, "house.png");
            this.imageCollection2.Images.SetKeyName(30, "images.png");
            this.imageCollection2.Images.SetKeyName(31, "Info.png");
            this.imageCollection2.Images.SetKeyName(32, "info2.png");
            this.imageCollection2.Images.SetKeyName(33, "information.png");
            this.imageCollection2.Images.SetKeyName(34, "layers2.png");
            this.imageCollection2.Images.SetKeyName(35, "magnifier_zoom_in2.png");
            this.imageCollection2.Images.SetKeyName(36, "magnifier_zoom_out2.png");
            this.imageCollection2.Images.SetKeyName(37, "magnifier2.png");
            this.imageCollection2.Images.SetKeyName(38, "map_add.png");
            this.imageCollection2.Images.SetKeyName(39, "map_delete2.png");
            this.imageCollection2.Images.SetKeyName(40, "map_edit.png");
            this.imageCollection2.Images.SetKeyName(41, "map_go2.png");
            this.imageCollection2.Images.SetKeyName(42, "map_magnify.png");
            this.imageCollection2.Images.SetKeyName(43, "map3.png");
            this.imageCollection2.Images.SetKeyName(44, "misc_17.png");
            this.imageCollection2.Images.SetKeyName(45, "misc_18.png");
            this.imageCollection2.Images.SetKeyName(46, "misc_55.png");
            this.imageCollection2.Images.SetKeyName(47, "objects_32.png");
            this.imageCollection2.Images.SetKeyName(48, "page_copy.png");
            this.imageCollection2.Images.SetKeyName(49, "page_edit.png");
            this.imageCollection2.Images.SetKeyName(50, "page_find.png");
            this.imageCollection2.Images.SetKeyName(51, "page_paste.png");
            this.imageCollection2.Images.SetKeyName(52, "page_white_edit.png");
            this.imageCollection2.Images.SetKeyName(53, "page_white_magnify.png");
            this.imageCollection2.Images.SetKeyName(54, "page_white_world.png");
            this.imageCollection2.Images.SetKeyName(55, "pathing.png");
            this.imageCollection2.Images.SetKeyName(56, "photos.png");
            this.imageCollection2.Images.SetKeyName(57, "pictures.png");
            this.imageCollection2.Images.SetKeyName(58, "pie_chart_32.png");
            this.imageCollection2.Images.SetKeyName(59, "report_magnify.png");
            this.imageCollection2.Images.SetKeyName(60, "scissors_32.png");
            this.imageCollection2.Images.SetKeyName(61, "Spotlight.png");
            this.imageCollection2.Images.SetKeyName(62, "stock_draw-polygon.png");
            this.imageCollection2.Images.SetKeyName(63, "stock_draw-polygon-45.png");
            this.imageCollection2.Images.SetKeyName(64, "stock_draw-polygon-45-filled.png");
            this.imageCollection2.Images.SetKeyName(65, "stock_draw-polygon-filled.png");
            this.imageCollection2.Images.SetKeyName(66, "stock_edit-points.png");
            this.imageCollection2.Images.SetKeyName(67, "web design_32_hot.png");
            this.imageCollection2.Images.SetKeyName(68, "Windows.png");
            this.imageCollection2.Images.SetKeyName(69, "world_32.png");
            this.imageCollection2.Images.SetKeyName(70, "ksirtet.png");
            this.imageCollection2.Images.SetKeyName(71, "Network%20Connection%20Manager—2.png");
            this.imageCollection2.Images.SetKeyName(72, "line-globe.png");
            this.imageCollection2.Images.SetKeyName(73, "drawing_pen-32.png");
            this.imageCollection2.Images.SetKeyName(74, "hand.png");
            this.imageCollection2.Images.SetKeyName(75, "zoom.png");
            this.imageCollection2.Images.SetKeyName(76, "hand_finger.png");
            this.imageCollection2.Images.SetKeyName(77, "icontexto-green-01.png");
            this.imageCollection2.Images.SetKeyName(78, "notebook-edit.png");
            this.imageCollection2.Images.SetKeyName(79, "bookmarks-edit.png");
            this.imageCollection2.Images.SetKeyName(80, "tree2.png");
            this.imageCollection2.Images.SetKeyName(81, "monitor_edit.png");
            this.imageCollection2.Images.SetKeyName(82, "tree_1.png");
            this.imageCollection2.Images.SetKeyName(83, "google_custom_search.png");
            this.imageCollection2.Images.SetKeyName(84, "table_tab_search.png");
            this.imageCollection2.Images.SetKeyName(85, "Safari-alt2.png");
            this.imageCollection2.Images.SetKeyName(86, "globe%20yellow.png");
            this.imageCollection2.Images.SetKeyName(87, "globe%20green.png");
            this.imageCollection2.Images.SetKeyName(88, "world_go.png");
            this.imageCollection2.Images.SetKeyName(89, "globe_model.png");
            this.imageCollection2.Images.SetKeyName(90, "world_add.png");
            this.imageCollection2.Images.SetKeyName(91, "world3.png");
            this.imageCollection2.Images.SetKeyName(92, "world_delete.png");
            this.imageCollection2.Images.SetKeyName(93, "world_edit.png");
            this.imageCollection2.Images.SetKeyName(94, "web2.png");
            this.imageCollection2.Images.SetKeyName(95, "package_network.png");
            this.imageCollection2.Images.SetKeyName(96, "misc_53.png");
            this.imageCollection2.Images.SetKeyName(97, "misc_55.png");
            this.imageCollection2.Images.SetKeyName(98, "zoom%20out.png");
            this.imageCollection2.Images.SetKeyName(99, "Search%20Remove.png");
            this.imageCollection2.Images.SetKeyName(100, "Search%20Add.png");
            this.imageCollection2.Images.SetKeyName(101, "hand-tool.png");
            this.imageCollection2.Images.SetKeyName(102, "system-run-32-2.png");
            this.imageCollection2.Images.SetKeyName(103, "world.png");
            this.imageCollection2.Images.SetKeyName(104, "find.png");
            this.imageCollection2.Images.SetKeyName(105, "zoom%20in.png");
            this.imageCollection2.Images.SetKeyName(106, "plus_32.png");
            this.imageCollection2.Images.SetKeyName(107, "clipboard_32.png");
            this.imageCollection2.Images.SetKeyName(108, "print_32.png");
            this.imageCollection2.Images.SetKeyName(109, "pencil_32.png");
            this.imageCollection2.Images.SetKeyName(110, "flag_32.png");
            this.imageCollection2.Images.SetKeyName(111, "Gnome-Edit-Undo-32.png");
            this.imageCollection2.Images.SetKeyName(112, "Gnome-Edit-Redo-32.png");
            this.imageCollection2.Images.SetKeyName(113, "img-portrait-edit.png");
            this.imageCollection2.Images.SetKeyName(114, "search_32.png");
            this.imageCollection2.Images.SetKeyName(115, "search_chart.png");
            this.imageCollection2.Images.SetKeyName(116, "tree.png");
            this.imageCollection2.Images.SetKeyName(117, "Hyperlink-Internet-Search-32.png");
            this.imageCollection2.Images.SetKeyName(118, "x-office-drawing.png");
            this.imageCollection2.Images.SetKeyName(119, "Move2Red.png");
            this.imageCollection2.Images.SetKeyName(120, "application_side_contract.png");
            this.imageCollection2.Images.SetKeyName(121, "application_side_expand.png");
            this.imageCollection2.Images.SetKeyName(122, "application_tile_horizontal.png");
            this.imageCollection2.Images.SetKeyName(123, "application_view_gallery.png");
            this.imageCollection2.Images.SetKeyName(124, "application_view_icons.png");
            this.imageCollection2.Images.SetKeyName(125, "areachart.png");
            this.imageCollection2.Images.SetKeyName(126, "artwork.png");
            this.imageCollection2.Images.SetKeyName(127, "blogs.png");
            this.imageCollection2.Images.SetKeyName(128, "building_edit.png");
            this.imageCollection2.Images.SetKeyName(129, "calendar.png");
            this.imageCollection2.Images.SetKeyName(130, "calendar_add.png");
            this.imageCollection2.Images.SetKeyName(131, "calendar_delete.png");
            this.imageCollection2.Images.SetKeyName(132, "calendar_edit.png");
            this.imageCollection2.Images.SetKeyName(133, "calendar_view_month.png");
            this.imageCollection2.Images.SetKeyName(134, "canvas.png");
            this.imageCollection2.Images.SetKeyName(135, "canvas_size.png");
            this.imageCollection2.Images.SetKeyName(136, "chart_bullseye.png");
            this.imageCollection2.Images.SetKeyName(137, "chart_curve.png");
            this.imageCollection2.Images.SetKeyName(138, "chart_curve_add.png");
            this.imageCollection2.Images.SetKeyName(139, "chart_curve_delete.png");
            this.imageCollection2.Images.SetKeyName(140, "chart_curve_edit.png");
            this.imageCollection2.Images.SetKeyName(141, "chart_line.png");
            this.imageCollection2.Images.SetKeyName(142, "chart_line_add.png");
            this.imageCollection2.Images.SetKeyName(143, "chart_line_delete.png");
            this.imageCollection2.Images.SetKeyName(144, "chart_line_edit.png");
            this.imageCollection2.Images.SetKeyName(145, "chart_pie.png");
            this.imageCollection2.Images.SetKeyName(146, "chart_pie_edit.png");
            this.imageCollection2.Images.SetKeyName(147, "chart_stock.png");
            this.imageCollection2.Images.SetKeyName(148, "cog_edit.png");
            this.imageCollection2.Images.SetKeyName(149, "color_swatch.png");
            this.imageCollection2.Images.SetKeyName(150, "column_one.png");
            this.imageCollection2.Images.SetKeyName(151, "computer_edit.png");
            this.imageCollection2.Images.SetKeyName(152, "cursor.png");
            this.imageCollection2.Images.SetKeyName(153, "cut.png");
            this.imageCollection2.Images.SetKeyName(154, "cut_red.png");
            this.imageCollection2.Images.SetKeyName(155, "data_table.png");
            this.imageCollection2.Images.SetKeyName(156, "disk.png");
            this.imageCollection2.Images.SetKeyName(157, "distribution_partnerships.png");
            this.imageCollection2.Images.SetKeyName(158, "document_comment_above.png");
            this.imageCollection2.Images.SetKeyName(159, "document_comments.png");
            this.imageCollection2.Images.SetKeyName(160, "document_copies.png");
            this.imageCollection2.Images.SetKeyName(161, "document_editing.png");
            this.imageCollection2.Images.SetKeyName(162, "document_font.png");
            this.imageCollection2.Images.SetKeyName(163, "document_info.png");
            this.imageCollection2.Images.SetKeyName(164, "document_image.png");
            this.imageCollection2.Images.SetKeyName(165, "document_image_hor.png");
            this.imageCollection2.Images.SetKeyName(166, "document_image_ver.png");
            this.imageCollection2.Images.SetKeyName(167, "document_insert.png");
            this.imageCollection2.Images.SetKeyName(168, "document_inspect.png");
            this.imageCollection2.Images.SetKeyName(169, "document_inspector.png");
            this.imageCollection2.Images.SetKeyName(170, "document_layout.png");
            this.imageCollection2.Images.SetKeyName(171, "document_margins.png");
            this.imageCollection2.Images.SetKeyName(172, "document_next.png");
            this.imageCollection2.Images.SetKeyName(173, "document_notes.png");
            this.imageCollection2.Images.SetKeyName(174, "document_prepare.png");
            this.imageCollection2.Images.SetKeyName(175, "document_split.png");
            this.imageCollection2.Images.SetKeyName(176, "domain_template.png");
            this.imageCollection2.Images.SetKeyName(177, "door_in.png");
            this.imageCollection2.Images.SetKeyName(178, "door_out.png");
            this.imageCollection2.Images.SetKeyName(179, "download.png");
            this.imageCollection2.Images.SetKeyName(180, "draw_ellipse.png");
            this.imageCollection2.Images.SetKeyName(181, "draw_island.png");
            this.imageCollection2.Images.SetKeyName(182, "draw_path.png");
            this.imageCollection2.Images.SetKeyName(183, "draw_vertex.png");
            this.imageCollection2.Images.SetKeyName(184, "draw_wave.png");
            this.imageCollection2.Images.SetKeyName(185, "edit_diff.png");
            this.imageCollection2.Images.SetKeyName(186, "edit_path.png");
            this.imageCollection2.Images.SetKeyName(187, "fire.png");
            this.imageCollection2.Images.SetKeyName(188, "flickr.png");
            this.imageCollection2.Images.SetKeyName(189, "folder_edit.png");
            this.imageCollection2.Images.SetKeyName(190, "folder_explore.png");
            this.imageCollection2.Images.SetKeyName(191, "folder_find.png");
            this.imageCollection2.Images.SetKeyName(192, "folder_image.png");
            this.imageCollection2.Images.SetKeyName(193, "folder_picture.png");
            this.imageCollection2.Images.SetKeyName(194, "folder_table.png");
            this.imageCollection2.Images.SetKeyName(195, "folder_wrench.png");
            this.imageCollection2.Images.SetKeyName(196, "font.png");
            this.imageCollection2.Images.SetKeyName(197, "font_colors.png");
            this.imageCollection2.Images.SetKeyName(198, "ftp.png");
            this.imageCollection2.Images.SetKeyName(199, "georectify.png");
            this.imageCollection2.Images.SetKeyName(200, "google_custom_search.png");
            this.imageCollection2.Images.SetKeyName(201, "google_map.png");
            this.imageCollection2.Images.SetKeyName(202, "google_webmaster_tools.png");
            this.imageCollection2.Images.SetKeyName(203, "grass.png");
            this.imageCollection2.Images.SetKeyName(204, "green.png");
            this.imageCollection2.Images.SetKeyName(205, "hammer.png");
            this.imageCollection2.Images.SetKeyName(206, "hdividedbox.png");
            this.imageCollection2.Images.SetKeyName(207, "help.png");
            this.imageCollection2.Images.SetKeyName(208, "information.png");
            this.imageCollection2.Images.SetKeyName(209, "house.png");
            this.imageCollection2.Images.SetKeyName(210, "image.png");
            this.imageCollection2.Images.SetKeyName(211, "images.png");
            this.imageCollection2.Images.SetKeyName(212, "insert_element.png");
            this.imageCollection2.Images.SetKeyName(213, "investment_menu_quality.png");
            this.imageCollection2.Images.SetKeyName(214, "large_tiles.png");
            this.imageCollection2.Images.SetKeyName(215, "layer.png");
            this.imageCollection2.Images.SetKeyName(216, "layer_add.png");
            this.imageCollection2.Images.SetKeyName(217, "layer_aspect_arrow.png");
            this.imageCollection2.Images.SetKeyName(218, "layer_chart.png");
            this.imageCollection2.Images.SetKeyName(219, "layer_database.png");
            this.imageCollection2.Images.SetKeyName(220, "layer_delete.png");
            this.imageCollection2.Images.SetKeyName(221, "layer_edit.png");
            this.imageCollection2.Images.SetKeyName(222, "layer_export.png");
            this.imageCollection2.Images.SetKeyName(223, "layer_group.png");
            this.imageCollection2.Images.SetKeyName(224, "layer_his.png");
            this.imageCollection2.Images.SetKeyName(225, "layer_import.png");
            this.imageCollection2.Images.SetKeyName(226, "layer_label.png");
            this.imageCollection2.Images.SetKeyName(227, "layer_open.png");
            this.imageCollection2.Images.SetKeyName(228, "layer_raster.png");
            this.imageCollection2.Images.SetKeyName(229, "layer_raster_3d.png");
            this.imageCollection2.Images.SetKeyName(230, "layer_redraw.png");
            this.imageCollection2.Images.SetKeyName(231, "layer_remove.png");
            this.imageCollection2.Images.SetKeyName(232, "layer_rgb.png");
            this.imageCollection2.Images.SetKeyName(233, "layer_to_image_size.png");
            this.imageCollection2.Images.SetKeyName(234, "layer_vector.png");
            this.imageCollection2.Images.SetKeyName(235, "layer_wms.png");
            this.imageCollection2.Images.SetKeyName(236, "layers.png");
            this.imageCollection2.Images.SetKeyName(237, "layers_map.png");
            this.imageCollection2.Images.SetKeyName(238, "layout.png");
            this.imageCollection2.Images.SetKeyName(239, "layout_add.png");
            this.imageCollection2.Images.SetKeyName(240, "layout_content.png");
            this.imageCollection2.Images.SetKeyName(241, "layout_delete.png");
            this.imageCollection2.Images.SetKeyName(242, "layout_edit.png");
            this.imageCollection2.Images.SetKeyName(243, "layout_header.png");
            this.imageCollection2.Images.SetKeyName(244, "legend.png");
            this.imageCollection2.Images.SetKeyName(245, "line_split.png");
            this.imageCollection2.Images.SetKeyName(246, "linechart.png");
            this.imageCollection2.Images.SetKeyName(247, "measure.png");
            this.imageCollection2.Images.SetKeyName(248, "measure_crop.png");
            this.imageCollection2.Images.SetKeyName(249, "messenger.png");
            this.imageCollection2.Images.SetKeyName(250, "monitor_edit.png");
            this.imageCollection2.Images.SetKeyName(251, "move_to_folder.png");
            this.imageCollection2.Images.SetKeyName(252, "node-tree.png");
            this.imageCollection2.Images.SetKeyName(253, "note_edit.png");
            this.imageCollection2.Images.SetKeyName(254, "orbit.png");
            this.imageCollection2.Images.SetKeyName(255, "page_refresh.png");
            this.imageCollection2.Images.SetKeyName(256, "pencil.png");
            this.imageCollection2.Images.SetKeyName(257, "pencil_add.png");
            this.imageCollection2.Images.SetKeyName(258, "pencil_delete.png");
            this.imageCollection2.Images.SetKeyName(259, "pencil_go.png");
            this.imageCollection2.Images.SetKeyName(260, "photo.png");
            this.imageCollection2.Images.SetKeyName(261, "photo_add.png");
            this.imageCollection2.Images.SetKeyName(262, "photo_delete.png");
            this.imageCollection2.Images.SetKeyName(263, "photos.png");
            this.imageCollection2.Images.SetKeyName(264, "picture.png");
            this.imageCollection2.Images.SetKeyName(265, "picture_add.png");
            this.imageCollection2.Images.SetKeyName(266, "picture_delete.png");
            this.imageCollection2.Images.SetKeyName(267, "picture_edit.png");
            this.imageCollection2.Images.SetKeyName(268, "picture_empty.png");
            this.imageCollection2.Images.SetKeyName(269, "pictures.png");
            this.imageCollection2.Images.SetKeyName(270, "piechart.png");
            this.imageCollection2.Images.SetKeyName(271, "Plant.png");
            this.imageCollection2.Images.SetKeyName(272, "plotchart.png");
            this.imageCollection2.Images.SetKeyName(273, "plugin_delete.png");
            this.imageCollection2.Images.SetKeyName(274, "plugin_edit.png");
            this.imageCollection2.Images.SetKeyName(275, "plugin_go.png");
            this.imageCollection2.Images.SetKeyName(276, "print_size.png");
            this.imageCollection2.Images.SetKeyName(277, "resize_picture.png");
            this.imageCollection2.Images.SetKeyName(278, "resource_usage.png");
            this.imageCollection2.Images.SetKeyName(279, "resources.png");
            this.imageCollection2.Images.SetKeyName(280, "richtext_editor.png");
            this.imageCollection2.Images.SetKeyName(281, "sallary_deferrais.png");
            this.imageCollection2.Images.SetKeyName(282, "scale_image.png");
            this.imageCollection2.Images.SetKeyName(283, "script_edit.png");
            this.imageCollection2.Images.SetKeyName(284, "select.png");
            this.imageCollection2.Images.SetKeyName(285, "select_by_adding_to_selection.png");
            this.imageCollection2.Images.SetKeyName(286, "select_by_color.png");
            this.imageCollection2.Images.SetKeyName(287, "select_by_difference.png");
            this.imageCollection2.Images.SetKeyName(288, "select_by_intersection.png");
            this.imageCollection2.Images.SetKeyName(289, "server_components.png");
            this.imageCollection2.Images.SetKeyName(290, "setting_tools.png");
            this.imageCollection2.Images.SetKeyName(291, "shading.png");
            this.imageCollection2.Images.SetKeyName(292, "shape_group.png");
            this.imageCollection2.Images.SetKeyName(293, "shape_handles.png");
            this.imageCollection2.Images.SetKeyName(294, "shape_move_back.png");
            this.imageCollection2.Images.SetKeyName(295, "shape_move_backwards.png");
            this.imageCollection2.Images.SetKeyName(296, "shape_move_forwards.png");
            this.imageCollection2.Images.SetKeyName(297, "shape_move_front.png");
            this.imageCollection2.Images.SetKeyName(298, "shape_square_add.png");
            this.imageCollection2.Images.SetKeyName(299, "shape_square_delete.png");
            this.imageCollection2.Images.SetKeyName(300, "shape_square_edit.png");
            this.imageCollection2.Images.SetKeyName(301, "shape_square_go.png");
            this.imageCollection2.Images.SetKeyName(302, "shape_ungroup.png");
            this.imageCollection2.Images.SetKeyName(303, "sharpen.png");
            this.imageCollection2.Images.SetKeyName(304, "snow_rain.png");
            this.imageCollection2.Images.SetKeyName(305, "soil_layers.png");
            this.imageCollection2.Images.SetKeyName(306, "sql_join_inner.png");
            this.imageCollection2.Images.SetKeyName(307, "sql_join_left.png");
            this.imageCollection2.Images.SetKeyName(308, "sql_join_outer.png");
            this.imageCollection2.Images.SetKeyName(309, "sql_join_outer_exclude.png");
            this.imageCollection2.Images.SetKeyName(310, "storage.png");
            this.imageCollection2.Images.SetKeyName(311, "style.png");
            this.imageCollection2.Images.SetKeyName(312, "sun_cloudy.png");
            this.imageCollection2.Images.SetKeyName(313, "sun_rain.png");
            this.imageCollection2.Images.SetKeyName(314, "swf_loader.png");
            this.imageCollection2.Images.SetKeyName(315, "table.png");
            this.imageCollection2.Images.SetKeyName(316, "table_add.png");
            this.imageCollection2.Images.SetKeyName(317, "table_delete.png");
            this.imageCollection2.Images.SetKeyName(318, "table_excel.png");
            this.imageCollection2.Images.SetKeyName(319, "table_go.png");
            this.imageCollection2.Images.SetKeyName(320, "table_heatmap.png");
            this.imageCollection2.Images.SetKeyName(321, "table_import.png");
            this.imageCollection2.Images.SetKeyName(322, "table_insert.png");
            this.imageCollection2.Images.SetKeyName(323, "table_multiple.png");
            this.imageCollection2.Images.SetKeyName(324, "table_refresh.png");
            this.imageCollection2.Images.SetKeyName(325, "tag_blue_add.png");
            this.imageCollection2.Images.SetKeyName(326, "tag_blue_edit.png");
            this.imageCollection2.Images.SetKeyName(327, "tag_green.png");
            this.imageCollection2.Images.SetKeyName(328, "tag_purple.png");
            this.imageCollection2.Images.SetKeyName(329, "text_signature.png");
            this.imageCollection2.Images.SetKeyName(330, "to_do_list.png");
            this.imageCollection2.Images.SetKeyName(331, "to_do_list_cheked_1.png");
            this.imageCollection2.Images.SetKeyName(332, "to_do_list_cheked_all.png");
            this.imageCollection2.Images.SetKeyName(333, "transform_crop.png");
            this.imageCollection2.Images.SetKeyName(334, "transform_flip.png");
            this.imageCollection2.Images.SetKeyName(335, "transform_layer.png");
            this.imageCollection2.Images.SetKeyName(336, "transform_move.png");
            this.imageCollection2.Images.SetKeyName(337, "transform_rotate.png");
            this.imageCollection2.Images.SetKeyName(338, "transform_selection.png");
            this.imageCollection2.Images.SetKeyName(339, "tree.png");
            this.imageCollection2.Images.SetKeyName(340, "update.png");
            this.imageCollection2.Images.SetKeyName(341, "vector.png");
            this.imageCollection2.Images.SetKeyName(342, "vector_add.png");
            this.imageCollection2.Images.SetKeyName(343, "vector_delete.png");
            this.imageCollection2.Images.SetKeyName(344, "viewstack.png");
            this.imageCollection2.Images.SetKeyName(345, "widgets.png");
            this.imageCollection2.Images.SetKeyName(346, "workspace.png");
            this.imageCollection2.Images.SetKeyName(347, "world.png");
            this.imageCollection2.Images.SetKeyName(348, "world_add.png");
            this.imageCollection2.Images.SetKeyName(349, "world_edit.png");
            this.imageCollection2.Images.SetKeyName(350, "world_go.png");
            this.imageCollection2.Images.SetKeyName(351, "wrench_orange.png");
            this.imageCollection2.Images.SetKeyName(352, "zoom.png");
            this.imageCollection2.Images.SetKeyName(353, "zoom_extend.png");
            this.imageCollection2.Images.SetKeyName(354, "zoom_refresh.png");
            this.imageCollection2.Images.SetKeyName(355, "Developpers_Icons_021.png");
            this.imageCollection2.Images.SetKeyName(356, "Developpers_Icons_023.png");
            this.imageCollection2.Images.SetKeyName(357, "Developpers_Icons_029.png");
            this.imageCollection2.Images.SetKeyName(358, "Developpers_Icons_041.png");
            this.imageCollection2.Images.SetKeyName(359, "Developpers_Icons_043.png");
            this.imageCollection2.Images.SetKeyName(360, "Developpers_Icons_062.png");
            this.imageCollection2.Images.SetKeyName(361, "Developpers_Icons_074.png");
            this.imageCollection2.Images.SetKeyName(362, "Developpers_Icons_077.png");
            this.imageCollection2.Images.SetKeyName(363, "Developpers_Icons_093.png");
            this.imageCollection2.Images.SetKeyName(364, "Developpers_Icons_094.png");
            this.imageCollection2.Images.SetKeyName(365, "Developpers_Icons_103.png");
            this.imageCollection2.Images.SetKeyName(366, "document_edit.png");
            this.imageCollection2.Images.SetKeyName(367, "edit.png");
            this.imageCollection2.Images.SetKeyName(368, "Feedicons_v2_043.png");
            this.imageCollection2.Images.SetKeyName(369, "Feedicons_v2_044.png");
            this.imageCollection2.Images.SetKeyName(370, "Feedicons_v2_054.png");
            this.imageCollection2.Images.SetKeyName(371, "Feedicons_v2_062.png");
            this.imageCollection2.Images.SetKeyName(372, "Kombine_toolbar_007.png");
            this.imageCollection2.Images.SetKeyName(373, "Kombine_toolbar_014.png");
            this.imageCollection2.Images.SetKeyName(374, "Kombine_toolbar_022.png");
            this.imageCollection2.Images.SetKeyName(375, "Kombine_toolbar_025.png");
            this.imageCollection2.Images.SetKeyName(376, "Kombine_toolbar_028.png");
            this.imageCollection2.Images.SetKeyName(377, "Kombine_toolbar_039.png");
            this.imageCollection2.Images.SetKeyName(378, "Kombine_toolbar_040.png");
            this.imageCollection2.Images.SetKeyName(379, "Kombine_toolbar_044.png");
            this.imageCollection2.Images.SetKeyName(380, "Kombine_toolbar_045.png");
            this.imageCollection2.Images.SetKeyName(381, "picture.png");
            this.imageCollection2.Images.SetKeyName(382, "picture_edit.png");
            this.imageCollection2.Images.SetKeyName(383, "picture_zoom.png");
            this.imageCollection2.Images.SetKeyName(384, "pictures.png");
            this.imageCollection2.Images.SetKeyName(385, "zoom in.png");
            this.imageCollection2.Images.SetKeyName(386, "zoom out.png");
            this.imageCollection2.Images.SetKeyName(387, "zoom.png");
            // 
            // ribbonPageDataEdit
            // 
            this.ribbonPageDataEdit.ImageIndex = 3;
            this.ribbonPageDataEdit.Name = "ribbonPageDataEdit";
            this.ribbonPageDataEdit.Text = "编辑";
            // 
            // ribbonPageCheck
            // 
            this.ribbonPageCheck.ImageIndex = 57;
            this.ribbonPageCheck.Name = "ribbonPageCheck";
            this.ribbonPageCheck.Text = "校验";
            // 
            // ribbonPageQuery
            // 
            this.ribbonPageQuery.ImageIndex = 29;
            this.ribbonPageQuery.Name = "ribbonPageQuery";
            this.ribbonPageQuery.Text = "查询";
            // 
            // ribbonPageGraphics
            // 
            this.ribbonPageGraphics.ImageIndex = 68;
            this.ribbonPageGraphics.Name = "ribbonPageGraphics";
            this.ribbonPageGraphics.Text = "制图";
            // 
            // ribbonPageTransfer
            // 
            this.ribbonPageTransfer.ImageIndex = 117;
            this.ribbonPageTransfer.Name = "ribbonPageTransfer";
            this.ribbonPageTransfer.Text = "传输";
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.ItemLinks.Add(this.barStaticItemInfo);
            this.ribbonStatusBar.ItemLinks.Add(this.barStaticItemLocation1);
            this.ribbonStatusBar.ItemLinks.Add(this.barStaticItemLocation2);
            this.ribbonStatusBar.ItemLinks.Add(this.barStaticItemLocation3);
            this.ribbonStatusBar.ItemLinks.Add(this.barStaticItemScale);
            this.ribbonStatusBar.ItemLinks.Add(this.barEditItemScale);
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 736);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbon;
            this.ribbonStatusBar.Size = new System.Drawing.Size(1016, 31);
            // 
            // defaultLookAndFeel1
            // 
            this.defaultLookAndFeel1.LookAndFeel.SkinName = "Blue";
            // 
            // dockManager1
            // 
            this.dockManager1.Form = this;
            this.dockManager1.HiddenPanels.AddRange(new DevExpress.XtraBars.Docking.DockPanel[] {
            this.dockPanelEdit,
            this.dockPanelBottom});
            this.dockManager1.MenuManager = this.barManager1;
            this.dockManager1.RootPanels.AddRange(new DevExpress.XtraBars.Docking.DockPanel[] {
            this.dockPanelToolbox});
            this.dockManager1.TopZIndexControls.AddRange(new string[] {
            "DevExpress.XtraBars.BarDockControl",
            "DevExpress.XtraBars.StandaloneBarDockControl",
            "System.Windows.Forms.StatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonStatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonControl"});
            // 
            // dockPanelEdit
            // 
            this.dockPanelEdit.Controls.Add(this.dockPanelEdit_Container);
            this.dockPanelEdit.Dock = DevExpress.XtraBars.Docking.DockingStyle.Right;
            this.dockPanelEdit.ID = new System.Guid("5005221a-95a9-4f31-936a-00edf4bf9451");
            this.dockPanelEdit.Location = new System.Drawing.Point(816, 153);
            this.dockPanelEdit.Name = "dockPanelEdit";
            this.dockPanelEdit.OriginalSize = new System.Drawing.Size(200, 200);
            this.dockPanelEdit.SavedDock = DevExpress.XtraBars.Docking.DockingStyle.Right;
            this.dockPanelEdit.SavedIndex = 0;
            this.dockPanelEdit.Size = new System.Drawing.Size(400, 570);
            this.dockPanelEdit.Text = "编辑工具";
            this.dockPanelEdit.Visibility = DevExpress.XtraBars.Docking.DockVisibility.Hidden;
            // 
            // dockPanelEdit_Container
            // 
            this.dockPanelEdit_Container.Location = new System.Drawing.Point(3, 29);
            this.dockPanelEdit_Container.Name = "dockPanelEdit_Container";
            this.dockPanelEdit_Container.Size = new System.Drawing.Size(194, 538);
            this.dockPanelEdit_Container.TabIndex = 0;
            // 
            // dockPanelBottom
            // 
            this.dockPanelBottom.Controls.Add(this.dockPanelBottom_Container);
            this.dockPanelBottom.Dock = DevExpress.XtraBars.Docking.DockingStyle.Bottom;
            this.dockPanelBottom.FloatVertical = true;
            this.dockPanelBottom.ID = new System.Guid("b19474b6-5f2e-45e7-bf89-14075560a1cc");
            this.dockPanelBottom.Location = new System.Drawing.Point(259, 543);
            this.dockPanelBottom.Name = "dockPanelBottom";
            this.dockPanelBottom.OriginalSize = new System.Drawing.Size(200, 200);
            this.dockPanelBottom.SavedDock = DevExpress.XtraBars.Docking.DockingStyle.Bottom;
            this.dockPanelBottom.SavedIndex = 1;
            this.dockPanelBottom.Size = new System.Drawing.Size(757, 200);
            this.dockPanelBottom.Text = "查询";
            this.dockPanelBottom.Visibility = DevExpress.XtraBars.Docking.DockVisibility.Hidden;
            // 
            // dockPanelBottom_Container
            // 
            this.dockPanelBottom_Container.Location = new System.Drawing.Point(3, 29);
            this.dockPanelBottom_Container.Name = "dockPanelBottom_Container";
            this.dockPanelBottom_Container.Size = new System.Drawing.Size(751, 168);
            this.dockPanelBottom_Container.TabIndex = 0;
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar1,
            this.bar2,
            this.bar3});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.DockManager = this.dockManager1;
            this.barManager1.Form = this.panelFull;
            this.barManager1.Images = this.imageCollection1;
            this.barManager1.LargeImages = this.imageCollection2;
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 1;
            this.barManager1.StatusBar = this.bar3;
            // 
            // bar1
            // 
            this.bar1.BarName = "Tools";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Left;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem2),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem1)});
            this.bar1.Text = "Tools";
            // 
            // bar2
            // 
            this.bar2.BarName = "Main menu";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            this.bar2.Visible = false;
            // 
            // bar3
            // 
            this.bar3.BarName = "Status bar";
            this.bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.bar3.DockCol = 0;
            this.bar3.DockRow = 0;
            this.bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.bar3.OptionsBar.AllowQuickCustomization = false;
            this.bar3.OptionsBar.DrawDragBorder = false;
            this.bar3.OptionsBar.UseWholeRow = true;
            this.bar3.Text = "Status bar";
            this.bar3.Visible = false;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(757, 20);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 564);
            this.barDockControlBottom.Size = new System.Drawing.Size(757, 23);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 20);
            this.barDockControlLeft.Size = new System.Drawing.Size(35, 544);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(757, 20);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 544);
            // 
            // panelFull
            // 
            this.panelFull.Controls.Add(this.xtraTabMain);
            this.panelFull.Controls.Add(this.barDockControlLeft);
            this.panelFull.Controls.Add(this.barDockControlRight);
            this.panelFull.Controls.Add(this.barDockControlBottom);
            this.panelFull.Controls.Add(this.barDockControlTop);
            this.panelFull.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFull.Location = new System.Drawing.Point(259, 149);
            this.panelFull.Name = "panelFull";
            this.panelFull.Size = new System.Drawing.Size(757, 587);
            this.panelFull.TabIndex = 13;
            // 
            // xtraTabMain
            // 
            this.xtraTabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabMain.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Bottom;
            this.xtraTabMain.Images = this.imageCollection1;
            this.xtraTabMain.Location = new System.Drawing.Point(35, 20);
            this.xtraTabMain.Name = "xtraTabMain";
            this.xtraTabMain.SelectedTabPage = this.tabPageMapContol;
            this.xtraTabMain.Size = new System.Drawing.Size(722, 544);
            this.xtraTabMain.TabIndex = 3;
            this.xtraTabMain.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tabPageMapContol,
            this.tabPagePagelayoutContol});
            // 
            // tabPageMapContol
            // 
            this.tabPageMapContol.Controls.Add(this.MapControlEdit);
            this.tabPageMapContol.Controls.Add(this.axLicenseControl1);
            this.tabPageMapContol.ImageIndex = 294;
            this.tabPageMapContol.Name = "tabPageMapContol";
            this.tabPageMapContol.Size = new System.Drawing.Size(716, 513);
            this.tabPageMapContol.Text = "地图";
            // 
            // MapControlEdit
            // 
            this.MapControlEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MapControlEdit.Location = new System.Drawing.Point(0, 0);
            this.MapControlEdit.Name = "MapControlEdit";
            this.MapControlEdit.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("MapControlEdit.OcxState")));
            this.MapControlEdit.Size = new System.Drawing.Size(716, 513);
            this.MapControlEdit.TabIndex = 0;
            // 
            // axLicenseControl1
            // 
            this.axLicenseControl1.Enabled = true;
            this.axLicenseControl1.Location = new System.Drawing.Point(0, 0);
            this.axLicenseControl1.Name = "axLicenseControl1";
            this.axLicenseControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axLicenseControl1.OcxState")));
            this.axLicenseControl1.Size = new System.Drawing.Size(32, 32);
            this.axLicenseControl1.TabIndex = 1;
            // 
            // tabPagePagelayoutContol
            // 
            this.tabPagePagelayoutContol.Controls.Add(this.PageLayoutControlEdit);
            this.tabPagePagelayoutContol.ImageIndex = 183;
            this.tabPagePagelayoutContol.Name = "tabPagePagelayoutContol";
            this.tabPagePagelayoutContol.Size = new System.Drawing.Size(716, 505);
            this.tabPagePagelayoutContol.Text = "出版";
            // 
            // PageLayoutControlEdit
            // 
            this.PageLayoutControlEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PageLayoutControlEdit.Location = new System.Drawing.Point(0, 0);
            this.PageLayoutControlEdit.Name = "PageLayoutControlEdit";
            this.PageLayoutControlEdit.Size = new System.Drawing.Size(716, 505);
            this.PageLayoutControlEdit.TabIndex = 0;
            // 
            // dockPanelToolbox
            // 
            this.dockPanelToolbox.Controls.Add(this.dockPanelToolbox_Container);
            this.dockPanelToolbox.Dock = DevExpress.XtraBars.Docking.DockingStyle.Left;
            this.dockPanelToolbox.ID = new System.Guid("fa4437ae-e899-4c64-a249-4c79c640a952");
            this.dockPanelToolbox.Location = new System.Drawing.Point(0, 149);
            this.dockPanelToolbox.Name = "dockPanelToolbox";
            this.dockPanelToolbox.OriginalSize = new System.Drawing.Size(259, 200);
            this.dockPanelToolbox.Size = new System.Drawing.Size(259, 587);
            this.dockPanelToolbox.Text = "工具箱";
            // 
            // dockPanelToolbox_Container
            // 
            this.dockPanelToolbox_Container.Controls.Add(this.xtraTabToolbox);
            this.dockPanelToolbox_Container.Location = new System.Drawing.Point(4, 23);
            this.dockPanelToolbox_Container.Name = "dockPanelToolbox_Container";
            this.dockPanelToolbox_Container.Size = new System.Drawing.Size(251, 560);
            this.dockPanelToolbox_Container.TabIndex = 0;
            // 
            // xtraTabToolbox
            // 
            this.xtraTabToolbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabToolbox.Location = new System.Drawing.Point(0, 0);
            this.xtraTabToolbox.Name = "xtraTabToolbox";
            this.xtraTabToolbox.SelectedTabPage = this.xtraTabPageTOC;
            this.xtraTabToolbox.Size = new System.Drawing.Size(251, 560);
            this.xtraTabToolbox.TabIndex = 1;
            this.xtraTabToolbox.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPageTOC,
            this.xtraTabPageIdentify,
            this.xtraTabPageQuery});
            // 
            // xtraTabPageTOC
            // 
            this.xtraTabPageTOC.Controls.Add(this.axTOCControl);
            this.xtraTabPageTOC.Name = "xtraTabPageTOC";
            this.xtraTabPageTOC.Size = new System.Drawing.Size(245, 531);
            this.xtraTabPageTOC.Text = "图层";
            // 
            // axTOCControl
            // 
            this.axTOCControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axTOCControl.Location = new System.Drawing.Point(0, 0);
            this.axTOCControl.Name = "axTOCControl";
            this.axTOCControl.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axTOCControl.OcxState")));
            this.axTOCControl.Size = new System.Drawing.Size(245, 531);
            this.axTOCControl.TabIndex = 0;
            // 
            // xtraTabPageIdentify
            // 
            this.xtraTabPageIdentify.Name = "xtraTabPageIdentify";
            this.xtraTabPageIdentify.Size = new System.Drawing.Size(245, 531);
            this.xtraTabPageIdentify.Text = "查看";
            // 
            // xtraTabPageQuery
            // 
            this.xtraTabPageQuery.Name = "xtraTabPageQuery";
            this.xtraTabPageQuery.PageVisible = false;
            this.xtraTabPageQuery.Size = new System.Drawing.Size(245, 531);
            this.xtraTabPageQuery.Text = "查询";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.White;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Location = new System.Drawing.Point(880, 726);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(86, 15);
            this.textBox1.TabIndex = 9;
            // 
            // RibbonFormFrame3
            // 
            this.ClientSize = new System.Drawing.Size(1016, 767);
            this.Controls.Add(this.panelFull);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.dockPanelToolbox);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.ribbon);
            this.MinimumSize = new System.Drawing.Size(1000, 726);
            this.Name = "RibbonFormFrame3";
            this.Ribbon = this.ribbon;
            this.StatusBar = this.ribbonStatusBar;
            this.Text = "系统主界面1";
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.applicationMenu1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).EndInit();
            this.dockPanelEdit.ResumeLayout(false);
            this.dockPanelBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            this.panelFull.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabMain)).EndInit();
            this.xtraTabMain.ResumeLayout(false);
            this.tabPageMapContol.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MapControlEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl1)).EndInit();
            this.tabPagePagelayoutContol.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PageLayoutControlEdit)).EndInit();
            this.dockPanelToolbox.ResumeLayout(false);
            this.dockPanelToolbox_Container.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabToolbox)).EndInit();
            this.xtraTabToolbox.ResumeLayout(false);
            this.xtraTabPageTOC.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.axTOCControl)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}

