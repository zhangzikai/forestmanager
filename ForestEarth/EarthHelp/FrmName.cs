namespace ForestEarth.EarthHelp
{
    using DevExpress.XtraEditors;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class FrmName : Form
    {
        private SimpleButton btn_cancel;
        private SimpleButton btn_ok;
        private IContainer components;
        public string m_name;
        private TextEdit te_name;

        public FrmName()
        {
            this.InitializeComponent();
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.te_name.Text = string.Empty;
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.te_name.Text.Trim()))
            {
                this.m_name = "未命名";
            }
            else
            {
                this.m_name = this.te_name.Text.Trim();
            }
            base.Close();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        public string GetName()
        {
            return this.m_name;
        }

        private void InitializeComponent()
        {
            ComponentResourceManager manager = new ComponentResourceManager(typeof(FrmName));
            this.te_name = new TextEdit();
            this.btn_ok = new SimpleButton();
            this.btn_cancel = new SimpleButton();
            this.te_name.Properties.BeginInit();
            base.SuspendLayout();
            this.te_name.Location = new Point(12, 0x15);
            this.te_name.Name = "te_name";
            this.te_name.Size = new Size(250, 0x15);
            this.te_name.TabIndex = 0;
            this.btn_ok.Image = (Image) manager.GetObject("btn_ok.Image");
            this.btn_ok.Location = new Point(0x30, 0x43);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new Size(60, 0x17);
            this.btn_ok.TabIndex = 1;
            this.btn_ok.Text = "确定";
            this.btn_ok.Click += new EventHandler(this.btn_ok_Click);
            this.btn_cancel.Image = (Image) manager.GetObject("btn_cancel.Image");
            this.btn_cancel.Location = new Point(0xa7, 0x43);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new Size(60, 0x17);
            this.btn_cancel.TabIndex = 2;
            this.btn_cancel.Text = "取消";
            this.btn_cancel.Click += new EventHandler(this.btn_cancel_Click);
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x112, 0x67);
            base.Controls.Add(this.btn_cancel);
            base.Controls.Add(this.btn_ok);
            base.Controls.Add(this.te_name);
            base.FormBorderStyle = FormBorderStyle.FixedSingle;
            base.Icon = (Icon) manager.GetObject("$this.Icon");
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            base.Name = "FrmName";
            base.StartPosition = FormStartPosition.Manual;
            this.Text = "输入名称";
            this.te_name.Properties.EndInit();
            base.ResumeLayout(false);
        }
    }
}

