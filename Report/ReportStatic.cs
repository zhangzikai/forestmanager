namespace Report
{
    using DevExpress.XtraEditors;
    using DevExpress.XtraEditors.Controls;
    using FormBase;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.IO;
    using System.Windows.Forms;

    /// <summary>
    /// 采伐统计表窗体
    /// </summary>
    public class ReportStatic : FormBase3
    {
        /// <summary>
        /// 报表参数类
        /// </summary>
        private ReportParamter _rp;
        private IContainer components;
        private DateEdit dateEdit_From;
        private DateEdit dateEdit_To;
        private LabelControl labelControl1;
        private LabelControl labelControl2;
        /// <summary>
        /// 报表的List条目用户窗体
        /// </summary>
        private ReportList reportList1;
        private SimpleButton simpleButton_close;
        private SimpleButton simpleButton_ok;
        /// <summary>
        /// 用于显示行政区划的TreeList树的公用用户窗体。
        /// </summary>
        private UserControlDistCode userControlDistCode1;

        /// <summary>
        /// 采伐统计表：窗体：构造器
        /// </summary>
        /// <param name="pReportParamter"></param>
        public ReportStatic(ReportParamter pReportParamter)
        {
            this.InitializeComponent();
            this._rp = pReportParamter;
            this.userControlDistCode1.InitialControls();
        }

        /// <summary>
        /// 更新时间无效：因为OnClick方法为null
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dateEdit_From_EditValueChanged(object sender, EventArgs e)
        {
        }

        private void dateEdit_To_EditValueChanged(object sender, EventArgs e)
        {
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// 获取时间
        /// </summary>
        /// <returns></returns>
        private string GetSJ()
        {
            if ((this.dateEdit_From.EditValue != null) || (this.dateEdit_To.EditValue != null))
            {
                if ((this.dateEdit_From.EditValue == null) && (this.dateEdit_To.EditValue != null))
                {
                    return ("GXSJ<='" + this.dateEdit_To.DateTime.ToString("yyyyMMdd") + "'");
                }
                if ((this.dateEdit_From.EditValue != null) && (this.dateEdit_To.EditValue == null))
                {
                    return ("GXSJ>='" + this.dateEdit_From.DateTime.ToString("yyyyMMdd") + "'");
                }
                if ((this.dateEdit_From.EditValue != null) && (this.dateEdit_To.EditValue != null))
                {
                    return ("(GENGXINSJ>='" + this.dateEdit_From.DateTime.ToString("yyyyMMdd") + "' and GENGXINSJ<='" + this.dateEdit_To.DateTime.ToString("yyyyMMdd") + "')");
                    ////return ("(GXSJ>='" + this.dateEdit_From.DateTime.ToString("yyyyMMdd") + "' and GXSJ<='" + this.dateEdit_To.DateTime.ToString("yyyyMMdd") + "')");
                }
            }
            return "1=1";
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
            this.dateEdit_To = new DevExpress.XtraEditors.DateEdit();
            this.dateEdit_From = new DevExpress.XtraEditors.DateEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.userControlDistCode1 = new UserControlDistCode();
            this.reportList1 = new ReportList();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit_To.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit_To.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit_From.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit_From.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // simpleButton_ok
            // 
            this.simpleButton_ok.Location = new System.Drawing.Point(449, 314);
            this.simpleButton_ok.Name = "simpleButton_ok";
            this.simpleButton_ok.Size = new System.Drawing.Size(75, 23);
            this.simpleButton_ok.TabIndex = 2;
            this.simpleButton_ok.Text = "统计";
            this.simpleButton_ok.Click += new System.EventHandler(this.simpleButton_ok_Click);
            // 
            // simpleButton_close
            // 
            this.simpleButton_close.Location = new System.Drawing.Point(530, 314);
            this.simpleButton_close.Name = "simpleButton_close";
            this.simpleButton_close.Size = new System.Drawing.Size(75, 23);
            this.simpleButton_close.TabIndex = 3;
            this.simpleButton_close.Text = "关闭";
            this.simpleButton_close.Click += new System.EventHandler(this.simpleButton_close_Click);
            // 
            // dateEdit_To
            // 
            this.dateEdit_To.EditValue = null;
            this.dateEdit_To.Location = new System.Drawing.Point(179, 316);
            this.dateEdit_To.Name = "dateEdit_To";
            this.dateEdit_To.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit_To.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateEdit_To.Size = new System.Drawing.Size(100, 20);
            this.dateEdit_To.TabIndex = 5;
            this.dateEdit_To.EditValueChanged += new System.EventHandler(this.dateEdit_To_EditValueChanged);
            // 
            // dateEdit_From
            // 
            this.dateEdit_From.EditValue = null;
            this.dateEdit_From.Location = new System.Drawing.Point(59, 316);
            this.dateEdit_From.Name = "dateEdit_From";
            this.dateEdit_From.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit_From.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateEdit_From.Size = new System.Drawing.Size(100, 20);
            this.dateEdit_From.TabIndex = 6;
            this.dateEdit_From.EditValueChanged += new System.EventHandler(this.dateEdit_From_EditValueChanged);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(3, 319);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(52, 14);
            this.labelControl1.TabIndex = 7;
            this.labelControl1.Text = "更新时间:";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(164, 319);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(9, 14);
            this.labelControl2.TabIndex = 8;
            this.labelControl2.Text = "~";
            // 
            // userControlDistCode1
            // 
            this.userControlDistCode1.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.userControlDistCode1.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.userControlDistCode1.Appearance.Options.UseBackColor = true;
            this.userControlDistCode1.Location = new System.Drawing.Point(3, 4);
            this.userControlDistCode1.MaximumSize = new System.Drawing.Size(350, 300);
            this.userControlDistCode1.Name = "userControlDistCode1";
            this.userControlDistCode1.Size = new System.Drawing.Size(276, 300);
            this.userControlDistCode1.TabIndex = 9;
            // 
            // reportList1
            // 
            this.reportList1.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.reportList1.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.reportList1.Appearance.Options.UseBackColor = true;
            this.reportList1.Location = new System.Drawing.Point(285, 4);
            this.reportList1.Name = "reportList1";
            this.reportList1.Size = new System.Drawing.Size(320, 300);
            this.reportList1.TabIndex = 1;
            // 
            // ReportStatic
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.Appearance.Options.UseBackColor = true;
            this.ClientSize = new System.Drawing.Size(610, 343);
            this.Controls.Add(this.userControlDistCode1);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.dateEdit_From);
            this.Controls.Add(this.dateEdit_To);
            this.Controls.Add(this.simpleButton_close);
            this.Controls.Add(this.simpleButton_ok);
            this.Controls.Add(this.reportList1);
            this.LookAndFeel.SkinName = "Blue";
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ReportStatic";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "报表统计";
            this.Load += new System.EventHandler(this.ReportStatic_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit_To.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit_To.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit_From.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit_From.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void simpleButton_close_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        /// <summary>
        /// 采伐报表统计--统计--的响应事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void simpleButton_ok_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog;
            string path = "";
            try
            {
                if (((this.dateEdit_From.EditValue != null) && (this.dateEdit_To.EditValue != null)) && (this.dateEdit_From.DateTime > this.dateEdit_To.DateTime))
                {
                    XtraMessageBox.Show("起始时间应小于等于结束时间！");
                }
                else
                {
                    dialog = new SaveFileDialog();
                    dialog.Title = "保存营造林统计表";
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
                    this._rp.BK = this.userControlDistCode1.GetSelectedCode();
                    this._rp.BK = this.userControlDistCode1.GetSelectedCode() + " and " + this.GetSJ();
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
                        viewer.Static(this._rp,path);
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        private void ReportStatic_Load(object sender, EventArgs e)
        {
            dateEdit_From.EditValue = DateTime.Now;
            dateEdit_To.EditValue = DateTime.Now;
        }
    }
}

