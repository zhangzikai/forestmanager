namespace MainFrameBase
{
    using DevExpress.LookAndFeel;
    using DevExpress.Utils;
    using DevExpress.XtraEditors;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class FormSplash : XtraForm
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

        public FormSplash()
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
            this.components = new Container();
            ComponentResourceManager resources = new ComponentResourceManager(typeof(FormSplash));
            this.label = new Label();
            this.labelN3 = new Label();
            this.imageList2 = new ImageList(this.components);
            this.labelN1 = new Label();
            this.label4 = new Label();
            this.labelN4 = new Label();
            this.label1 = new Label();
            this.label2 = new Label();
            this.textEdit1 = new TextEdit();
            this.textEdit2 = new TextEdit();
            this.simpleButtonOK = new SimpleButton();
            this.imageList3 = new ImageList(this.components);
            this.imageList1 = new ImageList(this.components);
            this.LabelProgressBar = new Label();
            this.LabelLoadInfo = new Label();
            this.LabelProgressBack = new Label();
            this.panelLogin = new Panel();
            this.simpleButtonCancel = new SimpleButton();
            this.panelProgress = new Panel();
            this.toolTipController1 = new ToolTipController(this.components);
            this.labelN2 = new Label();
            this.labelN5 = new Label();
            this.labelN0 = new Label();
            this.imageList4 = new ImageList(this.components);
            this.lablekind = new Label();
            this.simpleButton0 = new SimpleButton();
            this.labelN6 = new Label();
            this.labelN7 = new Label();
            this.textEdit1.Properties.BeginInit();
            this.textEdit2.Properties.BeginInit();
            this.panelLogin.SuspendLayout();
            this.panelProgress.SuspendLayout();
            base.SuspendLayout();
            this.label.BackColor = Color.Transparent;
            this.label.Cursor = Cursors.Hand;
            this.label.Location = new Point(0xf3, 8);
            this.label.Name = "label";
            this.label.Size = new Size(0x63, 0x63);
            this.label.TabIndex = 0;
            this.labelN3.BackColor = Color.Transparent;
            this.labelN3.Cursor = Cursors.Hand;
            this.labelN3.ImageList = this.imageList2;
            this.labelN3.Location = new Point(0xb8, 0x178);
            this.labelN3.Name = "labelN3";
            this.labelN3.Size = new Size(100, 100);
            this.labelN3.TabIndex = 1;
            this.toolTipController1.SetTitle(this.labelN3, "林权宗地变更");
            this.labelN3.MouseLeave += new EventHandler(this.labelLingai_MouseLeave);
            this.labelN3.Click += new EventHandler(this.labelLingai_Click);
            this.labelN3.MouseDown += new MouseEventHandler(this.labelLingai_MouseDown);
            this.labelN3.MouseUp += new MouseEventHandler(this.labelLingai_MouseUp);
            this.labelN3.MouseEnter += new EventHandler(this.labelLingai_MouseEnter);
            this.imageList2.ImageStream = (ImageListStreamer)resources.GetObject("imageList2.ImageStream");
            this.imageList2.TransparentColor = Color.Transparent;
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
            this.labelN1.BackColor = Color.Transparent;
            this.labelN1.Cursor = Cursors.Hand;
            this.labelN1.ImageList = this.imageList2;
            this.labelN1.Location = new Point(0x10, 0xeb);
            this.labelN1.Name = "labelN1";
            this.labelN1.Size = new Size(100, 100);
            this.labelN1.TabIndex = 2;
            this.toolTipController1.SetTitle(this.labelN1, "造林作业");
            this.labelN1.MouseLeave += new EventHandler(this.labelZaolin_MouseLeave);
            this.labelN1.Click += new EventHandler(this.labelZaolin_Click);
            this.labelN1.MouseDown += new MouseEventHandler(this.labelZaolin_MouseDown);
            this.labelN1.MouseUp += new MouseEventHandler(this.labelZaolin_MouseUp);
            this.labelN1.MouseEnter += new EventHandler(this.labelZaolin_MouseEnter);
            this.label4.BackColor = Color.Transparent;
            this.label4.Cursor = Cursors.Hand;
            this.label4.Location = new Point(0x10, 0x160);
            this.label4.Name = "label4";
            this.label4.Size = new Size(0x63, 0x63);
            this.label4.TabIndex = 3;
            this.labelN4.BackColor = Color.Transparent;
            this.labelN4.Cursor = Cursors.Hand;
            this.labelN4.ImageList = this.imageList2;
            this.labelN4.Location = new Point(0x128, 0x18b);
            this.labelN4.Name = "labelN4";
            this.labelN4.Size = new Size(100, 100);
            this.labelN4.TabIndex = 4;
            this.toolTipController1.SetTitle(this.labelN4, "通用编辑");
            this.labelN4.MouseLeave += new EventHandler(this.labelXiaoban_MouseLeave);
            this.labelN4.Click += new EventHandler(this.labelXiaoban_Click);
            this.labelN4.MouseDown += new MouseEventHandler(this.labelXiaoban_MouseDown);
            this.labelN4.MouseUp += new MouseEventHandler(this.labelXiaoban_MouseUp);
            this.labelN4.MouseEnter += new EventHandler(this.labelXiaoban_MouseEnter);
            this.label1.AutoSize = true;
            this.label1.BackColor = Color.Transparent;
            this.label1.ForeColor = Color.FromArgb(0, 0, 0x40);
            this.label1.Location = new Point(9, 12);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0x2f, 14);
            this.label1.TabIndex = 6;
            this.label1.Text = "用户名:";
            this.label2.AutoSize = true;
            this.label2.BackColor = Color.Transparent;
            this.label2.ForeColor = Color.FromArgb(0, 0, 0x40);
            this.label2.Location = new Point(9, 0x42);
            this.label2.Name = "label2";
            this.label2.Size = new Size(0x23, 14);
            this.label2.TabIndex = 7;
            this.label2.Text = "密码:";
            this.textEdit1.EditValue = "xiaoyao";
            this.textEdit1.Location = new Point(0x48, 8);
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.Properties.Appearance.BackColor = Color.WhiteSmoke;
            this.textEdit1.Properties.Appearance.ForeColor = Color.FromArgb(0, 0, 0x40);
            this.textEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.textEdit1.Properties.Appearance.Options.UseForeColor = true;
            this.textEdit1.Size = new Size(100, 0x15);
            this.textEdit1.TabIndex = 0;
            this.textEdit1.KeyPress += new KeyPressEventHandler(this.textEdit1_KeyPress);
            this.textEdit2.EditValue = "1";
            this.textEdit2.Location = new Point(0x48, 0x3f);
            this.textEdit2.Name = "textEdit2";
            this.textEdit2.Properties.Appearance.BackColor = Color.WhiteSmoke;
            this.textEdit2.Properties.Appearance.ForeColor = Color.FromArgb(0, 0, 0x40);
            this.textEdit2.Properties.Appearance.Options.UseBackColor = true;
            this.textEdit2.Properties.Appearance.Options.UseForeColor = true;
            this.textEdit2.Properties.PasswordChar = '*';
            this.textEdit2.Size = new Size(100, 0x15);
            this.textEdit2.TabIndex = 1;
            this.simpleButtonOK.Cursor = Cursors.Hand;
            this.simpleButtonOK.ImageIndex = 0;
            this.simpleButtonOK.ImageList = this.imageList3;
            this.simpleButtonOK.ImageLocation = ImageLocation.MiddleCenter;
            this.simpleButtonOK.Location = new Point(0xb8, 0);
            this.simpleButtonOK.Name = "simpleButtonOK";
            this.simpleButtonOK.Size = new Size(0x6c, 0x1d);
            this.simpleButtonOK.TabIndex = 2;
            this.simpleButtonOK.MouseLeave += new EventHandler(this.simpleButtonOK_MouseLeave);
            this.simpleButtonOK.Click += new EventHandler(this.simpleButtonOK_Click);
            this.simpleButtonOK.MouseDown += new MouseEventHandler(this.simpleButtonOK_MouseDown);
            this.simpleButtonOK.MouseUp += new MouseEventHandler(this.simpleButtonOK_MouseUp);
            this.simpleButtonOK.MouseEnter += new EventHandler(this.simpleButtonOK_MouseEnter);
            this.imageList3.ImageStream = (ImageListStreamer)resources.GetObject("imageList3.ImageStream");
            this.imageList3.TransparentColor = Color.Transparent;
            this.imageList3.Images.SetKeyName(0, "sjcj_login_03.png");
            this.imageList3.Images.SetKeyName(1, "sjcj_login_03dowen.png");
            this.imageList3.Images.SetKeyName(2, "sjcj_login_03up.png");
            this.imageList3.Images.SetKeyName(3, "sjcj_login_04.png");
            this.imageList3.Images.SetKeyName(4, "sjcj_login_04dowen.png");
            this.imageList3.Images.SetKeyName(5, "sjcj_login_04up.png");
            this.imageList1.ImageStream = (ImageListStreamer)resources.GetObject("imageList1.ImageStream");
            this.imageList1.TransparentColor = Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "LoginButtonD.bmp");
            this.imageList1.Images.SetKeyName(1, "LoginButtonO.bmp");
            this.imageList1.Images.SetKeyName(2, "LoginButtonE.bmp");
            this.imageList1.Images.SetKeyName(3, "LoginButtonC.bmp");
            this.LabelProgressBar.BackColor = Color.Gold;
            this.LabelProgressBar.Location = new Point(3, 0x1b);
            this.LabelProgressBar.Name = "LabelProgressBar";
            this.LabelProgressBar.Size = new Size(0x75, 2);
            this.LabelProgressBar.TabIndex = 13;
            this.LabelLoadInfo.BackColor = Color.Transparent;
            this.LabelLoadInfo.ForeColor = Color.FromArgb(0xff, 0x80, 0);
            this.LabelLoadInfo.Location = new Point(30, 0);
            this.LabelLoadInfo.Name = "LabelLoadInfo";
            this.LabelLoadInfo.Size = new Size(0x102, 0x13);
            this.LabelLoadInfo.TabIndex = 12;
            this.LabelLoadInfo.Text = "系统启动中, 请稍后...";
            this.LabelLoadInfo.TextAlign = ContentAlignment.MiddleLeft;
            this.LabelProgressBack.BackColor = Color.White;
            this.LabelProgressBack.BorderStyle = BorderStyle.FixedSingle;
            this.LabelProgressBack.ForeColor = Color.White;
            this.LabelProgressBack.Location = new Point(2, 0x1a);
            this.LabelProgressBack.Name = "LabelProgressBack";
            this.LabelProgressBack.Size = new Size(320, 4);
            this.LabelProgressBack.TabIndex = 11;
            this.panelLogin.BackColor = Color.Transparent;
            this.panelLogin.Controls.Add(this.simpleButtonCancel);
            this.panelLogin.Controls.Add(this.label1);
            this.panelLogin.Controls.Add(this.label2);
            this.panelLogin.Controls.Add(this.textEdit1);
            this.panelLogin.Controls.Add(this.textEdit2);
            this.panelLogin.Controls.Add(this.simpleButtonOK);
            this.panelLogin.Enabled = false;
            this.panelLogin.Location = new Point(0x22d, 370);
            this.panelLogin.Name = "panelLogin";
            this.panelLogin.Size = new Size(0x152, 0x69);
            this.panelLogin.TabIndex = 14;
            this.simpleButtonCancel.Cursor = Cursors.Hand;
            this.simpleButtonCancel.ImageIndex = 3;
            this.simpleButtonCancel.ImageList = this.imageList3;
            this.simpleButtonCancel.ImageLocation = ImageLocation.MiddleCenter;
            this.simpleButtonCancel.Location = new Point(0xb8, 0x35);
            this.simpleButtonCancel.Name = "simpleButtonCancel";
            this.simpleButtonCancel.Size = new Size(0x6c, 0x1d);
            this.simpleButtonCancel.TabIndex = 8;
            this.simpleButtonCancel.Click += new EventHandler(this.simpleButtonCancel_Click);
            this.panelProgress.BackColor = Color.Transparent;
            this.panelProgress.Controls.Add(this.LabelLoadInfo);
            this.panelProgress.Controls.Add(this.LabelProgressBar);
            this.panelProgress.Controls.Add(this.LabelProgressBack);
            this.panelProgress.Location = new Point(0x20f, 0x1a5);
            this.panelProgress.Name = "panelProgress";
            this.panelProgress.Size = new Size(0x152, 0x2c);
            this.panelProgress.TabIndex = 15;
            this.panelProgress.Visible = false;
            this.labelN2.BackColor = Color.Transparent;
            this.labelN2.Cursor = Cursors.Hand;
            this.labelN2.ImageList = this.imageList2;
            this.labelN2.Location = new Point(0x48, 0x14d);
            this.labelN2.Name = "labelN2";
            this.labelN2.Size = new Size(100, 100);
            this.labelN2.TabIndex = 0x13;
            this.toolTipController1.SetTitle(this.labelN2, "采伐作业");
            this.labelN2.MouseLeave += new EventHandler(this.labelCaifa_MouseLeave);
            this.labelN2.Click += new EventHandler(this.labelCaifa_Click);
            this.labelN2.MouseDown += new MouseEventHandler(this.labelCaifa_MouseDown);
            this.labelN2.MouseUp += new MouseEventHandler(this.labelCaifa_MouseUp);
            this.labelN2.MouseEnter += new EventHandler(this.labelCaifa_MouseEnter);
            this.labelN5.BackColor = Color.Transparent;
            this.labelN5.Cursor = Cursors.Hand;
            this.labelN5.ImageList = this.imageList2;
            this.labelN5.Location = new Point(0x192, 0x17d);
            this.labelN5.Name = "labelN5";
            this.labelN5.Size = new Size(100, 100);
            this.labelN5.TabIndex = 0x15;
            this.toolTipController1.SetTitle(this.labelN5, "公益林编辑");
            this.labelN5.MouseLeave += new EventHandler(this.labelGYL_MouseLeave);
            this.labelN5.Click += new EventHandler(this.labelGYL_Click);
            this.labelN5.MouseDown += new MouseEventHandler(this.labelGYL_MouseDown);
            this.labelN5.MouseUp += new MouseEventHandler(this.labelGYL_MouseUp);
            this.labelN5.MouseEnter += new EventHandler(this.labelGYL_MouseEnter);
            this.labelN0.BackColor = Color.Transparent;
            this.labelN0.Cursor = Cursors.Hand;
            this.labelN0.ImageList = this.imageList4;
            this.labelN0.Location = new Point(0x16, 0x81);
            this.labelN0.Name = "labelN0";
            this.labelN0.Size = new Size(100, 100);
            this.labelN0.TabIndex = 0x17;
            this.toolTipController1.SetTitle(this.labelN0, "通用编辑");
            this.labelN0.Click += new EventHandler(this.labelXiaobanUpdate_Click);
            this.imageList4.ImageStream = (ImageListStreamer)resources.GetObject("imageList4.ImageStream");
            this.imageList4.TransparentColor = Color.White;
            this.imageList4.Images.SetKeyName(0, "无标题3.png");
            this.lablekind.BackColor = Color.Transparent;
            this.lablekind.Font = new Font("微软雅黑", 14.25f, FontStyle.Bold, GraphicsUnit.Point, 0x86);
            this.lablekind.ForeColor = Color.Honeydew;
            this.lablekind.Location = new Point(0x22b, 0xca);
            this.lablekind.Name = "lablekind";
            this.lablekind.Size = new Size(0xcd, 0x26);
            this.lablekind.TabIndex = 0x16;
            this.lablekind.Text = "造林设计模式";
            this.lablekind.TextAlign = ContentAlignment.MiddleCenter;
            this.lablekind.Visible = false;
            this.simpleButton0.Appearance.BackColor = Color.Fuchsia;
            this.simpleButton0.Appearance.BackColor2 = Color.Blue;
            this.simpleButton0.Appearance.BorderColor = Color.Fuchsia;
            this.simpleButton0.Appearance.Options.UseBackColor = true;
            this.simpleButton0.Appearance.Options.UseBorderColor = true;
            this.simpleButton0.Location = new Point(0x31c, 8);
            this.simpleButton0.LookAndFeel.SkinName = "The Asphalt World";
            this.simpleButton0.LookAndFeel.Style = LookAndFeelStyle.Office2003;
            this.simpleButton0.LookAndFeel.UseDefaultLookAndFeel = false;
            this.simpleButton0.Name = "simpleButton0";
            this.simpleButton0.Size = new Size(0x68, 0x68);
            this.simpleButton0.TabIndex = 0x12;
            this.simpleButton0.Visible = false;
            this.labelN6.BackColor = Color.Transparent;
            this.labelN6.Cursor = Cursors.Hand;
            this.labelN6.ImageList = this.imageList2;
            this.labelN6.Location = new Point(0x1d7, 0x120);
            this.labelN6.Name = "labelN6";
            this.labelN6.Size = new Size(100, 100);
            this.labelN6.TabIndex = 0x18;
            this.toolTipController1.SetTitle(this.labelN6, "公益林编辑");
            this.labelN7.BackColor = Color.Transparent;
            this.labelN7.Cursor = Cursors.Hand;
            this.labelN7.ImageList = this.imageList2;
            this.labelN7.Location = new Point(0x1c4, 0xb2);
            this.labelN7.Name = "labelN7";
            this.labelN7.Size = new Size(100, 100);
            this.labelN7.TabIndex = 0x19;
            this.toolTipController1.SetTitle(this.labelN7, "编辑");
            base.Appearance.BackColor = Color.FromArgb(0x25, 0x39, 0x54);
            base.Appearance.Options.UseBackColor = true;
            base.AutoScaleDimensions = new SizeF(7f, 14f);
//            base.AutoScaleMode = AutoScaleMode.Font;
            base.BackgroundImageLayoutStore = ImageLayout.Zoom;
            base.BackgroundImageStore = (Image)resources.GetObject("$this.BackgroundImageStore");
            base.ClientSize = new Size(870, 550);
            base.Controls.Add(this.labelN7);
            base.Controls.Add(this.labelN6);
            base.Controls.Add(this.labelN5);
            base.Controls.Add(this.labelN3);
            base.Controls.Add(this.labelN4);
            base.Controls.Add(this.labelN0);
            base.Controls.Add(this.panelProgress);
            base.Controls.Add(this.lablekind);
            base.Controls.Add(this.labelN2);
            base.Controls.Add(this.label4);
            base.Controls.Add(this.label);
            base.Controls.Add(this.labelN1);
            base.Controls.Add(this.panelLogin);
            base.Controls.Add(this.simpleButton0);
            this.DoubleBuffered = true;
        //    base.FormBorderStyle = FormBorderStyle.None;
            base.Icon = (Icon)resources.GetObject("$this.Icon");
            base.Name = "FormSplash";
            base.ShowInTaskbar = false;
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "登录";
            base.TransparencyKey = Color.FromArgb(0x25, 0x39, 0x54);
            base.Deactivate += new EventHandler(this.frmSplash_Deactivate);
            base.Load += new EventHandler(this.frmSplash_Load);
            base.FormClosed += new FormClosedEventHandler(this.frmSplash_FormClosed);
            base.KeyPress += new KeyPressEventHandler(this.frmSplash_KeyPress);
            base.KeyDown += new KeyEventHandler(this.frmSplash_KeyDown);
            this.textEdit1.Properties.EndInit();
            this.textEdit2.Properties.EndInit();
            this.panelLogin.ResumeLayout(false);
            this.panelLogin.PerformLayout();
            this.panelProgress.ResumeLayout(false);
            base.ResumeLayout(false);
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
            string text = this.textEdit1.Text;
            string text2 = this.textEdit2.Text;
            base.Hide();
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

