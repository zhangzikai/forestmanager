namespace Desktop
{
    using DevExpress.XtraEditors;
    using FormBase;
    using GDB.SQLServerExpress.vTasks.Forest;
    using GDB.SQLServerExpress.vTasks.vControls;
    using Microsoft.SqlServer.Management.Common;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Utilities;

    public class FormDeleteForestDB : FormBase3
    {
        private ForestDBServerInfo _dbServerInfo;
        private ServerConnection _serverConnection;
        private bool _skip;
        private IContainer components;
        private DropDatabase dropDatabase1;
        private const string mClassName = "Desktop.FormRemoveForestDB";
        private ErrorOpt mErrOpt = UtilFactory.GetErrorOpt();
        private string mSubSysName = UtilFactory.GetConfigOpt().GetSystemName();
        private SimpleButton sb_OK;

        public FormDeleteForestDB()
        {
            this.InitializeComponent();
            this.dropDatabase1.SkipEvent += new DropDatabase.Skip(this.dropDatabase1_SkipEvent);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void dropDatabase1_SkipEvent()
        {
            this._skip = true;
            this._skip = false;
        }

        private void InitializeComponent()
        {
            this.dropDatabase1 = new DropDatabase();
            this.sb_OK = new SimpleButton();
            base.SuspendLayout();
            this.dropDatabase1.Dock = DockStyle.Top;
            this.dropDatabase1.Location = new Point(0, 0);
            this.dropDatabase1.Name = "dropDatabase1";
            this.dropDatabase1.Size = new Size(0x204, 0x5e);
            this.dropDatabase1.TabIndex = 0;
            this.sb_OK.Location = new Point(0x1ab, 0x67);
            this.sb_OK.Name = "sb_OK";
            this.sb_OK.Size = new Size(0x4b, 0x17);
            this.sb_OK.TabIndex = 0x29;
            this.sb_OK.Text = "确定";
            this.sb_OK.Click += new EventHandler(this.sb_OK_Click);
            base.Appearance.BackColor = Color.FromArgb(0xe3, 0xf1, 0xfe);
            base.Appearance.Options.UseBackColor = true;
            base.AutoScaleDimensions = new SizeF(7f, 14f);
           // base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x204, 0x90);
            base.Controls.Add(this.sb_OK);
            base.Controls.Add(this.dropDatabase1);
         //   base.FormBorderStyle = FormBorderStyle.FixedDialog;
            base.LookAndFeel.SkinName = "Blue";
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            base.Name = "FormDeleteForestDB";
            base.StartPosition = FormStartPosition.CenterParent;
            this.Text = "删除数据库";
            base.ResumeLayout(false);
        }

        public void InitialValue(ForestDBServerInfo dbServerInfo, string sCode)
        {
            try
            {
                this._dbServerInfo = dbServerInfo;
                string serverName = this._dbServerInfo.ServerName;
                this._serverConnection = new ServerConnection(serverName, this._dbServerInfo.UserName, this._dbServerInfo.UserPass);
                this._serverConnection.Connect();
                this.dropDatabase1.ServerConnection = this._serverConnection;
                this.dropDatabase1.LoadDatabases();
                this.dropDatabase1.LoadDatabasesEx();
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "Desktop.FormRemoveForestDB", "InitialValue", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void sb_OK_Click(object sender, EventArgs e)
        {
            this.dropDatabase1_SkipEvent();
            this.dropDatabase1.Run();
        }
    }
}

