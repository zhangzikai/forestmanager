namespace FormBase
{
    using DevExpress.LookAndFeel;
    using DevExpress.XtraEditors;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Windows.Forms;

    public class UserControlBase2 : XtraUserControl
    {
        private IContainer components = null;
        private DefaultLookAndFeel defaultLookAndFeel1;

        public UserControlBase2()
        {
            this.InitializeComponent();
            this.defaultLookAndFeel1.LookAndFeel.SkinName = "Money Twins";
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
            this.defaultLookAndFeel1 = new DefaultLookAndFeel(this.components);
            base.SuspendLayout();
            this.defaultLookAndFeel1.LookAndFeel.SkinName = "Money Twins";
            base.Appearance.BackColor = Color.FromArgb(0xb0, 0xcf, 0xf7);
            base.Appearance.BackColor2 = Color.White;
            base.Appearance.BorderColor = Color.FromArgb(0x80, 0x80, 0xff);
            base.Appearance.GradientMode = LinearGradientMode.Vertical;
            base.Appearance.Options.UseBackColor = true;
            base.Appearance.Options.UseBorderColor = true;
            base.AutoScaleDimensions = new SizeF(7f, 14f);
//            base.AutoScaleMode = AutoScaleMode.Font;
            this.LookAndFeel.SkinName = "Money Twins";
            base.Name = "UserControlBase2";
            base.Size = new Size(0xaf, 0x110);
            base.ResumeLayout(false);
        }
    }
}

