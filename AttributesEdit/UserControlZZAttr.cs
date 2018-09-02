namespace AttributesEdit
{
    using DevExpress.Utils;
    using DevExpress.XtraEditors;
    using DevExpress.XtraEditors.Controls;
    using DevExpress.XtraEditors.Mask;
    using DevExpress.XtraTab;
    using ESRI.ArcGIS.Geometry;
    using LDZY_ZTZZ;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Reflection;
    using System.Windows.Forms;
    using TaskManage;
    using Utilities;

    public class UserControlZZAttr : UserControl
    {
        private ZLSpinEdit BCFHJ;
        private ZLComboBox BH_DJ;
        private ZLComboBox BHYY;
        private ZLComboBox BSSZ;
        private TextEdit BZ;
        private ComboBoxEdit comboBoxEdit16;
        private IContainer components;
        private ZLComboBox CUN;
        private ZLComboBox DI_LEI;
        private ZLComboBox GJGYL_BHDJ;
        private DateEdit GXSJ;
        private ZLComboBox JJLCQ;
        private DateEdit JLSJ;
        private Label laBCFHJ;
        private Label label1;
        private Label label10;
        private Label label101;
        private Label label103;
        private Label label109;
        private Label label110;
        private Label label111;
        private Label label112;
        private Label label113;
        private Label label114;
        private Label label115;
        private Label label116;
        private Label label119;
        private Label label120;
        private Label label123;
        private Label label127;
        private Label label129;
        private Label label131;
        private Label label132;
        private Label label133;
        private Label label134;
        private Label label135;
        private Label label136;
        private Label label137;
        private Label label138;
        private Label label14;
        private Label label140;
        private Label label143;
        private Label label146;
        private Label label147;
        private Label label149;
        private Label label15;
        private Label label154;
        private Label label162;
        private Label label171;
        private Label label172;
        private Label label173;
        private Label label175;
        private Label label176;
        private Label label177;
        private Label label18;
        private Label label183;
        private Label label19;
        private Label label2;
        private Label label20;
        private Label label21;
        private Label label22;
        private Label label24;
        private Label label25;
        private Label label26;
        private Label label28;
        private Label label29;
        private Label label3;
        private Label label31;
        private Label label32;
        private Label label33;
        private Label label34;
        private Label label35;
        private Label label36;
        private Label label37;
        private Label label4;
        private Label label42;
        private Label label43;
        private Label label47;
        private Label label48;
        private Label label49;
        private Label label50;
        private Label label51;
        private Label label52;
        private Label label53;
        private Label label59;
        private Label label6;
        private Label label61;
        private Label label65;
        private Label label67;
        private Label label68;
        private Label label69;
        private Label label7;
        private Label label70;
        private Label label71;
        private Label label72;
        private Label label74;
        private Label label77;
        private Label label81;
        private Label label82;
        private Label label83;
        private Label label85;
        private Label label86;
        private Label label87;
        private Label label88;
        private Label label90;
        private Label label91;
        private Label label92;
        private Label label93;
        private Label label96;
        private Label label97;
        private Label label98;
        private Label labelLBMess;
        private Label laBH_DJ;
        private Label laBHYY;
        private Label laBSSZ;
        private Label laBZ;
        private Label laCUN;
        private Label laDI_LEI;
        private Label laGJGYL_BHDJ;
        private Label laGXSJ;
        private Label laJJLCQ;
        private Label laLD_QS;
        private Label laLDAZF;
        private Label laLDAZFDJ;
        private Label laLDBCDJ;
        private Label laLDBCF;
        private Label laLDLX;
        private Label laLDYT;
        private Label laLIN_BAN;
        private Label laLIN_ZHONG;
        private Label laLING_ZU;
        private Label laLMBCDJ;
        private Label laLMBCF;
        private Label laLMJYQ;
        private Label laLMSYQ;
        private Label laLYFQ;
        private Label laMEI_GQ_ZS;
        private Label laMIAN_JI;
        private Label laPINGJUN_DM;
        private Label laPINGJUN_NL;
        private Label laPINGJUN_SG;
        private Label laPINGJUN_XJ;
        private Label laQ_DI_LEI;
        private Label laQ_LD_QS;
        private Label laQ_LIN_ZHONG;
        private Label laQ_SEN_LB;
        private Label laQI_YUAN;
        private Label laQYKZ;
        private Label laSEN_LIN_LB;
        private Label laSFTGD;
        private Label laSHENG;
        private Label laSHI;
        private Label laSHI_QUAN_D;
        private Label laSHSJ;
        private Label laSLXJ;
        private Label laSPJB;
        private Label laSPMJ;
        private Label laTDJYQ;
        private Label laTJ_X;
        private Label laTJ_Y;
        private Label laTJMC;
        private Label laXFSS;
        private Label laXI_BAN;
        private Label laXIAN;
        private Label laXIANG;
        private Label laXIAO_BAN;
        private Label laXMBH;
        private Label laXMLX;
        private Label laXZWCD;
        private Label laXZWKD;
        private Label laXZWMJ;
        private Label laXZWZL;
        private Label laYDFW;
        private Label laYDZL;
        private Label laYOU_SHI_SZ;
        private Label laYU_BI_DU;
        private Label laZBHFDJ;
        private Label laZBHFF;
        private Label laZFYHJ;
        private Label laZJFWDX;
        private Label laZL_DJ;
        private Label laZYBM;
        private ZLComboBox LD_QS;
        private ZLSpinEdit LDAZF;
        private ZLSpinEdit LDAZFDJ;
        private ZLSpinEdit LDBCDJ;
        private ZLSpinEdit LDBCF;
        private ZLComboBox LDLX;
        private ZLComboBox LDYT;
        private TextEdit LIN_BAN;
        private ZLComboBox LIN_ZHONG;
        private ZLComboBox LING_ZU;
        private ZLSpinEdit LMBCDJ;
        private ZLSpinEdit LMBCF;
        private ZLComboBox LMJYQ;
        private ZLComboBox LMSYQ;
        private ZLComboBox LYFQ;
        private bool m_bInit;
        private ZLSpinEdit MEI_GQ_ZS;
        private ZLSpinEdit MIAN_JI;
        private Panel panel1;
        private Panel panel10;
        private Panel panel100;
        private Panel panel101;
        private Panel panel102;
        private Panel panel103;
        private Panel panel104;
        private Panel panel105;
        private Panel panel106;
        private Panel panel107;
        private Panel panel108;
        private Panel panel109;
        private Panel panel11;
        private Panel panel110;
        private Panel panel111;
        private Panel panel112;
        private Panel panel113;
        private Panel panel114;
        private Panel panel115;
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
        private Panel panel56;
        private Panel panel57;
        private Panel panel58;
        private Panel panel59;
        private Panel panel6;
        private Panel panel60;
        private Panel panel61;
        private Panel panel62;
        private Panel panel63;
        private Panel panel64;
        private Panel panel65;
        private Panel panel66;
        private Panel panel67;
        private Panel panel68;
        private Panel panel69;
        private Panel panel7;
        private Panel panel70;
        private Panel panel71;
        private Panel panel72;
        private Panel panel73;
        private Panel panel74;
        private Panel panel75;
        private Panel panel76;
        private Panel panel77;
        private Panel panel78;
        private Panel panel79;
        private Panel panel8;
        private Panel panel80;
        private Panel panel81;
        private Panel panel82;
        private Panel panel83;
        private Panel panel84;
        private Panel panel85;
        private Panel panel86;
        private Panel panel87;
        private Panel panel88;
        private Panel panel89;
        private Panel panel9;
        private Panel panel90;
        private Panel panel91;
        private Panel panel92;
        private Panel panel93;
        private Panel panel94;
        private Panel panel95;
        private Panel panel96;
        private Panel panel97;
        private Panel panel98;
        private Panel panel99;
        private Panel panelBasicInfo;
        private Panel panelControl1;
        private Panel panelControl2;
        private Panel panelOther;
        private Panel panelPoint;
        private Panel panelWoodsInfo;
        private Panel panelXZW;
        private Panel panelZZ;
        private ZLSpinEdit PINGJUN_DM;
        private ZLSpinEdit PINGJUN_NL;
        private ZLSpinEdit PINGJUN_SG;
        private ZLSpinEdit PINGJUN_XJ;
        private TextEdit PZWH;
        private ZLComboBox Q_DI_LEI;
        private ZLComboBox Q_LD_QS;
        private ZLComboBox Q_LIN_ZHONG;
        private ZLComboBox Q_SEN_LB;
        private ZLComboBox QI_YUAN;
        private ZLComboBox QYKZ;
        private ZLComboBox SEN_LIN_LB;
        private ZLComboBox SFTGD;
        private ZLComboBox SHENG;
        private ZLComboBox SHI;
        private ZLComboBox SHI_QUAN_D;
        private DateEdit SHSJ;
        private SimpleButton simpleButtonCalcXJ;
        private ZLSpinEdit SLXJ;
        private ZLSpinEdit spinEdit3;
        private ZLComboBox SPJB;
        private ZLSpinEdit SPMJ;
        private ZLComboBox TDJYQ;
        private TextEdit textEdit36;
        private TextEdit textEdit51;
        private TextEdit textEdit52;
        private ZLSpinEdit TJ_X;
        private ZLSpinEdit TJ_Y;
        private TextEdit TJMC;
        private ZLComboBox XFSS;
        private TextEdit XI_BAN;
        private ZLComboBox XIAN;
        private ZLComboBox XIANG;
        private TextEdit XIAO_BAN;
        private ZLComboBox XMLX;
        private TextEdit XMMC;
        private XtraTabControl xtraTabControl1;
        private XtraTabPage xtraTabPage1;
        private XtraTabPage xtraTabPage2;
        private ZLSpinEdit XZWCD;
        private ZLSpinEdit XZWKD;
        private ZLSpinEdit XZWMJ;
        private ZLComboBox XZWZL;
        private ZLComboBox YDFW;
        private ZLComboBox YDZL;
        private ZLComboBox YOU_SHI_SZ;
        private ZLSpinEdit YU_BI_DU;
        private ZLSpinEdit ZBHFDJ;
        private ZLSpinEdit ZBHFF;
        private ZLSpinEdit ZFYHJ;
        private ZLComboBox ZJFWDX;
        private ZLComboBox ZL_DJ;
        private ZLComboBox zlComboBox16;
        private TextEdit ZYBM;

        public UserControlZZAttr()
        {
            this.InitializeComponent();
            this.xtraTabPage1.Appearance.Header.Font = new Font("Tahoma", 9f, FontStyle.Bold);
            this.xtraTabPage1.Appearance.Header.ForeColor = Color.FromArgb(0, 0, 0xc0);
            this.xtraTabPage1.Appearance.Header.Options.UseFont = true;
            this.xtraTabPage1.Appearance.Header.Options.UseForeColor = true;
            this.xtraTabPage2.Appearance.Header.Font = new Font("Tahoma", 9f, FontStyle.Bold);
            this.xtraTabPage2.Appearance.Header.ForeColor = Color.FromArgb(0, 0, 0xc0);
            this.xtraTabPage2.Appearance.Header.Options.UseFont = false;
            this.xtraTabPage2.Appearance.Header.Options.UseForeColor = false;
            this.Q_SEN_LB.SelectedIndexChanged += new EventHandler(this.Q_SEN_LIN_LB_SelectedIndexChanged);
            this.SPMJ.KeyDown += new KeyEventHandler(this.SPMJ_KeyDown);
            this.SPMJ.Leave += new EventHandler(this.SPMJ_Leave);
            this.xtraTabControl1.SelectedPageChanged += new TabPageChangedEventHandler(this.xtraTabControl1_SelectedPageChanged);
        }

        private void CheckSPMJ()
        {
            decimal num = this.MIAN_JI.Value;
            if (num > 0M)
            {
                decimal num2 = this.SPMJ.Value;
                if (num2 > 0M)
                {
                    decimal d = Convert.ToDecimal(UtilFactory.GetConfigOpt().GetConfigValue2("Expropriation", "SPRate"));
                    if (d != 0M)
                    {
                        decimal num4 = num * d;
                        decimal num5 = num * (1M - d);
                        if ((num2 > num4) || (num2 < num5))
                        {
                            MessageBox.Show("审批面积与图上面积相差超过" + (d * 100M) + "%，请重新填写！", "提示");
                            this.SPMJ.Value = 0M;
                        }
                        else if (this.m_bInit)
                        {
                            decimal num7 = this.LDBCDJ.Value * (num2 * 15M);
                            this.LDBCF.Value = Convert.ToDecimal(num7);
                            num7 = this.LDAZFDJ.Value * (num2 * 15M);
                            this.LDAZF.Value = Convert.ToDecimal(num7);
                            num7 = this.LMBCDJ.Value * (num2 * 15M);
                            this.LMBCF.Value = Convert.ToDecimal(num7);
                            decimal num8 = (this.LDBCF.Value + this.LDAZF.Value) + this.LMBCF.Value;
                            this.BCFHJ.Value = num8;
                            num7 = this.ZBHFDJ.Value * (num2 * 10000M);
                            this.ZBHFF.Value = Convert.ToDecimal(num7);
                            num8 = this.BCFHJ.Value + this.ZBHFF.Value;
                            this.ZFYHJ.Value = num8;
                        }
                    }
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
            if (index == 0x31)
            {
                this.xtraTabControl1.SelectedTabPage = this.xtraTabPage2;
            }
            else if (index == 0x4a)
            {
                index = 1;
                this.xtraTabControl1.SelectedTabPage = this.xtraTabPage1;
            }
            Control control = this.GetControl(this, index);
            if (control != null)
            {
                if (control.Enabled && control.Visible)
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
                Control control;
                if (control2 is Panel)
                {
                    control = this.GetControl(control2, index);
                    if (control != null)
                    {
                        return control;
                    }
                }
                else if (control2 is XtraTabControl)
                {
                    control = this.GetControl(control2, index);
                    if (control != null)
                    {
                        return control;
                    }
                }
                else if (control2 is XtraTabPage)
                {
                    control = this.GetControl(control2, index);
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

        public void Init()
        {
            if (EditTask.EditLayer.FeatureClass.ShapeType == esriGeometryType.esriGeometryPolygon)
            {
                this.panelPoint.Visible = false;
                this.panelXZW.Visible = true;
            }
            else
            {
                this.panelPoint.Visible = true;
                this.panelXZW.Visible = false;
            }
            this.m_bInit = true;
        }

        private void InitializeComponent()
        {
            this.panelBasicInfo = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel16 = new System.Windows.Forms.Panel();
            this.panel106 = new System.Windows.Forms.Panel();
            this.XI_BAN = new DevExpress.XtraEditors.TextEdit();
            this.laXI_BAN = new System.Windows.Forms.Label();
            this.panel20 = new System.Windows.Forms.Panel();
            this.XIAO_BAN = new DevExpress.XtraEditors.TextEdit();
            this.laXIAO_BAN = new System.Windows.Forms.Label();
            this.label42 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.LIN_BAN = new DevExpress.XtraEditors.TextEdit();
            this.laLIN_BAN = new System.Windows.Forms.Label();
            this.panel10 = new System.Windows.Forms.Panel();
            this.CUN = new AttributesEdit.ZLComboBox();
            this.laCUN = new System.Windows.Forms.Label();
            this.panel11 = new System.Windows.Forms.Panel();
            this.XIANG = new AttributesEdit.ZLComboBox();
            this.laXIANG = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
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
            this.panel23 = new System.Windows.Forms.Panel();
            this.panel79 = new System.Windows.Forms.Panel();
            this.LYFQ = new AttributesEdit.ZLComboBox();
            this.laLYFQ = new System.Windows.Forms.Label();
            this.panel103 = new System.Windows.Forms.Panel();
            this.QYKZ = new AttributesEdit.ZLComboBox();
            this.laQYKZ = new System.Windows.Forms.Label();
            this.label138 = new System.Windows.Forms.Label();
            this.panel83 = new System.Windows.Forms.Panel();
            this.panel102 = new System.Windows.Forms.Panel();
            this.ZL_DJ = new AttributesEdit.ZLComboBox();
            this.laZL_DJ = new System.Windows.Forms.Label();
            this.panel27 = new System.Windows.Forms.Panel();
            this.GJGYL_BHDJ = new AttributesEdit.ZLComboBox();
            this.laGJGYL_BHDJ = new System.Windows.Forms.Label();
            this.label140 = new System.Windows.Forms.Label();
            this.panel18 = new System.Windows.Forms.Panel();
            this.panel67 = new System.Windows.Forms.Panel();
            this.SHI_QUAN_D = new AttributesEdit.ZLComboBox();
            this.laSHI_QUAN_D = new System.Windows.Forms.Label();
            this.panel19 = new System.Windows.Forms.Panel();
            this.BH_DJ = new AttributesEdit.ZLComboBox();
            this.laBH_DJ = new System.Windows.Forms.Label();
            this.panel42 = new System.Windows.Forms.Panel();
            this.QI_YUAN = new AttributesEdit.ZLComboBox();
            this.laQI_YUAN = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.panel35 = new System.Windows.Forms.Panel();
            this.panel107 = new System.Windows.Forms.Panel();
            this.MEI_GQ_ZS = new AttributesEdit.ZLSpinEdit();
            this.label147 = new System.Windows.Forms.Label();
            this.laMEI_GQ_ZS = new System.Windows.Forms.Label();
            this.panel34 = new System.Windows.Forms.Panel();
            this.PINGJUN_NL = new AttributesEdit.ZLSpinEdit();
            this.label133 = new System.Windows.Forms.Label();
            this.laPINGJUN_NL = new System.Windows.Forms.Label();
            this.panel75 = new System.Windows.Forms.Panel();
            this.LING_ZU = new AttributesEdit.ZLComboBox();
            this.laLING_ZU = new System.Windows.Forms.Label();
            this.label51 = new System.Windows.Forms.Label();
            this.panel105 = new System.Windows.Forms.Panel();
            this.simpleButtonCalcXJ = new DevExpress.XtraEditors.SimpleButton();
            this.panel32 = new System.Windows.Forms.Panel();
            this.SLXJ = new AttributesEdit.ZLSpinEdit();
            this.label82 = new System.Windows.Forms.Label();
            this.laSLXJ = new System.Windows.Forms.Label();
            this.label149 = new System.Windows.Forms.Label();
            this.panel29 = new System.Windows.Forms.Panel();
            this.panel46 = new System.Windows.Forms.Panel();
            this.PINGJUN_DM = new AttributesEdit.ZLSpinEdit();
            this.label34 = new System.Windows.Forms.Label();
            this.laPINGJUN_DM = new System.Windows.Forms.Label();
            this.panel51 = new System.Windows.Forms.Panel();
            this.PINGJUN_SG = new AttributesEdit.ZLSpinEdit();
            this.label134 = new System.Windows.Forms.Label();
            this.laPINGJUN_SG = new System.Windows.Forms.Label();
            this.panel30 = new System.Windows.Forms.Panel();
            this.PINGJUN_XJ = new AttributesEdit.ZLSpinEdit();
            this.label25 = new System.Windows.Forms.Label();
            this.laPINGJUN_XJ = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.panel31 = new System.Windows.Forms.Panel();
            this.panel43 = new System.Windows.Forms.Panel();
            this.YU_BI_DU = new AttributesEdit.ZLSpinEdit();
            this.label52 = new System.Windows.Forms.Label();
            this.laYU_BI_DU = new System.Windows.Forms.Label();
            this.panel104 = new System.Windows.Forms.Panel();
            this.SPMJ = new AttributesEdit.ZLSpinEdit();
            this.label146 = new System.Windows.Forms.Label();
            this.laSPMJ = new System.Windows.Forms.Label();
            this.panel33 = new System.Windows.Forms.Panel();
            this.MIAN_JI = new AttributesEdit.ZLSpinEdit();
            this.label32 = new System.Windows.Forms.Label();
            this.laMIAN_JI = new System.Windows.Forms.Label();
            this.label59 = new System.Windows.Forms.Label();
            this.panel41 = new System.Windows.Forms.Panel();
            this.panel73 = new System.Windows.Forms.Panel();
            this.JJLCQ = new AttributesEdit.ZLComboBox();
            this.laJJLCQ = new System.Windows.Forms.Label();
            this.panel66 = new System.Windows.Forms.Panel();
            this.BSSZ = new AttributesEdit.ZLComboBox();
            this.laBSSZ = new System.Windows.Forms.Label();
            this.panel44 = new System.Windows.Forms.Panel();
            this.YOU_SHI_SZ = new AttributesEdit.ZLComboBox();
            this.laYOU_SHI_SZ = new System.Windows.Forms.Label();
            this.label65 = new System.Windows.Forms.Label();
            this.panel14 = new System.Windows.Forms.Panel();
            this.panel38 = new System.Windows.Forms.Panel();
            this.LMSYQ = new AttributesEdit.ZLComboBox();
            this.laLMSYQ = new System.Windows.Forms.Label();
            this.panel40 = new System.Windows.Forms.Panel();
            this.LMJYQ = new AttributesEdit.ZLComboBox();
            this.laLMJYQ = new System.Windows.Forms.Label();
            this.panel47 = new System.Windows.Forms.Panel();
            this.TDJYQ = new AttributesEdit.ZLComboBox();
            this.laTDJYQ = new System.Windows.Forms.Label();
            this.label114 = new System.Windows.Forms.Label();
            this.panel100 = new System.Windows.Forms.Panel();
            this.panel26 = new System.Windows.Forms.Panel();
            this.LIN_ZHONG = new AttributesEdit.ZLComboBox();
            this.laLIN_ZHONG = new System.Windows.Forms.Label();
            this.panel9 = new System.Windows.Forms.Panel();
            this.Q_LIN_ZHONG = new AttributesEdit.ZLComboBox();
            this.laQ_LIN_ZHONG = new System.Windows.Forms.Label();
            this.label162 = new System.Windows.Forms.Label();
            this.panel93 = new System.Windows.Forms.Panel();
            this.panel97 = new System.Windows.Forms.Panel();
            this.DI_LEI = new AttributesEdit.ZLComboBox();
            this.laDI_LEI = new System.Windows.Forms.Label();
            this.panel101 = new System.Windows.Forms.Panel();
            this.Q_DI_LEI = new AttributesEdit.ZLComboBox();
            this.laQ_DI_LEI = new System.Windows.Forms.Label();
            this.label143 = new System.Windows.Forms.Label();
            this.panel21 = new System.Windows.Forms.Panel();
            this.panel24 = new System.Windows.Forms.Panel();
            this.LD_QS = new AttributesEdit.ZLComboBox();
            this.laLD_QS = new System.Windows.Forms.Label();
            this.panel25 = new System.Windows.Forms.Panel();
            this.Q_LD_QS = new AttributesEdit.ZLComboBox();
            this.laQ_LD_QS = new System.Windows.Forms.Label();
            this.label47 = new System.Windows.Forms.Label();
            this.panel37 = new System.Windows.Forms.Panel();
            this.labelLBMess = new System.Windows.Forms.Label();
            this.panel50 = new System.Windows.Forms.Panel();
            this.SEN_LIN_LB = new AttributesEdit.ZLComboBox();
            this.laSEN_LIN_LB = new System.Windows.Forms.Label();
            this.panel70 = new System.Windows.Forms.Panel();
            this.Q_SEN_LB = new AttributesEdit.ZLComboBox();
            this.laQ_SEN_LB = new System.Windows.Forms.Label();
            this.label183 = new System.Windows.Forms.Label();
            this.label67 = new System.Windows.Forms.Label();
            this.label68 = new System.Windows.Forms.Label();
            this.label69 = new System.Windows.Forms.Label();
            this.label70 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label103 = new System.Windows.Forms.Label();
            this.panelXZW = new System.Windows.Forms.Panel();
            this.panel108 = new System.Windows.Forms.Panel();
            this.panel72 = new System.Windows.Forms.Panel();
            this.panel17 = new System.Windows.Forms.Panel();
            this.XZWKD = new AttributesEdit.ZLSpinEdit();
            this.label137 = new System.Windows.Forms.Label();
            this.laXZWKD = new System.Windows.Forms.Label();
            this.panel59 = new System.Windows.Forms.Panel();
            this.XZWCD = new AttributesEdit.ZLSpinEdit();
            this.label136 = new System.Windows.Forms.Label();
            this.laXZWCD = new System.Windows.Forms.Label();
            this.label109 = new System.Windows.Forms.Label();
            this.panel88 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.XZWMJ = new AttributesEdit.ZLSpinEdit();
            this.label135 = new System.Windows.Forms.Label();
            this.laXZWMJ = new System.Windows.Forms.Label();
            this.panel12 = new System.Windows.Forms.Panel();
            this.XZWZL = new AttributesEdit.ZLComboBox();
            this.laXZWZL = new System.Windows.Forms.Label();
            this.label98 = new System.Windows.Forms.Label();
            this.label175 = new System.Windows.Forms.Label();
            this.label176 = new System.Windows.Forms.Label();
            this.label177 = new System.Windows.Forms.Label();
            this.spinEdit3 = new AttributesEdit.ZLSpinEdit();
            this.textEdit36 = new DevExpress.XtraEditors.TextEdit();
            this.label113 = new System.Windows.Forms.Label();
            this.panel89 = new System.Windows.Forms.Panel();
            this.textEdit51 = new DevExpress.XtraEditors.TextEdit();
            this.label171 = new System.Windows.Forms.Label();
            this.panel90 = new System.Windows.Forms.Panel();
            this.comboBoxEdit16 = new DevExpress.XtraEditors.ComboBoxEdit();
            this.textEdit52 = new DevExpress.XtraEditors.TextEdit();
            this.label172 = new System.Windows.Forms.Label();
            this.label173 = new System.Windows.Forms.Label();
            this.panelPoint = new System.Windows.Forms.Panel();
            this.panel52 = new System.Windows.Forms.Panel();
            this.panel57 = new System.Windows.Forms.Panel();
            this.TJ_Y = new AttributesEdit.ZLSpinEdit();
            this.label132 = new System.Windows.Forms.Label();
            this.laTJ_Y = new System.Windows.Forms.Label();
            this.panel61 = new System.Windows.Forms.Panel();
            this.TJ_X = new AttributesEdit.ZLSpinEdit();
            this.label83 = new System.Windows.Forms.Label();
            this.laTJ_X = new System.Windows.Forms.Label();
            this.label131 = new System.Windows.Forms.Label();
            this.panel71 = new System.Windows.Forms.Panel();
            this.panel74 = new System.Windows.Forms.Panel();
            this.TJMC = new DevExpress.XtraEditors.TextEdit();
            this.laTJMC = new System.Windows.Forms.Label();
            this.label85 = new System.Windows.Forms.Label();
            this.label50 = new System.Windows.Forms.Label();
            this.label49 = new System.Windows.Forms.Label();
            this.label48 = new System.Windows.Forms.Label();
            this.label43 = new System.Windows.Forms.Label();
            this.panelOther = new System.Windows.Forms.Panel();
            this.label53 = new System.Windows.Forms.Label();
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
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.panelControl1 = new System.Windows.Forms.Panel();
            this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
            this.panelControl2 = new System.Windows.Forms.Panel();
            this.panelZZ = new System.Windows.Forms.Panel();
            this.panel36 = new System.Windows.Forms.Panel();
            this.panel15 = new System.Windows.Forms.Panel();
            this.panel28 = new System.Windows.Forms.Panel();
            this.BZ = new DevExpress.XtraEditors.TextEdit();
            this.laBZ = new System.Windows.Forms.Label();
            this.label74 = new System.Windows.Forms.Label();
            this.panel96 = new System.Windows.Forms.Panel();
            this.panel99 = new System.Windows.Forms.Panel();
            this.ZFYHJ = new AttributesEdit.ZLSpinEdit();
            this.label28 = new System.Windows.Forms.Label();
            this.laZFYHJ = new System.Windows.Forms.Label();
            this.label127 = new System.Windows.Forms.Label();
            this.panel87 = new System.Windows.Forms.Panel();
            this.panel94 = new System.Windows.Forms.Panel();
            this.ZBHFF = new AttributesEdit.ZLSpinEdit();
            this.label97 = new System.Windows.Forms.Label();
            this.laZBHFF = new System.Windows.Forms.Label();
            this.panel95 = new System.Windows.Forms.Panel();
            this.ZBHFDJ = new AttributesEdit.ZLSpinEdit();
            this.label72 = new System.Windows.Forms.Label();
            this.laZBHFDJ = new System.Windows.Forms.Label();
            this.label123 = new System.Windows.Forms.Label();
            this.panel49 = new System.Windows.Forms.Panel();
            this.panel98 = new System.Windows.Forms.Panel();
            this.BCFHJ = new AttributesEdit.ZLSpinEdit();
            this.label116 = new System.Windows.Forms.Label();
            this.zlComboBox16 = new AttributesEdit.ZLComboBox();
            this.laBCFHJ = new System.Windows.Forms.Label();
            this.label120 = new System.Windows.Forms.Label();
            this.panel82 = new System.Windows.Forms.Panel();
            this.panel84 = new System.Windows.Forms.Panel();
            this.LMBCF = new AttributesEdit.ZLSpinEdit();
            this.label88 = new System.Windows.Forms.Label();
            this.laLMBCF = new System.Windows.Forms.Label();
            this.panel85 = new System.Windows.Forms.Panel();
            this.LMBCDJ = new AttributesEdit.ZLSpinEdit();
            this.label31 = new System.Windows.Forms.Label();
            this.laLMBCDJ = new System.Windows.Forms.Label();
            this.label119 = new System.Windows.Forms.Label();
            this.panel78 = new System.Windows.Forms.Panel();
            this.panel80 = new System.Windows.Forms.Panel();
            this.LDAZF = new AttributesEdit.ZLSpinEdit();
            this.label87 = new System.Windows.Forms.Label();
            this.laLDAZF = new System.Windows.Forms.Label();
            this.panel81 = new System.Windows.Forms.Panel();
            this.LDAZFDJ = new AttributesEdit.ZLSpinEdit();
            this.label29 = new System.Windows.Forms.Label();
            this.laLDAZFDJ = new System.Windows.Forms.Label();
            this.label101 = new System.Windows.Forms.Label();
            this.panel69 = new System.Windows.Forms.Panel();
            this.panel76 = new System.Windows.Forms.Panel();
            this.LDBCF = new AttributesEdit.ZLSpinEdit();
            this.label86 = new System.Windows.Forms.Label();
            this.laLDBCF = new System.Windows.Forms.Label();
            this.panel77 = new System.Windows.Forms.Panel();
            this.LDBCDJ = new AttributesEdit.ZLSpinEdit();
            this.label26 = new System.Windows.Forms.Label();
            this.laLDBCDJ = new System.Windows.Forms.Label();
            this.label96 = new System.Windows.Forms.Label();
            this.panel13 = new System.Windows.Forms.Panel();
            this.panel112 = new System.Windows.Forms.Panel();
            this.ZJFWDX = new AttributesEdit.ZLComboBox();
            this.laZJFWDX = new System.Windows.Forms.Label();
            this.panel110 = new System.Windows.Forms.Panel();
            this.SPJB = new AttributesEdit.ZLComboBox();
            this.laSPJB = new System.Windows.Forms.Label();
            this.panel39 = new System.Windows.Forms.Panel();
            this.SHSJ = new DevExpress.XtraEditors.DateEdit();
            this.laSHSJ = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.panel109 = new System.Windows.Forms.Panel();
            this.panel115 = new System.Windows.Forms.Panel();
            this.JLSJ = new DevExpress.XtraEditors.DateEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.panel111 = new System.Windows.Forms.Panel();
            this.YDFW = new AttributesEdit.ZLComboBox();
            this.laYDFW = new System.Windows.Forms.Label();
            this.label154 = new System.Windows.Forms.Label();
            this.panel64 = new System.Windows.Forms.Panel();
            this.panel65 = new System.Windows.Forms.Panel();
            this.SFTGD = new AttributesEdit.ZLComboBox();
            this.laSFTGD = new System.Windows.Forms.Label();
            this.panel68 = new System.Windows.Forms.Panel();
            this.YDZL = new AttributesEdit.ZLComboBox();
            this.laYDZL = new System.Windows.Forms.Label();
            this.label81 = new System.Windows.Forms.Label();
            this.panel60 = new System.Windows.Forms.Panel();
            this.panel62 = new System.Windows.Forms.Panel();
            this.LDYT = new AttributesEdit.ZLComboBox();
            this.laLDYT = new System.Windows.Forms.Label();
            this.panel63 = new System.Windows.Forms.Panel();
            this.LDLX = new AttributesEdit.ZLComboBox();
            this.laLDLX = new System.Windows.Forms.Label();
            this.label77 = new System.Windows.Forms.Label();
            this.panel45 = new System.Windows.Forms.Panel();
            this.panel48 = new System.Windows.Forms.Panel();
            this.ZYBM = new DevExpress.XtraEditors.TextEdit();
            this.laZYBM = new System.Windows.Forms.Label();
            this.label129 = new System.Windows.Forms.Label();
            this.panel54 = new System.Windows.Forms.Panel();
            this.panel56 = new System.Windows.Forms.Panel();
            this.XFSS = new AttributesEdit.ZLComboBox();
            this.laXFSS = new System.Windows.Forms.Label();
            this.panel58 = new System.Windows.Forms.Panel();
            this.XMLX = new AttributesEdit.ZLComboBox();
            this.laXMLX = new System.Windows.Forms.Label();
            this.label71 = new System.Windows.Forms.Label();
            this.panel113 = new System.Windows.Forms.Panel();
            this.panel114 = new System.Windows.Forms.Panel();
            this.PZWH = new DevExpress.XtraEditors.TextEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel53 = new System.Windows.Forms.Panel();
            this.panel55 = new System.Windows.Forms.Panel();
            this.XMMC = new DevExpress.XtraEditors.TextEdit();
            this.laXMBH = new System.Windows.Forms.Label();
            this.label61 = new System.Windows.Forms.Label();
            this.label90 = new System.Windows.Forms.Label();
            this.label91 = new System.Windows.Forms.Label();
            this.label92 = new System.Windows.Forms.Label();
            this.label93 = new System.Windows.Forms.Label();
            this.panelBasicInfo.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel16.SuspendLayout();
            this.panel106.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.XI_BAN.Properties)).BeginInit();
            this.panel20.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.XIAO_BAN.Properties)).BeginInit();
            this.panel7.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LIN_BAN.Properties)).BeginInit();
            this.panel10.SuspendLayout();
            this.panel11.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panelWoodsInfo.SuspendLayout();
            this.panel22.SuspendLayout();
            this.panel23.SuspendLayout();
            this.panel79.SuspendLayout();
            this.panel103.SuspendLayout();
            this.panel83.SuspendLayout();
            this.panel102.SuspendLayout();
            this.panel27.SuspendLayout();
            this.panel18.SuspendLayout();
            this.panel67.SuspendLayout();
            this.panel19.SuspendLayout();
            this.panel42.SuspendLayout();
            this.panel35.SuspendLayout();
            this.panel107.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MEI_GQ_ZS.Properties)).BeginInit();
            this.panel34.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PINGJUN_NL.Properties)).BeginInit();
            this.panel75.SuspendLayout();
            this.panel105.SuspendLayout();
            this.panel32.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SLXJ.Properties)).BeginInit();
            this.panel29.SuspendLayout();
            this.panel46.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PINGJUN_DM.Properties)).BeginInit();
            this.panel51.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PINGJUN_SG.Properties)).BeginInit();
            this.panel30.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PINGJUN_XJ.Properties)).BeginInit();
            this.panel31.SuspendLayout();
            this.panel43.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.YU_BI_DU.Properties)).BeginInit();
            this.panel104.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SPMJ.Properties)).BeginInit();
            this.panel33.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MIAN_JI.Properties)).BeginInit();
            this.panel41.SuspendLayout();
            this.panel73.SuspendLayout();
            this.panel66.SuspendLayout();
            this.panel44.SuspendLayout();
            this.panel14.SuspendLayout();
            this.panel38.SuspendLayout();
            this.panel40.SuspendLayout();
            this.panel47.SuspendLayout();
            this.panel100.SuspendLayout();
            this.panel26.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel93.SuspendLayout();
            this.panel97.SuspendLayout();
            this.panel101.SuspendLayout();
            this.panel21.SuspendLayout();
            this.panel24.SuspendLayout();
            this.panel25.SuspendLayout();
            this.panel37.SuspendLayout();
            this.panel50.SuspendLayout();
            this.panel70.SuspendLayout();
            this.panelXZW.SuspendLayout();
            this.panel108.SuspendLayout();
            this.panel72.SuspendLayout();
            this.panel17.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.XZWKD.Properties)).BeginInit();
            this.panel59.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.XZWCD.Properties)).BeginInit();
            this.panel88.SuspendLayout();
            this.panel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.XZWMJ.Properties)).BeginInit();
            this.panel12.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit3.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit36.Properties)).BeginInit();
            this.panel89.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit51.Properties)).BeginInit();
            this.panel90.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit16.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit52.Properties)).BeginInit();
            this.panelPoint.SuspendLayout();
            this.panel52.SuspendLayout();
            this.panel57.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TJ_Y.Properties)).BeginInit();
            this.panel61.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TJ_X.Properties)).BeginInit();
            this.panel71.SuspendLayout();
            this.panel74.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TJMC.Properties)).BeginInit();
            this.panelOther.SuspendLayout();
            this.panel86.SuspendLayout();
            this.panel91.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GXSJ.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GXSJ.Properties)).BeginInit();
            this.panel92.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
            this.panelControl1.SuspendLayout();
            this.xtraTabPage2.SuspendLayout();
            this.panelControl2.SuspendLayout();
            this.panelZZ.SuspendLayout();
            this.panel36.SuspendLayout();
            this.panel15.SuspendLayout();
            this.panel28.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BZ.Properties)).BeginInit();
            this.panel96.SuspendLayout();
            this.panel99.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ZFYHJ.Properties)).BeginInit();
            this.panel87.SuspendLayout();
            this.panel94.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ZBHFF.Properties)).BeginInit();
            this.panel95.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ZBHFDJ.Properties)).BeginInit();
            this.panel49.SuspendLayout();
            this.panel98.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BCFHJ.Properties)).BeginInit();
            this.panel82.SuspendLayout();
            this.panel84.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LMBCF.Properties)).BeginInit();
            this.panel85.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LMBCDJ.Properties)).BeginInit();
            this.panel78.SuspendLayout();
            this.panel80.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LDAZF.Properties)).BeginInit();
            this.panel81.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LDAZFDJ.Properties)).BeginInit();
            this.panel69.SuspendLayout();
            this.panel76.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LDBCF.Properties)).BeginInit();
            this.panel77.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LDBCDJ.Properties)).BeginInit();
            this.panel13.SuspendLayout();
            this.panel112.SuspendLayout();
            this.panel110.SuspendLayout();
            this.panel39.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SHSJ.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SHSJ.Properties)).BeginInit();
            this.panel109.SuspendLayout();
            this.panel115.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.JLSJ.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.JLSJ.Properties)).BeginInit();
            this.panel111.SuspendLayout();
            this.panel64.SuspendLayout();
            this.panel65.SuspendLayout();
            this.panel68.SuspendLayout();
            this.panel60.SuspendLayout();
            this.panel62.SuspendLayout();
            this.panel63.SuspendLayout();
            this.panel45.SuspendLayout();
            this.panel48.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ZYBM.Properties)).BeginInit();
            this.panel54.SuspendLayout();
            this.panel56.SuspendLayout();
            this.panel58.SuspendLayout();
            this.panel113.SuspendLayout();
            this.panel114.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PZWH.Properties)).BeginInit();
            this.panel53.SuspendLayout();
            this.panel55.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.XMMC.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panelBasicInfo
            // 
            this.panelBasicInfo.Controls.Add(this.panel1);
            this.panelBasicInfo.Controls.Add(this.label35);
            this.panelBasicInfo.Controls.Add(this.label36);
            this.panelBasicInfo.Controls.Add(this.label37);
            this.panelBasicInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelBasicInfo.Location = new System.Drawing.Point(0, 26);
            this.panelBasicInfo.Name = "panelBasicInfo";
            this.panelBasicInfo.Size = new System.Drawing.Size(440, 76);
            this.panelBasicInfo.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel16);
            this.panel1.Controls.Add(this.panel7);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(1, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(438, 75);
            this.panel1.TabIndex = 0;
            // 
            // panel16
            // 
            this.panel16.Controls.Add(this.panel106);
            this.panel16.Controls.Add(this.laXI_BAN);
            this.panel16.Controls.Add(this.panel20);
            this.panel16.Controls.Add(this.laXIAO_BAN);
            this.panel16.Controls.Add(this.label42);
            this.panel16.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel16.Location = new System.Drawing.Point(0, 50);
            this.panel16.Name = "panel16";
            this.panel16.Size = new System.Drawing.Size(438, 25);
            this.panel16.TabIndex = 0;
            // 
            // panel106
            // 
            this.panel106.Controls.Add(this.XI_BAN);
            this.panel106.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel106.Location = new System.Drawing.Point(196, 0);
            this.panel106.Name = "panel106";
            this.panel106.Padding = new System.Windows.Forms.Padding(2, 6, 8, 0);
            this.panel106.Size = new System.Drawing.Size(90, 24);
            this.panel106.TabIndex = 0;
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
            this.XI_BAN.Size = new System.Drawing.Size(80, 16);
            this.XI_BAN.TabIndex = 8;
            this.XI_BAN.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // laXI_BAN
            // 
            this.laXI_BAN.Dock = System.Windows.Forms.DockStyle.Left;
            this.laXI_BAN.Location = new System.Drawing.Point(143, 0);
            this.laXI_BAN.Name = "laXI_BAN";
            this.laXI_BAN.Size = new System.Drawing.Size(53, 24);
            this.laXI_BAN.TabIndex = 0;
            this.laXI_BAN.Text = "细班";
            this.laXI_BAN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel20
            // 
            this.panel20.Controls.Add(this.XIAO_BAN);
            this.panel20.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel20.Location = new System.Drawing.Point(53, 0);
            this.panel20.Name = "panel20";
            this.panel20.Padding = new System.Windows.Forms.Padding(2, 6, 8, 0);
            this.panel20.Size = new System.Drawing.Size(90, 24);
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
            this.XIAO_BAN.Size = new System.Drawing.Size(80, 16);
            this.XIAO_BAN.TabIndex = 7;
            this.XIAO_BAN.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // laXIAO_BAN
            // 
            this.laXIAO_BAN.Dock = System.Windows.Forms.DockStyle.Left;
            this.laXIAO_BAN.Location = new System.Drawing.Point(0, 0);
            this.laXIAO_BAN.Name = "laXIAO_BAN";
            this.laXIAO_BAN.Size = new System.Drawing.Size(53, 24);
            this.laXIAO_BAN.TabIndex = 0;
            this.laXIAO_BAN.Text = "小班号";
            this.laXIAO_BAN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label42
            // 
            this.label42.BackColor = System.Drawing.Color.Black;
            this.label42.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label42.Location = new System.Drawing.Point(0, 24);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(438, 1);
            this.label42.TabIndex = 0;
            this.label42.Text = "label42";
            this.label42.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.panel6);
            this.panel7.Controls.Add(this.laLIN_BAN);
            this.panel7.Controls.Add(this.panel10);
            this.panel7.Controls.Add(this.laCUN);
            this.panel7.Controls.Add(this.panel11);
            this.panel7.Controls.Add(this.laXIANG);
            this.panel7.Controls.Add(this.label10);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel7.Location = new System.Drawing.Point(0, 25);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(438, 25);
            this.panel7.TabIndex = 0;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.LIN_BAN);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel6.Location = new System.Drawing.Point(323, 0);
            this.panel6.Name = "panel6";
            this.panel6.Padding = new System.Windows.Forms.Padding(2, 6, 8, 0);
            this.panel6.Size = new System.Drawing.Size(105, 24);
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
            this.LIN_BAN.Size = new System.Drawing.Size(95, 16);
            this.LIN_BAN.TabIndex = 6;
            this.LIN_BAN.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // laLIN_BAN
            // 
            this.laLIN_BAN.Dock = System.Windows.Forms.DockStyle.Left;
            this.laLIN_BAN.Location = new System.Drawing.Point(286, 0);
            this.laLIN_BAN.Name = "laLIN_BAN";
            this.laLIN_BAN.Size = new System.Drawing.Size(37, 24);
            this.laLIN_BAN.TabIndex = 0;
            this.laLIN_BAN.Text = "林班";
            this.laLIN_BAN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel10
            // 
            this.panel10.Controls.Add(this.CUN);
            this.panel10.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel10.Location = new System.Drawing.Point(196, 0);
            this.panel10.Name = "panel10";
            this.panel10.Padding = new System.Windows.Forms.Padding(2, 4, 4, 0);
            this.panel10.Size = new System.Drawing.Size(90, 24);
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
            this.CUN.Size = new System.Drawing.Size(84, 20);
            this.CUN.TabIndex = 5;
            this.CUN.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // laCUN
            // 
            this.laCUN.Dock = System.Windows.Forms.DockStyle.Left;
            this.laCUN.Location = new System.Drawing.Point(143, 0);
            this.laCUN.Name = "laCUN";
            this.laCUN.Size = new System.Drawing.Size(53, 24);
            this.laCUN.TabIndex = 0;
            this.laCUN.Text = "村";
            this.laCUN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel11
            // 
            this.panel11.Controls.Add(this.XIANG);
            this.panel11.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel11.Location = new System.Drawing.Point(53, 0);
            this.panel11.Name = "panel11";
            this.panel11.Padding = new System.Windows.Forms.Padding(2, 4, 4, 0);
            this.panel11.Size = new System.Drawing.Size(90, 24);
            this.panel11.TabIndex = 0;
            // 
            // XIANG
            // 
            this.XIANG.AssDispValue = true;
            this.XIANG.Cursor = System.Windows.Forms.Cursors.Hand;
            this.XIANG.Dock = System.Windows.Forms.DockStyle.Fill;
            this.XIANG.ForeColor = System.Drawing.Color.Blue;
            this.XIANG.Location = new System.Drawing.Point(2, 4);
            this.XIANG.Name = "XIANG";
            this.XIANG.Size = new System.Drawing.Size(84, 20);
            this.XIANG.TabIndex = 4;
            this.XIANG.SelectedIndexChanged += new System.EventHandler(this.XIANG_SelectedIndexChanged);
            this.XIANG.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // laXIANG
            // 
            this.laXIANG.Dock = System.Windows.Forms.DockStyle.Left;
            this.laXIANG.Location = new System.Drawing.Point(0, 0);
            this.laXIANG.Name = "laXIANG";
            this.laXIANG.Size = new System.Drawing.Size(53, 24);
            this.laXIANG.TabIndex = 0;
            this.laXIANG.Text = "乡镇";
            this.laXIANG.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.Black;
            this.label10.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label10.Location = new System.Drawing.Point(0, 24);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(438, 1);
            this.label10.TabIndex = 0;
            this.label10.Text = "label10";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Controls.Add(this.laXIAN);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.laSHI);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.laSHENG);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(438, 25);
            this.panel2.TabIndex = 0;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.XIAN);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel5.Location = new System.Drawing.Point(323, 0);
            this.panel5.Name = "panel5";
            this.panel5.Padding = new System.Windows.Forms.Padding(2, 4, 4, 0);
            this.panel5.Size = new System.Drawing.Size(105, 24);
            this.panel5.TabIndex = 0;
            this.panel5.TabStop = true;
            // 
            // XIAN
            // 
            this.XIAN.AssDispValue = true;
            this.XIAN.Cursor = System.Windows.Forms.Cursors.Hand;
            this.XIAN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.XIAN.ForeColor = System.Drawing.Color.Blue;
            this.XIAN.Location = new System.Drawing.Point(2, 4);
            this.XIAN.Name = "XIAN";
            this.XIAN.Size = new System.Drawing.Size(99, 20);
            this.XIAN.TabIndex = 3;
            this.XIAN.SelectedIndexChanged += new System.EventHandler(this.XIAN_SelectedIndexChanged);
            this.XIAN.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // laXIAN
            // 
            this.laXIAN.Dock = System.Windows.Forms.DockStyle.Left;
            this.laXIAN.Location = new System.Drawing.Point(286, 0);
            this.laXIAN.Name = "laXIAN";
            this.laXIAN.Size = new System.Drawing.Size(37, 24);
            this.laXIAN.TabIndex = 0;
            this.laXIAN.Text = "区县";
            this.laXIAN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.SHI);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel4.Location = new System.Drawing.Point(196, 0);
            this.panel4.Name = "panel4";
            this.panel4.Padding = new System.Windows.Forms.Padding(2, 4, 4, 0);
            this.panel4.Size = new System.Drawing.Size(90, 24);
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
            this.SHI.Size = new System.Drawing.Size(84, 20);
            this.SHI.TabIndex = 2;
            this.SHI.SelectedIndexChanged += new System.EventHandler(this.SHI_SelectedIndexChanged);
            this.SHI.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // laSHI
            // 
            this.laSHI.Dock = System.Windows.Forms.DockStyle.Left;
            this.laSHI.Location = new System.Drawing.Point(143, 0);
            this.laSHI.Name = "laSHI";
            this.laSHI.Size = new System.Drawing.Size(53, 24);
            this.laSHI.TabIndex = 0;
            this.laSHI.Text = "市";
            this.laSHI.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.SHENG);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(43, 0);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(2, 4, 4, 0);
            this.panel3.Size = new System.Drawing.Size(100, 24);
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
            this.SHENG.Size = new System.Drawing.Size(94, 20);
            this.SHENG.TabIndex = 1;
            this.SHENG.SelectedIndexChanged += new System.EventHandler(this.SHENG_SelectedIndexChanged);
            this.SHENG.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // laSHENG
            // 
            this.laSHENG.Dock = System.Windows.Forms.DockStyle.Left;
            this.laSHENG.Location = new System.Drawing.Point(0, 0);
            this.laSHENG.Name = "laSHENG";
            this.laSHENG.Size = new System.Drawing.Size(43, 24);
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
            this.label2.Size = new System.Drawing.Size(438, 1);
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
            this.label35.Size = new System.Drawing.Size(438, 1);
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
            this.label37.Location = new System.Drawing.Point(439, 0);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(1, 76);
            this.label37.TabIndex = 0;
            this.label37.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.Dock = System.Windows.Forms.DockStyle.Top;
            this.label7.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(0, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(440, 26);
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
            this.panelWoodsInfo.Location = new System.Drawing.Point(0, 180);
            this.panelWoodsInfo.Name = "panelWoodsInfo";
            this.panelWoodsInfo.Size = new System.Drawing.Size(440, 326);
            this.panelWoodsInfo.TabIndex = 0;
            // 
            // panel22
            // 
            this.panel22.Controls.Add(this.panel23);
            this.panel22.Controls.Add(this.panel83);
            this.panel22.Controls.Add(this.panel18);
            this.panel22.Controls.Add(this.panel35);
            this.panel22.Controls.Add(this.panel105);
            this.panel22.Controls.Add(this.panel29);
            this.panel22.Controls.Add(this.panel31);
            this.panel22.Controls.Add(this.panel41);
            this.panel22.Controls.Add(this.panel14);
            this.panel22.Controls.Add(this.panel100);
            this.panel22.Controls.Add(this.panel93);
            this.panel22.Controls.Add(this.panel21);
            this.panel22.Controls.Add(this.panel37);
            this.panel22.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel22.Location = new System.Drawing.Point(1, 1);
            this.panel22.Name = "panel22";
            this.panel22.Size = new System.Drawing.Size(438, 325);
            this.panel22.TabIndex = 0;
            // 
            // panel23
            // 
            this.panel23.Controls.Add(this.panel79);
            this.panel23.Controls.Add(this.laLYFQ);
            this.panel23.Controls.Add(this.panel103);
            this.panel23.Controls.Add(this.laQYKZ);
            this.panel23.Controls.Add(this.label138);
            this.panel23.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel23.Location = new System.Drawing.Point(0, 300);
            this.panel23.Name = "panel23";
            this.panel23.Size = new System.Drawing.Size(438, 25);
            this.panel23.TabIndex = 0;
            // 
            // panel79
            // 
            this.panel79.Controls.Add(this.LYFQ);
            this.panel79.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel79.Location = new System.Drawing.Point(280, 0);
            this.panel79.Name = "panel79";
            this.panel79.Padding = new System.Windows.Forms.Padding(2, 4, 4, 0);
            this.panel79.Size = new System.Drawing.Size(149, 24);
            this.panel79.TabIndex = 0;
            // 
            // LYFQ
            // 
            this.LYFQ.AssDispValue = true;
            this.LYFQ.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LYFQ.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LYFQ.ForeColor = System.Drawing.Color.Blue;
            this.LYFQ.Location = new System.Drawing.Point(2, 4);
            this.LYFQ.Name = "LYFQ";
            this.LYFQ.Size = new System.Drawing.Size(143, 20);
            this.LYFQ.TabIndex = 39;
            this.LYFQ.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // laLYFQ
            // 
            this.laLYFQ.Dock = System.Windows.Forms.DockStyle.Left;
            this.laLYFQ.Location = new System.Drawing.Point(198, 0);
            this.laLYFQ.Name = "laLYFQ";
            this.laLYFQ.Size = new System.Drawing.Size(82, 24);
            this.laLYFQ.TabIndex = 0;
            this.laLYFQ.Text = "林地功能分区";
            this.laLYFQ.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel103
            // 
            this.panel103.Controls.Add(this.QYKZ);
            this.panel103.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel103.Location = new System.Drawing.Point(118, 0);
            this.panel103.Name = "panel103";
            this.panel103.Padding = new System.Windows.Forms.Padding(2, 4, 4, 0);
            this.panel103.Size = new System.Drawing.Size(80, 24);
            this.panel103.TabIndex = 0;
            // 
            // QYKZ
            // 
            this.QYKZ.AssDispValue = true;
            this.QYKZ.Cursor = System.Windows.Forms.Cursors.Hand;
            this.QYKZ.Dock = System.Windows.Forms.DockStyle.Fill;
            this.QYKZ.ForeColor = System.Drawing.Color.Blue;
            this.QYKZ.Location = new System.Drawing.Point(2, 4);
            this.QYKZ.Name = "QYKZ";
            this.QYKZ.Size = new System.Drawing.Size(74, 20);
            this.QYKZ.TabIndex = 38;
            this.QYKZ.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // laQYKZ
            // 
            this.laQYKZ.Dock = System.Windows.Forms.DockStyle.Left;
            this.laQYKZ.Location = new System.Drawing.Point(0, 0);
            this.laQYKZ.Name = "laQYKZ";
            this.laQYKZ.Size = new System.Drawing.Size(118, 24);
            this.laQYKZ.TabIndex = 0;
            this.laQYKZ.Text = "主体功能区";
            this.laQYKZ.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label138
            // 
            this.label138.BackColor = System.Drawing.Color.Black;
            this.label138.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label138.Location = new System.Drawing.Point(0, 24);
            this.label138.Name = "label138";
            this.label138.Size = new System.Drawing.Size(438, 1);
            this.label138.TabIndex = 0;
            this.label138.Text = "label138";
            this.label138.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel83
            // 
            this.panel83.Controls.Add(this.panel102);
            this.panel83.Controls.Add(this.laZL_DJ);
            this.panel83.Controls.Add(this.panel27);
            this.panel83.Controls.Add(this.laGJGYL_BHDJ);
            this.panel83.Controls.Add(this.label140);
            this.panel83.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel83.Location = new System.Drawing.Point(0, 275);
            this.panel83.Name = "panel83";
            this.panel83.Size = new System.Drawing.Size(438, 25);
            this.panel83.TabIndex = 0;
            // 
            // panel102
            // 
            this.panel102.Controls.Add(this.ZL_DJ);
            this.panel102.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel102.Location = new System.Drawing.Point(280, 0);
            this.panel102.Name = "panel102";
            this.panel102.Padding = new System.Windows.Forms.Padding(2, 4, 4, 0);
            this.panel102.Size = new System.Drawing.Size(90, 24);
            this.panel102.TabIndex = 0;
            // 
            // ZL_DJ
            // 
            this.ZL_DJ.AssDispValue = true;
            this.ZL_DJ.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ZL_DJ.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ZL_DJ.ForeColor = System.Drawing.Color.Blue;
            this.ZL_DJ.Location = new System.Drawing.Point(2, 4);
            this.ZL_DJ.Name = "ZL_DJ";
            this.ZL_DJ.Size = new System.Drawing.Size(84, 20);
            this.ZL_DJ.TabIndex = 37;
            this.ZL_DJ.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // laZL_DJ
            // 
            this.laZL_DJ.Dock = System.Windows.Forms.DockStyle.Left;
            this.laZL_DJ.Location = new System.Drawing.Point(198, 0);
            this.laZL_DJ.Name = "laZL_DJ";
            this.laZL_DJ.Size = new System.Drawing.Size(82, 24);
            this.laZL_DJ.TabIndex = 0;
            this.laZL_DJ.Text = "林地质量等级";
            this.laZL_DJ.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel27
            // 
            this.panel27.Controls.Add(this.GJGYL_BHDJ);
            this.panel27.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel27.Location = new System.Drawing.Point(118, 0);
            this.panel27.Name = "panel27";
            this.panel27.Padding = new System.Windows.Forms.Padding(2, 4, 4, 0);
            this.panel27.Size = new System.Drawing.Size(80, 24);
            this.panel27.TabIndex = 0;
            // 
            // GJGYL_BHDJ
            // 
            this.GJGYL_BHDJ.AssDispValue = true;
            this.GJGYL_BHDJ.Cursor = System.Windows.Forms.Cursors.Hand;
            this.GJGYL_BHDJ.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GJGYL_BHDJ.ForeColor = System.Drawing.Color.Blue;
            this.GJGYL_BHDJ.Location = new System.Drawing.Point(2, 4);
            this.GJGYL_BHDJ.Name = "GJGYL_BHDJ";
            this.GJGYL_BHDJ.Size = new System.Drawing.Size(74, 20);
            this.GJGYL_BHDJ.TabIndex = 36;
            this.GJGYL_BHDJ.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // laGJGYL_BHDJ
            // 
            this.laGJGYL_BHDJ.Dock = System.Windows.Forms.DockStyle.Left;
            this.laGJGYL_BHDJ.Location = new System.Drawing.Point(0, 0);
            this.laGJGYL_BHDJ.Name = "laGJGYL_BHDJ";
            this.laGJGYL_BHDJ.Size = new System.Drawing.Size(118, 24);
            this.laGJGYL_BHDJ.TabIndex = 0;
            this.laGJGYL_BHDJ.Text = "国家公益林保护等级";
            this.laGJGYL_BHDJ.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label140
            // 
            this.label140.BackColor = System.Drawing.Color.Black;
            this.label140.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label140.Location = new System.Drawing.Point(0, 24);
            this.label140.Name = "label140";
            this.label140.Size = new System.Drawing.Size(438, 1);
            this.label140.TabIndex = 0;
            this.label140.Text = "label140";
            this.label140.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel18
            // 
            this.panel18.Controls.Add(this.panel67);
            this.panel18.Controls.Add(this.laSHI_QUAN_D);
            this.panel18.Controls.Add(this.panel19);
            this.panel18.Controls.Add(this.laBH_DJ);
            this.panel18.Controls.Add(this.panel42);
            this.panel18.Controls.Add(this.laQI_YUAN);
            this.panel18.Controls.Add(this.label21);
            this.panel18.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel18.Location = new System.Drawing.Point(0, 250);
            this.panel18.Name = "panel18";
            this.panel18.Size = new System.Drawing.Size(438, 25);
            this.panel18.TabIndex = 0;
            // 
            // panel67
            // 
            this.panel67.Controls.Add(this.SHI_QUAN_D);
            this.panel67.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel67.Location = new System.Drawing.Point(339, 0);
            this.panel67.Name = "panel67";
            this.panel67.Padding = new System.Windows.Forms.Padding(2, 4, 4, 0);
            this.panel67.Size = new System.Drawing.Size(90, 24);
            this.panel67.TabIndex = 0;
            // 
            // SHI_QUAN_D
            // 
            this.SHI_QUAN_D.AssDispValue = true;
            this.SHI_QUAN_D.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SHI_QUAN_D.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SHI_QUAN_D.ForeColor = System.Drawing.Color.Blue;
            this.SHI_QUAN_D.Location = new System.Drawing.Point(2, 4);
            this.SHI_QUAN_D.Name = "SHI_QUAN_D";
            this.SHI_QUAN_D.Size = new System.Drawing.Size(84, 20);
            this.SHI_QUAN_D.TabIndex = 35;
            this.SHI_QUAN_D.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // laSHI_QUAN_D
            // 
            this.laSHI_QUAN_D.Dock = System.Windows.Forms.DockStyle.Left;
            this.laSHI_QUAN_D.Location = new System.Drawing.Point(286, 0);
            this.laSHI_QUAN_D.Name = "laSHI_QUAN_D";
            this.laSHI_QUAN_D.Size = new System.Drawing.Size(53, 24);
            this.laSHI_QUAN_D.TabIndex = 0;
            this.laSHI_QUAN_D.Text = "事权等级";
            this.laSHI_QUAN_D.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel19
            // 
            this.panel19.Controls.Add(this.BH_DJ);
            this.panel19.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel19.Location = new System.Drawing.Point(196, 0);
            this.panel19.Name = "panel19";
            this.panel19.Padding = new System.Windows.Forms.Padding(2, 4, 4, 0);
            this.panel19.Size = new System.Drawing.Size(90, 24);
            this.panel19.TabIndex = 0;
            // 
            // BH_DJ
            // 
            this.BH_DJ.AssDispValue = true;
            this.BH_DJ.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BH_DJ.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BH_DJ.ForeColor = System.Drawing.Color.Blue;
            this.BH_DJ.Location = new System.Drawing.Point(2, 4);
            this.BH_DJ.Name = "BH_DJ";
            this.BH_DJ.Size = new System.Drawing.Size(84, 20);
            this.BH_DJ.TabIndex = 34;
            this.BH_DJ.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // laBH_DJ
            // 
            this.laBH_DJ.Dock = System.Windows.Forms.DockStyle.Left;
            this.laBH_DJ.Location = new System.Drawing.Point(143, 0);
            this.laBH_DJ.Name = "laBH_DJ";
            this.laBH_DJ.Size = new System.Drawing.Size(53, 24);
            this.laBH_DJ.TabIndex = 0;
            this.laBH_DJ.Text = "保护等级";
            this.laBH_DJ.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel42
            // 
            this.panel42.Controls.Add(this.QI_YUAN);
            this.panel42.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel42.Location = new System.Drawing.Point(53, 0);
            this.panel42.Name = "panel42";
            this.panel42.Padding = new System.Windows.Forms.Padding(2, 4, 4, 0);
            this.panel42.Size = new System.Drawing.Size(90, 24);
            this.panel42.TabIndex = 0;
            // 
            // QI_YUAN
            // 
            this.QI_YUAN.AssDispValue = true;
            this.QI_YUAN.Cursor = System.Windows.Forms.Cursors.Hand;
            this.QI_YUAN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.QI_YUAN.ForeColor = System.Drawing.Color.Blue;
            this.QI_YUAN.Location = new System.Drawing.Point(2, 4);
            this.QI_YUAN.Name = "QI_YUAN";
            this.QI_YUAN.Size = new System.Drawing.Size(84, 20);
            this.QI_YUAN.TabIndex = 33;
            this.QI_YUAN.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // laQI_YUAN
            // 
            this.laQI_YUAN.Dock = System.Windows.Forms.DockStyle.Left;
            this.laQI_YUAN.Location = new System.Drawing.Point(0, 0);
            this.laQI_YUAN.Name = "laQI_YUAN";
            this.laQI_YUAN.Size = new System.Drawing.Size(53, 24);
            this.laQI_YUAN.TabIndex = 0;
            this.laQI_YUAN.Text = "起源";
            this.laQI_YUAN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label21
            // 
            this.label21.BackColor = System.Drawing.Color.Black;
            this.label21.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label21.Location = new System.Drawing.Point(0, 24);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(438, 1);
            this.label21.TabIndex = 0;
            this.label21.Text = "label21";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel35
            // 
            this.panel35.Controls.Add(this.panel107);
            this.panel35.Controls.Add(this.laMEI_GQ_ZS);
            this.panel35.Controls.Add(this.panel34);
            this.panel35.Controls.Add(this.laPINGJUN_NL);
            this.panel35.Controls.Add(this.panel75);
            this.panel35.Controls.Add(this.laLING_ZU);
            this.panel35.Controls.Add(this.label51);
            this.panel35.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel35.Location = new System.Drawing.Point(0, 225);
            this.panel35.Name = "panel35";
            this.panel35.Size = new System.Drawing.Size(438, 25);
            this.panel35.TabIndex = 0;
            // 
            // panel107
            // 
            this.panel107.Controls.Add(this.MEI_GQ_ZS);
            this.panel107.Controls.Add(this.label147);
            this.panel107.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel107.Location = new System.Drawing.Point(352, 0);
            this.panel107.Name = "panel107";
            this.panel107.Padding = new System.Windows.Forms.Padding(2, 6, 6, 2);
            this.panel107.Size = new System.Drawing.Size(77, 24);
            this.panel107.TabIndex = 0;
            // 
            // MEI_GQ_ZS
            // 
            this.MEI_GQ_ZS.Cursor = System.Windows.Forms.Cursors.Hand;
            this.MEI_GQ_ZS.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.MEI_GQ_ZS.EditScale = 0;
            this.MEI_GQ_ZS.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.MEI_GQ_ZS.Location = new System.Drawing.Point(2, 4);
            this.MEI_GQ_ZS.Name = "MEI_GQ_ZS";
            this.MEI_GQ_ZS.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.MEI_GQ_ZS.Properties.Appearance.Options.UseForeColor = true;
            this.MEI_GQ_ZS.Properties.Appearance.Options.UseTextOptions = true;
            this.MEI_GQ_ZS.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.MEI_GQ_ZS.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.MEI_GQ_ZS.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.MEI_GQ_ZS.Properties.MaxValue = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.MEI_GQ_ZS.Size = new System.Drawing.Size(59, 18);
            this.MEI_GQ_ZS.TabIndex = 32;
            this.MEI_GQ_ZS.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // label147
            // 
            this.label147.Dock = System.Windows.Forms.DockStyle.Right;
            this.label147.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label147.ForeColor = System.Drawing.Color.Blue;
            this.label147.Location = new System.Drawing.Point(61, 6);
            this.label147.Name = "label147";
            this.label147.Size = new System.Drawing.Size(10, 16);
            this.label147.TabIndex = 0;
            // 
            // laMEI_GQ_ZS
            // 
            this.laMEI_GQ_ZS.Dock = System.Windows.Forms.DockStyle.Left;
            this.laMEI_GQ_ZS.Location = new System.Drawing.Point(286, 0);
            this.laMEI_GQ_ZS.Name = "laMEI_GQ_ZS";
            this.laMEI_GQ_ZS.Size = new System.Drawing.Size(66, 24);
            this.laMEI_GQ_ZS.TabIndex = 0;
            this.laMEI_GQ_ZS.Text = "每公顷株数";
            this.laMEI_GQ_ZS.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel34
            // 
            this.panel34.Controls.Add(this.PINGJUN_NL);
            this.panel34.Controls.Add(this.label133);
            this.panel34.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel34.Location = new System.Drawing.Point(196, 0);
            this.panel34.Name = "panel34";
            this.panel34.Padding = new System.Windows.Forms.Padding(2, 2, 6, 2);
            this.panel34.Size = new System.Drawing.Size(90, 24);
            this.panel34.TabIndex = 0;
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
            this.PINGJUN_NL.Location = new System.Drawing.Point(2, 4);
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
            this.PINGJUN_NL.Size = new System.Drawing.Size(57, 18);
            this.PINGJUN_NL.TabIndex = 31;
            this.PINGJUN_NL.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // label133
            // 
            this.label133.Dock = System.Windows.Forms.DockStyle.Right;
            this.label133.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label133.ForeColor = System.Drawing.Color.Blue;
            this.label133.Location = new System.Drawing.Point(59, 2);
            this.label133.Name = "label133";
            this.label133.Size = new System.Drawing.Size(25, 20);
            this.label133.TabIndex = 0;
            // 
            // laPINGJUN_NL
            // 
            this.laPINGJUN_NL.Dock = System.Windows.Forms.DockStyle.Left;
            this.laPINGJUN_NL.Location = new System.Drawing.Point(143, 0);
            this.laPINGJUN_NL.Name = "laPINGJUN_NL";
            this.laPINGJUN_NL.Size = new System.Drawing.Size(53, 24);
            this.laPINGJUN_NL.TabIndex = 0;
            this.laPINGJUN_NL.Text = "平均年龄";
            this.laPINGJUN_NL.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel75
            // 
            this.panel75.Controls.Add(this.LING_ZU);
            this.panel75.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel75.Location = new System.Drawing.Point(53, 0);
            this.panel75.Name = "panel75";
            this.panel75.Padding = new System.Windows.Forms.Padding(2, 4, 4, 0);
            this.panel75.Size = new System.Drawing.Size(90, 24);
            this.panel75.TabIndex = 0;
            // 
            // LING_ZU
            // 
            this.LING_ZU.AssDispValue = true;
            this.LING_ZU.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LING_ZU.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LING_ZU.ForeColor = System.Drawing.Color.Blue;
            this.LING_ZU.Location = new System.Drawing.Point(2, 4);
            this.LING_ZU.Name = "LING_ZU";
            this.LING_ZU.Size = new System.Drawing.Size(84, 20);
            this.LING_ZU.TabIndex = 30;
            this.LING_ZU.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // laLING_ZU
            // 
            this.laLING_ZU.Dock = System.Windows.Forms.DockStyle.Left;
            this.laLING_ZU.Location = new System.Drawing.Point(0, 0);
            this.laLING_ZU.Name = "laLING_ZU";
            this.laLING_ZU.Size = new System.Drawing.Size(53, 24);
            this.laLING_ZU.TabIndex = 0;
            this.laLING_ZU.Text = "龄组";
            this.laLING_ZU.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label51
            // 
            this.label51.BackColor = System.Drawing.Color.Black;
            this.label51.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label51.Location = new System.Drawing.Point(0, 24);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(438, 1);
            this.label51.TabIndex = 0;
            this.label51.Text = "label51";
            this.label51.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel105
            // 
            this.panel105.Controls.Add(this.simpleButtonCalcXJ);
            this.panel105.Controls.Add(this.panel32);
            this.panel105.Controls.Add(this.laSLXJ);
            this.panel105.Controls.Add(this.label149);
            this.panel105.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel105.Location = new System.Drawing.Point(0, 200);
            this.panel105.Name = "panel105";
            this.panel105.Size = new System.Drawing.Size(438, 25);
            this.panel105.TabIndex = 0;
            // 
            // simpleButtonCalcXJ
            // 
            this.simpleButtonCalcXJ.Location = new System.Drawing.Point(156, 1);
            this.simpleButtonCalcXJ.Name = "simpleButtonCalcXJ";
            this.simpleButtonCalcXJ.Size = new System.Drawing.Size(38, 23);
            this.simpleButtonCalcXJ.TabIndex = 0;
            this.simpleButtonCalcXJ.Text = "计算";
            this.simpleButtonCalcXJ.ToolTip = "计算蓄积（依据前期地类、树种、平均树高、平均胸径、平均公顷断面积、小班面积）";
            this.simpleButtonCalcXJ.Click += new System.EventHandler(this.simpleButtonCalcXJ_Click);
            // 
            // panel32
            // 
            this.panel32.Controls.Add(this.SLXJ);
            this.panel32.Controls.Add(this.label82);
            this.panel32.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel32.Location = new System.Drawing.Point(53, 0);
            this.panel32.Name = "panel32";
            this.panel32.Padding = new System.Windows.Forms.Padding(2, 6, 6, 2);
            this.panel32.Size = new System.Drawing.Size(90, 24);
            this.panel32.TabIndex = 0;
            // 
            // SLXJ
            // 
            this.SLXJ.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SLXJ.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.SLXJ.EditScale = 0;
            this.SLXJ.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.SLXJ.Location = new System.Drawing.Point(2, 4);
            this.SLXJ.Name = "SLXJ";
            this.SLXJ.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.SLXJ.Properties.Appearance.Options.UseForeColor = true;
            this.SLXJ.Properties.Appearance.Options.UseTextOptions = true;
            this.SLXJ.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.SLXJ.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.SLXJ.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.SLXJ.Properties.MaxValue = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.SLXJ.Size = new System.Drawing.Size(57, 18);
            this.SLXJ.TabIndex = 29;
            this.SLXJ.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // label82
            // 
            this.label82.Dock = System.Windows.Forms.DockStyle.Right;
            this.label82.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label82.ForeColor = System.Drawing.Color.Blue;
            this.label82.Location = new System.Drawing.Point(59, 6);
            this.label82.Name = "label82";
            this.label82.Size = new System.Drawing.Size(25, 16);
            this.label82.TabIndex = 0;
            this.label82.Text = "m³";
            // 
            // laSLXJ
            // 
            this.laSLXJ.Dock = System.Windows.Forms.DockStyle.Left;
            this.laSLXJ.Location = new System.Drawing.Point(0, 0);
            this.laSLXJ.Name = "laSLXJ";
            this.laSLXJ.Size = new System.Drawing.Size(53, 24);
            this.laSLXJ.TabIndex = 0;
            this.laSLXJ.Text = "占用蓄积";
            this.laSLXJ.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label149
            // 
            this.label149.BackColor = System.Drawing.Color.Black;
            this.label149.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label149.Location = new System.Drawing.Point(0, 24);
            this.label149.Name = "label149";
            this.label149.Size = new System.Drawing.Size(438, 1);
            this.label149.TabIndex = 0;
            this.label149.Text = "label149";
            this.label149.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel29
            // 
            this.panel29.Controls.Add(this.panel46);
            this.panel29.Controls.Add(this.laPINGJUN_DM);
            this.panel29.Controls.Add(this.panel51);
            this.panel29.Controls.Add(this.laPINGJUN_SG);
            this.panel29.Controls.Add(this.panel30);
            this.panel29.Controls.Add(this.laPINGJUN_XJ);
            this.panel29.Controls.Add(this.label33);
            this.panel29.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel29.Location = new System.Drawing.Point(0, 175);
            this.panel29.Name = "panel29";
            this.panel29.Size = new System.Drawing.Size(438, 25);
            this.panel29.TabIndex = 0;
            // 
            // panel46
            // 
            this.panel46.Controls.Add(this.PINGJUN_DM);
            this.panel46.Controls.Add(this.label34);
            this.panel46.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel46.Location = new System.Drawing.Point(339, 0);
            this.panel46.Name = "panel46";
            this.panel46.Padding = new System.Windows.Forms.Padding(2, 6, 6, 2);
            this.panel46.Size = new System.Drawing.Size(90, 24);
            this.panel46.TabIndex = 0;
            // 
            // PINGJUN_DM
            // 
            this.PINGJUN_DM.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PINGJUN_DM.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PINGJUN_DM.EditScale = 0;
            this.PINGJUN_DM.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.PINGJUN_DM.Location = new System.Drawing.Point(2, 4);
            this.PINGJUN_DM.Name = "PINGJUN_DM";
            this.PINGJUN_DM.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.PINGJUN_DM.Properties.Appearance.Options.UseForeColor = true;
            this.PINGJUN_DM.Properties.Appearance.Options.UseTextOptions = true;
            this.PINGJUN_DM.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.PINGJUN_DM.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.PINGJUN_DM.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.PINGJUN_DM.Properties.MaxValue = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.PINGJUN_DM.Size = new System.Drawing.Size(50, 18);
            this.PINGJUN_DM.TabIndex = 28;
            this.PINGJUN_DM.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // label34
            // 
            this.label34.Dock = System.Windows.Forms.DockStyle.Right;
            this.label34.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label34.ForeColor = System.Drawing.Color.Blue;
            this.label34.Location = new System.Drawing.Point(52, 6);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(32, 16);
            this.label34.TabIndex = 0;
            this.label34.Text = "平米";
            // 
            // laPINGJUN_DM
            // 
            this.laPINGJUN_DM.Dock = System.Windows.Forms.DockStyle.Left;
            this.laPINGJUN_DM.Location = new System.Drawing.Point(286, 0);
            this.laPINGJUN_DM.Name = "laPINGJUN_DM";
            this.laPINGJUN_DM.Size = new System.Drawing.Size(53, 24);
            this.laPINGJUN_DM.TabIndex = 0;
            this.laPINGJUN_DM.Text = "平均断面";
            this.laPINGJUN_DM.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel51
            // 
            this.panel51.Controls.Add(this.PINGJUN_SG);
            this.panel51.Controls.Add(this.label134);
            this.panel51.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel51.Location = new System.Drawing.Point(196, 0);
            this.panel51.Name = "panel51";
            this.panel51.Padding = new System.Windows.Forms.Padding(2, 6, 6, 2);
            this.panel51.Size = new System.Drawing.Size(90, 24);
            this.panel51.TabIndex = 0;
            // 
            // PINGJUN_SG
            // 
            this.PINGJUN_SG.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PINGJUN_SG.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PINGJUN_SG.EditScale = 0;
            this.PINGJUN_SG.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.PINGJUN_SG.Location = new System.Drawing.Point(2, 4);
            this.PINGJUN_SG.Name = "PINGJUN_SG";
            this.PINGJUN_SG.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.PINGJUN_SG.Properties.Appearance.Options.UseForeColor = true;
            this.PINGJUN_SG.Properties.Appearance.Options.UseTextOptions = true;
            this.PINGJUN_SG.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.PINGJUN_SG.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.PINGJUN_SG.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.PINGJUN_SG.Properties.MaxValue = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.PINGJUN_SG.Size = new System.Drawing.Size(57, 18);
            this.PINGJUN_SG.TabIndex = 27;
            this.PINGJUN_SG.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // label134
            // 
            this.label134.Dock = System.Windows.Forms.DockStyle.Right;
            this.label134.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label134.ForeColor = System.Drawing.Color.Blue;
            this.label134.Location = new System.Drawing.Point(59, 6);
            this.label134.Name = "label134";
            this.label134.Size = new System.Drawing.Size(25, 16);
            this.label134.TabIndex = 0;
            this.label134.Text = "m";
            // 
            // laPINGJUN_SG
            // 
            this.laPINGJUN_SG.Dock = System.Windows.Forms.DockStyle.Left;
            this.laPINGJUN_SG.Location = new System.Drawing.Point(143, 0);
            this.laPINGJUN_SG.Name = "laPINGJUN_SG";
            this.laPINGJUN_SG.Size = new System.Drawing.Size(53, 24);
            this.laPINGJUN_SG.TabIndex = 0;
            this.laPINGJUN_SG.Text = "平均树高";
            this.laPINGJUN_SG.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel30
            // 
            this.panel30.Controls.Add(this.PINGJUN_XJ);
            this.panel30.Controls.Add(this.label25);
            this.panel30.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel30.Location = new System.Drawing.Point(53, 0);
            this.panel30.Name = "panel30";
            this.panel30.Padding = new System.Windows.Forms.Padding(2, 6, 6, 2);
            this.panel30.Size = new System.Drawing.Size(90, 24);
            this.panel30.TabIndex = 0;
            // 
            // PINGJUN_XJ
            // 
            this.PINGJUN_XJ.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PINGJUN_XJ.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PINGJUN_XJ.EditScale = 0;
            this.PINGJUN_XJ.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.PINGJUN_XJ.Location = new System.Drawing.Point(2, 4);
            this.PINGJUN_XJ.Name = "PINGJUN_XJ";
            this.PINGJUN_XJ.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.PINGJUN_XJ.Properties.Appearance.Options.UseForeColor = true;
            this.PINGJUN_XJ.Properties.Appearance.Options.UseTextOptions = true;
            this.PINGJUN_XJ.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.PINGJUN_XJ.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.PINGJUN_XJ.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.PINGJUN_XJ.Properties.MaxValue = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.PINGJUN_XJ.Size = new System.Drawing.Size(57, 18);
            this.PINGJUN_XJ.TabIndex = 26;
            this.PINGJUN_XJ.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // label25
            // 
            this.label25.Dock = System.Windows.Forms.DockStyle.Right;
            this.label25.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.ForeColor = System.Drawing.Color.Blue;
            this.label25.Location = new System.Drawing.Point(59, 6);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(25, 16);
            this.label25.TabIndex = 0;
            this.label25.Text = "cm";
            // 
            // laPINGJUN_XJ
            // 
            this.laPINGJUN_XJ.Dock = System.Windows.Forms.DockStyle.Left;
            this.laPINGJUN_XJ.Location = new System.Drawing.Point(0, 0);
            this.laPINGJUN_XJ.Name = "laPINGJUN_XJ";
            this.laPINGJUN_XJ.Size = new System.Drawing.Size(53, 24);
            this.laPINGJUN_XJ.TabIndex = 0;
            this.laPINGJUN_XJ.Text = "平均胸径";
            this.laPINGJUN_XJ.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label33
            // 
            this.label33.BackColor = System.Drawing.Color.Black;
            this.label33.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label33.Location = new System.Drawing.Point(0, 24);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(438, 1);
            this.label33.TabIndex = 0;
            this.label33.Text = "label33";
            this.label33.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel31
            // 
            this.panel31.Controls.Add(this.panel43);
            this.panel31.Controls.Add(this.laYU_BI_DU);
            this.panel31.Controls.Add(this.panel104);
            this.panel31.Controls.Add(this.laSPMJ);
            this.panel31.Controls.Add(this.panel33);
            this.panel31.Controls.Add(this.laMIAN_JI);
            this.panel31.Controls.Add(this.label59);
            this.panel31.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel31.Location = new System.Drawing.Point(0, 150);
            this.panel31.Name = "panel31";
            this.panel31.Size = new System.Drawing.Size(438, 25);
            this.panel31.TabIndex = 0;
            // 
            // panel43
            // 
            this.panel43.Controls.Add(this.YU_BI_DU);
            this.panel43.Controls.Add(this.label52);
            this.panel43.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel43.Location = new System.Drawing.Point(339, 0);
            this.panel43.Name = "panel43";
            this.panel43.Padding = new System.Windows.Forms.Padding(2, 6, 6, 2);
            this.panel43.Size = new System.Drawing.Size(90, 24);
            this.panel43.TabIndex = 0;
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
            this.YU_BI_DU.Size = new System.Drawing.Size(62, 18);
            this.YU_BI_DU.TabIndex = 25;
            this.YU_BI_DU.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // label52
            // 
            this.label52.Dock = System.Windows.Forms.DockStyle.Right;
            this.label52.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label52.ForeColor = System.Drawing.Color.Blue;
            this.label52.Location = new System.Drawing.Point(64, 6);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(20, 16);
            this.label52.TabIndex = 0;
            // 
            // laYU_BI_DU
            // 
            this.laYU_BI_DU.Dock = System.Windows.Forms.DockStyle.Left;
            this.laYU_BI_DU.Location = new System.Drawing.Point(286, 0);
            this.laYU_BI_DU.Name = "laYU_BI_DU";
            this.laYU_BI_DU.Size = new System.Drawing.Size(53, 24);
            this.laYU_BI_DU.TabIndex = 0;
            this.laYU_BI_DU.Text = "郁闭度";
            this.laYU_BI_DU.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel104
            // 
            this.panel104.Controls.Add(this.SPMJ);
            this.panel104.Controls.Add(this.label146);
            this.panel104.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel104.Location = new System.Drawing.Point(196, 0);
            this.panel104.Name = "panel104";
            this.panel104.Padding = new System.Windows.Forms.Padding(2, 6, 6, 2);
            this.panel104.Size = new System.Drawing.Size(90, 24);
            this.panel104.TabIndex = 0;
            // 
            // SPMJ
            // 
            this.SPMJ.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SPMJ.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.SPMJ.EditScale = 0;
            this.SPMJ.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.SPMJ.Location = new System.Drawing.Point(2, 4);
            this.SPMJ.Name = "SPMJ";
            this.SPMJ.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.SPMJ.Properties.Appearance.Options.UseForeColor = true;
            this.SPMJ.Properties.Appearance.Options.UseTextOptions = true;
            this.SPMJ.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.SPMJ.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.SPMJ.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.SPMJ.Properties.MaxValue = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.SPMJ.Size = new System.Drawing.Size(50, 18);
            this.SPMJ.TabIndex = 24;
            this.SPMJ.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // label146
            // 
            this.label146.Dock = System.Windows.Forms.DockStyle.Right;
            this.label146.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label146.ForeColor = System.Drawing.Color.Blue;
            this.label146.Location = new System.Drawing.Point(52, 6);
            this.label146.Name = "label146";
            this.label146.Size = new System.Drawing.Size(32, 16);
            this.label146.TabIndex = 0;
            this.label146.Text = "公顷";
            this.label146.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // laSPMJ
            // 
            this.laSPMJ.Dock = System.Windows.Forms.DockStyle.Left;
            this.laSPMJ.Location = new System.Drawing.Point(143, 0);
            this.laSPMJ.Name = "laSPMJ";
            this.laSPMJ.Size = new System.Drawing.Size(53, 24);
            this.laSPMJ.TabIndex = 0;
            this.laSPMJ.Text = "审批面积";
            this.laSPMJ.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel33
            // 
            this.panel33.Controls.Add(this.MIAN_JI);
            this.panel33.Controls.Add(this.label32);
            this.panel33.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel33.Location = new System.Drawing.Point(53, 0);
            this.panel33.Name = "panel33";
            this.panel33.Padding = new System.Windows.Forms.Padding(2, 6, 1, 2);
            this.panel33.Size = new System.Drawing.Size(90, 24);
            this.panel33.TabIndex = 0;
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
            this.MIAN_JI.Size = new System.Drawing.Size(55, 18);
            this.MIAN_JI.TabIndex = 23;
            this.MIAN_JI.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // label32
            // 
            this.label32.Dock = System.Windows.Forms.DockStyle.Right;
            this.label32.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label32.ForeColor = System.Drawing.Color.Blue;
            this.label32.Location = new System.Drawing.Point(57, 6);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(32, 16);
            this.label32.TabIndex = 0;
            this.label32.Text = "公顷";
            this.label32.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // laMIAN_JI
            // 
            this.laMIAN_JI.Dock = System.Windows.Forms.DockStyle.Left;
            this.laMIAN_JI.Location = new System.Drawing.Point(0, 0);
            this.laMIAN_JI.Name = "laMIAN_JI";
            this.laMIAN_JI.Size = new System.Drawing.Size(53, 24);
            this.laMIAN_JI.TabIndex = 0;
            this.laMIAN_JI.Text = "占用面积";
            this.laMIAN_JI.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label59
            // 
            this.label59.BackColor = System.Drawing.Color.Black;
            this.label59.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label59.Location = new System.Drawing.Point(0, 24);
            this.label59.Name = "label59";
            this.label59.Size = new System.Drawing.Size(438, 1);
            this.label59.TabIndex = 0;
            this.label59.Text = "label59";
            this.label59.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel41
            // 
            this.panel41.Controls.Add(this.panel73);
            this.panel41.Controls.Add(this.laJJLCQ);
            this.panel41.Controls.Add(this.panel66);
            this.panel41.Controls.Add(this.laBSSZ);
            this.panel41.Controls.Add(this.panel44);
            this.panel41.Controls.Add(this.laYOU_SHI_SZ);
            this.panel41.Controls.Add(this.label65);
            this.panel41.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel41.Location = new System.Drawing.Point(0, 125);
            this.panel41.Name = "panel41";
            this.panel41.Size = new System.Drawing.Size(438, 25);
            this.panel41.TabIndex = 0;
            // 
            // panel73
            // 
            this.panel73.Controls.Add(this.JJLCQ);
            this.panel73.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel73.Location = new System.Drawing.Point(352, 0);
            this.panel73.Name = "panel73";
            this.panel73.Padding = new System.Windows.Forms.Padding(2, 4, 4, 0);
            this.panel73.Size = new System.Drawing.Size(77, 24);
            this.panel73.TabIndex = 0;
            // 
            // JJLCQ
            // 
            this.JJLCQ.AssDispValue = true;
            this.JJLCQ.Cursor = System.Windows.Forms.Cursors.Hand;
            this.JJLCQ.Dock = System.Windows.Forms.DockStyle.Fill;
            this.JJLCQ.ForeColor = System.Drawing.Color.Blue;
            this.JJLCQ.Location = new System.Drawing.Point(2, 4);
            this.JJLCQ.Name = "JJLCQ";
            this.JJLCQ.Size = new System.Drawing.Size(71, 20);
            this.JJLCQ.TabIndex = 22;
            this.JJLCQ.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // laJJLCQ
            // 
            this.laJJLCQ.Dock = System.Windows.Forms.DockStyle.Left;
            this.laJJLCQ.Location = new System.Drawing.Point(286, 0);
            this.laJJLCQ.Name = "laJJLCQ";
            this.laJJLCQ.Size = new System.Drawing.Size(66, 24);
            this.laJJLCQ.TabIndex = 0;
            this.laJJLCQ.Text = "经济林产期";
            this.laJJLCQ.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel66
            // 
            this.panel66.Controls.Add(this.BSSZ);
            this.panel66.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel66.Location = new System.Drawing.Point(196, 0);
            this.panel66.Name = "panel66";
            this.panel66.Padding = new System.Windows.Forms.Padding(2, 4, 2, 0);
            this.panel66.Size = new System.Drawing.Size(90, 24);
            this.panel66.TabIndex = 0;
            // 
            // BSSZ
            // 
            this.BSSZ.AssDispValue = true;
            this.BSSZ.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BSSZ.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BSSZ.ForeColor = System.Drawing.Color.Blue;
            this.BSSZ.Location = new System.Drawing.Point(2, 4);
            this.BSSZ.Name = "BSSZ";
            this.BSSZ.Size = new System.Drawing.Size(86, 20);
            this.BSSZ.TabIndex = 21;
            this.BSSZ.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // laBSSZ
            // 
            this.laBSSZ.Dock = System.Windows.Forms.DockStyle.Left;
            this.laBSSZ.Location = new System.Drawing.Point(143, 0);
            this.laBSSZ.Name = "laBSSZ";
            this.laBSSZ.Size = new System.Drawing.Size(53, 24);
            this.laBSSZ.TabIndex = 0;
            this.laBSSZ.Text = "伴生树种";
            this.laBSSZ.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel44
            // 
            this.panel44.Controls.Add(this.YOU_SHI_SZ);
            this.panel44.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel44.Location = new System.Drawing.Point(53, 0);
            this.panel44.Name = "panel44";
            this.panel44.Padding = new System.Windows.Forms.Padding(2, 4, 2, 0);
            this.panel44.Size = new System.Drawing.Size(90, 24);
            this.panel44.TabIndex = 0;
            // 
            // YOU_SHI_SZ
            // 
            this.YOU_SHI_SZ.AssDispValue = true;
            this.YOU_SHI_SZ.Cursor = System.Windows.Forms.Cursors.Hand;
            this.YOU_SHI_SZ.Dock = System.Windows.Forms.DockStyle.Fill;
            this.YOU_SHI_SZ.ForeColor = System.Drawing.Color.Blue;
            this.YOU_SHI_SZ.Location = new System.Drawing.Point(2, 4);
            this.YOU_SHI_SZ.Name = "YOU_SHI_SZ";
            this.YOU_SHI_SZ.Size = new System.Drawing.Size(86, 20);
            this.YOU_SHI_SZ.TabIndex = 20;
            this.YOU_SHI_SZ.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // laYOU_SHI_SZ
            // 
            this.laYOU_SHI_SZ.Dock = System.Windows.Forms.DockStyle.Left;
            this.laYOU_SHI_SZ.Location = new System.Drawing.Point(0, 0);
            this.laYOU_SHI_SZ.Name = "laYOU_SHI_SZ";
            this.laYOU_SHI_SZ.Size = new System.Drawing.Size(53, 24);
            this.laYOU_SHI_SZ.TabIndex = 0;
            this.laYOU_SHI_SZ.Text = "优势树种";
            this.laYOU_SHI_SZ.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label65
            // 
            this.label65.BackColor = System.Drawing.Color.Black;
            this.label65.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label65.Location = new System.Drawing.Point(0, 24);
            this.label65.Name = "label65";
            this.label65.Size = new System.Drawing.Size(438, 1);
            this.label65.TabIndex = 0;
            this.label65.Text = "label65";
            this.label65.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel14
            // 
            this.panel14.Controls.Add(this.panel38);
            this.panel14.Controls.Add(this.laLMSYQ);
            this.panel14.Controls.Add(this.panel40);
            this.panel14.Controls.Add(this.laLMJYQ);
            this.panel14.Controls.Add(this.panel47);
            this.panel14.Controls.Add(this.laTDJYQ);
            this.panel14.Controls.Add(this.label114);
            this.panel14.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel14.Location = new System.Drawing.Point(0, 100);
            this.panel14.Name = "panel14";
            this.panel14.Size = new System.Drawing.Size(438, 25);
            this.panel14.TabIndex = 0;
            // 
            // panel38
            // 
            this.panel38.Controls.Add(this.LMSYQ);
            this.panel38.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel38.Location = new System.Drawing.Point(352, 0);
            this.panel38.Name = "panel38";
            this.panel38.Padding = new System.Windows.Forms.Padding(2, 4, 4, 0);
            this.panel38.Size = new System.Drawing.Size(77, 24);
            this.panel38.TabIndex = 0;
            // 
            // LMSYQ
            // 
            this.LMSYQ.AssDispValue = true;
            this.LMSYQ.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LMSYQ.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LMSYQ.ForeColor = System.Drawing.Color.Blue;
            this.LMSYQ.Location = new System.Drawing.Point(2, 4);
            this.LMSYQ.Name = "LMSYQ";
            this.LMSYQ.Size = new System.Drawing.Size(71, 20);
            this.LMSYQ.TabIndex = 19;
            this.LMSYQ.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // laLMSYQ
            // 
            this.laLMSYQ.Dock = System.Windows.Forms.DockStyle.Left;
            this.laLMSYQ.Location = new System.Drawing.Point(286, 0);
            this.laLMSYQ.Name = "laLMSYQ";
            this.laLMSYQ.Size = new System.Drawing.Size(66, 24);
            this.laLMSYQ.TabIndex = 0;
            this.laLMSYQ.Text = "林木所有权";
            this.laLMSYQ.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel40
            // 
            this.panel40.Controls.Add(this.LMJYQ);
            this.panel40.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel40.Location = new System.Drawing.Point(209, 0);
            this.panel40.Name = "panel40";
            this.panel40.Padding = new System.Windows.Forms.Padding(2, 4, 4, 0);
            this.panel40.Size = new System.Drawing.Size(77, 24);
            this.panel40.TabIndex = 0;
            // 
            // LMJYQ
            // 
            this.LMJYQ.AssDispValue = true;
            this.LMJYQ.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LMJYQ.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LMJYQ.ForeColor = System.Drawing.Color.Blue;
            this.LMJYQ.Location = new System.Drawing.Point(2, 4);
            this.LMJYQ.Name = "LMJYQ";
            this.LMJYQ.Size = new System.Drawing.Size(71, 20);
            this.LMJYQ.TabIndex = 18;
            this.LMJYQ.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // laLMJYQ
            // 
            this.laLMJYQ.Dock = System.Windows.Forms.DockStyle.Left;
            this.laLMJYQ.Location = new System.Drawing.Point(143, 0);
            this.laLMJYQ.Name = "laLMJYQ";
            this.laLMJYQ.Size = new System.Drawing.Size(66, 24);
            this.laLMJYQ.TabIndex = 0;
            this.laLMJYQ.Text = "林木使用权";
            this.laLMJYQ.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel47
            // 
            this.panel47.Controls.Add(this.TDJYQ);
            this.panel47.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel47.Location = new System.Drawing.Point(66, 0);
            this.panel47.Name = "panel47";
            this.panel47.Padding = new System.Windows.Forms.Padding(2, 4, 4, 0);
            this.panel47.Size = new System.Drawing.Size(77, 24);
            this.panel47.TabIndex = 0;
            // 
            // TDJYQ
            // 
            this.TDJYQ.AssDispValue = true;
            this.TDJYQ.Cursor = System.Windows.Forms.Cursors.Hand;
            this.TDJYQ.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TDJYQ.ForeColor = System.Drawing.Color.Blue;
            this.TDJYQ.Location = new System.Drawing.Point(2, 4);
            this.TDJYQ.Name = "TDJYQ";
            this.TDJYQ.Size = new System.Drawing.Size(71, 20);
            this.TDJYQ.TabIndex = 17;
            this.TDJYQ.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // laTDJYQ
            // 
            this.laTDJYQ.Dock = System.Windows.Forms.DockStyle.Left;
            this.laTDJYQ.Location = new System.Drawing.Point(0, 0);
            this.laTDJYQ.Name = "laTDJYQ";
            this.laTDJYQ.Size = new System.Drawing.Size(66, 24);
            this.laTDJYQ.TabIndex = 0;
            this.laTDJYQ.Text = "土地使用权";
            this.laTDJYQ.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label114
            // 
            this.label114.BackColor = System.Drawing.Color.Black;
            this.label114.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label114.Location = new System.Drawing.Point(0, 24);
            this.label114.Name = "label114";
            this.label114.Size = new System.Drawing.Size(438, 1);
            this.label114.TabIndex = 0;
            this.label114.Text = "label114";
            this.label114.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel100
            // 
            this.panel100.Controls.Add(this.panel26);
            this.panel100.Controls.Add(this.laLIN_ZHONG);
            this.panel100.Controls.Add(this.panel9);
            this.panel100.Controls.Add(this.laQ_LIN_ZHONG);
            this.panel100.Controls.Add(this.label162);
            this.panel100.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel100.Location = new System.Drawing.Point(0, 75);
            this.panel100.Name = "panel100";
            this.panel100.Size = new System.Drawing.Size(438, 25);
            this.panel100.TabIndex = 0;
            // 
            // panel26
            // 
            this.panel26.Controls.Add(this.LIN_ZHONG);
            this.panel26.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel26.Location = new System.Drawing.Point(240, 0);
            this.panel26.Name = "panel26";
            this.panel26.Padding = new System.Windows.Forms.Padding(2, 4, 4, 0);
            this.panel26.Size = new System.Drawing.Size(110, 24);
            this.panel26.TabIndex = 0;
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
            this.LIN_ZHONG.TabIndex = 16;
            this.LIN_ZHONG.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // laLIN_ZHONG
            // 
            this.laLIN_ZHONG.Dock = System.Windows.Forms.DockStyle.Left;
            this.laLIN_ZHONG.Location = new System.Drawing.Point(187, 0);
            this.laLIN_ZHONG.Name = "laLIN_ZHONG";
            this.laLIN_ZHONG.Size = new System.Drawing.Size(53, 24);
            this.laLIN_ZHONG.TabIndex = 0;
            this.laLIN_ZHONG.Text = "林种";
            this.laLIN_ZHONG.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.Q_LIN_ZHONG);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel9.Location = new System.Drawing.Point(77, 0);
            this.panel9.Name = "panel9";
            this.panel9.Padding = new System.Windows.Forms.Padding(2, 4, 4, 0);
            this.panel9.Size = new System.Drawing.Size(110, 24);
            this.panel9.TabIndex = 0;
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
            this.Q_LIN_ZHONG.TabIndex = 15;
            this.Q_LIN_ZHONG.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // laQ_LIN_ZHONG
            // 
            this.laQ_LIN_ZHONG.Dock = System.Windows.Forms.DockStyle.Left;
            this.laQ_LIN_ZHONG.Location = new System.Drawing.Point(0, 0);
            this.laQ_LIN_ZHONG.Name = "laQ_LIN_ZHONG";
            this.laQ_LIN_ZHONG.Size = new System.Drawing.Size(77, 24);
            this.laQ_LIN_ZHONG.TabIndex = 0;
            this.laQ_LIN_ZHONG.Text = "前期林种";
            this.laQ_LIN_ZHONG.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label162
            // 
            this.label162.BackColor = System.Drawing.Color.Black;
            this.label162.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label162.Location = new System.Drawing.Point(0, 24);
            this.label162.Name = "label162";
            this.label162.Size = new System.Drawing.Size(438, 1);
            this.label162.TabIndex = 0;
            this.label162.Text = "label162";
            this.label162.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel93
            // 
            this.panel93.Controls.Add(this.panel97);
            this.panel93.Controls.Add(this.laDI_LEI);
            this.panel93.Controls.Add(this.panel101);
            this.panel93.Controls.Add(this.laQ_DI_LEI);
            this.panel93.Controls.Add(this.label143);
            this.panel93.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel93.Location = new System.Drawing.Point(0, 50);
            this.panel93.Name = "panel93";
            this.panel93.Size = new System.Drawing.Size(438, 25);
            this.panel93.TabIndex = 0;
            // 
            // panel97
            // 
            this.panel97.Controls.Add(this.DI_LEI);
            this.panel97.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel97.Location = new System.Drawing.Point(240, 0);
            this.panel97.Name = "panel97";
            this.panel97.Padding = new System.Windows.Forms.Padding(2, 4, 4, 0);
            this.panel97.Size = new System.Drawing.Size(110, 24);
            this.panel97.TabIndex = 0;
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
            this.DI_LEI.TabIndex = 14;
            this.DI_LEI.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // laDI_LEI
            // 
            this.laDI_LEI.Dock = System.Windows.Forms.DockStyle.Left;
            this.laDI_LEI.Location = new System.Drawing.Point(187, 0);
            this.laDI_LEI.Name = "laDI_LEI";
            this.laDI_LEI.Size = new System.Drawing.Size(53, 24);
            this.laDI_LEI.TabIndex = 0;
            this.laDI_LEI.Text = "地类";
            this.laDI_LEI.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel101
            // 
            this.panel101.Controls.Add(this.Q_DI_LEI);
            this.panel101.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel101.Location = new System.Drawing.Point(77, 0);
            this.panel101.Name = "panel101";
            this.panel101.Padding = new System.Windows.Forms.Padding(2, 4, 4, 0);
            this.panel101.Size = new System.Drawing.Size(110, 24);
            this.panel101.TabIndex = 0;
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
            this.Q_DI_LEI.TabIndex = 13;
            this.Q_DI_LEI.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // laQ_DI_LEI
            // 
            this.laQ_DI_LEI.Dock = System.Windows.Forms.DockStyle.Left;
            this.laQ_DI_LEI.Location = new System.Drawing.Point(0, 0);
            this.laQ_DI_LEI.Name = "laQ_DI_LEI";
            this.laQ_DI_LEI.Size = new System.Drawing.Size(77, 24);
            this.laQ_DI_LEI.TabIndex = 0;
            this.laQ_DI_LEI.Text = "前期地类";
            this.laQ_DI_LEI.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label143
            // 
            this.label143.BackColor = System.Drawing.Color.Black;
            this.label143.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label143.Location = new System.Drawing.Point(0, 24);
            this.label143.Name = "label143";
            this.label143.Size = new System.Drawing.Size(438, 1);
            this.label143.TabIndex = 0;
            this.label143.Text = "label143";
            this.label143.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel21
            // 
            this.panel21.Controls.Add(this.panel24);
            this.panel21.Controls.Add(this.laLD_QS);
            this.panel21.Controls.Add(this.panel25);
            this.panel21.Controls.Add(this.laQ_LD_QS);
            this.panel21.Controls.Add(this.label47);
            this.panel21.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel21.Location = new System.Drawing.Point(0, 25);
            this.panel21.Name = "panel21";
            this.panel21.Size = new System.Drawing.Size(438, 25);
            this.panel21.TabIndex = 0;
            // 
            // panel24
            // 
            this.panel24.Controls.Add(this.LD_QS);
            this.panel24.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel24.Location = new System.Drawing.Point(240, 0);
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
            this.LD_QS.TabIndex = 12;
            this.LD_QS.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // laLD_QS
            // 
            this.laLD_QS.Dock = System.Windows.Forms.DockStyle.Left;
            this.laLD_QS.Location = new System.Drawing.Point(187, 0);
            this.laLD_QS.Name = "laLD_QS";
            this.laLD_QS.Size = new System.Drawing.Size(53, 24);
            this.laLD_QS.TabIndex = 0;
            this.laLD_QS.Text = "土地权属";
            this.laLD_QS.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel25
            // 
            this.panel25.Controls.Add(this.Q_LD_QS);
            this.panel25.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel25.Location = new System.Drawing.Point(77, 0);
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
            this.Q_LD_QS.TabIndex = 11;
            this.Q_LD_QS.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // laQ_LD_QS
            // 
            this.laQ_LD_QS.Dock = System.Windows.Forms.DockStyle.Left;
            this.laQ_LD_QS.Location = new System.Drawing.Point(0, 0);
            this.laQ_LD_QS.Name = "laQ_LD_QS";
            this.laQ_LD_QS.Size = new System.Drawing.Size(77, 24);
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
            this.label47.Size = new System.Drawing.Size(438, 1);
            this.label47.TabIndex = 0;
            this.label47.Text = "label47";
            this.label47.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel37
            // 
            this.panel37.Controls.Add(this.labelLBMess);
            this.panel37.Controls.Add(this.panel50);
            this.panel37.Controls.Add(this.laSEN_LIN_LB);
            this.panel37.Controls.Add(this.panel70);
            this.panel37.Controls.Add(this.laQ_SEN_LB);
            this.panel37.Controls.Add(this.label183);
            this.panel37.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel37.Location = new System.Drawing.Point(0, 0);
            this.panel37.Name = "panel37";
            this.panel37.Size = new System.Drawing.Size(438, 25);
            this.panel37.TabIndex = 0;
            // 
            // labelLBMess
            // 
            this.labelLBMess.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelLBMess.ForeColor = System.Drawing.Color.Red;
            this.labelLBMess.Location = new System.Drawing.Point(350, 0);
            this.labelLBMess.Name = "labelLBMess";
            this.labelLBMess.Size = new System.Drawing.Size(103, 24);
            this.labelLBMess.TabIndex = 0;
            this.labelLBMess.Text = "森林类别已改变！";
            this.labelLBMess.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelLBMess.Visible = false;
            // 
            // panel50
            // 
            this.panel50.Controls.Add(this.SEN_LIN_LB);
            this.panel50.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel50.Location = new System.Drawing.Point(240, 0);
            this.panel50.Name = "panel50";
            this.panel50.Padding = new System.Windows.Forms.Padding(2, 4, 4, 0);
            this.panel50.Size = new System.Drawing.Size(110, 24);
            this.panel50.TabIndex = 0;
            // 
            // SEN_LIN_LB
            // 
            this.SEN_LIN_LB.AssDispValue = true;
            this.SEN_LIN_LB.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SEN_LIN_LB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SEN_LIN_LB.ForeColor = System.Drawing.Color.Blue;
            this.SEN_LIN_LB.Location = new System.Drawing.Point(2, 4);
            this.SEN_LIN_LB.Name = "SEN_LIN_LB";
            this.SEN_LIN_LB.Size = new System.Drawing.Size(104, 20);
            this.SEN_LIN_LB.TabIndex = 10;
            this.SEN_LIN_LB.SelectedIndexChanged += new System.EventHandler(this.SEN_LIN_LB_SelectedIndexChanged);
            this.SEN_LIN_LB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // laSEN_LIN_LB
            // 
            this.laSEN_LIN_LB.Dock = System.Windows.Forms.DockStyle.Left;
            this.laSEN_LIN_LB.Location = new System.Drawing.Point(187, 0);
            this.laSEN_LIN_LB.Name = "laSEN_LIN_LB";
            this.laSEN_LIN_LB.Size = new System.Drawing.Size(53, 24);
            this.laSEN_LIN_LB.TabIndex = 0;
            this.laSEN_LIN_LB.Text = "森林类别";
            this.laSEN_LIN_LB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel70
            // 
            this.panel70.Controls.Add(this.Q_SEN_LB);
            this.panel70.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel70.Location = new System.Drawing.Point(77, 0);
            this.panel70.Name = "panel70";
            this.panel70.Padding = new System.Windows.Forms.Padding(2, 4, 4, 0);
            this.panel70.Size = new System.Drawing.Size(110, 24);
            this.panel70.TabIndex = 0;
            // 
            // Q_SEN_LB
            // 
            this.Q_SEN_LB.AssDispValue = true;
            this.Q_SEN_LB.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Q_SEN_LB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Q_SEN_LB.ForeColor = System.Drawing.Color.Blue;
            this.Q_SEN_LB.Location = new System.Drawing.Point(2, 4);
            this.Q_SEN_LB.Name = "Q_SEN_LB";
            this.Q_SEN_LB.Size = new System.Drawing.Size(104, 20);
            this.Q_SEN_LB.TabIndex = 9;
            this.Q_SEN_LB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // laQ_SEN_LB
            // 
            this.laQ_SEN_LB.Dock = System.Windows.Forms.DockStyle.Left;
            this.laQ_SEN_LB.Location = new System.Drawing.Point(0, 0);
            this.laQ_SEN_LB.Name = "laQ_SEN_LB";
            this.laQ_SEN_LB.Size = new System.Drawing.Size(77, 24);
            this.laQ_SEN_LB.TabIndex = 0;
            this.laQ_SEN_LB.Text = "前期森林类别";
            this.laQ_SEN_LB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label183
            // 
            this.label183.BackColor = System.Drawing.Color.Black;
            this.label183.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label183.Location = new System.Drawing.Point(0, 24);
            this.label183.Name = "label183";
            this.label183.Size = new System.Drawing.Size(438, 1);
            this.label183.TabIndex = 0;
            this.label183.Text = "label183";
            this.label183.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label67
            // 
            this.label67.BackColor = System.Drawing.Color.Black;
            this.label67.Dock = System.Windows.Forms.DockStyle.Top;
            this.label67.Location = new System.Drawing.Point(1, 0);
            this.label67.Name = "label67";
            this.label67.Size = new System.Drawing.Size(438, 1);
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
            this.label68.Size = new System.Drawing.Size(1, 326);
            this.label68.TabIndex = 0;
            this.label68.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label69
            // 
            this.label69.BackColor = System.Drawing.Color.Black;
            this.label69.Dock = System.Windows.Forms.DockStyle.Right;
            this.label69.Location = new System.Drawing.Point(439, 0);
            this.label69.Name = "label69";
            this.label69.Size = new System.Drawing.Size(1, 326);
            this.label69.TabIndex = 0;
            this.label69.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label70
            // 
            this.label70.Dock = System.Windows.Forms.DockStyle.Top;
            this.label70.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label70.Location = new System.Drawing.Point(0, 154);
            this.label70.Name = "label70";
            this.label70.Size = new System.Drawing.Size(440, 26);
            this.label70.TabIndex = 0;
            this.label70.Text = "  林分状况调查";
            this.label70.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label22
            // 
            this.label22.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label22.Location = new System.Drawing.Point(190, 29);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(72, 30);
            this.label22.TabIndex = 0;
            this.label22.Text = "采伐强度";
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
            this.label19.Text = "采伐蓄积";
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
            // label103
            // 
            this.label103.Dock = System.Windows.Forms.DockStyle.Top;
            this.label103.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label103.Location = new System.Drawing.Point(0, 506);
            this.label103.Name = "label103";
            this.label103.Size = new System.Drawing.Size(440, 26);
            this.label103.TabIndex = 0;
            this.label103.Text = "  其他";
            this.label103.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelXZW
            // 
            this.panelXZW.Controls.Add(this.panel108);
            this.panelXZW.Controls.Add(this.label175);
            this.panelXZW.Controls.Add(this.label176);
            this.panelXZW.Controls.Add(this.label177);
            this.panelXZW.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelXZW.Location = new System.Drawing.Point(0, 532);
            this.panelXZW.Name = "panelXZW";
            this.panelXZW.Size = new System.Drawing.Size(440, 51);
            this.panelXZW.TabIndex = 0;
            // 
            // panel108
            // 
            this.panel108.Controls.Add(this.panel72);
            this.panel108.Controls.Add(this.panel88);
            this.panel108.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel108.Location = new System.Drawing.Point(1, 1);
            this.panel108.Name = "panel108";
            this.panel108.Size = new System.Drawing.Size(438, 50);
            this.panel108.TabIndex = 0;
            // 
            // panel72
            // 
            this.panel72.Controls.Add(this.panel17);
            this.panel72.Controls.Add(this.laXZWKD);
            this.panel72.Controls.Add(this.panel59);
            this.panel72.Controls.Add(this.laXZWCD);
            this.panel72.Controls.Add(this.label109);
            this.panel72.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel72.Location = new System.Drawing.Point(0, 25);
            this.panel72.Name = "panel72";
            this.panel72.Size = new System.Drawing.Size(438, 25);
            this.panel72.TabIndex = 0;
            // 
            // panel17
            // 
            this.panel17.Controls.Add(this.XZWKD);
            this.panel17.Controls.Add(this.label137);
            this.panel17.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel17.Location = new System.Drawing.Point(244, 0);
            this.panel17.Name = "panel17";
            this.panel17.Padding = new System.Windows.Forms.Padding(2, 6, 6, 2);
            this.panel17.Size = new System.Drawing.Size(112, 24);
            this.panel17.TabIndex = 0;
            // 
            // XZWKD
            // 
            this.XZWKD.Cursor = System.Windows.Forms.Cursors.Hand;
            this.XZWKD.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.XZWKD.EditScale = 0;
            this.XZWKD.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.XZWKD.Location = new System.Drawing.Point(2, 4);
            this.XZWKD.Name = "XZWKD";
            this.XZWKD.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.XZWKD.Properties.Appearance.Options.UseForeColor = true;
            this.XZWKD.Properties.Appearance.Options.UseTextOptions = true;
            this.XZWKD.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.XZWKD.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.XZWKD.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.XZWKD.Properties.MaxValue = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.XZWKD.Size = new System.Drawing.Size(71, 18);
            this.XZWKD.TabIndex = 43;
            this.XZWKD.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // label137
            // 
            this.label137.Dock = System.Windows.Forms.DockStyle.Right;
            this.label137.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label137.ForeColor = System.Drawing.Color.Blue;
            this.label137.Location = new System.Drawing.Point(73, 6);
            this.label137.Name = "label137";
            this.label137.Size = new System.Drawing.Size(33, 16);
            this.label137.TabIndex = 0;
            this.label137.Text = "m";
            // 
            // laXZWKD
            // 
            this.laXZWKD.Cursor = System.Windows.Forms.Cursors.Default;
            this.laXZWKD.Dock = System.Windows.Forms.DockStyle.Left;
            this.laXZWKD.Location = new System.Drawing.Point(178, 0);
            this.laXZWKD.Name = "laXZWKD";
            this.laXZWKD.Size = new System.Drawing.Size(66, 24);
            this.laXZWKD.TabIndex = 0;
            this.laXZWKD.Text = "线状物宽度";
            this.laXZWKD.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel59
            // 
            this.panel59.Controls.Add(this.XZWCD);
            this.panel59.Controls.Add(this.label136);
            this.panel59.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel59.Location = new System.Drawing.Point(66, 0);
            this.panel59.Name = "panel59";
            this.panel59.Padding = new System.Windows.Forms.Padding(2, 6, 6, 2);
            this.panel59.Size = new System.Drawing.Size(112, 24);
            this.panel59.TabIndex = 0;
            // 
            // XZWCD
            // 
            this.XZWCD.Cursor = System.Windows.Forms.Cursors.Hand;
            this.XZWCD.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.XZWCD.EditScale = 0;
            this.XZWCD.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.XZWCD.Location = new System.Drawing.Point(2, 4);
            this.XZWCD.Name = "XZWCD";
            this.XZWCD.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.XZWCD.Properties.Appearance.Options.UseForeColor = true;
            this.XZWCD.Properties.Appearance.Options.UseTextOptions = true;
            this.XZWCD.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.XZWCD.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.XZWCD.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.XZWCD.Properties.MaxValue = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.XZWCD.Size = new System.Drawing.Size(71, 18);
            this.XZWCD.TabIndex = 42;
            this.XZWCD.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // label136
            // 
            this.label136.Dock = System.Windows.Forms.DockStyle.Right;
            this.label136.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label136.ForeColor = System.Drawing.Color.Blue;
            this.label136.Location = new System.Drawing.Point(73, 6);
            this.label136.Name = "label136";
            this.label136.Size = new System.Drawing.Size(33, 16);
            this.label136.TabIndex = 0;
            this.label136.Text = "m";
            // 
            // laXZWCD
            // 
            this.laXZWCD.Dock = System.Windows.Forms.DockStyle.Left;
            this.laXZWCD.Location = new System.Drawing.Point(0, 0);
            this.laXZWCD.Name = "laXZWCD";
            this.laXZWCD.Size = new System.Drawing.Size(66, 24);
            this.laXZWCD.TabIndex = 0;
            this.laXZWCD.Text = "线状物长度";
            this.laXZWCD.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label109
            // 
            this.label109.BackColor = System.Drawing.Color.Black;
            this.label109.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label109.Location = new System.Drawing.Point(0, 24);
            this.label109.Name = "label109";
            this.label109.Size = new System.Drawing.Size(438, 1);
            this.label109.TabIndex = 0;
            this.label109.Text = "label109";
            this.label109.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel88
            // 
            this.panel88.Controls.Add(this.panel8);
            this.panel88.Controls.Add(this.laXZWMJ);
            this.panel88.Controls.Add(this.panel12);
            this.panel88.Controls.Add(this.laXZWZL);
            this.panel88.Controls.Add(this.label98);
            this.panel88.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel88.Location = new System.Drawing.Point(0, 0);
            this.panel88.Name = "panel88";
            this.panel88.Size = new System.Drawing.Size(438, 25);
            this.panel88.TabIndex = 0;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.XZWMJ);
            this.panel8.Controls.Add(this.label135);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel8.Location = new System.Drawing.Point(244, 0);
            this.panel8.Name = "panel8";
            this.panel8.Padding = new System.Windows.Forms.Padding(2, 6, 6, 2);
            this.panel8.Size = new System.Drawing.Size(112, 24);
            this.panel8.TabIndex = 0;
            // 
            // XZWMJ
            // 
            this.XZWMJ.Cursor = System.Windows.Forms.Cursors.Hand;
            this.XZWMJ.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.XZWMJ.EditScale = 0;
            this.XZWMJ.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.XZWMJ.Location = new System.Drawing.Point(2, 4);
            this.XZWMJ.Name = "XZWMJ";
            this.XZWMJ.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.XZWMJ.Properties.Appearance.Options.UseForeColor = true;
            this.XZWMJ.Properties.Appearance.Options.UseTextOptions = true;
            this.XZWMJ.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.XZWMJ.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.XZWMJ.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.XZWMJ.Properties.MaxValue = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.XZWMJ.Size = new System.Drawing.Size(71, 18);
            this.XZWMJ.TabIndex = 41;
            this.XZWMJ.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // label135
            // 
            this.label135.Dock = System.Windows.Forms.DockStyle.Right;
            this.label135.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label135.ForeColor = System.Drawing.Color.Blue;
            this.label135.Location = new System.Drawing.Point(73, 6);
            this.label135.Name = "label135";
            this.label135.Size = new System.Drawing.Size(33, 16);
            this.label135.TabIndex = 0;
            this.label135.Text = "公顷";
            // 
            // laXZWMJ
            // 
            this.laXZWMJ.Cursor = System.Windows.Forms.Cursors.Default;
            this.laXZWMJ.Dock = System.Windows.Forms.DockStyle.Left;
            this.laXZWMJ.Location = new System.Drawing.Point(178, 0);
            this.laXZWMJ.Name = "laXZWMJ";
            this.laXZWMJ.Size = new System.Drawing.Size(66, 24);
            this.laXZWMJ.TabIndex = 0;
            this.laXZWMJ.Text = "线状物面积";
            this.laXZWMJ.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel12
            // 
            this.panel12.Controls.Add(this.XZWZL);
            this.panel12.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel12.Location = new System.Drawing.Point(66, 0);
            this.panel12.Name = "panel12";
            this.panel12.Padding = new System.Windows.Forms.Padding(2, 4, 4, 0);
            this.panel12.Size = new System.Drawing.Size(112, 24);
            this.panel12.TabIndex = 0;
            // 
            // XZWZL
            // 
            this.XZWZL.AssDispValue = true;
            this.XZWZL.Cursor = System.Windows.Forms.Cursors.Hand;
            this.XZWZL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.XZWZL.ForeColor = System.Drawing.Color.Blue;
            this.XZWZL.Location = new System.Drawing.Point(2, 4);
            this.XZWZL.Name = "XZWZL";
            this.XZWZL.Size = new System.Drawing.Size(106, 20);
            this.XZWZL.TabIndex = 40;
            this.XZWZL.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // laXZWZL
            // 
            this.laXZWZL.Cursor = System.Windows.Forms.Cursors.Default;
            this.laXZWZL.Dock = System.Windows.Forms.DockStyle.Left;
            this.laXZWZL.Location = new System.Drawing.Point(0, 0);
            this.laXZWZL.Name = "laXZWZL";
            this.laXZWZL.Size = new System.Drawing.Size(66, 24);
            this.laXZWZL.TabIndex = 0;
            this.laXZWZL.Text = "线状物种类";
            this.laXZWZL.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label98
            // 
            this.label98.BackColor = System.Drawing.Color.Black;
            this.label98.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label98.Location = new System.Drawing.Point(0, 24);
            this.label98.Name = "label98";
            this.label98.Size = new System.Drawing.Size(438, 1);
            this.label98.TabIndex = 0;
            this.label98.Text = "label98";
            this.label98.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label175
            // 
            this.label175.BackColor = System.Drawing.Color.Black;
            this.label175.Dock = System.Windows.Forms.DockStyle.Top;
            this.label175.Location = new System.Drawing.Point(1, 0);
            this.label175.Name = "label175";
            this.label175.Size = new System.Drawing.Size(438, 1);
            this.label175.TabIndex = 0;
            this.label175.Text = "label175";
            this.label175.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label176
            // 
            this.label176.BackColor = System.Drawing.Color.Black;
            this.label176.Dock = System.Windows.Forms.DockStyle.Left;
            this.label176.Location = new System.Drawing.Point(0, 0);
            this.label176.Name = "label176";
            this.label176.Size = new System.Drawing.Size(1, 51);
            this.label176.TabIndex = 0;
            this.label176.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label177
            // 
            this.label177.BackColor = System.Drawing.Color.Black;
            this.label177.Dock = System.Windows.Forms.DockStyle.Right;
            this.label177.Location = new System.Drawing.Point(439, 0);
            this.label177.Name = "label177";
            this.label177.Size = new System.Drawing.Size(1, 51);
            this.label177.TabIndex = 0;
            this.label177.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // spinEdit3
            // 
            this.spinEdit3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.spinEdit3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.spinEdit3.EditScale = 0;
            this.spinEdit3.EditValue = new decimal(new int[] {
            120,
            0,
            0,
            0});
            this.spinEdit3.Location = new System.Drawing.Point(2, 3);
            this.spinEdit3.Name = "spinEdit3";
            this.spinEdit3.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.spinEdit3.Properties.Appearance.Options.UseForeColor = true;
            this.spinEdit3.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.spinEdit3.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spinEdit3.Size = new System.Drawing.Size(98, 20);
            this.spinEdit3.TabIndex = 0;
            // 
            // textEdit36
            // 
            this.textEdit36.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textEdit36.EditValue = "";
            this.textEdit36.Location = new System.Drawing.Point(2, 2);
            this.textEdit36.Name = "textEdit36";
            this.textEdit36.Properties.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textEdit36.Properties.Appearance.ForeColor = System.Drawing.Color.Navy;
            this.textEdit36.Properties.Appearance.Options.UseFont = true;
            this.textEdit36.Properties.Appearance.Options.UseForeColor = true;
            this.textEdit36.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.textEdit36.Size = new System.Drawing.Size(98, 16);
            this.textEdit36.TabIndex = 0;
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
            this.panel89.Controls.Add(this.textEdit51);
            this.panel89.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel89.Location = new System.Drawing.Point(262, 0);
            this.panel89.Name = "panel89";
            this.panel89.Padding = new System.Windows.Forms.Padding(2, 2, 4, 2);
            this.panel89.Size = new System.Drawing.Size(130, 24);
            this.panel89.TabIndex = 0;
            // 
            // textEdit51
            // 
            this.textEdit51.Cursor = System.Windows.Forms.Cursors.Hand;
            this.textEdit51.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.textEdit51.EditValue = "2012年2月";
            this.textEdit51.Location = new System.Drawing.Point(2, 6);
            this.textEdit51.Name = "textEdit51";
            this.textEdit51.Properties.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textEdit51.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.textEdit51.Properties.Appearance.Options.UseFont = true;
            this.textEdit51.Properties.Appearance.Options.UseForeColor = true;
            this.textEdit51.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.textEdit51.Size = new System.Drawing.Size(124, 16);
            this.textEdit51.TabIndex = 0;
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
            // panel90
            // 
            this.panel90.Controls.Add(this.comboBoxEdit16);
            this.panel90.Controls.Add(this.textEdit52);
            this.panel90.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel90.Location = new System.Drawing.Point(66, 0);
            this.panel90.Name = "panel90";
            this.panel90.Padding = new System.Windows.Forms.Padding(2, 2, 10, 0);
            this.panel90.Size = new System.Drawing.Size(130, 24);
            this.panel90.TabIndex = 0;
            // 
            // comboBoxEdit16
            // 
            this.comboBoxEdit16.Cursor = System.Windows.Forms.Cursors.Hand;
            this.comboBoxEdit16.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBoxEdit16.EditValue = "造林";
            this.comboBoxEdit16.Location = new System.Drawing.Point(2, 2);
            this.comboBoxEdit16.Name = "comboBoxEdit16";
            this.comboBoxEdit16.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.comboBoxEdit16.Properties.Appearance.Options.UseForeColor = true;
            this.comboBoxEdit16.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.comboBoxEdit16.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEdit16.Properties.Items.AddRange(new object[] {
            "林翔区"});
            this.comboBoxEdit16.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.comboBoxEdit16.Size = new System.Drawing.Size(118, 18);
            this.comboBoxEdit16.TabIndex = 0;
            // 
            // textEdit52
            // 
            this.textEdit52.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textEdit52.EditValue = "不采白不采";
            this.textEdit52.Location = new System.Drawing.Point(2, 2);
            this.textEdit52.Name = "textEdit52";
            this.textEdit52.Properties.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textEdit52.Properties.Appearance.ForeColor = System.Drawing.Color.Navy;
            this.textEdit52.Properties.Appearance.Options.UseFont = true;
            this.textEdit52.Properties.Appearance.Options.UseForeColor = true;
            this.textEdit52.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.textEdit52.Size = new System.Drawing.Size(118, 16);
            this.textEdit52.TabIndex = 0;
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
            // panelPoint
            // 
            this.panelPoint.Controls.Add(this.panel52);
            this.panelPoint.Controls.Add(this.panel71);
            this.panelPoint.Controls.Add(this.label50);
            this.panelPoint.Controls.Add(this.label49);
            this.panelPoint.Controls.Add(this.label48);
            this.panelPoint.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelPoint.Location = new System.Drawing.Point(0, 583);
            this.panelPoint.Name = "panelPoint";
            this.panelPoint.Size = new System.Drawing.Size(440, 51);
            this.panelPoint.TabIndex = 0;
            // 
            // panel52
            // 
            this.panel52.Controls.Add(this.panel57);
            this.panel52.Controls.Add(this.laTJ_Y);
            this.panel52.Controls.Add(this.panel61);
            this.panel52.Controls.Add(this.laTJ_X);
            this.panel52.Controls.Add(this.label131);
            this.panel52.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel52.Location = new System.Drawing.Point(1, 26);
            this.panel52.Name = "panel52";
            this.panel52.Size = new System.Drawing.Size(438, 25);
            this.panel52.TabIndex = 0;
            // 
            // panel57
            // 
            this.panel57.Controls.Add(this.TJ_Y);
            this.panel57.Controls.Add(this.label132);
            this.panel57.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel57.Location = new System.Drawing.Point(256, 0);
            this.panel57.Name = "panel57";
            this.panel57.Padding = new System.Windows.Forms.Padding(2, 6, 6, 2);
            this.panel57.Size = new System.Drawing.Size(112, 24);
            this.panel57.TabIndex = 0;
            // 
            // TJ_Y
            // 
            this.TJ_Y.Cursor = System.Windows.Forms.Cursors.Hand;
            this.TJ_Y.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.TJ_Y.EditScale = 0;
            this.TJ_Y.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.TJ_Y.Location = new System.Drawing.Point(2, 4);
            this.TJ_Y.Name = "TJ_Y";
            this.TJ_Y.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.TJ_Y.Properties.Appearance.Options.UseForeColor = true;
            this.TJ_Y.Properties.Appearance.Options.UseTextOptions = true;
            this.TJ_Y.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.TJ_Y.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.TJ_Y.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.TJ_Y.Properties.MaxValue = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.TJ_Y.Size = new System.Drawing.Size(79, 18);
            this.TJ_Y.TabIndex = 46;
            this.TJ_Y.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // label132
            // 
            this.label132.Dock = System.Windows.Forms.DockStyle.Right;
            this.label132.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label132.ForeColor = System.Drawing.Color.Blue;
            this.label132.Location = new System.Drawing.Point(81, 6);
            this.label132.Name = "label132";
            this.label132.Size = new System.Drawing.Size(25, 16);
            this.label132.TabIndex = 0;
            this.label132.Text = "m";
            // 
            // laTJ_Y
            // 
            this.laTJ_Y.Dock = System.Windows.Forms.DockStyle.Left;
            this.laTJ_Y.Location = new System.Drawing.Point(184, 0);
            this.laTJ_Y.Name = "laTJ_Y";
            this.laTJ_Y.Size = new System.Drawing.Size(72, 24);
            this.laTJ_Y.TabIndex = 0;
            this.laTJ_Y.Text = "塔基点Y坐标";
            this.laTJ_Y.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel61
            // 
            this.panel61.Controls.Add(this.TJ_X);
            this.panel61.Controls.Add(this.label83);
            this.panel61.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel61.Location = new System.Drawing.Point(72, 0);
            this.panel61.Name = "panel61";
            this.panel61.Padding = new System.Windows.Forms.Padding(2, 6, 6, 2);
            this.panel61.Size = new System.Drawing.Size(112, 24);
            this.panel61.TabIndex = 0;
            // 
            // TJ_X
            // 
            this.TJ_X.Cursor = System.Windows.Forms.Cursors.Hand;
            this.TJ_X.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.TJ_X.EditScale = 0;
            this.TJ_X.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.TJ_X.Location = new System.Drawing.Point(2, 4);
            this.TJ_X.Name = "TJ_X";
            this.TJ_X.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.TJ_X.Properties.Appearance.Options.UseForeColor = true;
            this.TJ_X.Properties.Appearance.Options.UseTextOptions = true;
            this.TJ_X.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.TJ_X.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.TJ_X.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.TJ_X.Properties.MaxValue = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.TJ_X.Size = new System.Drawing.Size(79, 18);
            this.TJ_X.TabIndex = 45;
            this.TJ_X.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // label83
            // 
            this.label83.Dock = System.Windows.Forms.DockStyle.Right;
            this.label83.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label83.ForeColor = System.Drawing.Color.Blue;
            this.label83.Location = new System.Drawing.Point(81, 6);
            this.label83.Name = "label83";
            this.label83.Size = new System.Drawing.Size(25, 16);
            this.label83.TabIndex = 0;
            this.label83.Text = "m";
            // 
            // laTJ_X
            // 
            this.laTJ_X.Dock = System.Windows.Forms.DockStyle.Left;
            this.laTJ_X.Location = new System.Drawing.Point(0, 0);
            this.laTJ_X.Name = "laTJ_X";
            this.laTJ_X.Size = new System.Drawing.Size(72, 24);
            this.laTJ_X.TabIndex = 0;
            this.laTJ_X.Text = "塔基点X坐标";
            this.laTJ_X.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label131
            // 
            this.label131.BackColor = System.Drawing.Color.Black;
            this.label131.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label131.Location = new System.Drawing.Point(0, 24);
            this.label131.Name = "label131";
            this.label131.Size = new System.Drawing.Size(438, 1);
            this.label131.TabIndex = 0;
            this.label131.Text = "label131";
            this.label131.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel71
            // 
            this.panel71.Controls.Add(this.panel74);
            this.panel71.Controls.Add(this.laTJMC);
            this.panel71.Controls.Add(this.label85);
            this.panel71.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel71.Location = new System.Drawing.Point(1, 1);
            this.panel71.Name = "panel71";
            this.panel71.Size = new System.Drawing.Size(438, 25);
            this.panel71.TabIndex = 0;
            // 
            // panel74
            // 
            this.panel74.Controls.Add(this.TJMC);
            this.panel74.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel74.Location = new System.Drawing.Point(72, 0);
            this.panel74.Name = "panel74";
            this.panel74.Padding = new System.Windows.Forms.Padding(2, 6, 8, 0);
            this.panel74.Size = new System.Drawing.Size(296, 24);
            this.panel74.TabIndex = 0;
            // 
            // TJMC
            // 
            this.TJMC.Cursor = System.Windows.Forms.Cursors.Hand;
            this.TJMC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TJMC.EditValue = "";
            this.TJMC.Location = new System.Drawing.Point(2, 6);
            this.TJMC.Name = "TJMC";
            this.TJMC.Properties.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TJMC.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.TJMC.Properties.Appearance.Options.UseFont = true;
            this.TJMC.Properties.Appearance.Options.UseForeColor = true;
            this.TJMC.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.TJMC.Properties.MaxLength = 4;
            this.TJMC.Size = new System.Drawing.Size(286, 16);
            this.TJMC.TabIndex = 44;
            this.TJMC.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // laTJMC
            // 
            this.laTJMC.Dock = System.Windows.Forms.DockStyle.Left;
            this.laTJMC.Location = new System.Drawing.Point(0, 0);
            this.laTJMC.Name = "laTJMC";
            this.laTJMC.Size = new System.Drawing.Size(72, 24);
            this.laTJMC.TabIndex = 0;
            this.laTJMC.Text = "塔基名称";
            this.laTJMC.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label85
            // 
            this.label85.BackColor = System.Drawing.Color.Black;
            this.label85.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label85.Location = new System.Drawing.Point(0, 24);
            this.label85.Name = "label85";
            this.label85.Size = new System.Drawing.Size(438, 1);
            this.label85.TabIndex = 0;
            this.label85.Text = "label85";
            this.label85.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label50
            // 
            this.label50.BackColor = System.Drawing.Color.Black;
            this.label50.Dock = System.Windows.Forms.DockStyle.Right;
            this.label50.Location = new System.Drawing.Point(439, 1);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(1, 50);
            this.label50.TabIndex = 0;
            this.label50.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label49
            // 
            this.label49.BackColor = System.Drawing.Color.Black;
            this.label49.Dock = System.Windows.Forms.DockStyle.Left;
            this.label49.Location = new System.Drawing.Point(0, 1);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(1, 50);
            this.label49.TabIndex = 0;
            this.label49.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label48
            // 
            this.label48.BackColor = System.Drawing.Color.Black;
            this.label48.Dock = System.Windows.Forms.DockStyle.Top;
            this.label48.Location = new System.Drawing.Point(0, 0);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(440, 1);
            this.label48.TabIndex = 0;
            this.label48.Text = "label48";
            this.label48.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label43
            // 
            this.label43.Dock = System.Windows.Forms.DockStyle.Top;
            this.label43.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label43.Location = new System.Drawing.Point(0, 102);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(440, 26);
            this.label43.TabIndex = 0;
            this.label43.Text = "  变更情况";
            this.label43.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelOther
            // 
            this.panelOther.Controls.Add(this.label53);
            this.panelOther.Controls.Add(this.panel86);
            this.panelOther.Controls.Add(this.label110);
            this.panelOther.Controls.Add(this.label111);
            this.panelOther.Controls.Add(this.label112);
            this.panelOther.Controls.Add(this.label115);
            this.panelOther.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelOther.Location = new System.Drawing.Point(0, 128);
            this.panelOther.Name = "panelOther";
            this.panelOther.Size = new System.Drawing.Size(440, 26);
            this.panelOther.TabIndex = 0;
            // 
            // label53
            // 
            this.label53.BackColor = System.Drawing.Color.Black;
            this.label53.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label53.Location = new System.Drawing.Point(1, 24);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(438, 1);
            this.label53.TabIndex = 0;
            this.label53.Text = "label53";
            this.label53.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel86
            // 
            this.panel86.Controls.Add(this.panel91);
            this.panel86.Controls.Add(this.laGXSJ);
            this.panel86.Controls.Add(this.panel92);
            this.panel86.Controls.Add(this.laBHYY);
            this.panel86.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel86.Location = new System.Drawing.Point(1, 1);
            this.panel86.Name = "panel86";
            this.panel86.Size = new System.Drawing.Size(438, 25);
            this.panel86.TabIndex = 0;
            // 
            // panel91
            // 
            this.panel91.Controls.Add(this.GXSJ);
            this.panel91.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel91.Location = new System.Drawing.Point(244, 0);
            this.panel91.Name = "panel91";
            this.panel91.Padding = new System.Windows.Forms.Padding(2, 1, 8, 3);
            this.panel91.Size = new System.Drawing.Size(113, 25);
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
            this.GXSJ.Size = new System.Drawing.Size(103, 18);
            this.GXSJ.TabIndex = 48;
            this.GXSJ.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // laGXSJ
            // 
            this.laGXSJ.Dock = System.Windows.Forms.DockStyle.Left;
            this.laGXSJ.Location = new System.Drawing.Point(178, 0);
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
            this.panel92.Size = new System.Drawing.Size(112, 25);
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
            this.BHYY.Size = new System.Drawing.Size(106, 20);
            this.BHYY.TabIndex = 47;
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
            this.label110.Size = new System.Drawing.Size(438, 1);
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
            this.label111.Size = new System.Drawing.Size(438, 1);
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
            this.label115.Location = new System.Drawing.Point(439, 0);
            this.label115.Name = "label115";
            this.label115.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.label115.Size = new System.Drawing.Size(1, 26);
            this.label115.TabIndex = 0;
            this.label115.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Appearance.BackColor = System.Drawing.Color.White;
            this.xtraTabControl1.Appearance.Options.UseBackColor = true;
            this.xtraTabControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.xtraTabControl1.BorderStylePage = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl1.Location = new System.Drawing.Point(2, 2);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPage1;
            this.xtraTabControl1.Size = new System.Drawing.Size(446, 666);
            this.xtraTabControl1.TabIndex = 0;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1,
            this.xtraTabPage2});
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Appearance.PageClient.BackColor = System.Drawing.Color.White;
            this.xtraTabPage1.Appearance.PageClient.Options.UseBackColor = true;
            this.xtraTabPage1.Controls.Add(this.panelControl1);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(440, 637);
            this.xtraTabPage1.Text = "征占用林地调查";
            // 
            // panelControl1
            // 
            this.panelControl1.BackColor = System.Drawing.Color.White;
            this.panelControl1.Controls.Add(this.panelPoint);
            this.panelControl1.Controls.Add(this.panelXZW);
            this.panelControl1.Controls.Add(this.label103);
            this.panelControl1.Controls.Add(this.panelWoodsInfo);
            this.panelControl1.Controls.Add(this.label70);
            this.panelControl1.Controls.Add(this.panelOther);
            this.panelControl1.Controls.Add(this.label43);
            this.panelControl1.Controls.Add(this.panelBasicInfo);
            this.panelControl1.Controls.Add(this.label7);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(440, 637);
            this.panelControl1.TabIndex = 0;
            // 
            // xtraTabPage2
            // 
            this.xtraTabPage2.Controls.Add(this.panelControl2);
            this.xtraTabPage2.Name = "xtraTabPage2";
            this.xtraTabPage2.Size = new System.Drawing.Size(440, 637);
            this.xtraTabPage2.Text = "征占用项目调查";
            // 
            // panelControl2
            // 
            this.panelControl2.BackColor = System.Drawing.Color.White;
            this.panelControl2.Controls.Add(this.panelZZ);
            this.panelControl2.Controls.Add(this.label93);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(0, 0);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(440, 637);
            this.panelControl2.TabIndex = 0;
            // 
            // panelZZ
            // 
            this.panelZZ.Controls.Add(this.panel36);
            this.panelZZ.Controls.Add(this.label90);
            this.panelZZ.Controls.Add(this.label91);
            this.panelZZ.Controls.Add(this.label92);
            this.panelZZ.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelZZ.Location = new System.Drawing.Point(0, 26);
            this.panelZZ.Name = "panelZZ";
            this.panelZZ.Size = new System.Drawing.Size(440, 376);
            this.panelZZ.TabIndex = 0;
            // 
            // panel36
            // 
            this.panel36.Controls.Add(this.panel15);
            this.panel36.Controls.Add(this.panel96);
            this.panel36.Controls.Add(this.panel87);
            this.panel36.Controls.Add(this.panel49);
            this.panel36.Controls.Add(this.panel82);
            this.panel36.Controls.Add(this.panel78);
            this.panel36.Controls.Add(this.panel69);
            this.panel36.Controls.Add(this.panel13);
            this.panel36.Controls.Add(this.panel109);
            this.panel36.Controls.Add(this.panel64);
            this.panel36.Controls.Add(this.panel60);
            this.panel36.Controls.Add(this.panel45);
            this.panel36.Controls.Add(this.panel54);
            this.panel36.Controls.Add(this.panel113);
            this.panel36.Controls.Add(this.panel53);
            this.panel36.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel36.Location = new System.Drawing.Point(1, 1);
            this.panel36.Name = "panel36";
            this.panel36.Size = new System.Drawing.Size(438, 375);
            this.panel36.TabIndex = 0;
            // 
            // panel15
            // 
            this.panel15.Controls.Add(this.panel28);
            this.panel15.Controls.Add(this.laBZ);
            this.panel15.Controls.Add(this.label74);
            this.panel15.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel15.Location = new System.Drawing.Point(0, 350);
            this.panel15.Name = "panel15";
            this.panel15.Size = new System.Drawing.Size(438, 25);
            this.panel15.TabIndex = 0;
            // 
            // panel28
            // 
            this.panel28.Controls.Add(this.BZ);
            this.panel28.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel28.Location = new System.Drawing.Point(53, 0);
            this.panel28.Name = "panel28";
            this.panel28.Padding = new System.Windows.Forms.Padding(2, 6, 8, 0);
            this.panel28.Size = new System.Drawing.Size(375, 24);
            this.panel28.TabIndex = 0;
            // 
            // BZ
            // 
            this.BZ.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BZ.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BZ.EditValue = "";
            this.BZ.Location = new System.Drawing.Point(2, 6);
            this.BZ.Name = "BZ";
            this.BZ.Properties.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BZ.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.BZ.Properties.Appearance.Options.UseFont = true;
            this.BZ.Properties.Appearance.Options.UseForeColor = true;
            this.BZ.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.BZ.Size = new System.Drawing.Size(365, 16);
            this.BZ.TabIndex = 73;
            this.BZ.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // laBZ
            // 
            this.laBZ.Dock = System.Windows.Forms.DockStyle.Left;
            this.laBZ.Location = new System.Drawing.Point(0, 0);
            this.laBZ.Name = "laBZ";
            this.laBZ.Size = new System.Drawing.Size(53, 24);
            this.laBZ.TabIndex = 0;
            this.laBZ.Text = "备注";
            this.laBZ.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label74
            // 
            this.label74.BackColor = System.Drawing.Color.Black;
            this.label74.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label74.Location = new System.Drawing.Point(0, 24);
            this.label74.Name = "label74";
            this.label74.Size = new System.Drawing.Size(438, 1);
            this.label74.TabIndex = 0;
            this.label74.Text = "label74";
            this.label74.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel96
            // 
            this.panel96.Controls.Add(this.panel99);
            this.panel96.Controls.Add(this.laZFYHJ);
            this.panel96.Controls.Add(this.label127);
            this.panel96.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel96.Location = new System.Drawing.Point(0, 325);
            this.panel96.Name = "panel96";
            this.panel96.Size = new System.Drawing.Size(438, 25);
            this.panel96.TabIndex = 0;
            // 
            // panel99
            // 
            this.panel99.Controls.Add(this.ZFYHJ);
            this.panel99.Controls.Add(this.label28);
            this.panel99.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel99.Location = new System.Drawing.Point(90, 0);
            this.panel99.Name = "panel99";
            this.panel99.Padding = new System.Windows.Forms.Padding(2, 6, 6, 2);
            this.panel99.Size = new System.Drawing.Size(116, 24);
            this.panel99.TabIndex = 0;
            // 
            // ZFYHJ
            // 
            this.ZFYHJ.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ZFYHJ.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ZFYHJ.EditScale = 0;
            this.ZFYHJ.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ZFYHJ.Location = new System.Drawing.Point(2, 4);
            this.ZFYHJ.Name = "ZFYHJ";
            this.ZFYHJ.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.ZFYHJ.Properties.Appearance.Options.UseForeColor = true;
            this.ZFYHJ.Properties.Appearance.Options.UseTextOptions = true;
            this.ZFYHJ.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.ZFYHJ.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.ZFYHJ.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.ZFYHJ.Properties.MaxValue = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.ZFYHJ.Size = new System.Drawing.Size(86, 18);
            this.ZFYHJ.TabIndex = 72;
            this.ZFYHJ.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // label28
            // 
            this.label28.Dock = System.Windows.Forms.DockStyle.Right;
            this.label28.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label28.ForeColor = System.Drawing.Color.Blue;
            this.label28.Location = new System.Drawing.Point(88, 6);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(22, 16);
            this.label28.TabIndex = 0;
            this.label28.Text = "元";
            // 
            // laZFYHJ
            // 
            this.laZFYHJ.Dock = System.Windows.Forms.DockStyle.Left;
            this.laZFYHJ.Location = new System.Drawing.Point(0, 0);
            this.laZFYHJ.Name = "laZFYHJ";
            this.laZFYHJ.Size = new System.Drawing.Size(90, 24);
            this.laZFYHJ.TabIndex = 0;
            this.laZFYHJ.Text = "总费用合计";
            this.laZFYHJ.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label127
            // 
            this.label127.BackColor = System.Drawing.Color.Black;
            this.label127.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label127.Location = new System.Drawing.Point(0, 24);
            this.label127.Name = "label127";
            this.label127.Size = new System.Drawing.Size(438, 1);
            this.label127.TabIndex = 0;
            this.label127.Text = "label127";
            this.label127.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel87
            // 
            this.panel87.Controls.Add(this.panel94);
            this.panel87.Controls.Add(this.laZBHFF);
            this.panel87.Controls.Add(this.panel95);
            this.panel87.Controls.Add(this.laZBHFDJ);
            this.panel87.Controls.Add(this.label123);
            this.panel87.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel87.Location = new System.Drawing.Point(0, 300);
            this.panel87.Name = "panel87";
            this.panel87.Size = new System.Drawing.Size(438, 25);
            this.panel87.TabIndex = 0;
            // 
            // panel94
            // 
            this.panel94.Controls.Add(this.ZBHFF);
            this.panel94.Controls.Add(this.label97);
            this.panel94.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel94.Location = new System.Drawing.Point(274, 0);
            this.panel94.Name = "panel94";
            this.panel94.Padding = new System.Windows.Forms.Padding(2, 6, 6, 2);
            this.panel94.Size = new System.Drawing.Size(126, 24);
            this.panel94.TabIndex = 0;
            // 
            // ZBHFF
            // 
            this.ZBHFF.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ZBHFF.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ZBHFF.EditScale = 0;
            this.ZBHFF.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ZBHFF.Location = new System.Drawing.Point(2, 4);
            this.ZBHFF.Name = "ZBHFF";
            this.ZBHFF.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.ZBHFF.Properties.Appearance.Options.UseForeColor = true;
            this.ZBHFF.Properties.Appearance.Options.UseTextOptions = true;
            this.ZBHFF.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.ZBHFF.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.ZBHFF.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.ZBHFF.Properties.MaxValue = new decimal(new int[] {
            1410065408,
            2,
            0,
            0});
            this.ZBHFF.Size = new System.Drawing.Size(96, 18);
            this.ZBHFF.TabIndex = 71;
            this.ZBHFF.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // label97
            // 
            this.label97.Dock = System.Windows.Forms.DockStyle.Right;
            this.label97.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label97.ForeColor = System.Drawing.Color.Blue;
            this.label97.Location = new System.Drawing.Point(98, 6);
            this.label97.Name = "label97";
            this.label97.Size = new System.Drawing.Size(22, 16);
            this.label97.TabIndex = 0;
            this.label97.Text = "元";
            // 
            // laZBHFF
            // 
            this.laZBHFF.Dock = System.Windows.Forms.DockStyle.Left;
            this.laZBHFF.Location = new System.Drawing.Point(206, 0);
            this.laZBHFF.Name = "laZBHFF";
            this.laZBHFF.Size = new System.Drawing.Size(68, 24);
            this.laZBHFF.TabIndex = 0;
            this.laZBHFF.Text = "植被恢复费";
            this.laZBHFF.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel95
            // 
            this.panel95.Controls.Add(this.ZBHFDJ);
            this.panel95.Controls.Add(this.label72);
            this.panel95.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel95.Location = new System.Drawing.Point(90, 0);
            this.panel95.Name = "panel95";
            this.panel95.Padding = new System.Windows.Forms.Padding(2, 6, 6, 2);
            this.panel95.Size = new System.Drawing.Size(116, 24);
            this.panel95.TabIndex = 0;
            // 
            // ZBHFDJ
            // 
            this.ZBHFDJ.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ZBHFDJ.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ZBHFDJ.EditScale = 0;
            this.ZBHFDJ.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ZBHFDJ.Location = new System.Drawing.Point(2, 4);
            this.ZBHFDJ.Name = "ZBHFDJ";
            this.ZBHFDJ.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.ZBHFDJ.Properties.Appearance.Options.UseForeColor = true;
            this.ZBHFDJ.Properties.Appearance.Options.UseTextOptions = true;
            this.ZBHFDJ.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.ZBHFDJ.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.ZBHFDJ.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.ZBHFDJ.Properties.MaxValue = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.ZBHFDJ.Size = new System.Drawing.Size(57, 18);
            this.ZBHFDJ.TabIndex = 70;
            this.ZBHFDJ.EditValueChanged += new System.EventHandler(this.ZBHFDJ_EditValueChanged);
            this.ZBHFDJ.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // label72
            // 
            this.label72.Dock = System.Windows.Forms.DockStyle.Right;
            this.label72.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label72.ForeColor = System.Drawing.Color.Blue;
            this.label72.Location = new System.Drawing.Point(59, 6);
            this.label72.Name = "label72";
            this.label72.Size = new System.Drawing.Size(51, 16);
            this.label72.TabIndex = 0;
            this.label72.Text = "元/平米";
            // 
            // laZBHFDJ
            // 
            this.laZBHFDJ.Dock = System.Windows.Forms.DockStyle.Left;
            this.laZBHFDJ.Location = new System.Drawing.Point(0, 0);
            this.laZBHFDJ.Name = "laZBHFDJ";
            this.laZBHFDJ.Size = new System.Drawing.Size(90, 24);
            this.laZBHFDJ.TabIndex = 0;
            this.laZBHFDJ.Text = "植被恢复费单价";
            this.laZBHFDJ.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label123
            // 
            this.label123.BackColor = System.Drawing.Color.Black;
            this.label123.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label123.Location = new System.Drawing.Point(0, 24);
            this.label123.Name = "label123";
            this.label123.Size = new System.Drawing.Size(438, 1);
            this.label123.TabIndex = 0;
            this.label123.Text = "label123";
            this.label123.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel49
            // 
            this.panel49.Controls.Add(this.panel98);
            this.panel49.Controls.Add(this.laBCFHJ);
            this.panel49.Controls.Add(this.label120);
            this.panel49.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel49.Location = new System.Drawing.Point(0, 275);
            this.panel49.Name = "panel49";
            this.panel49.Size = new System.Drawing.Size(438, 25);
            this.panel49.TabIndex = 0;
            // 
            // panel98
            // 
            this.panel98.Controls.Add(this.BCFHJ);
            this.panel98.Controls.Add(this.label116);
            this.panel98.Controls.Add(this.zlComboBox16);
            this.panel98.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel98.Location = new System.Drawing.Point(90, 0);
            this.panel98.Name = "panel98";
            this.panel98.Padding = new System.Windows.Forms.Padding(2, 6, 6, 2);
            this.panel98.Size = new System.Drawing.Size(126, 24);
            this.panel98.TabIndex = 0;
            // 
            // BCFHJ
            // 
            this.BCFHJ.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BCFHJ.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BCFHJ.EditScale = 0;
            this.BCFHJ.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.BCFHJ.Location = new System.Drawing.Point(2, 4);
            this.BCFHJ.Name = "BCFHJ";
            this.BCFHJ.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.BCFHJ.Properties.Appearance.Options.UseForeColor = true;
            this.BCFHJ.Properties.Appearance.Options.UseTextOptions = true;
            this.BCFHJ.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.BCFHJ.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.BCFHJ.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.BCFHJ.Properties.MaxValue = new decimal(new int[] {
            1410065408,
            2,
            0,
            0});
            this.BCFHJ.Size = new System.Drawing.Size(96, 18);
            this.BCFHJ.TabIndex = 69;
            this.BCFHJ.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // label116
            // 
            this.label116.Dock = System.Windows.Forms.DockStyle.Right;
            this.label116.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label116.ForeColor = System.Drawing.Color.Blue;
            this.label116.Location = new System.Drawing.Point(98, 6);
            this.label116.Name = "label116";
            this.label116.Size = new System.Drawing.Size(22, 16);
            this.label116.TabIndex = 0;
            this.label116.Text = "元";
            // 
            // zlComboBox16
            // 
            this.zlComboBox16.AssDispValue = true;
            this.zlComboBox16.Cursor = System.Windows.Forms.Cursors.Hand;
            this.zlComboBox16.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zlComboBox16.ForeColor = System.Drawing.Color.Blue;
            this.zlComboBox16.Location = new System.Drawing.Point(2, 6);
            this.zlComboBox16.Name = "zlComboBox16";
            this.zlComboBox16.Size = new System.Drawing.Size(118, 20);
            this.zlComboBox16.TabIndex = 0;
            // 
            // laBCFHJ
            // 
            this.laBCFHJ.Dock = System.Windows.Forms.DockStyle.Left;
            this.laBCFHJ.Location = new System.Drawing.Point(0, 0);
            this.laBCFHJ.Name = "laBCFHJ";
            this.laBCFHJ.Size = new System.Drawing.Size(90, 24);
            this.laBCFHJ.TabIndex = 0;
            this.laBCFHJ.Text = "补偿费合计";
            this.laBCFHJ.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label120
            // 
            this.label120.BackColor = System.Drawing.Color.Black;
            this.label120.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label120.Location = new System.Drawing.Point(0, 24);
            this.label120.Name = "label120";
            this.label120.Size = new System.Drawing.Size(438, 1);
            this.label120.TabIndex = 0;
            this.label120.Text = "label120";
            this.label120.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel82
            // 
            this.panel82.Controls.Add(this.panel84);
            this.panel82.Controls.Add(this.laLMBCF);
            this.panel82.Controls.Add(this.panel85);
            this.panel82.Controls.Add(this.laLMBCDJ);
            this.panel82.Controls.Add(this.label119);
            this.panel82.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel82.Location = new System.Drawing.Point(0, 250);
            this.panel82.Name = "panel82";
            this.panel82.Size = new System.Drawing.Size(438, 25);
            this.panel82.TabIndex = 0;
            // 
            // panel84
            // 
            this.panel84.Controls.Add(this.LMBCF);
            this.panel84.Controls.Add(this.label88);
            this.panel84.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel84.Location = new System.Drawing.Point(274, 0);
            this.panel84.Name = "panel84";
            this.panel84.Padding = new System.Windows.Forms.Padding(2, 6, 6, 2);
            this.panel84.Size = new System.Drawing.Size(126, 24);
            this.panel84.TabIndex = 0;
            // 
            // LMBCF
            // 
            this.LMBCF.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LMBCF.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.LMBCF.EditScale = 0;
            this.LMBCF.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.LMBCF.Location = new System.Drawing.Point(2, 4);
            this.LMBCF.Name = "LMBCF";
            this.LMBCF.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.LMBCF.Properties.Appearance.Options.UseForeColor = true;
            this.LMBCF.Properties.Appearance.Options.UseTextOptions = true;
            this.LMBCF.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.LMBCF.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.LMBCF.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.LMBCF.Properties.MaxValue = new decimal(new int[] {
            1410065408,
            2,
            0,
            0});
            this.LMBCF.Size = new System.Drawing.Size(96, 18);
            this.LMBCF.TabIndex = 68;
            this.LMBCF.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // label88
            // 
            this.label88.Dock = System.Windows.Forms.DockStyle.Right;
            this.label88.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label88.ForeColor = System.Drawing.Color.Blue;
            this.label88.Location = new System.Drawing.Point(98, 6);
            this.label88.Name = "label88";
            this.label88.Size = new System.Drawing.Size(22, 16);
            this.label88.TabIndex = 0;
            this.label88.Text = "元";
            // 
            // laLMBCF
            // 
            this.laLMBCF.Dock = System.Windows.Forms.DockStyle.Left;
            this.laLMBCF.Location = new System.Drawing.Point(206, 0);
            this.laLMBCF.Name = "laLMBCF";
            this.laLMBCF.Size = new System.Drawing.Size(68, 24);
            this.laLMBCF.TabIndex = 0;
            this.laLMBCF.Text = "林木补偿费";
            this.laLMBCF.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel85
            // 
            this.panel85.Controls.Add(this.LMBCDJ);
            this.panel85.Controls.Add(this.label31);
            this.panel85.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel85.Location = new System.Drawing.Point(90, 0);
            this.panel85.Name = "panel85";
            this.panel85.Padding = new System.Windows.Forms.Padding(2, 6, 6, 2);
            this.panel85.Size = new System.Drawing.Size(116, 24);
            this.panel85.TabIndex = 0;
            // 
            // LMBCDJ
            // 
            this.LMBCDJ.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LMBCDJ.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.LMBCDJ.EditScale = 0;
            this.LMBCDJ.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.LMBCDJ.Location = new System.Drawing.Point(2, 4);
            this.LMBCDJ.Name = "LMBCDJ";
            this.LMBCDJ.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.LMBCDJ.Properties.Appearance.Options.UseForeColor = true;
            this.LMBCDJ.Properties.Appearance.Options.UseTextOptions = true;
            this.LMBCDJ.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.LMBCDJ.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.LMBCDJ.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.LMBCDJ.Properties.MaxValue = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.LMBCDJ.Size = new System.Drawing.Size(70, 18);
            this.LMBCDJ.TabIndex = 67;
            this.LMBCDJ.EditValueChanged += new System.EventHandler(this.LMBCDJ_EditValueChanged);
            this.LMBCDJ.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // label31
            // 
            this.label31.Dock = System.Windows.Forms.DockStyle.Right;
            this.label31.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label31.ForeColor = System.Drawing.Color.Blue;
            this.label31.Location = new System.Drawing.Point(72, 6);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(38, 16);
            this.label31.TabIndex = 0;
            this.label31.Text = "元/亩";
            // 
            // laLMBCDJ
            // 
            this.laLMBCDJ.Dock = System.Windows.Forms.DockStyle.Left;
            this.laLMBCDJ.Location = new System.Drawing.Point(0, 0);
            this.laLMBCDJ.Name = "laLMBCDJ";
            this.laLMBCDJ.Size = new System.Drawing.Size(90, 24);
            this.laLMBCDJ.TabIndex = 0;
            this.laLMBCDJ.Text = "林木补偿费单价";
            this.laLMBCDJ.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label119
            // 
            this.label119.BackColor = System.Drawing.Color.Black;
            this.label119.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label119.Location = new System.Drawing.Point(0, 24);
            this.label119.Name = "label119";
            this.label119.Size = new System.Drawing.Size(438, 1);
            this.label119.TabIndex = 0;
            this.label119.Text = "label119";
            this.label119.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel78
            // 
            this.panel78.Controls.Add(this.panel80);
            this.panel78.Controls.Add(this.laLDAZF);
            this.panel78.Controls.Add(this.panel81);
            this.panel78.Controls.Add(this.laLDAZFDJ);
            this.panel78.Controls.Add(this.label101);
            this.panel78.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel78.Location = new System.Drawing.Point(0, 225);
            this.panel78.Name = "panel78";
            this.panel78.Size = new System.Drawing.Size(438, 25);
            this.panel78.TabIndex = 0;
            // 
            // panel80
            // 
            this.panel80.Controls.Add(this.LDAZF);
            this.panel80.Controls.Add(this.label87);
            this.panel80.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel80.Location = new System.Drawing.Point(274, 0);
            this.panel80.Name = "panel80";
            this.panel80.Padding = new System.Windows.Forms.Padding(2, 6, 6, 2);
            this.panel80.Size = new System.Drawing.Size(126, 24);
            this.panel80.TabIndex = 0;
            // 
            // LDAZF
            // 
            this.LDAZF.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LDAZF.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.LDAZF.EditScale = 0;
            this.LDAZF.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.LDAZF.Location = new System.Drawing.Point(2, 4);
            this.LDAZF.Name = "LDAZF";
            this.LDAZF.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.LDAZF.Properties.Appearance.Options.UseForeColor = true;
            this.LDAZF.Properties.Appearance.Options.UseTextOptions = true;
            this.LDAZF.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.LDAZF.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.LDAZF.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.LDAZF.Properties.MaxValue = new decimal(new int[] {
            1410065408,
            2,
            0,
            0});
            this.LDAZF.Size = new System.Drawing.Size(96, 18);
            this.LDAZF.TabIndex = 66;
            this.LDAZF.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // label87
            // 
            this.label87.Dock = System.Windows.Forms.DockStyle.Right;
            this.label87.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label87.ForeColor = System.Drawing.Color.Blue;
            this.label87.Location = new System.Drawing.Point(98, 6);
            this.label87.Name = "label87";
            this.label87.Size = new System.Drawing.Size(22, 16);
            this.label87.TabIndex = 0;
            this.label87.Text = "元";
            // 
            // laLDAZF
            // 
            this.laLDAZF.Dock = System.Windows.Forms.DockStyle.Left;
            this.laLDAZF.Location = new System.Drawing.Point(206, 0);
            this.laLDAZF.Name = "laLDAZF";
            this.laLDAZF.Size = new System.Drawing.Size(68, 24);
            this.laLDAZF.TabIndex = 0;
            this.laLDAZF.Text = "林地安置费";
            this.laLDAZF.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel81
            // 
            this.panel81.Controls.Add(this.LDAZFDJ);
            this.panel81.Controls.Add(this.label29);
            this.panel81.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel81.Location = new System.Drawing.Point(90, 0);
            this.panel81.Name = "panel81";
            this.panel81.Padding = new System.Windows.Forms.Padding(2, 6, 6, 2);
            this.panel81.Size = new System.Drawing.Size(116, 24);
            this.panel81.TabIndex = 0;
            // 
            // LDAZFDJ
            // 
            this.LDAZFDJ.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LDAZFDJ.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.LDAZFDJ.EditScale = 0;
            this.LDAZFDJ.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.LDAZFDJ.Location = new System.Drawing.Point(2, 4);
            this.LDAZFDJ.Name = "LDAZFDJ";
            this.LDAZFDJ.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.LDAZFDJ.Properties.Appearance.Options.UseForeColor = true;
            this.LDAZFDJ.Properties.Appearance.Options.UseTextOptions = true;
            this.LDAZFDJ.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.LDAZFDJ.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.LDAZFDJ.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.LDAZFDJ.Properties.MaxValue = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.LDAZFDJ.Size = new System.Drawing.Size(70, 18);
            this.LDAZFDJ.TabIndex = 65;
            this.LDAZFDJ.EditValueChanged += new System.EventHandler(this.LDAZFDJ_EditValueChanged);
            this.LDAZFDJ.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // label29
            // 
            this.label29.Dock = System.Windows.Forms.DockStyle.Right;
            this.label29.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label29.ForeColor = System.Drawing.Color.Blue;
            this.label29.Location = new System.Drawing.Point(72, 6);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(38, 16);
            this.label29.TabIndex = 0;
            this.label29.Text = "元/亩";
            // 
            // laLDAZFDJ
            // 
            this.laLDAZFDJ.Dock = System.Windows.Forms.DockStyle.Left;
            this.laLDAZFDJ.Location = new System.Drawing.Point(0, 0);
            this.laLDAZFDJ.Name = "laLDAZFDJ";
            this.laLDAZFDJ.Size = new System.Drawing.Size(90, 24);
            this.laLDAZFDJ.TabIndex = 0;
            this.laLDAZFDJ.Text = "林地安置费单价";
            this.laLDAZFDJ.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label101
            // 
            this.label101.BackColor = System.Drawing.Color.Black;
            this.label101.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label101.Location = new System.Drawing.Point(0, 24);
            this.label101.Name = "label101";
            this.label101.Size = new System.Drawing.Size(438, 1);
            this.label101.TabIndex = 0;
            this.label101.Text = "label101";
            this.label101.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel69
            // 
            this.panel69.Controls.Add(this.panel76);
            this.panel69.Controls.Add(this.laLDBCF);
            this.panel69.Controls.Add(this.panel77);
            this.panel69.Controls.Add(this.laLDBCDJ);
            this.panel69.Controls.Add(this.label96);
            this.panel69.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel69.Location = new System.Drawing.Point(0, 200);
            this.panel69.Name = "panel69";
            this.panel69.Size = new System.Drawing.Size(438, 25);
            this.panel69.TabIndex = 0;
            // 
            // panel76
            // 
            this.panel76.Controls.Add(this.LDBCF);
            this.panel76.Controls.Add(this.label86);
            this.panel76.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel76.Location = new System.Drawing.Point(274, 0);
            this.panel76.Name = "panel76";
            this.panel76.Padding = new System.Windows.Forms.Padding(2, 6, 6, 2);
            this.panel76.Size = new System.Drawing.Size(126, 24);
            this.panel76.TabIndex = 0;
            // 
            // LDBCF
            // 
            this.LDBCF.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LDBCF.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.LDBCF.EditScale = 0;
            this.LDBCF.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.LDBCF.Location = new System.Drawing.Point(2, 4);
            this.LDBCF.Name = "LDBCF";
            this.LDBCF.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.LDBCF.Properties.Appearance.Options.UseForeColor = true;
            this.LDBCF.Properties.Appearance.Options.UseTextOptions = true;
            this.LDBCF.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.LDBCF.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.LDBCF.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.LDBCF.Properties.MaxValue = new decimal(new int[] {
            1410065408,
            2,
            0,
            0});
            this.LDBCF.Size = new System.Drawing.Size(96, 18);
            this.LDBCF.TabIndex = 64;
            this.LDBCF.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // label86
            // 
            this.label86.Dock = System.Windows.Forms.DockStyle.Right;
            this.label86.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label86.ForeColor = System.Drawing.Color.Blue;
            this.label86.Location = new System.Drawing.Point(98, 6);
            this.label86.Name = "label86";
            this.label86.Size = new System.Drawing.Size(22, 16);
            this.label86.TabIndex = 0;
            this.label86.Text = "元";
            // 
            // laLDBCF
            // 
            this.laLDBCF.Dock = System.Windows.Forms.DockStyle.Left;
            this.laLDBCF.Location = new System.Drawing.Point(206, 0);
            this.laLDBCF.Name = "laLDBCF";
            this.laLDBCF.Size = new System.Drawing.Size(68, 24);
            this.laLDBCF.TabIndex = 0;
            this.laLDBCF.Text = "林地补偿费";
            this.laLDBCF.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel77
            // 
            this.panel77.Controls.Add(this.LDBCDJ);
            this.panel77.Controls.Add(this.label26);
            this.panel77.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel77.Location = new System.Drawing.Point(90, 0);
            this.panel77.Name = "panel77";
            this.panel77.Padding = new System.Windows.Forms.Padding(2, 6, 6, 2);
            this.panel77.Size = new System.Drawing.Size(116, 24);
            this.panel77.TabIndex = 0;
            // 
            // LDBCDJ
            // 
            this.LDBCDJ.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LDBCDJ.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.LDBCDJ.EditScale = 0;
            this.LDBCDJ.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.LDBCDJ.Location = new System.Drawing.Point(2, 4);
            this.LDBCDJ.Name = "LDBCDJ";
            this.LDBCDJ.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.LDBCDJ.Properties.Appearance.Options.UseForeColor = true;
            this.LDBCDJ.Properties.Appearance.Options.UseTextOptions = true;
            this.LDBCDJ.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.LDBCDJ.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.LDBCDJ.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.LDBCDJ.Properties.MaxValue = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.LDBCDJ.Size = new System.Drawing.Size(70, 18);
            this.LDBCDJ.TabIndex = 63;
            this.LDBCDJ.EditValueChanged += new System.EventHandler(this.LDBCDJ_EditValueChanged);
            this.LDBCDJ.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // label26
            // 
            this.label26.Dock = System.Windows.Forms.DockStyle.Right;
            this.label26.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.ForeColor = System.Drawing.Color.Blue;
            this.label26.Location = new System.Drawing.Point(72, 6);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(38, 16);
            this.label26.TabIndex = 0;
            this.label26.Text = "元/亩";
            // 
            // laLDBCDJ
            // 
            this.laLDBCDJ.Dock = System.Windows.Forms.DockStyle.Left;
            this.laLDBCDJ.Location = new System.Drawing.Point(0, 0);
            this.laLDBCDJ.Name = "laLDBCDJ";
            this.laLDBCDJ.Size = new System.Drawing.Size(90, 24);
            this.laLDBCDJ.TabIndex = 0;
            this.laLDBCDJ.Text = "林地补偿费单价";
            this.laLDBCDJ.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label96
            // 
            this.label96.BackColor = System.Drawing.Color.Black;
            this.label96.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label96.Location = new System.Drawing.Point(0, 24);
            this.label96.Name = "label96";
            this.label96.Size = new System.Drawing.Size(438, 1);
            this.label96.TabIndex = 0;
            this.label96.Text = "label96";
            this.label96.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel13
            // 
            this.panel13.Controls.Add(this.panel112);
            this.panel13.Controls.Add(this.laZJFWDX);
            this.panel13.Controls.Add(this.panel110);
            this.panel13.Controls.Add(this.laSPJB);
            this.panel13.Controls.Add(this.panel39);
            this.panel13.Controls.Add(this.laSHSJ);
            this.panel13.Controls.Add(this.label24);
            this.panel13.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel13.Location = new System.Drawing.Point(0, 175);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(438, 25);
            this.panel13.TabIndex = 0;
            // 
            // panel112
            // 
            this.panel112.Controls.Add(this.ZJFWDX);
            this.panel112.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel112.Location = new System.Drawing.Point(358, 0);
            this.panel112.Name = "panel112";
            this.panel112.Padding = new System.Windows.Forms.Padding(2, 4, 4, 0);
            this.panel112.Size = new System.Drawing.Size(70, 24);
            this.panel112.TabIndex = 0;
            // 
            // ZJFWDX
            // 
            this.ZJFWDX.AssDispValue = true;
            this.ZJFWDX.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ZJFWDX.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ZJFWDX.ForeColor = System.Drawing.Color.Blue;
            this.ZJFWDX.Location = new System.Drawing.Point(2, 4);
            this.ZJFWDX.Name = "ZJFWDX";
            this.ZJFWDX.Size = new System.Drawing.Size(64, 20);
            this.ZJFWDX.TabIndex = 62;
            this.ZJFWDX.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // laZJFWDX
            // 
            this.laZJFWDX.Dock = System.Windows.Forms.DockStyle.Left;
            this.laZJFWDX.Location = new System.Drawing.Point(280, 0);
            this.laZJFWDX.Name = "laZJFWDX";
            this.laZJFWDX.Size = new System.Drawing.Size(78, 24);
            this.laZJFWDX.TabIndex = 0;
            this.laZJFWDX.Text = "直接服务对象";
            this.laZJFWDX.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel110
            // 
            this.panel110.Controls.Add(this.SPJB);
            this.panel110.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel110.Location = new System.Drawing.Point(195, 0);
            this.panel110.Name = "panel110";
            this.panel110.Padding = new System.Windows.Forms.Padding(2, 4, 4, 0);
            this.panel110.Size = new System.Drawing.Size(85, 24);
            this.panel110.TabIndex = 0;
            // 
            // SPJB
            // 
            this.SPJB.AssDispValue = true;
            this.SPJB.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SPJB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SPJB.ForeColor = System.Drawing.Color.Blue;
            this.SPJB.Location = new System.Drawing.Point(2, 4);
            this.SPJB.Name = "SPJB";
            this.SPJB.Size = new System.Drawing.Size(79, 20);
            this.SPJB.TabIndex = 61;
            this.SPJB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // laSPJB
            // 
            this.laSPJB.Dock = System.Windows.Forms.DockStyle.Left;
            this.laSPJB.Location = new System.Drawing.Point(142, 0);
            this.laSPJB.Name = "laSPJB";
            this.laSPJB.Size = new System.Drawing.Size(53, 24);
            this.laSPJB.TabIndex = 0;
            this.laSPJB.Text = "审批级别";
            this.laSPJB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel39
            // 
            this.panel39.Controls.Add(this.SHSJ);
            this.panel39.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel39.Location = new System.Drawing.Point(53, 0);
            this.panel39.Name = "panel39";
            this.panel39.Padding = new System.Windows.Forms.Padding(2, 1, 8, 3);
            this.panel39.Size = new System.Drawing.Size(89, 24);
            this.panel39.TabIndex = 0;
            // 
            // SHSJ
            // 
            this.SHSJ.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.SHSJ.EditValue = null;
            this.SHSJ.Location = new System.Drawing.Point(2, 3);
            this.SHSJ.Name = "SHSJ";
            this.SHSJ.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.SHSJ.Properties.Appearance.Options.UseForeColor = true;
            this.SHSJ.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.SHSJ.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.SHSJ.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.SHSJ.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.SHSJ.Size = new System.Drawing.Size(79, 18);
            this.SHSJ.TabIndex = 60;
            this.SHSJ.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // laSHSJ
            // 
            this.laSHSJ.Dock = System.Windows.Forms.DockStyle.Left;
            this.laSHSJ.Location = new System.Drawing.Point(0, 0);
            this.laSHSJ.Name = "laSHSJ";
            this.laSHSJ.Size = new System.Drawing.Size(53, 24);
            this.laSHSJ.TabIndex = 0;
            this.laSHSJ.Text = "审核时间";
            this.laSHSJ.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label24
            // 
            this.label24.BackColor = System.Drawing.Color.Black;
            this.label24.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label24.Location = new System.Drawing.Point(0, 24);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(438, 1);
            this.label24.TabIndex = 0;
            this.label24.Text = "label24";
            this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel109
            // 
            this.panel109.Controls.Add(this.panel115);
            this.panel109.Controls.Add(this.label1);
            this.panel109.Controls.Add(this.panel111);
            this.panel109.Controls.Add(this.laYDFW);
            this.panel109.Controls.Add(this.label154);
            this.panel109.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel109.Location = new System.Drawing.Point(0, 150);
            this.panel109.Name = "panel109";
            this.panel109.Size = new System.Drawing.Size(438, 25);
            this.panel109.TabIndex = 0;
            // 
            // panel115
            // 
            this.panel115.Controls.Add(this.JLSJ);
            this.panel115.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel115.Location = new System.Drawing.Point(268, 0);
            this.panel115.Name = "panel115";
            this.panel115.Padding = new System.Windows.Forms.Padding(2, 1, 8, 3);
            this.panel115.Size = new System.Drawing.Size(89, 24);
            this.panel115.TabIndex = 0;
            // 
            // JLSJ
            // 
            this.JLSJ.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.JLSJ.EditValue = null;
            this.JLSJ.Location = new System.Drawing.Point(2, 3);
            this.JLSJ.Name = "JLSJ";
            this.JLSJ.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.JLSJ.Properties.Appearance.Options.UseForeColor = true;
            this.JLSJ.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.JLSJ.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.JLSJ.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.JLSJ.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.JLSJ.Size = new System.Drawing.Size(79, 18);
            this.JLSJ.TabIndex = 59;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Location = new System.Drawing.Point(212, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "记录时间";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel111
            // 
            this.panel111.Controls.Add(this.YDFW);
            this.panel111.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel111.Location = new System.Drawing.Point(150, 0);
            this.panel111.Name = "panel111";
            this.panel111.Padding = new System.Windows.Forms.Padding(2, 4, 4, 0);
            this.panel111.Size = new System.Drawing.Size(62, 24);
            this.panel111.TabIndex = 0;
            // 
            // YDFW
            // 
            this.YDFW.AssDispValue = true;
            this.YDFW.Cursor = System.Windows.Forms.Cursors.Hand;
            this.YDFW.Dock = System.Windows.Forms.DockStyle.Fill;
            this.YDFW.ForeColor = System.Drawing.Color.Blue;
            this.YDFW.Location = new System.Drawing.Point(2, 4);
            this.YDFW.Name = "YDFW";
            this.YDFW.Size = new System.Drawing.Size(56, 20);
            this.YDFW.TabIndex = 58;
            this.YDFW.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // laYDFW
            // 
            this.laYDFW.Dock = System.Windows.Forms.DockStyle.Left;
            this.laYDFW.Location = new System.Drawing.Point(0, 0);
            this.laYDFW.Name = "laYDFW";
            this.laYDFW.Size = new System.Drawing.Size(150, 24);
            this.laYDFW.TabIndex = 0;
            this.laYDFW.Text = "是否城市及城市规划区林地";
            this.laYDFW.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label154
            // 
            this.label154.BackColor = System.Drawing.Color.Black;
            this.label154.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label154.Location = new System.Drawing.Point(0, 24);
            this.label154.Name = "label154";
            this.label154.Size = new System.Drawing.Size(438, 1);
            this.label154.TabIndex = 0;
            this.label154.Text = "label154";
            this.label154.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel64
            // 
            this.panel64.Controls.Add(this.panel65);
            this.panel64.Controls.Add(this.laSFTGD);
            this.panel64.Controls.Add(this.panel68);
            this.panel64.Controls.Add(this.laYDZL);
            this.panel64.Controls.Add(this.label81);
            this.panel64.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel64.Location = new System.Drawing.Point(0, 125);
            this.panel64.Name = "panel64";
            this.panel64.Size = new System.Drawing.Size(438, 25);
            this.panel64.TabIndex = 0;
            // 
            // panel65
            // 
            this.panel65.Controls.Add(this.SFTGD);
            this.panel65.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel65.Location = new System.Drawing.Point(211, 0);
            this.panel65.Name = "panel65";
            this.panel65.Padding = new System.Windows.Forms.Padding(2, 4, 4, 0);
            this.panel65.Size = new System.Drawing.Size(60, 24);
            this.panel65.TabIndex = 0;
            // 
            // SFTGD
            // 
            this.SFTGD.AssDispValue = true;
            this.SFTGD.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SFTGD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SFTGD.ForeColor = System.Drawing.Color.Blue;
            this.SFTGD.Location = new System.Drawing.Point(2, 4);
            this.SFTGD.Name = "SFTGD";
            this.SFTGD.Size = new System.Drawing.Size(54, 20);
            this.SFTGD.TabIndex = 57;
            this.SFTGD.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // laSFTGD
            // 
            this.laSFTGD.Dock = System.Windows.Forms.DockStyle.Left;
            this.laSFTGD.Location = new System.Drawing.Point(143, 0);
            this.laSFTGD.Name = "laSFTGD";
            this.laSFTGD.Size = new System.Drawing.Size(68, 24);
            this.laSFTGD.TabIndex = 0;
            this.laSFTGD.Text = "是否退耕地";
            this.laSFTGD.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel68
            // 
            this.panel68.Controls.Add(this.YDZL);
            this.panel68.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel68.Location = new System.Drawing.Point(53, 0);
            this.panel68.Name = "panel68";
            this.panel68.Padding = new System.Windows.Forms.Padding(2, 4, 4, 0);
            this.panel68.Size = new System.Drawing.Size(90, 24);
            this.panel68.TabIndex = 0;
            // 
            // YDZL
            // 
            this.YDZL.AssDispValue = true;
            this.YDZL.Cursor = System.Windows.Forms.Cursors.Hand;
            this.YDZL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.YDZL.ForeColor = System.Drawing.Color.Blue;
            this.YDZL.Location = new System.Drawing.Point(2, 4);
            this.YDZL.Name = "YDZL";
            this.YDZL.Size = new System.Drawing.Size(84, 20);
            this.YDZL.TabIndex = 56;
            this.YDZL.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // laYDZL
            // 
            this.laYDZL.Dock = System.Windows.Forms.DockStyle.Left;
            this.laYDZL.Location = new System.Drawing.Point(0, 0);
            this.laYDZL.Name = "laYDZL";
            this.laYDZL.Size = new System.Drawing.Size(53, 24);
            this.laYDZL.TabIndex = 0;
            this.laYDZL.Text = "用地种类";
            this.laYDZL.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label81
            // 
            this.label81.BackColor = System.Drawing.Color.Black;
            this.label81.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label81.Location = new System.Drawing.Point(0, 24);
            this.label81.Name = "label81";
            this.label81.Size = new System.Drawing.Size(438, 1);
            this.label81.TabIndex = 0;
            this.label81.Text = "label81";
            this.label81.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel60
            // 
            this.panel60.Controls.Add(this.panel62);
            this.panel60.Controls.Add(this.laLDYT);
            this.panel60.Controls.Add(this.panel63);
            this.panel60.Controls.Add(this.laLDLX);
            this.panel60.Controls.Add(this.label77);
            this.panel60.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel60.Location = new System.Drawing.Point(0, 100);
            this.panel60.Name = "panel60";
            this.panel60.Size = new System.Drawing.Size(438, 25);
            this.panel60.TabIndex = 0;
            // 
            // panel62
            // 
            this.panel62.Controls.Add(this.LDYT);
            this.panel62.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel62.Location = new System.Drawing.Point(196, 0);
            this.panel62.Name = "panel62";
            this.panel62.Padding = new System.Windows.Forms.Padding(2, 4, 4, 0);
            this.panel62.Size = new System.Drawing.Size(232, 24);
            this.panel62.TabIndex = 0;
            // 
            // LDYT
            // 
            this.LDYT.AssDispValue = true;
            this.LDYT.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LDYT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LDYT.ForeColor = System.Drawing.Color.Blue;
            this.LDYT.Location = new System.Drawing.Point(2, 4);
            this.LDYT.Name = "LDYT";
            this.LDYT.Size = new System.Drawing.Size(226, 20);
            this.LDYT.TabIndex = 55;
            this.LDYT.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // laLDYT
            // 
            this.laLDYT.Dock = System.Windows.Forms.DockStyle.Left;
            this.laLDYT.Location = new System.Drawing.Point(143, 0);
            this.laLDYT.Name = "laLDYT";
            this.laLDYT.Size = new System.Drawing.Size(53, 24);
            this.laLDYT.TabIndex = 0;
            this.laLDYT.Text = "林地用途";
            this.laLDYT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel63
            // 
            this.panel63.Controls.Add(this.LDLX);
            this.panel63.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel63.Location = new System.Drawing.Point(53, 0);
            this.panel63.Name = "panel63";
            this.panel63.Padding = new System.Windows.Forms.Padding(2, 4, 4, 0);
            this.panel63.Size = new System.Drawing.Size(90, 24);
            this.panel63.TabIndex = 0;
            // 
            // LDLX
            // 
            this.LDLX.AssDispValue = true;
            this.LDLX.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LDLX.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LDLX.ForeColor = System.Drawing.Color.Blue;
            this.LDLX.Location = new System.Drawing.Point(2, 4);
            this.LDLX.Name = "LDLX";
            this.LDLX.Size = new System.Drawing.Size(84, 20);
            this.LDLX.TabIndex = 54;
            this.LDLX.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // laLDLX
            // 
            this.laLDLX.Dock = System.Windows.Forms.DockStyle.Left;
            this.laLDLX.Location = new System.Drawing.Point(0, 0);
            this.laLDLX.Name = "laLDLX";
            this.laLDLX.Size = new System.Drawing.Size(53, 24);
            this.laLDLX.TabIndex = 0;
            this.laLDLX.Text = "林地类型";
            this.laLDLX.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label77
            // 
            this.label77.BackColor = System.Drawing.Color.Black;
            this.label77.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label77.Location = new System.Drawing.Point(0, 24);
            this.label77.Name = "label77";
            this.label77.Size = new System.Drawing.Size(438, 1);
            this.label77.TabIndex = 0;
            this.label77.Text = "label77";
            this.label77.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel45
            // 
            this.panel45.Controls.Add(this.panel48);
            this.panel45.Controls.Add(this.laZYBM);
            this.panel45.Controls.Add(this.label129);
            this.panel45.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel45.Location = new System.Drawing.Point(0, 75);
            this.panel45.Name = "panel45";
            this.panel45.Size = new System.Drawing.Size(438, 25);
            this.panel45.TabIndex = 0;
            // 
            // panel48
            // 
            this.panel48.Controls.Add(this.ZYBM);
            this.panel48.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel48.Location = new System.Drawing.Point(77, 0);
            this.panel48.Name = "panel48";
            this.panel48.Padding = new System.Windows.Forms.Padding(2, 6, 8, 0);
            this.panel48.Size = new System.Drawing.Size(351, 24);
            this.panel48.TabIndex = 0;
            // 
            // ZYBM
            // 
            this.ZYBM.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ZYBM.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ZYBM.EditValue = "";
            this.ZYBM.Location = new System.Drawing.Point(2, 6);
            this.ZYBM.Name = "ZYBM";
            this.ZYBM.Properties.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ZYBM.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.ZYBM.Properties.Appearance.Options.UseFont = true;
            this.ZYBM.Properties.Appearance.Options.UseForeColor = true;
            this.ZYBM.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.ZYBM.Size = new System.Drawing.Size(341, 16);
            this.ZYBM.TabIndex = 53;
            this.ZYBM.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // laZYBM
            // 
            this.laZYBM.Dock = System.Windows.Forms.DockStyle.Left;
            this.laZYBM.Location = new System.Drawing.Point(0, 0);
            this.laZYBM.Name = "laZYBM";
            this.laZYBM.Size = new System.Drawing.Size(77, 24);
            this.laZYBM.TabIndex = 0;
            this.laZYBM.Text = "占用征收单位";
            this.laZYBM.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label129
            // 
            this.label129.BackColor = System.Drawing.Color.Black;
            this.label129.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label129.Location = new System.Drawing.Point(0, 24);
            this.label129.Name = "label129";
            this.label129.Size = new System.Drawing.Size(438, 1);
            this.label129.TabIndex = 0;
            this.label129.Text = "label129";
            this.label129.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel54
            // 
            this.panel54.Controls.Add(this.panel56);
            this.panel54.Controls.Add(this.laXFSS);
            this.panel54.Controls.Add(this.panel58);
            this.panel54.Controls.Add(this.laXMLX);
            this.panel54.Controls.Add(this.label71);
            this.panel54.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel54.Location = new System.Drawing.Point(0, 50);
            this.panel54.Name = "panel54";
            this.panel54.Size = new System.Drawing.Size(438, 25);
            this.panel54.TabIndex = 0;
            // 
            // panel56
            // 
            this.panel56.Controls.Add(this.XFSS);
            this.panel56.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel56.Location = new System.Drawing.Point(249, 0);
            this.panel56.Name = "panel56";
            this.panel56.Padding = new System.Windows.Forms.Padding(2, 4, 4, 0);
            this.panel56.Size = new System.Drawing.Size(90, 24);
            this.panel56.TabIndex = 0;
            // 
            // XFSS
            // 
            this.XFSS.AssDispValue = true;
            this.XFSS.Cursor = System.Windows.Forms.Cursors.Hand;
            this.XFSS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.XFSS.ForeColor = System.Drawing.Color.Blue;
            this.XFSS.Location = new System.Drawing.Point(2, 4);
            this.XFSS.Name = "XFSS";
            this.XFSS.Size = new System.Drawing.Size(84, 20);
            this.XFSS.TabIndex = 52;
            this.XFSS.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // laXFSS
            // 
            this.laXFSS.Dock = System.Windows.Forms.DockStyle.Left;
            this.laXFSS.Location = new System.Drawing.Point(196, 0);
            this.laXFSS.Name = "laXFSS";
            this.laXFSS.Size = new System.Drawing.Size(53, 24);
            this.laXFSS.TabIndex = 0;
            this.laXFSS.Text = "是否实施";
            this.laXFSS.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel58
            // 
            this.panel58.Controls.Add(this.XMLX);
            this.panel58.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel58.Location = new System.Drawing.Point(53, 0);
            this.panel58.Name = "panel58";
            this.panel58.Padding = new System.Windows.Forms.Padding(2, 4, 4, 0);
            this.panel58.Size = new System.Drawing.Size(143, 24);
            this.panel58.TabIndex = 0;
            // 
            // XMLX
            // 
            this.XMLX.AssDispValue = true;
            this.XMLX.Cursor = System.Windows.Forms.Cursors.Hand;
            this.XMLX.Dock = System.Windows.Forms.DockStyle.Fill;
            this.XMLX.ForeColor = System.Drawing.Color.Blue;
            this.XMLX.Location = new System.Drawing.Point(2, 4);
            this.XMLX.Name = "XMLX";
            this.XMLX.Size = new System.Drawing.Size(137, 20);
            this.XMLX.TabIndex = 51;
            this.XMLX.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // laXMLX
            // 
            this.laXMLX.Dock = System.Windows.Forms.DockStyle.Left;
            this.laXMLX.Location = new System.Drawing.Point(0, 0);
            this.laXMLX.Name = "laXMLX";
            this.laXMLX.Size = new System.Drawing.Size(53, 24);
            this.laXMLX.TabIndex = 0;
            this.laXMLX.Text = "项目类型";
            this.laXMLX.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label71
            // 
            this.label71.BackColor = System.Drawing.Color.Black;
            this.label71.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label71.Location = new System.Drawing.Point(0, 24);
            this.label71.Name = "label71";
            this.label71.Size = new System.Drawing.Size(438, 1);
            this.label71.TabIndex = 0;
            this.label71.Text = "label71";
            this.label71.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel113
            // 
            this.panel113.Controls.Add(this.panel114);
            this.panel113.Controls.Add(this.label3);
            this.panel113.Controls.Add(this.label4);
            this.panel113.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel113.Location = new System.Drawing.Point(0, 25);
            this.panel113.Name = "panel113";
            this.panel113.Size = new System.Drawing.Size(438, 25);
            this.panel113.TabIndex = 0;
            // 
            // panel114
            // 
            this.panel114.Controls.Add(this.PZWH);
            this.panel114.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel114.Location = new System.Drawing.Point(53, 0);
            this.panel114.Name = "panel114";
            this.panel114.Padding = new System.Windows.Forms.Padding(2, 6, 8, 0);
            this.panel114.Size = new System.Drawing.Size(375, 24);
            this.panel114.TabIndex = 0;
            // 
            // PZWH
            // 
            this.PZWH.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PZWH.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PZWH.EditValue = "";
            this.PZWH.Location = new System.Drawing.Point(2, 6);
            this.PZWH.Name = "PZWH";
            this.PZWH.Properties.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.PZWH.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.PZWH.Properties.Appearance.Options.UseFont = true;
            this.PZWH.Properties.Appearance.Options.UseForeColor = true;
            this.PZWH.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.PZWH.Size = new System.Drawing.Size(365, 16);
            this.PZWH.TabIndex = 50;
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Left;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 24);
            this.label3.TabIndex = 0;
            this.label3.Text = "批准文号";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Black;
            this.label4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label4.Location = new System.Drawing.Point(0, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(438, 1);
            this.label4.TabIndex = 0;
            this.label4.Text = "label4";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel53
            // 
            this.panel53.Controls.Add(this.panel55);
            this.panel53.Controls.Add(this.laXMBH);
            this.panel53.Controls.Add(this.label61);
            this.panel53.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel53.Location = new System.Drawing.Point(0, 0);
            this.panel53.Name = "panel53";
            this.panel53.Size = new System.Drawing.Size(438, 25);
            this.panel53.TabIndex = 0;
            // 
            // panel55
            // 
            this.panel55.Controls.Add(this.XMMC);
            this.panel55.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel55.Location = new System.Drawing.Point(53, 0);
            this.panel55.Name = "panel55";
            this.panel55.Padding = new System.Windows.Forms.Padding(2, 6, 8, 0);
            this.panel55.Size = new System.Drawing.Size(375, 24);
            this.panel55.TabIndex = 0;
            // 
            // XMMC
            // 
            this.XMMC.Cursor = System.Windows.Forms.Cursors.Hand;
            this.XMMC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.XMMC.EditValue = "";
            this.XMMC.Location = new System.Drawing.Point(2, 6);
            this.XMMC.Name = "XMMC";
            this.XMMC.Properties.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.XMMC.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.XMMC.Properties.Appearance.Options.UseFont = true;
            this.XMMC.Properties.Appearance.Options.UseForeColor = true;
            this.XMMC.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.XMMC.Size = new System.Drawing.Size(365, 16);
            this.XMMC.TabIndex = 49;
            // 
            // laXMBH
            // 
            this.laXMBH.Dock = System.Windows.Forms.DockStyle.Left;
            this.laXMBH.Location = new System.Drawing.Point(0, 0);
            this.laXMBH.Name = "laXMBH";
            this.laXMBH.Size = new System.Drawing.Size(53, 24);
            this.laXMBH.TabIndex = 0;
            this.laXMBH.Text = "项目";
            this.laXMBH.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label61
            // 
            this.label61.BackColor = System.Drawing.Color.Black;
            this.label61.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label61.Location = new System.Drawing.Point(0, 24);
            this.label61.Name = "label61";
            this.label61.Size = new System.Drawing.Size(438, 1);
            this.label61.TabIndex = 0;
            this.label61.Text = "label61";
            this.label61.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label90
            // 
            this.label90.BackColor = System.Drawing.Color.Black;
            this.label90.Dock = System.Windows.Forms.DockStyle.Top;
            this.label90.Location = new System.Drawing.Point(1, 0);
            this.label90.Name = "label90";
            this.label90.Size = new System.Drawing.Size(438, 1);
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
            this.label91.Size = new System.Drawing.Size(1, 376);
            this.label91.TabIndex = 0;
            this.label91.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label92
            // 
            this.label92.BackColor = System.Drawing.Color.Black;
            this.label92.Dock = System.Windows.Forms.DockStyle.Right;
            this.label92.Location = new System.Drawing.Point(439, 0);
            this.label92.Name = "label92";
            this.label92.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.label92.Size = new System.Drawing.Size(1, 376);
            this.label92.TabIndex = 0;
            this.label92.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label93
            // 
            this.label93.Dock = System.Windows.Forms.DockStyle.Top;
            this.label93.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label93.Location = new System.Drawing.Point(0, 0);
            this.label93.Name = "label93";
            this.label93.Size = new System.Drawing.Size(440, 26);
            this.label93.TabIndex = 0;
            this.label93.Text = "  征占用项目情况";
            this.label93.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // UserControlZZAttr
            // 
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.xtraTabControl1);
            this.Name = "UserControlZZAttr";
            this.Padding = new System.Windows.Forms.Padding(2);
            this.Size = new System.Drawing.Size(450, 670);
            this.panelBasicInfo.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel16.ResumeLayout(false);
            this.panel106.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.XI_BAN.Properties)).EndInit();
            this.panel20.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.XIAO_BAN.Properties)).EndInit();
            this.panel7.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.LIN_BAN.Properties)).EndInit();
            this.panel10.ResumeLayout(false);
            this.panel11.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panelWoodsInfo.ResumeLayout(false);
            this.panel22.ResumeLayout(false);
            this.panel23.ResumeLayout(false);
            this.panel79.ResumeLayout(false);
            this.panel103.ResumeLayout(false);
            this.panel83.ResumeLayout(false);
            this.panel102.ResumeLayout(false);
            this.panel27.ResumeLayout(false);
            this.panel18.ResumeLayout(false);
            this.panel67.ResumeLayout(false);
            this.panel19.ResumeLayout(false);
            this.panel42.ResumeLayout(false);
            this.panel35.ResumeLayout(false);
            this.panel107.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MEI_GQ_ZS.Properties)).EndInit();
            this.panel34.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PINGJUN_NL.Properties)).EndInit();
            this.panel75.ResumeLayout(false);
            this.panel105.ResumeLayout(false);
            this.panel32.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SLXJ.Properties)).EndInit();
            this.panel29.ResumeLayout(false);
            this.panel46.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PINGJUN_DM.Properties)).EndInit();
            this.panel51.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PINGJUN_SG.Properties)).EndInit();
            this.panel30.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PINGJUN_XJ.Properties)).EndInit();
            this.panel31.ResumeLayout(false);
            this.panel43.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.YU_BI_DU.Properties)).EndInit();
            this.panel104.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SPMJ.Properties)).EndInit();
            this.panel33.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MIAN_JI.Properties)).EndInit();
            this.panel41.ResumeLayout(false);
            this.panel73.ResumeLayout(false);
            this.panel66.ResumeLayout(false);
            this.panel44.ResumeLayout(false);
            this.panel14.ResumeLayout(false);
            this.panel38.ResumeLayout(false);
            this.panel40.ResumeLayout(false);
            this.panel47.ResumeLayout(false);
            this.panel100.ResumeLayout(false);
            this.panel26.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.panel93.ResumeLayout(false);
            this.panel97.ResumeLayout(false);
            this.panel101.ResumeLayout(false);
            this.panel21.ResumeLayout(false);
            this.panel24.ResumeLayout(false);
            this.panel25.ResumeLayout(false);
            this.panel37.ResumeLayout(false);
            this.panel50.ResumeLayout(false);
            this.panel70.ResumeLayout(false);
            this.panelXZW.ResumeLayout(false);
            this.panel108.ResumeLayout(false);
            this.panel72.ResumeLayout(false);
            this.panel17.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.XZWKD.Properties)).EndInit();
            this.panel59.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.XZWCD.Properties)).EndInit();
            this.panel88.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.XZWMJ.Properties)).EndInit();
            this.panel12.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit3.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit36.Properties)).EndInit();
            this.panel89.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.textEdit51.Properties)).EndInit();
            this.panel90.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit16.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit52.Properties)).EndInit();
            this.panelPoint.ResumeLayout(false);
            this.panel52.ResumeLayout(false);
            this.panel57.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TJ_Y.Properties)).EndInit();
            this.panel61.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TJ_X.Properties)).EndInit();
            this.panel71.ResumeLayout(false);
            this.panel74.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TJMC.Properties)).EndInit();
            this.panelOther.ResumeLayout(false);
            this.panel86.ResumeLayout(false);
            this.panel91.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GXSJ.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GXSJ.Properties)).EndInit();
            this.panel92.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.xtraTabPage1.ResumeLayout(false);
            this.panelControl1.ResumeLayout(false);
            this.xtraTabPage2.ResumeLayout(false);
            this.panelControl2.ResumeLayout(false);
            this.panelZZ.ResumeLayout(false);
            this.panel36.ResumeLayout(false);
            this.panel15.ResumeLayout(false);
            this.panel28.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.BZ.Properties)).EndInit();
            this.panel96.ResumeLayout(false);
            this.panel99.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ZFYHJ.Properties)).EndInit();
            this.panel87.ResumeLayout(false);
            this.panel94.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ZBHFF.Properties)).EndInit();
            this.panel95.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ZBHFDJ.Properties)).EndInit();
            this.panel49.ResumeLayout(false);
            this.panel98.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.BCFHJ.Properties)).EndInit();
            this.panel82.ResumeLayout(false);
            this.panel84.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.LMBCF.Properties)).EndInit();
            this.panel85.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.LMBCDJ.Properties)).EndInit();
            this.panel78.ResumeLayout(false);
            this.panel80.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.LDAZF.Properties)).EndInit();
            this.panel81.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.LDAZFDJ.Properties)).EndInit();
            this.panel69.ResumeLayout(false);
            this.panel76.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.LDBCF.Properties)).EndInit();
            this.panel77.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.LDBCDJ.Properties)).EndInit();
            this.panel13.ResumeLayout(false);
            this.panel112.ResumeLayout(false);
            this.panel110.ResumeLayout(false);
            this.panel39.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SHSJ.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SHSJ.Properties)).EndInit();
            this.panel109.ResumeLayout(false);
            this.panel115.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.JLSJ.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.JLSJ.Properties)).EndInit();
            this.panel111.ResumeLayout(false);
            this.panel64.ResumeLayout(false);
            this.panel65.ResumeLayout(false);
            this.panel68.ResumeLayout(false);
            this.panel60.ResumeLayout(false);
            this.panel62.ResumeLayout(false);
            this.panel63.ResumeLayout(false);
            this.panel45.ResumeLayout(false);
            this.panel48.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ZYBM.Properties)).EndInit();
            this.panel54.ResumeLayout(false);
            this.panel56.ResumeLayout(false);
            this.panel58.ResumeLayout(false);
            this.panel113.ResumeLayout(false);
            this.panel114.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PZWH.Properties)).EndInit();
            this.panel53.ResumeLayout(false);
            this.panel55.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.XMMC.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        private void LDAZFDJ_EditValueChanged(object sender, EventArgs e)
        {
            if (this.m_bInit)
            {
                decimal num = this.SPMJ.Value;
                decimal num3 = this.LDAZFDJ.Value * (num * 15M);
                this.LDAZF.Value = Convert.ToDecimal(num3);
            }
        }

        private void LDBCDJ_EditValueChanged(object sender, EventArgs e)
        {
            if (this.m_bInit)
            {
                decimal num = this.SPMJ.Value;
                decimal num3 = this.LDBCDJ.Value * (num * 15M);
                this.LDBCF.Value = Convert.ToDecimal(num3);
            }
        }

        private void LMBCDJ_EditValueChanged(object sender, EventArgs e)
        {
            if (this.m_bInit)
            {
                decimal num = this.SPMJ.Value;
                decimal num3 = this.LMBCDJ.Value * (num * 15M);
                this.LMBCF.Value = Convert.ToDecimal(num3);
                decimal num4 = (this.LDBCF.Value + this.LDAZF.Value) + this.LMBCF.Value;
                this.BCFHJ.Value = num4;
            }
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

        private void simpleButtonCalcXJ_Click(object sender, EventArgs e)
        {
            JSXBXJL jsxbxjl = new JSXBXJL();
            string selectedValue = this.Q_DI_LEI.GetSelectedValue();
            string str2 = this.YOU_SHI_SZ.GetSelectedValue();
            double num = Convert.ToDouble(this.PINGJUN_SG.Value);
            double num2 = Convert.ToDouble(this.PINGJUN_XJ.Value);
            double num3 = Convert.ToDouble(this.PINGJUN_DM.Value);
            double mianji = Convert.ToDouble(this.MIAN_JI.Value);
            double num5 = jsxbxjl.GetXBXJL(selectedValue, str2, num, num2, num3, mianji);
            this.SLXJ.Value = Convert.ToInt32(num5);
        }

        private void SPMJ_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.CheckSPMJ();
            }
        }

        private void SPMJ_Leave(object sender, EventArgs e)
        {
            this.CheckSPMJ();
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

        private void xtraTabControl1_SelectedPageChanged(object sender, TabPageChangedEventArgs e)
        {
            XtraTabPage selectedTabPage = this.xtraTabControl1.SelectedTabPage;
            selectedTabPage.Appearance.Header.Options.UseFont = true;
            selectedTabPage.Appearance.Header.Options.UseForeColor = true;
            int num = 1 - this.xtraTabControl1.SelectedTabPageIndex;
            selectedTabPage = this.xtraTabControl1.TabPages[num];
            selectedTabPage.Appearance.Header.Options.UseFont = false;
            selectedTabPage.Appearance.Header.Options.UseForeColor = false;
        }

        private void ZBHFDJ_EditValueChanged(object sender, EventArgs e)
        {
            if (this.m_bInit)
            {
                decimal num = this.SPMJ.Value;
                decimal num3 = this.ZBHFDJ.Value * (num * 10000M);
                this.ZBHFF.Value = Convert.ToDecimal(num3);
                decimal num4 = this.BCFHJ.Value + this.ZBHFF.Value;
                this.ZFYHJ.Value = num4;
            }
        }
    }
}

