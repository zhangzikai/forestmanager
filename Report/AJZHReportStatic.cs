namespace Report
{
    using DevExpress.XtraEditors;
    using FormBase;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class AJZHReportStatic : FormBase3
    {
        private ReportParamter _rp;
        private IContainer components;
        private ReportList reportList1;
        private SimpleButton simpleButton_close;
        private SimpleButton simpleButton_ok;

        public AJZHReportStatic(ReportParamter pReportParamter)
        {
            this.InitializeComponent();
            this._rp = pReportParamter;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        public bool Init()
        {
            this.reportList1.InitReportList(this._rp.Theme, this._rp.SysType);
            if (ReportInit.Init(this._rp) == "0")
            {
                return false;
            }
            return true;
        }

        private void InitializeComponent()
        {
            this.simpleButton_ok = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton_close = new DevExpress.XtraEditors.SimpleButton();
            this.reportList1 = new Report.ReportList();
            this.SuspendLayout();
            // 
            // simpleButton_ok
            // 
            this.simpleButton_ok.Location = new System.Drawing.Point(92, 309);
            this.simpleButton_ok.Name = "simpleButton_ok";
            this.simpleButton_ok.Size = new System.Drawing.Size(75, 23);
            this.simpleButton_ok.TabIndex = 2;
            this.simpleButton_ok.Text = "统计";
            this.simpleButton_ok.Click += new System.EventHandler(this.simpleButton_ok_Click);
            // 
            // simpleButton_close
            // 
            this.simpleButton_close.Location = new System.Drawing.Point(173, 309);
            this.simpleButton_close.Name = "simpleButton_close";
            this.simpleButton_close.Size = new System.Drawing.Size(75, 23);
            this.simpleButton_close.TabIndex = 3;
            this.simpleButton_close.Text = "关闭";
            this.simpleButton_close.Click += new System.EventHandler(this.simpleButton_close_Click);
            // 
            // reportList1
            // 
            this.reportList1.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.reportList1.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.reportList1.Appearance.Options.UseBackColor = true;
            this.reportList1.Location = new System.Drawing.Point(14, 6);
            this.reportList1.Name = "reportList1";
            this.reportList1.Size = new System.Drawing.Size(313, 296);
            this.reportList1.TabIndex = 4;
            // 
            // AJZHReportStatic
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.Appearance.Options.UseBackColor = true;
            this.ClientSize = new System.Drawing.Size(341, 343);
            this.Controls.Add(this.reportList1);
            this.Controls.Add(this.simpleButton_close);
            this.Controls.Add(this.simpleButton_ok);
            this.LookAndFeel.SkinName = "Blue";
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AJZHReportStatic";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "报表统计";
            this.ResumeLayout(false);

        }

        private void simpleButton_close_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        private void simpleButton_ok_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog;
            string path = "";
            try
            {
                dialog = new SaveFileDialog();
                dialog.Title = "自然灾害统计表";
                dialog.DefaultExt = ".xls";
                dialog.Filter = "Excel电子表(*.xls)|*.xls";
                dialog.FileName = path;
                if (dialog.ShowDialog() != DialogResult.OK)
                {
                    return;
                }
                path = dialog.FileName;

                ReportViewer viewer = new ReportViewer(this._rp.Theme);
                List<string> selectedReportID = this.reportList1.GetSelectedReportID();
                this._rp.IDs = selectedReportID;
                this._rp.Names = this.reportList1.GetSelectedReportName();
                StaticMsg msg = new StaticMsg {
                    StartMessage = "正在统计：报表初始化...",
                    Title = "报表统计",
                    ExceptionMessage = "报表统计出现异常！",
                    EndMessage = "报表统计运行完毕！",
                    Verb = "正在统计：",
                    StaticReportCount = selectedReportID.Count
                };
                this._rp.StatisticsMsg = msg;
                if (selectedReportID.Count == 0)
                {
                    XtraMessageBox.Show("请选择要统计的报表！");
                }
                else
                {
                    viewer.Static(this._rp ,path);
                }
            }
            catch (Exception)
            {
            }
        }
    }
}

