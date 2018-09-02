namespace DataEdit
{
    using FormBase;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class FormDataBaseLogin : FormBase2
    {
        private IContainer components = null;
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
            this.userControlDataBaseLogin1 = new DataEdit.UserControlDataBaseLogin();
            this.SuspendLayout();
            // 
            // userControlDataBaseLogin1
            // 
            this.userControlDataBaseLogin1.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.userControlDataBaseLogin1.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.userControlDataBaseLogin1.Appearance.Options.UseBackColor = true;
            this.userControlDataBaseLogin1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControlDataBaseLogin1.Location = new System.Drawing.Point(0, 0);
            this.userControlDataBaseLogin1.Name = "userControlDataBaseLogin1";
            this.userControlDataBaseLogin1.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.userControlDataBaseLogin1.Size = new System.Drawing.Size(341, 238);
            this.userControlDataBaseLogin1.TabIndex = 1;
            // 
            // FormDataBaseLogin
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(341, 238);
            this.Controls.Add(this.userControlDataBaseLogin1);
            this.LookAndFeel.SkinName = "Blue";
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormDataBaseLogin";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "数据库连接";
            this.Controls.SetChildIndex(this.userControlDataBaseLogin1, 0);
            this.Controls.SetChildIndex(this.sButOk, 0);
            this.ResumeLayout(false);

        }
    }
}

