namespace QueryCommon
{
    using FormBase;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class FormTest : FormBase2
    {
        private IContainer components;
        private UserControlDistCode userControlDistCode1;

        public FormTest(object hook)
        {
            this.InitializeComponent();
            this.userControlDistCode1.InitialControls(hook);
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
            this.userControlDistCode1 = new QueryCommon.UserControlDistCode();
            this.SuspendLayout();
            // 
            // userControlDistCode1
            // 
            this.userControlDistCode1.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.userControlDistCode1.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.userControlDistCode1.Appearance.Options.UseBackColor = true;
            this.userControlDistCode1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControlDistCode1.Location = new System.Drawing.Point(0, 0);
            this.userControlDistCode1.MaximumSize = new System.Drawing.Size(408, 177);
            this.userControlDistCode1.Name = "userControlDistCode1";
            this.userControlDistCode1.Size = new System.Drawing.Size(331, 177);
            this.userControlDistCode1.TabIndex = 0;
            // 
            // FormTest
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(331, 306);
            this.Controls.Add(this.userControlDistCode1);
            this.LookAndFeel.SkinName = "Blue";
            this.Name = "FormTest";
            this.Text = "FormTest";
            this.Controls.SetChildIndex(this.userControlDistCode1, 0);
            this.Controls.SetChildIndex(this.sButOk, 0);
            this.ResumeLayout(false);

        }
    }
}

