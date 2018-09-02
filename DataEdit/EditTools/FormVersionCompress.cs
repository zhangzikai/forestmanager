namespace DataEdit.EditTools
{
    using DevExpress.XtraEditors;
    using ESRI.ArcGIS.Geodatabase;
    using FormBase;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class FormVersionCompress : FormBase2
    {
        private IContainer components = null;
        private Label label1;
        private ListBoxControl listBoxControl1;
        private Panel panel1;
        private SimpleButton simpleButtonClose;
        private SimpleButton simpleButtonCompress;

        public FormVersionCompress()
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
            this.listBoxControl1 = new ListBoxControl();
            this.label1 = new Label();
            this.panel1 = new Panel();
            this.simpleButtonCompress = new SimpleButton();
            this.simpleButtonClose = new SimpleButton();
            ((ISupportInitialize) this.listBoxControl1).BeginInit();
            this.panel1.SuspendLayout();
            base.SuspendLayout();
            base.sButOk.Click += new EventHandler(this.sButOk_Click);
            this.listBoxControl1.Dock = DockStyle.Top;
            this.listBoxControl1.Location = new Point(6, 0x21);
            this.listBoxControl1.Name = "listBoxControl1";
            this.listBoxControl1.Size = new Size(0x13f, 0x7e);
            this.listBoxControl1.TabIndex = 1;
            this.label1.Dock = DockStyle.Top;
            this.label1.Location = new Point(6, 6);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0x13f, 0x1b);
            this.label1.TabIndex = 2;
            this.label1.Text = "版本列表";
            this.label1.TextAlign = ContentAlignment.MiddleLeft;
            this.panel1.Controls.Add(this.simpleButtonClose);
            this.panel1.Controls.Add(this.simpleButtonCompress);
            this.panel1.Dock = DockStyle.Bottom;
            this.panel1.Location = new Point(6, 270);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new Padding(0, 6, 0, 0);
            this.panel1.Size = new Size(0x13f, 30);
            this.panel1.TabIndex = 3;
            this.simpleButtonCompress.Dock = DockStyle.Right;
            this.simpleButtonCompress.Location = new Point(0xf9, 6);
            this.simpleButtonCompress.Name = "simpleButtonCompress";
            this.simpleButtonCompress.Size = new Size(70, 0x18);
            this.simpleButtonCompress.TabIndex = 0;
            this.simpleButtonCompress.Text = "压缩";
            this.simpleButtonClose.Dock = DockStyle.Right;
            this.simpleButtonClose.Location = new Point(0xb3, 6);
            this.simpleButtonClose.Name = "simpleButtonClose";
            this.simpleButtonClose.Size = new Size(70, 0x18);
            this.simpleButtonClose.TabIndex = 1;
            this.simpleButtonClose.Text = "关闭";
            base.Appearance.BackColor = Color.FromArgb(0xe3, 0xf1, 0xfe);
            base.Appearance.Options.UseBackColor = true;
            base.AutoScaleDimensions = new SizeF(7f, 14f);
 //            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x14b, 0x132);
            base.Controls.Add(this.panel1);
            base.Controls.Add(this.listBoxControl1);
            base.Controls.Add(this.label1);
            base.LookAndFeel.SkinName = "Blue";
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            base.Name = "FormVersionCompress";
            base.Padding = new Padding(6);
            this.Text = "数据库版本压缩";
            base.Controls.SetChildIndex(this.label1, 0);
            base.Controls.SetChildIndex(base.sButOk, 0);
            base.Controls.SetChildIndex(this.listBoxControl1, 0);
            base.Controls.SetChildIndex(this.panel1, 0);
            ((ISupportInitialize) this.listBoxControl1).EndInit();
            this.panel1.ResumeLayout(false);
            base.ResumeLayout(false);
        }

        private void sButOk_Click(object sender, EventArgs e)
        {
        }

        public void VersionedWorkspace(IWorkspace workspace)
        {
            if (workspace.Type == esriWorkspaceType.esriRemoteDatabaseWorkspace)
            {
                IVersionedWorkspace workspace2 = (IVersionedWorkspace) workspace;
                IEnumVersionInfo versions = workspace2.Versions;
                versions.Reset();
                for (IVersionInfo info2 = versions.Next(); info2 != null; info2 = versions.Next())
                {
                    MessageBox.Show(" Version Name: " + info2.VersionName);
                }
                IVersion version = workspace2.FindVersion("ADO.Default");
                IVersion defaultVersion = workspace2.DefaultVersion;
                workspace2.Compress();
            }
        }
    }
}

