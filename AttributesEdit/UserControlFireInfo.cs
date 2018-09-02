namespace AttributesEdit
{
    using DevExpress.Utils;
    using DevExpress.XtraEditors;
    using DevExpress.XtraEditors.Controls;
    using ESRI.ArcGIS.Carto;
    using ESRI.ArcGIS.Geodatabase;
    using FormBase;
    using ShapeEdit;
    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.Drawing;
    using System.Reflection;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;
    using TaskManage;
    using Utilities;

    public class UserControlFireInfo : UserControlBase1
    {
        private SimpleButton buttonCalc;
        private ZLSpinEdit CL_RS;
        private ZLSpinEdit CL_XSRS;
        private IContainer components;
        private ZLComboBox CUN;
        private TextEdit DIMING;
        private ZLComboBox HZDJ;
        private ZLComboBox HZYY;
        private Label label00;
        private Label label1;
        private Label label10;
        private Label label100;
        private Label label101;
        private Label label105;
        private Label label11;
        private Label label115;
        private Label label116;
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
        private Label label27;
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
        private Label label38;
        private Label label39;
        private Label label4;
        private Label label40;
        private Label label41;
        private Label label42;
        private Label label43;
        private Label label44;
        private Label label45;
        private Label label46;
        private Label label47;
        private Label label48;
        private Label label49;
        private Label label5;
        private Label label50;
        private Label label51;
        private Label label52;
        private Label label53;
        private Label label54;
        private Label label55;
        private Label label56;
        private Label label57;
        private Label label58;
        private Label label6;
        private Label label7;
        private Label label79;
        private Label label8;
        private Label label80;
        private Label label81;
        private Label label82;
        private Label label83;
        private Label label84;
        private Label label85;
        private Label label9;
        private Label label93;
        private Label label94;
        private Label label95;
        private Label label96;
        private Label label97;
        private Label label99;
        private TextEdit LINFEN;
        private bool m_bAdd;
        private string m_Cnty;
        private bool m_EnableEdit;
        private IObject m_Object;
        private ITable m_Table;
        private string m_Town;
        private string m_Vill;
        private TextEdit NL;
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
        private Panel panel4;
        private Panel panel46;
        private Panel panel47;
        private Panel panel48;
        private Panel panel49;
        private Panel panel5;
        private Panel panel54;
        private Panel panel6;
        private Panel panel61;
        private Panel panel62;
        private Panel panel7;
        private Panel panel8;
        private Panel panel9;
        private Panel panel91;
        private Panel panel92;
        private Panel panelBasic;
        private Panel panelBasicInfo;
        private Panel panelInfo;
        private DateEdit PHSJ;
        private ZLSpinEdit PU_CL;
        private ZLSpinEdit PU_FJ;
        private ZLSpinEdit PU_JF;
        private ZLSpinEdit PU_QC;
        private ZLSpinEdit PU_RG;
        private DateEdit QHSJ;
        private ZLSpinEdit RGL_MJ;
        private ZLComboBox SF_CL;
        private ZLSpinEdit SHANG_Q;
        private ZLSpinEdit SHANG_S;
        private ZLSpinEdit SHANG_Z;
        private ZLSpinEdit SS_CL;
        private ZLSpinEdit SS_MONEY;
        private ZLSpinEdit SS_YL;
        private ZLSpinEdit SS_ZLMJ;
        private ZLSpinEdit TOTAL_MJ;
        private ZLComboBox XIAN;
        private ZLComboBox XIANG;
        private ZLSpinEdit YSL_MJ;

        public UserControlFireInfo()
        {
            this.InitializeComponent();
            this.XIAN.SelectedIndexChanged += new EventHandler(this.XIAN_SelectedIndexChanged);
            this.XIANG.SelectedIndexChanged += new EventHandler(this.XIANG_SelectedIndexChanged);
        }

        private void buttonCalc_Click(object sender, EventArgs e)
        {
            if (this.m_Object == null)
            {
                MessageBox.Show("新建火灾登记无法计算！", "提示");
            }
            else
            {
                try
                {
                    ConfigOpt configOpt = UtilFactory.GetConfigOpt();
                    string name = configOpt.GetConfigValue2("Fire", "IDField");
                    int index = this.m_Object.Fields.FindField(name);
                    if (index >= 0)
                    {
                        string str2 = this.m_Object.get_Value(index).ToString();
                        string str3 = name + "='" + str2 + "'";
                        IFeatureLayer editLayer = EditTask.EditLayer;
                        if (editLayer != null)
                        {
                            IFeatureClass featureClass = editLayer.FeatureClass;
                            if (featureClass != null)
                            {
                                IQueryFilter filter = new QueryFilterClass {
                                    WhereClause = str3,
                                    SubFields = featureClass.OIDFieldName
                                };
                                IFeatureCursor o = featureClass.Search(filter, false);
                                if (o != null)
                                {
                                    string[] strArray = configOpt.GetConfigValue2("Fire", "CalcFields").Split(new char[] { ',' });
                                    string sFieldName = strArray[0];
                                    string str6 = strArray[1];
                                    string str7 = strArray[2];
                                    string str8 = strArray[3];
                                    string str9 = strArray[4];
                                    double num2 = 0.0;
                                    double num3 = 0.0;
                                    double num4 = 0.0;
                                    double num5 = 0.0;
                                    IFeature pObj = null;
                                    int num6 = 0;
                                    while ((pObj = o.NextFeature()) != null)
                                    {
                                        num6++;
                                        string str10 = DataFuncs.GetFieldValue(pObj, str8).ToString();
                                        if (str10 != "")
                                        {
                                            if (str10.Substring(0, 1) == "1")
                                            {
                                                num2 += this.ConvertToDouble(DataFuncs.GetFieldValue(pObj, sFieldName));
                                            }
                                            else if (str10.Substring(0, 1) == "2")
                                            {
                                                num3 += this.ConvertToDouble(DataFuncs.GetFieldValue(pObj, sFieldName));
                                            }
                                        }
                                        string str11 = DataFuncs.GetFieldValue(pObj, str9).ToString();
                                        if (str11 != "")
                                        {
                                            if (str11 == "1")
                                            {
                                                num5 += this.ConvertToDouble(DataFuncs.GetFieldValue(pObj, str7));
                                            }
                                            else
                                            {
                                                num4 += this.ConvertToDouble(DataFuncs.GetFieldValue(pObj, str6));
                                            }
                                        }
                                    }
                                    Marshal.ReleaseComObject(o);
                                    if (num6 < 1)
                                    {
                                        MessageBox.Show("当前火灾不包含任何火灾斑块！", "提示");
                                    }
                                    else
                                    {
                                        string[] strArray2 = configOpt.GetConfigValue2("Fire", "ResultFields").Split(new char[] { ',' });
                                        string sName = strArray2[0];
                                        Control control = this.GetControl(sName);
                                        control.Text = Math.Round(num2, 2).ToString();
                                        string str14 = strArray2[1];
                                        control = this.GetControl(str14);
                                        control.Text = Math.Round(num3, 2).ToString();
                                        string str15 = strArray2[2];
                                        control = this.GetControl(str15);
                                        control.Text = Math.Round(num4, 2).ToString();
                                        string str16 = strArray2[3];
                                        control = this.GetControl(str16);
                                        control.Text = Math.Round(num5, 2).ToString();
                                    }
                                }
                            }
                        }
                    }
                }
                catch (Exception)
                {
                }
            }
        }

        private void Control_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                Control control = sender as Control;
                if (!(control is ZLComboBox) || !((ZLComboBox) control).DroppedDown)
                {
                    int index = control.TabIndex + 1;
                    this.FocusControl(index);
                }
            }
        }

        private double ConvertToDouble(object obj)
        {
            if (obj == null)
            {
                return 0.0;
            }
            try
            {
                return Convert.ToDouble(obj);
            }
            catch
            {
                return 0.0;
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

        private void FocusControl(int index)
        {
            if (index == 0x1d)
            {
                index = 1;
            }
            Control control = this.GetControl(this, index);
            if (control != null)
            {
                if (control.Enabled)
                {
                    control.Focus();
                }
                else
                {
                    this.FocusControl(index + 1);
                }
            }
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

        private Control GetControl(Control pControl, int index)
        {
            foreach (Control control2 in pControl.Controls)
            {
                if (control2 is Panel)
                {
                    Control control = this.GetControl(control2, index);
                    if (control != null)
                    {
                        return control;
                    }
                }
                else if (control2.TabIndex == index)
                {
                    return control2;
                }
            }
            return null;
        }

        private object GetControlValue(Control pControl)
        {
            try
            {
                if (pControl is ZLComboBox)
                {
                    return ((ZLComboBox) pControl).GetSelectedValue();
                }
                if (pControl is SpinEdit)
                {
                    return ((SpinEdit) pControl).Value;
                }
                if (pControl is DateEdit)
                {
                    DateEdit edit = pControl as DateEdit;
                    //2017.3.5 jiayp 修改为字符串
                    return edit.DateTime.ToString("yyyy-MM-dd HH:mm:ss");
                }
                if (pControl is TextEdit)
                {
                    
                    return ((TextEdit) pControl).Text;
                }
                return null;
            }
            catch
            {
                return null;
            }
        }

        public void Init(bool bEnableEdit, ITable pTable, IObject pObject, bool bAdd)
        {
            this.m_EnableEdit = bEnableEdit;
            this.m_Object = pObject;
            this.m_Table = pTable;
            this.m_bAdd = bAdd;
            this.ShowAttributes();
        }

        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelInfo = new System.Windows.Forms.Panel();
            this.panelBasic = new System.Windows.Forms.Panel();
            this.panelBasicInfo = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel31 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label47 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.panel33 = new System.Windows.Forms.Panel();
            this.label46 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.panel34 = new System.Windows.Forms.Panel();
            this.label29 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.panel27 = new System.Windows.Forms.Panel();
            this.panel28 = new System.Windows.Forms.Panel();
            this.label44 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.panel29 = new System.Windows.Forms.Panel();
            this.label45 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.panel24 = new System.Windows.Forms.Panel();
            this.panel35 = new System.Windows.Forms.Panel();
            this.label50 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.panel25 = new System.Windows.Forms.Panel();
            this.label43 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.panel26 = new System.Windows.Forms.Panel();
            this.label39 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.panel21 = new System.Windows.Forms.Panel();
            this.panel36 = new System.Windows.Forms.Panel();
            this.label51 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.panel23 = new System.Windows.Forms.Panel();
            this.label38 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.panel14 = new System.Windows.Forms.Panel();
            this.panel22 = new System.Windows.Forms.Panel();
            this.label49 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.panel18 = new System.Windows.Forms.Panel();
            this.label34 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.panel15 = new System.Windows.Forms.Panel();
            this.label33 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.panel11 = new System.Windows.Forms.Panel();
            this.panel17 = new System.Windows.Forms.Panel();
            this.NL = new DevExpress.XtraEditors.TextEdit();
            this.label11 = new System.Windows.Forms.Label();
            this.panel13 = new System.Windows.Forms.Panel();
            this.LINFEN = new DevExpress.XtraEditors.TextEdit();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panel46 = new System.Windows.Forms.Panel();
            this.buttonCalc = new DevExpress.XtraEditors.SimpleButton();
            this.label81 = new System.Windows.Forms.Label();
            this.panel48 = new System.Windows.Forms.Panel();
            this.panel61 = new System.Windows.Forms.Panel();
            this.label115 = new System.Windows.Forms.Label();
            this.label96 = new System.Windows.Forms.Label();
            this.panel62 = new System.Windows.Forms.Panel();
            this.label116 = new System.Windows.Forms.Label();
            this.label97 = new System.Windows.Forms.Label();
            this.panel54 = new System.Windows.Forms.Panel();
            this.label00 = new System.Windows.Forms.Label();
            this.label99 = new System.Windows.Forms.Label();
            this.label100 = new System.Windows.Forms.Label();
            this.label57 = new System.Windows.Forms.Label();
            this.label101 = new System.Windows.Forms.Label();
            this.label80 = new System.Windows.Forms.Label();
            this.panel49 = new System.Windows.Forms.Panel();
            this.panel92 = new System.Windows.Forms.Panel();
            this.label56 = new System.Windows.Forms.Label();
            this.label82 = new System.Windows.Forms.Label();
            this.panel91 = new System.Windows.Forms.Panel();
            this.label55 = new System.Windows.Forms.Label();
            this.label95 = new System.Windows.Forms.Label();
            this.panel47 = new System.Windows.Forms.Panel();
            this.label85 = new System.Windows.Forms.Label();
            this.label94 = new System.Windows.Forms.Label();
            this.label79 = new System.Windows.Forms.Label();
            this.label105 = new System.Windows.Forms.Label();
            this.label83 = new System.Windows.Forms.Label();
            this.label84 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label93 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label48 = new System.Windows.Forms.Label();
            this.label58 = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel9 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel16 = new System.Windows.Forms.Panel();
            this.panel19 = new System.Windows.Forms.Panel();
            this.PHSJ = new DevExpress.XtraEditors.DateEdit();
            this.label40 = new System.Windows.Forms.Label();
            this.panel20 = new System.Windows.Forms.Panel();
            this.QHSJ = new DevExpress.XtraEditors.DateEdit();
            this.label41 = new System.Windows.Forms.Label();
            this.label42 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.DIMING = new DevExpress.XtraEditors.TextEdit();
            this.label5 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.panel12 = new System.Windows.Forms.Panel();
            this.panel10 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.panel30 = new System.Windows.Forms.Panel();
            this.label52 = new System.Windows.Forms.Label();
            this.panel32 = new System.Windows.Forms.Panel();
            this.label53 = new System.Windows.Forms.Label();
            this.label54 = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.label37 = new System.Windows.Forms.Label();
            this.CL_XSRS = new AttributesEdit.ZLSpinEdit();
            this.CL_RS = new AttributesEdit.ZLSpinEdit();
            this.SF_CL = new AttributesEdit.ZLComboBox();
            this.PU_JF = new AttributesEdit.ZLSpinEdit();
            this.PU_FJ = new AttributesEdit.ZLSpinEdit();
            this.PU_QC = new AttributesEdit.ZLSpinEdit();
            this.PU_CL = new AttributesEdit.ZLSpinEdit();
            this.PU_RG = new AttributesEdit.ZLSpinEdit();
            this.SS_ZLMJ = new AttributesEdit.ZLSpinEdit();
            this.SS_MONEY = new AttributesEdit.ZLSpinEdit();
            this.SHANG_S = new AttributesEdit.ZLSpinEdit();
            this.SHANG_Z = new AttributesEdit.ZLSpinEdit();
            this.SHANG_Q = new AttributesEdit.ZLSpinEdit();
            this.SS_YL = new AttributesEdit.ZLSpinEdit();
            this.SS_CL = new AttributesEdit.ZLSpinEdit();
            this.RGL_MJ = new AttributesEdit.ZLSpinEdit();
            this.YSL_MJ = new AttributesEdit.ZLSpinEdit();
            this.TOTAL_MJ = new AttributesEdit.ZLSpinEdit();
            this.HZDJ = new AttributesEdit.ZLComboBox();
            this.HZYY = new AttributesEdit.ZLComboBox();
            this.CUN = new AttributesEdit.ZLComboBox();
            this.XIANG = new AttributesEdit.ZLComboBox();
            this.XIAN = new AttributesEdit.ZLComboBox();
            this.panel1.SuspendLayout();
            this.panelInfo.SuspendLayout();
            this.panelBasic.SuspendLayout();
            this.panelBasicInfo.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel31.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel33.SuspendLayout();
            this.panel34.SuspendLayout();
            this.panel27.SuspendLayout();
            this.panel28.SuspendLayout();
            this.panel29.SuspendLayout();
            this.panel24.SuspendLayout();
            this.panel35.SuspendLayout();
            this.panel25.SuspendLayout();
            this.panel26.SuspendLayout();
            this.panel21.SuspendLayout();
            this.panel36.SuspendLayout();
            this.panel23.SuspendLayout();
            this.panel14.SuspendLayout();
            this.panel22.SuspendLayout();
            this.panel18.SuspendLayout();
            this.panel15.SuspendLayout();
            this.panel11.SuspendLayout();
            this.panel17.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NL.Properties)).BeginInit();
            this.panel13.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LINFEN.Properties)).BeginInit();
            this.panel46.SuspendLayout();
            this.panel48.SuspendLayout();
            this.panel61.SuspendLayout();
            this.panel62.SuspendLayout();
            this.panel54.SuspendLayout();
            this.panel49.SuspendLayout();
            this.panel92.SuspendLayout();
            this.panel91.SuspendLayout();
            this.panel47.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel16.SuspendLayout();
            this.panel19.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PHSJ.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PHSJ.Properties)).BeginInit();
            this.panel20.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.QHSJ.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.QHSJ.Properties)).BeginInit();
            this.panel7.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DIMING.Properties)).BeginInit();
            this.panel12.SuspendLayout();
            this.panel10.SuspendLayout();
            this.panel30.SuspendLayout();
            this.panel32.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CL_XSRS.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CL_RS.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PU_JF.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PU_FJ.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PU_QC.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PU_CL.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PU_RG.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SS_ZLMJ.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SS_MONEY.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SHANG_S.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SHANG_Z.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SHANG_Q.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SS_YL.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SS_CL.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RGL_MJ.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.YSL_MJ.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TOTAL_MJ.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.panelInfo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(485, 457);
            this.panel1.TabIndex = 0;
            // 
            // panelInfo
            // 
            this.panelInfo.BackColor = System.Drawing.Color.White;
            this.panelInfo.Controls.Add(this.panelBasic);
            this.panelInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelInfo.Location = new System.Drawing.Point(0, 0);
            this.panelInfo.Name = "panelInfo";
            this.panelInfo.Size = new System.Drawing.Size(485, 410);
            this.panelInfo.TabIndex = 0;
            // 
            // panelBasic
            // 
            this.panelBasic.BackColor = System.Drawing.Color.White;
            this.panelBasic.Controls.Add(this.panelBasicInfo);
            this.panelBasic.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelBasic.Location = new System.Drawing.Point(0, 0);
            this.panelBasic.Name = "panelBasic";
            this.panelBasic.Size = new System.Drawing.Size(485, 399);
            this.panelBasic.TabIndex = 0;
            // 
            // panelBasicInfo
            // 
            this.panelBasicInfo.BackColor = System.Drawing.Color.White;
            this.panelBasicInfo.Controls.Add(this.panel2);
            this.panelBasicInfo.Controls.Add(this.label35);
            this.panelBasicInfo.Controls.Add(this.label36);
            this.panelBasicInfo.Controls.Add(this.label37);
            this.panelBasicInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelBasicInfo.Location = new System.Drawing.Point(0, 0);
            this.panelBasicInfo.Name = "panelBasicInfo";
            this.panelBasicInfo.Size = new System.Drawing.Size(485, 379);
            this.panelBasicInfo.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.panel31);
            this.panel2.Controls.Add(this.label23);
            this.panel2.Controls.Add(this.label32);
            this.panel2.Controls.Add(this.panel27);
            this.panel2.Controls.Add(this.panel24);
            this.panel2.Controls.Add(this.label16);
            this.panel2.Controls.Add(this.label31);
            this.panel2.Controls.Add(this.panel21);
            this.panel2.Controls.Add(this.panel14);
            this.panel2.Controls.Add(this.panel11);
            this.panel2.Controls.Add(this.panel46);
            this.panel2.Controls.Add(this.label15);
            this.panel2.Controls.Add(this.label93);
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Controls.Add(this.panel16);
            this.panel2.Controls.Add(this.panel7);
            this.panel2.Controls.Add(this.panel12);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(1, 1);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(483, 378);
            this.panel2.TabIndex = 0;
            // 
            // panel31
            // 
            this.panel31.Controls.Add(this.panel4);
            this.panel31.Controls.Add(this.label27);
            this.panel31.Controls.Add(this.panel33);
            this.panel31.Controls.Add(this.label28);
            this.panel31.Controls.Add(this.panel34);
            this.panel31.Controls.Add(this.label29);
            this.panel31.Controls.Add(this.label30);
            this.panel31.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel31.Location = new System.Drawing.Point(0, 353);
            this.panel31.Name = "panel31";
            this.panel31.Size = new System.Drawing.Size(483, 25);
            this.panel31.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.CL_XSRS);
            this.panel4.Controls.Add(this.label47);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel4.Location = new System.Drawing.Point(378, 0);
            this.panel4.Name = "panel4";
            this.panel4.Padding = new System.Windows.Forms.Padding(2, 2, 8, 2);
            this.panel4.Size = new System.Drawing.Size(83, 24);
            this.panel4.TabIndex = 0;
            // 
            // label47
            // 
            this.label47.Dock = System.Windows.Forms.DockStyle.Right;
            this.label47.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label47.ForeColor = System.Drawing.Color.Blue;
            this.label47.Location = new System.Drawing.Point(51, 2);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(24, 20);
            this.label47.TabIndex = 0;
            this.label47.Text = "人";
            this.label47.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label27
            // 
            this.label27.Dock = System.Windows.Forms.DockStyle.Left;
            this.label27.Location = new System.Drawing.Point(295, 0);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(83, 24);
            this.label27.TabIndex = 0;
            this.label27.Text = "刑事处罚人数";
            this.label27.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel33
            // 
            this.panel33.Controls.Add(this.CL_RS);
            this.panel33.Controls.Add(this.label46);
            this.panel33.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel33.Location = new System.Drawing.Point(211, 0);
            this.panel33.Name = "panel33";
            this.panel33.Padding = new System.Windows.Forms.Padding(2, 2, 8, 2);
            this.panel33.Size = new System.Drawing.Size(84, 24);
            this.panel33.TabIndex = 0;
            // 
            // label46
            // 
            this.label46.Dock = System.Windows.Forms.DockStyle.Right;
            this.label46.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label46.ForeColor = System.Drawing.Color.Blue;
            this.label46.Location = new System.Drawing.Point(52, 2);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(24, 20);
            this.label46.TabIndex = 0;
            this.label46.Text = "人";
            this.label46.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label28
            // 
            this.label28.Dock = System.Windows.Forms.DockStyle.Left;
            this.label28.Location = new System.Drawing.Point(153, 0);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(58, 24);
            this.label28.TabIndex = 0;
            this.label28.Text = "处理人数";
            this.label28.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel34
            // 
            this.panel34.Controls.Add(this.SF_CL);
            this.panel34.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel34.Location = new System.Drawing.Point(83, 0);
            this.panel34.Name = "panel34";
            this.panel34.Padding = new System.Windows.Forms.Padding(2, 2, 4, 0);
            this.panel34.Size = new System.Drawing.Size(70, 24);
            this.panel34.TabIndex = 0;
            // 
            // label29
            // 
            this.label29.Dock = System.Windows.Forms.DockStyle.Left;
            this.label29.Location = new System.Drawing.Point(0, 0);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(83, 24);
            this.label29.TabIndex = 0;
            this.label29.Text = "是否已经处理";
            this.label29.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label30
            // 
            this.label30.BackColor = System.Drawing.Color.Black;
            this.label30.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label30.Location = new System.Drawing.Point(0, 24);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(483, 1);
            this.label30.TabIndex = 0;
            this.label30.Text = "label30";
            this.label30.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label23
            // 
            this.label23.BackColor = System.Drawing.Color.Black;
            this.label23.Dock = System.Windows.Forms.DockStyle.Top;
            this.label23.Location = new System.Drawing.Point(0, 352);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(483, 1);
            this.label23.TabIndex = 0;
            this.label23.Text = "label23";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label32
            // 
            this.label32.Dock = System.Windows.Forms.DockStyle.Top;
            this.label32.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label32.Location = new System.Drawing.Point(0, 327);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(483, 25);
            this.label32.TabIndex = 0;
            this.label32.Text = " 处理情况";
            this.label32.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel27
            // 
            this.panel27.Controls.Add(this.panel28);
            this.panel27.Controls.Add(this.label24);
            this.panel27.Controls.Add(this.panel29);
            this.panel27.Controls.Add(this.label25);
            this.panel27.Controls.Add(this.label26);
            this.panel27.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel27.Location = new System.Drawing.Point(0, 302);
            this.panel27.Name = "panel27";
            this.panel27.Size = new System.Drawing.Size(483, 25);
            this.panel27.TabIndex = 0;
            // 
            // panel28
            // 
            this.panel28.Controls.Add(this.PU_JF);
            this.panel28.Controls.Add(this.label44);
            this.panel28.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel28.Location = new System.Drawing.Point(241, 0);
            this.panel28.Name = "panel28";
            this.panel28.Padding = new System.Windows.Forms.Padding(2, 2, 8, 2);
            this.panel28.Size = new System.Drawing.Size(123, 24);
            this.panel28.TabIndex = 0;
            // 
            // label44
            // 
            this.label44.Dock = System.Windows.Forms.DockStyle.Right;
            this.label44.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label44.ForeColor = System.Drawing.Color.Blue;
            this.label44.Location = new System.Drawing.Point(81, 2);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(34, 20);
            this.label44.TabIndex = 0;
            this.label44.Text = "万元";
            this.label44.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label24
            // 
            this.label24.Dock = System.Windows.Forms.DockStyle.Left;
            this.label24.Location = new System.Drawing.Point(183, 0);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(58, 24);
            this.label24.TabIndex = 0;
            this.label24.Text = "扑火经费";
            this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel29
            // 
            this.panel29.Controls.Add(this.PU_FJ);
            this.panel29.Controls.Add(this.label45);
            this.panel29.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel29.Location = new System.Drawing.Point(83, 0);
            this.panel29.Name = "panel29";
            this.panel29.Padding = new System.Windows.Forms.Padding(2, 2, 4, 2);
            this.panel29.Size = new System.Drawing.Size(100, 24);
            this.panel29.TabIndex = 0;
            // 
            // label45
            // 
            this.label45.Dock = System.Windows.Forms.DockStyle.Right;
            this.label45.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label45.ForeColor = System.Drawing.Color.Blue;
            this.label45.Location = new System.Drawing.Point(62, 2);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(34, 20);
            this.label45.TabIndex = 0;
            this.label45.Text = "架次";
            this.label45.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label25
            // 
            this.label25.Dock = System.Windows.Forms.DockStyle.Left;
            this.label25.Location = new System.Drawing.Point(0, 0);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(83, 24);
            this.label25.TabIndex = 0;
            this.label25.Text = "出动飞机";
            this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label26
            // 
            this.label26.BackColor = System.Drawing.Color.Black;
            this.label26.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label26.Location = new System.Drawing.Point(0, 24);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(483, 1);
            this.label26.TabIndex = 0;
            this.label26.Text = "label26";
            this.label26.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel24
            // 
            this.panel24.Controls.Add(this.panel35);
            this.panel24.Controls.Add(this.label19);
            this.panel24.Controls.Add(this.panel25);
            this.panel24.Controls.Add(this.label20);
            this.panel24.Controls.Add(this.panel26);
            this.panel24.Controls.Add(this.label21);
            this.panel24.Controls.Add(this.label22);
            this.panel24.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel24.Location = new System.Drawing.Point(0, 277);
            this.panel24.Name = "panel24";
            this.panel24.Size = new System.Drawing.Size(483, 25);
            this.panel24.TabIndex = 0;
            // 
            // panel35
            // 
            this.panel35.Controls.Add(this.PU_QC);
            this.panel35.Controls.Add(this.label50);
            this.panel35.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel35.Location = new System.Drawing.Point(369, 0);
            this.panel35.Name = "panel35";
            this.panel35.Padding = new System.Windows.Forms.Padding(2, 2, 4, 2);
            this.panel35.Size = new System.Drawing.Size(92, 24);
            this.panel35.TabIndex = 0;
            // 
            // label50
            // 
            this.label50.Dock = System.Windows.Forms.DockStyle.Right;
            this.label50.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label50.ForeColor = System.Drawing.Color.Blue;
            this.label50.Location = new System.Drawing.Point(64, 2);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(24, 20);
            this.label50.TabIndex = 0;
            this.label50.Text = "辆";
            this.label50.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label19
            // 
            this.label19.Dock = System.Windows.Forms.DockStyle.Left;
            this.label19.Location = new System.Drawing.Point(333, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(36, 24);
            this.label19.TabIndex = 0;
            this.label19.Text = "汽车";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel25
            // 
            this.panel25.Controls.Add(this.PU_CL);
            this.panel25.Controls.Add(this.label43);
            this.panel25.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel25.Location = new System.Drawing.Point(241, 0);
            this.panel25.Name = "panel25";
            this.panel25.Padding = new System.Windows.Forms.Padding(2, 2, 4, 2);
            this.panel25.Size = new System.Drawing.Size(92, 24);
            this.panel25.TabIndex = 0;
            // 
            // label43
            // 
            this.label43.Dock = System.Windows.Forms.DockStyle.Right;
            this.label43.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label43.ForeColor = System.Drawing.Color.Blue;
            this.label43.Location = new System.Drawing.Point(64, 2);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(24, 20);
            this.label43.TabIndex = 0;
            this.label43.Text = "辆";
            this.label43.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label20
            // 
            this.label20.Dock = System.Windows.Forms.DockStyle.Left;
            this.label20.Location = new System.Drawing.Point(183, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(58, 24);
            this.label20.TabIndex = 0;
            this.label20.Text = "出动车辆";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel26
            // 
            this.panel26.Controls.Add(this.PU_RG);
            this.panel26.Controls.Add(this.label39);
            this.panel26.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel26.Location = new System.Drawing.Point(83, 0);
            this.panel26.Name = "panel26";
            this.panel26.Padding = new System.Windows.Forms.Padding(2, 2, 4, 2);
            this.panel26.Size = new System.Drawing.Size(100, 24);
            this.panel26.TabIndex = 0;
            // 
            // label39
            // 
            this.label39.Dock = System.Windows.Forms.DockStyle.Right;
            this.label39.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label39.ForeColor = System.Drawing.Color.Blue;
            this.label39.Location = new System.Drawing.Point(62, 2);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(34, 20);
            this.label39.TabIndex = 0;
            this.label39.Text = "工日";
            this.label39.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label21
            // 
            this.label21.Dock = System.Windows.Forms.DockStyle.Left;
            this.label21.Location = new System.Drawing.Point(0, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(83, 24);
            this.label21.TabIndex = 0;
            this.label21.Text = "出动扑火人工 ";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label22
            // 
            this.label22.BackColor = System.Drawing.Color.Black;
            this.label22.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label22.Location = new System.Drawing.Point(0, 24);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(483, 1);
            this.label22.TabIndex = 0;
            this.label22.Text = "label22";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label16
            // 
            this.label16.BackColor = System.Drawing.Color.Black;
            this.label16.Dock = System.Windows.Forms.DockStyle.Top;
            this.label16.Location = new System.Drawing.Point(0, 276);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(483, 1);
            this.label16.TabIndex = 0;
            this.label16.Text = "label16";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label31
            // 
            this.label31.Dock = System.Windows.Forms.DockStyle.Top;
            this.label31.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label31.Location = new System.Drawing.Point(0, 251);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(483, 25);
            this.label31.TabIndex = 0;
            this.label31.Text = " 扑救情况";
            this.label31.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel21
            // 
            this.panel21.Controls.Add(this.panel36);
            this.panel21.Controls.Add(this.label12);
            this.panel21.Controls.Add(this.panel23);
            this.panel21.Controls.Add(this.label17);
            this.panel21.Controls.Add(this.label18);
            this.panel21.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel21.Location = new System.Drawing.Point(0, 226);
            this.panel21.Name = "panel21";
            this.panel21.Size = new System.Drawing.Size(483, 25);
            this.panel21.TabIndex = 0;
            // 
            // panel36
            // 
            this.panel36.Controls.Add(this.SS_ZLMJ);
            this.panel36.Controls.Add(this.label51);
            this.panel36.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel36.Location = new System.Drawing.Point(287, 0);
            this.panel36.Name = "panel36";
            this.panel36.Padding = new System.Windows.Forms.Padding(2, 2, 8, 2);
            this.panel36.Size = new System.Drawing.Size(105, 24);
            this.panel36.TabIndex = 0;
            // 
            // label51
            // 
            this.label51.Dock = System.Windows.Forms.DockStyle.Right;
            this.label51.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label51.ForeColor = System.Drawing.Color.Blue;
            this.label51.Location = new System.Drawing.Point(73, 2);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(24, 20);
            this.label51.TabIndex = 0;
            this.label51.Text = "m³";
            this.label51.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label12
            // 
            this.label12.Dock = System.Windows.Forms.DockStyle.Left;
            this.label12.Location = new System.Drawing.Point(183, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(104, 24);
            this.label12.TabIndex = 0;
            this.label12.Text = "受害新造林地面积";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel23
            // 
            this.panel23.Controls.Add(this.SS_MONEY);
            this.panel23.Controls.Add(this.label38);
            this.panel23.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel23.Location = new System.Drawing.Point(83, 0);
            this.panel23.Name = "panel23";
            this.panel23.Padding = new System.Windows.Forms.Padding(2, 2, 4, 2);
            this.panel23.Size = new System.Drawing.Size(100, 24);
            this.panel23.TabIndex = 0;
            // 
            // label38
            // 
            this.label38.Dock = System.Windows.Forms.DockStyle.Right;
            this.label38.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label38.ForeColor = System.Drawing.Color.Blue;
            this.label38.Location = new System.Drawing.Point(72, 2);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(24, 20);
            this.label38.TabIndex = 0;
            this.label38.Text = "万";
            this.label38.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label17
            // 
            this.label17.Dock = System.Windows.Forms.DockStyle.Left;
            this.label17.Location = new System.Drawing.Point(0, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(83, 24);
            this.label17.TabIndex = 0;
            this.label17.Text = "其他损失折款";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label18
            // 
            this.label18.BackColor = System.Drawing.Color.Black;
            this.label18.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label18.Location = new System.Drawing.Point(0, 24);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(483, 1);
            this.label18.TabIndex = 0;
            this.label18.Text = "label18";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel14
            // 
            this.panel14.Controls.Add(this.panel22);
            this.panel14.Controls.Add(this.label14);
            this.panel14.Controls.Add(this.panel18);
            this.panel14.Controls.Add(this.label13);
            this.panel14.Controls.Add(this.panel15);
            this.panel14.Controls.Add(this.label7);
            this.panel14.Controls.Add(this.label9);
            this.panel14.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel14.Location = new System.Drawing.Point(0, 201);
            this.panel14.Name = "panel14";
            this.panel14.Size = new System.Drawing.Size(483, 25);
            this.panel14.TabIndex = 0;
            // 
            // panel22
            // 
            this.panel22.Controls.Add(this.SHANG_S);
            this.panel22.Controls.Add(this.label49);
            this.panel22.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel22.Location = new System.Drawing.Point(341, 0);
            this.panel22.Name = "panel22";
            this.panel22.Padding = new System.Windows.Forms.Padding(2, 2, 8, 2);
            this.panel22.Size = new System.Drawing.Size(120, 24);
            this.panel22.TabIndex = 0;
            // 
            // label49
            // 
            this.label49.Dock = System.Windows.Forms.DockStyle.Right;
            this.label49.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label49.ForeColor = System.Drawing.Color.Blue;
            this.label49.Location = new System.Drawing.Point(88, 2);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(24, 20);
            this.label49.TabIndex = 0;
            this.label49.Text = "人";
            this.label49.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label14
            // 
            this.label14.Dock = System.Windows.Forms.DockStyle.Left;
            this.label14.Location = new System.Drawing.Point(305, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(36, 24);
            this.label14.TabIndex = 0;
            this.label14.Text = "死亡";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel18
            // 
            this.panel18.Controls.Add(this.SHANG_Z);
            this.panel18.Controls.Add(this.label34);
            this.panel18.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel18.Location = new System.Drawing.Point(189, 0);
            this.panel18.Name = "panel18";
            this.panel18.Padding = new System.Windows.Forms.Padding(2, 2, 8, 2);
            this.panel18.Size = new System.Drawing.Size(116, 24);
            this.panel18.TabIndex = 0;
            // 
            // label34
            // 
            this.label34.Dock = System.Windows.Forms.DockStyle.Right;
            this.label34.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label34.ForeColor = System.Drawing.Color.Blue;
            this.label34.Location = new System.Drawing.Point(84, 2);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(24, 20);
            this.label34.TabIndex = 0;
            this.label34.Text = "人";
            this.label34.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label13
            // 
            this.label13.Dock = System.Windows.Forms.DockStyle.Left;
            this.label13.Location = new System.Drawing.Point(153, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(36, 24);
            this.label13.TabIndex = 0;
            this.label13.Text = "重伤";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel15
            // 
            this.panel15.Controls.Add(this.SHANG_Q);
            this.panel15.Controls.Add(this.label33);
            this.panel15.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel15.Location = new System.Drawing.Point(36, 0);
            this.panel15.Name = "panel15";
            this.panel15.Padding = new System.Windows.Forms.Padding(2, 2, 8, 2);
            this.panel15.Size = new System.Drawing.Size(117, 24);
            this.panel15.TabIndex = 0;
            // 
            // label33
            // 
            this.label33.Dock = System.Windows.Forms.DockStyle.Right;
            this.label33.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label33.ForeColor = System.Drawing.Color.Blue;
            this.label33.Location = new System.Drawing.Point(85, 2);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(24, 20);
            this.label33.TabIndex = 0;
            this.label33.Text = "人";
            this.label33.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.Dock = System.Windows.Forms.DockStyle.Left;
            this.label7.Location = new System.Drawing.Point(0, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(36, 24);
            this.label7.TabIndex = 0;
            this.label7.Text = "轻伤";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.Black;
            this.label9.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label9.Location = new System.Drawing.Point(0, 24);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(483, 1);
            this.label9.TabIndex = 0;
            this.label9.Text = "label9";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel11
            // 
            this.panel11.Controls.Add(this.panel17);
            this.panel11.Controls.Add(this.label11);
            this.panel11.Controls.Add(this.panel13);
            this.panel11.Controls.Add(this.label4);
            this.panel11.Controls.Add(this.label6);
            this.panel11.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel11.Location = new System.Drawing.Point(0, 176);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(483, 25);
            this.panel11.TabIndex = 0;
            // 
            // panel17
            // 
            this.panel17.Controls.Add(this.NL);
            this.panel17.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel17.Location = new System.Drawing.Point(276, 0);
            this.panel17.Name = "panel17";
            this.panel17.Padding = new System.Windows.Forms.Padding(2, 6, 8, 0);
            this.panel17.Size = new System.Drawing.Size(185, 24);
            this.panel17.TabIndex = 0;
            // 
            // NL
            // 
            this.NL.Cursor = System.Windows.Forms.Cursors.Hand;
            this.NL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NL.EditValue = "";
            this.NL.Location = new System.Drawing.Point(2, 6);
            this.NL.Name = "NL";
            this.NL.Properties.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.NL.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.NL.Properties.Appearance.Options.UseFont = true;
            this.NL.Properties.Appearance.Options.UseForeColor = true;
            this.NL.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.White;
            this.NL.Properties.AppearanceReadOnly.Options.UseBackColor = true;
            this.NL.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.NL.Properties.MaxLength = 30;
            this.NL.Size = new System.Drawing.Size(175, 16);
            this.NL.TabIndex = 15;
            this.NL.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // label11
            // 
            this.label11.Dock = System.Windows.Forms.DockStyle.Left;
            this.label11.Location = new System.Drawing.Point(236, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(40, 24);
            this.label11.TabIndex = 0;
            this.label11.Text = "林龄";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel13
            // 
            this.panel13.Controls.Add(this.LINFEN);
            this.panel13.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel13.Location = new System.Drawing.Point(58, 0);
            this.panel13.Name = "panel13";
            this.panel13.Padding = new System.Windows.Forms.Padding(2, 6, 8, 0);
            this.panel13.Size = new System.Drawing.Size(178, 24);
            this.panel13.TabIndex = 0;
            // 
            // LINFEN
            // 
            this.LINFEN.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LINFEN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LINFEN.EditValue = "";
            this.LINFEN.Location = new System.Drawing.Point(2, 6);
            this.LINFEN.Name = "LINFEN";
            this.LINFEN.Properties.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LINFEN.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.LINFEN.Properties.Appearance.Options.UseFont = true;
            this.LINFEN.Properties.Appearance.Options.UseForeColor = true;
            this.LINFEN.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.White;
            this.LINFEN.Properties.AppearanceReadOnly.Options.UseBackColor = true;
            this.LINFEN.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.LINFEN.Properties.MaxLength = 30;
            this.LINFEN.Size = new System.Drawing.Size(168, 16);
            this.LINFEN.TabIndex = 14;
            this.LINFEN.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Left;
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 24);
            this.label4.TabIndex = 0;
            this.label4.Text = "林分组成";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.Black;
            this.label6.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label6.Location = new System.Drawing.Point(0, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(483, 1);
            this.label6.TabIndex = 0;
            this.label6.Text = "label6";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel46
            // 
            this.panel46.Controls.Add(this.buttonCalc);
            this.panel46.Controls.Add(this.label81);
            this.panel46.Controls.Add(this.panel48);
            this.panel46.Controls.Add(this.panel54);
            this.panel46.Controls.Add(this.label57);
            this.panel46.Controls.Add(this.label101);
            this.panel46.Controls.Add(this.label80);
            this.panel46.Controls.Add(this.panel49);
            this.panel46.Controls.Add(this.label95);
            this.panel46.Controls.Add(this.panel47);
            this.panel46.Controls.Add(this.label105);
            this.panel46.Controls.Add(this.label83);
            this.panel46.Controls.Add(this.label84);
            this.panel46.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel46.Location = new System.Drawing.Point(0, 126);
            this.panel46.Name = "panel46";
            this.panel46.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.panel46.Size = new System.Drawing.Size(483, 50);
            this.panel46.TabIndex = 0;
            // 
            // buttonCalc
            // 
            this.buttonCalc.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonCalc.Location = new System.Drawing.Point(448, 0);
            this.buttonCalc.Name = "buttonCalc";
            this.buttonCalc.Size = new System.Drawing.Size(33, 49);
            this.buttonCalc.TabIndex = 1;
            this.buttonCalc.Text = "自动\r\n计算";
            this.buttonCalc.ToolTip = "依据斑块的灾害面积、损失蓄积、损失株数、起源、龄组计算";
            this.buttonCalc.Click += new System.EventHandler(this.buttonCalc_Click);
            // 
            // label81
            // 
            this.label81.BackColor = System.Drawing.Color.Black;
            this.label81.Dock = System.Windows.Forms.DockStyle.Left;
            this.label81.Location = new System.Drawing.Point(412, 0);
            this.label81.Name = "label81";
            this.label81.Size = new System.Drawing.Size(1, 49);
            this.label81.TabIndex = 0;
            this.label81.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel48
            // 
            this.panel48.Controls.Add(this.panel61);
            this.panel48.Controls.Add(this.label96);
            this.panel48.Controls.Add(this.panel62);
            this.panel48.Controls.Add(this.label97);
            this.panel48.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel48.Location = new System.Drawing.Point(302, 0);
            this.panel48.Name = "panel48";
            this.panel48.Size = new System.Drawing.Size(110, 49);
            this.panel48.TabIndex = 0;
            // 
            // panel61
            // 
            this.panel61.Controls.Add(this.SS_YL);
            this.panel61.Controls.Add(this.label115);
            this.panel61.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel61.Location = new System.Drawing.Point(1, 25);
            this.panel61.Name = "panel61";
            this.panel61.Padding = new System.Windows.Forms.Padding(1, 2, 2, 2);
            this.panel61.Size = new System.Drawing.Size(109, 24);
            this.panel61.TabIndex = 0;
            // 
            // label115
            // 
            this.label115.Dock = System.Windows.Forms.DockStyle.Right;
            this.label115.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label115.ForeColor = System.Drawing.Color.Blue;
            this.label115.Location = new System.Drawing.Point(73, 2);
            this.label115.Name = "label115";
            this.label115.Size = new System.Drawing.Size(34, 20);
            this.label115.TabIndex = 0;
            this.label115.Text = "万株";
            this.label115.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label96
            // 
            this.label96.BackColor = System.Drawing.Color.Black;
            this.label96.Dock = System.Windows.Forms.DockStyle.Top;
            this.label96.Location = new System.Drawing.Point(1, 24);
            this.label96.Name = "label96";
            this.label96.Size = new System.Drawing.Size(109, 1);
            this.label96.TabIndex = 0;
            this.label96.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel62
            // 
            this.panel62.Controls.Add(this.SS_CL);
            this.panel62.Controls.Add(this.label116);
            this.panel62.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel62.Location = new System.Drawing.Point(1, 0);
            this.panel62.Name = "panel62";
            this.panel62.Padding = new System.Windows.Forms.Padding(1, 2, 2, 2);
            this.panel62.Size = new System.Drawing.Size(109, 24);
            this.panel62.TabIndex = 0;
            // 
            // label116
            // 
            this.label116.Dock = System.Windows.Forms.DockStyle.Right;
            this.label116.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label116.ForeColor = System.Drawing.Color.Blue;
            this.label116.Location = new System.Drawing.Point(73, 2);
            this.label116.Name = "label116";
            this.label116.Size = new System.Drawing.Size(34, 20);
            this.label116.TabIndex = 0;
            this.label116.Text = "m³";
            this.label116.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label97
            // 
            this.label97.BackColor = System.Drawing.Color.Black;
            this.label97.Dock = System.Windows.Forms.DockStyle.Left;
            this.label97.Location = new System.Drawing.Point(0, 0);
            this.label97.Name = "label97";
            this.label97.Size = new System.Drawing.Size(1, 49);
            this.label97.TabIndex = 0;
            this.label97.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel54
            // 
            this.panel54.Controls.Add(this.label00);
            this.panel54.Controls.Add(this.label99);
            this.panel54.Controls.Add(this.label100);
            this.panel54.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel54.Location = new System.Drawing.Point(262, 0);
            this.panel54.Name = "panel54";
            this.panel54.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.panel54.Size = new System.Drawing.Size(40, 49);
            this.panel54.TabIndex = 0;
            // 
            // label00
            // 
            this.label00.Dock = System.Windows.Forms.DockStyle.Top;
            this.label00.ForeColor = System.Drawing.Color.Black;
            this.label00.Location = new System.Drawing.Point(0, 25);
            this.label00.Name = "label00";
            this.label00.Size = new System.Drawing.Size(40, 22);
            this.label00.TabIndex = 0;
            this.label00.Text = "幼林";
            this.label00.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label99
            // 
            this.label99.BackColor = System.Drawing.Color.Black;
            this.label99.Dock = System.Windows.Forms.DockStyle.Top;
            this.label99.Location = new System.Drawing.Point(0, 24);
            this.label99.Name = "label99";
            this.label99.Size = new System.Drawing.Size(40, 1);
            this.label99.TabIndex = 0;
            this.label99.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label100
            // 
            this.label100.Dock = System.Windows.Forms.DockStyle.Top;
            this.label100.ForeColor = System.Drawing.Color.Black;
            this.label100.Location = new System.Drawing.Point(0, 2);
            this.label100.Name = "label100";
            this.label100.Size = new System.Drawing.Size(40, 22);
            this.label100.TabIndex = 0;
            this.label100.Text = "成林";
            this.label100.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label57
            // 
            this.label57.BackColor = System.Drawing.Color.Black;
            this.label57.Dock = System.Windows.Forms.DockStyle.Left;
            this.label57.Location = new System.Drawing.Point(261, 0);
            this.label57.Name = "label57";
            this.label57.Size = new System.Drawing.Size(1, 49);
            this.label57.TabIndex = 0;
            this.label57.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label101
            // 
            this.label101.Dock = System.Windows.Forms.DockStyle.Left;
            this.label101.Location = new System.Drawing.Point(222, 0);
            this.label101.Name = "label101";
            this.label101.Size = new System.Drawing.Size(39, 49);
            this.label101.TabIndex = 0;
            this.label101.Text = "林木损失";
            this.label101.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label80
            // 
            this.label80.BackColor = System.Drawing.Color.Black;
            this.label80.Dock = System.Windows.Forms.DockStyle.Left;
            this.label80.Location = new System.Drawing.Point(221, 0);
            this.label80.Name = "label80";
            this.label80.Size = new System.Drawing.Size(1, 49);
            this.label80.TabIndex = 0;
            this.label80.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel49
            // 
            this.panel49.Controls.Add(this.panel92);
            this.panel49.Controls.Add(this.label82);
            this.panel49.Controls.Add(this.panel91);
            this.panel49.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel49.Location = new System.Drawing.Point(111, 0);
            this.panel49.Name = "panel49";
            this.panel49.Padding = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.panel49.Size = new System.Drawing.Size(110, 49);
            this.panel49.TabIndex = 0;
            // 
            // panel92
            // 
            this.panel92.Controls.Add(this.RGL_MJ);
            this.panel92.Controls.Add(this.label56);
            this.panel92.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel92.Location = new System.Drawing.Point(0, 25);
            this.panel92.Name = "panel92";
            this.panel92.Padding = new System.Windows.Forms.Padding(1, 2, 2, 2);
            this.panel92.Size = new System.Drawing.Size(110, 24);
            this.panel92.TabIndex = 0;
            // 
            // label56
            // 
            this.label56.Dock = System.Windows.Forms.DockStyle.Right;
            this.label56.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label56.ForeColor = System.Drawing.Color.Blue;
            this.label56.Location = new System.Drawing.Point(74, 2);
            this.label56.Name = "label56";
            this.label56.Size = new System.Drawing.Size(34, 20);
            this.label56.TabIndex = 0;
            this.label56.Text = "公顷";
            this.label56.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label82
            // 
            this.label82.BackColor = System.Drawing.Color.Black;
            this.label82.Dock = System.Windows.Forms.DockStyle.Top;
            this.label82.Location = new System.Drawing.Point(0, 24);
            this.label82.Name = "label82";
            this.label82.Size = new System.Drawing.Size(110, 1);
            this.label82.TabIndex = 0;
            this.label82.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel91
            // 
            this.panel91.Controls.Add(this.YSL_MJ);
            this.panel91.Controls.Add(this.label55);
            this.panel91.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel91.Location = new System.Drawing.Point(0, 0);
            this.panel91.Name = "panel91";
            this.panel91.Padding = new System.Windows.Forms.Padding(1, 2, 2, 2);
            this.panel91.Size = new System.Drawing.Size(110, 24);
            this.panel91.TabIndex = 0;
            // 
            // label55
            // 
            this.label55.Dock = System.Windows.Forms.DockStyle.Right;
            this.label55.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label55.ForeColor = System.Drawing.Color.Blue;
            this.label55.Location = new System.Drawing.Point(74, 2);
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size(34, 20);
            this.label55.TabIndex = 0;
            this.label55.Text = "公顷";
            this.label55.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label95
            // 
            this.label95.BackColor = System.Drawing.Color.Black;
            this.label95.Dock = System.Windows.Forms.DockStyle.Left;
            this.label95.Location = new System.Drawing.Point(110, 0);
            this.label95.Name = "label95";
            this.label95.Size = new System.Drawing.Size(1, 49);
            this.label95.TabIndex = 0;
            this.label95.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel47
            // 
            this.panel47.Controls.Add(this.label85);
            this.panel47.Controls.Add(this.label94);
            this.panel47.Controls.Add(this.label79);
            this.panel47.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel47.Location = new System.Drawing.Point(59, 0);
            this.panel47.Name = "panel47";
            this.panel47.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.panel47.Size = new System.Drawing.Size(51, 49);
            this.panel47.TabIndex = 0;
            // 
            // label85
            // 
            this.label85.Dock = System.Windows.Forms.DockStyle.Top;
            this.label85.ForeColor = System.Drawing.Color.Black;
            this.label85.Location = new System.Drawing.Point(0, 25);
            this.label85.Name = "label85";
            this.label85.Size = new System.Drawing.Size(51, 22);
            this.label85.TabIndex = 0;
            this.label85.Text = "人工林";
            this.label85.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label94
            // 
            this.label94.BackColor = System.Drawing.Color.Black;
            this.label94.Dock = System.Windows.Forms.DockStyle.Top;
            this.label94.Location = new System.Drawing.Point(0, 24);
            this.label94.Name = "label94";
            this.label94.Size = new System.Drawing.Size(51, 1);
            this.label94.TabIndex = 0;
            this.label94.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label79
            // 
            this.label79.Dock = System.Windows.Forms.DockStyle.Top;
            this.label79.ForeColor = System.Drawing.Color.Black;
            this.label79.Location = new System.Drawing.Point(0, 2);
            this.label79.Name = "label79";
            this.label79.Size = new System.Drawing.Size(51, 22);
            this.label79.TabIndex = 0;
            this.label79.Text = "原始林";
            this.label79.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label105
            // 
            this.label105.BackColor = System.Drawing.Color.Black;
            this.label105.Dock = System.Windows.Forms.DockStyle.Left;
            this.label105.Location = new System.Drawing.Point(58, 0);
            this.label105.Name = "label105";
            this.label105.Size = new System.Drawing.Size(1, 49);
            this.label105.TabIndex = 0;
            this.label105.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label83
            // 
            this.label83.Dock = System.Windows.Forms.DockStyle.Left;
            this.label83.Location = new System.Drawing.Point(0, 0);
            this.label83.Name = "label83";
            this.label83.Size = new System.Drawing.Size(58, 49);
            this.label83.TabIndex = 0;
            this.label83.Text = "受害森林面积";
            this.label83.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label84
            // 
            this.label84.BackColor = System.Drawing.Color.Black;
            this.label84.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label84.Location = new System.Drawing.Point(0, 49);
            this.label84.Name = "label84";
            this.label84.Size = new System.Drawing.Size(481, 1);
            this.label84.TabIndex = 0;
            this.label84.Text = "label84";
            this.label84.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label15
            // 
            this.label15.BackColor = System.Drawing.Color.Black;
            this.label15.Dock = System.Windows.Forms.DockStyle.Top;
            this.label15.Location = new System.Drawing.Point(0, 125);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(483, 1);
            this.label15.TabIndex = 0;
            this.label15.Text = "label15";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label93
            // 
            this.label93.Dock = System.Windows.Forms.DockStyle.Top;
            this.label93.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label93.Location = new System.Drawing.Point(0, 100);
            this.label93.Name = "label93";
            this.label93.Size = new System.Drawing.Size(483, 25);
            this.label93.TabIndex = 0;
            this.label93.Text = " 损失情况";
            this.label93.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.panel3);
            this.panel5.Controls.Add(this.label58);
            this.panel5.Controls.Add(this.panel8);
            this.panel5.Controls.Add(this.label1);
            this.panel5.Controls.Add(this.panel9);
            this.panel5.Controls.Add(this.label2);
            this.panel5.Controls.Add(this.label3);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 75);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(483, 25);
            this.panel5.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.TOTAL_MJ);
            this.panel3.Controls.Add(this.label48);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(357, 0);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(2, 2, 4, 2);
            this.panel3.Size = new System.Drawing.Size(104, 24);
            this.panel3.TabIndex = 0;
            // 
            // label48
            // 
            this.label48.Dock = System.Windows.Forms.DockStyle.Right;
            this.label48.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label48.ForeColor = System.Drawing.Color.Blue;
            this.label48.Location = new System.Drawing.Point(66, 2);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(34, 20);
            this.label48.TabIndex = 0;
            this.label48.Text = "公顷";
            this.label48.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label58
            // 
            this.label58.Dock = System.Windows.Forms.DockStyle.Left;
            this.label58.Location = new System.Drawing.Point(289, 0);
            this.label58.Name = "label58";
            this.label58.Size = new System.Drawing.Size(68, 24);
            this.label58.TabIndex = 0;
            this.label58.Text = "火场总面积";
            this.label58.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.HZDJ);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel8.Location = new System.Drawing.Point(211, 0);
            this.panel8.Name = "panel8";
            this.panel8.Padding = new System.Windows.Forms.Padding(2, 2, 4, 0);
            this.panel8.Size = new System.Drawing.Size(78, 24);
            this.panel8.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Location = new System.Drawing.Point(153, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "火灾等级";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.HZYY);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel9.Location = new System.Drawing.Point(58, 0);
            this.panel9.Name = "panel9";
            this.panel9.Padding = new System.Windows.Forms.Padding(2, 2, 4, 0);
            this.panel9.Size = new System.Drawing.Size(95, 24);
            this.panel9.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Left;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 24);
            this.label2.TabIndex = 0;
            this.label2.Text = "火灾原因";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Black;
            this.label3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label3.Location = new System.Drawing.Point(0, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(483, 1);
            this.label3.TabIndex = 0;
            this.label3.Text = "label3";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel16
            // 
            this.panel16.Controls.Add(this.panel19);
            this.panel16.Controls.Add(this.label40);
            this.panel16.Controls.Add(this.panel20);
            this.panel16.Controls.Add(this.label41);
            this.panel16.Controls.Add(this.label42);
            this.panel16.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel16.Location = new System.Drawing.Point(0, 50);
            this.panel16.Name = "panel16";
            this.panel16.Size = new System.Drawing.Size(483, 25);
            this.panel16.TabIndex = 0;
            // 
            // panel19
            // 
            this.panel19.Controls.Add(this.PHSJ);
            this.panel19.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel19.Location = new System.Drawing.Point(313, 0);
            this.panel19.Name = "panel19";
            this.panel19.Padding = new System.Windows.Forms.Padding(2, 4, 8, 0);
            this.panel19.Size = new System.Drawing.Size(148, 24);
            this.panel19.TabIndex = 0;
            // 
            // PHSJ
            // 
            this.PHSJ.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PHSJ.EditValue = null;
            this.PHSJ.Location = new System.Drawing.Point(2, 4);
            this.PHSJ.Name = "PHSJ";
            this.PHSJ.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.PHSJ.Properties.Appearance.Options.UseForeColor = true;
            this.PHSJ.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.White;
            this.PHSJ.Properties.AppearanceReadOnly.Options.UseBackColor = true;
            this.PHSJ.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.PHSJ.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.PHSJ.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.PHSJ.Properties.DisplayFormat.FormatString = "yyyy/MM/dd HH:mm:ss";
            this.PHSJ.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.PHSJ.Properties.EditFormat.FormatString = "G";
            this.PHSJ.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.PHSJ.Properties.Mask.EditMask = "G";
            this.PHSJ.Size = new System.Drawing.Size(138, 18);
            this.PHSJ.TabIndex = 6;
            this.PHSJ.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // label40
            // 
            this.label40.Dock = System.Windows.Forms.DockStyle.Left;
            this.label40.Location = new System.Drawing.Point(255, 0);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(58, 24);
            this.label40.TabIndex = 0;
            this.label40.Text = "扑火时间";
            this.label40.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel20
            // 
            this.panel20.Controls.Add(this.QHSJ);
            this.panel20.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel20.Location = new System.Drawing.Point(107, 0);
            this.panel20.Name = "panel20";
            this.panel20.Padding = new System.Windows.Forms.Padding(2, 4, 8, 0);
            this.panel20.Size = new System.Drawing.Size(148, 24);
            this.panel20.TabIndex = 0;
            // 
            // QHSJ
            // 
            this.QHSJ.Dock = System.Windows.Forms.DockStyle.Fill;
            this.QHSJ.EditValue = null;
            this.QHSJ.Location = new System.Drawing.Point(2, 4);
            this.QHSJ.Name = "QHSJ";
            this.QHSJ.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.QHSJ.Properties.Appearance.Options.UseForeColor = true;
            this.QHSJ.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.White;
            this.QHSJ.Properties.AppearanceReadOnly.Options.UseBackColor = true;
            this.QHSJ.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.QHSJ.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.QHSJ.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.QHSJ.Properties.DisplayFormat.FormatString = "yyyy/MM/dd HH:mm:ss";
            this.QHSJ.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.QHSJ.Properties.EditFormat.FormatString = "G";
            this.QHSJ.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.QHSJ.Properties.Mask.EditMask = "G";
            this.QHSJ.Size = new System.Drawing.Size(138, 18);
            this.QHSJ.TabIndex = 5;
            this.QHSJ.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // label41
            // 
            this.label41.Dock = System.Windows.Forms.DockStyle.Left;
            this.label41.Location = new System.Drawing.Point(0, 0);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(107, 24);
            this.label41.TabIndex = 0;
            this.label41.Text = "起火（发现）时间";
            this.label41.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label42
            // 
            this.label42.BackColor = System.Drawing.Color.Black;
            this.label42.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label42.Location = new System.Drawing.Point(0, 24);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(483, 1);
            this.label42.TabIndex = 0;
            this.label42.Text = "label42";
            this.label42.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.panel6);
            this.panel7.Controls.Add(this.label5);
            this.panel7.Controls.Add(this.label10);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel7.Location = new System.Drawing.Point(0, 25);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(483, 25);
            this.panel7.TabIndex = 0;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.DIMING);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel6.Location = new System.Drawing.Point(58, 0);
            this.panel6.Name = "panel6";
            this.panel6.Padding = new System.Windows.Forms.Padding(2, 6, 8, 0);
            this.panel6.Size = new System.Drawing.Size(403, 24);
            this.panel6.TabIndex = 0;
            // 
            // DIMING
            // 
            this.DIMING.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DIMING.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DIMING.EditValue = "";
            this.DIMING.Location = new System.Drawing.Point(2, 6);
            this.DIMING.Name = "DIMING";
            this.DIMING.Properties.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DIMING.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.DIMING.Properties.Appearance.Options.UseFont = true;
            this.DIMING.Properties.Appearance.Options.UseForeColor = true;
            this.DIMING.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.White;
            this.DIMING.Properties.AppearanceReadOnly.Options.UseBackColor = true;
            this.DIMING.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.DIMING.Properties.MaxLength = 100;
            this.DIMING.Size = new System.Drawing.Size(393, 16);
            this.DIMING.TabIndex = 4;
            this.DIMING.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // label5
            // 
            this.label5.Dock = System.Windows.Forms.DockStyle.Left;
            this.label5.Location = new System.Drawing.Point(0, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 24);
            this.label5.TabIndex = 0;
            this.label5.Text = "小地名";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.Black;
            this.label10.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label10.Location = new System.Drawing.Point(0, 24);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(483, 1);
            this.label10.TabIndex = 0;
            this.label10.Text = "label10";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel12
            // 
            this.panel12.Controls.Add(this.panel10);
            this.panel12.Controls.Add(this.label8);
            this.panel12.Controls.Add(this.panel30);
            this.panel12.Controls.Add(this.label52);
            this.panel12.Controls.Add(this.panel32);
            this.panel12.Controls.Add(this.label53);
            this.panel12.Controls.Add(this.label54);
            this.panel12.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel12.Location = new System.Drawing.Point(0, 0);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(483, 25);
            this.panel12.TabIndex = 0;
            // 
            // panel10
            // 
            this.panel10.Controls.Add(this.CUN);
            this.panel10.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel10.Location = new System.Drawing.Point(345, 0);
            this.panel10.Name = "panel10";
            this.panel10.Padding = new System.Windows.Forms.Padding(2, 2, 4, 0);
            this.panel10.Size = new System.Drawing.Size(116, 24);
            this.panel10.TabIndex = 0;
            // 
            // label8
            // 
            this.label8.Dock = System.Windows.Forms.DockStyle.Left;
            this.label8.Location = new System.Drawing.Point(305, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(40, 24);
            this.label8.TabIndex = 0;
            this.label8.Text = "村";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel30
            // 
            this.panel30.Controls.Add(this.XIANG);
            this.panel30.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel30.Location = new System.Drawing.Point(189, 0);
            this.panel30.Name = "panel30";
            this.panel30.Padding = new System.Windows.Forms.Padding(2, 2, 4, 0);
            this.panel30.Size = new System.Drawing.Size(116, 24);
            this.panel30.TabIndex = 0;
            // 
            // label52
            // 
            this.label52.Dock = System.Windows.Forms.DockStyle.Left;
            this.label52.Location = new System.Drawing.Point(153, 0);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(36, 24);
            this.label52.TabIndex = 0;
            this.label52.Text = "乡镇";
            this.label52.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel32
            // 
            this.panel32.Controls.Add(this.XIAN);
            this.panel32.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel32.Location = new System.Drawing.Point(36, 0);
            this.panel32.Name = "panel32";
            this.panel32.Padding = new System.Windows.Forms.Padding(2, 2, 4, 0);
            this.panel32.Size = new System.Drawing.Size(117, 24);
            this.panel32.TabIndex = 0;
            // 
            // label53
            // 
            this.label53.Dock = System.Windows.Forms.DockStyle.Left;
            this.label53.Location = new System.Drawing.Point(0, 0);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(36, 24);
            this.label53.TabIndex = 0;
            this.label53.Text = "区县";
            this.label53.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label54
            // 
            this.label54.BackColor = System.Drawing.Color.Black;
            this.label54.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label54.Location = new System.Drawing.Point(0, 24);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(483, 1);
            this.label54.TabIndex = 0;
            this.label54.Text = "label54";
            this.label54.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label35
            // 
            this.label35.BackColor = System.Drawing.Color.Black;
            this.label35.Dock = System.Windows.Forms.DockStyle.Top;
            this.label35.Location = new System.Drawing.Point(1, 0);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(483, 1);
            this.label35.TabIndex = 0;
            this.label35.Text = "label35";
            this.label35.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label36
            // 
            this.label36.BackColor = System.Drawing.Color.Black;
            this.label36.Dock = System.Windows.Forms.DockStyle.Left;
            this.label36.Location = new System.Drawing.Point(0, 0);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(1, 379);
            this.label36.TabIndex = 0;
            this.label36.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label37
            // 
            this.label37.BackColor = System.Drawing.Color.Black;
            this.label37.Dock = System.Windows.Forms.DockStyle.Right;
            this.label37.Location = new System.Drawing.Point(484, 0);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(1, 379);
            this.label37.TabIndex = 0;
            this.label37.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CL_XSRS
            // 
            this.CL_XSRS.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CL_XSRS.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.CL_XSRS.EditScale = 0;
            this.CL_XSRS.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.CL_XSRS.Location = new System.Drawing.Point(2, 4);
            this.CL_XSRS.Name = "CL_XSRS";
            this.CL_XSRS.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.CL_XSRS.Properties.Appearance.Options.UseForeColor = true;
            this.CL_XSRS.Properties.Appearance.Options.UseTextOptions = true;
            this.CL_XSRS.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.CL_XSRS.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.White;
            this.CL_XSRS.Properties.AppearanceReadOnly.Options.UseBackColor = true;
            this.CL_XSRS.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.CL_XSRS.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.CL_XSRS.Properties.MaxValue = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.CL_XSRS.Size = new System.Drawing.Size(49, 18);
            this.CL_XSRS.TabIndex = 28;
            this.CL_XSRS.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // CL_RS
            // 
            this.CL_RS.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CL_RS.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.CL_RS.EditScale = 0;
            this.CL_RS.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.CL_RS.Location = new System.Drawing.Point(2, 4);
            this.CL_RS.Name = "CL_RS";
            this.CL_RS.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.CL_RS.Properties.Appearance.Options.UseForeColor = true;
            this.CL_RS.Properties.Appearance.Options.UseTextOptions = true;
            this.CL_RS.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.CL_RS.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.White;
            this.CL_RS.Properties.AppearanceReadOnly.Options.UseBackColor = true;
            this.CL_RS.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.CL_RS.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.CL_RS.Properties.MaxValue = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.CL_RS.Size = new System.Drawing.Size(50, 18);
            this.CL_RS.TabIndex = 27;
            this.CL_RS.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // SF_CL
            // 
            this.SF_CL.AssDispValue = true;
            this.SF_CL.BackColor = System.Drawing.Color.White;
            this.SF_CL.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SF_CL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SF_CL.ForeColor = System.Drawing.Color.Blue;
            this.SF_CL.Location = new System.Drawing.Point(2, 2);
            this.SF_CL.Name = "SF_CL";
            this.SF_CL.Size = new System.Drawing.Size(64, 22);
            this.SF_CL.TabIndex = 26;
            this.SF_CL.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // PU_JF
            // 
            this.PU_JF.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PU_JF.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PU_JF.EditScale = 0;
            this.PU_JF.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.PU_JF.Location = new System.Drawing.Point(2, 4);
            this.PU_JF.Name = "PU_JF";
            this.PU_JF.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.PU_JF.Properties.Appearance.Options.UseForeColor = true;
            this.PU_JF.Properties.Appearance.Options.UseTextOptions = true;
            this.PU_JF.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.PU_JF.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.White;
            this.PU_JF.Properties.AppearanceReadOnly.Options.UseBackColor = true;
            this.PU_JF.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.PU_JF.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.PU_JF.Properties.MaxValue = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.PU_JF.Size = new System.Drawing.Size(79, 18);
            this.PU_JF.TabIndex = 25;
            this.PU_JF.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // PU_FJ
            // 
            this.PU_FJ.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PU_FJ.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PU_FJ.EditScale = 0;
            this.PU_FJ.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.PU_FJ.Location = new System.Drawing.Point(2, 4);
            this.PU_FJ.Name = "PU_FJ";
            this.PU_FJ.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.PU_FJ.Properties.Appearance.Options.UseForeColor = true;
            this.PU_FJ.Properties.Appearance.Options.UseTextOptions = true;
            this.PU_FJ.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.PU_FJ.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.White;
            this.PU_FJ.Properties.AppearanceReadOnly.Options.UseBackColor = true;
            this.PU_FJ.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.PU_FJ.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.PU_FJ.Properties.MaxValue = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.PU_FJ.Size = new System.Drawing.Size(60, 18);
            this.PU_FJ.TabIndex = 24;
            this.PU_FJ.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // PU_QC
            // 
            this.PU_QC.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PU_QC.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PU_QC.EditScale = 0;
            this.PU_QC.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.PU_QC.Location = new System.Drawing.Point(2, 4);
            this.PU_QC.Name = "PU_QC";
            this.PU_QC.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.PU_QC.Properties.Appearance.Options.UseForeColor = true;
            this.PU_QC.Properties.Appearance.Options.UseTextOptions = true;
            this.PU_QC.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.PU_QC.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.White;
            this.PU_QC.Properties.AppearanceReadOnly.Options.UseBackColor = true;
            this.PU_QC.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.PU_QC.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.PU_QC.Properties.MaxValue = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.PU_QC.Size = new System.Drawing.Size(62, 18);
            this.PU_QC.TabIndex = 23;
            this.PU_QC.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // PU_CL
            // 
            this.PU_CL.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PU_CL.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PU_CL.EditScale = 0;
            this.PU_CL.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.PU_CL.Location = new System.Drawing.Point(2, 4);
            this.PU_CL.Name = "PU_CL";
            this.PU_CL.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.PU_CL.Properties.Appearance.Options.UseForeColor = true;
            this.PU_CL.Properties.Appearance.Options.UseTextOptions = true;
            this.PU_CL.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.PU_CL.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.White;
            this.PU_CL.Properties.AppearanceReadOnly.Options.UseBackColor = true;
            this.PU_CL.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.PU_CL.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.PU_CL.Properties.MaxValue = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.PU_CL.Size = new System.Drawing.Size(62, 18);
            this.PU_CL.TabIndex = 22;
            this.PU_CL.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // PU_RG
            // 
            this.PU_RG.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PU_RG.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PU_RG.EditScale = 0;
            this.PU_RG.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.PU_RG.Location = new System.Drawing.Point(2, 4);
            this.PU_RG.Name = "PU_RG";
            this.PU_RG.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.PU_RG.Properties.Appearance.Options.UseForeColor = true;
            this.PU_RG.Properties.Appearance.Options.UseTextOptions = true;
            this.PU_RG.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.PU_RG.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.White;
            this.PU_RG.Properties.AppearanceReadOnly.Options.UseBackColor = true;
            this.PU_RG.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.PU_RG.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.PU_RG.Properties.MaxValue = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.PU_RG.Size = new System.Drawing.Size(60, 18);
            this.PU_RG.TabIndex = 21;
            this.PU_RG.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // SS_ZLMJ
            // 
            this.SS_ZLMJ.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SS_ZLMJ.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.SS_ZLMJ.EditScale = 0;
            this.SS_ZLMJ.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.SS_ZLMJ.Location = new System.Drawing.Point(2, 4);
            this.SS_ZLMJ.Name = "SS_ZLMJ";
            this.SS_ZLMJ.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.SS_ZLMJ.Properties.Appearance.Options.UseForeColor = true;
            this.SS_ZLMJ.Properties.Appearance.Options.UseTextOptions = true;
            this.SS_ZLMJ.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.SS_ZLMJ.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.White;
            this.SS_ZLMJ.Properties.AppearanceReadOnly.Options.UseBackColor = true;
            this.SS_ZLMJ.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.SS_ZLMJ.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.SS_ZLMJ.Properties.MaxValue = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.SS_ZLMJ.Size = new System.Drawing.Size(71, 18);
            this.SS_ZLMJ.TabIndex = 20;
            this.SS_ZLMJ.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // SS_MONEY
            // 
            this.SS_MONEY.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SS_MONEY.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.SS_MONEY.EditScale = 0;
            this.SS_MONEY.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.SS_MONEY.Location = new System.Drawing.Point(2, 4);
            this.SS_MONEY.Name = "SS_MONEY";
            this.SS_MONEY.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.SS_MONEY.Properties.Appearance.Options.UseForeColor = true;
            this.SS_MONEY.Properties.Appearance.Options.UseTextOptions = true;
            this.SS_MONEY.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.SS_MONEY.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.White;
            this.SS_MONEY.Properties.AppearanceReadOnly.Options.UseBackColor = true;
            this.SS_MONEY.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.SS_MONEY.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.SS_MONEY.Properties.MaxValue = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.SS_MONEY.Size = new System.Drawing.Size(70, 18);
            this.SS_MONEY.TabIndex = 19;
            this.SS_MONEY.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // SHANG_S
            // 
            this.SHANG_S.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SHANG_S.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.SHANG_S.EditScale = 0;
            this.SHANG_S.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.SHANG_S.Location = new System.Drawing.Point(2, 4);
            this.SHANG_S.Name = "SHANG_S";
            this.SHANG_S.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.SHANG_S.Properties.Appearance.Options.UseForeColor = true;
            this.SHANG_S.Properties.Appearance.Options.UseTextOptions = true;
            this.SHANG_S.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.SHANG_S.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.White;
            this.SHANG_S.Properties.AppearanceReadOnly.Options.UseBackColor = true;
            this.SHANG_S.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.SHANG_S.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.SHANG_S.Properties.MaxValue = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.SHANG_S.Size = new System.Drawing.Size(86, 18);
            this.SHANG_S.TabIndex = 18;
            this.SHANG_S.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // SHANG_Z
            // 
            this.SHANG_Z.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SHANG_Z.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.SHANG_Z.EditScale = 0;
            this.SHANG_Z.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.SHANG_Z.Location = new System.Drawing.Point(2, 4);
            this.SHANG_Z.Name = "SHANG_Z";
            this.SHANG_Z.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.SHANG_Z.Properties.Appearance.Options.UseForeColor = true;
            this.SHANG_Z.Properties.Appearance.Options.UseTextOptions = true;
            this.SHANG_Z.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.SHANG_Z.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.White;
            this.SHANG_Z.Properties.AppearanceReadOnly.Options.UseBackColor = true;
            this.SHANG_Z.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.SHANG_Z.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.SHANG_Z.Properties.MaxValue = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.SHANG_Z.Size = new System.Drawing.Size(82, 18);
            this.SHANG_Z.TabIndex = 17;
            this.SHANG_Z.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // SHANG_Q
            // 
            this.SHANG_Q.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SHANG_Q.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.SHANG_Q.EditScale = 0;
            this.SHANG_Q.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.SHANG_Q.Location = new System.Drawing.Point(2, 4);
            this.SHANG_Q.Name = "SHANG_Q";
            this.SHANG_Q.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.SHANG_Q.Properties.Appearance.Options.UseForeColor = true;
            this.SHANG_Q.Properties.Appearance.Options.UseTextOptions = true;
            this.SHANG_Q.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.SHANG_Q.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.White;
            this.SHANG_Q.Properties.AppearanceReadOnly.Options.UseBackColor = true;
            this.SHANG_Q.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.SHANG_Q.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.SHANG_Q.Properties.MaxValue = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.SHANG_Q.Size = new System.Drawing.Size(83, 18);
            this.SHANG_Q.TabIndex = 16;
            this.SHANG_Q.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // SS_YL
            // 
            this.SS_YL.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SS_YL.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.SS_YL.EditScale = 0;
            this.SS_YL.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.SS_YL.Location = new System.Drawing.Point(1, 4);
            this.SS_YL.Name = "SS_YL";
            this.SS_YL.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.SS_YL.Properties.Appearance.Options.UseForeColor = true;
            this.SS_YL.Properties.Appearance.Options.UseTextOptions = true;
            this.SS_YL.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.SS_YL.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.White;
            this.SS_YL.Properties.AppearanceReadOnly.Options.UseBackColor = true;
            this.SS_YL.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.SS_YL.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.SS_YL.Properties.MaxValue = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.SS_YL.Size = new System.Drawing.Size(72, 18);
            this.SS_YL.TabIndex = 13;
            this.SS_YL.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // SS_CL
            // 
            this.SS_CL.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SS_CL.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.SS_CL.EditScale = 0;
            this.SS_CL.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.SS_CL.Location = new System.Drawing.Point(1, 4);
            this.SS_CL.Name = "SS_CL";
            this.SS_CL.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.SS_CL.Properties.Appearance.Options.UseForeColor = true;
            this.SS_CL.Properties.Appearance.Options.UseTextOptions = true;
            this.SS_CL.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.SS_CL.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.White;
            this.SS_CL.Properties.AppearanceReadOnly.Options.UseBackColor = true;
            this.SS_CL.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.SS_CL.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.SS_CL.Properties.MaxValue = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.SS_CL.Size = new System.Drawing.Size(72, 18);
            this.SS_CL.TabIndex = 12;
            this.SS_CL.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // RGL_MJ
            // 
            this.RGL_MJ.Cursor = System.Windows.Forms.Cursors.Hand;
            this.RGL_MJ.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.RGL_MJ.EditScale = 0;
            this.RGL_MJ.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.RGL_MJ.Location = new System.Drawing.Point(1, 4);
            this.RGL_MJ.Name = "RGL_MJ";
            this.RGL_MJ.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.RGL_MJ.Properties.Appearance.Options.UseForeColor = true;
            this.RGL_MJ.Properties.Appearance.Options.UseTextOptions = true;
            this.RGL_MJ.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.RGL_MJ.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.White;
            this.RGL_MJ.Properties.AppearanceReadOnly.Options.UseBackColor = true;
            this.RGL_MJ.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.RGL_MJ.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.RGL_MJ.Properties.MaxValue = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.RGL_MJ.Size = new System.Drawing.Size(73, 18);
            this.RGL_MJ.TabIndex = 11;
            this.RGL_MJ.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // YSL_MJ
            // 
            this.YSL_MJ.Cursor = System.Windows.Forms.Cursors.Hand;
            this.YSL_MJ.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.YSL_MJ.EditScale = 0;
            this.YSL_MJ.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.YSL_MJ.Location = new System.Drawing.Point(1, 4);
            this.YSL_MJ.Name = "YSL_MJ";
            this.YSL_MJ.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.YSL_MJ.Properties.Appearance.Options.UseForeColor = true;
            this.YSL_MJ.Properties.Appearance.Options.UseTextOptions = true;
            this.YSL_MJ.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.YSL_MJ.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.White;
            this.YSL_MJ.Properties.AppearanceReadOnly.Options.UseBackColor = true;
            this.YSL_MJ.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.YSL_MJ.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.YSL_MJ.Properties.MaxValue = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.YSL_MJ.Size = new System.Drawing.Size(73, 18);
            this.YSL_MJ.TabIndex = 10;
            this.YSL_MJ.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // TOTAL_MJ
            // 
            this.TOTAL_MJ.Cursor = System.Windows.Forms.Cursors.Hand;
            this.TOTAL_MJ.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.TOTAL_MJ.EditScale = 0;
            this.TOTAL_MJ.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.TOTAL_MJ.Location = new System.Drawing.Point(2, 4);
            this.TOTAL_MJ.Name = "TOTAL_MJ";
            this.TOTAL_MJ.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.TOTAL_MJ.Properties.Appearance.Options.UseForeColor = true;
            this.TOTAL_MJ.Properties.Appearance.Options.UseTextOptions = true;
            this.TOTAL_MJ.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.TOTAL_MJ.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.White;
            this.TOTAL_MJ.Properties.AppearanceReadOnly.Options.UseBackColor = true;
            this.TOTAL_MJ.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.TOTAL_MJ.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.TOTAL_MJ.Properties.MaxValue = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.TOTAL_MJ.Size = new System.Drawing.Size(64, 18);
            this.TOTAL_MJ.TabIndex = 9;
            this.TOTAL_MJ.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // HZDJ
            // 
            this.HZDJ.AssDispValue = true;
            this.HZDJ.BackColor = System.Drawing.Color.White;
            this.HZDJ.Cursor = System.Windows.Forms.Cursors.Hand;
            this.HZDJ.Dock = System.Windows.Forms.DockStyle.Fill;
            this.HZDJ.ForeColor = System.Drawing.Color.Blue;
            this.HZDJ.Location = new System.Drawing.Point(2, 2);
            this.HZDJ.Name = "HZDJ";
            this.HZDJ.Size = new System.Drawing.Size(72, 22);
            this.HZDJ.TabIndex = 8;
            this.HZDJ.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // HZYY
            // 
            this.HZYY.AssDispValue = true;
            this.HZYY.BackColor = System.Drawing.Color.White;
            this.HZYY.Cursor = System.Windows.Forms.Cursors.Hand;
            this.HZYY.Dock = System.Windows.Forms.DockStyle.Fill;
            this.HZYY.ForeColor = System.Drawing.Color.Blue;
            this.HZYY.Location = new System.Drawing.Point(2, 2);
            this.HZYY.Name = "HZYY";
            this.HZYY.Size = new System.Drawing.Size(89, 22);
            this.HZYY.TabIndex = 7;
            this.HZYY.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // CUN
            // 
            this.CUN.AssDispValue = true;
            this.CUN.BackColor = System.Drawing.Color.White;
            this.CUN.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CUN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CUN.ForeColor = System.Drawing.Color.Blue;
            this.CUN.Location = new System.Drawing.Point(2, 2);
            this.CUN.Name = "CUN";
            this.CUN.Size = new System.Drawing.Size(110, 22);
            this.CUN.TabIndex = 3;
            this.CUN.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // XIANG
            // 
            this.XIANG.AssDispValue = true;
            this.XIANG.BackColor = System.Drawing.Color.White;
            this.XIANG.Cursor = System.Windows.Forms.Cursors.Hand;
            this.XIANG.Dock = System.Windows.Forms.DockStyle.Fill;
            this.XIANG.ForeColor = System.Drawing.Color.Blue;
            this.XIANG.Location = new System.Drawing.Point(2, 2);
            this.XIANG.Name = "XIANG";
            this.XIANG.Size = new System.Drawing.Size(110, 22);
            this.XIANG.TabIndex = 2;
            this.XIANG.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // XIAN
            // 
            this.XIAN.AssDispValue = true;
            this.XIAN.BackColor = System.Drawing.Color.White;
            this.XIAN.Cursor = System.Windows.Forms.Cursors.Hand;
            this.XIAN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.XIAN.ForeColor = System.Drawing.Color.Blue;
            this.XIAN.Location = new System.Drawing.Point(2, 2);
            this.XIAN.Name = "XIAN";
            this.XIAN.Size = new System.Drawing.Size(111, 22);
            this.XIAN.TabIndex = 1;
            this.XIAN.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // UserControlFireInfo
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.BackColor2 = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.Controls.Add(this.panel1);
            this.Name = "UserControlFireInfo";
            this.Size = new System.Drawing.Size(485, 457);
            this.panel1.ResumeLayout(false);
            this.panelInfo.ResumeLayout(false);
            this.panelBasic.ResumeLayout(false);
            this.panelBasicInfo.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel31.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel33.ResumeLayout(false);
            this.panel34.ResumeLayout(false);
            this.panel27.ResumeLayout(false);
            this.panel28.ResumeLayout(false);
            this.panel29.ResumeLayout(false);
            this.panel24.ResumeLayout(false);
            this.panel35.ResumeLayout(false);
            this.panel25.ResumeLayout(false);
            this.panel26.ResumeLayout(false);
            this.panel21.ResumeLayout(false);
            this.panel36.ResumeLayout(false);
            this.panel23.ResumeLayout(false);
            this.panel14.ResumeLayout(false);
            this.panel22.ResumeLayout(false);
            this.panel18.ResumeLayout(false);
            this.panel15.ResumeLayout(false);
            this.panel11.ResumeLayout(false);
            this.panel17.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.NL.Properties)).EndInit();
            this.panel13.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.LINFEN.Properties)).EndInit();
            this.panel46.ResumeLayout(false);
            this.panel48.ResumeLayout(false);
            this.panel61.ResumeLayout(false);
            this.panel62.ResumeLayout(false);
            this.panel54.ResumeLayout(false);
            this.panel49.ResumeLayout(false);
            this.panel92.ResumeLayout(false);
            this.panel91.ResumeLayout(false);
            this.panel47.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.panel16.ResumeLayout(false);
            this.panel19.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PHSJ.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PHSJ.Properties)).EndInit();
            this.panel20.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.QHSJ.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.QHSJ.Properties)).EndInit();
            this.panel7.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DIMING.Properties)).EndInit();
            this.panel12.ResumeLayout(false);
            this.panel10.ResumeLayout(false);
            this.panel30.ResumeLayout(false);
            this.panel32.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CL_XSRS.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CL_RS.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PU_JF.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PU_FJ.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PU_QC.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PU_CL.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PU_RG.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SS_ZLMJ.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SS_MONEY.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SHANG_S.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SHANG_Z.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SHANG_Q.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SS_YL.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SS_CL.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RGL_MJ.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.YSL_MJ.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TOTAL_MJ.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        private void ShowAttributes()
        {
            if (this.m_Table != null)
            {
                IFields fields = this.m_Table.Fields;
                for (int i = 0; i < fields.FieldCount; i++)
                {
                    IField pField = fields.get_Field(i);
                    object pValue = null;
                    if (this.m_Object != null)
                    {
                        pValue = this.m_Object.get_Value(i);
                    }
                    this.ShowFieldValue(pField, pValue, pField.Name);
                }
            }
        }

        private void ShowCL(string sControlName, string sValue, bool bReadOnly)
        {
            IList pItems = new ArrayList();
            IList pValueList = new ArrayList();
            pItems.Add("<空>");
            pValueList.Add("");
            pItems.Add("是");
            pValueList.Add("是");
            pItems.Add("否");
            pValueList.Add("否");
            this.ShowComboBox(sControlName, sValue, pItems, pValueList, bReadOnly);
        }

        private void ShowComboBox(string sControlName, string sValue, IList pItems, IList pValueList, bool bReadOnly)
        {
            ZLComboBox control = this.GetControl(sControlName) as ZLComboBox;
            if (control != null)
            {
                int num = -1;
                control.ClearItems();
                if (pItems != null)
                {
                    if (pValueList == null)
                    {
                        pValueList = pItems;
                    }
                    for (int i = 0; i < pItems.Count; i++)
                    {
                        control.AddItem(pItems[i].ToString(), pValueList[i].ToString());
                        if (pValueList[i].ToString() == sValue)
                        {
                            num = i;
                        }
                    }
                }
                control.SelectedIndex = -1;
                control.Enabled = !bReadOnly;
                if (num == -1)
                {
                    control.SelectedIndex = 0;
                }
                else
                {
                    control.SelectedIndex = num;
                }
                if (sControlName == "XIAN")
                {
                    this.m_Cnty = sValue;
                }
                else if (sControlName == UtilFactory.GetConfigOpt().GetConfigValue2("Fire", "TownField"))
                {
                    control.ItemFilter(this.m_Cnty);
                    this.m_Town = sValue;
                }
                else if (sControlName == UtilFactory.GetConfigOpt().GetConfigValue2("Fire", "VillField"))
                {
                    control.ItemFilter(this.m_Town);
                    this.m_Vill = sValue;
                }
            }
        }

        private void ShowDateEdit(string sControlName, object pValue, bool bReadOnly)
        {
            DateEdit control = this.GetControl(sControlName) as DateEdit;
            if (control != null)
            {
                control.Enabled = !bReadOnly;
                if (pValue != null)
                {
                    string str = pValue.ToString();
                    if ((str == "") || (str.Length < 8))
                    {
                        control.Text = "";
                    }
                    else
                    {
                        control.DateTime = Convert.ToDateTime(pValue);
                    }
                }
                else
                {
                    control.Text = "";
                }
            }
        }

        private void ShowFieldValue(IField pField, object pValue, string sControlName)
        {
            try
            {
                string sValue = "";
                if (pValue != null)
                {
                    sValue = pValue.ToString();
                }
                bool bReadOnly = true;
                if (this.m_EnableEdit)
                {
                    bReadOnly = false;
                    this.buttonCalc.Enabled = true;
                }
                else
                {
                    bReadOnly = true;
                    this.buttonCalc.Enabled = false;
                }
                if (sControlName == "SF_CL")
                {
                    this.ShowCL(sControlName, sValue, bReadOnly);
                }
                else
                {
                    if (this.m_bAdd && (sControlName == "XIAN"))
                    {
                        sValue = EditTask.DistCode.Substring(0, 6);
                    }
                    IDomain domain = null;
                    ICodedValueDomain domain2 = null;
                    IList pItems = new ArrayList();
                    IList pValueList = new ArrayList();
                    domain = pField.Domain;
                    if (domain != null)
                    {
                        if (domain is ICodedValueDomain)
                        {
                            domain2 = domain as ICodedValueDomain;
                            if (pField.IsNullable)
                            {
                                pItems.Add("<空>");
                                pValueList.Add("");
                            }
                            for (int i = 0; i < domain2.CodeCount; i++)
                            {
                                pItems.Add(domain2.get_Name(i));
                                pValueList.Add(domain2.get_Value(i));
                            }
                            this.ShowComboBox(sControlName, sValue, pItems, pValueList, bReadOnly);
                        }
                    }
                    else if ((pField.Type == esriFieldType.esriFieldTypeSingle) || (pField.Type == esriFieldType.esriFieldTypeDouble))
                    {
                        if (!bReadOnly)
                        {
                            this.ShowSpinEdit(sControlName, pValue, bReadOnly, 0.0, 0.0, true, pField.Scale);
                        }
                        else
                        {
                            this.ShowTextEdit(sControlName, pValue, bReadOnly, -1);
                        }
                    }
                    else if ((pField.Type == esriFieldType.esriFieldTypeSmallInteger) || (pField.Type == esriFieldType.esriFieldTypeInteger))
                    {
                        if (!bReadOnly)
                        {
                            this.ShowSpinEdit(sControlName, pValue, bReadOnly, 0.0, 0.0, false, 0);
                        }
                        else
                        {
                            this.ShowTextEdit(sControlName, pValue, bReadOnly, -1);
                        }
                    }
                    else if (pField.Type == esriFieldType.esriFieldTypeDate)
                    {
                        this.ShowDateEdit(sControlName, pValue, bReadOnly);
                    }
                    else
                    {
                        this.ShowTextEdit(sControlName, sValue, bReadOnly, pField.Length);
                    }
                }
            }
            catch
            {
            }
        }

        private void ShowSpinEdit(string sControlName, object pValue, bool bReadOnly, double dMinValue, double dMaxValue, bool bFloat, int iScale)
        {
            ZLSpinEdit control = this.GetControl(sControlName) as ZLSpinEdit;
            if (control == null)
            {
                this.ShowTextEdit(sControlName, pValue, bReadOnly, -1);
            }
            else
            {
                control.Properties.AllowNullInput = DefaultBoolean.True;
                control.Properties.NullText = "";
                control.Enabled = !bReadOnly;
                control.Properties.IsFloatValue = bFloat;
                control.EditScale = iScale;
                if ((dMinValue != 0.0) || (dMaxValue != 0.0))
                {
                    control.Properties.MaxValue = (decimal) dMaxValue;
                    control.Properties.MinValue = (decimal) dMinValue;
                }
                if ((pValue == null) || (pValue == DBNull.Value))
                {
                    control.EditValue = null;
                }
                else
                {
                    string str = pValue.ToString();
                    decimal num = 0M;
                    if (str != "")
                    {
                        num = Convert.ToDecimal(str);
                    }
                    control.Value = num;
                }
            }
        }

        private void ShowTextEdit(string sControlName, object pValue, bool bReadOnly, int iLength)
        {
            TextEdit control = this.GetControl(sControlName) as TextEdit;
            if (control != null)
            {
                control.Enabled = !bReadOnly;
                if (iLength > 0)
                {
                    control.Properties.MaxLength = iLength;
                }
                control.Text = pValue.ToString();
            }
        }

        public string SubmitValues()
        {
            try
            {
                string sName = UtilFactory.GetConfigOpt().GetConfigValue2("Fire", "TimeField");
                string str3 = UtilFactory.GetConfigOpt().GetConfigValue2("Fire", "CntyField");
                Control pControl = this.GetControl(str3);
                string str4 = this.GetControlValue(pControl).ToString();
                if (str4 == "")
                {
                    return "区县未选择！";
                }
                pControl = this.GetControl(sName);
                object controlValue = this.GetControlValue(pControl);
                if ((controlValue == null) || (controlValue.ToString().Substring(0, 1) == "0"))
                {
                    return "起火时间未填写！";
                }
                DateTime temDt = DateTime.Parse(controlValue.ToString());
                string pFieldValue = str4 + temDt.ToString("yyyyMMddHHmmss");
                Editor.UniqueInstance.StartEditOperation();
                try
                {
                    if (this.m_Object == null)
                    {
                        IRow row = this.m_Table.CreateRow();
                        this.m_Object = row as IObject;
                    }
                    IObject pObject = this.m_Object;
                    IFields fields = this.m_Table.Fields;
                    for (int i = 0; i < fields.FieldCount; i++)
                    {
                        IField field = fields.get_Field(i);
                        if (field.Editable)
                        {
                            Control control = this.GetControl(field.Name);
                            if (control != null)
                            {
                                object obj4 = this.GetControlValue(control);
                                if (obj4 != null)
                                {
                                    if (obj4.ToString() == "<空>")
                                    {
                                        pObject.set_Value(i, "");
                                    }
                                    else
                                    {
                                        pObject.set_Value(i, obj4);
                                    }
                                }
                            }
                        }
                    }
                    string sFieldName = UtilFactory.GetConfigOpt().GetConfigValue2("Fire", "IDField");
                    DataFuncs.UpdateField(pObject, sFieldName, pFieldValue);
                    pObject.Store();
                }
                catch
                {
                    Editor.UniqueInstance.AbortEditOperation();
                }
                Editor.UniqueInstance.StopEditOperation();
                return "";
            }
            catch (Exception exception)
            {
                return exception.Message;
            }
        }

        private void XIAN_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.XIAN.SelectedIndex <= 0)
            {
                this.XIANG.ClearItems();
                this.XIANG.AddItem("<空>", "");
                this.XIANG.SelectedIndex = 0;
                this.CUN.ClearItems();
                this.CUN.AddItem("<空>", "");
                this.CUN.SelectedIndex = 0;
            }
            else
            {
                this.XIANG.ItemFilter(this.XIAN.GetSelectedValue());
            }
        }

        private void XIANG_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.XIANG.SelectedIndex <= 0)
            {
                this.CUN.ClearItems();
                this.CUN.AddItem("<空>", "");
                this.CUN.SelectedIndex = 0;
            }
            else
            {
                this.CUN.ItemFilter(this.XIANG.GetSelectedValue());
            }
        }
    }
}

