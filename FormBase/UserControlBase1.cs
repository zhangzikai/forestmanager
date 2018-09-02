namespace FormBase
{
    using DevExpress.LookAndFeel;
    using DevExpress.XtraEditors;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class UserControlBase1 : XtraUserControl
    {
        private IContainer components = null;
        private DefaultLookAndFeel defaultLookAndFeel1;

        public UserControlBase1()
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

        public void InitializeComponent()
        {
            this.components = new Container();
            this.defaultLookAndFeel1 = new DefaultLookAndFeel(this.components);
            base.SuspendLayout();
            this.defaultLookAndFeel1.LookAndFeel.SkinName = "Blue";
            base.Appearance.BackColor = Color.FromArgb(0xe3, 0xf1, 0xfe);
            base.Appearance.BackColor2 = Color.FromArgb(0xe3, 0xf1, 0xfe);
            base.Appearance.Options.UseBackColor = true;
            base.AutoScaleDimensions = new SizeF(6f, 12f);
//            base.AutoScaleMode = AutoScaleMode.Font;
            base.Name = "UserControlBase1";
            base.ResumeLayout(false);
        }
    }
}

