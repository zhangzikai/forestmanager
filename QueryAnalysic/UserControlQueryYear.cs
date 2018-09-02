namespace QueryAnalysic
{
    using DevExpress.XtraEditors;
    using DevExpress.XtraEditors.Controls;
    using ESRI.ArcGIS.Carto;
    using ESRI.ArcGIS.Controls;
    using ESRI.ArcGIS.Display;
    using ESRI.ArcGIS.Geodatabase;
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

    public class UserControlQueryYear : UserControlBase1
    {
        private SimpleButton ButtonLocationClear;
        private SimpleButton ButtonQuery;
        private CheckedListBoxControl cListBoxKind;
        private CheckedListBoxControl cListBoxY;
        private ColorEdit colorEdit1;
        private ColorEdit colorEdit2;
        private IContainer components;
        private GroupControl groupControl;
        private GroupControl groupControlKind;
        internal ImageList ImageList1;
        public ImageListBoxControl imageListBoxControlKind;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private IFeatureLayer m_CountyLayer;
        private IFeatureClass m_EditFeatureClass;
        private IFeatureLayer m_EditLayer;
        private IFeatureLayer m_QueryLayer;
        private IFeatureLayer m_TownLayer;
        private IFeatureLayer m_VillageLayer;
        private IActiveViewEvents_Event mActiveViewEvents;
        private const string mClassName = "QueryAnalysic.UserControlQueryYear";
        private string mEditKind = "造林";
        private string mEditKind2 = "ZaoLin";
        private string mEditKindCode = "";
        private ErrorOpt mErrOpt = UtilFactory.GetErrorOpt();
        private IGroupLayer mGLayer;
        private IHookHelper mHookHelper;
        private string mKindCode = "";
        private ArrayList mLayerList;
        private ArrayList mLayerList2;
        private ArrayList mLayerList3;
        private bool mSelecting;
        private string mSubSysName = UtilFactory.GetConfigOpt().GetSystemName();
        private const string myClassName = "查看年度作业设计图层";
        private Panel panel7;
        private Panel panel8;
        private PanelControl panelControlColor;
        private RadioGroup radioGroupY;
        private SpinEdit spinEdit1;

        public UserControlQueryYear()
        {
            this.InitializeComponent();
        }

        private void AddLayer(string sName, string sYear, IFeatureClass pFClass)
        {
            try
            {
                IMapDocument document = null;
                document = new MapDocumentClass();
                string sDocument = UtilFactory.GetConfigOpt().RootPath + @"\Template\" + sName.Replace("_" + sYear, "") + ".lyr";
                document.Open(sDocument, "");
                ILayer layer = null;
                IFeatureLayer layer2 = null;
                IGeoFeatureLayer layer3 = null;
                IFeatureRenderer renderer = null;
                if (document.DocumentType == esriMapDocumentType.esriMapDocumentTypeLyr)
                {
                    layer = document.get_Layer(0, 0);
                    layer2 = (IFeatureLayer) layer;
                    layer3 = (IGeoFeatureLayer) layer2;
                    renderer = layer3.Renderer;
                    try
                    {
                        ((IFeatureLayer) layer).FeatureClass = pFClass;
                    }
                    catch (Exception)
                    {
                    }
                }
                document.Close();
                layer.Name = sName;
                IUniqueValueRenderer renderer2 = renderer as IUniqueValueRenderer;
                IRelationshipClass relClass = layer2.FeatureClass.get_RelationshipClasses(esriRelRole.esriRelRoleAny).Next();
                ITable originClass = (ITable) relClass.OriginClass;
                ITable destinationClass = (ITable) relClass.DestinationClass;
                IDisplayRelationshipClass class4 = ((IFeatureLayer) layer) as IDisplayRelationshipClass;
                ITable table5 = (ITable) class4.RelationshipClass.OriginClass;
                ITable table6 = (ITable) class4.RelationshipClass.DestinationClass;
                string name = (destinationClass as IDataset).Name;
                IFeatureLayer layer1 = (IFeatureLayer) layer;
                IDisplayTable table2 = (IDisplayTable) layer2;
                ITable displayTable = table2.DisplayTable;
                if (displayTable is IRelQueryTable)
                {
                    IRelQueryTable table4 = (IRelQueryTable) displayTable;
                    IRelQueryTableInfo info = (IRelQueryTableInfo) table4;
                    class4.DisplayRelationshipClass(relClass, info.JoinType);
                }
                else
                {
                    class4.DisplayRelationshipClass(null, esriJoinType.esriLeftOuterJoin);
                }
                layer3 = (IGeoFeatureLayer) layer2;
                layer3.Renderer = new SimpleRendererClass();
                string field = renderer2.get_Field(0);
                if (renderer2.get_Field(0).Split(new char[] { '.' }).Length == 2)
                {
                    field = (destinationClass as IDataset).Name + "." + renderer2.get_Field(0).Split(new char[] { '.' })[1];
                }
                renderer2.set_Field(0, field);
                layer3.Renderer = renderer2 as IFeatureRenderer;
                string configValue = UtilFactory.GetConfigOpt().GetConfigValue(this.mEditKind2 + "FieldName");
                if ((this.mEditKind == "造林") || (this.mEditKind == "采伐"))
                {
                    try
                    {
                        layer3.DisplayField = (pFClass as IDataset).Name + "." + configValue;
                        goto Label_0261;
                    }
                    catch (Exception)
                    {
                        layer3.DisplayField = configValue;
                        goto Label_0261;
                    }
                }
                layer3.DisplayField = configValue;
            Label_0261:
                layer3.DisplayAnnotation = true;
                IAnnotateLayerPropertiesCollection annotationProperties = layer3.AnnotationProperties;
                annotationProperties.Clear();
                ILabelEngineLayerProperties properties = new LabelEngineLayerPropertiesClass();
                properties.IsExpressionSimple = true;
                properties.Expression = "[" + layer3.DisplayField.ToString() + "]";
                IAnnotateLayerProperties properties2 = properties as IAnnotateLayerProperties;
                properties2.AnnotationMinimumScale = 35000.0;
                ITextSymbol symbol = properties.Symbol;
                symbol.Size = 12.0;
                IColor color = symbol.Color;
                stdole.IFontDisp font = symbol.Font;
                font.Bold = true;
                font.Name = "宋体";
                font.Size = 12M;
                IRgbColor color2 = new RgbColorClass();
                color2.Red = this.colorEdit1.Color.R;
                color2.Blue = this.colorEdit1.Color.B;
                color2.Green = this.colorEdit1.Color.G;
                color2.Red = 0xff;
                color2.Blue = 0;
                color2.Green = 0;
                color = color2;
                symbol.Color = color;
                layer2.ScaleSymbols = true;
                annotationProperties.Add(properties as IAnnotateLayerProperties);
                this.mGLayer.Add(layer);
                this.mGLayer.Visible = true;
                layer.Visible = true;
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "QueryAnalysic.UserControlQueryYear", "AddLayer", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void AddLayer2(string syear, IFeatureClass pFClass)
        {
            try
            {
                IFeatureLayer layer = new FeatureLayerClass();
                layer.FeatureClass = pFClass;
                layer.Name = this.mEditKind + "_" + syear;
                ILayer layer2 = layer;
                this.mGLayer.Add(layer2);
                this.RendererLayer(layer2 as IFeatureLayer);
            }
            catch (Exception)
            {
            }
        }

        private void ButtonQuery_Click(object sender, EventArgs e)
        {
            try
            {
                string syear = "";
                string sLayerName = "";
                syear = this.cListBoxY.Items[this.cListBoxY.SelectedIndex].Value.ToString().Replace("年", "");
                syear = this.radioGroupY.Properties.Items[this.radioGroupY.SelectedIndex].Description.ToString().Replace("年", "");
                sLayerName = this.mEditKind + "_" + syear;
                ILayer layer = GISFunFactory.LayerFun.FindLayerInGroupLayer(this.mGLayer, sLayerName, true);
                if (this.cListBoxKind.Items[0].CheckState == CheckState.Checked)
                {
                    if (layer == null)
                    {
                        this.AddLayer2(syear, this.mLayerList[this.radioGroupY.SelectedIndex] as IFeatureClass);
                    }
                    else
                    {
                        this.RendererLayer(layer as IFeatureLayer);
                    }
                }
                for (int i = 1; i < this.cListBoxKind.Items.Count; i++)
                {
                    sLayerName = this.mEditKind + "_" + this.cListBoxKind.Items[i].Value.ToString() + "_" + syear;
                    layer = GISFunFactory.LayerFun.FindLayerInGroupLayer(this.mGLayer, sLayerName, true);
                    if (this.cListBoxKind.Items[i].CheckState == CheckState.Checked)
                    {
                        if (layer == null)
                        {
                            this.AddLayer(sLayerName, syear, this.mLayerList[this.radioGroupY.SelectedIndex] as IFeatureClass);
                        }
                        else
                        {
                            layer.Visible = true;
                            this.mGLayer.Visible = true;
                        }
                    }
                    else if (layer != null)
                    {
                        this.mGLayer.Delete(layer);
                    }
                }
                this.mHookHelper.ActiveView.Refresh();
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "QueryAnalysic.UserControlQueryYear", "ButtonQuery_Click", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void cListBoxY_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.InitialKindList();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void groupControl_Paint(object sender, PaintEventArgs e)
        {
        }

        public void Hook(object hook, string sEditKind, IFeatureLayer pEditFLayer)
        {
            try
            {
                this.mEditKind = sEditKind;
                this.m_EditLayer = pEditFLayer;
                if (hook != null)
                {
                    this.mHookHelper = new HookHelperClass();
                    this.mHookHelper.Hook = hook;
                    if (this.mHookHelper.FocusMap != null)
                    {
                        this.mActiveViewEvents = this.mHookHelper.FocusMap as IActiveViewEvents_Event;
                    }
                    this.InitialValue();
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "QueryAnalysic.UserControlQueryYear", "Hook", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserControlQueryYear));
            this.panel7 = new System.Windows.Forms.Panel();
            this.ButtonQuery = new DevExpress.XtraEditors.SimpleButton();
            this.ImageList1 = new System.Windows.Forms.ImageList();
            this.panel8 = new System.Windows.Forms.Panel();
            this.ButtonLocationClear = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl = new DevExpress.XtraEditors.GroupControl();
            this.radioGroupY = new DevExpress.XtraEditors.RadioGroup();
            this.cListBoxY = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.label4 = new System.Windows.Forms.Label();
            this.groupControlKind = new DevExpress.XtraEditors.GroupControl();
            this.panelControlColor = new DevExpress.XtraEditors.PanelControl();
            this.colorEdit2 = new DevExpress.XtraEditors.ColorEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.spinEdit1 = new DevExpress.XtraEditors.SpinEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.colorEdit1 = new DevExpress.XtraEditors.ColorEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.cListBoxKind = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.imageListBoxControlKind = new DevExpress.XtraEditors.ImageListBoxControl();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl)).BeginInit();
            this.groupControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroupY.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cListBoxY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlKind)).BeginInit();
            this.groupControlKind.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControlColor)).BeginInit();
            this.panelControlColor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.colorEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cListBoxKind)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageListBoxControlKind)).BeginInit();
            this.SuspendLayout();
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.ButtonQuery);
            this.panel7.Controls.Add(this.panel8);
            this.panel7.Controls.Add(this.ButtonLocationClear);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel7.Location = new System.Drawing.Point(0, 413);
            this.panel7.Name = "panel7";
            this.panel7.Padding = new System.Windows.Forms.Padding(7, 5, 5, 0);
            this.panel7.Size = new System.Drawing.Size(315, 33);
            this.panel7.TabIndex = 16;
            // 
            // ButtonQuery
            // 
            this.ButtonQuery.Dock = System.Windows.Forms.DockStyle.Right;
            this.ButtonQuery.ImageIndex = 16;
            this.ButtonQuery.ImageList = this.ImageList1;
            this.ButtonQuery.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.ButtonQuery.Location = new System.Drawing.Point(173, 5);
            this.ButtonQuery.Name = "ButtonQuery";
            this.ButtonQuery.Size = new System.Drawing.Size(65, 28);
            this.ButtonQuery.TabIndex = 11;
            this.ButtonQuery.Text = "查看";
            this.ButtonQuery.ToolTip = "查看";
            this.ButtonQuery.Click += new System.EventHandler(this.ButtonQuery_Click);
            // 
            // ImageList1
            // 
            this.ImageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList1.ImageStream")));
            this.ImageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.ImageList1.Images.SetKeyName(0, "blank16.ico");
            this.ImageList1.Images.SetKeyName(1, "tick16.ico");
            this.ImageList1.Images.SetKeyName(2, "PART16.ICO");
            this.ImageList1.Images.SetKeyName(3, "");
            this.ImageList1.Images.SetKeyName(4, "");
            this.ImageList1.Images.SetKeyName(5, "");
            this.ImageList1.Images.SetKeyName(6, "");
            this.ImageList1.Images.SetKeyName(7, "");
            this.ImageList1.Images.SetKeyName(8, "");
            this.ImageList1.Images.SetKeyName(9, "");
            this.ImageList1.Images.SetKeyName(10, "");
            this.ImageList1.Images.SetKeyName(11, "");
            this.ImageList1.Images.SetKeyName(12, "");
            this.ImageList1.Images.SetKeyName(13, "");
            this.ImageList1.Images.SetKeyName(14, "");
            this.ImageList1.Images.SetKeyName(15, "");
            this.ImageList1.Images.SetKeyName(16, "(30,24).png");
            this.ImageList1.Images.SetKeyName(17, "(00,02).png");
            this.ImageList1.Images.SetKeyName(18, "(00,17).png");
            this.ImageList1.Images.SetKeyName(19, "(00,46).png");
            this.ImageList1.Images.SetKeyName(20, "(01,10).png");
            this.ImageList1.Images.SetKeyName(21, "(01,25).png");
            this.ImageList1.Images.SetKeyName(22, "(05,32).png");
            this.ImageList1.Images.SetKeyName(23, "(06,32).png");
            this.ImageList1.Images.SetKeyName(24, "(07,32).png");
            this.ImageList1.Images.SetKeyName(25, "(08,32).png");
            this.ImageList1.Images.SetKeyName(26, "(08,36).png");
            this.ImageList1.Images.SetKeyName(27, "(09,36).png");
            this.ImageList1.Images.SetKeyName(28, "(10,26).png");
            this.ImageList1.Images.SetKeyName(29, "(11,26).png");
            this.ImageList1.Images.SetKeyName(30, "(11,29).png");
            this.ImageList1.Images.SetKeyName(31, "(12,29).png");
            this.ImageList1.Images.SetKeyName(32, "(11,32).png");
            this.ImageList1.Images.SetKeyName(33, "(11,36).png");
            this.ImageList1.Images.SetKeyName(34, "(13,32).png");
            this.ImageList1.Images.SetKeyName(35, "(19,31).png");
            this.ImageList1.Images.SetKeyName(36, "(22,18).png");
            this.ImageList1.Images.SetKeyName(37, "(25,27).png");
            this.ImageList1.Images.SetKeyName(38, "(29,43).png");
            this.ImageList1.Images.SetKeyName(39, "(30,14).png");
            this.ImageList1.Images.SetKeyName(40, "5.png");
            this.ImageList1.Images.SetKeyName(41, "10.png");
            this.ImageList1.Images.SetKeyName(42, "11.png");
            this.ImageList1.Images.SetKeyName(43, "16.png");
            this.ImageList1.Images.SetKeyName(44, "17.png");
            this.ImageList1.Images.SetKeyName(45, "18.png");
            this.ImageList1.Images.SetKeyName(46, "19.png");
            this.ImageList1.Images.SetKeyName(47, "20.png");
            this.ImageList1.Images.SetKeyName(48, "21.png");
            this.ImageList1.Images.SetKeyName(49, "22.png");
            this.ImageList1.Images.SetKeyName(50, "25.png");
            this.ImageList1.Images.SetKeyName(51, "31.png");
            this.ImageList1.Images.SetKeyName(52, "41.png");
            this.ImageList1.Images.SetKeyName(53, "add.png");
            this.ImageList1.Images.SetKeyName(54, "bullet_minus.png");
            this.ImageList1.Images.SetKeyName(55, "control_add_blue.png");
            this.ImageList1.Images.SetKeyName(56, "control_power_blue.png");
            this.ImageList1.Images.SetKeyName(57, "control_remove_blue.png");
            this.ImageList1.Images.SetKeyName(58, "cross.png");
            this.ImageList1.Images.SetKeyName(59, "down.png");
            this.ImageList1.Images.SetKeyName(60, "draw_tools.png");
            this.ImageList1.Images.SetKeyName(61, "Feedicons_v2_010.png");
            this.ImageList1.Images.SetKeyName(62, "Feedicons_v2_011.png");
            this.ImageList1.Images.SetKeyName(63, "Feedicons_v2_031.png");
            this.ImageList1.Images.SetKeyName(64, "Feedicons_v2_032.png");
            this.ImageList1.Images.SetKeyName(65, "Feedicons_v2_033.png");
            this.ImageList1.Images.SetKeyName(66, "flag blue.png");
            this.ImageList1.Images.SetKeyName(67, "flag red.png");
            this.ImageList1.Images.SetKeyName(68, "flag yellow.png");
            this.ImageList1.Images.SetKeyName(69, "(44,23).png");
            this.ImageList1.Images.SetKeyName(70, "(12,29).png");
            this.ImageList1.Images.SetKeyName(71, "(34,00).png");
            this.ImageList1.Images.SetKeyName(72, "(03,02).png");
            this.ImageList1.Images.SetKeyName(73, "(49,06).png");
            this.ImageList1.Images.SetKeyName(74, "(09,13).png");
            this.ImageList1.Images.SetKeyName(75, "(16,47).png");
            this.ImageList1.Images.SetKeyName(76, "(13,47).png");
            this.ImageList1.Images.SetKeyName(77, "(18,01).png");
            this.ImageList1.Images.SetKeyName(78, "(18,13).png");
            this.ImageList1.Images.SetKeyName(79, "(19,01).png");
            this.ImageList1.Images.SetKeyName(80, "(28,40).png");
            this.ImageList1.Images.SetKeyName(81, "(39,47).png");
            this.ImageList1.Images.SetKeyName(82, "(45,12).png");
            this.ImageList1.Images.SetKeyName(83, "(45,17).png");
            this.ImageList1.Images.SetKeyName(84, "(45,41).png");
            this.ImageList1.Images.SetKeyName(85, "arrow_refresh_small.png");
            this.ImageList1.Images.SetKeyName(86, "(11,29).png");
            this.ImageList1.Images.SetKeyName(87, "(12,29).png");
            this.ImageList1.Images.SetKeyName(88, "(12,11).png");
            // 
            // panel8
            // 
            this.panel8.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel8.Location = new System.Drawing.Point(238, 5);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(7, 28);
            this.panel8.TabIndex = 15;
            this.panel8.Visible = false;
            // 
            // ButtonLocationClear
            // 
            this.ButtonLocationClear.Dock = System.Windows.Forms.DockStyle.Right;
            this.ButtonLocationClear.ImageIndex = 56;
            this.ButtonLocationClear.ImageList = this.ImageList1;
            this.ButtonLocationClear.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.ButtonLocationClear.Location = new System.Drawing.Point(245, 5);
            this.ButtonLocationClear.Name = "ButtonLocationClear";
            this.ButtonLocationClear.Size = new System.Drawing.Size(65, 28);
            this.ButtonLocationClear.TabIndex = 14;
            this.ButtonLocationClear.Text = "重置";
            this.ButtonLocationClear.ToolTip = "重置图层";
            this.ButtonLocationClear.Visible = false;
            // 
            // groupControl
            // 
            this.groupControl.Controls.Add(this.radioGroupY);
            this.groupControl.Controls.Add(this.cListBoxY);
            this.groupControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl.Location = new System.Drawing.Point(0, 0);
            this.groupControl.Name = "groupControl";
            this.groupControl.Padding = new System.Windows.Forms.Padding(2);
            this.groupControl.Size = new System.Drawing.Size(315, 163);
            this.groupControl.TabIndex = 17;
            this.groupControl.Text = "作业设计年份";
            this.groupControl.Paint += new System.Windows.Forms.PaintEventHandler(this.groupControl_Paint);
            // 
            // radioGroupY
            // 
            this.radioGroupY.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radioGroupY.Location = new System.Drawing.Point(131, 24);
            this.radioGroupY.Name = "radioGroupY";
            this.radioGroupY.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.radioGroupY.Properties.Appearance.Options.UseBackColor = true;
            this.radioGroupY.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.radioGroupY.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "可见图层查看结果"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "二类小班查看结果"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "造林地块查看结果"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "采伐地块查看结果")});
            this.radioGroupY.Size = new System.Drawing.Size(180, 135);
            this.radioGroupY.TabIndex = 12;
            // 
            // cListBoxY
            // 
            this.cListBoxY.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.cListBoxY.CheckOnClick = true;
            this.cListBoxY.Dock = System.Windows.Forms.DockStyle.Left;
            this.cListBoxY.ItemHeight = 20;
            this.cListBoxY.Items.AddRange(new DevExpress.XtraEditors.Controls.CheckedListBoxItem[] {
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(null),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(null)});
            this.cListBoxY.Location = new System.Drawing.Point(4, 24);
            this.cListBoxY.Name = "cListBoxY";
            this.cListBoxY.Size = new System.Drawing.Size(127, 135);
            this.cListBoxY.TabIndex = 0;
            this.cListBoxY.Visible = false;
            this.cListBoxY.SelectedIndexChanged += new System.EventHandler(this.cListBoxY_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Location = new System.Drawing.Point(0, 163);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(315, 12);
            this.label4.TabIndex = 19;
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupControlKind
            // 
            this.groupControlKind.Controls.Add(this.panelControlColor);
            this.groupControlKind.Controls.Add(this.cListBoxKind);
            this.groupControlKind.Controls.Add(this.imageListBoxControlKind);
            this.groupControlKind.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControlKind.Location = new System.Drawing.Point(0, 175);
            this.groupControlKind.Name = "groupControlKind";
            this.groupControlKind.Padding = new System.Windows.Forms.Padding(2);
            this.groupControlKind.Size = new System.Drawing.Size(315, 238);
            this.groupControlKind.TabIndex = 20;
            this.groupControlKind.Text = "显示方式";
            // 
            // panelControlColor
            // 
            this.panelControlColor.Appearance.BackColor = System.Drawing.Color.White;
            this.panelControlColor.Appearance.Options.UseBackColor = true;
            this.panelControlColor.Controls.Add(this.colorEdit2);
            this.panelControlColor.Controls.Add(this.label2);
            this.panelControlColor.Controls.Add(this.spinEdit1);
            this.panelControlColor.Controls.Add(this.label3);
            this.panelControlColor.Controls.Add(this.colorEdit1);
            this.panelControlColor.Controls.Add(this.label1);
            this.panelControlColor.Location = new System.Drawing.Point(70, 27);
            this.panelControlColor.Name = "panelControlColor";
            this.panelControlColor.Size = new System.Drawing.Size(238, 26);
            this.panelControlColor.TabIndex = 3;
            this.panelControlColor.TabStop = true;
            // 
            // colorEdit2
            // 
            this.colorEdit2.Dock = System.Windows.Forms.DockStyle.Left;
            this.colorEdit2.EditValue = System.Drawing.Color.Transparent;
            this.colorEdit2.Location = new System.Drawing.Point(188, 2);
            this.colorEdit2.Name = "colorEdit2";
            this.colorEdit2.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.colorEdit2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.colorEdit2.Size = new System.Drawing.Size(47, 18);
            this.colorEdit2.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Left;
            this.label2.Location = new System.Drawing.Point(151, 2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 22);
            this.label2.TabIndex = 5;
            this.label2.Text = "填充";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // spinEdit1
            // 
            this.spinEdit1.Dock = System.Windows.Forms.DockStyle.Left;
            this.spinEdit1.EditValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spinEdit1.Location = new System.Drawing.Point(123, 2);
            this.spinEdit1.Name = "spinEdit1";
            this.spinEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.spinEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spinEdit1.Properties.MaxLength = 2;
            this.spinEdit1.Properties.MaxValue = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.spinEdit1.Properties.MinValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spinEdit1.Size = new System.Drawing.Size(28, 18);
            this.spinEdit1.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Left;
            this.label3.Location = new System.Drawing.Point(86, 2);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 22);
            this.label3.TabIndex = 7;
            this.label3.Text = "宽度";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // colorEdit1
            // 
            this.colorEdit1.Dock = System.Windows.Forms.DockStyle.Left;
            this.colorEdit1.EditValue = System.Drawing.Color.Red;
            this.colorEdit1.Location = new System.Drawing.Point(39, 2);
            this.colorEdit1.Name = "colorEdit1";
            this.colorEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.colorEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.colorEdit1.Size = new System.Drawing.Size(47, 18);
            this.colorEdit1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Location = new System.Drawing.Point(2, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 22);
            this.label1.TabIndex = 3;
            this.label1.Text = "边框";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cListBoxKind
            // 
            this.cListBoxKind.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.cListBoxKind.CheckOnClick = true;
            this.cListBoxKind.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cListBoxKind.ItemHeight = 24;
            this.cListBoxKind.Items.AddRange(new DevExpress.XtraEditors.Controls.CheckedListBoxItem[] {
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("单一值"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("权属"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("地类"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("树种"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("林种"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("立地类型"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("设计类型")});
            this.cListBoxKind.Location = new System.Drawing.Point(4, 24);
            this.cListBoxKind.Name = "cListBoxKind";
            this.cListBoxKind.Size = new System.Drawing.Size(307, 210);
            this.cListBoxKind.TabIndex = 4;
            // 
            // imageListBoxControlKind
            // 
            this.imageListBoxControlKind.Appearance.BackColor = System.Drawing.Color.White;
            this.imageListBoxControlKind.Appearance.Options.UseBackColor = true;
            this.imageListBoxControlKind.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.imageListBoxControlKind.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imageListBoxControlKind.HotTrackSelectMode = DevExpress.XtraEditors.HotTrackSelectMode.SelectItemOnClick;
            this.imageListBoxControlKind.ImageList = this.ImageList1;
            this.imageListBoxControlKind.ItemHeight = 24;
            this.imageListBoxControlKind.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageListBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageListBoxItem("单一值", 1),
            new DevExpress.XtraEditors.Controls.ImageListBoxItem("地类", 0),
            new DevExpress.XtraEditors.Controls.ImageListBoxItem("权属", 0),
            new DevExpress.XtraEditors.Controls.ImageListBoxItem("林种", 0),
            new DevExpress.XtraEditors.Controls.ImageListBoxItem("优势树种", 0),
            new DevExpress.XtraEditors.Controls.ImageListBoxItem("作业设计类型", 1),
            new DevExpress.XtraEditors.Controls.ImageListBoxItem("造林方式", 0)});
            this.imageListBoxControlKind.Location = new System.Drawing.Point(4, 24);
            this.imageListBoxControlKind.Name = "imageListBoxControlKind";
            this.imageListBoxControlKind.Size = new System.Drawing.Size(307, 210);
            this.imageListBoxControlKind.TabIndex = 1;
            // 
            // UserControlQueryYear
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.Appearance.Options.UseBackColor = true;
            this.Controls.Add(this.groupControlKind);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.groupControl);
            this.Controls.Add(this.panel7);
            this.Name = "UserControlQueryYear";
            this.Size = new System.Drawing.Size(315, 446);
            this.panel7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl)).EndInit();
            this.groupControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radioGroupY.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cListBoxY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlKind)).EndInit();
            this.groupControlKind.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControlColor)).EndInit();
            this.panelControlColor.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.colorEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cListBoxKind)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageListBoxControlKind)).EndInit();
            this.ResumeLayout(false);

        }

        private void InitialKindList()
        {
            try
            {
                ICompositeLayer mGLayer = this.mGLayer as ICompositeLayer;
                string str = this.cListBoxY.Items[this.cListBoxY.SelectedIndex].Value.ToString().Replace("年", "");
                str = this.radioGroupY.Properties.Items[this.radioGroupY.SelectedIndex].Description.ToString().Replace("年", "");
                for (int i = 0; i < this.cListBoxKind.Items.Count; i++)
                {
                    this.cListBoxKind.Items[i].CheckState = CheckState.Unchecked;
                }
                for (int j = 0; j < mGLayer.Count; j++)
                {
                    ILayer layer2 = mGLayer.get_Layer(j);
                    if (layer2.Name.Contains(str))
                    {
                        for (int k = 0; k < this.cListBoxKind.Items.Count; k++)
                        {
                            if (layer2.Name.Contains(this.cListBoxKind.Items[k].Value.ToString()))
                            {
                                this.cListBoxKind.Items[k].CheckState = CheckState.Checked;
                            }
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "QueryAnalysic.UserControlQueryYear", "InitialKindList", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        public void InitialValue()
        {
            try
            {
                IDataset editDataset;
                string str6;
                if (((this.mHookHelper == null) || (this.mHookHelper.FocusMap == null)) || (this.mHookHelper.FocusMap.LayerCount == 0))
                {
                    return;
                }
                if (this.mEditKind == "造林")
                {
                    this.mKindCode = "1";
                    this.mEditKind2 = "ZaoLin";
                    this.cListBoxKind.Items[5].Enabled = true;
                }
                else if (this.mEditKind == "采伐")
                {
                    this.mKindCode = "2";
                    this.mEditKind2 = "CaiFa";
                    this.cListBoxKind.Items[5].Enabled = false;
                }
                else
                {
                    this.mKindCode = "";
                }
                IFeatureWorkspace pfw = null;
                pfw = EditTask.EditWorkspace;
                if (pfw == null)
                {
                    return;
                }
                string str = "";
                if (this.m_EditLayer == null)
                {
                    editDataset = QueryFun.GetEditDataset(this.mEditKind2, pfw);
                    if (editDataset == null)
                    {
                        goto Label_02A4;
                    }
                    string[] strArray = editDataset.Name.Split(new char[] { '_' });
                    string str2 = strArray[strArray.Length - 1];
                    string name = UtilFactory.GetConfigOpt().GetConfigValue(this.mEditKind2 + "DatasetName2");
                    pfw.OpenFeatureDataset(name);
                    str = UtilFactory.GetConfigOpt().GetConfigValue(this.mEditKind2 + "Layer") + "_" + str2;
                }
                else
                {
                    editDataset = this.m_EditLayer.FeatureClass as IDataset;
                    str = editDataset.Name;
                    editDataset = this.m_EditLayer.FeatureClass.FeatureDataset;
                }
                IEnumDataset subsets = editDataset.Subsets;
                editDataset = subsets.Next();
                while (editDataset != null)
                {
                    if (str == editDataset.Name)
                    {
                        this.m_EditFeatureClass = editDataset as IFeatureClass;
                        break;
                    }
                    editDataset = subsets.Next();
                }
                this.cListBoxY.Items.Clear();
                this.radioGroupY.Properties.Items.Clear();
                this.mLayerList = new ArrayList();
                string configValue = UtilFactory.GetConfigOpt().GetConfigValue(this.mEditKind2 + "Layer");
                if (this.m_EditFeatureClass != null)
                {
                    string str5 = editDataset.Name.Substring(configValue.Length + 1, (str.Length - configValue.Length) - 1) + "年";
                    this.cListBoxY.Items.Add(str5, false);
                    this.radioGroupY.Properties.Items.AddRange(new RadioGroupItem[] { new RadioGroupItem(null, str5) });
                    this.mLayerList.Add(this.m_EditFeatureClass);
                }
            Label_02A4:
                str6 = UtilFactory.GetConfigOpt().GetConfigValue(this.mEditKind2 + "DatasetName2");
                configValue = UtilFactory.GetConfigOpt().GetConfigValue(this.mEditKind2 + "Layer2");
                IFeatureDataset dataset3 = pfw.OpenFeatureDataset(str6) as IFeatureDataset;
                IEnumDataset dataset4 = dataset3.Subsets;
                IDataset dataset5 = dataset4.Next();
                IFeatureClass class2 = null;
                while (dataset5 != null)
                {
                    if (dataset5.Type == esriDatasetType.esriDTFeatureClass)
                    {
                        class2 = dataset5 as IFeatureClass;
                        if (dataset5.Name.Contains(configValue) && (dataset5.Name.Length > configValue.Length))
                        {
                            string str7 = dataset5.Name.Substring(configValue.Length + 1, (dataset5.Name.Length - configValue.Length) - 1) + "年";
                            this.cListBoxY.Items.Add(str7, false);
                            this.radioGroupY.Properties.Items.AddRange(new RadioGroupItem[] { new RadioGroupItem(null, str7) });
                            this.mLayerList.Add(class2);
                        }
                    }
                    dataset5 = dataset4.Next();
                }
                IMap focusMap = this.mHookHelper.FocusMap;
                this.mGLayer = GISFunFactory.LayerFun.FindLayer(focusMap as IBasicMap, this.mEditKind + "专题", true) as IGroupLayer;
                if (this.mGLayer == null)
                {
                    GISFunFactory.LayerFun.AddGroupLayer(focusMap as IBasicMap, null, this.mEditKind);
                    this.mGLayer = GISFunFactory.LayerFun.FindLayer(focusMap as IBasicMap, this.mEditKind, true) as IGroupLayer;
                }
                if (this.mGLayer != null)
                {
                    ICompositeLayer mGLayer = this.mGLayer as ICompositeLayer;
                    for (int i = 0; i < mGLayer.Count; i++)
                    {
                        ILayer layer2 = mGLayer.get_Layer(i);
                        for (int j = 0; j < this.cListBoxY.Items.Count; j++)
                        {
                            string str8 = this.cListBoxY.Items[j].Value.ToString().Replace("年", "");
                            if (layer2.Name.Contains(str8))
                            {
                                this.cListBoxY.Items[j].CheckState = CheckState.Checked;
                                this.radioGroupY.SelectedIndex = j;
                            }
                        }
                    }
                    this.InitialKindList();
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "QueryAnalysic.UserControlQueryYear", "InitialValue", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void RendererLayer(IFeatureLayer featureLayer)
        {
            try
            {
                IGeoFeatureLayer layer = (IGeoFeatureLayer) featureLayer;
                string configValue = UtilFactory.GetConfigOpt().GetConfigValue(this.mEditKind2 + "FieldName");
                layer.DisplayField = configValue;
                ISimpleRenderer renderer1 = (ISimpleRenderer) layer.Renderer;
                ISymbol symbol = null;
                ISimpleFillSymbol symbol2 = new SimpleFillSymbolClass();
                ISimpleLineSymbol symbol3 = new SimpleLineSymbolClass();
                IRgbColor color = new RgbColorClass();
                color.NullColor = true;
                symbol2.Color = color;
                IRgbColor color2 = new RgbColorClass();
                color2.Red = this.colorEdit1.Color.R;
                color2.Blue = this.colorEdit1.Color.B;
                color2.Green = this.colorEdit1.Color.G;
                symbol3.Color = color2;
                symbol3.Width = (double) this.spinEdit1.Value;
                symbol2.Outline = symbol3;
                if (this.colorEdit2.Color.Name != "Transparent")
                {
                    color2.Red = this.colorEdit2.Color.R;
                    color2.Blue = this.colorEdit2.Color.B;
                    color2.Green = this.colorEdit2.Color.G;
                    symbol2.Color = color2;
                }
                symbol = symbol2 as ISymbol;
                ISimpleRenderer renderer = new SimpleRendererClass();
                renderer.Symbol = symbol;
                layer.Renderer = renderer as IFeatureRenderer;
                IAnnotateLayerPropertiesCollection annotationProperties = layer.AnnotationProperties;
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
                properties3.Expression = "[" + featureLayer.DisplayField + "]";
                IAnnotateLayerProperties properties4 = properties3 as IAnnotateLayerProperties;
                properties4.AnnotationMinimumScale = 35000.0;
                ITextSymbol symbol4 = new TextSymbolClass();
                symbol4.Size = 12.0;
                IColor color3 = symbol4.Color;
                stdole.IFontDisp font = symbol4.Font;
                font.Bold = true;
                font.Name = "宋体";
                font.Size = 12M;
                IRgbColor color4 = new RgbColorClass();
                color4.Red = this.colorEdit1.Color.R;
                color4.Blue = this.colorEdit1.Color.B;
                color4.Green = this.colorEdit1.Color.G;
                color3 = color4;
                symbol4.Color = color3;
                properties3.Symbol = symbol4;
                IAnnotateLayerProperties item = properties3 as IAnnotateLayerProperties;
                annotationProperties.Add(item);
                layer.Renderer = renderer as IFeatureRenderer;
                IFeatureRenderer renderer2 = layer.Renderer;
                layer.DisplayAnnotation = true;
            }
            catch (Exception)
            {
            }
        }
    }
}

