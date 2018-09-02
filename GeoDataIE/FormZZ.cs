namespace GeoDataIE
{
    using FormBase;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class FormZZ : FormBase2
    {
        private IContainer components;
        private bool m_bCurrentTask;
        private object m_Hook;
        private string m_Type;
        private UserControlExportHarvest userControlExportHarvest1;
        private UserControlImportHarvest userControlImportHarvest1;

        public FormZZ()
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

        private void FormHarvest_Load(object sender, EventArgs e)
        {
            this.userControlImportHarvest1.Hook = this.m_Hook;
            if (this.m_Type.ToLower() == "export")
            {
                this.Text = "导出征占用项目";
                this.userControlExportHarvest1.Init(this.m_bCurrentTask);
                this.userControlExportHarvest1.Visible = true;
                this.userControlImportHarvest1.Visible = false;
            }
            else if (this.m_Type.ToLower() == "import")
            {
                this.Text = "导入征占用项目";
                this.userControlImportHarvest1.Init();
                this.userControlExportHarvest1.Visible = false;
                this.userControlImportHarvest1.Visible = true;
            }
            else
            {
                this.Text = "";
                this.userControlExportHarvest1.Visible = false;
                this.userControlImportHarvest1.Visible = false;
            }
        }

        public void Init(object hook, string sType)
        {
            this.m_Hook = hook;
            this.m_Type = sType;
        }

        public void Init(object hook, string sType, bool bCurrentTask)
        {
            this.m_Hook = hook;
            this.m_Type = sType;
            this.m_bCurrentTask = bCurrentTask;
        }

        private void InitializeComponent()
        {
            this.userControlExportHarvest1 = new UserControlExportHarvest();
            this.userControlImportHarvest1 = new UserControlImportHarvest();
            base.SuspendLayout();
            this.userControlExportHarvest1.Appearance.BackColor = Color.FromArgb(0xe3, 0xf1, 0xfe);
            this.userControlExportHarvest1.Appearance.BackColor2 = Color.FromArgb(0xe3, 0xf1, 0xfe);
            this.userControlExportHarvest1.Appearance.Options.UseBackColor = true;
            this.userControlExportHarvest1.Dock = DockStyle.Fill;
            this.userControlExportHarvest1.Location = new Point(0, 0);
            this.userControlExportHarvest1.Name = "userControlExportHarvest1";
            this.userControlExportHarvest1.Padding = new Padding(5, 2, 5, 0);
            this.userControlExportHarvest1.Size = new Size(0x194, 0x144);
            this.userControlExportHarvest1.TabIndex = 0;
            this.userControlImportHarvest1.Appearance.BackColor = Color.FromArgb(0xe3, 0xf1, 0xfe);
            this.userControlImportHarvest1.Appearance.BackColor2 = Color.FromArgb(0xe3, 0xf1, 0xfe);
            this.userControlImportHarvest1.Appearance.Options.UseBackColor = true;
            this.userControlImportHarvest1.Dock = DockStyle.Fill;
            this.userControlImportHarvest1.Location = new Point(0, 0);
            this.userControlImportHarvest1.Name = "userControlImportHarvest1";
            this.userControlImportHarvest1.Padding = new Padding(5, 2, 5, 0);
            this.userControlImportHarvest1.Size = new Size(0x194, 0x144);
            this.userControlImportHarvest1.TabIndex = 1;
            base.Appearance.BackColor = Color.FromArgb(0xe3, 0xf1, 0xfe);
            base.Appearance.Options.UseBackColor = true;
            base.AutoScaleDimensions = new SizeF(7f, 14f);
//            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x194, 0x144);
            base.Controls.Add(this.userControlImportHarvest1);
            base.Controls.Add(this.userControlExportHarvest1);
            base.LookAndFeel.SkinName = "Blue";
            base.MinimizeBox = false;
            base.Name = "FormZZ";
            base.StartPosition = FormStartPosition.CenterParent;
            this.Text = "";
            base.Load += new EventHandler(this.FormHarvest_Load);
            base.Controls.SetChildIndex(this.userControlExportHarvest1, 0);
            base.Controls.SetChildIndex(this.userControlImportHarvest1, 0);
            base.Controls.SetChildIndex(base.sButOk, 0);
            base.ResumeLayout(false);
        }
    }
}

