namespace Report
{
    using DevExpress.XtraEditors;
    using ESRI.ArcGIS.Carto;
    using ESRI.ArcGIS.Geodatabase;
    using FormBase;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.Text;
    using System.Windows.Forms;

    /// <summary>
    /// 
    /// </summary>
    public class FQReportStatic : FormBase3
    {
        private Dictionary<int, string> _bk = new Dictionary<int, string>();
        private ReportParamter _rp;
        private CheckedListBoxControl checkedListBoxControl_bk;
        private IContainer components;
        private GroupControl groupControlDist;
        private Panel panelDistLocation;
        private ReportList reportList1;
        private SaveFileDialog saveFileDialog1;
        private SimpleButton simpleButton_close;
        private SimpleButton simpleButton_ok;
        private SimpleButton simpleButton1;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pReportParamter"></param>
        public FQReportStatic(ReportParamter pReportParamter)
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

        private string GetTj()
        {
            StringBuilder builder = new StringBuilder();
            if (this.checkedListBoxControl_bk.CheckedIndices.Count == 0)
            {
                return "1=1";
            }
            if (this.checkedListBoxControl_bk.CheckedIndices.Count > 1)
            {
                builder.Append("(");
                foreach (int num in (IEnumerable) this.checkedListBoxControl_bk.CheckedIndices)
                {
                    builder.Append("(");
                    builder.Append(this._bk[num]);
                    builder.Append(") or ");
                }
                builder = builder.Remove(builder.Length - 4, 4);
                builder.Append(")");
            }
            else
            {
                builder.Append("(");
                builder.Append(this._bk[this.checkedListBoxControl_bk.CheckedIndices[0]]);
                builder.Append(")");
            }
            return builder.ToString();
        }

        public bool Init()
        {
            this.reportList1.InitReportList(this._rp.Theme, this._rp.SysType);
            IFeatureLayer featureLayer = this._rp.FeatureLayer;
            IFeatureClass featureClass = featureLayer.FeatureClass;
            int index = featureClass.Fields.FindField("CUN");
            int num2 = featureClass.Fields.FindField("LIN_BAN");
            int num3 = featureClass.Fields.FindField("XIAO_BAN");
            int num4 = featureClass.Fields.FindField("XI_BAN");
            IFeatureSelection selection = featureLayer as IFeatureSelection;
            IEnumIDs iDs = selection.SelectionSet.IDs;
            iDs.Reset();
            int iD = iDs.Next();
            List<string> list = new List<string>();
            IFeature feature = null;
            object obj2 = null;
            string str = null;
            StringBuilder builder = null;
            StringBuilder builder2 = null;
            while (iD != -1)
            {
                builder = new StringBuilder();
                feature = featureClass.GetFeature(iD);
                obj2 = feature.get_Value(num2);
                if (obj2 != null)
                {
                    builder.Append("_");
                }
                else
                {
                    str = obj2.ToString();
                    builder.Append(str);
                    builder.Append("_");
                }
                obj2 = feature.get_Value(num3);
                if (obj2 != null)
                {
                    builder.Append("_");
                }
                else
                {
                    str = obj2.ToString();
                    builder.Append(str);
                    builder.Append("_");
                }
                obj2 = feature.get_Value(num4);
                if (obj2 != null)
                {
                    builder.Append("_");
                }
                else
                {
                    str = obj2.ToString();
                    builder.Append(str);
                    builder.Append("_");
                }
                builder = builder.Remove(builder.Length - 1, 1);
                list.Add(builder.ToString());
                iD = iDs.Next();
            }
            IQueryFilter filter = new QueryFilterClass {
                WhereClause = this._rp.TaskID
            };
            IFeatureCursor cursor = featureClass.Search(filter, false);
            feature = cursor.NextFeature();
            for (int i = 0; feature != null; i++)
            {
                builder = new StringBuilder();
                builder2 = new StringBuilder();
                obj2 = feature.get_Value(index);
                if (obj2 == null)
                {
                    builder2.Append("cun=null and ");
                }
                else
                {
                    builder2.Append("cun='");
                    builder2.Append(obj2.ToString());
                    builder2.Append("' and ");
                }
                obj2 = feature.get_Value(num2);
                if (obj2 == null)
                {
                    builder2.Append("lin_ban=null and ");
                    builder.Append("_");
                }
                else
                {
                    builder2.Append("lin_ban='");
                    str = obj2.ToString();
                    builder2.Append(str);
                    builder2.Append("' and ");
                    builder.Append(str);
                    builder.Append("_");
                }
                obj2 = feature.get_Value(num3);
                if (obj2 == null)
                {
                    builder2.Append("xiao_ban=null and ");
                    builder.Append("_");
                }
                else
                {
                    builder2.Append("xiao_ban='");
                    str = obj2.ToString();
                    builder2.Append(str);
                    builder2.Append("' and ");
                    builder.Append(str);
                    builder.Append("_");
                }
                obj2 = feature.get_Value(num4);
                if (obj2 == null)
                {
                    builder2.Append("xi_ban=null and ");
                    builder.Append("_");
                }
                else
                {
                    builder2.Append("xi_ban='");
                    str = obj2.ToString();
                    builder2.Append(str);
                    builder2.Append("' and ");
                    builder.Append(str);
                    builder.Append("_");
                }
                builder2 = builder2.Remove(builder2.Length - 5, 5);
                builder = builder.Remove(builder.Length - 1, 1);
                if (list.Contains(builder.ToString()))
                {
                    this.checkedListBoxControl_bk.Items.Add(builder, true);
                }
                else
                {
                    this.checkedListBoxControl_bk.Items.Add(builder, false);
                }
                feature = cursor.NextFeature();
                this._bk.Add(i, builder2.ToString());
            }
            if (ReportInit.Init(this._rp) == "0")
            {
                return false;
            }
            return true;
        }

        private void InitializeComponent()
        {
            this.reportList1 = new ReportList();
            this.simpleButton_ok = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton_close = new DevExpress.XtraEditors.SimpleButton();
            this.groupControlDist = new DevExpress.XtraEditors.GroupControl();
            this.panelDistLocation = new System.Windows.Forms.Panel();
            this.checkedListBoxControl_bk = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlDist)).BeginInit();
            this.groupControlDist.SuspendLayout();
            this.panelDistLocation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkedListBoxControl_bk)).BeginInit();
            this.SuspendLayout();
            // 
            // reportList1
            // 
            this.reportList1.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.reportList1.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.reportList1.Appearance.Options.UseBackColor = true;
            this.reportList1.Location = new System.Drawing.Point(243, 8);
            this.reportList1.Name = "reportList1";
            this.reportList1.Size = new System.Drawing.Size(313, 296);
            this.reportList1.TabIndex = 1;
            // 
            // simpleButton_ok
            // 
            this.simpleButton_ok.Location = new System.Drawing.Point(314, 310);
            this.simpleButton_ok.Name = "simpleButton_ok";
            this.simpleButton_ok.Size = new System.Drawing.Size(75, 23);
            this.simpleButton_ok.TabIndex = 2;
            this.simpleButton_ok.Text = "统计";
            this.simpleButton_ok.Click += new System.EventHandler(this.simpleButton_ok_Click);
            // 
            // simpleButton_close
            // 
            this.simpleButton_close.Location = new System.Drawing.Point(476, 310);
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
            this.groupControlDist.Controls.Add(this.panelDistLocation);
            this.groupControlDist.Location = new System.Drawing.Point(8, 8);
            this.groupControlDist.Name = "groupControlDist";
            this.groupControlDist.Padding = new System.Windows.Forms.Padding(6, 2, 8, 8);
            this.groupControlDist.Size = new System.Drawing.Size(229, 296);
            this.groupControlDist.TabIndex = 18;
            this.groupControlDist.Text = "选择小班(林班号_小班号_细班号)";
            // 
            // panelDistLocation
            // 
            this.panelDistLocation.BackColor = System.Drawing.Color.Transparent;
            this.panelDistLocation.Controls.Add(this.checkedListBoxControl_bk);
            this.panelDistLocation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDistLocation.ForeColor = System.Drawing.Color.Black;
            this.panelDistLocation.Location = new System.Drawing.Point(8, 24);
            this.panelDistLocation.Name = "panelDistLocation";
            this.panelDistLocation.Size = new System.Drawing.Size(211, 262);
            this.panelDistLocation.TabIndex = 9;
            // 
            // checkedListBoxControl_bk
            // 
            this.checkedListBoxControl_bk.CheckOnClick = true;
            this.checkedListBoxControl_bk.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkedListBoxControl_bk.HorizontalScrollbar = true;
            this.checkedListBoxControl_bk.Location = new System.Drawing.Point(0, 0);
            this.checkedListBoxControl_bk.Name = "checkedListBoxControl_bk";
            this.checkedListBoxControl_bk.Size = new System.Drawing.Size(211, 262);
            this.checkedListBoxControl_bk.TabIndex = 1;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(395, 310);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(75, 23);
            this.simpleButton1.TabIndex = 19;
            this.simpleButton1.Text = "导出";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "Excel|*.xls";
            // 
            // FQReportStatic
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.Appearance.Options.UseBackColor = true;
            this.ClientSize = new System.Drawing.Size(563, 341);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.groupControlDist);
            this.Controls.Add(this.simpleButton_close);
            this.Controls.Add(this.simpleButton_ok);
            this.Controls.Add(this.reportList1);
            this.LookAndFeel.SkinName = "Blue";
            this.Name = "FQReportStatic";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "报表统计";
            ((System.ComponentModel.ISupportInitialize)(this.groupControlDist)).EndInit();
            this.groupControlDist.ResumeLayout(false);
            this.panelDistLocation.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.checkedListBoxControl_bk)).EndInit();
            this.ResumeLayout(false);

        }

        private void simpleButton_close_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        private void simpleButton_ok_Click(object sender, EventArgs e)
        {
            try
            {
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
                if (this._rp.SysType == SystemType.FQSJ)
                {
                    this._rp.BK = this.GetTj() + " AND " + this._rp.TaskID;
                }
                else
                {
                    this._rp.BK = this.GetTj();
                }
                this._rp.DataTable = (this._rp.FeatureLayer.FeatureClass as IDataset).Name;
                if (selectedReportID.Count == 0)
                {
                    XtraMessageBox.Show("请选择要统计的报表！");
                }
                else
                {
                    viewer.Static(this._rp,null);
                }
            }
            catch (Exception)
            {
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    ReportViewer viewer = new ReportViewer(this._rp.Theme);
                    List<string> selectedReportID = this.reportList1.GetSelectedReportID();
                    this._rp.IDs = selectedReportID;
                    this._rp.Names = this.reportList1.GetSelectedReportName();
                    StaticMsg msg = new StaticMsg {
                        StartMessage = "正在导出表格...",
                        Title = "表格导出",
                        ExceptionMessage = "导出表格发生异常！",
                        EndMessage = "表格已导出！",
                        Verb = "正在导出：",
                        StaticReportCount = selectedReportID.Count
                    };
                    this._rp.StatisticsMsg = msg;
                    if (this._rp.SysType == SystemType.FQSJ)
                    {
                        this._rp.BK = this.GetTj() + " AND " + this._rp.TaskID;
                    }
                    else
                    {
                        this._rp.BK = this.GetTj();
                    }
                    this._rp.ExportPath = this.saveFileDialog1.FileName;
                    this._rp.DataTable = (this._rp.FeatureLayer.FeatureClass as IDataset).Name;
                    if (selectedReportID.Count == 0)
                    {
                        XtraMessageBox.Show("请选择要导出的表格！");
                    }
                    else
                    {
                        viewer.ExportExcel(this._rp);
                    }
                }
            }
            catch (Exception)
            {
            }
        }
    }
}

