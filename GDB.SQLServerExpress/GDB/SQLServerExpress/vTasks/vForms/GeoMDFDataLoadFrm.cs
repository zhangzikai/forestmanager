namespace GDB.SQLServerExpress.vTasks.vForms
{
    using DevExpress.XtraEditors;
    using GDB.SQLServerExpress.vTasks.vControls;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class GeoMDFDataLoadFrm : XtraForm
    {
        private IContainer components;
        private ForestGeoDataLoadControl forestGeoDataLoadControl1;

        public GeoMDFDataLoadFrm()
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
            this.forestGeoDataLoadControl1 = new ForestGeoDataLoadControl();
            base.SuspendLayout();
            this.forestGeoDataLoadControl1.Dock = DockStyle.Fill;
            this.forestGeoDataLoadControl1.Location = new Point(0, 0);
            this.forestGeoDataLoadControl1.Name = "forestGeoDataLoadControl1";
            this.forestGeoDataLoadControl1.Size = new Size(0x223, 0x182);
            this.forestGeoDataLoadControl1.TabIndex = 0;
            base.AutoScaleDimensions = new SizeF(7f, 14f);
//            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x223, 0x182);
            base.Controls.Add(this.forestGeoDataLoadControl1);
//            base.FormBorderStyle = FormBorderStyle.FixedDialog;
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            base.Name = "GeoMDFDataLoadFrm";
            this.Text = "导入年度更新本底数据";
            base.ResumeLayout(false);
        }
    }
}

