namespace DataEdit
{
    using DevExpress.XtraEditors;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class FormXY : Form
    {
        private IContainer components = null;
        private Label label44;
        private Label label45;
        private PanelControl panelControl1;
        private TextBox textBoxNane;
        private TextEdit textX;
        private TextEdit textY;
        public double X = 0.0;
        public double Y = 0.0;

        public FormXY()
        {
            this.InitializeComponent();
            this.textX.Focus();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void FormXY_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void InitializeComponent()
        {
            this.label45 = new Label();
            this.textY = new TextEdit();
            this.textX = new TextEdit();
            this.label44 = new Label();
            this.panelControl1 = new PanelControl();
            this.textBoxNane = new TextBox();
            this.textY.Properties.BeginInit();
            this.textX.Properties.BeginInit();
            this.panelControl1.BeginInit();
            this.panelControl1.SuspendLayout();
            base.SuspendLayout();
            this.label45.Location = new Point(0x75, 6);
            this.label45.Name = "label45";
            this.label45.Size = new Size(0x34, 14);
            this.label45.TabIndex = 0x31;
            this.label45.Text = " Y";
            this.textY.EditValue = "";
            this.textY.Location = new Point(0x75, 0x15);
            this.textY.Name = "textY";
            this.textY.Properties.Appearance.ForeColor = Color.Black;
            this.textY.Properties.Appearance.Options.UseForeColor = true;
            this.textY.Size = new Size(0x6d, 0x15);
            this.textY.TabIndex = 0x30;
            this.textY.KeyPress += new KeyPressEventHandler(this.textY_KeyPress);
            this.textX.EditValue = "";
            this.textX.Location = new Point(4, 0x15);
            this.textX.Name = "textX";
            this.textX.Properties.Appearance.ForeColor = Color.Black;
            this.textX.Properties.Appearance.Options.UseForeColor = true;
            this.textX.Size = new Size(0x6d, 0x15);
            this.textX.TabIndex = 0x2f;
            this.textX.KeyPress += new KeyPressEventHandler(this.textX_KeyPress);
            this.label44.Location = new Point(4, 6);
            this.label44.Name = "label44";
            this.label44.Size = new Size(0x34, 14);
            this.label44.TabIndex = 0x2e;
            this.label44.Text = " X";
            this.panelControl1.Appearance.BackColor = Color.White;
            this.panelControl1.Appearance.Options.UseBackColor = true;
            this.panelControl1.Controls.Add(this.textBoxNane);
            this.panelControl1.Dock = DockStyle.Fill;
            this.panelControl1.Location = new Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new Size(230, 50);
            this.panelControl1.TabIndex = 50;
            this.textBoxNane.BorderStyle = BorderStyle.None;
            this.textBoxNane.Dock = DockStyle.Fill;
            this.textBoxNane.Enabled = false;
            this.textBoxNane.Location = new Point(2, 2);
            this.textBoxNane.Multiline = true;
            this.textBoxNane.Name = "textBoxNane";
            this.textBoxNane.Size = new Size(0xe2, 0x2e);
            this.textBoxNane.TabIndex = 0;
            this.textBoxNane.KeyPress += new KeyPressEventHandler(this.textBoxNane_KeyPress);
            base.AutoScaleDimensions = new SizeF(6f, 12f);
//            base.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.White;
            base.ClientSize = new Size(230, 50);
            base.Controls.Add(this.label45);
            base.Controls.Add(this.textY);
            base.Controls.Add(this.textX);
            base.Controls.Add(this.label44);
            base.Controls.Add(this.panelControl1);
//            base.FormBorderStyle = FormBorderStyle.None;
            base.Name = "FormXY";
            base.ShowInTaskbar = false;
            base.StartPosition = FormStartPosition.Manual;
            this.Text = "FormXY";
            base.KeyPress += new KeyPressEventHandler(this.FormXY_KeyPress);
            this.textY.Properties.EndInit();
            this.textX.Properties.EndInit();
            this.panelControl1.EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            base.ResumeLayout(false);
        }

        public void SetXY(double x, double y)
        {
            this.textX.Text = x.ToString();
            this.textY.Text = y.ToString();
            this.X = x;
            this.Y = y;
        }

        private void textBoxNane_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void textX_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                if (this.textX.Text.Trim() != "")
                {
                    this.X = double.Parse(this.textX.Text.Trim());
                }
                this.textY.Select(0, this.textY.Text.Length);
                this.textY.Focus();
            }
        }

        private void textY_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                if (this.textX.Text.Trim() != "")
                {
                    this.X = double.Parse(this.textX.Text.Trim());
                }
                if (this.textY.Text.Trim() != "")
                {
                    this.Y = double.Parse(this.textY.Text.Trim());
                }
                base.Hide();
            }
        }
    }
}

