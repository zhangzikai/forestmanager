namespace QueryAnalysic
{
    using DataEdit;
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
    using ESRI.ArcGIS.DataSourcesFile;
    using ESRI.ArcGIS.esriSystem;
    using ESRI.ArcGIS.Geodatabase;
    using ESRI.ArcGIS.Geometry;
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

    public class UserControlQueryXB : UserControlBase1
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
        private ComboBoxEdit comboBoxC1;
        private ComboBoxEdit comboBoxC2;
        private ComboBoxEdit comboBoxC3;
        private ComboBoxEdit comboBoxC4;
        private ComboBoxEdit comboBoxC5;
        private ComboBoxEdit comboBoxC6;
        private ComboBoxEdit comboBoxC7;
        private ComboBoxEdit comboBoxChangeKind;
        private ComboBoxEdit comboBoxChangeState;
        private ComboBoxEdit comboBoxCounty;
        private ComboBoxEdit comboBoxL1;
        private ComboBoxEdit comboBoxL4;
        private ComboBoxEdit comboBoxLinban;
        private ComboBoxEdit comboBoxTown;
        private ComboBoxEdit comboBoxVillage;
        private ComboBoxEdit comboBoxXiaoban;
        private ComboBoxEdit comboBoxXiBan;
        private IContainer components;
        private GroupControl groupControlDist;
        private GroupControl groupControlResult;
        private Label label1;
        private Label label10;
        private Label label11;
        private Label label12;
        private Label label13;
        private Label label14;
        private Label label15;
        private Label label16;
        private Label label17;
        private Label label18;
        private Label label19;
        private Label label2;
        private Label label20;
        private Label label21;
        private Label label22;
        private Label label23;
        private Label label24;
        private Label label25;
        private Label label26;
        private Label label28;
        private Label label29;
        private Label label3;
        private Label label30;
        private Label label31;
        private Label label32;
        private Label label33;
        private Label label34;
        private Label label35;
        private Label label36;
        private Label label37;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label labelinfo;
        public Label labelLocation;
        private const string mClassName = "QueryAnalysic.UserControlQueryXB";
      
        private DockPanel mDockPanel;
        private IFeatureLayer mEditLayer;
        private ErrorOpt mErrOpt = UtilFactory.GetErrorOpt();
        private ArrayList mFeatureList;
        private IHookHelper mHookHelper;
        private IMap mMap;
        private ArrayList mNameList;
        private ArrayList mQueryList;
        private QueryCommon.UserControlQueryResult mQueryResult;
        private string mQueryString = "";
        private string mSubSysName = UtilFactory.GetConfigOpt().GetSystemName();
        private Panel panel1;
        private Panel panel10;
        private Panel panel11;
        private Panel panel12;
        private Panel panel13;
        private Panel panel14;
        private Panel panel15;
        private Panel panel16;
        private Panel panel17;
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
        private Panel panel29;
        private Panel panel3;
        private Panel panel30;
        private Panel panel31;
        private Panel panel32;
        private Panel panel33;
        private Panel panel34;
        private Panel panel35;
        private Panel panel36;
        private Panel panel37;
        private Panel panel38;
        private Panel panel39;
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
        private SimpleButton simpleButton2;
        private SimpleButton simpleButtonBack;
        private SimpleButton simpleButtonInfo;
        private SimpleButton simpleButtonMore;
        private SimpleButton simpleButtonOutput;
        public SimpleButton simpleButtonSelect;
        private SpinEdit spinEditL2;
        private SpinEdit spinEditL22;
        private SpinEdit spinEditL3;
        private SpinEdit spinEditL33;
        private SpinEdit spinEditL5;
        private SpinEdit spinEditL55;
        private SpinEdit spinEditL6;
        private SpinEdit spinEditL66;
        private SpinEdit spinEditL7;
        private SpinEdit spinEditL77;
        private TreeList treeList;
        private TreeListColumn treeListColumn1;
        private TreeListColumn treeListColumn2;
        private XtraTabControl xtraTabControl1;
        private XtraTabPage xtraTabPage1;
        private XtraTabPage xtraTabPage2;
        private XtraTabPage xtraTabPage3;

        public UserControlQueryXB()
        {
            this.InitializeComponent();
        }

        private void ButtonFind_Click(object sender, EventArgs e)
        {
            this.DoFind();
            this.groupControlDist.Visible = false;
            this.groupControlResult.Dock = DockStyle.Fill;
            this.groupControlResult.Visible = true;
            this.groupControlResult.BringToFront();
        }

        private void comboBoxB7_SelectedIndexChanged(object sender, EventArgs e)
        {
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
                    this.comboBoxXiBan.Properties.Items.Clear();
                    this.comboBoxXiBan.Properties.Items.Add("--");
                    this.comboBoxXiBan.Text = "--";
                    if (edit.SelectedIndex > 0)
                    {
                        ArrayList list5 = this.comboBoxXiaoban.Tag as ArrayList;
                        if (rowArray != null)
                        {
                            this.SetDist(rowArray[this.comboBoxVillage.SelectedIndex - 1]["code"].ToString(), list5[0] as DataTable, this.comboBoxXiBan);
                        }
                        else
                        {
                            this.SetDist(table.Rows[edit.SelectedIndex - 1]["code"].ToString(), null, this.comboBoxXiBan);
                        }
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        private IFeatureClass CreateFeatureClass(IFeatureWorkspace pfw, string sName)
        {
            try
            {
                IFields inputField = new FieldsClass();
                IFieldsEdit edit = (IFieldsEdit) inputField;
                IField field = new FieldClass();
                IFieldEdit edit2 = (IFieldEdit) field;
                edit2.Name_2 = "OID";
                edit2.Type_2 = esriFieldType.esriFieldTypeOID;
                edit.AddField(field);
                IGeometryDef def = new GeometryDefClass();
                IGeometryDefEdit edit3 = (IGeometryDefEdit) def;
                edit3.GeometryType_2 = esriGeometryType.esriGeometryPoint;
                new SpatialReferenceEnvironmentClass();
                ISpatialReference spatialReference = this.mHookHelper.FocusMap.SpatialReference;
                ((ISpatialReferenceResolution) spatialReference).ConstructFromHorizon();
                ((ISpatialReferenceTolerance) spatialReference).SetDefaultXYTolerance();
                edit3.SpatialReference_2 = spatialReference;
                IField field2 = new FieldClass();
                IFieldEdit edit4 = (IFieldEdit) field2;
                edit4.Name_2 = "Shape";
                edit4.Type_2 = esriFieldType.esriFieldTypeGeometry;
                edit4.GeometryDef_2 = def;
                edit.AddField(field2);
                IField field3 = new FieldClass();
                IFieldEdit edit5 = (IFieldEdit) field3;
                edit5.Name_2 = "ID";
                edit5.Type_2 = esriFieldType.esriFieldTypeString;
                edit5.Length_2 = 50;
                edit.AddField(field3);
                IField field4 = new FieldClass();
                IFieldEdit edit6 = (IFieldEdit) field4;
                edit6.Name_2 = "X坐标";
                edit6.Type_2 = esriFieldType.esriFieldTypeString;
                edit6.Length_2 = 50;
                edit.AddField(edit6);
                IField field5 = new FieldClass();
                IFieldEdit edit7 = (IFieldEdit) field5;
                edit7.Name_2 = "Y坐标";
                edit7.Type_2 = esriFieldType.esriFieldTypeString;
                edit7.Length_2 = 50;
                edit.AddField(edit7);
                IField field6 = new FieldClass();
                IFieldEdit edit8 = (IFieldEdit) field6;
                edit8.Name_2 = "时间";
                edit8.Type_2 = esriFieldType.esriFieldTypeString;
                edit8.Length_2 = 50;
                edit.AddField(edit8);
                IFieldChecker checker = new FieldCheckerClass();
                IEnumFieldError error = null;
                IFields fixedFields = null;
                checker.ValidateWorkspace = (IWorkspace) pfw;
                checker.Validate(inputField, out error, out fixedFields);
                return pfw.CreateFeatureClass(sName, fixedFields, null, null, esriFeatureType.esriFTSimple, "Shape", "");
            }
            catch (Exception)
            {
                return null;
            }
        }

        private IFeatureWorkspace CreateShapefile(string sPath, string sName, esriGeometryType pType, ISpatialReference pSpReference)
        {
            try
            {
                IWorkspaceFactory factory = new ShapefileWorkspaceFactoryClass();
                factory.OpenFromFile(sPath, 1);
                IWorkspaceFactory2 factory2 = new ShapefileWorkspaceFactoryClass();
                IName name2 = (IName) factory2.Create(sPath + @"\", sName.Split(new char[] { '.' })[0], null, 0);
                IWorkspace workspace = (IWorkspace) name2.Open();
                return (workspace as IFeatureWorkspace);
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "QueryAnalysic.UserControlQueryXB", "CreateShapeFile", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                return null;
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
                string[] strArray = UtilFactory.GetConfigOpt().GetConfigValue("XBFieldName2").Split(new char[] { ',' });
                DataTable table = (this.comboBoxCounty.Tag as ArrayList)[0] as DataTable;
                if (((this.comboBoxCounty.SelectedIndex == 0) && (this.comboBoxTown.SelectedIndex == 0)) && (this.comboBoxVillage.SelectedIndex == 0))
                {
                    str = "";
                    if ((this.comboBoxLinban.SelectedIndex > 0) || ((this.comboBoxLinban.Text != "") && (this.comboBoxLinban.Text != "--")))
                    {
                        if (str != "")
                        {
                            str = str + " and " + strArray[3] + "='" + this.comboBoxLinban.Text + "'";
                        }
                        else
                        {
                            str = strArray[3] + "='" + this.comboBoxLinban.Text + "'";
                        }
                    }
                    if ((this.comboBoxXiaoban.SelectedIndex > 0) || ((this.comboBoxXiaoban.Text != "") && (this.comboBoxXiaoban.Text != "--")))
                    {
                        if (str != "")
                        {
                            str = str + " and " + strArray[4] + "='" + this.comboBoxXiaoban.Text + "'";
                        }
                        else
                        {
                            str = strArray[4] + "='" + this.comboBoxXiaoban.Text + "'";
                        }
                    }
                }
                else
                {
                    if (this.comboBoxCounty.SelectedIndex > 0)
                    {
                        str = string.Concat(new object[] { strArray[0], "='", table.Rows[this.comboBoxCounty.SelectedIndex - 1]["code"], "'" });
                    }
                    object obj1 = (this.comboBoxTown.Tag as ArrayList)[0];
                    if (this.comboBoxTown.SelectedIndex > 0)
                    {
                        DataRow[] rowArray = (this.comboBoxTown.Tag as ArrayList)[1] as DataRow[];
                        if (this.comboBoxTown.SelectedIndex > 0)
                        {
                            str = string.Concat(new object[] { str, " and ", strArray[1], "='", rowArray[this.comboBoxTown.SelectedIndex - 1]["code"], "'" });
                        }
                        object obj2 = (this.comboBoxVillage.Tag as ArrayList)[0];
                        if (this.comboBoxVillage.SelectedIndex > 0)
                        {
                            DataRow[] rowArray2 = (this.comboBoxVillage.Tag as ArrayList)[1] as DataRow[];
                            str = string.Concat(new object[] { str, " and ", strArray[2], "='", rowArray2[this.comboBoxVillage.SelectedIndex - 1]["code"], "'" });
                            object obj3 = (this.comboBoxLinban.Tag as ArrayList)[0];
                            if (this.comboBoxLinban.SelectedIndex > 0)
                            {
                                object obj4 = (this.comboBoxLinban.Tag as ArrayList)[1];
                                str = str + " and " + strArray[3] + "='" + this.comboBoxLinban.Text + "'";
                                if (this.comboBoxXiaoban.SelectedIndex > 0)
                                {
                                    str = str + " and " + strArray[4] + "='" + this.comboBoxXiaoban.Text + "'";
                                }
                            }
                        }
                    }
                }
                if (this.comboBoxChangeKind.SelectedIndex > 0)
                {
                    DataTable table2 = (this.comboBoxChangeKind.Tag as ArrayList)[0] as DataTable;
                    if (this.comboBoxChangeKind.SelectedIndex > 1)
                    {
                        if (str == "")
                        {
                            str = "BHYY = '" + table2.Rows[this.comboBoxChangeKind.SelectedIndex - 2]["code"].ToString() + "'";
                        }
                        else
                        {
                            str = str + " and BHYY = '" + table2.Rows[this.comboBoxChangeKind.SelectedIndex - 1]["code"].ToString() + "'";
                        }
                    }
                    else if (this.comboBoxChangeKind.SelectedIndex == 1)
                    {
                        if (str == "")
                        {
                            str = "(BHYY = 'null' or BHYY = '')";
                        }
                        else
                        {
                            str = str + " and (BHYY = 'null' or BHYY = '')";
                        }
                    }
                }
                if (this.panelMore.Visible)
                {
                    ArrayList list = new ArrayList();
                    list.Add(this.comboBoxC5);
                    list.Add(this.comboBoxC6);
                    list.Add(this.comboBoxC7);
                    list.Add(this.comboBoxC1);
                    list.Add(this.comboBoxC2);
                    list.Add(this.comboBoxC3);
                    list.Add(this.comboBoxB1);
                    list.Add(this.comboBoxB2);
                    list.Add(this.comboBoxB3);
                    list.Add(this.comboBoxB4);
                    list.Add(this.comboBoxB5);
                    list.Add(this.comboBoxB6);
                    list.Add(this.comboBoxB7);
                    list.Add(this.comboBoxB8);
                    list.Add(this.comboBoxL1);
                    list.Add(this.comboBoxL4);
                    for (int j = 0; j < list.Count; j++)
                    {
                        ComboBoxEdit edit = list[j] as ComboBoxEdit;
                        ArrayList tag = edit.Tag as ArrayList;
                        if (tag != null)
                        {
                            DataTable table3 = tag[0] as DataTable;
                            if (edit.SelectedIndex > 0)
                            {
                                if (str != "")
                                {
                                    str = string.Concat(new object[] { str, " and ", tag[1], "='", table3.Rows[edit.SelectedIndex - 1]["code"], "'" });
                                }
                                else
                                {
                                    str = string.Concat(new object[] { tag[1], "='", table3.Rows[edit.SelectedIndex - 1]["code"], "'" });
                                }
                            }
                        }
                    }
                }
                QueryFilter filter = new QueryFilterClass();
                filter.WhereClause = str;
                this.mQueryString = str;
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
                    IQueryFilterDefinition definition = (IQueryFilterDefinition) filter;
                    definition.PostfixClause = "ORDER BY CUN,LIN_BAN,XIAO_BAN";
                }
                IFeatureCursor cursor = this.mEditLayer.FeatureClass.Search(filter, false);
                IFeature pFeature = cursor.NextFeature();
                this.Cursor = Cursors.WaitCursor;
                this.treeList.Nodes.Clear();
                this.treeList.Columns[0].Width = this.treeList.Width - 20;
                this.treeList.Columns[1].Width = 0x10;
                this.Cursor = Cursors.WaitCursor;
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
                        goto Label_098B;
                    }
                    pFeature = cursor.NextFeature();
                }
                if (num4 == 0)
                {
                    this.labelinfo.Text = "      未找到符合条件的小班";
                    this.labelinfo.Visible = true;
                    this.Cursor = Cursors.Default;
                }
                else
                {
                    this.labelinfo.Text = "      找到 " + num4 + " 个小班";
                    this.labelinfo.Visible = true;
                    this.Cursor = Cursors.Default;
                }
                return;
            Label_098B:
                this.labelinfo.Text = "      请缩小查询范围，找到 大于" + num4 + " 个小班";
                this.labelinfo.Visible = true;
                this.Cursor = Cursors.Default;
            }
            catch (Exception)
            {
                this.Cursor = Cursors.Default;
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

        private string GetXBName(IFeature pFeature)
        {
            try
            {
                string[] strArray = UtilFactory.GetConfigOpt().GetConfigValue("XBFieldName2").Split(new char[] { ',' });
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
                            str = str + this.GetDistName(pFeature.get_Value(index).ToString(), false);
                        }
                        else if (pFeature.get_Value(index).ToString().Length == 9)
                        {
                            str = str + this.GetDistName(pFeature.get_Value(index).ToString(), false);
                        }
                        else if (pFeature.get_Value(index).ToString().Length == 12)
                        {
                            str = str + this.GetDistName(pFeature.get_Value(index).ToString(), false);
                        }
                        else if ((pFeature.get_Value(index).ToString().Length <= 4) && (i == 3))
                        {
                            str = str + pFeature.get_Value(index) + "林班";
                        }
                        else if ((pFeature.get_Value(index).ToString().Length <= 4) && (i == 4))
                        {
                            str = str + pFeature.get_Value(index) + "小班";
                        }
                        else if (pFeature.get_Value(index).ToString() != "")
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

        private void groupControlDist_Paint(object sender, PaintEventArgs e)
        {
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
                    int num2 = 0;
                    try
                    {
                        num2 = int.Parse(edit.Name.Substring(edit.Name.Length - 1, 1));
                    }
                    catch (Exception)
                    {
                    }
                    if (num2 >= 1)
                    {
                        int index = this.mEditLayer.FeatureClass.Fields.FindField(arr[num2 - 1]);
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
                                list2.Add(arr[num2 - 1]);
                                edit.Tag = list2;
                            }
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "QueryAnalysic.UserControlQueryXB", "InitialCombox", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void InitialDicCom()
        {
            try
            {
                ArrayList list = new ArrayList();
                list.Add(this.comboBoxC1);
                list.Add(this.comboBoxC2);
                list.Add(this.comboBoxC3);
                list.Add(this.comboBoxC4);
                list.Add(this.comboBoxC5);
                list.Add(this.comboBoxC6);
                list.Add(this.comboBoxC7);
                string[] arr = UtilFactory.GetConfigOpt().GetConfigValue("XBFieldNameC").Split(new char[] { ',' });
                this.InitialCombox(arr, list);
                list = new ArrayList();
                list.Add(this.comboBoxB1);
                list.Add(this.comboBoxB2);
                list.Add(this.comboBoxB3);
                list.Add(this.comboBoxB6);
                list.Add(this.comboBoxB5);
                list.Add(this.comboBoxB4);
                list.Add(this.comboBoxB7);
                list.Add(this.comboBoxB8);
                arr = UtilFactory.GetConfigOpt().GetConfigValue("XBFieldNameB").Split(new char[] { ',' });
                this.InitialCombox(arr, list);
                list = new ArrayList();
                list.Add(this.comboBoxL1);
                list.Add(this.comboBoxL4);
                arr = UtilFactory.GetConfigOpt().GetConfigValue("XBFieldNameL").Split(new char[] { ',' });
                this.InitialCombox(arr, list);
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "QueryAnalysic.UserControlQueryXB", "InitialDicCom", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void InitialDist()
        {
            try
            {
                DataTable table;
                DataColumn column;

                IFeatureWorkspace editWorkspace = EditTask.EditWorkspace;
                IWorkspace workspace2 = editWorkspace as IWorkspace;
                IWorkspaceDomains domains = workspace2 as IWorkspaceDomains;
                UtilFactory.GetConfigOpt().GetConfigValue("XBFieldNameD").Split(new char[] { ',' });
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
                    if (EditTask.DistCode != "")
                    {
                        queryFilter.WhereClause = queryFilter.WhereClause + " and " + str3 + " like '" + EditTask.DistCode.Substring(0, 6) + "%'";
                    }
                    ICursor cursor = table2.Search(queryFilter, false);
                    IRow row = cursor.NextRow();
                    table = new DataTable();
                    column = new DataColumn("code", typeof(string));
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
                ArrayList list3 = new ArrayList();
                list3.Add(table3);
                this.comboBoxLinban.Tag = list3;
                this.comboBoxXiaoban.Tag = list3;
                this.comboBoxChangeKind.Properties.Items.Clear();
                this.comboBoxChangeKind.Properties.Items.Add("--");
                this.comboBoxChangeKind.Properties.Items.Add("无变化原因");
                ICodedValueDomain domain2 = domains.get_DomainByName("BHYY") as ICodedValueDomain;
                this.comboBoxChangeKind.Tag = domain2;
                table = new DataTable();
                column = new DataColumn("code", typeof(string));
                table.Columns.Add(column);
                column = new DataColumn("name", typeof(string));
                table.Columns.Add(column);
                for (int j = 0; j < domain2.CodeCount; j++)
                {
                    this.comboBoxChangeKind.Properties.Items.Add(domain2.get_Name(j));
                    DataRow row3 = table.NewRow();
                    row3["code"] = domain2.get_Value(j);
                    row3["name"] = domain2.get_Name(j);
                    table.Rows.Add(row3);
                }
                if (table.Rows.Count > 1)
                {
                    this.comboBoxChangeKind.SelectedIndex = 0;
                    ArrayList list4 = new ArrayList();
                    list4.Add(table);
                    this.comboBoxChangeKind.Tag = list4;
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "QueryAnalysic.UserControlQueryXB", "InitializeGISControls", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserControlQueryXB));
            this.comboBoxXiaoban = new DevExpress.XtraEditors.ComboBoxEdit();
            this.panel6 = new System.Windows.Forms.Panel();
            this.comboBoxLinban = new DevExpress.XtraEditors.ComboBoxEdit();
            this.panel1 = new System.Windows.Forms.Panel();
            this.comboBoxVillage = new DevExpress.XtraEditors.ComboBoxEdit();
            this.panel12 = new System.Windows.Forms.Panel();
            this.comboBoxTown = new DevExpress.XtraEditors.ComboBoxEdit();
            this.comboBoxCounty = new DevExpress.XtraEditors.ComboBoxEdit();
            this.panel14 = new System.Windows.Forms.Panel();
            this.groupControlDist = new DevExpress.XtraEditors.GroupControl();
            this.panel2 = new System.Windows.Forms.Panel();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.panel33 = new System.Windows.Forms.Panel();
            this.simpleButtonMore = new DevExpress.XtraEditors.SimpleButton();
            this.panel32 = new System.Windows.Forms.Panel();
            this.ButtonFind = new DevExpress.XtraEditors.SimpleButton();
            this.panelMore = new System.Windows.Forms.Panel();
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.panel8 = new System.Windows.Forms.Panel();
            this.comboBoxC7 = new DevExpress.XtraEditors.ComboBoxEdit();
            this.label6 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.comboBoxC6 = new DevExpress.XtraEditors.ComboBoxEdit();
            this.label19 = new System.Windows.Forms.Label();
            this.panel16 = new System.Windows.Forms.Panel();
            this.comboBoxC5 = new DevExpress.XtraEditors.ComboBoxEdit();
            this.label12 = new System.Windows.Forms.Label();
            this.panel29 = new System.Windows.Forms.Panel();
            this.comboBoxC4 = new DevExpress.XtraEditors.ComboBoxEdit();
            this.label29 = new System.Windows.Forms.Label();
            this.panel17 = new System.Windows.Forms.Panel();
            this.comboBoxC3 = new DevExpress.XtraEditors.ComboBoxEdit();
            this.label13 = new System.Windows.Forms.Label();
            this.panel15 = new System.Windows.Forms.Panel();
            this.comboBoxC2 = new DevExpress.XtraEditors.ComboBoxEdit();
            this.label11 = new System.Windows.Forms.Label();
            this.panel13 = new System.Windows.Forms.Panel();
            this.comboBoxC1 = new DevExpress.XtraEditors.ComboBoxEdit();
            this.label10 = new System.Windows.Forms.Label();
            this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
            this.panel36 = new System.Windows.Forms.Panel();
            this.comboBoxB8 = new DevExpress.XtraEditors.ComboBoxEdit();
            this.label33 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.comboBoxB7 = new DevExpress.XtraEditors.ComboBoxEdit();
            this.label20 = new System.Windows.Forms.Label();
            this.panel22 = new System.Windows.Forms.Panel();
            this.comboBoxB6 = new DevExpress.XtraEditors.ComboBoxEdit();
            this.label21 = new System.Windows.Forms.Label();
            this.panel23 = new System.Windows.Forms.Panel();
            this.comboBoxB5 = new DevExpress.XtraEditors.ComboBoxEdit();
            this.label22 = new System.Windows.Forms.Label();
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
            this.xtraTabPage3 = new DevExpress.XtraTab.XtraTabPage();
            this.panel38 = new System.Windows.Forms.Panel();
            this.spinEditL77 = new DevExpress.XtraEditors.SpinEdit();
            this.label36 = new System.Windows.Forms.Label();
            this.spinEditL7 = new DevExpress.XtraEditors.SpinEdit();
            this.label37 = new System.Windows.Forms.Label();
            this.panel37 = new System.Windows.Forms.Panel();
            this.spinEditL66 = new DevExpress.XtraEditors.SpinEdit();
            this.label34 = new System.Windows.Forms.Label();
            this.spinEditL6 = new DevExpress.XtraEditors.SpinEdit();
            this.label35 = new System.Windows.Forms.Label();
            this.panel26 = new System.Windows.Forms.Panel();
            this.spinEditL55 = new DevExpress.XtraEditors.SpinEdit();
            this.label25 = new System.Windows.Forms.Label();
            this.spinEditL5 = new DevExpress.XtraEditors.SpinEdit();
            this.label26 = new System.Windows.Forms.Label();
            this.panel28 = new System.Windows.Forms.Panel();
            this.comboBoxL4 = new DevExpress.XtraEditors.ComboBoxEdit();
            this.label28 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.spinEditL33 = new DevExpress.XtraEditors.SpinEdit();
            this.label4 = new System.Windows.Forms.Label();
            this.spinEditL3 = new DevExpress.XtraEditors.SpinEdit();
            this.label5 = new System.Windows.Forms.Label();
            this.panel21 = new System.Windows.Forms.Panel();
            this.spinEditL22 = new DevExpress.XtraEditors.SpinEdit();
            this.label18 = new System.Windows.Forms.Label();
            this.spinEditL2 = new DevExpress.XtraEditors.SpinEdit();
            this.label17 = new System.Windows.Forms.Label();
            this.panel20 = new System.Windows.Forms.Panel();
            this.comboBoxL1 = new DevExpress.XtraEditors.ComboBoxEdit();
            this.label16 = new System.Windows.Forms.Label();
            this.panelbasic = new System.Windows.Forms.Panel();
            this.panelDistLocation = new System.Windows.Forms.Panel();
            this.panel10 = new System.Windows.Forms.Panel();
            this.comboBoxChangeState = new DevExpress.XtraEditors.ComboBoxEdit();
            this.panel35 = new System.Windows.Forms.Panel();
            this.comboBoxChangeKind = new DevExpress.XtraEditors.ComboBoxEdit();
            this.panel31 = new System.Windows.Forms.Panel();
            this.comboBoxXiBan = new DevExpress.XtraEditors.ComboBoxEdit();
            this.panel30 = new System.Windows.Forms.Panel();
            this.panel11 = new System.Windows.Forms.Panel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.label31 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.treeListColumn2 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.repositoryItemPopupContainerEdit3 = new DevExpress.XtraEditors.Repository.RepositoryItemPopupContainerEdit();
            this.treeListColumn1 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.repositoryItemImageEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemImageEdit();
            this.panel5 = new System.Windows.Forms.Panel();
            this.simpleButtonSelect = new DevExpress.XtraEditors.SimpleButton();
            this.panel39 = new System.Windows.Forms.Panel();
            this.simpleButtonInfo = new DevExpress.XtraEditors.SimpleButton();
            this.panel34 = new System.Windows.Forms.Panel();
            this.simpleButtonOutput = new DevExpress.XtraEditors.SimpleButton();
            this.panel27 = new System.Windows.Forms.Panel();
            this.simpleButtonBack = new DevExpress.XtraEditors.SimpleButton();
            this.labelinfo = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.treeList = new DevExpress.XtraTreeList.TreeList();
            this.groupControlResult = new DevExpress.XtraEditors.GroupControl();
            this.labelLocation = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxXiaoban.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxLinban.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxVillage.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxTown.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxCounty.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlDist)).BeginInit();
            this.groupControlDist.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panelMore.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
            this.panel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxC7.Properties)).BeginInit();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxC6.Properties)).BeginInit();
            this.panel16.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxC5.Properties)).BeginInit();
            this.panel29.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxC4.Properties)).BeginInit();
            this.panel17.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxC3.Properties)).BeginInit();
            this.panel15.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxC2.Properties)).BeginInit();
            this.panel13.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxC1.Properties)).BeginInit();
            this.xtraTabPage2.SuspendLayout();
            this.panel36.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxB8.Properties)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxB7.Properties)).BeginInit();
            this.panel22.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxB6.Properties)).BeginInit();
            this.panel23.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxB5.Properties)).BeginInit();
            this.panel24.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxB4.Properties)).BeginInit();
            this.panel19.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxB3.Properties)).BeginInit();
            this.panel25.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxB2.Properties)).BeginInit();
            this.panel18.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxB1.Properties)).BeginInit();
            this.xtraTabPage3.SuspendLayout();
            this.panel38.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditL77.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditL7.Properties)).BeginInit();
            this.panel37.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditL66.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditL6.Properties)).BeginInit();
            this.panel26.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditL55.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditL5.Properties)).BeginInit();
            this.panel28.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxL4.Properties)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditL33.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditL3.Properties)).BeginInit();
            this.panel21.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditL22.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditL2.Properties)).BeginInit();
            this.panel20.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxL1.Properties)).BeginInit();
            this.panelbasic.SuspendLayout();
            this.panelDistLocation.SuspendLayout();
            this.panel10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxChangeState.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxChangeKind.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxXiBan.Properties)).BeginInit();
            this.panel9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPopupContainerEdit3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageEdit1)).BeginInit();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlResult)).BeginInit();
            this.groupControlResult.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBoxXiaoban
            // 
            this.comboBoxXiaoban.Dock = System.Windows.Forms.DockStyle.Top;
            this.comboBoxXiaoban.Location = new System.Drawing.Point(0, 105);
            this.comboBoxXiaoban.Name = "comboBoxXiaoban";
            this.comboBoxXiaoban.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxXiaoban.Size = new System.Drawing.Size(147, 20);
            this.comboBoxXiaoban.TabIndex = 15;
            this.comboBoxXiaoban.TextChanged += new System.EventHandler(this.comboBoxBase_TextChanged);
            // 
            // panel6
            // 
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 100);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(147, 5);
            this.panel6.TabIndex = 14;
            // 
            // comboBoxLinban
            // 
            this.comboBoxLinban.Dock = System.Windows.Forms.DockStyle.Top;
            this.comboBoxLinban.Location = new System.Drawing.Point(0, 80);
            this.comboBoxLinban.Name = "comboBoxLinban";
            this.comboBoxLinban.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxLinban.Size = new System.Drawing.Size(147, 20);
            this.comboBoxLinban.TabIndex = 13;
            this.comboBoxLinban.TextChanged += new System.EventHandler(this.comboBoxBase_TextChanged);
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 75);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(147, 5);
            this.panel1.TabIndex = 12;
            // 
            // comboBoxVillage
            // 
            this.comboBoxVillage.Dock = System.Windows.Forms.DockStyle.Top;
            this.comboBoxVillage.Location = new System.Drawing.Point(0, 55);
            this.comboBoxVillage.Name = "comboBoxVillage";
            this.comboBoxVillage.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxVillage.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.comboBoxVillage.Size = new System.Drawing.Size(147, 20);
            this.comboBoxVillage.TabIndex = 11;
            this.comboBoxVillage.TextChanged += new System.EventHandler(this.comboBoxBase_TextChanged);
            // 
            // panel12
            // 
            this.panel12.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel12.Location = new System.Drawing.Point(0, 50);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(147, 5);
            this.panel12.TabIndex = 7;
            // 
            // comboBoxTown
            // 
            this.comboBoxTown.Dock = System.Windows.Forms.DockStyle.Top;
            this.comboBoxTown.Location = new System.Drawing.Point(0, 30);
            this.comboBoxTown.Name = "comboBoxTown";
            this.comboBoxTown.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxTown.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.comboBoxTown.Size = new System.Drawing.Size(147, 20);
            this.comboBoxTown.TabIndex = 10;
            this.comboBoxTown.TextChanged += new System.EventHandler(this.comboBoxBase_TextChanged);
            // 
            // comboBoxCounty
            // 
            this.comboBoxCounty.Dock = System.Windows.Forms.DockStyle.Top;
            this.comboBoxCounty.Location = new System.Drawing.Point(0, 5);
            this.comboBoxCounty.Name = "comboBoxCounty";
            this.comboBoxCounty.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxCounty.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.comboBoxCounty.Size = new System.Drawing.Size(147, 20);
            this.comboBoxCounty.TabIndex = 9;
            this.comboBoxCounty.TextChanged += new System.EventHandler(this.comboBoxBase_TextChanged);
            // 
            // panel14
            // 
            this.panel14.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel14.Location = new System.Drawing.Point(0, 25);
            this.panel14.Name = "panel14";
            this.panel14.Size = new System.Drawing.Size(147, 5);
            this.panel14.TabIndex = 8;
            // 
            // groupControlDist
            // 
            this.groupControlDist.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.groupControlDist.Appearance.Options.UseBackColor = true;
            this.groupControlDist.AutoSize = true;
            this.groupControlDist.Controls.Add(this.panel2);
            this.groupControlDist.Controls.Add(this.panelMore);
            this.groupControlDist.Controls.Add(this.panelbasic);
            this.groupControlDist.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControlDist.Location = new System.Drawing.Point(4, 30);
            this.groupControlDist.Name = "groupControlDist";
            this.groupControlDist.Padding = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.groupControlDist.Size = new System.Drawing.Size(238, 483);
            this.groupControlDist.TabIndex = 102;
            this.groupControlDist.Text = "查找条件";
            this.groupControlDist.Paint += new System.Windows.Forms.PaintEventHandler(this.groupControlDist_Paint);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.simpleButton2);
            this.panel2.Controls.Add(this.panel33);
            this.panel2.Controls.Add(this.simpleButtonMore);
            this.panel2.Controls.Add(this.panel32);
            this.panel2.Controls.Add(this.ButtonFind);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(6, 449);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.panel2.Size = new System.Drawing.Size(226, 32);
            this.panel2.TabIndex = 16;
            // 
            // simpleButton2
            // 
            this.simpleButton2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.simpleButton2.Dock = System.Windows.Forms.DockStyle.Right;
            this.simpleButton2.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton2.Image")));
            this.simpleButton2.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.simpleButton2.Location = new System.Drawing.Point(34, 4);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(60, 24);
            this.simpleButton2.TabIndex = 14;
            this.simpleButton2.Text = "重置";
            this.simpleButton2.ToolTip = "重新设置查询条件";
            // 
            // panel33
            // 
            this.panel33.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel33.Location = new System.Drawing.Point(94, 4);
            this.panel33.Name = "panel33";
            this.panel33.Size = new System.Drawing.Size(6, 24);
            this.panel33.TabIndex = 18;
            // 
            // simpleButtonMore
            // 
            this.simpleButtonMore.Cursor = System.Windows.Forms.Cursors.Hand;
            this.simpleButtonMore.Dock = System.Windows.Forms.DockStyle.Right;
            this.simpleButtonMore.Image = ((System.Drawing.Image)(resources.GetObject("simpleButtonMore.Image")));
            this.simpleButtonMore.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.simpleButtonMore.Location = new System.Drawing.Point(100, 4);
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
            this.panel32.Location = new System.Drawing.Point(160, 4);
            this.panel32.Name = "panel32";
            this.panel32.Size = new System.Drawing.Size(6, 24);
            this.panel32.TabIndex = 17;
            // 
            // ButtonFind
            // 
            this.ButtonFind.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonFind.Dock = System.Windows.Forms.DockStyle.Right;
            this.ButtonFind.Image = ((System.Drawing.Image)(resources.GetObject("ButtonFind.Image")));
            this.ButtonFind.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.ButtonFind.Location = new System.Drawing.Point(166, 4);
            this.ButtonFind.Name = "ButtonFind";
            this.ButtonFind.Size = new System.Drawing.Size(60, 24);
            this.ButtonFind.TabIndex = 12;
            this.ButtonFind.Text = "查找";
            this.ButtonFind.ToolTip = "小班查找";
            this.ButtonFind.Click += new System.EventHandler(this.ButtonFind_Click);
            // 
            // panelMore
            // 
            this.panelMore.AutoScroll = true;
            this.panelMore.Controls.Add(this.xtraTabControl1);
            this.panelMore.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelMore.Location = new System.Drawing.Point(6, 216);
            this.panelMore.Name = "panelMore";
            this.panelMore.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.panelMore.Size = new System.Drawing.Size(226, 233);
            this.panelMore.TabIndex = 17;
            this.panelMore.Visible = false;
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.AppearancePage.HeaderActive.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xtraTabControl1.AppearancePage.HeaderActive.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.xtraTabControl1.AppearancePage.HeaderActive.Options.UseFont = true;
            this.xtraTabControl1.AppearancePage.HeaderActive.Options.UseForeColor = true;
            this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl1.Location = new System.Drawing.Point(0, 2);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPage1;
            this.xtraTabControl1.Size = new System.Drawing.Size(226, 231);
            this.xtraTabControl1.TabIndex = 19;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage2,
            this.xtraTabPage3,
            this.xtraTabPage1});
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Controls.Add(this.panel8);
            this.xtraTabPage1.Controls.Add(this.panel7);
            this.xtraTabPage1.Controls.Add(this.panel16);
            this.xtraTabPage1.Controls.Add(this.panel29);
            this.xtraTabPage1.Controls.Add(this.panel17);
            this.xtraTabPage1.Controls.Add(this.panel15);
            this.xtraTabPage1.Controls.Add(this.panel13);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(220, 202);
            this.xtraTabPage1.Text = "区划等级";
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.comboBoxC7);
            this.panel8.Controls.Add(this.label6);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel8.Location = new System.Drawing.Point(0, 156);
            this.panel8.Name = "panel8";
            this.panel8.Padding = new System.Windows.Forms.Padding(2, 4, 6, 0);
            this.panel8.Size = new System.Drawing.Size(220, 26);
            this.panel8.TabIndex = 10;
            // 
            // comboBoxC7
            // 
            this.comboBoxC7.Dock = System.Windows.Forms.DockStyle.Top;
            this.comboBoxC7.EditValue = "--";
            this.comboBoxC7.Location = new System.Drawing.Point(94, 4);
            this.comboBoxC7.Name = "comboBoxC7";
            this.comboBoxC7.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxC7.Properties.Items.AddRange(new object[] {
            "--",
            "可编辑",
            "不可编辑",
            "已提交"});
            this.comboBoxC7.Size = new System.Drawing.Size(120, 20);
            this.comboBoxC7.TabIndex = 23;
            // 
            // label6
            // 
            this.label6.Dock = System.Windows.Forms.DockStyle.Left;
            this.label6.Location = new System.Drawing.Point(2, 4);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(92, 22);
            this.label6.TabIndex = 8;
            this.label6.Text = "工程类别";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.comboBoxC6);
            this.panel7.Controls.Add(this.label19);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel7.Location = new System.Drawing.Point(0, 130);
            this.panel7.Name = "panel7";
            this.panel7.Padding = new System.Windows.Forms.Padding(2, 4, 6, 0);
            this.panel7.Size = new System.Drawing.Size(220, 26);
            this.panel7.TabIndex = 19;
            // 
            // comboBoxC6
            // 
            this.comboBoxC6.Dock = System.Windows.Forms.DockStyle.Top;
            this.comboBoxC6.EditValue = "--";
            this.comboBoxC6.Location = new System.Drawing.Point(94, 4);
            this.comboBoxC6.Name = "comboBoxC6";
            this.comboBoxC6.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxC6.Properties.Items.AddRange(new object[] {
            "--",
            "可编辑",
            "不可编辑",
            "已提交"});
            this.comboBoxC6.Size = new System.Drawing.Size(120, 20);
            this.comboBoxC6.TabIndex = 23;
            // 
            // label19
            // 
            this.label19.Dock = System.Windows.Forms.DockStyle.Left;
            this.label19.Location = new System.Drawing.Point(2, 4);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(92, 22);
            this.label19.TabIndex = 8;
            this.label19.Text = "公益林保护等级";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel16
            // 
            this.panel16.Controls.Add(this.comboBoxC5);
            this.panel16.Controls.Add(this.label12);
            this.panel16.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel16.Location = new System.Drawing.Point(0, 104);
            this.panel16.Name = "panel16";
            this.panel16.Padding = new System.Windows.Forms.Padding(2, 4, 6, 0);
            this.panel16.Size = new System.Drawing.Size(220, 26);
            this.panel16.TabIndex = 13;
            // 
            // comboBoxC5
            // 
            this.comboBoxC5.Dock = System.Windows.Forms.DockStyle.Top;
            this.comboBoxC5.EditValue = "--";
            this.comboBoxC5.Location = new System.Drawing.Point(94, 4);
            this.comboBoxC5.Name = "comboBoxC5";
            this.comboBoxC5.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxC5.Properties.Items.AddRange(new object[] {
            "--",
            "可编辑",
            "不可编辑",
            "已提交"});
            this.comboBoxC5.Size = new System.Drawing.Size(120, 20);
            this.comboBoxC5.TabIndex = 22;
            // 
            // label12
            // 
            this.label12.Dock = System.Windows.Forms.DockStyle.Left;
            this.label12.Location = new System.Drawing.Point(2, 4);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(92, 22);
            this.label12.TabIndex = 8;
            this.label12.Text = "事权等级";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel29
            // 
            this.panel29.Controls.Add(this.comboBoxC4);
            this.panel29.Controls.Add(this.label29);
            this.panel29.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel29.Location = new System.Drawing.Point(0, 78);
            this.panel29.Name = "panel29";
            this.panel29.Padding = new System.Windows.Forms.Padding(2, 4, 6, 0);
            this.panel29.Size = new System.Drawing.Size(220, 26);
            this.panel29.TabIndex = 22;
            // 
            // comboBoxC4
            // 
            this.comboBoxC4.Dock = System.Windows.Forms.DockStyle.Top;
            this.comboBoxC4.EditValue = "--";
            this.comboBoxC4.Location = new System.Drawing.Point(94, 4);
            this.comboBoxC4.Name = "comboBoxC4";
            this.comboBoxC4.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxC4.Properties.Items.AddRange(new object[] {
            "--",
            "可编辑",
            "不可编辑",
            "已提交"});
            this.comboBoxC4.Size = new System.Drawing.Size(120, 20);
            this.comboBoxC4.TabIndex = 21;
            // 
            // label29
            // 
            this.label29.Dock = System.Windows.Forms.DockStyle.Left;
            this.label29.Location = new System.Drawing.Point(2, 4);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(92, 22);
            this.label29.TabIndex = 8;
            this.label29.Text = "主体功能区";
            this.label29.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel17
            // 
            this.panel17.Controls.Add(this.comboBoxC3);
            this.panel17.Controls.Add(this.label13);
            this.panel17.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel17.Location = new System.Drawing.Point(0, 52);
            this.panel17.Name = "panel17";
            this.panel17.Padding = new System.Windows.Forms.Padding(2, 4, 6, 0);
            this.panel17.Size = new System.Drawing.Size(220, 26);
            this.panel17.TabIndex = 21;
            // 
            // comboBoxC3
            // 
            this.comboBoxC3.Dock = System.Windows.Forms.DockStyle.Top;
            this.comboBoxC3.EditValue = "--";
            this.comboBoxC3.Location = new System.Drawing.Point(94, 4);
            this.comboBoxC3.Name = "comboBoxC3";
            this.comboBoxC3.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxC3.Properties.Items.AddRange(new object[] {
            "--",
            "可编辑",
            "不可编辑",
            "已提交"});
            this.comboBoxC3.Size = new System.Drawing.Size(120, 20);
            this.comboBoxC3.TabIndex = 21;
            // 
            // label13
            // 
            this.label13.Dock = System.Windows.Forms.DockStyle.Left;
            this.label13.Location = new System.Drawing.Point(2, 4);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(92, 22);
            this.label13.TabIndex = 8;
            this.label13.Text = "林地质量等级";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel15
            // 
            this.panel15.Controls.Add(this.comboBoxC2);
            this.panel15.Controls.Add(this.label11);
            this.panel15.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel15.Location = new System.Drawing.Point(0, 26);
            this.panel15.Name = "panel15";
            this.panel15.Padding = new System.Windows.Forms.Padding(2, 4, 6, 0);
            this.panel15.Size = new System.Drawing.Size(220, 26);
            this.panel15.TabIndex = 20;
            // 
            // comboBoxC2
            // 
            this.comboBoxC2.Dock = System.Windows.Forms.DockStyle.Top;
            this.comboBoxC2.EditValue = "--";
            this.comboBoxC2.Location = new System.Drawing.Point(94, 4);
            this.comboBoxC2.Name = "comboBoxC2";
            this.comboBoxC2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxC2.Properties.Items.AddRange(new object[] {
            "--",
            "可编辑",
            "不可编辑",
            "已提交"});
            this.comboBoxC2.Size = new System.Drawing.Size(120, 20);
            this.comboBoxC2.TabIndex = 21;
            // 
            // label11
            // 
            this.label11.Dock = System.Windows.Forms.DockStyle.Left;
            this.label11.Location = new System.Drawing.Point(2, 4);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(92, 22);
            this.label11.TabIndex = 8;
            this.label11.Text = "林地功能分区";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel13
            // 
            this.panel13.Controls.Add(this.comboBoxC1);
            this.panel13.Controls.Add(this.label10);
            this.panel13.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel13.Location = new System.Drawing.Point(0, 0);
            this.panel13.Name = "panel13";
            this.panel13.Padding = new System.Windows.Forms.Padding(2, 4, 6, 0);
            this.panel13.Size = new System.Drawing.Size(220, 26);
            this.panel13.TabIndex = 11;
            // 
            // comboBoxC1
            // 
            this.comboBoxC1.Dock = System.Windows.Forms.DockStyle.Top;
            this.comboBoxC1.EditValue = "--";
            this.comboBoxC1.Location = new System.Drawing.Point(94, 4);
            this.comboBoxC1.Name = "comboBoxC1";
            this.comboBoxC1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxC1.Properties.Items.AddRange(new object[] {
            "--",
            "可编辑",
            "不可编辑",
            "已提交"});
            this.comboBoxC1.Size = new System.Drawing.Size(120, 20);
            this.comboBoxC1.TabIndex = 21;
            // 
            // label10
            // 
            this.label10.Dock = System.Windows.Forms.DockStyle.Left;
            this.label10.Location = new System.Drawing.Point(2, 4);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(92, 22);
            this.label10.TabIndex = 8;
            this.label10.Text = "林地保护等级";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xtraTabPage2
            // 
            this.xtraTabPage2.Controls.Add(this.panel36);
            this.xtraTabPage2.Controls.Add(this.panel4);
            this.xtraTabPage2.Controls.Add(this.panel22);
            this.xtraTabPage2.Controls.Add(this.panel23);
            this.xtraTabPage2.Controls.Add(this.panel24);
            this.xtraTabPage2.Controls.Add(this.panel19);
            this.xtraTabPage2.Controls.Add(this.panel25);
            this.xtraTabPage2.Controls.Add(this.panel18);
            this.xtraTabPage2.Name = "xtraTabPage2";
            this.xtraTabPage2.Size = new System.Drawing.Size(205, 202);
            this.xtraTabPage2.Text = "基本信息";
            // 
            // panel36
            // 
            this.panel36.Controls.Add(this.comboBoxB8);
            this.panel36.Controls.Add(this.label33);
            this.panel36.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel36.Location = new System.Drawing.Point(0, 175);
            this.panel36.Name = "panel36";
            this.panel36.Padding = new System.Windows.Forms.Padding(2, 4, 6, 0);
            this.panel36.Size = new System.Drawing.Size(205, 25);
            this.panel36.TabIndex = 26;
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
            this.comboBoxB8.Size = new System.Drawing.Size(125, 20);
            this.comboBoxB8.TabIndex = 22;
            // 
            // label33
            // 
            this.label33.Dock = System.Windows.Forms.DockStyle.Left;
            this.label33.Location = new System.Drawing.Point(2, 4);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(72, 21);
            this.label33.TabIndex = 8;
            this.label33.Text = "森林类别:";
            this.label33.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.comboBoxB7);
            this.panel4.Controls.Add(this.label20);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 150);
            this.panel4.Name = "panel4";
            this.panel4.Padding = new System.Windows.Forms.Padding(2, 4, 6, 0);
            this.panel4.Size = new System.Drawing.Size(205, 25);
            this.panel4.TabIndex = 24;
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
            this.comboBoxB7.Size = new System.Drawing.Size(125, 20);
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
            // panel22
            // 
            this.panel22.Controls.Add(this.comboBoxB6);
            this.panel22.Controls.Add(this.label21);
            this.panel22.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel22.Location = new System.Drawing.Point(0, 125);
            this.panel22.Name = "panel22";
            this.panel22.Padding = new System.Windows.Forms.Padding(2, 4, 6, 0);
            this.panel22.Size = new System.Drawing.Size(205, 25);
            this.panel22.TabIndex = 23;
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
            this.comboBoxB6.Size = new System.Drawing.Size(125, 20);
            this.comboBoxB6.TabIndex = 22;
            // 
            // label21
            // 
            this.label21.Dock = System.Windows.Forms.DockStyle.Left;
            this.label21.Location = new System.Drawing.Point(2, 4);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(72, 21);
            this.label21.TabIndex = 8;
            this.label21.Text = "林木所有权:";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel23
            // 
            this.panel23.Controls.Add(this.comboBoxB5);
            this.panel23.Controls.Add(this.label22);
            this.panel23.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel23.Location = new System.Drawing.Point(0, 100);
            this.panel23.Name = "panel23";
            this.panel23.Padding = new System.Windows.Forms.Padding(2, 4, 6, 0);
            this.panel23.Size = new System.Drawing.Size(205, 25);
            this.panel23.TabIndex = 22;
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
            this.comboBoxB5.Size = new System.Drawing.Size(125, 20);
            this.comboBoxB5.TabIndex = 21;
            // 
            // label22
            // 
            this.label22.Dock = System.Windows.Forms.DockStyle.Left;
            this.label22.Location = new System.Drawing.Point(2, 4);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(72, 21);
            this.label22.TabIndex = 8;
            this.label22.Text = "土地使用权:";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel24
            // 
            this.panel24.Controls.Add(this.comboBoxB4);
            this.panel24.Controls.Add(this.label23);
            this.panel24.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel24.Location = new System.Drawing.Point(0, 75);
            this.panel24.Name = "panel24";
            this.panel24.Padding = new System.Windows.Forms.Padding(2, 4, 6, 0);
            this.panel24.Size = new System.Drawing.Size(205, 25);
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
            this.comboBoxB4.Size = new System.Drawing.Size(125, 20);
            this.comboBoxB4.TabIndex = 23;
            this.comboBoxB4.SelectedIndexChanged += new System.EventHandler(this.comboBoxB7_SelectedIndexChanged);
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
            this.panel19.Size = new System.Drawing.Size(205, 25);
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
            this.comboBoxB3.Size = new System.Drawing.Size(125, 20);
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
            this.panel25.Size = new System.Drawing.Size(205, 25);
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
            this.comboBoxB2.Size = new System.Drawing.Size(125, 20);
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
            this.panel18.Size = new System.Drawing.Size(205, 25);
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
            this.comboBoxB1.Size = new System.Drawing.Size(125, 20);
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
            // xtraTabPage3
            // 
            this.xtraTabPage3.Controls.Add(this.panel38);
            this.xtraTabPage3.Controls.Add(this.panel37);
            this.xtraTabPage3.Controls.Add(this.panel26);
            this.xtraTabPage3.Controls.Add(this.panel28);
            this.xtraTabPage3.Controls.Add(this.panel3);
            this.xtraTabPage3.Controls.Add(this.panel21);
            this.xtraTabPage3.Controls.Add(this.panel20);
            this.xtraTabPage3.Name = "xtraTabPage3";
            this.xtraTabPage3.Size = new System.Drawing.Size(205, 202);
            this.xtraTabPage3.Text = "林分情况";
            // 
            // panel38
            // 
            this.panel38.Controls.Add(this.spinEditL77);
            this.panel38.Controls.Add(this.label36);
            this.panel38.Controls.Add(this.spinEditL7);
            this.panel38.Controls.Add(this.label37);
            this.panel38.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel38.Location = new System.Drawing.Point(0, 150);
            this.panel38.Name = "panel38";
            this.panel38.Padding = new System.Windows.Forms.Padding(2, 4, 6, 0);
            this.panel38.Size = new System.Drawing.Size(205, 25);
            this.panel38.TabIndex = 31;
            // 
            // spinEditL77
            // 
            this.spinEditL77.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spinEditL77.EditValue = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.spinEditL77.Location = new System.Drawing.Point(174, 4);
            this.spinEditL77.Name = "spinEditL77";
            this.spinEditL77.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spinEditL77.Properties.Mask.EditMask = "d";
            this.spinEditL77.Size = new System.Drawing.Size(25, 20);
            this.spinEditL77.TabIndex = 11;
            // 
            // label36
            // 
            this.label36.Dock = System.Windows.Forms.DockStyle.Left;
            this.label36.Location = new System.Drawing.Point(134, 4);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(40, 21);
            this.label36.TabIndex = 10;
            this.label36.Text = "~";
            this.label36.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // spinEditL7
            // 
            this.spinEditL7.Dock = System.Windows.Forms.DockStyle.Left;
            this.spinEditL7.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinEditL7.Location = new System.Drawing.Point(74, 4);
            this.spinEditL7.Name = "spinEditL7";
            this.spinEditL7.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spinEditL7.Properties.Mask.EditMask = "d";
            this.spinEditL7.Size = new System.Drawing.Size(60, 20);
            this.spinEditL7.TabIndex = 9;
            // 
            // label37
            // 
            this.label37.Dock = System.Windows.Forms.DockStyle.Left;
            this.label37.Location = new System.Drawing.Point(2, 4);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(72, 21);
            this.label37.TabIndex = 8;
            this.label37.Text = "公顷株数:";
            this.label37.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel37
            // 
            this.panel37.Controls.Add(this.spinEditL66);
            this.panel37.Controls.Add(this.label34);
            this.panel37.Controls.Add(this.spinEditL6);
            this.panel37.Controls.Add(this.label35);
            this.panel37.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel37.Location = new System.Drawing.Point(0, 125);
            this.panel37.Name = "panel37";
            this.panel37.Padding = new System.Windows.Forms.Padding(2, 4, 6, 0);
            this.panel37.Size = new System.Drawing.Size(205, 25);
            this.panel37.TabIndex = 30;
            // 
            // spinEditL66
            // 
            this.spinEditL66.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spinEditL66.EditValue = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.spinEditL66.Location = new System.Drawing.Point(174, 4);
            this.spinEditL66.Name = "spinEditL66";
            this.spinEditL66.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spinEditL66.Properties.Mask.EditMask = "d";
            this.spinEditL66.Size = new System.Drawing.Size(25, 20);
            this.spinEditL66.TabIndex = 11;
            // 
            // label34
            // 
            this.label34.Dock = System.Windows.Forms.DockStyle.Left;
            this.label34.Location = new System.Drawing.Point(134, 4);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(40, 21);
            this.label34.TabIndex = 10;
            this.label34.Text = "~";
            this.label34.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // spinEditL6
            // 
            this.spinEditL6.Dock = System.Windows.Forms.DockStyle.Left;
            this.spinEditL6.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinEditL6.Location = new System.Drawing.Point(74, 4);
            this.spinEditL6.Name = "spinEditL6";
            this.spinEditL6.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spinEditL6.Properties.Mask.EditMask = "d";
            this.spinEditL6.Size = new System.Drawing.Size(60, 20);
            this.spinEditL6.TabIndex = 9;
            // 
            // label35
            // 
            this.label35.Dock = System.Windows.Forms.DockStyle.Left;
            this.label35.Location = new System.Drawing.Point(2, 4);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(72, 21);
            this.label35.TabIndex = 8;
            this.label35.Text = "公顷蓄积:";
            this.label35.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel26
            // 
            this.panel26.Controls.Add(this.spinEditL55);
            this.panel26.Controls.Add(this.label25);
            this.panel26.Controls.Add(this.spinEditL5);
            this.panel26.Controls.Add(this.label26);
            this.panel26.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel26.Location = new System.Drawing.Point(0, 100);
            this.panel26.Name = "panel26";
            this.panel26.Padding = new System.Windows.Forms.Padding(2, 4, 6, 0);
            this.panel26.Size = new System.Drawing.Size(205, 25);
            this.panel26.TabIndex = 26;
            // 
            // spinEditL55
            // 
            this.spinEditL55.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spinEditL55.EditValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spinEditL55.Location = new System.Drawing.Point(174, 4);
            this.spinEditL55.Name = "spinEditL55";
            this.spinEditL55.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spinEditL55.Properties.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.spinEditL55.Properties.Mask.EditMask = "d";
            this.spinEditL55.Properties.MaxValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spinEditL55.Size = new System.Drawing.Size(25, 20);
            this.spinEditL55.TabIndex = 11;
            // 
            // label25
            // 
            this.label25.Dock = System.Windows.Forms.DockStyle.Left;
            this.label25.Location = new System.Drawing.Point(134, 4);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(40, 21);
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
            this.spinEditL5.Location = new System.Drawing.Point(74, 4);
            this.spinEditL5.Name = "spinEditL5";
            this.spinEditL5.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spinEditL5.Properties.Mask.EditMask = "d";
            this.spinEditL5.Size = new System.Drawing.Size(60, 20);
            this.spinEditL5.TabIndex = 9;
            // 
            // label26
            // 
            this.label26.Dock = System.Windows.Forms.DockStyle.Left;
            this.label26.Location = new System.Drawing.Point(2, 4);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(72, 21);
            this.label26.TabIndex = 8;
            this.label26.Text = "郁闭度:";
            this.label26.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel28
            // 
            this.panel28.Controls.Add(this.comboBoxL4);
            this.panel28.Controls.Add(this.label28);
            this.panel28.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel28.Location = new System.Drawing.Point(0, 75);
            this.panel28.Name = "panel28";
            this.panel28.Padding = new System.Windows.Forms.Padding(2, 4, 6, 0);
            this.panel28.Size = new System.Drawing.Size(205, 25);
            this.panel28.TabIndex = 28;
            // 
            // comboBoxL4
            // 
            this.comboBoxL4.Dock = System.Windows.Forms.DockStyle.Top;
            this.comboBoxL4.EditValue = "--";
            this.comboBoxL4.Location = new System.Drawing.Point(74, 4);
            this.comboBoxL4.Name = "comboBoxL4";
            this.comboBoxL4.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxL4.Properties.Items.AddRange(new object[] {
            "--",
            "可编辑",
            "不可编辑",
            "已提交"});
            this.comboBoxL4.Size = new System.Drawing.Size(125, 20);
            this.comboBoxL4.TabIndex = 22;
            // 
            // label28
            // 
            this.label28.Dock = System.Windows.Forms.DockStyle.Left;
            this.label28.Location = new System.Drawing.Point(2, 4);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(72, 21);
            this.label28.TabIndex = 8;
            this.label28.Text = "龄组 :";
            this.label28.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.spinEditL33);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.spinEditL3);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 50);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(2, 4, 6, 0);
            this.panel3.Size = new System.Drawing.Size(205, 25);
            this.panel3.TabIndex = 29;
            // 
            // spinEditL33
            // 
            this.spinEditL33.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spinEditL33.EditValue = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.spinEditL33.Location = new System.Drawing.Point(174, 4);
            this.spinEditL33.Name = "spinEditL33";
            this.spinEditL33.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spinEditL33.Properties.Mask.EditMask = "d";
            this.spinEditL33.Size = new System.Drawing.Size(25, 20);
            this.spinEditL33.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Left;
            this.label4.Location = new System.Drawing.Point(134, 4);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 21);
            this.label4.TabIndex = 10;
            this.label4.Text = "~";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // spinEditL3
            // 
            this.spinEditL3.Dock = System.Windows.Forms.DockStyle.Left;
            this.spinEditL3.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinEditL3.Location = new System.Drawing.Point(74, 4);
            this.spinEditL3.Name = "spinEditL3";
            this.spinEditL3.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spinEditL3.Properties.Mask.EditMask = "d";
            this.spinEditL3.Size = new System.Drawing.Size(60, 20);
            this.spinEditL3.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.Dock = System.Windows.Forms.DockStyle.Left;
            this.label5.Location = new System.Drawing.Point(2, 4);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 21);
            this.label5.TabIndex = 8;
            this.label5.Text = "平均年龄:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel21
            // 
            this.panel21.Controls.Add(this.spinEditL22);
            this.panel21.Controls.Add(this.label18);
            this.panel21.Controls.Add(this.spinEditL2);
            this.panel21.Controls.Add(this.label17);
            this.panel21.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel21.Location = new System.Drawing.Point(0, 25);
            this.panel21.Name = "panel21";
            this.panel21.Padding = new System.Windows.Forms.Padding(2, 4, 6, 0);
            this.panel21.Size = new System.Drawing.Size(205, 25);
            this.panel21.TabIndex = 18;
            // 
            // spinEditL22
            // 
            this.spinEditL22.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spinEditL22.EditValue = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.spinEditL22.Location = new System.Drawing.Point(174, 4);
            this.spinEditL22.Name = "spinEditL22";
            this.spinEditL22.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spinEditL22.Properties.Mask.EditMask = "d";
            this.spinEditL22.Size = new System.Drawing.Size(25, 20);
            this.spinEditL22.TabIndex = 11;
            // 
            // label18
            // 
            this.label18.Dock = System.Windows.Forms.DockStyle.Left;
            this.label18.Location = new System.Drawing.Point(134, 4);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(40, 21);
            this.label18.TabIndex = 10;
            this.label18.Text = "~";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // spinEditL2
            // 
            this.spinEditL2.Dock = System.Windows.Forms.DockStyle.Left;
            this.spinEditL2.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinEditL2.Location = new System.Drawing.Point(74, 4);
            this.spinEditL2.Name = "spinEditL2";
            this.spinEditL2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spinEditL2.Properties.Mask.EditMask = "d";
            this.spinEditL2.Size = new System.Drawing.Size(60, 20);
            this.spinEditL2.TabIndex = 9;
            // 
            // label17
            // 
            this.label17.Dock = System.Windows.Forms.DockStyle.Left;
            this.label17.Location = new System.Drawing.Point(2, 4);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(72, 21);
            this.label17.TabIndex = 8;
            this.label17.Text = "小班面积:";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel20
            // 
            this.panel20.Controls.Add(this.comboBoxL1);
            this.panel20.Controls.Add(this.label16);
            this.panel20.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel20.Location = new System.Drawing.Point(0, 0);
            this.panel20.Name = "panel20";
            this.panel20.Padding = new System.Windows.Forms.Padding(2, 4, 6, 0);
            this.panel20.Size = new System.Drawing.Size(205, 25);
            this.panel20.TabIndex = 17;
            // 
            // comboBoxL1
            // 
            this.comboBoxL1.Dock = System.Windows.Forms.DockStyle.Top;
            this.comboBoxL1.EditValue = "--";
            this.comboBoxL1.Location = new System.Drawing.Point(74, 4);
            this.comboBoxL1.Name = "comboBoxL1";
            this.comboBoxL1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxL1.Properties.Items.AddRange(new object[] {
            "--",
            "可编辑",
            "不可编辑",
            "已提交"});
            this.comboBoxL1.Size = new System.Drawing.Size(125, 20);
            this.comboBoxL1.TabIndex = 22;
            // 
            // label16
            // 
            this.label16.Dock = System.Windows.Forms.DockStyle.Left;
            this.label16.Location = new System.Drawing.Point(2, 4);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(72, 21);
            this.label16.TabIndex = 8;
            this.label16.Text = "优势树种 :";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelbasic
            // 
            this.panelbasic.AutoScroll = true;
            this.panelbasic.Controls.Add(this.panelDistLocation);
            this.panelbasic.Controls.Add(this.panel9);
            this.panelbasic.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelbasic.Location = new System.Drawing.Point(6, 22);
            this.panelbasic.Name = "panelbasic";
            this.panelbasic.Padding = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.panelbasic.Size = new System.Drawing.Size(226, 194);
            this.panelbasic.TabIndex = 18;
            // 
            // panelDistLocation
            // 
            this.panelDistLocation.BackColor = System.Drawing.Color.Transparent;
            this.panelDistLocation.Controls.Add(this.panel10);
            this.panelDistLocation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDistLocation.ForeColor = System.Drawing.Color.Black;
            this.panelDistLocation.Location = new System.Drawing.Point(79, 0);
            this.panelDistLocation.Name = "panelDistLocation";
            this.panelDistLocation.Size = new System.Drawing.Size(147, 193);
            this.panelDistLocation.TabIndex = 9;
            // 
            // panel10
            // 
            this.panel10.Controls.Add(this.comboBoxChangeState);
            this.panel10.Controls.Add(this.panel35);
            this.panel10.Controls.Add(this.comboBoxChangeKind);
            this.panel10.Controls.Add(this.panel31);
            this.panel10.Controls.Add(this.comboBoxXiBan);
            this.panel10.Controls.Add(this.panel30);
            this.panel10.Controls.Add(this.comboBoxXiaoban);
            this.panel10.Controls.Add(this.panel6);
            this.panel10.Controls.Add(this.comboBoxLinban);
            this.panel10.Controls.Add(this.panel1);
            this.panel10.Controls.Add(this.comboBoxVillage);
            this.panel10.Controls.Add(this.panel12);
            this.panel10.Controls.Add(this.comboBoxTown);
            this.panel10.Controls.Add(this.panel14);
            this.panel10.Controls.Add(this.comboBoxCounty);
            this.panel10.Controls.Add(this.panel11);
            this.panel10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel10.Location = new System.Drawing.Point(0, 0);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(147, 193);
            this.panel10.TabIndex = 14;
            // 
            // comboBoxChangeState
            // 
            this.comboBoxChangeState.Dock = System.Windows.Forms.DockStyle.Top;
            this.comboBoxChangeState.Location = new System.Drawing.Point(0, 180);
            this.comboBoxChangeState.Name = "comboBoxChangeState";
            this.comboBoxChangeState.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxChangeState.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.comboBoxChangeState.Size = new System.Drawing.Size(147, 20);
            this.comboBoxChangeState.TabIndex = 19;
            this.comboBoxChangeState.Visible = false;
            // 
            // panel35
            // 
            this.panel35.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel35.Location = new System.Drawing.Point(0, 175);
            this.panel35.Name = "panel35";
            this.panel35.Size = new System.Drawing.Size(147, 5);
            this.panel35.TabIndex = 20;
            // 
            // comboBoxChangeKind
            // 
            this.comboBoxChangeKind.Dock = System.Windows.Forms.DockStyle.Top;
            this.comboBoxChangeKind.Location = new System.Drawing.Point(0, 155);
            this.comboBoxChangeKind.Name = "comboBoxChangeKind";
            this.comboBoxChangeKind.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxChangeKind.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.comboBoxChangeKind.Size = new System.Drawing.Size(147, 20);
            this.comboBoxChangeKind.TabIndex = 17;
            // 
            // panel31
            // 
            this.panel31.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel31.Location = new System.Drawing.Point(0, 150);
            this.panel31.Name = "panel31";
            this.panel31.Size = new System.Drawing.Size(147, 5);
            this.panel31.TabIndex = 18;
            // 
            // comboBoxXiBan
            // 
            this.comboBoxXiBan.Dock = System.Windows.Forms.DockStyle.Top;
            this.comboBoxXiBan.Location = new System.Drawing.Point(0, 130);
            this.comboBoxXiBan.Name = "comboBoxXiBan";
            this.comboBoxXiBan.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxXiBan.Size = new System.Drawing.Size(147, 20);
            this.comboBoxXiBan.TabIndex = 21;
            // 
            // panel30
            // 
            this.panel30.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel30.Location = new System.Drawing.Point(0, 125);
            this.panel30.Name = "panel30";
            this.panel30.Size = new System.Drawing.Size(147, 5);
            this.panel30.TabIndex = 16;
            // 
            // panel11
            // 
            this.panel11.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel11.Location = new System.Drawing.Point(0, 0);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(147, 5);
            this.panel11.TabIndex = 6;
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.label31);
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
            this.panel9.Size = new System.Drawing.Size(79, 193);
            this.panel9.TabIndex = 13;
            this.panel9.TabStop = true;
            // 
            // label31
            // 
            this.label31.Dock = System.Windows.Forms.DockStyle.Top;
            this.label31.Location = new System.Drawing.Point(0, 189);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(79, 25);
            this.label31.TabIndex = 7;
            this.label31.Text = "变更状态 :";
            this.label31.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label31.Visible = false;
            // 
            // label30
            // 
            this.label30.Dock = System.Windows.Forms.DockStyle.Top;
            this.label30.Location = new System.Drawing.Point(0, 162);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(79, 27);
            this.label30.TabIndex = 6;
            this.label30.Text = "变更原因 :";
            this.label30.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label32
            // 
            this.label32.Dock = System.Windows.Forms.DockStyle.Top;
            this.label32.Location = new System.Drawing.Point(0, 135);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(79, 27);
            this.label32.TabIndex = 8;
            this.label32.Text = "细班 :";
            this.label32.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Location = new System.Drawing.Point(0, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 27);
            this.label2.TabIndex = 5;
            this.label2.Text = "小班 :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(0, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 27);
            this.label1.TabIndex = 4;
            this.label1.Text = "林班 :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.Dock = System.Windows.Forms.DockStyle.Top;
            this.label9.Location = new System.Drawing.Point(0, 54);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(79, 27);
            this.label9.TabIndex = 3;
            this.label9.Text = "村 :";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.Dock = System.Windows.Forms.DockStyle.Top;
            this.label8.Location = new System.Drawing.Point(0, 27);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(79, 27);
            this.label8.TabIndex = 2;
            this.label8.Text = "乡镇 :";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.Dock = System.Windows.Forms.DockStyle.Top;
            this.label7.Location = new System.Drawing.Point(0, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 27);
            this.label7.TabIndex = 1;
            this.label7.Text = "区县 :";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            // repositoryItemImageEdit1
            // 
            this.repositoryItemImageEdit1.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("repositoryItemImageEdit1.Appearance.Image")));
            this.repositoryItemImageEdit1.Appearance.Options.UseImage = true;
            this.repositoryItemImageEdit1.AutoHeight = false;
            this.repositoryItemImageEdit1.Name = "repositoryItemImageEdit1";
            this.repositoryItemImageEdit1.ShowDropDown = DevExpress.XtraEditors.Controls.ShowDropDown.Never;
            this.repositoryItemImageEdit1.ShowIcon = false;
            this.repositoryItemImageEdit1.ShowMenu = false;
            this.repositoryItemImageEdit1.ShowPopupShadow = false;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.simpleButtonSelect);
            this.panel5.Controls.Add(this.panel39);
            this.panel5.Controls.Add(this.simpleButtonInfo);
            this.panel5.Controls.Add(this.panel34);
            this.panel5.Controls.Add(this.simpleButtonOutput);
            this.panel5.Controls.Add(this.panel27);
            this.panel5.Controls.Add(this.simpleButtonBack);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(8, 148);
            this.panel5.Name = "panel5";
            this.panel5.Padding = new System.Windows.Forms.Padding(0, 6, 0, 6);
            this.panel5.Size = new System.Drawing.Size(222, 36);
            this.panel5.TabIndex = 101;
            // 
            // simpleButtonSelect
            // 
            this.simpleButtonSelect.Cursor = System.Windows.Forms.Cursors.Hand;
            this.simpleButtonSelect.Dock = System.Windows.Forms.DockStyle.Right;
            this.simpleButtonSelect.Image = ((System.Drawing.Image)(resources.GetObject("simpleButtonSelect.Image")));
            this.simpleButtonSelect.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.simpleButtonSelect.Location = new System.Drawing.Point(-36, 6);
            this.simpleButtonSelect.Name = "simpleButtonSelect";
            this.simpleButtonSelect.Size = new System.Drawing.Size(60, 24);
            this.simpleButtonSelect.TabIndex = 107;
            this.simpleButtonSelect.Text = "选中";
            this.simpleButtonSelect.ToolTip = "选中查询结果集";
            this.simpleButtonSelect.Click += new System.EventHandler(this.simpleButtonSelect_Click);
            // 
            // panel39
            // 
            this.panel39.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel39.Location = new System.Drawing.Point(24, 6);
            this.panel39.Name = "panel39";
            this.panel39.Size = new System.Drawing.Size(6, 24);
            this.panel39.TabIndex = 108;
            // 
            // simpleButtonInfo
            // 
            this.simpleButtonInfo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.simpleButtonInfo.Dock = System.Windows.Forms.DockStyle.Right;
            this.simpleButtonInfo.Image = ((System.Drawing.Image)(resources.GetObject("simpleButtonInfo.Image")));
            this.simpleButtonInfo.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.simpleButtonInfo.Location = new System.Drawing.Point(30, 6);
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
            this.panel34.Location = new System.Drawing.Point(90, 6);
            this.panel34.Name = "panel34";
            this.panel34.Size = new System.Drawing.Size(6, 24);
            this.panel34.TabIndex = 102;
            // 
            // simpleButtonOutput
            // 
            this.simpleButtonOutput.Cursor = System.Windows.Forms.Cursors.Hand;
            this.simpleButtonOutput.Dock = System.Windows.Forms.DockStyle.Right;
            this.simpleButtonOutput.Image = ((System.Drawing.Image)(resources.GetObject("simpleButtonOutput.Image")));
            this.simpleButtonOutput.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.simpleButtonOutput.Location = new System.Drawing.Point(96, 6);
            this.simpleButtonOutput.Name = "simpleButtonOutput";
            this.simpleButtonOutput.Size = new System.Drawing.Size(60, 24);
            this.simpleButtonOutput.TabIndex = 103;
            this.simpleButtonOutput.Text = "导出";
            this.simpleButtonOutput.ToolTip = "导出查询结果";
            this.simpleButtonOutput.Click += new System.EventHandler(this.simpleButtonOutput_Click);
            // 
            // panel27
            // 
            this.panel27.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel27.Location = new System.Drawing.Point(156, 6);
            this.panel27.Name = "panel27";
            this.panel27.Size = new System.Drawing.Size(6, 24);
            this.panel27.TabIndex = 104;
            // 
            // simpleButtonBack
            // 
            this.simpleButtonBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.simpleButtonBack.Dock = System.Windows.Forms.DockStyle.Right;
            this.simpleButtonBack.Image = ((System.Drawing.Image)(resources.GetObject("simpleButtonBack.Image")));
            this.simpleButtonBack.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.simpleButtonBack.Location = new System.Drawing.Point(162, 6);
            this.simpleButtonBack.Name = "simpleButtonBack";
            this.simpleButtonBack.Size = new System.Drawing.Size(60, 24);
            this.simpleButtonBack.TabIndex = 12;
            this.simpleButtonBack.Text = "返回";
            this.simpleButtonBack.ToolTip = "返回设置条件";
            this.simpleButtonBack.Click += new System.EventHandler(this.simpleButtonBack_Click);
            // 
            // labelinfo
            // 
            this.labelinfo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.labelinfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.labelinfo.Image = ((System.Drawing.Image)(resources.GetObject("labelinfo.Image")));
            this.labelinfo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelinfo.Location = new System.Drawing.Point(8, 122);
            this.labelinfo.Name = "labelinfo";
            this.labelinfo.Size = new System.Drawing.Size(222, 26);
            this.labelinfo.TabIndex = 101;
            this.labelinfo.Text = "      查找结果";
            this.labelinfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelinfo.Visible = false;
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label3.Location = new System.Drawing.Point(8, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(222, 26);
            this.label3.TabIndex = 100;
            this.label3.Text = "年度变更小班列表";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.treeList.Size = new System.Drawing.Size(222, 74);
            this.treeList.TabIndex = 99;
            this.treeList.TreeLevelWidth = 12;
            this.treeList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.treeList_MouseDoubleClick);
            // 
            // groupControlResult
            // 
            this.groupControlResult.Controls.Add(this.treeList);
            this.groupControlResult.Controls.Add(this.labelinfo);
            this.groupControlResult.Controls.Add(this.panel5);
            this.groupControlResult.Controls.Add(this.label3);
            this.groupControlResult.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControlResult.Location = new System.Drawing.Point(4, 513);
            this.groupControlResult.Name = "groupControlResult";
            this.groupControlResult.Padding = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.groupControlResult.Size = new System.Drawing.Size(238, 186);
            this.groupControlResult.TabIndex = 104;
            this.groupControlResult.Text = "查询结果";
            // 
            // labelLocation
            // 
            this.labelLocation.BackColor = System.Drawing.Color.Transparent;
            this.labelLocation.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelLocation.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelLocation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.labelLocation.Image = ((System.Drawing.Image)(resources.GetObject("labelLocation.Image")));
            this.labelLocation.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelLocation.Location = new System.Drawing.Point(4, 4);
            this.labelLocation.Name = "labelLocation";
            this.labelLocation.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.labelLocation.Size = new System.Drawing.Size(238, 26);
            this.labelLocation.TabIndex = 103;
            this.labelLocation.Text = "      年度更新小班查找          ";
            this.labelLocation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // UserControlQueryXB
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.Appearance.Options.UseBackColor = true;
            this.AutoScroll = true;
            this.Controls.Add(this.groupControlResult);
            this.Controls.Add(this.groupControlDist);
            this.Controls.Add(this.labelLocation);
            this.Name = "UserControlQueryXB";
            this.Padding = new System.Windows.Forms.Padding(4);
            this.Size = new System.Drawing.Size(246, 680);
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxXiaoban.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxLinban.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxVillage.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxTown.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxCounty.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlDist)).EndInit();
            this.groupControlDist.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panelMore.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.xtraTabPage1.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxC7.Properties)).EndInit();
            this.panel7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxC6.Properties)).EndInit();
            this.panel16.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxC5.Properties)).EndInit();
            this.panel29.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxC4.Properties)).EndInit();
            this.panel17.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxC3.Properties)).EndInit();
            this.panel15.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxC2.Properties)).EndInit();
            this.panel13.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxC1.Properties)).EndInit();
            this.xtraTabPage2.ResumeLayout(false);
            this.panel36.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxB8.Properties)).EndInit();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxB7.Properties)).EndInit();
            this.panel22.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxB6.Properties)).EndInit();
            this.panel23.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxB5.Properties)).EndInit();
            this.panel24.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxB4.Properties)).EndInit();
            this.panel19.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxB3.Properties)).EndInit();
            this.panel25.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxB2.Properties)).EndInit();
            this.panel18.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxB1.Properties)).EndInit();
            this.xtraTabPage3.ResumeLayout(false);
            this.panel38.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spinEditL77.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditL7.Properties)).EndInit();
            this.panel37.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spinEditL66.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditL6.Properties)).EndInit();
            this.panel26.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spinEditL55.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditL5.Properties)).EndInit();
            this.panel28.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxL4.Properties)).EndInit();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spinEditL33.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditL3.Properties)).EndInit();
            this.panel21.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spinEditL22.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditL2.Properties)).EndInit();
            this.panel20.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxL1.Properties)).EndInit();
            this.panelbasic.ResumeLayout(false);
            this.panelDistLocation.ResumeLayout(false);
            this.panel10.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxChangeState.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxChangeKind.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxXiBan.Properties)).EndInit();
            this.panel9.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPopupContainerEdit3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageEdit1)).EndInit();
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treeList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlResult)).EndInit();
            this.groupControlResult.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        public void InitialValue(object hook, IFeatureLayer pFeatureLayer, IMap pMap, QueryCommon.UserControlQueryResult pResult, DockPanel pDockPanel)
        {
            try
            {
                this.mHookHelper = new HookHelperClass();
                this.mHookHelper.Hook = hook;
                this.mEditLayer = pFeatureLayer;
                this.mMap = pMap;
                this.mQueryResult = pResult;
                this.mDockPanel = pDockPanel;
                this.groupControlResult.Visible = false;
                this.panelMore.Visible = false;
                this.groupControlDist.Visible = true;
                this.groupControlDist.BringToFront();
                this.labelLocation.Text = "      小班查找";
                this.label3.Text = "查询结果列表";
                this.InitialDist();
                this.InitialDicCom();
                this.simpleButtonMore.Text = "更多";
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "QueryAnalysic.UserControlQueryXB", "InitializeGISControls", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void OutputData(string spath)
        {
            try
            {
                new OutputShapeFile().OutputData(spath, this.mEditLayer.FeatureClass, this.mQueryString);
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "QueryAnalysic.UserControlQueryXB", "OutputData", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void SetDist(string code, DataTable ptable, ComboBoxEdit combox)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                if ((!combox.Name.Contains("Xiaoban") && !combox.Name.Contains("Linban")) && !combox.Name.Contains("XiBan"))
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
                    else if (combox.Name.Contains("XiBan"))
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
                this.Cursor = Cursors.Default;
            }
            catch (Exception exception)
            {
                this.Cursor = Cursors.Default;
                this.mErrOpt.ErrorOperate(this.mSubSysName, "QueryAnalysic.UserControlQueryXB", "SetDist", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void simpleButtonBack_Click(object sender, EventArgs e)
        {
            this.groupControlResult.Visible = false;
            this.groupControlDist.Visible = true;
            this.groupControlDist.BringToFront();
        }

        private void simpleButtonInfo_Click(object sender, EventArgs e)
        {
            this.mQueryResult.InitialQueryInfo(this.mHookHelper, this.mEditLayer, this.mQueryList, null, "", null, null);
            this.mDockPanel.Visibility = DockVisibility.Visible;
            this.mDockPanel.Text = this.mEditLayer.Name + "查询结果属性信息列表";
        }

        private void simpleButtonMore_Click(object sender, EventArgs e)
        {
            this.panelMore.Visible = !this.panelMore.Visible;
            if (this.simpleButtonMore.Text == "更多")
            {
                this.simpleButtonMore.Text = "简化";
            }
            else
            {
                this.simpleButtonMore.Text = "更多";
            }
        }

        private void simpleButtonOutput_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "ShapeFile (*.shp)|*.shp";
            dialog.Title = "导出小班查询结果数据";
            string str = UtilFactory.GetConfigOpt().RootPath + @"\" + UtilFactory.GetConfigOpt().GetConfigValue("TempPath");
            dialog.InitialDirectory = str;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = dialog.FileName;
                this.OutputData(fileName);
            }
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

        private void spinEditL7_EditValueChanged(object sender, EventArgs e)
        {
        }

        private void spinEditL8_EditValueChanged(object sender, EventArgs e)
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

