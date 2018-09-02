namespace ForestEarth.EarthHelp
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class FrmInformation : Form
    {
        private IContainer components;
        private RichTextBox rtb_infor;

        public FrmInformation()
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
            this.rtb_infor = new RichTextBox();
            base.SuspendLayout();
            this.rtb_infor.Dock = DockStyle.Fill;
            this.rtb_infor.Font = new Font("宋体", 12f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.rtb_infor.ForeColor = Color.Red;
            this.rtb_infor.Location = new Point(0, 0);
            this.rtb_infor.Name = "rtb_infor";
            this.rtb_infor.Size = new Size(0x1bc, 0x36);
            this.rtb_infor.TabIndex = 0;
            this.rtb_infor.Text = "";
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x1bc, 0x36);
            base.Controls.Add(this.rtb_infor);
            base.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            base.Name = "FrmInformation";
            base.StartPosition = FormStartPosition.Manual;
            this.Text = "信息：";
            base.ResumeLayout(false);
        }

        public string Information
        {
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    this.rtb_infor.Text = value;
                }
            }
        }
    }
}

