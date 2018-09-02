namespace Report
{
    using DevExpress.XtraEditors;
    using FormBase;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    /// <summary>
    /// 报表的List条目用户窗体
    /// </summary>
    internal class ReportList : UserControlBase1
    {
        private List<string> _realReportID = new List<string>();
        private List<string> _reportIds = new List<string>();
        private List<string> _reportNames = new List<string>();
        private CheckedListBoxControl checkedListBoxControl_ReportList;
        private IContainer components;
        private GroupControl groupControlDist;
        private Panel panelDistLocation;

        public ReportList()
        {
            this.InitializeComponent();
        }

        private void checkedListBoxControl_ReportList_SelectedIndexChanged(object sender, EventArgs e)
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
        /// 获取选择的报表ID
        /// </summary>
        /// <returns></returns>
        public List<string> GetSelectedReportID()
        {
            this._reportIds.Clear();
            foreach (int num in (IEnumerable) this.checkedListBoxControl_ReportList.CheckedIndices)
            {
                this._reportIds.Add(this._realReportID[num]);
            }
            return this._reportIds;
        }

        /// <summary>
        /// 获取选择报表的名称
        /// </summary>
        /// <returns></returns>
        public List<string> GetSelectedReportName()
        {
            this._reportNames.Clear();
            foreach (int num in (IEnumerable) this.checkedListBoxControl_ReportList.CheckedIndices)
            {
                this._reportNames.Add(this.checkedListBoxControl_ReportList.GetItemText(num));
            }
            return this._reportNames;
        }

        private void InitializeComponent()
        {
            this.groupControlDist = new DevExpress.XtraEditors.GroupControl();
            this.panelDistLocation = new System.Windows.Forms.Panel();
            this.checkedListBoxControl_ReportList = new DevExpress.XtraEditors.CheckedListBoxControl();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlDist)).BeginInit();
            this.groupControlDist.SuspendLayout();
            this.panelDistLocation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkedListBoxControl_ReportList)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControlDist
            // 
            this.groupControlDist.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.groupControlDist.Appearance.Options.UseBackColor = true;
            this.groupControlDist.Controls.Add(this.panelDistLocation);
            this.groupControlDist.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControlDist.Location = new System.Drawing.Point(0, 0);
            this.groupControlDist.Name = "groupControlDist";
            this.groupControlDist.Padding = new System.Windows.Forms.Padding(6, 2, 8, 8);
            this.groupControlDist.Size = new System.Drawing.Size(465, 271);
            this.groupControlDist.TabIndex = 19;
            this.groupControlDist.Text = "选择报表";
            // 
            // panelDistLocation
            // 
            this.panelDistLocation.BackColor = System.Drawing.Color.Transparent;
            this.panelDistLocation.Controls.Add(this.checkedListBoxControl_ReportList);
            this.panelDistLocation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDistLocation.ForeColor = System.Drawing.Color.Black;
            this.panelDistLocation.Location = new System.Drawing.Point(8, 24);
            this.panelDistLocation.Name = "panelDistLocation";
            this.panelDistLocation.Size = new System.Drawing.Size(447, 237);
            this.panelDistLocation.TabIndex = 9;
            // 
            // checkedListBoxControl_ReportList
            // 
            this.checkedListBoxControl_ReportList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkedListBoxControl_ReportList.HorizontalScrollbar = true;
            this.checkedListBoxControl_ReportList.Location = new System.Drawing.Point(0, 0);
            this.checkedListBoxControl_ReportList.Name = "checkedListBoxControl_ReportList";
            this.checkedListBoxControl_ReportList.Size = new System.Drawing.Size(447, 237);
            this.checkedListBoxControl_ReportList.TabIndex = 1;
            // 
            // ReportList
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.Appearance.Options.UseBackColor = true;
            this.Controls.Add(this.groupControlDist);
            this.Name = "ReportList";
            this.Size = new System.Drawing.Size(465, 271);
            ((System.ComponentModel.ISupportInitialize)(this.groupControlDist)).EndInit();
            this.groupControlDist.ResumeLayout(false);
            this.panelDistLocation.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.checkedListBoxControl_ReportList)).EndInit();
            this.ResumeLayout(false);

        }

        /// <summary>
        /// 初始化统计报表：将要调查的统计Excel报表添加进List中
        /// </summary>
        /// <param name="pTheme"></param>
        /// <param name="pType"></param>
        public void InitReportList(StatisticsTheme pTheme, SystemType pType)
        {
            ReportViewer viewer = new ReportViewer(pTheme);
            List<string> pNames = new List<string>();
            viewer.GetReportNameSql(ref pNames, ref this._realReportID);
            //if (((pType == SystemType.ZYGL) && (pTheme == StatisticsTheme.CF)) || (pType == SystemType.FQSJ))
            //{
            //    pNames.Add("简易伐区调查设计表");
            //    this._realReportID.Add("5");
            //}
            //else if ((pType == SystemType.ZYGL_EWLL_CF) && (pTheme == StatisticsTheme.CF))
            //{
            //    pNames.Remove("伐区调查及林木检尺登记表");
            //    this._realReportID.Remove("3");
            //}
            this.checkedListBoxControl_ReportList.DataSource = pNames;
            this.checkedListBoxControl_ReportList.CheckAll();
            this.checkedListBoxControl_ReportList.CheckOnClick = true;
        }

        private List<string> RealReportID
        {
            get
            {
                return this._realReportID;
            }
            set
            {
                this._realReportID = value;
            }
        }

        public List<string> ReportIds
        {
            get
            {
                return this._reportIds;
            }
        }

        public List<string> ReportNames
        {
            get
            {
                return this._reportNames;
            }
        }
    }
}

