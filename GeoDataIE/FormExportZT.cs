namespace GeoDataIE
{
    using ESRI.ArcGIS.Controls;
    using FormBase;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class FormExportZT : FormBase3
    {
        private IContainer components;
        private IHookHelper m_hookHelper;
        private Panel panel1;
        private UserControlExportZT userControlExportZT1;

        public FormExportZT()
        {
            this.InitializeComponent();
            base.Load += new EventHandler(this.FormExportZT_Load);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void FormExportZT_Load(object sender, EventArgs e)
        {
            this.userControlExportZT1.Init(this.m_hookHelper.FocusMap);
        }

        private void InitializeComponent()
        {
            this.panel1 = new Panel();
            this.userControlExportZT1 = new UserControlExportZT();
            this.panel1.SuspendLayout();
            base.SuspendLayout();
            this.panel1.Controls.Add(this.userControlExportZT1);
            this.panel1.Dock = DockStyle.Fill;
            this.panel1.Location = new Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new Size(0x155, 0x14e);
            this.panel1.TabIndex = 0;
            this.userControlExportZT1.Appearance.BackColor = Color.FromArgb(0xe3, 0xf1, 0xfe);
            this.userControlExportZT1.Appearance.BackColor2 = Color.FromArgb(0xe3, 0xf1, 0xfe);
            this.userControlExportZT1.Appearance.Options.UseBackColor = true;
            this.userControlExportZT1.Dock = DockStyle.Fill;
            this.userControlExportZT1.Location = new Point(0, 0);
            this.userControlExportZT1.Name = "userControlExportZT1";
            this.userControlExportZT1.Size = new Size(0x155, 0x14e);
            this.userControlExportZT1.TabIndex = 0;
            base.Appearance.BackColor = Color.FromArgb(0xe3, 0xf1, 0xfe);
            base.Appearance.Options.UseBackColor = true;
            base.AutoScaleDimensions = new SizeF(7f, 14f);
//            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x155, 0x14e);
            base.Controls.Add(this.panel1);
            base.LookAndFeel.SkinName = "Blue";
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            base.Name = "FormExportZT";
            base.ShowInTaskbar = false;
            base.StartPosition = FormStartPosition.CenterParent;
            this.Text = "导出专题数据";
            this.panel1.ResumeLayout(false);
            base.ResumeLayout(false);
        }

        public object Hook
        {
            set
            {
                if (value != null)
                {
                    if (this.m_hookHelper == null)
                    {
                        this.m_hookHelper = new HookHelperClass();
                    }
                    this.m_hookHelper.Hook = value;
                }
            }
        }
    }
}

