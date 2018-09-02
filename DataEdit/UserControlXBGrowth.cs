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
    using ESRI.ArcGIS.Carto;
    using ESRI.ArcGIS.Controls;
    using ESRI.ArcGIS.Geodatabase;
    using FormBase;
    using GX_DB_INFO;
    using QueryCommon;
    using ShapeEdit;
    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.Data;
    using System.Diagnostics;
    using System.Drawing;
    using System.Windows.Forms;
    using SZMODEL_GXYSSZXJ;
    using TaskManage;
    using Utilities;

    public class UserControlXBGrowth : UserControlBase1
    {
        private ComboBoxEdit comboBoxCounty;
        private ComboBoxEdit comboBoxLinban;
        private ComboBoxEdit comboBoxTown;
        private ComboBoxEdit comboBoxVillage;
        private ComboBoxEdit comboBoxXiaoban;
        private ComboBoxEdit comboBoxXiban;
        private ComboBoxEdit comboBoxYear;
        private IContainer components = null;
        private GroupControl groupControl1;
        private GroupControl groupControlSingle;
        private DevExpress.Utils.ImageCollection imageCollection2;
        internal ImageList imageList0;
        internal ImageList ImageList1;
        internal ImageList imageList2;
        internal ImageList imageList3;
        private ImageList imageList4;
        internal ImageList imageList6;
        internal ImageList imageList7;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label32;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label labelIdentify;
        private Label labelprogress;
        private ITable m_CountyTable;
        private IFeatureLayer m_EditLayer;
        private IFeatureLayer m_QueryLayer;
        private ITable m_QueryTable;
        private ITable m_TownTable;
        private IFeatureLayer m_UnderLayer;
        private ITable m_VillageTable;
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
        private ArrayList mQueryList = null;
        private UserControlQueryResult mQueryResult;
        private UserControlQueryResult mQueryResult2;
        private bool mSelected;
        private DataTable mStateTable;
        private string mSubSysName = UtilFactory.GetConfigOpt().GetSystemName();
        private DataTable mUpdataTable;
        private Panel panel1;
        private Panel panel10;
        private Panel panel11;
        private Panel panel12;
        private Panel panel14;
        private Panel panel2;
        private Panel panel3;
        private Panel panel30;
        private Panel panel31;
        private Panel panel4;
        private Panel panel5;
        public Panel panel6;
        private Panel panel7;
        private Panel panel9;
        private Panel panelbasic;
        private PanelControl panelControl1;
        private Panel panelDistLocation;
        public Panel panelIDList;
        private Panel panelInfo;
        private Panel panelInfo2;
        private Panel panelLog;
        private RepositoryItemImageEdit repositoryItemImageEdit1;
        private RepositoryItemImageEdit repositoryItemImageEdit6;
        private RepositoryItemImageEdit repositoryItemImageEdit7;
        private RepositoryItemImageEdit repositoryItemImageEdit8;
        private RichTextBox richTextBox;
        private string sDesKeyField;
        public SimpleButton simpleButton1;
        public SimpleButton simpleButtonBatchUpdate;
        private SimpleButton simpleButtonInfo;
        private SimpleButton simpleButtonRefresh;
        public SimpleButton simpleButtonResult;
        public SimpleButton simpleButtonSingleUpdata;
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
        private TreeListColumn treeListColumn17;
        private TreeListColumn treeListColumn18;
        private Image WaitImg = null;
        private XtraTabControl xtraTabControl1;
        private XtraTabPage xtraTabPage1;
        private XtraTabPage xtraTabPage2;

        public UserControlXBGrowth()
        {
            this.InitializeComponent();
            this.WaitImg = this.label2.Image;
        }

        private void comboBoxBase_TextChanged(object sender, EventArgs e)
        {
            try
            {
                ArrayList tag;
                ComboBoxEdit edit = sender as ComboBoxEdit;
                DataTable table = (edit.Tag as ArrayList)[0] as DataTable;
                DataRow[] rowArray = null;
                if ((edit.Tag as ArrayList).Count > 1)
                {
                    rowArray = (edit.Tag as ArrayList)[1] as DataRow[];
                }
                if (edit.Name.Contains("County"))
                {
                    this.comboBoxTown.Properties.Items.Clear();
                    this.comboBoxTown.Properties.Items.Add("--");
                    this.comboBoxTown.Text = "--";
                    this.comboBoxVillage.Properties.Items.Clear();
                    this.comboBoxVillage.Properties.Items.Add("--");
                    this.comboBoxVillage.Text = "--";
                    this.comboBoxLinban.Properties.Items.Clear();
                    this.comboBoxLinban.Properties.Items.Add("--");
                    this.comboBoxLinban.Text = "--";
                    this.comboBoxXiaoban.Properties.Items.Clear();
                    this.comboBoxXiaoban.Properties.Items.Add("--");
                    this.comboBoxXiaoban.Text = "--";
                    this.comboBoxXiban.Properties.Items.Clear();
                    this.comboBoxXiban.Properties.Items.Add("--");
                    this.comboBoxXiban.Text = "--";
                    if (edit.SelectedIndex > 0)
                    {
                        tag = this.comboBoxTown.Tag as ArrayList;
                        if (rowArray != null)
                        {
                            this.SetDist(rowArray[edit.SelectedIndex - 1]["code"].ToString(), tag[0] as DataTable, this.comboBoxTown);
                        }
                        else
                        {
                            this.SetDist(table.Rows[edit.SelectedIndex - 1]["code"].ToString(), tag[0] as DataTable, this.comboBoxTown);
                        }
                    }
                }
                else if (edit.Name.Contains("Town"))
                {
                    this.comboBoxVillage.Properties.Items.Clear();
                    this.comboBoxVillage.Properties.Items.Add("--");
                    this.comboBoxVillage.Text = "--";
                    this.comboBoxLinban.Properties.Items.Clear();
                    this.comboBoxLinban.Properties.Items.Add("--");
                    this.comboBoxLinban.Text = "--";
                    this.comboBoxXiaoban.Properties.Items.Clear();
                    this.comboBoxXiaoban.Properties.Items.Add("--");
                    this.comboBoxXiaoban.Text = "--";
                    this.comboBoxXiban.Properties.Items.Clear();
                    this.comboBoxXiban.Properties.Items.Add("--");
                    this.comboBoxXiban.Text = "--";
                    if (edit.SelectedIndex > 0)
                    {
                        tag = this.comboBoxVillage.Tag as ArrayList;
                        if (rowArray != null)
                        {
                            this.SetDist(rowArray[edit.SelectedIndex - 1]["code"].ToString(), tag[0] as DataTable, this.comboBoxVillage);
                        }
                        else
                        {
                            this.SetDist(table.Rows[edit.SelectedIndex - 1]["code"].ToString(), tag[0] as DataTable, this.comboBoxVillage);
                        }
                    }
                }
                else if (edit.Name.Contains("Village"))
                {
                    this.comboBoxLinban.Properties.Items.Clear();
                    this.comboBoxLinban.Properties.Items.Add("--");
                    this.comboBoxLinban.Text = "--";
                    this.comboBoxXiaoban.Properties.Items.Clear();
                    this.comboBoxXiaoban.Properties.Items.Add("--");
                    this.comboBoxXiaoban.Text = "--";
                    this.comboBoxXiban.Properties.Items.Clear();
                    this.comboBoxXiban.Properties.Items.Add("--");
                    this.comboBoxXiban.Text = "--";
                    if (edit.SelectedIndex > 0)
                    {
                        tag = this.comboBoxVillage.Tag as ArrayList;
                        if (rowArray != null)
                        {
                            this.SetDist(rowArray[edit.SelectedIndex - 1]["code"].ToString(), tag[0] as DataTable, this.comboBoxLinban);
                        }
                        else
                        {
                            this.SetDist(table.Rows[edit.SelectedIndex - 1]["code"].ToString(), tag[0] as DataTable, this.comboBoxLinban);
                        }
                    }
                }
                else if (edit.Name.Contains("Linban"))
                {
                    this.comboBoxXiaoban.Properties.Items.Clear();
                    this.comboBoxXiaoban.Properties.Items.Add("--");
                    this.comboBoxXiaoban.Text = "--";
                    this.comboBoxXiban.Properties.Items.Clear();
                    this.comboBoxXiban.Properties.Items.Add("--");
                    this.comboBoxXiban.Text = "--";
                    if (edit.SelectedIndex > 0)
                    {
                        tag = this.comboBoxLinban.Tag as ArrayList;
                        if (rowArray != null)
                        {
                            this.SetDist(rowArray[this.comboBoxVillage.SelectedIndex - 1]["code"].ToString(), tag[0] as DataTable, this.comboBoxXiaoban);
                        }
                        else
                        {
                            this.SetDist(table.Rows[edit.SelectedIndex - 1]["code"].ToString(), null, this.comboBoxXiaoban);
                        }
                    }
                }
                else if (edit.Name.Contains("Xiaoban"))
                {
                    this.comboBoxXiban.Properties.Items.Clear();
                    this.comboBoxXiban.Properties.Items.Add("--");
                    this.comboBoxXiban.Text = "--";
                    if (edit.SelectedIndex > 0)
                    {
                        tag = this.comboBoxXiaoban.Tag as ArrayList;
                        if (rowArray != null)
                        {
                            this.SetDist(rowArray[this.comboBoxVillage.SelectedIndex - 1]["code"].ToString(), tag[0] as DataTable, this.comboBoxXiban);
                        }
                        else
                        {
                            this.SetDist(table.Rows[edit.SelectedIndex - 1]["code"].ToString(), null, this.comboBoxXiban);
                        }
                    }
                }
                else if (edit.Name.Contains("Xiban"))
                {
                }
            }
            catch (Exception)
            {
            }
        }

        private void dbinfo_OnNatureUpdate(object sender, string msg, int step)
        {
            this.label2.Text = "      " + msg;
            this.label2.Refresh();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private string GetDistName(string scode)
        {
            try
            {
                DataTable table = (this.comboBoxCounty.Tag as ArrayList)[0] as DataTable;
                DataTable table2 = (this.comboBoxTown.Tag as ArrayList)[0] as DataTable;
                DataTable table3 = (this.comboBoxVillage.Tag as ArrayList)[0] as DataTable;
                string str = scode;
                if (scode.Length == 6)
                {
                    str = table.Select("code='" + scode + "'")[0]["name"].ToString();
                }
                else if (scode.Length == 9)
                {
                    str = table.Select("code='" + scode.Substring(0, 6) + "'")[0]["name"].ToString() + table2.Select("code='" + scode.Substring(0, 9) + "'")[0]["name"].ToString();
                }
                else if (scode.Length == 12)
                {
                    str = table.Select("code='" + scode.Substring(0, 6) + "'")[0]["name"].ToString() + table2.Select("code='" + scode.Substring(0, 9) + "'")[0]["name"].ToString() + table3.Select("code='" + scode.Substring(0, 12) + "'")[0]["name"].ToString();
                }
                else if (scode.Length == 3)
                {
                }
                return str;
            }
            catch (Exception)
            {
                return "";
            }
        }

        private string GetXBName(IFeature pFeature)
        {
            try
            {
                string[] strArray = UtilFactory.GetConfigOpt().GetConfigValue("CaiFaFieldNameD").Split(new char[] { ',' });
                string str = "";
                for (int i = 0; i < strArray.Length; i++)
                {
                    int index = pFeature.Fields.FindField(strArray[i]);
                    if (index > -1)
                    {
                        if ((pFeature.Fields.get_Field(index).Domain != null) && (pFeature.Fields.get_Field(index).Domain.Type == esriDomainType.esriDTCodedValue))
                        {
                            string str2 = "";
                            ICodedValueDomain domain = (ICodedValueDomain) pFeature.Fields.get_Field(index).Domain;
                            long num3 = Convert.ToInt64(pFeature.get_Value(index));
                            for (int j = 0; j < domain.CodeCount; j++)
                            {
                                if (num3 == Convert.ToInt64(domain.get_Value(j)))
                                {
                                    str2 = domain.get_Name(j);
                                    break;
                                }
                            }
                            str = str + str2;
                            continue;
                        }
                        if (pFeature.get_Value(index).ToString().Length == 6)
                        {
                            str = str + this.GetDistName(pFeature.get_Value(index).ToString());
                        }
                        else if (pFeature.get_Value(index).ToString().Length == 9)
                        {
                            str = str + this.GetDistName(pFeature.get_Value(index).ToString());
                        }
                        else if (pFeature.get_Value(index).ToString().Length == 12)
                        {
                            str = str + this.GetDistName(pFeature.get_Value(index).ToString());
                        }
                        else if ((pFeature.get_Value(index).ToString().Length == 4) && (i == 3))
                        {
                            str = str + pFeature.get_Value(index) + "林班";
                        }
                        else if ((pFeature.get_Value(index).ToString().Length == 4) && (i == 4))
                        {
                            str = str + pFeature.get_Value(index) + "小班";
                        }
                        else if ((pFeature.get_Value(index).ToString().Length <= 10) && (i == 5))
                        {
                            str = str + pFeature.get_Value(index) + "细班";
                        }
                        else
                        {
                            str = str + pFeature.get_Value(index);
                        }
                    }
                }
                return str.Trim();
            }
            catch (Exception)
            {
                return "";
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
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlXBLayerCombine", "Hook", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void InitialDist()
        {
            try
            {
                IFeatureWorkspace editWorkspace = EditTask.EditWorkspace;
                IWorkspace workspace2 = editWorkspace as IWorkspace;
                IWorkspaceDomains domains = workspace2 as IWorkspaceDomains;
                string[] strArray = UtilFactory.GetConfigOpt().GetConfigValue("XBFieldDist").Split(new char[] { ',' });
                string[] strArray2 = "County,Town,Village".Split(new char[] { ',' });
                ArrayList list = new ArrayList();
                list.Add(this.comboBoxCounty);
                list.Add(this.comboBoxTown);
                list.Add(this.comboBoxVillage);
                for (int i = 0; i < strArray2.Length; i++)
                {
                    ComboBoxEdit edit = list[i] as ComboBoxEdit;
                    edit.Properties.Items.Clear();
                    edit.Properties.Items.Add("--");
                    string configValue = UtilFactory.GetConfigOpt().GetConfigValue(strArray2[i] + "CodeTableName");
                    ITable table2 = editWorkspace.OpenTable(configValue);
                    string name = UtilFactory.GetConfigOpt().GetConfigValue(strArray2[i] + "CodeTableFieldName");
                    string str3 = UtilFactory.GetConfigOpt().GetConfigValue(strArray2[i] + "CodeTableFieldCode");
                    IQueryFilter queryFilter = new QueryFilterClass();
                    queryFilter.WhereClause = UtilFactory.GetConfigOpt().GetConfigValue(strArray2[i] + "CodeTableWhereStr");
                    ICursor cursor = table2.Search(queryFilter, false);
                    IRow row = cursor.NextRow();
                    DataTable table = new DataTable();
                    DataColumn column = new DataColumn("code", typeof(string));
                    table.Columns.Add(column);
                    column = new DataColumn("name", typeof(string));
                    table.Columns.Add(column);
                    while (row != null)
                    {
                        int index = row.Fields.FindField(name);
                        int num3 = row.Fields.FindField(str3);
                        DataRow row2 = table.NewRow();
                        row2["code"] = row.get_Value(num3);
                        row2["name"] = row.get_Value(index);
                        table.Rows.Add(row2);
                        if (i == 0)
                        {
                            edit.Properties.Items.Add(row2["name"].ToString());
                        }
                        row = cursor.NextRow();
                    }
                    if (table.Rows.Count > 0)
                    {
                        edit.SelectedIndex = 0;
                        ArrayList list2 = new ArrayList();
                        list2.Add(table);
                        edit.Tag = list2;
                    }
                }
                DataTable table3 = (this.comboBoxVillage.Tag as ArrayList)[0] as DataTable;
                this.comboBoxLinban.SelectedIndex = 0;
                this.comboBoxXiaoban.SelectedIndex = 0;
                this.comboBoxXiban.SelectedIndex = 0;
                ArrayList list3 = new ArrayList();
                list3.Add(table3);
                this.comboBoxLinban.Tag = list3;
                this.comboBoxXiaoban.Tag = list3;
                this.comboBoxXiban.Tag = list3;
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlXBLayerCombine", "InitializeGISControls", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserControlXBGrowth));
            DevExpress.Utils.SuperToolTip superToolTip1 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipItem toolTipItem1 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.SuperToolTip superToolTip2 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipItem toolTipItem2 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.SuperToolTip superToolTip3 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipItem toolTipItem3 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.SuperToolTip superToolTip4 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipItem toolTipItem4 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.SuperToolTip superToolTip5 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipItem toolTipItem5 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.SuperToolTip superToolTip6 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipItem toolTipItem6 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.SuperToolTip superToolTip7 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipItem toolTipItem7 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.SuperToolTip superToolTip8 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipItem toolTipItem8 = new DevExpress.Utils.ToolTipItem();
            this.imageCollection2 = new DevExpress.Utils.ImageCollection();
            this.treeListColumn17 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn18 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.repositoryItemImageEdit8 = new DevExpress.XtraEditors.Repository.RepositoryItemImageEdit();
            this.panelLog = new System.Windows.Forms.Panel();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.richTextBox = new System.Windows.Forms.RichTextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.labelprogress = new System.Windows.Forms.Label();
            this.treeListColumn16 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn15 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn14 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
            this.tList2 = new DevExpress.XtraTreeList.TreeList();
            this.treeListColumn11 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn12 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn13 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.panelInfo2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.ImageList1 = new System.Windows.Forms.ImageList();
            this.repositoryItemImageEdit7 = new DevExpress.XtraEditors.Repository.RepositoryItemImageEdit();
            this.repositoryItemImageEdit6 = new DevExpress.XtraEditors.Repository.RepositoryItemImageEdit();
            this.repositoryItemImageEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemImageEdit();
            this.panel6 = new System.Windows.Forms.Panel();
            this.simpleButtonBatchUpdate = new DevExpress.XtraEditors.SimpleButton();
            this.panel7 = new System.Windows.Forms.Panel();
            this.simpleButtonResult = new DevExpress.XtraEditors.SimpleButton();
            this.panelIDList = new System.Windows.Forms.Panel();
            this.simpleButtonRefresh = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonInfo = new DevExpress.XtraEditors.SimpleButton();
            this.imageList2 = new System.Windows.Forms.ImageList();
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.tList = new DevExpress.XtraTreeList.TreeList();
            this.tListCol1 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.tListCol2 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.tListCol3 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.tListCol4 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.tListCol5 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.tListCol6 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.tListCol7 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.tListCol8 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.imageList3 = new System.Windows.Forms.ImageList();
            this.imageList0 = new System.Windows.Forms.ImageList();
            this.imageList7 = new System.Windows.Forms.ImageList();
            this.imageList6 = new System.Windows.Forms.ImageList();
            this.imageList4 = new System.Windows.Forms.ImageList();
            this.panelInfo = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.labelIdentify = new System.Windows.Forms.Label();
            this.groupControlSingle = new DevExpress.XtraEditors.GroupControl();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.simpleButtonSingleUpdata = new DevExpress.XtraEditors.SimpleButton();
            this.panelbasic = new System.Windows.Forms.Panel();
            this.panelDistLocation = new System.Windows.Forms.Panel();
            this.panel10 = new System.Windows.Forms.Panel();
            this.panel31 = new System.Windows.Forms.Panel();
            this.comboBoxXiban = new DevExpress.XtraEditors.ComboBoxEdit();
            this.panel30 = new System.Windows.Forms.Panel();
            this.comboBoxXiaoban = new DevExpress.XtraEditors.ComboBoxEdit();
            this.panel1 = new System.Windows.Forms.Panel();
            this.comboBoxLinban = new DevExpress.XtraEditors.ComboBoxEdit();
            this.panel4 = new System.Windows.Forms.Panel();
            this.comboBoxVillage = new DevExpress.XtraEditors.ComboBoxEdit();
            this.panel12 = new System.Windows.Forms.Panel();
            this.comboBoxTown = new DevExpress.XtraEditors.ComboBoxEdit();
            this.panel11 = new System.Windows.Forms.Panel();
            this.comboBoxCounty = new DevExpress.XtraEditors.ComboBoxEdit();
            this.panel14 = new System.Windows.Forms.Panel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.label32 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.panel5 = new System.Windows.Forms.Panel();
            this.comboBoxYear = new DevExpress.XtraEditors.ComboBoxEdit();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageEdit8)).BeginInit();
            this.panelLog.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.xtraTabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tList2)).BeginInit();
            this.panelInfo2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageEdit7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageEdit6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageEdit1)).BeginInit();
            this.panel6.SuspendLayout();
            this.panelIDList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tList)).BeginInit();
            this.panelInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlSingle)).BeginInit();
            this.groupControlSingle.SuspendLayout();
            this.panelbasic.SuspendLayout();
            this.panelDistLocation.SuspendLayout();
            this.panel10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxXiban.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxXiaoban.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxLinban.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxVillage.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxTown.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxCounty.Properties)).BeginInit();
            this.panel9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxYear.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // imageCollection2
            // 
            this.imageCollection2.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection2.ImageStream")));
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
            this.imageCollection2.Images.SetKeyName(16, "maps.png");
            this.imageCollection2.Images.SetKeyName(17, "maps--arrow.png");
            this.imageCollection2.Images.SetKeyName(18, "maps--exclamation.png");
            this.imageCollection2.Images.SetKeyName(19, "maps--minus.png");
            this.imageCollection2.Images.SetKeyName(20, "maps--pencil.png");
            this.imageCollection2.Images.SetKeyName(21, "maps--pencil2.png");
            this.imageCollection2.Images.SetKeyName(22, "maps--pencil3.png");
            this.imageCollection2.Images.SetKeyName(23, "maps--plus.png");
            this.imageCollection2.Images.SetKeyName(24, "maps-stack.png");
            this.imageCollection2.Images.SetKeyName(25, "pathing3.png");
            this.imageCollection2.Images.SetKeyName(26, "picture_pencil.png");
            this.imageCollection2.Images.SetKeyName(27, "table__arrow.png");
            this.imageCollection2.Images.SetKeyName(28, "arrow_large_up.png");
            this.imageCollection2.Images.SetKeyName(29, "web design_16_hot.png");
            this.imageCollection2.Images.SetKeyName(30, "ksirtet16.png");
            this.imageCollection2.Images.SetKeyName(31, "node-select-child.png");
            this.imageCollection2.Images.SetKeyName(32, "flag blue.png");
            this.imageCollection2.Images.SetKeyName(33, "flag red.png");
            this.imageCollection2.Images.SetKeyName(34, "flag yellow.png");
            this.imageCollection2.Images.SetKeyName(35, "image.png");
            this.imageCollection2.Images.SetKeyName(36, "image_edit.png");
            this.imageCollection2.Images.SetKeyName(37, "image_magnify.png");
            this.imageCollection2.Images.SetKeyName(38, "page_edit.png");
            this.imageCollection2.Images.SetKeyName(39, "page_paintbrush.png");
            this.imageCollection2.Images.SetKeyName(40, "page_white_edit.png");
            this.imageCollection2.Images.SetKeyName(41, "pencil.png");
            this.imageCollection2.Images.SetKeyName(42, "photo.png");
            this.imageCollection2.Images.SetKeyName(43, "photos.png");
            this.imageCollection2.Images.SetKeyName(44, "picture.png");
            this.imageCollection2.Images.SetKeyName(45, "picture_add.png");
            this.imageCollection2.Images.SetKeyName(46, "picture_delete.png");
            this.imageCollection2.Images.SetKeyName(47, "picture_edit.png");
            this.imageCollection2.Images.SetKeyName(48, "search.gif");
            this.imageCollection2.Images.SetKeyName(49, "table.png");
            this.imageCollection2.Images.SetKeyName(50, "table_edit.png");
            this.imageCollection2.Images.SetKeyName(51, "(01,40).png");
            this.imageCollection2.Images.SetKeyName(52, "(01,46).png");
            this.imageCollection2.Images.SetKeyName(53, "(09,46).png");
            this.imageCollection2.Images.SetKeyName(54, "(12,11).png");
            this.imageCollection2.Images.SetKeyName(55, "(14,36).png");
            this.imageCollection2.Images.SetKeyName(56, "(14,37).png");
            this.imageCollection2.Images.SetKeyName(57, "(15,25).png");
            this.imageCollection2.Images.SetKeyName(58, "(15,40).png");
            this.imageCollection2.Images.SetKeyName(59, "(16,32).png");
            this.imageCollection2.Images.SetKeyName(60, "(17,49).png");
            this.imageCollection2.Images.SetKeyName(61, "(19,01).png");
            this.imageCollection2.Images.SetKeyName(62, "(24,04).png");
            this.imageCollection2.Images.SetKeyName(63, "(24,32).png");
            this.imageCollection2.Images.SetKeyName(64, "(28,09).png");
            this.imageCollection2.Images.SetKeyName(65, "(29,04).png");
            this.imageCollection2.Images.SetKeyName(66, "(30,24).png");
            this.imageCollection2.Images.SetKeyName(67, "(32,04).png");
            this.imageCollection2.Images.SetKeyName(68, "(32,24).png");
            this.imageCollection2.Images.SetKeyName(69, "(33,14).png");
            this.imageCollection2.Images.SetKeyName(70, "(35,29).png");
            this.imageCollection2.Images.SetKeyName(71, "(35,31).png");
            this.imageCollection2.Images.SetKeyName(72, "(35,45).png");
            this.imageCollection2.Images.SetKeyName(73, "(36,04).png");
            this.imageCollection2.Images.SetKeyName(74, "(36,47).png");
            this.imageCollection2.Images.SetKeyName(75, "(39,47).png");
            this.imageCollection2.Images.SetKeyName(76, "(40,05).png");
            this.imageCollection2.Images.SetKeyName(77, "(44,27).png");
            this.imageCollection2.Images.SetKeyName(78, "(45,28).png");
            this.imageCollection2.Images.SetKeyName(79, "(49,06).png");
            this.imageCollection2.Images.SetKeyName(80, "(49,48).png");
            this.imageCollection2.Images.SetKeyName(81, "(15,49).png");
            this.imageCollection2.Images.SetKeyName(82, "(27,15).png");
            this.imageCollection2.Images.SetKeyName(83, "(00,41).png");
            this.imageCollection2.Images.SetKeyName(84, "(00,47).png");
            this.imageCollection2.Images.SetKeyName(85, "(02,10).png");
            this.imageCollection2.Images.SetKeyName(86, "(02,40).png");
            this.imageCollection2.Images.SetKeyName(87, "(03,18).png");
            this.imageCollection2.Images.SetKeyName(88, "(06,02).png");
            this.imageCollection2.Images.SetKeyName(89, "(08,40).png");
            this.imageCollection2.Images.SetKeyName(90, "(10,41).png");
            this.imageCollection2.Images.SetKeyName(91, "(11,49).png");
            this.imageCollection2.Images.SetKeyName(92, "(13,15).png");
            // 
            // treeListColumn17
            // 
            this.treeListColumn17.Caption = "细班";
            this.treeListColumn17.FieldName = "细班";
            this.treeListColumn17.Name = "treeListColumn17";
            this.treeListColumn17.Visible = true;
            this.treeListColumn17.VisibleIndex = 6;
            // 
            // treeListColumn18
            // 
            this.treeListColumn18.Caption = "定位";
            this.treeListColumn18.FieldName = "定位";
            this.treeListColumn18.Name = "treeListColumn18";
            // 
            // repositoryItemImageEdit8
            // 
            this.repositoryItemImageEdit8.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("repositoryItemImageEdit8.Appearance.Image")));
            this.repositoryItemImageEdit8.Appearance.Options.UseImage = true;
            this.repositoryItemImageEdit8.AutoHeight = false;
            this.repositoryItemImageEdit8.Name = "repositoryItemImageEdit8";
            this.repositoryItemImageEdit8.ShowDropDown = DevExpress.XtraEditors.Controls.ShowDropDown.Never;
            // 
            // panelLog
            // 
            this.panelLog.BackColor = System.Drawing.Color.Transparent;
            this.panelLog.Controls.Add(this.panelControl1);
            this.panelLog.Controls.Add(this.panel3);
            this.panelLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelLog.Location = new System.Drawing.Point(5, 5);
            this.panelLog.Name = "panelLog";
            this.panelLog.Padding = new System.Windows.Forms.Padding(0, 7, 0, 0);
            this.panelLog.Size = new System.Drawing.Size(246, 221);
            this.panelLog.TabIndex = 30;
            this.panelLog.Visible = false;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.richTextBox);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 75);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(246, 146);
            this.panelControl1.TabIndex = 16;
            // 
            // richTextBox
            // 
            this.richTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox.Location = new System.Drawing.Point(2, 2);
            this.richTextBox.Name = "richTextBox";
            this.richTextBox.Size = new System.Drawing.Size(242, 142);
            this.richTextBox.TabIndex = 0;
            this.richTextBox.Text = "";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.labelprogress);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 7);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.panel3.Size = new System.Drawing.Size(246, 68);
            this.panel3.TabIndex = 15;
            // 
            // labelprogress
            // 
            this.labelprogress.BackColor = System.Drawing.Color.Transparent;
            this.labelprogress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelprogress.Location = new System.Drawing.Point(0, 2);
            this.labelprogress.Name = "labelprogress";
            this.labelprogress.Size = new System.Drawing.Size(246, 64);
            this.labelprogress.TabIndex = 8;
            this.labelprogress.Text = "生成进度:";
            // 
            // treeListColumn16
            // 
            this.treeListColumn16.Caption = "小班";
            this.treeListColumn16.FieldName = "定位";
            this.treeListColumn16.Name = "treeListColumn16";
            this.treeListColumn16.Visible = true;
            this.treeListColumn16.VisibleIndex = 5;
            this.treeListColumn16.Width = 38;
            // 
            // treeListColumn15
            // 
            this.treeListColumn15.Caption = "林班";
            this.treeListColumn15.FieldName = "变化原因";
            this.treeListColumn15.Name = "treeListColumn15";
            this.treeListColumn15.Visible = true;
            this.treeListColumn15.VisibleIndex = 4;
            this.treeListColumn15.Width = 39;
            // 
            // treeListColumn14
            // 
            this.treeListColumn14.Caption = "村";
            this.treeListColumn14.FieldName = "村";
            this.treeListColumn14.Name = "treeListColumn14";
            this.treeListColumn14.Visible = true;
            this.treeListColumn14.VisibleIndex = 3;
            this.treeListColumn14.Width = 26;
            // 
            // xtraTabPage2
            // 
            this.xtraTabPage2.Controls.Add(this.tList2);
            this.xtraTabPage2.Controls.Add(this.panelLog);
            this.xtraTabPage2.Name = "xtraTabPage2";
            this.xtraTabPage2.Padding = new System.Windows.Forms.Padding(5);
            this.xtraTabPage2.Size = new System.Drawing.Size(256, 231);
            toolTipItem1.Text = "未更新小班";
            superToolTip1.Items.Add(toolTipItem1);
            this.xtraTabPage2.SuperTip = superToolTip1;
            this.xtraTabPage2.Text = "未更新";
            // 
            // tList2
            // 
            this.tList2.Appearance.FocusedCell.BackColor = System.Drawing.Color.LightSkyBlue;
            this.tList2.Appearance.FocusedCell.BackColor2 = System.Drawing.Color.White;
            this.tList2.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Blue;
            this.tList2.Appearance.FocusedCell.Options.UseBackColor = true;
            this.tList2.Appearance.FocusedCell.Options.UseForeColor = true;
            this.tList2.Appearance.FocusedRow.BackColor = System.Drawing.Color.LightSkyBlue;
            this.tList2.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.White;
            this.tList2.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Blue;
            this.tList2.Appearance.FocusedRow.Options.UseBackColor = true;
            this.tList2.Appearance.FocusedRow.Options.UseForeColor = true;
            this.tList2.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.White;
            this.tList2.Appearance.HideSelectionRow.BackColor2 = System.Drawing.Color.White;
            this.tList2.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.Black;
            this.tList2.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.tList2.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.tList2.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.treeListColumn11,
            this.treeListColumn12,
            this.treeListColumn13,
            this.treeListColumn14,
            this.treeListColumn15,
            this.treeListColumn16,
            this.treeListColumn17,
            this.treeListColumn18});
            this.tList2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tList2.Location = new System.Drawing.Point(5, 5);
            this.tList2.Name = "tList2";
            this.tList2.BeginUnboundLoad();
            this.tList2.AppendNode(new object[] {
            "1",
            "XX县",
            null,
            null,
            null,
            null,
            null,
            null}, -1, 0, 0, 5);
            this.tList2.EndUnboundLoad();
            this.tList2.OptionsBehavior.Editable = false;
            this.tList2.OptionsView.AutoWidth = false;
            this.tList2.OptionsView.ShowHorzLines = false;
            this.tList2.OptionsView.ShowIndicator = false;
            this.tList2.OptionsView.ShowRoot = false;
            this.tList2.OptionsView.ShowSummaryFooter = true;
            this.tList2.OptionsView.ShowVertLines = false;
            this.tList2.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemImageEdit8});
            this.tList2.Size = new System.Drawing.Size(246, 221);
            this.tList2.TabIndex = 7;
            this.tList2.TreeLevelWidth = 12;
            this.tList2.TreeLineStyle = DevExpress.XtraTreeList.LineStyle.None;
            // 
            // treeListColumn11
            // 
            this.treeListColumn11.Caption = "编号";
            this.treeListColumn11.FieldName = "ID";
            this.treeListColumn11.Name = "treeListColumn11";
            this.treeListColumn11.Visible = true;
            this.treeListColumn11.VisibleIndex = 0;
            this.treeListColumn11.Width = 36;
            // 
            // treeListColumn12
            // 
            this.treeListColumn12.Caption = "县";
            this.treeListColumn12.FieldName = "县";
            this.treeListColumn12.Name = "treeListColumn12";
            this.treeListColumn12.Visible = true;
            this.treeListColumn12.VisibleIndex = 1;
            this.treeListColumn12.Width = 32;
            // 
            // treeListColumn13
            // 
            this.treeListColumn13.Caption = "乡";
            this.treeListColumn13.FieldName = "乡";
            this.treeListColumn13.Name = "treeListColumn13";
            this.treeListColumn13.Visible = true;
            this.treeListColumn13.VisibleIndex = 2;
            this.treeListColumn13.Width = 25;
            // 
            // panelInfo2
            // 
            this.panelInfo2.Controls.Add(this.label2);
            this.panelInfo2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelInfo2.Location = new System.Drawing.Point(2, 88);
            this.panelInfo2.Name = "panelInfo2";
            this.panelInfo2.Padding = new System.Windows.Forms.Padding(7);
            this.panelInfo2.Size = new System.Drawing.Size(258, 33);
            this.panelInfo2.TabIndex = 40;
            this.panelInfo2.Visible = false;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Image = ((System.Drawing.Image)(resources.GetObject("label2.Image")));
            this.label2.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.label2.Location = new System.Drawing.Point(7, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(244, 19);
            this.label2.TabIndex = 0;
            this.label2.Text = "      正在更新...";
            // 
            // ImageList1
            // 
            this.ImageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList1.ImageStream")));
            this.ImageList1.TransparentColor = System.Drawing.Color.Transparent;
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
            this.ImageList1.Images.SetKeyName(69, "(44,23).png");
            this.ImageList1.Images.SetKeyName(70, "(12,29).png");
            this.ImageList1.Images.SetKeyName(71, "(34,00).png");
            this.ImageList1.Images.SetKeyName(72, "(03,02).png");
            this.ImageList1.Images.SetKeyName(73, "(49,06).png");
            this.ImageList1.Images.SetKeyName(74, "(09,13).png");
            this.ImageList1.Images.SetKeyName(75, "(16,47).png");
            this.ImageList1.Images.SetKeyName(76, "(13,47).png");
            this.ImageList1.Images.SetKeyName(77, "(18,01).png");
            this.ImageList1.Images.SetKeyName(78, "(18,13).png");
            this.ImageList1.Images.SetKeyName(79, "(19,01).png");
            this.ImageList1.Images.SetKeyName(80, "(28,40).png");
            this.ImageList1.Images.SetKeyName(81, "(39,47).png");
            this.ImageList1.Images.SetKeyName(82, "(45,12).png");
            this.ImageList1.Images.SetKeyName(83, "(45,17).png");
            this.ImageList1.Images.SetKeyName(84, "(45,41).png");
            this.ImageList1.Images.SetKeyName(85, "arrow_refresh_small.png");
            this.ImageList1.Images.SetKeyName(86, "(11,29).png");
            this.ImageList1.Images.SetKeyName(87, "(12,29).png");
            this.ImageList1.Images.SetKeyName(88, "(12,11).png");
            this.ImageList1.Images.SetKeyName(89, "(24,28).png");
            this.ImageList1.Images.SetKeyName(90, "");
            this.ImageList1.Images.SetKeyName(91, "home_16.png");
            this.ImageList1.Images.SetKeyName(92, "(00,41).png");
            this.ImageList1.Images.SetKeyName(93, "image-info.png");
            this.ImageList1.Images.SetKeyName(94, "info.png");
            // 
            // repositoryItemImageEdit7
            // 
            this.repositoryItemImageEdit7.AutoHeight = false;
            this.repositoryItemImageEdit7.Name = "repositoryItemImageEdit7";
            // 
            // repositoryItemImageEdit6
            // 
            this.repositoryItemImageEdit6.AutoHeight = false;
            this.repositoryItemImageEdit6.Name = "repositoryItemImageEdit6";
            this.repositoryItemImageEdit6.ShowDropDown = DevExpress.XtraEditors.Controls.ShowDropDown.Never;
            // 
            // repositoryItemImageEdit1
            // 
            this.repositoryItemImageEdit1.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("repositoryItemImageEdit1.Appearance.Image")));
            this.repositoryItemImageEdit1.Appearance.Options.UseImage = true;
            this.repositoryItemImageEdit1.AutoHeight = false;
            this.repositoryItemImageEdit1.Name = "repositoryItemImageEdit1";
            this.repositoryItemImageEdit1.ShowDropDown = DevExpress.XtraEditors.Controls.ShowDropDown.Never;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.Transparent;
            this.panel6.Controls.Add(this.simpleButtonBatchUpdate);
            this.panel6.Controls.Add(this.panel7);
            this.panel6.Controls.Add(this.simpleButtonResult);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(2, 50);
            this.panel6.Name = "panel6";
            this.panel6.Padding = new System.Windows.Forms.Padding(0, 6, 0, 6);
            this.panel6.Size = new System.Drawing.Size(258, 38);
            this.panel6.TabIndex = 37;
            // 
            // simpleButtonBatchUpdate
            // 
            this.simpleButtonBatchUpdate.Dock = System.Windows.Forms.DockStyle.Right;
            this.simpleButtonBatchUpdate.ImageIndex = 70;
            this.simpleButtonBatchUpdate.ImageList = this.imageCollection2;
            this.simpleButtonBatchUpdate.Location = new System.Drawing.Point(107, 6);
            this.simpleButtonBatchUpdate.Name = "simpleButtonBatchUpdate";
            this.simpleButtonBatchUpdate.Size = new System.Drawing.Size(72, 26);
            toolTipItem2.Text = "批量更新年度小班蓄积、林龄等";
            superToolTip2.Items.Add(toolTipItem2);
            this.simpleButtonBatchUpdate.SuperTip = superToolTip2;
            this.simpleButtonBatchUpdate.TabIndex = 12;
            this.simpleButtonBatchUpdate.Text = "批量更新";
            this.simpleButtonBatchUpdate.Click += new System.EventHandler(this.simpleButtonBatchUpdate_Click);
            // 
            // panel7
            // 
            this.panel7.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel7.Location = new System.Drawing.Point(179, 6);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(7, 26);
            this.panel7.TabIndex = 13;
            // 
            // simpleButtonResult
            // 
            this.simpleButtonResult.Dock = System.Windows.Forms.DockStyle.Right;
            this.simpleButtonResult.ImageIndex = 49;
            this.simpleButtonResult.ImageList = this.imageCollection2;
            this.simpleButtonResult.Location = new System.Drawing.Point(186, 6);
            this.simpleButtonResult.Name = "simpleButtonResult";
            this.simpleButtonResult.Size = new System.Drawing.Size(72, 26);
            toolTipItem3.Text = "查看自然更新执行结果";
            superToolTip3.Items.Add(toolTipItem3);
            this.simpleButtonResult.SuperTip = superToolTip3;
            this.simpleButtonResult.TabIndex = 10;
            this.simpleButtonResult.Text = "查看结果";
            // 
            // panelIDList
            // 
            this.panelIDList.Controls.Add(this.simpleButtonRefresh);
            this.panelIDList.Controls.Add(this.simpleButtonInfo);
            this.panelIDList.Controls.Add(this.xtraTabControl1);
            this.panelIDList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelIDList.Location = new System.Drawing.Point(4, 444);
            this.panelIDList.Name = "panelIDList";
            this.panelIDList.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.panelIDList.Size = new System.Drawing.Size(262, 264);
            this.panelIDList.TabIndex = 39;
            this.panelIDList.Visible = false;
            // 
            // simpleButtonRefresh
            // 
            this.simpleButtonRefresh.ImageIndex = 85;
            this.simpleButtonRefresh.ImageList = this.ImageList1;
            this.simpleButtonRefresh.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.simpleButtonRefresh.Location = new System.Drawing.Point(141, 1);
            this.simpleButtonRefresh.Name = "simpleButtonRefresh";
            this.simpleButtonRefresh.Size = new System.Drawing.Size(58, 23);
            toolTipItem4.Text = "刷新列表";
            superToolTip4.Items.Add(toolTipItem4);
            this.simpleButtonRefresh.SuperTip = superToolTip4;
            this.simpleButtonRefresh.TabIndex = 4;
            this.simpleButtonRefresh.Text = "刷新";
            // 
            // simpleButtonInfo
            // 
            this.simpleButtonInfo.ImageIndex = 4;
            this.simpleButtonInfo.ImageList = this.imageList2;
            this.simpleButtonInfo.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.simpleButtonInfo.Location = new System.Drawing.Point(204, 1);
            this.simpleButtonInfo.Name = "simpleButtonInfo";
            this.simpleButtonInfo.Size = new System.Drawing.Size(58, 23);
            toolTipItem5.Text = "详细信息";
            superToolTip5.Items.Add(toolTipItem5);
            this.simpleButtonInfo.SuperTip = superToolTip5;
            this.simpleButtonInfo.TabIndex = 2;
            this.simpleButtonInfo.Text = "信息";
            // 
            // imageList2
            // 
            this.imageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList2.ImageStream")));
            this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
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
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl1.Location = new System.Drawing.Point(0, 4);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.Padding = new System.Windows.Forms.Padding(5);
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPage1;
            this.xtraTabControl1.Size = new System.Drawing.Size(262, 260);
            this.xtraTabControl1.TabIndex = 0;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1,
            this.xtraTabPage2});
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Controls.Add(this.tList);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Padding = new System.Windows.Forms.Padding(5);
            this.xtraTabPage1.Size = new System.Drawing.Size(256, 231);
            toolTipItem6.Text = "更新小班";
            superToolTip6.Items.Add(toolTipItem6);
            this.xtraTabPage1.SuperTip = superToolTip6;
            this.xtraTabPage1.Text = "已更新";
            // 
            // tList
            // 
            this.tList.Appearance.FocusedCell.BackColor = System.Drawing.Color.LightSkyBlue;
            this.tList.Appearance.FocusedCell.BackColor2 = System.Drawing.Color.White;
            this.tList.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Blue;
            this.tList.Appearance.FocusedCell.Options.UseBackColor = true;
            this.tList.Appearance.FocusedCell.Options.UseForeColor = true;
            this.tList.Appearance.FocusedRow.BackColor = System.Drawing.Color.LightSkyBlue;
            this.tList.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.White;
            this.tList.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Blue;
            this.tList.Appearance.FocusedRow.Options.UseBackColor = true;
            this.tList.Appearance.FocusedRow.Options.UseForeColor = true;
            this.tList.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.White;
            this.tList.Appearance.HideSelectionRow.BackColor2 = System.Drawing.Color.White;
            this.tList.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.Black;
            this.tList.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.tList.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.tList.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.tListCol1,
            this.tListCol2,
            this.tListCol3,
            this.tListCol4,
            this.tListCol5,
            this.tListCol6,
            this.tListCol7,
            this.tListCol8});
            this.tList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tList.Location = new System.Drawing.Point(5, 5);
            this.tList.Name = "tList";
            this.tList.BeginUnboundLoad();
            this.tList.AppendNode(new object[] {
            "1",
            null,
            null,
            null,
            null,
            null,
            null,
            null}, -1, 0, 0, 5);
            this.tList.EndUnboundLoad();
            this.tList.OptionsBehavior.Editable = false;
            this.tList.OptionsView.AutoWidth = false;
            this.tList.OptionsView.ShowHorzLines = false;
            this.tList.OptionsView.ShowIndicator = false;
            this.tList.OptionsView.ShowRoot = false;
            this.tList.OptionsView.ShowSummaryFooter = true;
            this.tList.OptionsView.ShowVertLines = false;
            this.tList.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemImageEdit1,
            this.repositoryItemImageEdit6,
            this.repositoryItemImageEdit7});
            this.tList.Size = new System.Drawing.Size(246, 221);
            this.tList.TabIndex = 6;
            this.tList.TreeLevelWidth = 12;
            this.tList.TreeLineStyle = DevExpress.XtraTreeList.LineStyle.None;
            // 
            // tListCol1
            // 
            this.tListCol1.Caption = "编号";
            this.tListCol1.FieldName = "ID";
            this.tListCol1.Name = "tListCol1";
            this.tListCol1.Visible = true;
            this.tListCol1.VisibleIndex = 0;
            this.tListCol1.Width = 36;
            // 
            // tListCol2
            // 
            this.tListCol2.Caption = "县";
            this.tListCol2.FieldName = "县";
            this.tListCol2.Name = "tListCol2";
            this.tListCol2.Visible = true;
            this.tListCol2.VisibleIndex = 1;
            this.tListCol2.Width = 31;
            // 
            // tListCol3
            // 
            this.tListCol3.Caption = "乡";
            this.tListCol3.FieldName = "乡";
            this.tListCol3.Name = "tListCol3";
            this.tListCol3.Visible = true;
            this.tListCol3.VisibleIndex = 2;
            this.tListCol3.Width = 31;
            // 
            // tListCol4
            // 
            this.tListCol4.Caption = "村";
            this.tListCol4.FieldName = "村";
            this.tListCol4.Name = "tListCol4";
            this.tListCol4.Visible = true;
            this.tListCol4.VisibleIndex = 3;
            this.tListCol4.Width = 29;
            // 
            // tListCol5
            // 
            this.tListCol5.Caption = "林班";
            this.tListCol5.FieldName = "定位";
            this.tListCol5.Name = "tListCol5";
            this.tListCol5.Visible = true;
            this.tListCol5.VisibleIndex = 4;
            this.tListCol5.Width = 39;
            // 
            // tListCol6
            // 
            this.tListCol6.Caption = "小班";
            this.tListCol6.FieldName = "信息";
            this.tListCol6.Name = "tListCol6";
            this.tListCol6.Visible = true;
            this.tListCol6.VisibleIndex = 5;
            this.tListCol6.Width = 44;
            // 
            // tListCol7
            // 
            this.tListCol7.Caption = "细班";
            this.tListCol7.FieldName = "状态";
            this.tListCol7.Name = "tListCol7";
            this.tListCol7.Visible = true;
            this.tListCol7.VisibleIndex = 6;
            this.tListCol7.Width = 31;
            // 
            // tListCol8
            // 
            this.tListCol8.Caption = "定位";
            this.tListCol8.FieldName = "定位";
            this.tListCol8.Name = "tListCol8";
            // 
            // imageList3
            // 
            this.imageList3.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList3.ImageStream")));
            this.imageList3.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList3.Images.SetKeyName(0, "(04,42).png");
            this.imageList3.Images.SetKeyName(1, "(03,42).png");
            this.imageList3.Images.SetKeyName(2, "(01,46).png");
            this.imageList3.Images.SetKeyName(3, "(01,49).png");
            this.imageList3.Images.SetKeyName(4, "(02,27).png");
            this.imageList3.Images.SetKeyName(5, "(03,42).png");
            // 
            // imageList0
            // 
            this.imageList0.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList0.ImageStream")));
            this.imageList0.TransparentColor = System.Drawing.Color.Transparent;
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
            // 
            // imageList7
            // 
            this.imageList7.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList7.ImageStream")));
            this.imageList7.TransparentColor = System.Drawing.Color.Transparent;
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
            // 
            // imageList6
            // 
            this.imageList6.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList6.ImageStream")));
            this.imageList6.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList6.Images.SetKeyName(0, "(03,42).png");
            this.imageList6.Images.SetKeyName(1, "(04,42).png");
            this.imageList6.Images.SetKeyName(2, "(01,46).png");
            this.imageList6.Images.SetKeyName(3, "(01,49).png");
            this.imageList6.Images.SetKeyName(4, "(02,27).png");
            this.imageList6.Images.SetKeyName(5, "(03,42).png");
            // 
            // imageList4
            // 
            this.imageList4.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList4.ImageStream")));
            this.imageList4.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList4.Images.SetKeyName(0, "001_45.gif");
            this.imageList4.Images.SetKeyName(1, "001_38.gif");
            this.imageList4.Images.SetKeyName(2, "blue_view_24x24.gif");
            this.imageList4.Images.SetKeyName(3, "gtk-edit.png");
            this.imageList4.Images.SetKeyName(4, "ico6.gif");
            // 
            // panelInfo
            // 
            this.panelInfo.Controls.Add(this.label1);
            this.panelInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelInfo.Location = new System.Drawing.Point(4, 33);
            this.panelInfo.Name = "panelInfo";
            this.panelInfo.Padding = new System.Windows.Forms.Padding(7);
            this.panelInfo.Size = new System.Drawing.Size(262, 60);
            this.panelInfo.TabIndex = 38;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(7, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(248, 46);
            this.label1.TabIndex = 0;
            this.label1.Text = "年度小班信息\r\n共计\r\n已更新,未更新";
            // 
            // labelIdentify
            // 
            this.labelIdentify.BackColor = System.Drawing.Color.Transparent;
            this.labelIdentify.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelIdentify.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelIdentify.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.labelIdentify.Image = ((System.Drawing.Image)(resources.GetObject("labelIdentify.Image")));
            this.labelIdentify.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelIdentify.Location = new System.Drawing.Point(4, 0);
            this.labelIdentify.Name = "labelIdentify";
            this.labelIdentify.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.labelIdentify.Size = new System.Drawing.Size(262, 33);
            this.labelIdentify.TabIndex = 36;
            this.labelIdentify.Text = "      小班自然更新";
            this.labelIdentify.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupControlSingle
            // 
            this.groupControlSingle.Controls.Add(this.simpleButton1);
            this.groupControlSingle.Controls.Add(this.panel2);
            this.groupControlSingle.Controls.Add(this.simpleButtonSingleUpdata);
            this.groupControlSingle.Controls.Add(this.panelbasic);
            this.groupControlSingle.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControlSingle.Location = new System.Drawing.Point(4, 93);
            this.groupControlSingle.Name = "groupControlSingle";
            this.groupControlSingle.Padding = new System.Windows.Forms.Padding(4);
            this.groupControlSingle.Size = new System.Drawing.Size(262, 228);
            this.groupControlSingle.TabIndex = 42;
            this.groupControlSingle.Text = "指定更新";
            // 
            // simpleButton1
            // 
            this.simpleButton1.Dock = System.Windows.Forms.DockStyle.Right;
            this.simpleButton1.ImageIndex = 66;
            this.simpleButton1.ImageList = this.imageCollection2;
            this.simpleButton1.Location = new System.Drawing.Point(129, 196);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(60, 26);
            toolTipItem7.Text = "定位指定班块";
            superToolTip7.Items.Add(toolTipItem7);
            this.simpleButton1.SuperTip = superToolTip7;
            this.simpleButton1.TabIndex = 45;
            this.simpleButton1.Text = "定位";
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(189, 196);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(7, 26);
            this.panel2.TabIndex = 44;
            // 
            // simpleButtonSingleUpdata
            // 
            this.simpleButtonSingleUpdata.Dock = System.Windows.Forms.DockStyle.Right;
            this.simpleButtonSingleUpdata.ImageIndex = 76;
            this.simpleButtonSingleUpdata.ImageList = this.imageCollection2;
            this.simpleButtonSingleUpdata.Location = new System.Drawing.Point(196, 196);
            this.simpleButtonSingleUpdata.Name = "simpleButtonSingleUpdata";
            this.simpleButtonSingleUpdata.Size = new System.Drawing.Size(60, 26);
            toolTipItem8.Text = "指定更新年度小班蓄积、林龄等";
            superToolTip8.Items.Add(toolTipItem8);
            this.simpleButtonSingleUpdata.SuperTip = superToolTip8;
            this.simpleButtonSingleUpdata.TabIndex = 43;
            this.simpleButtonSingleUpdata.Text = "更新";
            this.simpleButtonSingleUpdata.Click += new System.EventHandler(this.simpleButtonSingleUpdata_Click);
            // 
            // panelbasic
            // 
            this.panelbasic.Controls.Add(this.panelDistLocation);
            this.panelbasic.Controls.Add(this.panel9);
            this.panelbasic.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelbasic.Location = new System.Drawing.Point(6, 26);
            this.panelbasic.Name = "panelbasic";
            this.panelbasic.Padding = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.panelbasic.Size = new System.Drawing.Size(250, 170);
            this.panelbasic.TabIndex = 42;
            // 
            // panelDistLocation
            // 
            this.panelDistLocation.BackColor = System.Drawing.Color.Transparent;
            this.panelDistLocation.Controls.Add(this.panel10);
            this.panelDistLocation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDistLocation.ForeColor = System.Drawing.Color.Black;
            this.panelDistLocation.Location = new System.Drawing.Point(62, 0);
            this.panelDistLocation.Name = "panelDistLocation";
            this.panelDistLocation.Size = new System.Drawing.Size(188, 169);
            this.panelDistLocation.TabIndex = 9;
            // 
            // panel10
            // 
            this.panel10.Controls.Add(this.panel31);
            this.panel10.Controls.Add(this.comboBoxXiban);
            this.panel10.Controls.Add(this.panel30);
            this.panel10.Controls.Add(this.comboBoxXiaoban);
            this.panel10.Controls.Add(this.panel1);
            this.panel10.Controls.Add(this.comboBoxLinban);
            this.panel10.Controls.Add(this.panel4);
            this.panel10.Controls.Add(this.comboBoxVillage);
            this.panel10.Controls.Add(this.panel12);
            this.panel10.Controls.Add(this.comboBoxTown);
            this.panel10.Controls.Add(this.panel11);
            this.panel10.Controls.Add(this.comboBoxCounty);
            this.panel10.Controls.Add(this.panel14);
            this.panel10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel10.Location = new System.Drawing.Point(0, 0);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(188, 169);
            this.panel10.TabIndex = 14;
            // 
            // panel31
            // 
            this.panel31.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel31.Location = new System.Drawing.Point(0, 156);
            this.panel31.Name = "panel31";
            this.panel31.Size = new System.Drawing.Size(188, 6);
            this.panel31.TabIndex = 18;
            // 
            // comboBoxXiban
            // 
            this.comboBoxXiban.Dock = System.Windows.Forms.DockStyle.Top;
            this.comboBoxXiban.Location = new System.Drawing.Point(0, 136);
            this.comboBoxXiban.Name = "comboBoxXiban";
            this.comboBoxXiban.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxXiban.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.comboBoxXiban.Size = new System.Drawing.Size(188, 20);
            this.comboBoxXiban.TabIndex = 21;
            this.comboBoxXiban.TextChanged += new System.EventHandler(this.comboBoxBase_TextChanged);
            // 
            // panel30
            // 
            this.panel30.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel30.Location = new System.Drawing.Point(0, 130);
            this.panel30.Name = "panel30";
            this.panel30.Size = new System.Drawing.Size(188, 6);
            this.panel30.TabIndex = 16;
            // 
            // comboBoxXiaoban
            // 
            this.comboBoxXiaoban.Dock = System.Windows.Forms.DockStyle.Top;
            this.comboBoxXiaoban.Location = new System.Drawing.Point(0, 110);
            this.comboBoxXiaoban.Name = "comboBoxXiaoban";
            this.comboBoxXiaoban.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxXiaoban.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.comboBoxXiaoban.Size = new System.Drawing.Size(188, 20);
            this.comboBoxXiaoban.TabIndex = 15;
            this.comboBoxXiaoban.TextChanged += new System.EventHandler(this.comboBoxBase_TextChanged);
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 104);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(188, 6);
            this.panel1.TabIndex = 14;
            // 
            // comboBoxLinban
            // 
            this.comboBoxLinban.Dock = System.Windows.Forms.DockStyle.Top;
            this.comboBoxLinban.Location = new System.Drawing.Point(0, 84);
            this.comboBoxLinban.Name = "comboBoxLinban";
            this.comboBoxLinban.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxLinban.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.comboBoxLinban.Size = new System.Drawing.Size(188, 20);
            this.comboBoxLinban.TabIndex = 13;
            this.comboBoxLinban.TextChanged += new System.EventHandler(this.comboBoxBase_TextChanged);
            // 
            // panel4
            // 
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 78);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(188, 6);
            this.panel4.TabIndex = 12;
            // 
            // comboBoxVillage
            // 
            this.comboBoxVillage.Dock = System.Windows.Forms.DockStyle.Top;
            this.comboBoxVillage.Location = new System.Drawing.Point(0, 58);
            this.comboBoxVillage.Name = "comboBoxVillage";
            this.comboBoxVillage.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxVillage.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.comboBoxVillage.Size = new System.Drawing.Size(188, 20);
            this.comboBoxVillage.TabIndex = 11;
            this.comboBoxVillage.TextChanged += new System.EventHandler(this.comboBoxBase_TextChanged);
            // 
            // panel12
            // 
            this.panel12.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel12.Location = new System.Drawing.Point(0, 52);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(188, 6);
            this.panel12.TabIndex = 7;
            // 
            // comboBoxTown
            // 
            this.comboBoxTown.Dock = System.Windows.Forms.DockStyle.Top;
            this.comboBoxTown.Location = new System.Drawing.Point(0, 32);
            this.comboBoxTown.Name = "comboBoxTown";
            this.comboBoxTown.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxTown.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.comboBoxTown.Size = new System.Drawing.Size(188, 20);
            this.comboBoxTown.TabIndex = 10;
            this.comboBoxTown.TextChanged += new System.EventHandler(this.comboBoxBase_TextChanged);
            // 
            // panel11
            // 
            this.panel11.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel11.Location = new System.Drawing.Point(0, 26);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(188, 6);
            this.panel11.TabIndex = 6;
            // 
            // comboBoxCounty
            // 
            this.comboBoxCounty.Dock = System.Windows.Forms.DockStyle.Top;
            this.comboBoxCounty.Location = new System.Drawing.Point(0, 6);
            this.comboBoxCounty.Name = "comboBoxCounty";
            this.comboBoxCounty.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxCounty.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.comboBoxCounty.Size = new System.Drawing.Size(188, 20);
            this.comboBoxCounty.TabIndex = 9;
            this.comboBoxCounty.TextChanged += new System.EventHandler(this.comboBoxBase_TextChanged);
            // 
            // panel14
            // 
            this.panel14.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel14.Location = new System.Drawing.Point(0, 0);
            this.panel14.Name = "panel14";
            this.panel14.Size = new System.Drawing.Size(188, 6);
            this.panel14.TabIndex = 8;
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.label32);
            this.panel9.Controls.Add(this.label3);
            this.panel9.Controls.Add(this.label4);
            this.panel9.Controls.Add(this.label9);
            this.panel9.Controls.Add(this.label8);
            this.panel9.Controls.Add(this.label7);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel9.Location = new System.Drawing.Point(0, 0);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(62, 169);
            this.panel9.TabIndex = 13;
            this.panel9.TabStop = true;
            // 
            // label32
            // 
            this.label32.Dock = System.Windows.Forms.DockStyle.Top;
            this.label32.Location = new System.Drawing.Point(0, 138);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(62, 27);
            this.label32.TabIndex = 8;
            this.label32.Text = "细班:";
            this.label32.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Location = new System.Drawing.Point(0, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 27);
            this.label3.TabIndex = 5;
            this.label3.Text = "小班:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Location = new System.Drawing.Point(0, 84);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 27);
            this.label4.TabIndex = 4;
            this.label4.Text = "林班 :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.Dock = System.Windows.Forms.DockStyle.Top;
            this.label9.Location = new System.Drawing.Point(0, 57);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(62, 27);
            this.label9.TabIndex = 3;
            this.label9.Text = "村 :";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.Dock = System.Windows.Forms.DockStyle.Top;
            this.label8.Location = new System.Drawing.Point(0, 30);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(62, 27);
            this.label8.TabIndex = 2;
            this.label8.Text = "乡镇 :";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.Dock = System.Windows.Forms.DockStyle.Top;
            this.label7.Location = new System.Drawing.Point(0, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 30);
            this.label7.TabIndex = 1;
            this.label7.Text = "区县 :";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.panelInfo2);
            this.groupControl1.Controls.Add(this.panel6);
            this.groupControl1.Controls.Add(this.panel5);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl1.Location = new System.Drawing.Point(4, 321);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(262, 123);
            this.groupControl1.TabIndex = 43;
            this.groupControl1.Text = "批量更新";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.comboBoxYear);
            this.panel5.Controls.Add(this.label6);
            this.panel5.Controls.Add(this.label5);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(2, 22);
            this.panel5.Name = "panel5";
            this.panel5.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.panel5.Size = new System.Drawing.Size(258, 28);
            this.panel5.TabIndex = 41;
            // 
            // comboBoxYear
            // 
            this.comboBoxYear.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBoxYear.EditValue = "1";
            this.comboBoxYear.Location = new System.Drawing.Point(66, 6);
            this.comboBoxYear.Name = "comboBoxYear";
            this.comboBoxYear.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxYear.Properties.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5"});
            this.comboBoxYear.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.comboBoxYear.Size = new System.Drawing.Size(113, 20);
            this.comboBoxYear.TabIndex = 22;
            // 
            // label6
            // 
            this.label6.Dock = System.Windows.Forms.DockStyle.Right;
            this.label6.Location = new System.Drawing.Point(179, 6);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 22);
            this.label6.TabIndex = 23;
            this.label6.Text = " 年";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.Dock = System.Windows.Forms.DockStyle.Left;
            this.label5.Location = new System.Drawing.Point(0, 6);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 22);
            this.label5.TabIndex = 14;
            this.label5.Text = "增长年数";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UserControlXBGrowth
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.Controls.Add(this.panelIDList);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.groupControlSingle);
            this.Controls.Add(this.panelInfo);
            this.Controls.Add(this.labelIdentify);
            this.Name = "UserControlXBGrowth";
            this.Padding = new System.Windows.Forms.Padding(4, 0, 8, 0);
            this.Size = new System.Drawing.Size(274, 708);
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageEdit8)).EndInit();
            this.panelLog.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.xtraTabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tList2)).EndInit();
            this.panelInfo2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageEdit7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageEdit6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageEdit1)).EndInit();
            this.panel6.ResumeLayout(false);
            this.panelIDList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.xtraTabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tList)).EndInit();
            this.panelInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControlSingle)).EndInit();
            this.groupControlSingle.ResumeLayout(false);
            this.panelbasic.ResumeLayout(false);
            this.panelDistLocation.ResumeLayout(false);
            this.panel10.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxXiban.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxXiaoban.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxLinban.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxVillage.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxTown.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxCounty.Properties)).EndInit();
            this.panel9.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxYear.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        public void InitialValue()
        {
            try
            {
                if (((this.mHookHelper != null) && (this.mHookHelper.FocusMap != null)) && (this.mHookHelper.FocusMap.LayerCount != 0))
                {
                    IMap focusMap = this.mHookHelper.FocusMap;
         
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
                        int num = this.m_EditLayer.FeatureClass.FeatureCount(null);
                        this.label1.Text = "年度小班信息\r\n共计" + num + "个小班";
                        IQueryFilter queryFilter = new QueryFilterClass();
                        queryFilter.WhereClause = "(not BHYY is null) and (ltrim(rtrim(BHYY))<>'')";
                        num = this.m_EditLayer.FeatureClass.FeatureCount(queryFilter);
                        string name = (this.m_EditLayer.FeatureClass as IDataset).Name;
                        this.label1.Text = string.Concat(new object[] { this.label1.Text, ";其中已变更", num, "个班块" });
                        queryFilter.WhereClause = "BHYY = '80'";
                        num = this.m_EditLayer.FeatureClass.FeatureCount(queryFilter);
                        this.label1.Text = string.Concat(new object[] { this.label1.Text, ",已自然更新", num, "个班块" });
                        queryFilter.WhereClause = "(BHYY is null) or (ltrim(rtrim(BHYY))='')";
                        num = this.m_EditLayer.FeatureClass.FeatureCount(queryFilter);
                        if (num != 0)
                        {
                            this.label1.Text = string.Concat(new object[] { this.label1.Text, ",未变更", num, "个班块" });
                        }
                        this.panelInfo.Height = 70;
                        this.InitialDist();
                        string configValue = UtilFactory.GetConfigOpt().GetConfigValue("CountyCodeTableName");
                        this.m_CountyTable = this.mFeatureWorkspace.OpenTable(configValue);
                        if (this.m_CountyTable != null)
                        {
                            configValue = UtilFactory.GetConfigOpt().GetConfigValue("TownCodeTableName");
                            this.m_TownTable = this.mFeatureWorkspace.OpenTable(configValue);
                            if (this.m_TownTable != null)
                            {
                                configValue = UtilFactory.GetConfigOpt().GetConfigValue("VillageCodeTableName");
                                this.m_VillageTable = this.mFeatureWorkspace.OpenTable(configValue);
                                if (this.m_VillageTable != null)
                                {
                                    this.mCurItemImageEdit0 = this.repositoryItemImageEdit1;
                                    this.mCurItemImageEdit0.Images = this.imageList0;
                                    this.mCurItemImageEdit6 = this.repositoryItemImageEdit6;
                                    this.mCurItemImageEdit6.Images = this.imageList0;
                                    this.simpleButtonInfo.Left = (this.xtraTabControl1.Left + this.xtraTabControl1.Width) - this.simpleButtonInfo.Width;
                                    this.simpleButtonInfo.Top = 3;
                                    this.simpleButtonRefresh.Left = (this.simpleButtonInfo.Left - this.simpleButtonRefresh.Width) - 4;
                                    this.simpleButtonRefresh.Top = 3;
                                    this.panelIDList.Visible = false;
                                    this.simpleButtonResult.Visible = false;
                                    this.groupControlSingle.Visible = false;
                                    this.mSelected = false;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlXBLayerCombine", "InitialValue", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void SetDist(string code, DataTable ptable, ComboBoxEdit combox)
        {
            try
            {
                int num;
                if ((!combox.Name.Contains("Xiaoban") && !combox.Name.Contains("Linban")) && !combox.Name.Contains("Xiban"))
                {
                    DataRow[] rowArray = ptable.Select("code like '" + code + "%'");
                    num = 0;
                    while (num < rowArray.Length)
                    {
                        combox.Properties.Items.Add(rowArray[num]["name"]);
                        num++;
                    }
                    ArrayList list = new ArrayList();
                    list.Add(ptable);
                    list.Add(rowArray);
                    combox.Tag = list;
                }
                else
                {
                    string str2;
                    IQueryFilter filter;
                    IFeatureCursor cursor;
                    IFeature feature;
                    int num2;
                    bool flag;
                    string[] strArray = UtilFactory.GetConfigOpt().GetConfigValue("XBFieldName2").Split(new char[] { ',' });
                    string str = strArray[2];
                    if (combox.Name.Contains("Linban"))
                    {
                        str2 = strArray[2];
                        filter = new QueryFilterClass();
                        filter.WhereClause = str2 + "='" + code.Substring(0, 12) + "'";
                        cursor = this.m_EditLayer.FeatureClass.Search(filter, false);
                        for (feature = cursor.NextFeature(); feature != null; feature = cursor.NextFeature())
                        {
                            string name = strArray[3];
                            num2 = feature.Fields.FindField(name);
                            flag = false;
                            num = 0;
                            while (num < combox.Properties.Items.Count)
                            {
                                if (combox.Properties.Items[num].ToString() == feature.get_Value(num2).ToString())
                                {
                                    flag = true;
                                    break;
                                }
                                num++;
                            }
                            if (!flag)
                            {
                                combox.Properties.Items.Add(feature.get_Value(num2).ToString());
                            }
                        }
                        combox.Tag = this.comboBoxVillage.Tag;
                    }
                    else if (combox.Name.Contains("Xiaoban"))
                    {
                        str2 = strArray[4];
                        filter = new QueryFilterClass();
                        filter.WhereClause = str + "='" + code + "' and " + strArray[3] + "='" + this.comboBoxLinban.Text + "'";
                        cursor = this.m_EditLayer.FeatureClass.Search(filter, false);
                        for (feature = cursor.NextFeature(); feature != null; feature = cursor.NextFeature())
                        {
                            num2 = feature.Fields.FindField(str2);
                            flag = false;
                            num = 0;
                            while (num < combox.Properties.Items.Count)
                            {
                                if (combox.Properties.Items[num].ToString() == feature.get_Value(num2).ToString())
                                {
                                    flag = true;
                                    break;
                                }
                                num++;
                            }
                            if (!flag)
                            {
                                combox.Properties.Items.Add(feature.get_Value(num2).ToString());
                            }
                        }
                        combox.Tag = this.comboBoxVillage.Tag;
                    }
                    else if (combox.Name.Contains("Xiban"))
                    {
                        str2 = strArray[strArray.Length - 1];
                        filter = new QueryFilterClass();
                        filter.WhereClause = str + "='" + code + "' and " + strArray[3] + "='" + this.comboBoxLinban.Text + "' and " + strArray[4] + "='" + this.comboBoxXiaoban.Text + "'";
                        cursor = this.m_EditLayer.FeatureClass.Search(filter, false);
                        for (feature = cursor.NextFeature(); feature != null; feature = cursor.NextFeature())
                        {
                            num2 = feature.Fields.FindField(str2);
                            flag = false;
                            for (num = 0; num < combox.Properties.Items.Count; num++)
                            {
                                if (combox.Properties.Items[num].ToString() == feature.get_Value(num2).ToString())
                                {
                                    flag = true;
                                    break;
                                }
                            }
                            if (!flag)
                            {
                                combox.Properties.Items.Add(feature.get_Value(num2).ToString());
                            }
                        }
                        combox.Tag = this.comboBoxVillage.Tag;
                    }
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlXBLayerCombine", "SetDist", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void simpleButtonBatchUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                string message = "";
                this.panelInfo2.Visible = true;
                this.label2.Image = this.WaitImg;
                this.label2.Text = "      准备更新...";
                Application.DoEvents();
                vForDBInfo info = null;// new vForDBInfo(UtilFactory.GetDBAccess("SqlServer").Connection);
                info.OnNatureUpdate += new vForDBInfo.NatureUpdateMessageHandler(this.dbinfo_OnNatureUpdate);
                info.UpdateDbVersion();
                this.panelInfo2.Visible = true;
                this.label2.Text = "      正在更新...";
                Application.DoEvents();
                int yearDiff = int.Parse(this.comboBoxYear.Text);
                if (info.TryNatureUpdate(int.Parse(EditTask.TaskYear) - 1, int.Parse(EditTask.TaskYear), yearDiff, true, out message, this.mHookHelper.FocusMap))
                {
                    this.panelInfo2.Visible = true;
                    this.label2.Text = "      正在更新非速生桉未成林造林地...";
                    this.label2.Refresh();
                    Application.DoEvents();
                    this.UpdateXSD();
                    this.label2.Text = "      更新成功";
                    this.label2.Image = null;
                }
                else
                {
                    this.label2.Text = "      更新失败[" + message + "]";
                    this.label2.Image = null;
                }
                this.panelInfo2.Visible = true;
                this.label2.Visible = true;
                GC.Collect();
                try
                {
                    if (((Process.GetCurrentProcess().PrivateMemorySize64 / 0x400L) / 0x400L) > 250L)
                    {
                        Process process = new Process();
                        ProcessStartInfo info2 = new ProcessStartInfo(Application.StartupPath + @"\MemoryClean.exe");
                        process.StartInfo = info2;
                        process.StartInfo.UseShellExecute = false;
                        process.Start();
                    }
                }
                catch (Exception)
                {
                }
                int num2 = this.m_EditLayer.FeatureClass.FeatureCount(null);
                this.label1.Text = "年度小班信息\r\n共计" + num2 + "个小班";
                IQueryFilter queryFilter = new QueryFilterClass();
                queryFilter.WhereClause = "not BHYY is null or BHYY<>''";
                num2 = this.m_EditLayer.FeatureClass.FeatureCount(queryFilter);
                string name = (this.m_EditLayer.FeatureClass as IDataset).Name;
                this.label1.Text = string.Concat(new object[] { this.label1.Text, ";其中已变更", num2, "个班块" });
                queryFilter.WhereClause = "BHYY = '80'";
                num2 = this.m_EditLayer.FeatureClass.FeatureCount(queryFilter);
                this.label1.Text = string.Concat(new object[] { this.label1.Text, ",已自然更新", num2, "个班块" });
                queryFilter.WhereClause = "BHYY is null or BHYY=''";
                num2 = this.m_EditLayer.FeatureClass.FeatureCount(queryFilter);
                this.label1.Text = string.Concat(new object[] { this.label1.Text, ",未变更", num2, "个班块" });
                this.panelInfo.Height = 70;
                this.Cursor = Cursors.Default;
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlXBLayerCombine", "simpleButtonBatchUpdate_Click", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                this.Cursor = Cursors.Default;
            }
        }

        private void simpleButtonSingleUpdata_Click(object sender, EventArgs e)
        {
            try
            {
             
                GXYSSZXJ gxysszxj = new GXYSSZXJ();
                string str = "";
                string cun = "";
                string text = "";
                string str4 = "";
                string str5 = "";
                string[] strArray = UtilFactory.GetConfigOpt().GetConfigValue("XBFieldNameD").Split(new char[] { ',' });
                DataTable table = (this.comboBoxCounty.Tag as ArrayList)[0] as DataTable;
                if (((this.comboBoxCounty.SelectedIndex == 0) && (this.comboBoxTown.SelectedIndex == 0)) && (this.comboBoxVillage.SelectedIndex == 0))
                {
                    str = "";
                }
                else
                {
                    if (this.comboBoxCounty.SelectedIndex > 0)
                    {
                        str = string.Concat(new object[] { strArray[0], "='", table.Rows[this.comboBoxCounty.SelectedIndex - 1]["code"], "'" });
                    }
                    DataTable table2 = (this.comboBoxTown.Tag as ArrayList)[0] as DataTable;
                    if (this.comboBoxTown.SelectedIndex > 0)
                    {
                        DataRow[] rowArray = (this.comboBoxTown.Tag as ArrayList)[1] as DataRow[];
                        if (this.comboBoxTown.SelectedIndex > 0)
                        {
                            str = string.Concat(new object[] { str, " and ", strArray[1], "='", rowArray[this.comboBoxTown.SelectedIndex - 1]["code"], "'" });
                        }
                        DataTable table3 = (this.comboBoxVillage.Tag as ArrayList)[0] as DataTable;
                        if (this.comboBoxVillage.SelectedIndex > 0)
                        {
                            DataRow[] rowArray2 = (this.comboBoxVillage.Tag as ArrayList)[1] as DataRow[];
                            str = string.Concat(new object[] { str, " and ", strArray[2], "='", rowArray2[this.comboBoxVillage.SelectedIndex - 1]["code"], "'" });
                            cun = rowArray2[this.comboBoxVillage.SelectedIndex - 1]["code"].ToString();
                            DataTable table4 = (this.comboBoxLinban.Tag as ArrayList)[0] as DataTable;
                            if (this.comboBoxLinban.SelectedIndex > 0)
                            {
                                DataRow[] rowArray3 = (this.comboBoxLinban.Tag as ArrayList)[1] as DataRow[];
                                str = str + " and " + strArray[3] + "='" + this.comboBoxLinban.Text + "'";
                                text = this.comboBoxLinban.Text;
                                if (this.comboBoxXiaoban.SelectedIndex > 0)
                                {
                                    str = str + " and " + strArray[4] + "='" + this.comboBoxXiaoban.Text + "'";
                                    str4 = this.comboBoxXiaoban.Text;
                                    if (this.comboBoxXiban.SelectedIndex > 0)
                                    {
                                        str = str + " and " + strArray[5] + "='" + this.comboBoxXiban.Text + "'";
                                        str5 = this.comboBoxXiban.Text;
                                    }
                                }
                            }
                        }
                    }
                }
                //if (gxysszxj.blnExecuteSZMODEL_GXXJByOne(dBAccess.ConnectionString, EditTask.LayerName, cun, text, str4, null))
                {
                    MessageBox.Show("生长模型更新优势树种蓄积完成，请检查！");
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlXBLayerCombine", "simpleButtonSingleUpdata_Click", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private bool UpdateXSD()
        {
            Exception exception;
            try
            {
                IWorkspaceEdit editWorkspace = EditTask.EditWorkspace as IWorkspaceEdit;
                editWorkspace.StartEditing(false);
                Editor.UniqueInstance.AddAttribute = false;
                Editor.UniqueInstance.CheckOverlap = false;
                editWorkspace.StartEditOperation();
                string str = "( DI_LEI like '4%%') AND ( BHYY = NULL OR ltrim(rtrim(BHYY)) = '' OR BHYY = '80' OR BHYY > '90') AND (YOU_SHI_SZ < '290' OR YOU_SHI_SZ > '320') AND ( YOU_SHI_SZ <> NULL OR ltrim(rtrim(YOU_SHI_SZ)) <> '') AND PINGJUN_NL > 0 AND (PINGJUN_XJ = NULL  OR PINGJUN_XJ = 0 ) ";
                IQueryFilter filter = new QueryFilterClass();
                filter.WhereClause = str;
                IFeatureCursor cursor = this.m_EditLayer.FeatureClass.Search(filter, false);
                IFeature feature = cursor.NextFeature();
                if (feature != null)
                {
                    int index = feature.Fields.FindField("XIAN");
                    int num2 = feature.Fields.FindField("XIANG");
                    int num3 = feature.Fields.FindField("CUN");
                    int num4 = feature.Fields.FindField("Q_PJXJ");
                    int num5 = feature.Fields.FindField("Q_PJSG");
                    int num6 = feature.Fields.FindField("Q_PJDM");
                    int num7 = feature.Fields.FindField("PINGJUN_XJ");
                    int num8 = feature.Fields.FindField("PINGJUN_SG");
                    int num9 = feature.Fields.FindField("PINGJUN_DM");
                    int num10 = feature.Fields.FindField("YOU_SHI_SZ");
                    int num11 = feature.Fields.FindField("Q_PJNL");
                    int num12 = feature.Fields.FindField("PINGJUN_NL");
                    int num13 = feature.Fields.FindField("BHYY");
                    int num14 = 0;
                    int num15 = 0;
                    while (feature != null)
                    {
                        num15++;
                        this.label2.Text = "      更新未成林造林地非速生桉第" + num15 + "个";
                        this.label2.Refresh();
                        Application.DoEvents();
                        GC.Collect();
                        IQueryFilter queryFilter = new QueryFilterClass();
                        queryFilter.WhereClause = "YOU_SHI_SZ ='" + feature.get_Value(num10).ToString().Trim() + "' AND (Q_PJXJ <> NULL OR Q_PJXJ <> 0 ) and (Q_PJNL =" + feature.get_Value(num12).ToString().Trim() + " ) and CUN ='" + feature.get_Value(num3).ToString() + "'";
                        IFeatureCursor cursor2 = this.m_EditLayer.Search(queryFilter, false);
                        double num16 = 0.0;
                        double num17 = 0.0;
                        double num18 = 0.0;
                        int num19 = 0;
                        int num20 = 0;
                        int num21 = 0;
                        IFeature feature2 = cursor2.NextFeature();
                        bool flag = true;
                        if (feature2 == null)
                        {
                            queryFilter.WhereClause = "YOU_SHI_SZ ='" + feature.get_Value(num10).ToString().Trim() + "' AND (Q_PJXJ <> NULL OR Q_PJXJ <> 0 ) and (Q_PJNL <> NULL OR Q_PJNL <> 0 ) and (Q_PJNL =" + feature.get_Value(num12).ToString().Trim() + " ) and XIANG ='" + feature.get_Value(num2).ToString() + "'";
                            cursor2 = this.m_EditLayer.Search(queryFilter, false);
                            feature2 = cursor2.NextFeature();
                            if (feature2 == null)
                            {
                                queryFilter.WhereClause = "YOU_SHI_SZ ='" + feature.get_Value(num10).ToString().Trim() + "' AND (Q_PJXJ <> NULL OR Q_PJXJ <> 0 ) and (Q_PJNL <> NULL OR Q_PJNL <> 0 ) and (Q_PJNL =" + feature.get_Value(num12).ToString().Trim() + " ) and XIAN ='" + feature.get_Value(index).ToString() + "'";
                                cursor2 = this.m_EditLayer.Search(queryFilter, false);
                                feature2 = cursor2.NextFeature();
                                if (feature2 == null)
                                {
                                    flag = false;
                                    queryFilter.WhereClause = "YOU_SHI_SZ ='" + feature.get_Value(num10).ToString().Trim() + "' AND (PINGJUN_XJ <> NULL OR PINGJUN_XJ <> 0 ) and (PINGJUN_NL <> NULL OR PINGJUN_NL <> 0 ) and (PINGJUN_NL =" + feature.get_Value(num12).ToString().Trim() + " ) and CUN ='" + feature.get_Value(num3).ToString() + "'";
                                    cursor2 = this.m_EditLayer.Search(queryFilter, false);
                                    feature2 = cursor2.NextFeature();
                                    if (feature2 == null)
                                    {
                                        queryFilter.WhereClause = "YOU_SHI_SZ ='" + feature.get_Value(num10).ToString().Trim() + "' AND (PINGJUN_XJ <> NULL OR PINGJUN_XJ <> 0 ) and (PINGJUN_NL <> NULL OR PINGJUN_NL <> 0 ) and (PINGJUN_NL =" + feature.get_Value(num12).ToString().Trim() + " ) and XIANG ='" + feature.get_Value(num2).ToString() + "'";
                                        cursor2 = this.m_EditLayer.Search(queryFilter, false);
                                        feature2 = cursor2.NextFeature();
                                        if (feature2 == null)
                                        {
                                            queryFilter.WhereClause = "YOU_SHI_SZ ='" + feature.get_Value(num10).ToString().Trim() + "' AND (PINGJUN_XJ <> NULL OR PINGJUN_XJ <> 0 ) and (PINGJUN_NL <> NULL OR PINGJUN_NL <> 0 ) and (PINGJUN_NL =" + feature.get_Value(num12).ToString().Trim() + " ) and XIAN ='" + feature.get_Value(index).ToString() + "'";
                                            cursor2 = this.m_EditLayer.Search(queryFilter, false);
                                            feature2 = cursor2.NextFeature();
                                        }
                                    }
                                }
                            }
                        }
                        bool flag2 = false;
                        while (feature2 != null)
                        {
                            flag2 = true;
                            if (flag)
                            {
                                if (double.Parse(feature2.get_Value(num4).ToString()) > 0.0)
                                {
                                    num19++;
                                    num16 += double.Parse(feature2.get_Value(num4).ToString());
                                }
                                if (double.Parse(feature2.get_Value(num5).ToString()) > 0.0)
                                {
                                    num20++;
                                    num17 += double.Parse(feature2.get_Value(num5).ToString());
                                }
                                if ((feature2.get_Value(num6).ToString().Trim() != "") && (double.Parse(feature2.get_Value(num6).ToString().Trim()) > 0.0))
                                {
                                    num21++;
                                    num18 += double.Parse(feature2.get_Value(num6).ToString());
                                }
                            }
                            else
                            {
                                if (double.Parse(feature2.get_Value(num7).ToString()) > 0.0)
                                {
                                    num19++;
                                    num16 += double.Parse(feature2.get_Value(num7).ToString());
                                }
                                if (double.Parse(feature2.get_Value(num8).ToString()) > 0.0)
                                {
                                    num20++;
                                    num17 += double.Parse(feature2.get_Value(num8).ToString());
                                }
                                if ((feature2.get_Value(num9).ToString().Trim() != "") && (double.Parse(feature2.get_Value(num9).ToString().Trim()) > 0.0))
                                {
                                    num21++;
                                    num18 += double.Parse(feature2.get_Value(num9).ToString());
                                }
                            }
                            feature2 = cursor2.NextFeature();
                        }
                        if ((num16 > 0.0) && (num19 > 0))
                        {
                            num16 = Math.Round((double) (num16 / ((double) num19)), 1);
                            feature.set_Value(num7, num16);
                        }
                        if ((num17 > 0.0) && (num20 > 0))
                        {
                            num17 = Math.Round((double) (num17 / ((double) num20)), 1);
                            feature.set_Value(num8, num17);
                        }
                        if ((num18 > 0.0) && (num21 > 0))
                        {
                            num18 = Math.Round((double) (num18 / ((double) num21)), 1);
                            feature.set_Value(num9, num18);
                        }
                        if (flag2)
                        {
                            if (feature.get_Value(num13).ToString().Trim() == "")
                            {
                                feature.set_Value(num13, "80");
                            }
                            if (int.Parse(feature.get_Value(num7).ToString().Trim()) < 5)
                            {
                                feature.set_Value(num9, 0);
                            }
                            feature.Store();
                            num14++;
                        }
                        if (num14 >= 50)
                        {
                            try
                            {
                                editWorkspace.StopEditOperation();
                            }
                            catch (Exception)
                            {
                                editWorkspace.StopEditOperation();
                            }
                            Editor.UniqueInstance.AddAttribute = true;
                            Editor.UniqueInstance.CheckOverlap = true;
                            editWorkspace.StopEditing(true);
                            editWorkspace.StartEditing(false);
                            Editor.UniqueInstance.AddAttribute = false;
                            Editor.UniqueInstance.CheckOverlap = false;
                            editWorkspace.StartEditOperation();
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
                            num14 = 0;
                        }
                        feature = cursor.NextFeature();
                    }
                }
                try
                {
                    editWorkspace.StopEditOperation();
                    Editor.UniqueInstance.AddAttribute = false;
                    Editor.UniqueInstance.CheckOverlap = false;
                    editWorkspace.StopEditing(true);
                }
                catch (Exception exception3)
                {
                    exception = exception3;
                    this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlXBLayerCombine", "UpdateXSD", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                    editWorkspace.StopEditOperation();
                    Editor.UniqueInstance.AddAttribute = false;
                    Editor.UniqueInstance.CheckOverlap = false;
                    editWorkspace.StopEditing(true);
                }
                return true;
            }
            catch (Exception exception4)
            {
                exception = exception4;
                this.mErrOpt.ErrorOperate(this.mSubSysName, "DataEdit.UserControlXBLayerCombine", "UpdateXSD", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                return false;
            }
        }
    }
}

