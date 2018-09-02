namespace DataEdit
{
    using DevExpress.XtraBars;
    using DevExpress.XtraEditors;
    using DevExpress.XtraEditors.Controls;
    using DevExpress.XtraEditors.Repository;
    using DevExpress.XtraGrid;
    using DevExpress.XtraGrid.Columns;
    using DevExpress.XtraGrid.Views.Grid;
    using ESRI.ArcGIS.Carto;
    using ESRI.ArcGIS.Controls;
    using ESRI.ArcGIS.Geodatabase;
    using ESRI.ArcGIS.Geometry;
    using FormBase;
    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Windows.Forms;
    using TaskManage;
    using Utilities;
    using DevExpress.XtraGrid.Views.Base;

    public class UserControlInputXB : UserControlBase1
    {
        private ButtonEdit buttonEditDataPath;
        private CheckEdit checkEdit2;
        private CheckEdit checkPorpertyMatch;
        private IContainer components = null;
        private GridColumn gridColumn1;
        private GridColumn gridColumn2;
        private GridControl gridControl1;
        private GridView gridView1;
        internal ImageList ImageList1;
        private Label label1;
        private Label label4;
        private Label label6;
        private Label label9;
        private Label labelprogress;
        private Label labelSourceInfo;
        private ListBoxControl listBoxDataList;
        private IGroupLayer m_DCGroupLayer;
        private IFeatureLayer m_EditLayer;
        private ITable m_EditTable = null;
        private IFeatureWorkspace m_EditWorkspace;
        private IGroupLayer m_TempGroupLayer;
        private const string mClassName = "DataEdit.UserControlInputXB";
        private int mDaiHao = 0;
     
        private DataTable mDCDataTable;
        private DataTable mDCDataTable2;
        private IFeatureClass mDCFeatureClass;
        private IFeatureLayer mDCFeatureLayer;
        private ITable mDCTable;
        private string mEditKind = "小班";
        private string mEditKind2 = "xiaoban";
        private ErrorOpt mErrOpt = UtilFactory.GetErrorOpt();
        private DataTable mFieldTable;
        private HookHelper mHookHelper = null;
        private bool mIsBatch = true;
        private string mKeyFieldName = "";
        private DataTable mKindTable;
        private ArrayList mLayerList = null;
        private ArrayList mLayerList2 = null;
        private BarButtonItem mParButton;
        private IFeatureLayer mPointFeatureLayer;
        private DataTable mPointTable;
        private DataTable mPointTable2;
        private IFeatureLayer mPolyFeatureLayer;
        private IFeatureWorkspace mPolyFeatureWorkspace;
        private DataTable mPolyTable;
        private ArrayList mRangeList = null;
        private bool mSelected = false;
        private DataTable mSelPointTable;
        private string mSubSysName = UtilFactory.GetConfigOpt().GetSystemName();
        private const string myClassName = "小班数据导入";
        private Panel panel12;
        private Panel panel4;
        private Panel panel5;
        private Panel panel6;
        private PanelControl panelControl1;
        private PanelControl panelControl2;
        private Panel panelDo;
        private Panel panelField;
        private Panel panelFieldMatch;
        private Panel panelGridControl;
        private Panel panelLog;
        private Panel panelQuestion;
        private Panel panelResource;
        private Panel panelSetID;
        private Panel panelSetSubID;
        private Panel panelSubID;
        private ProgressBarControl progressBar;
        private RadioGroup radioGroup3;
        private RepositoryItemComboBox repositoryItemComboBox1;
        private RichTextBox richTextBox;
        private SimpleButton simpleButtonAdd;
        private SimpleButton simpleButtonBack;
        private SimpleButton simpleButtonCancel;
        private SimpleButton simpleButtonClear;
        private SimpleButton simpleButtonClear2;
        private SimpleButton simpleButtonClose;
        private SimpleButton simpleButtonContinue;
        private SimpleButton simpleButtonExpend;
        private SimpleButton simpleButtonExpend2;
        private SimpleButton simpleButtonInput;
        private SimpleButton simpleButtonJump;
        private SimpleButton simpleButtonRemove;
        private SimpleButton simpleButtonReset;
        private SimpleButton simpleButtonView;
        private string SubID = "";

        public UserControlInputXB()
        {
            this.InitializeComponent();
        }

        private void buttonEditDataPath_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            try
            {
                FormAddData2 data = new FormAddData2(this.mHookHelper.FocusMap as IBasicMap, null, false, this.m_EditLayer);
                data.ShowDialog(this);
                ArrayList layerList = data.LayerList;
                if (layerList != null)
                {
                    if (this.mLayerList == null)
                    {
                        this.mLayerList = new ArrayList();
                    }
                    this.mLayerList2 = null;
                    this.mLayerList2 = new ArrayList();
                    if (layerList.Count > 0)
                    {
                        for (int i = 0; i < layerList.Count; i++)
                        {
                            IFeatureLayer layer = layerList[i] as IFeatureLayer;
                            IDataset featureClass = layer.FeatureClass as IDataset;
                            if (i == 0)
                            {
                                this.buttonEditDataPath.Text = featureClass.Workspace.PathName + @"\" + featureClass.Name;
                            }
                            else
                            {
                                this.buttonEditDataPath.Text = this.buttonEditDataPath.Text + "," + featureClass.Workspace.PathName + @"\" + featureClass.Name;
                            }
                            if (this.mLayerList.Count > 0)
                            {
                                for (int j = 0; j < this.mLayerList.Count; j++)
                                {
                                    IFeatureLayer layer2 = this.mLayerList[j] as IFeatureLayer;
                                    IDataset dataset2 = layer.FeatureClass as IDataset;
                                    if ((featureClass.Workspace.PathName != dataset2.Workspace.PathName) || (featureClass.Name != dataset2.Name))
                                    {
                                        this.mLayerList.Add(layer);
                                        this.mLayerList2.Add(layer);
                                    }
                                }
                            }
                            else
                            {
                                this.mLayerList.Add(layer);
                                this.mLayerList2.Add(layer);
                            }
                        }
                        this.buttonEditDataPath.Tag = layerList;
                        this.simpleButtonAdd.Enabled = true;
                        this.labelprogress.Visible = false;
                    }
                    else
                    {
                        this.buttonEditDataPath.Tag = null;
                        this.simpleButtonAdd.Enabled = false;
                        this.labelprogress.Visible = false;
                    }
                }
            }
            catch (Exception)
            {
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

        public void Hook(object hook, string sEditKind, BarButtonItem barButtonItem)
        {
            try
            {
                this.mParButton = barButtonItem;
                if (hook != null)
                {
                    this.mEditKind = sEditKind;
                    this.mHookHelper = new HookHelperClass();
                    this.mHookHelper.Hook = hook;
                    this.InitialValue();
                    this.InitialControl();
                }
                this.mEditKind = sEditKind;
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlInputXB", "Hook", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void InitialControl()
        {
            try
            {
                this.SetView(0);
                this.InitialFieldGrid();
                this.mRangeList = new ArrayList();
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlInputXB", "InitialControl", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void InitialFieldGrid()
        {
            try
            {
                IFields fields;
                int num;
                DataRow row;
                string str3;
                this.mFieldTable = new DataTable();
                this.mFieldTable.Clear();
                DataColumn column = new DataColumn("目标数据字段", typeof(string));
                this.mFieldTable.Columns.Add(column);
                column = new DataColumn("目标数据字段2", typeof(string));
                this.mFieldTable.Columns.Add(column);
                column = new DataColumn("源数据字段", typeof(string));
                this.mFieldTable.Columns.Add(column);
                column = new DataColumn("源数据字段2", typeof(string));
                this.mFieldTable.Columns.Add(column);
                this.mPointTable = new DataTable();
                this.mPointTable.Clear();
                column = new DataColumn("点号", typeof(string));
                this.mPointTable.Columns.Add(column);
                column = new DataColumn("X坐标", typeof(string));
                this.mPointTable.Columns.Add(column);
                column = new DataColumn("Y坐标", typeof(string));
                this.mPointTable.Columns.Add(column);
                column = new DataColumn("时间", typeof(string));
                this.mPointTable.Columns.Add(column);
                this.mPointTable2 = new DataTable();
                this.mPointTable2.Clear();
                column = new DataColumn("OID", typeof(string));
                this.mPointTable2.Columns.Add(column);
                column = new DataColumn("点号", typeof(string));
                this.mPointTable2.Columns.Add(column);
                column = new DataColumn("X坐标", typeof(string));
                this.mPointTable2.Columns.Add(column);
                column = new DataColumn("Y坐标", typeof(string));
                this.mPointTable2.Columns.Add(column);
                column = new DataColumn("时间", typeof(string));
                this.mPointTable2.Columns.Add(column);
                this.mPolyTable = new DataTable();
                this.mPolyTable.Clear();
                column = new DataColumn("OID", typeof(string));
                this.mPolyTable.Columns.Add(column);
                column = new DataColumn("小班号", typeof(string));
                this.mPolyTable.Columns.Add(column);
                string name = "";
                if (name != "")
                {
                    try
                    {
                        this.m_EditTable = this.m_EditWorkspace.OpenTable(name);
                    }
                    catch (Exception)
                    {
                    }
                }
                string configValue = UtilFactory.GetConfigOpt().GetConfigValue(this.mEditKind2 + "FieldUID");
                this.mKeyFieldName = configValue;
                if (this.m_EditTable != null)
                {
                    fields = this.m_EditTable.Fields;
                    for (num = 0; num < fields.FieldCount; num++)
                    {
                        row = this.mFieldTable.NewRow();
                        if ((((fields.get_Field(num).Name != configValue) && (fields.get_Field(num).Name != this.m_EditLayer.FeatureClass.OIDFieldName)) && ((fields.get_Field(num).Name != this.m_EditLayer.FeatureClass.ShapeFieldName) && (fields.get_Field(num) != this.m_EditLayer.FeatureClass.LengthField))) && (fields.get_Field(num) != this.m_EditLayer.FeatureClass.AreaField))
                        {
                            str3 = fields.get_Field(num).Type.ToString().Replace("esriFieldType", "");
                            row[0] = fields.get_Field(num).AliasName + "[" + str3 + "]";
                            row[1] = fields.get_Field(num).Name;
                            row[2] = "";
                            row[3] = "";
                            this.mFieldTable.Rows.Add(row);
                        }
                    }
                }
                else
                {
                    fields = this.m_EditLayer.FeatureClass.Fields;
                    for (num = 0; num < fields.FieldCount; num++)
                    {
                        row = this.mFieldTable.NewRow();
                        if ((((fields.get_Field(num).Name != this.m_EditLayer.FeatureClass.OIDFieldName) && (fields.get_Field(num).Name != this.m_EditLayer.FeatureClass.ShapeFieldName)) && (fields.get_Field(num) != this.m_EditLayer.FeatureClass.LengthField)) && (fields.get_Field(num) != this.m_EditLayer.FeatureClass.AreaField))
                        {
                            str3 = fields.get_Field(num).Type.ToString().Replace("esriFieldType", "");
                            row[0] = fields.get_Field(num).AliasName + "[" + str3 + "]";
                            row[1] = fields.get_Field(num).Name;
                            row[2] = "";
                            row[3] = "";
                            this.mFieldTable.Rows.Add(row);
                        }
                    }
                }
                this.gridControl1.DataSource = null;
                this.gridView1.Columns.Clear();
                this.gridControl1.DataSource = this.mFieldTable;
                this.gridView1.RefreshData();
                this.gridView1.Columns[1].Visible = false;
                this.gridView1.Columns[3].Visible = false;
                this.gridView1.Columns[1].OptionsColumn.AllowEdit = false;
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlInputXB", "InitialFieldGrid", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void InitialFieldList(IFeatureClass pFeatureClass)
        {
            try
            {
                this.repositoryItemComboBox1.Items.Clear();
                this.repositoryItemComboBox1.Items.Add("");
                for (int i = 0; i < pFeatureClass.Fields.FieldCount; i++)
                {
                    if ((pFeatureClass.Fields.get_Field(i).Name != pFeatureClass.OIDFieldName) && (pFeatureClass.Fields.get_Field(i).Name != pFeatureClass.ShapeFieldName))
                    {
                        string str = pFeatureClass.Fields.get_Field(i).Type.ToString().Replace("esriFieldType", "");
                        if (pFeatureClass.Fields.get_Field(i).AliasName != pFeatureClass.Fields.get_Field(i).Name)
                        {
                            this.repositoryItemComboBox1.Items.Add(pFeatureClass.Fields.get_Field(i).AliasName + "[" + pFeatureClass.Fields.get_Field(i).Name + "][" + str + "]");
                        }
                        else
                        {
                            this.repositoryItemComboBox1.Items.Add(pFeatureClass.Fields.get_Field(i).AliasName + "[" + str + "]");
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlInputXB", "InitialFieldList", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserControlInputXB));
            this.ImageList1 = new System.Windows.Forms.ImageList();
            this.panelSubID = new System.Windows.Forms.Panel();
            this.panelSetSubID = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.labelSourceInfo = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.radioGroup3 = new DevExpress.XtraEditors.RadioGroup();
            this.panelSetID = new System.Windows.Forms.Panel();
            this.simpleButtonExpend2 = new DevExpress.XtraEditors.SimpleButton();
            this.checkEdit2 = new DevExpress.XtraEditors.CheckEdit();
            this.panelDo = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.simpleButtonBack = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonInput = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonClose = new DevExpress.XtraEditors.SimpleButton();
            this.progressBar = new DevExpress.XtraEditors.ProgressBarControl();
            this.panelField = new System.Windows.Forms.Panel();
            this.panelGridControl = new System.Windows.Forms.Panel();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.panelFieldMatch = new System.Windows.Forms.Panel();
            this.simpleButtonExpend = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonReset = new DevExpress.XtraEditors.SimpleButton();
            this.checkPorpertyMatch = new DevExpress.XtraEditors.CheckEdit();
            this.simpleButtonClear = new DevExpress.XtraEditors.SimpleButton();
            this.panelResource = new System.Windows.Forms.Panel();
            this.listBoxDataList = new DevExpress.XtraEditors.ListBoxControl();
            this.panel12 = new System.Windows.Forms.Panel();
            this.simpleButtonAdd = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonRemove = new DevExpress.XtraEditors.SimpleButton();
            this.label9 = new System.Windows.Forms.Label();
            this.simpleButtonClear2 = new DevExpress.XtraEditors.SimpleButton();
            this.buttonEditDataPath = new DevExpress.XtraEditors.ButtonEdit();
            this.label6 = new System.Windows.Forms.Label();
            this.panelLog = new System.Windows.Forms.Panel();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.richTextBox = new System.Windows.Forms.RichTextBox();
            this.panelQuestion = new System.Windows.Forms.Panel();
            this.simpleButtonView = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonCancel = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonJump = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonContinue = new DevExpress.XtraEditors.SimpleButton();
            this.label4 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.labelprogress = new System.Windows.Forms.Label();
            this.panelSubID.SuspendLayout();
            this.panelSetSubID.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup3.Properties)).BeginInit();
            this.panelSetID.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit2.Properties)).BeginInit();
            this.panelDo.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.progressBar.Properties)).BeginInit();
            this.panelField.SuspendLayout();
            this.panelGridControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).BeginInit();
            this.panelFieldMatch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkPorpertyMatch.Properties)).BeginInit();
            this.panelResource.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listBoxDataList)).BeginInit();
            this.panel12.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.buttonEditDataPath.Properties)).BeginInit();
            this.panelLog.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.panelQuestion.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // ImageList1
            // 
            this.ImageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList1.ImageStream")));
            this.ImageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.ImageList1.Images.SetKeyName(0, "blank16.ico");
            this.ImageList1.Images.SetKeyName(1, "tick16.ico");
            this.ImageList1.Images.SetKeyName(2, "PART16.ICO");
            this.ImageList1.Images.SetKeyName(3, "");
            this.ImageList1.Images.SetKeyName(4, "");
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
            this.ImageList1.Images.SetKeyName(16, "(30,24).png");
            this.ImageList1.Images.SetKeyName(17, "(00,02).png");
            this.ImageList1.Images.SetKeyName(18, "(00,17).png");
            this.ImageList1.Images.SetKeyName(19, "(00,46).png");
            this.ImageList1.Images.SetKeyName(20, "(01,10).png");
            this.ImageList1.Images.SetKeyName(21, "(01,25).png");
            this.ImageList1.Images.SetKeyName(22, "(05,32).png");
            this.ImageList1.Images.SetKeyName(23, "(06,32).png");
            this.ImageList1.Images.SetKeyName(24, "(07,32).png");
            this.ImageList1.Images.SetKeyName(25, "(08,32).png");
            this.ImageList1.Images.SetKeyName(26, "(08,36).png");
            this.ImageList1.Images.SetKeyName(27, "(09,36).png");
            this.ImageList1.Images.SetKeyName(28, "(10,26).png");
            this.ImageList1.Images.SetKeyName(29, "(11,26).png");
            this.ImageList1.Images.SetKeyName(30, "(11,29).png");
            this.ImageList1.Images.SetKeyName(31, "(12,29).png");
            this.ImageList1.Images.SetKeyName(32, "(11,32).png");
            this.ImageList1.Images.SetKeyName(33, "(11,36).png");
            this.ImageList1.Images.SetKeyName(34, "(13,32).png");
            this.ImageList1.Images.SetKeyName(35, "(19,31).png");
            this.ImageList1.Images.SetKeyName(36, "(22,18).png");
            this.ImageList1.Images.SetKeyName(37, "(25,27).png");
            this.ImageList1.Images.SetKeyName(38, "(29,43).png");
            this.ImageList1.Images.SetKeyName(39, "(30,14).png");
            this.ImageList1.Images.SetKeyName(40, "5.png");
            this.ImageList1.Images.SetKeyName(41, "10.png");
            this.ImageList1.Images.SetKeyName(42, "11.png");
            this.ImageList1.Images.SetKeyName(43, "16.png");
            this.ImageList1.Images.SetKeyName(44, "17.png");
            this.ImageList1.Images.SetKeyName(45, "18.png");
            this.ImageList1.Images.SetKeyName(46, "19.png");
            this.ImageList1.Images.SetKeyName(47, "20.png");
            this.ImageList1.Images.SetKeyName(48, "21.png");
            this.ImageList1.Images.SetKeyName(49, "22.png");
            this.ImageList1.Images.SetKeyName(50, "25.png");
            this.ImageList1.Images.SetKeyName(51, "31.png");
            this.ImageList1.Images.SetKeyName(52, "41.png");
            this.ImageList1.Images.SetKeyName(53, "add.png");
            this.ImageList1.Images.SetKeyName(54, "bullet_minus.png");
            this.ImageList1.Images.SetKeyName(55, "control_add_blue.png");
            this.ImageList1.Images.SetKeyName(56, "control_power_blue.png");
            this.ImageList1.Images.SetKeyName(57, "control_remove_blue.png");
            this.ImageList1.Images.SetKeyName(58, "cross.png");
            this.ImageList1.Images.SetKeyName(59, "down.png");
            this.ImageList1.Images.SetKeyName(60, "draw_tools.png");
            this.ImageList1.Images.SetKeyName(61, "Feedicons_v2_010.png");
            this.ImageList1.Images.SetKeyName(62, "Feedicons_v2_011.png");
            this.ImageList1.Images.SetKeyName(63, "Feedicons_v2_031.png");
            this.ImageList1.Images.SetKeyName(64, "Feedicons_v2_032.png");
            this.ImageList1.Images.SetKeyName(65, "Feedicons_v2_033.png");
            this.ImageList1.Images.SetKeyName(66, "flag blue.png");
            this.ImageList1.Images.SetKeyName(67, "flag red.png");
            this.ImageList1.Images.SetKeyName(68, "flag yellow.png");
            this.ImageList1.Images.SetKeyName(69, "31.png");
            this.ImageList1.Images.SetKeyName(70, "42.png");
            this.ImageList1.Images.SetKeyName(71, "control_add_blue.png");
            this.ImageList1.Images.SetKeyName(72, "control_remove_blue.png");
            this.ImageList1.Images.SetKeyName(73, "cursor.png");
            this.ImageList1.Images.SetKeyName(74, "cursor_small.png");
            this.ImageList1.Images.SetKeyName(75, "cut.png");
            this.ImageList1.Images.SetKeyName(76, "cut_red.png");
            this.ImageList1.Images.SetKeyName(77, "Feedicons_v2_010.png");
            this.ImageList1.Images.SetKeyName(78, "Feedicons_v2_011.png");
            this.ImageList1.Images.SetKeyName(79, "Feedicons_v2_024.png");
            this.ImageList1.Images.SetKeyName(80, "Feedicons_v2_026.png");
            this.ImageList1.Images.SetKeyName(81, "Feedicons_v2_031.png");
            this.ImageList1.Images.SetKeyName(82, "key.png");
            this.ImageList1.Images.SetKeyName(83, "page_add.png");
            this.ImageList1.Images.SetKeyName(84, "page_delete.png");
            this.ImageList1.Images.SetKeyName(85, "page_white_world.png");
            this.ImageList1.Images.SetKeyName(86, "page_world.png");
            this.ImageList1.Images.SetKeyName(87, "reload.png");
            this.ImageList1.Images.SetKeyName(88, "world_add.png");
            this.ImageList1.Images.SetKeyName(89, "world_delete.png");
            this.ImageList1.Images.SetKeyName(90, "zoom_in.png");
            this.ImageList1.Images.SetKeyName(91, "zoom_out.png");
            this.ImageList1.Images.SetKeyName(92, "control_power_blue.png");
            this.ImageList1.Images.SetKeyName(93, "Tipicon.ico");
            this.ImageList1.Images.SetKeyName(94, "Exit.png");
            // 
            // panelSubID
            // 
            this.panelSubID.BackColor = System.Drawing.Color.Transparent;
            this.panelSubID.Controls.Add(this.panelSetSubID);
            this.panelSubID.Controls.Add(this.panelSetID);
            this.panelSubID.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSubID.Location = new System.Drawing.Point(0, 290);
            this.panelSubID.Name = "panelSubID";
            this.panelSubID.Padding = new System.Windows.Forms.Padding(6, 0, 6, 6);
            this.panelSubID.Size = new System.Drawing.Size(338, 29);
            this.panelSubID.TabIndex = 35;
            // 
            // panelSetSubID
            // 
            this.panelSetSubID.BackColor = System.Drawing.Color.Transparent;
            this.panelSetSubID.Controls.Add(this.panel5);
            this.panelSetSubID.Controls.Add(this.radioGroup3);
            this.panelSetSubID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelSetSubID.Location = new System.Drawing.Point(6, 30);
            this.panelSetSubID.Name = "panelSetSubID";
            this.panelSetSubID.Padding = new System.Windows.Forms.Padding(0, 2, 0, 5);
            this.panelSetSubID.Size = new System.Drawing.Size(326, 0);
            this.panelSetSubID.TabIndex = 30;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.panelControl2);
            this.panel5.Controls.Add(this.label1);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 30);
            this.panel5.Name = "panel5";
            this.panel5.Padding = new System.Windows.Forms.Padding(0, 2, 0, 7);
            this.panel5.Size = new System.Drawing.Size(326, 75);
            this.panel5.TabIndex = 15;
            this.panel5.Visible = false;
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.labelSourceInfo);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl2.Location = new System.Drawing.Point(0, 23);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(326, 30);
            this.panelControl2.TabIndex = 16;
            // 
            // labelSourceInfo
            // 
            this.labelSourceInfo.BackColor = System.Drawing.Color.White;
            this.labelSourceInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelSourceInfo.Location = new System.Drawing.Point(2, 2);
            this.labelSourceInfo.Name = "labelSourceInfo";
            this.labelSourceInfo.Size = new System.Drawing.Size(322, 26);
            this.labelSourceInfo.TabIndex = 31;
            this.labelSourceInfo.Text = "共计33个要素";
            this.labelSourceInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(0, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(326, 21);
            this.label1.TabIndex = 8;
            this.label1.Text = "源数据信息:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // radioGroup3
            // 
            this.radioGroup3.Dock = System.Windows.Forms.DockStyle.Top;
            this.radioGroup3.Location = new System.Drawing.Point(0, 2);
            this.radioGroup3.Name = "radioGroup3";
            this.radioGroup3.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "自动生成"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "指定生成")});
            this.radioGroup3.Size = new System.Drawing.Size(326, 28);
            this.radioGroup3.TabIndex = 31;
            // 
            // panelSetID
            // 
            this.panelSetID.Controls.Add(this.simpleButtonExpend2);
            this.panelSetID.Controls.Add(this.checkEdit2);
            this.panelSetID.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSetID.Location = new System.Drawing.Point(6, 0);
            this.panelSetID.Name = "panelSetID";
            this.panelSetID.Padding = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.panelSetID.Size = new System.Drawing.Size(326, 30);
            this.panelSetID.TabIndex = 15;
            // 
            // simpleButtonExpend2
            // 
            this.simpleButtonExpend2.Dock = System.Windows.Forms.DockStyle.Right;
            this.simpleButtonExpend2.ImageIndex = 14;
            this.simpleButtonExpend2.ImageList = this.ImageList1;
            this.simpleButtonExpend2.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.simpleButtonExpend2.Location = new System.Drawing.Point(304, 4);
            this.simpleButtonExpend2.Name = "simpleButtonExpend2";
            this.simpleButtonExpend2.Size = new System.Drawing.Size(22, 22);
            this.simpleButtonExpend2.TabIndex = 17;
            this.simpleButtonExpend2.ToolTip = "重新匹配";
            this.simpleButtonExpend2.Visible = false;
            // 
            // checkEdit2
            // 
            this.checkEdit2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkEdit2.Dock = System.Windows.Forms.DockStyle.Left;
            this.checkEdit2.Location = new System.Drawing.Point(0, 4);
            this.checkEdit2.Name = "checkEdit2";
            this.checkEdit2.Properties.Caption = "生成小班编号:";
            this.checkEdit2.Size = new System.Drawing.Size(133, 19);
            this.checkEdit2.TabIndex = 33;
            // 
            // panelDo
            // 
            this.panelDo.BackColor = System.Drawing.Color.Transparent;
            this.panelDo.Controls.Add(this.panel6);
            this.panelDo.Controls.Add(this.progressBar);
            this.panelDo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelDo.Location = new System.Drawing.Point(0, 556);
            this.panelDo.Name = "panelDo";
            this.panelDo.Padding = new System.Windows.Forms.Padding(6);
            this.panelDo.Size = new System.Drawing.Size(338, 37);
            this.panelDo.TabIndex = 34;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.simpleButtonBack);
            this.panel6.Controls.Add(this.simpleButtonInput);
            this.panel6.Controls.Add(this.simpleButtonClose);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(6, 6);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(326, 24);
            this.panel6.TabIndex = 11;
            // 
            // simpleButtonBack
            // 
            this.simpleButtonBack.Dock = System.Windows.Forms.DockStyle.Right;
            this.simpleButtonBack.ImageIndex = 46;
            this.simpleButtonBack.ImageList = this.ImageList1;
            this.simpleButtonBack.Location = new System.Drawing.Point(134, 0);
            this.simpleButtonBack.Name = "simpleButtonBack";
            this.simpleButtonBack.Size = new System.Drawing.Size(64, 24);
            this.simpleButtonBack.TabIndex = 10;
            this.simpleButtonBack.Text = "返回";
            this.simpleButtonBack.ToolTip = "返回再导入数据";
            // 
            // simpleButtonInput
            // 
            this.simpleButtonInput.Dock = System.Windows.Forms.DockStyle.Right;
            this.simpleButtonInput.ImageIndex = 52;
            this.simpleButtonInput.ImageList = this.ImageList1;
            this.simpleButtonInput.Location = new System.Drawing.Point(198, 0);
            this.simpleButtonInput.Name = "simpleButtonInput";
            this.simpleButtonInput.Size = new System.Drawing.Size(64, 24);
            this.simpleButtonInput.TabIndex = 9;
            this.simpleButtonInput.Text = "导入";
            // 
            // simpleButtonClose
            // 
            this.simpleButtonClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.simpleButtonClose.ImageIndex = 94;
            this.simpleButtonClose.ImageList = this.ImageList1;
            this.simpleButtonClose.Location = new System.Drawing.Point(262, 0);
            this.simpleButtonClose.Name = "simpleButtonClose";
            this.simpleButtonClose.Size = new System.Drawing.Size(64, 24);
            this.simpleButtonClose.TabIndex = 13;
            this.simpleButtonClose.Text = "关闭";
            // 
            // progressBar
            // 
            this.progressBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBar.Location = new System.Drawing.Point(6, 7);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(326, 24);
            this.progressBar.TabIndex = 10;
            this.progressBar.Visible = false;
            // 
            // panelField
            // 
            this.panelField.BackColor = System.Drawing.Color.Transparent;
            this.panelField.Controls.Add(this.panelGridControl);
            this.panelField.Controls.Add(this.panelFieldMatch);
            this.panelField.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelField.Location = new System.Drawing.Point(0, 140);
            this.panelField.Name = "panelField";
            this.panelField.Padding = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.panelField.Size = new System.Drawing.Size(338, 150);
            this.panelField.TabIndex = 33;
            // 
            // panelGridControl
            // 
            this.panelGridControl.BackColor = System.Drawing.Color.Transparent;
            this.panelGridControl.Controls.Add(this.gridControl1);
            this.panelGridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelGridControl.Location = new System.Drawing.Point(6, 30);
            this.panelGridControl.Name = "panelGridControl";
            this.panelGridControl.Padding = new System.Windows.Forms.Padding(0, 4, 0, 6);
            this.panelGridControl.Size = new System.Drawing.Size(326, 120);
            this.panelGridControl.TabIndex = 17;
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 4);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemComboBox1});
            this.gridControl1.Size = new System.Drawing.Size(326, 110);
            this.gridControl1.TabIndex = 9;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsCustomization.AllowColumnMoving = false;
            this.gridView1.OptionsCustomization.AllowSort = false;
            this.gridView1.OptionsFilter.AllowColumnMRUFilterList = false;
            this.gridView1.OptionsFilter.AllowFilterEditor = false;
            this.gridView1.OptionsFilter.AllowMRUFilterList = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.OptionsView.ShowIndicator = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "目标属性字段";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "匹配源属性字段";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            // 
            // repositoryItemComboBox1
            // 
            this.repositoryItemComboBox1.AutoHeight = false;
            this.repositoryItemComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemComboBox1.Name = "repositoryItemComboBox1";
            // 
            // panelFieldMatch
            // 
            this.panelFieldMatch.Controls.Add(this.simpleButtonExpend);
            this.panelFieldMatch.Controls.Add(this.simpleButtonReset);
            this.panelFieldMatch.Controls.Add(this.checkPorpertyMatch);
            this.panelFieldMatch.Controls.Add(this.simpleButtonClear);
            this.panelFieldMatch.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelFieldMatch.Location = new System.Drawing.Point(6, 0);
            this.panelFieldMatch.Name = "panelFieldMatch";
            this.panelFieldMatch.Padding = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.panelFieldMatch.Size = new System.Drawing.Size(326, 30);
            this.panelFieldMatch.TabIndex = 17;
            // 
            // simpleButtonExpend
            // 
            this.simpleButtonExpend.Dock = System.Windows.Forms.DockStyle.Right;
            this.simpleButtonExpend.ImageIndex = 14;
            this.simpleButtonExpend.ImageList = this.ImageList1;
            this.simpleButtonExpend.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.simpleButtonExpend.Location = new System.Drawing.Point(260, 4);
            this.simpleButtonExpend.Name = "simpleButtonExpend";
            this.simpleButtonExpend.Size = new System.Drawing.Size(22, 22);
            this.simpleButtonExpend.TabIndex = 16;
            this.simpleButtonExpend.ToolTip = "展开";
            this.simpleButtonExpend.Visible = false;
            // 
            // simpleButtonReset
            // 
            this.simpleButtonReset.Dock = System.Windows.Forms.DockStyle.Right;
            this.simpleButtonReset.ImageIndex = 87;
            this.simpleButtonReset.ImageList = this.ImageList1;
            this.simpleButtonReset.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.simpleButtonReset.Location = new System.Drawing.Point(282, 4);
            this.simpleButtonReset.Name = "simpleButtonReset";
            this.simpleButtonReset.Size = new System.Drawing.Size(22, 22);
            this.simpleButtonReset.TabIndex = 13;
            this.simpleButtonReset.ToolTip = "重新匹配";
            this.simpleButtonReset.Visible = false;
            // 
            // checkPorpertyMatch
            // 
            this.checkPorpertyMatch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkPorpertyMatch.Dock = System.Windows.Forms.DockStyle.Left;
            this.checkPorpertyMatch.Location = new System.Drawing.Point(0, 4);
            this.checkPorpertyMatch.Name = "checkPorpertyMatch";
            this.checkPorpertyMatch.Properties.Caption = "属性字段匹配:";
            this.checkPorpertyMatch.Size = new System.Drawing.Size(177, 19);
            this.checkPorpertyMatch.TabIndex = 14;
            // 
            // simpleButtonClear
            // 
            this.simpleButtonClear.Dock = System.Windows.Forms.DockStyle.Right;
            this.simpleButtonClear.ImageIndex = 92;
            this.simpleButtonClear.ImageList = this.ImageList1;
            this.simpleButtonClear.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.simpleButtonClear.Location = new System.Drawing.Point(304, 4);
            this.simpleButtonClear.Name = "simpleButtonClear";
            this.simpleButtonClear.Size = new System.Drawing.Size(22, 22);
            this.simpleButtonClear.TabIndex = 11;
            this.simpleButtonClear.ToolTip = "清除";
            this.simpleButtonClear.Visible = false;
            // 
            // panelResource
            // 
            this.panelResource.BackColor = System.Drawing.Color.Transparent;
            this.panelResource.Controls.Add(this.listBoxDataList);
            this.panelResource.Controls.Add(this.panel12);
            this.panelResource.Controls.Add(this.buttonEditDataPath);
            this.panelResource.Controls.Add(this.label6);
            this.panelResource.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelResource.Location = new System.Drawing.Point(0, 0);
            this.panelResource.Name = "panelResource";
            this.panelResource.Padding = new System.Windows.Forms.Padding(6, 2, 6, 6);
            this.panelResource.Size = new System.Drawing.Size(338, 140);
            this.panelResource.TabIndex = 32;
            // 
            // listBoxDataList
            // 
            this.listBoxDataList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxDataList.Location = new System.Drawing.Point(6, 80);
            this.listBoxDataList.Name = "listBoxDataList";
            this.listBoxDataList.Size = new System.Drawing.Size(326, 54);
            this.listBoxDataList.TabIndex = 12;
            // 
            // panel12
            // 
            this.panel12.BackColor = System.Drawing.Color.Transparent;
            this.panel12.Controls.Add(this.simpleButtonAdd);
            this.panel12.Controls.Add(this.simpleButtonRemove);
            this.panel12.Controls.Add(this.label9);
            this.panel12.Controls.Add(this.simpleButtonClear2);
            this.panel12.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel12.Location = new System.Drawing.Point(6, 50);
            this.panel12.Name = "panel12";
            this.panel12.Padding = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.panel12.Size = new System.Drawing.Size(326, 30);
            this.panel12.TabIndex = 13;
            // 
            // simpleButtonAdd
            // 
            this.simpleButtonAdd.Dock = System.Windows.Forms.DockStyle.Right;
            this.simpleButtonAdd.ImageIndex = 71;
            this.simpleButtonAdd.ImageList = this.ImageList1;
            this.simpleButtonAdd.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.simpleButtonAdd.Location = new System.Drawing.Point(260, 4);
            this.simpleButtonAdd.Name = "simpleButtonAdd";
            this.simpleButtonAdd.Size = new System.Drawing.Size(22, 22);
            this.simpleButtonAdd.TabIndex = 10;
            this.simpleButtonAdd.ToolTip = "添加";
            // 
            // simpleButtonRemove
            // 
            this.simpleButtonRemove.Dock = System.Windows.Forms.DockStyle.Right;
            this.simpleButtonRemove.ImageIndex = 72;
            this.simpleButtonRemove.ImageList = this.ImageList1;
            this.simpleButtonRemove.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.simpleButtonRemove.Location = new System.Drawing.Point(282, 4);
            this.simpleButtonRemove.Name = "simpleButtonRemove";
            this.simpleButtonRemove.Size = new System.Drawing.Size(22, 22);
            this.simpleButtonRemove.TabIndex = 9;
            this.simpleButtonRemove.ToolTip = "移除";
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Dock = System.Windows.Forms.DockStyle.Left;
            this.label9.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label9.ImageList = this.ImageList1;
            this.label9.Location = new System.Drawing.Point(0, 4);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(126, 22);
            this.label9.TabIndex = 8;
            this.label9.Text = "导入数据列表:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // simpleButtonClear2
            // 
            this.simpleButtonClear2.Dock = System.Windows.Forms.DockStyle.Right;
            this.simpleButtonClear2.ImageIndex = 92;
            this.simpleButtonClear2.ImageList = this.ImageList1;
            this.simpleButtonClear2.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.simpleButtonClear2.Location = new System.Drawing.Point(304, 4);
            this.simpleButtonClear2.Name = "simpleButtonClear2";
            this.simpleButtonClear2.Size = new System.Drawing.Size(22, 22);
            this.simpleButtonClear2.TabIndex = 12;
            this.simpleButtonClear2.ToolTip = "清除";
            // 
            // buttonEditDataPath
            // 
            this.buttonEditDataPath.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonEditDataPath.Location = new System.Drawing.Point(6, 30);
            this.buttonEditDataPath.Name = "buttonEditDataPath";
            this.buttonEditDataPath.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.buttonEditDataPath.Size = new System.Drawing.Size(326, 20);
            this.buttonEditDataPath.TabIndex = 10;
            this.buttonEditDataPath.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.buttonEditDataPath_ButtonClick);
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Dock = System.Windows.Forms.DockStyle.Top;
            this.label6.Location = new System.Drawing.Point(6, 2);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(326, 28);
            this.label6.TabIndex = 14;
            this.label6.Text = "导入数据路径:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelLog
            // 
            this.panelLog.BackColor = System.Drawing.Color.Transparent;
            this.panelLog.Controls.Add(this.panelControl1);
            this.panelLog.Controls.Add(this.panelQuestion);
            this.panelLog.Controls.Add(this.panel4);
            this.panelLog.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLog.Location = new System.Drawing.Point(0, 319);
            this.panelLog.Name = "panelLog";
            this.panelLog.Padding = new System.Windows.Forms.Padding(6, 0, 6, 4);
            this.panelLog.Size = new System.Drawing.Size(338, 163);
            this.panelLog.TabIndex = 36;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.richTextBox);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(6, 58);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(326, 29);
            this.panelControl1.TabIndex = 16;
            // 
            // richTextBox
            // 
            this.richTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox.Location = new System.Drawing.Point(2, 2);
            this.richTextBox.Name = "richTextBox";
            this.richTextBox.Size = new System.Drawing.Size(322, 25);
            this.richTextBox.TabIndex = 0;
            this.richTextBox.Text = "";
            // 
            // panelQuestion
            // 
            this.panelQuestion.Controls.Add(this.simpleButtonView);
            this.panelQuestion.Controls.Add(this.simpleButtonCancel);
            this.panelQuestion.Controls.Add(this.simpleButtonJump);
            this.panelQuestion.Controls.Add(this.simpleButtonContinue);
            this.panelQuestion.Controls.Add(this.label4);
            this.panelQuestion.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelQuestion.Location = new System.Drawing.Point(6, 87);
            this.panelQuestion.Name = "panelQuestion";
            this.panelQuestion.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.panelQuestion.Size = new System.Drawing.Size(326, 72);
            this.panelQuestion.TabIndex = 17;
            this.panelQuestion.Visible = false;
            // 
            // simpleButtonView
            // 
            this.simpleButtonView.Cursor = System.Windows.Forms.Cursors.Hand;
            this.simpleButtonView.ImageIndex = 9;
            this.simpleButtonView.ImageList = this.ImageList1;
            this.simpleButtonView.Location = new System.Drawing.Point(205, 8);
            this.simpleButtonView.Name = "simpleButtonView";
            this.simpleButtonView.Size = new System.Drawing.Size(64, 24);
            this.simpleButtonView.TabIndex = 19;
            this.simpleButtonView.Text = "查看";
            this.simpleButtonView.ToolTip = "查看已有小班";
            // 
            // simpleButtonCancel
            // 
            this.simpleButtonCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.simpleButtonCancel.ImageIndex = 67;
            this.simpleButtonCancel.ImageList = this.ImageList1;
            this.simpleButtonCancel.Location = new System.Drawing.Point(205, 38);
            this.simpleButtonCancel.Name = "simpleButtonCancel";
            this.simpleButtonCancel.Size = new System.Drawing.Size(64, 24);
            this.simpleButtonCancel.TabIndex = 15;
            this.simpleButtonCancel.Text = "取消";
            this.simpleButtonCancel.ToolTip = "结束导入";
            // 
            // simpleButtonJump
            // 
            this.simpleButtonJump.Cursor = System.Windows.Forms.Cursors.Hand;
            this.simpleButtonJump.ImageIndex = 68;
            this.simpleButtonJump.ImageList = this.ImageList1;
            this.simpleButtonJump.Location = new System.Drawing.Point(120, 38);
            this.simpleButtonJump.Name = "simpleButtonJump";
            this.simpleButtonJump.Size = new System.Drawing.Size(64, 24);
            this.simpleButtonJump.TabIndex = 14;
            this.simpleButtonJump.Text = "跳过";
            this.simpleButtonJump.ToolTip = "忽略当前小班";
            // 
            // simpleButtonContinue
            // 
            this.simpleButtonContinue.Cursor = System.Windows.Forms.Cursors.Hand;
            this.simpleButtonContinue.ImageIndex = 66;
            this.simpleButtonContinue.ImageList = this.ImageList1;
            this.simpleButtonContinue.Location = new System.Drawing.Point(35, 38);
            this.simpleButtonContinue.Name = "simpleButtonContinue";
            this.simpleButtonContinue.Size = new System.Drawing.Size(64, 24);
            this.simpleButtonContinue.TabIndex = 13;
            this.simpleButtonContinue.Text = "继续";
            this.simpleButtonContinue.ToolTip = "继续导入";
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label4.ImageIndex = 93;
            this.label4.ImageList = this.ImageList1;
            this.label4.Location = new System.Drawing.Point(0, 5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(326, 29);
            this.label4.TabIndex = 9;
            this.label4.Text = "      相同位置已存在造林小班";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.labelprogress);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(6, 0);
            this.panel4.Name = "panel4";
            this.panel4.Padding = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.panel4.Size = new System.Drawing.Size(326, 58);
            this.panel4.TabIndex = 15;
            // 
            // labelprogress
            // 
            this.labelprogress.BackColor = System.Drawing.Color.Transparent;
            this.labelprogress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelprogress.Location = new System.Drawing.Point(0, 2);
            this.labelprogress.Name = "labelprogress";
            this.labelprogress.Size = new System.Drawing.Size(326, 54);
            this.labelprogress.TabIndex = 8;
            this.labelprogress.Text = "生成进度:";
            // 
            // UserControlInputXB
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.Controls.Add(this.panelLog);
            this.Controls.Add(this.panelSubID);
            this.Controls.Add(this.panelDo);
            this.Controls.Add(this.panelField);
            this.Controls.Add(this.panelResource);
            this.Name = "UserControlInputXB";
            this.Size = new System.Drawing.Size(338, 593);
            this.panelSubID.ResumeLayout(false);
            this.panelSetSubID.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup3.Properties)).EndInit();
            this.panelSetID.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit2.Properties)).EndInit();
            this.panelDo.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.progressBar.Properties)).EndInit();
            this.panelField.ResumeLayout(false);
            this.panelGridControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).EndInit();
            this.panelFieldMatch.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.checkPorpertyMatch.Properties)).EndInit();
            this.panelResource.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.listBoxDataList)).EndInit();
            this.panel12.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.buttonEditDataPath.Properties)).EndInit();
            this.panelLog.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelQuestion.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private void InitialValue()
        {
            try
            {
                IActiveView focusMap = this.mHookHelper.FocusMap as IActiveView;
                string configValue = "";
                if (this.mEditKind == "小班")
                {
                    this.mEditKind2 = "XB";
                    configValue = UtilFactory.GetConfigOpt().GetConfigValue("XBLayerName");
                }
                else if (this.mEditKind == "造林")
                {
                    this.mEditKind2 = "ZaoLin";
                    configValue = UtilFactory.GetConfigOpt().GetConfigValue("ZaoLinLayerName");
                }
                else if (this.mEditKind == "采伐")
                {
                    this.mEditKind2 = "CaiFa";
                    configValue = UtilFactory.GetConfigOpt().GetConfigValue("CaiFaLayerName");
                }
                else if (this.mEditKind == "火灾")
                {
                    this.mEditKind2 = "Fire";
                    configValue = UtilFactory.GetConfigOpt().GetConfigValue("FireLayerName");
                }
                else if (this.mEditKind == "自然灾害")
                {
                    this.mEditKind2 = "ZRZH";
                    configValue = UtilFactory.GetConfigOpt().GetConfigValue("ZRZHLayerName");
                }
                else if (this.mEditKind == "林业案件")
                {
                    this.mEditKind2 = "AnJian";
                    configValue = UtilFactory.GetConfigOpt().GetConfigValue("AnJianLayerName");
                }
                else if (this.mEditKind == "征占用")
                {
                    this.mEditKind2 = "ZZY";
                    configValue = UtilFactory.GetConfigOpt().GetConfigValue("ZZYLayerName");
                }
                this.m_EditWorkspace = EditTask.EditWorkspace;
                this.m_EditLayer = EditTask.EditLayer;
                if (this.m_EditLayer == null)
                {
                    this.m_EditLayer = EditTask.EditLayer;
                }
                ISpatialReference spatialReference = this.mHookHelper.FocusMap.SpatialReference;
                int num = (int) double.Parse(focusMap.Extent.YMin.ToString());
                int num2 = (int) double.Parse(focusMap.Extent.XMin.ToString());
                if (num2.ToString().Length > num.ToString().Length)
                {
                    this.mDaiHao = int.Parse(num2.ToString().Substring(0, 2));
                }
                else
                {
                    this.mDaiHao = 0;
                }
                this.mLayerList = null;
                this.mLayerList2 = null;
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlInputXB", "InitialValue", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void SetView(int kind)
        {
            try
            {
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlInputXB", "SetView", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }
    }
}

