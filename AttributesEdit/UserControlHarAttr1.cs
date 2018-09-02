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
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;
    using Utilities;

    public class UserControlHarAttr1 : UserControl
    {
        private ZLComboBox BHYY;
        private ZLSpinEdit BLMYBD;
        private SimpleButton buttonJC;
        private SimpleButton buttonPrint;
        private ZLSpinEdit CFCS;
        private ZLComboBox CFFS;
        private ZLComboBox CFLX;
        private ZLSpinEdit CFMJ;
        private ZLSpinEdit CFQD;
        private DateEdit CFSJ;
        private ComboBoxEdit comboBoxEdit16;
        private IContainer components;
        private ZLComboBox CTMY;
        private ZLComboBox CUN;
        private TextEdit DCRY;
        private ZLComboBox DI_LEI;
        private TextEdit DW;
        private TextEdit EAST;
        private TextEdit FMFF;
        private ZLSpinEdit FQZS;
        private TextEdit FYCS;
        private DateEdit GENGXINSJ;
        private ZLComboBox GJGYL_BHDJ;
        private ZLComboBox GXDJ;
        private ZLComboBox GXFS;
        private ZLSpinEdit GXMJ;
        private DateEdit GXSJ;
        private ZLComboBox GXSZ;
        private TextEdit GXZRR;
        private ZLSpinEdit HBG;
        private ZLSpinEdit HUO_LMGQXJ;
        private ZLComboBox JCFS;
        private Label label10;
        private Label label103;
        private Label label109;
        private Label label110;
        private Label label111;
        private Label label112;
        private Label label113;
        private Label label114;
        private Label label115;
        private Label label122;
        private Label label126;
        private Label label129;
        private Label label131;
        private Label label14;
        private Label label140;
        private Label label141;
        private Label label15;
        private Label label151;
        private Label label157;
        private Label label158;
        private Label label159;
        private Label label160;
        private Label label161;
        private Label label162;
        private Label label163;
        private Label label164;
        private Label label169;
        private Label label171;
        private Label label172;
        private Label label173;
        private Label label174;
        private Label label175;
        private Label label176;
        private Label label177;
        private Label label18;
        private Label label183;
        private Label label186;
        private Label label19;
        private Label label2;
        private Label label20;
        private Label label203;
        private Label label208;
        private Label label21;
        private Label label212;
        private Label label22;
        private Label label222;
        private Label label224;
        private Label label226;
        private Label label228;
        private Label label24;
        private Label label28;
        private Label label32;
        private Label label35;
        private Label label36;
        private Label label37;
        private Label label42;
        private Label label43;
        private Label label47;
        private Label label51;
        private Label label52;
        private Label label53;
        private Label label59;
        private Label label6;
        private Label label65;
        private Label label7;
        private Label label74;
        private Label label76;
        private Label label82;
        private Label label84;
        private Label label85;
        private Label label88;
        private Label label90;
        private Label label91;
        private Label label92;
        private Label label93;
        private Label label98;
        private Label labelLBMess;
        private Label labelTitle;
        private Label laBHYY;
        private Label laBLMYBD;
        private Label laCFCS;
        private Label laCFFS;
        private Label laCFLX;
        private Label laCFMJ;
        private Label laCFQD;
        private Label laCFSJ;
        private Label laCTMY;
        private Label laCUN;
        private Label laDCRY;
        private Label laDI_LEI;
        private Label laDW;
        private Label laEAST;
        private Label laFMFF;
        private Label laFQZS;
        private Label laFYCS;
        private Label laGENGXINSJ;
        private Label laGJGYL_BHDJ;
        private Label laGXDJ;
        private Label laGXFS;
        private Label laGXMJ;
        private Label laGXSJ;
        private Label laGXSZ;
        private Label laGXZRR;
        private Label laHBG;
        private Label laHUO_LMGQXJ;
        private Label laJCFS;
        private Label laLD_QS;
        private Label laLIN_BAN;
        private Label laLIN_ZHONG;
        private Label laLING_ZU;
        private Label laLMJYQ;
        private Label laLMSYQ;
        private Label laLMSYZXM;
        private Label laMEI_GQ_ZS;
        private Label laMIAN_JI;
        private Label laMIAOMUGG;
        private Label laNORTH;
        private Label laPINGJUN_NL;
        private Label laPINGJUN_SG;
        private Label laPINGJUN_XJ;
        private Label laPJGF;
        private Label laPO_DU;
        private Label laPO_WEI;
        private Label laPO_XIANG;
        private Label laQ_DI_LEI;
        private Label laQ_LD_QS;
        private Label laQ_LIN_ZHONG;
        private Label laQ_SEN_LB;
        private Label laQI_YUAN;
        private Label laQTSM;
        private Label laSEN_LIN_LB;
        private Label laSFCF;
        private Label laSHENG;
        private Label laSHI;
        private Label laSJBH;
        private Label laSJRY;
        private Label laSOUTH;
        private Label laSSXJ;
        private Label laSSZZS;
        private Label laTDJYQ;
        private Label laTU_CENG_HD;
        private Label laTU_RANG_LX;
        private Label laWEST;
        private Label laXI_BAN;
        private Label laXIAN;
        private Label laXIANG;
        private Label laXIAO_BAN;
        private Label laXIAODM;
        private Label laYML;
        private Label laYOU_SHI_SZ;
        private Label laYU_BI_DU;
        private Label laZDFS;
        private Label laZDGG;
        private Label laZHUHJ;
        private Label laZLMD;
        private Label laZXJ;
        private ZLComboBox LD_QS;
        private TextEdit LIN_BAN;
        private ZLComboBox LIN_ZHONG;
        private ZLComboBox LING_ZU;
        private ZLComboBox LMJYQ;
        private ZLComboBox LMSYQ;
        private TextEdit LMSYZXM;
        private const string mClassName = "AttributesEdit.UserControlHarAttr1";
        private ZLSpinEdit MEI_GQ_ZS;
        private ErrorOpt mErrOpt = UtilFactory.GetErrorOpt();
        private ZLSpinEdit MIAN_JI;
        private TextEdit MIAOMUGG;
        private string mSubSysName = UtilFactory.GetConfigOpt().GetSystemName();
        private TextEdit NORTH;
        private Panel panel1;
        private Panel panel10;
        private Panel panel100;
        private Panel panel101;
        private Panel panel102;
        private Panel panel103;
        private Panel panel108;
        private Panel panel11;
        private Panel panel110;
        private Panel panel111;
        private Panel panel112;
        private Panel panel113;
        private Panel panel114;
        private Panel panel115;
        private Panel panel118;
        private Panel panel119;
        private Panel panel12;
        private Panel panel120;
        private Panel panel121;
        private Panel panel122;
        private Panel panel13;
        private Panel panel130;
        private Panel panel132;
        private Panel panel133;
        private Panel panel134;
        private Panel panel135;
        private Panel panel136;
        private Panel panel137;
        private Panel panel138;
        private Panel panel14;
        private Panel panel144;
        private Panel panel145;
        private Panel panel146;
        private Panel panel149;
        private Panel panel15;
        private Panel panel155;
        private Panel panel158;
        private Panel panel159;
        private Panel panel16;
        private Panel panel160;
        private Panel panel168;
        private Panel panel169;
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
        private Panel panel28;
        private Panel panel3;
        private Panel panel31;
        private Panel panel32;
        private Panel panel33;
        private Panel panel34;
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
        private Panel panel47;
        private Panel panel48;
        private Panel panel49;
        private Panel panel5;
        private Panel panel50;
        private Panel panel52;
        private Panel panel59;
        private Panel panel6;
        private Panel panel60;
        private Panel panel62;
        private Panel panel67;
        private Panel panel7;
        private Panel panel70;
        private Panel panel71;
        private Panel panel72;
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
        private Panel panelHarTable;
        private Panel panelHarvest;
        private Panel panelOther;
        private Panel panelPage1;
        private Panel panelTitle1;
        private Panel panelUpdate;
        private ZLSpinEdit PINGJUN_NL;
        private ZLSpinEdit PINGJUN_SG;
        private ZLSpinEdit PINGJUN_XJ;
        private ZLSpinEdit PJGF;
        private ZLComboBox PO_DU;
        private ZLComboBox PO_WEI;
        private ZLComboBox PO_XIANG;
        private ZLComboBox Q_DI_LEI;
        private ZLComboBox Q_LD_QS;
        private ZLComboBox Q_LIN_ZHONG;
        private ZLComboBox Q_SEN_LB;
        private ZLComboBox QI_YUAN;
        private MemoEdit QTSM;
        private ZLComboBox SEN_LIN_LB;
        private ZLComboBox SFCF;
        private ZLComboBox SHENG;
        private ZLComboBox SHI;
        private TextEdit SJBH;
        private TextEdit SJRY;
        private TextEdit SOUTH;
        private ZLSpinEdit spinEdit3;
        private ZLSpinEdit SSXJ;
        private ZLSpinEdit SSZZS;
        private ZLComboBox TDJYQ;
        private TextEdit textEdit36;
        private TextEdit textEdit51;
        private TextEdit textEdit52;
        private ZLSpinEdit TU_CENG_HD;
        private ZLComboBox TU_RANG_LX;
        private TextEdit WEST;
        private TextEdit XI_BAN;
        private ZLComboBox XIAN;
        private ZLComboBox XIANG;
        private TextEdit XIAO_BAN;
        private TextEdit XIAODM;
        private ZLSpinEdit YML;
        private ZLComboBox YOU_SHI_SZ;
        private ZLSpinEdit YU_BI_DU;
        private TextEdit ZDFS;
        private TextEdit ZDGG;
        private TextEdit ZHUHJ;
        private ZLSpinEdit ZLMD;
        private ZLSpinEdit ZXJ;

        public event PrintHarvesthandler OnPrintHarvest;

        public event ShowJCTablehandler OnShowJCTable;

        public UserControlHarAttr1()
        {
            this.InitializeComponent();
            this.XIANG.SelectedIndexChanged += new EventHandler(this.XIANG_SelectedIndexChanged);
            this.Q_SEN_LB.SelectedIndexChanged += new EventHandler(this.Q_SEN_LIN_LB_SelectedIndexChanged);
            this.CFFS.SelectedIndexChanged += new EventHandler(this.CFFS_SelectedIndexChanged);
        }

        private void buttonJC_Click(object sender, EventArgs e)
        {
            this.OnShowJCTable(true);
        }

        private void buttonPrint_Click(object sender, EventArgs e)
        {
            this.OnPrintHarvest();
        }

        private void CFFS_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.CFFS.SelectedIndex == 1)
            {
                this.CFQD.Value = 100M;
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
            if (index == 0x4d)
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
            this.panel100 = new System.Windows.Forms.Panel();
            this.panel20 = new System.Windows.Forms.Panel();
            this.label21 = new System.Windows.Forms.Label();
            this.laZXJ = new System.Windows.Forms.Label();
            this.panel19 = new System.Windows.Forms.Panel();
            this.laFQZS = new System.Windows.Forms.Label();
            this.panel34 = new System.Windows.Forms.Panel();
            this.label76 = new System.Windows.Forms.Label();
            this.laPJGF = new System.Windows.Forms.Label();
            this.label162 = new System.Windows.Forms.Label();
            this.panel114 = new System.Windows.Forms.Panel();
            this.panel82 = new System.Windows.Forms.Panel();
            this.label129 = new System.Windows.Forms.Label();
            this.laHUO_LMGQXJ = new System.Windows.Forms.Label();
            this.panel99 = new System.Windows.Forms.Panel();
            this.laMEI_GQ_ZS = new System.Windows.Forms.Label();
            this.label169 = new System.Windows.Forms.Label();
            this.panel97 = new System.Windows.Forms.Panel();
            this.panel32 = new System.Windows.Forms.Panel();
            this.label82 = new System.Windows.Forms.Label();
            this.laSSXJ = new System.Windows.Forms.Label();
            this.panel33 = new System.Windows.Forms.Panel();
            this.laSSZZS = new System.Windows.Forms.Label();
            this.label158 = new System.Windows.Forms.Label();
            this.panel133 = new System.Windows.Forms.Panel();
            this.panel70 = new System.Windows.Forms.Panel();
            this.laQI_YUAN = new System.Windows.Forms.Label();
            this.panel67 = new System.Windows.Forms.Panel();
            this.label52 = new System.Windows.Forms.Label();
            this.laYU_BI_DU = new System.Windows.Forms.Label();
            this.panel168 = new System.Windows.Forms.Panel();
            this.laLING_ZU = new System.Windows.Forms.Label();
            this.panel169 = new System.Windows.Forms.Panel();
            this.label203 = new System.Windows.Forms.Label();
            this.laPINGJUN_NL = new System.Windows.Forms.Label();
            this.label222 = new System.Windows.Forms.Label();
            this.panel155 = new System.Windows.Forms.Panel();
            this.panel110 = new System.Windows.Forms.Panel();
            this.label159 = new System.Windows.Forms.Label();
            this.laTU_CENG_HD = new System.Windows.Forms.Label();
            this.panel158 = new System.Windows.Forms.Panel();
            this.laTU_RANG_LX = new System.Windows.Forms.Label();
            this.panel159 = new System.Windows.Forms.Panel();
            this.laCTMY = new System.Windows.Forms.Label();
            this.panel160 = new System.Windows.Forms.Panel();
            this.label226 = new System.Windows.Forms.Label();
            this.laHBG = new System.Windows.Forms.Label();
            this.label228 = new System.Windows.Forms.Label();
            this.panel149 = new System.Windows.Forms.Panel();
            this.panel42 = new System.Windows.Forms.Panel();
            this.laPO_WEI = new System.Windows.Forms.Label();
            this.panel23 = new System.Windows.Forms.Panel();
            this.laPO_DU = new System.Windows.Forms.Label();
            this.panel130 = new System.Windows.Forms.Panel();
            this.laPO_XIANG = new System.Windows.Forms.Label();
            this.label224 = new System.Windows.Forms.Label();
            this.panel41 = new System.Windows.Forms.Panel();
            this.labelLBMess = new System.Windows.Forms.Label();
            this.panel44 = new System.Windows.Forms.Panel();
            this.laQ_SEN_LB = new System.Windows.Forms.Label();
            this.panel43 = new System.Windows.Forms.Panel();
            this.laSEN_LIN_LB = new System.Windows.Forms.Label();
            this.label65 = new System.Windows.Forms.Label();
            this.panel21 = new System.Windows.Forms.Panel();
            this.panel25 = new System.Windows.Forms.Panel();
            this.laQ_LD_QS = new System.Windows.Forms.Label();
            this.panel24 = new System.Windows.Forms.Panel();
            this.laLD_QS = new System.Windows.Forms.Label();
            this.label47 = new System.Windows.Forms.Label();
            this.panel37 = new System.Windows.Forms.Panel();
            this.panel112 = new System.Windows.Forms.Panel();
            this.label163 = new System.Windows.Forms.Label();
            this.laPINGJUN_SG = new System.Windows.Forms.Label();
            this.panel80 = new System.Windows.Forms.Panel();
            this.label126 = new System.Windows.Forms.Label();
            this.laPINGJUN_XJ = new System.Windows.Forms.Label();
            this.panel79 = new System.Windows.Forms.Panel();
            this.laYOU_SHI_SZ = new System.Windows.Forms.Label();
            this.label183 = new System.Windows.Forms.Label();
            this.panel62 = new System.Windows.Forms.Panel();
            this.panel98 = new System.Windows.Forms.Panel();
            this.laGJGYL_BHDJ = new System.Windows.Forms.Label();
            this.panel77 = new System.Windows.Forms.Panel();
            this.laQ_LIN_ZHONG = new System.Windows.Forms.Label();
            this.panel76 = new System.Windows.Forms.Panel();
            this.laLIN_ZHONG = new System.Windows.Forms.Label();
            this.label122 = new System.Windows.Forms.Label();
            this.panel14 = new System.Windows.Forms.Panel();
            this.panel38 = new System.Windows.Forms.Panel();
            this.laLMSYQ = new System.Windows.Forms.Label();
            this.panel40 = new System.Windows.Forms.Panel();
            this.laLMJYQ = new System.Windows.Forms.Label();
            this.panel47 = new System.Windows.Forms.Panel();
            this.laTDJYQ = new System.Windows.Forms.Label();
            this.label114 = new System.Windows.Forms.Label();
            this.panel31 = new System.Windows.Forms.Panel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.laQ_DI_LEI = new System.Windows.Forms.Label();
            this.panel26 = new System.Windows.Forms.Panel();
            this.laDI_LEI = new System.Windows.Forms.Label();
            this.panel18 = new System.Windows.Forms.Panel();
            this.label51 = new System.Windows.Forms.Label();
            this.laMIAN_JI = new System.Windows.Forms.Label();
            this.label59 = new System.Windows.Forms.Label();
            this.panel145 = new System.Windows.Forms.Panel();
            this.panel85 = new System.Windows.Forms.Panel();
            this.DW = new DevExpress.XtraEditors.TextEdit();
            this.laDW = new System.Windows.Forms.Label();
            this.panel146 = new System.Windows.Forms.Panel();
            this.LMSYZXM = new DevExpress.XtraEditors.TextEdit();
            this.laLMSYZXM = new System.Windows.Forms.Label();
            this.label212 = new System.Windows.Forms.Label();
            this.panel138 = new System.Windows.Forms.Panel();
            this.panel22 = new System.Windows.Forms.Panel();
            this.NORTH = new DevExpress.XtraEditors.TextEdit();
            this.laNORTH = new System.Windows.Forms.Label();
            this.panel84 = new System.Windows.Forms.Panel();
            this.SOUTH = new DevExpress.XtraEditors.TextEdit();
            this.laSOUTH = new System.Windows.Forms.Label();
            this.label208 = new System.Windows.Forms.Label();
            this.panel16 = new System.Windows.Forms.Panel();
            this.panel78 = new System.Windows.Forms.Panel();
            this.WEST = new DevExpress.XtraEditors.TextEdit();
            this.laWEST = new System.Windows.Forms.Label();
            this.panel75 = new System.Windows.Forms.Panel();
            this.EAST = new DevExpress.XtraEditors.TextEdit();
            this.laEAST = new System.Windows.Forms.Label();
            this.label42 = new System.Windows.Forms.Label();
            this.panel120 = new System.Windows.Forms.Panel();
            this.panel144 = new System.Windows.Forms.Panel();
            this.XIAODM = new DevExpress.XtraEditors.TextEdit();
            this.laXIAODM = new System.Windows.Forms.Label();
            this.label186 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel121 = new System.Windows.Forms.Panel();
            this.XI_BAN = new DevExpress.XtraEditors.TextEdit();
            this.laXI_BAN = new System.Windows.Forms.Label();
            this.panel122 = new System.Windows.Forms.Panel();
            this.XIAO_BAN = new DevExpress.XtraEditors.TextEdit();
            this.laXIAO_BAN = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.LIN_BAN = new DevExpress.XtraEditors.TextEdit();
            this.laLIN_BAN = new System.Windows.Forms.Label();
            this.panel10 = new System.Windows.Forms.Panel();
            this.laCUN = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel11 = new System.Windows.Forms.Panel();
            this.laXIANG = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.laXIAN = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.laSHI = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.laSHENG = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.label37 = new System.Windows.Forms.Label();
            this.panelHarvest = new System.Windows.Forms.Panel();
            this.panel36 = new System.Windows.Forms.Panel();
            this.panel13 = new System.Windows.Forms.Panel();
            this.panel101 = new System.Windows.Forms.Panel();
            this.laJCFS = new System.Windows.Forms.Label();
            this.panel49 = new System.Windows.Forms.Panel();
            this.FMFF = new DevExpress.XtraEditors.TextEdit();
            this.laFMFF = new System.Windows.Forms.Label();
            this.panel39 = new System.Windows.Forms.Panel();
            this.CFSJ = new DevExpress.XtraEditors.DateEdit();
            this.laCFSJ = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.panel71 = new System.Windows.Forms.Panel();
            this.panel74 = new System.Windows.Forms.Panel();
            this.label84 = new System.Windows.Forms.Label();
            this.laBLMYBD = new System.Windows.Forms.Label();
            this.label85 = new System.Windows.Forms.Label();
            this.panel15 = new System.Windows.Forms.Panel();
            this.panel60 = new System.Windows.Forms.Panel();
            this.laSFCF = new System.Windows.Forms.Label();
            this.panel103 = new System.Windows.Forms.Panel();
            this.label32 = new System.Windows.Forms.Label();
            this.laCFQD = new System.Windows.Forms.Label();
            this.panel48 = new System.Windows.Forms.Panel();
            this.label28 = new System.Windows.Forms.Label();
            this.laCFMJ = new System.Windows.Forms.Label();
            this.label74 = new System.Windows.Forms.Label();
            this.panel50 = new System.Windows.Forms.Panel();
            this.panel102 = new System.Windows.Forms.Panel();
            this.laCFFS = new System.Windows.Forms.Label();
            this.panel45 = new System.Windows.Forms.Panel();
            this.laCFCS = new System.Windows.Forms.Label();
            this.panel52 = new System.Windows.Forms.Panel();
            this.laCFLX = new System.Windows.Forms.Label();
            this.label88 = new System.Windows.Forms.Label();
            this.label164 = new System.Windows.Forms.Label();
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
            this.label103 = new System.Windows.Forms.Label();
            this.panelUpdate = new System.Windows.Forms.Panel();
            this.panel108 = new System.Windows.Forms.Panel();
            this.panel81 = new System.Windows.Forms.Panel();
            this.QTSM = new DevExpress.XtraEditors.MemoEdit();
            this.laQTSM = new System.Windows.Forms.Label();
            this.panel118 = new System.Windows.Forms.Panel();
            this.panel115 = new System.Windows.Forms.Panel();
            this.GXZRR = new DevExpress.XtraEditors.TextEdit();
            this.laGXZRR = new System.Windows.Forms.Label();
            this.panel12 = new System.Windows.Forms.Panel();
            this.laGXDJ = new System.Windows.Forms.Label();
            this.label131 = new System.Windows.Forms.Label();
            this.panel94 = new System.Windows.Forms.Panel();
            this.panel95 = new System.Windows.Forms.Panel();
            this.FYCS = new DevExpress.XtraEditors.TextEdit();
            this.laFYCS = new System.Windows.Forms.Label();
            this.panel96 = new System.Windows.Forms.Panel();
            this.label174 = new System.Windows.Forms.Label();
            this.laYML = new System.Windows.Forms.Label();
            this.label151 = new System.Windows.Forms.Label();
            this.panel28 = new System.Windows.Forms.Panel();
            this.panel113 = new System.Windows.Forms.Panel();
            this.MIAOMUGG = new DevExpress.XtraEditors.TextEdit();
            this.laMIAOMUGG = new System.Windows.Forms.Label();
            this.panel83 = new System.Windows.Forms.Panel();
            this.ZHUHJ = new DevExpress.XtraEditors.TextEdit();
            this.laZHUHJ = new System.Windows.Forms.Label();
            this.panel87 = new System.Windows.Forms.Panel();
            this.label157 = new System.Windows.Forms.Label();
            this.laZLMD = new System.Windows.Forms.Label();
            this.label140 = new System.Windows.Forms.Label();
            this.panel72 = new System.Windows.Forms.Panel();
            this.panel17 = new System.Windows.Forms.Panel();
            this.laGXSZ = new System.Windows.Forms.Label();
            this.panel111 = new System.Windows.Forms.Panel();
            this.label160 = new System.Windows.Forms.Label();
            this.laGXMJ = new System.Windows.Forms.Label();
            this.panel59 = new System.Windows.Forms.Panel();
            this.GENGXINSJ = new DevExpress.XtraEditors.DateEdit();
            this.laGENGXINSJ = new System.Windows.Forms.Label();
            this.label109 = new System.Windows.Forms.Label();
            this.panel88 = new System.Windows.Forms.Panel();
            this.panel119 = new System.Windows.Forms.Panel();
            this.ZDGG = new DevExpress.XtraEditors.TextEdit();
            this.laZDGG = new System.Windows.Forms.Label();
            this.panel93 = new System.Windows.Forms.Panel();
            this.ZDFS = new DevExpress.XtraEditors.TextEdit();
            this.laZDFS = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            this.laGXFS = new System.Windows.Forms.Label();
            this.label98 = new System.Windows.Forms.Label();
            this.label175 = new System.Windows.Forms.Label();
            this.label176 = new System.Windows.Forms.Label();
            this.label177 = new System.Windows.Forms.Label();
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
            this.label43 = new System.Windows.Forms.Label();
            this.panelOther = new System.Windows.Forms.Panel();
            this.label53 = new System.Windows.Forms.Label();
            this.panel86 = new System.Windows.Forms.Panel();
            this.panel91 = new System.Windows.Forms.Panel();
            this.GXSJ = new DevExpress.XtraEditors.DateEdit();
            this.laGXSJ = new System.Windows.Forms.Label();
            this.panel92 = new System.Windows.Forms.Panel();
            this.laBHYY = new System.Windows.Forms.Label();
            this.label110 = new System.Windows.Forms.Label();
            this.label111 = new System.Windows.Forms.Label();
            this.label112 = new System.Windows.Forms.Label();
            this.label115 = new System.Windows.Forms.Label();
            this.panelPage1 = new System.Windows.Forms.Panel();
            this.panelControl1 = new System.Windows.Forms.Panel();
            this.panelHarTable = new System.Windows.Forms.Panel();
            this.label93 = new System.Windows.Forms.Label();
            this.panelTitle1 = new System.Windows.Forms.Panel();
            this.label161 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.panel132 = new System.Windows.Forms.Panel();
            this.panel134 = new System.Windows.Forms.Panel();
            this.SJRY = new DevExpress.XtraEditors.TextEdit();
            this.laSJRY = new System.Windows.Forms.Label();
            this.panel135 = new System.Windows.Forms.Panel();
            this.DCRY = new DevExpress.XtraEditors.TextEdit();
            this.laDCRY = new System.Windows.Forms.Label();
            this.label141 = new System.Windows.Forms.Label();
            this.panel136 = new System.Windows.Forms.Panel();
            this.buttonJC = new DevExpress.XtraEditors.SimpleButton();
            this.buttonPrint = new DevExpress.XtraEditors.SimpleButton();
            this.laSJBH = new System.Windows.Forms.Label();
            this.panel137 = new System.Windows.Forms.Panel();
            this.SJBH = new DevExpress.XtraEditors.TextEdit();
            this.BHYY = new AttributesEdit.ZLComboBox();
            this.GXDJ = new AttributesEdit.ZLComboBox();
            this.YML = new AttributesEdit.ZLSpinEdit();
            this.ZLMD = new AttributesEdit.ZLSpinEdit();
            this.GXSZ = new AttributesEdit.ZLComboBox();
            this.GXMJ = new AttributesEdit.ZLSpinEdit();
            this.GXFS = new AttributesEdit.ZLComboBox();
            this.JCFS = new AttributesEdit.ZLComboBox();
            this.BLMYBD = new AttributesEdit.ZLSpinEdit();
            this.SFCF = new AttributesEdit.ZLComboBox();
            this.CFQD = new AttributesEdit.ZLSpinEdit();
            this.CFMJ = new AttributesEdit.ZLSpinEdit();
            this.CFFS = new AttributesEdit.ZLComboBox();
            this.CFCS = new AttributesEdit.ZLSpinEdit();
            this.CFLX = new AttributesEdit.ZLComboBox();
            this.ZXJ = new AttributesEdit.ZLSpinEdit();
            this.FQZS = new AttributesEdit.ZLSpinEdit();
            this.PJGF = new AttributesEdit.ZLSpinEdit();
            this.HUO_LMGQXJ = new AttributesEdit.ZLSpinEdit();
            this.MEI_GQ_ZS = new AttributesEdit.ZLSpinEdit();
            this.SSXJ = new AttributesEdit.ZLSpinEdit();
            this.SSZZS = new AttributesEdit.ZLSpinEdit();
            this.QI_YUAN = new AttributesEdit.ZLComboBox();
            this.YU_BI_DU = new AttributesEdit.ZLSpinEdit();
            this.LING_ZU = new AttributesEdit.ZLComboBox();
            this.PINGJUN_NL = new AttributesEdit.ZLSpinEdit();
            this.TU_CENG_HD = new AttributesEdit.ZLSpinEdit();
            this.TU_RANG_LX = new AttributesEdit.ZLComboBox();
            this.CTMY = new AttributesEdit.ZLComboBox();
            this.HBG = new AttributesEdit.ZLSpinEdit();
            this.PO_WEI = new AttributesEdit.ZLComboBox();
            this.PO_DU = new AttributesEdit.ZLComboBox();
            this.PO_XIANG = new AttributesEdit.ZLComboBox();
            this.Q_SEN_LB = new AttributesEdit.ZLComboBox();
            this.SEN_LIN_LB = new AttributesEdit.ZLComboBox();
            this.Q_LD_QS = new AttributesEdit.ZLComboBox();
            this.LD_QS = new AttributesEdit.ZLComboBox();
            this.PINGJUN_SG = new AttributesEdit.ZLSpinEdit();
            this.PINGJUN_XJ = new AttributesEdit.ZLSpinEdit();
            this.YOU_SHI_SZ = new AttributesEdit.ZLComboBox();
            this.GJGYL_BHDJ = new AttributesEdit.ZLComboBox();
            this.Q_LIN_ZHONG = new AttributesEdit.ZLComboBox();
            this.LIN_ZHONG = new AttributesEdit.ZLComboBox();
            this.LMSYQ = new AttributesEdit.ZLComboBox();
            this.LMJYQ = new AttributesEdit.ZLComboBox();
            this.TDJYQ = new AttributesEdit.ZLComboBox();
            this.Q_DI_LEI = new AttributesEdit.ZLComboBox();
            this.DI_LEI = new AttributesEdit.ZLComboBox();
            this.MIAN_JI = new AttributesEdit.ZLSpinEdit();
            this.CUN = new AttributesEdit.ZLComboBox();
            this.XIANG = new AttributesEdit.ZLComboBox();
            this.XIAN = new AttributesEdit.ZLComboBox();
            this.SHI = new AttributesEdit.ZLComboBox();
            this.SHENG = new AttributesEdit.ZLComboBox();
            this.spinEdit3 = new AttributesEdit.ZLSpinEdit();
            this.panelBasicInfo.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel100.SuspendLayout();
            this.panel20.SuspendLayout();
            this.panel19.SuspendLayout();
            this.panel34.SuspendLayout();
            this.panel114.SuspendLayout();
            this.panel82.SuspendLayout();
            this.panel99.SuspendLayout();
            this.panel97.SuspendLayout();
            this.panel32.SuspendLayout();
            this.panel33.SuspendLayout();
            this.panel133.SuspendLayout();
            this.panel70.SuspendLayout();
            this.panel67.SuspendLayout();
            this.panel168.SuspendLayout();
            this.panel169.SuspendLayout();
            this.panel155.SuspendLayout();
            this.panel110.SuspendLayout();
            this.panel158.SuspendLayout();
            this.panel159.SuspendLayout();
            this.panel160.SuspendLayout();
            this.panel149.SuspendLayout();
            this.panel42.SuspendLayout();
            this.panel23.SuspendLayout();
            this.panel130.SuspendLayout();
            this.panel41.SuspendLayout();
            this.panel44.SuspendLayout();
            this.panel43.SuspendLayout();
            this.panel21.SuspendLayout();
            this.panel25.SuspendLayout();
            this.panel24.SuspendLayout();
            this.panel37.SuspendLayout();
            this.panel112.SuspendLayout();
            this.panel80.SuspendLayout();
            this.panel79.SuspendLayout();
            this.panel62.SuspendLayout();
            this.panel98.SuspendLayout();
            this.panel77.SuspendLayout();
            this.panel76.SuspendLayout();
            this.panel14.SuspendLayout();
            this.panel38.SuspendLayout();
            this.panel40.SuspendLayout();
            this.panel47.SuspendLayout();
            this.panel31.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel26.SuspendLayout();
            this.panel18.SuspendLayout();
            this.panel145.SuspendLayout();
            this.panel85.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DW.Properties)).BeginInit();
            this.panel146.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LMSYZXM.Properties)).BeginInit();
            this.panel138.SuspendLayout();
            this.panel22.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NORTH.Properties)).BeginInit();
            this.panel84.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SOUTH.Properties)).BeginInit();
            this.panel16.SuspendLayout();
            this.panel78.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.WEST.Properties)).BeginInit();
            this.panel75.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EAST.Properties)).BeginInit();
            this.panel120.SuspendLayout();
            this.panel144.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.XIAODM.Properties)).BeginInit();
            this.panel7.SuspendLayout();
            this.panel121.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.XI_BAN.Properties)).BeginInit();
            this.panel122.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.XIAO_BAN.Properties)).BeginInit();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LIN_BAN.Properties)).BeginInit();
            this.panel10.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel11.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panelHarvest.SuspendLayout();
            this.panel36.SuspendLayout();
            this.panel13.SuspendLayout();
            this.panel101.SuspendLayout();
            this.panel49.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FMFF.Properties)).BeginInit();
            this.panel39.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CFSJ.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CFSJ.Properties)).BeginInit();
            this.panel71.SuspendLayout();
            this.panel74.SuspendLayout();
            this.panel15.SuspendLayout();
            this.panel60.SuspendLayout();
            this.panel103.SuspendLayout();
            this.panel48.SuspendLayout();
            this.panel50.SuspendLayout();
            this.panel102.SuspendLayout();
            this.panel45.SuspendLayout();
            this.panel52.SuspendLayout();
            this.panelUpdate.SuspendLayout();
            this.panel108.SuspendLayout();
            this.panel81.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.QTSM.Properties)).BeginInit();
            this.panel118.SuspendLayout();
            this.panel115.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GXZRR.Properties)).BeginInit();
            this.panel12.SuspendLayout();
            this.panel94.SuspendLayout();
            this.panel95.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FYCS.Properties)).BeginInit();
            this.panel96.SuspendLayout();
            this.panel28.SuspendLayout();
            this.panel113.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MIAOMUGG.Properties)).BeginInit();
            this.panel83.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ZHUHJ.Properties)).BeginInit();
            this.panel87.SuspendLayout();
            this.panel72.SuspendLayout();
            this.panel17.SuspendLayout();
            this.panel111.SuspendLayout();
            this.panel59.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GENGXINSJ.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GENGXINSJ.Properties)).BeginInit();
            this.panel88.SuspendLayout();
            this.panel119.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ZDGG.Properties)).BeginInit();
            this.panel93.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ZDFS.Properties)).BeginInit();
            this.panel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit36.Properties)).BeginInit();
            this.panel89.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit51.Properties)).BeginInit();
            this.panel90.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit16.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit52.Properties)).BeginInit();
            this.panelOther.SuspendLayout();
            this.panel86.SuspendLayout();
            this.panel91.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GXSJ.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GXSJ.Properties)).BeginInit();
            this.panel92.SuspendLayout();
            this.panelPage1.SuspendLayout();
            this.panelControl1.SuspendLayout();
            this.panelHarTable.SuspendLayout();
            this.panelTitle1.SuspendLayout();
            this.panel132.SuspendLayout();
            this.panel134.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SJRY.Properties)).BeginInit();
            this.panel135.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DCRY.Properties)).BeginInit();
            this.panel136.SuspendLayout();
            this.panel137.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SJBH.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.YML.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ZLMD.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GXMJ.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BLMYBD.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CFQD.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CFMJ.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CFCS.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ZXJ.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FQZS.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PJGF.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HUO_LMGQXJ.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MEI_GQ_ZS.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SSXJ.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SSZZS.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.YU_BI_DU.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PINGJUN_NL.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TU_CENG_HD.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HBG.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PINGJUN_SG.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PINGJUN_XJ.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MIAN_JI.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit3.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelTitle
            // 
            this.labelTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelTitle.Font = new System.Drawing.Font("黑体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelTitle.Location = new System.Drawing.Point(0, 0);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(479, 25);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "伐区调查";
            this.labelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelBasicInfo
            // 
            this.panelBasicInfo.Controls.Add(this.panel1);
            this.panelBasicInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelBasicInfo.Location = new System.Drawing.Point(0, 50);
            this.panelBasicInfo.Name = "panelBasicInfo";
            this.panelBasicInfo.Size = new System.Drawing.Size(479, 451);
            this.panelBasicInfo.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel100);
            this.panel1.Controls.Add(this.panel114);
            this.panel1.Controls.Add(this.panel97);
            this.panel1.Controls.Add(this.panel133);
            this.panel1.Controls.Add(this.panel155);
            this.panel1.Controls.Add(this.panel149);
            this.panel1.Controls.Add(this.panel41);
            this.panel1.Controls.Add(this.panel21);
            this.panel1.Controls.Add(this.panel37);
            this.panel1.Controls.Add(this.panel62);
            this.panel1.Controls.Add(this.panel14);
            this.panel1.Controls.Add(this.panel31);
            this.panel1.Controls.Add(this.panel145);
            this.panel1.Controls.Add(this.panel138);
            this.panel1.Controls.Add(this.panel16);
            this.panel1.Controls.Add(this.panel120);
            this.panel1.Controls.Add(this.panel7);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(479, 451);
            this.panel1.TabIndex = 0;
            // 
            // panel100
            // 
            this.panel100.Controls.Add(this.panel20);
            this.panel100.Controls.Add(this.laZXJ);
            this.panel100.Controls.Add(this.panel19);
            this.panel100.Controls.Add(this.laFQZS);
            this.panel100.Controls.Add(this.panel34);
            this.panel100.Controls.Add(this.laPJGF);
            this.panel100.Controls.Add(this.label162);
            this.panel100.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel100.Location = new System.Drawing.Point(0, 425);
            this.panel100.Name = "panel100";
            this.panel100.Size = new System.Drawing.Size(479, 25);
            this.panel100.TabIndex = 0;
            // 
            // panel20
            // 
            this.panel20.Controls.Add(this.ZXJ);
            this.panel20.Controls.Add(this.label21);
            this.panel20.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel20.Location = new System.Drawing.Point(354, 0);
            this.panel20.Name = "panel20";
            this.panel20.Padding = new System.Windows.Forms.Padding(2, 6, 6, 2);
            this.panel20.Size = new System.Drawing.Size(104, 24);
            this.panel20.TabIndex = 0;
            // 
            // label21
            // 
            this.label21.Dock = System.Windows.Forms.DockStyle.Right;
            this.label21.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.Color.Blue;
            this.label21.Location = new System.Drawing.Point(74, 6);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(24, 16);
            this.label21.TabIndex = 0;
            this.label21.Text = "m³";
            // 
            // laZXJ
            // 
            this.laZXJ.Dock = System.Windows.Forms.DockStyle.Left;
            this.laZXJ.Location = new System.Drawing.Point(299, 0);
            this.laZXJ.Name = "laZXJ";
            this.laZXJ.Size = new System.Drawing.Size(55, 24);
            this.laZXJ.TabIndex = 0;
            this.laZXJ.Text = "伐区蓄积";
            this.laZXJ.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel19
            // 
            this.panel19.Controls.Add(this.FQZS);
            this.panel19.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel19.Location = new System.Drawing.Point(204, 0);
            this.panel19.Name = "panel19";
            this.panel19.Padding = new System.Windows.Forms.Padding(2, 2, 6, 2);
            this.panel19.Size = new System.Drawing.Size(95, 24);
            this.panel19.TabIndex = 0;
            // 
            // laFQZS
            // 
            this.laFQZS.Dock = System.Windows.Forms.DockStyle.Left;
            this.laFQZS.Location = new System.Drawing.Point(149, 0);
            this.laFQZS.Name = "laFQZS";
            this.laFQZS.Size = new System.Drawing.Size(55, 24);
            this.laFQZS.TabIndex = 0;
            this.laFQZS.Text = "伐区株数";
            this.laFQZS.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel34
            // 
            this.panel34.Controls.Add(this.PJGF);
            this.panel34.Controls.Add(this.label76);
            this.panel34.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel34.Location = new System.Drawing.Point(55, 0);
            this.panel34.Name = "panel34";
            this.panel34.Padding = new System.Windows.Forms.Padding(2, 6, 6, 2);
            this.panel34.Size = new System.Drawing.Size(94, 24);
            this.panel34.TabIndex = 0;
            // 
            // label76
            // 
            this.label76.Dock = System.Windows.Forms.DockStyle.Right;
            this.label76.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label76.ForeColor = System.Drawing.Color.Blue;
            this.label76.Location = new System.Drawing.Point(72, 6);
            this.label76.Name = "label76";
            this.label76.Size = new System.Drawing.Size(16, 16);
            this.label76.TabIndex = 0;
            this.label76.Text = "m";
            // 
            // laPJGF
            // 
            this.laPJGF.Dock = System.Windows.Forms.DockStyle.Left;
            this.laPJGF.Location = new System.Drawing.Point(0, 0);
            this.laPJGF.Name = "laPJGF";
            this.laPJGF.Size = new System.Drawing.Size(55, 24);
            this.laPJGF.TabIndex = 0;
            this.laPJGF.Text = "平均冠幅";
            this.laPJGF.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label162
            // 
            this.label162.BackColor = System.Drawing.Color.Black;
            this.label162.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label162.Location = new System.Drawing.Point(0, 24);
            this.label162.Name = "label162";
            this.label162.Size = new System.Drawing.Size(479, 1);
            this.label162.TabIndex = 0;
            this.label162.Text = "label162";
            this.label162.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel114
            // 
            this.panel114.Controls.Add(this.panel82);
            this.panel114.Controls.Add(this.laHUO_LMGQXJ);
            this.panel114.Controls.Add(this.panel99);
            this.panel114.Controls.Add(this.laMEI_GQ_ZS);
            this.panel114.Controls.Add(this.label169);
            this.panel114.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel114.Location = new System.Drawing.Point(0, 400);
            this.panel114.Name = "panel114";
            this.panel114.Size = new System.Drawing.Size(479, 25);
            this.panel114.TabIndex = 0;
            // 
            // panel82
            // 
            this.panel82.Controls.Add(this.HUO_LMGQXJ);
            this.panel82.Controls.Add(this.label129);
            this.panel82.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel82.Location = new System.Drawing.Point(256, 0);
            this.panel82.Name = "panel82";
            this.panel82.Padding = new System.Windows.Forms.Padding(2, 6, 6, 2);
            this.panel82.Size = new System.Drawing.Size(119, 24);
            this.panel82.TabIndex = 0;
            // 
            // label129
            // 
            this.label129.Dock = System.Windows.Forms.DockStyle.Right;
            this.label129.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label129.ForeColor = System.Drawing.Color.Blue;
            this.label129.Location = new System.Drawing.Point(89, 6);
            this.label129.Name = "label129";
            this.label129.Size = new System.Drawing.Size(24, 16);
            this.label129.TabIndex = 0;
            this.label129.Text = "m³";
            // 
            // laHUO_LMGQXJ
            // 
            this.laHUO_LMGQXJ.Dock = System.Windows.Forms.DockStyle.Left;
            this.laHUO_LMGQXJ.Location = new System.Drawing.Point(179, 0);
            this.laHUO_LMGQXJ.Name = "laHUO_LMGQXJ";
            this.laHUO_LMGQXJ.Size = new System.Drawing.Size(77, 24);
            this.laHUO_LMGQXJ.TabIndex = 0;
            this.laHUO_LMGQXJ.Text = "每公顷蓄积量";
            this.laHUO_LMGQXJ.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel99
            // 
            this.panel99.Controls.Add(this.MEI_GQ_ZS);
            this.panel99.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel99.Location = new System.Drawing.Point(66, 0);
            this.panel99.Name = "panel99";
            this.panel99.Padding = new System.Windows.Forms.Padding(2, 2, 6, 2);
            this.panel99.Size = new System.Drawing.Size(113, 24);
            this.panel99.TabIndex = 0;
            // 
            // laMEI_GQ_ZS
            // 
            this.laMEI_GQ_ZS.Dock = System.Windows.Forms.DockStyle.Left;
            this.laMEI_GQ_ZS.Location = new System.Drawing.Point(0, 0);
            this.laMEI_GQ_ZS.Name = "laMEI_GQ_ZS";
            this.laMEI_GQ_ZS.Size = new System.Drawing.Size(66, 24);
            this.laMEI_GQ_ZS.TabIndex = 0;
            this.laMEI_GQ_ZS.Text = "每公顷株数";
            this.laMEI_GQ_ZS.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label169
            // 
            this.label169.BackColor = System.Drawing.Color.Black;
            this.label169.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label169.Location = new System.Drawing.Point(0, 24);
            this.label169.Name = "label169";
            this.label169.Size = new System.Drawing.Size(479, 1);
            this.label169.TabIndex = 0;
            this.label169.Text = "label169";
            this.label169.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel97
            // 
            this.panel97.Controls.Add(this.panel32);
            this.panel97.Controls.Add(this.laSSXJ);
            this.panel97.Controls.Add(this.panel33);
            this.panel97.Controls.Add(this.laSSZZS);
            this.panel97.Controls.Add(this.label158);
            this.panel97.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel97.Location = new System.Drawing.Point(0, 375);
            this.panel97.Name = "panel97";
            this.panel97.Size = new System.Drawing.Size(479, 25);
            this.panel97.TabIndex = 0;
            // 
            // panel32
            // 
            this.panel32.Controls.Add(this.SSXJ);
            this.panel32.Controls.Add(this.label82);
            this.panel32.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel32.Location = new System.Drawing.Point(245, 0);
            this.panel32.Name = "panel32";
            this.panel32.Padding = new System.Windows.Forms.Padding(2, 6, 6, 2);
            this.panel32.Size = new System.Drawing.Size(130, 24);
            this.panel32.TabIndex = 0;
            // 
            // label82
            // 
            this.label82.Dock = System.Windows.Forms.DockStyle.Right;
            this.label82.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label82.ForeColor = System.Drawing.Color.Blue;
            this.label82.Location = new System.Drawing.Point(100, 6);
            this.label82.Name = "label82";
            this.label82.Size = new System.Drawing.Size(24, 16);
            this.label82.TabIndex = 0;
            this.label82.Text = "m³";
            // 
            // laSSXJ
            // 
            this.laSSXJ.Dock = System.Windows.Forms.DockStyle.Left;
            this.laSSXJ.Location = new System.Drawing.Point(179, 0);
            this.laSSXJ.Name = "laSSXJ";
            this.laSSXJ.Size = new System.Drawing.Size(66, 24);
            this.laSSXJ.TabIndex = 0;
            this.laSSXJ.Text = "散生木蓄积";
            this.laSSXJ.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel33
            // 
            this.panel33.Controls.Add(this.SSZZS);
            this.panel33.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel33.Location = new System.Drawing.Point(66, 0);
            this.panel33.Name = "panel33";
            this.panel33.Padding = new System.Windows.Forms.Padding(2, 2, 6, 2);
            this.panel33.Size = new System.Drawing.Size(113, 24);
            this.panel33.TabIndex = 0;
            // 
            // laSSZZS
            // 
            this.laSSZZS.Dock = System.Windows.Forms.DockStyle.Left;
            this.laSSZZS.Location = new System.Drawing.Point(0, 0);
            this.laSSZZS.Name = "laSSZZS";
            this.laSSZZS.Size = new System.Drawing.Size(66, 24);
            this.laSSZZS.TabIndex = 0;
            this.laSSZZS.Text = "散生木株数";
            this.laSSZZS.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label158
            // 
            this.label158.BackColor = System.Drawing.Color.Black;
            this.label158.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label158.Location = new System.Drawing.Point(0, 24);
            this.label158.Name = "label158";
            this.label158.Size = new System.Drawing.Size(479, 1);
            this.label158.TabIndex = 0;
            this.label158.Text = "label158";
            this.label158.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel133
            // 
            this.panel133.Controls.Add(this.panel70);
            this.panel133.Controls.Add(this.laQI_YUAN);
            this.panel133.Controls.Add(this.panel67);
            this.panel133.Controls.Add(this.laYU_BI_DU);
            this.panel133.Controls.Add(this.panel168);
            this.panel133.Controls.Add(this.laLING_ZU);
            this.panel133.Controls.Add(this.panel169);
            this.panel133.Controls.Add(this.laPINGJUN_NL);
            this.panel133.Controls.Add(this.label222);
            this.panel133.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel133.Location = new System.Drawing.Point(0, 350);
            this.panel133.Name = "panel133";
            this.panel133.Size = new System.Drawing.Size(479, 25);
            this.panel133.TabIndex = 0;
            // 
            // panel70
            // 
            this.panel70.Controls.Add(this.QI_YUAN);
            this.panel70.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel70.Location = new System.Drawing.Point(359, 0);
            this.panel70.Name = "panel70";
            this.panel70.Padding = new System.Windows.Forms.Padding(2, 4, 4, 0);
            this.panel70.Size = new System.Drawing.Size(99, 24);
            this.panel70.TabIndex = 0;
            // 
            // laQI_YUAN
            // 
            this.laQI_YUAN.Dock = System.Windows.Forms.DockStyle.Left;
            this.laQI_YUAN.Location = new System.Drawing.Point(329, 0);
            this.laQI_YUAN.Name = "laQI_YUAN";
            this.laQI_YUAN.Size = new System.Drawing.Size(30, 24);
            this.laQI_YUAN.TabIndex = 0;
            this.laQI_YUAN.Text = "起源";
            this.laQI_YUAN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel67
            // 
            this.panel67.Controls.Add(this.YU_BI_DU);
            this.panel67.Controls.Add(this.label52);
            this.panel67.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel67.Location = new System.Drawing.Point(262, 0);
            this.panel67.Name = "panel67";
            this.panel67.Padding = new System.Windows.Forms.Padding(2, 6, 6, 2);
            this.panel67.Size = new System.Drawing.Size(67, 24);
            this.panel67.TabIndex = 0;
            // 
            // label52
            // 
            this.label52.Dock = System.Windows.Forms.DockStyle.Right;
            this.label52.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label52.ForeColor = System.Drawing.Color.Blue;
            this.label52.Location = new System.Drawing.Point(56, 6);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(5, 16);
            this.label52.TabIndex = 0;
            // 
            // laYU_BI_DU
            // 
            this.laYU_BI_DU.Dock = System.Windows.Forms.DockStyle.Left;
            this.laYU_BI_DU.Location = new System.Drawing.Point(220, 0);
            this.laYU_BI_DU.Name = "laYU_BI_DU";
            this.laYU_BI_DU.Size = new System.Drawing.Size(42, 24);
            this.laYU_BI_DU.TabIndex = 0;
            this.laYU_BI_DU.Text = "郁闭度";
            this.laYU_BI_DU.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel168
            // 
            this.panel168.Controls.Add(this.LING_ZU);
            this.panel168.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel168.Location = new System.Drawing.Point(140, 0);
            this.panel168.Name = "panel168";
            this.panel168.Padding = new System.Windows.Forms.Padding(2, 4, 4, 0);
            this.panel168.Size = new System.Drawing.Size(80, 24);
            this.panel168.TabIndex = 0;
            // 
            // laLING_ZU
            // 
            this.laLING_ZU.Dock = System.Windows.Forms.DockStyle.Left;
            this.laLING_ZU.Location = new System.Drawing.Point(110, 0);
            this.laLING_ZU.Name = "laLING_ZU";
            this.laLING_ZU.Size = new System.Drawing.Size(30, 24);
            this.laLING_ZU.TabIndex = 0;
            this.laLING_ZU.Text = "龄组";
            this.laLING_ZU.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel169
            // 
            this.panel169.Controls.Add(this.PINGJUN_NL);
            this.panel169.Controls.Add(this.label203);
            this.panel169.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel169.Location = new System.Drawing.Point(30, 0);
            this.panel169.Name = "panel169";
            this.panel169.Padding = new System.Windows.Forms.Padding(2, 6, 6, 2);
            this.panel169.Size = new System.Drawing.Size(80, 24);
            this.panel169.TabIndex = 0;
            // 
            // label203
            // 
            this.label203.Dock = System.Windows.Forms.DockStyle.Right;
            this.label203.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label203.ForeColor = System.Drawing.Color.Blue;
            this.label203.Location = new System.Drawing.Point(69, 6);
            this.label203.Name = "label203";
            this.label203.Size = new System.Drawing.Size(5, 16);
            this.label203.TabIndex = 0;
            // 
            // laPINGJUN_NL
            // 
            this.laPINGJUN_NL.Dock = System.Windows.Forms.DockStyle.Left;
            this.laPINGJUN_NL.Location = new System.Drawing.Point(0, 0);
            this.laPINGJUN_NL.Name = "laPINGJUN_NL";
            this.laPINGJUN_NL.Size = new System.Drawing.Size(30, 24);
            this.laPINGJUN_NL.TabIndex = 0;
            this.laPINGJUN_NL.Text = "林龄";
            this.laPINGJUN_NL.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label222
            // 
            this.label222.BackColor = System.Drawing.Color.Black;
            this.label222.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label222.Location = new System.Drawing.Point(0, 24);
            this.label222.Name = "label222";
            this.label222.Size = new System.Drawing.Size(479, 1);
            this.label222.TabIndex = 0;
            this.label222.Text = "label222";
            this.label222.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel155
            // 
            this.panel155.Controls.Add(this.panel110);
            this.panel155.Controls.Add(this.laTU_CENG_HD);
            this.panel155.Controls.Add(this.panel158);
            this.panel155.Controls.Add(this.laTU_RANG_LX);
            this.panel155.Controls.Add(this.panel159);
            this.panel155.Controls.Add(this.laCTMY);
            this.panel155.Controls.Add(this.panel160);
            this.panel155.Controls.Add(this.laHBG);
            this.panel155.Controls.Add(this.label228);
            this.panel155.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel155.Location = new System.Drawing.Point(0, 325);
            this.panel155.Name = "panel155";
            this.panel155.Size = new System.Drawing.Size(479, 25);
            this.panel155.TabIndex = 0;
            // 
            // panel110
            // 
            this.panel110.Controls.Add(this.TU_CENG_HD);
            this.panel110.Controls.Add(this.label159);
            this.panel110.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel110.Location = new System.Drawing.Point(372, 0);
            this.panel110.Name = "panel110";
            this.panel110.Padding = new System.Windows.Forms.Padding(2, 6, 6, 2);
            this.panel110.Size = new System.Drawing.Size(86, 24);
            this.panel110.TabIndex = 0;
            // 
            // label159
            // 
            this.label159.Dock = System.Windows.Forms.DockStyle.Right;
            this.label159.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label159.ForeColor = System.Drawing.Color.Blue;
            this.label159.Location = new System.Drawing.Point(54, 6);
            this.label159.Name = "label159";
            this.label159.Size = new System.Drawing.Size(26, 16);
            this.label159.TabIndex = 0;
            this.label159.Text = "cm";
            // 
            // laTU_CENG_HD
            // 
            this.laTU_CENG_HD.Dock = System.Windows.Forms.DockStyle.Left;
            this.laTU_CENG_HD.Location = new System.Drawing.Point(330, 0);
            this.laTU_CENG_HD.Name = "laTU_CENG_HD";
            this.laTU_CENG_HD.Size = new System.Drawing.Size(42, 24);
            this.laTU_CENG_HD.TabIndex = 0;
            this.laTU_CENG_HD.Text = "土层厚";
            this.laTU_CENG_HD.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel158
            // 
            this.panel158.Controls.Add(this.TU_RANG_LX);
            this.panel158.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel158.Location = new System.Drawing.Point(250, 0);
            this.panel158.Name = "panel158";
            this.panel158.Padding = new System.Windows.Forms.Padding(2, 4, 4, 0);
            this.panel158.Size = new System.Drawing.Size(80, 24);
            this.panel158.TabIndex = 0;
            // 
            // laTU_RANG_LX
            // 
            this.laTU_RANG_LX.Dock = System.Windows.Forms.DockStyle.Left;
            this.laTU_RANG_LX.Location = new System.Drawing.Point(220, 0);
            this.laTU_RANG_LX.Name = "laTU_RANG_LX";
            this.laTU_RANG_LX.Size = new System.Drawing.Size(30, 24);
            this.laTU_RANG_LX.TabIndex = 0;
            this.laTU_RANG_LX.Text = "土壤";
            this.laTU_RANG_LX.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel159
            // 
            this.panel159.Controls.Add(this.CTMY);
            this.panel159.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel159.Location = new System.Drawing.Point(140, 0);
            this.panel159.Name = "panel159";
            this.panel159.Padding = new System.Windows.Forms.Padding(2, 4, 4, 0);
            this.panel159.Size = new System.Drawing.Size(80, 24);
            this.panel159.TabIndex = 0;
            // 
            // laCTMY
            // 
            this.laCTMY.Dock = System.Windows.Forms.DockStyle.Left;
            this.laCTMY.Location = new System.Drawing.Point(110, 0);
            this.laCTMY.Name = "laCTMY";
            this.laCTMY.Size = new System.Drawing.Size(30, 24);
            this.laCTMY.TabIndex = 0;
            this.laCTMY.Text = "母岩";
            this.laCTMY.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel160
            // 
            this.panel160.Controls.Add(this.HBG);
            this.panel160.Controls.Add(this.label226);
            this.panel160.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel160.Location = new System.Drawing.Point(30, 0);
            this.panel160.Name = "panel160";
            this.panel160.Padding = new System.Windows.Forms.Padding(2, 6, 6, 2);
            this.panel160.Size = new System.Drawing.Size(80, 24);
            this.panel160.TabIndex = 0;
            // 
            // label226
            // 
            this.label226.Dock = System.Windows.Forms.DockStyle.Right;
            this.label226.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label226.ForeColor = System.Drawing.Color.Blue;
            this.label226.Location = new System.Drawing.Point(54, 6);
            this.label226.Name = "label226";
            this.label226.Size = new System.Drawing.Size(20, 16);
            this.label226.TabIndex = 0;
            this.label226.Text = "米";
            // 
            // laHBG
            // 
            this.laHBG.Dock = System.Windows.Forms.DockStyle.Left;
            this.laHBG.Location = new System.Drawing.Point(0, 0);
            this.laHBG.Name = "laHBG";
            this.laHBG.Size = new System.Drawing.Size(30, 24);
            this.laHBG.TabIndex = 0;
            this.laHBG.Text = "海拔";
            this.laHBG.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label228
            // 
            this.label228.BackColor = System.Drawing.Color.Black;
            this.label228.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label228.Location = new System.Drawing.Point(0, 24);
            this.label228.Name = "label228";
            this.label228.Size = new System.Drawing.Size(479, 1);
            this.label228.TabIndex = 0;
            this.label228.Text = "label228";
            this.label228.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel149
            // 
            this.panel149.Controls.Add(this.panel42);
            this.panel149.Controls.Add(this.laPO_WEI);
            this.panel149.Controls.Add(this.panel23);
            this.panel149.Controls.Add(this.laPO_DU);
            this.panel149.Controls.Add(this.panel130);
            this.panel149.Controls.Add(this.laPO_XIANG);
            this.panel149.Controls.Add(this.label224);
            this.panel149.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel149.Location = new System.Drawing.Point(0, 300);
            this.panel149.Name = "panel149";
            this.panel149.Size = new System.Drawing.Size(479, 25);
            this.panel149.TabIndex = 0;
            // 
            // panel42
            // 
            this.panel42.Controls.Add(this.PO_WEI);
            this.panel42.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel42.Location = new System.Drawing.Point(250, 0);
            this.panel42.Name = "panel42";
            this.panel42.Padding = new System.Windows.Forms.Padding(2, 4, 4, 0);
            this.panel42.Size = new System.Drawing.Size(80, 24);
            this.panel42.TabIndex = 0;
            // 
            // laPO_WEI
            // 
            this.laPO_WEI.Dock = System.Windows.Forms.DockStyle.Left;
            this.laPO_WEI.Location = new System.Drawing.Point(220, 0);
            this.laPO_WEI.Name = "laPO_WEI";
            this.laPO_WEI.Size = new System.Drawing.Size(30, 24);
            this.laPO_WEI.TabIndex = 0;
            this.laPO_WEI.Text = "坡位";
            this.laPO_WEI.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel23
            // 
            this.panel23.Controls.Add(this.PO_DU);
            this.panel23.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel23.Location = new System.Drawing.Point(140, 0);
            this.panel23.Name = "panel23";
            this.panel23.Padding = new System.Windows.Forms.Padding(2, 4, 4, 0);
            this.panel23.Size = new System.Drawing.Size(80, 24);
            this.panel23.TabIndex = 0;
            // 
            // laPO_DU
            // 
            this.laPO_DU.Dock = System.Windows.Forms.DockStyle.Left;
            this.laPO_DU.Location = new System.Drawing.Point(110, 0);
            this.laPO_DU.Name = "laPO_DU";
            this.laPO_DU.Size = new System.Drawing.Size(30, 24);
            this.laPO_DU.TabIndex = 0;
            this.laPO_DU.Text = "坡度";
            this.laPO_DU.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel130
            // 
            this.panel130.Controls.Add(this.PO_XIANG);
            this.panel130.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel130.Location = new System.Drawing.Point(30, 0);
            this.panel130.Name = "panel130";
            this.panel130.Padding = new System.Windows.Forms.Padding(2, 4, 4, 0);
            this.panel130.Size = new System.Drawing.Size(80, 24);
            this.panel130.TabIndex = 0;
            // 
            // laPO_XIANG
            // 
            this.laPO_XIANG.Dock = System.Windows.Forms.DockStyle.Left;
            this.laPO_XIANG.Location = new System.Drawing.Point(0, 0);
            this.laPO_XIANG.Name = "laPO_XIANG";
            this.laPO_XIANG.Size = new System.Drawing.Size(30, 24);
            this.laPO_XIANG.TabIndex = 0;
            this.laPO_XIANG.Text = "坡向";
            this.laPO_XIANG.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label224
            // 
            this.label224.BackColor = System.Drawing.Color.Black;
            this.label224.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label224.Location = new System.Drawing.Point(0, 24);
            this.label224.Name = "label224";
            this.label224.Size = new System.Drawing.Size(479, 1);
            this.label224.TabIndex = 0;
            this.label224.Text = "label224";
            this.label224.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel41
            // 
            this.panel41.Controls.Add(this.labelLBMess);
            this.panel41.Controls.Add(this.panel44);
            this.panel41.Controls.Add(this.laQ_SEN_LB);
            this.panel41.Controls.Add(this.panel43);
            this.panel41.Controls.Add(this.laSEN_LIN_LB);
            this.panel41.Controls.Add(this.label65);
            this.panel41.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel41.Location = new System.Drawing.Point(0, 275);
            this.panel41.Name = "panel41";
            this.panel41.Size = new System.Drawing.Size(479, 25);
            this.panel41.TabIndex = 0;
            // 
            // labelLBMess
            // 
            this.labelLBMess.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelLBMess.ForeColor = System.Drawing.Color.Red;
            this.labelLBMess.Location = new System.Drawing.Point(376, 0);
            this.labelLBMess.Name = "labelLBMess";
            this.labelLBMess.Size = new System.Drawing.Size(103, 24);
            this.labelLBMess.TabIndex = 0;
            this.labelLBMess.Text = "森林类别已改变！";
            this.labelLBMess.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelLBMess.Visible = false;
            // 
            // panel44
            // 
            this.panel44.Controls.Add(this.Q_SEN_LB);
            this.panel44.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel44.Location = new System.Drawing.Point(256, 0);
            this.panel44.Name = "panel44";
            this.panel44.Padding = new System.Windows.Forms.Padding(2, 4, 2, 0);
            this.panel44.Size = new System.Drawing.Size(120, 24);
            this.panel44.TabIndex = 0;
            // 
            // laQ_SEN_LB
            // 
            this.laQ_SEN_LB.Dock = System.Windows.Forms.DockStyle.Left;
            this.laQ_SEN_LB.Location = new System.Drawing.Point(179, 0);
            this.laQ_SEN_LB.Name = "laQ_SEN_LB";
            this.laQ_SEN_LB.Size = new System.Drawing.Size(77, 24);
            this.laQ_SEN_LB.TabIndex = 0;
            this.laQ_SEN_LB.Text = "前期森林类别";
            this.laQ_SEN_LB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel43
            // 
            this.panel43.Controls.Add(this.SEN_LIN_LB);
            this.panel43.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel43.Location = new System.Drawing.Point(55, 0);
            this.panel43.Name = "panel43";
            this.panel43.Padding = new System.Windows.Forms.Padding(2, 4, 4, 0);
            this.panel43.Size = new System.Drawing.Size(124, 24);
            this.panel43.TabIndex = 0;
            // 
            // laSEN_LIN_LB
            // 
            this.laSEN_LIN_LB.Dock = System.Windows.Forms.DockStyle.Left;
            this.laSEN_LIN_LB.Location = new System.Drawing.Point(0, 0);
            this.laSEN_LIN_LB.Name = "laSEN_LIN_LB";
            this.laSEN_LIN_LB.Size = new System.Drawing.Size(55, 24);
            this.laSEN_LIN_LB.TabIndex = 0;
            this.laSEN_LIN_LB.Text = "森林类别";
            this.laSEN_LIN_LB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label65
            // 
            this.label65.BackColor = System.Drawing.Color.Black;
            this.label65.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label65.Location = new System.Drawing.Point(0, 24);
            this.label65.Name = "label65";
            this.label65.Size = new System.Drawing.Size(479, 1);
            this.label65.TabIndex = 0;
            this.label65.Text = "label65";
            this.label65.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel21
            // 
            this.panel21.Controls.Add(this.panel25);
            this.panel21.Controls.Add(this.laQ_LD_QS);
            this.panel21.Controls.Add(this.panel24);
            this.panel21.Controls.Add(this.laLD_QS);
            this.panel21.Controls.Add(this.label47);
            this.panel21.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel21.Location = new System.Drawing.Point(0, 250);
            this.panel21.Name = "panel21";
            this.panel21.Size = new System.Drawing.Size(479, 25);
            this.panel21.TabIndex = 0;
            // 
            // panel25
            // 
            this.panel25.Controls.Add(this.Q_LD_QS);
            this.panel25.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel25.Location = new System.Drawing.Point(256, 0);
            this.panel25.Name = "panel25";
            this.panel25.Padding = new System.Windows.Forms.Padding(2, 4, 4, 0);
            this.panel25.Size = new System.Drawing.Size(120, 24);
            this.panel25.TabIndex = 0;
            // 
            // laQ_LD_QS
            // 
            this.laQ_LD_QS.Dock = System.Windows.Forms.DockStyle.Left;
            this.laQ_LD_QS.Location = new System.Drawing.Point(179, 0);
            this.laQ_LD_QS.Name = "laQ_LD_QS";
            this.laQ_LD_QS.Size = new System.Drawing.Size(77, 24);
            this.laQ_LD_QS.TabIndex = 0;
            this.laQ_LD_QS.Text = "前期土地权属";
            this.laQ_LD_QS.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel24
            // 
            this.panel24.Controls.Add(this.LD_QS);
            this.panel24.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel24.Location = new System.Drawing.Point(55, 0);
            this.panel24.Name = "panel24";
            this.panel24.Padding = new System.Windows.Forms.Padding(2, 4, 4, 0);
            this.panel24.Size = new System.Drawing.Size(124, 24);
            this.panel24.TabIndex = 0;
            // 
            // laLD_QS
            // 
            this.laLD_QS.Dock = System.Windows.Forms.DockStyle.Left;
            this.laLD_QS.Location = new System.Drawing.Point(0, 0);
            this.laLD_QS.Name = "laLD_QS";
            this.laLD_QS.Size = new System.Drawing.Size(55, 24);
            this.laLD_QS.TabIndex = 0;
            this.laLD_QS.Text = "土地权属";
            this.laLD_QS.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label47
            // 
            this.label47.BackColor = System.Drawing.Color.Black;
            this.label47.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label47.Location = new System.Drawing.Point(0, 24);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(479, 1);
            this.label47.TabIndex = 0;
            this.label47.Text = "label47";
            this.label47.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel37
            // 
            this.panel37.Controls.Add(this.panel112);
            this.panel37.Controls.Add(this.laPINGJUN_SG);
            this.panel37.Controls.Add(this.panel80);
            this.panel37.Controls.Add(this.laPINGJUN_XJ);
            this.panel37.Controls.Add(this.panel79);
            this.panel37.Controls.Add(this.laYOU_SHI_SZ);
            this.panel37.Controls.Add(this.label183);
            this.panel37.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel37.Location = new System.Drawing.Point(0, 225);
            this.panel37.Name = "panel37";
            this.panel37.Size = new System.Drawing.Size(479, 25);
            this.panel37.TabIndex = 0;
            // 
            // panel112
            // 
            this.panel112.Controls.Add(this.PINGJUN_SG);
            this.panel112.Controls.Add(this.label163);
            this.panel112.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel112.Location = new System.Drawing.Point(341, 0);
            this.panel112.Name = "panel112";
            this.panel112.Padding = new System.Windows.Forms.Padding(2, 6, 6, 2);
            this.panel112.Size = new System.Drawing.Size(117, 24);
            this.panel112.TabIndex = 0;
            // 
            // label163
            // 
            this.label163.Dock = System.Windows.Forms.DockStyle.Right;
            this.label163.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label163.ForeColor = System.Drawing.Color.Blue;
            this.label163.Location = new System.Drawing.Point(93, 6);
            this.label163.Name = "label163";
            this.label163.Size = new System.Drawing.Size(18, 16);
            this.label163.TabIndex = 0;
            this.label163.Text = "m";
            // 
            // laPINGJUN_SG
            // 
            this.laPINGJUN_SG.Dock = System.Windows.Forms.DockStyle.Left;
            this.laPINGJUN_SG.Location = new System.Drawing.Point(299, 0);
            this.laPINGJUN_SG.Name = "laPINGJUN_SG";
            this.laPINGJUN_SG.Size = new System.Drawing.Size(42, 24);
            this.laPINGJUN_SG.TabIndex = 0;
            this.laPINGJUN_SG.Text = "平均高";
            this.laPINGJUN_SG.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel80
            // 
            this.panel80.Controls.Add(this.PINGJUN_XJ);
            this.panel80.Controls.Add(this.label126);
            this.panel80.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel80.Location = new System.Drawing.Point(204, 0);
            this.panel80.Name = "panel80";
            this.panel80.Padding = new System.Windows.Forms.Padding(2, 6, 6, 2);
            this.panel80.Size = new System.Drawing.Size(95, 24);
            this.panel80.TabIndex = 0;
            // 
            // label126
            // 
            this.label126.Dock = System.Windows.Forms.DockStyle.Right;
            this.label126.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label126.ForeColor = System.Drawing.Color.Blue;
            this.label126.Location = new System.Drawing.Point(63, 6);
            this.label126.Name = "label126";
            this.label126.Size = new System.Drawing.Size(26, 16);
            this.label126.TabIndex = 0;
            this.label126.Text = "cm";
            // 
            // laPINGJUN_XJ
            // 
            this.laPINGJUN_XJ.Dock = System.Windows.Forms.DockStyle.Left;
            this.laPINGJUN_XJ.Location = new System.Drawing.Point(149, 0);
            this.laPINGJUN_XJ.Name = "laPINGJUN_XJ";
            this.laPINGJUN_XJ.Size = new System.Drawing.Size(55, 24);
            this.laPINGJUN_XJ.TabIndex = 0;
            this.laPINGJUN_XJ.Text = "平均胸径";
            this.laPINGJUN_XJ.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel79
            // 
            this.panel79.Controls.Add(this.YOU_SHI_SZ);
            this.panel79.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel79.Location = new System.Drawing.Point(30, 0);
            this.panel79.Name = "panel79";
            this.panel79.Padding = new System.Windows.Forms.Padding(2, 4, 4, 0);
            this.panel79.Size = new System.Drawing.Size(119, 24);
            this.panel79.TabIndex = 0;
            // 
            // laYOU_SHI_SZ
            // 
            this.laYOU_SHI_SZ.Dock = System.Windows.Forms.DockStyle.Left;
            this.laYOU_SHI_SZ.Location = new System.Drawing.Point(0, 0);
            this.laYOU_SHI_SZ.Name = "laYOU_SHI_SZ";
            this.laYOU_SHI_SZ.Size = new System.Drawing.Size(30, 24);
            this.laYOU_SHI_SZ.TabIndex = 0;
            this.laYOU_SHI_SZ.Text = "树种";
            this.laYOU_SHI_SZ.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label183
            // 
            this.label183.BackColor = System.Drawing.Color.Black;
            this.label183.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label183.Location = new System.Drawing.Point(0, 24);
            this.label183.Name = "label183";
            this.label183.Size = new System.Drawing.Size(479, 1);
            this.label183.TabIndex = 0;
            this.label183.Text = "label183";
            this.label183.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel62
            // 
            this.panel62.Controls.Add(this.panel98);
            this.panel62.Controls.Add(this.laGJGYL_BHDJ);
            this.panel62.Controls.Add(this.panel77);
            this.panel62.Controls.Add(this.laQ_LIN_ZHONG);
            this.panel62.Controls.Add(this.panel76);
            this.panel62.Controls.Add(this.laLIN_ZHONG);
            this.panel62.Controls.Add(this.label122);
            this.panel62.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel62.Location = new System.Drawing.Point(0, 200);
            this.panel62.Name = "panel62";
            this.panel62.Size = new System.Drawing.Size(479, 25);
            this.panel62.TabIndex = 0;
            // 
            // panel98
            // 
            this.panel98.Controls.Add(this.GJGYL_BHDJ);
            this.panel98.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel98.Location = new System.Drawing.Point(388, 0);
            this.panel98.Name = "panel98";
            this.panel98.Padding = new System.Windows.Forms.Padding(2, 4, 4, 0);
            this.panel98.Size = new System.Drawing.Size(70, 24);
            this.panel98.TabIndex = 0;
            // 
            // laGJGYL_BHDJ
            // 
            this.laGJGYL_BHDJ.Dock = System.Windows.Forms.DockStyle.Left;
            this.laGJGYL_BHDJ.Location = new System.Drawing.Point(299, 0);
            this.laGJGYL_BHDJ.Name = "laGJGYL_BHDJ";
            this.laGJGYL_BHDJ.Size = new System.Drawing.Size(89, 24);
            this.laGJGYL_BHDJ.TabIndex = 0;
            this.laGJGYL_BHDJ.Text = "公益林保护等级";
            this.laGJGYL_BHDJ.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel77
            // 
            this.panel77.Controls.Add(this.Q_LIN_ZHONG);
            this.panel77.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel77.Location = new System.Drawing.Point(204, 0);
            this.panel77.Name = "panel77";
            this.panel77.Padding = new System.Windows.Forms.Padding(2, 4, 4, 0);
            this.panel77.Size = new System.Drawing.Size(95, 24);
            this.panel77.TabIndex = 0;
            // 
            // laQ_LIN_ZHONG
            // 
            this.laQ_LIN_ZHONG.Dock = System.Windows.Forms.DockStyle.Left;
            this.laQ_LIN_ZHONG.Location = new System.Drawing.Point(149, 0);
            this.laQ_LIN_ZHONG.Name = "laQ_LIN_ZHONG";
            this.laQ_LIN_ZHONG.Size = new System.Drawing.Size(55, 24);
            this.laQ_LIN_ZHONG.TabIndex = 0;
            this.laQ_LIN_ZHONG.Text = "前期林种";
            this.laQ_LIN_ZHONG.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel76
            // 
            this.panel76.Controls.Add(this.LIN_ZHONG);
            this.panel76.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel76.Location = new System.Drawing.Point(30, 0);
            this.panel76.Name = "panel76";
            this.panel76.Padding = new System.Windows.Forms.Padding(2, 4, 4, 0);
            this.panel76.Size = new System.Drawing.Size(119, 24);
            this.panel76.TabIndex = 0;
            // 
            // laLIN_ZHONG
            // 
            this.laLIN_ZHONG.Dock = System.Windows.Forms.DockStyle.Left;
            this.laLIN_ZHONG.Location = new System.Drawing.Point(0, 0);
            this.laLIN_ZHONG.Name = "laLIN_ZHONG";
            this.laLIN_ZHONG.Size = new System.Drawing.Size(30, 24);
            this.laLIN_ZHONG.TabIndex = 0;
            this.laLIN_ZHONG.Text = "林种";
            this.laLIN_ZHONG.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label122
            // 
            this.label122.BackColor = System.Drawing.Color.Black;
            this.label122.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label122.Location = new System.Drawing.Point(0, 24);
            this.label122.Name = "label122";
            this.label122.Size = new System.Drawing.Size(479, 1);
            this.label122.TabIndex = 0;
            this.label122.Text = "label122";
            this.label122.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.panel14.Location = new System.Drawing.Point(0, 175);
            this.panel14.Name = "panel14";
            this.panel14.Size = new System.Drawing.Size(479, 25);
            this.panel14.TabIndex = 0;
            // 
            // panel38
            // 
            this.panel38.Controls.Add(this.LMSYQ);
            this.panel38.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel38.Location = new System.Drawing.Point(365, 0);
            this.panel38.Name = "panel38";
            this.panel38.Padding = new System.Windows.Forms.Padding(2, 4, 4, 0);
            this.panel38.Size = new System.Drawing.Size(93, 24);
            this.panel38.TabIndex = 0;
            // 
            // laLMSYQ
            // 
            this.laLMSYQ.Dock = System.Windows.Forms.DockStyle.Left;
            this.laLMSYQ.Location = new System.Drawing.Point(299, 0);
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
            this.panel40.Location = new System.Drawing.Point(215, 0);
            this.panel40.Name = "panel40";
            this.panel40.Padding = new System.Windows.Forms.Padding(2, 4, 4, 0);
            this.panel40.Size = new System.Drawing.Size(84, 24);
            this.panel40.TabIndex = 0;
            // 
            // laLMJYQ
            // 
            this.laLMJYQ.Dock = System.Windows.Forms.DockStyle.Left;
            this.laLMJYQ.Location = new System.Drawing.Point(149, 0);
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
            this.panel47.Size = new System.Drawing.Size(83, 24);
            this.panel47.TabIndex = 0;
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
            this.label114.Size = new System.Drawing.Size(479, 1);
            this.label114.TabIndex = 0;
            this.label114.Text = "label114";
            this.label114.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel31
            // 
            this.panel31.Controls.Add(this.panel9);
            this.panel31.Controls.Add(this.laQ_DI_LEI);
            this.panel31.Controls.Add(this.panel26);
            this.panel31.Controls.Add(this.laDI_LEI);
            this.panel31.Controls.Add(this.panel18);
            this.panel31.Controls.Add(this.laMIAN_JI);
            this.panel31.Controls.Add(this.label59);
            this.panel31.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel31.Location = new System.Drawing.Point(0, 150);
            this.panel31.Name = "panel31";
            this.panel31.Size = new System.Drawing.Size(479, 25);
            this.panel31.TabIndex = 0;
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.Q_DI_LEI);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel9.Location = new System.Drawing.Point(354, 0);
            this.panel9.Name = "panel9";
            this.panel9.Padding = new System.Windows.Forms.Padding(2, 4, 4, 0);
            this.panel9.Size = new System.Drawing.Size(104, 24);
            this.panel9.TabIndex = 0;
            // 
            // laQ_DI_LEI
            // 
            this.laQ_DI_LEI.Dock = System.Windows.Forms.DockStyle.Left;
            this.laQ_DI_LEI.Location = new System.Drawing.Point(299, 0);
            this.laQ_DI_LEI.Name = "laQ_DI_LEI";
            this.laQ_DI_LEI.Size = new System.Drawing.Size(55, 24);
            this.laQ_DI_LEI.TabIndex = 0;
            this.laQ_DI_LEI.Text = "前期地类";
            this.laQ_DI_LEI.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel26
            // 
            this.panel26.Controls.Add(this.DI_LEI);
            this.panel26.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel26.Location = new System.Drawing.Point(179, 0);
            this.panel26.Name = "panel26";
            this.panel26.Padding = new System.Windows.Forms.Padding(2, 4, 4, 0);
            this.panel26.Size = new System.Drawing.Size(120, 24);
            this.panel26.TabIndex = 0;
            // 
            // laDI_LEI
            // 
            this.laDI_LEI.Dock = System.Windows.Forms.DockStyle.Left;
            this.laDI_LEI.Location = new System.Drawing.Point(149, 0);
            this.laDI_LEI.Name = "laDI_LEI";
            this.laDI_LEI.Size = new System.Drawing.Size(30, 24);
            this.laDI_LEI.TabIndex = 0;
            this.laDI_LEI.Text = "地类";
            this.laDI_LEI.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel18
            // 
            this.panel18.Controls.Add(this.MIAN_JI);
            this.panel18.Controls.Add(this.label51);
            this.panel18.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel18.Location = new System.Drawing.Point(30, 0);
            this.panel18.Name = "panel18";
            this.panel18.Padding = new System.Windows.Forms.Padding(2, 6, 6, 2);
            this.panel18.Size = new System.Drawing.Size(119, 24);
            this.panel18.TabIndex = 0;
            // 
            // label51
            // 
            this.label51.Dock = System.Windows.Forms.DockStyle.Right;
            this.label51.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label51.ForeColor = System.Drawing.Color.Blue;
            this.label51.Location = new System.Drawing.Point(81, 6);
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
            this.laMIAN_JI.Size = new System.Drawing.Size(30, 24);
            this.laMIAN_JI.TabIndex = 0;
            this.laMIAN_JI.Text = "面积";
            this.laMIAN_JI.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label59
            // 
            this.label59.BackColor = System.Drawing.Color.Black;
            this.label59.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label59.Location = new System.Drawing.Point(0, 24);
            this.label59.Name = "label59";
            this.label59.Size = new System.Drawing.Size(479, 1);
            this.label59.TabIndex = 0;
            this.label59.Text = "label59";
            this.label59.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel145
            // 
            this.panel145.Controls.Add(this.panel85);
            this.panel145.Controls.Add(this.laDW);
            this.panel145.Controls.Add(this.panel146);
            this.panel145.Controls.Add(this.laLMSYZXM);
            this.panel145.Controls.Add(this.label212);
            this.panel145.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel145.Location = new System.Drawing.Point(0, 125);
            this.panel145.Name = "panel145";
            this.panel145.Size = new System.Drawing.Size(479, 25);
            this.panel145.TabIndex = 0;
            // 
            // panel85
            // 
            this.panel85.Controls.Add(this.DW);
            this.panel85.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel85.Location = new System.Drawing.Point(250, 0);
            this.panel85.Name = "panel85";
            this.panel85.Padding = new System.Windows.Forms.Padding(2, 6, 8, 0);
            this.panel85.Size = new System.Drawing.Size(206, 24);
            this.panel85.TabIndex = 0;
            // 
            // DW
            // 
            this.DW.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DW.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DW.EditValue = "";
            this.DW.Location = new System.Drawing.Point(2, 6);
            this.DW.Name = "DW";
            this.DW.Properties.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DW.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.DW.Properties.Appearance.Options.UseFont = true;
            this.DW.Properties.Appearance.Options.UseForeColor = true;
            this.DW.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.DW.Properties.MaxLength = 100;
            this.DW.Size = new System.Drawing.Size(196, 16);
            this.DW.TabIndex = 18;
            this.DW.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // laDW
            // 
            this.laDW.Dock = System.Windows.Forms.DockStyle.Left;
            this.laDW.Location = new System.Drawing.Point(220, 0);
            this.laDW.Name = "laDW";
            this.laDW.Size = new System.Drawing.Size(30, 24);
            this.laDW.TabIndex = 0;
            this.laDW.Text = "单位";
            this.laDW.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel146
            // 
            this.panel146.Controls.Add(this.LMSYZXM);
            this.panel146.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel146.Location = new System.Drawing.Point(91, 0);
            this.panel146.Name = "panel146";
            this.panel146.Padding = new System.Windows.Forms.Padding(2, 6, 8, 0);
            this.panel146.Size = new System.Drawing.Size(129, 24);
            this.panel146.TabIndex = 0;
            // 
            // LMSYZXM
            // 
            this.LMSYZXM.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LMSYZXM.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LMSYZXM.EditValue = "";
            this.LMSYZXM.Location = new System.Drawing.Point(2, 6);
            this.LMSYZXM.Name = "LMSYZXM";
            this.LMSYZXM.Properties.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LMSYZXM.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.LMSYZXM.Properties.Appearance.Options.UseFont = true;
            this.LMSYZXM.Properties.Appearance.Options.UseForeColor = true;
            this.LMSYZXM.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.LMSYZXM.Properties.MaxLength = 20;
            this.LMSYZXM.Size = new System.Drawing.Size(119, 16);
            this.LMSYZXM.TabIndex = 17;
            this.LMSYZXM.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // laLMSYZXM
            // 
            this.laLMSYZXM.Dock = System.Windows.Forms.DockStyle.Left;
            this.laLMSYZXM.Location = new System.Drawing.Point(0, 0);
            this.laLMSYZXM.Name = "laLMSYZXM";
            this.laLMSYZXM.Size = new System.Drawing.Size(91, 24);
            this.laLMSYZXM.TabIndex = 0;
            this.laLMSYZXM.Text = "林木所有者姓名";
            this.laLMSYZXM.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label212
            // 
            this.label212.BackColor = System.Drawing.Color.Black;
            this.label212.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label212.Location = new System.Drawing.Point(0, 24);
            this.label212.Name = "label212";
            this.label212.Size = new System.Drawing.Size(479, 1);
            this.label212.TabIndex = 0;
            this.label212.Text = "label212";
            this.label212.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel138
            // 
            this.panel138.Controls.Add(this.panel22);
            this.panel138.Controls.Add(this.laNORTH);
            this.panel138.Controls.Add(this.panel84);
            this.panel138.Controls.Add(this.laSOUTH);
            this.panel138.Controls.Add(this.label208);
            this.panel138.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel138.Location = new System.Drawing.Point(0, 100);
            this.panel138.Name = "panel138";
            this.panel138.Size = new System.Drawing.Size(479, 25);
            this.panel138.TabIndex = 0;
            // 
            // panel22
            // 
            this.panel22.Controls.Add(this.NORTH);
            this.panel22.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel22.Location = new System.Drawing.Point(250, 0);
            this.panel22.Name = "panel22";
            this.panel22.Padding = new System.Windows.Forms.Padding(2, 6, 8, 0);
            this.panel22.Size = new System.Drawing.Size(206, 24);
            this.panel22.TabIndex = 0;
            // 
            // NORTH
            // 
            this.NORTH.Cursor = System.Windows.Forms.Cursors.Hand;
            this.NORTH.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NORTH.EditValue = "";
            this.NORTH.Location = new System.Drawing.Point(2, 6);
            this.NORTH.Name = "NORTH";
            this.NORTH.Properties.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.NORTH.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.NORTH.Properties.Appearance.Options.UseFont = true;
            this.NORTH.Properties.Appearance.Options.UseForeColor = true;
            this.NORTH.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.NORTH.Properties.MaxLength = 30;
            this.NORTH.Size = new System.Drawing.Size(196, 16);
            this.NORTH.TabIndex = 16;
            this.NORTH.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // laNORTH
            // 
            this.laNORTH.Dock = System.Windows.Forms.DockStyle.Left;
            this.laNORTH.Location = new System.Drawing.Point(220, 0);
            this.laNORTH.Name = "laNORTH";
            this.laNORTH.Size = new System.Drawing.Size(30, 24);
            this.laNORTH.TabIndex = 0;
            this.laNORTH.Text = "北至";
            this.laNORTH.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel84
            // 
            this.panel84.Controls.Add(this.SOUTH);
            this.panel84.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel84.Location = new System.Drawing.Point(30, 0);
            this.panel84.Name = "panel84";
            this.panel84.Padding = new System.Windows.Forms.Padding(2, 6, 8, 0);
            this.panel84.Size = new System.Drawing.Size(190, 24);
            this.panel84.TabIndex = 0;
            // 
            // SOUTH
            // 
            this.SOUTH.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SOUTH.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SOUTH.EditValue = "";
            this.SOUTH.Location = new System.Drawing.Point(2, 6);
            this.SOUTH.Name = "SOUTH";
            this.SOUTH.Properties.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.SOUTH.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.SOUTH.Properties.Appearance.Options.UseFont = true;
            this.SOUTH.Properties.Appearance.Options.UseForeColor = true;
            this.SOUTH.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.SOUTH.Properties.MaxLength = 30;
            this.SOUTH.Size = new System.Drawing.Size(180, 16);
            this.SOUTH.TabIndex = 15;
            this.SOUTH.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // laSOUTH
            // 
            this.laSOUTH.Dock = System.Windows.Forms.DockStyle.Left;
            this.laSOUTH.Location = new System.Drawing.Point(0, 0);
            this.laSOUTH.Name = "laSOUTH";
            this.laSOUTH.Size = new System.Drawing.Size(30, 24);
            this.laSOUTH.TabIndex = 0;
            this.laSOUTH.Text = "南至";
            this.laSOUTH.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label208
            // 
            this.label208.BackColor = System.Drawing.Color.Black;
            this.label208.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label208.Location = new System.Drawing.Point(0, 24);
            this.label208.Name = "label208";
            this.label208.Size = new System.Drawing.Size(479, 1);
            this.label208.TabIndex = 0;
            this.label208.Text = "label208";
            this.label208.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel16
            // 
            this.panel16.Controls.Add(this.panel78);
            this.panel16.Controls.Add(this.laWEST);
            this.panel16.Controls.Add(this.panel75);
            this.panel16.Controls.Add(this.laEAST);
            this.panel16.Controls.Add(this.label42);
            this.panel16.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel16.Location = new System.Drawing.Point(0, 75);
            this.panel16.Name = "panel16";
            this.panel16.Size = new System.Drawing.Size(479, 25);
            this.panel16.TabIndex = 0;
            // 
            // panel78
            // 
            this.panel78.Controls.Add(this.WEST);
            this.panel78.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel78.Location = new System.Drawing.Point(250, 0);
            this.panel78.Name = "panel78";
            this.panel78.Padding = new System.Windows.Forms.Padding(2, 6, 8, 0);
            this.panel78.Size = new System.Drawing.Size(206, 24);
            this.panel78.TabIndex = 0;
            // 
            // WEST
            // 
            this.WEST.Cursor = System.Windows.Forms.Cursors.Hand;
            this.WEST.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WEST.EditValue = "";
            this.WEST.Location = new System.Drawing.Point(2, 6);
            this.WEST.Name = "WEST";
            this.WEST.Properties.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.WEST.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.WEST.Properties.Appearance.Options.UseFont = true;
            this.WEST.Properties.Appearance.Options.UseForeColor = true;
            this.WEST.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.WEST.Properties.MaxLength = 30;
            this.WEST.Size = new System.Drawing.Size(196, 16);
            this.WEST.TabIndex = 14;
            this.WEST.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // laWEST
            // 
            this.laWEST.Dock = System.Windows.Forms.DockStyle.Left;
            this.laWEST.Location = new System.Drawing.Point(220, 0);
            this.laWEST.Name = "laWEST";
            this.laWEST.Size = new System.Drawing.Size(30, 24);
            this.laWEST.TabIndex = 0;
            this.laWEST.Text = "西至";
            this.laWEST.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel75
            // 
            this.panel75.Controls.Add(this.EAST);
            this.panel75.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel75.Location = new System.Drawing.Point(30, 0);
            this.panel75.Name = "panel75";
            this.panel75.Padding = new System.Windows.Forms.Padding(2, 6, 8, 0);
            this.panel75.Size = new System.Drawing.Size(190, 24);
            this.panel75.TabIndex = 0;
            // 
            // EAST
            // 
            this.EAST.Cursor = System.Windows.Forms.Cursors.Hand;
            this.EAST.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EAST.EditValue = "";
            this.EAST.Location = new System.Drawing.Point(2, 6);
            this.EAST.Name = "EAST";
            this.EAST.Properties.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.EAST.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.EAST.Properties.Appearance.Options.UseFont = true;
            this.EAST.Properties.Appearance.Options.UseForeColor = true;
            this.EAST.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.EAST.Properties.MaxLength = 30;
            this.EAST.Size = new System.Drawing.Size(180, 16);
            this.EAST.TabIndex = 13;
            this.EAST.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // laEAST
            // 
            this.laEAST.Dock = System.Windows.Forms.DockStyle.Left;
            this.laEAST.Location = new System.Drawing.Point(0, 0);
            this.laEAST.Name = "laEAST";
            this.laEAST.Size = new System.Drawing.Size(30, 24);
            this.laEAST.TabIndex = 0;
            this.laEAST.Text = "东至";
            this.laEAST.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label42
            // 
            this.label42.BackColor = System.Drawing.Color.Black;
            this.label42.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label42.Location = new System.Drawing.Point(0, 24);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(479, 1);
            this.label42.TabIndex = 0;
            this.label42.Text = "label42";
            this.label42.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel120
            // 
            this.panel120.Controls.Add(this.panel144);
            this.panel120.Controls.Add(this.laXIAODM);
            this.panel120.Controls.Add(this.label186);
            this.panel120.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel120.Location = new System.Drawing.Point(0, 50);
            this.panel120.Name = "panel120";
            this.panel120.Size = new System.Drawing.Size(479, 25);
            this.panel120.TabIndex = 0;
            // 
            // panel144
            // 
            this.panel144.Controls.Add(this.XIAODM);
            this.panel144.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel144.Location = new System.Drawing.Point(42, 0);
            this.panel144.Name = "panel144";
            this.panel144.Padding = new System.Windows.Forms.Padding(2, 6, 8, 0);
            this.panel144.Size = new System.Drawing.Size(415, 24);
            this.panel144.TabIndex = 0;
            // 
            // XIAODM
            // 
            this.XIAODM.Cursor = System.Windows.Forms.Cursors.Hand;
            this.XIAODM.Dock = System.Windows.Forms.DockStyle.Fill;
            this.XIAODM.EditValue = "";
            this.XIAODM.Location = new System.Drawing.Point(2, 6);
            this.XIAODM.Name = "XIAODM";
            this.XIAODM.Properties.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.XIAODM.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.XIAODM.Properties.Appearance.Options.UseFont = true;
            this.XIAODM.Properties.Appearance.Options.UseForeColor = true;
            this.XIAODM.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.XIAODM.Properties.MaxLength = 50;
            this.XIAODM.Size = new System.Drawing.Size(405, 16);
            this.XIAODM.TabIndex = 12;
            this.XIAODM.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // laXIAODM
            // 
            this.laXIAODM.Dock = System.Windows.Forms.DockStyle.Left;
            this.laXIAODM.Location = new System.Drawing.Point(0, 0);
            this.laXIAODM.Name = "laXIAODM";
            this.laXIAODM.Size = new System.Drawing.Size(42, 24);
            this.laXIAODM.TabIndex = 0;
            this.laXIAODM.Text = "小地名";
            this.laXIAODM.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label186
            // 
            this.label186.BackColor = System.Drawing.Color.Black;
            this.label186.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label186.Location = new System.Drawing.Point(0, 24);
            this.label186.Name = "label186";
            this.label186.Size = new System.Drawing.Size(479, 1);
            this.label186.TabIndex = 0;
            this.label186.Text = "label186";
            this.label186.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.panel121);
            this.panel7.Controls.Add(this.laXI_BAN);
            this.panel7.Controls.Add(this.panel122);
            this.panel7.Controls.Add(this.laXIAO_BAN);
            this.panel7.Controls.Add(this.panel6);
            this.panel7.Controls.Add(this.laLIN_BAN);
            this.panel7.Controls.Add(this.panel10);
            this.panel7.Controls.Add(this.laCUN);
            this.panel7.Controls.Add(this.label10);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel7.Location = new System.Drawing.Point(0, 25);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(479, 25);
            this.panel7.TabIndex = 0;
            // 
            // panel121
            // 
            this.panel121.Controls.Add(this.XI_BAN);
            this.panel121.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel121.Location = new System.Drawing.Point(395, 0);
            this.panel121.Name = "panel121";
            this.panel121.Padding = new System.Windows.Forms.Padding(2, 6, 8, 0);
            this.panel121.Size = new System.Drawing.Size(62, 24);
            this.panel121.TabIndex = 0;
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
            this.XI_BAN.Size = new System.Drawing.Size(52, 16);
            this.XI_BAN.TabIndex = 11;
            this.XI_BAN.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // laXI_BAN
            // 
            this.laXI_BAN.Dock = System.Windows.Forms.DockStyle.Left;
            this.laXI_BAN.Location = new System.Drawing.Point(305, 0);
            this.laXI_BAN.Name = "laXI_BAN";
            this.laXI_BAN.Size = new System.Drawing.Size(90, 24);
            this.laXI_BAN.TabIndex = 0;
            this.laXI_BAN.Text = "作业小班(细班)";
            this.laXI_BAN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel122
            // 
            this.panel122.Controls.Add(this.XIAO_BAN);
            this.panel122.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel122.Location = new System.Drawing.Point(250, 0);
            this.panel122.Name = "panel122";
            this.panel122.Padding = new System.Windows.Forms.Padding(2, 6, 8, 0);
            this.panel122.Size = new System.Drawing.Size(55, 24);
            this.panel122.TabIndex = 0;
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
            this.XIAO_BAN.Size = new System.Drawing.Size(45, 16);
            this.XIAO_BAN.TabIndex = 10;
            this.XIAO_BAN.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // laXIAO_BAN
            // 
            this.laXIAO_BAN.Dock = System.Windows.Forms.DockStyle.Left;
            this.laXIAO_BAN.Location = new System.Drawing.Point(195, 0);
            this.laXIAO_BAN.Name = "laXIAO_BAN";
            this.laXIAO_BAN.Size = new System.Drawing.Size(55, 24);
            this.laXIAO_BAN.TabIndex = 0;
            this.laXIAO_BAN.Text = "调查小班";
            this.laXIAO_BAN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.LIN_BAN);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel6.Location = new System.Drawing.Point(140, 0);
            this.panel6.Name = "panel6";
            this.panel6.Padding = new System.Windows.Forms.Padding(2, 6, 8, 0);
            this.panel6.Size = new System.Drawing.Size(55, 24);
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
            this.LIN_BAN.Size = new System.Drawing.Size(45, 16);
            this.LIN_BAN.TabIndex = 9;
            this.LIN_BAN.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // laLIN_BAN
            // 
            this.laLIN_BAN.Dock = System.Windows.Forms.DockStyle.Left;
            this.laLIN_BAN.Location = new System.Drawing.Point(110, 0);
            this.laLIN_BAN.Name = "laLIN_BAN";
            this.laLIN_BAN.Size = new System.Drawing.Size(30, 24);
            this.laLIN_BAN.TabIndex = 0;
            this.laLIN_BAN.Text = "林班";
            this.laLIN_BAN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel10
            // 
            this.panel10.Controls.Add(this.CUN);
            this.panel10.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel10.Location = new System.Drawing.Point(20, 0);
            this.panel10.Name = "panel10";
            this.panel10.Padding = new System.Windows.Forms.Padding(2, 4, 4, 0);
            this.panel10.Size = new System.Drawing.Size(90, 24);
            this.panel10.TabIndex = 0;
            // 
            // laCUN
            // 
            this.laCUN.Dock = System.Windows.Forms.DockStyle.Left;
            this.laCUN.Location = new System.Drawing.Point(0, 0);
            this.laCUN.Name = "laCUN";
            this.laCUN.Size = new System.Drawing.Size(20, 24);
            this.laCUN.TabIndex = 0;
            this.laCUN.Text = "村";
            this.laCUN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.Black;
            this.label10.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label10.Location = new System.Drawing.Point(0, 24);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(479, 1);
            this.label10.TabIndex = 0;
            this.label10.Text = "label10";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel11);
            this.panel2.Controls.Add(this.laXIANG);
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
            this.panel2.Size = new System.Drawing.Size(479, 25);
            this.panel2.TabIndex = 0;
            // 
            // panel11
            // 
            this.panel11.Controls.Add(this.XIANG);
            this.panel11.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel11.Location = new System.Drawing.Point(370, 0);
            this.panel11.Name = "panel11";
            this.panel11.Padding = new System.Windows.Forms.Padding(2, 4, 4, 0);
            this.panel11.Size = new System.Drawing.Size(87, 24);
            this.panel11.TabIndex = 0;
            // 
            // laXIANG
            // 
            this.laXIANG.Dock = System.Windows.Forms.DockStyle.Left;
            this.laXIANG.Location = new System.Drawing.Point(340, 0);
            this.laXIANG.Name = "laXIANG";
            this.laXIANG.Size = new System.Drawing.Size(30, 24);
            this.laXIANG.TabIndex = 0;
            this.laXIANG.Text = "乡镇";
            this.laXIANG.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.XIAN);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel5.Location = new System.Drawing.Point(250, 0);
            this.panel5.Name = "panel5";
            this.panel5.Padding = new System.Windows.Forms.Padding(2, 4, 4, 0);
            this.panel5.Size = new System.Drawing.Size(90, 24);
            this.panel5.TabIndex = 0;
            this.panel5.TabStop = true;
            // 
            // laXIAN
            // 
            this.laXIAN.Dock = System.Windows.Forms.DockStyle.Left;
            this.laXIAN.Location = new System.Drawing.Point(220, 0);
            this.laXIAN.Name = "laXIAN";
            this.laXIAN.Size = new System.Drawing.Size(30, 24);
            this.laXIAN.TabIndex = 0;
            this.laXIAN.Text = "区县";
            this.laXIAN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.SHI);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel4.Location = new System.Drawing.Point(130, 0);
            this.panel4.Name = "panel4";
            this.panel4.Padding = new System.Windows.Forms.Padding(2, 4, 4, 0);
            this.panel4.Size = new System.Drawing.Size(90, 24);
            this.panel4.TabIndex = 0;
            // 
            // laSHI
            // 
            this.laSHI.Dock = System.Windows.Forms.DockStyle.Left;
            this.laSHI.Location = new System.Drawing.Point(110, 0);
            this.laSHI.Name = "laSHI";
            this.laSHI.Size = new System.Drawing.Size(20, 24);
            this.laSHI.TabIndex = 0;
            this.laSHI.Text = "市";
            this.laSHI.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.SHENG);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(20, 0);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(2, 4, 4, 0);
            this.panel3.Size = new System.Drawing.Size(90, 24);
            this.panel3.TabIndex = 0;
            // 
            // laSHENG
            // 
            this.laSHENG.Dock = System.Windows.Forms.DockStyle.Left;
            this.laSHENG.Location = new System.Drawing.Point(0, 0);
            this.laSHENG.Name = "laSHENG";
            this.laSHENG.Size = new System.Drawing.Size(20, 24);
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
            this.label2.Size = new System.Drawing.Size(479, 1);
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
            this.label35.Size = new System.Drawing.Size(476, 1);
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
            this.label36.Size = new System.Drawing.Size(1, 401);
            this.label36.TabIndex = 0;
            this.label36.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label37
            // 
            this.label37.BackColor = System.Drawing.Color.Black;
            this.label37.Dock = System.Windows.Forms.DockStyle.Right;
            this.label37.Location = new System.Drawing.Point(477, 0);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(1, 401);
            this.label37.TabIndex = 0;
            this.label37.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelHarvest
            // 
            this.panelHarvest.Controls.Add(this.panel36);
            this.panelHarvest.Controls.Add(this.label164);
            this.panelHarvest.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHarvest.Location = new System.Drawing.Point(0, 527);
            this.panelHarvest.Name = "panelHarvest";
            this.panelHarvest.Size = new System.Drawing.Size(479, 101);
            this.panelHarvest.TabIndex = 0;
            // 
            // panel36
            // 
            this.panel36.Controls.Add(this.panel13);
            this.panel36.Controls.Add(this.panel71);
            this.panel36.Controls.Add(this.panel15);
            this.panel36.Controls.Add(this.panel50);
            this.panel36.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel36.Location = new System.Drawing.Point(0, 1);
            this.panel36.Name = "panel36";
            this.panel36.Size = new System.Drawing.Size(479, 100);
            this.panel36.TabIndex = 0;
            // 
            // panel13
            // 
            this.panel13.Controls.Add(this.panel101);
            this.panel13.Controls.Add(this.laJCFS);
            this.panel13.Controls.Add(this.panel49);
            this.panel13.Controls.Add(this.laFMFF);
            this.panel13.Controls.Add(this.panel39);
            this.panel13.Controls.Add(this.laCFSJ);
            this.panel13.Controls.Add(this.label24);
            this.panel13.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel13.Location = new System.Drawing.Point(0, 75);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(479, 25);
            this.panel13.TabIndex = 0;
            // 
            // panel101
            // 
            this.panel101.Controls.Add(this.JCFS);
            this.panel101.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel101.Location = new System.Drawing.Point(357, 0);
            this.panel101.Name = "panel101";
            this.panel101.Padding = new System.Windows.Forms.Padding(2, 4, 4, 0);
            this.panel101.Size = new System.Drawing.Size(96, 24);
            this.panel101.TabIndex = 0;
            // 
            // laJCFS
            // 
            this.laJCFS.Dock = System.Windows.Forms.DockStyle.Left;
            this.laJCFS.Location = new System.Drawing.Point(302, 0);
            this.laJCFS.Name = "laJCFS";
            this.laJCFS.Size = new System.Drawing.Size(55, 24);
            this.laJCFS.TabIndex = 0;
            this.laJCFS.Text = "集材方式";
            this.laJCFS.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel49
            // 
            this.panel49.Controls.Add(this.FMFF);
            this.panel49.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel49.Location = new System.Drawing.Point(206, 0);
            this.panel49.Name = "panel49";
            this.panel49.Padding = new System.Windows.Forms.Padding(2, 6, 8, 0);
            this.panel49.Size = new System.Drawing.Size(96, 24);
            this.panel49.TabIndex = 0;
            // 
            // FMFF
            // 
            this.FMFF.Cursor = System.Windows.Forms.Cursors.Hand;
            this.FMFF.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FMFF.EditValue = "";
            this.FMFF.Location = new System.Drawing.Point(2, 6);
            this.FMFF.Name = "FMFF";
            this.FMFF.Properties.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FMFF.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.FMFF.Properties.Appearance.Options.UseFont = true;
            this.FMFF.Properties.Appearance.Options.UseForeColor = true;
            this.FMFF.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.FMFF.Properties.MaxLength = 100;
            this.FMFF.Size = new System.Drawing.Size(86, 16);
            this.FMFF.TabIndex = 60;
            this.FMFF.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // laFMFF
            // 
            this.laFMFF.Dock = System.Windows.Forms.DockStyle.Left;
            this.laFMFF.Location = new System.Drawing.Point(151, 0);
            this.laFMFF.Name = "laFMFF";
            this.laFMFF.Size = new System.Drawing.Size(55, 24);
            this.laFMFF.TabIndex = 0;
            this.laFMFF.Text = "伐木方法";
            this.laFMFF.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel39
            // 
            this.panel39.Controls.Add(this.CFSJ);
            this.panel39.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel39.Location = new System.Drawing.Point(55, 0);
            this.panel39.Name = "panel39";
            this.panel39.Padding = new System.Windows.Forms.Padding(2, 1, 8, 3);
            this.panel39.Size = new System.Drawing.Size(96, 24);
            this.panel39.TabIndex = 0;
            // 
            // CFSJ
            // 
            this.CFSJ.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.CFSJ.EditValue = null;
            this.CFSJ.Location = new System.Drawing.Point(2, 3);
            this.CFSJ.Name = "CFSJ";
            this.CFSJ.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.CFSJ.Properties.Appearance.Options.UseForeColor = true;
            this.CFSJ.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.CFSJ.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.CFSJ.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.CFSJ.Size = new System.Drawing.Size(86, 18);
            this.CFSJ.TabIndex = 59;
            this.CFSJ.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // laCFSJ
            // 
            this.laCFSJ.Dock = System.Windows.Forms.DockStyle.Left;
            this.laCFSJ.Location = new System.Drawing.Point(0, 0);
            this.laCFSJ.Name = "laCFSJ";
            this.laCFSJ.Size = new System.Drawing.Size(55, 24);
            this.laCFSJ.TabIndex = 0;
            this.laCFSJ.Text = "采伐时间";
            this.laCFSJ.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label24
            // 
            this.label24.BackColor = System.Drawing.Color.Black;
            this.label24.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label24.Location = new System.Drawing.Point(0, 24);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(479, 1);
            this.label24.TabIndex = 0;
            this.label24.Text = "label24";
            this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel71
            // 
            this.panel71.Controls.Add(this.panel74);
            this.panel71.Controls.Add(this.laBLMYBD);
            this.panel71.Controls.Add(this.label85);
            this.panel71.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel71.Location = new System.Drawing.Point(0, 50);
            this.panel71.Name = "panel71";
            this.panel71.Size = new System.Drawing.Size(479, 25);
            this.panel71.TabIndex = 0;
            // 
            // panel74
            // 
            this.panel74.Controls.Add(this.BLMYBD);
            this.panel74.Controls.Add(this.label84);
            this.panel74.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel74.Location = new System.Drawing.Point(102, 0);
            this.panel74.Name = "panel74";
            this.panel74.Padding = new System.Windows.Forms.Padding(2, 6, 6, 2);
            this.panel74.Size = new System.Drawing.Size(84, 24);
            this.panel74.TabIndex = 0;
            // 
            // label84
            // 
            this.label84.Dock = System.Windows.Forms.DockStyle.Right;
            this.label84.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label84.ForeColor = System.Drawing.Color.Blue;
            this.label84.Location = new System.Drawing.Point(73, 6);
            this.label84.Name = "label84";
            this.label84.Size = new System.Drawing.Size(5, 16);
            this.label84.TabIndex = 0;
            // 
            // laBLMYBD
            // 
            this.laBLMYBD.Dock = System.Windows.Forms.DockStyle.Left;
            this.laBLMYBD.Location = new System.Drawing.Point(0, 0);
            this.laBLMYBD.Name = "laBLMYBD";
            this.laBLMYBD.Size = new System.Drawing.Size(102, 24);
            this.laBLMYBD.TabIndex = 0;
            this.laBLMYBD.Text = "伐后保留木郁闭度";
            this.laBLMYBD.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label85
            // 
            this.label85.BackColor = System.Drawing.Color.Black;
            this.label85.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label85.Location = new System.Drawing.Point(0, 24);
            this.label85.Name = "label85";
            this.label85.Size = new System.Drawing.Size(479, 1);
            this.label85.TabIndex = 0;
            this.label85.Text = "label85";
            this.label85.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel15
            // 
            this.panel15.Controls.Add(this.panel60);
            this.panel15.Controls.Add(this.laSFCF);
            this.panel15.Controls.Add(this.panel103);
            this.panel15.Controls.Add(this.laCFQD);
            this.panel15.Controls.Add(this.panel48);
            this.panel15.Controls.Add(this.laCFMJ);
            this.panel15.Controls.Add(this.label74);
            this.panel15.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel15.Location = new System.Drawing.Point(0, 25);
            this.panel15.Name = "panel15";
            this.panel15.Padding = new System.Windows.Forms.Padding(0, 0, 1, 0);
            this.panel15.Size = new System.Drawing.Size(479, 25);
            this.panel15.TabIndex = 0;
            // 
            // panel60
            // 
            this.panel60.Controls.Add(this.SFCF);
            this.panel60.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel60.Location = new System.Drawing.Point(357, 0);
            this.panel60.Name = "panel60";
            this.panel60.Padding = new System.Windows.Forms.Padding(2, 4, 4, 0);
            this.panel60.Size = new System.Drawing.Size(60, 24);
            this.panel60.TabIndex = 0;
            // 
            // laSFCF
            // 
            this.laSFCF.Dock = System.Windows.Forms.DockStyle.Left;
            this.laSFCF.Location = new System.Drawing.Point(302, 0);
            this.laSFCF.Name = "laSFCF";
            this.laSFCF.Size = new System.Drawing.Size(55, 24);
            this.laSFCF.TabIndex = 0;
            this.laSFCF.Text = "是否采伐";
            this.laSFCF.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel103
            // 
            this.panel103.Controls.Add(this.CFQD);
            this.panel103.Controls.Add(this.label32);
            this.panel103.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel103.Location = new System.Drawing.Point(206, 0);
            this.panel103.Name = "panel103";
            this.panel103.Padding = new System.Windows.Forms.Padding(2, 6, 6, 2);
            this.panel103.Size = new System.Drawing.Size(96, 24);
            this.panel103.TabIndex = 0;
            // 
            // label32
            // 
            this.label32.Dock = System.Windows.Forms.DockStyle.Right;
            this.label32.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label32.ForeColor = System.Drawing.Color.Blue;
            this.label32.Location = new System.Drawing.Point(70, 6);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(20, 16);
            this.label32.TabIndex = 0;
            this.label32.Text = "%";
            // 
            // laCFQD
            // 
            this.laCFQD.Dock = System.Windows.Forms.DockStyle.Left;
            this.laCFQD.Location = new System.Drawing.Point(151, 0);
            this.laCFQD.Name = "laCFQD";
            this.laCFQD.Size = new System.Drawing.Size(55, 24);
            this.laCFQD.TabIndex = 0;
            this.laCFQD.Text = "采伐强度";
            this.laCFQD.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel48
            // 
            this.panel48.Controls.Add(this.CFMJ);
            this.panel48.Controls.Add(this.label28);
            this.panel48.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel48.Location = new System.Drawing.Point(55, 0);
            this.panel48.Name = "panel48";
            this.panel48.Padding = new System.Windows.Forms.Padding(2, 6, 6, 2);
            this.panel48.Size = new System.Drawing.Size(96, 24);
            this.panel48.TabIndex = 0;
            // 
            // label28
            // 
            this.label28.Dock = System.Windows.Forms.DockStyle.Right;
            this.label28.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label28.ForeColor = System.Drawing.Color.Blue;
            this.label28.Location = new System.Drawing.Point(58, 6);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(32, 16);
            this.label28.TabIndex = 0;
            this.label28.Text = "公顷";
            // 
            // laCFMJ
            // 
            this.laCFMJ.Dock = System.Windows.Forms.DockStyle.Left;
            this.laCFMJ.Location = new System.Drawing.Point(0, 0);
            this.laCFMJ.Name = "laCFMJ";
            this.laCFMJ.Size = new System.Drawing.Size(55, 24);
            this.laCFMJ.TabIndex = 0;
            this.laCFMJ.Text = "采伐面积";
            this.laCFMJ.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label74
            // 
            this.label74.BackColor = System.Drawing.Color.Black;
            this.label74.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label74.Location = new System.Drawing.Point(0, 24);
            this.label74.Name = "label74";
            this.label74.Size = new System.Drawing.Size(478, 1);
            this.label74.TabIndex = 0;
            this.label74.Text = "label74";
            this.label74.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel50
            // 
            this.panel50.Controls.Add(this.panel102);
            this.panel50.Controls.Add(this.laCFFS);
            this.panel50.Controls.Add(this.panel45);
            this.panel50.Controls.Add(this.laCFCS);
            this.panel50.Controls.Add(this.panel52);
            this.panel50.Controls.Add(this.laCFLX);
            this.panel50.Controls.Add(this.label88);
            this.panel50.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel50.Location = new System.Drawing.Point(0, 0);
            this.panel50.Name = "panel50";
            this.panel50.Size = new System.Drawing.Size(479, 25);
            this.panel50.TabIndex = 0;
            // 
            // panel102
            // 
            this.panel102.Controls.Add(this.CFFS);
            this.panel102.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel102.Location = new System.Drawing.Point(357, 0);
            this.panel102.Name = "panel102";
            this.panel102.Padding = new System.Windows.Forms.Padding(2, 4, 4, 0);
            this.panel102.Size = new System.Drawing.Size(96, 24);
            this.panel102.TabIndex = 0;
            // 
            // laCFFS
            // 
            this.laCFFS.Dock = System.Windows.Forms.DockStyle.Left;
            this.laCFFS.Location = new System.Drawing.Point(302, 0);
            this.laCFFS.Name = "laCFFS";
            this.laCFFS.Size = new System.Drawing.Size(55, 24);
            this.laCFFS.TabIndex = 0;
            this.laCFFS.Text = "采伐方式";
            this.laCFFS.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel45
            // 
            this.panel45.Controls.Add(this.CFCS);
            this.panel45.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel45.Location = new System.Drawing.Point(206, 0);
            this.panel45.Name = "panel45";
            this.panel45.Padding = new System.Windows.Forms.Padding(2, 2, 6, 2);
            this.panel45.Size = new System.Drawing.Size(96, 24);
            this.panel45.TabIndex = 0;
            // 
            // laCFCS
            // 
            this.laCFCS.Dock = System.Windows.Forms.DockStyle.Left;
            this.laCFCS.Location = new System.Drawing.Point(151, 0);
            this.laCFCS.Name = "laCFCS";
            this.laCFCS.Size = new System.Drawing.Size(55, 24);
            this.laCFCS.TabIndex = 0;
            this.laCFCS.Text = "采伐次数";
            this.laCFCS.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel52
            // 
            this.panel52.Controls.Add(this.CFLX);
            this.panel52.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel52.Location = new System.Drawing.Point(55, 0);
            this.panel52.Name = "panel52";
            this.panel52.Padding = new System.Windows.Forms.Padding(2, 4, 4, 0);
            this.panel52.Size = new System.Drawing.Size(96, 24);
            this.panel52.TabIndex = 0;
            // 
            // laCFLX
            // 
            this.laCFLX.Dock = System.Windows.Forms.DockStyle.Left;
            this.laCFLX.Location = new System.Drawing.Point(0, 0);
            this.laCFLX.Name = "laCFLX";
            this.laCFLX.Size = new System.Drawing.Size(55, 24);
            this.laCFLX.TabIndex = 0;
            this.laCFLX.Text = "采伐类型";
            this.laCFLX.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label88
            // 
            this.label88.BackColor = System.Drawing.Color.Black;
            this.label88.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label88.Location = new System.Drawing.Point(0, 24);
            this.label88.Name = "label88";
            this.label88.Size = new System.Drawing.Size(479, 1);
            this.label88.TabIndex = 0;
            this.label88.Text = "label88";
            this.label88.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label164
            // 
            this.label164.BackColor = System.Drawing.Color.Black;
            this.label164.Dock = System.Windows.Forms.DockStyle.Top;
            this.label164.Location = new System.Drawing.Point(0, 0);
            this.label164.Name = "label164";
            this.label164.Size = new System.Drawing.Size(479, 1);
            this.label164.TabIndex = 0;
            this.label164.Text = "label164";
            this.label164.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label90
            // 
            this.label90.BackColor = System.Drawing.Color.Black;
            this.label90.Dock = System.Windows.Forms.DockStyle.Top;
            this.label90.Location = new System.Drawing.Point(1, 0);
            this.label90.Name = "label90";
            this.label90.Size = new System.Drawing.Size(476, 1);
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
            this.label91.Size = new System.Drawing.Size(1, 136);
            this.label91.TabIndex = 0;
            this.label91.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label92
            // 
            this.label92.BackColor = System.Drawing.Color.Black;
            this.label92.Dock = System.Windows.Forms.DockStyle.Right;
            this.label92.Location = new System.Drawing.Point(477, 0);
            this.label92.Name = "label92";
            this.label92.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.label92.Size = new System.Drawing.Size(1, 136);
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
            this.label103.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label103.Location = new System.Drawing.Point(0, 628);
            this.label103.Name = "label103";
            this.label103.Size = new System.Drawing.Size(479, 26);
            this.label103.TabIndex = 0;
            this.label103.Text = "更新造林设计";
            this.label103.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelUpdate
            // 
            this.panelUpdate.Controls.Add(this.panel108);
            this.panelUpdate.Controls.Add(this.label175);
            this.panelUpdate.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelUpdate.Location = new System.Drawing.Point(0, 654);
            this.panelUpdate.Name = "panelUpdate";
            this.panelUpdate.Size = new System.Drawing.Size(479, 180);
            this.panelUpdate.TabIndex = 0;
            // 
            // panel108
            // 
            this.panel108.Controls.Add(this.panel81);
            this.panel108.Controls.Add(this.panel118);
            this.panel108.Controls.Add(this.panel94);
            this.panel108.Controls.Add(this.panel28);
            this.panel108.Controls.Add(this.panel72);
            this.panel108.Controls.Add(this.panel88);
            this.panel108.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel108.Location = new System.Drawing.Point(0, 1);
            this.panel108.Name = "panel108";
            this.panel108.Size = new System.Drawing.Size(479, 179);
            this.panel108.TabIndex = 0;
            // 
            // panel81
            // 
            this.panel81.Controls.Add(this.QTSM);
            this.panel81.Controls.Add(this.laQTSM);
            this.panel81.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel81.Location = new System.Drawing.Point(0, 125);
            this.panel81.Name = "panel81";
            this.panel81.Padding = new System.Windows.Forms.Padding(0, 10, 5, 5);
            this.panel81.Size = new System.Drawing.Size(479, 55);
            this.panel81.TabIndex = 0;
            // 
            // QTSM
            // 
            this.QTSM.Dock = System.Windows.Forms.DockStyle.Fill;
            this.QTSM.Location = new System.Drawing.Point(55, 10);
            this.QTSM.Name = "QTSM";
            this.QTSM.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.QTSM.Properties.Appearance.Options.UseForeColor = true;
            this.QTSM.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.QTSM.Size = new System.Drawing.Size(419, 40);
            this.QTSM.TabIndex = 75;
            this.QTSM.UseOptimizedRendering = true;
            this.QTSM.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // laQTSM
            // 
            this.laQTSM.Dock = System.Windows.Forms.DockStyle.Left;
            this.laQTSM.Location = new System.Drawing.Point(0, 10);
            this.laQTSM.Name = "laQTSM";
            this.laQTSM.Size = new System.Drawing.Size(55, 40);
            this.laQTSM.TabIndex = 0;
            this.laQTSM.Text = "其他说明";
            this.laQTSM.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel118
            // 
            this.panel118.Controls.Add(this.panel115);
            this.panel118.Controls.Add(this.laGXZRR);
            this.panel118.Controls.Add(this.panel12);
            this.panel118.Controls.Add(this.laGXDJ);
            this.panel118.Controls.Add(this.label131);
            this.panel118.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel118.Location = new System.Drawing.Point(0, 100);
            this.panel118.Name = "panel118";
            this.panel118.Size = new System.Drawing.Size(479, 25);
            this.panel118.TabIndex = 0;
            // 
            // panel115
            // 
            this.panel115.Controls.Add(this.GXZRR);
            this.panel115.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel115.Location = new System.Drawing.Point(217, 0);
            this.panel115.Name = "panel115";
            this.panel115.Padding = new System.Windows.Forms.Padding(2, 6, 8, 0);
            this.panel115.Size = new System.Drawing.Size(180, 24);
            this.panel115.TabIndex = 0;
            // 
            // GXZRR
            // 
            this.GXZRR.Cursor = System.Windows.Forms.Cursors.Hand;
            this.GXZRR.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GXZRR.EditValue = "";
            this.GXZRR.Location = new System.Drawing.Point(2, 6);
            this.GXZRR.Name = "GXZRR";
            this.GXZRR.Properties.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.GXZRR.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.GXZRR.Properties.Appearance.Options.UseFont = true;
            this.GXZRR.Properties.Appearance.Options.UseForeColor = true;
            this.GXZRR.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.GXZRR.Properties.MaxLength = 20;
            this.GXZRR.Size = new System.Drawing.Size(170, 16);
            this.GXZRR.TabIndex = 74;
            this.GXZRR.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // laGXZRR
            // 
            this.laGXZRR.Cursor = System.Windows.Forms.Cursors.Default;
            this.laGXZRR.Dock = System.Windows.Forms.DockStyle.Left;
            this.laGXZRR.Location = new System.Drawing.Point(151, 0);
            this.laGXZRR.Name = "laGXZRR";
            this.laGXZRR.Size = new System.Drawing.Size(66, 24);
            this.laGXZRR.TabIndex = 0;
            this.laGXZRR.Text = "更新责任人";
            this.laGXZRR.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel12
            // 
            this.panel12.Controls.Add(this.GXDJ);
            this.panel12.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel12.Location = new System.Drawing.Point(55, 0);
            this.panel12.Name = "panel12";
            this.panel12.Padding = new System.Windows.Forms.Padding(2, 4, 4, 0);
            this.panel12.Size = new System.Drawing.Size(96, 24);
            this.panel12.TabIndex = 0;
            // 
            // laGXDJ
            // 
            this.laGXDJ.Cursor = System.Windows.Forms.Cursors.Default;
            this.laGXDJ.Dock = System.Windows.Forms.DockStyle.Left;
            this.laGXDJ.Location = new System.Drawing.Point(0, 0);
            this.laGXDJ.Name = "laGXDJ";
            this.laGXDJ.Size = new System.Drawing.Size(55, 24);
            this.laGXDJ.TabIndex = 0;
            this.laGXDJ.Text = "更新等级";
            this.laGXDJ.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label131
            // 
            this.label131.BackColor = System.Drawing.Color.Black;
            this.label131.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label131.Location = new System.Drawing.Point(0, 24);
            this.label131.Name = "label131";
            this.label131.Size = new System.Drawing.Size(479, 1);
            this.label131.TabIndex = 0;
            this.label131.Text = "label131";
            this.label131.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel94
            // 
            this.panel94.Controls.Add(this.panel95);
            this.panel94.Controls.Add(this.laFYCS);
            this.panel94.Controls.Add(this.panel96);
            this.panel94.Controls.Add(this.laYML);
            this.panel94.Controls.Add(this.label151);
            this.panel94.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel94.Location = new System.Drawing.Point(0, 75);
            this.panel94.Name = "panel94";
            this.panel94.Size = new System.Drawing.Size(479, 25);
            this.panel94.TabIndex = 0;
            // 
            // panel95
            // 
            this.panel95.Controls.Add(this.FYCS);
            this.panel95.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel95.Location = new System.Drawing.Point(206, 0);
            this.panel95.Name = "panel95";
            this.panel95.Padding = new System.Windows.Forms.Padding(2, 6, 8, 0);
            this.panel95.Size = new System.Drawing.Size(191, 24);
            this.panel95.TabIndex = 0;
            // 
            // FYCS
            // 
            this.FYCS.Cursor = System.Windows.Forms.Cursors.Hand;
            this.FYCS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FYCS.EditValue = "";
            this.FYCS.Location = new System.Drawing.Point(2, 6);
            this.FYCS.Name = "FYCS";
            this.FYCS.Properties.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FYCS.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.FYCS.Properties.Appearance.Options.UseFont = true;
            this.FYCS.Properties.Appearance.Options.UseForeColor = true;
            this.FYCS.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.FYCS.Properties.MaxLength = 20;
            this.FYCS.Size = new System.Drawing.Size(181, 16);
            this.FYCS.TabIndex = 72;
            this.FYCS.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // laFYCS
            // 
            this.laFYCS.Cursor = System.Windows.Forms.Cursors.Default;
            this.laFYCS.Dock = System.Windows.Forms.DockStyle.Left;
            this.laFYCS.Location = new System.Drawing.Point(151, 0);
            this.laFYCS.Name = "laFYCS";
            this.laFYCS.Size = new System.Drawing.Size(55, 24);
            this.laFYCS.TabIndex = 0;
            this.laFYCS.Text = "抚育措施";
            this.laFYCS.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel96
            // 
            this.panel96.Controls.Add(this.YML);
            this.panel96.Controls.Add(this.label174);
            this.panel96.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel96.Location = new System.Drawing.Point(55, 0);
            this.panel96.Name = "panel96";
            this.panel96.Padding = new System.Windows.Forms.Padding(2, 6, 6, 2);
            this.panel96.Size = new System.Drawing.Size(96, 24);
            this.panel96.TabIndex = 0;
            // 
            // label174
            // 
            this.label174.Dock = System.Windows.Forms.DockStyle.Right;
            this.label174.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label174.ForeColor = System.Drawing.Color.Blue;
            this.label174.Location = new System.Drawing.Point(70, 6);
            this.label174.Name = "label174";
            this.label174.Size = new System.Drawing.Size(20, 16);
            this.label174.TabIndex = 0;
            // 
            // laYML
            // 
            this.laYML.Cursor = System.Windows.Forms.Cursors.Default;
            this.laYML.Dock = System.Windows.Forms.DockStyle.Left;
            this.laYML.Location = new System.Drawing.Point(0, 0);
            this.laYML.Name = "laYML";
            this.laYML.Size = new System.Drawing.Size(55, 24);
            this.laYML.TabIndex = 0;
            this.laYML.Text = "用苗量";
            this.laYML.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label151
            // 
            this.label151.BackColor = System.Drawing.Color.Black;
            this.label151.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label151.Location = new System.Drawing.Point(0, 24);
            this.label151.Name = "label151";
            this.label151.Size = new System.Drawing.Size(479, 1);
            this.label151.TabIndex = 0;
            this.label151.Text = "label151";
            this.label151.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel28
            // 
            this.panel28.Controls.Add(this.panel113);
            this.panel28.Controls.Add(this.laMIAOMUGG);
            this.panel28.Controls.Add(this.panel83);
            this.panel28.Controls.Add(this.laZHUHJ);
            this.panel28.Controls.Add(this.panel87);
            this.panel28.Controls.Add(this.laZLMD);
            this.panel28.Controls.Add(this.label140);
            this.panel28.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel28.Location = new System.Drawing.Point(0, 50);
            this.panel28.Name = "panel28";
            this.panel28.Size = new System.Drawing.Size(479, 25);
            this.panel28.TabIndex = 0;
            // 
            // panel113
            // 
            this.panel113.Controls.Add(this.MIAOMUGG);
            this.panel113.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel113.Location = new System.Drawing.Point(357, 0);
            this.panel113.Name = "panel113";
            this.panel113.Padding = new System.Windows.Forms.Padding(2, 6, 8, 0);
            this.panel113.Size = new System.Drawing.Size(96, 24);
            this.panel113.TabIndex = 0;
            // 
            // MIAOMUGG
            // 
            this.MIAOMUGG.Cursor = System.Windows.Forms.Cursors.Hand;
            this.MIAOMUGG.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MIAOMUGG.EditValue = "";
            this.MIAOMUGG.Location = new System.Drawing.Point(2, 6);
            this.MIAOMUGG.Name = "MIAOMUGG";
            this.MIAOMUGG.Properties.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.MIAOMUGG.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.MIAOMUGG.Properties.Appearance.Options.UseFont = true;
            this.MIAOMUGG.Properties.Appearance.Options.UseForeColor = true;
            this.MIAOMUGG.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.MIAOMUGG.Properties.MaxLength = 20;
            this.MIAOMUGG.Size = new System.Drawing.Size(86, 16);
            this.MIAOMUGG.TabIndex = 70;
            this.MIAOMUGG.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // laMIAOMUGG
            // 
            this.laMIAOMUGG.Cursor = System.Windows.Forms.Cursors.Default;
            this.laMIAOMUGG.Dock = System.Windows.Forms.DockStyle.Left;
            this.laMIAOMUGG.Location = new System.Drawing.Point(302, 0);
            this.laMIAOMUGG.Name = "laMIAOMUGG";
            this.laMIAOMUGG.Size = new System.Drawing.Size(55, 24);
            this.laMIAOMUGG.TabIndex = 0;
            this.laMIAOMUGG.Text = "苗木规格";
            this.laMIAOMUGG.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel83
            // 
            this.panel83.Controls.Add(this.ZHUHJ);
            this.panel83.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel83.Location = new System.Drawing.Point(206, 0);
            this.panel83.Name = "panel83";
            this.panel83.Padding = new System.Windows.Forms.Padding(2, 6, 8, 0);
            this.panel83.Size = new System.Drawing.Size(96, 24);
            this.panel83.TabIndex = 0;
            // 
            // ZHUHJ
            // 
            this.ZHUHJ.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ZHUHJ.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ZHUHJ.EditValue = "";
            this.ZHUHJ.Location = new System.Drawing.Point(2, 6);
            this.ZHUHJ.Name = "ZHUHJ";
            this.ZHUHJ.Properties.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ZHUHJ.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.ZHUHJ.Properties.Appearance.Options.UseFont = true;
            this.ZHUHJ.Properties.Appearance.Options.UseForeColor = true;
            this.ZHUHJ.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.ZHUHJ.Properties.MaxLength = 50;
            this.ZHUHJ.Size = new System.Drawing.Size(86, 16);
            this.ZHUHJ.TabIndex = 69;
            this.ZHUHJ.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // laZHUHJ
            // 
            this.laZHUHJ.Cursor = System.Windows.Forms.Cursors.Default;
            this.laZHUHJ.Dock = System.Windows.Forms.DockStyle.Left;
            this.laZHUHJ.Location = new System.Drawing.Point(151, 0);
            this.laZHUHJ.Name = "laZHUHJ";
            this.laZHUHJ.Size = new System.Drawing.Size(55, 24);
            this.laZHUHJ.TabIndex = 0;
            this.laZHUHJ.Text = "株行距";
            this.laZHUHJ.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel87
            // 
            this.panel87.Controls.Add(this.ZLMD);
            this.panel87.Controls.Add(this.label157);
            this.panel87.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel87.Location = new System.Drawing.Point(55, 0);
            this.panel87.Name = "panel87";
            this.panel87.Padding = new System.Windows.Forms.Padding(2, 6, 6, 2);
            this.panel87.Size = new System.Drawing.Size(96, 24);
            this.panel87.TabIndex = 0;
            // 
            // label157
            // 
            this.label157.Dock = System.Windows.Forms.DockStyle.Right;
            this.label157.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label157.ForeColor = System.Drawing.Color.Blue;
            this.label157.Location = new System.Drawing.Point(37, 6);
            this.label157.Name = "label157";
            this.label157.Size = new System.Drawing.Size(53, 16);
            this.label157.TabIndex = 0;
            this.label157.Text = " 株/公顷";
            // 
            // laZLMD
            // 
            this.laZLMD.Cursor = System.Windows.Forms.Cursors.Default;
            this.laZLMD.Dock = System.Windows.Forms.DockStyle.Left;
            this.laZLMD.Location = new System.Drawing.Point(0, 0);
            this.laZLMD.Name = "laZLMD";
            this.laZLMD.Size = new System.Drawing.Size(55, 24);
            this.laZLMD.TabIndex = 0;
            this.laZLMD.Text = "造林密度";
            this.laZLMD.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label140
            // 
            this.label140.BackColor = System.Drawing.Color.Black;
            this.label140.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label140.Location = new System.Drawing.Point(0, 24);
            this.label140.Name = "label140";
            this.label140.Size = new System.Drawing.Size(479, 1);
            this.label140.TabIndex = 0;
            this.label140.Text = "label140";
            this.label140.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel72
            // 
            this.panel72.Controls.Add(this.panel17);
            this.panel72.Controls.Add(this.laGXSZ);
            this.panel72.Controls.Add(this.panel111);
            this.panel72.Controls.Add(this.laGXMJ);
            this.panel72.Controls.Add(this.panel59);
            this.panel72.Controls.Add(this.laGENGXINSJ);
            this.panel72.Controls.Add(this.label109);
            this.panel72.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel72.Location = new System.Drawing.Point(0, 25);
            this.panel72.Name = "panel72";
            this.panel72.Size = new System.Drawing.Size(479, 25);
            this.panel72.TabIndex = 0;
            // 
            // panel17
            // 
            this.panel17.Controls.Add(this.GXSZ);
            this.panel17.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel17.Location = new System.Drawing.Point(357, 0);
            this.panel17.Name = "panel17";
            this.panel17.Padding = new System.Windows.Forms.Padding(2, 4, 4, 0);
            this.panel17.Size = new System.Drawing.Size(96, 24);
            this.panel17.TabIndex = 0;
            // 
            // laGXSZ
            // 
            this.laGXSZ.Cursor = System.Windows.Forms.Cursors.Default;
            this.laGXSZ.Dock = System.Windows.Forms.DockStyle.Left;
            this.laGXSZ.Location = new System.Drawing.Point(302, 0);
            this.laGXSZ.Name = "laGXSZ";
            this.laGXSZ.Size = new System.Drawing.Size(55, 24);
            this.laGXSZ.TabIndex = 0;
            this.laGXSZ.Text = "更新树种";
            this.laGXSZ.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel111
            // 
            this.panel111.Controls.Add(this.GXMJ);
            this.panel111.Controls.Add(this.label160);
            this.panel111.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel111.Location = new System.Drawing.Point(206, 0);
            this.panel111.Name = "panel111";
            this.panel111.Padding = new System.Windows.Forms.Padding(2, 6, 6, 2);
            this.panel111.Size = new System.Drawing.Size(96, 24);
            this.panel111.TabIndex = 0;
            // 
            // label160
            // 
            this.label160.Dock = System.Windows.Forms.DockStyle.Right;
            this.label160.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label160.ForeColor = System.Drawing.Color.Blue;
            this.label160.Location = new System.Drawing.Point(58, 6);
            this.label160.Name = "label160";
            this.label160.Size = new System.Drawing.Size(32, 16);
            this.label160.TabIndex = 0;
            this.label160.Text = "公顷";
            // 
            // laGXMJ
            // 
            this.laGXMJ.Cursor = System.Windows.Forms.Cursors.Default;
            this.laGXMJ.Dock = System.Windows.Forms.DockStyle.Left;
            this.laGXMJ.Location = new System.Drawing.Point(151, 0);
            this.laGXMJ.Name = "laGXMJ";
            this.laGXMJ.Size = new System.Drawing.Size(55, 24);
            this.laGXMJ.TabIndex = 0;
            this.laGXMJ.Text = "更新面积";
            this.laGXMJ.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel59
            // 
            this.panel59.Controls.Add(this.GENGXINSJ);
            this.panel59.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel59.Location = new System.Drawing.Point(55, 0);
            this.panel59.Name = "panel59";
            this.panel59.Padding = new System.Windows.Forms.Padding(2, 5, 8, 0);
            this.panel59.Size = new System.Drawing.Size(96, 24);
            this.panel59.TabIndex = 0;
            // 
            // GENGXINSJ
            // 
            this.GENGXINSJ.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GENGXINSJ.EditValue = null;
            this.GENGXINSJ.Location = new System.Drawing.Point(2, 5);
            this.GENGXINSJ.Name = "GENGXINSJ";
            this.GENGXINSJ.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.GENGXINSJ.Properties.Appearance.Options.UseForeColor = true;
            this.GENGXINSJ.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.GENGXINSJ.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.GENGXINSJ.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.GENGXINSJ.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.GENGXINSJ.Size = new System.Drawing.Size(86, 18);
            this.GENGXINSJ.TabIndex = 65;
            this.GENGXINSJ.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // laGENGXINSJ
            // 
            this.laGENGXINSJ.Dock = System.Windows.Forms.DockStyle.Left;
            this.laGENGXINSJ.Location = new System.Drawing.Point(0, 0);
            this.laGENGXINSJ.Name = "laGENGXINSJ";
            this.laGENGXINSJ.Size = new System.Drawing.Size(55, 24);
            this.laGENGXINSJ.TabIndex = 0;
            this.laGENGXINSJ.Text = "更新时间";
            this.laGENGXINSJ.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label109
            // 
            this.label109.BackColor = System.Drawing.Color.Black;
            this.label109.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label109.Location = new System.Drawing.Point(0, 24);
            this.label109.Name = "label109";
            this.label109.Size = new System.Drawing.Size(479, 1);
            this.label109.TabIndex = 0;
            this.label109.Text = "label109";
            this.label109.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel88
            // 
            this.panel88.Controls.Add(this.panel119);
            this.panel88.Controls.Add(this.laZDGG);
            this.panel88.Controls.Add(this.panel93);
            this.panel88.Controls.Add(this.laZDFS);
            this.panel88.Controls.Add(this.panel8);
            this.panel88.Controls.Add(this.laGXFS);
            this.panel88.Controls.Add(this.label98);
            this.panel88.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel88.Location = new System.Drawing.Point(0, 0);
            this.panel88.Name = "panel88";
            this.panel88.Size = new System.Drawing.Size(479, 25);
            this.panel88.TabIndex = 0;
            // 
            // panel119
            // 
            this.panel119.Controls.Add(this.ZDGG);
            this.panel119.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel119.Location = new System.Drawing.Point(357, 0);
            this.panel119.Name = "panel119";
            this.panel119.Padding = new System.Windows.Forms.Padding(2, 6, 8, 0);
            this.panel119.Size = new System.Drawing.Size(96, 24);
            this.panel119.TabIndex = 0;
            // 
            // ZDGG
            // 
            this.ZDGG.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ZDGG.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ZDGG.EditValue = "";
            this.ZDGG.Location = new System.Drawing.Point(2, 6);
            this.ZDGG.Name = "ZDGG";
            this.ZDGG.Properties.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ZDGG.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.ZDGG.Properties.Appearance.Options.UseFont = true;
            this.ZDGG.Properties.Appearance.Options.UseForeColor = true;
            this.ZDGG.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.ZDGG.Properties.MaxLength = 50;
            this.ZDGG.Size = new System.Drawing.Size(86, 16);
            this.ZDGG.TabIndex = 64;
            this.ZDGG.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // laZDGG
            // 
            this.laZDGG.Cursor = System.Windows.Forms.Cursors.Default;
            this.laZDGG.Dock = System.Windows.Forms.DockStyle.Left;
            this.laZDGG.Location = new System.Drawing.Point(302, 0);
            this.laZDGG.Name = "laZDGG";
            this.laZDGG.Size = new System.Drawing.Size(55, 24);
            this.laZDGG.TabIndex = 0;
            this.laZDGG.Text = "整地规格";
            this.laZDGG.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel93
            // 
            this.panel93.Controls.Add(this.ZDFS);
            this.panel93.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel93.Location = new System.Drawing.Point(206, 0);
            this.panel93.Name = "panel93";
            this.panel93.Padding = new System.Windows.Forms.Padding(2, 6, 8, 0);
            this.panel93.Size = new System.Drawing.Size(96, 24);
            this.panel93.TabIndex = 0;
            // 
            // ZDFS
            // 
            this.ZDFS.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ZDFS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ZDFS.EditValue = "";
            this.ZDFS.Location = new System.Drawing.Point(2, 6);
            this.ZDFS.Name = "ZDFS";
            this.ZDFS.Properties.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ZDFS.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.ZDFS.Properties.Appearance.Options.UseFont = true;
            this.ZDFS.Properties.Appearance.Options.UseForeColor = true;
            this.ZDFS.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.ZDFS.Properties.MaxLength = 100;
            this.ZDFS.Size = new System.Drawing.Size(86, 16);
            this.ZDFS.TabIndex = 63;
            this.ZDFS.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // laZDFS
            // 
            this.laZDFS.Cursor = System.Windows.Forms.Cursors.Default;
            this.laZDFS.Dock = System.Windows.Forms.DockStyle.Left;
            this.laZDFS.Location = new System.Drawing.Point(151, 0);
            this.laZDFS.Name = "laZDFS";
            this.laZDFS.Size = new System.Drawing.Size(55, 24);
            this.laZDFS.TabIndex = 0;
            this.laZDFS.Text = "整地方式";
            this.laZDFS.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.GXFS);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel8.Location = new System.Drawing.Point(55, 0);
            this.panel8.Name = "panel8";
            this.panel8.Padding = new System.Windows.Forms.Padding(2, 4, 4, 0);
            this.panel8.Size = new System.Drawing.Size(96, 24);
            this.panel8.TabIndex = 0;
            // 
            // laGXFS
            // 
            this.laGXFS.Cursor = System.Windows.Forms.Cursors.Default;
            this.laGXFS.Dock = System.Windows.Forms.DockStyle.Left;
            this.laGXFS.Location = new System.Drawing.Point(0, 0);
            this.laGXFS.Name = "laGXFS";
            this.laGXFS.Size = new System.Drawing.Size(55, 24);
            this.laGXFS.TabIndex = 0;
            this.laGXFS.Text = "更新方式";
            this.laGXFS.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label98
            // 
            this.label98.BackColor = System.Drawing.Color.Black;
            this.label98.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label98.Location = new System.Drawing.Point(0, 24);
            this.label98.Name = "label98";
            this.label98.Size = new System.Drawing.Size(479, 1);
            this.label98.TabIndex = 0;
            this.label98.Text = "label98";
            this.label98.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label175
            // 
            this.label175.BackColor = System.Drawing.Color.Black;
            this.label175.Dock = System.Windows.Forms.DockStyle.Top;
            this.label175.Location = new System.Drawing.Point(0, 0);
            this.label175.Name = "label175";
            this.label175.Size = new System.Drawing.Size(479, 1);
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
            this.label176.Size = new System.Drawing.Size(1, 800);
            this.label176.TabIndex = 0;
            this.label176.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label177
            // 
            this.label177.BackColor = System.Drawing.Color.Black;
            this.label177.Dock = System.Windows.Forms.DockStyle.Right;
            this.label177.Location = new System.Drawing.Point(477, 0);
            this.label177.Name = "label177";
            this.label177.Size = new System.Drawing.Size(1, 800);
            this.label177.TabIndex = 0;
            this.label177.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            // label43
            // 
            this.label43.Dock = System.Windows.Forms.DockStyle.Top;
            this.label43.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label43.Location = new System.Drawing.Point(0, 890);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(479, 26);
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
            this.panelOther.Location = new System.Drawing.Point(0, 916);
            this.panelOther.Name = "panelOther";
            this.panelOther.Size = new System.Drawing.Size(479, 26);
            this.panelOther.TabIndex = 0;
            // 
            // label53
            // 
            this.label53.BackColor = System.Drawing.Color.Black;
            this.label53.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label53.Location = new System.Drawing.Point(1, 24);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(477, 1);
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
            this.panel86.Size = new System.Drawing.Size(477, 25);
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
            this.GXSJ.TabIndex = 77;
            this.GXSJ.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // laGXSJ
            // 
            this.laGXSJ.Dock = System.Windows.Forms.DockStyle.Left;
            this.laGXSJ.Location = new System.Drawing.Point(178, 0);
            this.laGXSJ.Name = "laGXSJ";
            this.laGXSJ.Size = new System.Drawing.Size(66, 25);
            this.laGXSJ.TabIndex = 0;
            this.laGXSJ.Text = "变更时间";
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
            this.label110.Size = new System.Drawing.Size(477, 1);
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
            this.label111.Size = new System.Drawing.Size(477, 1);
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
            this.label115.Location = new System.Drawing.Point(478, 0);
            this.label115.Name = "label115";
            this.label115.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.label115.Size = new System.Drawing.Size(1, 26);
            this.label115.TabIndex = 0;
            this.label115.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelPage1
            // 
            this.panelPage1.AutoScroll = true;
            this.panelPage1.Controls.Add(this.panelControl1);
            this.panelPage1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelPage1.Location = new System.Drawing.Point(2, 2);
            this.panelPage1.Name = "panelPage1";
            this.panelPage1.Size = new System.Drawing.Size(496, 496);
            this.panelPage1.TabIndex = 0;
            // 
            // panelControl1
            // 
            this.panelControl1.BackColor = System.Drawing.Color.White;
            this.panelControl1.Controls.Add(this.panelOther);
            this.panelControl1.Controls.Add(this.label43);
            this.panelControl1.Controls.Add(this.panelHarTable);
            this.panelControl1.Controls.Add(this.panel136);
            this.panelControl1.Controls.Add(this.labelTitle);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(479, 970);
            this.panelControl1.TabIndex = 0;
            // 
            // panelHarTable
            // 
            this.panelHarTable.Controls.Add(this.panelUpdate);
            this.panelHarTable.Controls.Add(this.label103);
            this.panelHarTable.Controls.Add(this.panelHarvest);
            this.panelHarTable.Controls.Add(this.label93);
            this.panelHarTable.Controls.Add(this.panelBasicInfo);
            this.panelHarTable.Controls.Add(this.panelTitle1);
            this.panelHarTable.Controls.Add(this.panel132);
            this.panelHarTable.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHarTable.Location = new System.Drawing.Point(0, 50);
            this.panelHarTable.Name = "panelHarTable";
            this.panelHarTable.Size = new System.Drawing.Size(479, 840);
            this.panelHarTable.TabIndex = 0;
            // 
            // label93
            // 
            this.label93.Dock = System.Windows.Forms.DockStyle.Top;
            this.label93.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label93.Location = new System.Drawing.Point(0, 501);
            this.label93.Name = "label93";
            this.label93.Size = new System.Drawing.Size(479, 26);
            this.label93.TabIndex = 0;
            this.label93.Text = "采伐设计";
            this.label93.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelTitle1
            // 
            this.panelTitle1.Controls.Add(this.label161);
            this.panelTitle1.Controls.Add(this.label7);
            this.panelTitle1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitle1.Location = new System.Drawing.Point(0, 25);
            this.panelTitle1.Name = "panelTitle1";
            this.panelTitle1.Size = new System.Drawing.Size(479, 25);
            this.panelTitle1.TabIndex = 0;
            // 
            // label161
            // 
            this.label161.BackColor = System.Drawing.Color.Black;
            this.label161.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label161.Location = new System.Drawing.Point(0, 24);
            this.label161.Name = "label161";
            this.label161.Size = new System.Drawing.Size(479, 1);
            this.label161.TabIndex = 0;
            this.label161.Text = "label161";
            this.label161.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.Dock = System.Windows.Forms.DockStyle.Top;
            this.label7.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(0, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(479, 26);
            this.label7.TabIndex = 0;
            this.label7.Text = "伐区调查";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel132
            // 
            this.panel132.Controls.Add(this.panel134);
            this.panel132.Controls.Add(this.laSJRY);
            this.panel132.Controls.Add(this.panel135);
            this.panel132.Controls.Add(this.laDCRY);
            this.panel132.Controls.Add(this.label141);
            this.panel132.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel132.Location = new System.Drawing.Point(0, 0);
            this.panel132.Name = "panel132";
            this.panel132.Size = new System.Drawing.Size(479, 25);
            this.panel132.TabIndex = 0;
            // 
            // panel134
            // 
            this.panel134.Controls.Add(this.SJRY);
            this.panel134.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel134.Location = new System.Drawing.Point(350, 0);
            this.panel134.Name = "panel134";
            this.panel134.Padding = new System.Windows.Forms.Padding(2, 6, 8, 0);
            this.panel134.Size = new System.Drawing.Size(107, 24);
            this.panel134.TabIndex = 0;
            this.panel134.TabStop = true;
            // 
            // SJRY
            // 
            this.SJRY.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SJRY.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SJRY.EditValue = "";
            this.SJRY.Location = new System.Drawing.Point(2, 6);
            this.SJRY.Name = "SJRY";
            this.SJRY.Properties.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.SJRY.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.SJRY.Properties.Appearance.Options.UseFont = true;
            this.SJRY.Properties.Appearance.Options.UseForeColor = true;
            this.SJRY.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.SJRY.Properties.MaxLength = 50;
            this.SJRY.Size = new System.Drawing.Size(97, 16);
            this.SJRY.TabIndex = 3;
            this.SJRY.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // laSJRY
            // 
            this.laSJRY.Dock = System.Windows.Forms.DockStyle.Left;
            this.laSJRY.Location = new System.Drawing.Point(295, 0);
            this.laSJRY.Name = "laSJRY";
            this.laSJRY.Size = new System.Drawing.Size(55, 24);
            this.laSJRY.TabIndex = 0;
            this.laSJRY.Text = "设计人员";
            this.laSJRY.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel135
            // 
            this.panel135.Controls.Add(this.DCRY);
            this.panel135.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel135.Location = new System.Drawing.Point(55, 0);
            this.panel135.Name = "panel135";
            this.panel135.Padding = new System.Windows.Forms.Padding(2, 6, 8, 0);
            this.panel135.Size = new System.Drawing.Size(240, 24);
            this.panel135.TabIndex = 0;
            // 
            // DCRY
            // 
            this.DCRY.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DCRY.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DCRY.EditValue = "";
            this.DCRY.Location = new System.Drawing.Point(2, 6);
            this.DCRY.Name = "DCRY";
            this.DCRY.Properties.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DCRY.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.DCRY.Properties.Appearance.Options.UseFont = true;
            this.DCRY.Properties.Appearance.Options.UseForeColor = true;
            this.DCRY.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.DCRY.Properties.MaxLength = 50;
            this.DCRY.Size = new System.Drawing.Size(230, 16);
            this.DCRY.TabIndex = 2;
            this.DCRY.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // laDCRY
            // 
            this.laDCRY.Dock = System.Windows.Forms.DockStyle.Left;
            this.laDCRY.Location = new System.Drawing.Point(0, 0);
            this.laDCRY.Name = "laDCRY";
            this.laDCRY.Size = new System.Drawing.Size(55, 24);
            this.laDCRY.TabIndex = 0;
            this.laDCRY.Text = "调查人员";
            this.laDCRY.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label141
            // 
            this.label141.BackColor = System.Drawing.Color.Black;
            this.label141.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label141.Location = new System.Drawing.Point(0, 24);
            this.label141.Name = "label141";
            this.label141.Size = new System.Drawing.Size(479, 1);
            this.label141.TabIndex = 0;
            this.label141.Text = "label141";
            this.label141.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel136
            // 
            this.panel136.Controls.Add(this.buttonJC);
            this.panel136.Controls.Add(this.buttonPrint);
            this.panel136.Controls.Add(this.laSJBH);
            this.panel136.Controls.Add(this.panel137);
            this.panel136.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel136.Location = new System.Drawing.Point(0, 25);
            this.panel136.Name = "panel136";
            this.panel136.Padding = new System.Windows.Forms.Padding(10, 0, 16, 0);
            this.panel136.Size = new System.Drawing.Size(479, 25);
            this.panel136.TabIndex = 0;
            // 
            // buttonJC
            // 
            this.buttonJC.Location = new System.Drawing.Point(13, 3);
            this.buttonJC.Name = "buttonJC";
            this.buttonJC.Size = new System.Drawing.Size(69, 20);
            this.buttonJC.TabIndex = 0;
            this.buttonJC.Text = "每木检尺表";
            this.buttonJC.ToolTip = "每木检尺表";
            this.buttonJC.Click += new System.EventHandler(this.buttonJC_Click);
            // 
            // buttonPrint
            // 
            this.buttonPrint.Location = new System.Drawing.Point(107, 3);
            this.buttonPrint.Name = "buttonPrint";
            this.buttonPrint.Size = new System.Drawing.Size(45, 20);
            this.buttonPrint.TabIndex = 0;
            this.buttonPrint.Text = "打印";
            this.buttonPrint.ToolTip = "打印简易伐区调查设计表";
            this.buttonPrint.Visible = false;
            this.buttonPrint.Click += new System.EventHandler(this.buttonPrint_Click);
            // 
            // laSJBH
            // 
            this.laSJBH.Dock = System.Windows.Forms.DockStyle.Right;
            this.laSJBH.Location = new System.Drawing.Point(308, 0);
            this.laSJBH.Name = "laSJBH";
            this.laSJBH.Size = new System.Drawing.Size(55, 25);
            this.laSJBH.TabIndex = 0;
            this.laSJBH.Text = "设计编号";
            this.laSJBH.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel137
            // 
            this.panel137.Controls.Add(this.SJBH);
            this.panel137.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel137.Location = new System.Drawing.Point(363, 0);
            this.panel137.Name = "panel137";
            this.panel137.Padding = new System.Windows.Forms.Padding(2, 6, 8, 0);
            this.panel137.Size = new System.Drawing.Size(100, 25);
            this.panel137.TabIndex = 0;
            // 
            // SJBH
            // 
            this.SJBH.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SJBH.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SJBH.EditValue = "";
            this.SJBH.Location = new System.Drawing.Point(2, 6);
            this.SJBH.Name = "SJBH";
            this.SJBH.Properties.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.SJBH.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.SJBH.Properties.Appearance.Options.UseFont = true;
            this.SJBH.Properties.Appearance.Options.UseForeColor = true;
            this.SJBH.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.SJBH.Properties.MaxLength = 50;
            this.SJBH.Size = new System.Drawing.Size(90, 16);
            this.SJBH.TabIndex = 1;
            this.SJBH.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
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
            this.BHYY.TabIndex = 76;
            this.BHYY.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // GXDJ
            // 
            this.GXDJ.AssDispValue = true;
            this.GXDJ.Cursor = System.Windows.Forms.Cursors.Hand;
            this.GXDJ.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GXDJ.ForeColor = System.Drawing.Color.Blue;
            this.GXDJ.Location = new System.Drawing.Point(2, 4);
            this.GXDJ.Name = "GXDJ";
            this.GXDJ.Size = new System.Drawing.Size(90, 20);
            this.GXDJ.TabIndex = 73;
            this.GXDJ.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // YML
            // 
            this.YML.Cursor = System.Windows.Forms.Cursors.Hand;
            this.YML.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.YML.EditScale = 0;
            this.YML.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.YML.Location = new System.Drawing.Point(2, 4);
            this.YML.Name = "YML";
            this.YML.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.YML.Properties.Appearance.Options.UseForeColor = true;
            this.YML.Properties.Appearance.Options.UseTextOptions = true;
            this.YML.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.YML.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.YML.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.YML.Properties.MaxValue = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.YML.Size = new System.Drawing.Size(68, 18);
            this.YML.TabIndex = 71;
            this.YML.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // ZLMD
            // 
            this.ZLMD.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ZLMD.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ZLMD.EditScale = 0;
            this.ZLMD.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ZLMD.Location = new System.Drawing.Point(2, 4);
            this.ZLMD.Name = "ZLMD";
            this.ZLMD.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.ZLMD.Properties.Appearance.Options.UseForeColor = true;
            this.ZLMD.Properties.Appearance.Options.UseTextOptions = true;
            this.ZLMD.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.ZLMD.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.ZLMD.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.ZLMD.Properties.MaxValue = new decimal(new int[] {
            30000,
            0,
            0,
            0});
            this.ZLMD.Size = new System.Drawing.Size(35, 18);
            this.ZLMD.TabIndex = 68;
            this.ZLMD.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // GXSZ
            // 
            this.GXSZ.AssDispValue = true;
            this.GXSZ.Cursor = System.Windows.Forms.Cursors.Hand;
            this.GXSZ.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GXSZ.ForeColor = System.Drawing.Color.Blue;
            this.GXSZ.Location = new System.Drawing.Point(2, 4);
            this.GXSZ.Name = "GXSZ";
            this.GXSZ.Size = new System.Drawing.Size(90, 20);
            this.GXSZ.TabIndex = 67;
            this.GXSZ.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // GXMJ
            // 
            this.GXMJ.Cursor = System.Windows.Forms.Cursors.Hand;
            this.GXMJ.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.GXMJ.EditScale = 0;
            this.GXMJ.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.GXMJ.Location = new System.Drawing.Point(2, 4);
            this.GXMJ.Name = "GXMJ";
            this.GXMJ.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.GXMJ.Properties.Appearance.Options.UseForeColor = true;
            this.GXMJ.Properties.Appearance.Options.UseTextOptions = true;
            this.GXMJ.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.GXMJ.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.GXMJ.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.GXMJ.Properties.MaxValue = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.GXMJ.Size = new System.Drawing.Size(56, 18);
            this.GXMJ.TabIndex = 66;
            this.GXMJ.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // GXFS
            // 
            this.GXFS.AssDispValue = true;
            this.GXFS.Cursor = System.Windows.Forms.Cursors.Hand;
            this.GXFS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GXFS.ForeColor = System.Drawing.Color.Blue;
            this.GXFS.Location = new System.Drawing.Point(2, 4);
            this.GXFS.Name = "GXFS";
            this.GXFS.Size = new System.Drawing.Size(90, 20);
            this.GXFS.TabIndex = 62;
            this.GXFS.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // JCFS
            // 
            this.JCFS.AssDispValue = true;
            this.JCFS.Cursor = System.Windows.Forms.Cursors.Hand;
            this.JCFS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.JCFS.ForeColor = System.Drawing.Color.Blue;
            this.JCFS.Location = new System.Drawing.Point(2, 4);
            this.JCFS.Name = "JCFS";
            this.JCFS.Size = new System.Drawing.Size(90, 20);
            this.JCFS.TabIndex = 61;
            this.JCFS.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // BLMYBD
            // 
            this.BLMYBD.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BLMYBD.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BLMYBD.EditScale = 0;
            this.BLMYBD.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.BLMYBD.Location = new System.Drawing.Point(2, 4);
            this.BLMYBD.Name = "BLMYBD";
            this.BLMYBD.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.BLMYBD.Properties.Appearance.Options.UseForeColor = true;
            this.BLMYBD.Properties.Appearance.Options.UseTextOptions = true;
            this.BLMYBD.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.BLMYBD.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.BLMYBD.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.BLMYBD.Properties.MaxValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.BLMYBD.Size = new System.Drawing.Size(71, 18);
            this.BLMYBD.TabIndex = 58;
            this.BLMYBD.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // SFCF
            // 
            this.SFCF.AssDispValue = true;
            this.SFCF.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SFCF.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SFCF.ForeColor = System.Drawing.Color.Blue;
            this.SFCF.Location = new System.Drawing.Point(2, 4);
            this.SFCF.Name = "SFCF";
            this.SFCF.Size = new System.Drawing.Size(54, 20);
            this.SFCF.TabIndex = 57;
            this.SFCF.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // CFQD
            // 
            this.CFQD.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CFQD.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.CFQD.EditScale = 0;
            this.CFQD.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.CFQD.Location = new System.Drawing.Point(2, 4);
            this.CFQD.Name = "CFQD";
            this.CFQD.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.CFQD.Properties.Appearance.Options.UseForeColor = true;
            this.CFQD.Properties.Appearance.Options.UseTextOptions = true;
            this.CFQD.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.CFQD.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.CFQD.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.CFQD.Properties.MaxValue = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.CFQD.Size = new System.Drawing.Size(68, 18);
            this.CFQD.TabIndex = 56;
            this.CFQD.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // CFMJ
            // 
            this.CFMJ.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CFMJ.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.CFMJ.EditScale = 0;
            this.CFMJ.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.CFMJ.Location = new System.Drawing.Point(2, 4);
            this.CFMJ.Name = "CFMJ";
            this.CFMJ.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.CFMJ.Properties.Appearance.Options.UseForeColor = true;
            this.CFMJ.Properties.Appearance.Options.UseTextOptions = true;
            this.CFMJ.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.CFMJ.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.CFMJ.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.CFMJ.Properties.MaxValue = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.CFMJ.Size = new System.Drawing.Size(56, 18);
            this.CFMJ.TabIndex = 55;
            this.CFMJ.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // CFFS
            // 
            this.CFFS.AssDispValue = true;
            this.CFFS.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CFFS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CFFS.ForeColor = System.Drawing.Color.Blue;
            this.CFFS.Location = new System.Drawing.Point(2, 4);
            this.CFFS.Name = "CFFS";
            this.CFFS.Size = new System.Drawing.Size(90, 20);
            this.CFFS.TabIndex = 54;
            this.CFFS.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // CFCS
            // 
            this.CFCS.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CFCS.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.CFCS.EditScale = 0;
            this.CFCS.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.CFCS.Location = new System.Drawing.Point(2, 4);
            this.CFCS.Name = "CFCS";
            this.CFCS.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.CFCS.Properties.Appearance.Options.UseForeColor = true;
            this.CFCS.Properties.Appearance.Options.UseTextOptions = true;
            this.CFCS.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.CFCS.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.CFCS.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.CFCS.Properties.MaxValue = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.CFCS.Size = new System.Drawing.Size(88, 18);
            this.CFCS.TabIndex = 53;
            this.CFCS.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // CFLX
            // 
            this.CFLX.AssDispValue = true;
            this.CFLX.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CFLX.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CFLX.ForeColor = System.Drawing.Color.Blue;
            this.CFLX.Location = new System.Drawing.Point(2, 4);
            this.CFLX.Name = "CFLX";
            this.CFLX.Size = new System.Drawing.Size(90, 20);
            this.CFLX.TabIndex = 52;
            this.CFLX.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // ZXJ
            // 
            this.ZXJ.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ZXJ.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ZXJ.EditScale = 0;
            this.ZXJ.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ZXJ.Location = new System.Drawing.Point(2, 4);
            this.ZXJ.Name = "ZXJ";
            this.ZXJ.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.ZXJ.Properties.Appearance.Options.UseForeColor = true;
            this.ZXJ.Properties.Appearance.Options.UseTextOptions = true;
            this.ZXJ.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.ZXJ.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.ZXJ.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.ZXJ.Properties.MaxValue = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.ZXJ.Size = new System.Drawing.Size(72, 18);
            this.ZXJ.TabIndex = 51;
            this.ZXJ.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // FQZS
            // 
            this.FQZS.Cursor = System.Windows.Forms.Cursors.Hand;
            this.FQZS.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.FQZS.EditScale = 0;
            this.FQZS.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.FQZS.Location = new System.Drawing.Point(2, 4);
            this.FQZS.Name = "FQZS";
            this.FQZS.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.FQZS.Properties.Appearance.Options.UseForeColor = true;
            this.FQZS.Properties.Appearance.Options.UseTextOptions = true;
            this.FQZS.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.FQZS.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.FQZS.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.FQZS.Properties.MaxValue = new decimal(new int[] {
            30000,
            0,
            0,
            0});
            this.FQZS.Size = new System.Drawing.Size(87, 18);
            this.FQZS.TabIndex = 50;
            this.FQZS.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // PJGF
            // 
            this.PJGF.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PJGF.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PJGF.EditScale = 0;
            this.PJGF.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.PJGF.Location = new System.Drawing.Point(2, 4);
            this.PJGF.Name = "PJGF";
            this.PJGF.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.PJGF.Properties.Appearance.Options.UseForeColor = true;
            this.PJGF.Properties.Appearance.Options.UseTextOptions = true;
            this.PJGF.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.PJGF.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.PJGF.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.PJGF.Properties.MaxValue = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.PJGF.Size = new System.Drawing.Size(70, 18);
            this.PJGF.TabIndex = 49;
            this.PJGF.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
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
            this.HUO_LMGQXJ.Location = new System.Drawing.Point(2, 4);
            this.HUO_LMGQXJ.Name = "HUO_LMGQXJ";
            this.HUO_LMGQXJ.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.HUO_LMGQXJ.Properties.Appearance.Options.UseForeColor = true;
            this.HUO_LMGQXJ.Properties.Appearance.Options.UseTextOptions = true;
            this.HUO_LMGQXJ.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.HUO_LMGQXJ.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.HUO_LMGQXJ.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.HUO_LMGQXJ.Properties.MaxValue = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.HUO_LMGQXJ.Size = new System.Drawing.Size(87, 18);
            this.HUO_LMGQXJ.TabIndex = 48;
            this.HUO_LMGQXJ.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
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
            30000,
            0,
            0,
            0});
            this.MEI_GQ_ZS.Size = new System.Drawing.Size(105, 18);
            this.MEI_GQ_ZS.TabIndex = 47;
            this.MEI_GQ_ZS.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // SSXJ
            // 
            this.SSXJ.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SSXJ.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.SSXJ.EditScale = 0;
            this.SSXJ.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.SSXJ.Location = new System.Drawing.Point(2, 4);
            this.SSXJ.Name = "SSXJ";
            this.SSXJ.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.SSXJ.Properties.Appearance.Options.UseForeColor = true;
            this.SSXJ.Properties.Appearance.Options.UseTextOptions = true;
            this.SSXJ.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.SSXJ.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.SSXJ.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.SSXJ.Properties.MaxValue = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.SSXJ.Size = new System.Drawing.Size(98, 18);
            this.SSXJ.TabIndex = 46;
            this.SSXJ.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // SSZZS
            // 
            this.SSZZS.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SSZZS.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.SSZZS.EditScale = 0;
            this.SSZZS.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.SSZZS.Location = new System.Drawing.Point(2, 4);
            this.SSZZS.Name = "SSZZS";
            this.SSZZS.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.SSZZS.Properties.Appearance.Options.UseForeColor = true;
            this.SSZZS.Properties.Appearance.Options.UseTextOptions = true;
            this.SSZZS.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.SSZZS.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.SSZZS.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.SSZZS.Properties.MaxValue = new decimal(new int[] {
            30000,
            0,
            0,
            0});
            this.SSZZS.Size = new System.Drawing.Size(105, 18);
            this.SSZZS.TabIndex = 45;
            this.SSZZS.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // QI_YUAN
            // 
            this.QI_YUAN.AssDispValue = true;
            this.QI_YUAN.Cursor = System.Windows.Forms.Cursors.Hand;
            this.QI_YUAN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.QI_YUAN.ForeColor = System.Drawing.Color.Blue;
            this.QI_YUAN.Location = new System.Drawing.Point(2, 4);
            this.QI_YUAN.Name = "QI_YUAN";
            this.QI_YUAN.Size = new System.Drawing.Size(93, 20);
            this.QI_YUAN.TabIndex = 44;
            this.QI_YUAN.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
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
            this.YU_BI_DU.Size = new System.Drawing.Size(54, 18);
            this.YU_BI_DU.TabIndex = 43;
            this.YU_BI_DU.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // LING_ZU
            // 
            this.LING_ZU.AssDispValue = true;
            this.LING_ZU.BackColor = System.Drawing.Color.White;
            this.LING_ZU.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LING_ZU.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LING_ZU.ForeColor = System.Drawing.Color.Blue;
            this.LING_ZU.Location = new System.Drawing.Point(2, 4);
            this.LING_ZU.Name = "LING_ZU";
            this.LING_ZU.Size = new System.Drawing.Size(74, 20);
            this.LING_ZU.TabIndex = 42;
            this.LING_ZU.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
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
            10000,
            0,
            0,
            0});
            this.PINGJUN_NL.Size = new System.Drawing.Size(67, 18);
            this.PINGJUN_NL.TabIndex = 41;
            this.PINGJUN_NL.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
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
            10000,
            0,
            0,
            0});
            this.TU_CENG_HD.Size = new System.Drawing.Size(52, 18);
            this.TU_CENG_HD.TabIndex = 40;
            this.TU_CENG_HD.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // TU_RANG_LX
            // 
            this.TU_RANG_LX.AssDispValue = true;
            this.TU_RANG_LX.BackColor = System.Drawing.Color.White;
            this.TU_RANG_LX.Cursor = System.Windows.Forms.Cursors.Hand;
            this.TU_RANG_LX.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TU_RANG_LX.ForeColor = System.Drawing.Color.Blue;
            this.TU_RANG_LX.Location = new System.Drawing.Point(2, 4);
            this.TU_RANG_LX.Name = "TU_RANG_LX";
            this.TU_RANG_LX.Size = new System.Drawing.Size(74, 20);
            this.TU_RANG_LX.TabIndex = 39;
            this.TU_RANG_LX.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // CTMY
            // 
            this.CTMY.AssDispValue = true;
            this.CTMY.BackColor = System.Drawing.Color.White;
            this.CTMY.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CTMY.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CTMY.ForeColor = System.Drawing.Color.Blue;
            this.CTMY.Location = new System.Drawing.Point(2, 4);
            this.CTMY.Name = "CTMY";
            this.CTMY.Size = new System.Drawing.Size(74, 20);
            this.CTMY.TabIndex = 38;
            this.CTMY.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // HBG
            // 
            this.HBG.Cursor = System.Windows.Forms.Cursors.Hand;
            this.HBG.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.HBG.EditScale = 0;
            this.HBG.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.HBG.Location = new System.Drawing.Point(2, 4);
            this.HBG.Name = "HBG";
            this.HBG.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.HBG.Properties.Appearance.Options.UseForeColor = true;
            this.HBG.Properties.Appearance.Options.UseTextOptions = true;
            this.HBG.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.HBG.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.HBG.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.HBG.Properties.MaxValue = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.HBG.Size = new System.Drawing.Size(52, 18);
            this.HBG.TabIndex = 37;
            this.HBG.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // PO_WEI
            // 
            this.PO_WEI.AssDispValue = true;
            this.PO_WEI.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PO_WEI.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PO_WEI.ForeColor = System.Drawing.Color.Blue;
            this.PO_WEI.Location = new System.Drawing.Point(2, 4);
            this.PO_WEI.Name = "PO_WEI";
            this.PO_WEI.Size = new System.Drawing.Size(74, 20);
            this.PO_WEI.TabIndex = 36;
            this.PO_WEI.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // PO_DU
            // 
            this.PO_DU.AssDispValue = true;
            this.PO_DU.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PO_DU.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PO_DU.ForeColor = System.Drawing.Color.Blue;
            this.PO_DU.Location = new System.Drawing.Point(2, 4);
            this.PO_DU.Name = "PO_DU";
            this.PO_DU.Size = new System.Drawing.Size(74, 20);
            this.PO_DU.TabIndex = 35;
            this.PO_DU.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // PO_XIANG
            // 
            this.PO_XIANG.AssDispValue = true;
            this.PO_XIANG.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PO_XIANG.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PO_XIANG.ForeColor = System.Drawing.Color.Blue;
            this.PO_XIANG.Location = new System.Drawing.Point(2, 4);
            this.PO_XIANG.Name = "PO_XIANG";
            this.PO_XIANG.Size = new System.Drawing.Size(74, 20);
            this.PO_XIANG.TabIndex = 34;
            this.PO_XIANG.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // Q_SEN_LB
            // 
            this.Q_SEN_LB.AssDispValue = true;
            this.Q_SEN_LB.BackColor = System.Drawing.Color.White;
            this.Q_SEN_LB.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Q_SEN_LB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Q_SEN_LB.ForeColor = System.Drawing.Color.Blue;
            this.Q_SEN_LB.Location = new System.Drawing.Point(2, 4);
            this.Q_SEN_LB.Name = "Q_SEN_LB";
            this.Q_SEN_LB.Size = new System.Drawing.Size(116, 20);
            this.Q_SEN_LB.TabIndex = 33;
            this.Q_SEN_LB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // SEN_LIN_LB
            // 
            this.SEN_LIN_LB.AssDispValue = true;
            this.SEN_LIN_LB.BackColor = System.Drawing.Color.White;
            this.SEN_LIN_LB.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SEN_LIN_LB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SEN_LIN_LB.ForeColor = System.Drawing.Color.Blue;
            this.SEN_LIN_LB.Location = new System.Drawing.Point(2, 4);
            this.SEN_LIN_LB.Name = "SEN_LIN_LB";
            this.SEN_LIN_LB.Size = new System.Drawing.Size(118, 20);
            this.SEN_LIN_LB.TabIndex = 32;
            this.SEN_LIN_LB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // Q_LD_QS
            // 
            this.Q_LD_QS.AssDispValue = true;
            this.Q_LD_QS.BackColor = System.Drawing.Color.White;
            this.Q_LD_QS.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Q_LD_QS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Q_LD_QS.ForeColor = System.Drawing.Color.Blue;
            this.Q_LD_QS.Location = new System.Drawing.Point(2, 4);
            this.Q_LD_QS.Name = "Q_LD_QS";
            this.Q_LD_QS.Size = new System.Drawing.Size(114, 20);
            this.Q_LD_QS.TabIndex = 31;
            this.Q_LD_QS.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // LD_QS
            // 
            this.LD_QS.AssDispValue = true;
            this.LD_QS.BackColor = System.Drawing.Color.White;
            this.LD_QS.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LD_QS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LD_QS.ForeColor = System.Drawing.Color.Blue;
            this.LD_QS.Location = new System.Drawing.Point(2, 4);
            this.LD_QS.Name = "LD_QS";
            this.LD_QS.Size = new System.Drawing.Size(118, 20);
            this.LD_QS.TabIndex = 30;
            this.LD_QS.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
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
            100000,
            0,
            0,
            0});
            this.PINGJUN_SG.Size = new System.Drawing.Size(91, 18);
            this.PINGJUN_SG.TabIndex = 29;
            this.PINGJUN_SG.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
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
            this.PINGJUN_XJ.Size = new System.Drawing.Size(61, 18);
            this.PINGJUN_XJ.TabIndex = 28;
            this.PINGJUN_XJ.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // YOU_SHI_SZ
            // 
            this.YOU_SHI_SZ.AssDispValue = true;
            this.YOU_SHI_SZ.Cursor = System.Windows.Forms.Cursors.Hand;
            this.YOU_SHI_SZ.Dock = System.Windows.Forms.DockStyle.Fill;
            this.YOU_SHI_SZ.ForeColor = System.Drawing.Color.Blue;
            this.YOU_SHI_SZ.Location = new System.Drawing.Point(2, 4);
            this.YOU_SHI_SZ.Name = "YOU_SHI_SZ";
            this.YOU_SHI_SZ.Size = new System.Drawing.Size(113, 20);
            this.YOU_SHI_SZ.TabIndex = 27;
            this.YOU_SHI_SZ.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // GJGYL_BHDJ
            // 
            this.GJGYL_BHDJ.AssDispValue = true;
            this.GJGYL_BHDJ.BackColor = System.Drawing.Color.White;
            this.GJGYL_BHDJ.Cursor = System.Windows.Forms.Cursors.Hand;
            this.GJGYL_BHDJ.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GJGYL_BHDJ.ForeColor = System.Drawing.Color.Blue;
            this.GJGYL_BHDJ.Location = new System.Drawing.Point(2, 4);
            this.GJGYL_BHDJ.Name = "GJGYL_BHDJ";
            this.GJGYL_BHDJ.Size = new System.Drawing.Size(64, 20);
            this.GJGYL_BHDJ.TabIndex = 26;
            this.GJGYL_BHDJ.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // Q_LIN_ZHONG
            // 
            this.Q_LIN_ZHONG.AssDispValue = true;
            this.Q_LIN_ZHONG.BackColor = System.Drawing.Color.White;
            this.Q_LIN_ZHONG.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Q_LIN_ZHONG.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Q_LIN_ZHONG.ForeColor = System.Drawing.Color.Blue;
            this.Q_LIN_ZHONG.Location = new System.Drawing.Point(2, 4);
            this.Q_LIN_ZHONG.Name = "Q_LIN_ZHONG";
            this.Q_LIN_ZHONG.Size = new System.Drawing.Size(89, 20);
            this.Q_LIN_ZHONG.TabIndex = 25;
            this.Q_LIN_ZHONG.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // LIN_ZHONG
            // 
            this.LIN_ZHONG.AssDispValue = true;
            this.LIN_ZHONG.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LIN_ZHONG.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LIN_ZHONG.ForeColor = System.Drawing.Color.Blue;
            this.LIN_ZHONG.Location = new System.Drawing.Point(2, 4);
            this.LIN_ZHONG.Name = "LIN_ZHONG";
            this.LIN_ZHONG.Size = new System.Drawing.Size(113, 20);
            this.LIN_ZHONG.TabIndex = 24;
            this.LIN_ZHONG.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
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
            this.LMSYQ.TabIndex = 23;
            this.LMSYQ.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // LMJYQ
            // 
            this.LMJYQ.AssDispValue = true;
            this.LMJYQ.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LMJYQ.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LMJYQ.ForeColor = System.Drawing.Color.Blue;
            this.LMJYQ.Location = new System.Drawing.Point(2, 4);
            this.LMJYQ.Name = "LMJYQ";
            this.LMJYQ.Size = new System.Drawing.Size(78, 20);
            this.LMJYQ.TabIndex = 22;
            this.LMJYQ.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // TDJYQ
            // 
            this.TDJYQ.AssDispValue = true;
            this.TDJYQ.Cursor = System.Windows.Forms.Cursors.Hand;
            this.TDJYQ.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TDJYQ.ForeColor = System.Drawing.Color.Blue;
            this.TDJYQ.Location = new System.Drawing.Point(2, 4);
            this.TDJYQ.Name = "TDJYQ";
            this.TDJYQ.Size = new System.Drawing.Size(77, 20);
            this.TDJYQ.TabIndex = 21;
            this.TDJYQ.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // Q_DI_LEI
            // 
            this.Q_DI_LEI.AssDispValue = true;
            this.Q_DI_LEI.BackColor = System.Drawing.Color.White;
            this.Q_DI_LEI.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Q_DI_LEI.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Q_DI_LEI.ForeColor = System.Drawing.Color.Blue;
            this.Q_DI_LEI.Location = new System.Drawing.Point(2, 4);
            this.Q_DI_LEI.Name = "Q_DI_LEI";
            this.Q_DI_LEI.Size = new System.Drawing.Size(98, 20);
            this.Q_DI_LEI.TabIndex = 20;
            this.Q_DI_LEI.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // DI_LEI
            // 
            this.DI_LEI.AssDispValue = true;
            this.DI_LEI.BackColor = System.Drawing.Color.White;
            this.DI_LEI.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DI_LEI.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DI_LEI.ForeColor = System.Drawing.Color.Blue;
            this.DI_LEI.Location = new System.Drawing.Point(2, 4);
            this.DI_LEI.Name = "DI_LEI";
            this.DI_LEI.Size = new System.Drawing.Size(114, 20);
            this.DI_LEI.TabIndex = 19;
            this.DI_LEI.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
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
            1000000,
            0,
            0,
            0});
            this.MIAN_JI.Size = new System.Drawing.Size(79, 18);
            this.MIAN_JI.TabIndex = 0;
            this.MIAN_JI.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
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
            this.CUN.TabIndex = 8;
            this.CUN.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // XIANG
            // 
            this.XIANG.AssDispValue = true;
            this.XIANG.Cursor = System.Windows.Forms.Cursors.Hand;
            this.XIANG.Dock = System.Windows.Forms.DockStyle.Fill;
            this.XIANG.ForeColor = System.Drawing.Color.Blue;
            this.XIANG.Location = new System.Drawing.Point(2, 4);
            this.XIANG.Name = "XIANG";
            this.XIANG.Size = new System.Drawing.Size(81, 20);
            this.XIANG.TabIndex = 7;
            this.XIANG.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // XIAN
            // 
            this.XIAN.AssDispValue = true;
            this.XIAN.Cursor = System.Windows.Forms.Cursors.Hand;
            this.XIAN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.XIAN.ForeColor = System.Drawing.Color.Blue;
            this.XIAN.Location = new System.Drawing.Point(2, 4);
            this.XIAN.Name = "XIAN";
            this.XIAN.Size = new System.Drawing.Size(84, 20);
            this.XIAN.TabIndex = 6;
            this.XIAN.SelectedIndexChanged += new System.EventHandler(this.XIAN_SelectedIndexChanged);
            this.XIAN.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
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
            this.SHI.TabIndex = 5;
            this.SHI.SelectedIndexChanged += new System.EventHandler(this.SHI_SelectedIndexChanged);
            this.SHI.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // SHENG
            // 
            this.SHENG.AssDispValue = true;
            this.SHENG.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SHENG.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SHENG.ForeColor = System.Drawing.Color.Blue;
            this.SHENG.Location = new System.Drawing.Point(2, 4);
            this.SHENG.Name = "SHENG";
            this.SHENG.Size = new System.Drawing.Size(84, 20);
            this.SHENG.TabIndex = 4;
            this.SHENG.SelectedIndexChanged += new System.EventHandler(this.SHENG_SelectedIndexChanged);
            this.SHENG.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
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
            this.spinEdit3.Size = new System.Drawing.Size(98, 18);
            this.spinEdit3.TabIndex = 0;
            // 
            // UserControlHarAttr1
            // 
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panelPage1);
            this.Name = "UserControlHarAttr1";
            this.Padding = new System.Windows.Forms.Padding(2);
            this.Size = new System.Drawing.Size(500, 500);
            this.panelBasicInfo.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel100.ResumeLayout(false);
            this.panel20.ResumeLayout(false);
            this.panel19.ResumeLayout(false);
            this.panel34.ResumeLayout(false);
            this.panel114.ResumeLayout(false);
            this.panel82.ResumeLayout(false);
            this.panel99.ResumeLayout(false);
            this.panel97.ResumeLayout(false);
            this.panel32.ResumeLayout(false);
            this.panel33.ResumeLayout(false);
            this.panel133.ResumeLayout(false);
            this.panel70.ResumeLayout(false);
            this.panel67.ResumeLayout(false);
            this.panel168.ResumeLayout(false);
            this.panel169.ResumeLayout(false);
            this.panel155.ResumeLayout(false);
            this.panel110.ResumeLayout(false);
            this.panel158.ResumeLayout(false);
            this.panel159.ResumeLayout(false);
            this.panel160.ResumeLayout(false);
            this.panel149.ResumeLayout(false);
            this.panel42.ResumeLayout(false);
            this.panel23.ResumeLayout(false);
            this.panel130.ResumeLayout(false);
            this.panel41.ResumeLayout(false);
            this.panel44.ResumeLayout(false);
            this.panel43.ResumeLayout(false);
            this.panel21.ResumeLayout(false);
            this.panel25.ResumeLayout(false);
            this.panel24.ResumeLayout(false);
            this.panel37.ResumeLayout(false);
            this.panel112.ResumeLayout(false);
            this.panel80.ResumeLayout(false);
            this.panel79.ResumeLayout(false);
            this.panel62.ResumeLayout(false);
            this.panel98.ResumeLayout(false);
            this.panel77.ResumeLayout(false);
            this.panel76.ResumeLayout(false);
            this.panel14.ResumeLayout(false);
            this.panel38.ResumeLayout(false);
            this.panel40.ResumeLayout(false);
            this.panel47.ResumeLayout(false);
            this.panel31.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.panel26.ResumeLayout(false);
            this.panel18.ResumeLayout(false);
            this.panel145.ResumeLayout(false);
            this.panel85.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DW.Properties)).EndInit();
            this.panel146.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.LMSYZXM.Properties)).EndInit();
            this.panel138.ResumeLayout(false);
            this.panel22.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.NORTH.Properties)).EndInit();
            this.panel84.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SOUTH.Properties)).EndInit();
            this.panel16.ResumeLayout(false);
            this.panel78.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.WEST.Properties)).EndInit();
            this.panel75.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.EAST.Properties)).EndInit();
            this.panel120.ResumeLayout(false);
            this.panel144.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.XIAODM.Properties)).EndInit();
            this.panel7.ResumeLayout(false);
            this.panel121.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.XI_BAN.Properties)).EndInit();
            this.panel122.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.XIAO_BAN.Properties)).EndInit();
            this.panel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.LIN_BAN.Properties)).EndInit();
            this.panel10.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel11.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panelHarvest.ResumeLayout(false);
            this.panel36.ResumeLayout(false);
            this.panel13.ResumeLayout(false);
            this.panel101.ResumeLayout(false);
            this.panel49.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.FMFF.Properties)).EndInit();
            this.panel39.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CFSJ.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CFSJ.Properties)).EndInit();
            this.panel71.ResumeLayout(false);
            this.panel74.ResumeLayout(false);
            this.panel15.ResumeLayout(false);
            this.panel60.ResumeLayout(false);
            this.panel103.ResumeLayout(false);
            this.panel48.ResumeLayout(false);
            this.panel50.ResumeLayout(false);
            this.panel102.ResumeLayout(false);
            this.panel45.ResumeLayout(false);
            this.panel52.ResumeLayout(false);
            this.panelUpdate.ResumeLayout(false);
            this.panel108.ResumeLayout(false);
            this.panel81.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.QTSM.Properties)).EndInit();
            this.panel118.ResumeLayout(false);
            this.panel115.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GXZRR.Properties)).EndInit();
            this.panel12.ResumeLayout(false);
            this.panel94.ResumeLayout(false);
            this.panel95.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.FYCS.Properties)).EndInit();
            this.panel96.ResumeLayout(false);
            this.panel28.ResumeLayout(false);
            this.panel113.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MIAOMUGG.Properties)).EndInit();
            this.panel83.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ZHUHJ.Properties)).EndInit();
            this.panel87.ResumeLayout(false);
            this.panel72.ResumeLayout(false);
            this.panel17.ResumeLayout(false);
            this.panel111.ResumeLayout(false);
            this.panel59.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GENGXINSJ.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GENGXINSJ.Properties)).EndInit();
            this.panel88.ResumeLayout(false);
            this.panel119.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ZDGG.Properties)).EndInit();
            this.panel93.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ZDFS.Properties)).EndInit();
            this.panel8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.textEdit36.Properties)).EndInit();
            this.panel89.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.textEdit51.Properties)).EndInit();
            this.panel90.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit16.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit52.Properties)).EndInit();
            this.panelOther.ResumeLayout(false);
            this.panel86.ResumeLayout(false);
            this.panel91.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GXSJ.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GXSJ.Properties)).EndInit();
            this.panel92.ResumeLayout(false);
            this.panelPage1.ResumeLayout(false);
            this.panelControl1.ResumeLayout(false);
            this.panelHarTable.ResumeLayout(false);
            this.panelTitle1.ResumeLayout(false);
            this.panel132.ResumeLayout(false);
            this.panel134.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SJRY.Properties)).EndInit();
            this.panel135.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DCRY.Properties)).EndInit();
            this.panel136.ResumeLayout(false);
            this.panel137.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SJBH.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.YML.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ZLMD.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GXMJ.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BLMYBD.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CFQD.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CFMJ.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CFCS.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ZXJ.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FQZS.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PJGF.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HUO_LMGQXJ.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MEI_GQ_ZS.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SSXJ.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SSZZS.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.YU_BI_DU.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PINGJUN_NL.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TU_CENG_HD.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HBG.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PINGJUN_SG.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PINGJUN_XJ.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MIAN_JI.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit3.Properties)).EndInit();
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

        public void ShowJCTable(IFeature pFeature)
        {
            FormMMJC mmmjc = new FormMMJC();
            mmmjc.Init(this, pFeature, true);
            mmmjc.WindowState = FormWindowState.Maximized;
            mmmjc.ShowDialog(this);
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

        public delegate void PrintHarvesthandler();

        public delegate void ShowJCTablehandler(bool bShow);
    }
}

