namespace MainFrameBase
{
    using DevExpress.LookAndFeel;
    using DevExpress.Utils;
    using DevExpress.XtraEditors;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class FormSplash2 : XtraForm
    {
        public bool CancelFlag;
        private IContainer components;
        public string EditKind = "小班";
        public ImageList imageList1;
        public ImageList imageList2;
        public ImageList imageList3;
        public ImageList imageList4;
        public Label label;
        public Label label1;
        public Label label2;
        public Label label4;
        protected Label LabelLoadInfo;
        public Label labelN0;
        public Label labelN1;
        public Label labelN2;
        public Label labelN3;
        public Label labelN4;
        public Label labelN5;
        public Label labelN6;
        public Label labelN7;
        public Label labelN8;
        protected Label LabelProgressBack;
        protected Label LabelProgressBar;
        public Label lablekind;
        public Timer m_Timer;
        public Panel panelLogin;
        public Panel panelProgress;
        public SimpleButton simpleButton0;
        public SimpleButton simpleButtonCancel;
        public SimpleButton simpleButtonOK;
        public TextEdit textEdit1;
        public TextEdit textEdit2;
        public ToolTipController toolTipController1;

        public FormSplash2()
        {
            this.InitializeComponent();
            this.m_Timer = new Timer();
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

        private void frmSplash_Deactivate(object sender, EventArgs e)
        {
        }

        private void frmSplash_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.m_Timer = null;
        }

        private void frmSplash_KeyDown(object sender, KeyEventArgs e)
        {
        }

        private void frmSplash_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\x001b')
            {
                this.CancelFlag = true;
                base.Hide();
            }
        }

        private void frmSplash_Load(object sender, EventArgs e)
        {
            this.m_Timer.Interval = 300;
            this.m_Timer.Start();
            this.lablekind.Visible = false;
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSplash2));
            this.label = new System.Windows.Forms.Label();
            this.labelN3 = new System.Windows.Forms.Label();
            this.imageList2 = new System.Windows.Forms.ImageList();
            this.labelN1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.labelN4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
            this.textEdit2 = new DevExpress.XtraEditors.TextEdit();
            this.simpleButtonOK = new DevExpress.XtraEditors.SimpleButton();
            this.imageList3 = new System.Windows.Forms.ImageList();
            this.imageList1 = new System.Windows.Forms.ImageList();
            this.LabelProgressBar = new System.Windows.Forms.Label();
            this.LabelLoadInfo = new System.Windows.Forms.Label();
            this.LabelProgressBack = new System.Windows.Forms.Label();
            this.panelLogin = new System.Windows.Forms.Panel();
            this.simpleButtonCancel = new DevExpress.XtraEditors.SimpleButton();
            this.panelProgress = new System.Windows.Forms.Panel();
            this.toolTipController1 = new DevExpress.Utils.ToolTipController();
            this.labelN2 = new System.Windows.Forms.Label();
            this.labelN5 = new System.Windows.Forms.Label();
            this.labelN0 = new System.Windows.Forms.Label();
            this.imageList4 = new System.Windows.Forms.ImageList();
            this.labelN6 = new System.Windows.Forms.Label();
            this.labelN7 = new System.Windows.Forms.Label();
            this.labelN8 = new System.Windows.Forms.Label();
            this.lablekind = new System.Windows.Forms.Label();
            this.simpleButton0 = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit2.Properties)).BeginInit();
            this.panelLogin.SuspendLayout();
            this.panelProgress.SuspendLayout();
            this.SuspendLayout();
            // 
            // label
            // 
            this.label.BackColor = System.Drawing.Color.Transparent;
            this.label.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label.Location = new System.Drawing.Point(243, 8);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(99, 99);
            this.label.TabIndex = 0;
            // 
            // labelN3
            // 
            this.labelN3.BackColor = System.Drawing.Color.Transparent;
            this.labelN3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelN3.ImageList = this.imageList2;
            this.labelN3.Location = new System.Drawing.Point(133, 342);
            this.labelN3.Name = "labelN3";
            this.labelN3.Size = new System.Drawing.Size(90, 90);
            this.labelN3.TabIndex = 1;
            this.toolTipController1.SetTitle(this.labelN3, "林权宗地变更");
            this.labelN3.Click += new System.EventHandler(this.labelLingai_Click);
            this.labelN3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.labelLingai_MouseDown);
            this.labelN3.MouseEnter += new System.EventHandler(this.labelLingai_MouseEnter);
            this.labelN3.MouseLeave += new System.EventHandler(this.labelLingai_MouseLeave);
            this.labelN3.MouseUp += new System.Windows.Forms.MouseEventHandler(this.labelLingai_MouseUp);
            // 
            // imageList2
            // 
            this.imageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList2.ImageStream")));
            this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList2.Images.SetKeyName(0, "sjcj_login_37.png");
            this.imageList2.Images.SetKeyName(1, "sjcj_login_32.png");
            this.imageList2.Images.SetKeyName(2, "sjcj_login_12.png");
            this.imageList2.Images.SetKeyName(3, "sjcj_login_39.png");
            this.imageList2.Images.SetKeyName(4, "sjcj_login_34.png");
            this.imageList2.Images.SetKeyName(5, "sjcj_login_14.png");
            this.imageList2.Images.SetKeyName(6, "sjcj_login_36.png");
            this.imageList2.Images.SetKeyName(7, "sjcj_login_31.png");
            this.imageList2.Images.SetKeyName(8, "sjcj_login_11.png");
            this.imageList2.Images.SetKeyName(9, "sjcj_login_38.png");
            this.imageList2.Images.SetKeyName(10, "sjcj_login_33.png");
            this.imageList2.Images.SetKeyName(11, "sjcj_login_13.png");
            this.imageList2.Images.SetKeyName(12, "sjcj_login_40.png");
            this.imageList2.Images.SetKeyName(13, "sjcj_login_35.png");
            this.imageList2.Images.SetKeyName(14, "sjcj_login_15.png");
            this.imageList2.Images.SetKeyName(15, "Download.png");
            // 
            // labelN1
            // 
            this.labelN1.BackColor = System.Drawing.Color.Transparent;
            this.labelN1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelN1.ImageList = this.imageList2;
            this.labelN1.Location = new System.Drawing.Point(12, 206);
            this.labelN1.Name = "labelN1";
            this.labelN1.Size = new System.Drawing.Size(90, 90);
            this.labelN1.TabIndex = 2;
            this.toolTipController1.SetTitle(this.labelN1, "造林作业");
            this.labelN1.Click += new System.EventHandler(this.labelZaolin_Click);
            this.labelN1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.labelZaolin_MouseDown);
            this.labelN1.MouseEnter += new System.EventHandler(this.labelZaolin_MouseEnter);
            this.labelN1.MouseLeave += new System.EventHandler(this.labelZaolin_MouseLeave);
            this.labelN1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.labelZaolin_MouseUp);
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label4.Location = new System.Drawing.Point(16, 352);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 99);
            this.label4.TabIndex = 3;
            // 
            // labelN4
            // 
            this.labelN4.BackColor = System.Drawing.Color.Transparent;
            this.labelN4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelN4.ImageList = this.imageList2;
            this.labelN4.Location = new System.Drawing.Point(227, 371);
            this.labelN4.Name = "labelN4";
            this.labelN4.Size = new System.Drawing.Size(90, 90);
            this.labelN4.TabIndex = 4;
            this.toolTipController1.SetTitle(this.labelN4, "通用编辑");
            this.labelN4.Click += new System.EventHandler(this.labelXiaoban_Click);
            this.labelN4.MouseDown += new System.Windows.Forms.MouseEventHandler(this.labelXiaoban_MouseDown);
            this.labelN4.MouseEnter += new System.EventHandler(this.labelXiaoban_MouseEnter);
            this.labelN4.MouseLeave += new System.EventHandler(this.labelXiaoban_MouseLeave);
            this.labelN4.MouseUp += new System.Windows.Forms.MouseEventHandler(this.labelXiaoban_MouseUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(9, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 14);
            this.label1.TabIndex = 6;
            this.label1.Text = "用户名:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(9, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 14);
            this.label2.TabIndex = 7;
            this.label2.Text = "密码:";
            // 
            // textEdit1
            // 
            this.textEdit1.EditValue = "xiaoyao";
            this.textEdit1.Location = new System.Drawing.Point(72, 8);
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
            this.textEdit2.EditValue = "1";
            this.textEdit2.Location = new System.Drawing.Point(72, 63);
            this.textEdit2.Name = "textEdit2";
            this.textEdit2.Properties.Appearance.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textEdit2.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.textEdit2.Properties.Appearance.Options.UseBackColor = true;
            this.textEdit2.Properties.Appearance.Options.UseForeColor = true;
            this.textEdit2.Properties.PasswordChar = '*';
            this.textEdit2.Size = new System.Drawing.Size(100, 20);
            this.textEdit2.TabIndex = 1;
            // 
            // simpleButtonOK
            // 
            this.simpleButtonOK.Cursor = System.Windows.Forms.Cursors.Hand;
            this.simpleButtonOK.ImageIndex = 0;
            this.simpleButtonOK.ImageList = this.imageList3;
            this.simpleButtonOK.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.simpleButtonOK.Location = new System.Drawing.Point(184, 0);
            this.simpleButtonOK.Name = "simpleButtonOK";
            this.simpleButtonOK.Size = new System.Drawing.Size(108, 29);
            this.simpleButtonOK.TabIndex = 2;
            this.simpleButtonOK.Click += new System.EventHandler(this.simpleButtonOK_Click);
            this.simpleButtonOK.MouseDown += new System.Windows.Forms.MouseEventHandler(this.simpleButtonOK_MouseDown);
            this.simpleButtonOK.MouseEnter += new System.EventHandler(this.simpleButtonOK_MouseEnter);
            this.simpleButtonOK.MouseLeave += new System.EventHandler(this.simpleButtonOK_MouseLeave);
            this.simpleButtonOK.MouseUp += new System.Windows.Forms.MouseEventHandler(this.simpleButtonOK_MouseUp);
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
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "LoginButtonD.bmp");
            this.imageList1.Images.SetKeyName(1, "LoginButtonO.bmp");
            this.imageList1.Images.SetKeyName(2, "LoginButtonE.bmp");
            this.imageList1.Images.SetKeyName(3, "LoginButtonC.bmp");
            // 
            // LabelProgressBar
            // 
            this.LabelProgressBar.BackColor = System.Drawing.Color.Gold;
            this.LabelProgressBar.Location = new System.Drawing.Point(3, 27);
            this.LabelProgressBar.Name = "LabelProgressBar";
            this.LabelProgressBar.Size = new System.Drawing.Size(117, 2);
            this.LabelProgressBar.TabIndex = 13;
            // 
            // LabelLoadInfo
            // 
            this.LabelLoadInfo.BackColor = System.Drawing.Color.Transparent;
            this.LabelLoadInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.LabelLoadInfo.Location = new System.Drawing.Point(30, 0);
            this.LabelLoadInfo.Name = "LabelLoadInfo";
            this.LabelLoadInfo.Size = new System.Drawing.Size(258, 19);
            this.LabelLoadInfo.TabIndex = 12;
            this.LabelLoadInfo.Text = "系统启动中, 请稍后...";
            this.LabelLoadInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LabelProgressBack
            // 
            this.LabelProgressBack.BackColor = System.Drawing.Color.White;
            this.LabelProgressBack.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LabelProgressBack.ForeColor = System.Drawing.Color.White;
            this.LabelProgressBack.Location = new System.Drawing.Point(2, 26);
            this.LabelProgressBack.Name = "LabelProgressBack";
            this.LabelProgressBack.Size = new System.Drawing.Size(320, 4);
            this.LabelProgressBack.TabIndex = 11;
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
            this.panelLogin.Enabled = false;
            this.panelLogin.Location = new System.Drawing.Point(521, 327);
            this.panelLogin.Name = "panelLogin";
            this.panelLogin.Size = new System.Drawing.Size(338, 105);
            this.panelLogin.TabIndex = 14;
            // 
            // simpleButtonCancel
            // 
            this.simpleButtonCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.simpleButtonCancel.ImageIndex = 3;
            this.simpleButtonCancel.ImageList = this.imageList3;
            this.simpleButtonCancel.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.simpleButtonCancel.Location = new System.Drawing.Point(184, 53);
            this.simpleButtonCancel.Name = "simpleButtonCancel";
            this.simpleButtonCancel.Size = new System.Drawing.Size(108, 29);
            this.simpleButtonCancel.TabIndex = 8;
            this.simpleButtonCancel.Click += new System.EventHandler(this.simpleButtonCancel_Click);
            // 
            // panelProgress
            // 
            this.panelProgress.BackColor = System.Drawing.Color.Transparent;
            this.panelProgress.Controls.Add(this.LabelLoadInfo);
            this.panelProgress.Controls.Add(this.LabelProgressBar);
            this.panelProgress.Controls.Add(this.LabelProgressBack);
            this.panelProgress.Location = new System.Drawing.Point(522, 355);
            this.panelProgress.Name = "panelProgress";
            this.panelProgress.Size = new System.Drawing.Size(338, 44);
            this.panelProgress.TabIndex = 15;
            this.panelProgress.Visible = false;
            // 
            // labelN2
            // 
            this.labelN2.BackColor = System.Drawing.Color.Transparent;
            this.labelN2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelN2.ImageList = this.imageList2;
            this.labelN2.Location = new System.Drawing.Point(52, 284);
            this.labelN2.Name = "labelN2";
            this.labelN2.Size = new System.Drawing.Size(90, 90);
            this.labelN2.TabIndex = 19;
            this.toolTipController1.SetTitle(this.labelN2, "采伐作业");
            this.labelN2.Click += new System.EventHandler(this.labelCaifa_Click);
            this.labelN2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.labelCaifa_MouseDown);
            this.labelN2.MouseEnter += new System.EventHandler(this.labelCaifa_MouseEnter);
            this.labelN2.MouseLeave += new System.EventHandler(this.labelCaifa_MouseLeave);
            this.labelN2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.labelCaifa_MouseUp);
            // 
            // labelN5
            // 
            this.labelN5.BackColor = System.Drawing.Color.Transparent;
            this.labelN5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelN5.ImageList = this.imageList2;
            this.labelN5.Location = new System.Drawing.Point(316, 371);
            this.labelN5.Name = "labelN5";
            this.labelN5.Size = new System.Drawing.Size(90, 90);
            this.labelN5.TabIndex = 21;
            this.toolTipController1.SetTitle(this.labelN5, "公益林编辑");
            this.labelN5.Click += new System.EventHandler(this.labelGYL_Click);
            this.labelN5.MouseDown += new System.Windows.Forms.MouseEventHandler(this.labelGYL_MouseDown);
            this.labelN5.MouseEnter += new System.EventHandler(this.labelGYL_MouseEnter);
            this.labelN5.MouseLeave += new System.EventHandler(this.labelGYL_MouseLeave);
            this.labelN5.MouseUp += new System.Windows.Forms.MouseEventHandler(this.labelGYL_MouseUp);
            // 
            // labelN0
            // 
            this.labelN0.BackColor = System.Drawing.Color.Transparent;
            this.labelN0.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelN0.ImageList = this.imageList4;
            this.labelN0.Location = new System.Drawing.Point(25, 116);
            this.labelN0.Name = "labelN0";
            this.labelN0.Size = new System.Drawing.Size(90, 90);
            this.labelN0.TabIndex = 23;
            this.toolTipController1.SetTitle(this.labelN0, "通用编辑");
            this.labelN0.Click += new System.EventHandler(this.labelXiaobanUpdate_Click);
            // 
            // imageList4
            // 
            this.imageList4.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList4.ImageStream")));
            this.imageList4.TransparentColor = System.Drawing.Color.White;
            this.imageList4.Images.SetKeyName(0, "无标题3.png");
            // 
            // labelN6
            // 
            this.labelN6.BackColor = System.Drawing.Color.Transparent;
            this.labelN6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelN6.ImageList = this.imageList2;
            this.labelN6.Location = new System.Drawing.Point(403, 327);
            this.labelN6.Name = "labelN6";
            this.labelN6.Size = new System.Drawing.Size(90, 90);
            this.labelN6.TabIndex = 24;
            this.toolTipController1.SetTitle(this.labelN6, "公益林编辑");
            // 
            // labelN7
            // 
            this.labelN7.BackColor = System.Drawing.Color.Transparent;
            this.labelN7.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelN7.ImageList = this.imageList2;
            this.labelN7.Location = new System.Drawing.Point(441, 245);
            this.labelN7.Name = "labelN7";
            this.labelN7.Size = new System.Drawing.Size(90, 90);
            this.labelN7.TabIndex = 25;
            this.toolTipController1.SetTitle(this.labelN7, "变更编辑");
            // 
            // labelN8
            // 
            this.labelN8.BackColor = System.Drawing.Color.Transparent;
            this.labelN8.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelN8.ImageList = this.imageList2;
            this.labelN8.Location = new System.Drawing.Point(453, 151);
            this.labelN8.Name = "labelN8";
            this.labelN8.Size = new System.Drawing.Size(90, 90);
            this.labelN8.TabIndex = 26;
            this.toolTipController1.SetTitle(this.labelN8, "年度编辑");
            // 
            // lablekind
            // 
            this.lablekind.BackColor = System.Drawing.Color.Transparent;
            this.lablekind.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lablekind.ForeColor = System.Drawing.Color.Honeydew;
            this.lablekind.Location = new System.Drawing.Point(555, 202);
            this.lablekind.Name = "lablekind";
            this.lablekind.Size = new System.Drawing.Size(205, 38);
            this.lablekind.TabIndex = 22;
            this.lablekind.Text = "造林设计模式";
            this.lablekind.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lablekind.Visible = false;
            // 
            // simpleButton0
            // 
            this.simpleButton0.Appearance.BackColor = System.Drawing.Color.Fuchsia;
            this.simpleButton0.Appearance.BackColor2 = System.Drawing.Color.Blue;
            this.simpleButton0.Appearance.BorderColor = System.Drawing.Color.Fuchsia;
            this.simpleButton0.Appearance.Options.UseBackColor = true;
            this.simpleButton0.Appearance.Options.UseBorderColor = true;
            this.simpleButton0.Location = new System.Drawing.Point(796, 8);
            this.simpleButton0.LookAndFeel.SkinName = "The Asphalt World";
            this.simpleButton0.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            this.simpleButton0.LookAndFeel.UseDefaultLookAndFeel = false;
            this.simpleButton0.Name = "simpleButton0";
            this.simpleButton0.Size = new System.Drawing.Size(104, 104);
            this.simpleButton0.TabIndex = 18;
            this.simpleButton0.Visible = false;
            // 
            // FormSplash2
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(57)))), ((int)(((byte)(84)))));
            this.Appearance.Options.UseBackColor = true;
            this.BackgroundImageLayoutStore = System.Windows.Forms.ImageLayout.Zoom;
            this.BackgroundImageStore = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImageStore")));
            this.ClientSize = new System.Drawing.Size(880, 544);
            this.Controls.Add(this.labelN8);
            this.Controls.Add(this.labelN7);
            this.Controls.Add(this.labelN6);
            this.Controls.Add(this.labelN5);
            this.Controls.Add(this.labelN3);
            this.Controls.Add(this.labelN4);
            this.Controls.Add(this.labelN0);
            this.Controls.Add(this.panelProgress);
            this.Controls.Add(this.lablekind);
            this.Controls.Add(this.labelN2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label);
            this.Controls.Add(this.labelN1);
            this.Controls.Add(this.panelLogin);
            this.Controls.Add(this.simpleButton0);
            this.DoubleBuffered = true;
            this.Name = "FormSplash2";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "登录";
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(57)))), ((int)(((byte)(84)))));
            this.Deactivate += new System.EventHandler(this.frmSplash_Deactivate);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmSplash_FormClosed);
            this.Load += new System.EventHandler(this.frmSplash_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmSplash_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmSplash_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit2.Properties)).EndInit();
            this.panelLogin.ResumeLayout(false);
            this.panelLogin.PerformLayout();
            this.panelProgress.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private void labelCaifa_Click(object sender, EventArgs e)
        {
            this.EditKind = "采伐";
            this.panelLogin.Enabled = true;
            this.simpleButtonOK.ImageIndex = 1;
            this.lablekind.Visible = true;
            this.lablekind.Text = "采伐设计模式";
        }

        private void labelCaifa_MouseDown(object sender, MouseEventArgs e)
        {
            this.labelN2.ImageIndex = 5;
        }

        private void labelCaifa_MouseEnter(object sender, EventArgs e)
        {
            this.labelN2.ImageIndex = 4;
        }

        private void labelCaifa_MouseLeave(object sender, EventArgs e)
        {
            this.simpleButton0.Visible = false;
            this.labelN2.ImageIndex = 3;
        }

        private void labelCaifa_MouseUp(object sender, MouseEventArgs e)
        {
            this.simpleButton0.Visible = false;
        }

        private void labelGYL_Click(object sender, EventArgs e)
        {
            this.EditKind = "公益林";
            this.panelLogin.Enabled = true;
            this.simpleButtonOK.ImageIndex = 1;
            this.lablekind.Visible = true;
            this.lablekind.Text = "公益林模式";
        }

        private void labelGYL_MouseDown(object sender, MouseEventArgs e)
        {
            this.labelN5.ImageIndex = 11;
        }

        private void labelGYL_MouseEnter(object sender, EventArgs e)
        {
            this.labelN5.ImageIndex = 10;
        }

        private void labelGYL_MouseLeave(object sender, EventArgs e)
        {
            this.labelN5.ImageIndex = 9;
        }

        private void labelGYL_MouseUp(object sender, MouseEventArgs e)
        {
            this.labelN5.ImageIndex = 10;
        }

        private void labelLingai_Click(object sender, EventArgs e)
        {
            this.EditKind = "林改";
            this.panelLogin.Enabled = true;
            this.simpleButtonOK.ImageIndex = 1;
            this.lablekind.Visible = true;
            this.lablekind.Text = "林权宗地模式";
        }

        private void labelLingai_MouseDown(object sender, MouseEventArgs e)
        {
            this.labelN3.ImageIndex = 8;
        }

        private void labelLingai_MouseEnter(object sender, EventArgs e)
        {
            this.labelN3.ImageIndex = 7;
        }

        private void labelLingai_MouseLeave(object sender, EventArgs e)
        {
            this.simpleButton0.Visible = false;
            this.labelN3.ImageIndex = 6;
        }

        private void labelLingai_MouseUp(object sender, MouseEventArgs e)
        {
            this.labelN3.ImageIndex = 6;
        }

        private void labelXiaoban_Click(object sender, EventArgs e)
        {
            this.EditKind = "通用";
            this.panelLogin.Enabled = true;
            this.simpleButtonOK.ImageIndex = 1;
            this.lablekind.Visible = true;
            this.lablekind.Text = "通用模式";
        }

        private void labelXiaoban_MouseDown(object sender, MouseEventArgs e)
        {
            this.labelN4.ImageIndex = 14;
        }

        private void labelXiaoban_MouseEnter(object sender, EventArgs e)
        {
            this.labelN4.ImageIndex = 13;
        }

        private void labelXiaoban_MouseLeave(object sender, EventArgs e)
        {
            this.labelN4.ImageIndex = 12;
        }

        private void labelXiaoban_MouseUp(object sender, MouseEventArgs e)
        {
            this.labelN4.ImageIndex = 12;
        }

        private void labelXiaobanUpdate_Click(object sender, EventArgs e)
        {
            this.EditKind = "小班";
            this.panelLogin.Enabled = true;
            this.simpleButtonOK.ImageIndex = 1;
            this.lablekind.Visible = true;
            this.lablekind.Text = "小班变更编辑模式";
        }

        private void labelZaolin_Click(object sender, EventArgs e)
        {
            this.EditKind = "造林";
            this.panelLogin.Enabled = true;
            this.simpleButtonOK.ImageIndex = 1;
            this.lablekind.Visible = true;
            this.lablekind.Text = "造林设计模式";
        }

        private void labelZaolin_MouseDown(object sender, MouseEventArgs e)
        {
            this.labelN1.ImageIndex = 2;
        }

        private void labelZaolin_MouseEnter(object sender, EventArgs e)
        {
            this.labelN1.ImageIndex = 1;
        }

        private void labelZaolin_MouseLeave(object sender, EventArgs e)
        {
            this.labelN1.ImageIndex = 0;
        }

        private void labelZaolin_MouseUp(object sender, MouseEventArgs e)
        {
            this.labelN1.ImageIndex = 0;
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

        private void simpleButton1_MouseDown(object sender, MouseEventArgs e)
        {
        }

        private void simpleButton3_MouseDown(object sender, MouseEventArgs e)
        {
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
            if (e.KeyChar == '\x001b')
            {
                this.CancelFlag = true;
                base.Hide();
            }
        }
    }
}

