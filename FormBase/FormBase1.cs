namespace FormBase
{
    using DevExpress.LookAndFeel;
    using DevExpress.XtraEditors;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class FormBase1 : XtraForm
    {
        private IContainer components = null;
        private DefaultLookAndFeel defaultLookAndFeel1;

        public FormBase1()
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

        private void FormBase1_Load(object sender, EventArgs e)
        {
            this.defaultLookAndFeel1.LookAndFeel.SkinName = "Money Twins";
        }

        private void InitializeComponent()
        {
            this.components = new Container();
            ComponentResourceManager manager = new ComponentResourceManager(typeof(FormBase1));
            this.defaultLookAndFeel1 = new DefaultLookAndFeel(this.components);
            base.SuspendLayout();
            this.defaultLookAndFeel1.LookAndFeel.SkinName = "Money Twins";
            base.Appearance.BackColor = Color.FromArgb(0xe3, 0xf1, 0xfe);
            base.Appearance.BackColor2 = Color.White;
            base.Appearance.Options.UseBackColor = true;
            base.AutoScaleDimensions = new SizeF(7f, 14f);
//            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x155, 310);
//            base.Icon = (Icon) manager.GetObject("$this.Icon");
            base.Name = "FormBase1";
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Base1";
            base.Load += new EventHandler(this.FormBase1_Load);
            base.ResumeLayout(false);
        }
    }
}

