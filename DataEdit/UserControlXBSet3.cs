namespace DataEdit
{
    using DevExpress.Utils;
    using DevExpress.XtraBars.Docking;
    using DevExpress.XtraEditors;
    using DevExpress.XtraEditors.Controls;
    using DevExpress.XtraEditors.Repository;
    using DevExpress.XtraTab;
    using DevExpress.XtraTreeList;
    using DevExpress.XtraTreeList.Columns;
    using DevExpress.XtraTreeList.Nodes;
    using ESRI.ArcGIS.Carto;
    using ESRI.ArcGIS.Controls;
    using ESRI.ArcGIS.Geodatabase;
    using FormBase;
    using FunFactory;
    using QueryCommon;
    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Windows.Forms;
    using TaskManage;
    using Utilities;

    public class UserControlXBSet3 : UserControlBase1
    {
        private int column = -1;
        private int columnlist = -1;
        private int columnlist2 = -1;
        private IContainer components = null;
        private DevExpress.Utils.ImageCollection imageCollection1;
        private DevExpress.Utils.ImageCollection imageCollection2;
        private DevExpress.Utils.ImageCollection imageCollection3;
        internal ImageList imageList0;
        internal ImageList ImageList1;
        internal ImageList imageList2;
        internal ImageList imageList3;
        private ImageList imageList4;
        private ImageList imageList5;
        internal ImageList imageList6;
        internal ImageList imageList7;
        private ImageList imageList8;
        private Label labelIdentify;
        private Label labelprogress;
        private Label labelXBInfo;
        private IFeatureLayer m_CountyLayer;
        private ITable m_CountyTable;
        private IFeatureLayer m_EditLayer;
        private IFeatureLayer m_QueryLayer;
        private ITable m_QueryTable;
        private IFeatureLayer m_TownLayer;
        private ITable m_TownTable;
        private IFeatureLayer m_UnderLayer;
        private IFeatureLayer m_VillageLayer;
        private ITable m_VillageTable;
        private IActiveViewEvents_Event mActiveViewEvents;
        private const string mClassName = "DataEdit.UserControlXBSet3";
        private RepositoryItemImageEdit mCurItemImageEdit;
        private RepositoryItemImageEdit mCurItemImageEdit0;
        private RepositoryItemImageEdit mCurItemImageEdit2;
        private RepositoryItemImageEdit mCurItemImageEdit22;
        private RepositoryItemImageEdit mCurItemImageEdit4;
        private RepositoryItemImageEdit mCurItemImageEdit5;
        private RepositoryItemImageEdit mCurItemImageEdit6;
        private RepositoryItemImageEdit mCurItemImageEdit7;
        private RepositoryItemImageEdit mCurItemImageEdit8;
       
        private DockPanel mDockPanel;
        private string mEditKindCode;
        private ErrorOpt mErrOpt = UtilFactory.GetErrorOpt();
        private ArrayList mFeatureList;
        private ArrayList mFeatureList2;
        private IFeatureWorkspace mFeatureWorkspace;
        private DataTable mFieldTable;
        private IHookHelper mHookHelper;
        private DataTable mKindTable;
        private TreeListNode mNode;
        private TreeListNode mNode2;
        private TreeListNode mNode3;
        private TreeListNode mNodeList;
        private TreeListNode mNodeList2;
        private ArrayList mQueryList = null;
        private UserControlQueryResult mQueryResult;
        private UserControlQueryResult mQueryResult2;
        private bool mSelected;
        private DataTable mStateTable;
        private string mSubSysName = UtilFactory.GetConfigOpt().GetSystemName();
        private DataTable mZTtable;
        private Panel panel2;
        private PanelControl panelControl1;
        public Panel panelIDList;
        private Panel panelInfo;
        private Panel panelLog;
        private RepositoryItemImageEdit repositoryItemImageEdit1;
        private RepositoryItemImageEdit repositoryItemImageEdit6;
        private RepositoryItemImageEdit repositoryItemImageEdit7;
        private RepositoryItemImageEdit repositoryItemImageEdit8;
        private RichTextBox richTextBox;
        private string sDesKeyField;
        private SimpleButton simpleButtonInfo;
        private SimpleButton simpleButtonRefresh;
        private TreeList tList;
        private TreeList tList2;
        private TreeListColumn tListCol1;
        private TreeListColumn tListCol2;
        private TreeListColumn tListCol3;
        private TreeListColumn tListCol4;
        private TreeListColumn tListCol5;
        private TreeListColumn tListCol6;
        private TreeListColumn tListCol7;
        private TreeListColumn tListCol8;
        private TreeListColumn treeListColumn11;
        private TreeListColumn treeListColumn12;
        private TreeListColumn treeListColumn13;
        private TreeListColumn treeListColumn14;
        private TreeListColumn treeListColumn15;
        private TreeListColumn treeListColumn16;
        private XtraTabControl xtraTabControl1;
        private XtraTabPage xtraTabPage1;
        private XtraTabPage xtraTabPage2;

        public UserControlXBSet3()
        {
            this.InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private string GetFiledValue(int index, IFeature pf)
        {
            string str2;
            string str = "";
            try
            {
                if (index == -1)
                {
                    return "";
                }
                IField field = pf.Fields.get_Field(index);
                str = pf.get_Value(index).ToString();
                if ((field.Domain != null) && (field.Domain.Type == esriDomainType.esriDTCodedValue))
                {
                    str = "";
                    try
                    {
                        ICodedValueDomain domain = (ICodedValueDomain) field.Domain;
                        long num = Convert.ToInt64(pf.get_Value(index));
                        for (int i = 0; i < domain.CodeCount; i++)
                        {
                            if (num == Convert.ToInt64(domain.get_Value(i)))
                            {
                                str = domain.get_Name(i);
                                goto Label_00E9;
                            }
                        }
                    }
                    catch (Exception)
                    {
                        str = pf.get_Value(index).ToString();
                    }
                }
                else
                {
                    str = pf.get_Value(index).ToString();
                }
            Label_00E9:
                str2 = str;
            }
            catch (Exception)
            {
                str2 = str;
            }
            return str2;
        }

        private void GetXBInfo()
        {
            try
            {
                this.panelInfo.Height = 0x88;
                string name = "BHYY";
                string str2 = "DT_SRC";
                int num = this.m_EditLayer.FeatureClass.FeatureCount(null);
                this.labelXBInfo.Text = "已有变更小班 共计" + num + "个";
                IQueryFilter queryFilter = new QueryFilterClass();
                int num2 = 0;
                queryFilter.WhereClause = name + " is not null and " + name + "<>'' ";
                num2 = this.m_EditLayer.FeatureClass.FeatureCount(queryFilter);
                this.labelXBInfo.Text = string.Concat(new object[] { this.labelXBInfo.Text, ",已确定变化原因", num2, "个" });
                queryFilter.WhereClause = name + " is null or " + name + "='' ";
                num2 = this.m_EditLayer.FeatureClass.FeatureCount(queryFilter);
                this.labelXBInfo.Text = string.Concat(new object[] { this.labelXBInfo.Text, ",未确定变化原因", num2, "个" });
                string configValue = "";
                configValue = UtilFactory.GetConfigOpt().GetConfigValue("YGFieldName");
                queryFilter.WhereClause = name + " is not null and " + name + "<>'' and (" + configValue + " is null or " + configValue + " ='') and " + str2 + " < '08'";
                num2 = this.m_EditLayer.FeatureClass.FeatureCount(queryFilter);
                this.labelXBInfo.Text = string.Concat(new object[] { this.labelXBInfo.Text, "\r\n六专题导入班块", num2, "个" });
                queryFilter.WhereClause = str2 + " = '01' and " + name + "<>'' and (" + configValue + " is null or " + configValue + " ='') ";
                num2 = this.m_EditLayer.FeatureClass.FeatureCount(queryFilter);
                this.labelXBInfo.Text = string.Concat(new object[] { this.labelXBInfo.Text, "(其中数据来源为造林专题的", num2, "个" });
                queryFilter.WhereClause = str2 + " = '02' and " + name + "<>'' and (" + configValue + " is null or " + configValue + " ='') ";
                num2 = this.m_EditLayer.FeatureClass.FeatureCount(queryFilter);
                this.labelXBInfo.Text = string.Concat(new object[] { this.labelXBInfo.Text, ",数据来源为采伐专题的", num2, "个" });
                queryFilter.WhereClause = str2 + " = '03' and " + name + "<>'' and (" + configValue + " is null or " + configValue + " ='') ";
                num2 = this.m_EditLayer.FeatureClass.FeatureCount(queryFilter);
                this.labelXBInfo.Text = string.Concat(new object[] { this.labelXBInfo.Text, ",数据来源为火灾专题的", num2, "个" });
                queryFilter.WhereClause = str2 + " = '04' and " + name + "<>'' and (" + configValue + " is null or " + configValue + " ='') ";
                num2 = this.m_EditLayer.FeatureClass.FeatureCount(queryFilter);
                this.labelXBInfo.Text = string.Concat(new object[] { this.labelXBInfo.Text, ",数据来源为征占用专题的", num2, "个" });
                queryFilter.WhereClause = str2 + " = '05' and " + name + "<>'' and (" + configValue + " is null or " + configValue + " ='') ";
                num2 = this.m_EditLayer.FeatureClass.FeatureCount(queryFilter);
                this.labelXBInfo.Text = string.Concat(new object[] { this.labelXBInfo.Text, ",数据来源为灾害专题的", num2, "个" });
                queryFilter.WhereClause = str2 + " = '07' and " + name + "<>'' and (" + configValue + " is null or " + configValue + " ='') ";
                num2 = this.m_EditLayer.FeatureClass.FeatureCount(queryFilter);
                this.labelXBInfo.Text = string.Concat(new object[] { this.labelXBInfo.Text, ",数据来源为案件专题的", num2, "个" });
                this.labelXBInfo.Text = this.labelXBInfo.Text + ")";
                configValue = UtilFactory.GetConfigOpt().GetConfigValue("YGFieldName");
                int num3 = this.m_EditLayer.FeatureClass.Fields.FindField(configValue);
                queryFilter.WhereClause = configValue + " <> '' and " + str2 + " = '99'";
                num2 = this.m_EditLayer.FeatureClass.FeatureCount(queryFilter);
                this.labelXBInfo.Text = string.Concat(new object[] { this.labelXBInfo.Text, "\r\n遥感判读导入班块", num2, "个" });
                int num4 = this.m_EditLayer.FeatureClass.Fields.FindField(name);
                queryFilter.WhereClause = str2 + " = '88'";
                num2 = this.m_EditLayer.FeatureClass.FeatureCount(queryFilter);
                this.labelXBInfo.Text = string.Concat(new object[] { this.labelXBInfo.Text, "\r\n公益林导入班块", num2, "个" });
                this.panelInfo.Height = 0xa6;
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlXBSet3", "GetXBInfo", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        public void Hook(object hook, IFeatureLayer pEditFLayer, UserControlQueryResult pResult, UserControlQueryResult pResult2, DockPanel pDockPanel)
        {
            try
            {
                this.m_EditLayer = pEditFLayer;
                this.mQueryResult = pResult;
                this.mQueryResult2 = pResult2;
                this.mDockPanel = pDockPanel;
                if (hook != null)
                {
                    this.mHookHelper = new HookHelperClass();
                    this.mHookHelper.Hook = hook;
                    if (this.mHookHelper.FocusMap != null)
                    {
                        this.mActiveViewEvents = this.mHookHelper.FocusMap as IActiveViewEvents_Event;
                    }
                    this.InitialValue();
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlXBSet3", "Hook", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void InitializeComponent()
        {
            this.components = new Container();
            ComponentResourceManager resources = new ComponentResourceManager(typeof(UserControlXBSet3));
            SuperToolTip tip = new SuperToolTip();
            ToolTipItem item = new ToolTipItem();
            SuperToolTip tip2 = new SuperToolTip();
            ToolTipItem item2 = new ToolTipItem();
            SuperToolTip tip3 = new SuperToolTip();
            ToolTipItem item3 = new ToolTipItem();
            SuperToolTip tip4 = new SuperToolTip();
            ToolTipItem item4 = new ToolTipItem();
            this.ImageList1 = new ImageList(this.components);
            this.imageList5 = new ImageList(this.components);
            this.imageCollection1 = new DevExpress.Utils.ImageCollection(this.components);
            this.imageCollection2 = new DevExpress.Utils.ImageCollection(this.components);
            this.imageList2 = new ImageList(this.components);
            this.imageList3 = new ImageList(this.components);
            this.imageList4 = new ImageList(this.components);
            this.imageList6 = new ImageList(this.components);
            this.imageList0 = new ImageList(this.components);
            this.imageList7 = new ImageList(this.components);
            this.imageList8 = new ImageList(this.components);
            this.imageCollection3 = new DevExpress.Utils.ImageCollection(this.components);
            this.panelIDList = new Panel();
            this.simpleButtonRefresh = new SimpleButton();
            this.simpleButtonInfo = new SimpleButton();
            this.xtraTabControl1 = new XtraTabControl();
            this.xtraTabPage1 = new XtraTabPage();
            this.tList = new TreeList();
            this.tListCol1 = new TreeListColumn();
            this.tListCol2 = new TreeListColumn();
            this.tListCol3 = new TreeListColumn();
            this.tListCol4 = new TreeListColumn();
            this.tListCol5 = new TreeListColumn();
            this.tListCol6 = new TreeListColumn();
            this.tListCol7 = new TreeListColumn();
            this.tListCol8 = new TreeListColumn();
            this.repositoryItemImageEdit1 = new RepositoryItemImageEdit();
            this.repositoryItemImageEdit6 = new RepositoryItemImageEdit();
            this.repositoryItemImageEdit7 = new RepositoryItemImageEdit();
            this.xtraTabPage2 = new XtraTabPage();
            this.tList2 = new TreeList();
            this.treeListColumn11 = new TreeListColumn();
            this.treeListColumn12 = new TreeListColumn();
            this.treeListColumn13 = new TreeListColumn();
            this.treeListColumn14 = new TreeListColumn();
            this.treeListColumn15 = new TreeListColumn();
            this.treeListColumn16 = new TreeListColumn();
            this.repositoryItemImageEdit8 = new RepositoryItemImageEdit();
            this.panelLog = new Panel();
            this.panelControl1 = new PanelControl();
            this.richTextBox = new RichTextBox();
            this.panel2 = new Panel();
            this.labelprogress = new Label();
            this.labelIdentify = new Label();
            this.panelInfo = new Panel();
            this.labelXBInfo = new Label();
            this.imageCollection1.BeginInit();
            this.imageCollection2.BeginInit();
            this.imageCollection3.BeginInit();
            this.panelIDList.SuspendLayout();
            this.xtraTabControl1.BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
            this.tList.BeginInit();
            this.repositoryItemImageEdit1.BeginInit();
            this.repositoryItemImageEdit6.BeginInit();
            this.repositoryItemImageEdit7.BeginInit();
            this.xtraTabPage2.SuspendLayout();
            this.tList2.BeginInit();
            this.repositoryItemImageEdit8.BeginInit();
            this.panelLog.SuspendLayout();
            this.panelControl1.BeginInit();
            this.panelControl1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panelInfo.SuspendLayout();
            base.SuspendLayout();
            this.ImageList1.ImageStream = (ImageListStreamer) resources.GetObject("ImageList1.ImageStream");
            this.ImageList1.TransparentColor = Color.Transparent;
            this.ImageList1.Images.SetKeyName(0, "blank16.ico");
            this.ImageList1.Images.SetKeyName(1, "tick16.ico");
            this.ImageList1.Images.SetKeyName(2, "PART16.ICO");
            this.ImageList1.Images.SetKeyName(3, "");
            this.ImageList1.Images.SetKeyName(4, "(14,37).png");
            this.ImageList1.Images.SetKeyName(5, "");
            this.ImageList1.Images.SetKeyName(6, "");
            this.ImageList1.Images.SetKeyName(7, "");
            this.ImageList1.Images.SetKeyName(8, "");
            this.ImageList1.Images.SetKeyName(9, "");
            this.ImageList1.Images.SetKeyName(10, "");
            this.ImageList1.Images.SetKeyName(11, "");
            this.ImageList1.Images.SetKeyName(12, "");
            this.ImageList1.Images.SetKeyName(13, "");
            this.ImageList1.Images.SetKeyName(14, "");
            this.ImageList1.Images.SetKeyName(15, "");
            this.ImageList1.Images.SetKeyName(0x10, "(30,24).png");
            this.ImageList1.Images.SetKeyName(0x11, "(00,02).png");
            this.ImageList1.Images.SetKeyName(0x12, "(00,17).png");
            this.ImageList1.Images.SetKeyName(0x13, "(00,46).png");
            this.ImageList1.Images.SetKeyName(20, "(01,10).png");
            this.ImageList1.Images.SetKeyName(0x15, "(01,25).png");
            this.ImageList1.Images.SetKeyName(0x16, "(05,32).png");
            this.ImageList1.Images.SetKeyName(0x17, "(06,32).png");
            this.ImageList1.Images.SetKeyName(0x18, "(07,32).png");
            this.ImageList1.Images.SetKeyName(0x19, "(08,32).png");
            this.ImageList1.Images.SetKeyName(0x1a, "(08,36).png");
            this.ImageList1.Images.SetKeyName(0x1b, "(09,36).png");
            this.ImageList1.Images.SetKeyName(0x1c, "(10,26).png");
            this.ImageList1.Images.SetKeyName(0x1d, "(11,26).png");
            this.ImageList1.Images.SetKeyName(30, "(11,29).png");
            this.ImageList1.Images.SetKeyName(0x1f, "(12,29).png");
            this.ImageList1.Images.SetKeyName(0x20, "(11,32).png");
            this.ImageList1.Images.SetKeyName(0x21, "(11,36).png");
            this.ImageList1.Images.SetKeyName(0x22, "(13,32).png");
            this.ImageList1.Images.SetKeyName(0x23, "(19,31).png");
            this.ImageList1.Images.SetKeyName(0x24, "(22,18).png");
            this.ImageList1.Images.SetKeyName(0x25, "(25,27).png");
            this.ImageList1.Images.SetKeyName(0x26, "(29,43).png");
            this.ImageList1.Images.SetKeyName(0x27, "(30,14).png");
            this.ImageList1.Images.SetKeyName(40, "5.png");
            this.ImageList1.Images.SetKeyName(0x29, "10.png");
            this.ImageList1.Images.SetKeyName(0x2a, "11.png");
            this.ImageList1.Images.SetKeyName(0x2b, "16.png");
            this.ImageList1.Images.SetKeyName(0x2c, "17.png");
            this.ImageList1.Images.SetKeyName(0x2d, "18.png");
            this.ImageList1.Images.SetKeyName(0x2e, "19.png");
            this.ImageList1.Images.SetKeyName(0x2f, "20.png");
            this.ImageList1.Images.SetKeyName(0x30, "21.png");
            this.ImageList1.Images.SetKeyName(0x31, "22.png");
            this.ImageList1.Images.SetKeyName(50, "25.png");
            this.ImageList1.Images.SetKeyName(0x33, "31.png");
            this.ImageList1.Images.SetKeyName(0x34, "41.png");
            this.ImageList1.Images.SetKeyName(0x35, "add.png");
            this.ImageList1.Images.SetKeyName(0x36, "bullet_minus.png");
            this.ImageList1.Images.SetKeyName(0x37, "control_add_blue.png");
            this.ImageList1.Images.SetKeyName(0x38, "control_power_blue.png");
            this.ImageList1.Images.SetKeyName(0x39, "control_remove_blue.png");
            this.ImageList1.Images.SetKeyName(0x3a, "cross.png");
            this.ImageList1.Images.SetKeyName(0x3b, "down.png");
            this.ImageList1.Images.SetKeyName(60, "draw_tools.png");
            this.ImageList1.Images.SetKeyName(0x3d, "Feedicons_v2_010.png");
            this.ImageList1.Images.SetKeyName(0x3e, "Feedicons_v2_011.png");
            this.ImageList1.Images.SetKeyName(0x3f, "Feedicons_v2_031.png");
            this.ImageList1.Images.SetKeyName(0x40, "Feedicons_v2_032.png");
            this.ImageList1.Images.SetKeyName(0x41, "Feedicons_v2_033.png");
            this.ImageList1.Images.SetKeyName(0x42, "flag blue.png");
            this.ImageList1.Images.SetKeyName(0x43, "flag red.png");
            this.ImageList1.Images.SetKeyName(0x44, "flag yellow.png");
            this.ImageList1.Images.SetKeyName(0x45, "(44,23).png");
            this.ImageList1.Images.SetKeyName(70, "(12,29).png");
            this.ImageList1.Images.SetKeyName(0x47, "(34,00).png");
            this.ImageList1.Images.SetKeyName(0x48, "(03,02).png");
            this.ImageList1.Images.SetKeyName(0x49, "(49,06).png");
            this.ImageList1.Images.SetKeyName(0x4a, "(09,13).png");
            this.ImageList1.Images.SetKeyName(0x4b, "(16,47).png");
            this.ImageList1.Images.SetKeyName(0x4c, "(13,47).png");
            this.ImageList1.Images.SetKeyName(0x4d, "(18,01).png");
            this.ImageList1.Images.SetKeyName(0x4e, "(18,13).png");
            this.ImageList1.Images.SetKeyName(0x4f, "(19,01).png");
            this.ImageList1.Images.SetKeyName(80, "(28,40).png");
            this.ImageList1.Images.SetKeyName(0x51, "(39,47).png");
            this.ImageList1.Images.SetKeyName(0x52, "(45,12).png");
            this.ImageList1.Images.SetKeyName(0x53, "(45,17).png");
            this.ImageList1.Images.SetKeyName(0x54, "(45,41).png");
            this.ImageList1.Images.SetKeyName(0x55, "arrow_refresh_small.png");
            this.ImageList1.Images.SetKeyName(0x56, "(11,29).png");
            this.ImageList1.Images.SetKeyName(0x57, "(12,29).png");
            this.ImageList1.Images.SetKeyName(0x58, "(12,11).png");
            this.ImageList1.Images.SetKeyName(0x59, "(24,28).png");
            this.ImageList1.Images.SetKeyName(90, "");
            this.ImageList1.Images.SetKeyName(0x5b, "home_16.png");
            this.ImageList1.Images.SetKeyName(0x5c, "(00,41).png");
            this.imageList5.ImageStream = (ImageListStreamer) resources.GetObject("imageList5.ImageStream");
            this.imageList5.TransparentColor = Color.Transparent;
            this.imageList5.Images.SetKeyName(0, "170503292.gif");
            this.imageCollection1.ImageSize = new Size(0x20, 0x20);
            this.imageCollection1.ImageStream = (ImageCollectionStreamer) resources.GetObject("imageCollection1.ImageStream");
            this.imageCollection1.Images.SetKeyName(0, "document-open.png");
            this.imageCollection1.Images.SetKeyName(1, "lincity-ng.png");
            this.imageCollection1.Images.SetKeyName(2, "kde-folder-txt.png");
            this.imageCollection1.Images.SetKeyName(3, "old-go-home.png");
            this.imageCollection1.Images.SetKeyName(4, "go-home.png");
            this.imageCollection1.Images.SetKeyName(5, "stock_task-recurring.png");
            this.imageCollection1.Images.SetKeyName(6, "old-openofficeorg-math.png");
            this.imageCollection1.Images.SetKeyName(7, "okteta.png");
            this.imageCollection1.Images.SetKeyName(8, "gconfeditor.png");
            this.imageCollection1.Images.SetKeyName(9, "gddccontrol.png");
            this.imageCollection1.Images.SetKeyName(10, "gnome-klotski.png");
            this.imageCollection1.Images.SetKeyName(11, "layer.png");
            this.imageCollection1.Images.SetKeyName(12, "chart_bullseye.png");
            this.imageCollection1.Images.SetKeyName(13, "draw_polyline.png");
            this.imageCollection1.Images.SetKeyName(14, "large_tiles.png");
            this.imageCollection1.Images.SetKeyName(15, "layers2.png");
            this.imageCollection1.Images.SetKeyName(0x10, "small_tiles.png");
            this.imageCollection1.Images.SetKeyName(0x11, "layers.png");
            this.imageCollection1.Images.SetKeyName(0x12, "application_view_tile.png");
            this.imageCollection1.Images.SetKeyName(0x13, "chart_stock.png");
            this.imageCollection1.Images.SetKeyName(20, "preferences-desktop-theme.png");
            this.imageCollection1.Images.SetKeyName(0x15, "grass.png");
            this.imageCollection1.Images.SetKeyName(0x16, "house_one.png");
            this.imageCollection1.Images.SetKeyName(0x17, "plotchart.png");
            this.imageCollection1.Images.SetKeyName(0x18, "plugin_edit.png");
            this.imageCollection1.Images.SetKeyName(0x19, "illustration.png");
            this.imageCollection1.Images.SetKeyName(0x1a, "google_map.png");
            this.imageCollection1.Images.SetKeyName(0x1b, "color_swatches.png");
            this.imageCollection1.Images.SetKeyName(0x1c, "openofficeorg-draw.png");
            this.imageCollection1.Images.SetKeyName(0x1d, "green_wormhole.png");
            this.imageCollection1.Images.SetKeyName(30, "applix.png");
            this.imageCollection1.Images.SetKeyName(0x1f, "abiword.png");
            this.imageCollection1.Images.SetKeyName(0x20, "Text-Document.png");
            this.imageCollection1.Images.SetKeyName(0x21, "Xcode.png");
            this.imageCollection1.Images.SetKeyName(0x22, "Application.png");
            this.imageCollection1.Images.SetKeyName(0x23, "leaves.png");
            this.imageCollection1.Images.SetKeyName(0x24, "folder_edit.png");
            this.imageCollection1.Images.SetKeyName(0x25, "color_swatch.png");
            this.imageCollection1.Images.SetKeyName(0x26, "house.png");
            this.imageCollection1.Images.SetKeyName(0x27, "images.png");
            this.imageCollection1.Images.SetKeyName(40, "tree2.png");
            this.imageCollection1.Images.SetKeyName(0x29, "tree_1.png");
            this.imageCollection1.Images.SetKeyName(0x2a, "img-portrait-edit.png");
            this.imageCollection1.Images.SetKeyName(0x2b, "tree.png");
            this.imageCollection1.Images.SetKeyName(0x2c, "20071126112025469.png");
            this.imageCollection1.Images.SetKeyName(0x2d, "mb5u3_mb5ucom.png");
            this.imageCollection1.Images.SetKeyName(0x2e, "mb5u6_mb5ucom.png");
            this.imageCollection1.Images.SetKeyName(0x2f, "20071127000637768.png");
            this.imageCollection1.Images.SetKeyName(0x30, "sc0905281_3.png");
            this.imageCollection1.Images.SetKeyName(0x31, "sc0905281_4.png");
            this.imageCollection1.Images.SetKeyName(50, "20071127000640731.png");
            this.imageCollection1.Images.SetKeyName(0x33, "20071127112435759.png");
            this.imageCollection1.Images.SetKeyName(0x34, "20071206144123734.png");
            this.imageCollection1.Images.SetKeyName(0x35, "icontexto-green-01.png");
            this.imageCollection1.Images.SetKeyName(0x36, "fire.png");
            this.imageCollection1.Images.SetKeyName(0x37, "house.png");
            this.imageCollection1.Images.SetKeyName(0x38, "images.png");
            this.imageCollection1.Images.SetKeyName(0x39, "layers.png");
            this.imageCollection1.Images.SetKeyName(0x3a, "layers_map.png");
            this.imageCollection1.Images.SetKeyName(0x3b, "Plant.png");
            this.imageCollection1.Images.SetKeyName(60, "plugin_edit.png");
            this.imageCollection1.Images.SetKeyName(0x3d, "sun_rain.png");
            this.imageCollection1.Images.SetKeyName(0x3e, "tree.png");
            this.imageCollection1.Images.SetKeyName(0x3f, "weather_rain.png");
            this.imageCollection1.Images.SetKeyName(0x40, "weather_snow.png");
            this.imageCollection1.Images.SetKeyName(0x41, "widgets.png");
            this.imageCollection2.ImageStream = (ImageCollectionStreamer) resources.GetObject("imageCollection2.ImageStream");
            this.imageCollection2.Images.SetKeyName(0, "1259760497_color_swatch_2.png");
            this.imageCollection2.Images.SetKeyName(1, "arrow_circle_double.png");
            this.imageCollection2.Images.SetKeyName(2, "edit_16x16.gif");
            this.imageCollection2.Images.SetKeyName(3, "map.png");
            this.imageCollection2.Images.SetKeyName(4, "map_add2.png");
            this.imageCollection2.Images.SetKeyName(5, "map_delete.png");
            this.imageCollection2.Images.SetKeyName(6, "map_edit2.png");
            this.imageCollection2.Images.SetKeyName(7, "map_go.png");
            this.imageCollection2.Images.SetKeyName(8, "map_magnify2.png");
            this.imageCollection2.Images.SetKeyName(9, "map2.png");
            this.imageCollection2.Images.SetKeyName(10, "map4.png");
            this.imageCollection2.Images.SetKeyName(11, "map--arrow.png");
            this.imageCollection2.Images.SetKeyName(12, "map--minus.png");
            this.imageCollection2.Images.SetKeyName(13, "map--pencil.png");
            this.imageCollection2.Images.SetKeyName(14, "map-pin.png");
            this.imageCollection2.Images.SetKeyName(15, "map--plus.png");
            this.imageCollection2.Images.SetKeyName(0x10, "maps.png");
            this.imageCollection2.Images.SetKeyName(0x11, "maps--arrow.png");
            this.imageCollection2.Images.SetKeyName(0x12, "maps--exclamation.png");
            this.imageCollection2.Images.SetKeyName(0x13, "maps--minus.png");
            this.imageCollection2.Images.SetKeyName(20, "maps--pencil.png");
            this.imageCollection2.Images.SetKeyName(0x15, "maps--pencil2.png");
            this.imageCollection2.Images.SetKeyName(0x16, "maps--pencil3.png");
            this.imageCollection2.Images.SetKeyName(0x17, "maps--plus.png");
            this.imageCollection2.Images.SetKeyName(0x18, "maps-stack.png");
            this.imageCollection2.Images.SetKeyName(0x19, "pathing3.png");
            this.imageCollection2.Images.SetKeyName(0x1a, "picture_pencil.png");
            this.imageCollection2.Images.SetKeyName(0x1b, "table__arrow.png");
            this.imageCollection2.Images.SetKeyName(0x1c, "arrow_large_up.png");
            this.imageCollection2.Images.SetKeyName(0x1d, "web design_16_hot.png");
            this.imageCollection2.Images.SetKeyName(30, "ksirtet16.png");
            this.imageCollection2.Images.SetKeyName(0x1f, "node-select-child.png");
            this.imageCollection2.Images.SetKeyName(0x20, "flag blue.png");
            this.imageCollection2.Images.SetKeyName(0x21, "flag red.png");
            this.imageCollection2.Images.SetKeyName(0x22, "flag yellow.png");
            this.imageCollection2.Images.SetKeyName(0x23, "image.png");
            this.imageCollection2.Images.SetKeyName(0x24, "image_edit.png");
            this.imageCollection2.Images.SetKeyName(0x25, "image_magnify.png");
            this.imageCollection2.Images.SetKeyName(0x26, "page_edit.png");
            this.imageCollection2.Images.SetKeyName(0x27, "page_paintbrush.png");
            this.imageCollection2.Images.SetKeyName(40, "page_white_edit.png");
            this.imageCollection2.Images.SetKeyName(0x29, "pencil.png");
            this.imageCollection2.Images.SetKeyName(0x2a, "photo.png");
            this.imageCollection2.Images.SetKeyName(0x2b, "photos.png");
            this.imageCollection2.Images.SetKeyName(0x2c, "picture.png");
            this.imageCollection2.Images.SetKeyName(0x2d, "picture_add.png");
            this.imageCollection2.Images.SetKeyName(0x2e, "picture_delete.png");
            this.imageCollection2.Images.SetKeyName(0x2f, "picture_edit.png");
            this.imageCollection2.Images.SetKeyName(0x30, "search.gif");
            this.imageCollection2.Images.SetKeyName(0x31, "table.png");
            this.imageCollection2.Images.SetKeyName(50, "table_edit.png");
            this.imageCollection2.Images.SetKeyName(0x33, "(01,40).png");
            this.imageCollection2.Images.SetKeyName(0x34, "(01,46).png");
            this.imageCollection2.Images.SetKeyName(0x35, "(09,46).png");
            this.imageCollection2.Images.SetKeyName(0x36, "(12,11).png");
            this.imageCollection2.Images.SetKeyName(0x37, "(14,36).png");
            this.imageCollection2.Images.SetKeyName(0x38, "(14,37).png");
            this.imageCollection2.Images.SetKeyName(0x39, "(15,25).png");
            this.imageCollection2.Images.SetKeyName(0x3a, "(15,40).png");
            this.imageCollection2.Images.SetKeyName(0x3b, "(16,32).png");
            this.imageCollection2.Images.SetKeyName(60, "(17,49).png");
            this.imageCollection2.Images.SetKeyName(0x3d, "(19,01).png");
            this.imageCollection2.Images.SetKeyName(0x3e, "(24,04).png");
            this.imageCollection2.Images.SetKeyName(0x3f, "(24,32).png");
            this.imageCollection2.Images.SetKeyName(0x40, "(28,09).png");
            this.imageCollection2.Images.SetKeyName(0x41, "(29,04).png");
            this.imageCollection2.Images.SetKeyName(0x42, "(30,24).png");
            this.imageCollection2.Images.SetKeyName(0x43, "(32,04).png");
            this.imageCollection2.Images.SetKeyName(0x44, "(32,24).png");
            this.imageCollection2.Images.SetKeyName(0x45, "(33,14).png");
            this.imageCollection2.Images.SetKeyName(70, "(35,29).png");
            this.imageCollection2.Images.SetKeyName(0x47, "(35,31).png");
            this.imageCollection2.Images.SetKeyName(0x48, "(35,45).png");
            this.imageCollection2.Images.SetKeyName(0x49, "(36,04).png");
            this.imageCollection2.Images.SetKeyName(0x4a, "(36,47).png");
            this.imageCollection2.Images.SetKeyName(0x4b, "(39,47).png");
            this.imageCollection2.Images.SetKeyName(0x4c, "(40,05).png");
            this.imageCollection2.Images.SetKeyName(0x4d, "(44,27).png");
            this.imageCollection2.Images.SetKeyName(0x4e, "(45,28).png");
            this.imageCollection2.Images.SetKeyName(0x4f, "(49,06).png");
            this.imageCollection2.Images.SetKeyName(80, "(49,48).png");
            this.imageCollection2.Images.SetKeyName(0x51, "(15,49).png");
            this.imageCollection2.Images.SetKeyName(0x52, "(27,15).png");
            this.imageCollection2.Images.SetKeyName(0x53, "(00,41).png");
            this.imageCollection2.Images.SetKeyName(0x54, "(00,47).png");
            this.imageCollection2.Images.SetKeyName(0x55, "(02,10).png");
            this.imageCollection2.Images.SetKeyName(0x56, "(02,40).png");
            this.imageCollection2.Images.SetKeyName(0x57, "(03,18).png");
            this.imageCollection2.Images.SetKeyName(0x58, "(06,02).png");
            this.imageCollection2.Images.SetKeyName(0x59, "(08,40).png");
            this.imageCollection2.Images.SetKeyName(90, "(10,41).png");
            this.imageCollection2.Images.SetKeyName(0x5b, "(11,49).png");
            this.imageCollection2.Images.SetKeyName(0x5c, "(13,15).png");
            this.imageList2.ImageStream = (ImageListStreamer) resources.GetObject("imageList2.ImageStream");
            this.imageList2.TransparentColor = Color.Transparent;
            this.imageList2.Images.SetKeyName(0, "layers_map.png");
            this.imageList2.Images.SetKeyName(1, "(28,08).png");
            this.imageList2.Images.SetKeyName(2, "");
            this.imageList2.Images.SetKeyName(3, "(01,49).png");
            this.imageList2.Images.SetKeyName(4, "(18,13).png");
            this.imageList2.Images.SetKeyName(5, "(01,46).png");
            this.imageList2.Images.SetKeyName(6, "(05,49).png");
            this.imageList2.Images.SetKeyName(7, "(06,30).png");
            this.imageList2.Images.SetKeyName(8, "(07,30).png");
            this.imageList2.Images.SetKeyName(9, "(09,13).png");
            this.imageList2.Images.SetKeyName(10, "(09,24).png");
            this.imageList2.Images.SetKeyName(11, "(11,49).png");
            this.imageList2.Images.SetKeyName(12, "(18,29).png");
            this.imageList2.Images.SetKeyName(13, "(34,00).png");
            this.imageList2.Images.SetKeyName(14, "(47,25).png");
            this.imageList2.Images.SetKeyName(15, "(48,48).png");
            this.imageList3.ImageStream = (ImageListStreamer) resources.GetObject("imageList3.ImageStream");
            this.imageList3.TransparentColor = Color.Transparent;
            this.imageList3.Images.SetKeyName(0, "(04,42).png");
            this.imageList3.Images.SetKeyName(1, "(03,42).png");
            this.imageList3.Images.SetKeyName(2, "(01,46).png");
            this.imageList3.Images.SetKeyName(3, "(01,49).png");
            this.imageList3.Images.SetKeyName(4, "(02,27).png");
            this.imageList3.Images.SetKeyName(5, "(03,42).png");
            this.imageList4.ImageStream = (ImageListStreamer) resources.GetObject("imageList4.ImageStream");
            this.imageList4.TransparentColor = Color.Transparent;
            this.imageList4.Images.SetKeyName(0, "001_45.gif");
            this.imageList4.Images.SetKeyName(1, "001_38.gif");
            this.imageList4.Images.SetKeyName(2, "blue_view_24x24.gif");
            this.imageList4.Images.SetKeyName(3, "gtk-edit.png");
            this.imageList4.Images.SetKeyName(4, "ico6.gif");
            this.imageList6.ImageStream = (ImageListStreamer) resources.GetObject("imageList6.ImageStream");
            this.imageList6.TransparentColor = Color.Transparent;
            this.imageList6.Images.SetKeyName(0, "(03,42).png");
            this.imageList6.Images.SetKeyName(1, "(04,42).png");
            this.imageList6.Images.SetKeyName(2, "(01,46).png");
            this.imageList6.Images.SetKeyName(3, "(01,49).png");
            this.imageList6.Images.SetKeyName(4, "(02,27).png");
            this.imageList6.Images.SetKeyName(5, "(03,42).png");
            this.imageList0.ImageStream = (ImageListStreamer) resources.GetObject("imageList0.ImageStream");
            this.imageList0.TransparentColor = Color.Transparent;
            this.imageList0.Images.SetKeyName(0, "(01,49).png");
            this.imageList0.Images.SetKeyName(1, "");
            this.imageList0.Images.SetKeyName(2, "(18,13).png");
            this.imageList0.Images.SetKeyName(3, "(01,46).png");
            this.imageList0.Images.SetKeyName(4, "(05,49).png");
            this.imageList0.Images.SetKeyName(5, "(06,30).png");
            this.imageList0.Images.SetKeyName(6, "(07,30).png");
            this.imageList0.Images.SetKeyName(7, "(09,13).png");
            this.imageList0.Images.SetKeyName(8, "(09,24).png");
            this.imageList0.Images.SetKeyName(9, "(11,49).png");
            this.imageList0.Images.SetKeyName(10, "(18,29).png");
            this.imageList0.Images.SetKeyName(11, "(34,00).png");
            this.imageList0.Images.SetKeyName(12, "(47,25).png");
            this.imageList0.Images.SetKeyName(13, "(48,48).png");
            this.imageList7.ImageStream = (ImageListStreamer) resources.GetObject("imageList7.ImageStream");
            this.imageList7.TransparentColor = Color.Transparent;
            this.imageList7.Images.SetKeyName(0, "(01,49).png");
            this.imageList7.Images.SetKeyName(1, "(18,13).png");
            this.imageList7.Images.SetKeyName(2, "");
            this.imageList7.Images.SetKeyName(3, "(01,46).png");
            this.imageList7.Images.SetKeyName(4, "(05,49).png");
            this.imageList7.Images.SetKeyName(5, "(06,30).png");
            this.imageList7.Images.SetKeyName(6, "(07,30).png");
            this.imageList7.Images.SetKeyName(7, "(09,13).png");
            this.imageList7.Images.SetKeyName(8, "(09,24).png");
            this.imageList7.Images.SetKeyName(9, "(11,49).png");
            this.imageList7.Images.SetKeyName(10, "(18,29).png");
            this.imageList7.Images.SetKeyName(11, "(34,00).png");
            this.imageList7.Images.SetKeyName(12, "(47,25).png");
            this.imageList7.Images.SetKeyName(13, "(48,48).png");
            this.imageList8.ImageStream = (ImageListStreamer) resources.GetObject("imageList8.ImageStream");
            this.imageList8.TransparentColor = Color.Transparent;
            this.imageList8.Images.SetKeyName(0, "drawing_pen-24.png");
            this.imageList8.Images.SetKeyName(1, "misc_53.png");
            this.imageList8.Images.SetKeyName(2, "001_45.gif");
            this.imageList8.Images.SetKeyName(3, "icn_best.gif");
            this.imageList8.Images.SetKeyName(4, "001_38.gif");
            this.imageList8.Images.SetKeyName(5, "edit3.png");
            this.imageCollection3.ImageSize = new Size(0x18, 0x18);
            this.imageCollection3.ImageStream = (ImageCollectionStreamer) resources.GetObject("imageCollection3.ImageStream");
            this.imageCollection3.Images.SetKeyName(0, "001_45.gif");
            this.imageCollection3.Images.SetKeyName(1, "large_tiles.png");
            this.imageCollection3.Images.SetKeyName(2, "layers2.png");
            this.imageCollection3.Images.SetKeyName(3, "31.png");
            this.imageCollection3.Images.SetKeyName(4, "small_tiles.png");
            this.imageCollection3.Images.SetKeyName(5, "color-layers.png");
            this.imageCollection3.Images.SetKeyName(6, "Sync.png");
            this.imageCollection3.Images.SetKeyName(7, "fire5.png");
            this.imageCollection3.Images.SetKeyName(8, "widgets.png");
            this.imageCollection3.Images.SetKeyName(9, "gkdebconf-icon.png");
            this.imageCollection3.Images.SetKeyName(10, "openofficeorg-draw.png");
            this.imageCollection3.Images.SetKeyName(11, "fire3.png");
            this.imageCollection3.Images.SetKeyName(12, "green_wormhole.png");
            this.imageCollection3.Images.SetKeyName(13, "globe_download2.png");
            this.imageCollection3.Images.SetKeyName(14, "globe_process2.png");
            this.imageCollection3.Images.SetKeyName(15, "hot.png");
            this.imageCollection3.Images.SetKeyName(0x10, "kde-folder-development.png");
            this.imageCollection3.Images.SetKeyName(0x11, "image-svg.png");
            this.imageCollection3.Images.SetKeyName(0x12, "document-open.png");
            this.imageCollection3.Images.SetKeyName(0x13, "image-svg+xml.png");
            this.imageCollection3.Images.SetKeyName(20, "application-x-tgif.png");
            this.imageCollection3.Images.SetKeyName(0x15, "gnome-mime-application-vnd_oasis_opendocument_graphics-template.png");
            this.imageCollection3.Images.SetKeyName(0x16, "x-kde-nsplugin-generated.png");
            this.imageCollection3.Images.SetKeyName(0x17, "kde-folder-image.png");
            this.imageCollection3.Images.SetKeyName(0x18, "applications-accessories.png");
            this.imageCollection3.Images.SetKeyName(0x19, "application-x-krita.png");
            this.imageCollection3.Images.SetKeyName(0x1a, "preferences-certificates.png");
            this.imageCollection3.Images.SetKeyName(0x1b, "applications-utilities.png");
            this.imageCollection3.Images.SetKeyName(0x1c, "insert-image.png");
            this.imageCollection3.Images.SetKeyName(0x1d, "tomboy.png");
            this.imageCollection3.Images.SetKeyName(30, "Burn.png");
            this.imageCollection3.Images.SetKeyName(0x1f, "gtk-execute.png");
            this.imageCollection3.Images.SetKeyName(0x20, "images24.png");
            this.imageCollection3.Images.SetKeyName(0x21, "Application.png");
            this.imageCollection3.Images.SetKeyName(0x22, "ksirtet24.png");
            this.imageCollection3.Images.SetKeyName(0x23, "Notes.png");
            this.imageCollection3.Images.SetKeyName(0x24, "icontexto-green-01.png");
            this.imageCollection3.Images.SetKeyName(0x25, "tree_1.png");
            this.imageCollection3.Images.SetKeyName(0x26, "img-portrait-edit.png");
            this.imageCollection3.Images.SetKeyName(0x27, "20071126112025469.png");
            this.imageCollection3.Images.SetKeyName(40, "mb5u3_mb5ucom.png");
            this.imageCollection3.Images.SetKeyName(0x29, "sc0905281_3.png");
            this.imageCollection3.Images.SetKeyName(0x2a, "20071206144123734.png");
            this.imageCollection3.Images.SetKeyName(0x2b, "fire.png");
            this.imageCollection3.Images.SetKeyName(0x2c, "rain.png");
            this.imageCollection3.Images.SetKeyName(0x2d, "snow_rain.png");
            this.imageCollection3.Images.SetKeyName(0x2e, "sun_rain.png");
            this.imageCollection3.Images.SetKeyName(0x2f, "weather_snow.png");
            this.panelIDList.Controls.Add(this.simpleButtonRefresh);
            this.panelIDList.Controls.Add(this.simpleButtonInfo);
            this.panelIDList.Controls.Add(this.xtraTabControl1);
            this.panelIDList.Dock = DockStyle.Fill;
            this.panelIDList.Location = new Point(6, 0x7a);
            this.panelIDList.Name = "panelIDList";
            this.panelIDList.Padding = new Padding(0, 2, 0, 2);
            this.panelIDList.Size = new Size(0x10c, 0x174);
            this.panelIDList.TabIndex = 0x1d;
            this.simpleButtonRefresh.ImageIndex = 0x55;
            this.simpleButtonRefresh.ImageList = this.ImageList1;
            this.simpleButtonRefresh.ImageLocation = ImageLocation.MiddleLeft;
            this.simpleButtonRefresh.Location = new Point(0xa1, 3);
            this.simpleButtonRefresh.Name = "simpleButtonRefresh";
            this.simpleButtonRefresh.Size = new Size(50, 20);
            item.Text = "刷新列表";
            tip.Items.Add(item);
            this.simpleButtonRefresh.SuperTip = tip;
            this.simpleButtonRefresh.TabIndex = 4;
            this.simpleButtonRefresh.Text = "刷新";
            this.simpleButtonRefresh.Click += new EventHandler(this.simpleButtonRefresh_Click);
            this.simpleButtonInfo.ImageIndex = 4;
            this.simpleButtonInfo.ImageList = this.imageList2;
            this.simpleButtonInfo.ImageLocation = ImageLocation.MiddleLeft;
            this.simpleButtonInfo.Location = new Point(0xd7, 3);
            this.simpleButtonInfo.Name = "simpleButtonInfo";
            this.simpleButtonInfo.Size = new Size(50, 20);
            item2.Text = "详细信息";
            tip2.Items.Add(item2);
            this.simpleButtonInfo.SuperTip = tip2;
            this.simpleButtonInfo.TabIndex = 2;
            this.simpleButtonInfo.Text = "信息";
            this.simpleButtonInfo.Click += new EventHandler(this.simpleButtonInfo_Click);
            this.xtraTabControl1.Dock = DockStyle.Fill;
            this.xtraTabControl1.Location = new Point(0, 2);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.Padding = new Padding(4);
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPage1;
            this.xtraTabControl1.Size = new Size(0x10c, 0x170);
            this.xtraTabControl1.TabIndex = 0;
            this.xtraTabControl1.TabPages.AddRange(new XtraTabPage[] { this.xtraTabPage1, this.xtraTabPage2 });
            this.xtraTabPage1.Controls.Add(this.tList);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Padding = new Padding(4);
            this.xtraTabPage1.Size = new Size(0x107, 0x155);
            item3.Text = "未核实遥感变化班块";
            tip3.Items.Add(item3);
            this.xtraTabPage1.SuperTip = tip3;
            this.xtraTabPage1.Text = "未核实";
            this.tList.Appearance.FocusedCell.BackColor = Color.LightSkyBlue;
            this.tList.Appearance.FocusedCell.BackColor2 = Color.White;
            this.tList.Appearance.FocusedCell.ForeColor = Color.Blue;
            this.tList.Appearance.FocusedCell.Options.UseBackColor = true;
            this.tList.Appearance.FocusedCell.Options.UseForeColor = true;
            this.tList.Appearance.FocusedRow.BackColor = Color.LightSkyBlue;
            this.tList.Appearance.FocusedRow.BackColor2 = Color.White;
            this.tList.Appearance.FocusedRow.ForeColor = Color.Blue;
            this.tList.Appearance.FocusedRow.Options.UseBackColor = true;
            this.tList.Appearance.FocusedRow.Options.UseForeColor = true;
            this.tList.Appearance.HideSelectionRow.BackColor = Color.White;
            this.tList.Appearance.HideSelectionRow.BackColor2 = Color.White;
            this.tList.Appearance.HideSelectionRow.ForeColor = Color.Black;
            this.tList.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.tList.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.tList.Columns.AddRange(new TreeListColumn[] { this.tListCol1, this.tListCol2, this.tListCol3, this.tListCol4, this.tListCol5, this.tListCol6, this.tListCol7, this.tListCol8 });
            this.tList.Dock = DockStyle.Fill;
            this.tList.Location = new Point(4, 4);
            this.tList.Name = "tList";
            this.tList.OptionsBehavior.Editable = false;
            this.tList.OptionsView.AutoWidth = false;
            this.tList.OptionsView.ShowHorzLines = false;
            this.tList.OptionsView.ShowIndicator = false;
            this.tList.OptionsView.ShowRoot = false;
            this.tList.OptionsView.ShowVertLines = false;
            this.tList.RepositoryItems.AddRange(new RepositoryItem[] { this.repositoryItemImageEdit1, this.repositoryItemImageEdit6, this.repositoryItemImageEdit7 });
            this.tList.Size = new Size(0xff, 0x14d);
            this.tList.TabIndex = 6;
            this.tList.TreeLevelWidth = 12;
            this.tList.TreeLineStyle = LineStyle.None;
            this.tList.MouseUp += new MouseEventHandler(this.tList_MouseUp);
            this.tList.CustomNodeCellEdit += new GetCustomNodeCellEditEventHandler(this.tList_CustomNodeCellEdit);
            this.tList.FocusedNodeChanged += new FocusedNodeChangedEventHandler(this.tList_FocusedNodeChanged);
            this.tList.FocusedColumnChanged += new FocusedColumnChangedEventHandler(this.tList_FocusedColumnChanged);
            this.tListCol1.Caption = "编号";
            this.tListCol1.FieldName = "ID";
            this.tListCol1.Name = "tListCol1";
            this.tListCol1.Visible = true;
            this.tListCol1.VisibleIndex = 0;
            this.tListCol1.Width = 0x24;
            this.tListCol2.Caption = "县";
            this.tListCol2.FieldName = "县";
            this.tListCol2.Name = "tListCol2";
            this.tListCol2.Visible = true;
            this.tListCol2.VisibleIndex = 1;
            this.tListCol2.Width = 0x1f;
            this.tListCol3.Caption = "乡";
            this.tListCol3.FieldName = "乡";
            this.tListCol3.Name = "tListCol3";
            this.tListCol3.Visible = true;
            this.tListCol3.VisibleIndex = 2;
            this.tListCol3.Width = 0x15;
            this.tListCol4.Caption = "村";
            this.tListCol4.FieldName = "村";
            this.tListCol4.Name = "tListCol4";
            this.tListCol4.Visible = true;
            this.tListCol4.VisibleIndex = 3;
            this.tListCol4.Width = 20;
            this.tListCol5.Caption = "遥感ID";
            this.tListCol5.FieldName = "遥感ID";
            this.tListCol5.Name = "tListCol5";
            this.tListCol5.Visible = true;
            this.tListCol5.VisibleIndex = 7;
            this.tListCol6.Caption = "定位";
            this.tListCol6.FieldName = "定位";
            this.tListCol6.Name = "tListCol6";
            this.tListCol6.Visible = true;
            this.tListCol6.VisibleIndex = 4;
            this.tListCol6.Width = 0x27;
            this.tListCol7.Caption = "信息";
            this.tListCol7.FieldName = "信息";
            this.tListCol7.Name = "tListCol7";
            this.tListCol7.Visible = true;
            this.tListCol7.VisibleIndex = 5;
            this.tListCol7.Width = 0x2c;
            this.tListCol8.Caption = "状态";
            this.tListCol8.FieldName = "状态";
            this.tListCol8.Name = "tListCol8";
            this.tListCol8.Visible = true;
            this.tListCol8.VisibleIndex = 6;
            this.tListCol8.Width = 40;
            this.repositoryItemImageEdit1.Appearance.Image = (Image) resources.GetObject("repositoryItemImageEdit1.Appearance.Image");
            this.repositoryItemImageEdit1.Appearance.Options.UseImage = true;
            this.repositoryItemImageEdit1.AutoHeight = false;
            this.repositoryItemImageEdit1.Name = "repositoryItemImageEdit1";
            this.repositoryItemImageEdit1.ShowDropDown = ShowDropDown.Never;
            this.repositoryItemImageEdit6.AutoHeight = false;
            this.repositoryItemImageEdit6.Name = "repositoryItemImageEdit6";
            this.repositoryItemImageEdit6.ShowDropDown = ShowDropDown.Never;
            this.repositoryItemImageEdit7.AutoHeight = false;
            this.repositoryItemImageEdit7.Name = "repositoryItemImageEdit7";
            this.xtraTabPage2.Controls.Add(this.tList2);
            this.xtraTabPage2.Controls.Add(this.panelLog);
            this.xtraTabPage2.Name = "xtraTabPage2";
            this.xtraTabPage2.Padding = new Padding(4);
            this.xtraTabPage2.Size = new Size(0x107, 0x1b3);
            item4.Text = "已核实遥感变化班块";
            tip4.Items.Add(item4);
            this.xtraTabPage2.SuperTip = tip4;
            this.xtraTabPage2.Text = "已核实";
            this.tList2.Appearance.FocusedCell.BackColor = Color.LightSkyBlue;
            this.tList2.Appearance.FocusedCell.BackColor2 = Color.White;
            this.tList2.Appearance.FocusedCell.ForeColor = Color.Blue;
            this.tList2.Appearance.FocusedCell.Options.UseBackColor = true;
            this.tList2.Appearance.FocusedCell.Options.UseForeColor = true;
            this.tList2.Appearance.FocusedRow.BackColor = Color.LightSkyBlue;
            this.tList2.Appearance.FocusedRow.BackColor2 = Color.White;
            this.tList2.Appearance.FocusedRow.ForeColor = Color.Blue;
            this.tList2.Appearance.FocusedRow.Options.UseBackColor = true;
            this.tList2.Appearance.FocusedRow.Options.UseForeColor = true;
            this.tList2.Appearance.HideSelectionRow.BackColor = Color.White;
            this.tList2.Appearance.HideSelectionRow.BackColor2 = Color.White;
            this.tList2.Appearance.HideSelectionRow.ForeColor = Color.Black;
            this.tList2.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.tList2.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.tList2.Columns.AddRange(new TreeListColumn[] { this.treeListColumn11, this.treeListColumn12, this.treeListColumn13, this.treeListColumn14, this.treeListColumn15, this.treeListColumn16 });
            this.tList2.Dock = DockStyle.Fill;
            this.tList2.Location = new Point(4, 4);
            this.tList2.Name = "tList2";
            this.tList2.OptionsBehavior.Editable = false;
            this.tList2.OptionsView.AutoWidth = false;
            this.tList2.OptionsView.ShowCheckBoxes = true;
            this.tList2.OptionsView.ShowHorzLines = false;
            this.tList2.OptionsView.ShowIndicator = false;
            this.tList2.OptionsView.ShowRoot = false;
            this.tList2.OptionsView.ShowVertLines = false;
            this.tList2.RepositoryItems.AddRange(new RepositoryItem[] { this.repositoryItemImageEdit8 });
            this.tList2.Size = new Size(0xff, 0x1ab);
            this.tList2.TabIndex = 7;
            this.tList2.TreeLevelWidth = 12;
            this.tList2.TreeLineStyle = LineStyle.None;
            this.tList2.MouseUp += new MouseEventHandler(this.tList2_MouseUp);
            this.tList2.CustomNodeCellEdit += new GetCustomNodeCellEditEventHandler(this.tList2_CustomNodeCellEdit);
            this.tList2.FocusedNodeChanged += new FocusedNodeChangedEventHandler(this.tList2_FocusedNodeChanged);
            this.tList2.FocusedColumnChanged += new FocusedColumnChangedEventHandler(this.tList2_FocusedColumnChanged);
            this.treeListColumn11.Caption = "编号";
            this.treeListColumn11.FieldName = "ID";
            this.treeListColumn11.Name = "treeListColumn11";
            this.treeListColumn11.Visible = true;
            this.treeListColumn11.VisibleIndex = 0;
            this.treeListColumn11.Width = 0x24;
            this.treeListColumn12.Caption = "县";
            this.treeListColumn12.FieldName = "县";
            this.treeListColumn12.Name = "treeListColumn12";
            this.treeListColumn12.Visible = true;
            this.treeListColumn12.VisibleIndex = 1;
            this.treeListColumn12.Width = 0x2e;
            this.treeListColumn13.Caption = "乡";
            this.treeListColumn13.FieldName = "乡";
            this.treeListColumn13.Name = "treeListColumn13";
            this.treeListColumn13.Visible = true;
            this.treeListColumn13.VisibleIndex = 2;
            this.treeListColumn13.Width = 0x19;
            this.treeListColumn14.Caption = "村";
            this.treeListColumn14.FieldName = "村";
            this.treeListColumn14.Name = "treeListColumn14";
            this.treeListColumn14.Visible = true;
            this.treeListColumn14.VisibleIndex = 3;
            this.treeListColumn14.Width = 0x1a;
            this.treeListColumn15.Caption = "变化原因";
            this.treeListColumn15.FieldName = "变化原因";
            this.treeListColumn15.Name = "treeListColumn15";
            this.treeListColumn15.Visible = true;
            this.treeListColumn15.VisibleIndex = 4;
            this.treeListColumn15.Width = 0x47;
            this.treeListColumn16.Caption = "定位";
            this.treeListColumn16.FieldName = "定位";
            this.treeListColumn16.Name = "treeListColumn16";
            this.treeListColumn16.Visible = true;
            this.treeListColumn16.VisibleIndex = 5;
            this.treeListColumn16.Width = 0x2e;
            this.repositoryItemImageEdit8.Appearance.Image = (Image) resources.GetObject("repositoryItemImageEdit8.Appearance.Image");
            this.repositoryItemImageEdit8.Appearance.Options.UseImage = true;
            this.repositoryItemImageEdit8.AutoHeight = false;
            this.repositoryItemImageEdit8.Name = "repositoryItemImageEdit8";
            this.repositoryItemImageEdit8.ShowDropDown = ShowDropDown.Never;
            this.panelLog.BackColor = Color.Transparent;
            this.panelLog.Controls.Add(this.panelControl1);
            this.panelLog.Controls.Add(this.panel2);
            this.panelLog.Dock = DockStyle.Fill;
            this.panelLog.Location = new Point(4, 4);
            this.panelLog.Name = "panelLog";
            this.panelLog.Padding = new Padding(0, 6, 0, 0);
            this.panelLog.Size = new Size(0xff, 0x1ab);
            this.panelLog.TabIndex = 30;
            this.panelLog.Visible = false;
            this.panelControl1.Controls.Add(this.richTextBox);
            this.panelControl1.Dock = DockStyle.Fill;
            this.panelControl1.Location = new Point(0, 0x40);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new Size(0xff, 0x16b);
            this.panelControl1.TabIndex = 0x10;
//            this.richTextBox.BorderStyle = BorderStyle.None;
            this.richTextBox.Dock = DockStyle.Fill;
            this.richTextBox.Location = new Point(2, 2);
            this.richTextBox.Name = "richTextBox";
            this.richTextBox.Size = new Size(0xfb, 0x167);
            this.richTextBox.TabIndex = 0;
            this.richTextBox.Text = "";
            this.panel2.Controls.Add(this.labelprogress);
            this.panel2.Dock = DockStyle.Top;
            this.panel2.Location = new Point(0, 6);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new Padding(0, 2, 0, 2);
            this.panel2.Size = new Size(0xff, 0x3a);
            this.panel2.TabIndex = 15;
            this.labelprogress.BackColor = Color.Transparent;
            this.labelprogress.Dock = DockStyle.Fill;
            this.labelprogress.Location = new Point(0, 2);
            this.labelprogress.Name = "labelprogress";
            this.labelprogress.Size = new Size(0xff, 0x36);
            this.labelprogress.TabIndex = 8;
            this.labelprogress.Text = "生成进度:";
            this.labelIdentify.BackColor = Color.Transparent;
            this.labelIdentify.Cursor = Cursors.Hand;
            this.labelIdentify.Dock = DockStyle.Top;
            this.labelIdentify.ForeColor = Color.FromArgb(0, 0, 0xc0);
            this.labelIdentify.Image = (Image) resources.GetObject("labelIdentify.Image");
            this.labelIdentify.ImageAlign = ContentAlignment.MiddleLeft;
            this.labelIdentify.Location = new Point(6, 0);
            this.labelIdentify.Name = "labelIdentify";
            this.labelIdentify.Padding = new Padding(0, 3, 0, 3);
            this.labelIdentify.Size = new Size(0x10c, 0x1c);
            this.labelIdentify.TabIndex = 30;
            this.labelIdentify.Text = "      外业调查核实";
            this.labelIdentify.TextAlign = ContentAlignment.MiddleLeft;
            this.labelIdentify.Click += new EventHandler(this.labelIdentify_Click);
            this.panelInfo.Controls.Add(this.labelXBInfo);
            this.panelInfo.Dock = DockStyle.Top;
            this.panelInfo.Location = new Point(6, 0x1c);
            this.panelInfo.Name = "panelInfo";
            this.panelInfo.Padding = new Padding(0, 4, 0, 4);
            this.panelInfo.Size = new Size(0x10c, 0x5e);
            this.panelInfo.TabIndex = 40;
            this.panelInfo.Visible = false;
            this.labelXBInfo.Dock = DockStyle.Fill;
            this.labelXBInfo.Location = new Point(0, 4);
            this.labelXBInfo.Name = "labelXBInfo";
            this.labelXBInfo.Size = new Size(0x10c, 0x56);
            this.labelXBInfo.TabIndex = 0;
            this.labelXBInfo.Text = "已有变更小班 共计0个  \r\n导入遥感判读班块0个,已确定变化原因班块0个(其中变化原因为造林的0个,采伐的0个,征占用的0个,火灾0个,灾害0个,案件0个)\r\n非遥感判读导入班块0个,(其中变化原因为造林的0个,采伐的0个,征占用的0个,火灾0个,灾害0个,案件0个)\r\n\r\n\r\n";
            base.Appearance.BackColor = Color.FromArgb(0xe3, 0xf1, 0xfe);
            base.Appearance.BackColor2 = Color.FromArgb(0xe3, 0xf1, 0xfe);
            base.Appearance.Options.UseBackColor = true;
            base.AutoScaleDimensions = new SizeF(7f, 14f);
//            base.AutoScaleMode = AutoScaleMode.Font;
            base.Controls.Add(this.panelIDList);
            base.Controls.Add(this.panelInfo);
            base.Controls.Add(this.labelIdentify);
            base.Name = "UserControlXBSet3";
            base.Padding = new Padding(6, 0, 6, 6);
            base.Size = new Size(280, 500);
            this.imageCollection1.EndInit();
            this.imageCollection2.EndInit();
            this.imageCollection3.EndInit();
            this.panelIDList.ResumeLayout(false);
            this.xtraTabControl1.EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.xtraTabPage1.ResumeLayout(false);
            this.tList.EndInit();
            this.repositoryItemImageEdit1.EndInit();
            this.repositoryItemImageEdit6.EndInit();
            this.repositoryItemImageEdit7.EndInit();
            this.xtraTabPage2.ResumeLayout(false);
            this.tList2.EndInit();
            this.repositoryItemImageEdit8.EndInit();
            this.panelLog.ResumeLayout(false);
            this.panelControl1.EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panelInfo.ResumeLayout(false);
            base.ResumeLayout(false);
        }

        public void InitialListID()
        {
            try
            {
                TreeListNode node3 = null;
                TreeListNode parentNode = null;
                this.tList.Columns[0].Width = 40;
                this.tList.Columns[1].Width = 0x2c;
                this.tList.Columns[2].Width = 50;
                this.tList.Columns[3].Width = 50;
                this.tList.Columns[4].Width = 50;
                this.tList.Columns[5].Width = 0x24;
                this.tList.Columns[6].Width = 0x18;
                this.tList.Columns[7].Width = 0x24;
                this.tListCol7.Visible = false;
                this.tListCol8.Visible = false;
                try
                {
                    if (this.tList.Nodes.Count > 0)
                    {
                        this.tList.Nodes.Clear();
                    }
                }
                catch (Exception)
                {
                }
                this.mFeatureList = new ArrayList();
                IQueryFilter filter = new QueryFilterClass();
                filter.WhereClause = "BHYY is null";
                IFeatureCursor cursor = this.m_EditLayer.FeatureClass.Search(null, false);
                IFeature feature = cursor.NextFeature();
                int index = -1;
                int num2 = -1;
                int num4 = -1;
                string[] strArray = null;
                if (feature != null)
                {
                    string name = "OBJECTID";
                    index = feature.Fields.FindField(name);
                    name = UtilFactory.GetConfigOpt().GetConfigValue("YGFieldName");
                    num4 = feature.Fields.FindField(name);
                    num2 = feature.Fields.FindField("BHYY");
                    strArray = UtilFactory.GetConfigOpt().GetConfigValue("XBFieldDist").Split(new char[] { ',' });
                }
                while (feature != null)
                {
                    if (feature.get_Value(num2).ToString() == "")
                    {
                        this.mFeatureList.Add(feature);
                        string nodeData = feature.get_Value(index).ToString();
                        node3 = this.tList.AppendNode(nodeData, parentNode);
                        node3.SetValue(0, nodeData);
                        for (int i = 0; i < strArray.Length; i++)
                        {
                            int num6 = feature.Fields.FindField(strArray[i]);
                            if (num6 > -1)
                            {
                                node3.SetValue(i + 1, this.GetFiledValue(num6, feature));
                            }
                        }
                        node3.SetValue(4, feature.get_Value(num4).ToString());
                        node3.SetValue(6, "遥感班块未核实");
                        node3.Tag = feature;
                    }
                    feature = cursor.NextFeature();
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlXBSet3", "InitialListID", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        public void InitialListID2()
        {
            try
            {
                TreeListNode node3 = null;
                TreeListNode parentNode = null;
                this.tList2.Columns[0].Width = 40;
                this.tList2.Columns[1].Width = 0x2c;
                this.tList2.Columns[2].Width = 50;
                this.tList2.Columns[3].Width = 50;
                this.tList2.Columns[4].Width = 50;
                this.tList2.Columns[5].Width = 0x24;
                this.tList2.BringToFront();
                this.tList2.OptionsView.ShowCheckBoxes = false;
                try
                {
                    if (this.tList2.Nodes.Count > 0)
                    {
                        this.tList2.Nodes.Clear();
                    }
                }
                catch (Exception)
                {
                }
                this.mFeatureList2 = new ArrayList();
                IQueryFilter filter = new QueryFilterClass();
                filter.WhereClause = "not (BHYY is null) ";
                IFeatureCursor cursor = this.m_EditLayer.FeatureClass.Search(filter, false);
                IFeature feature = cursor.NextFeature();
                int index = -1;
                int num2 = -1;
                string name = "";
                string[] strArray = null;
                if (feature != null)
                {
                    name = "OBJECTID";
                    index = feature.Fields.FindField(name);
                    strArray = UtilFactory.GetConfigOpt().GetConfigValue("XBFieldDist").Split(new char[] { ',' });
                    num2 = feature.Fields.FindField("BHYY");
                }
                while (feature != null)
                {
                    int num5;
                    this.mFeatureList2.Add(feature);
                    string nodeData = feature.get_Value(index).ToString();
                    try
                    {
                        node3 = this.tList2.AppendNode(nodeData, parentNode);
                    }
                    catch (Exception)
                    {
                        node3 = this.tList2.AppendNode(nodeData, parentNode);
                    }
                    node3.SetValue(0, nodeData);
                    node3.Tag = feature;
                    for (int i = 0; i < strArray.Length; i++)
                    {
                        num5 = feature.Fields.FindField(strArray[i]);
                        if (num5 > -1)
                        {
                            node3.SetValue(i + 1, this.GetFiledValue(num5, feature));
                        }
                    }
                    if (feature.get_Value(num2).ToString() != "")
                    {
                        string val = feature.get_Value(num2).ToString();
                        ICodedValueDomain domain = (ICodedValueDomain) feature.Fields.get_Field(num2).Domain;
                        long num6 = Convert.ToInt64(feature.get_Value(num2));
                        for (num5 = 0; num5 < domain.CodeCount; num5++)
                        {
                            if (num6 == Convert.ToInt64(domain.get_Value(num5)))
                            {
                                val = domain.get_Name(num5);
                                break;
                            }
                        }
                        node3.SetValue(4, val);
                    }
                    else
                    {
                        node3.SetValue(4, "遥感班块未核实");
                    }
                    feature = cursor.NextFeature();
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlXBSet3", "InitialListID2", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        public void InitialValue()
        {
            try
            {
                if (((this.mHookHelper != null) && (this.mHookHelper.FocusMap != null)) && (this.mHookHelper.FocusMap.LayerCount != 0))
                {
                    IMap focusMap = this.mHookHelper.FocusMap;
                    //if (this.mDBAccess == null)
                    //{
                    //    this.mDBAccess = UtilFactory.GetDBAccess("Access");
                    //}
                    this.mStateTable = null;// this.mDBAccess.GetDataTable(this.mDBAccess, "Select * from T_EditTask");
                    this.mFeatureWorkspace = EditTask.EditWorkspace;
                    if (this.mFeatureWorkspace != null)
                    {
                        if (this.m_EditLayer == null)
                        {
                            this.m_EditLayer = EditTask.EditLayer;
                        }
                        this.mEditKindCode = "DCYS";
                        EditTask.KindCode = "0809";
                        this.mCurItemImageEdit0 = this.repositoryItemImageEdit1;
                        this.mCurItemImageEdit0.Images = this.imageList0;
                        this.mCurItemImageEdit6 = this.repositoryItemImageEdit6;
                        this.mCurItemImageEdit6.Images = this.imageList0;
                        this.mCurItemImageEdit7 = this.repositoryItemImageEdit7;
                        this.mCurItemImageEdit7.Images = this.imageList7;
                        this.mCurItemImageEdit8 = this.repositoryItemImageEdit8;
                        this.mCurItemImageEdit8.Images = this.imageList0;
                        this.simpleButtonInfo.Left = (this.xtraTabControl1.Left + this.xtraTabControl1.Width) - this.simpleButtonInfo.Width;
                        this.simpleButtonInfo.Top = 3;
                        this.simpleButtonRefresh.Left = (this.simpleButtonInfo.Left - this.simpleButtonRefresh.Width) - 4;
                        this.simpleButtonRefresh.Top = 3;
                        if (this.xtraTabControl1.SelectedTabPageIndex == 0)
                        {
                            this.InitialListID();
                        }
                        else if (this.xtraTabControl1.SelectedTabPageIndex == 1)
                        {
                            this.InitialListID2();
                        }
                        this.mSelected = false;
                    }
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlXBSet3", "InitialValue", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void labelIdentify_Click(object sender, EventArgs e)
        {
            this.panelInfo.Visible = !this.panelInfo.Visible;
            if (this.panelInfo.Visible)
            {
                this.GetXBInfo();
            }
        }

        private void simpleButtonInfo_Click(object sender, EventArgs e)
        {
            try
            {
                TreeListNode mNodeList = null;
                UserControlQueryResult mQueryResult = null;
                if (this.xtraTabControl1.SelectedTabPageIndex == 0)
                {
                    this.mQueryList = this.mFeatureList;
                    mNodeList = this.mNodeList;
                    mQueryResult = this.mQueryResult;
                }
                else if (this.xtraTabControl1.SelectedTabPageIndex == 1)
                {
                    this.mQueryList = this.mFeatureList2;
                    mNodeList = this.mNodeList2;
                    mQueryResult = this.mQueryResult2;
                }
                int selectedTabPageIndex = this.xtraTabControl1.SelectedTabPageIndex;
                if (this.mQueryList != null)
                {
                    IFeature tag = mNodeList.Tag as IFeature;
                    mQueryResult.InitialQueryInfo(this.mHookHelper, this.m_EditLayer, this.mQueryList, this.m_QueryTable, this.sDesKeyField, tag, null);
                    this.mDockPanel.Visibility = DockVisibility.Visible;
                    if ((this.mDockPanel.Controls.Count > 0) && (this.mDockPanel.Controls[0].Controls.Count > 0))
                    {
                        XtraTabControl control = this.mDockPanel.Controls[0].Controls[0] as XtraTabControl;
                        if (control != null)
                        {
                            control.TabPages[selectedTabPageIndex].PageVisible = true;
                            control.TabPages[selectedTabPageIndex].Text = this.xtraTabControl1.SelectedTabPage.Text;
                            control.SelectedTabPage = control.TabPages[selectedTabPageIndex];
                        }
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        private void simpleButtonRefresh_Click(object sender, EventArgs e)
        {
            this.simpleButtonRefresh.Enabled = false;
            if (this.xtraTabControl1.SelectedTabPageIndex == 0)
            {
                this.InitialListID();
            }
            else if (this.xtraTabControl1.SelectedTabPageIndex == 1)
            {
                this.InitialListID2();
            }
            this.simpleButtonRefresh.Enabled = true;
        }

        private void tList_CustomNodeCellEdit(object sender, GetCustomNodeCellEditEventArgs e)
        {
            if (!this.mSelected)
            {
                this.mSelected = true;
                if (e.Column.Name == "tListCol6")
                {
                    e.RepositoryItem = this.mCurItemImageEdit6;
                }
                else
                {
                    e.RepositoryItem = null;
                }
                this.mSelected = false;
            }
        }

        private void tList_FocusedColumnChanged(object sender, FocusedColumnChangedEventArgs e)
        {
            this.columnlist = e.Column.AbsoluteIndex;
        }

        private void tList_FocusedNodeChanged(object sender, FocusedNodeChangedEventArgs e)
        {
            this.mNodeList = e.Node;
        }

        private void tList_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                if ((e.X >= this.tList.Columns[0].Width) && (this.columnlist == 5))
                {
                    IFeature tag = this.mNodeList.Tag as IFeature;
                    GISFunFactory.FeatureFun.ZoomToFeature(this.mHookHelper.FocusMap, tag);
                    (this.m_EditLayer as IFeatureSelection).Clear();
                    this.mHookHelper.FocusMap.SelectFeature(this.m_EditLayer, tag);
                }
            }
            catch (Exception)
            {
            }
        }

        private void tList2_CustomNodeCellEdit(object sender, GetCustomNodeCellEditEventArgs e)
        {
            if (!this.mSelected)
            {
                this.mSelected = true;
                if (e.Column.Name == "treeListColumn16")
                {
                    e.RepositoryItem = this.mCurItemImageEdit8;
                }
                else
                {
                    e.RepositoryItem = null;
                }
                this.mSelected = false;
            }
        }

        private void tList2_FocusedColumnChanged(object sender, FocusedColumnChangedEventArgs e)
        {
            this.columnlist2 = e.Column.AbsoluteIndex;
        }

        private void tList2_FocusedNodeChanged(object sender, FocusedNodeChangedEventArgs e)
        {
            this.mNodeList2 = e.Node;
        }

        private void tList2_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                if ((e.X >= this.tList2.Columns[0].Width) && (this.columnlist2 == 5))
                {
                    IFeature tag = this.mNodeList2.Tag as IFeature;
                    GISFunFactory.FeatureFun.ZoomToFeature(this.mHookHelper.FocusMap, tag);
                    (this.m_EditLayer as IFeatureSelection).Clear();
                    this.mHookHelper.FocusMap.SelectFeature(this.m_EditLayer, tag);
                }
            }
            catch (Exception)
            {
            }
        }
    }
}

