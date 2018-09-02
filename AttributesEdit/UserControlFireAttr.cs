namespace AttributesEdit
{
    using DevExpress.Utils;
    using DevExpress.XtraEditors;
    using DevExpress.XtraEditors.Controls;
    using DevExpress.XtraEditors.Mask;
    using ESRI.ArcGIS.Geodatabase;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Reflection;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;
    using TaskManage;
    using Utilities;

    public class UserControlFireAttr : UserControl
    {
        private ZLComboBox BHYY;
        private ZLSpinEdit BLXJ;
        private IContainer components;
        private ZLComboBox CUN;
        private ZLComboBox DI_LEI;
        private ZLComboBox DISASTER_C;
        private ZLComboBox DISPE;
        private ZLComboBox FIRE_NO;
        private DateEdit GXSJ;
        private ZLComboBox HZDJ;
        private ZLComboBox HZYY;
        private Label label11;
        private Label label110;
        private Label label111;
        private Label label112;
        private Label label113;
        private Label label115;
        private Label label12;
        private Label label14;
        private Label label15;
        private Label label162;
        private Label label171;
        private Label label172;
        private Label label173;
        private Label label18;
        private Label label183;
        private Label label19;
        private Label label2;
        private Label label20;
        private Label label22;
        private Label label24;
        private Label label26;
        private Label label28;
        private Label label30;
        private Label label31;
        private Label label32;
        private Label label33;
        private Label label34;
        private Label label35;
        private Label label36;
        private Label label37;
        private Label label42;
        private Label label43;
        private Label label47;
        private Label label49;
        private Label label50;
        private Label label51;
        private Label label54;
        private Label label58;
        private Label label6;
        private Label label61;
        private Label label62;
        private Label label65;
        private Label label66;
        private Label label67;
        private Label label68;
        private Label label69;
        private Label label7;
        private Label label70;
        private Label label88;
        private Label label90;
        private Label label91;
        private Label label92;
        private Label label93;
        private Label labelLBMess;
        private Label labelTitle;
        private Label laBHYY;
        private Label laBLXJ;
        private Label laCUN;
        private Label laDI_LEI;
        private Label laDISASTER_C;
        private Label laDISPE;
        private Label laFIRE_NO;
        private Label laGXSJ;
        private Label laHZDJ;
        private Label laHZYY;
        private Label laLD_QS;
        private Label laLIN_BAN;
        private Label laLIN_ZHONG;
        private Label laLING_ZU;
        private Label laLMJYQ;
        private Label laLMSYQ;
        private Label laMIAN_JI;
        private Label laPINGJUN_NL;
        private Label laQ_DI_LEI;
        private Label laQ_LD_QS;
        private Label laQ_LIN_ZHONG;
        private Label laQ_SEN_LB;
        private Label laQHSJ;
        private Label laQI_YUAN;
        private Label laSEN_LIN_LB;
        private Label laSHENG;
        private Label laSHI;
        private Label laSS_ZS;
        private Label laSUNSHIXJ;
        private Label laTDJYQ;
        private Label laXI_BAN;
        private Label laXIAN;
        private Label laXIANG;
        private Label laXIAO_BAN;
        private Label laYOU_SHI_SZ;
        private Label laYU_BI_DU;
        private Label laZHMJ;
        private ZLComboBox LD_QS;
        private TextEdit LIN_BAN;
        private ZLComboBox LIN_ZHONG;
        private ZLComboBox LING_ZU;
        private ZLComboBox LMJYQ;
        private ZLComboBox LMSYQ;
        private bool m_bShow;
        private ZLSpinEdit MIAN_JI;
        private Panel panel1;
        private Panel panel10;
        private Panel panel100;
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
        private Panel panel40;
        private Panel panel41;
        private Panel panel42;
        private Panel panel43;
        private Panel panel44;
        private Panel panel45;
        private Panel panel46;
        private Panel panel47;
        private Panel panel48;
        private Panel panel49;
        private Panel panel5;
        private Panel panel50;
        private Panel panel51;
        private Panel panel52;
        private Panel panel53;
        private Panel panel54;
        private Panel panel55;
        private Panel panel57;
        private Panel panel6;
        private Panel panel67;
        private Panel panel8;
        private Panel panel86;
        private Panel panel89;
        private Panel panel9;
        private Panel panel91;
        private Panel panel92;
        private Panel panelBasicInfo;
        private Panel panelControl1;
        private Panel panelFire;
        private Panel panelFireNO;
        private Panel panelOther;
        private Panel panelWoodsInfo;
        private ZLSpinEdit PINGJUN_NL;
        private ZLComboBox Q_DI_LEI;
        private ZLComboBox Q_LD_QS;
        private ZLComboBox Q_LIN_ZHONG;
        private ZLComboBox Q_SEN_LB;
        private DateEdit QHSJ;
        private ZLComboBox QI_YUAN;
        private ZLComboBox SEN_LIN_LB;
        private ZLComboBox SHENG;
        private ZLComboBox SHI;
        private ZLSpinEdit SS_ZS;
        private ZLSpinEdit SUNSHIXJ;
        private ZLComboBox TDJYQ;
        private TextEdit XI_BAN;
        private ZLComboBox XIAN;
        private ZLComboBox XIANG;
        private TextEdit XIAO_BAN;
        private ZLComboBox YOU_SHI_SZ;
        private ZLSpinEdit YU_BI_DU;
        private ZLSpinEdit ZHMJ;

        public UserControlFireAttr()
        {
            this.InitializeComponent();
            this.Q_SEN_LB.SelectedIndexChanged += new EventHandler(this.Q_SEN_LIN_LB_SelectedIndexChanged);
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

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void FIRE_NO_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.m_bShow)
            {
                if (this.FIRE_NO.SelectedIndex < 1)
                {
                    this.HZYY.SelectedIndex = 0;
                    this.HZDJ.SelectedIndex = 0;
                    this.QHSJ.Text = "";
                }
                else
                {
                    string selectedValue = this.FIRE_NO.GetSelectedValue();
                    try
                    {
                        string name = UtilFactory.GetConfigOpt().GetConfigValue2("Fire", "FireTable");
                        IFeatureWorkspace editWorkspace = EditTask.EditWorkspace;
                        if (editWorkspace != null)
                        {
                            ITable table = null;
                            try
                            {
                                table = editWorkspace.OpenTable(name);
                            }
                            catch
                            {
                                return;
                            }
                            if (table != null)
                            {
                                string str4 = UtilFactory.GetConfigOpt().GetConfigValue2("Fire", "IDField") + "='" + selectedValue + "'";
                                IQueryFilter queryFilter = new QueryFilterClass {
                                    WhereClause = str4
                                };
                                ICursor o = table.Search(queryFilter, false);
                                if (o != null)
                                {
                                    IRow row = o.NextRow();
                                    if (row != null)
                                    {
                                        string sFieldName = "HZYY";
                                        string sValue = DataFuncs.GetFieldValue((IObject) row, sFieldName).ToString();
                                        this.HZYY.SetSelectedItem(sValue);
                                        sFieldName = "HZDJ";
                                        sValue = DataFuncs.GetFieldValue((IObject) row, sFieldName).ToString();
                                        this.HZDJ.SetSelectedItem(sValue);
                                        sFieldName = "QHSJ";
                                        sValue = DataFuncs.GetFieldValue((IObject) row, sFieldName).ToString();
                                        if (sValue != "")
                                        {
                                            DateTime time = Convert.ToDateTime(sValue);
                                            this.QHSJ.DateTime = time;
                                        }
                                        else
                                        {
                                            this.QHSJ.Text = "";
                                        }
                                    }
                                    Marshal.ReleaseComObject(o);
                                }
                            }
                        }
                    }
                    catch
                    {
                    }
                }
            }
        }

        private void FocusControl(int index)
        {
            if (index == 0x26)
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

        public Control GetControl(string sName)
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

        private void InitializeComponent()
        {
            this.labelTitle = new System.Windows.Forms.Label();
            this.panelBasicInfo = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel16 = new System.Windows.Forms.Panel();
            this.panel19 = new System.Windows.Forms.Panel();
            this.XI_BAN = new DevExpress.XtraEditors.TextEdit();
            this.laXI_BAN = new System.Windows.Forms.Label();
            this.panel20 = new System.Windows.Forms.Panel();
            this.XIAO_BAN = new DevExpress.XtraEditors.TextEdit();
            this.laXIAO_BAN = new System.Windows.Forms.Label();
            this.label42 = new System.Windows.Forms.Label();
            this.panel12 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.LIN_BAN = new DevExpress.XtraEditors.TextEdit();
            this.laLIN_BAN = new System.Windows.Forms.Label();
            this.panel10 = new System.Windows.Forms.Panel();
            this.CUN = new AttributesEdit.ZLComboBox();
            this.laCUN = new System.Windows.Forms.Label();
            this.panel30 = new System.Windows.Forms.Panel();
            this.XIANG = new AttributesEdit.ZLComboBox();
            this.laXIANG = new System.Windows.Forms.Label();
            this.label54 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel32 = new System.Windows.Forms.Panel();
            this.XIAN = new AttributesEdit.ZLComboBox();
            this.laXIAN = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.SHI = new AttributesEdit.ZLComboBox();
            this.laSHI = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.SHENG = new AttributesEdit.ZLComboBox();
            this.laSHENG = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.label37 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.panelWoodsInfo = new System.Windows.Forms.Panel();
            this.panel22 = new System.Windows.Forms.Panel();
            this.panel42 = new System.Windows.Forms.Panel();
            this.panel45 = new System.Windows.Forms.Panel();
            this.TDJYQ = new AttributesEdit.ZLComboBox();
            this.laTDJYQ = new System.Windows.Forms.Label();
            this.label58 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel11 = new System.Windows.Forms.Panel();
            this.LMJYQ = new AttributesEdit.ZLComboBox();
            this.laLMJYQ = new System.Windows.Forms.Label();
            this.panel27 = new System.Windows.Forms.Panel();
            this.LMSYQ = new AttributesEdit.ZLComboBox();
            this.laLMSYQ = new System.Windows.Forms.Label();
            this.label50 = new System.Windows.Forms.Label();
            this.panel15 = new System.Windows.Forms.Panel();
            this.panel29 = new System.Windows.Forms.Panel();
            this.YU_BI_DU = new AttributesEdit.ZLSpinEdit();
            this.label11 = new System.Windows.Forms.Label();
            this.laYU_BI_DU = new System.Windows.Forms.Label();
            this.panel26 = new System.Windows.Forms.Panel();
            this.QI_YUAN = new AttributesEdit.ZLComboBox();
            this.laQI_YUAN = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.panel37 = new System.Windows.Forms.Panel();
            this.panel18 = new System.Windows.Forms.Panel();
            this.LING_ZU = new AttributesEdit.ZLComboBox();
            this.laLING_ZU = new System.Windows.Forms.Label();
            this.panel67 = new System.Windows.Forms.Panel();
            this.PINGJUN_NL = new AttributesEdit.ZLSpinEdit();
            this.label12 = new System.Windows.Forms.Label();
            this.laPINGJUN_NL = new System.Windows.Forms.Label();
            this.label183 = new System.Windows.Forms.Label();
            this.panel31 = new System.Windows.Forms.Panel();
            this.panel33 = new System.Windows.Forms.Panel();
            this.LIN_ZHONG = new AttributesEdit.ZLComboBox();
            this.laLIN_ZHONG = new System.Windows.Forms.Label();
            this.panel34 = new System.Windows.Forms.Panel();
            this.Q_LIN_ZHONG = new AttributesEdit.ZLComboBox();
            this.laQ_LIN_ZHONG = new System.Windows.Forms.Label();
            this.label49 = new System.Windows.Forms.Label();
            this.panel41 = new System.Windows.Forms.Panel();
            this.panel35 = new System.Windows.Forms.Panel();
            this.DI_LEI = new AttributesEdit.ZLComboBox();
            this.laDI_LEI = new System.Windows.Forms.Label();
            this.panel43 = new System.Windows.Forms.Panel();
            this.Q_DI_LEI = new AttributesEdit.ZLComboBox();
            this.laQ_DI_LEI = new System.Windows.Forms.Label();
            this.label65 = new System.Windows.Forms.Label();
            this.panel21 = new System.Windows.Forms.Panel();
            this.panel24 = new System.Windows.Forms.Panel();
            this.LD_QS = new AttributesEdit.ZLComboBox();
            this.laLD_QS = new System.Windows.Forms.Label();
            this.panel25 = new System.Windows.Forms.Panel();
            this.Q_LD_QS = new AttributesEdit.ZLComboBox();
            this.laQ_LD_QS = new System.Windows.Forms.Label();
            this.label47 = new System.Windows.Forms.Label();
            this.panel100 = new System.Windows.Forms.Panel();
            this.labelLBMess = new System.Windows.Forms.Label();
            this.panel9 = new System.Windows.Forms.Panel();
            this.SEN_LIN_LB = new AttributesEdit.ZLComboBox();
            this.laSEN_LIN_LB = new System.Windows.Forms.Label();
            this.panel23 = new System.Windows.Forms.Panel();
            this.Q_SEN_LB = new AttributesEdit.ZLComboBox();
            this.laQ_SEN_LB = new System.Windows.Forms.Label();
            this.label162 = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            this.panel14 = new System.Windows.Forms.Panel();
            this.YOU_SHI_SZ = new AttributesEdit.ZLComboBox();
            this.laYOU_SHI_SZ = new System.Windows.Forms.Label();
            this.panel17 = new System.Windows.Forms.Panel();
            this.MIAN_JI = new AttributesEdit.ZLSpinEdit();
            this.label51 = new System.Windows.Forms.Label();
            this.laMIAN_JI = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label67 = new System.Windows.Forms.Label();
            this.label68 = new System.Windows.Forms.Label();
            this.label69 = new System.Windows.Forms.Label();
            this.label70 = new System.Windows.Forms.Label();
            this.panelFire = new System.Windows.Forms.Panel();
            this.panel36 = new System.Windows.Forms.Panel();
            this.panel40 = new System.Windows.Forms.Panel();
            this.panel47 = new System.Windows.Forms.Panel();
            this.BLXJ = new AttributesEdit.ZLSpinEdit();
            this.label34 = new System.Windows.Forms.Label();
            this.laBLXJ = new System.Windows.Forms.Label();
            this.panel48 = new System.Windows.Forms.Panel();
            this.SUNSHIXJ = new AttributesEdit.ZLSpinEdit();
            this.label31 = new System.Windows.Forms.Label();
            this.laSUNSHIXJ = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.panel13 = new System.Windows.Forms.Panel();
            this.panel38 = new System.Windows.Forms.Panel();
            this.SS_ZS = new AttributesEdit.ZLSpinEdit();
            this.label33 = new System.Windows.Forms.Label();
            this.laSS_ZS = new System.Windows.Forms.Label();
            this.panel39 = new System.Windows.Forms.Panel();
            this.ZHMJ = new AttributesEdit.ZLSpinEdit();
            this.label28 = new System.Windows.Forms.Label();
            this.laZHMJ = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.panel50 = new System.Windows.Forms.Panel();
            this.panel52 = new System.Windows.Forms.Panel();
            this.DISASTER_C = new AttributesEdit.ZLComboBox();
            this.laDISASTER_C = new System.Windows.Forms.Label();
            this.panel53 = new System.Windows.Forms.Panel();
            this.DISPE = new AttributesEdit.ZLComboBox();
            this.laDISPE = new System.Windows.Forms.Label();
            this.label88 = new System.Windows.Forms.Label();
            this.label90 = new System.Windows.Forms.Label();
            this.label91 = new System.Windows.Forms.Label();
            this.label92 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label93 = new System.Windows.Forms.Label();
            this.label113 = new System.Windows.Forms.Label();
            this.panel89 = new System.Windows.Forms.Panel();
            this.label171 = new System.Windows.Forms.Label();
            this.label172 = new System.Windows.Forms.Label();
            this.label173 = new System.Windows.Forms.Label();
            this.label43 = new System.Windows.Forms.Label();
            this.panelOther = new System.Windows.Forms.Panel();
            this.panel28 = new System.Windows.Forms.Panel();
            this.panel86 = new System.Windows.Forms.Panel();
            this.panel91 = new System.Windows.Forms.Panel();
            this.GXSJ = new DevExpress.XtraEditors.DateEdit();
            this.laGXSJ = new System.Windows.Forms.Label();
            this.panel92 = new System.Windows.Forms.Panel();
            this.BHYY = new AttributesEdit.ZLComboBox();
            this.laBHYY = new System.Windows.Forms.Label();
            this.label110 = new System.Windows.Forms.Label();
            this.label111 = new System.Windows.Forms.Label();
            this.label112 = new System.Windows.Forms.Label();
            this.label115 = new System.Windows.Forms.Label();
            this.panelControl1 = new System.Windows.Forms.Panel();
            this.panel44 = new System.Windows.Forms.Panel();
            this.panel55 = new System.Windows.Forms.Panel();
            this.panel57 = new System.Windows.Forms.Panel();
            this.QHSJ = new DevExpress.XtraEditors.DateEdit();
            this.laQHSJ = new System.Windows.Forms.Label();
            this.label66 = new System.Windows.Forms.Label();
            this.panel46 = new System.Windows.Forms.Panel();
            this.panel51 = new System.Windows.Forms.Panel();
            this.HZDJ = new AttributesEdit.ZLComboBox();
            this.laHZDJ = new System.Windows.Forms.Label();
            this.panel54 = new System.Windows.Forms.Panel();
            this.HZYY = new AttributesEdit.ZLComboBox();
            this.laHZYY = new System.Windows.Forms.Label();
            this.label61 = new System.Windows.Forms.Label();
            this.panelFireNO = new System.Windows.Forms.Panel();
            this.panel49 = new System.Windows.Forms.Panel();
            this.FIRE_NO = new AttributesEdit.ZLComboBox();
            this.laFIRE_NO = new System.Windows.Forms.Label();
            this.label62 = new System.Windows.Forms.Label();
            this.panelBasicInfo.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel16.SuspendLayout();
            this.panel19.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.XI_BAN.Properties)).BeginInit();
            this.panel20.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.XIAO_BAN.Properties)).BeginInit();
            this.panel12.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LIN_BAN.Properties)).BeginInit();
            this.panel10.SuspendLayout();
            this.panel30.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel32.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panelWoodsInfo.SuspendLayout();
            this.panel22.SuspendLayout();
            this.panel42.SuspendLayout();
            this.panel45.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel11.SuspendLayout();
            this.panel27.SuspendLayout();
            this.panel15.SuspendLayout();
            this.panel29.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.YU_BI_DU.Properties)).BeginInit();
            this.panel26.SuspendLayout();
            this.panel37.SuspendLayout();
            this.panel18.SuspendLayout();
            this.panel67.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PINGJUN_NL.Properties)).BeginInit();
            this.panel31.SuspendLayout();
            this.panel33.SuspendLayout();
            this.panel34.SuspendLayout();
            this.panel41.SuspendLayout();
            this.panel35.SuspendLayout();
            this.panel43.SuspendLayout();
            this.panel21.SuspendLayout();
            this.panel24.SuspendLayout();
            this.panel25.SuspendLayout();
            this.panel100.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel23.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel14.SuspendLayout();
            this.panel17.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MIAN_JI.Properties)).BeginInit();
            this.panelFire.SuspendLayout();
            this.panel36.SuspendLayout();
            this.panel40.SuspendLayout();
            this.panel47.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BLXJ.Properties)).BeginInit();
            this.panel48.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SUNSHIXJ.Properties)).BeginInit();
            this.panel13.SuspendLayout();
            this.panel38.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SS_ZS.Properties)).BeginInit();
            this.panel39.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ZHMJ.Properties)).BeginInit();
            this.panel50.SuspendLayout();
            this.panel52.SuspendLayout();
            this.panel53.SuspendLayout();
            this.panelOther.SuspendLayout();
            this.panel28.SuspendLayout();
            this.panel86.SuspendLayout();
            this.panel91.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GXSJ.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GXSJ.Properties)).BeginInit();
            this.panel92.SuspendLayout();
            this.panelControl1.SuspendLayout();
            this.panel44.SuspendLayout();
            this.panel55.SuspendLayout();
            this.panel57.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.QHSJ.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.QHSJ.Properties)).BeginInit();
            this.panel46.SuspendLayout();
            this.panel51.SuspendLayout();
            this.panel54.SuspendLayout();
            this.panelFireNO.SuspendLayout();
            this.panel49.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelTitle
            // 
            this.labelTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelTitle.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelTitle.Location = new System.Drawing.Point(0, 0);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(436, 30);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "火灾调查";
            this.labelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelBasicInfo
            // 
            this.panelBasicInfo.Controls.Add(this.panel1);
            this.panelBasicInfo.Controls.Add(this.label35);
            this.panelBasicInfo.Controls.Add(this.label36);
            this.panelBasicInfo.Controls.Add(this.label37);
            this.panelBasicInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelBasicInfo.Location = new System.Drawing.Point(0, 132);
            this.panelBasicInfo.Name = "panelBasicInfo";
            this.panelBasicInfo.Size = new System.Drawing.Size(436, 76);
            this.panelBasicInfo.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel16);
            this.panel1.Controls.Add(this.panel12);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(1, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(434, 75);
            this.panel1.TabIndex = 0;
            // 
            // panel16
            // 
            this.panel16.Controls.Add(this.panel19);
            this.panel16.Controls.Add(this.laXI_BAN);
            this.panel16.Controls.Add(this.panel20);
            this.panel16.Controls.Add(this.laXIAO_BAN);
            this.panel16.Controls.Add(this.label42);
            this.panel16.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel16.Location = new System.Drawing.Point(0, 50);
            this.panel16.Name = "panel16";
            this.panel16.Size = new System.Drawing.Size(434, 25);
            this.panel16.TabIndex = 0;
            // 
            // panel19
            // 
            this.panel19.Controls.Add(this.XI_BAN);
            this.panel19.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel19.Location = new System.Drawing.Point(174, 0);
            this.panel19.Name = "panel19";
            this.panel19.Padding = new System.Windows.Forms.Padding(2, 6, 8, 0);
            this.panel19.Size = new System.Drawing.Size(106, 24);
            this.panel19.TabIndex = 0;
            // 
            // XI_BAN
            // 
            this.XI_BAN.Cursor = System.Windows.Forms.Cursors.Hand;
            this.XI_BAN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.XI_BAN.EditValue = "";
            this.XI_BAN.Location = new System.Drawing.Point(2, 6);
            this.XI_BAN.Name = "XI_BAN";
            this.XI_BAN.Properties.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.XI_BAN.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.XI_BAN.Properties.Appearance.Options.UseFont = true;
            this.XI_BAN.Properties.Appearance.Options.UseForeColor = true;
            this.XI_BAN.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.XI_BAN.Properties.MaxLength = 10;
            this.XI_BAN.Size = new System.Drawing.Size(96, 16);
            this.XI_BAN.TabIndex = 12;
            this.XI_BAN.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // laXI_BAN
            // 
            this.laXI_BAN.Dock = System.Windows.Forms.DockStyle.Left;
            this.laXI_BAN.Location = new System.Drawing.Point(140, 0);
            this.laXI_BAN.Name = "laXI_BAN";
            this.laXI_BAN.Size = new System.Drawing.Size(34, 24);
            this.laXI_BAN.TabIndex = 0;
            this.laXI_BAN.Text = "细班";
            this.laXI_BAN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel20
            // 
            this.panel20.Controls.Add(this.XIAO_BAN);
            this.panel20.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel20.Location = new System.Drawing.Point(34, 0);
            this.panel20.Name = "panel20";
            this.panel20.Padding = new System.Windows.Forms.Padding(2, 6, 8, 0);
            this.panel20.Size = new System.Drawing.Size(106, 24);
            this.panel20.TabIndex = 0;
            // 
            // XIAO_BAN
            // 
            this.XIAO_BAN.Cursor = System.Windows.Forms.Cursors.Hand;
            this.XIAO_BAN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.XIAO_BAN.EditValue = "";
            this.XIAO_BAN.Location = new System.Drawing.Point(2, 6);
            this.XIAO_BAN.Name = "XIAO_BAN";
            this.XIAO_BAN.Properties.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.XIAO_BAN.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.XIAO_BAN.Properties.Appearance.Options.UseFont = true;
            this.XIAO_BAN.Properties.Appearance.Options.UseForeColor = true;
            this.XIAO_BAN.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.XIAO_BAN.Properties.MaxLength = 4;
            this.XIAO_BAN.Size = new System.Drawing.Size(96, 16);
            this.XIAO_BAN.TabIndex = 11;
            this.XIAO_BAN.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // laXIAO_BAN
            // 
            this.laXIAO_BAN.Dock = System.Windows.Forms.DockStyle.Left;
            this.laXIAO_BAN.Location = new System.Drawing.Point(0, 0);
            this.laXIAO_BAN.Name = "laXIAO_BAN";
            this.laXIAO_BAN.Size = new System.Drawing.Size(34, 24);
            this.laXIAO_BAN.TabIndex = 0;
            this.laXIAO_BAN.Text = "图斑";
            this.laXIAO_BAN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label42
            // 
            this.label42.BackColor = System.Drawing.Color.Black;
            this.label42.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label42.Location = new System.Drawing.Point(0, 24);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(434, 1);
            this.label42.TabIndex = 0;
            this.label42.Text = "label42";
            this.label42.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel12
            // 
            this.panel12.Controls.Add(this.panel6);
            this.panel12.Controls.Add(this.laLIN_BAN);
            this.panel12.Controls.Add(this.panel10);
            this.panel12.Controls.Add(this.laCUN);
            this.panel12.Controls.Add(this.panel30);
            this.panel12.Controls.Add(this.laXIANG);
            this.panel12.Controls.Add(this.label54);
            this.panel12.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel12.Location = new System.Drawing.Point(0, 25);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(434, 25);
            this.panel12.TabIndex = 0;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.LIN_BAN);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel6.Location = new System.Drawing.Point(314, 0);
            this.panel6.Name = "panel6";
            this.panel6.Padding = new System.Windows.Forms.Padding(2, 6, 8, 0);
            this.panel6.Size = new System.Drawing.Size(106, 24);
            this.panel6.TabIndex = 0;
            // 
            // LIN_BAN
            // 
            this.LIN_BAN.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LIN_BAN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LIN_BAN.EditValue = "";
            this.LIN_BAN.Location = new System.Drawing.Point(2, 6);
            this.LIN_BAN.Name = "LIN_BAN";
            this.LIN_BAN.Properties.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LIN_BAN.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.LIN_BAN.Properties.Appearance.Options.UseFont = true;
            this.LIN_BAN.Properties.Appearance.Options.UseForeColor = true;
            this.LIN_BAN.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.LIN_BAN.Properties.MaxLength = 4;
            this.LIN_BAN.Size = new System.Drawing.Size(96, 16);
            this.LIN_BAN.TabIndex = 10;
            this.LIN_BAN.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // laLIN_BAN
            // 
            this.laLIN_BAN.Dock = System.Windows.Forms.DockStyle.Left;
            this.laLIN_BAN.Location = new System.Drawing.Point(280, 0);
            this.laLIN_BAN.Name = "laLIN_BAN";
            this.laLIN_BAN.Size = new System.Drawing.Size(34, 24);
            this.laLIN_BAN.TabIndex = 0;
            this.laLIN_BAN.Text = "林班";
            this.laLIN_BAN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel10
            // 
            this.panel10.Controls.Add(this.CUN);
            this.panel10.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel10.Location = new System.Drawing.Point(174, 0);
            this.panel10.Name = "panel10";
            this.panel10.Padding = new System.Windows.Forms.Padding(2, 4, 4, 0);
            this.panel10.Size = new System.Drawing.Size(106, 24);
            this.panel10.TabIndex = 0;
            // 
            // CUN
            // 
            this.CUN.AssDispValue = true;
            this.CUN.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CUN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CUN.ForeColor = System.Drawing.Color.Blue;
            this.CUN.Location = new System.Drawing.Point(2, 4);
            this.CUN.Name = "CUN";
            this.CUN.Size = new System.Drawing.Size(100, 20);
            this.CUN.TabIndex = 9;
            this.CUN.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // laCUN
            // 
            this.laCUN.Dock = System.Windows.Forms.DockStyle.Left;
            this.laCUN.Location = new System.Drawing.Point(140, 0);
            this.laCUN.Name = "laCUN";
            this.laCUN.Size = new System.Drawing.Size(34, 24);
            this.laCUN.TabIndex = 0;
            this.laCUN.Text = "村";
            this.laCUN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel30
            // 
            this.panel30.Controls.Add(this.XIANG);
            this.panel30.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel30.Location = new System.Drawing.Point(34, 0);
            this.panel30.Name = "panel30";
            this.panel30.Padding = new System.Windows.Forms.Padding(2, 4, 4, 0);
            this.panel30.Size = new System.Drawing.Size(106, 24);
            this.panel30.TabIndex = 0;
            // 
            // XIANG
            // 
            this.XIANG.AssDispValue = true;
            this.XIANG.Cursor = System.Windows.Forms.Cursors.Hand;
            this.XIANG.Dock = System.Windows.Forms.DockStyle.Fill;
            this.XIANG.ForeColor = System.Drawing.Color.Blue;
            this.XIANG.Location = new System.Drawing.Point(2, 4);
            this.XIANG.Name = "XIANG";
            this.XIANG.Size = new System.Drawing.Size(100, 20);
            this.XIANG.TabIndex = 8;
            this.XIANG.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // laXIANG
            // 
            this.laXIANG.Dock = System.Windows.Forms.DockStyle.Left;
            this.laXIANG.Location = new System.Drawing.Point(0, 0);
            this.laXIANG.Name = "laXIANG";
            this.laXIANG.Size = new System.Drawing.Size(34, 24);
            this.laXIANG.TabIndex = 0;
            this.laXIANG.Text = "乡镇";
            this.laXIANG.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label54
            // 
            this.label54.BackColor = System.Drawing.Color.Black;
            this.label54.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label54.Location = new System.Drawing.Point(0, 24);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(434, 1);
            this.label54.TabIndex = 0;
            this.label54.Text = "label54";
            this.label54.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel32);
            this.panel2.Controls.Add(this.laXIAN);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.laSHI);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.laSHENG);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(434, 25);
            this.panel2.TabIndex = 0;
            // 
            // panel32
            // 
            this.panel32.Controls.Add(this.XIAN);
            this.panel32.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel32.Location = new System.Drawing.Point(314, 0);
            this.panel32.Name = "panel32";
            this.panel32.Padding = new System.Windows.Forms.Padding(2, 4, 4, 0);
            this.panel32.Size = new System.Drawing.Size(106, 24);
            this.panel32.TabIndex = 0;
            // 
            // XIAN
            // 
            this.XIAN.AssDispValue = true;
            this.XIAN.Cursor = System.Windows.Forms.Cursors.Hand;
            this.XIAN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.XIAN.ForeColor = System.Drawing.Color.Blue;
            this.XIAN.Location = new System.Drawing.Point(2, 4);
            this.XIAN.Name = "XIAN";
            this.XIAN.Size = new System.Drawing.Size(100, 20);
            this.XIAN.TabIndex = 7;
            this.XIAN.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // laXIAN
            // 
            this.laXIAN.Dock = System.Windows.Forms.DockStyle.Left;
            this.laXIAN.Location = new System.Drawing.Point(280, 0);
            this.laXIAN.Name = "laXIAN";
            this.laXIAN.Size = new System.Drawing.Size(34, 24);
            this.laXIAN.TabIndex = 0;
            this.laXIAN.Text = "区县";
            this.laXIAN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.SHI);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel4.Location = new System.Drawing.Point(174, 0);
            this.panel4.Name = "panel4";
            this.panel4.Padding = new System.Windows.Forms.Padding(2, 4, 4, 0);
            this.panel4.Size = new System.Drawing.Size(106, 24);
            this.panel4.TabIndex = 0;
            // 
            // SHI
            // 
            this.SHI.AssDispValue = true;
            this.SHI.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SHI.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SHI.ForeColor = System.Drawing.Color.Blue;
            this.SHI.Location = new System.Drawing.Point(2, 4);
            this.SHI.Name = "SHI";
            this.SHI.Size = new System.Drawing.Size(100, 20);
            this.SHI.TabIndex = 6;
            this.SHI.SelectedIndexChanged += new System.EventHandler(this.SHI_SelectedIndexChanged);
            this.SHI.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // laSHI
            // 
            this.laSHI.Dock = System.Windows.Forms.DockStyle.Left;
            this.laSHI.Location = new System.Drawing.Point(140, 0);
            this.laSHI.Name = "laSHI";
            this.laSHI.Size = new System.Drawing.Size(34, 24);
            this.laSHI.TabIndex = 0;
            this.laSHI.Text = "市";
            this.laSHI.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.SHENG);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(34, 0);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(2, 4, 4, 0);
            this.panel3.Size = new System.Drawing.Size(106, 24);
            this.panel3.TabIndex = 0;
            // 
            // SHENG
            // 
            this.SHENG.AssDispValue = true;
            this.SHENG.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SHENG.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SHENG.ForeColor = System.Drawing.Color.Blue;
            this.SHENG.Location = new System.Drawing.Point(2, 4);
            this.SHENG.Name = "SHENG";
            this.SHENG.Size = new System.Drawing.Size(100, 20);
            this.SHENG.TabIndex = 5;
            this.SHENG.SelectedIndexChanged += new System.EventHandler(this.SHENG_SelectedIndexChanged);
            this.SHENG.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // laSHENG
            // 
            this.laSHENG.Dock = System.Windows.Forms.DockStyle.Left;
            this.laSHENG.Location = new System.Drawing.Point(0, 0);
            this.laSHENG.Name = "laSHENG";
            this.laSHENG.Size = new System.Drawing.Size(34, 24);
            this.laSHENG.TabIndex = 0;
            this.laSHENG.Text = "省";
            this.laSHENG.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Black;
            this.label2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label2.Location = new System.Drawing.Point(0, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(434, 1);
            this.label2.TabIndex = 0;
            this.label2.Text = "label2";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label35
            // 
            this.label35.BackColor = System.Drawing.Color.Black;
            this.label35.Dock = System.Windows.Forms.DockStyle.Top;
            this.label35.Location = new System.Drawing.Point(1, 0);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(434, 1);
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
            this.label36.Size = new System.Drawing.Size(1, 76);
            this.label36.TabIndex = 0;
            this.label36.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label37
            // 
            this.label37.BackColor = System.Drawing.Color.Black;
            this.label37.Dock = System.Windows.Forms.DockStyle.Right;
            this.label37.Location = new System.Drawing.Point(435, 0);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(1, 76);
            this.label37.TabIndex = 0;
            this.label37.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.Dock = System.Windows.Forms.DockStyle.Top;
            this.label7.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(0, 106);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(436, 26);
            this.label7.TabIndex = 0;
            this.label7.Text = "  基本情况调查";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelWoodsInfo
            // 
            this.panelWoodsInfo.Controls.Add(this.panel22);
            this.panelWoodsInfo.Controls.Add(this.label67);
            this.panelWoodsInfo.Controls.Add(this.label68);
            this.panelWoodsInfo.Controls.Add(this.label69);
            this.panelWoodsInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelWoodsInfo.Location = new System.Drawing.Point(0, 286);
            this.panelWoodsInfo.Name = "panelWoodsInfo";
            this.panelWoodsInfo.Size = new System.Drawing.Size(436, 226);
            this.panelWoodsInfo.TabIndex = 0;
            // 
            // panel22
            // 
            this.panel22.Controls.Add(this.panel42);
            this.panel22.Controls.Add(this.panel5);
            this.panel22.Controls.Add(this.panel15);
            this.panel22.Controls.Add(this.panel37);
            this.panel22.Controls.Add(this.panel31);
            this.panel22.Controls.Add(this.panel41);
            this.panel22.Controls.Add(this.panel21);
            this.panel22.Controls.Add(this.panel100);
            this.panel22.Controls.Add(this.panel8);
            this.panel22.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel22.Location = new System.Drawing.Point(1, 1);
            this.panel22.Name = "panel22";
            this.panel22.Size = new System.Drawing.Size(434, 225);
            this.panel22.TabIndex = 0;
            // 
            // panel42
            // 
            this.panel42.Controls.Add(this.panel45);
            this.panel42.Controls.Add(this.laTDJYQ);
            this.panel42.Controls.Add(this.label58);
            this.panel42.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel42.Location = new System.Drawing.Point(0, 200);
            this.panel42.Name = "panel42";
            this.panel42.Size = new System.Drawing.Size(434, 25);
            this.panel42.TabIndex = 0;
            // 
            // panel45
            // 
            this.panel45.Controls.Add(this.TDJYQ);
            this.panel45.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel45.Location = new System.Drawing.Point(78, 0);
            this.panel45.Name = "panel45";
            this.panel45.Padding = new System.Windows.Forms.Padding(2, 4, 4, 0);
            this.panel45.Size = new System.Drawing.Size(93, 24);
            this.panel45.TabIndex = 0;
            // 
            // TDJYQ
            // 
            this.TDJYQ.AssDispValue = true;
            this.TDJYQ.Cursor = System.Windows.Forms.Cursors.Hand;
            this.TDJYQ.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TDJYQ.ForeColor = System.Drawing.Color.Blue;
            this.TDJYQ.Location = new System.Drawing.Point(2, 4);
            this.TDJYQ.Name = "TDJYQ";
            this.TDJYQ.Size = new System.Drawing.Size(87, 20);
            this.TDJYQ.TabIndex = 29;
            this.TDJYQ.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // laTDJYQ
            // 
            this.laTDJYQ.Dock = System.Windows.Forms.DockStyle.Left;
            this.laTDJYQ.Location = new System.Drawing.Point(0, 0);
            this.laTDJYQ.Name = "laTDJYQ";
            this.laTDJYQ.Size = new System.Drawing.Size(78, 24);
            this.laTDJYQ.TabIndex = 0;
            this.laTDJYQ.Text = "土地使用权";
            this.laTDJYQ.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label58
            // 
            this.label58.BackColor = System.Drawing.Color.Black;
            this.label58.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label58.Location = new System.Drawing.Point(0, 24);
            this.label58.Name = "label58";
            this.label58.Size = new System.Drawing.Size(434, 1);
            this.label58.TabIndex = 0;
            this.label58.Text = "label58";
            this.label58.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.panel11);
            this.panel5.Controls.Add(this.laLMJYQ);
            this.panel5.Controls.Add(this.panel27);
            this.panel5.Controls.Add(this.laLMSYQ);
            this.panel5.Controls.Add(this.label50);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 175);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(434, 25);
            this.panel5.TabIndex = 0;
            // 
            // panel11
            // 
            this.panel11.Controls.Add(this.LMJYQ);
            this.panel11.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel11.Location = new System.Drawing.Point(237, 0);
            this.panel11.Name = "panel11";
            this.panel11.Padding = new System.Windows.Forms.Padding(2, 4, 4, 0);
            this.panel11.Size = new System.Drawing.Size(105, 24);
            this.panel11.TabIndex = 0;
            // 
            // LMJYQ
            // 
            this.LMJYQ.AssDispValue = true;
            this.LMJYQ.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LMJYQ.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LMJYQ.ForeColor = System.Drawing.Color.Blue;
            this.LMJYQ.Location = new System.Drawing.Point(2, 4);
            this.LMJYQ.Name = "LMJYQ";
            this.LMJYQ.Size = new System.Drawing.Size(99, 20);
            this.LMJYQ.TabIndex = 28;
            this.LMJYQ.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // laLMJYQ
            // 
            this.laLMJYQ.Dock = System.Windows.Forms.DockStyle.Left;
            this.laLMJYQ.Location = new System.Drawing.Point(171, 0);
            this.laLMJYQ.Name = "laLMJYQ";
            this.laLMJYQ.Size = new System.Drawing.Size(66, 24);
            this.laLMJYQ.TabIndex = 0;
            this.laLMJYQ.Text = "林木使用权";
            this.laLMJYQ.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel27
            // 
            this.panel27.Controls.Add(this.LMSYQ);
            this.panel27.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel27.Location = new System.Drawing.Point(78, 0);
            this.panel27.Name = "panel27";
            this.panel27.Padding = new System.Windows.Forms.Padding(2, 4, 4, 0);
            this.panel27.Size = new System.Drawing.Size(93, 24);
            this.panel27.TabIndex = 0;
            // 
            // LMSYQ
            // 
            this.LMSYQ.AssDispValue = true;
            this.LMSYQ.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LMSYQ.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LMSYQ.ForeColor = System.Drawing.Color.Blue;
            this.LMSYQ.Location = new System.Drawing.Point(2, 4);
            this.LMSYQ.Name = "LMSYQ";
            this.LMSYQ.Size = new System.Drawing.Size(87, 20);
            this.LMSYQ.TabIndex = 27;
            this.LMSYQ.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // laLMSYQ
            // 
            this.laLMSYQ.Dock = System.Windows.Forms.DockStyle.Left;
            this.laLMSYQ.Location = new System.Drawing.Point(0, 0);
            this.laLMSYQ.Name = "laLMSYQ";
            this.laLMSYQ.Size = new System.Drawing.Size(78, 24);
            this.laLMSYQ.TabIndex = 0;
            this.laLMSYQ.Text = "林木所有权";
            this.laLMSYQ.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label50
            // 
            this.label50.BackColor = System.Drawing.Color.Black;
            this.label50.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label50.Location = new System.Drawing.Point(0, 24);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(434, 1);
            this.label50.TabIndex = 0;
            this.label50.Text = "label50";
            this.label50.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel15
            // 
            this.panel15.Controls.Add(this.panel29);
            this.panel15.Controls.Add(this.laYU_BI_DU);
            this.panel15.Controls.Add(this.panel26);
            this.panel15.Controls.Add(this.laQI_YUAN);
            this.panel15.Controls.Add(this.label32);
            this.panel15.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel15.Location = new System.Drawing.Point(0, 150);
            this.panel15.Name = "panel15";
            this.panel15.Size = new System.Drawing.Size(434, 25);
            this.panel15.TabIndex = 0;
            // 
            // panel29
            // 
            this.panel29.Controls.Add(this.YU_BI_DU);
            this.panel29.Controls.Add(this.label11);
            this.panel29.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel29.Location = new System.Drawing.Point(237, 0);
            this.panel29.Name = "panel29";
            this.panel29.Padding = new System.Windows.Forms.Padding(2, 6, 6, 2);
            this.panel29.Size = new System.Drawing.Size(105, 24);
            this.panel29.TabIndex = 0;
            // 
            // YU_BI_DU
            // 
            this.YU_BI_DU.Cursor = System.Windows.Forms.Cursors.Hand;
            this.YU_BI_DU.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.YU_BI_DU.EditScale = 0;
            this.YU_BI_DU.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.YU_BI_DU.Location = new System.Drawing.Point(2, 4);
            this.YU_BI_DU.Name = "YU_BI_DU";
            this.YU_BI_DU.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.YU_BI_DU.Properties.Appearance.Options.UseForeColor = true;
            this.YU_BI_DU.Properties.Appearance.Options.UseTextOptions = true;
            this.YU_BI_DU.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.YU_BI_DU.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.YU_BI_DU.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.YU_BI_DU.Properties.MaxValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.YU_BI_DU.Size = new System.Drawing.Size(72, 18);
            this.YU_BI_DU.TabIndex = 26;
            this.YU_BI_DU.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // label11
            // 
            this.label11.Dock = System.Windows.Forms.DockStyle.Right;
            this.label11.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Blue;
            this.label11.Location = new System.Drawing.Point(74, 6);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(25, 16);
            this.label11.TabIndex = 0;
            // 
            // laYU_BI_DU
            // 
            this.laYU_BI_DU.Dock = System.Windows.Forms.DockStyle.Left;
            this.laYU_BI_DU.Location = new System.Drawing.Point(171, 0);
            this.laYU_BI_DU.Name = "laYU_BI_DU";
            this.laYU_BI_DU.Size = new System.Drawing.Size(66, 24);
            this.laYU_BI_DU.TabIndex = 0;
            this.laYU_BI_DU.Text = "郁闭度";
            this.laYU_BI_DU.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel26
            // 
            this.panel26.Controls.Add(this.QI_YUAN);
            this.panel26.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel26.Location = new System.Drawing.Point(78, 0);
            this.panel26.Name = "panel26";
            this.panel26.Padding = new System.Windows.Forms.Padding(2, 4, 4, 0);
            this.panel26.Size = new System.Drawing.Size(93, 24);
            this.panel26.TabIndex = 0;
            // 
            // QI_YUAN
            // 
            this.QI_YUAN.AssDispValue = true;
            this.QI_YUAN.Cursor = System.Windows.Forms.Cursors.Hand;
            this.QI_YUAN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.QI_YUAN.ForeColor = System.Drawing.Color.Blue;
            this.QI_YUAN.Location = new System.Drawing.Point(2, 4);
            this.QI_YUAN.Name = "QI_YUAN";
            this.QI_YUAN.Size = new System.Drawing.Size(87, 20);
            this.QI_YUAN.TabIndex = 25;
            this.QI_YUAN.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // laQI_YUAN
            // 
            this.laQI_YUAN.Dock = System.Windows.Forms.DockStyle.Left;
            this.laQI_YUAN.Location = new System.Drawing.Point(0, 0);
            this.laQI_YUAN.Name = "laQI_YUAN";
            this.laQI_YUAN.Size = new System.Drawing.Size(78, 24);
            this.laQI_YUAN.TabIndex = 0;
            this.laQI_YUAN.Text = "起源";
            this.laQI_YUAN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label32
            // 
            this.label32.BackColor = System.Drawing.Color.Black;
            this.label32.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label32.Location = new System.Drawing.Point(0, 24);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(434, 1);
            this.label32.TabIndex = 0;
            this.label32.Text = "label32";
            this.label32.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel37
            // 
            this.panel37.Controls.Add(this.panel18);
            this.panel37.Controls.Add(this.laLING_ZU);
            this.panel37.Controls.Add(this.panel67);
            this.panel37.Controls.Add(this.laPINGJUN_NL);
            this.panel37.Controls.Add(this.label183);
            this.panel37.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel37.Location = new System.Drawing.Point(0, 125);
            this.panel37.Name = "panel37";
            this.panel37.Size = new System.Drawing.Size(434, 25);
            this.panel37.TabIndex = 0;
            // 
            // panel18
            // 
            this.panel18.Controls.Add(this.LING_ZU);
            this.panel18.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel18.Location = new System.Drawing.Point(237, 0);
            this.panel18.Name = "panel18";
            this.panel18.Padding = new System.Windows.Forms.Padding(2, 6, 6, 2);
            this.panel18.Size = new System.Drawing.Size(105, 24);
            this.panel18.TabIndex = 0;
            // 
            // LING_ZU
            // 
            this.LING_ZU.AssDispValue = true;
            this.LING_ZU.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LING_ZU.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LING_ZU.ForeColor = System.Drawing.Color.Blue;
            this.LING_ZU.Location = new System.Drawing.Point(2, 6);
            this.LING_ZU.Name = "LING_ZU";
            this.LING_ZU.Size = new System.Drawing.Size(97, 20);
            this.LING_ZU.TabIndex = 24;
            this.LING_ZU.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // laLING_ZU
            // 
            this.laLING_ZU.Dock = System.Windows.Forms.DockStyle.Left;
            this.laLING_ZU.Location = new System.Drawing.Point(171, 0);
            this.laLING_ZU.Name = "laLING_ZU";
            this.laLING_ZU.Size = new System.Drawing.Size(66, 24);
            this.laLING_ZU.TabIndex = 0;
            this.laLING_ZU.Text = "龄组";
            this.laLING_ZU.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel67
            // 
            this.panel67.Controls.Add(this.PINGJUN_NL);
            this.panel67.Controls.Add(this.label12);
            this.panel67.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel67.Location = new System.Drawing.Point(78, 0);
            this.panel67.Name = "panel67";
            this.panel67.Padding = new System.Windows.Forms.Padding(2, 4, 4, 0);
            this.panel67.Size = new System.Drawing.Size(93, 24);
            this.panel67.TabIndex = 0;
            // 
            // PINGJUN_NL
            // 
            this.PINGJUN_NL.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PINGJUN_NL.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PINGJUN_NL.EditScale = 0;
            this.PINGJUN_NL.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.PINGJUN_NL.Location = new System.Drawing.Point(2, 6);
            this.PINGJUN_NL.Name = "PINGJUN_NL";
            this.PINGJUN_NL.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.PINGJUN_NL.Properties.Appearance.Options.UseForeColor = true;
            this.PINGJUN_NL.Properties.Appearance.Options.UseTextOptions = true;
            this.PINGJUN_NL.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.PINGJUN_NL.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.PINGJUN_NL.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.PINGJUN_NL.Properties.MaxValue = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.PINGJUN_NL.Size = new System.Drawing.Size(65, 18);
            this.PINGJUN_NL.TabIndex = 23;
            this.PINGJUN_NL.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // label12
            // 
            this.label12.Dock = System.Windows.Forms.DockStyle.Right;
            this.label12.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Blue;
            this.label12.Location = new System.Drawing.Point(67, 4);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(22, 20);
            this.label12.TabIndex = 0;
            // 
            // laPINGJUN_NL
            // 
            this.laPINGJUN_NL.Dock = System.Windows.Forms.DockStyle.Left;
            this.laPINGJUN_NL.Location = new System.Drawing.Point(0, 0);
            this.laPINGJUN_NL.Name = "laPINGJUN_NL";
            this.laPINGJUN_NL.Size = new System.Drawing.Size(78, 24);
            this.laPINGJUN_NL.TabIndex = 0;
            this.laPINGJUN_NL.Text = "平均年龄";
            this.laPINGJUN_NL.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label183
            // 
            this.label183.BackColor = System.Drawing.Color.Black;
            this.label183.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label183.Location = new System.Drawing.Point(0, 24);
            this.label183.Name = "label183";
            this.label183.Size = new System.Drawing.Size(434, 1);
            this.label183.TabIndex = 0;
            this.label183.Text = "label183";
            this.label183.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel31
            // 
            this.panel31.Controls.Add(this.panel33);
            this.panel31.Controls.Add(this.laLIN_ZHONG);
            this.panel31.Controls.Add(this.panel34);
            this.panel31.Controls.Add(this.laQ_LIN_ZHONG);
            this.panel31.Controls.Add(this.label49);
            this.panel31.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel31.Location = new System.Drawing.Point(0, 100);
            this.panel31.Name = "panel31";
            this.panel31.Size = new System.Drawing.Size(434, 25);
            this.panel31.TabIndex = 0;
            // 
            // panel33
            // 
            this.panel33.Controls.Add(this.LIN_ZHONG);
            this.panel33.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel33.Location = new System.Drawing.Point(254, 0);
            this.panel33.Name = "panel33";
            this.panel33.Padding = new System.Windows.Forms.Padding(2, 4, 4, 0);
            this.panel33.Size = new System.Drawing.Size(110, 24);
            this.panel33.TabIndex = 0;
            // 
            // LIN_ZHONG
            // 
            this.LIN_ZHONG.AssDispValue = true;
            this.LIN_ZHONG.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LIN_ZHONG.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LIN_ZHONG.ForeColor = System.Drawing.Color.Blue;
            this.LIN_ZHONG.Location = new System.Drawing.Point(2, 4);
            this.LIN_ZHONG.Name = "LIN_ZHONG";
            this.LIN_ZHONG.Size = new System.Drawing.Size(104, 20);
            this.LIN_ZHONG.TabIndex = 22;
            this.LIN_ZHONG.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // laLIN_ZHONG
            // 
            this.laLIN_ZHONG.Dock = System.Windows.Forms.DockStyle.Left;
            this.laLIN_ZHONG.Location = new System.Drawing.Point(188, 0);
            this.laLIN_ZHONG.Name = "laLIN_ZHONG";
            this.laLIN_ZHONG.Size = new System.Drawing.Size(66, 24);
            this.laLIN_ZHONG.TabIndex = 0;
            this.laLIN_ZHONG.Text = "林种";
            this.laLIN_ZHONG.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel34
            // 
            this.panel34.Controls.Add(this.Q_LIN_ZHONG);
            this.panel34.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel34.Location = new System.Drawing.Point(78, 0);
            this.panel34.Name = "panel34";
            this.panel34.Padding = new System.Windows.Forms.Padding(2, 4, 4, 0);
            this.panel34.Size = new System.Drawing.Size(110, 24);
            this.panel34.TabIndex = 0;
            // 
            // Q_LIN_ZHONG
            // 
            this.Q_LIN_ZHONG.AssDispValue = true;
            this.Q_LIN_ZHONG.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Q_LIN_ZHONG.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Q_LIN_ZHONG.ForeColor = System.Drawing.Color.Blue;
            this.Q_LIN_ZHONG.Location = new System.Drawing.Point(2, 4);
            this.Q_LIN_ZHONG.Name = "Q_LIN_ZHONG";
            this.Q_LIN_ZHONG.Size = new System.Drawing.Size(104, 20);
            this.Q_LIN_ZHONG.TabIndex = 21;
            this.Q_LIN_ZHONG.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // laQ_LIN_ZHONG
            // 
            this.laQ_LIN_ZHONG.Dock = System.Windows.Forms.DockStyle.Left;
            this.laQ_LIN_ZHONG.Location = new System.Drawing.Point(0, 0);
            this.laQ_LIN_ZHONG.Name = "laQ_LIN_ZHONG";
            this.laQ_LIN_ZHONG.Size = new System.Drawing.Size(78, 24);
            this.laQ_LIN_ZHONG.TabIndex = 0;
            this.laQ_LIN_ZHONG.Text = "前期林种";
            this.laQ_LIN_ZHONG.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label49
            // 
            this.label49.BackColor = System.Drawing.Color.Black;
            this.label49.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label49.Location = new System.Drawing.Point(0, 24);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(434, 1);
            this.label49.TabIndex = 0;
            this.label49.Text = "label49";
            this.label49.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel41
            // 
            this.panel41.Controls.Add(this.panel35);
            this.panel41.Controls.Add(this.laDI_LEI);
            this.panel41.Controls.Add(this.panel43);
            this.panel41.Controls.Add(this.laQ_DI_LEI);
            this.panel41.Controls.Add(this.label65);
            this.panel41.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel41.Location = new System.Drawing.Point(0, 75);
            this.panel41.Name = "panel41";
            this.panel41.Size = new System.Drawing.Size(434, 25);
            this.panel41.TabIndex = 0;
            // 
            // panel35
            // 
            this.panel35.Controls.Add(this.DI_LEI);
            this.panel35.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel35.Location = new System.Drawing.Point(254, 0);
            this.panel35.Name = "panel35";
            this.panel35.Padding = new System.Windows.Forms.Padding(2, 4, 4, 0);
            this.panel35.Size = new System.Drawing.Size(110, 24);
            this.panel35.TabIndex = 0;
            // 
            // DI_LEI
            // 
            this.DI_LEI.AssDispValue = true;
            this.DI_LEI.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DI_LEI.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DI_LEI.ForeColor = System.Drawing.Color.Blue;
            this.DI_LEI.Location = new System.Drawing.Point(2, 4);
            this.DI_LEI.Name = "DI_LEI";
            this.DI_LEI.Size = new System.Drawing.Size(104, 20);
            this.DI_LEI.TabIndex = 20;
            this.DI_LEI.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // laDI_LEI
            // 
            this.laDI_LEI.Dock = System.Windows.Forms.DockStyle.Left;
            this.laDI_LEI.Location = new System.Drawing.Point(188, 0);
            this.laDI_LEI.Name = "laDI_LEI";
            this.laDI_LEI.Size = new System.Drawing.Size(66, 24);
            this.laDI_LEI.TabIndex = 0;
            this.laDI_LEI.Text = "地类";
            this.laDI_LEI.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel43
            // 
            this.panel43.Controls.Add(this.Q_DI_LEI);
            this.panel43.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel43.Location = new System.Drawing.Point(78, 0);
            this.panel43.Name = "panel43";
            this.panel43.Padding = new System.Windows.Forms.Padding(2, 4, 4, 0);
            this.panel43.Size = new System.Drawing.Size(110, 24);
            this.panel43.TabIndex = 0;
            // 
            // Q_DI_LEI
            // 
            this.Q_DI_LEI.AssDispValue = true;
            this.Q_DI_LEI.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Q_DI_LEI.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Q_DI_LEI.ForeColor = System.Drawing.Color.Blue;
            this.Q_DI_LEI.Location = new System.Drawing.Point(2, 4);
            this.Q_DI_LEI.Name = "Q_DI_LEI";
            this.Q_DI_LEI.Size = new System.Drawing.Size(104, 20);
            this.Q_DI_LEI.TabIndex = 19;
            this.Q_DI_LEI.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // laQ_DI_LEI
            // 
            this.laQ_DI_LEI.Dock = System.Windows.Forms.DockStyle.Left;
            this.laQ_DI_LEI.Location = new System.Drawing.Point(0, 0);
            this.laQ_DI_LEI.Name = "laQ_DI_LEI";
            this.laQ_DI_LEI.Size = new System.Drawing.Size(78, 24);
            this.laQ_DI_LEI.TabIndex = 0;
            this.laQ_DI_LEI.Text = "前期地类";
            this.laQ_DI_LEI.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label65
            // 
            this.label65.BackColor = System.Drawing.Color.Black;
            this.label65.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label65.Location = new System.Drawing.Point(0, 24);
            this.label65.Name = "label65";
            this.label65.Size = new System.Drawing.Size(434, 1);
            this.label65.TabIndex = 0;
            this.label65.Text = "label65";
            this.label65.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel21
            // 
            this.panel21.Controls.Add(this.panel24);
            this.panel21.Controls.Add(this.laLD_QS);
            this.panel21.Controls.Add(this.panel25);
            this.panel21.Controls.Add(this.laQ_LD_QS);
            this.panel21.Controls.Add(this.label47);
            this.panel21.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel21.Location = new System.Drawing.Point(0, 50);
            this.panel21.Name = "panel21";
            this.panel21.Size = new System.Drawing.Size(434, 25);
            this.panel21.TabIndex = 0;
            // 
            // panel24
            // 
            this.panel24.Controls.Add(this.LD_QS);
            this.panel24.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel24.Location = new System.Drawing.Point(254, 0);
            this.panel24.Name = "panel24";
            this.panel24.Padding = new System.Windows.Forms.Padding(2, 4, 4, 0);
            this.panel24.Size = new System.Drawing.Size(110, 24);
            this.panel24.TabIndex = 0;
            // 
            // LD_QS
            // 
            this.LD_QS.AssDispValue = true;
            this.LD_QS.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LD_QS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LD_QS.ForeColor = System.Drawing.Color.Blue;
            this.LD_QS.Location = new System.Drawing.Point(2, 4);
            this.LD_QS.Name = "LD_QS";
            this.LD_QS.Size = new System.Drawing.Size(104, 20);
            this.LD_QS.TabIndex = 18;
            this.LD_QS.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // laLD_QS
            // 
            this.laLD_QS.Dock = System.Windows.Forms.DockStyle.Left;
            this.laLD_QS.Location = new System.Drawing.Point(188, 0);
            this.laLD_QS.Name = "laLD_QS";
            this.laLD_QS.Size = new System.Drawing.Size(66, 24);
            this.laLD_QS.TabIndex = 0;
            this.laLD_QS.Text = "土地权属";
            this.laLD_QS.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel25
            // 
            this.panel25.Controls.Add(this.Q_LD_QS);
            this.panel25.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel25.Location = new System.Drawing.Point(78, 0);
            this.panel25.Name = "panel25";
            this.panel25.Padding = new System.Windows.Forms.Padding(2, 4, 4, 0);
            this.panel25.Size = new System.Drawing.Size(110, 24);
            this.panel25.TabIndex = 0;
            // 
            // Q_LD_QS
            // 
            this.Q_LD_QS.AssDispValue = true;
            this.Q_LD_QS.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Q_LD_QS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Q_LD_QS.ForeColor = System.Drawing.Color.Blue;
            this.Q_LD_QS.Location = new System.Drawing.Point(2, 4);
            this.Q_LD_QS.Name = "Q_LD_QS";
            this.Q_LD_QS.Size = new System.Drawing.Size(104, 20);
            this.Q_LD_QS.TabIndex = 17;
            this.Q_LD_QS.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // laQ_LD_QS
            // 
            this.laQ_LD_QS.Dock = System.Windows.Forms.DockStyle.Left;
            this.laQ_LD_QS.Location = new System.Drawing.Point(0, 0);
            this.laQ_LD_QS.Name = "laQ_LD_QS";
            this.laQ_LD_QS.Size = new System.Drawing.Size(78, 24);
            this.laQ_LD_QS.TabIndex = 0;
            this.laQ_LD_QS.Text = "前期土地权属";
            this.laQ_LD_QS.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label47
            // 
            this.label47.BackColor = System.Drawing.Color.Black;
            this.label47.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label47.Location = new System.Drawing.Point(0, 24);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(434, 1);
            this.label47.TabIndex = 0;
            this.label47.Text = "label47";
            this.label47.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel100
            // 
            this.panel100.Controls.Add(this.labelLBMess);
            this.panel100.Controls.Add(this.panel9);
            this.panel100.Controls.Add(this.laSEN_LIN_LB);
            this.panel100.Controls.Add(this.panel23);
            this.panel100.Controls.Add(this.laQ_SEN_LB);
            this.panel100.Controls.Add(this.label162);
            this.panel100.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel100.Location = new System.Drawing.Point(0, 25);
            this.panel100.Name = "panel100";
            this.panel100.Size = new System.Drawing.Size(434, 25);
            this.panel100.TabIndex = 0;
            // 
            // labelLBMess
            // 
            this.labelLBMess.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelLBMess.ForeColor = System.Drawing.Color.Red;
            this.labelLBMess.Location = new System.Drawing.Point(342, 0);
            this.labelLBMess.Name = "labelLBMess";
            this.labelLBMess.Size = new System.Drawing.Size(103, 24);
            this.labelLBMess.TabIndex = 0;
            this.labelLBMess.Text = "森林类别已改变！";
            this.labelLBMess.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelLBMess.Visible = false;
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.SEN_LIN_LB);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel9.Location = new System.Drawing.Point(237, 0);
            this.panel9.Name = "panel9";
            this.panel9.Padding = new System.Windows.Forms.Padding(2, 4, 4, 0);
            this.panel9.Size = new System.Drawing.Size(105, 24);
            this.panel9.TabIndex = 0;
            // 
            // SEN_LIN_LB
            // 
            this.SEN_LIN_LB.AssDispValue = true;
            this.SEN_LIN_LB.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SEN_LIN_LB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SEN_LIN_LB.ForeColor = System.Drawing.Color.Blue;
            this.SEN_LIN_LB.Location = new System.Drawing.Point(2, 4);
            this.SEN_LIN_LB.Name = "SEN_LIN_LB";
            this.SEN_LIN_LB.Size = new System.Drawing.Size(99, 20);
            this.SEN_LIN_LB.TabIndex = 16;
            this.SEN_LIN_LB.SelectedIndexChanged += new System.EventHandler(this.SEN_LIN_LB_SelectedIndexChanged);
            this.SEN_LIN_LB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // laSEN_LIN_LB
            // 
            this.laSEN_LIN_LB.Dock = System.Windows.Forms.DockStyle.Left;
            this.laSEN_LIN_LB.Location = new System.Drawing.Point(171, 0);
            this.laSEN_LIN_LB.Name = "laSEN_LIN_LB";
            this.laSEN_LIN_LB.Size = new System.Drawing.Size(66, 24);
            this.laSEN_LIN_LB.TabIndex = 0;
            this.laSEN_LIN_LB.Text = "森林类别";
            this.laSEN_LIN_LB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel23
            // 
            this.panel23.Controls.Add(this.Q_SEN_LB);
            this.panel23.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel23.Location = new System.Drawing.Point(78, 0);
            this.panel23.Name = "panel23";
            this.panel23.Padding = new System.Windows.Forms.Padding(2, 4, 4, 0);
            this.panel23.Size = new System.Drawing.Size(93, 24);
            this.panel23.TabIndex = 0;
            // 
            // Q_SEN_LB
            // 
            this.Q_SEN_LB.AssDispValue = true;
            this.Q_SEN_LB.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Q_SEN_LB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Q_SEN_LB.ForeColor = System.Drawing.Color.Blue;
            this.Q_SEN_LB.Location = new System.Drawing.Point(2, 4);
            this.Q_SEN_LB.Name = "Q_SEN_LB";
            this.Q_SEN_LB.Size = new System.Drawing.Size(87, 20);
            this.Q_SEN_LB.TabIndex = 15;
            this.Q_SEN_LB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // laQ_SEN_LB
            // 
            this.laQ_SEN_LB.Dock = System.Windows.Forms.DockStyle.Left;
            this.laQ_SEN_LB.Location = new System.Drawing.Point(0, 0);
            this.laQ_SEN_LB.Name = "laQ_SEN_LB";
            this.laQ_SEN_LB.Size = new System.Drawing.Size(78, 24);
            this.laQ_SEN_LB.TabIndex = 0;
            this.laQ_SEN_LB.Text = "前期森林类别";
            this.laQ_SEN_LB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label162
            // 
            this.label162.BackColor = System.Drawing.Color.Black;
            this.label162.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label162.Location = new System.Drawing.Point(0, 24);
            this.label162.Name = "label162";
            this.label162.Size = new System.Drawing.Size(434, 1);
            this.label162.TabIndex = 0;
            this.label162.Text = "label162";
            this.label162.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.panel14);
            this.panel8.Controls.Add(this.laYOU_SHI_SZ);
            this.panel8.Controls.Add(this.panel17);
            this.panel8.Controls.Add(this.laMIAN_JI);
            this.panel8.Controls.Add(this.label26);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel8.Location = new System.Drawing.Point(0, 0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(434, 25);
            this.panel8.TabIndex = 0;
            // 
            // panel14
            // 
            this.panel14.Controls.Add(this.YOU_SHI_SZ);
            this.panel14.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel14.Location = new System.Drawing.Point(237, 0);
            this.panel14.Name = "panel14";
            this.panel14.Padding = new System.Windows.Forms.Padding(2, 4, 4, 0);
            this.panel14.Size = new System.Drawing.Size(105, 24);
            this.panel14.TabIndex = 0;
            // 
            // YOU_SHI_SZ
            // 
            this.YOU_SHI_SZ.AssDispValue = true;
            this.YOU_SHI_SZ.Cursor = System.Windows.Forms.Cursors.Hand;
            this.YOU_SHI_SZ.Dock = System.Windows.Forms.DockStyle.Fill;
            this.YOU_SHI_SZ.ForeColor = System.Drawing.Color.Blue;
            this.YOU_SHI_SZ.Location = new System.Drawing.Point(2, 4);
            this.YOU_SHI_SZ.Name = "YOU_SHI_SZ";
            this.YOU_SHI_SZ.Size = new System.Drawing.Size(99, 20);
            this.YOU_SHI_SZ.TabIndex = 14;
            this.YOU_SHI_SZ.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // laYOU_SHI_SZ
            // 
            this.laYOU_SHI_SZ.Dock = System.Windows.Forms.DockStyle.Left;
            this.laYOU_SHI_SZ.Location = new System.Drawing.Point(171, 0);
            this.laYOU_SHI_SZ.Name = "laYOU_SHI_SZ";
            this.laYOU_SHI_SZ.Size = new System.Drawing.Size(66, 24);
            this.laYOU_SHI_SZ.TabIndex = 0;
            this.laYOU_SHI_SZ.Text = "优势树种";
            this.laYOU_SHI_SZ.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel17
            // 
            this.panel17.Controls.Add(this.MIAN_JI);
            this.panel17.Controls.Add(this.label51);
            this.panel17.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel17.Location = new System.Drawing.Point(38, 0);
            this.panel17.Name = "panel17";
            this.panel17.Padding = new System.Windows.Forms.Padding(2, 6, 6, 2);
            this.panel17.Size = new System.Drawing.Size(133, 24);
            this.panel17.TabIndex = 0;
            // 
            // MIAN_JI
            // 
            this.MIAN_JI.Cursor = System.Windows.Forms.Cursors.Hand;
            this.MIAN_JI.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.MIAN_JI.EditScale = 0;
            this.MIAN_JI.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.MIAN_JI.Location = new System.Drawing.Point(2, 4);
            this.MIAN_JI.Name = "MIAN_JI";
            this.MIAN_JI.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.MIAN_JI.Properties.Appearance.Options.UseForeColor = true;
            this.MIAN_JI.Properties.Appearance.Options.UseTextOptions = true;
            this.MIAN_JI.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.MIAN_JI.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.MIAN_JI.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.MIAN_JI.Properties.MaxValue = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.MIAN_JI.Size = new System.Drawing.Size(93, 18);
            this.MIAN_JI.TabIndex = 13;
            this.MIAN_JI.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // label51
            // 
            this.label51.Dock = System.Windows.Forms.DockStyle.Right;
            this.label51.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label51.ForeColor = System.Drawing.Color.Blue;
            this.label51.Location = new System.Drawing.Point(95, 6);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(32, 16);
            this.label51.TabIndex = 0;
            this.label51.Text = "公顷";
            // 
            // laMIAN_JI
            // 
            this.laMIAN_JI.Dock = System.Windows.Forms.DockStyle.Left;
            this.laMIAN_JI.Location = new System.Drawing.Point(0, 0);
            this.laMIAN_JI.Name = "laMIAN_JI";
            this.laMIAN_JI.Size = new System.Drawing.Size(38, 24);
            this.laMIAN_JI.TabIndex = 0;
            this.laMIAN_JI.Text = "面积";
            this.laMIAN_JI.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label26
            // 
            this.label26.BackColor = System.Drawing.Color.Black;
            this.label26.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label26.Location = new System.Drawing.Point(0, 24);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(434, 1);
            this.label26.TabIndex = 0;
            this.label26.Text = "label26";
            this.label26.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label67
            // 
            this.label67.BackColor = System.Drawing.Color.Black;
            this.label67.Dock = System.Windows.Forms.DockStyle.Top;
            this.label67.Location = new System.Drawing.Point(1, 0);
            this.label67.Name = "label67";
            this.label67.Size = new System.Drawing.Size(434, 1);
            this.label67.TabIndex = 0;
            this.label67.Text = "label67";
            this.label67.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label68
            // 
            this.label68.BackColor = System.Drawing.Color.Black;
            this.label68.Dock = System.Windows.Forms.DockStyle.Left;
            this.label68.Location = new System.Drawing.Point(0, 0);
            this.label68.Name = "label68";
            this.label68.Size = new System.Drawing.Size(1, 226);
            this.label68.TabIndex = 0;
            this.label68.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label69
            // 
            this.label69.BackColor = System.Drawing.Color.Black;
            this.label69.Dock = System.Windows.Forms.DockStyle.Right;
            this.label69.Location = new System.Drawing.Point(435, 0);
            this.label69.Name = "label69";
            this.label69.Size = new System.Drawing.Size(1, 226);
            this.label69.TabIndex = 0;
            this.label69.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label70
            // 
            this.label70.Dock = System.Windows.Forms.DockStyle.Top;
            this.label70.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label70.Location = new System.Drawing.Point(0, 260);
            this.label70.Name = "label70";
            this.label70.Size = new System.Drawing.Size(436, 26);
            this.label70.TabIndex = 0;
            this.label70.Text = "  林木状况调查";
            this.label70.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelFire
            // 
            this.panelFire.Controls.Add(this.panel36);
            this.panelFire.Controls.Add(this.label90);
            this.panelFire.Controls.Add(this.label91);
            this.panelFire.Controls.Add(this.label92);
            this.panelFire.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelFire.Location = new System.Drawing.Point(0, 538);
            this.panelFire.Name = "panelFire";
            this.panelFire.Size = new System.Drawing.Size(436, 76);
            this.panelFire.TabIndex = 0;
            // 
            // panel36
            // 
            this.panel36.Controls.Add(this.panel40);
            this.panel36.Controls.Add(this.panel13);
            this.panel36.Controls.Add(this.panel50);
            this.panel36.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel36.Location = new System.Drawing.Point(1, 1);
            this.panel36.Name = "panel36";
            this.panel36.Size = new System.Drawing.Size(434, 75);
            this.panel36.TabIndex = 0;
            // 
            // panel40
            // 
            this.panel40.Controls.Add(this.panel47);
            this.panel40.Controls.Add(this.laBLXJ);
            this.panel40.Controls.Add(this.panel48);
            this.panel40.Controls.Add(this.laSUNSHIXJ);
            this.panel40.Controls.Add(this.label30);
            this.panel40.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel40.Location = new System.Drawing.Point(0, 50);
            this.panel40.Name = "panel40";
            this.panel40.Size = new System.Drawing.Size(434, 25);
            this.panel40.TabIndex = 0;
            // 
            // panel47
            // 
            this.panel47.Controls.Add(this.BLXJ);
            this.panel47.Controls.Add(this.label34);
            this.panel47.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel47.Location = new System.Drawing.Point(237, 0);
            this.panel47.Name = "panel47";
            this.panel47.Padding = new System.Windows.Forms.Padding(2, 6, 6, 2);
            this.panel47.Size = new System.Drawing.Size(105, 24);
            this.panel47.TabIndex = 0;
            // 
            // BLXJ
            // 
            this.BLXJ.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BLXJ.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BLXJ.EditScale = 0;
            this.BLXJ.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.BLXJ.Location = new System.Drawing.Point(2, 4);
            this.BLXJ.Name = "BLXJ";
            this.BLXJ.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.BLXJ.Properties.Appearance.Options.UseForeColor = true;
            this.BLXJ.Properties.Appearance.Options.UseTextOptions = true;
            this.BLXJ.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.BLXJ.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.BLXJ.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.BLXJ.Properties.MaxValue = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.BLXJ.Size = new System.Drawing.Size(65, 18);
            this.BLXJ.TabIndex = 35;
            this.BLXJ.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // label34
            // 
            this.label34.Dock = System.Windows.Forms.DockStyle.Right;
            this.label34.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label34.ForeColor = System.Drawing.Color.Blue;
            this.label34.Location = new System.Drawing.Point(67, 6);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(32, 16);
            this.label34.TabIndex = 0;
            this.label34.Text = "m³";
            // 
            // laBLXJ
            // 
            this.laBLXJ.Dock = System.Windows.Forms.DockStyle.Left;
            this.laBLXJ.Location = new System.Drawing.Point(171, 0);
            this.laBLXJ.Name = "laBLXJ";
            this.laBLXJ.Size = new System.Drawing.Size(66, 24);
            this.laBLXJ.TabIndex = 0;
            this.laBLXJ.Text = "保留蓄积";
            this.laBLXJ.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel48
            // 
            this.panel48.Controls.Add(this.SUNSHIXJ);
            this.panel48.Controls.Add(this.label31);
            this.panel48.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel48.Location = new System.Drawing.Point(66, 0);
            this.panel48.Name = "panel48";
            this.panel48.Padding = new System.Windows.Forms.Padding(2, 6, 6, 2);
            this.panel48.Size = new System.Drawing.Size(105, 24);
            this.panel48.TabIndex = 0;
            // 
            // SUNSHIXJ
            // 
            this.SUNSHIXJ.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SUNSHIXJ.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.SUNSHIXJ.EditScale = 0;
            this.SUNSHIXJ.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.SUNSHIXJ.Location = new System.Drawing.Point(2, 4);
            this.SUNSHIXJ.Name = "SUNSHIXJ";
            this.SUNSHIXJ.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.SUNSHIXJ.Properties.Appearance.Options.UseForeColor = true;
            this.SUNSHIXJ.Properties.Appearance.Options.UseTextOptions = true;
            this.SUNSHIXJ.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.SUNSHIXJ.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.SUNSHIXJ.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.SUNSHIXJ.Properties.MaxValue = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.SUNSHIXJ.Size = new System.Drawing.Size(65, 18);
            this.SUNSHIXJ.TabIndex = 34;
            this.SUNSHIXJ.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // label31
            // 
            this.label31.Dock = System.Windows.Forms.DockStyle.Right;
            this.label31.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label31.ForeColor = System.Drawing.Color.Blue;
            this.label31.Location = new System.Drawing.Point(67, 6);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(32, 16);
            this.label31.TabIndex = 0;
            this.label31.Text = "m³";
            // 
            // laSUNSHIXJ
            // 
            this.laSUNSHIXJ.Dock = System.Windows.Forms.DockStyle.Left;
            this.laSUNSHIXJ.Location = new System.Drawing.Point(0, 0);
            this.laSUNSHIXJ.Name = "laSUNSHIXJ";
            this.laSUNSHIXJ.Size = new System.Drawing.Size(66, 24);
            this.laSUNSHIXJ.TabIndex = 0;
            this.laSUNSHIXJ.Text = "损失蓄积";
            this.laSUNSHIXJ.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label30
            // 
            this.label30.BackColor = System.Drawing.Color.Black;
            this.label30.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label30.Location = new System.Drawing.Point(0, 24);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(434, 1);
            this.label30.TabIndex = 0;
            this.label30.Text = "label30";
            this.label30.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel13
            // 
            this.panel13.Controls.Add(this.panel38);
            this.panel13.Controls.Add(this.laSS_ZS);
            this.panel13.Controls.Add(this.panel39);
            this.panel13.Controls.Add(this.laZHMJ);
            this.panel13.Controls.Add(this.label24);
            this.panel13.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel13.Location = new System.Drawing.Point(0, 25);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(434, 25);
            this.panel13.TabIndex = 0;
            // 
            // panel38
            // 
            this.panel38.Controls.Add(this.SS_ZS);
            this.panel38.Controls.Add(this.label33);
            this.panel38.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel38.Location = new System.Drawing.Point(237, 0);
            this.panel38.Name = "panel38";
            this.panel38.Padding = new System.Windows.Forms.Padding(2, 6, 6, 2);
            this.panel38.Size = new System.Drawing.Size(105, 24);
            this.panel38.TabIndex = 0;
            // 
            // SS_ZS
            // 
            this.SS_ZS.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SS_ZS.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.SS_ZS.EditScale = 0;
            this.SS_ZS.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.SS_ZS.Location = new System.Drawing.Point(2, 4);
            this.SS_ZS.Name = "SS_ZS";
            this.SS_ZS.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.SS_ZS.Properties.Appearance.Options.UseForeColor = true;
            this.SS_ZS.Properties.Appearance.Options.UseTextOptions = true;
            this.SS_ZS.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.SS_ZS.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.SS_ZS.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.SS_ZS.Properties.MaxValue = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.SS_ZS.Size = new System.Drawing.Size(65, 18);
            this.SS_ZS.TabIndex = 33;
            this.SS_ZS.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // label33
            // 
            this.label33.Dock = System.Windows.Forms.DockStyle.Right;
            this.label33.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label33.ForeColor = System.Drawing.Color.Blue;
            this.label33.Location = new System.Drawing.Point(67, 6);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(32, 16);
            this.label33.TabIndex = 0;
            this.label33.Text = "万株";
            // 
            // laSS_ZS
            // 
            this.laSS_ZS.Dock = System.Windows.Forms.DockStyle.Left;
            this.laSS_ZS.Location = new System.Drawing.Point(171, 0);
            this.laSS_ZS.Name = "laSS_ZS";
            this.laSS_ZS.Size = new System.Drawing.Size(66, 24);
            this.laSS_ZS.TabIndex = 0;
            this.laSS_ZS.Text = "损失株数";
            this.laSS_ZS.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel39
            // 
            this.panel39.Controls.Add(this.ZHMJ);
            this.panel39.Controls.Add(this.label28);
            this.panel39.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel39.Location = new System.Drawing.Point(66, 0);
            this.panel39.Name = "panel39";
            this.panel39.Padding = new System.Windows.Forms.Padding(2, 6, 6, 2);
            this.panel39.Size = new System.Drawing.Size(105, 24);
            this.panel39.TabIndex = 0;
            // 
            // ZHMJ
            // 
            this.ZHMJ.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ZHMJ.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ZHMJ.EditScale = 0;
            this.ZHMJ.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ZHMJ.Location = new System.Drawing.Point(2, 4);
            this.ZHMJ.Name = "ZHMJ";
            this.ZHMJ.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.ZHMJ.Properties.Appearance.Options.UseForeColor = true;
            this.ZHMJ.Properties.Appearance.Options.UseTextOptions = true;
            this.ZHMJ.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.ZHMJ.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.ZHMJ.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.ZHMJ.Properties.MaxValue = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.ZHMJ.Size = new System.Drawing.Size(65, 18);
            this.ZHMJ.TabIndex = 32;
            this.ZHMJ.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // label28
            // 
            this.label28.Dock = System.Windows.Forms.DockStyle.Right;
            this.label28.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label28.ForeColor = System.Drawing.Color.Blue;
            this.label28.Location = new System.Drawing.Point(67, 6);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(32, 16);
            this.label28.TabIndex = 0;
            this.label28.Text = "公顷";
            // 
            // laZHMJ
            // 
            this.laZHMJ.Dock = System.Windows.Forms.DockStyle.Left;
            this.laZHMJ.Location = new System.Drawing.Point(0, 0);
            this.laZHMJ.Name = "laZHMJ";
            this.laZHMJ.Size = new System.Drawing.Size(66, 24);
            this.laZHMJ.TabIndex = 0;
            this.laZHMJ.Text = "灾害面积";
            this.laZHMJ.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label24
            // 
            this.label24.BackColor = System.Drawing.Color.Black;
            this.label24.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label24.Location = new System.Drawing.Point(0, 24);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(434, 1);
            this.label24.TabIndex = 0;
            this.label24.Text = "label24";
            this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel50
            // 
            this.panel50.Controls.Add(this.panel52);
            this.panel50.Controls.Add(this.laDISASTER_C);
            this.panel50.Controls.Add(this.panel53);
            this.panel50.Controls.Add(this.laDISPE);
            this.panel50.Controls.Add(this.label88);
            this.panel50.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel50.Location = new System.Drawing.Point(0, 0);
            this.panel50.Name = "panel50";
            this.panel50.Size = new System.Drawing.Size(434, 25);
            this.panel50.TabIndex = 0;
            // 
            // panel52
            // 
            this.panel52.Controls.Add(this.DISASTER_C);
            this.panel52.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel52.Location = new System.Drawing.Point(237, 0);
            this.panel52.Name = "panel52";
            this.panel52.Padding = new System.Windows.Forms.Padding(2, 4, 4, 0);
            this.panel52.Size = new System.Drawing.Size(105, 24);
            this.panel52.TabIndex = 0;
            // 
            // DISASTER_C
            // 
            this.DISASTER_C.AssDispValue = true;
            this.DISASTER_C.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DISASTER_C.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DISASTER_C.ForeColor = System.Drawing.Color.Blue;
            this.DISASTER_C.Location = new System.Drawing.Point(2, 4);
            this.DISASTER_C.Name = "DISASTER_C";
            this.DISASTER_C.Size = new System.Drawing.Size(99, 20);
            this.DISASTER_C.TabIndex = 31;
            this.DISASTER_C.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // laDISASTER_C
            // 
            this.laDISASTER_C.Dock = System.Windows.Forms.DockStyle.Left;
            this.laDISASTER_C.Location = new System.Drawing.Point(171, 0);
            this.laDISASTER_C.Name = "laDISASTER_C";
            this.laDISASTER_C.Size = new System.Drawing.Size(66, 24);
            this.laDISASTER_C.TabIndex = 0;
            this.laDISASTER_C.Text = "灾害等级";
            this.laDISASTER_C.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel53
            // 
            this.panel53.Controls.Add(this.DISPE);
            this.panel53.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel53.Location = new System.Drawing.Point(66, 0);
            this.panel53.Name = "panel53";
            this.panel53.Padding = new System.Windows.Forms.Padding(2, 4, 4, 0);
            this.panel53.Size = new System.Drawing.Size(105, 24);
            this.panel53.TabIndex = 0;
            // 
            // DISPE
            // 
            this.DISPE.AssDispValue = true;
            this.DISPE.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DISPE.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DISPE.ForeColor = System.Drawing.Color.Blue;
            this.DISPE.Location = new System.Drawing.Point(2, 4);
            this.DISPE.Name = "DISPE";
            this.DISPE.Size = new System.Drawing.Size(99, 20);
            this.DISPE.TabIndex = 30;
            this.DISPE.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // laDISPE
            // 
            this.laDISPE.Dock = System.Windows.Forms.DockStyle.Left;
            this.laDISPE.Location = new System.Drawing.Point(0, 0);
            this.laDISPE.Name = "laDISPE";
            this.laDISPE.Size = new System.Drawing.Size(66, 24);
            this.laDISPE.TabIndex = 0;
            this.laDISPE.Text = "灾害类型";
            this.laDISPE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label88
            // 
            this.label88.BackColor = System.Drawing.Color.Black;
            this.label88.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label88.Location = new System.Drawing.Point(0, 24);
            this.label88.Name = "label88";
            this.label88.Size = new System.Drawing.Size(434, 1);
            this.label88.TabIndex = 0;
            this.label88.Text = "label88";
            this.label88.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label90
            // 
            this.label90.BackColor = System.Drawing.Color.Black;
            this.label90.Dock = System.Windows.Forms.DockStyle.Top;
            this.label90.Location = new System.Drawing.Point(1, 0);
            this.label90.Name = "label90";
            this.label90.Size = new System.Drawing.Size(434, 1);
            this.label90.TabIndex = 0;
            this.label90.Text = "label90";
            this.label90.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label91
            // 
            this.label91.BackColor = System.Drawing.Color.Black;
            this.label91.Dock = System.Windows.Forms.DockStyle.Left;
            this.label91.Location = new System.Drawing.Point(0, 0);
            this.label91.Name = "label91";
            this.label91.Size = new System.Drawing.Size(1, 76);
            this.label91.TabIndex = 0;
            this.label91.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label92
            // 
            this.label92.BackColor = System.Drawing.Color.Black;
            this.label92.Dock = System.Windows.Forms.DockStyle.Right;
            this.label92.Location = new System.Drawing.Point(435, 0);
            this.label92.Name = "label92";
            this.label92.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.label92.Size = new System.Drawing.Size(1, 76);
            this.label92.TabIndex = 0;
            this.label92.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label22
            // 
            this.label22.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label22.Location = new System.Drawing.Point(190, 29);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(72, 30);
            this.label22.TabIndex = 0;
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label20
            // 
            this.label20.BackColor = System.Drawing.Color.Black;
            this.label20.Dock = System.Windows.Forms.DockStyle.Left;
            this.label20.Location = new System.Drawing.Point(189, 29);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(1, 30);
            this.label20.TabIndex = 0;
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label19
            // 
            this.label19.Dock = System.Windows.Forms.DockStyle.Left;
            this.label19.Location = new System.Drawing.Point(95, 29);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(94, 30);
            this.label19.TabIndex = 0;
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label14
            // 
            this.label14.BackColor = System.Drawing.Color.Black;
            this.label14.Dock = System.Windows.Forms.DockStyle.Left;
            this.label14.Location = new System.Drawing.Point(94, 29);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(1, 30);
            this.label14.TabIndex = 0;
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.Dock = System.Windows.Forms.DockStyle.Left;
            this.label6.Location = new System.Drawing.Point(0, 29);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(94, 30);
            this.label6.TabIndex = 0;
            this.label6.Text = "树种";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label18
            // 
            this.label18.BackColor = System.Drawing.Color.Black;
            this.label18.Dock = System.Windows.Forms.DockStyle.Top;
            this.label18.Location = new System.Drawing.Point(0, 28);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(262, 1);
            this.label18.TabIndex = 0;
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label15
            // 
            this.label15.Dock = System.Windows.Forms.DockStyle.Top;
            this.label15.Location = new System.Drawing.Point(0, 4);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(262, 24);
            this.label15.TabIndex = 0;
            this.label15.Text = "采  伐  情  况";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label93
            // 
            this.label93.Dock = System.Windows.Forms.DockStyle.Top;
            this.label93.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label93.Location = new System.Drawing.Point(0, 512);
            this.label93.Name = "label93";
            this.label93.Size = new System.Drawing.Size(436, 26);
            this.label93.TabIndex = 0;
            this.label93.Text = "  火灾情况";
            this.label93.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label113
            // 
            this.label113.Dock = System.Windows.Forms.DockStyle.Right;
            this.label113.ForeColor = System.Drawing.Color.Blue;
            this.label113.Location = new System.Drawing.Point(100, 2);
            this.label113.Name = "label113";
            this.label113.Size = new System.Drawing.Size(20, 20);
            this.label113.TabIndex = 0;
            this.label113.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel89
            // 
            this.panel89.Location = new System.Drawing.Point(0, 0);
            this.panel89.Name = "panel89";
            this.panel89.Size = new System.Drawing.Size(200, 100);
            this.panel89.TabIndex = 0;
            // 
            // label171
            // 
            this.label171.Dock = System.Windows.Forms.DockStyle.Left;
            this.label171.Location = new System.Drawing.Point(196, 0);
            this.label171.Name = "label171";
            this.label171.Size = new System.Drawing.Size(66, 24);
            this.label171.TabIndex = 0;
            this.label171.Text = "更新时间";
            this.label171.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label172
            // 
            this.label172.Dock = System.Windows.Forms.DockStyle.Left;
            this.label172.Location = new System.Drawing.Point(0, 0);
            this.label172.Name = "label172";
            this.label172.Size = new System.Drawing.Size(66, 24);
            this.label172.TabIndex = 0;
            this.label172.Text = "更新方式";
            this.label172.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label173
            // 
            this.label173.BackColor = System.Drawing.Color.Black;
            this.label173.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label173.Location = new System.Drawing.Point(0, 24);
            this.label173.Name = "label173";
            this.label173.Size = new System.Drawing.Size(594, 1);
            this.label173.TabIndex = 0;
            this.label173.Text = "label173";
            this.label173.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label43
            // 
            this.label43.Dock = System.Windows.Forms.DockStyle.Top;
            this.label43.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label43.Location = new System.Drawing.Point(0, 208);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(436, 26);
            this.label43.TabIndex = 0;
            this.label43.Text = "  变更情况";
            this.label43.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelOther
            // 
            this.panelOther.Controls.Add(this.panel28);
            this.panelOther.Controls.Add(this.label110);
            this.panelOther.Controls.Add(this.label111);
            this.panelOther.Controls.Add(this.label112);
            this.panelOther.Controls.Add(this.label115);
            this.panelOther.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelOther.Location = new System.Drawing.Point(0, 234);
            this.panelOther.Name = "panelOther";
            this.panelOther.Size = new System.Drawing.Size(436, 26);
            this.panelOther.TabIndex = 0;
            // 
            // panel28
            // 
            this.panel28.Controls.Add(this.panel86);
            this.panel28.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel28.Location = new System.Drawing.Point(1, 1);
            this.panel28.Name = "panel28";
            this.panel28.Size = new System.Drawing.Size(434, 24);
            this.panel28.TabIndex = 0;
            // 
            // panel86
            // 
            this.panel86.Controls.Add(this.panel91);
            this.panel86.Controls.Add(this.laGXSJ);
            this.panel86.Controls.Add(this.panel92);
            this.panel86.Controls.Add(this.laBHYY);
            this.panel86.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel86.Location = new System.Drawing.Point(0, 0);
            this.panel86.Name = "panel86";
            this.panel86.Size = new System.Drawing.Size(434, 25);
            this.panel86.TabIndex = 0;
            // 
            // panel91
            // 
            this.panel91.Controls.Add(this.GXSJ);
            this.panel91.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel91.Location = new System.Drawing.Point(237, 0);
            this.panel91.Name = "panel91";
            this.panel91.Padding = new System.Windows.Forms.Padding(2, 1, 8, 3);
            this.panel91.Size = new System.Drawing.Size(105, 25);
            this.panel91.TabIndex = 0;
            // 
            // GXSJ
            // 
            this.GXSJ.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.GXSJ.EditValue = null;
            this.GXSJ.Location = new System.Drawing.Point(2, 4);
            this.GXSJ.Name = "GXSJ";
            this.GXSJ.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.GXSJ.Properties.Appearance.Options.UseForeColor = true;
            this.GXSJ.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.GXSJ.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.GXSJ.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.GXSJ.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.GXSJ.Size = new System.Drawing.Size(95, 18);
            this.GXSJ.TabIndex = 37;
            this.GXSJ.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // laGXSJ
            // 
            this.laGXSJ.Dock = System.Windows.Forms.DockStyle.Left;
            this.laGXSJ.Location = new System.Drawing.Point(171, 0);
            this.laGXSJ.Name = "laGXSJ";
            this.laGXSJ.Size = new System.Drawing.Size(66, 25);
            this.laGXSJ.TabIndex = 0;
            this.laGXSJ.Text = "更新时间";
            this.laGXSJ.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel92
            // 
            this.panel92.Controls.Add(this.BHYY);
            this.panel92.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel92.Location = new System.Drawing.Point(66, 0);
            this.panel92.Name = "panel92";
            this.panel92.Padding = new System.Windows.Forms.Padding(2, 4, 4, 0);
            this.panel92.Size = new System.Drawing.Size(105, 25);
            this.panel92.TabIndex = 0;
            // 
            // BHYY
            // 
            this.BHYY.AssDispValue = true;
            this.BHYY.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BHYY.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BHYY.ForeColor = System.Drawing.Color.Blue;
            this.BHYY.Location = new System.Drawing.Point(2, 4);
            this.BHYY.Name = "BHYY";
            this.BHYY.Size = new System.Drawing.Size(99, 20);
            this.BHYY.TabIndex = 36;
            this.BHYY.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // laBHYY
            // 
            this.laBHYY.Dock = System.Windows.Forms.DockStyle.Left;
            this.laBHYY.Location = new System.Drawing.Point(0, 0);
            this.laBHYY.Name = "laBHYY";
            this.laBHYY.Size = new System.Drawing.Size(66, 25);
            this.laBHYY.TabIndex = 0;
            this.laBHYY.Text = "变化原因";
            this.laBHYY.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label110
            // 
            this.label110.BackColor = System.Drawing.Color.Black;
            this.label110.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label110.Location = new System.Drawing.Point(1, 25);
            this.label110.Name = "label110";
            this.label110.Size = new System.Drawing.Size(434, 1);
            this.label110.TabIndex = 0;
            this.label110.Text = "label110";
            this.label110.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label111
            // 
            this.label111.BackColor = System.Drawing.Color.Black;
            this.label111.Dock = System.Windows.Forms.DockStyle.Top;
            this.label111.Location = new System.Drawing.Point(1, 0);
            this.label111.Name = "label111";
            this.label111.Size = new System.Drawing.Size(434, 1);
            this.label111.TabIndex = 0;
            this.label111.Text = "label111";
            this.label111.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label112
            // 
            this.label112.BackColor = System.Drawing.Color.Black;
            this.label112.Dock = System.Windows.Forms.DockStyle.Left;
            this.label112.Location = new System.Drawing.Point(0, 0);
            this.label112.Name = "label112";
            this.label112.Size = new System.Drawing.Size(1, 26);
            this.label112.TabIndex = 0;
            this.label112.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label115
            // 
            this.label115.BackColor = System.Drawing.Color.Black;
            this.label115.Dock = System.Windows.Forms.DockStyle.Right;
            this.label115.Location = new System.Drawing.Point(435, 0);
            this.label115.Name = "label115";
            this.label115.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.label115.Size = new System.Drawing.Size(1, 26);
            this.label115.TabIndex = 0;
            this.label115.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.panelFire);
            this.panelControl1.Controls.Add(this.label93);
            this.panelControl1.Controls.Add(this.panelWoodsInfo);
            this.panelControl1.Controls.Add(this.label70);
            this.panelControl1.Controls.Add(this.panelOther);
            this.panelControl1.Controls.Add(this.label43);
            this.panelControl1.Controls.Add(this.panelBasicInfo);
            this.panelControl1.Controls.Add(this.label7);
            this.panelControl1.Controls.Add(this.panel44);
            this.panelControl1.Controls.Add(this.labelTitle);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(2, 2);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(436, 656);
            this.panelControl1.TabIndex = 0;
            // 
            // panel44
            // 
            this.panel44.Controls.Add(this.panel55);
            this.panel44.Controls.Add(this.panel46);
            this.panel44.Controls.Add(this.panelFireNO);
            this.panel44.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel44.Location = new System.Drawing.Point(0, 30);
            this.panel44.Name = "panel44";
            this.panel44.Size = new System.Drawing.Size(436, 76);
            this.panel44.TabIndex = 0;
            // 
            // panel55
            // 
            this.panel55.Controls.Add(this.panel57);
            this.panel55.Controls.Add(this.laQHSJ);
            this.panel55.Controls.Add(this.label66);
            this.panel55.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel55.Location = new System.Drawing.Point(0, 50);
            this.panel55.Name = "panel55";
            this.panel55.Size = new System.Drawing.Size(436, 25);
            this.panel55.TabIndex = 0;
            // 
            // panel57
            // 
            this.panel57.Controls.Add(this.QHSJ);
            this.panel57.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel57.Location = new System.Drawing.Point(56, 0);
            this.panel57.Name = "panel57";
            this.panel57.Padding = new System.Windows.Forms.Padding(2, 1, 8, 3);
            this.panel57.Size = new System.Drawing.Size(140, 24);
            this.panel57.TabIndex = 0;
            // 
            // QHSJ
            // 
            this.QHSJ.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.QHSJ.EditValue = null;
            this.QHSJ.Location = new System.Drawing.Point(2, 3);
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
            this.QHSJ.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.QHSJ.Size = new System.Drawing.Size(130, 18);
            this.QHSJ.TabIndex = 4;
            this.QHSJ.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // laQHSJ
            // 
            this.laQHSJ.Dock = System.Windows.Forms.DockStyle.Left;
            this.laQHSJ.Location = new System.Drawing.Point(0, 0);
            this.laQHSJ.Name = "laQHSJ";
            this.laQHSJ.Size = new System.Drawing.Size(56, 24);
            this.laQHSJ.TabIndex = 0;
            this.laQHSJ.Text = "起火时间";
            this.laQHSJ.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label66
            // 
            this.label66.BackColor = System.Drawing.Color.Black;
            this.label66.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label66.Location = new System.Drawing.Point(0, 24);
            this.label66.Name = "label66";
            this.label66.Size = new System.Drawing.Size(436, 1);
            this.label66.TabIndex = 0;
            this.label66.Text = "label66";
            this.label66.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel46
            // 
            this.panel46.Controls.Add(this.panel51);
            this.panel46.Controls.Add(this.laHZDJ);
            this.panel46.Controls.Add(this.panel54);
            this.panel46.Controls.Add(this.laHZYY);
            this.panel46.Controls.Add(this.label61);
            this.panel46.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel46.Location = new System.Drawing.Point(0, 25);
            this.panel46.Name = "panel46";
            this.panel46.Size = new System.Drawing.Size(436, 25);
            this.panel46.TabIndex = 0;
            // 
            // panel51
            // 
            this.panel51.Controls.Add(this.HZDJ);
            this.panel51.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel51.Location = new System.Drawing.Point(232, 0);
            this.panel51.Name = "panel51";
            this.panel51.Padding = new System.Windows.Forms.Padding(2, 4, 4, 0);
            this.panel51.Size = new System.Drawing.Size(108, 24);
            this.panel51.TabIndex = 0;
            // 
            // HZDJ
            // 
            this.HZDJ.AssDispValue = true;
            this.HZDJ.Cursor = System.Windows.Forms.Cursors.Hand;
            this.HZDJ.Dock = System.Windows.Forms.DockStyle.Fill;
            this.HZDJ.ForeColor = System.Drawing.Color.Blue;
            this.HZDJ.Location = new System.Drawing.Point(2, 4);
            this.HZDJ.Name = "HZDJ";
            this.HZDJ.Size = new System.Drawing.Size(102, 20);
            this.HZDJ.TabIndex = 3;
            this.HZDJ.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // laHZDJ
            // 
            this.laHZDJ.Dock = System.Windows.Forms.DockStyle.Left;
            this.laHZDJ.Location = new System.Drawing.Point(176, 0);
            this.laHZDJ.Name = "laHZDJ";
            this.laHZDJ.Size = new System.Drawing.Size(56, 24);
            this.laHZDJ.TabIndex = 0;
            this.laHZDJ.Text = "火灾等级";
            this.laHZDJ.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel54
            // 
            this.panel54.Controls.Add(this.HZYY);
            this.panel54.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel54.Location = new System.Drawing.Point(56, 0);
            this.panel54.Name = "panel54";
            this.panel54.Padding = new System.Windows.Forms.Padding(2, 4, 4, 0);
            this.panel54.Size = new System.Drawing.Size(120, 24);
            this.panel54.TabIndex = 0;
            // 
            // HZYY
            // 
            this.HZYY.AssDispValue = true;
            this.HZYY.Cursor = System.Windows.Forms.Cursors.Hand;
            this.HZYY.Dock = System.Windows.Forms.DockStyle.Fill;
            this.HZYY.ForeColor = System.Drawing.Color.Blue;
            this.HZYY.Location = new System.Drawing.Point(2, 4);
            this.HZYY.Name = "HZYY";
            this.HZYY.Size = new System.Drawing.Size(114, 20);
            this.HZYY.TabIndex = 2;
            this.HZYY.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // laHZYY
            // 
            this.laHZYY.Dock = System.Windows.Forms.DockStyle.Left;
            this.laHZYY.Location = new System.Drawing.Point(0, 0);
            this.laHZYY.Name = "laHZYY";
            this.laHZYY.Size = new System.Drawing.Size(56, 24);
            this.laHZYY.TabIndex = 0;
            this.laHZYY.Text = "火灾原因";
            this.laHZYY.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label61
            // 
            this.label61.BackColor = System.Drawing.Color.Black;
            this.label61.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label61.Location = new System.Drawing.Point(0, 24);
            this.label61.Name = "label61";
            this.label61.Size = new System.Drawing.Size(436, 1);
            this.label61.TabIndex = 0;
            this.label61.Text = "label61";
            this.label61.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelFireNO
            // 
            this.panelFireNO.Controls.Add(this.panel49);
            this.panelFireNO.Controls.Add(this.laFIRE_NO);
            this.panelFireNO.Controls.Add(this.label62);
            this.panelFireNO.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelFireNO.Location = new System.Drawing.Point(0, 0);
            this.panelFireNO.Name = "panelFireNO";
            this.panelFireNO.Size = new System.Drawing.Size(436, 25);
            this.panelFireNO.TabIndex = 0;
            // 
            // panel49
            // 
            this.panel49.Controls.Add(this.FIRE_NO);
            this.panel49.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel49.Location = new System.Drawing.Point(40, 0);
            this.panel49.Name = "panel49";
            this.panel49.Padding = new System.Windows.Forms.Padding(2, 4, 4, 0);
            this.panel49.Size = new System.Drawing.Size(372, 24);
            this.panel49.TabIndex = 0;
            // 
            // FIRE_NO
            // 
            this.FIRE_NO.AssDispValue = true;
            this.FIRE_NO.Cursor = System.Windows.Forms.Cursors.Hand;
            this.FIRE_NO.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FIRE_NO.ForeColor = System.Drawing.Color.Blue;
            this.FIRE_NO.Location = new System.Drawing.Point(2, 4);
            this.FIRE_NO.Name = "FIRE_NO";
            this.FIRE_NO.Size = new System.Drawing.Size(366, 20);
            this.FIRE_NO.TabIndex = 1;
            this.FIRE_NO.SelectedIndexChanged += new System.EventHandler(this.FIRE_NO_SelectedIndexChanged);
            this.FIRE_NO.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // laFIRE_NO
            // 
            this.laFIRE_NO.Dock = System.Windows.Forms.DockStyle.Left;
            this.laFIRE_NO.Location = new System.Drawing.Point(0, 0);
            this.laFIRE_NO.Name = "laFIRE_NO";
            this.laFIRE_NO.Size = new System.Drawing.Size(40, 24);
            this.laFIRE_NO.TabIndex = 0;
            this.laFIRE_NO.Text = "火灾";
            this.laFIRE_NO.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label62
            // 
            this.label62.BackColor = System.Drawing.Color.Black;
            this.label62.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label62.Location = new System.Drawing.Point(0, 24);
            this.label62.Name = "label62";
            this.label62.Size = new System.Drawing.Size(436, 1);
            this.label62.TabIndex = 0;
            this.label62.Text = "label62";
            this.label62.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // UserControlFireAttr
            // 
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panelControl1);
            this.Name = "UserControlFireAttr";
            this.Padding = new System.Windows.Forms.Padding(2);
            this.Size = new System.Drawing.Size(440, 660);
            this.panelBasicInfo.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel16.ResumeLayout(false);
            this.panel19.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.XI_BAN.Properties)).EndInit();
            this.panel20.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.XIAO_BAN.Properties)).EndInit();
            this.panel12.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.LIN_BAN.Properties)).EndInit();
            this.panel10.ResumeLayout(false);
            this.panel30.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel32.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panelWoodsInfo.ResumeLayout(false);
            this.panel22.ResumeLayout(false);
            this.panel42.ResumeLayout(false);
            this.panel45.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel11.ResumeLayout(false);
            this.panel27.ResumeLayout(false);
            this.panel15.ResumeLayout(false);
            this.panel29.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.YU_BI_DU.Properties)).EndInit();
            this.panel26.ResumeLayout(false);
            this.panel37.ResumeLayout(false);
            this.panel18.ResumeLayout(false);
            this.panel67.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PINGJUN_NL.Properties)).EndInit();
            this.panel31.ResumeLayout(false);
            this.panel33.ResumeLayout(false);
            this.panel34.ResumeLayout(false);
            this.panel41.ResumeLayout(false);
            this.panel35.ResumeLayout(false);
            this.panel43.ResumeLayout(false);
            this.panel21.ResumeLayout(false);
            this.panel24.ResumeLayout(false);
            this.panel25.ResumeLayout(false);
            this.panel100.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.panel23.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel14.ResumeLayout(false);
            this.panel17.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MIAN_JI.Properties)).EndInit();
            this.panelFire.ResumeLayout(false);
            this.panel36.ResumeLayout(false);
            this.panel40.ResumeLayout(false);
            this.panel47.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.BLXJ.Properties)).EndInit();
            this.panel48.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SUNSHIXJ.Properties)).EndInit();
            this.panel13.ResumeLayout(false);
            this.panel38.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SS_ZS.Properties)).EndInit();
            this.panel39.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ZHMJ.Properties)).EndInit();
            this.panel50.ResumeLayout(false);
            this.panel52.ResumeLayout(false);
            this.panel53.ResumeLayout(false);
            this.panelOther.ResumeLayout(false);
            this.panel28.ResumeLayout(false);
            this.panel86.ResumeLayout(false);
            this.panel91.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GXSJ.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GXSJ.Properties)).EndInit();
            this.panel92.ResumeLayout(false);
            this.panelControl1.ResumeLayout(false);
            this.panel44.ResumeLayout(false);
            this.panel55.ResumeLayout(false);
            this.panel57.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.QHSJ.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.QHSJ.Properties)).EndInit();
            this.panel46.ResumeLayout(false);
            this.panel51.ResumeLayout(false);
            this.panel54.ResumeLayout(false);
            this.panelFireNO.ResumeLayout(false);
            this.panel49.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private void Q_SEN_LIN_LB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.Q_SEN_LB.SelectedIndex == this.SEN_LIN_LB.SelectedIndex)
            {
                this.labelLBMess.Visible = false;
            }
        }

        private void SEN_LIN_LB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.Q_SEN_LB.SelectedIndex >= 0)
            {
                if (this.Q_SEN_LB.SelectedIndex != this.SEN_LIN_LB.SelectedIndex)
                {
                    this.labelLBMess.Visible = true;
                }
                else
                {
                    this.labelLBMess.Visible = false;
                }
            }
        }

        private void SHENG_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.SHENG.SelectedIndex <= 0)
            {
                this.SHI.ClearItems();
                this.SHI.AddItem("<空>", "");
                this.SHI.SelectedIndex = 0;
                this.XIAN.ClearItems();
                this.XIAN.AddItem("<空>", "");
                this.XIAN.SelectedIndex = 0;
                this.XIANG.ClearItems();
                this.XIANG.AddItem("<空>", "");
                this.XIANG.SelectedIndex = 0;
                this.CUN.ClearItems();
                this.CUN.AddItem("<空>", "");
                this.CUN.SelectedIndex = 0;
            }
            else
            {
                this.SHI.ItemFilter(this.SHENG.GetSelectedValue());
            }
        }

        private void SHI_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.SHI.SelectedIndex <= 0)
            {
                this.XIAN.ClearItems();
                this.XIAN.AddItem("<空>", "");
                this.XIAN.SelectedIndex = 0;
                this.XIANG.ClearItems();
                this.XIANG.AddItem("<空>", "");
                this.XIANG.SelectedIndex = 0;
                this.CUN.ClearItems();
                this.CUN.AddItem("<空>", "");
                this.CUN.SelectedIndex = 0;
            }
            else
            {
                this.XIAN.ItemFilter(this.SHI.GetSelectedValue());
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

        public bool IsShowed
        {
            set
            {
                this.m_bShow = value;
            }
        }
    }
}

