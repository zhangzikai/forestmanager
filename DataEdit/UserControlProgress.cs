namespace DataEdit
{
    using DevExpress.XtraEditors;
    using FormBase;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class UserControlProgress : UserControlBase1
    {
        private IContainer components = null;
        internal ImageList ImageList1;
        public Label labelInfo;
        public Label labelTitle;
        private Panel panel1;
        private Panel panel2;
        private PanelControl panelControl1;
        public ProgressBarControl progressBarControl1;
        public RichTextBox richTextBox;
        private SimpleButton simpleButtonCancle;
        private SimpleButton simpleButtonStop;

        public UserControlProgress()
        {
            this.InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new Container();
            ComponentResourceManager resources = new ComponentResourceManager(typeof(UserControlProgress));
            this.progressBarControl1 = new ProgressBarControl();
            this.richTextBox = new RichTextBox();
            this.panelControl1 = new PanelControl();
            this.panel1 = new Panel();
            this.panel2 = new Panel();
            this.simpleButtonStop = new SimpleButton();
            this.ImageList1 = new ImageList(this.components);
            this.simpleButtonCancle = new SimpleButton();
            this.labelInfo = new Label();
            this.labelTitle = new Label();
            this.progressBarControl1.Properties.BeginInit();
            this.panelControl1.BeginInit();
            this.panelControl1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            base.SuspendLayout();
            this.progressBarControl1.Dock = DockStyle.Top;
            this.progressBarControl1.EditValue = "60";
            this.progressBarControl1.Location = new Point(0, 0x4a);
            this.progressBarControl1.Name = "progressBarControl1";
            this.progressBarControl1.Properties.Appearance.BorderColor = Color.Transparent;
            this.progressBarControl1.Properties.Appearance.ForeColor = Color.FromArgb(0xc0, 0, 0);
            this.progressBarControl1.Properties.EndColor = Color.FromArgb(0xff, 0x80, 0);
            this.progressBarControl1.Properties.LookAndFeel.SkinName = "Blue";
            this.progressBarControl1.Properties.ShowTitle = true;
            this.progressBarControl1.Properties.StartColor = Color.FromArgb(0x80, 0xff, 0xff);
            this.progressBarControl1.Properties.Step = 1;
            this.progressBarControl1.Size = new Size(0x159, 0x15);
            this.progressBarControl1.TabIndex = 1;
//            this.richTextBox.BorderStyle = BorderStyle.None;
            this.richTextBox.Dock = DockStyle.Fill;
            this.richTextBox.Location = new Point(2, 2);
            this.richTextBox.Name = "richTextBox";
            this.richTextBox.Size = new Size(0x155, 0x13d);
            this.richTextBox.TabIndex = 2;
            this.richTextBox.Text = "";
            this.richTextBox.TextChanged += new EventHandler(this.richTextBox_TextChanged);
            this.panelControl1.Controls.Add(this.richTextBox);
            this.panelControl1.Dock = DockStyle.Fill;
            this.panelControl1.Location = new Point(9, 0x77);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new Size(0x159, 0x141);
            this.panelControl1.TabIndex = 3;
            this.panelControl1.Paint += new PaintEventHandler(this.panelControl1_Paint);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.progressBarControl1);
            this.panel1.Controls.Add(this.labelInfo);
            this.panel1.Controls.Add(this.labelTitle);
            this.panel1.Dock = DockStyle.Top;
            this.panel1.Location = new Point(9, 9);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new Padding(0, 0, 0, 14);
            this.panel1.Size = new Size(0x159, 110);
            this.panel1.TabIndex = 4;
            this.panel1.Paint += new PaintEventHandler(this.panel1_Paint);
            this.panel2.Controls.Add(this.simpleButtonStop);
            this.panel2.Controls.Add(this.simpleButtonCancle);
            this.panel2.Dock = DockStyle.Top;
            this.panel2.Location = new Point(0, 0x5f);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new Padding(0, 12, 0, 0);
            this.panel2.Size = new Size(0x159, 0x2a);
            this.panel2.TabIndex = 6;
            this.panel2.Visible = false;
            this.panel2.Paint += new PaintEventHandler(this.panel2_Paint);
            this.simpleButtonStop.Enabled = false;
            this.simpleButtonStop.ImageIndex = 0x51;
            this.simpleButtonStop.ImageList = this.ImageList1;
            this.simpleButtonStop.Location = new Point(0xa2, 12);
            this.simpleButtonStop.Name = "simpleButtonStop";
            this.simpleButtonStop.Size = new Size(0x57, 0x1b);
            this.simpleButtonStop.TabIndex = 5;
            this.simpleButtonStop.Text = "暂停";
            this.simpleButtonStop.Visible = false;
            this.simpleButtonStop.Click += new EventHandler(this.simpleButtonStop_Click);
            this.ImageList1.ImageStream = (ImageListStreamer) resources.GetObject("ImageList1.ImageStream");
            this.ImageList1.TransparentColor = Color.Transparent;
            this.ImageList1.Images.SetKeyName(0, "blank16.ico");
            this.ImageList1.Images.SetKeyName(1, "tick16.ico");
            this.ImageList1.Images.SetKeyName(2, "PART16.ICO");
            this.ImageList1.Images.SetKeyName(3, "");
            this.ImageList1.Images.SetKeyName(4, "");
            this.ImageList1.Images.SetKeyName(5, "");
            this.ImageList1.Images.SetKeyName(6, "");
            this.ImageList1.Images.SetKeyName(7, "");
            this.ImageList1.Images.SetKeyName(8, "");
            this.ImageList1.Images.SetKeyName(9, "");
            this.ImageList1.Images.SetKeyName(10, "");
            this.ImageList1.Images.SetKeyName(11, "");
            this.ImageList1.Images.SetKeyName(12, "");
            this.ImageList1.Images.SetKeyName(13, "");
            this.ImageList1.Images.SetKeyName(14, "");
            this.ImageList1.Images.SetKeyName(15, "");
            this.ImageList1.Images.SetKeyName(0x10, "(30,24).png");
            this.ImageList1.Images.SetKeyName(0x11, "(00,02).png");
            this.ImageList1.Images.SetKeyName(0x12, "(00,17).png");
            this.ImageList1.Images.SetKeyName(0x13, "(00,46).png");
            this.ImageList1.Images.SetKeyName(20, "(01,10).png");
            this.ImageList1.Images.SetKeyName(0x15, "(01,25).png");
            this.ImageList1.Images.SetKeyName(0x16, "(05,32).png");
            this.ImageList1.Images.SetKeyName(0x17, "(06,32).png");
            this.ImageList1.Images.SetKeyName(0x18, "(07,32).png");
            this.ImageList1.Images.SetKeyName(0x19, "(08,32).png");
            this.ImageList1.Images.SetKeyName(0x1a, "(08,36).png");
            this.ImageList1.Images.SetKeyName(0x1b, "(09,36).png");
            this.ImageList1.Images.SetKeyName(0x1c, "(10,26).png");
            this.ImageList1.Images.SetKeyName(0x1d, "(11,26).png");
            this.ImageList1.Images.SetKeyName(30, "(11,29).png");
            this.ImageList1.Images.SetKeyName(0x1f, "(12,29).png");
            this.ImageList1.Images.SetKeyName(0x20, "(11,32).png");
            this.ImageList1.Images.SetKeyName(0x21, "(11,36).png");
            this.ImageList1.Images.SetKeyName(0x22, "(13,32).png");
            this.ImageList1.Images.SetKeyName(0x23, "(19,31).png");
            this.ImageList1.Images.SetKeyName(0x24, "(22,18).png");
            this.ImageList1.Images.SetKeyName(0x25, "(25,27).png");
            this.ImageList1.Images.SetKeyName(0x26, "(29,43).png");
            this.ImageList1.Images.SetKeyName(0x27, "(30,14).png");
            this.ImageList1.Images.SetKeyName(40, "5.png");
            this.ImageList1.Images.SetKeyName(0x29, "10.png");
            this.ImageList1.Images.SetKeyName(0x2a, "11.png");
            this.ImageList1.Images.SetKeyName(0x2b, "16.png");
            this.ImageList1.Images.SetKeyName(0x2c, "17.png");
            this.ImageList1.Images.SetKeyName(0x2d, "18.png");
            this.ImageList1.Images.SetKeyName(0x2e, "19.png");
            this.ImageList1.Images.SetKeyName(0x2f, "20.png");
            this.ImageList1.Images.SetKeyName(0x30, "21.png");
            this.ImageList1.Images.SetKeyName(0x31, "22.png");
            this.ImageList1.Images.SetKeyName(50, "25.png");
            this.ImageList1.Images.SetKeyName(0x33, "31.png");
            this.ImageList1.Images.SetKeyName(0x34, "41.png");
            this.ImageList1.Images.SetKeyName(0x35, "add.png");
            this.ImageList1.Images.SetKeyName(0x36, "bullet_minus.png");
            this.ImageList1.Images.SetKeyName(0x37, "control_add_blue.png");
            this.ImageList1.Images.SetKeyName(0x38, "control_power_blue.png");
            this.ImageList1.Images.SetKeyName(0x39, "control_remove_blue.png");
            this.ImageList1.Images.SetKeyName(0x3a, "cross.png");
            this.ImageList1.Images.SetKeyName(0x3b, "down.png");
            this.ImageList1.Images.SetKeyName(60, "draw_tools.png");
            this.ImageList1.Images.SetKeyName(0x3d, "Feedicons_v2_010.png");
            this.ImageList1.Images.SetKeyName(0x3e, "Feedicons_v2_011.png");
            this.ImageList1.Images.SetKeyName(0x3f, "Feedicons_v2_031.png");
            this.ImageList1.Images.SetKeyName(0x40, "Feedicons_v2_032.png");
            this.ImageList1.Images.SetKeyName(0x41, "Feedicons_v2_033.png");
            this.ImageList1.Images.SetKeyName(0x42, "flag blue.png");
            this.ImageList1.Images.SetKeyName(0x43, "flag red.png");
            this.ImageList1.Images.SetKeyName(0x44, "flag yellow.png");
            this.ImageList1.Images.SetKeyName(0x45, "31.png");
            this.ImageList1.Images.SetKeyName(70, "42.png");
            this.ImageList1.Images.SetKeyName(0x47, "control_add_blue.png");
            this.ImageList1.Images.SetKeyName(0x48, "control_remove_blue.png");
            this.ImageList1.Images.SetKeyName(0x49, "cursor.png");
            this.ImageList1.Images.SetKeyName(0x4a, "cursor_small.png");
            this.ImageList1.Images.SetKeyName(0x4b, "cut.png");
            this.ImageList1.Images.SetKeyName(0x4c, "cut_red.png");
            this.ImageList1.Images.SetKeyName(0x4d, "Feedicons_v2_010.png");
            this.ImageList1.Images.SetKeyName(0x4e, "Feedicons_v2_011.png");
            this.ImageList1.Images.SetKeyName(0x4f, "Feedicons_v2_024.png");
            this.ImageList1.Images.SetKeyName(80, "Feedicons_v2_026.png");
            this.ImageList1.Images.SetKeyName(0x51, "Feedicons_v2_031.png");
            this.ImageList1.Images.SetKeyName(0x52, "key.png");
            this.ImageList1.Images.SetKeyName(0x53, "page_add.png");
            this.ImageList1.Images.SetKeyName(0x54, "page_delete.png");
            this.ImageList1.Images.SetKeyName(0x55, "page_white_world.png");
            this.ImageList1.Images.SetKeyName(0x56, "page_world.png");
            this.ImageList1.Images.SetKeyName(0x57, "reload.png");
            this.ImageList1.Images.SetKeyName(0x58, "world_add.png");
            this.ImageList1.Images.SetKeyName(0x59, "world_delete.png");
            this.ImageList1.Images.SetKeyName(90, "zoom_in.png");
            this.ImageList1.Images.SetKeyName(0x5b, "zoom_out.png");
            this.ImageList1.Images.SetKeyName(0x5c, "control_power_blue.png");
            this.simpleButtonCancle.Dock = DockStyle.Right;
            this.simpleButtonCancle.Enabled = false;
            this.simpleButtonCancle.ImageIndex = 80;
            this.simpleButtonCancle.ImageList = this.ImageList1;
            this.simpleButtonCancle.Location = new Point(0x102, 12);
            this.simpleButtonCancle.Name = "simpleButtonCancle";
            this.simpleButtonCancle.Size = new Size(0x57, 30);
            this.simpleButtonCancle.TabIndex = 4;
            this.simpleButtonCancle.Text = "取消";
            this.simpleButtonCancle.Click += new EventHandler(this.simpleButtonCancle_Click);
            this.labelInfo.Dock = DockStyle.Top;
            this.labelInfo.ForeColor = Color.Black;
            this.labelInfo.Location = new Point(0, 30);
            this.labelInfo.Name = "labelInfo";
            this.labelInfo.Size = new Size(0x159, 0x2c);
            this.labelInfo.TabIndex = 3;
            this.labelInfo.Text = "正在备份数据";
            this.labelInfo.TextAlign = ContentAlignment.MiddleLeft;
            this.labelInfo.Click += new EventHandler(this.labelInfo_Click);
            this.labelTitle.Dock = DockStyle.Top;
            this.labelTitle.ForeColor = Color.Blue;
            this.labelTitle.Location = new Point(0, 0);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new Size(0x159, 30);
            this.labelTitle.TabIndex = 2;
            this.labelTitle.Text = "备份进度";
            this.labelTitle.TextAlign = ContentAlignment.MiddleLeft;
            this.labelTitle.Click += new EventHandler(this.labelTitle_Click);
            base.Appearance.BackColor = Color.FromArgb(0xe3, 0xf1, 0xfe);
            base.Appearance.BackColor2 = Color.FromArgb(0xe3, 0xf1, 0xfe);
            base.Appearance.Options.UseBackColor = true;
            base.AutoScaleDimensions = new SizeF(7f, 14f);
//            base.AutoScaleMode = AutoScaleMode.Font;
            base.Controls.Add(this.panelControl1);
            base.Controls.Add(this.panel1);
            base.Name = "UserControlProgress";
            base.Padding = new Padding(9);
            base.Size = new Size(0x16b, 0x1c1);
            this.progressBarControl1.Properties.EndInit();
            this.panelControl1.EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            base.ResumeLayout(false);
        }

        private void labelInfo_Click(object sender, EventArgs e)
        {
        }

        private void labelTitle_Click(object sender, EventArgs e)
        {
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
        }

        private void panelControl1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void richTextBox_TextChanged(object sender, EventArgs e)
        {
        }

        private void simpleButtonCancle_Click(object sender, EventArgs e)
        {
        }

        private void simpleButtonStop_Click(object sender, EventArgs e)
        {
        }
    }
}

