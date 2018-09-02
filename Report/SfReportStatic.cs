namespace Report
{
    using DevExpress.Utils;
    using DevExpress.XtraEditors;
    using DevExpress.XtraEditors.Controls;
    using FormBase;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class SfReportStatic : FormBase3
    {
        private ReportParamter _rp;
        private StatisticsTheme _theme = StatisticsTheme.SF;
        private string _year;
        private IContainer components;
        private DateEditEx dateEditEx1;
        private GroupControl groupControlDist;
        private ReportList reportList1;
        private SimpleButton simpleButton_close;
        private SimpleButton simpleButton_ok;

        public SfReportStatic(ReportParamter pRp)
        {
            this.InitializeComponent();
            this._rp = pRp;
        }

        private void dateEditEx1_EditValueChanged(object sender, EventArgs e)
        {
            string str = this.dateEditEx1.EditValue.ToString();
            if (!str.Contains(this._year))
            {
                DateTime dt = new DateTime(Convert.ToInt32(_year), dateEditEx1.DateTime.Month, dateEditEx1.DateTime.Day);
                dateEditEx1.EditValue = dt;
            
            }
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
            this.reportList1.InitReportList(this._theme, this._rp.SysType);
            this._rp.Theme = this._theme;
            this._year = ReportInit.Init(this._rp);
            if (this._year == "0")
            {
                return false;
            }
            return true;
        }

        private void InitializeComponent()
        {
            this.simpleButton_ok = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton_close = new DevExpress.XtraEditors.SimpleButton();
            this.groupControlDist = new DevExpress.XtraEditors.GroupControl();
            this.dateEditEx1 = new DateEditEx();
            this.reportList1 = new ReportList();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlDist)).BeginInit();
            this.groupControlDist.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditEx1.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditEx1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // simpleButton_ok
            // 
            this.simpleButton_ok.Location = new System.Drawing.Point(83, 365);
            this.simpleButton_ok.Name = "simpleButton_ok";
            this.simpleButton_ok.Size = new System.Drawing.Size(75, 23);
            this.simpleButton_ok.TabIndex = 2;
            this.simpleButton_ok.Text = "统计";
            this.simpleButton_ok.Click += new System.EventHandler(this.simpleButton_ok_Click);
            // 
            // simpleButton_close
            // 
            this.simpleButton_close.Location = new System.Drawing.Point(179, 365);
            this.simpleButton_close.Name = "simpleButton_close";
            this.simpleButton_close.Size = new System.Drawing.Size(75, 23);
            this.simpleButton_close.TabIndex = 3;
            this.simpleButton_close.Text = "关闭";
            this.simpleButton_close.Click += new System.EventHandler(this.simpleButton_close_Click);
            // 
            // groupControlDist
            // 
            this.groupControlDist.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.groupControlDist.Appearance.Options.UseBackColor = true;
            this.groupControlDist.Controls.Add(this.dateEditEx1);
            this.groupControlDist.Location = new System.Drawing.Point(12, 12);
            this.groupControlDist.Name = "groupControlDist";
            this.groupControlDist.Padding = new System.Windows.Forms.Padding(6, 2, 8, 8);
            this.groupControlDist.Size = new System.Drawing.Size(313, 55);
            this.groupControlDist.TabIndex = 18;
            this.groupControlDist.Text = "每月报表月份选择";
            // 
            // dateEditEx1
            // 
            this.dateEditEx1.DateMode = DateEditEx.DateResultModeEnum.FirstDayOfMonth;
            this.dateEditEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dateEditEx1.EditValue = null;
            this.dateEditEx1.Location = new System.Drawing.Point(8, 24);
            this.dateEditEx1.Name = "dateEditEx1";
            this.dateEditEx1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditEx1.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateEditEx1.Properties.CalendarView = DevExpress.XtraEditors.Repository.CalendarView.Vista;
            this.dateEditEx1.Properties.DisplayFormat.FormatString = "yyyy-MM";
            this.dateEditEx1.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateEditEx1.Properties.Mask.EditMask = "yyyy-MM";
            this.dateEditEx1.Properties.ShowToday = false;
            this.dateEditEx1.Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.True;
            this.dateEditEx1.Size = new System.Drawing.Size(295, 20);
            this.dateEditEx1.TabIndex = 0;
            this.dateEditEx1.EditValueChanged += new System.EventHandler(this.dateEditEx1_EditValueChanged);
            // 
            // reportList1
            // 
            this.reportList1.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.reportList1.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.reportList1.Appearance.Options.UseBackColor = true;
            this.reportList1.Location = new System.Drawing.Point(12, 73);
            this.reportList1.Name = "reportList1";
            this.reportList1.Size = new System.Drawing.Size(313, 286);
            this.reportList1.TabIndex = 19;
            // 
            // SfReportStatic
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.Appearance.Options.UseBackColor = true;
            this.ClientSize = new System.Drawing.Size(337, 396);
            this.Controls.Add(this.reportList1);
            this.Controls.Add(this.groupControlDist);
            this.Controls.Add(this.simpleButton_close);
            this.Controls.Add(this.simpleButton_ok);
            this.LookAndFeel.SkinName = "Blue";
            this.Name = "SfReportStatic";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "报表统计";
            ((System.ComponentModel.ISupportInitialize)(this.groupControlDist)).EndInit();
            this.groupControlDist.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dateEditEx1.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditEx1.Properties)).EndInit();
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
                dialog.Title = "火灾统计表";
                dialog.DefaultExt = ".xls";
                dialog.Filter = "Excel电子表(*.xls)|*.xls";
                dialog.FileName = path;
                if (dialog.ShowDialog() != DialogResult.OK)
                {
                    return;
                }
                path = dialog.FileName;

                ReportViewer viewer = new ReportViewer(this._theme);
                ReportParamter pParameter = new ReportParamter();
                if (this.dateEditEx1.EditValue == null)
                {
                    pParameter.YueFen = "12";
                    pParameter.Year = "2016";
                }
                else
                {
                    pParameter.YueFen = this.dateEditEx1.DateTime.Month.ToString();
                    pParameter.Year = this.dateEditEx1.DateTime.Year.ToString();
                }
                pParameter.Theme = this._theme;
                pParameter.FindFromTable = _rp.FindFromTable;
                List<string> selectedReportID = this.reportList1.GetSelectedReportID();
                pParameter.IDs = selectedReportID;
                pParameter.Names = this.reportList1.GetSelectedReportName();
                StaticMsg msg = new StaticMsg {
                    StartMessage = "正在统计：报表初始化...",
                    Title = "报表统计",
                    ExceptionMessage = "报表统计出现异常！",
                    EndMessage = "报表统计运行完毕！",
                    TableInfo = "正在统计：",
                    StaticReportCount = selectedReportID.Count
                };
                pParameter.StatisticsMsg = msg;
                if (selectedReportID.Count == 0)
                {
                    XtraMessageBox.Show("请选择要统计的报表！");
                }
                else
                {
                    viewer.Static(pParameter,path);
                }
            }
            catch (Exception)
            {
            }
        }
    }
}

