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
    using ESRI.ArcGIS.Carto;
    using ESRI.ArcGIS.Controls;
    using ESRI.ArcGIS.Display;
    using ESRI.ArcGIS.esriSystem;
    using ESRI.ArcGIS.Geometry;
    using ESRI.ArcGIS.SystemUI;
    using OperateLog;
    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.Drawing;
    using System.Reflection;
    using System.Windows.Forms;
    using td.logic.sys;
    using Utilities;

    public class RibbonFormFrame : RibbonForm
    {
        public ApplicationMenu applicationMenu1;
        public AxLicenseControl axLicenseControl1;
        public AxTOCControl axTOCControl;
        public BarButtonItem barButtonItemBack;
        public BarButtonItem barButtonItemExit;
        public BarButtonItem barButtonItemForward;
        public BarButtonItem barButtonItemFullMap;
        public BarButtonItem barButtonItemHelp;
        public BarButtonItem barButtonItemIdentify;
        public BarButtonItem barButtonItemPan;
        public BarButtonItem barButtonItemToolbox;
        public BarButtonItem barButtonItemToolView;
        public BarButtonItem barButtonItemZoomIn;
        public BarButtonItem barButtonItemZoomOut;
        public BarEditItem barEditItemScale;
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
        public AutoHideContainer hideContainerBottom;
        public DevExpress.Utils.ImageCollection imageCollection1;
        public DevExpress.Utils.ImageCollection imageCollection2;
        private Timer m_Timer;
        protected AxMapControl MapControlEdit;
        private const string mClassName = "MainFrameBase.RibbonFormFrame";
        private string mEditKind;
        private IElement mElement;
        private IElement mElement2;
        private ErrorOpt mErrOpt = UtilFactory.GetErrorOpt();
        private FormSplash mFormSplash;
        private bool mSelection;
        private string mSubSysName = UtilFactory.GetConfigOpt().GetSystemName();
        protected AxPageLayoutControl PageLayoutControlEdit;
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
        public XtraTabPage xtraTabPage1;
        public XtraTabPage xtraTabPage2;
        public XtraTabPage xtraTabPage3;
        public XtraTabControl xtraTabToolbox;

        public RibbonFormFrame()
        {
            this.InitializeComponent();
            this.defaultLookAndFeel1.LookAndFeel.SkinName = "Blue";
        }

        private void axTOCControl_OnMouseDown(object sender, ITOCControlEvents_OnMouseDownEvent e)
        {
            this.ribbon.SetPopupContextMenu(this, null);
            this.ribbon.SetPopupContextMenu(this, null);
        }

        private void barEditItemScale_EditValueChanged(object sender, EventArgs e)
        {
            if (!this.mSelection)
            {
                this.mSelection = true;
                if (!this.barEditItemScale.EditValue.ToString().Contains("1:"))
                {
                    this.barEditItemScale.EditValue = "1:" + this.barEditItemScale.EditValue.ToString();
                }
                if (this.xtraTabMain.SelectedTabPageIndex == 0)
                {
                    this.SetMapScale(this.MapControlEdit.Map, this.barEditItemScale.EditValue.ToString());
                }
                else if (this.xtraTabMain.SelectedTabPageIndex == 1)
                {
                    this.SetMapScale(this.PageLayoutControlEdit.ActiveView.FocusMap, this.barEditItemScale.EditValue.ToString());
                }
                this.textBox1.Text = this.barEditItemScale.EditValue.ToString();
                this.mSelection = false;
            }
        }

        private void barEditItemScale_ItemClick(object sender, ItemClickEventArgs e)
        {
        }

        private void barEditItemScale_ItemPress(object sender, ItemClickEventArgs e)
        {
            if (!this.mSelection)
            {
                this.mSelection = true;
                if (!this.barEditItemScale.EditValue.ToString().Contains("1:"))
                {
                    this.barEditItemScale.EditValue = "1:" + this.barEditItemScale.EditValue.ToString();
                }
                if (this.xtraTabMain.SelectedTabPageIndex == 0)
                {
                    this.SetMapScale(this.MapControlEdit.Map, this.barEditItemScale.EditValue.ToString());
                }
                else if (this.xtraTabMain.SelectedTabPageIndex == 1)
                {
                    this.SetMapScale(this.PageLayoutControlEdit.ActiveView.FocusMap, this.barEditItemScale.EditValue.ToString());
                }
                this.textBox1.Text = this.barEditItemScale.EditValue.ToString();
                this.mSelection = false;
            }
        }

        private void barEditItemScale_ShowingEditor(object sender, ItemCancelEventArgs e)
        {
            if (!this.mSelection)
            {
                this.mSelection = true;
                if (!this.barEditItemScale.EditValue.ToString().Contains("1:"))
                {
                    this.barEditItemScale.EditValue = "1:" + this.barEditItemScale.EditValue.ToString();
                }
                if (this.xtraTabMain.SelectedTabPageIndex == 0)
                {
                    this.SetMapScale(this.MapControlEdit.Map, this.barEditItemScale.EditValue.ToString());
                }
                else if (this.xtraTabMain.SelectedTabPageIndex == 1)
                {
                    this.SetMapScale(this.PageLayoutControlEdit.ActiveView.FocusMap, this.barEditItemScale.EditValue.ToString());
                }
                this.textBox1.Text = this.barEditItemScale.EditValue.ToString();
                this.mSelection = false;
            }
        }

        private void barEditItemScale_ShownEditor(object sender, ItemClickEventArgs e)
        {
            if (!this.mSelection)
            {
                this.mSelection = true;
                if (!this.barEditItemScale.EditValue.ToString().Contains("1:"))
                {
                    this.barEditItemScale.EditValue = "1:" + this.barEditItemScale.EditValue.ToString();
                }
                if (this.xtraTabMain.SelectedTabPageIndex == 0)
                {
                    this.SetMapScale(this.MapControlEdit.Map, this.barEditItemScale.EditValue.ToString());
                }
                else if (this.xtraTabMain.SelectedTabPageIndex == 1)
                {
                    this.SetMapScale(this.PageLayoutControlEdit.ActiveView.FocusMap, this.barEditItemScale.EditValue.ToString());
                }
                this.textBox1.Text = this.barEditItemScale.EditValue.ToString();
                this.mSelection = false;
            }
        }

        protected void CreateCommand(ICommand pCommand, ref BarButtonItem pItem, ArrayList pButtonCollection, int imageIndex, bool beginGroup, object hook, string tooltip)
        {
        }

        protected void CreateCommand2(ICommand pCommand, ref BarButtonItem pItem, ArrayList pButtonCollection, int imageIndex, bool beginGroup, object hook, string tooltip)
        {
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        public IElement DrawEnvelopeElement(IMap pMap, IEnvelope pEnvelope, IGraphicsLayer pGLayer, bool pClearFlag)
        {
            try
            {
                IPoint inPoint = new PointClass();
                IPoint point2 = new PointClass();
                IPoint point3 = new PointClass();
                IPoint point4 = new PointClass();
                inPoint.PutCoords(pEnvelope.XMin, pEnvelope.YMin);
                point2.PutCoords(pEnvelope.XMin, pEnvelope.YMax);
                point3.PutCoords(pEnvelope.XMax, pEnvelope.YMax);
                point4.PutCoords(pEnvelope.XMax, pEnvelope.YMin);
                IPointCollection points = new PolygonClass();
                object before = Missing.Value;
                object after = Missing.Value;
                points.AddPoint(inPoint, ref before, ref after);
                points.AddPoint(point2, ref before, ref after);
                points.AddPoint(point3, ref before, ref after);
                points.AddPoint(point4, ref before, ref after);
                points.AddPoint(inPoint, ref before, ref after);
                ISimpleFillSymbol polySymbol = this.GetPolySymbol(null, null);
                IGeometry geometry = points as IGeometry;
                IElement element = new PolygonElementClass();
                element.Geometry = geometry;
                IFillShapeElement element2 = element as IFillShapeElement;
                element2.Symbol = polySymbol;
                IGraphicsContainer container = pGLayer as IGraphicsContainer;
                if (pClearFlag)
                {
                    container.DeleteAllElements();
                }
                container.AddElement(element, 0);
                return element;
            }
            catch (Exception)
            {
                return null;
            }
        }

        private void EditMapControl_Leave(object sender, EventArgs e)
        {
            this.ribbon.SetPopupContextMenu(this, null);
        }

        private void EditMapControl_OnAfterDraw(object sender, IMapControlEvents2_OnAfterDrawEvent e)
        {
        }

        private void EditMapControl_OnMouseUp(object sender, IMapControlEvents2_OnMouseUpEvent e)
        {
            if (this.xtraTabMain.SelectedTabPageIndex == 0)
            {
                this.RefreshToolBarButton(false);
            }
        }

        private void EditPageLayoutControl_OnAfterDraw(object sender, IPageLayoutControlEvents_OnAfterDrawEvent e)
        {
            this.barEditItemScale.EditValue = this.GetMapScale(this.PageLayoutControlEdit.ActiveView.FocusMap);
            this.textBox1.Text = this.barEditItemScale.EditValue.ToString();
        }

        private void EditPageLayoutControl_OnViewRefreshed(object sender, IPageLayoutControlEvents_OnViewRefreshedEvent e)
        {
            this.axTOCControl.Update();
        }

        public ILineSymbol GetLineSymbol(IRgbColor pRgbColor, double iWidth)
        {
            try
            {
                if (pRgbColor == null)
                {
                    pRgbColor = new RgbColorClass();
                    pRgbColor.Red = 0xff;
                    pRgbColor.Green = 0;
                    pRgbColor.Blue = 0;
                }
                ILineSymbol symbol = null;
                symbol = new CartographicLineSymbolClass();
                symbol.Width = iWidth;
                symbol.Color = pRgbColor;
                return symbol;
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "MainFrameBase.RibbonFormFrame", "GetLineSymbol", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                return null;
            }
        }

        private string GetMapScale(IMap pMap)
        {
            try
            {
                if ((pMap == null) || (pMap.LayerCount == 0))
                {
                    return "0:0";
                }
                return ("1:" + pMap.MapScale.ToString("###,###,###,##0"));
            }
            catch (Exception)
            {
                return "";
            }
        }

        public SimpleFillSymbol GetPolySymbol(IRgbColor pBackRgbColor, IRgbColor pBorderRgbColor)
        {
            try
            {
                if (pBackRgbColor == null)
                {
                    pBackRgbColor = new RgbColorClass();
                    pBackRgbColor.NullColor = true;
                }
                SimpleFillSymbol symbol = new SimpleFillSymbolClass();
                symbol.Color = pBackRgbColor;
                symbol.Outline = this.GetLineSymbol(pBorderRgbColor, 1.2);
                return symbol;
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "MainFrameBase.RibbonFormFrame", "GetPolySymbol", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                return null;
            }
        }

        private void InitializeBaseButton()
        {
        }

        private void InitializeButtonEditTool()
        {
        }

        private void InitializeButtonPageLayout()
        {
        }

        public void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RibbonFormFrame));
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.applicationMenu1 = new DevExpress.XtraBars.Ribbon.ApplicationMenu(this.components);
            this.barButtonItemExit = new DevExpress.XtraBars.BarButtonItem();
            this.imageCollection1 = new DevExpress.Utils.ImageCollection(this.components);
            this.barButtonItemToolbox = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemToolView = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemHelp = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemZoomIn = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemZoomOut = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemFullMap = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemPan = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemIdentify = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemBack = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemForward = new DevExpress.XtraBars.BarButtonItem();
            this.barStaticItemInfo = new DevExpress.XtraBars.BarStaticItem();
            this.barStaticItemLocation1 = new DevExpress.XtraBars.BarStaticItem();
            this.barStaticItemLocation2 = new DevExpress.XtraBars.BarStaticItem();
            this.barStaticItemLocation3 = new DevExpress.XtraBars.BarStaticItem();
            this.barStaticItemScale = new DevExpress.XtraBars.BarStaticItem();
            this.barEditItemScale = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.imageCollection2 = new DevExpress.Utils.ImageCollection(this.components);
            this.ribbonPageDataEdit = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageCheck = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageQuery = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGraphics = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageTransfer = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.defaultLookAndFeel1 = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            this.dockManager1 = new DevExpress.XtraBars.Docking.DockManager(this.components);
            this.hideContainerBottom = new DevExpress.XtraBars.Docking.AutoHideContainer();
            this.dockPanelBottom = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanelBottom_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.dockPanelEdit = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanelEdit_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.dockPanelToolbox = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanelToolbox_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.xtraTabToolbox = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.axTOCControl = new ESRI.ArcGIS.Controls.AxTOCControl();
            this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
            this.xtraTabPage3 = new DevExpress.XtraTab.XtraTabPage();
            this.xtraTabMain = new DevExpress.XtraTab.XtraTabControl();
            this.tabPageMapContol = new DevExpress.XtraTab.XtraTabPage();
            this.MapControlEdit = new ESRI.ArcGIS.Controls.AxMapControl();
            this.axLicenseControl1 = new ESRI.ArcGIS.Controls.AxLicenseControl();
            this.tabPagePagelayoutContol = new DevExpress.XtraTab.XtraTabPage();
            this.PageLayoutControlEdit = new ESRI.ArcGIS.Controls.AxPageLayoutControl();
            this.textBox1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.applicationMenu1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).BeginInit();
            this.hideContainerBottom.SuspendLayout();
            this.dockPanelBottom.SuspendLayout();
            this.dockPanelEdit.SuspendLayout();
            this.dockPanelToolbox.SuspendLayout();
            this.dockPanelToolbox_Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabToolbox)).BeginInit();
            this.xtraTabToolbox.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axTOCControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabMain)).BeginInit();
            this.xtraTabMain.SuspendLayout();
            this.tabPageMapContol.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MapControlEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl1)).BeginInit();
            this.tabPagePagelayoutContol.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PageLayoutControlEdit)).BeginInit();
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
            this.barButtonItemExit,
            this.barButtonItemToolbox,
            this.barButtonItemToolView,
            this.barButtonItemHelp,
            this.barButtonItemZoomIn,
            this.barButtonItemZoomOut,
            this.barButtonItemFullMap,
            this.barButtonItemPan,
            this.barButtonItemIdentify,
            this.barButtonItemBack,
            this.barButtonItemForward,
            this.barStaticItemInfo,
            this.barStaticItemLocation1,
            this.barStaticItemLocation2,
            this.barStaticItemLocation3,
            this.barStaticItemScale,
            this.barEditItemScale});
            this.ribbon.LargeImages = this.imageCollection2;
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.MaxItemId = 18;
            this.ribbon.Name = "ribbon";
            this.ribbon.PageHeaderItemLinks.Add(this.barButtonItemHelp);
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
            this.ribbon.Toolbar.ItemLinks.Add(this.barButtonItemToolbox);
            this.ribbon.Toolbar.ItemLinks.Add(this.barButtonItemToolView);
            // 
            // applicationMenu1
            // 
            this.applicationMenu1.ItemLinks.Add(this.barButtonItemExit);
            this.applicationMenu1.MenuDrawMode = DevExpress.XtraBars.MenuDrawMode.LargeImagesText;
            this.applicationMenu1.Name = "applicationMenu1";
            this.applicationMenu1.Ribbon = this.ribbon;
            // 
            // barButtonItemExit
            // 
            this.barButtonItemExit.Caption = "退出";
            this.barButtonItemExit.Id = 1;
            this.barButtonItemExit.LargeImageIndex = 16;
            this.barButtonItemExit.Name = "barButtonItemExit";
            this.barButtonItemExit.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
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
            // barButtonItemZoomIn
            // 
            this.barButtonItemZoomIn.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            this.barButtonItemZoomIn.Caption = "放大";
            this.barButtonItemZoomIn.Description = "地图放大";
            this.barButtonItemZoomIn.Id = 5;
            this.barButtonItemZoomIn.ImageIndex = 74;
            this.barButtonItemZoomIn.LargeImageIndex = 35;
            this.barButtonItemZoomIn.Name = "barButtonItemZoomIn";
            // 
            // barButtonItemZoomOut
            // 
            this.barButtonItemZoomOut.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            this.barButtonItemZoomOut.Caption = "缩小";
            this.barButtonItemZoomOut.Description = "地图缩小";
            this.barButtonItemZoomOut.Id = 6;
            this.barButtonItemZoomOut.ImageIndex = 75;
            this.barButtonItemZoomOut.LargeImageIndex = 36;
            this.barButtonItemZoomOut.Name = "barButtonItemZoomOut";
            // 
            // barButtonItemFullMap
            // 
            this.barButtonItemFullMap.Caption = "全图";
            this.barButtonItemFullMap.Description = "缩放到全图";
            this.barButtonItemFullMap.Id = 7;
            this.barButtonItemFullMap.ImageIndex = 25;
            this.barButtonItemFullMap.LargeImageIndex = 103;
            this.barButtonItemFullMap.Name = "barButtonItemFullMap";
            // 
            // barButtonItemPan
            // 
            this.barButtonItemPan.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            this.barButtonItemPan.Caption = "漫游";
            this.barButtonItemPan.Description = "地图漫游";
            this.barButtonItemPan.Id = 8;
            this.barButtonItemPan.ImageIndex = 56;
            this.barButtonItemPan.LargeImageIndex = 74;
            this.barButtonItemPan.Name = "barButtonItemPan";
            // 
            // barButtonItemIdentify
            // 
            this.barButtonItemIdentify.Caption = "查看";
            this.barButtonItemIdentify.Description = "属性信息查看";
            this.barButtonItemIdentify.Id = 9;
            this.barButtonItemIdentify.ImageIndex = 262;
            this.barButtonItemIdentify.LargeImageIndex = 33;
            this.barButtonItemIdentify.Name = "barButtonItemIdentify";
            // 
            // barButtonItemBack
            // 
            this.barButtonItemBack.Caption = "返回";
            this.barButtonItemBack.Id = 10;
            this.barButtonItemBack.ImageIndex = 142;
            this.barButtonItemBack.LargeImageIndex = 44;
            this.barButtonItemBack.Name = "barButtonItemBack";
            // 
            // barButtonItemForward
            // 
            this.barButtonItemForward.Caption = "向前";
            this.barButtonItemForward.Id = 11;
            this.barButtonItemForward.ImageIndex = 140;
            this.barButtonItemForward.LargeImageIndex = 45;
            this.barButtonItemForward.Name = "barButtonItemForward";
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
            this.barEditItemScale.EditValueChanged += new System.EventHandler(this.barEditItemScale_EditValueChanged);
            this.barEditItemScale.ShownEditor += new DevExpress.XtraBars.ItemClickEventHandler(this.barEditItemScale_ShownEditor);
            this.barEditItemScale.ShowingEditor += new DevExpress.XtraBars.ItemCancelEventHandler(this.barEditItemScale_ShowingEditor);
            this.barEditItemScale.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barEditItemScale_ItemClick);
            this.barEditItemScale.ItemPress += new DevExpress.XtraBars.ItemClickEventHandler(this.barEditItemScale_ItemClick);
            // 
            // repositoryItemComboBox1
            // 
            this.repositoryItemComboBox1.AutoHeight = false;
            this.repositoryItemComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemComboBox1.Name = "repositoryItemComboBox1";
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
            this.dockManager1.AutoHideContainers.AddRange(new DevExpress.XtraBars.Docking.AutoHideContainer[] {
            this.hideContainerBottom});
            this.dockManager1.Form = this;
            this.dockManager1.HiddenPanels.AddRange(new DevExpress.XtraBars.Docking.DockPanel[] {
            this.dockPanelEdit});
            this.dockManager1.RootPanels.AddRange(new DevExpress.XtraBars.Docking.DockPanel[] {
            this.dockPanelToolbox});
            this.dockManager1.TopZIndexControls.AddRange(new string[] {
            "DevExpress.XtraBars.BarDockControl",
            "DevExpress.XtraBars.StandaloneBarDockControl",
            "System.Windows.Forms.StatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonStatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonControl"});
            // 
            // hideContainerBottom
            // 
            this.hideContainerBottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
            this.hideContainerBottom.Controls.Add(this.dockPanelBottom);
            this.hideContainerBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.hideContainerBottom.Location = new System.Drawing.Point(0, 716);
            this.hideContainerBottom.Name = "hideContainerBottom";
            this.hideContainerBottom.Size = new System.Drawing.Size(1016, 20);
            // 
            // dockPanelBottom
            // 
            this.dockPanelBottom.Controls.Add(this.dockPanelBottom_Container);
            this.dockPanelBottom.Dock = DevExpress.XtraBars.Docking.DockingStyle.Bottom;
            this.dockPanelBottom.ID = new System.Guid("b19474b6-5f2e-45e7-bf89-14075560a1cc");
            this.dockPanelBottom.Location = new System.Drawing.Point(0, 0);
            this.dockPanelBottom.Name = "dockPanelBottom";
            this.dockPanelBottom.OriginalSize = new System.Drawing.Size(200, 200);
            this.dockPanelBottom.SavedDock = DevExpress.XtraBars.Docking.DockingStyle.Bottom;
            this.dockPanelBottom.SavedIndex = 0;
            this.dockPanelBottom.Size = new System.Drawing.Size(1016, 200);
            this.dockPanelBottom.Text = "查询";
            this.dockPanelBottom.Visibility = DevExpress.XtraBars.Docking.DockVisibility.AutoHide;
            // 
            // dockPanelBottom_Container
            // 
            this.dockPanelBottom_Container.Location = new System.Drawing.Point(3, 29);
            this.dockPanelBottom_Container.Name = "dockPanelBottom_Container";
            this.dockPanelBottom_Container.Size = new System.Drawing.Size(1010, 168);
            this.dockPanelBottom_Container.TabIndex = 0;
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
            // dockPanelToolbox
            // 
            this.dockPanelToolbox.Controls.Add(this.dockPanelToolbox_Container);
            this.dockPanelToolbox.Dock = DevExpress.XtraBars.Docking.DockingStyle.Left;
            this.dockPanelToolbox.ID = new System.Guid("fa4437ae-e899-4c64-a249-4c79c640a952");
            this.dockPanelToolbox.Location = new System.Drawing.Point(0, 149);
            this.dockPanelToolbox.Name = "dockPanelToolbox";
            this.dockPanelToolbox.OriginalSize = new System.Drawing.Size(259, 200);
            this.dockPanelToolbox.Size = new System.Drawing.Size(259, 567);
            this.dockPanelToolbox.Text = "工具箱";
            // 
            // dockPanelToolbox_Container
            // 
            this.dockPanelToolbox_Container.Controls.Add(this.xtraTabToolbox);
            this.dockPanelToolbox_Container.Location = new System.Drawing.Point(4, 23);
            this.dockPanelToolbox_Container.Name = "dockPanelToolbox_Container";
            this.dockPanelToolbox_Container.Size = new System.Drawing.Size(251, 540);
            this.dockPanelToolbox_Container.TabIndex = 0;
            // 
            // xtraTabToolbox
            // 
            this.xtraTabToolbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabToolbox.Location = new System.Drawing.Point(0, 0);
            this.xtraTabToolbox.Name = "xtraTabToolbox";
            this.xtraTabToolbox.SelectedTabPage = this.xtraTabPage1;
            this.xtraTabToolbox.Size = new System.Drawing.Size(251, 540);
            this.xtraTabToolbox.TabIndex = 1;
            this.xtraTabToolbox.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1,
            this.xtraTabPage2,
            this.xtraTabPage3});
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Controls.Add(this.axTOCControl);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(245, 511);
            this.xtraTabPage1.Text = "图层";
            // 
            // axTOCControl
            // 
            this.axTOCControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axTOCControl.Location = new System.Drawing.Point(0, 0);
            this.axTOCControl.Name = "axTOCControl";
            this.axTOCControl.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axTOCControl.OcxState")));
            this.axTOCControl.Size = new System.Drawing.Size(245, 511);
            this.axTOCControl.TabIndex = 0;
            // 
            // xtraTabPage2
            // 
            this.xtraTabPage2.Name = "xtraTabPage2";
            this.xtraTabPage2.Size = new System.Drawing.Size(247, 509);
            this.xtraTabPage2.Text = "查看";
            // 
            // xtraTabPage3
            // 
            this.xtraTabPage3.Name = "xtraTabPage3";
            this.xtraTabPage3.Size = new System.Drawing.Size(247, 509);
            this.xtraTabPage3.Text = "查询";
            // 
            // xtraTabMain
            // 
            this.xtraTabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabMain.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Bottom;
            this.xtraTabMain.Images = this.imageCollection1;
            this.xtraTabMain.Location = new System.Drawing.Point(259, 149);
            this.xtraTabMain.Name = "xtraTabMain";
            this.xtraTabMain.SelectedTabPage = this.tabPageMapContol;
            this.xtraTabMain.Size = new System.Drawing.Size(757, 567);
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
            this.tabPageMapContol.Size = new System.Drawing.Size(751, 536);
            this.tabPageMapContol.Text = "地图";
            // 
            // MapControlEdit
            // 
            this.MapControlEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MapControlEdit.Location = new System.Drawing.Point(0, 0);
            this.MapControlEdit.Name = "MapControlEdit";
            this.MapControlEdit.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("MapControlEdit.OcxState")));
            this.MapControlEdit.Size = new System.Drawing.Size(751, 536);
            this.MapControlEdit.TabIndex = 3;
            // 
            // axLicenseControl1
            // 
            this.axLicenseControl1.Enabled = true;
            this.axLicenseControl1.Location = new System.Drawing.Point(66, 97);
            this.axLicenseControl1.Name = "axLicenseControl1";
            this.axLicenseControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axLicenseControl1.OcxState")));
            this.axLicenseControl1.Size = new System.Drawing.Size(32, 32);
            this.axLicenseControl1.TabIndex = 2;
            // 
            // tabPagePagelayoutContol
            // 
            this.tabPagePagelayoutContol.Controls.Add(this.PageLayoutControlEdit);
            this.tabPagePagelayoutContol.ImageIndex = 183;
            this.tabPagePagelayoutContol.Name = "tabPagePagelayoutContol";
            this.tabPagePagelayoutContol.Size = new System.Drawing.Size(751, 539);
            this.tabPagePagelayoutContol.Text = "出版";
            // 
            // PageLayoutControlEdit
            // 
            this.PageLayoutControlEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PageLayoutControlEdit.Location = new System.Drawing.Point(0, 0);
            this.PageLayoutControlEdit.Name = "PageLayoutControlEdit";
            this.PageLayoutControlEdit.Size = new System.Drawing.Size(751, 539);
            this.PageLayoutControlEdit.TabIndex = 1;
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
            // RibbonFormFrame
            // 
            this.ClientSize = new System.Drawing.Size(1016, 767);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.xtraTabMain);
            this.Controls.Add(this.dockPanelToolbox);
            this.Controls.Add(this.hideContainerBottom);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.ribbon);
            this.MinimumSize = new System.Drawing.Size(1000, 758);
            this.Name = "RibbonFormFrame";
            this.Ribbon = this.ribbon;
            this.StatusBar = this.ribbonStatusBar;
            this.Text = "系统主界面1";
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.applicationMenu1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).EndInit();
            this.hideContainerBottom.ResumeLayout(false);
            this.dockPanelBottom.ResumeLayout(false);
            this.dockPanelEdit.ResumeLayout(false);
            this.dockPanelToolbox.ResumeLayout(false);
            this.dockPanelToolbox_Container.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabToolbox)).EndInit();
            this.xtraTabToolbox.ResumeLayout(false);
            this.xtraTabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.axTOCControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabMain)).EndInit();
            this.xtraTabMain.ResumeLayout(false);
            this.tabPageMapContol.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MapControlEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl1)).EndInit();
            this.tabPagePagelayoutContol.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PageLayoutControlEdit)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void InitializeControlEvents()
        {
        }

        private void InitializeEditValue()
        {
        }

        public bool InitializeForm()
        {
            try
            {
                this.mFormSplash.lablekind.Text = this.mFormSplash.lablekind.Text + " -- 数据编辑";
                this.mFormSplash.SetLoadInfo("正在加载地图数据...", 0x19);
                this.MapControlEdit.BringToFront();
                this.InitSynchronizer();
                this.InitializeGISControls();
                this.mFormSplash.SetLoadInfo("正在初始化工具按钮...", 30);
                this.InitializeBaseButton();
                this.mFormSplash.SetLoadInfo("正在初始化工具按钮...", 40);
                this.InitializeButtonEditTool();
                this.mFormSplash.SetLoadInfo("正在初始化工具按钮...", 50);
                this.InitializeButtonPageLayout();
                this.mFormSplash.SetLoadInfo("正在初始化功能模块...", 60);
                this.SetFormText();
                this.ribbon.SelectedPage = this.ribbonPageDataEdit;
                this.mFormSplash.SetLoadInfo("正在初始化功能模块...", 70);
                this.mFormSplash.SetLoadInfo("正在初始化功能模块...", 80);
                this.SetButtonVisible();
                this.SetButtonEnabled();
                this.SetButtonTooltip();
                base.WindowState = FormWindowState.Maximized;
                base.Show();
                this.mFormSplash.SetLoadInfo("正在初始化功能模块...", 90);
                LogType.SystemType = this.mEditKind;
               
                if (this.mEditKind == "林改")
                {
                    UserManager.Single.Log("登陆系统", this.mEditKind + "宗地编辑", LogType.SystemType);
                }
                else if (this.mEditKind.Contains("造林") || this.mEditKind.Contains("采伐"))
                {
                    UserManager.Single.Log( "登陆系统", this.mEditKind + "作业设计", LogType.SystemType);
                }
                else
                {
                    UserManager.Single.Log( "登陆系统", this.mEditKind + "编辑", LogType.SystemType);
                }
                this.barStaticItemInfo.Width = 200;
                this.barStaticItemLocation1.Width = 300;
                this.barStaticItemLocation2.Width = 250;
                this.barStaticItemLocation3.Width = 210;
                this.barStaticItemScale.Width = 60;
                this.m_Timer = new Timer();
                this.m_Timer.Tick += new EventHandler(this.m_Timer_Tick);
                this.m_Timer.Interval = 600;
                this.m_Timer.Start();
                this.mFormSplash.SetLoadInfo("系统初始化完毕...", 100);
                return true;
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "MainFrameBase.RibbonFormFrame", "InitializeForm", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                return false;
            }
        }

        private void InitializeGISControls()
        {
            try
            {
                this.mSelection = true;
                this.InitializeControlEvents();
                this.InitializeMapControl();
                this.InitializeEditValue();
                this.axTOCControl.SetBuddyControl(this.MapControlEdit);
                this.barEditItemScale.EditValue = this.GetMapScale(this.MapControlEdit.Map);
                this.mSelection = false;
            }
            catch (Exception exception)
            {
                this.mSelection = false;
                this.mErrOpt.ErrorOperate(this.mSubSysName, "MainFrameBase.RibbonFormFrame", "InitializeGISControls", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void InitializeMapControl()
        {
        }

        private void InitSynchronizer()
        {
        }

        private void m_Timer_Tick(object sender, EventArgs e)
        {
            this.RefreshToolBarButton(false);
        }

        private void mActiveViewEvents_ItemAdded(object Item)
        {
            this.axTOCControl.SetBuddyControl(this.MapControlEdit);
            this.axTOCControl.Update();
        }

        private void mActiveViewEvents_ItemDeleted(object Item)
        {
            this.axTOCControl.SetBuddyControl(this.MapControlEdit);
            this.axTOCControl.Update();
        }

        private void MapControlEdit_OnMouseMove(object sender, IMapControlEvents2_OnMouseMoveEvent e)
        {
        }

        private void OnActiveViewEventsAfterDraw(IDisplay Display, esriViewDrawPhase phase)
        {
        }

        private void OnActiveViewEventsItemAdded(object Item)
        {
            this.axTOCControl.SetBuddyControl(this.MapControlEdit);
            this.axTOCControl.Update();
        }

        private void OnActiveViewEventsItemDraw(short Index, IDisplay Display, esriDrawPhase phase)
        {
        }

        private void PageLayoutControl_DbClick(object sender, IPageLayoutControlEvents_OnDoubleClickEvent e)
        {
        }

        private void PageLayoutControlEdit_OnMouseMove(object sender, IPageLayoutControlEvents_OnMouseMoveEvent e)
        {
        }

        protected void RefreshToolBarButton(bool flag)
        {
        }

        private void ribbon_ItemPress(object sender, ItemClickEventArgs e)
        {
        }

        private void SetButtonEnabled()
        {
        }

        private void SetButtonTooltip()
        {
            try
            {
                for (int i = 0; i < this.ribbon.Items.Count; i++)
                {
                    if (this.ribbon.Items[i] is BarButtonItem)
                    {
                        BarButtonItem item = this.ribbon.Items[i] as BarButtonItem;
                        if (item.SuperTip == null)
                        {
                            item.SuperTip = new SuperToolTip();
                            if (item.Caption != "")
                            {
                                item.SuperTip.Items.AddTitle(item.Caption);
                            }
                            if (item.Description != "")
                            {
                                item.SuperTip.Items.Add(item.Description);
                            }
                        }
                        else if (item.SuperTip.Items.Count == 0)
                        {
                            if (item.Caption != "")
                            {
                                item.SuperTip.Items.AddTitle(item.Caption);
                            }
                            if (item.Description != "")
                            {
                                item.SuperTip.Items.Add(item.Description);
                            }
                        }
                        else
                        {
                            item.SuperTip.Items.Clear();
                            item.SuperTip.Items.AddTitle(item.Caption);
                            if (item.Description != "")
                            {
                                item.SuperTip.Items.Add(item.Description);
                            }
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "MainFrameBase.RibbonFormFrame", "SetButtonTooltip", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void SetButtonVisible()
        {
        }

        private void SetFormText()
        {
            try
            {
                string systemName = UtilFactory.GetConfigOpt().GetSystemName();
                this.Text = systemName + " — 数据编辑";
                this.barStaticItemInfo.Caption = "就绪";
                this.ribbon.ApplicationCaption = this.Text;
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "MainFrameBase.RibbonFormFrame", "SetFormText", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void SetMapScale(IMap pMap, string scalevalue)
        {
            try
            {
                this.mSelection = true;
                if ((pMap != null) && (pMap.LayerCount != 0))
                {
                    double num;
                    if (scalevalue.Contains("1:"))
                    {
                        num = double.Parse(scalevalue.Substring(2, scalevalue.Length - 2));
                    }
                    else
                    {
                        num = double.Parse(scalevalue);
                    }
                    if (num != pMap.MapScale)
                    {
                        pMap.MapScale = num;
                        (pMap as IActiveView).Refresh();
                        this.mSelection = false;
                    }
                }
            }
            catch (Exception exception)
            {
                this.mSelection = false;
                this.mErrOpt.ErrorOperate(this.mSubSysName, "MainFrameBase.RibbonFormFrame", "SetMapScale", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        public string EditKind
        {
            get
            {
                return this.mEditKind;
            }
            set
            {
                this.mEditKind = value;
            }
        }

        public FormSplash frmLogin
        {
            get
            {
                return this.mFormSplash;
            }
            set
            {
                this.mFormSplash = value;
            }
        }
    }
}

