namespace AttributesEdit
{
    using DevExpress.Utils;
    using DevExpress.XtraEditors;
    using DevExpress.XtraEditors.Controls;
    using DevExpress.XtraEditors.Mask;
    using ESRI.ArcGIS.Controls;
    using ESRI.ArcGIS.Geometry;
    using FormBase;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    public class UserControlSubAttr : UserControlBase1
    {
        private ZLComboBox BCLD;
        private ZLComboBox BH_DJ;
        private TextEdit BHND;
        private ZLComboBox BHYY;
        private ZLComboBox BSSZ;
        private ZLSpinEdit BSSZGQDM;
        private ZLSpinEdit BSSZGQZS;
        private ZLSpinEdit BSSZNL;
        private ZLSpinEdit BSSZPJXJ;
        private ZLComboBox BSSZQY;
        private ZLSpinEdit BSSZSG;
        private ZLSpinEdit BSSZXJ;
        private SimpleButton buttonSetChangeTool;
        private SimpleButton buttonSetXBTool;
        private ZLSpinEdit CBPJGD;
        private ZLComboBox CBYSZ;
        private ZLComboBox CCLDJ;
        private ZLSpinEdit CMZGD;
        private IContainer components;
        private ZLComboBox CTMY;
        private ZLComboBox CUN;
        private ZLComboBox DI_LEI;
        private ZLComboBox DI_MAO;
        private ZLComboBox DISASTER_C;
        private ZLComboBox DISPE;
        private ZLSpinEdit FRZLDW;
        private ZLSpinEdit FZCH;
        private ZLComboBox G_CHENG_LB;
        private ZLComboBox GBHJZSL;
        private ZLComboBox GJGYL_BHDJ;
        private ZLSpinEdit GMPJGD;
        private ZLComboBox GMYSZ;
        private ZLSpinEdit GMZGD;
        private ZLComboBox GXFBQK;
        private ZLSpinEdit GXGQZS;
        private ZLSpinEdit GXPJGD;
        private ZLSpinEdit GXPJNL;
        private DateEdit GXSJ;
        private ZLComboBox GXSZQK;
        private ZLComboBox GXYSSZ;
        private ZLSpinEdit HBG;
        private ZLSpinEdit HUO_LMGQXJ;
        private ZLComboBox JJLCQ;
        private ZLComboBox JKZK;
        private ZLComboBox JYCSLX;
        private ZLComboBox JYGLLX;
        private TextEdit JYLX;
        private ZLComboBox KE_JI_DU;
        private ZLComboBox KJD;
        private ZLSpinEdit KZLYH;
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
        private Label label120;
        private Label label121;
        private Label label122;
        private Label label123;
        private Label label124;
        private Label label125;
        private Label label126;
        private Label label127;
        private Label label128;
        private Label label129;
        private Label label13;
        private Label label130;
        private Label label131;
        private Label label132;
        private Label label133;
        private Label label134;
        private Label label135;
        private Label label136;
        private Label label137;
        private Label label138;
        private Label label139;
        private Label label14;
        private Label label140;
        private Label label141;
        private Label label142;
        private Label label143;
        private Label label148;
        private Label label15;
        private Label label152;
        private Label label156;
        private Label label16;
        private Label label160;
        private Label label161;
        private Label label162;
        private Label label163;
        private Label label168;
        private Label label172;
        private Label label176;
        private Label label18;
        private Label label180;
        private Label label181;
        private Label label182;
        private Label label183;
        private Label label184;
        private Label label185;
        private Label label186;
        private Label label187;
        private Label label188;
        private Label label189;
        private Label label190;
        private Label label191;
        private Label label192;
        private Label label193;
        private Label label194;
        private Label label195;
        private Label label196;
        private Label label197;
        private Label label198;
        private Label label2;
        private Label label200;
        private Label label201;
        private Label label202;
        private Label label203;
        private Label label204;
        private Label label205;
        private Label label206;
        private Label label207;
        private Label label208;
        private Label label209;
        private Label label21;
        private Label label210;
        private Label label211;
        private Label label212;
        private Label label213;
        private Label label214;
        private Label label215;
        private Label label216;
        private Label label217;
        private Label label219;
        private Label label220;
        private Label label221;
        private Label label224;
        private Label label225;
        private Label label226;
        private Label label228;
        private Label label229;
        private Label label23;
        private Label label230;
        private Label label231;
        private Label label232;
        private Label label233;
        private Label label234;
        private Label label235;
        private Label label236;
        private Label label237;
        private Label label238;
        private Label label239;
        private Label label24;
        private Label label240;
        private Label label241;
        private Label label242;
        private Label label243;
        private Label label244;
        private Label label245;
        private Label label246;
        private Label label247;
        private Label label249;
        private Label label25;
        private Label label250;
        private Label label251;
        private Label label252;
        private Label label253;
        private Label label254;
        private Label label255;
        private Label label259;
        private Label label26;
        private Label label260;
        private Label label261;
        private Label label262;
        private Label label263;
        private Label label27;
        private Label label28;
        private Label label280;
        private Label label281;
        private Label label282;
        private Label label283;
        private Label label284;
        private Label label285;
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
        private Label labelAttr2;
        private Label labelAttr3;
        private Label labelAttr4;
        private Label labelAttr5;
        private Label labelAttr6;
        private Label labelAttr8;
        private Label laBHND;
        private Label laBHYY;
        private Label laBSSZXJ;
        private Label laCUN;
        private Label laDI_LEI;
        private Label laGXSJ;
        private Label laHUO_LMGQXJ;
        private Label laLD_QS;
        private Label laLIN_BAN;
        private Label laLIN_CHANG;
        private Label laLIN_YE_JU;
        private Label laLIN_ZHONG;
        private Label laLING_ZU;
        private Label laLJ;
        private Label laLMJYQ;
        private Label laLMSYQ;
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
        private Label laSEN_LIN_LB;
        private Label laSHENG;
        private Label laSHI;
        private Label laSLXJ;
        private Label laSSXJ;
        private Label laTDJYQ;
        private Label laXI_BAN;
        private Label laXIAN;
        private Label laXIANG;
        private Label laXIAO_BAN;
        private Label laYOU_SHI_SZ;
        private Label laYSSZXJ;
        private Label laYU_BI_DU;
        private Label laZXJ;
        private ZLSpinEdit LD_CD;
        private ZLSpinEdit LD_KD;
        private ZLComboBox LD_QS;
        private ZLSpinEdit LDSYDW;
        private TextEdit LIN_BAN;
        private TextEdit LIN_CHANG;
        private TextEdit LIN_YE_JU;
        private ZLComboBox LIN_ZHONG;
        private ZLComboBox LING_ZU;
        private TextEdit LJ;
        private ZLComboBox LMJYQ;
        private ZLComboBox LMSYQ;
        private ZLComboBox LYFQ;
        private IHookHelper m_hookHelper;
        private ToolGetAttributes m_Tool;
        private ZLSpinEdit MEI_GQ_ZS;
        private ZLSpinEdit MIAN_JI;
        private IPoint mPoint;
        private int mType;
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
        private Panel panel116;
        private Panel panel117;
        private Panel panel118;
        private Panel panel119;
        private Panel panel12;
        private Panel panel120;
        private Panel panel121;
        private Panel panel122;
        private Panel panel123;
        private Panel panel124;
        private Panel panel125;
        private Panel panel126;
        private Panel panel127;
        private Panel panel128;
        private Panel panel129;
        private Panel panel13;
        private Panel panel130;
        private Panel panel131;
        private Panel panel132;
        private Panel panel133;
        private Panel panel134;
        private Panel panel135;
        private Panel panel136;
        private Panel panel137;
        private Panel panel138;
        private Panel panel139;
        private Panel panel14;
        private Panel panel140;
        private Panel panel141;
        private Panel panel142;
        private Panel panel143;
        private Panel panel144;
        private Panel panel145;
        private Panel panel146;
        private Panel panel147;
        private Panel panel148;
        private Panel panel149;
        private Panel panel15;
        private Panel panel150;
        private Panel panel151;
        private Panel panel152;
        private Panel panel153;
        private Panel panel154;
        private Panel panel155;
        private Panel panel156;
        private Panel panel157;
        private Panel panel158;
        private Panel panel159;
        private Panel panel16;
        private Panel panel160;
        private Panel panel161;
        private Panel panel162;
        private Panel panel163;
        private Panel panel164;
        private Panel panel165;
        private Panel panel166;
        private Panel panel167;
        private Panel panel168;
        private Panel panel169;
        private Panel panel17;
        private Panel panel170;
        private Panel panel171;
        private Panel panel172;
        private Panel panel173;
        private Panel panel174;
        private Panel panel175;
        private Panel panel176;
        private Panel panel177;
        private Panel panel178;
        private Panel panel179;
        private Panel panel18;
        private Panel panel180;
        private Panel panel181;
        private Panel panel182;
        private Panel panel183;
        private Panel panel184;
        private Panel panel185;
        private Panel panel186;
        private Panel panel187;
        private Panel panel188;
        private Panel panel189;
        private Panel panel19;
        private Panel panel191;
        private Panel panel192;
        private Panel panel2;
        private Panel panel20;
        private Panel panel206;
        private Panel panel209;
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
        private Panel panelAll;
        private Panel panelAttr1;
        private Panel panelAttr11;
        private Panel panelAttr2;
        private Panel panelAttr21;
        private Panel panelAttr3;
        private Panel panelAttr31;
        private Panel panelAttr4;
        private Panel panelAttr41;
        private Panel panelAttr5;
        private Panel panelAttr51;
        private Panel panelAttr6;
        private Panel panelAttr61;
        private Panel panelAttr7;
        private Panel panelAttr71;
        private Panel panelAttr8;
        private Panel panelAttr81;
        private Panel panelLeft;
        private Panel panelRight;
        private Panel panelTop;
        private ZLSpinEdit PINGJUN_DM;
        private ZLSpinEdit PINGJUN_NL;
        private ZLSpinEdit PINGJUN_SG;
        private ZLSpinEdit PINGJUN_XJ;
        private ZLComboBox PO_DU;
        private ZLComboBox PO_WEI;
        private ZLComboBox PO_XIANG;
        private ZLComboBox Q_BH_DJ;
        private ZLSpinEdit Q_BSSZGQDM;
        private ZLSpinEdit Q_BSSZNL;
        private ZLSpinEdit Q_BSSZPJXJ;
        private ZLSpinEdit Q_BSSZSG;
        private ZLSpinEdit Q_BSSZXJ;
        private ZLComboBox Q_DI_LEI;
        private ZLComboBox Q_GC_LB;
        private ZLComboBox Q_LD_QS;
        private ZLComboBox Q_LIN_ZHONG;
        private ZLSpinEdit Q_MJ;
        private ZLSpinEdit Q_PJDM;
        private ZLSpinEdit Q_PJNL;
        private ZLSpinEdit Q_PJSG;
        private ZLSpinEdit Q_PJXJ;
        private ZLComboBox Q_SEN_LB;
        private ZLComboBox Q_SQ_D;
        private ZLSpinEdit Q_SSXJ;
        private ZLComboBox Q_SZ;
        private ZLSpinEdit Q_YBD;
        private ZLSpinEdit Q_YSSZXJ;
        private ZLSpinEdit Q_ZXJ;
        private ZLComboBox QHFQBH;
        private ZLComboBox QI_YUAN;
        private ZLComboBox QLJG;
        private ZLComboBox QSCD;
        private ZLComboBox QSLX;
        private ZLComboBox QYKZ;
        private TextEdit Remarks;
        private ZLComboBox SDLX;
        private ZLComboBox SEN_LIN_LB;
        private ZLComboBox SHCD;
        private ZLComboBox SHENG;
        private ZLComboBox SHI;
        private ZLComboBox SHI_QUAN_D;
        private ZLComboBox SHLX;
        private ZLSpinEdit SLHL;
        private ZLSpinEdit SLXJ;
        private ZLComboBox SMHCD;
        private ZLComboBox SMHCY;
        private ZLComboBox SMHLX;
        private ZLComboBox SSLX;
        private ZLSpinEdit SSPJGD;
        private ZLSpinEdit SSPJXJ;
        private ZLSpinEdit SSXJ;
        private ZLComboBox SSZYSZ;
        private ZLSpinEdit SSZZS;
        private ZLComboBox STQW;
        private ZLComboBox TD_TH_LX;
        private ZLComboBox TDJYQ;
        private ZLSpinEdit TU_CENG_HD;
        private ZLComboBox TU_RANG_LX;
        private TextEdit XI_BAN;
        private ZLComboBox XIAN;
        private ZLComboBox XIANG;
        private TextEdit XIAO_BAN;
        private ZLComboBox XJBDJ;
        private TabControl xtraTabControl1;
        private TabPage xtraTabPage1;
        private TabPage xtraTabPage2;
        private TabPage xtraTabPage3;
        private ZLSpinEdit XZWCD;
        private ZLSpinEdit XZWKD;
        private ZLSpinEdit XZWMJ;
        private ZLComboBox XZWZL;
        private ZLComboBox YOU_SHI_SZ;
        private ZLSpinEdit YSMG;
        private ZLSpinEdit YSSZXJ;
        private ZLSpinEdit YU_BI_DU;
        private ZLSpinEdit YXMJ;
        private ZLSpinEdit ZFNL;
        private ZLComboBox ZL_DJ;
        private ZLSpinEdit ZLND;
        private ZLComboBox ZRD;
        private ZLSpinEdit ZXJ;

        public event GetAttributeshandler OnGetAttributes;

        public UserControlSubAttr()
        {
            this.InitializeComponent();
            this.SHENG.SelectedIndexChanged += new EventHandler(this.SHENG_SelectedIndexChanged);
            this.SHI.SelectedIndexChanged += new EventHandler(this.SHI_SelectedIndexChanged);
            this.XIAN.SelectedIndexChanged += new EventHandler(this.XIAN_SelectedIndexChanged);
            this.XIANG.SelectedIndexChanged += new EventHandler(this.XIANG_SelectedIndexChanged);
        }

        private void buttonSetChangeTool_Click(object sender, EventArgs e)
        {
            this.GetPointTool(1);
        }

        private void buttonSetXBTool_Click(object sender, EventArgs e)
        {
            this.GetPointTool(0);
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
            if (index == 0x2b)
            {
                this.xtraTabControl1.SelectedIndex = 1;
            }
            else if (index == 0x54)
            {
                this.xtraTabControl1.SelectedIndex = 2;
            }
            else if (index == 0x7a)
            {
                this.xtraTabControl1.SelectedIndex = 0;
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
                Control control;
                if (control2 is Panel)
                {
                    control = this.GetControl(control2, index);
                    if (control != null)
                    {
                        return control;
                    }
                }
                else if (control2 is TabControl)
                {
                    control = this.GetControl(control2, index);
                    if (control != null)
                    {
                        return control;
                    }
                }
                else if (control2 is TabPage)
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

        private void GetPointTool(int iType)
        {
            try
            {
                this.mType = iType;
                IMapControl2 hook = (IMapControl2) this.m_hookHelper.Hook;
                hook.CurrentTool = this.m_Tool;
            }
            catch (Exception)
            {
            }
        }

        public void Init(object hook)
        {
            if (this.m_hookHelper == null)
            {
                this.m_hookHelper = new HookHelperClass();
            }
            this.m_hookHelper.Hook = hook;
            this.m_Tool = new ToolGetAttributes();
            this.m_Tool.ParentUsercontrol = this;
            this.m_Tool.OnCreate(this.m_hookHelper.Hook);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserControlSubAttr));
            this.xtraTabControl1 = new System.Windows.Forms.TabControl();
            this.xtraTabPage1 = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelAttr8 = new System.Windows.Forms.Panel();
            this.panelAttr81 = new System.Windows.Forms.Panel();
            this.panel62 = new System.Windows.Forms.Panel();
            this.panel178 = new System.Windows.Forms.Panel();
            this.Q_SSXJ = new AttributesEdit.ZLSpinEdit();
            this.label247 = new System.Windows.Forms.Label();
            this.label246 = new System.Windows.Forms.Label();
            this.panel177 = new System.Windows.Forms.Panel();
            this.Q_BSSZXJ = new AttributesEdit.ZLSpinEdit();
            this.label245 = new System.Windows.Forms.Label();
            this.label233 = new System.Windows.Forms.Label();
            this.panel175 = new System.Windows.Forms.Panel();
            this.Q_BSSZGQDM = new AttributesEdit.ZLSpinEdit();
            this.label238 = new System.Windows.Forms.Label();
            this.label239 = new System.Windows.Forms.Label();
            this.label240 = new System.Windows.Forms.Label();
            this.panel58 = new System.Windows.Forms.Panel();
            this.panel173 = new System.Windows.Forms.Panel();
            this.Q_BSSZPJXJ = new AttributesEdit.ZLSpinEdit();
            this.label236 = new System.Windows.Forms.Label();
            this.label237 = new System.Windows.Forms.Label();
            this.panel59 = new System.Windows.Forms.Panel();
            this.Q_BSSZSG = new AttributesEdit.ZLSpinEdit();
            this.label229 = new System.Windows.Forms.Label();
            this.label230 = new System.Windows.Forms.Label();
            this.panel61 = new System.Windows.Forms.Panel();
            this.Q_BSSZNL = new AttributesEdit.ZLSpinEdit();
            this.label234 = new System.Windows.Forms.Label();
            this.label235 = new System.Windows.Forms.Label();
            this.panel182 = new System.Windows.Forms.Panel();
            this.panel176 = new System.Windows.Forms.Panel();
            this.Q_YSSZXJ = new AttributesEdit.ZLSpinEdit();
            this.label244 = new System.Windows.Forms.Label();
            this.label241 = new System.Windows.Forms.Label();
            this.panel179 = new System.Windows.Forms.Panel();
            this.Q_ZXJ = new AttributesEdit.ZLSpinEdit();
            this.label242 = new System.Windows.Forms.Label();
            this.label243 = new System.Windows.Forms.Label();
            this.panel183 = new System.Windows.Forms.Panel();
            this.Q_PJDM = new AttributesEdit.ZLSpinEdit();
            this.label249 = new System.Windows.Forms.Label();
            this.label250 = new System.Windows.Forms.Label();
            this.label255 = new System.Windows.Forms.Label();
            this.panel186 = new System.Windows.Forms.Panel();
            this.panel184 = new System.Windows.Forms.Panel();
            this.Q_PJSG = new AttributesEdit.ZLSpinEdit();
            this.label251 = new System.Windows.Forms.Label();
            this.label252 = new System.Windows.Forms.Label();
            this.panel185 = new System.Windows.Forms.Panel();
            this.Q_PJXJ = new AttributesEdit.ZLSpinEdit();
            this.label253 = new System.Windows.Forms.Label();
            this.label254 = new System.Windows.Forms.Label();
            this.panel189 = new System.Windows.Forms.Panel();
            this.Q_PJNL = new AttributesEdit.ZLSpinEdit();
            this.label259 = new System.Windows.Forms.Label();
            this.label260 = new System.Windows.Forms.Label();
            this.panel206 = new System.Windows.Forms.Panel();
            this.panel191 = new System.Windows.Forms.Panel();
            this.Q_YBD = new AttributesEdit.ZLSpinEdit();
            this.label261 = new System.Windows.Forms.Label();
            this.label262 = new System.Windows.Forms.Label();
            this.panel192 = new System.Windows.Forms.Panel();
            this.Q_SZ = new AttributesEdit.ZLComboBox();
            this.label263 = new System.Windows.Forms.Label();
            this.panel209 = new System.Windows.Forms.Panel();
            this.Q_MJ = new AttributesEdit.ZLSpinEdit();
            this.label280 = new System.Windows.Forms.Label();
            this.label281 = new System.Windows.Forms.Label();
            this.label282 = new System.Windows.Forms.Label();
            this.label283 = new System.Windows.Forms.Label();
            this.label284 = new System.Windows.Forms.Label();
            this.label285 = new System.Windows.Forms.Label();
            this.labelAttr8 = new System.Windows.Forms.Label();
            this.panelAttr7 = new System.Windows.Forms.Panel();
            this.panelAttr71 = new System.Windows.Forms.Panel();
            this.panel171 = new System.Windows.Forms.Panel();
            this.panel168 = new System.Windows.Forms.Panel();
            this.BSSZXJ = new AttributesEdit.ZLSpinEdit();
            this.label136 = new System.Windows.Forms.Label();
            this.laBSSZXJ = new System.Windows.Forms.Label();
            this.panel174 = new System.Windows.Forms.Panel();
            this.SSXJ = new AttributesEdit.ZLSpinEdit();
            this.label135 = new System.Windows.Forms.Label();
            this.laSSXJ = new System.Windows.Forms.Label();
            this.label228 = new System.Windows.Forms.Label();
            this.panel167 = new System.Windows.Forms.Panel();
            this.panel169 = new System.Windows.Forms.Panel();
            this.YSSZXJ = new AttributesEdit.ZLSpinEdit();
            this.label134 = new System.Windows.Forms.Label();
            this.laYSSZXJ = new System.Windows.Forms.Label();
            this.panel170 = new System.Windows.Forms.Panel();
            this.SLXJ = new AttributesEdit.ZLSpinEdit();
            this.label129 = new System.Windows.Forms.Label();
            this.laSLXJ = new System.Windows.Forms.Label();
            this.label224 = new System.Windows.Forms.Label();
            this.panel121 = new System.Windows.Forms.Panel();
            this.panel122 = new System.Windows.Forms.Panel();
            this.ZXJ = new AttributesEdit.ZLSpinEdit();
            this.label98 = new System.Windows.Forms.Label();
            this.laZXJ = new System.Windows.Forms.Label();
            this.panel123 = new System.Windows.Forms.Panel();
            this.MEI_GQ_ZS = new AttributesEdit.ZLSpinEdit();
            this.label80 = new System.Windows.Forms.Label();
            this.laMEI_GQ_ZS = new System.Windows.Forms.Label();
            this.panel124 = new System.Windows.Forms.Panel();
            this.HUO_LMGQXJ = new AttributesEdit.ZLSpinEdit();
            this.label76 = new System.Windows.Forms.Label();
            this.laHUO_LMGQXJ = new System.Windows.Forms.Label();
            this.label180 = new System.Windows.Forms.Label();
            this.panel117 = new System.Windows.Forms.Panel();
            this.panel118 = new System.Windows.Forms.Panel();
            this.PINGJUN_DM = new AttributesEdit.ZLSpinEdit();
            this.label65 = new System.Windows.Forms.Label();
            this.laPINGJUN_DM = new System.Windows.Forms.Label();
            this.panel119 = new System.Windows.Forms.Panel();
            this.PINGJUN_SG = new AttributesEdit.ZLSpinEdit();
            this.label66 = new System.Windows.Forms.Label();
            this.laPINGJUN_SG = new System.Windows.Forms.Label();
            this.panel120 = new System.Windows.Forms.Panel();
            this.PINGJUN_XJ = new AttributesEdit.ZLSpinEdit();
            this.label67 = new System.Windows.Forms.Label();
            this.laPINGJUN_XJ = new System.Windows.Forms.Label();
            this.label176 = new System.Windows.Forms.Label();
            this.panel78 = new System.Windows.Forms.Panel();
            this.panel104 = new System.Windows.Forms.Panel();
            this.LING_ZU = new AttributesEdit.ZLComboBox();
            this.laLING_ZU = new System.Windows.Forms.Label();
            this.panel106 = new System.Windows.Forms.Panel();
            this.LJ = new DevExpress.XtraEditors.TextEdit();
            this.laLJ = new System.Windows.Forms.Label();
            this.panel116 = new System.Windows.Forms.Panel();
            this.PINGJUN_NL = new AttributesEdit.ZLSpinEdit();
            this.label64 = new System.Windows.Forms.Label();
            this.laPINGJUN_NL = new System.Windows.Forms.Label();
            this.label172 = new System.Windows.Forms.Label();
            this.panel50 = new System.Windows.Forms.Panel();
            this.panel56 = new System.Windows.Forms.Panel();
            this.YU_BI_DU = new AttributesEdit.ZLSpinEdit();
            this.label62 = new System.Windows.Forms.Label();
            this.laYU_BI_DU = new System.Windows.Forms.Label();
            this.panel74 = new System.Windows.Forms.Panel();
            this.YOU_SHI_SZ = new AttributesEdit.ZLComboBox();
            this.laYOU_SHI_SZ = new System.Windows.Forms.Label();
            this.panel75 = new System.Windows.Forms.Panel();
            this.QI_YUAN = new AttributesEdit.ZLComboBox();
            this.laQI_YUAN = new System.Windows.Forms.Label();
            this.label168 = new System.Windows.Forms.Label();
            this.panel130 = new System.Windows.Forms.Panel();
            this.panel131 = new System.Windows.Forms.Panel();
            this.LIN_ZHONG = new AttributesEdit.ZLComboBox();
            this.laLIN_ZHONG = new System.Windows.Forms.Label();
            this.panel132 = new System.Windows.Forms.Panel();
            this.Q_LIN_ZHONG = new AttributesEdit.ZLComboBox();
            this.laQ_LIN_ZHONG = new System.Windows.Forms.Label();
            this.panel133 = new System.Windows.Forms.Panel();
            this.SEN_LIN_LB = new AttributesEdit.ZLComboBox();
            this.laSEN_LIN_LB = new System.Windows.Forms.Label();
            this.label148 = new System.Windows.Forms.Label();
            this.panel134 = new System.Windows.Forms.Panel();
            this.panel135 = new System.Windows.Forms.Panel();
            this.Q_SEN_LB = new AttributesEdit.ZLComboBox();
            this.laQ_SEN_LB = new System.Windows.Forms.Label();
            this.panel136 = new System.Windows.Forms.Panel();
            this.DI_LEI = new AttributesEdit.ZLComboBox();
            this.laDI_LEI = new System.Windows.Forms.Label();
            this.panel137 = new System.Windows.Forms.Panel();
            this.Q_DI_LEI = new AttributesEdit.ZLComboBox();
            this.laQ_DI_LEI = new System.Windows.Forms.Label();
            this.label152 = new System.Windows.Forms.Label();
            this.panel138 = new System.Windows.Forms.Panel();
            this.panel139 = new System.Windows.Forms.Panel();
            this.LMJYQ = new AttributesEdit.ZLComboBox();
            this.laLMJYQ = new System.Windows.Forms.Label();
            this.panel140 = new System.Windows.Forms.Panel();
            this.LMSYQ = new AttributesEdit.ZLComboBox();
            this.laLMSYQ = new System.Windows.Forms.Label();
            this.panel141 = new System.Windows.Forms.Panel();
            this.TDJYQ = new AttributesEdit.ZLComboBox();
            this.laTDJYQ = new System.Windows.Forms.Label();
            this.label156 = new System.Windows.Forms.Label();
            this.panel142 = new System.Windows.Forms.Panel();
            this.panel143 = new System.Windows.Forms.Panel();
            this.LD_QS = new AttributesEdit.ZLComboBox();
            this.laLD_QS = new System.Windows.Forms.Label();
            this.panel144 = new System.Windows.Forms.Panel();
            this.Q_LD_QS = new AttributesEdit.ZLComboBox();
            this.laQ_LD_QS = new System.Windows.Forms.Label();
            this.panel145 = new System.Windows.Forms.Panel();
            this.MIAN_JI = new AttributesEdit.ZLSpinEdit();
            this.label141 = new System.Windows.Forms.Label();
            this.laMIAN_JI = new System.Windows.Forms.Label();
            this.label160 = new System.Windows.Forms.Label();
            this.label161 = new System.Windows.Forms.Label();
            this.label162 = new System.Windows.Forms.Label();
            this.label163 = new System.Windows.Forms.Label();
            this.labelAttr2 = new System.Windows.Forms.Label();
            this.panelAttr2 = new System.Windows.Forms.Panel();
            this.panelAttr21 = new System.Windows.Forms.Panel();
            this.panel23 = new System.Windows.Forms.Panel();
            this.panel28 = new System.Windows.Forms.Panel();
            this.BHND = new DevExpress.XtraEditors.TextEdit();
            this.laBHND = new System.Windows.Forms.Label();
            this.panel25 = new System.Windows.Forms.Panel();
            this.GXSJ = new DevExpress.XtraEditors.DateEdit();
            this.laGXSJ = new System.Windows.Forms.Label();
            this.panel26 = new System.Windows.Forms.Panel();
            this.BHYY = new AttributesEdit.ZLComboBox();
            this.laBHYY = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.labelAttr3 = new System.Windows.Forms.Label();
            this.panelAttr1 = new System.Windows.Forms.Panel();
            this.panelAttr11 = new System.Windows.Forms.Panel();
            this.panel19 = new System.Windows.Forms.Panel();
            this.panel166 = new System.Windows.Forms.Panel();
            this.XI_BAN = new DevExpress.XtraEditors.TextEdit();
            this.laXI_BAN = new System.Windows.Forms.Label();
            this.panel43 = new System.Windows.Forms.Panel();
            this.XIAO_BAN = new DevExpress.XtraEditors.TextEdit();
            this.laXIAO_BAN = new System.Windows.Forms.Label();
            this.panel20 = new System.Windows.Forms.Panel();
            this.LIN_BAN = new DevExpress.XtraEditors.TextEdit();
            this.laLIN_BAN = new System.Windows.Forms.Label();
            this.panel21 = new System.Windows.Forms.Panel();
            this.LIN_CHANG = new DevExpress.XtraEditors.TextEdit();
            this.laLIN_CHANG = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.panel12 = new System.Windows.Forms.Panel();
            this.panel49 = new System.Windows.Forms.Panel();
            this.LIN_YE_JU = new DevExpress.XtraEditors.TextEdit();
            this.laLIN_YE_JU = new System.Windows.Forms.Label();
            this.panel16 = new System.Windows.Forms.Panel();
            this.CUN = new AttributesEdit.ZLComboBox();
            this.laCUN = new System.Windows.Forms.Label();
            this.panel18 = new System.Windows.Forms.Panel();
            this.XIANG = new AttributesEdit.ZLComboBox();
            this.laXIANG = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.panel13 = new System.Windows.Forms.Panel();
            this.panel115 = new System.Windows.Forms.Panel();
            this.XIAN = new AttributesEdit.ZLComboBox();
            this.laXIAN = new System.Windows.Forms.Label();
            this.panel53 = new System.Windows.Forms.Panel();
            this.SHI = new AttributesEdit.ZLComboBox();
            this.laSHI = new System.Windows.Forms.Label();
            this.panel15 = new System.Windows.Forms.Panel();
            this.SHENG = new AttributesEdit.ZLComboBox();
            this.laSHENG = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label90 = new System.Windows.Forms.Label();
            this.label91 = new System.Windows.Forms.Label();
            this.label92 = new System.Windows.Forms.Label();
            this.panelTop = new System.Windows.Forms.Panel();
            this.buttonSetChangeTool = new DevExpress.XtraEditors.SimpleButton();
            this.panel14 = new System.Windows.Forms.Panel();
            this.buttonSetXBTool = new DevExpress.XtraEditors.SimpleButton();
            this.xtraTabPage2 = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panelAttr4 = new System.Windows.Forms.Panel();
            this.panelAttr41 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.panel22 = new System.Windows.Forms.Panel();
            this.JKZK = new AttributesEdit.ZLComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.panel11 = new System.Windows.Forms.Panel();
            this.ZRD = new AttributesEdit.ZLComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel17 = new System.Windows.Forms.Panel();
            this.QLJG = new AttributesEdit.ZLComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.panel151 = new System.Windows.Forms.Panel();
            this.panel10 = new System.Windows.Forms.Panel();
            this.SDLX = new AttributesEdit.ZLComboBox();
            this.label198 = new System.Windows.Forms.Label();
            this.panel152 = new System.Windows.Forms.Panel();
            this.SHCD = new AttributesEdit.ZLComboBox();
            this.label200 = new System.Windows.Forms.Label();
            this.panel153 = new System.Windows.Forms.Panel();
            this.SHLX = new AttributesEdit.ZLComboBox();
            this.label201 = new System.Windows.Forms.Label();
            this.label202 = new System.Windows.Forms.Label();
            this.panel148 = new System.Windows.Forms.Panel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.SMHCY = new AttributesEdit.ZLComboBox();
            this.label193 = new System.Windows.Forms.Label();
            this.panel149 = new System.Windows.Forms.Panel();
            this.SMHCD = new AttributesEdit.ZLComboBox();
            this.label195 = new System.Windows.Forms.Label();
            this.panel150 = new System.Windows.Forms.Panel();
            this.SMHLX = new AttributesEdit.ZLComboBox();
            this.label196 = new System.Windows.Forms.Label();
            this.label197 = new System.Windows.Forms.Label();
            this.panel129 = new System.Windows.Forms.Panel();
            this.panel29 = new System.Windows.Forms.Panel();
            this.CTMY = new AttributesEdit.ZLComboBox();
            this.label53 = new System.Windows.Forms.Label();
            this.panel146 = new System.Windows.Forms.Panel();
            this.QSCD = new AttributesEdit.ZLComboBox();
            this.label190 = new System.Windows.Forms.Label();
            this.panel147 = new System.Windows.Forms.Panel();
            this.QSLX = new AttributesEdit.ZLComboBox();
            this.label191 = new System.Windows.Forms.Label();
            this.label192 = new System.Windows.Forms.Label();
            this.panel73 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.FZCH = new AttributesEdit.ZLSpinEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.label187 = new System.Windows.Forms.Label();
            this.panel76 = new System.Windows.Forms.Panel();
            this.SLHL = new AttributesEdit.ZLSpinEdit();
            this.label133 = new System.Windows.Forms.Label();
            this.label78 = new System.Windows.Forms.Label();
            this.label79 = new System.Windows.Forms.Label();
            this.panel77 = new System.Windows.Forms.Panel();
            this.panel79 = new System.Windows.Forms.Panel();
            this.KZLYH = new AttributesEdit.ZLSpinEdit();
            this.label137 = new System.Windows.Forms.Label();
            this.label81 = new System.Windows.Forms.Label();
            this.panel80 = new System.Windows.Forms.Panel();
            this.TU_CENG_HD = new AttributesEdit.ZLSpinEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.label82 = new System.Windows.Forms.Label();
            this.label83 = new System.Windows.Forms.Label();
            this.panel81 = new System.Windows.Forms.Panel();
            this.panel82 = new System.Windows.Forms.Panel();
            this.TU_RANG_LX = new AttributesEdit.ZLComboBox();
            this.label84 = new System.Windows.Forms.Label();
            this.panel83 = new System.Windows.Forms.Panel();
            this.PO_DU = new AttributesEdit.ZLComboBox();
            this.label85 = new System.Windows.Forms.Label();
            this.panel84 = new System.Windows.Forms.Panel();
            this.PO_WEI = new AttributesEdit.ZLComboBox();
            this.label86 = new System.Windows.Forms.Label();
            this.label87 = new System.Windows.Forms.Label();
            this.panel85 = new System.Windows.Forms.Panel();
            this.panel86 = new System.Windows.Forms.Panel();
            this.PO_XIANG = new AttributesEdit.ZLComboBox();
            this.label88 = new System.Windows.Forms.Label();
            this.panel87 = new System.Windows.Forms.Panel();
            this.HBG = new AttributesEdit.ZLSpinEdit();
            this.label115 = new System.Windows.Forms.Label();
            this.label89 = new System.Windows.Forms.Label();
            this.panel88 = new System.Windows.Forms.Panel();
            this.DI_MAO = new AttributesEdit.ZLComboBox();
            this.label93 = new System.Windows.Forms.Label();
            this.label94 = new System.Windows.Forms.Label();
            this.label95 = new System.Windows.Forms.Label();
            this.label96 = new System.Windows.Forms.Label();
            this.label97 = new System.Windows.Forms.Label();
            this.labelAttr5 = new System.Windows.Forms.Label();
            this.panelAttr3 = new System.Windows.Forms.Panel();
            this.panelAttr31 = new System.Windows.Forms.Panel();
            this.panel34 = new System.Windows.Forms.Panel();
            this.panel180 = new System.Windows.Forms.Panel();
            this.KJD = new AttributesEdit.ZLComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel172 = new System.Windows.Forms.Panel();
            this.ZFNL = new AttributesEdit.ZLSpinEdit();
            this.label194 = new System.Windows.Forms.Label();
            this.label59 = new System.Windows.Forms.Label();
            this.panel52 = new System.Windows.Forms.Panel();
            this.ZLND = new AttributesEdit.ZLSpinEdit();
            this.label14 = new System.Windows.Forms.Label();
            this.label61 = new System.Windows.Forms.Label();
            this.label63 = new System.Windows.Forms.Label();
            this.panel125 = new System.Windows.Forms.Panel();
            this.panel126 = new System.Windows.Forms.Panel();
            this.KE_JI_DU = new AttributesEdit.ZLComboBox();
            this.label181 = new System.Windows.Forms.Label();
            this.panel127 = new System.Windows.Forms.Panel();
            this.LD_CD = new AttributesEdit.ZLSpinEdit();
            this.label189 = new System.Windows.Forms.Label();
            this.label182 = new System.Windows.Forms.Label();
            this.panel128 = new System.Windows.Forms.Panel();
            this.LD_KD = new AttributesEdit.ZLSpinEdit();
            this.label188 = new System.Windows.Forms.Label();
            this.label183 = new System.Windows.Forms.Label();
            this.label184 = new System.Windows.Forms.Label();
            this.panel35 = new System.Windows.Forms.Panel();
            this.panel36 = new System.Windows.Forms.Panel();
            this.DISASTER_C = new AttributesEdit.ZLComboBox();
            this.label35 = new System.Windows.Forms.Label();
            this.panel37 = new System.Windows.Forms.Panel();
            this.DISPE = new AttributesEdit.ZLComboBox();
            this.label36 = new System.Windows.Forms.Label();
            this.panel188 = new System.Windows.Forms.Panel();
            this.QYKZ = new AttributesEdit.ZLComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label40 = new System.Windows.Forms.Label();
            this.panel39 = new System.Windows.Forms.Panel();
            this.panel40 = new System.Windows.Forms.Panel();
            this.LYFQ = new AttributesEdit.ZLComboBox();
            this.label41 = new System.Windows.Forms.Label();
            this.panel38 = new System.Windows.Forms.Panel();
            this.Q_BH_DJ = new AttributesEdit.ZLComboBox();
            this.label37 = new System.Windows.Forms.Label();
            this.panel42 = new System.Windows.Forms.Panel();
            this.BH_DJ = new AttributesEdit.ZLComboBox();
            this.label42 = new System.Windows.Forms.Label();
            this.label44 = new System.Windows.Forms.Label();
            this.panel41 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.BCLD = new AttributesEdit.ZLComboBox();
            this.label186 = new System.Windows.Forms.Label();
            this.panel44 = new System.Windows.Forms.Panel();
            this.ZL_DJ = new AttributesEdit.ZLComboBox();
            this.label43 = new System.Windows.Forms.Label();
            this.panel46 = new System.Windows.Forms.Panel();
            this.TD_TH_LX = new AttributesEdit.ZLComboBox();
            this.label54 = new System.Windows.Forms.Label();
            this.label60 = new System.Windows.Forms.Label();
            this.panel57 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.GJGYL_BHDJ = new AttributesEdit.ZLComboBox();
            this.label185 = new System.Windows.Forms.Label();
            this.panel60 = new System.Windows.Forms.Panel();
            this.STQW = new AttributesEdit.ZLComboBox();
            this.label231 = new System.Windows.Forms.Label();
            this.label232 = new System.Windows.Forms.Label();
            this.panel51 = new System.Windows.Forms.Panel();
            this.panel181 = new System.Windows.Forms.Panel();
            this.GBHJZSL = new AttributesEdit.ZLComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.panel54 = new System.Windows.Forms.Panel();
            this.G_CHENG_LB = new AttributesEdit.ZLComboBox();
            this.label205 = new System.Windows.Forms.Label();
            this.panel55 = new System.Windows.Forms.Panel();
            this.Q_GC_LB = new AttributesEdit.ZLComboBox();
            this.label225 = new System.Windows.Forms.Label();
            this.label226 = new System.Windows.Forms.Label();
            this.panel45 = new System.Windows.Forms.Panel();
            this.panel47 = new System.Windows.Forms.Panel();
            this.SHI_QUAN_D = new AttributesEdit.ZLComboBox();
            this.label46 = new System.Windows.Forms.Label();
            this.panel48 = new System.Windows.Forms.Panel();
            this.Q_SQ_D = new AttributesEdit.ZLComboBox();
            this.label47 = new System.Windows.Forms.Label();
            this.label48 = new System.Windows.Forms.Label();
            this.label49 = new System.Windows.Forms.Label();
            this.label50 = new System.Windows.Forms.Label();
            this.label51 = new System.Windows.Forms.Label();
            this.labelAttr4 = new System.Windows.Forms.Label();
            this.xtraTabPage3 = new System.Windows.Forms.TabPage();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panelAttr6 = new System.Windows.Forms.Panel();
            this.panelAttr61 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel27 = new System.Windows.Forms.Panel();
            this.Remarks = new DevExpress.XtraEditors.TextEdit();
            this.label28 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.panel154 = new System.Windows.Forms.Panel();
            this.panel33 = new System.Windows.Forms.Panel();
            this.GXSZQK = new AttributesEdit.ZLComboBox();
            this.label204 = new System.Windows.Forms.Label();
            this.panel155 = new System.Windows.Forms.Panel();
            this.GXFBQK = new AttributesEdit.ZLComboBox();
            this.label206 = new System.Windows.Forms.Label();
            this.panel156 = new System.Windows.Forms.Panel();
            this.GXGQZS = new AttributesEdit.ZLSpinEdit();
            this.label33 = new System.Windows.Forms.Label();
            this.label207 = new System.Windows.Forms.Label();
            this.label208 = new System.Windows.Forms.Label();
            this.panel103 = new System.Windows.Forms.Panel();
            this.panel32 = new System.Windows.Forms.Panel();
            this.GXPJGD = new AttributesEdit.ZLSpinEdit();
            this.label32 = new System.Windows.Forms.Label();
            this.label203 = new System.Windows.Forms.Label();
            this.panel113 = new System.Windows.Forms.Panel();
            this.GXPJNL = new AttributesEdit.ZLSpinEdit();
            this.label140 = new System.Windows.Forms.Label();
            this.label130 = new System.Windows.Forms.Label();
            this.panel114 = new System.Windows.Forms.Panel();
            this.GXYSSZ = new AttributesEdit.ZLComboBox();
            this.label131 = new System.Windows.Forms.Label();
            this.label132 = new System.Windows.Forms.Label();
            this.panel99 = new System.Windows.Forms.Panel();
            this.panel100 = new System.Windows.Forms.Panel();
            this.CMZGD = new AttributesEdit.ZLSpinEdit();
            this.label34 = new System.Windows.Forms.Label();
            this.label114 = new System.Windows.Forms.Label();
            this.panel101 = new System.Windows.Forms.Panel();
            this.CBPJGD = new AttributesEdit.ZLSpinEdit();
            this.label45 = new System.Windows.Forms.Label();
            this.label126 = new System.Windows.Forms.Label();
            this.panel102 = new System.Windows.Forms.Panel();
            this.CBYSZ = new AttributesEdit.ZLComboBox();
            this.label127 = new System.Windows.Forms.Label();
            this.label128 = new System.Windows.Forms.Label();
            this.panel95 = new System.Windows.Forms.Panel();
            this.panel96 = new System.Windows.Forms.Panel();
            this.GMZGD = new AttributesEdit.ZLSpinEdit();
            this.label52 = new System.Windows.Forms.Label();
            this.label110 = new System.Windows.Forms.Label();
            this.panel97 = new System.Windows.Forms.Panel();
            this.GMPJGD = new AttributesEdit.ZLSpinEdit();
            this.label56 = new System.Windows.Forms.Label();
            this.label111 = new System.Windows.Forms.Label();
            this.panel98 = new System.Windows.Forms.Panel();
            this.GMYSZ = new AttributesEdit.ZLComboBox();
            this.label112 = new System.Windows.Forms.Label();
            this.label113 = new System.Windows.Forms.Label();
            this.panel91 = new System.Windows.Forms.Panel();
            this.panel92 = new System.Windows.Forms.Panel();
            this.SSPJGD = new AttributesEdit.ZLSpinEdit();
            this.label55 = new System.Windows.Forms.Label();
            this.label106 = new System.Windows.Forms.Label();
            this.panel93 = new System.Windows.Forms.Panel();
            this.SSPJXJ = new AttributesEdit.ZLSpinEdit();
            this.label57 = new System.Windows.Forms.Label();
            this.label107 = new System.Windows.Forms.Label();
            this.panel94 = new System.Windows.Forms.Panel();
            this.SSZZS = new AttributesEdit.ZLSpinEdit();
            this.label58 = new System.Windows.Forms.Label();
            this.label108 = new System.Windows.Forms.Label();
            this.label109 = new System.Windows.Forms.Label();
            this.panel63 = new System.Windows.Forms.Panel();
            this.panel64 = new System.Windows.Forms.Panel();
            this.SSZYSZ = new AttributesEdit.ZLComboBox();
            this.label102 = new System.Windows.Forms.Label();
            this.panel89 = new System.Windows.Forms.Panel();
            this.SSLX = new AttributesEdit.ZLComboBox();
            this.label103 = new System.Windows.Forms.Label();
            this.panel90 = new System.Windows.Forms.Panel();
            this.BSSZGQZS = new AttributesEdit.ZLSpinEdit();
            this.label139 = new System.Windows.Forms.Label();
            this.label104 = new System.Windows.Forms.Label();
            this.label105 = new System.Windows.Forms.Label();
            this.panel65 = new System.Windows.Forms.Panel();
            this.panel66 = new System.Windows.Forms.Panel();
            this.BSSZGQDM = new AttributesEdit.ZLSpinEdit();
            this.label138 = new System.Windows.Forms.Label();
            this.label68 = new System.Windows.Forms.Label();
            this.panel67 = new System.Windows.Forms.Panel();
            this.BSSZPJXJ = new AttributesEdit.ZLSpinEdit();
            this.label142 = new System.Windows.Forms.Label();
            this.label69 = new System.Windows.Forms.Label();
            this.panel68 = new System.Windows.Forms.Panel();
            this.BSSZSG = new AttributesEdit.ZLSpinEdit();
            this.label31 = new System.Windows.Forms.Label();
            this.label70 = new System.Windows.Forms.Label();
            this.label71 = new System.Windows.Forms.Label();
            this.panel69 = new System.Windows.Forms.Panel();
            this.panel70 = new System.Windows.Forms.Panel();
            this.BSSZNL = new AttributesEdit.ZLSpinEdit();
            this.label77 = new System.Windows.Forms.Label();
            this.label72 = new System.Windows.Forms.Label();
            this.panel71 = new System.Windows.Forms.Panel();
            this.BSSZQY = new AttributesEdit.ZLComboBox();
            this.label73 = new System.Windows.Forms.Label();
            this.panel72 = new System.Windows.Forms.Panel();
            this.BSSZ = new AttributesEdit.ZLComboBox();
            this.label74 = new System.Windows.Forms.Label();
            this.label75 = new System.Windows.Forms.Label();
            this.label99 = new System.Windows.Forms.Label();
            this.label100 = new System.Windows.Forms.Label();
            this.label101 = new System.Windows.Forms.Label();
            this.label38 = new System.Windows.Forms.Label();
            this.panelAttr5 = new System.Windows.Forms.Panel();
            this.panelAttr51 = new System.Windows.Forms.Panel();
            this.panel163 = new System.Windows.Forms.Panel();
            this.panel187 = new System.Windows.Forms.Panel();
            this.JYGLLX = new AttributesEdit.ZLComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.panel164 = new System.Windows.Forms.Panel();
            this.YXMJ = new AttributesEdit.ZLSpinEdit();
            this.label27 = new System.Windows.Forms.Label();
            this.label219 = new System.Windows.Forms.Label();
            this.panel165 = new System.Windows.Forms.Panel();
            this.XZWMJ = new AttributesEdit.ZLSpinEdit();
            this.label13 = new System.Windows.Forms.Label();
            this.label220 = new System.Windows.Forms.Label();
            this.label221 = new System.Windows.Forms.Label();
            this.panel160 = new System.Windows.Forms.Panel();
            this.panel31 = new System.Windows.Forms.Panel();
            this.XZWKD = new AttributesEdit.ZLSpinEdit();
            this.label9 = new System.Windows.Forms.Label();
            this.label214 = new System.Windows.Forms.Label();
            this.panel161 = new System.Windows.Forms.Panel();
            this.XZWCD = new AttributesEdit.ZLSpinEdit();
            this.label10 = new System.Windows.Forms.Label();
            this.label215 = new System.Windows.Forms.Label();
            this.panel162 = new System.Windows.Forms.Panel();
            this.XZWZL = new AttributesEdit.ZLComboBox();
            this.label216 = new System.Windows.Forms.Label();
            this.label217 = new System.Windows.Forms.Label();
            this.panel157 = new System.Windows.Forms.Panel();
            this.panel30 = new System.Windows.Forms.Panel();
            this.FRZLDW = new AttributesEdit.ZLSpinEdit();
            this.label210 = new System.Windows.Forms.Label();
            this.panel158 = new System.Windows.Forms.Panel();
            this.LDSYDW = new AttributesEdit.ZLSpinEdit();
            this.label211 = new System.Windows.Forms.Label();
            this.panel159 = new System.Windows.Forms.Panel();
            this.QHFQBH = new AttributesEdit.ZLComboBox();
            this.label212 = new System.Windows.Forms.Label();
            this.label213 = new System.Windows.Forms.Label();
            this.panel105 = new System.Windows.Forms.Panel();
            this.panel24 = new System.Windows.Forms.Panel();
            this.XJBDJ = new AttributesEdit.ZLComboBox();
            this.label209 = new System.Windows.Forms.Label();
            this.panel107 = new System.Windows.Forms.Panel();
            this.CCLDJ = new AttributesEdit.ZLComboBox();
            this.label116 = new System.Windows.Forms.Label();
            this.panel108 = new System.Windows.Forms.Panel();
            this.JJLCQ = new AttributesEdit.ZLComboBox();
            this.label117 = new System.Windows.Forms.Label();
            this.label118 = new System.Windows.Forms.Label();
            this.panel109 = new System.Windows.Forms.Panel();
            this.panel110 = new System.Windows.Forms.Panel();
            this.YSMG = new AttributesEdit.ZLSpinEdit();
            this.label143 = new System.Windows.Forms.Label();
            this.label119 = new System.Windows.Forms.Label();
            this.panel111 = new System.Windows.Forms.Panel();
            this.JYCSLX = new AttributesEdit.ZLComboBox();
            this.label120 = new System.Windows.Forms.Label();
            this.panel112 = new System.Windows.Forms.Panel();
            this.JYLX = new DevExpress.XtraEditors.TextEdit();
            this.label121 = new System.Windows.Forms.Label();
            this.label122 = new System.Windows.Forms.Label();
            this.label123 = new System.Windows.Forms.Label();
            this.label124 = new System.Windows.Forms.Label();
            this.label125 = new System.Windows.Forms.Label();
            this.labelAttr6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panelAll = new System.Windows.Forms.Panel();
            this.panelRight = new System.Windows.Forms.Panel();
            this.panelLeft = new System.Windows.Forms.Panel();
            this.xtraTabControl1.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panelAttr8.SuspendLayout();
            this.panelAttr81.SuspendLayout();
            this.panel62.SuspendLayout();
            this.panel178.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Q_SSXJ.Properties)).BeginInit();
            this.panel177.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Q_BSSZXJ.Properties)).BeginInit();
            this.panel175.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Q_BSSZGQDM.Properties)).BeginInit();
            this.panel58.SuspendLayout();
            this.panel173.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Q_BSSZPJXJ.Properties)).BeginInit();
            this.panel59.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Q_BSSZSG.Properties)).BeginInit();
            this.panel61.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Q_BSSZNL.Properties)).BeginInit();
            this.panel182.SuspendLayout();
            this.panel176.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Q_YSSZXJ.Properties)).BeginInit();
            this.panel179.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Q_ZXJ.Properties)).BeginInit();
            this.panel183.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Q_PJDM.Properties)).BeginInit();
            this.panel186.SuspendLayout();
            this.panel184.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Q_PJSG.Properties)).BeginInit();
            this.panel185.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Q_PJXJ.Properties)).BeginInit();
            this.panel189.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Q_PJNL.Properties)).BeginInit();
            this.panel206.SuspendLayout();
            this.panel191.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Q_YBD.Properties)).BeginInit();
            this.panel192.SuspendLayout();
            this.panel209.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Q_MJ.Properties)).BeginInit();
            this.panelAttr7.SuspendLayout();
            this.panelAttr71.SuspendLayout();
            this.panel171.SuspendLayout();
            this.panel168.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BSSZXJ.Properties)).BeginInit();
            this.panel174.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SSXJ.Properties)).BeginInit();
            this.panel167.SuspendLayout();
            this.panel169.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.YSSZXJ.Properties)).BeginInit();
            this.panel170.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SLXJ.Properties)).BeginInit();
            this.panel121.SuspendLayout();
            this.panel122.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ZXJ.Properties)).BeginInit();
            this.panel123.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MEI_GQ_ZS.Properties)).BeginInit();
            this.panel124.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.HUO_LMGQXJ.Properties)).BeginInit();
            this.panel117.SuspendLayout();
            this.panel118.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PINGJUN_DM.Properties)).BeginInit();
            this.panel119.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PINGJUN_SG.Properties)).BeginInit();
            this.panel120.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PINGJUN_XJ.Properties)).BeginInit();
            this.panel78.SuspendLayout();
            this.panel104.SuspendLayout();
            this.panel106.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LJ.Properties)).BeginInit();
            this.panel116.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PINGJUN_NL.Properties)).BeginInit();
            this.panel50.SuspendLayout();
            this.panel56.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.YU_BI_DU.Properties)).BeginInit();
            this.panel74.SuspendLayout();
            this.panel75.SuspendLayout();
            this.panel130.SuspendLayout();
            this.panel131.SuspendLayout();
            this.panel132.SuspendLayout();
            this.panel133.SuspendLayout();
            this.panel134.SuspendLayout();
            this.panel135.SuspendLayout();
            this.panel136.SuspendLayout();
            this.panel137.SuspendLayout();
            this.panel138.SuspendLayout();
            this.panel139.SuspendLayout();
            this.panel140.SuspendLayout();
            this.panel141.SuspendLayout();
            this.panel142.SuspendLayout();
            this.panel143.SuspendLayout();
            this.panel144.SuspendLayout();
            this.panel145.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MIAN_JI.Properties)).BeginInit();
            this.panelAttr2.SuspendLayout();
            this.panelAttr21.SuspendLayout();
            this.panel23.SuspendLayout();
            this.panel28.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BHND.Properties)).BeginInit();
            this.panel25.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GXSJ.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GXSJ.Properties)).BeginInit();
            this.panel26.SuspendLayout();
            this.panelAttr1.SuspendLayout();
            this.panelAttr11.SuspendLayout();
            this.panel19.SuspendLayout();
            this.panel166.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.XI_BAN.Properties)).BeginInit();
            this.panel43.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.XIAO_BAN.Properties)).BeginInit();
            this.panel20.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LIN_BAN.Properties)).BeginInit();
            this.panel21.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LIN_CHANG.Properties)).BeginInit();
            this.panel12.SuspendLayout();
            this.panel49.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LIN_YE_JU.Properties)).BeginInit();
            this.panel16.SuspendLayout();
            this.panel18.SuspendLayout();
            this.panel13.SuspendLayout();
            this.panel115.SuspendLayout();
            this.panel53.SuspendLayout();
            this.panel15.SuspendLayout();
            this.panelTop.SuspendLayout();
            this.xtraTabPage2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panelAttr4.SuspendLayout();
            this.panelAttr41.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel22.SuspendLayout();
            this.panel11.SuspendLayout();
            this.panel17.SuspendLayout();
            this.panel151.SuspendLayout();
            this.panel10.SuspendLayout();
            this.panel152.SuspendLayout();
            this.panel153.SuspendLayout();
            this.panel148.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel149.SuspendLayout();
            this.panel150.SuspendLayout();
            this.panel129.SuspendLayout();
            this.panel29.SuspendLayout();
            this.panel146.SuspendLayout();
            this.panel147.SuspendLayout();
            this.panel73.SuspendLayout();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FZCH.Properties)).BeginInit();
            this.panel76.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SLHL.Properties)).BeginInit();
            this.panel77.SuspendLayout();
            this.panel79.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.KZLYH.Properties)).BeginInit();
            this.panel80.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TU_CENG_HD.Properties)).BeginInit();
            this.panel81.SuspendLayout();
            this.panel82.SuspendLayout();
            this.panel83.SuspendLayout();
            this.panel84.SuspendLayout();
            this.panel85.SuspendLayout();
            this.panel86.SuspendLayout();
            this.panel87.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.HBG.Properties)).BeginInit();
            this.panel88.SuspendLayout();
            this.panelAttr3.SuspendLayout();
            this.panelAttr31.SuspendLayout();
            this.panel34.SuspendLayout();
            this.panel180.SuspendLayout();
            this.panel172.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ZFNL.Properties)).BeginInit();
            this.panel52.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ZLND.Properties)).BeginInit();
            this.panel125.SuspendLayout();
            this.panel126.SuspendLayout();
            this.panel127.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LD_CD.Properties)).BeginInit();
            this.panel128.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LD_KD.Properties)).BeginInit();
            this.panel35.SuspendLayout();
            this.panel36.SuspendLayout();
            this.panel37.SuspendLayout();
            this.panel188.SuspendLayout();
            this.panel39.SuspendLayout();
            this.panel40.SuspendLayout();
            this.panel38.SuspendLayout();
            this.panel42.SuspendLayout();
            this.panel41.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel44.SuspendLayout();
            this.panel46.SuspendLayout();
            this.panel57.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel60.SuspendLayout();
            this.panel51.SuspendLayout();
            this.panel181.SuspendLayout();
            this.panel54.SuspendLayout();
            this.panel55.SuspendLayout();
            this.panel45.SuspendLayout();
            this.panel47.SuspendLayout();
            this.panel48.SuspendLayout();
            this.xtraTabPage3.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panelAttr6.SuspendLayout();
            this.panelAttr61.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel27.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Remarks.Properties)).BeginInit();
            this.panel154.SuspendLayout();
            this.panel33.SuspendLayout();
            this.panel155.SuspendLayout();
            this.panel156.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GXGQZS.Properties)).BeginInit();
            this.panel103.SuspendLayout();
            this.panel32.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GXPJGD.Properties)).BeginInit();
            this.panel113.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GXPJNL.Properties)).BeginInit();
            this.panel114.SuspendLayout();
            this.panel99.SuspendLayout();
            this.panel100.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CMZGD.Properties)).BeginInit();
            this.panel101.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CBPJGD.Properties)).BeginInit();
            this.panel102.SuspendLayout();
            this.panel95.SuspendLayout();
            this.panel96.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GMZGD.Properties)).BeginInit();
            this.panel97.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GMPJGD.Properties)).BeginInit();
            this.panel98.SuspendLayout();
            this.panel91.SuspendLayout();
            this.panel92.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SSPJGD.Properties)).BeginInit();
            this.panel93.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SSPJXJ.Properties)).BeginInit();
            this.panel94.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SSZZS.Properties)).BeginInit();
            this.panel63.SuspendLayout();
            this.panel64.SuspendLayout();
            this.panel89.SuspendLayout();
            this.panel90.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BSSZGQZS.Properties)).BeginInit();
            this.panel65.SuspendLayout();
            this.panel66.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BSSZGQDM.Properties)).BeginInit();
            this.panel67.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BSSZPJXJ.Properties)).BeginInit();
            this.panel68.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BSSZSG.Properties)).BeginInit();
            this.panel69.SuspendLayout();
            this.panel70.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BSSZNL.Properties)).BeginInit();
            this.panel71.SuspendLayout();
            this.panel72.SuspendLayout();
            this.panelAttr5.SuspendLayout();
            this.panelAttr51.SuspendLayout();
            this.panel163.SuspendLayout();
            this.panel187.SuspendLayout();
            this.panel164.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.YXMJ.Properties)).BeginInit();
            this.panel165.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.XZWMJ.Properties)).BeginInit();
            this.panel160.SuspendLayout();
            this.panel31.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.XZWKD.Properties)).BeginInit();
            this.panel161.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.XZWCD.Properties)).BeginInit();
            this.panel162.SuspendLayout();
            this.panel157.SuspendLayout();
            this.panel30.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FRZLDW.Properties)).BeginInit();
            this.panel158.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LDSYDW.Properties)).BeginInit();
            this.panel159.SuspendLayout();
            this.panel105.SuspendLayout();
            this.panel24.SuspendLayout();
            this.panel107.SuspendLayout();
            this.panel108.SuspendLayout();
            this.panel109.SuspendLayout();
            this.panel110.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.YSMG.Properties)).BeginInit();
            this.panel111.SuspendLayout();
            this.panel112.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.JYLX.Properties)).BeginInit();
            this.panelAll.SuspendLayout();
            this.SuspendLayout();
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Controls.Add(this.xtraTabPage1);
            this.xtraTabControl1.Controls.Add(this.xtraTabPage2);
            this.xtraTabControl1.Controls.Add(this.xtraTabPage3);
            this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl1.Location = new System.Drawing.Point(0, 0);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedIndex = 0;
            this.xtraTabControl1.Size = new System.Drawing.Size(585, 623);
            this.xtraTabControl1.TabIndex = 0;
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Controls.Add(this.panel1);
            this.xtraTabPage1.Location = new System.Drawing.Point(4, 23);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(577, 596);
            this.xtraTabPage1.TabIndex = 0;
            this.xtraTabPage1.Text = "基本信息";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.panelAttr8);
            this.panel1.Controls.Add(this.labelAttr8);
            this.panel1.Controls.Add(this.panelAttr7);
            this.panel1.Controls.Add(this.labelAttr2);
            this.panel1.Controls.Add(this.panelAttr2);
            this.panel1.Controls.Add(this.labelAttr3);
            this.panel1.Controls.Add(this.panelAttr1);
            this.panel1.Controls.Add(this.panelTop);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(577, 596);
            this.panel1.TabIndex = 0;
            // 
            // panelAttr8
            // 
            this.panelAttr8.Controls.Add(this.panelAttr81);
            this.panelAttr8.Controls.Add(this.label283);
            this.panelAttr8.Controls.Add(this.label284);
            this.panelAttr8.Controls.Add(this.label285);
            this.panelAttr8.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelAttr8.Location = new System.Drawing.Point(0, 467);
            this.panelAttr8.Name = "panelAttr8";
            this.panelAttr8.Size = new System.Drawing.Size(577, 126);
            this.panelAttr8.TabIndex = 0;
            // 
            // panelAttr81
            // 
            this.panelAttr81.Controls.Add(this.panel62);
            this.panelAttr81.Controls.Add(this.panel58);
            this.panelAttr81.Controls.Add(this.panel182);
            this.panelAttr81.Controls.Add(this.panel186);
            this.panelAttr81.Controls.Add(this.panel206);
            this.panelAttr81.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelAttr81.Location = new System.Drawing.Point(1, 1);
            this.panelAttr81.Name = "panelAttr81";
            this.panelAttr81.Size = new System.Drawing.Size(575, 125);
            this.panelAttr81.TabIndex = 0;
            // 
            // panel62
            // 
            this.panel62.Controls.Add(this.panel178);
            this.panel62.Controls.Add(this.label246);
            this.panel62.Controls.Add(this.panel177);
            this.panel62.Controls.Add(this.label233);
            this.panel62.Controls.Add(this.panel175);
            this.panel62.Controls.Add(this.label239);
            this.panel62.Controls.Add(this.label240);
            this.panel62.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel62.Location = new System.Drawing.Point(0, 100);
            this.panel62.Name = "panel62";
            this.panel62.Size = new System.Drawing.Size(575, 25);
            this.panel62.TabIndex = 0;
            // 
            // panel178
            // 
            this.panel178.Controls.Add(this.Q_SSXJ);
            this.panel178.Controls.Add(this.label247);
            this.panel178.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel178.Location = new System.Drawing.Point(477, 0);
            this.panel178.Name = "panel178";
            this.panel178.Padding = new System.Windows.Forms.Padding(2, 6, 6, 2);
            this.panel178.Size = new System.Drawing.Size(91, 24);
            this.panel178.TabIndex = 0;
            // 
            // Q_SSXJ
            // 
            this.Q_SSXJ.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Q_SSXJ.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Q_SSXJ.EditScale = 0;
            this.Q_SSXJ.EditValue = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.Q_SSXJ.Location = new System.Drawing.Point(2, 4);
            this.Q_SSXJ.Name = "Q_SSXJ";
            this.Q_SSXJ.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.Q_SSXJ.Properties.Appearance.Options.UseForeColor = true;
            this.Q_SSXJ.Properties.Appearance.Options.UseTextOptions = true;
            this.Q_SSXJ.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.Q_SSXJ.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.Q_SSXJ.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.Q_SSXJ.Properties.LookAndFeel.SkinName = "Blue";
            this.Q_SSXJ.Properties.MaxValue = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.Q_SSXJ.Size = new System.Drawing.Size(60, 18);
            this.Q_SSXJ.TabIndex = 0;
            // 
            // label247
            // 
            this.label247.Dock = System.Windows.Forms.DockStyle.Right;
            this.label247.ForeColor = System.Drawing.Color.Blue;
            this.label247.Location = new System.Drawing.Point(62, 6);
            this.label247.Name = "label247";
            this.label247.Size = new System.Drawing.Size(23, 16);
            this.label247.TabIndex = 0;
            this.label247.Text = "m³";
            this.label247.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label246
            // 
            this.label246.Dock = System.Windows.Forms.DockStyle.Left;
            this.label246.Location = new System.Drawing.Point(397, 0);
            this.label246.Name = "label246";
            this.label246.Size = new System.Drawing.Size(80, 24);
            this.label246.TabIndex = 0;
            this.label246.Text = "前期散生蓄积";
            this.label246.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel177
            // 
            this.panel177.Controls.Add(this.Q_BSSZXJ);
            this.panel177.Controls.Add(this.label245);
            this.panel177.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel177.Location = new System.Drawing.Point(306, 0);
            this.panel177.Name = "panel177";
            this.panel177.Padding = new System.Windows.Forms.Padding(2, 6, 6, 2);
            this.panel177.Size = new System.Drawing.Size(91, 24);
            this.panel177.TabIndex = 0;
            // 
            // Q_BSSZXJ
            // 
            this.Q_BSSZXJ.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Q_BSSZXJ.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Q_BSSZXJ.EditScale = 0;
            this.Q_BSSZXJ.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.Q_BSSZXJ.Location = new System.Drawing.Point(2, 4);
            this.Q_BSSZXJ.Name = "Q_BSSZXJ";
            this.Q_BSSZXJ.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.Q_BSSZXJ.Properties.Appearance.Options.UseForeColor = true;
            this.Q_BSSZXJ.Properties.Appearance.Options.UseTextOptions = true;
            this.Q_BSSZXJ.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.Q_BSSZXJ.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.Q_BSSZXJ.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.Q_BSSZXJ.Properties.LookAndFeel.SkinName = "Blue";
            this.Q_BSSZXJ.Properties.MaxValue = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.Q_BSSZXJ.Size = new System.Drawing.Size(60, 18);
            this.Q_BSSZXJ.TabIndex = 0;
            // 
            // label245
            // 
            this.label245.Dock = System.Windows.Forms.DockStyle.Right;
            this.label245.ForeColor = System.Drawing.Color.Blue;
            this.label245.Location = new System.Drawing.Point(62, 6);
            this.label245.Name = "label245";
            this.label245.Size = new System.Drawing.Size(23, 16);
            this.label245.TabIndex = 0;
            this.label245.Text = "m³";
            this.label245.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label233
            // 
            this.label233.Dock = System.Windows.Forms.DockStyle.Left;
            this.label233.Location = new System.Drawing.Point(203, 0);
            this.label233.Name = "label233";
            this.label233.Size = new System.Drawing.Size(103, 24);
            this.label233.TabIndex = 0;
            this.label233.Text = "前期伴生树种蓄积";
            this.label233.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel175
            // 
            this.panel175.Controls.Add(this.Q_BSSZGQDM);
            this.panel175.Controls.Add(this.label238);
            this.panel175.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel175.Location = new System.Drawing.Point(128, 0);
            this.panel175.Name = "panel175";
            this.panel175.Padding = new System.Windows.Forms.Padding(2, 6, 6, 2);
            this.panel175.Size = new System.Drawing.Size(75, 24);
            this.panel175.TabIndex = 0;
            // 
            // Q_BSSZGQDM
            // 
            this.Q_BSSZGQDM.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Q_BSSZGQDM.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Q_BSSZGQDM.EditScale = 0;
            this.Q_BSSZGQDM.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.Q_BSSZGQDM.Location = new System.Drawing.Point(2, 4);
            this.Q_BSSZGQDM.Name = "Q_BSSZGQDM";
            this.Q_BSSZGQDM.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.Q_BSSZGQDM.Properties.Appearance.Options.UseForeColor = true;
            this.Q_BSSZGQDM.Properties.Appearance.Options.UseTextOptions = true;
            this.Q_BSSZGQDM.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.Q_BSSZGQDM.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.Q_BSSZGQDM.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.Q_BSSZGQDM.Properties.LookAndFeel.SkinName = "Blue";
            this.Q_BSSZGQDM.Properties.MaxValue = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.Q_BSSZGQDM.Size = new System.Drawing.Size(44, 18);
            this.Q_BSSZGQDM.TabIndex = 0;
            // 
            // label238
            // 
            this.label238.Dock = System.Windows.Forms.DockStyle.Right;
            this.label238.ForeColor = System.Drawing.Color.Blue;
            this.label238.Location = new System.Drawing.Point(46, 6);
            this.label238.Name = "label238";
            this.label238.Size = new System.Drawing.Size(23, 16);
            this.label238.TabIndex = 0;
            this.label238.Text = "m²";
            this.label238.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label239
            // 
            this.label239.Dock = System.Windows.Forms.DockStyle.Left;
            this.label239.Location = new System.Drawing.Point(0, 0);
            this.label239.Name = "label239";
            this.label239.Size = new System.Drawing.Size(128, 24);
            this.label239.TabIndex = 0;
            this.label239.Text = "前期伴生树种公顷断面";
            this.label239.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label240
            // 
            this.label240.BackColor = System.Drawing.Color.Black;
            this.label240.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label240.Location = new System.Drawing.Point(0, 24);
            this.label240.Name = "label240";
            this.label240.Size = new System.Drawing.Size(575, 1);
            this.label240.TabIndex = 0;
            this.label240.Text = "label240";
            this.label240.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel58
            // 
            this.panel58.Controls.Add(this.panel173);
            this.panel58.Controls.Add(this.label237);
            this.panel58.Controls.Add(this.panel59);
            this.panel58.Controls.Add(this.label230);
            this.panel58.Controls.Add(this.panel61);
            this.panel58.Controls.Add(this.label234);
            this.panel58.Controls.Add(this.label235);
            this.panel58.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel58.Location = new System.Drawing.Point(0, 75);
            this.panel58.Name = "panel58";
            this.panel58.Size = new System.Drawing.Size(575, 25);
            this.panel58.TabIndex = 0;
            // 
            // panel173
            // 
            this.panel173.Controls.Add(this.Q_BSSZPJXJ);
            this.panel173.Controls.Add(this.label236);
            this.panel173.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel173.Location = new System.Drawing.Point(494, 0);
            this.panel173.Name = "panel173";
            this.panel173.Padding = new System.Windows.Forms.Padding(2, 6, 6, 2);
            this.panel173.Size = new System.Drawing.Size(80, 24);
            this.panel173.TabIndex = 0;
            // 
            // Q_BSSZPJXJ
            // 
            this.Q_BSSZPJXJ.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Q_BSSZPJXJ.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Q_BSSZPJXJ.EditScale = 0;
            this.Q_BSSZPJXJ.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.Q_BSSZPJXJ.Location = new System.Drawing.Point(2, 4);
            this.Q_BSSZPJXJ.Name = "Q_BSSZPJXJ";
            this.Q_BSSZPJXJ.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.Q_BSSZPJXJ.Properties.Appearance.Options.UseForeColor = true;
            this.Q_BSSZPJXJ.Properties.Appearance.Options.UseTextOptions = true;
            this.Q_BSSZPJXJ.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.Q_BSSZPJXJ.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.Q_BSSZPJXJ.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.Q_BSSZPJXJ.Properties.LookAndFeel.SkinName = "Blue";
            this.Q_BSSZPJXJ.Properties.MaxValue = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.Q_BSSZPJXJ.Size = new System.Drawing.Size(49, 18);
            this.Q_BSSZPJXJ.TabIndex = 0;
            // 
            // label236
            // 
            this.label236.Dock = System.Windows.Forms.DockStyle.Right;
            this.label236.ForeColor = System.Drawing.Color.Blue;
            this.label236.Location = new System.Drawing.Point(51, 6);
            this.label236.Name = "label236";
            this.label236.Size = new System.Drawing.Size(23, 16);
            this.label236.TabIndex = 0;
            this.label236.Text = "cm";
            this.label236.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label237
            // 
            this.label237.Dock = System.Windows.Forms.DockStyle.Left;
            this.label237.Location = new System.Drawing.Point(366, 0);
            this.label237.Name = "label237";
            this.label237.Size = new System.Drawing.Size(128, 24);
            this.label237.TabIndex = 0;
            this.label237.Text = "前期伴生树种平均胸径";
            this.label237.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel59
            // 
            this.panel59.Controls.Add(this.Q_BSSZSG);
            this.panel59.Controls.Add(this.label229);
            this.panel59.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel59.Location = new System.Drawing.Point(306, 0);
            this.panel59.Name = "panel59";
            this.panel59.Padding = new System.Windows.Forms.Padding(2, 6, 6, 2);
            this.panel59.Size = new System.Drawing.Size(60, 24);
            this.panel59.TabIndex = 0;
            // 
            // Q_BSSZSG
            // 
            this.Q_BSSZSG.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Q_BSSZSG.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Q_BSSZSG.EditScale = 0;
            this.Q_BSSZSG.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.Q_BSSZSG.Location = new System.Drawing.Point(2, 4);
            this.Q_BSSZSG.Name = "Q_BSSZSG";
            this.Q_BSSZSG.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.Q_BSSZSG.Properties.Appearance.Options.UseForeColor = true;
            this.Q_BSSZSG.Properties.Appearance.Options.UseTextOptions = true;
            this.Q_BSSZSG.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.Q_BSSZSG.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.Q_BSSZSG.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.Q_BSSZSG.Properties.LookAndFeel.SkinName = "Blue";
            this.Q_BSSZSG.Properties.MaxValue = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.Q_BSSZSG.Size = new System.Drawing.Size(36, 18);
            this.Q_BSSZSG.TabIndex = 0;
            // 
            // label229
            // 
            this.label229.Dock = System.Windows.Forms.DockStyle.Right;
            this.label229.ForeColor = System.Drawing.Color.Blue;
            this.label229.Location = new System.Drawing.Point(38, 6);
            this.label229.Name = "label229";
            this.label229.Size = new System.Drawing.Size(16, 16);
            this.label229.TabIndex = 0;
            this.label229.Text = "m";
            this.label229.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label230
            // 
            this.label230.Dock = System.Windows.Forms.DockStyle.Left;
            this.label230.Location = new System.Drawing.Point(178, 0);
            this.label230.Name = "label230";
            this.label230.Size = new System.Drawing.Size(128, 24);
            this.label230.TabIndex = 0;
            this.label230.Text = "前期伴生树种平均树高";
            this.label230.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel61
            // 
            this.panel61.Controls.Add(this.Q_BSSZNL);
            this.panel61.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel61.Location = new System.Drawing.Point(128, 0);
            this.panel61.Name = "panel61";
            this.panel61.Padding = new System.Windows.Forms.Padding(2, 6, 6, 2);
            this.panel61.Size = new System.Drawing.Size(50, 24);
            this.panel61.TabIndex = 0;
            // 
            // Q_BSSZNL
            // 
            this.Q_BSSZNL.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Q_BSSZNL.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Q_BSSZNL.EditScale = 0;
            this.Q_BSSZNL.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.Q_BSSZNL.Location = new System.Drawing.Point(2, 4);
            this.Q_BSSZNL.Name = "Q_BSSZNL";
            this.Q_BSSZNL.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.Q_BSSZNL.Properties.Appearance.Options.UseForeColor = true;
            this.Q_BSSZNL.Properties.Appearance.Options.UseTextOptions = true;
            this.Q_BSSZNL.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.Q_BSSZNL.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.Q_BSSZNL.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.Q_BSSZNL.Properties.LookAndFeel.SkinName = "Blue";
            this.Q_BSSZNL.Properties.MaxValue = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.Q_BSSZNL.Size = new System.Drawing.Size(42, 18);
            this.Q_BSSZNL.TabIndex = 0;
            // 
            // label234
            // 
            this.label234.Dock = System.Windows.Forms.DockStyle.Left;
            this.label234.Location = new System.Drawing.Point(0, 0);
            this.label234.Name = "label234";
            this.label234.Size = new System.Drawing.Size(128, 24);
            this.label234.TabIndex = 0;
            this.label234.Text = "前期伴生树种平均年龄";
            this.label234.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label235
            // 
            this.label235.BackColor = System.Drawing.Color.Black;
            this.label235.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label235.Location = new System.Drawing.Point(0, 24);
            this.label235.Name = "label235";
            this.label235.Size = new System.Drawing.Size(575, 1);
            this.label235.TabIndex = 0;
            this.label235.Text = "label235";
            this.label235.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel182
            // 
            this.panel182.Controls.Add(this.panel176);
            this.panel182.Controls.Add(this.label241);
            this.panel182.Controls.Add(this.panel179);
            this.panel182.Controls.Add(this.label243);
            this.panel182.Controls.Add(this.panel183);
            this.panel182.Controls.Add(this.label250);
            this.panel182.Controls.Add(this.label255);
            this.panel182.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel182.Location = new System.Drawing.Point(0, 50);
            this.panel182.Name = "panel182";
            this.panel182.Size = new System.Drawing.Size(575, 25);
            this.panel182.TabIndex = 0;
            // 
            // panel176
            // 
            this.panel176.Controls.Add(this.Q_YSSZXJ);
            this.panel176.Controls.Add(this.label244);
            this.panel176.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel176.Location = new System.Drawing.Point(485, 0);
            this.panel176.Name = "panel176";
            this.panel176.Padding = new System.Windows.Forms.Padding(2, 6, 6, 2);
            this.panel176.Size = new System.Drawing.Size(85, 24);
            this.panel176.TabIndex = 0;
            // 
            // Q_YSSZXJ
            // 
            this.Q_YSSZXJ.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Q_YSSZXJ.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Q_YSSZXJ.EditScale = 0;
            this.Q_YSSZXJ.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.Q_YSSZXJ.Location = new System.Drawing.Point(2, 4);
            this.Q_YSSZXJ.Name = "Q_YSSZXJ";
            this.Q_YSSZXJ.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.Q_YSSZXJ.Properties.Appearance.Options.UseForeColor = true;
            this.Q_YSSZXJ.Properties.Appearance.Options.UseTextOptions = true;
            this.Q_YSSZXJ.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.Q_YSSZXJ.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.Q_YSSZXJ.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.Q_YSSZXJ.Properties.LookAndFeel.SkinName = "Blue";
            this.Q_YSSZXJ.Properties.MaxValue = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.Q_YSSZXJ.Size = new System.Drawing.Size(52, 18);
            this.Q_YSSZXJ.TabIndex = 0;
            // 
            // label244
            // 
            this.label244.Dock = System.Windows.Forms.DockStyle.Right;
            this.label244.ForeColor = System.Drawing.Color.Blue;
            this.label244.Location = new System.Drawing.Point(54, 6);
            this.label244.Name = "label244";
            this.label244.Size = new System.Drawing.Size(25, 16);
            this.label244.TabIndex = 0;
            this.label244.Text = "m³";
            this.label244.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label241
            // 
            this.label241.Dock = System.Windows.Forms.DockStyle.Left;
            this.label241.Location = new System.Drawing.Point(380, 0);
            this.label241.Name = "label241";
            this.label241.Size = new System.Drawing.Size(105, 24);
            this.label241.TabIndex = 0;
            this.label241.Text = "前期优势树种蓄积";
            this.label241.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel179
            // 
            this.panel179.Controls.Add(this.Q_ZXJ);
            this.panel179.Controls.Add(this.label242);
            this.panel179.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel179.Location = new System.Drawing.Point(270, 0);
            this.panel179.Name = "panel179";
            this.panel179.Padding = new System.Windows.Forms.Padding(2, 6, 6, 2);
            this.panel179.Size = new System.Drawing.Size(110, 24);
            this.panel179.TabIndex = 0;
            // 
            // Q_ZXJ
            // 
            this.Q_ZXJ.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Q_ZXJ.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Q_ZXJ.EditScale = 0;
            this.Q_ZXJ.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.Q_ZXJ.Location = new System.Drawing.Point(2, 4);
            this.Q_ZXJ.Name = "Q_ZXJ";
            this.Q_ZXJ.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.Q_ZXJ.Properties.Appearance.Options.UseForeColor = true;
            this.Q_ZXJ.Properties.Appearance.Options.UseTextOptions = true;
            this.Q_ZXJ.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.Q_ZXJ.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.Q_ZXJ.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.Q_ZXJ.Properties.LookAndFeel.SkinName = "Blue";
            this.Q_ZXJ.Properties.MaxValue = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.Q_ZXJ.Size = new System.Drawing.Size(77, 18);
            this.Q_ZXJ.TabIndex = 34;
            // 
            // label242
            // 
            this.label242.Dock = System.Windows.Forms.DockStyle.Right;
            this.label242.ForeColor = System.Drawing.Color.Blue;
            this.label242.Location = new System.Drawing.Point(79, 6);
            this.label242.Name = "label242";
            this.label242.Size = new System.Drawing.Size(25, 16);
            this.label242.TabIndex = 0;
            this.label242.Text = "m³";
            this.label242.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label243
            // 
            this.label243.Dock = System.Windows.Forms.DockStyle.Left;
            this.label243.Location = new System.Drawing.Point(202, 0);
            this.label243.Name = "label243";
            this.label243.Size = new System.Drawing.Size(68, 24);
            this.label243.TabIndex = 0;
            this.label243.Text = "前期总蓄积";
            this.label243.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel183
            // 
            this.panel183.Controls.Add(this.Q_PJDM);
            this.panel183.Controls.Add(this.label249);
            this.panel183.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel183.Location = new System.Drawing.Point(92, 0);
            this.panel183.Name = "panel183";
            this.panel183.Padding = new System.Windows.Forms.Padding(2, 6, 6, 2);
            this.panel183.Size = new System.Drawing.Size(110, 24);
            this.panel183.TabIndex = 0;
            // 
            // Q_PJDM
            // 
            this.Q_PJDM.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Q_PJDM.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Q_PJDM.EditScale = 0;
            this.Q_PJDM.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.Q_PJDM.Location = new System.Drawing.Point(2, 4);
            this.Q_PJDM.Name = "Q_PJDM";
            this.Q_PJDM.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.Q_PJDM.Properties.Appearance.Options.UseForeColor = true;
            this.Q_PJDM.Properties.Appearance.Options.UseTextOptions = true;
            this.Q_PJDM.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.Q_PJDM.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.Q_PJDM.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.Q_PJDM.Properties.LookAndFeel.SkinName = "Blue";
            this.Q_PJDM.Properties.MaxValue = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.Q_PJDM.Size = new System.Drawing.Size(77, 18);
            this.Q_PJDM.TabIndex = 31;
            // 
            // label249
            // 
            this.label249.Dock = System.Windows.Forms.DockStyle.Right;
            this.label249.ForeColor = System.Drawing.Color.Blue;
            this.label249.Location = new System.Drawing.Point(79, 6);
            this.label249.Name = "label249";
            this.label249.Size = new System.Drawing.Size(25, 16);
            this.label249.TabIndex = 0;
            this.label249.Text = "m²";
            this.label249.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label250
            // 
            this.label250.Dock = System.Windows.Forms.DockStyle.Left;
            this.label250.Location = new System.Drawing.Point(0, 0);
            this.label250.Name = "label250";
            this.label250.Size = new System.Drawing.Size(92, 24);
            this.label250.TabIndex = 0;
            this.label250.Text = "前期公顷断面积";
            this.label250.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label255
            // 
            this.label255.BackColor = System.Drawing.Color.Black;
            this.label255.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label255.Location = new System.Drawing.Point(0, 24);
            this.label255.Name = "label255";
            this.label255.Size = new System.Drawing.Size(575, 1);
            this.label255.TabIndex = 0;
            this.label255.Text = "label255";
            this.label255.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel186
            // 
            this.panel186.Controls.Add(this.panel184);
            this.panel186.Controls.Add(this.label252);
            this.panel186.Controls.Add(this.panel185);
            this.panel186.Controls.Add(this.label254);
            this.panel186.Controls.Add(this.panel189);
            this.panel186.Controls.Add(this.label259);
            this.panel186.Controls.Add(this.label260);
            this.panel186.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel186.Location = new System.Drawing.Point(0, 25);
            this.panel186.Name = "panel186";
            this.panel186.Size = new System.Drawing.Size(575, 25);
            this.panel186.TabIndex = 0;
            // 
            // panel184
            // 
            this.panel184.Controls.Add(this.Q_PJSG);
            this.panel184.Controls.Add(this.label251);
            this.panel184.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel184.Location = new System.Drawing.Point(460, 0);
            this.panel184.Name = "panel184";
            this.panel184.Padding = new System.Windows.Forms.Padding(2, 6, 6, 2);
            this.panel184.Size = new System.Drawing.Size(110, 24);
            this.panel184.TabIndex = 4;
            // 
            // Q_PJSG
            // 
            this.Q_PJSG.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Q_PJSG.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Q_PJSG.EditScale = 0;
            this.Q_PJSG.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.Q_PJSG.Location = new System.Drawing.Point(2, 4);
            this.Q_PJSG.Name = "Q_PJSG";
            this.Q_PJSG.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.Q_PJSG.Properties.Appearance.Options.UseForeColor = true;
            this.Q_PJSG.Properties.Appearance.Options.UseTextOptions = true;
            this.Q_PJSG.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.Q_PJSG.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.Q_PJSG.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.Q_PJSG.Properties.LookAndFeel.SkinName = "Blue";
            this.Q_PJSG.Properties.MaxValue = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.Q_PJSG.Size = new System.Drawing.Size(83, 18);
            this.Q_PJSG.TabIndex = 30;
            // 
            // label251
            // 
            this.label251.Dock = System.Windows.Forms.DockStyle.Right;
            this.label251.ForeColor = System.Drawing.Color.Blue;
            this.label251.Location = new System.Drawing.Point(85, 6);
            this.label251.Name = "label251";
            this.label251.Size = new System.Drawing.Size(19, 16);
            this.label251.TabIndex = 0;
            this.label251.Text = "m";
            this.label251.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label252
            // 
            this.label252.Dock = System.Windows.Forms.DockStyle.Left;
            this.label252.Location = new System.Drawing.Point(380, 0);
            this.label252.Name = "label252";
            this.label252.Size = new System.Drawing.Size(80, 24);
            this.label252.TabIndex = 0;
            this.label252.Text = "前期平均树高";
            this.label252.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel185
            // 
            this.panel185.Controls.Add(this.Q_PJXJ);
            this.panel185.Controls.Add(this.label253);
            this.panel185.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel185.Location = new System.Drawing.Point(270, 0);
            this.panel185.Name = "panel185";
            this.panel185.Padding = new System.Windows.Forms.Padding(2, 6, 6, 2);
            this.panel185.Size = new System.Drawing.Size(110, 24);
            this.panel185.TabIndex = 2;
            // 
            // Q_PJXJ
            // 
            this.Q_PJXJ.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Q_PJXJ.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Q_PJXJ.EditScale = 0;
            this.Q_PJXJ.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.Q_PJXJ.Location = new System.Drawing.Point(2, 4);
            this.Q_PJXJ.Name = "Q_PJXJ";
            this.Q_PJXJ.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.Q_PJXJ.Properties.Appearance.Options.UseForeColor = true;
            this.Q_PJXJ.Properties.Appearance.Options.UseTextOptions = true;
            this.Q_PJXJ.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.Q_PJXJ.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.Q_PJXJ.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.Q_PJXJ.Properties.LookAndFeel.SkinName = "Blue";
            this.Q_PJXJ.Properties.MaxValue = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.Q_PJXJ.Size = new System.Drawing.Size(77, 18);
            this.Q_PJXJ.TabIndex = 29;
            // 
            // label253
            // 
            this.label253.Dock = System.Windows.Forms.DockStyle.Right;
            this.label253.ForeColor = System.Drawing.Color.Blue;
            this.label253.Location = new System.Drawing.Point(79, 6);
            this.label253.Name = "label253";
            this.label253.Size = new System.Drawing.Size(25, 16);
            this.label253.TabIndex = 0;
            this.label253.Text = "cm";
            this.label253.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label254
            // 
            this.label254.Dock = System.Windows.Forms.DockStyle.Left;
            this.label254.Location = new System.Drawing.Point(190, 0);
            this.label254.Name = "label254";
            this.label254.Size = new System.Drawing.Size(80, 24);
            this.label254.TabIndex = 1;
            this.label254.Text = "前期平均胸径";
            this.label254.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel189
            // 
            this.panel189.Controls.Add(this.Q_PJNL);
            this.panel189.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel189.Location = new System.Drawing.Point(80, 0);
            this.panel189.Name = "panel189";
            this.panel189.Padding = new System.Windows.Forms.Padding(2, 6, 6, 2);
            this.panel189.Size = new System.Drawing.Size(110, 24);
            this.panel189.TabIndex = 0;
            // 
            // Q_PJNL
            // 
            this.Q_PJNL.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Q_PJNL.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Q_PJNL.EditScale = 0;
            this.Q_PJNL.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.Q_PJNL.Location = new System.Drawing.Point(2, 4);
            this.Q_PJNL.Name = "Q_PJNL";
            this.Q_PJNL.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.Q_PJNL.Properties.Appearance.Options.UseForeColor = true;
            this.Q_PJNL.Properties.Appearance.Options.UseTextOptions = true;
            this.Q_PJNL.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.Q_PJNL.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.Q_PJNL.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.Q_PJNL.Properties.LookAndFeel.SkinName = "Blue";
            this.Q_PJNL.Properties.MaxValue = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.Q_PJNL.Size = new System.Drawing.Size(102, 18);
            this.Q_PJNL.TabIndex = 26;
            // 
            // label259
            // 
            this.label259.Dock = System.Windows.Forms.DockStyle.Left;
            this.label259.Location = new System.Drawing.Point(0, 0);
            this.label259.Name = "label259";
            this.label259.Size = new System.Drawing.Size(80, 24);
            this.label259.TabIndex = 0;
            this.label259.Text = "前期平均年龄";
            this.label259.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label260
            // 
            this.label260.BackColor = System.Drawing.Color.Black;
            this.label260.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label260.Location = new System.Drawing.Point(0, 24);
            this.label260.Name = "label260";
            this.label260.Size = new System.Drawing.Size(575, 1);
            this.label260.TabIndex = 0;
            this.label260.Text = "label260";
            this.label260.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel206
            // 
            this.panel206.Controls.Add(this.panel191);
            this.panel206.Controls.Add(this.label262);
            this.panel206.Controls.Add(this.panel192);
            this.panel206.Controls.Add(this.label263);
            this.panel206.Controls.Add(this.panel209);
            this.panel206.Controls.Add(this.label281);
            this.panel206.Controls.Add(this.label282);
            this.panel206.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel206.Location = new System.Drawing.Point(0, 0);
            this.panel206.Name = "panel206";
            this.panel206.Size = new System.Drawing.Size(575, 25);
            this.panel206.TabIndex = 0;
            // 
            // panel191
            // 
            this.panel191.Controls.Add(this.Q_YBD);
            this.panel191.Controls.Add(this.label261);
            this.panel191.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel191.Location = new System.Drawing.Point(460, 0);
            this.panel191.Name = "panel191";
            this.panel191.Padding = new System.Windows.Forms.Padding(2, 6, 6, 2);
            this.panel191.Size = new System.Drawing.Size(110, 24);
            this.panel191.TabIndex = 4;
            // 
            // Q_YBD
            // 
            this.Q_YBD.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Q_YBD.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Q_YBD.EditScale = 0;
            this.Q_YBD.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.Q_YBD.Location = new System.Drawing.Point(2, 4);
            this.Q_YBD.Name = "Q_YBD";
            this.Q_YBD.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.Q_YBD.Properties.Appearance.Options.UseForeColor = true;
            this.Q_YBD.Properties.Appearance.Options.UseTextOptions = true;
            this.Q_YBD.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.Q_YBD.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.Q_YBD.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.Q_YBD.Properties.LookAndFeel.SkinName = "Blue";
            this.Q_YBD.Properties.MaxValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.Q_YBD.Size = new System.Drawing.Size(83, 18);
            this.Q_YBD.TabIndex = 25;
            // 
            // label261
            // 
            this.label261.Dock = System.Windows.Forms.DockStyle.Right;
            this.label261.ForeColor = System.Drawing.Color.Blue;
            this.label261.Location = new System.Drawing.Point(85, 6);
            this.label261.Name = "label261";
            this.label261.Size = new System.Drawing.Size(19, 16);
            this.label261.TabIndex = 0;
            this.label261.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label262
            // 
            this.label262.Dock = System.Windows.Forms.DockStyle.Left;
            this.label262.Location = new System.Drawing.Point(380, 0);
            this.label262.Name = "label262";
            this.label262.Size = new System.Drawing.Size(80, 24);
            this.label262.TabIndex = 3;
            this.label262.Text = "前期郁闭度";
            this.label262.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel192
            // 
            this.panel192.Controls.Add(this.Q_SZ);
            this.panel192.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel192.Location = new System.Drawing.Point(270, 0);
            this.panel192.Name = "panel192";
            this.panel192.Padding = new System.Windows.Forms.Padding(2, 4, 4, 0);
            this.panel192.Size = new System.Drawing.Size(110, 24);
            this.panel192.TabIndex = 2;
            // 
            // Q_SZ
            // 
            this.Q_SZ.AssDispValue = true;
            this.Q_SZ.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Q_SZ.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Q_SZ.ForeColor = System.Drawing.Color.Blue;
            this.Q_SZ.Location = new System.Drawing.Point(2, 2);
            this.Q_SZ.Name = "Q_SZ";
            this.Q_SZ.Size = new System.Drawing.Size(104, 22);
            this.Q_SZ.TabIndex = 24;
            // 
            // label263
            // 
            this.label263.Dock = System.Windows.Forms.DockStyle.Left;
            this.label263.Location = new System.Drawing.Point(190, 0);
            this.label263.Name = "label263";
            this.label263.Size = new System.Drawing.Size(80, 24);
            this.label263.TabIndex = 1;
            this.label263.Text = "前期树种";
            this.label263.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel209
            // 
            this.panel209.Controls.Add(this.Q_MJ);
            this.panel209.Controls.Add(this.label280);
            this.panel209.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel209.Location = new System.Drawing.Point(80, 0);
            this.panel209.Name = "panel209";
            this.panel209.Padding = new System.Windows.Forms.Padding(2, 6, 6, 2);
            this.panel209.Size = new System.Drawing.Size(110, 24);
            this.panel209.TabIndex = 0;
            // 
            // Q_MJ
            // 
            this.Q_MJ.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Q_MJ.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Q_MJ.EditScale = 0;
            this.Q_MJ.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.Q_MJ.Location = new System.Drawing.Point(2, 4);
            this.Q_MJ.Name = "Q_MJ";
            this.Q_MJ.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.Q_MJ.Properties.Appearance.Options.UseForeColor = true;
            this.Q_MJ.Properties.Appearance.Options.UseTextOptions = true;
            this.Q_MJ.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.Q_MJ.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.Q_MJ.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.Q_MJ.Properties.LookAndFeel.SkinName = "Blue";
            this.Q_MJ.Properties.MaxValue = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.Q_MJ.Size = new System.Drawing.Size(69, 18);
            this.Q_MJ.TabIndex = 11;
            // 
            // label280
            // 
            this.label280.Dock = System.Windows.Forms.DockStyle.Right;
            this.label280.ForeColor = System.Drawing.Color.Blue;
            this.label280.Location = new System.Drawing.Point(71, 6);
            this.label280.Name = "label280";
            this.label280.Size = new System.Drawing.Size(33, 16);
            this.label280.TabIndex = 0;
            this.label280.Text = "公顷";
            this.label280.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label281
            // 
            this.label281.Dock = System.Windows.Forms.DockStyle.Left;
            this.label281.Location = new System.Drawing.Point(0, 0);
            this.label281.Name = "label281";
            this.label281.Size = new System.Drawing.Size(80, 24);
            this.label281.TabIndex = 0;
            this.label281.Text = "前期面积";
            this.label281.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label282
            // 
            this.label282.BackColor = System.Drawing.Color.Black;
            this.label282.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label282.Location = new System.Drawing.Point(0, 24);
            this.label282.Name = "label282";
            this.label282.Size = new System.Drawing.Size(575, 1);
            this.label282.TabIndex = 0;
            this.label282.Text = "label282";
            this.label282.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label283
            // 
            this.label283.BackColor = System.Drawing.Color.Black;
            this.label283.Dock = System.Windows.Forms.DockStyle.Top;
            this.label283.Location = new System.Drawing.Point(1, 0);
            this.label283.Name = "label283";
            this.label283.Size = new System.Drawing.Size(575, 1);
            this.label283.TabIndex = 0;
            this.label283.Text = "label283";
            this.label283.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label284
            // 
            this.label284.BackColor = System.Drawing.Color.Black;
            this.label284.Dock = System.Windows.Forms.DockStyle.Left;
            this.label284.Location = new System.Drawing.Point(0, 0);
            this.label284.Name = "label284";
            this.label284.Size = new System.Drawing.Size(1, 126);
            this.label284.TabIndex = 0;
            this.label284.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label285
            // 
            this.label285.BackColor = System.Drawing.Color.Black;
            this.label285.Dock = System.Windows.Forms.DockStyle.Right;
            this.label285.Location = new System.Drawing.Point(576, 0);
            this.label285.Name = "label285";
            this.label285.Size = new System.Drawing.Size(1, 126);
            this.label285.TabIndex = 0;
            this.label285.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelAttr8
            // 
            this.labelAttr8.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelAttr8.Font = new System.Drawing.Font("黑体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelAttr8.Location = new System.Drawing.Point(0, 437);
            this.labelAttr8.Name = "labelAttr8";
            this.labelAttr8.Size = new System.Drawing.Size(577, 30);
            this.labelAttr8.TabIndex = 0;
            this.labelAttr8.Text = " 前期信息";
            this.labelAttr8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelAttr7
            // 
            this.panelAttr7.Controls.Add(this.panelAttr71);
            this.panelAttr7.Controls.Add(this.label161);
            this.panelAttr7.Controls.Add(this.label162);
            this.panelAttr7.Controls.Add(this.label163);
            this.panelAttr7.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelAttr7.Location = new System.Drawing.Point(0, 186);
            this.panelAttr7.Name = "panelAttr7";
            this.panelAttr7.Size = new System.Drawing.Size(577, 251);
            this.panelAttr7.TabIndex = 0;
            // 
            // panelAttr71
            // 
            this.panelAttr71.Controls.Add(this.panel171);
            this.panelAttr71.Controls.Add(this.panel167);
            this.panelAttr71.Controls.Add(this.panel121);
            this.panelAttr71.Controls.Add(this.panel117);
            this.panelAttr71.Controls.Add(this.panel78);
            this.panelAttr71.Controls.Add(this.panel50);
            this.panelAttr71.Controls.Add(this.panel130);
            this.panelAttr71.Controls.Add(this.panel134);
            this.panelAttr71.Controls.Add(this.panel138);
            this.panelAttr71.Controls.Add(this.panel142);
            this.panelAttr71.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelAttr71.Location = new System.Drawing.Point(1, 1);
            this.panelAttr71.Name = "panelAttr71";
            this.panelAttr71.Size = new System.Drawing.Size(575, 250);
            this.panelAttr71.TabIndex = 0;
            // 
            // panel171
            // 
            this.panel171.Controls.Add(this.panel168);
            this.panel171.Controls.Add(this.laBSSZXJ);
            this.panel171.Controls.Add(this.panel174);
            this.panel171.Controls.Add(this.laSSXJ);
            this.panel171.Controls.Add(this.label228);
            this.panel171.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel171.Location = new System.Drawing.Point(0, 225);
            this.panel171.Name = "panel171";
            this.panel171.Size = new System.Drawing.Size(575, 25);
            this.panel171.TabIndex = 0;
            // 
            // panel168
            // 
            this.panel168.Controls.Add(this.BSSZXJ);
            this.panel168.Controls.Add(this.label136);
            this.panel168.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel168.Location = new System.Drawing.Point(270, 0);
            this.panel168.Name = "panel168";
            this.panel168.Padding = new System.Windows.Forms.Padding(2, 6, 6, 2);
            this.panel168.Size = new System.Drawing.Size(110, 24);
            this.panel168.TabIndex = 0;
            // 
            // BSSZXJ
            // 
            this.BSSZXJ.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BSSZXJ.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BSSZXJ.EditScale = 0;
            this.BSSZXJ.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.BSSZXJ.Location = new System.Drawing.Point(2, 4);
            this.BSSZXJ.Name = "BSSZXJ";
            this.BSSZXJ.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.BSSZXJ.Properties.Appearance.Options.UseForeColor = true;
            this.BSSZXJ.Properties.Appearance.Options.UseTextOptions = true;
            this.BSSZXJ.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.BSSZXJ.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.BSSZXJ.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.BSSZXJ.Properties.LookAndFeel.SkinName = "Blue";
            this.BSSZXJ.Properties.MaxValue = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.BSSZXJ.Size = new System.Drawing.Size(77, 18);
            this.BSSZXJ.TabIndex = 38;
            this.BSSZXJ.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // label136
            // 
            this.label136.Dock = System.Windows.Forms.DockStyle.Right;
            this.label136.ForeColor = System.Drawing.Color.Blue;
            this.label136.Location = new System.Drawing.Point(79, 6);
            this.label136.Name = "label136";
            this.label136.Size = new System.Drawing.Size(25, 16);
            this.label136.TabIndex = 0;
            this.label136.Text = "m³";
            this.label136.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // laBSSZXJ
            // 
            this.laBSSZXJ.Dock = System.Windows.Forms.DockStyle.Left;
            this.laBSSZXJ.Location = new System.Drawing.Point(190, 0);
            this.laBSSZXJ.Name = "laBSSZXJ";
            this.laBSSZXJ.Size = new System.Drawing.Size(80, 24);
            this.laBSSZXJ.TabIndex = 0;
            this.laBSSZXJ.Text = "伴生树种蓄积";
            this.laBSSZXJ.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel174
            // 
            this.panel174.Controls.Add(this.SSXJ);
            this.panel174.Controls.Add(this.label135);
            this.panel174.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel174.Location = new System.Drawing.Point(80, 0);
            this.panel174.Name = "panel174";
            this.panel174.Padding = new System.Windows.Forms.Padding(2, 6, 6, 2);
            this.panel174.Size = new System.Drawing.Size(110, 24);
            this.panel174.TabIndex = 0;
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
            this.SSXJ.Properties.LookAndFeel.SkinName = "Blue";
            this.SSXJ.Properties.MaxValue = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.SSXJ.Size = new System.Drawing.Size(77, 18);
            this.SSXJ.TabIndex = 37;
            this.SSXJ.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // label135
            // 
            this.label135.Dock = System.Windows.Forms.DockStyle.Right;
            this.label135.ForeColor = System.Drawing.Color.Blue;
            this.label135.Location = new System.Drawing.Point(79, 6);
            this.label135.Name = "label135";
            this.label135.Size = new System.Drawing.Size(25, 16);
            this.label135.TabIndex = 0;
            this.label135.Text = "m³";
            this.label135.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // laSSXJ
            // 
            this.laSSXJ.Dock = System.Windows.Forms.DockStyle.Left;
            this.laSSXJ.Location = new System.Drawing.Point(0, 0);
            this.laSSXJ.Name = "laSSXJ";
            this.laSSXJ.Size = new System.Drawing.Size(80, 24);
            this.laSSXJ.TabIndex = 0;
            this.laSSXJ.Text = "散生四旁蓄积";
            this.laSSXJ.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label228
            // 
            this.label228.BackColor = System.Drawing.Color.Black;
            this.label228.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label228.Location = new System.Drawing.Point(0, 24);
            this.label228.Name = "label228";
            this.label228.Size = new System.Drawing.Size(575, 1);
            this.label228.TabIndex = 0;
            this.label228.Text = "label228";
            this.label228.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel167
            // 
            this.panel167.Controls.Add(this.panel169);
            this.panel167.Controls.Add(this.laYSSZXJ);
            this.panel167.Controls.Add(this.panel170);
            this.panel167.Controls.Add(this.laSLXJ);
            this.panel167.Controls.Add(this.label224);
            this.panel167.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel167.Location = new System.Drawing.Point(0, 200);
            this.panel167.Name = "panel167";
            this.panel167.Size = new System.Drawing.Size(575, 25);
            this.panel167.TabIndex = 0;
            // 
            // panel169
            // 
            this.panel169.Controls.Add(this.YSSZXJ);
            this.panel169.Controls.Add(this.label134);
            this.panel169.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel169.Location = new System.Drawing.Point(270, 0);
            this.panel169.Name = "panel169";
            this.panel169.Padding = new System.Windows.Forms.Padding(2, 6, 6, 2);
            this.panel169.Size = new System.Drawing.Size(110, 24);
            this.panel169.TabIndex = 0;
            // 
            // YSSZXJ
            // 
            this.YSSZXJ.Cursor = System.Windows.Forms.Cursors.Hand;
            this.YSSZXJ.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.YSSZXJ.EditScale = 0;
            this.YSSZXJ.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.YSSZXJ.Location = new System.Drawing.Point(2, 4);
            this.YSSZXJ.Name = "YSSZXJ";
            this.YSSZXJ.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.YSSZXJ.Properties.Appearance.Options.UseForeColor = true;
            this.YSSZXJ.Properties.Appearance.Options.UseTextOptions = true;
            this.YSSZXJ.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.YSSZXJ.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.YSSZXJ.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.YSSZXJ.Properties.LookAndFeel.SkinName = "Blue";
            this.YSSZXJ.Properties.MaxValue = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.YSSZXJ.Size = new System.Drawing.Size(77, 18);
            this.YSSZXJ.TabIndex = 36;
            this.YSSZXJ.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // label134
            // 
            this.label134.Dock = System.Windows.Forms.DockStyle.Right;
            this.label134.ForeColor = System.Drawing.Color.Blue;
            this.label134.Location = new System.Drawing.Point(79, 6);
            this.label134.Name = "label134";
            this.label134.Size = new System.Drawing.Size(25, 16);
            this.label134.TabIndex = 0;
            this.label134.Text = "m³";
            this.label134.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // laYSSZXJ
            // 
            this.laYSSZXJ.Dock = System.Windows.Forms.DockStyle.Left;
            this.laYSSZXJ.Location = new System.Drawing.Point(190, 0);
            this.laYSSZXJ.Name = "laYSSZXJ";
            this.laYSSZXJ.Size = new System.Drawing.Size(80, 24);
            this.laYSSZXJ.TabIndex = 0;
            this.laYSSZXJ.Text = "优势树种蓄积";
            this.laYSSZXJ.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel170
            // 
            this.panel170.Controls.Add(this.SLXJ);
            this.panel170.Controls.Add(this.label129);
            this.panel170.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel170.Location = new System.Drawing.Point(80, 0);
            this.panel170.Name = "panel170";
            this.panel170.Padding = new System.Windows.Forms.Padding(2, 6, 6, 2);
            this.panel170.Size = new System.Drawing.Size(110, 24);
            this.panel170.TabIndex = 0;
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
            this.SLXJ.Properties.LookAndFeel.SkinName = "Blue";
            this.SLXJ.Properties.MaxValue = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.SLXJ.Size = new System.Drawing.Size(77, 18);
            this.SLXJ.TabIndex = 35;
            this.SLXJ.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // label129
            // 
            this.label129.Dock = System.Windows.Forms.DockStyle.Right;
            this.label129.ForeColor = System.Drawing.Color.Blue;
            this.label129.Location = new System.Drawing.Point(79, 6);
            this.label129.Name = "label129";
            this.label129.Size = new System.Drawing.Size(25, 16);
            this.label129.TabIndex = 0;
            this.label129.Text = "m³";
            this.label129.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // laSLXJ
            // 
            this.laSLXJ.Dock = System.Windows.Forms.DockStyle.Left;
            this.laSLXJ.Location = new System.Drawing.Point(0, 0);
            this.laSLXJ.Name = "laSLXJ";
            this.laSLXJ.Size = new System.Drawing.Size(80, 24);
            this.laSLXJ.TabIndex = 0;
            this.laSLXJ.Text = "森林蓄积";
            this.laSLXJ.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label224
            // 
            this.label224.BackColor = System.Drawing.Color.Black;
            this.label224.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label224.Location = new System.Drawing.Point(0, 24);
            this.label224.Name = "label224";
            this.label224.Size = new System.Drawing.Size(575, 1);
            this.label224.TabIndex = 0;
            this.label224.Text = "label224";
            this.label224.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel121
            // 
            this.panel121.Controls.Add(this.panel122);
            this.panel121.Controls.Add(this.laZXJ);
            this.panel121.Controls.Add(this.panel123);
            this.panel121.Controls.Add(this.laMEI_GQ_ZS);
            this.panel121.Controls.Add(this.panel124);
            this.panel121.Controls.Add(this.laHUO_LMGQXJ);
            this.panel121.Controls.Add(this.label180);
            this.panel121.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel121.Location = new System.Drawing.Point(0, 175);
            this.panel121.Name = "panel121";
            this.panel121.Size = new System.Drawing.Size(575, 25);
            this.panel121.TabIndex = 0;
            // 
            // panel122
            // 
            this.panel122.Controls.Add(this.ZXJ);
            this.panel122.Controls.Add(this.label98);
            this.panel122.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel122.Location = new System.Drawing.Point(460, 0);
            this.panel122.Name = "panel122";
            this.panel122.Padding = new System.Windows.Forms.Padding(2, 6, 6, 2);
            this.panel122.Size = new System.Drawing.Size(110, 24);
            this.panel122.TabIndex = 0;
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
            this.ZXJ.Properties.LookAndFeel.SkinName = "Blue";
            this.ZXJ.Properties.MaxValue = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.ZXJ.Size = new System.Drawing.Size(77, 18);
            this.ZXJ.TabIndex = 34;
            this.ZXJ.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // label98
            // 
            this.label98.Dock = System.Windows.Forms.DockStyle.Right;
            this.label98.ForeColor = System.Drawing.Color.Blue;
            this.label98.Location = new System.Drawing.Point(79, 6);
            this.label98.Name = "label98";
            this.label98.Size = new System.Drawing.Size(25, 16);
            this.label98.TabIndex = 0;
            this.label98.Text = "m³";
            this.label98.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // laZXJ
            // 
            this.laZXJ.Dock = System.Windows.Forms.DockStyle.Left;
            this.laZXJ.Location = new System.Drawing.Point(408, 0);
            this.laZXJ.Name = "laZXJ";
            this.laZXJ.Size = new System.Drawing.Size(52, 24);
            this.laZXJ.TabIndex = 0;
            this.laZXJ.Text = "总蓄积";
            this.laZXJ.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel123
            // 
            this.panel123.Controls.Add(this.MEI_GQ_ZS);
            this.panel123.Controls.Add(this.label80);
            this.panel123.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel123.Location = new System.Drawing.Point(298, 0);
            this.panel123.Name = "panel123";
            this.panel123.Padding = new System.Windows.Forms.Padding(2, 6, 6, 2);
            this.panel123.Size = new System.Drawing.Size(110, 24);
            this.panel123.TabIndex = 0;
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
            this.MEI_GQ_ZS.Properties.LookAndFeel.SkinName = "Blue";
            this.MEI_GQ_ZS.Properties.MaxValue = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.MEI_GQ_ZS.Size = new System.Drawing.Size(83, 18);
            this.MEI_GQ_ZS.TabIndex = 33;
            this.MEI_GQ_ZS.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // label80
            // 
            this.label80.Dock = System.Windows.Forms.DockStyle.Right;
            this.label80.ForeColor = System.Drawing.Color.Blue;
            this.label80.Location = new System.Drawing.Point(85, 6);
            this.label80.Name = "label80";
            this.label80.Size = new System.Drawing.Size(19, 16);
            this.label80.TabIndex = 0;
            this.label80.Text = "株";
            this.label80.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // laMEI_GQ_ZS
            // 
            this.laMEI_GQ_ZS.Dock = System.Windows.Forms.DockStyle.Left;
            this.laMEI_GQ_ZS.Location = new System.Drawing.Point(218, 0);
            this.laMEI_GQ_ZS.Name = "laMEI_GQ_ZS";
            this.laMEI_GQ_ZS.Size = new System.Drawing.Size(80, 24);
            this.laMEI_GQ_ZS.TabIndex = 0;
            this.laMEI_GQ_ZS.Text = "每公顷株数";
            this.laMEI_GQ_ZS.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel124
            // 
            this.panel124.Controls.Add(this.HUO_LMGQXJ);
            this.panel124.Controls.Add(this.label76);
            this.panel124.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel124.Location = new System.Drawing.Point(108, 0);
            this.panel124.Name = "panel124";
            this.panel124.Padding = new System.Windows.Forms.Padding(2, 6, 6, 2);
            this.panel124.Size = new System.Drawing.Size(110, 24);
            this.panel124.TabIndex = 0;
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
            this.HUO_LMGQXJ.Properties.LookAndFeel.SkinName = "Blue";
            this.HUO_LMGQXJ.Properties.MaxValue = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.HUO_LMGQXJ.Size = new System.Drawing.Size(77, 18);
            this.HUO_LMGQXJ.TabIndex = 32;
            this.HUO_LMGQXJ.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // label76
            // 
            this.label76.Dock = System.Windows.Forms.DockStyle.Right;
            this.label76.ForeColor = System.Drawing.Color.Blue;
            this.label76.Location = new System.Drawing.Point(79, 6);
            this.label76.Name = "label76";
            this.label76.Size = new System.Drawing.Size(25, 16);
            this.label76.TabIndex = 0;
            this.label76.Text = "m³";
            this.label76.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // laHUO_LMGQXJ
            // 
            this.laHUO_LMGQXJ.Dock = System.Windows.Forms.DockStyle.Left;
            this.laHUO_LMGQXJ.Location = new System.Drawing.Point(0, 0);
            this.laHUO_LMGQXJ.Name = "laHUO_LMGQXJ";
            this.laHUO_LMGQXJ.Size = new System.Drawing.Size(108, 24);
            this.laHUO_LMGQXJ.TabIndex = 0;
            this.laHUO_LMGQXJ.Text = "公顷蓄积(活立木)";
            this.laHUO_LMGQXJ.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label180
            // 
            this.label180.BackColor = System.Drawing.Color.Black;
            this.label180.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label180.Location = new System.Drawing.Point(0, 24);
            this.label180.Name = "label180";
            this.label180.Size = new System.Drawing.Size(575, 1);
            this.label180.TabIndex = 0;
            this.label180.Text = "label180";
            this.label180.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel117
            // 
            this.panel117.Controls.Add(this.panel118);
            this.panel117.Controls.Add(this.laPINGJUN_DM);
            this.panel117.Controls.Add(this.panel119);
            this.panel117.Controls.Add(this.laPINGJUN_SG);
            this.panel117.Controls.Add(this.panel120);
            this.panel117.Controls.Add(this.laPINGJUN_XJ);
            this.panel117.Controls.Add(this.label176);
            this.panel117.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel117.Location = new System.Drawing.Point(0, 150);
            this.panel117.Name = "panel117";
            this.panel117.Size = new System.Drawing.Size(575, 25);
            this.panel117.TabIndex = 0;
            // 
            // panel118
            // 
            this.panel118.Controls.Add(this.PINGJUN_DM);
            this.panel118.Controls.Add(this.label65);
            this.panel118.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel118.Location = new System.Drawing.Point(460, 0);
            this.panel118.Name = "panel118";
            this.panel118.Padding = new System.Windows.Forms.Padding(2, 6, 6, 2);
            this.panel118.Size = new System.Drawing.Size(110, 24);
            this.panel118.TabIndex = 0;
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
            this.PINGJUN_DM.Properties.LookAndFeel.SkinName = "Blue";
            this.PINGJUN_DM.Properties.MaxValue = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.PINGJUN_DM.Size = new System.Drawing.Size(77, 18);
            this.PINGJUN_DM.TabIndex = 31;
            this.PINGJUN_DM.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // label65
            // 
            this.label65.Dock = System.Windows.Forms.DockStyle.Right;
            this.label65.ForeColor = System.Drawing.Color.Blue;
            this.label65.Location = new System.Drawing.Point(79, 6);
            this.label65.Name = "label65";
            this.label65.Size = new System.Drawing.Size(25, 16);
            this.label65.TabIndex = 0;
            this.label65.Text = "m²";
            this.label65.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // laPINGJUN_DM
            // 
            this.laPINGJUN_DM.Dock = System.Windows.Forms.DockStyle.Left;
            this.laPINGJUN_DM.Location = new System.Drawing.Point(380, 0);
            this.laPINGJUN_DM.Name = "laPINGJUN_DM";
            this.laPINGJUN_DM.Size = new System.Drawing.Size(80, 24);
            this.laPINGJUN_DM.TabIndex = 0;
            this.laPINGJUN_DM.Text = "平均断面积";
            this.laPINGJUN_DM.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel119
            // 
            this.panel119.Controls.Add(this.PINGJUN_SG);
            this.panel119.Controls.Add(this.label66);
            this.panel119.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel119.Location = new System.Drawing.Point(270, 0);
            this.panel119.Name = "panel119";
            this.panel119.Padding = new System.Windows.Forms.Padding(2, 6, 6, 2);
            this.panel119.Size = new System.Drawing.Size(110, 24);
            this.panel119.TabIndex = 0;
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
            this.PINGJUN_SG.Properties.LookAndFeel.SkinName = "Blue";
            this.PINGJUN_SG.Properties.MaxValue = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.PINGJUN_SG.Size = new System.Drawing.Size(83, 18);
            this.PINGJUN_SG.TabIndex = 30;
            this.PINGJUN_SG.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // label66
            // 
            this.label66.Dock = System.Windows.Forms.DockStyle.Right;
            this.label66.ForeColor = System.Drawing.Color.Blue;
            this.label66.Location = new System.Drawing.Point(85, 6);
            this.label66.Name = "label66";
            this.label66.Size = new System.Drawing.Size(19, 16);
            this.label66.TabIndex = 0;
            this.label66.Text = "m";
            this.label66.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // laPINGJUN_SG
            // 
            this.laPINGJUN_SG.Dock = System.Windows.Forms.DockStyle.Left;
            this.laPINGJUN_SG.Location = new System.Drawing.Point(190, 0);
            this.laPINGJUN_SG.Name = "laPINGJUN_SG";
            this.laPINGJUN_SG.Size = new System.Drawing.Size(80, 24);
            this.laPINGJUN_SG.TabIndex = 0;
            this.laPINGJUN_SG.Text = "平均树高";
            this.laPINGJUN_SG.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel120
            // 
            this.panel120.Controls.Add(this.PINGJUN_XJ);
            this.panel120.Controls.Add(this.label67);
            this.panel120.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel120.Location = new System.Drawing.Point(80, 0);
            this.panel120.Name = "panel120";
            this.panel120.Padding = new System.Windows.Forms.Padding(2, 6, 6, 2);
            this.panel120.Size = new System.Drawing.Size(110, 24);
            this.panel120.TabIndex = 0;
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
            this.PINGJUN_XJ.Properties.LookAndFeel.SkinName = "Blue";
            this.PINGJUN_XJ.Properties.MaxValue = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.PINGJUN_XJ.Size = new System.Drawing.Size(77, 18);
            this.PINGJUN_XJ.TabIndex = 29;
            this.PINGJUN_XJ.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // label67
            // 
            this.label67.Dock = System.Windows.Forms.DockStyle.Right;
            this.label67.ForeColor = System.Drawing.Color.Blue;
            this.label67.Location = new System.Drawing.Point(79, 6);
            this.label67.Name = "label67";
            this.label67.Size = new System.Drawing.Size(25, 16);
            this.label67.TabIndex = 0;
            this.label67.Text = "cm";
            this.label67.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // laPINGJUN_XJ
            // 
            this.laPINGJUN_XJ.Dock = System.Windows.Forms.DockStyle.Left;
            this.laPINGJUN_XJ.Location = new System.Drawing.Point(0, 0);
            this.laPINGJUN_XJ.Name = "laPINGJUN_XJ";
            this.laPINGJUN_XJ.Size = new System.Drawing.Size(80, 24);
            this.laPINGJUN_XJ.TabIndex = 0;
            this.laPINGJUN_XJ.Text = "平均胸径";
            this.laPINGJUN_XJ.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label176
            // 
            this.label176.BackColor = System.Drawing.Color.Black;
            this.label176.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label176.Location = new System.Drawing.Point(0, 24);
            this.label176.Name = "label176";
            this.label176.Size = new System.Drawing.Size(575, 1);
            this.label176.TabIndex = 0;
            this.label176.Text = "label176";
            this.label176.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel78
            // 
            this.panel78.Controls.Add(this.panel104);
            this.panel78.Controls.Add(this.laLING_ZU);
            this.panel78.Controls.Add(this.panel106);
            this.panel78.Controls.Add(this.laLJ);
            this.panel78.Controls.Add(this.panel116);
            this.panel78.Controls.Add(this.laPINGJUN_NL);
            this.panel78.Controls.Add(this.label172);
            this.panel78.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel78.Location = new System.Drawing.Point(0, 125);
            this.panel78.Name = "panel78";
            this.panel78.Size = new System.Drawing.Size(575, 25);
            this.panel78.TabIndex = 0;
            // 
            // panel104
            // 
            this.panel104.Controls.Add(this.LING_ZU);
            this.panel104.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel104.Location = new System.Drawing.Point(460, 0);
            this.panel104.Name = "panel104";
            this.panel104.Padding = new System.Windows.Forms.Padding(2, 4, 4, 0);
            this.panel104.Size = new System.Drawing.Size(110, 24);
            this.panel104.TabIndex = 0;
            // 
            // LING_ZU
            // 
            this.LING_ZU.AssDispValue = true;
            this.LING_ZU.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LING_ZU.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.LING_ZU.ForeColor = System.Drawing.Color.Blue;
            this.LING_ZU.Location = new System.Drawing.Point(2, 2);
            this.LING_ZU.Name = "LING_ZU";
            this.LING_ZU.Size = new System.Drawing.Size(104, 22);
            this.LING_ZU.TabIndex = 28;
            this.LING_ZU.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // laLING_ZU
            // 
            this.laLING_ZU.Dock = System.Windows.Forms.DockStyle.Left;
            this.laLING_ZU.Location = new System.Drawing.Point(380, 0);
            this.laLING_ZU.Name = "laLING_ZU";
            this.laLING_ZU.Size = new System.Drawing.Size(80, 24);
            this.laLING_ZU.TabIndex = 0;
            this.laLING_ZU.Text = "龄组";
            this.laLING_ZU.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel106
            // 
            this.panel106.Controls.Add(this.LJ);
            this.panel106.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel106.Location = new System.Drawing.Point(270, 0);
            this.panel106.Name = "panel106";
            this.panel106.Padding = new System.Windows.Forms.Padding(2, 6, 8, 0);
            this.panel106.Size = new System.Drawing.Size(110, 24);
            this.panel106.TabIndex = 0;
            // 
            // LJ
            // 
            this.LJ.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.LJ.EditValue = "";
            this.LJ.Location = new System.Drawing.Point(2, 8);
            this.LJ.Name = "LJ";
            this.LJ.Properties.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LJ.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.LJ.Properties.Appearance.Options.UseFont = true;
            this.LJ.Properties.Appearance.Options.UseForeColor = true;
            this.LJ.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.LJ.Properties.MaxLength = 3;
            this.LJ.Size = new System.Drawing.Size(100, 16);
            this.LJ.TabIndex = 27;
            this.LJ.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // laLJ
            // 
            this.laLJ.Dock = System.Windows.Forms.DockStyle.Left;
            this.laLJ.Location = new System.Drawing.Point(190, 0);
            this.laLJ.Name = "laLJ";
            this.laLJ.Size = new System.Drawing.Size(80, 24);
            this.laLJ.TabIndex = 0;
            this.laLJ.Text = "龄级";
            this.laLJ.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel116
            // 
            this.panel116.Controls.Add(this.PINGJUN_NL);
            this.panel116.Controls.Add(this.label64);
            this.panel116.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel116.Location = new System.Drawing.Point(80, 0);
            this.panel116.Name = "panel116";
            this.panel116.Padding = new System.Windows.Forms.Padding(2, 6, 6, 2);
            this.panel116.Size = new System.Drawing.Size(110, 24);
            this.panel116.TabIndex = 0;
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
            this.PINGJUN_NL.Properties.LookAndFeel.SkinName = "Blue";
            this.PINGJUN_NL.Properties.MaxValue = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.PINGJUN_NL.Size = new System.Drawing.Size(83, 18);
            this.PINGJUN_NL.TabIndex = 26;
            this.PINGJUN_NL.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // label64
            // 
            this.label64.Dock = System.Windows.Forms.DockStyle.Right;
            this.label64.ForeColor = System.Drawing.Color.Blue;
            this.label64.Location = new System.Drawing.Point(85, 6);
            this.label64.Name = "label64";
            this.label64.Size = new System.Drawing.Size(19, 16);
            this.label64.TabIndex = 0;
            this.label64.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // laPINGJUN_NL
            // 
            this.laPINGJUN_NL.Dock = System.Windows.Forms.DockStyle.Left;
            this.laPINGJUN_NL.Location = new System.Drawing.Point(0, 0);
            this.laPINGJUN_NL.Name = "laPINGJUN_NL";
            this.laPINGJUN_NL.Size = new System.Drawing.Size(80, 24);
            this.laPINGJUN_NL.TabIndex = 0;
            this.laPINGJUN_NL.Text = "平均年龄";
            this.laPINGJUN_NL.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label172
            // 
            this.label172.BackColor = System.Drawing.Color.Black;
            this.label172.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label172.Location = new System.Drawing.Point(0, 24);
            this.label172.Name = "label172";
            this.label172.Size = new System.Drawing.Size(575, 1);
            this.label172.TabIndex = 0;
            this.label172.Text = "label172";
            this.label172.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel50
            // 
            this.panel50.Controls.Add(this.panel56);
            this.panel50.Controls.Add(this.laYU_BI_DU);
            this.panel50.Controls.Add(this.panel74);
            this.panel50.Controls.Add(this.laYOU_SHI_SZ);
            this.panel50.Controls.Add(this.panel75);
            this.panel50.Controls.Add(this.laQI_YUAN);
            this.panel50.Controls.Add(this.label168);
            this.panel50.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel50.Location = new System.Drawing.Point(0, 100);
            this.panel50.Name = "panel50";
            this.panel50.Size = new System.Drawing.Size(575, 25);
            this.panel50.TabIndex = 0;
            // 
            // panel56
            // 
            this.panel56.Controls.Add(this.YU_BI_DU);
            this.panel56.Controls.Add(this.label62);
            this.panel56.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel56.Location = new System.Drawing.Point(460, 0);
            this.panel56.Name = "panel56";
            this.panel56.Padding = new System.Windows.Forms.Padding(2, 6, 6, 2);
            this.panel56.Size = new System.Drawing.Size(110, 24);
            this.panel56.TabIndex = 0;
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
            this.YU_BI_DU.Properties.LookAndFeel.SkinName = "Blue";
            this.YU_BI_DU.Properties.MaxValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.YU_BI_DU.Size = new System.Drawing.Size(83, 18);
            this.YU_BI_DU.TabIndex = 25;
            this.YU_BI_DU.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // label62
            // 
            this.label62.Dock = System.Windows.Forms.DockStyle.Right;
            this.label62.ForeColor = System.Drawing.Color.Blue;
            this.label62.Location = new System.Drawing.Point(85, 6);
            this.label62.Name = "label62";
            this.label62.Size = new System.Drawing.Size(19, 16);
            this.label62.TabIndex = 0;
            this.label62.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // laYU_BI_DU
            // 
            this.laYU_BI_DU.Dock = System.Windows.Forms.DockStyle.Left;
            this.laYU_BI_DU.Location = new System.Drawing.Point(380, 0);
            this.laYU_BI_DU.Name = "laYU_BI_DU";
            this.laYU_BI_DU.Size = new System.Drawing.Size(80, 24);
            this.laYU_BI_DU.TabIndex = 0;
            this.laYU_BI_DU.Text = "郁闭度";
            this.laYU_BI_DU.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel74
            // 
            this.panel74.Controls.Add(this.YOU_SHI_SZ);
            this.panel74.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel74.Location = new System.Drawing.Point(270, 0);
            this.panel74.Name = "panel74";
            this.panel74.Padding = new System.Windows.Forms.Padding(2, 4, 4, 0);
            this.panel74.Size = new System.Drawing.Size(110, 24);
            this.panel74.TabIndex = 0;
            // 
            // YOU_SHI_SZ
            // 
            this.YOU_SHI_SZ.AssDispValue = true;
            this.YOU_SHI_SZ.Cursor = System.Windows.Forms.Cursors.Hand;
            this.YOU_SHI_SZ.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.YOU_SHI_SZ.ForeColor = System.Drawing.Color.Blue;
            this.YOU_SHI_SZ.Location = new System.Drawing.Point(2, 2);
            this.YOU_SHI_SZ.Name = "YOU_SHI_SZ";
            this.YOU_SHI_SZ.Size = new System.Drawing.Size(104, 22);
            this.YOU_SHI_SZ.TabIndex = 24;
            this.YOU_SHI_SZ.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // laYOU_SHI_SZ
            // 
            this.laYOU_SHI_SZ.Dock = System.Windows.Forms.DockStyle.Left;
            this.laYOU_SHI_SZ.Location = new System.Drawing.Point(190, 0);
            this.laYOU_SHI_SZ.Name = "laYOU_SHI_SZ";
            this.laYOU_SHI_SZ.Size = new System.Drawing.Size(80, 24);
            this.laYOU_SHI_SZ.TabIndex = 0;
            this.laYOU_SHI_SZ.Text = "优势树种";
            this.laYOU_SHI_SZ.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel75
            // 
            this.panel75.Controls.Add(this.QI_YUAN);
            this.panel75.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel75.Location = new System.Drawing.Point(80, 0);
            this.panel75.Name = "panel75";
            this.panel75.Padding = new System.Windows.Forms.Padding(2, 4, 4, 0);
            this.panel75.Size = new System.Drawing.Size(110, 24);
            this.panel75.TabIndex = 0;
            // 
            // QI_YUAN
            // 
            this.QI_YUAN.AssDispValue = true;
            this.QI_YUAN.Cursor = System.Windows.Forms.Cursors.Hand;
            this.QI_YUAN.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.QI_YUAN.ForeColor = System.Drawing.Color.Blue;
            this.QI_YUAN.Location = new System.Drawing.Point(2, 2);
            this.QI_YUAN.Name = "QI_YUAN";
            this.QI_YUAN.Size = new System.Drawing.Size(104, 22);
            this.QI_YUAN.TabIndex = 23;
            this.QI_YUAN.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // laQI_YUAN
            // 
            this.laQI_YUAN.Dock = System.Windows.Forms.DockStyle.Left;
            this.laQI_YUAN.Location = new System.Drawing.Point(0, 0);
            this.laQI_YUAN.Name = "laQI_YUAN";
            this.laQI_YUAN.Size = new System.Drawing.Size(80, 24);
            this.laQI_YUAN.TabIndex = 0;
            this.laQI_YUAN.Text = "起源";
            this.laQI_YUAN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label168
            // 
            this.label168.BackColor = System.Drawing.Color.Black;
            this.label168.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label168.Location = new System.Drawing.Point(0, 24);
            this.label168.Name = "label168";
            this.label168.Size = new System.Drawing.Size(575, 1);
            this.label168.TabIndex = 0;
            this.label168.Text = "label168";
            this.label168.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel130
            // 
            this.panel130.Controls.Add(this.panel131);
            this.panel130.Controls.Add(this.laLIN_ZHONG);
            this.panel130.Controls.Add(this.panel132);
            this.panel130.Controls.Add(this.laQ_LIN_ZHONG);
            this.panel130.Controls.Add(this.panel133);
            this.panel130.Controls.Add(this.laSEN_LIN_LB);
            this.panel130.Controls.Add(this.label148);
            this.panel130.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel130.Location = new System.Drawing.Point(0, 75);
            this.panel130.Name = "panel130";
            this.panel130.Size = new System.Drawing.Size(575, 25);
            this.panel130.TabIndex = 0;
            // 
            // panel131
            // 
            this.panel131.Controls.Add(this.LIN_ZHONG);
            this.panel131.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel131.Location = new System.Drawing.Point(460, 0);
            this.panel131.Name = "panel131";
            this.panel131.Padding = new System.Windows.Forms.Padding(2, 4, 4, 0);
            this.panel131.Size = new System.Drawing.Size(110, 24);
            this.panel131.TabIndex = 0;
            // 
            // LIN_ZHONG
            // 
            this.LIN_ZHONG.AssDispValue = true;
            this.LIN_ZHONG.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LIN_ZHONG.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.LIN_ZHONG.ForeColor = System.Drawing.Color.Blue;
            this.LIN_ZHONG.Location = new System.Drawing.Point(2, 2);
            this.LIN_ZHONG.Name = "LIN_ZHONG";
            this.LIN_ZHONG.Size = new System.Drawing.Size(104, 22);
            this.LIN_ZHONG.TabIndex = 22;
            this.LIN_ZHONG.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // laLIN_ZHONG
            // 
            this.laLIN_ZHONG.Dock = System.Windows.Forms.DockStyle.Left;
            this.laLIN_ZHONG.Location = new System.Drawing.Point(380, 0);
            this.laLIN_ZHONG.Name = "laLIN_ZHONG";
            this.laLIN_ZHONG.Size = new System.Drawing.Size(80, 24);
            this.laLIN_ZHONG.TabIndex = 0;
            this.laLIN_ZHONG.Text = "林种";
            this.laLIN_ZHONG.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel132
            // 
            this.panel132.Controls.Add(this.Q_LIN_ZHONG);
            this.panel132.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel132.Location = new System.Drawing.Point(270, 0);
            this.panel132.Name = "panel132";
            this.panel132.Padding = new System.Windows.Forms.Padding(2, 4, 4, 0);
            this.panel132.Size = new System.Drawing.Size(110, 24);
            this.panel132.TabIndex = 0;
            // 
            // Q_LIN_ZHONG
            // 
            this.Q_LIN_ZHONG.AssDispValue = true;
            this.Q_LIN_ZHONG.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Q_LIN_ZHONG.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Q_LIN_ZHONG.ForeColor = System.Drawing.Color.Blue;
            this.Q_LIN_ZHONG.Location = new System.Drawing.Point(2, 2);
            this.Q_LIN_ZHONG.Name = "Q_LIN_ZHONG";
            this.Q_LIN_ZHONG.Size = new System.Drawing.Size(104, 22);
            this.Q_LIN_ZHONG.TabIndex = 21;
            this.Q_LIN_ZHONG.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // laQ_LIN_ZHONG
            // 
            this.laQ_LIN_ZHONG.Dock = System.Windows.Forms.DockStyle.Left;
            this.laQ_LIN_ZHONG.Location = new System.Drawing.Point(190, 0);
            this.laQ_LIN_ZHONG.Name = "laQ_LIN_ZHONG";
            this.laQ_LIN_ZHONG.Size = new System.Drawing.Size(80, 24);
            this.laQ_LIN_ZHONG.TabIndex = 0;
            this.laQ_LIN_ZHONG.Text = "前期林种";
            this.laQ_LIN_ZHONG.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel133
            // 
            this.panel133.Controls.Add(this.SEN_LIN_LB);
            this.panel133.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel133.Location = new System.Drawing.Point(80, 0);
            this.panel133.Name = "panel133";
            this.panel133.Padding = new System.Windows.Forms.Padding(2, 4, 4, 0);
            this.panel133.Size = new System.Drawing.Size(110, 24);
            this.panel133.TabIndex = 0;
            // 
            // SEN_LIN_LB
            // 
            this.SEN_LIN_LB.AssDispValue = true;
            this.SEN_LIN_LB.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SEN_LIN_LB.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.SEN_LIN_LB.ForeColor = System.Drawing.Color.Blue;
            this.SEN_LIN_LB.Location = new System.Drawing.Point(2, 2);
            this.SEN_LIN_LB.Name = "SEN_LIN_LB";
            this.SEN_LIN_LB.Size = new System.Drawing.Size(104, 22);
            this.SEN_LIN_LB.TabIndex = 20;
            this.SEN_LIN_LB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // laSEN_LIN_LB
            // 
            this.laSEN_LIN_LB.Dock = System.Windows.Forms.DockStyle.Left;
            this.laSEN_LIN_LB.Location = new System.Drawing.Point(0, 0);
            this.laSEN_LIN_LB.Name = "laSEN_LIN_LB";
            this.laSEN_LIN_LB.Size = new System.Drawing.Size(80, 24);
            this.laSEN_LIN_LB.TabIndex = 0;
            this.laSEN_LIN_LB.Text = "森林类别";
            this.laSEN_LIN_LB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label148
            // 
            this.label148.BackColor = System.Drawing.Color.Black;
            this.label148.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label148.Location = new System.Drawing.Point(0, 24);
            this.label148.Name = "label148";
            this.label148.Size = new System.Drawing.Size(575, 1);
            this.label148.TabIndex = 0;
            this.label148.Text = "label148";
            this.label148.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel134
            // 
            this.panel134.Controls.Add(this.panel135);
            this.panel134.Controls.Add(this.laQ_SEN_LB);
            this.panel134.Controls.Add(this.panel136);
            this.panel134.Controls.Add(this.laDI_LEI);
            this.panel134.Controls.Add(this.panel137);
            this.panel134.Controls.Add(this.laQ_DI_LEI);
            this.panel134.Controls.Add(this.label152);
            this.panel134.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel134.Location = new System.Drawing.Point(0, 50);
            this.panel134.Name = "panel134";
            this.panel134.Size = new System.Drawing.Size(575, 25);
            this.panel134.TabIndex = 0;
            // 
            // panel135
            // 
            this.panel135.Controls.Add(this.Q_SEN_LB);
            this.panel135.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel135.Location = new System.Drawing.Point(460, 0);
            this.panel135.Name = "panel135";
            this.panel135.Padding = new System.Windows.Forms.Padding(2, 4, 4, 0);
            this.panel135.Size = new System.Drawing.Size(110, 24);
            this.panel135.TabIndex = 0;
            // 
            // Q_SEN_LB
            // 
            this.Q_SEN_LB.AssDispValue = true;
            this.Q_SEN_LB.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Q_SEN_LB.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Q_SEN_LB.ForeColor = System.Drawing.Color.Blue;
            this.Q_SEN_LB.Location = new System.Drawing.Point(2, 2);
            this.Q_SEN_LB.Name = "Q_SEN_LB";
            this.Q_SEN_LB.Size = new System.Drawing.Size(104, 22);
            this.Q_SEN_LB.TabIndex = 19;
            this.Q_SEN_LB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // laQ_SEN_LB
            // 
            this.laQ_SEN_LB.Dock = System.Windows.Forms.DockStyle.Left;
            this.laQ_SEN_LB.Location = new System.Drawing.Point(380, 0);
            this.laQ_SEN_LB.Name = "laQ_SEN_LB";
            this.laQ_SEN_LB.Size = new System.Drawing.Size(80, 24);
            this.laQ_SEN_LB.TabIndex = 0;
            this.laQ_SEN_LB.Text = "前期森林类别";
            this.laQ_SEN_LB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel136
            // 
            this.panel136.Controls.Add(this.DI_LEI);
            this.panel136.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel136.Location = new System.Drawing.Point(250, 0);
            this.panel136.Name = "panel136";
            this.panel136.Padding = new System.Windows.Forms.Padding(2, 4, 4, 0);
            this.panel136.Size = new System.Drawing.Size(130, 24);
            this.panel136.TabIndex = 0;
            // 
            // DI_LEI
            // 
            this.DI_LEI.AssDispValue = true;
            this.DI_LEI.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DI_LEI.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.DI_LEI.ForeColor = System.Drawing.Color.Blue;
            this.DI_LEI.Location = new System.Drawing.Point(2, 2);
            this.DI_LEI.Name = "DI_LEI";
            this.DI_LEI.Size = new System.Drawing.Size(124, 22);
            this.DI_LEI.TabIndex = 18;
            this.DI_LEI.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // laDI_LEI
            // 
            this.laDI_LEI.Dock = System.Windows.Forms.DockStyle.Left;
            this.laDI_LEI.Location = new System.Drawing.Point(190, 0);
            this.laDI_LEI.Name = "laDI_LEI";
            this.laDI_LEI.Size = new System.Drawing.Size(60, 24);
            this.laDI_LEI.TabIndex = 0;
            this.laDI_LEI.Text = "地类";
            this.laDI_LEI.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel137
            // 
            this.panel137.Controls.Add(this.Q_DI_LEI);
            this.panel137.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel137.Location = new System.Drawing.Point(80, 0);
            this.panel137.Name = "panel137";
            this.panel137.Padding = new System.Windows.Forms.Padding(2, 4, 4, 0);
            this.panel137.Size = new System.Drawing.Size(110, 24);
            this.panel137.TabIndex = 0;
            // 
            // Q_DI_LEI
            // 
            this.Q_DI_LEI.AssDispValue = true;
            this.Q_DI_LEI.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Q_DI_LEI.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Q_DI_LEI.ForeColor = System.Drawing.Color.Blue;
            this.Q_DI_LEI.Location = new System.Drawing.Point(2, 2);
            this.Q_DI_LEI.Name = "Q_DI_LEI";
            this.Q_DI_LEI.Size = new System.Drawing.Size(104, 22);
            this.Q_DI_LEI.TabIndex = 17;
            this.Q_DI_LEI.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // laQ_DI_LEI
            // 
            this.laQ_DI_LEI.Dock = System.Windows.Forms.DockStyle.Left;
            this.laQ_DI_LEI.Location = new System.Drawing.Point(0, 0);
            this.laQ_DI_LEI.Name = "laQ_DI_LEI";
            this.laQ_DI_LEI.Size = new System.Drawing.Size(80, 24);
            this.laQ_DI_LEI.TabIndex = 0;
            this.laQ_DI_LEI.Text = "前期地类";
            this.laQ_DI_LEI.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label152
            // 
            this.label152.BackColor = System.Drawing.Color.Black;
            this.label152.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label152.Location = new System.Drawing.Point(0, 24);
            this.label152.Name = "label152";
            this.label152.Size = new System.Drawing.Size(575, 1);
            this.label152.TabIndex = 0;
            this.label152.Text = "label152";
            this.label152.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel138
            // 
            this.panel138.Controls.Add(this.panel139);
            this.panel138.Controls.Add(this.laLMJYQ);
            this.panel138.Controls.Add(this.panel140);
            this.panel138.Controls.Add(this.laLMSYQ);
            this.panel138.Controls.Add(this.panel141);
            this.panel138.Controls.Add(this.laTDJYQ);
            this.panel138.Controls.Add(this.label156);
            this.panel138.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel138.Location = new System.Drawing.Point(0, 25);
            this.panel138.Name = "panel138";
            this.panel138.Size = new System.Drawing.Size(575, 25);
            this.panel138.TabIndex = 0;
            // 
            // panel139
            // 
            this.panel139.Controls.Add(this.LMJYQ);
            this.panel139.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel139.Location = new System.Drawing.Point(460, 0);
            this.panel139.Name = "panel139";
            this.panel139.Padding = new System.Windows.Forms.Padding(2, 4, 4, 0);
            this.panel139.Size = new System.Drawing.Size(110, 24);
            this.panel139.TabIndex = 0;
            // 
            // LMJYQ
            // 
            this.LMJYQ.AssDispValue = true;
            this.LMJYQ.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LMJYQ.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.LMJYQ.ForeColor = System.Drawing.Color.Blue;
            this.LMJYQ.Location = new System.Drawing.Point(2, 2);
            this.LMJYQ.Name = "LMJYQ";
            this.LMJYQ.Size = new System.Drawing.Size(104, 22);
            this.LMJYQ.TabIndex = 16;
            this.LMJYQ.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // laLMJYQ
            // 
            this.laLMJYQ.Dock = System.Windows.Forms.DockStyle.Left;
            this.laLMJYQ.Location = new System.Drawing.Point(380, 0);
            this.laLMJYQ.Name = "laLMJYQ";
            this.laLMJYQ.Size = new System.Drawing.Size(80, 24);
            this.laLMJYQ.TabIndex = 0;
            this.laLMJYQ.Text = "林木使用权";
            this.laLMJYQ.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel140
            // 
            this.panel140.Controls.Add(this.LMSYQ);
            this.panel140.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel140.Location = new System.Drawing.Point(270, 0);
            this.panel140.Name = "panel140";
            this.panel140.Padding = new System.Windows.Forms.Padding(2, 4, 4, 0);
            this.panel140.Size = new System.Drawing.Size(110, 24);
            this.panel140.TabIndex = 0;
            // 
            // LMSYQ
            // 
            this.LMSYQ.AssDispValue = true;
            this.LMSYQ.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LMSYQ.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.LMSYQ.ForeColor = System.Drawing.Color.Blue;
            this.LMSYQ.Location = new System.Drawing.Point(2, 2);
            this.LMSYQ.Name = "LMSYQ";
            this.LMSYQ.Size = new System.Drawing.Size(104, 22);
            this.LMSYQ.TabIndex = 15;
            this.LMSYQ.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // laLMSYQ
            // 
            this.laLMSYQ.Dock = System.Windows.Forms.DockStyle.Left;
            this.laLMSYQ.Location = new System.Drawing.Point(190, 0);
            this.laLMSYQ.Name = "laLMSYQ";
            this.laLMSYQ.Size = new System.Drawing.Size(80, 24);
            this.laLMSYQ.TabIndex = 0;
            this.laLMSYQ.Text = "林木所有权";
            this.laLMSYQ.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel141
            // 
            this.panel141.Controls.Add(this.TDJYQ);
            this.panel141.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel141.Location = new System.Drawing.Point(80, 0);
            this.panel141.Name = "panel141";
            this.panel141.Padding = new System.Windows.Forms.Padding(2, 4, 4, 0);
            this.panel141.Size = new System.Drawing.Size(110, 24);
            this.panel141.TabIndex = 0;
            // 
            // TDJYQ
            // 
            this.TDJYQ.AssDispValue = true;
            this.TDJYQ.Cursor = System.Windows.Forms.Cursors.Hand;
            this.TDJYQ.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.TDJYQ.ForeColor = System.Drawing.Color.Blue;
            this.TDJYQ.Location = new System.Drawing.Point(2, 2);
            this.TDJYQ.Name = "TDJYQ";
            this.TDJYQ.Size = new System.Drawing.Size(104, 22);
            this.TDJYQ.TabIndex = 14;
            this.TDJYQ.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // laTDJYQ
            // 
            this.laTDJYQ.Dock = System.Windows.Forms.DockStyle.Left;
            this.laTDJYQ.Location = new System.Drawing.Point(0, 0);
            this.laTDJYQ.Name = "laTDJYQ";
            this.laTDJYQ.Size = new System.Drawing.Size(80, 24);
            this.laTDJYQ.TabIndex = 0;
            this.laTDJYQ.Text = "土地使用权";
            this.laTDJYQ.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label156
            // 
            this.label156.BackColor = System.Drawing.Color.Black;
            this.label156.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label156.Location = new System.Drawing.Point(0, 24);
            this.label156.Name = "label156";
            this.label156.Size = new System.Drawing.Size(575, 1);
            this.label156.TabIndex = 0;
            this.label156.Text = "label156";
            this.label156.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel142
            // 
            this.panel142.Controls.Add(this.panel143);
            this.panel142.Controls.Add(this.laLD_QS);
            this.panel142.Controls.Add(this.panel144);
            this.panel142.Controls.Add(this.laQ_LD_QS);
            this.panel142.Controls.Add(this.panel145);
            this.panel142.Controls.Add(this.laMIAN_JI);
            this.panel142.Controls.Add(this.label160);
            this.panel142.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel142.Location = new System.Drawing.Point(0, 0);
            this.panel142.Name = "panel142";
            this.panel142.Size = new System.Drawing.Size(575, 25);
            this.panel142.TabIndex = 0;
            // 
            // panel143
            // 
            this.panel143.Controls.Add(this.LD_QS);
            this.panel143.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel143.Location = new System.Drawing.Point(460, 0);
            this.panel143.Name = "panel143";
            this.panel143.Padding = new System.Windows.Forms.Padding(2, 4, 4, 0);
            this.panel143.Size = new System.Drawing.Size(110, 24);
            this.panel143.TabIndex = 0;
            // 
            // LD_QS
            // 
            this.LD_QS.AssDispValue = true;
            this.LD_QS.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LD_QS.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.LD_QS.ForeColor = System.Drawing.Color.Blue;
            this.LD_QS.Location = new System.Drawing.Point(2, 2);
            this.LD_QS.Name = "LD_QS";
            this.LD_QS.Size = new System.Drawing.Size(104, 22);
            this.LD_QS.TabIndex = 13;
            this.LD_QS.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // laLD_QS
            // 
            this.laLD_QS.Dock = System.Windows.Forms.DockStyle.Left;
            this.laLD_QS.Location = new System.Drawing.Point(380, 0);
            this.laLD_QS.Name = "laLD_QS";
            this.laLD_QS.Size = new System.Drawing.Size(80, 24);
            this.laLD_QS.TabIndex = 0;
            this.laLD_QS.Text = "土地权属";
            this.laLD_QS.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel144
            // 
            this.panel144.Controls.Add(this.Q_LD_QS);
            this.panel144.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel144.Location = new System.Drawing.Point(270, 0);
            this.panel144.Name = "panel144";
            this.panel144.Padding = new System.Windows.Forms.Padding(2, 4, 4, 0);
            this.panel144.Size = new System.Drawing.Size(110, 24);
            this.panel144.TabIndex = 0;
            // 
            // Q_LD_QS
            // 
            this.Q_LD_QS.AssDispValue = true;
            this.Q_LD_QS.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Q_LD_QS.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Q_LD_QS.ForeColor = System.Drawing.Color.Blue;
            this.Q_LD_QS.Location = new System.Drawing.Point(2, 2);
            this.Q_LD_QS.Name = "Q_LD_QS";
            this.Q_LD_QS.Size = new System.Drawing.Size(104, 22);
            this.Q_LD_QS.TabIndex = 12;
            this.Q_LD_QS.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // laQ_LD_QS
            // 
            this.laQ_LD_QS.Dock = System.Windows.Forms.DockStyle.Left;
            this.laQ_LD_QS.Location = new System.Drawing.Point(190, 0);
            this.laQ_LD_QS.Name = "laQ_LD_QS";
            this.laQ_LD_QS.Size = new System.Drawing.Size(80, 24);
            this.laQ_LD_QS.TabIndex = 0;
            this.laQ_LD_QS.Text = "前期土地权属";
            this.laQ_LD_QS.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel145
            // 
            this.panel145.Controls.Add(this.MIAN_JI);
            this.panel145.Controls.Add(this.label141);
            this.panel145.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel145.Location = new System.Drawing.Point(80, 0);
            this.panel145.Name = "panel145";
            this.panel145.Padding = new System.Windows.Forms.Padding(2, 6, 6, 2);
            this.panel145.Size = new System.Drawing.Size(110, 24);
            this.panel145.TabIndex = 0;
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
            this.MIAN_JI.Properties.LookAndFeel.SkinName = "Blue";
            this.MIAN_JI.Properties.MaxValue = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.MIAN_JI.Size = new System.Drawing.Size(69, 18);
            this.MIAN_JI.TabIndex = 11;
            this.MIAN_JI.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // label141
            // 
            this.label141.Dock = System.Windows.Forms.DockStyle.Right;
            this.label141.ForeColor = System.Drawing.Color.Blue;
            this.label141.Location = new System.Drawing.Point(71, 6);
            this.label141.Name = "label141";
            this.label141.Size = new System.Drawing.Size(33, 16);
            this.label141.TabIndex = 0;
            this.label141.Text = "公顷";
            this.label141.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // laMIAN_JI
            // 
            this.laMIAN_JI.Dock = System.Windows.Forms.DockStyle.Left;
            this.laMIAN_JI.Location = new System.Drawing.Point(0, 0);
            this.laMIAN_JI.Name = "laMIAN_JI";
            this.laMIAN_JI.Size = new System.Drawing.Size(80, 24);
            this.laMIAN_JI.TabIndex = 0;
            this.laMIAN_JI.Text = "面积";
            this.laMIAN_JI.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label160
            // 
            this.label160.BackColor = System.Drawing.Color.Black;
            this.label160.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label160.Location = new System.Drawing.Point(0, 24);
            this.label160.Name = "label160";
            this.label160.Size = new System.Drawing.Size(575, 1);
            this.label160.TabIndex = 0;
            this.label160.Text = "label160";
            this.label160.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label161
            // 
            this.label161.BackColor = System.Drawing.Color.Black;
            this.label161.Dock = System.Windows.Forms.DockStyle.Top;
            this.label161.Location = new System.Drawing.Point(1, 0);
            this.label161.Name = "label161";
            this.label161.Size = new System.Drawing.Size(575, 1);
            this.label161.TabIndex = 0;
            this.label161.Text = "label161";
            this.label161.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label162
            // 
            this.label162.BackColor = System.Drawing.Color.Black;
            this.label162.Dock = System.Windows.Forms.DockStyle.Left;
            this.label162.Location = new System.Drawing.Point(0, 0);
            this.label162.Name = "label162";
            this.label162.Size = new System.Drawing.Size(1, 251);
            this.label162.TabIndex = 0;
            this.label162.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label163
            // 
            this.label163.BackColor = System.Drawing.Color.Black;
            this.label163.Dock = System.Windows.Forms.DockStyle.Right;
            this.label163.Location = new System.Drawing.Point(576, 0);
            this.label163.Name = "label163";
            this.label163.Size = new System.Drawing.Size(1, 251);
            this.label163.TabIndex = 0;
            this.label163.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelAttr2
            // 
            this.labelAttr2.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelAttr2.Font = new System.Drawing.Font("黑体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelAttr2.Location = new System.Drawing.Point(0, 156);
            this.labelAttr2.Name = "labelAttr2";
            this.labelAttr2.Size = new System.Drawing.Size(577, 30);
            this.labelAttr2.TabIndex = 0;
            this.labelAttr2.Text = " 林分信息";
            this.labelAttr2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelAttr2
            // 
            this.panelAttr2.Controls.Add(this.panelAttr21);
            this.panelAttr2.Controls.Add(this.label24);
            this.panelAttr2.Controls.Add(this.label25);
            this.panelAttr2.Controls.Add(this.label26);
            this.panelAttr2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelAttr2.Location = new System.Drawing.Point(0, 130);
            this.panelAttr2.Name = "panelAttr2";
            this.panelAttr2.Size = new System.Drawing.Size(577, 26);
            this.panelAttr2.TabIndex = 0;
            // 
            // panelAttr21
            // 
            this.panelAttr21.Controls.Add(this.panel23);
            this.panelAttr21.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelAttr21.Location = new System.Drawing.Point(1, 1);
            this.panelAttr21.Name = "panelAttr21";
            this.panelAttr21.Size = new System.Drawing.Size(575, 25);
            this.panelAttr21.TabIndex = 0;
            // 
            // panel23
            // 
            this.panel23.Controls.Add(this.panel28);
            this.panel23.Controls.Add(this.laBHND);
            this.panel23.Controls.Add(this.panel25);
            this.panel23.Controls.Add(this.laGXSJ);
            this.panel23.Controls.Add(this.panel26);
            this.panel23.Controls.Add(this.laBHYY);
            this.panel23.Controls.Add(this.label21);
            this.panel23.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel23.Location = new System.Drawing.Point(0, 0);
            this.panel23.Name = "panel23";
            this.panel23.Size = new System.Drawing.Size(575, 25);
            this.panel23.TabIndex = 0;
            // 
            // panel28
            // 
            this.panel28.Controls.Add(this.BHND);
            this.panel28.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel28.Location = new System.Drawing.Point(460, 0);
            this.panel28.Name = "panel28";
            this.panel28.Padding = new System.Windows.Forms.Padding(2, 6, 8, 0);
            this.panel28.Size = new System.Drawing.Size(110, 24);
            this.panel28.TabIndex = 0;
            // 
            // BHND
            // 
            this.BHND.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BHND.EditValue = "";
            this.BHND.Location = new System.Drawing.Point(2, 8);
            this.BHND.Name = "BHND";
            this.BHND.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.BHND.Properties.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BHND.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.BHND.Properties.Appearance.Options.UseBackColor = true;
            this.BHND.Properties.Appearance.Options.UseFont = true;
            this.BHND.Properties.Appearance.Options.UseForeColor = true;
            this.BHND.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.BHND.Properties.MaxLength = 4;
            this.BHND.Size = new System.Drawing.Size(100, 16);
            this.BHND.TabIndex = 41;
            this.BHND.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // laBHND
            // 
            this.laBHND.Dock = System.Windows.Forms.DockStyle.Left;
            this.laBHND.Location = new System.Drawing.Point(380, 0);
            this.laBHND.Name = "laBHND";
            this.laBHND.Size = new System.Drawing.Size(80, 24);
            this.laBHND.TabIndex = 0;
            this.laBHND.Text = "变化年度";
            this.laBHND.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel25
            // 
            this.panel25.Controls.Add(this.GXSJ);
            this.panel25.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel25.Location = new System.Drawing.Point(270, 0);
            this.panel25.Name = "panel25";
            this.panel25.Padding = new System.Windows.Forms.Padding(2, 1, 8, 3);
            this.panel25.Size = new System.Drawing.Size(110, 24);
            this.panel25.TabIndex = 0;
            // 
            // GXSJ
            // 
            this.GXSJ.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.GXSJ.EditValue = null;
            this.GXSJ.Location = new System.Drawing.Point(2, 3);
            this.GXSJ.Name = "GXSJ";
            this.GXSJ.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.GXSJ.Properties.Appearance.Options.UseForeColor = true;
            this.GXSJ.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.GXSJ.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.GXSJ.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.GXSJ.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.GXSJ.Size = new System.Drawing.Size(100, 18);
            this.GXSJ.TabIndex = 40;
            this.GXSJ.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // laGXSJ
            // 
            this.laGXSJ.Dock = System.Windows.Forms.DockStyle.Left;
            this.laGXSJ.Location = new System.Drawing.Point(190, 0);
            this.laGXSJ.Name = "laGXSJ";
            this.laGXSJ.Size = new System.Drawing.Size(80, 24);
            this.laGXSJ.TabIndex = 0;
            this.laGXSJ.Text = "更新时间";
            this.laGXSJ.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel26
            // 
            this.panel26.Controls.Add(this.BHYY);
            this.panel26.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel26.Location = new System.Drawing.Point(80, 0);
            this.panel26.Name = "panel26";
            this.panel26.Padding = new System.Windows.Forms.Padding(2, 4, 4, 0);
            this.panel26.Size = new System.Drawing.Size(110, 24);
            this.panel26.TabIndex = 0;
            // 
            // BHYY
            // 
            this.BHYY.AssDispValue = true;
            this.BHYY.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BHYY.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BHYY.ForeColor = System.Drawing.Color.Blue;
            this.BHYY.Location = new System.Drawing.Point(2, 2);
            this.BHYY.Name = "BHYY";
            this.BHYY.Size = new System.Drawing.Size(104, 22);
            this.BHYY.TabIndex = 39;
            this.BHYY.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // laBHYY
            // 
            this.laBHYY.Dock = System.Windows.Forms.DockStyle.Left;
            this.laBHYY.Location = new System.Drawing.Point(0, 0);
            this.laBHYY.Name = "laBHYY";
            this.laBHYY.Size = new System.Drawing.Size(80, 24);
            this.laBHYY.TabIndex = 0;
            this.laBHYY.Text = "变化原因";
            this.laBHYY.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label21
            // 
            this.label21.BackColor = System.Drawing.Color.Black;
            this.label21.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label21.Location = new System.Drawing.Point(0, 24);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(575, 1);
            this.label21.TabIndex = 0;
            this.label21.Text = "label21";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label24
            // 
            this.label24.BackColor = System.Drawing.Color.Black;
            this.label24.Dock = System.Windows.Forms.DockStyle.Top;
            this.label24.Location = new System.Drawing.Point(1, 0);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(575, 1);
            this.label24.TabIndex = 0;
            this.label24.Text = "label24";
            this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label25
            // 
            this.label25.BackColor = System.Drawing.Color.Black;
            this.label25.Dock = System.Windows.Forms.DockStyle.Left;
            this.label25.Location = new System.Drawing.Point(0, 0);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(1, 26);
            this.label25.TabIndex = 0;
            this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label26
            // 
            this.label26.BackColor = System.Drawing.Color.Black;
            this.label26.Dock = System.Windows.Forms.DockStyle.Right;
            this.label26.Location = new System.Drawing.Point(576, 0);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(1, 26);
            this.label26.TabIndex = 0;
            this.label26.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelAttr3
            // 
            this.labelAttr3.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelAttr3.Font = new System.Drawing.Font("黑体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelAttr3.Location = new System.Drawing.Point(0, 100);
            this.labelAttr3.Name = "labelAttr3";
            this.labelAttr3.Size = new System.Drawing.Size(577, 30);
            this.labelAttr3.TabIndex = 0;
            this.labelAttr3.Text = " 变更情况";
            this.labelAttr3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelAttr1
            // 
            this.panelAttr1.Controls.Add(this.panelAttr11);
            this.panelAttr1.Controls.Add(this.label90);
            this.panelAttr1.Controls.Add(this.label91);
            this.panelAttr1.Controls.Add(this.label92);
            this.panelAttr1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelAttr1.Location = new System.Drawing.Point(0, 24);
            this.panelAttr1.Name = "panelAttr1";
            this.panelAttr1.Size = new System.Drawing.Size(577, 76);
            this.panelAttr1.TabIndex = 0;
            // 
            // panelAttr11
            // 
            this.panelAttr11.Controls.Add(this.panel19);
            this.panelAttr11.Controls.Add(this.panel12);
            this.panelAttr11.Controls.Add(this.panel13);
            this.panelAttr11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelAttr11.Location = new System.Drawing.Point(1, 1);
            this.panelAttr11.Name = "panelAttr11";
            this.panelAttr11.Size = new System.Drawing.Size(575, 75);
            this.panelAttr11.TabIndex = 0;
            // 
            // panel19
            // 
            this.panel19.Controls.Add(this.panel166);
            this.panel19.Controls.Add(this.laXI_BAN);
            this.panel19.Controls.Add(this.panel43);
            this.panel19.Controls.Add(this.laXIAO_BAN);
            this.panel19.Controls.Add(this.panel20);
            this.panel19.Controls.Add(this.laLIN_BAN);
            this.panel19.Controls.Add(this.panel21);
            this.panel19.Controls.Add(this.laLIN_CHANG);
            this.panel19.Controls.Add(this.label23);
            this.panel19.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel19.Location = new System.Drawing.Point(0, 50);
            this.panel19.Name = "panel19";
            this.panel19.Size = new System.Drawing.Size(575, 25);
            this.panel19.TabIndex = 0;
            // 
            // panel166
            // 
            this.panel166.Controls.Add(this.XI_BAN);
            this.panel166.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel166.Location = new System.Drawing.Point(465, 0);
            this.panel166.Name = "panel166";
            this.panel166.Padding = new System.Windows.Forms.Padding(2, 6, 8, 0);
            this.panel166.Size = new System.Drawing.Size(105, 24);
            this.panel166.TabIndex = 0;
            // 
            // XI_BAN
            // 
            this.XI_BAN.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.XI_BAN.EditValue = "";
            this.XI_BAN.Location = new System.Drawing.Point(2, 8);
            this.XI_BAN.Name = "XI_BAN";
            this.XI_BAN.Properties.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.XI_BAN.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.XI_BAN.Properties.Appearance.Options.UseFont = true;
            this.XI_BAN.Properties.Appearance.Options.UseForeColor = true;
            this.XI_BAN.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.XI_BAN.Size = new System.Drawing.Size(95, 16);
            this.XI_BAN.TabIndex = 10;
            this.XI_BAN.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // laXI_BAN
            // 
            this.laXI_BAN.Dock = System.Windows.Forms.DockStyle.Left;
            this.laXI_BAN.Location = new System.Drawing.Point(425, 0);
            this.laXI_BAN.Name = "laXI_BAN";
            this.laXI_BAN.Size = new System.Drawing.Size(40, 24);
            this.laXI_BAN.TabIndex = 0;
            this.laXI_BAN.Text = "细班";
            this.laXI_BAN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel43
            // 
            this.panel43.Controls.Add(this.XIAO_BAN);
            this.panel43.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel43.Location = new System.Drawing.Point(345, 0);
            this.panel43.Name = "panel43";
            this.panel43.Padding = new System.Windows.Forms.Padding(2, 6, 8, 0);
            this.panel43.Size = new System.Drawing.Size(80, 24);
            this.panel43.TabIndex = 0;
            // 
            // XIAO_BAN
            // 
            this.XIAO_BAN.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.XIAO_BAN.EditValue = "";
            this.XIAO_BAN.Location = new System.Drawing.Point(2, 8);
            this.XIAO_BAN.Name = "XIAO_BAN";
            this.XIAO_BAN.Properties.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.XIAO_BAN.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.XIAO_BAN.Properties.Appearance.Options.UseFont = true;
            this.XIAO_BAN.Properties.Appearance.Options.UseForeColor = true;
            this.XIAO_BAN.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.XIAO_BAN.Properties.MaxLength = 4;
            this.XIAO_BAN.Size = new System.Drawing.Size(70, 16);
            this.XIAO_BAN.TabIndex = 9;
            this.XIAO_BAN.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // laXIAO_BAN
            // 
            this.laXIAO_BAN.Dock = System.Windows.Forms.DockStyle.Left;
            this.laXIAO_BAN.Location = new System.Drawing.Point(305, 0);
            this.laXIAO_BAN.Name = "laXIAO_BAN";
            this.laXIAO_BAN.Size = new System.Drawing.Size(40, 24);
            this.laXIAO_BAN.TabIndex = 0;
            this.laXIAO_BAN.Text = "小班";
            this.laXIAO_BAN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel20
            // 
            this.panel20.Controls.Add(this.LIN_BAN);
            this.panel20.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel20.Location = new System.Drawing.Point(225, 0);
            this.panel20.Name = "panel20";
            this.panel20.Padding = new System.Windows.Forms.Padding(2, 6, 8, 0);
            this.panel20.Size = new System.Drawing.Size(80, 24);
            this.panel20.TabIndex = 0;
            // 
            // LIN_BAN
            // 
            this.LIN_BAN.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.LIN_BAN.EditValue = "";
            this.LIN_BAN.Location = new System.Drawing.Point(2, 8);
            this.LIN_BAN.Name = "LIN_BAN";
            this.LIN_BAN.Properties.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LIN_BAN.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.LIN_BAN.Properties.Appearance.Options.UseFont = true;
            this.LIN_BAN.Properties.Appearance.Options.UseForeColor = true;
            this.LIN_BAN.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.LIN_BAN.Properties.MaxLength = 4;
            this.LIN_BAN.Size = new System.Drawing.Size(70, 16);
            this.LIN_BAN.TabIndex = 8;
            this.LIN_BAN.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // laLIN_BAN
            // 
            this.laLIN_BAN.Dock = System.Windows.Forms.DockStyle.Left;
            this.laLIN_BAN.Location = new System.Drawing.Point(185, 0);
            this.laLIN_BAN.Name = "laLIN_BAN";
            this.laLIN_BAN.Size = new System.Drawing.Size(40, 24);
            this.laLIN_BAN.TabIndex = 0;
            this.laLIN_BAN.Text = "林班";
            this.laLIN_BAN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel21
            // 
            this.panel21.Controls.Add(this.LIN_CHANG);
            this.panel21.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel21.Location = new System.Drawing.Point(40, 0);
            this.panel21.Name = "panel21";
            this.panel21.Padding = new System.Windows.Forms.Padding(2, 4, 4, 0);
            this.panel21.Size = new System.Drawing.Size(145, 24);
            this.panel21.TabIndex = 0;
            // 
            // LIN_CHANG
            // 
            this.LIN_CHANG.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.LIN_CHANG.EditValue = "";
            this.LIN_CHANG.Location = new System.Drawing.Point(2, 8);
            this.LIN_CHANG.Name = "LIN_CHANG";
            this.LIN_CHANG.Properties.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LIN_CHANG.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.LIN_CHANG.Properties.Appearance.Options.UseFont = true;
            this.LIN_CHANG.Properties.Appearance.Options.UseForeColor = true;
            this.LIN_CHANG.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.LIN_CHANG.Size = new System.Drawing.Size(139, 16);
            this.LIN_CHANG.TabIndex = 7;
            this.LIN_CHANG.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // laLIN_CHANG
            // 
            this.laLIN_CHANG.Dock = System.Windows.Forms.DockStyle.Left;
            this.laLIN_CHANG.Location = new System.Drawing.Point(0, 0);
            this.laLIN_CHANG.Name = "laLIN_CHANG";
            this.laLIN_CHANG.Size = new System.Drawing.Size(40, 24);
            this.laLIN_CHANG.TabIndex = 0;
            this.laLIN_CHANG.Text = "林场";
            this.laLIN_CHANG.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label23
            // 
            this.label23.BackColor = System.Drawing.Color.Black;
            this.label23.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label23.Location = new System.Drawing.Point(0, 24);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(575, 1);
            this.label23.TabIndex = 0;
            this.label23.Text = "label23";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel12
            // 
            this.panel12.Controls.Add(this.panel49);
            this.panel12.Controls.Add(this.laLIN_YE_JU);
            this.panel12.Controls.Add(this.panel16);
            this.panel12.Controls.Add(this.laCUN);
            this.panel12.Controls.Add(this.panel18);
            this.panel12.Controls.Add(this.laXIANG);
            this.panel12.Controls.Add(this.label18);
            this.panel12.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel12.Location = new System.Drawing.Point(0, 25);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(575, 25);
            this.panel12.TabIndex = 0;
            // 
            // panel49
            // 
            this.panel49.Controls.Add(this.LIN_YE_JU);
            this.panel49.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel49.Location = new System.Drawing.Point(420, 0);
            this.panel49.Name = "panel49";
            this.panel49.Padding = new System.Windows.Forms.Padding(2, 4, 4, 0);
            this.panel49.Size = new System.Drawing.Size(150, 24);
            this.panel49.TabIndex = 0;
            // 
            // LIN_YE_JU
            // 
            this.LIN_YE_JU.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.LIN_YE_JU.EditValue = "";
            this.LIN_YE_JU.Location = new System.Drawing.Point(2, 8);
            this.LIN_YE_JU.Name = "LIN_YE_JU";
            this.LIN_YE_JU.Properties.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LIN_YE_JU.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.LIN_YE_JU.Properties.Appearance.Options.UseFont = true;
            this.LIN_YE_JU.Properties.Appearance.Options.UseForeColor = true;
            this.LIN_YE_JU.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.LIN_YE_JU.Size = new System.Drawing.Size(144, 16);
            this.LIN_YE_JU.TabIndex = 6;
            this.LIN_YE_JU.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // laLIN_YE_JU
            // 
            this.laLIN_YE_JU.Dock = System.Windows.Forms.DockStyle.Left;
            this.laLIN_YE_JU.Location = new System.Drawing.Point(370, 0);
            this.laLIN_YE_JU.Name = "laLIN_YE_JU";
            this.laLIN_YE_JU.Size = new System.Drawing.Size(50, 24);
            this.laLIN_YE_JU.TabIndex = 0;
            this.laLIN_YE_JU.Text = "林业局";
            this.laLIN_YE_JU.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel16
            // 
            this.panel16.Controls.Add(this.CUN);
            this.panel16.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel16.Location = new System.Drawing.Point(225, 0);
            this.panel16.Name = "panel16";
            this.panel16.Padding = new System.Windows.Forms.Padding(2, 4, 4, 0);
            this.panel16.Size = new System.Drawing.Size(145, 24);
            this.panel16.TabIndex = 0;
            // 
            // CUN
            // 
            this.CUN.AssDispValue = true;
            this.CUN.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CUN.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.CUN.ForeColor = System.Drawing.Color.Blue;
            this.CUN.Location = new System.Drawing.Point(2, 2);
            this.CUN.Name = "CUN";
            this.CUN.Size = new System.Drawing.Size(139, 22);
            this.CUN.TabIndex = 5;
            this.CUN.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // laCUN
            // 
            this.laCUN.Dock = System.Windows.Forms.DockStyle.Left;
            this.laCUN.Location = new System.Drawing.Point(185, 0);
            this.laCUN.Name = "laCUN";
            this.laCUN.Size = new System.Drawing.Size(40, 24);
            this.laCUN.TabIndex = 0;
            this.laCUN.Text = "村";
            this.laCUN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel18
            // 
            this.panel18.Controls.Add(this.XIANG);
            this.panel18.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel18.Location = new System.Drawing.Point(40, 0);
            this.panel18.Name = "panel18";
            this.panel18.Padding = new System.Windows.Forms.Padding(2, 4, 4, 0);
            this.panel18.Size = new System.Drawing.Size(145, 24);
            this.panel18.TabIndex = 0;
            // 
            // XIANG
            // 
            this.XIANG.AssDispValue = true;
            this.XIANG.Cursor = System.Windows.Forms.Cursors.Hand;
            this.XIANG.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.XIANG.ForeColor = System.Drawing.Color.Blue;
            this.XIANG.Location = new System.Drawing.Point(2, 2);
            this.XIANG.Name = "XIANG";
            this.XIANG.Size = new System.Drawing.Size(139, 22);
            this.XIANG.TabIndex = 4;
            this.XIANG.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // laXIANG
            // 
            this.laXIANG.Dock = System.Windows.Forms.DockStyle.Left;
            this.laXIANG.Location = new System.Drawing.Point(0, 0);
            this.laXIANG.Name = "laXIANG";
            this.laXIANG.Size = new System.Drawing.Size(40, 24);
            this.laXIANG.TabIndex = 0;
            this.laXIANG.Text = "乡";
            this.laXIANG.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label18
            // 
            this.label18.BackColor = System.Drawing.Color.Black;
            this.label18.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label18.Location = new System.Drawing.Point(0, 24);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(575, 1);
            this.label18.TabIndex = 0;
            this.label18.Text = "label18";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel13
            // 
            this.panel13.Controls.Add(this.panel115);
            this.panel13.Controls.Add(this.laXIAN);
            this.panel13.Controls.Add(this.panel53);
            this.panel13.Controls.Add(this.laSHI);
            this.panel13.Controls.Add(this.panel15);
            this.panel13.Controls.Add(this.laSHENG);
            this.panel13.Controls.Add(this.label16);
            this.panel13.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel13.Location = new System.Drawing.Point(0, 0);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(575, 25);
            this.panel13.TabIndex = 0;
            // 
            // panel115
            // 
            this.panel115.Controls.Add(this.XIAN);
            this.panel115.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel115.Location = new System.Drawing.Point(420, 0);
            this.panel115.Name = "panel115";
            this.panel115.Padding = new System.Windows.Forms.Padding(2, 4, 4, 0);
            this.panel115.Size = new System.Drawing.Size(150, 24);
            this.panel115.TabIndex = 0;
            // 
            // XIAN
            // 
            this.XIAN.AssDispValue = true;
            this.XIAN.Cursor = System.Windows.Forms.Cursors.Hand;
            this.XIAN.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.XIAN.ForeColor = System.Drawing.Color.Blue;
            this.XIAN.Location = new System.Drawing.Point(2, 2);
            this.XIAN.Name = "XIAN";
            this.XIAN.Size = new System.Drawing.Size(144, 22);
            this.XIAN.TabIndex = 3;
            this.XIAN.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // laXIAN
            // 
            this.laXIAN.Dock = System.Windows.Forms.DockStyle.Left;
            this.laXIAN.Location = new System.Drawing.Point(370, 0);
            this.laXIAN.Name = "laXIAN";
            this.laXIAN.Size = new System.Drawing.Size(50, 24);
            this.laXIAN.TabIndex = 0;
            this.laXIAN.Text = "县";
            this.laXIAN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel53
            // 
            this.panel53.Controls.Add(this.SHI);
            this.panel53.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel53.Location = new System.Drawing.Point(225, 0);
            this.panel53.Name = "panel53";
            this.panel53.Padding = new System.Windows.Forms.Padding(2, 4, 4, 0);
            this.panel53.Size = new System.Drawing.Size(145, 24);
            this.panel53.TabIndex = 0;
            // 
            // SHI
            // 
            this.SHI.AssDispValue = true;
            this.SHI.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SHI.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.SHI.ForeColor = System.Drawing.Color.Blue;
            this.SHI.Location = new System.Drawing.Point(2, 2);
            this.SHI.Name = "SHI";
            this.SHI.Size = new System.Drawing.Size(139, 22);
            this.SHI.TabIndex = 2;
            this.SHI.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // laSHI
            // 
            this.laSHI.Dock = System.Windows.Forms.DockStyle.Left;
            this.laSHI.Location = new System.Drawing.Point(185, 0);
            this.laSHI.Name = "laSHI";
            this.laSHI.Size = new System.Drawing.Size(40, 24);
            this.laSHI.TabIndex = 0;
            this.laSHI.Text = "市";
            this.laSHI.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel15
            // 
            this.panel15.Controls.Add(this.SHENG);
            this.panel15.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel15.Location = new System.Drawing.Point(40, 0);
            this.panel15.Name = "panel15";
            this.panel15.Padding = new System.Windows.Forms.Padding(2, 4, 4, 0);
            this.panel15.Size = new System.Drawing.Size(145, 24);
            this.panel15.TabIndex = 0;
            // 
            // SHENG
            // 
            this.SHENG.AssDispValue = true;
            this.SHENG.BackColor = System.Drawing.Color.White;
            this.SHENG.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SHENG.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.SHENG.Enabled = false;
            this.SHENG.ForeColor = System.Drawing.Color.Blue;
            this.SHENG.Location = new System.Drawing.Point(2, 2);
            this.SHENG.Name = "SHENG";
            this.SHENG.Size = new System.Drawing.Size(139, 22);
            this.SHENG.TabIndex = 1;
            this.SHENG.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // laSHENG
            // 
            this.laSHENG.Dock = System.Windows.Forms.DockStyle.Left;
            this.laSHENG.Location = new System.Drawing.Point(0, 0);
            this.laSHENG.Name = "laSHENG";
            this.laSHENG.Size = new System.Drawing.Size(40, 24);
            this.laSHENG.TabIndex = 0;
            this.laSHENG.Text = "省";
            this.laSHENG.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label16
            // 
            this.label16.BackColor = System.Drawing.Color.Black;
            this.label16.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label16.Location = new System.Drawing.Point(0, 24);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(575, 1);
            this.label16.TabIndex = 0;
            this.label16.Text = "label16";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label90
            // 
            this.label90.BackColor = System.Drawing.Color.Black;
            this.label90.Dock = System.Windows.Forms.DockStyle.Top;
            this.label90.Location = new System.Drawing.Point(1, 0);
            this.label90.Name = "label90";
            this.label90.Size = new System.Drawing.Size(575, 1);
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
            this.label92.Location = new System.Drawing.Point(576, 0);
            this.label92.Name = "label92";
            this.label92.Size = new System.Drawing.Size(1, 76);
            this.label92.TabIndex = 0;
            this.label92.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.buttonSetChangeTool);
            this.panelTop.Controls.Add(this.panel14);
            this.panelTop.Controls.Add(this.buttonSetXBTool);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Padding = new System.Windows.Forms.Padding(0, 4, 60, 4);
            this.panelTop.Size = new System.Drawing.Size(577, 24);
            this.panelTop.TabIndex = 0;
            // 
            // buttonSetChangeTool
            // 
            this.buttonSetChangeTool.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.buttonSetChangeTool.Appearance.BorderColor = System.Drawing.Color.Transparent;
            this.buttonSetChangeTool.Appearance.Options.UseBackColor = true;
            this.buttonSetChangeTool.Appearance.Options.UseBorderColor = true;
            this.buttonSetChangeTool.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonSetChangeTool.Image = ((System.Drawing.Image)(resources.GetObject("buttonSetChangeTool.Image")));
            this.buttonSetChangeTool.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.buttonSetChangeTool.Location = new System.Drawing.Point(455, 4);
            this.buttonSetChangeTool.Name = "buttonSetChangeTool";
            this.buttonSetChangeTool.Size = new System.Drawing.Size(16, 16);
            this.buttonSetChangeTool.TabIndex = 0;
            this.buttonSetChangeTool.ToolTip = "获取变更小班属性";
            this.buttonSetChangeTool.Click += new System.EventHandler(this.buttonSetChangeTool_Click);
            // 
            // panel14
            // 
            this.panel14.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel14.Location = new System.Drawing.Point(471, 4);
            this.panel14.Name = "panel14";
            this.panel14.Size = new System.Drawing.Size(30, 16);
            this.panel14.TabIndex = 0;
            // 
            // buttonSetXBTool
            // 
            this.buttonSetXBTool.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.buttonSetXBTool.Appearance.BorderColor = System.Drawing.Color.Transparent;
            this.buttonSetXBTool.Appearance.Options.UseBackColor = true;
            this.buttonSetXBTool.Appearance.Options.UseBorderColor = true;
            this.buttonSetXBTool.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonSetXBTool.Image = ((System.Drawing.Image)(resources.GetObject("buttonSetXBTool.Image")));
            this.buttonSetXBTool.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.buttonSetXBTool.Location = new System.Drawing.Point(501, 4);
            this.buttonSetXBTool.Name = "buttonSetXBTool";
            this.buttonSetXBTool.Size = new System.Drawing.Size(16, 16);
            this.buttonSetXBTool.TabIndex = 0;
            this.buttonSetXBTool.ToolTip = "获取二类小班属性";
            this.buttonSetXBTool.Click += new System.EventHandler(this.buttonSetXBTool_Click);
            // 
            // xtraTabPage2
            // 
            this.xtraTabPage2.Controls.Add(this.panel2);
            this.xtraTabPage2.Location = new System.Drawing.Point(4, 23);
            this.xtraTabPage2.Name = "xtraTabPage2";
            this.xtraTabPage2.Size = new System.Drawing.Size(577, 596);
            this.xtraTabPage2.TabIndex = 0;
            this.xtraTabPage2.Text = "小班因子";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.panelAttr4);
            this.panel2.Controls.Add(this.labelAttr5);
            this.panel2.Controls.Add(this.panelAttr3);
            this.panel2.Controls.Add(this.labelAttr4);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(577, 596);
            this.panel2.TabIndex = 0;
            // 
            // panelAttr4
            // 
            this.panelAttr4.Controls.Add(this.panelAttr41);
            this.panelAttr4.Controls.Add(this.label95);
            this.panelAttr4.Controls.Add(this.label96);
            this.panelAttr4.Controls.Add(this.label97);
            this.panelAttr4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelAttr4.Location = new System.Drawing.Point(0, 261);
            this.panelAttr4.Name = "panelAttr4";
            this.panelAttr4.Size = new System.Drawing.Size(577, 201);
            this.panelAttr4.TabIndex = 0;
            // 
            // panelAttr41
            // 
            this.panelAttr41.Controls.Add(this.panel8);
            this.panelAttr41.Controls.Add(this.panel151);
            this.panelAttr41.Controls.Add(this.panel148);
            this.panelAttr41.Controls.Add(this.panel129);
            this.panelAttr41.Controls.Add(this.panel73);
            this.panelAttr41.Controls.Add(this.panel77);
            this.panelAttr41.Controls.Add(this.panel81);
            this.panelAttr41.Controls.Add(this.panel85);
            this.panelAttr41.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelAttr41.Location = new System.Drawing.Point(1, 1);
            this.panelAttr41.Name = "panelAttr41";
            this.panelAttr41.Size = new System.Drawing.Size(575, 200);
            this.panelAttr41.TabIndex = 0;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.panel22);
            this.panel8.Controls.Add(this.label8);
            this.panel8.Controls.Add(this.panel11);
            this.panel8.Controls.Add(this.label4);
            this.panel8.Controls.Add(this.panel17);
            this.panel8.Controls.Add(this.label6);
            this.panel8.Controls.Add(this.label7);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel8.Location = new System.Drawing.Point(0, 175);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(575, 25);
            this.panel8.TabIndex = 0;
            // 
            // panel22
            // 
            this.panel22.Controls.Add(this.JKZK);
            this.panel22.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel22.Location = new System.Drawing.Point(460, 0);
            this.panel22.Name = "panel22";
            this.panel22.Padding = new System.Windows.Forms.Padding(2, 4, 4, 0);
            this.panel22.Size = new System.Drawing.Size(110, 24);
            this.panel22.TabIndex = 0;
            // 
            // JKZK
            // 
            this.JKZK.AssDispValue = true;
            this.JKZK.Cursor = System.Windows.Forms.Cursors.Hand;
            this.JKZK.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.JKZK.ForeColor = System.Drawing.Color.Blue;
            this.JKZK.Location = new System.Drawing.Point(2, 2);
            this.JKZK.Name = "JKZK";
            this.JKZK.Size = new System.Drawing.Size(104, 22);
            this.JKZK.TabIndex = 83;
            this.JKZK.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // label8
            // 
            this.label8.Dock = System.Windows.Forms.DockStyle.Left;
            this.label8.Location = new System.Drawing.Point(380, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 24);
            this.label8.TabIndex = 0;
            this.label8.Text = "健康状况";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel11
            // 
            this.panel11.Controls.Add(this.ZRD);
            this.panel11.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel11.Location = new System.Drawing.Point(270, 0);
            this.panel11.Name = "panel11";
            this.panel11.Padding = new System.Windows.Forms.Padding(2, 4, 4, 0);
            this.panel11.Size = new System.Drawing.Size(110, 24);
            this.panel11.TabIndex = 0;
            // 
            // ZRD
            // 
            this.ZRD.AssDispValue = true;
            this.ZRD.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ZRD.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ZRD.ForeColor = System.Drawing.Color.Blue;
            this.ZRD.Location = new System.Drawing.Point(2, 2);
            this.ZRD.Name = "ZRD";
            this.ZRD.Size = new System.Drawing.Size(104, 22);
            this.ZRD.TabIndex = 82;
            this.ZRD.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Left;
            this.label4.Location = new System.Drawing.Point(190, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 24);
            this.label4.TabIndex = 0;
            this.label4.Text = "自然度";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel17
            // 
            this.panel17.Controls.Add(this.QLJG);
            this.panel17.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel17.Location = new System.Drawing.Point(80, 0);
            this.panel17.Name = "panel17";
            this.panel17.Padding = new System.Windows.Forms.Padding(2, 4, 4, 0);
            this.panel17.Size = new System.Drawing.Size(110, 24);
            this.panel17.TabIndex = 0;
            // 
            // QLJG
            // 
            this.QLJG.AssDispValue = true;
            this.QLJG.Cursor = System.Windows.Forms.Cursors.Hand;
            this.QLJG.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.QLJG.ForeColor = System.Drawing.Color.Blue;
            this.QLJG.Location = new System.Drawing.Point(2, 2);
            this.QLJG.Name = "QLJG";
            this.QLJG.Size = new System.Drawing.Size(104, 22);
            this.QLJG.TabIndex = 81;
            this.QLJG.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // label6
            // 
            this.label6.Dock = System.Windows.Forms.DockStyle.Left;
            this.label6.Location = new System.Drawing.Point(0, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 24);
            this.label6.TabIndex = 0;
            this.label6.Text = "群落结构";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.Black;
            this.label7.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label7.Location = new System.Drawing.Point(0, 24);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(575, 1);
            this.label7.TabIndex = 0;
            this.label7.Text = "label7";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel151
            // 
            this.panel151.Controls.Add(this.panel10);
            this.panel151.Controls.Add(this.label198);
            this.panel151.Controls.Add(this.panel152);
            this.panel151.Controls.Add(this.label200);
            this.panel151.Controls.Add(this.panel153);
            this.panel151.Controls.Add(this.label201);
            this.panel151.Controls.Add(this.label202);
            this.panel151.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel151.Location = new System.Drawing.Point(0, 150);
            this.panel151.Name = "panel151";
            this.panel151.Size = new System.Drawing.Size(575, 25);
            this.panel151.TabIndex = 0;
            // 
            // panel10
            // 
            this.panel10.Controls.Add(this.SDLX);
            this.panel10.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel10.Location = new System.Drawing.Point(460, 0);
            this.panel10.Name = "panel10";
            this.panel10.Padding = new System.Windows.Forms.Padding(2, 4, 4, 0);
            this.panel10.Size = new System.Drawing.Size(110, 24);
            this.panel10.TabIndex = 0;
            // 
            // SDLX
            // 
            this.SDLX.AssDispValue = true;
            this.SDLX.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SDLX.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.SDLX.ForeColor = System.Drawing.Color.Blue;
            this.SDLX.Location = new System.Drawing.Point(2, 2);
            this.SDLX.Name = "SDLX";
            this.SDLX.Size = new System.Drawing.Size(104, 22);
            this.SDLX.TabIndex = 80;
            this.SDLX.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // label198
            // 
            this.label198.Dock = System.Windows.Forms.DockStyle.Left;
            this.label198.Location = new System.Drawing.Point(380, 0);
            this.label198.Name = "label198";
            this.label198.Size = new System.Drawing.Size(80, 24);
            this.label198.TabIndex = 0;
            this.label198.Text = "湿地类型";
            this.label198.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel152
            // 
            this.panel152.Controls.Add(this.SHCD);
            this.panel152.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel152.Location = new System.Drawing.Point(270, 0);
            this.panel152.Name = "panel152";
            this.panel152.Padding = new System.Windows.Forms.Padding(2, 4, 4, 0);
            this.panel152.Size = new System.Drawing.Size(110, 24);
            this.panel152.TabIndex = 0;
            // 
            // SHCD
            // 
            this.SHCD.AssDispValue = true;
            this.SHCD.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SHCD.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.SHCD.ForeColor = System.Drawing.Color.Blue;
            this.SHCD.Location = new System.Drawing.Point(2, 2);
            this.SHCD.Name = "SHCD";
            this.SHCD.Size = new System.Drawing.Size(104, 22);
            this.SHCD.TabIndex = 79;
            this.SHCD.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // label200
            // 
            this.label200.Dock = System.Windows.Forms.DockStyle.Left;
            this.label200.Location = new System.Drawing.Point(190, 0);
            this.label200.Name = "label200";
            this.label200.Size = new System.Drawing.Size(80, 24);
            this.label200.TabIndex = 0;
            this.label200.Text = "沙化程度";
            this.label200.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel153
            // 
            this.panel153.Controls.Add(this.SHLX);
            this.panel153.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel153.Location = new System.Drawing.Point(80, 0);
            this.panel153.Name = "panel153";
            this.panel153.Padding = new System.Windows.Forms.Padding(2, 4, 4, 0);
            this.panel153.Size = new System.Drawing.Size(110, 24);
            this.panel153.TabIndex = 0;
            // 
            // SHLX
            // 
            this.SHLX.AssDispValue = true;
            this.SHLX.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SHLX.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.SHLX.ForeColor = System.Drawing.Color.Blue;
            this.SHLX.Location = new System.Drawing.Point(2, 2);
            this.SHLX.Name = "SHLX";
            this.SHLX.Size = new System.Drawing.Size(104, 22);
            this.SHLX.TabIndex = 78;
            this.SHLX.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // label201
            // 
            this.label201.Dock = System.Windows.Forms.DockStyle.Left;
            this.label201.Location = new System.Drawing.Point(0, 0);
            this.label201.Name = "label201";
            this.label201.Size = new System.Drawing.Size(80, 24);
            this.label201.TabIndex = 0;
            this.label201.Text = "沙化类型";
            this.label201.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label202
            // 
            this.label202.BackColor = System.Drawing.Color.Black;
            this.label202.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label202.Location = new System.Drawing.Point(0, 24);
            this.label202.Name = "label202";
            this.label202.Size = new System.Drawing.Size(575, 1);
            this.label202.TabIndex = 0;
            this.label202.Text = "label202";
            this.label202.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel148
            // 
            this.panel148.Controls.Add(this.panel9);
            this.panel148.Controls.Add(this.label193);
            this.panel148.Controls.Add(this.panel149);
            this.panel148.Controls.Add(this.label195);
            this.panel148.Controls.Add(this.panel150);
            this.panel148.Controls.Add(this.label196);
            this.panel148.Controls.Add(this.label197);
            this.panel148.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel148.Location = new System.Drawing.Point(0, 125);
            this.panel148.Name = "panel148";
            this.panel148.Size = new System.Drawing.Size(575, 25);
            this.panel148.TabIndex = 0;
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.SMHCY);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel9.Location = new System.Drawing.Point(460, 0);
            this.panel9.Name = "panel9";
            this.panel9.Padding = new System.Windows.Forms.Padding(2, 4, 4, 0);
            this.panel9.Size = new System.Drawing.Size(110, 24);
            this.panel9.TabIndex = 0;
            // 
            // SMHCY
            // 
            this.SMHCY.AssDispValue = true;
            this.SMHCY.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SMHCY.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.SMHCY.ForeColor = System.Drawing.Color.Blue;
            this.SMHCY.Location = new System.Drawing.Point(2, 2);
            this.SMHCY.Name = "SMHCY";
            this.SMHCY.Size = new System.Drawing.Size(104, 22);
            this.SMHCY.TabIndex = 77;
            this.SMHCY.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // label193
            // 
            this.label193.Dock = System.Windows.Forms.DockStyle.Left;
            this.label193.Location = new System.Drawing.Point(380, 0);
            this.label193.Name = "label193";
            this.label193.Size = new System.Drawing.Size(80, 24);
            this.label193.TabIndex = 0;
            this.label193.Text = "石漠化成因";
            this.label193.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel149
            // 
            this.panel149.Controls.Add(this.SMHCD);
            this.panel149.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel149.Location = new System.Drawing.Point(270, 0);
            this.panel149.Name = "panel149";
            this.panel149.Padding = new System.Windows.Forms.Padding(2, 4, 4, 0);
            this.panel149.Size = new System.Drawing.Size(110, 24);
            this.panel149.TabIndex = 0;
            // 
            // SMHCD
            // 
            this.SMHCD.AssDispValue = true;
            this.SMHCD.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SMHCD.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.SMHCD.ForeColor = System.Drawing.Color.Blue;
            this.SMHCD.Location = new System.Drawing.Point(2, 2);
            this.SMHCD.Name = "SMHCD";
            this.SMHCD.Size = new System.Drawing.Size(104, 22);
            this.SMHCD.TabIndex = 76;
            this.SMHCD.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // label195
            // 
            this.label195.Dock = System.Windows.Forms.DockStyle.Left;
            this.label195.Location = new System.Drawing.Point(190, 0);
            this.label195.Name = "label195";
            this.label195.Size = new System.Drawing.Size(80, 24);
            this.label195.TabIndex = 0;
            this.label195.Text = "石漠化程度";
            this.label195.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel150
            // 
            this.panel150.Controls.Add(this.SMHLX);
            this.panel150.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel150.Location = new System.Drawing.Point(80, 0);
            this.panel150.Name = "panel150";
            this.panel150.Padding = new System.Windows.Forms.Padding(2, 4, 4, 0);
            this.panel150.Size = new System.Drawing.Size(110, 24);
            this.panel150.TabIndex = 0;
            // 
            // SMHLX
            // 
            this.SMHLX.AssDispValue = true;
            this.SMHLX.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SMHLX.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.SMHLX.ForeColor = System.Drawing.Color.Blue;
            this.SMHLX.Location = new System.Drawing.Point(2, 2);
            this.SMHLX.Name = "SMHLX";
            this.SMHLX.Size = new System.Drawing.Size(104, 22);
            this.SMHLX.TabIndex = 75;
            this.SMHLX.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // label196
            // 
            this.label196.Dock = System.Windows.Forms.DockStyle.Left;
            this.label196.Location = new System.Drawing.Point(0, 0);
            this.label196.Name = "label196";
            this.label196.Size = new System.Drawing.Size(80, 24);
            this.label196.TabIndex = 0;
            this.label196.Text = "石漠化类型";
            this.label196.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label197
            // 
            this.label197.BackColor = System.Drawing.Color.Black;
            this.label197.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label197.Location = new System.Drawing.Point(0, 24);
            this.label197.Name = "label197";
            this.label197.Size = new System.Drawing.Size(575, 1);
            this.label197.TabIndex = 0;
            this.label197.Text = "label197";
            this.label197.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel129
            // 
            this.panel129.Controls.Add(this.panel29);
            this.panel129.Controls.Add(this.label53);
            this.panel129.Controls.Add(this.panel146);
            this.panel129.Controls.Add(this.label190);
            this.panel129.Controls.Add(this.panel147);
            this.panel129.Controls.Add(this.label191);
            this.panel129.Controls.Add(this.label192);
            this.panel129.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel129.Location = new System.Drawing.Point(0, 100);
            this.panel129.Name = "panel129";
            this.panel129.Size = new System.Drawing.Size(575, 25);
            this.panel129.TabIndex = 0;
            // 
            // panel29
            // 
            this.panel29.Controls.Add(this.CTMY);
            this.panel29.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel29.Location = new System.Drawing.Point(460, 0);
            this.panel29.Name = "panel29";
            this.panel29.Padding = new System.Windows.Forms.Padding(2, 4, 4, 0);
            this.panel29.Size = new System.Drawing.Size(110, 24);
            this.panel29.TabIndex = 0;
            // 
            // CTMY
            // 
            this.CTMY.AssDispValue = true;
            this.CTMY.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CTMY.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.CTMY.ForeColor = System.Drawing.Color.Blue;
            this.CTMY.Location = new System.Drawing.Point(2, 2);
            this.CTMY.Name = "CTMY";
            this.CTMY.Size = new System.Drawing.Size(104, 22);
            this.CTMY.TabIndex = 74;
            this.CTMY.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // label53
            // 
            this.label53.Dock = System.Windows.Forms.DockStyle.Left;
            this.label53.Location = new System.Drawing.Point(380, 0);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(80, 24);
            this.label53.TabIndex = 0;
            this.label53.Text = "成土母岩";
            this.label53.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel146
            // 
            this.panel146.Controls.Add(this.QSCD);
            this.panel146.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel146.Location = new System.Drawing.Point(270, 0);
            this.panel146.Name = "panel146";
            this.panel146.Padding = new System.Windows.Forms.Padding(2, 4, 4, 0);
            this.panel146.Size = new System.Drawing.Size(110, 24);
            this.panel146.TabIndex = 0;
            // 
            // QSCD
            // 
            this.QSCD.AssDispValue = true;
            this.QSCD.Cursor = System.Windows.Forms.Cursors.Hand;
            this.QSCD.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.QSCD.ForeColor = System.Drawing.Color.Blue;
            this.QSCD.Location = new System.Drawing.Point(2, 2);
            this.QSCD.Name = "QSCD";
            this.QSCD.Size = new System.Drawing.Size(104, 22);
            this.QSCD.TabIndex = 73;
            this.QSCD.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // label190
            // 
            this.label190.Dock = System.Windows.Forms.DockStyle.Left;
            this.label190.Location = new System.Drawing.Point(190, 0);
            this.label190.Name = "label190";
            this.label190.Size = new System.Drawing.Size(80, 24);
            this.label190.TabIndex = 0;
            this.label190.Text = "侵蚀程度";
            this.label190.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel147
            // 
            this.panel147.Controls.Add(this.QSLX);
            this.panel147.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel147.Location = new System.Drawing.Point(80, 0);
            this.panel147.Name = "panel147";
            this.panel147.Padding = new System.Windows.Forms.Padding(2, 4, 4, 0);
            this.panel147.Size = new System.Drawing.Size(110, 24);
            this.panel147.TabIndex = 0;
            // 
            // QSLX
            // 
            this.QSLX.AssDispValue = true;
            this.QSLX.Cursor = System.Windows.Forms.Cursors.Hand;
            this.QSLX.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.QSLX.ForeColor = System.Drawing.Color.Blue;
            this.QSLX.Location = new System.Drawing.Point(2, 2);
            this.QSLX.Name = "QSLX";
            this.QSLX.Size = new System.Drawing.Size(104, 22);
            this.QSLX.TabIndex = 72;
            this.QSLX.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // label191
            // 
            this.label191.Dock = System.Windows.Forms.DockStyle.Left;
            this.label191.Location = new System.Drawing.Point(0, 0);
            this.label191.Name = "label191";
            this.label191.Size = new System.Drawing.Size(80, 24);
            this.label191.TabIndex = 0;
            this.label191.Text = "侵蚀类型";
            this.label191.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label192
            // 
            this.label192.BackColor = System.Drawing.Color.Black;
            this.label192.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label192.Location = new System.Drawing.Point(0, 24);
            this.label192.Name = "label192";
            this.label192.Size = new System.Drawing.Size(575, 1);
            this.label192.TabIndex = 0;
            this.label192.Text = "label192";
            this.label192.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel73
            // 
            this.panel73.Controls.Add(this.panel7);
            this.panel73.Controls.Add(this.label187);
            this.panel73.Controls.Add(this.panel76);
            this.panel73.Controls.Add(this.label78);
            this.panel73.Controls.Add(this.label79);
            this.panel73.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel73.Location = new System.Drawing.Point(0, 75);
            this.panel73.Name = "panel73";
            this.panel73.Size = new System.Drawing.Size(575, 25);
            this.panel73.TabIndex = 0;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.FZCH);
            this.panel7.Controls.Add(this.label3);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel7.Location = new System.Drawing.Point(282, 0);
            this.panel7.Name = "panel7";
            this.panel7.Padding = new System.Windows.Forms.Padding(2, 6, 6, 2);
            this.panel7.Size = new System.Drawing.Size(110, 24);
            this.panel7.TabIndex = 0;
            // 
            // FZCH
            // 
            this.FZCH.Cursor = System.Windows.Forms.Cursors.Hand;
            this.FZCH.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.FZCH.EditScale = 0;
            this.FZCH.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.FZCH.Location = new System.Drawing.Point(2, 4);
            this.FZCH.Name = "FZCH";
            this.FZCH.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.FZCH.Properties.Appearance.Options.UseForeColor = true;
            this.FZCH.Properties.Appearance.Options.UseTextOptions = true;
            this.FZCH.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.FZCH.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.FZCH.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.FZCH.Properties.LookAndFeel.SkinName = "Blue";
            this.FZCH.Properties.MaxValue = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.FZCH.Size = new System.Drawing.Size(77, 18);
            this.FZCH.TabIndex = 71;
            this.FZCH.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Right;
            this.label3.ForeColor = System.Drawing.Color.Blue;
            this.label3.Location = new System.Drawing.Point(79, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(25, 16);
            this.label3.TabIndex = 0;
            this.label3.Text = "cm";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label187
            // 
            this.label187.Dock = System.Windows.Forms.DockStyle.Left;
            this.label187.Location = new System.Drawing.Point(190, 0);
            this.label187.Name = "label187";
            this.label187.Size = new System.Drawing.Size(92, 24);
            this.label187.TabIndex = 0;
            this.label187.Text = "腐殖质层厚度";
            this.label187.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel76
            // 
            this.panel76.Controls.Add(this.SLHL);
            this.panel76.Controls.Add(this.label133);
            this.panel76.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel76.Location = new System.Drawing.Point(80, 0);
            this.panel76.Name = "panel76";
            this.panel76.Padding = new System.Windows.Forms.Padding(2, 6, 6, 2);
            this.panel76.Size = new System.Drawing.Size(110, 24);
            this.panel76.TabIndex = 0;
            // 
            // SLHL
            // 
            this.SLHL.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SLHL.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.SLHL.EditScale = 0;
            this.SLHL.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.SLHL.Location = new System.Drawing.Point(2, 4);
            this.SLHL.Name = "SLHL";
            this.SLHL.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.SLHL.Properties.Appearance.Options.UseForeColor = true;
            this.SLHL.Properties.Appearance.Options.UseTextOptions = true;
            this.SLHL.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.SLHL.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.SLHL.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.SLHL.Properties.LookAndFeel.SkinName = "Blue";
            this.SLHL.Properties.MaxValue = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.SLHL.Size = new System.Drawing.Size(83, 18);
            this.SLHL.TabIndex = 70;
            this.SLHL.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // label133
            // 
            this.label133.Dock = System.Windows.Forms.DockStyle.Right;
            this.label133.ForeColor = System.Drawing.Color.Blue;
            this.label133.Location = new System.Drawing.Point(85, 6);
            this.label133.Name = "label133";
            this.label133.Size = new System.Drawing.Size(19, 16);
            this.label133.TabIndex = 0;
            this.label133.Text = "%";
            this.label133.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label78
            // 
            this.label78.Dock = System.Windows.Forms.DockStyle.Left;
            this.label78.Location = new System.Drawing.Point(0, 0);
            this.label78.Name = "label78";
            this.label78.Size = new System.Drawing.Size(80, 24);
            this.label78.TabIndex = 0;
            this.label78.Text = "石砾含量";
            this.label78.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label79
            // 
            this.label79.BackColor = System.Drawing.Color.Black;
            this.label79.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label79.Location = new System.Drawing.Point(0, 24);
            this.label79.Name = "label79";
            this.label79.Size = new System.Drawing.Size(575, 1);
            this.label79.TabIndex = 0;
            this.label79.Text = "label79";
            this.label79.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel77
            // 
            this.panel77.Controls.Add(this.panel79);
            this.panel77.Controls.Add(this.label81);
            this.panel77.Controls.Add(this.panel80);
            this.panel77.Controls.Add(this.label82);
            this.panel77.Controls.Add(this.label83);
            this.panel77.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel77.Location = new System.Drawing.Point(0, 50);
            this.panel77.Name = "panel77";
            this.panel77.Size = new System.Drawing.Size(575, 25);
            this.panel77.TabIndex = 0;
            // 
            // panel79
            // 
            this.panel79.Controls.Add(this.KZLYH);
            this.panel79.Controls.Add(this.label137);
            this.panel79.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel79.Location = new System.Drawing.Point(282, 0);
            this.panel79.Name = "panel79";
            this.panel79.Padding = new System.Windows.Forms.Padding(2, 6, 6, 2);
            this.panel79.Size = new System.Drawing.Size(110, 24);
            this.panel79.TabIndex = 0;
            // 
            // KZLYH
            // 
            this.KZLYH.Cursor = System.Windows.Forms.Cursors.Hand;
            this.KZLYH.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.KZLYH.EditScale = 0;
            this.KZLYH.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.KZLYH.Location = new System.Drawing.Point(2, 4);
            this.KZLYH.Name = "KZLYH";
            this.KZLYH.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.KZLYH.Properties.Appearance.Options.UseForeColor = true;
            this.KZLYH.Properties.Appearance.Options.UseTextOptions = true;
            this.KZLYH.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.KZLYH.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.KZLYH.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.KZLYH.Properties.LookAndFeel.SkinName = "Blue";
            this.KZLYH.Properties.MaxValue = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.KZLYH.Size = new System.Drawing.Size(77, 18);
            this.KZLYH.TabIndex = 69;
            this.KZLYH.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // label137
            // 
            this.label137.Dock = System.Windows.Forms.DockStyle.Right;
            this.label137.ForeColor = System.Drawing.Color.Blue;
            this.label137.Location = new System.Drawing.Point(79, 6);
            this.label137.Name = "label137";
            this.label137.Size = new System.Drawing.Size(25, 16);
            this.label137.TabIndex = 0;
            this.label137.Text = "cm";
            this.label137.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label81
            // 
            this.label81.Dock = System.Windows.Forms.DockStyle.Left;
            this.label81.Location = new System.Drawing.Point(190, 0);
            this.label81.Name = "label81";
            this.label81.Size = new System.Drawing.Size(92, 24);
            this.label81.TabIndex = 0;
            this.label81.Text = "枯枝阔叶层厚度";
            this.label81.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel80
            // 
            this.panel80.Controls.Add(this.TU_CENG_HD);
            this.panel80.Controls.Add(this.label2);
            this.panel80.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel80.Location = new System.Drawing.Point(80, 0);
            this.panel80.Name = "panel80";
            this.panel80.Padding = new System.Windows.Forms.Padding(2, 6, 6, 2);
            this.panel80.Size = new System.Drawing.Size(110, 24);
            this.panel80.TabIndex = 0;
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
            this.TU_CENG_HD.Properties.LookAndFeel.SkinName = "Blue";
            this.TU_CENG_HD.Properties.MaxValue = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.TU_CENG_HD.Size = new System.Drawing.Size(77, 18);
            this.TU_CENG_HD.TabIndex = 68;
            this.TU_CENG_HD.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Right;
            this.label2.ForeColor = System.Drawing.Color.Blue;
            this.label2.Location = new System.Drawing.Point(79, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "cm";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label82
            // 
            this.label82.Dock = System.Windows.Forms.DockStyle.Left;
            this.label82.Location = new System.Drawing.Point(0, 0);
            this.label82.Name = "label82";
            this.label82.Size = new System.Drawing.Size(80, 24);
            this.label82.TabIndex = 0;
            this.label82.Text = "土层厚度";
            this.label82.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label83
            // 
            this.label83.BackColor = System.Drawing.Color.Black;
            this.label83.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label83.Location = new System.Drawing.Point(0, 24);
            this.label83.Name = "label83";
            this.label83.Size = new System.Drawing.Size(575, 1);
            this.label83.TabIndex = 0;
            this.label83.Text = "label83";
            this.label83.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel81
            // 
            this.panel81.Controls.Add(this.panel82);
            this.panel81.Controls.Add(this.label84);
            this.panel81.Controls.Add(this.panel83);
            this.panel81.Controls.Add(this.label85);
            this.panel81.Controls.Add(this.panel84);
            this.panel81.Controls.Add(this.label86);
            this.panel81.Controls.Add(this.label87);
            this.panel81.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel81.Location = new System.Drawing.Point(0, 25);
            this.panel81.Name = "panel81";
            this.panel81.Size = new System.Drawing.Size(575, 25);
            this.panel81.TabIndex = 0;
            // 
            // panel82
            // 
            this.panel82.Controls.Add(this.TU_RANG_LX);
            this.panel82.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel82.Location = new System.Drawing.Point(460, 0);
            this.panel82.Name = "panel82";
            this.panel82.Padding = new System.Windows.Forms.Padding(2, 4, 4, 0);
            this.panel82.Size = new System.Drawing.Size(110, 24);
            this.panel82.TabIndex = 0;
            // 
            // TU_RANG_LX
            // 
            this.TU_RANG_LX.AssDispValue = true;
            this.TU_RANG_LX.Cursor = System.Windows.Forms.Cursors.Hand;
            this.TU_RANG_LX.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.TU_RANG_LX.ForeColor = System.Drawing.Color.Blue;
            this.TU_RANG_LX.Location = new System.Drawing.Point(2, 2);
            this.TU_RANG_LX.Name = "TU_RANG_LX";
            this.TU_RANG_LX.Size = new System.Drawing.Size(104, 22);
            this.TU_RANG_LX.TabIndex = 67;
            this.TU_RANG_LX.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // label84
            // 
            this.label84.Dock = System.Windows.Forms.DockStyle.Left;
            this.label84.Location = new System.Drawing.Point(380, 0);
            this.label84.Name = "label84";
            this.label84.Size = new System.Drawing.Size(80, 24);
            this.label84.TabIndex = 0;
            this.label84.Text = "土壤类型";
            this.label84.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel83
            // 
            this.panel83.Controls.Add(this.PO_DU);
            this.panel83.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel83.Location = new System.Drawing.Point(270, 0);
            this.panel83.Name = "panel83";
            this.panel83.Padding = new System.Windows.Forms.Padding(2, 4, 4, 0);
            this.panel83.Size = new System.Drawing.Size(110, 24);
            this.panel83.TabIndex = 0;
            // 
            // PO_DU
            // 
            this.PO_DU.AssDispValue = true;
            this.PO_DU.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PO_DU.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PO_DU.ForeColor = System.Drawing.Color.Blue;
            this.PO_DU.Location = new System.Drawing.Point(2, 2);
            this.PO_DU.Name = "PO_DU";
            this.PO_DU.Size = new System.Drawing.Size(104, 22);
            this.PO_DU.TabIndex = 66;
            this.PO_DU.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // label85
            // 
            this.label85.Dock = System.Windows.Forms.DockStyle.Left;
            this.label85.Location = new System.Drawing.Point(190, 0);
            this.label85.Name = "label85";
            this.label85.Size = new System.Drawing.Size(80, 24);
            this.label85.TabIndex = 0;
            this.label85.Text = "坡度";
            this.label85.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel84
            // 
            this.panel84.Controls.Add(this.PO_WEI);
            this.panel84.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel84.Location = new System.Drawing.Point(80, 0);
            this.panel84.Name = "panel84";
            this.panel84.Padding = new System.Windows.Forms.Padding(2, 4, 4, 0);
            this.panel84.Size = new System.Drawing.Size(110, 24);
            this.panel84.TabIndex = 0;
            // 
            // PO_WEI
            // 
            this.PO_WEI.AssDispValue = true;
            this.PO_WEI.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PO_WEI.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PO_WEI.ForeColor = System.Drawing.Color.Blue;
            this.PO_WEI.Location = new System.Drawing.Point(2, 2);
            this.PO_WEI.Name = "PO_WEI";
            this.PO_WEI.Size = new System.Drawing.Size(104, 22);
            this.PO_WEI.TabIndex = 65;
            this.PO_WEI.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // label86
            // 
            this.label86.Dock = System.Windows.Forms.DockStyle.Left;
            this.label86.Location = new System.Drawing.Point(0, 0);
            this.label86.Name = "label86";
            this.label86.Size = new System.Drawing.Size(80, 24);
            this.label86.TabIndex = 0;
            this.label86.Text = "坡位";
            this.label86.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label87
            // 
            this.label87.BackColor = System.Drawing.Color.Black;
            this.label87.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label87.Location = new System.Drawing.Point(0, 24);
            this.label87.Name = "label87";
            this.label87.Size = new System.Drawing.Size(575, 1);
            this.label87.TabIndex = 0;
            this.label87.Text = "label87";
            this.label87.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel85
            // 
            this.panel85.Controls.Add(this.panel86);
            this.panel85.Controls.Add(this.label88);
            this.panel85.Controls.Add(this.panel87);
            this.panel85.Controls.Add(this.label89);
            this.panel85.Controls.Add(this.panel88);
            this.panel85.Controls.Add(this.label93);
            this.panel85.Controls.Add(this.label94);
            this.panel85.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel85.Location = new System.Drawing.Point(0, 0);
            this.panel85.Name = "panel85";
            this.panel85.Size = new System.Drawing.Size(575, 25);
            this.panel85.TabIndex = 0;
            // 
            // panel86
            // 
            this.panel86.Controls.Add(this.PO_XIANG);
            this.panel86.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel86.Location = new System.Drawing.Point(460, 0);
            this.panel86.Name = "panel86";
            this.panel86.Padding = new System.Windows.Forms.Padding(2, 4, 4, 0);
            this.panel86.Size = new System.Drawing.Size(110, 24);
            this.panel86.TabIndex = 0;
            // 
            // PO_XIANG
            // 
            this.PO_XIANG.AssDispValue = true;
            this.PO_XIANG.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PO_XIANG.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PO_XIANG.ForeColor = System.Drawing.Color.Blue;
            this.PO_XIANG.Location = new System.Drawing.Point(2, 2);
            this.PO_XIANG.Name = "PO_XIANG";
            this.PO_XIANG.Size = new System.Drawing.Size(104, 22);
            this.PO_XIANG.TabIndex = 64;
            this.PO_XIANG.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // label88
            // 
            this.label88.Dock = System.Windows.Forms.DockStyle.Left;
            this.label88.Location = new System.Drawing.Point(380, 0);
            this.label88.Name = "label88";
            this.label88.Size = new System.Drawing.Size(80, 24);
            this.label88.TabIndex = 0;
            this.label88.Text = "坡向";
            this.label88.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel87
            // 
            this.panel87.Controls.Add(this.HBG);
            this.panel87.Controls.Add(this.label115);
            this.panel87.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel87.Location = new System.Drawing.Point(270, 0);
            this.panel87.Name = "panel87";
            this.panel87.Padding = new System.Windows.Forms.Padding(2, 6, 6, 2);
            this.panel87.Size = new System.Drawing.Size(110, 24);
            this.panel87.TabIndex = 0;
            // 
            // HBG
            // 
            this.HBG.Cursor = System.Windows.Forms.Cursors.Hand;
            this.HBG.Dock = System.Windows.Forms.DockStyle.Left;
            this.HBG.EditScale = 0;
            this.HBG.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.HBG.Location = new System.Drawing.Point(2, 6);
            this.HBG.Name = "HBG";
            this.HBG.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.HBG.Properties.Appearance.Options.UseForeColor = true;
            this.HBG.Properties.Appearance.Options.UseTextOptions = true;
            this.HBG.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.HBG.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.HBG.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.HBG.Properties.LookAndFeel.SkinName = "Blue";
            this.HBG.Size = new System.Drawing.Size(75, 18);
            this.HBG.TabIndex = 63;
            this.HBG.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // label115
            // 
            this.label115.Dock = System.Windows.Forms.DockStyle.Right;
            this.label115.ForeColor = System.Drawing.Color.Blue;
            this.label115.Location = new System.Drawing.Point(85, 6);
            this.label115.Name = "label115";
            this.label115.Size = new System.Drawing.Size(19, 16);
            this.label115.TabIndex = 0;
            this.label115.Text = "m";
            this.label115.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label89
            // 
            this.label89.Dock = System.Windows.Forms.DockStyle.Left;
            this.label89.Location = new System.Drawing.Point(190, 0);
            this.label89.Name = "label89";
            this.label89.Size = new System.Drawing.Size(80, 24);
            this.label89.TabIndex = 0;
            this.label89.Text = "海拔";
            this.label89.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel88
            // 
            this.panel88.Controls.Add(this.DI_MAO);
            this.panel88.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel88.Location = new System.Drawing.Point(80, 0);
            this.panel88.Name = "panel88";
            this.panel88.Padding = new System.Windows.Forms.Padding(2, 4, 4, 0);
            this.panel88.Size = new System.Drawing.Size(110, 24);
            this.panel88.TabIndex = 0;
            // 
            // DI_MAO
            // 
            this.DI_MAO.AssDispValue = true;
            this.DI_MAO.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DI_MAO.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.DI_MAO.ForeColor = System.Drawing.Color.Blue;
            this.DI_MAO.Location = new System.Drawing.Point(2, 2);
            this.DI_MAO.Name = "DI_MAO";
            this.DI_MAO.Size = new System.Drawing.Size(104, 22);
            this.DI_MAO.TabIndex = 62;
            this.DI_MAO.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // label93
            // 
            this.label93.Dock = System.Windows.Forms.DockStyle.Left;
            this.label93.Location = new System.Drawing.Point(0, 0);
            this.label93.Name = "label93";
            this.label93.Size = new System.Drawing.Size(80, 24);
            this.label93.TabIndex = 0;
            this.label93.Text = "地貌";
            this.label93.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label94
            // 
            this.label94.BackColor = System.Drawing.Color.Black;
            this.label94.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label94.Location = new System.Drawing.Point(0, 24);
            this.label94.Name = "label94";
            this.label94.Size = new System.Drawing.Size(575, 1);
            this.label94.TabIndex = 0;
            this.label94.Text = "label94";
            this.label94.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label95
            // 
            this.label95.BackColor = System.Drawing.Color.Black;
            this.label95.Dock = System.Windows.Forms.DockStyle.Top;
            this.label95.Location = new System.Drawing.Point(1, 0);
            this.label95.Name = "label95";
            this.label95.Size = new System.Drawing.Size(575, 1);
            this.label95.TabIndex = 0;
            this.label95.Text = "label95";
            this.label95.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label96
            // 
            this.label96.BackColor = System.Drawing.Color.Black;
            this.label96.Dock = System.Windows.Forms.DockStyle.Left;
            this.label96.Location = new System.Drawing.Point(0, 0);
            this.label96.Name = "label96";
            this.label96.Size = new System.Drawing.Size(1, 201);
            this.label96.TabIndex = 0;
            this.label96.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label97
            // 
            this.label97.BackColor = System.Drawing.Color.Black;
            this.label97.Dock = System.Windows.Forms.DockStyle.Right;
            this.label97.Location = new System.Drawing.Point(576, 0);
            this.label97.Name = "label97";
            this.label97.Size = new System.Drawing.Size(1, 201);
            this.label97.TabIndex = 0;
            this.label97.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelAttr5
            // 
            this.labelAttr5.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelAttr5.Font = new System.Drawing.Font("黑体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelAttr5.Location = new System.Drawing.Point(0, 231);
            this.labelAttr5.Name = "labelAttr5";
            this.labelAttr5.Size = new System.Drawing.Size(577, 30);
            this.labelAttr5.TabIndex = 0;
            this.labelAttr5.Text = " 立地因子";
            this.labelAttr5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelAttr3
            // 
            this.panelAttr3.Controls.Add(this.panelAttr31);
            this.panelAttr3.Controls.Add(this.label49);
            this.panelAttr3.Controls.Add(this.label50);
            this.panelAttr3.Controls.Add(this.label51);
            this.panelAttr3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelAttr3.Location = new System.Drawing.Point(0, 30);
            this.panelAttr3.Name = "panelAttr3";
            this.panelAttr3.Size = new System.Drawing.Size(577, 201);
            this.panelAttr3.TabIndex = 0;
            // 
            // panelAttr31
            // 
            this.panelAttr31.Controls.Add(this.panel34);
            this.panelAttr31.Controls.Add(this.panel125);
            this.panelAttr31.Controls.Add(this.panel35);
            this.panelAttr31.Controls.Add(this.panel39);
            this.panelAttr31.Controls.Add(this.panel41);
            this.panelAttr31.Controls.Add(this.panel57);
            this.panelAttr31.Controls.Add(this.panel51);
            this.panelAttr31.Controls.Add(this.panel45);
            this.panelAttr31.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelAttr31.Location = new System.Drawing.Point(1, 1);
            this.panelAttr31.Name = "panelAttr31";
            this.panelAttr31.Size = new System.Drawing.Size(575, 200);
            this.panelAttr31.TabIndex = 0;
            // 
            // panel34
            // 
            this.panel34.Controls.Add(this.panel180);
            this.panel34.Controls.Add(this.label1);
            this.panel34.Controls.Add(this.panel172);
            this.panel34.Controls.Add(this.label59);
            this.panel34.Controls.Add(this.panel52);
            this.panel34.Controls.Add(this.label61);
            this.panel34.Controls.Add(this.label63);
            this.panel34.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel34.Location = new System.Drawing.Point(0, 175);
            this.panel34.Name = "panel34";
            this.panel34.Size = new System.Drawing.Size(575, 25);
            this.panel34.TabIndex = 0;
            // 
            // panel180
            // 
            this.panel180.Controls.Add(this.KJD);
            this.panel180.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel180.Location = new System.Drawing.Point(460, 0);
            this.panel180.Name = "panel180";
            this.panel180.Padding = new System.Windows.Forms.Padding(2, 4, 4, 0);
            this.panel180.Size = new System.Drawing.Size(110, 24);
            this.panel180.TabIndex = 0;
            // 
            // KJD
            // 
            this.KJD.AssDispValue = true;
            this.KJD.Cursor = System.Windows.Forms.Cursors.Hand;
            this.KJD.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.KJD.ForeColor = System.Drawing.Color.Blue;
            this.KJD.Location = new System.Drawing.Point(2, 2);
            this.KJD.Name = "KJD";
            this.KJD.Size = new System.Drawing.Size(104, 22);
            this.KJD.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Location = new System.Drawing.Point(380, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "采运可及度";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel172
            // 
            this.panel172.Controls.Add(this.ZFNL);
            this.panel172.Controls.Add(this.label194);
            this.panel172.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel172.Location = new System.Drawing.Point(270, 0);
            this.panel172.Name = "panel172";
            this.panel172.Padding = new System.Windows.Forms.Padding(2, 6, 6, 2);
            this.panel172.Size = new System.Drawing.Size(110, 24);
            this.panel172.TabIndex = 0;
            // 
            // ZFNL
            // 
            this.ZFNL.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ZFNL.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ZFNL.EditScale = 0;
            this.ZFNL.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ZFNL.Location = new System.Drawing.Point(2, 4);
            this.ZFNL.Name = "ZFNL";
            this.ZFNL.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.ZFNL.Properties.Appearance.Options.UseForeColor = true;
            this.ZFNL.Properties.Appearance.Options.UseTextOptions = true;
            this.ZFNL.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.ZFNL.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.ZFNL.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.ZFNL.Properties.LookAndFeel.SkinName = "Blue";
            this.ZFNL.Properties.MaxValue = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.ZFNL.Size = new System.Drawing.Size(83, 18);
            this.ZFNL.TabIndex = 61;
            this.ZFNL.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // label194
            // 
            this.label194.Dock = System.Windows.Forms.DockStyle.Right;
            this.label194.ForeColor = System.Drawing.Color.Blue;
            this.label194.Location = new System.Drawing.Point(85, 6);
            this.label194.Name = "label194";
            this.label194.Size = new System.Drawing.Size(19, 16);
            this.label194.TabIndex = 0;
            this.label194.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label59
            // 
            this.label59.Dock = System.Windows.Forms.DockStyle.Left;
            this.label59.Location = new System.Drawing.Point(190, 0);
            this.label59.Name = "label59";
            this.label59.Size = new System.Drawing.Size(80, 24);
            this.label59.TabIndex = 0;
            this.label59.Text = "主伐年龄";
            this.label59.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel52
            // 
            this.panel52.Controls.Add(this.ZLND);
            this.panel52.Controls.Add(this.label14);
            this.panel52.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel52.Location = new System.Drawing.Point(80, 0);
            this.panel52.Name = "panel52";
            this.panel52.Padding = new System.Windows.Forms.Padding(2, 6, 6, 2);
            this.panel52.Size = new System.Drawing.Size(110, 24);
            this.panel52.TabIndex = 0;
            // 
            // ZLND
            // 
            this.ZLND.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ZLND.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ZLND.EditScale = 0;
            this.ZLND.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ZLND.Location = new System.Drawing.Point(2, 4);
            this.ZLND.Name = "ZLND";
            this.ZLND.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.ZLND.Properties.Appearance.Options.UseForeColor = true;
            this.ZLND.Properties.Appearance.Options.UseTextOptions = true;
            this.ZLND.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.ZLND.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.ZLND.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.ZLND.Properties.LookAndFeel.SkinName = "Blue";
            this.ZLND.Properties.MaxValue = new decimal(new int[] {
            2213,
            0,
            0,
            0});
            this.ZLND.Size = new System.Drawing.Size(83, 18);
            this.ZLND.TabIndex = 60;
            this.ZLND.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // label14
            // 
            this.label14.Dock = System.Windows.Forms.DockStyle.Right;
            this.label14.ForeColor = System.Drawing.Color.Blue;
            this.label14.Location = new System.Drawing.Point(85, 6);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(19, 16);
            this.label14.TabIndex = 0;
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label61
            // 
            this.label61.Dock = System.Windows.Forms.DockStyle.Left;
            this.label61.Location = new System.Drawing.Point(0, 0);
            this.label61.Name = "label61";
            this.label61.Size = new System.Drawing.Size(80, 24);
            this.label61.TabIndex = 0;
            this.label61.Text = "造林年度";
            this.label61.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label63
            // 
            this.label63.BackColor = System.Drawing.Color.Black;
            this.label63.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label63.Location = new System.Drawing.Point(0, 24);
            this.label63.Name = "label63";
            this.label63.Size = new System.Drawing.Size(575, 1);
            this.label63.TabIndex = 0;
            this.label63.Text = "label63";
            this.label63.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel125
            // 
            this.panel125.Controls.Add(this.panel126);
            this.panel125.Controls.Add(this.label181);
            this.panel125.Controls.Add(this.panel127);
            this.panel125.Controls.Add(this.label182);
            this.panel125.Controls.Add(this.panel128);
            this.panel125.Controls.Add(this.label183);
            this.panel125.Controls.Add(this.label184);
            this.panel125.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel125.Location = new System.Drawing.Point(0, 150);
            this.panel125.Name = "panel125";
            this.panel125.Size = new System.Drawing.Size(575, 25);
            this.panel125.TabIndex = 0;
            // 
            // panel126
            // 
            this.panel126.Controls.Add(this.KE_JI_DU);
            this.panel126.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel126.Location = new System.Drawing.Point(460, 0);
            this.panel126.Name = "panel126";
            this.panel126.Padding = new System.Windows.Forms.Padding(2, 4, 4, 0);
            this.panel126.Size = new System.Drawing.Size(110, 24);
            this.panel126.TabIndex = 0;
            // 
            // KE_JI_DU
            // 
            this.KE_JI_DU.AssDispValue = true;
            this.KE_JI_DU.Cursor = System.Windows.Forms.Cursors.Hand;
            this.KE_JI_DU.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.KE_JI_DU.ForeColor = System.Drawing.Color.Blue;
            this.KE_JI_DU.Location = new System.Drawing.Point(2, 2);
            this.KE_JI_DU.Name = "KE_JI_DU";
            this.KE_JI_DU.Size = new System.Drawing.Size(104, 22);
            this.KE_JI_DU.TabIndex = 59;
            this.KE_JI_DU.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // label181
            // 
            this.label181.Dock = System.Windows.Forms.DockStyle.Left;
            this.label181.Location = new System.Drawing.Point(380, 0);
            this.label181.Name = "label181";
            this.label181.Size = new System.Drawing.Size(80, 24);
            this.label181.TabIndex = 0;
            this.label181.Text = "交通区位";
            this.label181.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel127
            // 
            this.panel127.Controls.Add(this.LD_CD);
            this.panel127.Controls.Add(this.label189);
            this.panel127.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel127.Location = new System.Drawing.Point(270, 0);
            this.panel127.Name = "panel127";
            this.panel127.Padding = new System.Windows.Forms.Padding(2, 6, 6, 2);
            this.panel127.Size = new System.Drawing.Size(110, 24);
            this.panel127.TabIndex = 0;
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
            this.LD_CD.Properties.LookAndFeel.SkinName = "Blue";
            this.LD_CD.Properties.MaxValue = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.LD_CD.Size = new System.Drawing.Size(83, 18);
            this.LD_CD.TabIndex = 58;
            this.LD_CD.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // label189
            // 
            this.label189.Dock = System.Windows.Forms.DockStyle.Right;
            this.label189.ForeColor = System.Drawing.Color.Blue;
            this.label189.Location = new System.Drawing.Point(85, 6);
            this.label189.Name = "label189";
            this.label189.Size = new System.Drawing.Size(19, 16);
            this.label189.TabIndex = 0;
            this.label189.Text = "m";
            this.label189.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label182
            // 
            this.label182.Dock = System.Windows.Forms.DockStyle.Left;
            this.label182.Location = new System.Drawing.Point(190, 0);
            this.label182.Name = "label182";
            this.label182.Size = new System.Drawing.Size(80, 24);
            this.label182.TabIndex = 0;
            this.label182.Text = "林带长度";
            this.label182.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel128
            // 
            this.panel128.Controls.Add(this.LD_KD);
            this.panel128.Controls.Add(this.label188);
            this.panel128.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel128.Location = new System.Drawing.Point(80, 0);
            this.panel128.Name = "panel128";
            this.panel128.Padding = new System.Windows.Forms.Padding(2, 6, 6, 2);
            this.panel128.Size = new System.Drawing.Size(110, 24);
            this.panel128.TabIndex = 0;
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
            this.LD_KD.Location = new System.Drawing.Point(2, 4);
            this.LD_KD.Name = "LD_KD";
            this.LD_KD.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.LD_KD.Properties.Appearance.Options.UseForeColor = true;
            this.LD_KD.Properties.Appearance.Options.UseTextOptions = true;
            this.LD_KD.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.LD_KD.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.LD_KD.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.LD_KD.Properties.LookAndFeel.SkinName = "Blue";
            this.LD_KD.Properties.MaxValue = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.LD_KD.Size = new System.Drawing.Size(83, 18);
            this.LD_KD.TabIndex = 57;
            this.LD_KD.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // label188
            // 
            this.label188.Dock = System.Windows.Forms.DockStyle.Right;
            this.label188.ForeColor = System.Drawing.Color.Blue;
            this.label188.Location = new System.Drawing.Point(85, 6);
            this.label188.Name = "label188";
            this.label188.Size = new System.Drawing.Size(19, 16);
            this.label188.TabIndex = 0;
            this.label188.Text = "m";
            this.label188.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label183
            // 
            this.label183.Dock = System.Windows.Forms.DockStyle.Left;
            this.label183.Location = new System.Drawing.Point(0, 0);
            this.label183.Name = "label183";
            this.label183.Size = new System.Drawing.Size(80, 24);
            this.label183.TabIndex = 0;
            this.label183.Text = "林带宽度";
            this.label183.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label184
            // 
            this.label184.BackColor = System.Drawing.Color.Black;
            this.label184.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label184.Location = new System.Drawing.Point(0, 24);
            this.label184.Name = "label184";
            this.label184.Size = new System.Drawing.Size(575, 1);
            this.label184.TabIndex = 0;
            this.label184.Text = "label184";
            this.label184.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel35
            // 
            this.panel35.Controls.Add(this.panel36);
            this.panel35.Controls.Add(this.label35);
            this.panel35.Controls.Add(this.panel37);
            this.panel35.Controls.Add(this.label36);
            this.panel35.Controls.Add(this.panel188);
            this.panel35.Controls.Add(this.label15);
            this.panel35.Controls.Add(this.label40);
            this.panel35.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel35.Location = new System.Drawing.Point(0, 125);
            this.panel35.Name = "panel35";
            this.panel35.Size = new System.Drawing.Size(575, 25);
            this.panel35.TabIndex = 0;
            // 
            // panel36
            // 
            this.panel36.Controls.Add(this.DISASTER_C);
            this.panel36.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel36.Location = new System.Drawing.Point(460, 0);
            this.panel36.Name = "panel36";
            this.panel36.Padding = new System.Windows.Forms.Padding(2, 4, 4, 0);
            this.panel36.Size = new System.Drawing.Size(110, 24);
            this.panel36.TabIndex = 0;
            // 
            // DISASTER_C
            // 
            this.DISASTER_C.AssDispValue = true;
            this.DISASTER_C.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DISASTER_C.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.DISASTER_C.ForeColor = System.Drawing.Color.Blue;
            this.DISASTER_C.Location = new System.Drawing.Point(2, 2);
            this.DISASTER_C.Name = "DISASTER_C";
            this.DISASTER_C.Size = new System.Drawing.Size(104, 22);
            this.DISASTER_C.TabIndex = 56;
            this.DISASTER_C.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // label35
            // 
            this.label35.Dock = System.Windows.Forms.DockStyle.Left;
            this.label35.Location = new System.Drawing.Point(380, 0);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(80, 24);
            this.label35.TabIndex = 0;
            this.label35.Text = "灾害等级";
            this.label35.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel37
            // 
            this.panel37.Controls.Add(this.DISPE);
            this.panel37.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel37.Location = new System.Drawing.Point(270, 0);
            this.panel37.Name = "panel37";
            this.panel37.Padding = new System.Windows.Forms.Padding(2, 4, 4, 0);
            this.panel37.Size = new System.Drawing.Size(110, 24);
            this.panel37.TabIndex = 0;
            // 
            // DISPE
            // 
            this.DISPE.AssDispValue = true;
            this.DISPE.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DISPE.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.DISPE.ForeColor = System.Drawing.Color.Blue;
            this.DISPE.Location = new System.Drawing.Point(2, 2);
            this.DISPE.Name = "DISPE";
            this.DISPE.Size = new System.Drawing.Size(104, 22);
            this.DISPE.TabIndex = 55;
            this.DISPE.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // label36
            // 
            this.label36.Dock = System.Windows.Forms.DockStyle.Left;
            this.label36.Location = new System.Drawing.Point(190, 0);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(80, 24);
            this.label36.TabIndex = 0;
            this.label36.Text = "灾害类型";
            this.label36.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel188
            // 
            this.panel188.Controls.Add(this.QYKZ);
            this.panel188.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel188.Location = new System.Drawing.Point(80, 0);
            this.panel188.Name = "panel188";
            this.panel188.Padding = new System.Windows.Forms.Padding(2, 4, 4, 0);
            this.panel188.Size = new System.Drawing.Size(110, 24);
            this.panel188.TabIndex = 0;
            // 
            // QYKZ
            // 
            this.QYKZ.AssDispValue = true;
            this.QYKZ.Cursor = System.Windows.Forms.Cursors.Hand;
            this.QYKZ.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.QYKZ.ForeColor = System.Drawing.Color.Blue;
            this.QYKZ.Location = new System.Drawing.Point(2, 2);
            this.QYKZ.Name = "QYKZ";
            this.QYKZ.Size = new System.Drawing.Size(104, 22);
            this.QYKZ.TabIndex = 54;
            // 
            // label15
            // 
            this.label15.Dock = System.Windows.Forms.DockStyle.Left;
            this.label15.Location = new System.Drawing.Point(0, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(80, 24);
            this.label15.TabIndex = 0;
            this.label15.Text = "主体功能区";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label40
            // 
            this.label40.BackColor = System.Drawing.Color.Black;
            this.label40.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label40.Location = new System.Drawing.Point(0, 24);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(575, 1);
            this.label40.TabIndex = 0;
            this.label40.Text = "label40";
            this.label40.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel39
            // 
            this.panel39.Controls.Add(this.panel40);
            this.panel39.Controls.Add(this.label41);
            this.panel39.Controls.Add(this.panel38);
            this.panel39.Controls.Add(this.label37);
            this.panel39.Controls.Add(this.panel42);
            this.panel39.Controls.Add(this.label42);
            this.panel39.Controls.Add(this.label44);
            this.panel39.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel39.Location = new System.Drawing.Point(0, 100);
            this.panel39.Name = "panel39";
            this.panel39.Size = new System.Drawing.Size(575, 25);
            this.panel39.TabIndex = 0;
            // 
            // panel40
            // 
            this.panel40.Controls.Add(this.LYFQ);
            this.panel40.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel40.Location = new System.Drawing.Point(460, 0);
            this.panel40.Name = "panel40";
            this.panel40.Padding = new System.Windows.Forms.Padding(2, 4, 4, 0);
            this.panel40.Size = new System.Drawing.Size(110, 24);
            this.panel40.TabIndex = 0;
            // 
            // LYFQ
            // 
            this.LYFQ.AssDispValue = true;
            this.LYFQ.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LYFQ.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.LYFQ.ForeColor = System.Drawing.Color.Blue;
            this.LYFQ.Location = new System.Drawing.Point(2, 2);
            this.LYFQ.Name = "LYFQ";
            this.LYFQ.Size = new System.Drawing.Size(104, 22);
            this.LYFQ.TabIndex = 53;
            this.LYFQ.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // label41
            // 
            this.label41.Dock = System.Windows.Forms.DockStyle.Left;
            this.label41.Location = new System.Drawing.Point(380, 0);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(80, 24);
            this.label41.TabIndex = 0;
            this.label41.Text = "林地功能分区";
            this.label41.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel38
            // 
            this.panel38.Controls.Add(this.Q_BH_DJ);
            this.panel38.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel38.Location = new System.Drawing.Point(293, 0);
            this.panel38.Name = "panel38";
            this.panel38.Padding = new System.Windows.Forms.Padding(2, 4, 4, 0);
            this.panel38.Size = new System.Drawing.Size(87, 24);
            this.panel38.TabIndex = 0;
            // 
            // Q_BH_DJ
            // 
            this.Q_BH_DJ.AssDispValue = true;
            this.Q_BH_DJ.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Q_BH_DJ.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Q_BH_DJ.ForeColor = System.Drawing.Color.Blue;
            this.Q_BH_DJ.Location = new System.Drawing.Point(2, 2);
            this.Q_BH_DJ.Name = "Q_BH_DJ";
            this.Q_BH_DJ.Size = new System.Drawing.Size(81, 22);
            this.Q_BH_DJ.TabIndex = 52;
            // 
            // label37
            // 
            this.label37.Dock = System.Windows.Forms.DockStyle.Left;
            this.label37.Location = new System.Drawing.Point(190, 0);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(103, 24);
            this.label37.TabIndex = 0;
            this.label37.Text = "前期林地保护等级";
            this.label37.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel42
            // 
            this.panel42.Controls.Add(this.BH_DJ);
            this.panel42.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel42.Location = new System.Drawing.Point(80, 0);
            this.panel42.Name = "panel42";
            this.panel42.Padding = new System.Windows.Forms.Padding(2, 4, 4, 0);
            this.panel42.Size = new System.Drawing.Size(110, 24);
            this.panel42.TabIndex = 0;
            // 
            // BH_DJ
            // 
            this.BH_DJ.AssDispValue = true;
            this.BH_DJ.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BH_DJ.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BH_DJ.ForeColor = System.Drawing.Color.Blue;
            this.BH_DJ.Location = new System.Drawing.Point(2, 2);
            this.BH_DJ.Name = "BH_DJ";
            this.BH_DJ.Size = new System.Drawing.Size(104, 22);
            this.BH_DJ.TabIndex = 52;
            this.BH_DJ.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // label42
            // 
            this.label42.Dock = System.Windows.Forms.DockStyle.Left;
            this.label42.Location = new System.Drawing.Point(0, 0);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(80, 24);
            this.label42.TabIndex = 0;
            this.label42.Text = "林地保护等级";
            this.label42.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label44
            // 
            this.label44.BackColor = System.Drawing.Color.Black;
            this.label44.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label44.Location = new System.Drawing.Point(0, 24);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(575, 1);
            this.label44.TabIndex = 0;
            this.label44.Text = "label44";
            this.label44.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel41
            // 
            this.panel41.Controls.Add(this.panel6);
            this.panel41.Controls.Add(this.label186);
            this.panel41.Controls.Add(this.panel44);
            this.panel41.Controls.Add(this.label43);
            this.panel41.Controls.Add(this.panel46);
            this.panel41.Controls.Add(this.label54);
            this.panel41.Controls.Add(this.label60);
            this.panel41.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel41.Location = new System.Drawing.Point(0, 75);
            this.panel41.Name = "panel41";
            this.panel41.Size = new System.Drawing.Size(575, 25);
            this.panel41.TabIndex = 0;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.BCLD);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel6.Location = new System.Drawing.Point(474, 0);
            this.panel6.Name = "panel6";
            this.panel6.Padding = new System.Windows.Forms.Padding(2, 4, 4, 0);
            this.panel6.Size = new System.Drawing.Size(96, 24);
            this.panel6.TabIndex = 0;
            // 
            // BCLD
            // 
            this.BCLD.AssDispValue = true;
            this.BCLD.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BCLD.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BCLD.ForeColor = System.Drawing.Color.Blue;
            this.BCLD.Location = new System.Drawing.Point(2, 2);
            this.BCLD.Name = "BCLD";
            this.BCLD.Size = new System.Drawing.Size(90, 22);
            this.BCLD.TabIndex = 51;
            this.BCLD.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // label186
            // 
            this.label186.Dock = System.Windows.Forms.DockStyle.Left;
            this.label186.Location = new System.Drawing.Point(380, 0);
            this.label186.Name = "label186";
            this.label186.Size = new System.Drawing.Size(94, 24);
            this.label186.TabIndex = 0;
            this.label186.Text = "是否为补充林地";
            this.label186.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel44
            // 
            this.panel44.Controls.Add(this.ZL_DJ);
            this.panel44.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel44.Location = new System.Drawing.Point(270, 0);
            this.panel44.Name = "panel44";
            this.panel44.Padding = new System.Windows.Forms.Padding(2, 4, 4, 0);
            this.panel44.Size = new System.Drawing.Size(110, 24);
            this.panel44.TabIndex = 0;
            // 
            // ZL_DJ
            // 
            this.ZL_DJ.AssDispValue = true;
            this.ZL_DJ.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ZL_DJ.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ZL_DJ.ForeColor = System.Drawing.Color.Blue;
            this.ZL_DJ.Location = new System.Drawing.Point(2, 2);
            this.ZL_DJ.Name = "ZL_DJ";
            this.ZL_DJ.Size = new System.Drawing.Size(104, 22);
            this.ZL_DJ.TabIndex = 50;
            this.ZL_DJ.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // label43
            // 
            this.label43.Dock = System.Windows.Forms.DockStyle.Left;
            this.label43.Location = new System.Drawing.Point(190, 0);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(80, 24);
            this.label43.TabIndex = 0;
            this.label43.Text = "林地质量等级";
            this.label43.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel46
            // 
            this.panel46.Controls.Add(this.TD_TH_LX);
            this.panel46.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel46.Location = new System.Drawing.Point(80, 0);
            this.panel46.Name = "panel46";
            this.panel46.Padding = new System.Windows.Forms.Padding(2, 4, 4, 0);
            this.panel46.Size = new System.Drawing.Size(110, 24);
            this.panel46.TabIndex = 0;
            // 
            // TD_TH_LX
            // 
            this.TD_TH_LX.AssDispValue = true;
            this.TD_TH_LX.Cursor = System.Windows.Forms.Cursors.Hand;
            this.TD_TH_LX.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.TD_TH_LX.ForeColor = System.Drawing.Color.Blue;
            this.TD_TH_LX.Location = new System.Drawing.Point(2, 2);
            this.TD_TH_LX.Name = "TD_TH_LX";
            this.TD_TH_LX.Size = new System.Drawing.Size(104, 22);
            this.TD_TH_LX.TabIndex = 49;
            this.TD_TH_LX.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // label54
            // 
            this.label54.Dock = System.Windows.Forms.DockStyle.Left;
            this.label54.Location = new System.Drawing.Point(0, 0);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(80, 24);
            this.label54.TabIndex = 0;
            this.label54.Text = "土地退化类型";
            this.label54.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label60
            // 
            this.label60.BackColor = System.Drawing.Color.Black;
            this.label60.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label60.Location = new System.Drawing.Point(0, 24);
            this.label60.Name = "label60";
            this.label60.Size = new System.Drawing.Size(575, 1);
            this.label60.TabIndex = 0;
            this.label60.Text = "label60";
            this.label60.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel57
            // 
            this.panel57.Controls.Add(this.panel5);
            this.panel57.Controls.Add(this.label185);
            this.panel57.Controls.Add(this.panel60);
            this.panel57.Controls.Add(this.label231);
            this.panel57.Controls.Add(this.label232);
            this.panel57.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel57.Location = new System.Drawing.Point(0, 50);
            this.panel57.Name = "panel57";
            this.panel57.Size = new System.Drawing.Size(575, 25);
            this.panel57.TabIndex = 0;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.GJGYL_BHDJ);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel5.Location = new System.Drawing.Point(320, 0);
            this.panel5.Name = "panel5";
            this.panel5.Padding = new System.Windows.Forms.Padding(2, 4, 4, 0);
            this.panel5.Size = new System.Drawing.Size(110, 24);
            this.panel5.TabIndex = 0;
            // 
            // GJGYL_BHDJ
            // 
            this.GJGYL_BHDJ.AssDispValue = true;
            this.GJGYL_BHDJ.Cursor = System.Windows.Forms.Cursors.Hand;
            this.GJGYL_BHDJ.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.GJGYL_BHDJ.ForeColor = System.Drawing.Color.Blue;
            this.GJGYL_BHDJ.Location = new System.Drawing.Point(2, 2);
            this.GJGYL_BHDJ.Name = "GJGYL_BHDJ";
            this.GJGYL_BHDJ.Size = new System.Drawing.Size(104, 22);
            this.GJGYL_BHDJ.TabIndex = 48;
            this.GJGYL_BHDJ.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // label185
            // 
            this.label185.Dock = System.Windows.Forms.DockStyle.Left;
            this.label185.Location = new System.Drawing.Point(190, 0);
            this.label185.Name = "label185";
            this.label185.Size = new System.Drawing.Size(130, 24);
            this.label185.TabIndex = 0;
            this.label185.Text = "国家级公益林保护等级";
            this.label185.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel60
            // 
            this.panel60.Controls.Add(this.STQW);
            this.panel60.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel60.Location = new System.Drawing.Point(80, 0);
            this.panel60.Name = "panel60";
            this.panel60.Padding = new System.Windows.Forms.Padding(2, 4, 4, 0);
            this.panel60.Size = new System.Drawing.Size(110, 24);
            this.panel60.TabIndex = 0;
            // 
            // STQW
            // 
            this.STQW.AssDispValue = true;
            this.STQW.Cursor = System.Windows.Forms.Cursors.Hand;
            this.STQW.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.STQW.ForeColor = System.Drawing.Color.Blue;
            this.STQW.Location = new System.Drawing.Point(2, 2);
            this.STQW.Name = "STQW";
            this.STQW.Size = new System.Drawing.Size(104, 22);
            this.STQW.TabIndex = 47;
            this.STQW.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // label231
            // 
            this.label231.Dock = System.Windows.Forms.DockStyle.Left;
            this.label231.Location = new System.Drawing.Point(0, 0);
            this.label231.Name = "label231";
            this.label231.Size = new System.Drawing.Size(80, 24);
            this.label231.TabIndex = 0;
            this.label231.Text = "生态区位";
            this.label231.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label232
            // 
            this.label232.BackColor = System.Drawing.Color.Black;
            this.label232.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label232.Location = new System.Drawing.Point(0, 24);
            this.label232.Name = "label232";
            this.label232.Size = new System.Drawing.Size(575, 1);
            this.label232.TabIndex = 0;
            this.label232.Text = "label232";
            this.label232.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel51
            // 
            this.panel51.Controls.Add(this.panel181);
            this.panel51.Controls.Add(this.label11);
            this.panel51.Controls.Add(this.panel54);
            this.panel51.Controls.Add(this.label205);
            this.panel51.Controls.Add(this.panel55);
            this.panel51.Controls.Add(this.label225);
            this.panel51.Controls.Add(this.label226);
            this.panel51.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel51.Location = new System.Drawing.Point(0, 25);
            this.panel51.Name = "panel51";
            this.panel51.Size = new System.Drawing.Size(575, 25);
            this.panel51.TabIndex = 0;
            // 
            // panel181
            // 
            this.panel181.Controls.Add(this.GBHJZSL);
            this.panel181.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel181.Location = new System.Drawing.Point(474, 0);
            this.panel181.Name = "panel181";
            this.panel181.Padding = new System.Windows.Forms.Padding(2, 4, 4, 0);
            this.panel181.Size = new System.Drawing.Size(96, 24);
            this.panel181.TabIndex = 0;
            // 
            // GBHJZSL
            // 
            this.GBHJZSL.AssDispValue = true;
            this.GBHJZSL.Cursor = System.Windows.Forms.Cursors.Hand;
            this.GBHJZSL.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.GBHJZSL.ForeColor = System.Drawing.Color.Blue;
            this.GBHJZSL.Location = new System.Drawing.Point(2, 2);
            this.GBHJZSL.Name = "GBHJZSL";
            this.GBHJZSL.Size = new System.Drawing.Size(90, 22);
            this.GBHJZSL.TabIndex = 0;
            // 
            // label11
            // 
            this.label11.Dock = System.Windows.Forms.DockStyle.Left;
            this.label11.Location = new System.Drawing.Point(380, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(94, 24);
            this.label11.TabIndex = 0;
            this.label11.Text = "高保护价值森林";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel54
            // 
            this.panel54.Controls.Add(this.G_CHENG_LB);
            this.panel54.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel54.Location = new System.Drawing.Point(270, 0);
            this.panel54.Name = "panel54";
            this.panel54.Padding = new System.Windows.Forms.Padding(2, 4, 4, 0);
            this.panel54.Size = new System.Drawing.Size(110, 24);
            this.panel54.TabIndex = 0;
            // 
            // G_CHENG_LB
            // 
            this.G_CHENG_LB.AssDispValue = true;
            this.G_CHENG_LB.Cursor = System.Windows.Forms.Cursors.Hand;
            this.G_CHENG_LB.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.G_CHENG_LB.ForeColor = System.Drawing.Color.Blue;
            this.G_CHENG_LB.Location = new System.Drawing.Point(2, 2);
            this.G_CHENG_LB.Name = "G_CHENG_LB";
            this.G_CHENG_LB.Size = new System.Drawing.Size(104, 22);
            this.G_CHENG_LB.TabIndex = 46;
            this.G_CHENG_LB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // label205
            // 
            this.label205.Dock = System.Windows.Forms.DockStyle.Left;
            this.label205.Location = new System.Drawing.Point(190, 0);
            this.label205.Name = "label205";
            this.label205.Size = new System.Drawing.Size(80, 24);
            this.label205.TabIndex = 0;
            this.label205.Text = "工程类别";
            this.label205.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel55
            // 
            this.panel55.Controls.Add(this.Q_GC_LB);
            this.panel55.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel55.Location = new System.Drawing.Point(80, 0);
            this.panel55.Name = "panel55";
            this.panel55.Padding = new System.Windows.Forms.Padding(2, 4, 4, 0);
            this.panel55.Size = new System.Drawing.Size(110, 24);
            this.panel55.TabIndex = 0;
            // 
            // Q_GC_LB
            // 
            this.Q_GC_LB.AssDispValue = true;
            this.Q_GC_LB.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Q_GC_LB.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Q_GC_LB.ForeColor = System.Drawing.Color.Blue;
            this.Q_GC_LB.Location = new System.Drawing.Point(2, 2);
            this.Q_GC_LB.Name = "Q_GC_LB";
            this.Q_GC_LB.Size = new System.Drawing.Size(104, 22);
            this.Q_GC_LB.TabIndex = 45;
            this.Q_GC_LB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // label225
            // 
            this.label225.Dock = System.Windows.Forms.DockStyle.Left;
            this.label225.Location = new System.Drawing.Point(0, 0);
            this.label225.Name = "label225";
            this.label225.Size = new System.Drawing.Size(80, 24);
            this.label225.TabIndex = 0;
            this.label225.Text = "前期工程类别";
            this.label225.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label226
            // 
            this.label226.BackColor = System.Drawing.Color.Black;
            this.label226.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label226.Location = new System.Drawing.Point(0, 24);
            this.label226.Name = "label226";
            this.label226.Size = new System.Drawing.Size(575, 1);
            this.label226.TabIndex = 0;
            this.label226.Text = "label226";
            this.label226.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel45
            // 
            this.panel45.Controls.Add(this.panel47);
            this.panel45.Controls.Add(this.label46);
            this.panel45.Controls.Add(this.panel48);
            this.panel45.Controls.Add(this.label47);
            this.panel45.Controls.Add(this.label48);
            this.panel45.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel45.Location = new System.Drawing.Point(0, 0);
            this.panel45.Name = "panel45";
            this.panel45.Size = new System.Drawing.Size(575, 25);
            this.panel45.TabIndex = 0;
            // 
            // panel47
            // 
            this.panel47.Controls.Add(this.SHI_QUAN_D);
            this.panel47.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel47.Location = new System.Drawing.Point(270, 0);
            this.panel47.Name = "panel47";
            this.panel47.Padding = new System.Windows.Forms.Padding(2, 4, 4, 0);
            this.panel47.Size = new System.Drawing.Size(110, 24);
            this.panel47.TabIndex = 0;
            // 
            // SHI_QUAN_D
            // 
            this.SHI_QUAN_D.AssDispValue = true;
            this.SHI_QUAN_D.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SHI_QUAN_D.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.SHI_QUAN_D.ForeColor = System.Drawing.Color.Blue;
            this.SHI_QUAN_D.Location = new System.Drawing.Point(2, 2);
            this.SHI_QUAN_D.Name = "SHI_QUAN_D";
            this.SHI_QUAN_D.Size = new System.Drawing.Size(104, 22);
            this.SHI_QUAN_D.TabIndex = 44;
            this.SHI_QUAN_D.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // label46
            // 
            this.label46.Dock = System.Windows.Forms.DockStyle.Left;
            this.label46.Location = new System.Drawing.Point(190, 0);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(80, 24);
            this.label46.TabIndex = 0;
            this.label46.Text = "事权等级";
            this.label46.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel48
            // 
            this.panel48.Controls.Add(this.Q_SQ_D);
            this.panel48.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel48.Location = new System.Drawing.Point(80, 0);
            this.panel48.Name = "panel48";
            this.panel48.Padding = new System.Windows.Forms.Padding(2, 4, 4, 0);
            this.panel48.Size = new System.Drawing.Size(110, 24);
            this.panel48.TabIndex = 0;
            // 
            // Q_SQ_D
            // 
            this.Q_SQ_D.AssDispValue = true;
            this.Q_SQ_D.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Q_SQ_D.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Q_SQ_D.ForeColor = System.Drawing.Color.Blue;
            this.Q_SQ_D.Location = new System.Drawing.Point(2, 2);
            this.Q_SQ_D.Name = "Q_SQ_D";
            this.Q_SQ_D.Size = new System.Drawing.Size(104, 22);
            this.Q_SQ_D.TabIndex = 43;
            this.Q_SQ_D.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // label47
            // 
            this.label47.Dock = System.Windows.Forms.DockStyle.Left;
            this.label47.Location = new System.Drawing.Point(0, 0);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(80, 24);
            this.label47.TabIndex = 0;
            this.label47.Text = "前期事权等级";
            this.label47.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label48
            // 
            this.label48.BackColor = System.Drawing.Color.Black;
            this.label48.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label48.Location = new System.Drawing.Point(0, 24);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(575, 1);
            this.label48.TabIndex = 0;
            this.label48.Text = "label48";
            this.label48.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label49
            // 
            this.label49.BackColor = System.Drawing.Color.Black;
            this.label49.Dock = System.Windows.Forms.DockStyle.Top;
            this.label49.Location = new System.Drawing.Point(1, 0);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(575, 1);
            this.label49.TabIndex = 0;
            this.label49.Text = "label49";
            this.label49.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label50
            // 
            this.label50.BackColor = System.Drawing.Color.Black;
            this.label50.Dock = System.Windows.Forms.DockStyle.Left;
            this.label50.Location = new System.Drawing.Point(0, 0);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(1, 201);
            this.label50.TabIndex = 0;
            this.label50.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label51
            // 
            this.label51.BackColor = System.Drawing.Color.Black;
            this.label51.Dock = System.Windows.Forms.DockStyle.Right;
            this.label51.Location = new System.Drawing.Point(576, 0);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(1, 201);
            this.label51.TabIndex = 0;
            this.label51.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelAttr4
            // 
            this.labelAttr4.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelAttr4.Font = new System.Drawing.Font("黑体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelAttr4.Location = new System.Drawing.Point(0, 0);
            this.labelAttr4.Name = "labelAttr4";
            this.labelAttr4.Size = new System.Drawing.Size(577, 30);
            this.labelAttr4.TabIndex = 0;
            this.labelAttr4.Text = " 林木因子";
            this.labelAttr4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // xtraTabPage3
            // 
            this.xtraTabPage3.Controls.Add(this.panel3);
            this.xtraTabPage3.Location = new System.Drawing.Point(4, 23);
            this.xtraTabPage3.Name = "xtraTabPage3";
            this.xtraTabPage3.Size = new System.Drawing.Size(577, 596);
            this.xtraTabPage3.TabIndex = 0;
            this.xtraTabPage3.Text = "小班因子";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.panelAttr6);
            this.panel3.Controls.Add(this.label38);
            this.panel3.Controls.Add(this.panelAttr5);
            this.panel3.Controls.Add(this.labelAttr6);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(577, 596);
            this.panel3.TabIndex = 0;
            // 
            // panelAttr6
            // 
            this.panelAttr6.Controls.Add(this.panelAttr61);
            this.panelAttr6.Controls.Add(this.label99);
            this.panelAttr6.Controls.Add(this.label100);
            this.panelAttr6.Controls.Add(this.label101);
            this.panelAttr6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelAttr6.Location = new System.Drawing.Point(0, 186);
            this.panelAttr6.Name = "panelAttr6";
            this.panelAttr6.Size = new System.Drawing.Size(577, 237);
            this.panelAttr6.TabIndex = 0;
            // 
            // panelAttr61
            // 
            this.panelAttr61.Controls.Add(this.panel4);
            this.panelAttr61.Controls.Add(this.panel154);
            this.panelAttr61.Controls.Add(this.panel103);
            this.panelAttr61.Controls.Add(this.panel99);
            this.panelAttr61.Controls.Add(this.panel95);
            this.panelAttr61.Controls.Add(this.panel91);
            this.panelAttr61.Controls.Add(this.panel63);
            this.panelAttr61.Controls.Add(this.panel65);
            this.panelAttr61.Controls.Add(this.panel69);
            this.panelAttr61.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelAttr61.Location = new System.Drawing.Point(1, 1);
            this.panelAttr61.Name = "panelAttr61";
            this.panelAttr61.Size = new System.Drawing.Size(575, 236);
            this.panelAttr61.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.panel27);
            this.panel4.Controls.Add(this.label28);
            this.panel4.Controls.Add(this.label30);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 210);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(575, 25);
            this.panel4.TabIndex = 0;
            // 
            // panel27
            // 
            this.panel27.Controls.Add(this.Remarks);
            this.panel27.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel27.Location = new System.Drawing.Point(40, 0);
            this.panel27.Name = "panel27";
            this.panel27.Padding = new System.Windows.Forms.Padding(2, 6, 8, 0);
            this.panel27.Size = new System.Drawing.Size(530, 24);
            this.panel27.TabIndex = 0;
            // 
            // Remarks
            // 
            this.Remarks.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Remarks.EditValue = "";
            this.Remarks.Location = new System.Drawing.Point(2, 8);
            this.Remarks.Name = "Remarks";
            this.Remarks.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.Remarks.Properties.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Remarks.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.Remarks.Properties.Appearance.Options.UseBackColor = true;
            this.Remarks.Properties.Appearance.Options.UseFont = true;
            this.Remarks.Properties.Appearance.Options.UseForeColor = true;
            this.Remarks.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.Remarks.Size = new System.Drawing.Size(520, 16);
            this.Remarks.TabIndex = 0;
            // 
            // label28
            // 
            this.label28.Dock = System.Windows.Forms.DockStyle.Left;
            this.label28.Location = new System.Drawing.Point(0, 0);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(40, 24);
            this.label28.TabIndex = 0;
            this.label28.Text = "说明";
            this.label28.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label30
            // 
            this.label30.BackColor = System.Drawing.Color.Black;
            this.label30.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label30.Location = new System.Drawing.Point(0, 24);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(575, 1);
            this.label30.TabIndex = 0;
            this.label30.Text = "label30";
            this.label30.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel154
            // 
            this.panel154.Controls.Add(this.panel33);
            this.panel154.Controls.Add(this.label204);
            this.panel154.Controls.Add(this.panel155);
            this.panel154.Controls.Add(this.label206);
            this.panel154.Controls.Add(this.panel156);
            this.panel154.Controls.Add(this.label207);
            this.panel154.Controls.Add(this.label208);
            this.panel154.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel154.Location = new System.Drawing.Point(0, 185);
            this.panel154.Name = "panel154";
            this.panel154.Size = new System.Drawing.Size(575, 25);
            this.panel154.TabIndex = 0;
            // 
            // panel33
            // 
            this.panel33.Controls.Add(this.GXSZQK);
            this.panel33.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel33.Location = new System.Drawing.Point(460, 0);
            this.panel33.Name = "panel33";
            this.panel33.Padding = new System.Windows.Forms.Padding(2, 4, 4, 0);
            this.panel33.Size = new System.Drawing.Size(110, 24);
            this.panel33.TabIndex = 0;
            // 
            // GXSZQK
            // 
            this.GXSZQK.AssDispValue = true;
            this.GXSZQK.Cursor = System.Windows.Forms.Cursors.Hand;
            this.GXSZQK.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.GXSZQK.ForeColor = System.Drawing.Color.Blue;
            this.GXSZQK.Location = new System.Drawing.Point(2, 2);
            this.GXSZQK.Name = "GXSZQK";
            this.GXSZQK.Size = new System.Drawing.Size(104, 22);
            this.GXSZQK.TabIndex = 121;
            this.GXSZQK.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // label204
            // 
            this.label204.Dock = System.Windows.Forms.DockStyle.Left;
            this.label204.Location = new System.Drawing.Point(380, 0);
            this.label204.Name = "label204";
            this.label204.Size = new System.Drawing.Size(80, 24);
            this.label204.TabIndex = 0;
            this.label204.Text = "下木生长情况";
            this.label204.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel155
            // 
            this.panel155.Controls.Add(this.GXFBQK);
            this.panel155.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel155.Location = new System.Drawing.Point(270, 0);
            this.panel155.Name = "panel155";
            this.panel155.Padding = new System.Windows.Forms.Padding(2, 4, 4, 0);
            this.panel155.Size = new System.Drawing.Size(110, 24);
            this.panel155.TabIndex = 0;
            // 
            // GXFBQK
            // 
            this.GXFBQK.AssDispValue = true;
            this.GXFBQK.Cursor = System.Windows.Forms.Cursors.Hand;
            this.GXFBQK.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.GXFBQK.ForeColor = System.Drawing.Color.Blue;
            this.GXFBQK.Location = new System.Drawing.Point(2, 2);
            this.GXFBQK.Name = "GXFBQK";
            this.GXFBQK.Size = new System.Drawing.Size(104, 22);
            this.GXFBQK.TabIndex = 120;
            this.GXFBQK.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // label206
            // 
            this.label206.Dock = System.Windows.Forms.DockStyle.Left;
            this.label206.Location = new System.Drawing.Point(190, 0);
            this.label206.Name = "label206";
            this.label206.Size = new System.Drawing.Size(80, 24);
            this.label206.TabIndex = 0;
            this.label206.Text = "下木分布情况";
            this.label206.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel156
            // 
            this.panel156.Controls.Add(this.GXGQZS);
            this.panel156.Controls.Add(this.label33);
            this.panel156.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel156.Location = new System.Drawing.Point(80, 0);
            this.panel156.Name = "panel156";
            this.panel156.Padding = new System.Windows.Forms.Padding(2, 6, 6, 2);
            this.panel156.Size = new System.Drawing.Size(110, 24);
            this.panel156.TabIndex = 0;
            // 
            // GXGQZS
            // 
            this.GXGQZS.Cursor = System.Windows.Forms.Cursors.Hand;
            this.GXGQZS.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.GXGQZS.EditScale = 0;
            this.GXGQZS.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.GXGQZS.Location = new System.Drawing.Point(2, 4);
            this.GXGQZS.Name = "GXGQZS";
            this.GXGQZS.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.GXGQZS.Properties.Appearance.Options.UseForeColor = true;
            this.GXGQZS.Properties.Appearance.Options.UseTextOptions = true;
            this.GXGQZS.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.GXGQZS.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.GXGQZS.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.GXGQZS.Properties.MaxValue = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.GXGQZS.Size = new System.Drawing.Size(83, 18);
            this.GXGQZS.TabIndex = 119;
            this.GXGQZS.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // label33
            // 
            this.label33.Dock = System.Windows.Forms.DockStyle.Right;
            this.label33.ForeColor = System.Drawing.Color.Blue;
            this.label33.Location = new System.Drawing.Point(85, 6);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(19, 16);
            this.label33.TabIndex = 0;
            this.label33.Text = "株";
            this.label33.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label207
            // 
            this.label207.Dock = System.Windows.Forms.DockStyle.Left;
            this.label207.Location = new System.Drawing.Point(0, 0);
            this.label207.Name = "label207";
            this.label207.Size = new System.Drawing.Size(80, 24);
            this.label207.TabIndex = 0;
            this.label207.Text = "下木公顷株数";
            this.label207.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label208
            // 
            this.label208.BackColor = System.Drawing.Color.Black;
            this.label208.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label208.Location = new System.Drawing.Point(0, 24);
            this.label208.Name = "label208";
            this.label208.Size = new System.Drawing.Size(575, 1);
            this.label208.TabIndex = 0;
            this.label208.Text = "label208";
            this.label208.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel103
            // 
            this.panel103.Controls.Add(this.panel32);
            this.panel103.Controls.Add(this.label203);
            this.panel103.Controls.Add(this.panel113);
            this.panel103.Controls.Add(this.label130);
            this.panel103.Controls.Add(this.panel114);
            this.panel103.Controls.Add(this.label131);
            this.panel103.Controls.Add(this.label132);
            this.panel103.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel103.Location = new System.Drawing.Point(0, 160);
            this.panel103.Name = "panel103";
            this.panel103.Size = new System.Drawing.Size(575, 25);
            this.panel103.TabIndex = 0;
            // 
            // panel32
            // 
            this.panel32.Controls.Add(this.GXPJGD);
            this.panel32.Controls.Add(this.label32);
            this.panel32.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel32.Location = new System.Drawing.Point(460, 0);
            this.panel32.Name = "panel32";
            this.panel32.Padding = new System.Windows.Forms.Padding(2, 6, 6, 2);
            this.panel32.Size = new System.Drawing.Size(110, 24);
            this.panel32.TabIndex = 0;
            // 
            // GXPJGD
            // 
            this.GXPJGD.Cursor = System.Windows.Forms.Cursors.Hand;
            this.GXPJGD.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.GXPJGD.EditScale = 0;
            this.GXPJGD.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.GXPJGD.Location = new System.Drawing.Point(2, 4);
            this.GXPJGD.Name = "GXPJGD";
            this.GXPJGD.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.GXPJGD.Properties.Appearance.Options.UseForeColor = true;
            this.GXPJGD.Properties.Appearance.Options.UseTextOptions = true;
            this.GXPJGD.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.GXPJGD.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.GXPJGD.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.GXPJGD.Properties.MaxValue = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.GXPJGD.Size = new System.Drawing.Size(83, 18);
            this.GXPJGD.TabIndex = 118;
            this.GXPJGD.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // label32
            // 
            this.label32.Dock = System.Windows.Forms.DockStyle.Right;
            this.label32.ForeColor = System.Drawing.Color.Blue;
            this.label32.Location = new System.Drawing.Point(85, 6);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(19, 16);
            this.label32.TabIndex = 0;
            this.label32.Text = "m";
            this.label32.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label203
            // 
            this.label203.Dock = System.Windows.Forms.DockStyle.Left;
            this.label203.Location = new System.Drawing.Point(380, 0);
            this.label203.Name = "label203";
            this.label203.Size = new System.Drawing.Size(80, 24);
            this.label203.TabIndex = 0;
            this.label203.Text = "下木平均高度";
            this.label203.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel113
            // 
            this.panel113.Controls.Add(this.GXPJNL);
            this.panel113.Controls.Add(this.label140);
            this.panel113.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel113.Location = new System.Drawing.Point(270, 0);
            this.panel113.Name = "panel113";
            this.panel113.Padding = new System.Windows.Forms.Padding(2, 6, 6, 2);
            this.panel113.Size = new System.Drawing.Size(110, 24);
            this.panel113.TabIndex = 0;
            // 
            // GXPJNL
            // 
            this.GXPJNL.Cursor = System.Windows.Forms.Cursors.Hand;
            this.GXPJNL.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.GXPJNL.EditScale = 0;
            this.GXPJNL.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.GXPJNL.Location = new System.Drawing.Point(2, 4);
            this.GXPJNL.Name = "GXPJNL";
            this.GXPJNL.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.GXPJNL.Properties.Appearance.Options.UseForeColor = true;
            this.GXPJNL.Properties.Appearance.Options.UseTextOptions = true;
            this.GXPJNL.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.GXPJNL.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.GXPJNL.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.GXPJNL.Properties.MaxValue = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.GXPJNL.Size = new System.Drawing.Size(83, 18);
            this.GXPJNL.TabIndex = 117;
            this.GXPJNL.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // label140
            // 
            this.label140.Dock = System.Windows.Forms.DockStyle.Right;
            this.label140.ForeColor = System.Drawing.Color.Blue;
            this.label140.Location = new System.Drawing.Point(85, 6);
            this.label140.Name = "label140";
            this.label140.Size = new System.Drawing.Size(19, 16);
            this.label140.TabIndex = 0;
            this.label140.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label130
            // 
            this.label130.Dock = System.Windows.Forms.DockStyle.Left;
            this.label130.Location = new System.Drawing.Point(190, 0);
            this.label130.Name = "label130";
            this.label130.Size = new System.Drawing.Size(80, 24);
            this.label130.TabIndex = 0;
            this.label130.Text = "下木平均年龄";
            this.label130.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel114
            // 
            this.panel114.Controls.Add(this.GXYSSZ);
            this.panel114.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel114.Location = new System.Drawing.Point(80, 0);
            this.panel114.Name = "panel114";
            this.panel114.Padding = new System.Windows.Forms.Padding(2, 4, 4, 0);
            this.panel114.Size = new System.Drawing.Size(110, 24);
            this.panel114.TabIndex = 0;
            // 
            // GXYSSZ
            // 
            this.GXYSSZ.AssDispValue = true;
            this.GXYSSZ.Cursor = System.Windows.Forms.Cursors.Hand;
            this.GXYSSZ.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.GXYSSZ.ForeColor = System.Drawing.Color.Blue;
            this.GXYSSZ.Location = new System.Drawing.Point(2, 2);
            this.GXYSSZ.Name = "GXYSSZ";
            this.GXYSSZ.Size = new System.Drawing.Size(104, 22);
            this.GXYSSZ.TabIndex = 116;
            this.GXYSSZ.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // label131
            // 
            this.label131.Dock = System.Windows.Forms.DockStyle.Left;
            this.label131.Location = new System.Drawing.Point(0, 0);
            this.label131.Name = "label131";
            this.label131.Size = new System.Drawing.Size(80, 24);
            this.label131.TabIndex = 0;
            this.label131.Text = "下木优势树种";
            this.label131.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label132
            // 
            this.label132.BackColor = System.Drawing.Color.Black;
            this.label132.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label132.Location = new System.Drawing.Point(0, 24);
            this.label132.Name = "label132";
            this.label132.Size = new System.Drawing.Size(575, 1);
            this.label132.TabIndex = 0;
            this.label132.Text = "label132";
            this.label132.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel99
            // 
            this.panel99.Controls.Add(this.panel100);
            this.panel99.Controls.Add(this.label114);
            this.panel99.Controls.Add(this.panel101);
            this.panel99.Controls.Add(this.label126);
            this.panel99.Controls.Add(this.panel102);
            this.panel99.Controls.Add(this.label127);
            this.panel99.Controls.Add(this.label128);
            this.panel99.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel99.Location = new System.Drawing.Point(0, 135);
            this.panel99.Name = "panel99";
            this.panel99.Size = new System.Drawing.Size(575, 25);
            this.panel99.TabIndex = 0;
            // 
            // panel100
            // 
            this.panel100.Controls.Add(this.CMZGD);
            this.panel100.Controls.Add(this.label34);
            this.panel100.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel100.Location = new System.Drawing.Point(460, 0);
            this.panel100.Name = "panel100";
            this.panel100.Padding = new System.Windows.Forms.Padding(2, 6, 6, 2);
            this.panel100.Size = new System.Drawing.Size(110, 24);
            this.panel100.TabIndex = 0;
            // 
            // CMZGD
            // 
            this.CMZGD.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CMZGD.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.CMZGD.EditScale = 0;
            this.CMZGD.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.CMZGD.Location = new System.Drawing.Point(2, 4);
            this.CMZGD.Name = "CMZGD";
            this.CMZGD.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.CMZGD.Properties.Appearance.Options.UseForeColor = true;
            this.CMZGD.Properties.Appearance.Options.UseTextOptions = true;
            this.CMZGD.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.CMZGD.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.CMZGD.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.CMZGD.Properties.MaxValue = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.CMZGD.Size = new System.Drawing.Size(83, 18);
            this.CMZGD.TabIndex = 115;
            this.CMZGD.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // label34
            // 
            this.label34.Dock = System.Windows.Forms.DockStyle.Right;
            this.label34.ForeColor = System.Drawing.Color.Blue;
            this.label34.Location = new System.Drawing.Point(85, 6);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(19, 16);
            this.label34.TabIndex = 0;
            this.label34.Text = "%";
            this.label34.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label114
            // 
            this.label114.Dock = System.Windows.Forms.DockStyle.Left;
            this.label114.Location = new System.Drawing.Point(380, 0);
            this.label114.Name = "label114";
            this.label114.Size = new System.Drawing.Size(80, 24);
            this.label114.TabIndex = 0;
            this.label114.Text = "草本层总盖度";
            this.label114.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel101
            // 
            this.panel101.Controls.Add(this.CBPJGD);
            this.panel101.Controls.Add(this.label45);
            this.panel101.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel101.Location = new System.Drawing.Point(270, 0);
            this.panel101.Name = "panel101";
            this.panel101.Padding = new System.Windows.Forms.Padding(2, 6, 6, 2);
            this.panel101.Size = new System.Drawing.Size(110, 24);
            this.panel101.TabIndex = 0;
            // 
            // CBPJGD
            // 
            this.CBPJGD.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CBPJGD.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.CBPJGD.EditScale = 0;
            this.CBPJGD.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.CBPJGD.Location = new System.Drawing.Point(2, 4);
            this.CBPJGD.Name = "CBPJGD";
            this.CBPJGD.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.CBPJGD.Properties.Appearance.Options.UseForeColor = true;
            this.CBPJGD.Properties.Appearance.Options.UseTextOptions = true;
            this.CBPJGD.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.CBPJGD.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.CBPJGD.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.CBPJGD.Properties.MaxValue = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.CBPJGD.Size = new System.Drawing.Size(83, 18);
            this.CBPJGD.TabIndex = 114;
            this.CBPJGD.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // label45
            // 
            this.label45.Dock = System.Windows.Forms.DockStyle.Right;
            this.label45.ForeColor = System.Drawing.Color.Blue;
            this.label45.Location = new System.Drawing.Point(85, 6);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(19, 16);
            this.label45.TabIndex = 0;
            this.label45.Text = "m";
            this.label45.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label126
            // 
            this.label126.Dock = System.Windows.Forms.DockStyle.Left;
            this.label126.Location = new System.Drawing.Point(190, 0);
            this.label126.Name = "label126";
            this.label126.Size = new System.Drawing.Size(80, 24);
            this.label126.TabIndex = 0;
            this.label126.Text = "草本层平均高";
            this.label126.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel102
            // 
            this.panel102.Controls.Add(this.CBYSZ);
            this.panel102.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel102.Location = new System.Drawing.Point(80, 0);
            this.panel102.Name = "panel102";
            this.panel102.Padding = new System.Windows.Forms.Padding(2, 4, 4, 0);
            this.panel102.Size = new System.Drawing.Size(110, 24);
            this.panel102.TabIndex = 0;
            // 
            // CBYSZ
            // 
            this.CBYSZ.AssDispValue = true;
            this.CBYSZ.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CBYSZ.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.CBYSZ.ForeColor = System.Drawing.Color.Blue;
            this.CBYSZ.Location = new System.Drawing.Point(2, 2);
            this.CBYSZ.Name = "CBYSZ";
            this.CBYSZ.Size = new System.Drawing.Size(104, 22);
            this.CBYSZ.TabIndex = 113;
            this.CBYSZ.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // label127
            // 
            this.label127.Dock = System.Windows.Forms.DockStyle.Left;
            this.label127.Location = new System.Drawing.Point(0, 0);
            this.label127.Name = "label127";
            this.label127.Size = new System.Drawing.Size(80, 24);
            this.label127.TabIndex = 0;
            this.label127.Text = "草本层优势种";
            this.label127.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label128
            // 
            this.label128.BackColor = System.Drawing.Color.Black;
            this.label128.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label128.Location = new System.Drawing.Point(0, 24);
            this.label128.Name = "label128";
            this.label128.Size = new System.Drawing.Size(575, 1);
            this.label128.TabIndex = 0;
            this.label128.Text = "label128";
            this.label128.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel95
            // 
            this.panel95.Controls.Add(this.panel96);
            this.panel95.Controls.Add(this.label110);
            this.panel95.Controls.Add(this.panel97);
            this.panel95.Controls.Add(this.label111);
            this.panel95.Controls.Add(this.panel98);
            this.panel95.Controls.Add(this.label112);
            this.panel95.Controls.Add(this.label113);
            this.panel95.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel95.Location = new System.Drawing.Point(0, 110);
            this.panel95.Name = "panel95";
            this.panel95.Size = new System.Drawing.Size(575, 25);
            this.panel95.TabIndex = 0;
            // 
            // panel96
            // 
            this.panel96.Controls.Add(this.GMZGD);
            this.panel96.Controls.Add(this.label52);
            this.panel96.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel96.Location = new System.Drawing.Point(460, 0);
            this.panel96.Name = "panel96";
            this.panel96.Padding = new System.Windows.Forms.Padding(2, 6, 6, 2);
            this.panel96.Size = new System.Drawing.Size(110, 24);
            this.panel96.TabIndex = 0;
            // 
            // GMZGD
            // 
            this.GMZGD.Cursor = System.Windows.Forms.Cursors.Hand;
            this.GMZGD.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.GMZGD.EditScale = 0;
            this.GMZGD.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.GMZGD.Location = new System.Drawing.Point(2, 4);
            this.GMZGD.Name = "GMZGD";
            this.GMZGD.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.GMZGD.Properties.Appearance.Options.UseForeColor = true;
            this.GMZGD.Properties.Appearance.Options.UseTextOptions = true;
            this.GMZGD.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.GMZGD.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.GMZGD.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.GMZGD.Properties.MaxValue = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.GMZGD.Size = new System.Drawing.Size(83, 18);
            this.GMZGD.TabIndex = 112;
            this.GMZGD.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // label52
            // 
            this.label52.Dock = System.Windows.Forms.DockStyle.Right;
            this.label52.ForeColor = System.Drawing.Color.Blue;
            this.label52.Location = new System.Drawing.Point(85, 6);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(19, 16);
            this.label52.TabIndex = 0;
            this.label52.Text = "%";
            this.label52.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label110
            // 
            this.label110.Dock = System.Windows.Forms.DockStyle.Left;
            this.label110.Location = new System.Drawing.Point(380, 0);
            this.label110.Name = "label110";
            this.label110.Size = new System.Drawing.Size(80, 24);
            this.label110.TabIndex = 0;
            this.label110.Text = "灌木层总盖度";
            this.label110.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel97
            // 
            this.panel97.Controls.Add(this.GMPJGD);
            this.panel97.Controls.Add(this.label56);
            this.panel97.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel97.Location = new System.Drawing.Point(270, 0);
            this.panel97.Name = "panel97";
            this.panel97.Padding = new System.Windows.Forms.Padding(2, 6, 6, 2);
            this.panel97.Size = new System.Drawing.Size(110, 24);
            this.panel97.TabIndex = 0;
            // 
            // GMPJGD
            // 
            this.GMPJGD.Cursor = System.Windows.Forms.Cursors.Hand;
            this.GMPJGD.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.GMPJGD.EditScale = 0;
            this.GMPJGD.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.GMPJGD.Location = new System.Drawing.Point(2, 4);
            this.GMPJGD.Name = "GMPJGD";
            this.GMPJGD.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.GMPJGD.Properties.Appearance.Options.UseForeColor = true;
            this.GMPJGD.Properties.Appearance.Options.UseTextOptions = true;
            this.GMPJGD.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.GMPJGD.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.GMPJGD.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.GMPJGD.Properties.MaxValue = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.GMPJGD.Size = new System.Drawing.Size(83, 18);
            this.GMPJGD.TabIndex = 111;
            this.GMPJGD.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // label56
            // 
            this.label56.Dock = System.Windows.Forms.DockStyle.Right;
            this.label56.ForeColor = System.Drawing.Color.Blue;
            this.label56.Location = new System.Drawing.Point(85, 6);
            this.label56.Name = "label56";
            this.label56.Size = new System.Drawing.Size(19, 16);
            this.label56.TabIndex = 0;
            this.label56.Text = "m";
            this.label56.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label111
            // 
            this.label111.Dock = System.Windows.Forms.DockStyle.Left;
            this.label111.Location = new System.Drawing.Point(190, 0);
            this.label111.Name = "label111";
            this.label111.Size = new System.Drawing.Size(80, 24);
            this.label111.TabIndex = 0;
            this.label111.Text = "灌木层平均高";
            this.label111.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel98
            // 
            this.panel98.Controls.Add(this.GMYSZ);
            this.panel98.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel98.Location = new System.Drawing.Point(80, 0);
            this.panel98.Name = "panel98";
            this.panel98.Padding = new System.Windows.Forms.Padding(2, 4, 4, 0);
            this.panel98.Size = new System.Drawing.Size(110, 24);
            this.panel98.TabIndex = 0;
            // 
            // GMYSZ
            // 
            this.GMYSZ.AssDispValue = true;
            this.GMYSZ.Cursor = System.Windows.Forms.Cursors.Hand;
            this.GMYSZ.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.GMYSZ.ForeColor = System.Drawing.Color.Blue;
            this.GMYSZ.Location = new System.Drawing.Point(2, 2);
            this.GMYSZ.Name = "GMYSZ";
            this.GMYSZ.Size = new System.Drawing.Size(104, 22);
            this.GMYSZ.TabIndex = 110;
            this.GMYSZ.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // label112
            // 
            this.label112.Dock = System.Windows.Forms.DockStyle.Left;
            this.label112.Location = new System.Drawing.Point(0, 0);
            this.label112.Name = "label112";
            this.label112.Size = new System.Drawing.Size(80, 24);
            this.label112.TabIndex = 0;
            this.label112.Text = "灌木层优势种";
            this.label112.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label113
            // 
            this.label113.BackColor = System.Drawing.Color.Black;
            this.label113.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label113.Location = new System.Drawing.Point(0, 24);
            this.label113.Name = "label113";
            this.label113.Size = new System.Drawing.Size(575, 1);
            this.label113.TabIndex = 0;
            this.label113.Text = "label113";
            this.label113.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel91
            // 
            this.panel91.Controls.Add(this.panel92);
            this.panel91.Controls.Add(this.label106);
            this.panel91.Controls.Add(this.panel93);
            this.panel91.Controls.Add(this.label107);
            this.panel91.Controls.Add(this.panel94);
            this.panel91.Controls.Add(this.label108);
            this.panel91.Controls.Add(this.label109);
            this.panel91.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel91.Location = new System.Drawing.Point(0, 85);
            this.panel91.Name = "panel91";
            this.panel91.Size = new System.Drawing.Size(575, 25);
            this.panel91.TabIndex = 0;
            // 
            // panel92
            // 
            this.panel92.Controls.Add(this.SSPJGD);
            this.panel92.Controls.Add(this.label55);
            this.panel92.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel92.Location = new System.Drawing.Point(460, 0);
            this.panel92.Name = "panel92";
            this.panel92.Padding = new System.Windows.Forms.Padding(2, 6, 6, 2);
            this.panel92.Size = new System.Drawing.Size(110, 24);
            this.panel92.TabIndex = 0;
            // 
            // SSPJGD
            // 
            this.SSPJGD.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SSPJGD.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.SSPJGD.EditScale = 0;
            this.SSPJGD.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.SSPJGD.Location = new System.Drawing.Point(2, 4);
            this.SSPJGD.Name = "SSPJGD";
            this.SSPJGD.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.SSPJGD.Properties.Appearance.Options.UseForeColor = true;
            this.SSPJGD.Properties.Appearance.Options.UseTextOptions = true;
            this.SSPJGD.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.SSPJGD.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.SSPJGD.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.SSPJGD.Properties.MaxValue = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.SSPJGD.Size = new System.Drawing.Size(83, 18);
            this.SSPJGD.TabIndex = 109;
            this.SSPJGD.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // label55
            // 
            this.label55.Dock = System.Windows.Forms.DockStyle.Right;
            this.label55.ForeColor = System.Drawing.Color.Blue;
            this.label55.Location = new System.Drawing.Point(85, 6);
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size(19, 16);
            this.label55.TabIndex = 0;
            this.label55.Text = "m";
            this.label55.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label106
            // 
            this.label106.Dock = System.Windows.Forms.DockStyle.Left;
            this.label106.Location = new System.Drawing.Point(380, 0);
            this.label106.Name = "label106";
            this.label106.Size = new System.Drawing.Size(80, 24);
            this.label106.TabIndex = 0;
            this.label106.Text = "散生平均高度";
            this.label106.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel93
            // 
            this.panel93.Controls.Add(this.SSPJXJ);
            this.panel93.Controls.Add(this.label57);
            this.panel93.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel93.Location = new System.Drawing.Point(270, 0);
            this.panel93.Name = "panel93";
            this.panel93.Padding = new System.Windows.Forms.Padding(2, 6, 6, 2);
            this.panel93.Size = new System.Drawing.Size(110, 24);
            this.panel93.TabIndex = 0;
            // 
            // SSPJXJ
            // 
            this.SSPJXJ.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SSPJXJ.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.SSPJXJ.EditScale = 0;
            this.SSPJXJ.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.SSPJXJ.Location = new System.Drawing.Point(2, 4);
            this.SSPJXJ.Name = "SSPJXJ";
            this.SSPJXJ.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.SSPJXJ.Properties.Appearance.Options.UseForeColor = true;
            this.SSPJXJ.Properties.Appearance.Options.UseTextOptions = true;
            this.SSPJXJ.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.SSPJXJ.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.SSPJXJ.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.SSPJXJ.Properties.MaxValue = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.SSPJXJ.Size = new System.Drawing.Size(77, 18);
            this.SSPJXJ.TabIndex = 108;
            this.SSPJXJ.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // label57
            // 
            this.label57.Dock = System.Windows.Forms.DockStyle.Right;
            this.label57.ForeColor = System.Drawing.Color.Blue;
            this.label57.Location = new System.Drawing.Point(79, 6);
            this.label57.Name = "label57";
            this.label57.Size = new System.Drawing.Size(25, 16);
            this.label57.TabIndex = 0;
            this.label57.Text = "cm";
            this.label57.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label107
            // 
            this.label107.Dock = System.Windows.Forms.DockStyle.Left;
            this.label107.Location = new System.Drawing.Point(190, 0);
            this.label107.Name = "label107";
            this.label107.Size = new System.Drawing.Size(80, 24);
            this.label107.TabIndex = 0;
            this.label107.Text = "散生平均胸径";
            this.label107.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel94
            // 
            this.panel94.Controls.Add(this.SSZZS);
            this.panel94.Controls.Add(this.label58);
            this.panel94.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel94.Location = new System.Drawing.Point(80, 0);
            this.panel94.Name = "panel94";
            this.panel94.Padding = new System.Windows.Forms.Padding(2, 6, 6, 2);
            this.panel94.Size = new System.Drawing.Size(110, 24);
            this.panel94.TabIndex = 0;
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
            100,
            0,
            0,
            0});
            this.SSZZS.Size = new System.Drawing.Size(83, 18);
            this.SSZZS.TabIndex = 107;
            this.SSZZS.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // label58
            // 
            this.label58.Dock = System.Windows.Forms.DockStyle.Right;
            this.label58.ForeColor = System.Drawing.Color.Blue;
            this.label58.Location = new System.Drawing.Point(85, 6);
            this.label58.Name = "label58";
            this.label58.Size = new System.Drawing.Size(19, 16);
            this.label58.TabIndex = 0;
            this.label58.Text = "株";
            this.label58.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label108
            // 
            this.label108.Dock = System.Windows.Forms.DockStyle.Left;
            this.label108.Location = new System.Drawing.Point(0, 0);
            this.label108.Name = "label108";
            this.label108.Size = new System.Drawing.Size(80, 24);
            this.label108.TabIndex = 0;
            this.label108.Text = "散生总株数";
            this.label108.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label109
            // 
            this.label109.BackColor = System.Drawing.Color.Black;
            this.label109.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label109.Location = new System.Drawing.Point(0, 24);
            this.label109.Name = "label109";
            this.label109.Size = new System.Drawing.Size(575, 1);
            this.label109.TabIndex = 0;
            this.label109.Text = "label109";
            this.label109.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel63
            // 
            this.panel63.Controls.Add(this.panel64);
            this.panel63.Controls.Add(this.label102);
            this.panel63.Controls.Add(this.panel89);
            this.panel63.Controls.Add(this.label103);
            this.panel63.Controls.Add(this.panel90);
            this.panel63.Controls.Add(this.label104);
            this.panel63.Controls.Add(this.label105);
            this.panel63.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel63.Location = new System.Drawing.Point(0, 55);
            this.panel63.Name = "panel63";
            this.panel63.Size = new System.Drawing.Size(575, 30);
            this.panel63.TabIndex = 0;
            // 
            // panel64
            // 
            this.panel64.Controls.Add(this.SSZYSZ);
            this.panel64.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel64.Location = new System.Drawing.Point(460, 0);
            this.panel64.Name = "panel64";
            this.panel64.Padding = new System.Windows.Forms.Padding(2, 4, 4, 0);
            this.panel64.Size = new System.Drawing.Size(110, 29);
            this.panel64.TabIndex = 0;
            // 
            // SSZYSZ
            // 
            this.SSZYSZ.AssDispValue = true;
            this.SSZYSZ.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SSZYSZ.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.SSZYSZ.ForeColor = System.Drawing.Color.Blue;
            this.SSZYSZ.Location = new System.Drawing.Point(2, 7);
            this.SSZYSZ.Name = "SSZYSZ";
            this.SSZYSZ.Size = new System.Drawing.Size(104, 22);
            this.SSZYSZ.TabIndex = 106;
            this.SSZYSZ.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // label102
            // 
            this.label102.Dock = System.Windows.Forms.DockStyle.Left;
            this.label102.Location = new System.Drawing.Point(380, 0);
            this.label102.Name = "label102";
            this.label102.Size = new System.Drawing.Size(80, 29);
            this.label102.TabIndex = 0;
            this.label102.Text = "散生主要树种";
            this.label102.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel89
            // 
            this.panel89.Controls.Add(this.SSLX);
            this.panel89.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel89.Location = new System.Drawing.Point(270, 0);
            this.panel89.Name = "panel89";
            this.panel89.Padding = new System.Windows.Forms.Padding(2, 4, 4, 0);
            this.panel89.Size = new System.Drawing.Size(110, 29);
            this.panel89.TabIndex = 0;
            // 
            // SSLX
            // 
            this.SSLX.AssDispValue = true;
            this.SSLX.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SSLX.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.SSLX.ForeColor = System.Drawing.Color.Blue;
            this.SSLX.Location = new System.Drawing.Point(2, 7);
            this.SSLX.Name = "SSLX";
            this.SSLX.Size = new System.Drawing.Size(104, 22);
            this.SSLX.TabIndex = 105;
            this.SSLX.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // label103
            // 
            this.label103.Dock = System.Windows.Forms.DockStyle.Left;
            this.label103.Location = new System.Drawing.Point(190, 0);
            this.label103.Name = "label103";
            this.label103.Size = new System.Drawing.Size(80, 29);
            this.label103.TabIndex = 0;
            this.label103.Text = "散生类型";
            this.label103.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel90
            // 
            this.panel90.Controls.Add(this.BSSZGQZS);
            this.panel90.Controls.Add(this.label139);
            this.panel90.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel90.Location = new System.Drawing.Point(80, 0);
            this.panel90.Name = "panel90";
            this.panel90.Padding = new System.Windows.Forms.Padding(2, 6, 6, 2);
            this.panel90.Size = new System.Drawing.Size(110, 29);
            this.panel90.TabIndex = 0;
            // 
            // BSSZGQZS
            // 
            this.BSSZGQZS.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BSSZGQZS.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BSSZGQZS.EditScale = 0;
            this.BSSZGQZS.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.BSSZGQZS.Location = new System.Drawing.Point(2, 9);
            this.BSSZGQZS.Name = "BSSZGQZS";
            this.BSSZGQZS.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.BSSZGQZS.Properties.Appearance.Options.UseForeColor = true;
            this.BSSZGQZS.Properties.Appearance.Options.UseTextOptions = true;
            this.BSSZGQZS.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.BSSZGQZS.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.BSSZGQZS.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.BSSZGQZS.Properties.MaxValue = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.BSSZGQZS.Size = new System.Drawing.Size(83, 18);
            this.BSSZGQZS.TabIndex = 104;
            this.BSSZGQZS.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // label139
            // 
            this.label139.Dock = System.Windows.Forms.DockStyle.Right;
            this.label139.ForeColor = System.Drawing.Color.Blue;
            this.label139.Location = new System.Drawing.Point(85, 6);
            this.label139.Name = "label139";
            this.label139.Size = new System.Drawing.Size(19, 21);
            this.label139.TabIndex = 0;
            this.label139.Text = "株";
            this.label139.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label104
            // 
            this.label104.Dock = System.Windows.Forms.DockStyle.Left;
            this.label104.Location = new System.Drawing.Point(0, 0);
            this.label104.Name = "label104";
            this.label104.Size = new System.Drawing.Size(80, 29);
            this.label104.TabIndex = 0;
            this.label104.Text = "伴生树种每公顷株数";
            this.label104.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label105
            // 
            this.label105.BackColor = System.Drawing.Color.Black;
            this.label105.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label105.Location = new System.Drawing.Point(0, 29);
            this.label105.Name = "label105";
            this.label105.Size = new System.Drawing.Size(575, 1);
            this.label105.TabIndex = 0;
            this.label105.Text = "label105";
            this.label105.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel65
            // 
            this.panel65.Controls.Add(this.panel66);
            this.panel65.Controls.Add(this.label68);
            this.panel65.Controls.Add(this.panel67);
            this.panel65.Controls.Add(this.label69);
            this.panel65.Controls.Add(this.panel68);
            this.panel65.Controls.Add(this.label70);
            this.panel65.Controls.Add(this.label71);
            this.panel65.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel65.Location = new System.Drawing.Point(0, 25);
            this.panel65.Name = "panel65";
            this.panel65.Size = new System.Drawing.Size(575, 30);
            this.panel65.TabIndex = 0;
            // 
            // panel66
            // 
            this.panel66.Controls.Add(this.BSSZGQDM);
            this.panel66.Controls.Add(this.label138);
            this.panel66.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel66.Location = new System.Drawing.Point(460, 0);
            this.panel66.Name = "panel66";
            this.panel66.Padding = new System.Windows.Forms.Padding(2, 6, 6, 2);
            this.panel66.Size = new System.Drawing.Size(110, 29);
            this.panel66.TabIndex = 0;
            // 
            // BSSZGQDM
            // 
            this.BSSZGQDM.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BSSZGQDM.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BSSZGQDM.EditScale = 0;
            this.BSSZGQDM.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.BSSZGQDM.Location = new System.Drawing.Point(2, 9);
            this.BSSZGQDM.Name = "BSSZGQDM";
            this.BSSZGQDM.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.BSSZGQDM.Properties.Appearance.Options.UseForeColor = true;
            this.BSSZGQDM.Properties.Appearance.Options.UseTextOptions = true;
            this.BSSZGQDM.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.BSSZGQDM.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.BSSZGQDM.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.BSSZGQDM.Size = new System.Drawing.Size(70, 18);
            this.BSSZGQDM.TabIndex = 103;
            this.BSSZGQDM.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // label138
            // 
            this.label138.Dock = System.Windows.Forms.DockStyle.Right;
            this.label138.ForeColor = System.Drawing.Color.Blue;
            this.label138.Location = new System.Drawing.Point(72, 6);
            this.label138.Name = "label138";
            this.label138.Size = new System.Drawing.Size(32, 21);
            this.label138.TabIndex = 0;
            this.label138.Text = "公顷";
            this.label138.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label68
            // 
            this.label68.Dock = System.Windows.Forms.DockStyle.Left;
            this.label68.Location = new System.Drawing.Point(380, 0);
            this.label68.Name = "label68";
            this.label68.Size = new System.Drawing.Size(80, 29);
            this.label68.TabIndex = 0;
            this.label68.Text = "伴生树种每公顷断面积";
            this.label68.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel67
            // 
            this.panel67.Controls.Add(this.BSSZPJXJ);
            this.panel67.Controls.Add(this.label142);
            this.panel67.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel67.Location = new System.Drawing.Point(270, 0);
            this.panel67.Name = "panel67";
            this.panel67.Padding = new System.Windows.Forms.Padding(2, 6, 6, 2);
            this.panel67.Size = new System.Drawing.Size(110, 29);
            this.panel67.TabIndex = 0;
            // 
            // BSSZPJXJ
            // 
            this.BSSZPJXJ.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BSSZPJXJ.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BSSZPJXJ.EditScale = 0;
            this.BSSZPJXJ.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.BSSZPJXJ.Location = new System.Drawing.Point(2, 9);
            this.BSSZPJXJ.Name = "BSSZPJXJ";
            this.BSSZPJXJ.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.BSSZPJXJ.Properties.Appearance.Options.UseForeColor = true;
            this.BSSZPJXJ.Properties.Appearance.Options.UseTextOptions = true;
            this.BSSZPJXJ.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.BSSZPJXJ.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.BSSZPJXJ.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.BSSZPJXJ.Properties.MaxValue = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.BSSZPJXJ.Size = new System.Drawing.Size(77, 18);
            this.BSSZPJXJ.TabIndex = 102;
            this.BSSZPJXJ.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // label142
            // 
            this.label142.Dock = System.Windows.Forms.DockStyle.Right;
            this.label142.ForeColor = System.Drawing.Color.Blue;
            this.label142.Location = new System.Drawing.Point(79, 6);
            this.label142.Name = "label142";
            this.label142.Size = new System.Drawing.Size(25, 21);
            this.label142.TabIndex = 0;
            this.label142.Text = "cm";
            this.label142.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label69
            // 
            this.label69.Dock = System.Windows.Forms.DockStyle.Left;
            this.label69.Location = new System.Drawing.Point(190, 0);
            this.label69.Name = "label69";
            this.label69.Size = new System.Drawing.Size(80, 29);
            this.label69.TabIndex = 0;
            this.label69.Text = "伴生树种平均胸径";
            this.label69.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel68
            // 
            this.panel68.Controls.Add(this.BSSZSG);
            this.panel68.Controls.Add(this.label31);
            this.panel68.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel68.Location = new System.Drawing.Point(80, 0);
            this.panel68.Name = "panel68";
            this.panel68.Padding = new System.Windows.Forms.Padding(2, 6, 6, 2);
            this.panel68.Size = new System.Drawing.Size(110, 29);
            this.panel68.TabIndex = 0;
            // 
            // BSSZSG
            // 
            this.BSSZSG.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BSSZSG.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BSSZSG.EditScale = 0;
            this.BSSZSG.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.BSSZSG.Location = new System.Drawing.Point(2, 9);
            this.BSSZSG.Name = "BSSZSG";
            this.BSSZSG.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.BSSZSG.Properties.Appearance.Options.UseForeColor = true;
            this.BSSZSG.Properties.Appearance.Options.UseTextOptions = true;
            this.BSSZSG.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.BSSZSG.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.BSSZSG.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.BSSZSG.Properties.MaxValue = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.BSSZSG.Size = new System.Drawing.Size(83, 18);
            this.BSSZSG.TabIndex = 101;
            this.BSSZSG.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // label31
            // 
            this.label31.Dock = System.Windows.Forms.DockStyle.Right;
            this.label31.ForeColor = System.Drawing.Color.Blue;
            this.label31.Location = new System.Drawing.Point(85, 6);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(19, 21);
            this.label31.TabIndex = 0;
            this.label31.Text = "m";
            this.label31.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label70
            // 
            this.label70.Dock = System.Windows.Forms.DockStyle.Left;
            this.label70.Location = new System.Drawing.Point(0, 0);
            this.label70.Name = "label70";
            this.label70.Size = new System.Drawing.Size(80, 29);
            this.label70.TabIndex = 0;
            this.label70.Text = "伴生树种平均高";
            this.label70.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label71
            // 
            this.label71.BackColor = System.Drawing.Color.Black;
            this.label71.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label71.Location = new System.Drawing.Point(0, 29);
            this.label71.Name = "label71";
            this.label71.Size = new System.Drawing.Size(575, 1);
            this.label71.TabIndex = 0;
            this.label71.Text = "label71";
            this.label71.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel69
            // 
            this.panel69.Controls.Add(this.panel70);
            this.panel69.Controls.Add(this.label72);
            this.panel69.Controls.Add(this.panel71);
            this.panel69.Controls.Add(this.label73);
            this.panel69.Controls.Add(this.panel72);
            this.panel69.Controls.Add(this.label74);
            this.panel69.Controls.Add(this.label75);
            this.panel69.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel69.Location = new System.Drawing.Point(0, 0);
            this.panel69.Name = "panel69";
            this.panel69.Size = new System.Drawing.Size(575, 25);
            this.panel69.TabIndex = 0;
            // 
            // panel70
            // 
            this.panel70.Controls.Add(this.BSSZNL);
            this.panel70.Controls.Add(this.label77);
            this.panel70.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel70.Location = new System.Drawing.Point(460, 0);
            this.panel70.Name = "panel70";
            this.panel70.Padding = new System.Windows.Forms.Padding(2, 6, 6, 2);
            this.panel70.Size = new System.Drawing.Size(110, 24);
            this.panel70.TabIndex = 0;
            // 
            // BSSZNL
            // 
            this.BSSZNL.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BSSZNL.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BSSZNL.EditScale = 0;
            this.BSSZNL.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.BSSZNL.Location = new System.Drawing.Point(2, 4);
            this.BSSZNL.Name = "BSSZNL";
            this.BSSZNL.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.BSSZNL.Properties.Appearance.Options.UseForeColor = true;
            this.BSSZNL.Properties.Appearance.Options.UseTextOptions = true;
            this.BSSZNL.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.BSSZNL.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.BSSZNL.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.BSSZNL.Properties.MaxValue = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.BSSZNL.Size = new System.Drawing.Size(83, 18);
            this.BSSZNL.TabIndex = 100;
            this.BSSZNL.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // label77
            // 
            this.label77.Dock = System.Windows.Forms.DockStyle.Right;
            this.label77.ForeColor = System.Drawing.Color.Blue;
            this.label77.Location = new System.Drawing.Point(85, 6);
            this.label77.Name = "label77";
            this.label77.Size = new System.Drawing.Size(19, 16);
            this.label77.TabIndex = 0;
            this.label77.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label72
            // 
            this.label72.Dock = System.Windows.Forms.DockStyle.Left;
            this.label72.Location = new System.Drawing.Point(380, 0);
            this.label72.Name = "label72";
            this.label72.Size = new System.Drawing.Size(80, 24);
            this.label72.TabIndex = 0;
            this.label72.Text = "伴生树种年龄";
            this.label72.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel71
            // 
            this.panel71.Controls.Add(this.BSSZQY);
            this.panel71.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel71.Location = new System.Drawing.Point(270, 0);
            this.panel71.Name = "panel71";
            this.panel71.Padding = new System.Windows.Forms.Padding(2, 4, 4, 0);
            this.panel71.Size = new System.Drawing.Size(110, 24);
            this.panel71.TabIndex = 0;
            // 
            // BSSZQY
            // 
            this.BSSZQY.AssDispValue = true;
            this.BSSZQY.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BSSZQY.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BSSZQY.ForeColor = System.Drawing.Color.Blue;
            this.BSSZQY.Location = new System.Drawing.Point(2, 2);
            this.BSSZQY.Name = "BSSZQY";
            this.BSSZQY.Size = new System.Drawing.Size(104, 22);
            this.BSSZQY.TabIndex = 99;
            this.BSSZQY.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // label73
            // 
            this.label73.Dock = System.Windows.Forms.DockStyle.Left;
            this.label73.Location = new System.Drawing.Point(190, 0);
            this.label73.Name = "label73";
            this.label73.Size = new System.Drawing.Size(80, 24);
            this.label73.TabIndex = 0;
            this.label73.Text = "伴生树种起源";
            this.label73.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel72
            // 
            this.panel72.Controls.Add(this.BSSZ);
            this.panel72.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel72.Location = new System.Drawing.Point(80, 0);
            this.panel72.Name = "panel72";
            this.panel72.Padding = new System.Windows.Forms.Padding(2, 4, 4, 0);
            this.panel72.Size = new System.Drawing.Size(110, 24);
            this.panel72.TabIndex = 0;
            // 
            // BSSZ
            // 
            this.BSSZ.AssDispValue = true;
            this.BSSZ.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BSSZ.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BSSZ.ForeColor = System.Drawing.Color.Blue;
            this.BSSZ.Location = new System.Drawing.Point(2, 2);
            this.BSSZ.Name = "BSSZ";
            this.BSSZ.Size = new System.Drawing.Size(104, 22);
            this.BSSZ.TabIndex = 98;
            this.BSSZ.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // label74
            // 
            this.label74.Dock = System.Windows.Forms.DockStyle.Left;
            this.label74.Location = new System.Drawing.Point(0, 0);
            this.label74.Name = "label74";
            this.label74.Size = new System.Drawing.Size(80, 24);
            this.label74.TabIndex = 0;
            this.label74.Text = "伴生树种名称";
            this.label74.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label75
            // 
            this.label75.BackColor = System.Drawing.Color.Black;
            this.label75.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label75.Location = new System.Drawing.Point(0, 24);
            this.label75.Name = "label75";
            this.label75.Size = new System.Drawing.Size(575, 1);
            this.label75.TabIndex = 0;
            this.label75.Text = "label75";
            this.label75.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label99
            // 
            this.label99.BackColor = System.Drawing.Color.Black;
            this.label99.Dock = System.Windows.Forms.DockStyle.Top;
            this.label99.Location = new System.Drawing.Point(1, 0);
            this.label99.Name = "label99";
            this.label99.Size = new System.Drawing.Size(575, 1);
            this.label99.TabIndex = 0;
            this.label99.Text = "label99";
            this.label99.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label100
            // 
            this.label100.BackColor = System.Drawing.Color.Black;
            this.label100.Dock = System.Windows.Forms.DockStyle.Left;
            this.label100.Location = new System.Drawing.Point(0, 0);
            this.label100.Name = "label100";
            this.label100.Size = new System.Drawing.Size(1, 237);
            this.label100.TabIndex = 0;
            this.label100.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label101
            // 
            this.label101.BackColor = System.Drawing.Color.Black;
            this.label101.Dock = System.Windows.Forms.DockStyle.Right;
            this.label101.Location = new System.Drawing.Point(576, 0);
            this.label101.Name = "label101";
            this.label101.Size = new System.Drawing.Size(1, 237);
            this.label101.TabIndex = 0;
            this.label101.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label38
            // 
            this.label38.Dock = System.Windows.Forms.DockStyle.Top;
            this.label38.Font = new System.Drawing.Font("黑体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label38.Location = new System.Drawing.Point(0, 156);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(577, 30);
            this.label38.TabIndex = 0;
            this.label38.Text = " ";
            this.label38.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelAttr5
            // 
            this.panelAttr5.Controls.Add(this.panelAttr51);
            this.panelAttr5.Controls.Add(this.label123);
            this.panelAttr5.Controls.Add(this.label124);
            this.panelAttr5.Controls.Add(this.label125);
            this.panelAttr5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelAttr5.Location = new System.Drawing.Point(0, 30);
            this.panelAttr5.Name = "panelAttr5";
            this.panelAttr5.Size = new System.Drawing.Size(577, 126);
            this.panelAttr5.TabIndex = 0;
            // 
            // panelAttr51
            // 
            this.panelAttr51.Controls.Add(this.panel163);
            this.panelAttr51.Controls.Add(this.panel160);
            this.panelAttr51.Controls.Add(this.panel157);
            this.panelAttr51.Controls.Add(this.panel105);
            this.panelAttr51.Controls.Add(this.panel109);
            this.panelAttr51.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelAttr51.Location = new System.Drawing.Point(1, 1);
            this.panelAttr51.Name = "panelAttr51";
            this.panelAttr51.Size = new System.Drawing.Size(575, 125);
            this.panelAttr51.TabIndex = 0;
            // 
            // panel163
            // 
            this.panel163.Controls.Add(this.panel187);
            this.panel163.Controls.Add(this.label12);
            this.panel163.Controls.Add(this.panel164);
            this.panel163.Controls.Add(this.label219);
            this.panel163.Controls.Add(this.panel165);
            this.panel163.Controls.Add(this.label220);
            this.panel163.Controls.Add(this.label221);
            this.panel163.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel163.Location = new System.Drawing.Point(0, 100);
            this.panel163.Name = "panel163";
            this.panel163.Size = new System.Drawing.Size(575, 25);
            this.panel163.TabIndex = 0;
            // 
            // panel187
            // 
            this.panel187.Controls.Add(this.JYGLLX);
            this.panel187.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel187.Location = new System.Drawing.Point(460, 0);
            this.panel187.Name = "panel187";
            this.panel187.Padding = new System.Windows.Forms.Padding(2, 4, 4, 0);
            this.panel187.Size = new System.Drawing.Size(110, 24);
            this.panel187.TabIndex = 0;
            // 
            // JYGLLX
            // 
            this.JYGLLX.AssDispValue = true;
            this.JYGLLX.Cursor = System.Windows.Forms.Cursors.Hand;
            this.JYGLLX.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.JYGLLX.ForeColor = System.Drawing.Color.Blue;
            this.JYGLLX.Location = new System.Drawing.Point(2, 2);
            this.JYGLLX.Name = "JYGLLX";
            this.JYGLLX.Size = new System.Drawing.Size(104, 22);
            this.JYGLLX.TabIndex = 85;
            // 
            // label12
            // 
            this.label12.Dock = System.Windows.Forms.DockStyle.Left;
            this.label12.Location = new System.Drawing.Point(380, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(80, 24);
            this.label12.TabIndex = 0;
            this.label12.Text = "经营管理类型";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel164
            // 
            this.panel164.Controls.Add(this.YXMJ);
            this.panel164.Controls.Add(this.label27);
            this.panel164.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel164.Location = new System.Drawing.Point(270, 0);
            this.panel164.Name = "panel164";
            this.panel164.Padding = new System.Windows.Forms.Padding(2, 6, 6, 2);
            this.panel164.Size = new System.Drawing.Size(110, 24);
            this.panel164.TabIndex = 0;
            // 
            // YXMJ
            // 
            this.YXMJ.Cursor = System.Windows.Forms.Cursors.Hand;
            this.YXMJ.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.YXMJ.EditScale = 0;
            this.YXMJ.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.YXMJ.Location = new System.Drawing.Point(2, 4);
            this.YXMJ.Name = "YXMJ";
            this.YXMJ.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.YXMJ.Properties.Appearance.Options.UseForeColor = true;
            this.YXMJ.Properties.Appearance.Options.UseTextOptions = true;
            this.YXMJ.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.YXMJ.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.YXMJ.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.YXMJ.Properties.MaxValue = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.YXMJ.Size = new System.Drawing.Size(68, 18);
            this.YXMJ.TabIndex = 97;
            this.YXMJ.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // label27
            // 
            this.label27.Dock = System.Windows.Forms.DockStyle.Right;
            this.label27.ForeColor = System.Drawing.Color.Blue;
            this.label27.Location = new System.Drawing.Point(70, 6);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(34, 16);
            this.label27.TabIndex = 0;
            this.label27.Text = "公顷";
            this.label27.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label219
            // 
            this.label219.Dock = System.Windows.Forms.DockStyle.Left;
            this.label219.Location = new System.Drawing.Point(190, 0);
            this.label219.Name = "label219";
            this.label219.Size = new System.Drawing.Size(80, 24);
            this.label219.TabIndex = 0;
            this.label219.Text = "有效面积";
            this.label219.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel165
            // 
            this.panel165.Controls.Add(this.XZWMJ);
            this.panel165.Controls.Add(this.label13);
            this.panel165.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel165.Location = new System.Drawing.Point(80, 0);
            this.panel165.Name = "panel165";
            this.panel165.Padding = new System.Windows.Forms.Padding(2, 6, 6, 2);
            this.panel165.Size = new System.Drawing.Size(110, 24);
            this.panel165.TabIndex = 0;
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
            10000,
            0,
            0,
            0});
            this.XZWMJ.Size = new System.Drawing.Size(69, 18);
            this.XZWMJ.TabIndex = 96;
            this.XZWMJ.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // label13
            // 
            this.label13.Dock = System.Windows.Forms.DockStyle.Right;
            this.label13.ForeColor = System.Drawing.Color.Blue;
            this.label13.Location = new System.Drawing.Point(71, 6);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(33, 16);
            this.label13.TabIndex = 0;
            this.label13.Text = "公顷";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label220
            // 
            this.label220.Dock = System.Windows.Forms.DockStyle.Left;
            this.label220.Location = new System.Drawing.Point(0, 0);
            this.label220.Name = "label220";
            this.label220.Size = new System.Drawing.Size(80, 24);
            this.label220.TabIndex = 0;
            this.label220.Text = "线状物面积";
            this.label220.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label221
            // 
            this.label221.BackColor = System.Drawing.Color.Black;
            this.label221.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label221.Location = new System.Drawing.Point(0, 24);
            this.label221.Name = "label221";
            this.label221.Size = new System.Drawing.Size(575, 1);
            this.label221.TabIndex = 0;
            this.label221.Text = "label221";
            this.label221.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel160
            // 
            this.panel160.Controls.Add(this.panel31);
            this.panel160.Controls.Add(this.label214);
            this.panel160.Controls.Add(this.panel161);
            this.panel160.Controls.Add(this.label215);
            this.panel160.Controls.Add(this.panel162);
            this.panel160.Controls.Add(this.label216);
            this.panel160.Controls.Add(this.label217);
            this.panel160.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel160.Location = new System.Drawing.Point(0, 75);
            this.panel160.Name = "panel160";
            this.panel160.Size = new System.Drawing.Size(575, 25);
            this.panel160.TabIndex = 0;
            // 
            // panel31
            // 
            this.panel31.Controls.Add(this.XZWKD);
            this.panel31.Controls.Add(this.label9);
            this.panel31.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel31.Location = new System.Drawing.Point(460, 0);
            this.panel31.Name = "panel31";
            this.panel31.Padding = new System.Windows.Forms.Padding(2, 6, 6, 2);
            this.panel31.Size = new System.Drawing.Size(110, 24);
            this.panel31.TabIndex = 0;
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
            10000,
            0,
            0,
            0});
            this.XZWKD.Size = new System.Drawing.Size(83, 18);
            this.XZWKD.TabIndex = 95;
            this.XZWKD.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // label9
            // 
            this.label9.Dock = System.Windows.Forms.DockStyle.Right;
            this.label9.ForeColor = System.Drawing.Color.Blue;
            this.label9.Location = new System.Drawing.Point(85, 6);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(19, 16);
            this.label9.TabIndex = 0;
            this.label9.Text = "m";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label214
            // 
            this.label214.Dock = System.Windows.Forms.DockStyle.Left;
            this.label214.Location = new System.Drawing.Point(380, 0);
            this.label214.Name = "label214";
            this.label214.Size = new System.Drawing.Size(80, 24);
            this.label214.TabIndex = 0;
            this.label214.Text = "线状物宽度";
            this.label214.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel161
            // 
            this.panel161.Controls.Add(this.XZWCD);
            this.panel161.Controls.Add(this.label10);
            this.panel161.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel161.Location = new System.Drawing.Point(270, 0);
            this.panel161.Name = "panel161";
            this.panel161.Padding = new System.Windows.Forms.Padding(2, 6, 6, 2);
            this.panel161.Size = new System.Drawing.Size(110, 24);
            this.panel161.TabIndex = 0;
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
            10000,
            0,
            0,
            0});
            this.XZWCD.Size = new System.Drawing.Size(83, 18);
            this.XZWCD.TabIndex = 94;
            this.XZWCD.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // label10
            // 
            this.label10.Dock = System.Windows.Forms.DockStyle.Right;
            this.label10.ForeColor = System.Drawing.Color.Blue;
            this.label10.Location = new System.Drawing.Point(85, 6);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(19, 16);
            this.label10.TabIndex = 0;
            this.label10.Text = "m";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label215
            // 
            this.label215.Dock = System.Windows.Forms.DockStyle.Left;
            this.label215.Location = new System.Drawing.Point(190, 0);
            this.label215.Name = "label215";
            this.label215.Size = new System.Drawing.Size(80, 24);
            this.label215.TabIndex = 0;
            this.label215.Text = "线状物长度";
            this.label215.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel162
            // 
            this.panel162.Controls.Add(this.XZWZL);
            this.panel162.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel162.Location = new System.Drawing.Point(80, 0);
            this.panel162.Name = "panel162";
            this.panel162.Padding = new System.Windows.Forms.Padding(2, 4, 4, 0);
            this.panel162.Size = new System.Drawing.Size(110, 24);
            this.panel162.TabIndex = 0;
            // 
            // XZWZL
            // 
            this.XZWZL.AssDispValue = true;
            this.XZWZL.Cursor = System.Windows.Forms.Cursors.Hand;
            this.XZWZL.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.XZWZL.ForeColor = System.Drawing.Color.Blue;
            this.XZWZL.Location = new System.Drawing.Point(2, 2);
            this.XZWZL.Name = "XZWZL";
            this.XZWZL.Size = new System.Drawing.Size(104, 22);
            this.XZWZL.TabIndex = 93;
            this.XZWZL.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // label216
            // 
            this.label216.Dock = System.Windows.Forms.DockStyle.Left;
            this.label216.Location = new System.Drawing.Point(0, 0);
            this.label216.Name = "label216";
            this.label216.Size = new System.Drawing.Size(80, 24);
            this.label216.TabIndex = 0;
            this.label216.Text = "线状物类型";
            this.label216.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label217
            // 
            this.label217.BackColor = System.Drawing.Color.Black;
            this.label217.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label217.Location = new System.Drawing.Point(0, 24);
            this.label217.Name = "label217";
            this.label217.Size = new System.Drawing.Size(575, 1);
            this.label217.TabIndex = 0;
            this.label217.Text = "label217";
            this.label217.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel157
            // 
            this.panel157.Controls.Add(this.panel30);
            this.panel157.Controls.Add(this.label210);
            this.panel157.Controls.Add(this.panel158);
            this.panel157.Controls.Add(this.label211);
            this.panel157.Controls.Add(this.panel159);
            this.panel157.Controls.Add(this.label212);
            this.panel157.Controls.Add(this.label213);
            this.panel157.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel157.Location = new System.Drawing.Point(0, 50);
            this.panel157.Name = "panel157";
            this.panel157.Size = new System.Drawing.Size(575, 25);
            this.panel157.TabIndex = 0;
            // 
            // panel30
            // 
            this.panel30.Controls.Add(this.FRZLDW);
            this.panel30.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel30.Location = new System.Drawing.Point(460, 0);
            this.panel30.Name = "panel30";
            this.panel30.Padding = new System.Windows.Forms.Padding(2, 6, 6, 2);
            this.panel30.Size = new System.Drawing.Size(110, 24);
            this.panel30.TabIndex = 0;
            // 
            // FRZLDW
            // 
            this.FRZLDW.Cursor = System.Windows.Forms.Cursors.Hand;
            this.FRZLDW.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.FRZLDW.EditScale = 0;
            this.FRZLDW.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.FRZLDW.Location = new System.Drawing.Point(2, 4);
            this.FRZLDW.Name = "FRZLDW";
            this.FRZLDW.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.FRZLDW.Properties.Appearance.Options.UseForeColor = true;
            this.FRZLDW.Properties.Appearance.Options.UseTextOptions = true;
            this.FRZLDW.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.FRZLDW.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.FRZLDW.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.FRZLDW.Properties.MaxValue = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.FRZLDW.Size = new System.Drawing.Size(102, 18);
            this.FRZLDW.TabIndex = 92;
            this.FRZLDW.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // label210
            // 
            this.label210.Dock = System.Windows.Forms.DockStyle.Left;
            this.label210.Location = new System.Drawing.Point(380, 0);
            this.label210.Name = "label210";
            this.label210.Size = new System.Drawing.Size(80, 24);
            this.label210.TabIndex = 0;
            this.label210.Text = "法人造林单位";
            this.label210.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel158
            // 
            this.panel158.Controls.Add(this.LDSYDW);
            this.panel158.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel158.Location = new System.Drawing.Point(270, 0);
            this.panel158.Name = "panel158";
            this.panel158.Padding = new System.Windows.Forms.Padding(2, 6, 6, 2);
            this.panel158.Size = new System.Drawing.Size(110, 24);
            this.panel158.TabIndex = 0;
            // 
            // LDSYDW
            // 
            this.LDSYDW.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LDSYDW.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.LDSYDW.EditScale = 0;
            this.LDSYDW.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.LDSYDW.Location = new System.Drawing.Point(2, 4);
            this.LDSYDW.Name = "LDSYDW";
            this.LDSYDW.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.LDSYDW.Properties.Appearance.Options.UseForeColor = true;
            this.LDSYDW.Properties.Appearance.Options.UseTextOptions = true;
            this.LDSYDW.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.LDSYDW.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.LDSYDW.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.LDSYDW.Properties.MaxValue = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.LDSYDW.Size = new System.Drawing.Size(102, 18);
            this.LDSYDW.TabIndex = 91;
            this.LDSYDW.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // label211
            // 
            this.label211.Dock = System.Windows.Forms.DockStyle.Left;
            this.label211.Location = new System.Drawing.Point(190, 0);
            this.label211.Name = "label211";
            this.label211.Size = new System.Drawing.Size(80, 24);
            this.label211.TabIndex = 0;
            this.label211.Text = "林地所有单位";
            this.label211.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel159
            // 
            this.panel159.Controls.Add(this.QHFQBH);
            this.panel159.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel159.Location = new System.Drawing.Point(106, 0);
            this.panel159.Name = "panel159";
            this.panel159.Padding = new System.Windows.Forms.Padding(2, 6, 8, 0);
            this.panel159.Size = new System.Drawing.Size(84, 24);
            this.panel159.TabIndex = 0;
            // 
            // QHFQBH
            // 
            this.QHFQBH.AssDispValue = true;
            this.QHFQBH.Cursor = System.Windows.Forms.Cursors.Hand;
            this.QHFQBH.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.QHFQBH.ForeColor = System.Drawing.Color.Blue;
            this.QHFQBH.Location = new System.Drawing.Point(2, 2);
            this.QHFQBH.Name = "QHFQBH";
            this.QHFQBH.Size = new System.Drawing.Size(74, 22);
            this.QHFQBH.TabIndex = 90;
            this.QHFQBH.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // label212
            // 
            this.label212.Dock = System.Windows.Forms.DockStyle.Left;
            this.label212.Location = new System.Drawing.Point(0, 0);
            this.label212.Name = "label212";
            this.label212.Size = new System.Drawing.Size(106, 24);
            this.label212.TabIndex = 0;
            this.label212.Text = "林业区划分区编号";
            this.label212.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label213
            // 
            this.label213.BackColor = System.Drawing.Color.Black;
            this.label213.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label213.Location = new System.Drawing.Point(0, 24);
            this.label213.Name = "label213";
            this.label213.Size = new System.Drawing.Size(575, 1);
            this.label213.TabIndex = 0;
            this.label213.Text = "label213";
            this.label213.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel105
            // 
            this.panel105.Controls.Add(this.panel24);
            this.panel105.Controls.Add(this.label209);
            this.panel105.Controls.Add(this.panel107);
            this.panel105.Controls.Add(this.label116);
            this.panel105.Controls.Add(this.panel108);
            this.panel105.Controls.Add(this.label117);
            this.panel105.Controls.Add(this.label118);
            this.panel105.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel105.Location = new System.Drawing.Point(0, 25);
            this.panel105.Name = "panel105";
            this.panel105.Size = new System.Drawing.Size(575, 25);
            this.panel105.TabIndex = 0;
            // 
            // panel24
            // 
            this.panel24.Controls.Add(this.XJBDJ);
            this.panel24.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel24.Location = new System.Drawing.Point(483, 0);
            this.panel24.Name = "panel24";
            this.panel24.Padding = new System.Windows.Forms.Padding(2, 4, 4, 0);
            this.panel24.Size = new System.Drawing.Size(87, 24);
            this.panel24.TabIndex = 0;
            // 
            // XJBDJ
            // 
            this.XJBDJ.AssDispValue = true;
            this.XJBDJ.Cursor = System.Windows.Forms.Cursors.Hand;
            this.XJBDJ.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.XJBDJ.ForeColor = System.Drawing.Color.Blue;
            this.XJBDJ.Location = new System.Drawing.Point(2, 2);
            this.XJBDJ.Name = "XJBDJ";
            this.XJBDJ.Size = new System.Drawing.Size(81, 22);
            this.XJBDJ.TabIndex = 89;
            this.XJBDJ.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // label209
            // 
            this.label209.Dock = System.Windows.Forms.DockStyle.Left;
            this.label209.Location = new System.Drawing.Point(380, 0);
            this.label209.Name = "label209";
            this.label209.Size = new System.Drawing.Size(103, 24);
            this.label209.TabIndex = 0;
            this.label209.Text = "大径木蓄积比等级";
            this.label209.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel107
            // 
            this.panel107.Controls.Add(this.CCLDJ);
            this.panel107.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel107.Location = new System.Drawing.Point(270, 0);
            this.panel107.Name = "panel107";
            this.panel107.Padding = new System.Windows.Forms.Padding(2, 4, 4, 0);
            this.panel107.Size = new System.Drawing.Size(110, 24);
            this.panel107.TabIndex = 0;
            // 
            // CCLDJ
            // 
            this.CCLDJ.AssDispValue = true;
            this.CCLDJ.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CCLDJ.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.CCLDJ.ForeColor = System.Drawing.Color.Blue;
            this.CCLDJ.Location = new System.Drawing.Point(2, 2);
            this.CCLDJ.Name = "CCLDJ";
            this.CCLDJ.Size = new System.Drawing.Size(104, 22);
            this.CCLDJ.TabIndex = 88;
            this.CCLDJ.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // label116
            // 
            this.label116.Dock = System.Windows.Forms.DockStyle.Left;
            this.label116.Location = new System.Drawing.Point(190, 0);
            this.label116.Name = "label116";
            this.label116.Size = new System.Drawing.Size(80, 24);
            this.label116.TabIndex = 0;
            this.label116.Text = "出材率等级";
            this.label116.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel108
            // 
            this.panel108.Controls.Add(this.JJLCQ);
            this.panel108.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel108.Location = new System.Drawing.Point(80, 0);
            this.panel108.Name = "panel108";
            this.panel108.Padding = new System.Windows.Forms.Padding(2, 4, 4, 0);
            this.panel108.Size = new System.Drawing.Size(110, 24);
            this.panel108.TabIndex = 0;
            // 
            // JJLCQ
            // 
            this.JJLCQ.AssDispValue = true;
            this.JJLCQ.Cursor = System.Windows.Forms.Cursors.Hand;
            this.JJLCQ.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.JJLCQ.ForeColor = System.Drawing.Color.Blue;
            this.JJLCQ.Location = new System.Drawing.Point(2, 2);
            this.JJLCQ.Name = "JJLCQ";
            this.JJLCQ.Size = new System.Drawing.Size(104, 22);
            this.JJLCQ.TabIndex = 87;
            this.JJLCQ.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // label117
            // 
            this.label117.Dock = System.Windows.Forms.DockStyle.Left;
            this.label117.Location = new System.Drawing.Point(0, 0);
            this.label117.Name = "label117";
            this.label117.Size = new System.Drawing.Size(80, 24);
            this.label117.TabIndex = 0;
            this.label117.Text = "经济林产期";
            this.label117.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label118
            // 
            this.label118.BackColor = System.Drawing.Color.Black;
            this.label118.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label118.Location = new System.Drawing.Point(0, 24);
            this.label118.Name = "label118";
            this.label118.Size = new System.Drawing.Size(575, 1);
            this.label118.TabIndex = 0;
            this.label118.Text = "label118";
            this.label118.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel109
            // 
            this.panel109.Controls.Add(this.panel110);
            this.panel109.Controls.Add(this.label119);
            this.panel109.Controls.Add(this.panel111);
            this.panel109.Controls.Add(this.label120);
            this.panel109.Controls.Add(this.panel112);
            this.panel109.Controls.Add(this.label121);
            this.panel109.Controls.Add(this.label122);
            this.panel109.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel109.Location = new System.Drawing.Point(0, 0);
            this.panel109.Name = "panel109";
            this.panel109.Size = new System.Drawing.Size(575, 25);
            this.panel109.TabIndex = 0;
            // 
            // panel110
            // 
            this.panel110.Controls.Add(this.YSMG);
            this.panel110.Controls.Add(this.label143);
            this.panel110.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel110.Location = new System.Drawing.Point(460, 0);
            this.panel110.Name = "panel110";
            this.panel110.Padding = new System.Windows.Forms.Padding(2, 6, 6, 2);
            this.panel110.Size = new System.Drawing.Size(110, 24);
            this.panel110.TabIndex = 0;
            // 
            // YSMG
            // 
            this.YSMG.Cursor = System.Windows.Forms.Cursors.Hand;
            this.YSMG.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.YSMG.EditScale = 0;
            this.YSMG.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.YSMG.Location = new System.Drawing.Point(2, 4);
            this.YSMG.Name = "YSMG";
            this.YSMG.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.YSMG.Properties.Appearance.Options.UseForeColor = true;
            this.YSMG.Properties.Appearance.Options.UseTextOptions = true;
            this.YSMG.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.YSMG.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.YSMG.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.YSMG.Properties.MaxValue = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.YSMG.Size = new System.Drawing.Size(83, 18);
            this.YSMG.TabIndex = 86;
            this.YSMG.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // label143
            // 
            this.label143.Dock = System.Windows.Forms.DockStyle.Right;
            this.label143.ForeColor = System.Drawing.Color.Blue;
            this.label143.Location = new System.Drawing.Point(85, 6);
            this.label143.Name = "label143";
            this.label143.Size = new System.Drawing.Size(19, 16);
            this.label143.TabIndex = 0;
            this.label143.Text = "m";
            this.label143.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label119
            // 
            this.label119.Dock = System.Windows.Forms.DockStyle.Left;
            this.label119.Location = new System.Drawing.Point(380, 0);
            this.label119.Name = "label119";
            this.label119.Size = new System.Drawing.Size(80, 24);
            this.label119.TabIndex = 0;
            this.label119.Text = "优势木高";
            this.label119.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel111
            // 
            this.panel111.Controls.Add(this.JYCSLX);
            this.panel111.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel111.Location = new System.Drawing.Point(270, 0);
            this.panel111.Name = "panel111";
            this.panel111.Padding = new System.Windows.Forms.Padding(2, 4, 4, 0);
            this.panel111.Size = new System.Drawing.Size(110, 24);
            this.panel111.TabIndex = 0;
            // 
            // JYCSLX
            // 
            this.JYCSLX.AssDispValue = true;
            this.JYCSLX.Cursor = System.Windows.Forms.Cursors.Hand;
            this.JYCSLX.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.JYCSLX.ForeColor = System.Drawing.Color.Blue;
            this.JYCSLX.Location = new System.Drawing.Point(2, 2);
            this.JYCSLX.Name = "JYCSLX";
            this.JYCSLX.Size = new System.Drawing.Size(104, 22);
            this.JYCSLX.TabIndex = 85;
            this.JYCSLX.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // label120
            // 
            this.label120.Dock = System.Windows.Forms.DockStyle.Left;
            this.label120.Location = new System.Drawing.Point(190, 0);
            this.label120.Name = "label120";
            this.label120.Size = new System.Drawing.Size(80, 24);
            this.label120.TabIndex = 0;
            this.label120.Text = "经营措施类型";
            this.label120.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel112
            // 
            this.panel112.Controls.Add(this.JYLX);
            this.panel112.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel112.Location = new System.Drawing.Point(80, 0);
            this.panel112.Name = "panel112";
            this.panel112.Padding = new System.Windows.Forms.Padding(2, 6, 8, 0);
            this.panel112.Size = new System.Drawing.Size(110, 24);
            this.panel112.TabIndex = 0;
            // 
            // JYLX
            // 
            this.JYLX.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.JYLX.EditValue = "";
            this.JYLX.Location = new System.Drawing.Point(2, 8);
            this.JYLX.Name = "JYLX";
            this.JYLX.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.JYLX.Properties.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.JYLX.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.JYLX.Properties.Appearance.Options.UseBackColor = true;
            this.JYLX.Properties.Appearance.Options.UseFont = true;
            this.JYLX.Properties.Appearance.Options.UseForeColor = true;
            this.JYLX.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.JYLX.Size = new System.Drawing.Size(100, 16);
            this.JYLX.TabIndex = 84;
            // 
            // label121
            // 
            this.label121.Dock = System.Windows.Forms.DockStyle.Left;
            this.label121.Location = new System.Drawing.Point(0, 0);
            this.label121.Name = "label121";
            this.label121.Size = new System.Drawing.Size(80, 24);
            this.label121.TabIndex = 0;
            this.label121.Text = "经营类型";
            this.label121.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label122
            // 
            this.label122.BackColor = System.Drawing.Color.Black;
            this.label122.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label122.Location = new System.Drawing.Point(0, 24);
            this.label122.Name = "label122";
            this.label122.Size = new System.Drawing.Size(575, 1);
            this.label122.TabIndex = 0;
            this.label122.Text = "label122";
            this.label122.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label123
            // 
            this.label123.BackColor = System.Drawing.Color.Black;
            this.label123.Dock = System.Windows.Forms.DockStyle.Top;
            this.label123.Location = new System.Drawing.Point(1, 0);
            this.label123.Name = "label123";
            this.label123.Size = new System.Drawing.Size(575, 1);
            this.label123.TabIndex = 0;
            this.label123.Text = "label123";
            this.label123.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label124
            // 
            this.label124.BackColor = System.Drawing.Color.Black;
            this.label124.Dock = System.Windows.Forms.DockStyle.Left;
            this.label124.Location = new System.Drawing.Point(0, 0);
            this.label124.Name = "label124";
            this.label124.Size = new System.Drawing.Size(1, 126);
            this.label124.TabIndex = 0;
            this.label124.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label125
            // 
            this.label125.BackColor = System.Drawing.Color.Black;
            this.label125.Dock = System.Windows.Forms.DockStyle.Right;
            this.label125.Location = new System.Drawing.Point(576, 0);
            this.label125.Name = "label125";
            this.label125.Size = new System.Drawing.Size(1, 126);
            this.label125.TabIndex = 0;
            this.label125.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelAttr6
            // 
            this.labelAttr6.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelAttr6.Font = new System.Drawing.Font("黑体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelAttr6.Location = new System.Drawing.Point(0, 0);
            this.labelAttr6.Name = "labelAttr6";
            this.labelAttr6.Size = new System.Drawing.Size(577, 30);
            this.labelAttr6.TabIndex = 0;
            this.labelAttr6.Text = " ";
            this.labelAttr6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Black;
            this.label5.Dock = System.Windows.Forms.DockStyle.Right;
            this.label5.Location = new System.Drawing.Point(529, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(1, 29);
            this.label5.TabIndex = 0;
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelAll
            // 
            this.panelAll.BackColor = System.Drawing.Color.White;
            this.panelAll.Controls.Add(this.panelRight);
            this.panelAll.Controls.Add(this.panelLeft);
            this.panelAll.Controls.Add(this.xtraTabControl1);
            this.panelAll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelAll.Location = new System.Drawing.Point(0, 0);
            this.panelAll.Name = "panelAll";
            this.panelAll.Size = new System.Drawing.Size(585, 623);
            this.panelAll.TabIndex = 0;
            // 
            // panelRight
            // 
            this.panelRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelRight.Location = new System.Drawing.Point(582, 0);
            this.panelRight.Name = "panelRight";
            this.panelRight.Size = new System.Drawing.Size(3, 623);
            this.panelRight.TabIndex = 0;
            // 
            // panelLeft
            // 
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeft.Location = new System.Drawing.Point(0, 0);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(1, 623);
            this.panelLeft.TabIndex = 0;
            // 
            // UserControlSubAttr
            // 
            this.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.Appearance.BackColor2 = System.Drawing.Color.Transparent;
            this.Appearance.Options.UseBackColor = true;
            this.Controls.Add(this.panelAll);
            this.Name = "UserControlSubAttr";
            this.Size = new System.Drawing.Size(585, 623);
            this.xtraTabControl1.ResumeLayout(false);
            this.xtraTabPage1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panelAttr8.ResumeLayout(false);
            this.panelAttr81.ResumeLayout(false);
            this.panel62.ResumeLayout(false);
            this.panel178.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Q_SSXJ.Properties)).EndInit();
            this.panel177.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Q_BSSZXJ.Properties)).EndInit();
            this.panel175.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Q_BSSZGQDM.Properties)).EndInit();
            this.panel58.ResumeLayout(false);
            this.panel173.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Q_BSSZPJXJ.Properties)).EndInit();
            this.panel59.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Q_BSSZSG.Properties)).EndInit();
            this.panel61.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Q_BSSZNL.Properties)).EndInit();
            this.panel182.ResumeLayout(false);
            this.panel176.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Q_YSSZXJ.Properties)).EndInit();
            this.panel179.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Q_ZXJ.Properties)).EndInit();
            this.panel183.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Q_PJDM.Properties)).EndInit();
            this.panel186.ResumeLayout(false);
            this.panel184.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Q_PJSG.Properties)).EndInit();
            this.panel185.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Q_PJXJ.Properties)).EndInit();
            this.panel189.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Q_PJNL.Properties)).EndInit();
            this.panel206.ResumeLayout(false);
            this.panel191.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Q_YBD.Properties)).EndInit();
            this.panel192.ResumeLayout(false);
            this.panel209.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Q_MJ.Properties)).EndInit();
            this.panelAttr7.ResumeLayout(false);
            this.panelAttr71.ResumeLayout(false);
            this.panel171.ResumeLayout(false);
            this.panel168.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.BSSZXJ.Properties)).EndInit();
            this.panel174.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SSXJ.Properties)).EndInit();
            this.panel167.ResumeLayout(false);
            this.panel169.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.YSSZXJ.Properties)).EndInit();
            this.panel170.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SLXJ.Properties)).EndInit();
            this.panel121.ResumeLayout(false);
            this.panel122.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ZXJ.Properties)).EndInit();
            this.panel123.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MEI_GQ_ZS.Properties)).EndInit();
            this.panel124.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.HUO_LMGQXJ.Properties)).EndInit();
            this.panel117.ResumeLayout(false);
            this.panel118.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PINGJUN_DM.Properties)).EndInit();
            this.panel119.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PINGJUN_SG.Properties)).EndInit();
            this.panel120.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PINGJUN_XJ.Properties)).EndInit();
            this.panel78.ResumeLayout(false);
            this.panel104.ResumeLayout(false);
            this.panel106.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.LJ.Properties)).EndInit();
            this.panel116.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PINGJUN_NL.Properties)).EndInit();
            this.panel50.ResumeLayout(false);
            this.panel56.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.YU_BI_DU.Properties)).EndInit();
            this.panel74.ResumeLayout(false);
            this.panel75.ResumeLayout(false);
            this.panel130.ResumeLayout(false);
            this.panel131.ResumeLayout(false);
            this.panel132.ResumeLayout(false);
            this.panel133.ResumeLayout(false);
            this.panel134.ResumeLayout(false);
            this.panel135.ResumeLayout(false);
            this.panel136.ResumeLayout(false);
            this.panel137.ResumeLayout(false);
            this.panel138.ResumeLayout(false);
            this.panel139.ResumeLayout(false);
            this.panel140.ResumeLayout(false);
            this.panel141.ResumeLayout(false);
            this.panel142.ResumeLayout(false);
            this.panel143.ResumeLayout(false);
            this.panel144.ResumeLayout(false);
            this.panel145.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MIAN_JI.Properties)).EndInit();
            this.panelAttr2.ResumeLayout(false);
            this.panelAttr21.ResumeLayout(false);
            this.panel23.ResumeLayout(false);
            this.panel28.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.BHND.Properties)).EndInit();
            this.panel25.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GXSJ.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GXSJ.Properties)).EndInit();
            this.panel26.ResumeLayout(false);
            this.panelAttr1.ResumeLayout(false);
            this.panelAttr11.ResumeLayout(false);
            this.panel19.ResumeLayout(false);
            this.panel166.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.XI_BAN.Properties)).EndInit();
            this.panel43.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.XIAO_BAN.Properties)).EndInit();
            this.panel20.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.LIN_BAN.Properties)).EndInit();
            this.panel21.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.LIN_CHANG.Properties)).EndInit();
            this.panel12.ResumeLayout(false);
            this.panel49.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.LIN_YE_JU.Properties)).EndInit();
            this.panel16.ResumeLayout(false);
            this.panel18.ResumeLayout(false);
            this.panel13.ResumeLayout(false);
            this.panel115.ResumeLayout(false);
            this.panel53.ResumeLayout(false);
            this.panel15.ResumeLayout(false);
            this.panelTop.ResumeLayout(false);
            this.xtraTabPage2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panelAttr4.ResumeLayout(false);
            this.panelAttr41.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel22.ResumeLayout(false);
            this.panel11.ResumeLayout(false);
            this.panel17.ResumeLayout(false);
            this.panel151.ResumeLayout(false);
            this.panel10.ResumeLayout(false);
            this.panel152.ResumeLayout(false);
            this.panel153.ResumeLayout(false);
            this.panel148.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.panel149.ResumeLayout(false);
            this.panel150.ResumeLayout(false);
            this.panel129.ResumeLayout(false);
            this.panel29.ResumeLayout(false);
            this.panel146.ResumeLayout(false);
            this.panel147.ResumeLayout(false);
            this.panel73.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.FZCH.Properties)).EndInit();
            this.panel76.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SLHL.Properties)).EndInit();
            this.panel77.ResumeLayout(false);
            this.panel79.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.KZLYH.Properties)).EndInit();
            this.panel80.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TU_CENG_HD.Properties)).EndInit();
            this.panel81.ResumeLayout(false);
            this.panel82.ResumeLayout(false);
            this.panel83.ResumeLayout(false);
            this.panel84.ResumeLayout(false);
            this.panel85.ResumeLayout(false);
            this.panel86.ResumeLayout(false);
            this.panel87.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.HBG.Properties)).EndInit();
            this.panel88.ResumeLayout(false);
            this.panelAttr3.ResumeLayout(false);
            this.panelAttr31.ResumeLayout(false);
            this.panel34.ResumeLayout(false);
            this.panel180.ResumeLayout(false);
            this.panel172.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ZFNL.Properties)).EndInit();
            this.panel52.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ZLND.Properties)).EndInit();
            this.panel125.ResumeLayout(false);
            this.panel126.ResumeLayout(false);
            this.panel127.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.LD_CD.Properties)).EndInit();
            this.panel128.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.LD_KD.Properties)).EndInit();
            this.panel35.ResumeLayout(false);
            this.panel36.ResumeLayout(false);
            this.panel37.ResumeLayout(false);
            this.panel188.ResumeLayout(false);
            this.panel39.ResumeLayout(false);
            this.panel40.ResumeLayout(false);
            this.panel38.ResumeLayout(false);
            this.panel42.ResumeLayout(false);
            this.panel41.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel44.ResumeLayout(false);
            this.panel46.ResumeLayout(false);
            this.panel57.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel60.ResumeLayout(false);
            this.panel51.ResumeLayout(false);
            this.panel181.ResumeLayout(false);
            this.panel54.ResumeLayout(false);
            this.panel55.ResumeLayout(false);
            this.panel45.ResumeLayout(false);
            this.panel47.ResumeLayout(false);
            this.panel48.ResumeLayout(false);
            this.xtraTabPage3.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panelAttr6.ResumeLayout(false);
            this.panelAttr61.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel27.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Remarks.Properties)).EndInit();
            this.panel154.ResumeLayout(false);
            this.panel33.ResumeLayout(false);
            this.panel155.ResumeLayout(false);
            this.panel156.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GXGQZS.Properties)).EndInit();
            this.panel103.ResumeLayout(false);
            this.panel32.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GXPJGD.Properties)).EndInit();
            this.panel113.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GXPJNL.Properties)).EndInit();
            this.panel114.ResumeLayout(false);
            this.panel99.ResumeLayout(false);
            this.panel100.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CMZGD.Properties)).EndInit();
            this.panel101.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CBPJGD.Properties)).EndInit();
            this.panel102.ResumeLayout(false);
            this.panel95.ResumeLayout(false);
            this.panel96.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GMZGD.Properties)).EndInit();
            this.panel97.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GMPJGD.Properties)).EndInit();
            this.panel98.ResumeLayout(false);
            this.panel91.ResumeLayout(false);
            this.panel92.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SSPJGD.Properties)).EndInit();
            this.panel93.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SSPJXJ.Properties)).EndInit();
            this.panel94.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SSZZS.Properties)).EndInit();
            this.panel63.ResumeLayout(false);
            this.panel64.ResumeLayout(false);
            this.panel89.ResumeLayout(false);
            this.panel90.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.BSSZGQZS.Properties)).EndInit();
            this.panel65.ResumeLayout(false);
            this.panel66.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.BSSZGQDM.Properties)).EndInit();
            this.panel67.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.BSSZPJXJ.Properties)).EndInit();
            this.panel68.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.BSSZSG.Properties)).EndInit();
            this.panel69.ResumeLayout(false);
            this.panel70.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.BSSZNL.Properties)).EndInit();
            this.panel71.ResumeLayout(false);
            this.panel72.ResumeLayout(false);
            this.panelAttr5.ResumeLayout(false);
            this.panelAttr51.ResumeLayout(false);
            this.panel163.ResumeLayout(false);
            this.panel187.ResumeLayout(false);
            this.panel164.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.YXMJ.Properties)).EndInit();
            this.panel165.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.XZWMJ.Properties)).EndInit();
            this.panel160.ResumeLayout(false);
            this.panel31.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.XZWKD.Properties)).EndInit();
            this.panel161.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.XZWCD.Properties)).EndInit();
            this.panel162.ResumeLayout(false);
            this.panel157.ResumeLayout(false);
            this.panel30.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.FRZLDW.Properties)).EndInit();
            this.panel158.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.LDSYDW.Properties)).EndInit();
            this.panel159.ResumeLayout(false);
            this.panel105.ResumeLayout(false);
            this.panel24.ResumeLayout(false);
            this.panel107.ResumeLayout(false);
            this.panel108.ResumeLayout(false);
            this.panel109.ResumeLayout(false);
            this.panel110.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.YSMG.Properties)).EndInit();
            this.panel111.ResumeLayout(false);
            this.panel112.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.JYLX.Properties)).EndInit();
            this.panelAll.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private void ReadValue()
        {
            try
            {
                if (this.mPoint != null)
                {
                    this.OnGetAttributes(this.mPoint, this.mType);
                }
            }
            catch (Exception)
            {
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

        public bool IsVisibleAddFields
        {
            set
            {
                this.labelAttr8.Visible = value;
                this.panelAttr8.Visible = value;
            }
        }

        public bool IsVisibleTool
        {
            set
            {
                this.buttonSetChangeTool.Visible = value;
            }
        }

        public IPoint PointLocation
        {
            get
            {
                return this.mPoint;
            }
            set
            {
                if (value != null)
                {
                    this.mPoint = value;
                    if (this.mPoint != null)
                    {
                        this.ReadValue();
                    }
                }
            }
        }

        public delegate void GetAttributeshandler(IPoint pPoint, int iType);
    }
}

