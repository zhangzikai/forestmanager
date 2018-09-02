namespace QueryAnalysic
{
    using DevExpress.XtraBars.Docking;
    using DevExpress.XtraEditors;
    using DevExpress.XtraEditors.Controls;
    using DevExpress.XtraEditors.Repository;
    using DevExpress.XtraGrid;
    using DevExpress.XtraGrid.Views.Grid;
    using DevExpress.XtraNavBar;
    using DevExpress.XtraNavBar.ViewInfo;
    using DevExpress.XtraTreeList;
    using DevExpress.XtraTreeList.Columns;
    using DevExpress.XtraTreeList.Nodes;
    using ESRI.ArcGIS.Carto;
    using ESRI.ArcGIS.Controls;
    using ESRI.ArcGIS.Display;
    using ESRI.ArcGIS.Geodatabase;
    using ESRI.ArcGIS.Geometry;
    using FormBase;
    using FunFactory;
    using QueryCommon;
    using stdole;
    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Windows.Forms;
    using TaskManage;
    using Utilities;
    using DevExpress.XtraGrid.Views.Base;
    using td.logic.sys;
    using td.db.orm;
    using td.db.mid.sys;
    using System.Collections.Generic;

    public class UserControlQueryDesign : UserControlBase1
    {
        private ComboBoxEdit comboBoxEdit1;
        private IContainer components;
        private GridControl gridControl1;
        private GridView gridView1;
        private GroupControl groupControl1;
        private GroupControl groupControl2;
        private GroupControl groupControl4;
        private GroupControl groupControl5;
        private GroupControl groupControlDist;
        private GroupControl groupControlname;
        private GroupControl groupControltype;
        private ImageList imageList1;
        private ImageList imageList2;
        private ImageList imageList3;
        private Label label1;
        private Label label10;
        private Label label11;
        private Label label13;
        private Label label14;
        private Label label16;
        private Label label17;
        private Label label18;
        private Label label19;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label labelInfo;
        private Label labelInfo2;
        private Label labelKind;
        private Label labelResultInfo;
        private ITable m_CityTable;
        private IFeatureLayer m_CountyLayer;
        private ITable m_CountyTable;
        private IFeatureClass m_EditFeatureClass;
        private IFeatureClass m_EditFeatureClass2;
        private IFeatureClass m_EditFeatureClass3;
        private IFeatureLayer m_EditLayer;
        private IFeatureLayer m_QueryLayer;
        private IFeatureLayer m_QueryLayer2;
        private IFeatureLayer m_QueryLayer3;
        private ITable m_QueryTable;
        private ITable m_QueryTable2;
        private IFeatureLayer m_TownLayer;
        private ITable m_TownTable;
        private IFeatureLayer m_VillageLayer;
        private ITable m_VillageTable;
        private const string mClassName = "QueryAnalysic.UserControlQueryDesign";
       
        private DockPanel mDockPanel;
        private string mEditKind = "";
        private string mEditKindCode = "";
        private ErrorOpt mErrOpt = UtilFactory.GetErrorOpt();
        private IFeatureWorkspace mFeatureWorkspace;
        private DataTable mFieldTable;
        private ArrayList mForList;
        private HookHelper mHookHelper;
        private bool mIsBatch = true;
        private string mKindCode = "";
        private ArrayList mKindList;
        private DataTable mKindTable;
        private ArrayList mLandList;
        private ArrayList mLayerList;
        private ArrayList mLayerList2;
        private ArrayList mLayerList3;
        private TreeListNode mNode;
        private ArrayList mQueryList;
        private QueryCommon.UserControlQueryResult mQueryResult;
        private DataTable mQueryTable;
        private ArrayList mRangeList;
        private ArrayList mRightList;
        private ArrayList mRightList2;
        private ArrayList mRightList3;
        private ArrayList mRightList4;
        private bool mSelected;
        private string mSubSysName = UtilFactory.GetConfigOpt().GetSystemName();
        private ITable mTableF;
        private ITable mTableL;
        private ITable mTableR;
        private ITable mTableR2;
        private ITable mTableR3;
        private ITable mTableR4;
        private ITable mTableT;
        private string mTaskID = "";
        private ArrayList mTreeList;
        private NavBarControl navBarControl1;
        private NavBarGroupControlContainer navBarGroupControlContainer1;
        private NavBarGroupControlContainer navBarGroupControlContainer2;
        private NavBarGroupControlContainer navBarGroupControlContainer6;
        private NavBarGroup navBarGroupConvert;
        private NavBarGroup navBarGroupQuery;
        private NavBarGroup navBarGroupResult;
        private Panel panel2;
        private Panel panel3;
        private Panel panel4;
        private Panel panel7;
        private Panel panel8;
        private Panel panelButtons;
        private PanelControl panelControl1;
        private PanelControl panelControl2;
        private Panel panelEdit;
        private Panel panelKind;
        private Panel panelList;
        private Panel panelQuery;
        private Panel panelResult;
        private Panel panelYear;
        private RadioGroup radioGroup1;
        private RadioGroup radioGroupYear;
        private RepositoryItemImageEdit repositoryItemImageEdit1;
        private SimpleButton simpleButtonBack;
        private SimpleButton simpleButtonDelete;
        private SimpleButton simpleButtonEdit;
        private SimpleButton simpleButtonEditCancle;
        private SimpleButton simpleButtonEditOK;
        private SimpleButton simpleButtonInfo;
        private SimpleButton simpleButtonLocation;
        private SimpleButton simpleButtonQuery;
        private SimpleButton simpleButtonQueryMap;
        private SimpleButton simpleButtonQueryXB;
        private SimpleButton simpleButtonReset;
        private SimpleButton simpleButtonSchedule;
        private SplitterControl splitterControl1;
        internal TreeListColumn tcolBase1;
        private TextBox textBox2;
        private TextBox textBoxNane;
        internal TreeList tListDesignKind;
        internal TreeList tListDist;
        internal TreeList tListResult;
        internal TreeListColumn treeListColumn1;
        internal TreeListColumn treeListColumn2;
        internal TreeListColumn treeListColumn3;
        internal TreeListColumn treeListColumn4;
        private UserControlTaskConvert userControlTaskConvert1;

        public UserControlQueryDesign()
        {
            this.InitializeComponent();
        }

        private void AddDistCounty(string scode, TreeListNode node)
        {
            try
            {
                node.Nodes.Clear();
                TreeListNode parentNode = null;
                UtilFactory.GetConfigOpt().GetConfigValue("CountyCodeTableFieldName");
                string configValue = UtilFactory.GetConfigOpt().GetConfigValue("CountyCodeTableFieldCode");
                IQueryFilter queryFilter = new QueryFilterClass();
                string str2 = UtilFactory.GetConfigOpt().GetConfigValue("CountyCodeTableWhereStr");
                if (str2 != "")
                {
                    queryFilter.WhereClause = configValue + " like '" + scode + "%' and " + str2;
                }
                else
                {
                    queryFilter.WhereClause = configValue + " like '" + scode + "%' ";
                }
                ICursor cursor = this.m_CountyTable.Search(queryFilter, false);
                IRow row = cursor.NextRow();
                int index = row.Fields.FindField(UtilFactory.GetConfigOpt().GetConfigValue("CountyCodeTableFieldCode"));
                int num2 = row.Fields.FindField(UtilFactory.GetConfigOpt().GetConfigValue("CountyCodeTableFieldName"));
                while (row != null)
                {
                    parentNode = this.tListDist.AppendNode(row.get_Value(num2).ToString(), node);
                    parentNode.SetValue(0, row.get_Value(num2).ToString());
                    parentNode.Tag = row.get_Value(index).ToString();
                    this.tListDist.AppendNode("", parentNode);
                    parentNode.Expanded = false;
                    row = cursor.NextRow();
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "QueryAnalysic.UserControlQueryDesign", "AddDistCounty", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void AddDistTown(string scode, TreeListNode node)
        {
            try
            {
                node.Nodes.Clear();
                TreeListNode parentNode = null;
                UtilFactory.GetConfigOpt().GetConfigValue("TownCodeTableFieldName");
                string configValue = UtilFactory.GetConfigOpt().GetConfigValue("TownCodeTableFieldCode");
                IQueryFilter queryFilter = new QueryFilterClass();
                string str2 = UtilFactory.GetConfigOpt().GetConfigValue("TownCodeTableWhereStr");
                if (str2 != "")
                {
                    queryFilter.WhereClause = configValue + " like '" + scode + "%' and " + str2;
                }
                else
                {
                    queryFilter.WhereClause = configValue + " like '" + scode + "%' ";
                }
                ICursor cursor = this.m_TownTable.Search(queryFilter, false);
                IRow row = cursor.NextRow();
                int index = row.Fields.FindField(UtilFactory.GetConfigOpt().GetConfigValue("TownCodeTableFieldCode"));
                int num2 = row.Fields.FindField(UtilFactory.GetConfigOpt().GetConfigValue("TownCodeTableFieldName"));
                while (row != null)
                {
                    parentNode = this.tListDist.AppendNode(row.get_Value(num2).ToString(), node);
                    parentNode.SetValue(0, row.get_Value(num2).ToString());
                    parentNode.Tag = row.get_Value(index).ToString();
                    this.tListDist.AppendNode("", parentNode);
                    parentNode.Expanded = false;
                    row = cursor.NextRow();
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "QueryAnalysic.UserControlQueryDesign", "AddDistTown", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void AddDistVillage(string scode, TreeListNode node)
        {
            try
            {
                node.Nodes.Clear();
                TreeListNode node2 = null;
                UtilFactory.GetConfigOpt().GetConfigValue("VillageCodeTableFieldName");
                string configValue = UtilFactory.GetConfigOpt().GetConfigValue("VillageCodeTableFieldCode");
                IQueryFilter queryFilter = new QueryFilterClass();
                string str2 = UtilFactory.GetConfigOpt().GetConfigValue("VillageCodeTableWhereStr");
                if (str2 != "")
                {
                    queryFilter.WhereClause = configValue + " like '" + scode + "%' and " + str2;
                }
                else
                {
                    queryFilter.WhereClause = configValue + " like '" + scode + "%' ";
                }
                ICursor cursor = this.m_VillageTable.Search(queryFilter, false);
                IRow row = cursor.NextRow();
                int index = row.Fields.FindField(UtilFactory.GetConfigOpt().GetConfigValue("VillageCodeTableFieldCode"));
                int num2 = row.Fields.FindField(UtilFactory.GetConfigOpt().GetConfigValue("VillageCodeTableFieldName"));
                while (row != null)
                {
                    node2 = this.tListDist.AppendNode(row.get_Value(num2).ToString(), node);
                    node2.SetValue(0, row.get_Value(num2).ToString());
                    node2.Tag = row.get_Value(index).ToString();
                    node2.Expanded = false;
                    row = cursor.NextRow();
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "QueryAnalysic.UserControlQueryDesign", "AddDistVillage", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private ILayer AddLayer2(string sname, IFeatureClass pFClass, IGroupLayer pGLayer)
        {
            try
            {
                ICompositeLayer layer = pGLayer as ICompositeLayer;
                for (int i = 0; i < layer.Count; i++)
                {
                    ILayer layer2 = layer.get_Layer(i);
                    if (layer2.Name == sname)
                    {
                        pGLayer.Delete(layer2);
                    }
                }
                IFeatureLayer layer3 = new FeatureLayerClass();
                layer3.FeatureClass = pFClass;
                layer3.Name = sname;
                ILayer layer4 = layer3;
                pGLayer.Add(layer4);
                IFeatureLayer featureLayer = layer4 as IFeatureLayer;
                this.RendererLayer(featureLayer, false, 0xff, 0, 0xff, 1.2, 10, "");
                return layer4;
            }
            catch (Exception)
            {
                return null;
            }
        }

        private bool DeleteEditLayerFeature(string taskid)
        {
            try
            {
                IFeatureWorkspace editWorkspace = EditTask.EditWorkspace;
                IWorkspaceEdit edit = editWorkspace as IWorkspaceEdit;
                if (edit == null)
                {
                    return false;
                }
                GC.Collect();
                IQueryFilter filter = new QueryFilterClass();
                filter.WhereClause = this.mTaskID + "='" + taskid + "'";
                this.m_EditLayer = EditTask.EditLayer;
                ITable table = null;
                if (EditTask.TableName != "")
                {
                    table = editWorkspace.OpenTable(EditTask.TableName);
                }
                IFeatureCursor cursor = this.m_EditLayer.FeatureClass.Search(filter, false);
                IFeature feature = cursor.NextFeature();
                edit.StartEditing(false);
                edit.StartEditOperation();
                Application.DoEvents();
                string str = "";
                if (UtilFactory.GetConfigOpt().GetConfigValue(this.mEditKindCode + "ConnectFieldName") != "")
                {
                    string[] strArray = UtilFactory.GetConfigOpt().GetConfigValue(this.mEditKindCode + "ConnectFieldName").Split(new char[] { ';' });
                    string[] strArray2 = strArray[0].Split(new char[] { ',' });
                    string[] strArray3 = strArray[1].Split(new char[] { ',' });
                    for (int i = 0; i < strArray2.Length; i++)
                    {
                        int index = feature.Fields.FindField(strArray2[i]);
                        if (str == "")
                        {
                            str = string.Concat(new object[] { strArray3[i], "='", feature.get_Value(index), "'" });
                        }
                        else
                        {
                            str = string.Concat(new object[] { str, " and ", strArray3[i], "='", feature.get_Value(index), "'" });
                        }
                    }
                }
                while (feature != null)
                {
                    if (table != null)
                    {
                        IQueryFilter queryFilter = new QueryFilterClass();
                        queryFilter.WhereClause = str;
                        ICursor cursor2 = table.Search(queryFilter, false);
                        for (IRow row = cursor2.NextRow(); row != null; row = cursor2.NextRow())
                        {
                            row.Delete();
                            row.Store();
                        }
                    }
                    feature.Delete();
                    feature.Store();
                    feature = cursor.NextFeature();
                }
                edit.StopEditOperation();
                edit.StopEditing(true);
                edit.StartEditing(false);
                edit.StartEditOperation();
                return true;
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "QueryAnalysic.UserControlQueryDesign", "DeleteEditLayerFeature", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                return false;
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

        private void GetFeatureList()
        {
            try
            {
                string str = this.GetQueryStr3(this.tListResult.Selection[0].Tag.ToString());
                IQueryFilter filter = new QueryFilterClass();
                filter.WhereClause = str;
                GC.Collect();
                IFeatureCursor cursor = this.m_QueryLayer.FeatureClass.Search(filter, false);
                IFeature feature = cursor.NextFeature();
                int num = 0;
                this.mQueryList = new ArrayList();
                if (feature != null)
                {
                    while (feature != null)
                    {
                        num++;
                        this.mQueryList.Add(feature);
                        feature = cursor.NextFeature();
                    }
                }
                else
                {
                    string str2 = this.tListResult.Selection[0].Tag.ToString();
                    filter.WhereClause = this.mTaskID + " = '" + str2 + "' or " + this.mTaskID + " like '," + str2 + "' or " + this.mTaskID + " like '" + str2 + ",'";
                    IFeatureCursor cursor2 = this.m_QueryLayer.FeatureClass.Search(filter, false);
                    for (feature = cursor2.NextFeature(); feature != null; feature = cursor2.NextFeature())
                    {
                        this.mQueryList.Add(feature);
                    }
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "QueryAnalysic.UserControlQueryDesign", "GetFeatureList", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private string GetQueryStr()
        {
            try
            {
                string str = "";
                for (int i = 0; i < this.mKindList.Count; i++)
                {
                    string str2 = this.mKindList[i].ToString();
                    string str3 = "=";
                    if (this.mKindList[i].ToString().Contains("0000"))
                    {
                        str2 = this.mKindList[i].ToString().Substring(0, 2) + "%";
                        str3 = " like ";
                    }
                    else if (this.mKindList[i].ToString().Contains("00"))
                    {
                        str2 = this.mKindList[i].ToString().Substring(0, 4) + "%";
                        str3 = " like ";
                    }
                    if (str == "")
                    {
                        str = (this.m_QueryTable as IDataset).Name + ".DESI_KIND" + str3 + "'" + str2 + "'";
                    }
                    else
                    {
                        str = string.Concat(new object[] { str, " or ", (this.m_QueryTable as IDataset).Name, ".DESI_KIND", str3, "'", this.mKindList[i], "'" });
                    }
                }
                if (str != "")
                {
                    str = "(" + str + ")";
                }
                string str4 = "";
                for (int j = 0; j < this.mRangeList.Count; j++)
                {
                    string str5 = "";
                    if (this.mRangeList[j].ToString().Length == 6)
                    {
                        str5 = (this.m_QueryTable as IDataset).Name + ".CNTY";
                    }
                    else if (this.mRangeList[j].ToString().Length == 9)
                    {
                        str5 = (this.m_QueryTable as IDataset).Name + ".TOWN";
                    }
                    else if (this.mRangeList[j].ToString().Length == 12)
                    {
                        str5 = (this.m_QueryTable as IDataset).Name + ".VILL";
                    }
                    if (str4 == "")
                    {
                        str4 = string.Concat(new object[] { str5, "='", this.mRangeList[j], "'" });
                    }
                    else
                    {
                        str4 = string.Concat(new object[] { str4, " or ", str5, "='", this.mRangeList[j], "'" });
                    }
                }
                if (str4 != "")
                {
                    str4 = "(" + str4 + ")";
                    if (str != "")
                    {
                        str = str + " and " + str4;
                    }
                    else
                    {
                        str = str4;
                    }
                }
                return str;
            }
            catch (Exception)
            {
                return "";
            }
        }

        private string GetQueryStr2()
        {
            try
            {
                string str = "taskkind like '0" + this.mKindCode + "%'";
                string str2 = this.radioGroupYear.Properties.Items[this.radioGroupYear.SelectedIndex].Description.Replace("年", "");
                if (str == "")
                {
                    str = "taskyear='" + str2 + "'";
                }
                else
                {
                    str = str + " and taskyear='" + str2 + "'";
                }
                this.labelResultInfo.Text = "        " + str2 + "年";
                if (this.groupControltype.Enabled)
                {
                    for (int i = 0; i < this.mKindList.Count; i++)
                    {
                        string str3 = this.mKindList[i].ToString();
                        string str4 = "=";
                        if (this.mKindList[i].ToString().Contains("0000"))
                        {
                            str3 = "0" + this.mKindCode + this.mKindList[i].ToString().Substring(0, 2) + "%";
                            str4 = " like ";
                        }
                        else if (this.mKindList[i].ToString().Contains("00"))
                        {
                            str3 = "0" + this.mKindCode + this.mKindList[i].ToString().Substring(0, 4) + "%";
                            str4 = " like ";
                        }
                        else
                        {
                            str3 = "0" + this.mKindCode + this.mKindList[i].ToString();
                        }
                        if (str == "")
                        {
                            str = "taskkind" + str4 + "'" + str3 + "'";
                        }
                        else
                        {
                            str = str + " and taskkind" + str4 + "'" + str3 + "'";
                        }
                    }
                    if (this.tListDesignKind.Selection.Count > 0)
                    {
                        this.labelResultInfo.Text = this.labelResultInfo.Text + this.tListDesignKind.Selection[0].GetValue(0);
                    }
                }
                if (str != "")
                {
                    str = "(" + str + ")";
                }
                string str5 = "";
                if (this.groupControlDist.Enabled)
                {
                    for (int j = 0; j < this.mRangeList.Count; j++)
                    {
                        string str6 = "distcode";
                        string str7 = this.mRangeList[j].ToString();
                        string str8 = "=";
                        if (this.mRangeList[j].ToString().Length == 6)
                        {
                            str7 = this.mRangeList[j].ToString() + "%%%";
                            str8 = " like ";
                        }
                        else if (this.mRangeList[j].ToString().Length == 9)
                        {
                            str7 = this.mRangeList[j].ToString();
                            str8 = " = ";
                        }
                        if (str5 == "")
                        {
                            str5 = str6 + str8 + "'" + str7 + "'";
                        }
                        else
                        {
                            str5 = str5 + " and " + str6 + str8 + "'" + str7 + "'";
                        }
                    }
                    if (this.tListDist.Selection.Count > 0)
                    {
                        this.labelResultInfo.Text = this.labelResultInfo.Text + this.tListDist.Selection[0].GetValue(0);
                    }
                }
                if (str5 != "")
                {
                    str5 = "(" + str5 + ")";
                    if (str != "")
                    {
                        str = str + " and " + str5;
                    }
                    else
                    {
                        str = str5;
                    }
                }
                str5 = "";
                if (this.textBoxNane.Text.Trim() != "")
                {
                    str5 = "taskname like '%" + this.textBoxNane.Text.Trim() + "%'";
                }
                if (str5 != "")
                {
                    str5 = "(" + str5 + ")";
                    if (str != "")
                    {
                        str = str + " and " + str5;
                    }
                    else
                    {
                        str = str5;
                    }
                }
                if (this.mEditKind == "征占用")
                {
                    this.labelResultInfo.Text = this.labelResultInfo.Text + this.mEditKind + "项目";
                }
                else
                {
                    this.labelResultInfo.Text = this.labelResultInfo.Text + this.mEditKind + "作业设计";
                }
                return str;
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "QueryAnalysic.UserControlQueryDesign", "GetQueryStr2", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                return "";
            }
        }

        private string GetQueryStr3(string taskid)
        {
            try
            {
                string str = "";
                if (str == "")
                {
                    str = this.mTaskID + "='" + taskid + "'";
                }
                else
                {
                    str = str + " and " + this.mTaskID + "='" + taskid + "'";
                }
                string str2 = "";
                if (this.groupControlDist.Enabled)
                {
                    for (int i = 0; i < this.mRangeList.Count; i++)
                    {
                        string str3 = "";
                        if (this.mRangeList[i].ToString().Length == 6)
                        {
                            str3 = "CNTY";
                        }
                        else if (this.mRangeList[i].ToString().Length == 9)
                        {
                            str3 = "TOWN";
                        }
                        else if (this.mRangeList[i].ToString().Length == 12)
                        {
                            str3 = "VILL";
                        }
                        if (str2 == "")
                        {
                            str2 = string.Concat(new object[] { str3, "='", this.mRangeList[i], "'" });
                        }
                        else
                        {
                            str2 = string.Concat(new object[] { str2, " or ", str3, "='", this.mRangeList[i], "'" });
                        }
                    }
                }
                if (str2 != "")
                {
                    str2 = "(" + str2 + ")";
                    if (str != "")
                    {
                        str = str + " and " + str2;
                    }
                    else
                    {
                        str = str2;
                    }
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

        private void groupControlyear_DoubleClick(object sender, EventArgs e)
        {
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserControlQueryDesign));
            this.navBarControl1 = new DevExpress.XtraNavBar.NavBarControl();
            this.navBarGroupQuery = new DevExpress.XtraNavBar.NavBarGroup();
            this.navBarGroupControlContainer1 = new DevExpress.XtraNavBar.NavBarGroupControlContainer();
            this.panel7 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.groupControlDist = new DevExpress.XtraEditors.GroupControl();
            this.tListDist = new DevExpress.XtraTreeList.TreeList();
            this.treeListColumn1 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn2 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.splitterControl1 = new DevExpress.XtraEditors.SplitterControl();
            this.panelKind = new System.Windows.Forms.Panel();
            this.labelKind = new System.Windows.Forms.Label();
            this.groupControltype = new DevExpress.XtraEditors.GroupControl();
            this.tListDesignKind = new DevExpress.XtraTreeList.TreeList();
            this.tcolBase1 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.panelYear = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.groupControl5 = new DevExpress.XtraEditors.GroupControl();
            this.radioGroupYear = new DevExpress.XtraEditors.RadioGroup();
            this.panel8 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.groupControlname = new DevExpress.XtraEditors.GroupControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.textBoxNane = new System.Windows.Forms.TextBox();
            this.panelQuery = new System.Windows.Forms.Panel();
            this.simpleButtonReset = new DevExpress.XtraEditors.SimpleButton();
            this.label11 = new System.Windows.Forms.Label();
            this.simpleButtonQuery = new DevExpress.XtraEditors.SimpleButton();
            this.navBarGroupControlContainer2 = new DevExpress.XtraNavBar.NavBarGroupControlContainer();
            this.panelResult = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tListResult = new DevExpress.XtraTreeList.TreeList();
            this.treeListColumn3 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn4 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.repositoryItemImageEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemImageEdit();
            this.labelInfo = new System.Windows.Forms.Label();
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.panelButtons = new System.Windows.Forms.Panel();
            this.simpleButtonSchedule = new DevExpress.XtraEditors.SimpleButton();
            this.label3 = new System.Windows.Forms.Label();
            this.simpleButtonQueryMap = new DevExpress.XtraEditors.SimpleButton();
            this.label2 = new System.Windows.Forms.Label();
            this.simpleButtonQueryXB = new DevExpress.XtraEditors.SimpleButton();
            this.label14 = new System.Windows.Forms.Label();
            this.simpleButtonEdit = new DevExpress.XtraEditors.SimpleButton();
            this.label13 = new System.Windows.Forms.Label();
            this.simpleButtonDelete = new DevExpress.XtraEditors.SimpleButton();
            this.labelResultInfo = new System.Windows.Forms.Label();
            this.imageList3 = new System.Windows.Forms.ImageList(this.components);
            this.panelList = new System.Windows.Forms.Panel();
            this.label19 = new System.Windows.Forms.Label();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.labelInfo2 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.simpleButtonInfo = new DevExpress.XtraEditors.SimpleButton();
            this.label4 = new System.Windows.Forms.Label();
            this.simpleButtonLocation = new DevExpress.XtraEditors.SimpleButton();
            this.label17 = new System.Windows.Forms.Label();
            this.simpleButtonBack = new DevExpress.XtraEditors.SimpleButton();
            this.panelEdit = new System.Windows.Forms.Panel();
            this.label16 = new System.Windows.Forms.Label();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.comboBoxEdit1 = new DevExpress.XtraEditors.ComboBoxEdit();
            this.panel2 = new System.Windows.Forms.Panel();
            this.simpleButtonEditOK = new DevExpress.XtraEditors.SimpleButton();
            this.label18 = new System.Windows.Forms.Label();
            this.simpleButtonEditCancle = new DevExpress.XtraEditors.SimpleButton();
            this.label9 = new System.Windows.Forms.Label();
            this.navBarGroupControlContainer6 = new DevExpress.XtraNavBar.NavBarGroupControlContainer();
            this.userControlTaskConvert1 = new TaskManage.UserControlTaskConvert();
            this.navBarGroupResult = new DevExpress.XtraNavBar.NavBarGroup();
            this.navBarGroupConvert = new DevExpress.XtraNavBar.NavBarGroup();
            this.groupControl4 = new DevExpress.XtraEditors.GroupControl();
            this.radioGroup1 = new DevExpress.XtraEditors.RadioGroup();
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl1)).BeginInit();
            this.navBarControl1.SuspendLayout();
            this.navBarGroupControlContainer1.SuspendLayout();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlDist)).BeginInit();
            this.groupControlDist.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tListDist)).BeginInit();
            this.panelKind.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControltype)).BeginInit();
            this.groupControltype.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tListDesignKind)).BeginInit();
            this.panelYear.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl5)).BeginInit();
            this.groupControl5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroupYear.Properties)).BeginInit();
            this.panel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlname)).BeginInit();
            this.groupControlname.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.panelQuery.SuspendLayout();
            this.navBarGroupControlContainer2.SuspendLayout();
            this.panelResult.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tListResult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageEdit1)).BeginInit();
            this.panelButtons.SuspendLayout();
            this.panelList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.panel4.SuspendLayout();
            this.panelEdit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit1.Properties)).BeginInit();
            this.panel2.SuspendLayout();
            this.navBarGroupControlContainer6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl4)).BeginInit();
            this.groupControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // navBarControl1
            // 
            this.navBarControl1.ActiveGroup = this.navBarGroupQuery;
            this.navBarControl1.Appearance.Background.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.navBarControl1.Appearance.Background.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.navBarControl1.Appearance.Background.Options.UseBackColor = true;
            this.navBarControl1.ContentButtonHint = null;
            this.navBarControl1.Controls.Add(this.navBarGroupControlContainer1);
            this.navBarControl1.Controls.Add(this.navBarGroupControlContainer2);
            this.navBarControl1.Controls.Add(this.navBarGroupControlContainer6);
            this.navBarControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.navBarControl1.Groups.AddRange(new DevExpress.XtraNavBar.NavBarGroup[] {
            this.navBarGroupQuery,
            this.navBarGroupResult,
            this.navBarGroupConvert});
            this.navBarControl1.LargeImages = this.imageList1;
            this.navBarControl1.Location = new System.Drawing.Point(4, 4);
            this.navBarControl1.Name = "navBarControl1";
            this.navBarControl1.OptionsNavPane.ExpandedWidth = 278;
            this.navBarControl1.Size = new System.Drawing.Size(292, 582);
            this.navBarControl1.StoreDefaultPaintStyleName = true;
            this.navBarControl1.TabIndex = 1;
            this.navBarControl1.Text = "navBarControl1";
            this.navBarControl1.GroupExpanded += new DevExpress.XtraNavBar.NavBarGroupEventHandler(this.navBarControl1_GroupExpanded);
            // 
            // navBarGroupQuery
            // 
            this.navBarGroupQuery.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.navBarGroupQuery.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.navBarGroupQuery.Appearance.Options.UseBackColor = true;
            this.navBarGroupQuery.AppearanceBackground.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.navBarGroupQuery.AppearanceBackground.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.navBarGroupQuery.AppearanceBackground.Options.UseBackColor = true;
            this.navBarGroupQuery.Caption = "搜索范围";
            this.navBarGroupQuery.ControlContainer = this.navBarGroupControlContainer1;
            this.navBarGroupQuery.Expanded = true;
            this.navBarGroupQuery.GroupClientHeight = 460;
            this.navBarGroupQuery.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.ControlContainer;
            this.navBarGroupQuery.LargeImageIndex = 18;
            this.navBarGroupQuery.Name = "navBarGroupQuery";
            this.navBarGroupQuery.ItemChanged += new System.EventHandler(this.navBarGroupQuery_ItemChanged);
            // 
            // navBarGroupControlContainer1
            // 
            this.navBarGroupControlContainer1.Controls.Add(this.panel7);
            this.navBarGroupControlContainer1.Controls.Add(this.splitterControl1);
            this.navBarGroupControlContainer1.Controls.Add(this.panelKind);
            this.navBarGroupControlContainer1.Controls.Add(this.panelYear);
            this.navBarGroupControlContainer1.Controls.Add(this.panel8);
            this.navBarGroupControlContainer1.Controls.Add(this.panelQuery);
            this.navBarGroupControlContainer1.Name = "navBarGroupControlContainer1";
            this.navBarGroupControlContainer1.Size = new System.Drawing.Size(284, 456);
            this.navBarGroupControlContainer1.TabIndex = 0;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.panel7.Controls.Add(this.label7);
            this.panel7.Controls.Add(this.groupControlDist);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel7.Location = new System.Drawing.Point(134, 80);
            this.panel7.Name = "panel7";
            this.panel7.Padding = new System.Windows.Forms.Padding(6, 14, 6, 0);
            this.panel7.Size = new System.Drawing.Size(150, 258);
            this.panel7.TabIndex = 17;
            this.panel7.TabStop = true;
            this.panel7.Paint += new System.Windows.Forms.PaintEventHandler(this.panel7_Paint);
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label7.ImageIndex = 23;
            this.label7.ImageList = this.imageList1;
            this.label7.Location = new System.Drawing.Point(14, 3);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(32, 32);
            this.label7.TabIndex = 12;
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "gtk-new.png");
            this.imageList1.Images.SetKeyName(1, "bookmark.png");
            this.imageList1.Images.SetKeyName(2, "notebook.png");
            this.imageList1.Images.SetKeyName(3, "bookmark-star.png");
            this.imageList1.Images.SetKeyName(4, "bookmark-edit.png");
            this.imageList1.Images.SetKeyName(5, "clock_edit.png");
            this.imageList1.Images.SetKeyName(6, "img-portrait-edit.png");
            this.imageList1.Images.SetKeyName(7, "history.png");
            this.imageList1.Images.SetKeyName(8, "world_edit.png");
            this.imageList1.Images.SetKeyName(9, "world3.png");
            this.imageList1.Images.SetKeyName(10, "table_tab_search.png");
            this.imageList1.Images.SetKeyName(11, "Arzo_Icons_012.png");
            this.imageList1.Images.SetKeyName(12, "info_32.png");
            this.imageList1.Images.SetKeyName(13, "clock_32.png");
            this.imageList1.Images.SetKeyName(14, "home_32.png");
            this.imageList1.Images.SetKeyName(15, "folder_32.png");
            this.imageList1.Images.SetKeyName(16, "flag_32.png");
            this.imageList1.Images.SetKeyName(17, "globe_32.png");
            this.imageList1.Images.SetKeyName(18, "search_32.png");
            this.imageList1.Images.SetKeyName(19, "color_swatch.png");
            this.imageList1.Images.SetKeyName(20, "house.png");
            this.imageList1.Images.SetKeyName(21, "images.png");
            this.imageList1.Images.SetKeyName(22, "insert_element.png");
            this.imageList1.Images.SetKeyName(23, "things_digital.png");
            this.imageList1.Images.SetKeyName(24, "time.png");
            this.imageList1.Images.SetKeyName(25, "map_magnify.png");
            this.imageList1.Images.SetKeyName(26, "messenger.png");
            this.imageList1.Images.SetKeyName(27, "orbit.png");
            this.imageList1.Images.SetKeyName(28, "application_edit.png");
            this.imageList1.Images.SetKeyName(29, "application_form_edit.png");
            this.imageList1.Images.SetKeyName(30, "large_tiles.png");
            this.imageList1.Images.SetKeyName(31, "book_edit.png");
            this.imageList1.Images.SetKeyName(32, "cog_edit.png");
            this.imageList1.Images.SetKeyName(33, "computer_edit.png");
            this.imageList1.Images.SetKeyName(34, "document_prepare.png");
            this.imageList1.Images.SetKeyName(35, "domain_template.png");
            this.imageList1.Images.SetKeyName(36, "ftp.png");
            this.imageList1.Images.SetKeyName(37, "globe_model.png");
            this.imageList1.Images.SetKeyName(38, "pencil.png");
            this.imageList1.Images.SetKeyName(39, "picture_edit.png");
            this.imageList1.Images.SetKeyName(40, "plugin_edit.png");
            this.imageList1.Images.SetKeyName(41, "report_edit.png");
            this.imageList1.Images.SetKeyName(42, "script_edit.png");
            this.imageList1.Images.SetKeyName(43, "to_do_list.png");
            this.imageList1.Images.SetKeyName(44, "to_do_list_cheked_all.png");
            this.imageList1.Images.SetKeyName(45, "widgets.png");
            this.imageList1.Images.SetKeyName(46, "Kombine_toolbar_022.png");
            this.imageList1.Images.SetKeyName(47, "system-run-32-2.png");
            this.imageList1.Images.SetKeyName(48, "030.png");
            this.imageList1.Images.SetKeyName(49, "037.png");
            this.imageList1.Images.SetKeyName(50, "065.png");
            this.imageList1.Images.SetKeyName(51, "File_edit.png");
            this.imageList1.Images.SetKeyName(52, "Glass.png");
            // 
            // groupControlDist
            // 
            this.groupControlDist.Controls.Add(this.tListDist);
            this.groupControlDist.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControlDist.Location = new System.Drawing.Point(6, 14);
            this.groupControlDist.Name = "groupControlDist";
            this.groupControlDist.Size = new System.Drawing.Size(138, 244);
            this.groupControlDist.TabIndex = 5;
            this.groupControlDist.Text = "        区划范围";
            // 
            // tListDist
            // 
            this.tListDist.Appearance.Empty.BackColor = System.Drawing.Color.White;
            this.tListDist.Appearance.Empty.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.tListDist.Appearance.Empty.Options.UseBackColor = true;
            this.tListDist.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(242)))), ((int)(((byte)(254)))));
            this.tListDist.Appearance.EvenRow.BackColor2 = System.Drawing.Color.White;
            this.tListDist.Appearance.EvenRow.ForeColor = System.Drawing.Color.Black;
            this.tListDist.Appearance.EvenRow.Options.UseBackColor = true;
            this.tListDist.Appearance.EvenRow.Options.UseForeColor = true;
            this.tListDist.Appearance.FocusedCell.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.tListDist.Appearance.FocusedCell.BackColor2 = System.Drawing.Color.LightCyan;
            this.tListDist.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Black;
            this.tListDist.Appearance.FocusedCell.Options.UseBackColor = true;
            this.tListDist.Appearance.FocusedCell.Options.UseForeColor = true;
            this.tListDist.Appearance.FocusedRow.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.tListDist.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.LightCyan;
            this.tListDist.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.tListDist.Appearance.FocusedRow.Options.UseBackColor = true;
            this.tListDist.Appearance.FocusedRow.Options.UseForeColor = true;
            this.tListDist.Appearance.FooterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(236)))), ((int)(((byte)(254)))));
            this.tListDist.Appearance.FooterPanel.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(171)))), ((int)(((byte)(228)))));
            this.tListDist.Appearance.FooterPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(236)))), ((int)(((byte)(254)))));
            this.tListDist.Appearance.FooterPanel.ForeColor = System.Drawing.Color.Black;
            this.tListDist.Appearance.FooterPanel.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.tListDist.Appearance.FooterPanel.Options.UseBackColor = true;
            this.tListDist.Appearance.FooterPanel.Options.UseBorderColor = true;
            this.tListDist.Appearance.FooterPanel.Options.UseForeColor = true;
            this.tListDist.Appearance.GroupButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(216)))), ((int)(((byte)(247)))));
            this.tListDist.Appearance.GroupButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(216)))), ((int)(((byte)(247)))));
            this.tListDist.Appearance.GroupButton.ForeColor = System.Drawing.Color.Black;
            this.tListDist.Appearance.GroupButton.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.tListDist.Appearance.GroupButton.Options.UseBackColor = true;
            this.tListDist.Appearance.GroupButton.Options.UseBorderColor = true;
            this.tListDist.Appearance.GroupButton.Options.UseForeColor = true;
            this.tListDist.Appearance.GroupFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(216)))), ((int)(((byte)(247)))));
            this.tListDist.Appearance.GroupFooter.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(216)))), ((int)(((byte)(247)))));
            this.tListDist.Appearance.GroupFooter.ForeColor = System.Drawing.Color.Black;
            this.tListDist.Appearance.GroupFooter.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.tListDist.Appearance.GroupFooter.Options.UseBackColor = true;
            this.tListDist.Appearance.GroupFooter.Options.UseBorderColor = true;
            this.tListDist.Appearance.GroupFooter.Options.UseForeColor = true;
            this.tListDist.Appearance.HeaderPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(236)))), ((int)(((byte)(254)))));
            this.tListDist.Appearance.HeaderPanel.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(171)))), ((int)(((byte)(228)))));
            this.tListDist.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(236)))), ((int)(((byte)(254)))));
            this.tListDist.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.Black;
            this.tListDist.Appearance.HeaderPanel.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.tListDist.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.tListDist.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.tListDist.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.tListDist.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(153)))), ((int)(((byte)(228)))));
            this.tListDist.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(224)))), ((int)(((byte)(251)))));
            this.tListDist.Appearance.HideSelectionRow.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.tListDist.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.tListDist.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.tListDist.Appearance.HorzLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(127)))), ((int)(((byte)(196)))));
            this.tListDist.Appearance.HorzLine.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.tListDist.Appearance.HorzLine.Options.UseBackColor = true;
            this.tListDist.Appearance.OddRow.BackColor = System.Drawing.Color.White;
            this.tListDist.Appearance.OddRow.ForeColor = System.Drawing.Color.Black;
            this.tListDist.Appearance.OddRow.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.tListDist.Appearance.OddRow.Options.UseBackColor = true;
            this.tListDist.Appearance.OddRow.Options.UseForeColor = true;
            this.tListDist.Appearance.Preview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(252)))), ((int)(((byte)(255)))));
            this.tListDist.Appearance.Preview.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(129)))), ((int)(((byte)(185)))));
            this.tListDist.Appearance.Preview.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.tListDist.Appearance.Preview.Options.UseBackColor = true;
            this.tListDist.Appearance.Preview.Options.UseForeColor = true;
            this.tListDist.Appearance.Row.BackColor = System.Drawing.Color.White;
            this.tListDist.Appearance.Row.ForeColor = System.Drawing.Color.Black;
            this.tListDist.Appearance.Row.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.tListDist.Appearance.Row.Options.UseBackColor = true;
            this.tListDist.Appearance.Row.Options.UseForeColor = true;
            this.tListDist.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(126)))), ((int)(((byte)(217)))));
            this.tListDist.Appearance.SelectedRow.BackColor2 = System.Drawing.Color.White;
            this.tListDist.Appearance.SelectedRow.ForeColor = System.Drawing.Color.White;
            this.tListDist.Appearance.SelectedRow.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.tListDist.Appearance.SelectedRow.Options.UseBackColor = true;
            this.tListDist.Appearance.SelectedRow.Options.UseForeColor = true;
            this.tListDist.Appearance.TreeLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(97)))), ((int)(((byte)(156)))));
            this.tListDist.Appearance.TreeLine.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.tListDist.Appearance.TreeLine.Options.UseBackColor = true;
            this.tListDist.Appearance.VertLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(127)))), ((int)(((byte)(196)))));
            this.tListDist.Appearance.VertLine.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.tListDist.Appearance.VertLine.Options.UseBackColor = true;
            this.tListDist.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.tListDist.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.treeListColumn1,
            this.treeListColumn2});
            this.tListDist.CustomizationFormBounds = new System.Drawing.Rectangle(269, 370, 208, 163);
            this.tListDist.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tListDist.Location = new System.Drawing.Point(2, 22);
            this.tListDist.LookAndFeel.SkinName = "Blue";
            this.tListDist.Name = "tListDist";
            this.tListDist.OptionsBehavior.Editable = false;
            this.tListDist.OptionsView.ShowColumns = false;
            this.tListDist.OptionsView.ShowHorzLines = false;
            this.tListDist.OptionsView.ShowIndicator = false;
            this.tListDist.OptionsView.ShowVertLines = false;
            this.tListDist.Size = new System.Drawing.Size(134, 220);
            this.tListDist.TabIndex = 77;
            this.tListDist.TreeLineStyle = DevExpress.XtraTreeList.LineStyle.None;
            this.tListDist.BeforeExpand += new DevExpress.XtraTreeList.BeforeExpandEventHandler(this.tListDist_BeforeExpand);
            this.tListDist.MouseClick += new System.Windows.Forms.MouseEventHandler(this.tListDist_MouseClick);
            // 
            // treeListColumn1
            // 
            this.treeListColumn1.Caption = "名称";
            this.treeListColumn1.FieldName = "设备号";
            this.treeListColumn1.MinWidth = 100;
            this.treeListColumn1.Name = "treeListColumn1";
            this.treeListColumn1.Visible = true;
            this.treeListColumn1.VisibleIndex = 0;
            this.treeListColumn1.Width = 100;
            // 
            // treeListColumn2
            // 
            this.treeListColumn2.Caption = "定位";
            this.treeListColumn2.FieldName = "定位";
            this.treeListColumn2.MinWidth = 16;
            this.treeListColumn2.Name = "treeListColumn2";
            this.treeListColumn2.Visible = true;
            this.treeListColumn2.VisibleIndex = 1;
            this.treeListColumn2.Width = 10;
            // 
            // splitterControl1
            // 
            this.splitterControl1.Location = new System.Drawing.Point(129, 80);
            this.splitterControl1.Name = "splitterControl1";
            this.splitterControl1.Size = new System.Drawing.Size(5, 258);
            this.splitterControl1.TabIndex = 19;
            this.splitterControl1.TabStop = false;
            // 
            // panelKind
            // 
            this.panelKind.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.panelKind.Controls.Add(this.labelKind);
            this.panelKind.Controls.Add(this.groupControltype);
            this.panelKind.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelKind.Location = new System.Drawing.Point(0, 80);
            this.panelKind.Name = "panelKind";
            this.panelKind.Padding = new System.Windows.Forms.Padding(6, 14, 6, 0);
            this.panelKind.Size = new System.Drawing.Size(129, 258);
            this.panelKind.TabIndex = 15;
            this.panelKind.Paint += new System.Windows.Forms.PaintEventHandler(this.panel5_Paint);
            // 
            // labelKind
            // 
            this.labelKind.BackColor = System.Drawing.Color.Transparent;
            this.labelKind.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelKind.ImageIndex = 4;
            this.labelKind.ImageList = this.imageList1;
            this.labelKind.Location = new System.Drawing.Point(14, 3);
            this.labelKind.Name = "labelKind";
            this.labelKind.Size = new System.Drawing.Size(32, 32);
            this.labelKind.TabIndex = 11;
            this.labelKind.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.labelKind.Click += new System.EventHandler(this.labelKind_Click);
            // 
            // groupControltype
            // 
            this.groupControltype.Controls.Add(this.tListDesignKind);
            this.groupControltype.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControltype.Location = new System.Drawing.Point(6, 14);
            this.groupControltype.Name = "groupControltype";
            this.groupControltype.Size = new System.Drawing.Size(117, 244);
            this.groupControltype.TabIndex = 4;
            this.groupControltype.TabStop = true;
            this.groupControltype.Text = "        设计类型";
            // 
            // tListDesignKind
            // 
            this.tListDesignKind.Appearance.Empty.BackColor = System.Drawing.Color.White;
            this.tListDesignKind.Appearance.Empty.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.tListDesignKind.Appearance.Empty.Options.UseBackColor = true;
            this.tListDesignKind.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(242)))), ((int)(((byte)(254)))));
            this.tListDesignKind.Appearance.EvenRow.BackColor2 = System.Drawing.Color.White;
            this.tListDesignKind.Appearance.EvenRow.ForeColor = System.Drawing.Color.Black;
            this.tListDesignKind.Appearance.EvenRow.Options.UseBackColor = true;
            this.tListDesignKind.Appearance.EvenRow.Options.UseForeColor = true;
            this.tListDesignKind.Appearance.FocusedCell.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.tListDesignKind.Appearance.FocusedCell.BackColor2 = System.Drawing.Color.LightCyan;
            this.tListDesignKind.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Black;
            this.tListDesignKind.Appearance.FocusedCell.Options.UseBackColor = true;
            this.tListDesignKind.Appearance.FocusedCell.Options.UseForeColor = true;
            this.tListDesignKind.Appearance.FocusedRow.BackColor = System.Drawing.Color.DodgerBlue;
            this.tListDesignKind.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.LightCyan;
            this.tListDesignKind.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.tListDesignKind.Appearance.FocusedRow.Options.UseBackColor = true;
            this.tListDesignKind.Appearance.FocusedRow.Options.UseForeColor = true;
            this.tListDesignKind.Appearance.FooterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(236)))), ((int)(((byte)(254)))));
            this.tListDesignKind.Appearance.FooterPanel.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(171)))), ((int)(((byte)(228)))));
            this.tListDesignKind.Appearance.FooterPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(236)))), ((int)(((byte)(254)))));
            this.tListDesignKind.Appearance.FooterPanel.ForeColor = System.Drawing.Color.Black;
            this.tListDesignKind.Appearance.FooterPanel.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.tListDesignKind.Appearance.FooterPanel.Options.UseBackColor = true;
            this.tListDesignKind.Appearance.FooterPanel.Options.UseBorderColor = true;
            this.tListDesignKind.Appearance.FooterPanel.Options.UseForeColor = true;
            this.tListDesignKind.Appearance.GroupButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(216)))), ((int)(((byte)(247)))));
            this.tListDesignKind.Appearance.GroupButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(216)))), ((int)(((byte)(247)))));
            this.tListDesignKind.Appearance.GroupButton.ForeColor = System.Drawing.Color.Black;
            this.tListDesignKind.Appearance.GroupButton.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.tListDesignKind.Appearance.GroupButton.Options.UseBackColor = true;
            this.tListDesignKind.Appearance.GroupButton.Options.UseBorderColor = true;
            this.tListDesignKind.Appearance.GroupButton.Options.UseForeColor = true;
            this.tListDesignKind.Appearance.GroupFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(216)))), ((int)(((byte)(247)))));
            this.tListDesignKind.Appearance.GroupFooter.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(216)))), ((int)(((byte)(247)))));
            this.tListDesignKind.Appearance.GroupFooter.ForeColor = System.Drawing.Color.Black;
            this.tListDesignKind.Appearance.GroupFooter.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.tListDesignKind.Appearance.GroupFooter.Options.UseBackColor = true;
            this.tListDesignKind.Appearance.GroupFooter.Options.UseBorderColor = true;
            this.tListDesignKind.Appearance.GroupFooter.Options.UseForeColor = true;
            this.tListDesignKind.Appearance.HeaderPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(236)))), ((int)(((byte)(254)))));
            this.tListDesignKind.Appearance.HeaderPanel.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(171)))), ((int)(((byte)(228)))));
            this.tListDesignKind.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(236)))), ((int)(((byte)(254)))));
            this.tListDesignKind.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.Black;
            this.tListDesignKind.Appearance.HeaderPanel.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.tListDesignKind.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.tListDesignKind.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.tListDesignKind.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.tListDesignKind.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(153)))), ((int)(((byte)(228)))));
            this.tListDesignKind.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(224)))), ((int)(((byte)(251)))));
            this.tListDesignKind.Appearance.HideSelectionRow.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.tListDesignKind.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.tListDesignKind.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.tListDesignKind.Appearance.HorzLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(127)))), ((int)(((byte)(196)))));
            this.tListDesignKind.Appearance.HorzLine.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.tListDesignKind.Appearance.HorzLine.Options.UseBackColor = true;
            this.tListDesignKind.Appearance.OddRow.BackColor = System.Drawing.Color.White;
            this.tListDesignKind.Appearance.OddRow.ForeColor = System.Drawing.Color.Black;
            this.tListDesignKind.Appearance.OddRow.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.tListDesignKind.Appearance.OddRow.Options.UseBackColor = true;
            this.tListDesignKind.Appearance.OddRow.Options.UseForeColor = true;
            this.tListDesignKind.Appearance.Preview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(252)))), ((int)(((byte)(255)))));
            this.tListDesignKind.Appearance.Preview.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(129)))), ((int)(((byte)(185)))));
            this.tListDesignKind.Appearance.Preview.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.tListDesignKind.Appearance.Preview.Options.UseBackColor = true;
            this.tListDesignKind.Appearance.Preview.Options.UseForeColor = true;
            this.tListDesignKind.Appearance.Row.BackColor = System.Drawing.Color.White;
            this.tListDesignKind.Appearance.Row.ForeColor = System.Drawing.Color.Black;
            this.tListDesignKind.Appearance.Row.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.tListDesignKind.Appearance.Row.Options.UseBackColor = true;
            this.tListDesignKind.Appearance.Row.Options.UseForeColor = true;
            this.tListDesignKind.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(126)))), ((int)(((byte)(217)))));
            this.tListDesignKind.Appearance.SelectedRow.BackColor2 = System.Drawing.Color.White;
            this.tListDesignKind.Appearance.SelectedRow.ForeColor = System.Drawing.Color.White;
            this.tListDesignKind.Appearance.SelectedRow.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.tListDesignKind.Appearance.SelectedRow.Options.UseBackColor = true;
            this.tListDesignKind.Appearance.SelectedRow.Options.UseForeColor = true;
            this.tListDesignKind.Appearance.TreeLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(97)))), ((int)(((byte)(156)))));
            this.tListDesignKind.Appearance.TreeLine.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.tListDesignKind.Appearance.TreeLine.Options.UseBackColor = true;
            this.tListDesignKind.Appearance.VertLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(127)))), ((int)(((byte)(196)))));
            this.tListDesignKind.Appearance.VertLine.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.tListDesignKind.Appearance.VertLine.Options.UseBackColor = true;
            this.tListDesignKind.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.tListDesignKind.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.tcolBase1});
            this.tListDesignKind.CustomizationFormBounds = new System.Drawing.Rectangle(269, 370, 208, 163);
            this.tListDesignKind.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tListDesignKind.Location = new System.Drawing.Point(2, 22);
            this.tListDesignKind.LookAndFeel.SkinName = "Blue";
            this.tListDesignKind.Name = "tListDesignKind";
            this.tListDesignKind.OptionsBehavior.Editable = false;
            this.tListDesignKind.OptionsView.ShowColumns = false;
            this.tListDesignKind.OptionsView.ShowHorzLines = false;
            this.tListDesignKind.OptionsView.ShowIndicator = false;
            this.tListDesignKind.OptionsView.ShowVertLines = false;
            this.tListDesignKind.Size = new System.Drawing.Size(113, 220);
            this.tListDesignKind.TabIndex = 77;
            this.tListDesignKind.TreeLineStyle = DevExpress.XtraTreeList.LineStyle.None;
            this.tListDesignKind.MouseClick += new System.Windows.Forms.MouseEventHandler(this.tListDesignKind_MouseClick);
            // 
            // tcolBase1
            // 
            this.tcolBase1.Caption = "名称";
            this.tcolBase1.FieldName = "设备号";
            this.tcolBase1.MinWidth = 100;
            this.tcolBase1.Name = "tcolBase1";
            this.tcolBase1.Visible = true;
            this.tcolBase1.VisibleIndex = 0;
            this.tcolBase1.Width = 100;
            // 
            // panelYear
            // 
            this.panelYear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.panelYear.Controls.Add(this.label1);
            this.panelYear.Controls.Add(this.groupControl5);
            this.panelYear.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelYear.Location = new System.Drawing.Point(0, 0);
            this.panelYear.Name = "panelYear";
            this.panelYear.Padding = new System.Windows.Forms.Padding(6, 14, 6, 6);
            this.panelYear.Size = new System.Drawing.Size(284, 80);
            this.panelYear.TabIndex = 16;
            this.panelYear.Paint += new System.Windows.Forms.PaintEventHandler(this.panel6_Paint);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ImageIndex = 13;
            this.label1.ImageList = this.imageList1;
            this.label1.Location = new System.Drawing.Point(14, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 32);
            this.label1.TabIndex = 12;
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupControl5
            // 
            this.groupControl5.AppearanceCaption.Image = ((System.Drawing.Image)(resources.GetObject("groupControl5.AppearanceCaption.Image")));
            this.groupControl5.AppearanceCaption.Options.UseImage = true;
            this.groupControl5.ContentImage = ((System.Drawing.Image)(resources.GetObject("groupControl5.ContentImage")));
            this.groupControl5.ContentImageAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.groupControl5.Controls.Add(this.radioGroupYear);
            this.groupControl5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl5.Location = new System.Drawing.Point(6, 14);
            this.groupControl5.LookAndFeel.SkinName = "Blue";
            this.groupControl5.LookAndFeel.UseDefaultLookAndFeel = false;
            this.groupControl5.Name = "groupControl5";
            this.groupControl5.Size = new System.Drawing.Size(272, 60);
            this.groupControl5.TabIndex = 3;
            this.groupControl5.TabStop = true;
            this.groupControl5.Text = "        设计时间";
            // 
            // radioGroupYear
            // 
            this.radioGroupYear.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radioGroupYear.Location = new System.Drawing.Point(2, 22);
            this.radioGroupYear.Name = "radioGroupYear";
            this.radioGroupYear.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.radioGroupYear.Properties.Columns = 3;
            this.radioGroupYear.Size = new System.Drawing.Size(268, 36);
            this.radioGroupYear.TabIndex = 3;
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.panel8.Controls.Add(this.label8);
            this.panel8.Controls.Add(this.groupControlname);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel8.Location = new System.Drawing.Point(0, 338);
            this.panel8.Name = "panel8";
            this.panel8.Padding = new System.Windows.Forms.Padding(6, 16, 6, 0);
            this.panel8.Size = new System.Drawing.Size(284, 80);
            this.panel8.TabIndex = 18;
            this.panel8.Paint += new System.Windows.Forms.PaintEventHandler(this.panel8_Paint);
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.ImageIndex = 31;
            this.label8.ImageList = this.imageList1;
            this.label8.Location = new System.Drawing.Point(14, 5);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(32, 32);
            this.label8.TabIndex = 13;
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // groupControlname
            // 
            this.groupControlname.Appearance.BackColor = System.Drawing.Color.White;
            this.groupControlname.Appearance.Options.UseBackColor = true;
            this.groupControlname.Controls.Add(this.panelControl1);
            this.groupControlname.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControlname.Location = new System.Drawing.Point(6, 16);
            this.groupControlname.Name = "groupControlname";
            this.groupControlname.Size = new System.Drawing.Size(272, 64);
            this.groupControlname.TabIndex = 6;
            this.groupControlname.Text = "        设计名称";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.textBoxNane);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(2, 22);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(268, 40);
            this.panelControl1.TabIndex = 7;
            // 
            // textBoxNane
            // 
            this.textBoxNane.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxNane.Location = new System.Drawing.Point(2, 2);
            this.textBoxNane.Multiline = true;
            this.textBoxNane.Name = "textBoxNane";
            this.textBoxNane.Size = new System.Drawing.Size(264, 36);
            this.textBoxNane.TabIndex = 0;
            // 
            // panelQuery
            // 
            this.panelQuery.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.panelQuery.Controls.Add(this.simpleButtonReset);
            this.panelQuery.Controls.Add(this.label11);
            this.panelQuery.Controls.Add(this.simpleButtonQuery);
            this.panelQuery.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelQuery.Location = new System.Drawing.Point(0, 418);
            this.panelQuery.Name = "panelQuery";
            this.panelQuery.Padding = new System.Windows.Forms.Padding(6);
            this.panelQuery.Size = new System.Drawing.Size(284, 38);
            this.panelQuery.TabIndex = 14;
            // 
            // simpleButtonReset
            // 
            this.simpleButtonReset.Dock = System.Windows.Forms.DockStyle.Right;
            this.simpleButtonReset.Image = ((System.Drawing.Image)(resources.GetObject("simpleButtonReset.Image")));
            this.simpleButtonReset.Location = new System.Drawing.Point(117, 6);
            this.simpleButtonReset.Name = "simpleButtonReset";
            this.simpleButtonReset.Size = new System.Drawing.Size(78, 26);
            this.simpleButtonReset.TabIndex = 1;
            this.simpleButtonReset.Text = "重置";
            this.simpleButtonReset.Click += new System.EventHandler(this.simpleButtonReset_Click);
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Dock = System.Windows.Forms.DockStyle.Right;
            this.label11.Location = new System.Drawing.Point(195, 6);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(5, 26);
            this.label11.TabIndex = 11;
            // 
            // simpleButtonQuery
            // 
            this.simpleButtonQuery.Dock = System.Windows.Forms.DockStyle.Right;
            this.simpleButtonQuery.Image = ((System.Drawing.Image)(resources.GetObject("simpleButtonQuery.Image")));
            this.simpleButtonQuery.Location = new System.Drawing.Point(200, 6);
            this.simpleButtonQuery.Name = "simpleButtonQuery";
            this.simpleButtonQuery.Size = new System.Drawing.Size(78, 26);
            this.simpleButtonQuery.TabIndex = 0;
            this.simpleButtonQuery.Text = "查询";
            this.simpleButtonQuery.Click += new System.EventHandler(this.simpleButtonQuery_Click);
            // 
            // navBarGroupControlContainer2
            // 
            this.navBarGroupControlContainer2.Controls.Add(this.panelResult);
            this.navBarGroupControlContainer2.Name = "navBarGroupControlContainer2";
            this.navBarGroupControlContainer2.Size = new System.Drawing.Size(290, 459);
            this.navBarGroupControlContainer2.TabIndex = 1;
            // 
            // panelResult
            // 
            this.panelResult.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.panelResult.Controls.Add(this.panel3);
            this.panelResult.Controls.Add(this.panelList);
            this.panelResult.Controls.Add(this.panelEdit);
            this.panelResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelResult.Location = new System.Drawing.Point(0, 0);
            this.panelResult.Name = "panelResult";
            this.panelResult.Padding = new System.Windows.Forms.Padding(4, 5, 5, 0);
            this.panelResult.Size = new System.Drawing.Size(290, 459);
            this.panelResult.TabIndex = 81;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.tListResult);
            this.panel3.Controls.Add(this.labelInfo);
            this.panel3.Controls.Add(this.panelButtons);
            this.panel3.Controls.Add(this.labelResultInfo);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(4, 5);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(281, 88);
            this.panel3.TabIndex = 85;
            // 
            // tListResult
            // 
            this.tListResult.Appearance.Empty.BackColor = System.Drawing.Color.White;
            this.tListResult.Appearance.Empty.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.tListResult.Appearance.Empty.Options.UseBackColor = true;
            this.tListResult.Appearance.FocusedCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.tListResult.Appearance.FocusedCell.BackColor2 = System.Drawing.Color.White;
            this.tListResult.Appearance.FocusedCell.BorderColor = System.Drawing.Color.Yellow;
            this.tListResult.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Yellow;
            this.tListResult.Appearance.FocusedCell.Options.UseBackColor = true;
            this.tListResult.Appearance.FocusedCell.Options.UseBorderColor = true;
            this.tListResult.Appearance.FocusedCell.Options.UseForeColor = true;
            this.tListResult.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(106)))), ((int)(((byte)(197)))));
            this.tListResult.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.White;
            this.tListResult.Appearance.FocusedRow.BorderColor = System.Drawing.Color.Yellow;
            this.tListResult.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Yellow;
            this.tListResult.Appearance.FocusedRow.Options.UseBackColor = true;
            this.tListResult.Appearance.FocusedRow.Options.UseBorderColor = true;
            this.tListResult.Appearance.FocusedRow.Options.UseForeColor = true;
            this.tListResult.Appearance.FooterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(236)))), ((int)(((byte)(254)))));
            this.tListResult.Appearance.FooterPanel.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(171)))), ((int)(((byte)(228)))));
            this.tListResult.Appearance.FooterPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(236)))), ((int)(((byte)(254)))));
            this.tListResult.Appearance.FooterPanel.ForeColor = System.Drawing.Color.Black;
            this.tListResult.Appearance.FooterPanel.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.tListResult.Appearance.FooterPanel.Options.UseBackColor = true;
            this.tListResult.Appearance.FooterPanel.Options.UseBorderColor = true;
            this.tListResult.Appearance.FooterPanel.Options.UseForeColor = true;
            this.tListResult.Appearance.GroupButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(216)))), ((int)(((byte)(247)))));
            this.tListResult.Appearance.GroupButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(216)))), ((int)(((byte)(247)))));
            this.tListResult.Appearance.GroupButton.ForeColor = System.Drawing.Color.Black;
            this.tListResult.Appearance.GroupButton.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.tListResult.Appearance.GroupButton.Options.UseBackColor = true;
            this.tListResult.Appearance.GroupButton.Options.UseBorderColor = true;
            this.tListResult.Appearance.GroupButton.Options.UseForeColor = true;
            this.tListResult.Appearance.GroupFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(216)))), ((int)(((byte)(247)))));
            this.tListResult.Appearance.GroupFooter.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(216)))), ((int)(((byte)(247)))));
            this.tListResult.Appearance.GroupFooter.ForeColor = System.Drawing.Color.Black;
            this.tListResult.Appearance.GroupFooter.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.tListResult.Appearance.GroupFooter.Options.UseBackColor = true;
            this.tListResult.Appearance.GroupFooter.Options.UseBorderColor = true;
            this.tListResult.Appearance.GroupFooter.Options.UseForeColor = true;
            this.tListResult.Appearance.HeaderPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(236)))), ((int)(((byte)(254)))));
            this.tListResult.Appearance.HeaderPanel.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(171)))), ((int)(((byte)(228)))));
            this.tListResult.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(236)))), ((int)(((byte)(254)))));
            this.tListResult.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.Black;
            this.tListResult.Appearance.HeaderPanel.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.tListResult.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.tListResult.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.tListResult.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.tListResult.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(153)))), ((int)(((byte)(228)))));
            this.tListResult.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(224)))), ((int)(((byte)(251)))));
            this.tListResult.Appearance.HideSelectionRow.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.tListResult.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.tListResult.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.tListResult.Appearance.HorzLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(127)))), ((int)(((byte)(196)))));
            this.tListResult.Appearance.HorzLine.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.tListResult.Appearance.HorzLine.Options.UseBackColor = true;
            this.tListResult.Appearance.OddRow.BackColor = System.Drawing.Color.White;
            this.tListResult.Appearance.OddRow.ForeColor = System.Drawing.Color.Black;
            this.tListResult.Appearance.OddRow.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.tListResult.Appearance.OddRow.Options.UseBackColor = true;
            this.tListResult.Appearance.OddRow.Options.UseForeColor = true;
            this.tListResult.Appearance.Preview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(252)))), ((int)(((byte)(255)))));
            this.tListResult.Appearance.Preview.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(129)))), ((int)(((byte)(185)))));
            this.tListResult.Appearance.Preview.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.tListResult.Appearance.Preview.Options.UseBackColor = true;
            this.tListResult.Appearance.Preview.Options.UseForeColor = true;
            this.tListResult.Appearance.Row.BackColor = System.Drawing.Color.White;
            this.tListResult.Appearance.Row.ForeColor = System.Drawing.Color.Black;
            this.tListResult.Appearance.Row.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.tListResult.Appearance.Row.Options.UseBackColor = true;
            this.tListResult.Appearance.Row.Options.UseForeColor = true;
            this.tListResult.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(126)))), ((int)(((byte)(217)))));
            this.tListResult.Appearance.SelectedRow.BackColor2 = System.Drawing.Color.White;
            this.tListResult.Appearance.SelectedRow.BorderColor = System.Drawing.Color.Gold;
            this.tListResult.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Yellow;
            this.tListResult.Appearance.SelectedRow.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.tListResult.Appearance.SelectedRow.Options.UseBackColor = true;
            this.tListResult.Appearance.SelectedRow.Options.UseBorderColor = true;
            this.tListResult.Appearance.SelectedRow.Options.UseForeColor = true;
            this.tListResult.Appearance.TreeLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(97)))), ((int)(((byte)(156)))));
            this.tListResult.Appearance.TreeLine.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.tListResult.Appearance.TreeLine.Options.UseBackColor = true;
            this.tListResult.Appearance.VertLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(127)))), ((int)(((byte)(196)))));
            this.tListResult.Appearance.VertLine.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.tListResult.Appearance.VertLine.Options.UseBackColor = true;
            this.tListResult.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.treeListColumn3,
            this.treeListColumn4});
            this.tListResult.CustomizationFormBounds = new System.Drawing.Rectangle(269, 370, 208, 163);
            this.tListResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tListResult.Location = new System.Drawing.Point(0, 24);
            this.tListResult.LookAndFeel.SkinName = "Blue";
            this.tListResult.Name = "tListResult";
            this.tListResult.OptionsBehavior.Editable = false;
            this.tListResult.OptionsSelection.EnableAppearanceFocusedRow = false;
            this.tListResult.OptionsView.EnableAppearanceEvenRow = true;
            this.tListResult.OptionsView.ShowColumns = false;
            this.tListResult.OptionsView.ShowHorzLines = false;
            this.tListResult.OptionsView.ShowIndicator = false;
            this.tListResult.OptionsView.ShowVertLines = false;
            this.tListResult.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemImageEdit1});
            this.tListResult.Size = new System.Drawing.Size(281, 2);
            this.tListResult.TabIndex = 78;
            this.tListResult.TreeLineStyle = DevExpress.XtraTreeList.LineStyle.None;
            this.tListResult.CustomNodeCellEdit += new DevExpress.XtraTreeList.GetCustomNodeCellEditEventHandler(this.tListResult_CustomNodeCellEdit);
            this.tListResult.MouseClick += new System.Windows.Forms.MouseEventHandler(this.tListResult_MouseClick);
            // 
            // treeListColumn3
            // 
            this.treeListColumn3.Caption = "名称";
            this.treeListColumn3.FieldName = "设备号";
            this.treeListColumn3.MinWidth = 100;
            this.treeListColumn3.Name = "treeListColumn3";
            this.treeListColumn3.Visible = true;
            this.treeListColumn3.VisibleIndex = 0;
            this.treeListColumn3.Width = 100;
            // 
            // treeListColumn4
            // 
            this.treeListColumn4.Caption = "查看";
            this.treeListColumn4.FieldName = "定位";
            this.treeListColumn4.Name = "treeListColumn4";
            this.treeListColumn4.Visible = true;
            this.treeListColumn4.VisibleIndex = 1;
            this.treeListColumn4.Width = 20;
            // 
            // repositoryItemImageEdit1
            // 
            this.repositoryItemImageEdit1.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("repositoryItemImageEdit1.Appearance.Image")));
            this.repositoryItemImageEdit1.Appearance.Options.UseImage = true;
            this.repositoryItemImageEdit1.AutoHeight = false;
            this.repositoryItemImageEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemImageEdit1.Name = "repositoryItemImageEdit1";
            this.repositoryItemImageEdit1.Click += new System.EventHandler(this.repositoryItemImageEdit1_Click);
            // 
            // labelInfo
            // 
            this.labelInfo.BackColor = System.Drawing.Color.Transparent;
            this.labelInfo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.labelInfo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelInfo.ImageKey = "flag_32.png";
            this.labelInfo.ImageList = this.imageList2;
            this.labelInfo.Location = new System.Drawing.Point(0, 26);
            this.labelInfo.Name = "labelInfo";
            this.labelInfo.Size = new System.Drawing.Size(281, 24);
            this.labelInfo.TabIndex = 80;
            this.labelInfo.Text = "     共计0个作业设计";
            this.labelInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // imageList2
            // 
            this.imageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList2.ImageStream")));
            this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList2.Images.SetKeyName(0, "gtk-new.png");
            this.imageList2.Images.SetKeyName(1, "bookmark.png");
            this.imageList2.Images.SetKeyName(2, "notebook.png");
            this.imageList2.Images.SetKeyName(3, "bookmark-star.png");
            this.imageList2.Images.SetKeyName(4, "bookmark-edit.png");
            this.imageList2.Images.SetKeyName(5, "clock_edit.png");
            this.imageList2.Images.SetKeyName(6, "img-portrait-edit.png");
            this.imageList2.Images.SetKeyName(7, "history.png");
            this.imageList2.Images.SetKeyName(8, "world_edit.png");
            this.imageList2.Images.SetKeyName(9, "world3.png");
            this.imageList2.Images.SetKeyName(10, "table_tab_search.png");
            this.imageList2.Images.SetKeyName(11, "Arzo_Icons_012.png");
            this.imageList2.Images.SetKeyName(12, "info_32.png");
            this.imageList2.Images.SetKeyName(13, "clock_32.png");
            this.imageList2.Images.SetKeyName(14, "home_32.png");
            this.imageList2.Images.SetKeyName(15, "folder_32.png");
            this.imageList2.Images.SetKeyName(16, "flag_32.png");
            this.imageList2.Images.SetKeyName(17, "globe_32.png");
            this.imageList2.Images.SetKeyName(18, "search_32.png");
            this.imageList2.Images.SetKeyName(19, "color_swatch.png");
            this.imageList2.Images.SetKeyName(20, "house.png");
            this.imageList2.Images.SetKeyName(21, "images.png");
            this.imageList2.Images.SetKeyName(22, "insert_element.png");
            this.imageList2.Images.SetKeyName(23, "things_digital.png");
            this.imageList2.Images.SetKeyName(24, "time.png");
            this.imageList2.Images.SetKeyName(25, "map_magnify.png");
            this.imageList2.Images.SetKeyName(26, "messenger.png");
            this.imageList2.Images.SetKeyName(27, "orbit.png");
            this.imageList2.Images.SetKeyName(28, "application_edit.png");
            this.imageList2.Images.SetKeyName(29, "application_form_edit.png");
            this.imageList2.Images.SetKeyName(30, "large_tiles.png");
            this.imageList2.Images.SetKeyName(31, "book_edit.png");
            this.imageList2.Images.SetKeyName(32, "cog_edit.png");
            this.imageList2.Images.SetKeyName(33, "computer_edit.png");
            this.imageList2.Images.SetKeyName(34, "document_prepare.png");
            this.imageList2.Images.SetKeyName(35, "domain_template.png");
            this.imageList2.Images.SetKeyName(36, "ftp.png");
            this.imageList2.Images.SetKeyName(37, "globe_model.png");
            this.imageList2.Images.SetKeyName(38, "pencil.png");
            this.imageList2.Images.SetKeyName(39, "picture_edit.png");
            this.imageList2.Images.SetKeyName(40, "plugin_edit.png");
            this.imageList2.Images.SetKeyName(41, "report_edit.png");
            this.imageList2.Images.SetKeyName(42, "script_edit.png");
            this.imageList2.Images.SetKeyName(43, "to_do_list.png");
            this.imageList2.Images.SetKeyName(44, "to_do_list_cheked_all.png");
            this.imageList2.Images.SetKeyName(45, "widgets.png");
            // 
            // panelButtons
            // 
            this.panelButtons.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.panelButtons.Controls.Add(this.simpleButtonSchedule);
            this.panelButtons.Controls.Add(this.label3);
            this.panelButtons.Controls.Add(this.simpleButtonQueryMap);
            this.panelButtons.Controls.Add(this.label2);
            this.panelButtons.Controls.Add(this.simpleButtonQueryXB);
            this.panelButtons.Controls.Add(this.label14);
            this.panelButtons.Controls.Add(this.simpleButtonEdit);
            this.panelButtons.Controls.Add(this.label13);
            this.panelButtons.Controls.Add(this.simpleButtonDelete);
            this.panelButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelButtons.Location = new System.Drawing.Point(0, 50);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Padding = new System.Windows.Forms.Padding(0, 6, 0, 6);
            this.panelButtons.Size = new System.Drawing.Size(281, 38);
            this.panelButtons.TabIndex = 79;
            this.panelButtons.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // simpleButtonSchedule
            // 
            this.simpleButtonSchedule.Dock = System.Windows.Forms.DockStyle.Right;
            this.simpleButtonSchedule.Image = ((System.Drawing.Image)(resources.GetObject("simpleButtonSchedule.Image")));
            this.simpleButtonSchedule.ImageIndex = 43;
            this.simpleButtonSchedule.Location = new System.Drawing.Point(-67, 6);
            this.simpleButtonSchedule.Name = "simpleButtonSchedule";
            this.simpleButtonSchedule.Size = new System.Drawing.Size(68, 26);
            this.simpleButtonSchedule.TabIndex = 16;
            this.simpleButtonSchedule.Text = "一览表";
            this.simpleButtonSchedule.ToolTip = "作业设计一览表";
            this.simpleButtonSchedule.Visible = false;
            this.simpleButtonSchedule.Click += new System.EventHandler(this.simpleButtonSchedule_Click);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Dock = System.Windows.Forms.DockStyle.Right;
            this.label3.Location = new System.Drawing.Point(1, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(2, 26);
            this.label3.TabIndex = 17;
            // 
            // simpleButtonQueryMap
            // 
            this.simpleButtonQueryMap.Dock = System.Windows.Forms.DockStyle.Right;
            this.simpleButtonQueryMap.Image = ((System.Drawing.Image)(resources.GetObject("simpleButtonQueryMap.Image")));
            this.simpleButtonQueryMap.Location = new System.Drawing.Point(3, 6);
            this.simpleButtonQueryMap.Name = "simpleButtonQueryMap";
            this.simpleButtonQueryMap.Size = new System.Drawing.Size(68, 26);
            this.simpleButtonQueryMap.TabIndex = 14;
            this.simpleButtonQueryMap.Text = "查看";
            this.simpleButtonQueryMap.ToolTip = "地图查看";
            this.simpleButtonQueryMap.Click += new System.EventHandler(this.simpleButtonQueryMap_Click);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Dock = System.Windows.Forms.DockStyle.Right;
            this.label2.Location = new System.Drawing.Point(71, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(2, 26);
            this.label2.TabIndex = 15;
            // 
            // simpleButtonQueryXB
            // 
            this.simpleButtonQueryXB.Dock = System.Windows.Forms.DockStyle.Right;
            this.simpleButtonQueryXB.Image = ((System.Drawing.Image)(resources.GetObject("simpleButtonQueryXB.Image")));
            this.simpleButtonQueryXB.Location = new System.Drawing.Point(73, 6);
            this.simpleButtonQueryXB.Name = "simpleButtonQueryXB";
            this.simpleButtonQueryXB.Size = new System.Drawing.Size(68, 26);
            this.simpleButtonQueryXB.TabIndex = 12;
            this.simpleButtonQueryXB.Text = "小班";
            this.simpleButtonQueryXB.ToolTip = "小班查询";
            this.simpleButtonQueryXB.Click += new System.EventHandler(this.simpleButton7_Click);
            // 
            // label14
            // 
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Dock = System.Windows.Forms.DockStyle.Right;
            this.label14.Location = new System.Drawing.Point(141, 6);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(2, 26);
            this.label14.TabIndex = 13;
            // 
            // simpleButtonEdit
            // 
            this.simpleButtonEdit.Dock = System.Windows.Forms.DockStyle.Right;
            this.simpleButtonEdit.Image = ((System.Drawing.Image)(resources.GetObject("simpleButtonEdit.Image")));
            this.simpleButtonEdit.Location = new System.Drawing.Point(143, 6);
            this.simpleButtonEdit.Name = "simpleButtonEdit";
            this.simpleButtonEdit.Size = new System.Drawing.Size(68, 26);
            this.simpleButtonEdit.TabIndex = 1;
            this.simpleButtonEdit.Text = "修改";
            this.simpleButtonEdit.Click += new System.EventHandler(this.simpleButtonEdit_Click);
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Dock = System.Windows.Forms.DockStyle.Right;
            this.label13.Location = new System.Drawing.Point(211, 6);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(2, 26);
            this.label13.TabIndex = 11;
            // 
            // simpleButtonDelete
            // 
            this.simpleButtonDelete.Dock = System.Windows.Forms.DockStyle.Right;
            this.simpleButtonDelete.Image = ((System.Drawing.Image)(resources.GetObject("simpleButtonDelete.Image")));
            this.simpleButtonDelete.Location = new System.Drawing.Point(213, 6);
            this.simpleButtonDelete.Name = "simpleButtonDelete";
            this.simpleButtonDelete.Size = new System.Drawing.Size(68, 26);
            this.simpleButtonDelete.TabIndex = 0;
            this.simpleButtonDelete.Text = "删除";
            this.simpleButtonDelete.ToolTip = "删除作业设计";
            this.simpleButtonDelete.Click += new System.EventHandler(this.simpleButtonDelete_Click);
            // 
            // labelResultInfo
            // 
            this.labelResultInfo.BackColor = System.Drawing.Color.Transparent;
            this.labelResultInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelResultInfo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelResultInfo.ImageKey = "notebook.png";
            this.labelResultInfo.ImageList = this.imageList3;
            this.labelResultInfo.Location = new System.Drawing.Point(0, 0);
            this.labelResultInfo.Name = "labelResultInfo";
            this.labelResultInfo.Size = new System.Drawing.Size(281, 24);
            this.labelResultInfo.TabIndex = 84;
            this.labelResultInfo.Text = "        作业设计";
            this.labelResultInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // imageList3
            // 
            this.imageList3.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList3.ImageStream")));
            this.imageList3.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList3.Images.SetKeyName(0, "gtk-new.png");
            this.imageList3.Images.SetKeyName(1, "bookmark.png");
            this.imageList3.Images.SetKeyName(2, "notebook.png");
            this.imageList3.Images.SetKeyName(3, "bookmark-star.png");
            this.imageList3.Images.SetKeyName(4, "bookmark-edit.png");
            this.imageList3.Images.SetKeyName(5, "clock_edit.png");
            this.imageList3.Images.SetKeyName(6, "img-portrait-edit.png");
            this.imageList3.Images.SetKeyName(7, "history.png");
            this.imageList3.Images.SetKeyName(8, "world_edit.png");
            this.imageList3.Images.SetKeyName(9, "world3.png");
            this.imageList3.Images.SetKeyName(10, "table_tab_search.png");
            this.imageList3.Images.SetKeyName(11, "Arzo_Icons_012.png");
            this.imageList3.Images.SetKeyName(12, "info_32.png");
            this.imageList3.Images.SetKeyName(13, "clock_32.png");
            this.imageList3.Images.SetKeyName(14, "home_32.png");
            this.imageList3.Images.SetKeyName(15, "folder_32.png");
            this.imageList3.Images.SetKeyName(16, "flag_32.png");
            this.imageList3.Images.SetKeyName(17, "globe_32.png");
            this.imageList3.Images.SetKeyName(18, "search_32.png");
            this.imageList3.Images.SetKeyName(19, "color_swatch.png");
            this.imageList3.Images.SetKeyName(20, "house.png");
            this.imageList3.Images.SetKeyName(21, "images.png");
            this.imageList3.Images.SetKeyName(22, "insert_element.png");
            this.imageList3.Images.SetKeyName(23, "things_digital.png");
            this.imageList3.Images.SetKeyName(24, "time.png");
            this.imageList3.Images.SetKeyName(25, "map_magnify.png");
            this.imageList3.Images.SetKeyName(26, "messenger.png");
            this.imageList3.Images.SetKeyName(27, "orbit.png");
            this.imageList3.Images.SetKeyName(28, "application_edit.png");
            this.imageList3.Images.SetKeyName(29, "application_form_edit.png");
            this.imageList3.Images.SetKeyName(30, "large_tiles.png");
            // 
            // panelList
            // 
            this.panelList.Controls.Add(this.label19);
            this.panelList.Controls.Add(this.groupControl2);
            this.panelList.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelList.Location = new System.Drawing.Point(4, 93);
            this.panelList.Name = "panelList";
            this.panelList.Padding = new System.Windows.Forms.Padding(0, 14, 0, 0);
            this.panelList.Size = new System.Drawing.Size(281, 200);
            this.panelList.TabIndex = 83;
            this.panelList.TabStop = true;
            this.panelList.Visible = false;
            // 
            // label19
            // 
            this.label19.BackColor = System.Drawing.Color.Transparent;
            this.label19.ImageIndex = 10;
            this.label19.ImageList = this.imageList1;
            this.label19.Location = new System.Drawing.Point(7, 3);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(32, 32);
            this.label19.TabIndex = 83;
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupControl2
            // 
            this.groupControl2.Appearance.BackColor = System.Drawing.Color.White;
            this.groupControl2.Appearance.Options.UseBackColor = true;
            this.groupControl2.Controls.Add(this.gridControl1);
            this.groupControl2.Controls.Add(this.labelInfo2);
            this.groupControl2.Controls.Add(this.panel4);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl2.Location = new System.Drawing.Point(0, 14);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Padding = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.groupControl2.Size = new System.Drawing.Size(281, 186);
            this.groupControl2.TabIndex = 83;
            this.groupControl2.Text = "        小班列表";
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(8, 26);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(265, 102);
            this.gridControl1.TabIndex = 81;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.GroupPanelText = "造林小班列表";
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // labelInfo2
            // 
            this.labelInfo2.BackColor = System.Drawing.Color.Transparent;
            this.labelInfo2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.labelInfo2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelInfo2.ImageKey = "flag_32.png";
            this.labelInfo2.ImageList = this.imageList2;
            this.labelInfo2.Location = new System.Drawing.Point(8, 128);
            this.labelInfo2.Name = "labelInfo2";
            this.labelInfo2.Size = new System.Drawing.Size(265, 20);
            this.labelInfo2.TabIndex = 81;
            this.labelInfo2.Text = "     共计0个班块";
            this.labelInfo2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelInfo2.Click += new System.EventHandler(this.label3_Click);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.panel4.Controls.Add(this.simpleButtonInfo);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Controls.Add(this.simpleButtonLocation);
            this.panel4.Controls.Add(this.label17);
            this.panel4.Controls.Add(this.simpleButtonBack);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(8, 148);
            this.panel4.Name = "panel4";
            this.panel4.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.panel4.Size = new System.Drawing.Size(265, 32);
            this.panel4.TabIndex = 82;
            // 
            // simpleButtonInfo
            // 
            this.simpleButtonInfo.Dock = System.Windows.Forms.DockStyle.Right;
            this.simpleButtonInfo.Image = ((System.Drawing.Image)(resources.GetObject("simpleButtonInfo.Image")));
            this.simpleButtonInfo.Location = new System.Drawing.Point(51, 6);
            this.simpleButtonInfo.Name = "simpleButtonInfo";
            this.simpleButtonInfo.Size = new System.Drawing.Size(68, 26);
            this.simpleButtonInfo.TabIndex = 82;
            this.simpleButtonInfo.Text = "信息";
            this.simpleButtonInfo.ToolTip = "属性信息";
            this.simpleButtonInfo.Click += new System.EventHandler(this.simpleButtonInfo_Click);
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Dock = System.Windows.Forms.DockStyle.Right;
            this.label4.Location = new System.Drawing.Point(119, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(5, 26);
            this.label4.TabIndex = 84;
            // 
            // simpleButtonLocation
            // 
            this.simpleButtonLocation.Dock = System.Windows.Forms.DockStyle.Right;
            this.simpleButtonLocation.Image = ((System.Drawing.Image)(resources.GetObject("simpleButtonLocation.Image")));
            this.simpleButtonLocation.Location = new System.Drawing.Point(124, 6);
            this.simpleButtonLocation.Name = "simpleButtonLocation";
            this.simpleButtonLocation.Size = new System.Drawing.Size(68, 26);
            this.simpleButtonLocation.TabIndex = 12;
            this.simpleButtonLocation.Text = "定位";
            this.simpleButtonLocation.Click += new System.EventHandler(this.simpleButtonLocation_Click);
            // 
            // label17
            // 
            this.label17.BackColor = System.Drawing.Color.Transparent;
            this.label17.Dock = System.Windows.Forms.DockStyle.Right;
            this.label17.Location = new System.Drawing.Point(192, 6);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(5, 26);
            this.label17.TabIndex = 14;
            // 
            // simpleButtonBack
            // 
            this.simpleButtonBack.Dock = System.Windows.Forms.DockStyle.Right;
            this.simpleButtonBack.Image = ((System.Drawing.Image)(resources.GetObject("simpleButtonBack.Image")));
            this.simpleButtonBack.Location = new System.Drawing.Point(197, 6);
            this.simpleButtonBack.Name = "simpleButtonBack";
            this.simpleButtonBack.Size = new System.Drawing.Size(68, 26);
            this.simpleButtonBack.TabIndex = 13;
            this.simpleButtonBack.Text = "返回";
            this.simpleButtonBack.Click += new System.EventHandler(this.simpleButton5_Click);
            // 
            // panelEdit
            // 
            this.panelEdit.BackColor = System.Drawing.Color.Transparent;
            this.panelEdit.Controls.Add(this.label16);
            this.panelEdit.Controls.Add(this.groupControl1);
            this.panelEdit.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelEdit.Location = new System.Drawing.Point(4, 293);
            this.panelEdit.Name = "panelEdit";
            this.panelEdit.Padding = new System.Windows.Forms.Padding(0, 14, 0, 5);
            this.panelEdit.Size = new System.Drawing.Size(281, 166);
            this.panelEdit.TabIndex = 16;
            this.panelEdit.Visible = false;
            this.panelEdit.Paint += new System.Windows.Forms.PaintEventHandler(this.panelEdit_Paint);
            // 
            // label16
            // 
            this.label16.BackColor = System.Drawing.Color.Transparent;
            this.label16.ImageIndex = 6;
            this.label16.ImageList = this.imageList1;
            this.label16.Location = new System.Drawing.Point(7, 3);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(32, 32);
            this.label16.TabIndex = 82;
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupControl1
            // 
            this.groupControl1.Appearance.BackColor = System.Drawing.Color.White;
            this.groupControl1.Appearance.Options.UseBackColor = true;
            this.groupControl1.Controls.Add(this.panelControl2);
            this.groupControl1.Controls.Add(this.label10);
            this.groupControl1.Controls.Add(this.comboBoxEdit1);
            this.groupControl1.Controls.Add(this.panel2);
            this.groupControl1.Controls.Add(this.label9);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 14);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Padding = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.groupControl1.Size = new System.Drawing.Size(281, 147);
            this.groupControl1.TabIndex = 81;
            this.groupControl1.Text = "        修改作业设计";
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.textBox2);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(8, 50);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(265, 11);
            this.panelControl2.TabIndex = 7;
            // 
            // textBox2
            // 
            this.textBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox2.Location = new System.Drawing.Point(2, 2);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(261, 7);
            this.textBox2.TabIndex = 0;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label10.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label10.ImageKey = "large_tiles.png";
            this.label10.ImageList = this.imageList3;
            this.label10.Location = new System.Drawing.Point(8, 61);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(265, 28);
            this.label10.TabIndex = 13;
            this.label10.Text = "        设计状态";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label10.Visible = false;
            // 
            // comboBoxEdit1
            // 
            this.comboBoxEdit1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.comboBoxEdit1.Location = new System.Drawing.Point(8, 89);
            this.comboBoxEdit1.Name = "comboBoxEdit1";
            this.comboBoxEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEdit1.Size = new System.Drawing.Size(265, 20);
            this.comboBoxEdit1.TabIndex = 0;
            this.comboBoxEdit1.Visible = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.panel2.Controls.Add(this.simpleButtonEditOK);
            this.panel2.Controls.Add(this.label18);
            this.panel2.Controls.Add(this.simpleButtonEditCancle);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(8, 109);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.panel2.Size = new System.Drawing.Size(265, 32);
            this.panel2.TabIndex = 80;
            // 
            // simpleButtonEditOK
            // 
            this.simpleButtonEditOK.Dock = System.Windows.Forms.DockStyle.Right;
            this.simpleButtonEditOK.Image = ((System.Drawing.Image)(resources.GetObject("simpleButtonEditOK.Image")));
            this.simpleButtonEditOK.Location = new System.Drawing.Point(122, 6);
            this.simpleButtonEditOK.Name = "simpleButtonEditOK";
            this.simpleButtonEditOK.Size = new System.Drawing.Size(68, 26);
            this.simpleButtonEditOK.TabIndex = 1;
            this.simpleButtonEditOK.Text = "确定";
            this.simpleButtonEditOK.Click += new System.EventHandler(this.simpleButtonEditOK_Click);
            // 
            // label18
            // 
            this.label18.BackColor = System.Drawing.Color.Transparent;
            this.label18.Dock = System.Windows.Forms.DockStyle.Right;
            this.label18.Location = new System.Drawing.Point(190, 6);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(7, 26);
            this.label18.TabIndex = 11;
            // 
            // simpleButtonEditCancle
            // 
            this.simpleButtonEditCancle.Dock = System.Windows.Forms.DockStyle.Right;
            this.simpleButtonEditCancle.Image = ((System.Drawing.Image)(resources.GetObject("simpleButtonEditCancle.Image")));
            this.simpleButtonEditCancle.Location = new System.Drawing.Point(197, 6);
            this.simpleButtonEditCancle.Name = "simpleButtonEditCancle";
            this.simpleButtonEditCancle.Size = new System.Drawing.Size(68, 26);
            this.simpleButtonEditCancle.TabIndex = 0;
            this.simpleButtonEditCancle.Text = "取消";
            this.simpleButtonEditCancle.Click += new System.EventHandler(this.simpleButtonEditCancle_Click);
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Dock = System.Windows.Forms.DockStyle.Top;
            this.label9.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label9.ImageKey = "messenger.png";
            this.label9.ImageList = this.imageList3;
            this.label9.Location = new System.Drawing.Point(8, 26);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(265, 24);
            this.label9.TabIndex = 11;
            this.label9.Text = "        设计名称";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // navBarGroupControlContainer6
            // 
            this.navBarGroupControlContainer6.Controls.Add(this.userControlTaskConvert1);
            this.navBarGroupControlContainer6.Name = "navBarGroupControlContainer6";
            this.navBarGroupControlContainer6.Size = new System.Drawing.Size(290, 419);
            this.navBarGroupControlContainer6.TabIndex = 5;
            // 
            // userControlTaskConvert1
            // 
            this.userControlTaskConvert1.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.userControlTaskConvert1.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.userControlTaskConvert1.Appearance.Options.UseBackColor = true;
            this.userControlTaskConvert1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControlTaskConvert1.Location = new System.Drawing.Point(0, 0);
            this.userControlTaskConvert1.Name = "userControlTaskConvert1";
            this.userControlTaskConvert1.Size = new System.Drawing.Size(290, 419);
            this.userControlTaskConvert1.TabIndex = 0;
            // 
            // navBarGroupResult
            // 
            this.navBarGroupResult.Caption = "设计列表";
            this.navBarGroupResult.ControlContainer = this.navBarGroupControlContainer2;
            this.navBarGroupResult.GroupClientHeight = 460;
            this.navBarGroupResult.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.ControlContainer;
            this.navBarGroupResult.LargeImageIndex = 35;
            this.navBarGroupResult.Name = "navBarGroupResult";
            this.navBarGroupResult.ItemChanged += new System.EventHandler(this.navBarGroupResult_ItemChanged);
            // 
            // navBarGroupConvert
            // 
            this.navBarGroupConvert.AppearanceBackground.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.navBarGroupConvert.AppearanceBackground.BackColor2 = System.Drawing.Color.White;
            this.navBarGroupConvert.AppearanceBackground.Options.UseBackColor = true;
            this.navBarGroupConvert.Caption = "年度划转";
            this.navBarGroupConvert.ControlContainer = this.navBarGroupControlContainer6;
            this.navBarGroupConvert.GroupClientHeight = 420;
            this.navBarGroupConvert.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.ControlContainer;
            this.navBarGroupConvert.LargeImageIndex = 45;
            this.navBarGroupConvert.Name = "navBarGroupConvert";
            // 
            // groupControl4
            // 
            this.groupControl4.AppearanceCaption.Image = ((System.Drawing.Image)(resources.GetObject("groupControl4.AppearanceCaption.Image")));
            this.groupControl4.AppearanceCaption.Options.UseImage = true;
            this.groupControl4.ContentImage = ((System.Drawing.Image)(resources.GetObject("groupControl4.ContentImage")));
            this.groupControl4.ContentImageAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.groupControl4.Controls.Add(this.radioGroup1);
            this.groupControl4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl4.Location = new System.Drawing.Point(0, 16);
            this.groupControl4.Name = "groupControl4";
            this.groupControl4.Size = new System.Drawing.Size(382, 64);
            this.groupControl4.TabIndex = 3;
            this.groupControl4.TabStop = true;
            this.groupControl4.Text = "        设计时间";
            // 
            // radioGroup1
            // 
            this.radioGroup1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radioGroup1.Location = new System.Drawing.Point(2, 22);
            this.radioGroup1.Name = "radioGroup1";
            this.radioGroup1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.radioGroup1.Properties.Columns = 3;
            this.radioGroup1.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "2001"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "2002"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "2003")});
            this.radioGroup1.Size = new System.Drawing.Size(378, 40);
            this.radioGroup1.TabIndex = 3;
            // 
            // UserControlQueryDesign
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.Controls.Add(this.navBarControl1);
            this.Name = "UserControlQueryDesign";
            this.Padding = new System.Windows.Forms.Padding(4);
            this.Size = new System.Drawing.Size(300, 590);
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl1)).EndInit();
            this.navBarControl1.ResumeLayout(false);
            this.navBarGroupControlContainer1.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControlDist)).EndInit();
            this.groupControlDist.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tListDist)).EndInit();
            this.panelKind.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControltype)).EndInit();
            this.groupControltype.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tListDesignKind)).EndInit();
            this.panelYear.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl5)).EndInit();
            this.groupControl5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radioGroupYear.Properties)).EndInit();
            this.panel8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControlname)).EndInit();
            this.groupControlname.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            this.panelQuery.ResumeLayout(false);
            this.navBarGroupControlContainer2.ResumeLayout(false);
            this.panelResult.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tListResult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageEdit1)).EndInit();
            this.panelButtons.ResumeLayout(false);
            this.panelList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panelEdit.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit1.Properties)).EndInit();
            this.panel2.ResumeLayout(false);
            this.navBarGroupControlContainer6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl4)).EndInit();
            this.groupControl4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup1.Properties)).EndInit();
            this.ResumeLayout(false);

        }
        public ProjectManager PM
        {
            get
            {
                return DBServiceFactory<ProjectManager>.Service;
            }
        }
        private IList<T_DESIGNKIND_Mid> m_kindCodeLst;
        private IList<T_EDITTASK_ZT_Mid> m_projectLst;
        private void InitialKindList()
        {
            try
            {
                if (this.mKindTable != null)
                {
                    TreeListNode node = null;
                    TreeListNode parentNode = null;
                    TreeListNode node3 = null;
                    TreeListNode node4 = null;
                    this.tListDesignKind.Nodes.Clear();
                    this.tListDesignKind.OptionsView.ShowRoot = true;
                    this.tListDesignKind.SelectImageList = null;
                    this.tListDesignKind.OptionsView.ShowButtons = true;
                    this.tListDesignKind.TreeLineStyle = LineStyle.None;
                    this.tListDesignKind.RowHeight = 20;
                    this.tListDesignKind.OptionsBehavior.AutoPopulateColumns = true;
                  //  DataTable dataTable = TaskManageClass.GetDataTable(this.mDBAccess, "select * from T_DesignKind where ( code like '%0000' and kind='" + this.mKindCode + "') ");
                    m_kindCodeLst = PM.FindTreeByKindCode(mKindCode);
                    string str = "";
                    for (int i = 0; i < m_kindCodeLst.Count; i++)
                    {
                        this.mSelected = true;
                        node3 = this.tListDesignKind.AppendNode(m_kindCodeLst[i].name, node4);
                        node3.SetValue(0, m_kindCodeLst[i].name);
                        node3.Tag = m_kindCodeLst[i].code;
                        node3.ImageIndex = -1;
                        node3.StateImageIndex = 0;
                        node3.SelectImageIndex = -1;
                        node3.ExpandAll();
                     //   str = dataTable.Rows[i]["code"].ToString().Substring(0, 2);
                      //  DataTable table2 = TaskManageClass.GetDataTable(this.mDBAccess, "select * from T_DesignKind where ( code like '" + str + "%' and right(code ,4 )<>'0000' and right(code ,2 )='00' and kind='" + this.mKindCode + "')");
                      //  string str2 = "";
                        IList<T_DESIGNKIND_Mid> secondLst = m_kindCodeLst[i].SubList;
                        for (int j = 0; j < secondLst.Count; j++)
                        {
                            parentNode = this.tListDesignKind.AppendNode(secondLst[j].name, node3);
                            parentNode.ImageIndex = -1;
                            parentNode.StateImageIndex = 0;
                            parentNode.SelectImageIndex = -1;
                            parentNode.SetValue(0, secondLst[j].name);
                            parentNode.Tag = secondLst[j].code;
                            parentNode.Expanded = false;
                          //  str2 = table2.Rows[j]["code"].ToString().Substring(0, 4);
                          //  DataTable table3 = TaskManageClass.GetDataTable(this.mDBAccess, "select * from T_DesignKind where (code like '" + str2 + "%' and right(code ,4 )<>'0000' and right(code ,2 )<>'00' and kind='" + this.mKindCode + "')");
                            IList<T_DESIGNKIND_Mid> thirdLst = secondLst[j].SubList;
                            for (int k = 0; k < thirdLst.Count; k++)
                            {
                                node = this.tListDesignKind.AppendNode(thirdLst[k].name, parentNode);
                                node.ImageIndex = -1;
                                node.StateImageIndex = 0;
                                node.SelectImageIndex = -1;
                                node.SetValue(0, thirdLst[k].name);
                                node.Tag = thirdLst[k].code;
                                node.Expanded = false;
                            }
                        }
                        node3.ExpandAll();
                    }
                    this.tListDesignKind.Selection.Clear();
                    this.tListDesignKind.FocusedNode = null;
                    this.tListDesignKind.Refresh();
                    this.tListDesignKind.OptionsSelection.Reset();
                    this.mSelected = false;
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "QueryAnalysic.UserControlQueryDesign", "InitialKindList", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void InitialList()
        {
            try
            {
                TreeListNode node = null;
                TreeListNode parentNode = null;
                TreeListNode node3 = null;
                TreeListNode node4 = null;
                this.tListDist.ClearNodes();
                this.tListDist.OptionsView.ShowRoot = true;
                this.tListDist.SelectImageList = null;
                this.tListDist.OptionsView.ShowButtons = true;
                this.tListDist.TreeLineStyle = LineStyle.None;
                this.tListDist.RowHeight = 20;
                this.tListDist.OptionsBehavior.AutoPopulateColumns = true;
                this.tListDist.OptionsView.AutoWidth = true;
                if (this.tListDist.Columns.Count == 2)
                {
                    this.tListDist.Columns[1].Visible = false;
                }
                IQueryFilter queryFilter = new QueryFilterClass();
                queryFilter.WhereClause = UtilFactory.GetConfigOpt().GetConfigValue("CityCodeTableWhereStr");
                if (this.m_CityTable.RowCount(queryFilter) == 0)
                {
                    UtilFactory.GetConfigOpt().GetConfigValue("CountyCodeTableFieldName");
                    string configValue = UtilFactory.GetConfigOpt().GetConfigValue("CountyCodeTableFieldCode");
                    IQueryFilter filter2 = new QueryFilterClass();
                    filter2.WhereClause = "CINDEX='103'";
                    ICursor cursor = this.m_CountyTable.Search(filter2, false);
                    IRow row = cursor.NextRow();
                    int index = row.Fields.FindField(configValue);
                    while (row != null)
                    {
                        IQueryFilter filter3 = new QueryFilterClass();
                        filter3.WhereClause = configValue + "='" + row.get_Value(index).ToString() + "' and CINDEX='103'";
                        ICursor cursor2 = this.m_CountyTable.Search(filter3, false);
                        IRow row2 = cursor2.NextRow();
                        int num3 = row2.Fields.FindField(UtilFactory.GetConfigOpt().GetConfigValue("CountyCodeTableFieldCode"));
                        int num4 = row2.Fields.FindField(UtilFactory.GetConfigOpt().GetConfigValue("CountyCodeTableFieldName"));
                        while (row2 != null)
                        {
                            if (row2.get_Value(num3).ToString() == row.get_Value(index).ToString())
                            {
                                node3 = this.tListDist.AppendNode(row2.get_Value(num4).ToString(), node4);
                                node3.SetValue(0, row2.get_Value(num4).ToString());
                                node3.Tag = row2.get_Value(num3).ToString();
                                if (this.mEditKind == "采伐")
                                {
                                    IQueryFilter filter4 = new QueryFilterClass();
                                    filter4.WhereClause = configValue + " like '" + row2.get_Value(num3).ToString() + "%' and CINDEX='104'";
                                    ICursor cursor3 = this.m_TownTable.Search(filter4, true);
                                    for (IRow row3 = cursor3.NextRow(); row3 != null; row3 = cursor3.NextRow())
                                    {
                                        parentNode = this.tListDist.AppendNode(row3.get_Value(num4).ToString(), node3);
                                        parentNode.SetValue(0, row3.get_Value(num4).ToString());
                                        parentNode.Tag = row3.get_Value(num3).ToString();
                                        parentNode.Expanded = false;
                                        if (!this.mIsBatch)
                                        {
                                            IQueryFilter filter5 = new QueryFilterClass();
                                            filter5.WhereClause = configValue + " like '" + row3.get_Value(num3).ToString() + "%' and CINDEX='105'";
                                            ICursor cursor4 = this.m_VillageTable.Search(filter5, false);
                                            for (IRow row4 = cursor4.NextRow(); row4 != null; row4 = cursor4.NextRow())
                                            {
                                                node = this.tListDist.AppendNode(row4.get_Value(num4).ToString(), parentNode);
                                                node.SetValue(0, row4.get_Value(num4).ToString());
                                                node.Tag = row4.get_Value(num3).ToString();
                                                node.Expanded = false;
                                            }
                                        }
                                    }
                                }
                                node3.ExpandAll();
                            }
                            row2 = cursor2.NextRow();
                        }
                        row = cursor.NextRow();
                    }
                }
                else
                {
                    string name = UtilFactory.GetConfigOpt().GetConfigValue("CityCodeTableFieldName");
                    string str3 = UtilFactory.GetConfigOpt().GetConfigValue("CityCodeTableFieldCode");
                    ICursor cursor5 = this.m_CityTable.Search(queryFilter, false);
                    IRow row5 = cursor5.NextRow();
                    int num5 = row5.Fields.FindField(str3);
                    int num6 = row5.Fields.FindField(name);
                    while (row5 != null)
                    {
                        node3 = this.tListDist.AppendNode(row5.get_Value(num6).ToString(), node4);
                        node3.SetValue(0, row5.get_Value(num6).ToString());
                        node3.Tag = row5.get_Value(num5).ToString();
                        this.tListDist.AppendNode("", node3);
                        row5 = cursor5.NextRow();
                    }
                }
                this.tListDist.Selection.Clear();
                this.tListDist.FocusedNode = null;
                this.tListDist.Refresh();
                this.tListDist.OptionsSelection.Reset();
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "QueryAnalysic.UserControlQueryDesign", "InitialList", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void InitialListResult(IList<T_EDITTASK_ZT_Mid> taskList)
        {
            try
            {
                TreeListNode node = null;
                TreeListNode parentNode = null;
                TreeListNode node3 = null;
                this.tListResult.ClearNodes();
                this.tListResult.Columns[0].Width = this.tListResult.Width;
                this.tListResult.Columns[1].Width = 0;
                this.tListResult.OptionsView.ShowRoot = true;
                this.tListResult.SelectImageList = null;
                this.tListResult.OptionsView.ShowButtons = true;
                this.tListResult.TreeLineStyle = LineStyle.None;
                this.tListResult.RowHeight = 20;
                this.tListResult.OptionsBehavior.AutoPopulateColumns = true;
                for (int i = 0; i < taskList.Count; i++)
                {
                    string str;
                    string str2;
                    parentNode = this.tListResult.AppendNode(taskList[i].tablename, node3);
                    parentNode.SetValue(0, taskList[i].tablename);
                    parentNode.Tag = taskList[i].ID;
                    IQueryFilter queryFilter = new QueryFilterClass();
                    queryFilter.WhereClause = "CCODE='" + taskList[i].distcode + "'";
                    ICursor cursor = null;
                    if (taskList[i].distcode.Length == 6)
                    {
                        cursor = this.m_CountyTable.Search(queryFilter, false);
                    }
                    else if (taskList[i].distcode.Length == 9)
                    {
                        cursor = this.m_TownTable.Search(queryFilter, false);
                    }
                    else if (taskList[i].distcode.Length == 12)
                    {
                        cursor = this.m_VillageTable.Search(queryFilter, false);
                    }
                    IRow row = cursor.NextRow();
                    row.Fields.FindField(UtilFactory.GetConfigOpt().GetConfigValue("CountyCodeTableFieldCode"));
                    int index = row.Fields.FindField(UtilFactory.GetConfigOpt().GetConfigValue("CountyCodeTableFieldName"));
                    node = this.tListResult.AppendNode("行政区划", parentNode);
                    node.SetValue(0, "行政区划: " + row.get_Value(index).ToString());
                    node.Tag = taskList[i].distcode;
                    node = this.tListResult.AppendNode(taskList[i].taskstate, parentNode);
                    TaskState2 state = (TaskState2)int.Parse(taskList[i].taskstate);
                    node.SetValue(0, "设计状态: " + this.GetTaskState(state));
                    node.Tag = taskList[i].taskstate;
                    node = this.tListResult.AppendNode(taskList[i].taskyear, parentNode);
                    node.SetValue(0, "年度: " + taskList[i].taskyear + "年");
                    node.Tag = taskList[i].taskyear;
                    node = this.tListResult.AppendNode(taskList[i].createtime, parentNode);
                    node.SetValue(0, "创建时间: " + taskList[i].createtime);
                    node.Tag = taskList[i].createtime;
                    node = this.tListResult.AppendNode(taskList[i].logiccheckstate, parentNode);
                    if (taskList[i].logiccheckstate == "0")
                    {
                        str = "未通过";
                    }
                    else
                    {
                        str = "通过";
                    }
                    node.SetValue(0, "逻辑校验: " + str);
                    node.Tag = taskList[i].logiccheckstate;
                    node = this.tListResult.AppendNode(taskList[i].logiccheckstate, parentNode);
                    if (taskList[i].logiccheckstate == "0")
                    {
                        str2 = "未通过";
                    }
                    else
                    {
                        str2 = "通过";
                    }
                    node.SetValue(0, "图形校验: " + str2);
                    node.Tag = taskList[i].logiccheckstate;
                    int num3 = 0;
                    IQueryFilter filter2 = new QueryFilterClass();
                    filter2.WhereClause = this.mTaskID + " = '" + taskList[i].ID + "'";
                    num3 = this.m_QueryLayer.FeatureClass.FeatureCount(filter2);
                    node = this.tListResult.AppendNode("小班总数", parentNode);
                    node.SetValue(0, "小班总数: " + num3.ToString());
                    node.Tag = num3.ToString();
                    node = this.tListResult.AppendNode("小班总面积", parentNode);
                    if (num3 == 0)
                    {
                        node.SetValue(0, "小班总面积: " + num3);
                        node.Tag = num3.ToString();
                    }
                    else
                    {
                        string name = "";
                        if ((this.mEditKind == "造林") || (this.mEditKind == "征占用"))
                        {
                            name = "MIAN_JI";
                        }
                        else if (this.mEditKind == "采伐")
                        {
                            name = "CFMJ";
                        }
                        IQueryFilter filter = new QueryFilterClass();
                        filter.WhereClause = this.mTaskID + "='" + taskList[i].ID + "'";
                        IFeatureCursor cursor2 = this.m_QueryLayer.FeatureClass.Search(filter, false);
                        IFeature feature = cursor2.NextFeature();
                        double num4 = 0.0;
                        while (feature != null)
                        {
                            int num5 = feature.Fields.FindField(name);
                            try
                            {
                                if ((feature.get_Value(num5) != null) && (feature.get_Value(num5).ToString().Trim() != ""))
                                {
                                    num4 += double.Parse(feature.get_Value(num5).ToString());
                                }
                            }
                            catch (Exception)
                            {
                            }
                            feature = cursor2.NextFeature();
                        }
                        node.SetValue(0, "小班总面积: " + num4);
                        node.Tag = num3.ToString();
                    }
                }
                this.tListResult.Selection.Clear();
                this.tListResult.Refresh();
                this.mQueryList = null;
                if (this.tListResult.Nodes.Count > 0)
                {
                    this.tListResult.Selection.Add(this.tListResult.Nodes[0]);
                    this.simpleButtonQueryMap.Enabled = true;
                    this.simpleButtonQueryXB.Enabled = true;
                    this.simpleButtonSchedule.Enabled = false;
                }
                else
                {
                    this.simpleButtonQueryMap.Enabled = false;
                    this.simpleButtonQueryXB.Enabled = false;
                    this.simpleButtonSchedule.Enabled = false;
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "QueryAnalysic.UserControlQueryDesign", "InitialListResult", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void InitialQueryLayer()
        {
            string str = "";
            if (this.mEditKind == "造林")
            {
                str = "作业设计";
            }
            else if (this.mEditKind == "采伐")
            {
                str = "作业设计";
            }
            else if (this.mEditKind == "征占用")
            {
                str = "项目";
            }
            string configValue = UtilFactory.GetConfigOpt().GetConfigValue(this.mEditKindCode + "GroupName2");
            IGroupLayer pGroupLayer = GISFunFactory.LayerFun.FindLayer(this.mHookHelper.FocusMap as IBasicMap, configValue, true) as IGroupLayer;
            if (pGroupLayer == null)
            {
                GISFunFactory.LayerFun.AddGroupLayer(this.mHookHelper.FocusMap as IBasicMap, null, configValue);
                pGroupLayer = GISFunFactory.LayerFun.FindLayer(this.mHookHelper.FocusMap as IBasicMap, configValue, true) as IGroupLayer;
            }
            else if (this.mEditKind != "征占用")
            {
                this.m_QueryLayer = GISFunFactory.LayerFun.FindLayerInGroupLayer(pGroupLayer, this.mEditKind + str, true) as IFeatureLayer;
            }
            else if (this.mEditKind == "征占用")
            {
                this.m_QueryLayer = GISFunFactory.LayerFun.FindLayerInGroupLayer(pGroupLayer, this.mEditKind + str + "面", true) as IFeatureLayer;
                this.m_QueryLayer2 = GISFunFactory.LayerFun.FindLayerInGroupLayer(pGroupLayer, this.mEditKind + str + "点", true) as IFeatureLayer;
                this.m_QueryLayer3 = GISFunFactory.LayerFun.FindLayerInGroupLayer(pGroupLayer, this.mEditKind + str + "线", true) as IFeatureLayer;
            }
            if (this.m_QueryLayer == null)
            {
                if (this.mEditKind != "征占用")
                {
                    IFeatureClass pFClass = this.mLayerList[this.radioGroupYear.SelectedIndex] as IFeatureClass;
                    this.m_QueryLayer = this.AddLayer2(this.mEditKind + str, pFClass, pGroupLayer) as IFeatureLayer;
                }
                else if (this.mEditKind == "征占用")
                {
                    IFeatureClass class3 = this.mLayerList[this.radioGroupYear.SelectedIndex] as IFeatureClass;
                    this.m_QueryLayer = this.AddLayer2(this.mEditKind + str + "面", class3, pGroupLayer) as IFeatureLayer;
                    class3 = this.mLayerList2[this.radioGroupYear.SelectedIndex] as IFeatureClass;
                    this.m_QueryLayer2 = this.AddLayer2(this.mEditKind + str + "点", class3, pGroupLayer) as IFeatureLayer;
                    class3 = this.mLayerList3[this.radioGroupYear.SelectedIndex] as IFeatureClass;
                    this.m_QueryLayer3 = this.AddLayer2(this.mEditKind + str + "线", class3, pGroupLayer) as IFeatureLayer;
                }
            }
            else
            {
                IFeatureClass class4 = this.mLayerList[this.radioGroupYear.SelectedIndex] as IFeatureClass;
                try
                {
                    if (this.mEditKind != "征占用")
                    {
                        this.m_QueryLayer.FeatureClass = class4;
                    }
                    else if (this.mEditKind == "征占用")
                    {
                        this.m_QueryLayer.FeatureClass = class4;
                        class4 = this.mLayerList2[this.radioGroupYear.SelectedIndex] as IFeatureClass;
                        this.m_QueryLayer2.FeatureClass = class4;
                        class4 = this.mLayerList3[this.radioGroupYear.SelectedIndex] as IFeatureClass;
                        this.m_QueryLayer3.FeatureClass = class4;
                    }
                }
                catch (Exception)
                {
                    this.mHookHelper.FocusMap.DeleteLayer(this.m_QueryLayer);
                    this.m_QueryLayer = null;
                    this.m_QueryLayer = this.AddLayer2(this.mEditKind + str, class4, pGroupLayer) as IFeatureLayer;
                }
            }
        }

        public void InitialValue(object hook, string sEditKind, QueryCommon.UserControlQueryResult pResult, DockPanel pDockPanel)
        {
            try
            {
                this.mHookHelper = new HookHelperClass();
                if (hook != null)
                {
                    this.mHookHelper.Hook = hook;
                }
                this.mEditKind = sEditKind;
                this.mQueryResult = pResult;
                this.mDockPanel = pDockPanel;
                this.simpleButtonQueryXB.Enabled = false;
                this.simpleButtonQueryMap.Enabled = false;
                this.navBarGroupConvert.Visible = false;
                this.simpleButtonDelete.Enabled = false;
                this.simpleButtonEdit.Enabled = false;
                this.panelKind.Width = this.panelYear.Width / 2;
                this.navBarGroupQuery.GroupClientHeight = base.Height - 100;
                this.navBarGroupResult.GroupClientHeight = this.navBarGroupQuery.GroupClientHeight;
                this.tListDist.ClearNodes();
                this.mTaskID = "Task_ID";
                if (this.mEditKind == "征占用")
                {
                    this.mTaskID = "XMBH";
                    this.navBarGroupResult.Caption = "项目列表";
                    this.simpleButtonDelete.ToolTip = "删除征占用";
                    this.labelResultInfo.Text = "        征占用项目";
                    this.groupControl1.Text = "        修改征占用项目";
                    this.labelInfo.Text = "     共计0个作业设计";
                    this.groupControltype.Text = "        林地用途";
                    this.groupControl5.Text = "        设计时间";
                    this.groupControlname.Text = "        征占用项目名称";
                    this.label10.Text = "        项目状态";
                    this.label9.Text = "        项目名称";
                    this.simpleButtonSchedule.Visible = false;
                }
        
                if (this.mEditKind == "造林")
                {
                    this.mKindCode = "1";
                    this.mIsBatch = true;
                }
                else if (this.mEditKind == "采伐")
                {
                    this.mKindCode = "2";
                    this.mIsBatch = false;
                }
                else if (this.mEditKind == "征占用")
                {
                    this.mKindCode = "4";
                    this.mIsBatch = false;
                }
                else
                {
                    this.mKindCode = "";
                }
              //  this.mKindTable = TaskManageClass.GetDataTable(this.mDBAccess, "select * from T_DesignKind where kind='" + this.mKindCode + "'");
                this.InitialKindList();
                this.mKindList = new ArrayList();
                if (((this.mHookHelper != null) && (this.mHookHelper.FocusMap != null)) && (this.mHookHelper.FocusMap.LayerCount != 0))
                {
                    IMap focusMap = this.mHookHelper.FocusMap;
                    this.mFeatureWorkspace = EditTask.EditWorkspace;
                    if (this.mFeatureWorkspace != null)
                    {
                        string configValue = UtilFactory.GetConfigOpt().GetConfigValue("CityCodeTableName");
                        this.m_CityTable = this.mFeatureWorkspace.OpenTable(configValue);
                        if (this.m_CityTable != null)
                        {
                            configValue = UtilFactory.GetConfigOpt().GetConfigValue("CountyCodeTableName");
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
                                        this.InitialList();
                                        this.mRangeList = new ArrayList();
                                        if (this.mEditKind == "造林")
                                        {
                                            this.mEditKindCode = "ZaoLin";
                                        }
                                        else if (this.mEditKind == "采伐")
                                        {
                                            this.mEditKindCode = "CaiFa";
                                        }
                                        else if (this.mEditKind == "征占用")
                                        {
                                            this.mEditKindCode = "ZZY";
                                        }
                                        else
                                        {
                                            this.mEditKindCode = "";
                                        }
                                        string str2 = UtilFactory.GetConfigOpt().GetConfigValue(this.mEditKindCode + "Layer");
                                        string str3 = "";
                                        string str4 = "";
                                        str3 = UtilFactory.GetConfigOpt().GetConfigValue(this.mEditKindCode + "LayerName3");
                                        if ((str3 != "") && str3.Contains(","))
                                        {
                                            str4 = str3.Split(new char[] { ',' })[1];
                                            str3 = str3.Split(new char[] { ',' })[0];
                                        }
                                        UtilFactory.GetConfigOpt().GetConfigValue(this.mEditKindCode + "TableName");
                                        string name = UtilFactory.GetConfigOpt().GetConfigValue(this.mEditKindCode + "Dataset");
                                        UtilFactory.GetConfigOpt().GetConfigValue(this.mEditKindCode + "Dataset2");
                                        IDataset dataset = this.mFeatureWorkspace.OpenFeatureDataset(name);
                                        if (dataset != null)
                                        {
                                            IEnumDataset subsets = dataset.Subsets;
                                            for (dataset = subsets.Next(); dataset != null; dataset = subsets.Next())
                                            {
                                                string[] strArray = dataset.Name.Split(new char[] { '.' });
                                                string str6 = strArray[strArray.Length - 1];
                                                if (str6.Contains(str2) && (str6.Length > str2.Length))
                                                {
                                                    this.m_EditFeatureClass = dataset as IFeatureClass;
                                                }
                                                if (((str3 != "") && str6.Contains(str3)) && (str6.Length > str3.Length))
                                                {
                                                    this.m_EditFeatureClass2 = dataset as IFeatureClass;
                                                }
                                                if (((str4 != "") && str6.Contains(str4)) && (str6.Length > str4.Length))
                                                {
                                                    this.m_EditFeatureClass3 = dataset as IFeatureClass;
                                                }
                                            }
                                        }
                                        this.radioGroupYear.Properties.Items.Clear();
                                        this.mLayerList = new ArrayList();
                                        if (this.mEditKind == "征占用")
                                        {
                                            this.mLayerList2 = new ArrayList();
                                            this.mLayerList3 = new ArrayList();
                                        }
                                        string str7 = UtilFactory.GetConfigOpt().GetConfigValue(this.mEditKindCode + "Layer");
                                        if (this.m_EditFeatureClass != null)
                                        {
                                            string[] strArray2 = (this.m_EditFeatureClass as IDataset).Name.ToString().Split(new char[] { '.' });
                                            string str8 = strArray2[strArray2.Length - 1];
                                            RadioGroupItem item = new RadioGroupItem(null, str8.Replace(str7 + "_", "") + "年");
                                            this.radioGroupYear.Properties.Items.Add(item);
                                            this.radioGroupYear.SelectedIndex = 0;
                                            this.mLayerList.Add(this.m_EditFeatureClass);
                                            if (str3 != "")
                                            {
                                                this.mLayerList2.Add(this.m_EditFeatureClass2);
                                            }
                                            if (str4 != "")
                                            {
                                                this.mLayerList3.Add(this.m_EditFeatureClass3);
                                            }
                                        }
                                        string str9 = UtilFactory.GetConfigOpt().GetConfigValue(this.mEditKindCode + "Dataset2");
                                        str7 = UtilFactory.GetConfigOpt().GetConfigValue(this.mEditKindCode + "Layer2");
                                        try
                                        {
                                            IFeatureDataset dataset3 = this.mFeatureWorkspace.OpenFeatureDataset(str9) as IFeatureDataset;
                                            IEnumDataset dataset4 = dataset3.Subsets;
                                            IDataset dataset5 = dataset4.Next();
                                            IFeatureClass class2 = null;
                                            while (dataset5 != null)
                                            {
                                                if (dataset5.Type == esriDatasetType.esriDTFeatureClass)
                                                {
                                                    class2 = dataset5 as IFeatureClass;
                                                    string[] strArray3 = dataset5.Name.ToString().Split(new char[] { '.' });
                                                    string str10 = strArray3[strArray3.Length - 1];
                                                    if ((str10.Contains(str7) && (str10.Length > str7.Length)) && (!str10.Contains("_Templ") && !str10.Contains("_TEMPL")))
                                                    {
                                                        RadioGroupItem item2 = new RadioGroupItem(null, str10.Substring(str7.Length + 1, (str10.Length - str7.Length) - 1) + "年");
                                                        this.radioGroupYear.Properties.Items.Add(item2);
                                                        this.mLayerList.Add(class2);
                                                    }
                                                    if ((((str3 != "") && str10.Contains(str3)) && ((str10.Length > str3.Length) && !str10.Contains("_Templ"))) && !str10.Contains("_TEMPL"))
                                                    {
                                                        new RadioGroupItem(null, str10.Substring(str3.Length + 1, (str10.Length - str3.Length) - 1) + "年");
                                                        this.mLayerList2.Add(class2);
                                                    }
                                                    if ((((str4 != "") && str10.Contains(str4)) && ((str10.Length > str4.Length) && !str10.Contains("_Templ"))) && !str10.Contains("_TEMPL"))
                                                    {
                                                        new RadioGroupItem(null, str10.Substring(str4.Length + 1, (str10.Length - str4.Length) - 1) + "年");
                                                        this.mLayerList3.Add(class2);
                                                    }
                                                }
                                                dataset5 = dataset4.Next();
                                            }
                                        }
                                        catch (Exception)
                                        {
                                        }
                                        this.tListResult.Nodes.Clear();
                                        this.mRangeList = new ArrayList();
                                        this.mKindList = new ArrayList();
                                        this.InitialQueryLayer();
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "QueryAnalysic.UserControlQueryDesign", "InitialValue", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void InitialXBList()
        {
            try
            {
                this.GetFeatureList();
                this.labelInfo2.Text = "     共计" + this.mQueryList.Count + "个班块";
                this.labelInfo2.Visible = true;
                this.navBarGroupQuery.Expanded = false;
                this.navBarGroupResult.Expanded = true;
                this.mQueryTable = new DataTable();
                DataColumn column = new DataColumn("XH", typeof(string));
                column.Caption = "序号";
                this.mQueryTable.Columns.Add(column);
                column = new DataColumn("ID", typeof(string));
                column.Caption = "编号";
                this.mQueryTable.Columns.Add(column);
                column = new DataColumn("obj", typeof(object));
                column.Caption = "object";
                this.mQueryTable.Columns.Add(column);
                for (int i = 0; i < this.mQueryList.Count; i++)
                {
                    DataRow row = this.mQueryTable.NewRow();
                    IFeature feature = this.mQueryList[i] as IFeature;
                    int index = feature.Fields.FindField(UtilFactory.GetConfigOpt().GetConfigValue(this.mEditKindCode + "FieldName"));
                    row["XH"] = i + 1;
                    row["ID"] = feature.get_Value(index);
                    row["obj"] = feature;
                    this.mQueryTable.Rows.Add(row);
                }
                this.gridControl1.DataSource = null;
                this.gridView1.Columns.Clear();
                this.gridControl1.DataSource = this.mQueryTable;
                this.gridView1.RefreshData();
                this.gridView1.Columns[2].Visible = false;
                this.gridView1.OptionsBehavior.Editable = false;
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "QueryAnalysic.UserControlQueryDesign", "SetTaskEditValue", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
        }

        private void label7_Click(object sender, EventArgs e)
        {
            this.groupControlDist.Enabled = !this.groupControlDist.Enabled;
            this.tListDist.Selection.Clear();
            this.tListDist.Refresh();
            this.tListDist.OptionsSelection.EnableAppearanceFocusedCell = this.groupControlDist.Enabled;
        }

        private void label8_Click(object sender, EventArgs e)
        {
        }

        private void labelKind_Click(object sender, EventArgs e)
        {
            this.groupControltype.Enabled = !this.groupControltype.Enabled;
            this.tListDesignKind.Selection.Clear();
            this.tListDesignKind.Refresh();
            this.mKindList.Clear();
            this.tListDesignKind.OptionsSelection.EnableAppearanceFocusedCell = this.groupControltype.Enabled;
        }

        private void navBarControl1_GroupExpanded(object sender, NavBarGroupEventArgs e)
        {
            if (e.Group == this.navBarGroupQuery)
            {
                if (this.navBarGroupResult.Expanded)
                {
                    this.navBarGroupResult.Expanded = false;
                }
                if (this.navBarGroupConvert.Expanded)
                {
                    this.navBarGroupConvert.Expanded = false;
                }
            }
            if (e.Group == this.navBarGroupResult)
            {
                if (this.navBarGroupQuery.Expanded)
                {
                    this.navBarGroupQuery.Expanded = false;
                }
                if (this.navBarGroupConvert.Expanded)
                {
                    this.navBarGroupConvert.Expanded = false;
                }
            }
            if (e.Group == this.navBarGroupConvert)
            {
                if (this.navBarGroupQuery.Expanded)
                {
                    this.navBarGroupQuery.Expanded = false;
                }
                if (this.navBarGroupResult.Expanded)
                {
                    this.navBarGroupResult.Expanded = false;
                }
            }
        }

        private void navBarGroupQuery_ItemChanged(object sender, EventArgs e)
        {
        }

        private void navBarGroupResult_ItemChanged(object sender, EventArgs e)
        {
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {
        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {
        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {
        }

        private void panelEdit_Paint(object sender, PaintEventArgs e)
        {
        }

        private void RendererLayer(IFeatureLayer featureLayer, bool bUniqueValue, int r, int g, int b, double width, int size, string skind)
        {
            try
            {
                IGeoFeatureLayer layer = (IGeoFeatureLayer) featureLayer;
                ISymbol symbol = null;
                ISymbol symbol2 = null;
                ISimpleFillSymbol symbol3 = new SimpleFillSymbolClass();
                ISimpleLineSymbol symbol4 = new SimpleLineSymbolClass();
                new SimpleMarkerSymbolClass();
                ISimpleFillSymbol symbol5 = new SimpleFillSymbolClass();
                ISimpleLineSymbol symbol6 = new SimpleLineSymbolClass();
                new SimpleMarkerSymbolClass();
                if (featureLayer.FeatureClass.ShapeType == esriGeometryType.esriGeometryPolygon)
                {
                    IRgbColor color = new RgbColorClass();
                    color.NullColor = true;
                    symbol3.Color = color;
                    IRgbColor color2 = new RgbColorClass();
                    color2.Red = r;
                    color2.Blue = b;
                    color2.Green = g;
                    symbol4.Color = color2;
                    symbol4.Width = width;
                    symbol3.Outline = symbol4;
                    symbol = symbol3 as ISymbol;
                    symbol5.Style = esriSimpleFillStyle.esriSFSNull;
                    ISimpleLineSymbol outline = symbol5.Outline as ISimpleLineSymbol;
                    outline.Style = esriSimpleLineStyle.esriSLSDash;
                    outline.Color = color2;
                    outline.Width = width / 2.0;
                    symbol5.Outline = outline;
                    symbol2 = symbol5 as ISymbol;
                }
                else if (featureLayer.FeatureClass.ShapeType == esriGeometryType.esriGeometryPolyline)
                {
                    IRgbColor color3 = new RgbColorClass();
                    color3.Red = r;
                    color3.Blue = b;
                    color3.Green = g;
                    symbol4.Color = color3;
                    symbol4.Width = width;
                    symbol = symbol4 as ISymbol;
                    ISimpleLineSymbol symbol8 = symbol6;
                    symbol8.Style = esriSimpleLineStyle.esriSLSDash;
                    symbol8.Color = color3;
                    symbol8.Width = width / 2.0;
                    symbol6 = symbol8;
                    symbol2 = symbol6 as ISymbol;
                }
                else if (featureLayer.FeatureClass.ShapeType == esriGeometryType.esriGeometryPoint)
                {
                    ISimpleMarkerSymbol symbol9 = new SimpleMarkerSymbolClass();
                    symbol9.Style = esriSimpleMarkerStyle.esriSMSCross;
                    IRgbColor color4 = new RgbColorClass();
                    color4.Red = r;
                    color4.Blue = b;
                    color4.Green = g;
                    symbol9.Color = color4;
                    symbol9.Size = size;
                    symbol = symbol9 as ISymbol;
                    symbol9 = new SimpleMarkerSymbolClass();
                    symbol9.Style = esriSimpleMarkerStyle.esriSMSCross;
                    color4 = new RgbColorClass();
                    color4.Red = r;
                    color4.Blue = b;
                    color4.Green = g;
                    symbol9.Color = color4;
                    symbol9.Size = size / 2;
                    symbol2 = symbol9 as ISymbol;
                }
                if (!bUniqueValue)
                {
                    ISimpleRenderer renderer1 = (ISimpleRenderer) layer.Renderer;
                    ISimpleRenderer renderer = new SimpleRendererClass();
                    renderer.Symbol = symbol;
                    layer.Renderer = renderer as IFeatureRenderer;
                }
                else
                {
                    IFeatureRenderer renderer3 = layer.Renderer;
                    IUniqueValueRenderer renderer2 = new UniqueValueRendererClass();
                    renderer2.FieldCount = 1;
                    renderer2.set_Field(0, this.mTaskID);
                    renderer2.DefaultSymbol = symbol2;
                    renderer2.UseDefaultSymbol = true;
                    renderer2.DefaultLabel = "其它" + skind;
                    renderer2.AddValue(this.tListResult.Selection[0].Tag.ToString(), "", symbol);
                    renderer2.set_Label(this.tListResult.Selection[0].Tag.ToString(), this.tListResult.Selection[0].GetDisplayText(0));
                    renderer2.set_Description(this.tListResult.Selection[0].Tag.ToString(), this.tListResult.Selection[0].GetDisplayText(0));
                    renderer2.DefaultLabel = "其它" + skind + " ";
                    layer.Renderer = renderer2 as IFeatureRenderer;
                    layer.DisplayAnnotation = true;
                }
                IAnnotateLayerPropertiesCollection annotationProperties = layer.AnnotationProperties;
                if (annotationProperties == null)
                {
                    annotationProperties = new AnnotateLayerPropertiesCollectionClass();
                    layer.AnnotationProperties = annotationProperties;
                }
                else
                {
                    annotationProperties.Clear();
                }
                ILineLabelPosition position = new LineLabelPositionClass();
                position.Parallel = false;
                position.Perpendicular = true;
                ILineLabelPlacementPriorities priorities = new LineLabelPlacementPrioritiesClass();
                IBasicOverposterLayerProperties properties2 = new BasicOverposterLayerPropertiesClass();
                properties2.FeatureType = esriBasicOverposterFeatureType.esriOverposterPolyline;
                properties2.LineLabelPlacementPriorities = priorities;
                properties2.LineLabelPosition = position;
                properties2.LabelWeight = esriBasicOverposterWeight.esriHighWeight;
                ILabelEngineLayerProperties properties3 = new LabelEngineLayerPropertiesClass();
                properties3.BasicOverposterLayerProperties = properties2;
                properties3.Expression = "[" + featureLayer.DisplayField + "]";
                IAnnotateLayerProperties properties4 = properties3 as IAnnotateLayerProperties;
                properties4.AnnotationMinimumScale = 35000.0;
                ITextSymbol symbol10 = new TextSymbolClass();
                symbol10.Size = 12.0;
                IColor color5 = symbol10.Color;
                stdole.IFontDisp font = symbol10.Font;
                font.Bold = true;
                font.Name = "宋体";
                font.Size = 12M;
                symbol10.Font = font;
                IRgbColor color6 = new RgbColorClass();
                color6.Red = r;
                color6.Blue = b;
                color6.Green = g;
                color5 = color6;
                symbol10.Color = color5;
                properties3.Symbol = symbol10;
                IAnnotateLayerProperties item = properties3 as IAnnotateLayerProperties;
                annotationProperties.Add(item);
                layer.DisplayAnnotation = true;
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "QueryAnalysic.UserControlQueryDesign", "RendererLayer", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void repositoryItemImageEdit1_Click(object sender, EventArgs e)
        {
            if (this.mNode.Tag != null)
            {
                IFeature tag = this.mNode.Tag as IFeature;
                IActiveView activeView = this.mHookHelper.ActiveView;
                IEnvelope envelope = tag.Shape.Envelope;
                envelope.Expand(1.2, 1.2, true);
                activeView.FullExtent = envelope;
                activeView.Refresh();
            }
        }

        public void SetConvert(bool flag)
        {
            this.navBarGroupConvert.Visible = flag;
            this.navBarGroupQuery.Expanded = false;
            this.navBarGroupResult.Expanded = false;
            this.navBarGroupConvert.Expanded = flag;
            if (flag)
            {
                this.userControlTaskConvert1.InitialValue(this.mHookHelper.Hook, this.mEditKind);
            }
        }

        public void SetEdit(bool flag)
        {
            if (flag)
            {
                if (this.tListResult.Nodes.Count > 0)
                {
                    this.simpleButtonEdit.Enabled = flag;
                    this.simpleButtonDelete.Enabled = flag;
                }
            }
            else
            {
                this.simpleButtonEdit.Enabled = flag;
                this.simpleButtonDelete.Enabled = flag;
            }
            this.navBarGroupQuery.Expanded = false;
            this.navBarGroupResult.Expanded = flag;
            this.navBarGroupConvert.Expanded = false;
            this.simpleButtonDelete.Visible = true;
            this.simpleButtonEdit.Visible = true;
        }

        public void SetQuery(bool flag)
        {
            this.simpleButtonQueryXB.Enabled = flag;
            this.simpleButtonQueryMap.Enabled = flag;
            this.navBarGroupQuery.Expanded = flag;
            this.navBarGroupResult.Expanded = false;
            this.navBarGroupConvert.Expanded = false;
            this.navBarGroupQuery.Visible = flag;
            this.navBarGroupResult.Visible = flag;
            this.simpleButtonDelete.Visible = false;
            this.simpleButtonEdit.Visible = false;
        }

        private void SetTaskEditValue(string taskid)
        {
            try
            {
               T_EDITTASK_ZT_Mid mid= PM.TaskService.Find(Convert.ToInt32(taskid));
             //   DataRow row = TaskManageClass.GetDataTable(this.mDBAccess, "T_EditTask_ZT", "*", "edittime desc", "id =" + taskid, false).Rows[0];
               EditTask.KindCode = mid.taskkind;
               EditTask.TaskName = mid.taskname;
               EditTask.DistCode = mid.distcode;
               EditTask.TaskState = (TaskState2)int.Parse(mid.taskstate);
               EditTask.TaskYear = mid.taskyear;
               EditTask.CreateTime = mid.createtime;
               EditTask.EditTime = mid.edittime;
               EditTask.DatasetName = mid.datasetname;
               EditTask.TableName = mid.tablename;
               EditTask.LayerName = mid.layername;
               EditTask.TaskID = mid.ID;
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "QueryAnalysic.UserControlQueryDesign", "SetTaskEditValue", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            this.simpleButtonQueryXB.Enabled = true;
            this.panelList.Visible = false;
            this.mDockPanel.Visibility = DockVisibility.Hidden;
        }

        private void simpleButton7_Click(object sender, EventArgs e)
        {
            this.panelList.Visible = true;
            this.simpleButtonQueryXB.Enabled = false;
            this.InitialXBList();
        }

        private void simpleButtonDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if ((this.tListResult.Selection.Count != 0) && this.tListResult.Selection[0].HasChildren)
                {
                    string taskid = this.tListResult.Selection[0].Tag.ToString();
                    //string sCmdText = "Delete from T_EditTask_ZT where ID= " + taskid;
                   // this.mDBAccess.ExecuteScalar(sCmdText);
                    PM.TaskService.Delete(Convert.ToInt32(taskid));
                    this.DeleteEditLayerFeature(taskid);
                    string str3 = "作业设计";
                    if (this.mEditKind == "征占用")
                    {
                        str3 = "项目";
                    }
                 //  m_projectLst = TaskManageClass.GetDataTable(this.mDBAccess, "select * from T_EditTask_ZT  where " + this.GetQueryStr2());
                    m_projectLst = PM.TaskService.FindBySql(this.GetQueryStr2());
                    if (m_projectLst.Count > 0)
                    {
                        this.labelInfo.Text = string.Concat(new object[] { "      查询结果：找到", m_projectLst.Count, "个", str3 });
                        this.labelInfo.Visible = true;
                        this.InitialListResult(m_projectLst);
                    }
                    else
                    {
                        this.labelInfo.Text = "      查询结果：没有找到符合条件的" + str3;
                        this.labelInfo.Visible = true;
                        this.InitialListResult(m_projectLst);
                    }
                    if (this.tListResult.Nodes.Count > 0)
                    {
                        this.simpleButtonEdit.Enabled = true;
                        this.simpleButtonDelete.Enabled = true;
                    }
                    else
                    {
                        this.simpleButtonEdit.Enabled = false;
                        this.simpleButtonDelete.Enabled = false;
                    }
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "QueryAnalysic.UserControlQueryDesign", "simpleButtonDelete_Click", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void simpleButtonEdit_Click(object sender, EventArgs e)
        {
            this.panelEdit.Visible = true;
            this.panelButtons.Visible = false;
            this.tListResult.Enabled = false;
        }

        private void simpleButtonEditCancle_Click(object sender, EventArgs e)
        {
            this.panelEdit.Visible = false;
            this.panelButtons.Visible = true;
            this.tListResult.Enabled = true;
        }

        private void simpleButtonEditOK_Click(object sender, EventArgs e)
        {
            this.tListResult.Enabled = true;
            if ((this.tListResult.Selection.Count != 0) && this.tListResult.Selection[0].HasChildren)
            {
              //  string sCmdText = "update T_EditTask_ZT  set taskname='" + this.textBox2.Text + "' where ID= " + this.tListResult.Selection[0].Tag.ToString();
               // this.mDBAccess.ExecuteScalar(sCmdText);
                PM.EditTaskName(Convert.ToInt32(this.tListResult.Selection[0].Tag), this.textBox2.Text.Trim());
                this.panelEdit.Visible = false;
                this.panelButtons.Visible = true;
                this.tListResult.Enabled = true;
             //   DataTable dataTable = TaskManageClass.GetDataTable(this.mDBAccess, "select * from T_EditTask_ZT  where " + this.GetQueryStr2());
                m_projectLst = PM.TaskService.FindBySql(GetQueryStr2());
                if (m_projectLst.Count > 0)
                {
                    string str2 = "作业设计";
                    if (this.mEditKind == "征占用")
                    {
                        str2 = "项目";
                    }
                    this.labelInfo.Text = string.Concat(new object[] { "      查询结果：找到", m_projectLst.Count, "个", str2 });
                    this.labelInfo.Visible = true;
                    this.InitialListResult(m_projectLst);
                }
            }
        }

        private void simpleButtonInfo_Click(object sender, EventArgs e)
        {
            this.mQueryResult.InitialQueryInfo(this.mHookHelper, this.m_QueryLayer, this.mQueryList, this.m_QueryTable, "", null, null);
            this.mDockPanel.Visibility = DockVisibility.Visible;
        }

        private void simpleButtonLocation_Click(object sender, EventArgs e)
        {
            if ((this.gridView1.FocusedRowHandle != -1) && (this.mQueryTable.Rows.Count != 0))
            {
                DataRow row = this.mQueryTable.Rows[this.gridView1.FocusedRowHandle];
                IFeature pFeature = row["obj"] as IFeature;
                GISFunFactory.FeatureFun.ZoomToFeature(this.mHookHelper.FocusMap, pFeature);
                (this.mHookHelper.Hook as IMapControl2).FlashShape(pFeature.Shape, 1, 300, null);
            }
        }

        private void simpleButtonQuery_Click(object sender, EventArgs e)
        {
            try
            {
                string str = "";
                if (this.mEditKind == "造林")
                {
                    str = "作业设计";
                }
                else if (this.mEditKind == "采伐")
                {
                    str = "作业设计";
                }
                else if (this.mEditKind == "征占用")
                {
                    str = "项目";
                }
               // DataTable dataTable = TaskManageClass.GetDataTable(this.mDBAccess, "select * from T_EditTask_ZT where " + this.GetQueryStr2());
                m_projectLst = PM.TaskService.FindBySql(this.GetQueryStr2());
                if (m_projectLst.Count > 0)
                {
                    this.labelInfo.Text = string.Concat(new object[] { "      查询结果：找到", m_projectLst.Count, "个", str });
                    this.labelInfo.Visible = true;
                    this.InitialListResult(m_projectLst);
                    this.simpleButtonQueryMap.Enabled = true;
                }
                else
                {
                    this.labelInfo.Text = "      查询结果：没有找到符合条件的" + str;
                    this.labelInfo.Visible = true;
                    this.InitialListResult(m_projectLst);
                    this.simpleButtonQueryMap.Enabled = false;
                }
                this.navBarGroupQuery.Expanded = false;
                this.navBarGroupResult.Expanded = true;
                string str2 = "";
                if (this.radioGroupYear.SelectedIndex != -1)
                {
                    str2 = this.radioGroupYear.Properties.Items[this.radioGroupYear.SelectedIndex].Description.Replace("年", "");
                }
                if (str2 != "")
                {
                    this.InitialQueryLayer();
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "QueryAnalysic.UserControlQueryDesign", "ButtonQuery_Click", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void simpleButtonQueryMap_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.m_QueryLayer != null)
                {
                    string str = "";
                    string skind = "";
                    if (this.mEditKind == "造林")
                    {
                        str = "ZaoLin";
                        skind = "作业设计";
                    }
                    else if (this.mEditKind == "采伐")
                    {
                        str = "CaiFa";
                        skind = "作业设计";
                    }
                    else if (this.mEditKind == "征占用")
                    {
                        str = "ZZY";
                        skind = "项目";
                    }
                    else
                    {
                        str = "";
                    }
                    this.m_QueryLayer.Visible = true;
                    this.m_QueryLayer.DisplayField = "XI_BAN";
                    if (this.m_QueryLayer2 != null)
                    {
                        this.m_QueryLayer2.DisplayField = "XI_BAN";
                        this.m_QueryLayer2.Visible = true;
                    }
                    if (this.m_QueryLayer3 != null)
                    {
                        this.m_QueryLayer3.Visible = true;
                    }
                    string configValue = UtilFactory.GetConfigOpt().GetConfigValue(str + "GroupName2");
                    IGroupLayer pGroupLayer = GISFunFactory.LayerFun.FindLayer(this.mHookHelper.FocusMap as IBasicMap, configValue, true) as IGroupLayer;
                    pGroupLayer.Visible = true;
                    if (GISFunFactory.LayerFun.FindLayerInGroupLayer(pGroupLayer, this.m_QueryLayer.Name, true) == null)
                    {
                        pGroupLayer.Add(this.m_QueryLayer);
                    }
                    IGeoFeatureLayer queryLayer = (IGeoFeatureLayer) this.m_QueryLayer;
                    if (this.tListResult.Selection.Count == 0)
                    {
                        this.RendererLayer(this.m_QueryLayer, false, 0xff, 0, 0, 1.2, 10, skind);
                    }
                    else if (this.tListResult.Selection[0].Tag != null)
                    {
                        this.RendererLayer(this.m_QueryLayer, true, 0xff, 0, 0, 1.2, 10, skind);
                    }
                    if (GISFunFactory.LayerFun.FindLayerInGroupLayer(pGroupLayer, this.m_QueryLayer2.Name, true) == null)
                    {
                        pGroupLayer.Add(this.m_QueryLayer2);
                    }
                    IGeoFeatureLayer layer4 = (IGeoFeatureLayer) this.m_QueryLayer2;
                    if (this.tListResult.Selection.Count == 0)
                    {
                        this.RendererLayer(this.m_QueryLayer2, false, 0xff, 0, 0, 1.2, 10, skind);
                    }
                    else if (this.tListResult.Selection[0].Tag != null)
                    {
                        this.RendererLayer(this.m_QueryLayer2, true, 0xff, 0, 0, 1.2, 10, skind);
                    }
                    if (GISFunFactory.LayerFun.FindLayerInGroupLayer(pGroupLayer, this.m_QueryLayer3.Name, true) == null)
                    {
                        pGroupLayer.Add(this.m_QueryLayer3);
                    }
                    IGeoFeatureLayer layer5 = (IGeoFeatureLayer) this.m_QueryLayer3;
                    if (this.tListResult.Selection.Count == 0)
                    {
                        this.RendererLayer(this.m_QueryLayer3, false, 0xff, 0, 0, 1.2, 10, skind);
                    }
                    else if (this.tListResult.Selection[0].Tag != null)
                    {
                        this.RendererLayer(this.m_QueryLayer3, true, 0xff, 0, 0, 1.2, 10, skind);
                    }
                    IEnvelope areaOfInterest = null;
                    if (this.mQueryList == null)
                    {
                        IDataset dataset = this.m_QueryLayer as IDataset;
                        IGeoDataset dataset2 = dataset as IGeoDataset;
                        dataset2.Extent.Expand(1.25, 1.25, true);
                        areaOfInterest = this.m_QueryLayer.AreaOfInterest;
                        areaOfInterest.Expand(1.25, 1.25, true);
                    }
                    if (this.mQueryList != null)
                    {
                        if (this.mQueryList.Count > 0)
                        {
                            for (int i = 0; i < this.mQueryList.Count; i++)
                            {
                                IFeature feature = this.mQueryList[i] as IFeature;
                                IEnvelope envelope = feature.Shape.Envelope;
                                if (areaOfInterest == null)
                                {
                                    areaOfInterest = envelope;
                                }
                                else
                                {
                                    if (areaOfInterest.XMin > envelope.XMin)
                                    {
                                        areaOfInterest.XMin = envelope.XMin;
                                    }
                                    if (areaOfInterest.YMin > envelope.YMin)
                                    {
                                        areaOfInterest.YMin = envelope.YMin;
                                    }
                                    if (areaOfInterest.XMax < envelope.XMin)
                                    {
                                        areaOfInterest.XMax = envelope.XMax;
                                    }
                                    if (areaOfInterest.YMax < envelope.YMax)
                                    {
                                        areaOfInterest.YMax = envelope.YMax;
                                    }
                                }
                            }
                        }
                        else
                        {
                            areaOfInterest = this.m_QueryLayer.AreaOfInterest;
                            areaOfInterest.Expand(1.25, 1.25, true);
                        }
                    }
                    else
                    {
                        areaOfInterest = this.m_QueryLayer.AreaOfInterest;
                        areaOfInterest.Expand(1.25, 1.25, true);
                    }
                    this.mHookHelper.ActiveView.Extent = areaOfInterest;
                    this.mHookHelper.ActiveView.Refresh();
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "QueryAnalysic.UserControlQueryDesign", "simpleButtonQueryMap_Click", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void simpleButtonReset_Click(object sender, EventArgs e)
        {
            this.radioGroupYear.SelectedIndex = 0;
            this.tListDesignKind.Selection.Clear();
            this.tListDesignKind.FocusedNode = null;
            this.tListDist.Selection.Clear();
            this.tListDist.FocusedNode = null;
            this.textBoxNane.Text = "";
            this.mKindList.Clear();
            this.mRangeList.Clear();
        }

        private void simpleButtonSchedule_Click(object sender, EventArgs e)
        {
            string kindCode = EditTask.KindCode;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
        }

        private void tListDesignKind_MouseClick(object sender, MouseEventArgs e)
        {
            if (this.tListDesignKind.Selection.Count > 0)
            {
                this.mKindList.Clear();
                this.mKindList.Add(this.tListDesignKind.Selection[0].Tag);
            }
        }

        private void tListDist_BeforeExpand(object sender, BeforeExpandEventArgs e)
        {
            if ((e.Node.Tag != null) && (!e.Node.HasChildren || (e.Node.Nodes.Count <= 1)))
            {
                string scode = e.Node.Tag.ToString();
                if (scode.Length == 4)
                {
                    this.AddDistCounty(scode, e.Node);
                }
                else if (scode.Length == 6)
                {
                    this.AddDistTown(scode, e.Node);
                }
                else if (scode.Length == 9)
                {
                    this.AddDistVillage(scode, e.Node);
                }
            }
        }

        private void tListDist_MouseClick(object sender, MouseEventArgs e)
        {
            if (this.tListDist.Selection.Count > 0)
            {
                this.mRangeList.Clear();
                this.mRangeList.Add(this.tListDist.Selection[0].Tag);
            }
        }

        private void tListResult_CustomNodeCellEdit(object sender, GetCustomNodeCellEditEventArgs e)
        {
            if (e.Column.Name == "treeListColumn2")
            {
                e.RepositoryItem = this.repositoryItemImageEdit1;
                this.mNode = e.Node;
            }
        }

        private void tListResult_MouseClick(object sender, MouseEventArgs e)
        {
            if (this.tListResult.Selection.Count != 0)
            {
                if (this.tListResult.Selection[0].HasChildren)
                {
                    this.textBox2.Text = this.tListResult.Selection[0].GetDisplayText(0);
                    this.SetTaskEditValue(this.tListResult.Selection[0].Tag.ToString());
                    this.GetFeatureList();
                    if (this.panelList.Visible)
                    {
                        this.InitialXBList();
                    }
                    this.simpleButtonQueryMap.Enabled = true;
                    this.simpleButtonQueryXB.Enabled = true;
                    this.simpleButtonSchedule.Enabled = true;
                    this.simpleButtonDelete.Enabled = true;
                    this.simpleButtonEdit.Enabled = true;
                }
                else
                {
                    this.simpleButtonQueryMap.Enabled = false;
                    this.simpleButtonQueryXB.Enabled = false;
                    this.textBox2.Text = "";
                    this.simpleButtonSchedule.Enabled = false;
                    this.simpleButtonDelete.Enabled = false;
                    this.simpleButtonEdit.Enabled = false;
                }
            }
        }
    }
}

