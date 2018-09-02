namespace Cartography.Render
{
    using Cartography.Element;
    using DevExpress.XtraEditors;
    using DevExpress.XtraEditors.Controls;
    using ESRI.ArcGIS.Carto;
    using ESRI.ArcGIS.Display;
    using ESRI.ArcGIS.esriSystem;
    using ESRI.ArcGIS.Geodatabase;
    using FormBase;
    using stdole;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class DevLabelRender : FormBase3
    {
        private SimpleButton btnSymbol;
        private CheckEdit checkEditClass;
        private CheckEdit checkEditLabel;
        private ComboBoxEdit comboBoxEditClass;
        private ComboBoxEdit comboBoxEditField;
        private ComboBoxEdit comboMaxScale;
        private ComboBoxEdit comboMinScale;
        private IContainer components;
        private GroupBox groupBox1;
        private LabelControl labelControl1;
        private LabelControl labelControl2;
        private LabelControl labelControl3;
        private LabelControl labelControl4;
        private LabelControl labelControl5;
        private LabelControl labelControl6;
        private LabelControl labelControl7;
        private LabelControl labelControl8;
        private IAnnotateLayerPropertiesCollection m_AnnoCollection;
        private IList<string> m_FieldList;
        private string m_Lable;
        private ILabelEngineLayerProperties m_LableEngine;
        private IGeoFeatureLayer m_Layer;
        private ITextSymbol m_TextSymbol;
        private PanelControl panelClass;
        private PanelControl panelClass1;
        private PanelControl panelControl1;
        private PanelControl panelControl2;
        private PanelControl panelControl3;
        private PanelControl panelControl4;
        private PanelControl panelControl5;
        private PanelControl panelControl6;
        private PanelControl panelControl7;
        private RadioGroup radioGroup1;
        private SimpleButton simpleButtonAddClass;
        private SimpleButton simpleButtonCancel;
        private SimpleButton simpleButtonDeleteClass;
        private SimpleButton simpleButtonFix;
        private SimpleButton simpleButtonLabel;
        private SimpleButton simpleButtonOK;
        private SimpleButton simpleButtonRename;
        private TextBox txtFont;

        public DevLabelRender(ILayer pLayer)
        {
            this.InitializeComponent();
            this.m_Layer = (IGeoFeatureLayer) pLayer;
        }

        private void btnSymbol_Click(object sender, EventArgs e)
        {
            ISymbol textSymbol = (ISymbol) this.m_TextSymbol;
            frmTextSymbol symbol2 = new frmTextSymbol();
            symbol2.SymbolSource = textSymbol;
            if (symbol2.ShowDialog() == DialogResult.OK)
            {
                ISymbol symbolSelected = (ISymbol) symbol2.SymbolSelected;
                this.m_TextSymbol = (ITextSymbol) symbolSelected;
                this.InitSymbol();
                symbol2 = null;
            }
        }

        private void checkEditClass_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkEditClass.CheckState == CheckState.Checked)
            {
                IAnnotateLayerPropertiesCollection annotationProperties = this.m_Layer.AnnotationProperties;
                this.InitClassLabel(annotationProperties);
                this.panelClass.Visible = true;
            }
            else
            {
                this.panelClass.Visible = false;
                this.m_AnnoCollection = new AnnotateLayerPropertiesCollectionClass();
                this.CreateDefaultLabel("");
                this.InitLabelEngine(0);
            }
        }

        private void CheckScale(ComboBoxEdit pComboBox)
        {
            int num;
            string str = pComboBox.EditValue.ToString().Replace(" ", "");
            switch (str)
            {
                case "":
                case "<无>":
                    pComboBox.SelectedIndex = 0;
                    return;

                default:
                    num = 0;
                    if (str.IndexOf("1:") == 0)
                    {
                        string str2 = str.Substring(2).Replace(",", "");
                        try
                        {
                            num = Convert.ToInt32(str2);
                            break;
                        }
                        catch
                        {
                            MessageBox.Show("请输入比例尺整数！", "提示");
                            return;
                        }
                    }
                    try
                    {
                        num = Convert.ToInt32(str.Replace(",", ""));
                    }
                    catch
                    {
                        MessageBox.Show("请输入比例尺整数！", "提示");
                        return;
                    }
                    break;
            }
            str = "1:" + this.GetNumString((double) num);
            pComboBox.EditValue = str;
        }

        private void comboBoxEditClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.comboBoxEditClass.Properties.Items.Count < 2)
            {
                this.simpleButtonDeleteClass.Enabled = false;
            }
            else
            {
                this.simpleButtonDeleteClass.Enabled = true;
            }
            if (this.m_LableEngine != null)
            {
                this.SaveLabelEngine();
            }
            int selectedIndex = this.comboBoxEditClass.SelectedIndex;
            if (selectedIndex > -1)
            {
                this.InitLabelEngine(selectedIndex);
            }
        }

        private void comboBoxEditField_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndex = this.comboBoxEditField.SelectedIndex;
            if (selectedIndex > -1)
            {
                this.m_Lable = "[" + this.m_FieldList[selectedIndex] + "]";
            }
        }

        private void comboMaxScale_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.CheckScale(this.comboMaxScale);
            }
        }

        private void comboMaxScale_Leave(object sender, EventArgs e)
        {
            this.CheckScale(this.comboMaxScale);
        }

        private void comboMinScale_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.CheckScale(this.comboMinScale);
            }
        }

        private void comboMinScale_Leave(object sender, EventArgs e)
        {
            this.CheckScale(this.comboMinScale);
        }

        private void CreateDefaultLabel(string sClass)
        {
            ILabelEngineLayerProperties properties = null;
            properties = new LabelEngineLayerPropertiesClass();
            properties.IsExpressionSimple = true;
            properties.Symbol = this.CreateDefaultTextSymbol();
            if (sClass != "")
            {
                IAnnotateLayerProperties properties2 = (IAnnotateLayerProperties) properties;
                properties2.Class = sClass;
            }
            if (this.m_AnnoCollection == null)
            {
                this.m_AnnoCollection = new AnnotateLayerPropertiesCollectionClass();
            }
            this.m_AnnoCollection.Add(properties as IAnnotateLayerProperties);
        }

        private ITextSymbol CreateDefaultTextSymbol()
        {
            ITextSymbol symbol = new TextSymbolClass();
            symbol.Color = this.GetRGBColor(60, 100, 50);
            stdole.IFontDisp font = symbol.Font;
            font.Name = "Arial";
            font.Bold = false;
            font.Italic = false;
            font.Underline = false;
            font.Strikethrough = false;
            font.Size = 9M;
            symbol.Font = font;
            return symbol;
        }

        private void DevLabelRender_Load(object sender, EventArgs e)
        {
            this.panelClass.Visible = false;
            this.InitScale();
            this.InitFields();
            this.InitLabel();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private string GetNumString(double num)
        {
            return num.ToString("#,###");
        }

        private IRgbColor GetRGBColor(int red, int green, int blue)
        {
            IRgbColor color = new RgbColorClass();
            color.Red = red;
            color.Green = green;
            color.Blue = blue;
            return color;
        }

        private void InitClassLabel(IAnnotateLayerPropertiesCollection pAnnoCollection)
        {
            this.m_AnnoCollection = new AnnotateLayerPropertiesCollectionClass();
            this.comboBoxEditClass.Properties.Items.Clear();
            IAnnotateLayerProperties item = null;
            IElementCollection placedElements = null;
            IElementCollection unplacedElements = null;
            for (int i = 0; i < pAnnoCollection.Count; i++)
            {
                pAnnoCollection.QueryItem(i, out item, out placedElements, out unplacedElements);
                ILabelEngineLayerProperties properties2 = (ILabelEngineLayerProperties) item;
                ILabelEngineLayerProperties properties3 = null;
                properties3 = new LabelEngineLayerPropertiesClass();
                properties3.Expression = properties2.Expression;
                properties3.IsExpressionSimple = properties2.IsExpressionSimple;
                IClone symbol = properties2.Symbol as IClone;
                properties3.Symbol = symbol.Clone() as ITextSymbol;
                double annotationMaximumScale = item.AnnotationMaximumScale;
                double annotationMinimumScale = item.AnnotationMinimumScale;
                IAnnotateLayerProperties properties4 = (IAnnotateLayerProperties) properties3;
                properties4.AnnotationMaximumScale = annotationMaximumScale;
                properties4.AnnotationMinimumScale = annotationMinimumScale;
                properties4.Class = item.Class;
                this.m_AnnoCollection.Add(properties4);
                this.comboBoxEditClass.Properties.Items.Add(properties4.Class);
            }
            this.comboBoxEditClass.SelectedIndex = 0;
        }

        private void InitFields()
        {
            this.m_FieldList = new List<string>();
            IField field = null;
            IFeatureClass featureClass = this.m_Layer.FeatureClass;
            for (int i = 0; i < featureClass.Fields.FieldCount; i++)
            {
                field = featureClass.Fields.get_Field(i);
                if (field.Type != esriFieldType.esriFieldTypeGeometry)
                {
                    this.m_FieldList.Add(field.Name);
                    this.comboBoxEditField.Properties.Items.Add(field.AliasName);
                }
            }
            this.comboBoxEditField.SelectedIndex = 0;
        }

        private void InitializeComponent()
        {
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.checkEditLabel = new DevExpress.XtraEditors.CheckEdit();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panelControl4 = new DevExpress.XtraEditors.PanelControl();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.comboMaxScale = new DevExpress.XtraEditors.ComboBoxEdit();
            this.comboMinScale = new DevExpress.XtraEditors.ComboBoxEdit();
            this.radioGroup1 = new DevExpress.XtraEditors.RadioGroup();
            this.panelControl6 = new DevExpress.XtraEditors.PanelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtFont = new System.Windows.Forms.TextBox();
            this.btnSymbol = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl5 = new DevExpress.XtraEditors.PanelControl();
            this.simpleButtonFix = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.comboBoxEditField = new DevExpress.XtraEditors.ComboBoxEdit();
            this.simpleButtonLabel = new DevExpress.XtraEditors.SimpleButton();
            this.panelClass = new DevExpress.XtraEditors.PanelControl();
            this.panelControl7 = new DevExpress.XtraEditors.PanelControl();
            this.simpleButtonRename = new DevExpress.XtraEditors.SimpleButton();
            this.comboBoxEditClass = new DevExpress.XtraEditors.ComboBoxEdit();
            this.simpleButtonDeleteClass = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonAddClass = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.simpleButtonCancel = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonOK = new DevExpress.XtraEditors.SimpleButton();
            this.panelClass1 = new DevExpress.XtraEditors.PanelControl();
            this.checkEditClass = new DevExpress.XtraEditors.CheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditLabel.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).BeginInit();
            this.panelControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comboMaxScale.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboMinScale.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl6)).BeginInit();
            this.panelControl6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl5)).BeginInit();
            this.panelControl5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEditField.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelClass)).BeginInit();
            this.panelClass.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl7)).BeginInit();
            this.panelControl7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEditClass.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelClass1)).BeginInit();
            this.panelClass1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditClass.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.checkEditLabel);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(379, 35);
            this.panelControl1.TabIndex = 0;
            // 
            // checkEditLabel
            // 
            this.checkEditLabel.Location = new System.Drawing.Point(9, 14);
            this.checkEditLabel.Name = "checkEditLabel";
            this.checkEditLabel.Properties.Caption = "显示图层标注";
            this.checkEditLabel.Size = new System.Drawing.Size(143, 19);
            this.checkEditLabel.TabIndex = 0;
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.groupBox1);
            this.panelControl2.Controls.Add(this.panelControl6);
            this.panelControl2.Controls.Add(this.panelControl5);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl2.Location = new System.Drawing.Point(0, 104);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Padding = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.panelControl2.Size = new System.Drawing.Size(379, 240);
            this.panelControl2.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panelControl4);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(5, 93);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(369, 136);
            this.groupBox1.TabIndex = 90;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "比例尺范围";
            // 
            // panelControl4
            // 
            this.panelControl4.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl4.Controls.Add(this.labelControl7);
            this.panelControl4.Controls.Add(this.labelControl6);
            this.panelControl4.Controls.Add(this.labelControl5);
            this.panelControl4.Controls.Add(this.labelControl4);
            this.panelControl4.Controls.Add(this.comboMaxScale);
            this.panelControl4.Controls.Add(this.comboMinScale);
            this.panelControl4.Controls.Add(this.radioGroup1);
            this.panelControl4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl4.Location = new System.Drawing.Point(3, 18);
            this.panelControl4.Name = "panelControl4";
            this.panelControl4.Size = new System.Drawing.Size(363, 115);
            this.panelControl4.TabIndex = 87;
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(38, 59);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(36, 14);
            this.labelControl7.TabIndex = 88;
            this.labelControl7.Text = "小于：";
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(38, 86);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(36, 14);
            this.labelControl6.TabIndex = 87;
            this.labelControl6.Text = "大于：";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(219, 86);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(84, 14);
            this.labelControl5.TabIndex = 86;
            this.labelControl5.Text = "（最大比例尺）";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(219, 59);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(84, 14);
            this.labelControl4.TabIndex = 85;
            this.labelControl4.Text = "（最小比例尺）";
            // 
            // comboMaxScale
            // 
            this.comboMaxScale.Location = new System.Drawing.Point(80, 83);
            this.comboMaxScale.Name = "comboMaxScale";
            this.comboMaxScale.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboMaxScale.Size = new System.Drawing.Size(133, 20);
            this.comboMaxScale.TabIndex = 2;
            this.comboMaxScale.KeyDown += new System.Windows.Forms.KeyEventHandler(this.comboMaxScale_KeyDown);
            this.comboMaxScale.Leave += new System.EventHandler(this.comboMaxScale_Leave);
            // 
            // comboMinScale
            // 
            this.comboMinScale.Location = new System.Drawing.Point(80, 56);
            this.comboMinScale.Name = "comboMinScale";
            this.comboMinScale.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboMinScale.Size = new System.Drawing.Size(133, 20);
            this.comboMinScale.TabIndex = 1;
            this.comboMinScale.KeyDown += new System.Windows.Forms.KeyEventHandler(this.comboMinScale_KeyDown);
            this.comboMinScale.Leave += new System.EventHandler(this.comboMinScale_Leave);
            // 
            // radioGroup1
            // 
            this.radioGroup1.Dock = System.Windows.Forms.DockStyle.Top;
            this.radioGroup1.Location = new System.Drawing.Point(0, 0);
            this.radioGroup1.Name = "radioGroup1";
            this.radioGroup1.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.radioGroup1.Properties.Appearance.Options.UseBackColor = true;
            this.radioGroup1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.radioGroup1.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "与图层的比例范围相同"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "超出下列比例尺则不显示标注")});
            this.radioGroup1.Size = new System.Drawing.Size(363, 50);
            this.radioGroup1.TabIndex = 0;
            this.radioGroup1.SelectedIndexChanged += new System.EventHandler(this.radioGroup1_SelectedIndexChanged);
            // 
            // panelControl6
            // 
            this.panelControl6.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl6.Controls.Add(this.labelControl2);
            this.panelControl6.Controls.Add(this.txtFont);
            this.panelControl6.Controls.Add(this.btnSymbol);
            this.panelControl6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl6.Location = new System.Drawing.Point(5, 42);
            this.panelControl6.Name = "panelControl6";
            this.panelControl6.Size = new System.Drawing.Size(369, 51);
            this.panelControl6.TabIndex = 89;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(30, 12);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(28, 14);
            this.labelControl2.TabIndex = 84;
            this.labelControl2.Text = "字体:";
            // 
            // txtFont
            // 
            this.txtFont.BackColor = System.Drawing.SystemColors.Control;
            this.txtFont.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtFont.Location = new System.Drawing.Point(81, 9);
            this.txtFont.Multiline = true;
            this.txtFont.Name = "txtFont";
            this.txtFont.ReadOnly = true;
            this.txtFont.Size = new System.Drawing.Size(187, 24);
            this.txtFont.TabIndex = 85;
            // 
            // btnSymbol
            // 
            this.btnSymbol.Location = new System.Drawing.Point(286, 7);
            this.btnSymbol.Name = "btnSymbol";
            this.btnSymbol.Size = new System.Drawing.Size(58, 27);
            this.btnSymbol.TabIndex = 86;
            this.btnSymbol.Text = "文本符号";
            this.btnSymbol.Click += new System.EventHandler(this.btnSymbol_Click);
            // 
            // panelControl5
            // 
            this.panelControl5.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl5.Controls.Add(this.simpleButtonFix);
            this.panelControl5.Controls.Add(this.labelControl1);
            this.panelControl5.Controls.Add(this.comboBoxEditField);
            this.panelControl5.Controls.Add(this.simpleButtonLabel);
            this.panelControl5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl5.Location = new System.Drawing.Point(5, 8);
            this.panelControl5.Name = "panelControl5";
            this.panelControl5.Size = new System.Drawing.Size(369, 34);
            this.panelControl5.TabIndex = 88;
            // 
            // simpleButtonFix
            // 
            this.simpleButtonFix.Location = new System.Drawing.Point(298, 3);
            this.simpleButtonFix.Name = "simpleButtonFix";
            this.simpleButtonFix.Size = new System.Drawing.Size(55, 22);
            this.simpleButtonFix.TabIndex = 87;
            this.simpleButtonFix.Text = "森林资源";
            this.simpleButtonFix.ToolTip = "分子式表达式";
            this.simpleButtonFix.Click += new System.EventHandler(this.simpleButtonFix_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(15, 5);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(60, 14);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "标注字段：";
            // 
            // comboBoxEditField
            // 
            this.comboBoxEditField.Location = new System.Drawing.Point(81, 3);
            this.comboBoxEditField.Name = "comboBoxEditField";
            this.comboBoxEditField.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEditField.Size = new System.Drawing.Size(145, 20);
            this.comboBoxEditField.TabIndex = 1;
            this.comboBoxEditField.SelectedIndexChanged += new System.EventHandler(this.comboBoxEditField_SelectedIndexChanged);
            // 
            // simpleButtonLabel
            // 
            this.simpleButtonLabel.Location = new System.Drawing.Point(241, 2);
            this.simpleButtonLabel.Name = "simpleButtonLabel";
            this.simpleButtonLabel.Size = new System.Drawing.Size(46, 22);
            this.simpleButtonLabel.TabIndex = 86;
            this.simpleButtonLabel.Text = "通用";
            this.simpleButtonLabel.ToolTip = "通用表达式";
            this.simpleButtonLabel.Click += new System.EventHandler(this.simpleButtonLabel_Click);
            // 
            // panelClass
            // 
            this.panelClass.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelClass.Controls.Add(this.panelControl7);
            this.panelClass.Controls.Add(this.labelControl3);
            this.panelClass.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelClass.Location = new System.Drawing.Point(0, 65);
            this.panelClass.Name = "panelClass";
            this.panelClass.Size = new System.Drawing.Size(379, 39);
            this.panelClass.TabIndex = 86;
            // 
            // panelControl7
            // 
            this.panelControl7.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.panelControl7.Controls.Add(this.simpleButtonRename);
            this.panelControl7.Controls.Add(this.comboBoxEditClass);
            this.panelControl7.Controls.Add(this.simpleButtonDeleteClass);
            this.panelControl7.Controls.Add(this.simpleButtonAddClass);
            this.panelControl7.Controls.Add(this.labelControl8);
            this.panelControl7.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl7.Location = new System.Drawing.Point(0, 0);
            this.panelControl7.Name = "panelControl7";
            this.panelControl7.Size = new System.Drawing.Size(379, 39);
            this.panelControl7.TabIndex = 87;
            // 
            // simpleButtonRename
            // 
            this.simpleButtonRename.Location = new System.Drawing.Point(325, 8);
            this.simpleButtonRename.Name = "simpleButtonRename";
            this.simpleButtonRename.Size = new System.Drawing.Size(46, 22);
            this.simpleButtonRename.TabIndex = 89;
            this.simpleButtonRename.Text = "重命名";
            this.simpleButtonRename.ToolTip = "通用表达式";
            this.simpleButtonRename.Click += new System.EventHandler(this.simpleButtonRename_Click);
            // 
            // comboBoxEditClass
            // 
            this.comboBoxEditClass.Location = new System.Drawing.Point(62, 9);
            this.comboBoxEditClass.Name = "comboBoxEditClass";
            this.comboBoxEditClass.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEditClass.Size = new System.Drawing.Size(124, 20);
            this.comboBoxEditClass.TabIndex = 2;
            this.comboBoxEditClass.SelectedIndexChanged += new System.EventHandler(this.comboBoxEditClass_SelectedIndexChanged);
            // 
            // simpleButtonDeleteClass
            // 
            this.simpleButtonDeleteClass.Location = new System.Drawing.Point(268, 8);
            this.simpleButtonDeleteClass.Name = "simpleButtonDeleteClass";
            this.simpleButtonDeleteClass.Size = new System.Drawing.Size(46, 22);
            this.simpleButtonDeleteClass.TabIndex = 88;
            this.simpleButtonDeleteClass.Text = "删除";
            this.simpleButtonDeleteClass.ToolTip = "通用表达式";
            this.simpleButtonDeleteClass.Click += new System.EventHandler(this.simpleButtonDeleteClass_Click);
            // 
            // simpleButtonAddClass
            // 
            this.simpleButtonAddClass.Location = new System.Drawing.Point(211, 8);
            this.simpleButtonAddClass.Name = "simpleButtonAddClass";
            this.simpleButtonAddClass.Size = new System.Drawing.Size(46, 22);
            this.simpleButtonAddClass.TabIndex = 87;
            this.simpleButtonAddClass.Text = "添加";
            this.simpleButtonAddClass.ToolTip = "通用表达式";
            this.simpleButtonAddClass.Click += new System.EventHandler(this.simpleButtonAddClass_Click);
            // 
            // labelControl8
            // 
            this.labelControl8.Location = new System.Drawing.Point(20, 12);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(36, 14);
            this.labelControl8.TabIndex = 85;
            this.labelControl8.Text = "类别：";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(30, 12);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(36, 14);
            this.labelControl3.TabIndex = 85;
            this.labelControl3.Text = "类别：";
            // 
            // panelControl3
            // 
            this.panelControl3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl3.Controls.Add(this.simpleButtonCancel);
            this.panelControl3.Controls.Add(this.simpleButtonOK);
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl3.Location = new System.Drawing.Point(0, 360);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(379, 49);
            this.panelControl3.TabIndex = 2;
            // 
            // simpleButtonCancel
            // 
            this.simpleButtonCancel.Location = new System.Drawing.Point(279, 10);
            this.simpleButtonCancel.Name = "simpleButtonCancel";
            this.simpleButtonCancel.Size = new System.Drawing.Size(70, 27);
            this.simpleButtonCancel.TabIndex = 1;
            this.simpleButtonCancel.Text = "取消";
            this.simpleButtonCancel.Click += new System.EventHandler(this.simpleButtonCancel_Click);
            // 
            // simpleButtonOK
            // 
            this.simpleButtonOK.Location = new System.Drawing.Point(161, 10);
            this.simpleButtonOK.Name = "simpleButtonOK";
            this.simpleButtonOK.Size = new System.Drawing.Size(70, 27);
            this.simpleButtonOK.TabIndex = 0;
            this.simpleButtonOK.Text = "确定";
            this.simpleButtonOK.Click += new System.EventHandler(this.simpleButtonOK_Click);
            // 
            // panelClass1
            // 
            this.panelClass1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelClass1.Controls.Add(this.checkEditClass);
            this.panelClass1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelClass1.Location = new System.Drawing.Point(0, 35);
            this.panelClass1.Name = "panelClass1";
            this.panelClass1.Size = new System.Drawing.Size(379, 30);
            this.panelClass1.TabIndex = 87;
            // 
            // checkEditClass
            // 
            this.checkEditClass.Location = new System.Drawing.Point(43, 6);
            this.checkEditClass.Name = "checkEditClass";
            this.checkEditClass.Properties.Caption = "分类别显示标注";
            this.checkEditClass.Size = new System.Drawing.Size(143, 19);
            this.checkEditClass.TabIndex = 2;
            this.checkEditClass.CheckedChanged += new System.EventHandler(this.checkEditClass_CheckedChanged);
            // 
            // DevLabelRender
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(379, 409);
            this.Controls.Add(this.panelControl3);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelClass);
            this.Controls.Add(this.panelClass1);
            this.Controls.Add(this.panelControl1);
            this.LookAndFeel.SkinName = "Blue";
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DevLabelRender";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "标注";
            this.Load += new System.EventHandler(this.DevLabelRender_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.checkEditLabel.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).EndInit();
            this.panelControl4.ResumeLayout(false);
            this.panelControl4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comboMaxScale.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboMinScale.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl6)).EndInit();
            this.panelControl6.ResumeLayout(false);
            this.panelControl6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl5)).EndInit();
            this.panelControl5.ResumeLayout(false);
            this.panelControl5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEditField.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelClass)).EndInit();
            this.panelClass.ResumeLayout(false);
            this.panelClass.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl7)).EndInit();
            this.panelControl7.ResumeLayout(false);
            this.panelControl7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEditClass.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelClass1)).EndInit();
            this.panelClass1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.checkEditClass.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        private void InitLabel()
        {
            this.checkEditLabel.Checked = this.m_Layer.DisplayAnnotation;
            try
            {
                this.m_AnnoCollection = new AnnotateLayerPropertiesCollectionClass();
                IAnnotateLayerPropertiesCollection annotationProperties = this.m_Layer.AnnotationProperties;
                if (annotationProperties.Count > 0)
                {
                    if (annotationProperties.Count > 1)
                    {
                        this.checkEditClass.CheckState = CheckState.Checked;
                    }
                    else
                    {
                        this.checkEditClass.CheckState = CheckState.Unchecked;
                        this.InitClassLabel(annotationProperties);
                    }
                }
                else
                {
                    this.CreateDefaultLabel("");
                }
                this.InitLabelEngine(0);
            }
            catch
            {
            }
        }

        private void InitLabelEngine(int index)
        {
            IAnnotateLayerProperties item = null;
            IElementCollection placedElements = null;
            IElementCollection unplacedElements = null;
            this.m_AnnoCollection.QueryItem(index, out item, out placedElements, out unplacedElements);
            ILabelEngineLayerProperties properties2 = item as ILabelEngineLayerProperties;
            this.m_LableEngine = properties2;
            string str = this.m_LableEngine.Expression.Replace("[", "").Replace("]", "").Replace(" ", "");
            if (this.m_FieldList.Contains(str))
            {
                this.comboBoxEditField.SelectedIndex = this.m_FieldList.IndexOf(str);
                this.comboBoxEditField.Enabled = true;
            }
            else if (str == "")
            {
                this.comboBoxEditField.SelectedIndex = 0;
                this.comboBoxEditField.Enabled = true;
                this.m_LableEngine.Expression = "[" + this.comboBoxEditField.SelectedItem.ToString() + "]";
            }
            else
            {
                this.comboBoxEditField.Enabled = false;
                this.comboBoxEditField.Text = "表达式";
            }
            this.m_Lable = this.m_LableEngine.Expression;
            this.m_TextSymbol = properties2.Symbol;
            this.InitSymbol();
            double annotationMaximumScale = item.AnnotationMaximumScale;
            double annotationMinimumScale = item.AnnotationMinimumScale;
            if ((annotationMaximumScale == 0.0) && (annotationMinimumScale == 0.0))
            {
                this.radioGroup1.SelectedIndex = 0;
                this.comboMaxScale.Enabled = false;
                this.comboMinScale.Enabled = false;
            }
            else
            {
                this.radioGroup1.SelectedIndex = 1;
                this.comboMaxScale.Enabled = true;
                this.comboMinScale.Enabled = true;
                if (annotationMinimumScale == 0.0)
                {
                    this.comboMinScale.EditValue = "<无>";
                }
                else
                {
                    this.comboMinScale.EditValue = "1:" + this.GetNumString(annotationMinimumScale);
                }
                if (annotationMaximumScale == 0.0)
                {
                    this.comboMaxScale.EditValue = "<无>";
                }
                else
                {
                    this.comboMaxScale.EditValue = "1:" + this.GetNumString(annotationMaximumScale);
                }
            }
        }

        private void InitScale()
        {
            string[] strArray = new string[] { "<无>", "1:1,000", "1:10,000", "1:24,000", "1:100,000", "1:250,000", "1:500,000", "1:750,000", "1:1000,000" };
            for (int i = 0; i < strArray.Length; i++)
            {
                this.comboMinScale.Properties.Items.Add(strArray[i]);
            }
            this.comboMinScale.SelectedIndex = 0;
            for (int j = 0; j < strArray.Length; j++)
            {
                this.comboMaxScale.Properties.Items.Add(strArray[j]);
            }
            this.comboMaxScale.SelectedIndex = 0;
        }

        private void InitSymbol()
        {
            if (this.m_TextSymbol != null)
            {
                IRgbColor color = (IRgbColor) this.m_TextSymbol.Color;
                Color color3 = Color.FromArgb(color.Red, color.Green, color.Blue);
                this.txtFont.ForeColor = color3;
                this.txtFont.Text = this.m_TextSymbol.Font.Name + " " + Convert.ToInt32(this.m_TextSymbol.Font.Size);
                this.txtFont.Refresh();
            }
        }

        private void radioGroup1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.radioGroup1.SelectedIndex == 0)
            {
                this.comboMaxScale.Enabled = false;
                this.comboMinScale.Enabled = false;
            }
            else
            {
                this.comboMaxScale.Enabled = true;
                this.comboMinScale.Enabled = true;
            }
        }

        private void SaveLabelEngine()
        {
            try
            {
                this.m_LableEngine.Expression = this.m_Lable;
                if (this.m_Lable.ToLower().Contains("function"))
                {
                    this.m_LableEngine.IsExpressionSimple = false;
                }
                else
                {
                    this.m_LableEngine.IsExpressionSimple = true;
                }
                this.m_LableEngine.Symbol = this.m_TextSymbol;
                IAnnotateLayerProperties lableEngine = (IAnnotateLayerProperties) this.m_LableEngine;
                double num = 0.0;
                double num2 = 0.0;
                if (this.radioGroup1.SelectedIndex == 1)
                {
                    if (this.comboMinScale.EditValue.ToString() != "<无>")
                    {
                        num = Convert.ToInt32(this.comboMinScale.EditValue.ToString().Substring(2).Replace(",", ""));
                    }
                    if (this.comboMaxScale.EditValue.ToString() != "<无>")
                    {
                        num2 = Convert.ToInt32(this.comboMaxScale.EditValue.ToString().Substring(2).Replace(",", ""));
                    }
                }
                lableEngine.AnnotationMinimumScale = num;
                lableEngine.AnnotationMaximumScale = num2;
                IAnnotateLayerPropertiesCollection propertiess = new AnnotateLayerPropertiesCollectionClass();
                for (int i = 0; i < this.m_AnnoCollection.Count; i++)
                {
                    IAnnotateLayerProperties item = null;
                    IElementCollection placedElements = null;
                    IElementCollection unplacedElements = null;
                    this.m_AnnoCollection.QueryItem(i, out item, out placedElements, out unplacedElements);
                    if (item.Class == lableEngine.Class)
                    {
                        propertiess.Add(lableEngine);
                    }
                    else
                    {
                        propertiess.Add(item);
                    }
                }
                if ((propertiess.Count < 1) && (lableEngine != null))
                {
                    propertiess.Add(lableEngine);
                }
                this.m_AnnoCollection = propertiess;
            }
            catch
            {
            }
        }

        private void simpleButtonAddClass_Click(object sender, EventArgs e)
        {
            NewHeading heading = new NewHeading();
            if (heading.ShowDialog() == DialogResult.OK)
            {
                if ((heading.Heading == null) || (heading.Heading.Replace(" ", "") == ""))
                {
                    MessageBox.Show("类名不能为空！", "标注");
                }
                else
                {
                    string sClass = heading.Heading;
                    IAnnotateLayerProperties item = null;
                    IElementCollection placedElements = null;
                    IElementCollection unplacedElements = null;
                    for (int i = 0; i < this.m_AnnoCollection.Count; i++)
                    {
                        this.m_AnnoCollection.QueryItem(i, out item, out placedElements, out unplacedElements);
                        if (item.Class == sClass)
                        {
                            MessageBox.Show("类名不能重复！", "标注");
                            return;
                        }
                    }
                    this.CreateDefaultLabel(sClass);
                    this.comboBoxEditClass.Properties.Items.Add(sClass);
                    this.comboBoxEditClass.SelectedIndex = this.comboBoxEditClass.Properties.Items.Count - 1;
                    this.InitLabelEngine(this.comboBoxEditClass.SelectedIndex);
                }
            }
        }

        private void simpleButtonCancel_Click(object sender, EventArgs e)
        {
            base.DialogResult = DialogResult.Cancel;
            base.Close();
        }

        private void simpleButtonDeleteClass_Click(object sender, EventArgs e)
        {
            int selectedIndex = this.comboBoxEditClass.SelectedIndex;
            string str = this.comboBoxEditClass.SelectedItem.ToString();
            IAnnotateLayerProperties item = null;
            IElementCollection placedElements = null;
            IElementCollection unplacedElements = null;
            for (int i = 0; i < this.m_AnnoCollection.Count; i++)
            {
                this.m_AnnoCollection.QueryItem(i, out item, out placedElements, out unplacedElements);
                if (item.Class == str)
                {
                    this.m_AnnoCollection.Remove(item);
                    break;
                }
            }
            this.m_LableEngine = null;
            this.comboBoxEditClass.Properties.Items.RemoveAt(selectedIndex);
            if (selectedIndex == 0)
            {
                this.comboBoxEditClass.SelectedIndex = selectedIndex;
            }
            else
            {
                this.comboBoxEditClass.SelectedIndex = selectedIndex - 1;
            }
        }

        private void simpleButtonFix_Click(object sender, EventArgs e)
        {
            DevLabelRenderExtent2 extent = new DevLabelRenderExtent2();
            extent.Init(this.m_Layer, this.m_Lable);
            if (extent.ShowDialog() == DialogResult.OK)
            {
                this.m_Lable = extent.Label;
                this.comboBoxEditField.Enabled = false;
                this.comboBoxEditField.Text = "表达式";
            }
        }

        private void simpleButtonLabel_Click(object sender, EventArgs e)
        {
            DevLabelRenderExtent extent = new DevLabelRenderExtent();
            this.m_Lable = this.m_LableEngine.Expression;
            extent.Init(this.m_Layer, this.m_Lable);
            if (extent.ShowDialog() == DialogResult.OK)
            {
                this.m_Lable = extent.Label;
                this.comboBoxEditField.Enabled = false;
                this.comboBoxEditField.Text = "表达式";
            }
        }

        private void simpleButtonOK_Click(object sender, EventArgs e)
        {
            this.SaveLabelEngine();
            this.m_Layer.AnnotationProperties = this.m_AnnoCollection;
            this.m_Layer.DisplayAnnotation = this.checkEditLabel.Checked;
            base.DialogResult = DialogResult.OK;
            base.Close();
        }

        private void simpleButtonRename_Click(object sender, EventArgs e)
        {
            int selectedIndex = this.comboBoxEditClass.SelectedIndex;
            string str = this.comboBoxEditClass.SelectedItem.ToString();
            NewHeading heading = new NewHeading();
            heading.Heading = str;
            IAnnotateLayerProperties item = null;
            IElementCollection placedElements = null;
            IElementCollection unplacedElements = null;
            if (heading.ShowDialog() == DialogResult.OK)
            {
                if ((heading.Heading == null) || (heading.Heading.Replace(" ", "") == ""))
                {
                    MessageBox.Show("类名不能为空！", "标注");
                }
                else
                {
                    string str2 = heading.Heading;
                    for (int i = 0; i < this.m_AnnoCollection.Count; i++)
                    {
                        if (i != selectedIndex)
                        {
                            this.m_AnnoCollection.QueryItem(i, out item, out placedElements, out unplacedElements);
                            if (item.Class == str2)
                            {
                                MessageBox.Show("类名不能重复！", "标注");
                                return;
                            }
                        }
                    }
                    for (int j = 0; j < this.m_AnnoCollection.Count; j++)
                    {
                        if (j == selectedIndex)
                        {
                            this.m_AnnoCollection.QueryItem(j, out item, out placedElements, out unplacedElements);
                            item.Class = str2;
                        }
                    }
                    this.comboBoxEditClass.Properties.Items.RemoveAt(selectedIndex);
                    this.comboBoxEditClass.Properties.Items.Insert(selectedIndex, str2);
                    this.comboBoxEditClass.SelectedIndex = selectedIndex;
                }
            }
        }
    }
}

