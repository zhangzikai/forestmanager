namespace GDB.SQLServerExpress.vTasks.vForms
{
    using DevExpress.XtraEditors;
    using GDB.SQLServerExpress.vTasks.vControls;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class CleanDataFrm : XtraForm
    {
        private IContainer components;
        private ForestMDFCleanControl forestMDFCleanControl1;

        public CleanDataFrm()
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
            ComponentResourceManager resources = new ComponentResourceManager(typeof(CleanDataFrm));
            this.forestMDFCleanControl1 = new ForestMDFCleanControl();
            base.SuspendLayout();
            this.forestMDFCleanControl1.Dock = DockStyle.Fill;
            this.forestMDFCleanControl1.Location = new Point(0, 0);
            this.forestMDFCleanControl1.Name = "forestMDFCleanControl1";
            this.forestMDFCleanControl1.Size = new Size(0x21a, 0x18f);
            this.forestMDFCleanControl1.TabIndex = 0;
            base.AutoScaleDimensions = new SizeF(7f, 14f);
//            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x21a, 0x18f);
            base.Controls.Add(this.forestMDFCleanControl1);
//            base.FormBorderStyle = FormBorderStyle.FixedSingle;
            base.Icon = (Icon) resources.GetObject("$this.Icon");
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            base.Name = "CleanDataFrm";
            this.Text = "清除冗余数据";
            base.ResumeLayout(false);
        }
    }
}

