namespace QueryAnalysic
{
    using DevExpress.XtraEditors;
    using DevExpress.XtraEditors.Controls;
    using ESRI.ArcGIS.Carto;
    using ESRI.ArcGIS.Controls;
    using ESRI.ArcGIS.Display;
    using ESRI.ArcGIS.Geodatabase;
    using ESRI.ArcGIS.Geometry;
    using FormBase;
    using FunFactory;
    using stdole;
    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using TaskManage;
    using Utilities;

    public class UserControlQueryTFH : UserControlBase1
    {
        private SimpleButton ButtonDistLocation;
        private SimpleButton ButtonFind;
        private CheckEdit checkEdit1;
        private ComboBoxEdit cmbPlace;
        private ComboBoxEdit cmbTFH;
        private ComboBoxEdit cmbTFH2;
        private IContainer components;
        private GroupControl groupControlTFH;
        private ImageListBoxControl icmbFind;
        private Label labelQuery;
        private bool m_bCoor;
        private bool m_bUnitD;
        private HookHelper m_HookHelper;
        private IMap m_Map;
        private IFeatureLayer m_TFLayer;
        private const string mClassName = "QueryAnalysic.UserControlQueryTFH";
   
        private IFeatureLayer mEditLayer;
        private ErrorOpt mErrOpt = UtilFactory.GetErrorOpt();
        private string mFiledName = "";
        private IFeatureWorkspace mfWorkspace;
        private string mSubSysName = UtilFactory.GetConfigOpt().GetSystemName();
        private const string myClassName = "图幅号查询";
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private Panel panel4;
        private Panel panel5;
        private Panel panel7;
        private Panel panel8;
        private RadioGroup radioGroupKind;

        public UserControlQueryTFH()
        {
            this.InitializeComponent();
        }

        private ILayer AddLayer(string sname, string sDisplayField, IFeatureLayer pFLayer, IGroupLayer pGLayer)
        {
            try
            {
                if (pGLayer != null)
                {
                    ICompositeLayer layer = pGLayer as ICompositeLayer;
                    for (int i = 0; i < layer.Count; i++)
                    {
                        ILayer layer2 = layer.get_Layer(i);
                        if (layer2.Name == sname)
                        {
                            pGLayer.Delete(layer2);
                        }
                    }
                }
                pFLayer.Name = sname;
                pFLayer.DisplayField = sDisplayField;
                ILayer layer3 = pFLayer;
                if (pGLayer != null)
                {
                    pGLayer.Add(layer3);
                }
                else
                {
                    this.m_Map.AddLayer(layer3);
                }
                IFeatureLayer layer4 = layer3 as IFeatureLayer;
                IGeoFeatureLayer layer5 = (IGeoFeatureLayer) layer4;
                ISimpleRenderer renderer1 = (ISimpleRenderer) layer5.Renderer;
                ISymbol symbol = null;
                ISimpleFillSymbol symbol2 = new SimpleFillSymbolClass();
                ISimpleLineSymbol symbol3 = new SimpleLineSymbolClass();
                IRgbColor color = new RgbColorClass();
                color.NullColor = true;
                symbol2.Color = color;
                IRgbColor color2 = new RgbColorClass();
                color2.Red = 0xff;
                color2.Blue = 0xff;
                color2.Green = 0;
                symbol3.Color = color2;
                symbol3.Width = 1.2;
                symbol2.Outline = symbol3;
                symbol = symbol2 as ISymbol;
                ISimpleRenderer renderer = new SimpleRendererClass();
                renderer.Symbol = symbol;
                layer5.Renderer = renderer as IFeatureRenderer;
                IAnnotateLayerPropertiesCollection annotationProperties = layer5.AnnotationProperties;
                annotationProperties.Clear();
                ILineLabelPosition position = new LineLabelPositionClass();
                position.Parallel = false;
                position.Perpendicular = true;
                ILineLabelPlacementPriorities priorities = new LineLabelPlacementPrioritiesClass();
                IBasicOverposterLayerProperties properties2 = new BasicOverposterLayerPropertiesClass();
                properties2.FeatureType = esriBasicOverposterFeatureType.esriOverposterPolyline;
                properties2.LineLabelPlacementPriorities = priorities;
                properties2.LineLabelPosition = position;
                properties2.LabelWeight = esriBasicOverposterWeight.esriHighWeight;
                ILabelEngineLayerProperties properties3 = new LabelEngineLayerPropertiesClass();
                properties3.BasicOverposterLayerProperties = properties2;
                properties3.Expression = "[" + pFLayer.DisplayField + "]";
                ITextSymbol symbol4 = new TextSymbolClass();
                symbol4.Size = 12.0;
                IColor color3 = symbol4.Color;
                stdole.IFontDisp font = symbol4.Font;
                font.Bold = true;
                font.Name = "宋体";
                font.Size = 12M;
                IRgbColor color4 = new RgbColorClass();
                color4.Red = 0xff;
                color4.Blue = 0xff;
                color4.Green = 0;
                color3 = color4;
                symbol4.Color = color3;
                properties3.Symbol = symbol4;
                IAnnotateLayerProperties item = properties3 as IAnnotateLayerProperties;
                annotationProperties.Add(item);
                layer5.DisplayAnnotation = true;
                return layer3;
            }
            catch (Exception)
            {
                return null;
            }
        }

        private void ButtonDistLocation_Click(object sender, EventArgs e)
        {
            try
            {
                ComboBoxEdit cmbTFH = null;
                if (this.radioGroupKind.SelectedIndex == 0)
                {
                    cmbTFH = this.cmbTFH;
                }
                else if (this.radioGroupKind.SelectedIndex == 1)
                {
                    cmbTFH = this.cmbTFH2;
                }
                else if (this.radioGroupKind.SelectedIndex == 2)
                {
                    cmbTFH = this.cmbPlace;
                }
                if ((cmbTFH != null) && (cmbTFH.Tag != null))
                {
                    ArrayList tag = cmbTFH.Tag as ArrayList;
                    if ((tag != null) && (cmbTFH.Properties.Items[cmbTFH.SelectedIndex].ToString() == cmbTFH.Text))
                    {
                        IFeature pFeature = tag[cmbTFH.SelectedIndex] as IFeature;
                        if (pFeature != null)
                        {
                            GISFunFactory.FeatureFun.ZoomToFeature(this.m_Map, pFeature);
                        }
                        if (this.m_TFLayer.DisplayField != this.mFiledName)
                        {
                            IGeoFeatureLayer tFLayer = (IGeoFeatureLayer) this.m_TFLayer;
                            IAnnotateLayerPropertiesCollection annotationProperties = tFLayer.AnnotationProperties;
                            annotationProperties.Clear();
                            ILineLabelPosition position = new LineLabelPositionClass();
                            position.Parallel = false;
                            position.Perpendicular = true;
                            ILineLabelPlacementPriorities priorities = new LineLabelPlacementPrioritiesClass();
                            IBasicOverposterLayerProperties properties2 = new BasicOverposterLayerPropertiesClass();
                            properties2.FeatureType = esriBasicOverposterFeatureType.esriOverposterPolyline;
                            properties2.LineLabelPlacementPriorities = priorities;
                            properties2.LineLabelPosition = position;
                            properties2.LabelWeight = esriBasicOverposterWeight.esriHighWeight;
                            ILabelEngineLayerProperties properties3 = new LabelEngineLayerPropertiesClass();
                            properties3.BasicOverposterLayerProperties = properties2;
                            properties3.Expression = "[" + this.m_TFLayer.DisplayField + "]";
                            ITextSymbol symbol = new TextSymbolClass();
                            symbol.Size = 12.0;
                            IColor color = symbol.Color;
                            stdole.IFontDisp font = symbol.Font;
                            font.Bold = true;
                            font.Name = "宋体";
                            font.Size = 12M;
                            IRgbColor color2 = new RgbColorClass();
                            color2.Red = 0xff;
                            color2.Blue = 0xff;
                            color2.Green = 0;
                            color = color2;
                            symbol.Color = color;
                            properties3.Symbol = symbol;
                            IAnnotateLayerProperties item = properties3 as IAnnotateLayerProperties;
                            annotationProperties.Add(item);
                            tFLayer.DisplayAnnotation = true;
                        }
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        private void ButtonFind_Click(object sender, EventArgs e)
        {
            try
            {
                ComboBoxEdit cmbTFH = null;
                if (this.radioGroupKind.SelectedIndex == 0)
                {
                    cmbTFH = this.cmbTFH;
                }
                else if (this.radioGroupKind.SelectedIndex == 1)
                {
                    cmbTFH = this.cmbTFH2;
                }
                else if (this.radioGroupKind.SelectedIndex == 2)
                {
                    cmbTFH = this.cmbPlace;
                }
                if ((cmbTFH != null) && (cmbTFH.Tag != null))
                {
                    ArrayList tag = cmbTFH.Tag as ArrayList;
                    if (tag != null)
                    {
                        this.icmbFind.Items.Clear();
                        IDataset featureClass = this.m_TFLayer.FeatureClass as IDataset;
                        ISQLSyntax workspace = featureClass.Workspace as ISQLSyntax;
                        esriSQLSpecialCharacters sqlSC = esriSQLSpecialCharacters.esriSQL_WildcardManyMatch;
                        string specialCharacter = workspace.GetSpecialCharacter(sqlSC);
                        IQueryFilter filter = new QueryFilterClass();
                        filter.WhereClause = this.mFiledName + " like '" + specialCharacter + cmbTFH.Text + specialCharacter + "'";
                        IFeatureCursor cursor = this.m_TFLayer.FeatureClass.Search(filter, false);
                        IFeature feature = cursor.NextFeature();
                        if (feature != null)
                        {
                            int index = feature.Fields.FindField(this.mFiledName);
                            ImageListBoxItem item = null;
                            ArrayList list2 = new ArrayList();
                            while (feature != null)
                            {
                                item = new ImageListBoxItem();
                                if (feature.Shape.GeometryType == esriGeometryType.esriGeometryPoint)
                                {
                                    item.ImageIndex = 0;
                                }
                                else if (feature.Shape.GeometryType == esriGeometryType.esriGeometryPolyline)
                                {
                                    item.ImageIndex = 1;
                                }
                                else if (feature.Shape.GeometryType == esriGeometryType.esriGeometryPolygon)
                                {
                                    item.ImageIndex = 2;
                                }
                                item.Value = feature.get_Value(index);
                                this.icmbFind.Items.Add(item);
                                list2.Add(feature);
                                feature = cursor.NextFeature();
                            }
                            this.icmbFind.Tag = tag;
                        }
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        private void checkEdit1_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkEdit1.Checked)
            {
                this.AddLayer("图幅号", this.mFiledName, this.m_TFLayer, null);
            }
            else
            {
                this.m_Map.DeleteLayer(this.m_TFLayer);
            }
        }

        private void cmbPlace_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.cmbPlace.SelectedIndex == -1)
                {
                    this.ButtonFind.Visible = true;
                    this.ButtonDistLocation.Visible = false;
                    this.icmbFind.Visible = true;
                }
                else if (this.cmbPlace.Properties.Items[this.cmbPlace.SelectedIndex].ToString() == this.cmbPlace.Text)
                {
                    this.ButtonFind.Visible = false;
                    this.ButtonDistLocation.Visible = true;
                    this.icmbFind.Visible = false;
                }
                else if (this.cmbPlace.Properties.Items[this.cmbPlace.SelectedIndex].ToString() != this.cmbPlace.Text)
                {
                    this.ButtonFind.Visible = true;
                    this.ButtonDistLocation.Visible = false;
                    this.icmbFind.Visible = true;
                }
            }
            catch (Exception)
            {
            }
        }

        private void cmbTFH_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.cmbTFH.SelectedIndex == -1)
                {
                    this.ButtonFind.Visible = true;
                    this.ButtonDistLocation.Visible = false;
                    this.icmbFind.Visible = true;
                }
                else if (this.cmbTFH.Properties.Items[this.cmbTFH.SelectedIndex].ToString() == this.cmbTFH.Text)
                {
                    this.ButtonFind.Visible = false;
                    this.ButtonDistLocation.Visible = true;
                    this.icmbFind.Visible = false;
                }
                else if (this.cmbTFH.Properties.Items[this.cmbTFH.SelectedIndex].ToString() != this.cmbTFH.Text)
                {
                    this.ButtonFind.Visible = true;
                    this.ButtonDistLocation.Visible = false;
                    this.icmbFind.Visible = true;
                }
            }
            catch (Exception)
            {
            }
        }

        private void cmbTFH2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.cmbTFH2.SelectedIndex == -1)
                {
                    this.ButtonFind.Visible = true;
                    this.ButtonDistLocation.Visible = false;
                    this.icmbFind.Visible = true;
                }
                else if (this.cmbTFH2.Properties.Items[this.cmbTFH2.SelectedIndex].ToString() == this.cmbTFH2.Text)
                {
                    this.ButtonFind.Visible = false;
                    this.ButtonDistLocation.Visible = true;
                    this.icmbFind.Visible = false;
                }
                else if (this.cmbTFH2.Properties.Items[this.cmbTFH2.SelectedIndex].ToString() != this.cmbTFH2.Text)
                {
                    this.ButtonFind.Visible = true;
                    this.ButtonDistLocation.Visible = false;
                    this.icmbFind.Visible = true;
                }
            }
            catch (Exception)
            {
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

        private void icmbFind_DoubleClick(object sender, EventArgs e)
        {
            if (this.icmbFind.SelectedIndex != -1)
            {
                ArrayList tag = this.icmbFind.Tag as ArrayList;
                if (tag != null)
                {
                    IFeature pFeature = tag[this.icmbFind.SelectedIndex] as IFeature;
                    if (pFeature != null)
                    {
                        GISFunFactory.FeatureFun.ZoomToFeature(this.m_Map, pFeature);
                    }
                }
            }
        }

        private void InitialCombox(ArrayList plist)
        {
            try
            {
                IFeatureCursor cursor = this.m_TFLayer.FeatureClass.Search(null, false);
                IFeature feature = cursor.NextFeature();
                string[] strArray = UtilFactory.GetConfigOpt().GetConfigValue("TfhFiledName").Split(new char[] { ',' });
                if (plist.Count == strArray.Length)
                {
                    ArrayList tag = null;
                    while (feature != null)
                    {
                        for (int i = 0; i < strArray.Length; i++)
                        {
                            int index = feature.Fields.FindField(strArray[i]);
                            if (index > -1)
                            {
                                ComboBoxEdit edit = plist[i] as ComboBoxEdit;
                                if (feature.get_Value(index).ToString() != "")
                                {
                                    edit.Properties.Items.Add(feature.get_Value(index).ToString());
                                    if (edit.Tag == null)
                                    {
                                        tag = new ArrayList();
                                        edit.Tag = tag;
                                    }
                                    else
                                    {
                                        tag = edit.Tag as ArrayList;
                                    }
                                    tag.Add(feature);
                                }
                            }
                        }
                        feature = cursor.NextFeature();
                    }
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "QueryAnalysic.UserControlQueryTFH", "InitialCombox", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserControlQueryTFH));
            this.labelQuery = new System.Windows.Forms.Label();
            this.groupControlTFH = new DevExpress.XtraEditors.GroupControl();
            this.icmbFind = new DevExpress.XtraEditors.ImageListBoxControl();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.ButtonFind = new DevExpress.XtraEditors.SimpleButton();
            this.checkEdit1 = new DevExpress.XtraEditors.CheckEdit();
            this.ButtonDistLocation = new DevExpress.XtraEditors.SimpleButton();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.cmbPlace = new DevExpress.XtraEditors.ComboBoxEdit();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cmbTFH2 = new DevExpress.XtraEditors.ComboBoxEdit();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmbTFH = new DevExpress.XtraEditors.ComboBoxEdit();
            this.panel7 = new System.Windows.Forms.Panel();
            this.radioGroupKind = new DevExpress.XtraEditors.RadioGroup();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlTFH)).BeginInit();
            this.groupControlTFH.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.icmbFind)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit1.Properties)).BeginInit();
            this.panel4.SuspendLayout();
            this.panel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPlace.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbTFH2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbTFH.Properties)).BeginInit();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroupKind.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelQuery
            // 
            this.labelQuery.BackColor = System.Drawing.Color.Transparent;
            this.labelQuery.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelQuery.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelQuery.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.labelQuery.Image = ((System.Drawing.Image)(resources.GetObject("labelQuery.Image")));
            this.labelQuery.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelQuery.Location = new System.Drawing.Point(0, 0);
            this.labelQuery.Name = "labelQuery";
            this.labelQuery.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.labelQuery.Size = new System.Drawing.Size(322, 30);
            this.labelQuery.TabIndex = 71;
            this.labelQuery.Text = "      图幅查询";
            this.labelQuery.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupControlTFH
            // 
            this.groupControlTFH.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.groupControlTFH.Controls.Add(this.icmbFind);
            this.groupControlTFH.Controls.Add(this.panel3);
            this.groupControlTFH.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControlTFH.Location = new System.Drawing.Point(0, 30);
            this.groupControlTFH.Name = "groupControlTFH";
            this.groupControlTFH.Padding = new System.Windows.Forms.Padding(6, 0, 6, 6);
            this.groupControlTFH.ShowCaption = false;
            this.groupControlTFH.Size = new System.Drawing.Size(322, 400);
            this.groupControlTFH.TabIndex = 72;
            this.groupControlTFH.Text = "图幅号查询";
            // 
            // icmbFind
            // 
            this.icmbFind.Dock = System.Windows.Forms.DockStyle.Fill;
            this.icmbFind.Location = new System.Drawing.Point(6, 140);
            this.icmbFind.Name = "icmbFind";
            this.icmbFind.Size = new System.Drawing.Size(310, 254);
            this.icmbFind.TabIndex = 10;
            this.icmbFind.DoubleClick += new System.EventHandler(this.icmbFind_DoubleClick);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel5);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(6, 0);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(0, 5, 0, 9);
            this.panel3.Size = new System.Drawing.Size(310, 140);
            this.panel3.TabIndex = 9;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.ButtonFind);
            this.panel5.Controls.Add(this.checkEdit1);
            this.panel5.Controls.Add(this.ButtonDistLocation);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 97);
            this.panel5.Name = "panel5";
            this.panel5.Padding = new System.Windows.Forms.Padding(0, 8, 0, 8);
            this.panel5.Size = new System.Drawing.Size(310, 42);
            this.panel5.TabIndex = 26;
            // 
            // ButtonFind
            // 
            this.ButtonFind.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonFind.Dock = System.Windows.Forms.DockStyle.Right;
            this.ButtonFind.Image = ((System.Drawing.Image)(resources.GetObject("ButtonFind.Image")));
            this.ButtonFind.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.ButtonFind.Location = new System.Drawing.Point(178, 8);
            this.ButtonFind.Name = "ButtonFind";
            this.ButtonFind.Size = new System.Drawing.Size(66, 26);
            this.ButtonFind.TabIndex = 15;
            this.ButtonFind.Text = "查找";
            this.ButtonFind.ToolTip = "查找";
            this.ButtonFind.Click += new System.EventHandler(this.ButtonFind_Click);
            // 
            // checkEdit1
            // 
            this.checkEdit1.Location = new System.Drawing.Point(3, 13);
            this.checkEdit1.Name = "checkEdit1";
            this.checkEdit1.Properties.Caption = "显示图幅框";
            this.checkEdit1.Size = new System.Drawing.Size(85, 19);
            this.checkEdit1.TabIndex = 14;
            this.checkEdit1.CheckedChanged += new System.EventHandler(this.checkEdit1_CheckedChanged);
            // 
            // ButtonDistLocation
            // 
            this.ButtonDistLocation.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonDistLocation.Dock = System.Windows.Forms.DockStyle.Right;
            this.ButtonDistLocation.Image = ((System.Drawing.Image)(resources.GetObject("ButtonDistLocation.Image")));
            this.ButtonDistLocation.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.ButtonDistLocation.Location = new System.Drawing.Point(244, 8);
            this.ButtonDistLocation.Name = "ButtonDistLocation";
            this.ButtonDistLocation.Size = new System.Drawing.Size(66, 26);
            this.ButtonDistLocation.TabIndex = 13;
            this.ButtonDistLocation.Text = "定位";
            this.ButtonDistLocation.ToolTip = "定位";
            this.ButtonDistLocation.Click += new System.EventHandler(this.ButtonDistLocation_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.panel8);
            this.panel4.Controls.Add(this.panel7);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 5);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(310, 92);
            this.panel4.TabIndex = 25;
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.panel8.Controls.Add(this.cmbPlace);
            this.panel8.Controls.Add(this.panel2);
            this.panel8.Controls.Add(this.cmbTFH2);
            this.panel8.Controls.Add(this.panel1);
            this.panel8.Controls.Add(this.cmbTFH);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel8.Location = new System.Drawing.Point(88, 0);
            this.panel8.Name = "panel8";
            this.panel8.Padding = new System.Windows.Forms.Padding(0, 6, 0, 8);
            this.panel8.Size = new System.Drawing.Size(222, 92);
            this.panel8.TabIndex = 25;
            // 
            // cmbPlace
            // 
            this.cmbPlace.Dock = System.Windows.Forms.DockStyle.Top;
            this.cmbPlace.Location = new System.Drawing.Point(0, 62);
            this.cmbPlace.Name = "cmbPlace";
            this.cmbPlace.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbPlace.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbPlace.Size = new System.Drawing.Size(222, 20);
            this.cmbPlace.TabIndex = 20;
            this.cmbPlace.TextChanged += new System.EventHandler(this.cmbPlace_TextChanged);
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 54);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(222, 8);
            this.panel2.TabIndex = 21;
            // 
            // cmbTFH2
            // 
            this.cmbTFH2.Dock = System.Windows.Forms.DockStyle.Top;
            this.cmbTFH2.Location = new System.Drawing.Point(0, 34);
            this.cmbTFH2.Name = "cmbTFH2";
            this.cmbTFH2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbTFH2.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbTFH2.Size = new System.Drawing.Size(222, 20);
            this.cmbTFH2.TabIndex = 18;
            this.cmbTFH2.TextChanged += new System.EventHandler(this.cmbTFH2_TextChanged);
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 26);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(222, 8);
            this.panel1.TabIndex = 19;
            // 
            // cmbTFH
            // 
            this.cmbTFH.Dock = System.Windows.Forms.DockStyle.Top;
            this.cmbTFH.Location = new System.Drawing.Point(0, 6);
            this.cmbTFH.Name = "cmbTFH";
            this.cmbTFH.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbTFH.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbTFH.Size = new System.Drawing.Size(222, 20);
            this.cmbTFH.TabIndex = 17;
            this.cmbTFH.TextChanged += new System.EventHandler(this.cmbTFH_TextChanged);
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.panel7.Controls.Add(this.radioGroupKind);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel7.Location = new System.Drawing.Point(0, 0);
            this.panel7.Name = "panel7";
            this.panel7.Padding = new System.Windows.Forms.Padding(0, 0, 8, 0);
            this.panel7.Size = new System.Drawing.Size(88, 92);
            this.panel7.TabIndex = 24;
            // 
            // radioGroupKind
            // 
            this.radioGroupKind.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radioGroupKind.Location = new System.Drawing.Point(0, 0);
            this.radioGroupKind.Name = "radioGroupKind";
            this.radioGroupKind.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.radioGroupKind.Properties.Appearance.Options.UseBackColor = true;
            this.radioGroupKind.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.radioGroupKind.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "新图幅号"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "旧图幅号"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "地名")});
            this.radioGroupKind.Size = new System.Drawing.Size(80, 92);
            this.radioGroupKind.TabIndex = 22;
            this.radioGroupKind.SelectedIndexChanged += new System.EventHandler(this.radioGroupKind_SelectedIndexChanged);
            // 
            // UserControlQueryTFH
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.Appearance.Options.UseBackColor = true;
            this.Controls.Add(this.groupControlTFH);
            this.Controls.Add(this.labelQuery);
            this.Name = "UserControlQueryTFH";
            this.Size = new System.Drawing.Size(322, 430);
            ((System.ComponentModel.ISupportInitialize)(this.groupControlTFH)).EndInit();
            this.groupControlTFH.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.icmbFind)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit1.Properties)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cmbPlace.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbTFH2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbTFH.Properties)).EndInit();
            this.panel7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radioGroupKind.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        public void InitialValues()
        {
            try
            {
                this.cmbTFH.Visible = true;
                this.cmbTFH2.Visible = true;
                this.cmbTFH.Properties.TextEditStyle = TextEditStyles.Standard;
                this.cmbTFH2.Properties.TextEditStyle = TextEditStyles.Standard;
                this.cmbPlace.Properties.TextEditStyle = TextEditStyles.Standard;
                string[] strArray = UtilFactory.GetConfigOpt().GetConfigValue("TfhFiledName").Split(new char[] { ',' });
                if (this.radioGroupKind.SelectedIndex == 0)
                {
                    this.cmbTFH.Enabled = true;
                    this.cmbTFH2.Enabled = false;
                    this.cmbPlace.Enabled = false;
                    this.mFiledName = strArray[this.radioGroupKind.SelectedIndex];
                }
                else if (this.radioGroupKind.SelectedIndex == 1)
                {
                    this.cmbTFH2.Enabled = true;
                    this.cmbTFH.Enabled = false;
                    this.cmbPlace.Enabled = false;
                    this.mFiledName = strArray[this.radioGroupKind.SelectedIndex];
                }
                else if (this.radioGroupKind.SelectedIndex == 2)
                {
                    this.cmbPlace.Enabled = true;
                    this.cmbTFH.Enabled = false;
                    this.cmbTFH2.Enabled = false;
                    this.mFiledName = strArray[this.radioGroupKind.SelectedIndex];
                }
                IFeatureWorkspace editWorkspace = EditTask.EditWorkspace;
                if (editWorkspace != null)
                {
                    string configValue = UtilFactory.GetConfigOpt().GetConfigValue("TfhLayerName");
                    string name = UtilFactory.GetConfigOpt().GetConfigValue("TfhClassName");
                    this.m_TFLayer = GISFunFactory.LayerFun.FindFeatureLayer(this.m_Map as IBasicMap, configValue, true);
                    IFeatureClass featureClass = null;
                    if (this.m_TFLayer != null)
                    {
                        featureClass = this.m_TFLayer.FeatureClass;
                    }
                    else
                    {
                        featureClass = editWorkspace.OpenFeatureClass(name);
                        this.m_TFLayer = new FeatureLayerClass();
                        this.m_TFLayer.Name = configValue;
                        this.m_TFLayer.FeatureClass = featureClass;
                    }
                    if ((featureClass != null) && (this.m_TFLayer != null))
                    {
                        ArrayList plist = new ArrayList();
                        plist.Add(this.cmbTFH);
                        plist.Add(this.cmbTFH2);
                        plist.Add(this.cmbPlace);
                        this.InitialCombox(plist);
                    }
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "QueryAnalysic.UserControlQueryTFH", "InitialValues", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void radioGroupKind_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string[] strArray = UtilFactory.GetConfigOpt().GetConfigValue("TfhFiledName").Split(new char[] { ',' });
                if (this.radioGroupKind.SelectedIndex == 0)
                {
                    this.cmbTFH.Enabled = true;
                    this.cmbTFH2.Enabled = false;
                    this.cmbPlace.Enabled = false;
                    this.mFiledName = strArray[this.radioGroupKind.SelectedIndex];
                }
                else if (this.radioGroupKind.SelectedIndex == 1)
                {
                    this.cmbTFH2.Enabled = true;
                    this.cmbTFH.Enabled = false;
                    this.cmbPlace.Enabled = false;
                    this.mFiledName = strArray[this.radioGroupKind.SelectedIndex];
                }
                else if (this.radioGroupKind.SelectedIndex == 2)
                {
                    this.cmbPlace.Enabled = true;
                    this.cmbTFH.Enabled = false;
                    this.cmbTFH2.Enabled = false;
                    this.mFiledName = strArray[this.radioGroupKind.SelectedIndex];
                }
            }
            catch (Exception)
            {
            }
        }

        public object hook
        {
            get
            {
                try
                {
                    if (this.m_HookHelper != null)
                    {
                        return this.m_HookHelper.Hook;
                    }
                    return null;
                }
                catch (Exception)
                {
                    return null;
                }
            }
            set
            {
                try
                {
                    if (value != null)
                    {
                        this.m_HookHelper = new HookHelperClass();
                        this.m_HookHelper.Hook = value;
                        this.m_Map = this.m_HookHelper.FocusMap;
                        this.InitialValues();
                    }
                }
                catch (Exception exception)
                {
                    this.mErrOpt.ErrorOperate(this.mSubSysName, "QueryAnalysic.UserControlQueryTFH", "hook", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                }
            }
        }
    }
}

