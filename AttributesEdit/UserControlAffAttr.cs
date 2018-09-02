namespace AttributesEdit
{
    using DevExpress.Utils;
    using DevExpress.XtraEditors;
    using DevExpress.XtraEditors.Controls;
    using DevExpress.XtraEditors.Mask;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    /// <summary>
    /// 造林设计调查：用户自定义窗体
    /// </summary>
    public class UserControlAffAttr : UserControl
    {
        private ZLSpinEdit BHGMJ;
        private ZLComboBox BHGYY;
        private ZLComboBox BHSYY;
        private ZLComboBox BHYY;
        private ZLComboBox BSSZ;
        private SimpleButton buttonTfh;
        private TextEdit BZ;
        private IContainer components;
        private ZLComboBox CUN;
        private ZLSpinEdit DFTZDJ;
        private ZLSpinEdit DFTZJF;
        private ZLComboBox DI_LEI;
        private ZLComboBox FYFS;
        private ZLComboBox G_CHENG_LB;
        private DateEdit GXSJ;
        private ZLSpinEdit HGMJ;
        private ZLSpinEdit HSMJ;
        private TextEdit JCRY;
        private DateEdit JCSJ;
        private ZLSpinEdit JHND;
        private Label label10;
        private Label label100;
        private Label label11;
        private Label label110;
        private Label label111;
        private Label label112;
        private Label label113;
        private Label label115;
        private Label label13;
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
        private Label label30;
        private Label label32;
        private Label label33;
        private Label label35;
        private Label label36;
        private Label label37;
        private Label label42;
        private Label label43;
        private Label label47;
        private Label label49;
        private Label label51;
        private Label label53;
        private Label label56;
        private Label label59;
        private Label label6;
        private Label label61;
        private Label label65;
        private Label label66;
        private Label label67;
        private Label label68;
        private Label label69;
        private Label label7;
        private Label label70;
        private Label label72;
        private Label label75;
        private Label label78;
        private Label label81;
        private Label label84;
        private Label label88;
        private Label label89;
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
        private Label labelLBMess;
        private Label labelTitle;
        private Label laBHGMJ;
        private Label laBHGYY;
        private Label laBHSYY;
        private Label laBHYY;
        private Label laBSSZ;
        private Label laBZ;
        private Label laCUN;
        private Label laDFTZDJ;
        private Label laDFTZJF;
        private Label laDI_LEI;
        private Label laFYFS;
        private Label laG_CHENG_LB;
        private Label laGXSJ;
        private Label laHGMJ;
        private Label laHSMJ;
        private Label laJCRY;
        private Label laJCSJ;
        private Label laJHND;
        private Label laLD_CD;
        private Label laLD_KD;
        private Label laLD_QS;
        private Label laLIN_BAN;
        private Label laLIN_ZHONG;
        private Label laLMJYQ;
        private Label laLMSYQ;
        private Label laMEI_GQ_ZS;
        private Label laMIAN_JI;
        private Label laQ_DI_LEI;
        private Label laQ_LD_QS;
        private Label laQ_LIN_ZHONG;
        private Label laQ_SEN_LB;
        private Label laSEN_LIN_LB;
        private Label laSHENG;
        private Label laSHI;
        private Label laSSMJ;
        private Label laSSYY;
        private Label laSSZZS;
        private Label laTDJYQ;
        private Label laTFH;
        private Label laTU_RANG_LX;
        private Label laXI_BAN;
        private Label laXIAN;
        private Label laXIANG;
        private Label laXIAO_BAN;
        private Label laYOU_SHI_SZ;
        private Label laZAO_LIN_LB;
        private Label laZAO_LIN_MS;
        private Label laZJLY;
        private Label laZLHNAME;
        private Label laZLND;
        private Label laZYTZDJ;
        private Label laZYTZJF;
        private ZLSpinEdit LD_CD;
        private ZLSpinEdit LD_KD;
        private ZLComboBox LD_QS;
        private TextEdit LIN_BAN;
        private ZLComboBox LIN_ZHONG;
        private ZLComboBox LMJYQ;
        private ZLComboBox LMSYQ;
        private ZLSpinEdit MEI_GQ_ZS;
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
        private Panel panel8;
        private Panel panel86;
        private Panel panel9;
        private Panel panel91;
        private Panel panel92;
        private Panel panelAff;
        private Panel panelAll;
        private Panel panelBasicInfo;
        private Panel panelOther;
        private Panel panelWoodsInfo;
        private PopupContainerControl popupContainerControl1;
        private PopupContainerEdit popupContainerEdit1;
        private ZLComboBox Q_DI_LEI;
        private ZLComboBox Q_LD_QS;
        private ZLComboBox Q_LIN_ZHONG;
        private ZLComboBox Q_SEN_LB;
        private ZLComboBox SEN_LIN_LB;
        private ZLComboBox SHENG;
        private ZLComboBox SHI;
        private ZLSpinEdit SSMJ;
        private ZLComboBox SSYY;
        private ZLSpinEdit SSZZS;
        private ZLComboBox TDJYQ;
        private TextEdit TFH;
        private ZLComboBox TU_RANG_LX;
        private TextEdit XI_BAN;
        private ZLComboBox XIAN;
        private ZLComboBox XIANG;
        private TextEdit XIAO_BAN;
        private ZLComboBox YOU_SHI_SZ;
        private ZLComboBox ZAO_LIN_LB;
        private TextEdit ZAO_LIN_MS;
        private CheckedListBoxControl ZJLY;
        private TextEdit ZLHNAME;
        private TextEdit ZLND;
        private ZLSpinEdit ZYTZDJ;
        private ZLSpinEdit ZYTZJF;

        public event SetTfhhandler OnSetTfh;

        /// <summary>
        ///  造林设计调查：用户自定义窗体:构造器
        /// </summary>
        public UserControlAffAttr()
        {
            this.InitializeComponent();
            this.SSZZS.EditValueChanged += new EventHandler(this.SSZZS_EditValueChanged);
            this.MEI_GQ_ZS.EditValueChanged += new EventHandler(this.MEI_GQ_ZS_EditValueChanged);
            this.ZAO_LIN_LB.SelectedIndexChanged += new EventHandler(this.ZAO_LIN_LB_SelectedIndexChanged);
            this.Q_SEN_LB.SelectedIndexChanged += new EventHandler(this.Q_SEN_LIN_LB_SelectedIndexChanged);
            this.buttonTfh.Click += new EventHandler(this.buttonTfh_Click);
            this.ZJLY.ItemCheck += new DevExpress.XtraEditors.Controls.ItemCheckEventHandler(this.ZJLY_ItemCheck);
            this.popupContainerEdit1.Closed += new ClosedEventHandler(this.popupContainerEdit1_Closed);
        }

        private void buttonTfh_Click(object sender, EventArgs e)
        {
            this.OnSetTfh();
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

        private void DFTZDJ_EditValueChanged(object sender, EventArgs e)
        {
            decimal num = this.HGMJ.Value;
            if (num > 0M)
            {
                this.DFTZJF.Value = this.DFTZDJ.Value * num;
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
            if (index == 0x35)
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

        private void HGMJ_EditValueChanged(object sender, EventArgs e)
        {
            decimal num = this.HGMJ.Value;
            if (num > 0M)
            {
                this.DFTZJF.Value = this.DFTZDJ.Value * num;
                this.ZYTZJF.Value = this.ZYTZDJ.Value * num;
            }
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
            this.panel15 = new System.Windows.Forms.Panel();
            this.panel30 = new System.Windows.Forms.Panel();
            this.SSZZS = new AttributesEdit.ZLSpinEdit();
            this.laSSZZS = new System.Windows.Forms.Label();
            this.panel32 = new System.Windows.Forms.Panel();
            this.MEI_GQ_ZS = new AttributesEdit.ZLSpinEdit();
            this.laMEI_GQ_ZS = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.panel26 = new System.Windows.Forms.Panel();
            this.panel27 = new System.Windows.Forms.Panel();
            this.LD_CD = new AttributesEdit.ZLSpinEdit();
            this.label13 = new System.Windows.Forms.Label();
            this.laLD_CD = new System.Windows.Forms.Label();
            this.panel29 = new System.Windows.Forms.Panel();
            this.LD_KD = new AttributesEdit.ZLSpinEdit();
            this.label11 = new System.Windows.Forms.Label();
            this.laLD_KD = new System.Windows.Forms.Label();
            this.label56 = new System.Windows.Forms.Label();
            this.panel37 = new System.Windows.Forms.Panel();
            this.panel18 = new System.Windows.Forms.Panel();
            this.MIAN_JI = new AttributesEdit.ZLSpinEdit();
            this.label51 = new System.Windows.Forms.Label();
            this.laMIAN_JI = new System.Windows.Forms.Label();
            this.panel67 = new System.Windows.Forms.Panel();
            this.TU_RANG_LX = new AttributesEdit.ZLComboBox();
            this.laTU_RANG_LX = new System.Windows.Forms.Label();
            this.label183 = new System.Windows.Forms.Label();
            this.panel31 = new System.Windows.Forms.Panel();
            this.panel33 = new System.Windows.Forms.Panel();
            this.LMSYQ = new AttributesEdit.ZLComboBox();
            this.laLMSYQ = new System.Windows.Forms.Label();
            this.panel34 = new System.Windows.Forms.Panel();
            this.LMJYQ = new AttributesEdit.ZLComboBox();
            this.laLMJYQ = new System.Windows.Forms.Label();
            this.label49 = new System.Windows.Forms.Label();
            this.panel100 = new System.Windows.Forms.Panel();
            this.panel12 = new System.Windows.Forms.Panel();
            this.TDJYQ = new AttributesEdit.ZLComboBox();
            this.laTDJYQ = new System.Windows.Forms.Label();
            this.panel9 = new System.Windows.Forms.Panel();
            this.G_CHENG_LB = new AttributesEdit.ZLComboBox();
            this.laG_CHENG_LB = new System.Windows.Forms.Label();
            this.label162 = new System.Windows.Forms.Label();
            this.panel42 = new System.Windows.Forms.Panel();
            this.panel57 = new System.Windows.Forms.Panel();
            this.BSSZ = new AttributesEdit.ZLComboBox();
            this.laBSSZ = new System.Windows.Forms.Label();
            this.panel56 = new System.Windows.Forms.Panel();
            this.YOU_SHI_SZ = new AttributesEdit.ZLComboBox();
            this.laYOU_SHI_SZ = new System.Windows.Forms.Label();
            this.label61 = new System.Windows.Forms.Label();
            this.panel35 = new System.Windows.Forms.Panel();
            this.panel54 = new System.Windows.Forms.Panel();
            this.LIN_ZHONG = new AttributesEdit.ZLComboBox();
            this.laLIN_ZHONG = new System.Windows.Forms.Label();
            this.panel55 = new System.Windows.Forms.Panel();
            this.Q_LIN_ZHONG = new AttributesEdit.ZLComboBox();
            this.laQ_LIN_ZHONG = new System.Windows.Forms.Label();
            this.label59 = new System.Windows.Forms.Label();
            this.panel41 = new System.Windows.Forms.Panel();
            this.panel43 = new System.Windows.Forms.Panel();
            this.DI_LEI = new AttributesEdit.ZLComboBox();
            this.laDI_LEI = new System.Windows.Forms.Label();
            this.panel44 = new System.Windows.Forms.Panel();
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
            this.panel45 = new System.Windows.Forms.Panel();
            this.labelLBMess = new System.Windows.Forms.Label();
            this.panel23 = new System.Windows.Forms.Panel();
            this.SEN_LIN_LB = new AttributesEdit.ZLComboBox();
            this.laSEN_LIN_LB = new System.Windows.Forms.Label();
            this.panel46 = new System.Windows.Forms.Panel();
            this.Q_SEN_LB = new AttributesEdit.ZLComboBox();
            this.laQ_SEN_LB = new System.Windows.Forms.Label();
            this.label53 = new System.Windows.Forms.Label();
            this.label67 = new System.Windows.Forms.Label();
            this.label68 = new System.Windows.Forms.Label();
            this.label69 = new System.Windows.Forms.Label();
            this.label70 = new System.Windows.Forms.Label();
            this.panelAff = new System.Windows.Forms.Panel();
            this.panel36 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.panel17 = new System.Windows.Forms.Panel();
            this.BZ = new DevExpress.XtraEditors.TextEdit();
            this.laBZ = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.panel40 = new System.Windows.Forms.Panel();
            this.panel47 = new System.Windows.Forms.Panel();
            this.JCSJ = new DevExpress.XtraEditors.DateEdit();
            this.laJCSJ = new System.Windows.Forms.Label();
            this.panel48 = new System.Windows.Forms.Panel();
            this.JCRY = new DevExpress.XtraEditors.TextEdit();
            this.laJCRY = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.panel73 = new System.Windows.Forms.Panel();
            this.panel74 = new System.Windows.Forms.Panel();
            this.SSYY = new AttributesEdit.ZLComboBox();
            this.laSSYY = new System.Windows.Forms.Label();
            this.panel75 = new System.Windows.Forms.Panel();
            this.SSMJ = new AttributesEdit.ZLSpinEdit();
            this.label100 = new System.Windows.Forms.Label();
            this.laSSMJ = new System.Windows.Forms.Label();
            this.label84 = new System.Windows.Forms.Label();
            this.panel70 = new System.Windows.Forms.Panel();
            this.panel76 = new System.Windows.Forms.Panel();
            this.BHGYY = new AttributesEdit.ZLComboBox();
            this.laBHGYY = new System.Windows.Forms.Label();
            this.panel71 = new System.Windows.Forms.Panel();
            this.BHGMJ = new AttributesEdit.ZLSpinEdit();
            this.label99 = new System.Windows.Forms.Label();
            this.laBHGMJ = new System.Windows.Forms.Label();
            this.panel72 = new System.Windows.Forms.Panel();
            this.HGMJ = new AttributesEdit.ZLSpinEdit();
            this.label98 = new System.Windows.Forms.Label();
            this.laHGMJ = new System.Windows.Forms.Label();
            this.label81 = new System.Windows.Forms.Label();
            this.panel66 = new System.Windows.Forms.Panel();
            this.panel68 = new System.Windows.Forms.Panel();
            this.BHSYY = new AttributesEdit.ZLComboBox();
            this.laBHSYY = new System.Windows.Forms.Label();
            this.panel69 = new System.Windows.Forms.Panel();
            this.HSMJ = new AttributesEdit.ZLSpinEdit();
            this.label97 = new System.Windows.Forms.Label();
            this.laHSMJ = new System.Windows.Forms.Label();
            this.label78 = new System.Windows.Forms.Label();
            this.panel63 = new System.Windows.Forms.Panel();
            this.panel64 = new System.Windows.Forms.Panel();
            this.DFTZJF = new AttributesEdit.ZLSpinEdit();
            this.label95 = new System.Windows.Forms.Label();
            this.laDFTZJF = new System.Windows.Forms.Label();
            this.panel65 = new System.Windows.Forms.Panel();
            this.DFTZDJ = new AttributesEdit.ZLSpinEdit();
            this.label96 = new System.Windows.Forms.Label();
            this.laDFTZDJ = new System.Windows.Forms.Label();
            this.label75 = new System.Windows.Forms.Label();
            this.panel38 = new System.Windows.Forms.Panel();
            this.panel61 = new System.Windows.Forms.Panel();
            this.ZYTZJF = new AttributesEdit.ZLSpinEdit();
            this.label94 = new System.Windows.Forms.Label();
            this.laZYTZJF = new System.Windows.Forms.Label();
            this.panel62 = new System.Windows.Forms.Panel();
            this.ZYTZDJ = new AttributesEdit.ZLSpinEdit();
            this.label89 = new System.Windows.Forms.Label();
            this.laZYTZDJ = new System.Windows.Forms.Label();
            this.label72 = new System.Windows.Forms.Label();
            this.panel13 = new System.Windows.Forms.Panel();
            this.popupContainerControl1 = new DevExpress.XtraEditors.PopupContainerControl();
            this.ZJLY = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.panel14 = new System.Windows.Forms.Panel();
            this.popupContainerEdit1 = new DevExpress.XtraEditors.PopupContainerEdit();
            this.laZJLY = new System.Windows.Forms.Label();
            this.panel39 = new System.Windows.Forms.Panel();
            this.TFH = new DevExpress.XtraEditors.TextEdit();
            this.buttonTfh = new DevExpress.XtraEditors.SimpleButton();
            this.laTFH = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.panel51 = new System.Windows.Forms.Panel();
            this.panel58 = new System.Windows.Forms.Panel();
            this.ZLHNAME = new DevExpress.XtraEditors.TextEdit();
            this.laZLHNAME = new System.Windows.Forms.Label();
            this.panel60 = new System.Windows.Forms.Panel();
            this.FYFS = new AttributesEdit.ZLComboBox();
            this.laFYFS = new System.Windows.Forms.Label();
            this.panel49 = new System.Windows.Forms.Panel();
            this.ZAO_LIN_LB = new AttributesEdit.ZLComboBox();
            this.laZAO_LIN_LB = new System.Windows.Forms.Label();
            this.label66 = new System.Windows.Forms.Label();
            this.panel50 = new System.Windows.Forms.Panel();
            this.panel52 = new System.Windows.Forms.Panel();
            this.ZAO_LIN_MS = new DevExpress.XtraEditors.TextEdit();
            this.laZAO_LIN_MS = new System.Windows.Forms.Label();
            this.panel53 = new System.Windows.Forms.Panel();
            this.ZLND = new DevExpress.XtraEditors.TextEdit();
            this.laZLND = new System.Windows.Forms.Label();
            this.panel59 = new System.Windows.Forms.Panel();
            this.JHND = new AttributesEdit.ZLSpinEdit();
            this.laJHND = new System.Windows.Forms.Label();
            this.label88 = new System.Windows.Forms.Label();
            this.label90 = new System.Windows.Forms.Label();
            this.label91 = new System.Windows.Forms.Label();
            this.label92 = new System.Windows.Forms.Label();
            this.panelAll = new System.Windows.Forms.Panel();
            this.label93 = new System.Windows.Forms.Label();
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
            this.label43 = new System.Windows.Forms.Label();
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
            this.panelBasicInfo.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel16.SuspendLayout();
            this.panel19.SuspendLayout();
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
            this.panel15.SuspendLayout();
            this.panel30.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SSZZS.Properties)).BeginInit();
            this.panel32.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MEI_GQ_ZS.Properties)).BeginInit();
            this.panel26.SuspendLayout();
            this.panel27.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LD_CD.Properties)).BeginInit();
            this.panel29.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LD_KD.Properties)).BeginInit();
            this.panel37.SuspendLayout();
            this.panel18.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MIAN_JI.Properties)).BeginInit();
            this.panel67.SuspendLayout();
            this.panel31.SuspendLayout();
            this.panel33.SuspendLayout();
            this.panel34.SuspendLayout();
            this.panel100.SuspendLayout();
            this.panel12.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel42.SuspendLayout();
            this.panel57.SuspendLayout();
            this.panel56.SuspendLayout();
            this.panel35.SuspendLayout();
            this.panel54.SuspendLayout();
            this.panel55.SuspendLayout();
            this.panel41.SuspendLayout();
            this.panel43.SuspendLayout();
            this.panel44.SuspendLayout();
            this.panel21.SuspendLayout();
            this.panel24.SuspendLayout();
            this.panel25.SuspendLayout();
            this.panel45.SuspendLayout();
            this.panel23.SuspendLayout();
            this.panel46.SuspendLayout();
            this.panelAff.SuspendLayout();
            this.panel36.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel17.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BZ.Properties)).BeginInit();
            this.panel40.SuspendLayout();
            this.panel47.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.JCSJ.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.JCSJ.Properties)).BeginInit();
            this.panel48.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.JCRY.Properties)).BeginInit();
            this.panel73.SuspendLayout();
            this.panel74.SuspendLayout();
            this.panel75.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SSMJ.Properties)).BeginInit();
            this.panel70.SuspendLayout();
            this.panel76.SuspendLayout();
            this.panel71.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BHGMJ.Properties)).BeginInit();
            this.panel72.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.HGMJ.Properties)).BeginInit();
            this.panel66.SuspendLayout();
            this.panel68.SuspendLayout();
            this.panel69.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.HSMJ.Properties)).BeginInit();
            this.panel63.SuspendLayout();
            this.panel64.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DFTZJF.Properties)).BeginInit();
            this.panel65.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DFTZDJ.Properties)).BeginInit();
            this.panel38.SuspendLayout();
            this.panel61.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ZYTZJF.Properties)).BeginInit();
            this.panel62.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ZYTZDJ.Properties)).BeginInit();
            this.panel13.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.popupContainerControl1)).BeginInit();
            this.popupContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ZJLY)).BeginInit();
            this.panel14.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.popupContainerEdit1.Properties)).BeginInit();
            this.panel39.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TFH.Properties)).BeginInit();
            this.panel51.SuspendLayout();
            this.panel58.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ZLHNAME.Properties)).BeginInit();
            this.panel60.SuspendLayout();
            this.panel49.SuspendLayout();
            this.panel50.SuspendLayout();
            this.panel52.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ZAO_LIN_MS.Properties)).BeginInit();
            this.panel53.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ZLND.Properties)).BeginInit();
            this.panel59.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.JHND.Properties)).BeginInit();
            this.panelAll.SuspendLayout();
            this.panelOther.SuspendLayout();
            this.panel28.SuspendLayout();
            this.panel86.SuspendLayout();
            this.panel91.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GXSJ.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GXSJ.Properties)).BeginInit();
            this.panel92.SuspendLayout();
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
            this.labelTitle.Text = "造林设计调查";
            this.labelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelBasicInfo
            // 
            this.panelBasicInfo.Controls.Add(this.panel1);
            this.panelBasicInfo.Controls.Add(this.label35);
            this.panelBasicInfo.Controls.Add(this.label36);
            this.panelBasicInfo.Controls.Add(this.label37);
            this.panelBasicInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelBasicInfo.Location = new System.Drawing.Point(0, 56);
            this.panelBasicInfo.Name = "panelBasicInfo";
            this.panelBasicInfo.Size = new System.Drawing.Size(436, 76);
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
            this.panel19.Location = new System.Drawing.Point(177, 0);
            this.panel19.Name = "panel19";
            this.panel19.Padding = new System.Windows.Forms.Padding(2, 6, 8, 0);
            this.panel19.Size = new System.Drawing.Size(105, 24);
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
            this.XI_BAN.Size = new System.Drawing.Size(95, 16);
            this.XI_BAN.TabIndex = 8;
            this.XI_BAN.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // laXI_BAN
            // 
            this.laXI_BAN.Dock = System.Windows.Forms.DockStyle.Left;
            this.laXI_BAN.Location = new System.Drawing.Point(141, 0);
            this.laXI_BAN.Name = "laXI_BAN";
            this.laXI_BAN.Size = new System.Drawing.Size(36, 24);
            this.laXI_BAN.TabIndex = 0;
            this.laXI_BAN.Text = "细班";
            this.laXI_BAN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel20
            // 
            this.panel20.Controls.Add(this.XIAO_BAN);
            this.panel20.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel20.Location = new System.Drawing.Point(36, 0);
            this.panel20.Name = "panel20";
            this.panel20.Padding = new System.Windows.Forms.Padding(2, 6, 8, 0);
            this.panel20.Size = new System.Drawing.Size(105, 24);
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
            this.XIAO_BAN.Size = new System.Drawing.Size(95, 16);
            this.XIAO_BAN.TabIndex = 7;
            this.XIAO_BAN.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // laXIAO_BAN
            // 
            this.laXIAO_BAN.Dock = System.Windows.Forms.DockStyle.Left;
            this.laXIAO_BAN.Location = new System.Drawing.Point(0, 0);
            this.laXIAO_BAN.Name = "laXIAO_BAN";
            this.laXIAO_BAN.Size = new System.Drawing.Size(36, 24);
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
            this.panel7.Size = new System.Drawing.Size(434, 25);
            this.panel7.TabIndex = 0;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.LIN_BAN);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel6.Location = new System.Drawing.Point(318, 0);
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
            this.laLIN_BAN.Location = new System.Drawing.Point(282, 0);
            this.laLIN_BAN.Name = "laLIN_BAN";
            this.laLIN_BAN.Size = new System.Drawing.Size(36, 24);
            this.laLIN_BAN.TabIndex = 0;
            this.laLIN_BAN.Text = "林班";
            this.laLIN_BAN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel10
            // 
            this.panel10.Controls.Add(this.CUN);
            this.panel10.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel10.Location = new System.Drawing.Point(177, 0);
            this.panel10.Name = "panel10";
            this.panel10.Padding = new System.Windows.Forms.Padding(2, 4, 4, 0);
            this.panel10.Size = new System.Drawing.Size(105, 24);
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
            this.CUN.Size = new System.Drawing.Size(99, 20);
            this.CUN.TabIndex = 5;
            this.CUN.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // laCUN
            // 
            this.laCUN.Dock = System.Windows.Forms.DockStyle.Left;
            this.laCUN.Location = new System.Drawing.Point(141, 0);
            this.laCUN.Name = "laCUN";
            this.laCUN.Size = new System.Drawing.Size(36, 24);
            this.laCUN.TabIndex = 0;
            this.laCUN.Text = "村";
            this.laCUN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel11
            // 
            this.panel11.Controls.Add(this.XIANG);
            this.panel11.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel11.Location = new System.Drawing.Point(36, 0);
            this.panel11.Name = "panel11";
            this.panel11.Padding = new System.Windows.Forms.Padding(2, 4, 4, 0);
            this.panel11.Size = new System.Drawing.Size(105, 24);
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
            this.XIANG.Size = new System.Drawing.Size(99, 20);
            this.XIANG.TabIndex = 4;
            this.XIANG.SelectedIndexChanged += new System.EventHandler(this.XIANG_SelectedIndexChanged);
            this.XIANG.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // laXIANG
            // 
            this.laXIANG.Dock = System.Windows.Forms.DockStyle.Left;
            this.laXIANG.Location = new System.Drawing.Point(0, 0);
            this.laXIANG.Name = "laXIANG";
            this.laXIANG.Size = new System.Drawing.Size(36, 24);
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
            this.label10.Size = new System.Drawing.Size(434, 1);
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
            this.panel2.Size = new System.Drawing.Size(434, 25);
            this.panel2.TabIndex = 0;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.XIAN);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel5.Location = new System.Drawing.Point(318, 0);
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
            this.laXIAN.Location = new System.Drawing.Point(282, 0);
            this.laXIAN.Name = "laXIAN";
            this.laXIAN.Size = new System.Drawing.Size(36, 24);
            this.laXIAN.TabIndex = 0;
            this.laXIAN.Text = "区县";
            this.laXIAN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.SHI);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel4.Location = new System.Drawing.Point(177, 0);
            this.panel4.Name = "panel4";
            this.panel4.Padding = new System.Windows.Forms.Padding(2, 4, 4, 0);
            this.panel4.Size = new System.Drawing.Size(105, 24);
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
            this.SHI.Size = new System.Drawing.Size(99, 20);
            this.SHI.TabIndex = 2;
            this.SHI.SelectedIndexChanged += new System.EventHandler(this.SHI_SelectedIndexChanged);
            this.SHI.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // laSHI
            // 
            this.laSHI.Dock = System.Windows.Forms.DockStyle.Left;
            this.laSHI.Location = new System.Drawing.Point(141, 0);
            this.laSHI.Name = "laSHI";
            this.laSHI.Size = new System.Drawing.Size(36, 24);
            this.laSHI.TabIndex = 0;
            this.laSHI.Text = "市";
            this.laSHI.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.SHENG);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(36, 0);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(2, 4, 4, 0);
            this.panel3.Size = new System.Drawing.Size(105, 24);
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
            this.SHENG.Size = new System.Drawing.Size(99, 20);
            this.SHENG.TabIndex = 1;
            this.SHENG.SelectedIndexChanged += new System.EventHandler(this.SHENG_SelectedIndexChanged);
            this.SHENG.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // laSHENG
            // 
            this.laSHENG.Dock = System.Windows.Forms.DockStyle.Left;
            this.laSHENG.Location = new System.Drawing.Point(0, 0);
            this.laSHENG.Name = "laSHENG";
            this.laSHENG.Size = new System.Drawing.Size(36, 24);
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
            this.label7.Location = new System.Drawing.Point(0, 30);
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
            this.panelWoodsInfo.Location = new System.Drawing.Point(0, 210);
            this.panelWoodsInfo.Name = "panelWoodsInfo";
            this.panelWoodsInfo.Size = new System.Drawing.Size(436, 251);
            this.panelWoodsInfo.TabIndex = 0;
            // 
            // panel22
            // 
            this.panel22.Controls.Add(this.panel15);
            this.panel22.Controls.Add(this.panel26);
            this.panel22.Controls.Add(this.panel37);
            this.panel22.Controls.Add(this.panel31);
            this.panel22.Controls.Add(this.panel100);
            this.panel22.Controls.Add(this.panel42);
            this.panel22.Controls.Add(this.panel35);
            this.panel22.Controls.Add(this.panel41);
            this.panel22.Controls.Add(this.panel21);
            this.panel22.Controls.Add(this.panel45);
            this.panel22.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel22.Location = new System.Drawing.Point(1, 1);
            this.panel22.Name = "panel22";
            this.panel22.Size = new System.Drawing.Size(434, 250);
            this.panel22.TabIndex = 0;
            // 
            // panel15
            // 
            this.panel15.Controls.Add(this.panel30);
            this.panel15.Controls.Add(this.laSSZZS);
            this.panel15.Controls.Add(this.panel32);
            this.panel15.Controls.Add(this.laMEI_GQ_ZS);
            this.panel15.Controls.Add(this.label33);
            this.panel15.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel15.Location = new System.Drawing.Point(0, 225);
            this.panel15.Name = "panel15";
            this.panel15.Size = new System.Drawing.Size(434, 25);
            this.panel15.TabIndex = 0;
            // 
            // panel30
            // 
            this.panel30.Controls.Add(this.SSZZS);
            this.panel30.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel30.Location = new System.Drawing.Point(244, 0);
            this.panel30.Name = "panel30";
            this.panel30.Padding = new System.Windows.Forms.Padding(2, 2, 6, 2);
            this.panel30.Size = new System.Drawing.Size(112, 24);
            this.panel30.TabIndex = 0;
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
            10000000,
            0,
            0,
            0});
            this.SSZZS.Size = new System.Drawing.Size(104, 18);
            this.SSZZS.TabIndex = 28;
            this.SSZZS.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // laSSZZS
            // 
            this.laSSZZS.Dock = System.Windows.Forms.DockStyle.Left;
            this.laSSZZS.Location = new System.Drawing.Point(178, 0);
            this.laSSZZS.Name = "laSSZZS";
            this.laSSZZS.Size = new System.Drawing.Size(66, 24);
            this.laSSZZS.TabIndex = 0;
            this.laSSZZS.Text = "散生木株数";
            this.laSSZZS.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel32
            // 
            this.panel32.Controls.Add(this.MEI_GQ_ZS);
            this.panel32.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel32.Location = new System.Drawing.Point(66, 0);
            this.panel32.Name = "panel32";
            this.panel32.Padding = new System.Windows.Forms.Padding(2, 2, 6, 2);
            this.panel32.Size = new System.Drawing.Size(112, 24);
            this.panel32.TabIndex = 0;
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
            this.MEI_GQ_ZS.Size = new System.Drawing.Size(104, 18);
            this.MEI_GQ_ZS.TabIndex = 27;
            this.MEI_GQ_ZS.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
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
            // label33
            // 
            this.label33.BackColor = System.Drawing.Color.Black;
            this.label33.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label33.Location = new System.Drawing.Point(0, 24);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(434, 1);
            this.label33.TabIndex = 0;
            this.label33.Text = "label33";
            this.label33.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel26
            // 
            this.panel26.Controls.Add(this.panel27);
            this.panel26.Controls.Add(this.laLD_CD);
            this.panel26.Controls.Add(this.panel29);
            this.panel26.Controls.Add(this.laLD_KD);
            this.panel26.Controls.Add(this.label56);
            this.panel26.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel26.Location = new System.Drawing.Point(0, 200);
            this.panel26.Name = "panel26";
            this.panel26.Size = new System.Drawing.Size(434, 25);
            this.panel26.TabIndex = 0;
            // 
            // panel27
            // 
            this.panel27.Controls.Add(this.LD_CD);
            this.panel27.Controls.Add(this.label13);
            this.panel27.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel27.Location = new System.Drawing.Point(244, 0);
            this.panel27.Name = "panel27";
            this.panel27.Padding = new System.Windows.Forms.Padding(2, 6, 6, 2);
            this.panel27.Size = new System.Drawing.Size(112, 24);
            this.panel27.TabIndex = 0;
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
            this.LD_CD.Size = new System.Drawing.Size(79, 18);
            this.LD_CD.TabIndex = 26;
            this.LD_CD.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // label13
            // 
            this.label13.Dock = System.Windows.Forms.DockStyle.Right;
            this.label13.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Blue;
            this.label13.Location = new System.Drawing.Point(81, 6);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(25, 16);
            this.label13.TabIndex = 0;
            this.label13.Text = "m";
            // 
            // laLD_CD
            // 
            this.laLD_CD.Dock = System.Windows.Forms.DockStyle.Left;
            this.laLD_CD.Location = new System.Drawing.Point(178, 0);
            this.laLD_CD.Name = "laLD_CD";
            this.laLD_CD.Size = new System.Drawing.Size(66, 24);
            this.laLD_CD.TabIndex = 0;
            this.laLD_CD.Text = "林带长度";
            this.laLD_CD.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel29
            // 
            this.panel29.Controls.Add(this.LD_KD);
            this.panel29.Controls.Add(this.label11);
            this.panel29.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel29.Location = new System.Drawing.Point(66, 0);
            this.panel29.Name = "panel29";
            this.panel29.Padding = new System.Windows.Forms.Padding(2, 6, 6, 2);
            this.panel29.Size = new System.Drawing.Size(112, 24);
            this.panel29.TabIndex = 0;
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
            this.LD_KD.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
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
            this.LD_KD.Size = new System.Drawing.Size(79, 18);
            this.LD_KD.TabIndex = 25;
            this.LD_KD.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // label11
            // 
            this.label11.Dock = System.Windows.Forms.DockStyle.Right;
            this.label11.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Blue;
            this.label11.Location = new System.Drawing.Point(81, 6);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(25, 16);
            this.label11.TabIndex = 0;
            this.label11.Text = "m";
            // 
            // laLD_KD
            // 
            this.laLD_KD.Dock = System.Windows.Forms.DockStyle.Left;
            this.laLD_KD.Location = new System.Drawing.Point(0, 0);
            this.laLD_KD.Name = "laLD_KD";
            this.laLD_KD.Size = new System.Drawing.Size(66, 24);
            this.laLD_KD.TabIndex = 0;
            this.laLD_KD.Text = "林带宽度";
            this.laLD_KD.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label56
            // 
            this.label56.BackColor = System.Drawing.Color.Black;
            this.label56.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label56.Location = new System.Drawing.Point(0, 24);
            this.label56.Name = "label56";
            this.label56.Size = new System.Drawing.Size(434, 1);
            this.label56.TabIndex = 0;
            this.label56.Text = "label56";
            this.label56.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel37
            // 
            this.panel37.Controls.Add(this.panel18);
            this.panel37.Controls.Add(this.laMIAN_JI);
            this.panel37.Controls.Add(this.panel67);
            this.panel37.Controls.Add(this.laTU_RANG_LX);
            this.panel37.Controls.Add(this.label183);
            this.panel37.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel37.Location = new System.Drawing.Point(0, 175);
            this.panel37.Name = "panel37";
            this.panel37.Size = new System.Drawing.Size(434, 25);
            this.panel37.TabIndex = 0;
            // 
            // panel18
            // 
            this.panel18.Controls.Add(this.MIAN_JI);
            this.panel18.Controls.Add(this.label51);
            this.panel18.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel18.Location = new System.Drawing.Point(244, 0);
            this.panel18.Name = "panel18";
            this.panel18.Padding = new System.Windows.Forms.Padding(2, 6, 6, 2);
            this.panel18.Size = new System.Drawing.Size(112, 24);
            this.panel18.TabIndex = 0;
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
            this.MIAN_JI.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
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
            this.MIAN_JI.Size = new System.Drawing.Size(72, 18);
            this.MIAN_JI.TabIndex = 24;
            this.MIAN_JI.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // label51
            // 
            this.label51.Dock = System.Windows.Forms.DockStyle.Right;
            this.label51.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label51.ForeColor = System.Drawing.Color.Blue;
            this.label51.Location = new System.Drawing.Point(74, 6);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(32, 16);
            this.label51.TabIndex = 0;
            this.label51.Text = "公顷";
            // 
            // laMIAN_JI
            // 
            this.laMIAN_JI.Dock = System.Windows.Forms.DockStyle.Left;
            this.laMIAN_JI.Location = new System.Drawing.Point(178, 0);
            this.laMIAN_JI.Name = "laMIAN_JI";
            this.laMIAN_JI.Size = new System.Drawing.Size(66, 24);
            this.laMIAN_JI.TabIndex = 0;
            this.laMIAN_JI.Text = "面积";
            this.laMIAN_JI.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel67
            // 
            this.panel67.Controls.Add(this.TU_RANG_LX);
            this.panel67.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel67.Location = new System.Drawing.Point(66, 0);
            this.panel67.Name = "panel67";
            this.panel67.Padding = new System.Windows.Forms.Padding(2, 4, 4, 0);
            this.panel67.Size = new System.Drawing.Size(112, 24);
            this.panel67.TabIndex = 0;
            // 
            // TU_RANG_LX
            // 
            this.TU_RANG_LX.AssDispValue = true;
            this.TU_RANG_LX.Cursor = System.Windows.Forms.Cursors.Hand;
            this.TU_RANG_LX.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TU_RANG_LX.ForeColor = System.Drawing.Color.Blue;
            this.TU_RANG_LX.Location = new System.Drawing.Point(2, 4);
            this.TU_RANG_LX.Name = "TU_RANG_LX";
            this.TU_RANG_LX.Size = new System.Drawing.Size(106, 20);
            this.TU_RANG_LX.TabIndex = 23;
            this.TU_RANG_LX.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // laTU_RANG_LX
            // 
            this.laTU_RANG_LX.Dock = System.Windows.Forms.DockStyle.Left;
            this.laTU_RANG_LX.Location = new System.Drawing.Point(0, 0);
            this.laTU_RANG_LX.Name = "laTU_RANG_LX";
            this.laTU_RANG_LX.Size = new System.Drawing.Size(66, 24);
            this.laTU_RANG_LX.TabIndex = 0;
            this.laTU_RANG_LX.Text = "土壤类型";
            this.laTU_RANG_LX.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.panel31.Controls.Add(this.laLMSYQ);
            this.panel31.Controls.Add(this.panel34);
            this.panel31.Controls.Add(this.laLMJYQ);
            this.panel31.Controls.Add(this.label49);
            this.panel31.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel31.Location = new System.Drawing.Point(0, 150);
            this.panel31.Name = "panel31";
            this.panel31.Size = new System.Drawing.Size(434, 25);
            this.panel31.TabIndex = 0;
            // 
            // panel33
            // 
            this.panel33.Controls.Add(this.LMSYQ);
            this.panel33.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel33.Location = new System.Drawing.Point(244, 0);
            this.panel33.Name = "panel33";
            this.panel33.Padding = new System.Windows.Forms.Padding(2, 4, 4, 0);
            this.panel33.Size = new System.Drawing.Size(112, 24);
            this.panel33.TabIndex = 0;
            // 
            // LMSYQ
            // 
            this.LMSYQ.AssDispValue = true;
            this.LMSYQ.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LMSYQ.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LMSYQ.ForeColor = System.Drawing.Color.Blue;
            this.LMSYQ.Location = new System.Drawing.Point(2, 4);
            this.LMSYQ.Name = "LMSYQ";
            this.LMSYQ.Size = new System.Drawing.Size(106, 20);
            this.LMSYQ.TabIndex = 22;
            this.LMSYQ.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // laLMSYQ
            // 
            this.laLMSYQ.Dock = System.Windows.Forms.DockStyle.Left;
            this.laLMSYQ.Location = new System.Drawing.Point(178, 0);
            this.laLMSYQ.Name = "laLMSYQ";
            this.laLMSYQ.Size = new System.Drawing.Size(66, 24);
            this.laLMSYQ.TabIndex = 0;
            this.laLMSYQ.Text = "林木所有权";
            this.laLMSYQ.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel34
            // 
            this.panel34.Controls.Add(this.LMJYQ);
            this.panel34.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel34.Location = new System.Drawing.Point(66, 0);
            this.panel34.Name = "panel34";
            this.panel34.Padding = new System.Windows.Forms.Padding(2, 4, 4, 0);
            this.panel34.Size = new System.Drawing.Size(112, 24);
            this.panel34.TabIndex = 0;
            // 
            // LMJYQ
            // 
            this.LMJYQ.AssDispValue = true;
            this.LMJYQ.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LMJYQ.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LMJYQ.ForeColor = System.Drawing.Color.Blue;
            this.LMJYQ.Location = new System.Drawing.Point(2, 4);
            this.LMJYQ.Name = "LMJYQ";
            this.LMJYQ.Size = new System.Drawing.Size(106, 20);
            this.LMJYQ.TabIndex = 21;
            this.LMJYQ.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // laLMJYQ
            // 
            this.laLMJYQ.Dock = System.Windows.Forms.DockStyle.Left;
            this.laLMJYQ.Location = new System.Drawing.Point(0, 0);
            this.laLMJYQ.Name = "laLMJYQ";
            this.laLMJYQ.Size = new System.Drawing.Size(66, 24);
            this.laLMJYQ.TabIndex = 0;
            this.laLMJYQ.Text = "林木使用权";
            this.laLMJYQ.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            // panel100
            // 
            this.panel100.Controls.Add(this.panel12);
            this.panel100.Controls.Add(this.laTDJYQ);
            this.panel100.Controls.Add(this.panel9);
            this.panel100.Controls.Add(this.laG_CHENG_LB);
            this.panel100.Controls.Add(this.label162);
            this.panel100.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel100.Location = new System.Drawing.Point(0, 125);
            this.panel100.Name = "panel100";
            this.panel100.Size = new System.Drawing.Size(434, 25);
            this.panel100.TabIndex = 0;
            // 
            // panel12
            // 
            this.panel12.Controls.Add(this.TDJYQ);
            this.panel12.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel12.Location = new System.Drawing.Point(292, 0);
            this.panel12.Name = "panel12";
            this.panel12.Padding = new System.Windows.Forms.Padding(2, 4, 4, 0);
            this.panel12.Size = new System.Drawing.Size(77, 24);
            this.panel12.TabIndex = 0;
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
            this.TDJYQ.TabIndex = 20;
            this.TDJYQ.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // laTDJYQ
            // 
            this.laTDJYQ.Dock = System.Windows.Forms.DockStyle.Left;
            this.laTDJYQ.Location = new System.Drawing.Point(226, 0);
            this.laTDJYQ.Name = "laTDJYQ";
            this.laTDJYQ.Size = new System.Drawing.Size(66, 24);
            this.laTDJYQ.TabIndex = 0;
            this.laTDJYQ.Text = "土地使用权";
            this.laTDJYQ.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.G_CHENG_LB);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel9.Location = new System.Drawing.Point(66, 0);
            this.panel9.Name = "panel9";
            this.panel9.Padding = new System.Windows.Forms.Padding(2, 4, 4, 0);
            this.panel9.Size = new System.Drawing.Size(160, 24);
            this.panel9.TabIndex = 0;
            // 
            // G_CHENG_LB
            // 
            this.G_CHENG_LB.AssDispValue = true;
            this.G_CHENG_LB.Cursor = System.Windows.Forms.Cursors.Hand;
            this.G_CHENG_LB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.G_CHENG_LB.ForeColor = System.Drawing.Color.Blue;
            this.G_CHENG_LB.Location = new System.Drawing.Point(2, 4);
            this.G_CHENG_LB.Name = "G_CHENG_LB";
            this.G_CHENG_LB.Size = new System.Drawing.Size(154, 20);
            this.G_CHENG_LB.TabIndex = 19;
            this.G_CHENG_LB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // laG_CHENG_LB
            // 
            this.laG_CHENG_LB.Dock = System.Windows.Forms.DockStyle.Left;
            this.laG_CHENG_LB.Location = new System.Drawing.Point(0, 0);
            this.laG_CHENG_LB.Name = "laG_CHENG_LB";
            this.laG_CHENG_LB.Size = new System.Drawing.Size(66, 24);
            this.laG_CHENG_LB.TabIndex = 0;
            this.laG_CHENG_LB.Text = "工程类别";
            this.laG_CHENG_LB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            // panel42
            // 
            this.panel42.Controls.Add(this.panel57);
            this.panel42.Controls.Add(this.laBSSZ);
            this.panel42.Controls.Add(this.panel56);
            this.panel42.Controls.Add(this.laYOU_SHI_SZ);
            this.panel42.Controls.Add(this.label61);
            this.panel42.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel42.Location = new System.Drawing.Point(0, 100);
            this.panel42.Name = "panel42";
            this.panel42.Size = new System.Drawing.Size(434, 25);
            this.panel42.TabIndex = 0;
            // 
            // panel57
            // 
            this.panel57.Controls.Add(this.BSSZ);
            this.panel57.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel57.Location = new System.Drawing.Point(244, 0);
            this.panel57.Name = "panel57";
            this.panel57.Padding = new System.Windows.Forms.Padding(2, 4, 4, 0);
            this.panel57.Size = new System.Drawing.Size(112, 24);
            this.panel57.TabIndex = 0;
            // 
            // BSSZ
            // 
            this.BSSZ.AssDispValue = true;
            this.BSSZ.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BSSZ.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BSSZ.ForeColor = System.Drawing.Color.Blue;
            this.BSSZ.Location = new System.Drawing.Point(2, 4);
            this.BSSZ.Name = "BSSZ";
            this.BSSZ.Size = new System.Drawing.Size(106, 20);
            this.BSSZ.TabIndex = 18;
            this.BSSZ.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // laBSSZ
            // 
            this.laBSSZ.Dock = System.Windows.Forms.DockStyle.Left;
            this.laBSSZ.Location = new System.Drawing.Point(178, 0);
            this.laBSSZ.Name = "laBSSZ";
            this.laBSSZ.Size = new System.Drawing.Size(66, 24);
            this.laBSSZ.TabIndex = 0;
            this.laBSSZ.Text = "伴生树种";
            this.laBSSZ.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel56
            // 
            this.panel56.Controls.Add(this.YOU_SHI_SZ);
            this.panel56.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel56.Location = new System.Drawing.Point(66, 0);
            this.panel56.Name = "panel56";
            this.panel56.Padding = new System.Windows.Forms.Padding(2, 4, 4, 0);
            this.panel56.Size = new System.Drawing.Size(112, 24);
            this.panel56.TabIndex = 0;
            // 
            // YOU_SHI_SZ
            // 
            this.YOU_SHI_SZ.AssDispValue = true;
            this.YOU_SHI_SZ.Cursor = System.Windows.Forms.Cursors.Hand;
            this.YOU_SHI_SZ.Dock = System.Windows.Forms.DockStyle.Fill;
            this.YOU_SHI_SZ.ForeColor = System.Drawing.Color.Blue;
            this.YOU_SHI_SZ.Location = new System.Drawing.Point(2, 4);
            this.YOU_SHI_SZ.Name = "YOU_SHI_SZ";
            this.YOU_SHI_SZ.Size = new System.Drawing.Size(106, 20);
            this.YOU_SHI_SZ.TabIndex = 17;
            this.YOU_SHI_SZ.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // laYOU_SHI_SZ
            // 
            this.laYOU_SHI_SZ.Dock = System.Windows.Forms.DockStyle.Left;
            this.laYOU_SHI_SZ.Location = new System.Drawing.Point(0, 0);
            this.laYOU_SHI_SZ.Name = "laYOU_SHI_SZ";
            this.laYOU_SHI_SZ.Size = new System.Drawing.Size(66, 24);
            this.laYOU_SHI_SZ.TabIndex = 0;
            this.laYOU_SHI_SZ.Text = "优势树种";
            this.laYOU_SHI_SZ.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label61
            // 
            this.label61.BackColor = System.Drawing.Color.Black;
            this.label61.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label61.Location = new System.Drawing.Point(0, 24);
            this.label61.Name = "label61";
            this.label61.Size = new System.Drawing.Size(434, 1);
            this.label61.TabIndex = 0;
            this.label61.Text = "label61";
            this.label61.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel35
            // 
            this.panel35.Controls.Add(this.panel54);
            this.panel35.Controls.Add(this.laLIN_ZHONG);
            this.panel35.Controls.Add(this.panel55);
            this.panel35.Controls.Add(this.laQ_LIN_ZHONG);
            this.panel35.Controls.Add(this.label59);
            this.panel35.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel35.Location = new System.Drawing.Point(0, 75);
            this.panel35.Name = "panel35";
            this.panel35.Size = new System.Drawing.Size(434, 25);
            this.panel35.TabIndex = 0;
            // 
            // panel54
            // 
            this.panel54.Controls.Add(this.LIN_ZHONG);
            this.panel54.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel54.Location = new System.Drawing.Point(244, 0);
            this.panel54.Name = "panel54";
            this.panel54.Padding = new System.Windows.Forms.Padding(2, 4, 4, 0);
            this.panel54.Size = new System.Drawing.Size(112, 24);
            this.panel54.TabIndex = 0;
            // 
            // LIN_ZHONG
            // 
            this.LIN_ZHONG.AssDispValue = true;
            this.LIN_ZHONG.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LIN_ZHONG.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LIN_ZHONG.ForeColor = System.Drawing.Color.Blue;
            this.LIN_ZHONG.Location = new System.Drawing.Point(2, 4);
            this.LIN_ZHONG.Name = "LIN_ZHONG";
            this.LIN_ZHONG.Size = new System.Drawing.Size(106, 20);
            this.LIN_ZHONG.TabIndex = 16;
            this.LIN_ZHONG.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // laLIN_ZHONG
            // 
            this.laLIN_ZHONG.Dock = System.Windows.Forms.DockStyle.Left;
            this.laLIN_ZHONG.Location = new System.Drawing.Point(178, 0);
            this.laLIN_ZHONG.Name = "laLIN_ZHONG";
            this.laLIN_ZHONG.Size = new System.Drawing.Size(66, 24);
            this.laLIN_ZHONG.TabIndex = 0;
            this.laLIN_ZHONG.Text = "林种";
            this.laLIN_ZHONG.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel55
            // 
            this.panel55.Controls.Add(this.Q_LIN_ZHONG);
            this.panel55.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel55.Location = new System.Drawing.Point(66, 0);
            this.panel55.Name = "panel55";
            this.panel55.Padding = new System.Windows.Forms.Padding(2, 4, 4, 0);
            this.panel55.Size = new System.Drawing.Size(112, 24);
            this.panel55.TabIndex = 0;
            // 
            // Q_LIN_ZHONG
            // 
            this.Q_LIN_ZHONG.AssDispValue = true;
            this.Q_LIN_ZHONG.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Q_LIN_ZHONG.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Q_LIN_ZHONG.ForeColor = System.Drawing.Color.Blue;
            this.Q_LIN_ZHONG.Location = new System.Drawing.Point(2, 4);
            this.Q_LIN_ZHONG.Name = "Q_LIN_ZHONG";
            this.Q_LIN_ZHONG.Size = new System.Drawing.Size(106, 20);
            this.Q_LIN_ZHONG.TabIndex = 15;
            this.Q_LIN_ZHONG.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // laQ_LIN_ZHONG
            // 
            this.laQ_LIN_ZHONG.Dock = System.Windows.Forms.DockStyle.Left;
            this.laQ_LIN_ZHONG.Location = new System.Drawing.Point(0, 0);
            this.laQ_LIN_ZHONG.Name = "laQ_LIN_ZHONG";
            this.laQ_LIN_ZHONG.Size = new System.Drawing.Size(66, 24);
            this.laQ_LIN_ZHONG.TabIndex = 0;
            this.laQ_LIN_ZHONG.Text = "前期林种";
            this.laQ_LIN_ZHONG.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label59
            // 
            this.label59.BackColor = System.Drawing.Color.Black;
            this.label59.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label59.Location = new System.Drawing.Point(0, 24);
            this.label59.Name = "label59";
            this.label59.Size = new System.Drawing.Size(434, 1);
            this.label59.TabIndex = 0;
            this.label59.Text = "label59";
            this.label59.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel41
            // 
            this.panel41.Controls.Add(this.panel43);
            this.panel41.Controls.Add(this.laDI_LEI);
            this.panel41.Controls.Add(this.panel44);
            this.panel41.Controls.Add(this.laQ_DI_LEI);
            this.panel41.Controls.Add(this.label65);
            this.panel41.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel41.Location = new System.Drawing.Point(0, 50);
            this.panel41.Name = "panel41";
            this.panel41.Size = new System.Drawing.Size(434, 25);
            this.panel41.TabIndex = 0;
            // 
            // panel43
            // 
            this.panel43.Controls.Add(this.DI_LEI);
            this.panel43.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel43.Location = new System.Drawing.Point(244, 0);
            this.panel43.Name = "panel43";
            this.panel43.Padding = new System.Windows.Forms.Padding(2, 4, 4, 0);
            this.panel43.Size = new System.Drawing.Size(112, 24);
            this.panel43.TabIndex = 0;
            // 
            // DI_LEI
            // 
            this.DI_LEI.AssDispValue = true;
            this.DI_LEI.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DI_LEI.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DI_LEI.ForeColor = System.Drawing.Color.Blue;
            this.DI_LEI.Location = new System.Drawing.Point(2, 4);
            this.DI_LEI.Name = "DI_LEI";
            this.DI_LEI.Size = new System.Drawing.Size(106, 20);
            this.DI_LEI.TabIndex = 14;
            this.DI_LEI.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // laDI_LEI
            // 
            this.laDI_LEI.Dock = System.Windows.Forms.DockStyle.Left;
            this.laDI_LEI.Location = new System.Drawing.Point(178, 0);
            this.laDI_LEI.Name = "laDI_LEI";
            this.laDI_LEI.Size = new System.Drawing.Size(66, 24);
            this.laDI_LEI.TabIndex = 0;
            this.laDI_LEI.Text = "地类";
            this.laDI_LEI.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel44
            // 
            this.panel44.Controls.Add(this.Q_DI_LEI);
            this.panel44.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel44.Location = new System.Drawing.Point(66, 0);
            this.panel44.Name = "panel44";
            this.panel44.Padding = new System.Windows.Forms.Padding(2, 4, 4, 0);
            this.panel44.Size = new System.Drawing.Size(112, 24);
            this.panel44.TabIndex = 0;
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
            this.Q_DI_LEI.Size = new System.Drawing.Size(106, 20);
            this.Q_DI_LEI.TabIndex = 13;
            this.Q_DI_LEI.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // laQ_DI_LEI
            // 
            this.laQ_DI_LEI.Dock = System.Windows.Forms.DockStyle.Left;
            this.laQ_DI_LEI.Location = new System.Drawing.Point(0, 0);
            this.laQ_DI_LEI.Name = "laQ_DI_LEI";
            this.laQ_DI_LEI.Size = new System.Drawing.Size(66, 24);
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
            this.panel21.Location = new System.Drawing.Point(0, 25);
            this.panel21.Name = "panel21";
            this.panel21.Size = new System.Drawing.Size(434, 25);
            this.panel21.TabIndex = 0;
            // 
            // panel24
            // 
            this.panel24.Controls.Add(this.LD_QS);
            this.panel24.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel24.Location = new System.Drawing.Point(246, 0);
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
            this.laLD_QS.Location = new System.Drawing.Point(188, 0);
            this.laLD_QS.Name = "laLD_QS";
            this.laLD_QS.Size = new System.Drawing.Size(58, 24);
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
            this.Q_LD_QS.BackColor = System.Drawing.Color.White;
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
            // panel45
            // 
            this.panel45.Controls.Add(this.labelLBMess);
            this.panel45.Controls.Add(this.panel23);
            this.panel45.Controls.Add(this.laSEN_LIN_LB);
            this.panel45.Controls.Add(this.panel46);
            this.panel45.Controls.Add(this.laQ_SEN_LB);
            this.panel45.Controls.Add(this.label53);
            this.panel45.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel45.Location = new System.Drawing.Point(0, 0);
            this.panel45.Name = "panel45";
            this.panel45.Size = new System.Drawing.Size(434, 25);
            this.panel45.TabIndex = 0;
            // 
            // labelLBMess
            // 
            this.labelLBMess.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelLBMess.ForeColor = System.Drawing.Color.Red;
            this.labelLBMess.Location = new System.Drawing.Point(341, 0);
            this.labelLBMess.Name = "labelLBMess";
            this.labelLBMess.Size = new System.Drawing.Size(103, 24);
            this.labelLBMess.TabIndex = 0;
            this.labelLBMess.Text = "森林类别已改变！";
            this.labelLBMess.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelLBMess.Visible = false;
            // 
            // panel23
            // 
            this.panel23.Controls.Add(this.SEN_LIN_LB);
            this.panel23.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel23.Location = new System.Drawing.Point(236, 0);
            this.panel23.Name = "panel23";
            this.panel23.Padding = new System.Windows.Forms.Padding(2, 4, 4, 0);
            this.panel23.Size = new System.Drawing.Size(105, 24);
            this.panel23.TabIndex = 0;
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
            this.SEN_LIN_LB.TabIndex = 10;
            this.SEN_LIN_LB.SelectedIndexChanged += new System.EventHandler(this.SEN_LIN_LB_SelectedIndexChanged);
            this.SEN_LIN_LB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // laSEN_LIN_LB
            // 
            this.laSEN_LIN_LB.Dock = System.Windows.Forms.DockStyle.Left;
            this.laSEN_LIN_LB.Location = new System.Drawing.Point(183, 0);
            this.laSEN_LIN_LB.Name = "laSEN_LIN_LB";
            this.laSEN_LIN_LB.Size = new System.Drawing.Size(53, 24);
            this.laSEN_LIN_LB.TabIndex = 0;
            this.laSEN_LIN_LB.Text = "森林类别";
            this.laSEN_LIN_LB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel46
            // 
            this.panel46.Controls.Add(this.Q_SEN_LB);
            this.panel46.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel46.Location = new System.Drawing.Point(78, 0);
            this.panel46.Name = "panel46";
            this.panel46.Padding = new System.Windows.Forms.Padding(2, 4, 4, 0);
            this.panel46.Size = new System.Drawing.Size(105, 24);
            this.panel46.TabIndex = 0;
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
            this.Q_SEN_LB.Size = new System.Drawing.Size(99, 20);
            this.Q_SEN_LB.TabIndex = 9;
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
            // label53
            // 
            this.label53.BackColor = System.Drawing.Color.Black;
            this.label53.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label53.Location = new System.Drawing.Point(0, 24);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(434, 1);
            this.label53.TabIndex = 0;
            this.label53.Text = "label53";
            this.label53.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.label68.Size = new System.Drawing.Size(1, 251);
            this.label68.TabIndex = 0;
            this.label68.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label69
            // 
            this.label69.BackColor = System.Drawing.Color.Black;
            this.label69.Dock = System.Windows.Forms.DockStyle.Right;
            this.label69.Location = new System.Drawing.Point(435, 0);
            this.label69.Name = "label69";
            this.label69.Size = new System.Drawing.Size(1, 251);
            this.label69.TabIndex = 0;
            this.label69.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label70
            // 
            this.label70.Dock = System.Windows.Forms.DockStyle.Top;
            this.label70.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label70.Location = new System.Drawing.Point(0, 184);
            this.label70.Name = "label70";
            this.label70.Size = new System.Drawing.Size(436, 26);
            this.label70.TabIndex = 0;
            this.label70.Text = "  林木状况调查";
            this.label70.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelAff
            // 
            this.panelAff.Controls.Add(this.panel36);
            this.panelAff.Controls.Add(this.label90);
            this.panelAff.Controls.Add(this.label91);
            this.panelAff.Controls.Add(this.label92);
            this.panelAff.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelAff.Location = new System.Drawing.Point(0, 487);
            this.panelAff.Name = "panelAff";
            this.panelAff.Size = new System.Drawing.Size(436, 251);
            this.panelAff.TabIndex = 0;
            // 
            // panel36
            // 
            this.panel36.Controls.Add(this.panel8);
            this.panel36.Controls.Add(this.panel40);
            this.panel36.Controls.Add(this.panel73);
            this.panel36.Controls.Add(this.panel70);
            this.panel36.Controls.Add(this.panel66);
            this.panel36.Controls.Add(this.panel63);
            this.panel36.Controls.Add(this.panel38);
            this.panel36.Controls.Add(this.panel13);
            this.panel36.Controls.Add(this.panel51);
            this.panel36.Controls.Add(this.panel50);
            this.panel36.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel36.Location = new System.Drawing.Point(1, 1);
            this.panel36.Name = "panel36";
            this.panel36.Size = new System.Drawing.Size(434, 250);
            this.panel36.TabIndex = 0;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.panel17);
            this.panel8.Controls.Add(this.laBZ);
            this.panel8.Controls.Add(this.label32);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel8.Location = new System.Drawing.Point(0, 225);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(434, 25);
            this.panel8.TabIndex = 0;
            // 
            // panel17
            // 
            this.panel17.Controls.Add(this.BZ);
            this.panel17.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel17.Location = new System.Drawing.Point(53, 0);
            this.panel17.Name = "panel17";
            this.panel17.Padding = new System.Windows.Forms.Padding(2, 6, 8, 0);
            this.panel17.Size = new System.Drawing.Size(357, 24);
            this.panel17.TabIndex = 0;
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
            this.BZ.Properties.MaxLength = 50;
            this.BZ.Size = new System.Drawing.Size(347, 16);
            this.BZ.TabIndex = 50;
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
            // panel40
            // 
            this.panel40.Controls.Add(this.panel47);
            this.panel40.Controls.Add(this.laJCSJ);
            this.panel40.Controls.Add(this.panel48);
            this.panel40.Controls.Add(this.laJCRY);
            this.panel40.Controls.Add(this.label30);
            this.panel40.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel40.Location = new System.Drawing.Point(0, 200);
            this.panel40.Name = "panel40";
            this.panel40.Size = new System.Drawing.Size(434, 25);
            this.panel40.TabIndex = 0;
            // 
            // panel47
            // 
            this.panel47.Controls.Add(this.JCSJ);
            this.panel47.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel47.Location = new System.Drawing.Point(208, 0);
            this.panel47.Name = "panel47";
            this.panel47.Padding = new System.Windows.Forms.Padding(2, 1, 8, 3);
            this.panel47.Size = new System.Drawing.Size(90, 24);
            this.panel47.TabIndex = 0;
            // 
            // JCSJ
            // 
            this.JCSJ.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.JCSJ.EditValue = null;
            this.JCSJ.Location = new System.Drawing.Point(2, 3);
            this.JCSJ.Name = "JCSJ";
            this.JCSJ.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.JCSJ.Properties.Appearance.Options.UseForeColor = true;
            this.JCSJ.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.JCSJ.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.JCSJ.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.JCSJ.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.JCSJ.Size = new System.Drawing.Size(80, 18);
            this.JCSJ.TabIndex = 49;
            this.JCSJ.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // laJCSJ
            // 
            this.laJCSJ.Dock = System.Windows.Forms.DockStyle.Left;
            this.laJCSJ.Location = new System.Drawing.Point(143, 0);
            this.laJCSJ.Name = "laJCSJ";
            this.laJCSJ.Size = new System.Drawing.Size(65, 24);
            this.laJCSJ.TabIndex = 0;
            this.laJCSJ.Text = "检查时间";
            this.laJCSJ.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel48
            // 
            this.panel48.Controls.Add(this.JCRY);
            this.panel48.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel48.Location = new System.Drawing.Point(53, 0);
            this.panel48.Name = "panel48";
            this.panel48.Padding = new System.Windows.Forms.Padding(2, 6, 8, 0);
            this.panel48.Size = new System.Drawing.Size(90, 24);
            this.panel48.TabIndex = 0;
            // 
            // JCRY
            // 
            this.JCRY.Cursor = System.Windows.Forms.Cursors.Hand;
            this.JCRY.Dock = System.Windows.Forms.DockStyle.Fill;
            this.JCRY.EditValue = "";
            this.JCRY.Location = new System.Drawing.Point(2, 6);
            this.JCRY.Name = "JCRY";
            this.JCRY.Properties.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.JCRY.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.JCRY.Properties.Appearance.Options.UseFont = true;
            this.JCRY.Properties.Appearance.Options.UseForeColor = true;
            this.JCRY.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.JCRY.Properties.MaxLength = 40;
            this.JCRY.Size = new System.Drawing.Size(80, 16);
            this.JCRY.TabIndex = 48;
            this.JCRY.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // laJCRY
            // 
            this.laJCRY.Dock = System.Windows.Forms.DockStyle.Left;
            this.laJCRY.Location = new System.Drawing.Point(0, 0);
            this.laJCRY.Name = "laJCRY";
            this.laJCRY.Size = new System.Drawing.Size(53, 24);
            this.laJCRY.TabIndex = 0;
            this.laJCRY.Text = "检查人员";
            this.laJCRY.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            // panel73
            // 
            this.panel73.Controls.Add(this.panel74);
            this.panel73.Controls.Add(this.laSSYY);
            this.panel73.Controls.Add(this.panel75);
            this.panel73.Controls.Add(this.laSSMJ);
            this.panel73.Controls.Add(this.label84);
            this.panel73.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel73.Location = new System.Drawing.Point(0, 175);
            this.panel73.Name = "panel73";
            this.panel73.Size = new System.Drawing.Size(434, 25);
            this.panel73.TabIndex = 0;
            // 
            // panel74
            // 
            this.panel74.Controls.Add(this.SSYY);
            this.panel74.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel74.Location = new System.Drawing.Point(208, 0);
            this.panel74.Name = "panel74";
            this.panel74.Padding = new System.Windows.Forms.Padding(2, 4, 4, 0);
            this.panel74.Size = new System.Drawing.Size(100, 24);
            this.panel74.TabIndex = 0;
            // 
            // SSYY
            // 
            this.SSYY.AssDispValue = true;
            this.SSYY.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SSYY.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SSYY.ForeColor = System.Drawing.Color.Blue;
            this.SSYY.Location = new System.Drawing.Point(2, 4);
            this.SSYY.Name = "SSYY";
            this.SSYY.Size = new System.Drawing.Size(94, 20);
            this.SSYY.TabIndex = 47;
            this.SSYY.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // laSSYY
            // 
            this.laSSYY.Dock = System.Windows.Forms.DockStyle.Left;
            this.laSSYY.Location = new System.Drawing.Point(143, 0);
            this.laSSYY.Name = "laSSYY";
            this.laSSYY.Size = new System.Drawing.Size(65, 24);
            this.laSSYY.TabIndex = 0;
            this.laSSYY.Text = "损失原因";
            this.laSSYY.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel75
            // 
            this.panel75.Controls.Add(this.SSMJ);
            this.panel75.Controls.Add(this.label100);
            this.panel75.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel75.Location = new System.Drawing.Point(53, 0);
            this.panel75.Name = "panel75";
            this.panel75.Padding = new System.Windows.Forms.Padding(2, 6, 6, 2);
            this.panel75.Size = new System.Drawing.Size(90, 24);
            this.panel75.TabIndex = 0;
            // 
            // SSMJ
            // 
            this.SSMJ.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SSMJ.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.SSMJ.EditScale = 0;
            this.SSMJ.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.SSMJ.Location = new System.Drawing.Point(2, 4);
            this.SSMJ.Name = "SSMJ";
            this.SSMJ.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.SSMJ.Properties.Appearance.Options.UseForeColor = true;
            this.SSMJ.Properties.Appearance.Options.UseTextOptions = true;
            this.SSMJ.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.SSMJ.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.SSMJ.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.SSMJ.Properties.MaxValue = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.SSMJ.Size = new System.Drawing.Size(50, 18);
            this.SSMJ.TabIndex = 46;
            this.SSMJ.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // label100
            // 
            this.label100.Dock = System.Windows.Forms.DockStyle.Right;
            this.label100.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label100.ForeColor = System.Drawing.Color.Blue;
            this.label100.Location = new System.Drawing.Point(52, 6);
            this.label100.Name = "label100";
            this.label100.Size = new System.Drawing.Size(32, 16);
            this.label100.TabIndex = 0;
            this.label100.Text = "公顷";
            // 
            // laSSMJ
            // 
            this.laSSMJ.Dock = System.Windows.Forms.DockStyle.Left;
            this.laSSMJ.Location = new System.Drawing.Point(0, 0);
            this.laSSMJ.Name = "laSSMJ";
            this.laSSMJ.Size = new System.Drawing.Size(53, 24);
            this.laSSMJ.TabIndex = 0;
            this.laSSMJ.Text = "损失面积";
            this.laSSMJ.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label84
            // 
            this.label84.BackColor = System.Drawing.Color.Black;
            this.label84.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label84.Location = new System.Drawing.Point(0, 24);
            this.label84.Name = "label84";
            this.label84.Size = new System.Drawing.Size(434, 1);
            this.label84.TabIndex = 0;
            this.label84.Text = "label84";
            this.label84.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel70
            // 
            this.panel70.Controls.Add(this.panel76);
            this.panel70.Controls.Add(this.laBHGYY);
            this.panel70.Controls.Add(this.panel71);
            this.panel70.Controls.Add(this.laBHGMJ);
            this.panel70.Controls.Add(this.panel72);
            this.panel70.Controls.Add(this.laHGMJ);
            this.panel70.Controls.Add(this.label81);
            this.panel70.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel70.Location = new System.Drawing.Point(0, 150);
            this.panel70.Name = "panel70";
            this.panel70.Size = new System.Drawing.Size(434, 25);
            this.panel70.TabIndex = 0;
            // 
            // panel76
            // 
            this.panel76.Controls.Add(this.BHGYY);
            this.panel76.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel76.Location = new System.Drawing.Point(353, 0);
            this.panel76.Name = "panel76";
            this.panel76.Padding = new System.Windows.Forms.Padding(2, 4, 4, 0);
            this.panel76.Size = new System.Drawing.Size(76, 24);
            this.panel76.TabIndex = 0;
            // 
            // BHGYY
            // 
            this.BHGYY.AssDispValue = true;
            this.BHGYY.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BHGYY.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BHGYY.ForeColor = System.Drawing.Color.Blue;
            this.BHGYY.Location = new System.Drawing.Point(2, 4);
            this.BHGYY.Name = "BHGYY";
            this.BHGYY.Size = new System.Drawing.Size(70, 20);
            this.BHGYY.TabIndex = 45;
            this.BHGYY.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // laBHGYY
            // 
            this.laBHGYY.Dock = System.Windows.Forms.DockStyle.Left;
            this.laBHGYY.Location = new System.Drawing.Point(288, 0);
            this.laBHGYY.Name = "laBHGYY";
            this.laBHGYY.Size = new System.Drawing.Size(65, 24);
            this.laBHGYY.TabIndex = 0;
            this.laBHGYY.Text = "不合格原因";
            this.laBHGYY.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel71
            // 
            this.panel71.Controls.Add(this.BHGMJ);
            this.panel71.Controls.Add(this.label99);
            this.panel71.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel71.Location = new System.Drawing.Point(208, 0);
            this.panel71.Name = "panel71";
            this.panel71.Padding = new System.Windows.Forms.Padding(2, 6, 6, 2);
            this.panel71.Size = new System.Drawing.Size(80, 24);
            this.panel71.TabIndex = 0;
            // 
            // BHGMJ
            // 
            this.BHGMJ.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BHGMJ.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BHGMJ.EditScale = 0;
            this.BHGMJ.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.BHGMJ.Location = new System.Drawing.Point(2, 4);
            this.BHGMJ.Name = "BHGMJ";
            this.BHGMJ.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.BHGMJ.Properties.Appearance.Options.UseForeColor = true;
            this.BHGMJ.Properties.Appearance.Options.UseTextOptions = true;
            this.BHGMJ.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.BHGMJ.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.BHGMJ.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.BHGMJ.Properties.MaxValue = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.BHGMJ.Size = new System.Drawing.Size(40, 18);
            this.BHGMJ.TabIndex = 44;
            this.BHGMJ.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // label99
            // 
            this.label99.Dock = System.Windows.Forms.DockStyle.Right;
            this.label99.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label99.ForeColor = System.Drawing.Color.Blue;
            this.label99.Location = new System.Drawing.Point(42, 6);
            this.label99.Name = "label99";
            this.label99.Size = new System.Drawing.Size(32, 16);
            this.label99.TabIndex = 0;
            this.label99.Text = "公顷";
            // 
            // laBHGMJ
            // 
            this.laBHGMJ.Dock = System.Windows.Forms.DockStyle.Left;
            this.laBHGMJ.Location = new System.Drawing.Point(143, 0);
            this.laBHGMJ.Name = "laBHGMJ";
            this.laBHGMJ.Size = new System.Drawing.Size(65, 24);
            this.laBHGMJ.TabIndex = 0;
            this.laBHGMJ.Text = "不合格面积";
            this.laBHGMJ.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel72
            // 
            this.panel72.Controls.Add(this.HGMJ);
            this.panel72.Controls.Add(this.label98);
            this.panel72.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel72.Location = new System.Drawing.Point(53, 0);
            this.panel72.Name = "panel72";
            this.panel72.Padding = new System.Windows.Forms.Padding(2, 6, 6, 2);
            this.panel72.Size = new System.Drawing.Size(90, 24);
            this.panel72.TabIndex = 0;
            // 
            // HGMJ
            // 
            this.HGMJ.Cursor = System.Windows.Forms.Cursors.Hand;
            this.HGMJ.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.HGMJ.EditScale = 0;
            this.HGMJ.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.HGMJ.Location = new System.Drawing.Point(2, 4);
            this.HGMJ.Name = "HGMJ";
            this.HGMJ.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.HGMJ.Properties.Appearance.Options.UseForeColor = true;
            this.HGMJ.Properties.Appearance.Options.UseTextOptions = true;
            this.HGMJ.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.HGMJ.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.HGMJ.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.HGMJ.Properties.MaxValue = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.HGMJ.Size = new System.Drawing.Size(50, 18);
            this.HGMJ.TabIndex = 43;
            this.HGMJ.EditValueChanged += new System.EventHandler(this.HGMJ_EditValueChanged);
            this.HGMJ.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // label98
            // 
            this.label98.Dock = System.Windows.Forms.DockStyle.Right;
            this.label98.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label98.ForeColor = System.Drawing.Color.Blue;
            this.label98.Location = new System.Drawing.Point(52, 6);
            this.label98.Name = "label98";
            this.label98.Size = new System.Drawing.Size(32, 16);
            this.label98.TabIndex = 0;
            this.label98.Text = "公顷";
            // 
            // laHGMJ
            // 
            this.laHGMJ.Dock = System.Windows.Forms.DockStyle.Left;
            this.laHGMJ.Location = new System.Drawing.Point(0, 0);
            this.laHGMJ.Name = "laHGMJ";
            this.laHGMJ.Size = new System.Drawing.Size(53, 24);
            this.laHGMJ.TabIndex = 0;
            this.laHGMJ.Text = "合格面积";
            this.laHGMJ.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label81
            // 
            this.label81.BackColor = System.Drawing.Color.Black;
            this.label81.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label81.Location = new System.Drawing.Point(0, 24);
            this.label81.Name = "label81";
            this.label81.Size = new System.Drawing.Size(434, 1);
            this.label81.TabIndex = 0;
            this.label81.Text = "label81";
            this.label81.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel66
            // 
            this.panel66.Controls.Add(this.panel68);
            this.panel66.Controls.Add(this.laBHSYY);
            this.panel66.Controls.Add(this.panel69);
            this.panel66.Controls.Add(this.laHSMJ);
            this.panel66.Controls.Add(this.label78);
            this.panel66.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel66.Location = new System.Drawing.Point(0, 125);
            this.panel66.Name = "panel66";
            this.panel66.Size = new System.Drawing.Size(434, 25);
            this.panel66.TabIndex = 0;
            // 
            // panel68
            // 
            this.panel68.Controls.Add(this.BHSYY);
            this.panel68.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel68.Location = new System.Drawing.Point(208, 0);
            this.panel68.Name = "panel68";
            this.panel68.Padding = new System.Windows.Forms.Padding(2, 4, 4, 0);
            this.panel68.Size = new System.Drawing.Size(100, 24);
            this.panel68.TabIndex = 0;
            // 
            // BHSYY
            // 
            this.BHSYY.AssDispValue = true;
            this.BHSYY.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BHSYY.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BHSYY.ForeColor = System.Drawing.Color.Blue;
            this.BHSYY.Location = new System.Drawing.Point(2, 4);
            this.BHSYY.Name = "BHSYY";
            this.BHSYY.Size = new System.Drawing.Size(94, 20);
            this.BHSYY.TabIndex = 42;
            this.BHSYY.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // laBHSYY
            // 
            this.laBHSYY.Dock = System.Windows.Forms.DockStyle.Left;
            this.laBHSYY.Location = new System.Drawing.Point(143, 0);
            this.laBHSYY.Name = "laBHSYY";
            this.laBHSYY.Size = new System.Drawing.Size(65, 24);
            this.laBHSYY.TabIndex = 0;
            this.laBHSYY.Text = "不核实原因";
            this.laBHSYY.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel69
            // 
            this.panel69.Controls.Add(this.HSMJ);
            this.panel69.Controls.Add(this.label97);
            this.panel69.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel69.Location = new System.Drawing.Point(53, 0);
            this.panel69.Name = "panel69";
            this.panel69.Padding = new System.Windows.Forms.Padding(2, 6, 6, 2);
            this.panel69.Size = new System.Drawing.Size(90, 24);
            this.panel69.TabIndex = 0;
            // 
            // HSMJ
            // 
            this.HSMJ.Cursor = System.Windows.Forms.Cursors.Hand;
            this.HSMJ.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.HSMJ.EditScale = 0;
            this.HSMJ.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.HSMJ.Location = new System.Drawing.Point(2, 4);
            this.HSMJ.Name = "HSMJ";
            this.HSMJ.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.HSMJ.Properties.Appearance.Options.UseForeColor = true;
            this.HSMJ.Properties.Appearance.Options.UseTextOptions = true;
            this.HSMJ.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.HSMJ.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.HSMJ.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.HSMJ.Properties.MaxValue = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.HSMJ.Size = new System.Drawing.Size(50, 18);
            this.HSMJ.TabIndex = 41;
            this.HSMJ.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // label97
            // 
            this.label97.Dock = System.Windows.Forms.DockStyle.Right;
            this.label97.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label97.ForeColor = System.Drawing.Color.Blue;
            this.label97.Location = new System.Drawing.Point(52, 6);
            this.label97.Name = "label97";
            this.label97.Size = new System.Drawing.Size(32, 16);
            this.label97.TabIndex = 0;
            this.label97.Text = "公顷";
            // 
            // laHSMJ
            // 
            this.laHSMJ.Dock = System.Windows.Forms.DockStyle.Left;
            this.laHSMJ.Location = new System.Drawing.Point(0, 0);
            this.laHSMJ.Name = "laHSMJ";
            this.laHSMJ.Size = new System.Drawing.Size(53, 24);
            this.laHSMJ.TabIndex = 0;
            this.laHSMJ.Text = "核实面积";
            this.laHSMJ.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label78
            // 
            this.label78.BackColor = System.Drawing.Color.Black;
            this.label78.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label78.Location = new System.Drawing.Point(0, 24);
            this.label78.Name = "label78";
            this.label78.Size = new System.Drawing.Size(434, 1);
            this.label78.TabIndex = 0;
            this.label78.Text = "label78";
            this.label78.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel63
            // 
            this.panel63.Controls.Add(this.panel64);
            this.panel63.Controls.Add(this.laDFTZJF);
            this.panel63.Controls.Add(this.panel65);
            this.panel63.Controls.Add(this.laDFTZDJ);
            this.panel63.Controls.Add(this.label75);
            this.panel63.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel63.Location = new System.Drawing.Point(0, 100);
            this.panel63.Name = "panel63";
            this.panel63.Size = new System.Drawing.Size(434, 25);
            this.panel63.TabIndex = 0;
            // 
            // panel64
            // 
            this.panel64.Controls.Add(this.DFTZJF);
            this.panel64.Controls.Add(this.label95);
            this.panel64.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel64.Location = new System.Drawing.Point(284, 0);
            this.panel64.Name = "panel64";
            this.panel64.Padding = new System.Windows.Forms.Padding(2, 6, 6, 2);
            this.panel64.Size = new System.Drawing.Size(120, 24);
            this.panel64.TabIndex = 0;
            // 
            // DFTZJF
            // 
            this.DFTZJF.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DFTZJF.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.DFTZJF.EditScale = 0;
            this.DFTZJF.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.DFTZJF.Location = new System.Drawing.Point(2, 4);
            this.DFTZJF.Name = "DFTZJF";
            this.DFTZJF.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.DFTZJF.Properties.Appearance.Options.UseForeColor = true;
            this.DFTZJF.Properties.Appearance.Options.UseTextOptions = true;
            this.DFTZJF.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.DFTZJF.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.DFTZJF.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.DFTZJF.Properties.MaxValue = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.DFTZJF.Size = new System.Drawing.Size(87, 18);
            this.DFTZJF.TabIndex = 40;
            this.DFTZJF.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // label95
            // 
            this.label95.Dock = System.Windows.Forms.DockStyle.Right;
            this.label95.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label95.ForeColor = System.Drawing.Color.Blue;
            this.label95.Location = new System.Drawing.Point(89, 6);
            this.label95.Name = "label95";
            this.label95.Size = new System.Drawing.Size(25, 16);
            this.label95.TabIndex = 0;
            this.label95.Text = "元";
            // 
            // laDFTZJF
            // 
            this.laDFTZJF.Dock = System.Windows.Forms.DockStyle.Left;
            this.laDFTZJF.Location = new System.Drawing.Point(202, 0);
            this.laDFTZJF.Name = "laDFTZJF";
            this.laDFTZJF.Size = new System.Drawing.Size(82, 24);
            this.laDFTZJF.TabIndex = 0;
            this.laDFTZJF.Text = "地方投资经费";
            this.laDFTZJF.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel65
            // 
            this.panel65.Controls.Add(this.DFTZDJ);
            this.panel65.Controls.Add(this.label96);
            this.panel65.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel65.Location = new System.Drawing.Point(82, 0);
            this.panel65.Name = "panel65";
            this.panel65.Padding = new System.Windows.Forms.Padding(2, 6, 6, 2);
            this.panel65.Size = new System.Drawing.Size(120, 24);
            this.panel65.TabIndex = 0;
            // 
            // DFTZDJ
            // 
            this.DFTZDJ.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DFTZDJ.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.DFTZDJ.EditScale = 0;
            this.DFTZDJ.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.DFTZDJ.Location = new System.Drawing.Point(2, 4);
            this.DFTZDJ.Name = "DFTZDJ";
            this.DFTZDJ.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.DFTZDJ.Properties.Appearance.Options.UseForeColor = true;
            this.DFTZDJ.Properties.Appearance.Options.UseTextOptions = true;
            this.DFTZDJ.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.DFTZDJ.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.DFTZDJ.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.DFTZDJ.Properties.MaxValue = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.DFTZDJ.Size = new System.Drawing.Size(87, 18);
            this.DFTZDJ.TabIndex = 39;
            this.DFTZDJ.EditValueChanged += new System.EventHandler(this.DFTZDJ_EditValueChanged);
            this.DFTZDJ.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // label96
            // 
            this.label96.Dock = System.Windows.Forms.DockStyle.Right;
            this.label96.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label96.ForeColor = System.Drawing.Color.Blue;
            this.label96.Location = new System.Drawing.Point(89, 6);
            this.label96.Name = "label96";
            this.label96.Size = new System.Drawing.Size(25, 16);
            this.label96.TabIndex = 0;
            this.label96.Text = "元";
            // 
            // laDFTZDJ
            // 
            this.laDFTZDJ.Dock = System.Windows.Forms.DockStyle.Left;
            this.laDFTZDJ.Location = new System.Drawing.Point(0, 0);
            this.laDFTZDJ.Name = "laDFTZDJ";
            this.laDFTZDJ.Size = new System.Drawing.Size(82, 24);
            this.laDFTZDJ.TabIndex = 0;
            this.laDFTZDJ.Text = "地方投资单价";
            this.laDFTZDJ.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label75
            // 
            this.label75.BackColor = System.Drawing.Color.Black;
            this.label75.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label75.Location = new System.Drawing.Point(0, 24);
            this.label75.Name = "label75";
            this.label75.Size = new System.Drawing.Size(434, 1);
            this.label75.TabIndex = 0;
            this.label75.Text = "label75";
            this.label75.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel38
            // 
            this.panel38.Controls.Add(this.panel61);
            this.panel38.Controls.Add(this.laZYTZJF);
            this.panel38.Controls.Add(this.panel62);
            this.panel38.Controls.Add(this.laZYTZDJ);
            this.panel38.Controls.Add(this.label72);
            this.panel38.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel38.Location = new System.Drawing.Point(0, 75);
            this.panel38.Name = "panel38";
            this.panel38.Size = new System.Drawing.Size(434, 25);
            this.panel38.TabIndex = 0;
            // 
            // panel61
            // 
            this.panel61.Controls.Add(this.ZYTZJF);
            this.panel61.Controls.Add(this.label94);
            this.panel61.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel61.Location = new System.Drawing.Point(284, 0);
            this.panel61.Name = "panel61";
            this.panel61.Padding = new System.Windows.Forms.Padding(2, 6, 6, 2);
            this.panel61.Size = new System.Drawing.Size(120, 24);
            this.panel61.TabIndex = 0;
            // 
            // ZYTZJF
            // 
            this.ZYTZJF.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ZYTZJF.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ZYTZJF.EditScale = 0;
            this.ZYTZJF.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ZYTZJF.Location = new System.Drawing.Point(2, 4);
            this.ZYTZJF.Name = "ZYTZJF";
            this.ZYTZJF.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.ZYTZJF.Properties.Appearance.Options.UseForeColor = true;
            this.ZYTZJF.Properties.Appearance.Options.UseTextOptions = true;
            this.ZYTZJF.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.ZYTZJF.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.ZYTZJF.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.ZYTZJF.Properties.MaxValue = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.ZYTZJF.Size = new System.Drawing.Size(87, 18);
            this.ZYTZJF.TabIndex = 38;
            this.ZYTZJF.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // label94
            // 
            this.label94.Dock = System.Windows.Forms.DockStyle.Right;
            this.label94.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label94.ForeColor = System.Drawing.Color.Blue;
            this.label94.Location = new System.Drawing.Point(89, 6);
            this.label94.Name = "label94";
            this.label94.Size = new System.Drawing.Size(25, 16);
            this.label94.TabIndex = 0;
            this.label94.Text = "元";
            // 
            // laZYTZJF
            // 
            this.laZYTZJF.Dock = System.Windows.Forms.DockStyle.Left;
            this.laZYTZJF.Location = new System.Drawing.Point(202, 0);
            this.laZYTZJF.Name = "laZYTZJF";
            this.laZYTZJF.Size = new System.Drawing.Size(82, 24);
            this.laZYTZJF.TabIndex = 0;
            this.laZYTZJF.Text = "中央投资经费";
            this.laZYTZJF.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel62
            // 
            this.panel62.Controls.Add(this.ZYTZDJ);
            this.panel62.Controls.Add(this.label89);
            this.panel62.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel62.Location = new System.Drawing.Point(82, 0);
            this.panel62.Name = "panel62";
            this.panel62.Padding = new System.Windows.Forms.Padding(2, 6, 6, 2);
            this.panel62.Size = new System.Drawing.Size(120, 24);
            this.panel62.TabIndex = 0;
            // 
            // ZYTZDJ
            // 
            this.ZYTZDJ.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ZYTZDJ.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ZYTZDJ.EditScale = 0;
            this.ZYTZDJ.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ZYTZDJ.Location = new System.Drawing.Point(2, 4);
            this.ZYTZDJ.Name = "ZYTZDJ";
            this.ZYTZDJ.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.ZYTZDJ.Properties.Appearance.Options.UseForeColor = true;
            this.ZYTZDJ.Properties.Appearance.Options.UseTextOptions = true;
            this.ZYTZDJ.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.ZYTZDJ.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.ZYTZDJ.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.ZYTZDJ.Properties.MaxValue = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.ZYTZDJ.Size = new System.Drawing.Size(87, 18);
            this.ZYTZDJ.TabIndex = 37;
            this.ZYTZDJ.EditValueChanged += new System.EventHandler(this.ZYTZDJ_EditValueChanged);
            this.ZYTZDJ.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // label89
            // 
            this.label89.Dock = System.Windows.Forms.DockStyle.Right;
            this.label89.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label89.ForeColor = System.Drawing.Color.Blue;
            this.label89.Location = new System.Drawing.Point(89, 6);
            this.label89.Name = "label89";
            this.label89.Size = new System.Drawing.Size(25, 16);
            this.label89.TabIndex = 0;
            this.label89.Text = "元";
            // 
            // laZYTZDJ
            // 
            this.laZYTZDJ.Dock = System.Windows.Forms.DockStyle.Left;
            this.laZYTZDJ.Location = new System.Drawing.Point(0, 0);
            this.laZYTZDJ.Name = "laZYTZDJ";
            this.laZYTZDJ.Size = new System.Drawing.Size(82, 24);
            this.laZYTZDJ.TabIndex = 0;
            this.laZYTZDJ.Text = "中央投资单价";
            this.laZYTZDJ.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label72
            // 
            this.label72.BackColor = System.Drawing.Color.Black;
            this.label72.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label72.Location = new System.Drawing.Point(0, 24);
            this.label72.Name = "label72";
            this.label72.Size = new System.Drawing.Size(434, 1);
            this.label72.TabIndex = 0;
            this.label72.Text = "label72";
            this.label72.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel13
            // 
            this.panel13.Controls.Add(this.popupContainerControl1);
            this.panel13.Controls.Add(this.panel14);
            this.panel13.Controls.Add(this.laZJLY);
            this.panel13.Controls.Add(this.panel39);
            this.panel13.Controls.Add(this.laTFH);
            this.panel13.Controls.Add(this.label24);
            this.panel13.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel13.Location = new System.Drawing.Point(0, 50);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(434, 25);
            this.panel13.TabIndex = 0;
            // 
            // popupContainerControl1
            // 
            this.popupContainerControl1.AlwaysScrollActiveControlIntoView = false;
            this.popupContainerControl1.Controls.Add(this.ZJLY);
            this.popupContainerControl1.Location = new System.Drawing.Point(258, 23);
            this.popupContainerControl1.Name = "popupContainerControl1";
            this.popupContainerControl1.Size = new System.Drawing.Size(160, 80);
            this.popupContainerControl1.TabIndex = 0;
            // 
            // ZJLY
            // 
            this.ZJLY.ColumnWidth = 90;
            this.ZJLY.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ZJLY.Items.AddRange(new DevExpress.XtraEditors.Controls.CheckedListBoxItem[] {
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("20", "退耕"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("41", "长防国债"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("42", "长防基金"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("43", "长防农发"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("60", "速丰"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("70", "其它"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("71", "中央财政"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("72", "基建投资"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("80", "无")});
            this.ZJLY.Location = new System.Drawing.Point(0, 0);
            this.ZJLY.MultiColumn = true;
            this.ZJLY.Name = "ZJLY";
            this.ZJLY.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.ZJLY.Size = new System.Drawing.Size(160, 80);
            this.ZJLY.TabIndex = 0;
            this.ZJLY.Click += new System.EventHandler(this.ZJLY_Click);
            // 
            // panel14
            // 
            this.panel14.Controls.Add(this.popupContainerEdit1);
            this.panel14.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel14.Location = new System.Drawing.Point(299, 0);
            this.panel14.Name = "panel14";
            this.panel14.Padding = new System.Windows.Forms.Padding(2, 4, 10, 0);
            this.panel14.Size = new System.Drawing.Size(130, 24);
            this.panel14.TabIndex = 0;
            // 
            // popupContainerEdit1
            // 
            this.popupContainerEdit1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.popupContainerEdit1.EditValue = "请选择...";
            this.popupContainerEdit1.Location = new System.Drawing.Point(2, 4);
            this.popupContainerEdit1.Name = "popupContainerEdit1";
            this.popupContainerEdit1.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.popupContainerEdit1.Properties.Appearance.Options.UseForeColor = true;
            this.popupContainerEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.popupContainerEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.popupContainerEdit1.Properties.PopupControl = this.popupContainerControl1;
            this.popupContainerEdit1.Size = new System.Drawing.Size(118, 18);
            this.popupContainerEdit1.TabIndex = 36;
            this.popupContainerEdit1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // laZJLY
            // 
            this.laZJLY.Dock = System.Windows.Forms.DockStyle.Left;
            this.laZJLY.Location = new System.Drawing.Point(246, 0);
            this.laZJLY.Name = "laZJLY";
            this.laZJLY.Size = new System.Drawing.Size(53, 24);
            this.laZJLY.TabIndex = 0;
            this.laZJLY.Text = "资金来源";
            this.laZJLY.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel39
            // 
            this.panel39.Controls.Add(this.TFH);
            this.panel39.Controls.Add(this.buttonTfh);
            this.panel39.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel39.Location = new System.Drawing.Point(53, 0);
            this.panel39.Name = "panel39";
            this.panel39.Padding = new System.Windows.Forms.Padding(2, 2, 6, 1);
            this.panel39.Size = new System.Drawing.Size(193, 24);
            this.panel39.TabIndex = 0;
            // 
            // TFH
            // 
            this.TFH.Cursor = System.Windows.Forms.Cursors.Hand;
            this.TFH.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.TFH.EditValue = "";
            this.TFH.Location = new System.Drawing.Point(2, 7);
            this.TFH.Name = "TFH";
            this.TFH.Properties.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TFH.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.TFH.Properties.Appearance.Options.UseFont = true;
            this.TFH.Properties.Appearance.Options.UseForeColor = true;
            this.TFH.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.TFH.Properties.MaxLength = 50;
            this.TFH.Size = new System.Drawing.Size(145, 16);
            this.TFH.TabIndex = 35;
            this.TFH.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // buttonTfh
            // 
            this.buttonTfh.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonTfh.Location = new System.Drawing.Point(147, 2);
            this.buttonTfh.Name = "buttonTfh";
            this.buttonTfh.Size = new System.Drawing.Size(40, 21);
            this.buttonTfh.TabIndex = 36;
            this.buttonTfh.Text = "获取";
            this.buttonTfh.ToolTip = "获取图幅号";
            // 
            // laTFH
            // 
            this.laTFH.Dock = System.Windows.Forms.DockStyle.Left;
            this.laTFH.Location = new System.Drawing.Point(0, 0);
            this.laTFH.Name = "laTFH";
            this.laTFH.Size = new System.Drawing.Size(53, 24);
            this.laTFH.TabIndex = 0;
            this.laTFH.Text = "图幅号";
            this.laTFH.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            // panel51
            // 
            this.panel51.Controls.Add(this.panel58);
            this.panel51.Controls.Add(this.laZLHNAME);
            this.panel51.Controls.Add(this.panel60);
            this.panel51.Controls.Add(this.laFYFS);
            this.panel51.Controls.Add(this.panel49);
            this.panel51.Controls.Add(this.laZAO_LIN_LB);
            this.panel51.Controls.Add(this.label66);
            this.panel51.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel51.Location = new System.Drawing.Point(0, 25);
            this.panel51.Name = "panel51";
            this.panel51.Size = new System.Drawing.Size(434, 25);
            this.panel51.TabIndex = 0;
            // 
            // panel58
            // 
            this.panel58.Controls.Add(this.ZLHNAME);
            this.panel58.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel58.Location = new System.Drawing.Point(339, 0);
            this.panel58.Name = "panel58";
            this.panel58.Padding = new System.Windows.Forms.Padding(2, 6, 8, 0);
            this.panel58.Size = new System.Drawing.Size(90, 24);
            this.panel58.TabIndex = 0;
            // 
            // ZLHNAME
            // 
            this.ZLHNAME.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ZLHNAME.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ZLHNAME.EditValue = "";
            this.ZLHNAME.Location = new System.Drawing.Point(2, 6);
            this.ZLHNAME.Name = "ZLHNAME";
            this.ZLHNAME.Properties.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ZLHNAME.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.ZLHNAME.Properties.Appearance.Options.UseFont = true;
            this.ZLHNAME.Properties.Appearance.Options.UseForeColor = true;
            this.ZLHNAME.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.ZLHNAME.Properties.MaxLength = 50;
            this.ZLHNAME.Size = new System.Drawing.Size(80, 16);
            this.ZLHNAME.TabIndex = 34;
            this.ZLHNAME.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // laZLHNAME
            // 
            this.laZLHNAME.Dock = System.Windows.Forms.DockStyle.Left;
            this.laZLHNAME.Location = new System.Drawing.Point(286, 0);
            this.laZLHNAME.Name = "laZLHNAME";
            this.laZLHNAME.Size = new System.Drawing.Size(53, 24);
            this.laZLHNAME.TabIndex = 0;
            this.laZLHNAME.Text = "造林户";
            this.laZLHNAME.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel60
            // 
            this.panel60.Controls.Add(this.FYFS);
            this.panel60.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel60.Location = new System.Drawing.Point(196, 0);
            this.panel60.Name = "panel60";
            this.panel60.Padding = new System.Windows.Forms.Padding(2, 4, 4, 0);
            this.panel60.Size = new System.Drawing.Size(90, 24);
            this.panel60.TabIndex = 0;
            // 
            // FYFS
            // 
            this.FYFS.AssDispValue = true;
            this.FYFS.Cursor = System.Windows.Forms.Cursors.Hand;
            this.FYFS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FYFS.ForeColor = System.Drawing.Color.Blue;
            this.FYFS.Location = new System.Drawing.Point(2, 4);
            this.FYFS.Name = "FYFS";
            this.FYFS.Size = new System.Drawing.Size(84, 20);
            this.FYFS.TabIndex = 33;
            this.FYFS.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // laFYFS
            // 
            this.laFYFS.Dock = System.Windows.Forms.DockStyle.Left;
            this.laFYFS.Location = new System.Drawing.Point(143, 0);
            this.laFYFS.Name = "laFYFS";
            this.laFYFS.Size = new System.Drawing.Size(53, 24);
            this.laFYFS.TabIndex = 0;
            this.laFYFS.Text = "抚育方式";
            this.laFYFS.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel49
            // 
            this.panel49.Controls.Add(this.ZAO_LIN_LB);
            this.panel49.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel49.Location = new System.Drawing.Point(53, 0);
            this.panel49.Name = "panel49";
            this.panel49.Padding = new System.Windows.Forms.Padding(2, 4, 4, 0);
            this.panel49.Size = new System.Drawing.Size(90, 24);
            this.panel49.TabIndex = 0;
            // 
            // ZAO_LIN_LB
            // 
            this.ZAO_LIN_LB.AssDispValue = true;
            this.ZAO_LIN_LB.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ZAO_LIN_LB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ZAO_LIN_LB.ForeColor = System.Drawing.Color.Blue;
            this.ZAO_LIN_LB.Location = new System.Drawing.Point(2, 4);
            this.ZAO_LIN_LB.Name = "ZAO_LIN_LB";
            this.ZAO_LIN_LB.Size = new System.Drawing.Size(84, 20);
            this.ZAO_LIN_LB.TabIndex = 32;
            this.ZAO_LIN_LB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // laZAO_LIN_LB
            // 
            this.laZAO_LIN_LB.Dock = System.Windows.Forms.DockStyle.Left;
            this.laZAO_LIN_LB.Location = new System.Drawing.Point(0, 0);
            this.laZAO_LIN_LB.Name = "laZAO_LIN_LB";
            this.laZAO_LIN_LB.Size = new System.Drawing.Size(53, 24);
            this.laZAO_LIN_LB.TabIndex = 0;
            this.laZAO_LIN_LB.Text = "造林类别";
            this.laZAO_LIN_LB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label66
            // 
            this.label66.BackColor = System.Drawing.Color.Black;
            this.label66.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label66.Location = new System.Drawing.Point(0, 24);
            this.label66.Name = "label66";
            this.label66.Size = new System.Drawing.Size(434, 1);
            this.label66.TabIndex = 0;
            this.label66.Text = "label66";
            this.label66.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel50
            // 
            this.panel50.Controls.Add(this.panel52);
            this.panel50.Controls.Add(this.laZAO_LIN_MS);
            this.panel50.Controls.Add(this.panel53);
            this.panel50.Controls.Add(this.laZLND);
            this.panel50.Controls.Add(this.panel59);
            this.panel50.Controls.Add(this.laJHND);
            this.panel50.Controls.Add(this.label88);
            this.panel50.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel50.Location = new System.Drawing.Point(0, 0);
            this.panel50.Name = "panel50";
            this.panel50.Size = new System.Drawing.Size(434, 25);
            this.panel50.TabIndex = 0;
            // 
            // panel52
            // 
            this.panel52.Controls.Add(this.ZAO_LIN_MS);
            this.panel52.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel52.Location = new System.Drawing.Point(339, 0);
            this.panel52.Name = "panel52";
            this.panel52.Padding = new System.Windows.Forms.Padding(2, 6, 8, 0);
            this.panel52.Size = new System.Drawing.Size(90, 24);
            this.panel52.TabIndex = 0;
            // 
            // ZAO_LIN_MS
            // 
            this.ZAO_LIN_MS.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ZAO_LIN_MS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ZAO_LIN_MS.EditValue = "";
            this.ZAO_LIN_MS.Location = new System.Drawing.Point(2, 6);
            this.ZAO_LIN_MS.Name = "ZAO_LIN_MS";
            this.ZAO_LIN_MS.Properties.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ZAO_LIN_MS.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.ZAO_LIN_MS.Properties.Appearance.Options.UseFont = true;
            this.ZAO_LIN_MS.Properties.Appearance.Options.UseForeColor = true;
            this.ZAO_LIN_MS.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.ZAO_LIN_MS.Properties.MaxLength = 20;
            this.ZAO_LIN_MS.Size = new System.Drawing.Size(80, 16);
            this.ZAO_LIN_MS.TabIndex = 31;
            this.ZAO_LIN_MS.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // laZAO_LIN_MS
            // 
            this.laZAO_LIN_MS.Dock = System.Windows.Forms.DockStyle.Left;
            this.laZAO_LIN_MS.Location = new System.Drawing.Point(286, 0);
            this.laZAO_LIN_MS.Name = "laZAO_LIN_MS";
            this.laZAO_LIN_MS.Size = new System.Drawing.Size(53, 24);
            this.laZAO_LIN_MS.TabIndex = 0;
            this.laZAO_LIN_MS.Text = "造林模式";
            this.laZAO_LIN_MS.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel53
            // 
            this.panel53.Controls.Add(this.ZLND);
            this.panel53.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel53.Location = new System.Drawing.Point(196, 0);
            this.panel53.Name = "panel53";
            this.panel53.Padding = new System.Windows.Forms.Padding(2, 6, 8, 0);
            this.panel53.Size = new System.Drawing.Size(90, 24);
            this.panel53.TabIndex = 0;
            // 
            // ZLND
            // 
            this.ZLND.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ZLND.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ZLND.EditValue = "";
            this.ZLND.Location = new System.Drawing.Point(2, 6);
            this.ZLND.Name = "ZLND";
            this.ZLND.Properties.Appearance.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ZLND.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.ZLND.Properties.Appearance.Options.UseFont = true;
            this.ZLND.Properties.Appearance.Options.UseForeColor = true;
            this.ZLND.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.ZLND.Properties.MaxLength = 4;
            this.ZLND.Size = new System.Drawing.Size(80, 16);
            this.ZLND.TabIndex = 30;
            this.ZLND.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // laZLND
            // 
            this.laZLND.Dock = System.Windows.Forms.DockStyle.Left;
            this.laZLND.Location = new System.Drawing.Point(143, 0);
            this.laZLND.Name = "laZLND";
            this.laZLND.Size = new System.Drawing.Size(53, 24);
            this.laZLND.TabIndex = 0;
            this.laZLND.Text = "造林年度";
            this.laZLND.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel59
            // 
            this.panel59.Controls.Add(this.JHND);
            this.panel59.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel59.Location = new System.Drawing.Point(53, 0);
            this.panel59.Name = "panel59";
            this.panel59.Padding = new System.Windows.Forms.Padding(2, 2, 6, 2);
            this.panel59.Size = new System.Drawing.Size(90, 24);
            this.panel59.TabIndex = 0;
            // 
            // JHND
            // 
            this.JHND.Cursor = System.Windows.Forms.Cursors.Hand;
            this.JHND.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.JHND.EditScale = 0;
            this.JHND.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.JHND.Location = new System.Drawing.Point(2, 4);
            this.JHND.Name = "JHND";
            this.JHND.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.JHND.Properties.Appearance.Options.UseForeColor = true;
            this.JHND.Properties.Appearance.Options.UseTextOptions = true;
            this.JHND.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.JHND.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.JHND.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.JHND.Properties.MaxValue = new decimal(new int[] {
            2113,
            0,
            0,
            0});
            this.JHND.Size = new System.Drawing.Size(82, 18);
            this.JHND.TabIndex = 29;
            this.JHND.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Control_KeyPress);
            // 
            // laJHND
            // 
            this.laJHND.Dock = System.Windows.Forms.DockStyle.Left;
            this.laJHND.Location = new System.Drawing.Point(0, 0);
            this.laJHND.Name = "laJHND";
            this.laJHND.Size = new System.Drawing.Size(53, 24);
            this.laJHND.TabIndex = 0;
            this.laJHND.Text = "计划年度";
            this.laJHND.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.label91.Size = new System.Drawing.Size(1, 251);
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
            this.label92.Size = new System.Drawing.Size(1, 251);
            this.label92.TabIndex = 0;
            this.label92.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelAll
            // 
            this.panelAll.Controls.Add(this.panelAff);
            this.panelAll.Controls.Add(this.label93);
            this.panelAll.Controls.Add(this.panelWoodsInfo);
            this.panelAll.Controls.Add(this.label70);
            this.panelAll.Controls.Add(this.panelOther);
            this.panelAll.Controls.Add(this.label43);
            this.panelAll.Controls.Add(this.panelBasicInfo);
            this.panelAll.Controls.Add(this.label7);
            this.panelAll.Controls.Add(this.labelTitle);
            this.panelAll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelAll.Location = new System.Drawing.Point(2, 2);
            this.panelAll.Name = "panelAll";
            this.panelAll.Size = new System.Drawing.Size(436, 746);
            this.panelAll.TabIndex = 0;
            // 
            // label93
            // 
            this.label93.Dock = System.Windows.Forms.DockStyle.Top;
            this.label93.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label93.Location = new System.Drawing.Point(0, 461);
            this.label93.Name = "label93";
            this.label93.Size = new System.Drawing.Size(436, 26);
            this.label93.TabIndex = 0;
            this.label93.Text = "  造林情况";
            this.label93.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelOther
            // 
            this.panelOther.Controls.Add(this.panel28);
            this.panelOther.Controls.Add(this.label110);
            this.panelOther.Controls.Add(this.label111);
            this.panelOther.Controls.Add(this.label112);
            this.panelOther.Controls.Add(this.label115);
            this.panelOther.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelOther.Location = new System.Drawing.Point(0, 158);
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
            this.GXSJ.TabIndex = 52;
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
            this.BHYY.TabIndex = 51;
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
            // label43
            // 
            this.label43.Dock = System.Windows.Forms.DockStyle.Top;
            this.label43.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label43.Location = new System.Drawing.Point(0, 132);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(436, 26);
            this.label43.TabIndex = 0;
            this.label43.Text = "  变更情况";
            this.label43.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            // UserControlAffAttr
            // 
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panelAll);
            this.Name = "UserControlAffAttr";
            this.Padding = new System.Windows.Forms.Padding(2);
            this.Size = new System.Drawing.Size(440, 750);
            this.panelBasicInfo.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel16.ResumeLayout(false);
            this.panel19.ResumeLayout(false);
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
            this.panel15.ResumeLayout(false);
            this.panel30.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SSZZS.Properties)).EndInit();
            this.panel32.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MEI_GQ_ZS.Properties)).EndInit();
            this.panel26.ResumeLayout(false);
            this.panel27.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.LD_CD.Properties)).EndInit();
            this.panel29.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.LD_KD.Properties)).EndInit();
            this.panel37.ResumeLayout(false);
            this.panel18.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MIAN_JI.Properties)).EndInit();
            this.panel67.ResumeLayout(false);
            this.panel31.ResumeLayout(false);
            this.panel33.ResumeLayout(false);
            this.panel34.ResumeLayout(false);
            this.panel100.ResumeLayout(false);
            this.panel12.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.panel42.ResumeLayout(false);
            this.panel57.ResumeLayout(false);
            this.panel56.ResumeLayout(false);
            this.panel35.ResumeLayout(false);
            this.panel54.ResumeLayout(false);
            this.panel55.ResumeLayout(false);
            this.panel41.ResumeLayout(false);
            this.panel43.ResumeLayout(false);
            this.panel44.ResumeLayout(false);
            this.panel21.ResumeLayout(false);
            this.panel24.ResumeLayout(false);
            this.panel25.ResumeLayout(false);
            this.panel45.ResumeLayout(false);
            this.panel23.ResumeLayout(false);
            this.panel46.ResumeLayout(false);
            this.panelAff.ResumeLayout(false);
            this.panel36.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel17.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.BZ.Properties)).EndInit();
            this.panel40.ResumeLayout(false);
            this.panel47.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.JCSJ.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.JCSJ.Properties)).EndInit();
            this.panel48.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.JCRY.Properties)).EndInit();
            this.panel73.ResumeLayout(false);
            this.panel74.ResumeLayout(false);
            this.panel75.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SSMJ.Properties)).EndInit();
            this.panel70.ResumeLayout(false);
            this.panel76.ResumeLayout(false);
            this.panel71.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.BHGMJ.Properties)).EndInit();
            this.panel72.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.HGMJ.Properties)).EndInit();
            this.panel66.ResumeLayout(false);
            this.panel68.ResumeLayout(false);
            this.panel69.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.HSMJ.Properties)).EndInit();
            this.panel63.ResumeLayout(false);
            this.panel64.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DFTZJF.Properties)).EndInit();
            this.panel65.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DFTZDJ.Properties)).EndInit();
            this.panel38.ResumeLayout(false);
            this.panel61.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ZYTZJF.Properties)).EndInit();
            this.panel62.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ZYTZDJ.Properties)).EndInit();
            this.panel13.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.popupContainerControl1)).EndInit();
            this.popupContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ZJLY)).EndInit();
            this.panel14.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.popupContainerEdit1.Properties)).EndInit();
            this.panel39.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TFH.Properties)).EndInit();
            this.panel51.ResumeLayout(false);
            this.panel58.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ZLHNAME.Properties)).EndInit();
            this.panel60.ResumeLayout(false);
            this.panel49.ResumeLayout(false);
            this.panel50.ResumeLayout(false);
            this.panel52.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ZAO_LIN_MS.Properties)).EndInit();
            this.panel53.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ZLND.Properties)).EndInit();
            this.panel59.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.JHND.Properties)).EndInit();
            this.panelAll.ResumeLayout(false);
            this.panelOther.ResumeLayout(false);
            this.panel28.ResumeLayout(false);
            this.panel86.ResumeLayout(false);
            this.panel91.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GXSJ.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GXSJ.Properties)).EndInit();
            this.panel92.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        public void InitZJLY()
        {
            if (this.ZJLY.CheckedItemsCount < 1)
            {
                this.popupContainerEdit1.EditValue = "请选择…";
            }
            else
            {
                string str = "";
                int num2 = 0;
                for (int i = 0; i < this.ZJLY.Items.Count; i++)
                {
                    if (this.ZJLY.Items[i].CheckState == CheckState.Checked)
                    {
                        num2++;
                        str = str + "," + this.ZJLY.Items[i].Description.ToString();
                    }
                }
                this.popupContainerEdit1.EditValue = str.Substring(1);
            }
        }

        private void MEI_GQ_ZS_EditValueChanged(object sender, EventArgs e)
        {
            if (this.ZAO_LIN_LB.GetSelectedName() == "农地造林")
            {
                decimal num = this.MEI_GQ_ZS.Value;
                if (num > 0M)
                {
                    decimal num2 = num / 15M;
                    if (num2 > 110M)
                    {
                        MessageBox.Show("您填的株数已经超过每亩110株了，不符合农地造林密度", "提示");
                        this.MEI_GQ_ZS.Value = 0.0M;
                    }
                }
            }
        }

        private void popupContainerEdit1_Closed(object sender, ClosedEventArgs e)
        {
            this.InitZJLY();
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

        private void SSZZS_EditValueChanged(object sender, EventArgs e)
        {
            if (this.ZAO_LIN_LB.GetSelectedName() == "城镇绿化")
            {
                decimal num = this.MIAN_JI.Value;
                if (num > 0M)
                {
                    decimal num2 = this.SSZZS.Value;
                    if (num2 > 0M)
                    {
                        decimal num3 = (num2 / num) / 15M;
                        if (num3 > 110M)
                        {
                            MessageBox.Show("您填的株数已经超过每亩110株了，不符合城镇绿化造林密度", "提示");
                            this.SSZZS.Value = 0.0M;
                        }
                    }
                }
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

        private void ZAO_LIN_LB_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (this.ZAO_LIN_LB.GetSelectedName())
            {
                case "农地造林":
                {
                    decimal num = this.MEI_GQ_ZS.Value;
                    if (num > 0M)
                    {
                        decimal num2 = num / 15M;
                        if (num2 > 110M)
                        {
                            MessageBox.Show("您填的株数已经超过每亩110株了，不符合农地造林密度", "提示");
                            this.MEI_GQ_ZS.Value = 0.0M;
                            return;
                        }
                    }
                    break;
                }
                case "城镇绿化":
                {
                    decimal num3 = this.MIAN_JI.Value;
                    if (num3 <= 0M)
                    {
                        return;
                    }
                    decimal num4 = this.SSZZS.Value;
                    if (num4 > 0M)
                    {
                        decimal num5 = (num4 / num3) / 15M;
                        if (num5 > 110M)
                        {
                            MessageBox.Show("您填的株数已经超过每亩110株了，不符合城镇绿化造林密度", "提示");
                            this.SSZZS.Value = 0.0M;
                        }
                    }
                    break;
                }
            }
        }

        private void ZJLY_Click(object sender, EventArgs e)
        {
            if (this.ZJLY.CheckedItemsCount > 6)
            {
                MessageBox.Show("资金来源选择不能超过6个！");
                int num2 = 0;
                for (int i = 0; i < this.ZJLY.Items.Count; i++)
                {
                    if (this.ZJLY.Items[i].CheckState == CheckState.Checked)
                    {
                        num2++;
                        if (num2 > 6)
                        {
                            this.ZJLY.Items[i].CheckState = CheckState.Unchecked;
                        }
                    }
                }
            }
        }

        private void ZJLY_ItemCheck(object sender, DevExpress.XtraEditors.Controls.ItemCheckEventArgs e)
        {
        }

        private void ZYTZDJ_EditValueChanged(object sender, EventArgs e)
        {
            decimal num = this.HGMJ.Value;
            if (num > 0M)
            {
                this.ZYTZJF.Value = this.ZYTZDJ.Value * num;
            }
        }

        public delegate void SetTfhhandler();
    }
}

