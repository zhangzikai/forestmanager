namespace Report
{
    using DevExpress.XtraEditors;
    using FormBase;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Runtime.CompilerServices;
    using System.Threading;
    using System.Windows.Forms;

    internal class WaitDialog : FormBase2
    {
        private Thread _cancelThread;
        private CheckStopWaitDialog _checkStopFunction;
        private StaticMsg _msg;
        private IContainer components;
        private LabelControl labelControl_ReportInfo;
        private LabelControl labelControl_time;
        private LabelControl labelControl2;
        private LabelControl lblTimeTaken;
        private ProgressBarControl progressBarControl_report;
        private SimpleButton simpleButton_cancel;
        private DateTime Started;
        private System.Windows.Forms.Timer timer1;

        public WaitDialog(CheckStopWaitDialog checkStopFunction, Thread pCancelThread, StaticMsg pMsg)
        {
            this.InitializeComponent();
            this._checkStopFunction = checkStopFunction;
            this._cancelThread = pCancelThread;
            this.progressBarControl_report.Properties.Step = this.progressBarControl_report.Properties.Maximum / (pMsg.StaticReportCount + 1);
            this.Text = pMsg.Title;
            this.labelControl2.Text = pMsg.StartMessage;
            this._msg = pMsg;
            this.Started = DateTime.Now;
            this.timer1.Interval = 0x3e8;
            this.timer1_Tick(null, null);
            this.timer1.Start();
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
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.progressBarControl_report = new DevExpress.XtraEditors.ProgressBarControl();
            this.labelControl_time = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.lblTimeTaken = new DevExpress.XtraEditors.LabelControl();
            this.labelControl_ReportInfo = new DevExpress.XtraEditors.LabelControl();
            this.simpleButton_cancel = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.progressBarControl_report.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // progressBarControl_report
            // 
            this.progressBarControl_report.Location = new System.Drawing.Point(12, 12);
            this.progressBarControl_report.Name = "progressBarControl_report";
            this.progressBarControl_report.Size = new System.Drawing.Size(328, 18);
            this.progressBarControl_report.TabIndex = 0;
            // 
            // labelControl_time
            // 
            this.labelControl_time.Location = new System.Drawing.Point(12, 46);
            this.labelControl_time.Name = "labelControl_time";
            this.labelControl_time.Size = new System.Drawing.Size(60, 14);
            this.labelControl_time.TabIndex = 1;
            this.labelControl_time.Text = "已用时间：";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(13, 76);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(0, 14);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.TextChanged += new System.EventHandler(this.labelControl2_TextChanged);
            // 
            // lblTimeTaken
            // 
            this.lblTimeTaken.Location = new System.Drawing.Point(79, 46);
            this.lblTimeTaken.Name = "lblTimeTaken";
            this.lblTimeTaken.Size = new System.Drawing.Size(0, 14);
            this.lblTimeTaken.TabIndex = 3;
            // 
            // labelControl_ReportInfo
            // 
            this.labelControl_ReportInfo.Location = new System.Drawing.Point(79, 76);
            this.labelControl_ReportInfo.Name = "labelControl_ReportInfo";
            this.labelControl_ReportInfo.Size = new System.Drawing.Size(0, 14);
            this.labelControl_ReportInfo.TabIndex = 4;
            // 
            // simpleButton_cancel
            // 
            this.simpleButton_cancel.Location = new System.Drawing.Point(265, 108);
            this.simpleButton_cancel.Name = "simpleButton_cancel";
            this.simpleButton_cancel.Size = new System.Drawing.Size(75, 23);
            this.simpleButton_cancel.TabIndex = 5;
            this.simpleButton_cancel.Text = "取消";
            this.simpleButton_cancel.Click += new System.EventHandler(this.simpleButton_cancel_Click);
            // 
            // WaitDialog
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.Appearance.Options.UseBackColor = true;
            this.ClientSize = new System.Drawing.Size(352, 143);
            this.Controls.Add(this.simpleButton_cancel);
            this.Controls.Add(this.labelControl_ReportInfo);
            this.Controls.Add(this.lblTimeTaken);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl_time);
            this.Controls.Add(this.progressBarControl_report);
            this.LookAndFeel.SkinName = "Blue";
            this.Name = "WaitDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "";
            this.Controls.SetChildIndex(this.progressBarControl_report, 0);
            this.Controls.SetChildIndex(this.labelControl_time, 0);
            this.Controls.SetChildIndex(this.labelControl2, 0);
            this.Controls.SetChildIndex(this.lblTimeTaken, 0);
            this.Controls.SetChildIndex(this.labelControl_ReportInfo, 0);
            this.Controls.SetChildIndex(this.simpleButton_cancel, 0);
            this.Controls.SetChildIndex(this.sButOk, 0);
            ((System.ComponentModel.ISupportInitialize)(this.progressBarControl_report.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void labelControl2_TextChanged(object sender, EventArgs e)
        {
            this.progressBarControl_report.PerformStep();
        }

        private void simpleButton_cancel_Click(object sender, EventArgs e)
        {
            while (this._cancelThread.IsAlive)
            {
                this._cancelThread.Abort();
                this._msg.ThreadMsg = 1;
                this._msg.EndMessage = "报表统计已取消！";
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            TimeSpan span = (TimeSpan) (DateTime.Now - this.Started);
            this.lblTimeTaken.Text = string.Concat(new object[] { (((span.Days * 0x18) + span.Hours) * 60) + span.Minutes, " 分 ", span.Seconds, " 秒" });
            if (this._msg.Start)
            {
                this.labelControl2.Text = this._msg.TableInfo;
            }
            else
            {
                this.labelControl2.Text = this._msg.StartMessage;
            }
            if (this._checkStopFunction())
            {
                base.Close();
            }
            Application.DoEvents();
        }

        public delegate bool CheckStopWaitDialog();
    }
}

