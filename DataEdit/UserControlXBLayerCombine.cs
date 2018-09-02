namespace DataEdit
{
    using AttributesEdit;
    using DevExpress.Utils;
    using DevExpress.XtraBars.Docking;
    using DevExpress.XtraEditors;
    using DevExpress.XtraEditors.Controls;
    using DevExpress.XtraEditors.Repository;
    using DevExpress.XtraGrid;
    using DevExpress.XtraGrid.Columns;
    using DevExpress.XtraGrid.Views.Grid;
    using DevExpress.XtraTab;
    using DevExpress.XtraTreeList;
    using DevExpress.XtraTreeList.Columns;
    using DevExpress.XtraTreeList.Nodes;
    using ESRI.ArcGIS.AnalysisTools;
    using ESRI.ArcGIS.Carto;
    using ESRI.ArcGIS.Controls;
    using ESRI.ArcGIS.DataManagementTools;
    using ESRI.ArcGIS.esriSystem;
    using ESRI.ArcGIS.Geodatabase;
    using ESRI.ArcGIS.Geoprocessing;
    using ESRI.ArcGIS.Geoprocessor;
    using FormBase;
    using FunFactory;
    using QueryCommon;
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
    using DevExpress.XtraGrid.Views.Base;

    public class UserControlXBLayerCombine : UserControlBase1
    {
        private CheckedListBoxControl checkedListBoxControl1;
        private int columnlist = -1;
        private int columnlist2 = -1;
        private IContainer components = null;
        private GridColumn gridColumn1;
        private GridColumn gridColumn2;
        private GridColumn gridColumn3;
        private GridColumn gridColumn4;
        public GridControl gridControl1;
        public GridControl gridControl2;
        public GridControl gridControl3;
        public GridView gridView1;
        public GridView gridView2;
        public GridView gridView3;
        private GroupControl groupControlDistConbine;
        private DevExpress.Utils.ImageCollection imageCollection2;
        internal ImageList imageList0;
        internal ImageList ImageList1;
        internal ImageList imageList2;
        internal ImageList imageList3;
        private ImageList imageList4;
        internal ImageList imageList5;
        internal ImageList imageList6;
        internal ImageList imageList7;
        private ImageListBoxControl imageListBoxControl1;
        private Label label1;
        private Label label2;
        private Label labelIdentify;
        private Label labelinfo;
        private Label labelInfo2;
        private Label labelInfo3;
        private Label labelprogress;
        private ListView listViewDist;
        private IFeature m_CountyFeature;
        private IFeatureLayer m_CountyLayer;
        private ITable m_CountyTable;
        private IFeatureLayer m_EditLayer;
        private IFeatureLayer m_QueryLayer;
        private IFeatureLayer m_TownLayer;
        private ITable m_TownTable;
        private IFeatureLayer m_UnderLayer;
        private IFeatureLayer m_VillageLayer;
        private IActiveViewEvents_Event mActiveViewEvents;
        private const string mClassName = "DataEdit.UserControlXBLayerCombine";
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
        private IHookHelper mHookHelper;
        private TreeListNode mNodeList;
        private TreeListNode mNodeList2;
        private ArrayList mQueryList = null;
        private UserControlQueryResult mQueryResult;
        private UserControlQueryResult mQueryResult2;
        private bool mSelected;
        private DataTable mStateTable;
        private bool mStopFlag = false;
        private string mSubSysName = UtilFactory.GetConfigOpt().GetSystemName();
        private DataTable mUpdataTable;
        private DataTable mUpdataTable1;
        private DataTable mUpdataTable2;
        private DataTable mUpdataTable3;
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private Panel panel4;
        private Panel panel5;
        public Panel panel6;
        private Panel panel7;
        private Panel panel8;
        private PanelControl panelControl1;
        public Panel panelIDList;
        private Panel panelInfo;
        private Panel panelInfo2;
        private Panel panelLog;
        private RepositoryItemComboBox repositoryItemComboBox1;
        private RepositoryItemComboBox repositoryItemComboBox2;
        private RepositoryItemComboBox repositoryItemComboBox3;
        private RepositoryItemComboBox repositoryItemComboBox4;
        private RepositoryItemImageEdit repositoryItemImageEdit1;
        private RepositoryItemImageEdit repositoryItemImageEdit2;
        private RepositoryItemImageEdit repositoryItemImageEdit6;
        private RepositoryItemImageEdit repositoryItemImageEdit7;
        private RepositoryItemImageEdit repositoryItemImageEdit8;
        private RichTextBox richTextBox;
        private string sDesKeyField;
        public SimpleButton simpleButton1;
        public SimpleButton simpleButtonCancel;
        private SimpleButton simpleButtonCheck;
        public SimpleButton simpleButtonCombine;
        public SimpleButton simpleButtonCombine2;
        public SimpleButton simpleButtonDistCombine;
        private SimpleButton simpleButtonInfo;
        private SimpleButton simpleButtonRefresh;
        public SimpleButton simpleButtonResult;
        private SimpleButton simpleButtonStop;
        private TreeList tList;
        private TreeList tList2;
        private TreeList tList3;
        private TreeListColumn tListCol1;
        private TreeListColumn tListCol2;
        private TreeListColumn tListCol3;
        private TreeListColumn tListCol4;
        private TreeListColumn tListCol5;
        private TreeListColumn tListCol6;
        private TreeListColumn tListCol7;
        private TreeListColumn tListCol8;
        private TreeListColumn treeListColumn1;
        private TreeListColumn treeListColumn11;
        private TreeListColumn treeListColumn12;
        private TreeListColumn treeListColumn13;
        private TreeListColumn treeListColumn14;
        private TreeListColumn treeListColumn15;
        private TreeListColumn treeListColumn16;
        private TreeListColumn treeListColumn17;
        private TreeListColumn treeListColumn18;
        private TreeListColumn treeListColumn2;
        private TreeListColumn treeListColumn3;
        private TreeListColumn treeListColumn4;
        private TreeListColumn treeListColumn5;
        private TreeListColumn treeListColumn6;
        private TreeListColumn treeListColumn7;
        private TreeListColumn treeListColumn8;
        private XtraTabControl xtraTabControl1;
        private XtraTabPage xtraTabPage1;
        private XtraTabPage xtraTabPage2;
        private XtraTabPage xtraTabPage3;
        private ColumnHeader 合并状态;
        private ColumnHeader 乡镇名称;

        public UserControlXBLayerCombine()
        {
            this.InitializeComponent();
            this.xtraTabControl1.SelectedPageChanged += new TabPageChangedEventHandler(this.xtraTabControl1_SelectedPageChanged);
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

        private void gridControl2_Click(object sender, EventArgs e)
        {
        }

        private void gridControl3_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (this.gridView3.FocusedRowHandle != -1)
                {
                    string s = "-1";
                    s = this.gridView3.GetRowCellValue(this.gridView1.FocusedRowHandle, "序号").ToString();
                    IFeature feature = this.m_EditLayer.FeatureClass.GetFeature(int.Parse(s));
                    if (!this.m_EditLayer.Visible)
                    {
                        this.m_EditLayer.Visible = true;
                    }
                    (this.m_EditLayer as IFeatureSelection).Clear();
                    this.mHookHelper.FocusMap.SelectFeature(this.m_EditLayer, feature);
                    GISFunFactory.FeatureFun.ZoomToFeature(this.mHookHelper.FocusMap, feature);
                }
            }
            catch (Exception)
            {
            }
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (this.gridView1.FocusedRowHandle != -1)
                {
                    string s = "-1";
                    s = this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "序号").ToString();
                    IFeature feature = this.m_EditLayer.FeatureClass.GetFeature(int.Parse(s));
                    if (!this.m_EditLayer.Visible)
                    {
                        this.m_EditLayer.Visible = true;
                    }
                    (this.m_EditLayer as IFeatureSelection).Clear();
                    this.mHookHelper.FocusMap.SelectFeature(this.m_EditLayer, feature);
                    GISFunFactory.FeatureFun.ZoomToFeature(this.mHookHelper.FocusMap, feature);
                }
            }
            catch (Exception)
            {
            }
        }

        private void gridView2_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (this.gridView2.FocusedRowHandle != -1)
                {
                    string s = "-1";
                    s = this.gridView2.GetRowCellValue(this.gridView2.FocusedRowHandle, "序号").ToString();
                    IFeature feature = this.m_EditLayer.FeatureClass.GetFeature(int.Parse(s));
                    if (!this.m_EditLayer.Visible)
                    {
                        this.m_EditLayer.Visible = true;
                    }
                    (this.m_EditLayer as IFeatureSelection).Clear();
                    this.mHookHelper.FocusMap.SelectFeature(this.m_EditLayer, feature);
                    GISFunFactory.FeatureFun.ZoomToFeature(this.mHookHelper.FocusMap, feature);
                }
            }
            catch (Exception)
            {
            }
        }

        public void Hook(object hook, IFeatureLayer pEditFLayer, IFeature pCountyFeature, UserControlQueryResult pResult, UserControlQueryResult pResult2, DockPanel pDockPanel)
        {
            try
            {
                this.m_EditLayer = pEditFLayer;
                this.m_CountyFeature = pCountyFeature;
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
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlXBLayerCombine", "Hook", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private DataTable InitialGridView(GridControl gridControl, GridView gridView, string sType, Label labinfo)
        {
            try
            {
                int num;
                DataTable dataTable = null;// this.mDBAccess.GetDataTable(this.mDBAccess, "Select Feature_ID as 序号 from T_AutoUpdate_Feature where Update_Type='" + sType + "'");
                DataColumn column = new DataColumn("县", typeof(string));
                dataTable.Columns.Add(column);
                column = new DataColumn("乡", typeof(string));
                dataTable.Columns.Add(column);
                column = new DataColumn("村", typeof(string));
                dataTable.Columns.Add(column);
                string[] strArray = UtilFactory.GetConfigOpt().GetConfigValue("XBFieldName2").Split(new char[] { ',' });
                string[] strArray2 = strArray;
                ITable featureClass = this.m_EditLayer.FeatureClass as ITable;
                for (num = 0; num < strArray.Length; num++)
                {
                    strArray2[num] = featureClass.Fields.FindField(strArray[num]).ToString();
                }
                for (num = 0; num < dataTable.Rows.Count; num++)
                {
                    IQueryFilter queryFilter = new QueryFilterClass();
                    queryFilter.WhereClause = "OBJECTID =" + dataTable.Rows[num][0].ToString();
                    IRow row = featureClass.Search(queryFilter, false).NextRow();
                    dataTable.Rows[num][1] = row.get_Value(int.Parse(strArray2[0]));
                    dataTable.Rows[num][2] = row.get_Value(int.Parse(strArray2[1]));
                    dataTable.Rows[num][3] = row.get_Value(int.Parse(strArray2[2]));
                }
                gridControl.DataSource = null;
                gridView.OptionsView.ColumnAutoWidth = false;
                gridView.Columns.Clear();
                gridControl.DataSource = dataTable;
                gridView.RefreshData();
                gridView.FixedLineWidth = 1;
                gridView.OptionsBehavior.Editable = false;
                gridView.Columns[0].Width = 0x2e;
                labinfo.Text = "    " + dataTable.Rows.Count;
                labinfo.Visible = true;
                return dataTable;
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlXBLayerCombine", "InitialGridView", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                return null;
            }
        }

        private void InitializeComponent()
        {
            this.components = new Container();
            ComponentResourceManager resources = new ComponentResourceManager(typeof(UserControlXBLayerCombine));
            SuperToolTip tip = new SuperToolTip();
            ToolTipItem item = new ToolTipItem();
            SuperToolTip tip2 = new SuperToolTip();
            ToolTipItem item2 = new ToolTipItem();
            SuperToolTip tip3 = new SuperToolTip();
            ToolTipItem item3 = new ToolTipItem();
            SuperToolTip tip4 = new SuperToolTip();
            ToolTipItem item4 = new ToolTipItem();
            SuperToolTip tip5 = new SuperToolTip();
            ToolTipItem item5 = new ToolTipItem();
            SuperToolTip tip6 = new SuperToolTip();
            ToolTipItem item6 = new ToolTipItem();
            SuperToolTip tip7 = new SuperToolTip();
            ToolTipItem item7 = new ToolTipItem();
            SuperToolTip tip8 = new SuperToolTip();
            ToolTipItem item8 = new ToolTipItem();
            SuperToolTip tip9 = new SuperToolTip();
            ToolTipItem item9 = new ToolTipItem();
            SuperToolTip tip10 = new SuperToolTip();
            ToolTipItem item10 = new ToolTipItem();
            ListViewItem item11 = new ListViewItem("1", 0x5b);
            ListViewItem item12 = new ListViewItem("2", 4);
            SuperToolTip tip11 = new SuperToolTip();
            ToolTipItem item13 = new ToolTipItem();
            SuperToolTip tip12 = new SuperToolTip();
            ToolTipItem item14 = new ToolTipItem();
            this.labelIdentify = new Label();
            this.ImageList1 = new ImageList(this.components);
            this.imageList0 = new ImageList(this.components);
            this.imageList7 = new ImageList(this.components);
            this.imageList6 = new ImageList(this.components);
            this.imageList4 = new ImageList(this.components);
            this.imageList3 = new ImageList(this.components);
            this.imageCollection2 = new DevExpress.Utils.ImageCollection(this.components);
            this.imageList2 = new ImageList(this.components);
            this.panel6 = new Panel();
            this.simpleButtonCancel = new SimpleButton();
            this.panel1 = new Panel();
            this.simpleButtonResult = new SimpleButton();
            this.panel2 = new Panel();
            this.simpleButtonCheck = new SimpleButton();
            this.panel7 = new Panel();
            this.simpleButtonCombine = new SimpleButton();
            this.panel4 = new Panel();
            this.simpleButtonCombine2 = new SimpleButton();
            this.panelInfo = new Panel();
            this.label1 = new Label();
            this.panelIDList = new Panel();
            this.simpleButtonStop = new SimpleButton();
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
            this.labelinfo = new Label();
            this.gridControl1 = new GridControl();
            this.gridView1 = new GridView();
            this.gridColumn3 = new GridColumn();
            this.repositoryItemComboBox2 = new RepositoryItemComboBox();
            this.xtraTabPage2 = new XtraTabPage();
            this.tList2 = new TreeList();
            this.treeListColumn11 = new TreeListColumn();
            this.treeListColumn12 = new TreeListColumn();
            this.treeListColumn13 = new TreeListColumn();
            this.treeListColumn14 = new TreeListColumn();
            this.treeListColumn15 = new TreeListColumn();
            this.treeListColumn16 = new TreeListColumn();
            this.treeListColumn17 = new TreeListColumn();
            this.treeListColumn18 = new TreeListColumn();
            this.repositoryItemImageEdit8 = new RepositoryItemImageEdit();
            this.labelInfo2 = new Label();
            this.gridControl2 = new GridControl();
            this.gridView2 = new GridView();
            this.gridColumn2 = new GridColumn();
            this.repositoryItemComboBox3 = new RepositoryItemComboBox();
            this.xtraTabPage3 = new XtraTabPage();
            this.tList3 = new TreeList();
            this.treeListColumn1 = new TreeListColumn();
            this.treeListColumn2 = new TreeListColumn();
            this.treeListColumn3 = new TreeListColumn();
            this.treeListColumn4 = new TreeListColumn();
            this.treeListColumn5 = new TreeListColumn();
            this.treeListColumn6 = new TreeListColumn();
            this.treeListColumn7 = new TreeListColumn();
            this.treeListColumn8 = new TreeListColumn();
            this.repositoryItemImageEdit2 = new RepositoryItemImageEdit();
            this.labelInfo3 = new Label();
            this.gridControl3 = new GridControl();
            this.gridView3 = new GridView();
            this.gridColumn4 = new GridColumn();
            this.repositoryItemComboBox4 = new RepositoryItemComboBox();
            this.panelInfo2 = new Panel();
            this.label2 = new Label();
            this.gridColumn1 = new GridColumn();
            this.repositoryItemComboBox1 = new RepositoryItemComboBox();
            this.panelLog = new Panel();
            this.panelControl1 = new PanelControl();
            this.richTextBox = new RichTextBox();
            this.panel3 = new Panel();
            this.labelprogress = new Label();
            this.groupControlDistConbine = new GroupControl();
            this.listViewDist = new ListView();
            this.乡镇名称 = new ColumnHeader("(无)");
            this.合并状态 = new ColumnHeader("(无)");
            this.checkedListBoxControl1 = new CheckedListBoxControl();
            this.imageListBoxControl1 = new ImageListBoxControl();
            this.panel5 = new Panel();
            this.simpleButtonDistCombine = new SimpleButton();
            this.panel8 = new Panel();
            this.simpleButton1 = new SimpleButton();
            this.imageList5 = new ImageList(this.components);
            this.imageCollection2.BeginInit();
            this.panel6.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panelInfo.SuspendLayout();
            this.panelIDList.SuspendLayout();
            this.xtraTabControl1.BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
            this.tList.BeginInit();
            this.repositoryItemImageEdit1.BeginInit();
            this.repositoryItemImageEdit6.BeginInit();
            this.repositoryItemImageEdit7.BeginInit();
            this.gridControl1.BeginInit();
            this.gridView1.BeginInit();
            this.repositoryItemComboBox2.BeginInit();
            this.xtraTabPage2.SuspendLayout();
            this.tList2.BeginInit();
            this.repositoryItemImageEdit8.BeginInit();
            this.gridControl2.BeginInit();
            this.gridView2.BeginInit();
            this.repositoryItemComboBox3.BeginInit();
            this.xtraTabPage3.SuspendLayout();
            this.tList3.BeginInit();
            this.repositoryItemImageEdit2.BeginInit();
            this.gridControl3.BeginInit();
            this.gridView3.BeginInit();
            this.repositoryItemComboBox4.BeginInit();
            this.panelInfo2.SuspendLayout();
            this.repositoryItemComboBox1.BeginInit();
            this.panelLog.SuspendLayout();
            this.panelControl1.BeginInit();
            this.panelControl1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.groupControlDistConbine.BeginInit();
            this.groupControlDistConbine.SuspendLayout();
            ((ISupportInitialize) this.checkedListBoxControl1).BeginInit();
            ((ISupportInitialize) this.imageListBoxControl1).BeginInit();
            this.panel5.SuspendLayout();
            base.SuspendLayout();
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
            this.labelIdentify.TabIndex = 0x1f;
            this.labelIdentify.Text = "      年度变更小班更新";
            this.labelIdentify.TextAlign = ContentAlignment.MiddleLeft;
            this.labelIdentify.Click += new EventHandler(this.labelIdentify_Click);
            this.ImageList1.ImageStream = (ImageListStreamer) resources.GetObject("ImageList1.ImageStream");
            this.ImageList1.TransparentColor = Color.White;
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
            this.ImageList1.Images.SetKeyName(0x5d, "image-info.png");
            this.ImageList1.Images.SetKeyName(0x5e, "info.png");
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
            this.imageList6.ImageStream = (ImageListStreamer) resources.GetObject("imageList6.ImageStream");
            this.imageList6.TransparentColor = Color.Transparent;
            this.imageList6.Images.SetKeyName(0, "(03,42).png");
            this.imageList6.Images.SetKeyName(1, "(04,42).png");
            this.imageList6.Images.SetKeyName(2, "(01,46).png");
            this.imageList6.Images.SetKeyName(3, "(01,49).png");
            this.imageList6.Images.SetKeyName(4, "(02,27).png");
            this.imageList6.Images.SetKeyName(5, "(03,42).png");
            this.imageList4.ImageStream = (ImageListStreamer) resources.GetObject("imageList4.ImageStream");
            this.imageList4.TransparentColor = Color.Transparent;
            this.imageList4.Images.SetKeyName(0, "001_45.gif");
            this.imageList4.Images.SetKeyName(1, "001_38.gif");
            this.imageList4.Images.SetKeyName(2, "blue_view_24x24.gif");
            this.imageList4.Images.SetKeyName(3, "gtk-edit.png");
            this.imageList4.Images.SetKeyName(4, "ico6.gif");
            this.imageList3.ImageStream = (ImageListStreamer) resources.GetObject("imageList3.ImageStream");
            this.imageList3.TransparentColor = Color.Transparent;
            this.imageList3.Images.SetKeyName(0, "(04,42).png");
            this.imageList3.Images.SetKeyName(1, "(03,42).png");
            this.imageList3.Images.SetKeyName(2, "(01,46).png");
            this.imageList3.Images.SetKeyName(3, "(01,49).png");
            this.imageList3.Images.SetKeyName(4, "(02,27).png");
            this.imageList3.Images.SetKeyName(5, "(03,42).png");
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
            this.panel6.BackColor = Color.Transparent;
            this.panel6.Controls.Add(this.simpleButtonCancel);
            this.panel6.Controls.Add(this.panel1);
            this.panel6.Controls.Add(this.simpleButtonResult);
            this.panel6.Controls.Add(this.panel2);
            this.panel6.Dock = DockStyle.Top;
            this.panel6.Location = new Point(6, 0x4e);
            this.panel6.Name = "panel6";
            this.panel6.Padding = new Padding(0, 6, 0, 6);
            this.panel6.Size = new Size(0x10c, 0x44);
            this.panel6.TabIndex = 0x20;
            this.simpleButtonCancel.Dock = DockStyle.Right;
            this.simpleButtonCancel.ImageIndex = 0x40;
            this.simpleButtonCancel.ImageList = this.imageCollection2;
            this.simpleButtonCancel.Location = new Point(0x72, 0x24);
            this.simpleButtonCancel.Name = "simpleButtonCancel";
            this.simpleButtonCancel.Size = new Size(0x4a, 0x1a);
            item.Text = "恢复备份年度小班数据";
            tip.Items.Add(item);
            this.simpleButtonCancel.SuperTip = tip;
            this.simpleButtonCancel.TabIndex = 9;
            this.simpleButtonCancel.Text = "恢复备份";
            this.simpleButtonCancel.Click += new EventHandler(this.simpleButtonCancel_Click);
            this.panel1.Dock = DockStyle.Right;
            this.panel1.Location = new Point(0xbc, 0x24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new Size(6, 0x1a);
            this.panel1.TabIndex = 11;
            this.simpleButtonResult.Dock = DockStyle.Right;
            this.simpleButtonResult.ImageIndex = 0x31;
            this.simpleButtonResult.ImageList = this.imageCollection2;
            this.simpleButtonResult.Location = new Point(0xc2, 0x24);
            this.simpleButtonResult.Name = "simpleButtonResult";
            this.simpleButtonResult.Size = new Size(0x4a, 0x1a);
            item2.Text = "查看自动更新执行结果";
            tip2.Items.Add(item2);
            this.simpleButtonResult.SuperTip = tip2;
            this.simpleButtonResult.TabIndex = 10;
            this.simpleButtonResult.Text = "查看结果";
            this.simpleButtonResult.Click += new EventHandler(this.simpleButtonResult_Click);
            this.panel2.Controls.Add(this.simpleButtonCheck);
            this.panel2.Controls.Add(this.panel7);
            this.panel2.Controls.Add(this.simpleButtonCombine);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.simpleButtonCombine2);
            this.panel2.Dock = DockStyle.Top;
            this.panel2.Location = new Point(0, 6);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new Padding(0, 0, 0, 4);
            this.panel2.Size = new Size(0x10c, 30);
            this.panel2.TabIndex = 15;
            this.simpleButtonCheck.Dock = DockStyle.Right;
            this.simpleButtonCheck.ImageIndex = 6;
            this.simpleButtonCheck.ImageList = this.ImageList1;
            this.simpleButtonCheck.Location = new Point(0x22, 0);
            this.simpleButtonCheck.Name = "simpleButtonCheck";
            this.simpleButtonCheck.Size = new Size(0x4a, 0x1a);
            this.simpleButtonCheck.TabIndex = 14;
            this.simpleButtonCheck.Text = "数据校验";
            this.simpleButtonCheck.ToolTip = "校验遥感数据是否有重叠班块,变化原因是否填写";
            this.simpleButtonCheck.Click += new EventHandler(this.simpleButtonCheck_Click);
            this.panel7.Dock = DockStyle.Right;
            this.panel7.Location = new Point(0x6c, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new Size(6, 0x1a);
            this.panel7.TabIndex = 15;
            this.simpleButtonCombine.Dock = DockStyle.Right;
            this.simpleButtonCombine.ImageIndex = 0x35;
            this.simpleButtonCombine.ImageList = this.imageCollection2;
            this.simpleButtonCombine.Location = new Point(0x72, 0);
            this.simpleButtonCombine.Name = "simpleButtonCombine";
            this.simpleButtonCombine.Size = new Size(0x4a, 0x1a);
            item3.Text = "自动新增、分割、替换年度小班";
            tip3.Items.Add(item3);
            this.simpleButtonCombine.SuperTip = tip3;
            this.simpleButtonCombine.TabIndex = 12;
            this.simpleButtonCombine.Text = "自动更新";
            this.simpleButtonCombine.Click += new EventHandler(this.simpleButtonCombine_Click);
            this.panel4.Dock = DockStyle.Right;
            this.panel4.Location = new Point(0xbc, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new Size(6, 0x1a);
            this.panel4.TabIndex = 0x11;
            this.simpleButtonCombine2.Dock = DockStyle.Right;
            this.simpleButtonCombine2.ImageIndex = 0x51;
            this.simpleButtonCombine2.ImageList = this.imageCollection2;
            this.simpleButtonCombine2.Location = new Point(0xc2, 0);
            this.simpleButtonCombine2.Name = "simpleButtonCombine2";
            this.simpleButtonCombine2.Size = new Size(0x4a, 0x1a);
            item4.Text = "按乡镇新增、分割、替换年度小班";
            tip4.Items.Add(item4);
            this.simpleButtonCombine2.SuperTip = tip4;
            this.simpleButtonCombine2.TabIndex = 0x10;
            this.simpleButtonCombine2.Text = "区域更新";
            this.simpleButtonCombine2.Click += new EventHandler(this.simpleButtonCombine2_Click);
            this.panelInfo.Controls.Add(this.label1);
            this.panelInfo.Dock = DockStyle.Top;
            this.panelInfo.Location = new Point(6, 0x1c);
            this.panelInfo.Name = "panelInfo";
            this.panelInfo.Padding = new Padding(6, 2, 6, 2);
            this.panelInfo.Size = new Size(0x10c, 50);
            this.panelInfo.TabIndex = 0x21;
            this.label1.Dock = DockStyle.Fill;
            this.label1.Location = new Point(6, 2);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0x100, 0x2e);
            this.label1.TabIndex = 0;
            this.label1.Text = "变更小班信息\r\n共计200个变更班块\r\n总面积3000";
            this.panelIDList.Controls.Add(this.simpleButtonStop);
            this.panelIDList.Controls.Add(this.simpleButtonRefresh);
            this.panelIDList.Controls.Add(this.simpleButtonInfo);
            this.panelIDList.Controls.Add(this.xtraTabControl1);
            this.panelIDList.Dock = DockStyle.Fill;
            this.panelIDList.Location = new Point(6, 0x1aa);
            this.panelIDList.Name = "panelIDList";
            this.panelIDList.Padding = new Padding(0, 2, 0, 0);
            this.panelIDList.Size = new Size(0x10c, 0xa8);
            this.panelIDList.TabIndex = 0x22;
            this.panelIDList.Visible = false;
            this.simpleButtonStop.ImageIndex = 0x3a;
            this.simpleButtonStop.ImageList = this.ImageList1;
            this.simpleButtonStop.ImageLocation = ImageLocation.MiddleLeft;
            this.simpleButtonStop.Location = new Point(0xa5, 3);
            this.simpleButtonStop.Name = "simpleButtonStop";
            this.simpleButtonStop.Size = new Size(0x30, 20);
            item5.Text = "停止刷新";
            tip5.Items.Add(item5);
            this.simpleButtonStop.SuperTip = tip5;
            this.simpleButtonStop.TabIndex = 0x25;
            this.simpleButtonStop.Text = "停止";
            this.simpleButtonStop.Visible = false;
            this.simpleButtonStop.Click += new EventHandler(this.simpleButtonStop_Click);
            this.simpleButtonRefresh.ImageIndex = 0x55;
            this.simpleButtonRefresh.ImageList = this.ImageList1;
            this.simpleButtonRefresh.ImageLocation = ImageLocation.MiddleLeft;
            this.simpleButtonRefresh.Location = new Point(0xa5, 3);
            this.simpleButtonRefresh.Name = "simpleButtonRefresh";
            this.simpleButtonRefresh.Size = new Size(0x30, 20);
            item6.Text = "刷新列表";
            tip6.Items.Add(item6);
            this.simpleButtonRefresh.SuperTip = tip6;
            this.simpleButtonRefresh.TabIndex = 4;
            this.simpleButtonRefresh.Text = "刷新";
            this.simpleButtonRefresh.Click += new EventHandler(this.simpleButtonRefresh_Click);
            this.simpleButtonInfo.ImageIndex = 4;
            this.simpleButtonInfo.ImageList = this.imageList2;
            this.simpleButtonInfo.ImageLocation = ImageLocation.MiddleLeft;
            this.simpleButtonInfo.Location = new Point(0xd9, 3);
            this.simpleButtonInfo.Name = "simpleButtonInfo";
            this.simpleButtonInfo.Size = new Size(0x30, 20);
            item7.Text = "详细信息";
            tip7.Items.Add(item7);
            this.simpleButtonInfo.SuperTip = tip7;
            this.simpleButtonInfo.TabIndex = 2;
            this.simpleButtonInfo.Text = "信息";
            this.simpleButtonInfo.Click += new EventHandler(this.simpleButtonInfo_Click);
            this.xtraTabControl1.Dock = DockStyle.Fill;
            this.xtraTabControl1.Location = new Point(0, 2);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.Padding = new Padding(4);
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPage1;
            this.xtraTabControl1.Size = new Size(0x10c, 0xa6);
            this.xtraTabControl1.TabIndex = 0;
            this.xtraTabControl1.TabPages.AddRange(new XtraTabPage[] { this.xtraTabPage1, this.xtraTabPage2, this.xtraTabPage3 });
            this.xtraTabPage1.Controls.Add(this.tList);
            this.xtraTabPage1.Controls.Add(this.labelinfo);
            this.xtraTabPage1.Controls.Add(this.gridControl1);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Padding = new Padding(4);
            this.xtraTabPage1.Size = new Size(0x107, 0x8b);
            item8.Text = "分割小班";
            tip8.Items.Add(item8);
            this.xtraTabPage1.SuperTip = tip8;
            this.xtraTabPage1.Text = "分割";
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
            this.tList.Location = new Point(4, 0x16);
            this.tList.Name = "tList";
            this.tList.OptionsBehavior.Editable = false;
            this.tList.OptionsView.AutoWidth = false;
            this.tList.OptionsView.ShowHorzLines = false;
            this.tList.OptionsView.ShowIndicator = false;
            this.tList.OptionsView.ShowRoot = false;
            this.tList.OptionsView.ShowVertLines = false;
            this.tList.RepositoryItems.AddRange(new RepositoryItem[] { this.repositoryItemImageEdit1, this.repositoryItemImageEdit6, this.repositoryItemImageEdit7 });
            this.tList.Size = new Size(0xff, 0x71);
            this.tList.TabIndex = 6;
            this.tList.TreeLevelWidth = 12;
            this.tList.TreeLineStyle = LineStyle.None;
            this.tList.FocusedNodeChanged += new FocusedNodeChangedEventHandler(this.tList_FocusedNodeChanged);
            this.tList.FocusedColumnChanged += new DevExpress.XtraTreeList.FocusedColumnChangedEventHandler(this.tList_FocusedColumnChanged);
            this.tList.MouseDoubleClick += new MouseEventHandler(this.tList_MouseDoubleClick);
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
            this.tListCol3.Width = 0x1f;
            this.tListCol4.Caption = "村";
            this.tListCol4.FieldName = "村";
            this.tListCol4.Name = "tListCol4";
            this.tListCol4.Visible = true;
            this.tListCol4.VisibleIndex = 3;
            this.tListCol4.Width = 0x1d;
            this.tListCol5.Caption = "林班";
            this.tListCol5.FieldName = "定位";
            this.tListCol5.Name = "tListCol5";
            this.tListCol5.Visible = true;
            this.tListCol5.VisibleIndex = 4;
            this.tListCol5.Width = 0x27;
            this.tListCol6.Caption = "小班";
            this.tListCol6.FieldName = "信息";
            this.tListCol6.Name = "tListCol6";
            this.tListCol6.Visible = true;
            this.tListCol6.VisibleIndex = 5;
            this.tListCol6.Width = 0x2c;
            this.tListCol7.Caption = "细班";
            this.tListCol7.FieldName = "状态";
            this.tListCol7.Name = "tListCol7";
            this.tListCol7.Visible = true;
            this.tListCol7.VisibleIndex = 6;
            this.tListCol7.Width = 0x1f;
            this.tListCol8.Caption = "定位";
            this.tListCol8.FieldName = "定位";
            this.tListCol8.Name = "tListCol8";
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
            this.labelinfo.Dock = DockStyle.Top;
            this.labelinfo.ImageAlign = ContentAlignment.TopLeft;
            this.labelinfo.ImageIndex = 0x13;
            this.labelinfo.ImageList = this.ImageList1;
            this.labelinfo.Location = new Point(4, 4);
            this.labelinfo.Name = "labelinfo";
            this.labelinfo.Size = new Size(0xff, 0x12);
            this.labelinfo.TabIndex = 7;
            this.labelinfo.Text = "    ";
            this.labelinfo.TextAlign = ContentAlignment.MiddleLeft;
            this.gridControl1.Dock = DockStyle.Fill;
            this.gridControl1.Location = new Point(4, 4);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new RepositoryItem[] { this.repositoryItemComboBox2 });
            this.gridControl1.Size = new Size(0xff, 0x83);
            this.gridControl1.TabIndex = 0x62;
            this.gridControl1.ViewCollection.AddRange(new BaseView[] { this.gridView1 });
            this.gridControl1.Visible = false;
            this.gridView1.Columns.AddRange(new GridColumn[] { this.gridColumn3 });
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsCustomization.AllowColumnMoving = false;
            this.gridView1.OptionsCustomization.AllowSort = false;
            this.gridView1.OptionsFilter.AllowColumnMRUFilterList = false;
            this.gridView1.OptionsFilter.AllowFilterEditor = false;
            this.gridView1.OptionsFilter.AllowMRUFilterList = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.OptionsView.ShowIndicator = false;
            this.gridView1.DoubleClick += new EventHandler(this.gridView1_DoubleClick);
            this.gridColumn3.Caption = "名称";
            this.gridColumn3.Name = "gridColumn3";
            this.repositoryItemComboBox2.AutoHeight = false;
            this.repositoryItemComboBox2.Buttons.AddRange(new EditorButton[] { new EditorButton(ButtonPredefines.Combo) });
            this.repositoryItemComboBox2.Name = "repositoryItemComboBox2";
            this.xtraTabPage2.Controls.Add(this.tList2);
            this.xtraTabPage2.Controls.Add(this.labelInfo2);
            this.xtraTabPage2.Controls.Add(this.gridControl2);
            this.xtraTabPage2.Name = "xtraTabPage2";
            this.xtraTabPage2.Padding = new Padding(4);
            this.xtraTabPage2.Size = new Size(0x107, 0x8b);
            item9.Text = "属性修改小班";
            tip9.Items.Add(item9);
            this.xtraTabPage2.SuperTip = tip9;
            this.xtraTabPage2.Text = "属性";
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
            this.tList2.Columns.AddRange(new TreeListColumn[] { this.treeListColumn11, this.treeListColumn12, this.treeListColumn13, this.treeListColumn14, this.treeListColumn15, this.treeListColumn16, this.treeListColumn17, this.treeListColumn18 });
            this.tList2.Dock = DockStyle.Fill;
            this.tList2.Location = new Point(4, 0x16);
            this.tList2.Name = "tList2";
            this.tList2.OptionsBehavior.Editable = false;
            this.tList2.OptionsView.AutoWidth = false;
            this.tList2.OptionsView.ShowHorzLines = false;
            this.tList2.OptionsView.ShowIndicator = false;
            this.tList2.OptionsView.ShowRoot = false;
            this.tList2.OptionsView.ShowVertLines = false;
            this.tList2.RepositoryItems.AddRange(new RepositoryItem[] { this.repositoryItemImageEdit8 });
            this.tList2.Size = new Size(0xff, 0x71);
            this.tList2.TabIndex = 7;
            this.tList2.TreeLevelWidth = 12;
            this.tList2.TreeLineStyle = LineStyle.None;
            this.tList2.FocusedNodeChanged += new FocusedNodeChangedEventHandler(this.tList_FocusedNodeChanged);
            this.tList2.FocusedColumnChanged += new DevExpress.XtraTreeList.FocusedColumnChangedEventHandler(this.tList_FocusedColumnChanged);
            this.tList2.MouseDoubleClick += new MouseEventHandler(this.tList_MouseDoubleClick);
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
            this.treeListColumn12.Width = 0x20;
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
            this.treeListColumn15.Caption = "林班";
            this.treeListColumn15.FieldName = "变化原因";
            this.treeListColumn15.Name = "treeListColumn15";
            this.treeListColumn15.Visible = true;
            this.treeListColumn15.VisibleIndex = 4;
            this.treeListColumn15.Width = 0x27;
            this.treeListColumn16.Caption = "小班";
            this.treeListColumn16.FieldName = "定位";
            this.treeListColumn16.Name = "treeListColumn16";
            this.treeListColumn16.Visible = true;
            this.treeListColumn16.VisibleIndex = 5;
            this.treeListColumn16.Width = 0x26;
            this.treeListColumn17.Caption = "细班";
            this.treeListColumn17.FieldName = "细班";
            this.treeListColumn17.Name = "treeListColumn17";
            this.treeListColumn17.Visible = true;
            this.treeListColumn17.VisibleIndex = 6;
            this.treeListColumn18.Caption = "定位";
            this.treeListColumn18.FieldName = "定位";
            this.treeListColumn18.Name = "treeListColumn18";
            this.repositoryItemImageEdit8.Appearance.Image = (Image) resources.GetObject("repositoryItemImageEdit8.Appearance.Image");
            this.repositoryItemImageEdit8.Appearance.Options.UseImage = true;
            this.repositoryItemImageEdit8.AutoHeight = false;
            this.repositoryItemImageEdit8.Name = "repositoryItemImageEdit8";
            this.repositoryItemImageEdit8.ShowDropDown = ShowDropDown.Never;
            this.labelInfo2.Dock = DockStyle.Top;
            this.labelInfo2.ImageAlign = ContentAlignment.TopLeft;
            this.labelInfo2.ImageIndex = 0x13;
            this.labelInfo2.ImageList = this.ImageList1;
            this.labelInfo2.Location = new Point(4, 4);
            this.labelInfo2.Name = "labelInfo2";
            this.labelInfo2.Size = new Size(0xff, 0x12);
            this.labelInfo2.TabIndex = 0x1f;
            this.labelInfo2.Text = "    ";
            this.labelInfo2.TextAlign = ContentAlignment.MiddleLeft;
            this.gridControl2.Dock = DockStyle.Fill;
            this.gridControl2.Location = new Point(4, 4);
            this.gridControl2.MainView = this.gridView2;
            this.gridControl2.Name = "gridControl2";
            this.gridControl2.RepositoryItems.AddRange(new RepositoryItem[] { this.repositoryItemComboBox3 });
            this.gridControl2.Size = new Size(0xff, 0x83);
            this.gridControl2.TabIndex = 0x63;
            this.gridControl2.ViewCollection.AddRange(new BaseView[] { this.gridView2 });
            this.gridControl2.Click += new EventHandler(this.gridControl2_Click);
            this.gridView2.Columns.AddRange(new GridColumn[] { this.gridColumn2 });
            this.gridView2.GridControl = this.gridControl2;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsCustomization.AllowColumnMoving = false;
            this.gridView2.OptionsCustomization.AllowSort = false;
            this.gridView2.OptionsFilter.AllowColumnMRUFilterList = false;
            this.gridView2.OptionsFilter.AllowFilterEditor = false;
            this.gridView2.OptionsFilter.AllowMRUFilterList = false;
            this.gridView2.OptionsView.ShowGroupPanel = false;
            this.gridView2.OptionsView.ShowIndicator = false;
            this.gridView2.DoubleClick += new EventHandler(this.gridView2_DoubleClick);
            this.gridColumn2.Caption = "名称";
            this.gridColumn2.Name = "gridColumn2";
            this.repositoryItemComboBox3.AutoHeight = false;
            this.repositoryItemComboBox3.Buttons.AddRange(new EditorButton[] { new EditorButton(ButtonPredefines.Combo) });
            this.repositoryItemComboBox3.Name = "repositoryItemComboBox3";
            this.xtraTabPage3.Controls.Add(this.tList3);
            this.xtraTabPage3.Controls.Add(this.labelInfo3);
            this.xtraTabPage3.Controls.Add(this.gridControl3);
            this.xtraTabPage3.Name = "xtraTabPage3";
            this.xtraTabPage3.Padding = new Padding(4);
            this.xtraTabPage3.Size = new Size(0x107, 0x8b);
            item10.Text = "新增小班";
            tip10.Items.Add(item10);
            this.xtraTabPage3.SuperTip = tip10;
            this.xtraTabPage3.Text = "新增";
            this.tList3.Appearance.FocusedCell.BackColor = Color.LightSkyBlue;
            this.tList3.Appearance.FocusedCell.BackColor2 = Color.White;
            this.tList3.Appearance.FocusedCell.ForeColor = Color.Blue;
            this.tList3.Appearance.FocusedCell.Options.UseBackColor = true;
            this.tList3.Appearance.FocusedCell.Options.UseForeColor = true;
            this.tList3.Appearance.FocusedRow.BackColor = Color.LightSkyBlue;
            this.tList3.Appearance.FocusedRow.BackColor2 = Color.White;
            this.tList3.Appearance.FocusedRow.ForeColor = Color.Blue;
            this.tList3.Appearance.FocusedRow.Options.UseBackColor = true;
            this.tList3.Appearance.FocusedRow.Options.UseForeColor = true;
            this.tList3.Appearance.HideSelectionRow.BackColor = Color.White;
            this.tList3.Appearance.HideSelectionRow.BackColor2 = Color.White;
            this.tList3.Appearance.HideSelectionRow.ForeColor = Color.Black;
            this.tList3.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.tList3.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.tList3.Columns.AddRange(new TreeListColumn[] { this.treeListColumn1, this.treeListColumn2, this.treeListColumn3, this.treeListColumn4, this.treeListColumn5, this.treeListColumn6, this.treeListColumn7, this.treeListColumn8 });
            this.tList3.Dock = DockStyle.Fill;
            this.tList3.Location = new Point(4, 0x16);
            this.tList3.Name = "tList3";
            this.tList3.OptionsBehavior.Editable = false;
            this.tList3.OptionsView.AutoWidth = false;
            this.tList3.OptionsView.ShowHorzLines = false;
            this.tList3.OptionsView.ShowIndicator = false;
            this.tList3.OptionsView.ShowRoot = false;
            this.tList3.OptionsView.ShowVertLines = false;
            this.tList3.RepositoryItems.AddRange(new RepositoryItem[] { this.repositoryItemImageEdit2 });
            this.tList3.Size = new Size(0xff, 0x71);
            this.tList3.TabIndex = 8;
            this.tList3.TreeLevelWidth = 12;
            this.tList3.TreeLineStyle = LineStyle.None;
            this.tList3.FocusedNodeChanged += new FocusedNodeChangedEventHandler(this.tList_FocusedNodeChanged);
            this.tList3.FocusedColumnChanged += new DevExpress.XtraTreeList.FocusedColumnChangedEventHandler(this.tList_FocusedColumnChanged);
            this.tList3.MouseDoubleClick += new MouseEventHandler(this.tList_MouseDoubleClick);
            this.treeListColumn1.Caption = "编号";
            this.treeListColumn1.FieldName = "ID";
            this.treeListColumn1.Name = "treeListColumn1";
            this.treeListColumn1.Visible = true;
            this.treeListColumn1.VisibleIndex = 0;
            this.treeListColumn1.Width = 0x24;
            this.treeListColumn2.Caption = "县";
            this.treeListColumn2.FieldName = "县";
            this.treeListColumn2.Name = "treeListColumn2";
            this.treeListColumn2.Visible = true;
            this.treeListColumn2.VisibleIndex = 1;
            this.treeListColumn2.Width = 0x20;
            this.treeListColumn3.Caption = "乡";
            this.treeListColumn3.FieldName = "乡";
            this.treeListColumn3.Name = "treeListColumn3";
            this.treeListColumn3.Visible = true;
            this.treeListColumn3.VisibleIndex = 2;
            this.treeListColumn3.Width = 0x19;
            this.treeListColumn4.Caption = "村";
            this.treeListColumn4.FieldName = "村";
            this.treeListColumn4.Name = "treeListColumn4";
            this.treeListColumn4.Visible = true;
            this.treeListColumn4.VisibleIndex = 3;
            this.treeListColumn4.Width = 0x1a;
            this.treeListColumn5.Caption = "林班";
            this.treeListColumn5.FieldName = "变化原因";
            this.treeListColumn5.Name = "treeListColumn5";
            this.treeListColumn5.Visible = true;
            this.treeListColumn5.VisibleIndex = 4;
            this.treeListColumn5.Width = 0x27;
            this.treeListColumn6.Caption = "小班";
            this.treeListColumn6.FieldName = "定位";
            this.treeListColumn6.Name = "treeListColumn6";
            this.treeListColumn6.Visible = true;
            this.treeListColumn6.VisibleIndex = 5;
            this.treeListColumn6.Width = 0x26;
            this.treeListColumn7.Caption = "细班";
            this.treeListColumn7.FieldName = "细班";
            this.treeListColumn7.Name = "treeListColumn7";
            this.treeListColumn7.Visible = true;
            this.treeListColumn7.VisibleIndex = 6;
            this.treeListColumn8.Caption = "定位";
            this.treeListColumn8.FieldName = "定位";
            this.treeListColumn8.Name = "treeListColumn8";
            this.repositoryItemImageEdit2.Appearance.Image = (Image) resources.GetObject("repositoryItemImageEdit2.Appearance.Image");
            this.repositoryItemImageEdit2.Appearance.Options.UseImage = true;
            this.repositoryItemImageEdit2.AutoHeight = false;
            this.repositoryItemImageEdit2.Name = "repositoryItemImageEdit2";
            this.repositoryItemImageEdit2.ShowDropDown = ShowDropDown.Never;
            this.labelInfo3.Dock = DockStyle.Top;
            this.labelInfo3.ImageAlign = ContentAlignment.TopLeft;
            this.labelInfo3.ImageIndex = 0x13;
            this.labelInfo3.ImageList = this.ImageList1;
            this.labelInfo3.Location = new Point(4, 4);
            this.labelInfo3.Name = "labelInfo3";
            this.labelInfo3.Size = new Size(0xff, 0x12);
            this.labelInfo3.TabIndex = 9;
            this.labelInfo3.Text = "    ";
            this.labelInfo3.TextAlign = ContentAlignment.MiddleLeft;
            this.gridControl3.Dock = DockStyle.Fill;
            this.gridControl3.Location = new Point(4, 4);
            this.gridControl3.MainView = this.gridView3;
            this.gridControl3.Name = "gridControl3";
            this.gridControl3.RepositoryItems.AddRange(new RepositoryItem[] { this.repositoryItemComboBox4 });
            this.gridControl3.Size = new Size(0xff, 0x83);
            this.gridControl3.TabIndex = 100;
            this.gridControl3.ViewCollection.AddRange(new BaseView[] { this.gridView3 });
            this.gridControl3.DoubleClick += new EventHandler(this.gridControl3_DoubleClick);
            this.gridView3.Columns.AddRange(new GridColumn[] { this.gridColumn4 });
            this.gridView3.GridControl = this.gridControl3;
            this.gridView3.Name = "gridView3";
            this.gridView3.OptionsCustomization.AllowColumnMoving = false;
            this.gridView3.OptionsCustomization.AllowSort = false;
            this.gridView3.OptionsFilter.AllowColumnMRUFilterList = false;
            this.gridView3.OptionsFilter.AllowFilterEditor = false;
            this.gridView3.OptionsFilter.AllowMRUFilterList = false;
            this.gridView3.OptionsView.ShowGroupPanel = false;
            this.gridView3.OptionsView.ShowIndicator = false;
            this.gridColumn4.Caption = "名称";
            this.gridColumn4.Name = "gridColumn4";
            this.repositoryItemComboBox4.AutoHeight = false;
            this.repositoryItemComboBox4.Buttons.AddRange(new EditorButton[] { new EditorButton(ButtonPredefines.Combo) });
            this.repositoryItemComboBox4.Name = "repositoryItemComboBox4";
            this.panelInfo2.Controls.Add(this.label2);
            this.panelInfo2.Dock = DockStyle.Top;
            this.panelInfo2.Location = new Point(6, 0x182);
            this.panelInfo2.Name = "panelInfo2";
            this.panelInfo2.Padding = new Padding(6);
            this.panelInfo2.Size = new Size(0x10c, 40);
            this.panelInfo2.TabIndex = 0x23;
            this.panelInfo2.Visible = false;
            this.label2.Dock = DockStyle.Fill;
            this.label2.ImageAlign = ContentAlignment.TopLeft;
            this.label2.ImageIndex = 0x5d;
            this.label2.ImageList = this.ImageList1;
            this.label2.Location = new Point(6, 6);
            this.label2.Name = "label2";
            this.label2.Size = new Size(0x100, 0x1c);
            this.label2.TabIndex = 0;
            this.label2.Text = "      正在更新...";
            this.gridColumn1.Caption = "名称";
            this.gridColumn1.Name = "gridColumn1";
            this.repositoryItemComboBox1.AutoHeight = false;
            this.repositoryItemComboBox1.Buttons.AddRange(new EditorButton[] { new EditorButton(ButtonPredefines.Combo) });
            this.repositoryItemComboBox1.Name = "repositoryItemComboBox1";
            this.panelLog.BackColor = Color.Transparent;
            this.panelLog.Controls.Add(this.panelControl1);
            this.panelLog.Controls.Add(this.panel3);
            this.panelLog.Dock = DockStyle.Fill;
            this.panelLog.Location = new Point(6, 0x1aa);
            this.panelLog.Name = "panelLog";
            this.panelLog.Padding = new Padding(0, 6, 0, 0);
            this.panelLog.Size = new Size(0x10c, 0xa8);
            this.panelLog.TabIndex = 0x24;
            this.panelLog.Visible = false;
            this.panelControl1.Controls.Add(this.richTextBox);
            this.panelControl1.Dock = DockStyle.Fill;
            this.panelControl1.Location = new Point(0, 0x2c);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new Size(0x10c, 0x7c);
            this.panelControl1.TabIndex = 0x10;
//            this.richTextBox.BorderStyle = BorderStyle.None;
            this.richTextBox.Dock = DockStyle.Fill;
            this.richTextBox.Location = new Point(2, 2);
            this.richTextBox.Name = "richTextBox";
            this.richTextBox.Size = new Size(0x108, 120);
            this.richTextBox.TabIndex = 0;
            this.richTextBox.Text = "";
            this.panel3.Controls.Add(this.labelprogress);
            this.panel3.Dock = DockStyle.Top;
            this.panel3.Location = new Point(0, 6);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new Padding(0, 2, 0, 2);
            this.panel3.Size = new Size(0x10c, 0x26);
            this.panel3.TabIndex = 15;
            this.labelprogress.BackColor = Color.Transparent;
            this.labelprogress.Dock = DockStyle.Fill;
            this.labelprogress.Location = new Point(0, 2);
            this.labelprogress.Name = "labelprogress";
            this.labelprogress.Size = new Size(0x10c, 0x22);
            this.labelprogress.TabIndex = 8;
            this.labelprogress.Text = "生成进度:";
            this.groupControlDistConbine.Controls.Add(this.listViewDist);
            this.groupControlDistConbine.Controls.Add(this.checkedListBoxControl1);
            this.groupControlDistConbine.Controls.Add(this.imageListBoxControl1);
            this.groupControlDistConbine.Controls.Add(this.panel5);
            this.groupControlDistConbine.Dock = DockStyle.Top;
            this.groupControlDistConbine.Location = new Point(6, 0x92);
            this.groupControlDistConbine.Name = "groupControlDistConbine";
            this.groupControlDistConbine.Padding = new Padding(4, 4, 4, 0);
            this.groupControlDistConbine.Size = new Size(0x10c, 240);
            this.groupControlDistConbine.TabIndex = 0x25;
            this.groupControlDistConbine.Text = "按乡更新";
            this.groupControlDistConbine.Visible = false;
//            this.listViewDist.BorderStyle = BorderStyle.None;
            this.listViewDist.CheckBoxes = true;
            this.listViewDist.Columns.AddRange(new ColumnHeader[] { this.乡镇名称, this.合并状态 });
            this.listViewDist.Dock = DockStyle.Fill;
            item11.Checked = true;
            item11.StateImageIndex = 2;
            item12.Checked = true;
            item12.StateImageIndex = 1;
            this.listViewDist.Items.AddRange(new ListViewItem[] { item11, item12 });
            this.listViewDist.LargeImageList = this.imageList2;
            this.listViewDist.Location = new Point(0x31, 0x1b);
            this.listViewDist.Name = "listViewDist";
            this.listViewDist.Size = new Size(0xb3, 0xb1);
            this.listViewDist.SmallImageList = this.ImageList1;
            this.listViewDist.StateImageList = this.imageList5;
            this.listViewDist.TabIndex = 0x13;
            this.listViewDist.UseCompatibleStateImageBehavior = false;
            this.listViewDist.View = View.Details;
            this.乡镇名称.Text = "乡镇名称";
            this.乡镇名称.Width = 100;
            this.合并状态.Text = "合并状态";
            this.合并状态.TextAlign = HorizontalAlignment.Center;
            this.合并状态.Width = 0x6d;
            this.checkedListBoxControl1.Dock = DockStyle.Right;
            this.checkedListBoxControl1.Items.AddRange(new CheckedListBoxItem[] { new CheckedListBoxItem(null), new CheckedListBoxItem(null) });
            this.checkedListBoxControl1.Location = new Point(0xe4, 0x1b);
            this.checkedListBoxControl1.Name = "checkedListBoxControl1";
            this.checkedListBoxControl1.Size = new Size(0x22, 0xb1);
            this.checkedListBoxControl1.TabIndex = 0x12;
            this.checkedListBoxControl1.Visible = false;
            this.imageListBoxControl1.Dock = DockStyle.Left;
            this.imageListBoxControl1.ImageList = this.ImageList1;
            this.imageListBoxControl1.Items.AddRange(new ImageListBoxItem[] { new ImageListBoxItem("1", 0), new ImageListBoxItem("2", 0) });
            this.imageListBoxControl1.Location = new Point(6, 0x1b);
            this.imageListBoxControl1.Name = "imageListBoxControl1";
            this.imageListBoxControl1.Size = new Size(0x2b, 0xb1);
            this.imageListBoxControl1.TabIndex = 0x11;
            this.imageListBoxControl1.Visible = false;
            this.panel5.Controls.Add(this.simpleButtonDistCombine);
            this.panel5.Controls.Add(this.panel8);
            this.panel5.Controls.Add(this.simpleButton1);
            this.panel5.Dock = DockStyle.Bottom;
            this.panel5.Location = new Point(6, 0xcc);
            this.panel5.Name = "panel5";
            this.panel5.Padding = new Padding(0, 4, 0, 4);
            this.panel5.Size = new Size(0x100, 0x22);
            this.panel5.TabIndex = 0x10;
            this.simpleButtonDistCombine.Dock = DockStyle.Right;
            this.simpleButtonDistCombine.ImageIndex = 0x3f;
            this.simpleButtonDistCombine.ImageList = this.imageCollection2;
            this.simpleButtonDistCombine.Location = new Point(110, 4);
            this.simpleButtonDistCombine.Name = "simpleButtonDistCombine";
            this.simpleButtonDistCombine.Size = new Size(70, 0x1a);
            item13.Text = "自动新增、分割、替换年度小班";
            tip11.Items.Add(item13);
            this.simpleButtonDistCombine.SuperTip = tip11;
            this.simpleButtonDistCombine.TabIndex = 0x10;
            this.simpleButtonDistCombine.Text = "更新";
            this.simpleButtonDistCombine.Click += new EventHandler(this.simpleButtonDistCombine_Click);
            this.panel8.Dock = DockStyle.Right;
            this.panel8.Location = new Point(180, 4);
            this.panel8.Name = "panel8";
            this.panel8.Size = new Size(6, 0x1a);
            this.panel8.TabIndex = 0x11;
            this.simpleButton1.Dock = DockStyle.Right;
            this.simpleButton1.ImageIndex = 0x54;
            this.simpleButton1.ImageList = this.imageCollection2;
            this.simpleButton1.Location = new Point(0xba, 4);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new Size(70, 0x1a);
            item14.Text = "取消按乡镇合并";
            tip12.Items.Add(item14);
            this.simpleButton1.SuperTip = tip12;
            this.simpleButton1.TabIndex = 0x12;
            this.simpleButton1.Text = "取消";
            this.simpleButton1.Click += new EventHandler(this.simpleButton1_Click);
            this.imageList5.ImageStream = (ImageListStreamer) resources.GetObject("imageList5.ImageStream");
            this.imageList5.TransparentColor = Color.White;
            this.imageList5.Images.SetKeyName(0, "blank16.ico");
            this.imageList5.Images.SetKeyName(1, "tick16.ico");
            this.imageList5.Images.SetKeyName(2, "PART16.ICO");
            base.Appearance.BackColor = Color.FromArgb(0xe3, 0xf1, 0xfe);
            base.Appearance.BackColor2 = Color.FromArgb(0xe3, 0xf1, 0xfe);
            base.Appearance.Options.UseBackColor = true;
            base.AutoScaleDimensions = new SizeF(7f, 14f);
//            base.AutoScaleMode = AutoScaleMode.Font;
            base.Controls.Add(this.panelLog);
            base.Controls.Add(this.panelIDList);
            base.Controls.Add(this.panelInfo2);
            base.Controls.Add(this.groupControlDistConbine);
            base.Controls.Add(this.panel6);
            base.Controls.Add(this.panelInfo);
            base.Controls.Add(this.labelIdentify);
            base.Name = "UserControlXBLayerCombine";
            base.Padding = new Padding(6, 0, 6, 6);
            base.Size = new Size(280, 600);
            this.imageCollection2.EndInit();
            this.panel6.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panelInfo.ResumeLayout(false);
            this.panelIDList.ResumeLayout(false);
            this.xtraTabControl1.EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.xtraTabPage1.ResumeLayout(false);
            this.tList.EndInit();
            this.repositoryItemImageEdit1.EndInit();
            this.repositoryItemImageEdit6.EndInit();
            this.repositoryItemImageEdit7.EndInit();
            this.gridControl1.EndInit();
            this.gridView1.EndInit();
            this.repositoryItemComboBox2.EndInit();
            this.xtraTabPage2.ResumeLayout(false);
            this.tList2.EndInit();
            this.repositoryItemImageEdit8.EndInit();
            this.gridControl2.EndInit();
            this.gridView2.EndInit();
            this.repositoryItemComboBox3.EndInit();
            this.xtraTabPage3.ResumeLayout(false);
            this.tList3.EndInit();
            this.repositoryItemImageEdit2.EndInit();
            this.gridControl3.EndInit();
            this.gridView3.EndInit();
            this.repositoryItemComboBox4.EndInit();
            this.panelInfo2.ResumeLayout(false);
            this.repositoryItemComboBox1.EndInit();
            this.panelLog.ResumeLayout(false);
            this.panelControl1.EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.groupControlDistConbine.EndInit();
            this.groupControlDistConbine.ResumeLayout(false);
            ((ISupportInitialize) this.checkedListBoxControl1).EndInit();
            ((ISupportInitialize) this.imageListBoxControl1).EndInit();
            this.panel5.ResumeLayout(false);
            base.ResumeLayout(false);
        }

        public void InitialListID(TreeList pList, DataRow[] pRows, Label labinfo)
        {
            try
            {
                TreeListNode node3 = null;
                TreeListNode parentNode = null;
                pList.Columns[0].Width = 40;
                pList.Columns[1].Width = 0x2c;
                pList.Columns[2].Width = 50;
                pList.Columns[3].Width = 50;
                pList.Columns[4].Width = 50;
                pList.Columns[5].Width = 0x24;
                pList.Columns[6].Width = 0x24;
                pList.Columns[7].Width = 0x18;
                try
                {
                    if (pList.Nodes.Count > 0)
                    {
                        pList.Nodes.Clear();
                    }
                }
                catch (Exception)
                {
                }
                this.Cursor = Cursors.WaitCursor;
                Application.DoEvents();
                ArrayList list = new ArrayList();
                Application.DoEvents();
                string text = labinfo.Text;
                for (int i = 0; i < pRows.Length; i++)
                {
                    Application.DoEvents();
                    GC.Collect();
                    IQueryFilter filter = new QueryFilterClass();
                    filter.WhereClause = "OBJECTID =" + pRows[i]["Feature_ID"].ToString();
                    IFeatureCursor cursor = this.m_EditLayer.FeatureClass.Search(filter, false);
                    IFeature feature = cursor.NextFeature();
                    int index = -1;
                    int num3 = -1;
                    string[] strArray = null;
                    if (feature != null)
                    {
                        string name = "OBJECTID";
                        index = feature.Fields.FindField(name);
                        num3 = feature.Fields.FindField("BHYY");
                        strArray = UtilFactory.GetConfigOpt().GetConfigValue("XBFieldName2").Split(new char[] { ',' });
                    }
                    while (feature != null)
                    {
                        list.Add(feature);
                        labinfo.Text = string.Concat(new object[] { text, ",已读取小班", list.Count, "块" });
                        string nodeData = feature.get_Value(index).ToString();
                        try
                        {
                            node3 = pList.AppendNode(nodeData, parentNode);
                            node3.SetValue(0, nodeData);
                        }
                        catch (Exception)
                        {
                        }
                        for (int j = 0; j < strArray.Length; j++)
                        {
                            int num7 = feature.Fields.FindField(strArray[j]);
                            if (num7 > -1)
                            {
                                node3.SetValue(j + 1, this.GetFiledValue(num7, feature));
                            }
                        }
                        node3.Tag = feature;
                        if (this.mStopFlag)
                        {
                            this.mStopFlag = false;
                            break;
                        }
                        feature = cursor.NextFeature();
                    }
                }
                pList.Tag = list;
                labinfo.Text = string.Concat(new object[] { text, ",已读取小班", list.Count, "块" });
                this.simpleButtonStop.Visible = false;
                this.Cursor = Cursors.Default;
            }
            catch (Exception exception)
            {
                this.Cursor = Cursors.Default;
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlXBLayerCombine", "InitialListID", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void InitialListView()
        {
            try
            {
                this.listViewDist.Items.Clear();
                for (int i = 0; i < this.mStateTable.Rows.Count; i++)
                {
                    this.listViewDist.Items.Add(this.mStateTable.Rows[i]["distcode"].ToString(), this.mStateTable.Rows[i]["distname"].ToString(), 0x5b);
                    ListViewItem item = this.listViewDist.Items[this.mStateTable.Rows[i]["distcode"].ToString()];
                    item.ImageIndex = 0x5b;
                    item.Tag = this.mStateTable.Rows[i];
                    if (this.mStateTable.Rows[i]["editstate"].ToString() == "0")
                    {
                        item.SubItems.Add("未合并");
                        item.Checked = false;
                        item.StateImageIndex = 0;
                    }
                    else if (this.mStateTable.Rows[i]["editstate"].ToString() == "2")
                    {
                        item.SubItems.Add("已合并");
                        item.StateImageIndex = 2;
                    }
                    else if (this.mStateTable.Rows[i]["editstate"].ToString() == "1")
                    {
                        item.SubItems.Add("合并未完成");
                        item.StateImageIndex = 0;
                    }
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlXBLayerCombine", "InitialListView", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        public void InitialValue()
        {
            Exception exception;
            try
            {
                if (((this.mHookHelper != null) && (this.mHookHelper.FocusMap != null)) && (this.mHookHelper.FocusMap.LayerCount != 0))
                {
                    this.mCurItemImageEdit0 = this.repositoryItemImageEdit1;
                    this.mCurItemImageEdit0.Images = this.imageList0;
                    this.mCurItemImageEdit6 = this.repositoryItemImageEdit6;
                    this.mCurItemImageEdit6.Images = this.imageList0;
                    this.simpleButtonInfo.Left = (this.xtraTabControl1.Left + this.xtraTabControl1.Width) - this.simpleButtonInfo.Width;
                    this.simpleButtonInfo.Top = 3;
                    this.simpleButtonRefresh.Left = (this.simpleButtonInfo.Left - this.simpleButtonRefresh.Width) - 4;
                    this.simpleButtonRefresh.Top = 3;
                    this.simpleButtonCombine.Visible = true;
                    this.panelIDList.Visible = false;
                    this.simpleButtonRefresh.Left = (this.simpleButtonInfo.Left - this.simpleButtonRefresh.Width) - 4;
                    this.simpleButtonStop.Left = (this.simpleButtonInfo.Left - this.simpleButtonStop.Width) - 4;
                    this.label2.Text = "";
                    this.simpleButtonCombine.Enabled = false;
                    this.simpleButtonCombine2.Enabled = false;
                    IMap focusMap = this.mHookHelper.FocusMap;
               //     this.mDBAccess = UtilFactory.GetDBAccess("Access");
                    this.mUpdataTable = null;// this.mDBAccess.GetDataTable(this.mDBAccess, "Select * from T_AutoUpdate_Feature");
                    this.mFeatureWorkspace = EditTask.EditWorkspace;
                    if (this.mFeatureWorkspace != null)
                    {
                        if (this.m_EditLayer == null)
                        {
                            this.m_EditLayer = EditTask.EditLayer;
                        }
                        this.m_UnderLayer = EditTask.UnderLayer;
                        this.mEditKindCode = "XB";
                        EditTask.KindCode = "08";
                        GC.Collect();
                        Application.DoEvents();
                        int num = this.m_UnderLayer.FeatureClass.FeatureCount(null);
                        this.label1.Text = "变更小班信息：共计" + num + "个变更班块";
                        IQueryFilter queryFilter = new QueryFilterClass();
                        queryFilter.WhereClause = "(not BHYY is null) and (ltrim(rtrim(BHYY))<>'')";
                        num = this.m_UnderLayer.FeatureClass.FeatureCount(queryFilter);
                        this.label1.Text = string.Concat(new object[] { this.label1.Text, ",已确定变化原因", num, "个变更班块" });
                        queryFilter.WhereClause = "(BHYY is null) or (ltrim(rtrim(BHYY))='')";
                        num = this.m_UnderLayer.FeatureClass.FeatureCount(queryFilter);
                        this.label1.Text = string.Concat(new object[] { this.label1.Text, ",未确定变化原因", num, "个变更班块" });
                        Application.DoEvents();
                        this.label1.Text = this.label1.Text + "\r\n年度小班信息：";
                        num = this.m_EditLayer.FeatureClass.FeatureCount(null);
                        this.label1.Text = string.Concat(new object[] { this.label1.Text, "共计", num, "个小班" });
                        queryFilter.WhereClause = "(not BHYY is null) and (ltrim(rtrim(BHYY))<>'')";
                        num = this.m_EditLayer.FeatureClass.FeatureCount(queryFilter);
                        this.label1.Text = string.Concat(new object[] { this.label1.Text, ",已变更", num, "个小班" });
                        queryFilter.WhereClause = "(BHYY is null) or (ltrim(rtrim(BHYY))='')";
                        num = this.m_EditLayer.FeatureClass.FeatureCount(queryFilter);
                        this.label1.Text = string.Concat(new object[] { this.label1.Text, ",未变更", num, "个小班" });
                        this.panelInfo.Height = 80;
                        GC.Collect();
                        string configValue = UtilFactory.GetConfigOpt().GetConfigValue("CountyLayerName");
                        this.m_CountyLayer = GISFunFactory.LayerFun.FindFeatureLayer(focusMap as IBasicMap, configValue, true);
                        if (this.m_CountyLayer != null)
                        {
                            configValue = UtilFactory.GetConfigOpt().GetConfigValue("TownLayerName");
                            this.m_TownLayer = GISFunFactory.LayerFun.FindFeatureLayer(focusMap as IBasicMap, configValue, true);
                            if (this.m_TownLayer != null)
                            {
                                string name = UtilFactory.GetConfigOpt().GetConfigValue("CountyCodeTableName");
                                this.m_CountyTable = this.mFeatureWorkspace.OpenTable(name);
                                if (this.m_CountyTable != null)
                                {
                                    name = UtilFactory.GetConfigOpt().GetConfigValue("TownCodeTableName");
                                    this.m_TownTable = this.mFeatureWorkspace.OpenTable(name);
                                    if (this.m_TownTable != null)
                                    {
                                      //  IDBAccess dBAccess = UtilFactory.GetDBAccess("Access");
                                        this.mStateTable = null;// dBAccess.GetDataTable(dBAccess, "select * from T_TownXBCombine where distcode like '" + EditTask.DistCode + "%' ORDER BY distcode ASC");
                                        if (this.mStateTable.Rows.Count == 0)
                                        {
                                            string sCmdText = "DELETE * FROM T_TownXBCombine";
                                         //   dBAccess.ExecuteScalar(sCmdText);
                                            int num2 = this.m_TownLayer.FeatureClass.FeatureCount(null);
                                            string str4 = UtilFactory.GetConfigOpt().GetConfigValue("TownFieldCode");
                                            string str5 = UtilFactory.GetConfigOpt().GetConfigValue("TownFieldName");
                                            IQueryFilter filter = new QueryFilterClass();
                                            filter.WhereClause = "";
                                            IQueryFilterDefinition definition = (IQueryFilterDefinition) filter;
                                            definition.PostfixClause = "ORDER BY " + str4;
                                            IFeatureCursor cursor2 = this.m_TownLayer.FeatureClass.Search(filter, false);
                                            IFeature feature = cursor2.NextFeature();
                                            if (feature != null)
                                            {
                                                int index = feature.Fields.FindField(str5);
                                                if (num2 > 0)
                                                {
                                                    while (feature != null)
                                                    {
                                                        int num4 = feature.Fields.FindField(str4);
                                                        string str6 = "";
                                                        if ((feature.Fields.get_Field(num4).Domain != null) && (feature.Fields.get_Field(num4).Domain.Type == esriDomainType.esriDTCodedValue))
                                                        {
                                                            str6 = "";
                                                            try
                                                            {
                                                                ICodedValueDomain domain = (ICodedValueDomain) feature.Fields.get_Field(num4).Domain;
                                                                long num5 = Convert.ToInt64(feature.get_Value(index));
                                                                for (int i = 0; i < domain.CodeCount; i++)
                                                                {
                                                                    if (num5 == Convert.ToInt64(domain.get_Value(i)))
                                                                    {
                                                                        str6 = domain.get_Name(i);
                                                                        goto Label_07A5;
                                                                    }
                                                                }
                                                            }
                                                            catch (Exception exception1)
                                                            {
                                                                exception = exception1;
                                                                str6 = feature.get_Value(num4).ToString();
                                                            }
                                                        }
                                                        else
                                                        {
                                                            str6 = feature.get_Value(num4).ToString();
                                                        }
                                                    Label_07A5:;
                                                        string str7 = "insert into T_TownXBCombine (DistCode,DistName,EditState) values ('" + feature.get_Value(num4).ToString().Trim() + "','" + str6 + "','0' )";
                                                     //   this.mDBAccess.ExecuteScalar(str7);
                                                        feature = cursor2.NextFeature();
                                                    }
                                                }
                                            }
                                        }
                                        this.mStateTable = null;// dBAccess.GetDataTable(dBAccess, "select * from T_TownXBCombine  ORDER BY distcode ASC");
                                        string[] strArray = (this.m_UnderLayer.FeatureClass as IDataset).Name.Split(new char[] { '.' });
                                        string str8 = strArray[strArray.Length - 1];
                                        str8 = str8.Replace("_" + EditTask.TaskYear, "");
                                      //  if (dBAccess.GetDataTable(dBAccess, "select * from T_EditTask  where layername='" + str8 + "' and logiccheckstate = '1' and toplogiccheckstate= '1' ORDER BY ID ASC ").Rows.Count > 0)
                                        {
                                            this.simpleButtonCombine.Enabled = true;
                                            this.simpleButtonCombine2.Enabled = true;
                                        }
                                        this.InitialListView();
                                        this.mSelected = false;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception exception2)
            {
                exception = exception2;
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlXBLayerCombine", "InitialValue", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private IFeatureClass Intersect(IList<IFeatureClass> pFCList, string sFile)
        {
            try
            {
                IFeatureClass class2;
                IQueryFilter filter;
                if ((pFCList == null) || (pFCList.Count < 1))
                {
                    return null;
                }
                IGpValueTableObject obj2 = new GpValueTableObjectClass();
                obj2.SetColumns(1);
                object row = null;
                for (int i = 0; i < pFCList.Count; i++)
                {
                    row = pFCList[i];
                    obj2.AddRow(ref row);
                }
                if (!(Directory.Exists(Path.GetDirectoryName(sFile)) && (".shp" == Path.GetExtension(sFile))))
                {
                    return null;
                }
                ESRI.ArcGIS.Geoprocessor.Geoprocessor geoprocessor = new ESRI.ArcGIS.Geoprocessor.Geoprocessor();
                geoprocessor.OverwriteOutput = true;
                ESRI.ArcGIS.AnalysisTools.Intersect process = new ESRI.ArcGIS.AnalysisTools.Intersect(obj2, sFile);
                IGeoProcessorResult result = (IGeoProcessorResult) geoprocessor.Execute(process, null);
                if (result.Status != esriJobStatus.esriJobSucceeded)
                {
                    return null;
                }
                IGPUtilities utilities = new GPUtilitiesClass();
                utilities.DecodeFeatureLayer(result.GetOutput(0), out class2, out filter);
                return class2;
            }
            catch
            {
                return null;
            }
        }

        private void labelIdentify_Click(object sender, EventArgs e)
        {
            try
            {
                GC.Collect();
                int num = this.m_UnderLayer.FeatureClass.FeatureCount(null);
                this.label1.Text = "变更小班信息：共计" + num + "个变更班块";
                IQueryFilter queryFilter = new QueryFilterClass();
                queryFilter.WhereClause = "(not BHYY is null) and (ltrim(rtrim(BHYY))<>'')";
                num = this.m_UnderLayer.FeatureClass.FeatureCount(queryFilter);
                this.label1.Text = string.Concat(new object[] { this.label1.Text, ",已确定变化原因", num, "个变更班块" });
                queryFilter.WhereClause = "(BHYY is null) or (ltrim(rtrim(BHYY))='')";
                num = this.m_UnderLayer.FeatureClass.FeatureCount(queryFilter);
                this.label1.Text = string.Concat(new object[] { this.label1.Text, ",未确定变化原因", num, "个变更班块" });
                if (num > 0)
                {
                    this.label1.Text = this.label1.Text + ",请进入小班变更修改没有变化原因的班块";
                    this.simpleButtonCombine.Enabled = false;
                    this.simpleButtonCombine2.Enabled = false;
                }
                else
                {
                    this.simpleButtonCombine.Enabled = true;
                    this.simpleButtonCombine2.Enabled = true;
                }
                this.label1.Text = this.label1.Text + "\r\n年度小班信息：";
                num = this.m_EditLayer.FeatureClass.FeatureCount(null);
                this.label1.Text = string.Concat(new object[] { this.label1.Text, "共计", num, "个小班" });
                queryFilter.WhereClause = "(not BHYY is null) and (ltrim(rtrim(BHYY))<>'')";
                num = this.m_EditLayer.FeatureClass.FeatureCount(queryFilter);
                this.label1.Text = string.Concat(new object[] { this.label1.Text, ",已变更", num, "个小班" });
                queryFilter.WhereClause = "(BHYY is null) or (ltrim(rtrim(BHYY))='')";
                num = this.m_EditLayer.FeatureClass.FeatureCount(queryFilter);
                this.label1.Text = string.Concat(new object[] { this.label1.Text, ",未变更", num, "个小班" });
                this.panelInfo.Height = 80;
                GC.Collect();
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlXBLayerCombine", "labelIdentify_Click", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void RefreshList()
        {
            DataRow[] rowArray;
            this.simpleButtonStop.Visible = true;
            this.simpleButtonRefresh.Visible = false;
            this.mUpdataTable = null;// this.mDBAccess.GetDataTable(this.mDBAccess, "Select * from T_AutoUpdate_Feature");
            if (this.xtraTabControl1.SelectedTabPageIndex == 0)
            {
                rowArray = this.mUpdataTable.Select("Update_Type='1'");
                this.labelinfo.Text = "    分割小班" + rowArray.Length + "块";
                this.InitialListID(this.tList, rowArray, this.labelinfo);
            }
            else if (this.xtraTabControl1.SelectedTabPageIndex == 1)
            {
                rowArray = this.mUpdataTable.Select("Update_Type='2'");
                this.labelInfo2.Text = "    替换小班" + rowArray.Length + "块";
                this.InitialListID(this.tList2, rowArray, this.labelInfo2);
            }
            else if (this.xtraTabControl1.SelectedTabPageIndex == 2)
            {
                rowArray = this.mUpdataTable.Select("Update_Type='3'");
                this.labelInfo3.Text = "    新增小班" + rowArray.Length + "块";
                this.InitialListID(this.tList3, rowArray, this.labelInfo3);
            }
            this.simpleButtonStop.Visible = false;
            this.simpleButtonRefresh.Visible = true;
        }

        private void ResetXBLayer()
        {
            Exception exception2;
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.label2.Text = "";
                this.panelInfo2.Visible = true;
                IWorkspace mFeatureWorkspace = this.mFeatureWorkspace as IWorkspace;
                this.label2.Text = "    数据准备...";
                this.label2.Refresh();
                Application.DoEvents();
                ESRI.ArcGIS.Geoprocessor.Geoprocessor geoprocessor = new ESRI.ArcGIS.Geoprocessor.Geoprocessor();
                geoprocessor.OverwriteOutput = true;
                CreateArcSDEConnectionFile process = new CreateArcSDEConnectionFile();
                string str = UtilFactory.GetConfigOpt().RootPath + @"\Temp";
                process.out_folder_path = str;
                string str2 = "sdeconnect.sde";
                process.out_name = str2;
                string str3 = UtilFactory.GetConfigOpt().GetConfigValue2("SqlServer", "DataSource").Split(new char[] { '/' })[0];
                process.server = str3;
                string str4 = UtilFactory.GetConfigOpt().GetConfigValue2("SqlServer", "Service");
                process.service = str4;
                string str5 = UtilFactory.GetConfigOpt().GetConfigValue2("SqlServer", "InitialCatalog");
                process.database = str5;
                string str7 = UtilFactory.GetConfigOpt().GetConfigValue2("SqlServer", "UserID");
                process.username = str7;
                string str8 = UtilFactory.GetConfigOpt().GetConfigValue2("SqlServer", "Password");
                process.password = str8;
                process.save_version_info = "SAVE_VERSION";
                string str11 = UtilFactory.GetConfigOpt().GetConfigValue2("SqlServer", "Version");
                process.version = str11;
                geoprocessor.Execute(process, null);
                string name = UtilFactory.GetConfigOpt().GetConfigValue("XBLayer1") + "_" + ((int.Parse(EditTask.TaskYear) - 1)).ToString();
                string str13 = UtilFactory.GetConfigOpt().GetConfigValue("XBLayer1") + "_" + EditTask.TaskYear;
                IFeatureClass class2 = this.mFeatureWorkspace.OpenFeatureClass(name);
                IFeatureClass class3 = this.mFeatureWorkspace.OpenFeatureClass(str13);
                if (class3.FeatureCount(null) > 0)
                {
                    this.label2.Text = "    清空资源数据...";
                    this.label2.Refresh();
                    Application.DoEvents();
                    try
                    {
                        (class3 as IDataset).Workspace.ExecuteSQL("delete from " + (class3 as IDataset).Name);
                    }
                    catch (Exception exception)
                    {
                        this.label2.Text = "    清空资源数据失败--" + exception.Message;
                        this.label2.Refresh();
                        Application.DoEvents();
                    }
                }
                this.label2.Text = "    加载年度小班数据...";
                this.label2.Refresh();
                Append append = new Append();
                string str14 = str + @"\" + str2 + @"\" + str5 + @".DBO.FOREST\" + str5 + ".DBO." + name;
                append.inputs = str14;
                append.target = str + @"\" + str2 + @"\" + str5 + @".DBO.FOREST\" + str5 + ".DBO." + str13;
                append.schema_type = "NO_TEST";
                try
                {
                    string str15 = geoprocessor.Execute(append, null).ToString();
                    this.label2.Text = "    加载年度小班数据完成";
                    this.label2.Refresh();
                }
                catch (Exception exception3)
                {
                    exception2 = exception3;
                    this.label2.Text = "    加载年度小班数据出错";
                    this.label2.Refresh();
                    MessageBox.Show(exception2.Message, "重置数据", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                this.label2.Text = "    清空" + EditTask.TaskYear + "年度小班变化原因与时间...";
                this.label2.Refresh();
                Application.DoEvents();
                string sqlStmt = "update " + str13 + " set BHYY=NULL,GXSJ=NULL,XI_BAN=NULL,DT_SRC=NULL,BAK1=NULL,BAK2=NULL";
                (class3 as IDataset).Workspace.ExecuteSQL(sqlStmt);
                IQueryFilter queryFilter = new QueryFilterClass();
                queryFilter.WhereClause = "BHYY<>NULL or GXSJ<>NULL or XI_BAN<>NULL or DT_SRC<>NULL or BAK1<>NULL or BAK2<>NULL";
                int num = class3.FeatureCount(queryFilter);
                if (num > 0)
                {
                    this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlXBLayerCombine", "AutoUpdate", "0", "", "清空变化原因与时间出错", "", "", "");
                    this.label2.Text = "    清空" + EditTask.TaskYear + "年度小班变化原因与时间出错";
                    Application.DoEvents();
                }
                else if (num == 0)
                {
                    this.label2.Text = "    清空" + EditTask.TaskYear + "年度小班变化原因与时间完成";
                    Application.DoEvents();
                }
                this.label2.Text = "    重置年度小班数据完成";
                this.label2.Refresh();
                Application.DoEvents();
                this.Cursor = Cursors.Default;
            }
            catch (Exception exception4)
            {
                exception2 = exception4;
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlXBLayerCombine", "ResetXBLayer", exception2.GetHashCode().ToString(), exception2.Source, exception2.Message, "", "", "");
                this.Cursor = Cursors.Default;
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.groupControlDistConbine.Visible = false;
            this.panelInfo2.Visible = false;
        }

        private void simpleButtonCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定恢复年度小班内容为上一年度数据?", "年度更新", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.panelLog.Visible = false;
                this.label2.Text = "";
                this.panelInfo2.Visible = true;
                this.ResetXBLayer();
               // IDBAccess dBAccess = UtilFactory.GetDBAccess("Access");
                string sCmdText = "DELETE * FROM T_AutoUpdate_Feature";
            //    dBAccess.ExecuteScalar(sCmdText);
              //  this.mStateTable = this.mDBAccess.GetDataTable(this.mDBAccess, "Select * from T_TownXBCombine");
                for (int i = 0; i < this.mStateTable.Rows.Count; i++)
                {
                    sCmdText = "update T_TownXBCombine set EditState='0' where distcode= '" + this.mStateTable.Rows[i]["distcode"].ToString() + "'";
                 //   dBAccess.ExecuteScalar(sCmdText);
                }
                this.InitialListView();
                GC.Collect();
                int num2 = this.m_UnderLayer.FeatureClass.FeatureCount(null);
                this.label1.Text = "变更小班信息：共计" + num2 + "个变更班块";
                IQueryFilter queryFilter = new QueryFilterClass();
                queryFilter.WhereClause = "(not BHYY is null) and (ltrim(rtrim(BHYY))<>'')";
                num2 = this.m_UnderLayer.FeatureClass.FeatureCount(queryFilter);
                this.label1.Text = string.Concat(new object[] { this.label1.Text, ",已确定变化原因", num2, "个变更班块" });
                queryFilter.WhereClause = "(BHYY is null) or (ltrim(rtrim(BHYY))='')";
                num2 = this.m_UnderLayer.FeatureClass.FeatureCount(queryFilter);
                this.label1.Text = string.Concat(new object[] { this.label1.Text, ",未确定变化原因", num2, "个变更班块" });
                this.label1.Text = this.label1.Text + "\r\n年度小班信息：";
                num2 = this.m_EditLayer.FeatureClass.FeatureCount(null);
                this.label1.Text = string.Concat(new object[] { this.label1.Text, "共计", num2, "个小班" });
                queryFilter.WhereClause = "(not BHYY is null) and (ltrim(rtrim(BHYY))<>'')";
                num2 = this.m_EditLayer.FeatureClass.FeatureCount(queryFilter);
                this.label1.Text = string.Concat(new object[] { this.label1.Text, ",已变更", num2, "个小班" });
                queryFilter.WhereClause = "(BHYY is null) or (ltrim(rtrim(BHYY))='')";
                num2 = this.m_EditLayer.FeatureClass.FeatureCount(queryFilter);
                this.label1.Text = string.Concat(new object[] { this.label1.Text, ",未变更", num2, "个小班" });
                this.panelInfo.Height = 80;
                GC.Collect();
            }
        }

        private void simpleButtonCheck_Click(object sender, EventArgs e)
        {
            try
            {
                string str4;
                this.Cursor = Cursors.WaitCursor;
                bool flag = true;
                this.panelLog.Visible = true;
                this.panelLog.BringToFront();
                this.labelprogress.Text = "    检查是否有重叠相交小班...";
                this.labelprogress.Visible = true;
                IList<IFeatureClass> pFCList = new List<IFeatureClass>();
                pFCList.Add(this.m_UnderLayer.FeatureClass);
                string str = UtilFactory.GetConfigOpt().RootPath + @"\" + UtilFactory.GetConfigOpt().GetConfigValue("TempPath");
                string sFile = str + @"\xbintersect.shp";
                if (File.Exists(str + "xbintersect.shp"))
                {
                    File.Delete(str + "xbintersect.shp");
                }
                if (File.Exists(str + "xbintersect.dbf"))
                {
                    File.Delete(str + "xbintersect.dbf");
                }
                if (File.Exists(str + "xbintersect.sbn"))
                {
                    File.Delete(str + "xbintersect.sbn");
                }
                if (File.Exists(str + "xbintersect.sbx"))
                {
                    File.Delete(str + "xbintersect.sbx");
                }
                if (File.Exists(str + "xbintersect.shx"))
                {
                    File.Delete(str + "xbintersect.shx");
                }
                if (File.Exists(str + "xbintersect.shp.xml"))
                {
                    File.Delete(str + "xbintersect.shp.xml");
                }
                if (File.Exists(str + "xbintersect.prj"))
                {
                    File.Delete(str + "xbintersect.prj");
                }
                this.richTextBox.Text = "计算变更小班图层相交班块";
                Application.DoEvents();
                IFeatureClass class2 = this.Intersect(pFCList, sFile);
                this.Cursor = Cursors.Default;
                int num = class2.FeatureCount(null);
                if (num > 0)
                {
                    if (this.richTextBox.Text != "")
                    {
                        this.richTextBox.Text = string.Concat(new object[] { this.richTextBox.Text, "\n变更小班图层有", num, "个相交班块" });
                    }
                    else
                    {
                        this.richTextBox.Text = "变更小班图层有" + num + "个相交班块";
                    }
                    this.richTextBox.Refresh();
                    this.simpleButtonCombine.Enabled = false;
                    this.simpleButtonCombine2.Enabled = false;
                    flag = false;
                }
                else
                {
                    if (this.richTextBox.Text != "")
                    {
                        this.richTextBox.Text = this.richTextBox.Text + "\n变更小班图层无相交要素";
                    }
                    else
                    {
                        this.richTextBox.Text = "变更小班图层无相交要素";
                    }
                    this.richTextBox.Refresh();
                }
                IFeatureClass featureClass = this.m_UnderLayer.FeatureClass;
                IQueryFilter queryFilter = new QueryFilterClass();
                queryFilter.WhereClause = "ltrim(rtrim(bhyy))='' or bhyy is null";
                int num2 = featureClass.FeatureCount(queryFilter);
                if (num2 == 0)
                {
                    if (this.richTextBox.Text != "")
                    {
                        this.richTextBox.Text = this.richTextBox.Text + "\n变更小班图层无变化原因未填写的班块";
                    }
                    else
                    {
                        this.richTextBox.Text = "变更小班图层无变化原因未填写的班块";
                    }
                }
                else if (this.richTextBox.Text != "")
                {
                    this.richTextBox.Text = string.Concat(new object[] { this.richTextBox.Text, "\n变更小班图层有", num2, "个变化原因未填写的班块" });
                }
                else
                {
                    this.richTextBox.Text = "变更小班图层有" + num2 + "个变化原因未填写的班块";
                }
                this.richTextBox.Refresh();
                if (num2 > 0)
                {
                    this.simpleButtonCombine.Enabled = false;
                    this.simpleButtonCombine2.Enabled = false;
                    flag = false;
                }
                this.simpleButtonCombine.Enabled = flag;
                this.simpleButtonCombine2.Enabled = flag;
                string[] strArray = (this.m_UnderLayer.FeatureClass as IDataset).Name.Split(new char[] { '.' });
                string str3 = strArray[strArray.Length - 1];
                str3 = str3.Replace("_" + EditTask.TaskYear, "");
                if (this.simpleButtonCombine.Enabled)
                {
                    this.labelprogress.Text = "    变更小班校验完成--通过校验，可做年度变更小班更新。";
                    str4 = "update T_EditTask  set logiccheckstate='1' where layername = '" + str3 + "'";
                  //  this.mDBAccess.ExecuteScalar(str4);
                    str4 = "update T_EditTask  set toplogiccheckstate='1' where layername = '" + str3 + "'";
                 //   this.mDBAccess.ExecuteScalar(str4);
                }
                else
                {
                    this.labelprogress.Text = "    变更小班校验完成--未通过校验，请进入小班变更编辑修改后再做更新。";
                    str4 = "update T_EditTask  set logiccheckstate='0' where layername = '" + str3 + "'";
                   // this.mDBAccess.ExecuteScalar(str4);
                    str4 = "update T_EditTask  set toplogiccheckstate='0' where layername = '" + str3 + "'";
                   // this.mDBAccess.ExecuteScalar(str4);
                }
                this.Cursor = Cursors.Default;
            }
            catch (Exception exception)
            {
                this.Cursor = Cursors.Default;
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlXBLayerCombine", "simpleButtonCheck_Click", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void simpleButtonCombine_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.panelLog.Visible = false;
                this.panelInfo2.Visible = true;
                this.label2.Text = "      正在更新...";
                Application.DoEvents();
                AutoUpdateSub sub = new AutoUpdateSub(this.mHookHelper.FocusMap);
                this.m_EditLayer = EditTask.EditLayer;
                if (sub.AutoUpdate(this.m_EditLayer, this.m_UnderLayer, this.label2))
                {
                    this.label2.Text = "      更新成功";
                }
                else
                {
                    this.label2.Text = "      更新失败";
                }
                this.mUpdataTable = null;// this.mDBAccess.GetDataTable(this.mDBAccess, "Select * from T_AutoUpdate_Feature");
                this.label2.Text = this.label2.Text + ", 更新小班总数" + this.mUpdataTable.Rows.Count;
                GC.Collect();
                try
                {
                    if (((Process.GetCurrentProcess().PrivateMemorySize64 / 0x400L) / 0x400L) > 250L)
                    {
                        Process process = new Process();
                        ProcessStartInfo info = new ProcessStartInfo(Application.StartupPath + @"\MemoryClean.exe");
                        process.StartInfo = info;
                        process.StartInfo.UseShellExecute = false;
                        process.Start();
                    }
                }
                catch (Exception)
                {
                }
                Application.DoEvents();
                if (this.panelInfo.Visible)
                {
                    GC.Collect();
                    int num = this.m_UnderLayer.FeatureClass.FeatureCount(null);
                    this.label1.Text = "变更小班信息：共计" + num + "个变更班块";
                    IQueryFilter queryFilter = new QueryFilterClass();
                    queryFilter.WhereClause = "(not BHYY is null) and (ltrim(rtrim(BHYY))<>'')";
                    num = this.m_UnderLayer.FeatureClass.FeatureCount(queryFilter);
                    this.label1.Text = string.Concat(new object[] { this.label1.Text, ",已确定变化原因", num, "个变更班块" });
                    queryFilter.WhereClause = "(BHYY is null) or (ltrim(rtrim(BHYY))='')";
                    num = this.m_UnderLayer.FeatureClass.FeatureCount(queryFilter);
                    this.label1.Text = string.Concat(new object[] { this.label1.Text, ",未确定变化原因", num, "个变更班块" });
                    this.label1.Text = this.label1.Text + "\r\n年度小班信息：";
                    num = this.m_EditLayer.FeatureClass.FeatureCount(null);
                    this.label1.Text = string.Concat(new object[] { this.label1.Text, "共计", num, "个小班" });
                    queryFilter.WhereClause = "(not BHYY is null) and (ltrim(rtrim(BHYY))<>'')";
                    num = this.m_EditLayer.FeatureClass.FeatureCount(queryFilter);
                    this.label1.Text = string.Concat(new object[] { this.label1.Text, ",已变更", num, "个小班" });
                    queryFilter.WhereClause = "(BHYY is null) or (ltrim(rtrim(BHYY))='')";
                    num = this.m_EditLayer.FeatureClass.FeatureCount(queryFilter);
                    this.label1.Text = string.Concat(new object[] { this.label1.Text, ",未变更", num, "个小班" });
                    this.panelInfo.Height = 80;
                    GC.Collect();
                }
                this.Cursor = Cursors.Default;
            }
            catch (Exception exception)
            {
                this.Cursor = Cursors.Default;
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlXBLayerCombine", "simpleButtonCombine_Click", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void simpleButtonCombine2_Click(object sender, EventArgs e)
        {
            this.panelLog.Visible = false;
            this.groupControlDistConbine.Visible = true;
            this.InitialListView();
        }

        private void simpleButtonDistCombine_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.panelLog.Visible = false;
                this.panelInfo2.Visible = true;
                this.label2.Text = "      正在更新...";
                Application.DoEvents();
                AutoUpdateSub sub = new AutoUpdateSub(this.mHookHelper.FocusMap);
                this.m_EditLayer = EditTask.EditLayer;
                bool flag = true;
                for (int i = 0; i < this.listViewDist.Items.Count; i++)
                {
                    if (this.listViewDist.Items[i].StateImageIndex == 1)
                    {
                        string str;
                        DataRow tag = this.listViewDist.Items[i].Tag as DataRow;
                        this.label2.Text = "      正在更新" + tag["distname"].ToString() + "xiaoban ";
                        Application.DoEvents();
                        if (sub.UpdateDist(this.m_EditLayer, this.m_UnderLayer, tag["distcode"].ToString(), tag["distname"].ToString(), this.label2))
                        {
                            this.label2.Text = "      " + tag["distname"].ToString() + "更新成功";
                            this.listViewDist.Items[i].SubItems[1].Text = "合并成功";
                            str = "update T_TownXBCombine set EditState='2' where DistCode='" + tag["DistCode"].ToString().Trim() + "' ";
                          //  this.mDBAccess.ExecuteScalar(str);
                            this.mStateTable = null;// this.mDBAccess.GetDataTable(this.mDBAccess, "Select * from T_TownXBCombine");
                            this.listViewDist.Items[i].Tag = this.mStateTable.Rows[i];
                            this.listViewDist.Items[i].StateImageIndex = 2;
                            this.listViewDist.Refresh();
                            Application.DoEvents();
                        }
                        else
                        {
                            this.label2.Text = "      " + tag["distname"].ToString() + "更新失败";
                            this.listViewDist.Items[i].SubItems[1].Text = "合并失败";
                            str = "update T_TownXBCombine set EditState='1' where DistCode='" + tag["DistCode"].ToString().Trim() + "' ";
                          //  this.mDBAccess.ExecuteScalar(str);
                            this.mStateTable = null;// this.mDBAccess.GetDataTable(this.mDBAccess, "Select * from T_TownXBCombine");
                            this.listViewDist.Items[i].Tag = this.mStateTable.Rows[i];
                            flag = false;
                            break;
                        }
                    }
                }
                this.mStateTable = null;// this.mDBAccess.GetDataTable(this.mDBAccess, "Select * from T_TownXBCombine");
                this.mUpdataTable = null;// this.mDBAccess.GetDataTable(this.mDBAccess, "Select * from T_AutoUpdate_Feature");
                if (flag)
                {
                    this.label2.Text = "      更新完成，更新小班总数" + this.mUpdataTable.Rows.Count;
                }
                else
                {
                    this.label2.Text = "      更新失败，更新小班总数" + this.mUpdataTable.Rows.Count;
                }
                if (this.panelInfo.Visible)
                {
                    GC.Collect();
                    int num2 = this.m_UnderLayer.FeatureClass.FeatureCount(null);
                    this.label1.Text = "变更小班信息：共计" + num2 + "个变更班块";
                    IQueryFilter queryFilter = new QueryFilterClass();
                    queryFilter.WhereClause = "(not BHYY is null) and (ltrim(rtrim(BHYY))<>'')";
                    num2 = this.m_UnderLayer.FeatureClass.FeatureCount(queryFilter);
                    this.label1.Text = string.Concat(new object[] { this.label1.Text, ",已确定变化原因", num2, "个变更班块" });
                    queryFilter.WhereClause = "(BHYY is null) or (ltrim(rtrim(BHYY))='')";
                    num2 = this.m_UnderLayer.FeatureClass.FeatureCount(queryFilter);
                    this.label1.Text = string.Concat(new object[] { this.label1.Text, ",未确定变化原因", num2, "个变更班块" });
                    this.label1.Text = this.label1.Text + "\r\n年度小班信息：";
                    num2 = this.m_EditLayer.FeatureClass.FeatureCount(null);
                    this.label1.Text = string.Concat(new object[] { this.label1.Text, "共计", num2, "个小班" });
                    queryFilter.WhereClause = "(not BHYY is null) and (ltrim(rtrim(BHYY))<>'')";
                    num2 = this.m_EditLayer.FeatureClass.FeatureCount(queryFilter);
                    this.label1.Text = string.Concat(new object[] { this.label1.Text, ",已变更", num2, "个小班" });
                    queryFilter.WhereClause = "(BHYY is null) or (ltrim(rtrim(BHYY))='')";
                    num2 = this.m_EditLayer.FeatureClass.FeatureCount(queryFilter);
                    this.label1.Text = string.Concat(new object[] { this.label1.Text, ",未变更", num2, "个小班" });
                    this.panelInfo.Height = 80;
                    GC.Collect();
                }
                this.Cursor = Cursors.Default;
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlXBLayerCombine", "simpleButtonDistCombine_Click", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                this.Cursor = Cursors.Default;
            }
        }

        private void simpleButtonInfo_Click(object sender, EventArgs e)
        {
            try
            {
                TreeListNode mNodeList = this.mNodeList;
                if (this.xtraTabControl1.SelectedTabPageIndex == 0)
                {
                    this.mQueryList = this.tList.Tag as ArrayList;
                }
                else if (this.xtraTabControl1.SelectedTabPageIndex == 1)
                {
                    this.mQueryList = this.tList2.Tag as ArrayList;
                }
                else if (this.xtraTabControl1.SelectedTabPageIndex == 2)
                {
                    this.mQueryList = this.tList3.Tag as ArrayList;
                }
                int selectedTabPageIndex = this.xtraTabControl1.SelectedTabPageIndex;
                if (this.mQueryList != null)
                {
                    IFeature tag = mNodeList.Tag as IFeature;
                    this.mQueryResult.InitialQueryInfo(this.mHookHelper, this.m_EditLayer, this.mQueryList, null, this.sDesKeyField, tag, null);
                    this.mDockPanel.Visibility = DockVisibility.Visible;
                    if ((this.mDockPanel.Controls.Count > 0) && (this.mDockPanel.Controls[0].Controls.Count > 0))
                    {
                        XtraTabControl control = this.mDockPanel.Controls[0].Controls[0] as XtraTabControl;
                        if (control != null)
                        {
                            control.TabPages[selectedTabPageIndex].PageVisible = true;
                            control.TabPages[selectedTabPageIndex].Text = this.xtraTabControl1.SelectedTabPage.Text;
                            control.SelectedTabPage = control.TabPages[0];
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
            this.RefreshList();
        }

        private void simpleButtonResult_Click(object sender, EventArgs e)
        {
          //  this.mUpdataTable = this.mDBAccess.GetDataTable(this.mDBAccess, "Select * from T_AutoUpdate_Feature");
            this.panelIDList.Visible = true;
            this.panelIDList.BringToFront();
            Application.DoEvents();
            this.xtraTabControl1.SelectedTabPageIndex = 0;
        }

        private void simpleButtonStop_Click(object sender, EventArgs e)
        {
            this.mStopFlag = true;
        }

        private void tList_FocusedColumnChanged(object sender, DevExpress.XtraTreeList.FocusedColumnChangedEventArgs e)
        {
            this.columnlist = e.Column.AbsoluteIndex;
        }

        private void tList_FocusedNodeChanged(object sender, FocusedNodeChangedEventArgs e)
        {
            this.mNodeList = e.Node;
        }

        private void tList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            TreeList list = sender as TreeList;
            if (list.Selection.Count > 0)
            {
                IFeature tag = list.Selection[0].Tag as IFeature;
                if (tag != null)
                {
                    GISFunFactory.FeatureFun.ZoomToFeature(this.mHookHelper.FocusMap, tag);
                    (this.m_EditLayer as IFeatureSelection).Clear();
                    this.mHookHelper.FocusMap.SelectFeature(this.m_EditLayer, tag);
                }
            }
        }

        private void xtraTabControl1_SelectedPageChanged(object sender, TabPageChangedEventArgs e)
        {
            if (this.xtraTabControl1.SelectedTabPageIndex == 0)
            {
                this.labelinfo.Visible = true;
                this.labelInfo2.Visible = false;
                this.labelInfo3.Visible = false;
            }
            else if (this.xtraTabControl1.SelectedTabPageIndex == 1)
            {
                this.labelinfo.Visible = false;
                this.labelInfo2.Visible = true;
                this.labelInfo3.Visible = false;
            }
            else if (this.xtraTabControl1.SelectedTabPageIndex == 2)
            {
                this.labelinfo.Visible = false;
                this.labelInfo2.Visible = false;
                this.labelInfo3.Visible = true;
            }
            this.RefreshList();
        }
    }
}

