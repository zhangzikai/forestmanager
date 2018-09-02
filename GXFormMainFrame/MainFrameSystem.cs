namespace GXFormMainFrame
{
    using AttributesEdit;
    using Cartography;
    using Cartography.Business;
    using Cartography.Element;
    using Cartography.Template;
    using DataEdit;
    using Desktop;
    using DevExpress.Utils;
    using DevExpress.XtraBars;
    using DevExpress.XtraBars.Docking;
    using DevExpress.XtraBars.Ribbon;
    using DevExpress.XtraEditors;
    using DevExpress.XtraEditors.Repository;
    using DevExpress.XtraTab;
    using ESRI.ArcGIS.Carto;
    using ESRI.ArcGIS.Controls;
    using ESRI.ArcGIS.Display;
    using ESRI.ArcGIS.esriSystem;
    using ESRI.ArcGIS.Geodatabase;
    using ESRI.ArcGIS.Geometry;
    using ESRI.ArcGIS.SystemUI;
    using FunFactory;
    using GDB.SQLServerExpress.vTasks.Forest;
    using GISControlsClass;
    using MainFrameBase;
    using Measure;
    using OperateLog;
    using Print;
    using ProxyButton;
    using QueryAnalysic;
    using QueryCommon;
    using ShapeEdit;
    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.Data;
    using System.Diagnostics;
    using System.Drawing;
    using System.Drawing.Printing;
    using System.Windows.Forms;
    using TaskManage;
    using td.db.orm;
    using td.logic.sys;
    using Utilities;

    /// <summary>
    /// 系统管理窗体
    /// </summary>
    public class MainFrameSystem : RibbonFormFrame2
    {
        private IToolbarControl _editMapToolBar = new ToolbarControlClass();
        private BarButtonGroup barButtonGroup1;
        private BarButtonItem barButtonItem3;
        private BarButtonItem barButtonItem4;
        private BarButtonItem barButtonItemAddFeature;
        private BarButtonItem barButtonItemAddLayer;
        private BarButtonItem barButtonItemAddLayer2;
        private BarButtonItem barButtonItemAddLayer3;
        private BarButtonItem barButtonItemBack;
        private BarButtonItem barButtonItemBackup;
        private BarButtonItem barButtonItemBackup2;
        private BarButtonItem barButtonItemBoudarySnap;
        private BarButtonItem barButtonItemChartCF;
        private BarButtonItem barButtonItemChartZL;
        private BarButtonItem barButtonItemCheckAngle;
        private BarButtonItem barButtonItemCheckArea;
        private BarButtonItem barButtonItemCheckBoundary;
        private BarButtonItem barButtonItemCheckDist;
        private BarButtonItem barButtonItemCheckGap;
        private BarButtonItem barButtonItemCheckLayers;
        private BarButtonItem barButtonItemCheckOverlap;
        private BarButtonItem barButtonItemCheckRepeat;
        private BarButtonItem barButtonItemCheckSelfIntersect;
        private BarButtonItem barButtonItemClearSelectFeature;
        private BarButtonItem barButtonItemClearTopErr;
        private BarButtonItem barButtonItemCombineFeature;
        private BarButtonItem barButtonItemCutFeature;
        private BarButtonItem barButtonItemDataImput;
        private BarButtonItem barButtonItemDataOutput;
        private BarButtonItem barButtonItemDBConnect;
        private BarButtonItem barButtonItemDBDelete;
        private BarButtonItem barButtonItemDBLoadData;
        private BarButtonItem barButtonItemDBNew;
        private BarButtonItem barButtonItemDBUpdata;
        private BarButtonItem barButtonItemDeleteFeature;
        private BarButtonItem barButtonItemDesign;
        private BarButtonItem barButtonItemEditFeature;
        private BarButtonItem barButtonItemEditRedo;
        private BarButtonItem barButtonItemEditUndo;
        private BarButtonItem barButtonItemEraseFeature;
        private BarButtonItem barButtonItemExportImage;
        private BarButtonItem barButtonItemForward;
        private BarButtonItem barButtonItemFullMap;
        private BarButtonItem barButtonItemGrowthModel;
        private BarButtonItem barButtonItemIdentify;
        private BarButtonItem barButtonItemIdentify2;
        private BarButtonItem barButtonItemInput;
        private BarButtonItem barButtonItemInputDC;
        private BarButtonItem barButtonItemInputOther;
        private BarButtonItem barButtonItemInputProperty;
        private BarButtonItem barButtonItemInputYG;
        private BarButtonItem barButtonItemInputZT;
        private BarButtonItem barButtonItemLargeButton;
        private BarButtonItem barButtonItemLayerCombine;
        private BarButtonItem barButtonItemLinkageAdd;
        private BarButtonItem barButtonItemLinkageDelete;
        private BarButtonItem barButtonItemLinkageEdit;
        private BarButtonItem barButtonItemLocation;
        private BarButtonItem barButtonItemLogClear;
        private BarButtonItem barButtonItemLogDelete;
        private BarButtonItem barButtonItemLogicCheck;
        private BarButtonItem barButtonItemLogs;
        private BarButtonItem barButtonItemManageDesignEdit;
        private BarButtonItem barButtonItemManageDesignQuery;
        private BarButtonItem barButtonItemManageDesignYear;
        private BarButtonItem barButtonItemMapComment;
        private BarButtonItem barButtonItemMapFind;
        private BarButtonItem barButtonItemMapFrame;
        private BarButtonItem barButtonItemMapGrid;
        private BarButtonItem barButtonItemMapLegend;
        private BarButtonItem barButtonItemMapNorthArrow;
        private BarButtonItem barButtonItemMapScaleBar;
        private BarButtonItem barButtonItemMapTable;
        private BarButtonItem barButtonItemMapText;
        private BarButtonItem barButtonItemMeasure;
        private BarButtonItem barButtonItemNessRule;
        private BarButtonItem barButtonItemNormal;
        private BarButtonItem barButtonItemOpen;
        private BarButtonItem barButtonItemOverlapCombine;
        private BarButtonItem barButtonItemOverlapConvert;
        private BarButtonItem barButtonItemOverlapDelete;
        private BarButtonItem barButtonItemOverView;
        private BarButtonItem barButtonItemPageNext;
        private BarButtonItem barButtonItemPagePan;
        private BarButtonItem barButtonItemPagePre;
        private BarButtonItem barButtonItemPageWhole;
        private BarButtonItem barButtonItemPageZoomIn;
        private BarButtonItem barButtonItemPageZoomOut;
        private BarButtonItem barButtonItemPan;
        private BarButtonItem barButtonItemPlace;
        private BarButtonItem barButtonItemPointDelete;
        private BarButtonItem barButtonItemPrint;
        private BarButtonItem barButtonItemPrintPreview;
        private BarButtonItem barButtonItemPrintSet;
        private BarButtonItem barButtonItemQueryKind;
        private BarButtonItem barButtonItemQueryTF;
        private BarButtonItem barButtonItemQueryXB;
        private BarButtonItem barButtonItemQueryYear;
        private BarButtonItem barButtonItemQueryZT;
        private BarButtonItem barButtonItemQuickSnap;
        private BarButtonItem barButtonItemRedo;
        private BarButtonItem barButtonItemRefresh;
        private BarButtonItem barButtonItemReportCF1;
        private BarButtonItem barButtonItemReportZL;
        private BarButtonItem barButtonItemRestore;
        private BarButtonItem barButtonItemRestore2;
        private BarButtonItem barButtonItemSave;
        private BarButtonItem barButtonItemScaleText;
        private BarButtonItem barButtonItemSelectedFeaturesReport;
        private BarButtonItem barButtonItemSelectElement;
        private BarButtonItem barButtonItemSelectFeature;
        private BarButtonItem barButtonItemSelectLayerSet;
        private BarButtonItem barButtonItemSetDRG;
        private BarButtonItem barButtonItemShapeCopy;
        private BarButtonItem barButtonItemShapePaste;
        private BarButtonItem barButtonItemSimplify;
        private BarButtonItem barButtonItemSmallButton;
        private BarButtonItem barButtonItemSmallText;
        private BarButtonItem barButtonItemSplitFeature;
        private BarButtonItem barButtonItemStatic;
        private BarButtonItem barButtonItemTOC;
        private BarButtonItem barButtonItemTOC2;
        private BarButtonItem barButtonItemTotalLayer;
        private BarButtonItem barButtonItemUndo;
        private BarButtonItem barButtonItemUserAdd;
        private BarButtonItem barButtonItemUserDelete;
        private BarButtonItem barButtonItemUserEdit;
        private BarButtonItem barButtonItemUserKey;
        private BarButtonItem barButtonItemUserList;
        private BarButtonItem barButtonItemVertexDelete;
        private BarButtonItem barButtonItemVertexInsert;
        private BarButtonItem barButtonItemVertexList;
        private BarButtonItem barButtonItemXBEdit;
        private BarButtonItem barButtonItemXBSet;
        private BarButtonItem barButtonItemXBUpdate;
        private BarButtonItem barButtonItemZone;
        private BarButtonItem barButtonItemZoomIn;
        private BarButtonItem barButtonItemZoomOut;
        private BarButtonItem barButtonToolbox;
        private BarButtonItem barButtonToolView;
        private BarEditItem barEditItem1;
        private BarSubItem barSubItemButtonStyle;
        private IContainer components = null;
        private PrintDocument doc = new PrintDocument();
        public FormLogin4 FormSplash;
        public FormLogin5 FormSplash5;
        public FormLogin6 FormSplash6;
        private IActiveViewEvents_AfterDrawEventHandler m_ActiveViewEventsAfterDraw;
        private IActiveViewEvents_AfterItemDrawEventHandler m_ActiveViewEventsAfterItemDraw;
        private IActiveViewEvents_ContentsChangedEventHandler m_ActiveViewEventsContentsChanged;
        private IActiveViewEvents_ContentsClearedEventHandler m_ActiveViewEventsContentsCleared;
        private IActiveViewEvents_FocusMapChangedEventHandler m_ActiveViewEventsFocusMapChanged;
        private IActiveViewEvents_ItemAddedEventHandler m_ActiveViewEventsItemAdded;
        private IActiveViewEvents_ItemDeletedEventHandler m_ActiveViewEventsItemDeleted;
        private IActiveViewEvents_ItemReorderedEventHandler m_ActiveViewEventsItemReordered;
        private IActiveViewEvents_SelectionChangedEventHandler m_ActiveViewEventsSelectionChanged;
        private IActiveViewEvents_SpatialReferenceChangedEventHandler m_ActiveViewEventsSpatialReferenceChanged;
        private IActiveViewEvents_ViewRefreshedEventHandler m_ActiveViewEventsViewRefreshed;
        protected ControlsSynchronizer m_controlsSynchronizer;
        protected ControlsSynchronizer m_controlsSynchronizer2;
        private Timer m_Timer = null;
        private IActiveViewEvents_Event mActiveViewEvents;
        protected ArrayList mButtonCollection = new ArrayList();
        protected ArrayList mButtonCollection2 = new ArrayList();
        protected ArrayList mButtonCollection3 = new ArrayList();
        private const string mClassName = "GXFormMainFrame.FormMainEdit";
        private ArrayList mCommandMenuItems = new ArrayList();
        private ArrayList mCommandToolItems = new ArrayList();
        private BarButtonItem mCurBarButtonItem;
        private BarButtonItem mCurMenuButtonItem;
        protected ICommand mCurrentTool = null;
        private IGroupLayer mEditGroupLayer = null;
        public string mEditKind;
        public string mEditKind2;
        private IFeatureLayer mEditLayer = null;
        private IFeatureLayer mEditLayer2 = null;
        private IFeatureLayer mEditLayer3 = null;
        private IFeatureLayer mEditLayer4 = null;
        private IElement mElement;
        private IElement mElement2;
        private ErrorOpt mErrOpt = UtilFactory.GetErrorOpt();
        private IFeatureWorkspace mFeatureWorkspace = null;
        private FormVertexList mFormVertexList = null;
        private bool mInUse;
        private IFeatureLayer[] mLinkageLayer = null;
        private static Process mProcess = null;
        private RibbonItemStyles mRibbonItemStyles = RibbonItemStyles.Default;
        private bool mSelection;
        private string mSubSysName = UtilFactory.GetConfigOpt().GetSystemName();
        private PictureBox pictureBox1;
        private PopupMenu popupMenuEdit;
        private PopupMenu popupMenuLinkage;
        private PopupMenu popupMenuMapView;
        private PopupMenu popupMenuVertex;
        private RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private RibbonPage ribbonPageDataManager;
        private RibbonPageGroup ribbonPageGroup2;
        private RibbonPageGroup ribbonPageGroupAddnew;
        private RibbonPageGroup ribbonPageGroupBack;
        private RibbonPageGroup ribbonPageGroupCaoTu;
        private RibbonPageGroup ribbonPageGroupCommEdit;
        private RibbonPageGroup ribbonPageGroupDataCheck;
        private RibbonPageGroup ribbonPageGroupDataUpdata;
        private RibbonPageGroup ribbonPageGroupDBManage;
        private RibbonPageGroup ribbonPageGroupDelete;
        private RibbonPageGroup ribbonPageGroupEdit;
        private RibbonPageGroup ribbonPageGroupEdittool;
        private RibbonPageGroup ribbonPageGroupIO;
        private RibbonPageGroup ribbonPageGroupLogic;
        private RibbonPageGroup ribbonPageGroupLogs;
        private RibbonPageGroup ribbonPageGroupManageDesign;
        private RibbonPageGroup ribbonPageGroupManageUser;
        private RibbonPageGroup ribbonPageGroupMapView;
        private RibbonPageGroup ribbonPageGroupMapView2;
        private RibbonPageGroup ribbonPageGroupMapView3;
        private RibbonPageGroup ribbonPageGroupMapView4;
        private RibbonPageGroup ribbonPageGroupMapView5;
        private RibbonPageGroup ribbonPageGroupMxt;
        private RibbonPageGroup ribbonPageGroupPageTool;
        private RibbonPageGroup ribbonPageGroupPageView;
        private RibbonPageGroup ribbonPageGroupQuery;
        private RibbonPageGroup ribbonPageGroupQuery2;
        private RibbonPageGroup ribbonPageGroupQueryComm;
        private RibbonPageGroup ribbonPageGroupSet;
        private RibbonPageGroup ribbonPageGroupToplogic;
        private RibbonPageGroup ribbonPageGroupToplogic2;
        private RibbonPageGroup ribbonPageGroupTopoModify;
        private RibbonPageGroup ribbonPageGroupXB;
        private RibbonPageGroup ribbonPageGroupXBSet;
        private RibbonPage ribbonPageSystemManager;
        private SplitterControl splitterControl1;
        private IToolbarControl tc1 = new ToolbarControlClass();
        private IToolbarControl tc2 = new ToolbarControlClass();
        private UserControlAttrEdit userControlAttrEdit1;
        private UserControlAttriCheck userControlAttriCheck1;
        private UserControlImageGeoReference userControlImageGeoReference1;
        private UserControlInfo userControlInfo;
        private UserControlInputData2 userControlInputData;
        private UserControlInputYG userControlInputYG1;
        private UserControlLayerControl userControlLayerControl;
        private UserControlLocation userControlLocation;
        private UserControlLog userControlLog1;
        private UserControlMapFind userControlMapFind1;
        private UserControlOverView userControlOverView;
        private UserControlPlace userControlPlace1;
        private UserControlQueryCF userControlQueryCF1;
        private UserControlQueryCF2 userControlQueryCF21;
        private UserControlQueryDesign userControlQueryDesign;
        private QueryCommon.UserControlQueryResult userControlQueryResult1;
        private QueryCommon.UserControlQueryResult userControlQueryResult2;
        private UserControlQueryTFH userControlQueryTFH1;
        private UserControlQueryXB userControlQueryXB;
        private UserControlQueryXB2 userControlQueryXB21;
        private UserControlQueryZL userControlQueryZL1;
        private UserControlSelectFeatureResport2 userControlSelectFeatureResport21;
        private UserControlSelectLayerSet userControlSelectLayerSet1;
        private UserControlUpdate userControlUpdate1;
        private UserControlXBGrowth userControlXBGrowth1;
        private UserControlXBLayerCombine userControlXBLayerCombine1;
        private UserControlXBSet userControlXBSet1;
        private UserControlXBSet2 userControlXBSet21;
        private UserControlXBSet3 userControlXBSet31;
        private XtraTabControl xtraTabControlEdit;
        private XtraTabPage xtraTabPage1;
        private XtraTabPage xtraTabPage2;
        private XtraTabPage xtraTabPage3;
        private XtraTabPage xtraTabPageAddRasterlayer;
        private XtraTabPage xtraTabPageAttribute;
        private XtraTabPage xtraTabPageDesign;
        private XtraTabPage xtraTabPageInputData;
        private XtraTabPage xtraTabPageKind;
        private XtraTabPage xtraTabPageLocation;
        private XtraTabPage xtraTabPageLog;
        private XtraTabPage xtraTabPageLogicCheck;
        private XtraTabPage xtraTabPageMapFind;
        private XtraTabPage xtraTabPagePlace;
        private XtraTabPage xtraTabPageSelect;
        private XtraTabPage xtraTabPageTFH;
        private XtraTabPage xtraTabPageUpdate;
        private XtraTabPage xtraTabPageXBchange;
        private XtraTabControl xtraTabQuery;

        /// <summary>
        /// 系统管理构造器
        /// </summary>
        public MainFrameSystem()
        {
            this.InitializeComponent();
        }

        private void ActiveViewEvents_ItemAdded(object Item)
        {
            base.axTOCControl.SetBuddyControl(base.MapControlEdit);
            base.axTOCControl.Update();
        }

        private void ActiveViewEvents_ItemDeleted(object Item)
        {
            base.axTOCControl.SetBuddyControl(base.MapControlEdit);
            base.axTOCControl.Update();
        }

        private void axTOCControl_OnMouseDown(object sender, ITOCControlEvents_OnMouseDownEvent e)
        {
            base.ribbon.SetPopupContextMenu(this, null);
            AxTOCControl control = sender as AxTOCControl;
            control.SetBuddyControl(base.MapControlEdit);
            control.Update();
            esriTOCControlItem esriTOCControlItemNone = esriTOCControlItem.esriTOCControlItemNone;
            IBasicMap basicMap = null;
            ILayer layer = null;
            object unk = null;
            object data = null;
            control.HitTest(e.x, e.y, ref esriTOCControlItemNone, ref basicMap, ref layer, ref unk, ref data);
            if ((e.button == 2) && (esriTOCControlItemNone == esriTOCControlItem.esriTOCControlItemLayer))
            {
                TocMenu menu = new TocMenu(control.Object as ITOCControl2);
                control.SelectItem(layer, null);
                control.CustomProperty = layer;
                menu.ShowMenu(e.x, e.y, control.hWnd);
            }
            else
            {
                base.ribbon.SetPopupContextMenu(this, null);
            }
        }

        private void axTOCControl_OnMouseMove(object sender, ITOCControlEvents_OnMouseMoveEvent e)
        {
            base.ribbon.SetPopupContextMenu(this, null);
        }

        private void barButtonItemAddLayer_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                IMap map = null;
                IActiveView activeView = null;
                if (base.xtraTabMain.SelectedTabPageIndex == 0)
                {
                    map = base.MapControlEdit.Map;
                    activeView = base.MapControlEdit.ActiveView;
                }
                else if (base.xtraTabMain.SelectedTabPageIndex == 1)
                {
                    string name = "";
                    if (this.mEditKind.Contains("小班"))
                    {
                        name = "小班地图";
                    }
                    else if (this.mEditKind == "火灾")
                    {
                        name = "火灾地图";
                    }
                    else if (this.mEditKind == "造林")
                    {
                        name = "造林地图";
                    }
                    else if (this.mEditKind == "采伐")
                    {
                        name = "采伐地图";
                    }
                    else if (this.mEditKind == "征占用")
                    {
                        name = "征占用地图";
                    }
                    else if (this.mEditKind == "林业工程")
                    {
                        name = "林业工程地图";
                    }
                    else if (this.mEditKind == "林业案件")
                    {
                        name = "林业案件地图";
                    }
                    else if (this.mEditKind == "自然灾害")
                    {
                        name = "自然灾害地图";
                    }
                    IMapFrame frame = (IMapFrame) base.PageLayoutControlEdit.FindElementByName(name);
                    map = frame.Map;
                    activeView = (IActiveView) frame.Map;
                }
                ArrayList layerList = null;
                FormAddData data = new FormAddData(map as IBasicMap, null, true, null);
                data.ShowDialog(this);
                layerList = data.LayerList;
                if ((layerList != null) && (layerList.Count == 1))
                {
                    IDataset dataset = (layerList[0] as ILayer) as IDataset;
                    IGeoDataset dataset2 = dataset as IGeoDataset;
                    IEnvelope extent = dataset2.Extent;
                    base.MapControlEdit.ActiveView.FullExtent = extent;
                    base.MapControlEdit.ActiveView.Refresh();
                }
            }
            catch (Exception)
            {
            }
        }

        private void barButtonItemAddLayer2_ItemClick(object sender, ItemClickEventArgs e)
        {
        }

        private void barButtonItemAddLayer3_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (this.barButtonItemAddLayer3.Down)
            {
                this.xtraTabPageAddRasterlayer.PageVisible = true;
                base.xtraTabToolbox.SelectedTabPage = this.xtraTabPageAddRasterlayer;
                this.xtraTabPageAddRasterlayer.Show();
                this.userControlImageGeoReference1.Hook(base.MapControlEdit.Object, this.mEditKind);
            }
            else
            {
                this.xtraTabPageAddRasterlayer.PageVisible = false;
            }
        }

        private void barButtonItemChartCF_ItemClick(object sender, ItemClickEventArgs e)
        {
        }

        private void barButtonItemChartZL_ItemClick(object sender, ItemClickEventArgs e)
        {
        }

        private void barButtonItemDBConnect_ItemClick(object sender, ItemClickEventArgs e)
        {
            new OperateLog.FormDataBaseLogin().ShowDialog(this);
            string str = (EditTask.EditWorkspace as IWorkspace).ConnectionProperties.GetProperty("DATABASE").ToString();
            string str2 = UtilFactory.GetConfigOpt().GetConfigValue2("SqlServer", "InitialCatalog");
            this.InitializeEditValue(false);
        }

        private void barButtonItemDBDelete_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                ForestDBServerInfo dbServerInfo = new ForestDBServerInfo {
                    ServerName = UtilFactory.GetConfigOpt().GetConfigValue2("SqlServer", "DataSource"),
                    InstanceName = UtilFactory.GetConfigOpt().GetConfigValue2("SqlServer", "InitialCatalog"),
                    UserName = UtilFactory.GetConfigOpt().GetConfigValue2("SqlServer", "UserID"),
                    UserPass = UtilFactory.GetConfigOpt().GetConfigValue2("SqlServer", "Password")
                };
                FormDeleteForestDB tdb = new FormDeleteForestDB();
                tdb.InitialValue(dbServerInfo, EditTask.DistCode);
                tdb.ShowDialog(this);
                if (tdb != null)
                {
                    tdb.Close();
                    tdb = null;
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "GXFormMainFrame.FormMainEdit", "barButtonItemDBDelete_ItemClick", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void barButtonItemDBLoad_ItemClick(object sender, ItemClickEventArgs e)
        {
            FormLoadSpatialData data = new FormLoadSpatialData();
            data.InitialValue();
            data.ShowDialog(this);
        }

        private void barButtonItemDBNew_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                ForestDBServerInfo dbServerInfo = new ForestDBServerInfo {
                    ServerName = UtilFactory.GetConfigOpt().GetConfigValue2("SqlServer", "DataSource"),
                    InstanceName = UtilFactory.GetConfigOpt().GetConfigValue2("SqlServer", "InitialCatalog"),
                    UserName = UtilFactory.GetConfigOpt().GetConfigValue2("SqlServer", "UserID"),
                    UserPass = UtilFactory.GetConfigOpt().GetConfigValue2("SqlServer", "Password")
                };
                FormCreateForestDB tdb = new FormCreateForestDB();
                tdb.InitialValue(dbServerInfo, EditTask.DistCode);
                tdb.ShowDialog(this);
                if (tdb != null)
                {
                    tdb.Close();
                    tdb = null;
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "GXFormMainFrame.FormMainEdit", "barButtonItemDBNew_ItemClick", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void barButtonItemDBUpdata_ItemClick(object sender, ItemClickEventArgs e)
        {
            new FormUpdateGDB().ShowDialog(this);
        }

        private void barButtonItemExportImage_ItemClick(object sender, ItemClickEventArgs e)
        {
            IActiveView activeView = null;
            AxMapControl mapControlEdit = base.MapControlEdit;
            if (mapControlEdit != null)
            {
                activeView = mapControlEdit.ActiveView;
            }
            else
            {
                activeView = base.PageLayoutControlEdit.ActiveView;
            }
            DevImageExport export = new DevImageExport {
                ActiveView = activeView
            };
            export.ShowDialog();
            export.Dispose();
            export = null;
        }

        private void barButtonItemIdentify2_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                if (this.barButtonItemIdentify2.Down)
                {
                    if (this.userControlInfo.hook == null)
                    {
                        this.userControlInfo.hook = base.MapControlEdit.Object;
                    }
                    this.userControlInfo.EditLayer = this.mEditLayer;
                    this.userControlInfo.InitialControls(this.mEditKind);
                    base.dockPanelToolbox.Visibility = DockVisibility.Visible;
                    base.xtraTabPageIdentify.PageVisible = true;
                    base.xtraTabToolbox.SelectedTabPage = base.xtraTabPageIdentify;
                }
                else if (this.barButtonItemTOC.Down)
                {
                    base.xtraTabPageIdentify.PageVisible = false;
                    base.xtraTabToolbox.SelectedTabPage = base.xtraTabPageTOC;
                }
                else if (this.barButtonItemLocation.Down)
                {
                    base.xtraTabToolbox.SelectedTabPage = base.xtraTabPageIdentify;
                }
                else if (this.barButtonItemPlace.Down)
                {
                    base.xtraTabToolbox.SelectedTabPage = base.xtraTabPageIdentify;
                }
            }
            catch (Exception)
            {
            }
        }

        private void barButtonItemLargeButton_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.barButtonItemLargeButton.Down = true;
            this.mRibbonItemStyles = RibbonItemStyles.SmallWithText | RibbonItemStyles.Large;
            if (this.barButtonItemSmallButton.Down)
            {
                this.barButtonItemSmallButton.Down = false;
                this.RefreshToolBarButton2();
            }
            else if (this.barButtonItemSmallText.Down)
            {
                this.barButtonItemSmallText.Down = false;
                this.RefreshToolBarButton2();
            }
            base.ribbon.Height = 0xa1;
        }

        private void barButtonItemLocation_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (this.barButtonItemLocation.Down)
            {
                if (this.userControlLocation.hook == null)
                {
                    this.userControlLocation.hook = base.MapControlEdit.Object;
                }
                this.userControlLocation.InitialControls(this.mEditKind, true);
                base.dockPanelToolbox.Visibility = DockVisibility.Visible;
                this.xtraTabPageLocation.PageEnabled = true;
                this.xtraTabPageLocation.PageVisible = true;
                base.xtraTabToolbox.SelectedTabPage = this.xtraTabPageLocation;
            }
            else
            {
                this.xtraTabPageLocation.PageVisible = false;
            }
        }

        private void barButtonItemLogClear_ItemClick(object sender, ItemClickEventArgs e)
        {
            UserManager.Single.ClearLog();
            this.userControlLog1.Refresh();
        }

        private void barButtonItemLogicCheck_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (this.barButtonItemLogicCheck.Down)
            {
                this.userControlAttriCheck1.Init(this.mEditLayer, base.MapControlEdit.Object);
                this.xtraTabPageLogicCheck.PageVisible = true;
                this.xtraTabControlEdit.SelectedTabPage = this.xtraTabPageLogicCheck;
                base.dockPanelEdit.Visibility = DockVisibility.Visible;
            }
            else
            {
                this.xtraTabPageLogicCheck.PageVisible = false;
                base.dockPanelEdit.Visibility = DockVisibility.Hidden;
            }
        }

        private void barButtonItemLogs_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (this.barButtonItemLogs.Down)
            {
                this.userControlLog1.Init();
                base.xtraTabMain.Visible = true;
                this.xtraTabPageLog.PageVisible = true;
                if (!((this.barButtonItemManageDesignQuery.Down && this.barButtonItemManageDesignEdit.Down) && this.barButtonItemManageDesignYear.Down))
                {
                    base.tabPageMapContol.PageVisible = false;
                }
                base.xtraTabMain.SelectedTabPage = this.xtraTabPageLog;
                base.xtraTabMain.Visible = true;
                base.xtraTabMain.BringToFront();
            }
            else if ((this.mEditKind != "造林") && (this.mEditKind != "采伐"))
            {
                this.pictureBox1.BringToFront();
            }
            else
            {
                this.xtraTabPageLog.PageVisible = false;
                if (!(this.xtraTabPageLog.PageVisible || base.tabPageMapContol.PageVisible))
                {
                    base.tabPageMapContol.Visible = false;
                }
            }
        }

        private void barButtonItemManageDesignEdit_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (this.barButtonItemManageDesignEdit.Down)
            {
                if (!(this.barButtonItemManageDesignQuery.Down || this.barButtonItemManageDesignYear.Down))
                {
                    this.userControlQueryDesign.InitialValue(base.MapControlEdit.Object, this.mEditKind, this.userControlQueryResult1, base.dockPanelBottom);
                }
                this.userControlQueryDesign.SetEdit(true);
                base.xtraTabMain.Visible = true;
                base.xtraTabMain.SelectedTabPage = base.tabPageMapContol;
                base.tabPageMapContol.PageVisible = true;
            }
            else
            {
                this.userControlQueryDesign.SetEdit(false);
                this.xtraTabPageLog.PageVisible = false;
                if (!(this.xtraTabPageLog.PageVisible || base.tabPageMapContol.PageVisible))
                {
                    base.xtraTabMain.Visible = false;
                }
            }
        }

        private void barButtonItemManageDesignQuery_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.barButtonItemManageDesignEdit.Enabled = this.barButtonItemManageDesignQuery.Down;
            if (this.barButtonItemManageDesignQuery.Down)
            {
                base.dockPanelToolbox.Visibility = DockVisibility.Visible;
                this.xtraTabPageDesign.PageVisible = true;
                base.xtraTabToolbox.SelectedTabPage = this.xtraTabPageDesign;
                this.userControlQueryDesign.BringToFront();
                if (!(this.barButtonItemManageDesignEdit.Down || this.barButtonItemManageDesignYear.Down))
                {
                    this.userControlQueryDesign.InitialValue(base.MapControlEdit.Object, this.mEditKind, this.userControlQueryResult1, base.dockPanelBottom);
                }
                this.userControlQueryDesign.SetQuery(true);
                base.xtraTabMain.Visible = true;
                base.xtraTabMain.BringToFront();
                base.xtraTabMain.SelectedTabPage = base.tabPageMapContol;
                base.tabPageMapContol.PageVisible = true;
                base.barStaticItemLocation1.Visibility = BarItemVisibility.Always;
                base.barStaticItemLocation2.Visibility = BarItemVisibility.Always;
                base.barStaticItemLocation3.Visibility = BarItemVisibility.Never;
                base.barStaticItemScale.Visibility = BarItemVisibility.Always;
                base.barEditItemScale.Visibility = BarItemVisibility.Always;
                this.ribbonPageGroupMapView5.Visible = true;
            }
            else
            {
                this.userControlQueryDesign.SetQuery(false);
                if (!this.barButtonItemManageDesignYear.Down)
                {
                    base.barStaticItemLocation1.Visibility = BarItemVisibility.Never;
                    base.barStaticItemLocation2.Visibility = BarItemVisibility.Never;
                    base.barStaticItemLocation3.Visibility = BarItemVisibility.Never;
                    base.barEditItemScale.Visibility = BarItemVisibility.Never;
                    base.barStaticItemScale.Visibility = BarItemVisibility.Never;
                    this.ribbonPageGroupMapView5.Visible = false;
                    base.dockPanelToolbox.Visibility = DockVisibility.Hidden;
                    base.xtraTabMain.Visible = false;
                }
                this.xtraTabPageLog.PageVisible = false;
                if (!(this.xtraTabPageLog.PageVisible || base.tabPageMapContol.PageVisible))
                {
                    base.xtraTabMain.Visible = false;
                }
            }
        }

        private void barButtonItemManageDesignYear_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (this.barButtonItemManageDesignYear.Down)
            {
                base.dockPanelToolbox.Visibility = DockVisibility.Visible;
                this.xtraTabPageDesign.PageVisible = true;
                base.xtraTabToolbox.SelectedTabPage = this.xtraTabPageDesign;
                this.userControlQueryDesign.BringToFront();
                if (!(this.barButtonItemManageDesignQuery.Down || this.barButtonItemManageDesignEdit.Down))
                {
                    this.userControlQueryDesign.InitialValue(base.MapControlEdit.Object, this.mEditKind, this.userControlQueryResult1, base.dockPanelBottom);
                    this.userControlQueryDesign.SetQuery(false);
                    this.userControlQueryDesign.SetConvert(true);
                }
                else
                {
                    this.userControlQueryDesign.SetConvert(true);
                }
                base.xtraTabMain.Visible = true;
                base.xtraTabMain.BringToFront();
                base.xtraTabMain.SelectedTabPage = base.tabPageMapContol;
                base.tabPageMapContol.PageVisible = true;
                base.barStaticItemLocation1.Visibility = BarItemVisibility.Always;
                base.barStaticItemLocation2.Visibility = BarItemVisibility.Always;
                base.barStaticItemLocation3.Visibility = BarItemVisibility.Never;
                base.barStaticItemScale.Visibility = BarItemVisibility.Always;
                base.barEditItemScale.Visibility = BarItemVisibility.Always;
                this.ribbonPageGroupMapView5.Visible = true;
            }
            else
            {
                if (this.barButtonItemManageDesignQuery.Down)
                {
                    this.userControlQueryDesign.SetConvert(false);
                }
                else
                {
                    base.barStaticItemLocation1.Visibility = BarItemVisibility.Never;
                    base.barStaticItemLocation2.Visibility = BarItemVisibility.Never;
                    base.barStaticItemLocation3.Visibility = BarItemVisibility.Never;
                    base.barEditItemScale.Visibility = BarItemVisibility.Never;
                    base.barStaticItemScale.Visibility = BarItemVisibility.Never;
                    this.ribbonPageGroupMapView5.Visible = false;
                    base.dockPanelToolbox.Visibility = DockVisibility.Hidden;
                    base.xtraTabMain.Visible = false;
                }
                if (!(this.xtraTabPageLog.PageVisible || base.tabPageMapContol.PageVisible))
                {
                    base.xtraTabMain.Visible = false;
                }
            }
        }

        private void barButtonItemMapFind_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.xtraTabPageMapFind.PageVisible = this.barButtonItemMapFind.Down;
            if (this.barButtonItemMapFind.Down)
            {
                this.userControlMapFind1.BringToFront();
                this.userControlMapFind1.InitialValue(base.MapControlEdit.Object);
                base.xtraTabToolbox.SelectedTabPage = this.xtraTabPageMapFind;
            }
        }

        private void barButtonItemMapFrame_ItemClick(object sender, ItemClickEventArgs e)
        {
            AxPageLayoutControl pageLayoutControlEdit = base.PageLayoutControlEdit;
            IMapFrame frame = pageLayoutControlEdit.GraphicsContainer.FindFrame(pageLayoutControlEdit.ActiveView.FocusMap) as IMapFrame;
            IFrameProperties properties = (IFrameProperties) frame;
            DevFrame frame2 = new DevFrame(pageLayoutControlEdit.ActiveView);
            if (((properties.Border != null) || (properties.Background != null)) || (properties.Shadow != null))
            {
                OperatorSelect select = new OperatorSelect {
                    Tip = "当前焦点图已存在图框,编辑或删除?"
                };
                select.ShowDialog();
                if (select.DialogResult == DialogResult.No)
                {
                    properties.Border = null;
                    properties.Background = null;
                    properties.Shadow = null;
                    pageLayoutControlEdit.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, null);
                    return;
                }
                if (select.DialogResult == DialogResult.Cancel)
                {
                    return;
                }
            }
            frame2.ShowDialog();
            frame2 = null;
        }

        private void barButtonItemMapGrid_ItemClick(object sender, ItemClickEventArgs e)
        {
            AxPageLayoutControl pageLayoutControlEdit = base.PageLayoutControlEdit;
            IGraphicsContainer pageLayout = pageLayoutControlEdit.PageLayout as IGraphicsContainer;
            IMapFrame frame = pageLayout.FindFrame(pageLayoutControlEdit.ActiveView.FocusMap) as IMapFrame;
            IMapGrids grids = frame as IMapGrids;
            DevGrid grid = new DevGrid(pageLayoutControlEdit.ActiveView);
            if (grids.MapGridCount != 0)
            {
                IMapGrid mapGrid = grids.get_MapGrid(0);
                if (mapGrid is IMeasuredGrid)
                {
                    OperatorSelect select = new OperatorSelect {
                        Tip = "当前焦点图已存在公里网，编辑或删除?"
                    };
                    select.ShowDialog();
                    if (select.DialogResult == DialogResult.Yes)
                    {
                        grid = new DevGrid(pageLayoutControlEdit.ActiveView) {
                            OrigMapGrid = mapGrid
                        };
                        select.Dispose();
                        goto Label_010D;
                    }
                    if (select.DialogResult == DialogResult.No)
                    {
                        grids.DeleteMapGrid(mapGrid);
                        pageLayoutControlEdit.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, null);
                        select.Dispose();
                    }
                }
                else
                {
                    MessageBox.Show("没有可编辑的公里网!");
                }
                return;
            }
        Label_010D:
            grid.ShowDialog();
            grid.Dispose();
            grid = null;
        }

        private void barButtonItemMapLegend_ItemClick(object sender, ItemClickEventArgs e)
        {
            AxPageLayoutControl pageLayoutControlEdit = base.PageLayoutControlEdit;
            new DevLegend { PageLayoutControl = pageLayoutControlEdit.Object as IPageLayoutControl }.ShowDialog();
        }

        private void barButtonItemMapNorthArrow_ItemClick(object sender, ItemClickEventArgs e)
        {
            AxPageLayoutControl pageLayoutControlEdit = base.PageLayoutControlEdit;
            new DevNorthArrowSelector { ActiveView = pageLayoutControlEdit.PageLayout as IActiveView }.ShowDialog();
        }

        private void barButtonItemMapScaleBar_ItemClick(object sender, ItemClickEventArgs e)
        {
            AxPageLayoutControl pageLayoutControlEdit = base.PageLayoutControlEdit;
            new DevScaleBar { ActiveView = pageLayoutControlEdit.PageLayout as IActiveView }.ShowDialog();
        }

        private void barButtonItemMapTable_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void barButtonItemMapText_ItemClick(object sender, ItemClickEventArgs e)
        {
            AxPageLayoutControl pageLayoutControlEdit = base.PageLayoutControlEdit;
            new DevText { ActiveView = pageLayoutControlEdit.ActiveView }.ShowDialog();
        }

        private void barButtonItemOverView_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (this.barButtonItemOverView.Down)
            {
                this.userControlOverView.Visible = true;
                this.splitterControl1.Visible = true;
            }
            else
            {
                this.userControlOverView.Visible = false;
                this.splitterControl1.Visible = false;
            }
        }

        private void barButtonItemPlace_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (this.barButtonItemPlace.Down)
            {
                base.dockPanelToolbox.Visibility = DockVisibility.Visible;
                this.xtraTabPagePlace.PageVisible = true;
                base.xtraTabToolbox.SelectedTabPage = this.xtraTabPagePlace;
                this.userControlPlace1.hook = base.MapControlEdit.Object;
            }
            else
            {
                this.xtraTabPagePlace.PageVisible = false;
            }
        }

        private void barButtonItemPreview_ItemClick(object sender, ItemClickEventArgs e)
        {
            IActiveView activeView = null;
            if (base.xtraTabMain.SelectedTabPageIndex == 0)
            {
                activeView = base.MapControlEdit.ActiveView;
            }
            else
            {
                activeView = base.PageLayoutControlEdit.ActiveView;
            }
            AxPageLayoutControl pageLayoutControlEdit = base.PageLayoutControlEdit;
            new ClsPrintView { 
                PrintPreViewWindow = { Owner = this },
                PageLayoutControl = pageLayoutControlEdit.Object as IPageLayoutControl3,
                ActiveView = activeView,
                Document = this.doc
            }.PreView();
        }

        private void barButtonItemPrint_ItemClick(object sender, ItemClickEventArgs e)
        {
            IActiveView activeView = null;
            if (base.xtraTabMain.SelectedTabPageIndex == 0)
            {
                activeView = base.MapControlEdit.ActiveView;
            }
            else
            {
                activeView = base.PageLayoutControlEdit.ActiveView;
            }
            AxPageLayoutControl pageLayoutControlEdit = base.PageLayoutControlEdit;
            ClsPrint print = new ClsPrint {
                Document = this.doc,
                PageLayoutControl = pageLayoutControlEdit.Object as IPageLayoutControl3,
                ActiveView = activeView
            };
            print.Print();
            print.Dispose();
            print = null;
        }

        private void barButtonItemPrintSet_ItemClick(object sender, ItemClickEventArgs e)
        {
            AxPageLayoutControl pageLayoutControlEdit = base.PageLayoutControlEdit;
            PrintSetupDialogEx ex = new PrintSetupDialogEx {
                Parent = base.Handle,
                Document = this.doc,
                PageLayoutControl = pageLayoutControlEdit.Object as IPageLayoutControl3,
                UseEXDialog = true
            };
            ex.ShowDialog();
            ex.Dispose();
        }

        private void barButtonItemQueryKind_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.xtraTabPageKind.PageVisible = this.barButtonItemQueryKind.Down;
            if (this.barButtonItemQueryKind.Down)
            {
                if (this.mEditKind == "造林")
                {
                    this.userControlQueryCF21.Visible = true;
                    this.userControlQueryCF21.BringToFront();
                    this.userControlQueryCF21.InitialValue(base.MapControlEdit.Object, this.mEditKind, "ZaoLin");
                    this.userControlQueryCF21.labelLocation.Text = "      " + this.mEditKind + "类型查询";
                    base.xtraTabToolbox.SelectedTabPage = this.xtraTabPageKind;
                }
                else if (this.mEditKind == "采伐")
                {
                    this.userControlQueryCF21.Visible = true;
                    this.userControlQueryCF21.BringToFront();
                    this.userControlQueryCF21.InitialValue(base.MapControlEdit.Object, this.mEditKind, "CaiFa");
                    this.userControlQueryCF21.labelLocation.Text = "      " + this.mEditKind + "类型查询";
                    base.xtraTabToolbox.SelectedTabPage = this.xtraTabPageKind;
                }
                else if ((((this.mEditKind != "林业工程") && !this.mEditKind.Contains("征占用")) && (!this.mEditKind.Contains("火灾") && !this.mEditKind.Contains("自然灾害"))) && (!this.mEditKind.Contains("案件") && this.mEditKind.Contains("小班")))
                {
                    base.xtraTabToolbox.SelectedTabPage = this.xtraTabPageKind;
                    this.userControlQueryXB21.Visible = true;
                    this.userControlQueryXB21.BringToFront();
                    this.userControlQueryXB21.InitialValue(base.MapControlEdit.Object, this.mEditLayer);
                    if (this.mEditKind.Contains("年度"))
                    {
                        this.userControlQueryXB21.labelLocation.Text = "      小班类型查询";
                    }
                    this.userControlQueryXB21.Dock = DockStyle.Fill;
                }
            }
        }

        private void barButtonItemQueryTF_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (this.barButtonItemQueryTF.Down)
            {
                base.dockPanelToolbox.Visibility = DockVisibility.Visible;
                this.xtraTabPageTFH.PageVisible = true;
                base.xtraTabToolbox.SelectedTabPage = this.xtraTabPageTFH;
                this.userControlQueryTFH1.hook = base.MapControlEdit.Object;
            }
            else
            {
                this.xtraTabPageTFH.PageVisible = false;
            }
        }

        private void barButtonItemQueryXB_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                this.barButtonItemQueryXB.ButtonStyle = BarButtonStyle.Check;
                base.xtraTabPageQuery.PageVisible = this.barButtonItemQueryXB.Down;
                this.userControlQueryXB.Visible = this.barButtonItemQueryXB.Down;
                if (this.barButtonItemQueryXB.Down)
                {
                    this.userControlQueryXB.BringToFront();
                    this.userControlQueryXB.labelLocation.Visible = true;
                    this.userControlQueryXB.InitialValue(base.MapControlEdit.Object, this.mEditLayer, base.MapControlEdit.Map, this.userControlQueryResult1, base.dockPanelBottom);
                    base.xtraTabToolbox.SelectedTabPage = base.xtraTabPageQuery;
                }
                else
                {
                    base.xtraTabPageQuery.PageVisible = false;
                }
            }
            catch (Exception)
            {
            }
        }

        private void barButtonItemQueryYear_ItemClick(object sender, ItemClickEventArgs e)
        {
            base.xtraTabPageQuery.PageVisible = this.barButtonItemQueryYear.Down;
        }

        private void barButtonItemQueryZT_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                this.barButtonItemQueryZT.ButtonStyle = BarButtonStyle.Check;
                base.xtraTabPageQuery.PageVisible = this.barButtonItemQueryZT.Down;
                if (this.barButtonItemQueryZT.Down)
                {
                    if (this.mEditKind == "造林")
                    {
                        this.userControlQueryZL1.Visible = true;
                        this.userControlQueryZL1.BringToFront();
                        this.userControlQueryZL1.InitialValue(base.MapControlEdit.Object, this.mEditLayer, base.MapControlEdit.Map, this.userControlQueryResult1, base.dockPanelBottom);
                        base.xtraTabToolbox.SelectedTabPage = base.xtraTabPageQuery;
                    }
                    else if (this.mEditKind == "采伐")
                    {
                        this.userControlQueryCF1.Visible = true;
                        this.userControlQueryCF1.BringToFront();
                        this.userControlQueryCF1.InitialValue(base.MapControlEdit.Object, this.mEditLayer, base.MapControlEdit.Map, this.userControlQueryResult1, base.dockPanelBottom);
                        base.xtraTabToolbox.SelectedTabPage = base.xtraTabPageQuery;
                    }
                    else if ((((this.mEditKind != "林业工程") && !this.mEditKind.Contains("征占用")) && (!this.mEditKind.Contains("火灾") && !this.mEditKind.Contains("自然灾害"))) && this.mEditKind.Contains("案件"))
                    {
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        private void barButtonItemSave_ItemClick(object sender, ItemClickEventArgs e)
        {
            IMxdContents pMxdContents = null;
            AxMapControl mapControlEdit = base.MapControlEdit;
            if (mapControlEdit != null)
            {
                pMxdContents = mapControlEdit.Object as IMxdContents;
            }
            else
            {
                pMxdContents = base.PageLayoutControlEdit.Object as IMxdContents;
            }
            string sFileName = UtilFactory.GetConfigOpt().RootPath + @"\test.mxd";
            if (GISFunFactory.CoreFun.SaveMapDocument(pMxdContents, sFileName, true, true, true, false))
            {
                MessageBox.Show("存储完成！");
            }
        }

        private void barButtonItemSelectedFeaturesReport_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (this.barButtonItemSelectedFeaturesReport.Down)
            {
                base.dockPanelBottom.Visibility = DockVisibility.Visible;
                this.xtraTabPage3.PageVisible = true;
                this.xtraTabQuery.SelectedTabPage = this.xtraTabPage3;
                this.userControlSelectFeatureResport21.hook = base.MapControlEdit.Object;
                this.userControlSelectFeatureResport21.InitialValue();
            }
            else
            {
                this.xtraTabPage3.PageVisible = false;
            }
        }

        private void barButtonItemSelectLayerSet_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (this.barButtonItemSelectLayerSet.Down)
            {
                this.xtraTabPageSelect.PageVisible = true;
                base.xtraTabToolbox.SelectedTabPage = this.xtraTabPageSelect;
                this.userControlSelectLayerSet1.Hook = base.MapControlEdit.Object;
                this.userControlSelectLayerSet1.InitialValue();
            }
            else
            {
                this.xtraTabPageSelect.PageVisible = false;
            }
        }

        private void barButtonItemSetDRG_ItemClick(object sender, ItemClickEventArgs e)
        {
            new FormDXTSet().ShowDialog(this);
        }

        private void barButtonItemSmallButton_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.barButtonItemSmallButton.Down = true;
            this.mRibbonItemStyles = RibbonItemStyles.SmallWithoutText;
            if (this.barButtonItemLargeButton.Down)
            {
                this.barButtonItemLargeButton.Down = false;
                this.RefreshToolBarButton2();
            }
            else if (this.barButtonItemSmallText.Down)
            {
                this.barButtonItemSmallText.Down = false;
                this.RefreshToolBarButton2();
            }
            base.ribbon.ToolbarLocation = RibbonQuickAccessToolbarLocation.Above;
            base.ribbon.Height = 80;
        }

        private void barButtonItemSmallText_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.barButtonItemSmallText.Down = true;
            this.mRibbonItemStyles = RibbonItemStyles.SmallWithText;
            if (this.barButtonItemLargeButton.Down)
            {
                this.barButtonItemLargeButton.Down = false;
                this.RefreshToolBarButton2();
            }
            else if (this.barButtonItemSmallButton.Down)
            {
                this.barButtonItemSmallButton.Down = false;
                this.RefreshToolBarButton2();
            }
        }

        private void barButtonItemStatic_ItemClick(object sender, ItemClickEventArgs e)
        {
        }

        private void barButtonItemTOC_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.barButtonItemTOC.ButtonStyle = BarButtonStyle.Check;
            if (this.barButtonItemTOC.Down)
            {
                this.barButtonItemTOC2.Down = false;
                this.barButtonItemOverView.Enabled = true;
                base.axTOCControl.SetBuddyControl(base.MapControlEdit);
                base.axTOCControl.Update();
            }
            else
            {
                this.barButtonItemOverView.Enabled = false;
            }
            this.userControlLayerControl.Visible = this.barButtonItemTOC2.Down;
            base.xtraTabPageTOC.PageVisible = this.barButtonItemTOC.Down;
            if (base.xtraTabPageTOC.PageVisible)
            {
                base.dockPanelToolbox.Visibility = DockVisibility.Visible;
            }
            base.axTOCControl.Visible = this.barButtonItemTOC.Down;
            base.xtraTabToolbox.SelectedTabPageIndex = 0;
            base.axTOCControl.Dock = DockStyle.Fill;
            base.axTOCControl.BringToFront();
            base.axTOCControl.Refresh();
            if (this.barButtonItemOverView.Enabled && this.barButtonItemOverView.Down)
            {
                this.userControlOverView.Visible = true;
                this.splitterControl1.Visible = true;
            }
            else
            {
                this.userControlOverView.Visible = false;
                this.splitterControl1.Visible = false;
            }
        }

        private void barButtonItemTOC2_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (this.barButtonItemTOC2.Down)
            {
                this.barButtonItemTOC.Down = false;
                this.barButtonItemOverView.Enabled = true;
                this.userControlLayerControl.Map = base.MapControlEdit.Map;
                this.userControlLayerControl.InitialValue();
            }
            else
            {
                this.barButtonItemOverView.Enabled = false;
            }
            base.xtraTabPageTOC.PageVisible = this.barButtonItemTOC2.Down;
            base.axTOCControl.Visible = this.barButtonItemTOC.Down;
            this.userControlLayerControl.Visible = this.barButtonItemTOC2.Down;
            base.xtraTabToolbox.SelectedTabPageIndex = 0;
            this.userControlLayerControl.BringToFront();
            if (base.xtraTabPageTOC.PageVisible)
            {
                base.dockPanelToolbox.Visibility = DockVisibility.Visible;
            }
            if (this.barButtonItemOverView.Enabled && this.barButtonItemOverView.Down)
            {
                this.userControlOverView.Visible = true;
                this.splitterControl1.Visible = true;
            }
            else
            {
                this.userControlOverView.Visible = false;
                this.splitterControl1.Visible = false;
            }
        }

        private void barButtonItemToolbox_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (this.barButtonToolbox.Down)
            {
                base.dockPanelToolbox.Visibility = DockVisibility.Visible;
            }
            else
            {
                base.dockPanelToolbox.Visibility = DockVisibility.Hidden;
            }
        }

        private void barButtonItemToolView_ItemClick(object sender, ItemClickEventArgs e)
        {
            base.ribbon.Minimized = !base.ribbon.Minimized;
            base.barButtonItemToolView.Caption = "功能区最小化";
        }

        private void barButtonItemUserEdit_ItemClick(object sender, ItemClickEventArgs e)
        {
            new FormUserManage().ShowDialog(this);
        }

        private void barButtonItemUserList_ItemClick(object sender, ItemClickEventArgs e)
        {
            new FormUserManage().ShowDialog();
        }

        private void barButtonItemVertexList_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (this.mFormVertexList == null)
            {
                this.mFormVertexList = new FormVertexList(base.MapControlEdit.Object);
                this.mFormVertexList.Owner = this;
            }
            this.mFormVertexList.Init();
            this.mFormVertexList.Show();
        }

        private void barEditItemScale_EditValueChanged(object sender, EventArgs e)
        {
            if (!this.mSelection)
            {
                this.mSelection = true;
                if (!base.barEditItemScale.EditValue.ToString().Contains("1:"))
                {
                    base.barEditItemScale.EditValue = "1:" + base.barEditItemScale.EditValue.ToString();
                }
                if (base.xtraTabMain.SelectedTabPageIndex == 0)
                {
                    this.SetMapScale(base.MapControlEdit.Map, base.barEditItemScale.EditValue.ToString());
                }
                else if (base.xtraTabMain.SelectedTabPageIndex == 1)
                {
                    this.SetMapScale(base.PageLayoutControlEdit.ActiveView.FocusMap, base.barEditItemScale.EditValue.ToString());
                }
                base.textBox1.Text = base.barEditItemScale.EditValue.ToString();
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
                if (!base.barEditItemScale.EditValue.ToString().Contains("1:"))
                {
                    base.barEditItemScale.EditValue = "1:" + base.barEditItemScale.EditValue.ToString();
                }
                if (base.xtraTabMain.SelectedTabPageIndex == 0)
                {
                    this.SetMapScale(base.MapControlEdit.Map, base.barEditItemScale.EditValue.ToString());
                }
                else if (base.xtraTabMain.SelectedTabPageIndex == 1)
                {
                    this.SetMapScale(base.PageLayoutControlEdit.ActiveView.FocusMap, base.barEditItemScale.EditValue.ToString());
                }
                base.textBox1.Text = base.barEditItemScale.EditValue.ToString();
                this.mSelection = false;
            }
        }

        private void barEditItemScale_ShowingEditor(object sender, ItemCancelEventArgs e)
        {
            if (!this.mSelection)
            {
                this.mSelection = true;
                if (!base.barEditItemScale.EditValue.ToString().Contains("1:"))
                {
                    base.barEditItemScale.EditValue = "1:" + base.barEditItemScale.EditValue.ToString();
                }
                if (base.xtraTabMain.SelectedTabPageIndex == 0)
                {
                    this.SetMapScale(base.MapControlEdit.Map, base.barEditItemScale.EditValue.ToString());
                }
                else if (base.xtraTabMain.SelectedTabPageIndex == 1)
                {
                    this.SetMapScale(base.PageLayoutControlEdit.ActiveView.FocusMap, base.barEditItemScale.EditValue.ToString());
                }
                base.textBox1.Text = base.barEditItemScale.EditValue.ToString();
                this.mSelection = false;
            }
        }

        private void barEditItemScale_ShownEditor(object sender, ItemClickEventArgs e)
        {
            if (!this.mSelection)
            {
                this.mSelection = true;
                if (!base.barEditItemScale.EditValue.ToString().Contains("1:"))
                {
                    base.barEditItemScale.EditValue = "1:" + base.barEditItemScale.EditValue.ToString();
                }
                if (base.xtraTabMain.SelectedTabPageIndex == 0)
                {
                    this.SetMapScale(base.MapControlEdit.Map, base.barEditItemScale.EditValue.ToString());
                }
                else if (base.xtraTabMain.SelectedTabPageIndex == 1)
                {
                    this.SetMapScale(base.PageLayoutControlEdit.ActiveView.FocusMap, base.barEditItemScale.EditValue.ToString());
                }
                base.textBox1.Text = base.barEditItemScale.EditValue.ToString();
                this.mSelection = false;
            }
        }

        private void bbiDLandScape_ItemClick(object sender, ItemClickEventArgs e)
        {
            IPageLayoutControl3 control = base.PageLayoutControlEdit.Object as IPageLayoutControl3;
            TemplateCartoManager manager = new TemplateCartoManager();
            this.userControlOverView.MapControlOverView.Update();
        }

        private void bbiDPortrit_ItemClick(object sender, ItemClickEventArgs e)
        {
            IPageLayoutControl3 control = base.PageLayoutControlEdit.Object as IPageLayoutControl3;
            TemplateCartoManager manager = new TemplateCartoManager();
            this.userControlOverView.MapControlOverView.Update();
        }

        private void bbiLandScape_ItemClick(object sender, ItemClickEventArgs e)
        {
            IPageLayoutControl3 control = base.PageLayoutControlEdit.Object as IPageLayoutControl3;
            TemplateCartoManager manager = new TemplateCartoManager();
            this.userControlOverView.MapControlOverView.Update();
        }

        private void bbiNormal_ItemClick(object sender, ItemClickEventArgs e)
        {
            new TemplateCartoManager().NormalCarto((IPageLayoutControl3) base.PageLayoutControlEdit.Object);
        }

        private void bbiNPortrit_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmLoadTemplate template = new frmLoadTemplate();
            template.Init(base.PageLayoutControlEdit.Object);
            template.ShowDialog();
        }

        private void bbiPortrit_ItemClick(object sender, ItemClickEventArgs e)
        {
            IPageLayoutControl3 control = base.PageLayoutControlEdit.Object as IPageLayoutControl3;
            TemplateCartoManager manager = new TemplateCartoManager();
            this.userControlOverView.MapControlOverView.Update();
        }

        private void CreateCommand(ICommand pCommand, ref BarButtonItem pItem, ArrayList pButtonCollection, int imageIndex, bool beginGroup, object hook, string tooltip)
        {
            try
            {
                if (pCommand != null)
                {
                    ArrayList tag;
                    pCommand.OnCreate(hook);
                    pItem.Enabled = pCommand.Enabled;
                    if (tooltip != "")
                    {
                        pItem.Hint = tooltip;
                    }
                    else
                    {
                        pItem.Hint = pCommand.Tooltip;
                    }
                    if (pItem.Tag != null)
                    {
                        tag = pItem.Tag as ArrayList;
                        tag.Add(pCommand);
                        pItem.Tag = tag;
                    }
                    else
                    {
                        tag = new ArrayList {
                            pCommand
                        };
                        pItem.Tag = tag;
                    }
                    if (pCommand is ITool)
                    {
                        pItem.ButtonStyle = BarButtonStyle.Check;
                        pItem.GroupIndex = 1;
                    }
                    try
                    {
                        this.mCommandToolItems.Add(pItem);
                    }
                    catch (Exception)
                    {
                        this.mCommandToolItems.Remove(pCommand.Name);
                        this.mCommandToolItems.Add(pItem);
                    }
                    ICommand command = pCommand;
                    try
                    {
                        pButtonCollection.Add(command);
                    }
                    catch (Exception)
                    {
                    }
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "GXFormMainFrame.FormMainEdit", "CreateCommand", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void CreateCommand2(ICommand pCommand, ref BarButtonItem pItem, ArrayList pButtonCollection, int imageIndex, bool beginGroup, object hook, string tooltip)
        {
            try
            {
                if (pCommand != null)
                {
                    ArrayList tag;
                    pCommand.OnCreate(hook);
                    pItem.Enabled = pCommand.Enabled;
                    if (tooltip != "")
                    {
                        pItem.Hint = tooltip;
                    }
                    else
                    {
                        pItem.Hint = pCommand.Tooltip;
                    }
                    if (pItem.Tag != null)
                    {
                        tag = pItem.Tag as ArrayList;
                        for (int i = 0; i < tag.Count; i++)
                        {
                            ICommand command = tag[i] as ICommand;
                            if (command.Name == pCommand.Name)
                            {
                                tag[i] = pCommand;
                                break;
                            }
                        }
                        pItem.Tag = tag;
                    }
                    else
                    {
                        tag = new ArrayList {
                            pCommand
                        };
                        pItem.Tag = tag;
                    }
                    if (pCommand is ITool)
                    {
                        pItem.ButtonStyle = BarButtonStyle.Check;
                        pItem.GroupIndex = 1;
                    }
                    try
                    {
                        this.mCommandToolItems.Add(pItem);
                    }
                    catch (Exception)
                    {
                        this.mCommandToolItems.Remove(pCommand.Name);
                        this.mCommandToolItems.Add(pItem);
                    }
                    ICommand command2 = pCommand;
                    pButtonCollection.Add(command2);
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "GXFormMainFrame.FormMainEdit", "CreateCommand2", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void DelegateToolBarEvents()
        {
            try
            {
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "GXFormMainFrame.FormMainEdit", "DelegateToolBarEvents", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
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

        private void FormMainFrame_Activated(object sender, EventArgs e)
        {
            base.defaultLookAndFeel1.LookAndFeel.SkinName = "Blue";
        }

        private void FormMainFrame_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                IWorkspaceEdit editWorkspace = EditTask.EditWorkspace as IWorkspaceEdit;
                if (((TaskManageClass.TaskState.ToString() == TaskState.Open.ToString()) && editWorkspace.IsBeingEdited()) && Editor.UniqueInstance.IsBeingEdited)
                {
                    Editor.UniqueInstance.StopEdit();
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "GXFormMainFrame.FormMainEdit", "FormMainFrame_FormClosed", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void FormMainFrame_Load(object sender, EventArgs e)
        {
            base.defaultLookAndFeel1.LookAndFeel.SkinName = "Blue";
         
        }

        private string GetDistName(string scode)
        {
            try
            {
                IFeatureWorkspace editWorkspace = EditTask.EditWorkspace;
                string configValue = UtilFactory.GetConfigOpt().GetConfigValue("CountyCodeTableName");
                ITable table = null;
                if (scode.Length == 6)
                {
                    table = editWorkspace.OpenTable(configValue);
                }
                else if (scode.Length == 9)
                {
                    configValue = UtilFactory.GetConfigOpt().GetConfigValue("TownCodeTableName");
                    table = editWorkspace.OpenTable(configValue);
                }
                if (table != null)
                {
                    int num = table.FindField("code");
                    int index = table.FindField("name");
                    if ((num < 0) || (index < 0))
                    {
                        return "";
                    }
                    IQueryFilter queryFilter = new QueryFilterClass {
                        WhereClause = "code='" + scode + "'"
                    };
                    IRow row = table.Search(queryFilter, false).NextRow();
                    if (row != null)
                    {
                        return row.get_Value(index).ToString();
                    }
                }
                return "";
            }
            catch (Exception)
            {
                return "";
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

        private string GetNullString(int length)
        {
            try
            {
                string str = "";
                for (int i = 0; i < length; i++)
                {
                    str = str + " ";
                }
                return str;
            }
            catch (Exception)
            {
                return "";
            }
        }

        private string GetTaskState(TaskState2 state)
        {
            switch (state)
            {
                case TaskState2.Create:
                    return "创建";

                case TaskState2.Edit:
                    return "编辑";

                case TaskState2.Check:
                    return "通过校验";

                case TaskState2.Submit:
                    return "已提交送审";

                case TaskState2.Unapprove:
                    return "批复修改";

                case TaskState2.Pass:
                    return "已提审批通过";
            }
            return "";
        }

        private void InitializeBaseButtonComm()
        {
            try
            {
                ICommand pCommand = new MapFullExtentCommand();
                this.CreateCommand(pCommand, ref this.barButtonItemFullMap, this.mButtonCollection2, -1, false, base.MapControlEdit.Object, "");
                pCommand = new MapFullExtentCommand();
                this.CreateCommand(pCommand, ref this.barButtonItemFullMap, this.mButtonCollection2, -1, false, base.PageLayoutControlEdit.Object, "");
                pCommand = new MapZoomInTool();
                this.CreateCommand(pCommand, ref this.barButtonItemZoomIn, this.mButtonCollection2, -1, false, base.MapControlEdit.Object, "");
                pCommand = new MapZoomInTool();
                this.CreateCommand(pCommand, ref this.barButtonItemZoomIn, this.mButtonCollection2, -1, false, base.PageLayoutControlEdit.Object, "");
                pCommand = new MapZoomOutTool();
                this.CreateCommand(pCommand, ref this.barButtonItemZoomOut, this.mButtonCollection2, -1, false, base.MapControlEdit.Object, "");
                pCommand = new MapZoomOutTool();
                this.CreateCommand(pCommand, ref this.barButtonItemZoomOut, this.mButtonCollection2, -1, false, base.PageLayoutControlEdit.Object, "");
                pCommand = new MapPanTool();
                this.CreateCommand(pCommand, ref this.barButtonItemPan, this.mButtonCollection2, -1, false, base.MapControlEdit.Object, "");
                pCommand = new MapPanTool();
                this.CreateCommand(pCommand, ref this.barButtonItemPan, this.mButtonCollection2, -1, false, base.PageLayoutControlEdit.Object, "");
                pCommand = new IdentifyTool();
                this.CreateCommand(pCommand, ref this.barButtonItemIdentify, this.mButtonCollection2, -1, false, base.MapControlEdit.Object, "");
                pCommand = new MapRefreshCommand();
                this.CreateCommand(pCommand, ref this.barButtonItemRefresh, this.mButtonCollection2, -1, false, base.MapControlEdit.Object, "");
                pCommand = new MapRefreshCommand();
                this.CreateCommand(pCommand, ref this.barButtonItemRefresh, this.mButtonCollection2, -1, false, base.PageLayoutControlEdit.Object, "");
                pCommand = new MapZoomToLastExtentBackCommand();
                this.CreateCommand(pCommand, ref this.barButtonItemBack, this.mButtonCollection2, -1, false, base.MapControlEdit.Object, "");
                pCommand = new MapZoomToLastExtentForwardCommand();
                this.CreateCommand(pCommand, ref this.barButtonItemForward, this.mButtonCollection2, -1, false, base.MapControlEdit.Object, "");
                pCommand = new FeatureSelectionSelectFeaturesTool();
                this.CreateCommand(pCommand, ref this.barButtonItemSelectFeature, this.mButtonCollection, -1, false, base.MapControlEdit.Object, "");
                pCommand = new FeatureSelectionClearSelectionCommand();
                this.CreateCommand(pCommand, ref this.barButtonItemClearSelectFeature, this.mButtonCollection, -1, false, base.MapControlEdit.Object, "");
                pCommand = new AddTxtPointsCommand();
                this.CreateCommand(pCommand, ref this.barButtonItemAddLayer2, this.mButtonCollection, -1, false, base.MapControlEdit.Object, "添加GPS轨迹点数据");
                pCommand = new MeasureTool();
                this.CreateCommand(pCommand, ref this.barButtonItemMeasure, this.mButtonCollection, -1, false, base.MapControlEdit.Object, "");
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "GXFormMainFrame.FormMainEdit", "InitializeBaseButtonComm", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void InitializeBaseButtonPage()
        {
            try
            {
                this.tc1.SetBuddyControl(base.PageLayoutControlEdit);
                this.tc1.AddItem(new ProxyButton.Undo(), 0, 0, true, 0, esriCommandStyles.esriCommandStyleIconOnly);
                this.tc1.AddItem(new ProxyButton.Redo(), 0, 1, false, 0, esriCommandStyles.esriCommandStyleIconOnly);
                this.tc1.AddItem(new ElementSelect(), 0, -1, true, 0, esriCommandStyles.esriCommandStyleIconOnly);
                this.tc2.SetBuddyControl(base.PageLayoutControlEdit);
                this.tc2.AddItem(new ProxyButton.Undo(), 0, 0, true, 0, esriCommandStyles.esriCommandStyleIconOnly);
                this.tc2.AddItem(new ProxyButton.Redo(), 0, 1, false, 0, esriCommandStyles.esriCommandStyleIconOnly);
                this.tc2.AddItem(new ElementSelect(), 0, -1, true, 0, esriCommandStyles.esriCommandStyleIconOnly);
                ICommand pCommand = new PageZoomIn();
                this.CreateCommand(pCommand, ref this.barButtonItemPageZoomIn, this.mButtonCollection, -1, false, base.PageLayoutControlEdit.Object, "");
                pCommand = new PageZoomOut();
                this.CreateCommand(pCommand, ref this.barButtonItemPageZoomOut, this.mButtonCollection2, -1, true, base.PageLayoutControlEdit.Object, "");
                pCommand = new PageZoomWhole();
                this.CreateCommand(pCommand, ref this.barButtonItemPageWhole, this.mButtonCollection2, -1, true, base.PageLayoutControlEdit.Object, "");
                pCommand = new PagePan();
                this.CreateCommand(pCommand, ref this.barButtonItemPagePan, this.mButtonCollection2, -1, true, base.PageLayoutControlEdit.Object, "");
                pCommand = new PageLast();
                this.CreateCommand(pCommand, ref this.barButtonItemPagePre, this.mButtonCollection2, -1, true, base.PageLayoutControlEdit.Object, "");
                pCommand = new PageNext();
                this.CreateCommand(pCommand, ref this.barButtonItemPageNext, this.mButtonCollection2, -1, true, base.PageLayoutControlEdit.Object, "");
                pCommand = this.tc1.GetItem(2).Command;
                this.CreateCommand(pCommand, ref this.barButtonItemSelectElement, this.mButtonCollection, -1, true, this.tc1.Object, "");
                pCommand = this.tc2.GetItem(2).Command;
                this.CreateCommand(pCommand, ref this.barButtonItemSelectElement, this.mButtonCollection2, -1, true, this.tc2.Object, "");
                pCommand = this.tc1.GetItem(0).Command;
                this.CreateCommand(pCommand, ref this.barButtonItemUndo, this.mButtonCollection, -1, true, this.tc1.Object, "");
                pCommand = this.tc2.GetItem(0).Command;
                this.CreateCommand(pCommand, ref this.barButtonItemUndo, this.mButtonCollection2, -1, true, this.tc2.Object, "");
                pCommand = this.tc1.GetItem(1).Command;
                this.CreateCommand(pCommand, ref this.barButtonItemRedo, this.mButtonCollection, -1, true, this.tc1.Object, "");
                pCommand = this.tc2.GetItem(1).Command;
                this.CreateCommand(pCommand, ref this.barButtonItemRedo, this.mButtonCollection2, -1, true, this.tc2.Object, "");
                pCommand = new Refresh();
                this.CreateCommand(pCommand, ref this.barButtonItemRefresh, this.mButtonCollection2, -1, true, base.PageLayoutControlEdit.Object, "");
                pCommand = new Cartography.Element.Annotate();
                this.CreateCommand(pCommand, ref this.barButtonItemMapComment, this.mButtonCollection2, -1, true, base.PageLayoutControlEdit.Object, "");
                base.PageLayoutControlEdit.OnAfterDraw += new IPageLayoutControlEvents_Ax_OnAfterDrawEventHandler(this.PageLayoutControlEdit_OnAfterDraw);
                base.PageLayoutControlEdit.OnViewRefreshed += new IPageLayoutControlEvents_Ax_OnViewRefreshedEventHandler(this.PageLayoutControlEdit_OnViewRefreshed);
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "GXFormMainFrame.FormMainEdit", "InitializeBaseButtonPage", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainFrameSystem));
            DevExpress.Utils.SuperToolTip superToolTip2 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipItem toolTipItem2 = new DevExpress.Utils.ToolTipItem();
            this.splitterControl1 = new DevExpress.XtraEditors.SplitterControl();
            this.barButtonItemZoomIn = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemZoomOut = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemFullMap = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemPan = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemIdentify = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemBack = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemForward = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemRefresh = new DevExpress.XtraBars.BarButtonItem();
            this.userControlOverView = new GISControlsClass.UserControlOverView();
            this.barButtonItemSelectFeature = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemSelectLayerSet = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemSelectedFeaturesReport = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemClearSelectFeature = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemTOC = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemOverView = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemTOC2 = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPageGroupQueryComm = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.barButtonItemMapFind = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemMeasure = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemAddLayer = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemAddLayer2 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemSave = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemPrint = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemExportImage = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemPrintPreview = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemPrintSet = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemOpen = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemXBSet = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPageGroupXBSet = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroupAddnew = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.barButtonItemInput = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemAddFeature = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemXBUpdate = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPageGroupEdit = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.barButtonItemEditFeature = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemLinkageEdit = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemSplitFeature = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemCombineFeature = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemInputProperty = new DevExpress.XtraBars.BarButtonItem();
            this.popupMenuVertex = new DevExpress.XtraBars.PopupMenu(this.components);
            this.barButtonItemVertexInsert = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemVertexDelete = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemVertexList = new DevExpress.XtraBars.BarButtonItem();
            this.popupMenuLinkage = new DevExpress.XtraBars.PopupMenu(this.components);
            this.barButtonItemLinkageAdd = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemLinkageDelete = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemDeleteFeature = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemBoudarySnap = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPageGroupDelete = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroupEdittool = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.barButtonItemQuickSnap = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemEraseFeature = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemCutFeature = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemIdentify2 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemShapeCopy = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPageGroupMapView = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.popupMenuMapView = new DevExpress.XtraBars.PopupMenu(this.components);
            this.ribbonPageGroupCommEdit = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.barButtonItemShapePaste = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemEditUndo = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemEditRedo = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPageGroupDataCheck = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroupToplogic2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.barButtonItemNessRule = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemCheckDist = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemTotalLayer = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemCheckLayers = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemCheckBoundary = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemCheckRepeat = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemCheckGap = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPageGroupLogic = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.barButtonItemLogicCheck = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPageGroupToplogic = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.barButtonItemCheckSelfIntersect = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemCheckOverlap = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemCheckArea = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemCheckAngle = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemClearTopErr = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemOverlapCombine = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemOverlapConvert = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemOverlapDelete = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemSimplify = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemPointDelete = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemLocation = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemPlace = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemQueryZT = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemQueryKind = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemQueryYear = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPageGroupTopoModify = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.popupMenuEdit = new DevExpress.XtraBars.PopupMenu(this.components);
            this.xtraTabControlEdit = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPageAttribute = new DevExpress.XtraTab.XtraTabPage();
            this.userControlAttrEdit1 = new AttributesEdit.UserControlAttrEdit();
            this.xtraTabPageLogicCheck = new DevExpress.XtraTab.XtraTabPage();
            this.userControlAttriCheck1 = new AttributesEdit.UserControlAttriCheck();
            this.xtraTabPageInputData = new DevExpress.XtraTab.XtraTabPage();
            this.userControlInputData = new DataEdit.UserControlInputData2();
            this.xtraTabPageUpdate = new DevExpress.XtraTab.XtraTabPage();
            this.userControlUpdate1 = new AttributesEdit.UserControlUpdate();
            this.userControlInfo = new QueryCommon.UserControlInfo();
            this.userControlLayerControl = new GISControlsClass.UserControlLayerControl();
            this.xtraTabPageSelect = new DevExpress.XtraTab.XtraTabPage();
            this.userControlSelectLayerSet1 = new GISControlsClass.UserControlSelectLayerSet();
            this.ribbonPageGroupQuery = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.barButtonItemQueryTF = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPageGroupQuery2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.barButtonItemQueryXB = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPageGroupMapView2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroupMapView3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.xtraTabPageMapFind = new DevExpress.XtraTab.XtraTabPage();
            this.userControlMapFind1 = new QueryCommon.UserControlMapFind();
            this.xtraTabPageLocation = new DevExpress.XtraTab.XtraTabPage();
            this.userControlLocation = new QueryCommon.UserControlLocation();
            this.ribbonPageGroupMxt = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.barButtonItemZone = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemDesign = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemNormal = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPageGroupPageTool = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.barButtonItemMapFrame = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemMapGrid = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemMapLegend = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemMapScaleBar = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemScaleText = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemMapNorthArrow = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemMapText = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemMapComment = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemMapTable = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPageGroupPageView = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.barButtonItemPageWhole = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemPageZoomIn = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemPageZoomOut = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemPagePan = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemSelectElement = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemUndo = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemRedo = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPageGroupMapView4 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.barButtonItemPagePre = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemPageNext = new DevExpress.XtraBars.BarButtonItem();
            this.xtraTabPageXBchange = new DevExpress.XtraTab.XtraTabPage();
            this.userControlXBGrowth1 = new DataEdit.UserControlXBGrowth();
            this.userControlXBLayerCombine1 = new DataEdit.UserControlXBLayerCombine();
            this.userControlXBSet31 = new DataEdit.UserControlXBSet3();
            this.userControlXBSet21 = new DataEdit.UserControlXBSet2();
            this.userControlInputYG1 = new DataEdit.UserControlInputYG();
            this.userControlXBSet1 = new DataEdit.UserControlXBSet();
            this.userControlQueryResult1 = new QueryCommon.UserControlQueryResult();
            this.barButtonToolbox = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonToolView = new DevExpress.XtraBars.BarButtonItem();
            this.barEditItem1 = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.barSubItemButtonStyle = new DevExpress.XtraBars.BarSubItem();
            this.barButtonItemLargeButton = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemSmallButton = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemSmallText = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonGroup1 = new DevExpress.XtraBars.BarButtonGroup();
            this.userControlQueryXB = new QueryAnalysic.UserControlQueryXB();
            this.ribbonPageGroupCaoTu = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.barButtonItemInputYG = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemInputZT = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemInputDC = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemInputOther = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemLayerCombine = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPageGroupXB = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.barButtonItemGrowthModel = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemXBEdit = new DevExpress.XtraBars.BarButtonItem();
            this.xtraTabQuery = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
            this.userControlQueryResult2 = new QueryCommon.UserControlQueryResult();
            this.xtraTabPage3 = new DevExpress.XtraTab.XtraTabPage();
            this.userControlSelectFeatureResport21 = new GISControlsClass.UserControlSelectFeatureResport2();
            this.barButtonItemAddLayer3 = new DevExpress.XtraBars.BarButtonItem();
            this.xtraTabPageAddRasterlayer = new DevExpress.XtraTab.XtraTabPage();
            this.userControlImageGeoReference1 = new DataEdit.UserControlImageGeoReference();
            this.barButtonItemReportCF1 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemChartCF = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemReportZL = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemChartZL = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemStatic = new DevExpress.XtraBars.BarButtonItem();
            this.xtraTabPagePlace = new DevExpress.XtraTab.XtraTabPage();
            this.userControlPlace1 = new QueryCommon.UserControlPlace();
            this.xtraTabPageTFH = new DevExpress.XtraTab.XtraTabPage();
            this.userControlQueryTFH1 = new QueryAnalysic.UserControlQueryTFH();
            this.userControlQueryCF1 = new QueryAnalysic.UserControlQueryCF();
            this.xtraTabPageKind = new DevExpress.XtraTab.XtraTabPage();
            this.userControlQueryXB21 = new QueryAnalysic.UserControlQueryXB2();
            this.userControlQueryCF21 = new QueryAnalysic.UserControlQueryCF2();
            this.userControlQueryZL1 = new QueryAnalysic.UserControlQueryZL();
            this.ribbonPageDataManager = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPageGroupIO = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.barButtonItemDataImput = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemDataOutput = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPageGroupDataUpdata = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroupBack = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.barButtonItemBackup = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemRestore = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemBackup2 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemRestore2 = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPageGroupMapView5 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageSystemManager = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroupManageUser = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.barButtonItemUserList = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemUserAdd = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemUserEdit = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemUserDelete = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemUserKey = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPageGroupLogs = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.barButtonItemLogs = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemLogDelete = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemLogClear = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPageGroupDBManage = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.barButtonItemDBConnect = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemDBUpdata = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemDBNew = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemDBLoadData = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemDBDelete = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPageGroupSet = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.barButtonItemSetDRG = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPageGroupManageDesign = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.barButtonItemManageDesignQuery = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemManageDesignEdit = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemManageDesignYear = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem4 = new DevExpress.XtraBars.BarButtonItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.xtraTabPageLog = new DevExpress.XtraTab.XtraTabPage();
            this.userControlLog1 = new OperateLog.UserControlLog();
            this.userControlQueryDesign = new QueryAnalysic.UserControlQueryDesign();
            this.xtraTabPageDesign = new DevExpress.XtraTab.XtraTabPage();
            ((System.ComponentModel.ISupportInitialize)(this.applicationMenu1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axTOCControl)).BeginInit();
            this.dockPanelBottom.SuspendLayout();
            this.dockPanelBottom_Container.SuspendLayout();
            this.dockPanelEdit.SuspendLayout();
            this.dockPanelEdit_Container.SuspendLayout();
            this.dockPanelToolbox.SuspendLayout();
            this.dockPanelToolbox_Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MapControlEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PageLayoutControlEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            this.tabPageMapContol.SuspendLayout();
            this.tabPagePagelayoutContol.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabMain)).BeginInit();
            this.xtraTabMain.SuspendLayout();
            this.xtraTabPageIdentify.SuspendLayout();
            this.xtraTabPageQuery.SuspendLayout();
            this.xtraTabPageTOC.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabToolbox)).BeginInit();
            this.xtraTabToolbox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenuVertex)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenuLinkage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenuMapView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenuEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControlEdit)).BeginInit();
            this.xtraTabControlEdit.SuspendLayout();
            this.xtraTabPageAttribute.SuspendLayout();
            this.xtraTabPageLogicCheck.SuspendLayout();
            this.xtraTabPageInputData.SuspendLayout();
            this.xtraTabPageUpdate.SuspendLayout();
            this.xtraTabPageSelect.SuspendLayout();
            this.xtraTabPageMapFind.SuspendLayout();
            this.xtraTabPageLocation.SuspendLayout();
            this.xtraTabPageXBchange.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabQuery)).BeginInit();
            this.xtraTabQuery.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
            this.xtraTabPage2.SuspendLayout();
            this.xtraTabPage3.SuspendLayout();
            this.xtraTabPageAddRasterlayer.SuspendLayout();
            this.xtraTabPagePlace.SuspendLayout();
            this.xtraTabPageTFH.SuspendLayout();
            this.xtraTabPageKind.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.xtraTabPageLog.SuspendLayout();
            this.xtraTabPageDesign.SuspendLayout();
            this.SuspendLayout();
            // 
            // applicationMenu1
            // 
            this.applicationMenu1.ItemLinks.Add(this.barButtonItemOpen, true);
            this.applicationMenu1.ItemLinks.Add(this.barButtonItemExportImage, true);
            this.applicationMenu1.ItemLinks.Add(this.barButtonItemPrintSet, true);
            this.applicationMenu1.ItemLinks.Add(this.barButtonItemPrintPreview);
            this.applicationMenu1.ItemLinks.Add(this.barButtonItemPrint);
            // 
            // axTOCControl
            // 
            this.axTOCControl.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axTOCControl.OcxState")));
            this.axTOCControl.Size = new System.Drawing.Size(266, 307);
            // 
            // defaultLookAndFeel1
            // 
            this.defaultLookAndFeel1.LookAndFeel.SkinName = "Blue";
            // 
            // dockPanelBottom
            // 
            this.dockPanelBottom.Location = new System.Drawing.Point(0, 544);
            this.dockPanelBottom.SavedDock = DevExpress.XtraBars.Docking.DockingStyle.Float;
            this.dockPanelBottom.Size = new System.Drawing.Size(1124, 200);
            // 
            // dockPanelBottom_Container
            // 
            this.dockPanelBottom_Container.Controls.Add(this.xtraTabQuery);
            this.dockPanelBottom_Container.Size = new System.Drawing.Size(1118, 168);
            // 
            // dockPanelEdit
            // 
            this.dockPanelEdit.FloatSize = new System.Drawing.Size(300, 600);
            this.dockPanelEdit.Location = new System.Drawing.Point(886, 153);
            this.dockPanelEdit.OriginalSize = new System.Drawing.Size(400, 200);
            this.dockPanelEdit.Size = new System.Drawing.Size(400, 622);
            // 
            // dockPanelEdit_Container
            // 
            this.dockPanelEdit_Container.Controls.Add(this.xtraTabControlEdit);
            this.dockPanelEdit_Container.Size = new System.Drawing.Size(394, 590);
            // 
            // dockPanelToolbox
            // 
            this.dockPanelToolbox.OriginalSize = new System.Drawing.Size(280, 200);
            this.dockPanelToolbox.SavedDock = DevExpress.XtraBars.Docking.DockingStyle.Left;
            this.dockPanelToolbox.SavedIndex = 0;
            this.dockPanelToolbox.Size = new System.Drawing.Size(280, 588);
            this.dockPanelToolbox.Visibility = DevExpress.XtraBars.Docking.DockVisibility.Hidden;
            // 
            // dockPanelToolbox_Container
            // 
            this.dockPanelToolbox_Container.Size = new System.Drawing.Size(272, 561);
            // 
            // imageCollection1
            // 
            this.imageCollection1.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection1.ImageStream")));
            this.imageCollection1.TransparentColor = System.Drawing.Color.White;
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
            this.imageCollection1.Images.SetKeyName(304, "select_by_polygon.bmp");
            this.imageCollection1.Images.SetKeyName(305, "SelectedFeaturesReport4.bmp");
            this.imageCollection1.Images.SetKeyName(306, "清除选择要素2.bmp");
            this.imageCollection1.Images.SetKeyName(307, "设置可选图层3.bmp");
            this.imageCollection1.Images.SetKeyName(308, "选择要素2.bmp");
            this.imageCollection1.Images.SetKeyName(309, "selection_1_2.bmp");
            this.imageCollection1.Images.SetKeyName(310, "layer_vector.png");
            this.imageCollection1.Images.SetKeyName(311, "map_add2.png");
            this.imageCollection1.Images.SetKeyName(312, "map_delete.png");
            this.imageCollection1.Images.SetKeyName(313, "draw_ring.png");
            this.imageCollection1.Images.SetKeyName(314, "(11,49).png");
            this.imageCollection1.Images.SetKeyName(315, "(28,14).png");
            this.imageCollection1.Images.SetKeyName(316, "(30,04).png");
            this.imageCollection1.Images.SetKeyName(317, "(35,20).png");
            this.imageCollection1.Images.SetKeyName(318, "(36,32).png");
            this.imageCollection1.Images.SetKeyName(319, "(40,32).png");
            this.imageCollection1.Images.SetKeyName(320, "(41,31).png");
            this.imageCollection1.Images.SetKeyName(321, "(42,20).png");
            this.imageCollection1.Images.SetKeyName(322, "aol_mail.png");
            this.imageCollection1.Images.SetKeyName(323, "draw_island.png");
            this.imageCollection1.Images.SetKeyName(324, "draw_wave.png");
            this.imageCollection1.Images.SetKeyName(325, "edit_diff.png");
            this.imageCollection1.Images.SetKeyName(326, "sql_join_inner.png");
            this.imageCollection1.Images.SetKeyName(327, "sql_join_outer.png");
            this.imageCollection1.Images.SetKeyName(328, "sql_join_outer_exclude.png");
            this.imageCollection1.Images.SetKeyName(329, "(00,31).png");
            this.imageCollection1.Images.SetKeyName(330, "(03,11).png");
            this.imageCollection1.Images.SetKeyName(331, "(03,43).png");
            this.imageCollection1.Images.SetKeyName(332, "(08,34).png");
            this.imageCollection1.Images.SetKeyName(333, "(25,02).png");
            this.imageCollection1.Images.SetKeyName(334, "(33,14).png");
            this.imageCollection1.Images.SetKeyName(335, "(34,28).png");
            this.imageCollection1.Images.SetKeyName(336, "(39,04).png");
            this.imageCollection1.Images.SetKeyName(337, "(42,05).png");
            this.imageCollection1.Images.SetKeyName(338, "(42,41).png");
            this.imageCollection1.Images.SetKeyName(339, "(45,28).png");
            this.imageCollection1.Images.SetKeyName(340, "(48,36).png");
            this.imageCollection1.Images.SetKeyName(341, "web design_16_hot.png");
            // 
            // imageCollection2
            // 
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
            this.imageCollection2.Images.SetKeyName(388, "draw_polyline.png");
            this.imageCollection2.Images.SetKeyName(389, "draw_polygon_curves.png");
            this.imageCollection2.Images.SetKeyName(390, "draw_ring.png");
            this.imageCollection2.Images.SetKeyName(391, "aol_mail.png");
            this.imageCollection2.Images.SetKeyName(392, "color-layers.png");
            this.imageCollection2.Images.SetKeyName(393, "adept_update.png");
            this.imageCollection2.Images.SetKeyName(394, "transform_path.png");
            this.imageCollection2.Images.SetKeyName(395, "preferences-desktop-theme.png");
            this.imageCollection2.Images.SetKeyName(396, "layer_shaded_relief.png");
            this.imageCollection2.Images.SetKeyName(397, "color_swatches.png");
            this.imageCollection2.Images.SetKeyName(398, "openofficeorg-draw.png");
            this.imageCollection2.Images.SetKeyName(399, "application-x-tgif.png");
            this.imageCollection2.Images.SetKeyName(400, "gnome-mime-application-vnd_oasis_opendocument_graphics-template.png");
            this.imageCollection2.Images.SetKeyName(401, "billard-gl.png");
            this.imageCollection2.Images.SetKeyName(402, "text-x-credits.png");
            this.imageCollection2.Images.SetKeyName(403, "list-accept.png");
            this.imageCollection2.Images.SetKeyName(404, "list-information.png");
            this.imageCollection2.Images.SetKeyName(405, "list-edit.png");
            this.imageCollection2.Images.SetKeyName(406, "list2-delete.png");
            this.imageCollection2.Images.SetKeyName(407, "list2-add.png");
            this.imageCollection2.Images.SetKeyName(408, "list-delete.png");
            this.imageCollection2.Images.SetKeyName(409, "directory_listing.png");
            this.imageCollection2.Images.SetKeyName(410, "list.png");
            this.imageCollection2.Images.SetKeyName(411, "Edit-Male-User.png");
            this.imageCollection2.Images.SetKeyName(412, "Remove-Male-User.png");
            this.imageCollection2.Images.SetKeyName(413, "Add-Male-User.png");
            this.imageCollection2.Images.SetKeyName(414, "key.png");
            this.imageCollection2.Images.SetKeyName(415, "key_32.png");
            this.imageCollection2.Images.SetKeyName(416, "Search-Male-User.png");
            this.imageCollection2.Images.SetKeyName(417, "text-x-changelog.png");
            this.imageCollection2.Images.SetKeyName(418, "media-playlist-repeat.png");
            this.imageCollection2.Images.SetKeyName(419, "system-upgrade.png");
            this.imageCollection2.Images.SetKeyName(420, "gwget.png");
            this.imageCollection2.Images.SetKeyName(421, "new-edit-undo.png");
            this.imageCollection2.Images.SetKeyName(422, "disk-manager.png");
            this.imageCollection2.Images.SetKeyName(423, "edit-redo.png");
            this.imageCollection2.Images.SetKeyName(424, "object-rotate-right.png");
            this.imageCollection2.Images.SetKeyName(425, "object-rotate-left.png");
            this.imageCollection2.Images.SetKeyName(426, "backup-restore32.png");
            this.imageCollection2.Images.SetKeyName(427, "Green_Backup.png");
            this.imageCollection2.Images.SetKeyName(428, "Blue_Backup_W.png");
            this.imageCollection2.Images.SetKeyName(429, "Orange_Backup_W.png");
            // 
            // MapControlEdit
            // 
            this.MapControlEdit.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("MapControlEdit.OcxState")));
            this.MapControlEdit.Size = new System.Drawing.Size(1118, 557);
            this.MapControlEdit.OnMouseDown += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnMouseDownEventHandler(this.MapControlEdit_OnMouseDown);
            this.MapControlEdit.OnAfterDraw += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnAfterDrawEventHandler(this.MapControlEdit_OnAfterDraw);
            this.MapControlEdit.Leave += new System.EventHandler(this.MapControlEdit_Leave);
            // 
            // PageLayoutControlEdit
            // 
            this.PageLayoutControlEdit.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("PageLayoutControlEdit.OcxState")));
            this.PageLayoutControlEdit.Size = new System.Drawing.Size(1010, 556);
            // 
            // ribbon
            // 
            this.ribbon.ApplicationButtonDropDownControl = null;
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barButtonItemOpen,
            this.barButtonItemExportImage,
            this.barButtonItemPrintSet,
            this.barButtonItemPrintPreview,
            this.barButtonItemPrint,
            this.barButtonItemZoomIn,
            this.barButtonItemZoomOut,
            this.barButtonItemFullMap,
            this.barButtonItemPan,
            this.barButtonItemIdentify,
            this.barButtonItemBack,
            this.barButtonItemForward,
            this.barButtonItemRefresh,
            this.barButtonItemSelectFeature,
            this.barButtonItemSelectLayerSet,
            this.barButtonItemSelectedFeaturesReport,
            this.barButtonItemClearSelectFeature,
            this.barButtonItemTOC,
            this.barButtonItemOverView,
            this.barButtonItemTOC2,
            this.barButtonItemMeasure,
            this.barButtonItemAddLayer,
            this.barButtonItemAddLayer2,
            this.barButtonItemSave,
            this.barButtonItemXBSet,
            this.barButtonItemAddFeature,
            this.barButtonItemEditFeature,
            this.barButtonItemVertexInsert,
            this.barButtonItemVertexDelete,
            this.barButtonItemVertexList,
            this.barButtonItemLinkageEdit,
            this.barButtonItemLinkageAdd,
            this.barButtonItemLinkageDelete,
            this.barButtonItemSplitFeature,
            this.barButtonItemCombineFeature,
            this.barButtonItemInputProperty,
            this.barButtonItemDeleteFeature,
            this.barButtonItemBoudarySnap,
            this.barButtonItemQuickSnap,
            this.barButtonItemEraseFeature,
            this.barButtonItemCutFeature,
            this.barButtonItemIdentify2,
            this.barButtonItemShapeCopy,
            this.barButtonItemShapePaste,
            this.barButtonItemEditUndo,
            this.barButtonItemEditRedo,
            this.barButtonItemInput,
            this.barButtonItemNessRule,
            this.barButtonItemTotalLayer,
            this.barButtonItemCheckLayers,
            this.barButtonItemCheckBoundary,
            this.barButtonItemCheckRepeat,
            this.barButtonItemCheckGap,
            this.barButtonItemCheckSelfIntersect,
            this.barButtonItemCheckArea,
            this.barButtonItemCheckAngle,
            this.barButtonItemCheckOverlap,
            this.barButtonItemOverlapCombine,
            this.barButtonItemOverlapConvert,
            this.barButtonItemOverlapDelete,
            this.barButtonItemSimplify,
            this.barButtonItemPointDelete,
            this.barButtonItemLogicCheck,
            this.barButtonItemMapFind,
            this.barButtonItemLocation,
            this.barButtonItemPlace,
            this.barButtonItemQueryZT,
            this.barButtonItemQueryKind,
            this.barButtonItemQueryYear,
            this.barButtonItemPageZoomIn,
            this.barButtonItemPageZoomOut,
            this.barButtonItemPagePan,
            this.barButtonItemPageWhole,
            this.barButtonItemPagePre,
            this.barButtonItemPageNext,
            this.barButtonItemSelectElement,
            this.barButtonItemUndo,
            this.barButtonItemRedo,
            this.barButtonItemMapFrame,
            this.barButtonItemMapLegend,
            this.barButtonItemMapScaleBar,
            this.barButtonItemScaleText,
            this.barButtonItemMapNorthArrow,
            this.barButtonItemMapText,
            this.barButtonItemMapComment,
            this.barButtonItemMapGrid,
            this.barButtonItemMapTable,
            this.barButtonToolbox,
            this.barButtonToolView,
            this.barButtonItemZone,
            this.barButtonItemDesign,
            this.barButtonItemNormal,
            this.barButtonItemQueryTF,
            this.barButtonItemXBUpdate,
            this.barEditItem1,
            this.barSubItemButtonStyle,
            this.barButtonItemLargeButton,
            this.barButtonItemSmallButton,
            this.barButtonItemSmallText,
            this.barButtonGroup1,
            this.barButtonItemCheckDist,
            this.barButtonItemQueryXB,
            this.barButtonItemInputYG,
            this.barButtonItemInputZT,
            this.barButtonItemInputDC,
            this.barButtonItemInputOther,
            this.barButtonItemLayerCombine,
            this.barButtonItemXBEdit,
            this.barButtonItemAddLayer3,
            this.barButtonItemStatic,
            this.barButtonItemReportCF1,
            this.barButtonItemReportZL,
            this.barButtonItemChartCF,
            this.barButtonItemChartZL,
            this.barButtonItemClearTopErr,
            this.barButtonItemGrowthModel,
            this.barButtonItemDataImput,
            this.barButtonItemDataOutput,
            this.barButtonItem3,
            this.barButtonItemBackup,
            this.barButtonItemRestore,
            this.barButtonItemBackup2,
            this.barButtonItemRestore2,
            this.barButtonItem4,
            this.barButtonItemUserList,
            this.barButtonItemUserAdd,
            this.barButtonItemUserEdit,
            this.barButtonItemUserDelete,
            this.barButtonItemUserKey,
            this.barButtonItemLogs,
            this.barButtonItemLogDelete,
            this.barButtonItemLogClear,
            this.barButtonItemManageDesignQuery,
            this.barButtonItemManageDesignEdit,
            this.barButtonItemManageDesignYear,
            this.barButtonItemDBConnect,
            this.barButtonItemDBUpdata,
            this.barButtonItemDBNew,
            this.barButtonItemDBLoadData,
            this.barButtonItemDBDelete,
            this.barButtonItemSetDRG});
            this.ribbon.MaxItemId = 186;
            this.ribbon.PageHeaderItemLinks.Add(this.barButtonItemSave);
            this.ribbon.PageHeaderItemLinks.Add(this.barButtonItemExportImage);
            this.ribbon.PageHeaderItemLinks.Add(this.barButtonItemPrint);
            this.ribbon.PageHeaderItemLinks.Add(this.barButtonItemPrintPreview);
            this.ribbon.PageHeaderItemLinks.Add(this.barButtonItemPrintSet);
            this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPageDataManager,
            this.ribbonPageSystemManager});
            this.ribbon.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1});
            this.ribbon.Size = new System.Drawing.Size(1124, 149);
            this.ribbon.Toolbar.ItemLinks.Add(this.barButtonToolbox);
            this.ribbon.Toolbar.ItemLinks.Add(this.barButtonToolView);
            this.ribbon.Toolbar.ItemLinks.Add(this.barSubItemButtonStyle);
            this.ribbon.Toolbar.ItemLinks.Add(this.barButtonItemAddLayer);
            this.ribbon.Toolbar.ItemLinks.Add(this.barButtonItemAddLayer2);
            this.ribbon.Toolbar.ItemLinks.Add(this.barButtonItemAddLayer3);
            this.ribbon.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.ribbon_ItemPress);
            this.ribbon.SelectedPageChanged += new System.EventHandler(this.ribbon_SelectedPageChanged);
            this.ribbon.Click += new System.EventHandler(this.ribbon_Click);
            // 
            // ribbonPageCheck
            // 
            this.ribbonPageCheck.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroupDataCheck,
            this.ribbonPageGroupLogic,
            this.ribbonPageGroupToplogic2,
            this.ribbonPageGroupToplogic,
            this.ribbonPageGroupTopoModify,
            this.ribbonPageGroupMapView2});
            this.ribbonPageCheck.Visible = false;
            // 
            // ribbonPageDataEdit
            // 
            this.ribbonPageDataEdit.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroupCaoTu,
            this.ribbonPageGroupXB,
            this.ribbonPageGroupXBSet,
            this.ribbonPageGroupAddnew,
            this.ribbonPageGroupEdit,
            this.ribbonPageGroupDelete,
            this.ribbonPageGroupEdittool,
            this.ribbonPageGroupCommEdit,
            this.ribbonPageGroupMapView});
            this.ribbonPageDataEdit.Visible = false;
            // 
            // ribbonPageGraphics
            // 
            this.ribbonPageGraphics.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroupMxt,
            this.ribbonPageGroupPageTool,
            this.ribbonPageGroupPageView,
            this.ribbonPageGroupMapView4});
            this.ribbonPageGraphics.Visible = false;
            // 
            // ribbonPageQuery
            // 
            this.ribbonPageQuery.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroupQueryComm,
            this.ribbonPageGroupQuery,
            this.ribbonPageGroupQuery2,
            this.ribbonPageGroupMapView3});
            this.ribbonPageQuery.Visible = false;
            // 
            // ribbonPageTransfer
            // 
            this.ribbonPageTransfer.Visible = false;
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 737);
            this.ribbonStatusBar.Size = new System.Drawing.Size(1124, 31);
            // 
            // tabPageMapContol
            // 
            this.tabPageMapContol.PageVisible = false;
            this.tabPageMapContol.Size = new System.Drawing.Size(1118, 557);
            // 
            // tabPagePagelayoutContol
            // 
            this.tabPagePagelayoutContol.PageVisible = false;
            this.tabPagePagelayoutContol.Size = new System.Drawing.Size(1010, 556);
            // 
            // xtraTabMain
            // 
            this.xtraTabMain.SelectedTabPage = this.tabPageMapContol;
            this.xtraTabMain.Size = new System.Drawing.Size(1124, 588);
            this.xtraTabMain.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPageLog});
            this.xtraTabMain.SelectedPageChanged += new DevExpress.XtraTab.TabPageChangedEventHandler(this.xtraTabMain_SelectedPageChanged);
            this.xtraTabMain.Controls.SetChildIndex(this.xtraTabPageLog, 0);
            this.xtraTabMain.Controls.SetChildIndex(this.tabPagePagelayoutContol, 0);
            this.xtraTabMain.Controls.SetChildIndex(this.tabPageMapContol, 0);
            // 
            // xtraTabPageIdentify
            // 
            this.xtraTabPageIdentify.Controls.Add(this.userControlInfo);
            // 
            // xtraTabPageQuery
            // 
            this.xtraTabPageQuery.Controls.Add(this.userControlQueryZL1);
            this.xtraTabPageQuery.Controls.Add(this.userControlQueryCF1);
            this.xtraTabPageQuery.Controls.Add(this.userControlQueryXB);
            this.xtraTabPageQuery.Padding = new System.Windows.Forms.Padding(6, 1, 6, 1);
            // 
            // xtraTabPageTOC
            // 
            this.xtraTabPageTOC.Controls.Add(this.userControlLayerControl);
            this.xtraTabPageTOC.Controls.Add(this.splitterControl1);
            this.xtraTabPageTOC.Controls.Add(this.userControlOverView);
            this.xtraTabPageTOC.Size = new System.Drawing.Size(266, 532);
            this.xtraTabPageTOC.Controls.SetChildIndex(this.userControlOverView, 0);
            this.xtraTabPageTOC.Controls.SetChildIndex(this.splitterControl1, 0);
            this.xtraTabPageTOC.Controls.SetChildIndex(this.userControlLayerControl, 0);
            this.xtraTabPageTOC.Controls.SetChildIndex(this.axTOCControl, 0);
            // 
            // xtraTabToolbox
            // 
            this.xtraTabToolbox.SelectedTabPage = this.xtraTabPageTOC;
            this.xtraTabToolbox.Size = new System.Drawing.Size(272, 561);
            this.xtraTabToolbox.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPageSelect,
            this.xtraTabPageMapFind,
            this.xtraTabPageLocation,
            this.xtraTabPageXBchange,
            this.xtraTabPageAddRasterlayer,
            this.xtraTabPagePlace,
            this.xtraTabPageTFH,
            this.xtraTabPageKind,
            this.xtraTabPageDesign});
            this.xtraTabToolbox.Controls.SetChildIndex(this.xtraTabPageDesign, 0);
            this.xtraTabToolbox.Controls.SetChildIndex(this.xtraTabPageKind, 0);
            this.xtraTabToolbox.Controls.SetChildIndex(this.xtraTabPageTFH, 0);
            this.xtraTabToolbox.Controls.SetChildIndex(this.xtraTabPagePlace, 0);
            this.xtraTabToolbox.Controls.SetChildIndex(this.xtraTabPageAddRasterlayer, 0);
            this.xtraTabToolbox.Controls.SetChildIndex(this.xtraTabPageXBchange, 0);
            this.xtraTabToolbox.Controls.SetChildIndex(this.xtraTabPageLocation, 0);
            this.xtraTabToolbox.Controls.SetChildIndex(this.xtraTabPageMapFind, 0);
            this.xtraTabToolbox.Controls.SetChildIndex(this.xtraTabPageSelect, 0);
            this.xtraTabToolbox.Controls.SetChildIndex(this.xtraTabPageQuery, 0);
            this.xtraTabToolbox.Controls.SetChildIndex(this.xtraTabPageIdentify, 0);
            this.xtraTabToolbox.Controls.SetChildIndex(this.xtraTabPageTOC, 0);
            // 
            // splitterControl1
            // 
            this.splitterControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitterControl1.Location = new System.Drawing.Point(0, 307);
            this.splitterControl1.Name = "splitterControl1";
            this.splitterControl1.Size = new System.Drawing.Size(266, 5);
            this.splitterControl1.TabIndex = 2;
            this.splitterControl1.TabStop = false;
            this.splitterControl1.Visible = false;
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
            this.barButtonItemZoomIn.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText)));
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
            this.barButtonItemZoomOut.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText)));
            // 
            // barButtonItemFullMap
            // 
            this.barButtonItemFullMap.Caption = "全图";
            this.barButtonItemFullMap.Description = "缩放到全图";
            this.barButtonItemFullMap.Id = 7;
            this.barButtonItemFullMap.ImageIndex = 25;
            this.barButtonItemFullMap.LargeImageIndex = 103;
            this.barButtonItemFullMap.Name = "barButtonItemFullMap";
            this.barButtonItemFullMap.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText)));
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
            this.barButtonItemPan.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText)));
            // 
            // barButtonItemIdentify
            // 
            this.barButtonItemIdentify.Caption = "查看";
            this.barButtonItemIdentify.Description = "属性信息查看";
            this.barButtonItemIdentify.Id = 9;
            this.barButtonItemIdentify.ImageIndex = 262;
            this.barButtonItemIdentify.LargeImageIndex = 402;
            this.barButtonItemIdentify.Name = "barButtonItemIdentify";
            this.barButtonItemIdentify.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText)));
            // 
            // barButtonItemBack
            // 
            this.barButtonItemBack.Caption = "返回";
            this.barButtonItemBack.Id = 10;
            this.barButtonItemBack.ImageIndex = 142;
            this.barButtonItemBack.LargeImageIndex = 44;
            this.barButtonItemBack.Name = "barButtonItemBack";
            this.barButtonItemBack.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText)));
            // 
            // barButtonItemForward
            // 
            this.barButtonItemForward.Caption = "向前";
            this.barButtonItemForward.Id = 11;
            this.barButtonItemForward.ImageIndex = 140;
            this.barButtonItemForward.LargeImageIndex = 45;
            this.barButtonItemForward.Name = "barButtonItemForward";
            this.barButtonItemForward.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText)));
            // 
            // barButtonItemRefresh
            // 
            this.barButtonItemRefresh.Caption = "刷新";
            this.barButtonItemRefresh.Description = "地图刷新";
            this.barButtonItemRefresh.Id = 18;
            this.barButtonItemRefresh.ImageIndex = 80;
            this.barButtonItemRefresh.LargeImageIndex = 340;
            this.barButtonItemRefresh.Name = "barButtonItemRefresh";
            this.barButtonItemRefresh.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText)));
            // 
            // userControlOverView
            // 
            this.userControlOverView.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.userControlOverView.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.userControlOverView.Appearance.Options.UseBackColor = true;
            this.userControlOverView.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.userControlOverView.Location = new System.Drawing.Point(0, 312);
            this.userControlOverView.Name = "userControlOverView";
            this.userControlOverView.Padding = new System.Windows.Forms.Padding(1);
            this.userControlOverView.Size = new System.Drawing.Size(266, 220);
            this.userControlOverView.TabIndex = 3;
            this.userControlOverView.Visible = false;
            // 
            // barButtonItemSelectFeature
            // 
            this.barButtonItemSelectFeature.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            this.barButtonItemSelectFeature.Caption = "选择";
            this.barButtonItemSelectFeature.Description = "要素选择";
            this.barButtonItemSelectFeature.Id = 19;
            this.barButtonItemSelectFeature.ImageIndex = 308;
            this.barButtonItemSelectFeature.LargeImageIndex = 152;
            this.barButtonItemSelectFeature.Name = "barButtonItemSelectFeature";
            this.barButtonItemSelectFeature.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText;
            // 
            // barButtonItemSelectLayerSet
            // 
            this.barButtonItemSelectLayerSet.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            this.barButtonItemSelectLayerSet.Caption = "图层选择";
            this.barButtonItemSelectLayerSet.Description = "设置图层可选择";
            this.barButtonItemSelectLayerSet.Id = 20;
            this.barButtonItemSelectLayerSet.ImageIndex = 307;
            this.barButtonItemSelectLayerSet.LargeImageIndex = 331;
            this.barButtonItemSelectLayerSet.Name = "barButtonItemSelectLayerSet";
            this.barButtonItemSelectLayerSet.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText;
            this.barButtonItemSelectLayerSet.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemSelectLayerSet_ItemClick);
            // 
            // barButtonItemSelectedFeaturesReport
            // 
            this.barButtonItemSelectedFeaturesReport.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            this.barButtonItemSelectedFeaturesReport.Caption = "选中属性";
            this.barButtonItemSelectedFeaturesReport.Description = "选中要素属性列表";
            this.barButtonItemSelectedFeaturesReport.Id = 21;
            this.barButtonItemSelectedFeaturesReport.ImageIndex = 305;
            this.barButtonItemSelectedFeaturesReport.LargeImageIndex = 281;
            this.barButtonItemSelectedFeaturesReport.Name = "barButtonItemSelectedFeaturesReport";
            this.barButtonItemSelectedFeaturesReport.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText;
            this.barButtonItemSelectedFeaturesReport.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemSelectedFeaturesReport_ItemClick);
            // 
            // barButtonItemClearSelectFeature
            // 
            this.barButtonItemClearSelectFeature.Caption = "清除";
            this.barButtonItemClearSelectFeature.Description = "清除选择";
            this.barButtonItemClearSelectFeature.Id = 22;
            this.barButtonItemClearSelectFeature.ImageIndex = 306;
            this.barButtonItemClearSelectFeature.LargeImageIndex = 268;
            this.barButtonItemClearSelectFeature.Name = "barButtonItemClearSelectFeature";
            this.barButtonItemClearSelectFeature.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText;
            // 
            // barButtonItemTOC
            // 
            this.barButtonItemTOC.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            this.barButtonItemTOC.Caption = "图层";
            this.barButtonItemTOC.Description = "图层控制";
            this.barButtonItemTOC.Down = true;
            this.barButtonItemTOC.Id = 23;
            this.barButtonItemTOC.ImageIndex = 230;
            this.barButtonItemTOC.LargeImageIndex = 34;
            this.barButtonItemTOC.Name = "barButtonItemTOC";
            this.barButtonItemTOC.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.barButtonItemTOC.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemTOC_ItemClick);
            // 
            // barButtonItemOverView
            // 
            this.barButtonItemOverView.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            this.barButtonItemOverView.Caption = "鹰眼图";
            this.barButtonItemOverView.Id = 24;
            this.barButtonItemOverView.ImageIndex = 76;
            this.barButtonItemOverView.LargeImageIndex = 17;
            this.barButtonItemOverView.Name = "barButtonItemOverView";
            this.barButtonItemOverView.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText;
            this.barButtonItemOverView.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemOverView_ItemClick);
            // 
            // barButtonItemTOC2
            // 
            this.barButtonItemTOC2.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            this.barButtonItemTOC2.Caption = "快速设置";
            this.barButtonItemTOC2.Id = 25;
            this.barButtonItemTOC2.ImageIndex = 70;
            this.barButtonItemTOC2.LargeImageIndex = 128;
            this.barButtonItemTOC2.Name = "barButtonItemTOC2";
            this.barButtonItemTOC2.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText;
            this.barButtonItemTOC2.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemTOC2_ItemClick);
            // 
            // ribbonPageGroupQueryComm
            // 
            this.ribbonPageGroupQueryComm.AllowMinimize = false;
            this.ribbonPageGroupQueryComm.ItemLinks.Add(this.barButtonItemIdentify);
            this.ribbonPageGroupQueryComm.ItemLinks.Add(this.barButtonItemMapFind);
            this.ribbonPageGroupQueryComm.ItemLinks.Add(this.barButtonItemMeasure);
            this.ribbonPageGroupQueryComm.Name = "ribbonPageGroupQueryComm";
            this.ribbonPageGroupQueryComm.Text = "通用查询";
            // 
            // barButtonItemMapFind
            // 
            this.barButtonItemMapFind.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            this.barButtonItemMapFind.Caption = "查找";
            this.barButtonItemMapFind.Description = "地图查找";
            this.barButtonItemMapFind.Id = 74;
            this.barButtonItemMapFind.ImageIndex = 84;
            this.barButtonItemMapFind.LargeImageIndex = 191;
            this.barButtonItemMapFind.Name = "barButtonItemMapFind";
            this.barButtonItemMapFind.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.barButtonItemMapFind.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemMapFind_ItemClick);
            // 
            // barButtonItemMeasure
            // 
            this.barButtonItemMeasure.Caption = "量算";
            this.barButtonItemMeasure.Description = "地图量算";
            this.barButtonItemMeasure.Id = 26;
            this.barButtonItemMeasure.ImageIndex = 249;
            this.barButtonItemMeasure.LargeImageIndex = 46;
            this.barButtonItemMeasure.Name = "barButtonItemMeasure";
            this.barButtonItemMeasure.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // barButtonItemAddLayer
            // 
            this.barButtonItemAddLayer.Caption = "添加";
            this.barButtonItemAddLayer.Description = "添加图层";
            this.barButtonItemAddLayer.Id = 27;
            this.barButtonItemAddLayer.ImageIndex = 41;
            this.barButtonItemAddLayer.LargeImageIndex = 216;
            this.barButtonItemAddLayer.Name = "barButtonItemAddLayer";
            this.barButtonItemAddLayer.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.barButtonItemAddLayer.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemAddLayer_ItemClick);
            // 
            // barButtonItemAddLayer2
            // 
            this.barButtonItemAddLayer2.Caption = "添加";
            this.barButtonItemAddLayer2.Description = "添加GPS轨迹点";
            this.barButtonItemAddLayer2.Id = 28;
            this.barButtonItemAddLayer2.ImageIndex = 201;
            this.barButtonItemAddLayer2.LargeImageIndex = 216;
            this.barButtonItemAddLayer2.Name = "barButtonItemAddLayer2";
            this.barButtonItemAddLayer2.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.barButtonItemAddLayer2.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemAddLayer2_ItemClick);
            // 
            // barButtonItemSave
            // 
            this.barButtonItemSave.Caption = "保存";
            this.barButtonItemSave.Description = "保存工作空间";
            this.barButtonItemSave.Id = 29;
            this.barButtonItemSave.ImageIndex = 78;
            this.barButtonItemSave.LargeImageIndex = 15;
            this.barButtonItemSave.Name = "barButtonItemSave";
            this.barButtonItemSave.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.barButtonItemSave.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemSave_ItemClick);
            // 
            // barButtonItemPrint
            // 
            this.barButtonItemPrint.Caption = "打印";
            this.barButtonItemPrint.Description = "地图打印";
            this.barButtonItemPrint.Id = 30;
            this.barButtonItemPrint.ImageIndex = 10;
            this.barButtonItemPrint.LargeImageIndex = 108;
            this.barButtonItemPrint.Name = "barButtonItemPrint";
            this.barButtonItemPrint.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // barButtonItemExportImage
            // 
            this.barButtonItemExportImage.Caption = "地图输出";
            this.barButtonItemExportImage.Description = "地图输出";
            this.barButtonItemExportImage.Id = 31;
            this.barButtonItemExportImage.ImageIndex = 88;
            this.barButtonItemExportImage.LargeImageIndex = 376;
            this.barButtonItemExportImage.Name = "barButtonItemExportImage";
            this.barButtonItemExportImage.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // barButtonItemPrintPreview
            // 
            this.barButtonItemPrintPreview.Caption = "打印预览";
            this.barButtonItemPrintPreview.Id = 32;
            this.barButtonItemPrintPreview.ImageIndex = 297;
            this.barButtonItemPrintPreview.LargeImageIndex = 53;
            this.barButtonItemPrintPreview.Name = "barButtonItemPrintPreview";
            this.barButtonItemPrintPreview.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // barButtonItemPrintSet
            // 
            this.barButtonItemPrintSet.Caption = "打印设置";
            this.barButtonItemPrintSet.Id = 33;
            this.barButtonItemPrintSet.ImageIndex = 182;
            this.barButtonItemPrintSet.LargeImageIndex = 164;
            this.barButtonItemPrintSet.Name = "barButtonItemPrintSet";
            this.barButtonItemPrintSet.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // barButtonItemOpen
            // 
            this.barButtonItemOpen.Caption = "打开地图";
            this.barButtonItemOpen.Description = "打开编辑地图";
            this.barButtonItemOpen.Id = 34;
            this.barButtonItemOpen.ImageIndex = 8;
            this.barButtonItemOpen.LargeImageIndex = 198;
            this.barButtonItemOpen.Name = "barButtonItemOpen";
            // 
            // barButtonItemXBSet
            // 
            this.barButtonItemXBSet.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            this.barButtonItemXBSet.Caption = "设置";
            this.barButtonItemXBSet.Description = "变更编辑设置";
            this.barButtonItemXBSet.Down = true;
            this.barButtonItemXBSet.Id = 35;
            this.barButtonItemXBSet.ImageIndex = 37;
            this.barButtonItemXBSet.LargeImageIndex = 332;
            this.barButtonItemXBSet.Name = "barButtonItemXBSet";
            this.barButtonItemXBSet.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // ribbonPageGroupXBSet
            // 
            this.ribbonPageGroupXBSet.ItemLinks.Add(this.barButtonItemXBSet);
            this.ribbonPageGroupXBSet.Name = "ribbonPageGroupXBSet";
            this.ribbonPageGroupXBSet.Text = "变更设置";
            this.ribbonPageGroupXBSet.Visible = false;
            // 
            // ribbonPageGroupAddnew
            // 
            this.ribbonPageGroupAddnew.AllowMinimize = false;
            this.ribbonPageGroupAddnew.ItemLinks.Add(this.barButtonItemInput);
            this.ribbonPageGroupAddnew.ItemLinks.Add(this.barButtonItemAddFeature);
            this.ribbonPageGroupAddnew.ItemLinks.Add(this.barButtonItemXBUpdate, true);
            this.ribbonPageGroupAddnew.Name = "ribbonPageGroupAddnew";
            this.ribbonPageGroupAddnew.Text = "新增班块";
            // 
            // barButtonItemInput
            // 
            this.barButtonItemInput.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            this.barButtonItemInput.Caption = "导入";
            this.barButtonItemInput.Id = 57;
            this.barButtonItemInput.ImageIndex = 90;
            this.barButtonItemInput.LargeImageIndex = 41;
            this.barButtonItemInput.Name = "barButtonItemInput";
            this.barButtonItemInput.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // barButtonItemAddFeature
            // 
            this.barButtonItemAddFeature.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            this.barButtonItemAddFeature.Caption = "新增";
            this.barButtonItemAddFeature.Id = 36;
            this.barButtonItemAddFeature.ImageIndex = 311;
            this.barButtonItemAddFeature.LargeImageIndex = 38;
            this.barButtonItemAddFeature.Name = "barButtonItemAddFeature";
            this.barButtonItemAddFeature.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // barButtonItemXBUpdate
            // 
            this.barButtonItemXBUpdate.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            this.barButtonItemXBUpdate.Caption = "自动更新";
            this.barButtonItemXBUpdate.Id = 106;
            this.barButtonItemXBUpdate.ImageIndex = 233;
            this.barButtonItemXBUpdate.LargeImageIndex = 201;
            this.barButtonItemXBUpdate.Name = "barButtonItemXBUpdate";
            this.barButtonItemXBUpdate.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // ribbonPageGroupEdit
            // 
            this.ribbonPageGroupEdit.AllowMinimize = false;
            this.ribbonPageGroupEdit.ImageIndex = 68;
            this.ribbonPageGroupEdit.ItemLinks.Add(this.barButtonItemEditFeature);
            this.ribbonPageGroupEdit.ItemLinks.Add(this.barButtonItemLinkageEdit);
            this.ribbonPageGroupEdit.ItemLinks.Add(this.barButtonItemSplitFeature, true);
            this.ribbonPageGroupEdit.ItemLinks.Add(this.barButtonItemCombineFeature);
            this.ribbonPageGroupEdit.ItemLinks.Add(this.barButtonItemInputProperty, true);
            this.ribbonPageGroupEdit.Name = "ribbonPageGroupEdit";
            this.ribbonPageGroupEdit.Text = "修改班块";
            // 
            // barButtonItemEditFeature
            // 
            this.barButtonItemEditFeature.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            this.barButtonItemEditFeature.Caption = "编辑";
            this.barButtonItemEditFeature.Id = 37;
            this.barButtonItemEditFeature.ImageIndex = 89;
            this.barButtonItemEditFeature.LargeImageIndex = 40;
            this.barButtonItemEditFeature.Name = "barButtonItemEditFeature";
            this.barButtonItemEditFeature.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // barButtonItemLinkageEdit
            // 
            this.barButtonItemLinkageEdit.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            this.barButtonItemLinkageEdit.Caption = "联动";
            this.barButtonItemLinkageEdit.Description = "联动编辑";
            this.barButtonItemLinkageEdit.Id = 41;
            this.barButtonItemLinkageEdit.ImageIndex = 304;
            this.barButtonItemLinkageEdit.LargeImageIndex = 334;
            this.barButtonItemLinkageEdit.Name = "barButtonItemLinkageEdit";
            this.barButtonItemLinkageEdit.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // barButtonItemSplitFeature
            // 
            this.barButtonItemSplitFeature.Caption = "分割";
            this.barButtonItemSplitFeature.Description = "分割班块";
            this.barButtonItemSplitFeature.Id = 44;
            this.barButtonItemSplitFeature.ImageIndex = 199;
            this.barButtonItemSplitFeature.LargeImageIndex = 181;
            this.barButtonItemSplitFeature.Name = "barButtonItemSplitFeature";
            this.barButtonItemSplitFeature.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // barButtonItemCombineFeature
            // 
            this.barButtonItemCombineFeature.Caption = "合并";
            this.barButtonItemCombineFeature.Description = "合并班块";
            this.barButtonItemCombineFeature.Id = 45;
            this.barButtonItemCombineFeature.ImageIndex = 196;
            this.barButtonItemCombineFeature.LargeImageIndex = 389;
            this.barButtonItemCombineFeature.Name = "barButtonItemCombineFeature";
            this.barButtonItemCombineFeature.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // barButtonItemInputProperty
            // 
            this.barButtonItemInputProperty.Caption = "录入";
            this.barButtonItemInputProperty.Id = 46;
            this.barButtonItemInputProperty.ImageIndex = 222;
            this.barButtonItemInputProperty.LargeImageIndex = 329;
            this.barButtonItemInputProperty.Name = "barButtonItemInputProperty";
            this.barButtonItemInputProperty.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // popupMenuVertex
            // 
            this.popupMenuVertex.ItemLinks.Add(this.barButtonItemEditFeature);
            this.popupMenuVertex.ItemLinks.Add(this.barButtonItemVertexInsert);
            this.popupMenuVertex.ItemLinks.Add(this.barButtonItemVertexDelete);
            this.popupMenuVertex.ItemLinks.Add(this.barButtonItemVertexList);
            this.popupMenuVertex.Name = "popupMenuVertex";
            this.popupMenuVertex.Ribbon = this.ribbon;
            // 
            // barButtonItemVertexInsert
            // 
            this.barButtonItemVertexInsert.Caption = "插入节点";
            this.barButtonItemVertexInsert.Id = 38;
            this.barButtonItemVertexInsert.ImageIndex = 186;
            this.barButtonItemVertexInsert.LargeImageIndex = 257;
            this.barButtonItemVertexInsert.Name = "barButtonItemVertexInsert";
            // 
            // barButtonItemVertexDelete
            // 
            this.barButtonItemVertexDelete.Caption = "删除节点";
            this.barButtonItemVertexDelete.Id = 39;
            this.barButtonItemVertexDelete.ImageIndex = 187;
            this.barButtonItemVertexDelete.LargeImageIndex = 258;
            this.barButtonItemVertexDelete.Name = "barButtonItemVertexDelete";
            // 
            // barButtonItemVertexList
            // 
            this.barButtonItemVertexList.Caption = "节点列表";
            this.barButtonItemVertexList.Id = 40;
            this.barButtonItemVertexList.ImageIndex = 204;
            this.barButtonItemVertexList.LargeImageIndex = 176;
            this.barButtonItemVertexList.Name = "barButtonItemVertexList";
            this.barButtonItemVertexList.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemVertexList_ItemClick);
            // 
            // popupMenuLinkage
            // 
            this.popupMenuLinkage.ItemLinks.Add(this.barButtonItemLinkageEdit);
            this.popupMenuLinkage.ItemLinks.Add(this.barButtonItemLinkageAdd);
            this.popupMenuLinkage.ItemLinks.Add(this.barButtonItemLinkageDelete);
            this.popupMenuLinkage.Name = "popupMenuLinkage";
            this.popupMenuLinkage.Ribbon = this.ribbon;
            // 
            // barButtonItemLinkageAdd
            // 
            this.barButtonItemLinkageAdd.Caption = "添加节点";
            this.barButtonItemLinkageAdd.Id = 42;
            this.barButtonItemLinkageAdd.ImageIndex = 210;
            this.barButtonItemLinkageAdd.Name = "barButtonItemLinkageAdd";
            // 
            // barButtonItemLinkageDelete
            // 
            this.barButtonItemLinkageDelete.Caption = "删除节点";
            this.barButtonItemLinkageDelete.Id = 43;
            this.barButtonItemLinkageDelete.ImageIndex = 211;
            this.barButtonItemLinkageDelete.Name = "barButtonItemLinkageDelete";
            // 
            // barButtonItemDeleteFeature
            // 
            this.barButtonItemDeleteFeature.Caption = "删除";
            this.barButtonItemDeleteFeature.Description = "删除班块";
            this.barButtonItemDeleteFeature.Id = 47;
            this.barButtonItemDeleteFeature.ImageIndex = 312;
            this.barButtonItemDeleteFeature.LargeImageIndex = 39;
            this.barButtonItemDeleteFeature.Name = "barButtonItemDeleteFeature";
            this.barButtonItemDeleteFeature.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // barButtonItemBoudarySnap
            // 
            this.barButtonItemBoudarySnap.Caption = "追踪图层";
            this.barButtonItemBoudarySnap.Description = "追踪图层设置";
            this.barButtonItemBoudarySnap.Id = 48;
            this.barButtonItemBoudarySnap.ImageIndex = 45;
            this.barButtonItemBoudarySnap.LargeImageIndex = 186;
            this.barButtonItemBoudarySnap.Name = "barButtonItemBoudarySnap";
            this.barButtonItemBoudarySnap.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // ribbonPageGroupDelete
            // 
            this.ribbonPageGroupDelete.AllowMinimize = false;
            this.ribbonPageGroupDelete.ItemLinks.Add(this.barButtonItemDeleteFeature);
            this.ribbonPageGroupDelete.Name = "ribbonPageGroupDelete";
            this.ribbonPageGroupDelete.Text = "删除班块";
            // 
            // ribbonPageGroupEdittool
            // 
            this.ribbonPageGroupEdittool.AllowMinimize = false;
            this.ribbonPageGroupEdittool.ImageIndex = 44;
            this.ribbonPageGroupEdittool.ItemLinks.Add(this.barButtonItemBoudarySnap);
            this.ribbonPageGroupEdittool.ItemLinks.Add(this.barButtonItemQuickSnap);
            this.ribbonPageGroupEdittool.ItemLinks.Add(this.barButtonItemEraseFeature, true);
            this.ribbonPageGroupEdittool.ItemLinks.Add(this.barButtonItemCutFeature);
            this.ribbonPageGroupEdittool.Name = "ribbonPageGroupEdittool";
            this.ribbonPageGroupEdittool.Text = "编辑工具";
            // 
            // barButtonItemQuickSnap
            // 
            this.barButtonItemQuickSnap.Caption = "快速追踪";
            this.barButtonItemQuickSnap.Id = 49;
            this.barButtonItemQuickSnap.ImageIndex = 51;
            this.barButtonItemQuickSnap.LargeImageIndex = 182;
            this.barButtonItemQuickSnap.Name = "barButtonItemQuickSnap";
            this.barButtonItemQuickSnap.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // barButtonItemEraseFeature
            // 
            this.barButtonItemEraseFeature.Caption = "挖空";
            this.barButtonItemEraseFeature.Id = 50;
            this.barButtonItemEraseFeature.ImageIndex = 313;
            this.barButtonItemEraseFeature.LargeImageIndex = 390;
            this.barButtonItemEraseFeature.Name = "barButtonItemEraseFeature";
            this.barButtonItemEraseFeature.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // barButtonItemCutFeature
            // 
            this.barButtonItemCutFeature.Caption = "裁切";
            this.barButtonItemCutFeature.Id = 51;
            this.barButtonItemCutFeature.ImageIndex = 338;
            this.barButtonItemCutFeature.LargeImageIndex = 333;
            this.barButtonItemCutFeature.Name = "barButtonItemCutFeature";
            this.barButtonItemCutFeature.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // barButtonItemIdentify2
            // 
            this.barButtonItemIdentify2.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            this.barButtonItemIdentify2.Caption = "快速查看";
            this.barButtonItemIdentify2.Description = "快速查看";
            this.barButtonItemIdentify2.Down = true;
            this.barButtonItemIdentify2.Id = 52;
            this.barButtonItemIdentify2.ImageIndex = 231;
            this.barButtonItemIdentify2.LargeImageIndex = 169;
            this.barButtonItemIdentify2.Name = "barButtonItemIdentify2";
            this.barButtonItemIdentify2.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText)));
            this.barButtonItemIdentify2.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemIdentify2_ItemClick);
            // 
            // barButtonItemShapeCopy
            // 
            this.barButtonItemShapeCopy.Caption = "复制";
            this.barButtonItemShapeCopy.Id = 53;
            this.barButtonItemShapeCopy.ImageIndex = 59;
            this.barButtonItemShapeCopy.LargeImageIndex = 48;
            this.barButtonItemShapeCopy.Name = "barButtonItemShapeCopy";
            this.barButtonItemShapeCopy.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText)));
            // 
            // ribbonPageGroupMapView
            // 
            this.ribbonPageGroupMapView.ImageIndex = 251;
            this.ribbonPageGroupMapView.ItemLinks.Add(this.barButtonItemFullMap);
            this.ribbonPageGroupMapView.ItemLinks.Add(this.barButtonItemPan);
            this.ribbonPageGroupMapView.ItemLinks.Add(this.barButtonItemZoomIn, true);
            this.ribbonPageGroupMapView.ItemLinks.Add(this.barButtonItemZoomOut);
            this.ribbonPageGroupMapView.ItemLinks.Add(this.barButtonItemRefresh);
            this.ribbonPageGroupMapView.ItemLinks.Add(this.barButtonItemBack);
            this.ribbonPageGroupMapView.ItemLinks.Add(this.barButtonItemForward);
            this.ribbonPageGroupMapView.ItemLinks.Add(this.barButtonItemIdentify, true);
            this.ribbonPageGroupMapView.ItemLinks.Add(this.barButtonItemIdentify2);
            this.ribbonPageGroupMapView.ItemLinks.Add(this.barButtonItemTOC, true);
            this.ribbonPageGroupMapView.ItemLinks.Add(this.barButtonItemOverView);
            this.ribbonPageGroupMapView.ItemLinks.Add(this.barButtonItemTOC2);
            this.ribbonPageGroupMapView.ItemLinks.Add(this.barButtonItemSelectFeature, true);
            this.ribbonPageGroupMapView.ItemLinks.Add(this.barButtonItemClearSelectFeature);
            this.ribbonPageGroupMapView.ItemLinks.Add(this.barButtonItemSelectLayerSet, true);
            this.ribbonPageGroupMapView.ItemLinks.Add(this.barButtonItemSelectedFeaturesReport);
            this.ribbonPageGroupMapView.Name = "ribbonPageGroupMapView";
            this.ribbonPageGroupMapView.Text = "地图浏览";
            // 
            // popupMenuMapView
            // 
            this.popupMenuMapView.ItemLinks.Add(this.barButtonItemFullMap);
            this.popupMenuMapView.ItemLinks.Add(this.barButtonItemZoomIn);
            this.popupMenuMapView.ItemLinks.Add(this.barButtonItemZoomOut);
            this.popupMenuMapView.ItemLinks.Add(this.barButtonItemPan);
            this.popupMenuMapView.ItemLinks.Add(this.barButtonItemRefresh);
            this.popupMenuMapView.ItemLinks.Add(this.barButtonItemSelectFeature, true);
            this.popupMenuMapView.ItemLinks.Add(this.barButtonItemClearSelectFeature);
            this.popupMenuMapView.ItemLinks.Add(this.barButtonItemIdentify2, true);
            this.popupMenuMapView.Name = "popupMenuMapView";
            this.popupMenuMapView.Ribbon = this.ribbon;
            // 
            // ribbonPageGroupCommEdit
            // 
            this.ribbonPageGroupCommEdit.AllowMinimize = false;
            this.ribbonPageGroupCommEdit.ImageIndex = 102;
            this.ribbonPageGroupCommEdit.ItemLinks.Add(this.barButtonItemShapeCopy);
            this.ribbonPageGroupCommEdit.ItemLinks.Add(this.barButtonItemShapePaste);
            this.ribbonPageGroupCommEdit.ItemLinks.Add(this.barButtonItemEditUndo, true);
            this.ribbonPageGroupCommEdit.ItemLinks.Add(this.barButtonItemEditRedo);
            this.ribbonPageGroupCommEdit.Name = "ribbonPageGroupCommEdit";
            this.ribbonPageGroupCommEdit.Text = "通用编辑";
            // 
            // barButtonItemShapePaste
            // 
            this.barButtonItemShapePaste.Caption = "粘贴";
            this.barButtonItemShapePaste.Id = 54;
            this.barButtonItemShapePaste.ImageIndex = 63;
            this.barButtonItemShapePaste.LargeImageIndex = 51;
            this.barButtonItemShapePaste.Name = "barButtonItemShapePaste";
            // 
            // barButtonItemEditUndo
            // 
            this.barButtonItemEditUndo.Caption = "撤销";
            this.barButtonItemEditUndo.Id = 55;
            this.barButtonItemEditUndo.ImageIndex = 225;
            this.barButtonItemEditUndo.LargeImageIndex = 0;
            this.barButtonItemEditUndo.Name = "barButtonItemEditUndo";
            this.barButtonItemEditUndo.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText)));
            // 
            // barButtonItemEditRedo
            // 
            this.barButtonItemEditRedo.Caption = "重做";
            this.barButtonItemEditRedo.Id = 56;
            this.barButtonItemEditRedo.ImageIndex = 229;
            this.barButtonItemEditRedo.LargeImageIndex = 1;
            this.barButtonItemEditRedo.Name = "barButtonItemEditRedo";
            this.barButtonItemEditRedo.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText)));
            // 
            // ribbonPageGroupDataCheck
            // 
            this.ribbonPageGroupDataCheck.Name = "ribbonPageGroupDataCheck";
            this.ribbonPageGroupDataCheck.Text = "数据校验";
            this.ribbonPageGroupDataCheck.Visible = false;
            // 
            // ribbonPageGroupToplogic2
            // 
            this.ribbonPageGroupToplogic2.AllowMinimize = false;
            this.ribbonPageGroupToplogic2.ItemLinks.Add(this.barButtonItemNessRule);
            this.ribbonPageGroupToplogic2.ItemLinks.Add(this.barButtonItemCheckDist);
            this.ribbonPageGroupToplogic2.ItemLinks.Add(this.barButtonItemTotalLayer);
            this.ribbonPageGroupToplogic2.ItemLinks.Add(this.barButtonItemCheckLayers);
            this.ribbonPageGroupToplogic2.Name = "ribbonPageGroupToplogic2";
            this.ribbonPageGroupToplogic2.Text = "拓扑校验";
            // 
            // barButtonItemNessRule
            // 
            this.barButtonItemNessRule.Caption = "规则设置";
            this.barButtonItemNessRule.Id = 58;
            this.barButtonItemNessRule.ImageIndex = 268;
            this.barButtonItemNessRule.LargeImageIndex = 78;
            this.barButtonItemNessRule.Name = "barButtonItemNessRule";
            this.barButtonItemNessRule.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // barButtonItemCheckDist
            // 
            this.barButtonItemCheckDist.Caption = "编辑检查";
            this.barButtonItemCheckDist.Description = "当前编辑范围内检查";
            this.barButtonItemCheckDist.Id = 137;
            this.barButtonItemCheckDist.ImageIndex = 284;
            this.barButtonItemCheckDist.LargeImageIndex = 396;
            this.barButtonItemCheckDist.Name = "barButtonItemCheckDist";
            this.barButtonItemCheckDist.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.barButtonItemCheckDist.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // barButtonItemTotalLayer
            // 
            this.barButtonItemTotalLayer.Caption = "图层检查";
            this.barButtonItemTotalLayer.Id = 59;
            this.barButtonItemTotalLayer.ImageIndex = 96;
            this.barButtonItemTotalLayer.LargeImageIndex = 235;
            this.barButtonItemTotalLayer.Name = "barButtonItemTotalLayer";
            this.barButtonItemTotalLayer.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // barButtonItemCheckLayers
            // 
            this.barButtonItemCheckLayers.Caption = "层间检查";
            this.barButtonItemCheckLayers.Id = 60;
            this.barButtonItemCheckLayers.ImageIndex = 99;
            this.barButtonItemCheckLayers.LargeImageIndex = 392;
            this.barButtonItemCheckLayers.Name = "barButtonItemCheckLayers";
            this.barButtonItemCheckLayers.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // barButtonItemCheckBoundary
            // 
            this.barButtonItemCheckBoundary.Caption = "边界检查";
            this.barButtonItemCheckBoundary.Id = 61;
            this.barButtonItemCheckBoundary.ImageIndex = 194;
            this.barButtonItemCheckBoundary.LargeImageIndex = 274;
            this.barButtonItemCheckBoundary.Name = "barButtonItemCheckBoundary";
            this.barButtonItemCheckBoundary.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText)));
            // 
            // barButtonItemCheckRepeat
            // 
            this.barButtonItemCheckRepeat.Caption = "重复点";
            this.barButtonItemCheckRepeat.Id = 62;
            this.barButtonItemCheckRepeat.ImageIndex = 318;
            this.barButtonItemCheckRepeat.LargeImageIndex = 401;
            this.barButtonItemCheckRepeat.Name = "barButtonItemCheckRepeat";
            // 
            // barButtonItemCheckGap
            // 
            this.barButtonItemCheckGap.Caption = "缝隙检查";
            this.barButtonItemCheckGap.Id = 63;
            this.barButtonItemCheckGap.ImageIndex = 325;
            this.barButtonItemCheckGap.LargeImageIndex = 185;
            this.barButtonItemCheckGap.Name = "barButtonItemCheckGap";
            // 
            // ribbonPageGroupLogic
            // 
            this.ribbonPageGroupLogic.AllowMinimize = false;
            this.ribbonPageGroupLogic.ItemLinks.Add(this.barButtonItemLogicCheck);
            this.ribbonPageGroupLogic.Name = "ribbonPageGroupLogic";
            this.ribbonPageGroupLogic.Text = "逻辑校验";
            // 
            // barButtonItemLogicCheck
            // 
            this.barButtonItemLogicCheck.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            this.barButtonItemLogicCheck.Caption = "逻辑校验";
            this.barButtonItemLogicCheck.Id = 73;
            this.barButtonItemLogicCheck.ImageIndex = 334;
            this.barButtonItemLogicCheck.LargeImageIndex = 398;
            this.barButtonItemLogicCheck.Name = "barButtonItemLogicCheck";
            this.barButtonItemLogicCheck.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // ribbonPageGroupToplogic
            // 
            this.ribbonPageGroupToplogic.AllowMinimize = false;
            this.ribbonPageGroupToplogic.ItemLinks.Add(this.barButtonItemCheckBoundary);
            this.ribbonPageGroupToplogic.ItemLinks.Add(this.barButtonItemCheckRepeat);
            this.ribbonPageGroupToplogic.ItemLinks.Add(this.barButtonItemCheckGap);
            this.ribbonPageGroupToplogic.ItemLinks.Add(this.barButtonItemCheckSelfIntersect);
            this.ribbonPageGroupToplogic.ItemLinks.Add(this.barButtonItemCheckOverlap);
            this.ribbonPageGroupToplogic.ItemLinks.Add(this.barButtonItemCheckArea);
            this.ribbonPageGroupToplogic.ItemLinks.Add(this.barButtonItemCheckAngle);
            this.ribbonPageGroupToplogic.ItemLinks.Add(this.barButtonItemClearTopErr);
            this.ribbonPageGroupToplogic.Name = "ribbonPageGroupToplogic";
            this.ribbonPageGroupToplogic.Text = "校验工具";
            // 
            // barButtonItemCheckSelfIntersect
            // 
            this.barButtonItemCheckSelfIntersect.Caption = "自相交";
            this.barButtonItemCheckSelfIntersect.Id = 64;
            this.barButtonItemCheckSelfIntersect.ImageIndex = 149;
            this.barButtonItemCheckSelfIntersect.LargeImageIndex = 147;
            this.barButtonItemCheckSelfIntersect.Name = "barButtonItemCheckSelfIntersect";
            // 
            // barButtonItemCheckOverlap
            // 
            this.barButtonItemCheckOverlap.Caption = "重叠";
            this.barButtonItemCheckOverlap.Id = 67;
            this.barButtonItemCheckOverlap.ImageIndex = 33;
            this.barButtonItemCheckOverlap.LargeImageIndex = 308;
            this.barButtonItemCheckOverlap.Name = "barButtonItemCheckOverlap";
            // 
            // barButtonItemCheckArea
            // 
            this.barButtonItemCheckArea.Caption = "最小面积";
            this.barButtonItemCheckArea.Id = 65;
            this.barButtonItemCheckArea.ImageIndex = 2;
            this.barButtonItemCheckArea.LargeImageIndex = 388;
            this.barButtonItemCheckArea.Name = "barButtonItemCheckArea";
            // 
            // barButtonItemCheckAngle
            // 
            this.barButtonItemCheckAngle.Caption = "最小锐角";
            this.barButtonItemCheckAngle.Id = 66;
            this.barButtonItemCheckAngle.ImageIndex = 293;
            this.barButtonItemCheckAngle.LargeImageIndex = 391;
            this.barButtonItemCheckAngle.Name = "barButtonItemCheckAngle";
            // 
            // barButtonItemClearTopErr
            // 
            this.barButtonItemClearTopErr.Caption = "清除错误";
            this.barButtonItemClearTopErr.Description = "清除拓扑错误";
            this.barButtonItemClearTopErr.Id = 157;
            this.barButtonItemClearTopErr.LargeImageIndex = 231;
            this.barButtonItemClearTopErr.Name = "barButtonItemClearTopErr";
            // 
            // barButtonItemOverlapCombine
            // 
            this.barButtonItemOverlapCombine.Caption = "合并重叠";
            this.barButtonItemOverlapCombine.Id = 68;
            this.barButtonItemOverlapCombine.ImageIndex = 327;
            this.barButtonItemOverlapCombine.LargeImageIndex = 308;
            this.barButtonItemOverlapCombine.Name = "barButtonItemOverlapCombine";
            this.barButtonItemOverlapCombine.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText)));
            // 
            // barButtonItemOverlapConvert
            // 
            this.barButtonItemOverlapConvert.Caption = "新增重叠";
            this.barButtonItemOverlapConvert.Id = 69;
            this.barButtonItemOverlapConvert.ImageIndex = 326;
            this.barButtonItemOverlapConvert.LargeImageIndex = 306;
            this.barButtonItemOverlapConvert.Name = "barButtonItemOverlapConvert";
            this.barButtonItemOverlapConvert.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText)));
            // 
            // barButtonItemOverlapDelete
            // 
            this.barButtonItemOverlapDelete.Caption = "删除重叠";
            this.barButtonItemOverlapDelete.Id = 70;
            this.barButtonItemOverlapDelete.ImageIndex = 328;
            this.barButtonItemOverlapDelete.LargeImageIndex = 309;
            this.barButtonItemOverlapDelete.Name = "barButtonItemOverlapDelete";
            this.barButtonItemOverlapDelete.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText)));
            // 
            // barButtonItemSimplify
            // 
            this.barButtonItemSimplify.Caption = "简化";
            this.barButtonItemSimplify.Id = 71;
            this.barButtonItemSimplify.ImageIndex = 324;
            this.barButtonItemSimplify.LargeImageIndex = 184;
            this.barButtonItemSimplify.Name = "barButtonItemSimplify";
            // 
            // barButtonItemPointDelete
            // 
            this.barButtonItemPointDelete.Caption = "删除点";
            this.barButtonItemPointDelete.Id = 72;
            this.barButtonItemPointDelete.LargeImageIndexDisabled = 343;
            this.barButtonItemPointDelete.Name = "barButtonItemPointDelete";
            // 
            // barButtonItemLocation
            // 
            this.barButtonItemLocation.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            this.barButtonItemLocation.Caption = "地图定位";
            this.barButtonItemLocation.Description = "地图定位";
            this.barButtonItemLocation.Id = 75;
            this.barButtonItemLocation.ImageIndex = 24;
            this.barButtonItemLocation.LargeImageIndex = 67;
            this.barButtonItemLocation.Name = "barButtonItemLocation";
            this.barButtonItemLocation.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.barButtonItemLocation.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemLocation_ItemClick);
            // 
            // barButtonItemPlace
            // 
            this.barButtonItemPlace.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            this.barButtonItemPlace.Caption = "地名查找";
            this.barButtonItemPlace.Description = "地名查找";
            this.barButtonItemPlace.Id = 76;
            this.barButtonItemPlace.ImageIndex = 14;
            this.barButtonItemPlace.LargeImageIndex = 29;
            this.barButtonItemPlace.Name = "barButtonItemPlace";
            this.barButtonItemPlace.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.barButtonItemPlace.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemPlace_ItemClick);
            // 
            // barButtonItemQueryZT
            // 
            this.barButtonItemQueryZT.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            this.barButtonItemQueryZT.Caption = "班块查询";
            this.barButtonItemQueryZT.Id = 77;
            this.barButtonItemQueryZT.ImageIndex = 91;
            this.barButtonItemQueryZT.LargeImageIndex = 42;
            this.barButtonItemQueryZT.Name = "barButtonItemQueryZT";
            this.barButtonItemQueryZT.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.barButtonItemQueryZT.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemQueryZT_ItemClick);
            // 
            // barButtonItemQueryKind
            // 
            this.barButtonItemQueryKind.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            this.barButtonItemQueryKind.Caption = "类型查询";
            this.barButtonItemQueryKind.Id = 78;
            this.barButtonItemQueryKind.ImageIndex = 195;
            this.barButtonItemQueryKind.LargeImageIndex = 397;
            this.barButtonItemQueryKind.Name = "barButtonItemQueryKind";
            this.barButtonItemQueryKind.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.barButtonItemQueryKind.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemQueryKind_ItemClick);
            // 
            // barButtonItemQueryYear
            // 
            this.barButtonItemQueryYear.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            this.barButtonItemQueryYear.Caption = "年度查询";
            this.barButtonItemQueryYear.Id = 79;
            this.barButtonItemQueryYear.ImageIndex = 104;
            this.barButtonItemQueryYear.LargeImageIndex = 237;
            this.barButtonItemQueryYear.Name = "barButtonItemQueryYear";
            this.barButtonItemQueryYear.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.barButtonItemQueryYear.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemQueryYear_ItemClick);
            // 
            // ribbonPageGroupTopoModify
            // 
            this.ribbonPageGroupTopoModify.AllowMinimize = false;
            this.ribbonPageGroupTopoModify.ItemLinks.Add(this.barButtonItemEditFeature);
            this.ribbonPageGroupTopoModify.ItemLinks.Add(this.barButtonItemDeleteFeature);
            this.ribbonPageGroupTopoModify.ItemLinks.Add(this.barButtonItemSimplify);
            this.ribbonPageGroupTopoModify.ItemLinks.Add(this.barButtonItemOverlapCombine);
            this.ribbonPageGroupTopoModify.ItemLinks.Add(this.barButtonItemOverlapConvert);
            this.ribbonPageGroupTopoModify.ItemLinks.Add(this.barButtonItemOverlapDelete);
            this.ribbonPageGroupTopoModify.Name = "ribbonPageGroupTopoModify";
            this.ribbonPageGroupTopoModify.Text = "拓扑修改";
            // 
            // popupMenuEdit
            // 
            this.popupMenuEdit.ItemLinks.Add(this.barButtonItemShapeCopy);
            this.popupMenuEdit.ItemLinks.Add(this.barButtonItemShapePaste);
            this.popupMenuEdit.ItemLinks.Add(this.barButtonItemEditFeature);
            this.popupMenuEdit.ItemLinks.Add(this.barButtonItemInputProperty);
            this.popupMenuEdit.ItemLinks.Add(this.barButtonItemDeleteFeature);
            this.popupMenuEdit.ItemLinks.Add(this.barButtonItemClearSelectFeature);
            this.popupMenuEdit.ItemLinks.Add(this.barButtonItemEditUndo);
            this.popupMenuEdit.ItemLinks.Add(this.barButtonItemEditRedo);
            this.popupMenuEdit.Name = "popupMenuEdit";
            this.popupMenuEdit.Ribbon = this.ribbon;
            // 
            // xtraTabControlEdit
            // 
            this.xtraTabControlEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControlEdit.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Bottom;
            this.xtraTabControlEdit.Location = new System.Drawing.Point(0, 0);
            this.xtraTabControlEdit.Name = "xtraTabControlEdit";
            this.xtraTabControlEdit.SelectedTabPage = this.xtraTabPageAttribute;
            this.xtraTabControlEdit.Size = new System.Drawing.Size(394, 590);
            this.xtraTabControlEdit.TabIndex = 1;
            this.xtraTabControlEdit.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPageAttribute,
            this.xtraTabPageLogicCheck,
            this.xtraTabPageInputData,
            this.xtraTabPageUpdate});
            // 
            // xtraTabPageAttribute
            // 
            this.xtraTabPageAttribute.Controls.Add(this.userControlAttrEdit1);
            this.xtraTabPageAttribute.Name = "xtraTabPageAttribute";
            this.xtraTabPageAttribute.PageVisible = false;
            this.xtraTabPageAttribute.Size = new System.Drawing.Size(389, 563);
            this.xtraTabPageAttribute.Text = "属性";
            // 
            // userControlAttrEdit1
            // 
            this.userControlAttrEdit1.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.userControlAttrEdit1.Appearance.BackColor2 = System.Drawing.Color.Transparent;
            this.userControlAttrEdit1.Appearance.Options.UseBackColor = true;
            this.userControlAttrEdit1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControlAttrEdit1.Location = new System.Drawing.Point(0, 0);
            this.userControlAttrEdit1.Name = "userControlAttrEdit1";
            this.userControlAttrEdit1.Size = new System.Drawing.Size(389, 563);
            this.userControlAttrEdit1.TabIndex = 0;
            // 
            // xtraTabPageLogicCheck
            // 
            this.xtraTabPageLogicCheck.Controls.Add(this.userControlAttriCheck1);
            this.xtraTabPageLogicCheck.Name = "xtraTabPageLogicCheck";
            this.xtraTabPageLogicCheck.PageVisible = false;
            this.xtraTabPageLogicCheck.Size = new System.Drawing.Size(389, 563);
            this.xtraTabPageLogicCheck.Text = "逻辑校验";
            // 
            // userControlAttriCheck1
            // 
            this.userControlAttriCheck1.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.userControlAttriCheck1.Appearance.BackColor2 = System.Drawing.Color.Transparent;
            this.userControlAttriCheck1.Appearance.Options.UseBackColor = true;
            this.userControlAttriCheck1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControlAttriCheck1.Location = new System.Drawing.Point(0, 0);
            this.userControlAttriCheck1.Margin = new System.Windows.Forms.Padding(5);
            this.userControlAttriCheck1.Name = "userControlAttriCheck1";
            this.userControlAttriCheck1.Size = new System.Drawing.Size(389, 563);
            this.userControlAttriCheck1.TabIndex = 1;
            // 
            // xtraTabPageInputData
            // 
            this.xtraTabPageInputData.Controls.Add(this.userControlInputData);
            this.xtraTabPageInputData.Name = "xtraTabPageInputData";
            this.xtraTabPageInputData.PageVisible = false;
            this.xtraTabPageInputData.Size = new System.Drawing.Size(389, 563);
            this.xtraTabPageInputData.Text = "数据导入";
            // 
            // userControlInputData
            // 
            this.userControlInputData.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.userControlInputData.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.userControlInputData.Appearance.Options.UseBackColor = true;
            this.userControlInputData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControlInputData.Location = new System.Drawing.Point(0, 0);
            this.userControlInputData.Margin = new System.Windows.Forms.Padding(5);
            this.userControlInputData.Name = "userControlInputData";
            this.userControlInputData.Padding = new System.Windows.Forms.Padding(2);
            this.userControlInputData.Size = new System.Drawing.Size(389, 563);
            this.userControlInputData.TabIndex = 6;
            // 
            // xtraTabPageUpdate
            // 
            this.xtraTabPageUpdate.Controls.Add(this.userControlUpdate1);
            this.xtraTabPageUpdate.Name = "xtraTabPageUpdate";
            this.xtraTabPageUpdate.PageVisible = false;
            this.xtraTabPageUpdate.Size = new System.Drawing.Size(389, 563);
            this.xtraTabPageUpdate.Text = "数据更新";
            // 
            // userControlUpdate1
            // 
            this.userControlUpdate1.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.userControlUpdate1.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.userControlUpdate1.Appearance.Options.UseBackColor = true;
            this.userControlUpdate1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControlUpdate1.Location = new System.Drawing.Point(0, 0);
            this.userControlUpdate1.Name = "userControlUpdate1";
            this.userControlUpdate1.Size = new System.Drawing.Size(389, 563);
            this.userControlUpdate1.TabIndex = 0;
            this.userControlUpdate1.Visible = false;
            // 
            // userControlInfo
            // 
            this.userControlInfo.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.userControlInfo.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.userControlInfo.Appearance.Options.UseBackColor = true;
            this.userControlInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControlInfo.EditLayer = null;
            this.userControlInfo.hook = null;
            this.userControlInfo.Location = new System.Drawing.Point(0, 0);
            this.userControlInfo.Name = "userControlInfo";
            this.userControlInfo.PointLocation = null;
            this.userControlInfo.PointLocation2 = null;
            this.userControlInfo.Size = new System.Drawing.Size(245, 531);
            this.userControlInfo.TabIndex = 0;
            // 
            // userControlLayerControl
            // 
            this.userControlLayerControl.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.userControlLayerControl.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.userControlLayerControl.Appearance.Options.UseBackColor = true;
            this.userControlLayerControl.Cursor = System.Windows.Forms.Cursors.Default;
            this.userControlLayerControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControlLayerControl.Location = new System.Drawing.Point(0, 0);
            this.userControlLayerControl.Name = "userControlLayerControl";
            this.userControlLayerControl.Size = new System.Drawing.Size(266, 307);
            this.userControlLayerControl.TabIndex = 4;
            this.userControlLayerControl.Visible = false;
            // 
            // xtraTabPageSelect
            // 
            this.xtraTabPageSelect.Controls.Add(this.userControlSelectLayerSet1);
            this.xtraTabPageSelect.Name = "xtraTabPageSelect";
            this.xtraTabPageSelect.PageVisible = false;
            this.xtraTabPageSelect.Size = new System.Drawing.Size(266, 532);
            this.xtraTabPageSelect.Text = "选择";
            // 
            // userControlSelectLayerSet1
            // 
            this.userControlSelectLayerSet1.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.userControlSelectLayerSet1.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.userControlSelectLayerSet1.Appearance.Options.UseBackColor = true;
            this.userControlSelectLayerSet1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControlSelectLayerSet1.Hook = null;
            this.userControlSelectLayerSet1.Location = new System.Drawing.Point(0, 0);
            this.userControlSelectLayerSet1.Name = "userControlSelectLayerSet1";
            this.userControlSelectLayerSet1.Padding = new System.Windows.Forms.Padding(5);
            this.userControlSelectLayerSet1.Size = new System.Drawing.Size(266, 532);
            this.userControlSelectLayerSet1.TabIndex = 0;
            // 
            // ribbonPageGroupQuery
            // 
            this.ribbonPageGroupQuery.AllowMinimize = false;
            this.ribbonPageGroupQuery.ItemLinks.Add(this.barButtonItemIdentify2);
            this.ribbonPageGroupQuery.ItemLinks.Add(this.barButtonItemLocation);
            this.ribbonPageGroupQuery.ItemLinks.Add(this.barButtonItemPlace);
            this.ribbonPageGroupQuery.ItemLinks.Add(this.barButtonItemQueryTF);
            this.ribbonPageGroupQuery.Name = "ribbonPageGroupQuery";
            this.ribbonPageGroupQuery.Text = "专题查询";
            // 
            // barButtonItemQueryTF
            // 
            this.barButtonItemQueryTF.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            this.barButtonItemQueryTF.Caption = "图幅查询";
            this.barButtonItemQueryTF.Id = 105;
            this.barButtonItemQueryTF.ImageIndex = 79;
            this.barButtonItemQueryTF.LargeImageIndex = 13;
            this.barButtonItemQueryTF.Name = "barButtonItemQueryTF";
            this.barButtonItemQueryTF.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.barButtonItemQueryTF.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemQueryTF_ItemClick);
            // 
            // ribbonPageGroupQuery2
            // 
            this.ribbonPageGroupQuery2.AllowMinimize = false;
            this.ribbonPageGroupQuery2.ItemLinks.Add(this.barButtonItemQueryZT);
            this.ribbonPageGroupQuery2.ItemLinks.Add(this.barButtonItemQueryXB);
            this.ribbonPageGroupQuery2.ItemLinks.Add(this.barButtonItemQueryKind);
            this.ribbonPageGroupQuery2.ItemLinks.Add(this.barButtonItemQueryYear);
            this.ribbonPageGroupQuery2.Name = "ribbonPageGroupQuery2";
            this.ribbonPageGroupQuery2.Text = "造林查询";
            // 
            // barButtonItemQueryXB
            // 
            this.barButtonItemQueryXB.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            this.barButtonItemQueryXB.Caption = "小班查询";
            this.barButtonItemQueryXB.Description = "变更小班查询";
            this.barButtonItemQueryXB.Id = 138;
            this.barButtonItemQueryXB.ImageIndex = 91;
            this.barButtonItemQueryXB.LargeImageIndex = 42;
            this.barButtonItemQueryXB.Name = "barButtonItemQueryXB";
            this.barButtonItemQueryXB.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.barButtonItemQueryXB.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemQueryXB_ItemClick);
            // 
            // ribbonPageGroupMapView2
            // 
            this.ribbonPageGroupMapView2.ItemLinks.Add(this.barButtonItemFullMap);
            this.ribbonPageGroupMapView2.ItemLinks.Add(this.barButtonItemPan);
            this.ribbonPageGroupMapView2.ItemLinks.Add(this.barButtonItemZoomIn);
            this.ribbonPageGroupMapView2.ItemLinks.Add(this.barButtonItemZoomOut);
            this.ribbonPageGroupMapView2.ItemLinks.Add(this.barButtonItemRefresh);
            this.ribbonPageGroupMapView2.ItemLinks.Add(this.barButtonItemBack, true);
            this.ribbonPageGroupMapView2.ItemLinks.Add(this.barButtonItemForward);
            this.ribbonPageGroupMapView2.ItemLinks.Add(this.barButtonItemTOC);
            this.ribbonPageGroupMapView2.ItemLinks.Add(this.barButtonItemSelectFeature);
            this.ribbonPageGroupMapView2.ItemLinks.Add(this.barButtonItemClearSelectFeature);
            this.ribbonPageGroupMapView2.ItemLinks.Add(this.barButtonItemIdentify2);
            this.ribbonPageGroupMapView2.Name = "ribbonPageGroupMapView2";
            this.ribbonPageGroupMapView2.Text = "地图浏览";
            // 
            // ribbonPageGroupMapView3
            // 
            this.ribbonPageGroupMapView3.ItemLinks.Add(this.barButtonItemFullMap);
            this.ribbonPageGroupMapView3.ItemLinks.Add(this.barButtonItemZoomOut);
            this.ribbonPageGroupMapView3.ItemLinks.Add(this.barButtonItemZoomIn);
            this.ribbonPageGroupMapView3.ItemLinks.Add(this.barButtonItemPan);
            this.ribbonPageGroupMapView3.ItemLinks.Add(this.barButtonItemRefresh);
            this.ribbonPageGroupMapView3.ItemLinks.Add(this.barButtonItemBack, true);
            this.ribbonPageGroupMapView3.ItemLinks.Add(this.barButtonItemForward);
            this.ribbonPageGroupMapView3.ItemLinks.Add(this.barButtonItemTOC, true);
            this.ribbonPageGroupMapView3.ItemLinks.Add(this.barButtonItemOverView);
            this.ribbonPageGroupMapView3.ItemLinks.Add(this.barButtonItemTOC2);
            this.ribbonPageGroupMapView3.ItemLinks.Add(this.barButtonItemSelectFeature, true);
            this.ribbonPageGroupMapView3.ItemLinks.Add(this.barButtonItemClearSelectFeature);
            this.ribbonPageGroupMapView3.ItemLinks.Add(this.barButtonItemSelectLayerSet, true);
            this.ribbonPageGroupMapView3.ItemLinks.Add(this.barButtonItemSelectedFeaturesReport);
            this.ribbonPageGroupMapView3.Name = "ribbonPageGroupMapView3";
            this.ribbonPageGroupMapView3.Text = "地图浏览";
            // 
            // xtraTabPageMapFind
            // 
            this.xtraTabPageMapFind.Controls.Add(this.userControlMapFind1);
            this.xtraTabPageMapFind.Name = "xtraTabPageMapFind";
            this.xtraTabPageMapFind.PageVisible = false;
            this.xtraTabPageMapFind.Size = new System.Drawing.Size(266, 532);
            this.xtraTabPageMapFind.Text = "查找";
            // 
            // userControlMapFind1
            // 
            this.userControlMapFind1.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.userControlMapFind1.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.userControlMapFind1.Appearance.Options.UseBackColor = true;
            this.userControlMapFind1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControlMapFind1.Location = new System.Drawing.Point(0, 0);
            this.userControlMapFind1.Name = "userControlMapFind1";
            this.userControlMapFind1.Padding = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.userControlMapFind1.Size = new System.Drawing.Size(266, 532);
            this.userControlMapFind1.TabIndex = 2;
            // 
            // xtraTabPageLocation
            // 
            this.xtraTabPageLocation.Controls.Add(this.userControlLocation);
            this.xtraTabPageLocation.Name = "xtraTabPageLocation";
            this.xtraTabPageLocation.PageVisible = false;
            this.xtraTabPageLocation.Size = new System.Drawing.Size(266, 532);
            this.xtraTabPageLocation.Text = "定位";
            // 
            // userControlLocation
            // 
            this.userControlLocation.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.userControlLocation.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.userControlLocation.Appearance.Options.UseBackColor = true;
            this.userControlLocation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControlLocation.hook = null;
            this.userControlLocation.Location = new System.Drawing.Point(0, 0);
            this.userControlLocation.Name = "userControlLocation";
            this.userControlLocation.Size = new System.Drawing.Size(266, 532);
            this.userControlLocation.TabIndex = 0;
            // 
            // ribbonPageGroupMxt
            // 
            this.ribbonPageGroupMxt.AllowMinimize = false;
            this.ribbonPageGroupMxt.ItemLinks.Add(this.barButtonItemZone);
            this.ribbonPageGroupMxt.ItemLinks.Add(this.barButtonItemDesign);
            this.ribbonPageGroupMxt.ItemLinks.Add(this.barButtonItemNormal);
            this.ribbonPageGroupMxt.Name = "ribbonPageGroupMxt";
            this.ribbonPageGroupMxt.Text = "制图模版";
            // 
            // barButtonItemZone
            // 
            this.barButtonItemZone.Caption = "调查图";
            this.barButtonItemZone.Description = "外业调查图";
            this.barButtonItemZone.Id = 102;
            this.barButtonItemZone.ImageIndex = 189;
            this.barButtonItemZone.LargeImageIndex = 126;
            this.barButtonItemZone.Name = "barButtonItemZone";
            this.barButtonItemZone.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // barButtonItemDesign
            // 
            this.barButtonItemDesign.Caption = "设计图";
            this.barButtonItemDesign.Description = "作业设计图";
            this.barButtonItemDesign.Id = 103;
            this.barButtonItemDesign.ImageIndex = 93;
            this.barButtonItemDesign.LargeImageIndex = 43;
            this.barButtonItemDesign.Name = "barButtonItemDesign";
            this.barButtonItemDesign.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // barButtonItemNormal
            // 
            this.barButtonItemNormal.Caption = "自定义";
            this.barButtonItemNormal.Id = 104;
            this.barButtonItemNormal.ImageIndex = 297;
            this.barButtonItemNormal.LargeImageIndex = 3;
            this.barButtonItemNormal.Name = "barButtonItemNormal";
            this.barButtonItemNormal.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // ribbonPageGroupPageTool
            // 
            this.ribbonPageGroupPageTool.AllowMinimize = false;
            this.ribbonPageGroupPageTool.ItemLinks.Add(this.barButtonItemMapFrame);
            this.ribbonPageGroupPageTool.ItemLinks.Add(this.barButtonItemMapGrid);
            this.ribbonPageGroupPageTool.ItemLinks.Add(this.barButtonItemMapLegend);
            this.ribbonPageGroupPageTool.ItemLinks.Add(this.barButtonItemMapScaleBar, true);
            this.ribbonPageGroupPageTool.ItemLinks.Add(this.barButtonItemScaleText);
            this.ribbonPageGroupPageTool.ItemLinks.Add(this.barButtonItemMapNorthArrow);
            this.ribbonPageGroupPageTool.ItemLinks.Add(this.barButtonItemMapText);
            this.ribbonPageGroupPageTool.ItemLinks.Add(this.barButtonItemMapComment);
            this.ribbonPageGroupPageTool.ItemLinks.Add(this.barButtonItemMapTable);
            this.ribbonPageGroupPageTool.Name = "ribbonPageGroupPageTool";
            this.ribbonPageGroupPageTool.Text = "制图工具";
            // 
            // barButtonItemMapFrame
            // 
            this.barButtonItemMapFrame.Caption = "图框";
            this.barButtonItemMapFrame.Id = 91;
            this.barButtonItemMapFrame.ImageIndex = 48;
            this.barButtonItemMapFrame.LargeImageIndex = 291;
            this.barButtonItemMapFrame.Name = "barButtonItemMapFrame";
            this.barButtonItemMapFrame.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // barButtonItemMapGrid
            // 
            this.barButtonItemMapGrid.Caption = "公里网";
            this.barButtonItemMapGrid.Id = 98;
            this.barButtonItemMapGrid.ImageIndex = 332;
            this.barButtonItemMapGrid.LargeImageIndex = 346;
            this.barButtonItemMapGrid.Name = "barButtonItemMapGrid";
            this.barButtonItemMapGrid.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // barButtonItemMapLegend
            // 
            this.barButtonItemMapLegend.Caption = "图例";
            this.barButtonItemMapLegend.Id = 92;
            this.barButtonItemMapLegend.ImageIndex = 336;
            this.barButtonItemMapLegend.LargeImageIndex = 244;
            this.barButtonItemMapLegend.Name = "barButtonItemMapLegend";
            this.barButtonItemMapLegend.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // barButtonItemMapScaleBar
            // 
            this.barButtonItemMapScaleBar.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            this.barButtonItemMapScaleBar.Caption = "比例尺";
            this.barButtonItemMapScaleBar.Id = 93;
            this.barButtonItemMapScaleBar.ImageIndex = 339;
            this.barButtonItemMapScaleBar.LargeImageIndex = 197;
            this.barButtonItemMapScaleBar.Name = "barButtonItemMapScaleBar";
            this.barButtonItemMapScaleBar.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // barButtonItemScaleText
            // 
            this.barButtonItemScaleText.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            this.barButtonItemScaleText.Caption = "比例尺文本";
            this.barButtonItemScaleText.Id = 94;
            this.barButtonItemScaleText.ImageIndex = 252;
            this.barButtonItemScaleText.LargeImageIndex = 196;
            this.barButtonItemScaleText.Name = "barButtonItemScaleText";
            this.barButtonItemScaleText.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // barButtonItemMapNorthArrow
            // 
            this.barButtonItemMapNorthArrow.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            this.barButtonItemMapNorthArrow.Caption = "指北针";
            this.barButtonItemMapNorthArrow.Id = 95;
            this.barButtonItemMapNorthArrow.ImageIndex = 5;
            this.barButtonItemMapNorthArrow.LargeImageIndex = 85;
            this.barButtonItemMapNorthArrow.Name = "barButtonItemMapNorthArrow";
            this.barButtonItemMapNorthArrow.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // barButtonItemMapText
            // 
            this.barButtonItemMapText.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            this.barButtonItemMapText.Caption = "文本";
            this.barButtonItemMapText.Id = 96;
            this.barButtonItemMapText.ImageIndex = 335;
            this.barButtonItemMapText.LargeImageIndex = 279;
            this.barButtonItemMapText.Name = "barButtonItemMapText";
            this.barButtonItemMapText.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // barButtonItemMapComment
            // 
            this.barButtonItemMapComment.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            this.barButtonItemMapComment.Caption = "注记";
            this.barButtonItemMapComment.Id = 97;
            this.barButtonItemMapComment.ImageIndex = 16;
            this.barButtonItemMapComment.LargeImageIndex = 280;
            this.barButtonItemMapComment.Name = "barButtonItemMapComment";
            this.barButtonItemMapComment.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // barButtonItemMapTable
            // 
            this.barButtonItemMapTable.Caption = "表格";
            this.barButtonItemMapTable.Id = 99;
            this.barButtonItemMapTable.ImageIndex = 224;
            this.barButtonItemMapTable.LargeImageIndex = 315;
            this.barButtonItemMapTable.Name = "barButtonItemMapTable";
            this.barButtonItemMapTable.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // ribbonPageGroupPageView
            // 
            this.ribbonPageGroupPageView.ItemLinks.Add(this.barButtonItemPageWhole);
            this.ribbonPageGroupPageView.ItemLinks.Add(this.barButtonItemPageZoomIn);
            this.ribbonPageGroupPageView.ItemLinks.Add(this.barButtonItemPageZoomOut);
            this.ribbonPageGroupPageView.ItemLinks.Add(this.barButtonItemPagePan);
            this.ribbonPageGroupPageView.ItemLinks.Add(this.barButtonItemSelectElement, true);
            this.ribbonPageGroupPageView.ItemLinks.Add(this.barButtonItemUndo, true);
            this.ribbonPageGroupPageView.ItemLinks.Add(this.barButtonItemRedo);
            this.ribbonPageGroupPageView.Name = "ribbonPageGroupPageView";
            this.ribbonPageGroupPageView.Text = "页面浏览";
            // 
            // barButtonItemPageWhole
            // 
            this.barButtonItemPageWhole.Caption = "全图";
            this.barButtonItemPageWhole.Id = 85;
            this.barButtonItemPageWhole.ImageIndex = 294;
            this.barButtonItemPageWhole.LargeImageIndex = 373;
            this.barButtonItemPageWhole.Name = "barButtonItemPageWhole";
            this.barButtonItemPageWhole.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText)));
            // 
            // barButtonItemPageZoomIn
            // 
            this.barButtonItemPageZoomIn.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            this.barButtonItemPageZoomIn.Caption = "放大";
            this.barButtonItemPageZoomIn.Id = 82;
            this.barButtonItemPageZoomIn.ImageIndex = 290;
            this.barButtonItemPageZoomIn.LargeImageIndex = 100;
            this.barButtonItemPageZoomIn.Name = "barButtonItemPageZoomIn";
            this.barButtonItemPageZoomIn.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText)));
            // 
            // barButtonItemPageZoomOut
            // 
            this.barButtonItemPageZoomOut.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            this.barButtonItemPageZoomOut.Caption = "缩小";
            this.barButtonItemPageZoomOut.Id = 83;
            this.barButtonItemPageZoomOut.ImageIndex = 291;
            this.barButtonItemPageZoomOut.LargeImageIndex = 99;
            this.barButtonItemPageZoomOut.Name = "barButtonItemPageZoomOut";
            this.barButtonItemPageZoomOut.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText)));
            // 
            // barButtonItemPagePan
            // 
            this.barButtonItemPagePan.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            this.barButtonItemPagePan.Caption = "漫游";
            this.barButtonItemPagePan.Id = 84;
            this.barButtonItemPagePan.ImageIndex = 56;
            this.barButtonItemPagePan.LargeImageIndex = 101;
            this.barButtonItemPagePan.Name = "barButtonItemPagePan";
            this.barButtonItemPagePan.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText)));
            // 
            // barButtonItemSelectElement
            // 
            this.barButtonItemSelectElement.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            this.barButtonItemSelectElement.Caption = "选择";
            this.barButtonItemSelectElement.Id = 88;
            this.barButtonItemSelectElement.ImageIndex = 246;
            this.barButtonItemSelectElement.LargeImageIndex = 284;
            this.barButtonItemSelectElement.Name = "barButtonItemSelectElement";
            this.barButtonItemSelectElement.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText)));
            // 
            // barButtonItemUndo
            // 
            this.barButtonItemUndo.Caption = "撤销";
            this.barButtonItemUndo.Id = 89;
            this.barButtonItemUndo.ImageIndex = 225;
            this.barButtonItemUndo.LargeImageIndex = 111;
            this.barButtonItemUndo.Name = "barButtonItemUndo";
            this.barButtonItemUndo.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText)));
            // 
            // barButtonItemRedo
            // 
            this.barButtonItemRedo.Caption = "重做";
            this.barButtonItemRedo.Id = 90;
            this.barButtonItemRedo.ImageIndex = 229;
            this.barButtonItemRedo.LargeImageIndex = 112;
            this.barButtonItemRedo.Name = "barButtonItemRedo";
            this.barButtonItemRedo.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText)));
            // 
            // ribbonPageGroupMapView4
            // 
            this.ribbonPageGroupMapView4.ItemLinks.Add(this.barButtonItemFullMap);
            this.ribbonPageGroupMapView4.ItemLinks.Add(this.barButtonItemPan);
            this.ribbonPageGroupMapView4.ItemLinks.Add(this.barButtonItemZoomIn);
            this.ribbonPageGroupMapView4.ItemLinks.Add(this.barButtonItemZoomOut);
            this.ribbonPageGroupMapView4.ItemLinks.Add(this.barButtonItemRefresh);
            this.ribbonPageGroupMapView4.ItemLinks.Add(this.barButtonItemBack, true);
            this.ribbonPageGroupMapView4.ItemLinks.Add(this.barButtonItemForward);
            this.ribbonPageGroupMapView4.ItemLinks.Add(this.barButtonItemTOC, true);
            this.ribbonPageGroupMapView4.ItemLinks.Add(this.barButtonItemOverView);
            this.ribbonPageGroupMapView4.Name = "ribbonPageGroupMapView4";
            this.ribbonPageGroupMapView4.Text = "地图浏览";
            // 
            // barButtonItemPagePre
            // 
            this.barButtonItemPagePre.Caption = "上幅";
            this.barButtonItemPagePre.Id = 86;
            this.barButtonItemPagePre.ImageIndex = 143;
            this.barButtonItemPagePre.Name = "barButtonItemPagePre";
            // 
            // barButtonItemPageNext
            // 
            this.barButtonItemPageNext.Caption = "下幅";
            this.barButtonItemPageNext.Id = 87;
            this.barButtonItemPageNext.ImageIndex = 137;
            this.barButtonItemPageNext.Name = "barButtonItemPageNext";
            // 
            // xtraTabPageXBchange
            // 
            this.xtraTabPageXBchange.Controls.Add(this.userControlXBGrowth1);
            this.xtraTabPageXBchange.Controls.Add(this.userControlXBLayerCombine1);
            this.xtraTabPageXBchange.Controls.Add(this.userControlXBSet31);
            this.xtraTabPageXBchange.Controls.Add(this.userControlXBSet21);
            this.xtraTabPageXBchange.Controls.Add(this.userControlInputYG1);
            this.xtraTabPageXBchange.Controls.Add(this.userControlXBSet1);
            this.xtraTabPageXBchange.Name = "xtraTabPageXBchange";
            this.xtraTabPageXBchange.Size = new System.Drawing.Size(266, 532);
            this.xtraTabPageXBchange.Text = "变更";
            this.xtraTabPageXBchange.Tooltip = "变更编辑设置";
            // 
            // userControlXBGrowth1
            // 
            this.userControlXBGrowth1.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.userControlXBGrowth1.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.userControlXBGrowth1.Appearance.Options.UseBackColor = true;
            this.userControlXBGrowth1.Location = new System.Drawing.Point(0, 0);
            this.userControlXBGrowth1.Name = "userControlXBGrowth1";
            this.userControlXBGrowth1.Padding = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.userControlXBGrowth1.Size = new System.Drawing.Size(274, 708);
            this.userControlXBGrowth1.TabIndex = 5;
            // 
            // userControlXBLayerCombine1
            // 
            this.userControlXBLayerCombine1.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.userControlXBLayerCombine1.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.userControlXBLayerCombine1.Appearance.Options.UseBackColor = true;
            this.userControlXBLayerCombine1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControlXBLayerCombine1.Location = new System.Drawing.Point(0, 0);
            this.userControlXBLayerCombine1.Name = "userControlXBLayerCombine1";
            this.userControlXBLayerCombine1.Padding = new System.Windows.Forms.Padding(6, 0, 6, 6);
            this.userControlXBLayerCombine1.Size = new System.Drawing.Size(266, 532);
            this.userControlXBLayerCombine1.TabIndex = 4;
            // 
            // userControlXBSet31
            // 
            this.userControlXBSet31.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.userControlXBSet31.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.userControlXBSet31.Appearance.Options.UseBackColor = true;
            this.userControlXBSet31.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControlXBSet31.Location = new System.Drawing.Point(0, 0);
            this.userControlXBSet31.Name = "userControlXBSet31";
            this.userControlXBSet31.Padding = new System.Windows.Forms.Padding(6, 0, 6, 6);
            this.userControlXBSet31.Size = new System.Drawing.Size(266, 532);
            this.userControlXBSet31.TabIndex = 3;
            // 
            // userControlXBSet21
            // 
            this.userControlXBSet21.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.userControlXBSet21.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.userControlXBSet21.Appearance.Options.UseBackColor = true;
            this.userControlXBSet21.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControlXBSet21.Location = new System.Drawing.Point(0, 0);
            this.userControlXBSet21.Name = "userControlXBSet21";
            this.userControlXBSet21.Padding = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.userControlXBSet21.Size = new System.Drawing.Size(266, 532);
            this.userControlXBSet21.TabIndex = 2;
            // 
            // userControlInputYG1
            // 
            this.userControlInputYG1.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.userControlInputYG1.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.userControlInputYG1.Appearance.Options.UseBackColor = true;
            this.userControlInputYG1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControlInputYG1.Location = new System.Drawing.Point(0, 0);
            this.userControlInputYG1.Name = "userControlInputYG1";
            this.userControlInputYG1.Padding = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.userControlInputYG1.Size = new System.Drawing.Size(266, 532);
            this.userControlInputYG1.TabIndex = 1;
            // 
            // userControlXBSet1
            // 
            this.userControlXBSet1.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.userControlXBSet1.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.userControlXBSet1.Appearance.Options.UseBackColor = true;
            this.userControlXBSet1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControlXBSet1.Location = new System.Drawing.Point(0, 0);
            this.userControlXBSet1.Name = "userControlXBSet1";
            this.userControlXBSet1.Padding = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.userControlXBSet1.Size = new System.Drawing.Size(266, 532);
            this.userControlXBSet1.TabIndex = 0;
            // 
            // userControlQueryResult1
            // 
            this.userControlQueryResult1.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.userControlQueryResult1.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.userControlQueryResult1.Appearance.Options.UseBackColor = true;
            this.userControlQueryResult1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControlQueryResult1.Location = new System.Drawing.Point(0, 0);
            this.userControlQueryResult1.Name = "userControlQueryResult1";
            this.userControlQueryResult1.Size = new System.Drawing.Size(1074, 162);
            this.userControlQueryResult1.TabIndex = 0;
            // 
            // barButtonToolbox
            // 
            this.barButtonToolbox.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            this.barButtonToolbox.Caption = "工具箱";
            this.barButtonToolbox.Down = true;
            this.barButtonToolbox.Id = 100;
            this.barButtonToolbox.ImageIndex = 38;
            this.barButtonToolbox.Name = "barButtonToolbox";
            this.barButtonToolbox.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemToolbox_ItemClick);
            // 
            // barButtonToolView
            // 
            this.barButtonToolView.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            this.barButtonToolView.Caption = "最小化功能区";
            this.barButtonToolView.Id = 101;
            this.barButtonToolView.ImageIndex = 47;
            this.barButtonToolView.Name = "barButtonToolView";
            this.barButtonToolView.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemToolView_ItemClick);
            // 
            // barEditItem1
            // 
            this.barEditItem1.Caption = "大图标";
            this.barEditItem1.Edit = this.repositoryItemCheckEdit1;
            this.barEditItem1.Id = 107;
            this.barEditItem1.Name = "barEditItem1";
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Caption = "Check";
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // barSubItemButtonStyle
            // 
            this.barSubItemButtonStyle.Caption = "按钮类型";
            this.barSubItemButtonStyle.Id = 108;
            this.barSubItemButtonStyle.ImageIndex = 298;
            this.barSubItemButtonStyle.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItemLargeButton),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItemSmallButton),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItemSmallText)});
            this.barSubItemButtonStyle.Name = "barSubItemButtonStyle";
            // 
            // barButtonItemLargeButton
            // 
            this.barButtonItemLargeButton.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            this.barButtonItemLargeButton.Caption = "大图标";
            this.barButtonItemLargeButton.Down = true;
            this.barButtonItemLargeButton.Id = 111;
            this.barButtonItemLargeButton.ImageIndex = 77;
            this.barButtonItemLargeButton.Name = "barButtonItemLargeButton";
            this.barButtonItemLargeButton.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemLargeButton_ItemClick);
            // 
            // barButtonItemSmallButton
            // 
            this.barButtonItemSmallButton.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            this.barButtonItemSmallButton.Caption = "小图标";
            this.barButtonItemSmallButton.Id = 112;
            this.barButtonItemSmallButton.ImageIndex = 190;
            this.barButtonItemSmallButton.Name = "barButtonItemSmallButton";
            this.barButtonItemSmallButton.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemSmallButton_ItemClick);
            // 
            // barButtonItemSmallText
            // 
            this.barButtonItemSmallText.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            this.barButtonItemSmallText.Caption = "带文字的小图标";
            this.barButtonItemSmallText.Id = 113;
            this.barButtonItemSmallText.ImageIndex = 208;
            this.barButtonItemSmallText.Name = "barButtonItemSmallText";
            this.barButtonItemSmallText.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemSmallText_ItemClick);
            // 
            // barButtonGroup1
            // 
            this.barButtonGroup1.Caption = "barButtonGroup1";
            this.barButtonGroup1.Id = 133;
            this.barButtonGroup1.Name = "barButtonGroup1";
            this.barButtonGroup1.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText)));
            // 
            // userControlQueryXB
            // 
            this.userControlQueryXB.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.userControlQueryXB.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.userControlQueryXB.Appearance.Options.UseBackColor = true;
            this.userControlQueryXB.AutoScroll = true;
            this.userControlQueryXB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControlQueryXB.Location = new System.Drawing.Point(6, 1);
            this.userControlQueryXB.Name = "userControlQueryXB";
            this.userControlQueryXB.Padding = new System.Windows.Forms.Padding(4);
            this.userControlQueryXB.Size = new System.Drawing.Size(233, 529);
            this.userControlQueryXB.TabIndex = 0;
            // 
            // ribbonPageGroupCaoTu
            // 
            this.ribbonPageGroupCaoTu.AllowMinimize = false;
            this.ribbonPageGroupCaoTu.ImageIndex = 61;
            this.ribbonPageGroupCaoTu.ItemLinks.Add(this.barButtonItemInputYG);
            this.ribbonPageGroupCaoTu.ItemLinks.Add(this.barButtonItemInputZT);
            this.ribbonPageGroupCaoTu.ItemLinks.Add(this.barButtonItemInputDC);
            this.ribbonPageGroupCaoTu.ItemLinks.Add(this.barButtonItemInputOther);
            this.ribbonPageGroupCaoTu.Name = "ribbonPageGroupCaoTu";
            this.ribbonPageGroupCaoTu.Text = "变化小班编辑";
            this.ribbonPageGroupCaoTu.Visible = false;
            // 
            // barButtonItemInputYG
            // 
            this.barButtonItemInputYG.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            this.barButtonItemInputYG.Caption = "导入遥感";
            this.barButtonItemInputYG.Description = "导入遥感判读变化数据";
            this.barButtonItemInputYG.Id = 139;
            this.barButtonItemInputYG.ImageIndex = 50;
            this.barButtonItemInputYG.LargeImageIndex = 224;
            this.barButtonItemInputYG.Name = "barButtonItemInputYG";
            this.barButtonItemInputYG.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // barButtonItemInputZT
            // 
            this.barButtonItemInputZT.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            this.barButtonItemInputZT.Caption = "专题合并";
            this.barButtonItemInputZT.Description = "专题变化数据合并";
            this.barButtonItemInputZT.Id = 140;
            this.barButtonItemInputZT.ImageIndex = 334;
            this.barButtonItemInputZT.LargeImageIndex = 232;
            this.barButtonItemInputZT.Name = "barButtonItemInputZT";
            this.barButtonItemInputZT.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // barButtonItemInputDC
            // 
            this.barButtonItemInputDC.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            this.barButtonItemInputDC.Caption = "外调核实";
            this.barButtonItemInputDC.Description = "导入外业调查核实数据";
            this.barButtonItemInputDC.Id = 141;
            this.barButtonItemInputDC.ImageIndex = 107;
            this.barButtonItemInputDC.LargeImageIndex = 399;
            this.barButtonItemInputDC.Name = "barButtonItemInputDC";
            this.barButtonItemInputDC.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // barButtonItemInputOther
            // 
            this.barButtonItemInputOther.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            this.barButtonItemInputOther.Caption = "其它更新";
            this.barButtonItemInputOther.Description = "其他变化更新";
            this.barButtonItemInputOther.Id = 142;
            this.barButtonItemInputOther.ImageIndex = 268;
            this.barButtonItemInputOther.LargeImageIndex = 228;
            this.barButtonItemInputOther.Name = "barButtonItemInputOther";
            this.barButtonItemInputOther.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // barButtonItemLayerCombine
            // 
            this.barButtonItemLayerCombine.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            this.barButtonItemLayerCombine.Caption = "年度合并";
            this.barButtonItemLayerCombine.Description = "年度变更数据合并";
            this.barButtonItemLayerCombine.Id = 143;
            this.barButtonItemLayerCombine.ImageIndex = 282;
            this.barButtonItemLayerCombine.LargeImageIndex = 320;
            this.barButtonItemLayerCombine.Name = "barButtonItemLayerCombine";
            this.barButtonItemLayerCombine.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // ribbonPageGroupXB
            // 
            this.ribbonPageGroupXB.AllowMinimize = false;
            this.ribbonPageGroupXB.ItemLinks.Add(this.barButtonItemLayerCombine);
            this.ribbonPageGroupXB.ItemLinks.Add(this.barButtonItemGrowthModel);
            this.ribbonPageGroupXB.ItemLinks.Add(this.barButtonItemXBEdit);
            this.ribbonPageGroupXB.Name = "ribbonPageGroupXB";
            this.ribbonPageGroupXB.Text = "年度小班编辑";
            this.ribbonPageGroupXB.Visible = false;
            // 
            // barButtonItemGrowthModel
            // 
            this.barButtonItemGrowthModel.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            this.barButtonItemGrowthModel.Caption = "自然更新";
            this.barButtonItemGrowthModel.Id = 158;
            this.barButtonItemGrowthModel.LargeImageIndex = 271;
            this.barButtonItemGrowthModel.Name = "barButtonItemGrowthModel";
            this.barButtonItemGrowthModel.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barButtonItemGrowthModel.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // barButtonItemXBEdit
            // 
            this.barButtonItemXBEdit.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            this.barButtonItemXBEdit.Caption = "小班编辑";
            this.barButtonItemXBEdit.Id = 144;
            this.barButtonItemXBEdit.ImageIndex = 96;
            this.barButtonItemXBEdit.LargeImageIndex = 221;
            this.barButtonItemXBEdit.Name = "barButtonItemXBEdit";
            // 
            // xtraTabQuery
            // 
            this.xtraTabQuery.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabQuery.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Left;
            this.xtraTabQuery.HeaderOrientation = DevExpress.XtraTab.TabOrientation.Horizontal;
            this.xtraTabQuery.Location = new System.Drawing.Point(0, 0);
            this.xtraTabQuery.Name = "xtraTabQuery";
            this.xtraTabQuery.SelectedTabPage = this.xtraTabPage1;
            this.xtraTabQuery.Size = new System.Drawing.Size(1118, 168);
            this.xtraTabQuery.TabIndex = 1;
            this.xtraTabQuery.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1,
            this.xtraTabPage2,
            this.xtraTabPage3});
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Controls.Add(this.userControlQueryResult1);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(1074, 162);
            this.xtraTabPage1.Text = "查询";
            // 
            // xtraTabPage2
            // 
            this.xtraTabPage2.Controls.Add(this.userControlQueryResult2);
            this.xtraTabPage2.Name = "xtraTabPage2";
            this.xtraTabPage2.PageVisible = false;
            this.xtraTabPage2.Size = new System.Drawing.Size(1074, 162);
            this.xtraTabPage2.Text = "查询";
            // 
            // userControlQueryResult2
            // 
            this.userControlQueryResult2.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.userControlQueryResult2.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.userControlQueryResult2.Appearance.Options.UseBackColor = true;
            this.userControlQueryResult2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControlQueryResult2.Location = new System.Drawing.Point(0, 0);
            this.userControlQueryResult2.Name = "userControlQueryResult2";
            this.userControlQueryResult2.Size = new System.Drawing.Size(1074, 162);
            this.userControlQueryResult2.TabIndex = 1;
            // 
            // xtraTabPage3
            // 
            this.xtraTabPage3.Controls.Add(this.userControlSelectFeatureResport21);
            this.xtraTabPage3.Name = "xtraTabPage3";
            this.xtraTabPage3.Size = new System.Drawing.Size(1074, 162);
            toolTipItem2.Text = "要素属性列表";
            superToolTip2.Items.Add(toolTipItem2);
            this.xtraTabPage3.SuperTip = superToolTip2;
            this.xtraTabPage3.Text = "属性";
            // 
            // userControlSelectFeatureResport21
            // 
            this.userControlSelectFeatureResport21.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.userControlSelectFeatureResport21.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.userControlSelectFeatureResport21.Appearance.Options.UseBackColor = true;
            this.userControlSelectFeatureResport21.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControlSelectFeatureResport21.hook = null;
            this.userControlSelectFeatureResport21.Location = new System.Drawing.Point(0, 0);
            this.userControlSelectFeatureResport21.Name = "userControlSelectFeatureResport21";
            this.userControlSelectFeatureResport21.Size = new System.Drawing.Size(1074, 162);
            this.userControlSelectFeatureResport21.TabIndex = 0;
            // 
            // barButtonItemAddLayer3
            // 
            this.barButtonItemAddLayer3.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            this.barButtonItemAddLayer3.Caption = "添加栅格数据";
            this.barButtonItemAddLayer3.Id = 146;
            this.barButtonItemAddLayer3.ImageIndex = 50;
            this.barButtonItemAddLayer3.Name = "barButtonItemAddLayer3";
            this.barButtonItemAddLayer3.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.barButtonItemAddLayer3.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemAddLayer3_ItemClick);
            // 
            // xtraTabPageAddRasterlayer
            // 
            this.xtraTabPageAddRasterlayer.Controls.Add(this.userControlImageGeoReference1);
            this.xtraTabPageAddRasterlayer.Name = "xtraTabPageAddRasterlayer";
            this.xtraTabPageAddRasterlayer.PageVisible = false;
            this.xtraTabPageAddRasterlayer.Size = new System.Drawing.Size(266, 532);
            this.xtraTabPageAddRasterlayer.Text = "添加";
            this.xtraTabPageAddRasterlayer.Tooltip = "添加栅格数据";
            // 
            // userControlImageGeoReference1
            // 
            this.userControlImageGeoReference1.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.userControlImageGeoReference1.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.userControlImageGeoReference1.Appearance.Options.UseBackColor = true;
            this.userControlImageGeoReference1.AutoScroll = true;
            this.userControlImageGeoReference1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControlImageGeoReference1.Location = new System.Drawing.Point(0, 0);
            this.userControlImageGeoReference1.Name = "userControlImageGeoReference1";
            this.userControlImageGeoReference1.Padding = new System.Windows.Forms.Padding(6);
            this.userControlImageGeoReference1.PointLocation = null;
            this.userControlImageGeoReference1.Size = new System.Drawing.Size(266, 532);
            this.userControlImageGeoReference1.TabIndex = 0;
            // 
            // barButtonItemReportCF1
            // 
            this.barButtonItemReportCF1.Caption = "采伐统计表";
            this.barButtonItemReportCF1.Id = 153;
            this.barButtonItemReportCF1.LargeImageIndex = 371;
            this.barButtonItemReportCF1.Name = "barButtonItemReportCF1";
            // 
            // barButtonItemChartCF
            // 
            this.barButtonItemChartCF.Caption = "采伐统计图表";
            this.barButtonItemChartCF.Id = 155;
            this.barButtonItemChartCF.LargeImageIndex = 7;
            this.barButtonItemChartCF.Name = "barButtonItemChartCF";
            this.barButtonItemChartCF.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemChartCF_ItemClick);
            // 
            // barButtonItemReportZL
            // 
            this.barButtonItemReportZL.Caption = "造林统计表";
            this.barButtonItemReportZL.Id = 154;
            this.barButtonItemReportZL.LargeImageIndex = 281;
            this.barButtonItemReportZL.Name = "barButtonItemReportZL";
            // 
            // barButtonItemChartZL
            // 
            this.barButtonItemChartZL.Caption = "造林统计图表";
            this.barButtonItemChartZL.Id = 156;
            this.barButtonItemChartZL.LargeImageIndex = 7;
            this.barButtonItemChartZL.Name = "barButtonItemChartZL";
            this.barButtonItemChartZL.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemChartZL_ItemClick);
            // 
            // barButtonItemStatic
            // 
            this.barButtonItemStatic.Caption = "统计报表";
            this.barButtonItemStatic.Id = 147;
            this.barButtonItemStatic.LargeImageIndex = 212;
            this.barButtonItemStatic.Name = "barButtonItemStatic";
            this.barButtonItemStatic.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemStatic_ItemClick);
            // 
            // xtraTabPagePlace
            // 
            this.xtraTabPagePlace.Controls.Add(this.userControlPlace1);
            this.xtraTabPagePlace.Name = "xtraTabPagePlace";
            this.xtraTabPagePlace.PageVisible = false;
            this.xtraTabPagePlace.Size = new System.Drawing.Size(266, 532);
            this.xtraTabPagePlace.Text = "地名";
            // 
            // userControlPlace1
            // 
            this.userControlPlace1.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.userControlPlace1.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.userControlPlace1.Appearance.Options.UseBackColor = true;
            this.userControlPlace1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControlPlace1.hook = null;
            this.userControlPlace1.Location = new System.Drawing.Point(0, 0);
            this.userControlPlace1.Name = "userControlPlace1";
            this.userControlPlace1.Size = new System.Drawing.Size(266, 532);
            this.userControlPlace1.TabIndex = 0;
            // 
            // xtraTabPageTFH
            // 
            this.xtraTabPageTFH.Controls.Add(this.userControlQueryTFH1);
            this.xtraTabPageTFH.Name = "xtraTabPageTFH";
            this.xtraTabPageTFH.PageVisible = false;
            this.xtraTabPageTFH.Size = new System.Drawing.Size(266, 532);
            this.xtraTabPageTFH.Text = "图幅";
            // 
            // userControlQueryTFH1
            // 
            this.userControlQueryTFH1.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.userControlQueryTFH1.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.userControlQueryTFH1.Appearance.Options.UseBackColor = true;
            this.userControlQueryTFH1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControlQueryTFH1.hook = null;
            this.userControlQueryTFH1.Location = new System.Drawing.Point(0, 0);
            this.userControlQueryTFH1.Name = "userControlQueryTFH1";
            this.userControlQueryTFH1.Size = new System.Drawing.Size(266, 532);
            this.userControlQueryTFH1.TabIndex = 0;
            // 
            // userControlQueryCF1
            // 
            this.userControlQueryCF1.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.userControlQueryCF1.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.userControlQueryCF1.Appearance.Options.UseBackColor = true;
            this.userControlQueryCF1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControlQueryCF1.Location = new System.Drawing.Point(6, 1);
            this.userControlQueryCF1.Name = "userControlQueryCF1";
            this.userControlQueryCF1.Size = new System.Drawing.Size(233, 529);
            this.userControlQueryCF1.TabIndex = 1;
            this.userControlQueryCF1.Visible = false;
            // 
            // xtraTabPageKind
            // 
            this.xtraTabPageKind.Controls.Add(this.userControlQueryXB21);
            this.xtraTabPageKind.Controls.Add(this.userControlQueryCF21);
            this.xtraTabPageKind.Name = "xtraTabPageKind";
            this.xtraTabPageKind.PageVisible = false;
            this.xtraTabPageKind.Size = new System.Drawing.Size(266, 532);
            this.xtraTabPageKind.Text = "类型";
            // 
            // userControlQueryXB21
            // 
            this.userControlQueryXB21.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.userControlQueryXB21.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.userControlQueryXB21.Appearance.Options.UseBackColor = true;
            this.userControlQueryXB21.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControlQueryXB21.Location = new System.Drawing.Point(0, 0);
            this.userControlQueryXB21.Name = "userControlQueryXB21";
            this.userControlQueryXB21.Padding = new System.Windows.Forms.Padding(4, 0, 4, 4);
            this.userControlQueryXB21.Size = new System.Drawing.Size(266, 532);
            this.userControlQueryXB21.TabIndex = 1;
            // 
            // userControlQueryCF21
            // 
            this.userControlQueryCF21.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.userControlQueryCF21.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.userControlQueryCF21.Appearance.Options.UseBackColor = true;
            this.userControlQueryCF21.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControlQueryCF21.Location = new System.Drawing.Point(0, 0);
            this.userControlQueryCF21.Name = "userControlQueryCF21";
            this.userControlQueryCF21.Padding = new System.Windows.Forms.Padding(6, 0, 6, 6);
            this.userControlQueryCF21.Size = new System.Drawing.Size(266, 532);
            this.userControlQueryCF21.TabIndex = 0;
            // 
            // userControlQueryZL1
            // 
            this.userControlQueryZL1.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.userControlQueryZL1.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.userControlQueryZL1.Appearance.Options.UseBackColor = true;
            this.userControlQueryZL1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControlQueryZL1.Location = new System.Drawing.Point(6, 1);
            this.userControlQueryZL1.Name = "userControlQueryZL1";
            this.userControlQueryZL1.Size = new System.Drawing.Size(233, 529);
            this.userControlQueryZL1.TabIndex = 2;
            // 
            // ribbonPageDataManager
            // 
            this.ribbonPageDataManager.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup2,
            this.ribbonPageGroupIO,
            this.ribbonPageGroupDataUpdata,
            this.ribbonPageGroupBack});
            this.ribbonPageDataManager.Name = "ribbonPageDataManager";
            this.ribbonPageDataManager.Text = "数据维护";
            this.ribbonPageDataManager.Visible = false;
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.AllowTextClipping = false;
            this.ribbonPageGroup2.ItemLinks.Add(this.barButtonItem3);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.Text = "参数设置";
            // 
            // barButtonItem3
            // 
            this.barButtonItem3.Caption = "连接参数";
            this.barButtonItem3.Description = "设置数据库连接参数";
            this.barButtonItem3.Id = 161;
            this.barButtonItem3.LargeImageIndex = 71;
            this.barButtonItem3.Name = "barButtonItem3";
            // 
            // ribbonPageGroupIO
            // 
            this.ribbonPageGroupIO.ItemLinks.Add(this.barButtonItemDataImput);
            this.ribbonPageGroupIO.ItemLinks.Add(this.barButtonItemDataOutput);
            this.ribbonPageGroupIO.Name = "ribbonPageGroupIO";
            this.ribbonPageGroupIO.Text = "导入导出";
            // 
            // barButtonItemDataImput
            // 
            this.barButtonItemDataImput.Caption = "数据导入";
            this.barButtonItemDataImput.Id = 159;
            this.barButtonItemDataImput.LargeImageIndex = 359;
            this.barButtonItemDataImput.Name = "barButtonItemDataImput";
            // 
            // barButtonItemDataOutput
            // 
            this.barButtonItemDataOutput.Caption = "数据导出";
            this.barButtonItemDataOutput.Id = 160;
            this.barButtonItemDataOutput.LargeImageIndex = 356;
            this.barButtonItemDataOutput.Name = "barButtonItemDataOutput";
            // 
            // ribbonPageGroupDataUpdata
            // 
            this.ribbonPageGroupDataUpdata.Name = "ribbonPageGroupDataUpdata";
            this.ribbonPageGroupDataUpdata.Text = "数据更新";
            this.ribbonPageGroupDataUpdata.Visible = false;
            // 
            // ribbonPageGroupBack
            // 
            this.ribbonPageGroupBack.ItemLinks.Add(this.barButtonItemBackup);
            this.ribbonPageGroupBack.ItemLinks.Add(this.barButtonItemRestore);
            this.ribbonPageGroupBack.ItemLinks.Add(this.barButtonItemBackup2, true);
            this.ribbonPageGroupBack.ItemLinks.Add(this.barButtonItemRestore2);
            this.ribbonPageGroupBack.Name = "ribbonPageGroupBack";
            this.ribbonPageGroupBack.Text = "备份恢复";
            // 
            // barButtonItemBackup
            // 
            this.barButtonItemBackup.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            this.barButtonItemBackup.Caption = "自动备份";
            this.barButtonItemBackup.Description = "自动备份编辑数据";
            this.barButtonItemBackup.Id = 162;
            this.barButtonItemBackup.LargeImageIndex = 420;
            this.barButtonItemBackup.Name = "barButtonItemBackup";
            // 
            // barButtonItemRestore
            // 
            this.barButtonItemRestore.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            this.barButtonItemRestore.Caption = "自动恢复";
            this.barButtonItemRestore.Id = 163;
            this.barButtonItemRestore.LargeImageIndex = 419;
            this.barButtonItemRestore.Name = "barButtonItemRestore";
            // 
            // barButtonItemBackup2
            // 
            this.barButtonItemBackup2.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            this.barButtonItemBackup2.Caption = "指定备份";
            this.barButtonItemBackup2.Id = 164;
            this.barButtonItemBackup2.LargeImageIndex = 429;
            this.barButtonItemBackup2.Name = "barButtonItemBackup2";
            // 
            // barButtonItemRestore2
            // 
            this.barButtonItemRestore2.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            this.barButtonItemRestore2.Caption = "指定恢复";
            this.barButtonItemRestore2.Id = 165;
            this.barButtonItemRestore2.LargeImageIndex = 426;
            this.barButtonItemRestore2.Name = "barButtonItemRestore2";
            // 
            // ribbonPageGroupMapView5
            // 
            this.ribbonPageGroupMapView5.ItemLinks.Add(this.barButtonItemFullMap);
            this.ribbonPageGroupMapView5.ItemLinks.Add(this.barButtonItemPan);
            this.ribbonPageGroupMapView5.ItemLinks.Add(this.barButtonItemZoomIn);
            this.ribbonPageGroupMapView5.ItemLinks.Add(this.barButtonItemZoomOut);
            this.ribbonPageGroupMapView5.ItemLinks.Add(this.barButtonItemRefresh);
            this.ribbonPageGroupMapView5.ItemLinks.Add(this.barButtonItemBack);
            this.ribbonPageGroupMapView5.ItemLinks.Add(this.barButtonItemForward);
            this.ribbonPageGroupMapView5.ItemLinks.Add(this.barButtonItemIdentify);
            this.ribbonPageGroupMapView5.ItemLinks.Add(this.barButtonItemTOC);
            this.ribbonPageGroupMapView5.Name = "ribbonPageGroupMapView5";
            this.ribbonPageGroupMapView5.Text = "地图浏览";
            this.ribbonPageGroupMapView5.Visible = false;
            // 
            // ribbonPageSystemManager
            // 
            this.ribbonPageSystemManager.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroupManageUser,
            this.ribbonPageGroupLogs,
            this.ribbonPageGroupDBManage,
            this.ribbonPageGroupSet,
            this.ribbonPageGroupManageDesign,
            this.ribbonPageGroupMapView5});
            this.ribbonPageSystemManager.Name = "ribbonPageSystemManager";
            this.ribbonPageSystemManager.Text = "系统管理";
            // 
            // ribbonPageGroupManageUser
            // 
            this.ribbonPageGroupManageUser.AllowMinimize = false;
            this.ribbonPageGroupManageUser.ItemLinks.Add(this.barButtonItemUserList);
            this.ribbonPageGroupManageUser.ItemLinks.Add(this.barButtonItemUserAdd);
            this.ribbonPageGroupManageUser.ItemLinks.Add(this.barButtonItemUserEdit);
            this.ribbonPageGroupManageUser.ItemLinks.Add(this.barButtonItemUserDelete);
            this.ribbonPageGroupManageUser.ItemLinks.Add(this.barButtonItemUserKey);
            this.ribbonPageGroupManageUser.Name = "ribbonPageGroupManageUser";
            this.ribbonPageGroupManageUser.Text = " 用户管理 ";
            this.ribbonPageGroupManageUser.Visible = false;
            // 
            // barButtonItemUserList
            // 
            this.barButtonItemUserList.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            this.barButtonItemUserList.Caption = "用户列表";
            this.barButtonItemUserList.Id = 167;
            this.barButtonItemUserList.LargeImageIndex = 416;
            this.barButtonItemUserList.Name = "barButtonItemUserList";
            this.barButtonItemUserList.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.barButtonItemUserList.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // barButtonItemUserAdd
            // 
            this.barButtonItemUserAdd.Caption = "增加用户";
            this.barButtonItemUserAdd.Id = 168;
            this.barButtonItemUserAdd.LargeImageIndex = 413;
            this.barButtonItemUserAdd.Name = "barButtonItemUserAdd";
            this.barButtonItemUserAdd.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // barButtonItemUserEdit
            // 
            this.barButtonItemUserEdit.Caption = "修改用户";
            this.barButtonItemUserEdit.Id = 169;
            this.barButtonItemUserEdit.LargeImageIndex = 411;
            this.barButtonItemUserEdit.Name = "barButtonItemUserEdit";
            // 
            // barButtonItemUserDelete
            // 
            this.barButtonItemUserDelete.Caption = "删除用户";
            this.barButtonItemUserDelete.Id = 170;
            this.barButtonItemUserDelete.LargeImageIndex = 412;
            this.barButtonItemUserDelete.Name = "barButtonItemUserDelete";
            this.barButtonItemUserDelete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // barButtonItemUserKey
            // 
            this.barButtonItemUserKey.Caption = "修改密码";
            this.barButtonItemUserKey.Id = 171;
            this.barButtonItemUserKey.LargeImageIndex = 414;
            this.barButtonItemUserKey.Name = "barButtonItemUserKey";
            this.barButtonItemUserKey.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // ribbonPageGroupLogs
            // 
            this.ribbonPageGroupLogs.AllowMinimize = false;
            this.ribbonPageGroupLogs.ItemLinks.Add(this.barButtonItemLogs);
            this.ribbonPageGroupLogs.ItemLinks.Add(this.barButtonItemLogDelete);
            this.ribbonPageGroupLogs.ItemLinks.Add(this.barButtonItemLogClear);
            this.ribbonPageGroupLogs.Name = "ribbonPageGroupLogs";
            this.ribbonPageGroupLogs.Text = "日志管理";
            // 
            // barButtonItemLogs
            // 
            this.barButtonItemLogs.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            this.barButtonItemLogs.Caption = "日志列表";
            this.barButtonItemLogs.Id = 172;
            this.barButtonItemLogs.LargeImageIndex = 404;
            this.barButtonItemLogs.Name = "barButtonItemLogs";
            this.barButtonItemLogs.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // barButtonItemLogDelete
            // 
            this.barButtonItemLogDelete.Caption = "删除日志";
            this.barButtonItemLogDelete.Id = 173;
            this.barButtonItemLogDelete.LargeImageIndex = 408;
            this.barButtonItemLogDelete.Name = "barButtonItemLogDelete";
            this.barButtonItemLogDelete.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.barButtonItemLogDelete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // barButtonItemLogClear
            // 
            this.barButtonItemLogClear.Caption = "清空日志";
            this.barButtonItemLogClear.Id = 174;
            this.barButtonItemLogClear.LargeImageIndex = 406;
            this.barButtonItemLogClear.Name = "barButtonItemLogClear";
            // 
            // ribbonPageGroupDBManage
            // 
            this.ribbonPageGroupDBManage.AllowMinimize = false;
            this.ribbonPageGroupDBManage.ItemLinks.Add(this.barButtonItemDBConnect);
            this.ribbonPageGroupDBManage.ItemLinks.Add(this.barButtonItemDBUpdata, true);
            this.ribbonPageGroupDBManage.ItemLinks.Add(this.barButtonItemDBNew, true);
            this.ribbonPageGroupDBManage.ItemLinks.Add(this.barButtonItemDBLoadData);
            this.ribbonPageGroupDBManage.ItemLinks.Add(this.barButtonItemDBDelete);
            this.ribbonPageGroupDBManage.Name = "ribbonPageGroupDBManage";
            this.ribbonPageGroupDBManage.Text = "数据库管理";
            // 
            // barButtonItemDBConnect
            // 
            this.barButtonItemDBConnect.Caption = "参数设置";
            this.barButtonItemDBConnect.Description = "数据库连接参数设置";
            this.barButtonItemDBConnect.Id = 178;
            this.barButtonItemDBConnect.LargeImageIndex = 417;
            this.barButtonItemDBConnect.Name = "barButtonItemDBConnect";
            this.barButtonItemDBConnect.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barButtonItemDBConnect.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // barButtonItemDBUpdata
            // 
            this.barButtonItemDBUpdata.Caption = "数据库升级";
            this.barButtonItemDBUpdata.Id = 179;
            this.barButtonItemDBUpdata.LargeImageIndex = 71;
            this.barButtonItemDBUpdata.Name = "barButtonItemDBUpdata";
            this.barButtonItemDBUpdata.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barButtonItemDBUpdata.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.barButtonItemDBUpdata.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // barButtonItemDBNew
            // 
            this.barButtonItemDBNew.Caption = "新建数据库";
            this.barButtonItemDBNew.Description = "创建新一年度数据库";
            this.barButtonItemDBNew.Id = 180;
            this.barButtonItemDBNew.LargeImageIndex = 422;
            this.barButtonItemDBNew.Name = "barButtonItemDBNew";
            this.barButtonItemDBNew.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barButtonItemDBNew.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.barButtonItemDBNew.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // barButtonItemDBLoadData
            // 
            this.barButtonItemDBLoadData.Caption = "加载数据";
            this.barButtonItemDBLoadData.Description = "从指定数据库加载数据到新一年度数据库";
            this.barButtonItemDBLoadData.Id = 181;
            this.barButtonItemDBLoadData.LargeImageIndex = 420;
            this.barButtonItemDBLoadData.Name = "barButtonItemDBLoadData";
            this.barButtonItemDBLoadData.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barButtonItemDBLoadData.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.barButtonItemDBLoadData.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // barButtonItemDBDelete
            // 
            this.barButtonItemDBDelete.Caption = "删除数据库";
            this.barButtonItemDBDelete.Description = "删除指定数据库";
            this.barButtonItemDBDelete.Id = 182;
            this.barButtonItemDBDelete.LargeImageIndex = 429;
            this.barButtonItemDBDelete.Name = "barButtonItemDBDelete";
            this.barButtonItemDBDelete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // ribbonPageGroupSet
            // 
            this.ribbonPageGroupSet.ItemLinks.Add(this.barButtonItemSetDRG);
            this.ribbonPageGroupSet.Name = "ribbonPageGroupSet";
            this.ribbonPageGroupSet.Text = "系统参数设置";
            this.ribbonPageGroupSet.Visible = false;
            // 
            // barButtonItemSetDRG
            // 
            this.barButtonItemSetDRG.Caption = "底图设置";
            this.barButtonItemSetDRG.Description = "工作底图路径参数设置";
            this.barButtonItemSetDRG.Id = 183;
            this.barButtonItemSetDRG.LargeImageIndex = 128;
            this.barButtonItemSetDRG.Name = "barButtonItemSetDRG";
            // 
            // ribbonPageGroupManageDesign
            // 
            this.ribbonPageGroupManageDesign.ItemLinks.Add(this.barButtonItemManageDesignQuery);
            this.ribbonPageGroupManageDesign.ItemLinks.Add(this.barButtonItemManageDesignEdit);
            this.ribbonPageGroupManageDesign.ItemLinks.Add(this.barButtonItemManageDesignYear);
            this.ribbonPageGroupManageDesign.Name = "ribbonPageGroupManageDesign";
            this.ribbonPageGroupManageDesign.Text = "作业设计管理";
            this.ribbonPageGroupManageDesign.Visible = false;
            // 
            // barButtonItemManageDesignQuery
            // 
            this.barButtonItemManageDesignQuery.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            this.barButtonItemManageDesignQuery.Caption = "设计查询";
            this.barButtonItemManageDesignQuery.Id = 175;
            this.barButtonItemManageDesignQuery.LargeImageIndex = 84;
            this.barButtonItemManageDesignQuery.Name = "barButtonItemManageDesignQuery";
            // 
            // barButtonItemManageDesignEdit
            // 
            this.barButtonItemManageDesignEdit.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            this.barButtonItemManageDesignEdit.Caption = "设计修改";
            this.barButtonItemManageDesignEdit.Id = 176;
            this.barButtonItemManageDesignEdit.LargeImageIndex = 128;
            this.barButtonItemManageDesignEdit.Name = "barButtonItemManageDesignEdit";
            // 
            // barButtonItemManageDesignYear
            // 
            this.barButtonItemManageDesignYear.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            this.barButtonItemManageDesignYear.Caption = "年度划转";
            this.barButtonItemManageDesignYear.Id = 177;
            this.barButtonItemManageDesignYear.LargeImageIndex = 155;
            this.barButtonItemManageDesignYear.Name = "barButtonItemManageDesignYear";
            // 
            // barButtonItem4
            // 
            this.barButtonItem4.Caption = "barButtonItem4";
            this.barButtonItem4.Id = 166;
            this.barButtonItem4.Name = "barButtonItem4";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(0, 149);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1124, 588);
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            // 
            // xtraTabPageLog
            // 
            this.xtraTabPageLog.Controls.Add(this.userControlLog1);
            this.xtraTabPageLog.ImageIndex = 202;
            this.xtraTabPageLog.Name = "xtraTabPageLog";
            this.xtraTabPageLog.Size = new System.Drawing.Size(838, 557);
            this.xtraTabPageLog.Text = "日志";
            // 
            // userControlLog1
            // 
            this.userControlLog1.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.userControlLog1.Appearance.BackColor2 = System.Drawing.Color.Transparent;
            this.userControlLog1.Appearance.Options.UseBackColor = true;
            this.userControlLog1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControlLog1.Location = new System.Drawing.Point(0, 0);
            this.userControlLog1.Name = "userControlLog1";
            this.userControlLog1.Padding = new System.Windows.Forms.Padding(7);
            this.userControlLog1.Size = new System.Drawing.Size(838, 557);
            this.userControlLog1.TabIndex = 0;
            // 
            // userControlQueryDesign
            // 
            this.userControlQueryDesign.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.userControlQueryDesign.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.userControlQueryDesign.Appearance.Options.UseBackColor = true;
            this.userControlQueryDesign.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControlQueryDesign.Location = new System.Drawing.Point(0, 0);
            this.userControlQueryDesign.Name = "userControlQueryDesign";
            this.userControlQueryDesign.Padding = new System.Windows.Forms.Padding(5);
            this.userControlQueryDesign.Size = new System.Drawing.Size(266, 532);
            this.userControlQueryDesign.TabIndex = 2;
            // 
            // xtraTabPageDesign
            // 
            this.xtraTabPageDesign.Controls.Add(this.userControlQueryDesign);
            this.xtraTabPageDesign.Name = "xtraTabPageDesign";
            this.xtraTabPageDesign.Size = new System.Drawing.Size(266, 532);
            this.xtraTabPageDesign.Text = "设计";
            // 
            // MainFrameSystem
            // 
            this.ClientSize = new System.Drawing.Size(1124, 768);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.dockPanelBottom);
            this.MinimumSize = new System.Drawing.Size(1002, 723);
            this.Name = "MainFrameSystem";
            this.Text = "系统管理";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Activated += new System.EventHandler(this.FormMainFrame_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainFrameEdit_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormMainFrame_FormClosed);
            this.Load += new System.EventHandler(this.FormMainFrame_Load);
            this.Resize += new System.EventHandler(this.MainFrameEdit_Resize);
            this.Controls.SetChildIndex(this.ribbon, 0);
            this.Controls.SetChildIndex(this.ribbonStatusBar, 0);
            this.Controls.SetChildIndex(this.dockPanelBottom, 0);
            this.Controls.SetChildIndex(this.pictureBox1, 0);
            this.Controls.SetChildIndex(this.textBox1, 0);
            this.Controls.SetChildIndex(this.xtraTabMain, 0);
            ((System.ComponentModel.ISupportInitialize)(this.applicationMenu1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axTOCControl)).EndInit();
            this.dockPanelBottom.ResumeLayout(false);
            this.dockPanelBottom_Container.ResumeLayout(false);
            this.dockPanelEdit.ResumeLayout(false);
            this.dockPanelEdit_Container.ResumeLayout(false);
            this.dockPanelToolbox.ResumeLayout(false);
            this.dockPanelToolbox_Container.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MapControlEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PageLayoutControlEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            this.tabPageMapContol.ResumeLayout(false);
            this.tabPagePagelayoutContol.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabMain)).EndInit();
            this.xtraTabMain.ResumeLayout(false);
            this.xtraTabPageIdentify.ResumeLayout(false);
            this.xtraTabPageQuery.ResumeLayout(false);
            this.xtraTabPageTOC.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabToolbox)).EndInit();
            this.xtraTabToolbox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.popupMenuVertex)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenuLinkage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenuMapView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenuEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControlEdit)).EndInit();
            this.xtraTabControlEdit.ResumeLayout(false);
            this.xtraTabPageAttribute.ResumeLayout(false);
            this.xtraTabPageLogicCheck.ResumeLayout(false);
            this.xtraTabPageInputData.ResumeLayout(false);
            this.xtraTabPageUpdate.ResumeLayout(false);
            this.xtraTabPageSelect.ResumeLayout(false);
            this.xtraTabPageMapFind.ResumeLayout(false);
            this.xtraTabPageLocation.ResumeLayout(false);
            this.xtraTabPageXBchange.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabQuery)).EndInit();
            this.xtraTabQuery.ResumeLayout(false);
            this.xtraTabPage1.ResumeLayout(false);
            this.xtraTabPage2.ResumeLayout(false);
            this.xtraTabPage3.ResumeLayout(false);
            this.xtraTabPageAddRasterlayer.ResumeLayout(false);
            this.xtraTabPagePlace.ResumeLayout(false);
            this.xtraTabPageTFH.ResumeLayout(false);
            this.xtraTabPageKind.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.xtraTabPageLog.ResumeLayout(false);
            this.xtraTabPageDesign.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private bool InitializeEditValue(bool flag)
        {
            try
            {
                TaskManageClass.InitialEditValues("系统管理", "2013", base.MapControlEdit.Map);
                TaskManageClass.TaskState = TaskState.Open;
                TaskManageClass.LogicCheckState = LogicCheckState.Failure;
                TaskManageClass.ToplogicCheckState = ToplogicCheckState.Failure;
                this.mFeatureWorkspace = EditTask.EditWorkspace;
                if (this.mFeatureWorkspace == null)
                {
                    return false;
                }
                return true;
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "GXFormMainFrame.FormMainEdit", "InitializeEditValue", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                return false;
            }
        }

        public bool InitializeForm()
        {
            try
            {
               
                if (this.FormSplash != null)
                {
                    this.FormSplash.SetLoadInfo("正在初始化工具按钮...", 0x19);
                }
                if (this.FormSplash6 != null)
                {
                    this.FormSplash6.SetLoadInfo("正在初始化工具按钮...", 0x19);
                }
                base.MapControlEdit.BringToFront();
                base.MapControlEdit.Dock = DockStyle.Fill;
                this.InitSynchronizer();
                if (!this.InitializeGISControls())
                {
                    return false;
                }
                if (this.FormSplash != null)
                {
                    this.FormSplash.SetLoadInfo("正在初始化工具按钮...", 30);
                }
                if (this.FormSplash6 != null)
                {
                    this.FormSplash6.SetLoadInfo("正在初始化工具按钮...", 30);
                }
               
                this.InitializeBaseButtonComm();
                if (this.FormSplash != null)
                {
                    this.FormSplash.SetLoadInfo("正在初始化工具按钮...", 40);
                }
                if (this.FormSplash6 != null)
                {
                    this.FormSplash6.SetLoadInfo("正在初始化工具按钮...", 40);
                }
                if (this.FormSplash != null)
                {
                    this.FormSplash.SetLoadInfo("正在初始化工具按钮...", 50);
                }
                if (this.FormSplash6 != null)
                {
                    this.FormSplash6.SetLoadInfo("正在初始化工具按钮...", 50);
                }
                this.InitializeBaseButtonPage();
                if (this.FormSplash != null)
                {
                    this.FormSplash.SetLoadInfo("正在初始化功能模块...", 60);
                }
                if (this.FormSplash6 != null)
                {
                    this.FormSplash6.SetLoadInfo("正在初始化功能模块...", 60);
                }
                this.SetFormText();
                base.ribbon.SelectedPage = this.ribbonPageSystemManager;
                base.tabPageMapContol.PageVisible = true;
                if (this.FormSplash != null)
                {
                    this.FormSplash.SetLoadInfo("正在初始化功能模块...", 70);
                }
                if (this.FormSplash6 != null)
                {
                    this.FormSplash6.SetLoadInfo("正在初始化功能模块...", 70);
                }
                if (this.FormSplash != null)
                {
                    this.FormSplash.SetLoadInfo("正在初始化功能模块...", 80);
                }
                if (this.FormSplash6 != null)
                {
                    this.FormSplash6.SetLoadInfo("正在初始化功能模块...", 80);
                }
                this.SetButtonVisible();
                this.SetButtonEnabled();
                this.SetButtonTooltip();
                base.WindowState = FormWindowState.Maximized;
                base.Show();
                base.barStaticItemLocation1.Visibility = BarItemVisibility.Never;
                base.barStaticItemLocation2.Visibility = BarItemVisibility.Never;
                base.barStaticItemLocation3.Visibility = BarItemVisibility.Never;
                base.barStaticItemScale.Visibility = BarItemVisibility.Never;
                base.barEditItemScale.Visibility = BarItemVisibility.Never;
                base.textBox1.Left = (((base.barStaticItemInfo.Width + base.barStaticItemLocation1.Width) + base.barStaticItemLocation2.Width) + base.barStaticItemScale.Width) + 10;
                base.textBox1.Top = base.Height - 0x1c;
                base.textBox1.Width = 0x54;
                base.textBox1.Visible = false;
                if (this.FormSplash != null)
                {
                    this.FormSplash.SetLoadInfo("正在初始化功能模块...", 90);
                }
                if (this.FormSplash6 != null)
                {
                    this.FormSplash6.SetLoadInfo("正在初始化功能模块...", 90);
                }
                this.m_Timer = new Timer();
                this.m_Timer.Tick += new EventHandler(this.m_Timer_Tick);
                this.m_Timer.Interval = 600;
                this.m_Timer.Start();
                if (this.FormSplash != null)
                {
                    this.FormSplash.SetLoadInfo("系统初始化完毕...", 100);
                }
                if (this.FormSplash6 != null)
                {
                    this.FormSplash6.SetLoadInfo("系统初始化完毕...", 100);
                }
                return true;
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "GXFormMainFrame.FormMainEdit", "InitializeForm", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                return false;
            }
        }

        public bool InitializeForm5()
        {
            try
            {
                this.FormSplash5.SetLoadInfo("正在加载地图数据...", 0x19);
                base.MapControlEdit.BringToFront();
                base.MapControlEdit.Dock = DockStyle.Fill;
                this.InitSynchronizer();
                this.InitializeGISControls();
                this.FormSplash5.SetLoadInfo("正在初始化工具按钮...", 30);
                this.InitializeBaseButtonComm();
                this.FormSplash5.SetLoadInfo("正在初始化工具按钮...", 40);
                this.FormSplash5.SetLoadInfo("正在初始化工具按钮...", 50);
                this.InitializeBaseButtonPage();
                this.FormSplash5.SetLoadInfo("正在初始化功能模块...", 60);
                this.SetFormText();
                base.ribbon.SelectedPage = this.ribbonPageSystemManager;
                this.FormSplash5.SetLoadInfo("正在初始化功能模块...", 70);
                this.FormSplash5.SetLoadInfo("正在初始化功能模块...", 80);
                this.SetButtonVisible();
                this.SetButtonEnabled();
                this.SetButtonTooltip();
                base.WindowState = FormWindowState.Maximized;
                base.Show();
                base.barStaticItemLocation1.Visibility = BarItemVisibility.Never;
                base.barStaticItemLocation2.Visibility = BarItemVisibility.Never;
                base.barStaticItemLocation3.Visibility = BarItemVisibility.Never;
                base.barStaticItemScale.Visibility = BarItemVisibility.Never;
                base.barEditItemScale.Visibility = BarItemVisibility.Never;
                base.textBox1.Left = (((base.barStaticItemInfo.Width + base.barStaticItemLocation1.Width) + base.barStaticItemLocation2.Width) + base.barStaticItemScale.Width) + 10;
                base.textBox1.Top = base.Height - 28;
                base.textBox1.Width = 0x54;
                base.textBox1.Visible = false;
                this.FormSplash5.SetLoadInfo("正在初始化功能模块...", 90);
                LogType.SystemType = this.mEditKind;
                UserManager.Single.Log("登陆系统", this.mEditKind + "编辑", LogType.SystemType);
                this.m_Timer = new Timer();
                this.m_Timer.Tick += new EventHandler(this.m_Timer_Tick);
                this.m_Timer.Interval = 600;
                this.m_Timer.Start();
                this.FormSplash5.SetLoadInfo("系统初始化完毕...", 100);
                return true;
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "GXFormMainFrame.FormMainEdit", "InitializeForm", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                return false;
            }
        }

        private bool InitializeGISControls()
        {
            try
            {
                this.mSelection = true;
                this.mActiveViewEvents = base.MapControlEdit.Map as IActiveViewEvents_Event;
                this.mActiveViewEvents.ItemAdded+=(new IActiveViewEvents_ItemAddedEventHandler(this.ActiveViewEvents_ItemAdded));
                this.mActiveViewEvents.ItemDeleted+=(new IActiveViewEvents_ItemDeletedEventHandler(this.ActiveViewEvents_ItemDeleted));
                this.m_ActiveViewEventsAfterDraw = new IActiveViewEvents_AfterDrawEventHandler(this.OnActiveViewEventsAfterDraw);
                ((IActiveViewEvents_Event) base.MapControlEdit.Map).AfterDraw+=(this.m_ActiveViewEventsAfterDraw);
                this.m_ActiveViewEventsAfterItemDraw = new IActiveViewEvents_AfterItemDrawEventHandler(this.OnActiveViewEventsItemDraw);
                ((IActiveViewEvents_Event) base.MapControlEdit.Map).AfterItemDraw+=(this.m_ActiveViewEventsAfterItemDraw);
                this.m_ActiveViewEventsItemAdded = new IActiveViewEvents_ItemAddedEventHandler(this.OnActiveViewEventsItemAdded);
                ((IActiveViewEvents_Event) base.MapControlEdit.Map).ItemAdded+=(this.m_ActiveViewEventsItemAdded);
                base.MapControlEdit.OnMouseMove += new IMapControlEvents2_Ax_OnMouseMoveEventHandler(this.MapControlEdit_OnMouseMove);
                base.MapControlEdit.OnMouseUp += new IMapControlEvents2_Ax_OnMouseUpEventHandler(this.MapControlEdit_OnMouseUp);
                base.MapControlEdit.OnAfterDraw += new IMapControlEvents2_Ax_OnAfterDrawEventHandler(this.MapControlEdit_OnAfterDraw);
                base.PageLayoutControlEdit.OnDoubleClick += new IPageLayoutControlEvents_Ax_OnDoubleClickEventHandler(this.PgaeLayoutControl_DbClick);
                base.axTOCControl.OnMouseDown += new ITOCControlEvents_Ax_OnMouseDownEventHandler(this.axTOCControl_OnMouseDown);
                base.barEditItemScale.ShowingEditor += new ItemCancelEventHandler(this.barEditItemScale_ShowingEditor);
                base.barEditItemScale.ItemClick += new ItemClickEventHandler(this.barEditItemScale_ItemClick);
                base.barEditItemScale.ItemPress += new ItemClickEventHandler(this.barEditItemScale_ItemPress);
                base.barEditItemScale.EditValueChanged += new EventHandler(this.barEditItemScale_EditValueChanged);
                base.barEditItemScale.ShownEditor += new ItemClickEventHandler(this.barEditItemScale_ShownEditor);
                base.textBox1.KeyPress += new KeyPressEventHandler(this.textBox1_KeyPress);
                base.barButtonItemToolbox.ItemClick += new ItemClickEventHandler(this.barButtonItemToolbox_ItemClick);
                base.barButtonItemToolbox.Down = true;
                base.barButtonItemToolView.ItemClick += new ItemClickEventHandler(this.barButtonItemToolView_ItemClick);
                this.barButtonItemMapFrame.ItemClick += new ItemClickEventHandler(this.barButtonItemMapFrame_ItemClick);
                this.barButtonItemMapLegend.ItemClick += new ItemClickEventHandler(this.barButtonItemMapLegend_ItemClick);
                this.barButtonItemMapScaleBar.ItemClick += new ItemClickEventHandler(this.barButtonItemMapScaleBar_ItemClick);
                this.barButtonItemMapNorthArrow.ItemClick += new ItemClickEventHandler(this.barButtonItemMapNorthArrow_ItemClick);
                this.barButtonItemMapText.ItemClick += new ItemClickEventHandler(this.barButtonItemMapText_ItemClick);
                this.barButtonItemMapGrid.ItemClick += new ItemClickEventHandler(this.barButtonItemMapGrid_ItemClick);
                this.barButtonItemMapTable.ItemClick += new ItemClickEventHandler(this.barButtonItemMapTable_ItemClick);
                this.barButtonItemPrintSet.ItemClick += new ItemClickEventHandler(this.barButtonItemPrintSet_ItemClick);
                this.barButtonItemPrint.ItemClick += new ItemClickEventHandler(this.barButtonItemPrint_ItemClick);
                this.barButtonItemPrintPreview.ItemClick += new ItemClickEventHandler(this.barButtonItemPreview_ItemClick);
                this.barButtonItemExportImage.ItemClick += new ItemClickEventHandler(this.barButtonItemExportImage_ItemClick);
                this.barButtonItemAddLayer.ItemClick += new ItemClickEventHandler(this.barButtonItemAddLayer_ItemClick);
                this.barButtonItemVertexList.ItemClick += new ItemClickEventHandler(this.barButtonItemVertexList_ItemClick);
                this.barButtonItemLogicCheck.ItemClick += new ItemClickEventHandler(this.barButtonItemLogicCheck_ItemClick);
                this.barButtonItemUserList.ItemClick += new ItemClickEventHandler(this.barButtonItemUserList_ItemClick);
                this.barButtonItemDBConnect.ItemClick += new ItemClickEventHandler(this.barButtonItemDBConnect_ItemClick);
                this.barButtonItemDBUpdata.ItemClick += new ItemClickEventHandler(this.barButtonItemDBUpdata_ItemClick);
                this.barButtonItemDBNew.ItemClick += new ItemClickEventHandler(this.barButtonItemDBNew_ItemClick);
                this.barButtonItemDBLoadData.ItemClick += new ItemClickEventHandler(this.barButtonItemDBLoad_ItemClick);
                this.barButtonItemDBDelete.ItemClick += new ItemClickEventHandler(this.barButtonItemDBDelete_ItemClick);
                this.barButtonItemManageDesignQuery.ItemClick += new ItemClickEventHandler(this.barButtonItemManageDesignQuery_ItemClick);
                this.barButtonItemManageDesignEdit.ItemClick += new ItemClickEventHandler(this.barButtonItemManageDesignEdit_ItemClick);
                this.barButtonItemManageDesignYear.ItemClick += new ItemClickEventHandler(this.barButtonItemManageDesignYear_ItemClick);
                this.barButtonItemLogs.ItemClick += new ItemClickEventHandler(this.barButtonItemLogs_ItemClick);
                this.barButtonItemLogClear.ItemClick += new ItemClickEventHandler(this.barButtonItemLogClear_ItemClick);
                this.barButtonItemUserEdit.ItemClick += new ItemClickEventHandler(this.barButtonItemUserEdit_ItemClick);
                this.barButtonItemSetDRG.ItemClick += new ItemClickEventHandler(this.barButtonItemSetDRG_ItemClick);
                base.xtraTabMain.SelectedPageChanged += new TabPageChangedEventHandler(this.xtraTabMain_SelectedPageChanged);
                base.xtraTabMain.Resize += new EventHandler(this.xtraTabMain_Resize);
                this.userControlLayerControl.treeList1.MouseMove += new MouseEventHandler(this.userControlLayerControltreeList1_MouseMove);
                this.userControlLayerControl.treeList1.MouseDown += new MouseEventHandler(this.userControlLayerControltreeList1_MouseDown);
                string mxPath = UtilFactory.GetConfigOpt().RootPath + PathManager.FindValue("OverviewPath");
                this.userControlOverView.MapControlOverView.ShowScrollbars = false;
                this.MapControlEdit.LoadMxFile(mxPath);
                //this.userControlOverView.MapControlOverView.LoadMxFile(mxPath);
                if (this.barButtonItemOverView.Enabled && this.barButtonItemOverView.Down)
                {
                    this.userControlOverView.Visible = true;
                    this.splitterControl1.Visible = true;
                }
                else
                {
                    this.userControlOverView.Visible = false;
                    this.splitterControl1.Visible = false;
                }
                if (!this.InitializeEditValue(false))
                {
                    return false;
                }
                base.barEditItemScale.EditValue = this.GetMapScale(base.MapControlEdit.Map);
                if (this.userControlInfo.hook == null)
                {
                    this.userControlInfo.hook = base.MapControlEdit.Object;
                }
                this.userControlInfo.EditLayer = this.mEditLayer;
                this.userControlInfo.InitialControls(this.mEditKind);
                this.SetPageLayoutValues();
                this.mSelection = false;
                return true;
            }
            catch (Exception exception)
            {
                this.mSelection = false;
                this.mErrOpt.ErrorOperate(this.mSubSysName, "GXFormMainFrame.FormMainEdit", "InitializeGISControls", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                return false;
            }
        }
        private static PathManager PathManager
        {
            get
            {
                return DBServiceFactory<PathManager>.Service;
            }
        }
        protected void InitSynchronizer()
        {
            try
            {
                IMapControl4 mapControl = base.MapControlEdit.Object as IMapControl4;
                base.PageLayoutControlEdit.Visible = true;
                IPageLayoutControl3 pageLayoutControl = base.PageLayoutControlEdit.Object as IPageLayoutControl3;
                this.m_controlsSynchronizer2 = new ControlsSynchronizer(mapControl, pageLayoutControl);
                this.m_controlsSynchronizer2.AddFrameworkControl(base.axTOCControl.Object);
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "GXFormMainFrame.FormMainEdit", "InitSynchronizer", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void m_Timer_Tick(object sender, EventArgs e)
        {
            this.RefreshToolBarButton(false);
        }

        private void MainFrameEdit_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.mFormVertexList != null)
            {
                this.mFormVertexList.Dispose();
                this.mFormVertexList = null;
            }
            if (mProcess != null)
            {
                Process[] processes = Process.GetProcesses();
                for (int i = 1; i <= (processes.Length - 1); i++)
                {
                    if (processes[i].ProcessName == mProcess.ProcessName)
                    {
                        processes[i].Kill();
                        break;
                    }
                }
            }
        }

        private void MainFrameEdit_Resize(object sender, EventArgs e)
        {
        }

        private void MapControlEdit_Leave(object sender, EventArgs e)
        {
            base.ribbon.SetPopupContextMenu(this, null);
        }

        private void MapControlEdit_OnAfterDraw(object sender, IMapControlEvents2_OnAfterDrawEvent e)
        {
            try
            {
                if (base.xtraTabMain.SelectedTabPageIndex == 0)
                {
                    this.mSelection = true;
                    base.barEditItemScale.EditValue = this.GetMapScale(base.MapControlEdit.Map);
                    base.textBox1.Text = base.barEditItemScale.EditValue.ToString();
                    IEnvelope extent = base.MapControlEdit.ActiveView.Extent;
                    this.userControlOverView.DrawEnvelope(extent, base.MapControlEdit.MapUnits);
                    this.mSelection = false;
                }
            }
            catch (Exception)
            {
                this.mSelection = false;
            }
        }

        private void MapControlEdit_OnMouseMove(object sender, IMapControlEvents2_OnMouseMoveEvent e)
        {
            try
            {
                if (base.xtraTabMain.SelectedTabPageIndex == 0)
                {
                    string outx = null;
                    string outy = null;
                    IActiveView activeView = base.MapControlEdit.ActiveView;
                    GISFunFactory.UnitFun.bj54tojingweiduAo(activeView, e.mapX, e.mapY, ref outx, ref outy);
                    string str3 = "经纬度： 经度=" + outx;
                    string str4 = " 纬度=" + outy;
                    string str5 = "大地坐标： X=" + Convert.ToInt32(e.mapX) + "米";
                    string str6 = " Y=" + Convert.ToInt32(e.mapY) + "米";
                    base.barStaticItemLocation1.Caption = string.Format("{0} {1}", str3, str4);
                    base.barStaticItemLocation2.Caption = string.Format("{0} {1}", str5, str6);
                    base.barStaticItemLocation1.Width = 300;
                    base.barStaticItemLocation2.Width = 250;
                    base.barStaticItemLocation3.Visibility = BarItemVisibility.Never;
                    if (base.MapControlEdit.CurrentTool is SnapEx)
                    {
                        base.ribbon.SetPopupContextMenu(this, null);
                    }
                    else
                    {
                        if (base.MapControlEdit.CurrentTool is Edit)
                        {
                            if (Editor.UniqueInstance.EditShape.IsEmpty)
                            {
                                base.ribbon.SetPopupContextMenu(this, this.popupMenuEdit);
                            }
                            else
                            {
                                base.ribbon.SetPopupContextMenu(this, this.popupMenuVertex);
                            }
                        }
                        else if (base.MapControlEdit.CurrentTool is ToolAttributesEdit)
                        {
                            base.ribbon.SetPopupContextMenu(this, this.popupMenuEdit);
                        }
                        else if ((base.MapControlEdit.CurrentTool is InsertVertex) || (base.MapControlEdit.CurrentTool is DeleteVertex))
                        {
                            base.ribbon.SetPopupContextMenu(this, this.popupMenuVertex);
                        }
                        else if (base.MapControlEdit.CurrentTool is LinkageEdit)
                        {
                            if (Editor.UniqueInstance.LinageShape.IsEmpty)
                            {
                                base.ribbon.SetPopupContextMenu(this, this.popupMenuEdit);
                            }
                            else
                            {
                                base.ribbon.SetPopupContextMenu(this, this.popupMenuLinkage);
                            }
                        }
                        else if ((base.MapControlEdit.CurrentTool is LinkageInsertVertex) || (base.MapControlEdit.CurrentTool is LinkageDeleteVertex))
                        {
                            base.ribbon.SetPopupContextMenu(this, this.popupMenuLinkage);
                        }
                        else if (Editor.UniqueInstance.EngineEditor.SelectionCount == 1)
                        {
                            IFeatureSelection targetLayer = Editor.UniqueInstance.TargetLayer as IFeatureSelection;
                            if (targetLayer.SelectionSet.Count == 1)
                            {
                                base.ribbon.SetPopupContextMenu(this, this.popupMenuEdit);
                            }
                            else
                            {
                                base.ribbon.SetPopupContextMenu(this, this.popupMenuMapView);
                            }
                        }
                        else
                        {
                            base.ribbon.SetPopupContextMenu(this, this.popupMenuMapView);
                        }
                        base.textBox1.Left = (((base.barStaticItemInfo.Width + base.barStaticItemLocation1.Width) + base.barStaticItemLocation2.Width) + base.barStaticItemScale.Width) + 10;
                        base.textBox1.Top = base.Height - 0x1c;
                        base.textBox1.Width = 0x54;
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        private void MapControlEdit_OnMouseUp(object sender, IMapControlEvents2_OnMouseUpEvent e)
        {
            if (base.xtraTabMain.SelectedTabPageIndex == 0)
            {
                this.RefreshToolBarButton(false);
                if (((base.MapControlEdit.CurrentTool.ToString() == "ESRI.ArcGIS.Controls.ControlsEditingEditToolClass") && (this.mFormVertexList != null)) && this.mFormVertexList.Visible)
                {
                    this.mFormVertexList.Init();
                }
            }
        }

        private void OnActiveViewEventsAfterDraw(IDisplay Display, esriViewDrawPhase phase)
        {
        }

        private void OnActiveViewEventsItemAdded(object Item)
        {
            base.axTOCControl.SetBuddyControl(base.MapControlEdit);
            base.axTOCControl.Update();
        }

        private void OnActiveViewEventsItemDraw(short Index, IDisplay Display, esriDrawPhase phase)
        {
        }

        private void PageLayoutControlEdit_OnAfterDraw(object sender, IPageLayoutControlEvents_OnAfterDrawEvent e)
        {
            base.barEditItemScale.EditValue = this.GetMapScale(base.PageLayoutControlEdit.ActiveView.FocusMap);
            base.textBox1.Text = base.barEditItemScale.EditValue.ToString();
        }

        private void PageLayoutControlEdit_OnMouseMove(object sender, IPageLayoutControlEvents_OnMouseMoveEvent e)
        {
            try
            {
                if (base.xtraTabMain.SelectedTabPageIndex == 1)
                {
                    string name = "";
                    if (this.mEditKind == "小班")
                    {
                        name = "二类资源地图";
                    }
                    else if (this.mEditKind == "林改")
                    {
                        name = "林改地图";
                    }
                    else if (this.mEditKind == "造林")
                    {
                        name = "造林地图";
                    }
                    else if (this.mEditKind == "采伐")
                    {
                        name = "采伐地图";
                    }
                    else if (this.mEditKind == "公益林")
                    {
                        name = "公益林地图";
                    }
                    else if (this.mEditKind == "通用")
                    {
                        name = "临沧市地图";
                    }
                    IMapFrame frame = (IMapFrame) base.PageLayoutControlEdit.FindElementByName(name);
                    if (frame != null)
                    {
                        IActiveView map = (IActiveView) frame.Map;
                        IPoint point = map.ScreenDisplay.DisplayTransformation.ToMapPoint(e.x, e.y);
                        string outx = null;
                        string outy = null;
                        GISFunFactory.UnitFun.bj54tojingweiduAo(map, point.X, point.Y, ref outx, ref outy);
                        string str4 = "经纬度： 经度=" + outx;
                        string str5 = " 纬度=" + outy;
                        string str6 = "大地坐标： X=" + Convert.ToInt32(point.X) + "米";
                        string str7 = " Y=" + Convert.ToInt32(point.Y) + "米";
                        base.barStaticItemLocation1.Caption = string.Format("{0} {1}", str4, str5);
                        base.barStaticItemLocation2.Caption = string.Format("{0} {1}", str6, str7);
                        base.barStaticItemLocation1.Width = 300;
                        base.barStaticItemLocation2.Width = 250;
                        base.barStaticItemLocation3.Width = 210;
                    }
                    base.barStaticItemLocation3.Caption = string.Format("{0} {1} {2} {3} {4}", new object[] { "页面坐标：", e.pageX.ToString("###.##"), "厘米 ", e.pageY.ToString("###.##"), "厘米" });
                    base.textBox1.Left = ((((base.barStaticItemInfo.Width + base.barStaticItemLocation1.Width) + base.barStaticItemLocation2.Width) + base.barStaticItemLocation3.Width) + base.barStaticItemScale.Width) + 0x1a;
                    base.textBox1.Top = base.Height - 0x1b;
                    base.textBox1.Width = 0x54;
                    base.barStaticItemLocation3.Visibility = BarItemVisibility.Always;
                }
            }
            catch (Exception)
            {
            }
        }

        private void PageLayoutControlEdit_OnViewRefreshed(object sender, IPageLayoutControlEvents_OnViewRefreshedEvent e)
        {
            base.axTOCControl.Update();
        }

        private void PgaeLayoutControl_DbClick(object sender, IPageLayoutControlEvents_OnDoubleClickEvent e)
        {
            AxPageLayoutControl control = sender as AxPageLayoutControl;
            IPageLayoutControl3 pPageLayout = control.Object as IPageLayoutControl3;
            new ElementManager().SetProperty(pPageLayout, e.pageX, e.pageY);
        }

        protected void RefreshToolBarButton(bool flag)
        {
            try
            {
                if ((this.mCommandToolItems != null) && (this.mCommandToolItems.Count > 0))
                {
                    ICommand command = null;
                    foreach (BarButtonItem item in this.mCommandToolItems)
                    {
                        item.RibbonStyle = this.mRibbonItemStyles;
                        if (item.Tag != null)
                        {
                            ArrayList tag = item.Tag as ArrayList;
                            if (base.xtraTabMain.SelectedTabPageIndex == 0)
                            {
                                command = tag[0] as ICommand;
                                if (flag)
                                {
                                    command.OnCreate(base.MapControlEdit.Object);
                                }
                            }
                            else if (base.xtraTabMain.SelectedTabPageIndex == 1)
                            {
                                command = tag[tag.Count - 1] as ICommand;
                                if (flag)
                                {
                                    if ((command.Name == "ControlToolsGeneric_Undo") || (command.Name == "ControlToolsGeneric_Redo"))
                                    {
                                        command.OnCreate(this.tc1);
                                    }
                                    else
                                    {
                                        command.OnCreate(base.PageLayoutControlEdit.Object);
                                    }
                                }
                            }
                            if (command != null)
                            {
                                item.Enabled = command.Enabled;
                                item.Down = false;
                                if (item.SuperTip == null)
                                {
                                    item.SuperTip = new SuperToolTip();
                                    if (item.Caption != "")
                                    {
                                        item.SuperTip.Items.AddTitle(item.Caption);
                                    }
                                    else
                                    {
                                        item.SuperTip.Items.AddTitle(command.Caption);
                                    }
                                    if (item.Description != "")
                                    {
                                        item.SuperTip.Items.Add(item.Description);
                                    }
                                    else
                                    {
                                        item.SuperTip.Items.Add(command.Message);
                                    }
                                }
                                else if (item.SuperTip.Items.Count == 0)
                                {
                                    if (item.Caption != "")
                                    {
                                        item.SuperTip.Items.AddTitle(item.Caption);
                                    }
                                    else
                                    {
                                        item.SuperTip.Items.AddTitle(command.Caption);
                                    }
                                    if (item.Description != "")
                                    {
                                        item.SuperTip.Items.Add(item.Description);
                                    }
                                    else
                                    {
                                        item.SuperTip.Items.Add(command.Message);
                                    }
                                }
                                if (command is ITool)
                                {
                                    ITool tool = command as ITool;
                                    if (base.xtraTabMain.SelectedTabPageIndex == 0)
                                    {
                                        if (base.MapControlEdit.CurrentTool != null)
                                        {
                                            if ((base.MapControlEdit.CurrentTool.ToString() == tool.ToString()) && (command.Caption == (base.MapControlEdit.CurrentTool as ICommand).Caption))
                                            {
                                                item.Down = true;
                                            }
                                            else
                                            {
                                                item.Down = false;
                                            }
                                        }
                                    }
                                    else if ((base.xtraTabMain.SelectedTabPageIndex == 1) && (base.PageLayoutControlEdit.CurrentTool != null))
                                    {
                                        if (base.PageLayoutControlEdit.CurrentTool.ToString() == tool.ToString())
                                        {
                                            item.Down = true;
                                        }
                                        else
                                        {
                                            item.Down = false;
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (item.Caption != "")
                            {
                                item.SuperTip.Items.AddTitle(item.Caption);
                            }
                            else
                            {
                                item.SuperTip.Items.AddTitle(command.Caption);
                            }
                            if (item.Description != "")
                            {
                                item.SuperTip.Items.Add(item.Description);
                            }
                            else
                            {
                                item.SuperTip.Items.Add(command.Message);
                            }
                        }
                    }
                    if (base.MapControlEdit.CurrentTool is SnapEx)
                    {
                        base.ribbon.SetPopupContextMenu(this, null);
                    }
                    else if (this.barButtonItemEditFeature.Down)
                    {
                        base.ribbon.SetPopupContextMenu(this, this.popupMenuEdit);
                    }
                    else
                    {
                        base.ribbon.SetPopupContextMenu(this, this.popupMenuMapView);
                    }
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "GXFormMainFrame.FormMainEdit", "RefreshToolBarButton", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        protected void RefreshToolBarButton2()
        {
            try
            {
                int num;
                for (num = 0; num < base.ribbon.Items.Count; num++)
                {
                    if ((base.ribbon.Items[num] is BarButtonItem) || (base.ribbon.Items[num] is BarSubItem))
                    {
                        base.ribbon.Items[num].RibbonStyle = this.mRibbonItemStyles;
                    }
                }
                for (num = 0; num < base.ribbonPageDataEdit.Groups.Count; num++)
                {
                    if (base.ribbonPageDataEdit.Groups[num] != null)
                    {
                        int num2;
                        if (base.ribbonPageDataEdit.Groups[num].Name.Contains("ribbonPageGroupMapView"))
                        {
                            base.ribbonPageDataEdit.Groups[num].AllowMinimize = true;
                            if (this.mRibbonItemStyles == (RibbonItemStyles.SmallWithText | RibbonItemStyles.Large))
                            {
                                num2 = 0;
                                while (num2 < base.ribbonPageDataEdit.Groups[num].ItemLinks.Count)
                                {
                                    base.ribbonPageDataEdit.Groups[num].ItemLinks[num2].Item.RibbonStyle = RibbonItemStyles.SmallWithText;
                                    num2++;
                                }
                            }
                        }
                        else if (((base.ribbonPageDataEdit.Groups[num].Name.Contains("ribbonPageGroupEdit") || base.ribbonPageDataEdit.Groups[num].Name.Contains("ribbonPageGroupCaoTu")) || base.ribbonPageDataEdit.Groups[num].Name.Contains("ribbonPageGroupEdittool")) || base.ribbonPageDataEdit.Groups[num].Name.Contains("ribbonPageGroupCommEdit"))
                        {
                            if (this.mRibbonItemStyles == (RibbonItemStyles.SmallWithText | RibbonItemStyles.Large))
                            {
                                for (num2 = 0; num2 < base.ribbonPageDataEdit.Groups[num].ItemLinks.Count; num2++)
                                {
                                    base.ribbonPageDataEdit.Groups[num].ItemLinks[num2].Item.RibbonStyle = RibbonItemStyles.Large;
                                }
                            }
                            base.ribbonPageDataEdit.Groups[num].AllowMinimize = false;
                        }
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        private void ribbon_Click(object sender, EventArgs e)
        {
        }

        private void ribbon_ItemPress(object sender, ItemClickEventArgs e)
        {
            try
            {
                if (e.Item.Tag != null)
                {
                    IOperationStack operationStack;
                    ArrayList tag = e.Item.Tag as ArrayList;
                    BarButtonItem item = e.Item as BarButtonItem;
                    ICommand command = null;
                    if (base.MapControlEdit.Visible && (base.xtraTabMain.SelectedTabPageIndex == 0))
                    {
                        command = tag[0] as ICommand;
                    }
                    else if (base.PageLayoutControlEdit.Visible && (base.xtraTabMain.SelectedTabPageIndex == 1))
                    {
                        if (tag.Count > 1)
                        {
                            command = tag[1] as ICommand;
                        }
                        else if (tag.Count == 1)
                        {
                            command = tag[0] as ICommand;
                        }
                    }
                    if (command is ITool)
                    {
                        if (base.MapControlEdit.Visible && (base.xtraTabMain.SelectedTabPageIndex == 0))
                        {
                            base.MapControlEdit.CurrentTool = command as ITool;
                            operationStack = this.tc1.OperationStack;
                            this.RefreshToolBarButton(false);
                        }
                        else if (base.PageLayoutControlEdit.Visible && (base.xtraTabMain.SelectedTabPageIndex == 1))
                        {
                            base.PageLayoutControlEdit.CurrentTool = command as ITool;
                            operationStack = this.tc1.OperationStack;
                            this.RefreshToolBarButton(false);
                        }
                        else
                        {
                            operationStack = this.tc1.OperationStack;
                            command.OnClick();
                            this.RefreshToolBarButton(false);
                        }
                        if (e.Item.Name == this.barButtonItemAddFeature.Name)
                        {
                            Editor.UniqueInstance.AddAttribute = true;
                        }
                    }
                    else
                    {
                        operationStack = this.tc1.OperationStack;
                        command.OnClick();
                        this.RefreshToolBarButton(false);
                    }
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "GXFormMainFrame.FormMainEdit", "ribbon_ItemPress", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void ribbon_SelectedPageChanged(object sender, EventArgs e)
        {
            this.RefreshToolBarButton(false);
            if (base.ribbon.SelectedPage == base.ribbonPageDataEdit)
            {
                base.xtraTabMain.SelectedTabPageIndex = 0;
            }
            else if (base.ribbon.SelectedPage == base.ribbonPageQuery)
            {
                base.xtraTabMain.SelectedTabPageIndex = 0;
            }
            else if (base.ribbon.SelectedPage == base.ribbonPageGraphics)
            {
                base.xtraTabMain.SelectedTabPageIndex = 1;
            }
            this.mSelection = false;
        }

        private void SetButtonEnabled()
        {
            try
            {
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "GXFormMainFrame.FormMainEdit", "SetButtonEnabled", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void SetButtonTooltip()
        {
            try
            {
                for (int i = 0; i < base.ribbon.Items.Count; i++)
                {
                    if (base.ribbon.Items[i] is BarButtonItem)
                    {
                        BarButtonItem item = base.ribbon.Items[i] as BarButtonItem;
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
            catch (Exception)
            {
            }
        }

        private void SetButtonVisible()
        {
            try
            {
                this.xtraTabPageLocation.PageVisible = false;
                this.xtraTabPageMapFind.PageVisible = false;
                base.xtraTabPageQuery.PageVisible = false;
                this.xtraTabPageSelect.PageVisible = false;
                this.xtraTabPageXBchange.PageVisible = false;
                base.ribbonPageTransfer.Visible = false;
                this.ribbonPageGroupQuery2.Text = this.mEditKind + "查询";
                if (this.mEditKind == "造林")
                {
                    this.mEditKind2 = "ZaoLin";
                    this.barButtonItemXBUpdate.Visibility = BarItemVisibility.Never;
                    this.barButtonItemQueryXB.Visibility = BarItemVisibility.Never;
                    this.barButtonItemQueryZT.Visibility = BarItemVisibility.Always;
                    this.barButtonItemQueryYear.Visibility = BarItemVisibility.Never;
                }
                else if (this.mEditKind == "采伐")
                {
                    this.mEditKind2 = "CaiFa";
                    this.barButtonItemXBUpdate.Visibility = BarItemVisibility.Never;
                    this.barButtonItemQueryXB.Visibility = BarItemVisibility.Never;
                    this.barButtonItemQueryZT.Visibility = BarItemVisibility.Always;
                    this.barButtonItemQueryYear.Visibility = BarItemVisibility.Never;
                }
                else if (this.mEditKind == "林业工程")
                {
                    this.mEditKind2 = "LYGC";
                    this.barButtonItemXBUpdate.Visibility = BarItemVisibility.Never;
                    this.barButtonItemQueryXB.Visibility = BarItemVisibility.Never;
                    this.barButtonItemQueryZT.Visibility = BarItemVisibility.Always;
                }
                else if (this.mEditKind.Contains("征占用"))
                {
                    this.mEditKind2 = "ZZY";
                    this.barButtonItemXBUpdate.Visibility = BarItemVisibility.Never;
                    this.barButtonItemQueryXB.Visibility = BarItemVisibility.Never;
                    this.barButtonItemQueryZT.Visibility = BarItemVisibility.Always;
                }
                else if (this.mEditKind.Contains("火灾"))
                {
                    this.mEditKind2 = "Fire";
                    this.barButtonItemXBUpdate.Visibility = BarItemVisibility.Never;
                    this.barButtonItemQueryXB.Visibility = BarItemVisibility.Never;
                    this.barButtonItemQueryZT.Visibility = BarItemVisibility.Always;
                }
                else if (this.mEditKind.Contains("自然灾害"))
                {
                    this.mEditKind2 = "ZRZH";
                    this.barButtonItemXBUpdate.Visibility = BarItemVisibility.Never;
                    this.barButtonItemQueryXB.Visibility = BarItemVisibility.Never;
                    this.barButtonItemQueryZT.Visibility = BarItemVisibility.Always;
                }
                else if (this.mEditKind.Contains("案件"))
                {
                    this.mEditKind2 = "AnJian";
                    this.barButtonItemXBUpdate.Visibility = BarItemVisibility.Never;
                    this.barButtonItemQueryXB.Visibility = BarItemVisibility.Never;
                    this.barButtonItemQueryZT.Visibility = BarItemVisibility.Always;
                }
                else if (this.mEditKind == "小班变更")
                {
                    this.mEditKind2 = "XB";
                    this.ribbonPageGroupCaoTu.Visible = true;
                    if (this.barButtonItemInputZT.Down)
                    {
                        this.xtraTabPageXBchange.PageVisible = true;
                    }
                    this.barButtonItemInput.Visibility = BarItemVisibility.Never;
                    this.barButtonItemQueryXB.Visibility = BarItemVisibility.Always;
                    this.barButtonItemQueryZT.Visibility = BarItemVisibility.Never;
                }
                else if (this.mEditKind == "年度小班")
                {
                    this.mEditKind2 = "XB";
                    this.ribbonPageGroupXB.Visible = true;
                    this.barButtonItemInput.Visibility = BarItemVisibility.Never;
                    this.barButtonItemQueryXB.Visibility = BarItemVisibility.Always;
                    this.barButtonItemQueryZT.Visibility = BarItemVisibility.Never;
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "GXFormMainFrame.FormMainEdit", "SetButtonVisible", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }       

        private void SetFormText()
        {
            try
            {
                string systemName = UtilFactory.GetConfigOpt().GetSystemName();
                if (this.mEditKind == "年度小班")
                {
                    this.Text = systemName + EditTask.TaskYear + "年度 — 系统管理";
                    base.barStaticItemInfo.Caption = "就绪";
                }
                else
                {
                    string taskState = this.GetTaskState(EditTask.TaskState);
                    if (TaskManageClass.TaskState == TaskState.Open)
                    {
                        this.Text = systemName + " — " + this.mEditKind + "专题系统管理";
                        base.barStaticItemInfo.Caption = EditTask.TaskName;
                    }
                    else if (TaskManageClass.TaskState == TaskState.Close)
                    {
                        this.Text = systemName + " — " + this.mEditKind;
                        base.barStaticItemInfo.Caption = "就绪";
                    }
                }
                base.ribbon.ApplicationCaption = this.Text;
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "GXFormMainFrame.FormMainEdit", "SetFormText", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
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
                this.mErrOpt.ErrorOperate(this.mSubSysName, "GXFormMainFrame.FormMainEdit", "SetMapScale", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void SetPageLayoutValues()
        {
            try
            {
                IGraphicsContainer graphicsContainer = base.PageLayoutControlEdit.GraphicsContainer;
                graphicsContainer.Reset();
                IElement element = graphicsContainer.Next();
                while (element != null)
                {
                    if (element is IGraphicElement)
                    {
                        IGraphicElement element2 = element as IGraphicElement;
                        if (element2 is IFrameElement)
                        {
                            IFrameElement element4 = (IFrameElement) element2;
                        }
                        else if (!(element2 is IDataGraphTElement))
                        {
                            if (element2 is IMarkerElement)
                            {
                                IMarkerElement element3 = element2 as IMarkerElement;
                            }
                            else if (element2 is ITextElement)
                            {
                                ITextElement element5 = element2 as ITextElement;
                                IElementProperties properties = element as IElementProperties;
                                if (properties.Name == "Time")
                                {
                                    element5.Text = DateTime.Now.Year.ToString() + "年" + DateTime.Now.Month.ToString() + "月" + DateTime.Now.Day.ToString() + "日";
                                }
                                else if (properties.Name == "title")
                                {
                                    element5.Text = this.mEditKind + "专题图";
                                }
                                else if ((properties.Name == "Department") && (EditTask.DistCode != ""))
                                {
                                    if (EditTask.DistCode.Length == 6)
                                    {
                                        element5.Text = this.GetDistName(EditTask.DistCode) + "林业局";
                                    }
                                    else if (EditTask.DistCode.Length == 9)
                                    {
                                        element5.Text = this.GetDistName(EditTask.DistCode) + "林业站";
                                    }
                                }
                                if (element5.ScaleText)
                                {
                                }
                            }
                        }
                    }
                    element = graphicsContainer.Next();
                }
            }
            catch (Exception)
            {
            }
        }

        private bool ShowSplash()
        {
            Exception exception;
            try
            {
                Image image = null;
                try
                {
                    image = new Bitmap(UtilFactory.GetConfigOpt().RootPath + @"\" + PathManager.FindValue("SplashBmpPath"));
                }
                catch (Exception exception1)
                {
                    exception = exception1;
                }
                return true;
            }
            catch (Exception exception2)
            {
                exception = exception2;
                this.mErrOpt.ErrorOperate(this.mSubSysName, "GXFormMainFrame.FormMainEdit", "ShowSplash", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                return false;
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar == '\r') && !this.mSelection)
            {
                this.mSelection = true;
                base.barEditItemScale.EditValue = base.textBox1.Text.ToString();
                if (!base.barEditItemScale.EditValue.ToString().Contains("1:"))
                {
                    base.barEditItemScale.EditValue = "1:" + base.barEditItemScale.EditValue.ToString();
                    base.textBox1.Text = base.barEditItemScale.EditValue.ToString();
                }
                if (base.xtraTabMain.SelectedTabPageIndex == 0)
                {
                    this.SetMapScale(base.MapControlEdit.Map, base.barEditItemScale.EditValue.ToString());
                }
                else if (base.xtraTabMain.SelectedTabPageIndex == 1)
                {
                    this.SetMapScale(base.PageLayoutControlEdit.ActiveView.FocusMap, base.barEditItemScale.EditValue.ToString());
                }
                this.mSelection = false;
            }
        }

        private void Toc_OnMouseDown(object sender, ITOCControlEvents_OnMouseDownEvent e)
        {
            AxTOCControl control = sender as AxTOCControl;
            control.SetBuddyControl(base.MapControlEdit);
            control.Update();
            esriTOCControlItem esriTOCControlItemNone = esriTOCControlItem.esriTOCControlItemNone;
            IBasicMap basicMap = null;
            ILayer layer = null;
            object unk = null;
            object data = null;
            control.HitTest(e.x, e.y, ref esriTOCControlItemNone, ref basicMap, ref layer, ref unk, ref data);
            if ((e.button == 2) && (esriTOCControlItemNone == esriTOCControlItem.esriTOCControlItemLayer))
            {
                TocMenu menu = new TocMenu(control.Object as ITOCControl2);
                control.SelectItem(layer, null);
                control.CustomProperty = layer;
                menu.ShowMenu(e.x, e.y, control.hWnd);
            }
        }

        private void userControlLayerControltreeList1_MouseDown(object sender, MouseEventArgs e)
        {
            base.ribbon.SetPopupContextMenu(this, null);
        }

        private void userControlLayerControltreeList1_MouseMove(object sender, MouseEventArgs e)
        {
            base.ribbon.SetPopupContextMenu(this, null);
        }

        private void xtraTabMain_Resize(object sender, EventArgs e)
        {
            if (base.xtraTabMain.SelectedTabPageIndex == 0)
            {
                base.MapControlEdit.BringToFront();
                base.MapControlEdit.Dock = DockStyle.None;
                base.MapControlEdit.Left = 1;
                base.MapControlEdit.Top = 1;
                base.MapControlEdit.Width = base.xtraTabMain.Width - 2;
                base.MapControlEdit.Height = base.xtraTabMain.Height - 30;
                base.MapControlEdit.ShowScrollbars = false;
                base.PageLayoutControlEdit.Dock = DockStyle.None;
                base.PageLayoutControlEdit.Left = 1;
                base.PageLayoutControlEdit.Top = 1;
                base.PageLayoutControlEdit.Width = base.xtraTabMain.Width - 2;
                base.PageLayoutControlEdit.Height = base.xtraTabMain.Height - 30;
            }
            else if (base.xtraTabMain.SelectedTabPageIndex == 1)
            {
                base.PageLayoutControlEdit.BringToFront();
                base.PageLayoutControlEdit.Dock = DockStyle.None;
                base.PageLayoutControlEdit.Left = 1;
                base.PageLayoutControlEdit.Top = 1;
                base.PageLayoutControlEdit.Width = base.xtraTabMain.Width - 2;
                base.PageLayoutControlEdit.Height = base.xtraTabMain.Height - 30;
                base.MapControlEdit.Dock = DockStyle.None;
                base.MapControlEdit.Left = 1;
                base.MapControlEdit.Top = 1;
                base.MapControlEdit.Width = base.xtraTabMain.Width - 2;
                base.MapControlEdit.Height = base.xtraTabMain.Height - 30;
                base.MapControlEdit.ShowScrollbars = false;
            }
        }

        private void xtraTabMain_SelectedPageChanged(object sender, TabPageChangedEventArgs e)
        {
            try
            {
                if (!this.mSelection)
                {
                    this.RefreshToolBarButton(false);
                    if (base.xtraTabMain.SelectedTabPageIndex == 0)
                    {
                        this.m_controlsSynchronizer2.SetMapOfPagelayoutToMap();
                        this.m_controlsSynchronizer2.ActivateMap();
                        base.barEditItemScale.EditValue = this.GetMapScale(base.MapControlEdit.Map);
                        if (TaskManageClass.TaskState == TaskState.Close)
                        {
                            base.dockPanelBottom.Visibility = DockVisibility.Hidden;
                        }
                        else if (TaskManageClass.TaskState == TaskState.Open)
                        {
                        }
                        base.dockPanelEdit.Visibility = DockVisibility.Hidden;
                        if (this.barButtonItemSelectLayerSet.Down)
                        {
                            this.userControlSelectLayerSet1.Hook = base.MapControlEdit.Object;
                            this.userControlSelectLayerSet1.InitialValue();
                            this.xtraTabPageSelect.PageVisible = true;
                        }
                        int width = 0;
                        if (base.dockPanelToolbox.Visibility == DockVisibility.Visible)
                        {
                            width = base.dockPanelToolbox.Width;
                        }
                        base.MapControlEdit.ShowScrollbars = false;
                        this.m_controlsSynchronizer2.SetMapOfPagelayoutToMap();
                        this.m_controlsSynchronizer2.ActivateMap();
                    }
                    else if (base.xtraTabMain.SelectedTabPageIndex == 1)
                    {
                        base.ribbon.SelectedPage = base.ribbonPageGraphics;
                        base.dockPanelEdit.Visibility = DockVisibility.Hidden;
                        base.dockPanelBottom.Visibility = DockVisibility.Hidden;
                        this.m_controlsSynchronizer2.SetMapOfMapToPagelayout();
                        this.m_controlsSynchronizer2.ActivatePageLayout();
                        this.SetPageLayoutValues();
                    }
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "GXFormMainFrame.FormMainEdit", "xtraTabMain_SelectedPageChanged", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void MapControlEdit_OnMouseDown(object sender, IMapControlEvents2_OnMouseDownEvent e)
        {

        }
    }
}

