namespace GDB.SQLServerExpress.vTasks.vForms
{
    using DevExpress.XtraEditors;
    using ESRI.ArcGIS.Geodatabase;
    using FormBase;
    using GDB.SQLServerExpress.vTasks.vControls;
    using Microsoft.SqlServer.Management.Smo;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class DataMatchForm : FormBase3
    {
        private SimpleButton bt_cancel;
        private SimpleButton bt_ok;
        private IContainer components;
        private DataMatch dataMatch1;

        public DataMatchForm(IWorkspace pSourceWs, string pSourcePath, string pTarPath, Database pDb)
        {
            this.InitializeComponent();
            this.dataMatch1.Init(pSourceWs, pSourcePath, pTarPath, pDb);
        }

        private void bt_cancel_Click(object sender, EventArgs e)
        {
            base.DialogResult = DialogResult.Cancel;
        }

        private void bt_ok_Click(object sender, EventArgs e)
        {
            base.DialogResult = DialogResult.OK;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        public Dictionary<DataSetInfo, DataSetInfo> GetMatch()
        {
            return this.dataMatch1.GetMatch();
        }

        private void InitializeComponent()
        {
            this.bt_ok = new SimpleButton();
            this.bt_cancel = new SimpleButton();
            this.dataMatch1 = new DataMatch();
            base.SuspendLayout();
            this.bt_ok.Location = new Point(0xc0, 0x171);
            this.bt_ok.Name = "bt_ok";
            this.bt_ok.Size = new Size(0x4b, 0x17);
            this.bt_ok.TabIndex = 1;
            this.bt_ok.Text = "确定";
            this.bt_ok.Click += new EventHandler(this.bt_ok_Click);
            this.bt_cancel.Location = new Point(0x111, 0x171);
            this.bt_cancel.Name = "bt_cancel";
            this.bt_cancel.Size = new Size(0x4b, 0x17);
            this.bt_cancel.TabIndex = 2;
            this.bt_cancel.Text = "取消";
            this.bt_cancel.Click += new EventHandler(this.bt_cancel_Click);
            this.dataMatch1.Dock = DockStyle.Top;
            this.dataMatch1.Location = new Point(0, 0);
            this.dataMatch1.Name = "dataMatch1";
            this.dataMatch1.Size = new Size(0x21d, 360);
            this.dataMatch1.TabIndex = 0;
            base.Appearance.BackColor = Color.FromArgb(0xe3, 0xf1, 0xfe);
            base.Appearance.Options.UseBackColor = true;
            base.AutoScaleDimensions = new SizeF(7f, 14f);
//            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x21d, 0x195);
            base.Controls.Add(this.bt_cancel);
            base.Controls.Add(this.bt_ok);
            base.Controls.Add(this.dataMatch1);
//            base.FormBorderStyle = FormBorderStyle.FixedSingle;
            base.LookAndFeel.SkinName = "Blue";
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            base.Name = "DataMatchForm";
            base.ShowInTaskbar = false;
            base.StartPosition = FormStartPosition.CenterParent;
            this.Text = "表匹配";
            base.ResumeLayout(false);
        }
    }
}

