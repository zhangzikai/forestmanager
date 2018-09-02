namespace Desktop
{
    using FormBase;
    using GDB.SQLServerExpress.vTasks.Forest;
    using GDB.SQLServerExpress.vTasks.vControls;
    using Microsoft.SqlServer.Management.Common;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Utilities;

    public class FormCreateForestDB : FormBase3
    {
        private ForestDBServerInfo _dbServerInfo;
        private ServerConnection _serverConnection;
        private IContainer components;
        public CreateForestDataBase createForestDataBase1;
        private const string mClassName = "Desktop.FormCreateForestDB";
        private ErrorOpt mErrOpt = UtilFactory.GetErrorOpt();
        private string mSubSysName = UtilFactory.GetConfigOpt().GetSystemName();

        public FormCreateForestDB()
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
            ComponentResourceManager manager = new ComponentResourceManager(typeof(FormCreateForestDB));
            this.createForestDataBase1 = new CreateForestDataBase();
            base.SuspendLayout();
            this.createForestDataBase1.Appearance.BackColor = Color.FromArgb(0xe3, 0xf1, 0xfe);
            this.createForestDataBase1.Appearance.BackColor2 = Color.FromArgb(0xe3, 0xf1, 0xfe);
            this.createForestDataBase1.Appearance.Options.UseBackColor = true;
            this.createForestDataBase1.Dock = DockStyle.Fill;
            this.createForestDataBase1.Location = new Point(0, 0);
            this.createForestDataBase1.Name = "createForestDataBase1";
            this.createForestDataBase1.Size = new Size(0x1b2, 0xec);
            this.createForestDataBase1.TabIndex = 0;
            base.Appearance.BackColor = Color.FromArgb(0xe3, 0xf1, 0xfe);
            base.Appearance.Options.UseBackColor = true;
            base.AutoScaleDimensions = new SizeF(7f, 14f);
        //    base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x1b2, 0xec);
            base.Controls.Add(this.createForestDataBase1);
        //    base.Icon = (Icon) manager.GetObject("$this.Icon");
            base.LookAndFeel.SkinName = "Blue";
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            base.Name = "FormCreateForestDB";
            base.StartPosition = FormStartPosition.CenterParent;
            this.Text = "创建新一年度数据库";
            base.ResumeLayout(false);
        }

        public void InitialValue(ForestDBServerInfo dbServerInfo, string sCode)
        {
            try
            {
                this._dbServerInfo = dbServerInfo;
                this.createForestDataBase1.Tag = this;
                this.createForestDataBase1.InitialValue(this._dbServerInfo, sCode);
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "Desktop.FormCreateForestDB", "InitialValue", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }
    }
}

