namespace OperateLog
{
    using FormBase;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class FormDataBaseLogin : FormBase2
    {
        private IContainer components;
        private UserControlDataBaseLogin userControlDataBaseLogin1;

        public FormDataBaseLogin()
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
            this.userControlDataBaseLogin1 = new UserControlDataBaseLogin();
            base.SuspendLayout();
            this.userControlDataBaseLogin1.Appearance.BackColor = Color.FromArgb(0xe3, 0xf1, 0xfe);
            this.userControlDataBaseLogin1.Appearance.BackColor2 = Color.FromArgb(0xe3, 0xf1, 0xfe);
            this.userControlDataBaseLogin1.Appearance.Options.UseBackColor = true;
            this.userControlDataBaseLogin1.Dock = DockStyle.Fill;
            this.userControlDataBaseLogin1.Location = new Point(0, 0);
            this.userControlDataBaseLogin1.Name = "userControlDataBaseLogin1";
            this.userControlDataBaseLogin1.Padding = new Padding(0, 2, 0, 0);
            this.userControlDataBaseLogin1.Size = new Size(0x155, 0x156);
            this.userControlDataBaseLogin1.TabIndex = 1;
            base.Appearance.BackColor = Color.FromArgb(0xe3, 0xf1, 0xfe);
            base.Appearance.Options.UseBackColor = true;
            base.AutoScaleDimensions = new SizeF(7f, 14f);
//            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x155, 0x156);
            base.Controls.Add(this.userControlDataBaseLogin1);
//            base.FormBorderStyle = FormBorderStyle.FixedDialog;
            base.LookAndFeel.SkinName = "Blue";
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            base.Name = "FormDataBaseLogin";
            base.ShowInTaskbar = false;
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "数据库连接";
            base.Controls.SetChildIndex(this.userControlDataBaseLogin1, 0);
            base.Controls.SetChildIndex(base.sButOk, 0);
            base.ResumeLayout(false);
        }

        public void SetCloseVisible(bool bVisible)
        {
            this.userControlDataBaseLogin1.simpleButtonCancel.Visible = bVisible;
        }
    }
}

