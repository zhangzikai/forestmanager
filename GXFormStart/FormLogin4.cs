namespace GXFormStart
{
    using DevExpress.Utils;
    using DevExpress.XtraEditors;
    using ESRI.ArcGIS.Controls;
    using GXFormStart.Properties;
    using OperateLog;
    using System;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Drawing;
    using System.Windows.Forms;
    using Utilities;
    using System.Collections.Generic;
    using jn.isos.log;

    public class FormLogin4 : Form
    {
        private AxLicenseControl axLicenseControl1;
        public bool CancelFlag;
        private IContainer components;
        public string EditKind = "小班";
        private ImageList imageList1;
        private ImageList imageList2;
        public ImageList imageList3;
        private ImageList imageList4;
        private ImageList imageList5;
        public ImageList imageList6;
        private Label label0;
        public Label label1;
        public Label label2;
        private Label label2DView;
        private Label label3DView;
        private Label labelAJ;
        private Label labelCF;
        private Label labelEdit;
        private Label labelexit;
        private Label labelGC;
        private Label labelHZ;
        protected Label LabelLoadInfo;
        private Label labelmod1;
        private Label labelmod11;
        private Label labelmod2;
        private Label labelmod21;
        private Label labelmod22;
        private Label labelmod3;
        private Label labelmod31;
        protected Label LabelProgressBack;
        protected Label LabelProgressBar;
        private Label labelQuery;
        private Label labelSys;
        private Label labelSys2;
        public Label labelV;
        private Label labelXB;
        private Label labelXB2;
        private Label labelXB3;
        private Label labelYG;
        private Label labelZH;
        private Label labelZL;
        private Label labelZZY;
        public Timer m_Timer;
        private DateTime mStartTime;
        public Panel panelLogin;
        public Panel panelProgress;
        public SimpleButton simpleButtonCancel;
        public SimpleButton simpleButtonOK;
        public TextEdit textEdit1;
        public TextEdit textEdit2;
        public ToolTipController toolTipController1;
        private IDictionary<string, Image> m_imageDict;
        private Logger m_log = LoggerManager.CreateLogger("UI", typeof(FormLogin4));
        public FormLogin4()
        {
            m_log.Warn("FormLogin4 begin...");
            this.m_Timer = new Timer();
            m_imageDict = new Dictionary<string, Image>(10);
            this.InitializeComponent();
            this.m_Timer = new Timer();
            m_log.Warn("FormLogin4 over.");
        }
        private Image FindImage(string imagName)
        {
            if (m_imageDict.ContainsKey(imagName))
            {
                return m_imageDict[imagName];
            }
            else
            {
                Image img = null;
                try
                {
                    img = Image.FromFile(Application.StartupPath + @"\skin\" + imagName);
                }
                catch { }
                if (null != img)
                {
                    m_imageDict.Add(imagName, img);
                }
                return img;
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

        private void FormLogin_Load(object sender, EventArgs e)
        {
            string configValue = UtilFactory.GetConfigOpt().GetConfigValue("LoginUserID");
            string resource = "000.png";
            this.labelmod22.Image = FindImage(resource);
            this.BackgroundImage = FindImage(resource);
            if (configValue == "")
            {
                this.textEdit1.Text = "admin";
            }
            else
            {
                this.textEdit1.Text = configValue;
            }
            this.textEdit2.Text = "";
            this.m_Timer.Interval = 300;
            this.m_Timer.Start();
            this.labelSys2.Visible = true;
            this.panelLogin.Tag = this.panelLogin.Left;
        }

        private void FormLogin4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\x001b')
            {
                this.CancelFlag = true;
                base.Hide();
            }
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLogin4));
            this.labelmod3 = new System.Windows.Forms.Label();
            this.labelmod2 = new System.Windows.Forms.Label();
            this.labelmod1 = new System.Windows.Forms.Label();
            this.labelSys2 = new System.Windows.Forms.Label();
            this.panelLogin = new System.Windows.Forms.Panel();
            this.simpleButtonCancel = new DevExpress.XtraEditors.SimpleButton();
            this.imageList3 = new System.Windows.Forms.ImageList();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
            this.textEdit2 = new DevExpress.XtraEditors.TextEdit();
            this.simpleButtonOK = new DevExpress.XtraEditors.SimpleButton();
            this.imageList6 = new System.Windows.Forms.ImageList();
            this.toolTipController1 = new DevExpress.Utils.ToolTipController();
            this.labelZH = new System.Windows.Forms.Label();
            this.imageList2 = new System.Windows.Forms.ImageList();
            this.labelZL = new System.Windows.Forms.Label();
            this.labelHZ = new System.Windows.Forms.Label();
            this.labelAJ = new System.Windows.Forms.Label();
            this.labelGC = new System.Windows.Forms.Label();
            this.labelZZY = new System.Windows.Forms.Label();
            this.labelCF = new System.Windows.Forms.Label();
            this.labelSys = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList();
            this.labelEdit = new System.Windows.Forms.Label();
            this.labelQuery = new System.Windows.Forms.Label();
            this.label3DView = new System.Windows.Forms.Label();
            this.imageList5 = new System.Windows.Forms.ImageList();
            this.label2DView = new System.Windows.Forms.Label();
            this.labelXB2 = new System.Windows.Forms.Label();
            this.labelXB = new System.Windows.Forms.Label();
            this.labelexit = new System.Windows.Forms.Label();
            this.imageList4 = new System.Windows.Forms.ImageList();
            this.labelYG = new System.Windows.Forms.Label();
            this.labelXB3 = new System.Windows.Forms.Label();
            this.labelmod11 = new System.Windows.Forms.Label();
            this.labelmod21 = new System.Windows.Forms.Label();
            this.labelmod22 = new System.Windows.Forms.Label();
            this.labelmod31 = new System.Windows.Forms.Label();
            this.panelProgress = new System.Windows.Forms.Panel();
            this.LabelLoadInfo = new System.Windows.Forms.Label();
            this.LabelProgressBar = new System.Windows.Forms.Label();
            this.LabelProgressBack = new System.Windows.Forms.Label();
            this.label0 = new System.Windows.Forms.Label();
            this.axLicenseControl1 = new ESRI.ArcGIS.Controls.AxLicenseControl();
            this.labelV = new System.Windows.Forms.Label();
            this.panelLogin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit2.Properties)).BeginInit();
            this.panelProgress.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelmod3
            // 
            this.labelmod3.BackColor = System.Drawing.Color.Transparent;
            this.labelmod3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelmod3.Location = new System.Drawing.Point(131, 166);
            this.labelmod3.Name = "labelmod3";
            this.labelmod3.Size = new System.Drawing.Size(150, 143);
            this.labelmod3.TabIndex = 34;
            this.labelmod3.Click += new System.EventHandler(this.labelmod3_Click);
            // 
            // labelmod2
            // 
            this.labelmod2.BackColor = System.Drawing.Color.Transparent;
            this.labelmod2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelmod2.Location = new System.Drawing.Point(496, 250);
            this.labelmod2.Name = "labelmod2";
            this.labelmod2.Size = new System.Drawing.Size(150, 143);
            this.labelmod2.TabIndex = 33;
            this.labelmod2.Visible = false;
            this.labelmod2.Click += new System.EventHandler(this.labelmod2_Click);
            // 
            // labelmod1
            // 
            this.labelmod1.BackColor = System.Drawing.Color.Transparent;
            this.labelmod1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelmod1.Location = new System.Drawing.Point(398, 166);
            this.labelmod1.Name = "labelmod1";
            this.labelmod1.Size = new System.Drawing.Size(150, 143);
            this.labelmod1.TabIndex = 32;
            this.labelmod1.Click += new System.EventHandler(this.labelmod1_Click);
            // 
            // labelSys2
            // 
            this.labelSys2.BackColor = System.Drawing.Color.Transparent;
            this.labelSys2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelSys2.ImageIndex = 11;
            this.labelSys2.Location = new System.Drawing.Point(663, 166);
            this.labelSys2.Name = "labelSys2";
            this.labelSys2.Size = new System.Drawing.Size(151, 140);
            this.labelSys2.TabIndex = 55;
            this.labelSys2.Tag = "系统管理";
            this.labelSys2.Visible = false;
            this.labelSys2.Click += new System.EventHandler(this.labelSys2_Click);
            // 
            // panelLogin
            // 
            this.panelLogin.BackColor = System.Drawing.Color.Transparent;
            this.panelLogin.Controls.Add(this.simpleButtonCancel);
            this.panelLogin.Controls.Add(this.label1);
            this.panelLogin.Controls.Add(this.label2);
            this.panelLogin.Controls.Add(this.textEdit1);
            this.panelLogin.Controls.Add(this.textEdit2);
            this.panelLogin.Controls.Add(this.simpleButtonOK);
            this.panelLogin.Location = new System.Drawing.Point(543, 462);
            this.panelLogin.Name = "panelLogin";
            this.panelLogin.Size = new System.Drawing.Size(256, 76);
            this.panelLogin.TabIndex = 56;
            this.panelLogin.Visible = false;
            // 
            // simpleButtonCancel
            // 
            this.simpleButtonCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.simpleButtonCancel.ImageIndex = 3;
            this.simpleButtonCancel.ImageList = this.imageList3;
            this.simpleButtonCancel.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.simpleButtonCancel.Location = new System.Drawing.Point(164, 45);
            this.simpleButtonCancel.Name = "simpleButtonCancel";
            this.simpleButtonCancel.Size = new System.Drawing.Size(70, 26);
            this.simpleButtonCancel.TabIndex = 8;
            this.simpleButtonCancel.Visible = false;
            this.simpleButtonCancel.Click += new System.EventHandler(this.simpleButtonCancel_Click);
            this.simpleButtonCancel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.simpleButtonCancel_MouseDown);
            this.simpleButtonCancel.MouseEnter += new System.EventHandler(this.simpleButtonCancel_MouseEnter);
            this.simpleButtonCancel.MouseLeave += new System.EventHandler(this.simpleButtonCancel_MouseLeave);
            this.simpleButtonCancel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.simpleButtonCancel_MouseUp);
            // 
            // imageList3
            // 
            this.imageList3.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList3.ImageStream")));
            this.imageList3.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList3.Images.SetKeyName(0, "sjcj_login_03.png");
            this.imageList3.Images.SetKeyName(1, "sjcj_login_03dowen.png");
            this.imageList3.Images.SetKeyName(2, "sjcj_login_03up.png");
            this.imageList3.Images.SetKeyName(3, "sjcj_login_04.png");
            this.imageList3.Images.SetKeyName(4, "sjcj_login_04dowen.png");
            this.imageList3.Images.SetKeyName(5, "sjcj_login_04up.png");
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(9, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "用户名:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(9, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "密码:";
            // 
            // textEdit1
            // 
            this.textEdit1.EditValue = "";
            this.textEdit1.Location = new System.Drawing.Point(58, 8);
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.Properties.Appearance.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textEdit1.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.textEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.textEdit1.Properties.Appearance.Options.UseForeColor = true;
            this.textEdit1.Size = new System.Drawing.Size(100, 20);
            this.textEdit1.TabIndex = 0;
            this.textEdit1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textEdit1_KeyPress);
            // 
            // textEdit2
            // 
            this.textEdit2.EditValue = "";
            this.textEdit2.Location = new System.Drawing.Point(58, 49);
            this.textEdit2.Name = "textEdit2";
            this.textEdit2.Properties.Appearance.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textEdit2.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.textEdit2.Properties.Appearance.Options.UseBackColor = true;
            this.textEdit2.Properties.Appearance.Options.UseForeColor = true;
            this.textEdit2.Properties.PasswordChar = '*';
            this.textEdit2.Size = new System.Drawing.Size(100, 20);
            this.textEdit2.TabIndex = 1;
            this.textEdit2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textEdit2_KeyPress);
            // 
            // simpleButtonOK
            // 
            this.simpleButtonOK.Cursor = System.Windows.Forms.Cursors.Hand;
            this.simpleButtonOK.ImageIndex = 0;
            this.simpleButtonOK.ImageList = this.imageList6;
            this.simpleButtonOK.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.simpleButtonOK.Location = new System.Drawing.Point(164, 45);
            this.simpleButtonOK.Name = "simpleButtonOK";
            this.simpleButtonOK.Size = new System.Drawing.Size(70, 26);
            this.simpleButtonOK.TabIndex = 2;
            this.simpleButtonOK.Click += new System.EventHandler(this.simpleButtonOK_Click);
            this.simpleButtonOK.MouseDown += new System.Windows.Forms.MouseEventHandler(this.simpleButtonOK_MouseDown);
            this.simpleButtonOK.MouseEnter += new System.EventHandler(this.simpleButtonOK_MouseEnter);
            this.simpleButtonOK.MouseLeave += new System.EventHandler(this.simpleButtonOK_MouseLeave);
            this.simpleButtonOK.MouseUp += new System.Windows.Forms.MouseEventHandler(this.simpleButtonOK_MouseUp);
            // 
            // imageList6
            // 
            this.imageList6.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList6.ImageStream")));
            this.imageList6.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList6.Images.SetKeyName(0, "登录.png");
            this.imageList6.Images.SetKeyName(1, "登录3.png");
            this.imageList6.Images.SetKeyName(2, "登录2.png");
            // 
            // labelZH
            // 
            this.labelZH.BackColor = System.Drawing.Color.Transparent;
            this.labelZH.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelZH.ImageIndex = 10;
            this.labelZH.ImageList = this.imageList2;
            this.labelZH.Location = new System.Drawing.Point(693, 358);
            this.labelZH.Name = "labelZH";
            this.labelZH.Size = new System.Drawing.Size(90, 90);
            this.labelZH.TabIndex = 63;
            this.labelZH.Tag = "自然灾害";
            this.toolTipController1.SetTitle(this.labelZH, "其它灾害");
            this.labelZH.Visible = false;
            this.labelZH.Click += new System.EventHandler(this.labelCF_Click);
            // 
            // imageList2
            // 
            this.imageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList2.ImageStream")));
            this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList2.Images.SetKeyName(0, "zaolin0.png");
            this.imageList2.Images.SetKeyName(1, "zaolin.png");
            this.imageList2.Images.SetKeyName(2, "caifa0.png");
            this.imageList2.Images.SetKeyName(3, "caifa.png");
            this.imageList2.Images.SetKeyName(4, "zzy0.png");
            this.imageList2.Images.SetKeyName(5, "zzy.png");
            this.imageList2.Images.SetKeyName(6, "huozai0.png");
            this.imageList2.Images.SetKeyName(7, "huozai.png");
            this.imageList2.Images.SetKeyName(8, "anjian0.png");
            this.imageList2.Images.SetKeyName(9, "anjian.png");
            this.imageList2.Images.SetKeyName(10, "zaihai0.png");
            this.imageList2.Images.SetKeyName(11, "zaihai.png");
            // 
            // labelZL
            // 
            this.labelZL.BackColor = System.Drawing.Color.Transparent;
            this.labelZL.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelZL.ImageIndex = 0;
            this.labelZL.ImageList = this.imageList2;
            this.labelZL.Location = new System.Drawing.Point(151, 359);
            this.labelZL.Name = "labelZL";
            this.labelZL.Size = new System.Drawing.Size(90, 90);
            this.labelZL.TabIndex = 57;
            this.labelZL.Tag = "造林";
            this.toolTipController1.SetTitle(this.labelZL, "造林作业");
            this.labelZL.Visible = false;
            this.labelZL.Click += new System.EventHandler(this.labelCF_Click);
            // 
            // labelHZ
            // 
            this.labelHZ.BackColor = System.Drawing.Color.Transparent;
            this.labelHZ.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelHZ.ImageIndex = 6;
            this.labelHZ.ImageList = this.imageList2;
            this.labelHZ.Location = new System.Drawing.Point(485, 358);
            this.labelHZ.Name = "labelHZ";
            this.labelHZ.Size = new System.Drawing.Size(90, 90);
            this.labelHZ.TabIndex = 62;
            this.labelHZ.Tag = "火灾";
            this.toolTipController1.SetTitle(this.labelHZ, "森林火灾");
            this.labelHZ.Visible = false;
            this.labelHZ.Click += new System.EventHandler(this.labelCF_Click);
            // 
            // labelAJ
            // 
            this.labelAJ.BackColor = System.Drawing.Color.Transparent;
            this.labelAJ.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelAJ.ImageIndex = 8;
            this.labelAJ.ImageList = this.imageList2;
            this.labelAJ.Location = new System.Drawing.Point(588, 358);
            this.labelAJ.Name = "labelAJ";
            this.labelAJ.Size = new System.Drawing.Size(90, 90);
            this.labelAJ.TabIndex = 61;
            this.labelAJ.Tag = "林业案件";
            this.toolTipController1.SetTitle(this.labelAJ, "林业案件");
            this.labelAJ.Visible = false;
            this.labelAJ.Click += new System.EventHandler(this.labelCF_Click);
            // 
            // labelGC
            // 
            this.labelGC.BackColor = System.Drawing.Color.Transparent;
            this.labelGC.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelGC.Location = new System.Drawing.Point(0, 361);
            this.labelGC.Name = "labelGC";
            this.labelGC.Size = new System.Drawing.Size(84, 86);
            this.labelGC.TabIndex = 60;
            this.labelGC.Tag = "林业工程";
            this.toolTipController1.SetTitle(this.labelGC, "林业工程");
            this.labelGC.Visible = false;
            this.labelGC.Click += new System.EventHandler(this.labelCF_Click);
            // 
            // labelZZY
            // 
            this.labelZZY.BackColor = System.Drawing.Color.Transparent;
            this.labelZZY.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelZZY.ImageIndex = 4;
            this.labelZZY.ImageList = this.imageList2;
            this.labelZZY.Location = new System.Drawing.Point(372, 358);
            this.labelZZY.Name = "labelZZY";
            this.labelZZY.Size = new System.Drawing.Size(90, 90);
            this.labelZZY.TabIndex = 59;
            this.labelZZY.Tag = "征占用";
            this.toolTipController1.SetTitle(this.labelZZY, "林地征占用");
            this.labelZZY.Visible = false;
            this.labelZZY.Click += new System.EventHandler(this.labelCF_Click);
            // 
            // labelCF
            // 
            this.labelCF.BackColor = System.Drawing.Color.Transparent;
            this.labelCF.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelCF.ImageIndex = 2;
            this.labelCF.ImageList = this.imageList2;
            this.labelCF.Location = new System.Drawing.Point(260, 358);
            this.labelCF.Name = "labelCF";
            this.labelCF.Size = new System.Drawing.Size(90, 90);
            this.labelCF.TabIndex = 58;
            this.labelCF.Tag = "采伐";
            this.toolTipController1.SetTitle(this.labelCF, "采伐作业");
            this.labelCF.Visible = false;
            this.labelCF.Click += new System.EventHandler(this.labelCF_Click);
            // 
            // labelSys
            // 
            this.labelSys.BackColor = System.Drawing.Color.Transparent;
            this.labelSys.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelSys.ImageIndex = 4;
            this.labelSys.ImageList = this.imageList1;
            this.labelSys.Location = new System.Drawing.Point(411, 486);
            this.labelSys.Name = "labelSys";
            this.labelSys.Size = new System.Drawing.Size(107, 43);
            this.labelSys.TabIndex = 68;
            this.labelSys.Tag = "系统管理";
            this.toolTipController1.SetTitle(this.labelSys, "系统管理与数据维护");
            this.labelSys.Visible = false;
            this.labelSys.Click += new System.EventHandler(this.label_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.White;
            this.imageList1.Images.SetKeyName(0, "edit0.png");
            this.imageList1.Images.SetKeyName(1, "edit.png");
            this.imageList1.Images.SetKeyName(2, "query0.png");
            this.imageList1.Images.SetKeyName(3, "query.png");
            this.imageList1.Images.SetKeyName(4, "sys0.png");
            this.imageList1.Images.SetKeyName(5, "sys.png");
            // 
            // labelEdit
            // 
            this.labelEdit.BackColor = System.Drawing.Color.Transparent;
            this.labelEdit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelEdit.ImageIndex = 0;
            this.labelEdit.ImageList = this.imageList1;
            this.labelEdit.Location = new System.Drawing.Point(174, 486);
            this.labelEdit.Name = "labelEdit";
            this.labelEdit.Size = new System.Drawing.Size(107, 43);
            this.labelEdit.TabIndex = 66;
            this.labelEdit.Tag = "数据编辑";
            this.toolTipController1.SetTitle(this.labelEdit, "数据编辑");
            this.labelEdit.Visible = false;
            this.labelEdit.Click += new System.EventHandler(this.label_Click);
            // 
            // labelQuery
            // 
            this.labelQuery.BackColor = System.Drawing.Color.Transparent;
            this.labelQuery.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelQuery.ImageIndex = 2;
            this.labelQuery.ImageList = this.imageList1;
            this.labelQuery.Location = new System.Drawing.Point(315, 486);
            this.labelQuery.Name = "labelQuery";
            this.labelQuery.Size = new System.Drawing.Size(107, 43);
            this.labelQuery.TabIndex = 67;
            this.labelQuery.Tag = "查询统计";
            this.toolTipController1.SetTitle(this.labelQuery, "查询统计");
            this.labelQuery.Visible = false;
            this.labelQuery.Click += new System.EventHandler(this.label_Click);
            // 
            // label3DView
            // 
            this.label3DView.BackColor = System.Drawing.Color.Transparent;
            this.label3DView.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label3DView.ImageIndex = 4;
            this.label3DView.ImageList = this.imageList5;
            this.label3DView.Location = new System.Drawing.Point(164, 358);
            this.label3DView.Name = "label3DView";
            this.label3DView.Size = new System.Drawing.Size(113, 90);
            this.label3DView.TabIndex = 69;
            this.label3DView.Tag = "3DView";
            this.toolTipController1.SetTitle(this.label3DView, "三维电子沙盘");
            this.label3DView.Visible = false;
            this.label3DView.Click += new System.EventHandler(this.label3DView_Click);
            // 
            // imageList5
            // 
            this.imageList5.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList5.ImageStream")));
            this.imageList5.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList5.Images.SetKeyName(0, "bgbj0.png");
            this.imageList5.Images.SetKeyName(1, "bgbj.png");
            this.imageList5.Images.SetKeyName(2, "ndbj0.png");
            this.imageList5.Images.SetKeyName(3, "ndbj.png");
            this.imageList5.Images.SetKeyName(4, "sanwei0.png");
            this.imageList5.Images.SetKeyName(5, "sanwei.png");
            this.imageList5.Images.SetKeyName(6, "erwei0.png");
            this.imageList5.Images.SetKeyName(7, "erwei.png");
            this.imageList5.Images.SetKeyName(8, "ygbj0.png");
            this.imageList5.Images.SetKeyName(9, "ygbj.png");
            this.imageList5.Images.SetKeyName(10, "lcbj0.png");
            this.imageList5.Images.SetKeyName(11, "lcbj.png");
            // 
            // label2DView
            // 
            this.label2DView.BackColor = System.Drawing.Color.Transparent;
            this.label2DView.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label2DView.ImageIndex = 6;
            this.label2DView.ImageList = this.imageList5;
            this.label2DView.Location = new System.Drawing.Point(336, 357);
            this.label2DView.Name = "label2DView";
            this.label2DView.Size = new System.Drawing.Size(113, 90);
            this.label2DView.TabIndex = 70;
            this.label2DView.Tag = "2DView";
            this.toolTipController1.SetTitle(this.label2DView, "二维浏览查看");
            this.label2DView.Visible = false;
            this.label2DView.Click += new System.EventHandler(this.label2DView_Click);
            // 
            // labelXB2
            // 
            this.labelXB2.BackColor = System.Drawing.Color.Transparent;
            this.labelXB2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelXB2.ImageIndex = 2;
            this.labelXB2.ImageList = this.imageList5;
            this.labelXB2.Location = new System.Drawing.Point(466, 354);
            this.labelXB2.Name = "labelXB2";
            this.labelXB2.Size = new System.Drawing.Size(113, 90);
            this.labelXB2.TabIndex = 74;
            this.labelXB2.Tag = "年度变更";
            this.toolTipController1.SetTitle(this.labelXB2, "小班年度编辑");
            this.labelXB2.Visible = false;
            this.labelXB2.Click += new System.EventHandler(this.labelXB2_Click);
            // 
            // labelXB
            // 
            this.labelXB.BackColor = System.Drawing.Color.Transparent;
            this.labelXB.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelXB.ImageIndex = 0;
            this.labelXB.ImageList = this.imageList5;
            this.labelXB.Location = new System.Drawing.Point(313, 355);
            this.labelXB.Name = "labelXB";
            this.labelXB.Size = new System.Drawing.Size(113, 90);
            this.labelXB.TabIndex = 73;
            this.labelXB.Tag = "小班变更";
            this.toolTipController1.SetTitle(this.labelXB, "小班变更编辑");
            this.labelXB.Visible = false;
            this.labelXB.Click += new System.EventHandler(this.labelXB_Click);
            // 
            // labelexit
            // 
            this.labelexit.BackColor = System.Drawing.Color.Transparent;
            this.labelexit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelexit.ImageIndex = 0;
            this.labelexit.ImageList = this.imageList4;
            this.labelexit.Location = new System.Drawing.Point(757, 566);
            this.labelexit.Name = "labelexit";
            this.labelexit.Size = new System.Drawing.Size(42, 42);
            this.labelexit.TabIndex = 78;
            this.labelexit.Tag = "";
            this.toolTipController1.SetTitle(this.labelexit, "退出");
            this.labelexit.Click += new System.EventHandler(this.labelexit_Click);
            this.labelexit.MouseDown += new System.Windows.Forms.MouseEventHandler(this.labelexit_MouseDown);
            this.labelexit.MouseEnter += new System.EventHandler(this.labelexit_MouseEnter);
            this.labelexit.MouseLeave += new System.EventHandler(this.labelexit_MouseLeave);
            this.labelexit.MouseUp += new System.Windows.Forms.MouseEventHandler(this.labelexit_MouseUp);
            // 
            // imageList4
            // 
            this.imageList4.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList4.ImageStream")));
            this.imageList4.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList4.Images.SetKeyName(0, "exit0.png");
            this.imageList4.Images.SetKeyName(1, "exit1.png");
            this.imageList4.Images.SetKeyName(2, "exit3.png");
            // 
            // labelYG
            // 
            this.labelYG.BackColor = System.Drawing.Color.Transparent;
            this.labelYG.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelYG.ImageIndex = 8;
            this.labelYG.ImageList = this.imageList5;
            this.labelYG.Location = new System.Drawing.Point(164, 355);
            this.labelYG.Name = "labelYG";
            this.labelYG.Size = new System.Drawing.Size(113, 90);
            this.labelYG.TabIndex = 79;
            this.labelYG.Tag = "遥感编辑";
            this.toolTipController1.SetTitle(this.labelYG, "遥感变更编辑");
            this.labelYG.Visible = false;
            this.labelYG.Click += new System.EventHandler(this.labelYG_Click);
            // 
            // labelXB3
            // 
            this.labelXB3.BackColor = System.Drawing.Color.Transparent;
            this.labelXB3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelXB3.ImageIndex = 10;
            this.labelXB3.ImageList = this.imageList5;
            this.labelXB3.Location = new System.Drawing.Point(620, 355);
            this.labelXB3.Name = "labelXB3";
            this.labelXB3.Size = new System.Drawing.Size(113, 90);
            this.labelXB3.TabIndex = 81;
            this.labelXB3.Tag = "二类变化";
            this.toolTipController1.SetTitle(this.labelXB3, "林场变更编辑");
            this.labelXB3.Visible = false;
            this.labelXB3.Click += new System.EventHandler(this.labelXB3_Click);
            // 
            // labelmod11
            // 
            this.labelmod11.BackColor = System.Drawing.Color.Transparent;
            this.labelmod11.Cursor = System.Windows.Forms.Cursors.Default;
            this.labelmod11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelmod11.Location = new System.Drawing.Point(0, 0);
            this.labelmod11.Name = "labelmod11";
            this.labelmod11.Size = new System.Drawing.Size(945, 617);
            this.labelmod11.TabIndex = 64;
            this.labelmod11.Visible = false;
            // 
            // labelmod21
            // 
            this.labelmod21.BackColor = System.Drawing.Color.White;
            this.labelmod21.Cursor = System.Windows.Forms.Cursors.Default;
            this.labelmod21.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelmod21.Location = new System.Drawing.Point(0, 0);
            this.labelmod21.Name = "labelmod21";
            this.labelmod21.Size = new System.Drawing.Size(945, 617);
            this.labelmod21.TabIndex = 65;
            this.labelmod21.Visible = false;
            // 
            // labelmod22
            // 
            this.labelmod22.BackColor = System.Drawing.Color.Transparent;
            this.labelmod22.Cursor = System.Windows.Forms.Cursors.Default;
            this.labelmod22.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelmod22.Location = new System.Drawing.Point(0, 0);
            this.labelmod22.Name = "labelmod22";
            this.labelmod22.Size = new System.Drawing.Size(945, 617);
            this.labelmod22.TabIndex = 71;
            this.labelmod22.Visible = false;
            // 
            // labelmod31
            // 
            this.labelmod31.BackColor = System.Drawing.Color.Transparent;
            this.labelmod31.Cursor = System.Windows.Forms.Cursors.Default;
            this.labelmod31.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelmod31.Location = new System.Drawing.Point(0, 0);
            this.labelmod31.Name = "labelmod31";
            this.labelmod31.Size = new System.Drawing.Size(945, 617);
            this.labelmod31.TabIndex = 72;
            this.labelmod31.Visible = false;
            // 
            // panelProgress
            // 
            this.panelProgress.BackColor = System.Drawing.Color.Transparent;
            this.panelProgress.Controls.Add(this.LabelLoadInfo);
            this.panelProgress.Controls.Add(this.LabelProgressBar);
            this.panelProgress.Controls.Add(this.LabelProgressBack);
            this.panelProgress.Location = new System.Drawing.Point(540, 488);
            this.panelProgress.Name = "panelProgress";
            this.panelProgress.Size = new System.Drawing.Size(264, 32);
            this.panelProgress.TabIndex = 75;
            this.panelProgress.Visible = false;
            // 
            // LabelLoadInfo
            // 
            this.LabelLoadInfo.BackColor = System.Drawing.Color.Transparent;
            this.LabelLoadInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.LabelLoadInfo.Location = new System.Drawing.Point(30, 3);
            this.LabelLoadInfo.Name = "LabelLoadInfo";
            this.LabelLoadInfo.Size = new System.Drawing.Size(258, 19);
            this.LabelLoadInfo.TabIndex = 12;
            this.LabelLoadInfo.Text = "系统启动中, 请稍候...";
            this.LabelLoadInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LabelProgressBar
            // 
            this.LabelProgressBar.BackColor = System.Drawing.Color.Gold;
            this.LabelProgressBar.Location = new System.Drawing.Point(3, 27);
            this.LabelProgressBar.Name = "LabelProgressBar";
            this.LabelProgressBar.Size = new System.Drawing.Size(117, 2);
            this.LabelProgressBar.TabIndex = 13;
            // 
            // LabelProgressBack
            // 
            this.LabelProgressBack.BackColor = System.Drawing.Color.White;
            this.LabelProgressBack.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LabelProgressBack.ForeColor = System.Drawing.Color.White;
            this.LabelProgressBack.Location = new System.Drawing.Point(2, 26);
            this.LabelProgressBack.Name = "LabelProgressBack";
            this.LabelProgressBack.Size = new System.Drawing.Size(260, 4);
            this.LabelProgressBack.TabIndex = 11;
            // 
            // label0
            // 
            this.label0.BackColor = System.Drawing.Color.Transparent;
            this.label0.Cursor = System.Windows.Forms.Cursors.Default;
            this.label0.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label0.Location = new System.Drawing.Point(0, 0);
            this.label0.Name = "label0";
            this.label0.Size = new System.Drawing.Size(945, 617);
            this.label0.TabIndex = 76;
            this.label0.Visible = false;
            // 
            // axLicenseControl1
            // 
            this.axLicenseControl1.Enabled = true;
            this.axLicenseControl1.Location = new System.Drawing.Point(40, 443);
            this.axLicenseControl1.Name = "axLicenseControl1";
            this.axLicenseControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axLicenseControl1.OcxState")));
            this.axLicenseControl1.Size = new System.Drawing.Size(32, 32);
            this.axLicenseControl1.TabIndex = 77;
            // 
            // labelV
            // 
            this.labelV.AutoSize = true;
            this.labelV.BackColor = System.Drawing.Color.Transparent;
            this.labelV.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.labelV.Location = new System.Drawing.Point(38, 575);
            this.labelV.Name = "labelV";
            this.labelV.Size = new System.Drawing.Size(29, 12);
            this.labelV.TabIndex = 80;
            this.labelV.Text = "v1.0";
            // 
            // FormLogin4
            // 
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(945, 617);
            this.Controls.Add(this.labelXB3);
            this.Controls.Add(this.labelV);
            this.Controls.Add(this.labelYG);
            this.Controls.Add(this.labelexit);
            this.Controls.Add(this.axLicenseControl1);
            this.Controls.Add(this.labelSys2);
            this.Controls.Add(this.panelProgress);
            this.Controls.Add(this.labelXB2);
            this.Controls.Add(this.labelXB);
            this.Controls.Add(this.label3DView);
            this.Controls.Add(this.label2DView);
            this.Controls.Add(this.labelSys);
            this.Controls.Add(this.labelEdit);
            this.Controls.Add(this.labelQuery);
            this.Controls.Add(this.labelZH);
            this.Controls.Add(this.labelZL);
            this.Controls.Add(this.labelHZ);
            this.Controls.Add(this.labelAJ);
            this.Controls.Add(this.labelGC);
            this.Controls.Add(this.labelZZY);
            this.Controls.Add(this.labelCF);
            this.Controls.Add(this.panelLogin);
            this.Controls.Add(this.labelmod3);
            this.Controls.Add(this.labelmod2);
            this.Controls.Add(this.labelmod1);
            this.Controls.Add(this.labelmod11);
            this.Controls.Add(this.label0);
            this.Controls.Add(this.labelmod21);
            this.Controls.Add(this.labelmod22);
            this.Controls.Add(this.labelmod31);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormLogin4";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "登录";
            this.Load += new System.EventHandler(this.FormLogin_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FormLogin4_KeyPress);
            this.panelLogin.ResumeLayout(false);
            this.panelLogin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit2.Properties)).EndInit();
            this.panelProgress.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void label_Click(object sender, EventArgs e)
        {
            if ((sender as Label) == this.labelEdit)
            {
                this.labelEdit.ImageIndex = 1;
            }
            else
            {
                this.labelEdit.ImageIndex = 0;
            }
            if ((sender as Label) == this.labelQuery)
            {
                this.labelQuery.ImageIndex = 3;
            }
            else
            {
                this.labelQuery.ImageIndex = 2;
            }
            if ((sender as Label) == this.labelSys)
            {
                this.labelSys.ImageIndex = 5;
            }
            else
            {
                this.labelSys.ImageIndex = 4;
            }
            string[] strArray = this.EditKind.Split(new char[] { '-' });
            this.EditKind = strArray[0] + "-" + (sender as Label).Tag.ToString();
            this.panelLogin.Visible = true;
            this.panelLogin.Enabled = true;
            this.simpleButtonOK.ImageIndex = 1;
        }

        private void label2DView_Click(object sender, EventArgs e)
        {
            this.EditKind = "年度小班";
            this.EditKind = this.EditKind + "-二维浏览";
            this.panelLogin.Visible = true;
            this.panelLogin.Enabled = true;
            this.simpleButtonOK.ImageIndex = 0;
            this.label2DView.ImageIndex = 7;
            this.label3DView.ImageIndex = 4;
        }

        private void label3DView_Click(object sender, EventArgs e)
        {
            this.EditKind = "年度小班";
            this.EditKind = this.EditKind + "-三维浏览";
            this.panelLogin.Visible = true;
            this.panelLogin.Enabled = true;
            this.simpleButtonOK.ImageIndex = 0;
            this.label3DView.ImageIndex = 5;
            this.label2DView.ImageIndex = 6;
        }

        private void labelCF_Click(object sender, EventArgs e)
        {
            if (((((sender as Label).ImageIndex == 0) || ((sender as Label).ImageIndex == 2)) || (((sender as Label).ImageIndex == 4) || ((sender as Label).ImageIndex == 6))) || (((sender as Label).ImageIndex == 8) || ((sender as Label).ImageIndex == 10)))
            {
                (sender as Label).ImageIndex++;
            }
            if ((sender as Label) == this.labelZL)
            {
                if ((sender as Label).ImageIndex != 0)
                {
                    this.labelZL.ImageIndex = 1;
                }
            }
            else
            {
                this.labelZL.ImageIndex = 0;
            }
            if ((sender as Label) == this.labelCF)
            {
                if ((sender as Label).ImageIndex != 0)
                {
                    this.labelCF.ImageIndex = 3;
                }
            }
            else
            {
                this.labelCF.ImageIndex = 2;
            }
            if ((sender as Label) == this.labelZZY)
            {
                if ((sender as Label).ImageIndex != 0)
                {
                    this.labelZZY.ImageIndex = 5;
                }
            }
            else
            {
                this.labelZZY.ImageIndex = 4;
            }
            if ((sender as Label) == this.labelHZ)
            {
                if ((sender as Label).ImageIndex != 0)
                {
                    this.labelHZ.ImageIndex = 7;
                }
            }
            else
            {
                this.labelHZ.ImageIndex = 6;
            }
            if ((sender as Label) == this.labelAJ)
            {
                if ((sender as Label).ImageIndex != 0)
                {
                    this.labelAJ.ImageIndex = 9;
                }
            }
            else
            {
                this.labelAJ.ImageIndex = 8;
            }
            if ((sender as Label) == this.labelZH)
            {
                if ((sender as Label).ImageIndex != 0)
                {
                    this.labelZH.ImageIndex = 11;
                }
            }
            else
            {
                this.labelZH.ImageIndex = 10;
            }
            this.EditKind = (sender as Label).Tag.ToString();
            string[] strArray = this.EditKind.Split(new char[] { '-' });
            this.EditKind = strArray[0] + "-数据编辑";
            this.panelLogin.Visible = true;
            this.panelLogin.Enabled = true;
            this.simpleButtonOK.ImageIndex = 0;
        }

        private void labelexit_Click(object sender, EventArgs e)
        {
            this.CancelFlag = true;
            base.Close();
        }

        private void labelexit_MouseDown(object sender, MouseEventArgs e)
        {
            this.labelexit.ImageIndex = 2;
        }

        private void labelexit_MouseEnter(object sender, EventArgs e)
        {
            this.labelexit.ImageIndex = 1;
        }

        private void labelexit_MouseLeave(object sender, EventArgs e)
        {
            this.labelexit.ImageIndex = 0;
        }

        private void labelexit_MouseUp(object sender, MouseEventArgs e)
        {
            this.labelexit.ImageIndex = 1;
        }

        private void labelmod1_Click(object sender, EventArgs e)
        {
            if (!this.labelmod21.Visible && !this.labelmod22.Visible)
            {
                this.labelZL.Visible = false;
                this.labelCF.Visible = false;
                this.labelZZY.Visible = false;
                this.labelZH.Visible = false;
                this.labelHZ.Visible = false;
                this.labelAJ.Visible = false;
                this.labelXB.Visible = false;
                this.labelXB2.Visible = false;
                this.labelXB3.Visible = false;
                this.labelYG.Visible = false;
                this.labelEdit.Visible = false;
                this.labelQuery.Visible = false;
                this.labelSys.Visible = false;
                this.panelLogin.Visible = false;
                this.panelLogin.Enabled = false;
                this.labelmod31.Visible = false;
                this.labelmod21.Visible = false;
                this.labelmod22.Visible = false;
                this.labelmod11.Visible = false;
                this.label2DView.Visible = false;
                this.label3DView.Visible = false;
                this.label0.Visible = true;
                this.EditKind = "造林-数据编辑";
                //string resource = "000.png";
                //this.label0.Image = FindImage(resource);
                //this.BackgroundImage = FindImage(resource);
                this.panelLogin.Visible = true;
                this.panelLogin.Enabled = true;
                textEdit2.Text = "1234";
                this.simpleButtonOK.ImageIndex = 0;
            }
        }

        private void labelmod2_Click(object sender, EventArgs e)
        {
            if (!this.labelmod11.Visible)
            {
                this.labelEdit.Visible = false;
                this.labelQuery.Visible = false;
                this.labelSys.Visible = false;
                this.labelXB.ImageIndex = 0;
                this.labelXB2.ImageIndex = 2;
                this.labelXB3.ImageIndex = 10;
                this.labelYG.ImageIndex = 8;
                this.label0.Visible = true;
                this.labelZL.Visible = false;
                this.labelCF.Visible = false;
                this.labelZZY.Visible = false;
                this.labelZH.Visible = false;
                this.labelHZ.Visible = false;
                this.labelAJ.Visible = false;
                this.label2DView.Visible = false;
                this.label3DView.Visible = false;
                this.labelmod11.Visible = true;
                this.labelmod21.Visible = false;
                this.labelmod22.Visible = false;
                this.labelmod31.Visible = false;
                this.panelLogin.Visible = false;
                string resource = "330.png";
                this.labelmod11.Image = FindImage(resource);
                this.BackgroundImage = FindImage(resource);
                this.labelXB.Visible = true;
                this.labelXB.BringToFront();
                this.labelXB2.Visible = true;
                this.labelXB2.BringToFront();
                this.labelXB3.Visible = true;
                this.labelXB3.BringToFront();
                this.labelYG.Visible = true;
                this.labelYG.BringToFront();
                this.panelLogin.Visible = false;
                this.panelLogin.Enabled = false;
            }
        }

        private void labelmod3_Click(object sender, EventArgs e)
        {
            if (!this.labelmod31.Visible)
            {
                this.label2DView.ImageIndex = 6;
                this.label3DView.ImageIndex = 4;
                this.label0.Visible = true;
                this.labelZL.Visible = false;
                this.labelCF.Visible = false;
                this.labelZZY.Visible = false;
                this.labelZH.Visible = false;
                this.labelHZ.Visible = false;
                this.labelAJ.Visible = false;
                this.labelXB.Visible = false;
                this.labelXB2.Visible = false;
                this.labelXB3.Visible = false;
                this.labelYG.Visible = false;
                this.panelLogin.Visible = false;
                this.panelLogin.Enabled = false;
                this.labelmod31.Visible = true;
                this.labelmod21.Visible = false;
                this.labelmod22.Visible = false;
                this.labelmod11.Visible = false;
                this.labelmod11.Visible = false;
                this.labelmod21.Visible = false;
                this.labelmod22.Visible = false;
              //  this.label2DView.Visible = true;
             //   this.label2DView.BringToFront();
              //  this.label3DView.Visible = true;
              //  this.label3DView.BringToFront();
                this.labelEdit.Visible = false;
                this.labelQuery.Visible = false;
                this.labelSys.Visible = false;
                //string resource = "110.png";
                //this.labelmod31.Image = FindImage(resource);
                //this.labelmod31.Refresh();
                //this.BackgroundImage = FindImage(resource);
                this.EditKind = "年度小班";
                this.EditKind = this.EditKind + "-二维浏览";
                this.panelLogin.Visible = true;
                this.panelLogin.Enabled = true;
                textEdit2.Text = "1234";
                this.Refresh();
            }
        }

        private void labelQuery_Click(object sender, EventArgs e)
        {
        }

        private void labelSys_Click(object sender, EventArgs e)
        {
        }

        private void labelSys2_Click(object sender, EventArgs e)
        {
            this.labelZL.Visible = false;
            this.labelCF.Visible = false;
            this.labelZZY.Visible = false;
            this.labelZH.Visible = false;
            this.labelHZ.Visible = false;
            this.labelAJ.Visible = false;
            this.labelXB.Visible = false;
            this.labelXB2.Visible = false;
            this.labelXB3.Visible = false;
            this.labelYG.Visible = false;
            this.labelEdit.Visible = false;
            this.labelQuery.Visible = false;
            this.labelSys.Visible = false;
            this.panelLogin.Visible = false;
            this.panelLogin.Enabled = false;
            this.labelmod31.Visible = false;
            this.labelmod21.Visible = false;
            this.labelmod22.Visible = false;
            this.labelmod11.Visible = false;
            this.label2DView.Visible = false;
            this.label3DView.Visible = false;
            this.label0.Visible = true;
            this.EditKind = "系统管理";
            //string resource = "000.png";
            //this.label0.Image = FindImage(resource);
            //this.BackgroundImage = FindImage(resource);
            this.panelLogin.Visible = true;
            this.panelLogin.Enabled = true;
            textEdit2.Text = "1234";
            this.simpleButtonOK.ImageIndex = 0;
        }

        private void labelXB_Click(object sender, EventArgs e)
        {
            this.labelXB2.ImageIndex = 2;
            this.labelXB.ImageIndex = 1;
            this.labelYG.ImageIndex = 8;
            this.labelXB3.ImageIndex = 10;
            this.EditKind = "小班变更";
            this.EditKind = this.EditKind + "-数据编辑";
            this.panelLogin.Visible = true;
            this.panelLogin.Enabled = true;
            this.simpleButtonOK.ImageIndex = 0;
        }

        private void labelXB2_Click(object sender, EventArgs e)
        {
            this.labelXB2.ImageIndex = 3;
            this.labelXB.ImageIndex = 0;
            this.labelYG.ImageIndex = 8;
            this.labelXB3.ImageIndex = 10;
            this.EditKind = "年度小班";
            this.EditKind = this.EditKind + "-数据编辑";
            this.panelLogin.Visible = true;
            this.panelLogin.Enabled = true;
            this.simpleButtonOK.ImageIndex = 0;
        }

        private void labelXB3_Click(object sender, EventArgs e)
        {
            this.labelXB3.ImageIndex = 11;
            this.labelXB2.ImageIndex = 2;
            this.labelXB.ImageIndex = 0;
            this.labelYG.ImageIndex = 8;
            this.EditKind = "二类变化";
            this.EditKind = this.EditKind + "-数据编辑";
            this.panelLogin.Visible = true;
            this.panelLogin.Enabled = true;
            this.simpleButtonOK.ImageIndex = 0;
        }

        private void labelYG_Click(object sender, EventArgs e)
        {
            this.labelYG.ImageIndex = 9;
            this.labelXB.ImageIndex = 0;
            this.labelXB2.ImageIndex = 2;
            this.EditKind = "遥感";
            this.EditKind = this.EditKind + "-数据编辑";
            this.panelLogin.Visible = true;
            this.panelLogin.Enabled = true;
            this.simpleButtonOK.ImageIndex = 0;
        }

        private void labelZL_Click(object sender, EventArgs e)
        {
            this.labelmod21.Visible = false;
            this.labelmod22.Visible = true;
            this.labelmod31.Visible = false;
            this.labelmod11.Visible = false;
            string resource = "221.png";
            this.labelmod22.Image = FindImage(resource);
            this.BackgroundImage = FindImage(resource);
            this.panelLogin.Visible = false;
            this.panelLogin.Enabled = true;
            this.panelLogin.Top = (sender as Label).Top;
            this.EditKind = (sender as Label).Tag.ToString();
        }

        private void m_Timer_Tick(object sender, EventArgs e)
        {
            if (!this.CancelFlag)
            {
                if (this.panelProgress.Visible)
                {
                    this.LabelLoadInfo.Refresh();
                    this.LabelProgressBack.Refresh();
                    this.LabelProgressBar.Refresh();
                }
                string processName = "GXFormMainFrame";
                if (Process.GetProcessesByName(processName).Length == 1)
                {
                    this.panelProgress.Visible = true;
                    this.Cursor = Cursors.WaitCursor;
                    base.Hide();
                }
                else
                {
                    this.Cursor = Cursors.Default;
                    this.panelProgress.Visible = false;
                    base.TopLevel = true;
                    base.Show();
                }
            }
        }

        public void SetLoadInfo(string sInfo, int iValue)
        {
            try
            {
                this.LabelLoadInfo.Text = sInfo;
                this.LabelProgressBar.Width = ((this.LabelProgressBack.Width - 2) * iValue) / 100;
                this.LabelProgressBar.BringToFront();
                this.Refresh();
            }
            catch (Exception)
            {
            }
        }

        private void simpleButtonCancel_Click(object sender, EventArgs e)
        {
            this.CancelFlag = true;
            this.panelLogin.Visible = false;
            base.Hide();
        }

        private void simpleButtonCancel_MouseDown(object sender, MouseEventArgs e)
        {
            this.simpleButtonCancel.ImageIndex = 5;
        }

        private void simpleButtonCancel_MouseEnter(object sender, EventArgs e)
        {
            this.simpleButtonCancel.ImageIndex = 4;
        }

        private void simpleButtonCancel_MouseLeave(object sender, EventArgs e)
        {
            this.simpleButtonCancel.ImageIndex = 3;
        }

        private void simpleButtonCancel_MouseUp(object sender, MouseEventArgs e)
        {
            this.simpleButtonCancel.ImageIndex = 3;
        }

        private void simpleButtonOK_Click(object sender, EventArgs e)
        {
            string sUserName = this.textEdit1.Text.Trim();
            if (sUserName == "")
            {
                MessageBox.Show(this, "请输入用户名", "系统登录", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                this.textEdit1.Focus();
            }
            else
            {
                string sPasswrd = this.textEdit2.Text.Trim();
                if (sPasswrd == "")
                {
                    MessageBox.Show(this, "请输入密码", "系统登录", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    this.textEdit2.Focus();
                }
                else
                {
                    string sResponse = "";
                    string[] strArray = this.EditKind.Split(new char[] { '-' });
                    ////登录系统被注销
                    ////if ((strArray.Length > 1) && ((strArray[1] == "三维浏览") || (strArray[1] == "二维浏览")))
                    ////{
                    ////    if (!UserManage.Login(sUserName, sPasswrd, strArray[1], out sResponse))
                    ////    {
                    ////        MessageBox.Show(this, sResponse, "系统登录", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    ////        return;
                    ////    }
                    ////}
                    ////else if (!UserManage.Login(sUserName, sPasswrd, strArray[0], out sResponse))
                    ////{
                    ////    MessageBox.Show(this, sResponse, "系统登录", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    ////    return;
                    ////}
                    UtilFactory.GetConfigOpt2().SetConfigValue("LoginUserID", sUserName);
                    this.panelLogin.Visible = false;
                    this.panelProgress.Visible = true;
                    this.LabelLoadInfo.Text = "正在加载主窗体...";
                    this.panelProgress.Refresh();
                    Application.DoEvents();
                    Process process = new Process();
                    string proPath=Application.StartupPath + @"\GXFormMainFrame.exe";
                    m_log.Warn("启动:"+proPath);
                    ProcessStartInfo info = new ProcessStartInfo(proPath, this.EditKind);
                    process.StartInfo = info;
                    process.StartInfo.UseShellExecute = false;                 
                    process.Start();
                    this.SetLoadInfo("正在设置系统界面...", 20);
                    this.Cursor = Cursors.WaitCursor;
                    this.m_Timer.Tick += new EventHandler(this.m_Timer_Tick);
                    this.m_Timer.Interval = 600;
                    this.m_Timer.Start();
                    this.mStartTime = DateTime.Now;
                }
            }
        }

        private void simpleButtonOK_MouseDown(object sender, MouseEventArgs e)
        {
            this.simpleButtonOK.ImageIndex = 2;
        }

        private void simpleButtonOK_MouseEnter(object sender, EventArgs e)
        {
            this.simpleButtonOK.ImageIndex = 1;
        }

        private void simpleButtonOK_MouseLeave(object sender, EventArgs e)
        {
            this.simpleButtonOK.ImageIndex = 0;
        }

        private void simpleButtonOK_MouseUp(object sender, MouseEventArgs e)
        {
            this.simpleButtonOK.ImageIndex = 0;
        }

        private void textEdit1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                this.textEdit2.Focus();
            }
            if (e.KeyChar == '\x001b')
            {
                this.CancelFlag = true;
                base.Hide();
            }
        }

        private void textEdit2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                this.simpleButtonOK_Click(sender, e);
            }
            if (e.KeyChar == '\x001b')
            {
                this.CancelFlag = true;
                base.Hide();
            }
        }
    }
}

