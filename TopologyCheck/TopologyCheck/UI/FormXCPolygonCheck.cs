namespace TopologyCheck.UI
{
    using DevExpress.Utils;
    using DevExpress.XtraEditors;
    using DevExpress.XtraGrid;
    using DevExpress.XtraGrid.Views.Grid;
    using ESRI.ArcGIS.Carto;
    using ESRI.ArcGIS.Controls;
    using ESRI.ArcGIS.Geodatabase;
    using ESRI.ArcGIS.Geometry;
    using FormBase;
    using FunFactory;
    using System;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Windows.Forms;
    using TaskManage;
    using Utilities;
    using DevExpress.XtraGrid.Views.Base;

    public class FormXCPolygonCheck : FormBase3
    {
        private IContainer components;
        private GridControl gridControlResult;
        private GridView gridViewResult;
        private GroupControl groupControlResult;
        private Label labelDes;
        internal Label LabelLoadInfo;
        private const string m_ClassName = "TopologyCheck.UI.FormXCPolygonCheck";
        private ErrorOpt m_ErrorOpt = UtilFactory.GetErrorOpt();
        private IHookHelper m_HookHelper;
        private string m_SubSysName = UtilFactory.GetConfigOpt().GetSystemName();
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private Panel panel4;
        private SimpleButton simpleButtonCheck;

        public FormXCPolygonCheck()
        {
            this.InitializeComponent();
        }

        private DataTable Check()
        {
            try
            {
                IFeatureClass featureClass = EditTask.EditLayer.FeatureClass;
                string name = featureClass.LengthField.Name;
                string str2 = featureClass.AreaField.Name;
                string str3 = "left(XI_BAN,charindex('-',XI_BAN)-1)=right(XI_BAN,len(XI_BAN)-charindex('-',XI_BAN))";
                double num = 3.1415926;
                double num2 = 2.45;
                object obj2 = str3;
                str3 = string.Concat(new object[] { obj2, "and (", name, "/(2*sqrt(", str2, "*", num, ")))>", num2 });
                IDBAccess dBAccess = UtilFactory.GetDBAccess(UtilFactory.GetConfigOpt().GetConfigValue2("DataBase", "MapDBkey"));
                if (dBAccess == null)
                {
                    MessageBox.Show("数据库连接有错！", "提示");
                    return null;
                }
                IDataset dataset = (IDataset) featureClass;
                string sql = "select " + featureClass.OIDFieldName + " from " + dataset.Name + " where " + str3;
                return dBAccess.GetDataTable(dBAccess, sql);
            }
            catch (Exception exception)
            {
                this.m_ErrorOpt.ErrorOperate(this.m_SubSysName, "TopologyCheck.UI.FormXCPolygonCheck", "Check", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                return null;
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

        private void FormXCPolygonCheck_Load(object sender, EventArgs e)
        {
            this.labelDes.Text = "    此工具根据景观形状指数，检查更新过程中生成的【特别不规则多边形】。检查结果请用户自行判断是否为错误多边形，如为错误多边形，应用分割、合并等工具修正错误。";
            this.panel2.Visible = false;
            this.LabelLoadInfo.Visible = false;
        }

        private void gridControlResult_DoubleClick(object sender, EventArgs e)
        {
            DataRow focusedDataRow = this.gridViewResult.GetFocusedDataRow();
            if (focusedDataRow != null)
            {
                string sOID = focusedDataRow[0].ToString();
                this.ZoomErrorFeature(sOID);
            }
        }

        private void InitializeComponent()
        {
            this.labelDes = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.simpleButtonCheck = new DevExpress.XtraEditors.SimpleButton();
            this.panel4 = new System.Windows.Forms.Panel();
            this.LabelLoadInfo = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupControlResult = new DevExpress.XtraEditors.GroupControl();
            this.gridControlResult = new DevExpress.XtraGrid.GridControl();
            this.gridViewResult = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlResult)).BeginInit();
            this.groupControlResult.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlResult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewResult)).BeginInit();
            this.SuspendLayout();
            // 
            // labelDes
            // 
            this.labelDes.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelDes.Location = new System.Drawing.Point(5, 10);
            this.labelDes.Name = "labelDes";
            this.labelDes.Size = new System.Drawing.Size(336, 59);
            this.labelDes.TabIndex = 0;
            this.labelDes.Text = "labelDes";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.labelDes);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(5, 10, 0, 0);
            this.panel1.Size = new System.Drawing.Size(341, 123);
            this.panel1.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.simpleButtonCheck);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(5, 76);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(336, 25);
            this.panel3.TabIndex = 13;
            // 
            // simpleButtonCheck
            // 
            this.simpleButtonCheck.Location = new System.Drawing.Point(245, 0);
            this.simpleButtonCheck.Name = "simpleButtonCheck";
            this.simpleButtonCheck.Size = new System.Drawing.Size(48, 23);
            this.simpleButtonCheck.TabIndex = 1;
            this.simpleButtonCheck.Text = "检查";
            this.simpleButtonCheck.Click += new System.EventHandler(this.simpleButtonCheck_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.LabelLoadInfo);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(5, 101);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(336, 22);
            this.panel4.TabIndex = 14;
            // 
            // LabelLoadInfo
            // 
            this.LabelLoadInfo.BackColor = System.Drawing.Color.Transparent;
            this.LabelLoadInfo.ForeColor = System.Drawing.Color.OrangeRed;
            this.LabelLoadInfo.Location = new System.Drawing.Point(77, 1);
            this.LabelLoadInfo.Name = "LabelLoadInfo";
            this.LabelLoadInfo.Size = new System.Drawing.Size(146, 19);
            this.LabelLoadInfo.TabIndex = 13;
            this.LabelLoadInfo.Text = "正在进行检查，请稍候...";
            this.LabelLoadInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.groupControlResult);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 123);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(341, 222);
            this.panel2.TabIndex = 2;
            // 
            // groupControlResult
            // 
            this.groupControlResult.Controls.Add(this.gridControlResult);
            this.groupControlResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControlResult.Location = new System.Drawing.Point(0, 0);
            this.groupControlResult.Name = "groupControlResult";
            this.groupControlResult.Padding = new System.Windows.Forms.Padding(10, 0, 10, 5);
            this.groupControlResult.Size = new System.Drawing.Size(341, 222);
            this.groupControlResult.TabIndex = 9;
            this.groupControlResult.Text = "结果列表";
            // 
            // gridControlResult
            // 
            this.gridControlResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlResult.Location = new System.Drawing.Point(12, 22);
            this.gridControlResult.MainView = this.gridViewResult;
            this.gridControlResult.Name = "gridControlResult";
            this.gridControlResult.Size = new System.Drawing.Size(317, 193);
            this.gridControlResult.TabIndex = 2;
            this.gridControlResult.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewResult});
            this.gridControlResult.DoubleClick += new System.EventHandler(this.gridControlResult_DoubleClick);
            // 
            // gridViewResult
            // 
            this.gridViewResult.GridControl = this.gridControlResult;
            this.gridViewResult.Name = "gridViewResult";
            this.gridViewResult.OptionsBehavior.Editable = false;
            this.gridViewResult.OptionsCustomization.AllowColumnMoving = false;
            this.gridViewResult.OptionsCustomization.AllowFilter = false;
            this.gridViewResult.OptionsCustomization.AllowGroup = false;
            this.gridViewResult.OptionsCustomization.AllowSort = false;
            this.gridViewResult.OptionsMenu.EnableColumnMenu = false;
            this.gridViewResult.OptionsMenu.EnableFooterMenu = false;
            this.gridViewResult.OptionsMenu.EnableGroupPanelMenu = false;
            this.gridViewResult.OptionsView.ColumnAutoWidth = false;
            this.gridViewResult.OptionsView.ShowGroupPanel = false;
            this.gridViewResult.OptionsView.ShowIndicator = false;
            // 
            // FormXCPolygonCheck
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(341, 345);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.LookAndFeel.SkinName = "Blue";
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormXCPolygonCheck";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "不规则多边形检查";
            this.Load += new System.EventHandler(this.FormXCPolygonCheck_Load);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControlResult)).EndInit();
            this.groupControlResult.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlResult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewResult)).EndInit();
            this.ResumeLayout(false);

        }

        private void simpleButtonCheck_Click(object sender, EventArgs e)
        {
            this.panel2.Visible = false;
            this.gridControlResult.DataSource = null;
            this.LabelLoadInfo.Text = "正在进行检查，请稍候……";
            this.LabelLoadInfo.Visible = true;
            this.simpleButtonCheck.Enabled = false;
            this.Refresh();
            DataTable table = this.Check();
            this.simpleButtonCheck.Enabled = true;
            if (table == null)
            {
                this.LabelLoadInfo.Text = "检查出错，无结果。";
            }
            else if (table.Rows.Count == 0)
            {
                this.LabelLoadInfo.Text = "检查通过，当前编辑图层无不规则多边形。";
            }
            else
            {
                this.LabelLoadInfo.Visible = false;
                this.panel2.Visible = true;
                this.groupControlResult.Text = "结果列表（" + table.Rows.Count + "）";
                this.gridControlResult.DataSource = table;
                this.gridViewResult.Columns[0].Width = 300;
                this.gridViewResult.Columns[0].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
                this.gridViewResult.Columns[0].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Near;
            }
        }

        private void ZoomErrorFeature(string sOID)
        {
            try
            {
                IFeature feature = null;
                string kindCode = EditTask.KindCode;
                UtilFactory.GetConfigOpt();
                IFeatureClass featureClass = EditTask.EditLayer.FeatureClass;
                IQueryFilter filter = new QueryFilterClass();
                filter.WhereClause = featureClass.OIDFieldName + "=" + sOID;
                feature = featureClass.Search(filter, false).NextFeature();
                if (feature != null)
                {
                    IActiveView activeView = this.m_HookHelper.ActiveView;
                    if (activeView != null)
                    {
                        IGeometry shapeCopy = feature.ShapeCopy;
                        if (shapeCopy.IsEmpty)
                        {
                            XtraMessageBox.Show(this, "要素图形为空，无法定位！", "逻辑校验");
                        }
                        else
                        {
                            shapeCopy = GISFunFactory.UnitFun.ConvertPoject(shapeCopy, this.m_HookHelper.ActiveView.FocusMap.SpatialReference);
                            IEnvelope envelope = new EnvelopeClass();
                            envelope = shapeCopy.Envelope;
                            if (shapeCopy.GeometryType == esriGeometryType.esriGeometryPoint)
                            {
                                IEnvelope envelope2 = new EnvelopeClass();
                                envelope2.SpatialReference = activeView.FocusMap.SpatialReference;
                                double num = 100.0;
                                envelope2.PutCoords(envelope.XMin - num, envelope.YMin - num, envelope.XMax + num, envelope.YMax + num);
                                envelope = envelope2;
                            }
                            else
                            {
                                envelope.Expand(1.5, 1.5, true);
                            }
                            IFeatureSelection editLayer = EditTask.EditLayer as IFeatureSelection;
                            editLayer.Clear();
                            editLayer.Add(feature);
                            activeView.FullExtent = envelope;
                            activeView.Refresh();
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                this.m_ErrorOpt.ErrorOperate(this.m_SubSysName, "TopologyCheck.UI.FormXCPolygonCheck", "ZoomErrorFeature", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        public object Hook
        {
            set
            {
                if (value != null)
                {
                    try
                    {
                        this.m_HookHelper = new HookHelperClass();
                        this.m_HookHelper.Hook = value;
                        if (this.m_HookHelper.ActiveView == null)
                        {
                            this.m_HookHelper = null;
                        }
                    }
                    catch
                    {
                        this.m_HookHelper = null;
                    }
                }
            }
        }
    }
}

