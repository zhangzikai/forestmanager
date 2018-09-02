namespace GXFormStart
{
    using DevExpress.Utils;
    using DevExpress.XtraEditors;
    using ESRI.ArcGIS.Controls;
    using GXFormStart.Properties;
    using OperateLog;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Utilities;

    public class FormLogin : Form
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
        private Label labelXB;
        private Label labelXB2;
        private Label labelZH;
        private Label labelZL;
        private Label labelZZY;
        public Timer m_Timer = new Timer();
        public Panel panelLogin;
        public Panel panelProgress;
        public SimpleButton simpleButtonCancel;
        public SimpleButton simpleButtonOK;
        public TextEdit textEdit1;
        public TextEdit textEdit2;
        public ToolTipController toolTipController1;

        public FormLogin()
        {
            this.InitializeComponent();
            this.m_Timer.Tick += new EventHandler(this.m_Timer_Tick);
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
            this.components = new Container();
            ComponentResourceManager resources = new ComponentResourceManager(typeof(FormLogin));
            this.labelmod3 = new Label();
            this.labelmod2 = new Label();
            this.labelmod1 = new Label();
            this.labelSys2 = new Label();
            this.panelLogin = new Panel();
            this.simpleButtonCancel = new SimpleButton();
            this.imageList3 = new ImageList(this.components);
            this.label1 = new Label();
            this.label2 = new Label();
            this.textEdit1 = new TextEdit();
            this.textEdit2 = new TextEdit();
            this.simpleButtonOK = new SimpleButton();
            this.toolTipController1 = new ToolTipController(this.components);
            this.labelZH = new Label();
            this.imageList2 = new ImageList(this.components);
            this.labelZL = new Label();
            this.labelHZ = new Label();
            this.labelAJ = new Label();
            this.labelGC = new Label();
            this.labelZZY = new Label();
            this.labelCF = new Label();
            this.labelSys = new Label();
            this.imageList1 = new ImageList(this.components);
            this.labelEdit = new Label();
            this.labelQuery = new Label();
            this.label3DView = new Label();
            this.imageList5 = new ImageList(this.components);
            this.label2DView = new Label();
            this.labelXB2 = new Label();
            this.labelXB = new Label();
            this.labelexit = new Label();
            this.imageList4 = new ImageList(this.components);
            this.labelmod11 = new Label();
            this.labelmod21 = new Label();
            this.labelmod22 = new Label();
            this.labelmod31 = new Label();
            this.panelProgress = new Panel();
            this.LabelLoadInfo = new Label();
            this.LabelProgressBar = new Label();
            this.LabelProgressBack = new Label();
            this.label0 = new Label();
            this.axLicenseControl1 = new AxLicenseControl();
            this.panelLogin.SuspendLayout();
            this.textEdit1.Properties.BeginInit();
            this.textEdit2.Properties.BeginInit();
            this.panelProgress.SuspendLayout();
            this.axLicenseControl1.BeginInit();
            base.SuspendLayout();
            this.labelmod3.BackColor = Color.Transparent;
            this.labelmod3.Cursor = Cursors.Hand;
            this.labelmod3.Location = new Point(0x58, 0xa9);
            this.labelmod3.Name = "labelmod3";
            this.labelmod3.Size = new Size(150, 0x8f);
            this.labelmod3.TabIndex = 0x22;
            this.labelmod3.Click += new EventHandler(this.labelmod3_Click);
            this.labelmod2.BackColor = Color.Transparent;
            this.labelmod2.Cursor = Cursors.Hand;
            this.labelmod2.Location = new Point(500, 0xac);
            this.labelmod2.Name = "labelmod2";
            this.labelmod2.Size = new Size(150, 0x8f);
            this.labelmod2.TabIndex = 0x21;
            this.labelmod2.Click += new EventHandler(this.labelmod2_Click);
            this.labelmod1.BackColor = Color.Transparent;
            this.labelmod1.Cursor = Cursors.Hand;
            this.labelmod1.Location = new Point(0x124, 0xac);
            this.labelmod1.Name = "labelmod1";
            this.labelmod1.Size = new Size(150, 0x8f);
            this.labelmod1.TabIndex = 0x20;
            this.labelmod1.Click += new EventHandler(this.labelmod1_Click);
            this.labelSys2.BackColor = Color.Transparent;
            this.labelSys2.Cursor = Cursors.Hand;
            this.labelSys2.ImageIndex = 11;
            this.labelSys2.Location = new Point(710, 0xac);
            this.labelSys2.Name = "labelSys2";
            this.labelSys2.Size = new Size(0x97, 140);
            this.labelSys2.TabIndex = 0x37;
            this.labelSys2.Tag = "系统管理";
            this.labelSys2.Visible = false;
            this.labelSys2.Click += new EventHandler(this.labelSys2_Click);
            this.panelLogin.BackColor = Color.Transparent;
            this.panelLogin.Controls.Add(this.simpleButtonCancel);
            this.panelLogin.Controls.Add(this.label1);
            this.panelLogin.Controls.Add(this.label2);
            this.panelLogin.Controls.Add(this.textEdit1);
            this.panelLogin.Controls.Add(this.textEdit2);
            this.panelLogin.Controls.Add(this.simpleButtonOK);
            this.panelLogin.Location = new Point(0x21f, 0x1ce);
            this.panelLogin.Name = "panelLogin";
            this.panelLogin.Size = new Size(0x100, 0x4c);
            this.panelLogin.TabIndex = 0x38;
            this.panelLogin.Visible = false;
            this.simpleButtonCancel.Cursor = Cursors.Hand;
            this.simpleButtonCancel.ImageIndex = 3;
            this.simpleButtonCancel.ImageList = this.imageList3;
            this.simpleButtonCancel.ImageLocation = ImageLocation.MiddleCenter;
            this.simpleButtonCancel.Location = new Point(0xa4, 0x2d);
            this.simpleButtonCancel.Name = "simpleButtonCancel";
            this.simpleButtonCancel.Size = new Size(0x49, 0x1a);
            this.simpleButtonCancel.TabIndex = 8;
            this.simpleButtonCancel.MouseLeave += new EventHandler(this.simpleButtonCancel_MouseLeave);
            this.simpleButtonCancel.Click += new EventHandler(this.simpleButtonCancel_Click);
            this.simpleButtonCancel.MouseDown += new MouseEventHandler(this.simpleButtonCancel_MouseDown);
            this.simpleButtonCancel.MouseUp += new MouseEventHandler(this.simpleButtonCancel_MouseUp);
            this.simpleButtonCancel.MouseEnter += new EventHandler(this.simpleButtonCancel_MouseEnter);
            this.imageList3.ImageStream = (ImageListStreamer)resources.GetObject("imageList3.ImageStream");
            this.imageList3.TransparentColor = Color.Transparent;
            this.imageList3.Images.SetKeyName(0, "sjcj_login_03.png");
            this.imageList3.Images.SetKeyName(1, "sjcj_login_03dowen.png");
            this.imageList3.Images.SetKeyName(2, "sjcj_login_03up.png");
            this.imageList3.Images.SetKeyName(3, "sjcj_login_04.png");
            this.imageList3.Images.SetKeyName(4, "sjcj_login_04dowen.png");
            this.imageList3.Images.SetKeyName(5, "sjcj_login_04up.png");
            this.label1.AutoSize = true;
            this.label1.BackColor = Color.Transparent;
            this.label1.ForeColor = Color.FromArgb(0, 0, 0x40);
            this.label1.Location = new Point(9, 12);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0x2f, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "用户名:";
            this.label2.AutoSize = true;
            this.label2.BackColor = Color.Transparent;
            this.label2.ForeColor = Color.FromArgb(0, 0, 0x40);
            this.label2.Location = new Point(9, 0x34);
            this.label2.Name = "label2";
            this.label2.Size = new Size(0x23, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "密码:";
            this.textEdit1.EditValue = "";
            this.textEdit1.Location = new Point(0x3a, 8);
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.Properties.Appearance.BackColor = Color.WhiteSmoke;
            this.textEdit1.Properties.Appearance.ForeColor = Color.FromArgb(0, 0, 0x40);
            this.textEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.textEdit1.Properties.Appearance.Options.UseForeColor = true;
            this.textEdit1.Size = new Size(100, 0x15);
            this.textEdit1.TabIndex = 0;
            this.textEdit1.KeyPress += new KeyPressEventHandler(this.textEdit1_KeyPress);
            this.textEdit2.EditValue = "";
            this.textEdit2.Location = new Point(0x3a, 0x31);
            this.textEdit2.Name = "textEdit2";
            this.textEdit2.Properties.Appearance.BackColor = Color.WhiteSmoke;
            this.textEdit2.Properties.Appearance.ForeColor = Color.FromArgb(0, 0, 0x40);
            this.textEdit2.Properties.Appearance.Options.UseBackColor = true;
            this.textEdit2.Properties.Appearance.Options.UseForeColor = true;
            this.textEdit2.Properties.PasswordChar = '*';
            this.textEdit2.Size = new Size(100, 0x15);
            this.textEdit2.TabIndex = 1;
            this.textEdit2.KeyPress += new KeyPressEventHandler(this.textEdit2_KeyPress);
            this.simpleButtonOK.Cursor = Cursors.Hand;
            this.simpleButtonOK.ImageIndex = 0;
            this.simpleButtonOK.ImageList = this.imageList3;
            this.simpleButtonOK.ImageLocation = ImageLocation.MiddleCenter;
            this.simpleButtonOK.Location = new Point(0xa3, 4);
            this.simpleButtonOK.Name = "simpleButtonOK";
            this.simpleButtonOK.Size = new Size(0x4a, 0x1a);
            this.simpleButtonOK.TabIndex = 2;
            this.simpleButtonOK.MouseLeave += new EventHandler(this.simpleButtonOK_MouseLeave);
            this.simpleButtonOK.Click += new EventHandler(this.simpleButtonOK_Click);
            this.simpleButtonOK.MouseDown += new MouseEventHandler(this.simpleButtonOK_MouseDown);
            this.simpleButtonOK.MouseUp += new MouseEventHandler(this.simpleButtonOK_MouseUp);
            this.simpleButtonOK.MouseEnter += new EventHandler(this.simpleButtonOK_MouseEnter);
            this.labelZH.BackColor = Color.Transparent;
            this.labelZH.Cursor = Cursors.Hand;
            this.labelZH.ImageIndex = 10;
            this.labelZH.ImageList = this.imageList2;
            this.labelZH.Location = new Point(0x2b5, 0x166);
            this.labelZH.Name = "labelZH";
            this.labelZH.Size = new Size(90, 90);
            this.labelZH.TabIndex = 0x3f;
            this.labelZH.Tag = "自然灾害";
            this.toolTipController1.SetTitle(this.labelZH, "自然灾害");
            this.labelZH.Visible = false;
            this.labelZH.Click += new EventHandler(this.labelCF_Click);
            this.imageList2.ImageStream = (ImageListStreamer)resources.GetObject("imageList2.ImageStream");
            this.imageList2.TransparentColor = Color.Transparent;
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
            this.labelZL.BackColor = Color.Transparent;
            this.labelZL.Cursor = Cursors.Hand;
            this.labelZL.ImageIndex = 0;
            this.labelZL.ImageList = this.imageList2;
            this.labelZL.Location = new Point(0x97, 0x167);
            this.labelZL.Name = "labelZL";
            this.labelZL.Size = new Size(90, 90);
            this.labelZL.TabIndex = 0x39;
            this.labelZL.Tag = "造林";
            this.toolTipController1.SetTitle(this.labelZL, "造林作业");
            this.labelZL.Visible = false;
            this.labelZL.Click += new EventHandler(this.labelCF_Click);
            this.labelHZ.BackColor = Color.Transparent;
            this.labelHZ.Cursor = Cursors.Hand;
            this.labelHZ.ImageIndex = 6;
            this.labelHZ.ImageList = this.imageList2;
            this.labelHZ.Location = new Point(0x1e5, 0x166);
            this.labelHZ.Name = "labelHZ";
            this.labelHZ.Size = new Size(90, 90);
            this.labelHZ.TabIndex = 0x3e;
            this.labelHZ.Tag = "火灾";
            this.toolTipController1.SetTitle(this.labelHZ, "森林火灾");
            this.labelHZ.Visible = false;
            this.labelHZ.Click += new EventHandler(this.labelCF_Click);
            this.labelAJ.BackColor = Color.Transparent;
            this.labelAJ.Cursor = Cursors.Hand;
            this.labelAJ.ImageIndex = 8;
            this.labelAJ.ImageList = this.imageList2;
            this.labelAJ.Location = new Point(0x24c, 0x166);
            this.labelAJ.Name = "labelAJ";
            this.labelAJ.Size = new Size(90, 90);
            this.labelAJ.TabIndex = 0x3d;
            this.labelAJ.Tag = "林业案件";
            this.toolTipController1.SetTitle(this.labelAJ, "林业案件");
            this.labelAJ.Visible = false;
            this.labelAJ.Click += new EventHandler(this.labelCF_Click);
            this.labelGC.BackColor = Color.Transparent;
            this.labelGC.Cursor = Cursors.Hand;
            this.labelGC.Location = new Point(0, 0x169);
            this.labelGC.Name = "labelGC";
            this.labelGC.Size = new Size(0x54, 0x56);
            this.labelGC.TabIndex = 60;
            this.labelGC.Tag = "林业工程";
            this.toolTipController1.SetTitle(this.labelGC, "林业工程");
            this.labelGC.Visible = false;
            this.labelGC.Click += new EventHandler(this.labelCF_Click);
            this.labelZZY.BackColor = Color.Transparent;
            this.labelZZY.Cursor = Cursors.Hand;
            this.labelZZY.ImageIndex = 4;
            this.labelZZY.ImageList = this.imageList2;
            this.labelZZY.Location = new Point(0x174, 0x166);
            this.labelZZY.Name = "labelZZY";
            this.labelZZY.Size = new Size(90, 90);
            this.labelZZY.TabIndex = 0x3b;
            this.labelZZY.Tag = "征占用";
            this.toolTipController1.SetTitle(this.labelZZY, "林地征占用");
            this.labelZZY.Visible = false;
            this.labelZZY.Click += new EventHandler(this.labelCF_Click);
            this.labelCF.BackColor = Color.Transparent;
            this.labelCF.Cursor = Cursors.Hand;
            this.labelCF.ImageIndex = 2;
            this.labelCF.ImageList = this.imageList2;
            this.labelCF.Location = new Point(260, 0x166);
            this.labelCF.Name = "labelCF";
            this.labelCF.Size = new Size(90, 90);
            this.labelCF.TabIndex = 0x3a;
            this.labelCF.Tag = "采伐";
            this.toolTipController1.SetTitle(this.labelCF, "采伐作业");
            this.labelCF.Visible = false;
            this.labelCF.Click += new EventHandler(this.labelCF_Click);
            this.labelSys.BackColor = Color.Transparent;
            this.labelSys.Cursor = Cursors.Hand;
            this.labelSys.ImageIndex = 4;
            this.labelSys.ImageList = this.imageList1;
            this.labelSys.Location = new Point(0x19b, 0x1e6);
            this.labelSys.Name = "labelSys";
            this.labelSys.Size = new Size(0x6b, 0x2b);
            this.labelSys.TabIndex = 0x44;
            this.labelSys.Tag = "系统管理";
            this.toolTipController1.SetTitle(this.labelSys, "系统管理与数据维护");
            this.labelSys.Visible = false;
            this.labelSys.Click += new EventHandler(this.label_Click);
            this.imageList1.ImageStream = (ImageListStreamer)resources.GetObject("imageList1.ImageStream");
            this.imageList1.TransparentColor = Color.White;
            this.imageList1.Images.SetKeyName(0, "edit0.png");
            this.imageList1.Images.SetKeyName(1, "edit.png");
            this.imageList1.Images.SetKeyName(2, "query0.png");
            this.imageList1.Images.SetKeyName(3, "query.png");
            this.imageList1.Images.SetKeyName(4, "sys0.png");
            this.imageList1.Images.SetKeyName(5, "sys.png");
            this.labelEdit.BackColor = Color.Transparent;
            this.labelEdit.Cursor = Cursors.Hand;
            this.labelEdit.ImageIndex = 0;
            this.labelEdit.ImageList = this.imageList1;
            this.labelEdit.Location = new Point(0xae, 0x1e6);
            this.labelEdit.Name = "labelEdit";
            this.labelEdit.Size = new Size(0x6b, 0x2b);
            this.labelEdit.TabIndex = 0x42;
            this.labelEdit.Tag = "数据编辑";
            this.toolTipController1.SetTitle(this.labelEdit, "数据编辑");
            this.labelEdit.Visible = false;
            this.labelEdit.Click += new EventHandler(this.label_Click);
            this.labelQuery.BackColor = Color.Transparent;
            this.labelQuery.Cursor = Cursors.Hand;
            this.labelQuery.ImageIndex = 2;
            this.labelQuery.ImageList = this.imageList1;
            this.labelQuery.Location = new Point(0x13b, 0x1e6);
            this.labelQuery.Name = "labelQuery";
            this.labelQuery.Size = new Size(0x6b, 0x2b);
            this.labelQuery.TabIndex = 0x43;
            this.labelQuery.Tag = "查询统计";
            this.toolTipController1.SetTitle(this.labelQuery, "查询统计");
            this.labelQuery.Visible = false;
            this.labelQuery.Click += new EventHandler(this.label_Click);
            this.label3DView.BackColor = Color.Transparent;
            this.label3DView.Cursor = Cursors.Hand;
            this.label3DView.ImageIndex = 4;
            this.label3DView.ImageList = this.imageList5;
            this.label3DView.Location = new Point(0xa4, 0x166);
            this.label3DView.Name = "label3DView";
            this.label3DView.Size = new Size(0x71, 90);
            this.label3DView.TabIndex = 0x45;
            this.label3DView.Tag = "3DView";
            this.toolTipController1.SetTitle(this.label3DView, "三维电子沙盘");
            this.label3DView.Visible = false;
            this.label3DView.Click += new EventHandler(this.label3DView_Click);
            this.imageList5.ImageStream = (ImageListStreamer)resources.GetObject("imageList5.ImageStream");
            this.imageList5.TransparentColor = Color.Transparent;
            this.imageList5.Images.SetKeyName(0, "bgbj0.png");
            this.imageList5.Images.SetKeyName(1, "bgbj.png");
            this.imageList5.Images.SetKeyName(2, "ndbj0.png");
            this.imageList5.Images.SetKeyName(3, "ndbj.png");
            this.imageList5.Images.SetKeyName(4, "sanwei0.png");
            this.imageList5.Images.SetKeyName(5, "sanwei.png");
            this.imageList5.Images.SetKeyName(6, "erwei0.png");
            this.imageList5.Images.SetKeyName(7, "erwei.png");
            this.label2DView.BackColor = Color.Transparent;
            this.label2DView.Cursor = Cursors.Hand;
            this.label2DView.ImageIndex = 6;
            this.label2DView.ImageList = this.imageList5;
            this.label2DView.Location = new Point(0x150, 0x165);
            this.label2DView.Name = "label2DView";
            this.label2DView.Size = new Size(0x71, 90);
            this.label2DView.TabIndex = 70;
            this.label2DView.Tag = "2DView";
            this.toolTipController1.SetTitle(this.label2DView, "二维浏览查看");
            this.label2DView.Visible = false;
            this.label2DView.Click += new EventHandler(this.label2DView_Click);
            this.labelXB2.BackColor = Color.Transparent;
            this.labelXB2.Cursor = Cursors.Hand;
            this.labelXB2.ImageIndex = 2;
            this.labelXB2.ImageList = this.imageList5;
            this.labelXB2.Location = new Point(550, 0x162);
            this.labelXB2.Name = "labelXB2";
            this.labelXB2.Size = new Size(0x71, 90);
            this.labelXB2.TabIndex = 0x4a;
            this.labelXB2.Tag = "年度变更";
            this.toolTipController1.SetTitle(this.labelXB2, "小班年度编辑");
            this.labelXB2.Visible = false;
            this.labelXB2.Click += new EventHandler(this.labelXB2_Click);
            this.labelXB.BackColor = Color.Transparent;
            this.labelXB.Cursor = Cursors.Hand;
            this.labelXB.ImageIndex = 0;
            this.labelXB.ImageList = this.imageList5;
            this.labelXB.Location = new Point(200, 0x163);
            this.labelXB.Name = "labelXB";
            this.labelXB.Size = new Size(0x71, 90);
            this.labelXB.TabIndex = 0x49;
            this.labelXB.Tag = "小班变更";
            this.toolTipController1.SetTitle(this.labelXB, "小班变更编辑");
            this.labelXB.Visible = false;
            this.labelXB.Click += new EventHandler(this.labelXB_Click);
            this.labelexit.BackColor = Color.Transparent;
            this.labelexit.Cursor = Cursors.Hand;
            this.labelexit.ImageIndex = 0;
            this.labelexit.ImageList = this.imageList4;
            this.labelexit.Location = new Point(0x2f5, 0x236);
            this.labelexit.Name = "labelexit";
            this.labelexit.Size = new Size(0x2a, 0x2a);
            this.labelexit.TabIndex = 0x4e;
            this.labelexit.Tag = "";
            this.toolTipController1.SetTitle(this.labelexit, "退出");
            this.labelexit.MouseLeave += new EventHandler(this.labelexit_MouseLeave);
            this.labelexit.Click += new EventHandler(this.labelexit_Click);
            this.labelexit.MouseDown += new MouseEventHandler(this.labelexit_MouseDown);
            this.labelexit.MouseUp += new MouseEventHandler(this.labelexit_MouseUp);
            this.labelexit.MouseEnter += new EventHandler(this.labelexit_MouseEnter);
            this.imageList4.ImageStream = (ImageListStreamer)resources.GetObject("imageList4.ImageStream");
            this.imageList4.TransparentColor = Color.Transparent;
            this.imageList4.Images.SetKeyName(0, "exit0.png");
            this.imageList4.Images.SetKeyName(1, "exit1.png");
            this.imageList4.Images.SetKeyName(2, "exit3.png");
            this.labelmod11.BackColor = Color.Transparent;
            this.labelmod11.Cursor = Cursors.Default;
            this.labelmod11.Dock = DockStyle.Fill;
//            this.labelmod11.Image = Resources._220;
            this.labelmod11.Location = new Point(0, 0);
            this.labelmod11.Name = "labelmod11";
            this.labelmod11.Size = new Size(0x3b1, 0x269);
            this.labelmod11.TabIndex = 0x40;
            this.labelmod11.Visible = false;
            this.labelmod21.BackColor = Color.White;
            this.labelmod21.Cursor = Cursors.Default;
            this.labelmod21.Dock = DockStyle.Fill;
//            this.labelmod21.Image = Resources._221;
            this.labelmod21.Location = new Point(0, 0);
            this.labelmod21.Name = "labelmod21";
            this.labelmod21.Size = new Size(0x3b1, 0x269);
            this.labelmod21.TabIndex = 0x41;
            this.labelmod21.Visible = false;
            this.labelmod22.BackColor = Color.Transparent;
            this.labelmod22.Cursor = Cursors.Default;
            this.labelmod22.Dock = DockStyle.Fill;
          //  this.labelmod22.Image = Resources._330;
            this.labelmod22.Location = new Point(0, 0);
            this.labelmod22.Name = "labelmod22";
            this.labelmod22.Size = new Size(0x3b1, 0x269);
            this.labelmod22.TabIndex = 0x47;
            this.labelmod22.Visible = false;
            this.labelmod31.BackColor = Color.Transparent;
            this.labelmod31.Cursor = Cursors.Default;
            this.labelmod31.Dock = DockStyle.Fill;
          //  this.labelmod31.Image = Resources._110;
            this.labelmod31.Location = new Point(0, 0);
            this.labelmod31.Name = "labelmod31";
            this.labelmod31.Size = new Size(0x3b1, 0x269);
            this.labelmod31.TabIndex = 0x48;
            this.labelmod31.Visible = false;
            this.panelProgress.BackColor = Color.Transparent;
            this.panelProgress.Controls.Add(this.LabelLoadInfo);
            this.panelProgress.Controls.Add(this.LabelProgressBar);
            this.panelProgress.Controls.Add(this.LabelProgressBack);
            this.panelProgress.Location = new Point(540, 0x1e8);
            this.panelProgress.Name = "panelProgress";
            this.panelProgress.Size = new Size(0x108, 0x20);
            this.panelProgress.TabIndex = 0x4b;
            this.panelProgress.Visible = false;
            this.LabelLoadInfo.BackColor = Color.Transparent;
            this.LabelLoadInfo.ForeColor = Color.FromArgb(0xff, 0x80, 0);
            this.LabelLoadInfo.Location = new Point(30, 3);
            this.LabelLoadInfo.Name = "LabelLoadInfo";
            this.LabelLoadInfo.Size = new Size(0x102, 0x13);
            this.LabelLoadInfo.TabIndex = 12;
            this.LabelLoadInfo.Text = "系统启动中, 请稍候...";
            this.LabelLoadInfo.TextAlign = ContentAlignment.MiddleLeft;
            this.LabelProgressBar.BackColor = Color.Gold;
            this.LabelProgressBar.Location = new Point(3, 0x1b);
            this.LabelProgressBar.Name = "LabelProgressBar";
            this.LabelProgressBar.Size = new Size(0x75, 2);
            this.LabelProgressBar.TabIndex = 13;
            this.LabelProgressBack.BackColor = Color.White;
            this.LabelProgressBack.BorderStyle = BorderStyle.FixedSingle;
            this.LabelProgressBack.ForeColor = Color.White;
            this.LabelProgressBack.Location = new Point(2, 0x1a);
            this.LabelProgressBack.Name = "LabelProgressBack";
            this.LabelProgressBack.Size = new Size(260, 4);
            this.LabelProgressBack.TabIndex = 11;
            this.label0.BackColor = Color.Transparent;
            this.label0.Cursor = Cursors.Default;
            this.label0.Dock = DockStyle.Fill;
//            this.label0.Image = Resources._000;
            this.label0.Location = new Point(0, 0);
            this.label0.Name = "label0";
            this.label0.Size = new Size(0x3b1, 0x269);
            this.label0.TabIndex = 0x4c;
            this.label0.Visible = false;
            this.axLicenseControl1.Enabled = true;
            this.axLicenseControl1.Location = new Point(40, 0x1bb);
            this.axLicenseControl1.Name = "axLicenseControl1";
            this.axLicenseControl1.OcxState = (AxHost.State)resources.GetObject("axLicenseControl1.OcxState");
            this.axLicenseControl1.Size = new Size(0x20, 0x20);
            this.axLicenseControl1.TabIndex = 0x4d;
            base.AutoScaleDimensions = new SizeF(6f, 12f);
//            base.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.White;
//            this.BackgroundImage = Resources._000;
            base.ClientSize = new Size(0x3b1, 0x269);
            base.Controls.Add(this.labelexit);
            base.Controls.Add(this.axLicenseControl1);
            base.Controls.Add(this.labelSys2);
            base.Controls.Add(this.panelProgress);
            base.Controls.Add(this.labelXB2);
            base.Controls.Add(this.labelXB);
            base.Controls.Add(this.label3DView);
            base.Controls.Add(this.label2DView);
            base.Controls.Add(this.labelSys);
            base.Controls.Add(this.labelEdit);
            base.Controls.Add(this.labelQuery);
            base.Controls.Add(this.labelZH);
            base.Controls.Add(this.labelZL);
            base.Controls.Add(this.labelHZ);
            base.Controls.Add(this.labelAJ);
            base.Controls.Add(this.labelGC);
            base.Controls.Add(this.labelZZY);
            base.Controls.Add(this.labelCF);
            base.Controls.Add(this.panelLogin);
            base.Controls.Add(this.labelmod3);
            base.Controls.Add(this.labelmod2);
            base.Controls.Add(this.labelmod1);
            base.Controls.Add(this.labelmod11);
            base.Controls.Add(this.label0);
            base.Controls.Add(this.labelmod21);
            base.Controls.Add(this.labelmod22);
            base.Controls.Add(this.labelmod31);
//            base.FormBorderStyle = FormBorderStyle.None;
            base.Icon = (Icon)resources.GetObject("$this.Icon");
            base.Name = "FormLogin4";
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "登录";
            base.Load += new EventHandler(this.FormLogin_Load);
            base.KeyPress += new KeyPressEventHandler(this.FormLogin4_KeyPress);
            this.panelLogin.ResumeLayout(false);
            this.panelLogin.PerformLayout();
            this.textEdit1.Properties.EndInit();
            this.textEdit2.Properties.EndInit();
            this.panelProgress.ResumeLayout(false);
            this.axLicenseControl1.EndInit();
            base.ResumeLayout(false);
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
            this.EditKind = this.EditKind + "-查询统计";
            this.panelLogin.Visible = true;
            this.panelLogin.Enabled = true;
            this.simpleButtonOK.ImageIndex = 1;
            this.label2DView.ImageIndex = 7;
            this.label3DView.ImageIndex = 4;
        }

        private void label3DView_Click(object sender, EventArgs e)
        {
            this.EditKind = "年度小班";
            this.EditKind = this.EditKind + "-三维系统";
            this.panelLogin.Visible = true;
            this.panelLogin.Enabled = true;
            this.simpleButtonOK.ImageIndex = 1;
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
            this.labelEdit.ImageIndex = 0;
            this.labelQuery.ImageIndex = 2;
            this.labelSys.ImageIndex = 4;
            this.labelmod21.Visible = false;
            this.labelmod22.Visible = true;
            this.labelmod31.Visible = false;
            this.labelmod11.Visible = false;
            string resource = "Resources.221.png";
            this.labelmod22.Image = new Bitmap(base.GetType(), resource);
            this.BackgroundImage = new Bitmap(base.GetType(), resource);
            this.labelEdit.Visible = true;
            this.labelEdit.BringToFront();
            this.labelQuery.Visible = true;
            this.labelQuery.BringToFront();
            this.EditKind = (sender as Label).Tag.ToString();
        }

        private void labelexit_Click(object sender, EventArgs e)
        {
            this.CancelFlag = true;
            base.Hide();
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
                this.label0.Visible = false;
                this.labelXB.Visible = false;
                this.labelXB2.Visible = false;
                this.label2DView.Visible = false;
                this.label3DView.Visible = false;
                this.labelZL.ImageIndex = 0;
                this.labelCF.ImageIndex = 2;
                this.labelZZY.ImageIndex = 4;
                this.labelHZ.ImageIndex = 6;
                this.labelAJ.ImageIndex = 8;
                this.labelZH.ImageIndex = 10;
                this.labelmod21.Visible = true;
                this.labelmod22.Visible = false;
                this.labelmod31.Visible = false;
                this.labelmod11.Visible = false;
                string resource = "Resources.220.png";
                this.labelmod21.Image = new Bitmap(base.GetType(), resource);
                this.BackgroundImage = new Bitmap(base.GetType(), resource);
                this.labelZL.Visible = true;
                this.labelCF.Visible = true;
                this.labelZZY.Visible = true;
                this.labelZH.Visible = true;
                this.labelHZ.Visible = true;
                this.labelAJ.Visible = true;
                this.panelLogin.Visible = false;
                this.panelLogin.Enabled = false;
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
                string resource = "Resources.330.png";
                this.labelmod11.Image = new Bitmap(base.GetType(), resource);
                this.BackgroundImage = new Bitmap(base.GetType(), resource);
                this.labelXB.Visible = true;
                this.labelXB.BringToFront();
                this.labelXB2.Visible = true;
                this.labelXB2.BringToFront();
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
                this.panelLogin.Visible = false;
                this.panelLogin.Enabled = false;
                this.labelmod31.Visible = true;
                this.labelmod21.Visible = false;
                this.labelmod22.Visible = false;
                this.labelmod11.Visible = false;
                this.labelmod11.Visible = false;
                this.labelmod21.Visible = false;
                this.labelmod22.Visible = false;
                this.label2DView.Visible = true;
                this.label2DView.BringToFront();
                this.label3DView.Visible = true;
                this.label3DView.BringToFront();
                this.labelEdit.Visible = false;
                this.labelQuery.Visible = false;
                this.labelSys.Visible = false;
                string resource = "Resources.110.png";
                this.labelmod31.Image = new Bitmap(base.GetType(), resource);
                this.labelmod31.Refresh();
                this.BackgroundImage = new Bitmap(base.GetType(), resource);
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
            string resource = "Resources.000.png";
            this.label0.Image = new Bitmap(base.GetType(), resource);
            this.BackgroundImage = new Bitmap(base.GetType(), resource);
            this.panelLogin.Visible = true;
            this.panelLogin.Enabled = true;
            this.simpleButtonOK.ImageIndex = 1;
        }

        private void labelXB_Click(object sender, EventArgs e)
        {
            this.labelXB2.ImageIndex = 2;
            this.labelXB.ImageIndex = 1;
            this.EditKind = "小班变更";
            this.EditKind = this.EditKind + "-数据编辑";
            this.panelLogin.Visible = true;
            this.panelLogin.Enabled = true;
            this.simpleButtonOK.ImageIndex = 1;
        }

        private void labelXB2_Click(object sender, EventArgs e)
        {
            this.labelXB2.ImageIndex = 3;
            this.labelXB.ImageIndex = 0;
            this.EditKind = "年度小班";
            this.EditKind = this.EditKind + "-数据编辑";
            this.panelLogin.Visible = true;
            this.panelLogin.Enabled = true;
            this.simpleButtonOK.ImageIndex = 1;
        }

        private void labelZL_Click(object sender, EventArgs e)
        {
            this.labelmod21.Visible = false;
            this.labelmod22.Visible = true;
            this.labelmod31.Visible = false;
            this.labelmod11.Visible = false;
            string resource = "Resources.221.png";
            this.labelmod22.Image = new Bitmap(base.GetType(), resource);
            this.BackgroundImage = new Bitmap(base.GetType(), resource);
            this.panelLogin.Visible = false;
            this.panelLogin.Enabled = true;
            this.panelLogin.Top = (sender as Label).Top;
            this.labelEdit.Visible = true;
            this.labelEdit.BringToFront();
            this.labelQuery.Visible = true;
            this.labelQuery.BringToFront();
            this.EditKind = (sender as Label).Tag.ToString();
        }

        private void m_Timer_Tick(object sender, EventArgs e)
        {
            this.LabelLoadInfo.Refresh();
            this.LabelProgressBack.Refresh();
            this.LabelProgressBar.Refresh();
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
                    //登录系统被注销
                    //if (!UserManage.Login(sUserName, sPasswrd, strArray[0], out sResponse))
                    //{
                    //    MessageBox.Show(this, sResponse, "系统登录", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    //}
                    //else
                    //{
                    //    UtilFactory.GetConfigOpt().SetConfigValue("LoginUserID", sUserName);
                    //    if ((strArray.Length == 1) && (strArray[0] == "系统管理"))
                    //    {
                    //        new FormSystemManage().ShowDialog();
                    //        this.panelLogin.Visible = false;
                    //    }
                    //    else
                    //    {
                    //        base.Hide();
                    //    }
                    //}
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

