namespace DataEdit
{
    using DevExpress.XtraEditors;
    using DevExpress.XtraTab;
    using ESRI.ArcGIS.Catalog;
    using ESRI.ArcGIS.CatalogUI;
    using ESRI.ArcGIS.DataSourcesGDB;
    using ESRI.ArcGIS.DataSourcesRaster;
    using ESRI.ArcGIS.Geodatabase;
    using ESRI.ArcGIS.Geometry;
    using FormBase;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.IO;
    using System.Text;
    using System.Windows.Forms;
    using Utilities;

    public class FormSetSpatialreference : FormBase2
    {
        private IContainer components = null;
        public bool FlagOk = false;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private FormSetGeographicCoordinateSystem mformSetGeographic = null;
        private FormSetProjectedCoordinateSystem mformSetProjected = null;
        private IGeographicCoordinateSystem mGeographicCoordinateSystem = null;
        private IProjectedCoordinateSystem mProjectedCoordinateSystem = null;
        private ISpatialReference mSpatialReference = null;
        private Panel panel1;
        private PanelControl panelControl1;
        private RichTextBox rtbDetailes;
        private SimpleButton sButCancel;
        private SimpleButton sButImport;
        private SimpleButton sButModify;
        private SimpleButton sButSelect;
        private TextEdit txtCoordinateName;
        private XtraTabControl xtraTabControl1;
        private XtraTabPage xtraTabPage1;

        public FormSetSpatialreference()
        {
            this.InitializeComponent();
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
            double scaleFactor = 0.0;
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
                try
                {
                    scaleFactor = pPrjCoodSys.get_CentralMeridian(true);
                    builder.Append("\r\n");
                    builder.Append("中央子午线: ");
                    builder.Append(scaleFactor.ToString("0.000000"));
                }
                catch (Exception)
                {
                }
                try
                {
                    scaleFactor = pPrjCoodSys.ScaleFactor;
                    builder.Append("\r\n");
                    builder.Append("比例因子: ");
                    builder.Append(scaleFactor.ToString("0.000000"));
                }
                catch (Exception)
                {
                }
                builder.Append("\r\n");
                builder.Append("经纬度原点: ");
                try
                {
                    scaleFactor = pPrjCoodSys.LongitudeOfOrigin;
                }
                catch (Exception)
                {
                    scaleFactor = 0.0;
                }
                builder.Append(scaleFactor.ToString("0.000000"));
                try
                {
                    ILinearUnit unit = pPrjCoodSys.CoordinateUnit;
                    builder.Append("\r\n");
                    builder.Append("坐标单位: ");
                    builder.Append(pPrjCoodSys.CoordinateUnit.Name);
                    builder.Append("(" + unit.MetersPerUnit.ToString("0.000000") + ")");
                }
                catch (Exception)
                {
                }
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

        private void InitializeComponent()
        {
            this.sButCancel = new DevExpress.XtraEditors.SimpleButton();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.rtbDetailes = new System.Windows.Forms.RichTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.sButSelect = new DevExpress.XtraEditors.SimpleButton();
            this.sButModify = new DevExpress.XtraEditors.SimpleButton();
            this.sButImport = new DevExpress.XtraEditors.SimpleButton();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCoordinateName = new DevExpress.XtraEditors.TextEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCoordinateName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // sButOk
            // 
            this.sButOk.Location = new System.Drawing.Point(318, 503);
            this.sButOk.Visible = true;
            this.sButOk.Click += new System.EventHandler(this.sButOk_Click);
            // 
            // sButCancel
            // 
            this.sButCancel.Location = new System.Drawing.Point(395, 503);
            this.sButCancel.Name = "sButCancel";
            this.sButCancel.Size = new System.Drawing.Size(70, 28);
            this.sButCancel.TabIndex = 1;
            this.sButCancel.Text = "取消";
            this.sButCancel.Click += new System.EventHandler(this.sButCancel_Click);
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Controls.Add(this.panelControl1);
            this.xtraTabPage1.Controls.Add(this.panel1);
            this.xtraTabPage1.Controls.Add(this.label2);
            this.xtraTabPage1.Controls.Add(this.txtCoordinateName);
            this.xtraTabPage1.Controls.Add(this.label1);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Padding = new System.Windows.Forms.Padding(9, 9, 9, 9);
            this.xtraTabPage1.Size = new System.Drawing.Size(451, 452);
            this.xtraTabPage1.Text = "坐标系统";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.rtbDetailes);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(9, 76);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(433, 255);
            this.panelControl1.TabIndex = 2;
            // 
            // rtbDetailes
            // 
            this.rtbDetailes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbDetailes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbDetailes.Enabled = false;
            this.rtbDetailes.Location = new System.Drawing.Point(2, 2);
            this.rtbDetailes.Name = "rtbDetailes";
            this.rtbDetailes.Size = new System.Drawing.Size(429, 251);
            this.rtbDetailes.TabIndex = 1;
            this.rtbDetailes.Text = "";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.sButSelect);
            this.panel1.Controls.Add(this.sButModify);
            this.panel1.Controls.Add(this.sButImport);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(9, 331);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(433, 112);
            this.panel1.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(82, 89);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(163, 14);
            this.label5.TabIndex = 9;
            this.label5.Text = "编辑修改当前坐标系属性信息";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(82, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(223, 14);
            this.label3.TabIndex = 8;
            this.label3.Text = "导入已有坐标系的数据，获取其坐标系统";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(82, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(151, 14);
            this.label4.TabIndex = 7;
            this.label4.Text = "选择一个已定义的坐标系统";
            // 
            // sButSelect
            // 
            this.sButSelect.Location = new System.Drawing.Point(0, 14);
            this.sButSelect.Name = "sButSelect";
            this.sButSelect.Size = new System.Drawing.Size(70, 28);
            this.sButSelect.TabIndex = 4;
            this.sButSelect.Text = "选择...";
            this.sButSelect.Click += new System.EventHandler(this.sButSelect_Click);
            // 
            // sButModify
            // 
            this.sButModify.Location = new System.Drawing.Point(0, 84);
            this.sButModify.Name = "sButModify";
            this.sButModify.Size = new System.Drawing.Size(70, 28);
            this.sButModify.TabIndex = 6;
            this.sButModify.Text = "修改...";
            this.sButModify.Click += new System.EventHandler(this.sButModify_Click);
            // 
            // sButImport
            // 
            this.sButImport.Location = new System.Drawing.Point(0, 49);
            this.sButImport.Name = "sButImport";
            this.sButImport.Size = new System.Drawing.Size(70, 28);
            this.sButImport.TabIndex = 5;
            this.sButImport.Text = "导入...";
            this.sButImport.Click += new System.EventHandler(this.sButImport_Click);
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Location = new System.Drawing.Point(9, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(433, 26);
            this.label2.TabIndex = 3;
            this.label2.Text = "详细信息";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtCoordinateName
            // 
            this.txtCoordinateName.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtCoordinateName.Enabled = false;
            this.txtCoordinateName.Location = new System.Drawing.Point(9, 30);
            this.txtCoordinateName.Name = "txtCoordinateName";
            this.txtCoordinateName.Size = new System.Drawing.Size(433, 20);
            this.txtCoordinateName.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(433, 21);
            this.label1.TabIndex = 1;
            this.label1.Text = "名称";
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.xtraTabControl1.Location = new System.Drawing.Point(9, 9);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPage1;
            this.xtraTabControl1.Size = new System.Drawing.Size(457, 481);
            this.xtraTabControl1.TabIndex = 2;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1});
            // 
            // FormSetSpatialreference
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(475, 544);
            this.Controls.Add(this.xtraTabControl1);
            this.Controls.Add(this.sButCancel);
            this.LookAndFeel.SkinName = "Blue";
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormSetSpatialreference";
            this.Padding = new System.Windows.Forms.Padding(9, 9, 9, 9);
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "空间参考属性";
            this.Controls.SetChildIndex(this.sButCancel, 0);
            this.Controls.SetChildIndex(this.xtraTabControl1, 0);
            this.Controls.SetChildIndex(this.sButOk, 0);
            this.xtraTabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCoordinateName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        public void InitialValue(ISpatialReference pSpr)
        {
            try
            {
                if (pSpr != null)
                {
                    this.mSpatialReference = pSpr;
                    IProjectedCoordinateSystem pPrjCoodSys = pSpr as IProjectedCoordinateSystem;
                    IGeographicCoordinateSystem pGeoCoordSys = pSpr as IGeographicCoordinateSystem;
                    if (pPrjCoodSys != null)
                    {
                        this.txtCoordinateName.Text = pPrjCoodSys.Name;
                        this.rtbDetailes.Text = this.GetPrjCoordDetails(pPrjCoodSys);
                    }
                    else if (pGeoCoordSys != null)
                    {
                        this.txtCoordinateName.Text = pGeoCoordSys.Name;
                        this.rtbDetailes.Text = this.GetGeoCoordSysDetails(pGeoCoordSys);
                    }
                    this.rtbDetailes.Enabled = true;
                    this.txtCoordinateName.Enabled = true;
                }
            }
            catch (Exception)
            {
            }
        }

        private void sButCancel_Click(object sender, EventArgs e)
        {
            if (this.mformSetProjected != null)
            {
                this.mformSetProjected.Close();
                this.mformSetProjected = null;
            }
            if (this.mformSetGeographic != null)
            {
                this.mformSetGeographic.Close();
                this.mformSetGeographic = null;
            }
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
                    IGeographicCoordinateSystem system2;
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
                            system2 = this.mSpatialReference as IGeographicCoordinateSystem;
                            if (mSpatialReference != null)
                            {
                                this.rtbDetailes.Text = this.GetPrjCoordDetails(mSpatialReference);
                                this.txtCoordinateName.Text = mSpatialReference.Name;
                            }
                            else if (system2 != null)
                            {
                                this.rtbDetailes.Text = this.GetGeoCoordSysDetails(system2);
                                this.txtCoordinateName.Text = system2.Name;
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
                                system2 = this.mSpatialReference as IGeographicCoordinateSystem;
                                if (mSpatialReference != null)
                                {
                                    this.rtbDetailes.Text = this.GetPrjCoordDetails(mSpatialReference);
                                    this.txtCoordinateName.Text = mSpatialReference.Name;
                                }
                                else if (system2 != null)
                                {
                                    this.rtbDetailes.Text = this.GetGeoCoordSysDetails(system2);
                                    this.txtCoordinateName.Text = system2.Name;
                                }
                            }
                        }
                    }
                    else if (obj3.FullName.ToLower().Contains(".tif"))
                    {
                        factory = new RasterWorkspaceFactoryClass();
                        workspace = factory.OpenFromFile(fileName, 0);
                        if (obj3.Category == "Raster Dataset")
                        {
                            workspace3 = workspace as IRasterWorkspace;
                            dataset = workspace3.OpenRasterDataset(name + ".tif") as IGeoDataset;
                            this.mSpatialReference = dataset.SpatialReference;
                            mSpatialReference = this.mSpatialReference as IProjectedCoordinateSystem;
                            system2 = this.mSpatialReference as IGeographicCoordinateSystem;
                            if (mSpatialReference != null)
                            {
                                this.rtbDetailes.Text = this.GetPrjCoordDetails(mSpatialReference);
                                this.txtCoordinateName.Text = mSpatialReference.Name;
                            }
                            else if (system2 != null)
                            {
                                this.rtbDetailes.Text = this.GetGeoCoordSysDetails(system2);
                                this.txtCoordinateName.Text = system2.Name;
                            }
                        }
                    }
                    else if (obj3.FullName.ToLower().Contains(".img"))
                    {
                        factory = new RasterWorkspaceFactoryClass();
                        workspace = factory.OpenFromFile(fileName, 0);
                        if (obj3.Category == "Raster Dataset")
                        {
                            workspace3 = workspace as IRasterWorkspace;
                            dataset = workspace3.OpenRasterDataset(name + ".img") as IGeoDataset;
                            this.mSpatialReference = dataset.SpatialReference;
                            mSpatialReference = this.mSpatialReference as IProjectedCoordinateSystem;
                            system2 = this.mSpatialReference as IGeographicCoordinateSystem;
                            if (mSpatialReference != null)
                            {
                                this.rtbDetailes.Text = this.GetPrjCoordDetails(mSpatialReference);
                                this.txtCoordinateName.Text = mSpatialReference.Name;
                            }
                            else if (system2 != null)
                            {
                                this.rtbDetailes.Text = this.GetGeoCoordSysDetails(system2);
                                this.txtCoordinateName.Text = system2.Name;
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
                        system2 = this.mSpatialReference as IGeographicCoordinateSystem;
                        if (mSpatialReference != null)
                        {
                            this.rtbDetailes.Text = this.GetPrjCoordDetails(mSpatialReference);
                            this.txtCoordinateName.Text = mSpatialReference.Name;
                        }
                        else if (system2 != null)
                        {
                            this.rtbDetailes.Text = this.GetGeoCoordSysDetails(system2);
                            this.txtCoordinateName.Text = system2.Name;
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
            IProjectedCoordinateSystem mSpatialReference = this.mSpatialReference as IProjectedCoordinateSystem;
            IGeographicCoordinateSystem system2 = this.mSpatialReference as IGeographicCoordinateSystem;
            if (mSpatialReference != null)
            {
                if (this.mformSetProjected == null)
                {
                    this.mformSetProjected = new FormSetProjectedCoordinateSystem();
                }
                this.mformSetProjected.InitialValue(this.mSpatialReference);
                this.mformSetProjected.ShowDialog();
                if (this.mformSetProjected.FlagOk)
                {
                    this.mProjectedCoordinateSystem = this.mformSetProjected.SetProjectionValue();
                    this.rtbDetailes.Text = this.GetPrjCoordDetails(this.mProjectedCoordinateSystem);
                    this.txtCoordinateName.Text = this.mProjectedCoordinateSystem.Name;
                }
            }
            else if (system2 != null)
            {
                if (this.mformSetGeographic == null)
                {
                    this.mformSetGeographic = new FormSetGeographicCoordinateSystem();
                }
                this.mformSetGeographic.InitialValue(this.mSpatialReference);
                this.mformSetGeographic.ShowDialog();
                if (this.mformSetGeographic.FlagOk)
                {
                    this.mGeographicCoordinateSystem = this.mformSetGeographic.SetGeographicValue();
                    this.rtbDetailes.Text = this.GetGeoCoordSysDetails(this.mGeographicCoordinateSystem);
                    this.txtCoordinateName.Text = this.mGeographicCoordinateSystem.Name;
                }
            }
        }

        private void sButOk_Click(object sender, EventArgs e)
        {
            if (this.mformSetProjected != null)
            {
                if (this.mformSetProjected.mFormSetGeographic != null)
                {
                    this.mformSetProjected.mFormSetGeographic.Close();
                }
                if (this.mformSetProjected.FlagOk)
                {
                    this.mSpatialReference = this.mProjectedCoordinateSystem;
                    this.FlagOk = true;
                }
                this.mformSetProjected.Close();
                this.mformSetProjected = null;
            }
            if (this.mformSetGeographic != null)
            {
                if (this.mformSetGeographic.FlagOk)
                {
                    this.mSpatialReference = this.mGeographicCoordinateSystem;
                    this.FlagOk = true;
                }
                this.mformSetGeographic.Close();
                this.mformSetGeographic = null;
            }
            base.Hide();
        }

        private void sButSelect_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "Coodinate System|*.prj";
                string configValue = UtilFactory.GetConfigOpt().GetConfigValue("AppPath");
                string str2 = UtilFactory.GetConfigOpt().GetConfigValue("ProjectFilePath");
                dialog.InitialDirectory = configValue + @"\" + str2;
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    this.txtCoordinateName.Text = "";
                    this.rtbDetailes.Text = "";
                    string fileName = dialog.FileName;
                    ISpatialReferenceFactory factory = new SpatialReferenceEnvironmentClass();
                    ISpatialReference reference = factory.CreateESRISpatialReferenceFromPRJFile(fileName);
                    if ((reference == null) || (!(reference is IProjectedCoordinateSystem) && !(reference is IGeographicCoordinateSystem)))
                    {
                        MessageBox.Show("选择的坐标系统文件不正确，请重新选择！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else
                    {
                        this.mSpatialReference = reference;
                        IProjectedCoordinateSystem mSpatialReference = this.mSpatialReference as IProjectedCoordinateSystem;
                        IGeographicCoordinateSystem pGeoCoordSys = this.mSpatialReference as IGeographicCoordinateSystem;
                        if (mSpatialReference != null)
                        {
                            this.rtbDetailes.Text = this.GetPrjCoordDetails(mSpatialReference);
                            this.txtCoordinateName.Text = mSpatialReference.Name;
                            this.mProjectedCoordinateSystem = mSpatialReference;
                            this.FlagOk = true;
                        }
                        else if (pGeoCoordSys != null)
                        {
                            this.rtbDetailes.Text = this.GetGeoCoordSysDetails(pGeoCoordSys);
                            this.txtCoordinateName.Text = pGeoCoordSys.Name;
                            this.mGeographicCoordinateSystem = pGeoCoordSys;
                            this.FlagOk = true;
                        }
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        public ISpatialReference SpatialReference
        {
            get
            {
                return this.mSpatialReference;
            }
            set
            {
                try
                {
                    this.mSpatialReference = value;
                }
                catch (Exception)
                {
                }
            }
        }
    }
}

