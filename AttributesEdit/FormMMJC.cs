namespace AttributesEdit
{
    using Cf_Calc;
    using DevExpress.Utils;
    using DevExpress.XtraEditors;
    using DevExpress.XtraEditors.Controls;
    using ESRI.ArcGIS.Geodatabase;
    using MyGridControl;
    using ShapeEdit;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Reflection;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;
    using TaskManage;
    using Utilities;

    public class FormMMJC : Form
    {
        private ZLSpinEdit BLMGQXJ1;
        private ZLSpinEdit BLMGQZS1;
        private SimpleButton btnCal;
        private ZLSpinEdit CCLV1;
        private ZLSpinEdit CFXJ1;
        private ZLSpinEdit CFZS1;
        private IContainer components;
        private ZLSpinEdit FGGCCCL1;
        private ZLSpinEdit GGCCCL1;
        private Label label100;
        private Label label101;
        private Label label116;
        private Label label117;
        private Label label143;
        private Label label150;
        private Label label152;
        private Label label154;
        private Label label17;
        private Label label25;
        private Label label48;
        private Label label49;
        private Label label60;
        private Label label72;
        private Label label73;
        private Label label75;
        private Label label78;
        private Label label81;
        private Label label95;
        private Label label96;
        private Label label97;
        private Label label99;
        private bool m_bClose;
        private bool m_bEditParent = true;
        private IFeature m_Feature;
        private string[] m_KeyFieldList;
        private string[] m_KeyValueList;
        private string m_KeyWhere;
        private Control m_ParentControl;
        private ITable m_Table;
        private string m_TreeCode = "";
        private const string mClassName = "AttributesEdit.FormMMJC";
        private ErrorOpt mErrOpt = UtilFactory.GetErrorOpt();
        private string mSubSysName = UtilFactory.GetConfigOpt().GetSystemName();
        private Panel panel1;
        private Panel panel104;
        private Panel panel105;
        private Panel panel107;
        private Panel panel109;
        private Panel panel29;
        private Panel panel53;
        private Panel panel55;
        private Panel panel56;
        private Panel panel63;
        private Panel panel64;
        private Panel panel65;
        private Panel panel66;
        private Panel panel68;
        private Panel panelCalc;
        private Panel panelControl2;
        private Panel panelTrees;
        private SplitContainer splitContainer1;
        private RichTextBox textBoxTrees;
        private UserControlTableWrite userControlTableWrite1;

        public FormMMJC()
        {
            this.InitializeComponent();
            base.Load += new EventHandler(this.FormMMJC_Load);
            this.btnCal.Click += new EventHandler(this.btnCal_Click);
            this.userControlTableWrite1.OnSubmitJCTable += new UserControlTableWrite.SubmitJCTablehandler(this.userControlTableWrite1_OnSubmitJCTable);
            base.FormClosing += new FormClosingEventHandler(this.FormMMJC_FormClosing);
        }

        private void btnCal_Click(object sender, EventArgs e)
        {
            this.panelTrees.Visible = false;
            if (XtraMessageBox.Show(this, "请确认已提交每木检尺数据，计算是否继续？", "提示", MessageBoxButtons.YesNo) != DialogResult.No)
            {
                this.btnCal.Enabled = false;
                this.Cursor = Cursors.WaitCursor;
                Application.DoEvents();
                this.Calc();
                this.Cursor = Cursors.Default;
                this.btnCal.Enabled = true;
                Application.DoEvents();
            }
        }

        private void Calc()
        {
            try
            {
                string str = UtilFactory.GetConfigOpt().GetConfigValue2("Harvest", "CalcFields");
                int index = str.IndexOf(";");
                string str2 = str.Substring(0, index);
                string str3 = str.Substring(index + 1);
                string[] strArray = str2.Split(new char[] { ',' });
                string[] strArray2 = str3.Split(new char[] { ',' });
                if ((this.userControlTableWrite1.Data == null) || (this.userControlTableWrite1.Data.Rows.Count < 1))
                {
                    if (XtraMessageBox.Show(this, "未填写林木检尺表，是否保存录入的株数、蓄积与出材率等信息？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        Editor.UniqueInstance.StartEditOperation();
                        for (int i = 0; i < strArray.Length; i++)
                        {
                            string name = strArray[i].ToString();
                            int num3 = this.m_Feature.Fields.FindField(name);
                            if (num3 >= 0)
                            {
                                Control control = this.GetControl(name + "1");
                                if (control != null)
                                {
                                    SpinEdit edit = (SpinEdit) control;
                                    this.m_Feature.set_Value(num3, edit.Value);
                                }
                            }
                        }
                        this.m_Feature.Store();
                        Editor.UniqueInstance.StopEditOperation();
                    }
                }
                else
                {
                    string cun = this.m_KeyValueList[0];
                    string lb = this.m_KeyValueList[1];
                    string dcxb = this.m_KeyValueList[2];
                    string zyxb = this.m_KeyValueList[3];
                   // IDBAccess dBAccess = UtilFactory.GetDBAccess(UtilFactory.GetConfigOpt().GetConfigValue2("DataBase", "DBKey"));
                    if (!CfCalc_mmjc.Calc_jcsj(cun, lb, dcxb, zyxb))
                    {
                        XtraMessageBox.Show(this, "计算出错！", "提示");
                    }
                    else
                    {
                        string sFieldName = UtilFactory.GetConfigOpt().GetConfigValue2("Harvest", "AreaField");
                        object fieldValue = DataFuncs.GetFieldValue(this.m_Feature, sFieldName);
                        if (fieldValue is DBNull)
                        {
                            XtraMessageBox.Show(this, "请填写面积值！", "提示");
                        }
                        else
                        {
                            double cfmj = Convert.ToDouble(fieldValue);
                            if (cfmj <= 0.0)
                            {
                                XtraMessageBox.Show(this, "请确保面积值大于0！", "提示");
                            }
                            else
                            {
                                cfmj *= 10000.0;
                                CfCalc_xb _xb = new CfCalc_xb(cun, lb, dcxb, zyxb, cfmj);
                                Editor.UniqueInstance.StartEditOperation();
                                double d = 0.0;
                                double num6 = 0.0;
                                double num7 = 0.0;
                                for (int j = 0; j < strArray2.Length; j++)
                                {
                                    if (strArray2[j] == "采伐株数")
                                    {
                                        d = _xb.GetValue(CfCalc_xb.Calc_ValueType.采伐株数);
                                        num6 = d;
                                    }
                                    else if (strArray2[j] == "采伐蓄积")
                                    {
                                        d = _xb.GetValue(CfCalc_xb.Calc_ValueType.采伐蓄积);
                                        num7 = d;
                                    }
                                    else if (strArray2[j] == "出材率")
                                    {
                                        d = _xb.GetValue(CfCalc_xb.Calc_ValueType.出材率);
                                    }
                                    else if (strArray2[j] == "规格材出材量")
                                    {
                                        d = _xb.GetValue(CfCalc_xb.Calc_ValueType.规格材出材量);
                                    }
                                    else if (strArray2[j] == "非规格材出材量")
                                    {
                                        d = _xb.GetValue(CfCalc_xb.Calc_ValueType.非规格材出材量);
                                    }
                                    else if (strArray2[j] == "保留木公顷株数")
                                    {
                                        d = _xb.GetValue(CfCalc_xb.Calc_ValueType.保留木公顷株数);
                                    }
                                    else
                                    {
                                        if (strArray2[j] != "保留木公顷蓄积")
                                        {
                                            continue;
                                        }
                                        d = _xb.GetValue(CfCalc_xb.Calc_ValueType.保留木公顷蓄积);
                                    }
                                    if (double.IsInfinity(d))
                                    {
                                        d = 0.0;
                                    }
                                    d = Math.Round(d, 1);
                                    string str11 = strArray[j].ToString();
                                    int num9 = this.m_Feature.Fields.FindField(str11);
                                    if (num9 >= 0)
                                    {
                                        IField field = this.m_Feature.Fields.get_Field(num9);
                                        if ((field.Type == esriFieldType.esriFieldTypeSmallInteger) || (field.Type == esriFieldType.esriFieldTypeInteger))
                                        {
                                            this.m_Feature.set_Value(num9, (int) d);
                                        }
                                        else
                                        {
                                            this.m_Feature.set_Value(num9, d);
                                        }
                                    }
                                }
                                this.m_Feature.Store();
                                this.panelTrees.Visible = true;
                                string sql = "select CCODE,CNAME from T_SYS_META_CODE where CTYPE='树种' and CCODE in (";
                                string str16 = sql;
                                sql = str16 + "select distinct JCSZ from T_ZT_CF_MMJC where CUN='" + cun + "' and LIN_BAN='" + lb + "' and DCXB='" + dcxb + "' and ZYXB='" + zyxb + "')";
                                DataTable dataTable = null;// dBAccess.GetDataTable(dBAccess, sql);
                                if ((dataTable == null) || (dataTable.Rows.Count < 2))
                                {
                                    this.panelTrees.Visible = false;
                                }
                                else
                                {
                                    string str13 = "";
                                    for (int k = 0; k < dataTable.Rows.Count; k++)
                                    {
                                        string sz = dataTable.Rows[k][0].ToString();
                                        str13 = (((((((((((((((str13 + "树种：" + dataTable.Rows[k][1].ToString() + "\r\n") + "  " + CfCalc_xb.Calc_ValueTypeByTree.采伐蓄积.ToString() + "：") + _xb.GetValueByTree(CfCalc_xb.Calc_ValueTypeByTree.采伐蓄积, sz).ToString() + "立方米") + "；") + "  " + CfCalc_xb.Calc_ValueTypeByTree.规格材出材量.ToString() + "：") + _xb.GetValueByTree(CfCalc_xb.Calc_ValueTypeByTree.规格材出材量, sz).ToString() + "立方米") + "；") + "  " + CfCalc_xb.Calc_ValueTypeByTree.非规格材出材量.ToString() + "：") + _xb.GetValueByTree(CfCalc_xb.Calc_ValueTypeByTree.非规格材出材量, sz).ToString() + "立方米") + "；") + "  " + CfCalc_xb.Calc_ValueTypeByTree.出材量.ToString() + "：") + _xb.GetValueByTree(CfCalc_xb.Calc_ValueTypeByTree.出材量, sz).ToString() + "立方米") + "；") + "  " + CfCalc_xb.Calc_ValueTypeByTree.出材率.ToString() + "：") + _xb.GetValueByTree(CfCalc_xb.Calc_ValueTypeByTree.出材率, sz).ToString() + "%") + "\r\n";
                                    }
                                    this.textBoxTrees.Text = str13;
                                    this.panelTrees.Visible = true;
                                    DataFuncs.UpdateField(this.m_Feature, "QTSM", str13.Substring(0, str13.Length - 2));
                                    this.m_Feature.Store();
                                    MemoEdit harControl = (MemoEdit) this.GetHarControl("QTSM");
                                    harControl.Text = str13.Substring(0, str13.Length - 2);
                                }
                                Editor.UniqueInstance.StopEditOperation();
                                this.ShowXJ(this.m_Feature);
                                Editor.UniqueInstance.StartEditOperation();
                                try
                                {
                                    decimal num11 = Convert.ToDecimal(num6);
                                    decimal num12 = Convert.ToDecimal(num7);
                                    string text = "    注意：是否将斑块的伐区蓄积、伐区株数、平均胸径、平均树高、每公顷株数、每公顷蓄积替换为由每木检尺表计算出的数据？";
                                    if (DialogResult.Yes == XtraMessageBox.Show(text, "提示", MessageBoxButtons.YesNo))
                                    {
                                        DataFuncs.UpdateField(this.m_Feature, "ZXJ", num7);
                                        DataFuncs.UpdateField(this.m_Feature, "FQZS", num6);
                                        this.m_Feature.Store();
                                        if (this.m_bEditParent)
                                        {
                                            SpinEdit edit3 = (SpinEdit) this.GetHarControl("FQZS");
                                            edit3.Value = num11;
                                            SpinEdit edit4 = (SpinEdit) this.GetHarControl("ZXJ");
                                            edit4.Value = num12;
                                        }
                                    }
                                    string[] strArray3 = new string[] { "PINGJUN_XJ", "PINGJUN_SG", "MEI_GQ_ZS", "HUO_LMGQXJ" };
                                    for (int m = 0; m < strArray3.Length; m++)
                                    {
                                        if (strArray3[m] == "PINGJUN_XJ")
                                        {
                                            d = _xb.GetValue(CfCalc_xb.Calc_ValueType.采伐木平均胸径);
                                        }
                                        else if (strArray3[m] == "PINGJUN_SG")
                                        {
                                            d = _xb.GetValue(CfCalc_xb.Calc_ValueType.采伐木平均高);
                                        }
                                        else if (strArray3[m] == "MEI_GQ_ZS")
                                        {
                                            d = _xb.GetValue(CfCalc_xb.Calc_ValueType.采伐木公顷株数);
                                        }
                                        else
                                        {
                                            if (strArray3[m] != "HUO_LMGQXJ")
                                            {
                                                continue;
                                            }
                                            d = _xb.GetValue(CfCalc_xb.Calc_ValueType.采伐木公顷蓄积);
                                        }
                                        DataFuncs.UpdateField(this.m_Feature, strArray3[m], d);
                                        if (this.m_bEditParent)
                                        {
                                            SpinEdit edit5 = (SpinEdit) this.GetHarControl(strArray3[m]);
                                            edit5.Value = Convert.ToDecimal(d);
                                        }
                                    }
                                    this.m_Feature.Store();
                                    Editor.UniqueInstance.StopEditOperation();
                                }
                                catch
                                {
                                    Editor.UniqueInstance.AbortEditOperation();
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "AttributesEdit.FormMMJC", "Calc", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                XtraMessageBox.Show("计算发生错误！", "提示");
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

        private void FormMMJC_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!this.m_bClose && (XtraMessageBox.Show(this, "是否关闭？请确定已保存。", "提示", MessageBoxButtons.YesNo) != DialogResult.Yes))
            {
                e.Cancel = true;
            }
        }

        private void FormMMJC_Load(object sender, EventArgs e)
        {
            this.InitControl();
        }

        private Control GetControl(string sName)
        {
            try
            {
                return (Control) base.GetType().GetField(sName, BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.IgnoreCase).GetValue(this);
            }
            catch
            {
                return null;
            }
        }

        private Control GetHarControl(string sControlName)
        {
            if ((this.m_ParentControl != null) && (this.m_ParentControl is UserControlHarAttr1))
            {
                UserControlHarAttr1 parentControl = (UserControlHarAttr1) this.m_ParentControl;
                return parentControl.GetControl(sControlName);
            }
            return null;
        }

        public void Init(Control pParentControl, IFeature pFeature, bool bEditParent)
        {
            this.m_bEditParent = bEditParent;
            this.m_ParentControl = pParentControl;
            this.m_Feature = pFeature;
        }

        private void InitControl()
        {
            this.panelTrees.Visible = false;
            this.m_KeyWhere = "";
            this.btnCal.Enabled = true;
            try
            {
                ConfigOpt configOpt = UtilFactory.GetConfigOpt();
                string configValue = configOpt.GetConfigValue("CaiFaTableName");
                IFeatureWorkspace editWorkspace = EditTask.EditWorkspace;
                if (editWorkspace != null)
                {
                    ITable table = null;
                    try
                    {
                        table = editWorkspace.OpenTable(configValue);
                    }
                    catch
                    {
                        return;
                    }
                    if (table != null)
                    {
                        this.m_Table = table;
                        string str2 = UtilFactory.GetConfigOpt().GetConfigValue2("Harvest", "JCFields");
                        if (str2 != "")
                        {
                            this.ShowXJ(this.m_Feature);
                            this.userControlTableWrite1.Clear();
                            string sFieldName = configOpt.GetConfigValue2("Harvest", "CFSZField");
                            string sTreeCode = DataFuncs.GetFieldValue(this.m_Feature, sFieldName).ToString();
                            this.m_TreeCode = sTreeCode;
                            string str5 = configOpt.GetConfigValue("CaiFaConnectFieldName");
                            int index = str5.IndexOf(";");
                            string str6 = str5.Substring(0, index);
                            string str7 = str5.Substring(index + 1);
                            string[] strArray = str6.Split(new char[] { ',' });
                            string[] pKeyFieldList = str7.Split(new char[] { ',' });
                            this.m_KeyFieldList = pKeyFieldList;
                            string str8 = "";
                            string str9 = "";
                            string str10 = "";
                            for (int i = 0; i < strArray.Length; i++)
                            {
                                str9 = DataFuncs.GetFieldValue(this.m_Feature, strArray[i]).ToString();
                                if (str9.Replace(" ", "") == "")
                                {
                                    XtraMessageBox.Show(this, "要填写林木检尺表，请确保村、林班、调查小班、作业小班都不为空！", "提示");
                                    this.userControlTableWrite1.Enabled = false;
                                    return;
                                }
                                string str11 = str8;
                                str8 = str11 + " and " + pKeyFieldList[i] + "='" + str9 + "'";
                                str10 = str10 + "," + str9;
                            }
                            str8 = str8.Substring(5);
                            this.m_KeyWhere = str8;
                            str10 = str10.Substring(1);
                            IQueryFilter queryFilter = new QueryFilterClass {
                                WhereClause = str8
                            };
                            ICursor cursor = null;
                            try
                            {
                                cursor = table.Search(queryFilter, false);
                            }
                            catch
                            {
                            }
                            if (cursor != null)
                            {
                                string[] pKeyValueList = str10.Split(new char[] { ',' });
                                this.m_KeyValueList = pKeyValueList;
                                this.userControlTableWrite1.Enabled = true;
                                this.btnCal.Enabled = true;
                                IFields pFields = cursor.Fields;
                                IList pRowList = new List<IRow>();
                                for (IRow row = cursor.NextRow(); row != null; row = cursor.NextRow())
                                {
                                    pRowList.Add(row);
                                }
                                string[] pJcFieldList = str2.Split(new char[] { ',' });
                                this.userControlTableWrite1.Init(pJcFieldList, pFields, pRowList, pKeyFieldList, pKeyValueList, sTreeCode);
                            }
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "AttributesEdit.FormMMJC", "ShowJCTable", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void InitializeComponent()
        {
            this.panelControl2 = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label117 = new System.Windows.Forms.Label();
            this.userControlTableWrite1 = new MyGridControl.UserControlTableWrite();
            this.panel64 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelTrees = new System.Windows.Forms.Panel();
            this.textBoxTrees = new System.Windows.Forms.RichTextBox();
            this.panel65 = new System.Windows.Forms.Panel();
            this.btnCal = new DevExpress.XtraEditors.SimpleButton();
            this.panelCalc = new System.Windows.Forms.Panel();
            this.panel29 = new System.Windows.Forms.Panel();
            this.panel63 = new System.Windows.Forms.Panel();
            this.panel68 = new System.Windows.Forms.Panel();
            this.BLMGQXJ1 = new AttributesEdit.ZLSpinEdit();
            this.label78 = new System.Windows.Forms.Label();
            this.label100 = new System.Windows.Forms.Label();
            this.panel66 = new System.Windows.Forms.Panel();
            this.BLMGQZS1 = new AttributesEdit.ZLSpinEdit();
            this.label81 = new System.Windows.Forms.Label();
            this.label99 = new System.Windows.Forms.Label();
            this.label101 = new System.Windows.Forms.Label();
            this.panel104 = new System.Windows.Forms.Panel();
            this.panel109 = new System.Windows.Forms.Panel();
            this.CCLV1 = new AttributesEdit.ZLSpinEdit();
            this.label154 = new System.Windows.Forms.Label();
            this.label152 = new System.Windows.Forms.Label();
            this.panel107 = new System.Windows.Forms.Panel();
            this.FGGCCCL1 = new AttributesEdit.ZLSpinEdit();
            this.label150 = new System.Windows.Forms.Label();
            this.label73 = new System.Windows.Forms.Label();
            this.panel105 = new System.Windows.Forms.Panel();
            this.GGCCCL1 = new AttributesEdit.ZLSpinEdit();
            this.label48 = new System.Windows.Forms.Label();
            this.label49 = new System.Windows.Forms.Label();
            this.label143 = new System.Windows.Forms.Label();
            this.panel53 = new System.Windows.Forms.Panel();
            this.panel55 = new System.Windows.Forms.Panel();
            this.CFXJ1 = new AttributesEdit.ZLSpinEdit();
            this.label17 = new System.Windows.Forms.Label();
            this.label72 = new System.Windows.Forms.Label();
            this.panel56 = new System.Windows.Forms.Panel();
            this.CFZS1 = new AttributesEdit.ZLSpinEdit();
            this.label25 = new System.Windows.Forms.Label();
            this.label60 = new System.Windows.Forms.Label();
            this.label75 = new System.Windows.Forms.Label();
            this.label95 = new System.Windows.Forms.Label();
            this.label96 = new System.Windows.Forms.Label();
            this.label97 = new System.Windows.Forms.Label();
            this.label116 = new System.Windows.Forms.Label();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel64.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panelTrees.SuspendLayout();
            this.panel65.SuspendLayout();
            this.panelCalc.SuspendLayout();
            this.panel29.SuspendLayout();
            this.panel63.SuspendLayout();
            this.panel68.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BLMGQXJ1.Properties)).BeginInit();
            this.panel66.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BLMGQZS1.Properties)).BeginInit();
            this.panel104.SuspendLayout();
            this.panel109.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CCLV1.Properties)).BeginInit();
            this.panel107.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FGGCCCL1.Properties)).BeginInit();
            this.panel105.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GGCCCL1.Properties)).BeginInit();
            this.panel53.SuspendLayout();
            this.panel55.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CFXJ1.Properties)).BeginInit();
            this.panel56.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CFZS1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl2
            // 
            this.panelControl2.BackColor = System.Drawing.Color.White;
            this.panelControl2.Controls.Add(this.splitContainer1);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(0, 0);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Padding = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.panelControl2.Size = new System.Drawing.Size(565, 510);
            this.panelControl2.TabIndex = 1;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Location = new System.Drawing.Point(6, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.label117);
            this.splitContainer1.Panel1.Controls.Add(this.userControlTableWrite1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panel64);
            this.splitContainer1.Size = new System.Drawing.Size(553, 510);
            this.splitContainer1.SplitterDistance = 321;
            this.splitContainer1.SplitterWidth = 3;
            this.splitContainer1.TabIndex = 0;
            // 
            // label117
            // 
            this.label117.BackColor = System.Drawing.Color.Blue;
            this.label117.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label117.ForeColor = System.Drawing.Color.Black;
            this.label117.Location = new System.Drawing.Point(0, 320);
            this.label117.Name = "label117";
            this.label117.Size = new System.Drawing.Size(553, 1);
            this.label117.TabIndex = 0;
            this.label117.Text = "label117";
            this.label117.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // userControlTableWrite1
            // 
            this.userControlTableWrite1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControlTableWrite1.Location = new System.Drawing.Point(0, 0);
            this.userControlTableWrite1.Name = "userControlTableWrite1";
            this.userControlTableWrite1.Size = new System.Drawing.Size(553, 321);
            this.userControlTableWrite1.TabIndex = 0;
            // 
            // panel64
            // 
            this.panel64.Controls.Add(this.panel1);
            this.panel64.Controls.Add(this.panelCalc);
            this.panel64.Controls.Add(this.label116);
            this.panel64.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel64.Location = new System.Drawing.Point(0, 0);
            this.panel64.Name = "panel64";
            this.panel64.Padding = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.panel64.Size = new System.Drawing.Size(553, 186);
            this.panel64.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panelTrees);
            this.panel1.Controls.Add(this.panel65);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 87);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(0, 3, 10, 2);
            this.panel1.Size = new System.Drawing.Size(553, 89);
            this.panel1.TabIndex = 1;
            // 
            // panelTrees
            // 
            this.panelTrees.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelTrees.Controls.Add(this.textBoxTrees);
            this.panelTrees.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTrees.Location = new System.Drawing.Point(0, 3);
            this.panelTrees.Name = "panelTrees";
            this.panelTrees.Size = new System.Drawing.Size(441, 84);
            this.panelTrees.TabIndex = 1;
            // 
            // textBoxTrees
            // 
            this.textBoxTrees.BackColor = System.Drawing.Color.White;
            this.textBoxTrees.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxTrees.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxTrees.Location = new System.Drawing.Point(0, 0);
            this.textBoxTrees.Name = "textBoxTrees";
            this.textBoxTrees.ReadOnly = true;
            this.textBoxTrees.Size = new System.Drawing.Size(439, 82);
            this.textBoxTrees.TabIndex = 0;
            this.textBoxTrees.Text = "";
            // 
            // panel65
            // 
            this.panel65.Controls.Add(this.btnCal);
            this.panel65.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel65.Location = new System.Drawing.Point(441, 3);
            this.panel65.Name = "panel65";
            this.panel65.Padding = new System.Windows.Forms.Padding(0, 3, 20, 2);
            this.panel65.Size = new System.Drawing.Size(102, 84);
            this.panel65.TabIndex = 0;
            // 
            // btnCal
            // 
            this.btnCal.Location = new System.Drawing.Point(15, 6);
            this.btnCal.Name = "btnCal";
            this.btnCal.Size = new System.Drawing.Size(76, 26);
            this.btnCal.TabIndex = 0;
            this.btnCal.Text = "计算保存";
            // 
            // panelCalc
            // 
            this.panelCalc.Controls.Add(this.panel29);
            this.panelCalc.Controls.Add(this.label95);
            this.panelCalc.Controls.Add(this.label96);
            this.panelCalc.Controls.Add(this.label97);
            this.panelCalc.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelCalc.Location = new System.Drawing.Point(0, 1);
            this.panelCalc.Name = "panelCalc";
            this.panelCalc.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.panelCalc.Size = new System.Drawing.Size(553, 86);
            this.panelCalc.TabIndex = 0;
            // 
            // panel29
            // 
            this.panel29.Controls.Add(this.panel63);
            this.panel29.Controls.Add(this.panel104);
            this.panel29.Controls.Add(this.panel53);
            this.panel29.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel29.Location = new System.Drawing.Point(1, 11);
            this.panel29.Name = "panel29";
            this.panel29.Size = new System.Drawing.Size(551, 75);
            this.panel29.TabIndex = 0;
            // 
            // panel63
            // 
            this.panel63.Controls.Add(this.panel68);
            this.panel63.Controls.Add(this.label100);
            this.panel63.Controls.Add(this.panel66);
            this.panel63.Controls.Add(this.label99);
            this.panel63.Controls.Add(this.label101);
            this.panel63.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel63.Location = new System.Drawing.Point(0, 50);
            this.panel63.Name = "panel63";
            this.panel63.Size = new System.Drawing.Size(551, 25);
            this.panel63.TabIndex = 0;
            // 
            // panel68
            // 
            this.panel68.Controls.Add(this.BLMGQXJ1);
            this.panel68.Controls.Add(this.label78);
            this.panel68.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel68.Location = new System.Drawing.Point(292, 0);
            this.panel68.Name = "panel68";
            this.panel68.Padding = new System.Windows.Forms.Padding(2, 6, 6, 2);
            this.panel68.Size = new System.Drawing.Size(113, 24);
            this.panel68.TabIndex = 2;
            // 
            // BLMGQXJ1
            // 
            this.BLMGQXJ1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BLMGQXJ1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BLMGQXJ1.EditScale = 0;
            this.BLMGQXJ1.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.BLMGQXJ1.Location = new System.Drawing.Point(2, 4);
            this.BLMGQXJ1.Name = "BLMGQXJ1";
            this.BLMGQXJ1.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.BLMGQXJ1.Properties.Appearance.Options.UseForeColor = true;
            this.BLMGQXJ1.Properties.Appearance.Options.UseTextOptions = true;
            this.BLMGQXJ1.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.BLMGQXJ1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.BLMGQXJ1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.BLMGQXJ1.Properties.MaxValue = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.BLMGQXJ1.Size = new System.Drawing.Size(81, 18);
            this.BLMGQXJ1.TabIndex = 31;
            // 
            // label78
            // 
            this.label78.Dock = System.Windows.Forms.DockStyle.Right;
            this.label78.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label78.ForeColor = System.Drawing.Color.Blue;
            this.label78.Location = new System.Drawing.Point(83, 6);
            this.label78.Name = "label78";
            this.label78.Size = new System.Drawing.Size(24, 16);
            this.label78.TabIndex = 0;
            this.label78.Text = "m³";
            // 
            // label100
            // 
            this.label100.Dock = System.Windows.Forms.DockStyle.Left;
            this.label100.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label100.Location = new System.Drawing.Point(196, 0);
            this.label100.Name = "label100";
            this.label100.Size = new System.Drawing.Size(96, 24);
            this.label100.TabIndex = 1;
            this.label100.Text = "保留木公顷蓄积";
            this.label100.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel66
            // 
            this.panel66.Controls.Add(this.BLMGQZS1);
            this.panel66.Controls.Add(this.label81);
            this.panel66.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel66.Location = new System.Drawing.Point(96, 0);
            this.panel66.Name = "panel66";
            this.panel66.Padding = new System.Windows.Forms.Padding(2, 6, 6, 2);
            this.panel66.Size = new System.Drawing.Size(100, 24);
            this.panel66.TabIndex = 0;
            // 
            // BLMGQZS1
            // 
            this.BLMGQZS1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BLMGQZS1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BLMGQZS1.EditScale = 0;
            this.BLMGQZS1.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.BLMGQZS1.Location = new System.Drawing.Point(2, 4);
            this.BLMGQZS1.Name = "BLMGQZS1";
            this.BLMGQZS1.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.BLMGQZS1.Properties.Appearance.Options.UseForeColor = true;
            this.BLMGQZS1.Properties.Appearance.Options.UseTextOptions = true;
            this.BLMGQZS1.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.BLMGQZS1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.BLMGQZS1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.BLMGQZS1.Properties.IsFloatValue = false;
            this.BLMGQZS1.Properties.Mask.EditMask = "N00";
            this.BLMGQZS1.Properties.MaxValue = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.BLMGQZS1.Size = new System.Drawing.Size(76, 18);
            this.BLMGQZS1.TabIndex = 31;
            // 
            // label81
            // 
            this.label81.Dock = System.Windows.Forms.DockStyle.Right;
            this.label81.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label81.ForeColor = System.Drawing.Color.Blue;
            this.label81.Location = new System.Drawing.Point(78, 6);
            this.label81.Name = "label81";
            this.label81.Size = new System.Drawing.Size(16, 16);
            this.label81.TabIndex = 0;
            this.label81.Text = "株";
            // 
            // label99
            // 
            this.label99.Dock = System.Windows.Forms.DockStyle.Left;
            this.label99.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label99.Location = new System.Drawing.Point(0, 0);
            this.label99.Name = "label99";
            this.label99.Size = new System.Drawing.Size(96, 24);
            this.label99.TabIndex = 0;
            this.label99.Text = "保留木公顷株数";
            this.label99.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label101
            // 
            this.label101.BackColor = System.Drawing.Color.Black;
            this.label101.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label101.Location = new System.Drawing.Point(0, 24);
            this.label101.Name = "label101";
            this.label101.Size = new System.Drawing.Size(551, 1);
            this.label101.TabIndex = 0;
            this.label101.Text = "label101";
            this.label101.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel104
            // 
            this.panel104.Controls.Add(this.panel109);
            this.panel104.Controls.Add(this.label152);
            this.panel104.Controls.Add(this.panel107);
            this.panel104.Controls.Add(this.label73);
            this.panel104.Controls.Add(this.panel105);
            this.panel104.Controls.Add(this.label49);
            this.panel104.Controls.Add(this.label143);
            this.panel104.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel104.Location = new System.Drawing.Point(0, 25);
            this.panel104.Name = "panel104";
            this.panel104.Padding = new System.Windows.Forms.Padding(0, 0, 1, 0);
            this.panel104.Size = new System.Drawing.Size(551, 25);
            this.panel104.TabIndex = 3;
            // 
            // panel109
            // 
            this.panel109.Controls.Add(this.CCLV1);
            this.panel109.Controls.Add(this.label154);
            this.panel109.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel109.Location = new System.Drawing.Point(398, 0);
            this.panel109.Name = "panel109";
            this.panel109.Padding = new System.Windows.Forms.Padding(2, 6, 6, 2);
            this.panel109.Size = new System.Drawing.Size(80, 24);
            this.panel109.TabIndex = 10;
            // 
            // CCLV1
            // 
            this.CCLV1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CCLV1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.CCLV1.EditScale = 0;
            this.CCLV1.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.CCLV1.Location = new System.Drawing.Point(2, 4);
            this.CCLV1.Name = "CCLV1";
            this.CCLV1.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.CCLV1.Properties.Appearance.Options.UseForeColor = true;
            this.CCLV1.Properties.Appearance.Options.UseTextOptions = true;
            this.CCLV1.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.CCLV1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.CCLV1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.CCLV1.Properties.MaxValue = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.CCLV1.Size = new System.Drawing.Size(52, 18);
            this.CCLV1.TabIndex = 30;
            // 
            // label154
            // 
            this.label154.Dock = System.Windows.Forms.DockStyle.Right;
            this.label154.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label154.ForeColor = System.Drawing.Color.Blue;
            this.label154.Location = new System.Drawing.Point(54, 6);
            this.label154.Name = "label154";
            this.label154.Size = new System.Drawing.Size(20, 16);
            this.label154.TabIndex = 0;
            this.label154.Text = "%";
            // 
            // label152
            // 
            this.label152.Dock = System.Windows.Forms.DockStyle.Left;
            this.label152.Location = new System.Drawing.Point(356, 0);
            this.label152.Name = "label152";
            this.label152.Size = new System.Drawing.Size(42, 24);
            this.label152.TabIndex = 9;
            this.label152.Text = "出材率";
            this.label152.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel107
            // 
            this.panel107.Controls.Add(this.FGGCCCL1);
            this.panel107.Controls.Add(this.label150);
            this.panel107.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel107.Location = new System.Drawing.Point(251, 0);
            this.panel107.Name = "panel107";
            this.panel107.Padding = new System.Windows.Forms.Padding(2, 6, 6, 2);
            this.panel107.Size = new System.Drawing.Size(105, 24);
            this.panel107.TabIndex = 8;
            // 
            // FGGCCCL1
            // 
            this.FGGCCCL1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.FGGCCCL1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.FGGCCCL1.EditScale = 0;
            this.FGGCCCL1.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.FGGCCCL1.Location = new System.Drawing.Point(2, 4);
            this.FGGCCCL1.Name = "FGGCCCL1";
            this.FGGCCCL1.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.FGGCCCL1.Properties.Appearance.Options.UseForeColor = true;
            this.FGGCCCL1.Properties.Appearance.Options.UseTextOptions = true;
            this.FGGCCCL1.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.FGGCCCL1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.FGGCCCL1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.FGGCCCL1.Properties.MaxValue = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.FGGCCCL1.Size = new System.Drawing.Size(73, 18);
            this.FGGCCCL1.TabIndex = 30;
            // 
            // label150
            // 
            this.label150.Dock = System.Windows.Forms.DockStyle.Right;
            this.label150.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label150.ForeColor = System.Drawing.Color.Blue;
            this.label150.Location = new System.Drawing.Point(75, 6);
            this.label150.Name = "label150";
            this.label150.Size = new System.Drawing.Size(24, 16);
            this.label150.TabIndex = 0;
            this.label150.Text = "m³";
            // 
            // label73
            // 
            this.label73.Dock = System.Windows.Forms.DockStyle.Left;
            this.label73.Location = new System.Drawing.Point(196, 0);
            this.label73.Name = "label73";
            this.label73.Size = new System.Drawing.Size(55, 24);
            this.label73.TabIndex = 7;
            this.label73.Text = "非规格材";
            this.label73.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel105
            // 
            this.panel105.Controls.Add(this.GGCCCL1);
            this.panel105.Controls.Add(this.label48);
            this.panel105.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel105.Location = new System.Drawing.Point(96, 0);
            this.panel105.Name = "panel105";
            this.panel105.Padding = new System.Windows.Forms.Padding(2, 6, 6, 2);
            this.panel105.Size = new System.Drawing.Size(100, 24);
            this.panel105.TabIndex = 6;
            // 
            // GGCCCL1
            // 
            this.GGCCCL1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.GGCCCL1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.GGCCCL1.EditScale = 0;
            this.GGCCCL1.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.GGCCCL1.Location = new System.Drawing.Point(2, 4);
            this.GGCCCL1.Name = "GGCCCL1";
            this.GGCCCL1.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.GGCCCL1.Properties.Appearance.Options.UseForeColor = true;
            this.GGCCCL1.Properties.Appearance.Options.UseTextOptions = true;
            this.GGCCCL1.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.GGCCCL1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.GGCCCL1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.GGCCCL1.Properties.MaxValue = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.GGCCCL1.Size = new System.Drawing.Size(68, 18);
            this.GGCCCL1.TabIndex = 30;
            // 
            // label48
            // 
            this.label48.Dock = System.Windows.Forms.DockStyle.Right;
            this.label48.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label48.ForeColor = System.Drawing.Color.Blue;
            this.label48.Location = new System.Drawing.Point(70, 6);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(24, 16);
            this.label48.TabIndex = 0;
            this.label48.Text = "m³";
            // 
            // label49
            // 
            this.label49.Dock = System.Windows.Forms.DockStyle.Left;
            this.label49.Location = new System.Drawing.Point(0, 0);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(96, 24);
            this.label49.TabIndex = 5;
            this.label49.Text = "规格材出材量";
            this.label49.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label143
            // 
            this.label143.BackColor = System.Drawing.Color.Black;
            this.label143.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label143.Location = new System.Drawing.Point(0, 24);
            this.label143.Name = "label143";
            this.label143.Size = new System.Drawing.Size(550, 1);
            this.label143.TabIndex = 0;
            this.label143.Text = "label143";
            this.label143.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel53
            // 
            this.panel53.Controls.Add(this.panel55);
            this.panel53.Controls.Add(this.label72);
            this.panel53.Controls.Add(this.panel56);
            this.panel53.Controls.Add(this.label60);
            this.panel53.Controls.Add(this.label75);
            this.panel53.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel53.Location = new System.Drawing.Point(0, 0);
            this.panel53.Name = "panel53";
            this.panel53.Size = new System.Drawing.Size(551, 25);
            this.panel53.TabIndex = 0;
            // 
            // panel55
            // 
            this.panel55.Controls.Add(this.CFXJ1);
            this.panel55.Controls.Add(this.label17);
            this.panel55.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel55.Location = new System.Drawing.Point(251, 0);
            this.panel55.Name = "panel55";
            this.panel55.Padding = new System.Windows.Forms.Padding(2, 6, 6, 2);
            this.panel55.Size = new System.Drawing.Size(105, 24);
            this.panel55.TabIndex = 4;
            // 
            // CFXJ1
            // 
            this.CFXJ1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CFXJ1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.CFXJ1.EditScale = 0;
            this.CFXJ1.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.CFXJ1.Location = new System.Drawing.Point(2, 4);
            this.CFXJ1.Name = "CFXJ1";
            this.CFXJ1.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.CFXJ1.Properties.Appearance.Options.UseForeColor = true;
            this.CFXJ1.Properties.Appearance.Options.UseTextOptions = true;
            this.CFXJ1.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.CFXJ1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.CFXJ1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.CFXJ1.Properties.MaxValue = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.CFXJ1.Size = new System.Drawing.Size(73, 18);
            this.CFXJ1.TabIndex = 31;
            // 
            // label17
            // 
            this.label17.Dock = System.Windows.Forms.DockStyle.Right;
            this.label17.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.Blue;
            this.label17.Location = new System.Drawing.Point(75, 6);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(24, 16);
            this.label17.TabIndex = 0;
            this.label17.Text = "m³";
            // 
            // label72
            // 
            this.label72.Dock = System.Windows.Forms.DockStyle.Left;
            this.label72.Location = new System.Drawing.Point(196, 0);
            this.label72.Name = "label72";
            this.label72.Size = new System.Drawing.Size(55, 24);
            this.label72.TabIndex = 3;
            this.label72.Text = "采伐蓄积";
            this.label72.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel56
            // 
            this.panel56.Controls.Add(this.CFZS1);
            this.panel56.Controls.Add(this.label25);
            this.panel56.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel56.Location = new System.Drawing.Point(96, 0);
            this.panel56.Name = "panel56";
            this.panel56.Padding = new System.Windows.Forms.Padding(2, 6, 6, 2);
            this.panel56.Size = new System.Drawing.Size(100, 24);
            this.panel56.TabIndex = 2;
            // 
            // CFZS1
            // 
            this.CFZS1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CFZS1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.CFZS1.EditScale = 0;
            this.CFZS1.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.CFZS1.Location = new System.Drawing.Point(2, 4);
            this.CFZS1.Name = "CFZS1";
            this.CFZS1.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.CFZS1.Properties.Appearance.Options.UseForeColor = true;
            this.CFZS1.Properties.Appearance.Options.UseTextOptions = true;
            this.CFZS1.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.CFZS1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.CFZS1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.CFZS1.Properties.MaxValue = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.CFZS1.Size = new System.Drawing.Size(76, 18);
            this.CFZS1.TabIndex = 31;
            // 
            // label25
            // 
            this.label25.Dock = System.Windows.Forms.DockStyle.Right;
            this.label25.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.ForeColor = System.Drawing.Color.Blue;
            this.label25.Location = new System.Drawing.Point(78, 6);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(16, 16);
            this.label25.TabIndex = 0;
            this.label25.Text = "株";
            // 
            // label60
            // 
            this.label60.Dock = System.Windows.Forms.DockStyle.Left;
            this.label60.Location = new System.Drawing.Point(0, 0);
            this.label60.Name = "label60";
            this.label60.Size = new System.Drawing.Size(96, 24);
            this.label60.TabIndex = 1;
            this.label60.Text = "采伐株数";
            this.label60.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label75
            // 
            this.label75.BackColor = System.Drawing.Color.Black;
            this.label75.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label75.Location = new System.Drawing.Point(0, 24);
            this.label75.Name = "label75";
            this.label75.Size = new System.Drawing.Size(551, 1);
            this.label75.TabIndex = 0;
            this.label75.Text = "label75";
            this.label75.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label95
            // 
            this.label95.BackColor = System.Drawing.Color.Black;
            this.label95.Dock = System.Windows.Forms.DockStyle.Top;
            this.label95.Location = new System.Drawing.Point(1, 10);
            this.label95.Name = "label95";
            this.label95.Size = new System.Drawing.Size(551, 1);
            this.label95.TabIndex = 0;
            this.label95.Text = "label95";
            this.label95.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label96
            // 
            this.label96.BackColor = System.Drawing.Color.Black;
            this.label96.Dock = System.Windows.Forms.DockStyle.Left;
            this.label96.Location = new System.Drawing.Point(0, 10);
            this.label96.Name = "label96";
            this.label96.Size = new System.Drawing.Size(1, 76);
            this.label96.TabIndex = 0;
            this.label96.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label97
            // 
            this.label97.BackColor = System.Drawing.Color.Black;
            this.label97.Dock = System.Windows.Forms.DockStyle.Right;
            this.label97.Location = new System.Drawing.Point(552, 10);
            this.label97.Name = "label97";
            this.label97.Size = new System.Drawing.Size(1, 76);
            this.label97.TabIndex = 0;
            this.label97.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label116
            // 
            this.label116.BackColor = System.Drawing.Color.Blue;
            this.label116.Dock = System.Windows.Forms.DockStyle.Top;
            this.label116.ForeColor = System.Drawing.Color.Black;
            this.label116.Location = new System.Drawing.Point(0, 0);
            this.label116.Name = "label116";
            this.label116.Size = new System.Drawing.Size(553, 1);
            this.label116.TabIndex = 0;
            this.label116.Text = "label116";
            this.label116.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FormMMJC
            // 
            this.ClientSize = new System.Drawing.Size(565, 510);
            this.Controls.Add(this.panelControl2);
            this.MinimizeBox = false;
            this.Name = "FormMMJC";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "  每木检尺表录入";
            this.panelControl2.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel64.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panelTrees.ResumeLayout(false);
            this.panel65.ResumeLayout(false);
            this.panelCalc.ResumeLayout(false);
            this.panel29.ResumeLayout(false);
            this.panel63.ResumeLayout(false);
            this.panel68.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.BLMGQXJ1.Properties)).EndInit();
            this.panel66.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.BLMGQZS1.Properties)).EndInit();
            this.panel104.ResumeLayout(false);
            this.panel109.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CCLV1.Properties)).EndInit();
            this.panel107.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.FGGCCCL1.Properties)).EndInit();
            this.panel105.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GGCCCL1.Properties)).EndInit();
            this.panel53.ResumeLayout(false);
            this.panel55.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CFXJ1.Properties)).EndInit();
            this.panel56.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CFZS1.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        private bool SaveMMJC(DataTable pDataTable)
        {
            if (pDataTable == null)
            {
                return true;
            }
            this.Cursor = Cursors.WaitCursor;
            Editor.UniqueInstance.StartEditOperation();
            try
            {
                ITable table = this.m_Table;
                if (this.m_KeyWhere != "")
                {
                    IQueryFilter queryFilter = new QueryFilterClass {
                        WhereClause = this.m_KeyWhere
                    };
                    ICursor cursor = null;
                    cursor = table.Search(queryFilter, false);
                    for (IRow row = cursor.NextRow(); row != null; row = cursor.NextRow())
                    {
                        row.Delete();
                    }
                    Marshal.ReleaseComObject(cursor);
                    Marshal.ReleaseComObject(queryFilter);
                }
                ICursor o = table.Insert(true);
                IRowBuffer buffer = null;
                buffer = table.CreateRowBuffer();
                for (int i = 0; i < pDataTable.Rows.Count; i++)
                {
                    DataRow row2 = pDataTable.Rows[i];
                    for (int j = 0; j < pDataTable.Columns.Count; j++)
                    {
                        string columnName = pDataTable.Columns[j].ColumnName;
                        int index = table.Fields.FindField(columnName);
                        IField field = table.Fields.get_Field(index);
                        if (index > -1)
                        {
                            if (this.m_KeyFieldList.Contains<string>(columnName))
                            {
                                int num4 = this.m_KeyFieldList.ToList<string>().IndexOf(columnName);
                                buffer.set_Value(index, this.m_KeyValueList[num4]);
                            }
                            else
                            {
                                object obj2 = row2[j];
                                if (obj2 != null)
                                {
                                    if ((field.Domain != null) && (field.Domain.Type == esriDomainType.esriDTCodedValue))
                                    {
                                        ICodedValueDomain domain = field.Domain as ICodedValueDomain;
                                        for (int k = 0; k < domain.CodeCount; k++)
                                        {
                                            if (domain.get_Name(k) == obj2.ToString())
                                            {
                                                buffer.set_Value(index, domain.get_Value(k));
                                                break;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        buffer.set_Value(index, obj2);
                                    }
                                }
                            }
                        }
                    }
                    o.InsertRow(buffer);
                }
                o.Flush();
                Marshal.ReleaseComObject(buffer);
                Marshal.ReleaseComObject(o);
                Editor.UniqueInstance.StopEditOperation();
                if (UtilFactory.GetConfigOpt().GetConfigValue2("DataBase", "DBKey") == "Access")
                {
                    Editor.UniqueInstance.StopEdit2();
                    Editor.UniqueInstance.StartEdit(Editor.UniqueInstance.Workspace, Editor.UniqueInstance.Map);
                    Editor.UniqueInstance.StartEditOperation();
                    Editor.UniqueInstance.StopEditOperation();
                }
                this.Cursor = Cursors.Default;
                return true;
            }
            catch (Exception exception)
            {
                Editor.UniqueInstance.AbortEditOperation();
                this.mErrOpt.ErrorOperate(this.mSubSysName, "AttributesEdit.FormMMJC", "SaveMMJC", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                this.Cursor = Cursors.Default;
                return false;
            }
        }

        private void ShowXJ(IFeature pFeature)
        {
            try
            {
                string str = UtilFactory.GetConfigOpt().GetConfigValue2("Harvest", "CalcFields");
                int index = str.IndexOf(";");
                string[] strArray = str.Substring(0, index).Split(new char[] { ',' });
                for (int i = 0; i < strArray.Length; i++)
                {
                    Control control = this.GetControl(strArray[i].ToString() + "1");
                    if (control != null)
                    {
                        string name = strArray[i].ToString();
                        int num3 = this.m_Feature.Fields.FindField(name);
                        if (num3 >= 0)
                        {
                            IField field = this.m_Feature.Fields.get_Field(num3);
                            ZLSpinEdit edit = (ZLSpinEdit) control;
                            if ((field.Type == esriFieldType.esriFieldTypeSmallInteger) || (field.Type == esriFieldType.esriFieldTypeInteger))
                            {
                                edit.Properties.IsFloatValue = false;
                            }
                            else if ((field.Type == esriFieldType.esriFieldTypeDouble) || (field.Type == esriFieldType.esriFieldTypeSingle))
                            {
                                edit.Properties.IsFloatValue = true;
                                edit.EditScale = field.Scale;
                            }
                            edit.Text = this.m_Feature.get_Value(num3).ToString();
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "AttributesEdit.FormMMJC", "ShowXJ", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void userControlTableWrite1_OnSubmitJCTable(DataTable pDataTable)
        {
            if ((pDataTable != null) && (this.m_Table != null))
            {
                if (this.SaveMMJC(pDataTable))
                {
                    XtraMessageBox.Show(this, "提交成功！", "提示");
                }
                else
                {
                    XtraMessageBox.Show(this, "提交失败！", "提示");
                }
            }
        }
    }
}

