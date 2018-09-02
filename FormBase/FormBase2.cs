namespace FormBase
{
    using DevExpress.LookAndFeel;
    using DevExpress.XtraEditors;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class FormBase2 : XtraForm
    {
        private IContainer components = null;
        private DefaultLookAndFeel defaultLookAndFeel1;
        public SimpleButton sButOk;

        public FormBase2()
        {
            this.InitializeComponent();
            this.defaultLookAndFeel1.LookAndFeel.SkinName = "Blue";
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
            this.components = new System.ComponentModel.Container();
            this.defaultLookAndFeel1 = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            this.sButOk = new DevExpress.XtraEditors.SimpleButton();
            this.SuspendLayout();
            // 
            // defaultLookAndFeel1
            // 
            this.defaultLookAndFeel1.LookAndFeel.SkinName = "Money Twins";
            // 
            // sButOk
            // 
            this.sButOk.Location = new System.Drawing.Point(257, 268);
            this.sButOk.Name = "sButOk";
            this.sButOk.Size = new System.Drawing.Size(70, 28);
            this.sButOk.TabIndex = 0;
            this.sButOk.Text = "确定";
            this.sButOk.Visible = false;
            // 
            // FormBase2
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.Appearance.Options.UseBackColor = true;
            this.ClientSize = new System.Drawing.Size(341, 310);
            this.Controls.Add(this.sButOk);
            this.LookAndFeel.SkinName = "Blue";
            this.Name = "FormBase2";
            this.Text = "FormBase2";
            this.ResumeLayout(false);

        }
    }
}

