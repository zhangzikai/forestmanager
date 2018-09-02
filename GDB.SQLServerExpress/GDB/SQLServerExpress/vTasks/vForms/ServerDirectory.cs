namespace GDB.SQLServerExpress.vTasks.vForms
{
    using DevExpress.XtraEditors;
    using FormBase;
    using GDB.SQLServerExpress.vTasks.vControls;
    using Microsoft.SqlServer.Management.Common;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Windows.Forms;

    public class ServerDirectory : FormBase3
    {
        private string _path;
        private IContainer components;
        private FileGeodatabase fileGeodatabase1;
        private SimpleButton sb_cancel;
        private SimpleButton sb_ok;

        public ServerDirectory()
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

        public void Init(ServerConnection pServerConnection, bool pLocal, bool pLoadFile)
        {
            this.fileGeodatabase1.IsLocal = pLocal;
            this.fileGeodatabase1.LoadFile = pLoadFile;
            if (!pLocal)
            {
                this.fileGeodatabase1.LoadServerDriver(pServerConnection);
            }
            else
            {
                this.fileGeodatabase1.LoadDriver();
            }
        }

        private void InitializeComponent()
        {
            this.fileGeodatabase1 = new FileGeodatabase();
            this.sb_ok = new SimpleButton();
            this.sb_cancel = new SimpleButton();
            base.SuspendLayout();
            this.fileGeodatabase1.Appearance.BackColor = Color.FromArgb(0xb0, 0xcf, 0xf7);
            this.fileGeodatabase1.Appearance.BackColor2 = Color.White;
            this.fileGeodatabase1.Appearance.BorderColor = Color.FromArgb(0x80, 0x80, 0xff);
            this.fileGeodatabase1.Appearance.GradientMode = LinearGradientMode.Vertical;
            this.fileGeodatabase1.Appearance.Options.UseBackColor = true;
            this.fileGeodatabase1.Appearance.Options.UseBorderColor = true;
            this.fileGeodatabase1.Dock = DockStyle.Top;
            this.fileGeodatabase1.Location = new Point(0, 0);
            this.fileGeodatabase1.LookAndFeel.SkinName = "Money Twins";
            this.fileGeodatabase1.Name = "fileGeodatabase1";
            this.fileGeodatabase1.Size = new Size(0x11c, 0x14d);
            this.fileGeodatabase1.TabIndex = 0;
            this.sb_ok.Location = new Point(0x40, 0x153);
            this.sb_ok.Name = "sb_ok";
            this.sb_ok.Size = new Size(0x4b, 0x17);
            this.sb_ok.TabIndex = 1;
            this.sb_ok.Text = "确定";
            this.sb_ok.Click += new EventHandler(this.sb_ok_Click);
            this.sb_cancel.Location = new Point(0x92, 0x153);
            this.sb_cancel.Name = "sb_cancel";
            this.sb_cancel.Size = new Size(0x4b, 0x17);
            this.sb_cancel.TabIndex = 2;
            this.sb_cancel.Text = "取消";
            this.sb_cancel.Click += new EventHandler(this.sb_cancel_Click);
            base.Appearance.BackColor = Color.FromArgb(0xe3, 0xf1, 0xfe);
            base.Appearance.Options.UseBackColor = true;
            base.AutoScaleDimensions = new SizeF(7f, 14f);
//            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x11c, 370);
            base.Controls.Add(this.sb_cancel);
            base.Controls.Add(this.sb_ok);
            base.Controls.Add(this.fileGeodatabase1);
       //     base.FormBorderStyle = FormBorderStyle.FixedSingle;
            base.LookAndFeel.SkinName = "Blue";
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            base.Name = "ServerDirectory";
            base.StartPosition = FormStartPosition.CenterParent;
            this.Text = "服务器目录";
            base.ResumeLayout(false);
        }

        private void sb_cancel_Click(object sender, EventArgs e)
        {
            base.DialogResult = DialogResult.Cancel;
        }

        private void sb_ok_Click(object sender, EventArgs e)
        {
            this._path = this.fileGeodatabase1.GetPath();
            base.DialogResult = DialogResult.OK;
        }

        public string Path
        {
            get
            {
                return this._path;
            }
        }
    }
}

