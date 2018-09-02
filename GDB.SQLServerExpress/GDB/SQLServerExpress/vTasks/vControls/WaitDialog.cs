namespace GDB.SQLServerExpress.vTasks.vControls
{
    using DevExpress.XtraEditors;
    using FormBase;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    internal class WaitDialog : FormBase2
    {
        private IContainer components;
        private LabelControl labelControl_ReportInfo;
        private LabelControl labelControl2;
        private ProgressBarControl progressBarControl_report;

        public WaitDialog()
        {
            this.InitializeComponent();
            this.progressBarControl_report.Position = this.progressBarControl_report.Properties.Maximum / 10;
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
            this.progressBarControl_report = new ProgressBarControl();
            this.labelControl2 = new LabelControl();
            this.labelControl_ReportInfo = new LabelControl();
            this.progressBarControl_report.Properties.BeginInit();
            base.SuspendLayout();
            this.progressBarControl_report.Location = new Point(12, 12);
            this.progressBarControl_report.Name = "progressBarControl_report";
            this.progressBarControl_report.Size = new Size(0x148, 0x12);
            this.progressBarControl_report.TabIndex = 0;
            this.labelControl2.Location = new Point(0x12, 0x30);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new Size(0, 14);
            this.labelControl2.TabIndex = 2;
            this.labelControl_ReportInfo.Location = new Point(0x54, 0x30);
            this.labelControl_ReportInfo.Name = "labelControl_ReportInfo";
            this.labelControl_ReportInfo.Size = new Size(0, 14);
            this.labelControl_ReportInfo.TabIndex = 4;
            base.Appearance.BackColor = Color.FromArgb(0xe3, 0xf1, 0xfe);
            base.Appearance.Options.UseBackColor = true;
            base.AutoScaleDimensions = new SizeF(7f, 14f);
//            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x160, 0x45);
            base.ControlBox = false;
            base.Controls.Add(this.labelControl_ReportInfo);
            base.Controls.Add(this.progressBarControl_report);
            base.Controls.Add(this.labelControl2);
//            base.FormBorderStyle = FormBorderStyle.FixedDialog;
            base.LookAndFeel.SkinName = "Blue";
            base.Name = "WaitDialog";
            base.ShowInTaskbar = false;
            base.StartPosition = FormStartPosition.Manual;
            this.Text = "";
            base.TopMost = true;
            base.Load += new EventHandler(this.WaitDialog_Load);
            base.Controls.SetChildIndex(this.labelControl2, 0);
            base.Controls.SetChildIndex(this.progressBarControl_report, 0);
            base.Controls.SetChildIndex(this.labelControl_ReportInfo, 0);
            base.Controls.SetChildIndex(base.sButOk, 0);
            this.progressBarControl_report.Properties.EndInit();
            base.ResumeLayout(false);
            base.PerformLayout();
        }

        public void SetProgress(string pMsg)
        {
            this.labelControl2.Text = pMsg;
            int num = this.progressBarControl_report.Properties.Maximum - this.progressBarControl_report.Position;
            this.progressBarControl_report.Position += num / 5;
            Application.DoEvents();
        }

        private void WaitDialog_Load(object sender, EventArgs e)
        {
            base.Left = base.Owner.Left + ((base.Owner.ClientSize.Width - base.Width) / 2);
            base.Top = base.Owner.Top + ((base.Owner.ClientSize.Height - base.Height) / 2);
        }
    }
}

