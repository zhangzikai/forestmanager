namespace FormBase
{
    using DevExpress.LookAndFeel;
    using DevExpress.XtraEditors;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class FormBase3 : XtraForm
    {
        private IContainer components = null;
        private DefaultLookAndFeel defaultLookAndFeel1;

        public FormBase3()
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

        private void FormBase1_Load(object sender, EventArgs e)
        {
            this.defaultLookAndFeel1.LookAndFeel.SkinName = "Blue";
        }

        private void InitializeComponent()
        {
            this.components = new Container();
            ComponentResourceManager manager = new ComponentResourceManager(typeof(FormBase3));
            this.defaultLookAndFeel1 = new DefaultLookAndFeel(this.components);
            base.SuspendLayout();
            this.defaultLookAndFeel1.LookAndFeel.SkinName = "Blue";
            base.Appearance.BackColor = Color.FromArgb(0xe3, 0xf1, 0xfe);
            base.Appearance.Options.UseBackColor = true;
            base.AutoScaleDimensions = new SizeF(6f, 12f);
//            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x124, 0x10a);
//            base.Icon = (Icon) manager.GetObject("$this.Icon");
            base.LookAndFeel.SkinName = "Blue";
            base.Name = "FormBase3";
            this.Text = "FormBase3";
            base.ResumeLayout(false);
        }
    }
}

