namespace GXFormMainFrame
{
    using AttributesEdit;
    using Cartography;
    using Cartography.Business;
    using Cartography.Element;
    using Cartography.Template;
    using DataEdit;
    using DevExpress.Utils;
    using DevExpress.XtraBars;
    using DevExpress.XtraBars.Docking;
    using DevExpress.XtraBars.Ribbon;
    using DevExpress.XtraEditors;
    using DevExpress.XtraEditors.Controls;
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
    using GeoDataIE;
    using GISControlsClass;
    using gylandzzytj;
    using LDZY_ZTZL;
    using LDZY_ZTZZ;
    using MainFrameBase;
    using Measure;
    using Print;
    using ProxyButton;
    using QueryAnalysic;
    using QueryCommon;
    using Report;
    using ShapeEdit;
    using StatisChart;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Diagnostics;
    using System.Drawing;
    using System.IO;
    using System.Windows.Forms;
    using TaskManage;

    using Utilities;
    using VgsTiledMap.Ags;
    using VgsTiledMap.Ags.VgsTile.Configs;
    using jn.isos.log;
    using td.forest.task.linker;
    using td.db.orm;
    using td.db.etl.zl;
    using td.db.etl.aj;
    using td.db.etl.zh;
    using td.forest.report;
    using td.db.etl.xb;
    using td.db.etl.cf;
    using GXFormMainFrame.etl.zz;
    using System.Data.SQLite;

    /// <summary>
    /// “资源信息查询”的“二维浏览”窗体使用了此界面
    /// </summary>
    public class MainFrameQuery : RibbonFormFrame2
    {
        #region 基本变量
        private IToolbarControl _editMapToolBar = new ToolbarControlClass();
        private BarButtonGroup barButtonGroup1;
        private BarButtonItem barButtonItemAddDRG;
        private BarButtonItem barButtonItemAddFeature;
        private BarButtonItem barButtonItemAddLayer;
        private BarButtonItem barButtonItemAddLayer2;
        private BarButtonItem barButtonItemAddLayer3;
        private BarButtonItem barButtonItemBack;
        private BarButtonItem barButtonItemBoudarySnap;
        private BarButtonItem barButtonItemChartCF;
        private BarButtonItem barButtonItemChartHZ;
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
        private BarButtonItem barButtonItemDC;
        private BarButtonItem barButtonItemDeleteFeature;
        private BarButtonItem barButtonItemEditFeature;
        private BarButtonItem barButtonItemEditRedo;
        private BarButtonItem barButtonItemEditUndo;
        private BarButtonItem barButtonItemEraseFeature;
        private BarButtonItem barButtonItemExit;
        private BarButtonItem barButtonItemExportImage;
        private BarButtonItem barButtonItemForward;
        private BarButtonItem barButtonItemFullMap;
        private BarButtonItem barButtonItemGrowthModel;
        private BarButtonItem barButtonItemHZInfoTable;
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
        private BarButtonItem barButtonItemLogicCheck;
        private BarButtonItem barButtonItemMapComment;
        private BarButtonItem barButtonItemMapFind;
        private BarButtonItem barButtonItemMapFrame;
        private BarButtonItem barButtonItemMapGrid;
        private BarButtonItem barButtonItemMapLegend;
        private BarButtonItem barButtonItemMapNorthArrow;
        private BarButtonItem barButtonItemMapScaleBar;
        private BarButtonItem barButtonItemMapSet;
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
        private BarButtonItem barButtonItemQueryKindAJ;
        private BarButtonItem barButtonItemQueryKindCF;
        private BarButtonItem barButtonItemQueryKindHZ;
        private BarButtonItem barButtonItemQueryKindLDBH;
        private BarButtonItem barButtonItemQueryKindXB;
        private BarButtonItem barButtonItemQueryKindZH;
        private BarButtonItem barButtonItemQueryKindZL;
        private BarButtonItem barButtonItemQueryKindZZY;
        private BarButtonItem barButtonItemQueryTF;
        private BarButtonItem barButtonItemQueryXB;
        private BarButtonItem barButtonItemQueryYear;
        private BarButtonItem barButtonItemQueryZT;
        private BarButtonItem barButtonItemQuickSnap;
        private BarButtonItem barButtonItemRedo;
        private BarButtonItem barButtonItemRefresh;
        private BarButtonItem barButtonItemReportAJ;
        private BarButtonItem barButtonItemReportCF1;
        private BarButtonItem barButtonItemReportGYL;
        private BarButtonItem barButtonItemReportHZ;
        private BarButtonItem barButtonItemReportKind;
        private BarButtonItem barButtonItemReportLD;
        private BarButtonItem barButtonItemReportZH;
        private BarButtonItem barButtonItemReportZL;
        private BarButtonItem barButtonItemReportZZY;
        private BarButtonItem barButtonItemReportZZY2;
        private BarButtonItem barButtonItemReportZZY3;
        private BarButtonItem barButtonItemSave;
        private BarButtonItem barButtonItemScaleText;
        private BarButtonItem barButtonItemSelectedFeaturesReport;
        private BarButtonItem barButtonItemSelectElement;
        private BarButtonItem barButtonItemSelectFeature;
        private BarButtonItem barButtonItemSelectLayerSet;
        private BarButtonItem barButtonItemShapeCopy;
        private BarButtonItem barButtonItemShapePaste;
        private BarButtonItem barButtonItemSimplify;
        private BarButtonItem barButtonItemSJ;
        private BarButtonItem barButtonItemSmallButton;
        private BarButtonItem barButtonItemSmallText;
        private BarButtonItem barButtonItemSplitFeature;
        /// <summary>
        /// 小班统计报表
        /// </summary>
        private BarButtonItem barButtonItemStatic;
        private BarButtonItem barButtonItemTOC;
        private BarButtonItem barButtonItemTOC2;
        private BarButtonItem barButtonItemTotalLayer;
        private BarButtonItem barButtonItemUndo;
        private BarButtonItem barButtonItemVertexDelete;
        private BarButtonItem barButtonItemVertexInsert;
        private BarButtonItem barButtonItemVertexList;
        private BarButtonItem barButtonItemXBEdit;
        private BarButtonItem barButtonItemXBSet;
        private BarButtonItem barButtonItemXBUpdate;
        private BarButtonItem barButtonItemZoomIn;
        private BarButtonItem barButtonItemZoomOut;
        private BarButtonItem barButtonItemZTT;
        private BarButtonItem barButtonToolbox;
        private BarButtonItem barButtonToolView;
        private BarEditItem barEditItem_fx;
        private BarEditItem barEditItem1;
        private BarSubItem barSubItemButtonStyle;
        private bool bDefaultPath = true;
        private IContainer components = null;
        /// <summary>
        /// FormLogin4：登录主界面（主要显示登录界面的各功能及其子功能）
        /// </summary>
        public FormLogin4 FormSplash;
        /// <summary>
        /// FormLogin6：登录附界面（在此界面上主要用于显示加载进度的信息）
        /// </summary>
        public FormLogin6 FormSplash6;
        private bool HasLayerResource = true;
        /// <summary>
        /// IActiveViewEvents.AfterDraw事件在指定阶段绘制后启动。
        /// </summary>
        private IActiveViewEvents_AfterDrawEventHandler m_ActiveViewEventsAfterDraw;
        /// <summary>
        /// IActiveViewEvents.AfterItemDraw事件在单个视图项目绘制后触发。示例：查看项目包括地图中的图层或页面布局中的元素。
        /// AfterItemDraw可以在每个单独的项目绘制后执行。然而，当地图中有许多层时，事件触发可能是一项昂贵的操作（耗时）。
        /// 因此，仅当IViewManger :: VerboseEvents属性设置为True时才会触发AfterItemDraw事件。默认情况下，此属性为False。
        /// </summary>
        private IActiveViewEvents_AfterItemDrawEventHandler m_ActiveViewEventsAfterItemDraw;
        /// <summary>
        /// IActiveViewEvents.ContentsChanged事件当视图内容发生变化时触发。
        /// 当加载新文档时，Map对象会触发此事件。 向地图添加新图层不会触发此事件。
        /// 当IGraphicsContainer :: DeleteAllElements在调用时和新文档加载时，PageLayout对象会触发该事件。
        /// </summary>
        private IActiveViewEvents_ContentsChangedEventHandler m_ActiveViewEventsContentsChanged;
        /// <summary>
        /// IActiveViewEvents.ContentsCleared事件当视图的内容被清除时触发。
        /// </summary>
        private IActiveViewEvents_ContentsClearedEventHandler m_ActiveViewEventsContentsCleared;
        /// <summary>
        /// IActiveViewEvents.FocusMapChanged事件当新地图激活时触发。
        /// </summary>
        private IActiveViewEvents_FocusMapChangedEventHandler m_ActiveViewEventsFocusMapChanged;
        /// <summary>
        /// IActiveViewEvents.ItemAdded事件当项目添加到视图时触发。
        /// 每次添加新图层时，地图都会触发该事件。
        /// 每当将新元素添加到布局时，PageLayout将触发此事件。 元素不仅包括图形，还包括数据帧。
        /// </summary>
        private IActiveViewEvents_ItemAddedEventHandler m_ActiveViewEventsItemAdded;
        /// <summary>
        /// IActiveViewEvents.ItemDeleted事件从视图中删除项目时触发。
        /// 每当从布局中删除元素时，PageLayout对象会触发此事件。
        /// 删除图层时，Map对象会触发此事件。
        /// </summary>
        private IActiveViewEvents_ItemDeletedEventHandler m_ActiveViewEventsItemDeleted;
        /// <summary>
        /// IActiveViewEvents.ItemReordered事件当视图项目重新排序时触发。
        /// 每当调用IMap :: MoveLayer时，Map对象只会触发此事件。在ArcMap应用程序中，当您重新排列目录中的图层时，会发生这种情况。当添加新图层时，地图也将触发此事件。
        /// 当更改图形的顺序时，PageLayout对象会触发此事件。例如，IGraphicsContainer :: BringToFront，PutElementOrder，SendToBack，SendBackward和BringForward都会触发此事件。
        /// 这些功能位于ArcMap的“绘图”菜单中的“订单拉”菜单下。虽然Map对象也是一个图形容器，但是当它的图形重新排序时，它不会触发此事件。
        /// </summary>
        private IActiveViewEvents_ItemReorderedEventHandler m_ActiveViewEventsItemReordered;
        /// <summary>
        /// IActiveViewEvents.SelectionChanged事件调用此功能来激活选择更改的事件。
        /// </summary>
        private IActiveViewEvents_SelectionChangedEventHandler m_ActiveViewEventsSelectionChanged;
        /// <summary>
        /// IActiveViewEvents.SpatialReferenceChanged事件当空间参考更改时触发。
        /// </summary>
        private IActiveViewEvents_SpatialReferenceChangedEventHandler m_ActiveViewEventsSpatialReferenceChanged;
        /// <summary>
        /// IActiveViewEvents.ViewRefreshed事件当画面发生之前刷新视图时触发。
        /// 响应IActiveView :: Refresh和IActiveView :: PartialRefresh触发的方法。
        /// 在您正在观看视图中要更改的内容并且没有任何特定事件（例如ContentsChanged，ItemAdded）的情况下，此事件很有用。
        /// 您可以随时收听此方法作为最后的手段。但是，必须注意在执行此事件时效率非常高，因为这样会被频繁地调用。
        /// 事件参数直接与IActiveView :: PartialRefresh的参数一致。有关参数的其他信息，请参阅该方法的帮助。
        /// 如果事件对象连接到布局和映射，则viewparameter会告诉您哪个对象发起了事件。
        /// 在这种方法的实现中，您通常需要检查相位并仅响应一个。否则，您的代码将每个绘图序列执行多次。
        /// </summary>
        private IActiveViewEvents_ViewRefreshedEventHandler m_ActiveViewEventsViewRefreshed;
        /// <summary>
        /// 定义控制的同步类
        /// </summary>
        protected ControlsSynchronizer m_controlsSynchronizer;
        /// <summary>
        /// 定义控制的同步类
        /// </summary>
        protected ControlsSynchronizer m_controlsSynchronizer2;
        /// <summary>
        /// 县要素
        /// </summary>
        private IFeature m_CountyFeature = null;
        /// <summary>
        ///  县图层
        /// </summary>
        private IFeatureLayer m_pCLayer = null;
        /// <summary>
        /// 实现按用户定义的时间间隔引发事件的计时器。此计时器最宜用于 Windows 窗体应用程序中，并且必须在窗口中使用。
        /// </summary>
        private Timer m_Timer = null;
        /// <summary>
        /// IActiveViewEvents_Event:提供对活动视图的状态更改时发生的事件的访问。
        /// </summary>
        private IActiveViewEvents_Event mActiveViewEvents;
        protected ArrayList mButtonCollection = new ArrayList();
        protected ArrayList mButtonCollection2 = new ArrayList();
        protected ArrayList mButtonCollection3 = new ArrayList();
        private const string mClassName = "GXFormMainFrame.FormMainEdit";
        /// <summary>
        /// 菜单栏条目：封装在ArrayList数组里
        /// </summary>
        private ArrayList mCommandMenuItems = new ArrayList();
        /// <summary>
        /// 工具栏条目：封装在ArrayList数组里
        /// </summary>
        private ArrayList mCommandToolItems = new ArrayList();
        private BarButtonItem mCurBarButtonItem;
        private BarButtonItem mCurMenuButtonItem;
        protected ICommand mCurrentTool = null;
        private IGroupLayer mEditGroupLayer = null;
        ///
        /// <summary>
        /// 编辑类型 
        /// </summary>
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
        private bool mFirstFlag = true;
        private FormVertexList mFormVertexList = null;
        private bool mInUse;
        private IFeatureLayer[] mLinkageLayer = null;
        private static Process mProcess = null;
        private RibbonItemStyles mRibbonItemStyles = RibbonItemStyles.Default;
        private bool mSelection;
        private string mSubSysName = UtilFactory.GetConfigOpt().GetSystemName();
        private PopupMenu popupMenuEdit;
        private PopupMenu popupMenuLinkage;
        private PopupMenu popupMenuMapView;
        private PopupMenu popupMenuVertex;
        private RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private RepositoryItemComboBox repositoryItemComboBox2;
        private RibbonPageGroup ribbonPageGroupAddnew;
        private RibbonPageGroup ribbonPageGroupAJ;
        private RibbonPageGroup ribbonPageGroupCaoTu;
        private RibbonPageGroup ribbonPageGroupCF;
        private RibbonPageGroup ribbonPageGroupCommEdit;
        private RibbonPageGroup ribbonPageGroupDataCheck;
        private RibbonPageGroup ribbonPageGroupDelete;
        private RibbonPageGroup ribbonPageGroupEdit;
        private RibbonPageGroup ribbonPageGroupEdittool;
        private RibbonPageGroup ribbonPageGroupGYL;
        private RibbonPageGroup ribbonPageGroupHZ;
        private RibbonPageGroup ribbonPageGroupLD;
        private RibbonPageGroup ribbonPageGroupLogic;
        private RibbonPageGroup ribbonPageGroupMapView;
        private RibbonPageGroup ribbonPageGroupMapView2;
        private RibbonPageGroup ribbonPageGroupMapView3;
        private RibbonPageGroup ribbonPageGroupMapView4;
        private RibbonPageGroup ribbonPageGroupMxt;
        private RibbonPageGroup ribbonPageGroupPageTool;
        private RibbonPageGroup ribbonPageGroupPageView;
        private RibbonPageGroup ribbonPageGroupQuery;
        private RibbonPageGroup ribbonPageGroupQuery2;
        private RibbonPageGroup ribbonPageGroupQueryComm;
        private RibbonPageGroup ribbonPageGroupReportXB;
        private RibbonPageGroup ribbonPageGroupToplogic;
        private RibbonPageGroup ribbonPageGroupToplogic2;
        private RibbonPageGroup ribbonPageGroupTopoModify;
        private RibbonPageGroup ribbonPageGroupXB;
        private RibbonPageGroup ribbonPageGroupXBSet;
        private RibbonPageGroup ribbonPageGroupZH;
        private RibbonPageGroup ribbonPageGroupZL;
        private RibbonPageGroup ribbonPageGroupZZY;
        private RibbonPage ribbonPageStatic;
        private string sMxdPath = "";
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
        private UserControlMapFind userControlMapFind1;
        /// <summary>
        /// 
        /// </summary>
        private UserControlOverView userControlOverView;
        /// <summary>
        /// 查询--地名查找：工具箱界面
        /// </summary>
        private UserControlPlace userControlPlace1;
        private UserControlQueryAJ userControlQueryAJ1;
        private UserControlQueryCF userControlQueryCF1;
        /// <summary>
        /// “造林查询”的工具箱界面
        /// </summary>
        private UserControlQueryCF2 userControlQueryCF21;
        private UserControlQueryHZ userControlQueryHZ1;
        private UserControlQueryHZ2 userControlQueryHZ21;
        private UserControlQueryLDBH userControlQueryLDBH1;
        private QueryCommon.UserControlQueryResult userControlQueryResult1;
        private QueryCommon.UserControlQueryResult userControlQueryResult2;
        private UserControlQueryTFH userControlQueryTFH1;
        private UserControlQueryXB userControlQueryXB;
        private UserControlQueryXB2 userControlQueryXB21;
        private UserControlQueryZH userControlQueryZH1;
        private UserControlQueryZL userControlQueryZL1;
        private UserControlQueryZZY userControlQueryZZY1;
        private UserControlQueryZZY2 userControlQueryZZY21;
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
        private XtraTabPage xtraTabPageInputData;
        private XtraTabPage xtraTabPageKind;
        private XtraTabPage xtraTabPageLocation;
        private XtraTabPage xtraTabPageLogicCheck;
        private XtraTabPage xtraTabPageMapFind;
        private XtraTabPage xtraTabPagePlace;
        private XtraTabPage xtraTabPageSelect;
        private XtraTabPage xtraTabPageTFH;
        private XtraTabPage xtraTabPageUpdate;
        private XtraTabPage xtraTabPageXBchange;
        private XtraTabControl xtraTabQuery;
        private XtraTabPage xtraTabPageCX;
        private UserControlSelectByAttributes userControlSelectByAttributes1;
        private BarButtonItem barButtonItemCX;
        private BarButtonItem barButtonReportCustom;
        private RibbonPageGroup ribbonPageGroup1;
        private BarStaticItem barStaticItem1;
        private BarEditItem barEditItem2;
        private RepositoryItemComboBox repositoryItemComboBox3;
        private RibbonPageGroup ribbonPageGroup2;
        private Logger m_log = LoggerManager.CreateLogger("UI", typeof(MainFrameQuery));
        # endregion

        /// <summary>
        ///  “资源信息查询”的“二维浏览”窗体使用了此界面的构造器
        /// </summary>
        public MainFrameQuery()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// 每次添加新图层时，地图都会触发该事件。
        /// </summary>
        /// <param name="Item"></param>
        private void ActiveViewEvents_ItemAdded(object Item)
        {
            base.axTOCControl.SetBuddyControl(base.MapControlEdit);
            base.axTOCControl.Update();
        }

        /// <summary>
        /// 每当从布局中删除元素时，PageLayout对象会触发此事件。
        /// 删除图层时，Map对象会触发此事件。
        /// </summary>
        /// <param name="Item"></param>
        private void ActiveViewEvents_ItemDeleted(object Item)
        {
            base.axTOCControl.SetBuddyControl(base.MapControlEdit);
            base.axTOCControl.Update();
        }
        /// <summary>
        /// 增加卫星影像
        /// </summary>
        private void AddEviaTiledSatellite()
        {
            try
            {
                IMap pMap = base.MapControlEdit.Map;
                IGroupLayer pGl = GISFunFactory.LayerFun.FindLayer(pMap as IBasicMap, "影像", true) as IGroupLayer;
                //<MapServerPath Name="地图服务路径">DOM2012</MapServerPath>
                string configValue = UtilFactory.GetConfigOpt().GetConfigValue("MapServerPath");
                string sAliasName = "卫星影像";
                int iYear = 0;
                EnumArcVgsTileLayer eviaTiledSatellite = EnumArcVgsTileLayer.EviaTiledSatellite;
                if (pGl != null)
                {
                    this.AddVgsLayer(pMap, pGl, configValue, sAliasName, iYear, eviaTiledSatellite);
                }
                pGl = GISFunFactory.LayerFun.FindLayer(pMap as IBasicMap, "扫描图", true) as IGroupLayer;
                if (pGl != null)
                {
                    pGl.Name = "工作底图";
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "GXFormMainFrame.FormMainEdit", "AddEviaTiledSatellite", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void AddVgsLayer(IMap pMap, IGroupLayer pGl, string sLyrName, string sAliasName, int iYear, EnumArcVgsTileLayer pLayerType)
        {
            try
            {
                if (pMap != null)
                {
                    if (string.IsNullOrEmpty(sLyrName))
                    {
                        MessageBox.Show("请设置需要添加的图层名称!");
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(sAliasName))
                        {
                            sAliasName = sLyrName;
                        }
                        string lyrYear = string.Empty;
                        if (iYear >= 0x7d9)
                        {
                            lyrYear = iYear.ToString();
                        }
                        else if (iYear == 0)
                        {
                            if (pLayerType == EnumArcVgsTileLayer.EviaTiledSatellite)
                            {
                                lyrYear = "0000";
                            }
                            else
                            {
                                lyrYear = string.Empty;
                            }
                        }
                        IConfig config = null;
                        switch (pLayerType)
                        {
                            case EnumArcVgsTileLayer.VgsTiled:
                                config = new ConfigLindi(string.Empty, sLyrName, lyrYear, "png");
                                break;

                            case EnumArcVgsTileLayer.VgsSatellite:
                            case EnumArcVgsTileLayer.EviaTiledSatellite:
                                config = new ConfigLindi(string.Empty, sLyrName, lyrYear, "etd");
                                break;

                            default:
                                config = new ConfigLindi(string.Empty, sLyrName, lyrYear, "png");
                                break;
                        }
                        if (config != null)
                        {
                            VgsArcTileLayer layer = null;
                            layer = new VgsArcTileLayer(pMap, config)
                            {
                                Name = sAliasName,
                                Visible = true
                            };
                            if (pGl != null)
                            {
                                pGl.Add(layer);
                            }
                            else
                            {
                                pMap.AddLayer(layer);
                            }
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "GXFormMainFrame.FormMainEdit", "AddVgsLayer", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
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
                    IMapFrame frame = (IMapFrame)base.PageLayoutControlEdit.FindElementByName(name);
                    map = frame.Map;
                    activeView = (IActiveView)frame.Map;
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

        /// <summary>
        /// 统计--采伐统计表 的响应事件:有误
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItemCF1_ItemClick(object sender, ItemClickEventArgs e)
        {
            ReportEntry entry = new ReportEntry();

            #region 添加源代码：得到采伐图层和数据表
            string str = UtilFactory.GetConfigOpt().GetConfigValue("CaiFaLayer") + "_" + EditTask.TaskYear;
            FindMidFromLayer_CF midLyr = new FindMidFromLayer_CF();
            midLyr.DataClass = GetFeatureClass(str);
            #endregion

            ReportParamter pReportParamter = new ReportParamter
            {
                TaskName = "采伐",
                Year = EditTask.TaskYear,
                SysType = Report.SystemType.ZYGL_EWLL_CF,

                TaskID = EditTask.TaskID.ToString(),
                FindFromLayer_CF = midLyr

            };
            entry.Show(pReportParamter);
        }

        private void barButtonItemChartCF_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmCFStatis statis = new FrmCFStatis();
            string sTableName = UtilFactory.GetConfigOpt().GetConfigValue("CaiFaLayer") + "_" + EditTask.TaskYear;
            statis.InitialValue("采伐", "CaiFa", EditTask.DistCode, sTableName);
            statis.ShowDialog(this);
        }

        private void barButtonItemChartHZ_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmCFStatis statis = new FrmCFStatis();
            string configValue = UtilFactory.GetConfigOpt().GetConfigValue("FireTableName");
            statis.InitialValue("火灾", "HuoZai", EditTask.DistCode, configValue);
            statis.ShowDialog(this);
        }

        private void barButtonItemChartZL_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmCFStatis statis = new FrmCFStatis();
            string sTableName = UtilFactory.GetConfigOpt().GetConfigValue("ZaoLinLayer") + "_" + EditTask.TaskYear;
            statis.InitialValue("造林", "ZaoLin", EditTask.DistCode, sTableName);
            statis.ShowDialog(this);
        }

        private void barButtonItemDC_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.barButtonItemSJ.Down = false;
            this.barButtonItemZTT.Down = false;
            TemplateCartoManager manager = new TemplateCartoManager();
            Cartography.Template.TemplateInfo pInfo = new Cartography.Template.TemplateInfo();
            switch (this.barEditItem_fx.EditValue.ToString())
            {
                case "A4横向":
                    pInfo.TemplateDirection = Direction.Heng;
                    pInfo.TF = "A4";
                    break;

                case "A4纵向":
                    pInfo.TemplateDirection = Direction.Zong;
                    pInfo.TF = "A4";
                    break;

                case "A3横向":
                    pInfo.TemplateDirection = Direction.Heng;
                    pInfo.TF = "A3";
                    break;

                case "A3纵向":
                    pInfo.TemplateDirection = Direction.Zong;
                    pInfo.TF = "A3";
                    break;
            }
            if (EditTask.TaskName == "采伐")
            {
                pInfo.TemplateBusiness = BusinessType.CaiFaDC;
            }
            else if (EditTask.TaskName == "造林")
            {
                pInfo.TemplateBusiness = BusinessType.ZaoLinDC;
            }
            else if (EditTask.TaskName == "征占用")
            {
                pInfo.TemplateBusiness = BusinessType.ZZDC;
            }
            Cartography.Template.TemplateInfo.CurrentTemplateInfo = pInfo;
            manager.TemplateCarto(base.PageLayoutControlEdit.Object as IPageLayoutControl3, pInfo);
            this.SetPageLayoutValues();
        }

        private void barButtonItemExit_ItemClick(object sender, ItemClickEventArgs e)
        {
            base.Close();
        }

        private void barButtonItemExportImage_ItemClick(object sender, ItemClickEventArgs e)
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
            DevImageExport export = new DevImageExport
            {
                ActiveView = activeView
            };
            export.ShowDialog();
            export.Dispose();
            export = null;
        }

        private void barButtonItemFullMap_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (this.m_CountyFeature != null)
            {
                this.ZoomToFeature(base.MapControlEdit.Map, this.m_CountyFeature);
            }
        }

        /// <summary>
        /// 统计--火灾统计表：有误
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItemReportHZ_ItemClick(object sender, ItemClickEventArgs e)
        {
            ReportEntry entry = new ReportEntry();
            FindMidFromTable_HZ midLyr = new FindMidFromTable_HZ();
            midLyr.DataTable = GetFireTable();
            ReportParamter pReportParamter = new ReportParamter
            {
                TaskID = EditTask.TaskID.ToString(),
                SysType = Report.SystemType.ZYGL,
                TaskName = "火灾",
                FindFromTable = midLyr
            };
            entry.Show(pReportParamter);
        }
        private ITable GetFireTable()
        {
            string name = UtilFactory.GetConfigOpt().GetConfigValue2("Fire", "FireTable");

            if (mFeatureWorkspace == null)
            {
                return null;
            }
            ITable table = null;
            try
            {
                table = mFeatureWorkspace.OpenTable(name);
            }
            catch
            {
                return null;
            }
            return table;
        }
        private void barButtonItemHZInfoTable_ItemClick(object sender, ItemClickEventArgs e)
        {
            //得到火灾表

            ReportEntry entry = new ReportEntry();
            ReportParamter pReportParamter = new ReportParamter
            {
                Theme = StatisticsTheme.SF,
                TaskID = EditTask.TaskID.ToString(),
                TaskName = "火灾",
                Year = EditTask.TaskYear,
                SysType = Report.SystemType.ZYGL

            };
            List<string> list = new List<string> { "4" };
            pReportParamter.IDs = list;
            entry.ShowRegister(pReportParamter);
        }

        /// <summary>
        /// 查看的响应事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                    this.userControlLocation.PageLayoutControl = base.PageLayoutControlEdit.Object as IPageLayoutControl3;
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
            IFrameProperties properties = (IFrameProperties)frame;
            DevFrame frame2 = new DevFrame(pageLayoutControlEdit.ActiveView);
            if (((properties.Border != null) || (properties.Background != null)) || (properties.Shadow != null))
            {
                OperatorSelect select = new OperatorSelect
                {
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
                    OperatorSelect select = new OperatorSelect
                    {
                        Tip = "当前焦点图已存在公里网，编辑或删除?"
                    };
                    select.ShowDialog();
                    if (select.DialogResult == DialogResult.Yes)
                    {
                        grid = new DevGrid(pageLayoutControlEdit.ActiveView)
                        {
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

        /// <summary>
        /// 制图--图例的响应事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItemMapLegend_ItemClick(object sender, ItemClickEventArgs e)
        {
            AxPageLayoutControl pageLayoutControlEdit = base.PageLayoutControlEdit;
            new DevLegend { PageLayoutControl = pageLayoutControlEdit.Object as IPageLayoutControl }.ShowDialog();

        }

        /// <summary>
        /// 制图--指北针响应事件时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItemMapNorthArrow_ItemClick(object sender, ItemClickEventArgs e)
        {
            AxPageLayoutControl pageLayoutControlEdit = base.PageLayoutControlEdit;
            ////new DevNorthArrowSelector { ActiveView = pageLayoutControlEdit.PageLayout as IActiveView }.ShowDialog();
            new DevNorthArrowSelector { ActiveView = pageLayoutControlEdit.PageLayout as IActiveView, PageLayoutControl = pageLayoutControlEdit.Object as IPageLayoutControl }.ShowDialog();

        }

        /// <summary>
        /// 制图--比例尺：响应事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItemMapScaleBar_ItemClick(object sender, ItemClickEventArgs e)
        {
            AxPageLayoutControl pageLayoutControlEdit = base.PageLayoutControlEdit;
            new DevScaleBar { ActiveView = pageLayoutControlEdit.PageLayout as IActiveView }.ShowDialog();
        }

        private void barButtonItemMapSet_ItemClick(object sender, ItemClickEventArgs e)
        {
            new MapSet(base.PageLayoutControlEdit.Object as IPageLayoutControl3).ShowDialog();
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

        /// <summary>
        /// “制图--文本”的响应事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItemMapText_ItemClick(object sender, ItemClickEventArgs e)
        {
            AxPageLayoutControl pageLayoutControlEdit = base.PageLayoutControlEdit;
            new DevText { ActiveView = pageLayoutControlEdit.ActiveView, PageLayoutControl = pageLayoutControlEdit.Object as IPageLayoutControl }.ShowDialog();
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

        /// <summary>
        /// 查询--地名查找
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        private void barButtonItemPrint_ItemClick(object sender, ItemClickEventArgs e)
        {
            IPageLayoutControl3 control2 = base.PageLayoutControlEdit.Object as IPageLayoutControl3;
            IActiveView activeView = null;
            if (base.xtraTabMain.SelectedTabPageIndex == 0)
            {
                activeView = base.MapControlEdit.ActiveView;
            }
            else
            {
                activeView = base.PageLayoutControlEdit.ActiveView;
            }
            ClsPrint print = new ClsPrint
            {
                Document = PrintController.PrintDocument,
                PageLayoutControl = control2,
                ActiveView = activeView
            };
            print.Print();
            print.Dispose();
            print = null;
        }

        private void barButtonItemPrintPreview_ItemClick(object sender, ItemClickEventArgs e)
        {
            IPageLayoutControl3 control2 = base.PageLayoutControlEdit.Object as IPageLayoutControl3;
            IActiveView activeView = null;
            if (base.xtraTabMain.SelectedTabPageIndex == 0)
            {
                activeView = base.MapControlEdit.ActiveView;
            }
            else
            {
                activeView = base.PageLayoutControlEdit.ActiveView;
            }
            new ClsPrintView
            {
                PrintPreViewWindow = { Owner = this },
                PageLayoutControl = control2,
                ActiveView = activeView,
                Document = PrintController.PrintDocument
            }.PreView();
        }

        private void barButtonItemPrintSet_ItemClick(object sender, ItemClickEventArgs e)
        {
            new PrintSetup().ShowDialog(PrintController.PrintDocument, base.PageLayoutControlEdit.Object as IPageLayoutControl3);
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
                else if (this.mEditKind != "林业工程")
                {
                    if (this.mEditKind.Contains("征占用"))
                    {
                        this.userControlQueryZZY21.Dock = DockStyle.Fill;
                        this.userControlQueryZZY21.Visible = true;
                        this.userControlQueryZZY21.BringToFront();
                        this.userControlQueryZZY21.InitialValue(base.MapControlEdit.Object, this.mEditKind, "ZZY");
                        base.xtraTabToolbox.SelectedTabPage = this.xtraTabPageKind;
                    }
                    else if (this.mEditKind.Contains("火灾"))
                    {
                        this.userControlQueryHZ21.Dock = DockStyle.Fill;
                        this.userControlQueryHZ21.Visible = true;
                        this.userControlQueryHZ21.BringToFront();
                        this.userControlQueryHZ21.InitialValue(base.MapControlEdit.Object, this.mEditKind, "Fire");
                        this.userControlQueryHZ21.labelLocation.Text = "      " + this.mEditKind + "类型查询";
                        base.xtraTabToolbox.SelectedTabPage = this.xtraTabPageKind;
                    }
                    else if (this.mEditKind.Contains("自然灾害"))
                    {
                        this.userControlQueryCF21.Visible = true;
                        this.userControlQueryCF21.BringToFront();
                        this.userControlQueryCF21.InitialValue(base.MapControlEdit.Object, "灾害", "ZRZH");
                        this.userControlQueryCF21.labelLocation.Text = "      " + this.mEditKind + "类型查询";
                        base.xtraTabToolbox.SelectedTabPage = this.xtraTabPageKind;
                    }
                    else if (this.mEditKind.Contains("林业案件"))
                    {
                        this.userControlQueryCF21.Visible = true;
                        this.userControlQueryCF21.BringToFront();
                        this.userControlQueryCF21.InitialValue(base.MapControlEdit.Object, "案件", "AnJian");
                        this.userControlQueryCF21.labelLocation.Text = "      " + this.mEditKind + "类型查询";
                        base.xtraTabToolbox.SelectedTabPage = this.xtraTabPageKind;
                    }
                    else if (this.mEditKind.Contains("小班"))
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
        }

        private void barButtonItemQueryKindAJ_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.xtraTabPageKind.PageVisible = this.barButtonItemQueryKindAJ.Down;
            if (this.barButtonItemQueryKindAJ.Down)
            {
                this.userControlQueryCF21.Visible = true;
                this.userControlQueryCF21.BringToFront();
                this.userControlQueryCF21.InitialValue(base.MapControlEdit.Object, "案件", "AnJian");
                this.userControlQueryCF21.labelLocation.Text = "      案件专题类型查询";
                base.xtraTabToolbox.SelectedTabPage = this.xtraTabPageKind;
                this.barButtonItemQueryKindZL.Down = false;
                this.barButtonItemQueryKindCF.Down = false;
                this.barButtonItemQueryKindHZ.Down = false;
                this.barButtonItemQueryKindZH.Down = false;
                this.barButtonItemQueryKindZZY.Down = false;
                this.barButtonItemQueryKindXB.Down = false;
                this.barButtonItemQueryKindLDBH.Down = false;
            }
        }

        /// <summary>
        /// “采伐查询”的响应事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItemQueryKindCF_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.xtraTabPageKind.PageVisible = this.barButtonItemQueryKindCF.Down;
            if (this.barButtonItemQueryKindCF.Down)
            {
                this.userControlQueryCF21.Visible = true;
                this.userControlQueryCF21.BringToFront();
                this.userControlQueryCF21.InitialValue(base.MapControlEdit.Object, "采伐", "CaiFa");
                this.userControlQueryCF21.labelLocation.Text = "      采伐专题类型查询";
                base.xtraTabToolbox.SelectedTabPage = this.xtraTabPageKind;
                this.barButtonItemQueryKindZL.Down = false;
                this.barButtonItemQueryKindHZ.Down = false;
                this.barButtonItemQueryKindZH.Down = false;
                this.barButtonItemQueryKindAJ.Down = false;
                this.barButtonItemQueryKindZZY.Down = false;
                this.barButtonItemQueryKindXB.Down = false;
                this.barButtonItemQueryKindLDBH.Down = false;
            }
        }

        private void barButtonItemQueryKindHZ_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.xtraTabPageKind.PageVisible = this.barButtonItemQueryKindHZ.Down;
            if (this.barButtonItemQueryKindHZ.Down)
            {
                this.userControlQueryHZ21.Visible = true;
                this.userControlQueryHZ21.BringToFront();
                this.userControlQueryHZ21.InitialValue(base.MapControlEdit.Object, "火灾", "Fire");
                base.xtraTabToolbox.SelectedTabPage = this.xtraTabPageKind;
                this.barButtonItemQueryKindZL.Down = false;
                this.barButtonItemQueryKindCF.Down = false;
                this.barButtonItemQueryKindZH.Down = false;
                this.barButtonItemQueryKindAJ.Down = false;
                this.barButtonItemQueryKindZZY.Down = false;
                this.barButtonItemQueryKindXB.Down = false;
                this.barButtonItemQueryKindLDBH.Down = false;
            }
        }

        /// <summary>
        /// “林地查询”的响应事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItemQueryKindLDBH_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.xtraTabPageKind.PageVisible = this.barButtonItemQueryKindLDBH.Down;
            if (this.barButtonItemQueryKindLDBH.Down)
            {
                this.userControlQueryLDBH1.Visible = true;
                this.userControlQueryLDBH1.BringToFront();
                this.userControlQueryLDBH1.InitialValue(base.MapControlEdit.Object, this.mEditLayer);
                this.userControlQueryLDBH1.Dock = DockStyle.Fill;
                base.xtraTabToolbox.SelectedTabPage = this.xtraTabPageKind;
                this.barButtonItemQueryKindZL.Down = false;
                this.barButtonItemQueryKindCF.Down = false;
                this.barButtonItemQueryKindHZ.Down = false;
                this.barButtonItemQueryKindZH.Down = false;
                this.barButtonItemQueryKindAJ.Down = false;
                this.barButtonItemQueryKindZZY.Down = false;
            }
        }

        /// <summary>
        /// “小班查询”的响应事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItemQueryKindXB_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.xtraTabPageKind.PageVisible = this.barButtonItemQueryKindXB.Down;
            if (this.barButtonItemQueryKindXB.Down)
            {
                this.userControlQueryXB21.Visible = true;
                this.userControlQueryXB21.BringToFront();
                this.userControlQueryXB21.InitialValue(base.MapControlEdit.Object, this.mEditLayer);
                if (this.mEditKind.Contains("年度"))
                {
                    this.userControlQueryXB21.labelLocation.Text = "      小班类型查询";
                }
                this.userControlQueryXB21.Dock = DockStyle.Fill;
                base.xtraTabToolbox.SelectedTabPage = this.xtraTabPageKind;
                this.barButtonItemQueryKindZL.Down = false;
                this.barButtonItemQueryKindCF.Down = false;
                this.barButtonItemQueryKindHZ.Down = false;
                this.barButtonItemQueryKindZH.Down = false;
                this.barButtonItemQueryKindAJ.Down = false;
                this.barButtonItemQueryKindZZY.Down = false;
            }
        }

        private void barButtonItemQueryKindZH_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.xtraTabPageKind.PageVisible = this.barButtonItemQueryKindZH.Down;
            if (this.barButtonItemQueryKindZH.Down)
            {
                this.userControlQueryCF21.Visible = true;
                this.userControlQueryCF21.BringToFront();
                this.userControlQueryCF21.InitialValue(base.MapControlEdit.Object, "灾害", "ZRZH");
                this.userControlQueryCF21.labelLocation.Text = "      灾害专题类型查询";
                base.xtraTabToolbox.SelectedTabPage = this.xtraTabPageKind;
                this.barButtonItemQueryKindZL.Down = false;
                this.barButtonItemQueryKindCF.Down = false;
                this.barButtonItemQueryKindHZ.Down = false;
                this.barButtonItemQueryKindAJ.Down = false;
                this.barButtonItemQueryKindZZY.Down = false;
                this.barButtonItemQueryKindXB.Down = false;
                this.barButtonItemQueryKindLDBH.Down = false;
            }
        }

        /// <summary>
        /// 造林查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItemQueryKindZL_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.xtraTabPageKind.PageVisible = this.barButtonItemQueryKindZL.Down;
            if (this.barButtonItemQueryKindZL.Down)
            {
                this.userControlQueryCF21.Visible = true;
                this.userControlQueryCF21.BringToFront();
                this.userControlQueryCF21.InitialValue(base.MapControlEdit.Object, "造林", "ZaoLin");
                this.userControlQueryCF21.labelLocation.Text = "      造林专题类型查询";
                base.xtraTabToolbox.SelectedTabPage = this.xtraTabPageKind;
                this.barButtonItemQueryKindCF.Down = false;
                this.barButtonItemQueryKindHZ.Down = false;
                this.barButtonItemQueryKindZH.Down = false;
                this.barButtonItemQueryKindAJ.Down = false;
                this.barButtonItemQueryKindZZY.Down = false;
                this.barButtonItemQueryKindXB.Down = false;
                this.barButtonItemQueryKindLDBH.Down = false;
            }
        }

        /// <summary>
        /// 征占用查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItemQueryKindZZY_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.xtraTabPageKind.PageVisible = this.barButtonItemQueryKindZZY.Down;
            if (this.barButtonItemQueryKindZZY.Down)
            {
                this.userControlQueryZZY21.Visible = true;
                this.userControlQueryZZY21.BringToFront();
                this.userControlQueryZZY21.InitialValue(base.MapControlEdit.Object, "征占用", "ZZY");
                base.xtraTabToolbox.SelectedTabPage = this.xtraTabPageKind;
                this.barButtonItemQueryKindZL.Down = false;
                this.barButtonItemQueryKindCF.Down = false;
                this.barButtonItemQueryKindHZ.Down = false;
                this.barButtonItemQueryKindZH.Down = false;
                this.barButtonItemQueryKindAJ.Down = false;
                this.barButtonItemQueryKindXB.Down = false;
                this.barButtonItemQueryKindLDBH.Down = false;
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
                if (this.mEditLayer == null)
                {
                    this.mEditLayer = EditTask.EditLayer;
                }
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
                    else if (this.mEditKind != "林业工程")
                    {
                        if (this.mEditKind.Contains("征占用"))
                        {
                            this.userControlQueryZZY1.Visible = true;
                            this.userControlQueryZZY1.BringToFront();
                            this.userControlQueryZZY1.InitialValue(base.MapControlEdit.Object, this.mEditLayer, base.MapControlEdit.Map, this.userControlQueryResult1, base.dockPanelBottom);
                            base.xtraTabToolbox.SelectedTabPage = base.xtraTabPageQuery;
                        }
                        else if (this.mEditKind.Contains("火灾"))
                        {
                            this.userControlQueryHZ1.Visible = true;
                            this.userControlQueryHZ1.BringToFront();
                            this.userControlQueryHZ1.InitialValue(base.MapControlEdit.Object, this.mEditLayer, base.MapControlEdit.Map, this.userControlQueryResult1, base.dockPanelBottom);
                            base.xtraTabToolbox.SelectedTabPage = base.xtraTabPageQuery;
                        }
                        else if (this.mEditKind.Contains("自然灾害"))
                        {
                            this.userControlQueryZH1.Visible = true;
                            this.userControlQueryZH1.BringToFront();
                            this.userControlQueryZH1.InitialValue(base.MapControlEdit.Object, this.mEditLayer, base.MapControlEdit.Map, this.userControlQueryResult1, base.dockPanelBottom);
                            base.xtraTabToolbox.SelectedTabPage = base.xtraTabPageQuery;
                        }
                        else if (this.mEditKind.Contains("案件"))
                        {
                            this.userControlQueryAJ1.Visible = true;
                            this.userControlQueryAJ1.BringToFront();
                            this.userControlQueryAJ1.InitialValue(base.MapControlEdit.Object, this.mEditLayer, base.MapControlEdit.Map, this.userControlQueryResult1, base.dockPanelBottom);
                            base.xtraTabToolbox.SelectedTabPage = base.xtraTabPageQuery;
                        }
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// 统计--林业案件统计表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItemReportAJ_ItemClick(object sender, ItemClickEventArgs e)
        {
            ReportEntry entry = new ReportEntry();
            FindMidFromLayer_AJ midLyr = new FindMidFromLayer_AJ();
            string str = UtilFactory.GetConfigOpt().GetConfigValue("AnJianLayer") + "_" + EditTask.TaskYear;
            midLyr.DataClass = GetFeatureClass(str);
            ReportParamter pReportParamter = new ReportParamter
            {
                TaskID = EditTask.TaskID.ToString(),
                SysType = Report.SystemType.ZYGL,
                FindFromLayer_AJ = midLyr,
                Year = EditTask.TaskYear,
                TaskName = "林业案件"
            };
            entry.Show(pReportParamter);
        }

        /// <summary>
        /// 统计--公益林统计表：响应事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItemReportGYL_ItemClick(object sender, ItemClickEventArgs e)
        {
            new FormGylStat(UtilFactory.GetConfigOpt().GetConfigValue("XBLayer1") + "_" + EditTask.TaskYear).ShowDialog();
        }


        /// <summary>
        /// 统计--森林资源数据年度更新统计表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItemReportLD_ItemClick(object sender, ItemClickEventArgs e)
        {
            string connectionString = "";// UtilFactory.GetDBAccess(UtilFactory.GetConfigOpt().GetConfigValue2("DataBase", "DBKey")).ConnectionString;
            string configValue = UtilFactory.GetConfigOpt().GetConfigValue("InitialCatalog");
            new GeoDataIE.ExportZYBHTable().Export(configValue);
        }

        /// <summary>
        /// 统计--自然灾害统计表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItemReportZH_ItemClick(object sender, ItemClickEventArgs e)
        {
            ReportEntry entry = new ReportEntry();
            string str = UtilFactory.GetConfigOpt().GetConfigValue("ZRZHLayer") + "_" + EditTask.TaskYear;
            FindMidFromLayer_ZH midLyr = new FindMidFromLayer_ZH();
            midLyr.DataClass = GetFeatureClass(str);
            ReportParamter pReportParamter = new ReportParamter
            {
                TaskID = EditTask.TaskID.ToString(),
                SysType = Report.SystemType.ZYGL,
                FindFromLayer_ZH = midLyr,
                Year = EditTask.TaskYear,
                TaskName = "自然灾害"
            };
            entry.Show(pReportParamter);
        }
        private IFeatureClass GetFeatureClass(string layerName)
        {

            if (mFeatureWorkspace == null)
            {
                return null;
            }
            IFeatureClass table = null;
            try
            {
                table = mFeatureWorkspace.OpenFeatureClass(layerName);
            }
            catch
            {
                return null;
            }
            return table;
        }

        /// <summary>
        /// 统计--造林统计表的响应事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItemReportZL_ItemClick(object sender, ItemClickEventArgs e)
        {
            dlgTJMain main = new dlgTJMain();
            string str = UtilFactory.GetConfigOpt().GetConfigValue("ZaoLinLayer") + "_" + EditTask.TaskYear;
            FindMidFromLayer_ZL midLyr = new FindMidFromLayer_ZL();
            midLyr.DataClass = GetFeatureClass(str);
            main.FindFromLayer = midLyr;
            main.ZLTableName = str;
            main.ShowDialog();
        }

        /// <summary>
        /// 统计--调查成果统计表：响应事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItemReportZZY_ItemClick(object sender, ItemClickEventArgs e)
        {
            dlgLDZZTJ gldzztj = new dlgLDZZTJ();
            ///查询的征占用图层
            string str = UtilFactory.GetConfigOpt().GetConfigValue("ZZYLayer") + "_" + EditTask.TaskYear;
            FindMidFromLayer_ZZ midLyr = new FindMidFromLayer_ZZ();
            midLyr.DataClass = GetFeatureClass(str);
            gldzztj.FindFromLayer = midLyr;
            gldzztj.ZZYTableName = str;
            gldzztj.ShowDialog();
        }

        /// <summary>
        /// 统计--国家统计报表：响应事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItemReportZZY2_ItemClick(object sender, ItemClickEventArgs e)
        {//调查的仍然是征占用图层
            string str = UtilFactory.GetConfigOpt().GetConfigValue("ZZYLayer") + "_" + EditTask.TaskYear;
            FindMidFromLayer_ZZ midLyr = new FindMidFromLayer_ZZ();
            midLyr.DataClass = GetFeatureClass(str);
            FormLdzzyStat ldzzy = new FormLdzzyStat(str);
            ldzzy.FindFromLayer = midLyr;
            ldzzy.ShowDialog();
        }

        /// <summary>
        /// 统计--月统计报表：响应事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItemReportZZY3_ItemClick(object sender, ItemClickEventArgs e)
        {
            new FormLDZZYMonthReport(UtilFactory.GetConfigOpt().GetConfigValue("ZZYLayer") + "_" + EditTask.TaskYear).ShowDialog();
        }

        private void barButtonItemSave_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                IMxdContents pMxdContents = null;
                if ((EditTask.KindCode.Length > 2) && (int.Parse(EditTask.KindCode.Substring(0, 2)) < 8))
                {
                    base.MapControlEdit.Map.Description = EditTask.KindCode.Substring(0, 2) + ",TASK_ID=" + EditTask.TaskID;
                }
                else
                {
                    base.MapControlEdit.Map.Description = EditTask.KindCode.Substring(0, 2);
                }
                AxMapControl mapControlEdit = base.MapControlEdit;
                this.m_controlsSynchronizer2.SetMapOfMapToPagelayout();
                pMxdContents = base.PageLayoutControlEdit.Object as IMxdContents;
                string sFileName = UtilFactory.GetConfigOpt().RootPath + @"Template\查询" + this.mEditKind + ".mxd";
                if (GISFunFactory.CoreFun.SaveMapDocument(pMxdContents, sFileName, true, true, true, true))
                {
                    MessageBox.Show("存储完成！", "保存工作空间");
                }
                else
                {
                    MessageBox.Show("存储失败！", "保存工作空间");
                    return;
                }

                DMM.SavePath(mEditKind);
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "GXFormMainFrame.FormMainEdit", "barButtonItemSave_ItemClick", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
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

        private void barButtonItemSJ_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.barButtonItemDC.Down = false;
            this.barButtonItemZTT.Down = false;
            TemplateCartoManager manager = new TemplateCartoManager();
            Cartography.Template.TemplateInfo pInfo = new Cartography.Template.TemplateInfo();
            switch (this.barEditItem_fx.EditValue.ToString())
            {
                case "A4横向":
                    pInfo.TemplateDirection = Direction.Heng;
                    pInfo.TF = "A4";
                    break;

                case "A4纵向":
                    pInfo.TemplateDirection = Direction.Zong;
                    pInfo.TF = "A4";
                    break;

                case "A3横向":
                    pInfo.TemplateDirection = Direction.Heng;
                    pInfo.TF = "A3";
                    break;

                case "A3纵向":
                    pInfo.TemplateDirection = Direction.Zong;
                    pInfo.TF = "A3";
                    break;
            }
            if (EditTask.TaskName == "采伐")
            {
                pInfo.TemplateBusiness = BusinessType.CaiFaSJ;
            }
            else if (EditTask.TaskName == "造林")
            {
                pInfo.TemplateBusiness = BusinessType.ZaoLinSJ;
            }
            else if (EditTask.TaskName == "征占用")
            {
                pInfo.TemplateBusiness = BusinessType.ZZWZ;
            }
            Cartography.Template.TemplateInfo.CurrentTemplateInfo = pInfo;
            manager.TemplateCarto(base.PageLayoutControlEdit.Object as IPageLayoutControl3, pInfo);
            this.SetPageLayoutValues();
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
        /// <summary>
        /// “小班统计报表”的响应事件
        /// 20170507 jiayp modify repport
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItemStatic_ItemClick(object sender, ItemClickEventArgs e)
        {
            ReportEntry entry = new ReportEntry();
            //得到案件表
            FindMidFromLayer_XB midLyr = new FindMidFromLayer_XB();
            midLyr.DataLayer = mEditLayer;
            ReportParamter pReportParamter = new ReportParamter
            {
                TaskID = EditTask.TaskID.ToString(),
                TaskName = "小班统计",
                Year = EditTask.TaskYear,
                SysType = Report.SystemType.ZYGL,
                FindFromLayer_XB = midLyr
            };
            entry.Show(pReportParamter);
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

        private void barButtonItemZTT_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.barButtonItemSJ.Down = false;
            this.barButtonItemDC.Down = false;
            TemplateCartoManager manager = new TemplateCartoManager();
            Cartography.Template.TemplateInfo pInfo = new Cartography.Template.TemplateInfo();
            switch (this.barEditItem_fx.EditValue.ToString())
            {
                case "A4横向":
                    pInfo.TemplateDirection = Direction.Heng;
                    pInfo.TF = "A4";
                    break;

                case "A4纵向":
                    pInfo.TemplateDirection = Direction.Zong;
                    pInfo.TF = "A4";
                    break;

                case "A3横向":
                    pInfo.TemplateDirection = Direction.Heng;
                    pInfo.TF = "A3";
                    break;

                case "A3纵向":
                    pInfo.TemplateDirection = Direction.Zong;
                    pInfo.TF = "A3";
                    break;
            }
            if (EditTask.TaskName == "采伐")
            {
                pInfo.TemplateBusiness = BusinessType.CaiFaCX;
            }
            else if (EditTask.TaskName == "造林")
            {
                pInfo.TemplateBusiness = BusinessType.ZaoLINCX;
            }
            else if (EditTask.TaskName == "征占用")
            {
                pInfo.TemplateBusiness = BusinessType.ZZCX;
            }
            else if (EditTask.TaskName == "林业案件")
            {
                pInfo.TemplateBusiness = BusinessType.AJCX;
            }
            else if (EditTask.TaskName == "火灾")
            {
                pInfo.TemplateBusiness = BusinessType.HZCX;
            }
            else if (EditTask.TaskName == "自然灾害")
            {
                pInfo.TemplateBusiness = BusinessType.ZHCX;
            }
            else if (EditTask.TaskName == "年度小班")
            {
                pInfo.TemplateBusiness = BusinessType.NDXBCX;
            }
            else if (EditTask.TaskName == "专题")
            {
                pInfo.TemplateBusiness = BusinessType.XBCX;
            }
            Cartography.Template.TemplateInfo.CurrentTemplateInfo = pInfo;
            manager.TemplateCarto(base.PageLayoutControlEdit.Object as IPageLayoutControl3, pInfo);
            this.SetPageLayoutValues();
        }

        private void barEditItem_fx_EditValueChanged(object sender, EventArgs e)
        {
            TemplateCartoManager manager = new TemplateCartoManager();
            Cartography.Template.TemplateInfo currentTemplateInfo = Cartography.Template.TemplateInfo.CurrentTemplateInfo;
            if (currentTemplateInfo != null)
            {
                string str = this.barEditItem_fx.EditValue.ToString();
                IPageLayoutControl3 control = base.PageLayoutControlEdit.Object as IPageLayoutControl3;
                switch (str)
                {
                    case "A4横向":
                        currentTemplateInfo.TemplateDirection = Direction.Heng;
                        currentTemplateInfo.TF = "A4";
                        PrintController.SetDefaultPrintSet("A4", 2, base.PageLayoutControlEdit.Object as IPageLayoutControl3);
                        break;

                    case "A4纵向":
                        currentTemplateInfo.TemplateDirection = Direction.Zong;
                        currentTemplateInfo.TF = "A4";
                        PrintController.SetDefaultPrintSet("A4", 1, base.PageLayoutControlEdit.Object as IPageLayoutControl3);
                        break;

                    case "A3横向":
                        currentTemplateInfo.TemplateDirection = Direction.Heng;
                        currentTemplateInfo.TF = "A3";
                        PrintController.SetDefaultPrintSet("A3", 2, base.PageLayoutControlEdit.Object as IPageLayoutControl3);
                        break;

                    case "A3纵向":
                        currentTemplateInfo.TemplateDirection = Direction.Zong;
                        currentTemplateInfo.TF = "A3";
                        PrintController.SetDefaultPrintSet("A3", 1, base.PageLayoutControlEdit.Object as IPageLayoutControl3);
                        break;
                }
                manager.TemplateCarto(base.PageLayoutControlEdit.Object as IPageLayoutControl3, currentTemplateInfo);
                this.SetPageLayoutValues();
            }
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
            new TemplateCartoManager().NormalCarto((IPageLayoutControl3)base.PageLayoutControlEdit.Object);
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

        private bool CheckDataSource(string skey)
        {
            try
            {
                string configValue = UtilFactory.GetConfigOpt().GetConfigValue(skey);
                string str2 = UtilFactory.GetConfigOpt().GetConfigValue2("SqlServer", "DataSource");
                string str3 = UtilFactory.GetConfigOpt().GetConfigValue2("SqlServer", "InitialCatalog");
                return (configValue == (str2 + "," + str3));
            }
            catch (Exception)
            {
                return false;
            }
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

        private void dockPanelToolbox_ClosedPanel(object sender, DockPanelEventArgs e)
        {
            base.barButtonItemToolbox.Down = false;
        }

        private void FormMainFrame_Activated(object sender, EventArgs e)
        {
            try
            {
                base.defaultLookAndFeel1.LookAndFeel.SkinName = "Blue";
                if (this.mFirstFlag)
                {
                    base.dockPanelToolbox.Visibility = DockVisibility.Visible;
                    base.dockPanelToolbox.Width = 0x11a;
                    base.dockPanelToolbox.BringToFront();
                    base.xtraTabMain.BringToFront();
                    base.MapControlEdit.BringToFront();
                    base.MapControlEdit.Dock = DockStyle.None;
                    base.MapControlEdit.Left = 1;
                    base.MapControlEdit.Top = 1;
                    base.MapControlEdit.Width = base.xtraTabMain.Width - 2;
                    base.MapControlEdit.Height = base.xtraTabMain.Height - 30;
                    base.MapControlEdit.ShowScrollbars = false;
                    if (this.bDefaultPath && (this.m_CountyFeature != null))
                    {
                        this.ZoomToFeature(base.MapControlEdit.Map, this.m_CountyFeature);
                    }
                    base.MapControlEdit.ActiveView.Refresh();
                    this.mFirstFlag = false;
                }
            }
            catch (Exception)
            {
            }
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

        private void FormMainFrame_Resize(object sender, EventArgs e)
        {
        }

        private string GetDistName(string scode)
        {
            try
            {
                IFeatureWorkspace editWorkspace = EditTask.EditWorkspace;
                string configValue = UtilFactory.GetConfigOpt().GetConfigValue("CountyCodeTableName");
                string str2 = "";
                ITable table = null;
                if (scode.Length == 6)
                {
                    table = editWorkspace.OpenTable(configValue);
                    str2 = UtilFactory.GetConfigOpt().GetConfigValue("CountyCodeTableWhereStr");
                }
                else if (scode.Length == 9)
                {
                    configValue = UtilFactory.GetConfigOpt().GetConfigValue("TownCodeTableName");
                    str2 = UtilFactory.GetConfigOpt().GetConfigValue("TownCodeTableWhereStr");
                    table = editWorkspace.OpenTable(configValue);
                }
                else if (scode.Length == 12)
                {
                    configValue = UtilFactory.GetConfigOpt().GetConfigValue("VillageCodeTableName");
                    str2 = UtilFactory.GetConfigOpt().GetConfigValue("VillageCodeTableWhereStr");
                    table = editWorkspace.OpenTable(configValue);
                }
                if (table != null)
                {
                    int num = table.FindField("ccode");
                    int index = table.FindField("cname");
                    if ((num < 0) || (index < 0))
                    {
                        return "";
                    }
                    IQueryFilter queryFilter = new QueryFilterClass();
                    if (str2 != "")
                    {
                        queryFilter.WhereClause = "ccode='" + scode + "' and " + str2;
                    }
                    else
                    {
                        queryFilter.WhereClause = "ccode='" + scode + "'";
                    }
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

        /// <summary>
        /// 获取视图的显示比例
        /// </summary>
        /// <param name="pMap"></param>
        /// <returns></returns>
        private string GetMapScale(IMap pMap)
        {
            try
            {
                if ((pMap == null) || (pMap.LayerCount == 0))
                {
                    return "0:0";
                }//获取当前视图放入显示比例，用分数显示
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
                ICommand pCommand = null;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainFrameQuery));
            DevExpress.Utils.SuperToolTip superToolTip1 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipItem toolTipItem1 = new DevExpress.Utils.ToolTipItem();
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
            this.barButtonItemAddDRG = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPageGroupQueryComm = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.barButtonItemMapFind = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemMeasure = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemCX = new DevExpress.XtraBars.BarButtonItem();
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
            this.barButtonItemQueryKindZL = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemQueryKindCF = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemQueryKindZZY = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemHZInfoTable = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemQueryKindHZ = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemQueryKindZH = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemQueryKindAJ = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemQueryKindLDBH = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemQueryKindXB = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPageGroupMapView2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroupMapView3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.xtraTabPageMapFind = new DevExpress.XtraTab.XtraTabPage();
            this.userControlMapFind1 = new QueryCommon.UserControlMapFind();
            this.xtraTabPageLocation = new DevExpress.XtraTab.XtraTabPage();
            this.userControlLocation = new QueryCommon.UserControlLocation();
            this.ribbonPageGroupMxt = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.barButtonItemDC = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemSJ = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemZTT = new DevExpress.XtraBars.BarButtonItem();
            this.barEditItem_fx = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemComboBox2 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
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
            this.ribbonPageStatic = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroupCF = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.barButtonItemReportCF1 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemChartCF = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPageGroupZL = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.barButtonItemReportZL = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemChartZL = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPageGroupHZ = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.barButtonItemReportHZ = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemChartHZ = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemReportKind = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPageGroupZH = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.barButtonItemReportZH = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPageGroupAJ = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.barButtonItemReportAJ = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPageGroupZZY = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.barButtonItemReportZZY = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemReportZZY2 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemReportZZY3 = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPageGroupReportXB = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.barButtonItemStatic = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.barButtonReportCustom = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPageGroupGYL = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.barButtonItemReportGYL = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPageGroupLD = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.barButtonItemReportLD = new DevExpress.XtraBars.BarButtonItem();
            this.xtraTabPagePlace = new DevExpress.XtraTab.XtraTabPage();
            this.userControlPlace1 = new QueryCommon.UserControlPlace();
            this.xtraTabPageTFH = new DevExpress.XtraTab.XtraTabPage();
            this.userControlQueryTFH1 = new QueryAnalysic.UserControlQueryTFH();
            this.userControlQueryCF1 = new QueryAnalysic.UserControlQueryCF();
            this.xtraTabPageKind = new DevExpress.XtraTab.XtraTabPage();
            this.userControlQueryLDBH1 = new QueryAnalysic.UserControlQueryLDBH();
            this.userControlQueryZZY21 = new QueryAnalysic.UserControlQueryZZY2();
            this.userControlQueryHZ21 = new QueryAnalysic.UserControlQueryHZ2();
            this.userControlQueryXB21 = new QueryAnalysic.UserControlQueryXB2();
            this.userControlQueryCF21 = new QueryAnalysic.UserControlQueryCF2();
            this.userControlQueryZL1 = new QueryAnalysic.UserControlQueryZL();
            this.userControlQueryHZ1 = new QueryAnalysic.UserControlQueryHZ();
            this.userControlQueryZZY1 = new QueryAnalysic.UserControlQueryZZY();
            this.userControlQueryZH1 = new QueryAnalysic.UserControlQueryZH();
            this.userControlQueryAJ1 = new QueryAnalysic.UserControlQueryAJ();
            this.barButtonItemMapSet = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemExit = new DevExpress.XtraBars.BarButtonItem();
            this.xtraTabPageCX = new DevExpress.XtraTab.XtraTabPage();
            this.userControlSelectByAttributes1 = new GISControlsClass.UserControlSelectByAttributes();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.barStaticItem1 = new DevExpress.XtraBars.BarStaticItem();
            this.barEditItem2 = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemComboBox3 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
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
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox2)).BeginInit();
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
            this.xtraTabPageCX.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // applicationMenu1
            // 
            this.applicationMenu1.ItemLinks.Add(this.barButtonItemOpen, true);
            this.applicationMenu1.ItemLinks.Add(this.barButtonItemExportImage, true);
            this.applicationMenu1.ItemLinks.Add(this.barButtonItemPrintSet, true);
            this.applicationMenu1.ItemLinks.Add(this.barButtonItemPrintPreview);
            this.applicationMenu1.ItemLinks.Add(this.barButtonItemPrint);
            this.applicationMenu1.ItemLinks.Add(this.barButtonItemExit, true);
            // 
            // axTOCControl
            // 
            this.axTOCControl.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axTOCControl.OcxState")));
            this.axTOCControl.Size = new System.Drawing.Size(266, 326);
            // 
            // defaultLookAndFeel1
            // 
            this.defaultLookAndFeel1.LookAndFeel.SkinName = "Blue";
            // 
            // dockPanelBottom
            // 
            this.dockPanelBottom.Location = new System.Drawing.Point(280, 576);
            this.dockPanelBottom.Size = new System.Drawing.Size(1000, 200);
            // 
            // dockPanelBottom_Container
            // 
            this.dockPanelBottom_Container.Controls.Add(this.xtraTabQuery);
            this.dockPanelBottom_Container.Size = new System.Drawing.Size(994, 168);
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
            this.dockPanelToolbox.Size = new System.Drawing.Size(280, 607);
            this.dockPanelToolbox.ClosedPanel += new DevExpress.XtraBars.Docking.DockPanelEventHandler(this.dockPanelToolbox_ClosedPanel);
            // 
            // dockPanelToolbox_Container
            // 
            this.dockPanelToolbox_Container.Size = new System.Drawing.Size(272, 580);
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
            this.imageCollection2.Images.SetKeyName(403, "green_wormhole.png");
            this.imageCollection2.Images.SetKeyName(404, "map.png");
            this.imageCollection2.Images.SetKeyName(405, "table_row_insert.png");
            this.imageCollection2.Images.SetKeyName(406, "kview.png");
            this.imageCollection2.Images.SetKeyName(407, "home_page.png");
            this.imageCollection2.Images.SetKeyName(408, "interface_preferences.png");
            this.imageCollection2.Images.SetKeyName(409, "sitemap_color.png");
            this.imageCollection2.Images.SetKeyName(410, "small_tiles.png");
            this.imageCollection2.Images.SetKeyName(411, "data_sort.png");
            this.imageCollection2.Images.SetKeyName(412, "application-msword.png");
            this.imageCollection2.Images.SetKeyName(413, "text-calendar.png");
            this.imageCollection2.Images.SetKeyName(414, "text-enriched.png");
            this.imageCollection2.Images.SetKeyName(415, "application-vnd_sun_xml_calc_template.png");
            this.imageCollection2.Images.SetKeyName(416, "stock_new-text.png");
            this.imageCollection2.Images.SetKeyName(417, "sunbird.png");
            this.imageCollection2.Images.SetKeyName(418, "message-news.png");
            this.imageCollection2.Images.SetKeyName(419, "gnome-power-statistics.png");
            this.imageCollection2.Images.SetKeyName(420, "openofficeorg-calc.png");
            this.imageCollection2.Images.SetKeyName(421, "kchart.png");
            // 
            // MapControlEdit
            // 
            this.MapControlEdit.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("MapControlEdit.OcxState")));
            this.MapControlEdit.Size = new System.Drawing.Size(994, 576);
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
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barButtonItemOpen,
            this.barButtonItemExportImage,
            this.barButtonItemPrintSet,
            this.barButtonItemPrintPreview,
            this.barButtonItemPrint,
            this.barButtonItemExit,
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
            this.barButtonItemAddDRG,
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
            this.barButtonItemDC,
            this.barButtonItemSJ,
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
            this.barButtonItemQueryKindZL,
            this.barButtonItemQueryKindCF,
            this.barButtonItemQueryKindXB,
            this.barButtonItemReportHZ,
            this.barButtonItemChartHZ,
            this.barButtonItemReportKind,
            this.barButtonItemReportZZY,
            this.barButtonItemHZInfoTable,
            this.barButtonItemReportZH,
            this.barButtonItemReportAJ,
            this.barButtonItemReportZZY2,
            this.barButtonItemQueryKindHZ,
            this.barButtonItemQueryKindZH,
            this.barButtonItemQueryKindAJ,
            this.barButtonItemQueryKindZZY,
            this.barEditItem_fx,
            this.barButtonItemZTT,
            this.barButtonItemMapSet,
            this.barButtonItemReportLD,
            this.barButtonItemQueryKindLDBH,
            this.barButtonItemReportGYL,
            this.barButtonItemReportZZY3,
            this.barButtonItemCX,
            this.barButtonReportCustom,
            this.barStaticItem1,
            this.barEditItem2});
            this.ribbon.MaxItemId = 270;
            this.ribbon.PageHeaderItemLinks.Add(this.barButtonItemSave);
            this.ribbon.PageHeaderItemLinks.Add(this.barButtonItemExportImage);
            this.ribbon.PageHeaderItemLinks.Add(this.barButtonItemPrint);
            this.ribbon.PageHeaderItemLinks.Add(this.barButtonItemPrintPreview);
            this.ribbon.PageHeaderItemLinks.Add(this.barButtonItemMapSet);
            this.ribbon.PageHeaderItemLinks.Add(this.barButtonItemPrintSet);
            this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPageStatic});
            this.ribbon.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1,
            this.repositoryItemComboBox2,
            this.repositoryItemComboBox3});
            this.ribbon.Size = new System.Drawing.Size(1280, 149);
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
            // 
            // ribbonPageQuery
            // 
            this.ribbonPageQuery.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroupQueryComm,
            this.ribbonPageGroupQuery,
            this.ribbonPageGroupQuery2,
            this.ribbonPageGroupMapView3,
            this.ribbonPageGroup2});
            // 
            // ribbonPageTransfer
            // 
            this.ribbonPageTransfer.Visible = false;
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 756);
            this.ribbonStatusBar.Size = new System.Drawing.Size(1280, 31);
            // 
            // tabPageMapContol
            // 
            this.tabPageMapContol.Size = new System.Drawing.Size(994, 576);
            // 
            // tabPagePagelayoutContol
            // 
            this.tabPagePagelayoutContol.Size = new System.Drawing.Size(1010, 556);
            // 
            // xtraTabMain
            // 
            this.xtraTabMain.Location = new System.Drawing.Point(280, 149);
            this.xtraTabMain.SelectedTabPage = this.tabPageMapContol;
            this.xtraTabMain.Size = new System.Drawing.Size(1000, 607);
            this.xtraTabMain.Resize += new System.EventHandler(this.xtraTabMain_Resize);
            // 
            // xtraTabPageIdentify
            // 
            this.xtraTabPageIdentify.Controls.Add(this.userControlInfo);
            // 
            // xtraTabPageQuery
            // 
            this.xtraTabPageQuery.Controls.Add(this.userControlQueryAJ1);
            this.xtraTabPageQuery.Controls.Add(this.userControlQueryZH1);
            this.xtraTabPageQuery.Controls.Add(this.userControlQueryZZY1);
            this.xtraTabPageQuery.Controls.Add(this.userControlQueryHZ1);
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
            this.xtraTabPageTOC.Size = new System.Drawing.Size(266, 551);
            this.xtraTabPageTOC.Controls.SetChildIndex(this.userControlOverView, 0);
            this.xtraTabPageTOC.Controls.SetChildIndex(this.splitterControl1, 0);
            this.xtraTabPageTOC.Controls.SetChildIndex(this.userControlLayerControl, 0);
            this.xtraTabPageTOC.Controls.SetChildIndex(this.axTOCControl, 0);
            // 
            // xtraTabToolbox
            // 
            this.xtraTabToolbox.SelectedTabPage = this.xtraTabPageTOC;
            this.xtraTabToolbox.Size = new System.Drawing.Size(272, 580);
            this.xtraTabToolbox.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPageSelect,
            this.xtraTabPageMapFind,
            this.xtraTabPageLocation,
            this.xtraTabPageXBchange,
            this.xtraTabPageAddRasterlayer,
            this.xtraTabPagePlace,
            this.xtraTabPageTFH,
            this.xtraTabPageKind,
            this.xtraTabPageCX});
            this.xtraTabToolbox.Controls.SetChildIndex(this.xtraTabPageCX, 0);
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
            this.splitterControl1.Location = new System.Drawing.Point(0, 326);
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
            this.barButtonItemFullMap.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemFullMap_ItemClick);
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
            this.barButtonItemBack.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText;
            // 
            // barButtonItemForward
            // 
            this.barButtonItemForward.Caption = "向前";
            this.barButtonItemForward.Id = 11;
            this.barButtonItemForward.ImageIndex = 140;
            this.barButtonItemForward.LargeImageIndex = 45;
            this.barButtonItemForward.Name = "barButtonItemForward";
            this.barButtonItemForward.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText;
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
            this.userControlOverView.Location = new System.Drawing.Point(0, 331);
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
            this.barButtonItemTOC.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText)));
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
            this.barButtonItemOverView.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
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
            this.barButtonItemTOC2.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.barButtonItemTOC2.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemTOC2_ItemClick);
            // 
            // barButtonItemAddDRG
            // 
            this.barButtonItemAddDRG.Caption = "底图";
            this.barButtonItemAddDRG.Description = "加载工作底图";
            this.barButtonItemAddDRG.Id = 26;
            this.barButtonItemAddDRG.ImageIndex = 67;
            this.barButtonItemAddDRG.LargeImageIndex = 214;
            this.barButtonItemAddDRG.Name = "barButtonItemAddDRG";
            this.barButtonItemAddDRG.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // ribbonPageGroupQueryComm
            // 
            this.ribbonPageGroupQueryComm.AllowMinimize = false;
            this.ribbonPageGroupQueryComm.ItemLinks.Add(this.barButtonItemIdentify);
            this.ribbonPageGroupQueryComm.ItemLinks.Add(this.barButtonItemMapFind);
            this.ribbonPageGroupQueryComm.ItemLinks.Add(this.barButtonItemMeasure);
            this.ribbonPageGroupQueryComm.ItemLinks.Add(this.barButtonItemCX);
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
            // barButtonItemCX
            // 
            this.barButtonItemCX.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            this.barButtonItemCX.Caption = "自定义查询";
            this.barButtonItemCX.Glyph = ((System.Drawing.Image)(resources.GetObject("barButtonItemCX.Glyph")));
            this.barButtonItemCX.Id = 193;
            this.barButtonItemCX.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barButtonItemCX.LargeGlyph")));
            this.barButtonItemCX.Name = "barButtonItemCX";
            this.barButtonItemCX.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemCX_ItemClick);
            // 
            // barButtonItemAddLayer
            // 
            this.barButtonItemAddLayer.Caption = "添加";
            this.barButtonItemAddLayer.Description = "添加图层";
            this.barButtonItemAddLayer.Id = 27;
            this.barButtonItemAddLayer.ImageIndex = 41;
            this.barButtonItemAddLayer.LargeImageIndex = 216;
            this.barButtonItemAddLayer.Name = "barButtonItemAddLayer";
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
            // 
            // barButtonItemExportImage
            // 
            this.barButtonItemExportImage.Caption = "地图输出";
            this.barButtonItemExportImage.Description = "地图输出";
            this.barButtonItemExportImage.Id = 31;
            this.barButtonItemExportImage.ImageIndex = 88;
            this.barButtonItemExportImage.LargeImageIndex = 376;
            this.barButtonItemExportImage.Name = "barButtonItemExportImage";
            // 
            // barButtonItemPrintPreview
            // 
            this.barButtonItemPrintPreview.Caption = "打印预览";
            this.barButtonItemPrintPreview.Id = 32;
            this.barButtonItemPrintPreview.ImageIndex = 297;
            this.barButtonItemPrintPreview.LargeImageIndex = 53;
            this.barButtonItemPrintPreview.Name = "barButtonItemPrintPreview";
            // 
            // barButtonItemPrintSet
            // 
            this.barButtonItemPrintSet.Caption = "打印设置";
            this.barButtonItemPrintSet.Id = 33;
            this.barButtonItemPrintSet.ImageIndex = 182;
            this.barButtonItemPrintSet.LargeImageIndex = 164;
            this.barButtonItemPrintSet.Name = "barButtonItemPrintSet";
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
            this.ribbonPageGroupMapView.ItemLinks.Add(this.barButtonItemAddDRG);
            this.ribbonPageGroupMapView.ItemLinks.Add(this.barButtonItemSelectFeature, true);
            this.ribbonPageGroupMapView.ItemLinks.Add(this.barButtonItemClearSelectFeature);
            this.ribbonPageGroupMapView.ItemLinks.Add(this.barButtonItemSelectLayerSet, true);
            this.ribbonPageGroupMapView.ItemLinks.Add(this.barButtonItemSelectedFeaturesReport);
            this.ribbonPageGroupMapView.ItemLinks.Add(this.barButtonItemAddDRG);
            this.ribbonPageGroupMapView.ItemLinks.Add(this.barButtonItemAddDRG);
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
            this.barButtonItemQueryYear.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
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
            this.xtraTabPageAttribute.Size = new System.Drawing.Size(388, 561);
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
            this.userControlAttrEdit1.Size = new System.Drawing.Size(388, 561);
            this.userControlAttrEdit1.TabIndex = 0;
            // 
            // xtraTabPageLogicCheck
            // 
            this.xtraTabPageLogicCheck.Controls.Add(this.userControlAttriCheck1);
            this.xtraTabPageLogicCheck.Name = "xtraTabPageLogicCheck";
            this.xtraTabPageLogicCheck.PageVisible = false;
            this.xtraTabPageLogicCheck.Size = new System.Drawing.Size(388, 561);
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
            this.userControlAttriCheck1.Size = new System.Drawing.Size(388, 561);
            this.userControlAttriCheck1.TabIndex = 1;
            // 
            // xtraTabPageInputData
            // 
            this.xtraTabPageInputData.Controls.Add(this.userControlInputData);
            this.xtraTabPageInputData.Name = "xtraTabPageInputData";
            this.xtraTabPageInputData.PageVisible = false;
            this.xtraTabPageInputData.Size = new System.Drawing.Size(388, 561);
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
            this.userControlInputData.Size = new System.Drawing.Size(388, 561);
            this.userControlInputData.TabIndex = 6;
            // 
            // xtraTabPageUpdate
            // 
            this.xtraTabPageUpdate.Controls.Add(this.userControlUpdate1);
            this.xtraTabPageUpdate.Name = "xtraTabPageUpdate";
            this.xtraTabPageUpdate.PageVisible = false;
            this.xtraTabPageUpdate.Size = new System.Drawing.Size(388, 561);
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
            this.userControlUpdate1.Size = new System.Drawing.Size(388, 561);
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
            this.userControlLayerControl.Size = new System.Drawing.Size(266, 326);
            this.userControlLayerControl.TabIndex = 4;
            this.userControlLayerControl.Visible = false;
            // 
            // xtraTabPageSelect
            // 
            this.xtraTabPageSelect.Controls.Add(this.userControlSelectLayerSet1);
            this.xtraTabPageSelect.Name = "xtraTabPageSelect";
            this.xtraTabPageSelect.PageVisible = false;
            this.xtraTabPageSelect.Size = new System.Drawing.Size(266, 551);
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
            this.userControlSelectLayerSet1.Size = new System.Drawing.Size(266, 551);
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
            this.ribbonPageGroupQuery2.ItemLinks.Add(this.barButtonItemQueryZT);
            this.ribbonPageGroupQuery2.ItemLinks.Add(this.barButtonItemQueryXB);
            this.ribbonPageGroupQuery2.ItemLinks.Add(this.barButtonItemQueryKind);
            this.ribbonPageGroupQuery2.ItemLinks.Add(this.barButtonItemQueryYear);
            this.ribbonPageGroupQuery2.ItemLinks.Add(this.barButtonItemQueryKindZL);
            this.ribbonPageGroupQuery2.ItemLinks.Add(this.barButtonItemQueryKindCF);
            this.ribbonPageGroupQuery2.ItemLinks.Add(this.barButtonItemQueryKindZZY);
            this.ribbonPageGroupQuery2.ItemLinks.Add(this.barButtonItemHZInfoTable);
            this.ribbonPageGroupQuery2.ItemLinks.Add(this.barButtonItemQueryKindHZ);
            this.ribbonPageGroupQuery2.ItemLinks.Add(this.barButtonItemQueryKindZH);
            this.ribbonPageGroupQuery2.ItemLinks.Add(this.barButtonItemQueryKindAJ);
            this.ribbonPageGroupQuery2.ItemLinks.Add(this.barButtonItemQueryKindLDBH);
            this.ribbonPageGroupQuery2.ItemLinks.Add(this.barButtonItemQueryKindXB);
            this.ribbonPageGroupQuery2.Name = "ribbonPageGroupQuery2";
            this.ribbonPageGroupQuery2.Text = "造林查询";
            // 
            // barButtonItemQueryXB
            // 
            this.barButtonItemQueryXB.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            this.barButtonItemQueryXB.Caption = "小班查找";
            this.barButtonItemQueryXB.Description = "小班查询";
            this.barButtonItemQueryXB.Id = 138;
            this.barButtonItemQueryXB.ImageIndex = 91;
            this.barButtonItemQueryXB.LargeImageIndex = 42;
            this.barButtonItemQueryXB.Name = "barButtonItemQueryXB";
            this.barButtonItemQueryXB.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.barButtonItemQueryXB.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemQueryXB_ItemClick);
            // 
            // barButtonItemQueryKindZL
            // 
            this.barButtonItemQueryKindZL.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            this.barButtonItemQueryKindZL.Caption = "造林查询";
            this.barButtonItemQueryKindZL.Description = "造林类型查询";
            this.barButtonItemQueryKindZL.Id = 159;
            this.barButtonItemQueryKindZL.LargeImageIndex = 271;
            this.barButtonItemQueryKindZL.Name = "barButtonItemQueryKindZL";
            this.barButtonItemQueryKindZL.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barButtonItemQueryKindZL.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.barButtonItemQueryKindZL.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // barButtonItemQueryKindCF
            // 
            this.barButtonItemQueryKindCF.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            this.barButtonItemQueryKindCF.Caption = "采伐查询";
            this.barButtonItemQueryKindCF.Description = "采伐类型查询";
            this.barButtonItemQueryKindCF.Id = 160;
            this.barButtonItemQueryKindCF.LargeImageIndex = 339;
            this.barButtonItemQueryKindCF.Name = "barButtonItemQueryKindCF";
            this.barButtonItemQueryKindCF.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barButtonItemQueryKindCF.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.barButtonItemQueryKindCF.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // barButtonItemQueryKindZZY
            // 
            this.barButtonItemQueryKindZZY.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            this.barButtonItemQueryKindZZY.Caption = "征占用查询";
            this.barButtonItemQueryKindZZY.Description = "征占用类型查询";
            this.barButtonItemQueryKindZZY.Id = 175;
            this.barButtonItemQueryKindZZY.LargeImageIndex = 117;
            this.barButtonItemQueryKindZZY.Name = "barButtonItemQueryKindZZY";
            this.barButtonItemQueryKindZZY.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barButtonItemQueryKindZZY.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.barButtonItemQueryKindZZY.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // barButtonItemHZInfoTable
            // 
            this.barButtonItemHZInfoTable.Caption = "火灾登记表";
            this.barButtonItemHZInfoTable.Id = 166;
            this.barButtonItemHZInfoTable.ImageIndex = 113;
            this.barButtonItemHZInfoTable.LargeImageIndex = 344;
            this.barButtonItemHZInfoTable.Name = "barButtonItemHZInfoTable";
            this.barButtonItemHZInfoTable.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // barButtonItemQueryKindHZ
            // 
            this.barButtonItemQueryKindHZ.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            this.barButtonItemQueryKindHZ.Caption = "火灾查询";
            this.barButtonItemQueryKindHZ.Description = "森林火灾类型查询";
            this.barButtonItemQueryKindHZ.Id = 172;
            this.barButtonItemQueryKindHZ.LargeImageIndex = 187;
            this.barButtonItemQueryKindHZ.Name = "barButtonItemQueryKindHZ";
            this.barButtonItemQueryKindHZ.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barButtonItemQueryKindHZ.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.barButtonItemQueryKindHZ.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // barButtonItemQueryKindZH
            // 
            this.barButtonItemQueryKindZH.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            this.barButtonItemQueryKindZH.Caption = "灾害查询";
            this.barButtonItemQueryKindZH.Description = "自然灾害类型查询";
            this.barButtonItemQueryKindZH.Id = 173;
            this.barButtonItemQueryKindZH.LargeImageIndex = 403;
            this.barButtonItemQueryKindZH.Name = "barButtonItemQueryKindZH";
            this.barButtonItemQueryKindZH.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barButtonItemQueryKindZH.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.barButtonItemQueryKindZH.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // barButtonItemQueryKindAJ
            // 
            this.barButtonItemQueryKindAJ.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            this.barButtonItemQueryKindAJ.Caption = "案件查询";
            this.barButtonItemQueryKindAJ.Description = "林业案件类型查询";
            this.barButtonItemQueryKindAJ.Id = 174;
            this.barButtonItemQueryKindAJ.LargeImageIndex = 59;
            this.barButtonItemQueryKindAJ.Name = "barButtonItemQueryKindAJ";
            this.barButtonItemQueryKindAJ.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barButtonItemQueryKindAJ.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.barButtonItemQueryKindAJ.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // barButtonItemQueryKindLDBH
            // 
            this.barButtonItemQueryKindLDBH.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            this.barButtonItemQueryKindLDBH.Caption = "林地查询";
            this.barButtonItemQueryKindLDBH.Id = 180;
            this.barButtonItemQueryKindLDBH.LargeImageIndex = 406;
            this.barButtonItemQueryKindLDBH.Name = "barButtonItemQueryKindLDBH";
            this.barButtonItemQueryKindLDBH.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barButtonItemQueryKindLDBH.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.barButtonItemQueryKindLDBH.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // barButtonItemQueryKindXB
            // 
            this.barButtonItemQueryKindXB.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            this.barButtonItemQueryKindXB.Caption = "小班查询";
            this.barButtonItemQueryKindXB.Description = "小班类型查询";
            this.barButtonItemQueryKindXB.Id = 161;
            this.barButtonItemQueryKindXB.LargeImageIndex = 176;
            this.barButtonItemQueryKindXB.Name = "barButtonItemQueryKindXB";
            this.barButtonItemQueryKindXB.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barButtonItemQueryKindXB.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.barButtonItemQueryKindXB.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
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
            this.ribbonPageGroupMapView3.ItemLinks.Add(this.barButtonItemZoomIn);
            this.ribbonPageGroupMapView3.ItemLinks.Add(this.barButtonItemZoomOut);
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
            this.xtraTabPageMapFind.Size = new System.Drawing.Size(266, 551);
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
            this.userControlMapFind1.Size = new System.Drawing.Size(266, 551);
            this.userControlMapFind1.TabIndex = 2;
            // 
            // xtraTabPageLocation
            // 
            this.xtraTabPageLocation.Controls.Add(this.userControlLocation);
            this.xtraTabPageLocation.Name = "xtraTabPageLocation";
            this.xtraTabPageLocation.PageVisible = false;
            this.xtraTabPageLocation.Size = new System.Drawing.Size(266, 551);
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
            this.userControlLocation.Size = new System.Drawing.Size(266, 551);
            this.userControlLocation.TabIndex = 0;
            // 
            // ribbonPageGroupMxt
            // 
            this.ribbonPageGroupMxt.AllowMinimize = false;
            this.ribbonPageGroupMxt.ItemLinks.Add(this.barButtonItemDC);
            this.ribbonPageGroupMxt.ItemLinks.Add(this.barButtonItemSJ);
            this.ribbonPageGroupMxt.ItemLinks.Add(this.barButtonItemZTT);
            this.ribbonPageGroupMxt.ItemLinks.Add(this.barEditItem_fx);
            this.ribbonPageGroupMxt.ItemLinks.Add(this.barButtonItemNormal);
            this.ribbonPageGroupMxt.Name = "ribbonPageGroupMxt";
            this.ribbonPageGroupMxt.Text = "制图模版";
            // 
            // barButtonItemDC
            // 
            this.barButtonItemDC.Caption = "调查图";
            this.barButtonItemDC.Description = "外业调查图";
            this.barButtonItemDC.Id = 102;
            this.barButtonItemDC.ImageIndex = 189;
            this.barButtonItemDC.LargeImageIndex = 126;
            this.barButtonItemDC.Name = "barButtonItemDC";
            this.barButtonItemDC.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.barButtonItemDC.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemDC_ItemClick);
            // 
            // barButtonItemSJ
            // 
            this.barButtonItemSJ.Caption = "设计图";
            this.barButtonItemSJ.Description = "作业设计图";
            this.barButtonItemSJ.Id = 103;
            this.barButtonItemSJ.ImageIndex = 93;
            this.barButtonItemSJ.LargeImageIndex = 43;
            this.barButtonItemSJ.Name = "barButtonItemSJ";
            this.barButtonItemSJ.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.barButtonItemSJ.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemSJ_ItemClick);
            // 
            // barButtonItemZTT
            // 
            this.barButtonItemZTT.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            this.barButtonItemZTT.Caption = "专题图";
            this.barButtonItemZTT.Description = "专题图";
            this.barButtonItemZTT.Id = 193;
            this.barButtonItemZTT.ImageIndex = 190;
            this.barButtonItemZTT.LargeImageIndex = 381;
            this.barButtonItemZTT.Name = "barButtonItemZTT";
            this.barButtonItemZTT.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barButtonItemZTT.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.barButtonItemZTT.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.barButtonItemZTT.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemZTT_ItemClick);
            // 
            // barEditItem_fx
            // 
            this.barEditItem_fx.Edit = this.repositoryItemComboBox2;
            this.barEditItem_fx.EditValue = "A4横向";
            this.barEditItem_fx.Id = 176;
            this.barEditItem_fx.Name = "barEditItem_fx";
            this.barEditItem_fx.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText;
            this.barEditItem_fx.Width = 60;
            this.barEditItem_fx.EditValueChanged += new System.EventHandler(this.barEditItem_fx_EditValueChanged);
            // 
            // repositoryItemComboBox2
            // 
            this.repositoryItemComboBox2.AutoHeight = false;
            this.repositoryItemComboBox2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemComboBox2.Items.AddRange(new object[] {
            "A4横向",
            "A4纵向",
            "A3横向",
            "A3纵向"});
            this.repositoryItemComboBox2.Name = "repositoryItemComboBox2";
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
            this.xtraTabPageXBchange.Size = new System.Drawing.Size(266, 551);
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
            this.userControlXBLayerCombine1.Size = new System.Drawing.Size(266, 551);
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
            this.userControlXBSet31.Size = new System.Drawing.Size(266, 551);
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
            this.userControlXBSet21.Size = new System.Drawing.Size(266, 551);
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
            this.userControlInputYG1.Size = new System.Drawing.Size(266, 551);
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
            this.userControlXBSet1.Size = new System.Drawing.Size(266, 551);
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
            this.userControlQueryResult1.Size = new System.Drawing.Size(950, 162);
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
            this.xtraTabQuery.Size = new System.Drawing.Size(994, 168);
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
            this.xtraTabPage1.Size = new System.Drawing.Size(950, 162);
            this.xtraTabPage1.Text = "查询";
            // 
            // xtraTabPage2
            // 
            this.xtraTabPage2.Controls.Add(this.userControlQueryResult2);
            this.xtraTabPage2.Name = "xtraTabPage2";
            this.xtraTabPage2.PageVisible = false;
            this.xtraTabPage2.Size = new System.Drawing.Size(950, 162);
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
            this.userControlQueryResult2.Size = new System.Drawing.Size(950, 162);
            this.userControlQueryResult2.TabIndex = 1;
            // 
            // xtraTabPage3
            // 
            this.xtraTabPage3.Controls.Add(this.userControlSelectFeatureResport21);
            this.xtraTabPage3.Name = "xtraTabPage3";
            this.xtraTabPage3.PageVisible = false;
            this.xtraTabPage3.Size = new System.Drawing.Size(950, 162);
            toolTipItem1.Text = "要素属性列表";
            superToolTip1.Items.Add(toolTipItem1);
            this.xtraTabPage3.SuperTip = superToolTip1;
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
            this.userControlSelectFeatureResport21.Size = new System.Drawing.Size(950, 162);
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
            this.xtraTabPageAddRasterlayer.Size = new System.Drawing.Size(266, 551);
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
            this.userControlImageGeoReference1.Size = new System.Drawing.Size(266, 551);
            this.userControlImageGeoReference1.TabIndex = 0;
            // 
            // ribbonPageStatic
            // 
            this.ribbonPageStatic.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroupCF,
            this.ribbonPageGroupZL,
            this.ribbonPageGroupHZ,
            this.ribbonPageGroupZH,
            this.ribbonPageGroupAJ,
            this.ribbonPageGroupZZY,
            this.ribbonPageGroupReportXB,
            this.ribbonPageGroup1,
            this.ribbonPageGroupGYL,
            this.ribbonPageGroupLD});
            this.ribbonPageStatic.ImageIndex = 205;
            this.ribbonPageStatic.Name = "ribbonPageStatic";
            this.ribbonPageStatic.Text = "统计";
            // 
            // ribbonPageGroupCF
            // 
            this.ribbonPageGroupCF.ItemLinks.Add(this.barButtonItemReportCF1);
            this.ribbonPageGroupCF.ItemLinks.Add(this.barButtonItemChartCF);
            this.ribbonPageGroupCF.Name = "ribbonPageGroupCF";
            this.ribbonPageGroupCF.Text = "采伐专题报表";
            this.ribbonPageGroupCF.Visible = false;
            // 
            // barButtonItemReportCF1
            // 
            this.barButtonItemReportCF1.Caption = "采伐统计表";
            this.barButtonItemReportCF1.Id = 153;
            this.barButtonItemReportCF1.LargeImageIndex = 371;
            this.barButtonItemReportCF1.Name = "barButtonItemReportCF1";
            this.barButtonItemReportCF1.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.barButtonItemReportCF1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemReportCF1_ItemClick);
            // 
            // barButtonItemChartCF
            // 
            this.barButtonItemChartCF.Caption = "采伐统计图表";
            this.barButtonItemChartCF.Id = 155;
            this.barButtonItemChartCF.LargeImageIndex = 7;
            this.barButtonItemChartCF.Name = "barButtonItemChartCF";
            this.barButtonItemChartCF.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.barButtonItemChartCF.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemChartCF_ItemClick);
            // 
            // ribbonPageGroupZL
            // 
            this.ribbonPageGroupZL.ItemLinks.Add(this.barButtonItemReportZL);
            this.ribbonPageGroupZL.ItemLinks.Add(this.barButtonItemChartZL);
            this.ribbonPageGroupZL.Name = "ribbonPageGroupZL";
            this.ribbonPageGroupZL.Text = "造林专题报表";
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
            this.barButtonItemChartZL.LargeImageIndex = 421;
            this.barButtonItemChartZL.Name = "barButtonItemChartZL";
            this.barButtonItemChartZL.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.barButtonItemChartZL.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemChartZL_ItemClick);
            // 
            // ribbonPageGroupHZ
            // 
            this.ribbonPageGroupHZ.ItemLinks.Add(this.barButtonItemReportHZ);
            this.ribbonPageGroupHZ.ItemLinks.Add(this.barButtonItemChartHZ);
            this.ribbonPageGroupHZ.ItemLinks.Add(this.barButtonItemReportKind);
            this.ribbonPageGroupHZ.Name = "ribbonPageGroupHZ";
            this.ribbonPageGroupHZ.Text = "火灾专题报表";
            this.ribbonPageGroupHZ.Visible = false;
            // 
            // barButtonItemReportHZ
            // 
            this.barButtonItemReportHZ.Caption = "火灾统计表";
            this.barButtonItemReportHZ.Description = "森林火灾统计表";
            this.barButtonItemReportHZ.Id = 162;
            this.barButtonItemReportHZ.LargeImageIndex = 4;
            this.barButtonItemReportHZ.Name = "barButtonItemReportHZ";
            this.barButtonItemReportHZ.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barButtonItemReportHZ.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // barButtonItemChartHZ
            // 
            this.barButtonItemChartHZ.Caption = "火灾统计图表";
            this.barButtonItemChartHZ.Description = "森林火灾统计图表";
            this.barButtonItemChartHZ.Id = 163;
            this.barButtonItemChartHZ.LargeImageIndex = 58;
            this.barButtonItemChartHZ.Name = "barButtonItemChartHZ";
            this.barButtonItemChartHZ.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barButtonItemChartHZ.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.barButtonItemChartHZ.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // barButtonItemReportKind
            // 
            this.barButtonItemReportKind.Caption = "类型统计表";
            this.barButtonItemReportKind.Description = "森林火灾分类型统计表";
            this.barButtonItemReportKind.Id = 164;
            this.barButtonItemReportKind.LargeImageIndex = 211;
            this.barButtonItemReportKind.Name = "barButtonItemReportKind";
            this.barButtonItemReportKind.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barButtonItemReportKind.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // ribbonPageGroupZH
            // 
            this.ribbonPageGroupZH.ItemLinks.Add(this.barButtonItemReportZH);
            this.ribbonPageGroupZH.Name = "ribbonPageGroupZH";
            this.ribbonPageGroupZH.Text = "灾害专题统计";
            this.ribbonPageGroupZH.Visible = false;
            // 
            // barButtonItemReportZH
            // 
            this.barButtonItemReportZH.Caption = "自然灾害统计表";
            this.barButtonItemReportZH.Id = 169;
            this.barButtonItemReportZH.LargeImageIndex = 161;
            this.barButtonItemReportZH.Name = "barButtonItemReportZH";
            this.barButtonItemReportZH.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barButtonItemReportZH.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // ribbonPageGroupAJ
            // 
            this.ribbonPageGroupAJ.ItemLinks.Add(this.barButtonItemReportAJ);
            this.ribbonPageGroupAJ.Name = "ribbonPageGroupAJ";
            this.ribbonPageGroupAJ.Text = "案件专题统计";
            this.ribbonPageGroupAJ.Visible = false;
            // 
            // barButtonItemReportAJ
            // 
            this.barButtonItemReportAJ.Caption = "林业案件统计表";
            this.barButtonItemReportAJ.Id = 170;
            this.barButtonItemReportAJ.LargeImageIndex = 160;
            this.barButtonItemReportAJ.Name = "barButtonItemReportAJ";
            this.barButtonItemReportAJ.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barButtonItemReportAJ.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // ribbonPageGroupZZY
            // 
            this.ribbonPageGroupZZY.ItemLinks.Add(this.barButtonItemReportZZY);
            this.ribbonPageGroupZZY.ItemLinks.Add(this.barButtonItemReportZZY2);
            this.ribbonPageGroupZZY.ItemLinks.Add(this.barButtonItemReportZZY3);
            this.ribbonPageGroupZZY.Name = "ribbonPageGroupZZY";
            this.ribbonPageGroupZZY.Text = "征占用专题统计";
            // 
            // barButtonItemReportZZY
            // 
            this.barButtonItemReportZZY.Caption = "调查成果统计表";
            this.barButtonItemReportZZY.Description = "征占用调查成果统计表";
            this.barButtonItemReportZZY.Id = 165;
            this.barButtonItemReportZZY.LargeImageIndex = 213;
            this.barButtonItemReportZZY.Name = "barButtonItemReportZZY";
            this.barButtonItemReportZZY.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // barButtonItemReportZZY2
            // 
            this.barButtonItemReportZZY2.Caption = "征占用林地统计报表";
            this.barButtonItemReportZZY2.Description = "林地征占用国家统计表";
            this.barButtonItemReportZZY2.Id = 171;
            this.barButtonItemReportZZY2.LargeImageIndex = 9;
            this.barButtonItemReportZZY2.Name = "barButtonItemReportZZY2";
            // 
            // barButtonItemReportZZY3
            // 
            this.barButtonItemReportZZY3.Caption = " 月统计报表 ";
            this.barButtonItemReportZZY3.Id = 182;
            this.barButtonItemReportZZY3.LargeImageIndex = 129;
            this.barButtonItemReportZZY3.Name = "barButtonItemReportZZY3";
            this.barButtonItemReportZZY3.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // ribbonPageGroupReportXB
            // 
            this.ribbonPageGroupReportXB.ItemLinks.Add(this.barButtonItemStatic);
            this.ribbonPageGroupReportXB.Name = "ribbonPageGroupReportXB";
            this.ribbonPageGroupReportXB.Text = "二类调查统计";
            // 
            // barButtonItemStatic
            // 
            this.barButtonItemStatic.Caption = "小班统计报表";
            this.barButtonItemStatic.Id = 147;
            this.barButtonItemStatic.LargeImageIndex = 212;
            this.barButtonItemStatic.Name = "barButtonItemStatic";
            this.barButtonItemStatic.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemStatic_ItemClick);
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.barButtonReportCustom);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "通用统计";
            // 
            // barButtonReportCustom
            // 
            this.barButtonReportCustom.Caption = "自定义报表";
            this.barButtonReportCustom.Glyph = ((System.Drawing.Image)(resources.GetObject("barButtonReportCustom.Glyph")));
            this.barButtonReportCustom.Id = 197;
            this.barButtonReportCustom.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barButtonReportCustom.LargeGlyph")));
            this.barButtonReportCustom.Name = "barButtonReportCustom";
            this.barButtonReportCustom.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonReportCustom_ItemClick);
            // 
            // ribbonPageGroupGYL
            // 
            this.ribbonPageGroupGYL.ItemLinks.Add(this.barButtonItemReportGYL);
            this.ribbonPageGroupGYL.Name = "ribbonPageGroupGYL";
            this.ribbonPageGroupGYL.Text = "公益林统计";
            // 
            // barButtonItemReportGYL
            // 
            this.barButtonItemReportGYL.Caption = "公益林统计表";
            this.barButtonItemReportGYL.Id = 181;
            this.barButtonItemReportGYL.LargeImageIndex = 413;
            this.barButtonItemReportGYL.Name = "barButtonItemReportGYL";
            // 
            // ribbonPageGroupLD
            // 
            this.ribbonPageGroupLD.ItemLinks.Add(this.barButtonItemReportLD);
            this.ribbonPageGroupLD.Name = "ribbonPageGroupLD";
            this.ribbonPageGroupLD.Text = "年度更新统计";
            this.ribbonPageGroupLD.Visible = false;
            // 
            // barButtonItemReportLD
            // 
            this.barButtonItemReportLD.Caption = "森林资源数据年度更新统计表";
            this.barButtonItemReportLD.Id = 179;
            this.barButtonItemReportLD.LargeImageIndex = 323;
            this.barButtonItemReportLD.Name = "barButtonItemReportLD";
            // 
            // xtraTabPagePlace
            // 
            this.xtraTabPagePlace.Controls.Add(this.userControlPlace1);
            this.xtraTabPagePlace.Name = "xtraTabPagePlace";
            this.xtraTabPagePlace.PageVisible = false;
            this.xtraTabPagePlace.Size = new System.Drawing.Size(266, 551);
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
            this.userControlPlace1.Size = new System.Drawing.Size(266, 551);
            this.userControlPlace1.TabIndex = 0;
            // 
            // xtraTabPageTFH
            // 
            this.xtraTabPageTFH.Controls.Add(this.userControlQueryTFH1);
            this.xtraTabPageTFH.Name = "xtraTabPageTFH";
            this.xtraTabPageTFH.PageVisible = false;
            this.xtraTabPageTFH.Size = new System.Drawing.Size(266, 551);
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
            this.userControlQueryTFH1.Size = new System.Drawing.Size(266, 551);
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
            this.xtraTabPageKind.Controls.Add(this.userControlQueryLDBH1);
            this.xtraTabPageKind.Controls.Add(this.userControlQueryZZY21);
            this.xtraTabPageKind.Controls.Add(this.userControlQueryHZ21);
            this.xtraTabPageKind.Controls.Add(this.userControlQueryXB21);
            this.xtraTabPageKind.Controls.Add(this.userControlQueryCF21);
            this.xtraTabPageKind.Name = "xtraTabPageKind";
            this.xtraTabPageKind.PageVisible = false;
            this.xtraTabPageKind.Size = new System.Drawing.Size(266, 551);
            this.xtraTabPageKind.Text = "类型";
            // 
            // userControlQueryLDBH1
            // 
            this.userControlQueryLDBH1.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.userControlQueryLDBH1.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.userControlQueryLDBH1.Appearance.Options.UseBackColor = true;
            this.userControlQueryLDBH1.AutoScroll = true;
            this.userControlQueryLDBH1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControlQueryLDBH1.Location = new System.Drawing.Point(0, 0);
            this.userControlQueryLDBH1.Name = "userControlQueryLDBH1";
            this.userControlQueryLDBH1.Padding = new System.Windows.Forms.Padding(4, 0, 4, 4);
            this.userControlQueryLDBH1.Size = new System.Drawing.Size(266, 551);
            this.userControlQueryLDBH1.TabIndex = 4;
            this.userControlQueryLDBH1.Visible = false;
            // 
            // userControlQueryZZY21
            // 
            this.userControlQueryZZY21.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.userControlQueryZZY21.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.userControlQueryZZY21.Appearance.Options.UseBackColor = true;
            this.userControlQueryZZY21.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControlQueryZZY21.Location = new System.Drawing.Point(0, 0);
            this.userControlQueryZZY21.Name = "userControlQueryZZY21";
            this.userControlQueryZZY21.Padding = new System.Windows.Forms.Padding(6, 0, 6, 6);
            this.userControlQueryZZY21.Size = new System.Drawing.Size(266, 551);
            this.userControlQueryZZY21.TabIndex = 3;
            this.userControlQueryZZY21.Visible = false;
            // 
            // userControlQueryHZ21
            // 
            this.userControlQueryHZ21.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.userControlQueryHZ21.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.userControlQueryHZ21.Appearance.Options.UseBackColor = true;
            this.userControlQueryHZ21.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControlQueryHZ21.Location = new System.Drawing.Point(0, 0);
            this.userControlQueryHZ21.Name = "userControlQueryHZ21";
            this.userControlQueryHZ21.Size = new System.Drawing.Size(266, 551);
            this.userControlQueryHZ21.TabIndex = 2;
            this.userControlQueryHZ21.Visible = false;
            // 
            // userControlQueryXB21
            // 
            this.userControlQueryXB21.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.userControlQueryXB21.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.userControlQueryXB21.Appearance.Options.UseBackColor = true;
            this.userControlQueryXB21.AutoScroll = true;
            this.userControlQueryXB21.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControlQueryXB21.Location = new System.Drawing.Point(0, 0);
            this.userControlQueryXB21.Name = "userControlQueryXB21";
            this.userControlQueryXB21.Padding = new System.Windows.Forms.Padding(4, 0, 4, 4);
            this.userControlQueryXB21.Size = new System.Drawing.Size(266, 551);
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
            this.userControlQueryCF21.Size = new System.Drawing.Size(266, 551);
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
            // userControlQueryHZ1
            // 
            this.userControlQueryHZ1.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.userControlQueryHZ1.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.userControlQueryHZ1.Appearance.Options.UseBackColor = true;
            this.userControlQueryHZ1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControlQueryHZ1.Location = new System.Drawing.Point(6, 1);
            this.userControlQueryHZ1.Name = "userControlQueryHZ1";
            this.userControlQueryHZ1.Size = new System.Drawing.Size(233, 529);
            this.userControlQueryHZ1.TabIndex = 3;
            this.userControlQueryHZ1.Visible = false;
            // 
            // userControlQueryZZY1
            // 
            this.userControlQueryZZY1.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.userControlQueryZZY1.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.userControlQueryZZY1.Appearance.Options.UseBackColor = true;
            this.userControlQueryZZY1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControlQueryZZY1.Location = new System.Drawing.Point(6, 1);
            this.userControlQueryZZY1.Name = "userControlQueryZZY1";
            this.userControlQueryZZY1.Size = new System.Drawing.Size(233, 529);
            this.userControlQueryZZY1.TabIndex = 4;
            this.userControlQueryZZY1.Visible = false;
            // 
            // userControlQueryZH1
            // 
            this.userControlQueryZH1.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.userControlQueryZH1.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.userControlQueryZH1.Appearance.Options.UseBackColor = true;
            this.userControlQueryZH1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControlQueryZH1.Location = new System.Drawing.Point(6, 1);
            this.userControlQueryZH1.Name = "userControlQueryZH1";
            this.userControlQueryZH1.Size = new System.Drawing.Size(233, 529);
            this.userControlQueryZH1.TabIndex = 5;
            this.userControlQueryZH1.Visible = false;
            // 
            // userControlQueryAJ1
            // 
            this.userControlQueryAJ1.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.userControlQueryAJ1.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.userControlQueryAJ1.Appearance.Options.UseBackColor = true;
            this.userControlQueryAJ1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControlQueryAJ1.Location = new System.Drawing.Point(6, 1);
            this.userControlQueryAJ1.Name = "userControlQueryAJ1";
            this.userControlQueryAJ1.Size = new System.Drawing.Size(233, 529);
            this.userControlQueryAJ1.TabIndex = 6;
            this.userControlQueryAJ1.Visible = false;
            // 
            // barButtonItemMapSet
            // 
            this.barButtonItemMapSet.Caption = "地图设置";
            this.barButtonItemMapSet.Id = 178;
            this.barButtonItemMapSet.ImageIndex = 340;
            this.barButtonItemMapSet.LargeImageIndex = 170;
            this.barButtonItemMapSet.Name = "barButtonItemMapSet";
            // 
            // barButtonItemExit
            // 
            this.barButtonItemExit.Caption = "退出";
            this.barButtonItemExit.Description = "退出系统";
            this.barButtonItemExit.Id = 183;
            this.barButtonItemExit.LargeImageIndex = 16;
            this.barButtonItemExit.Name = "barButtonItemExit";
            this.barButtonItemExit.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barButtonItemExit.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText)));
            // 
            // xtraTabPageCX
            // 
            this.xtraTabPageCX.Controls.Add(this.userControlSelectByAttributes1);
            this.xtraTabPageCX.Name = "xtraTabPageCX";
            this.xtraTabPageCX.Size = new System.Drawing.Size(266, 551);
            this.xtraTabPageCX.Text = "条件查询";
            // 
            // userControlSelectByAttributes1
            // 
            this.userControlSelectByAttributes1.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.userControlSelectByAttributes1.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.userControlSelectByAttributes1.Appearance.Options.UseBackColor = true;
            this.userControlSelectByAttributes1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControlSelectByAttributes1.Location = new System.Drawing.Point(0, 0);
            this.userControlSelectByAttributes1.Name = "userControlSelectByAttributes1";
            this.userControlSelectByAttributes1.Padding = new System.Windows.Forms.Padding(4);
            this.userControlSelectByAttributes1.Size = new System.Drawing.Size(266, 551);
            this.userControlSelectByAttributes1.TabIndex = 0;
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.AllowMinimize = false;
            this.ribbonPageGroup2.ItemLinks.Add(this.barStaticItem1, true);
            this.ribbonPageGroup2.ItemLinks.Add(this.barEditItem2);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.Text = "小班年度管理";
            // 
            // barStaticItem1
            // 
            this.barStaticItem1.Caption = " 选择年度：";
            this.barStaticItem1.Id = 267;
            this.barStaticItem1.Name = "barStaticItem1";
            this.barStaticItem1.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // barEditItem2
            // 
            this.barEditItem2.Edit = this.repositoryItemComboBox3;
            this.barEditItem2.Id = 268;
            this.barEditItem2.Name = "barEditItem2";
            this.barEditItem2.Width = 75;
            this.barEditItem2.EditValueChanged += new System.EventHandler(this.barEditItem2_EditValueChanged);
            // 
            // repositoryItemComboBox3
            // 
            this.repositoryItemComboBox3.AutoHeight = false;
            this.repositoryItemComboBox3.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemComboBox3.Items.AddRange(new object[] {
            "2013",
            "2014",
            "2015",
            "2016",
            "2017",
            "2018",
            "2019",
            "2020"});
            this.repositoryItemComboBox3.Name = "repositoryItemComboBox3";
            // 
            // MainFrameQuery
            // 
            this.ClientSize = new System.Drawing.Size(1280, 787);
            this.MinimumSize = new System.Drawing.Size(1002, 723);
            this.Name = "MainFrameQuery";
            this.Text = "查询统计";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Activated += new System.EventHandler(this.FormMainFrame_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainFrameEdit_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormMainFrame_FormClosed);
            this.Load += new System.EventHandler(this.FormMainFrame_Load);
            this.Resize += new System.EventHandler(this.FormMainFrame_Resize);
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
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox2)).EndInit();
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
            this.xtraTabPageCX.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        /// <summary>
        /// 初始化编辑值
        /// </summary>
        /// <param name="flag"></param>
        private void InitializeEditValue(bool flag)
        {
            try
            {
                TaskManageClass.InitialEditValues(this.mEditKind, "2016", base.MapControlEdit.Map);
                TaskManageClass.TaskState = TaskState.Open;
                TaskManageClass.LogicCheckState = LogicCheckState.Failure;
                TaskManageClass.ToplogicCheckState = ToplogicCheckState.Failure;
                this.mFeatureWorkspace = EditTask.EditWorkspace;
                this.mEditLayer = EditTask.EditLayer;
                if (this.bDefaultPath)
                {
                    DB2LayerModelManager dmm = new DB2LayerModelManager();
                    dmm.SetFeatureLayerResource(MapControlEdit.Map, this.mFeatureWorkspace, HasLayerResource, EditTask.TaskYear);

                }
                string configValue = UtilFactory.GetConfigOpt().GetConfigValue("CountyLayerName");
                this.m_pCLayer = GISFunFactory.LayerFun.FindFeatureLayer(base.MapControlEdit.Map as IBasicMap, configValue, true);
                if (this.m_pCLayer != null)
                {
                    GC.Collect();
                    IQueryFilter queryFilter = new QueryFilterClass();
                    string str2 = UtilFactory.GetConfigOpt().GetConfigValue("CountyFieldCode");
                    queryFilter.WhereClause = str2 + "='" + EditTask.DistCode + "'";
                    this.m_CountyFeature = this.m_pCLayer.Search(queryFilter, false).NextFeature();
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "GXFormMainFrame.FormMainEdit", "InitializeEditValue", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        /// <summary>
        /// 在初始化“资源信息查询”的“二维浏览”窗体，给登录界面反馈加载进度。
        /// </summary>
        /// <returns></returns>
        public bool InitializeForm()
        {
            Exception exception;
            try
            {
                if (this.FormSplash != null)
                {
                    this.FormSplash.SetLoadInfo("正在加载地图数据...", 25);
                }
                if (this.FormSplash6 != null)
                {
                    this.FormSplash6.SetLoadInfo("正在加载地图数据...", 25);
                }
                base.MapControlEdit.BringToFront();
                this.InitSynchronizer();//初始化同步IMapControl4，必须同步，因为如果不加载视图，将无法进行视图操作和根据视图有关的所有操作
                this.InitializeGISControls();
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
                //设置窗体名称
                this.SetFormText();
                base.ribbon.SelectedPage = base.ribbonPageQuery;
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
                //BringToFront（）将控件移到 Z 顺序的前面。如果控件是另一个控件的子控件，那么子控件移到 Z 顺序的前面。BringToFront 不会使一个控件成为顶级控件。
                base.dockPanelToolbox.BringToFront();
                base.WindowState = FormWindowState.Maximized;
                base.Show();
                int width = 0;
                //DockVisibility:包含指定停靠面板可见状态的值。面板是可见的。 Visible = 0,
                if (base.dockPanelToolbox.Visibility == DockVisibility.Visible)
                {
                    width = base.xtraTabToolbox.Width;
                }
                if (base.xtraTabMain.SelectedTabPageIndex == 0)//若视图为地图MapControlEdit
                {
                    base.MapControlEdit.BringToFront();
                    base.MapControlEdit.Dock = DockStyle.None;
                    base.MapControlEdit.Left = 1;
                    base.MapControlEdit.Top = 1;
                    base.MapControlEdit.Width = base.xtraTabMain.Width - 2;
                    base.MapControlEdit.Height = base.xtraTabMain.Height - 32;
                    base.MapControlEdit.ShowScrollbars = false;
                    base.MapControlEdit.Height = base.xtraTabMain.Height - 24;
                    base.PageLayoutControlEdit.Dock = DockStyle.None;
                    base.PageLayoutControlEdit.Left = base.xtraTabMain.Left + 1;
                    base.PageLayoutControlEdit.Top = base.xtraTabMain.Top + 1;
                    base.PageLayoutControlEdit.Width = base.xtraTabMain.Width - 2;
                    base.PageLayoutControlEdit.Height = base.xtraTabMain.Height - 32;
                    base.PageLayoutControlEdit.Height = base.xtraTabMain.Height - 24;
                }
                else if (base.xtraTabMain.SelectedTabPageIndex == 1)//若视图为出版PageLayeroutControlEdit
                {
                    base.PageLayoutControlEdit.BringToFront();
                    base.PageLayoutControlEdit.Dock = DockStyle.None;
                    base.PageLayoutControlEdit.Left = base.xtraTabMain.Left + 1;
                    base.PageLayoutControlEdit.Top = base.xtraTabMain.Top + 1;
                    base.PageLayoutControlEdit.Width = base.xtraTabMain.Width - 2;
                    base.PageLayoutControlEdit.Height = base.xtraTabMain.Height - 32;
                    base.PageLayoutControlEdit.Height = base.xtraTabMain.Height - 24;
                    base.MapControlEdit.Dock = DockStyle.None;
                    base.MapControlEdit.Left = 1;
                    base.MapControlEdit.Top = 1;
                    base.MapControlEdit.Width = base.xtraTabMain.Width - 2;
                    base.MapControlEdit.Height = base.xtraTabMain.Height - 32;
                    base.MapControlEdit.ShowScrollbars = false;
                    base.MapControlEdit.Height = base.xtraTabMain.Height - 24;
                }
                if (this.FormSplash != null)
                {
                    this.FormSplash.SetLoadInfo("正在初始化功能模块...", 90);
                }
                if (this.FormSplash6 != null)
                {
                    this.FormSplash6.SetLoadInfo("正在初始化功能模块...", 90);
                }
                try
                {
                    PrintController.SetDefaultPrintSet("A4", 2, base.PageLayoutControlEdit.Object as IPageLayoutControl3);
                }
                catch (Exception exception1)
                {
                    exception = exception1;
                    this.mErrOpt.ErrorOperate(this.mSubSysName, "GXFormMainFrame.FormMainEdit", "InitializeForm", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                }
                try
                {
                    if (((Process.GetCurrentProcess().PrivateMemorySize64 / 0x400L) / 0x400L) > 200L)
                    {
                        Process process = new Process();
                        ProcessStartInfo info = new ProcessStartInfo(Application.StartupPath + @"\MemoryClean.exe");
                        process.StartInfo = info;
                        process.StartInfo.UseShellExecute = false;
                        process.Start();
                    }
                }
                catch (Exception exception2)
                {
                    exception = exception2;
                    this.mErrOpt.ErrorOperate(this.mSubSysName, "GXFormMainFrame.FormMainEdit", "InitializeForm", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                }
                //当初始化窗体有异常时，便会触发计时器窗体
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
            catch (Exception exception3)
            {
                exception = exception3;
                this.mErrOpt.ErrorOperate(this.mSubSysName, "GXFormMainFrame.FormMainEdit", "InitializeForm", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                return false;
            }
        }

        /// <summary>
        /// 初始化GIS控制
        /// </summary>
        private void InitializeGISControls()
        {
            try
            {
                //设置地图控件事件和按钮事件
                this.mSelection = true;
                this.mActiveViewEvents = base.MapControlEdit.Map as IActiveViewEvents_Event;
                //IActiveViewEvents.ItemAdded事件当项目添加到视图时触发。
                this.mActiveViewEvents.ItemAdded += (new IActiveViewEvents_ItemAddedEventHandler(this.ActiveViewEvents_ItemAdded));
                //IActiveViewEvents.ItemDeleted事件从视图中删除项目时触发。
                this.mActiveViewEvents.ItemDeleted += (new IActiveViewEvents_ItemDeletedEventHandler(this.ActiveViewEvents_ItemDeleted));
                this.m_ActiveViewEventsAfterDraw = new IActiveViewEvents_AfterDrawEventHandler(this.OnActiveViewEventsAfterDraw);
                ((IActiveViewEvents_Event)base.MapControlEdit.Map).AfterDraw += (this.m_ActiveViewEventsAfterDraw);
                this.m_ActiveViewEventsAfterItemDraw = new IActiveViewEvents_AfterItemDrawEventHandler(this.OnActiveViewEventsItemDraw);
                ((IActiveViewEvents_Event)base.MapControlEdit.Map).AfterItemDraw += (this.m_ActiveViewEventsAfterItemDraw);
                this.m_ActiveViewEventsItemAdded = new IActiveViewEvents_ItemAddedEventHandler(this.OnActiveViewEventsItemAdded);
                ((IActiveViewEvents_Event)base.MapControlEdit.Map).ItemAdded += (this.m_ActiveViewEventsItemAdded);
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
                this.barButtonItemPrintPreview.ItemClick += new ItemClickEventHandler(this.barButtonItemPrintPreview_ItemClick);
                this.barButtonItemExportImage.ItemClick += new ItemClickEventHandler(this.barButtonItemExportImage_ItemClick);
                this.barButtonItemAddLayer.ItemClick += new ItemClickEventHandler(this.barButtonItemAddLayer_ItemClick);
                this.barButtonItemVertexList.ItemClick += new ItemClickEventHandler(this.barButtonItemVertexList_ItemClick);
                this.barButtonItemLogicCheck.ItemClick += new ItemClickEventHandler(this.barButtonItemLogicCheck_ItemClick);
                this.barButtonItemReportCF1.ItemClick += new ItemClickEventHandler(this.barButtonItemCF1_ItemClick);
                this.barButtonItemReportZL.ItemClick += new ItemClickEventHandler(this.barButtonItemReportZL_ItemClick);
                this.barButtonItemQueryKindZL.ItemClick += new ItemClickEventHandler(this.barButtonItemQueryKindZL_ItemClick);
                this.barButtonItemQueryKindCF.ItemClick += new ItemClickEventHandler(this.barButtonItemQueryKindCF_ItemClick);
                this.barButtonItemQueryKindHZ.ItemClick += new ItemClickEventHandler(this.barButtonItemQueryKindHZ_ItemClick);
                this.barButtonItemQueryKindZH.ItemClick += new ItemClickEventHandler(this.barButtonItemQueryKindZH_ItemClick);
                this.barButtonItemQueryKindAJ.ItemClick += new ItemClickEventHandler(this.barButtonItemQueryKindAJ_ItemClick);
                this.barButtonItemQueryKindZZY.ItemClick += new ItemClickEventHandler(this.barButtonItemQueryKindZZY_ItemClick);
                this.barButtonItemQueryKindLDBH.ItemClick += new ItemClickEventHandler(this.barButtonItemQueryKindLDBH_ItemClick);
                this.barButtonItemQueryKindXB.ItemClick += new ItemClickEventHandler(this.barButtonItemQueryKindXB_ItemClick);
                this.barButtonItemReportHZ.ItemClick += new ItemClickEventHandler(this.barButtonItemReportHZ_ItemClick);
                this.barButtonItemChartHZ.ItemClick += new ItemClickEventHandler(this.barButtonItemChartHZ_ItemClick);
                this.barButtonItemHZInfoTable.ItemClick += new ItemClickEventHandler(this.barButtonItemHZInfoTable_ItemClick);
                this.barButtonItemReportZH.ItemClick += new ItemClickEventHandler(this.barButtonItemReportZH_ItemClick);
                this.barButtonItemReportAJ.ItemClick += new ItemClickEventHandler(this.barButtonItemReportAJ_ItemClick);
                this.barButtonItemReportZZY.ItemClick += new ItemClickEventHandler(this.barButtonItemReportZZY_ItemClick);
                this.barButtonItemReportZZY2.ItemClick += new ItemClickEventHandler(this.barButtonItemReportZZY2_ItemClick);
                this.barButtonItemReportZZY3.ItemClick += new ItemClickEventHandler(this.barButtonItemReportZZY3_ItemClick);
                this.barButtonItemReportLD.ItemClick += new ItemClickEventHandler(this.barButtonItemReportLD_ItemClick);
                this.barButtonItemReportGYL.ItemClick += new ItemClickEventHandler(this.barButtonItemReportGYL_ItemClick);
                this.barButtonItemExit.ItemClick += new ItemClickEventHandler(this.barButtonItemExit_ItemClick);
                base.xtraTabMain.SelectedPageChanged += new TabPageChangedEventHandler(this.xtraTabMain_SelectedPageChanged);
                this.userControlLayerControl.treeList1.MouseMove += new MouseEventHandler(this.userControlLayerControltreeList1_MouseMove);
                this.userControlLayerControl.treeList1.MouseDown += new MouseEventHandler(this.userControlLayerControltreeList1_MouseDown);
                this.barButtonItemMapSet.ItemClick += new ItemClickEventHandler(this.barButtonItemMapSet_ItemClick);

                Tuple<string, bool> tup = DMM.PreparePathInfo(mEditKind);
                this.sMxdPath = tup.Item1;
                this.bDefaultPath = tup.Item2;

                FileInfo info = new FileInfo(this.sMxdPath);
                if (info.Exists)
                {
                    m_log.Warn("start load Map:" + sMxdPath);
                    //此处执行实际的加载MXD文档
                    //IPageLayoutControl3接口提供对控制PageLayoutControl的成员的访问。IPageLayoutControl3接口为使用键盘和鼠标导航PageLayoutControl的显示相关任务提供了额外的成员。
                    //LoadMxFile():将指定的地图文档加载到页面布局控件中包含的页面布局中。
                    (base.PageLayoutControlEdit.Object as IPageLayoutControl3).LoadMxFile(this.sMxdPath, null);
                    this.m_controlsSynchronizer2.SetMapOfPagelayoutToMap();
                    this.m_controlsSynchronizer2.ActivateMap();
                    m_log.Warn("end load Map");
                }
                else
                {
                    MessageBox.Show("地图数据加载失败，文件 " + sMxdPath + " 错误。", "提示", MessageBoxButtons.OK);
                }
                ///当文件不在本地时加载航空影像
                ////if (UtilFactory.GetConfigOpt().GetConfigValue("MapDBkey") != "Local")
                ////{
                ////    this.AddEviaTiledSatellite();
                ////}
                #region 连接SQLServerSDE需要改变
                if (UtilFactory.GetConfigOpt().GetConfigValue("MapDBkey") != "SqlServer")
                {
                    this.AddEviaTiledSatellite();
                }
                #endregion
                this.InitializeEditValue(false);
                base.axTOCControl.SetBuddyControl(base.MapControlEdit);
                base.axTOCControl.EnableLayerDragDrop = true;
                base.axTOCControl.Enabled = true;
                base.axTOCControl.LabelEdit = esriTOCControlEdit.esriTOCControlAutomatic;
                base.axTOCControl.LayerVisibilityEdit = esriTOCControlEdit.esriTOCControlAutomatic;
                base.barEditItemScale.EditValue = this.GetMapScale(base.MapControlEdit.Map);
                if (this.userControlInfo.hook == null)
                {
                    this.userControlInfo.hook = base.MapControlEdit.Object;
                }
                this.userControlInfo.EditLayer = this.mEditLayer;
                this.userControlInfo.InitialControls(this.mEditKind);
                this.SetPageLayoutValues();
                this.mSelection = false;
            }
            catch (Exception exception)
            {
                this.mSelection = false;
                this.mErrOpt.ErrorOperate(this.mSubSysName, "GXFormMainFrame.FormMainEdit", "InitializeGISControls", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        /// <summary>
        /// DB2数据库图层模型管理类：获取DB数据库Server服务
        /// </summary>
        private DB2LayerModelManager DMM
        {
            get { return DBServiceFactory<DB2LayerModelManager>.Service; }
        }

        /// <summary>
        /// 初始化同步IMapControl4，必须同步，因为如果不加载视图，将无法进行视图操作和根据视图有关的所有操作
        /// </summary>
        protected void InitSynchronizer()
        {
            try
            {
                IMapControl4 mapControl = base.MapControlEdit.Object as IMapControl4;
                base.PageLayoutControlEdit.Visible = true;
                //IPageLayoutControl3接口提供对控制PageLayoutControl的成员的访问。IPageLayoutControl3接口为使用键盘和鼠标导航PageLayoutControl的显示相关任务提供了额外的成员。
                IPageLayoutControl3 pageLayoutControl = base.PageLayoutControlEdit.Object as IPageLayoutControl3;
                this.m_controlsSynchronizer2 = new ControlsSynchronizer(mapControl, pageLayoutControl);
                this.m_controlsSynchronizer2.AddFrameworkControl(base.axTOCControl.Object);
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "GXFormMainFrame.FormMainEdit", "InitSynchronizer", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        /// <summary>
        /// 定时器的响应事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        private void MapControlEdit_Leave(object sender, EventArgs e)
        {
            base.ribbon.SetPopupContextMenu(this, null);
        }

        /// <summary>
        /// 
        /// IMapControlEvents2.OnAfterDraw事件地图绘制指定的视图阶段之后触发。
        /// 在Map的屏幕显示上绘制了指定的阶段之后，OnAfterDraw事件被触发，并且基于IActiveViewEvents :: AfterDraw事件。
        /// 您必须查询IDisplay界面的界面，并将viewDrawPhase基于esriViewDrawPhase常量。
        /// 在某些情况下，可能需要在地图中的每个单独图层绘制后执行一些代码。为此，您需要将IViewManager :: VerboseEvents属性设置为true，并使用IActiveViewEvents :: AfterItemDraw事件。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// 在地图视图界面鼠标当移动到指定的对象时，显示各种坐标信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
            catch (Exception ex)
            {
                m_log.Error(ex.Message + "-" + ex.StackTrace);

            }
        }

        /// <summary>
        /// 在地图视图界面当鼠标按键被松开时触发，
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MapControlEdit_OnMouseUp(object sender, IMapControlEvents2_OnMouseUpEvent e)
        {
            if (base.xtraTabMain.SelectedTabPageIndex == 0)//当视图界面为IMapControl时
            {
                this.RefreshToolBarButton(false);
                if (((base.MapControlEdit.CurrentTool.ToString() == "ESRI.ArcGIS.Controls.ControlsEditingEditToolClass") && (this.mFormVertexList != null)) && this.mFormVertexList.Visible)
                {
                    this.mFormVertexList.Init();
                }
            }
        }

        /// <summary>
        /// 该方法在指定阶段绘制后触发
        /// </summary>
        /// <param name="Display"></param>
        /// <param name="phase"></param>
        private void OnActiveViewEventsAfterDraw(IDisplay Display, esriViewDrawPhase phase)
        {
        }

        private void OnActiveViewEventsItemAdded(object Item)
        {
            base.axTOCControl.SetBuddyControl(base.MapControlEdit);
            base.axTOCControl.Update();
        }

        /// <summary>
        /// AfterItemDraw事件在单个视图项目绘制后触发。
        /// </summary>
        /// <param name="Index"></param>
        /// <param name="Display"></param>
        /// <param name="phase"></param>
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
                    IMapFrame frame = (IMapFrame)base.PageLayoutControlEdit.FindElementByName(name);
                    if (frame != null)
                    {
                        IActiveView map = (IActiveView)frame.Map;
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
                    base.textBox1.Width = 84;
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

        /// <summary>
        /// 出版视图页面的双击事件。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PgaeLayoutControl_DbClick(object sender, IPageLayoutControlEvents_OnDoubleClickEvent e)
        {
            AxPageLayoutControl control = sender as AxPageLayoutControl;
            IPageLayoutControl3 pPageLayout = control.Object as IPageLayoutControl3;
            new ElementManager().SetProperty(pPageLayout, e.pageX, e.pageY);
        }

        /// <summary>
        /// 刷新工具栏按钮
        /// </summary>
        /// <param name="flag"></param>
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

        private void SelectFeature(IFeatureLayer pFLayer, IFeature pFeature)
        {
            (pFLayer as IFeatureSelection).Clear();
            if ((pFLayer != null) && (pFeature != null))
            {
                base.MapControlEdit.Map.SelectFeature(pFLayer, pFeature);
            }
        }

        /// <summary>
        /// 设置“查询界面”按钮的可操作性
        /// </summary>
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

        /// <summary>
        /// 设置顶部工具栏按钮
        /// </summary>
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
        /// <summary>
        /// 设置不同的主题采用不同的功能
        /// </summary>
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
                this.barButtonItemSave.Visibility = BarItemVisibility.Never;
                if (this.mEditKind == "造林")
                {
                    this.mEditKind2 = "ZaoLin";
                    this.barButtonItemXBUpdate.Visibility = BarItemVisibility.Never;
                    this.barButtonItemQueryXB.Visibility = BarItemVisibility.Never;
                    this.barButtonItemQueryZT.Visibility = BarItemVisibility.Always;
                    this.barButtonItemQueryZT.Description = "征占用数据查询";
                    this.barButtonItemQueryYear.Visibility = BarItemVisibility.Never;
                    this.ribbonPageGroupZL.Visible = true;
                    this.ribbonPageGroupZZY.Visible = false;
                    this.ribbonPageGroupHZ.Visible = false;
                    this.ribbonPageGroupCF.Visible = false;
                    this.ribbonPageGroupAJ.Visible = false;
                    this.ribbonPageGroupZH.Visible = false;
                    this.ribbonPageGroupReportXB.Visible = false;
                    this.barButtonItemDC.Visibility = BarItemVisibility.Never;
                    this.barButtonItemSJ.Visibility = BarItemVisibility.Never;
                    this.barButtonItemZTT.Visibility = BarItemVisibility.Always;
                }
                else if (this.mEditKind == "采伐")
                {
                    this.mEditKind2 = "CaiFa";
                    this.barButtonItemXBUpdate.Visibility = BarItemVisibility.Never;
                    this.barButtonItemQueryXB.Visibility = BarItemVisibility.Never;
                    this.barButtonItemQueryZT.Visibility = BarItemVisibility.Always;
                    this.barButtonItemQueryYear.Visibility = BarItemVisibility.Never;
                    this.ribbonPageGroupCF.Visible = true;
                    this.ribbonPageGroupZZY.Visible = false;
                    this.ribbonPageGroupHZ.Visible = false;
                    this.ribbonPageGroupZL.Visible = false;
                    this.ribbonPageGroupAJ.Visible = false;
                    this.ribbonPageGroupZH.Visible = false;
                    this.ribbonPageGroupReportXB.Visible = false;
                    this.barButtonItemDC.Visibility = BarItemVisibility.Never;
                    this.barButtonItemSJ.Visibility = BarItemVisibility.Never;
                    this.barButtonItemZTT.Visibility = BarItemVisibility.Always;
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
                    this.ribbonPageGroupCF.Visible = false;
                    this.ribbonPageGroupZZY.Visible = true;
                    this.ribbonPageGroupHZ.Visible = false;
                    this.ribbonPageGroupZL.Visible = false;
                    this.ribbonPageGroupAJ.Visible = false;
                    this.ribbonPageGroupZH.Visible = false;
                    this.ribbonPageGroupReportXB.Visible = false;
                    this.barButtonItemSJ.Down = false;
                    this.barButtonItemDC.Down = true;
                    this.barButtonItemSJ.Caption = "位置图";
                    this.barButtonItemSJ.Visibility = BarItemVisibility.Always;
                    this.barButtonItemDC.Caption = "调查图";
                    this.barButtonItemDC.Visibility = BarItemVisibility.Always;
                    this.barButtonItemDC.Visibility = BarItemVisibility.Never;
                    this.barButtonItemSJ.Visibility = BarItemVisibility.Never;
                    this.barButtonItemZTT.Visibility = BarItemVisibility.Always;
                }
                else if (this.mEditKind.Contains("火灾"))
                {
                    this.mEditKind2 = "Fire";
                    this.ribbonPageGroupHZ.Visible = true;
                    this.barButtonItemXBUpdate.Visibility = BarItemVisibility.Never;
                    this.barButtonItemQueryXB.Visibility = BarItemVisibility.Never;
                    this.barButtonItemQueryZT.Visibility = BarItemVisibility.Always;
                    this.barButtonItemHZInfoTable.Visibility = BarItemVisibility.Always;
                    this.ribbonPageGroupCF.Visible = false;
                    this.ribbonPageGroupZZY.Visible = false;
                    this.ribbonPageGroupHZ.Visible = true;
                    this.ribbonPageGroupZL.Visible = false;
                    this.ribbonPageGroupAJ.Visible = false;
                    this.ribbonPageGroupZH.Visible = false;
                    this.ribbonPageGroupReportXB.Visible = false;
                    this.barButtonItemDC.Visibility = BarItemVisibility.Never;
                    this.barButtonItemSJ.Visibility = BarItemVisibility.Never;
                    this.barButtonItemZTT.Visibility = BarItemVisibility.Always;
                }
                else if (this.mEditKind.Contains("自然灾害"))
                {
                    this.mEditKind2 = "ZRZH";
                    this.barButtonItemXBUpdate.Visibility = BarItemVisibility.Never;
                    this.barButtonItemQueryXB.Visibility = BarItemVisibility.Never;
                    this.barButtonItemQueryZT.Visibility = BarItemVisibility.Always;
                    this.ribbonPageGroupCF.Visible = false;
                    this.ribbonPageGroupZZY.Visible = false;
                    this.ribbonPageGroupHZ.Visible = false;
                    this.ribbonPageGroupZL.Visible = false;
                    this.ribbonPageGroupAJ.Visible = false;
                    this.ribbonPageGroupZH.Visible = true;
                    this.ribbonPageGroupReportXB.Visible = false;
                    this.barButtonItemDC.Visibility = BarItemVisibility.Never;
                    this.barButtonItemSJ.Visibility = BarItemVisibility.Never;
                    this.barButtonItemZTT.Visibility = BarItemVisibility.Always;
                }
                else if (this.mEditKind.Contains("案件"))
                {
                    this.mEditKind2 = "AnJian";
                    this.barButtonItemXBUpdate.Visibility = BarItemVisibility.Never;
                    this.barButtonItemQueryXB.Visibility = BarItemVisibility.Never;
                    this.barButtonItemQueryZT.Visibility = BarItemVisibility.Always;
                    this.ribbonPageGroupCF.Visible = false;
                    this.ribbonPageGroupZZY.Visible = false;
                    this.ribbonPageGroupHZ.Visible = false;
                    this.ribbonPageGroupZL.Visible = false;
                    this.ribbonPageGroupAJ.Visible = true;
                    this.ribbonPageGroupZH.Visible = false;
                    this.ribbonPageGroupReportXB.Visible = false;
                    this.barButtonItemDC.Visibility = BarItemVisibility.Never;
                    this.barButtonItemSJ.Visibility = BarItemVisibility.Never;
                    this.barButtonItemZTT.Visibility = BarItemVisibility.Always;
                }
                else if (this.mEditKind == "小班变更")
                {
                    this.mEditKind2 = "XB";
                    this.ribbonPageGroupMxt.Visible = true;
                    this.barButtonItemDC.Visibility = BarItemVisibility.Never;
                    this.barButtonItemSJ.Visibility = BarItemVisibility.Never;
                    this.ribbonPageGroupCaoTu.Visible = true;
                    if (this.barButtonItemInputZT.Down)
                    {
                        this.xtraTabPageXBchange.PageVisible = true;
                    }
                    this.barButtonItemInput.Visibility = BarItemVisibility.Never;
                    this.barButtonItemQueryXB.Visibility = BarItemVisibility.Always;
                    this.barButtonItemQueryZT.Visibility = BarItemVisibility.Never;
                    this.ribbonPageGroupCF.Visible = false;
                    this.ribbonPageGroupZZY.Visible = false;
                    this.ribbonPageGroupHZ.Visible = false;
                    this.ribbonPageGroupZL.Visible = false;
                    this.ribbonPageGroupAJ.Visible = false;
                    this.ribbonPageGroupZH.Visible = false;
                }
                else if (this.mEditKind == "年度小班")
                {
                    this.mEditKind2 = "XB";
                    this.ribbonPageGroupQuery2.Text = "专题数据查询";
                    this.ribbonPageGroupMxt.Visible = true;
                    this.barButtonItemDC.Visibility = BarItemVisibility.Never;
                    this.barButtonItemSJ.Visibility = BarItemVisibility.Never;
                    this.barButtonItemSave.Visibility = BarItemVisibility.Always;
                    this.ribbonPageGroupXB.Visible = true;
                    this.barButtonItemInput.Visibility = BarItemVisibility.Never;
                    this.barButtonItemQueryZT.Visibility = BarItemVisibility.Never;
                    this.barButtonItemQueryKind.Visibility = BarItemVisibility.Never;
                    this.barButtonItemQueryXB.Visibility = BarItemVisibility.Always;
                    this.barButtonItemQueryKindZL.Visibility = BarItemVisibility.Always;
                    this.barButtonItemQueryKindCF.Visibility = BarItemVisibility.Always;
                    this.barButtonItemQueryKindHZ.Visibility = BarItemVisibility.Always;
                    this.barButtonItemQueryKindZH.Visibility = BarItemVisibility.Always;
                    this.barButtonItemQueryKindAJ.Visibility = BarItemVisibility.Always;
                    this.barButtonItemQueryKindZZY.Visibility = BarItemVisibility.Always;
                    this.barButtonItemQueryKindXB.Visibility = BarItemVisibility.Always;
                    this.barButtonItemQueryKindLDBH.Visibility = BarItemVisibility.Always;
                    //this.ribbonPageGroupCF.Visible = true;
                    this.ribbonPageGroupZZY.Visible = true;
                    //this.ribbonPageGroupHZ.Visible = true;
                    this.ribbonPageGroupZL.Visible = true;
                    //this.ribbonPageGroupAJ.Visible = true;
                    //this.ribbonPageGroupZH.Visible = true;
                    //this.ribbonPageGroupLD.Visible = true;
                    this.ribbonPageGroupGYL.Visible = true;
                    this.ribbonPageGroupReportXB.Visible = true;
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "GXFormMainFrame.FormMainEdit", "SetButtonVisible", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }
        /// <summary>
        /// 设置窗体主题名称
        /// </summary>
        private void SetFormText()
        {
            try
            {
                string systemName = UtilFactory.GetConfigOpt().GetSystemName();
                if (this.mEditKind == "小班")
                {
                    this.Text = systemName + " — 查询统计";
                    base.barStaticItemInfo.Caption = "就绪";
                }
                else
                {
                    string taskState = this.GetTaskState(EditTask.TaskState);
                    if (TaskManageClass.TaskState == TaskState.Open)
                    {
                        if (this.mEditKind == "年度小班")
                        {
                            this.Text = systemName + " — 查询统计";
                        }
                        else
                        {
                            this.Text = systemName + " — " + this.mEditKind + "专题查询统计";
                            base.barStaticItemInfo.Caption = EditTask.TaskName;
                        }
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
                            IFrameElement element4 = (IFrameElement)element2;
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
                                    string distName = "";
                                    if (EditTask.DistCode.Length == 6)
                                    {
                                        distName = this.GetDistName(EditTask.DistCode);
                                    }
                                    else if (EditTask.DistCode.Length == 9)
                                    {
                                        distName = this.GetDistName(EditTask.DistCode.Substring(0, 6)) + this.GetDistName(EditTask.DistCode);
                                    }
                                    else if (EditTask.DistCode.Length == 12)
                                    {
                                        distName = this.GetDistName(EditTask.DistCode.Substring(0, 6)) + this.GetDistName(EditTask.DistCode.Substring(0, 9)) + this.GetDistName(EditTask.DistCode.Substring(0, 12));
                                    }
                                    if (element5.Text.Contains("位置图") && (this.mEditKind == "征占用"))
                                    {
                                        element5.Text = distName + EditTask.TaskYear + "年林地征占用位置图";
                                    }
                                    else if (element5.Text.Contains("调查图") && (this.mEditKind == "征占用"))
                                    {
                                        element5.Text = distName + EditTask.TaskYear + "年林地征占用调查图";
                                    }
                                    else if (element5.Text.Contains("专题图"))
                                    {
                                        element5.Text = distName + EditTask.TaskYear + "年" + this.mEditKind + "专题图";
                                    }
                                    else if (element5.Text.Contains("设计图"))
                                    {
                                        element5.Text = EditTask.TaskYear + "年" + distName + this.mEditKind + "作业设计图";
                                    }
                                    else if (element5.Text.Contains("调查图"))
                                    {
                                        element5.Text = EditTask.TaskYear + "年" + distName + this.mEditKind + "外业调查图";
                                    }
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
                    image = new Bitmap(UtilFactory.GetConfigOpt().RootPath + @"\" + UtilFactory.GetConfigOpt().GetConfigValue("SplashBmpPath"));
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
                        base.ribbon.SelectedPage = base.ribbonPageQuery;
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
                        base.PageLayoutControlEdit.BringToFront();
                        base.PageLayoutControlEdit.Dock = DockStyle.None;
                        base.PageLayoutControlEdit.Left = 1;
                        base.PageLayoutControlEdit.Top = 1;
                        base.PageLayoutControlEdit.Width = base.xtraTabMain.Width - 2;
                        base.PageLayoutControlEdit.Height = base.xtraTabMain.Height - 0x20;
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

        private void ZoomToFeature(IMap pMap, IFeature pFeature)
        {
            try
            {
                if ((pMap != null) && (pFeature != null))
                {
                    IGeometry shape = null;
                    IActiveView view = null;
                    IEnvelope envelope = null;
                    shape = pFeature.Shape;
                    if (shape.SpatialReference != pMap.SpatialReference)
                    {
                        shape.Project(pMap.SpatialReference);
                        shape.SpatialReference = pMap.SpatialReference;
                    }
                    envelope = new EnvelopeClass();
                    envelope = shape.Envelope;
                    view = pMap as IActiveView;
                    if (shape.GeometryType == esriGeometryType.esriGeometryPoint)
                    {
                        double num = 0.0;
                        double num2 = 0.0;
                        pMap.MapScale = 6000.0;
                        num = view.Extent.Width / 2.0;
                        num2 = view.Extent.Height / 2.0;
                        IPoint p = null;
                        p = shape as IPoint;
                        if ((num == 0.0) | (num2 == 0.0))
                        {
                            return;
                        }
                        envelope.Width = num;
                        envelope.Height = num2;
                        envelope.CenterAt(p);
                    }
                    else
                    {
                        envelope.Expand(1.2, 1.2, true);
                    }
                    if ((view.Extent.Width != envelope.Width) && (view.Extent.Height != envelope.Height))
                    {
                        view.Extent = envelope;
                        view.Refresh();
                    }
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "GXFormMainFrame.FormMainEdit", "ZoomToFeature", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void ZoomToGeometry(IMap pMap, IGeometry pGeometry)
        {
            try
            {
                if ((pMap != null) && (pGeometry != null))
                {
                    IActiveView view = null;
                    IEnvelope envelope = null;
                    envelope = new EnvelopeClass();
                    envelope = pGeometry.Envelope;
                    view = pMap as IActiveView;
                    if (pGeometry.GeometryType == esriGeometryType.esriGeometryPoint)
                    {
                        double num = 0.0;
                        double num2 = 0.0;
                        pMap.MapScale = 6000.0;
                        num = view.Extent.Width / 2.0;
                        num2 = view.Extent.Height / 2.0;
                        IPoint p = null;
                        p = pGeometry as IPoint;
                        if ((num == 0.0) | (num2 == 0.0))
                        {
                            return;
                        }
                        envelope.Width = num;
                        envelope.Height = num2;
                        envelope.CenterAt(p);
                    }
                    else
                    {
                        envelope.Expand(1.25, 1.25, true);
                    }
                    view.Extent = envelope;
                    view.Refresh();
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "GXFormMainFrame.FormMainEdit", "ZoomToGeometry", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }
       

     


        private void barButtonItemCX_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (this.barButtonItemCX.Down)
            {
                base.dockPanelToolbox.Visibility = DockVisibility.Visible;
                this.xtraTabPageCX.PageVisible = true;
                base.xtraTabToolbox.SelectedTabPage = this.xtraTabPageCX;
                this.userControlSelectByAttributes1.InitialValue(base.MapControlEdit.Object);
                //this.userControlSelectByAttributes1.ho
                //    .hook = base.MapControlEdit.Object;
            }
            else
            {
                this.xtraTabPageCX.PageVisible = false;
            }
        }

        private void barButtonReportCustom_ItemClick(object sender, ItemClickEventArgs e)
        {
            ReportCustom rpCoustom = new ReportCustom();
            rpCoustom.Show();
        }

        private void MapControlEdit_OnMouseDown(object sender, IMapControlEvents2_OnMouseDownEvent e)
        {

        }

        private void barButtonItemReportCF1_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void barEditItem2_EditValueChanged(object sender, EventArgs e)
        {

            IFeatureDataset df =  mFeatureWorkspace.OpenFeatureDataset("forest");
            IFeatureClassContainer fcc = (IFeatureClassContainer)df;
            try
            {
                IFeatureClass fc = fcc.get_ClassByName("FOR_XIAOBAN_" + ((BarEditItem)sender).EditValue);
                IMap pMap = base.MapControlEdit.Map;
                IFeatureLayer fy = (IFeatureLayer)GISFunFactory.LayerFun.FindLayer(pMap as IBasicMap, "年度小班", true);
                fy.FeatureClass = fc;
                ((IActiveView)pMap).Refresh();
            }
            catch {
                XtraMessageBox.Show("该年度数据并未录入", "错误");
                return;
            }
 
 
        
        }

    }
}

