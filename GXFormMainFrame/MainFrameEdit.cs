namespace GXFormMainFrame
{
    using AttributesEdit;
    using Cartography;
    using Cartography.Base;
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
    using ESRI.ArcGIS.ADF.COMSupport;
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
    using GX_DB_INFO;
    using gylandzzytj;
    using LDZY_ZTZL;
    using LDZY_ZTZZ;
    using MainFrameBase;
    using Measure;
    using OperateLog;
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
    using System.Data.SqlClient;
    using System.Diagnostics;
    using System.Drawing;
    using System.IO;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;
    using TaskManage;
    using td.db.mid.sys;
    using td.db.orm;
    using td.logic.sys;

    using TopologyCheck.Checker;
    using TopologyCheck.UI;
    using Utilities;
    using VgsTiledMap.Ags;
    using VgsTiledMap.Ags.VgsTile.Configs;
    using td.forest.task.linker;
    using td.db.etl.zl;
    using td.db.etl.ldzy;
    using td.db.etl.aj;
    using td.db.etl.zh;
    using jn.isos.log;
    using td.forest.report;
    using GXFormMainFrame.etl.zz;

    /// <summary>
    /// "造林"数据编辑窗体
    /// </summary>
    public class MainFrameEdit : RibbonFormFrame4
    {
        private IToolbarControl _editMapToolBar = new ToolbarControlClass();
        private BarButtonGroup barButtonGroup1;
        private BarButtonItem barButtonItem_Auto;
        private BarButtonItem barButtonItem_Coordinate;
        private BarButtonItem barButtonItem_TF;
        private BarButtonItem barButtonItem_XZ;
        private BarButtonItem barButtonItem_XZ2;
        private BarButtonItem barButtonItem4;
        private BarButtonItem barButtonItemAddDRG;
        private BarButtonItem barButtonItemAddFeature;
        private BarButtonItem barButtonItemAddLayer;
        private BarButtonItem barButtonItemAddLayer2;
        private BarButtonItem barButtonItemAddLayer3;
        private BarButtonItem barButtonItemAddLine;
        private BarButtonItem barButtonItemArea;
        private BarButtonItem barButtonItemAutoComplete;
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
        private BarButtonItem barButtonItemCheckXCPolygon;
        private BarButtonItem barButtonItemClearSelectFeature;
        private BarButtonItem barButtonItemClearTopErr;
        private BarButtonItem barButtonItemCombineFeature;
        private BarButtonItem barButtonItemCopyHarvest;
        private BarButtonItem barButtonItemCreateByPolygon;
        private BarButtonItem barButtonItemCreateByPolygon2;
        private BarButtonItem barButtonItemCutFeature;
        private BarButtonItem barButtonItemDC;
        private BarButtonItem barButtonItemDeleteFeature;
        private BarButtonItem barButtonItemDesignQuery;
        private BarButtonItem barButtonItemEditFeature;
        private BarButtonItem barButtonItemEditRedo;
        private BarButtonItem barButtonItemEditUndo;
        private BarButtonItem barButtonItemEraseFeature;
        private BarButtonItem barButtonItemExit;
        private BarButtonItem barButtonItemExplode;
        private BarButtonItem barButtonItemExportImage;
        private BarButtonItem barButtonItemExportSub;
        private BarButtonItem barButtonItemExportXM;
        private BarButtonItem barButtonItemExportZT;
        private BarButtonItem barButtonItemFireTable;
        private BarButtonItem barButtonItemForward;
        private BarButtonItem barButtonItemFullMap;
        private BarButtonItem barButtonItemGrowthModel;
        private BarButtonItem barButtonItemHZInfoTable;
        private BarButtonItem barButtonItemIdentify;
        private BarButtonItem barButtonItemIdentify2;
        private BarButtonItem barButtonItemImport;
        private BarButtonItem barButtonItemImportRedline;
        private BarButtonItem barButtonItemInput;
        private BarButtonItem barButtonItemInputDC;
        private BarButtonItem barButtonItemInputEL;
        private BarButtonItem barButtonItemInputGYL;
        private BarButtonItem barButtonItemInputOther;
        private BarButtonItem barButtonItemInputProperties;
        private BarButtonItem barButtonItemInputProperty;
        private BarButtonItem barButtonItemInputPropertyList;
        private BarButtonItem barButtonItemInputYG;
        private BarButtonItem barButtonItemInputZT;
        private BarButtonItem barButtonItemLargeButton;
        private BarButtonItem barButtonItemLayerCombine;
        private BarButtonItem barButtonItemLinkageAdd;
        private BarButtonItem barButtonItemLinkageDelete;
        private BarButtonItem barButtonItemLinkageEdit;
        private BarButtonItem barButtonItemLinZu;
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
        private BarButtonItem barButtonItemMapText;
        private BarButtonItem barButtonItemMeasure;
        private BarButtonItem barButtonItemNessRule;
        private BarButtonItem barButtonItemOpen;
        private BarButtonItem barButtonItemOpen2;
        private BarButtonItem barButtonItemOutCFTable;
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
        private BarButtonItem barButtonItemPan2;
        private BarButtonItem barButtonItemPlace;
        private BarButtonItem barButtonItemPointDelete;
        private BarButtonItem barButtonItemPrint;
        private BarButtonItem barButtonItemPrintPreview;
        private BarButtonItem barButtonItemPrintSet;
        private BarButtonItem barButtonItemProjectList;
        private BarButtonItem barButtonItemPropertyByXB;
        private BarButtonItem barButtonItemQueryKind;
        private BarButtonItem barButtonItemQueryTF;
        private BarButtonItem barButtonItemQueryXB;
        private BarButtonItem barButtonItemQueryYear;
        private BarButtonItem barButtonItemQueryZT;
        private BarButtonItem barButtonItemQuickSnap;
        private BarButtonItem barButtonItemRedo;
        private BarButtonItem barButtonItemRefresh;
        private BarButtonItem barButtonItemReportAJ;
        private BarButtonItem barButtonItemReportCF;
        private BarButtonItem barButtonItemReportCF1;
        private BarButtonItem barButtonItemReportFCDC;
        private BarButtonItem barButtonItemReportHZ;
        private BarButtonItem barButtonItemReportHZKind;
        private BarButtonItem barButtonItemReportHZRegion;
        private BarButtonItem barButtonItemReportZH;
        private BarButtonItem barButtonItemReportZL;
        private BarButtonItem barButtonItemReportZZY1;
        private BarButtonItem barButtonItemReportZZY2;
        private BarButtonItem barButtonItemReportZZY3;
        private BarButtonItem barButtonItemSave;
        private BarButtonItem barButtonItemSaveEdit;
        private BarButtonItem barButtonItemScaleText;
        private BarButtonItem barButtonItemSelectByAttributes;
        private BarButtonItem barButtonItemSelectedFeaturesReport;
        private BarButtonItem barButtonItemSelectElement;
        private BarButtonItem barButtonItemSelectFeature;
        private BarButtonItem barButtonItemSelectLayerSet;
        private BarButtonItem barButtonItemSetSpatialreference;
        private BarButtonItem barButtonItemShapeCopy;
        private BarButtonItem barButtonItemShapePaste;
        private BarButtonItem barButtonItemSimplify;
        private BarButtonItem barButtonItemSingleCheck;
        private BarButtonItem barButtonItemSJ;
        private BarButtonItem barButtonItemSmallButton;
        private BarButtonItem barButtonItemSmallText;
        private BarButtonItem barButtonItemSmoothPolygon;
        private BarButtonItem barButtonItemSplitFeature;
        private BarButtonItem barButtonItemSSA;
        private BarButtonItem barButtonItemStatic;
        private BarButtonItem barButtonItemTOC;
        private BarButtonItem barButtonItemTOC2;
        private BarButtonItem barButtonItemTopModify;
        private BarButtonItem barButtonItemTotalLayer;
        private BarButtonItem barButtonItemUndo;
        private BarButtonItem barButtonItemVertexDelete;
        private BarButtonItem barButtonItemVertexInsert;
        private BarButtonItem barButtonItemVertexList;
        private BarButtonItem barButtonItemXBEdit;
        private BarButtonItem barButtonItemXBSet;
        private BarButtonItem barButtonItemXBUpdate;
        private BarButtonItem barButtonItemXJ;
        private BarButtonItem barButtonItemZoomIn;
        private BarButtonItem barButtonItemZoomOut;
        private BarButtonItem barButtonItemZTT;
        private BarButtonItem barButtonToolbox;
        private BarButtonItem barButtonToolView;
        private BarEditItem barEditItem_fx;
        private BarEditItem barEditItem1;
        private BarEditItem barEditItem2;
        private BarEditItem barEditItem3;
        private BarEditItem barEditItemEditLayer;
        private BarEditItem barEditItemEditLayer0;
        private BarSubItem barSubItemButtonStyle;
        private BarButtonItem bbiLoadTempalte;
        private BarButtonItem bbiSaveTemplate;
        private bool bDefaultPath = true;
        private BarSubItem bsi_Coordinate;
        private BarSubItem bsiNormal;
        private IContainer components = null;
        public FormLogin4 FormSplash;
        public FormLogin5 FormSplash5;
        public FormLogin6 FormSplash6;
        private bool HasLayerResource = true;
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
        private IFeature m_CountyFeature = null;
        private IFeatureLayer m_pCLayer = null;
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
        public T_EDITTASK_ZT_Mid m_project = null;
        private IElement mElement;
        private IElement mElement2;
        private ErrorOpt mErrOpt = UtilFactory.GetErrorOpt();
        private IFeatureWorkspace mFeatureWorkspace = null;
        private bool mFirstFlag = true;
        private FormVertexList mFormVertexList = null;
        private bool mInUse;
        protected IList<ILayer> mLayerList = new List<ILayer>(30);
        private IFeatureLayer[] mLinkageLayer = null;
        private bool MouseOn = false;
        private static Process mProcess = null;
        private RibbonItemStyles mRibbonItemStyles = RibbonItemStyles.Default;
        private bool mSelection;
        private string mSubSysName = UtilFactory.GetConfigOpt().GetSystemName();
        private System.Drawing.Point p;
        private PopupMenu popupMenuEdit;
        private PopupMenu popupMenuLinkage;
        private PopupMenu popupMenuMapView;
        private PopupMenu popupMenuVertex;
        private RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private RepositoryItemCheckEdit repositoryItemCheckEdit2;
        private RepositoryItemCheckEdit repositoryItemCheckEdit3;
        private RepositoryItemComboBox repositoryItemComboBox2;
        private RepositoryItemComboBox repositoryItemComboBox3;
        private RepositoryItemComboBox repositoryItemComboBox4;
        private RepositoryItemComboBox repositoryItemComboBox5;
        private RepositoryItemComboBox repositoryItemComboBox6;
        private RepositoryItemComboBox repositoryItemComboBox7;
        private RepositoryItemPictureEdit repositoryItemPictureEdit1;
        private RepositoryItemRadioGroup repositoryItemRadioGroup1;
        private RepositoryItemRadioGroup repositoryItemRadioGroup2;
        private RepositoryItemRadioGroup repositoryItemRadioGroup3;
        private RepositoryItemRadioGroup repositoryItemRadioGroup4;
        private RepositoryItemRadioGroup repositoryItemRadioGroup5;
        private RepositoryItemRadioGroup repositoryItemRadioGroup6;
        private RepositoryItemRadioGroup repositoryItemRadioGroup7;
        private RepositoryItemRadioGroup repositoryItemRadioGroup8;
        private RepositoryItemTextEdit repositoryItemTextEdit1;
        private int ribbonindex = -1;
        private RibbonPageGroup ribbonPageGroupAddnew;
        private RibbonPageGroup ribbonPageGroupAJ;
        private RibbonPageGroup ribbonPageGroupCaoTu;
        private RibbonPageGroup ribbonPageGroupCF;
        private RibbonPageGroup ribbonPageGroupCommEdit;
        private RibbonPageGroup ribbonPageGroupDelete;
        private RibbonPageGroup ribbonPageGroupEdit;
        private RibbonPageGroup ribbonPageGroupEditLayer;
        private RibbonPageGroup ribbonPageGroupEdittool;
        private RibbonPageGroup ribbonPageGroupHZ;
        private RibbonPageGroup ribbonPageGroupImportBack;
        private RibbonPageGroup ribbonPageGroupInputTable;
        private RibbonPageGroup ribbonPageGroupLogic;
        private RibbonPageGroup ribbonPageGroupMapView;
        private RibbonPageGroup ribbonPageGroupMapView2;
        private RibbonPageGroup ribbonPageGroupMapView3;
        private RibbonPageGroup ribbonPageGroupMapView4;
        private RibbonPageGroup ribbonPageGroupMxt;
        private RibbonPageGroup ribbonPageGroupPageTool;
        private RibbonPageGroup ribbonPageGroupPageView;
        private RibbonPageGroup ribbonPageGroupProject;
        private RibbonPageGroup ribbonPageGroupQuery;
        private RibbonPageGroup ribbonPageGroupQuery2;
        private RibbonPageGroup ribbonPageGroupQueryComm;
        private RibbonPageGroup ribbonPageGroupReportXB;
        private RibbonPageGroup ribbonPageGroupToplogic;
        private RibbonPageGroup ribbonPageGroupToplogic2;
        private RibbonPageGroup ribbonPageGroupTopoModify;
        private RibbonPageGroup ribbonPageGroupXB;
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
        private UserControlAttriList userControlAttriList1;
        private UserControlConvertData userControlConvertData;
        private UserControlDesignList userControlDesignList1;
        private UserControlFireManage userControlFireManage1;
        private UserControlImageGeoReference2 userControlImageGeoReference1;
        private UserControlImportLC userControlImportLC1;
        private UserControlInfo userControlInfo;
        private UserControlInputData2 userControlInputData;
        private UserControlInputGYL userControlInputGYL1;
        private UserControlInputYG userControlInputYG1;
        private UserControlLayerControl userControlLayerControl;
        private UserControlLocation userControlLocation;
        private UserControlMapFind userControlMapFind1;
        private UserControlOverView userControlOverView;
        private UserControlPlace userControlPlace1;
        private UserControlProjectList userControlProjectList1;
        private UserControlQueryAJ userControlQueryAJ1;
        private UserControlQueryCF userControlQueryCF1;
        private UserControlQueryCF2 userControlQueryCF21;
        private UserControlQueryDesign userControlQueryDesign1;
        private UserControlQueryHZ userControlQueryHZ1;
        private UserControlQueryHZ2 userControlQueryHZ21;
        private QueryCommon.UserControlQueryResult userControlQueryResult1;
        private QueryCommon.UserControlQueryResult userControlQueryResult2;
        private UserControlQueryTFH userControlQueryTFH1;
        private UserControlQueryXB userControlQueryXB;
        private UserControlQueryXB2 userControlQueryXB21;
        private UserControlQueryYG userControlQueryYG;
        private UserControlQueryZH userControlQueryZH1;
        private UserControlQueryZL userControlQueryZL1;
        private UserControlQueryZZY userControlQueryZZY1;
        private UserControlQueryZZY2 userControlQueryZZY21;
        private UserControlSelectByAttributes userControlSelectByAttributes;
        private UserControlSelectFeatureResport2 userControlSelectFeatureResport21;
        private UserControlSelectLayerSet userControlSelectLayerSet1;
        private UserControlTaskInfo userControlTaskInfo1;
        private UserControlUpdate userControlUpdate1;
        private UserControlUpdateAS2 userControlUpdateAS21;
        private UserControlXBGrowth userControlXBGrowth1;
        private UserControlXBLayerCombine userControlXBLayerCombine1;
        private UserControlXBSet userControlXBSet1;
        private UserControlXBSet userControlXBSet21;
        private UserControlXBSet3 userControlXBSet31;
        private XtraTabControl xtraTabControlEdit;
        private XtraTabPage xtraTabPage1;
        private XtraTabPage xtraTabPage2;
        private XtraTabPage xtraTabPage3;
        private XtraTabPage xtraTabPage4;
        private XtraTabPage xtraTabPageAddRasterlayer;
        private XtraTabPage xtraTabPageAttribute;
        private XtraTabPage xtraTabPageAttriList;
        private XtraTabPage xtraTabPageConvertData;
        private XtraTabPage xtraTabPageDesign;
        private XtraTabPage xtraTabPageFireManage;
        private XtraTabPage xtraTabPageInputData;
        private XtraTabPage xtraTabPageKind;
        private XtraTabPage xtraTabPageLocation;
        private XtraTabPage xtraTabPageLogicCheck;
        private XtraTabPage xtraTabPageMapFind;
        private XtraTabPage xtraTabPagePlace;
        private XtraTabPage xtraTabPageProject;
        private XtraTabPage xtraTabPageSelect;
        private XtraTabPage xtraTabPageSelectByAttributes;
        private XtraTabPage xtraTabPageTFH;
        private XtraTabPage xtraTabPageUpdate;
        private XtraTabPage xtraTabPageXBchange;
        private XtraTabControl xtraTabQuery;
        private Logger m_log = LoggerManager.CreateLogger("UI", typeof(MainFrameEdit));
        public MainFrameEdit()
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

        private void AddEviaTiledSatellite()
        {
            try
            {
                IMap pMap = base.MapControlEdit.Map;
                IGroupLayer pGl = GISFunFactory.LayerFun.FindLayer(pMap as IBasicMap, "影像", true) as IGroupLayer;
                string configValue = UtilFactory.GetConfigOpt().GetConfigValue("MapServerPath");
                string sAliasName = "卫星影像";
                int iYear = 0;
                EnumArcVgsTileLayer eviaTiledSatellite = EnumArcVgsTileLayer.EviaTiledSatellite;
                if (pGl != null)
                {
                    this.AddVgsLayer(pMap, pGl, configValue, sAliasName, iYear, eviaTiledSatellite);
                }
                pGl = GISFunFactory.LayerFun.FindLayer(pMap as IBasicMap, "扫描图", true) as IGroupLayer;
                if (pGl == null)
                {
                    pGl = GISFunFactory.LayerFun.FindLayer(pMap as IBasicMap, "地形图", true) as IGroupLayer;
                }
                if (pGl == null)
                {
                    pGl = GISFunFactory.LayerFun.FindLayer(pMap as IBasicMap, "工作底图", true) as IGroupLayer;
                }
                if (pGl != null)
                {
                    pGl.Name = "工作底图";
                    base.axTOCControl.Update();
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
            try
            {
                this.MouseOn = false;
                Control control = null;
                base.ribbon.GetPopupContextMenu(control);
                if (control != null)
                {
                    base.ribbon.SetPopupContextMenu(this, null);
                }
                AxTOCControl control2 = sender as AxTOCControl;
                control2.SetBuddyControl(base.MapControlEdit);
                control2.Update();
                esriTOCControlItem esriTOCControlItemNone = esriTOCControlItem.esriTOCControlItemNone;
                IBasicMap basicMap = null;
                ILayer layer = null;
                object unk = null;
                object data = null;
                control2.HitTest(e.x, e.y, ref esriTOCControlItemNone, ref basicMap, ref layer, ref unk, ref data);
                if ((e.button == 2) && (esriTOCControlItemNone == esriTOCControlItem.esriTOCControlItemLayer))
                {
                    base.ribbon.SetPopupContextMenu(this, null);
                    TocMenu menu = new TocMenu(control2.Object as ITOCControl2);
                    control2.SelectItem(layer, null);
                    control2.CustomProperty = layer;
                    menu.ShowMenu(e.x, e.y, control2.hWnd);
                }
                else
                {
                    base.ribbon.SetPopupContextMenu(this, null);
                }
            }
            catch (Exception)
            {
            }
        }

        private void axTOCControl_OnMouseMove(object sender, ITOCControlEvents_OnMouseMoveEvent e)
        {
            this.MouseOn = false;
        }

        private void barButtonItem_Auto_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                AxPageLayoutControl pageLayoutControlEdit = base.PageLayoutControlEdit;
                ElementManager manager = new ElementManager();
                manager.CreateCoordinate(pageLayoutControlEdit.PageLayout);
                manager.Dispose();
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "GXFormMainFrame.FormMainEdit", "barButtonItem_Auto_ItemClick", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void barButtonItem_XZ_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                this.mSelection = true;
                AxPageLayoutControl pageLayoutControlEdit = base.PageLayoutControlEdit;
                ElementManager manager = new ElementManager();
                TableInfo pTableInfo = new TableInfo();
                if (Cartography.Template.TemplateInfo.CurrentTemplateInfo == null)
                {
                    XtraMessageBox.Show("请选择专题图类型！", "提示");
                }
                else
                {
                    if ((Cartography.Template.TemplateInfo.CurrentTemplateInfo.TemplateBusiness == BusinessType.CaiFaDC) || (Cartography.Template.TemplateInfo.CurrentTemplateInfo.TemplateBusiness == BusinessType.ZaoLinDC))
                    {
                        pTableInfo.GraphType = "Survey";
                        pTableInfo.UseSelection = true;
                    }
                    else if ((Cartography.Template.TemplateInfo.CurrentTemplateInfo.TemplateBusiness == BusinessType.CaiFaSJ) || (Cartography.Template.TemplateInfo.CurrentTemplateInfo.TemplateBusiness == BusinessType.ZaoLinSJ))
                    {
                        pTableInfo.GraphType = "Design";
                        pTableInfo.UseSelection = true;
                    }
                    if (EditTask.KindCode.StartsWith("02"))
                    {
                        pTableInfo.SectionName = "HAR";
                    }
                    else if (EditTask.KindCode.StartsWith("01"))
                    {
                        pTableInfo.SectionName = "AFF";
                    }
                    pTableInfo.Custom = false;
                    manager.CreateTableEx(pageLayoutControlEdit.PageLayout, pTableInfo);
                    manager.Dispose();
                    this.mSelection = false;
                }
            }
            catch (Exception exception)
            {
                this.mSelection = false;
                MessageBox.Show(exception.Message, "制图", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                this.mErrOpt.ErrorOperate(this.mSubSysName, "GXFormMainFrame.FormMainEdit", "barButtonItem_XZ_ItemClick", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void barButtonItem_XZ2_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                this.mSelection = true;
                AxPageLayoutControl pageLayoutControlEdit = base.PageLayoutControlEdit;
                ElementManager manager = new ElementManager();
                TableInfo pTableInfo = new TableInfo
                {
                    GraphType = "Custom"
                };
                if (EditTask.KindCode.StartsWith("02"))
                {
                    pTableInfo.SectionName = "HAR";
                }
                else if (EditTask.KindCode.StartsWith("01"))
                {
                    pTableInfo.SectionName = "AFF";
                }
                else if (EditTask.KindCode.StartsWith("05"))
                {
                    pTableInfo.SectionName = "HZ";
                }
                else if (EditTask.KindCode.StartsWith("04"))
                {
                    pTableInfo.SectionName = "ZZY";
                }
                else if (EditTask.KindCode.StartsWith("06"))
                {
                    pTableInfo.SectionName = "ZH";
                }
                else if (EditTask.KindCode.StartsWith("07"))
                {
                    pTableInfo.SectionName = "AJ";
                }
                pTableInfo.UseSelection = true;
                pTableInfo.Custom = true;
                manager.CreateTable(pageLayoutControlEdit.PageLayout, pTableInfo);
                manager.Dispose();
                this.mSelection = false;
            }
            catch (Exception exception)
            {
                this.mSelection = false;
                MessageBox.Show(exception.Message, "制图", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                this.mErrOpt.ErrorOperate(this.mSubSysName, "GXFormMainFrame.FormMainEdit", "barButtonItem_XZ2_ItemClick", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
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
                if (base.dockPanelToolbox.Width < 0x124)
                {
                    base.dockPanelToolbox.Width = 0x124;
                }
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

        private void barButtonItemCF_ItemClick(object sender, ItemClickEventArgs e)
        {
            ReportEntry entry = new ReportEntry();
            ReportParamter pReportParamter = new ReportParamter
            {
                TaskID = "TASK_ID='" + EditTask.TaskID.ToString() + "'",
                TaskName = "采伐",
                Year = EditTask.TaskYear,
                SysType = Report.SystemType.FQSJ,
                FeatureLayer = EditTask.EditLayer
            };
            entry.Show(pReportParamter);
        }

        private void barButtonItemCF1_ItemClick(object sender, ItemClickEventArgs e)
        {
            ReportEntry entry = new ReportEntry();
            ReportParamter pReportParamter = new ReportParamter
            {
                TaskName = "采伐",
                Year = EditTask.TaskYear,
                SysType = Report.SystemType.ZYGL
            };
            entry.Show(pReportParamter);
        }

        private void barButtonItemChartCF_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmCFStatis statis = new FrmCFStatis();
            statis.InitialValue(this.mEditKind, this.mEditKind2, EditTask.DistCode, EditTask.LayerName);
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
            statis.InitialValue(this.mEditKind, this.mEditKind2, EditTask.DistCode, EditTask.LayerName);
            statis.ShowDialog(this);
        }

        /// <summary>
        /// 编辑--自动生成的响应事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItemCreateByPolygon_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                IFeature pFeature = null;
                if (base.MapControlEdit.Map.SelectionCount != 1)
                {
                    MessageBox.Show("请先选择一块多边形", "数据编辑", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    ArrayList selectionLayerCollection = this.GetSelectionLayerCollection(base.MapControlEdit.Map);
                    if (selectionLayerCollection == null)
                    {
                        MessageBox.Show("请先选择一块多边形", "数据编辑", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else if (selectionLayerCollection.Count != 1)
                    {
                        MessageBox.Show("请先选择一块多边形", "数据编辑", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else
                    {
                        for (int i = 0; i < selectionLayerCollection.Count; i++)
                        {
                            IFeatureLayer layer = selectionLayerCollection[i] as IFeatureLayer;
                            IFeatureSelection selection = layer as IFeatureSelection;
                            ISelectionSet selectionSet = null;
                            selectionSet = selection.SelectionSet;
                            ICursor cursor = null;
                            selectionSet.Search(null, false, out cursor);
                            pFeature = (cursor as IFeatureCursor).NextFeature();
                            if (pFeature == null)
                            {
                                MessageBox.Show("请先选择一块多边形", "数据编辑", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                return;
                            }
                            IGeometry shapeCopy = pFeature.ShapeCopy;
                            IEnvelope envelope = GISFunFactory.UnitFun.ConvertPoject(shapeCopy, base.MapControlEdit.Map.SpatialReference).Envelope;
                            envelope.Expand(1.2, 1.2, true);
                            base.MapControlEdit.ActiveView.FullExtent = envelope;
                            base.MapControlEdit.ActiveView.Refresh();
                        }
                        string configValue = UtilFactory.GetConfigOpt().GetConfigValue("XiaobanLayerName");
                        IFeatureLayer layer2 = GISFunFactory.LayerFun.FindFeatureLayer(base.MapControlEdit.Map as IBasicMap, configValue, true);
                        if (layer2 == null)
                        {
                            MessageBox.Show("无二类小班图层不能自动生成", "数据编辑", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                        else
                        {
                            this.Cursor = Cursors.WaitCursor;
                            Editor.UniqueInstance.StartEditOperation();
                            IGeometry geometry2 = pFeature.ShapeCopy;
                            if (geometry2.SpatialReference != (layer2.FeatureClass as IGeoDataset).SpatialReference)
                            {
                                geometry2.Project((layer2.FeatureClass as IGeoDataset).SpatialReference);
                            }
                            ISpatialFilter filter = new SpatialFilterClass
                            {
                                Geometry = geometry2,
                                GeometryField = layer2.FeatureClass.ShapeFieldName,
                                SpatialRel = esriSpatialRelEnum.esriSpatialRelOverlaps
                            };
                            GC.Collect();
                            IFeatureCursor pFCursor = null;
                            pFCursor = layer2.FeatureClass.Search(filter, false);
                            IFeature pf = pFCursor.NextFeature();
                            this.ClipXBCreateFeature(pFCursor, pf, pFeature);
                            filter.SpatialRel = esriSpatialRelEnum.esriSpatialRelContains;
                            GC.Collect();
                            pFCursor = layer2.FeatureClass.Search(filter, false);
                            pf = pFCursor.NextFeature();
                            this.ClipXBCreateFeature(pFCursor, pf, pFeature);
                            filter.SpatialRel = esriSpatialRelEnum.esriSpatialRelWithin;
                            GC.Collect();
                            pFCursor = layer2.FeatureClass.Search(filter, false);
                            pf = pFCursor.NextFeature();
                            this.ClipXBCreateFeature(pFCursor, pf, pFeature);
                            Editor.UniqueInstance.StopEditOperation();
                            this.Cursor = Cursors.Default;
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                this.Cursor = Cursors.Default;
                if (Editor.UniqueInstance.IsBeingEdited)
                {
                    Editor.UniqueInstance.StopEditOperation();
                }
                this.mErrOpt.ErrorOperate(this.mSubSysName, "GXFormMainFrame.FormMainEdit", "barButtonItemCreateByPolygon_ItemClick", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        /// <summary>
        /// 编辑--批量裁切：构造器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItemCreateByPolygon2_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                string configValue = UtilFactory.GetConfigOpt().GetConfigValue("XiaobanLayerName");
                if (GISFunFactory.LayerFun.FindFeatureLayer(base.MapControlEdit.Map as IBasicMap, configValue, true) == null)
                {
                    MessageBox.Show("无二类小班图层不能根据小班自动裁切", "数据编辑", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    new FormClipByXB(base.MapControlEdit.Object, this.mEditKind).ShowDialog(this);
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "GXFormMainFrame.FormMainEdit", "barButtonItemCreateByPolygon2_ItemClick", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void barButtonItemDC_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.barButtonItemDC.Down = true;
            if (this.barButtonItemDC.Down)
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
                if ((EditTask.TaskName == "采伐") || (EditTask.KindCode.Substring(0, 2) == "02"))
                {
                    pInfo.TemplateBusiness = BusinessType.CaiFaDC;
                }
                else if ((EditTask.TaskName == "造林") || (EditTask.KindCode.Substring(0, 2) == "01"))
                {
                    pInfo.TemplateBusiness = BusinessType.ZaoLinDC;
                }
                else if ((EditTask.TaskName == "征占用") || (EditTask.KindCode.Substring(0, 2) == "04"))
                {
                    pInfo.TemplateBusiness = BusinessType.ZZDC;
                }
                Cartography.Template.TemplateInfo.CurrentTemplateInfo = pInfo;
                manager.TemplateCarto(base.PageLayoutControlEdit.Object as IPageLayoutControl3, pInfo);
                this.SetPageLayoutValues();
            }
        }

        private void barButtonItemDesignQuery_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (this.barButtonItemDesignQuery.Down)
            {
                base.dockPanelToolbox.Visibility = DockVisibility.Visible;
                this.xtraTabPageDesign.PageVisible = true;
                base.xtraTabToolbox.SelectedTabPage = this.xtraTabPageDesign;
                this.userControlQueryDesign1.BringToFront();
                this.userControlQueryDesign1.InitialValue(base.MapControlEdit.Object, this.mEditKind, this.userControlQueryResult1, base.dockPanelBottom);
                this.userControlQueryDesign1.SetQuery(true);
            }
            else if (!this.barButtonItemDesignQuery.Down)
            {
                this.xtraTabPageDesign.PageVisible = false;
            }
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

        private void barButtonItemExportSub_ItemClick(object sender, ItemClickEventArgs e)
        {
        }

        private void barButtonItemExportXM_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (EditTask.KindCode.Substring(0, 2) == "02")
            {
                FormHarvest harvest = new FormHarvest();
                if (EditTask.KindCode.Length < 3)
                {
                    harvest.Init(base.MapControlEdit.Object, "export", false);
                    harvest.ShowDialog();
                }
                else
                {
                    harvest.Init(base.MapControlEdit.Object, "export", true);
                    harvest.ShowDialog();
                }
            }
            else if (EditTask.KindCode.Substring(0, 2) == "04")
            {
                FormZZ mzz = new FormZZ();
                if (EditTask.KindCode.Length < 3)
                {
                    mzz.Init(base.MapControlEdit.Object, "export", false);
                    mzz.ShowDialog();
                }
                else
                {
                    mzz.Init(base.MapControlEdit.Object, "export", true);
                    mzz.ShowDialog();
                }
            }
        }

        private void barButtonItemExportZT_ItemClick(object sender, ItemClickEventArgs e)
        {
        }

        private void barButtonItemFireTable_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (this.barButtonItemFireTable.Down)
            {
                this.userControlFireManage1.Init();
                this.xtraTabPageFireManage.PageVisible = true;
                this.xtraTabControlEdit.SelectedTabPage = this.xtraTabPageFireManage;
                base.dockPanelEdit.Visibility = DockVisibility.Visible;
                base.dockPanelEdit.Width = 490;
            }
            else
            {
                this.xtraTabPageFireManage.PageVisible = false;
                base.dockPanelEdit.Visibility = DockVisibility.Hidden;
            }
        }

        private void barButtonItemFullMap_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (this.m_CountyFeature == null)
            {
                string configValue = UtilFactory.GetConfigOpt().GetConfigValue("CountyLayerName");
                this.m_pCLayer = GISFunFactory.LayerFun.FindFeatureLayer(base.MapControlEdit.Map as IBasicMap, configValue, true);
                if (this.m_pCLayer != null)
                {
                    GC.Collect();
                    IQueryFilter queryFilter = new QueryFilterClass();
                    string str2 = UtilFactory.GetConfigOpt().GetConfigValue("CountyFieldCode");
                    queryFilter.WhereClause = str2 + "='" + EditTask.DistCode.Substring(0, 6) + "'";
                    this.m_CountyFeature = this.m_pCLayer.Search(queryFilter, false).NextFeature();
                }
            }
            if (this.m_CountyFeature != null)
            {
                if (base.xtraTabMain.SelectedTabPageIndex == 0)
                {
                    this.ZoomToFeature(base.MapControlEdit.Map, this.m_CountyFeature);
                }
                else if (base.xtraTabMain.SelectedTabPageIndex == 1)
                {
                    this.ZoomToFeature(base.PageLayoutControlEdit.ActiveView.FocusMap, this.m_CountyFeature);
                }
            }
        }

        private void barButtonItemGrowthModel_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (this.barButtonItemGrowthModel.Down)
            {
                TaskManageClass.SetEditLayer(this.mEditKind + "年度", EditTask.TaskYear, base.MapControlEdit.Map);
                this.mEditLayer = EditTask.EditLayer;
                this.barButtonItemInputOther.Down = false;
                this.barButtonItemInputDC.Down = false;
                this.barButtonItemInputZT.Down = false;
                this.barButtonItemInputYG.Down = false;
                this.barButtonItemXBEdit.Down = false;
                this.barButtonItemInputEL.Down = false;
                this.barButtonItemSSA.Down = false;
                this.userControlXBGrowth1.Visible = true;
                this.userControlXBGrowth1.BringToFront();
                this.userControlXBGrowth1.panelIDList.Visible = false;
                this.userControlXBGrowth1.Hook(base.MapControlEdit.Object, this.mEditLayer, this.userControlQueryResult1, this.userControlQueryResult2, base.dockPanelBottom);
                this.xtraTabPageXBchange.Text = "年度";
                this.xtraTabPageXBchange.PageVisible = true;
                base.xtraTabToolbox.SelectedTabPageIndex = this.xtraTabPageXBchange.TabIndex;
                base.xtraTabToolbox.SelectedTabPageIndex = this.xtraTabPageXBchange.TabIndex;
                this.barButtonItemInputZT.Enabled = false;
                this.barButtonItemInputYG.Enabled = false;
                this.barButtonItemInputDC.Enabled = false;
                this.barButtonItemInputOther.Enabled = false;
                this.barButtonItemLayerCombine.Enabled = false;
                this.barButtonItemGrowthModel.Enabled = true;
                this.barButtonItemInputEL.Enabled = false;
                this.barButtonItemXBEdit.Enabled = false;
                this.barButtonItemSSA.Enabled = false;
                this.barButtonItemArea.Enabled = false;
                this.barButtonItemXJ.Enabled = false;
                this.barButtonItemLinZu.Enabled = false;
                this.barButtonItemInputPropertyList.Enabled = false;
                this.barButtonItemSaveEdit.Enabled = false;
            }
            else
            {
                this.xtraTabPageXBchange.PageVisible = false;
                base.xtraTabToolbox.SelectedTabPageIndex = 0;
                this.barButtonItemInputYG.Enabled = true;
                this.barButtonItemInputDC.Enabled = true;
                this.barButtonItemInputOther.Enabled = true;
                this.barButtonItemLayerCombine.Enabled = true;
                this.barButtonItemGrowthModel.Enabled = true;
                this.barButtonItemInputZT.Enabled = true;
                this.barButtonItemXBEdit.Enabled = true;
                this.barButtonItemInputEL.Enabled = true;
                this.barButtonItemSSA.Enabled = true;
                this.barButtonItemArea.Enabled = true;
                this.barButtonItemXJ.Enabled = true;
                this.barButtonItemLinZu.Enabled = true;
                this.barButtonItemInputPropertyList.Enabled = false;
                this.barButtonItemSaveEdit.Enabled = false;
            }
        }

        private void barButtonItemHZInfoTable_ItemClick(object sender, ItemClickEventArgs e)
        {
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

        private void barButtonItemImport_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (EditTask.KindCode.Substring(0, 2) == "02")
            {
                if (EditTask.KindCode.Length > 2)
                {
                    MessageBox.Show("请关闭当前作业设计后再导入！", "提示");
                }
                else
                {
                    FormHarvest harvest = new FormHarvest();
                    harvest.Init(base.MapControlEdit.Object, "import");
                    harvest.ShowDialog();
                }
            }
            else if (EditTask.KindCode.Substring(0, 2) == "04")
            {
                if (EditTask.KindCode.Length > 2)
                {
                    MessageBox.Show("请关闭当前项目后再导入！", "提示");
                }
                else
                {
                    FormZZ mzz = new FormZZ();
                    mzz.Init(base.MapControlEdit.Object, "import");
                    mzz.ShowDialog();
                }
            }
        }

        private void barButtonItemImportRedline_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                ILayer layer = new RedLineImport(base.MapControlEdit.Map.SpatialReference).OpenFile();
                if (layer != null)
                {
                    IFeatureLayer layer2 = layer as IFeatureLayer;
                    ISpatialReference spatialReference = null;
                    spatialReference = base.MapControlEdit.Map.SpatialReference;
                    layer2.SpatialReference = spatialReference;
                    IGroupLayer layer3 = GISFunFactory.LayerFun.FindLayer(base.MapControlEdit.Map as IBasicMap, "红线图", false) as IGroupLayer;
                    if (layer3 == null)
                    {
                        if (GISFunFactory.LayerFun.AddGroupLayer(base.MapControlEdit.Map as IBasicMap, null, "红线图"))
                        {
                            layer3 = GISFunFactory.LayerFun.FindLayer(base.MapControlEdit.Map as IBasicMap, "红线图", false) as IGroupLayer;
                            layer3.Add(layer);
                        }
                        else
                        {
                            base.MapControlEdit.AddLayer(layer);
                        }
                    }
                    else
                    {
                        layer3.Add(layer);
                    }
                    IEnvelope pGeometry = null;
                    if (layer is IFeatureLayer)
                    {
                        IFeatureLayer layer4 = layer as IFeatureLayer;
                        int num = layer4.FeatureClass.FeatureCount(null);
                        pGeometry = layer4.AreaOfInterest;
                    }
                    else
                    {
                        IDataset dataset = layer as IDataset;
                        IGeoDataset dataset2 = dataset as IGeoDataset;
                        pGeometry = dataset2.Extent;
                    }
                    this.ZoomToGeometry(base.MapControlEdit.Map, pGeometry);
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "GXFormMainFrame.FormMainEdit", "barButtonItemImportRedline_ItemClick", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void barButtonItemInput_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.barButtonItemInput.ButtonStyle = BarButtonStyle.Check;
            if (this.barButtonItemInput.Down)
            {
                this.userControlInputData.Visible = true;
                this.userControlInputData.Hook(base.MapControlEdit.Object, this.mEditKind, this.barButtonItemInput);
                this.xtraTabPageInputData.PageVisible = true;
                this.xtraTabControlEdit.SelectedTabPage = this.xtraTabPageInputData;
                if (this.barButtonItemAddFeature.Down)
                {
                    ItemClickEventArgs args = new ItemClickEventArgs(this.barButtonItemAddFeature, this.barButtonItemAddFeature.Links[0]);
                    this.ribbon_ItemPress(sender, args);
                    base.MapControlEdit.CurrentTool = null;
                    this.RefreshToolBarButton(false);
                }
                base.dockPanelEdit.Visibility = DockVisibility.Visible;
                IWorkspaceEdit mFeatureWorkspace = this.mFeatureWorkspace as IWorkspaceEdit;
                if (((TaskManageClass.TaskState.ToString() == TaskState.Open.ToString()) && mFeatureWorkspace.IsBeingEdited()) && Editor.UniqueInstance.IsBeingEdited)
                {
                    Editor.UniqueInstance.StopEdit();
                }
                this.barButtonItemCreateByPolygon.Enabled = false;
                this.barButtonItemCreateByPolygon2.Enabled = false;
                this.barButtonItemSmoothPolygon.Enabled = false;
                this.barButtonItemPropertyByXB.Enabled = false;
                this.barButtonItemInputPropertyList.Enabled = false;
                this.barButtonItemSaveEdit.Enabled = false;
            }
            else
            {
                if (EditTask.DistCode == "")
                {
                    EditTask.DistCode = UserInfo.DistCode;
                }
                string[] strArray = EditTask.DistCode.Split(new char[] { ',' });
                if (strArray.Length > 1)
                {
                    EditTask.DistCode = strArray[strArray.Length - 1];
                }
                string distCode = EditTask.DistCode;
                IEnvelope extent = base.MapControlEdit.ActiveView.Extent;
                this.InitializeBaseButtonEdit();
                this.InitializeBaseButtonPage();
                this.SetButtonVisible();
                this.barButtonItemCreateByPolygon.Enabled = true;
                this.barButtonItemCreateByPolygon2.Enabled = true;
                this.barButtonItemSmoothPolygon.Enabled = true;
                this.barButtonItemPropertyByXB.Enabled = true;
                this.barButtonItemInputPropertyList.Enabled = true;
                this.barButtonItemSaveEdit.Enabled = true;
                this.xtraTabPageInputData.PageVisible = false;
                bool flag = false;
                for (int i = 0; i < this.xtraTabControlEdit.TabPages.Count; i++)
                {
                    if (this.xtraTabControlEdit.TabPages[i].PageVisible)
                    {
                        flag = true;
                        break;
                    }
                }
                if (!flag)
                {
                    base.dockPanelEdit.Visibility = DockVisibility.Hidden;
                }
                EditTask.DistCode = distCode;
                string str2 = "";
                IFeatureLayerDefinition mEditLayer = null;
                if (EditTask.KindCode == "08")
                {
                    if (this.mEditLayer != null)
                    {
                        str2 = "((RENEW_STATE<> '1' and  RENEW_STATE<> '4' ) or RENEW_STATE is NULL ) AND CNTY = '" + EditTask.DistCode.Substring(0, 6) + "'";
                        if (EditTask.DistCode.Length > 6)
                        {
                            str2 = str2 + " AND TOWN= '" + EditTask.DistCode.Substring(0, 9) + "'";
                        }
                        if (EditTask.DistCode.Length > 9)
                        {
                            str2 = str2 + " AND VILL= '" + EditTask.DistCode.Substring(0, 12) + "'";
                        }
                        mEditLayer = (IFeatureLayerDefinition)this.mEditLayer;
                        mEditLayer.DefinitionExpression = str2;
                    }
                    if (this.mEditLayer2 != null)
                    {
                        str2 = "((RENEW_STATE like '1' or  RENEW_STATE like '4') and CNTY = '" + EditTask.DistCode.Substring(0, 6) + "') or ( CNTY <> '" + EditTask.DistCode.Substring(0, 6) + "')";
                        if (EditTask.DistCode.Length > 6)
                        {
                            str2 = str2 + " or ( TOWN <> '" + EditTask.DistCode.Substring(0, 9) + "')";
                        }
                        if (EditTask.DistCode.Length > 9)
                        {
                            str2 = str2 + " or ( VILL <> '" + EditTask.DistCode.Substring(0, 12) + "')";
                        }
                        mEditLayer = (IFeatureLayerDefinition)this.mEditLayer2;
                        mEditLayer.DefinitionExpression = str2;
                    }
                }
                base.MapControlEdit.ActiveView.FullExtent = extent;
                base.MapControlEdit.ActiveView.Refresh();
            }
        }

        private void barButtonItemInputDC_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (this.barButtonItemInputDC.Down)
            {
                this.barButtonItemLayerCombine.Down = false;
                this.barButtonItemInputOther.Down = false;
                this.barButtonItemInputZT.Down = false;
                this.barButtonItemInputYG.Down = false;
                this.barButtonItemXBEdit.Down = false;
                this.barButtonItemInputGYL.Down = false;
                this.xtraTabPageXBchange.PageVisible = true;
                base.xtraTabToolbox.SelectedTabPageIndex = this.xtraTabPageXBchange.TabIndex;
                this.userControlXBSet31.BringToFront();
                this.userControlXBSet31.panelIDList.Visible = true;
                base.xtraTabToolbox.SelectedTabPageIndex = this.xtraTabPageXBchange.TabIndex;
                this.Cursor = Cursors.WaitCursor;
                TaskManageClass.SetEditLayer(this.mEditKind, EditTask.TaskYear, base.MapControlEdit.Map);
                this.mEditLayer = EditTask.EditLayer;
                this.userControlXBSet31.Hook(base.MapControlEdit.Object, this.mEditLayer, this.userControlQueryResult1, this.userControlQueryResult2, base.dockPanelBottom);
                this.Cursor = Cursors.Default;
                this.InitializeBaseButtonEdit();
                this.InitializeBaseButtonPage();
                this.barButtonItemInputZT.Enabled = false;
                this.barButtonItemInputYG.Enabled = false;
                this.barButtonItemInputDC.Enabled = true;
                this.barButtonItemInputOther.Enabled = false;
                this.barButtonItemLayerCombine.Enabled = false;
                this.barButtonItemXBEdit.Enabled = false;
                this.barButtonItemInputGYL.Enabled = false;
                this.barButtonItemArea.Enabled = false;
                this.barButtonItemXJ.Enabled = false;
                this.barButtonItemLinZu.Enabled = false;
                this.barButtonItemCreateByPolygon.Enabled = true;
                this.barButtonItemCreateByPolygon2.Enabled = true;
                this.barButtonItemSmoothPolygon.Enabled = true;
                this.barButtonItemPropertyByXB.Enabled = true;
                this.barButtonItemInputPropertyList.Enabled = true;
                this.barButtonItemSaveEdit.Enabled = true;
            }
            else
            {
                IWorkspaceEdit editWorkspace = EditTask.EditWorkspace as IWorkspaceEdit;
                if (((TaskManageClass.TaskState.ToString() == TaskState.Open.ToString()) && editWorkspace.IsBeingEdited()) && Editor.UniqueInstance.IsBeingEdited)
                {
                    Editor.UniqueInstance.StopEdit();
                }
                this.xtraTabPageXBchange.PageVisible = false;
                base.xtraTabToolbox.SelectedTabPageIndex = 0;
                this.barButtonItemInputYG.Enabled = true;
                this.barButtonItemInputDC.Enabled = true;
                this.barButtonItemInputOther.Enabled = true;
                this.barButtonItemLayerCombine.Enabled = true;
                this.barButtonItemInputZT.Enabled = true;
                this.barButtonItemXBEdit.Enabled = true;
                this.barButtonItemInputGYL.Enabled = true;
                this.barButtonItemArea.Enabled = true;
                this.barButtonItemXJ.Enabled = true;
                this.barButtonItemLinZu.Enabled = true;
                this.barButtonItemCreateByPolygon.Enabled = false;
                this.barButtonItemCreateByPolygon2.Enabled = false;
                this.barButtonItemSmoothPolygon.Enabled = false;
                this.barButtonItemPropertyByXB.Enabled = false;
                this.barButtonItemInputPropertyList.Enabled = false;
                this.barButtonItemSaveEdit.Enabled = false;
            }
        }

        private void barButtonItemInputEL_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (this.mEditKind.Contains("二类变化"))
            {
                if (this.barButtonItemInputEL.Down)
                {
                    if (this.mEditLayer == null)
                    {
                        this.mEditLayer = EditTask.EditLayer;
                    }
                    this.barButtonItemInputOther.Down = false;
                    this.barButtonItemInputDC.Down = false;
                    this.barButtonItemInputZT.Down = false;
                    this.barButtonItemInputYG.Down = false;
                    this.barButtonItemXBEdit.Down = false;
                    this.barButtonItemGrowthModel.Down = false;
                    this.userControlImportLC1.Visible = true;
                    this.userControlImportLC1.BringToFront();
                    this.userControlImportLC1.Hook = base.MapControlEdit.Object;
                    this.userControlImportLC1.ImportType = 2;
                    this.xtraTabPageXBchange.Text = "二类";
                    this.xtraTabPageXBchange.PageVisible = true;
                    base.xtraTabToolbox.SelectedTabPageIndex = this.xtraTabPageXBchange.TabIndex;
                    base.xtraTabToolbox.SelectedTabPageIndex = this.xtraTabPageXBchange.TabIndex;
                    this.barButtonItemInputZT.Enabled = false;
                    this.barButtonItemInputYG.Enabled = false;
                    this.barButtonItemInputDC.Enabled = false;
                    this.barButtonItemInputOther.Enabled = false;
                    this.barButtonItemLayerCombine.Enabled = false;
                    this.barButtonItemGrowthModel.Enabled = false;
                    this.barButtonItemXBEdit.Enabled = false;
                    this.barButtonItemArea.Enabled = false;
                    this.barButtonItemXJ.Enabled = false;
                    this.barButtonItemLinZu.Enabled = false;
                    this.barButtonItemInputPropertyList.Enabled = false;
                    this.barButtonItemSaveEdit.Enabled = false;
                }
                else
                {
                    this.xtraTabPageXBchange.PageVisible = false;
                    base.xtraTabToolbox.SelectedTabPageIndex = 0;
                    this.barButtonItemInputYG.Enabled = true;
                    this.barButtonItemInputDC.Enabled = true;
                    this.barButtonItemInputOther.Enabled = true;
                    this.barButtonItemLayerCombine.Enabled = true;
                    this.barButtonItemGrowthModel.Enabled = true;
                    this.barButtonItemInputZT.Enabled = true;
                    this.barButtonItemXBEdit.Enabled = true;
                    this.barButtonItemArea.Enabled = true;
                    this.barButtonItemXJ.Enabled = true;
                    this.barButtonItemLinZu.Enabled = true;
                    this.barButtonItemInputPropertyList.Enabled = false;
                    this.barButtonItemSaveEdit.Enabled = false;
                }
            }
            else if (this.barButtonItemInputEL.Down)
            {
                if (this.mEditLayer == null)
                {
                    TaskManageClass.SetEditLayer(this.mEditKind + "年度", EditTask.TaskYear, base.MapControlEdit.Map);
                    this.mEditLayer = EditTask.EditLayer;
                }
                this.barButtonItemInputOther.Down = false;
                this.barButtonItemInputDC.Down = false;
                this.barButtonItemInputZT.Down = false;
                this.barButtonItemInputYG.Down = false;
                this.barButtonItemXBEdit.Down = false;
                this.barButtonItemGrowthModel.Down = false;
                this.barButtonItemSSA.Down = false;
                this.userControlImportLC1.Visible = true;
                this.userControlImportLC1.BringToFront();
                this.userControlImportLC1.Hook = base.MapControlEdit.Object;
                this.userControlImportLC1.ImportType = 1;
                this.xtraTabPageXBchange.Text = "年度";
                this.xtraTabPageXBchange.PageVisible = true;
                base.xtraTabToolbox.SelectedTabPageIndex = this.xtraTabPageXBchange.TabIndex;
                base.xtraTabToolbox.SelectedTabPageIndex = this.xtraTabPageXBchange.TabIndex;
                this.barButtonItemInputZT.Enabled = false;
                this.barButtonItemInputYG.Enabled = false;
                this.barButtonItemInputDC.Enabled = false;
                this.barButtonItemInputOther.Enabled = false;
                this.barButtonItemLayerCombine.Enabled = false;
                this.barButtonItemGrowthModel.Enabled = false;
                this.barButtonItemSSA.Enabled = false;
                this.barButtonItemXBEdit.Enabled = false;
                this.barButtonItemArea.Enabled = false;
                this.barButtonItemXJ.Enabled = false;
                this.barButtonItemLinZu.Enabled = false;
                this.barButtonItemInputPropertyList.Enabled = false;
                this.barButtonItemSaveEdit.Enabled = false;
            }
            else
            {
                this.xtraTabPageXBchange.PageVisible = false;
                base.xtraTabToolbox.SelectedTabPageIndex = 0;
                this.barButtonItemInputYG.Enabled = true;
                this.barButtonItemInputDC.Enabled = true;
                this.barButtonItemInputOther.Enabled = true;
                this.barButtonItemLayerCombine.Enabled = true;
                this.barButtonItemGrowthModel.Enabled = true;
                this.barButtonItemSSA.Enabled = true;
                this.barButtonItemInputZT.Enabled = true;
                this.barButtonItemXBEdit.Enabled = true;
                this.barButtonItemArea.Enabled = true;
                this.barButtonItemXJ.Enabled = true;
                this.barButtonItemLinZu.Enabled = true;
                this.barButtonItemInputPropertyList.Enabled = false;
                this.barButtonItemSaveEdit.Enabled = false;
            }
        }

        private void barButtonItemInputGYL_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (this.barButtonItemInputGYL.Down)
            {
                this.barButtonItemLayerCombine.Down = false;
                this.barButtonItemInputDC.Down = false;
                this.barButtonItemInputZT.Down = false;
                this.barButtonItemInputYG.Down = false;
                this.barButtonItemXBEdit.Down = false;
                this.barButtonItemInputOther.Down = false;
                this.userControlInputGYL1.Visible = true;
                this.userControlInputGYL1.BringToFront();
                this.xtraTabPageXBchange.PageVisible = true;
                base.xtraTabToolbox.SelectedTabPageIndex = this.xtraTabPageXBchange.TabIndex;
                this.Cursor = Cursors.WaitCursor;
                this.userControlInputGYL1.Hook(base.MapControlEdit.Object, this.m_CountyFeature, this.userControlQueryResult1, this.userControlQueryResult2, base.dockPanelBottom);
                this.Cursor = Cursors.Default;
                this.barButtonItemInputZT.Enabled = false;
                this.barButtonItemInputYG.Enabled = false;
                this.barButtonItemInputDC.Enabled = false;
                this.barButtonItemInputOther.Enabled = false;
                this.barButtonItemLayerCombine.Enabled = false;
                this.barButtonItemXBEdit.Enabled = false;
                this.barButtonItemInputGYL.Enabled = true;
                this.barButtonItemInput.Enabled = false;
                this.barButtonItemXBUpdate.Visibility = BarItemVisibility.Never;
            }
            else
            {
                this.xtraTabPageXBchange.PageVisible = false;
                base.xtraTabToolbox.SelectedTabPageIndex = 0;
                IWorkspaceEdit editWorkspace = EditTask.EditWorkspace as IWorkspaceEdit;
                if (((TaskManageClass.TaskState.ToString() == TaskState.Open.ToString()) && editWorkspace.IsBeingEdited()) && Editor.UniqueInstance.IsBeingEdited)
                {
                    Editor.UniqueInstance.StopEdit();
                }
                this.barButtonItemInputZT.Enabled = true;
                this.barButtonItemInputYG.Enabled = true;
                this.barButtonItemInputDC.Enabled = true;
                this.barButtonItemInputOther.Enabled = true;
                this.barButtonItemLayerCombine.Enabled = true;
                this.barButtonItemXBEdit.Enabled = true;
                this.barButtonItemInputGYL.Enabled = true;
                this.barButtonItemArea.Enabled = true;
                this.barButtonItemXJ.Enabled = true;
                this.barButtonItemLinZu.Enabled = true;
                this.barButtonItemCreateByPolygon.Enabled = false;
                this.barButtonItemCreateByPolygon2.Enabled = false;
                this.barButtonItemSmoothPolygon.Enabled = false;
                this.barButtonItemPropertyByXB.Enabled = false;
                this.barButtonItemInputPropertyList.Enabled = false;
                this.barButtonItemSaveEdit.Enabled = false;
            }
        }

        private void barButtonItemInputOther_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (this.barButtonItemInputOther.Down)
            {
                TaskManageClass.SetEditLayer(this.mEditKind, EditTask.TaskYear, base.MapControlEdit.Map);
                this.mEditLayer = EditTask.EditLayer;
                this.barButtonItemLayerCombine.Down = false;
                this.barButtonItemInputDC.Down = false;
                this.barButtonItemInputZT.Down = false;
                this.barButtonItemInputYG.Down = false;
                this.barButtonItemXBEdit.Down = false;
                this.barButtonItemInputGYL.Down = false;
                this.InitializeBaseButtonEdit();
                this.InitializeBaseButtonPage();
                this.SetButtonVisible();
                this.barButtonItemInputZT.Enabled = false;
                this.barButtonItemInputYG.Enabled = false;
                this.barButtonItemInputDC.Enabled = false;
                this.barButtonItemInputOther.Enabled = true;
                this.barButtonItemLayerCombine.Enabled = false;
                this.barButtonItemXBEdit.Enabled = false;
                this.barButtonItemInputGYL.Enabled = false;
                this.barButtonItemArea.Enabled = false;
                this.barButtonItemXJ.Enabled = false;
                this.barButtonItemLinZu.Enabled = false;
                this.barButtonItemCreateByPolygon.Enabled = true;
                this.barButtonItemCreateByPolygon2.Enabled = true;
                this.barButtonItemSmoothPolygon.Enabled = true;
                this.barButtonItemPropertyByXB.Enabled = true;
                this.barButtonItemInputPropertyList.Enabled = true;
                this.barButtonItemSaveEdit.Enabled = true;
            }
            else
            {
                IWorkspaceEdit editWorkspace = EditTask.EditWorkspace as IWorkspaceEdit;
                if (((TaskManageClass.TaskState.ToString() == TaskState.Open.ToString()) && editWorkspace.IsBeingEdited()) && Editor.UniqueInstance.IsBeingEdited)
                {
                    Editor.UniqueInstance.StopEdit();
                }
                this.xtraTabPageXBchange.PageVisible = false;
                base.xtraTabToolbox.SelectedTabPageIndex = 0;
                this.barButtonItemInputYG.Enabled = true;
                this.barButtonItemInputDC.Enabled = true;
                this.barButtonItemInputOther.Enabled = true;
                this.barButtonItemLayerCombine.Enabled = true;
                this.barButtonItemInputZT.Enabled = true;
                this.barButtonItemXBEdit.Enabled = true;
                this.barButtonItemInputGYL.Enabled = true;
                this.barButtonItemArea.Enabled = true;
                this.barButtonItemXJ.Enabled = true;
                this.barButtonItemLinZu.Enabled = true;
                this.barButtonItemCreateByPolygon.Enabled = false;
                this.barButtonItemCreateByPolygon2.Enabled = false;
                this.barButtonItemSmoothPolygon.Enabled = false;
                this.barButtonItemPropertyByXB.Enabled = false;
                this.barButtonItemInputPropertyList.Enabled = false;
                this.barButtonItemSaveEdit.Enabled = false;
            }
        }

        /// <summary>
        /// 编辑--属性列表响应事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItemInputPropertyList_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (this.barButtonItemInputPropertyList.Down)
            {
                this.userControlAttriList1.Visible = true;
                this.userControlAttriList1.Init(base.MapControlEdit.Object);
                this.xtraTabPageAttriList.PageVisible = true;
                this.xtraTabControlEdit.SelectedTabPage = this.xtraTabPageAttriList;
                base.dockPanelEdit.Visibility = DockVisibility.Visible;
            }
            else
            {
                this.xtraTabPageAttriList.PageVisible = false;
            }
        }

        private void barButtonItemInputYG_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!this.barButtonItemInputYG.Down)
            {
                this.xtraTabPageXBchange.PageVisible = false;
                base.xtraTabToolbox.SelectedTabPageIndex = 0;
                this.barButtonItemInputZT.Enabled = true;
                this.barButtonItemInputYG.Enabled = true;
                this.barButtonItemInputDC.Enabled = true;
                this.barButtonItemInputOther.Enabled = true;
                this.barButtonItemLayerCombine.Enabled = true;
                this.barButtonItemXBEdit.Enabled = true;
                this.barButtonItemInputGYL.Enabled = true;
                this.barButtonItemArea.Enabled = true;
                this.barButtonItemXJ.Enabled = true;
                this.barButtonItemLinZu.Enabled = true;
                this.barButtonItemCreateByPolygon.Enabled = false;
                this.barButtonItemCreateByPolygon2.Enabled = false;
                this.barButtonItemSmoothPolygon.Enabled = false;
                this.barButtonItemPropertyByXB.Enabled = false;
                this.barButtonItemInputPropertyList.Enabled = false;
                this.barButtonItemSaveEdit.Enabled = false;
            }
            else
            {
                this.xtraTabPageXBchange.PageVisible = true;
                base.xtraTabToolbox.SelectedTabPage = this.xtraTabPageXBchange;
                this.userControlInputYG1.Visible = true;
                this.userControlInputYG1.BringToFront();
                this.barButtonItemLayerCombine.Down = false;
                this.barButtonItemInputOther.Down = false;
                this.barButtonItemInputDC.Down = false;
                this.barButtonItemInputZT.Down = false;
                this.barButtonItemXBEdit.Down = false;
                this.barButtonItemInputGYL.Down = false;
                this.barButtonItemInputZT.Enabled = false;
                this.barButtonItemInputYG.Enabled = true;
                this.barButtonItemInputDC.Enabled = false;
                this.barButtonItemInputOther.Enabled = false;
                this.barButtonItemLayerCombine.Enabled = false;
                this.barButtonItemXBEdit.Enabled = false;
                this.barButtonItemInputGYL.Enabled = false;
                this.barButtonItemArea.Enabled = false;
                this.barButtonItemXJ.Enabled = false;
                this.barButtonItemLinZu.Enabled = false;
                this.barButtonItemCreateByPolygon.Enabled = false;
                this.barButtonItemCreateByPolygon2.Enabled = false;
                this.barButtonItemSmoothPolygon.Enabled = false;
                this.barButtonItemPropertyByXB.Enabled = false;
                this.barButtonItemInputPropertyList.Enabled = false;
                this.barButtonItemSaveEdit.Enabled = false;
                this.Cursor = Cursors.WaitCursor;
                TaskManageClass.SetEditLayer(this.mEditKind, EditTask.TaskYear, base.MapControlEdit.Map);
                this.mEditLayer = EditTask.EditLayer;
                ArrayList underLayers = EditTask.UnderLayers;
                IFeatureLayer pYGLayer = null;
                string configValue = UtilFactory.GetConfigOpt().GetConfigValue("YGLayer");
                for (int i = 0; i < underLayers.Count; i++)
                {
                    pYGLayer = underLayers[i] as IFeatureLayer;
                    if ((pYGLayer.FeatureClass as IDataset).Name.Contains(configValue))
                    {
                        this.userControlInputYG1.Hook(base.MapControlEdit.Object, pYGLayer, this.m_CountyFeature, this.userControlQueryResult1, this.userControlQueryResult2, base.dockPanelBottom);
                        this.userControlInputYG1.InitialValue();
                        break;
                    }
                }
                TaskManageClass.SetEditLayer(this.mEditKind, EditTask.TaskYear, base.MapControlEdit.Map);
                this.Cursor = Cursors.Default;
                this.barButtonItemLayerCombine.Down = false;
                this.barButtonItemInputOther.Down = false;
                this.barButtonItemInputDC.Down = false;
                this.barButtonItemInputZT.Down = false;
            }
        }

        private void barButtonItemInputZT_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (this.barButtonItemInputZT.Down)
            {
                this.barButtonItemLayerCombine.Down = false;
                this.barButtonItemInputOther.Down = false;
                this.barButtonItemInputDC.Down = false;
                this.barButtonItemInputYG.Down = false;
                this.barButtonItemXBEdit.Down = false;
                this.barButtonItemInputGYL.Down = false;
                this.userControlXBSet21.Visible = true;
                this.userControlXBSet21.BringToFront();
                this.xtraTabPageXBchange.PageVisible = true;
                base.xtraTabToolbox.SelectedTabPageIndex = this.xtraTabPageXBchange.TabIndex;
                this.Cursor = Cursors.WaitCursor;
                TaskManageClass.SetEditLayer(this.mEditKind, EditTask.TaskYear, base.MapControlEdit.Map);
                this.mEditLayer = EditTask.EditLayer;
                this.userControlXBSet21.Hook(base.MapControlEdit.Object, this.mEditLayer, this.m_CountyFeature, this.userControlQueryResult1, this.userControlQueryResult2, base.dockPanelBottom);
                this.Cursor = Cursors.Default;
                this.barButtonItemInputYG.Enabled = false;
                this.barButtonItemInputDC.Enabled = false;
                this.barButtonItemInputOther.Enabled = false;
                this.barButtonItemLayerCombine.Enabled = false;
                this.barButtonItemInputGYL.Enabled = false;
                this.barButtonItemInput.Enabled = false;
                this.barButtonItemXBUpdate.Visibility = BarItemVisibility.Never;
            }
            else
            {
                this.xtraTabPageXBchange.PageVisible = false;
                base.xtraTabToolbox.SelectedTabPageIndex = 0;
                IWorkspaceEdit editWorkspace = EditTask.EditWorkspace as IWorkspaceEdit;
                if (((TaskManageClass.TaskState.ToString() == TaskState.Open.ToString()) && editWorkspace.IsBeingEdited()) && Editor.UniqueInstance.IsBeingEdited)
                {
                    Editor.UniqueInstance.StopEdit();
                }
                this.barButtonItemInputYG.Enabled = true;
                this.barButtonItemInputDC.Enabled = true;
                this.barButtonItemInputOther.Enabled = true;
                this.barButtonItemLayerCombine.Enabled = true;
                this.barButtonItemXBEdit.Enabled = true;
                this.barButtonItemInputGYL.Enabled = true;
                this.barButtonItemArea.Enabled = true;
                this.barButtonItemXJ.Enabled = true;
                this.barButtonItemLinZu.Enabled = true;
                this.barButtonItemCreateByPolygon.Enabled = false;
                this.barButtonItemCreateByPolygon2.Enabled = false;
                this.barButtonItemSmoothPolygon.Enabled = false;
                this.barButtonItemPropertyByXB.Enabled = false;
                this.barButtonItemInputPropertyList.Enabled = false;
                this.barButtonItemSaveEdit.Enabled = false;
            }
        }

        private void barButtonItemLargeButton_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.barButtonItemLargeButton.Down = true;
            this.mRibbonItemStyles = RibbonItemStyles.Large;//RibbonItemStyles.SmallWithText | RibbonItemStyles.Large;
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

        private void barButtonItemLayerCombine_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (this.barButtonItemLayerCombine.Down)
            {
                TaskManageClass.SetEditLayer(this.mEditKind + "年度", EditTask.TaskYear, base.MapControlEdit.Map);
                this.mEditLayer = EditTask.EditLayer;
                this.barButtonItemInputOther.Down = false;
                this.barButtonItemInputDC.Down = false;
                this.barButtonItemInputZT.Down = false;
                this.barButtonItemInputYG.Down = false;
                this.barButtonItemXBEdit.Down = false;
                this.barButtonItemGrowthModel.Down = false;
                this.barButtonItemInputEL.Down = false;
                this.barButtonItemSSA.Down = false;
                this.xtraTabPageXBchange.Text = "年度";
                this.xtraTabPageXBchange.PageVisible = true;
                base.xtraTabToolbox.SelectedTabPageIndex = this.xtraTabPageXBchange.TabIndex;
                base.xtraTabToolbox.SelectedTabPageIndex = this.xtraTabPageXBchange.TabIndex;
                this.userControlXBLayerCombine1.BringToFront();
                this.userControlXBLayerCombine1.panelIDList.Visible = true;
                this.Cursor = Cursors.WaitCursor;
                this.userControlXBLayerCombine1.Hook(base.MapControlEdit.Object, this.mEditLayer, this.m_CountyFeature, this.userControlQueryResult1, this.userControlQueryResult2, base.dockPanelBottom);
                this.userControlXBLayerCombine1.InitialValue();
                this.Cursor = Cursors.Default;
                this.barButtonItemInputZT.Enabled = false;
                this.barButtonItemInputYG.Enabled = false;
                this.barButtonItemInputDC.Enabled = false;
                this.barButtonItemInputOther.Enabled = false;
                this.barButtonItemLayerCombine.Enabled = true;
                this.barButtonItemXBEdit.Enabled = false;
                this.barButtonItemGrowthModel.Enabled = false;
                this.barButtonItemSSA.Enabled = false;
                this.barButtonItemInputEL.Enabled = false;
                this.barButtonItemArea.Enabled = false;
                this.barButtonItemXJ.Enabled = false;
                this.barButtonItemLinZu.Enabled = false;
                this.barButtonItemCreateByPolygon.Enabled = false;
                this.barButtonItemCreateByPolygon2.Enabled = false;
                this.barButtonItemSmoothPolygon.Enabled = false;
                this.barButtonItemPropertyByXB.Enabled = false;
                this.barButtonItemInputPropertyList.Enabled = false;
                this.barButtonItemSaveEdit.Enabled = false;
            }
            else
            {
                this.xtraTabPageXBchange.PageVisible = false;
                base.xtraTabToolbox.SelectedTabPageIndex = 0;
                this.barButtonItemInputYG.Enabled = true;
                this.barButtonItemInputDC.Enabled = true;
                this.barButtonItemInputOther.Enabled = true;
                this.barButtonItemLayerCombine.Enabled = true;
                this.barButtonItemInputZT.Enabled = true;
                this.barButtonItemXBEdit.Enabled = true;
                this.barButtonItemGrowthModel.Enabled = true;
                this.barButtonItemSSA.Enabled = true;
                this.barButtonItemInputEL.Enabled = true;
                this.barButtonItemArea.Enabled = true;
                this.barButtonItemXJ.Enabled = true;
                this.barButtonItemLinZu.Enabled = true;
            }
        }

        private void barButtonItemLinZu_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                //   IDBAccess dBAccess = UtilFactory.GetDBAccess("Access");
                //  IDBAccess access2 = UtilFactory.GetDBAccess(UtilFactory.GetConfigOpt().GetConfigValue2("DataBase", "DBKey"));
                SqlConnection pSqlConnection = null;
                //if (access2.Connection is SqlConnection)
                //{
                //    pSqlConnection = access2.Connection as SqlConnection;
                //}
                string layerName = EditTask.LayerName;
                string text = "";// new ClsCalculateVolAndAge().CalculateLJLZ(layerName, pSqlConnection, dBAccess);
                if (text == "")
                {
                    MessageBox.Show("年度小班龄组划分完成!", "龄组划分", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    MessageBox.Show(text, "龄组划分", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                this.Cursor = Cursors.Default;
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "GXFormMainFrame.FormMainEdit", "barButtonItemLinZu_ItemClick", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                this.Cursor = Cursors.Default;
            }
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

        private void barButtonItemMapSet_ItemClick(object sender, ItemClickEventArgs e)
        {
            new MapSet(base.PageLayoutControlEdit.Object as IPageLayoutControl3).ShowDialog();
        }

        private void barButtonItemMapText_ItemClick(object sender, ItemClickEventArgs e)
        {
            AxPageLayoutControl pageLayoutControlEdit = base.PageLayoutControlEdit;
            new DevText { ActiveView = pageLayoutControlEdit.ActiveView }.ShowDialog();
        }

        private void barButtonItemOpen_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {

                Tuple<bool, string> res = DMM.GetSavePath(mEditKind, bDefaultPath, sMxdPath);
                bDefaultPath = res.Item1;
                sMxdPath = res.Item2;
                FileInfo info = new FileInfo(this.sMxdPath);
                if (info.Exists)
                {
                    (base.PageLayoutControlEdit.Object as IPageLayoutControl3).LoadMxFile(this.sMxdPath, null);
                    this.m_controlsSynchronizer2.SetMapOfPagelayoutToMap();
                    this.m_controlsSynchronizer2.ActivateMap();
                    if (UtilFactory.GetConfigOpt().GetConfigValue("MapDBkey") != "Local")
                    {
                        this.AddEviaTiledSatellite();
                    }
                    this.userControlLayerControl.mEditKind = this.mEditKind;
                    this.userControlLayerControl.Map = base.MapControlEdit.Map;
                    this.userControlLayerControl.InitialValue();
                    this.ResetToolBarButton();
                    this.RefreshToolBarButton(true);
                    this.mButtonCollection = new ArrayList();
                    this.mButtonCollection2 = new ArrayList();
                    this.mButtonCollection3 = new ArrayList();
                    this.InitializeEditValue(false);
                    this.InitializeBaseButtonEdit();
                    this.InitializeBaseButtonPage();
                    this.SetButtonVisible();
                    if (this.mEditKind == "征占用")
                    {
                        this.OpenZZYProject();
                        this.barButtonItemProjectList.Down = true;
                        this.barButtonItemProjectList_ItemClick(sender, null);
                    }
                    this.xtraTabPageInputData.PageVisible = false;
                    if (this.barButtonItemIdentify2.Down)
                    {
                        this.userControlInfo.InitialControls(this.mEditKind);
                    }
                    this.SetButtonVisible();
                    this.SetButtonEnabled();
                    this.SetFormText();
                }
                else
                {
                    MessageBox.Show("工作空间加载失败，文件 " + this.sMxdPath + " 错误。", "提示", MessageBoxButtons.OK);
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "GXFormMainFrame.FormMainEdit", "barButtonItemOpen_ItemClick", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void barButtonItemOpen2_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                Tuple<bool, string> res = DMM.GetOpenFile(mEditKind, sMxdPath, bDefaultPath);
                bDefaultPath = res.Item1;
                sMxdPath = res.Item2;
                FileInfo info = new FileInfo(this.sMxdPath);
                if (info.Exists)
                {
                    (base.PageLayoutControlEdit.Object as IPageLayoutControl3).LoadMxFile(this.sMxdPath, null);
                    this.m_controlsSynchronizer2.SetMapOfPagelayoutToMap();
                    this.m_controlsSynchronizer2.ActivateMap();
                    if (UtilFactory.GetConfigOpt().GetConfigValue("MapDBkey") != "Local")
                    {
                        this.AddEviaTiledSatellite();
                    }
                    this.InitializeEditValue(false);
                    base.barEditItemScale.EditValue = this.GetMapScale(base.MapControlEdit.Map);
                    if (this.userControlInfo.hook == null)
                    {
                        this.userControlInfo.hook = base.MapControlEdit.Object;
                    }
                    this.userControlInfo.EditLayer = this.mEditLayer;
                    this.userControlInfo.InitialControls(this.mEditKind);
                    this.SetPageLayoutValues();
                    TemplateCartoManager manager = new TemplateCartoManager();
                    Cartography.Template.TemplateInfo info2 = new Cartography.Template.TemplateInfo();
                    string str = this.barEditItem_fx.EditValue.ToString();
                    info2.TemplateDirection = Direction.Heng;
                    if (EditTask.TaskName == "采伐")
                    {
                        info2.TemplateBusiness = BusinessType.CaiFaSJ;
                    }
                    else if (EditTask.TaskName == "造林")
                    {
                        info2.TemplateBusiness = BusinessType.ZaoLinSJ;
                    }
                    else if (EditTask.TaskName == "征占用")
                    {
                        info2.TemplateBusiness = BusinessType.ZZWZ;
                    }
                    else
                    {
                        info2 = null;
                    }
                    Cartography.Template.TemplateInfo.CurrentTemplateInfo = info2;
                    this.ResetToolBarButton();
                    this.RefreshToolBarButton(true);
                    this.mButtonCollection = new ArrayList();
                    this.mButtonCollection2 = new ArrayList();
                    this.mButtonCollection3 = new ArrayList();
                    this.InitializeBaseButtonEdit();
                    this.InitializeBaseButtonPage();
                    this.SetButtonVisible();
                    this.xtraTabPageInputData.PageVisible = false;
                    if (this.barButtonItemIdentify2.Down)
                    {
                        this.userControlInfo.InitialControls(this.mEditKind);
                    }
                    if (this.mEditKind == "征占用")
                    {
                        this.userControlProjectList1.InitialValue(base.MapControlEdit.Object, this.mEditLayer);
                    }
                    this.SetButtonVisible();
                    this.SetButtonEnabled();
                    this.SetFormText();
                    if (this.mEditKind == "征占用")
                    {
                        this.CloseZZYProject();
                    }
                }
                else
                {
                    MessageBox.Show("工作空间加载失败，文件 " + this.sMxdPath + " 错误。", "提示", MessageBoxButtons.OK);
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "GXFormMainFrame.FormMainEdit", "barButtonItemOpen_ItemClick", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void barButtonItemOutCFTable_ItemClick(object sender, ItemClickEventArgs e)
        {
            new FormHarTable().ShowDialog();
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

        private void barButtonItemProjectList_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (this.barButtonItemProjectList.Down)
            {
                base.dockPanelToolbox.Visibility = DockVisibility.Visible;
                if (base.dockPanelToolbox.Width < 310)
                {
                    base.dockPanelToolbox.Width = 310;
                }
                this.xtraTabPageProject.PageVisible = true;
                base.xtraTabToolbox.SelectedTabPage = this.xtraTabPageProject;
                if (this.mEditKind == "征占用")
                {
                    this.userControlProjectList1.BringToFront();
                    this.userControlProjectList1.InitialValue(base.MapControlEdit.Object, this.mEditLayer);
                }
                else if (this.mEditKind == "采伐")
                {
                    this.userControlDesignList1.BringToFront();
                    this.userControlDesignList1.InitialValue(base.MapControlEdit.Object, this.mEditLayer);
                }
            }
            else if (!this.barButtonItemProjectList.Down)
            {
                this.xtraTabPageProject.PageVisible = false;
            }
        }

        /// <summary>
        /// 编辑--获取属性的响应事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItemPropertyByXB_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                string configValue = UtilFactory.GetConfigOpt().GetConfigValue("XiaobanLayerName");
                if (GISFunFactory.LayerFun.FindFeatureLayer(base.MapControlEdit.Map as IBasicMap, configValue, true) == null)
                {
                    MessageBox.Show("无二类小班图层不能根据小班自动提取属性信息", "数据编辑", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    new FormPropertyByXB2(base.MapControlEdit.Object, this.mEditKind) { Width = 450 }.ShowDialog();
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "GXFormMainFrame.FormMainEdit", "barButtonItemPropertyByXB_ItemClick", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
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
                    this.userControlQueryXB.simpleButtonSelect.Visible = false;
                    this.userControlQueryXB.BringToFront();
                    this.userControlQueryXB.labelLocation.Visible = true;
                    string configValue = UtilFactory.GetConfigOpt().GetConfigValue("XiaobanLayerName");
                    ILayer layer = GISFunFactory.LayerFun.FindLayer(base.MapControlEdit.Map as IBasicMap, configValue, true);
                    if ((layer != null) && (layer is IFeatureLayer))
                    {
                        this.userControlQueryXB.InitialValue(base.MapControlEdit.Object, layer as IFeatureLayer, base.MapControlEdit.Map, this.userControlQueryResult1, base.dockPanelBottom);
                    }
                    base.xtraTabToolbox.SelectedTabPage = base.xtraTabPageQuery;
                    this.barButtonItemQueryZT.Down = false;
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
                    this.barButtonItemQueryXB.Down = false;
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
                        else if (this.mEditKind.Contains("遥感"))
                        {
                            this.userControlQueryYG.Visible = true;
                            this.userControlQueryYG.BringToFront();
                            this.userControlQueryYG.InitialValue(base.MapControlEdit.Object, this.mEditLayer, base.MapControlEdit.Map, this.userControlQueryResult1, base.dockPanelBottom);
                            base.xtraTabToolbox.SelectedTabPage = base.xtraTabPageQuery;
                        }
                        else if (this.mEditKind == "小班变更")
                        {
                            this.userControlQueryXB.Visible = true;
                            this.userControlQueryXB.BringToFront();
                            this.userControlQueryXB.simpleButtonSelect.Visible = true;
                            this.userControlQueryXB.InitialValue(base.MapControlEdit.Object, this.mEditLayer, base.MapControlEdit.Map, this.userControlQueryResult1, base.dockPanelBottom);
                            this.userControlQueryXB.labelLocation.Visible = true;
                            this.userControlQueryXB.labelLocation.Text = "      变更小班查询          ";
                            base.xtraTabToolbox.SelectedTabPage = base.xtraTabPageQuery;
                        }
                        else if (this.mEditKind == "年度小班")
                        {
                            this.userControlQueryXB.Visible = true;
                            this.userControlQueryXB.BringToFront();
                            this.userControlQueryXB.simpleButtonSelect.Visible = true;
                            this.userControlQueryXB.InitialValue(base.MapControlEdit.Object, this.mEditLayer, base.MapControlEdit.Map, this.userControlQueryResult1, base.dockPanelBottom);
                            this.userControlQueryXB.labelLocation.Visible = true;
                            this.userControlQueryXB.labelLocation.Text = "      年度小班查询          ";
                            base.xtraTabToolbox.SelectedTabPage = base.xtraTabPageQuery;
                        }
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        private void barButtonItemReportAJ_ItemClick(object sender, ItemClickEventArgs e)
        {
            ReportEntry entry = new ReportEntry();
            //得到案件表
            FindMidFromLayer_AJ midLyr = new FindMidFromLayer_AJ();
            midLyr.DataLayer = mEditLayer;
            ReportParamter pReportParamter = new ReportParamter
            {
                TaskID = EditTask.TaskID.ToString(),
                TaskName = "林业案件",
                Year = EditTask.TaskYear,
                SysType = Report.SystemType.ZYGL,
                FindFromLayer_AJ = midLyr
            };
            entry.Show(pReportParamter);
        }

        private void barButtonItemReportFCDC_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                ReportEntry entry;
                ReportParamter paramter;
                List<string> list;
                string str = EditTask.TaskID.ToString();
                IFeature feature = null;
                string str2 = "";
                if (str == "0")
                {
                    if (base.MapControlEdit.Map.SelectionCount == 0)
                    {
                        MessageBox.Show("请先选择一块采伐班块", "数据编辑", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else
                    {
                        if (this.mEditLayer == null)
                        {
                            this.mEditLayer = EditTask.EditLayer;
                        }
                        IFeatureSelection mEditLayer = this.mEditLayer as IFeatureSelection;
                        ISelectionSet selectionSet = null;
                        selectionSet = mEditLayer.SelectionSet;
                        ICursor cursor = null;
                        selectionSet.Search(null, false, out cursor);
                        feature = (cursor as IFeatureCursor).NextFeature();
                        if (feature != null)
                        {
                            int index = feature.Fields.FindField("CUN");
                            if (index > -1)
                            {
                                str2 = "CUN='" + feature.get_Value(index).ToString() + "'";
                            }
                            index = feature.Fields.FindField("LIN_BAN");
                            if (index > -1)
                            {
                                str2 = str2 + " and LIN_BAN='" + feature.get_Value(index).ToString() + "'";
                            }
                            index = feature.Fields.FindField("XIAO_BAN");
                            if (index > -1)
                            {
                                str2 = str2 + " and XIAO_BAN='" + feature.get_Value(index).ToString() + "'";
                            }
                            index = feature.Fields.FindField("XI_BAN");
                            if (index > -1)
                            {
                                str2 = str2 + " and XI_BAN='" + feature.get_Value(index).ToString() + "'";
                            }
                        }
                        if (str2 == "")
                        {
                            MessageBox.Show("请先选择一块采伐班块", "数据统计", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                        else
                        {
                            entry = new ReportEntry();
                            paramter = new ReportParamter
                            {
                                BK = "(" + str2 + ")",
                                TaskName = "采伐",
                                Year = EditTask.TaskYear,
                                SysType = Report.SystemType.ZYGL,
                                FeatureLayer = EditTask.EditLayer
                            };
                            list = new List<string> { "4" };
                            paramter.IDs = list;
                            entry.ShowRegister(paramter);
                        }
                    }
                }
                else
                {
                    entry = new ReportEntry();
                    paramter = new ReportParamter
                    {
                        TaskID = "Task_ID='" + str + "'",
                        TaskName = "采伐",
                        Year = EditTask.TaskYear,
                        SysType = Report.SystemType.FQSJ,
                        FeatureLayer = EditTask.EditLayer
                    };
                    list = new List<string> { "4" };
                    paramter.IDs = list;
                    entry.ShowRegister(paramter);
                }
            }
            catch (Exception)
            {
            }
        }
        private ITable GetFireTable()
        {
            string name = UtilFactory.GetConfigOpt().GetConfigValue2("Fire", "FireTable");
            IFeatureWorkspace editWorkspace = EditTask.EditWorkspace;
            if (editWorkspace == null)
            {
                return null;
            }
            ITable table = null;
            try
            {
                table = editWorkspace.OpenTable(name);
            }
            catch
            {
                return null;
            }
            return table;
        }
        private void barButtonItemReportHZ_ItemClick(object sender, ItemClickEventArgs e)
        {
            ReportEntry entry = new ReportEntry();
            //得到火灾表
            FindMidFromTable_HZ midLyr = new FindMidFromTable_HZ();
            midLyr.DataTable = GetFireTable();

            ReportParamter pReportParamter = new ReportParamter
            {
                TaskID = EditTask.TaskID.ToString(),
                TaskName = "火灾",
                Year = EditTask.TaskYear,
                SysType = Report.SystemType.ZYGL,
                FindFromTable = midLyr
            };
            entry.Show(pReportParamter);
        }

        private void barButtonItemReportZH_ItemClick(object sender, ItemClickEventArgs e)
        {
            ReportEntry entry = new ReportEntry();
            FindMidFromLayer_ZH midLyr = new FindMidFromLayer_ZH();
            midLyr.DataLayer = mEditLayer;
            ReportParamter pReportParamter = new ReportParamter
            {
                TaskID = EditTask.TaskID.ToString(),
                TaskName = "自然灾害",
                Year = EditTask.TaskYear,
                SysType = Report.SystemType.ZYGL,
                FindFromLayer_ZH = midLyr
            };
            entry.Show(pReportParamter);
        }

        private void barButtonItemReportZL_ItemClick(object sender, ItemClickEventArgs e)
        {
            dlgTJMain main = new dlgTJMain() { ZLTableName = (this.mEditLayer.FeatureClass as IDataset).Name };
            string str = UtilFactory.GetConfigOpt().GetConfigValue("ZaoLinLayer") + "_" + EditTask.TaskYear;
            FindMidFromLayer_ZL midLyr = new FindMidFromLayer_ZL();
            midLyr.DataLayer = mEditLayer;
            main.FindFromLayer = midLyr;
            main.ZLTableName = str;
            main.ShowDialog();

        }

        /// <summary>
        /// 统计--调查成果统计表：的响应
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItemReportZZY_ItemClick(object sender, ItemClickEventArgs e)
        {
            dlgLDZZTJ gldzztj = new dlgLDZZTJ();
            string str = UtilFactory.GetConfigOpt().GetConfigValue("ZZYLayer") + "_" + EditTask.TaskYear;
            ///源代码：FindMidFromLayer_LDZY midLyr = new FindMidFromLayer_LDZY();
            FindMidFromLayer_ZZ midLyr = new FindMidFromLayer_ZZ();
            midLyr.DataLayer = mEditLayer;
            gldzztj.ZZYTableName = (this.mEditLayer.FeatureClass as IDataset).Name;
            gldzztj.FindFromLayer = midLyr;
            gldzztj.ShowDialog();
        }

        private void barButtonItemReportZZY2_ItemClick(object sender, ItemClickEventArgs e)
        {
            new FormLdzzyStat(UtilFactory.GetConfigOpt().GetConfigValue("ZZYLayer") + "_" + EditTask.TaskYear).ShowDialog();
        }

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
                string sFileName = UtilFactory.GetConfigOpt().RootPath + @"Template\" + this.mEditKind + ".mxd";
                if (GISFunFactory.CoreFun.SaveMapDocument(pMxdContents, sFileName, true, true, true, true))
                {
                    MessageBox.Show("存储完成！", "保存工作空间", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    MessageBox.Show("存储失败！", "保存工作空间", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }
                DMM.SavePath(mEditKind);
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "GXFormMainFrame.FormMainEdit", "barButtonItemSave_ItemClick", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void barButtonItemSaveEdit_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                if (Editor.UniqueInstance.IsBeingEdited)
                {
                    Editor.UniqueInstance.StopEdit();
                    Editor.UniqueInstance.StartEdit(Editor.UniqueInstance.Workspace, Editor.UniqueInstance.Map);
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "GXFormMainFrame.FormMainEdit", "barButtonItemSaveEdit_ItemClick", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void barButtonItemSelectByAttributes_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (this.barButtonItemSelectByAttributes.Down)
            {
                this.xtraTabPageSelectByAttributes.PageVisible = true;
                base.xtraTabToolbox.SelectedTabPage = this.xtraTabPageSelectByAttributes;
                this.userControlSelectByAttributes.InitialValue(base.MapControlEdit.Object);
            }
            else
            {
                this.xtraTabPageSelectByAttributes.PageVisible = false;
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

        private void barButtonItemSetSpatialreference_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                ISpatialReference spatialReference = base.MapControlEdit.Map.SpatialReference;
                FormSetSpatialreference spatialreference = new FormSetSpatialreference();
                spatialreference.InitialValue(spatialReference);
                spatialreference.ShowDialog(this);
                bool flag = false;
                IWorkspaceEdit editWorkspace = EditTask.EditWorkspace as IWorkspaceEdit;
                if ((TaskManageClass.TaskState.ToString() == TaskState.Open.ToString()) && editWorkspace.IsBeingEdited())
                {
                    if (Editor.UniqueInstance.IsBeingEdited)
                    {
                        Editor.UniqueInstance.StopEdit();
                    }
                    flag = true;
                }
                spatialReference = spatialreference.SpatialReference;
                base.MapControlEdit.Map.SpatialReference = spatialReference;
                if (flag)
                {
                    Editor.UniqueInstance.StartEdit(EditTask.EditWorkspace as IWorkspace, base.MapControlEdit.ActiveView.FocusMap);
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "GXFormMainFrame.FormMainEdit", "barButtonItemSetSpatialreference_ItemClick", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void barButtonItemSingleCheck_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ribbonPageGroupToplogic.Visible = this.barButtonItemSingleCheck.Down;
        }

        private void barButtonItemSJ_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.barButtonItemSJ.Down = true;
            if (this.barButtonItemSJ.Down)
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
                if ((EditTask.TaskName == "采伐") || (EditTask.KindCode.Substring(0, 2) == "02"))
                {
                    pInfo.TemplateBusiness = BusinessType.CaiFaSJ;
                }
                else if ((EditTask.TaskName == "造林") || (EditTask.KindCode.Substring(0, 2) == "01"))
                {
                    pInfo.TemplateBusiness = BusinessType.ZaoLinSJ;
                }
                else if ((EditTask.TaskName == "征占用") || (EditTask.KindCode.Substring(0, 2) == "04"))
                {
                    pInfo.TemplateBusiness = BusinessType.ZZWZ;
                }
                Cartography.Template.TemplateInfo.CurrentTemplateInfo = pInfo;
                manager.TemplateCarto(base.PageLayoutControlEdit.Object as IPageLayoutControl3, pInfo);
                this.SetPageLayoutValues();
            }
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

        private void barButtonItemSmoothPolygon_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "GXFormMainFrame.FormMainEdit", "barButtonItemSmoothPolygon_ItemClick", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void barButtonItemSSA_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (this.barButtonItemSSA.Down)
            {
                this.barButtonItemInputOther.Down = false;
                this.barButtonItemInputDC.Down = false;
                this.barButtonItemInputZT.Down = false;
                this.barButtonItemInputYG.Down = false;
                this.barButtonItemXBEdit.Down = false;
                this.barButtonItemInputEL.Down = false;
                this.barButtonItemGrowthModel.Down = false;
                this.userControlUpdateAS21.Visible = true;
                this.userControlUpdateAS21.BringToFront();
                this.userControlUpdateAS21.Hook = base.MapControlEdit.Object;
                this.xtraTabPageXBchange.Text = "年度";
                this.xtraTabPageXBchange.PageVisible = true;
                base.xtraTabToolbox.SelectedTabPageIndex = this.xtraTabPageXBchange.TabIndex;
                base.xtraTabToolbox.SelectedTabPageIndex = this.xtraTabPageXBchange.TabIndex;
                this.barButtonItemInputZT.Enabled = false;
                this.barButtonItemInputYG.Enabled = false;
                this.barButtonItemInputDC.Enabled = false;
                this.barButtonItemInputOther.Enabled = false;
                this.barButtonItemLayerCombine.Enabled = false;
                this.barButtonItemGrowthModel.Enabled = false;
                this.barButtonItemSSA.Enabled = true;
                this.barButtonItemXBEdit.Enabled = false;
                this.barButtonItemInputEL.Enabled = false;
                this.barButtonItemArea.Enabled = false;
                this.barButtonItemXJ.Enabled = false;
                this.barButtonItemLinZu.Enabled = false;
                this.barButtonItemInputPropertyList.Enabled = false;
                this.barButtonItemSaveEdit.Enabled = false;
            }
            else
            {
                this.xtraTabPageXBchange.PageVisible = false;
                base.xtraTabToolbox.SelectedTabPageIndex = 0;
                this.barButtonItemInputYG.Enabled = true;
                this.barButtonItemInputDC.Enabled = true;
                this.barButtonItemInputOther.Enabled = true;
                this.barButtonItemLayerCombine.Enabled = true;
                this.barButtonItemGrowthModel.Enabled = true;
                this.barButtonItemSSA.Enabled = true;
                this.barButtonItemInputZT.Enabled = true;
                this.barButtonItemXBEdit.Enabled = true;
                this.barButtonItemInputEL.Enabled = true;
                this.barButtonItemArea.Enabled = true;
                this.barButtonItemXJ.Enabled = true;
                this.barButtonItemLinZu.Enabled = true;
                this.barButtonItemInputPropertyList.Enabled = false;
                this.barButtonItemSaveEdit.Enabled = false;
            }
        }

        private void barButtonItemStatic_ItemClick(object sender, ItemClickEventArgs e)
        {
            //  new frmSelectTable().ShowDialog(this);
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
                base.MapControlEdit.Height = base.xtraTabMain.Height - 0x18;
                base.PageLayoutControlEdit.Dock = DockStyle.None;
                base.PageLayoutControlEdit.Left = 1;
                base.PageLayoutControlEdit.Top = 1;
                base.PageLayoutControlEdit.Width = base.xtraTabMain.Width - 2;
                base.PageLayoutControlEdit.Height = base.xtraTabMain.Height - 30;
                base.PageLayoutControlEdit.Height = base.xtraTabMain.Height - 0x18;
            }
            else if (base.xtraTabMain.SelectedTabPageIndex == 1)
            {
                base.PageLayoutControlEdit.BringToFront();
                base.PageLayoutControlEdit.Dock = DockStyle.None;
                base.PageLayoutControlEdit.Left = 1;
                base.PageLayoutControlEdit.Top = 1;
                base.PageLayoutControlEdit.Width = base.xtraTabMain.Width - 2;
                base.PageLayoutControlEdit.Height = base.xtraTabMain.Height - 30;
                base.PageLayoutControlEdit.Height = base.xtraTabMain.Height - 0x18;
                base.MapControlEdit.Dock = DockStyle.None;
                base.MapControlEdit.Left = 1;
                base.MapControlEdit.Top = 1;
                base.MapControlEdit.Width = base.xtraTabMain.Width - 2;
                base.MapControlEdit.Height = base.xtraTabMain.Height - 30;
                base.MapControlEdit.ShowScrollbars = false;
                base.MapControlEdit.Height = base.xtraTabMain.Height - 0x18;
            }
        }

        private void barButtonItemTopModify_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ribbonPageGroupTopoModify.Visible = this.barButtonItemTopModify.Down;
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

        private void barButtonItemXBEdit_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (this.barButtonItemXBEdit.Down)
            {
                if (this.mEditLayer == null)
                {
                    this.mEditLayer = EditTask.EditLayer;
                }
                this.barButtonItemInputOther.Down = false;
                this.barButtonItemInputDC.Down = false;
                this.barButtonItemInputZT.Down = false;
                this.barButtonItemInputYG.Down = false;
                this.barButtonItemGrowthModel.Down = false;
                this.barButtonItemInputEL.Down = false;
                this.barButtonItemLayerCombine.Down = false;
                this.barButtonItemSSA.Down = false;
                this.InitializeBaseButtonEdit();
                this.InitializeBaseButtonPage();
                this.SetButtonVisible();
                this.xtraTabPageXBchange.PageVisible = false;
                base.xtraTabToolbox.SelectedTabPageIndex = 0;
                this.barButtonItemInputZT.Enabled = false;
                this.barButtonItemInputYG.Enabled = false;
                this.barButtonItemInputDC.Enabled = false;
                this.barButtonItemInputOther.Enabled = false;
                this.barButtonItemLayerCombine.Enabled = false;
                this.barButtonItemGrowthModel.Enabled = false;
                this.barButtonItemSSA.Enabled = false;
                this.barButtonItemInputEL.Enabled = false;
                this.barButtonItemArea.Enabled = false;
                this.barButtonItemXJ.Enabled = false;
                this.barButtonItemLinZu.Enabled = false;
                this.barButtonItemCreateByPolygon.Enabled = true;
                this.barButtonItemCreateByPolygon2.Enabled = true;
                this.barButtonItemSmoothPolygon.Enabled = true;
                this.barButtonItemPropertyByXB.Enabled = true;
                this.barButtonItemInputPropertyList.Enabled = true;
                this.barButtonItemSaveEdit.Enabled = true;
            }
            else
            {
                IWorkspaceEdit editWorkspace = EditTask.EditWorkspace as IWorkspaceEdit;
                if (((TaskManageClass.TaskState.ToString() == TaskState.Open.ToString()) && editWorkspace.IsBeingEdited()) && Editor.UniqueInstance.IsBeingEdited)
                {
                    Editor.UniqueInstance.StopEdit();
                }
                this.barButtonItemInputYG.Enabled = true;
                this.barButtonItemInputDC.Enabled = true;
                this.barButtonItemInputOther.Enabled = true;
                this.barButtonItemLayerCombine.Enabled = true;
                this.barButtonItemInputZT.Enabled = true;
                this.barButtonItemGrowthModel.Enabled = true;
                this.barButtonItemSSA.Enabled = true;
                this.barButtonItemInputEL.Enabled = true;
                this.barButtonItemArea.Enabled = true;
                this.barButtonItemXJ.Enabled = true;
                this.barButtonItemLinZu.Enabled = true;
                this.barButtonItemCreateByPolygon.Enabled = false;
                this.barButtonItemCreateByPolygon2.Enabled = false;
                this.barButtonItemSmoothPolygon.Enabled = false;
                this.barButtonItemPropertyByXB.Enabled = false;
                this.barButtonItemInputPropertyList.Enabled = false;
                this.barButtonItemSaveEdit.Enabled = false;
            }
        }

        private void barButtonItemXBUpdate_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (this.barButtonItemXBUpdate.Down)
            {
                base.dockPanelEdit.Visibility = DockVisibility.Visible;
                this.xtraTabPageUpdate.PageVisible = true;
                this.userControlUpdate1.Init(base.MapControlEdit.Object);
            }
            else
            {
                base.dockPanelEdit.Visibility = DockVisibility.Hidden;
            }
        }

        private void barButtonItemXJ_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                // IDBAccess dBAccess = UtilFactory.GetDBAccess(UtilFactory.GetConfigOpt().GetConfigValue2("DataBase", "DBKey"));
                SqlConnection pSqlConnection = null;
                //if (dBAccess.Connection is SqlConnection)
                //{
                //    pSqlConnection = dBAccess.Connection as SqlConnection;
                //}
                string layerName = EditTask.LayerName;
                ClsCalculateVolAndAge age = new ClsCalculateVolAndAge();
                string text = "";// age.CalculateXJ_BHYY(layerName, dBAccess.Connection);
                if (text == "")
                {
                    text = age.CalculateXJ_ANSHU(layerName, pSqlConnection);
                    if (text == "")
                    {
                        text = age.CalculateXJ_All(layerName, pSqlConnection);
                        if (text == "")
                        {
                            AutoUpdateSub sub = new AutoUpdateSub(base.MapControlEdit.Map);
                            if (sub.UpdateXJ(EditTask.EditLayer))
                            {
                                MessageBox.Show("年度小班蓄积计算完成!", "蓄积计算", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            }
                            else
                            {
                                MessageBox.Show("公顷蓄积计算错误", "蓄积计算", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            }
                        }
                        else
                        {
                            MessageBox.Show(text, "蓄积计算", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                    }
                    else
                    {
                        MessageBox.Show(text, "蓄积计算", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                }
                else
                {
                    MessageBox.Show(text, "蓄积计算", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                this.Cursor = Cursors.Default;
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "GXFormMainFrame.FormMainEdit", "barButtonItemXJ_ItemClick", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                this.Cursor = Cursors.Default;
            }
        }

        private void barButtonItemZTT_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                this.mSelection = true;
                this.barButtonItemZTT.Down = true;
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
                else if (EditTask.TaskName == "遥感")
                {
                    pInfo.TemplateBusiness = BusinessType.YGBJ;
                }
                else if (EditTask.TaskName == "专题")
                {
                    pInfo.TemplateBusiness = BusinessType.XBCX;
                }
                Cartography.Template.TemplateInfo.CurrentTemplateInfo = pInfo;
                manager.TemplateCarto(base.PageLayoutControlEdit.Object as IPageLayoutControl3, pInfo);
                this.SetPageLayoutValues();
                this.mSelection = false;
            }
            catch (Exception)
            {
                this.mSelection = false;
            }
        }

        private void barEditItem_fx_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                this.mSelection = true;
                TemplateCartoManager manager = new TemplateCartoManager();
                Cartography.Template.TemplateInfo currentTemplateInfo = Cartography.Template.TemplateInfo.CurrentTemplateInfo;
                if (currentTemplateInfo != null)
                {
                    switch (this.barEditItem_fx.EditValue.ToString())
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
                    this.mSelection = false;
                }
            }
            catch (Exception)
            {
                this.mSelection = false;
            }
        }

        private void barEditItemEditLayer_HiddenEditor(object sender, ItemClickEventArgs e)
        {
        }

        private void barEditItemEditLayer_ItemClick(object sender, ItemClickEventArgs e)
        {
        }

        private void barEditItemEditLayer_ItemPress(object sender, ItemClickEventArgs e)
        {
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

        private void bbiLoadTempalte_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmLoadTemplate template = new frmLoadTemplate();
            template.Init(base.PageLayoutControlEdit.Object);
            template.ShowDialog();
        }

        //private bool CheckDataSource(string skey, string spath)
        //{
        //    try
        //    {
        //        FileInfo info = new FileInfo(spath);
        //        if (info.Exists)
        //        {
        //            string configValue = UtilFactory.GetConfigOpt().GetConfigValue(skey);
        //            string str2 = UtilFactory.GetConfigOpt().GetConfigValue2("SqlServer", "DataSource");
        //            string str3 = UtilFactory.GetConfigOpt().GetConfigValue2("SqlServer", "InitialCatalog");
        //            if (configValue == (str2 + "," + str3))
        //            {
        //                return true;
        //            }
        //        }
        //        return false;
        //    }
        //    catch (Exception)
        //    {
        //        return false;
        //    }
        //}

        private ArrayList CheckSelectionLayer(ILayer pLayer, ArrayList pSelLayerCol)
        {
            try
            {
                if (pLayer != null)
                {
                    if (pSelLayerCol == null)
                    {
                        return pSelLayerCol;
                    }
                    if (!pLayer.Valid)
                    {
                        return pSelLayerCol;
                    }
                    if (pLayer is ICompositeLayer)
                    {
                        ICompositeLayer layer = pLayer as ICompositeLayer;
                        for (int i = 0; i < layer.Count; i++)
                        {
                            pSelLayerCol = this.CheckSelectionLayer(layer.get_Layer(i), pSelLayerCol);
                        }
                    }
                    else if (pLayer is IFeatureSelection)
                    {
                        IFeatureSelection selection = pLayer as IFeatureSelection;
                        if (selection.SelectionSet.Count > 0)
                        {
                            pSelLayerCol.Add(pLayer);
                        }
                    }
                }
                return pSelLayerCol;
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "GXFormMainFrame.FormMainEdit", "CheckSelectionLayer", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                return pSelLayerCol;
            }
        }

        private bool ClipXBCreateFeature(IFeatureCursor pFCursor, IFeature pf, IFeature pFeature)
        {
            Exception exception;
            try
            {
                int num = 0;
                while (pf != null)
                {
                    IGeometry shapeCopy = pf.ShapeCopy;
                    IGeometry other = pFeature.ShapeCopy;
                    if (other.SpatialReference != shapeCopy.SpatialReference)
                    {
                        other.Project(shapeCopy.SpatialReference);
                    }
                    ITopologicalOperator2 @operator = shapeCopy as ITopologicalOperator2;
                    @operator.IsKnownSimple_2 = false;
                    @operator.Simplify();
                    try
                    {
                        IGeometry geometry3 = @operator.Intersect(other, esriGeometryDimension.esriGeometry2Dimension);
                        if (!geometry3.IsEmpty)
                        {
                            num++;
                            ITopologicalOperator2 operator2 = geometry3 as ITopologicalOperator2;
                            operator2.IsKnownSimple_2 = false;
                            operator2.Simplify();
                            ITopologicalOperator2 operator3 = shapeCopy as ITopologicalOperator2;
                            IGeometry geometry4 = geometry3;
                            IFeature feature = this.mEditLayer.FeatureClass.CreateFeature();
                            feature.Shape = geometry4;
                            for (int i = 0; i < feature.Fields.FieldCount; i++)
                            {
                                IField field = feature.Fields.get_Field(i);
                                if ((((field.Name != "") && (field.Name != this.mEditLayer.FeatureClass.OIDFieldName)) && ((field.Name != this.mEditLayer.FeatureClass.ShapeFieldName) && (field.Name != this.mEditLayer.FeatureClass.LengthField.Name))) && (field.Name != this.mEditLayer.FeatureClass.AreaField.Name))
                                {
                                    int index = pFeature.Fields.FindField(field.Name);
                                    try
                                    {
                                        if ((index > -1) && (pFeature.get_Value(index).ToString().Trim() != ""))
                                        {
                                            feature.set_Value(i, pFeature.get_Value(index));
                                        }
                                    }
                                    catch (Exception)
                                    {
                                    }
                                }
                            }
                            if (EditTask.TaskID > 0L)
                            {
                                int num4 = feature.Fields.FindField("XMBH");
                                if (num4 > -1)
                                {
                                    feature.set_Value(num4, EditTask.TaskID);
                                }
                                num4 = feature.Fields.FindField("Task_ID");
                                if (num4 > -1)
                                {
                                    feature.set_Value(num4, EditTask.TaskID);
                                }
                            }
                            feature.Store();
                            this.SetFeatureArea(feature);
                            IGeometry pGeometry = feature.ShapeCopy;
                            pGeometry = GISFunFactory.UnitFun.ConvertPoject(pGeometry, base.MapControlEdit.Map.SpatialReference);
                            base.MapControlEdit.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeography, this.mEditLayer, pGeometry.Envelope);
                        }
                    }
                    catch (Exception exception2)
                    {
                        exception = exception2;
                        this.mErrOpt.ErrorOperate(this.mSubSysName, "GXFormMainFrame.FormMainEdit", "ClipXBCreateFeature", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                    }
                    pf = pFCursor.NextFeature();
                }
                return true;
            }
            catch (Exception exception3)
            {
                exception = exception3;
                this.mErrOpt.ErrorOperate(this.mSubSysName, "GXFormMainFrame.FormMainEdit", "ClipXBCreateFeature", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                return false;
            }
        }

        public void CloseDesign()
        {
            try
            {
                this.mEditLayer2 = null;
                this.m_project = null;
                this.m_controlsSynchronizer2.SetMapOfMapToPagelayout();
                this.m_controlsSynchronizer2.ActivateMap();
                //   IDBAccess dBAccess = null;
                //if (UtilFactory.GetConfigOpt().GetConfigValue("MapDBkey") == "Local")
                //{
                //    dBAccess = UtilFactory.GetDBAccess("Access");
                //}
                //else if (UtilFactory.GetConfigOpt().GetConfigValue("MapDBkey") == "SqlServer")
                //{
                //    dBAccess = UtilFactory.GetDBAccess("SqlServer");
                //}
                if (EditTask.TaskState == TaskState2.Create)
                {
                    EditTask.TaskState = TaskState2.Edit;
                }
                string sCmdText = string.Concat(new object[] { "update T_EditTask_ZT set logiccheckstate='", EditTask.LogicChkState.GetHashCode(), "' where ID= ", EditTask.TaskID });
                //    dBAccess.ExecuteScalar(sCmdText);
                sCmdText = string.Concat(new object[] { "update T_EditTask_ZT set toplogiccheckstate='", EditTask.ToplogicChkState.GetHashCode(), "' where ID= ", EditTask.TaskID });
                //  dBAccess.ExecuteScalar(sCmdText);
                sCmdText = string.Concat(new object[] { "update T_EditTask_ZT set taskstate='", EditTask.TaskState.GetHashCode(), "' where ID= ", EditTask.TaskID });
                //   dBAccess.ExecuteScalar(sCmdText);
                ArrayList tag = this.barButtonItemSelectFeature.Tag as ArrayList;
                ICommand command = tag[0] as ICommand;
                base.MapControlEdit.CurrentTool = command as ITool;
                this.barButtonItemSelectFeature.Down = true;
                base.barStaticItemInfo.Caption = "就绪";
                this.barButtonItemReportCF.Visibility = BarItemVisibility.Never;
                this.barButtonItemReportCF1.Visibility = BarItemVisibility.Always;
                this.barButtonItemChartCF.Visibility = BarItemVisibility.Always;
                this.SetFormText();
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "GXFormMainFrame.FormMainEdit", "CloseDesign", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        public void CloseZZYProject()
        {
            try
            {
                IWorkspaceEdit editWorkspace = EditTask.EditWorkspace as IWorkspaceEdit;
                if (((TaskManageClass.TaskState.ToString() == TaskState.Open.ToString()) && editWorkspace.IsBeingEdited()) && Editor.UniqueInstance.IsBeingEdited)
                {
                    Editor.UniqueInstance.StopEdit();
                }
                this.barButtonItemInput.Enabled = false;
                this.barButtonItemInputProperty.Enabled = false;
                this.barButtonItemImportRedline.Enabled = false;
                this.barEditItemEditLayer.Enabled = false;
                this.barButtonItemCreateByPolygon.Enabled = false;
                this.barButtonItemCreateByPolygon2.Enabled = false;
                this.barButtonItemSmoothPolygon.Enabled = false;
                this.barButtonItemPropertyByXB.Enabled = false;
                this.barButtonItemInputPropertyList.Enabled = false;
                this.barButtonItemSaveEdit.Enabled = false;
                this.barButtonItemCheckDist.Visibility = BarItemVisibility.Never;
                TaskManageClass.TaskState = TaskState.Close;
                base.barStaticItemInfo.Caption = EditTask.TaskName;
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "GXFormMainFrame.FormMainEdit", "CloseZZYProject", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
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

        private void dockPanelBottom_MouseMove(object sender, MouseEventArgs e)
        {
            base.ribbon.SetPopupContextMenu(this, null);
        }

        private void dockPanelEdit_ClosedPanel(object sender, DockPanelEventArgs e)
        {
            if (this.barButtonItemInput.Down)
            {
                this.barButtonItemInput.Down = false;
                this.barButtonItemInput_ItemClick(sender, null);
            }
        }

        private void dockPanelEdit_MouseMove(object sender, MouseEventArgs e)
        {
            base.ribbon.SetPopupContextMenu(this, null);
        }

        private void dockPanelToolbox_ClosedPanel(object sender, DockPanelEventArgs e)
        {
            base.barButtonItemToolbox.Down = false;
        }

        private void dockPanelToolbox_MouseMove(object sender, MouseEventArgs e)
        {
            base.ribbon.SetPopupContextMenu(this, null);
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
                try
                {
                    Marshal.ReleaseComObject(Editor.UniqueInstance);
                }
                catch (Exception)
                {
                }
                AOUninitialize.Shutdown();
                GC.Collect();
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

        [DllImport("user32.dll")]
        public static extern bool GetCursorPos(out System.Drawing.Point pt);
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

        private ArrayList GetSelectionLayerCollection(IMap m_Map)
        {
            try
            {
                if (m_Map == null)
                {
                    return null;
                }
                ArrayList pSelLayerCol = new ArrayList();
                for (int i = 0; i < m_Map.LayerCount; i++)
                {
                    this.CheckSelectionLayer(m_Map.get_Layer(i), pSelLayerCol);
                }
                return pSelLayerCol;
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "GXFormMainFrame.FormMainEdit", "GetSelectionLayerCollection", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                return null;
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
                this.barButtonItemFullMap.RibbonStyle = RibbonItemStyles.SmallWithText;
                pCommand = new MapZoomInTool();
                this.CreateCommand(pCommand, ref this.barButtonItemZoomIn, this.mButtonCollection2, -1, false, base.MapControlEdit.Object, "");
                pCommand = new MapZoomInTool();
                this.CreateCommand(pCommand, ref this.barButtonItemZoomIn, this.mButtonCollection2, -1, false, base.PageLayoutControlEdit.Object, "");
                this.barButtonItemZoomIn.RibbonStyle = RibbonItemStyles.SmallWithText;
                pCommand = new MapZoomOutTool();
                this.CreateCommand(pCommand, ref this.barButtonItemZoomOut, this.mButtonCollection2, -1, false, base.MapControlEdit.Object, "");
                pCommand = new MapZoomOutTool();
                this.CreateCommand(pCommand, ref this.barButtonItemZoomOut, this.mButtonCollection2, -1, false, base.PageLayoutControlEdit.Object, "");
                this.barButtonItemZoomOut.RibbonStyle = RibbonItemStyles.SmallWithText;
                pCommand = new MapPanTool();
                this.CreateCommand(pCommand, ref this.barButtonItemPan, this.mButtonCollection2, -1, false, base.MapControlEdit.Object, "");
                pCommand = new MapPanTool();
                this.CreateCommand(pCommand, ref this.barButtonItemPan, this.mButtonCollection2, -1, false, base.PageLayoutControlEdit.Object, "");
                this.barButtonItemPan.RibbonStyle = RibbonItemStyles.SmallWithText;
                pCommand = new MapIdentifyTool();
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
                pCommand = new CmdAddDXT();
                this.CreateCommand(pCommand, ref this.barButtonItemAddDRG, this.mButtonCollection, -1, false, base.MapControlEdit.Object, "加载当前视图范围工作底图");
                pCommand = new CmdSmoothPolygon();
                this.CreateCommand(pCommand, ref this.barButtonItemSmoothPolygon, this.mButtonCollection, -1, false, base.MapControlEdit.Object, "");
                pCommand = new MeasureTool();
                this.CreateCommand(pCommand, ref this.barButtonItemMeasure, this.mButtonCollection, -1, false, base.MapControlEdit.Object, "");
                pCommand = new CmdExportSub();
                this.CreateCommand(pCommand, ref this.barButtonItemExportSub, this.mButtonCollection, -1, false, base.MapControlEdit.Object, "");
                pCommand = new CmdExportZT();
                this.CreateCommand(pCommand, ref this.barButtonItemExportZT, this.mButtonCollection, -1, false, base.MapControlEdit.Object, "");
                pCommand = new CmdSetArea();
                this.CreateCommand(pCommand, ref this.barButtonItemArea, this.mButtonCollection, -1, false, base.MapControlEdit.Object, "");
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "GXFormMainFrame.FormMainEdit", "InitializeBaseButtonComm", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        /// <summary>
        /// 初始化编辑视图的工具
        /// </summary>
        private void InitializeBaseButtonEdit()
        {
            try
            {
                this.mEditLayer = EditTask.EditLayer;
                Editor.UniqueInstance.StartEdit(this.mEditLayer.FeatureClass.FeatureDataset.Workspace, base.MapControlEdit.ActiveView.FocusMap);
                Editor.UniqueInstance.TargetLayer = this.mEditLayer;
                AttributeManager.AttributeCombineHandleClass = new CombineHandleClass(base.MapControlEdit.Object, this.userControlAttrEdit1);
                AttributeManager.AttributeSplitHandleClass = new SplitHandleClass(base.MapControlEdit.Object, this.userControlAttrEdit1);
                AttributeManager.AttributeAddHandleClass = new AddHandleClass(base.MapControlEdit.Object, this.userControlAttrEdit1);
                AttributeManager.AttributeDeleteHandleClass = new DeleteHandleClass(this.userControlAttrEdit1);
                AttributeManager.AttributeUndoHandleClass = new UndoHandleClass(this.userControlAttrEdit1);
                this._editMapToolBar.SetBuddyControl(base.MapControlEdit.Object);
                Editor.UniqueInstance.BuddyToolBarControl(this._editMapToolBar.Object as IToolbarControl);
                this._editMapToolBar.AddItem(ToolFactory.GetEditTool(), 0, 0, false, 0, esriCommandStyles.esriCommandStyleTextOnly);
                this._editMapToolBar.AddItem(ToolFactory.GetInsertVertexTool(), 0, 1, false, 0, esriCommandStyles.esriCommandStyleTextOnly);
                this._editMapToolBar.AddItem(ToolFactory.GetDeleteVertexTool(), 0, 2, false, 0, esriCommandStyles.esriCommandStyleTextOnly);
                this._editMapToolBar.AddItem(new ShapeEdit.Undo(), 0, 3, false, 0, esriCommandStyles.esriCommandStyleTextOnly);
                this._editMapToolBar.AddItem(new ShapeEdit.Redo(), 0, 4, false, 0, esriCommandStyles.esriCommandStyleTextOnly);
                ICommand sketchTool = ToolFactory.GetSketchTool() as ICommand;
                this.CreateCommand(sketchTool, ref this.barButtonItemAddFeature, this.mButtonCollection, -1, true, base.MapControlEdit.Object, "添加班块");
                sketchTool = ToolFactory.GetHxTool() as ICommand;
                this.CreateCommand(sketchTool, ref this.barButtonItemAddLine, this.mButtonCollection, -1, true, base.MapControlEdit.Object, "添加红线");
                sketchTool = new Delete1();
                this.CreateCommand(sketchTool, ref this.barButtonItemDeleteFeature, this.mButtonCollection, -1, true, base.MapControlEdit.Object, "");
                sketchTool = ToolFactory.GetSplitTool() as ICommand;
                this.CreateCommand(sketchTool, ref this.barButtonItemSplitFeature, this.mButtonCollection, -1, true, base.MapControlEdit.Object, "");
                sketchTool = new SnapPro(this);
                this.CreateCommand(sketchTool, ref this.barButtonItemBoudarySnap, this.mButtonCollection, -1, true, base.MapControlEdit.Object, "追踪图层要素节点");
                sketchTool = ToolFactory.QuickSnapTool() as ICommand;
                this.CreateCommand(sketchTool, ref this.barButtonItemQuickSnap, this.mButtonCollection, -1, true, base.MapControlEdit.Object, "");
                sketchTool = new Combine();
                this.CreateCommand(sketchTool, ref this.barButtonItemCombineFeature, this.mButtonCollection, -1, true, base.MapControlEdit.Object, "");
                sketchTool = ToolFactory.GetEraseTool() as ICommand;
                this.CreateCommand(sketchTool, ref this.barButtonItemEraseFeature, this.mButtonCollection, -1, true, base.MapControlEdit.Object, "");
                sketchTool = ToolFactory.GetErase2Tool() as ICommand;
                this.CreateCommand(sketchTool, ref this.barButtonItemCutFeature, this.mButtonCollection, -1, true, base.MapControlEdit.Object, "");
                sketchTool = new Explode();
                this.CreateCommand(sketchTool, ref this.barButtonItemExplode, this.mButtonCollection, -1, true, base.MapControlEdit.Object, "");
                sketchTool = ToolFactory.GetAutocompleteTool() as ICommand;
                this.CreateCommand(sketchTool, ref this.barButtonItemAutoComplete, this.mButtonCollection, -1, true, base.MapControlEdit.Object, "");
                sketchTool = ToolFactory.GetLinkageEditTool() as ICommand;
                this.CreateCommand(sketchTool, ref this.barButtonItemLinkageEdit, this.mButtonCollection, -1, true, base.MapControlEdit.Object, "");
                sketchTool = ToolFactory.GetLinkageInsertVertexTool() as ICommand;
                this.CreateCommand(sketchTool, ref this.barButtonItemLinkageAdd, this.mButtonCollection, -1, true, base.MapControlEdit.Object, "");
                sketchTool = ToolFactory.GetLinkageDeleteVertexTool() as ICommand;
                this.CreateCommand(sketchTool, ref this.barButtonItemLinkageDelete, this.mButtonCollection, -1, true, base.MapControlEdit.Object, "");
                sketchTool = this._editMapToolBar.GetItem(0).Command;
                this.CreateCommand(sketchTool, ref this.barButtonItemEditFeature, this.mButtonCollection, -1, true, base.MapControlEdit.Object, "选择、移动编辑班块");
                sketchTool = this._editMapToolBar.GetItem(1).Command;
                this.CreateCommand(sketchTool, ref this.barButtonItemVertexInsert, this.mButtonCollection, -1, true, base.MapControlEdit.Object, "");
                sketchTool = this._editMapToolBar.GetItem(2).Command;
                this.CreateCommand(sketchTool, ref this.barButtonItemVertexDelete, this.mButtonCollection, -1, true, base.MapControlEdit.Object, "");
                sketchTool = this._editMapToolBar.GetItem(3).Command;
                this.CreateCommand(sketchTool, ref this.barButtonItemEditUndo, this.mButtonCollection, -1, false, base.MapControlEdit.Object, "");
                sketchTool = this._editMapToolBar.GetItem(4).Command;
                this.CreateCommand(sketchTool, ref this.barButtonItemEditRedo, this.mButtonCollection, -1, false, base.MapControlEdit.Object, "");
                sketchTool = new Copy();
                this.CreateCommand(sketchTool, ref this.barButtonItemShapeCopy, this.mButtonCollection, -1, false, base.MapControlEdit.Object, "");
                sketchTool = new Paste();
                this.CreateCommand(sketchTool, ref this.barButtonItemShapePaste, this.mButtonCollection, -1, false, base.MapControlEdit.Object, "");
                sketchTool = new ToolAttributesEdit(this.userControlAttrEdit1);
                this.CreateCommand(sketchTool, ref this.barButtonItemInputProperty, this.mButtonCollection, -1, false, base.MapControlEdit.Object, "属性录入");
                sketchTool = new CmdCopyHarvest();
                this.CreateCommand(sketchTool, ref this.barButtonItemCopyHarvest, this.mButtonCollection, -1, false, base.MapControlEdit.Object, "复制桉树采伐班块");
                sketchTool = new CmdSetUniqueValue();
                this.CreateCommand(sketchTool, ref this.barButtonItemInputProperties, this.mButtonCollection, -1, false, base.MapControlEdit.Object, "批量修改指定字段属性值");
                sketchTool = new CmdRulerSet();
                this.CreateCommand(sketchTool, ref this.barButtonItemNessRule, this.mButtonCollection, -1, false, base.MapControlEdit.Object, "");
                sketchTool = new CmdSingleLayerCheck(1);
                this.CreateCommand(sketchTool, ref this.barButtonItemCheckDist, this.mButtonCollection, -1, false, base.MapControlEdit.Object, "");
                sketchTool = new CmdXCPolygonCheck();
                this.CreateCommand(sketchTool, ref this.barButtonItemCheckXCPolygon, this.mButtonCollection, -1, false, base.MapControlEdit.Object, "");
                sketchTool = new CmdSingleLayerCheck(0);
                this.CreateCommand(sketchTool, ref this.barButtonItemTotalLayer, this.mButtonCollection, -1, false, base.MapControlEdit.Object, "");
                sketchTool = new CmdMultiLayerCheck();
                this.CreateCommand(sketchTool, ref this.barButtonItemCheckLayers, this.mButtonCollection, -1, false, base.MapControlEdit.Object, "");
                sketchTool = new PointRepeatCheckTool(this.mEditLayer);
                this.CreateCommand(sketchTool, ref this.barButtonItemCheckRepeat, this.mButtonCollection, -1, false, base.MapControlEdit.Object, "");
                sketchTool = new SelfIntersectCheckTool(this.mEditLayer);
                this.CreateCommand(sketchTool, ref this.barButtonItemCheckSelfIntersect, this.mButtonCollection, -1, false, base.MapControlEdit.Object, "");
                sketchTool = new AngleCheckTool(this.mEditLayer, this);
                this.CreateCommand(sketchTool, ref this.barButtonItemCheckAngle, this.mButtonCollection, -1, false, base.MapControlEdit.Object, "");
                sketchTool = new AreaCheckTool(this.mEditLayer, this);
                this.CreateCommand(sketchTool, ref this.barButtonItemCheckArea, this.mButtonCollection, -1, false, base.MapControlEdit.Object, "");
                sketchTool = new OverlapCheckTool();
                this.CreateCommand(sketchTool, ref this.barButtonItemTotalLayer, this.mButtonCollection, -1, false, base.MapControlEdit.Object, "");
                sketchTool = new ClearTopoErr();
                this.CreateCommand(sketchTool, ref this.barButtonItemClearTopErr, this.mButtonCollection, -1, false, base.MapControlEdit.Object, "");
                sketchTool = new OverlapCheckTool();
                this.CreateCommand(sketchTool, ref this.barButtonItemCheckOverlap, this.mButtonCollection, -1, false, base.MapControlEdit.Object, "");
                sketchTool = new GapsCheckTool();
                this.CreateCommand(sketchTool, ref this.barButtonItemCheckGap, this.mButtonCollection, -1, false, base.MapControlEdit.Object, "");
                if (this.m_CountyFeature != null)
                {
                    sketchTool = new BoundaryBeyondCheckTool(this.m_CountyFeature.ShapeCopy);
                    this.CreateCommand(sketchTool, ref this.barButtonItemCheckBoundary, this.mButtonCollection, -1, false, base.MapControlEdit.Object, "");
                }
                sketchTool = ToolFactory.GetSimplifyTool() as ICommand;
                this.CreateCommand(sketchTool, ref this.barButtonItemSimplify, this.mButtonCollection, -1, false, base.MapControlEdit.Object, "");
                sketchTool = ToolFactory.GetOverlapCombineTool() as ICommand;
                this.CreateCommand(sketchTool, ref this.barButtonItemOverlapCombine, this.mButtonCollection, -1, false, base.MapControlEdit.Object, "");
                sketchTool = ToolFactory.GetOverlapDeleteTool() as ICommand;
                this.CreateCommand(sketchTool, ref this.barButtonItemOverlapDelete, this.mButtonCollection, -1, false, base.MapControlEdit.Object, "");
                sketchTool = ToolFactory.GetOverlapConvertTool() as ICommand;
                this.CreateCommand(sketchTool, ref this.barButtonItemOverlapConvert, this.mButtonCollection, -1, false, base.MapControlEdit.Object, "");
                sketchTool = ToolFactory.GetRPointDeleteExTool() as ICommand;
                this.CreateCommand(sketchTool, ref this.barButtonItemDeleteFeature, this.mButtonCollection, -1, false, base.MapControlEdit.Object, "");
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "GXFormMainFrame.FormMainEdit", "InitializeBaseButtonEdit", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
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
                pCommand = new TF();
                this.CreateCommand(pCommand, ref this.barButtonItem_TF, this.mButtonCollection2, -1, true, base.PageLayoutControlEdit.Object, "");
                pCommand = new Coordinate();
                this.CreateCommand(pCommand, ref this.barButtonItem_Coordinate, this.mButtonCollection2, -1, true, base.PageLayoutControlEdit.Object, "");
                pCommand = new cmdSaveTemplate();
                this.CreateCommand(pCommand, ref this.bbiSaveTemplate, this.mButtonCollection2, -1, true, base.PageLayoutControlEdit.Object, "");
                pCommand = new ToolScaleText();
                this.CreateCommand(pCommand, ref this.barButtonItemScaleText, this.mButtonCollection2, -1, true, base.PageLayoutControlEdit.Object, "");
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainFrameEdit));
            DevExpress.Utils.SuperToolTip superToolTip1 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipItem toolTipItem1 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.SuperToolTip superToolTip2 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipItem toolTipItem2 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.SuperToolTip superToolTip3 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipItem toolTipItem3 = new DevExpress.Utils.ToolTipItem();
            this.splitterControl1 = new DevExpress.XtraEditors.SplitterControl();
            this.barButtonItemZoomIn = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemZoomOut = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemFullMap = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemPan2 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemPan = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemIdentify = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemBack = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemForward = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemRefresh = new DevExpress.XtraBars.BarButtonItem();
            this.userControlOverView = new GISControlsClass.UserControlOverView();
            this.barButtonItemSelectFeature = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemSelectLayerSet = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemSelectByAttributes = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemSelectedFeaturesReport = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemClearSelectFeature = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemTOC = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemOverView = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemTOC2 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemAddDRG = new DevExpress.XtraBars.BarButtonItem();
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
            this.ribbonPageGroupAddnew = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.barButtonItemInput = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemAddFeature = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemAddLine = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemAutoComplete = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemXBUpdate = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemCreateByPolygon = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPageGroupEdit = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.barButtonItemEditFeature = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemLinkageEdit = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemSplitFeature = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemCombineFeature = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemExplode = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemInputProperty = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemCopyHarvest = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemInputPropertyList = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemInputProperties = new DevExpress.XtraBars.BarButtonItem();
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
            this.barButtonItemEraseFeature = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemCutFeature = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemCreateByPolygon2 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemPropertyByXB = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemSmoothPolygon = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemQuickSnap = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemIdentify2 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemShapeCopy = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPageGroupMapView = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.popupMenuMapView = new DevExpress.XtraBars.PopupMenu(this.components);
            this.ribbonPageGroupCommEdit = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.barButtonItemShapePaste = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemEditUndo = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemEditRedo = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemSaveEdit = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPageGroupToplogic2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.barButtonItemNessRule = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemCheckDist = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemTotalLayer = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemCheckXCPolygon = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemCheckLayers = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemSingleCheck = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemTopModify = new DevExpress.XtraBars.BarButtonItem();
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
            this.xtraTabPageFireManage = new DevExpress.XtraTab.XtraTabPage();
            this.userControlFireManage1 = new AttributesEdit.UserControlFireManage();
            this.xtraTabPageInputData = new DevExpress.XtraTab.XtraTabPage();
            this.userControlInputData = new DataEdit.UserControlInputData2();
            this.xtraTabPageConvertData = new DevExpress.XtraTab.XtraTabPage();
            this.userControlConvertData = new DataEdit.UserControlConvertData();
            this.xtraTabPageUpdate = new DevExpress.XtraTab.XtraTabPage();
            this.userControlUpdate1 = new AttributesEdit.UserControlUpdate();
            this.xtraTabPageAttriList = new DevExpress.XtraTab.XtraTabPage();
            this.userControlAttriList1 = new AttributesEdit.UserControlAttriList();
            this.userControlInfo = new QueryCommon.UserControlInfo();
            this.userControlLayerControl = new GISControlsClass.UserControlLayerControl();
            this.xtraTabPageSelect = new DevExpress.XtraTab.XtraTabPage();
            this.userControlSelectLayerSet1 = new GISControlsClass.UserControlSelectLayerSet();
            this.xtraTabPageSelectByAttributes = new DevExpress.XtraTab.XtraTabPage();
            this.userControlSelectByAttributes = new GISControlsClass.UserControlSelectByAttributes();
            this.ribbonPageGroupQuery = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.barButtonItemQueryTF = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPageGroupQuery2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.barButtonItemQueryXB = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemDesignQuery = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemHZInfoTable = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPageGroupMapView2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroupMapView3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.xtraTabPageMapFind = new DevExpress.XtraTab.XtraTabPage();
            this.userControlMapFind1 = new QueryCommon.UserControlMapFind();
            this.xtraTabPageLocation = new DevExpress.XtraTab.XtraTabPage();
            this.userControlLocation = new QueryCommon.UserControlLocation();
            this.ribbonPageGroupMxt = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.barButtonItemSJ = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemDC = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemZTT = new DevExpress.XtraBars.BarButtonItem();
            this.barEditItem_fx = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemComboBox5 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.bsiNormal = new DevExpress.XtraBars.BarSubItem();
            this.bbiSaveTemplate = new DevExpress.XtraBars.BarButtonItem();
            this.bbiLoadTempalte = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPageGroupPageTool = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.barButtonItemMapFrame = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemMapGrid = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemMapLegend = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemMapScaleBar = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemScaleText = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemMapNorthArrow = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemMapText = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemMapComment = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem_XZ = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem_XZ2 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem_TF = new DevExpress.XtraBars.BarButtonItem();
            this.bsi_Coordinate = new DevExpress.XtraBars.BarSubItem();
            this.barButtonItem_Coordinate = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem_Auto = new DevExpress.XtraBars.BarButtonItem();
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
            this.userControlImportLC1 = new GeoDataIE.UserControlImportLC();
            this.userControlXBGrowth1 = new DataEdit.UserControlXBGrowth();
            this.userControlXBLayerCombine1 = new DataEdit.UserControlXBLayerCombine();
            this.userControlXBSet31 = new DataEdit.UserControlXBSet3();
            this.userControlXBSet21 = new DataEdit.UserControlXBSet();
            this.userControlInputYG1 = new DataEdit.UserControlInputYG();
            this.userControlInputGYL1 = new DataEdit.UserControlInputGYL();
            this.userControlUpdateAS21 = new GX_DB_INFO.UserControlUpdateAS2();
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
            this.userControlQueryYG = new QueryAnalysic.UserControlQueryYG();
            this.ribbonPageGroupCaoTu = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.barButtonItemInputZT = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemInputYG = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemInputDC = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemInputGYL = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemInputOther = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemLayerCombine = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPageGroupXB = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.barButtonItemArea = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemGrowthModel = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemSSA = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemXJ = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemLinZu = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemInputEL = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemXBEdit = new DevExpress.XtraBars.BarButtonItem();
            this.xtraTabQuery = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
            this.userControlQueryResult2 = new QueryCommon.UserControlQueryResult();
            this.xtraTabPage3 = new DevExpress.XtraTab.XtraTabPage();
            this.userControlSelectFeatureResport21 = new GISControlsClass.UserControlSelectFeatureResport2();
            this.xtraTabPage4 = new DevExpress.XtraTab.XtraTabPage();
            this.userControlTaskInfo1 = new TaskManage.UserControlTaskInfo();
            this.barButtonItemAddLayer3 = new DevExpress.XtraBars.BarButtonItem();
            this.xtraTabPageAddRasterlayer = new DevExpress.XtraTab.XtraTabPage();
            this.userControlImageGeoReference1 = new DataEdit.UserControlImageGeoReference2();
            this.ribbonPageStatic = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroupCF = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.barButtonItemReportCF1 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemChartCF = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemReportFCDC = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemReportCF = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPageGroupZL = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.barButtonItemReportZL = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemChartZL = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPageGroupHZ = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.barButtonItemReportHZ = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemReportHZRegion = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemReportHZKind = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemChartHZ = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPageGroupZZY = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.barButtonItemReportZZY1 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemReportZZY2 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemReportZZY3 = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPageGroupZH = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.barButtonItemReportZH = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPageGroupAJ = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.barButtonItemReportAJ = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPageGroupReportXB = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.barButtonItemStatic = new DevExpress.XtraBars.BarButtonItem();
            this.xtraTabPagePlace = new DevExpress.XtraTab.XtraTabPage();
            this.userControlPlace1 = new QueryCommon.UserControlPlace();
            this.xtraTabPageTFH = new DevExpress.XtraTab.XtraTabPage();
            this.userControlQueryTFH1 = new QueryAnalysic.UserControlQueryTFH();
            this.userControlQueryCF1 = new QueryAnalysic.UserControlQueryCF();
            this.xtraTabPageKind = new DevExpress.XtraTab.XtraTabPage();
            this.userControlQueryZZY21 = new QueryAnalysic.UserControlQueryZZY2();
            this.userControlQueryHZ21 = new QueryAnalysic.UserControlQueryHZ2();
            this.userControlQueryXB21 = new QueryAnalysic.UserControlQueryXB2();
            this.userControlQueryCF21 = new QueryAnalysic.UserControlQueryCF2();
            this.userControlQueryZL1 = new QueryAnalysic.UserControlQueryZL();
            this.repositoryItemRadioGroup1 = new DevExpress.XtraEditors.Repository.RepositoryItemRadioGroup();
            this.repositoryItemRadioGroup2 = new DevExpress.XtraEditors.Repository.RepositoryItemRadioGroup();
            this.repositoryItemCheckEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.repositoryItemComboBox2 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.repositoryItemRadioGroup3 = new DevExpress.XtraEditors.Repository.RepositoryItemRadioGroup();
            this.repositoryItemComboBox3 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.repositoryItemCheckEdit3 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.barButtonItemFireTable = new DevExpress.XtraBars.BarButtonItem();
            this.repositoryItemRadioGroup4 = new DevExpress.XtraEditors.Repository.RepositoryItemRadioGroup();
            this.repositoryItemRadioGroup5 = new DevExpress.XtraEditors.Repository.RepositoryItemRadioGroup();
            this.repositoryItemRadioGroup6 = new DevExpress.XtraEditors.Repository.RepositoryItemRadioGroup();
            this.repositoryItemComboBox4 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.repositoryItemPictureEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit();
            this.repositoryItemRadioGroup7 = new DevExpress.XtraEditors.Repository.RepositoryItemRadioGroup();
            this.barButtonItemImport = new DevExpress.XtraBars.BarButtonItem();
            this.xtraTabPageDesign = new DevExpress.XtraTab.XtraTabPage();
            this.userControlQueryDesign1 = new QueryAnalysic.UserControlQueryDesign();
            this.ribbonPageGroupInputTable = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.barButtonItem4 = new DevExpress.XtraBars.BarButtonItem();
            this.userControlQueryHZ1 = new QueryAnalysic.UserControlQueryHZ();
            this.ribbonPageGroupEditLayer = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.barEditItem3 = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.barEditItemEditLayer = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemComboBox7 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.barEditItemEditLayer0 = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemRadioGroup8 = new DevExpress.XtraEditors.Repository.RepositoryItemRadioGroup();
            this.barEditItem2 = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemComboBox6 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.ribbonPageGroupImportBack = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.barButtonItemImportRedline = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPageGroupProject = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.barButtonItemProjectList = new DevExpress.XtraBars.BarButtonItem();
            this.xtraTabPageProject = new DevExpress.XtraTab.XtraTabPage();
            this.userControlProjectList1 = new TaskManage.UserControlProjectList();
            this.userControlDesignList1 = new TaskManage.UserControlDesignList();
            this.userControlQueryZZY1 = new QueryAnalysic.UserControlQueryZZY();
            this.userControlQueryZH1 = new QueryAnalysic.UserControlQueryZH();
            this.userControlQueryAJ1 = new QueryAnalysic.UserControlQueryAJ();
            this.barButtonItemMapSet = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemOutCFTable = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemExportSub = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemExportZT = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemExportXM = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemOpen2 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemSetSpatialreference = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemExit = new DevExpress.XtraBars.BarButtonItem();
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
            this.panelFull.SuspendLayout();
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
            this.xtraTabPageFireManage.SuspendLayout();
            this.xtraTabPageInputData.SuspendLayout();
            this.xtraTabPageConvertData.SuspendLayout();
            this.xtraTabPageUpdate.SuspendLayout();
            this.xtraTabPageAttriList.SuspendLayout();
            this.xtraTabPageSelect.SuspendLayout();
            this.xtraTabPageSelectByAttributes.SuspendLayout();
            this.xtraTabPageMapFind.SuspendLayout();
            this.xtraTabPageLocation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox5)).BeginInit();
            this.xtraTabPageXBchange.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabQuery)).BeginInit();
            this.xtraTabQuery.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
            this.xtraTabPage2.SuspendLayout();
            this.xtraTabPage3.SuspendLayout();
            this.xtraTabPage4.SuspendLayout();
            this.xtraTabPageAddRasterlayer.SuspendLayout();
            this.xtraTabPagePlace.SuspendLayout();
            this.xtraTabPageTFH.SuspendLayout();
            this.xtraTabPageKind.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemRadioGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemRadioGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemRadioGroup3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemRadioGroup4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemRadioGroup5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemRadioGroup6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemRadioGroup7)).BeginInit();
            this.xtraTabPageDesign.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemRadioGroup8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox6)).BeginInit();
            this.xtraTabPageProject.SuspendLayout();
            this.SuspendLayout();
            // 
            // applicationMenu1
            // 
            this.applicationMenu1.ItemLinks.Add(this.barButtonItemOpen2, true);
            this.applicationMenu1.ItemLinks.Add(this.barButtonItemOpen);
            this.applicationMenu1.ItemLinks.Add(this.barButtonItemSetSpatialreference, true);
            this.applicationMenu1.ItemLinks.Add(this.barButtonItemImport, true);
            this.applicationMenu1.ItemLinks.Add(this.barButtonItemOutCFTable, true);
            this.applicationMenu1.ItemLinks.Add(this.barButtonItemExportZT, true);
            this.applicationMenu1.ItemLinks.Add(this.barButtonItemExportXM, true);
            this.applicationMenu1.ItemLinks.Add(this.barButtonItemExportSub, true);
            this.applicationMenu1.ItemLinks.Add(this.barButtonItemExportImage, true);
            this.applicationMenu1.ItemLinks.Add(this.barButtonItemPrintSet, true);
            this.applicationMenu1.ItemLinks.Add(this.barButtonItemMapSet);
            this.applicationMenu1.ItemLinks.Add(this.barButtonItemPrintPreview);
            this.applicationMenu1.ItemLinks.Add(this.barButtonItemPrint);
            this.applicationMenu1.ItemLinks.Add(this.barButtonItemExit, true);
            // 
            // axTOCControl
            // 
            this.axTOCControl.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axTOCControl.OcxState")));
            this.axTOCControl.Size = new System.Drawing.Size(266, 306);
            // 
            // defaultLookAndFeel1
            // 
            this.defaultLookAndFeel1.LookAndFeel.SkinName = "Blue";
            // 
            // dockPanelBottom
            // 
            this.dockPanelBottom.Location = new System.Drawing.Point(280, 575);
            this.dockPanelBottom.Size = new System.Drawing.Size(992, 200);
            // 
            // dockPanelBottom_Container
            // 
            this.dockPanelBottom_Container.Controls.Add(this.xtraTabQuery);
            this.dockPanelBottom_Container.Size = new System.Drawing.Size(986, 168);
            // 
            // dockPanelEdit
            // 
            this.dockPanelEdit.FloatSize = new System.Drawing.Size(300, 600);
            this.dockPanelEdit.Location = new System.Drawing.Point(886, 153);
            this.dockPanelEdit.OriginalSize = new System.Drawing.Size(400, 200);
            this.dockPanelEdit.Size = new System.Drawing.Size(400, 622);
            this.dockPanelEdit.ClosedPanel += new DevExpress.XtraBars.Docking.DockPanelEventHandler(this.dockPanelEdit_ClosedPanel);
            // 
            // dockPanelEdit_Container
            // 
            this.dockPanelEdit_Container.Controls.Add(this.xtraTabControlEdit);
            this.dockPanelEdit_Container.Size = new System.Drawing.Size(394, 590);
            // 
            // dockPanelToolbox
            // 
            this.dockPanelToolbox.OriginalSize = new System.Drawing.Size(280, 200);
            this.dockPanelToolbox.Size = new System.Drawing.Size(280, 587);
            this.dockPanelToolbox.ClosedPanel += new DevExpress.XtraBars.Docking.DockPanelEventHandler(this.dockPanelToolbox_ClosedPanel);
            // 
            // dockPanelToolbox_Container
            // 
            this.dockPanelToolbox_Container.Size = new System.Drawing.Size(272, 560);
            // 
            // imageCollection1
            // 
            this.imageCollection1.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection1.ImageStream")));
            this.imageCollection1.TransparentColor = System.Drawing.Color.White;
            // 
            // imageCollection2
            // 
            this.imageCollection2.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection2.ImageStream")));
            // 
            // MapControlEdit
            // 
            this.MapControlEdit.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("MapControlEdit.OcxState")));
            this.MapControlEdit.Size = new System.Drawing.Size(695, 513);
            this.MapControlEdit.OnAfterDraw += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnAfterDrawEventHandler(this.MapControlEdit_OnAfterDraw);
            this.MapControlEdit.Leave += new System.EventHandler(this.MapControlEdit_Leave);
            // 
            // PageLayoutControlEdit
            // 
            this.PageLayoutControlEdit.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("PageLayoutControlEdit.OcxState")));
            this.PageLayoutControlEdit.Size = new System.Drawing.Size(981, 513);
            // 
            // panelFull
            // 
            this.panelFull.Location = new System.Drawing.Point(280, 149);
            this.panelFull.Size = new System.Drawing.Size(736, 587);
            // 
            // ribbon
            // 
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barButtonItemOpen2,
            this.barButtonItemOpen,
            this.barButtonItemSetSpatialreference,
            this.barButtonItemImport,
            this.barButtonItemOutCFTable,
            this.barButtonItemExportZT,
            this.barButtonItemExportXM,
            this.barButtonItemExportSub,
            this.barButtonItemExportImage,
            this.barButtonItemPrintSet,
            this.barButtonItemMapSet,
            this.barButtonItemPrintPreview,
            this.barButtonItemPrint,
            this.barButtonItemExit,
            this.barButtonItemZoomIn,
            this.barButtonItemZoomOut,
            this.barButtonItemFullMap,
            this.barButtonItemPan2,
            this.barButtonItemPan,
            this.barButtonItemIdentify,
            this.barButtonItemBack,
            this.barButtonItemForward,
            this.barButtonItemRefresh,
            this.barButtonItemSelectFeature,
            this.barButtonItemSelectLayerSet,
            this.barButtonItemSelectByAttributes,
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
            this.barButtonItemInputPropertyList,
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
            this.barButtonToolbox,
            this.barButtonToolView,
            this.barButtonItemSJ,
            this.barButtonItemDC,
            this.barButtonItemQueryTF,
            this.barButtonItemXBUpdate,
            this.barEditItem1,
            this.barSubItemButtonStyle,
            this.barButtonItemLargeButton,
            this.barButtonItemSmallButton,
            this.barButtonItemSmallText,
            this.barButtonGroup1,
            this.barButtonItemCheckDist,
            this.barButtonItemCheckXCPolygon,
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
            this.barButtonItemSSA,
            this.barButtonItem_TF,
            this.barButtonItemFireTable,
            this.barEditItem_fx,
            this.bsiNormal,
            this.bbiSaveTemplate,
            this.bbiLoadTempalte,
            this.bsi_Coordinate,
            this.barButtonItem_Coordinate,
            this.barButtonItem_Auto,
            this.barButtonItemDesignQuery,
            this.barButtonItemExplode,
            this.barButtonItemZTT,
            this.barButtonItemReportHZ,
            this.barButtonItemReportHZRegion,
            this.barButtonItemReportHZKind,
            this.barButtonItem4,
            this.barButtonItemHZInfoTable,
            this.barEditItem2,
            this.barEditItemEditLayer0,
            this.barButtonItemImportRedline,
            this.barButtonItemAddLine,
            this.barButtonItemProjectList,
            this.barEditItemEditLayer,
            this.barEditItem3,
            this.barButtonItem_XZ,
            this.barButtonItemCopyHarvest,
            this.barButtonItemReportZH,
            this.barButtonItemReportZZY1,
            this.barButtonItemReportZZY2,
            this.barButtonItemReportAJ,
            this.barButtonItemChartHZ,
            this.barButtonItemAutoComplete,
            this.barButtonItem_XZ2,
            this.barButtonItemReportZZY3,
            this.barButtonItemSingleCheck,
            this.barButtonItemTopModify,
            this.barButtonItemSaveEdit,
            this.barButtonItemCreateByPolygon,
            this.barButtonItemReportFCDC,
            this.barButtonItemCreateByPolygon2,
            this.barButtonItemPropertyByXB,
            this.barButtonItemSmoothPolygon,
            this.barButtonItemInputProperties,
            this.barButtonItemArea,
            this.barButtonItemXJ,
            this.barButtonItemLinZu,
            this.barButtonItemReportCF,
            this.barButtonItemInputGYL,
            this.barButtonItemInputEL});
            this.ribbon.MaxItemId = 257;
            this.ribbon.PageHeaderItemLinks.Add(this.barButtonItemSave);
            this.ribbon.PageHeaderItemLinks.Add(this.barButtonItemExportImage);
            this.ribbon.PageHeaderItemLinks.Add(this.barButtonItemPrint);
            this.ribbon.PageHeaderItemLinks.Add(this.barButtonItemPrintPreview);
            this.ribbon.PageHeaderItemLinks.Add(this.barButtonItemPrintSet);
            this.ribbon.PageHeaderItemLinks.Add(this.barButtonItemMapSet);
            this.ribbon.PageHeaderItemLinks.Add(this.barButtonItemImport, true);
            this.ribbon.PageHeaderItemLinks.Add(this.barButtonItemExportXM);
            this.ribbon.PageHeaderItemLinks.Add(this.barButtonItemExportZT, true);
            this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPageStatic});
            this.ribbon.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1,
            this.repositoryItemRadioGroup1,
            this.repositoryItemRadioGroup2,
            this.repositoryItemCheckEdit2,
            this.repositoryItemComboBox2,
            this.repositoryItemRadioGroup3,
            this.repositoryItemComboBox3,
            this.repositoryItemCheckEdit3,
            this.repositoryItemRadioGroup4,
            this.repositoryItemRadioGroup5,
            this.repositoryItemRadioGroup6,
            this.repositoryItemComboBox4,
            this.repositoryItemPictureEdit1,
            this.repositoryItemRadioGroup7,
            this.repositoryItemComboBox5,
            this.repositoryItemComboBox6,
            this.repositoryItemRadioGroup8,
            this.repositoryItemComboBox7,
            this.repositoryItemTextEdit1});
            this.ribbon.Toolbar.ItemLinks.Add(this.barButtonToolbox);
            this.ribbon.Toolbar.ItemLinks.Add(this.barButtonToolView);
            this.ribbon.Toolbar.ItemLinks.Add(this.barSubItemButtonStyle);
            this.ribbon.Toolbar.ItemLinks.Add(this.barButtonItemOpen2, true);
            this.ribbon.Toolbar.ItemLinks.Add(this.barButtonItemOpen);
            this.ribbon.Toolbar.ItemLinks.Add(this.barButtonItemAddLayer, true);
            this.ribbon.Toolbar.ItemLinks.Add(this.barButtonItemAddLayer2);
            this.ribbon.Toolbar.ItemLinks.Add(this.barButtonItemAddLayer3);
            this.ribbon.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.ribbon_ItemPress);
            this.ribbon.SelectedPageChanged += new System.EventHandler(this.ribbon_SelectedPageChanged);
            this.ribbon.Click += new System.EventHandler(this.ribbon_Click);
            // 
            // ribbonPageCheck
            // 
            this.ribbonPageCheck.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroupLogic,
            this.ribbonPageGroupToplogic2,
            this.ribbonPageGroupToplogic,
            this.ribbonPageGroupTopoModify,
            this.ribbonPageGroupMapView2});
            // 
            // ribbonPageDataEdit
            // 
            this.ribbonPageDataEdit.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroupProject,
            this.ribbonPageGroupEditLayer,
            this.ribbonPageGroupCaoTu,
            this.ribbonPageGroupXB,
            this.ribbonPageGroupInputTable,
            this.ribbonPageGroupImportBack,
            this.ribbonPageGroupAddnew,
            this.ribbonPageGroupEdit,
            this.ribbonPageGroupDelete,
            this.ribbonPageGroupEdittool,
            this.ribbonPageGroupCommEdit,
            this.ribbonPageGroupMapView});
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
            this.ribbonPageGroupMapView3});
            // 
            // tabPageMapContol
            // 
            this.tabPageMapContol.Size = new System.Drawing.Size(695, 513);
            // 
            // tabPagePagelayoutContol
            // 
            this.tabPagePagelayoutContol.Size = new System.Drawing.Size(981, 513);
            // 
            // xtraTabMain
            // 
            this.xtraTabMain.Location = new System.Drawing.Point(35, 20);
            this.xtraTabMain.SelectedTabPage = this.tabPageMapContol;
            this.xtraTabMain.Size = new System.Drawing.Size(701, 544);
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
            this.xtraTabPageQuery.Controls.Add(this.userControlQueryYG);
            this.xtraTabPageQuery.Controls.Add(this.userControlQueryXB);
            this.xtraTabPageQuery.Padding = new System.Windows.Forms.Padding(6, 1, 6, 1);
            // 
            // xtraTabPageTOC
            // 
            this.xtraTabPageTOC.Controls.Add(this.userControlLayerControl);
            this.xtraTabPageTOC.Controls.Add(this.splitterControl1);
            this.xtraTabPageTOC.Controls.Add(this.userControlOverView);
            this.xtraTabPageTOC.Size = new System.Drawing.Size(266, 531);
            this.xtraTabPageTOC.Controls.SetChildIndex(this.userControlOverView, 0);
            this.xtraTabPageTOC.Controls.SetChildIndex(this.splitterControl1, 0);
            this.xtraTabPageTOC.Controls.SetChildIndex(this.userControlLayerControl, 0);
            this.xtraTabPageTOC.Controls.SetChildIndex(this.axTOCControl, 0);
            // 
            // xtraTabToolbox
            // 
            this.xtraTabToolbox.SelectedTabPage = this.xtraTabPageTOC;
            this.xtraTabToolbox.Size = new System.Drawing.Size(272, 560);
            this.xtraTabToolbox.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPageSelect,
            this.xtraTabPageSelectByAttributes,
            this.xtraTabPageMapFind,
            this.xtraTabPageLocation,
            this.xtraTabPageXBchange,
            this.xtraTabPageAddRasterlayer,
            this.xtraTabPagePlace,
            this.xtraTabPageTFH,
            this.xtraTabPageKind,
            this.xtraTabPageDesign,
            this.xtraTabPageProject});
            this.xtraTabToolbox.Controls.SetChildIndex(this.xtraTabPageProject, 0);
            this.xtraTabToolbox.Controls.SetChildIndex(this.xtraTabPageDesign, 0);
            this.xtraTabToolbox.Controls.SetChildIndex(this.xtraTabPageKind, 0);
            this.xtraTabToolbox.Controls.SetChildIndex(this.xtraTabPageTFH, 0);
            this.xtraTabToolbox.Controls.SetChildIndex(this.xtraTabPagePlace, 0);
            this.xtraTabToolbox.Controls.SetChildIndex(this.xtraTabPageAddRasterlayer, 0);
            this.xtraTabToolbox.Controls.SetChildIndex(this.xtraTabPageXBchange, 0);
            this.xtraTabToolbox.Controls.SetChildIndex(this.xtraTabPageLocation, 0);
            this.xtraTabToolbox.Controls.SetChildIndex(this.xtraTabPageMapFind, 0);
            this.xtraTabToolbox.Controls.SetChildIndex(this.xtraTabPageSelect, 0);
            this.xtraTabToolbox.Controls.SetChildIndex(this.xtraTabPageSelectByAttributes, 0);
            this.xtraTabToolbox.Controls.SetChildIndex(this.xtraTabPageQuery, 0);
            this.xtraTabToolbox.Controls.SetChildIndex(this.xtraTabPageIdentify, 0);
            this.xtraTabToolbox.Controls.SetChildIndex(this.xtraTabPageTOC, 0);
            // 
            // splitterControl1
            // 
            this.splitterControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitterControl1.Location = new System.Drawing.Point(0, 306);
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
            this.barButtonItemZoomIn.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText;
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
            this.barButtonItemZoomOut.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText;
            // 
            // barButtonItemFullMap
            // 
            this.barButtonItemFullMap.Caption = "全图";
            this.barButtonItemFullMap.Description = "缩放到全图";
            this.barButtonItemFullMap.Id = 7;
            this.barButtonItemFullMap.ImageIndex = 25;
            this.barButtonItemFullMap.LargeImageIndex = 103;
            this.barButtonItemFullMap.Name = "barButtonItemFullMap";
            this.barButtonItemFullMap.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText;
            // 
            // barButtonItemPan2
            // 
            this.barButtonItemPan2.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            this.barButtonItemPan2.Caption = "漫游";
            this.barButtonItemPan2.Description = "地图漫游";
            this.barButtonItemPan2.Id = 8;
            this.barButtonItemPan2.ImageIndex = 56;
            this.barButtonItemPan2.LargeImageIndex = 74;
            this.barButtonItemPan2.Name = "barButtonItemPan2";
            this.barButtonItemPan2.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText;
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
            this.barButtonItemPan.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText;
            // 
            // barButtonItemIdentify
            // 
            this.barButtonItemIdentify.Caption = "查看";
            this.barButtonItemIdentify.Description = "属性信息查看";
            this.barButtonItemIdentify.Id = 9;
            this.barButtonItemIdentify.ImageIndex = 262;
            this.barButtonItemIdentify.LargeImageIndex = 402;
            this.barButtonItemIdentify.Name = "barButtonItemIdentify";
            this.barButtonItemIdentify.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
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
            this.barButtonItemRefresh.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText;
            // 
            // userControlOverView
            // 
            this.userControlOverView.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.userControlOverView.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.userControlOverView.Appearance.Options.UseBackColor = true;
            this.userControlOverView.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.userControlOverView.Location = new System.Drawing.Point(0, 311);
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
            this.barButtonItemSelectFeature.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText)));
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
            // barButtonItemSelectByAttributes
            // 
            this.barButtonItemSelectByAttributes.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            this.barButtonItemSelectByAttributes.Caption = "属性选择";
            this.barButtonItemSelectByAttributes.Description = "属性条件选择";
            this.barButtonItemSelectByAttributes.Id = 20;
            this.barButtonItemSelectByAttributes.ImageIndex = 342;
            this.barButtonItemSelectByAttributes.LargeImageIndex = 331;
            this.barButtonItemSelectByAttributes.Name = "barButtonItemSelectByAttributes";
            this.barButtonItemSelectByAttributes.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText;
            this.barButtonItemSelectByAttributes.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemSelectByAttributes_ItemClick);
            // 
            // barButtonItemSelectedFeaturesReport
            // 
            this.barButtonItemSelectedFeaturesReport.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            this.barButtonItemSelectedFeaturesReport.Caption = "选中属性";
            this.barButtonItemSelectedFeaturesReport.Description = "选中要素属性列表";
            this.barButtonItemSelectedFeaturesReport.Id = 21;
            this.barButtonItemSelectedFeaturesReport.ImageIndex = 305;
            this.barButtonItemSelectedFeaturesReport.LargeImageIndex = 409;
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
            this.barButtonItemOpen.Caption = "打开工作空间";
            this.barButtonItemOpen.Description = "打开已保存工作空间";
            this.barButtonItemOpen.Id = 34;
            this.barButtonItemOpen.ImageIndex = 35;
            this.barButtonItemOpen.LargeImageIndex = 22;
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
            // ribbonPageGroupAddnew
            // 
            this.ribbonPageGroupAddnew.AllowMinimize = false;
            this.ribbonPageGroupAddnew.ItemLinks.Add(this.barButtonItemInput);
            this.ribbonPageGroupAddnew.ItemLinks.Add(this.barButtonItemAddFeature);
            this.ribbonPageGroupAddnew.ItemLinks.Add(this.barButtonItemAddLine);
            this.ribbonPageGroupAddnew.ItemLinks.Add(this.barButtonItemAutoComplete);
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
            this.barButtonItemInput.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barButtonItemInput.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.barButtonItemInput.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemInput_ItemClick);
            // 
            // barButtonItemAddFeature
            // 
            this.barButtonItemAddFeature.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            this.barButtonItemAddFeature.Caption = "新增";
            this.barButtonItemAddFeature.Id = 36;
            this.barButtonItemAddFeature.ImageIndex = 311;
            this.barButtonItemAddFeature.LargeImageIndex = 38;
            this.barButtonItemAddFeature.Name = "barButtonItemAddFeature";
            this.barButtonItemAddFeature.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barButtonItemAddFeature.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // barButtonItemAddLine
            // 
            this.barButtonItemAddLine.Caption = "新增";
            this.barButtonItemAddLine.Description = "新增线";
            this.barButtonItemAddLine.Id = 204;
            this.barButtonItemAddLine.ImageIndex = 311;
            this.barButtonItemAddLine.LargeImageIndex = 38;
            this.barButtonItemAddLine.Name = "barButtonItemAddLine";
            this.barButtonItemAddLine.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barButtonItemAddLine.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText)));
            this.barButtonItemAddLine.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // barButtonItemAutoComplete
            // 
            this.barButtonItemAutoComplete.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            this.barButtonItemAutoComplete.Caption = "自动完成";
            this.barButtonItemAutoComplete.Description = "自动绘制多边形";
            this.barButtonItemAutoComplete.Id = 222;
            this.barButtonItemAutoComplete.ImageIndex = 248;
            this.barButtonItemAutoComplete.LargeImageIndex = 404;
            this.barButtonItemAutoComplete.Name = "barButtonItemAutoComplete";
            this.barButtonItemAutoComplete.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barButtonItemAutoComplete.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText)));
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
            this.barButtonItemXBUpdate.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemXBUpdate_ItemClick);
            // 
            // barButtonItemCreateByPolygon
            // 
            this.barButtonItemCreateByPolygon.Caption = "自动生成";
            this.barButtonItemCreateByPolygon.Description = "自动裁切二类小班生成选中多边形范围内班块";
            this.barButtonItemCreateByPolygon.Id = 241;
            this.barButtonItemCreateByPolygon.ImageIndex = 127;
            this.barButtonItemCreateByPolygon.LargeImageIndex = 405;
            this.barButtonItemCreateByPolygon.Name = "barButtonItemCreateByPolygon";
            this.barButtonItemCreateByPolygon.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText)));
            // 
            // ribbonPageGroupEdit
            // 
            this.ribbonPageGroupEdit.AllowMinimize = false;
            this.ribbonPageGroupEdit.ImageIndex = 68;
            this.ribbonPageGroupEdit.ItemLinks.Add(this.barButtonItemEditFeature);
            this.ribbonPageGroupEdit.ItemLinks.Add(this.barButtonItemLinkageEdit);
            this.ribbonPageGroupEdit.ItemLinks.Add(this.barButtonItemSplitFeature, true);
            this.ribbonPageGroupEdit.ItemLinks.Add(this.barButtonItemCombineFeature);
            this.ribbonPageGroupEdit.ItemLinks.Add(this.barButtonItemExplode);
            this.ribbonPageGroupEdit.ItemLinks.Add(this.barButtonItemInputProperty, true);
            this.ribbonPageGroupEdit.ItemLinks.Add(this.barButtonItemCopyHarvest);
            this.ribbonPageGroupEdit.ItemLinks.Add(this.barButtonItemInputPropertyList);
            this.ribbonPageGroupEdit.ItemLinks.Add(this.barButtonItemInputProperties);
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
            this.barButtonItemEditFeature.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
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
            this.barButtonItemLinkageEdit.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
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
            // barButtonItemExplode
            // 
            this.barButtonItemExplode.Caption = "打散";
            this.barButtonItemExplode.Description = "打散多部分多边形";
            this.barButtonItemExplode.Id = 192;
            this.barButtonItemExplode.ImageIndex = 338;
            this.barButtonItemExplode.LargeImageIndex = 217;
            this.barButtonItemExplode.Name = "barButtonItemExplode";
            this.barButtonItemExplode.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barButtonItemExplode.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // barButtonItemInputProperty
            // 
            this.barButtonItemInputProperty.Caption = "录入";
            this.barButtonItemInputProperty.Description = "班块属性录入";
            this.barButtonItemInputProperty.Id = 46;
            this.barButtonItemInputProperty.ImageIndex = 222;
            this.barButtonItemInputProperty.LargeImageIndex = 329;
            this.barButtonItemInputProperty.Name = "barButtonItemInputProperty";
            this.barButtonItemInputProperty.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // barButtonItemCopyHarvest
            // 
            this.barButtonItemCopyHarvest.Caption = "复制采伐";
            this.barButtonItemCopyHarvest.Description = "复制桉树采伐班块";
            this.barButtonItemCopyHarvest.Id = 212;
            this.barButtonItemCopyHarvest.ImageIndex = 35;
            this.barButtonItemCopyHarvest.LargeImageIndex = 127;
            this.barButtonItemCopyHarvest.Name = "barButtonItemCopyHarvest";
            this.barButtonItemCopyHarvest.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barButtonItemCopyHarvest.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.barButtonItemCopyHarvest.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // barButtonItemInputPropertyList
            // 
            this.barButtonItemInputPropertyList.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            this.barButtonItemInputPropertyList.Caption = "属性列表";
            this.barButtonItemInputPropertyList.Description = "属性录入列表";
            this.barButtonItemInputPropertyList.Id = 46;
            this.barButtonItemInputPropertyList.ImageIndex = 241;
            this.barButtonItemInputPropertyList.LargeImageIndex = 330;
            this.barButtonItemInputPropertyList.Name = "barButtonItemInputPropertyList";
            this.barButtonItemInputPropertyList.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // barButtonItemInputProperties
            // 
            this.barButtonItemInputProperties.Caption = "批量修改";
            this.barButtonItemInputProperties.Description = "批量修改要素指定属性字段值";
            this.barButtonItemInputProperties.Id = 245;
            this.barButtonItemInputProperties.ImageIndex = 39;
            this.barButtonItemInputProperties.LargeImageIndex = 332;
            this.barButtonItemInputProperties.Name = "barButtonItemInputProperties";
            this.barButtonItemInputProperties.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
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
            this.barButtonItemBoudarySnap.Caption = "追踪";
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
            this.ribbonPageGroupEdittool.ItemLinks.Add(this.barButtonItemEraseFeature, true);
            this.ribbonPageGroupEdittool.ItemLinks.Add(this.barButtonItemCutFeature);
            this.ribbonPageGroupEdittool.ItemLinks.Add(this.barButtonItemCreateByPolygon, true);
            this.ribbonPageGroupEdittool.ItemLinks.Add(this.barButtonItemCreateByPolygon2);
            this.ribbonPageGroupEdittool.ItemLinks.Add(this.barButtonItemPropertyByXB);
            this.ribbonPageGroupEdittool.ItemLinks.Add(this.barButtonItemSmoothPolygon);
            this.ribbonPageGroupEdittool.ItemLinks.Add(this.barButtonItemBoudarySnap, true);
            this.ribbonPageGroupEdittool.ItemLinks.Add(this.barButtonItemQuickSnap);
            this.ribbonPageGroupEdittool.Name = "ribbonPageGroupEdittool";
            this.ribbonPageGroupEdittool.Text = "编辑工具";
            // 
            // barButtonItemEraseFeature
            // 
            this.barButtonItemEraseFeature.Caption = "挖空";
            this.barButtonItemEraseFeature.Id = 50;
            this.barButtonItemEraseFeature.ImageIndex = 313;
            this.barButtonItemEraseFeature.LargeImageIndex = 390;
            this.barButtonItemEraseFeature.Name = "barButtonItemEraseFeature";
            this.barButtonItemEraseFeature.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText)));
            // 
            // barButtonItemCutFeature
            // 
            this.barButtonItemCutFeature.Caption = "裁切";
            this.barButtonItemCutFeature.Id = 51;
            this.barButtonItemCutFeature.ImageIndex = 338;
            this.barButtonItemCutFeature.LargeImageIndex = 333;
            this.barButtonItemCutFeature.Name = "barButtonItemCutFeature";
            this.barButtonItemCutFeature.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText)));
            // 
            // barButtonItemCreateByPolygon2
            // 
            this.barButtonItemCreateByPolygon2.Caption = "批量裁切";
            this.barButtonItemCreateByPolygon2.Description = "依据二类小班边界批量裁切指定行政范围内多边形生成班块";
            this.barButtonItemCreateByPolygon2.Id = 244;
            this.barButtonItemCreateByPolygon2.ImageIndex = 130;
            this.barButtonItemCreateByPolygon2.LargeImageIndex = 57;
            this.barButtonItemCreateByPolygon2.Name = "barButtonItemCreateByPolygon2";
            this.barButtonItemCreateByPolygon2.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText)));
            // 
            // barButtonItemPropertyByXB
            // 
            this.barButtonItemPropertyByXB.Caption = "获取属性";
            this.barButtonItemPropertyByXB.Description = "依据二类小班获取指定行政范围内班块相应属性信息";
            this.barButtonItemPropertyByXB.Id = 245;
            this.barButtonItemPropertyByXB.ImageIndex = 129;
            this.barButtonItemPropertyByXB.LargeImageIndex = 56;
            this.barButtonItemPropertyByXB.Name = "barButtonItemPropertyByXB";
            this.barButtonItemPropertyByXB.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText)));
            // 
            // barButtonItemSmoothPolygon
            // 
            this.barButtonItemSmoothPolygon.Caption = "平滑处理";
            this.barButtonItemSmoothPolygon.Description = "平滑处理锯齿状班块";
            this.barButtonItemSmoothPolygon.Id = 246;
            this.barButtonItemSmoothPolygon.ImageIndex = 128;
            this.barButtonItemSmoothPolygon.LargeImageIndex = 55;
            this.barButtonItemSmoothPolygon.Name = "barButtonItemSmoothPolygon";
            this.barButtonItemSmoothPolygon.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText)));
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
            this.ribbonPageGroupMapView.ItemLinks.Add(this.barButtonItemIdentify2);
            this.ribbonPageGroupMapView.ItemLinks.Add(this.barButtonItemTOC, true);
            this.ribbonPageGroupMapView.ItemLinks.Add(this.barButtonItemOverView);
            this.ribbonPageGroupMapView.ItemLinks.Add(this.barButtonItemTOC2);
            this.ribbonPageGroupMapView.ItemLinks.Add(this.barButtonItemAddDRG);
            this.ribbonPageGroupMapView.ItemLinks.Add(this.barButtonItemSelectLayerSet, true);
            this.ribbonPageGroupMapView.ItemLinks.Add(this.barButtonItemSelectByAttributes);
            this.ribbonPageGroupMapView.ItemLinks.Add(this.barButtonItemSelectedFeaturesReport);
            this.ribbonPageGroupMapView.Name = "ribbonPageGroupMapView";
            this.ribbonPageGroupMapView.Text = "地图浏览";
            // 
            // popupMenuMapView
            // 
            this.popupMenuMapView.ItemLinks.Add(this.barButtonItemFullMap, true);
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
            this.ribbonPageGroupCommEdit.ItemLinks.Add(this.barButtonItemSaveEdit, true);
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
            // barButtonItemSaveEdit
            // 
            this.barButtonItemSaveEdit.Caption = "保存";
            this.barButtonItemSaveEdit.Description = "保存编辑";
            this.barButtonItemSaveEdit.Id = 236;
            this.barButtonItemSaveEdit.ImageIndex = 78;
            this.barButtonItemSaveEdit.LargeImageIndex = 219;
            this.barButtonItemSaveEdit.Name = "barButtonItemSaveEdit";
            this.barButtonItemSaveEdit.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barButtonItemSaveEdit.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // ribbonPageGroupToplogic2
            // 
            this.ribbonPageGroupToplogic2.AllowMinimize = false;
            this.ribbonPageGroupToplogic2.ItemLinks.Add(this.barButtonItemNessRule);
            this.ribbonPageGroupToplogic2.ItemLinks.Add(this.barButtonItemCheckDist);
            this.ribbonPageGroupToplogic2.ItemLinks.Add(this.barButtonItemTotalLayer);
            this.ribbonPageGroupToplogic2.ItemLinks.Add(this.barButtonItemCheckXCPolygon);
            this.ribbonPageGroupToplogic2.ItemLinks.Add(this.barButtonItemCheckLayers);
            this.ribbonPageGroupToplogic2.ItemLinks.Add(this.barButtonItemSingleCheck);
            this.ribbonPageGroupToplogic2.ItemLinks.Add(this.barButtonItemTopModify);
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
            this.barButtonItemNessRule.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barButtonItemNessRule.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // barButtonItemCheckDist
            // 
            this.barButtonItemCheckDist.Caption = "范围检查";
            this.barButtonItemCheckDist.Description = "当前编辑范围内检查";
            this.barButtonItemCheckDist.Id = 137;
            this.barButtonItemCheckDist.ImageIndex = 284;
            this.barButtonItemCheckDist.LargeImageIndex = 396;
            this.barButtonItemCheckDist.Name = "barButtonItemCheckDist";
            this.barButtonItemCheckDist.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
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
            this.barButtonItemTotalLayer.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barButtonItemTotalLayer.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // barButtonItemCheckXCPolygon
            // 
            this.barButtonItemCheckXCPolygon.Caption = "形状检查";
            this.barButtonItemCheckXCPolygon.Description = "不规则班块检查";
            this.barButtonItemCheckXCPolygon.Id = 137;
            this.barButtonItemCheckXCPolygon.ImageIndex = 285;
            this.barButtonItemCheckXCPolygon.LargeImageIndex = 397;
            this.barButtonItemCheckXCPolygon.Name = "barButtonItemCheckXCPolygon";
            this.barButtonItemCheckXCPolygon.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barButtonItemCheckXCPolygon.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.barButtonItemCheckXCPolygon.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // barButtonItemCheckLayers
            // 
            this.barButtonItemCheckLayers.Caption = "层间检查";
            this.barButtonItemCheckLayers.Id = 60;
            this.barButtonItemCheckLayers.ImageIndex = 99;
            this.barButtonItemCheckLayers.LargeImageIndex = 392;
            this.barButtonItemCheckLayers.Name = "barButtonItemCheckLayers";
            this.barButtonItemCheckLayers.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barButtonItemCheckLayers.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.barButtonItemCheckLayers.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // barButtonItemSingleCheck
            // 
            this.barButtonItemSingleCheck.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            this.barButtonItemSingleCheck.Caption = "单一校验";
            this.barButtonItemSingleCheck.Id = 234;
            this.barButtonItemSingleCheck.LargeImageIndex = 199;
            this.barButtonItemSingleCheck.Name = "barButtonItemSingleCheck";
            this.barButtonItemSingleCheck.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barButtonItemSingleCheck.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // barButtonItemTopModify
            // 
            this.barButtonItemTopModify.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            this.barButtonItemTopModify.Caption = "拓扑修改";
            this.barButtonItemTopModify.Id = 235;
            this.barButtonItemTopModify.LargeImageIndex = 118;
            this.barButtonItemTopModify.Name = "barButtonItemTopModify";
            this.barButtonItemTopModify.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barButtonItemTopModify.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // barButtonItemCheckBoundary
            // 
            this.barButtonItemCheckBoundary.Caption = "边界检查";
            this.barButtonItemCheckBoundary.Id = 61;
            this.barButtonItemCheckBoundary.ImageIndex = 194;
            this.barButtonItemCheckBoundary.LargeImageIndex = 274;
            this.barButtonItemCheckBoundary.Name = "barButtonItemCheckBoundary";
            this.barButtonItemCheckBoundary.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // barButtonItemCheckRepeat
            // 
            this.barButtonItemCheckRepeat.Caption = "重复点";
            this.barButtonItemCheckRepeat.Id = 62;
            this.barButtonItemCheckRepeat.ImageIndex = 318;
            this.barButtonItemCheckRepeat.LargeImageIndex = 401;
            this.barButtonItemCheckRepeat.Name = "barButtonItemCheckRepeat";
            this.barButtonItemCheckRepeat.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // barButtonItemCheckGap
            // 
            this.barButtonItemCheckGap.Caption = "缝隙检查";
            this.barButtonItemCheckGap.Id = 63;
            this.barButtonItemCheckGap.ImageIndex = 325;
            this.barButtonItemCheckGap.LargeImageIndex = 185;
            this.barButtonItemCheckGap.Name = "barButtonItemCheckGap";
            this.barButtonItemCheckGap.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
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
            this.ribbonPageGroupToplogic.Visible = false;
            // 
            // barButtonItemCheckSelfIntersect
            // 
            this.barButtonItemCheckSelfIntersect.Caption = "自相交";
            this.barButtonItemCheckSelfIntersect.Id = 64;
            this.barButtonItemCheckSelfIntersect.ImageIndex = 149;
            this.barButtonItemCheckSelfIntersect.LargeImageIndex = 147;
            this.barButtonItemCheckSelfIntersect.Name = "barButtonItemCheckSelfIntersect";
            this.barButtonItemCheckSelfIntersect.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // barButtonItemCheckOverlap
            // 
            this.barButtonItemCheckOverlap.Caption = "重叠";
            this.barButtonItemCheckOverlap.Id = 67;
            this.barButtonItemCheckOverlap.ImageIndex = 33;
            this.barButtonItemCheckOverlap.LargeImageIndex = 307;
            this.barButtonItemCheckOverlap.Name = "barButtonItemCheckOverlap";
            this.barButtonItemCheckOverlap.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // barButtonItemCheckArea
            // 
            this.barButtonItemCheckArea.Caption = "最小面积";
            this.barButtonItemCheckArea.Id = 65;
            this.barButtonItemCheckArea.ImageIndex = 2;
            this.barButtonItemCheckArea.LargeImageIndex = 388;
            this.barButtonItemCheckArea.Name = "barButtonItemCheckArea";
            this.barButtonItemCheckArea.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // barButtonItemCheckAngle
            // 
            this.barButtonItemCheckAngle.Caption = "最小锐角";
            this.barButtonItemCheckAngle.Id = 66;
            this.barButtonItemCheckAngle.ImageIndex = 293;
            this.barButtonItemCheckAngle.LargeImageIndex = 391;
            this.barButtonItemCheckAngle.Name = "barButtonItemCheckAngle";
            this.barButtonItemCheckAngle.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // barButtonItemClearTopErr
            // 
            this.barButtonItemClearTopErr.Caption = "清除错误";
            this.barButtonItemClearTopErr.Description = "清除拓扑错误";
            this.barButtonItemClearTopErr.Id = 157;
            this.barButtonItemClearTopErr.ImageIndex = 95;
            this.barButtonItemClearTopErr.LargeImageIndex = 231;
            this.barButtonItemClearTopErr.Name = "barButtonItemClearTopErr";
            this.barButtonItemClearTopErr.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // barButtonItemOverlapCombine
            // 
            this.barButtonItemOverlapCombine.Caption = "合并重叠";
            this.barButtonItemOverlapCombine.Id = 68;
            this.barButtonItemOverlapCombine.ImageIndex = 327;
            this.barButtonItemOverlapCombine.LargeImageIndex = 308;
            this.barButtonItemOverlapCombine.Name = "barButtonItemOverlapCombine";
            this.barButtonItemOverlapCombine.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // barButtonItemOverlapConvert
            // 
            this.barButtonItemOverlapConvert.Caption = "新增重叠";
            this.barButtonItemOverlapConvert.Id = 69;
            this.barButtonItemOverlapConvert.ImageIndex = 326;
            this.barButtonItemOverlapConvert.LargeImageIndex = 306;
            this.barButtonItemOverlapConvert.Name = "barButtonItemOverlapConvert";
            this.barButtonItemOverlapConvert.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // barButtonItemOverlapDelete
            // 
            this.barButtonItemOverlapDelete.Caption = "删除重叠";
            this.barButtonItemOverlapDelete.Id = 70;
            this.barButtonItemOverlapDelete.ImageIndex = 328;
            this.barButtonItemOverlapDelete.LargeImageIndex = 309;
            this.barButtonItemOverlapDelete.Name = "barButtonItemOverlapDelete";
            this.barButtonItemOverlapDelete.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
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
            this.ribbonPageGroupTopoModify.Visible = false;
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
            this.xtraTabPageFireManage,
            this.xtraTabPageInputData,
            this.xtraTabPageConvertData,
            this.xtraTabPageUpdate,
            this.xtraTabPageAttriList});
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
            // xtraTabPageFireManage
            // 
            this.xtraTabPageFireManage.Controls.Add(this.userControlFireManage1);
            this.xtraTabPageFireManage.Name = "xtraTabPageFireManage";
            this.xtraTabPageFireManage.PageVisible = false;
            this.xtraTabPageFireManage.Size = new System.Drawing.Size(388, 561);
            this.xtraTabPageFireManage.Text = "火灾信息";
            // 
            // userControlFireManage1
            // 
            this.userControlFireManage1.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.userControlFireManage1.Appearance.BackColor2 = System.Drawing.Color.Transparent;
            this.userControlFireManage1.Appearance.Options.UseBackColor = true;
            this.userControlFireManage1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControlFireManage1.Location = new System.Drawing.Point(0, 0);
            this.userControlFireManage1.LookAndFeel.SkinName = "Blue";
            this.userControlFireManage1.Name = "userControlFireManage1";
            this.userControlFireManage1.Size = new System.Drawing.Size(388, 561);
            this.userControlFireManage1.TabIndex = 1;
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
            // xtraTabPageConvertData
            // 
            this.xtraTabPageConvertData.Controls.Add(this.userControlConvertData);
            this.xtraTabPageConvertData.Name = "xtraTabPageConvertData";
            this.xtraTabPageConvertData.PageVisible = false;
            this.xtraTabPageConvertData.Size = new System.Drawing.Size(388, 561);
            this.xtraTabPageConvertData.Text = "数据转换";
            // 
            // userControlConvertData
            // 
            this.userControlConvertData.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.userControlConvertData.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.userControlConvertData.Appearance.Options.UseBackColor = true;
            this.userControlConvertData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControlConvertData.Location = new System.Drawing.Point(0, 0);
            this.userControlConvertData.Margin = new System.Windows.Forms.Padding(5);
            this.userControlConvertData.Name = "userControlConvertData";
            this.userControlConvertData.Padding = new System.Windows.Forms.Padding(2);
            this.userControlConvertData.Size = new System.Drawing.Size(388, 561);
            this.userControlConvertData.TabIndex = 6;
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
            // xtraTabPageAttriList
            // 
            this.xtraTabPageAttriList.Controls.Add(this.userControlAttriList1);
            this.xtraTabPageAttriList.Name = "xtraTabPageAttriList";
            this.xtraTabPageAttriList.PageVisible = false;
            this.xtraTabPageAttriList.Size = new System.Drawing.Size(388, 561);
            this.xtraTabPageAttriList.Text = "属性列表";
            // 
            // userControlAttriList1
            // 
            this.userControlAttriList1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControlAttriList1.Location = new System.Drawing.Point(0, 0);
            this.userControlAttriList1.Name = "userControlAttriList1";
            this.userControlAttriList1.Padding = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.userControlAttriList1.Size = new System.Drawing.Size(388, 561);
            this.userControlAttriList1.TabIndex = 6;
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
            this.userControlLayerControl.Size = new System.Drawing.Size(266, 306);
            this.userControlLayerControl.TabIndex = 4;
            this.userControlLayerControl.Visible = false;
            // 
            // xtraTabPageSelect
            // 
            this.xtraTabPageSelect.Controls.Add(this.userControlSelectLayerSet1);
            this.xtraTabPageSelect.Name = "xtraTabPageSelect";
            this.xtraTabPageSelect.PageVisible = false;
            this.xtraTabPageSelect.Size = new System.Drawing.Size(248, 531);
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
            this.userControlSelectLayerSet1.Size = new System.Drawing.Size(248, 531);
            this.userControlSelectLayerSet1.TabIndex = 0;
            // 
            // xtraTabPageSelectByAttributes
            // 
            this.xtraTabPageSelectByAttributes.Controls.Add(this.userControlSelectByAttributes);
            this.xtraTabPageSelectByAttributes.Name = "xtraTabPageSelectByAttributes";
            this.xtraTabPageSelectByAttributes.PageVisible = false;
            this.xtraTabPageSelectByAttributes.Size = new System.Drawing.Size(248, 531);
            this.xtraTabPageSelectByAttributes.Text = "条件选择";
            // 
            // userControlSelectByAttributes
            // 
            this.userControlSelectByAttributes.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.userControlSelectByAttributes.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.userControlSelectByAttributes.Appearance.Options.UseBackColor = true;
            this.userControlSelectByAttributes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControlSelectByAttributes.Location = new System.Drawing.Point(0, 0);
            this.userControlSelectByAttributes.Name = "userControlSelectByAttributes";
            this.userControlSelectByAttributes.Padding = new System.Windows.Forms.Padding(5);
            this.userControlSelectByAttributes.Size = new System.Drawing.Size(248, 531);
            this.userControlSelectByAttributes.TabIndex = 0;
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
            this.ribbonPageGroupQuery2.ItemLinks.Add(this.barButtonItemDesignQuery);
            this.ribbonPageGroupQuery2.ItemLinks.Add(this.barButtonItemQueryYear);
            this.ribbonPageGroupQuery2.ItemLinks.Add(this.barButtonItemHZInfoTable);
            this.ribbonPageGroupQuery2.Name = "ribbonPageGroupQuery2";
            this.ribbonPageGroupQuery2.Text = "造林查询";
            // 
            // barButtonItemQueryXB
            // 
            this.barButtonItemQueryXB.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            this.barButtonItemQueryXB.Caption = "小班查询";
            this.barButtonItemQueryXB.Description = "二类本底小班查询";
            this.barButtonItemQueryXB.Id = 138;
            this.barButtonItemQueryXB.ImageIndex = 91;
            this.barButtonItemQueryXB.LargeImageIndex = 176;
            this.barButtonItemQueryXB.Name = "barButtonItemQueryXB";
            this.barButtonItemQueryXB.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.barButtonItemQueryXB.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemQueryXB_ItemClick);
            // 
            // barButtonItemDesignQuery
            // 
            this.barButtonItemDesignQuery.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            this.barButtonItemDesignQuery.Caption = "设计查询";
            this.barButtonItemDesignQuery.Description = "作业设计查询";
            this.barButtonItemDesignQuery.Id = 191;
            this.barButtonItemDesignQuery.ImageIndex = 118;
            this.barButtonItemDesignQuery.LargeImageIndex = 84;
            this.barButtonItemDesignQuery.Name = "barButtonItemDesignQuery";
            this.barButtonItemDesignQuery.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // barButtonItemHZInfoTable
            // 
            this.barButtonItemHZInfoTable.Caption = "火灾登记表";
            this.barButtonItemHZInfoTable.Id = 200;
            this.barButtonItemHZInfoTable.ImageIndex = 113;
            this.barButtonItemHZInfoTable.LargeImageIndex = 150;
            this.barButtonItemHZInfoTable.Name = "barButtonItemHZInfoTable";
            this.barButtonItemHZInfoTable.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // ribbonPageGroupMapView2
            // 
            this.ribbonPageGroupMapView2.ItemLinks.Add(this.barButtonItemTOC);
            this.ribbonPageGroupMapView2.ItemLinks.Add(this.barButtonItemAddDRG);
            this.ribbonPageGroupMapView2.ItemLinks.Add(this.barButtonItemIdentify2);
            this.ribbonPageGroupMapView2.Name = "ribbonPageGroupMapView2";
            this.ribbonPageGroupMapView2.Text = "地图浏览";
            // 
            // ribbonPageGroupMapView3
            // 
            this.ribbonPageGroupMapView3.ItemLinks.Add(this.barButtonItemTOC, true);
            this.ribbonPageGroupMapView3.ItemLinks.Add(this.barButtonItemOverView);
            this.ribbonPageGroupMapView3.ItemLinks.Add(this.barButtonItemTOC2);
            this.ribbonPageGroupMapView3.ItemLinks.Add(this.barButtonItemAddDRG);
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
            this.xtraTabPageMapFind.Size = new System.Drawing.Size(248, 531);
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
            this.userControlMapFind1.Size = new System.Drawing.Size(248, 531);
            this.userControlMapFind1.TabIndex = 2;
            // 
            // xtraTabPageLocation
            // 
            this.xtraTabPageLocation.Controls.Add(this.userControlLocation);
            this.xtraTabPageLocation.Name = "xtraTabPageLocation";
            this.xtraTabPageLocation.PageVisible = false;
            this.xtraTabPageLocation.Size = new System.Drawing.Size(248, 531);
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
            this.userControlLocation.Size = new System.Drawing.Size(248, 531);
            this.userControlLocation.TabIndex = 0;
            // 
            // ribbonPageGroupMxt
            // 
            this.ribbonPageGroupMxt.AllowMinimize = false;
            this.ribbonPageGroupMxt.ItemLinks.Add(this.barButtonItemSJ);
            this.ribbonPageGroupMxt.ItemLinks.Add(this.barButtonItemDC);
            this.ribbonPageGroupMxt.ItemLinks.Add(this.barButtonItemZTT);
            this.ribbonPageGroupMxt.ItemLinks.Add(this.barEditItem_fx);
            this.ribbonPageGroupMxt.ItemLinks.Add(this.bsiNormal);
            this.ribbonPageGroupMxt.Name = "ribbonPageGroupMxt";
            this.ribbonPageGroupMxt.Text = "制图模版";
            // 
            // barButtonItemSJ
            // 
            this.barButtonItemSJ.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            this.barButtonItemSJ.Caption = "设计图";
            this.barButtonItemSJ.Down = true;
            this.barButtonItemSJ.Id = 102;
            this.barButtonItemSJ.ImageIndex = 189;
            this.barButtonItemSJ.LargeImageIndex = 126;
            this.barButtonItemSJ.Name = "barButtonItemSJ";
            this.barButtonItemSJ.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.barButtonItemSJ.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemSJ_ItemClick);
            // 
            // barButtonItemDC
            // 
            this.barButtonItemDC.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            this.barButtonItemDC.Caption = "调查图";
            this.barButtonItemDC.Id = 103;
            this.barButtonItemDC.ImageIndex = 93;
            this.barButtonItemDC.LargeImageIndex = 43;
            this.barButtonItemDC.Name = "barButtonItemDC";
            this.barButtonItemDC.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.barButtonItemDC.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemDC_ItemClick);
            // 
            // barButtonItemZTT
            // 
            this.barButtonItemZTT.Caption = "专题图";
            this.barButtonItemZTT.Description = "专题图";
            this.barButtonItemZTT.Id = 193;
            this.barButtonItemZTT.ImageIndex = 190;
            this.barButtonItemZTT.LargeImageIndex = 381;
            this.barButtonItemZTT.Name = "barButtonItemZTT";
            this.barButtonItemZTT.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barButtonItemZTT.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.barButtonItemZTT.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // barEditItem_fx
            // 
            this.barEditItem_fx.Description = "方向";
            this.barEditItem_fx.Edit = this.repositoryItemComboBox5;
            this.barEditItem_fx.EditValue = "A4横向";
            this.barEditItem_fx.Id = 181;
            this.barEditItem_fx.Name = "barEditItem_fx";
            this.barEditItem_fx.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.barEditItem_fx.Width = 60;
            this.barEditItem_fx.EditValueChanged += new System.EventHandler(this.barEditItem_fx_EditValueChanged);
            // 
            // repositoryItemComboBox5
            // 
            this.repositoryItemComboBox5.AutoHeight = false;
            this.repositoryItemComboBox5.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemComboBox5.Items.AddRange(new object[] {
            "A4横向",
            "A4纵向",
            "A3横向",
            "A3纵向"});
            this.repositoryItemComboBox5.Name = "repositoryItemComboBox5";
            // 
            // bsiNormal
            // 
            this.bsiNormal.Caption = "自定义";
            this.bsiNormal.Id = 182;
            this.bsiNormal.ImageIndex = 297;
            this.bsiNormal.LargeImageIndex = 3;
            this.bsiNormal.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiSaveTemplate),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiLoadTempalte)});
            this.bsiNormal.Name = "bsiNormal";
            // 
            // bbiSaveTemplate
            // 
            this.bbiSaveTemplate.Caption = "保存模板";
            this.bbiSaveTemplate.Id = 183;
            this.bbiSaveTemplate.ImageIndex = 114;
            this.bbiSaveTemplate.Name = "bbiSaveTemplate";
            // 
            // bbiLoadTempalte
            // 
            this.bbiLoadTempalte.Caption = "加载模板";
            this.bbiLoadTempalte.Id = 184;
            this.bbiLoadTempalte.ImageIndex = 124;
            this.bbiLoadTempalte.Name = "bbiLoadTempalte";
            this.bbiLoadTempalte.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiLoadTempalte_ItemClick);
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
            this.ribbonPageGroupPageTool.ItemLinks.Add(this.barButtonItem_XZ);
            this.ribbonPageGroupPageTool.ItemLinks.Add(this.barButtonItem_XZ2);
            this.ribbonPageGroupPageTool.ItemLinks.Add(this.barButtonItem_TF);
            this.ribbonPageGroupPageTool.ItemLinks.Add(this.bsi_Coordinate);
            this.ribbonPageGroupPageTool.Name = "ribbonPageGroupPageTool";
            this.ribbonPageGroupPageTool.Text = "制图工具";
            // 
            // barButtonItemMapFrame
            // 
            this.barButtonItemMapFrame.Caption = "图框";
            this.barButtonItemMapFrame.Id = 91;
            this.barButtonItemMapFrame.ImageIndex = 48;
            this.barButtonItemMapFrame.LargeImageIndex = 171;
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
            this.barButtonItemMapScaleBar.ImageIndex = 329;
            this.barButtonItemMapScaleBar.LargeImageIndex = 168;
            this.barButtonItemMapScaleBar.Name = "barButtonItemMapScaleBar";
            this.barButtonItemMapScaleBar.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // barButtonItemScaleText
            // 
            this.barButtonItemScaleText.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            this.barButtonItemScaleText.Caption = "比例尺文本";
            this.barButtonItemScaleText.Id = 94;
            this.barButtonItemScaleText.ImageIndex = 229;
            this.barButtonItemScaleText.LargeImageIndex = 197;
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
            this.barButtonItemMapComment.LargeImageIndex = 403;
            this.barButtonItemMapComment.Name = "barButtonItemMapComment";
            this.barButtonItemMapComment.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // barButtonItem_XZ
            // 
            this.barButtonItem_XZ.Caption = "表格";
            this.barButtonItem_XZ.Id = 211;
            this.barButtonItem_XZ.ImageIndex = 224;
            this.barButtonItem_XZ.LargeImageIndex = 315;
            this.barButtonItem_XZ.Name = "barButtonItem_XZ";
            this.barButtonItem_XZ.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // barButtonItem_XZ2
            // 
            this.barButtonItem_XZ2.Caption = "自定义表格";
            this.barButtonItem_XZ2.Id = 223;
            this.barButtonItem_XZ2.ImageIndex = 224;
            this.barButtonItem_XZ2.LargeImageIndex = 251;
            this.barButtonItem_XZ2.Name = "barButtonItem_XZ2";
            this.barButtonItem_XZ2.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.barButtonItem_XZ2.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // barButtonItem_TF
            // 
            this.barButtonItem_TF.Caption = "图幅";
            this.barButtonItem_TF.Id = 159;
            this.barButtonItem_TF.ImageIndex = 261;
            this.barButtonItem_TF.LargeImageIndex = 215;
            this.barButtonItem_TF.Name = "barButtonItem_TF";
            this.barButtonItem_TF.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // bsi_Coordinate
            // 
            this.bsi_Coordinate.Caption = "坐标";
            this.bsi_Coordinate.Id = 187;
            this.bsi_Coordinate.ImageIndex = 26;
            this.bsi_Coordinate.LargeImageIndex = 134;
            this.bsi_Coordinate.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem_Coordinate),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem_Auto)});
            this.bsi_Coordinate.Name = "bsi_Coordinate";
            this.bsi_Coordinate.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // barButtonItem_Coordinate
            // 
            this.barButtonItem_Coordinate.Caption = "手工添加";
            this.barButtonItem_Coordinate.Id = 188;
            this.barButtonItem_Coordinate.ImageIndex = 62;
            this.barButtonItem_Coordinate.Name = "barButtonItem_Coordinate";
            // 
            // barButtonItem_Auto
            // 
            this.barButtonItem_Auto.Caption = "自动生成";
            this.barButtonItem_Auto.Id = 189;
            this.barButtonItem_Auto.ImageIndex = 57;
            this.barButtonItem_Auto.Name = "barButtonItem_Auto";
            // 
            // ribbonPageGroupPageView
            // 
            this.ribbonPageGroupPageView.AllowMinimize = false;
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
            this.barButtonItemPageZoomIn.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText;
            // 
            // barButtonItemPageZoomOut
            // 
            this.barButtonItemPageZoomOut.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            this.barButtonItemPageZoomOut.Caption = "缩小";
            this.barButtonItemPageZoomOut.Id = 83;
            this.barButtonItemPageZoomOut.ImageIndex = 291;
            this.barButtonItemPageZoomOut.LargeImageIndex = 99;
            this.barButtonItemPageZoomOut.Name = "barButtonItemPageZoomOut";
            this.barButtonItemPageZoomOut.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText;
            // 
            // barButtonItemPagePan
            // 
            this.barButtonItemPagePan.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            this.barButtonItemPagePan.Caption = "漫游";
            this.barButtonItemPagePan.Id = 84;
            this.barButtonItemPagePan.ImageIndex = 56;
            this.barButtonItemPagePan.LargeImageIndex = 101;
            this.barButtonItemPagePan.Name = "barButtonItemPagePan";
            this.barButtonItemPagePan.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText;
            // 
            // barButtonItemSelectElement
            // 
            this.barButtonItemSelectElement.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            this.barButtonItemSelectElement.Caption = "选择";
            this.barButtonItemSelectElement.Id = 88;
            this.barButtonItemSelectElement.ImageIndex = 246;
            this.barButtonItemSelectElement.LargeImageIndex = 284;
            this.barButtonItemSelectElement.Name = "barButtonItemSelectElement";
            this.barButtonItemSelectElement.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText;
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
            this.ribbonPageGroupMapView4.AllowMinimize = false;
            this.ribbonPageGroupMapView4.ItemLinks.Add(this.barButtonItemTOC, true);
            this.ribbonPageGroupMapView4.ItemLinks.Add(this.barButtonItemOverView);
            this.ribbonPageGroupMapView4.ItemLinks.Add(this.barButtonItemSelectLayerSet);
            this.ribbonPageGroupMapView4.ItemLinks.Add(this.barButtonItemSelectByAttributes);
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
            this.xtraTabPageXBchange.Controls.Add(this.userControlImportLC1);
            this.xtraTabPageXBchange.Controls.Add(this.userControlXBGrowth1);
            this.xtraTabPageXBchange.Controls.Add(this.userControlXBLayerCombine1);
            this.xtraTabPageXBchange.Controls.Add(this.userControlXBSet31);
            this.xtraTabPageXBchange.Controls.Add(this.userControlXBSet21);
            this.xtraTabPageXBchange.Controls.Add(this.userControlInputYG1);
            this.xtraTabPageXBchange.Controls.Add(this.userControlInputGYL1);
            this.xtraTabPageXBchange.Controls.Add(this.userControlUpdateAS21);
            this.xtraTabPageXBchange.Controls.Add(this.userControlXBSet1);
            this.xtraTabPageXBchange.Name = "xtraTabPageXBchange";
            this.xtraTabPageXBchange.Size = new System.Drawing.Size(248, 531);
            this.xtraTabPageXBchange.Text = "变更";
            this.xtraTabPageXBchange.Tooltip = "变更编辑设置";
            // 
            // userControlImportLC1
            // 
            this.userControlImportLC1.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.userControlImportLC1.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.userControlImportLC1.Appearance.Options.UseBackColor = true;
            this.userControlImportLC1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControlImportLC1.Location = new System.Drawing.Point(0, 0);
            this.userControlImportLC1.Name = "userControlImportLC1";
            this.userControlImportLC1.Size = new System.Drawing.Size(248, 531);
            this.userControlImportLC1.TabIndex = 6;
            this.userControlImportLC1.Visible = false;
            // 
            // userControlXBGrowth1
            // 
            this.userControlXBGrowth1.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.userControlXBGrowth1.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.userControlXBGrowth1.Appearance.Options.UseBackColor = true;
            this.userControlXBGrowth1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControlXBGrowth1.Location = new System.Drawing.Point(0, 0);
            this.userControlXBGrowth1.Name = "userControlXBGrowth1";
            this.userControlXBGrowth1.Padding = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.userControlXBGrowth1.Size = new System.Drawing.Size(248, 531);
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
            this.userControlXBLayerCombine1.Size = new System.Drawing.Size(248, 531);
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
            this.userControlXBSet31.Size = new System.Drawing.Size(248, 531);
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
            this.userControlXBSet21.Size = new System.Drawing.Size(248, 531);
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
            this.userControlInputYG1.Size = new System.Drawing.Size(248, 531);
            this.userControlInputYG1.TabIndex = 1;
            // 
            // userControlInputGYL1
            // 
            this.userControlInputGYL1.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.userControlInputGYL1.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.userControlInputGYL1.Appearance.Options.UseBackColor = true;
            this.userControlInputGYL1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControlInputGYL1.Location = new System.Drawing.Point(0, 0);
            this.userControlInputGYL1.Name = "userControlInputGYL1";
            this.userControlInputGYL1.Padding = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.userControlInputGYL1.Size = new System.Drawing.Size(248, 531);
            this.userControlInputGYL1.TabIndex = 1;
            // 
            // userControlUpdateAS21
            // 
            this.userControlUpdateAS21.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.userControlUpdateAS21.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.userControlUpdateAS21.Appearance.Options.UseBackColor = true;
            this.userControlUpdateAS21.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControlUpdateAS21.Location = new System.Drawing.Point(0, 0);
            this.userControlUpdateAS21.Name = "userControlUpdateAS21";
            this.userControlUpdateAS21.Padding = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.userControlUpdateAS21.Size = new System.Drawing.Size(248, 531);
            this.userControlUpdateAS21.TabIndex = 6;
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
            this.userControlXBSet1.Size = new System.Drawing.Size(248, 531);
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
            this.userControlQueryResult1.Size = new System.Drawing.Size(942, 162);
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
            // userControlQueryYG
            // 
            this.userControlQueryYG.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.userControlQueryYG.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.userControlQueryYG.Appearance.Options.UseBackColor = true;
            this.userControlQueryYG.AutoScroll = true;
            this.userControlQueryYG.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControlQueryYG.Location = new System.Drawing.Point(6, 1);
            this.userControlQueryYG.Name = "userControlQueryYG";
            this.userControlQueryYG.Padding = new System.Windows.Forms.Padding(4);
            this.userControlQueryYG.Size = new System.Drawing.Size(233, 529);
            this.userControlQueryYG.TabIndex = 0;
            // 
            // ribbonPageGroupCaoTu
            // 
            this.ribbonPageGroupCaoTu.AllowMinimize = false;
            this.ribbonPageGroupCaoTu.ImageIndex = 61;
            this.ribbonPageGroupCaoTu.ItemLinks.Add(this.barButtonItemInputZT);
            this.ribbonPageGroupCaoTu.ItemLinks.Add(this.barButtonItemInputYG);
            this.ribbonPageGroupCaoTu.ItemLinks.Add(this.barButtonItemInputDC);
            this.ribbonPageGroupCaoTu.ItemLinks.Add(this.barButtonItemInputGYL);
            this.ribbonPageGroupCaoTu.ItemLinks.Add(this.barButtonItemInputOther);
            this.ribbonPageGroupCaoTu.Name = "ribbonPageGroupCaoTu";
            this.ribbonPageGroupCaoTu.Text = "变化小班编辑";
            this.ribbonPageGroupCaoTu.Visible = false;
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
            this.barButtonItemInputZT.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemInputZT_ItemClick);
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
            this.barButtonItemInputYG.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemInputYG_ItemClick);
            // 
            // barButtonItemInputDC
            // 
            this.barButtonItemInputDC.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            this.barButtonItemInputDC.Caption = "外调核实";
            this.barButtonItemInputDC.Description = "导入外业调查核实数据";
            this.barButtonItemInputDC.Id = 141;
            this.barButtonItemInputDC.ImageIndex = 107;
            this.barButtonItemInputDC.LargeImageIndex = 414;
            this.barButtonItemInputDC.Name = "barButtonItemInputDC";
            this.barButtonItemInputDC.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.barButtonItemInputDC.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemInputDC_ItemClick);
            // 
            // barButtonItemInputGYL
            // 
            this.barButtonItemInputGYL.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            this.barButtonItemInputGYL.Caption = "公益林修正";
            this.barButtonItemInputGYL.Id = 254;
            this.barButtonItemInputGYL.ImageIndex = 190;
            this.barButtonItemInputGYL.LargeImageIndex = 228;
            this.barButtonItemInputGYL.Name = "barButtonItemInputGYL";
            this.barButtonItemInputGYL.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // barButtonItemInputOther
            // 
            this.barButtonItemInputOther.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            this.barButtonItemInputOther.Caption = "其它更新";
            this.barButtonItemInputOther.Description = "其他变化更新";
            this.barButtonItemInputOther.Id = 142;
            this.barButtonItemInputOther.ImageIndex = 268;
            this.barButtonItemInputOther.LargeImageIndex = 235;
            this.barButtonItemInputOther.Name = "barButtonItemInputOther";
            this.barButtonItemInputOther.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.barButtonItemInputOther.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemInputOther_ItemClick);
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
            this.barButtonItemLayerCombine.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemLayerCombine_ItemClick);
            // 
            // ribbonPageGroupXB
            // 
            this.ribbonPageGroupXB.AllowMinimize = false;
            this.ribbonPageGroupXB.ItemLinks.Add(this.barButtonItemLayerCombine);
            this.ribbonPageGroupXB.ItemLinks.Add(this.barButtonItemArea);
            this.ribbonPageGroupXB.ItemLinks.Add(this.barButtonItemGrowthModel);
            this.ribbonPageGroupXB.ItemLinks.Add(this.barButtonItemSSA);
            this.ribbonPageGroupXB.ItemLinks.Add(this.barButtonItemXJ);
            this.ribbonPageGroupXB.ItemLinks.Add(this.barButtonItemLinZu);
            this.ribbonPageGroupXB.ItemLinks.Add(this.barButtonItemInputEL);
            this.ribbonPageGroupXB.ItemLinks.Add(this.barButtonItemXBEdit);
            this.ribbonPageGroupXB.Name = "ribbonPageGroupXB";
            this.ribbonPageGroupXB.Text = "年度小班编辑";
            this.ribbonPageGroupXB.Visible = false;
            // 
            // barButtonItemArea
            // 
            this.barButtonItemArea.Caption = "面积平差";
            this.barButtonItemArea.Description = "年度小班面积平差";
            this.barButtonItemArea.Id = 247;
            this.barButtonItemArea.LargeImageIndex = 413;
            this.barButtonItemArea.Name = "barButtonItemArea";
            // 
            // barButtonItemGrowthModel
            // 
            this.barButtonItemGrowthModel.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            this.barButtonItemGrowthModel.Caption = "自然更新";
            this.barButtonItemGrowthModel.Description = "根据自然生长模型更新年度小班蓄积";
            this.barButtonItemGrowthModel.Id = 158;
            this.barButtonItemGrowthModel.LargeImageIndex = 271;
            this.barButtonItemGrowthModel.Name = "barButtonItemGrowthModel";
            this.barButtonItemGrowthModel.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barButtonItemGrowthModel.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // barButtonItemSSA
            // 
            this.barButtonItemSSA.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            this.barButtonItemSSA.Caption = "速生桉";
            this.barButtonItemSSA.Description = "速生桉异常数据处理";
            this.barButtonItemSSA.Id = 158;
            this.barButtonItemSSA.LargeImageIndex = 339;
            this.barButtonItemSSA.Name = "barButtonItemSSA";
            this.barButtonItemSSA.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barButtonItemSSA.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.barButtonItemSSA.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // barButtonItemXJ
            // 
            this.barButtonItemXJ.Caption = "蓄积计算";
            this.barButtonItemXJ.Description = "年度小班蓄积计算";
            this.barButtonItemXJ.Id = 249;
            this.barButtonItemXJ.LargeImageIndex = 70;
            this.barButtonItemXJ.Name = "barButtonItemXJ";
            this.barButtonItemXJ.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barButtonItemXJ.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // barButtonItemLinZu
            // 
            this.barButtonItemLinZu.Caption = "龄组划分";
            this.barButtonItemLinZu.Description = "重新划分龄组、龄级、经济林产期";
            this.barButtonItemLinZu.Id = 250;
            this.barButtonItemLinZu.LargeImageIndex = 5;
            this.barButtonItemLinZu.Name = "barButtonItemLinZu";
            this.barButtonItemLinZu.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barButtonItemLinZu.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // barButtonItemInputEL
            // 
            this.barButtonItemInputEL.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            this.barButtonItemInputEL.Caption = "二类导入";
            this.barButtonItemInputEL.Id = 255;
            this.barButtonItemInputEL.LargeImageIndex = 281;
            this.barButtonItemInputEL.Name = "barButtonItemInputEL";
            this.barButtonItemInputEL.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barButtonItemInputEL.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // barButtonItemXBEdit
            // 
            this.barButtonItemXBEdit.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            this.barButtonItemXBEdit.Caption = "小班编辑";
            this.barButtonItemXBEdit.Id = 144;
            this.barButtonItemXBEdit.ImageIndex = 96;
            this.barButtonItemXBEdit.LargeImageIndex = 221;
            this.barButtonItemXBEdit.Name = "barButtonItemXBEdit";
            this.barButtonItemXBEdit.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barButtonItemXBEdit.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.barButtonItemXBEdit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemXBEdit_ItemClick);
            // 
            // xtraTabQuery
            // 
            this.xtraTabQuery.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabQuery.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Left;
            this.xtraTabQuery.HeaderOrientation = DevExpress.XtraTab.TabOrientation.Horizontal;
            this.xtraTabQuery.Location = new System.Drawing.Point(0, 0);
            this.xtraTabQuery.Name = "xtraTabQuery";
            this.xtraTabQuery.SelectedTabPage = this.xtraTabPage1;
            this.xtraTabQuery.Size = new System.Drawing.Size(986, 168);
            this.xtraTabQuery.TabIndex = 1;
            this.xtraTabQuery.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1,
            this.xtraTabPage2,
            this.xtraTabPage3,
            this.xtraTabPage4});
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Controls.Add(this.userControlQueryResult1);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(942, 162);
            this.xtraTabPage1.Text = "查询";
            // 
            // xtraTabPage2
            // 
            this.xtraTabPage2.Controls.Add(this.userControlQueryResult2);
            this.xtraTabPage2.Name = "xtraTabPage2";
            this.xtraTabPage2.PageVisible = false;
            this.xtraTabPage2.Size = new System.Drawing.Size(942, 162);
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
            this.userControlQueryResult2.Size = new System.Drawing.Size(942, 162);
            this.userControlQueryResult2.TabIndex = 1;
            // 
            // xtraTabPage3
            // 
            this.xtraTabPage3.Controls.Add(this.userControlSelectFeatureResport21);
            this.xtraTabPage3.Name = "xtraTabPage3";
            this.xtraTabPage3.Size = new System.Drawing.Size(942, 162);
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
            this.userControlSelectFeatureResport21.Size = new System.Drawing.Size(942, 162);
            this.userControlSelectFeatureResport21.TabIndex = 0;
            // 
            // xtraTabPage4
            // 
            this.xtraTabPage4.Controls.Add(this.userControlTaskInfo1);
            this.xtraTabPage4.Name = "xtraTabPage4";
            this.xtraTabPage4.PageVisible = false;
            this.xtraTabPage4.Size = new System.Drawing.Size(942, 162);
            toolTipItem2.Text = "采伐作业设计查询";
            superToolTip2.Items.Add(toolTipItem2);
            this.xtraTabPage4.SuperTip = superToolTip2;
            this.xtraTabPage4.Text = "设计";
            // 
            // userControlTaskInfo1
            // 
            this.userControlTaskInfo1.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.userControlTaskInfo1.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.userControlTaskInfo1.Appearance.Options.UseBackColor = true;
            this.userControlTaskInfo1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControlTaskInfo1.Location = new System.Drawing.Point(0, 0);
            this.userControlTaskInfo1.Name = "userControlTaskInfo1";
            this.userControlTaskInfo1.Padding = new System.Windows.Forms.Padding(5, 5, 5, 0);
            this.userControlTaskInfo1.Size = new System.Drawing.Size(942, 162);
            this.userControlTaskInfo1.TabIndex = 0;
            // 
            // barButtonItemAddLayer3
            // 
            this.barButtonItemAddLayer3.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            this.barButtonItemAddLayer3.Caption = "添加栅格数据";
            this.barButtonItemAddLayer3.Id = 146;
            this.barButtonItemAddLayer3.ImageIndex = 50;
            this.barButtonItemAddLayer3.Name = "barButtonItemAddLayer3";
            this.barButtonItemAddLayer3.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemAddLayer3_ItemClick);
            // 
            // xtraTabPageAddRasterlayer
            // 
            this.xtraTabPageAddRasterlayer.Controls.Add(this.userControlImageGeoReference1);
            this.xtraTabPageAddRasterlayer.Name = "xtraTabPageAddRasterlayer";
            this.xtraTabPageAddRasterlayer.PageVisible = false;
            this.xtraTabPageAddRasterlayer.Size = new System.Drawing.Size(248, 531);
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
            this.userControlImageGeoReference1.Size = new System.Drawing.Size(248, 531);
            this.userControlImageGeoReference1.TabIndex = 0;
            // 
            // ribbonPageStatic
            // 
            this.ribbonPageStatic.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroupCF,
            this.ribbonPageGroupZL,
            this.ribbonPageGroupHZ,
            this.ribbonPageGroupZZY,
            this.ribbonPageGroupZH,
            this.ribbonPageGroupAJ,
            this.ribbonPageGroupReportXB});
            this.ribbonPageStatic.ImageIndex = 205;
            this.ribbonPageStatic.Name = "ribbonPageStatic";
            this.ribbonPageStatic.Text = "统计";
            this.ribbonPageStatic.Visible = false;
            // 
            // ribbonPageGroupCF
            // 
            this.ribbonPageGroupCF.AllowMinimize = false;
            this.ribbonPageGroupCF.ItemLinks.Add(this.barButtonItemReportCF1);
            this.ribbonPageGroupCF.ItemLinks.Add(this.barButtonItemChartCF);
            this.ribbonPageGroupCF.ItemLinks.Add(this.barButtonItemReportFCDC);
            this.ribbonPageGroupCF.ItemLinks.Add(this.barButtonItemReportCF);
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
            this.barButtonItemReportCF1.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // barButtonItemChartCF
            // 
            this.barButtonItemChartCF.Caption = "采伐统计图表";
            this.barButtonItemChartCF.Id = 155;
            this.barButtonItemChartCF.LargeImageIndex = 7;
            this.barButtonItemChartCF.Name = "barButtonItemChartCF";
            this.barButtonItemChartCF.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemChartCF_ItemClick);
            // 
            // barButtonItemReportFCDC
            // 
            this.barButtonItemReportFCDC.Caption = "伐区调查登记表";
            this.barButtonItemReportFCDC.Description = "伐区调查及每木检尺登记表";
            this.barButtonItemReportFCDC.Id = 242;
            this.barButtonItemReportFCDC.ImageIndex = 205;
            this.barButtonItemReportFCDC.LargeImageIndex = 344;
            this.barButtonItemReportFCDC.Name = "barButtonItemReportFCDC";
            this.barButtonItemReportFCDC.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // barButtonItemReportCF
            // 
            this.barButtonItemReportCF.Caption = "伐区设计统计表";
            this.barButtonItemReportCF.Id = 251;
            this.barButtonItemReportCF.LargeImageIndex = 371;
            this.barButtonItemReportCF.Name = "barButtonItemReportCF";
            this.barButtonItemReportCF.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barButtonItemReportCF.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.barButtonItemReportCF.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // ribbonPageGroupZL
            // 
            this.ribbonPageGroupZL.AllowMinimize = false;
            this.ribbonPageGroupZL.ItemLinks.Add(this.barButtonItemReportZL);
            this.ribbonPageGroupZL.ItemLinks.Add(this.barButtonItemChartZL);
            this.ribbonPageGroupZL.Name = "ribbonPageGroupZL";
            this.ribbonPageGroupZL.Text = "造林专题报表";
            this.ribbonPageGroupZL.Visible = false;
            // 
            // barButtonItemReportZL
            // 
            this.barButtonItemReportZL.Caption = "造林统计表";
            this.barButtonItemReportZL.Id = 154;
            this.barButtonItemReportZL.LargeImageIndex = 281;
            this.barButtonItemReportZL.Name = "barButtonItemReportZL";
            this.barButtonItemReportZL.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barButtonItemReportZL.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // barButtonItemChartZL
            // 
            this.barButtonItemChartZL.Caption = "造林统计图表";
            this.barButtonItemChartZL.Id = 156;
            this.barButtonItemChartZL.LargeImageIndex = 7;
            this.barButtonItemChartZL.Name = "barButtonItemChartZL";
            this.barButtonItemChartZL.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemChartZL_ItemClick);
            // 
            // ribbonPageGroupHZ
            // 
            this.ribbonPageGroupHZ.AllowMinimize = false;
            this.ribbonPageGroupHZ.ItemLinks.Add(this.barButtonItemReportHZ);
            this.ribbonPageGroupHZ.ItemLinks.Add(this.barButtonItemReportHZRegion);
            this.ribbonPageGroupHZ.ItemLinks.Add(this.barButtonItemReportHZKind);
            this.ribbonPageGroupHZ.ItemLinks.Add(this.barButtonItemChartHZ);
            this.ribbonPageGroupHZ.Name = "ribbonPageGroupHZ";
            this.ribbonPageGroupHZ.Text = "火灾专题报表";
            this.ribbonPageGroupHZ.Visible = false;
            // 
            // barButtonItemReportHZ
            // 
            this.barButtonItemReportHZ.Caption = "火灾统计表";
            this.barButtonItemReportHZ.Description = "森林火灾统计表";
            this.barButtonItemReportHZ.Id = 196;
            this.barButtonItemReportHZ.LargeImageIndex = 4;
            this.barButtonItemReportHZ.Name = "barButtonItemReportHZ";
            this.barButtonItemReportHZ.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barButtonItemReportHZ.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // barButtonItemReportHZRegion
            // 
            this.barButtonItemReportHZRegion.Caption = "地区统计表";
            this.barButtonItemReportHZRegion.Description = "森林火灾分地区统计表";
            this.barButtonItemReportHZRegion.Id = 197;
            this.barButtonItemReportHZRegion.LargeImageIndex = 213;
            this.barButtonItemReportHZRegion.Name = "barButtonItemReportHZRegion";
            this.barButtonItemReportHZRegion.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barButtonItemReportHZRegion.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.barButtonItemReportHZRegion.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // barButtonItemReportHZKind
            // 
            this.barButtonItemReportHZKind.Caption = "类型统计表";
            this.barButtonItemReportHZKind.Description = "森林火灾分类型统计表";
            this.barButtonItemReportHZKind.Id = 198;
            this.barButtonItemReportHZKind.LargeImageIndex = 211;
            this.barButtonItemReportHZKind.Name = "barButtonItemReportHZKind";
            this.barButtonItemReportHZKind.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barButtonItemReportHZKind.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.barButtonItemReportHZKind.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // barButtonItemChartHZ
            // 
            this.barButtonItemChartHZ.Caption = "统计图表";
            this.barButtonItemChartHZ.Description = "森林火灾统计图表";
            this.barButtonItemChartHZ.Id = 218;
            this.barButtonItemChartHZ.LargeImageIndex = 58;
            this.barButtonItemChartHZ.Name = "barButtonItemChartHZ";
            this.barButtonItemChartHZ.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barButtonItemChartHZ.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // ribbonPageGroupZZY
            // 
            this.ribbonPageGroupZZY.AllowMinimize = false;
            this.ribbonPageGroupZZY.ItemLinks.Add(this.barButtonItemReportZZY1);
            this.ribbonPageGroupZZY.ItemLinks.Add(this.barButtonItemReportZZY2);
            this.ribbonPageGroupZZY.ItemLinks.Add(this.barButtonItemReportZZY3);
            this.ribbonPageGroupZZY.Name = "ribbonPageGroupZZY";
            this.ribbonPageGroupZZY.Text = "征占用专题报表";
            this.ribbonPageGroupZZY.Visible = false;
            // 
            // barButtonItemReportZZY1
            // 
            this.barButtonItemReportZZY1.Caption = "外调成果统计表";
            this.barButtonItemReportZZY1.Description = "征占用调查成果统计表";
            this.barButtonItemReportZZY1.Id = 215;
            this.barButtonItemReportZZY1.LargeImageIndex = 213;
            this.barButtonItemReportZZY1.Name = "barButtonItemReportZZY1";
            this.barButtonItemReportZZY1.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barButtonItemReportZZY1.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // barButtonItemReportZZY2
            // 
            this.barButtonItemReportZZY2.Caption = "国家级统计表";
            this.barButtonItemReportZZY2.Description = "林地征占用国家统计表";
            this.barButtonItemReportZZY2.Id = 216;
            this.barButtonItemReportZZY2.LargeImageIndex = 9;
            this.barButtonItemReportZZY2.Name = "barButtonItemReportZZY2";
            this.barButtonItemReportZZY2.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barButtonItemReportZZY2.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // barButtonItemReportZZY3
            // 
            this.barButtonItemReportZZY3.Caption = " 月统计表 ";
            this.barButtonItemReportZZY3.Id = 228;
            this.barButtonItemReportZZY3.LargeImageIndex = 129;
            this.barButtonItemReportZZY3.Name = "barButtonItemReportZZY3";
            // 
            // ribbonPageGroupZH
            // 
            this.ribbonPageGroupZH.AllowMinimize = false;
            this.ribbonPageGroupZH.ItemLinks.Add(this.barButtonItemReportZH);
            this.ribbonPageGroupZH.Name = "ribbonPageGroupZH";
            this.ribbonPageGroupZH.Text = "灾害专题报表";
            this.ribbonPageGroupZH.Visible = false;
            // 
            // barButtonItemReportZH
            // 
            this.barButtonItemReportZH.Caption = "自然灾害统计表";
            this.barButtonItemReportZH.Id = 214;
            this.barButtonItemReportZH.LargeImageIndex = 161;
            this.barButtonItemReportZH.Name = "barButtonItemReportZH";
            this.barButtonItemReportZH.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barButtonItemReportZH.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // ribbonPageGroupAJ
            // 
            this.ribbonPageGroupAJ.AllowMinimize = false;
            this.ribbonPageGroupAJ.ItemLinks.Add(this.barButtonItemReportAJ);
            this.ribbonPageGroupAJ.Name = "ribbonPageGroupAJ";
            this.ribbonPageGroupAJ.Text = "案件专题报表";
            this.ribbonPageGroupAJ.Visible = false;
            // 
            // barButtonItemReportAJ
            // 
            this.barButtonItemReportAJ.Caption = "林业案件统计报表";
            this.barButtonItemReportAJ.Id = 217;
            this.barButtonItemReportAJ.LargeImageIndex = 160;
            this.barButtonItemReportAJ.Name = "barButtonItemReportAJ";
            this.barButtonItemReportAJ.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barButtonItemReportAJ.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // ribbonPageGroupReportXB
            // 
            this.ribbonPageGroupReportXB.AllowMinimize = false;
            this.ribbonPageGroupReportXB.ItemLinks.Add(this.barButtonItemStatic);
            this.ribbonPageGroupReportXB.Name = "ribbonPageGroupReportXB";
            this.ribbonPageGroupReportXB.Text = "二类调查统计";
            this.ribbonPageGroupReportXB.Visible = false;
            // 
            // barButtonItemStatic
            // 
            this.barButtonItemStatic.Caption = "小班统计报表";
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
            this.xtraTabPagePlace.Size = new System.Drawing.Size(248, 531);
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
            this.userControlPlace1.Size = new System.Drawing.Size(248, 531);
            this.userControlPlace1.TabIndex = 0;
            // 
            // xtraTabPageTFH
            // 
            this.xtraTabPageTFH.Controls.Add(this.userControlQueryTFH1);
            this.xtraTabPageTFH.Name = "xtraTabPageTFH";
            this.xtraTabPageTFH.PageVisible = false;
            this.xtraTabPageTFH.Size = new System.Drawing.Size(248, 531);
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
            this.userControlQueryTFH1.Size = new System.Drawing.Size(248, 531);
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
            this.xtraTabPageKind.Controls.Add(this.userControlQueryZZY21);
            this.xtraTabPageKind.Controls.Add(this.userControlQueryHZ21);
            this.xtraTabPageKind.Controls.Add(this.userControlQueryXB21);
            this.xtraTabPageKind.Controls.Add(this.userControlQueryCF21);
            this.xtraTabPageKind.Name = "xtraTabPageKind";
            this.xtraTabPageKind.PageVisible = false;
            this.xtraTabPageKind.Size = new System.Drawing.Size(248, 531);
            this.xtraTabPageKind.Text = "类型";
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
            this.userControlQueryZZY21.Size = new System.Drawing.Size(248, 531);
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
            this.userControlQueryHZ21.Size = new System.Drawing.Size(248, 531);
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
            this.userControlQueryXB21.Size = new System.Drawing.Size(248, 531);
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
            this.userControlQueryCF21.Size = new System.Drawing.Size(248, 531);
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
            // repositoryItemRadioGroup1
            // 
            this.repositoryItemRadioGroup1.Name = "repositoryItemRadioGroup1";
            // 
            // repositoryItemRadioGroup2
            // 
            this.repositoryItemRadioGroup2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.repositoryItemRadioGroup2.Columns = 1;
            this.repositoryItemRadioGroup2.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "横向"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "纵向")});
            this.repositoryItemRadioGroup2.Name = "repositoryItemRadioGroup2";
            // 
            // repositoryItemCheckEdit2
            // 
            this.repositoryItemCheckEdit2.AutoHeight = false;
            this.repositoryItemCheckEdit2.Caption = "Check";
            this.repositoryItemCheckEdit2.Name = "repositoryItemCheckEdit2";
            // 
            // repositoryItemComboBox2
            // 
            this.repositoryItemComboBox2.AutoHeight = false;
            this.repositoryItemComboBox2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemComboBox2.Name = "repositoryItemComboBox2";
            // 
            // repositoryItemRadioGroup3
            // 
            this.repositoryItemRadioGroup3.Appearance.ForeColor = System.Drawing.Color.Black;
            this.repositoryItemRadioGroup3.Appearance.Options.UseForeColor = true;
            this.repositoryItemRadioGroup3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.repositoryItemRadioGroup3.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "横向"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "纵向")});
            this.repositoryItemRadioGroup3.Name = "repositoryItemRadioGroup3";
            // 
            // repositoryItemComboBox3
            // 
            this.repositoryItemComboBox3.AutoHeight = false;
            this.repositoryItemComboBox3.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemComboBox3.Name = "repositoryItemComboBox3";
            // 
            // repositoryItemCheckEdit3
            // 
            this.repositoryItemCheckEdit3.AutoHeight = false;
            this.repositoryItemCheckEdit3.Caption = "Check";
            this.repositoryItemCheckEdit3.Name = "repositoryItemCheckEdit3";
            // 
            // barButtonItemFireTable
            // 
            this.barButtonItemFireTable.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            this.barButtonItemFireTable.Caption = "火灾登记表";
            this.barButtonItemFireTable.Description = "森林火灾登记表录入";
            this.barButtonItemFireTable.Id = 172;
            this.barButtonItemFireTable.ImageIndex = 287;
            this.barButtonItemFireTable.LargeImageIndex = 161;
            this.barButtonItemFireTable.Name = "barButtonItemFireTable";
            this.barButtonItemFireTable.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.barButtonItemFireTable.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // repositoryItemRadioGroup4
            // 
            this.repositoryItemRadioGroup4.Name = "repositoryItemRadioGroup4";
            // 
            // repositoryItemRadioGroup5
            // 
            this.repositoryItemRadioGroup5.Name = "repositoryItemRadioGroup5";
            // 
            // repositoryItemRadioGroup6
            // 
            this.repositoryItemRadioGroup6.Name = "repositoryItemRadioGroup6";
            // 
            // repositoryItemComboBox4
            // 
            this.repositoryItemComboBox4.AutoHeight = false;
            this.repositoryItemComboBox4.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemComboBox4.Name = "repositoryItemComboBox4";
            // 
            // repositoryItemPictureEdit1
            // 
            this.repositoryItemPictureEdit1.Name = "repositoryItemPictureEdit1";
            // 
            // repositoryItemRadioGroup7
            // 
            this.repositoryItemRadioGroup7.Appearance.BackColor2 = System.Drawing.Color.White;
            this.repositoryItemRadioGroup7.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.repositoryItemRadioGroup7.Columns = 1;
            this.repositoryItemRadioGroup7.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "横向"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "纵向")});
            this.repositoryItemRadioGroup7.Name = "repositoryItemRadioGroup7";
            // 
            // barButtonItemImport
            // 
            this.barButtonItemImport.Caption = "数据导入";
            this.barButtonItemImport.Description = "采伐作业设计数据导入";
            this.barButtonItemImport.Id = 190;
            this.barButtonItemImport.ImageIndex = 119;
            this.barButtonItemImport.LargeImageIndex = 356;
            this.barButtonItemImport.Name = "barButtonItemImport";
            // 
            // xtraTabPageDesign
            // 
            this.xtraTabPageDesign.Controls.Add(this.userControlQueryDesign1);
            this.xtraTabPageDesign.Name = "xtraTabPageDesign";
            this.xtraTabPageDesign.PageVisible = false;
            this.xtraTabPageDesign.Size = new System.Drawing.Size(248, 531);
            toolTipItem3.Text = "作业设计查询";
            superToolTip3.Items.Add(toolTipItem3);
            this.xtraTabPageDesign.SuperTip = superToolTip3;
            this.xtraTabPageDesign.Text = "设计";
            // 
            // userControlQueryDesign1
            // 
            this.userControlQueryDesign1.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.userControlQueryDesign1.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.userControlQueryDesign1.Appearance.Options.UseBackColor = true;
            this.userControlQueryDesign1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControlQueryDesign1.Location = new System.Drawing.Point(0, 0);
            this.userControlQueryDesign1.Name = "userControlQueryDesign1";
            this.userControlQueryDesign1.Padding = new System.Windows.Forms.Padding(5);
            this.userControlQueryDesign1.Size = new System.Drawing.Size(248, 531);
            this.userControlQueryDesign1.TabIndex = 0;
            // 
            // ribbonPageGroupInputTable
            // 
            this.ribbonPageGroupInputTable.AllowMinimize = false;
            this.ribbonPageGroupInputTable.ItemLinks.Add(this.barButtonItemFireTable);
            this.ribbonPageGroupInputTable.Name = "ribbonPageGroupInputTable";
            this.ribbonPageGroupInputTable.Text = "表单录入";
            this.ribbonPageGroupInputTable.Visible = false;
            // 
            // barButtonItem4
            // 
            this.barButtonItem4.Caption = "barButtonItem4";
            this.barButtonItem4.Id = 199;
            this.barButtonItem4.Name = "barButtonItem4";
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
            // ribbonPageGroupEditLayer
            // 
            this.ribbonPageGroupEditLayer.AllowMinimize = false;
            this.ribbonPageGroupEditLayer.ItemLinks.Add(this.barEditItem3);
            this.ribbonPageGroupEditLayer.ItemLinks.Add(this.barEditItemEditLayer);
            this.ribbonPageGroupEditLayer.Name = "ribbonPageGroupEditLayer";
            this.ribbonPageGroupEditLayer.Text = "编辑图层";
            this.ribbonPageGroupEditLayer.Visible = false;
            // 
            // barEditItem3
            // 
            this.barEditItem3.Caption = "设置编辑图层";
            this.barEditItem3.Edit = this.repositoryItemTextEdit1;
            this.barEditItem3.Id = 207;
            this.barEditItem3.Name = "barEditItem3";
            this.barEditItem3.Width = 0;
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.AutoHeight = false;
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            // 
            // barEditItemEditLayer
            // 
            this.barEditItemEditLayer.Edit = this.repositoryItemComboBox7;
            this.barEditItemEditLayer.EditValue = "编辑面";
            this.barEditItemEditLayer.Id = 206;
            this.barEditItemEditLayer.Name = "barEditItemEditLayer";
            this.barEditItemEditLayer.Width = 70;
            // 
            // repositoryItemComboBox7
            // 
            this.repositoryItemComboBox7.AutoHeight = false;
            this.repositoryItemComboBox7.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemComboBox7.Items.AddRange(new object[] {
            "编辑点",
            "编辑线",
            "编辑面"});
            this.repositoryItemComboBox7.Name = "repositoryItemComboBox7";
            this.repositoryItemComboBox7.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            // 
            // barEditItemEditLayer0
            // 
            this.barEditItemEditLayer0.Edit = this.repositoryItemRadioGroup8;
            this.barEditItemEditLayer0.EditHeight = 60;
            this.barEditItemEditLayer0.Id = 202;
            this.barEditItemEditLayer0.ItemAppearance.Normal.BackColor = System.Drawing.Color.Transparent;
            this.barEditItemEditLayer0.ItemAppearance.Normal.Options.UseBackColor = true;
            this.barEditItemEditLayer0.ItemAppearance.Normal.Options.UseBorderColor = true;
            this.barEditItemEditLayer0.LargeImageIndex = 392;
            this.barEditItemEditLayer0.Name = "barEditItemEditLayer0";
            this.barEditItemEditLayer0.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barEditItemEditLayer0.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.barEditItemEditLayer0.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.barEditItemEditLayer0.Width = 80;
            this.barEditItemEditLayer0.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barEditItemEditLayer_ItemClick);
            // 
            // repositoryItemRadioGroup8
            // 
            this.repositoryItemRadioGroup8.Columns = 1;
            this.repositoryItemRadioGroup8.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(false, "编辑点"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(false, "编辑线"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(false, "编辑面")});
            this.repositoryItemRadioGroup8.Name = "repositoryItemRadioGroup8";
            // 
            // barEditItem2
            // 
            this.barEditItem2.Caption = "barEditItem2";
            this.barEditItem2.Edit = this.repositoryItemComboBox6;
            this.barEditItem2.Id = 201;
            this.barEditItem2.Name = "barEditItem2";
            // 
            // repositoryItemComboBox6
            // 
            this.repositoryItemComboBox6.AutoHeight = false;
            this.repositoryItemComboBox6.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemComboBox6.Name = "repositoryItemComboBox6";
            // 
            // ribbonPageGroupImportBack
            // 
            this.ribbonPageGroupImportBack.AllowMinimize = false;
            this.ribbonPageGroupImportBack.ItemLinks.Add(this.barButtonItemImportRedline);
            this.ribbonPageGroupImportBack.Name = "ribbonPageGroupImportBack";
            this.ribbonPageGroupImportBack.Text = "导入底图";
            this.ribbonPageGroupImportBack.Visible = false;
            // 
            // barButtonItemImportRedline
            // 
            this.barButtonItemImportRedline.Caption = "红线图";
            this.barButtonItemImportRedline.Description = "导入红线图";
            this.barButtonItemImportRedline.Id = 203;
            this.barButtonItemImportRedline.LargeImageIndex = 399;
            this.barButtonItemImportRedline.Name = "barButtonItemImportRedline";
            this.barButtonItemImportRedline.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barButtonItemImportRedline.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.barButtonItemImportRedline.SmallWithTextWidth = 100;
            // 
            // ribbonPageGroupProject
            // 
            this.ribbonPageGroupProject.ItemLinks.Add(this.barButtonItemProjectList);
            this.ribbonPageGroupProject.Name = "ribbonPageGroupProject";
            this.ribbonPageGroupProject.Text = "征占用项目";
            this.ribbonPageGroupProject.Visible = false;
            // 
            // barButtonItemProjectList
            // 
            this.barButtonItemProjectList.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            this.barButtonItemProjectList.Caption = "项目列表";
            this.barButtonItemProjectList.Description = "征占用项目列表";
            this.barButtonItemProjectList.Id = 205;
            this.barButtonItemProjectList.ImageIndex = 268;
            this.barButtonItemProjectList.LargeImageIndex = 23;
            this.barButtonItemProjectList.Name = "barButtonItemProjectList";
            this.barButtonItemProjectList.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barButtonItemProjectList.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // xtraTabPageProject
            // 
            this.xtraTabPageProject.Controls.Add(this.userControlProjectList1);
            this.xtraTabPageProject.Controls.Add(this.userControlDesignList1);
            this.xtraTabPageProject.Name = "xtraTabPageProject";
            this.xtraTabPageProject.PageVisible = false;
            this.xtraTabPageProject.Size = new System.Drawing.Size(248, 531);
            this.xtraTabPageProject.Text = "项目";
            // 
            // userControlProjectList1
            // 
            this.userControlProjectList1.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.userControlProjectList1.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.userControlProjectList1.Appearance.Options.UseBackColor = true;
            this.userControlProjectList1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControlProjectList1.Location = new System.Drawing.Point(0, 0);
            this.userControlProjectList1.Name = "userControlProjectList1";
            this.userControlProjectList1.Padding = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.userControlProjectList1.Size = new System.Drawing.Size(248, 531);
            this.userControlProjectList1.TabIndex = 0;
            // 
            // userControlDesignList1
            // 
            this.userControlDesignList1.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.userControlDesignList1.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.userControlDesignList1.Appearance.Options.UseBackColor = true;
            this.userControlDesignList1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControlDesignList1.Location = new System.Drawing.Point(0, 0);
            this.userControlDesignList1.Name = "userControlDesignList1";
            this.userControlDesignList1.Padding = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.userControlDesignList1.Size = new System.Drawing.Size(248, 531);
            this.userControlDesignList1.TabIndex = 0;
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
            this.barButtonItemMapSet.Id = 224;
            this.barButtonItemMapSet.ImageIndex = 340;
            this.barButtonItemMapSet.LargeImageIndex = 170;
            this.barButtonItemMapSet.Name = "barButtonItemMapSet";
            // 
            // barButtonItemOutCFTable
            // 
            this.barButtonItemOutCFTable.Caption = "打印伐区调查表";
            this.barButtonItemOutCFTable.Description = "打印简易伐区调查设计表模版";
            this.barButtonItemOutCFTable.Id = 226;
            this.barButtonItemOutCFTable.ImageIndex = 282;
            this.barButtonItemOutCFTable.LargeImageIndex = 319;
            this.barButtonItemOutCFTable.Name = "barButtonItemOutCFTable";
            this.barButtonItemOutCFTable.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // barButtonItemExportSub
            // 
            this.barButtonItemExportSub.Caption = "成果上报";
            this.barButtonItemExportSub.Id = 233;
            this.barButtonItemExportSub.ImageIndex = 123;
            this.barButtonItemExportSub.LargeImageIndex = 359;
            this.barButtonItemExportSub.Name = "barButtonItemExportSub";
            this.barButtonItemExportSub.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // barButtonItemExportZT
            // 
            this.barButtonItemExportZT.Caption = "数据导出";
            this.barButtonItemExportZT.Description = "专题数据导出";
            this.barButtonItemExportZT.Id = 243;
            this.barButtonItemExportZT.ImageIndex = 123;
            this.barButtonItemExportZT.LargeImageIndex = 359;
            this.barButtonItemExportZT.Name = "barButtonItemExportZT";
            // 
            // barButtonItemExportXM
            // 
            this.barButtonItemExportXM.Caption = "项目导出";
            this.barButtonItemExportXM.Description = "项目数据导出";
            this.barButtonItemExportXM.Id = 243;
            this.barButtonItemExportXM.ImageIndex = 123;
            this.barButtonItemExportXM.LargeImageIndex = 359;
            this.barButtonItemExportXM.Name = "barButtonItemExportXM";
            this.barButtonItemExportXM.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // barButtonItemOpen2
            // 
            this.barButtonItemOpen2.Caption = "打开默认工作空间";
            this.barButtonItemOpen2.Description = "打开默认工作空间";
            this.barButtonItemOpen2.Id = 246;
            this.barButtonItemOpen2.ImageIndex = 37;
            this.barButtonItemOpen2.LargeImageIndex = 18;
            this.barButtonItemOpen2.Name = "barButtonItemOpen2";
            // 
            // barButtonItemSetSpatialreference
            // 
            this.barButtonItemSetSpatialreference.Caption = "设置空间参考";
            this.barButtonItemSetSpatialreference.Description = "设置当前地图空间参考";
            this.barButtonItemSetSpatialreference.Id = 252;
            this.barButtonItemSetSpatialreference.ImageIndex = 332;
            this.barButtonItemSetSpatialreference.LargeImageIndex = 95;
            this.barButtonItemSetSpatialreference.Name = "barButtonItemSetSpatialreference";
            this.barButtonItemSetSpatialreference.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barButtonItemSetSpatialreference.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText)));
            // 
            // barButtonItemExit
            // 
            this.barButtonItemExit.Caption = "退出";
            this.barButtonItemExit.Description = "退出系统";
            this.barButtonItemExit.Id = 253;
            this.barButtonItemExit.LargeImageIndex = 16;
            this.barButtonItemExit.Name = "barButtonItemExit";
            this.barButtonItemExit.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barButtonItemExit.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText)));
            base.bar1.Text = "浏览工具";
            base.bar1.Reset();
            base.bar1.OptionsBar.MultiLine = true;
            base.bar1.LinksPersistInfo.AddRange(new LinkPersistInfo[] { new LinkPersistInfo(this.barButtonItemFullMap, true), new LinkPersistInfo(this.barButtonItemPan), new LinkPersistInfo(this.barButtonItemZoomIn), new LinkPersistInfo(this.barButtonItemZoomOut), new LinkPersistInfo(this.barButtonItemRefresh), new LinkPersistInfo(this.barButtonItemBack), new LinkPersistInfo(this.barButtonItemForward), new LinkPersistInfo(this.barButtonItemIdentify, true), new LinkPersistInfo(this.barButtonItemSelectFeature, true), new LinkPersistInfo(this.barButtonItemClearSelectFeature) });
            base.AutoScaleDimensions = new SizeF(7f, 14f);

            // 
            // MainFrameEdit
            // 
            this.ClientSize = new System.Drawing.Size(1016, 767);
            this.MinimumSize = new System.Drawing.Size(1002, 723);
            this.Name = "MainFrameEdit";
            this.Text = "";
            this.Activated += new System.EventHandler(this.FormMainFrame_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainFrameEdit_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormMainFrame_FormClosed);
            this.Load += new System.EventHandler(this.FormMainFrame_Load);
            this.Resize += new System.EventHandler(this.MainFrameEdit_Resize);
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
            this.panelFull.ResumeLayout(false);
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
            this.xtraTabPageFireManage.ResumeLayout(false);
            this.xtraTabPageInputData.ResumeLayout(false);
            this.xtraTabPageConvertData.ResumeLayout(false);
            this.xtraTabPageUpdate.ResumeLayout(false);
            this.xtraTabPageAttriList.ResumeLayout(false);
            this.xtraTabPageSelect.ResumeLayout(false);
            this.xtraTabPageSelectByAttributes.ResumeLayout(false);
            this.xtraTabPageMapFind.ResumeLayout(false);
            this.xtraTabPageLocation.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox5)).EndInit();
            this.xtraTabPageXBchange.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabQuery)).EndInit();
            this.xtraTabQuery.ResumeLayout(false);
            this.xtraTabPage1.ResumeLayout(false);
            this.xtraTabPage2.ResumeLayout(false);
            this.xtraTabPage3.ResumeLayout(false);
            this.xtraTabPage4.ResumeLayout(false);
            this.xtraTabPageAddRasterlayer.ResumeLayout(false);
            this.xtraTabPagePlace.ResumeLayout(false);
            this.xtraTabPageTFH.ResumeLayout(false);
            this.xtraTabPageKind.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemRadioGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemRadioGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemRadioGroup3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemRadioGroup4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemRadioGroup5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemRadioGroup6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemRadioGroup7)).EndInit();
            this.xtraTabPageDesign.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemRadioGroup8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox6)).EndInit();
            this.xtraTabPageProject.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private bool InitializeEditValue(bool flag)
        {
            bool flag2 = false;
            try
            {
                TaskManageClass.InitialEditValues(this.mEditKind, "2016", base.MapControlEdit.Map);
                this.mFeatureWorkspace = EditTask.EditWorkspace;
                if (this.mFeatureWorkspace == null)
                {
                    return false;
                }
                TaskManageClass.TaskState = TaskState.Open;
                TaskManageClass.LogicCheckState = LogicCheckState.Failure;
                TaskManageClass.ToplogicCheckState = ToplogicCheckState.Failure;
                this.mEditLayer = EditTask.EditLayer;
                if (this.bDefaultPath)
                {
                    DB2LayerModelManager dmm = new DB2LayerModelManager();
                    Tuple<bool, IList<ILayer>> tu = dmm.SetFeatureLayerResource(MapControlEdit.Map, this.mFeatureWorkspace, HasLayerResource, EditTask.TaskYear);
                    mLayerList = tu.Item2;
                }
                EditTask.LayerList = this.mLayerList;
                flag2 = true;
                if (this.bDefaultPath)
                {
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
                if (((this.mEditKind == "征占用") && (EditTask.UnderLayer != null)) && this.bDefaultPath)
                {
                    this.SetLayerRenderer(EditTask.UnderLayer.Name, EditTask.TaskYear, EditTask.UnderLayer);
                }
                if ((base.MapControlEdit.Map.Description != "") && !this.bDefaultPath)
                {
                    string[] strArray = base.MapControlEdit.Map.Description.Split(new char[] { ',' });
                    if (strArray.Length == 2)
                    {
                        if (strArray[1].Contains("TASK_ID="))
                        {
                            EditTask.TaskID = long.Parse(strArray[1].Replace("TASK_ID=", ""));
                        }
                        else
                        {
                            EditTask.TaskID = long.Parse(strArray[1]);
                        }
                        DataTable table = null;// TaskManageClass.GetDataTable(pDBAccess, "T_EditTask_ZT", "*", "", "ID='" + EditTask.TaskID + "'", false);
                        if (table.Rows.Count > 0)
                        {
                            DataRow row = table.Rows[0];
                            TaskManageClass.TaskState = TaskState.Open;
                            TaskManageClass.LogicCheckState = LogicCheckState.Failure;
                            TaskManageClass.ToplogicCheckState = ToplogicCheckState.Failure;
                            EditTask.KindCode = row["taskkind"].ToString();
                            EditTask.TaskName = row["taskname"].ToString();
                            EditTask.DistCode = row["distcode"].ToString();
                            EditTask.TaskState = (TaskState2)int.Parse(row["taskstate"].ToString());
                            EditTask.TaskYear = row["taskyear"].ToString();
                            EditTask.CreateTime = row["createtime"].ToString();
                            EditTask.EditTime = row["edittime"].ToString();
                            EditTask.DatasetName = row["datasetname"].ToString();
                            EditTask.LayerName = row["layername"].ToString();
                            EditTask.TableName = row["tablename"].ToString();
                            EditTask.TaskID = long.Parse(row["ID"].ToString());
                            EditTask.PZWH = row["taskpath"].ToString();
                            if (row["logiccheckstate"].ToString() == "1")
                            {
                                EditTask.LogicChkState = LogicCheckState.Success;
                            }
                            else if (row["logiccheckstate"].ToString() == "0")
                            {
                                EditTask.LogicChkState = LogicCheckState.Failure;
                            }
                            if (row["logiccheckstate"].ToString() == "1")
                            {
                                EditTask.ToplogicChkState = ToplogicCheckState.Success;
                            }
                            else if (row["logiccheckstate"].ToString() == "0")
                            {
                                EditTask.ToplogicChkState = ToplogicCheckState.Failure;
                            }
                            IWorkspaceEdit editWorkspace = EditTask.EditWorkspace as IWorkspaceEdit;
                            Editor.UniqueInstance.StartEdit(Editor.UniqueInstance.Workspace, Editor.UniqueInstance.Map);
                            this.barButtonItemInput.Enabled = true;
                            this.barButtonItemInputProperty.Enabled = true;
                            this.barButtonItemImportRedline.Enabled = true;
                            this.barEditItemEditLayer.Enabled = true;
                            this.barButtonItemCreateByPolygon.Enabled = true;
                            this.barButtonItemCreateByPolygon2.Enabled = true;
                            this.barButtonItemSmoothPolygon.Enabled = true;
                            this.barButtonItemPropertyByXB.Enabled = true;
                            this.barButtonItemInputPropertyList.Enabled = true;
                            this.barButtonItemSaveEdit.Enabled = true;
                            this.barButtonItemCheckDist.Visibility = BarItemVisibility.Always;
                            TaskManageClass.TaskState = TaskState.Open;
                            base.barStaticItemInfo.Caption = EditTask.TaskName;
                        }
                    }
                }
                if ((this.mEditKind == "征占用") && this.bDefaultPath)
                {
                    string str3 = "";
                    IFeatureLayerDefinition mEditLayer = null;
                    if (this.mEditLayer != null)
                    {
                        str3 = "XMBH = '" + EditTask.TaskID + "'";
                        mEditLayer = (IFeatureLayerDefinition)this.mEditLayer;
                        mEditLayer.DefinitionExpression = str3;
                    }
                    this.mEditLayer2 = EditTask.UnderLayers[0] as IFeatureLayer;
                    if (this.mEditLayer2 != null)
                    {
                        str3 = "XMBH = '" + EditTask.TaskID + "'";
                        mEditLayer = (IFeatureLayerDefinition)this.mEditLayer2;
                        mEditLayer.DefinitionExpression = str3;
                    }
                    this.mEditLayer3 = EditTask.UnderLayers[1] as IFeatureLayer;
                    if (this.mEditLayer3 != null)
                    {
                        str3 = "XMBH = '" + EditTask.TaskID + "'";
                        mEditLayer = (IFeatureLayerDefinition)this.mEditLayer3;
                        mEditLayer.DefinitionExpression = str3;
                    }
                    IFeatureLayer layer = EditTask.UnderLayers[3] as IFeatureLayer;
                    if (layer != null)
                    {
                        str3 = "XMBH <> '" + EditTask.TaskID + "'";
                        mEditLayer = (IFeatureLayerDefinition)layer;
                        mEditLayer.DefinitionExpression = str3;
                    }
                    layer = EditTask.UnderLayers[4] as IFeatureLayer;
                    if (layer != null)
                    {
                        str3 = "XMBH <> '" + EditTask.TaskID + "'";
                        mEditLayer = (IFeatureLayerDefinition)layer;
                        mEditLayer.DefinitionExpression = str3;
                    }
                    layer = EditTask.UnderLayers[5] as IFeatureLayer;
                    if (layer != null)
                    {
                        str3 = "XMBH <> '" + EditTask.TaskID + "'";
                        mEditLayer = (IFeatureLayerDefinition)layer;
                        mEditLayer.DefinitionExpression = str3;
                    }
                }
                return flag2;
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "GXFormMainFrame.FormMainEdit", "InitializeEditValue", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                return flag2;
            }
        }

        public bool InitializeForm()
        {
            Exception exception;
            try
            {
                ItemClickEventArgs args;
                IWorkspaceEdit editWorkspace;
                Application.DoEvents();
                if (this.FormSplash != null)
                {
                    this.FormSplash.SetLoadInfo("正在加载地图数据...", 0x19);
                }
                if (this.FormSplash6 != null)
                {
                    this.FormSplash6.SetLoadInfo("正在加载地图数据...", 0x19);
                }
                base.MapControlEdit.BringToFront();
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

                Application.DoEvents();
                this.mRibbonItemStyles = RibbonItemStyles.SmallWithText | RibbonItemStyles.Large;
                this.ribbonPageGroupMapView.AllowMinimize = false;
                this.ribbonPageGroupMapView2.AllowMinimize = false;
                this.ribbonPageGroupMapView3.AllowMinimize = false;
                this.ribbonPageGroupMapView4.AllowMinimize = false;
                this.InitializeBaseButtonComm();

                if (this.FormSplash != null)
                {
                    this.FormSplash.SetLoadInfo("正在初始化工具按钮...", 40);
                }
                if (this.FormSplash6 != null)
                {
                    this.FormSplash6.SetLoadInfo("正在初始化工具按钮...", 40);
                }
                this.InitializeBaseButtonEdit();
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
                base.ribbon.SelectedPage = base.ribbonPageDataEdit;
                if (this.FormSplash != null)
                {
                    this.FormSplash.SetLoadInfo("正在初始化功能模块...", 70);
                }
                if (this.FormSplash6 != null)
                {
                    this.FormSplash6.SetLoadInfo("正在初始化功能模块...", 70);
                }
                if (this.mEditKind == "小班变更")
                {
                    this.userControlXBSet21.simpleButtonOK.Click += new EventHandler(this.userControlXBSet21simpleButtonOK_Click);
                    this.userControlXBSet21.simpleButtonCancel.Click += new EventHandler(this.userControlXBSet21simpleButtonCancel_Click);
                    this.userControlXBSet21.simpleButtonFinish.Click += new EventHandler(this.userControlXBSet21simpleButtonFinish_Click);
                    if (this.barButtonItemAddFeature.Down)
                    {
                        args = new ItemClickEventArgs(this.barButtonItemAddFeature, this.barButtonItemAddFeature.Links[0]);
                        base.MapControlEdit.CurrentTool = null;
                        this.RefreshToolBarButton(false);
                        base.dockPanelEdit.Visibility = DockVisibility.Hidden;
                    }
                    editWorkspace = EditTask.EditWorkspace as IWorkspaceEdit;
                    if (((TaskManageClass.TaskState.ToString() == TaskState.Open.ToString()) && editWorkspace.IsBeingEdited()) && Editor.UniqueInstance.IsBeingEdited)
                    {
                        Editor.UniqueInstance.StopEdit();
                    }
                    this.barButtonItemInput.Enabled = false;
                    this.barButtonItemInputProperty.Enabled = false;
                    this.barButtonItemXBUpdate.Enabled = false;
                    this.xtraTabPageXBchange.PageVisible = false;
                }
                else if (this.mEditKind == "年度小班")
                {
                    if (this.barButtonItemAddFeature.Down)
                    {
                        args = new ItemClickEventArgs(this.barButtonItemAddFeature, this.barButtonItemAddFeature.Links[0]);
                        base.MapControlEdit.CurrentTool = null;
                        this.RefreshToolBarButton(false);
                        base.dockPanelEdit.Visibility = DockVisibility.Hidden;
                    }
                    editWorkspace = EditTask.EditWorkspace as IWorkspaceEdit;
                    if (((TaskManageClass.TaskState.ToString() == TaskState.Open.ToString()) && editWorkspace.IsBeingEdited()) && Editor.UniqueInstance.IsBeingEdited)
                    {
                        Editor.UniqueInstance.StopEdit();
                    }
                    this.barButtonItemInput.Enabled = false;
                    this.barButtonItemInputProperty.Enabled = false;
                    this.barButtonItemXBUpdate.Enabled = false;
                    this.xtraTabPageXBchange.PageVisible = false;
                }
                else if (this.mEditKind == "二类变化")
                {
                    if (this.barButtonItemAddFeature.Down)
                    {
                        args = new ItemClickEventArgs(this.barButtonItemAddFeature, this.barButtonItemAddFeature.Links[0]);
                        base.MapControlEdit.CurrentTool = null;
                        this.RefreshToolBarButton(false);
                        base.dockPanelEdit.Visibility = DockVisibility.Hidden;
                    }
                    editWorkspace = EditTask.EditWorkspace as IWorkspaceEdit;
                    if (((TaskManageClass.TaskState.ToString() == TaskState.Open.ToString()) && editWorkspace.IsBeingEdited()) && Editor.UniqueInstance.IsBeingEdited)
                    {
                        Editor.UniqueInstance.StopEdit();
                    }
                    this.barButtonItemInput.Enabled = false;
                    this.barButtonItemInputProperty.Enabled = false;
                    this.barButtonItemXBUpdate.Enabled = false;
                    this.xtraTabPageXBchange.PageVisible = false;
                }
                else if (this.mEditKind == "征占用")
                {
                    this.userControlProjectList1.simpleButtonOpen.Click += new EventHandler(this.userControlProjectList1simpleButtonOpen_Click);
                    base.dockPanelToolbox.Width = 310;
                    if (this.bDefaultPath)
                    {
                        editWorkspace = EditTask.EditWorkspace as IWorkspaceEdit;
                        if (((TaskManageClass.TaskState.ToString() == TaskState.Open.ToString()) && editWorkspace.IsBeingEdited()) && Editor.UniqueInstance.IsBeingEdited)
                        {
                            Editor.UniqueInstance.StopEdit();
                        }
                        this.barButtonItemInput.Enabled = false;
                        this.barButtonItemInputProperty.Enabled = false;
                        this.barButtonItemImportRedline.Enabled = false;
                        this.barEditItemEditLayer0.Enabled = false;
                        this.barEditItemEditLayer.Enabled = false;
                        this.barButtonItemCreateByPolygon.Enabled = false;
                        this.barButtonItemCreateByPolygon2.Enabled = false;
                        this.barButtonItemInputPropertyList.Enabled = false;
                        this.barButtonItemSaveEdit.Enabled = false;
                        this.barButtonItemSmoothPolygon.Enabled = false;
                        this.barButtonItemPropertyByXB.Enabled = false;
                        TaskManageClass.TaskState = TaskState.Close;
                        this.barButtonItemProjectList.Down = true;
                        base.dockPanelToolbox.Visibility = DockVisibility.Visible;
                        this.xtraTabPageProject.PageVisible = true;
                        base.xtraTabToolbox.SelectedTabPage = this.xtraTabPageProject;
                        this.userControlProjectList1.BringToFront();
                        this.userControlProjectList1.InitialValue(base.MapControlEdit.Object, this.mEditLayer);
                    }
                    else
                    {
                        this.barButtonItemProjectList.Down = true;
                        base.dockPanelToolbox.Visibility = DockVisibility.Visible;
                        this.xtraTabPageProject.PageVisible = true;
                        base.xtraTabToolbox.SelectedTabPage = this.xtraTabPageProject;
                        this.userControlProjectList1.BringToFront();
                        this.userControlProjectList1.InitialValue(base.MapControlEdit.Object, this.mEditLayer);
                    }
                }
                else if (this.mEditKind == "采伐")
                {
                    this.userControlDesignList1.simpleButtonOpen.Click += new EventHandler(this.userControlDesignList1simpleButtonOpen_Click);
                    base.dockPanelToolbox.Width = 310;
                    this.xtraTabPageProject.Text = "设计";
                    if (this.bDefaultPath)
                    {
                        this.barButtonItemProjectList.Down = true;
                        base.dockPanelToolbox.Visibility = DockVisibility.Visible;
                        this.xtraTabPageProject.PageVisible = true;
                        base.xtraTabToolbox.SelectedTabPage = this.xtraTabPageProject;
                        this.userControlDesignList1.BringToFront();
                        this.userControlDesignList1.InitialValue(base.MapControlEdit.Object, this.mEditLayer);
                    }
                    else
                    {
                        this.barButtonItemProjectList.Down = true;
                        base.dockPanelToolbox.Visibility = DockVisibility.Visible;
                        this.xtraTabPageProject.PageVisible = true;
                        base.xtraTabToolbox.SelectedTabPage = this.xtraTabPageProject;
                        IEnvelope extent = base.MapControlEdit.ActiveView.Extent;
                        this.userControlDesignList1.BringToFront();
                        this.userControlDesignList1.InitialValue(base.MapControlEdit.Object, this.mEditLayer);
                        base.MapControlEdit.ActiveView.Extent = extent;
                    }
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

                base.dockPanelToolbox.BringToFront();
                base.WindowState = FormWindowState.Maximized;
                base.Show();
                if (base.xtraTabMain.SelectedTabPageIndex == 0)
                {
                    base.MapControlEdit.BringToFront();
                    base.MapControlEdit.Dock = DockStyle.None;
                    base.MapControlEdit.Left = 1;
                    base.MapControlEdit.Top = 1;
                    base.MapControlEdit.Width = base.xtraTabMain.Width - 2;
                    base.MapControlEdit.Height = base.xtraTabMain.Height;
                    base.MapControlEdit.ShowScrollbars = false;
                    base.PageLayoutControlEdit.Dock = DockStyle.None;
                    base.PageLayoutControlEdit.Left = 1;
                    base.PageLayoutControlEdit.Top = 1;
                    base.PageLayoutControlEdit.Width = base.xtraTabMain.Width - 2;
                    base.PageLayoutControlEdit.Height = base.xtraTabMain.Height;
                }
                else if (base.xtraTabMain.SelectedTabPageIndex == 1)
                {
                    base.PageLayoutControlEdit.BringToFront();
                    base.PageLayoutControlEdit.Dock = DockStyle.None;
                    base.PageLayoutControlEdit.Left = 1;
                    base.PageLayoutControlEdit.Top = 1;
                    base.PageLayoutControlEdit.Width = base.xtraTabMain.Width - 2;
                    base.PageLayoutControlEdit.Height = base.xtraTabMain.Height;
                    base.MapControlEdit.Dock = DockStyle.None;
                    base.MapControlEdit.Left = 1;
                    base.MapControlEdit.Top = 1;
                    base.MapControlEdit.Width = base.xtraTabMain.Width - 2;
                    base.MapControlEdit.Height = base.xtraTabMain.Height;
                    base.MapControlEdit.ShowScrollbars = false;
                }
                if (this.FormSplash != null)
                {
                    this.FormSplash.SetLoadInfo("正在初始化功能模块...", 90);
                }
                if (this.FormSplash6 != null)
                {
                    this.FormSplash6.SetLoadInfo("正在初始化功能模块...", 90);
                }

                //this.m_Timer = new Timer();
                //this.m_Timer.Tick += new EventHandler(this.m_Timer_Tick);
                //this.m_Timer.Interval = 600;
                //this.m_Timer.Start();
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

        public bool InitializeForm5()
        {
            try
            {
                ItemClickEventArgs args;
                IWorkspaceEdit editWorkspace;
                this.FormSplash5.SetLoadInfo("正在加载地图数据...", 0x19);
                base.MapControlEdit.BringToFront();
                this.InitSynchronizer();
                this.InitializeGISControls();
                this.FormSplash5.SetLoadInfo("正在初始化工具按钮...", 30);
                this.InitializeBaseButtonComm();
                this.FormSplash5.SetLoadInfo("正在初始化工具按钮...", 40);
                this.InitializeBaseButtonEdit();
                this.FormSplash5.SetLoadInfo("正在初始化工具按钮...", 50);
                this.InitializeBaseButtonPage();
                this.FormSplash5.SetLoadInfo("正在初始化功能模块...", 60);
                this.SetFormText();
                base.ribbon.SelectedPage = base.ribbonPageDataEdit;
                this.FormSplash5.SetLoadInfo("正在初始化功能模块...", 70);
                if (this.mEditKind == "小班变更")
                {
                    this.userControlXBSet21.simpleButtonOK.Click += new EventHandler(this.userControlXBSet21simpleButtonOK_Click);
                    this.userControlXBSet21.simpleButtonCancel.Click += new EventHandler(this.userControlXBSet21simpleButtonCancel_Click);
                    this.userControlXBSet21.simpleButtonFinish.Click += new EventHandler(this.userControlXBSet21simpleButtonFinish_Click);
                    if (this.barButtonItemAddFeature.Down)
                    {
                        args = new ItemClickEventArgs(this.barButtonItemAddFeature, this.barButtonItemAddFeature.Links[0]);
                        base.MapControlEdit.CurrentTool = null;
                        this.RefreshToolBarButton(false);
                        base.dockPanelEdit.Visibility = DockVisibility.Hidden;
                    }
                    editWorkspace = EditTask.EditWorkspace as IWorkspaceEdit;
                    if (((TaskManageClass.TaskState.ToString() == TaskState.Open.ToString()) && editWorkspace.IsBeingEdited()) && Editor.UniqueInstance.IsBeingEdited)
                    {
                        Editor.UniqueInstance.StopEdit();
                    }
                    this.barButtonItemInput.Enabled = false;
                    this.barButtonItemInputProperty.Enabled = false;
                    this.barButtonItemXBUpdate.Enabled = false;
                    this.xtraTabPageXBchange.PageVisible = false;
                }
                else if (this.mEditKind == "年度小班")
                {
                    if (this.barButtonItemAddFeature.Down)
                    {
                        args = new ItemClickEventArgs(this.barButtonItemAddFeature, this.barButtonItemAddFeature.Links[0]);
                        base.MapControlEdit.CurrentTool = null;
                        this.RefreshToolBarButton(false);
                        base.dockPanelEdit.Visibility = DockVisibility.Hidden;
                    }
                    editWorkspace = EditTask.EditWorkspace as IWorkspaceEdit;
                    if (((TaskManageClass.TaskState.ToString() == TaskState.Open.ToString()) && editWorkspace.IsBeingEdited()) && Editor.UniqueInstance.IsBeingEdited)
                    {
                        Editor.UniqueInstance.StopEdit();
                    }
                    this.barButtonItemInput.Enabled = false;
                    this.barButtonItemInputProperty.Enabled = false;
                    this.barButtonItemXBUpdate.Enabled = false;
                    this.xtraTabPageXBchange.PageVisible = false;
                }
                this.FormSplash5.SetLoadInfo("正在初始化功能模块...", 80);
                this.SetButtonVisible();
                this.SetButtonEnabled();
                this.SetButtonTooltip();
                base.dockPanelToolbox.BringToFront();
                base.WindowState = FormWindowState.Maximized;
                base.Show();
                if (base.xtraTabMain.SelectedTabPageIndex == 0)
                {
                    base.MapControlEdit.BringToFront();
                    base.MapControlEdit.Dock = DockStyle.None;
                    base.MapControlEdit.Left = 1;
                    base.MapControlEdit.Top = 1;
                    base.MapControlEdit.Width = base.xtraTabMain.Width - 2;
                    base.MapControlEdit.Height = base.xtraTabMain.Height;
                    base.MapControlEdit.ShowScrollbars = false;
                    base.PageLayoutControlEdit.Dock = DockStyle.None;
                    base.PageLayoutControlEdit.Left = 1;
                    base.PageLayoutControlEdit.Top = 1;
                    base.PageLayoutControlEdit.Width = base.xtraTabMain.Width - 2;
                    base.PageLayoutControlEdit.Height = base.xtraTabMain.Height;
                }
                else if (base.xtraTabMain.SelectedTabPageIndex == 1)
                {
                    base.PageLayoutControlEdit.BringToFront();
                    base.PageLayoutControlEdit.Dock = DockStyle.None;
                    base.PageLayoutControlEdit.Left = 1;
                    base.PageLayoutControlEdit.Top = 1;
                    base.PageLayoutControlEdit.Width = base.xtraTabMain.Width - 2;
                    base.PageLayoutControlEdit.Height = base.xtraTabMain.Height;
                    base.MapControlEdit.Dock = DockStyle.None;
                    base.MapControlEdit.Left = 1;
                    base.MapControlEdit.Top = 1;
                    base.MapControlEdit.Width = base.xtraTabMain.Width - 2;
                    base.MapControlEdit.Height = base.xtraTabMain.Height;
                    base.MapControlEdit.ShowScrollbars = false;
                }
                this.FormSplash5.SetLoadInfo("正在初始化功能模块...", 90);
                LogType.SystemType = this.mEditKind;
                UserManager.Single.Log("登陆系统", this.mEditKind + "编辑", LogType.SystemType);
                //this.m_Timer = new Timer();
                //this.m_Timer.Tick += new EventHandler(this.m_Timer_Tick);
                //this.m_Timer.Interval = 600;
                //this.m_Timer.Start();
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
                base.ribbon.MouseMove += new MouseEventHandler(this.ribbon_MouseMove);
                base.dockPanelToolbox.MouseMove += new MouseEventHandler(this.dockPanelToolbox_MouseMove);
                base.dockPanelEdit.MouseMove += new MouseEventHandler(this.dockPanelEdit_MouseMove);
                base.dockPanelBottom.MouseMove += new MouseEventHandler(this.dockPanelBottom_MouseMove);
                base.xtraTabMain.MouseMove += new MouseEventHandler(this.xtraTabMain_MouseMove);
                base.xtraTabMain.SelectedPageChanged += new TabPageChangedEventHandler(this.xtraTabMain_SelectedPageChanged);
                this.StatusBar.MouseMove += new MouseEventHandler(this.StatusBar_MouseMove);
                this.mActiveViewEvents = base.MapControlEdit.Map as IActiveViewEvents_Event;
                this.mActiveViewEvents.ItemAdded += (new IActiveViewEvents_ItemAddedEventHandler(this.ActiveViewEvents_ItemAdded));
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
                this.barButtonItem_XZ.ItemClick += new ItemClickEventHandler(this.barButtonItem_XZ_ItemClick);
                this.barButtonItem_XZ2.ItemClick += new ItemClickEventHandler(this.barButtonItem_XZ2_ItemClick);
                this.barButtonItem_Auto.ItemClick += new ItemClickEventHandler(this.barButtonItem_Auto_ItemClick);
                this.barButtonItemZTT.ItemClick += new ItemClickEventHandler(this.barButtonItemZTT_ItemClick);
                this.barButtonItemPrintSet.ItemClick += new ItemClickEventHandler(this.barButtonItemPrintSet_ItemClick);
                this.barButtonItemPrint.ItemClick += new ItemClickEventHandler(this.barButtonItemPrint_ItemClick);
                this.barButtonItemPrintPreview.ItemClick += new ItemClickEventHandler(this.barButtonItemPrintPreview_ItemClick);
                this.barButtonItemExportImage.ItemClick += new ItemClickEventHandler(this.barButtonItemExportImage_ItemClick);
                this.barButtonItemMapSet.ItemClick += new ItemClickEventHandler(this.barButtonItemMapSet_ItemClick);
                this.barButtonItemVertexList.ItemClick += new ItemClickEventHandler(this.barButtonItemVertexList_ItemClick);
                this.barButtonItemInput.ItemClick += new ItemClickEventHandler(this.barButtonItemInput_ItemClick);
                this.barButtonItemLogicCheck.ItemClick += new ItemClickEventHandler(this.barButtonItemLogicCheck_ItemClick);
                this.barButtonItemReportCF.ItemClick += new ItemClickEventHandler(this.barButtonItemCF_ItemClick);
                this.barButtonItemReportCF1.ItemClick += new ItemClickEventHandler(this.barButtonItemCF1_ItemClick);
                this.barButtonItemReportZL.ItemClick += new ItemClickEventHandler(this.barButtonItemReportZL_ItemClick);
                this.barButtonItemReportHZ.ItemClick += new ItemClickEventHandler(this.barButtonItemReportHZ_ItemClick);
                this.barButtonItemChartHZ.ItemClick += new ItemClickEventHandler(this.barButtonItemChartHZ_ItemClick);
                this.barButtonItemReportZH.ItemClick += new ItemClickEventHandler(this.barButtonItemReportZH_ItemClick);
                this.barButtonItemReportAJ.ItemClick += new ItemClickEventHandler(this.barButtonItemReportAJ_ItemClick);
                this.barButtonItemReportZZY1.ItemClick += new ItemClickEventHandler(this.barButtonItemReportZZY_ItemClick);
                this.barButtonItemReportZZY2.ItemClick += new ItemClickEventHandler(this.barButtonItemReportZZY2_ItemClick);
                this.barButtonItemReportZZY3.ItemClick += new ItemClickEventHandler(this.barButtonItemReportZZY3_ItemClick);
                this.barButtonItemGrowthModel.ItemClick += new ItemClickEventHandler(this.barButtonItemGrowthModel_ItemClick);
                this.barButtonItemFullMap.ItemClick += new ItemClickEventHandler(this.barButtonItemFullMap_ItemClick);
                this.barButtonItemImport.ItemClick += new ItemClickEventHandler(this.barButtonItemImport_ItemClick);
                this.barButtonItemDesignQuery.ItemClick += new ItemClickEventHandler(this.barButtonItemDesignQuery_ItemClick);
                this.barButtonItemExit.ItemClick += new ItemClickEventHandler(this.barButtonItemExit_ItemClick);
                this.barButtonItemFireTable.ItemClick += new ItemClickEventHandler(this.barButtonItemFireTable_ItemClick);
                this.barButtonItemHZInfoTable.ItemClick += new ItemClickEventHandler(this.barButtonItemHZInfoTable_ItemClick);
                this.repositoryItemRadioGroup8.EditValueChanged += new EventHandler(this.repositoryItemRadioGroup8_EditValueChanged);
                this.barButtonItemImportRedline.ItemClick += new ItemClickEventHandler(this.barButtonItemImportRedline_ItemClick);
                this.barButtonItemProjectList.ItemClick += new ItemClickEventHandler(this.barButtonItemProjectList_ItemClick);
                this.barEditItemEditLayer0.ItemPress += new ItemClickEventHandler(this.barEditItemEditLayer_ItemPress);
                this.barEditItemEditLayer0.HiddenEditor += new ItemClickEventHandler(this.barEditItemEditLayer_HiddenEditor);
                this.repositoryItemComboBox7.EditValueChanged += new EventHandler(this.repositoryItemComboBox7_EditValueChanged);
                this.barButtonItemOutCFTable.ItemClick += new ItemClickEventHandler(this.barButtonItemOutCFTable_ItemClick);
                this.barButtonItemExportSub.ItemClick += new ItemClickEventHandler(this.barButtonItemExportSub_ItemClick);
                this.barButtonItemExportZT.ItemClick += new ItemClickEventHandler(this.barButtonItemExportZT_ItemClick);
                this.barButtonItemExportXM.ItemClick += new ItemClickEventHandler(this.barButtonItemExportXM_ItemClick);
                this.barButtonItemTopModify.ItemClick += new ItemClickEventHandler(this.barButtonItemTopModify_ItemClick);
                this.barButtonItemSingleCheck.ItemClick += new ItemClickEventHandler(this.barButtonItemSingleCheck_ItemClick);
                this.barButtonItemSaveEdit.ItemClick += new ItemClickEventHandler(this.barButtonItemSaveEdit_ItemClick);
                this.barButtonItemCreateByPolygon.ItemClick += new ItemClickEventHandler(this.barButtonItemCreateByPolygon_ItemClick);
                this.barButtonItemCreateByPolygon2.ItemClick += new ItemClickEventHandler(this.barButtonItemCreateByPolygon2_ItemClick);
                this.barButtonItemPropertyByXB.ItemClick += new ItemClickEventHandler(this.barButtonItemPropertyByXB_ItemClick);
                this.barButtonItemSmoothPolygon.ItemClick += new ItemClickEventHandler(this.barButtonItemSmoothPolygon_ItemClick);
                this.barButtonItemReportFCDC.ItemClick += new ItemClickEventHandler(this.barButtonItemReportFCDC_ItemClick);
                this.barButtonItemSave.ItemClick += new ItemClickEventHandler(this.barButtonItemSave_ItemClick);
                this.barButtonItemOpen.ItemClick += new ItemClickEventHandler(this.barButtonItemOpen_ItemClick);
                this.barButtonItemOpen2.ItemClick += new ItemClickEventHandler(this.barButtonItemOpen2_ItemClick);
                this.barButtonItemXJ.ItemClick += new ItemClickEventHandler(this.barButtonItemXJ_ItemClick);
                this.barButtonItemLinZu.ItemClick += new ItemClickEventHandler(this.barButtonItemLinZu_ItemClick);
                this.barButtonItemSetSpatialreference.ItemClick += new ItemClickEventHandler(this.barButtonItemSetSpatialreference_ItemClick);
                this.barButtonItemInputPropertyList.ItemClick += new ItemClickEventHandler(this.barButtonItemInputPropertyList_ItemClick);
                this.barButtonItemInputGYL.ItemClick += new ItemClickEventHandler(this.barButtonItemInputGYL_ItemClick);
                this.barButtonItemInputEL.ItemClick += new ItemClickEventHandler(this.barButtonItemInputEL_ItemClick);
                this.barButtonItemSSA.ItemClick += new ItemClickEventHandler(this.barButtonItemSSA_ItemClick);
                this.userControlLayerControl.treeList1.MouseMove += new MouseEventHandler(this.userControlLayerControltreeList1_MouseMove);
                this.userControlLayerControl.treeList1.MouseDown += new MouseEventHandler(this.userControlLayerControltreeList1_MouseDown);
                this.userControlTaskInfo1.MouseMove += new MouseEventHandler(this.userControls_MouseMove);
                this.userControlSelectFeatureResport21.MouseMove += new MouseEventHandler(this.userControls_MouseMove);
                this.userControlSelectLayerSet1.MouseMove += new MouseEventHandler(this.userControls_MouseMove);
                this.userControlQueryXB.MouseMove += new MouseEventHandler(this.userControls_MouseMove);
                this.userControlQueryXB21.MouseMove += new MouseEventHandler(this.userControls_MouseMove);
                this.userControlQueryResult2.MouseMove += new MouseEventHandler(this.userControls_MouseMove);
                this.userControlQueryResult1.MouseMove += new MouseEventHandler(this.userControls_MouseMove);
                this.userControlQueryCF1.MouseMove += new MouseEventHandler(this.userControls_MouseMove);
                this.userControlQueryCF21.MouseMove += new MouseEventHandler(this.userControls_MouseMove);
                this.userControlQueryAJ1.MouseMove += new MouseEventHandler(this.userControls_MouseMove);
                this.userControlQueryHZ1.MouseMove += new MouseEventHandler(this.userControls_MouseMove);
                this.userControlQueryHZ21.MouseMove += new MouseEventHandler(this.userControls_MouseMove);
                this.userControlQueryZL1.MouseMove += new MouseEventHandler(this.userControls_MouseMove);
                this.userControlMapFind1.MouseMove += new MouseEventHandler(this.userControls_MouseMove);
                this.userControlLayerControl.MouseMove += new MouseEventHandler(this.userControls_MouseMove);
                this.userControlXBSet21.MouseMove += new MouseEventHandler(this.userControls_MouseMove);
                this.userControlProjectList1.MouseMove += new MouseEventHandler(this.userControls_MouseMove);
                this.userControlDesignList1.MouseMove += new MouseEventHandler(this.userControls_MouseMove);
                this.userControlAttrEdit1.MouseMove += new MouseEventHandler(this.userControls_MouseMove);
                this.userControlAttriCheck1.MouseMove += new MouseEventHandler(this.userControls_MouseMove);
                this.userControlFireManage1.MouseMove += new MouseEventHandler(this.userControls_MouseMove);
                this.userControlInputData.MouseMove += new MouseEventHandler(this.userControls_MouseMove);
                this.userControlSelectByAttributes.MouseMove += new MouseEventHandler(this.userControls_MouseMove);
                this.userControlAttriList1.MouseMove += new MouseEventHandler(this.userControls_MouseMove);

                Tuple<string, bool> tup = DMM.PreparePathInfo(mEditKind);
                this.sMxdPath = tup.Item1;
                this.bDefaultPath = tup.Item2;

                FileInfo info = new FileInfo(this.sMxdPath);
                if (info.Exists)
                {
                    m_log.Warn("load mxd:" + sMxdPath);
                    (base.PageLayoutControlEdit.Object as IPageLayoutControl3).LoadMxFile(this.sMxdPath, null);
                    this.m_controlsSynchronizer2.SetMapOfPagelayoutToMap();
                    this.m_controlsSynchronizer2.ActivateMap();
                }
                else
                {
                    MessageBox.Show("地图数据加载失败，文件 " + this.sMxdPath + " 错误。", "提示", MessageBoxButtons.OK);
                }
                ///当文件不在本地时加载航空影像
                ////if (UtilFactory.GetConfigOpt().GetConfigValue("MapDBkey") != "Local")
                ////{
                ////    this.AddEviaTiledSatellite();
                ////}
                #region 连接SQLServerSDE需要改变
                ////if (UtilFactory.GetConfigOpt().GetConfigValue("MapDBkey") != "SqlServer")
                ////{
                ////    this.AddEviaTiledSatellite();
                ////}
                #endregion
                if (!this.InitializeEditValue(false))
                {
                    return false;
                }
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
                TemplateCartoManager manager = new TemplateCartoManager();
                Cartography.Template.TemplateInfo info2 = new Cartography.Template.TemplateInfo();
                string str = this.barEditItem_fx.EditValue.ToString();
                info2.TemplateDirection = Direction.Heng;
                info2.TF = "A4";
                if (EditTask.TaskName == "采伐")
                {
                    info2.TemplateBusiness = BusinessType.CaiFaSJ;
                }
                else if (EditTask.TaskName == "造林")
                {
                    info2.TemplateBusiness = BusinessType.ZaoLinSJ;
                }
                else if (EditTask.TaskName == "征占用")
                {
                    info2.TemplateBusiness = BusinessType.ZZWZ;
                }
                else if (EditTask.TaskName == "林业案件")
                {
                    info2.TemplateBusiness = BusinessType.AJBJ;
                }
                else if (EditTask.TaskName == "火灾")
                {
                    info2.TemplateBusiness = BusinessType.HZBJ;
                }
                else if (EditTask.TaskName == "自然灾害")
                {
                    info2.TemplateBusiness = BusinessType.ZHBJ;
                }
                else if (EditTask.TaskName == "年度小班")
                {
                    info2.TemplateBusiness = BusinessType.NDXBBJ;
                }
                else if (EditTask.TaskName == "遥感")
                {
                    info2.TemplateBusiness = BusinessType.YGBJ;
                }
                else if (EditTask.TaskName == "专题")
                {
                    info2.TemplateBusiness = BusinessType.XBCX;
                }
                else
                {
                    info2 = null;
                }
                Cartography.Template.TemplateInfo.CurrentTemplateInfo = info2;
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
        private DB2LayerModelManager DMM
        {
            get { return DBServiceFactory<DB2LayerModelManager>.Service; }
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
            if (this.mFirstFlag)
            {
                if (this.m_CountyFeature != null)
                {
                    this.ZoomToFeature(base.MapControlEdit.Map, this.m_CountyFeature);
                }
                this.mFirstFlag = false;
            }
        }

        private void MapControlEdit_Leave(object sender, EventArgs e)
        {
            base.ribbon.SetPopupContextMenu(this, null);
        }

        /// <summary>
        /// 在地图视图上绘制完成触发的事件
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

        private void MapControlEdit_OnMouseMove(object sender, IMapControlEvents2_OnMouseMoveEvent e)
        {
            try
            {
                this.MouseOn = true;
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
                        else if (base.MapControlEdit.Map.SelectionCount > 0)
                        {
                            base.ribbon.SetPopupContextMenu(this, this.popupMenuEdit);
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

        /// <summary>
        /// 在地图视图界面鼠标抬起触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MapControlEdit_OnMouseUp(object sender, IMapControlEvents2_OnMouseUpEvent e)
        {
            this.MouseOn = true;
            if (base.xtraTabMain.SelectedTabPageIndex == 0)
            {
                this.RefreshToolBarButton(false);
                if ((base.MapControlEdit.CurrentTool != null))
                {
                    if (((base.MapControlEdit.CurrentTool.ToString() == "ESRI.ArcGIS.Controls.ControlsEditingEditToolClass") && (this.mFormVertexList != null)) && this.mFormVertexList.Visible)
                    {
                        this.mFormVertexList.Init();
                    }
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

        public void OpenDesign()
        {
            try
            {
                this.m_controlsSynchronizer2.SetMapOfMapToPagelayout();
                this.m_controlsSynchronizer2.ActivateMap();
                this.userControlLayerControl.Map = base.MapControlEdit.Map;
                this.ResetToolBarButton();
                this.RefreshToolBarButton(true);
                this.mButtonCollection = new ArrayList();
                this.mButtonCollection2 = new ArrayList();
                this.mButtonCollection3 = new ArrayList();
                this.InitializeBaseButtonEdit();
                this.InitializeBaseButtonPage();
                this.SetButtonVisible();
                this.xtraTabPageInputData.PageVisible = false;
                if (this.barButtonItemIdentify2.Down)
                {
                    this.userControlInfo.InitialControls(this.mEditKind);
                }
                this.SetButtonVisible();
                this.SetButtonEnabled();
                this.SetFormText();
                IWorkspaceEdit editWorkspace = EditTask.EditWorkspace as IWorkspaceEdit;
                Editor.UniqueInstance.StartEdit(Editor.UniqueInstance.Workspace, Editor.UniqueInstance.Map);
                this.barButtonItemInput.Enabled = true;
                this.barButtonItemInputProperty.Enabled = true;
                this.barButtonItemImportRedline.Enabled = true;
                this.barEditItemEditLayer.Enabled = true;
                this.barButtonItemCreateByPolygon.Enabled = true;
                this.barButtonItemCreateByPolygon2.Enabled = true;
                this.barButtonItemSmoothPolygon.Enabled = true;
                this.barButtonItemPropertyByXB.Enabled = true;
                this.barButtonItemInputPropertyList.Enabled = true;
                this.barButtonItemSaveEdit.Enabled = true;
                this.barButtonItemCheckDist.Visibility = BarItemVisibility.Always;
                this.barButtonItemReportCF.Visibility = BarItemVisibility.Always;
                this.barButtonItemReportCF1.Visibility = BarItemVisibility.Never;
                this.barButtonItemChartCF.Visibility = BarItemVisibility.Never;
                TaskManageClass.TaskState = TaskState.Open;
                base.barStaticItemInfo.Caption = EditTask.TaskName;
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "GXFormMainFrame.FormMainEdit", "OpenDesign", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        public void OpenTask(T_EDITTASK_ZT_Mid pRow)
        {
            Exception exception;
            try
            {
                this.m_project = pRow;
                string str = m_project.taskyear;
                string sLayerName = "";
                string configValue = "";
                string str4 = "";
                string str5 = "";
                string str6 = "";
                if (this.mEditKind == "小班")
                {
                    sLayerName = "小班.lyr";
                    configValue = "XiaoBan";
                }
                else if (this.mEditKind == "造林")
                {
                    sLayerName = UtilFactory.GetConfigOpt().GetConfigValue("ZaoLinlyr");
                    configValue = UtilFactory.GetConfigOpt().GetConfigValue("ZaoLinlyr2");
                    str4 = UtilFactory.GetConfigOpt().GetConfigValue("ZaoLinlyr4");
                    str5 = "ZaoLin";
                    str6 = UtilFactory.GetConfigOpt().GetConfigValue("ZaoLinlyr5");
                }
                else if (this.mEditKind == "采伐")
                {
                    sLayerName = UtilFactory.GetConfigOpt().GetConfigValue("CaiFalyr");
                    configValue = UtilFactory.GetConfigOpt().GetConfigValue("CaiFalyr2");
                    str4 = UtilFactory.GetConfigOpt().GetConfigValue("CaiFalyr4");
                    str5 = "CaiFa";
                    str6 = UtilFactory.GetConfigOpt().GetConfigValue("CaiFalyr5");
                }
                IFeatureWorkspace editWorkspace = EditTask.EditWorkspace;
                IWorkspace workspace2 = editWorkspace as IWorkspace;
                IDataset dataset = workspace2 as IDataset;
                IFeatureDataset dataset2 = editWorkspace.OpenFeatureDataset(m_project.datasetname) as IFeatureDataset;
                IEnumDataset subsets = dataset2.Subsets;
                IDataset dataset4 = subsets.Next();
                IFeatureClass class2 = null;
                IFeatureClass class3 = null;
                while (dataset4 != null)
                {
                    if (dataset4.Type == esriDatasetType.esriDTFeatureClass)
                    {
                        class2 = dataset4 as IFeatureClass;
                        string[] strArray = dataset4.Name.Split(new char[] { '.' });
                        string str7 = strArray[strArray.Length - 1];
                        if (str7.Equals(m_project.layername))
                        {
                            class3 = class2;
                            break;
                        }
                    }
                    dataset4 = subsets.Next();
                }
                if (class3 != null)
                {
                    IMapDocument document = null;
                    document = new MapDocumentClass();
                    string sDocument = UtilFactory.GetConfigOpt().RootPath + @"\Template\" + configValue;
                    try
                    {
                        document.Open(sDocument, "");
                    }
                    catch (Exception exception1)
                    {
                        exception = exception1;
                        MessageBox.Show(sDocument + "  " + exception.Message);
                    }
                    ILayer layer = null;
                    if (document.DocumentType == esriMapDocumentType.esriMapDocumentTypeLyr)
                    {
                        layer = document.get_Layer(0, 0);
                        try
                        {
                            ((IFeatureLayer)layer).FeatureClass = class3;
                        }
                        catch (Exception)
                        {
                        }
                    }
                    document.Close();
                    document = new MapDocumentClass();
                    sDocument = UtilFactory.GetConfigOpt().RootPath + @"\Template\" + sLayerName;
                    document.Open(sDocument, "");
                    ILayer layer2 = null;
                    if (document.DocumentType == esriMapDocumentType.esriMapDocumentTypeLyr)
                    {
                        layer2 = document.get_Layer(0, 0);
                        try
                        {
                            ((IFeatureLayer)layer2).FeatureClass = class3;
                        }
                        catch (Exception)
                        {
                        }
                    }
                    document.Close();
                    if (layer2 != null)
                    {
                        IEnvelope envelope;
                        sLayerName = UtilFactory.GetConfigOpt().GetConfigValue("EditLayer");
                        if (this.mEditKind == "造林")
                        {
                            sLayerName = UtilFactory.GetConfigOpt().GetConfigValue("EditZLLayer");
                        }
                        if (this.mEditKind == "采伐")
                        {
                            sLayerName = UtilFactory.GetConfigOpt().GetConfigValue("EditCFLayer");
                        }
                        string str9 = UtilFactory.GetConfigOpt().GetConfigValue(str5 + "GroupName");
                        IGroupLayer pGroupLayer = GISFunFactory.LayerFun.FindLayer(base.MapControlEdit.Map as IBasicMap, str9, true) as IGroupLayer;
                        str9 = UtilFactory.GetConfigOpt().GetConfigValue(str5 + "GroupName2");
                        IGroupLayer layer4 = GISFunFactory.LayerFun.FindLayer(base.MapControlEdit.Map as IBasicMap, str9, true) as IGroupLayer;
                        if (pGroupLayer != null)
                        {
                            this.mEditLayer = GISFunFactory.LayerFun.FindLayerInGroupLayer(pGroupLayer, sLayerName, true) as IFeatureLayer;
                            sLayerName = UtilFactory.GetConfigOpt().GetConfigValue(str5 + "LayerName2");
                            this.mEditLayer2 = GISFunFactory.LayerFun.FindLayerInGroupLayer(pGroupLayer, sLayerName, true) as IFeatureLayer;
                        }
                        else
                        {
                            this.mEditLayer = GISFunFactory.LayerFun.FindLayer(base.MapControlEdit.Map as IBasicMap, sLayerName, true) as IFeatureLayer;
                            sLayerName = UtilFactory.GetConfigOpt().GetConfigValue(str5 + "LayerName2");
                            this.mEditLayer2 = GISFunFactory.LayerFun.FindLayer(base.MapControlEdit.Map as IBasicMap, sLayerName, true) as IFeatureLayer;
                        }
                        if (this.mEditLayer != null)
                        {
                            this.mEditLayer.FeatureClass = class3;
                            this.mEditLayer.Visible = true;
                            this.mEditLayer2.FeatureClass = ((IFeatureLayer)layer).FeatureClass;
                            this.mEditLayer2.Visible = true;
                        }
                        else
                        {
                            this.mEditLayer2 = layer as IFeatureLayer;
                            this.mEditLayer = layer2 as IFeatureLayer;
                            TaskManageClass.TaskState = TaskState.Open;
                            TaskManageClass.LogicCheckState = LogicCheckState.Failure;
                            TaskManageClass.ToplogicCheckState = ToplogicCheckState.Failure;
                            EditTask.KindCode = m_project.taskkind;
                            EditTask.TaskName = m_project.taskname;
                            EditTask.DistCode = m_project.distcode;
                            EditTask.TaskState = (TaskState2)int.Parse(m_project.taskstate);
                            EditTask.TaskYear = m_project.taskyear;
                            EditTask.CreateTime = m_project.createtime;
                            EditTask.EditTime = m_project.edittime;
                            EditTask.DatasetName = m_project.datasetname;
                            EditTask.LayerName = m_project.layername;
                            EditTask.TableName = m_project.tablename;
                            EditTask.TaskID = m_project.ID;
                            if (m_project.logiccheckstate == "1")
                            {
                                EditTask.LogicChkState = LogicCheckState.Success;
                            }
                            else if (m_project.logiccheckstate == "0")
                            {
                                EditTask.LogicChkState = LogicCheckState.Failure;
                            }
                            if (m_project.toplogiccheckstate == "1")
                            {
                                EditTask.ToplogicChkState = ToplogicCheckState.Success;
                            }
                            else if (m_project.toplogiccheckstate == "0")
                            {
                                EditTask.ToplogicChkState = ToplogicCheckState.Failure;
                            }
                            EditTask.EditLayer = this.mEditLayer;
                            string str10 = "Task_ID= '" + EditTask.TaskID + "'";
                            IFeatureLayerDefinition mEditLayer = (IFeatureLayerDefinition)this.mEditLayer;
                            mEditLayer.DefinitionExpression = str10;
                            str10 = "Task_ID<> '" + EditTask.TaskID + "' or TASK_ID IS NULL";
                            mEditLayer = (IFeatureLayerDefinition)this.mEditLayer2;
                            mEditLayer.DefinitionExpression = str10;
                            if (pGroupLayer != null)
                            {
                                pGroupLayer.Add(this.mEditLayer);
                                pGroupLayer.Add(this.mEditLayer2);
                                ICompositeLayer layer5 = pGroupLayer as ICompositeLayer;
                            }
                            else
                            {
                                base.MapControlEdit.AddLayer(this.mEditLayer2, 0);
                                base.MapControlEdit.AddLayer(this.mEditLayer, 0);
                            }
                        }
                        this.m_controlsSynchronizer2.SetMapOfMapToPagelayout();
                        this.m_controlsSynchronizer2.ActivateMap();
                        this.userControlLayerControl.mEditKind = this.mEditKind;
                        this.userControlLayerControl.Map = base.MapControlEdit.Map;
                        this.userControlLayerControl.InitialValue();
                        this.ResetToolBarButton();
                        this.RefreshToolBarButton(true);
                        this.mButtonCollection = new ArrayList();
                        this.mButtonCollection2 = new ArrayList();
                        this.mButtonCollection3 = new ArrayList();
                        this.InitializeBaseButtonEdit();
                        this.InitializeBaseButtonPage();
                        this.SetButtonVisible();
                        this.xtraTabPageInputData.PageVisible = false;
                        if (this.barButtonItemIdentify2.Down)
                        {
                            this.userControlInfo.InitialControls(this.mEditKind);
                        }
                        this.SetButtonVisible();
                        this.SetButtonEnabled();
                        this.SetFormText();
                        string str11 = "";
                        string str12 = "";
                        layer2 = null;
                        IFeatureLayer layer6 = null;
                        IQueryFilter queryFilter = null;
                        IFeature feature = null;
                        if (EditTask.DistCode.Length == 6)
                        {
                            str11 = UtilFactory.GetConfigOpt().GetConfigValue("CountyLayerName");
                            str12 = UtilFactory.GetConfigOpt().GetConfigValue("CountyFieldCode");
                            layer2 = GISFunFactory.LayerFun.FindLayer(base.MapControlEdit.Map as IBasicMap, str11, true);
                        }
                        else if (EditTask.DistCode.Length == 9)
                        {
                            str11 = UtilFactory.GetConfigOpt().GetConfigValue("TownLayerName");
                            str12 = UtilFactory.GetConfigOpt().GetConfigValue("TownFieldCode");
                            layer2 = GISFunFactory.LayerFun.FindLayer(base.MapControlEdit.Map as IBasicMap, str11, true);
                        }
                        else if (EditTask.DistCode.Length == 12)
                        {
                            str11 = UtilFactory.GetConfigOpt().GetConfigValue("VillageLayerName");
                            str12 = UtilFactory.GetConfigOpt().GetConfigValue("VillageFieldCode");
                            layer2 = GISFunFactory.LayerFun.FindLayer(base.MapControlEdit.Map as IBasicMap, str11, true);
                        }
                        if (layer2 != null)
                        {
                            layer6 = layer2 as IFeatureLayer;
                            queryFilter = new QueryFilterClass
                            {
                                WhereClause = str12 + "='" + EditTask.DistCode + "'"
                            };
                            feature = layer6.Search(queryFilter, false).NextFeature();
                            envelope = feature.Shape.Envelope;
                            envelope.Expand(1.2, 1.2, true);
                            base.MapControlEdit.ActiveView.FullExtent = envelope;
                            base.MapControlEdit.Map.SelectFeature(layer6, feature);
                        }
                        else
                        {
                            IQueryFilter filter2 = new QueryFilterClass
                            {
                                WhereClause = "Task_ID= '" + EditTask.TaskID + "'"
                            };
                            if (this.mEditLayer.FeatureClass.FeatureCount(filter2) > 0)
                            {
                                IFeatureCursor cursor = this.mEditLayer.FeatureClass.Search(filter2, false);
                                IFeature feature2 = cursor.NextFeature();
                                IGeometry shape = feature2.Shape;
                                if (shape.SpatialReference != base.MapControlEdit.Map.SpatialReference)
                                {
                                    shape.Project(base.MapControlEdit.Map.SpatialReference);
                                    shape.SpatialReference = base.MapControlEdit.Map.SpatialReference;
                                }
                                envelope = shape.Envelope;
                                while (feature2 != null)
                                {
                                    shape = feature2.Shape;
                                    if (shape.SpatialReference != base.MapControlEdit.Map.SpatialReference)
                                    {
                                        shape.Project(base.MapControlEdit.Map.SpatialReference);
                                        shape.SpatialReference = base.MapControlEdit.Map.SpatialReference;
                                    }
                                    if (envelope.XMin > shape.Envelope.XMin)
                                    {
                                        envelope.XMin = shape.Envelope.XMin;
                                    }
                                    if (envelope.YMin > shape.Envelope.YMin)
                                    {
                                        envelope.YMin = shape.Envelope.YMin;
                                    }
                                    if (envelope.XMax < shape.Envelope.XMax)
                                    {
                                        envelope.XMax = shape.Envelope.XMax;
                                    }
                                    if (envelope.YMax < shape.Envelope.YMax)
                                    {
                                        envelope.YMax = shape.Envelope.YMax;
                                    }
                                    feature2 = cursor.NextFeature();
                                }
                                envelope.Expand(1.1, 1.1, false);
                                base.MapControlEdit.ActiveView.FullExtent = envelope;
                            }
                            else
                            {
                                IDataset featureClass = this.mEditLayer.FeatureClass as IDataset;
                                IGeoDataset dataset6 = featureClass as IGeoDataset;
                                base.MapControlEdit.ActiveView.FullExtent = dataset6.Extent;
                            }
                        }
                        base.MapControlEdit.ActiveView.Refresh();
                        base.ribbonPageDataEdit.Visible = true;
                        base.ribbonPageTransfer.Visible = false;
                        base.ribbonPageCheck.Visible = true;
                        this.SetFormText();
                    }
                }
            }
            catch (Exception exception4)
            {
                exception = exception4;
                this.mErrOpt.ErrorOperate(this.mSubSysName, "GXFormMainFrame.FormMainEdit", "OpenTask2", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        public bool OpenWorkspace(string sFile, DataRow pRow)
        {
            try
            {
                FileInfo info = new FileInfo(sFile);
                if (info.Exists)
                {
                    (base.PageLayoutControlEdit.Object as IPageLayoutControl3).LoadMxFile(sFile, null);
                    this.m_controlsSynchronizer2.SetMapOfPagelayoutToMap();
                    this.m_controlsSynchronizer2.ActivateMap();
                    string configValue = UtilFactory.GetConfigOpt().GetConfigValue("EditLayer");
                    string str2 = "";
                    if (this.mEditKind == "造林")
                    {
                        configValue = UtilFactory.GetConfigOpt().GetConfigValue("EditZLLayer");
                        str2 = "ZaoLin";
                    }
                    if (this.mEditKind == "采伐")
                    {
                        configValue = UtilFactory.GetConfigOpt().GetConfigValue("EditCFLayer");
                        str2 = "CaiFa";
                    }
                    string sLayerName = UtilFactory.GetConfigOpt().GetConfigValue(str2 + "GroupName");
                    IGroupLayer pGroupLayer = GISFunFactory.LayerFun.FindLayer(base.MapControlEdit.Map as IBasicMap, sLayerName, true) as IGroupLayer;
                    sLayerName = UtilFactory.GetConfigOpt().GetConfigValue(str2 + "GroupName2");
                    if (pGroupLayer != null)
                    {
                        this.mEditLayer = GISFunFactory.LayerFun.FindLayerInGroupLayer(pGroupLayer, configValue, true) as IFeatureLayer;
                        if (this.mEditLayer == null)
                        {
                            MessageBox.Show("工作空间加载失败，" + this.mEditKind + "图层读取错误。", "提示", MessageBoxButtons.OK);
                            return false;
                        }
                        if (this.mEditLayer.FeatureClass == null)
                        {
                            MessageBox.Show("工作空间加载失败，" + this.mEditKind + "图层数据源丢失。", "提示", MessageBoxButtons.OK);
                            return false;
                        }
                        configValue = UtilFactory.GetConfigOpt().GetConfigValue(str2 + "LayerName2");
                        this.mEditLayer2 = GISFunFactory.LayerFun.FindLayerInGroupLayer(pGroupLayer, configValue, true) as IFeatureLayer;
                        if (this.mEditLayer2 == null)
                        {
                            MessageBox.Show("工作空间加载失败，" + this.mEditKind + "图层读取错误。", "提示", MessageBoxButtons.OK);
                            return false;
                        }
                        if (this.mEditLayer2.FeatureClass == null)
                        {
                            MessageBox.Show("工作空间加载失败，" + this.mEditKind + "图层数据源丢失。", "提示", MessageBoxButtons.OK);
                            return false;
                        }
                    }
                    else
                    {
                        MessageBox.Show("工作空间加载失败，" + this.mEditKind + "图层组读取错误。", "提示", MessageBoxButtons.OK);
                        return false;
                    }
                    TaskManageClass.TaskState = TaskState.Open;
                    TaskManageClass.LogicCheckState = LogicCheckState.Failure;
                    TaskManageClass.ToplogicCheckState = ToplogicCheckState.Failure;
                    EditTask.KindCode = pRow["taskkind"].ToString();
                    EditTask.TaskName = pRow["taskname"].ToString();
                    EditTask.DistCode = pRow["distcode"].ToString();
                    EditTask.TaskState = (TaskState2)int.Parse(pRow["taskstate"].ToString());
                    EditTask.TaskYear = pRow["taskyear"].ToString();
                    EditTask.CreateTime = pRow["createtime"].ToString();
                    EditTask.EditTime = pRow["edittime"].ToString();
                    EditTask.DatasetName = pRow["datasetname"].ToString();
                    EditTask.LayerName = pRow["layername"].ToString();
                    EditTask.TableName = pRow["tablename"].ToString();
                    EditTask.TaskID = long.Parse(pRow["ID"].ToString());
                    if (pRow["logiccheckstate"].ToString() == "1")
                    {
                        EditTask.LogicChkState = LogicCheckState.Success;
                    }
                    else if (pRow["logiccheckstate"].ToString() == "0")
                    {
                        EditTask.LogicChkState = LogicCheckState.Failure;
                    }
                    if (pRow["logiccheckstate"].ToString() == "1")
                    {
                        EditTask.ToplogicChkState = ToplogicCheckState.Success;
                    }
                    else if (pRow["logiccheckstate"].ToString() == "0")
                    {
                        EditTask.ToplogicChkState = ToplogicCheckState.Failure;
                    }
                    EditTask.EditLayer = this.mEditLayer;
                    this.userControlLayerControl.mEditKind = this.mEditKind;
                    this.userControlLayerControl.Map = base.MapControlEdit.Map;
                    this.userControlLayerControl.InitialValue();
                    this.RefreshToolBarButton(true);
                    this.mButtonCollection = new ArrayList();
                    this.mButtonCollection2 = new ArrayList();
                    this.mButtonCollection3 = new ArrayList();
                    this.InitializeBaseButtonEdit();
                    this.InitializeBaseButtonPage();
                    this.SetButtonVisible();
                    this.xtraTabPageInputData.PageVisible = false;
                    if (this.barButtonItemIdentify2.Down)
                    {
                        this.userControlInfo.InitialControls(this.mEditKind);
                    }
                    this.SetButtonVisible();
                    this.SetButtonEnabled();
                    this.SetFormText();
                    return true;
                }
                MessageBox.Show("工作空间加载失败，文件 " + sFile + " 错误。", "提示", MessageBoxButtons.OK);
                return false;
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "GXFormMainFrame.FormMainEdit", "OpenWorkspace", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                return false;
            }
        }

        public void OpenZZYProject()
        {
            try
            {
                IWorkspaceEdit editWorkspace = EditTask.EditWorkspace as IWorkspaceEdit;
                Editor.UniqueInstance.StartEdit(Editor.UniqueInstance.Workspace, Editor.UniqueInstance.Map);
                this.barButtonItemInput.Enabled = true;
                this.barButtonItemInputProperty.Enabled = true;
                this.barButtonItemImportRedline.Enabled = true;
                this.barEditItemEditLayer.Enabled = true;
                this.barButtonItemCreateByPolygon.Enabled = true;
                this.barButtonItemCreateByPolygon2.Enabled = true;
                this.barButtonItemSmoothPolygon.Enabled = true;
                this.barButtonItemPropertyByXB.Enabled = true;
                this.barButtonItemInputPropertyList.Enabled = true;
                this.barButtonItemSaveEdit.Enabled = true;
                this.barButtonItemCheckDist.Visibility = BarItemVisibility.Always;
                TaskManageClass.TaskState = TaskState.Open;
                base.barStaticItemInfo.Caption = EditTask.TaskName;
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "GXFormMainFrame.FormMainEdit", "OpenZZYProject", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
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
            if (this.mSelection)
            {
                base.axTOCControl.Update();
            }
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

                this.ribbonPageGroupMapView.AllowMinimize = false;
                this.ribbonPageGroupMapView2.AllowMinimize = false;
                this.ribbonPageGroupMapView3.AllowMinimize = false;
                this.ribbonPageGroupMapView4.AllowMinimize = false;

                if ((this.mCommandToolItems != null) && (this.mCommandToolItems.Count > 0))
                {
                    ICommand command = null;
                    foreach (BarButtonItem item in this.mCommandToolItems)
                    {
                        // item.RibbonStyle = this.mRibbonItemStyles;
                        //  item.PaintStyle = BarItemPaintStyle.CaptionGlyph;              
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
                    return;
                    if (this.MouseOn)
                    {
                        GetCursorPos(out this.p);
                        int width = 0;
                        int left = 0;
                        if (base.dockPanelToolbox.Visibility == DockVisibility.Visible)
                        {
                            width = base.dockPanelToolbox.Width;
                        }
                        if ((base.dockPanelToolbox.Visibility == DockVisibility.AutoHide) && base.dockPanelToolbox.Focused)
                        {
                            width = base.dockPanelToolbox.Width;
                        }
                        if (!((base.dockPanelToolbox.Visibility != DockVisibility.AutoHide) || base.dockPanelToolbox.Focused))
                        {
                            width = 0x18;
                        }
                        if (base.bar1.Visible && (base.bar1.DockStyle == BarDockStyle.Left))
                        {
                            width += 0x18;
                        }
                        if (base.dockPanelEdit.Visibility == DockVisibility.Visible)
                        {
                            left = base.dockPanelEdit.Left;
                        }
                        if ((base.dockPanelEdit.Visibility == DockVisibility.AutoHide) && base.dockPanelEdit.Focused)
                        {
                            left = base.dockPanelEdit.Left;
                        }
                        if (!((base.dockPanelEdit.Visibility != DockVisibility.AutoHide) || base.dockPanelEdit.Focused))
                        {
                            left = base.Width - 0x18;
                        }
                        if ((this.p.X <= width) || (this.p.X >= left))
                        {
                            base.ribbon.SetPopupContextMenu(this, null);
                        }
                        else if (base.MapControlEdit.CurrentTool is SnapEx)
                        {
                            base.ribbon.SetPopupContextMenu(this, null);
                        }
                        else if (this.barButtonItemEditFeature.Down)
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
                        else if (base.MapControlEdit.Map.SelectionCount > 0)
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
                        base.ribbon.SetPopupContextMenu(this, null);
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
            }
            catch (Exception)
            {
            }
        }

        private void repositoryItemComboBox7_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (base.dockPanelEdit.Visibility != DockVisibility.Hidden)
                {
                    base.dockPanelEdit.Visibility = DockVisibility.Hidden;
                }
                ComboBoxEdit edit = sender as ComboBoxEdit;
                if (edit.SelectedIndex == 0)
                {
                    if (EditTask.EditLayer.Name.Contains("点"))
                    {
                        return;
                    }
                    this.barButtonItemAddLine.Visibility = BarItemVisibility.Never;
                    this.barButtonItemAddFeature.Visibility = BarItemVisibility.Always;
                    this.barButtonItemInputProperty.Visibility = BarItemVisibility.Always;
                    this.barButtonItemInput.Visibility = BarItemVisibility.Always;
                    this.barButtonItemCreateByPolygon.Visibility = BarItemVisibility.Never;
                    this.barButtonItemCreateByPolygon2.Visibility = BarItemVisibility.Never;
                    this.barButtonItemSmoothPolygon.Visibility = BarItemVisibility.Never;
                    this.barButtonItemPropertyByXB.Visibility = BarItemVisibility.Never;
                    base.ribbonPageCheck.Visible = true;
                    EditTask.EditLayer = EditTask.UnderLayers[0] as IFeatureLayer;
                    this.mEditLayer = EditTask.EditLayer;
                    if (base.MapControlEdit.CurrentTool != null)
                    {
                        base.MapControlEdit.CurrentTool = null;
                    }
                }
                else if (edit.SelectedIndex == 1)
                {
                    if (EditTask.EditLayer.Name.Contains("线"))
                    {
                        return;
                    }
                    this.barButtonItemAddLine.Visibility = BarItemVisibility.Always;
                    this.barButtonItemAddFeature.Visibility = BarItemVisibility.Never;
                    this.barButtonItemInputProperty.Visibility = BarItemVisibility.Never;
                    this.barButtonItemInput.Visibility = BarItemVisibility.Never;
                    this.barButtonItemCreateByPolygon.Visibility = BarItemVisibility.Never;
                    this.barButtonItemCreateByPolygon2.Visibility = BarItemVisibility.Never;
                    this.barButtonItemSmoothPolygon.Visibility = BarItemVisibility.Never;
                    this.barButtonItemPropertyByXB.Visibility = BarItemVisibility.Never;
                    base.ribbonPageCheck.Visible = false;
                    EditTask.EditLayer = EditTask.UnderLayers[1] as IFeatureLayer;
                    this.mEditLayer = EditTask.EditLayer;
                    if (base.MapControlEdit.CurrentTool != null)
                    {
                        base.MapControlEdit.CurrentTool = null;
                    }
                }
                else
                {
                    if ((edit.SelectedIndex != 2) || EditTask.EditLayer.Name.Contains("面"))
                    {
                        return;
                    }
                    this.barButtonItemAddLine.Visibility = BarItemVisibility.Never;
                    this.barButtonItemAddFeature.Visibility = BarItemVisibility.Always;
                    this.barButtonItemInputProperty.Visibility = BarItemVisibility.Always;
                    this.barButtonItemInput.Visibility = BarItemVisibility.Always;
                    this.barButtonItemCreateByPolygon.Visibility = BarItemVisibility.Always;
                    this.barButtonItemCreateByPolygon2.Visibility = BarItemVisibility.Always;
                    this.barButtonItemSmoothPolygon.Visibility = BarItemVisibility.Always;
                    this.barButtonItemPropertyByXB.Visibility = BarItemVisibility.Always;
                    base.ribbonPageCheck.Visible = true;
                    EditTask.EditLayer = EditTask.UnderLayers[2] as IFeatureLayer;
                    this.mEditLayer = EditTask.EditLayer;
                    if (base.MapControlEdit.CurrentTool != null)
                    {
                        base.MapControlEdit.CurrentTool = null;
                    }
                }
                if (Editor.UniqueInstance.IsBeingEdited)
                {
                    Editor.UniqueInstance.StopEdit();
                }
                if (this.mEditLayer != null)
                {
                    IDataset featureClass = this.mEditLayer.FeatureClass as IDataset;
                    IWorkspace pWs = featureClass.Workspace;
                    Editor.UniqueInstance.StartEdit(pWs, base.MapControlEdit.ActiveView.FocusMap);
                    this.barButtonItemInput.Enabled = true;
                    this.RefreshToolBarButton(false);
                }
                else
                {
                    this.barButtonItemInput.Enabled = false;
                }
                Editor.UniqueInstance.TargetLayer = this.mEditLayer;
                AttributeManager.AttributeCombineHandleClass = new CombineHandleClass(base.MapControlEdit.Object, this.userControlAttrEdit1);
                AttributeManager.AttributeSplitHandleClass = new SplitHandleClass(base.MapControlEdit.Object, this.userControlAttrEdit1);
                AttributeManager.AttributeAddHandleClass = new AddHandleClass(base.MapControlEdit.Object, this.userControlAttrEdit1);
                AttributeManager.AttributeDeleteHandleClass = new DeleteHandleClass(this.userControlAttrEdit1);
                AttributeManager.AttributeUndoHandleClass = new UndoHandleClass(this.userControlAttrEdit1);
                this._editMapToolBar.SetBuddyControl(base.MapControlEdit.Object);
                Editor.UniqueInstance.BuddyToolBarControl(this._editMapToolBar.Object as IToolbarControl);
                this._editMapToolBar.AddItem(ToolFactory.GetEditTool(), 0, 0, false, 0, esriCommandStyles.esriCommandStyleTextOnly);
                this._editMapToolBar.AddItem(ToolFactory.GetInsertVertexTool(), 0, 1, false, 0, esriCommandStyles.esriCommandStyleTextOnly);
                this._editMapToolBar.AddItem(ToolFactory.GetDeleteVertexTool(), 0, 2, false, 0, esriCommandStyles.esriCommandStyleTextOnly);
                this._editMapToolBar.AddItem(new ShapeEdit.Undo(), 0, 3, false, 0, esriCommandStyles.esriCommandStyleTextOnly);
                this._editMapToolBar.AddItem(new ShapeEdit.Redo(), 0, 4, false, 0, esriCommandStyles.esriCommandStyleTextOnly);
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "GXFormMainFrame.FormMainEdit", "repositoryItemComboBox7_EditValueChanged", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void repositoryItemRadioGroup8_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                RadioGroup group = sender as RadioGroup;
                if (group.SelectedIndex == 0)
                {
                    if (EditTask.EditLayer.Name.Contains("点"))
                    {
                        return;
                    }
                    this.barButtonItemAddLine.Visibility = BarItemVisibility.Never;
                    this.barButtonItemAddFeature.Visibility = BarItemVisibility.Always;
                    EditTask.EditLayer = EditTask.UnderLayers[0] as IFeatureLayer;
                    this.mEditLayer = EditTask.EditLayer;
                }
                else if (group.SelectedIndex == 1)
                {
                    if (EditTask.EditLayer.Name.Contains("线"))
                    {
                        return;
                    }
                    this.barButtonItemAddLine.Visibility = BarItemVisibility.Always;
                    this.barButtonItemAddFeature.Visibility = BarItemVisibility.Never;
                    EditTask.EditLayer = EditTask.UnderLayers[1] as IFeatureLayer;
                    this.mEditLayer = EditTask.EditLayer;
                }
                else if ((group.SelectedIndex == 2) && !EditTask.EditLayer.Name.Contains("面"))
                {
                    this.barButtonItemAddLine.Visibility = BarItemVisibility.Never;
                    this.barButtonItemAddFeature.Visibility = BarItemVisibility.Always;
                    EditTask.EditLayer = EditTask.UnderLayers[2] as IFeatureLayer;
                    this.mEditLayer = EditTask.EditLayer;
                }
                else
                {
                    return;
                }
                if (Editor.UniqueInstance.IsBeingEdited)
                {
                    Editor.UniqueInstance.StopEdit();
                }
                if (this.mEditLayer != null)
                {
                    IDataset featureClass = this.mEditLayer.FeatureClass as IDataset;
                    IWorkspace pWs = featureClass.Workspace;
                    Editor.UniqueInstance.StartEdit(pWs, base.MapControlEdit.ActiveView.FocusMap);
                    this.barButtonItemInput.Enabled = true;
                }
                else
                {
                    this.barButtonItemInput.Enabled = false;
                }
                Editor.UniqueInstance.TargetLayer = this.mEditLayer;
                AttributeManager.AttributeCombineHandleClass = new CombineHandleClass(base.MapControlEdit.Object, this.userControlAttrEdit1);
                AttributeManager.AttributeSplitHandleClass = new SplitHandleClass(base.MapControlEdit.Object, this.userControlAttrEdit1);
                AttributeManager.AttributeAddHandleClass = new AddHandleClass(base.MapControlEdit.Object, this.userControlAttrEdit1);
                AttributeManager.AttributeDeleteHandleClass = new DeleteHandleClass(this.userControlAttrEdit1);
                AttributeManager.AttributeUndoHandleClass = new UndoHandleClass(this.userControlAttrEdit1);
                this._editMapToolBar.SetBuddyControl(base.MapControlEdit.Object);
                Editor.UniqueInstance.BuddyToolBarControl(this._editMapToolBar.Object as IToolbarControl);
                this._editMapToolBar.AddItem(ToolFactory.GetEditTool(), 0, 0, false, 0, esriCommandStyles.esriCommandStyleTextOnly);
                this._editMapToolBar.AddItem(ToolFactory.GetInsertVertexTool(), 0, 1, false, 0, esriCommandStyles.esriCommandStyleTextOnly);
                this._editMapToolBar.AddItem(ToolFactory.GetDeleteVertexTool(), 0, 2, false, 0, esriCommandStyles.esriCommandStyleTextOnly);
                this._editMapToolBar.AddItem(new ShapeEdit.Undo(), 0, 3, false, 0, esriCommandStyles.esriCommandStyleTextOnly);
                this._editMapToolBar.AddItem(new ShapeEdit.Redo(), 0, 4, false, 0, esriCommandStyles.esriCommandStyleTextOnly);
            }
            catch (Exception)
            {
            }
        }

        private void ResetToolBarButton()
        {
            try
            {
                Editor.UniqueInstance.StartEdit(this.mEditLayer.FeatureClass.FeatureDataset.Workspace, base.MapControlEdit.ActiveView.FocusMap);
                Editor.UniqueInstance.TargetLayer = this.mEditLayer;
                ICommand pCommand = new ToolAttributesEdit(this.userControlAttrEdit1);
                this.CreateCommand2(pCommand, ref this.barButtonItemInputProperty, this.mButtonCollection, -1, false, base.MapControlEdit.Object, "属性录入");
                pCommand = new PointRepeatCheckTool(this.mEditLayer);
                this.CreateCommand2(pCommand, ref this.barButtonItemCheckRepeat, this.mButtonCollection, -1, false, base.MapControlEdit.Object, "");
                pCommand = new SelfIntersectCheckTool(this.mEditLayer);
                this.CreateCommand2(pCommand, ref this.barButtonItemCheckSelfIntersect, this.mButtonCollection, -1, false, base.MapControlEdit.Object, "");
                pCommand = new AngleCheckTool(this.mEditLayer, this);
                this.CreateCommand2(pCommand, ref this.barButtonItemCheckAngle, this.mButtonCollection, -1, false, base.MapControlEdit.Object, "");
                pCommand = new AreaCheckTool(this.mEditLayer, this);
                this.CreateCommand2(pCommand, ref this.barButtonItemCheckArea, this.mButtonCollection, -1, false, base.MapControlEdit.Object, "");
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "GXFormMainFrame.FormMainEdit", "ResetToolBarButton", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void ribbon_Click(object sender, EventArgs e)
        {
            base.ribbon.SetPopupContextMenu(this, null);
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

        private void ribbon_MouseMove(object sender, MouseEventArgs e)
        {
            base.ribbon.SetPopupContextMenu(this, null);
        }

        private void ribbon_SelectedPageChanged(object sender, EventArgs e)
        {
            try
            {
                this.RefreshToolBarButton(false);
                this.ribbonindex = base.ribbon.SelectedPage.PageIndex;
                if ((base.ribbon.SelectedPage == base.ribbonPageDataEdit) || (base.ribbon.SelectedPage == base.ribbonPageCheck))
                {
                    base.xtraTabMain.SelectedTabPageIndex = 0;
                }
                else if (base.ribbon.SelectedPage == base.ribbonPageQuery)
                {
                    base.xtraTabMain.SelectedTabPageIndex = 0;
                    if (Editor.UniqueInstance.IsBeingEdited)
                    {
                        Editor.UniqueInstance.StopEdit();
                        Editor.UniqueInstance.StartEdit(Editor.UniqueInstance.Workspace, Editor.UniqueInstance.Map);
                    }
                }
                else if (base.ribbon.SelectedPage == base.ribbonPageGraphics)
                {
                    int num;
                    base.xtraTabMain.SelectedTabPageIndex = 1;
                    bool flag = false;
                    ArrayList list = new ArrayList();
                    ArrayList list2 = new ArrayList();
                    if (base.MapControlEdit.Map.SelectionCount > 0)
                    {
                        flag = true;
                        ArrayList selectionLayerCollection = this.GetSelectionLayerCollection(base.MapControlEdit.Map);
                        for (num = 0; num < selectionLayerCollection.Count; num++)
                        {
                            ILayer layer = selectionLayerCollection[num] as ILayer;
                            IFeatureSelection selection = layer as IFeatureSelection;
                            ISelectionSet selectionSet = selection.SelectionSet;
                            ICursor cursor = null;
                            selectionSet.Search(null, false, out cursor);
                            IFeatureCursor cursor2 = cursor as IFeatureCursor;
                            for (IFeature feature = cursor2.NextFeature(); feature != null; feature = cursor2.NextFeature())
                            {
                                list.Add(feature);
                                list2.Add(layer);
                            }
                        }
                    }
                    if (Editor.UniqueInstance.IsBeingEdited)
                    {
                        Editor.UniqueInstance.StopEdit();
                        Editor.UniqueInstance.StartEdit(Editor.UniqueInstance.Workspace, Editor.UniqueInstance.Map);
                    }
                    if (((list.Count > 0) && (list2.Count > 0)) && (list.Count == list2.Count))
                    {
                        for (num = 0; num < list2.Count; num++)
                        {
                            base.MapControlEdit.Map.SelectFeature(list2[num] as ILayer, list[num] as IFeature);
                        }
                    }
                }
                else if ((base.ribbon.SelectedPage == this.ribbonPageStatic) && Editor.UniqueInstance.IsBeingEdited)
                {
                    Editor.UniqueInstance.StopEdit();
                    Editor.UniqueInstance.StartEdit(Editor.UniqueInstance.Workspace, Editor.UniqueInstance.Map);
                }
                this.mSelection = false;
            }
            catch (Exception exception)
            {
                this.mSelection = false;
                this.mErrOpt.ErrorOperate(this.mSubSysName, "GXFormMainFrame.FormMainEdit", "ribbon_SelectedPageChanged", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private bool SaveMXD(string sFile, bool flag)
        {
            try
            {
                IMxdContents pMxdContents = null;
                AxMapControl mapControlEdit = base.MapControlEdit;
                this.m_controlsSynchronizer2.SetMapOfPagelayoutToMap();
                this.m_controlsSynchronizer2.ActivateMap();
                base.PageLayoutControlEdit.Page.Orientation = 2;
                pMxdContents = base.PageLayoutControlEdit.Object as IMxdContents;
                if (GISFunFactory.CoreFun.SaveMapDocument(pMxdContents, sFile, true, true, true, flag))
                {
                    if (!flag)
                    {
                        MessageBox.Show("存储完成！");
                    }
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private void SelectFeature(IFeatureLayer pFLayer, IFeature pFeature)
        {
            (pFLayer as IFeatureSelection).Clear();
            if ((pFLayer != null) && (pFeature != null))
            {
                base.MapControlEdit.Map.SelectFeature(pFLayer, pFeature);
            }
        }

        private void SetButtonEnabled()
        {
            try
            {
                if (this.mEditKind.Contains("遥感"))
                {
                    this.barButtonItemInputZT.Enabled = false;
                    this.barButtonItemInputYG.Enabled = true;
                    this.barButtonItemInputDC.Enabled = false;
                    this.barButtonItemInputOther.Enabled = false;
                    this.barButtonItemLayerCombine.Enabled = false;
                    this.barButtonItemXBEdit.Enabled = false;
                    this.barButtonItemArea.Enabled = false;
                    this.barButtonItemXJ.Enabled = false;
                    this.barButtonItemLinZu.Enabled = false;
                }
                else if (this.mEditKind.Contains("小班变更"))
                {
                    this.barButtonItemLayerCombine.Enabled = false;
                    this.barButtonItemXBEdit.Enabled = false;
                    this.barButtonItemArea.Enabled = false;
                    this.barButtonItemXJ.Enabled = false;
                    this.barButtonItemLinZu.Enabled = false;
                    this.barButtonItemCreateByPolygon.Enabled = false;
                    this.barButtonItemCreateByPolygon2.Enabled = false;
                    this.barButtonItemSmoothPolygon.Enabled = false;
                    this.barButtonItemPropertyByXB.Enabled = false;
                    this.barButtonItemInputPropertyList.Enabled = false;
                    this.barButtonItemSaveEdit.Enabled = false;
                }
                else if (this.mEditKind.Contains("年度小班"))
                {
                    this.barButtonItemCreateByPolygon.Enabled = false;
                    this.barButtonItemCreateByPolygon2.Enabled = false;
                    this.barButtonItemSmoothPolygon.Enabled = false;
                    this.barButtonItemPropertyByXB.Enabled = false;
                    this.barButtonItemInputPropertyList.Enabled = false;
                    this.barButtonItemSaveEdit.Enabled = false;
                }
                else if (this.mEditKind.Contains("二类变化"))
                {
                    this.barButtonItemCreateByPolygon.Enabled = false;
                    this.barButtonItemCreateByPolygon2.Enabled = false;
                    this.barButtonItemSmoothPolygon.Enabled = false;
                    this.barButtonItemPropertyByXB.Enabled = false;
                    this.barButtonItemInputPropertyList.Enabled = false;
                    this.barButtonItemSaveEdit.Enabled = false;
                }
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
                this.barButtonItemImport.Visibility = BarItemVisibility.Never;
                this.barButtonItemSmoothPolygon.Visibility = BarItemVisibility.Never;
                this.ribbonPageGroupQuery2.Text = this.mEditKind + "查询";
                if (this.mEditKind == "造林")
                {
                    this.mEditKind2 = "ZaoLin";
                    this.barButtonItemXBUpdate.Visibility = BarItemVisibility.Never;
                    this.barButtonItemQueryXB.Visibility = BarItemVisibility.Always;
                    this.barButtonItemQueryXB.Description = "小班查询";
                    this.barButtonItemQueryZT.Visibility = BarItemVisibility.Always;
                    this.barButtonItemQueryYear.Visibility = BarItemVisibility.Never;
                    this.ribbonPageGroupZL.Visible = true;
                    this.ribbonPageGroupCF.Visible = false;
                    this.barButtonItemCopyHarvest.Visibility = BarItemVisibility.Always;
                    this.barButtonItem_XZ2.Visibility = BarItemVisibility.Always;
                }
                else if (this.mEditKind == "采伐")
                {
                    this.mEditKind2 = "CaiFa";
                    this.barButtonItemXBUpdate.Visibility = BarItemVisibility.Never;
                    this.barButtonItemQueryXB.Visibility = BarItemVisibility.Always;
                    this.barButtonItemQueryXB.Description = "小班查询";
                    this.barButtonItemQueryZT.Visibility = BarItemVisibility.Always;
                    this.barButtonItemQueryYear.Visibility = BarItemVisibility.Never;
                    this.barButtonItemDesignQuery.Visibility = BarItemVisibility.Always;
                    this.ribbonPageGroupCF.Visible = true;
                    this.ribbonPageGroupZL.Visible = false;
                    this.barButtonItemImport.Visibility = BarItemVisibility.Always;
                    this.barButtonItemOutCFTable.Visibility = BarItemVisibility.Always;
                    this.barButtonItem_XZ2.Visibility = BarItemVisibility.Always;
                    this.ribbonPageGroupProject.Visible = true;
                    this.ribbonPageGroupProject.Text = "伐区设计";
                    this.barButtonItemProjectList.Caption = "设计列表";
                    this.barButtonItemProjectList.Description = "伐区作业设计列表";
                    this.barButtonItemExportXM.Caption = "设计导出";
                    this.barButtonItemExportXM.Description = "采伐作业设计数据导出";
                    this.barButtonItemExportXM.Visibility = BarItemVisibility.Always;
                    this.barButtonItemImport.Description = "采伐作业设计数据导入";
                    this.barButtonItemReportFCDC.Visibility = BarItemVisibility.Never;
                }
                else if (this.mEditKind == "林业工程")
                {
                    this.mEditKind2 = "LYGC";
                    this.barButtonItemXBUpdate.Visibility = BarItemVisibility.Never;
                    this.barButtonItemQueryXB.Visibility = BarItemVisibility.Always;
                    this.barButtonItemQueryXB.Description = "小班查询";
                    this.barButtonItemQueryZT.Visibility = BarItemVisibility.Always;
                }
                else if (this.mEditKind.Contains("征占用"))
                {
                    this.mEditKind2 = "ZZY";
                    this.barButtonItemXBUpdate.Visibility = BarItemVisibility.Never;
                    this.barButtonItemQueryXB.Visibility = BarItemVisibility.Always;
                    this.barButtonItemQueryXB.Description = "小班查询";
                    this.barButtonItemQueryZT.Visibility = BarItemVisibility.Always;
                    this.barButtonItemQueryZT.Description = "征占用数据查询";
                    this.ribbonPageGroupEditLayer.Visible = true;
                    this.ribbonPageGroupImportBack.Visible = true;
                    this.ribbonPageGroupProject.Visible = true;
                    this.ribbonPageGroupProject.Text = "征占用项目";
                    this.barButtonItemProjectList.Caption = "项目列表";
                    this.barButtonItemProjectList.Description = "征占用项目列表";
                    this.barButtonItemExportXM.Caption = "项目导出";
                    this.barButtonItemExportXM.Description = "征占用项目数据导出";
                    this.barButtonItemExportXM.Visibility = BarItemVisibility.Always;
                    this.barButtonItemImport.Description = "征占用项目数据导入";
                    this.barButtonItem_XZ2.Visibility = BarItemVisibility.Always;
                    this.ribbonPageGroupZZY.Visible = true;
                    this.barButtonItemImport.Visibility = BarItemVisibility.Always;
                    this.barButtonItemSJ.Down = false;
                    this.barButtonItemDC.Down = true;
                    this.barButtonItemSJ.Caption = "位置图";
                    this.barButtonItemSJ.Visibility = BarItemVisibility.Always;
                    this.barButtonItemDC.Caption = "调查图";
                    this.barButtonItemDC.Visibility = BarItemVisibility.Always;
                    this.barButtonItemZTT.Visibility = BarItemVisibility.Never;
                    this.barButtonItem_XZ.Visibility = BarItemVisibility.Never;
                }
                else if (this.mEditKind.Contains("火灾"))
                {
                    this.mEditKind2 = "Fire";
                    this.ribbonPageGroupInputTable.Visible = true;
                    this.ribbonPageGroupHZ.Visible = true;
                    this.barButtonItemZTT.Visibility = BarItemVisibility.Always;
                    this.barButtonItemZTT.ButtonStyle = BarButtonStyle.Check;
                    this.barButtonItemZTT.Down = true;
                    this.barButtonItemFireTable.Visibility = BarItemVisibility.Always;
                    this.barButtonItemXBUpdate.Visibility = BarItemVisibility.Never;
                    this.barButtonItemQueryXB.Visibility = BarItemVisibility.Always;
                    this.barButtonItemQueryXB.Description = "小班查询";
                    this.barButtonItemQueryZT.Visibility = BarItemVisibility.Always;
                    this.barButtonItemHZInfoTable.Visibility = BarItemVisibility.Always;
                    this.barButtonItemSJ.Visibility = BarItemVisibility.Never;
                    this.barButtonItemDC.Visibility = BarItemVisibility.Never;
                    this.barButtonItem_XZ.Visibility = BarItemVisibility.Never;
                    this.barButtonItem_XZ2.Visibility = BarItemVisibility.Always;
                }
                else if (this.mEditKind.Contains("自然灾害"))
                {
                    this.mEditKind2 = "ZRZH";
                    this.ribbonPageGroupZH.Visible = true;
                    this.barButtonItemZTT.Visibility = BarItemVisibility.Always;
                    this.barButtonItemZTT.ButtonStyle = BarButtonStyle.Check;
                    this.barButtonItemZTT.Down = true;
                    this.barButtonItemXBUpdate.Visibility = BarItemVisibility.Never;
                    this.barButtonItemQueryXB.Visibility = BarItemVisibility.Always;
                    this.barButtonItemQueryXB.Description = "小班查询";
                    this.barButtonItemQueryZT.Visibility = BarItemVisibility.Always;
                    this.barButtonItemSJ.Visibility = BarItemVisibility.Never;
                    this.barButtonItemDC.Visibility = BarItemVisibility.Never;
                    this.barButtonItem_XZ.Visibility = BarItemVisibility.Never;
                    this.barButtonItem_XZ2.Visibility = BarItemVisibility.Always;
                }
                else if (this.mEditKind.Contains("案件"))
                {
                    this.mEditKind2 = "AnJian";
                    this.ribbonPageGroupAJ.Visible = true;
                    this.barButtonItemZTT.Visibility = BarItemVisibility.Always;
                    this.barButtonItemZTT.ButtonStyle = BarButtonStyle.Check;
                    this.barButtonItemZTT.Down = true;
                    this.barButtonItemXBUpdate.Visibility = BarItemVisibility.Never;
                    this.barButtonItemQueryXB.Visibility = BarItemVisibility.Always;
                    this.barButtonItemQueryXB.Description = "小班查询";
                    this.barButtonItemQueryZT.Visibility = BarItemVisibility.Always;
                    this.barButtonItemSJ.Visibility = BarItemVisibility.Never;
                    this.barButtonItemDC.Visibility = BarItemVisibility.Never;
                    this.barButtonItem_XZ.Visibility = BarItemVisibility.Never;
                    this.barButtonItem_XZ2.Visibility = BarItemVisibility.Always;
                }
                else if (this.mEditKind == "小班变更")
                {
                    this.mEditKind2 = "XB";
                    this.xtraTabPageXBchange.Text = "变更";
                    this.barButtonItemZTT.Visibility = BarItemVisibility.Always;
                    this.barButtonItemZTT.ButtonStyle = BarButtonStyle.Check;
                    this.barButtonItemZTT.Down = true;
                    this.barButtonItemDC.Visibility = BarItemVisibility.Never;
                    this.barButtonItemSJ.Visibility = BarItemVisibility.Never;
                    this.ribbonPageStatic.Visible = false;
                    this.ribbonPageGroupCaoTu.Visible = true;
                    if (this.barButtonItemInputZT.Down)
                    {
                        this.xtraTabPageXBchange.PageVisible = true;
                    }
                    this.barButtonItemInput.Visibility = BarItemVisibility.Never;
                    this.barButtonItemQueryXB.Visibility = BarItemVisibility.Always;
                    this.barButtonItemQueryZT.Visibility = BarItemVisibility.Always;
                    this.barButtonItemExportZT.Visibility = BarItemVisibility.Always;
                }
                else if (this.mEditKind == "年度小班")
                {
                    this.mEditKind2 = "XB";
                    this.xtraTabPageXBchange.Text = "年度";
                    this.barButtonItemZTT.Visibility = BarItemVisibility.Always;
                    this.barButtonItemZTT.ButtonStyle = BarButtonStyle.Check;
                    this.barButtonItemZTT.Down = true;
                    this.barButtonItemDC.Visibility = BarItemVisibility.Never;
                    this.barButtonItemSJ.Visibility = BarItemVisibility.Never;
                    this.ribbonPageStatic.Visible = false;
                    this.ribbonPageGroupXB.Visible = true;
                    this.barButtonItemInput.Visibility = BarItemVisibility.Never;
                    this.barButtonItemQueryXB.Visibility = BarItemVisibility.Always;
                    this.barButtonItemQueryZT.Visibility = BarItemVisibility.Always;
                    this.barButtonItemExportSub.Visibility = BarItemVisibility.Always;
                    this.barButtonItemExportZT.Visibility = BarItemVisibility.Never;
                    this.barButtonItemCheckXCPolygon.Visibility = BarItemVisibility.Always;
                    this.barButtonItemLinZu.Visibility = BarItemVisibility.Always;
                    this.barButtonItemSSA.Visibility = BarItemVisibility.Always;
                }
                else if (this.mEditKind.Contains("遥感"))
                {
                    this.mEditKind2 = "YG";
                    this.barButtonItemSmoothPolygon.Visibility = BarItemVisibility.Always;
                    this.ribbonPageStatic.Visible = false;
                    this.barButtonItemZTT.Visibility = BarItemVisibility.Always;
                    this.barButtonItemZTT.ButtonStyle = BarButtonStyle.Check;
                    this.barButtonItemZTT.Down = true;
                    this.barButtonItemDC.Visibility = BarItemVisibility.Never;
                    this.barButtonItemSJ.Visibility = BarItemVisibility.Never;
                    this.barButtonItemXBUpdate.Visibility = BarItemVisibility.Never;
                    this.barButtonItemQueryXB.Visibility = BarItemVisibility.Always;
                    this.barButtonItemQueryXB.Description = "小班查询";
                    this.barButtonItemQueryZT.Visibility = BarItemVisibility.Always;
                    this.barButtonItemQueryKind.Visibility = BarItemVisibility.Never;
                    this.barButtonItem_XZ.Visibility = BarItemVisibility.Never;
                }
                else if (this.mEditKind.Contains("二类变化"))
                {
                    this.mEditKind2 = "ELBH";
                    base.ribbonPageGraphics.Visible = false;
                    this.ribbonPageStatic.Visible = false;
                    this.ribbonPageGroupXB.Visible = true;
                    this.ribbonPageGroupXB.Text = "二类变化编辑";
                    this.barButtonItemInputEL.Visibility = BarItemVisibility.Always;
                    this.barButtonItemXBEdit.Visibility = BarItemVisibility.Always;
                    this.barButtonItemXBEdit.Caption = "二类编辑";
                    this.barButtonItemLayerCombine.Visibility = BarItemVisibility.Never;
                    this.barButtonItemArea.Visibility = BarItemVisibility.Never;
                    this.barButtonItemGrowthModel.Visibility = BarItemVisibility.Never;
                    this.barButtonItemLinZu.Visibility = BarItemVisibility.Never;
                    this.barButtonItemXJ.Visibility = BarItemVisibility.Never;
                    this.barButtonItemInput.Visibility = BarItemVisibility.Never;
                    this.barButtonItemZTT.Visibility = BarItemVisibility.Always;
                    this.barButtonItemZTT.ButtonStyle = BarButtonStyle.Check;
                    this.barButtonItemZTT.Down = true;
                    this.barButtonItemDC.Visibility = BarItemVisibility.Never;
                    this.barButtonItemSJ.Visibility = BarItemVisibility.Never;
                    this.barButtonItemXBUpdate.Visibility = BarItemVisibility.Never;
                    this.barButtonItemQueryXB.Visibility = BarItemVisibility.Always;
                    this.barButtonItemQueryXB.Description = "小班查询";
                    this.barButtonItemQueryZT.Visibility = BarItemVisibility.Always;
                    this.barButtonItemQueryKind.Visibility = BarItemVisibility.Never;
                    this.barButtonItem_XZ.Visibility = BarItemVisibility.Never;
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "GXFormMainFrame.FormMainEdit", "SetButtonVisible", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void SetFeatureArea(IFeature pFeature)
        {
            if (pFeature != null)
            {
                try
                {
                    IGeometry shapeCopy = pFeature.ShapeCopy;
                    if (shapeCopy.GeometryType == esriGeometryType.esriGeometryPolygon)
                    {
                        double area = ((IArea)GISFunFactory.UnitFun.ConvertPoject(shapeCopy, base.MapControlEdit.Map.SpatialReference)).Area;
                        string str = EditTask.KindCode.Substring(0, 2);
                        string name = "";
                        string str3 = "";
                        string str4 = "";
                        if (str == "01")
                        {
                            area = Math.Round(Math.Abs((double)(area / 10000.0)), 2);
                            name = "Afforest";
                            str3 = UtilFactory.GetConfigOpt().GetConfigValue2(name, "AreaField");
                        }
                        else if (str == "02")
                        {
                            area = Math.Round(Math.Abs((double)(area / 10000.0)), 2);
                            name = "Harvest";
                            str3 = UtilFactory.GetConfigOpt().GetConfigValue2(name, "AreaField");
                            str4 = UtilFactory.GetConfigOpt().GetConfigValue2(name, "ZTAreaField");
                        }
                        else if (str == "06")
                        {
                            area = Math.Round(Math.Abs((double)(area / 10000.0)), 2);
                            name = "Disaster";
                            str4 = UtilFactory.GetConfigOpt().GetConfigValue2(name, "ZTAreaField");
                        }
                        else if (str == "07")
                        {
                            area = Math.Round(Math.Abs((double)(area / 10000.0)), 2);
                            name = "ForestCase";
                            str3 = UtilFactory.GetConfigOpt().GetConfigValue2(name, "AreaField");
                        }
                        else if (str == "04")
                        {
                            area = Math.Round(Math.Abs((double)(area / 10000.0)), 4);
                            name = "Expropriation";
                            str3 = UtilFactory.GetConfigOpt().GetConfigValue2(name, "AreaField");
                        }
                        else if (str == "05")
                        {
                            area = Math.Round(Math.Abs((double)(area / 10000.0)), 2);
                            name = "Fire";
                            str3 = UtilFactory.GetConfigOpt().GetConfigValue2(name, "AreaField");
                        }
                        else
                        {
                            area = Math.Round(Math.Abs((double)(area / 10000.0)), 2);
                            name = "Sub";
                            str3 = UtilFactory.GetConfigOpt().GetConfigValue2(name, "AreaField");
                        }
                        int index = pFeature.Fields.FindField(str3);
                        if (index > -1)
                        {
                            pFeature.set_Value(index, area);
                        }
                        index = pFeature.Fields.FindField(str4);
                        if (index > -1)
                        {
                            pFeature.set_Value(index, area);
                        }
                        pFeature.Store();
                    }
                }
                catch
                {
                }
            }
        }

        private void SetFormText()
        {
            try
            {
                string str = UtilFactory.GetConfigOpt().GetSystemName() + EditTask.TaskYear + "年度";
                if (this.mEditKind == "小班")
                {
                    this.Text = str + " — 小班变更编辑";
                    base.barStaticItemInfo.Caption = "就绪";
                }
                else if (this.mEditKind == "采伐")
                {
                    if (TaskManageClass.TaskState == TaskState.Open)
                    {
                        if (this.m_project != null)
                        {
                            this.Text = str + " — " + this.mEditKind + "专题数据编辑【 " + m_project.taskname + " 】";
                            base.barStaticItemInfo.Caption = EditTask.TaskName;
                        }
                        else
                        {
                            this.Text = str + " — " + this.mEditKind + "专题数据编辑";
                            base.barStaticItemInfo.Caption = EditTask.TaskName;
                        }
                    }
                }
                else
                {
                    string taskState = this.GetTaskState(EditTask.TaskState);
                    if (TaskManageClass.TaskState == TaskState.Open)
                    {
                        this.Text = str + " — " + this.mEditKind + "专题数据编辑";
                        if (this.mEditKind == "自然灾害")
                        {
                            this.Text = str + " — 其它灾害专题数据编辑";
                        }
                        base.barStaticItemInfo.Caption = EditTask.TaskName;
                        if (this.mEditKind == "自然灾害")
                        {
                            base.barStaticItemInfo.Caption = "其它灾害";
                        }
                    }
                    else if (TaskManageClass.TaskState == TaskState.Close)
                    {
                        this.Text = str + " — " + this.mEditKind;
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

        private void SetLayerRenderer(string sName, string sYear, IFeatureLayer pFeatureLayer)
        {
            try
            {
                IMapDocument document = null;
                document = new MapDocumentClass();
                string sDocument = UtilFactory.GetConfigOpt().RootPath + @"\Template\" + sName.Replace("_" + sYear, "") + ".lyr";
                document.Open(sDocument, "");
                IGeoFeatureLayer layer3 = null;
                IFeatureRenderer renderer = null;
                if (document.DocumentType == esriMapDocumentType.esriMapDocumentTypeLyr)
                {
                    IFeatureLayer layer2 = (IFeatureLayer)document.get_Layer(0, 0);
                    layer3 = (IGeoFeatureLayer)layer2;
                    renderer = layer3.Renderer;
                    (pFeatureLayer as IGeoFeatureLayer).Renderer = layer3.Renderer;
                }
                document.Close();
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "GXFormMainFrame.FormMainEdit", "SetLayerRenderer", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void SetLegend(ILegend mapSurround)
        {
            try
            {
                int num;
                ILegend legend = mapSurround;
                if (legend.ItemCount == 0)
                {
                    legend.Refresh();
                }
                string str = "";
                if (base.MapControlEdit.Map.Name.Contains("造林"))
                {
                    str = "ZaoLin";
                }
                else if (base.MapControlEdit.Map.Name.Contains("采伐"))
                {
                    str = "CaiFa";
                }
                else if (base.MapControlEdit.Map.Name.Contains("火灾"))
                {
                    str = "Fire";
                }
                else if (base.MapControlEdit.Map.Name.Contains("征占用"))
                {
                    str = "ZZY";
                }
                else if (base.MapControlEdit.Map.Name.Contains("灾害"))
                {
                    str = "ZRZH";
                }
                else if (base.MapControlEdit.Map.Name.Contains("案件"))
                {
                    str = "AnJian";
                }
                else if (base.MapControlEdit.Map.Name.Contains("变更小班"))
                {
                    str = "XB";
                }
                else if (base.MapControlEdit.Map.Name.Contains("小班"))
                {
                    str = "XB2";
                }
                else if (base.MapControlEdit.Map.Name.Contains("遥感"))
                {
                    str = "YG";
                }
                string configValue = UtilFactory.GetConfigOpt().GetConfigValue("LegendLayer");
                string[] strArray = UtilFactory.GetConfigOpt().GetConfigValue(str + "LegendLayer").Split(new char[] { ',' });
                string[] strArray2 = UtilFactory.GetConfigOpt().GetConfigValue(str + "LegendLayerNewColumn").Split(new char[] { ',' });
                string[] strArray3 = UtilFactory.GetConfigOpt().GetConfigValue(str + "LegendLayerNewColumn").Split(new char[] { '1' });
                ArrayList list = new ArrayList();
                for (num = 0; num < strArray.Length; num++)
                {
                    bool flag = false;
                    for (int i = 0; i < legend.ItemCount; i++)
                    {
                        if (legend.get_Item(i).Layer.Name == strArray[num])
                        {
                            list.Add(legend.get_Item(i));
                            if (strArray2[num] == "0")
                            {
                                legend.get_Item(num).NewColumn = false;
                            }
                            else if (strArray2[num] == "1")
                            {
                                legend.get_Item(num).NewColumn = true;
                            }
                            flag = true;
                            break;
                        }
                    }
                }
                if (list.Count > 0)
                {
                    legend.ClearItems();
                    for (num = 0; num < list.Count; num++)
                    {
                        ILegendItem item = list[num] as ILegendItem;
                        legend.AddItem(list[num] as ILegendItem);
                    }
                }
                legend.AutoReorder = false;
                legend.AutoVisibility = false;
                int itemCount = legend.ItemCount;
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "GXFormMainFrame.FormMainEdit", "SetLegend", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
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
                IMapFrame frame = null;
                ILegend mapSurround = null;
                IElement element = graphicsContainer.Next();
                while (element != null)
                {
                    if (element is IMapFrame)
                    {
                        frame = (IMapFrame)element;
                    }
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
                                        element5.Text = EditTask.TaskYear + "年" + distName + this.mEditKind + "专题图";
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
                    else if (element is IFrameElement)
                    {
                        IFrameElement element6 = element as IFrameElement;
                        if (element6 is IMapSurroundFrame)
                        {
                            IMapSurroundFrame frame2 = element6 as IMapSurroundFrame;
                            IMapSurround surround = frame2.MapSurround;
                            if (surround is ILegend)
                            {
                                mapSurround = surround as ILegend;
                            }
                        }
                    }
                    element = graphicsContainer.Next();
                }
                if (mapSurround != null)
                {
                    mapSurround.Map = frame.Map;
                    this.SetLegend(mapSurround);
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "GXFormMainFrame.FormMainEdit", "SetPageLayoutValues", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
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
        private PathManager PathManager
        {
            get
            {
                return DBServiceFactory<PathManager>.Service;
            }
        }
        private void StatusBar_MouseMove(object sender, MouseEventArgs e)
        {
            base.ribbon.SetPopupContextMenu(this, null);
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
            this.MouseOn = false;
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

        private void userControlDesignList1simpleButtonOpen_Click(object sender, EventArgs e)
        {
            this.userControlDesignList1.ButtonOpenClick(true);
            if (this.userControlDesignList1.simpleButtonOpen.Text == "关闭")
            {
                this.OpenDesign();
                this.m_project = this.userControlDesignList1.m_curProject;
            }
            else if (this.userControlDesignList1.simpleButtonOpen.Text == "打开")
            {
                this.CloseDesign();
                this.m_project = null;
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

        private void userControlProjectList1simpleButtonOpen_Click(object sender, EventArgs e)
        {
            this.userControlProjectList1.ButtonOpenClick();
            if (this.userControlProjectList1.simpleButtonOpen.Text == "关闭")
            {
                this.OpenZZYProject();
            }
            else if (this.userControlProjectList1.simpleButtonOpen.Text == "打开")
            {
                this.CloseZZYProject();
            }
        }

        private void userControls_MouseMove(object sender, MouseEventArgs e)
        {
            this.MouseOn = false;
            base.ribbon.SetPopupContextMenu(this, null);
        }

        private void userControlXBSet21simpleButtonCancel_Click(object sender, EventArgs e)
        {
            this.userControlXBSet21.panelIDList.Visible = false;
            this.splitterControl1.Visible = false;
            this.userControlXBSet21.tListKind.Height = 0xe4;
            this.userControlXBSet21.simpleButtonOK.Visible = true;
            this.userControlXBSet21.panel6.Dock = DockStyle.Top;
            this.userControlXBSet21.simpleButtonCancel.Enabled = false;
            this.userControlXBSet21.simpleButtonFinish.Visible = false;
            this.userControlXBSet21.EditFlag = false;
            this.userControlXBSet21.StartFlag = false;
            IWorkspaceEdit editWorkspace = EditTask.EditWorkspace as IWorkspaceEdit;
            if (((TaskManageClass.TaskState.ToString() == TaskState.Open.ToString()) && editWorkspace.IsBeingEdited()) && Editor.UniqueInstance.IsBeingEdited)
            {
                Editor.UniqueInstance.StopEdit();
            }
            this.barButtonItemInputZT.Enabled = true;
            this.barButtonItemXBEdit.Enabled = true;
            this.barButtonItemArea.Enabled = true;
            this.barButtonItemXJ.Enabled = true;
            this.barButtonItemLinZu.Enabled = true;
            this.barButtonItemCreateByPolygon.Enabled = false;
            this.barButtonItemCreateByPolygon2.Enabled = false;
            this.barButtonItemSmoothPolygon.Enabled = false;
            this.barButtonItemPropertyByXB.Enabled = false;
            this.barButtonItemInputPropertyList.Enabled = false;
            this.barButtonItemSaveEdit.Enabled = false;
            if (EditTask.KindCode.Length == 4)
            {
                //  IDBAccess dBAccess = UtilFactory.GetDBAccess("Access");
                string sCmdText = "update T_EditTask set EditState='1' where ID= " + int.Parse(EditTask.KindCode.Substring(2, 2));
                //    dBAccess.ExecuteScalar(sCmdText);
                this.userControlXBSet21.InitialValue();
            }
        }

        private void userControlXBSet21simpleButtonFinish_Click(object sender, EventArgs e)
        {
            this.userControlXBSet21.panelIDList.Visible = false;
            this.splitterControl1.Visible = false;
            this.userControlXBSet21.tListKind.Height = 0xe4;
            this.userControlXBSet21.simpleButtonOK.Visible = true;
            this.userControlXBSet21.panel6.Dock = DockStyle.Top;
            this.userControlXBSet21.simpleButtonCancel.Enabled = false;
            this.userControlXBSet21.simpleButtonFinish.Visible = false;
            this.userControlXBSet21.EditFlag = false;
            this.userControlXBSet21.StartFlag = false;
            IWorkspaceEdit editWorkspace = EditTask.EditWorkspace as IWorkspaceEdit;
            if (((TaskManageClass.TaskState.ToString() == TaskState.Open.ToString()) && editWorkspace.IsBeingEdited()) && Editor.UniqueInstance.IsBeingEdited)
            {
                Editor.UniqueInstance.StopEdit();
            }
            this.barButtonItemInputZT.Enabled = true;
            this.barButtonItemXBEdit.Enabled = true;
            this.barButtonItemArea.Enabled = true;
            this.barButtonItemXJ.Enabled = true;
            this.barButtonItemLinZu.Enabled = true;
            this.barButtonItemCreateByPolygon.Enabled = false;
            this.barButtonItemCreateByPolygon2.Enabled = false;
            this.barButtonItemSmoothPolygon.Enabled = false;
            this.barButtonItemPropertyByXB.Enabled = false;
            this.barButtonItemInputPropertyList.Enabled = false;
            this.barButtonItemSaveEdit.Enabled = false;
            if (EditTask.KindCode.Length == 4)
            {
                // IDBAccess dBAccess = UtilFactory.GetDBAccess("Access");
                string sCmdText = "update T_EditTask set EditState='2' where ID= " + int.Parse(EditTask.KindCode.Substring(2, 2));
                //   dBAccess.ExecuteScalar(sCmdText);
                this.userControlXBSet21.InitialValue();
            }
        }

        private void userControlXBSet21simpleButtonOK_Click(object sender, EventArgs e)
        {
            this.userControlXBSet21.panel6.Dock = DockStyle.Bottom;
            this.userControlXBSet21.panelIDList.Visible = true;
            this.userControlXBSet21.splitterControl1.Visible = true;
            this.userControlXBSet21.StartFlag = true;
            this.InitializeBaseButtonEdit();
            this.InitializeBaseButtonPage();
            this.SetButtonVisible();
            base.xtraTabToolbox.SelectedTabPageIndex = this.xtraTabPageXBchange.TabIndex;
            this.barButtonItemInputZT.Enabled = false;
            this.barButtonItemInputYG.Enabled = false;
            this.barButtonItemInputDC.Enabled = false;
            this.barButtonItemInputOther.Enabled = false;
            this.barButtonItemLayerCombine.Enabled = false;
            this.barButtonItemXBEdit.Enabled = false;
            this.barButtonItemArea.Enabled = false;
            this.barButtonItemXJ.Enabled = false;
            this.barButtonItemLinZu.Enabled = false;
            this.barButtonItemCreateByPolygon.Enabled = true;
            this.barButtonItemCreateByPolygon2.Enabled = true;
            this.barButtonItemSmoothPolygon.Enabled = true;
            this.barButtonItemPropertyByXB.Enabled = true;
            this.barButtonItemInputPropertyList.Enabled = true;
            this.barButtonItemSaveEdit.Enabled = true;
            if (EditTask.KindCode.Length == 4)
            {
                //  IDBAccess dBAccess = UtilFactory.GetDBAccess("Access");
                string sCmdText = "update T_EditTask set EditState='1' where ID= " + int.Parse(EditTask.KindCode.Substring(2, 2));
                //  dBAccess.ExecuteScalar(sCmdText);
            }
        }

        private void xtraTabMain_MouseMove(object sender, MouseEventArgs e)
        {
            base.ribbon.SetPopupContextMenu(this, null);
        }

        private void xtraTabMain_Resize(object sender, EventArgs e)
        {
            //20170501 jiayp 窗体最大最小化会导致地图消失
            if (base.xtraTabMain.Width == 0)
            {
                return;
            }
            if (base.xtraTabMain.SelectedTabPageIndex == 0)
            {
                base.MapControlEdit.BringToFront();
                base.MapControlEdit.Dock = DockStyle.None;
                base.MapControlEdit.Left = 1;
                base.MapControlEdit.Top = 1;
                base.MapControlEdit.Width = base.xtraTabMain.Width - 2;
                base.MapControlEdit.Height = base.xtraTabMain.Height - 30;
                base.MapControlEdit.ShowScrollbars = false;
                base.MapControlEdit.Height = base.xtraTabMain.Height - 0x18;
                base.PageLayoutControlEdit.Dock = DockStyle.None;
                base.PageLayoutControlEdit.Left = 1;
                base.PageLayoutControlEdit.Top = 1;
                base.PageLayoutControlEdit.Width = base.xtraTabMain.Width - 2;
                base.PageLayoutControlEdit.Height = base.xtraTabMain.Height - 30;
                base.PageLayoutControlEdit.Height = base.xtraTabMain.Height - 0x18;
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
                base.MapControlEdit.Height = base.xtraTabMain.Height - 0x18;
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
                        if (((base.ribbon.SelectedPage != base.ribbonPageQuery) && (base.ribbon.SelectedPage != base.ribbonPageDataEdit)) && (base.ribbon.SelectedPage != base.ribbonPageCheck))
                        {
                            base.ribbon.SelectedPage = base.ribbonPageDataEdit;
                        }
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
                        int selectedTabPageIndex = this.xtraTabControlEdit.SelectedTabPageIndex;
                        if (selectedTabPageIndex > -1)
                        {
                            this.xtraTabControlEdit.TabPages[selectedTabPageIndex].PageVisible = true;
                            base.dockPanelEdit.Visibility = DockVisibility.Visible;
                        }
                        int width = 0;
                        if (base.dockPanelToolbox.Visibility == DockVisibility.Visible)
                        {
                            width = base.dockPanelToolbox.Width;
                        }
                        base.MapControlEdit.BringToFront();
                        base.MapControlEdit.Dock = DockStyle.None;
                        base.MapControlEdit.Left = 1;
                        base.MapControlEdit.Top = 1;
                        base.MapControlEdit.Width = base.xtraTabMain.Width - 2;
                        base.MapControlEdit.Height = base.xtraTabMain.Height - 0x20;
                        base.MapControlEdit.ShowScrollbars = false;
                        base.MapControlEdit.Height = base.xtraTabMain.Height - 0x18;
                    }
                    else if (base.xtraTabMain.SelectedTabPageIndex == 1)
                    {
                        int num4;
                        bool flag = false;
                        ArrayList list = new ArrayList();
                        ArrayList list2 = new ArrayList();
                        if (base.MapControlEdit.Map.SelectionCount > 0)
                        {
                            flag = true;
                            ArrayList selectionLayerCollection = this.GetSelectionLayerCollection(base.MapControlEdit.Map);
                            for (num4 = 0; num4 < selectionLayerCollection.Count; num4++)
                            {
                                ILayer layer = selectionLayerCollection[num4] as ILayer;
                                IFeatureSelection selection = layer as IFeatureSelection;
                                ISelectionSet selectionSet = selection.SelectionSet;
                                ICursor cursor = null;
                                selectionSet.Search(null, false, out cursor);
                                IFeatureCursor cursor2 = cursor as IFeatureCursor;
                                for (IFeature feature = cursor2.NextFeature(); feature != null; feature = cursor2.NextFeature())
                                {
                                    list.Add(feature);
                                    list2.Add(layer);
                                }
                            }
                        }
                        if (Editor.UniqueInstance.IsBeingEdited)
                        {
                            Editor.UniqueInstance.StopEdit();
                            Editor.UniqueInstance.StartEdit(Editor.UniqueInstance.Workspace, Editor.UniqueInstance.Map);
                        }
                        base.ribbon.SelectedPage = base.ribbonPageGraphics;
                        base.dockPanelEdit.Visibility = DockVisibility.Hidden;
                        base.PageLayoutControlEdit.Dock = DockStyle.None;
                        base.PageLayoutControlEdit.Left = 1;
                        base.PageLayoutControlEdit.Top = 1;
                        base.PageLayoutControlEdit.Width = base.xtraTabMain.Width - 2;
                        base.PageLayoutControlEdit.Height = base.xtraTabMain.Height - 0x20;
                        base.PageLayoutControlEdit.Height = base.xtraTabMain.Height - 0x18;
                        base.dockPanelBottom.Visibility = DockVisibility.Hidden;
                        if (((list.Count > 0) && (list2.Count > 0)) && (list.Count == list2.Count))
                        {
                            for (num4 = 0; num4 < list2.Count; num4++)
                            {
                                base.MapControlEdit.Map.SelectFeature(list2[num4] as ILayer, list[num4] as IFeature);
                            }
                        }
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
                        envelope.Expand(1.1, 1.1, true);
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
                    if (pGeometry.SpatialReference != pMap.SpatialReference)
                    {
                        pGeometry.Project(pMap.SpatialReference);
                        pGeometry.SpatialReference = pMap.SpatialReference;
                    }
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
                        envelope.Expand(1.2, 1.2, true);
                    }
                    view.FullExtent = envelope;
                    view.Refresh();
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "GXFormMainFrame.FormMainEdit", "ZoomToGeometry", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }
    }
}

