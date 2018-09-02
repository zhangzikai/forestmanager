namespace DataEdit
{
    using DevExpress.XtraEditors;
    using ESRI.ArcGIS.Controls;
    using ESRI.ArcGIS.Geodatabase;
    using ESRI.ArcGIS.Geometry;
    using FormBase;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class FormInputDataQuestion : FormBase2
    {
        private CheckEdit checkRedo;
        private IContainer components = null;
        internal ImageList ImageList1;
        public Label label4;
        private IFeature mFeature;
        private HookHelper mHookHelper = null;
        private IRow mRow;
        private PanelControl panelControl1;
        private Panel panelQuestion;
        public bool Redo = false;
        public int Result;
        private SimpleButton simpleButtonCancel;
        private SimpleButton simpleButtonContinue;
        private SimpleButton simpleButtonJump;
        private SimpleButton simpleButtonView;

        public FormInputDataQuestion(IFeature pFeature, HookHelper hookhelper)
        {
            this.InitializeComponent();
            this.panelControl1.Visible = true;
            this.panelQuestion.Visible = true;
            this.mHookHelper = hookhelper;
            this.mFeature = pFeature;
            if (this.mFeature == null)
            {
                this.simpleButtonView.Visible = false;
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

        private void InitializeComponent()
        {
            this.components = new Container();
            ComponentResourceManager resources = new ComponentResourceManager(typeof(FormInputDataQuestion));
            this.ImageList1 = new ImageList(this.components);
            this.panelQuestion = new Panel();
            this.label4 = new Label();
            this.simpleButtonView = new SimpleButton();
            this.simpleButtonCancel = new SimpleButton();
            this.simpleButtonJump = new SimpleButton();
            this.simpleButtonContinue = new SimpleButton();
            this.panelControl1 = new PanelControl();
            this.checkRedo = new CheckEdit();
            this.panelQuestion.SuspendLayout();
            this.panelControl1.BeginInit();
            this.panelControl1.SuspendLayout();
            this.checkRedo.Properties.BeginInit();
            base.SuspendLayout();
            this.ImageList1.ImageStream = (ImageListStreamer)resources.GetObject("ImageList1.ImageStream");
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
            this.ImageList1.Images.SetKeyName(0x5d, "Tipicon.ico");
            this.panelQuestion.Controls.Add(this.label4);
            this.panelQuestion.Controls.Add(this.simpleButtonView);
            this.panelQuestion.Dock = DockStyle.Top;
            this.panelQuestion.Location = new System.Drawing.Point(8, 2);
            this.panelQuestion.Name = "panelQuestion";
            this.panelQuestion.Padding = new Padding(3, 9, 9, 9);
            this.panelQuestion.Size = new Size(0x11f, 0x2f);
            this.panelQuestion.TabIndex = 0x12;
            this.panelQuestion.Visible = false;
            this.label4.BackColor = Color.Transparent;
            this.label4.Dock = DockStyle.Fill;
            this.label4.Image = (Image)resources.GetObject("label4.Image");
            this.label4.ImageAlign = ContentAlignment.MiddleLeft;
            this.label4.Location = new System.Drawing.Point(3, 9);
            this.label4.Name = "label4";
            this.label4.Size = new Size(0xd1, 0x1d);
            this.label4.TabIndex = 9;
            this.label4.Text = "      相同位置已存在小班";
            this.label4.TextAlign = ContentAlignment.MiddleLeft;
            this.simpleButtonView.Cursor = Cursors.Hand;
            this.simpleButtonView.Dock = DockStyle.Right;
            this.simpleButtonView.ImageIndex = 9;
            this.simpleButtonView.ImageList = this.ImageList1;
            this.simpleButtonView.Location = new System.Drawing.Point(0xd4, 9);
            this.simpleButtonView.Name = "simpleButtonView";
            this.simpleButtonView.Size = new Size(0x42, 0x1d);
            this.simpleButtonView.TabIndex = 0x13;
            this.simpleButtonView.Text = "查看";
            this.simpleButtonView.ToolTip = "查看已有小班";
            this.simpleButtonView.Click += new EventHandler(this.simpleButtonView_Click);
            this.simpleButtonCancel.Cursor = Cursors.Hand;
            this.simpleButtonCancel.ImageIndex = 0x43;
            this.simpleButtonCancel.ImageList = this.ImageList1;
            this.simpleButtonCancel.Location = new System.Drawing.Point(0xcb, 0x38);
            this.simpleButtonCancel.Name = "simpleButtonCancel";
            this.simpleButtonCancel.Size = new Size(0x52, 0x1c);
            this.simpleButtonCancel.TabIndex = 15;
            this.simpleButtonCancel.Text = "取消";
            this.simpleButtonCancel.ToolTip = "结束导入";
            this.simpleButtonCancel.Click += new EventHandler(this.simpleButtonCancel_Click);
            this.simpleButtonJump.Cursor = Cursors.Hand;
            this.simpleButtonJump.ImageIndex = 0x44;
            this.simpleButtonJump.ImageList = this.ImageList1;
            this.simpleButtonJump.Location = new System.Drawing.Point(0x6b, 0x38);
            this.simpleButtonJump.Name = "simpleButtonJump";
            this.simpleButtonJump.Size = new Size(0x52, 0x1c);
            this.simpleButtonJump.TabIndex = 14;
            this.simpleButtonJump.Text = "跳过";
            this.simpleButtonJump.ToolTip = "忽略当前小班";
            this.simpleButtonJump.Click += new EventHandler(this.simpleButtonJump_Click);
            this.simpleButtonContinue.Cursor = Cursors.Hand;
            this.simpleButtonContinue.ImageIndex = 0x42;
            this.simpleButtonContinue.ImageList = this.ImageList1;
            this.simpleButtonContinue.Location = new System.Drawing.Point(12, 0x38);
            this.simpleButtonContinue.Name = "simpleButtonContinue";
            this.simpleButtonContinue.Size = new Size(0x52, 0x1c);
            this.simpleButtonContinue.TabIndex = 13;
            this.simpleButtonContinue.Text = "继续";
            this.simpleButtonContinue.ToolTip = "继续导入";
            this.simpleButtonContinue.Click += new EventHandler(this.simpleButtonContinue_Click);
            this.panelControl1.Controls.Add(this.checkRedo);
            this.panelControl1.Controls.Add(this.simpleButtonContinue);
            this.panelControl1.Controls.Add(this.panelQuestion);
            this.panelControl1.Controls.Add(this.simpleButtonJump);
            this.panelControl1.Controls.Add(this.simpleButtonCancel);
            this.panelControl1.Dock = DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(1, 1);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Padding = new Padding(6, 0, 0, 6);
            this.panelControl1.Size = new Size(0x129, 0x80);
            this.panelControl1.TabIndex = 0x13;
            this.checkRedo.Cursor = Cursors.Hand;
            this.checkRedo.Dock = DockStyle.Bottom;
            this.checkRedo.Location = new System.Drawing.Point(8, 0x65);
            this.checkRedo.Name = "checkRedo";
            this.checkRedo.Properties.Caption = "为之后冲突一直执行此操作:";
            this.checkRedo.Size = new Size(0x11f, 0x13);
            this.checkRedo.TabIndex = 0x13;
            base.Appearance.BackColor = Color.RoyalBlue;
            base.Appearance.Options.UseBackColor = true;
            base.AutoScaleDimensions = new SizeF(7f, 14f);
//            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x12b, 130);
            base.Controls.Add(this.panelControl1);
//            base.FormBorderStyle = FormBorderStyle.None;
            base.Icon = (Icon)resources.GetObject("$this.Icon");
            base.LookAndFeel.SkinName = "Blue";
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            base.Name = "FormInputDataQuestion";
            base.Padding = new Padding(1);
            base.StartPosition = FormStartPosition.CenterParent;
            this.Text = "数据导入";
            base.Controls.SetChildIndex(base.sButOk, 0);
            base.Controls.SetChildIndex(this.panelControl1, 0);
            this.panelQuestion.ResumeLayout(false);
            this.panelControl1.EndInit();
            this.panelControl1.ResumeLayout(false);
            this.checkRedo.Properties.EndInit();
            base.ResumeLayout(false);
        }

        private void simpleButtonCancel_Click(object sender, EventArgs e)
        {
            this.Result = 3;
            this.Redo = this.checkRedo.Checked;
            base.Hide();
        }

        private void simpleButtonContinue_Click(object sender, EventArgs e)
        {
            this.Result = 1;
            this.Redo = this.checkRedo.Checked;
            base.Hide();
        }

        private void simpleButtonJump_Click(object sender, EventArgs e)
        {
            this.Result = 2;
            this.Redo = this.checkRedo.Checked;
            base.Hide();
        }

        private void simpleButtonView_Click(object sender, EventArgs e)
        {
            try
            {
                IEnvelope envelope = this.mFeature.Shape.Envelope;
                if ((((envelope.XMin < this.mHookHelper.ActiveView.Extent.XMin) || (envelope.YMin < this.mHookHelper.ActiveView.Extent.YMin)) || (envelope.XMax > this.mHookHelper.ActiveView.Extent.XMax)) || (envelope.YMax > this.mHookHelper.ActiveView.Extent.YMax))
                {
                    envelope.Expand(2.0, 2.0, true);
                    this.mHookHelper.ActiveView.Extent = envelope;
                    this.mHookHelper.ActiveView.Refresh();
                }
                (this.mHookHelper.Hook as IMapControl2).FlashShape(this.mFeature.Shape, 1, 300, null);
            }
            catch (Exception)
            {
            }
        }
    }
}

