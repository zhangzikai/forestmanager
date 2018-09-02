namespace AttributesEdit
{
    using DevExpress.Utils;
    using DevExpress.XtraEditors;
    using DevExpress.XtraEditors.Controls;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Reflection;
    using System.Windows.Forms;

    public class UserControlHSAttr : UserControl
    {
        private ZLComboBox BCLD;
        private TextEdit BEIZU;
        private ZLComboBox BH_DJ;
        private TextEdit BHND;
        private ZLComboBox BHYY;
        private IContainer components;
        private ZLComboBox CUN;
        private ZLComboBox DI_LEI;
        private ZLComboBox DI_MAO;
        private ZLComboBox DISASTER_C;
        private ZLComboBox DISPE;
        private ZLComboBox G_CHENG_LB;
        private ZLComboBox GJGYL_BHDJ;
        private ZLSpinEdit HUO_LMGQXJ;
        private ZLComboBox KE_JI_DU;
        private Label label1;
        private Label label10;
        private Label label100;
        private Label label101;
        private Label label102;
        private Label label103;
        private Label label104;
        private Label label105;
        private Label label106;
        private Label label107;
        private Label label108;
        private Label label109;
        private Label label11;
        private Label label110;
        private Label label111;
        private Label label112;
        private Label label113;
        private Label label114;
        private Label label115;
        private Label label116;
        private Label label117;
        private Label label118;
        private Label label119;
        private Label label12;
        private Label label121;
        private Label label13;
        private Label label14;
        private Label label15;
        private Label label16;
        private Label label17;
        private Label label171;
        private Label label172;
        private Label label173;
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
        private Label label59;
        private Label label6;
        private Label label60;
        private Label label61;
        private Label label62;
        private Label label63;
        private Label label64;
        private Label label65;
        private Label label66;
        private Label label67;
        private Label label68;
        private Label label69;
        private Label label7;
        private Label label70;
        private Label label71;
        private Label label72;
        private Label label73;
        private Label label74;
        private Label label75;
        private Label label76;
        private Label label77;
        private Label label78;
        private Label label79;
        private Label label8;
        private Label label80;
        private Label label81;
        private Label label82;
        private Label label83;
        private Label label84;
        private Label label85;
        private Label label86;
        private Label label87;
        private Label label88;
        private Label label89;
        private Label label9;
        private Label label90;
        private Label label91;
        private Label label92;
        private Label label93;
        private Label label94;
        private Label label95;
        private Label label96;
        private Label label97;
        private Label label98;
        private Label label99;
        private Label labelTitle;
        private ZLSpinEdit LD_CD;
        private ZLSpinEdit LD_KD;
        private ZLComboBox LD_QS;
        private ZLComboBox LDGLLX;
        private TextEdit LIN_BAN;
        private TextEdit LIN_CHANG;
        private TextEdit LIN_YE_JU;
        private ZLComboBox LIN_ZHONG;
        private ZLComboBox LING_ZU;
        private ZLComboBox LMSYQ;
        private ZLComboBox LYFQ;
        private ZLSpinEdit MEI_GQ_ZS;
        private ZLSpinEdit MIAN_JI;
        private TextEdit NO_TB;
        private ZLComboBox PAN_DILEI;
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
        private Panel panel89;
        private Panel panel9;
        private Panel panelBasicInfo;
        private Panel panelControl1;
        private Panel panelHS;
        private Panel panelP21;
        private Panel panelP22;
        private Panel panelP23;
        private Panel panelP24;
        private Panel panelP25;
        private Panel panelP26;
        private Panel panelTitle;
        private ZLSpinEdit PINGJUN_DM;
        private ZLSpinEdit PINGJUN_NL;
        private ZLSpinEdit PINGJUN_SG;
        private ZLSpinEdit PINGJUN_XJ;
        private ZLComboBox PO_DU;
        private ZLComboBox PO_WEI;
        private ZLComboBox PO_XIANG;
        private ZLComboBox QI_YUAN;
        private ZLComboBox QYKZ;
        private ZLComboBox SEN_LIN_LB;
        private ZLComboBox SHENG;
        private ZLComboBox SHI_QUAN_D;
        private ZLComboBox TD_TH_LX;
        private ZLSpinEdit TU_CENG_HD;
        private ZLComboBox TU_RANG_LX;
        private ZLComboBox XIAN;
        private ZLComboBox XIANG;
        private ZLComboBox YOU_SHI_SZ;
        private ZLSpinEdit YU_BI_DU;
        private ZLComboBox ZL_DJ;
        private ZLComboBox zlComboBox1;

        public UserControlHSAttr()
        {
            this.InitializeComponent();
            this.SHENG.SelectedIndexChanged += new EventHandler(this.SHENG_SelectedIndexChanged);
            this.XIAN.SelectedIndexChanged += new EventHandler(this.XIAN_SelectedIndexChanged);
            this.XIANG.SelectedIndexChanged += new EventHandler(this.XIANG_SelectedIndexChanged);
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
            if (index == 50)
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
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel16 = new System.Windows.Forms.Panel();
            this.panel18 = new System.Windows.Forms.Panel();
            this.BEIZU = new DevExpress.XtraEditors.TextEdit();
            this.label44 = new System.Windows.Forms.Label();
            this.panel19 = new System.Windows.Forms.Panel();
            this.PAN_DILEI = new AttributesEdit.ZLComboBox();
            this.label49 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel10 = new System.Windows.Forms.Panel();
            this.LIN_BAN = new DevExpress.XtraEditors.TextEdit();
            this.label40 = new System.Windows.Forms.Label();
            this.panel11 = new System.Windows.Forms.Panel();
            this.CUN = new AttributesEdit.ZLComboBox();
            this.label41 = new System.Windows.Forms.Label();
            this.label42 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.XIANG = new AttributesEdit.ZLComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.NO_TB = new DevExpress.XtraEditors.TextEdit();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label39 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.label37 = new System.Windows.Forms.Label();
            this.panelHS = new System.Windows.Forms.Panel();
            this.panel36 = new System.Windows.Forms.Panel();
            this.panelP26 = new System.Windows.Forms.Panel();
            this.panel42 = new System.Windows.Forms.Panel();
            this.panel43 = new System.Windows.Forms.Panel();
            this.panel44 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.BHND = new DevExpress.XtraEditors.TextEdit();
            this.label59 = new System.Windows.Forms.Label();
            this.panel56 = new System.Windows.Forms.Panel();
            this.panel57 = new System.Windows.Forms.Panel();
            this.LDGLLX = new AttributesEdit.ZLComboBox();
            this.label63 = new System.Windows.Forms.Label();
            this.panel85 = new System.Windows.Forms.Panel();
            this.BHYY = new AttributesEdit.ZLComboBox();
            this.label64 = new System.Windows.Forms.Label();
            this.label65 = new System.Windows.Forms.Label();
            this.label110 = new System.Windows.Forms.Label();
            this.label111 = new System.Windows.Forms.Label();
            this.panelP25 = new System.Windows.Forms.Panel();
            this.panel12 = new System.Windows.Forms.Panel();
            this.panel15 = new System.Windows.Forms.Panel();
            this.panel20 = new System.Windows.Forms.Panel();
            this.LYFQ = new AttributesEdit.ZLComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.panel9 = new System.Windows.Forms.Panel();
            this.panel41 = new System.Windows.Forms.Panel();
            this.BCLD = new AttributesEdit.ZLComboBox();
            this.label114 = new System.Windows.Forms.Label();
            this.panel86 = new System.Windows.Forms.Panel();
            this.SHI_QUAN_D = new AttributesEdit.ZLComboBox();
            this.label115 = new System.Windows.Forms.Label();
            this.label116 = new System.Windows.Forms.Label();
            this.panel21 = new System.Windows.Forms.Panel();
            this.panel24 = new System.Windows.Forms.Panel();
            this.QYKZ = new AttributesEdit.ZLComboBox();
            this.label21 = new System.Windows.Forms.Label();
            this.panel25 = new System.Windows.Forms.Panel();
            this.BH_DJ = new AttributesEdit.ZLComboBox();
            this.label25 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.panel30 = new System.Windows.Forms.Panel();
            this.panel31 = new System.Windows.Forms.Panel();
            this.GJGYL_BHDJ = new AttributesEdit.ZLComboBox();
            this.label33 = new System.Windows.Forms.Label();
            this.panel32 = new System.Windows.Forms.Panel();
            this.TD_TH_LX = new AttributesEdit.ZLComboBox();
            this.label38 = new System.Windows.Forms.Label();
            this.label45 = new System.Windows.Forms.Label();
            this.panel33 = new System.Windows.Forms.Panel();
            this.panel34 = new System.Windows.Forms.Panel();
            this.DISASTER_C = new AttributesEdit.ZLComboBox();
            this.label46 = new System.Windows.Forms.Label();
            this.panel35 = new System.Windows.Forms.Panel();
            this.DISPE = new AttributesEdit.ZLComboBox();
            this.label47 = new System.Windows.Forms.Label();
            this.label48 = new System.Windows.Forms.Label();
            this.label50 = new System.Windows.Forms.Label();
            this.label54 = new System.Windows.Forms.Label();
            this.label57 = new System.Windows.Forms.Label();
            this.panelP24 = new System.Windows.Forms.Panel();
            this.panel65 = new System.Windows.Forms.Panel();
            this.panel66 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.panel74 = new System.Windows.Forms.Panel();
            this.HUO_LMGQXJ = new AttributesEdit.ZLSpinEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.label106 = new System.Windows.Forms.Label();
            this.panel84 = new System.Windows.Forms.Panel();
            this.MEI_GQ_ZS = new AttributesEdit.ZLSpinEdit();
            this.label107 = new System.Windows.Forms.Label();
            this.panel45 = new System.Windows.Forms.Panel();
            this.panel55 = new System.Windows.Forms.Panel();
            this.PINGJUN_DM = new AttributesEdit.ZLSpinEdit();
            this.label119 = new System.Windows.Forms.Label();
            this.label118 = new System.Windows.Forms.Label();
            this.panel46 = new System.Windows.Forms.Panel();
            this.PINGJUN_SG = new AttributesEdit.ZLSpinEdit();
            this.label93 = new System.Windows.Forms.Label();
            this.zlComboBox1 = new AttributesEdit.ZLComboBox();
            this.label68 = new System.Windows.Forms.Label();
            this.label82 = new System.Windows.Forms.Label();
            this.panel54 = new System.Windows.Forms.Panel();
            this.panel50 = new System.Windows.Forms.Panel();
            this.PINGJUN_XJ = new AttributesEdit.ZLSpinEdit();
            this.label69 = new System.Windows.Forms.Label();
            this.label70 = new System.Windows.Forms.Label();
            this.panel67 = new System.Windows.Forms.Panel();
            this.PINGJUN_NL = new AttributesEdit.ZLSpinEdit();
            this.label101 = new System.Windows.Forms.Label();
            this.label109 = new System.Windows.Forms.Label();
            this.label117 = new System.Windows.Forms.Label();
            this.panel68 = new System.Windows.Forms.Panel();
            this.panel69 = new System.Windows.Forms.Panel();
            this.LING_ZU = new AttributesEdit.ZLComboBox();
            this.label72 = new System.Windows.Forms.Label();
            this.panel70 = new System.Windows.Forms.Panel();
            this.YU_BI_DU = new AttributesEdit.ZLSpinEdit();
            this.label51 = new System.Windows.Forms.Label();
            this.label77 = new System.Windows.Forms.Label();
            this.label78 = new System.Windows.Forms.Label();
            this.panel71 = new System.Windows.Forms.Panel();
            this.panel72 = new System.Windows.Forms.Panel();
            this.YOU_SHI_SZ = new AttributesEdit.ZLComboBox();
            this.label79 = new System.Windows.Forms.Label();
            this.panel73 = new System.Windows.Forms.Panel();
            this.QI_YUAN = new AttributesEdit.ZLComboBox();
            this.label80 = new System.Windows.Forms.Label();
            this.label81 = new System.Windows.Forms.Label();
            this.label83 = new System.Windows.Forms.Label();
            this.label84 = new System.Windows.Forms.Label();
            this.label105 = new System.Windows.Forms.Label();
            this.panelP23 = new System.Windows.Forms.Panel();
            this.panel61 = new System.Windows.Forms.Panel();
            this.panel64 = new System.Windows.Forms.Panel();
            this.panel87 = new System.Windows.Forms.Panel();
            this.panel89 = new System.Windows.Forms.Panel();
            this.G_CHENG_LB = new AttributesEdit.ZLComboBox();
            this.label121 = new System.Windows.Forms.Label();
            this.label52 = new System.Windows.Forms.Label();
            this.panel75 = new System.Windows.Forms.Panel();
            this.panel76 = new System.Windows.Forms.Panel();
            this.LIN_ZHONG = new AttributesEdit.ZLComboBox();
            this.label85 = new System.Windows.Forms.Label();
            this.panel80 = new System.Windows.Forms.Panel();
            this.SEN_LIN_LB = new AttributesEdit.ZLComboBox();
            this.label86 = new System.Windows.Forms.Label();
            this.panel81 = new System.Windows.Forms.Panel();
            this.panel82 = new System.Windows.Forms.Panel();
            this.LMSYQ = new AttributesEdit.ZLComboBox();
            this.label88 = new System.Windows.Forms.Label();
            this.panel83 = new System.Windows.Forms.Panel();
            this.LD_QS = new AttributesEdit.ZLComboBox();
            this.label96 = new System.Windows.Forms.Label();
            this.label98 = new System.Windows.Forms.Label();
            this.label102 = new System.Windows.Forms.Label();
            this.label103 = new System.Windows.Forms.Label();
            this.label104 = new System.Windows.Forms.Label();
            this.panelP22 = new System.Windows.Forms.Panel();
            this.panel62 = new System.Windows.Forms.Panel();
            this.panel63 = new System.Windows.Forms.Panel();
            this.panel77 = new System.Windows.Forms.Panel();
            this.panel78 = new System.Windows.Forms.Panel();
            this.ZL_DJ = new AttributesEdit.ZLComboBox();
            this.label89 = new System.Windows.Forms.Label();
            this.panel79 = new System.Windows.Forms.Panel();
            this.DI_LEI = new AttributesEdit.ZLComboBox();
            this.label94 = new System.Windows.Forms.Label();
            this.label97 = new System.Windows.Forms.Label();
            this.label99 = new System.Windows.Forms.Label();
            this.label100 = new System.Windows.Forms.Label();
            this.panelP21 = new System.Windows.Forms.Panel();
            this.panel13 = new System.Windows.Forms.Panel();
            this.panel14 = new System.Windows.Forms.Panel();
            this.panel58 = new System.Windows.Forms.Panel();
            this.panel59 = new System.Windows.Forms.Panel();
            this.KE_JI_DU = new AttributesEdit.ZLComboBox();
            this.label74 = new System.Windows.Forms.Label();
            this.panel60 = new System.Windows.Forms.Panel();
            this.LD_KD = new AttributesEdit.ZLSpinEdit();
            this.label5 = new System.Windows.Forms.Label();
            this.label75 = new System.Windows.Forms.Label();
            this.panel40 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.LD_CD = new AttributesEdit.ZLSpinEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.panel53 = new System.Windows.Forms.Panel();
            this.TU_CENG_HD = new AttributesEdit.ZLSpinEdit();
            this.label4 = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.label73 = new System.Windows.Forms.Label();
            this.panel17 = new System.Windows.Forms.Panel();
            this.panel28 = new System.Windows.Forms.Panel();
            this.TU_RANG_LX = new AttributesEdit.ZLComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.panel38 = new System.Windows.Forms.Panel();
            this.PO_WEI = new AttributesEdit.ZLComboBox();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.panel39 = new System.Windows.Forms.Panel();
            this.panel47 = new System.Windows.Forms.Panel();
            this.PO_DU = new AttributesEdit.ZLComboBox();
            this.label30 = new System.Windows.Forms.Label();
            this.panel48 = new System.Windows.Forms.Panel();
            this.PO_XIANG = new AttributesEdit.ZLComboBox();
            this.label31 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.panel49 = new System.Windows.Forms.Panel();
            this.panel51 = new System.Windows.Forms.Panel();
            this.DI_MAO = new AttributesEdit.ZLComboBox();
            this.label43 = new System.Windows.Forms.Label();
            this.panel52 = new System.Windows.Forms.Panel();
            this.MIAN_JI = new AttributesEdit.ZLSpinEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.label60 = new System.Windows.Forms.Label();
            this.label62 = new System.Windows.Forms.Label();
            this.label71 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label92 = new System.Windows.Forms.Label();
            this.label90 = new System.Windows.Forms.Label();
            this.label91 = new System.Windows.Forms.Label();
            this.label112 = new System.Windows.Forms.Label();
            this.label61 = new System.Windows.Forms.Label();
            this.label108 = new System.Windows.Forms.Label();
            this.label87 = new System.Windows.Forms.Label();
            this.label95 = new System.Windows.Forms.Label();
            this.label76 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label113 = new System.Windows.Forms.Label();
            this.label171 = new System.Windows.Forms.Label();
            this.label172 = new System.Windows.Forms.Label();
            this.label173 = new System.Windows.Forms.Label();
            this.panelControl1 = new System.Windows.Forms.Panel();
            this.panelTitle = new System.Windows.Forms.Panel();
            this.panel27 = new System.Windows.Forms.Panel();
            this.panel29 = new System.Windows.Forms.Panel();
            this.LIN_CHANG = new DevExpress.XtraEditors.TextEdit();
            this.label66 = new System.Windows.Forms.Label();
            this.panel37 = new System.Windows.Forms.Panel();
            this.LIN_YE_JU = new DevExpress.XtraEditors.TextEdit();
            this.label67 = new System.Windows.Forms.Label();
            this.panel22 = new System.Windows.Forms.Panel();
            this.panel23 = new System.Windows.Forms.Panel();
            this.XIAN = new AttributesEdit.ZLComboBox();
            this.label53 = new System.Windows.Forms.Label();
            this.panel26 = new System.Windows.Forms.Panel();
            this.SHENG = new AttributesEdit.ZLComboBox();
            this.label55 = new System.Windows.Forms.Label();
            this.label58 = new System.Windows.Forms.Label();
            this.label56 = new System.Windows.Forms.Label();
            this.panelBasicInfo.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel16.SuspendLayout();
            this.panel18.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BEIZU.Properties)).BeginInit();
            this.panel19.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LIN_BAN.Properties)).BeginInit();
            this.panel11.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NO_TB.Properties)).BeginInit();
            this.panelHS.SuspendLayout();
            this.panel36.SuspendLayout();
            this.panelP26.SuspendLayout();
            this.panel42.SuspendLayout();
            this.panel43.SuspendLayout();
            this.panel44.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BHND.Properties)).BeginInit();
            this.panel56.SuspendLayout();
            this.panel57.SuspendLayout();
            this.panel85.SuspendLayout();
            this.panelP25.SuspendLayout();
            this.panel12.SuspendLayout();
            this.panel15.SuspendLayout();
            this.panel20.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel41.SuspendLayout();
            this.panel86.SuspendLayout();
            this.panel21.SuspendLayout();
            this.panel24.SuspendLayout();
            this.panel25.SuspendLayout();
            this.panel30.SuspendLayout();
            this.panel31.SuspendLayout();
            this.panel32.SuspendLayout();
            this.panel33.SuspendLayout();
            this.panel34.SuspendLayout();
            this.panel35.SuspendLayout();
            this.panelP24.SuspendLayout();
            this.panel65.SuspendLayout();
            this.panel66.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel74.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.HUO_LMGQXJ.Properties)).BeginInit();
            this.panel84.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MEI_GQ_ZS.Properties)).BeginInit();
            this.panel45.SuspendLayout();
            this.panel55.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PINGJUN_DM.Properties)).BeginInit();
            this.panel46.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PINGJUN_SG.Properties)).BeginInit();
            this.panel54.SuspendLayout();
            this.panel50.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PINGJUN_XJ.Properties)).BeginInit();
            this.panel67.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PINGJUN_NL.Properties)).BeginInit();
            this.panel68.SuspendLayout();
            this.panel69.SuspendLayout();
            this.panel70.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.YU_BI_DU.Properties)).BeginInit();
            this.panel71.SuspendLayout();
            this.panel72.SuspendLayout();
            this.panel73.SuspendLayout();
            this.panelP23.SuspendLayout();
            this.panel61.SuspendLayout();
            this.panel64.SuspendLayout();
            this.panel87.SuspendLayout();
            this.panel89.SuspendLayout();
            this.panel75.SuspendLayout();
            this.panel76.SuspendLayout();
            this.panel80.SuspendLayout();
            this.panel81.SuspendLayout();
            this.panel82.SuspendLayout();
            this.panel83.SuspendLayout();
            this.panelP22.SuspendLayout();
            this.panel62.SuspendLayout();
            this.panel63.SuspendLayout();
            this.panel77.SuspendLayout();
            this.panel78.SuspendLayout();
            this.panel79.SuspendLayout();
            this.panelP21.SuspendLayout();
            this.panel13.SuspendLayout();
            this.panel14.SuspendLayout();
            this.panel58.SuspendLayout();
            this.panel59.SuspendLayout();
            this.panel60.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LD_KD.Properties)).BeginInit();
            this.panel40.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LD_CD.Properties)).BeginInit();
            this.panel53.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TU_CENG_HD.Properties)).BeginInit();
            this.panel17.SuspendLayout();
            this.panel28.SuspendLayout();
            this.panel38.SuspendLayout();
            this.panel39.SuspendLayout();
            this.panel47.SuspendLayout();
            this.panel48.SuspendLayout();
            this.panel49.SuspendLayout();
            this.panel51.SuspendLayout();
            this.panel52.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MIAN_JI.Properties)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.panelTitle.SuspendLayout();
            this.panel27.SuspendLayout();
            this.panel29.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LIN_CHANG.Properties)).BeginInit();
            this.panel37.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LIN_YE_JU.Properties)).BeginInit();
            this.panel22.SuspendLayout();
            this.panel23.SuspendLayout();
            this.panel26.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelTitle
            // 
            this.labelTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelTitle.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelTitle.Location = new System.Drawing.Point(0, 0);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(451, 30);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "林地变化图斑核实调查属性记录表";
            this.labelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelBasicInfo
            // 
            this.panelBasicInfo.Controls.Add(this.panel4);
            this.panelBasicInfo.Controls.Add(this.label10);
            this.panelBasicInfo.Controls.Add(this.label35);
            this.panelBasicInfo.Controls.Add(this.label36);
            this.panelBasicInfo.Controls.Add(this.label37);
            this.panelBasicInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelBasicInfo.Location = new System.Drawing.Point(0, 81);
            this.panelBasicInfo.Name = "panelBasicInfo";
            this.panelBasicInfo.Size = new System.Drawing.Size(451, 76);
            this.panelBasicInfo.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.panel16);
            this.panel4.Controls.Add(this.panel7);
            this.panel4.Controls.Add(this.panel1);
            this.panel4.Controls.Add(this.label39);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(78, 1);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(372, 75);
            this.panel4.TabIndex = 0;
            // 
            // panel16
            // 
            this.panel16.Controls.Add(this.panel18);
            this.panel16.Controls.Add(this.label44);
            this.panel16.Controls.Add(this.panel19);
            this.panel16.Controls.Add(this.label49);
            this.panel16.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel16.Location = new System.Drawing.Point(1, 50);
            this.panel16.Name = "panel16";
            this.panel16.Size = new System.Drawing.Size(371, 25);
            this.panel16.TabIndex = 0;
            // 
            // panel18
            // 
            this.panel18.Controls.Add(this.BEIZU);
            this.panel18.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel18.Location = new System.Drawing.Point(218, 0);
            this.panel18.Name = "panel18";
            this.panel18.Padding = new System.Windows.Forms.Padding(2, 6, 8, 0);
            this.panel18.Size = new System.Drawing.Size(146, 25);
            this.panel18.TabIndex = 0;
            // 
            // BEIZU
            // 
            this.BEIZU.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BEIZU.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BEIZU.EditValue = "";
            this.BEIZU.Location = new System.Drawing.Point(2, 6);
            this.BEIZU.Name = "BEIZU";
            this.BEIZU.Properties.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BEIZU.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.BEIZU.Properties.Appearance.Options.UseFont = true;
            this.BEIZU.Properties.Appearance.Options.UseForeColor = true;
            this.BEIZU.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.BEIZU.Properties.MaxLength = 50;
            this.BEIZU.Size = new System.Drawing.Size(136, 16);
            this.BEIZU.TabIndex = 10;
            this.BEIZU.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // label44
            // 
            this.label44.Dock = System.Windows.Forms.DockStyle.Left;
            this.label44.Location = new System.Drawing.Point(182, 0);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(36, 25);
            this.label44.TabIndex = 0;
            this.label44.Text = "备注";
            this.label44.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel19
            // 
            this.panel19.Controls.Add(this.PAN_DILEI);
            this.panel19.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel19.Location = new System.Drawing.Point(77, 0);
            this.panel19.Name = "panel19";
            this.panel19.Padding = new System.Windows.Forms.Padding(2, 4, 4, 0);
            this.panel19.Size = new System.Drawing.Size(105, 25);
            this.panel19.TabIndex = 0;
            // 
            // PAN_DILEI
            // 
            this.PAN_DILEI.AssDispValue = true;
            this.PAN_DILEI.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PAN_DILEI.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PAN_DILEI.ForeColor = System.Drawing.Color.Blue;
            this.PAN_DILEI.Location = new System.Drawing.Point(2, 4);
            this.PAN_DILEI.Name = "PAN_DILEI";
            this.PAN_DILEI.Size = new System.Drawing.Size(99, 20);
            this.PAN_DILEI.TabIndex = 9;
            this.PAN_DILEI.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // label49
            // 
            this.label49.Dock = System.Windows.Forms.DockStyle.Left;
            this.label49.Location = new System.Drawing.Point(0, 0);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(77, 25);
            this.label49.TabIndex = 0;
            this.label49.Text = "判读地类";
            this.label49.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.panel10);
            this.panel7.Controls.Add(this.label40);
            this.panel7.Controls.Add(this.panel11);
            this.panel7.Controls.Add(this.label41);
            this.panel7.Controls.Add(this.label42);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel7.Location = new System.Drawing.Point(1, 25);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(371, 25);
            this.panel7.TabIndex = 0;
            // 
            // panel10
            // 
            this.panel10.Controls.Add(this.LIN_BAN);
            this.panel10.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel10.Location = new System.Drawing.Point(218, 0);
            this.panel10.Name = "panel10";
            this.panel10.Padding = new System.Windows.Forms.Padding(2, 6, 8, 0);
            this.panel10.Size = new System.Drawing.Size(146, 24);
            this.panel10.TabIndex = 0;
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
            this.LIN_BAN.Properties.MaxLength = 10;
            this.LIN_BAN.Size = new System.Drawing.Size(136, 16);
            this.LIN_BAN.TabIndex = 8;
            this.LIN_BAN.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // label40
            // 
            this.label40.Dock = System.Windows.Forms.DockStyle.Left;
            this.label40.Location = new System.Drawing.Point(182, 0);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(36, 24);
            this.label40.TabIndex = 0;
            this.label40.Text = "林班";
            this.label40.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel11
            // 
            this.panel11.Controls.Add(this.CUN);
            this.panel11.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel11.Location = new System.Drawing.Point(77, 0);
            this.panel11.Name = "panel11";
            this.panel11.Padding = new System.Windows.Forms.Padding(2, 4, 4, 0);
            this.panel11.Size = new System.Drawing.Size(105, 24);
            this.panel11.TabIndex = 0;
            // 
            // CUN
            // 
            this.CUN.AssDispValue = true;
            this.CUN.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CUN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CUN.ForeColor = System.Drawing.Color.Blue;
            this.CUN.Location = new System.Drawing.Point(2, 4);
            this.CUN.Name = "CUN";
            this.CUN.Size = new System.Drawing.Size(99, 20);
            this.CUN.TabIndex = 7;
            this.CUN.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // label41
            // 
            this.label41.Dock = System.Windows.Forms.DockStyle.Left;
            this.label41.Location = new System.Drawing.Point(0, 0);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(77, 24);
            this.label41.TabIndex = 0;
            this.label41.Text = "村";
            this.label41.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label42
            // 
            this.label42.BackColor = System.Drawing.Color.Black;
            this.label42.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label42.Location = new System.Drawing.Point(0, 24);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(371, 1);
            this.label42.TabIndex = 0;
            this.label42.Text = "label42";
            this.label42.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.panel6);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(1, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(371, 25);
            this.panel1.TabIndex = 0;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.XIANG);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel5.Location = new System.Drawing.Point(259, 0);
            this.panel5.Name = "panel5";
            this.panel5.Padding = new System.Windows.Forms.Padding(2, 4, 4, 0);
            this.panel5.Size = new System.Drawing.Size(105, 24);
            this.panel5.TabIndex = 0;
            // 
            // XIANG
            // 
            this.XIANG.AssDispValue = true;
            this.XIANG.Cursor = System.Windows.Forms.Cursors.Hand;
            this.XIANG.Dock = System.Windows.Forms.DockStyle.Fill;
            this.XIANG.ForeColor = System.Drawing.Color.Blue;
            this.XIANG.Location = new System.Drawing.Point(2, 4);
            this.XIANG.Name = "XIANG";
            this.XIANG.Size = new System.Drawing.Size(99, 20);
            this.XIANG.TabIndex = 6;
            this.XIANG.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // label11
            // 
            this.label11.Dock = System.Windows.Forms.DockStyle.Left;
            this.label11.Location = new System.Drawing.Point(182, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(77, 24);
            this.label11.TabIndex = 0;
            this.label11.Text = "乡（镇、场）";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.NO_TB);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel6.Location = new System.Drawing.Point(77, 0);
            this.panel6.Name = "panel6";
            this.panel6.Padding = new System.Windows.Forms.Padding(2, 6, 8, 0);
            this.panel6.Size = new System.Drawing.Size(105, 24);
            this.panel6.TabIndex = 0;
            // 
            // NO_TB
            // 
            this.NO_TB.Cursor = System.Windows.Forms.Cursors.Hand;
            this.NO_TB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NO_TB.EditValue = "";
            this.NO_TB.Location = new System.Drawing.Point(2, 6);
            this.NO_TB.Name = "NO_TB";
            this.NO_TB.Properties.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.NO_TB.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.NO_TB.Properties.Appearance.Options.UseFont = true;
            this.NO_TB.Properties.Appearance.Options.UseForeColor = true;
            this.NO_TB.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.NO_TB.Properties.MaxLength = 50;
            this.NO_TB.Size = new System.Drawing.Size(95, 16);
            this.NO_TB.TabIndex = 5;
            // 
            // label12
            // 
            this.label12.Dock = System.Windows.Forms.DockStyle.Left;
            this.label12.Location = new System.Drawing.Point(0, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(77, 24);
            this.label12.TabIndex = 0;
            this.label12.Text = "判读图斑编号";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.Color.Black;
            this.label13.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label13.Location = new System.Drawing.Point(0, 24);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(371, 1);
            this.label13.TabIndex = 0;
            this.label13.Text = "label13";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label39
            // 
            this.label39.BackColor = System.Drawing.Color.Black;
            this.label39.Dock = System.Windows.Forms.DockStyle.Left;
            this.label39.Location = new System.Drawing.Point(0, 0);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(1, 75);
            this.label39.TabIndex = 0;
            this.label39.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            this.label10.Dock = System.Windows.Forms.DockStyle.Left;
            this.label10.Location = new System.Drawing.Point(1, 1);
            this.label10.Name = "label10";
            this.label10.Padding = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Size = new System.Drawing.Size(77, 75);
            this.label10.TabIndex = 0;
            this.label10.Text = "遥感判读区划图斑因子";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label35
            // 
            this.label35.BackColor = System.Drawing.Color.Black;
            this.label35.Dock = System.Windows.Forms.DockStyle.Top;
            this.label35.Location = new System.Drawing.Point(1, 0);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(449, 1);
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
            this.label37.Location = new System.Drawing.Point(450, 0);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(1, 76);
            this.label37.TabIndex = 0;
            this.label37.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelHS
            // 
            this.panelHS.Controls.Add(this.panel36);
            this.panelHS.Controls.Add(this.label8);
            this.panelHS.Controls.Add(this.label92);
            this.panelHS.Controls.Add(this.label90);
            this.panelHS.Controls.Add(this.label91);
            this.panelHS.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHS.Location = new System.Drawing.Point(0, 157);
            this.panelHS.Name = "panelHS";
            this.panelHS.Size = new System.Drawing.Size(451, 530);
            this.panelHS.TabIndex = 0;
            // 
            // panel36
            // 
            this.panel36.Controls.Add(this.panelP26);
            this.panel36.Controls.Add(this.panelP25);
            this.panel36.Controls.Add(this.panelP24);
            this.panel36.Controls.Add(this.panelP23);
            this.panel36.Controls.Add(this.panelP22);
            this.panel36.Controls.Add(this.panelP21);
            this.panel36.Controls.Add(this.label16);
            this.panel36.Controls.Add(this.label7);
            this.panel36.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel36.Location = new System.Drawing.Point(1, 1);
            this.panel36.Name = "panel36";
            this.panel36.Size = new System.Drawing.Size(449, 528);
            this.panel36.TabIndex = 0;
            // 
            // panelP26
            // 
            this.panelP26.Controls.Add(this.panel42);
            this.panelP26.Controls.Add(this.label111);
            this.panelP26.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelP26.Location = new System.Drawing.Point(21, 480);
            this.panelP26.Name = "panelP26";
            this.panelP26.Size = new System.Drawing.Size(428, 51);
            this.panelP26.TabIndex = 0;
            // 
            // panel42
            // 
            this.panel42.Controls.Add(this.panel43);
            this.panel42.Controls.Add(this.label110);
            this.panel42.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel42.Location = new System.Drawing.Point(57, 0);
            this.panel42.Name = "panel42";
            this.panel42.Size = new System.Drawing.Size(371, 51);
            this.panel42.TabIndex = 0;
            // 
            // panel43
            // 
            this.panel43.Controls.Add(this.panel44);
            this.panel43.Controls.Add(this.panel56);
            this.panel43.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel43.Location = new System.Drawing.Point(1, 0);
            this.panel43.Name = "panel43";
            this.panel43.Size = new System.Drawing.Size(370, 51);
            this.panel43.TabIndex = 0;
            // 
            // panel44
            // 
            this.panel44.Controls.Add(this.panel3);
            this.panel44.Controls.Add(this.label59);
            this.panel44.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel44.Location = new System.Drawing.Point(0, 25);
            this.panel44.Name = "panel44";
            this.panel44.Size = new System.Drawing.Size(370, 25);
            this.panel44.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.BHND);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(77, 0);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(2, 6, 8, 0);
            this.panel3.Size = new System.Drawing.Size(105, 25);
            this.panel3.TabIndex = 0;
            // 
            // BHND
            // 
            this.BHND.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BHND.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BHND.EditValue = "";
            this.BHND.Location = new System.Drawing.Point(2, 6);
            this.BHND.Name = "BHND";
            this.BHND.Properties.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BHND.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.BHND.Properties.Appearance.Options.UseFont = true;
            this.BHND.Properties.Appearance.Options.UseForeColor = true;
            this.BHND.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.BHND.Properties.MaxLength = 10;
            this.BHND.Size = new System.Drawing.Size(95, 16);
            this.BHND.TabIndex = 49;
            this.BHND.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // label59
            // 
            this.label59.Dock = System.Windows.Forms.DockStyle.Left;
            this.label59.Location = new System.Drawing.Point(0, 0);
            this.label59.Name = "label59";
            this.label59.Size = new System.Drawing.Size(77, 25);
            this.label59.TabIndex = 0;
            this.label59.Text = "变化年度";
            this.label59.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel56
            // 
            this.panel56.Controls.Add(this.panel57);
            this.panel56.Controls.Add(this.label63);
            this.panel56.Controls.Add(this.panel85);
            this.panel56.Controls.Add(this.label64);
            this.panel56.Controls.Add(this.label65);
            this.panel56.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel56.Location = new System.Drawing.Point(0, 0);
            this.panel56.Name = "panel56";
            this.panel56.Size = new System.Drawing.Size(370, 25);
            this.panel56.TabIndex = 0;
            // 
            // panel57
            // 
            this.panel57.Controls.Add(this.LDGLLX);
            this.panel57.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel57.Location = new System.Drawing.Point(259, 0);
            this.panel57.Name = "panel57";
            this.panel57.Padding = new System.Windows.Forms.Padding(2, 4, 4, 0);
            this.panel57.Size = new System.Drawing.Size(105, 24);
            this.panel57.TabIndex = 0;
            // 
            // LDGLLX
            // 
            this.LDGLLX.AssDispValue = true;
            this.LDGLLX.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LDGLLX.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LDGLLX.ForeColor = System.Drawing.Color.Blue;
            this.LDGLLX.Location = new System.Drawing.Point(2, 4);
            this.LDGLLX.Name = "LDGLLX";
            this.LDGLLX.Size = new System.Drawing.Size(99, 20);
            this.LDGLLX.TabIndex = 48;
            this.LDGLLX.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // label63
            // 
            this.label63.Dock = System.Windows.Forms.DockStyle.Left;
            this.label63.Location = new System.Drawing.Point(182, 0);
            this.label63.Name = "label63";
            this.label63.Size = new System.Drawing.Size(77, 24);
            this.label63.TabIndex = 0;
            this.label63.Text = "林地管理类型";
            this.label63.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel85
            // 
            this.panel85.Controls.Add(this.BHYY);
            this.panel85.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel85.Location = new System.Drawing.Point(77, 0);
            this.panel85.Name = "panel85";
            this.panel85.Padding = new System.Windows.Forms.Padding(2, 4, 4, 0);
            this.panel85.Size = new System.Drawing.Size(105, 24);
            this.panel85.TabIndex = 0;
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
            this.BHYY.TabIndex = 47;
            this.BHYY.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // label64
            // 
            this.label64.Dock = System.Windows.Forms.DockStyle.Left;
            this.label64.Location = new System.Drawing.Point(0, 0);
            this.label64.Name = "label64";
            this.label64.Size = new System.Drawing.Size(77, 24);
            this.label64.TabIndex = 0;
            this.label64.Text = "变化原因";
            this.label64.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label65
            // 
            this.label65.BackColor = System.Drawing.Color.Black;
            this.label65.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label65.Location = new System.Drawing.Point(0, 24);
            this.label65.Name = "label65";
            this.label65.Size = new System.Drawing.Size(370, 1);
            this.label65.TabIndex = 0;
            this.label65.Text = "label65";
            this.label65.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label110
            // 
            this.label110.BackColor = System.Drawing.Color.Black;
            this.label110.Dock = System.Windows.Forms.DockStyle.Left;
            this.label110.Location = new System.Drawing.Point(0, 0);
            this.label110.Name = "label110";
            this.label110.Size = new System.Drawing.Size(1, 51);
            this.label110.TabIndex = 0;
            this.label110.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label111
            // 
            this.label111.Dock = System.Windows.Forms.DockStyle.Left;
            this.label111.Location = new System.Drawing.Point(0, 0);
            this.label111.Name = "label111";
            this.label111.Padding = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label111.Size = new System.Drawing.Size(57, 51);
            this.label111.TabIndex = 0;
            this.label111.Text = "管理因子";
            this.label111.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelP25
            // 
            this.panelP25.Controls.Add(this.panel12);
            this.panelP25.Controls.Add(this.label54);
            this.panelP25.Controls.Add(this.label57);
            this.panelP25.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelP25.Location = new System.Drawing.Point(21, 353);
            this.panelP25.Name = "panelP25";
            this.panelP25.Size = new System.Drawing.Size(428, 127);
            this.panelP25.TabIndex = 0;
            // 
            // panel12
            // 
            this.panel12.Controls.Add(this.panel15);
            this.panel12.Controls.Add(this.label50);
            this.panel12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel12.Location = new System.Drawing.Point(57, 0);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(371, 126);
            this.panel12.TabIndex = 0;
            // 
            // panel15
            // 
            this.panel15.Controls.Add(this.panel20);
            this.panel15.Controls.Add(this.label9);
            this.panel15.Controls.Add(this.panel9);
            this.panel15.Controls.Add(this.panel21);
            this.panel15.Controls.Add(this.panel30);
            this.panel15.Controls.Add(this.panel33);
            this.panel15.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel15.Location = new System.Drawing.Point(1, 0);
            this.panel15.Name = "panel15";
            this.panel15.Size = new System.Drawing.Size(370, 126);
            this.panel15.TabIndex = 0;
            // 
            // panel20
            // 
            this.panel20.Controls.Add(this.LYFQ);
            this.panel20.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel20.Location = new System.Drawing.Point(77, 100);
            this.panel20.Name = "panel20";
            this.panel20.Padding = new System.Windows.Forms.Padding(2, 4, 4, 0);
            this.panel20.Size = new System.Drawing.Size(270, 26);
            this.panel20.TabIndex = 0;
            // 
            // LYFQ
            // 
            this.LYFQ.AssDispValue = true;
            this.LYFQ.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LYFQ.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LYFQ.ForeColor = System.Drawing.Color.Blue;
            this.LYFQ.Location = new System.Drawing.Point(2, 4);
            this.LYFQ.Name = "LYFQ";
            this.LYFQ.Size = new System.Drawing.Size(264, 20);
            this.LYFQ.TabIndex = 46;
            this.LYFQ.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // label9
            // 
            this.label9.Dock = System.Windows.Forms.DockStyle.Left;
            this.label9.Location = new System.Drawing.Point(0, 100);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 26);
            this.label9.TabIndex = 0;
            this.label9.Text = "林地功能分区";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.panel41);
            this.panel9.Controls.Add(this.label114);
            this.panel9.Controls.Add(this.panel86);
            this.panel9.Controls.Add(this.label115);
            this.panel9.Controls.Add(this.label116);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel9.Location = new System.Drawing.Point(0, 75);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(370, 25);
            this.panel9.TabIndex = 0;
            // 
            // panel41
            // 
            this.panel41.Controls.Add(this.BCLD);
            this.panel41.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel41.Location = new System.Drawing.Point(259, 0);
            this.panel41.Name = "panel41";
            this.panel41.Padding = new System.Windows.Forms.Padding(2, 4, 4, 0);
            this.panel41.Size = new System.Drawing.Size(105, 24);
            this.panel41.TabIndex = 0;
            // 
            // BCLD
            // 
            this.BCLD.AssDispValue = true;
            this.BCLD.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BCLD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BCLD.ForeColor = System.Drawing.Color.Blue;
            this.BCLD.Location = new System.Drawing.Point(2, 4);
            this.BCLD.Name = "BCLD";
            this.BCLD.Size = new System.Drawing.Size(99, 20);
            this.BCLD.TabIndex = 45;
            this.BCLD.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // label114
            // 
            this.label114.Dock = System.Windows.Forms.DockStyle.Left;
            this.label114.Location = new System.Drawing.Point(182, 0);
            this.label114.Name = "label114";
            this.label114.Size = new System.Drawing.Size(77, 24);
            this.label114.TabIndex = 0;
            this.label114.Text = "林地范围变化类型";
            this.label114.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel86
            // 
            this.panel86.Controls.Add(this.SHI_QUAN_D);
            this.panel86.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel86.Location = new System.Drawing.Point(77, 0);
            this.panel86.Name = "panel86";
            this.panel86.Padding = new System.Windows.Forms.Padding(2, 4, 4, 0);
            this.panel86.Size = new System.Drawing.Size(105, 24);
            this.panel86.TabIndex = 0;
            // 
            // SHI_QUAN_D
            // 
            this.SHI_QUAN_D.AssDispValue = true;
            this.SHI_QUAN_D.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SHI_QUAN_D.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SHI_QUAN_D.ForeColor = System.Drawing.Color.Blue;
            this.SHI_QUAN_D.Location = new System.Drawing.Point(2, 4);
            this.SHI_QUAN_D.Name = "SHI_QUAN_D";
            this.SHI_QUAN_D.Size = new System.Drawing.Size(99, 20);
            this.SHI_QUAN_D.TabIndex = 44;
            this.SHI_QUAN_D.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // label115
            // 
            this.label115.Dock = System.Windows.Forms.DockStyle.Left;
            this.label115.Location = new System.Drawing.Point(0, 0);
            this.label115.Name = "label115";
            this.label115.Size = new System.Drawing.Size(77, 24);
            this.label115.TabIndex = 0;
            this.label115.Text = "事权等级";
            this.label115.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label116
            // 
            this.label116.BackColor = System.Drawing.Color.Black;
            this.label116.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label116.Location = new System.Drawing.Point(0, 24);
            this.label116.Name = "label116";
            this.label116.Size = new System.Drawing.Size(370, 1);
            this.label116.TabIndex = 0;
            this.label116.Text = "label116";
            this.label116.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel21
            // 
            this.panel21.Controls.Add(this.panel24);
            this.panel21.Controls.Add(this.label21);
            this.panel21.Controls.Add(this.panel25);
            this.panel21.Controls.Add(this.label25);
            this.panel21.Controls.Add(this.label28);
            this.panel21.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel21.Location = new System.Drawing.Point(0, 50);
            this.panel21.Name = "panel21";
            this.panel21.Size = new System.Drawing.Size(370, 25);
            this.panel21.TabIndex = 0;
            // 
            // panel24
            // 
            this.panel24.Controls.Add(this.QYKZ);
            this.panel24.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel24.Location = new System.Drawing.Point(259, 0);
            this.panel24.Name = "panel24";
            this.panel24.Padding = new System.Windows.Forms.Padding(2, 4, 4, 0);
            this.panel24.Size = new System.Drawing.Size(105, 24);
            this.panel24.TabIndex = 0;
            // 
            // QYKZ
            // 
            this.QYKZ.AssDispValue = true;
            this.QYKZ.Cursor = System.Windows.Forms.Cursors.Hand;
            this.QYKZ.Dock = System.Windows.Forms.DockStyle.Fill;
            this.QYKZ.ForeColor = System.Drawing.Color.Blue;
            this.QYKZ.Location = new System.Drawing.Point(2, 4);
            this.QYKZ.Name = "QYKZ";
            this.QYKZ.Size = new System.Drawing.Size(99, 20);
            this.QYKZ.TabIndex = 43;
            this.QYKZ.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // label21
            // 
            this.label21.Dock = System.Windows.Forms.DockStyle.Left;
            this.label21.Location = new System.Drawing.Point(182, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(77, 24);
            this.label21.TabIndex = 0;
            this.label21.Text = "主体功能区";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel25
            // 
            this.panel25.Controls.Add(this.BH_DJ);
            this.panel25.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel25.Location = new System.Drawing.Point(77, 0);
            this.panel25.Name = "panel25";
            this.panel25.Padding = new System.Windows.Forms.Padding(2, 4, 4, 0);
            this.panel25.Size = new System.Drawing.Size(105, 24);
            this.panel25.TabIndex = 0;
            // 
            // BH_DJ
            // 
            this.BH_DJ.AssDispValue = true;
            this.BH_DJ.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BH_DJ.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BH_DJ.ForeColor = System.Drawing.Color.Blue;
            this.BH_DJ.Location = new System.Drawing.Point(2, 4);
            this.BH_DJ.Name = "BH_DJ";
            this.BH_DJ.Size = new System.Drawing.Size(99, 20);
            this.BH_DJ.TabIndex = 42;
            this.BH_DJ.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // label25
            // 
            this.label25.Dock = System.Windows.Forms.DockStyle.Left;
            this.label25.Location = new System.Drawing.Point(0, 0);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(77, 24);
            this.label25.TabIndex = 0;
            this.label25.Text = "林地保护等级";
            this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label28
            // 
            this.label28.BackColor = System.Drawing.Color.Black;
            this.label28.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label28.Location = new System.Drawing.Point(0, 24);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(370, 1);
            this.label28.TabIndex = 0;
            this.label28.Text = "label28";
            this.label28.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel30
            // 
            this.panel30.Controls.Add(this.panel31);
            this.panel30.Controls.Add(this.label33);
            this.panel30.Controls.Add(this.panel32);
            this.panel30.Controls.Add(this.label38);
            this.panel30.Controls.Add(this.label45);
            this.panel30.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel30.Location = new System.Drawing.Point(0, 25);
            this.panel30.Name = "panel30";
            this.panel30.Size = new System.Drawing.Size(370, 25);
            this.panel30.TabIndex = 0;
            // 
            // panel31
            // 
            this.panel31.Controls.Add(this.GJGYL_BHDJ);
            this.panel31.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel31.Location = new System.Drawing.Point(259, 0);
            this.panel31.Name = "panel31";
            this.panel31.Padding = new System.Windows.Forms.Padding(2, 4, 4, 0);
            this.panel31.Size = new System.Drawing.Size(105, 24);
            this.panel31.TabIndex = 0;
            // 
            // GJGYL_BHDJ
            // 
            this.GJGYL_BHDJ.AssDispValue = true;
            this.GJGYL_BHDJ.Cursor = System.Windows.Forms.Cursors.Hand;
            this.GJGYL_BHDJ.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GJGYL_BHDJ.ForeColor = System.Drawing.Color.Blue;
            this.GJGYL_BHDJ.Location = new System.Drawing.Point(2, 4);
            this.GJGYL_BHDJ.Name = "GJGYL_BHDJ";
            this.GJGYL_BHDJ.Size = new System.Drawing.Size(99, 20);
            this.GJGYL_BHDJ.TabIndex = 41;
            this.GJGYL_BHDJ.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // label33
            // 
            this.label33.Dock = System.Windows.Forms.DockStyle.Left;
            this.label33.Location = new System.Drawing.Point(182, 0);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(77, 24);
            this.label33.TabIndex = 0;
            this.label33.Text = "国家级公益林保护等级";
            this.label33.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel32
            // 
            this.panel32.Controls.Add(this.TD_TH_LX);
            this.panel32.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel32.Location = new System.Drawing.Point(77, 0);
            this.panel32.Name = "panel32";
            this.panel32.Padding = new System.Windows.Forms.Padding(2, 4, 4, 0);
            this.panel32.Size = new System.Drawing.Size(105, 24);
            this.panel32.TabIndex = 0;
            // 
            // TD_TH_LX
            // 
            this.TD_TH_LX.AssDispValue = true;
            this.TD_TH_LX.Cursor = System.Windows.Forms.Cursors.Hand;
            this.TD_TH_LX.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TD_TH_LX.ForeColor = System.Drawing.Color.Blue;
            this.TD_TH_LX.Location = new System.Drawing.Point(2, 4);
            this.TD_TH_LX.Name = "TD_TH_LX";
            this.TD_TH_LX.Size = new System.Drawing.Size(99, 20);
            this.TD_TH_LX.TabIndex = 40;
            this.TD_TH_LX.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // label38
            // 
            this.label38.Dock = System.Windows.Forms.DockStyle.Left;
            this.label38.Location = new System.Drawing.Point(0, 0);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(77, 24);
            this.label38.TabIndex = 0;
            this.label38.Text = "土地退化类型";
            this.label38.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label45
            // 
            this.label45.BackColor = System.Drawing.Color.Black;
            this.label45.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label45.Location = new System.Drawing.Point(0, 24);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(370, 1);
            this.label45.TabIndex = 0;
            this.label45.Text = "label45";
            this.label45.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel33
            // 
            this.panel33.Controls.Add(this.panel34);
            this.panel33.Controls.Add(this.label46);
            this.panel33.Controls.Add(this.panel35);
            this.panel33.Controls.Add(this.label47);
            this.panel33.Controls.Add(this.label48);
            this.panel33.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel33.Location = new System.Drawing.Point(0, 0);
            this.panel33.Name = "panel33";
            this.panel33.Size = new System.Drawing.Size(370, 25);
            this.panel33.TabIndex = 0;
            // 
            // panel34
            // 
            this.panel34.Controls.Add(this.DISASTER_C);
            this.panel34.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel34.Location = new System.Drawing.Point(259, 0);
            this.panel34.Name = "panel34";
            this.panel34.Padding = new System.Windows.Forms.Padding(2, 4, 4, 0);
            this.panel34.Size = new System.Drawing.Size(105, 24);
            this.panel34.TabIndex = 0;
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
            this.DISASTER_C.TabIndex = 39;
            this.DISASTER_C.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // label46
            // 
            this.label46.Dock = System.Windows.Forms.DockStyle.Left;
            this.label46.Location = new System.Drawing.Point(182, 0);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(77, 24);
            this.label46.TabIndex = 0;
            this.label46.Text = "灾害等级";
            this.label46.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel35
            // 
            this.panel35.Controls.Add(this.DISPE);
            this.panel35.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel35.Location = new System.Drawing.Point(77, 0);
            this.panel35.Name = "panel35";
            this.panel35.Padding = new System.Windows.Forms.Padding(2, 4, 4, 0);
            this.panel35.Size = new System.Drawing.Size(105, 24);
            this.panel35.TabIndex = 0;
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
            this.DISPE.TabIndex = 38;
            this.DISPE.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // label47
            // 
            this.label47.Dock = System.Windows.Forms.DockStyle.Left;
            this.label47.Location = new System.Drawing.Point(0, 0);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(77, 24);
            this.label47.TabIndex = 0;
            this.label47.Text = "灾害类型";
            this.label47.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label48
            // 
            this.label48.BackColor = System.Drawing.Color.Black;
            this.label48.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label48.Location = new System.Drawing.Point(0, 24);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(370, 1);
            this.label48.TabIndex = 0;
            this.label48.Text = "label48";
            this.label48.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label50
            // 
            this.label50.BackColor = System.Drawing.Color.Black;
            this.label50.Dock = System.Windows.Forms.DockStyle.Left;
            this.label50.Location = new System.Drawing.Point(0, 0);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(1, 126);
            this.label50.TabIndex = 0;
            this.label50.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label54
            // 
            this.label54.Dock = System.Windows.Forms.DockStyle.Left;
            this.label54.Location = new System.Drawing.Point(0, 0);
            this.label54.Name = "label54";
            this.label54.Padding = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label54.Size = new System.Drawing.Size(57, 126);
            this.label54.TabIndex = 0;
            this.label54.Text = "其他因子";
            this.label54.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label57
            // 
            this.label57.BackColor = System.Drawing.Color.Black;
            this.label57.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label57.Location = new System.Drawing.Point(0, 126);
            this.label57.Name = "label57";
            this.label57.Size = new System.Drawing.Size(428, 1);
            this.label57.TabIndex = 0;
            this.label57.Text = "label57";
            this.label57.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelP24
            // 
            this.panelP24.Controls.Add(this.panel65);
            this.panelP24.Controls.Add(this.label84);
            this.panelP24.Controls.Add(this.label105);
            this.panelP24.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelP24.Location = new System.Drawing.Point(21, 228);
            this.panelP24.Name = "panelP24";
            this.panelP24.Size = new System.Drawing.Size(428, 125);
            this.panelP24.TabIndex = 0;
            // 
            // panel65
            // 
            this.panel65.Controls.Add(this.panel66);
            this.panel65.Controls.Add(this.label83);
            this.panel65.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel65.Location = new System.Drawing.Point(57, 0);
            this.panel65.Name = "panel65";
            this.panel65.Size = new System.Drawing.Size(371, 124);
            this.panel65.TabIndex = 0;
            // 
            // panel66
            // 
            this.panel66.Controls.Add(this.panel8);
            this.panel66.Controls.Add(this.panel45);
            this.panel66.Controls.Add(this.panel54);
            this.panel66.Controls.Add(this.panel68);
            this.panel66.Controls.Add(this.panel71);
            this.panel66.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel66.Location = new System.Drawing.Point(1, 0);
            this.panel66.Name = "panel66";
            this.panel66.Size = new System.Drawing.Size(370, 124);
            this.panel66.TabIndex = 0;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.panel74);
            this.panel8.Controls.Add(this.label106);
            this.panel8.Controls.Add(this.panel84);
            this.panel8.Controls.Add(this.label107);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel8.Location = new System.Drawing.Point(0, 100);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(370, 25);
            this.panel8.TabIndex = 0;
            // 
            // panel74
            // 
            this.panel74.Controls.Add(this.HUO_LMGQXJ);
            this.panel74.Controls.Add(this.label2);
            this.panel74.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel74.Location = new System.Drawing.Point(259, 0);
            this.panel74.Name = "panel74";
            this.panel74.Padding = new System.Windows.Forms.Padding(2, 6, 6, 2);
            this.panel74.Size = new System.Drawing.Size(105, 25);
            this.panel74.TabIndex = 0;
            // 
            // HUO_LMGQXJ
            // 
            this.HUO_LMGQXJ.Cursor = System.Windows.Forms.Cursors.Hand;
            this.HUO_LMGQXJ.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.HUO_LMGQXJ.EditScale = 0;
            this.HUO_LMGQXJ.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.HUO_LMGQXJ.Location = new System.Drawing.Point(2, 5);
            this.HUO_LMGQXJ.Name = "HUO_LMGQXJ";
            this.HUO_LMGQXJ.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.HUO_LMGQXJ.Properties.Appearance.Options.UseForeColor = true;
            this.HUO_LMGQXJ.Properties.Appearance.Options.UseTextOptions = true;
            this.HUO_LMGQXJ.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.HUO_LMGQXJ.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.HUO_LMGQXJ.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.HUO_LMGQXJ.Properties.MaxValue = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.HUO_LMGQXJ.Size = new System.Drawing.Size(72, 18);
            this.HUO_LMGQXJ.TabIndex = 37;
            this.HUO_LMGQXJ.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Right;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Blue;
            this.label2.Location = new System.Drawing.Point(74, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "m³";
            // 
            // label106
            // 
            this.label106.Dock = System.Windows.Forms.DockStyle.Left;
            this.label106.Location = new System.Drawing.Point(182, 0);
            this.label106.Name = "label106";
            this.label106.Size = new System.Drawing.Size(77, 25);
            this.label106.TabIndex = 0;
            this.label106.Text = "公顷蓄积";
            this.label106.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel84
            // 
            this.panel84.Controls.Add(this.MEI_GQ_ZS);
            this.panel84.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel84.Location = new System.Drawing.Point(77, 0);
            this.panel84.Name = "panel84";
            this.panel84.Padding = new System.Windows.Forms.Padding(2, 6, 6, 2);
            this.panel84.Size = new System.Drawing.Size(105, 25);
            this.panel84.TabIndex = 0;
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
            this.MEI_GQ_ZS.Location = new System.Drawing.Point(2, 5);
            this.MEI_GQ_ZS.Name = "MEI_GQ_ZS";
            this.MEI_GQ_ZS.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.MEI_GQ_ZS.Properties.Appearance.Options.UseForeColor = true;
            this.MEI_GQ_ZS.Properties.Appearance.Options.UseTextOptions = true;
            this.MEI_GQ_ZS.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.MEI_GQ_ZS.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.MEI_GQ_ZS.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.MEI_GQ_ZS.Properties.MaxValue = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.MEI_GQ_ZS.Size = new System.Drawing.Size(97, 18);
            this.MEI_GQ_ZS.TabIndex = 36;
            this.MEI_GQ_ZS.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // label107
            // 
            this.label107.Dock = System.Windows.Forms.DockStyle.Left;
            this.label107.Location = new System.Drawing.Point(0, 0);
            this.label107.Name = "label107";
            this.label107.Size = new System.Drawing.Size(77, 25);
            this.label107.TabIndex = 0;
            this.label107.Text = "每公顷株数";
            this.label107.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel45
            // 
            this.panel45.Controls.Add(this.panel55);
            this.panel45.Controls.Add(this.label118);
            this.panel45.Controls.Add(this.panel46);
            this.panel45.Controls.Add(this.label68);
            this.panel45.Controls.Add(this.label82);
            this.panel45.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel45.Location = new System.Drawing.Point(0, 75);
            this.panel45.Name = "panel45";
            this.panel45.Size = new System.Drawing.Size(370, 25);
            this.panel45.TabIndex = 0;
            // 
            // panel55
            // 
            this.panel55.Controls.Add(this.PINGJUN_DM);
            this.panel55.Controls.Add(this.label119);
            this.panel55.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel55.Location = new System.Drawing.Point(259, 0);
            this.panel55.Name = "panel55";
            this.panel55.Padding = new System.Windows.Forms.Padding(2, 6, 6, 2);
            this.panel55.Size = new System.Drawing.Size(105, 24);
            this.panel55.TabIndex = 0;
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
            10000,
            0,
            0,
            0});
            this.PINGJUN_DM.Size = new System.Drawing.Size(72, 18);
            this.PINGJUN_DM.TabIndex = 35;
            this.PINGJUN_DM.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // label119
            // 
            this.label119.Dock = System.Windows.Forms.DockStyle.Right;
            this.label119.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label119.ForeColor = System.Drawing.Color.Blue;
            this.label119.Location = new System.Drawing.Point(74, 6);
            this.label119.Name = "label119";
            this.label119.Size = new System.Drawing.Size(25, 16);
            this.label119.TabIndex = 0;
            this.label119.Text = "m²";
            // 
            // label118
            // 
            this.label118.Dock = System.Windows.Forms.DockStyle.Left;
            this.label118.Location = new System.Drawing.Point(182, 0);
            this.label118.Name = "label118";
            this.label118.Size = new System.Drawing.Size(77, 24);
            this.label118.TabIndex = 0;
            this.label118.Text = "每公顷断面";
            this.label118.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel46
            // 
            this.panel46.Controls.Add(this.PINGJUN_SG);
            this.panel46.Controls.Add(this.label93);
            this.panel46.Controls.Add(this.zlComboBox1);
            this.panel46.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel46.Location = new System.Drawing.Point(77, 0);
            this.panel46.Name = "panel46";
            this.panel46.Padding = new System.Windows.Forms.Padding(2, 4, 4, 0);
            this.panel46.Size = new System.Drawing.Size(105, 24);
            this.panel46.TabIndex = 0;
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
            this.PINGJUN_SG.Location = new System.Drawing.Point(2, 6);
            this.PINGJUN_SG.Name = "PINGJUN_SG";
            this.PINGJUN_SG.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.PINGJUN_SG.Properties.Appearance.Options.UseForeColor = true;
            this.PINGJUN_SG.Properties.Appearance.Options.UseTextOptions = true;
            this.PINGJUN_SG.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.PINGJUN_SG.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.PINGJUN_SG.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.PINGJUN_SG.Properties.MaxValue = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.PINGJUN_SG.Size = new System.Drawing.Size(74, 18);
            this.PINGJUN_SG.TabIndex = 34;
            this.PINGJUN_SG.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // label93
            // 
            this.label93.Dock = System.Windows.Forms.DockStyle.Right;
            this.label93.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label93.ForeColor = System.Drawing.Color.Blue;
            this.label93.Location = new System.Drawing.Point(76, 4);
            this.label93.Name = "label93";
            this.label93.Size = new System.Drawing.Size(25, 20);
            this.label93.TabIndex = 0;
            this.label93.Text = "m";
            // 
            // zlComboBox1
            // 
            this.zlComboBox1.AssDispValue = true;
            this.zlComboBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.zlComboBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zlComboBox1.ForeColor = System.Drawing.Color.Blue;
            this.zlComboBox1.Location = new System.Drawing.Point(2, 4);
            this.zlComboBox1.Name = "zlComboBox1";
            this.zlComboBox1.Size = new System.Drawing.Size(99, 20);
            this.zlComboBox1.TabIndex = 0;
            // 
            // label68
            // 
            this.label68.Dock = System.Windows.Forms.DockStyle.Left;
            this.label68.Location = new System.Drawing.Point(0, 0);
            this.label68.Name = "label68";
            this.label68.Size = new System.Drawing.Size(77, 24);
            this.label68.TabIndex = 0;
            this.label68.Text = "平均树高";
            this.label68.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label82
            // 
            this.label82.BackColor = System.Drawing.Color.Black;
            this.label82.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label82.Location = new System.Drawing.Point(0, 24);
            this.label82.Name = "label82";
            this.label82.Size = new System.Drawing.Size(370, 1);
            this.label82.TabIndex = 0;
            this.label82.Text = "label82";
            this.label82.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel54
            // 
            this.panel54.Controls.Add(this.panel50);
            this.panel54.Controls.Add(this.label70);
            this.panel54.Controls.Add(this.panel67);
            this.panel54.Controls.Add(this.label109);
            this.panel54.Controls.Add(this.label117);
            this.panel54.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel54.Location = new System.Drawing.Point(0, 50);
            this.panel54.Name = "panel54";
            this.panel54.Size = new System.Drawing.Size(370, 25);
            this.panel54.TabIndex = 2;
            // 
            // panel50
            // 
            this.panel50.Controls.Add(this.PINGJUN_XJ);
            this.panel50.Controls.Add(this.label69);
            this.panel50.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel50.Location = new System.Drawing.Point(259, 0);
            this.panel50.Name = "panel50";
            this.panel50.Padding = new System.Windows.Forms.Padding(2, 6, 6, 2);
            this.panel50.Size = new System.Drawing.Size(105, 24);
            this.panel50.TabIndex = 2;
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
            100000,
            0,
            0,
            0});
            this.PINGJUN_XJ.Size = new System.Drawing.Size(72, 18);
            this.PINGJUN_XJ.TabIndex = 33;
            this.PINGJUN_XJ.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // label69
            // 
            this.label69.Dock = System.Windows.Forms.DockStyle.Right;
            this.label69.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label69.ForeColor = System.Drawing.Color.Blue;
            this.label69.Location = new System.Drawing.Point(74, 6);
            this.label69.Name = "label69";
            this.label69.Size = new System.Drawing.Size(25, 16);
            this.label69.TabIndex = 0;
            this.label69.Text = "cm";
            // 
            // label70
            // 
            this.label70.Dock = System.Windows.Forms.DockStyle.Left;
            this.label70.Location = new System.Drawing.Point(182, 0);
            this.label70.Name = "label70";
            this.label70.Size = new System.Drawing.Size(77, 24);
            this.label70.TabIndex = 1;
            this.label70.Text = "平均胸径";
            this.label70.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel67
            // 
            this.panel67.Controls.Add(this.PINGJUN_NL);
            this.panel67.Controls.Add(this.label101);
            this.panel67.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel67.Location = new System.Drawing.Point(77, 0);
            this.panel67.Name = "panel67";
            this.panel67.Padding = new System.Windows.Forms.Padding(2, 6, 6, 2);
            this.panel67.Size = new System.Drawing.Size(105, 24);
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
            100000,
            0,
            0,
            0});
            this.PINGJUN_NL.Size = new System.Drawing.Size(72, 18);
            this.PINGJUN_NL.TabIndex = 32;
            this.PINGJUN_NL.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // label101
            // 
            this.label101.Dock = System.Windows.Forms.DockStyle.Right;
            this.label101.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label101.ForeColor = System.Drawing.Color.Blue;
            this.label101.Location = new System.Drawing.Point(74, 6);
            this.label101.Name = "label101";
            this.label101.Size = new System.Drawing.Size(25, 16);
            this.label101.TabIndex = 0;
            // 
            // label109
            // 
            this.label109.Dock = System.Windows.Forms.DockStyle.Left;
            this.label109.Location = new System.Drawing.Point(0, 0);
            this.label109.Name = "label109";
            this.label109.Size = new System.Drawing.Size(77, 24);
            this.label109.TabIndex = 0;
            this.label109.Text = "平均年龄";
            this.label109.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label117
            // 
            this.label117.BackColor = System.Drawing.Color.Black;
            this.label117.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label117.Location = new System.Drawing.Point(0, 24);
            this.label117.Name = "label117";
            this.label117.Size = new System.Drawing.Size(370, 1);
            this.label117.TabIndex = 0;
            this.label117.Text = "label117";
            this.label117.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel68
            // 
            this.panel68.Controls.Add(this.panel69);
            this.panel68.Controls.Add(this.label72);
            this.panel68.Controls.Add(this.panel70);
            this.panel68.Controls.Add(this.label77);
            this.panel68.Controls.Add(this.label78);
            this.panel68.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel68.Location = new System.Drawing.Point(0, 25);
            this.panel68.Name = "panel68";
            this.panel68.Size = new System.Drawing.Size(370, 25);
            this.panel68.TabIndex = 0;
            // 
            // panel69
            // 
            this.panel69.Controls.Add(this.LING_ZU);
            this.panel69.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel69.Location = new System.Drawing.Point(259, 0);
            this.panel69.Name = "panel69";
            this.panel69.Padding = new System.Windows.Forms.Padding(2, 4, 4, 0);
            this.panel69.Size = new System.Drawing.Size(105, 24);
            this.panel69.TabIndex = 2;
            // 
            // LING_ZU
            // 
            this.LING_ZU.AssDispValue = true;
            this.LING_ZU.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LING_ZU.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LING_ZU.ForeColor = System.Drawing.Color.Blue;
            this.LING_ZU.Location = new System.Drawing.Point(2, 4);
            this.LING_ZU.Name = "LING_ZU";
            this.LING_ZU.Size = new System.Drawing.Size(99, 20);
            this.LING_ZU.TabIndex = 31;
            this.LING_ZU.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // label72
            // 
            this.label72.Dock = System.Windows.Forms.DockStyle.Left;
            this.label72.Location = new System.Drawing.Point(182, 0);
            this.label72.Name = "label72";
            this.label72.Size = new System.Drawing.Size(77, 24);
            this.label72.TabIndex = 1;
            this.label72.Text = "龄组";
            this.label72.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel70
            // 
            this.panel70.Controls.Add(this.YU_BI_DU);
            this.panel70.Controls.Add(this.label51);
            this.panel70.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel70.Location = new System.Drawing.Point(77, 0);
            this.panel70.Name = "panel70";
            this.panel70.Padding = new System.Windows.Forms.Padding(2, 6, 6, 2);
            this.panel70.Size = new System.Drawing.Size(105, 24);
            this.panel70.TabIndex = 0;
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
            this.YU_BI_DU.TabIndex = 30;
            this.YU_BI_DU.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // label51
            // 
            this.label51.Dock = System.Windows.Forms.DockStyle.Right;
            this.label51.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label51.ForeColor = System.Drawing.Color.Blue;
            this.label51.Location = new System.Drawing.Point(74, 6);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(25, 16);
            this.label51.TabIndex = 0;
            // 
            // label77
            // 
            this.label77.Dock = System.Windows.Forms.DockStyle.Left;
            this.label77.Location = new System.Drawing.Point(0, 0);
            this.label77.Name = "label77";
            this.label77.Size = new System.Drawing.Size(77, 24);
            this.label77.TabIndex = 0;
            this.label77.Text = "郁闭度";
            this.label77.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label78
            // 
            this.label78.BackColor = System.Drawing.Color.Black;
            this.label78.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label78.Location = new System.Drawing.Point(0, 24);
            this.label78.Name = "label78";
            this.label78.Size = new System.Drawing.Size(370, 1);
            this.label78.TabIndex = 0;
            this.label78.Text = "label78";
            this.label78.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel71
            // 
            this.panel71.Controls.Add(this.panel72);
            this.panel71.Controls.Add(this.label79);
            this.panel71.Controls.Add(this.panel73);
            this.panel71.Controls.Add(this.label80);
            this.panel71.Controls.Add(this.label81);
            this.panel71.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel71.Location = new System.Drawing.Point(0, 0);
            this.panel71.Name = "panel71";
            this.panel71.Size = new System.Drawing.Size(370, 25);
            this.panel71.TabIndex = 0;
            // 
            // panel72
            // 
            this.panel72.Controls.Add(this.YOU_SHI_SZ);
            this.panel72.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel72.Location = new System.Drawing.Point(259, 0);
            this.panel72.Name = "panel72";
            this.panel72.Padding = new System.Windows.Forms.Padding(2, 4, 4, 0);
            this.panel72.Size = new System.Drawing.Size(105, 24);
            this.panel72.TabIndex = 0;
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
            this.YOU_SHI_SZ.TabIndex = 29;
            this.YOU_SHI_SZ.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // label79
            // 
            this.label79.Dock = System.Windows.Forms.DockStyle.Left;
            this.label79.Location = new System.Drawing.Point(182, 0);
            this.label79.Name = "label79";
            this.label79.Size = new System.Drawing.Size(77, 24);
            this.label79.TabIndex = 0;
            this.label79.Text = "优势树种";
            this.label79.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel73
            // 
            this.panel73.Controls.Add(this.QI_YUAN);
            this.panel73.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel73.Location = new System.Drawing.Point(77, 0);
            this.panel73.Name = "panel73";
            this.panel73.Padding = new System.Windows.Forms.Padding(2, 4, 4, 0);
            this.panel73.Size = new System.Drawing.Size(105, 24);
            this.panel73.TabIndex = 0;
            // 
            // QI_YUAN
            // 
            this.QI_YUAN.AssDispValue = true;
            this.QI_YUAN.Cursor = System.Windows.Forms.Cursors.Hand;
            this.QI_YUAN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.QI_YUAN.ForeColor = System.Drawing.Color.Blue;
            this.QI_YUAN.Location = new System.Drawing.Point(2, 4);
            this.QI_YUAN.Name = "QI_YUAN";
            this.QI_YUAN.Size = new System.Drawing.Size(99, 20);
            this.QI_YUAN.TabIndex = 28;
            this.QI_YUAN.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // label80
            // 
            this.label80.Dock = System.Windows.Forms.DockStyle.Left;
            this.label80.Location = new System.Drawing.Point(0, 0);
            this.label80.Name = "label80";
            this.label80.Size = new System.Drawing.Size(77, 24);
            this.label80.TabIndex = 0;
            this.label80.Text = "起源";
            this.label80.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label81
            // 
            this.label81.BackColor = System.Drawing.Color.Black;
            this.label81.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label81.Location = new System.Drawing.Point(0, 24);
            this.label81.Name = "label81";
            this.label81.Size = new System.Drawing.Size(370, 1);
            this.label81.TabIndex = 0;
            this.label81.Text = "label81";
            this.label81.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label83
            // 
            this.label83.BackColor = System.Drawing.Color.Black;
            this.label83.Dock = System.Windows.Forms.DockStyle.Left;
            this.label83.Location = new System.Drawing.Point(0, 0);
            this.label83.Name = "label83";
            this.label83.Size = new System.Drawing.Size(1, 124);
            this.label83.TabIndex = 0;
            this.label83.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label84
            // 
            this.label84.Dock = System.Windows.Forms.DockStyle.Left;
            this.label84.Location = new System.Drawing.Point(0, 0);
            this.label84.Name = "label84";
            this.label84.Padding = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label84.Size = new System.Drawing.Size(57, 124);
            this.label84.TabIndex = 0;
            this.label84.Text = "林分因子";
            this.label84.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label105
            // 
            this.label105.BackColor = System.Drawing.Color.Black;
            this.label105.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label105.Location = new System.Drawing.Point(0, 124);
            this.label105.Name = "label105";
            this.label105.Size = new System.Drawing.Size(428, 1);
            this.label105.TabIndex = 0;
            this.label105.Text = "label105";
            this.label105.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelP23
            // 
            this.panelP23.Controls.Add(this.panel61);
            this.panelP23.Controls.Add(this.label103);
            this.panelP23.Controls.Add(this.label104);
            this.panelP23.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelP23.Location = new System.Drawing.Point(21, 152);
            this.panelP23.Name = "panelP23";
            this.panelP23.Size = new System.Drawing.Size(428, 76);
            this.panelP23.TabIndex = 0;
            // 
            // panel61
            // 
            this.panel61.Controls.Add(this.panel64);
            this.panel61.Controls.Add(this.label102);
            this.panel61.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel61.Location = new System.Drawing.Point(57, 0);
            this.panel61.Name = "panel61";
            this.panel61.Size = new System.Drawing.Size(371, 75);
            this.panel61.TabIndex = 0;
            // 
            // panel64
            // 
            this.panel64.Controls.Add(this.panel87);
            this.panel64.Controls.Add(this.label52);
            this.panel64.Controls.Add(this.panel75);
            this.panel64.Controls.Add(this.panel81);
            this.panel64.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel64.Location = new System.Drawing.Point(1, 0);
            this.panel64.Name = "panel64";
            this.panel64.Size = new System.Drawing.Size(370, 75);
            this.panel64.TabIndex = 0;
            // 
            // panel87
            // 
            this.panel87.Controls.Add(this.panel89);
            this.panel87.Controls.Add(this.label121);
            this.panel87.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel87.Location = new System.Drawing.Point(0, 51);
            this.panel87.Name = "panel87";
            this.panel87.Size = new System.Drawing.Size(370, 25);
            this.panel87.TabIndex = 0;
            // 
            // panel89
            // 
            this.panel89.Controls.Add(this.G_CHENG_LB);
            this.panel89.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel89.Location = new System.Drawing.Point(77, 0);
            this.panel89.Name = "panel89";
            this.panel89.Padding = new System.Windows.Forms.Padding(2, 4, 4, 0);
            this.panel89.Size = new System.Drawing.Size(256, 25);
            this.panel89.TabIndex = 0;
            // 
            // G_CHENG_LB
            // 
            this.G_CHENG_LB.AssDispValue = true;
            this.G_CHENG_LB.Cursor = System.Windows.Forms.Cursors.Hand;
            this.G_CHENG_LB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.G_CHENG_LB.ForeColor = System.Drawing.Color.Blue;
            this.G_CHENG_LB.Location = new System.Drawing.Point(2, 4);
            this.G_CHENG_LB.Name = "G_CHENG_LB";
            this.G_CHENG_LB.Size = new System.Drawing.Size(250, 20);
            this.G_CHENG_LB.TabIndex = 27;
            this.G_CHENG_LB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // label121
            // 
            this.label121.Dock = System.Windows.Forms.DockStyle.Left;
            this.label121.Location = new System.Drawing.Point(0, 0);
            this.label121.Name = "label121";
            this.label121.Size = new System.Drawing.Size(77, 25);
            this.label121.TabIndex = 0;
            this.label121.Text = "工程类别";
            this.label121.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label52
            // 
            this.label52.BackColor = System.Drawing.Color.Black;
            this.label52.Dock = System.Windows.Forms.DockStyle.Top;
            this.label52.Location = new System.Drawing.Point(0, 50);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(370, 1);
            this.label52.TabIndex = 0;
            this.label52.Text = "label52";
            this.label52.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel75
            // 
            this.panel75.Controls.Add(this.panel76);
            this.panel75.Controls.Add(this.label85);
            this.panel75.Controls.Add(this.panel80);
            this.panel75.Controls.Add(this.label86);
            this.panel75.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel75.Location = new System.Drawing.Point(0, 25);
            this.panel75.Name = "panel75";
            this.panel75.Size = new System.Drawing.Size(370, 25);
            this.panel75.TabIndex = 0;
            // 
            // panel76
            // 
            this.panel76.Controls.Add(this.LIN_ZHONG);
            this.panel76.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel76.Location = new System.Drawing.Point(259, 0);
            this.panel76.Name = "panel76";
            this.panel76.Padding = new System.Windows.Forms.Padding(2, 4, 4, 0);
            this.panel76.Size = new System.Drawing.Size(105, 25);
            this.panel76.TabIndex = 0;
            // 
            // LIN_ZHONG
            // 
            this.LIN_ZHONG.AssDispValue = true;
            this.LIN_ZHONG.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LIN_ZHONG.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LIN_ZHONG.ForeColor = System.Drawing.Color.Blue;
            this.LIN_ZHONG.Location = new System.Drawing.Point(2, 4);
            this.LIN_ZHONG.Name = "LIN_ZHONG";
            this.LIN_ZHONG.Size = new System.Drawing.Size(99, 20);
            this.LIN_ZHONG.TabIndex = 26;
            this.LIN_ZHONG.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // label85
            // 
            this.label85.Dock = System.Windows.Forms.DockStyle.Left;
            this.label85.Location = new System.Drawing.Point(182, 0);
            this.label85.Name = "label85";
            this.label85.Size = new System.Drawing.Size(77, 25);
            this.label85.TabIndex = 0;
            this.label85.Text = "林种";
            this.label85.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel80
            // 
            this.panel80.Controls.Add(this.SEN_LIN_LB);
            this.panel80.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel80.Location = new System.Drawing.Point(77, 0);
            this.panel80.Name = "panel80";
            this.panel80.Padding = new System.Windows.Forms.Padding(2, 4, 4, 0);
            this.panel80.Size = new System.Drawing.Size(105, 25);
            this.panel80.TabIndex = 0;
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
            this.SEN_LIN_LB.TabIndex = 25;
            this.SEN_LIN_LB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // label86
            // 
            this.label86.Dock = System.Windows.Forms.DockStyle.Left;
            this.label86.Location = new System.Drawing.Point(0, 0);
            this.label86.Name = "label86";
            this.label86.Size = new System.Drawing.Size(77, 25);
            this.label86.TabIndex = 0;
            this.label86.Text = "森林类别";
            this.label86.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel81
            // 
            this.panel81.Controls.Add(this.panel82);
            this.panel81.Controls.Add(this.label88);
            this.panel81.Controls.Add(this.panel83);
            this.panel81.Controls.Add(this.label96);
            this.panel81.Controls.Add(this.label98);
            this.panel81.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel81.Location = new System.Drawing.Point(0, 0);
            this.panel81.Name = "panel81";
            this.panel81.Size = new System.Drawing.Size(370, 25);
            this.panel81.TabIndex = 0;
            // 
            // panel82
            // 
            this.panel82.Controls.Add(this.LMSYQ);
            this.panel82.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel82.Location = new System.Drawing.Point(259, 0);
            this.panel82.Name = "panel82";
            this.panel82.Padding = new System.Windows.Forms.Padding(2, 4, 4, 0);
            this.panel82.Size = new System.Drawing.Size(105, 24);
            this.panel82.TabIndex = 0;
            // 
            // LMSYQ
            // 
            this.LMSYQ.AssDispValue = true;
            this.LMSYQ.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LMSYQ.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LMSYQ.ForeColor = System.Drawing.Color.Blue;
            this.LMSYQ.Location = new System.Drawing.Point(2, 4);
            this.LMSYQ.Name = "LMSYQ";
            this.LMSYQ.Size = new System.Drawing.Size(99, 20);
            this.LMSYQ.TabIndex = 24;
            this.LMSYQ.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // label88
            // 
            this.label88.Dock = System.Windows.Forms.DockStyle.Left;
            this.label88.Location = new System.Drawing.Point(182, 0);
            this.label88.Name = "label88";
            this.label88.Size = new System.Drawing.Size(77, 24);
            this.label88.TabIndex = 0;
            this.label88.Text = "林木权属";
            this.label88.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel83
            // 
            this.panel83.Controls.Add(this.LD_QS);
            this.panel83.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel83.Location = new System.Drawing.Point(77, 0);
            this.panel83.Name = "panel83";
            this.panel83.Padding = new System.Windows.Forms.Padding(2, 4, 4, 0);
            this.panel83.Size = new System.Drawing.Size(105, 24);
            this.panel83.TabIndex = 0;
            // 
            // LD_QS
            // 
            this.LD_QS.AssDispValue = true;
            this.LD_QS.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LD_QS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LD_QS.ForeColor = System.Drawing.Color.Blue;
            this.LD_QS.Location = new System.Drawing.Point(2, 4);
            this.LD_QS.Name = "LD_QS";
            this.LD_QS.Size = new System.Drawing.Size(99, 20);
            this.LD_QS.TabIndex = 23;
            this.LD_QS.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // label96
            // 
            this.label96.Dock = System.Windows.Forms.DockStyle.Left;
            this.label96.Location = new System.Drawing.Point(0, 0);
            this.label96.Name = "label96";
            this.label96.Size = new System.Drawing.Size(77, 24);
            this.label96.TabIndex = 0;
            this.label96.Text = "土地权属";
            this.label96.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label98
            // 
            this.label98.BackColor = System.Drawing.Color.Black;
            this.label98.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label98.Location = new System.Drawing.Point(0, 24);
            this.label98.Name = "label98";
            this.label98.Size = new System.Drawing.Size(370, 1);
            this.label98.TabIndex = 0;
            this.label98.Text = "label98";
            this.label98.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label102
            // 
            this.label102.BackColor = System.Drawing.Color.Black;
            this.label102.Dock = System.Windows.Forms.DockStyle.Left;
            this.label102.Location = new System.Drawing.Point(0, 0);
            this.label102.Name = "label102";
            this.label102.Size = new System.Drawing.Size(1, 75);
            this.label102.TabIndex = 0;
            this.label102.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label103
            // 
            this.label103.Dock = System.Windows.Forms.DockStyle.Left;
            this.label103.Location = new System.Drawing.Point(0, 0);
            this.label103.Name = "label103";
            this.label103.Padding = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label103.Size = new System.Drawing.Size(57, 75);
            this.label103.TabIndex = 0;
            this.label103.Text = "管理因子";
            this.label103.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label104
            // 
            this.label104.BackColor = System.Drawing.Color.Black;
            this.label104.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label104.Location = new System.Drawing.Point(0, 75);
            this.label104.Name = "label104";
            this.label104.Size = new System.Drawing.Size(428, 1);
            this.label104.TabIndex = 0;
            this.label104.Text = "label104";
            this.label104.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelP22
            // 
            this.panelP22.Controls.Add(this.panel62);
            this.panelP22.Controls.Add(this.label99);
            this.panelP22.Controls.Add(this.label100);
            this.panelP22.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelP22.Location = new System.Drawing.Point(21, 126);
            this.panelP22.Name = "panelP22";
            this.panelP22.Size = new System.Drawing.Size(428, 26);
            this.panelP22.TabIndex = 0;
            // 
            // panel62
            // 
            this.panel62.Controls.Add(this.panel63);
            this.panel62.Controls.Add(this.label97);
            this.panel62.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel62.Location = new System.Drawing.Point(57, 0);
            this.panel62.Name = "panel62";
            this.panel62.Size = new System.Drawing.Size(371, 25);
            this.panel62.TabIndex = 0;
            // 
            // panel63
            // 
            this.panel63.Controls.Add(this.panel77);
            this.panel63.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel63.Location = new System.Drawing.Point(1, 0);
            this.panel63.Name = "panel63";
            this.panel63.Size = new System.Drawing.Size(370, 25);
            this.panel63.TabIndex = 0;
            // 
            // panel77
            // 
            this.panel77.Controls.Add(this.panel78);
            this.panel77.Controls.Add(this.label89);
            this.panel77.Controls.Add(this.panel79);
            this.panel77.Controls.Add(this.label94);
            this.panel77.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel77.Location = new System.Drawing.Point(0, 0);
            this.panel77.Name = "panel77";
            this.panel77.Size = new System.Drawing.Size(370, 25);
            this.panel77.TabIndex = 0;
            // 
            // panel78
            // 
            this.panel78.Controls.Add(this.ZL_DJ);
            this.panel78.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel78.Location = new System.Drawing.Point(259, 0);
            this.panel78.Name = "panel78";
            this.panel78.Padding = new System.Windows.Forms.Padding(2, 4, 4, 0);
            this.panel78.Size = new System.Drawing.Size(105, 25);
            this.panel78.TabIndex = 0;
            // 
            // ZL_DJ
            // 
            this.ZL_DJ.AssDispValue = true;
            this.ZL_DJ.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ZL_DJ.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ZL_DJ.ForeColor = System.Drawing.Color.Blue;
            this.ZL_DJ.Location = new System.Drawing.Point(2, 4);
            this.ZL_DJ.Name = "ZL_DJ";
            this.ZL_DJ.Size = new System.Drawing.Size(99, 20);
            this.ZL_DJ.TabIndex = 22;
            this.ZL_DJ.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // label89
            // 
            this.label89.Dock = System.Windows.Forms.DockStyle.Left;
            this.label89.Location = new System.Drawing.Point(182, 0);
            this.label89.Name = "label89";
            this.label89.Size = new System.Drawing.Size(77, 25);
            this.label89.TabIndex = 0;
            this.label89.Text = "林地质量等级";
            this.label89.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel79
            // 
            this.panel79.Controls.Add(this.DI_LEI);
            this.panel79.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel79.Location = new System.Drawing.Point(77, 0);
            this.panel79.Name = "panel79";
            this.panel79.Padding = new System.Windows.Forms.Padding(2, 4, 4, 0);
            this.panel79.Size = new System.Drawing.Size(105, 25);
            this.panel79.TabIndex = 0;
            // 
            // DI_LEI
            // 
            this.DI_LEI.AssDispValue = true;
            this.DI_LEI.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DI_LEI.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DI_LEI.ForeColor = System.Drawing.Color.Blue;
            this.DI_LEI.Location = new System.Drawing.Point(2, 4);
            this.DI_LEI.Name = "DI_LEI";
            this.DI_LEI.Size = new System.Drawing.Size(99, 20);
            this.DI_LEI.TabIndex = 21;
            this.DI_LEI.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // label94
            // 
            this.label94.Dock = System.Windows.Forms.DockStyle.Left;
            this.label94.Location = new System.Drawing.Point(0, 0);
            this.label94.Name = "label94";
            this.label94.Size = new System.Drawing.Size(77, 25);
            this.label94.TabIndex = 0;
            this.label94.Text = "地类";
            this.label94.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label97
            // 
            this.label97.BackColor = System.Drawing.Color.Black;
            this.label97.Dock = System.Windows.Forms.DockStyle.Left;
            this.label97.Location = new System.Drawing.Point(0, 0);
            this.label97.Name = "label97";
            this.label97.Size = new System.Drawing.Size(1, 25);
            this.label97.TabIndex = 0;
            this.label97.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label99
            // 
            this.label99.Dock = System.Windows.Forms.DockStyle.Left;
            this.label99.Location = new System.Drawing.Point(0, 0);
            this.label99.Name = "label99";
            this.label99.Padding = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label99.Size = new System.Drawing.Size(57, 25);
            this.label99.TabIndex = 0;
            this.label99.Text = "林地因子";
            this.label99.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label100
            // 
            this.label100.BackColor = System.Drawing.Color.Black;
            this.label100.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label100.Location = new System.Drawing.Point(0, 25);
            this.label100.Name = "label100";
            this.label100.Size = new System.Drawing.Size(428, 1);
            this.label100.TabIndex = 0;
            this.label100.Text = "label100";
            this.label100.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelP21
            // 
            this.panelP21.Controls.Add(this.panel13);
            this.panelP21.Controls.Add(this.label26);
            this.panelP21.Controls.Add(this.label27);
            this.panelP21.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelP21.Location = new System.Drawing.Point(21, 0);
            this.panelP21.Name = "panelP21";
            this.panelP21.Size = new System.Drawing.Size(428, 126);
            this.panelP21.TabIndex = 0;
            // 
            // panel13
            // 
            this.panel13.Controls.Add(this.panel14);
            this.panel13.Controls.Add(this.label71);
            this.panel13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel13.Location = new System.Drawing.Point(57, 0);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(371, 125);
            this.panel13.TabIndex = 0;
            // 
            // panel14
            // 
            this.panel14.Controls.Add(this.panel58);
            this.panel14.Controls.Add(this.panel40);
            this.panel14.Controls.Add(this.panel17);
            this.panel14.Controls.Add(this.panel39);
            this.panel14.Controls.Add(this.panel49);
            this.panel14.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel14.Location = new System.Drawing.Point(1, 0);
            this.panel14.Name = "panel14";
            this.panel14.Size = new System.Drawing.Size(370, 125);
            this.panel14.TabIndex = 0;
            // 
            // panel58
            // 
            this.panel58.Controls.Add(this.panel59);
            this.panel58.Controls.Add(this.label74);
            this.panel58.Controls.Add(this.panel60);
            this.panel58.Controls.Add(this.label75);
            this.panel58.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel58.Location = new System.Drawing.Point(0, 100);
            this.panel58.Name = "panel58";
            this.panel58.Size = new System.Drawing.Size(370, 25);
            this.panel58.TabIndex = 0;
            // 
            // panel59
            // 
            this.panel59.Controls.Add(this.KE_JI_DU);
            this.panel59.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel59.Location = new System.Drawing.Point(259, 0);
            this.panel59.Name = "panel59";
            this.panel59.Padding = new System.Windows.Forms.Padding(2, 4, 4, 0);
            this.panel59.Size = new System.Drawing.Size(105, 25);
            this.panel59.TabIndex = 0;
            // 
            // KE_JI_DU
            // 
            this.KE_JI_DU.AssDispValue = true;
            this.KE_JI_DU.Cursor = System.Windows.Forms.Cursors.Hand;
            this.KE_JI_DU.Dock = System.Windows.Forms.DockStyle.Fill;
            this.KE_JI_DU.ForeColor = System.Drawing.Color.Blue;
            this.KE_JI_DU.Location = new System.Drawing.Point(2, 4);
            this.KE_JI_DU.Name = "KE_JI_DU";
            this.KE_JI_DU.Size = new System.Drawing.Size(99, 20);
            this.KE_JI_DU.TabIndex = 20;
            this.KE_JI_DU.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // label74
            // 
            this.label74.Dock = System.Windows.Forms.DockStyle.Left;
            this.label74.Location = new System.Drawing.Point(182, 0);
            this.label74.Name = "label74";
            this.label74.Size = new System.Drawing.Size(77, 25);
            this.label74.TabIndex = 0;
            this.label74.Text = "交通区位";
            this.label74.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel60
            // 
            this.panel60.Controls.Add(this.LD_KD);
            this.panel60.Controls.Add(this.label5);
            this.panel60.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel60.Location = new System.Drawing.Point(77, 0);
            this.panel60.Name = "panel60";
            this.panel60.Padding = new System.Windows.Forms.Padding(2, 6, 6, 2);
            this.panel60.Size = new System.Drawing.Size(105, 25);
            this.panel60.TabIndex = 0;
            // 
            // LD_KD
            // 
            this.LD_KD.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LD_KD.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.LD_KD.EditScale = 0;
            this.LD_KD.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.LD_KD.Location = new System.Drawing.Point(2, 5);
            this.LD_KD.Name = "LD_KD";
            this.LD_KD.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.LD_KD.Properties.Appearance.Options.UseForeColor = true;
            this.LD_KD.Properties.Appearance.Options.UseTextOptions = true;
            this.LD_KD.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.LD_KD.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.LD_KD.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.LD_KD.Properties.MaxValue = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.LD_KD.Size = new System.Drawing.Size(72, 18);
            this.LD_KD.TabIndex = 19;
            this.LD_KD.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // label5
            // 
            this.label5.Dock = System.Windows.Forms.DockStyle.Right;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Blue;
            this.label5.Location = new System.Drawing.Point(74, 6);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(25, 17);
            this.label5.TabIndex = 0;
            this.label5.Text = "m";
            // 
            // label75
            // 
            this.label75.Dock = System.Windows.Forms.DockStyle.Left;
            this.label75.Location = new System.Drawing.Point(0, 0);
            this.label75.Name = "label75";
            this.label75.Size = new System.Drawing.Size(77, 25);
            this.label75.TabIndex = 0;
            this.label75.Text = "林带宽度";
            this.label75.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel40
            // 
            this.panel40.Controls.Add(this.panel2);
            this.panel40.Controls.Add(this.label29);
            this.panel40.Controls.Add(this.panel53);
            this.panel40.Controls.Add(this.label34);
            this.panel40.Controls.Add(this.label73);
            this.panel40.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel40.Location = new System.Drawing.Point(0, 75);
            this.panel40.Name = "panel40";
            this.panel40.Size = new System.Drawing.Size(370, 25);
            this.panel40.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.LD_CD);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(259, 0);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(2, 6, 6, 2);
            this.panel2.Size = new System.Drawing.Size(105, 24);
            this.panel2.TabIndex = 0;
            // 
            // LD_CD
            // 
            this.LD_CD.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LD_CD.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.LD_CD.EditScale = 0;
            this.LD_CD.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.LD_CD.Location = new System.Drawing.Point(2, 4);
            this.LD_CD.Name = "LD_CD";
            this.LD_CD.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.LD_CD.Properties.Appearance.Options.UseForeColor = true;
            this.LD_CD.Properties.Appearance.Options.UseTextOptions = true;
            this.LD_CD.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.LD_CD.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.LD_CD.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.LD_CD.Properties.MaxValue = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.LD_CD.Size = new System.Drawing.Size(72, 18);
            this.LD_CD.TabIndex = 18;
            this.LD_CD.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Right;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(74, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "m";
            // 
            // label29
            // 
            this.label29.Dock = System.Windows.Forms.DockStyle.Left;
            this.label29.Location = new System.Drawing.Point(182, 0);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(77, 24);
            this.label29.TabIndex = 0;
            this.label29.Text = "林带长度";
            this.label29.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel53
            // 
            this.panel53.Controls.Add(this.TU_CENG_HD);
            this.panel53.Controls.Add(this.label4);
            this.panel53.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel53.Location = new System.Drawing.Point(77, 0);
            this.panel53.Name = "panel53";
            this.panel53.Padding = new System.Windows.Forms.Padding(2, 6, 6, 2);
            this.panel53.Size = new System.Drawing.Size(105, 24);
            this.panel53.TabIndex = 0;
            // 
            // TU_CENG_HD
            // 
            this.TU_CENG_HD.Cursor = System.Windows.Forms.Cursors.Hand;
            this.TU_CENG_HD.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.TU_CENG_HD.EditScale = 0;
            this.TU_CENG_HD.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.TU_CENG_HD.Location = new System.Drawing.Point(2, 4);
            this.TU_CENG_HD.Name = "TU_CENG_HD";
            this.TU_CENG_HD.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.TU_CENG_HD.Properties.Appearance.Options.UseForeColor = true;
            this.TU_CENG_HD.Properties.Appearance.Options.UseTextOptions = true;
            this.TU_CENG_HD.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.TU_CENG_HD.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.TU_CENG_HD.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.TU_CENG_HD.Properties.MaxValue = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.TU_CENG_HD.Size = new System.Drawing.Size(72, 18);
            this.TU_CENG_HD.TabIndex = 17;
            this.TU_CENG_HD.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Right;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Blue;
            this.label4.Location = new System.Drawing.Point(74, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(25, 16);
            this.label4.TabIndex = 0;
            this.label4.Text = "cm";
            // 
            // label34
            // 
            this.label34.Dock = System.Windows.Forms.DockStyle.Left;
            this.label34.Location = new System.Drawing.Point(0, 0);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(77, 24);
            this.label34.TabIndex = 0;
            this.label34.Text = "土层厚度";
            this.label34.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label73
            // 
            this.label73.BackColor = System.Drawing.Color.Black;
            this.label73.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label73.Location = new System.Drawing.Point(0, 24);
            this.label73.Name = "label73";
            this.label73.Size = new System.Drawing.Size(370, 1);
            this.label73.TabIndex = 0;
            this.label73.Text = "label73";
            this.label73.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel17
            // 
            this.panel17.Controls.Add(this.panel28);
            this.panel17.Controls.Add(this.label17);
            this.panel17.Controls.Add(this.panel38);
            this.panel17.Controls.Add(this.label23);
            this.panel17.Controls.Add(this.label24);
            this.panel17.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel17.Location = new System.Drawing.Point(0, 50);
            this.panel17.Name = "panel17";
            this.panel17.Size = new System.Drawing.Size(370, 25);
            this.panel17.TabIndex = 0;
            // 
            // panel28
            // 
            this.panel28.Controls.Add(this.TU_RANG_LX);
            this.panel28.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel28.Location = new System.Drawing.Point(259, 0);
            this.panel28.Name = "panel28";
            this.panel28.Padding = new System.Windows.Forms.Padding(2, 4, 4, 0);
            this.panel28.Size = new System.Drawing.Size(105, 24);
            this.panel28.TabIndex = 0;
            // 
            // TU_RANG_LX
            // 
            this.TU_RANG_LX.AssDispValue = true;
            this.TU_RANG_LX.Cursor = System.Windows.Forms.Cursors.Hand;
            this.TU_RANG_LX.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TU_RANG_LX.ForeColor = System.Drawing.Color.Blue;
            this.TU_RANG_LX.Location = new System.Drawing.Point(2, 4);
            this.TU_RANG_LX.Name = "TU_RANG_LX";
            this.TU_RANG_LX.Size = new System.Drawing.Size(99, 20);
            this.TU_RANG_LX.TabIndex = 16;
            this.TU_RANG_LX.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // label17
            // 
            this.label17.Dock = System.Windows.Forms.DockStyle.Left;
            this.label17.Location = new System.Drawing.Point(182, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(77, 24);
            this.label17.TabIndex = 0;
            this.label17.Text = "土壤类型";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel38
            // 
            this.panel38.Controls.Add(this.PO_WEI);
            this.panel38.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel38.Location = new System.Drawing.Point(77, 0);
            this.panel38.Name = "panel38";
            this.panel38.Padding = new System.Windows.Forms.Padding(2, 4, 4, 0);
            this.panel38.Size = new System.Drawing.Size(105, 24);
            this.panel38.TabIndex = 0;
            // 
            // PO_WEI
            // 
            this.PO_WEI.AssDispValue = true;
            this.PO_WEI.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PO_WEI.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PO_WEI.ForeColor = System.Drawing.Color.Blue;
            this.PO_WEI.Location = new System.Drawing.Point(2, 4);
            this.PO_WEI.Name = "PO_WEI";
            this.PO_WEI.Size = new System.Drawing.Size(99, 20);
            this.PO_WEI.TabIndex = 15;
            this.PO_WEI.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // label23
            // 
            this.label23.Dock = System.Windows.Forms.DockStyle.Left;
            this.label23.Location = new System.Drawing.Point(0, 0);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(77, 24);
            this.label23.TabIndex = 0;
            this.label23.Text = "坡位";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label24
            // 
            this.label24.BackColor = System.Drawing.Color.Black;
            this.label24.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label24.Location = new System.Drawing.Point(0, 24);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(370, 1);
            this.label24.TabIndex = 0;
            this.label24.Text = "label24";
            this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel39
            // 
            this.panel39.Controls.Add(this.panel47);
            this.panel39.Controls.Add(this.label30);
            this.panel39.Controls.Add(this.panel48);
            this.panel39.Controls.Add(this.label31);
            this.panel39.Controls.Add(this.label32);
            this.panel39.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel39.Location = new System.Drawing.Point(0, 25);
            this.panel39.Name = "panel39";
            this.panel39.Size = new System.Drawing.Size(370, 25);
            this.panel39.TabIndex = 0;
            // 
            // panel47
            // 
            this.panel47.Controls.Add(this.PO_DU);
            this.panel47.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel47.Location = new System.Drawing.Point(259, 0);
            this.panel47.Name = "panel47";
            this.panel47.Padding = new System.Windows.Forms.Padding(2, 4, 4, 0);
            this.panel47.Size = new System.Drawing.Size(105, 24);
            this.panel47.TabIndex = 0;
            // 
            // PO_DU
            // 
            this.PO_DU.AssDispValue = true;
            this.PO_DU.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PO_DU.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PO_DU.ForeColor = System.Drawing.Color.Blue;
            this.PO_DU.Location = new System.Drawing.Point(2, 4);
            this.PO_DU.Name = "PO_DU";
            this.PO_DU.Size = new System.Drawing.Size(99, 20);
            this.PO_DU.TabIndex = 14;
            this.PO_DU.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // label30
            // 
            this.label30.Dock = System.Windows.Forms.DockStyle.Left;
            this.label30.Location = new System.Drawing.Point(182, 0);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(77, 24);
            this.label30.TabIndex = 0;
            this.label30.Text = "坡度";
            this.label30.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel48
            // 
            this.panel48.Controls.Add(this.PO_XIANG);
            this.panel48.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel48.Location = new System.Drawing.Point(77, 0);
            this.panel48.Name = "panel48";
            this.panel48.Padding = new System.Windows.Forms.Padding(2, 4, 4, 0);
            this.panel48.Size = new System.Drawing.Size(105, 24);
            this.panel48.TabIndex = 0;
            // 
            // PO_XIANG
            // 
            this.PO_XIANG.AssDispValue = true;
            this.PO_XIANG.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PO_XIANG.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PO_XIANG.ForeColor = System.Drawing.Color.Blue;
            this.PO_XIANG.Location = new System.Drawing.Point(2, 4);
            this.PO_XIANG.Name = "PO_XIANG";
            this.PO_XIANG.Size = new System.Drawing.Size(99, 20);
            this.PO_XIANG.TabIndex = 13;
            this.PO_XIANG.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // label31
            // 
            this.label31.Dock = System.Windows.Forms.DockStyle.Left;
            this.label31.Location = new System.Drawing.Point(0, 0);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(77, 24);
            this.label31.TabIndex = 0;
            this.label31.Text = "坡向";
            this.label31.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label32
            // 
            this.label32.BackColor = System.Drawing.Color.Black;
            this.label32.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label32.Location = new System.Drawing.Point(0, 24);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(370, 1);
            this.label32.TabIndex = 0;
            this.label32.Text = "label32";
            this.label32.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel49
            // 
            this.panel49.Controls.Add(this.panel51);
            this.panel49.Controls.Add(this.label43);
            this.panel49.Controls.Add(this.panel52);
            this.panel49.Controls.Add(this.label60);
            this.panel49.Controls.Add(this.label62);
            this.panel49.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel49.Location = new System.Drawing.Point(0, 0);
            this.panel49.Name = "panel49";
            this.panel49.Size = new System.Drawing.Size(370, 25);
            this.panel49.TabIndex = 0;
            // 
            // panel51
            // 
            this.panel51.Controls.Add(this.DI_MAO);
            this.panel51.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel51.Location = new System.Drawing.Point(259, 0);
            this.panel51.Name = "panel51";
            this.panel51.Padding = new System.Windows.Forms.Padding(2, 4, 4, 0);
            this.panel51.Size = new System.Drawing.Size(105, 24);
            this.panel51.TabIndex = 0;
            // 
            // DI_MAO
            // 
            this.DI_MAO.AssDispValue = true;
            this.DI_MAO.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DI_MAO.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DI_MAO.ForeColor = System.Drawing.Color.Blue;
            this.DI_MAO.Location = new System.Drawing.Point(2, 4);
            this.DI_MAO.Name = "DI_MAO";
            this.DI_MAO.Size = new System.Drawing.Size(99, 20);
            this.DI_MAO.TabIndex = 12;
            this.DI_MAO.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // label43
            // 
            this.label43.Dock = System.Windows.Forms.DockStyle.Left;
            this.label43.Location = new System.Drawing.Point(182, 0);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(77, 24);
            this.label43.TabIndex = 0;
            this.label43.Text = "地貌";
            this.label43.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel52
            // 
            this.panel52.Controls.Add(this.MIAN_JI);
            this.panel52.Controls.Add(this.label3);
            this.panel52.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel52.Location = new System.Drawing.Point(77, 0);
            this.panel52.Name = "panel52";
            this.panel52.Padding = new System.Windows.Forms.Padding(2, 6, 6, 2);
            this.panel52.Size = new System.Drawing.Size(105, 24);
            this.panel52.TabIndex = 0;
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
            this.MIAN_JI.Size = new System.Drawing.Size(65, 18);
            this.MIAN_JI.TabIndex = 11;
            this.MIAN_JI.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Right;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Blue;
            this.label3.Location = new System.Drawing.Point(67, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 16);
            this.label3.TabIndex = 0;
            this.label3.Text = "公顷";
            // 
            // label60
            // 
            this.label60.Dock = System.Windows.Forms.DockStyle.Left;
            this.label60.Location = new System.Drawing.Point(0, 0);
            this.label60.Name = "label60";
            this.label60.Size = new System.Drawing.Size(77, 24);
            this.label60.TabIndex = 0;
            this.label60.Text = "面积";
            this.label60.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label62
            // 
            this.label62.BackColor = System.Drawing.Color.Black;
            this.label62.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label62.Location = new System.Drawing.Point(0, 24);
            this.label62.Name = "label62";
            this.label62.Size = new System.Drawing.Size(370, 1);
            this.label62.TabIndex = 0;
            this.label62.Text = "label62";
            this.label62.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label71
            // 
            this.label71.BackColor = System.Drawing.Color.Black;
            this.label71.Dock = System.Windows.Forms.DockStyle.Left;
            this.label71.Location = new System.Drawing.Point(0, 0);
            this.label71.Name = "label71";
            this.label71.Size = new System.Drawing.Size(1, 125);
            this.label71.TabIndex = 0;
            this.label71.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label26
            // 
            this.label26.Dock = System.Windows.Forms.DockStyle.Left;
            this.label26.Location = new System.Drawing.Point(0, 0);
            this.label26.Name = "label26";
            this.label26.Padding = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.label26.Size = new System.Drawing.Size(57, 125);
            this.label26.TabIndex = 0;
            this.label26.Text = "基础因子";
            this.label26.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label27
            // 
            this.label27.BackColor = System.Drawing.Color.Black;
            this.label27.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label27.Location = new System.Drawing.Point(0, 125);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(428, 1);
            this.label27.TabIndex = 0;
            this.label27.Text = "label27";
            this.label27.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label16
            // 
            this.label16.BackColor = System.Drawing.Color.Black;
            this.label16.Dock = System.Windows.Forms.DockStyle.Left;
            this.label16.Location = new System.Drawing.Point(20, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(1, 528);
            this.label16.TabIndex = 0;
            this.label16.Text = "label16";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.Dock = System.Windows.Forms.DockStyle.Left;
            this.label7.Location = new System.Drawing.Point(0, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(20, 528);
            this.label7.TabIndex = 0;
            this.label7.Text = "图  斑  因  子  核  实  调  查";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.Black;
            this.label8.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label8.Location = new System.Drawing.Point(1, 529);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(449, 1);
            this.label8.TabIndex = 0;
            this.label8.Text = "label8";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label92
            // 
            this.label92.BackColor = System.Drawing.Color.Black;
            this.label92.Dock = System.Windows.Forms.DockStyle.Right;
            this.label92.Location = new System.Drawing.Point(450, 1);
            this.label92.Name = "label92";
            this.label92.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.label92.Size = new System.Drawing.Size(1, 529);
            this.label92.TabIndex = 0;
            this.label92.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label90
            // 
            this.label90.BackColor = System.Drawing.Color.Black;
            this.label90.Dock = System.Windows.Forms.DockStyle.Top;
            this.label90.Location = new System.Drawing.Point(1, 0);
            this.label90.Name = "label90";
            this.label90.Size = new System.Drawing.Size(450, 1);
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
            this.label91.Size = new System.Drawing.Size(1, 530);
            this.label91.TabIndex = 0;
            this.label91.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label112
            // 
            this.label112.BackColor = System.Drawing.Color.Black;
            this.label112.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label112.Location = new System.Drawing.Point(0, 50);
            this.label112.Name = "label112";
            this.label112.Size = new System.Drawing.Size(428, 1);
            this.label112.TabIndex = 0;
            this.label112.Text = "label112";
            this.label112.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label61
            // 
            this.label61.BackColor = System.Drawing.Color.Black;
            this.label61.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label61.Location = new System.Drawing.Point(0, 24);
            this.label61.Name = "label61";
            this.label61.Size = new System.Drawing.Size(370, 1);
            this.label61.TabIndex = 0;
            this.label61.Text = "label61";
            this.label61.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label108
            // 
            this.label108.BackColor = System.Drawing.Color.Black;
            this.label108.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label108.Location = new System.Drawing.Point(0, 24);
            this.label108.Name = "label108";
            this.label108.Size = new System.Drawing.Size(370, 1);
            this.label108.TabIndex = 0;
            this.label108.Text = "label108";
            this.label108.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label87
            // 
            this.label87.BackColor = System.Drawing.Color.Black;
            this.label87.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label87.Location = new System.Drawing.Point(0, 24);
            this.label87.Name = "label87";
            this.label87.Size = new System.Drawing.Size(370, 1);
            this.label87.TabIndex = 0;
            this.label87.Text = "label87";
            this.label87.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label95
            // 
            this.label95.BackColor = System.Drawing.Color.Black;
            this.label95.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label95.Location = new System.Drawing.Point(0, 24);
            this.label95.Name = "label95";
            this.label95.Size = new System.Drawing.Size(370, 1);
            this.label95.TabIndex = 0;
            this.label95.Text = "label95";
            this.label95.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label76
            // 
            this.label76.BackColor = System.Drawing.Color.Black;
            this.label76.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label76.Location = new System.Drawing.Point(0, 24);
            this.label76.Name = "label76";
            this.label76.Size = new System.Drawing.Size(370, 1);
            this.label76.TabIndex = 0;
            this.label76.Text = "label76";
            this.label76.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.label173.Location = new System.Drawing.Point(0, 0);
            this.label173.Name = "label173";
            this.label173.Size = new System.Drawing.Size(100, 23);
            this.label173.TabIndex = 0;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.panelHS);
            this.panelControl1.Controls.Add(this.panelBasicInfo);
            this.panelControl1.Controls.Add(this.panelTitle);
            this.panelControl1.Controls.Add(this.labelTitle);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(2, 2);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(451, 696);
            this.panelControl1.TabIndex = 0;
            // 
            // panelTitle
            // 
            this.panelTitle.Controls.Add(this.panel27);
            this.panelTitle.Controls.Add(this.panel22);
            this.panelTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitle.Location = new System.Drawing.Point(0, 30);
            this.panelTitle.Name = "panelTitle";
            this.panelTitle.Size = new System.Drawing.Size(451, 51);
            this.panelTitle.TabIndex = 0;
            // 
            // panel27
            // 
            this.panel27.Controls.Add(this.panel29);
            this.panel27.Controls.Add(this.label66);
            this.panel27.Controls.Add(this.panel37);
            this.panel27.Controls.Add(this.label67);
            this.panel27.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel27.Location = new System.Drawing.Point(0, 25);
            this.panel27.Name = "panel27";
            this.panel27.Size = new System.Drawing.Size(451, 25);
            this.panel27.TabIndex = 0;
            // 
            // panel29
            // 
            this.panel29.Controls.Add(this.LIN_CHANG);
            this.panel29.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel29.Location = new System.Drawing.Point(195, 0);
            this.panel29.Name = "panel29";
            this.panel29.Padding = new System.Windows.Forms.Padding(2, 6, 8, 0);
            this.panel29.Size = new System.Drawing.Size(105, 25);
            this.panel29.TabIndex = 0;
            // 
            // LIN_CHANG
            // 
            this.LIN_CHANG.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LIN_CHANG.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LIN_CHANG.EditValue = "";
            this.LIN_CHANG.Location = new System.Drawing.Point(2, 6);
            this.LIN_CHANG.Name = "LIN_CHANG";
            this.LIN_CHANG.Properties.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LIN_CHANG.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.LIN_CHANG.Properties.Appearance.Options.UseFont = true;
            this.LIN_CHANG.Properties.Appearance.Options.UseForeColor = true;
            this.LIN_CHANG.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.LIN_CHANG.Properties.MaxLength = 10;
            this.LIN_CHANG.Size = new System.Drawing.Size(95, 16);
            this.LIN_CHANG.TabIndex = 4;
            this.LIN_CHANG.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // label66
            // 
            this.label66.Dock = System.Windows.Forms.DockStyle.Left;
            this.label66.Location = new System.Drawing.Point(150, 0);
            this.label66.Name = "label66";
            this.label66.Size = new System.Drawing.Size(45, 25);
            this.label66.TabIndex = 0;
            this.label66.Text = "林场";
            this.label66.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel37
            // 
            this.panel37.Controls.Add(this.LIN_YE_JU);
            this.panel37.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel37.Location = new System.Drawing.Point(45, 0);
            this.panel37.Name = "panel37";
            this.panel37.Padding = new System.Windows.Forms.Padding(2, 6, 8, 0);
            this.panel37.Size = new System.Drawing.Size(105, 25);
            this.panel37.TabIndex = 0;
            // 
            // LIN_YE_JU
            // 
            this.LIN_YE_JU.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LIN_YE_JU.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LIN_YE_JU.EditValue = "";
            this.LIN_YE_JU.Location = new System.Drawing.Point(2, 6);
            this.LIN_YE_JU.Name = "LIN_YE_JU";
            this.LIN_YE_JU.Properties.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LIN_YE_JU.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.LIN_YE_JU.Properties.Appearance.Options.UseFont = true;
            this.LIN_YE_JU.Properties.Appearance.Options.UseForeColor = true;
            this.LIN_YE_JU.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.LIN_YE_JU.Properties.MaxLength = 10;
            this.LIN_YE_JU.Size = new System.Drawing.Size(95, 16);
            this.LIN_YE_JU.TabIndex = 3;
            this.LIN_YE_JU.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // label67
            // 
            this.label67.Dock = System.Windows.Forms.DockStyle.Left;
            this.label67.Location = new System.Drawing.Point(0, 0);
            this.label67.Name = "label67";
            this.label67.Size = new System.Drawing.Size(45, 25);
            this.label67.TabIndex = 0;
            this.label67.Text = "林业局";
            this.label67.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel22
            // 
            this.panel22.Controls.Add(this.panel23);
            this.panel22.Controls.Add(this.label53);
            this.panel22.Controls.Add(this.panel26);
            this.panel22.Controls.Add(this.label55);
            this.panel22.Controls.Add(this.label58);
            this.panel22.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel22.Location = new System.Drawing.Point(0, 0);
            this.panel22.Name = "panel22";
            this.panel22.Size = new System.Drawing.Size(451, 25);
            this.panel22.TabIndex = 0;
            // 
            // panel23
            // 
            this.panel23.Controls.Add(this.XIAN);
            this.panel23.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel23.Location = new System.Drawing.Point(195, 0);
            this.panel23.Name = "panel23";
            this.panel23.Padding = new System.Windows.Forms.Padding(2, 4, 4, 0);
            this.panel23.Size = new System.Drawing.Size(105, 24);
            this.panel23.TabIndex = 0;
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
            this.XIAN.TabIndex = 2;
            this.XIAN.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // label53
            // 
            this.label53.Dock = System.Windows.Forms.DockStyle.Left;
            this.label53.Location = new System.Drawing.Point(150, 0);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(45, 24);
            this.label53.TabIndex = 0;
            this.label53.Text = "县";
            this.label53.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel26
            // 
            this.panel26.Controls.Add(this.SHENG);
            this.panel26.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel26.Location = new System.Drawing.Point(45, 0);
            this.panel26.Name = "panel26";
            this.panel26.Padding = new System.Windows.Forms.Padding(2, 4, 4, 0);
            this.panel26.Size = new System.Drawing.Size(105, 24);
            this.panel26.TabIndex = 0;
            // 
            // SHENG
            // 
            this.SHENG.AssDispValue = true;
            this.SHENG.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SHENG.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SHENG.ForeColor = System.Drawing.Color.Blue;
            this.SHENG.Location = new System.Drawing.Point(2, 4);
            this.SHENG.Name = "SHENG";
            this.SHENG.Size = new System.Drawing.Size(99, 20);
            this.SHENG.TabIndex = 1;
            this.SHENG.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // label55
            // 
            this.label55.Dock = System.Windows.Forms.DockStyle.Left;
            this.label55.Location = new System.Drawing.Point(0, 0);
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size(45, 24);
            this.label55.TabIndex = 0;
            this.label55.Text = "省";
            this.label55.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label58
            // 
            this.label58.BackColor = System.Drawing.Color.Black;
            this.label58.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label58.Location = new System.Drawing.Point(0, 24);
            this.label58.Name = "label58";
            this.label58.Size = new System.Drawing.Size(451, 1);
            this.label58.TabIndex = 0;
            this.label58.Text = "label58";
            this.label58.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label56
            // 
            this.label56.BackColor = System.Drawing.Color.Black;
            this.label56.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label56.Location = new System.Drawing.Point(0, 50);
            this.label56.Name = "label56";
            this.label56.Size = new System.Drawing.Size(451, 1);
            this.label56.TabIndex = 0;
            this.label56.Text = "label56";
            this.label56.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // UserControlHSAttr
            // 
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panelControl1);
            this.Name = "UserControlHSAttr";
            this.Padding = new System.Windows.Forms.Padding(2);
            this.Size = new System.Drawing.Size(455, 700);
            this.panelBasicInfo.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel16.ResumeLayout(false);
            this.panel18.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.BEIZU.Properties)).EndInit();
            this.panel19.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel10.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.LIN_BAN.Properties)).EndInit();
            this.panel11.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.NO_TB.Properties)).EndInit();
            this.panelHS.ResumeLayout(false);
            this.panel36.ResumeLayout(false);
            this.panelP26.ResumeLayout(false);
            this.panel42.ResumeLayout(false);
            this.panel43.ResumeLayout(false);
            this.panel44.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.BHND.Properties)).EndInit();
            this.panel56.ResumeLayout(false);
            this.panel57.ResumeLayout(false);
            this.panel85.ResumeLayout(false);
            this.panelP25.ResumeLayout(false);
            this.panel12.ResumeLayout(false);
            this.panel15.ResumeLayout(false);
            this.panel20.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.panel41.ResumeLayout(false);
            this.panel86.ResumeLayout(false);
            this.panel21.ResumeLayout(false);
            this.panel24.ResumeLayout(false);
            this.panel25.ResumeLayout(false);
            this.panel30.ResumeLayout(false);
            this.panel31.ResumeLayout(false);
            this.panel32.ResumeLayout(false);
            this.panel33.ResumeLayout(false);
            this.panel34.ResumeLayout(false);
            this.panel35.ResumeLayout(false);
            this.panelP24.ResumeLayout(false);
            this.panel65.ResumeLayout(false);
            this.panel66.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel74.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.HUO_LMGQXJ.Properties)).EndInit();
            this.panel84.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MEI_GQ_ZS.Properties)).EndInit();
            this.panel45.ResumeLayout(false);
            this.panel55.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PINGJUN_DM.Properties)).EndInit();
            this.panel46.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PINGJUN_SG.Properties)).EndInit();
            this.panel54.ResumeLayout(false);
            this.panel50.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PINGJUN_XJ.Properties)).EndInit();
            this.panel67.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PINGJUN_NL.Properties)).EndInit();
            this.panel68.ResumeLayout(false);
            this.panel69.ResumeLayout(false);
            this.panel70.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.YU_BI_DU.Properties)).EndInit();
            this.panel71.ResumeLayout(false);
            this.panel72.ResumeLayout(false);
            this.panel73.ResumeLayout(false);
            this.panelP23.ResumeLayout(false);
            this.panel61.ResumeLayout(false);
            this.panel64.ResumeLayout(false);
            this.panel87.ResumeLayout(false);
            this.panel89.ResumeLayout(false);
            this.panel75.ResumeLayout(false);
            this.panel76.ResumeLayout(false);
            this.panel80.ResumeLayout(false);
            this.panel81.ResumeLayout(false);
            this.panel82.ResumeLayout(false);
            this.panel83.ResumeLayout(false);
            this.panelP22.ResumeLayout(false);
            this.panel62.ResumeLayout(false);
            this.panel63.ResumeLayout(false);
            this.panel77.ResumeLayout(false);
            this.panel78.ResumeLayout(false);
            this.panel79.ResumeLayout(false);
            this.panelP21.ResumeLayout(false);
            this.panel13.ResumeLayout(false);
            this.panel14.ResumeLayout(false);
            this.panel58.ResumeLayout(false);
            this.panel59.ResumeLayout(false);
            this.panel60.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.LD_KD.Properties)).EndInit();
            this.panel40.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.LD_CD.Properties)).EndInit();
            this.panel53.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TU_CENG_HD.Properties)).EndInit();
            this.panel17.ResumeLayout(false);
            this.panel28.ResumeLayout(false);
            this.panel38.ResumeLayout(false);
            this.panel39.ResumeLayout(false);
            this.panel47.ResumeLayout(false);
            this.panel48.ResumeLayout(false);
            this.panel49.ResumeLayout(false);
            this.panel51.ResumeLayout(false);
            this.panel52.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MIAN_JI.Properties)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelTitle.ResumeLayout(false);
            this.panel27.ResumeLayout(false);
            this.panel29.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.LIN_CHANG.Properties)).EndInit();
            this.panel37.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.LIN_YE_JU.Properties)).EndInit();
            this.panel22.ResumeLayout(false);
            this.panel23.ResumeLayout(false);
            this.panel26.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private void SHENG_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.SHENG.SelectedIndex <= 0)
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
                this.XIAN.ItemFilter(this.SHENG.GetSelectedValue());
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

