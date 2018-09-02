namespace TJ_DLL
{
    using DevExpress.XtraEditors;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class frmWaiting : XtraForm
    {
        private IContainer components;
        private LabelControl labelControl1;
        private MarqueeProgressBarControl marqueeProgressBarControl1;

        public frmWaiting(BackgroundWorker backgroundWorker)
        {
            this.InitializeComponent();
            BackgroundWorker worker = backgroundWorker;
            worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.pBackgroundWorker_RunWorkerCompleted);
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
            this.marqueeProgressBarControl1 = new MarqueeProgressBarControl();
            this.labelControl1 = new LabelControl();
            this.marqueeProgressBarControl1.Properties.BeginInit();
            base.SuspendLayout();
            this.marqueeProgressBarControl1.EditValue = 0;
            this.marqueeProgressBarControl1.Location = new Point(0x58, 0x45);
            this.marqueeProgressBarControl1.Name = "marqueeProgressBarControl1";
            this.marqueeProgressBarControl1.Size = new Size(100, 0x12);
            this.marqueeProgressBarControl1.TabIndex = 0;
            this.labelControl1.Appearance.Font = new Font("宋体", 9f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.labelControl1.Location = new Point(50, 0x24);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new Size(0xc0, 12);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "统计表数据正在初始化，请稍侯……";
            base.AutoScaleDimensions = new SizeF(7f, 14f);
//            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(280, 0x7a);
            base.Controls.Add(this.labelControl1);
            base.Controls.Add(this.marqueeProgressBarControl1);
//            base.FormBorderStyle = FormBorderStyle.None;
            base.Name = "frmWaiting";
            base.StartPosition = FormStartPosition.CenterScreen;
            this.marqueeProgressBarControl1.Properties.EndInit();
            base.ResumeLayout(false);
            base.PerformLayout();
        }

        private void pBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            base.Close();
        }
    }
}

