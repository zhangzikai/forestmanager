namespace DataEdit
{
    using DevExpress.XtraEditors;
    using DevExpress.XtraEditors.Controls;
    using DevExpress.XtraGrid;
    using DevExpress.XtraGrid.Columns;
    using DevExpress.XtraGrid.Views.Grid;
    using DevExpress.XtraTab;
    using ESRI.ArcGIS.Catalog;
    using ESRI.ArcGIS.CatalogUI;
    using ESRI.ArcGIS.DataSourcesGDB;
    using ESRI.ArcGIS.DataSourcesRaster;
    using ESRI.ArcGIS.Geodatabase;
    using ESRI.ArcGIS.Geometry;
    using FormBase;
    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.IO;
    using System.Text;
    using System.Windows.Forms;
    using Utilities;
    using DevExpress.XtraGrid.Views.Base;

    public class FormSetProjectedCoordinateSystem : FormBase2
    {
        private IContainer components = null;
        private ComboBoxEdit comProjectName;
        private ComboBoxEdit comUnitName;
        public bool FlagOk = false;
        private GridColumn gridColumn1;
        private GridColumn gridColumn2;
        private GridControl gridControl1;
        private GridView gridView1;
        private GroupControl groupControl1;
        private GroupControl groupControl2;
        private GroupControl groupControl3;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        public FormSetGeographicCoordinateSystem mFormSetGeographic = null;
        private IGeographicCoordinateSystem mGeographicCoordinateSystem = null;
        private ArrayList mProjectionList = null;
        private ISpatialReference mSpatialReference = null;
        private DataTable mTableProjectionValue = null;
        private ArrayList mUnitList = null;
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private Panel panel4;
        private Panel panel5;
        private Panel panel6;
        private Panel panel7;
        private PanelControl panelControl1;
        private RichTextBox rtbDetailes;
        private SimpleButton sButCancel;
        private SimpleButton sButImport;
        private SimpleButton sButModify;
        private SimpleButton sButSelect;
        private TextEdit txtCoordinateName;
        private TextEdit txtperUnit;
        private XtraTabControl xtraTabControl1;
        private XtraTabPage xtraTabPage1;

        public FormSetProjectedCoordinateSystem()
        {
            this.InitializeComponent();
        }

        private void comProjectName_TextChanged(object sender, EventArgs e)
        {
            this.ReadProjectionValue(null);
        }

        private void comUnitName_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void comUnitName_SelectedValueChanged(object sender, EventArgs e)
        {
            if (this.mUnitList != null)
            {
                IUnit unit = null;
                for (int i = 0; i < this.mUnitList.Count; i++)
                {
                    unit = this.mUnitList[i] as IUnit;
                    if (unit.Name == this.comUnitName.Text)
                    {
                        this.txtperUnit.Text = unit.ConversionFactor.ToString();
                        break;
                    }
                }
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

        private string GetGeoCoordSysDetails(IGeographicCoordinateSystem pGeoCoordSys)
        {
            StringBuilder builder = new StringBuilder();
            try
            {
                builder.Append("地理坐标系统: ");
                builder.Append(pGeoCoordSys.Name);
                builder.Append("\r\n");
                builder.Append("角度单位: ");
                IAngularUnit coordinateUnit = pGeoCoordSys.CoordinateUnit;
                builder.Append(coordinateUnit.Name + "(" + coordinateUnit.ConversionFactor.ToString("0.0000000000000000") + ")");
                builder.Append("\r\n");
                builder.Append("本初子午线:");
                builder.Append(pGeoCoordSys.PrimeMeridian.Name + "(" + pGeoCoordSys.PrimeMeridian.Longitude.ToString("0.0000000000000000") + ")");
                builder.Append("\r\n");
                builder.Append("大地基准面:  ");
                builder.Append(pGeoCoordSys.Datum.Name);
                builder.Append("\r\n");
                builder.Append("   椭球体:  ");
                builder.Append(pGeoCoordSys.Datum.Spheroid.Name);
                builder.Append("\r\n");
                builder.Append("      长半轴:  ");
                builder.Append(pGeoCoordSys.Datum.Spheroid.SemiMajorAxis.ToString());
                builder.Append("\r\n");
                builder.Append("      短半轴:  ");
                builder.Append(pGeoCoordSys.Datum.Spheroid.SemiMinorAxis.ToString());
                builder.Append("\r\n");
                builder.Append("      扁率倒数:  ");
                builder.Append(pGeoCoordSys.Datum.Spheroid.Flattening.ToString());
                builder.Append("\r\n");
                return builder.ToString();
            }
            catch (Exception)
            {
                return builder.ToString();
            }
        }

        private string GetPrjCoordDetails(IProjectedCoordinateSystem pPrjCoodSys)
        {
            double longitudeOfOrigin = 0.0;
            StringBuilder builder = new StringBuilder();
            try
            {
                builder.Append("投影信息:");
                builder.Append(pPrjCoodSys.Projection.Name);
                builder.Append("\r\n");
                builder.Append("东偏:");
                builder.Append(Math.Round(pPrjCoodSys.FalseEasting, 6).ToString("0.000000"));
                builder.Append("\r\n");
                builder.Append("北偏:");
                builder.Append(pPrjCoodSys.FalseNorthing.ToString("0.000000"));
                builder.Append("\r\n");
                builder.Append("中央子午线: ");
                builder.Append(pPrjCoodSys.get_CentralMeridian(true).ToString("0.000000"));
                builder.Append("\r\n");
                builder.Append("比例因子: ");
                builder.Append(pPrjCoodSys.ScaleFactor.ToString("0.000000"));
                builder.Append("\r\n");
                builder.Append("经纬度原点: ");
                try
                {
                    longitudeOfOrigin = pPrjCoodSys.LongitudeOfOrigin;
                }
                catch (Exception)
                {
                    longitudeOfOrigin = 0.0;
                }
                builder.Append(longitudeOfOrigin.ToString("0.000000"));
                builder.Append("\r\n");
                builder.Append("坐标单位: ");
                builder.Append(pPrjCoodSys.CoordinateUnit.Name);
                builder.Append(pPrjCoodSys.CoordinateUnit.MetersPerUnit.ToString("0.000000"));
                builder.Append("\r\n   \r\n");
                builder.Append("地理坐标系统: ");
                builder.Append(pPrjCoodSys.GeographicCoordinateSystem.Name);
                builder.Append("\r\n");
                builder.Append("角度单位: ");
                IAngularUnit coordinateUnit = pPrjCoodSys.GeographicCoordinateSystem.CoordinateUnit;
                builder.Append(coordinateUnit.Name + "(" + coordinateUnit.ConversionFactor.ToString("0.0000000000000000") + ")");
                builder.Append("\r\n");
                builder.Append("本初子午线:");
                builder.Append(pPrjCoodSys.GeographicCoordinateSystem.PrimeMeridian.Name + "(" + pPrjCoodSys.GeographicCoordinateSystem.PrimeMeridian.Longitude.ToString("0.0000000000000000") + ")");
                builder.Append("\r\n");
                builder.Append("大地基准面:  ");
                builder.Append(pPrjCoodSys.GeographicCoordinateSystem.Datum.Name);
                builder.Append("\r\n");
                builder.Append("   椭球体:  ");
                builder.Append(pPrjCoodSys.GeographicCoordinateSystem.Datum.Spheroid.Name);
                builder.Append("\r\n");
                builder.Append("      长半轴:  ");
                builder.Append(pPrjCoodSys.GeographicCoordinateSystem.Datum.Spheroid.SemiMajorAxis.ToString("0.0000000000000000"));
                builder.Append("\r\n");
                builder.Append("      短半轴:  ");
                builder.Append(pPrjCoodSys.GeographicCoordinateSystem.Datum.Spheroid.SemiMinorAxis.ToString("0.0000000000000000"));
                builder.Append("\r\n");
                builder.Append("      扁率倒数:  ");
                builder.Append((1.0 / pPrjCoodSys.GeographicCoordinateSystem.Datum.Spheroid.Flattening).ToString("0.0000000000000000"));
                builder.Append("\r\n");
                return builder.ToString();
            }
            catch (Exception)
            {
                return builder.ToString();
            }
        }

        private bool InitialComProjectionList(IProjectedCoordinateSystem pProjectedCoordinateSystem)
        {
            try
            {
                ISpatialReferenceFactory2 factory = new SpatialReferenceEnvironmentClass();
                this.mProjectionList = new ArrayList();
                IProjectionGEN ngen = null;
                this.comProjectName.Properties.Items.Clear();
                this.comProjectName.Properties.Sorted = true;
                for (int i = 0xa7f9; i < 0xa834; i++)
                {
                    ngen = factory.CreateProjection(i) as IProjectionGEN;
                    this.comProjectName.Properties.Items.Add(ngen.Name);
                    this.mProjectionList.Add(ngen);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private bool InitialComUnitList()
        {
            try
            {
                int num;
                ILinearUnit unit = new LinearUnitClass();
                ISpatialReferenceFactory3 factory = new SpatialReferenceEnvironmentClass();
                IUnit unit2 = null;
                this.mUnitList = new ArrayList();
                this.comUnitName.Properties.Items.Clear();
                this.comUnitName.Properties.Sorted = true;
                for (num = 0x2329; num < 0x239b; num++)
                {
                    try
                    {
                        unit2 = factory.CreateUnit(num);
                        if (unit2.Name != "")
                        {
                            this.comUnitName.Properties.Items.Add(unit2.Name);
                            unit = unit2 as ILinearUnit;
                            this.mUnitList.Add(unit2);
                        }
                    }
                    catch (Exception)
                    {
                    }
                }
                for (num = 0x1a9c9; num < 0x1a9e8; num++)
                {
                    try
                    {
                        unit2 = factory.CreateUnit(num);
                        if (unit2.Name != "")
                        {
                            this.comUnitName.Properties.Items.Add(unit2.Name);
                            unit = unit2 as ILinearUnit;
                            this.mUnitList.Add(unit2);
                        }
                    }
                    catch (Exception)
                    {
                    }
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private void InitializeComponent()
        {
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panel3 = new System.Windows.Forms.Panel();
            this.comProjectName = new DevExpress.XtraEditors.ComboBoxEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.panel7 = new System.Windows.Forms.Panel();
            this.txtperUnit = new DevExpress.XtraEditors.TextEdit();
            this.label4 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.comUnitName = new DevExpress.XtraEditors.ComboBoxEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtCoordinateName = new DevExpress.XtraEditors.TextEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.rtbDetailes = new System.Windows.Forms.RichTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.sButSelect = new DevExpress.XtraEditors.SimpleButton();
            this.sButModify = new DevExpress.XtraEditors.SimpleButton();
            this.sButImport = new DevExpress.XtraEditors.SimpleButton();
            this.sButCancel = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comProjectName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtperUnit.Properties)).BeginInit();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comUnitName.Properties)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCoordinateName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // sButOk
            // 
            this.sButOk.Location = new System.Drawing.Point(301, 619);
            this.sButOk.Visible = true;
            this.sButOk.Click += new System.EventHandler(this.sButOk_Click);
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.xtraTabControl1.Location = new System.Drawing.Point(8, 8);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPage1;
            this.xtraTabControl1.Size = new System.Drawing.Size(441, 603);
            this.xtraTabControl1.TabIndex = 4;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1});
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Controls.Add(this.groupControl1);
            this.xtraTabPage1.Controls.Add(this.panel4);
            this.xtraTabPage1.Controls.Add(this.groupControl2);
            this.xtraTabPage1.Controls.Add(this.panel2);
            this.xtraTabPage1.Controls.Add(this.panel5);
            this.xtraTabPage1.Controls.Add(this.groupControl3);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Padding = new System.Windows.Forms.Padding(6);
            this.xtraTabPage1.Size = new System.Drawing.Size(435, 574);
            this.xtraTabPage1.Text = "普通";
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.gridControl1);
            this.groupControl1.Controls.Add(this.panel3);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(6, 42);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Padding = new System.Windows.Forms.Padding(8);
            this.groupControl1.Size = new System.Drawing.Size(423, 266);
            this.groupControl1.TabIndex = 9;
            this.groupControl1.Text = "投影";
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(10, 66);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(403, 190);
            this.gridControl1.TabIndex = 121;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.OptionsView.ShowIndicator = false;
            this.gridView1.OptionsView.ShowPreviewRowLines = DevExpress.Utils.DefaultBoolean.False;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "参数";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "值";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.comProjectName);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(10, 30);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(0, 4, 0, 8);
            this.panel3.Size = new System.Drawing.Size(403, 36);
            this.panel3.TabIndex = 9;
            // 
            // comProjectName
            // 
            this.comProjectName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comProjectName.Location = new System.Drawing.Point(70, 4);
            this.comProjectName.Name = "comProjectName";
            this.comProjectName.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comProjectName.Size = new System.Drawing.Size(333, 20);
            this.comProjectName.TabIndex = 2;
            this.comProjectName.TextChanged += new System.EventHandler(this.comProjectName_TextChanged);
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Left;
            this.label3.Location = new System.Drawing.Point(0, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 24);
            this.label3.TabIndex = 1;
            this.label3.Text = "名称";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel4
            // 
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(6, 308);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(423, 10);
            this.panel4.TabIndex = 11;
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.panel7);
            this.groupControl2.Controls.Add(this.panel6);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupControl2.Location = new System.Drawing.Point(6, 318);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.groupControl2.Size = new System.Drawing.Size(423, 97);
            this.groupControl2.TabIndex = 10;
            this.groupControl2.Text = "线性单位";
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.txtperUnit);
            this.panel7.Controls.Add(this.label4);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel7.Location = new System.Drawing.Point(10, 56);
            this.panel7.Name = "panel7";
            this.panel7.Padding = new System.Windows.Forms.Padding(0, 4, 0, 8);
            this.panel7.Size = new System.Drawing.Size(403, 36);
            this.panel7.TabIndex = 11;
            // 
            // txtperUnit
            // 
            this.txtperUnit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtperUnit.Enabled = false;
            this.txtperUnit.Location = new System.Drawing.Point(70, 4);
            this.txtperUnit.Name = "txtperUnit";
            this.txtperUnit.Size = new System.Drawing.Size(333, 20);
            this.txtperUnit.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Left;
            this.label4.Location = new System.Drawing.Point(0, 4);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 24);
            this.label4.TabIndex = 1;
            this.label4.Text = "米/单位";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.comUnitName);
            this.panel6.Controls.Add(this.label2);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(10, 22);
            this.panel6.Name = "panel6";
            this.panel6.Padding = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.panel6.Size = new System.Drawing.Size(403, 34);
            this.panel6.TabIndex = 10;
            // 
            // comUnitName
            // 
            this.comUnitName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comUnitName.Location = new System.Drawing.Point(70, 4);
            this.comUnitName.Name = "comUnitName";
            this.comUnitName.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comUnitName.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.comUnitName.Size = new System.Drawing.Size(333, 20);
            this.comUnitName.TabIndex = 2;
            this.comUnitName.SelectedIndexChanged += new System.EventHandler(this.comUnitName_SelectedIndexChanged);
            this.comUnitName.SelectedValueChanged += new System.EventHandler(this.comUnitName_SelectedValueChanged);
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Left;
            this.label2.Location = new System.Drawing.Point(0, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 26);
            this.label2.TabIndex = 1;
            this.label2.Text = "名称";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtCoordinateName);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(6, 6);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(9, 5, 9, 12);
            this.panel2.Size = new System.Drawing.Size(423, 36);
            this.panel2.TabIndex = 8;
            // 
            // txtCoordinateName
            // 
            this.txtCoordinateName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCoordinateName.Enabled = false;
            this.txtCoordinateName.Location = new System.Drawing.Point(79, 5);
            this.txtCoordinateName.Name = "txtCoordinateName";
            this.txtCoordinateName.Size = new System.Drawing.Size(335, 20);
            this.txtCoordinateName.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Location = new System.Drawing.Point(9, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "名称";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel5
            // 
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(6, 415);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(423, 10);
            this.panel5.TabIndex = 13;
            // 
            // groupControl3
            // 
            this.groupControl3.Controls.Add(this.panelControl1);
            this.groupControl3.Controls.Add(this.panel1);
            this.groupControl3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupControl3.Location = new System.Drawing.Point(6, 425);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Padding = new System.Windows.Forms.Padding(8);
            this.groupControl3.Size = new System.Drawing.Size(423, 143);
            this.groupControl3.TabIndex = 12;
            this.groupControl3.Text = "地理坐标系";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.rtbDetailes);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(10, 30);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(324, 103);
            this.panelControl1.TabIndex = 2;
            // 
            // rtbDetailes
            // 
            this.rtbDetailes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbDetailes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbDetailes.Enabled = false;
            this.rtbDetailes.Location = new System.Drawing.Point(2, 2);
            this.rtbDetailes.Name = "rtbDetailes";
            this.rtbDetailes.Size = new System.Drawing.Size(320, 99);
            this.rtbDetailes.TabIndex = 1;
            this.rtbDetailes.Text = "";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.sButSelect);
            this.panel1.Controls.Add(this.sButModify);
            this.panel1.Controls.Add(this.sButImport);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(334, 30);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(79, 103);
            this.panel1.TabIndex = 7;
            // 
            // sButSelect
            // 
            this.sButSelect.Location = new System.Drawing.Point(9, 3);
            this.sButSelect.Name = "sButSelect";
            this.sButSelect.Size = new System.Drawing.Size(70, 28);
            this.sButSelect.TabIndex = 4;
            this.sButSelect.Text = "选择...";
            this.sButSelect.Click += new System.EventHandler(this.sButSelect_Click);
            // 
            // sButModify
            // 
            this.sButModify.Location = new System.Drawing.Point(9, 73);
            this.sButModify.Name = "sButModify";
            this.sButModify.Size = new System.Drawing.Size(70, 28);
            this.sButModify.TabIndex = 6;
            this.sButModify.Text = "修改...";
            this.sButModify.Click += new System.EventHandler(this.sButModify_Click);
            // 
            // sButImport
            // 
            this.sButImport.Location = new System.Drawing.Point(9, 38);
            this.sButImport.Name = "sButImport";
            this.sButImport.Size = new System.Drawing.Size(70, 28);
            this.sButImport.TabIndex = 5;
            this.sButImport.Text = "导入...";
            this.sButImport.Click += new System.EventHandler(this.sButImport_Click);
            // 
            // sButCancel
            // 
            this.sButCancel.Location = new System.Drawing.Point(378, 619);
            this.sButCancel.Name = "sButCancel";
            this.sButCancel.Size = new System.Drawing.Size(70, 28);
            this.sButCancel.TabIndex = 3;
            this.sButCancel.Text = "取消";
            this.sButCancel.Click += new System.EventHandler(this.sButCancel_Click);
            // 
            // FormSetProjectedCoordinateSystem
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(457, 660);
            this.Controls.Add(this.xtraTabControl1);
            this.Controls.Add(this.sButCancel);
            this.LookAndFeel.SkinName = "Blue";
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormSetProjectedCoordinateSystem";
            this.Padding = new System.Windows.Forms.Padding(8);
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "投影坐标系属性";
            this.Controls.SetChildIndex(this.sButCancel, 0);
            this.Controls.SetChildIndex(this.sButOk, 0);
            this.Controls.SetChildIndex(this.xtraTabControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.xtraTabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.comProjectName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtperUnit.Properties)).EndInit();
            this.panel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.comUnitName.Properties)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtCoordinateName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        public void InitialValue(ISpatialReference pSpr)
        {
            try
            {
                if (pSpr != null)
                {
                    this.mSpatialReference = pSpr;
                    this.mTableProjectionValue = new DataTable();
                    this.mTableProjectionValue.Clear();
                    DataColumn column = new DataColumn("参数", typeof(string));
                    this.mTableProjectionValue.Columns.Add(column);
                    column = new DataColumn("值", typeof(string));
                    this.mTableProjectionValue.Columns.Add(column);
                    this.mTableProjectionValue.Rows.Clear();
                    this.gridControl1.DataSource = null;
                    this.gridView1.Columns.Clear();
                    this.gridControl1.DataSource = this.mTableProjectionValue;
                    this.gridView1.RefreshData();
                    this.gridView1.OptionsBehavior.Editable = true;
                    this.gridView1.Columns[0].OptionsColumn.ReadOnly = true;
                    IProjectedCoordinateSystem pProjectedCoordinateSystem = pSpr as IProjectedCoordinateSystem;
                    this.mGeographicCoordinateSystem = pSpr as IGeographicCoordinateSystem;
                    if (this.mGeographicCoordinateSystem == null)
                    {
                        this.mGeographicCoordinateSystem = pProjectedCoordinateSystem.GeographicCoordinateSystem;
                    }
                    if (pProjectedCoordinateSystem != null)
                    {
                        this.txtCoordinateName.Text = pProjectedCoordinateSystem.Name;
                        this.InitialComProjectionList(pProjectedCoordinateSystem);
                        this.comUnitName.Text = pProjectedCoordinateSystem.CoordinateUnit.Name;
                        this.txtperUnit.Text = pProjectedCoordinateSystem.CoordinateUnit.MetersPerUnit.ToString("0.000000");
                        this.InitialComUnitList();
                        IProjection projection = pProjectedCoordinateSystem.Projection;
                        this.comProjectName.Text = projection.Name;
                        this.ReadProjectionValue(pProjectedCoordinateSystem);
                        this.mGeographicCoordinateSystem = pProjectedCoordinateSystem.GeographicCoordinateSystem;
                        this.rtbDetailes.Text = this.GetGeoCoordSysDetails(this.mGeographicCoordinateSystem);
                    }
                    else if (this.mGeographicCoordinateSystem != null)
                    {
                    }
                    this.rtbDetailes.Enabled = true;
                    this.txtCoordinateName.Enabled = true;
                }
            }
            catch (Exception)
            {
            }
        }

        private bool ReadProjectionValue(IProjectedCoordinateSystem pProjectedCoordinateSystem)
        {
            try
            {
                IParameter[] defaultParameters;
                IProjectionGEN ngen;
                DataRow row;
                int num2;
                if (pProjectedCoordinateSystem != null)
                {
                    IProjectedCoordinateSystem5 system = pProjectedCoordinateSystem as IProjectedCoordinateSystem5;
                    defaultParameters = null;
                    ngen = null;
                    this.mTableProjectionValue.Rows.Clear();
                    double falseEasting = 0.0;
                    row = null;
                    for (num2 = 0; num2 < this.mProjectionList.Count; num2++)
                    {
                        ngen = this.mProjectionList[num2] as IProjectionGEN;
                        if (ngen.Name == this.comProjectName.Text)
                        {
                            defaultParameters = ngen.GetDefaultParameters();
                            break;
                        }
                    }
                    try
                    {
                        falseEasting = system.FalseEasting;
                        row = this.mTableProjectionValue.NewRow();
                        row[0] = "False_Easting";
                        row[1] = falseEasting.ToString("0.0000000000000000");
                        this.mTableProjectionValue.Rows.Add(row);
                    }
                    catch (Exception)
                    {
                    }
                    try
                    {
                        falseEasting = system.FalseNorthing;
                        row = this.mTableProjectionValue.NewRow();
                        row[0] = "False_Northing";
                        row[1] = falseEasting.ToString("0.0000000000000000");
                        this.mTableProjectionValue.Rows.Add(row);
                    }
                    catch (Exception)
                    {
                    }
                    try
                    {
                        falseEasting = system.Azimuth;
                        row = this.mTableProjectionValue.NewRow();
                        row[0] = "Azimuth";
                        row[1] = falseEasting.ToString("0.0000000000000000");
                        this.mTableProjectionValue.Rows.Add(row);
                    }
                    catch (Exception)
                    {
                    }
                    try
                    {
                        falseEasting = system.get_CentralMeridian(true);
                        row = this.mTableProjectionValue.NewRow();
                        row[0] = "Central_Meridian";
                        row[1] = falseEasting.ToString("0.0000000000000000");
                        this.mTableProjectionValue.Rows.Add(row);
                    }
                    catch (Exception)
                    {
                    }
                    try
                    {
                        falseEasting = system.CentralParallel;
                        row = this.mTableProjectionValue.NewRow();
                        row[0] = "Central_Parallel";
                        row[1] = falseEasting.ToString("0.0000000000000000");
                        this.mTableProjectionValue.Rows.Add(row);
                    }
                    catch (Exception)
                    {
                    }
                    try
                    {
                        falseEasting = system.LatitudeOf1st;
                        row = this.mTableProjectionValue.NewRow();
                        row[0] = "Latitude_Of_1st";
                        row[1] = falseEasting.ToString("0.0000000000000000");
                        this.mTableProjectionValue.Rows.Add(row);
                    }
                    catch (Exception)
                    {
                    }
                    try
                    {
                        falseEasting = system.LatitudeOf2nd;
                        row = this.mTableProjectionValue.NewRow();
                        row[0] = "Latitude_Of_2nd";
                        row[1] = falseEasting.ToString("0.0000000000000000");
                        this.mTableProjectionValue.Rows.Add(row);
                    }
                    catch (Exception)
                    {
                    }
                    try
                    {
                        falseEasting = system.LatitudeOfCenter;
                        row = this.mTableProjectionValue.NewRow();
                        row[0] = "Latitude_Of_Center";
                        row[1] = falseEasting.ToString("0.0000000000000000");
                        this.mTableProjectionValue.Rows.Add(row);
                    }
                    catch (Exception)
                    {
                    }
                    try
                    {
                        falseEasting = system.LatitudeOfOrigin;
                        row = this.mTableProjectionValue.NewRow();
                        row[0] = "Latitude_Of_Origin";
                        row[1] = falseEasting.ToString("0.0000000000000000");
                        this.mTableProjectionValue.Rows.Add(row);
                    }
                    catch (Exception)
                    {
                    }
                    try
                    {
                        falseEasting = system.LongitudeOf1st;
                        row = this.mTableProjectionValue.NewRow();
                        row[0] = "Longitude_Of_1st";
                        row[1] = falseEasting.ToString("0.0000000000000000");
                        this.mTableProjectionValue.Rows.Add(row);
                    }
                    catch (Exception)
                    {
                    }
                    try
                    {
                        falseEasting = system.LongitudeOf2nd;
                        row = this.mTableProjectionValue.NewRow();
                        row[0] = "Longitude_Of_2nd";
                        row[1] = falseEasting.ToString("0.0000000000000000");
                        this.mTableProjectionValue.Rows.Add(row);
                    }
                    catch (Exception)
                    {
                    }
                    try
                    {
                        falseEasting = system.LongitudeOfCenter;
                        row = this.mTableProjectionValue.NewRow();
                        row[0] = "Longitude_Of_Center";
                        row[1] = falseEasting.ToString("0.0000000000000000");
                        this.mTableProjectionValue.Rows.Add(row);
                    }
                    catch (Exception)
                    {
                    }
                    try
                    {
                        falseEasting = system.LongitudeOfOrigin;
                        row = this.mTableProjectionValue.NewRow();
                        row[0] = "Longitude_Of_Origin";
                        row[1] = falseEasting.ToString("0.0000000000000000");
                        this.mTableProjectionValue.Rows.Add(row);
                    }
                    catch (Exception)
                    {
                    }
                    try
                    {
                        falseEasting = system.PseudoStandardParallel1;
                        row = this.mTableProjectionValue.NewRow();
                        row[0] = "Pseudo_Standard_Parallel1";
                        row[1] = falseEasting.ToString("0.0000000000000000");
                        this.mTableProjectionValue.Rows.Add(row);
                    }
                    catch (Exception)
                    {
                    }
                    try
                    {
                        falseEasting = system.ScaleFactor;
                        row = this.mTableProjectionValue.NewRow();
                        row[0] = "Scale_Factor";
                        row[1] = falseEasting.ToString("0.0000000000000000");
                        this.mTableProjectionValue.Rows.Add(row);
                    }
                    catch (Exception)
                    {
                    }
                    try
                    {
                        falseEasting = system.StandardParallel1;
                        row = this.mTableProjectionValue.NewRow();
                        row[0] = "Standard_Parallel_1";
                        row[1] = falseEasting.ToString("0.0000000000000000");
                        this.mTableProjectionValue.Rows.Add(row);
                    }
                    catch (Exception)
                    {
                    }
                    try
                    {
                        falseEasting = system.StandardParallel2;
                        row = this.mTableProjectionValue.NewRow();
                        row[0] = "Standard_Parallel_2";
                        row[1] = falseEasting.ToString("0.0000000000000000");
                        this.mTableProjectionValue.Rows.Add(row);
                    }
                    catch (Exception)
                    {
                    }
                    try
                    {
                        falseEasting = system.XScaleFactor;
                        row = this.mTableProjectionValue.NewRow();
                        row[0] = "X_Scale";
                        row[1] = falseEasting.ToString("0.0000000000000000");
                        this.mTableProjectionValue.Rows.Add(row);
                    }
                    catch (Exception)
                    {
                    }
                    try
                    {
                        falseEasting = system.YScaleFactor;
                        row = this.mTableProjectionValue.NewRow();
                        row[0] = "Y_Scale";
                        row[1] = falseEasting.ToString("0.0000000000000000");
                        this.mTableProjectionValue.Rows.Add(row);
                    }
                    catch (Exception)
                    {
                    }
                    try
                    {
                        falseEasting = system.Rotation;
                        row = this.mTableProjectionValue.NewRow();
                        row[0] = "XY_Plane_Rotation";
                        row[1] = falseEasting.ToString("0.0000000000000000");
                        this.mTableProjectionValue.Rows.Add(row);
                    }
                    catch (Exception)
                    {
                    }
                    this.gridControl1.DataSource = null;
                    this.gridView1.Columns.Clear();
                    this.gridControl1.DataSource = this.mTableProjectionValue;
                    this.gridView1.RefreshData();
                    this.gridView1.OptionsBehavior.Editable = true;
                    this.gridView1.Columns[0].OptionsColumn.ReadOnly = true;
                    return true;
                }
                if (this.mProjectionList == null)
                {
                    return false;
                }
                ngen = null;
                this.mTableProjectionValue.Rows.Clear();
                this.gridControl1.DataSource = null;
                this.gridView1.Columns.Clear();
                this.gridControl1.DataSource = this.mTableProjectionValue;
                this.gridView1.RefreshData();
                row = null;
                for (num2 = 0; num2 < this.mProjectionList.Count; num2++)
                {
                    ngen = this.mProjectionList[num2] as IProjectionGEN;
                    if (ngen.Name == this.comProjectName.Text)
                    {
                        defaultParameters = ngen.GetDefaultParameters();
                        for (int i = 0; i < defaultParameters.Length; i++)
                        {
                            row = this.mTableProjectionValue.NewRow();
                            row[0] = defaultParameters[i].Name;
                            row[1] = defaultParameters[i].Value.ToString("0.0000000000000000");
                            this.mTableProjectionValue.Rows.Add(row);
                        }
                        break;
                    }
                }
                this.gridControl1.DataSource = null;
                this.gridView1.Columns.Clear();
                this.gridControl1.DataSource = this.mTableProjectionValue;
                this.gridView1.RefreshData();
                this.gridView1.OptionsBehavior.Editable = true;
                this.gridView1.Columns[0].OptionsColumn.ReadOnly = true;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private void sButCancel_Click(object sender, EventArgs e)
        {
            this.FlagOk = false;
            base.Hide();
        }

        private void sButImport_Click(object sender, EventArgs e)
        {
            try
            {
                IGxObjectFilter filter = new GxFilterDatasetsClass();
                IGxDialog dialog = new GxDialogClass();
                dialog.AllowMultiSelect = false;
                dialog.Title = "选择数据";
                dialog.ObjectFilter = filter;
                IEnumGxObject selection = null;
                IGxObject obj3 = null;
                string fileName = "";
                string name = "";
                if (dialog.DoModalOpen((int) base.Handle, out selection) && (selection != null))
                {
                    IProjectedCoordinateSystem mSpatialReference;
                    IGeographicCoordinateSystem geographicCoordinateSystem;
                    obj3 = selection.Next();
                    fileName = Directory.GetParent(obj3.FullName).ToString();
                    name = obj3.BaseName;
                    IWorkspace workspace = null;
                    IFeatureWorkspace workspace2 = null;
                    IRasterWorkspace workspace3 = null;
                    IWorkspaceFactory2 factory = null;
                    IGeoDataset dataset = null;
                    IRasterDataset dataset2 = null;
                    if (fileName.Contains(".mdb"))
                    {
                        factory = new AccessWorkspaceFactoryClass();
                        workspace = factory.OpenFromFile(fileName, 0);
                        if (obj3.Category == "Personal Geodatabase Feature Class")
                        {
                            workspace2 = workspace as IFeatureWorkspace;
                            dataset = workspace2.OpenFeatureClass(name) as IGeoDataset;
                            this.mSpatialReference = dataset.SpatialReference;
                            mSpatialReference = this.mSpatialReference as IProjectedCoordinateSystem;
                            geographicCoordinateSystem = this.mSpatialReference as IGeographicCoordinateSystem;
                            if (geographicCoordinateSystem == null)
                            {
                                geographicCoordinateSystem = mSpatialReference.GeographicCoordinateSystem;
                            }
                            if (geographicCoordinateSystem != null)
                            {
                                this.rtbDetailes.Text = this.GetGeoCoordSysDetails(geographicCoordinateSystem);
                                this.txtCoordinateName.Text = geographicCoordinateSystem.Name;
                            }
                        }
                        else if (obj3.Category == "Personal Geodatabase Raster Dataset")
                        {
                            IEnumDataset dataset3 = workspace.get_Datasets(esriDatasetType.esriDTRasterDataset);
                            for (IDataset dataset4 = dataset3.Next(); dataset4 != null; dataset4 = dataset3.Next())
                            {
                                if (dataset4.Name == name)
                                {
                                    dataset2 = dataset4 as IRasterDataset;
                                    break;
                                }
                            }
                            if (dataset2 != null)
                            {
                                dataset = dataset2 as IGeoDataset;
                                this.mSpatialReference = dataset.SpatialReference;
                                mSpatialReference = this.mSpatialReference as IProjectedCoordinateSystem;
                                geographicCoordinateSystem = this.mSpatialReference as IGeographicCoordinateSystem;
                                if (geographicCoordinateSystem == null)
                                {
                                    geographicCoordinateSystem = mSpatialReference.GeographicCoordinateSystem;
                                }
                                if (geographicCoordinateSystem != null)
                                {
                                    this.rtbDetailes.Text = this.GetGeoCoordSysDetails(geographicCoordinateSystem);
                                    this.txtCoordinateName.Text = geographicCoordinateSystem.Name;
                                }
                            }
                        }
                    }
                    else if (obj3.FullName.Contains(".tif"))
                    {
                        factory = new RasterWorkspaceFactoryClass();
                        workspace = factory.OpenFromFile(fileName, 0);
                        if (obj3.Category == "Raster Dataset")
                        {
                            workspace3 = workspace as IRasterWorkspace;
                            dataset = workspace3.OpenRasterDataset(name + ".tif") as IGeoDataset;
                            this.mSpatialReference = dataset.SpatialReference;
                            mSpatialReference = this.mSpatialReference as IProjectedCoordinateSystem;
                            geographicCoordinateSystem = this.mSpatialReference as IGeographicCoordinateSystem;
                            if (geographicCoordinateSystem == null)
                            {
                                geographicCoordinateSystem = mSpatialReference.GeographicCoordinateSystem;
                            }
                            if (geographicCoordinateSystem != null)
                            {
                                this.rtbDetailes.Text = this.GetGeoCoordSysDetails(geographicCoordinateSystem);
                                this.txtCoordinateName.Text = geographicCoordinateSystem.Name;
                            }
                        }
                    }
                    else if (obj3.Category == "Raster Dataset")
                    {
                        factory = new RasterWorkspaceFactoryClass();
                        workspace3 = factory.OpenFromFile(fileName, 0) as IRasterWorkspace;
                        dataset = workspace3.OpenRasterDataset(name) as IGeoDataset;
                        this.mSpatialReference = dataset.SpatialReference;
                        mSpatialReference = this.mSpatialReference as IProjectedCoordinateSystem;
                        geographicCoordinateSystem = this.mSpatialReference as IGeographicCoordinateSystem;
                        if (geographicCoordinateSystem == null)
                        {
                            geographicCoordinateSystem = mSpatialReference.GeographicCoordinateSystem;
                        }
                        if (geographicCoordinateSystem != null)
                        {
                            this.rtbDetailes.Text = this.GetGeoCoordSysDetails(geographicCoordinateSystem);
                            this.txtCoordinateName.Text = geographicCoordinateSystem.Name;
                        }
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        private void sButModify_Click(object sender, EventArgs e)
        {
            if (this.mFormSetGeographic == null)
            {
                this.mFormSetGeographic = new FormSetGeographicCoordinateSystem();
            }
            this.mFormSetGeographic.InitialValue(this.mGeographicCoordinateSystem);
            this.mFormSetGeographic.ShowDialog();
            if (this.mFormSetGeographic.FlagOk)
            {
                this.mGeographicCoordinateSystem = this.mFormSetGeographic.SetGeographicValue();
                this.rtbDetailes.Text = this.GetGeoCoordSysDetails(this.mGeographicCoordinateSystem);
            }
            this.mFormSetGeographic.Close();
            this.mFormSetGeographic = null;
        }

        private void sButOk_Click(object sender, EventArgs e)
        {
            this.FlagOk = true;
            base.Hide();
        }

        private unsafe void sButSelect_Click(object sender, EventArgs e)
        {
            try
            {
                IGxObjectFilter filter = new GxFilterVerticalCoordinateSystemsClass();
                IGxDialog dialog = new GxDialogClass();
                dialog.AllowMultiSelect = false;
                dialog.Title = "选择坐标系文件";
                dialog.ObjectFilter = filter;
                string configValue = UtilFactory.GetConfigOpt().GetConfigValue("AppPath");
                string str2 = UtilFactory.GetConfigOpt().GetConfigValue("ProjectFilePath");
                object obj2 = configValue + @"\" + str2;
                dialog.set_StartingLocation(ref obj2);
                IEnumGxObject selection = null;
                IGxObject obj4 = null;
                string str3 = "";
                string baseName = "";
                if (dialog.DoModalOpen((int) base.Handle, out selection) && (selection != null))
                {
                    obj4 = selection.Next();
                    str3 = Directory.GetParent(obj4.FullName).ToString();
                    baseName = obj4.BaseName;
                    ISpatialReferenceFactory factory = new SpatialReferenceEnvironmentClass();
                    ISpatialReference reference = factory.CreateESRISpatialReferenceFromPRJFile(obj4.FullName);
                    if (!((reference != null) && (reference is IGeographicCoordinateSystem)))
                    {
                        MessageBox.Show("选择的地理坐标系统文件不正确，请重新选择！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else
                    {
                        this.mSpatialReference = reference;
                        IGeographicCoordinateSystem mSpatialReference = this.mSpatialReference as IGeographicCoordinateSystem;
                        if (mSpatialReference != null)
                        {
                            this.rtbDetailes.Text = this.GetGeoCoordSysDetails(mSpatialReference);
                            this.txtCoordinateName.Text = mSpatialReference.Name;
                        }
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        public IProjectedCoordinateSystem SetProjectionValue()
        {
            try
            {
                int num;
                IProjectedCoordinateSystem mSpatialReference = this.mSpatialReference as IProjectedCoordinateSystem;
                IProjectedCoordinateSystem5 system2 = mSpatialReference as IProjectedCoordinateSystem5;
                IUnit unit = null;
                ILinearUnit coordinateUnit = null;
                IProjectedCoordinateSystemEdit edit = mSpatialReference as IProjectedCoordinateSystemEdit;
                for (num = 0; num < this.mUnitList.Count; num++)
                {
                    unit = this.mUnitList[num] as IUnit;
                    coordinateUnit = system2.CoordinateUnit;
                    if (unit.Name == this.comUnitName.Text)
                    {
                        coordinateUnit = unit as ILinearUnit;
                        break;
                    }
                }
                IProjectionGEN ngen = null;
                for (num = 0; num < this.mProjectionList.Count; num++)
                {
                    ngen = this.mProjectionList[num] as IProjectionGEN;
                    if (ngen.Name == this.comProjectName.Text)
                    {
                        break;
                    }
                }
                object text = this.txtCoordinateName.Text;
                object projectedUnit = coordinateUnit;
                object missing = System.Type.Missing;
                object mGeographicCoordinateSystem = this.mGeographicCoordinateSystem;
                object projection = ngen as IProjection;
                edit.Define(ref text, ref missing, ref missing, ref missing, ref missing, ref mGeographicCoordinateSystem, ref projectedUnit, ref projection, ref missing);
                system2 = mSpatialReference as IProjectedCoordinateSystem5;
                double centralMeridian = 0.0;
                try
                {
                    for (num = 0; num < this.mTableProjectionValue.Rows.Count; num++)
                    {
                        if (this.mTableProjectionValue.Rows[num][0] == "False_Easting")
                        {
                            string s = this.mTableProjectionValue.Rows[num][1].ToString();
                            system2.FalseEasting = double.Parse(s);
                        }
                    }
                }
                catch (Exception)
                {
                }
                try
                {
                    for (num = 0; num < this.mTableProjectionValue.Rows.Count; num++)
                    {
                        if (this.mTableProjectionValue.Rows[num][0] == "False_Northing")
                        {
                            centralMeridian = double.Parse(this.mTableProjectionValue.Rows[num][1].ToString());
                            system2.FalseNorthing = centralMeridian;
                        }
                    }
                }
                catch (Exception)
                {
                }
                try
                {
                    for (num = 0; num < this.mTableProjectionValue.Rows.Count; num++)
                    {
                        if (this.mTableProjectionValue.Rows[num][0] == "Azimuth")
                        {
                            centralMeridian = double.Parse(this.mTableProjectionValue.Rows[num][1].ToString());
                            system2.Azimuth = centralMeridian;
                        }
                    }
                }
                catch (Exception)
                {
                }
                try
                {
                    for (num = 0; num < this.mTableProjectionValue.Rows.Count; num++)
                    {
                        if (this.mTableProjectionValue.Rows[num][0] == "Central_Meridian")
                        {
                            centralMeridian = double.Parse(this.mTableProjectionValue.Rows[num][1].ToString());
                            system2.set_CentralMeridian(true, centralMeridian);
                        }
                    }
                }
                catch (Exception)
                {
                }
                try
                {
                    for (num = 0; num < this.mTableProjectionValue.Rows.Count; num++)
                    {
                        if (this.mTableProjectionValue.Rows[num][0] == "Central_Parallel")
                        {
                            centralMeridian = double.Parse(this.mTableProjectionValue.Rows[num][1].ToString());
                            system2.CentralParallel = centralMeridian;
                        }
                    }
                }
                catch (Exception)
                {
                }
                try
                {
                    for (num = 0; num < this.mTableProjectionValue.Rows.Count; num++)
                    {
                        if (this.mTableProjectionValue.Rows[num][0] == "Latitude_Of_1st")
                        {
                            centralMeridian = double.Parse(this.mTableProjectionValue.Rows[num][1].ToString());
                            system2.LatitudeOf1st = centralMeridian;
                        }
                    }
                }
                catch (Exception)
                {
                }
                try
                {
                    for (num = 0; num < this.mTableProjectionValue.Rows.Count; num++)
                    {
                        if (this.mTableProjectionValue.Rows[num][0] == "Latitude_Of_2nd")
                        {
                            centralMeridian = double.Parse(this.mTableProjectionValue.Rows[num][1].ToString());
                            system2.LatitudeOf2nd = centralMeridian;
                        }
                    }
                }
                catch (Exception)
                {
                }
                try
                {
                    for (num = 0; num < this.mTableProjectionValue.Rows.Count; num++)
                    {
                        if (this.mTableProjectionValue.Rows[num][0] == "Latitude_Of_Center")
                        {
                            centralMeridian = double.Parse(this.mTableProjectionValue.Rows[num][1].ToString());
                            system2.LatitudeOfCenter = centralMeridian;
                        }
                    }
                }
                catch (Exception)
                {
                }
                try
                {
                    for (num = 0; num < this.mTableProjectionValue.Rows.Count; num++)
                    {
                        if (this.mTableProjectionValue.Rows[num][0] == "Latitude_Of_Origin")
                        {
                            centralMeridian = double.Parse(this.mTableProjectionValue.Rows[num][1].ToString());
                            system2.LatitudeOfOrigin = centralMeridian;
                        }
                    }
                }
                catch (Exception)
                {
                }
                try
                {
                    for (num = 0; num < this.mTableProjectionValue.Rows.Count; num++)
                    {
                        if (this.mTableProjectionValue.Rows[num][0] == "Longitude_Of_1st")
                        {
                            centralMeridian = double.Parse(this.mTableProjectionValue.Rows[num][1].ToString());
                            system2.LongitudeOf1st = centralMeridian;
                        }
                    }
                }
                catch (Exception)
                {
                }
                try
                {
                    for (num = 0; num < this.mTableProjectionValue.Rows.Count; num++)
                    {
                        if (this.mTableProjectionValue.Rows[num][0] == "Longitude_Of_2nd")
                        {
                            centralMeridian = double.Parse(this.mTableProjectionValue.Rows[num][1].ToString());
                            system2.LongitudeOf2nd = centralMeridian;
                        }
                    }
                }
                catch (Exception)
                {
                }
                try
                {
                    for (num = 0; num < this.mTableProjectionValue.Rows.Count; num++)
                    {
                        if (this.mTableProjectionValue.Rows[num][0] == "Longitude_Of_Center")
                        {
                            centralMeridian = double.Parse(this.mTableProjectionValue.Rows[num][1].ToString());
                            system2.LongitudeOfCenter = centralMeridian;
                        }
                    }
                }
                catch (Exception)
                {
                }
                try
                {
                    for (num = 0; num < this.mTableProjectionValue.Rows.Count; num++)
                    {
                        if (this.mTableProjectionValue.Rows[num][0] == "Longitude_Of_Origin")
                        {
                            centralMeridian = double.Parse(this.mTableProjectionValue.Rows[num][1].ToString());
                            system2.LongitudeOfOrigin = centralMeridian;
                        }
                    }
                }
                catch (Exception)
                {
                }
                try
                {
                    for (num = 0; num < this.mTableProjectionValue.Rows.Count; num++)
                    {
                        if (this.mTableProjectionValue.Rows[num][0] == "Pseudo_Standard_Parallel1")
                        {
                            centralMeridian = double.Parse(this.mTableProjectionValue.Rows[num][1].ToString());
                            system2.PseudoStandardParallel1 = centralMeridian;
                        }
                    }
                }
                catch (Exception)
                {
                }
                try
                {
                    for (num = 0; num < this.mTableProjectionValue.Rows.Count; num++)
                    {
                        if (this.mTableProjectionValue.Rows[num][0] == "Scale_Factor")
                        {
                            centralMeridian = double.Parse(this.mTableProjectionValue.Rows[num][1].ToString());
                            system2.ScaleFactor = centralMeridian;
                        }
                    }
                }
                catch (Exception)
                {
                }
                try
                {
                    for (num = 0; num < this.mTableProjectionValue.Rows.Count; num++)
                    {
                        if (this.mTableProjectionValue.Rows[num][0] == "Standard_Parallel_1")
                        {
                            centralMeridian = double.Parse(this.mTableProjectionValue.Rows[num][1].ToString());
                            system2.StandardParallel1 = centralMeridian;
                        }
                    }
                }
                catch (Exception)
                {
                }
                try
                {
                    for (num = 0; num < this.mTableProjectionValue.Rows.Count; num++)
                    {
                        if (this.mTableProjectionValue.Rows[num][0] == "Standard_Parallel_2")
                        {
                            centralMeridian = double.Parse(this.mTableProjectionValue.Rows[num][1].ToString());
                            system2.StandardParallel2 = centralMeridian;
                        }
                    }
                }
                catch (Exception)
                {
                }
                try
                {
                    for (num = 0; num < this.mTableProjectionValue.Rows.Count; num++)
                    {
                        if (this.mTableProjectionValue.Rows[num][0] == "X_Scale")
                        {
                            centralMeridian = double.Parse(this.mTableProjectionValue.Rows[num][1].ToString());
                            system2.XScaleFactor = centralMeridian;
                        }
                    }
                }
                catch (Exception)
                {
                }
                try
                {
                    for (num = 0; num < this.mTableProjectionValue.Rows.Count; num++)
                    {
                        if (this.mTableProjectionValue.Rows[num][0] == "Y_Scale")
                        {
                            centralMeridian = double.Parse(this.mTableProjectionValue.Rows[num][1].ToString());
                            system2.YScaleFactor = centralMeridian;
                        }
                    }
                }
                catch (Exception)
                {
                }
                try
                {
                    for (num = 0; num < this.mTableProjectionValue.Rows.Count; num++)
                    {
                        if (this.mTableProjectionValue.Rows[num][0] == "XY_Plane_Rotation")
                        {
                            centralMeridian = double.Parse(this.mTableProjectionValue.Rows[num][1].ToString());
                            system2.Rotation = centralMeridian;
                        }
                    }
                }
                catch (Exception)
                {
                }
                return mSpatialReference;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}

