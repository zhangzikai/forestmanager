namespace DataEdit
{
    using DevExpress.Utils;
    using DevExpress.XtraBars;
    using DevExpress.XtraEditors;
    using DevExpress.XtraTreeList;
    using DevExpress.XtraTreeList.Columns;
    using DevExpress.XtraTreeList.Nodes;
    using ESRI.ArcGIS.Carto;
    using ESRI.ArcGIS.Controls;
    using ESRI.ArcGIS.DataManagementTools;
    using ESRI.ArcGIS.Geodatabase;
    using ESRI.ArcGIS.Geoprocessor;
    using FormBase;
    using FunFactory;
    using GDB.SQLServerExpress.vTasks.Forest;
    using Microsoft.SqlServer.Management.Common;
    using Microsoft.SqlServer.Management.Smo;
    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Windows.Forms;
    using TaskManage;
    using Utilities;

    public class FormLoadSpatialData : FormBase3
    {
        private IContainer components = null;
        private DevExpress.Utils.ImageCollection imageCollection1;
        private ImageList imageList1;
        internal Label label1;
        internal Label labelCatalog;
        private LabelControl labelControl8;
        private LabelControl labelLog;
        private IGroupLayer m_DCGroupLayer;
        private IFeatureLayer m_EditLayer;
        private IGroupLayer m_TempGroupLayer;
        private const string mClassName = "DataEdit.FormLoadSpatialData";
        private int mDaiHao = 0;
    
        private DataTable mDCDataTable;
        private DataTable mDCDataTable2;
        private IFeatureClass mDCFeatureClass;
        private IFeatureLayer mDCFeatureLayer;
        private ITable mDCTable;
        private string mEditKind = "小班";
        private string mEditKind2 = "xiaoban";
        private ErrorOpt mErrOpt = UtilFactory.GetErrorOpt();
        private IFeatureWorkspace mFeatureWorkspace;
        private DataTable mFieldTable;
        private HookHelper mHookHelper = null;
        private DataTable mInputTable;
        private bool mIsBatch = true;
        private string mKeyFieldName = "";
        private DataTable mKindTable;
        private ArrayList mLayerList = null;
        private ArrayList mLayerList2 = null;
        private IFeatureWorkspace mNewFeatureWorkspace;
        private BarButtonItem mParButton;
        private IFeatureLayer mPointFeatureLayer;
        private DataTable mPointTable;
        private DataTable mPointTable2;
        private IFeatureLayer mPolyFeatureLayer;
        private DataTable mPolyTable;
        private ArrayList mRangeList = null;
        private bool mSelected = false;
        private DataTable mSelPointTable;
        private string mSubSysName = UtilFactory.GetConfigOpt().GetSystemName();
        private IFeatureLayer mXBLayer;
        private const string myClassName = "数据导入";
        private Panel panel1;
        private Panel panel2;
        private Panel panel8;
        private Panel panel9;
        private Panel panelLog;
        private RichTextBox richTextBox;
        private SimpleButton simpleButtonBack;
        private SimpleButton simpleButtonClose;
        private SimpleButton simpleButtonLoadData;
        private SimpleButton simpleButtonOK;
        private SimpleButton simpleButtonSelect;
        private string SubID = "";
        private TreeList tListCatalog;
        private TreeListColumn treeListColumn3;
        private TreeListColumn treeListColumn4;
        private TextEdit txt_year;

        public FormLoadSpatialData()
        {
            this.InitializeComponent();
        }

        private bool CheckDataBase()
        {
            try
            {
                if (string.IsNullOrEmpty(this.txt_year.Text))
                {
                    XtraMessageBox.Show("请填写年份！", "空间数据加载");
                    this.mNewFeatureWorkspace = null;
                    return false;
                }
                if (this.txt_year.Text.Trim().Length != 4)
                {
                    XtraMessageBox.Show("请输入正确年度", "空间数据加载");
                    this.mNewFeatureWorkspace = null;
                    return false;
                }
                if (this.txt_year.Text.Trim() == EditTask.TaskYear)
                {
                    XtraMessageBox.Show("请输入非当前年度", "空间数据加载");
                    this.mNewFeatureWorkspace = null;
                    return false;
                }
                string sDataSource = UtilFactory.GetConfigOpt().GetConfigValue2("SqlServer", "DataSource");
                string sService = UtilFactory.GetConfigOpt().GetConfigValue2("SqlServer", "Service");
                string sInitialCatalog = UtilFactory.GetConfigOpt().GetConfigValue2("SqlServer", "InitialCatalog");
                string sVersion = UtilFactory.GetConfigOpt().GetConfigValue2("SqlServer", "Version");
                string sUserID = UtilFactory.GetConfigOpt().GetConfigValue2("SqlServer", "UserID");
                string sPassword = UtilFactory.GetConfigOpt().GetConfigValue2("SqlServer", "Password");
                sInitialCatalog = sInitialCatalog.Replace(EditTask.TaskYear, this.txt_year.Text.Trim());
                this.mNewFeatureWorkspace = GISFunFactory.WorkspaceFun.GetFeatureWorkspace(WorkspaceSource.esriWSSdeWorkspaceFactory, sDataSource, sService, sInitialCatalog, sVersion, sUserID, sPassword, false);
                if (this.mNewFeatureWorkspace != null)
                {
                    return true;
                }
                XtraMessageBox.Show("年度输入错误，无指定年度数据库，数据库连接失败。", "空间数据加载");
                return false;
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate("DataEdit.FormLoadSpatialData", "DataEdit.FormLoadSpatialData", "CheckDataBase", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                return false;
            }
        }

        private int CheckHasData(IDataset pDataset, string datakind)
        {
            try
            {
                bool flag = false;
                IEnumDataset subsets = pDataset.Subsets;
                for (IDataset dataset2 = subsets.Next(); dataset2 != null; dataset2 = subsets.Next())
                {
                    IFeatureClass class2 = dataset2 as IFeatureClass;
                    if (class2.FeatureCount(null) > 0)
                    {
                        flag = true;
                        break;
                    }
                }
                if (flag)
                {
                    DialogResult result = XtraMessageBox.Show(this, datakind + "数据已存在是否重新加载？", "空间数据加载", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        return 1;
                    }
                    if ((result != DialogResult.No) && (result == DialogResult.Cancel))
                    {
                        return 3;
                    }
                    return 2;
                }
                return 0;
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate("DataEdit.FormLoadSpatialData", "DataEdit.FormLoadSpatialData", "CheckHasData", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                return 2;
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

        private void DoLoadData()
        {
            Exception exception;
            try
            {
                object obj2;
                this.panelLog.Visible = true;
                this.panelLog.BringToFront();
                this.simpleButtonBack.Visible = true;
                this.simpleButtonLoadData.Visible = false;
                this.labelCatalog.Visible = false;
                this.tListCatalog.Visible = false;
                this.labelLog.Text = "准备加载空间数据库 ...";
                this.labelLog.Refresh();
                this.richTextBox.Text = "";
                Application.DoEvents();
                IWorkspace mFeatureWorkspace = this.mFeatureWorkspace as IWorkspace;
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
                string str12 = "tsdeconnect.sde";
                process.out_name = str12;
                string str13 = str5.Replace(EditTask.TaskYear, this.txt_year.Text.Trim());
                process.database = str13;
                geoprocessor.Execute(process, null);
                Application.DoEvents();
                this.labelLog.Text = "加载基础地理数据...";
                this.labelLog.Refresh();
                IDataset dataset = (IDataset) (this.mFeatureWorkspace as IWorkspace);
                IWorkspaceName fullName = (IWorkspaceName) dataset.FullName;
                IFeatureDatasetName name2 = new FeatureDatasetNameClass();
                IDatasetName name3 = (IDatasetName) name2;
                name3.WorkspaceName = fullName;
                name3.Name = "BASE";
                IDataset mNewFeatureWorkspace = (IDataset) this.mNewFeatureWorkspace;
                IWorkspaceName name4 = (IWorkspaceName) mNewFeatureWorkspace.FullName;
                IFeatureDatasetName name5 = new FeatureDatasetNameClass();
                IDatasetName name6 = (IDatasetName) name5;
                name6.WorkspaceName = name4;
                name6.Name = "BASE";
                IDataset pDataset = this.mNewFeatureWorkspace.OpenFeatureDataset("BASE");
                IDataset dataset4 = this.mFeatureWorkspace.OpenFeatureDataset("BASE");
                int num = this.CheckHasData(pDataset, "基础地理数据");
                IEnumDataset subsets = pDataset.Subsets;
                IDataset dataset6 = subsets.Next();
                switch (num)
                {
                    case 0:
                    case 1:
                        while (dataset6 != null)
                        {
                            IFeatureClass class2 = dataset6 as IFeatureClass;
                            if (class2.FeatureCount(null) > 0)
                            {
                                this.richTextBox.AppendText("\n清空基础地理数据[" + dataset6.Name + "]");
                                dataset6.Workspace.ExecuteSQL("delete from " + dataset6.Name);
                            }
                            dataset6 = subsets.Next();
                        }
                        break;

                    case 2:
                        goto Label_054D;

                    case 3:
                        return;
                }
                IEnumDataset dataset7 = dataset4.Subsets;
                for (IDataset dataset8 = dataset7.Next(); dataset8 != null; dataset8 = dataset7.Next())
                {
                    Append append = new Append();
                    string[] strArray = dataset8.Name.Split(new char[] { '.' });
                    string str14 = strArray[strArray.Length - 1];
                    string str15 = str14;
                    IFeatureClass class3 = this.mFeatureWorkspace.OpenFeatureClass(str14);
                    IFeatureClass class4 = this.mNewFeatureWorkspace.OpenFeatureClass(str15);
                    append.inputs = str + @"\" + str2 + @"\" + str5 + @".DBO.BASE\" + str5 + ".DBO." + str14;
                    append.target = str + @"\" + str12 + @"\" + str13 + @".DBO.BASE\" + str13 + ".DBO." + str15;
                    append.schema_type = "NO_TEST";
                    this.richTextBox.AppendText("\n加载基础地理数据[" + class4.AliasName + "]");
                    Application.DoEvents();
                    geoprocessor.Execute(append, null);
                    obj2 = null;
                    this.richTextBox.AppendText("\n" + geoprocessor.GetMessages(ref obj2));
                }
            Label_054D:
                this.labelLog.Text = "加载资源数据...";
                this.labelLog.Refresh();
                Application.DoEvents();
                this.richTextBox.AppendText("\n加载本底小班数据...");
                string name = UtilFactory.GetConfigOpt().GetConfigValue("XBLayer1") + "_" + EditTask.TaskYear;
                string str18 = UtilFactory.GetConfigOpt().GetConfigValue("XBLayer1") + "_" + ((int.Parse(this.txt_year.Text.Trim()) - 1)).ToString();
                IFeatureClass class5 = this.mFeatureWorkspace.OpenFeatureClass(name);
                IFeatureClass class6 = this.mNewFeatureWorkspace.OpenFeatureClass(str18);
                if (class6.FeatureCount(null) > 0)
                {
                    this.richTextBox.AppendText("\n清空资源数据[" + class6.AliasName + "]");
                    this.richTextBox.Refresh();
                    Application.DoEvents();
                    (class6 as IDataset).Workspace.ExecuteSQL("delete from " + (class6 as IDataset).Name);
                }
                Append append2 = new Append();
                string str19 = str + @"\" + str2 + @"\" + str5 + @".DBO.FOREST\" + str5 + ".DBO." + name;
                append2.inputs = str19;
                append2.target = str + @"\" + str12 + @"\" + str13 + @".DBO.FOREST\" + str13 + ".DBO." + str18;
                append2.schema_type = "NO_TEST";
                try
                {
                    string str16 = geoprocessor.Execute(append2, null).ToString();
                    obj2 = null;
                    this.richTextBox.AppendText("\n" + geoprocessor.GetMessages(ref obj2));
                }
                catch (Exception exception1)
                {
                    exception = exception1;
                    MessageBox.Show(exception.Message, "加载数据", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                string str20 = UtilFactory.GetConfigOpt().GetConfigValue("XBLayer1") + "_" + this.txt_year.Text.Trim();
                class6 = this.mNewFeatureWorkspace.OpenFeatureClass(str20);
                if (class6.FeatureCount(null) > 0)
                {
                    this.richTextBox.AppendText("\n清空资源数据[" + class6.AliasName + "]");
                    Application.DoEvents();
                    (class6 as IDataset).Workspace.ExecuteSQL("delete from " + (class6 as IDataset).Name);
                }
                append2.target = str + @"\" + str12 + @"\" + str13 + @".DBO.FOREST\" + str13 + ".DBO." + str20;
                try
                {
                    object obj3 = geoprocessor.Execute(append2, null);
                    obj2 = null;
                    this.richTextBox.AppendText("\n" + geoprocessor.GetMessages(ref obj2));
                }
                catch (Exception exception2)
                {
                    exception = exception2;
                    MessageBox.Show(exception.Message, "加载数据", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                IWorkspaceEdit edit = this.mNewFeatureWorkspace as IWorkspaceEdit;
                edit.StartEditing(false);
                edit.StartEditOperation();
                string sqlStmt = "update " + str20 + " set BHYY=NULL,GXSJ=NULL,XI_BAN=NULL,DT_SRC=NULL,BAK1=NULL,BAK2=NULL";
                (class6 as IDataset).Workspace.ExecuteSQL(sqlStmt);
                try
                {
                    edit.StopEditOperation();
                }
                catch (Exception exception3)
                {
                    exception = exception3;
                    MessageBox.Show(exception.Message, "加载数据", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    edit.StopEditOperation();
                }
                edit.StopEditing(true);
                IQueryFilter queryFilter = new QueryFilterClass();
                queryFilter.WhereClause = "BHYY<>NULL or GXSJ<>NULL or XI_BAN<>NULL or DT_SRC<>NULL or BAK1<>NULL or BAK2<>NULL";
                int num2 = class6.FeatureCount(queryFilter);
                if (num2 > 0)
                {
                    this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.FormLoadSpatialData", "AutoUpdate", "0", "", "清空变化原因与时间出错", "", "", "");
                    this.richTextBox.AppendText("\n清空" + this.txt_year.Text.Trim() + "年度小班变化原因与时间出错");
                    Application.DoEvents();
                }
                else if (num2 == 0)
                {
                    this.richTextBox.AppendText("\n清空" + this.txt_year.Text.Trim() + "年度小班变化原因与时间");
                    Application.DoEvents();
                }
                edit = this.mNewFeatureWorkspace as IWorkspaceEdit;
                edit.StartEditing(false);
                edit.StartEditOperation();
                int num3 = 0;
                string str22 = UtilFactory.GetConfigOpt().GetConfigValue("XBLayer") + "_" + this.txt_year.Text.Trim();
                IFeatureClass class7 = this.mNewFeatureWorkspace.OpenFeatureClass(str22);
                num3 = class7.FeatureCount(null);
                IDataset dataset9 = class7 as IDataset;
                if (num3 > 0)
                {
                    dataset9.Workspace.ExecuteSQL("delete from " + dataset9.Name);
                }
                try
                {
                    edit.StopEditOperation();
                }
                catch (Exception exception4)
                {
                    exception = exception4;
                    MessageBox.Show(exception.Message, "加载数据", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    edit.StopEditOperation();
                }
                edit.StopEditing(true);
                this.labelLog.Text = "处理图幅索引数据...";
                this.labelLog.Refresh();
                try
                {
                    ForestDBServerInfo info = new ForestDBServerInfo();
                    info.ServerName = UtilFactory.GetConfigOpt().GetConfigValue2("SqlServer", "DataSource");
                    info.InstanceName = UtilFactory.GetConfigOpt().GetConfigValue2("SqlServer", "InitialCatalog");
                    info.UserName = UtilFactory.GetConfigOpt().GetConfigValue2("SqlServer", "UserID");
                    info.UserPass = UtilFactory.GetConfigOpt().GetConfigValue2("SqlServer", "Password");
                    ForestDBServerInfo info2 = null;
                    ServerConnection serverConnection = new ServerConnection(info2.ServerName, info.UserName, info.UserPass);
                    if (!serverConnection.IsOpen)
                    {
                        serverConnection.Connect();
                    }
                    Server server = new Server(serverConnection);
                    if (serverConnection.IsOpen)
                    {
                        serverConnection.Disconnect();
                    }
                }
                catch (Exception)
                {
                }
                this.labelLog.Text = "数据加载完成";
                this.labelLog.Refresh();
                MessageBox.Show("数据加载完成", "加载数据", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            catch (Exception exception6)
            {
                exception = exception6;
                MessageBox.Show(exception.Message, "加载数据", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.mErrOpt.ErrorOperate("DataEdit.FormLoadSpatialData", "DataEdit.FormLoadSpatialData", "DoLoadData", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLoadSpatialData));
            DevExpress.Utils.SuperToolTip superToolTip1 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipItem toolTipItem1 = new DevExpress.Utils.ToolTipItem();
            this.tListCatalog = new DevExpress.XtraTreeList.TreeList();
            this.treeListColumn3 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn4 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.imageList1 = new System.Windows.Forms.ImageList();
            this.labelCatalog = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            this.simpleButtonBack = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonSelect = new DevExpress.XtraEditors.SimpleButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.simpleButtonLoadData = new DevExpress.XtraEditors.SimpleButton();
            this.panel9 = new System.Windows.Forms.Panel();
            this.simpleButtonClose = new DevExpress.XtraEditors.SimpleButton();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_year = new DevExpress.XtraEditors.TextEdit();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.panel2 = new System.Windows.Forms.Panel();
            this.simpleButtonOK = new DevExpress.XtraEditors.SimpleButton();
            this.imageCollection1 = new DevExpress.Utils.ImageCollection();
            this.panelLog = new System.Windows.Forms.Panel();
            this.richTextBox = new System.Windows.Forms.RichTextBox();
            this.labelLog = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.tListCatalog)).BeginInit();
            this.panel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_year.Properties)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).BeginInit();
            this.panelLog.SuspendLayout();
            this.SuspendLayout();
            // 
            // tListCatalog
            // 
            this.tListCatalog.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.treeListColumn3,
            this.treeListColumn4});
            this.tListCatalog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tListCatalog.Location = new System.Drawing.Point(6, 98);
            this.tListCatalog.Name = "tListCatalog";
            this.tListCatalog.BeginUnboundLoad();
            this.tListCatalog.AppendNode(new object[] {
            "node",
            null}, -1, 0, 0, 0);
            this.tListCatalog.AppendNode(new object[] {
            "node1",
            null}, 0, 0, 0, 2);
            this.tListCatalog.AppendNode(new object[] {
            "node11",
            null}, 1, 0, 0, 1);
            this.tListCatalog.AppendNode(new object[] {
            null,
            null}, -1);
            this.tListCatalog.EndUnboundLoad();
            this.tListCatalog.OptionsSelection.EnableAppearanceFocusedRow = false;
            this.tListCatalog.OptionsView.ShowColumns = false;
            this.tListCatalog.OptionsView.ShowHorzLines = false;
            this.tListCatalog.OptionsView.ShowIndicator = false;
            this.tListCatalog.OptionsView.ShowVertLines = false;
            this.tListCatalog.Size = new System.Drawing.Size(332, 338);
            this.tListCatalog.StateImageList = this.imageList1;
            this.tListCatalog.TabIndex = 84;
            this.tListCatalog.Visible = false;
            // 
            // treeListColumn3
            // 
            this.treeListColumn3.Caption = "treeListColumn1";
            this.treeListColumn3.FieldName = "treeListColumn1";
            this.treeListColumn3.MinWidth = 87;
            this.treeListColumn3.Name = "treeListColumn3";
            this.treeListColumn3.Visible = true;
            this.treeListColumn3.VisibleIndex = 0;
            // 
            // treeListColumn4
            // 
            this.treeListColumn4.Caption = "treeListColumn2";
            this.treeListColumn4.FieldName = "treeListColumn2";
            this.treeListColumn4.Name = "treeListColumn4";
            this.treeListColumn4.Visible = true;
            this.treeListColumn4.VisibleIndex = 1;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "blank16.ico");
            this.imageList1.Images.SetKeyName(1, "tick16.ico");
            this.imageList1.Images.SetKeyName(2, "PART16.ICO");
            this.imageList1.Images.SetKeyName(3, "application_view_detail.png");
            this.imageList1.Images.SetKeyName(4, "application_view_gallery.png");
            this.imageList1.Images.SetKeyName(5, "application_view_icons.png");
            this.imageList1.Images.SetKeyName(6, "application_view_tile.png");
            this.imageList1.Images.SetKeyName(7, "image.png");
            this.imageList1.Images.SetKeyName(8, "image_edit.png");
            this.imageList1.Images.SetKeyName(9, "layers.png");
            this.imageList1.Images.SetKeyName(10, "layout_content.png");
            this.imageList1.Images.SetKeyName(11, "map.png");
            this.imageList1.Images.SetKeyName(12, "map_add.png");
            this.imageList1.Images.SetKeyName(13, "map_delete.png");
            this.imageList1.Images.SetKeyName(14, "map_edit.png");
            this.imageList1.Images.SetKeyName(15, "map_go.png");
            this.imageList1.Images.SetKeyName(16, "map_magnify.png");
            this.imageList1.Images.SetKeyName(17, "overlays.png");
            this.imageList1.Images.SetKeyName(18, "page.png");
            this.imageList1.Images.SetKeyName(19, "page_add.png");
            this.imageList1.Images.SetKeyName(20, "page_copy.png");
            this.imageList1.Images.SetKeyName(21, "page_delete.png");
            this.imageList1.Images.SetKeyName(22, "page_edit.png");
            this.imageList1.Images.SetKeyName(23, "page_paste.png");
            this.imageList1.Images.SetKeyName(24, "page_red.png");
            this.imageList1.Images.SetKeyName(25, "page_white.png");
            this.imageList1.Images.SetKeyName(26, "page_white_world.png");
            this.imageList1.Images.SetKeyName(27, "page_world.png");
            this.imageList1.Images.SetKeyName(28, "(181).gif");
            this.imageList1.Images.SetKeyName(29, "objects (3).png");
            this.imageList1.Images.SetKeyName(30, "Marker.bmp");
            this.imageList1.Images.SetKeyName(31, "Line.bmp");
            this.imageList1.Images.SetKeyName(32, "Polygon.bmp");
            this.imageList1.Images.SetKeyName(33, "(414).gif");
            this.imageList1.Images.SetKeyName(34, "application_view_columns.png");
            this.imageList1.Images.SetKeyName(35, "(321).gif");
            this.imageList1.Images.SetKeyName(36, "(322).gif");
            this.imageList1.Images.SetKeyName(37, "(323).gif");
            this.imageList1.Images.SetKeyName(38, "setting.ico");
            // 
            // labelCatalog
            // 
            this.labelCatalog.BackColor = System.Drawing.Color.Transparent;
            this.labelCatalog.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelCatalog.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelCatalog.ImageIndex = 6;
            this.labelCatalog.Location = new System.Drawing.Point(6, 67);
            this.labelCatalog.Name = "labelCatalog";
            this.labelCatalog.Size = new System.Drawing.Size(332, 31);
            this.labelCatalog.TabIndex = 85;
            this.labelCatalog.Text = "加载数据内容";
            this.labelCatalog.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelCatalog.Visible = false;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.simpleButtonBack);
            this.panel8.Controls.Add(this.simpleButtonSelect);
            this.panel8.Controls.Add(this.panel1);
            this.panel8.Controls.Add(this.simpleButtonLoadData);
            this.panel8.Controls.Add(this.panel9);
            this.panel8.Controls.Add(this.simpleButtonClose);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel8.Location = new System.Drawing.Point(6, 398);
            this.panel8.Name = "panel8";
            this.panel8.Padding = new System.Windows.Forms.Padding(0, 6, 0, 6);
            this.panel8.Size = new System.Drawing.Size(332, 38);
            this.panel8.TabIndex = 86;
            // 
            // simpleButtonBack
            // 
            this.simpleButtonBack.Dock = System.Windows.Forms.DockStyle.Right;
            this.simpleButtonBack.Image = ((System.Drawing.Image)(resources.GetObject("simpleButtonBack.Image")));
            this.simpleButtonBack.ImageList = this.imageList1;
            this.simpleButtonBack.Location = new System.Drawing.Point(80, 6);
            this.simpleButtonBack.Name = "simpleButtonBack";
            this.simpleButtonBack.Size = new System.Drawing.Size(60, 26);
            this.simpleButtonBack.TabIndex = 89;
            this.simpleButtonBack.Text = "返回";
            this.simpleButtonBack.Visible = false;
            this.simpleButtonBack.Click += new System.EventHandler(this.simpleButtonBack_Click);
            // 
            // simpleButtonSelect
            // 
            this.simpleButtonSelect.Dock = System.Windows.Forms.DockStyle.Right;
            this.simpleButtonSelect.Enabled = false;
            this.simpleButtonSelect.Image = ((System.Drawing.Image)(resources.GetObject("simpleButtonSelect.Image")));
            this.simpleButtonSelect.ImageIndex = 6;
            this.simpleButtonSelect.Location = new System.Drawing.Point(140, 6);
            this.simpleButtonSelect.Name = "simpleButtonSelect";
            this.simpleButtonSelect.Size = new System.Drawing.Size(60, 26);
            this.simpleButtonSelect.TabIndex = 80;
            this.simpleButtonSelect.Text = "全选";
            this.simpleButtonSelect.Visible = false;
            this.simpleButtonSelect.Click += new System.EventHandler(this.simpleButtonSelect_Click);
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(200, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(6, 26);
            this.panel1.TabIndex = 81;
            this.panel1.Visible = false;
            // 
            // simpleButtonLoadData
            // 
            this.simpleButtonLoadData.Dock = System.Windows.Forms.DockStyle.Right;
            this.simpleButtonLoadData.Enabled = false;
            this.simpleButtonLoadData.Image = ((System.Drawing.Image)(resources.GetObject("simpleButtonLoadData.Image")));
            this.simpleButtonLoadData.ImageIndex = 6;
            this.simpleButtonLoadData.Location = new System.Drawing.Point(206, 6);
            this.simpleButtonLoadData.Name = "simpleButtonLoadData";
            this.simpleButtonLoadData.Size = new System.Drawing.Size(60, 26);
            toolTipItem1.Text = "加载数据";
            superToolTip1.Items.Add(toolTipItem1);
            this.simpleButtonLoadData.SuperTip = superToolTip1;
            this.simpleButtonLoadData.TabIndex = 77;
            this.simpleButtonLoadData.Text = "加载";
            this.simpleButtonLoadData.Visible = false;
            this.simpleButtonLoadData.Click += new System.EventHandler(this.simpleButtonLoadData_Click);
            // 
            // panel9
            // 
            this.panel9.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel9.Location = new System.Drawing.Point(266, 6);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(6, 26);
            this.panel9.TabIndex = 79;
            // 
            // simpleButtonClose
            // 
            this.simpleButtonClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.simpleButtonClose.Image = ((System.Drawing.Image)(resources.GetObject("simpleButtonClose.Image")));
            this.simpleButtonClose.ImageIndex = 7;
            this.simpleButtonClose.Location = new System.Drawing.Point(272, 6);
            this.simpleButtonClose.Name = "simpleButtonClose";
            this.simpleButtonClose.Size = new System.Drawing.Size(60, 26);
            this.simpleButtonClose.TabIndex = 78;
            this.simpleButtonClose.Text = "关闭";
            this.simpleButtonClose.Click += new System.EventHandler(this.simpleButtonClose_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.ImageIndex = 6;
            this.label1.Location = new System.Drawing.Point(6, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(332, 31);
            this.label1.TabIndex = 87;
            this.label1.Text = "加载当前数据库中空间数据到指定新数据库";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txt_year
            // 
            this.txt_year.Dock = System.Windows.Forms.DockStyle.Left;
            this.txt_year.EditValue = "2014";
            this.txt_year.Location = new System.Drawing.Point(88, 6);
            this.txt_year.Name = "txt_year";
            this.txt_year.Size = new System.Drawing.Size(150, 20);
            this.txt_year.TabIndex = 89;
            // 
            // labelControl8
            // 
            this.labelControl8.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelControl8.Location = new System.Drawing.Point(4, 6);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(84, 14);
            this.labelControl8.TabIndex = 88;
            this.labelControl8.Text = "新数据库年度：";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.simpleButtonOK);
            this.panel2.Controls.Add(this.txt_year);
            this.panel2.Controls.Add(this.labelControl8);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(6, 33);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(4, 6, 0, 6);
            this.panel2.Size = new System.Drawing.Size(332, 34);
            this.panel2.TabIndex = 90;
            // 
            // simpleButtonOK
            // 
            this.simpleButtonOK.Dock = System.Windows.Forms.DockStyle.Right;
            this.simpleButtonOK.Enabled = false;
            this.simpleButtonOK.ImageIndex = 27;
            this.simpleButtonOK.ImageList = this.imageList1;
            this.simpleButtonOK.Location = new System.Drawing.Point(272, 6);
            this.simpleButtonOK.Name = "simpleButtonOK";
            this.simpleButtonOK.Size = new System.Drawing.Size(60, 22);
            this.simpleButtonOK.TabIndex = 90;
            this.simpleButtonOK.Text = "确定";
            this.simpleButtonOK.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // imageCollection1
            // 
            this.imageCollection1.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection1.ImageStream")));
            this.imageCollection1.Images.SetKeyName(0, "(709).gif");
            this.imageCollection1.Images.SetKeyName(1, "(60).gif");
            this.imageCollection1.Images.SetKeyName(2, "(62).gif");
            this.imageCollection1.Images.SetKeyName(3, "(773).gif");
            this.imageCollection1.Images.SetKeyName(4, "(704).gif");
            this.imageCollection1.Images.SetKeyName(5, "(705).gif");
            this.imageCollection1.Images.SetKeyName(6, "(706).gif");
            this.imageCollection1.Images.SetKeyName(7, "(707).gif");
            this.imageCollection1.Images.SetKeyName(8, "(708).gif");
            this.imageCollection1.Images.SetKeyName(9, "(73).gif");
            this.imageCollection1.Images.SetKeyName(10, "(711).gif");
            this.imageCollection1.Images.SetKeyName(11, "(712).gif");
            this.imageCollection1.Images.SetKeyName(12, "(713).gif");
            this.imageCollection1.Images.SetKeyName(13, "(721).gif");
            this.imageCollection1.Images.SetKeyName(14, "(12).gif");
            this.imageCollection1.Images.SetKeyName(15, "layer_7_.bmp");
            this.imageCollection1.Images.SetKeyName(16, "layers.png");
            this.imageCollection1.Images.SetKeyName(17, "layer-shaded-relief-add.png");
            this.imageCollection1.Images.SetKeyName(18, "layers2-24.png");
            this.imageCollection1.Images.SetKeyName(19, "home.png");
            this.imageCollection1.Images.SetKeyName(20, "image.png");
            this.imageCollection1.Images.SetKeyName(21, "map.png");
            this.imageCollection1.Images.SetKeyName(22, "page_landscape_shot.png");
            // 
            // panelLog
            // 
            this.panelLog.Controls.Add(this.richTextBox);
            this.panelLog.Controls.Add(this.labelLog);
            this.panelLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelLog.Location = new System.Drawing.Point(6, 98);
            this.panelLog.Name = "panelLog";
            this.panelLog.Padding = new System.Windows.Forms.Padding(4, 6, 0, 6);
            this.panelLog.Size = new System.Drawing.Size(332, 300);
            this.panelLog.TabIndex = 91;
            // 
            // richTextBox
            // 
            this.richTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox.Location = new System.Drawing.Point(4, 32);
            this.richTextBox.Name = "richTextBox";
            this.richTextBox.Size = new System.Drawing.Size(328, 262);
            this.richTextBox.TabIndex = 89;
            this.richTextBox.Text = "";
            // 
            // labelLog
            // 
            this.labelLog.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelLog.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelLog.Location = new System.Drawing.Point(4, 6);
            this.labelLog.Name = "labelLog";
            this.labelLog.Size = new System.Drawing.Size(328, 26);
            this.labelLog.TabIndex = 88;
            this.labelLog.Text = "加载记录";
            // 
            // FormLoadSpatialData
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(344, 442);
            this.Controls.Add(this.panelLog);
            this.Controls.Add(this.panel8);
            this.Controls.Add(this.tListCatalog);
            this.Controls.Add(this.labelCatalog);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.LookAndFeel.SkinName = "Blue";
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormLoadSpatialData";
            this.Padding = new System.Windows.Forms.Padding(6, 2, 6, 6);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "加载数据";
            ((System.ComponentModel.ISupportInitialize)(this.tListCatalog)).EndInit();
            this.panel8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txt_year.Properties)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).EndInit();
            this.panelLog.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private void InitialTreeList()
        {
            try
            {
                TreeListNode node2 = null;
                TreeListNode parentNode = null;
                TreeListNode node4 = null;
                try
                {
                    if (this.tListCatalog.Nodes.Count > 0)
                    {
                        this.tListCatalog.ClearNodes();
                    }
                }
                catch (Exception)
                {
                }
                this.tListCatalog.OptionsView.ShowCheckBoxes = false;
                this.tListCatalog.StateImageList = this.imageCollection1;
                this.tListCatalog.SelectImageList = null;
                this.tListCatalog.Columns[0].Width = this.tListCatalog.Width - 2;
                this.tListCatalog.OptionsBehavior.Editable = false;
                parentNode = this.tListCatalog.AppendNode("基础地理数据", node4);
                parentNode.SetValue(0, "基础地理数据");
                parentNode.ImageIndex = 15;
                parentNode.StateImageIndex = 15;
                parentNode.SelectImageIndex = -1;
                parentNode.Checked = false;
                parentNode.ExpandAll();
                DataRow[] rowArray = this.mInputTable.Select("TAB_THE='BASE'");
                for (int i = 0; i < rowArray.Length; i++)
                {
                    DataRow row = this.mInputTable.Rows[i];
                    node2 = this.tListCatalog.AppendNode(row["TAB_ALIA"].ToString(), parentNode);
                    node2.Checked = false;
                    node2.ImageIndex = -1;
                    node2.StateImageIndex = 20;
                    node2.SelectImageIndex = -1;
                    node2.SetValue(0, row["TAB_ALIA"].ToString());
                    node2.Tag = row["TAB_NAME"].ToString();
                }
                parentNode.ExpandAll();
                parentNode = this.tListCatalog.AppendNode("资源数据", node4);
                parentNode.SetValue(0, "资源数据");
                parentNode.ImageIndex = 0x10;
                parentNode.StateImageIndex = 0x10;
                parentNode.SelectImageIndex = -1;
                parentNode.Checked = false;
                parentNode.ExpandAll();
                foreach (DataRow row in this.mInputTable.Select("TAB_THE='FOREST'"))
                {
                    string str = row["TAB_NAME"].ToString();
                    string nodeData = row["TAB_ALIA"].ToString();
                    if (str.Contains(EditTask.TaskYear) && str.Contains("FOR_XIAOBAN"))
                    {
                        nodeData = "本底小班图层" + EditTask.TaskYear;
                    }
                    else if (str.Contains("FOR_XIAOBAN"))
                    {
                        nodeData = "资源小班图层" + this.txt_year.Text.Trim();
                    }
                    else if (str.Contains("FOR_XBBH"))
                    {
                        nodeData = "小班变化图层" + this.txt_year.Text.Trim();
                    }
                    node2 = this.tListCatalog.AppendNode(nodeData, parentNode);
                    node2.Checked = false;
                    node2.ImageIndex = -1;
                    node2.StateImageIndex = 0x16;
                    node2.SelectImageIndex = -1;
                    node2.SetValue(0, nodeData);
                    node2.Tag = row["TAB_NAME"].ToString();
                }
                parentNode.ExpandAll();
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate("DataEdit.FormLoadSpatialData", "DataEdit.FormLoadSpatialData", "InitialTreeList", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        public void InitialValue()
        {
            try
            {
                this.mFeatureWorkspace = EditTask.EditWorkspace;
                this.txt_year.Text = (int.Parse(EditTask.TaskYear) + 1).ToString();
                this.simpleButtonOK.Enabled = true;
                this.panelLog.Visible = false;
                string sDataSource = UtilFactory.GetConfigOpt().GetConfigValue2("SqlServer", "DataSource");
                string sService = UtilFactory.GetConfigOpt().GetConfigValue2("SqlServer", "Service");
                string sInitialCatalog = UtilFactory.GetConfigOpt().GetConfigValue2("SqlServer", "InitialCatalog");
                string sVersion = UtilFactory.GetConfigOpt().GetConfigValue2("SqlServer", "Version");
                string sUserID = UtilFactory.GetConfigOpt().GetConfigValue2("SqlServer", "UserID");
                string sPassword = UtilFactory.GetConfigOpt().GetConfigValue2("SqlServer", "Password");
                sInitialCatalog = sInitialCatalog.Replace(EditTask.TaskYear, this.txt_year.Text.Trim());
                this.mNewFeatureWorkspace = GISFunFactory.WorkspaceFun.GetFeatureWorkspace(WorkspaceSource.esriWSSdeWorkspaceFactory, sDataSource, sService, sInitialCatalog, sVersion, sUserID, sPassword, false);
                if (this.mNewFeatureWorkspace == null)
                {
                    this.txt_year.Text = "";
                }
               
                if (this.mInputTable == null)
                {
                 //   this.mInputTable = this.mDBAccess.GetDataTable(this.mDBAccess, "Select * from T_SYS_META_TABLE where TAB_TYPE='SDE'");
                }
                this.simpleButtonClose.Visible = true;
                this.simpleButtonClose.Enabled = true;
                this.simpleButtonLoadData.Enabled = true;
                this.tListCatalog.BringToFront();
                if (this.mNewFeatureWorkspace != null)
                {
                    this.InitialTreeList();
                    this.labelCatalog.Visible = true;
                    this.tListCatalog.Visible = true;
                    this.simpleButtonLoadData.Visible = true;
                    this.simpleButtonLoadData.Enabled = true;
                }
                else
                {
                    this.labelCatalog.Visible = false;
                    this.tListCatalog.Visible = false;
                    this.simpleButtonLoadData.Visible = false;
                    this.simpleButtonLoadData.Enabled = false;
                    try
                    {
                        if (this.tListCatalog.Nodes.Count > 0)
                        {
                            this.tListCatalog.ClearNodes();
                        }
                    }
                    catch (Exception)
                    {
                    }
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate("DataEdit.FormLoadSpatialData", "DataEdit.FormLoadSpatialData", "InitialValue", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (this.CheckDataBase())
            {
                this.InitialTreeList();
                this.labelCatalog.Visible = true;
                this.tListCatalog.Visible = true;
                this.simpleButtonLoadData.Visible = true;
                this.simpleButtonLoadData.Enabled = true;
            }
            else
            {
                this.labelCatalog.Visible = false;
                this.tListCatalog.Visible = false;
                this.simpleButtonLoadData.Enabled = false;
                try
                {
                    if (this.tListCatalog.Nodes.Count > 0)
                    {
                        this.tListCatalog.ClearNodes();
                    }
                }
                catch (Exception)
                {
                }
            }
        }

        private void simpleButtonBack_Click(object sender, EventArgs e)
        {
            this.panelLog.Visible = false;
            this.labelCatalog.Visible = true;
            this.tListCatalog.Visible = true;
            this.Refresh();
        }

        private void simpleButtonClose_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        private void simpleButtonLoadData_Click(object sender, EventArgs e)
        {
            if (this.CheckDataBase())
            {
                this.DoLoadData();
            }
        }

        private void simpleButtonSelect_Click(object sender, EventArgs e)
        {
        }
    }
}

