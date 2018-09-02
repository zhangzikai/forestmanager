namespace QueryAnalysic
{
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

    public class UserControlQueryHZ : UserControlBase1
    {
        private SimpleButton ButtonFind;
        private ComboBoxEdit comboBoxB1;
        private ComboBoxEdit comboBoxB2;
        private ComboBoxEdit comboBoxB3;
        private ComboBoxEdit comboBoxB4;
        private ComboBoxEdit comboBoxB5;
        private ComboBoxEdit comboBoxB6;
        private ComboBoxEdit comboBoxB7;
        private ComboBoxEdit comboBoxB8;
        private ComboBoxEdit comboBoxCounty;
        private ComboBoxEdit comboBoxL1;
        private ComboBoxEdit comboBoxL2;
        private ComboBoxEdit comboBoxLinban;
        private ComboBoxEdit comboBoxTown;
        private ComboBoxEdit comboBoxVillage;
        private ComboBoxEdit comboBoxXiaoban;
        private ComboBoxEdit comboBoxXiban;
        private IContainer components;
        private DateEdit dateEdit1;
        private DateEdit dateEdit2;
        private GroupControl groupControlDist;
        private GroupControl groupControlResult;
        private Label label1;
        private Label label10;
        private Label label12;
        private Label label14;
        private Label label15;
        private Label label16;
        private Label label17;
        private Label label18;
        private Label label2;
        private Label label20;
        private Label label21;
        private Label label22;
        private Label label23;
        private Label label24;
        private Label label25;
        private Label label26;
        private Label label27;
        private Label label28;
        private Label label3;
        private Label label30;
        private Label label31;
        private Label label32;
        private Label label38;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label labelinfo;
        public Label labelLocation;
        private const string mClassName = "QueryAnalysic.UserControlQueryHZ";
      
        private DockPanel mDockPanel;
        private IFeatureLayer mEditLayer;
        private DataTable mEditTable;
        private ErrorOpt mErrOpt = UtilFactory.GetErrorOpt();
        private ArrayList mFeatureList;
        private IHookHelper mHookHelper;
        private IMap mMap;
        private ArrayList mNameList;
        private ArrayList mQueryList;
        private QueryCommon.UserControlQueryResult mQueryResult;
        private string mSubSysName = UtilFactory.GetConfigOpt().GetSystemName();
        private ITable mTable;
        private Panel panel1;
        private Panel panel10;
        private Panel panel11;
        private Panel panel12;
        private Panel panel13;
        private Panel panel14;
        private Panel panel18;
        private Panel panel19;
        private Panel panel2;
        private Panel panel20;
        private Panel panel21;
        private Panel panel22;
        private Panel panel23;
        private Panel panel24;
        private Panel panel25;
        private Panel panel26;
        private Panel panel27;
        private Panel panel28;
        private Panel panel3;
        private Panel panel30;
        private Panel panel31;
        private Panel panel32;
        private Panel panel33;
        private Panel panel34;
        private Panel panel35;
        private Panel panel4;
        private Panel panel5;
        private Panel panel6;
        private Panel panel7;
        private Panel panel8;
        private Panel panel9;
        private Panel panelbasic;
        private Panel panelDistLocation;
        private Panel panelMore;
        private RepositoryItemImageEdit repositoryItemImageEdit1;
        private RepositoryItemPopupContainerEdit repositoryItemPopupContainerEdit3;
        private SimpleButton simpleButtonBack;
        private SimpleButton simpleButtonInfo;
        private SimpleButton simpleButtonMore;
        private SimpleButton simpleButtonReset;
        private SimpleButton simpleButtonSelect;
        private SpinEdit spinEditB6;
        private SpinEdit spinEditB66;
        private SpinEdit spinEditL3;
        private SpinEdit spinEditL33;
        private SpinEdit spinEditL4;
        private SpinEdit spinEditL44;
        private SpinEdit spinEditL5;
        private SpinEdit spinEditL55;
        private SpinEdit spinEditL6;
        private SpinEdit spinEditL66;
        private string sTableName = "";
        private TreeList treeList;
        private TreeListColumn treeListColumn1;
        private TreeListColumn treeListColumn2;
        private XtraTabControl xtraTabControl1;
        private XtraTabPage xtraTabPage1;
        private XtraTabPage xtraTabPage2;

        public UserControlQueryHZ()
        {
            this.InitializeComponent();
        }

        private void ButtonFind_Click(object sender, EventArgs e)
        {
            this.DoFind();
            this.groupControlResult.Dock = DockStyle.Fill;
            this.groupControlResult.Visible = true;
            this.groupControlResult.BringToFront();
        }

        private void comboBoxBase_TextChanged(object sender, EventArgs e)
        {
            try
            {
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
                        ArrayList tag = this.comboBoxTown.Tag as ArrayList;
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
                        ArrayList list2 = this.comboBoxVillage.Tag as ArrayList;
                        if (rowArray != null)
                        {
                            this.SetDist(rowArray[edit.SelectedIndex - 1]["code"].ToString(), list2[0] as DataTable, this.comboBoxVillage);
                        }
                        else
                        {
                            this.SetDist(table.Rows[edit.SelectedIndex - 1]["code"].ToString(), list2[0] as DataTable, this.comboBoxVillage);
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
                        ArrayList list3 = this.comboBoxVillage.Tag as ArrayList;
                        if (rowArray != null)
                        {
                            this.SetDist(rowArray[edit.SelectedIndex - 1]["code"].ToString(), list3[0] as DataTable, this.comboBoxLinban);
                        }
                        else
                        {
                            this.SetDist(table.Rows[edit.SelectedIndex - 1]["code"].ToString(), list3[0] as DataTable, this.comboBoxLinban);
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
                        ArrayList list4 = this.comboBoxLinban.Tag as ArrayList;
                        if (rowArray != null)
                        {
                            this.SetDist(rowArray[this.comboBoxVillage.SelectedIndex - 1]["code"].ToString(), list4[0] as DataTable, this.comboBoxXiaoban);
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
                        ArrayList list5 = this.comboBoxXiaoban.Tag as ArrayList;
                        if (rowArray != null)
                        {
                            this.SetDist(rowArray[this.comboBoxVillage.SelectedIndex - 1]["code"].ToString(), list5[0] as DataTable, this.comboBoxXiban);
                        }
                        else
                        {
                            this.SetDist(table.Rows[edit.SelectedIndex - 1]["code"].ToString(), null, this.comboBoxXiban);
                        }
                    }
                }
                else
                {
                    edit.Name.Contains("Xiban");
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

        private void DoFind()
        {
            try
            {
                string str = "";
                this.treeList.Nodes.Clear();
                string[] arr = UtilFactory.GetConfigOpt().GetConfigValue("FireFieldNameD").Split(new char[] { ',' });
                DataTable table = (this.comboBoxCounty.Tag as ArrayList)[0] as DataTable;
                if (((this.comboBoxCounty.SelectedIndex == 0) && (this.comboBoxTown.SelectedIndex == 0)) && (this.comboBoxVillage.SelectedIndex == 0))
                {
                    str = "";
                    if ((this.comboBoxLinban.SelectedIndex > 0) || ((this.comboBoxLinban.Text != "") && (this.comboBoxLinban.Text != "--")))
                    {
                        if (str != "")
                        {
                            str = str + " and " + arr[3] + "='" + this.comboBoxLinban.Text + "'";
                        }
                        else
                        {
                            str = arr[3] + "='" + this.comboBoxLinban.Text + "'";
                        }
                    }
                    if ((this.comboBoxXiaoban.SelectedIndex > 0) || ((this.comboBoxXiaoban.Text != "") && (this.comboBoxXiaoban.Text != "--")))
                    {
                        if (str != "")
                        {
                            str = str + " and " + arr[4] + "='" + this.comboBoxXiaoban.Text + "'";
                        }
                        else
                        {
                            str = arr[4] + "='" + this.comboBoxXiaoban.Text + "'";
                        }
                    }
                    if ((this.comboBoxXiban.SelectedIndex > 0) || ((this.comboBoxXiban.Text != "") && (this.comboBoxXiban.Text != "--")))
                    {
                        if (str != "")
                        {
                            str = str + " and " + arr[5] + "='" + this.comboBoxXiban.Text + "'";
                        }
                        else
                        {
                            str = arr[5] + "='" + this.comboBoxXiban.Text + "'";
                        }
                    }
                }
                else
                {
                    if (this.comboBoxCounty.SelectedIndex > 0)
                    {
                        str = string.Concat(new object[] { arr[0], "='", table.Rows[this.comboBoxCounty.SelectedIndex - 1]["code"], "'" });
                    }
                    object obj1 = (this.comboBoxTown.Tag as ArrayList)[0];
                    if (this.comboBoxTown.SelectedIndex > 0)
                    {
                        DataRow[] rowArray = (this.comboBoxTown.Tag as ArrayList)[1] as DataRow[];
                        if (this.comboBoxTown.SelectedIndex > 0)
                        {
                            str = string.Concat(new object[] { str, " and ", arr[1], "='", rowArray[this.comboBoxTown.SelectedIndex - 1]["code"], "'" });
                        }
                        object obj2 = (this.comboBoxVillage.Tag as ArrayList)[0];
                        if (this.comboBoxVillage.SelectedIndex > 0)
                        {
                            DataRow[] rowArray2 = (this.comboBoxVillage.Tag as ArrayList)[1] as DataRow[];
                            str = string.Concat(new object[] { str, " and ", arr[2], "='", rowArray2[this.comboBoxVillage.SelectedIndex - 1]["code"], "'" });
                            object obj3 = (this.comboBoxLinban.Tag as ArrayList)[0];
                            if (this.comboBoxLinban.SelectedIndex > 0)
                            {
                                object obj4 = (this.comboBoxLinban.Tag as ArrayList)[1];
                                str = str + " and " + arr[3] + "='" + this.comboBoxLinban.Text + "'";
                                if (this.comboBoxXiaoban.SelectedIndex > 0)
                                {
                                    str = str + " and " + arr[4] + "='" + this.comboBoxXiaoban.Text + "'";
                                    if (this.comboBoxXiban.SelectedIndex > 0)
                                    {
                                        str = str + " and " + arr[5] + "='" + this.comboBoxXiban.Text + "'";
                                    }
                                }
                            }
                        }
                    }
                }
                string str2 = "";
                string configValue = UtilFactory.GetConfigOpt().GetConfigValue("FireFieldTime");
                if ((configValue != "") && ((this.dateEdit1.Text != "") || (this.dateEdit2.Text != "")))
                {
                    string str4 = "";
                    if (UtilFactory.GetConfigOpt().GetConfigValue("MapDBkey") == "Local")
                    {
                        str4 = " date ";
                    }
                    else if (UtilFactory.GetConfigOpt().GetConfigValue("MapDBkey") == "SqlServer")
                    {
                        str4 = "";
                    }
                    string str5 = "";
                    if (this.dateEdit1.Text != "")
                    {
                        str5 = DateTime.Parse(this.dateEdit1.Text).ToString("yyyy-MM-dd HH:mm:ss");
                        str2 = configValue + ">= " + str4 + "'" + str5 + "'";
                    }
                    if (this.dateEdit2.Text != "")
                    {
                        str5 = DateTime.Parse(this.dateEdit2.Text).ToString("yyyy-MM-dd 23:59:59");
                        if (str2 == "")
                        {
                            str2 = configValue + "<= " + str4 + "'" + str5 + "'";
                        }
                        else
                        {
                            str2 = str2 + " and " + configValue + "<= " + str4 + "'" + str5 + "'";
                        }
                    }
                    string str6 = "";
                    if (str2 != "")
                    {
                        ITable table2 = EditTask.EditWorkspace.OpenTable(EditTask.TableName);
                        IQueryFilter queryFilter = new QueryFilterClass();
                        queryFilter.WhereClause = str2;
                        ICursor cursor = table2.Search(queryFilter, false);
                        IRow row = cursor.NextRow();
                        string name = UtilFactory.GetConfigOpt().GetConfigValue("FireTableFieldName");
                        while (row != null)
                        {
                            int index = row.Fields.FindField(name);
                            if (row.get_Value(index).ToString() != "")
                            {
                                if (str6 != "")
                                {
                                    str6 = string.Concat(new object[] { str6, " or ", name, " = ", row.get_Value(index) });
                                }
                                else
                                {
                                    str6 = string.Concat(new object[] { name, " = '", row.get_Value(index), "'" });
                                }
                            }
                            row = cursor.NextRow();
                        }
                    }
                    if (str6 != "")
                    {
                        if (str != "")
                        {
                            str = str + " and " + str6;
                        }
                        else
                        {
                            str = str6;
                        }
                    }
                }
                if (this.panelMore.Visible)
                {
                    ArrayList list = new ArrayList();
                    list.Add(this.comboBoxB1);
                    list.Add(this.comboBoxB2);
                    list.Add(this.comboBoxB3);
                    list.Add(this.comboBoxB4);
                    list.Add(this.comboBoxB5);
                    list.Add(this.comboBoxB6);
                    list.Add(this.comboBoxB7);
                    list.Add(this.comboBoxB8);
                    arr = UtilFactory.GetConfigOpt().GetConfigValue("FireFieldNameB").Split(new char[] { ',' });
                    string whereString = this.GetWhereString(list, arr);
                    if (whereString != "")
                    {
                        if (str != "")
                        {
                            str = str + " and " + whereString;
                        }
                        else
                        {
                            str = whereString;
                        }
                    }
                    list.Clear();
                    list.Add(this.comboBoxL1);
                    list.Add(this.comboBoxL2);
                    list.Add("int," + this.spinEditL3.Text + "," + this.spinEditL33.Text);
                    list.Add("int," + this.spinEditL4.Text + "," + this.spinEditL44.Text);
                    list.Add("int," + this.spinEditL5.Text + "," + this.spinEditL55.Text);
                    list.Add("int," + this.spinEditL6.Text + "," + this.spinEditL66.Text);
                    arr = UtilFactory.GetConfigOpt().GetConfigValue("FireFieldNameL").Split(new char[] { ',' });
                    whereString = this.GetWhereString(list, arr);
                    if (whereString != "")
                    {
                        if (str != "")
                        {
                            str = str + " and " + whereString;
                        }
                        else
                        {
                            str = whereString;
                        }
                    }
                }
                QueryFilter filter2 = new QueryFilterClass();
                filter2.WhereClause = str;
                string[] strArray2 = "CUN,LIN_BAN,XIAO_BAN".Split(new char[] { ',' });
                bool flag = true;
                for (int i = 0; i < strArray2.Length; i++)
                {
                    if (this.mEditLayer.FeatureClass.Fields.FindField(strArray2[i]) < 0)
                    {
                        flag = false;
                    }
                }
                if (flag)
                {
                    IQueryFilterDefinition definition = (IQueryFilterDefinition) filter2;
                    definition.PostfixClause = "ORDER BY CUN,LIN_BAN,XIAO_BAN";
                }
                IFeatureCursor cursor2 = this.mEditLayer.FeatureClass.Search(filter2, false);
                IFeature pFeature = cursor2.NextFeature();
                this.treeList.Nodes.Clear();
                this.treeList.Columns[0].Width = this.treeList.Width - 20;
                this.treeList.Columns[1].Width = 0x10;
                TreeListNode node = null;
                TreeListNode parentNode = null;
                this.mNameList = new ArrayList();
                new ArrayList();
                this.mQueryList = new ArrayList();
                int num4 = 0;
                while (pFeature != null)
                {
                    string xBName = this.GetXBName(pFeature);
                    this.mNameList.Add(xBName);
                    node = this.treeList.AppendNode(xBName, parentNode);
                    node.SetValue(0, xBName);
                    node.Tag = pFeature;
                    node.ImageIndex = -1;
                    node.StateImageIndex = -1;
                    node.SelectImageIndex = -1;
                    node.ExpandAll();
                    this.mQueryList.Add(pFeature);
                    num4++;
                    if (num4 == 0x7d0)
                    {
                        goto Label_0CD1;
                    }
                    pFeature = cursor2.NextFeature();
                }
                if (num4 == 0)
                {
                    this.labelinfo.Text = "      未找到符合条件的小班";
                    this.labelinfo.Visible = true;
                }
                else
                {
                    this.labelinfo.Text = "      找到 " + num4 + " 个小班";
                    this.labelinfo.Visible = true;
                }
                return;
            Label_0CD1:
                this.labelinfo.Text = "      请缩小查询范围，找到 大于" + num4 + " 个小班";
                this.labelinfo.Visible = true;
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "QueryAnalysic.UserControlQueryHZ", "DoFind", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private string GetDistName(string scode, bool all)
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
                    if (all)
                    {
                        str = table.Select("code='" + scode.Substring(0, 6) + "'")[0]["name"].ToString() + table2.Select("code='" + scode.Substring(0, 9) + "'")[0]["name"].ToString();
                    }
                    else
                    {
                        str = table2.Select("code='" + scode.Substring(0, 9) + "'")[0]["name"].ToString();
                    }
                }
                else if (scode.Length == 12)
                {
                    if (all)
                    {
                        str = table.Select("code='" + scode.Substring(0, 6) + "'")[0]["name"].ToString() + table2.Select("code='" + scode.Substring(0, 9) + "'")[0]["name"].ToString() + table3.Select("code='" + scode.Substring(0, 12) + "'")[0]["name"].ToString();
                    }
                    else
                    {
                        str = table3.Select("code='" + scode.Substring(0, 12) + "'")[0]["name"].ToString();
                    }
                }
                else
                {
                    int length = scode.Length;
                }
                return str.Trim();
            }
            catch (Exception)
            {
                return "";
            }
        }

        private string GetWhereString(ArrayList list, string[] arr)
        {
            string str = "";
            try
            {
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i] is ComboBoxEdit)
                    {
                        ComboBoxEdit edit = list[i] as ComboBoxEdit;
                        ArrayList tag = edit.Tag as ArrayList;
                        if (tag != null)
                        {
                            DataTable table = tag[0] as DataTable;
                            if (edit.SelectedIndex > 0)
                            {
                                if (str != "")
                                {
                                    str = string.Concat(new object[] { str, " and ", tag[1], "='", table.Rows[edit.SelectedIndex - 1]["code"], "'" });
                                }
                                else
                                {
                                    str = string.Concat(new object[] { tag[1], "='", table.Rows[edit.SelectedIndex - 1]["code"], "'" });
                                }
                            }
                        }
                    }
                    else if (list[i] is string)
                    {
                        string[] strArray = (list[i] as string).Split(new char[] { ',' });
                        string str2 = "";
                        if (strArray[0] == "str")
                        {
                            str2 = "'";
                        }
                        if (strArray.Length == 2)
                        {
                            if ((strArray[1].Trim() != "") && (strArray[1].Trim() != "0"))
                            {
                                if (str != "")
                                {
                                    str = str + " and " + arr[i] + "=" + str2 + strArray[0] + str2;
                                }
                                else
                                {
                                    str = arr[i] + "=" + str2 + strArray[0] + str2;
                                }
                            }
                        }
                        else if (strArray.Length == 3)
                        {
                            if (strArray[0] == "date")
                            {
                                string str3 = "";
                                if (strArray[1].Trim() != "")
                                {
                                    str3 = arr[i] + ">='" + DateTime.Parse(strArray[1].Trim()).ToString("yyyyMMdd") + "'";
                                }
                                if (strArray[2].Trim() != "")
                                {
                                    if (str3 == "")
                                    {
                                        str3 = arr[i] + "<='" + DateTime.Parse(strArray[2].Trim()).ToString("yyyyMMdd") + "'";
                                    }
                                    else
                                    {
                                        str3 = str3 + " and " + arr[i] + "<='" + DateTime.Parse(strArray[2].Trim()).ToString("yyyyMMdd") + "'";
                                    }
                                }
                                if (str != "")
                                {
                                    str = str + " and " + str3;
                                }
                                else
                                {
                                    str = str3;
                                }
                            }
                            else if (((strArray[2].Trim() != "") || (strArray[1].Trim() != "")) && ((strArray[2].Trim() != "0") || (strArray[1].Trim() != "0")))
                            {
                                if (str != "")
                                {
                                    str = str + " and " + arr[i] + ">=" + str2 + strArray[1] + str2 + " and " + arr[i] + "<=" + str2 + strArray[2] + str2;
                                }
                                else
                                {
                                    str = arr[i] + ">=" + strArray[1] + str2 + " and " + arr[i] + "<=" + str2 + strArray[2] + str2;
                                }
                            }
                        }
                    }
                }
                return str;
            }
            catch (Exception)
            {
                return str;
            }
        }

        private string GetXBName(IFeature pFeature)
        {
            try
            {
                string[] strArray = UtilFactory.GetConfigOpt().GetConfigValue("FireFieldNameD").Split(new char[] { ',' });
                string str = "";
                for (int i = 0; i < strArray.Length; i++)
                {
                    int index = pFeature.Fields.FindField(strArray[i]);
                    if (index > -1)
                    {
                        if (pFeature.get_Value(index).ToString().Length == 6)
                        {
                            if (pFeature.get_Value(index).ToString().Trim() != "")
                            {
                                str = str + this.GetDistName(pFeature.get_Value(index).ToString(), false);
                            }
                        }
                        else if (pFeature.get_Value(index).ToString().Length == 9)
                        {
                            if (pFeature.get_Value(index).ToString().Trim() != "")
                            {
                                str = str + this.GetDistName(pFeature.get_Value(index).ToString(), false);
                            }
                        }
                        else if (pFeature.get_Value(index).ToString().Length == 12)
                        {
                            if (pFeature.get_Value(index).ToString().Trim() != "")
                            {
                                str = str + this.GetDistName(pFeature.get_Value(index).ToString(), false);
                            }
                        }
                        else if ((pFeature.get_Value(index).ToString().Length == 4) && (i == 3))
                        {
                            if (pFeature.get_Value(index).ToString().Trim() != "")
                            {
                                str = str + pFeature.get_Value(index) + "林班";
                            }
                        }
                        else if ((pFeature.get_Value(index).ToString().Length == 4) && (i == 4))
                        {
                            if (pFeature.get_Value(index).ToString().Trim() != "")
                            {
                                str = str + pFeature.get_Value(index) + "小班";
                            }
                        }
                        else if ((pFeature.get_Value(index).ToString().Length <= 10) && (i == 5))
                        {
                            if (pFeature.get_Value(index).ToString().Trim() != "")
                            {
                                str = str + pFeature.get_Value(index) + "细班";
                            }
                        }
                        else if (pFeature.get_Value(index).ToString().Trim() != "")
                        {
                            string aliasName = pFeature.Fields.get_Field(index).AliasName;
                            if (pFeature.Fields.get_Field(index).AliasName.Contains("小班"))
                            {
                                aliasName = "小班";
                            }
                            str = str + pFeature.get_Value(index) + aliasName;
                        }
                    }
                }
                if (str.Trim() == "")
                {
                    str = pFeature.Class.OIDFieldName + pFeature.OID.ToString();
                }
                return str.Trim();
            }
            catch (Exception)
            {
                return "";
            }
        }

        private void InitialCombox(string[] arr, ArrayList list)
        {
            try
            {
                for (int i = 0; i < list.Count; i++)
                {
                    ComboBoxEdit edit = list[i] as ComboBoxEdit;
                    edit.Properties.Items.Clear();
                    edit.Properties.Items.Add("--");
                    int index = this.mEditLayer.FeatureClass.Fields.FindField(arr[i]);
                    if (index > -1)
                    {
                        ICodedValueDomain domain = this.mEditLayer.FeatureClass.Fields.get_Field(index).Domain as ICodedValueDomain;
                        DataTable table = new DataTable();
                        DataColumn column = new DataColumn("code", typeof(string));
                        table.Columns.Add(column);
                        column = new DataColumn("name", typeof(string));
                        table.Columns.Add(column);
                        for (int j = 0; j < domain.CodeCount; j++)
                        {
                            edit.Properties.Items.Add(domain.get_Name(j));
                            DataRow row = table.NewRow();
                            row["code"] = domain.get_Value(j);
                            row["name"] = domain.get_Name(j);
                            table.Rows.Add(row);
                        }
                        if (edit.Properties.Items.Count > 1)
                        {
                            edit.SelectedIndex = 0;
                            ArrayList list2 = new ArrayList();
                            list2.Add(table);
                            list2.Add(arr[i]);
                            edit.Tag = list2;
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "QueryAnalysic.UserControlQueryHZ", "InitialCombox", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void InitialDicCom()
        {
            try
            {
                ArrayList list = new ArrayList();
                list.Add(this.comboBoxB1);
                list.Add(this.comboBoxB2);
                list.Add(this.comboBoxB3);
                list.Add(this.comboBoxB4);
                list.Add(this.comboBoxB5);
                list.Add(this.comboBoxB6);
                list.Add(this.comboBoxB7);
                list.Add(this.comboBoxB8);
                string[] arr = UtilFactory.GetConfigOpt().GetConfigValue("FireFieldNameB").Split(new char[] { ',' });
                this.InitialCombox(arr, list);
                list = new ArrayList();
                list.Add(this.comboBoxL1);
                list.Add(this.comboBoxL2);
                this.spinEditL3.Value = 0M;
                this.spinEditL33.Value = 0M;
                this.spinEditL4.Value = 0M;
                this.spinEditL44.Value = 0M;
                this.spinEditL5.Value = 0M;
                this.spinEditL55.Value = 0M;
                this.spinEditL6.Value = 0M;
                this.spinEditL66.Value = 0M;
                arr = UtilFactory.GetConfigOpt().GetConfigValue("FireFieldNameL").Split(new char[] { ',' });
                this.InitialCombox(arr, list);
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "QueryAnalysic.UserControlQueryHZ", "InitialDicCom", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void InitialDist()
        {
            try
            {
                IFeatureWorkspace editWorkspace = EditTask.EditWorkspace;
                IWorkspace workspace2 = editWorkspace as IWorkspace;
                UtilFactory.GetConfigOpt().GetConfigValue("FireFieldDist").Split(new char[] { ',' });
                string[] strArray = "County,Town,Village".Split(new char[] { ',' });
                ArrayList list = new ArrayList();
                list.Add(this.comboBoxCounty);
                list.Add(this.comboBoxTown);
                list.Add(this.comboBoxVillage);
                for (int i = 0; i < strArray.Length; i++)
                {
                    ComboBoxEdit edit = list[i] as ComboBoxEdit;
                    edit.Properties.Items.Clear();
                    edit.Properties.Items.Add("--");
                    string configValue = UtilFactory.GetConfigOpt().GetConfigValue(strArray[i] + "CodeTableName");
                    ITable table2 = editWorkspace.OpenTable(configValue);
                    string name = UtilFactory.GetConfigOpt().GetConfigValue(strArray[i] + "CodeTableFieldName");
                    string str3 = UtilFactory.GetConfigOpt().GetConfigValue(strArray[i] + "CodeTableFieldCode");
                    IQueryFilter queryFilter = new QueryFilterClass();
                    queryFilter.WhereClause = UtilFactory.GetConfigOpt().GetConfigValue(strArray[i] + "CodeTableWhereStr");
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
                        ArrayList list2 = new ArrayList();
                        list2.Add(table);
                        edit.Tag = list2;
                        edit.SelectedIndex = 0;
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
                this.mErrOpt.ErrorOperate(this.mSubSysName, "QueryAnalysic.UserControlQueryHZ", "InitializeGISControls", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void InitializeComponent()
        {
            this.groupControlResult = new DevExpress.XtraEditors.GroupControl();
            this.treeList = new DevExpress.XtraTreeList.TreeList();
            this.treeListColumn1 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn2 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.repositoryItemPopupContainerEdit3 = new DevExpress.XtraEditors.Repository.RepositoryItemPopupContainerEdit();
            this.repositoryItemImageEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemImageEdit();
            this.labelinfo = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.simpleButtonSelect = new DevExpress.XtraEditors.SimpleButton();
            this.panel13 = new System.Windows.Forms.Panel();
            this.simpleButtonInfo = new DevExpress.XtraEditors.SimpleButton();
            this.panel34 = new System.Windows.Forms.Panel();
            this.simpleButtonBack = new DevExpress.XtraEditors.SimpleButton();
            this.label3 = new System.Windows.Forms.Label();
            this.groupControlDist = new DevExpress.XtraEditors.GroupControl();
            this.panel2 = new System.Windows.Forms.Panel();
            this.simpleButtonReset = new DevExpress.XtraEditors.SimpleButton();
            this.panel33 = new System.Windows.Forms.Panel();
            this.simpleButtonMore = new DevExpress.XtraEditors.SimpleButton();
            this.panel32 = new System.Windows.Forms.Panel();
            this.ButtonFind = new DevExpress.XtraEditors.SimpleButton();
            this.panelMore = new System.Windows.Forms.Panel();
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
            this.panel28 = new System.Windows.Forms.Panel();
            this.spinEditL66 = new DevExpress.XtraEditors.SpinEdit();
            this.label38 = new System.Windows.Forms.Label();
            this.spinEditL6 = new DevExpress.XtraEditors.SpinEdit();
            this.label28 = new System.Windows.Forms.Label();
            this.panel27 = new System.Windows.Forms.Panel();
            this.spinEditL55 = new DevExpress.XtraEditors.SpinEdit();
            this.label25 = new System.Windows.Forms.Label();
            this.spinEditL5 = new DevExpress.XtraEditors.SpinEdit();
            this.label27 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.spinEditL44 = new DevExpress.XtraEditors.SpinEdit();
            this.label4 = new System.Windows.Forms.Label();
            this.spinEditL4 = new DevExpress.XtraEditors.SpinEdit();
            this.label5 = new System.Windows.Forms.Label();
            this.panel21 = new System.Windows.Forms.Panel();
            this.spinEditL33 = new DevExpress.XtraEditors.SpinEdit();
            this.label18 = new System.Windows.Forms.Label();
            this.spinEditL3 = new DevExpress.XtraEditors.SpinEdit();
            this.label17 = new System.Windows.Forms.Label();
            this.panel26 = new System.Windows.Forms.Panel();
            this.comboBoxL2 = new DevExpress.XtraEditors.ComboBoxEdit();
            this.label26 = new System.Windows.Forms.Label();
            this.panel20 = new System.Windows.Forms.Panel();
            this.comboBoxL1 = new DevExpress.XtraEditors.ComboBoxEdit();
            this.label16 = new System.Windows.Forms.Label();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.panel22 = new System.Windows.Forms.Panel();
            this.spinEditB66 = new DevExpress.XtraEditors.SpinEdit();
            this.label12 = new System.Windows.Forms.Label();
            this.spinEditB6 = new DevExpress.XtraEditors.SpinEdit();
            this.label21 = new System.Windows.Forms.Label();
            this.panel23 = new System.Windows.Forms.Panel();
            this.comboBoxB8 = new DevExpress.XtraEditors.ComboBoxEdit();
            this.label22 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.comboBoxB7 = new DevExpress.XtraEditors.ComboBoxEdit();
            this.label20 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.comboBoxB6 = new DevExpress.XtraEditors.ComboBoxEdit();
            this.label6 = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            this.comboBoxB5 = new DevExpress.XtraEditors.ComboBoxEdit();
            this.label10 = new System.Windows.Forms.Label();
            this.panel24 = new System.Windows.Forms.Panel();
            this.comboBoxB4 = new DevExpress.XtraEditors.ComboBoxEdit();
            this.label23 = new System.Windows.Forms.Label();
            this.panel19 = new System.Windows.Forms.Panel();
            this.comboBoxB3 = new DevExpress.XtraEditors.ComboBoxEdit();
            this.label15 = new System.Windows.Forms.Label();
            this.panel25 = new System.Windows.Forms.Panel();
            this.comboBoxB2 = new DevExpress.XtraEditors.ComboBoxEdit();
            this.label24 = new System.Windows.Forms.Label();
            this.panel18 = new System.Windows.Forms.Panel();
            this.comboBoxB1 = new DevExpress.XtraEditors.ComboBoxEdit();
            this.label14 = new System.Windows.Forms.Label();
            this.panelbasic = new System.Windows.Forms.Panel();
            this.panelDistLocation = new System.Windows.Forms.Panel();
            this.panel10 = new System.Windows.Forms.Panel();
            this.panel35 = new System.Windows.Forms.Panel();
            this.dateEdit2 = new DevExpress.XtraEditors.DateEdit();
            this.label31 = new System.Windows.Forms.Label();
            this.dateEdit1 = new DevExpress.XtraEditors.DateEdit();
            this.panel31 = new System.Windows.Forms.Panel();
            this.comboBoxXiban = new DevExpress.XtraEditors.ComboBoxEdit();
            this.panel30 = new System.Windows.Forms.Panel();
            this.comboBoxXiaoban = new DevExpress.XtraEditors.ComboBoxEdit();
            this.panel6 = new System.Windows.Forms.Panel();
            this.comboBoxLinban = new DevExpress.XtraEditors.ComboBoxEdit();
            this.panel1 = new System.Windows.Forms.Panel();
            this.comboBoxVillage = new DevExpress.XtraEditors.ComboBoxEdit();
            this.panel12 = new System.Windows.Forms.Panel();
            this.comboBoxTown = new DevExpress.XtraEditors.ComboBoxEdit();
            this.panel11 = new System.Windows.Forms.Panel();
            this.comboBoxCounty = new DevExpress.XtraEditors.ComboBoxEdit();
            this.panel14 = new System.Windows.Forms.Panel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.label30 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.labelLocation = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlResult)).BeginInit();
            this.groupControlResult.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPopupContainerEdit3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageEdit1)).BeginInit();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlDist)).BeginInit();
            this.groupControlDist.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panelMore.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.xtraTabPage2.SuspendLayout();
            this.panel28.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditL66.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditL6.Properties)).BeginInit();
            this.panel27.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditL55.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditL5.Properties)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditL44.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditL4.Properties)).BeginInit();
            this.panel21.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditL33.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditL3.Properties)).BeginInit();
            this.panel26.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxL2.Properties)).BeginInit();
            this.panel20.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxL1.Properties)).BeginInit();
            this.xtraTabPage1.SuspendLayout();
            this.panel22.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditB66.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditB6.Properties)).BeginInit();
            this.panel23.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxB8.Properties)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxB7.Properties)).BeginInit();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxB6.Properties)).BeginInit();
            this.panel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxB5.Properties)).BeginInit();
            this.panel24.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxB4.Properties)).BeginInit();
            this.panel19.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxB3.Properties)).BeginInit();
            this.panel25.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxB2.Properties)).BeginInit();
            this.panel18.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxB1.Properties)).BeginInit();
            this.panelbasic.SuspendLayout();
            this.panelDistLocation.SuspendLayout();
            this.panel10.SuspendLayout();
            this.panel35.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit2.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxXiban.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxXiaoban.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxLinban.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxVillage.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxTown.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxCounty.Properties)).BeginInit();
            this.panel9.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupControlResult
            // 
            this.groupControlResult.Controls.Add(this.treeList);
            this.groupControlResult.Controls.Add(this.labelinfo);
            this.groupControlResult.Controls.Add(this.panel5);
            this.groupControlResult.Controls.Add(this.label3);
            this.groupControlResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControlResult.Location = new System.Drawing.Point(0, 463);
            this.groupControlResult.Name = "groupControlResult";
            this.groupControlResult.Padding = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.groupControlResult.Size = new System.Drawing.Size(248, 189);
            this.groupControlResult.TabIndex = 110;
            this.groupControlResult.Text = "查询结果";
            // 
            // treeList
            // 
            this.treeList.Appearance.FocusedCell.BackColor = System.Drawing.Color.DodgerBlue;
            this.treeList.Appearance.FocusedCell.BackColor2 = System.Drawing.Color.PaleTurquoise;
            this.treeList.Appearance.FocusedCell.BorderColor = System.Drawing.Color.Blue;
            this.treeList.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Yellow;
            this.treeList.Appearance.FocusedCell.Options.UseBackColor = true;
            this.treeList.Appearance.FocusedCell.Options.UseBorderColor = true;
            this.treeList.Appearance.FocusedCell.Options.UseForeColor = true;
            this.treeList.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.treeListColumn1,
            this.treeListColumn2});
            this.treeList.Cursor = System.Windows.Forms.Cursors.Hand;
            this.treeList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeList.Location = new System.Drawing.Point(8, 48);
            this.treeList.Name = "treeList";
            this.treeList.BeginUnboundLoad();
            this.treeList.AppendNode(new object[] {
            "XX县XX乡XX村XXX林班XXX小班",
            ""}, -1, -1, -1, -1);
            this.treeList.AppendNode(new object[] {
            "XX县XX乡XX村XXX林班XXX小班",
            ""}, -1);
            this.treeList.EndUnboundLoad();
            this.treeList.OptionsBehavior.Editable = false;
            this.treeList.OptionsSelection.EnableAppearanceFocusedRow = false;
            this.treeList.OptionsView.ShowColumns = false;
            this.treeList.OptionsView.ShowHorzLines = false;
            this.treeList.OptionsView.ShowIndicator = false;
            this.treeList.OptionsView.ShowRoot = false;
            this.treeList.OptionsView.ShowVertLines = false;
            this.treeList.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemPopupContainerEdit3,
            this.repositoryItemImageEdit1});
            this.treeList.Size = new System.Drawing.Size(232, 83);
            this.treeList.TabIndex = 99;
            this.treeList.TreeLevelWidth = 12;
            this.treeList.DoubleClick += new System.EventHandler(this.treeList_DoubleClick);
            this.treeList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.treeList_MouseDoubleClick);
            // 
            // treeListColumn1
            // 
            this.treeListColumn1.Caption = "宗地号";
            this.treeListColumn1.FieldName = "name";
            this.treeListColumn1.MinWidth = 37;
            this.treeListColumn1.Name = "treeListColumn1";
            this.treeListColumn1.Visible = true;
            this.treeListColumn1.VisibleIndex = 0;
            this.treeListColumn1.Width = 186;
            // 
            // treeListColumn2
            // 
            this.treeListColumn2.Caption = "定位";
            this.treeListColumn2.FieldName = "value";
            this.treeListColumn2.ImageIndex = 17;
            this.treeListColumn2.Name = "treeListColumn2";
            this.treeListColumn2.Width = 36;
            // 
            // repositoryItemPopupContainerEdit3
            // 
            this.repositoryItemPopupContainerEdit3.AutoHeight = false;
            this.repositoryItemPopupContainerEdit3.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemPopupContainerEdit3.Name = "repositoryItemPopupContainerEdit3";
            // 
            // repositoryItemImageEdit1
            // 
            this.repositoryItemImageEdit1.Appearance.Options.UseImage = true;
            this.repositoryItemImageEdit1.AutoHeight = false;
            this.repositoryItemImageEdit1.Name = "repositoryItemImageEdit1";
            this.repositoryItemImageEdit1.ShowDropDown = DevExpress.XtraEditors.Controls.ShowDropDown.Never;
            this.repositoryItemImageEdit1.ShowIcon = false;
            this.repositoryItemImageEdit1.ShowMenu = false;
            this.repositoryItemImageEdit1.ShowPopupShadow = false;
            // 
            // labelinfo
            // 
            this.labelinfo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.labelinfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.labelinfo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelinfo.Location = new System.Drawing.Point(8, 131);
            this.labelinfo.Name = "labelinfo";
            this.labelinfo.Size = new System.Drawing.Size(232, 26);
            this.labelinfo.TabIndex = 102;
            this.labelinfo.Text = "      查找结果";
            this.labelinfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelinfo.Visible = false;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.simpleButtonSelect);
            this.panel5.Controls.Add(this.panel13);
            this.panel5.Controls.Add(this.simpleButtonInfo);
            this.panel5.Controls.Add(this.panel34);
            this.panel5.Controls.Add(this.simpleButtonBack);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(8, 157);
            this.panel5.Name = "panel5";
            this.panel5.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.panel5.Size = new System.Drawing.Size(232, 30);
            this.panel5.TabIndex = 101;
            // 
            // simpleButtonSelect
            // 
            this.simpleButtonSelect.Cursor = System.Windows.Forms.Cursors.Hand;
            this.simpleButtonSelect.Dock = System.Windows.Forms.DockStyle.Right;
            this.simpleButtonSelect.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.simpleButtonSelect.Location = new System.Drawing.Point(40, 6);
            this.simpleButtonSelect.Name = "simpleButtonSelect";
            this.simpleButtonSelect.Size = new System.Drawing.Size(60, 24);
            this.simpleButtonSelect.TabIndex = 107;
            this.simpleButtonSelect.Text = "选中";
            this.simpleButtonSelect.ToolTip = "选中查询结果集";
            this.simpleButtonSelect.Click += new System.EventHandler(this.simpleButtonSelect_Click);
            // 
            // panel13
            // 
            this.panel13.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel13.Location = new System.Drawing.Point(100, 6);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(6, 24);
            this.panel13.TabIndex = 108;
            // 
            // simpleButtonInfo
            // 
            this.simpleButtonInfo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.simpleButtonInfo.Dock = System.Windows.Forms.DockStyle.Right;
            this.simpleButtonInfo.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.simpleButtonInfo.Location = new System.Drawing.Point(106, 6);
            this.simpleButtonInfo.Name = "simpleButtonInfo";
            this.simpleButtonInfo.Size = new System.Drawing.Size(60, 24);
            this.simpleButtonInfo.TabIndex = 13;
            this.simpleButtonInfo.Text = "查看";
            this.simpleButtonInfo.ToolTip = "查看详细信息";
            this.simpleButtonInfo.Click += new System.EventHandler(this.simpleButtonInfo_Click);
            // 
            // panel34
            // 
            this.panel34.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel34.Location = new System.Drawing.Point(166, 6);
            this.panel34.Name = "panel34";
            this.panel34.Size = new System.Drawing.Size(6, 24);
            this.panel34.TabIndex = 102;
            // 
            // simpleButtonBack
            // 
            this.simpleButtonBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.simpleButtonBack.Dock = System.Windows.Forms.DockStyle.Right;
            this.simpleButtonBack.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.simpleButtonBack.Location = new System.Drawing.Point(172, 6);
            this.simpleButtonBack.Name = "simpleButtonBack";
            this.simpleButtonBack.Size = new System.Drawing.Size(60, 24);
            this.simpleButtonBack.TabIndex = 12;
            this.simpleButtonBack.Text = "返回";
            this.simpleButtonBack.ToolTip = "返回设置条件";
            this.simpleButtonBack.Click += new System.EventHandler(this.simpleButtonBack_Click);
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label3.Location = new System.Drawing.Point(8, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(232, 26);
            this.label3.TabIndex = 100;
            this.label3.Text = "火灾列表";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupControlDist
            // 
            this.groupControlDist.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.groupControlDist.Appearance.Options.UseBackColor = true;
            this.groupControlDist.Controls.Add(this.panel2);
            this.groupControlDist.Controls.Add(this.panelMore);
            this.groupControlDist.Controls.Add(this.panelbasic);
            this.groupControlDist.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControlDist.Location = new System.Drawing.Point(0, 26);
            this.groupControlDist.Name = "groupControlDist";
            this.groupControlDist.Padding = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.groupControlDist.Size = new System.Drawing.Size(248, 437);
            this.groupControlDist.TabIndex = 108;
            this.groupControlDist.Text = "查找条件";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.simpleButtonReset);
            this.panel2.Controls.Add(this.panel33);
            this.panel2.Controls.Add(this.simpleButtonMore);
            this.panel2.Controls.Add(this.panel32);
            this.panel2.Controls.Add(this.ButtonFind);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(9, 404);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.panel2.Size = new System.Drawing.Size(230, 32);
            this.panel2.TabIndex = 16;
            // 
            // simpleButtonReset
            // 
            this.simpleButtonReset.Cursor = System.Windows.Forms.Cursors.Hand;
            this.simpleButtonReset.Dock = System.Windows.Forms.DockStyle.Right;
            this.simpleButtonReset.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.simpleButtonReset.Location = new System.Drawing.Point(38, 4);
            this.simpleButtonReset.Name = "simpleButtonReset";
            this.simpleButtonReset.Size = new System.Drawing.Size(60, 24);
            this.simpleButtonReset.TabIndex = 14;
            this.simpleButtonReset.Text = "重置";
            this.simpleButtonReset.ToolTip = "重新设置查询条件";
            this.simpleButtonReset.Click += new System.EventHandler(this.simpleButtonReset_Click);
            // 
            // panel33
            // 
            this.panel33.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel33.Location = new System.Drawing.Point(98, 4);
            this.panel33.Name = "panel33";
            this.panel33.Size = new System.Drawing.Size(6, 24);
            this.panel33.TabIndex = 18;
            // 
            // simpleButtonMore
            // 
            this.simpleButtonMore.Cursor = System.Windows.Forms.Cursors.Hand;
            this.simpleButtonMore.Dock = System.Windows.Forms.DockStyle.Right;
            this.simpleButtonMore.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.simpleButtonMore.Location = new System.Drawing.Point(104, 4);
            this.simpleButtonMore.Name = "simpleButtonMore";
            this.simpleButtonMore.Size = new System.Drawing.Size(60, 24);
            this.simpleButtonMore.TabIndex = 13;
            this.simpleButtonMore.Tag = "基本";
            this.simpleButtonMore.Text = "更多";
            this.simpleButtonMore.ToolTip = "更多查询条件";
            this.simpleButtonMore.Click += new System.EventHandler(this.simpleButtonMore_Click);
            // 
            // panel32
            // 
            this.panel32.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel32.Location = new System.Drawing.Point(164, 4);
            this.panel32.Name = "panel32";
            this.panel32.Size = new System.Drawing.Size(6, 24);
            this.panel32.TabIndex = 17;
            // 
            // ButtonFind
            // 
            this.ButtonFind.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonFind.Dock = System.Windows.Forms.DockStyle.Right;
            this.ButtonFind.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.ButtonFind.Location = new System.Drawing.Point(170, 4);
            this.ButtonFind.Name = "ButtonFind";
            this.ButtonFind.Size = new System.Drawing.Size(60, 24);
            this.ButtonFind.TabIndex = 12;
            this.ButtonFind.Text = "查找";
            this.ButtonFind.ToolTip = "小班查找";
            this.ButtonFind.Click += new System.EventHandler(this.ButtonFind_Click);
            // 
            // panelMore
            // 
            this.panelMore.Controls.Add(this.xtraTabControl1);
            this.panelMore.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelMore.Location = new System.Drawing.Point(9, 171);
            this.panelMore.Name = "panelMore";
            this.panelMore.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.panelMore.Size = new System.Drawing.Size(230, 233);
            this.panelMore.TabIndex = 17;
            this.panelMore.Visible = false;
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl1.Location = new System.Drawing.Point(0, 2);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPage2;
            this.xtraTabControl1.Size = new System.Drawing.Size(230, 231);
            this.xtraTabControl1.TabIndex = 19;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1,
            this.xtraTabPage2});
            // 
            // xtraTabPage2
            // 
            this.xtraTabPage2.Controls.Add(this.panel28);
            this.xtraTabPage2.Controls.Add(this.panel27);
            this.xtraTabPage2.Controls.Add(this.panel3);
            this.xtraTabPage2.Controls.Add(this.panel21);
            this.xtraTabPage2.Controls.Add(this.panel26);
            this.xtraTabPage2.Controls.Add(this.panel20);
            this.xtraTabPage2.Name = "xtraTabPage2";
            this.xtraTabPage2.Size = new System.Drawing.Size(224, 202);
            this.xtraTabPage2.Text = "火灾信息";
            // 
            // panel28
            // 
            this.panel28.Controls.Add(this.spinEditL66);
            this.panel28.Controls.Add(this.label38);
            this.panel28.Controls.Add(this.spinEditL6);
            this.panel28.Controls.Add(this.label28);
            this.panel28.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel28.Location = new System.Drawing.Point(0, 125);
            this.panel28.Name = "panel28";
            this.panel28.Padding = new System.Windows.Forms.Padding(2, 4, 6, 0);
            this.panel28.Size = new System.Drawing.Size(224, 25);
            this.panel28.TabIndex = 28;
            // 
            // spinEditL66
            // 
            this.spinEditL66.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spinEditL66.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinEditL66.Location = new System.Drawing.Point(162, 4);
            this.spinEditL66.Name = "spinEditL66";
            this.spinEditL66.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spinEditL66.Properties.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.spinEditL66.Properties.Mask.EditMask = "d";
            this.spinEditL66.Size = new System.Drawing.Size(56, 20);
            this.spinEditL66.TabIndex = 14;
            // 
            // label38
            // 
            this.label38.Dock = System.Windows.Forms.DockStyle.Left;
            this.label38.Location = new System.Drawing.Point(142, 4);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(20, 21);
            this.label38.TabIndex = 13;
            this.label38.Text = "~";
            this.label38.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // spinEditL6
            // 
            this.spinEditL6.Dock = System.Windows.Forms.DockStyle.Left;
            this.spinEditL6.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinEditL6.Location = new System.Drawing.Point(82, 4);
            this.spinEditL6.Name = "spinEditL6";
            this.spinEditL6.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spinEditL6.Properties.Mask.EditMask = "d";
            this.spinEditL6.Size = new System.Drawing.Size(60, 20);
            this.spinEditL6.TabIndex = 12;
            // 
            // label28
            // 
            this.label28.Dock = System.Windows.Forms.DockStyle.Left;
            this.label28.Location = new System.Drawing.Point(2, 4);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(80, 21);
            this.label28.TabIndex = 8;
            this.label28.Text = "损失株数:";
            this.label28.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel27
            // 
            this.panel27.Controls.Add(this.spinEditL55);
            this.panel27.Controls.Add(this.label25);
            this.panel27.Controls.Add(this.spinEditL5);
            this.panel27.Controls.Add(this.label27);
            this.panel27.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel27.Location = new System.Drawing.Point(0, 100);
            this.panel27.Name = "panel27";
            this.panel27.Padding = new System.Windows.Forms.Padding(2, 4, 6, 0);
            this.panel27.Size = new System.Drawing.Size(224, 25);
            this.panel27.TabIndex = 27;
            // 
            // spinEditL55
            // 
            this.spinEditL55.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spinEditL55.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinEditL55.Location = new System.Drawing.Point(162, 4);
            this.spinEditL55.Name = "spinEditL55";
            this.spinEditL55.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spinEditL55.Properties.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.spinEditL55.Properties.Mask.EditMask = "d";
            this.spinEditL55.Size = new System.Drawing.Size(56, 20);
            this.spinEditL55.TabIndex = 11;
            // 
            // label25
            // 
            this.label25.Dock = System.Windows.Forms.DockStyle.Left;
            this.label25.Location = new System.Drawing.Point(142, 4);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(20, 21);
            this.label25.TabIndex = 10;
            this.label25.Text = "~";
            this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // spinEditL5
            // 
            this.spinEditL5.Dock = System.Windows.Forms.DockStyle.Left;
            this.spinEditL5.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinEditL5.Location = new System.Drawing.Point(82, 4);
            this.spinEditL5.Name = "spinEditL5";
            this.spinEditL5.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spinEditL5.Properties.Mask.EditMask = "d";
            this.spinEditL5.Size = new System.Drawing.Size(60, 20);
            this.spinEditL5.TabIndex = 9;
            // 
            // label27
            // 
            this.label27.Dock = System.Windows.Forms.DockStyle.Left;
            this.label27.Location = new System.Drawing.Point(2, 4);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(80, 21);
            this.label27.TabIndex = 8;
            this.label27.Text = "保留蓄积:";
            this.label27.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.spinEditL44);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.spinEditL4);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 75);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(2, 4, 6, 0);
            this.panel3.Size = new System.Drawing.Size(224, 25);
            this.panel3.TabIndex = 29;
            // 
            // spinEditL44
            // 
            this.spinEditL44.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spinEditL44.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinEditL44.Location = new System.Drawing.Point(162, 4);
            this.spinEditL44.Name = "spinEditL44";
            this.spinEditL44.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spinEditL44.Properties.Mask.EditMask = "d";
            this.spinEditL44.Size = new System.Drawing.Size(56, 20);
            this.spinEditL44.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Left;
            this.label4.Location = new System.Drawing.Point(142, 4);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(20, 21);
            this.label4.TabIndex = 10;
            this.label4.Text = "~";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // spinEditL4
            // 
            this.spinEditL4.Dock = System.Windows.Forms.DockStyle.Left;
            this.spinEditL4.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinEditL4.Location = new System.Drawing.Point(82, 4);
            this.spinEditL4.Name = "spinEditL4";
            this.spinEditL4.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spinEditL4.Properties.Mask.EditMask = "d";
            this.spinEditL4.Size = new System.Drawing.Size(60, 20);
            this.spinEditL4.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.Dock = System.Windows.Forms.DockStyle.Left;
            this.label5.Location = new System.Drawing.Point(2, 4);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 21);
            this.label5.TabIndex = 8;
            this.label5.Text = "损失蓄积:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel21
            // 
            this.panel21.Controls.Add(this.spinEditL33);
            this.panel21.Controls.Add(this.label18);
            this.panel21.Controls.Add(this.spinEditL3);
            this.panel21.Controls.Add(this.label17);
            this.panel21.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel21.Location = new System.Drawing.Point(0, 50);
            this.panel21.Name = "panel21";
            this.panel21.Padding = new System.Windows.Forms.Padding(2, 4, 6, 0);
            this.panel21.Size = new System.Drawing.Size(224, 25);
            this.panel21.TabIndex = 18;
            // 
            // spinEditL33
            // 
            this.spinEditL33.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spinEditL33.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinEditL33.Location = new System.Drawing.Point(162, 4);
            this.spinEditL33.Name = "spinEditL33";
            this.spinEditL33.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spinEditL33.Properties.Mask.EditMask = "d";
            this.spinEditL33.Size = new System.Drawing.Size(56, 20);
            this.spinEditL33.TabIndex = 11;
            // 
            // label18
            // 
            this.label18.Dock = System.Windows.Forms.DockStyle.Left;
            this.label18.Location = new System.Drawing.Point(142, 4);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(20, 21);
            this.label18.TabIndex = 10;
            this.label18.Text = "~";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // spinEditL3
            // 
            this.spinEditL3.Dock = System.Windows.Forms.DockStyle.Left;
            this.spinEditL3.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinEditL3.Location = new System.Drawing.Point(82, 4);
            this.spinEditL3.Name = "spinEditL3";
            this.spinEditL3.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spinEditL3.Properties.Mask.EditMask = "d";
            this.spinEditL3.Size = new System.Drawing.Size(60, 20);
            this.spinEditL3.TabIndex = 9;
            // 
            // label17
            // 
            this.label17.Dock = System.Windows.Forms.DockStyle.Left;
            this.label17.Location = new System.Drawing.Point(2, 4);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(80, 21);
            this.label17.TabIndex = 8;
            this.label17.Text = "灾害面积:";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel26
            // 
            this.panel26.Controls.Add(this.comboBoxL2);
            this.panel26.Controls.Add(this.label26);
            this.panel26.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel26.Location = new System.Drawing.Point(0, 25);
            this.panel26.Name = "panel26";
            this.panel26.Padding = new System.Windows.Forms.Padding(2, 4, 6, 0);
            this.panel26.Size = new System.Drawing.Size(224, 25);
            this.panel26.TabIndex = 26;
            // 
            // comboBoxL2
            // 
            this.comboBoxL2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBoxL2.EditValue = "--";
            this.comboBoxL2.Location = new System.Drawing.Point(82, 4);
            this.comboBoxL2.Name = "comboBoxL2";
            this.comboBoxL2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxL2.Properties.Items.AddRange(new object[] {
            "--",
            "可编辑",
            "不可编辑",
            "已提交"});
            this.comboBoxL2.Size = new System.Drawing.Size(136, 20);
            this.comboBoxL2.TabIndex = 22;
            // 
            // label26
            // 
            this.label26.Dock = System.Windows.Forms.DockStyle.Left;
            this.label26.Location = new System.Drawing.Point(2, 4);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(80, 21);
            this.label26.TabIndex = 8;
            this.label26.Text = "火灾原因:";
            this.label26.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel20
            // 
            this.panel20.Controls.Add(this.comboBoxL1);
            this.panel20.Controls.Add(this.label16);
            this.panel20.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel20.Location = new System.Drawing.Point(0, 0);
            this.panel20.Name = "panel20";
            this.panel20.Padding = new System.Windows.Forms.Padding(2, 4, 6, 0);
            this.panel20.Size = new System.Drawing.Size(224, 25);
            this.panel20.TabIndex = 17;
            // 
            // comboBoxL1
            // 
            this.comboBoxL1.Dock = System.Windows.Forms.DockStyle.Top;
            this.comboBoxL1.EditValue = "--";
            this.comboBoxL1.Location = new System.Drawing.Point(82, 4);
            this.comboBoxL1.Name = "comboBoxL1";
            this.comboBoxL1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxL1.Properties.Items.AddRange(new object[] {
            "--",
            "可编辑",
            "不可编辑",
            "已提交"});
            this.comboBoxL1.Size = new System.Drawing.Size(136, 20);
            this.comboBoxL1.TabIndex = 22;
            // 
            // label16
            // 
            this.label16.Dock = System.Windows.Forms.DockStyle.Left;
            this.label16.Location = new System.Drawing.Point(2, 4);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(80, 21);
            this.label16.TabIndex = 8;
            this.label16.Text = "火灾等级:";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Controls.Add(this.panel22);
            this.xtraTabPage1.Controls.Add(this.panel23);
            this.xtraTabPage1.Controls.Add(this.panel4);
            this.xtraTabPage1.Controls.Add(this.panel7);
            this.xtraTabPage1.Controls.Add(this.panel8);
            this.xtraTabPage1.Controls.Add(this.panel24);
            this.xtraTabPage1.Controls.Add(this.panel19);
            this.xtraTabPage1.Controls.Add(this.panel25);
            this.xtraTabPage1.Controls.Add(this.panel18);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(224, 202);
            this.xtraTabPage1.Text = "基本信息";
            // 
            // panel22
            // 
            this.panel22.Controls.Add(this.spinEditB66);
            this.panel22.Controls.Add(this.label12);
            this.panel22.Controls.Add(this.spinEditB6);
            this.panel22.Controls.Add(this.label21);
            this.panel22.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel22.Location = new System.Drawing.Point(0, 200);
            this.panel22.Name = "panel22";
            this.panel22.Padding = new System.Windows.Forms.Padding(2, 4, 6, 0);
            this.panel22.Size = new System.Drawing.Size(224, 25);
            this.panel22.TabIndex = 23;
            // 
            // spinEditB66
            // 
            this.spinEditB66.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spinEditB66.EditValue = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.spinEditB66.Location = new System.Drawing.Point(164, 4);
            this.spinEditB66.Name = "spinEditB66";
            this.spinEditB66.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spinEditB66.Properties.Mask.EditMask = "d";
            this.spinEditB66.Size = new System.Drawing.Size(54, 20);
            this.spinEditB66.TabIndex = 14;
            // 
            // label12
            // 
            this.label12.Dock = System.Windows.Forms.DockStyle.Left;
            this.label12.Location = new System.Drawing.Point(134, 4);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(30, 21);
            this.label12.TabIndex = 13;
            this.label12.Text = "~";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // spinEditB6
            // 
            this.spinEditB6.Dock = System.Windows.Forms.DockStyle.Left;
            this.spinEditB6.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinEditB6.Location = new System.Drawing.Point(74, 4);
            this.spinEditB6.Name = "spinEditB6";
            this.spinEditB6.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spinEditB6.Properties.Mask.EditMask = "d";
            this.spinEditB6.Size = new System.Drawing.Size(60, 20);
            this.spinEditB6.TabIndex = 12;
            // 
            // label21
            // 
            this.label21.Dock = System.Windows.Forms.DockStyle.Left;
            this.label21.Location = new System.Drawing.Point(2, 4);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(72, 21);
            this.label21.TabIndex = 8;
            this.label21.Text = "郁闭度:";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel23
            // 
            this.panel23.Controls.Add(this.comboBoxB8);
            this.panel23.Controls.Add(this.label22);
            this.panel23.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel23.Location = new System.Drawing.Point(0, 175);
            this.panel23.Name = "panel23";
            this.panel23.Padding = new System.Windows.Forms.Padding(2, 4, 6, 0);
            this.panel23.Size = new System.Drawing.Size(224, 25);
            this.panel23.TabIndex = 22;
            // 
            // comboBoxB8
            // 
            this.comboBoxB8.Dock = System.Windows.Forms.DockStyle.Top;
            this.comboBoxB8.EditValue = "--";
            this.comboBoxB8.Location = new System.Drawing.Point(74, 4);
            this.comboBoxB8.Name = "comboBoxB8";
            this.comboBoxB8.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxB8.Properties.Items.AddRange(new object[] {
            "--",
            "可编辑",
            "不可编辑",
            "已提交"});
            this.comboBoxB8.Size = new System.Drawing.Size(144, 20);
            this.comboBoxB8.TabIndex = 21;
            // 
            // label22
            // 
            this.label22.Dock = System.Windows.Forms.DockStyle.Left;
            this.label22.Location = new System.Drawing.Point(2, 4);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(72, 21);
            this.label22.TabIndex = 8;
            this.label22.Text = "森林类别:";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.comboBoxB7);
            this.panel4.Controls.Add(this.label20);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 150);
            this.panel4.Name = "panel4";
            this.panel4.Padding = new System.Windows.Forms.Padding(2, 4, 6, 0);
            this.panel4.Size = new System.Drawing.Size(224, 25);
            this.panel4.TabIndex = 28;
            // 
            // comboBoxB7
            // 
            this.comboBoxB7.Dock = System.Windows.Forms.DockStyle.Top;
            this.comboBoxB7.EditValue = "--";
            this.comboBoxB7.Location = new System.Drawing.Point(74, 4);
            this.comboBoxB7.Name = "comboBoxB7";
            this.comboBoxB7.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxB7.Properties.Items.AddRange(new object[] {
            "--",
            "可编辑",
            "不可编辑",
            "已提交"});
            this.comboBoxB7.Size = new System.Drawing.Size(144, 20);
            this.comboBoxB7.TabIndex = 22;
            // 
            // label20
            // 
            this.label20.Dock = System.Windows.Forms.DockStyle.Left;
            this.label20.Location = new System.Drawing.Point(2, 4);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(72, 21);
            this.label20.TabIndex = 8;
            this.label20.Text = "林木使用权:";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.comboBoxB6);
            this.panel7.Controls.Add(this.label6);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel7.Location = new System.Drawing.Point(0, 125);
            this.panel7.Name = "panel7";
            this.panel7.Padding = new System.Windows.Forms.Padding(2, 4, 6, 0);
            this.panel7.Size = new System.Drawing.Size(224, 25);
            this.panel7.TabIndex = 27;
            // 
            // comboBoxB6
            // 
            this.comboBoxB6.Dock = System.Windows.Forms.DockStyle.Top;
            this.comboBoxB6.EditValue = "--";
            this.comboBoxB6.Location = new System.Drawing.Point(74, 4);
            this.comboBoxB6.Name = "comboBoxB6";
            this.comboBoxB6.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxB6.Properties.Items.AddRange(new object[] {
            "--",
            "可编辑",
            "不可编辑",
            "已提交"});
            this.comboBoxB6.Size = new System.Drawing.Size(144, 20);
            this.comboBoxB6.TabIndex = 22;
            // 
            // label6
            // 
            this.label6.Dock = System.Windows.Forms.DockStyle.Left;
            this.label6.Location = new System.Drawing.Point(2, 4);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 21);
            this.label6.TabIndex = 8;
            this.label6.Text = "林木所有权:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.comboBoxB5);
            this.panel8.Controls.Add(this.label10);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel8.Location = new System.Drawing.Point(0, 100);
            this.panel8.Name = "panel8";
            this.panel8.Padding = new System.Windows.Forms.Padding(2, 4, 6, 0);
            this.panel8.Size = new System.Drawing.Size(224, 25);
            this.panel8.TabIndex = 26;
            // 
            // comboBoxB5
            // 
            this.comboBoxB5.Dock = System.Windows.Forms.DockStyle.Top;
            this.comboBoxB5.EditValue = "--";
            this.comboBoxB5.Location = new System.Drawing.Point(74, 4);
            this.comboBoxB5.Name = "comboBoxB5";
            this.comboBoxB5.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxB5.Properties.Items.AddRange(new object[] {
            "--",
            "可编辑",
            "不可编辑",
            "已提交"});
            this.comboBoxB5.Size = new System.Drawing.Size(144, 20);
            this.comboBoxB5.TabIndex = 21;
            // 
            // label10
            // 
            this.label10.Dock = System.Windows.Forms.DockStyle.Left;
            this.label10.Location = new System.Drawing.Point(2, 4);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(72, 21);
            this.label10.TabIndex = 8;
            this.label10.Text = "土地使用权:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel24
            // 
            this.panel24.Controls.Add(this.comboBoxB4);
            this.panel24.Controls.Add(this.label23);
            this.panel24.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel24.Location = new System.Drawing.Point(0, 75);
            this.panel24.Name = "panel24";
            this.panel24.Padding = new System.Windows.Forms.Padding(2, 4, 6, 0);
            this.panel24.Size = new System.Drawing.Size(224, 25);
            this.panel24.TabIndex = 21;
            // 
            // comboBoxB4
            // 
            this.comboBoxB4.Dock = System.Windows.Forms.DockStyle.Top;
            this.comboBoxB4.EditValue = "--";
            this.comboBoxB4.Location = new System.Drawing.Point(74, 4);
            this.comboBoxB4.Name = "comboBoxB4";
            this.comboBoxB4.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxB4.Properties.Items.AddRange(new object[] {
            "--",
            "可编辑",
            "不可编辑",
            "已提交"});
            this.comboBoxB4.Size = new System.Drawing.Size(144, 20);
            this.comboBoxB4.TabIndex = 23;
            // 
            // label23
            // 
            this.label23.Dock = System.Windows.Forms.DockStyle.Left;
            this.label23.Location = new System.Drawing.Point(2, 4);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(72, 21);
            this.label23.TabIndex = 8;
            this.label23.Text = "土地权属:";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel19
            // 
            this.panel19.Controls.Add(this.comboBoxB3);
            this.panel19.Controls.Add(this.label15);
            this.panel19.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel19.Location = new System.Drawing.Point(0, 50);
            this.panel19.Name = "panel19";
            this.panel19.Padding = new System.Windows.Forms.Padding(2, 4, 6, 0);
            this.panel19.Size = new System.Drawing.Size(224, 25);
            this.panel19.TabIndex = 16;
            // 
            // comboBoxB3
            // 
            this.comboBoxB3.Dock = System.Windows.Forms.DockStyle.Top;
            this.comboBoxB3.EditValue = "--";
            this.comboBoxB3.Location = new System.Drawing.Point(74, 4);
            this.comboBoxB3.Name = "comboBoxB3";
            this.comboBoxB3.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxB3.Properties.Items.AddRange(new object[] {
            "--",
            "可编辑",
            "不可编辑",
            "已提交"});
            this.comboBoxB3.Size = new System.Drawing.Size(144, 20);
            this.comboBoxB3.TabIndex = 22;
            // 
            // label15
            // 
            this.label15.Dock = System.Windows.Forms.DockStyle.Left;
            this.label15.Location = new System.Drawing.Point(2, 4);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(72, 21);
            this.label15.TabIndex = 8;
            this.label15.Text = "亚林种 :";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel25
            // 
            this.panel25.Controls.Add(this.comboBoxB2);
            this.panel25.Controls.Add(this.label24);
            this.panel25.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel25.Location = new System.Drawing.Point(0, 25);
            this.panel25.Name = "panel25";
            this.panel25.Padding = new System.Windows.Forms.Padding(2, 4, 6, 0);
            this.panel25.Size = new System.Drawing.Size(224, 25);
            this.panel25.TabIndex = 25;
            // 
            // comboBoxB2
            // 
            this.comboBoxB2.Dock = System.Windows.Forms.DockStyle.Top;
            this.comboBoxB2.EditValue = "--";
            this.comboBoxB2.Location = new System.Drawing.Point(74, 4);
            this.comboBoxB2.Name = "comboBoxB2";
            this.comboBoxB2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxB2.Properties.Items.AddRange(new object[] {
            "--",
            "可编辑",
            "不可编辑",
            "已提交"});
            this.comboBoxB2.Size = new System.Drawing.Size(144, 20);
            this.comboBoxB2.TabIndex = 22;
            // 
            // label24
            // 
            this.label24.Dock = System.Windows.Forms.DockStyle.Left;
            this.label24.Location = new System.Drawing.Point(2, 4);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(72, 21);
            this.label24.TabIndex = 8;
            this.label24.Text = "起源 :";
            this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel18
            // 
            this.panel18.Controls.Add(this.comboBoxB1);
            this.panel18.Controls.Add(this.label14);
            this.panel18.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel18.Location = new System.Drawing.Point(0, 0);
            this.panel18.Name = "panel18";
            this.panel18.Padding = new System.Windows.Forms.Padding(2, 4, 6, 0);
            this.panel18.Size = new System.Drawing.Size(224, 25);
            this.panel18.TabIndex = 15;
            // 
            // comboBoxB1
            // 
            this.comboBoxB1.Dock = System.Windows.Forms.DockStyle.Top;
            this.comboBoxB1.EditValue = "--";
            this.comboBoxB1.Location = new System.Drawing.Point(74, 4);
            this.comboBoxB1.Name = "comboBoxB1";
            this.comboBoxB1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxB1.Properties.Items.AddRange(new object[] {
            "--",
            "可编辑",
            "不可编辑",
            "已提交"});
            this.comboBoxB1.Size = new System.Drawing.Size(144, 20);
            this.comboBoxB1.TabIndex = 23;
            // 
            // label14
            // 
            this.label14.Dock = System.Windows.Forms.DockStyle.Left;
            this.label14.Location = new System.Drawing.Point(2, 4);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(72, 21);
            this.label14.TabIndex = 8;
            this.label14.Text = "地类 :";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelbasic
            // 
            this.panelbasic.Controls.Add(this.panelDistLocation);
            this.panelbasic.Controls.Add(this.panel9);
            this.panelbasic.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelbasic.Location = new System.Drawing.Point(9, 22);
            this.panelbasic.Name = "panelbasic";
            this.panelbasic.Padding = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.panelbasic.Size = new System.Drawing.Size(230, 149);
            this.panelbasic.TabIndex = 18;
            // 
            // panelDistLocation
            // 
            this.panelDistLocation.BackColor = System.Drawing.Color.Transparent;
            this.panelDistLocation.Controls.Add(this.panel10);
            this.panelDistLocation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDistLocation.ForeColor = System.Drawing.Color.Black;
            this.panelDistLocation.Location = new System.Drawing.Point(62, 0);
            this.panelDistLocation.Name = "panelDistLocation";
            this.panelDistLocation.Size = new System.Drawing.Size(168, 148);
            this.panelDistLocation.TabIndex = 9;
            // 
            // panel10
            // 
            this.panel10.Controls.Add(this.panel35);
            this.panel10.Controls.Add(this.panel31);
            this.panel10.Controls.Add(this.comboBoxXiban);
            this.panel10.Controls.Add(this.panel30);
            this.panel10.Controls.Add(this.comboBoxXiaoban);
            this.panel10.Controls.Add(this.panel6);
            this.panel10.Controls.Add(this.comboBoxLinban);
            this.panel10.Controls.Add(this.panel1);
            this.panel10.Controls.Add(this.comboBoxVillage);
            this.panel10.Controls.Add(this.panel12);
            this.panel10.Controls.Add(this.comboBoxTown);
            this.panel10.Controls.Add(this.panel11);
            this.panel10.Controls.Add(this.comboBoxCounty);
            this.panel10.Controls.Add(this.panel14);
            this.panel10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel10.Location = new System.Drawing.Point(0, 0);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(168, 148);
            this.panel10.TabIndex = 14;
            // 
            // panel35
            // 
            this.panel35.Controls.Add(this.dateEdit2);
            this.panel35.Controls.Add(this.label31);
            this.panel35.Controls.Add(this.dateEdit1);
            this.panel35.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel35.Location = new System.Drawing.Point(0, 162);
            this.panel35.Name = "panel35";
            this.panel35.Size = new System.Drawing.Size(168, 23);
            this.panel35.TabIndex = 25;
            // 
            // dateEdit2
            // 
            this.dateEdit2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dateEdit2.EditValue = null;
            this.dateEdit2.Location = new System.Drawing.Point(92, 0);
            this.dateEdit2.Name = "dateEdit2";
            this.dateEdit2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit2.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateEdit2.Size = new System.Drawing.Size(76, 20);
            this.dateEdit2.TabIndex = 24;
            // 
            // label31
            // 
            this.label31.Dock = System.Windows.Forms.DockStyle.Left;
            this.label31.Location = new System.Drawing.Point(80, 0);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(12, 23);
            this.label31.TabIndex = 23;
            this.label31.Text = "-";
            this.label31.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dateEdit1
            // 
            this.dateEdit1.Dock = System.Windows.Forms.DockStyle.Left;
            this.dateEdit1.EditValue = null;
            this.dateEdit1.Location = new System.Drawing.Point(0, 0);
            this.dateEdit1.Name = "dateEdit1";
            this.dateEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit1.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateEdit1.Size = new System.Drawing.Size(80, 20);
            this.dateEdit1.TabIndex = 22;
            // 
            // panel31
            // 
            this.panel31.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel31.Location = new System.Drawing.Point(0, 156);
            this.panel31.Name = "panel31";
            this.panel31.Size = new System.Drawing.Size(168, 6);
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
            this.comboBoxXiban.Size = new System.Drawing.Size(168, 20);
            this.comboBoxXiban.TabIndex = 21;
            this.comboBoxXiban.Visible = false;
            this.comboBoxXiban.TextChanged += new System.EventHandler(this.comboBoxBase_TextChanged);
            // 
            // panel30
            // 
            this.panel30.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel30.Location = new System.Drawing.Point(0, 130);
            this.panel30.Name = "panel30";
            this.panel30.Size = new System.Drawing.Size(168, 6);
            this.panel30.TabIndex = 16;
            this.panel30.Visible = false;
            // 
            // comboBoxXiaoban
            // 
            this.comboBoxXiaoban.Dock = System.Windows.Forms.DockStyle.Top;
            this.comboBoxXiaoban.Location = new System.Drawing.Point(0, 110);
            this.comboBoxXiaoban.Name = "comboBoxXiaoban";
            this.comboBoxXiaoban.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxXiaoban.Size = new System.Drawing.Size(168, 20);
            this.comboBoxXiaoban.TabIndex = 15;
            this.comboBoxXiaoban.Visible = false;
            this.comboBoxXiaoban.TextChanged += new System.EventHandler(this.comboBoxBase_TextChanged);
            // 
            // panel6
            // 
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 104);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(168, 6);
            this.panel6.TabIndex = 14;
            this.panel6.Visible = false;
            // 
            // comboBoxLinban
            // 
            this.comboBoxLinban.Dock = System.Windows.Forms.DockStyle.Top;
            this.comboBoxLinban.Location = new System.Drawing.Point(0, 84);
            this.comboBoxLinban.Name = "comboBoxLinban";
            this.comboBoxLinban.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxLinban.Size = new System.Drawing.Size(168, 20);
            this.comboBoxLinban.TabIndex = 13;
            this.comboBoxLinban.TextChanged += new System.EventHandler(this.comboBoxBase_TextChanged);
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 78);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(168, 6);
            this.panel1.TabIndex = 12;
            // 
            // comboBoxVillage
            // 
            this.comboBoxVillage.Dock = System.Windows.Forms.DockStyle.Top;
            this.comboBoxVillage.Location = new System.Drawing.Point(0, 58);
            this.comboBoxVillage.Name = "comboBoxVillage";
            this.comboBoxVillage.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxVillage.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.comboBoxVillage.Size = new System.Drawing.Size(168, 20);
            this.comboBoxVillage.TabIndex = 11;
            this.comboBoxVillage.TextChanged += new System.EventHandler(this.comboBoxBase_TextChanged);
            // 
            // panel12
            // 
            this.panel12.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel12.Location = new System.Drawing.Point(0, 52);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(168, 6);
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
            this.comboBoxTown.Size = new System.Drawing.Size(168, 20);
            this.comboBoxTown.TabIndex = 10;
            this.comboBoxTown.TextChanged += new System.EventHandler(this.comboBoxBase_TextChanged);
            // 
            // panel11
            // 
            this.panel11.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel11.Location = new System.Drawing.Point(0, 26);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(168, 6);
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
            this.comboBoxCounty.Size = new System.Drawing.Size(168, 20);
            this.comboBoxCounty.TabIndex = 9;
            this.comboBoxCounty.TextChanged += new System.EventHandler(this.comboBoxBase_TextChanged);
            // 
            // panel14
            // 
            this.panel14.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel14.Location = new System.Drawing.Point(0, 0);
            this.panel14.Name = "panel14";
            this.panel14.Size = new System.Drawing.Size(168, 6);
            this.panel14.TabIndex = 8;
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.label30);
            this.panel9.Controls.Add(this.label32);
            this.panel9.Controls.Add(this.label2);
            this.panel9.Controls.Add(this.label1);
            this.panel9.Controls.Add(this.label9);
            this.panel9.Controls.Add(this.label8);
            this.panel9.Controls.Add(this.label7);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel9.Location = new System.Drawing.Point(0, 0);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(62, 148);
            this.panel9.TabIndex = 13;
            this.panel9.TabStop = true;
            // 
            // label30
            // 
            this.label30.Dock = System.Windows.Forms.DockStyle.Top;
            this.label30.Location = new System.Drawing.Point(0, 165);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(62, 27);
            this.label30.TabIndex = 6;
            this.label30.Text = "发生时间:";
            this.label30.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label32
            // 
            this.label32.Dock = System.Windows.Forms.DockStyle.Top;
            this.label32.Location = new System.Drawing.Point(0, 138);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(62, 27);
            this.label32.TabIndex = 8;
            this.label32.Text = "作业小班:";
            this.label32.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label32.Visible = false;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Location = new System.Drawing.Point(0, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 27);
            this.label2.TabIndex = 5;
            this.label2.Text = "调查小班:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label2.Visible = false;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(0, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 27);
            this.label1.TabIndex = 4;
            this.label1.Text = "林班 :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            // labelLocation
            // 
            this.labelLocation.BackColor = System.Drawing.Color.Transparent;
            this.labelLocation.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelLocation.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelLocation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.labelLocation.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelLocation.Location = new System.Drawing.Point(0, 0);
            this.labelLocation.Name = "labelLocation";
            this.labelLocation.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.labelLocation.Size = new System.Drawing.Size(248, 26);
            this.labelLocation.TabIndex = 109;
            this.labelLocation.Text = "      火灾查找";
            this.labelLocation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // UserControlQueryHZ
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.Controls.Add(this.groupControlResult);
            this.Controls.Add(this.groupControlDist);
            this.Controls.Add(this.labelLocation);
            this.Name = "UserControlQueryHZ";
            this.Size = new System.Drawing.Size(248, 652);
            ((System.ComponentModel.ISupportInitialize)(this.groupControlResult)).EndInit();
            this.groupControlResult.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treeList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPopupContainerEdit3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageEdit1)).EndInit();
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControlDist)).EndInit();
            this.groupControlDist.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panelMore.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.xtraTabPage2.ResumeLayout(false);
            this.panel28.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spinEditL66.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditL6.Properties)).EndInit();
            this.panel27.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spinEditL55.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditL5.Properties)).EndInit();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spinEditL44.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditL4.Properties)).EndInit();
            this.panel21.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spinEditL33.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditL3.Properties)).EndInit();
            this.panel26.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxL2.Properties)).EndInit();
            this.panel20.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxL1.Properties)).EndInit();
            this.xtraTabPage1.ResumeLayout(false);
            this.panel22.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spinEditB66.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditB6.Properties)).EndInit();
            this.panel23.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxB8.Properties)).EndInit();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxB7.Properties)).EndInit();
            this.panel7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxB6.Properties)).EndInit();
            this.panel8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxB5.Properties)).EndInit();
            this.panel24.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxB4.Properties)).EndInit();
            this.panel19.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxB3.Properties)).EndInit();
            this.panel25.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxB2.Properties)).EndInit();
            this.panel18.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxB1.Properties)).EndInit();
            this.panelbasic.ResumeLayout(false);
            this.panelDistLocation.ResumeLayout(false);
            this.panel10.ResumeLayout(false);
            this.panel35.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit2.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxXiban.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxXiaoban.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxLinban.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxVillage.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxTown.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxCounty.Properties)).EndInit();
            this.panel9.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        public void InitialValue(object hook, IFeatureLayer pFeatureLayer, IMap pMap, QueryCommon.UserControlQueryResult pResult, DockPanel pDockPanel)
        {
            try
            {
                this.mHookHelper = new HookHelperClass();
                this.mHookHelper.Hook = hook;
                this.mEditLayer = pFeatureLayer;
                this.sTableName = UtilFactory.GetConfigOpt().GetConfigValue("FireTableName");
                this.mTable = EditTask.EditWorkspace.OpenTable(this.sTableName);
                this.mMap = pMap;
                this.mQueryResult = pResult;
                this.mDockPanel = pDockPanel;
                this.groupControlResult.Visible = false;
                this.panelMore.Visible = false;
                this.simpleButtonMore.Text = "更多";
                this.groupControlDist.Dock = DockStyle.Fill;
                this.groupControlDist.BringToFront();
                this.InitialDist();
                this.InitialDicCom();
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "QueryAnalysic.UserControlQueryHZ", "InitializeGISControls", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void SetDist(string code, DataTable ptable, ComboBoxEdit combox)
        {
            try
            {
                if ((!combox.Name.Contains("Xiaoban") && !combox.Name.Contains("Linban")) && !combox.Name.Contains("Xiban"))
                {
                    DataRow[] rowArray = ptable.Select("code like '" + code + "%'");
                    for (int i = 0; i < rowArray.Length; i++)
                    {
                        combox.Properties.Items.Add(rowArray[i]["name"]);
                    }
                    ArrayList list = new ArrayList();
                    list.Add(ptable);
                    list.Add(rowArray);
                    combox.Tag = list;
                }
                else
                {
                    string[] strArray = UtilFactory.GetConfigOpt().GetConfigValue("XBFieldName2").Split(new char[] { ',' });
                    string str = strArray[2];
                    if (combox.Name.Contains("Linban"))
                    {
                        string str2 = strArray[2];
                        IQueryFilter filter = new QueryFilterClass();
                        filter.WhereClause = str2 + "='" + code.Substring(0, 12) + "'";
                        IQueryFilterDefinition definition = (IQueryFilterDefinition) filter;
                        definition.PostfixClause = "ORDER BY LIN_BAN";
                        IFeatureCursor cursor = this.mEditLayer.FeatureClass.Search(filter, false);
                        for (IFeature feature = cursor.NextFeature(); feature != null; feature = cursor.NextFeature())
                        {
                            string name = strArray[3];
                            int index = feature.Fields.FindField(name);
                            bool flag = false;
                            for (int j = 0; j < combox.Properties.Items.Count; j++)
                            {
                                if (combox.Properties.Items[j].ToString() == feature.get_Value(index).ToString())
                                {
                                    flag = true;
                                    break;
                                }
                            }
                            if (!flag)
                            {
                                combox.Properties.Items.Add(feature.get_Value(index).ToString());
                            }
                        }
                        combox.Tag = this.comboBoxVillage.Tag;
                    }
                    else if (combox.Name.Contains("Xiaoban"))
                    {
                        string str4 = strArray[4];
                        IQueryFilter filter2 = new QueryFilterClass();
                        filter2.WhereClause = str + "='" + code + "' and " + strArray[3] + "='" + this.comboBoxLinban.Text + "'";
                        IQueryFilterDefinition definition2 = (IQueryFilterDefinition) filter2;
                        definition2.PostfixClause = "ORDER BY XIAO_BAN";
                        IFeatureCursor cursor2 = this.mEditLayer.FeatureClass.Search(filter2, false);
                        for (IFeature feature2 = cursor2.NextFeature(); feature2 != null; feature2 = cursor2.NextFeature())
                        {
                            int num4 = feature2.Fields.FindField(str4);
                            bool flag2 = false;
                            for (int k = 0; k < combox.Properties.Items.Count; k++)
                            {
                                if (combox.Properties.Items[k].ToString() == feature2.get_Value(num4).ToString())
                                {
                                    flag2 = true;
                                    break;
                                }
                            }
                            if (!flag2)
                            {
                                combox.Properties.Items.Add(feature2.get_Value(num4).ToString());
                            }
                        }
                        combox.Tag = this.comboBoxVillage.Tag;
                    }
                    else if (combox.Name.Contains("Xiban"))
                    {
                        string str5 = strArray[strArray.Length - 1];
                        IQueryFilter filter3 = new QueryFilterClass();
                        filter3.WhereClause = str + "='" + code + "' and " + strArray[3] + "='" + this.comboBoxLinban.Text + "' and " + strArray[4] + "='" + this.comboBoxXiaoban.Text + "'";
                        IQueryFilterDefinition definition3 = (IQueryFilterDefinition) filter3;
                        definition3.PostfixClause = "ORDER BY XI_BAN";
                        IFeatureCursor cursor3 = this.mEditLayer.FeatureClass.Search(filter3, false);
                        for (IFeature feature3 = cursor3.NextFeature(); feature3 != null; feature3 = cursor3.NextFeature())
                        {
                            int num6 = feature3.Fields.FindField(str5);
                            bool flag3 = false;
                            for (int m = 0; m < combox.Properties.Items.Count; m++)
                            {
                                if (combox.Properties.Items[m].ToString() == feature3.get_Value(num6).ToString())
                                {
                                    flag3 = true;
                                    break;
                                }
                            }
                            if (!flag3)
                            {
                                combox.Properties.Items.Add(feature3.get_Value(num6).ToString());
                            }
                        }
                        combox.Tag = this.comboBoxVillage.Tag;
                    }
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "QueryAnalysic.UserControlQueryHZ", "SetDist", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void simpleButtonBack_Click(object sender, EventArgs e)
        {
            this.groupControlResult.Visible = false;
            this.groupControlDist.Visible = true;
            this.groupControlDist.Dock = DockStyle.Fill;
            this.groupControlDist.BringToFront();
        }

        private void simpleButtonInfo_Click(object sender, EventArgs e)
        {
            this.mQueryResult.InitialQueryInfo(this.mHookHelper, this.mEditLayer, this.mQueryList, null, "", null, null);
            this.mDockPanel.Visibility = DockVisibility.Visible;
            this.mDockPanel.Text = "火灾查询结果属性信息列表";
        }

        private void simpleButtonMore_Click(object sender, EventArgs e)
        {
            this.panelMore.Visible = !this.panelMore.Visible;
            if (this.panelMore.Visible)
            {
                this.simpleButtonMore.Text = "简化";
            }
            else
            {
                this.simpleButtonMore.Text = "更多";
            }
        }

        private void simpleButtonReset_Click(object sender, EventArgs e)
        {
            this.InitialDist();
            this.InitialDicCom();
        }

        private void simpleButtonSelect_Click(object sender, EventArgs e)
        {
            if ((this.mQueryList != null) && (this.mQueryList.Count != 0))
            {
                for (int i = 0; i < this.mQueryList.Count; i++)
                {
                    IFeature feature = this.mQueryList[i] as IFeature;
                    this.mHookHelper.FocusMap.SelectFeature(this.mEditLayer, feature);
                    this.mHookHelper.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeoSelection, null, feature.Shape.Envelope);
                }
            }
        }

        private void treeList_DoubleClick(object sender, EventArgs e)
        {
        }

        private void treeList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (((this.mQueryList != null) && (this.mQueryList.Count != 0)) && (this.treeList.Selection.Count != 0))
                {
                    int id = this.treeList.Selection[0].Id;
                    IFeature feature = this.mQueryList[id] as IFeature;
                    this.mMap.ClearSelection();
                    this.mMap.SelectFeature(this.mEditLayer, feature);
                    GISFunFactory.FeatureFun.ZoomToFeature(this.mMap, feature);
                }
            }
            catch (Exception)
            {
            }
        }
    }
}

