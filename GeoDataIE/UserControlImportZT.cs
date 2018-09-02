namespace GeoDataIE
{
    using DevExpress.XtraEditors;
    using DevExpress.XtraEditors.Controls;
    using FormBase;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class UserControlImportZT : UserControlBase1
    {
        private ButtonEdit buttonEditPath;
        private IContainer components;
        private Panel panel1;
        private Panel panel2;

        public UserControlImportZT()
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
            this.buttonEditPath = new ButtonEdit();
            this.panel1 = new Panel();
            this.panel2 = new Panel();
            this.buttonEditPath.Properties.BeginInit();
            this.panel1.SuspendLayout();
            base.SuspendLayout();
            this.buttonEditPath.Location = new Point(0x2a, 14);
            this.buttonEditPath.Name = "buttonEditPath";
            this.buttonEditPath.Properties.Buttons.AddRange(new EditorButton[] { new EditorButton() });
            this.buttonEditPath.Size = new Size(0xb8, 0x15);
            this.buttonEditPath.TabIndex = 10;
            this.panel1.Controls.Add(this.buttonEditPath);
            this.panel1.Dock = DockStyle.Top;
            this.panel1.Location = new Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new Size(0x11f, 100);
            this.panel1.TabIndex = 11;
            this.panel2.Location = new Point(3, 0x6a);
            this.panel2.Name = "panel2";
            this.panel2.Size = new Size(0x119, 0x75);
            this.panel2.TabIndex = 12;
            base.Appearance.BackColor = Color.FromArgb(0xe3, 0xf1, 0xfe);
            base.Appearance.BackColor2 = Color.FromArgb(0xe3, 0xf1, 0xfe);
            base.Appearance.Options.UseBackColor = true;
            base.AutoScaleDimensions = new SizeF(7f, 14f);
//            base.AutoScaleMode = AutoScaleMode.Font;
            base.Controls.Add(this.panel2);
            base.Controls.Add(this.panel1);
            base.Name = "UserControlImportZT";
            base.Size = new Size(0x11f, 0x11f);
            this.buttonEditPath.Properties.EndInit();
            this.panel1.ResumeLayout(false);
            base.ResumeLayout(false);
        }
    }
}

