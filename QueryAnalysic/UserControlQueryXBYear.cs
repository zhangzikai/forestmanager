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
    using Utilities;

    public class UserControlQueryXBYear : UserControlBase1
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
        private const string mClassName = "QueryAnalysic.UserControlQueryYear2";
        private string mEditKind = "小班";
        private string mEditKind2 = "XB";
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
        private const string myClassName = "查看年度小班变更图层";
        private Panel panel1;
        private Panel panel2;
        private Panel panel7;
        private Panel panel8;
        private PanelControl panelControlColor;
        private RadioGroup radioGroupKind;
        private RadioGroup radioGroupY;
        private SpinEdit spinEdit1;

        public UserControlQueryXBYear()
        {
            this.InitializeComponent();
        }

        private void AddLayer(string sName, string sYear, IFeatureClass pFClass)
        {
            try
            {
                IMapDocument document = null;
                document = new MapDocumentClass();
                IEnvelope areaOfInterest = null;
                string sDocument = UtilFactory.GetConfigOpt().RootPath + @"\Template\" + sName.Replace("_" + sYear, "") + ".lyr";
                document.Open(sDocument, "");
                ILayer layer = null;
                IFeatureLayer layer2 = null;
                IGeoFeatureLayer layer3 = null;
                if (document.DocumentType == esriMapDocumentType.esriMapDocumentTypeLyr)
                {
                    layer = document.get_Layer(0, 0);
                    layer2 = (IFeatureLayer) layer;
                    layer3 = (IGeoFeatureLayer) layer2;
                    IFeatureRenderer renderer = layer3.Renderer;
                    try
                    {
                        ((IFeatureLayer) layer).FeatureClass = pFClass;
                    }
                    catch (Exception)
                    {
                    }
                    areaOfInterest = layer2.AreaOfInterest;
                }
                document.Close();
                layer.Name = sName;
                this.mGLayer.Add(layer);
                this.mGLayer.Visible = true;
                layer.Visible = true;
                if (areaOfInterest != null)
                {
                    this.mHookHelper.ActiveView.FullExtent = areaOfInterest;
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "QueryAnalysic.UserControlQueryYear2", "AddLayer", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
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
                            this.mHookHelper.ActiveView.FullExtent = (layer as IFeatureLayer).AreaOfInterest;
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
                this.mErrOpt.ErrorOperate(this.mSubSysName, "QueryAnalysic.UserControlQueryYear2", "ButtonQuery_Click", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
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
                this.mErrOpt.ErrorOperate(this.mSubSysName, "QueryAnalysic.UserControlQueryYear2", "Hook", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void InitializeComponent()
        {
            this.components = new Container();
            ComponentResourceManager resources = new ComponentResourceManager(typeof(UserControlQueryXBYear));
            this.panel7 = new Panel();
            this.ButtonQuery = new SimpleButton();
            this.ImageList1 = new ImageList(this.components);
            this.panel8 = new Panel();
            this.ButtonLocationClear = new SimpleButton();
            this.groupControl = new GroupControl();
            this.panel2 = new Panel();
            this.radioGroupY = new RadioGroup();
            this.cListBoxY = new CheckedListBoxControl();
            this.label4 = new Label();
            this.groupControlKind = new GroupControl();
            this.panel1 = new Panel();
            this.panelControlColor = new PanelControl();
            this.colorEdit2 = new ColorEdit();
            this.label2 = new Label();
            this.spinEdit1 = new SpinEdit();
            this.label3 = new Label();
            this.colorEdit1 = new ColorEdit();
            this.label1 = new Label();
            this.cListBoxKind = new CheckedListBoxControl();
            this.radioGroupKind = new RadioGroup();
            this.panel7.SuspendLayout();
            this.groupControl.BeginInit();
            this.groupControl.SuspendLayout();
            this.panel2.SuspendLayout();
            this.radioGroupY.Properties.BeginInit();
            ((ISupportInitialize) this.cListBoxY).BeginInit();
            this.groupControlKind.BeginInit();
            this.groupControlKind.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panelControlColor.BeginInit();
            this.panelControlColor.SuspendLayout();
            this.colorEdit2.Properties.BeginInit();
            this.spinEdit1.Properties.BeginInit();
            this.colorEdit1.Properties.BeginInit();
            ((ISupportInitialize) this.cListBoxKind).BeginInit();
            this.radioGroupKind.Properties.BeginInit();
            base.SuspendLayout();
            this.panel7.Controls.Add(this.ButtonQuery);
            this.panel7.Controls.Add(this.panel8);
            this.panel7.Controls.Add(this.ButtonLocationClear);
            this.panel7.Dock = DockStyle.Bottom;
            this.panel7.Location = new System.Drawing.Point(0, 550);
            this.panel7.Name = "panel7";
            this.panel7.Padding = new Padding(7, 7, 0, 0);
            this.panel7.Size = new Size(300, 0x21);
            this.panel7.TabIndex = 0x10;
            this.ButtonQuery.Dock = DockStyle.Right;
            this.ButtonQuery.ImageIndex = 0x10;
            this.ButtonQuery.ImageList = this.ImageList1;
            this.ButtonQuery.ImageLocation = ImageLocation.MiddleLeft;
            this.ButtonQuery.Location = new System.Drawing.Point(0xa3, 7);
            this.ButtonQuery.Name = "ButtonQuery";
            this.ButtonQuery.Size = new Size(0x41, 0x1a);
            this.ButtonQuery.TabIndex = 11;
            this.ButtonQuery.Text = "查看";
            this.ButtonQuery.ToolTip = "查看";
            this.ButtonQuery.Click += new EventHandler(this.ButtonQuery_Click);
            this.ImageList1.ImageStream = (ImageListStreamer) resources.GetObject("ImageList1.ImageStream");
            this.ImageList1.TransparentColor = Color.Transparent;
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
            this.ImageList1.Images.SetKeyName(0x10, "(30,24).png");
            this.ImageList1.Images.SetKeyName(0x11, "(00,02).png");
            this.ImageList1.Images.SetKeyName(0x12, "(00,17).png");
            this.ImageList1.Images.SetKeyName(0x13, "(00,46).png");
            this.ImageList1.Images.SetKeyName(20, "(01,10).png");
            this.ImageList1.Images.SetKeyName(0x15, "(01,25).png");
            this.ImageList1.Images.SetKeyName(0x16, "(05,32).png");
            this.ImageList1.Images.SetKeyName(0x17, "(06,32).png");
            this.ImageList1.Images.SetKeyName(0x18, "(07,32).png");
            this.ImageList1.Images.SetKeyName(0x19, "(08,32).png");
            this.ImageList1.Images.SetKeyName(0x1a, "(08,36).png");
            this.ImageList1.Images.SetKeyName(0x1b, "(09,36).png");
            this.ImageList1.Images.SetKeyName(0x1c, "(10,26).png");
            this.ImageList1.Images.SetKeyName(0x1d, "(11,26).png");
            this.ImageList1.Images.SetKeyName(30, "(11,29).png");
            this.ImageList1.Images.SetKeyName(0x1f, "(12,29).png");
            this.ImageList1.Images.SetKeyName(0x20, "(11,32).png");
            this.ImageList1.Images.SetKeyName(0x21, "(11,36).png");
            this.ImageList1.Images.SetKeyName(0x22, "(13,32).png");
            this.ImageList1.Images.SetKeyName(0x23, "(19,31).png");
            this.ImageList1.Images.SetKeyName(0x24, "(22,18).png");
            this.ImageList1.Images.SetKeyName(0x25, "(25,27).png");
            this.ImageList1.Images.SetKeyName(0x26, "(29,43).png");
            this.ImageList1.Images.SetKeyName(0x27, "(30,14).png");
            this.ImageList1.Images.SetKeyName(40, "5.png");
            this.ImageList1.Images.SetKeyName(0x29, "10.png");
            this.ImageList1.Images.SetKeyName(0x2a, "11.png");
            this.ImageList1.Images.SetKeyName(0x2b, "16.png");
            this.ImageList1.Images.SetKeyName(0x2c, "17.png");
            this.ImageList1.Images.SetKeyName(0x2d, "18.png");
            this.ImageList1.Images.SetKeyName(0x2e, "19.png");
            this.ImageList1.Images.SetKeyName(0x2f, "20.png");
            this.ImageList1.Images.SetKeyName(0x30, "21.png");
            this.ImageList1.Images.SetKeyName(0x31, "22.png");
            this.ImageList1.Images.SetKeyName(50, "25.png");
            this.ImageList1.Images.SetKeyName(0x33, "31.png");
            this.ImageList1.Images.SetKeyName(0x34, "41.png");
            this.ImageList1.Images.SetKeyName(0x35, "add.png");
            this.ImageList1.Images.SetKeyName(0x36, "bullet_minus.png");
            this.ImageList1.Images.SetKeyName(0x37, "control_add_blue.png");
            this.ImageList1.Images.SetKeyName(0x38, "control_power_blue.png");
            this.ImageList1.Images.SetKeyName(0x39, "control_remove_blue.png");
            this.ImageList1.Images.SetKeyName(0x3a, "cross.png");
            this.ImageList1.Images.SetKeyName(0x3b, "down.png");
            this.ImageList1.Images.SetKeyName(60, "draw_tools.png");
            this.ImageList1.Images.SetKeyName(0x3d, "Feedicons_v2_010.png");
            this.ImageList1.Images.SetKeyName(0x3e, "Feedicons_v2_011.png");
            this.ImageList1.Images.SetKeyName(0x3f, "Feedicons_v2_031.png");
            this.ImageList1.Images.SetKeyName(0x40, "Feedicons_v2_032.png");
            this.ImageList1.Images.SetKeyName(0x41, "Feedicons_v2_033.png");
            this.ImageList1.Images.SetKeyName(0x42, "flag blue.png");
            this.ImageList1.Images.SetKeyName(0x43, "flag red.png");
            this.ImageList1.Images.SetKeyName(0x44, "flag yellow.png");
            this.ImageList1.Images.SetKeyName(0x45, "(44,23).png");
            this.ImageList1.Images.SetKeyName(70, "(12,29).png");
            this.ImageList1.Images.SetKeyName(0x47, "(34,00).png");
            this.ImageList1.Images.SetKeyName(0x48, "(03,02).png");
            this.ImageList1.Images.SetKeyName(0x49, "(49,06).png");
            this.ImageList1.Images.SetKeyName(0x4a, "(09,13).png");
            this.ImageList1.Images.SetKeyName(0x4b, "(16,47).png");
            this.ImageList1.Images.SetKeyName(0x4c, "(13,47).png");
            this.ImageList1.Images.SetKeyName(0x4d, "(18,01).png");
            this.ImageList1.Images.SetKeyName(0x4e, "(18,13).png");
            this.ImageList1.Images.SetKeyName(0x4f, "(19,01).png");
            this.ImageList1.Images.SetKeyName(80, "(28,40).png");
            this.ImageList1.Images.SetKeyName(0x51, "(39,47).png");
            this.ImageList1.Images.SetKeyName(0x52, "(45,12).png");
            this.ImageList1.Images.SetKeyName(0x53, "(45,17).png");
            this.ImageList1.Images.SetKeyName(0x54, "(45,41).png");
            this.ImageList1.Images.SetKeyName(0x55, "arrow_refresh_small.png");
            this.ImageList1.Images.SetKeyName(0x56, "(11,29).png");
            this.ImageList1.Images.SetKeyName(0x57, "(12,29).png");
            this.ImageList1.Images.SetKeyName(0x58, "(12,11).png");
            this.panel8.Dock = DockStyle.Right;
            this.panel8.Location = new System.Drawing.Point(0xe4, 7);
            this.panel8.Name = "panel8";
            this.panel8.Size = new Size(7, 0x1a);
            this.panel8.TabIndex = 15;
            this.panel8.Visible = false;
            this.ButtonLocationClear.Dock = DockStyle.Right;
            this.ButtonLocationClear.ImageIndex = 0x38;
            this.ButtonLocationClear.ImageList = this.ImageList1;
            this.ButtonLocationClear.ImageLocation = ImageLocation.MiddleLeft;
            this.ButtonLocationClear.Location = new System.Drawing.Point(0xeb, 7);
            this.ButtonLocationClear.Name = "ButtonLocationClear";
            this.ButtonLocationClear.Size = new Size(0x41, 0x1a);
            this.ButtonLocationClear.TabIndex = 14;
            this.ButtonLocationClear.Text = "重置";
            this.ButtonLocationClear.ToolTip = "重置图层";
            this.ButtonLocationClear.Visible = false;
            this.groupControl.Appearance.BackColor = Color.White;
            this.groupControl.Appearance.BackColor2 = Color.White;
            this.groupControl.Appearance.Options.UseBackColor = true;
            this.groupControl.Controls.Add(this.panel2);
            this.groupControl.Dock = DockStyle.Top;
            this.groupControl.Location = new System.Drawing.Point(0, 0);
            this.groupControl.Name = "groupControl";
            this.groupControl.Padding = new Padding(1);
            this.groupControl.Size = new Size(300, 0x69);
            this.groupControl.TabIndex = 0x11;
            this.groupControl.Text = "小班更新年份";
            this.groupControl.Paint += new PaintEventHandler(this.groupControl_Paint);
            this.panel2.Controls.Add(this.radioGroupY);
            this.panel2.Controls.Add(this.cListBoxY);
            this.panel2.Dock = DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 0x18);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new Padding(7);
            this.panel2.Size = new Size(0x126, 0x4e);
            this.panel2.TabIndex = 13;
            this.radioGroupY.Dock = DockStyle.Fill;
            this.radioGroupY.Location = new System.Drawing.Point(0x56, 7);
            this.radioGroupY.Name = "radioGroupY";
            this.radioGroupY.Properties.Appearance.BackColor = Color.White;
            this.radioGroupY.Properties.Appearance.Options.UseBackColor = true;
            this.radioGroupY.Properties.BorderStyle = BorderStyles.NoBorder;
            this.radioGroupY.Properties.Items.AddRange(new RadioGroupItem[] { new RadioGroupItem(null, "可见图层查看结果"), new RadioGroupItem(null, "二类小班查看结果"), new RadioGroupItem(null, "造林地块查看结果"), new RadioGroupItem(null, "采伐地块查看结果") });
            this.radioGroupY.Size = new Size(0xc9, 0x40);
            this.radioGroupY.TabIndex = 12;
            this.cListBoxY.BorderStyle = BorderStyles.NoBorder;
            this.cListBoxY.CheckOnClick = true;
            this.cListBoxY.Dock = DockStyle.Left;
            this.cListBoxY.ItemHeight = 20;
            this.cListBoxY.Items.AddRange(new CheckedListBoxItem[] { new CheckedListBoxItem(null), new CheckedListBoxItem(null) });
            this.cListBoxY.Location = new System.Drawing.Point(7, 7);
            this.cListBoxY.Name = "cListBoxY";
            this.cListBoxY.Size = new Size(0x4f, 0x40);
            this.cListBoxY.TabIndex = 0;
            this.cListBoxY.Visible = false;
            this.cListBoxY.SelectedIndexChanged += new EventHandler(this.cListBoxY_SelectedIndexChanged);
            this.label4.Dock = DockStyle.Top;
            this.label4.Location = new System.Drawing.Point(0, 0x69);
            this.label4.Name = "label4";
            this.label4.Size = new Size(300, 10);
            this.label4.TabIndex = 0x13;
            this.label4.TextAlign = ContentAlignment.MiddleLeft;
            this.groupControlKind.Appearance.BackColor = Color.White;
            this.groupControlKind.Appearance.BackColor2 = Color.White;
            this.groupControlKind.Appearance.Options.UseBackColor = true;
            this.groupControlKind.Controls.Add(this.panel1);
            this.groupControlKind.Dock = DockStyle.Fill;
            this.groupControlKind.Location = new System.Drawing.Point(0, 0x73);
            this.groupControlKind.Name = "groupControlKind";
            this.groupControlKind.Padding = new Padding(1);
            this.groupControlKind.Size = new Size(300, 0x1b3);
            this.groupControlKind.TabIndex = 20;
            this.groupControlKind.Text = "显示方式";
            this.panel1.Controls.Add(this.panelControlColor);
            this.panel1.Controls.Add(this.cListBoxKind);
            this.panel1.Controls.Add(this.radioGroupKind);
            this.panel1.Dock = DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 0x18);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new Padding(7);
            this.panel1.Size = new Size(0x126, 0x198);
            this.panel1.TabIndex = 5;
            this.panelControlColor.Appearance.BackColor = Color.White;
            this.panelControlColor.Appearance.BackColor2 = Color.White;
            this.panelControlColor.Appearance.Options.UseBackColor = true;
            this.panelControlColor.Controls.Add(this.colorEdit2);
            this.panelControlColor.Controls.Add(this.label2);
            this.panelControlColor.Controls.Add(this.spinEdit1);
            this.panelControlColor.Controls.Add(this.label3);
            this.panelControlColor.Controls.Add(this.colorEdit1);
            this.panelControlColor.Controls.Add(this.label1);
            this.panelControlColor.Location = new System.Drawing.Point(0x4c, 8);
            this.panelControlColor.Name = "panelControlColor";
            this.panelControlColor.Size = new Size(210, 0x16);
            this.panelControlColor.TabIndex = 3;
            this.panelControlColor.TabStop = true;
            this.colorEdit2.Dock = DockStyle.Left;
            this.colorEdit2.EditValue = Color.Transparent;
            this.colorEdit2.Location = new System.Drawing.Point(0xa9, 2);
            this.colorEdit2.Name = "colorEdit2";
            this.colorEdit2.Properties.BorderStyle = BorderStyles.NoBorder;
            this.colorEdit2.Properties.Buttons.AddRange(new EditorButton[] { new EditorButton(ButtonPredefines.Combo) });
            this.colorEdit2.Size = new Size(40, 0x13);
            this.colorEdit2.TabIndex = 4;
            this.label2.Dock = DockStyle.Left;
            this.label2.Location = new System.Drawing.Point(0x88, 2);
            this.label2.Name = "label2";
            this.label2.Size = new Size(0x21, 0x12);
            this.label2.TabIndex = 5;
            this.label2.Text = "填充";
            this.label2.TextAlign = ContentAlignment.MiddleCenter;
            this.spinEdit1.Dock = DockStyle.Left;
            int[] bits = new int[4];
            bits[0] = 1;
            this.spinEdit1.EditValue = new decimal(bits);
            this.spinEdit1.Location = new System.Drawing.Point(0x6c, 2);
            this.spinEdit1.Name = "spinEdit1";
            this.spinEdit1.Properties.BorderStyle = BorderStyles.NoBorder;
            this.spinEdit1.Properties.Buttons.AddRange(new EditorButton[] { new EditorButton() });
            this.spinEdit1.Properties.MaxLength = 2;
            int[] numArray2 = new int[4];
            numArray2[0] = 0x63;
            this.spinEdit1.Properties.MaxValue = new decimal(numArray2);
            int[] numArray3 = new int[4];
            numArray3[0] = 1;
            this.spinEdit1.Properties.MinValue = new decimal(numArray3);
            this.spinEdit1.Size = new Size(0x1c, 0x13);
            this.spinEdit1.TabIndex = 8;
            this.label3.Dock = DockStyle.Left;
            this.label3.Location = new System.Drawing.Point(0x4b, 2);
            this.label3.Name = "label3";
            this.label3.Size = new Size(0x21, 0x12);
            this.label3.TabIndex = 7;
            this.label3.Text = "宽度";
            this.label3.TextAlign = ContentAlignment.MiddleCenter;
            this.colorEdit1.Dock = DockStyle.Left;
            this.colorEdit1.EditValue = Color.Red;
            this.colorEdit1.Location = new System.Drawing.Point(0x23, 2);
            this.colorEdit1.Name = "colorEdit1";
            this.colorEdit1.Properties.BorderStyle = BorderStyles.NoBorder;
            this.colorEdit1.Properties.Buttons.AddRange(new EditorButton[] { new EditorButton(ButtonPredefines.Combo) });
            this.colorEdit1.Size = new Size(40, 0x13);
            this.colorEdit1.TabIndex = 2;
            this.label1.Dock = DockStyle.Left;
            this.label1.Location = new System.Drawing.Point(2, 2);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0x21, 0x12);
            this.label1.TabIndex = 3;
            this.label1.Text = "边框";
            this.label1.TextAlign = ContentAlignment.MiddleCenter;
            this.cListBoxKind.BorderStyle = BorderStyles.NoBorder;
            this.cListBoxKind.CheckOnClick = true;
            this.cListBoxKind.Dock = DockStyle.Fill;
            this.cListBoxKind.ItemHeight = 0x18;
            this.cListBoxKind.Items.AddRange(new CheckedListBoxItem[] { new CheckedListBoxItem("单一值"), new CheckedListBoxItem("人为更新"), new CheckedListBoxItem("自然更新"), new CheckedListBoxItem("更新来源"), new CheckedListBoxItem("地类"), new CheckedListBoxItem("林地权属"), new CheckedListBoxItem("林木权属"), new CheckedListBoxItem("林种"), new CheckedListBoxItem("树种"), new CheckedListBoxItem("起源"), new CheckedListBoxItem("龄组") });
            this.cListBoxKind.Location = new System.Drawing.Point(7, 7);
            this.cListBoxKind.MultiColumn = true;
            this.cListBoxKind.Name = "cListBoxKind";
            this.cListBoxKind.Size = new Size(280, 0x128);
            this.cListBoxKind.TabIndex = 4;
            this.radioGroupKind.Dock = DockStyle.Bottom;
            this.radioGroupKind.Location = new System.Drawing.Point(7, 0x12f);
            this.radioGroupKind.Name = "radioGroupKind";
            this.radioGroupKind.Properties.BorderStyle = BorderStyles.NoBorder;
            this.radioGroupKind.Properties.Items.AddRange(new RadioGroupItem[] { new RadioGroupItem(null, "地类"), new RadioGroupItem(null, "林种"), new RadioGroupItem(null, "保护等级"), new RadioGroupItem(null, "生态区位") });
            this.radioGroupKind.Size = new Size(280, 0x62);
            this.radioGroupKind.TabIndex = 0x67;
            this.radioGroupKind.Visible = false;
            base.Appearance.BackColor = Color.FromArgb(0xe3, 0xf1, 0xfe);
            base.Appearance.BackColor2 = Color.FromArgb(0xe3, 0xf1, 0xfe);
            base.Appearance.Options.UseBackColor = true;
            base.AutoScaleDimensions = new SizeF(7f, 14f);
//            base.AutoScaleMode = AutoScaleMode.Font;
            base.Controls.Add(this.groupControlKind);
            base.Controls.Add(this.label4);
            base.Controls.Add(this.groupControl);
            base.Controls.Add(this.panel7);
            base.Name = "UserControlQueryXBYear";
            base.Size = new Size(300, 0x247);
            this.panel7.ResumeLayout(false);
            this.groupControl.EndInit();
            this.groupControl.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.radioGroupY.Properties.EndInit();
            ((ISupportInitialize) this.cListBoxY).EndInit();
            this.groupControlKind.EndInit();
            this.groupControlKind.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panelControlColor.EndInit();
            this.panelControlColor.ResumeLayout(false);
            this.colorEdit2.Properties.EndInit();
            this.spinEdit1.Properties.EndInit();
            this.colorEdit1.Properties.EndInit();
            ((ISupportInitialize) this.cListBoxKind).EndInit();
            this.radioGroupKind.Properties.EndInit();
            base.ResumeLayout(false);
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
                this.mErrOpt.ErrorOperate(this.mSubSysName, "QueryAnalysic.UserControlQueryYear2", "InitialKindList", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        public void InitialValue()
        {
            try
            {
                string str;
                IDataset editDataset;
                string str7;
                if (((this.mHookHelper != null) && (this.mHookHelper.FocusMap != null)) && (this.mHookHelper.FocusMap.LayerCount != 0))
                {
                    if (this.mEditKind == "小班")
                    {
                        this.mKindCode = "5";
                        this.mEditKind2 = "XB";
                        this.cListBoxKind.Items[5].Enabled = true;
                        goto Label_0087;
                    }
                    this.mKindCode = "";
                }
                return;
            Label_0087:
                str = UtilFactory.GetConfigOpt().RootPath + @"\" + UtilFactory.GetConfigOpt().GetConfigValue("EditDataPath");
                IFeatureWorkspace pfw = null;
                if (str.Contains(".gdb") || str.Contains(".GDB"))
                {
                    pfw = GISFunFactory.WorkspaceFun.GetFeatureWorkspace(str, WorkspaceSource.esriWSFileGDBWorkspaceFactory);
                }
                else if (str.Contains(".mdb") || str.Contains(".MDB"))
                {
                    pfw = GISFunFactory.WorkspaceFun.GetFeatureWorkspace(str, WorkspaceSource.esriWSAccessWorkspaceFactory);
                }
                if (pfw == null)
                {
                    return;
                }
                string str2 = "";
                if (this.m_EditLayer == null)
                {
                    editDataset = QueryFun.GetEditDataset(this.mEditKind2 + "DatasetName", pfw);
                    if (editDataset == null)
                    {
                        goto Label_0301;
                    }
                    string[] strArray = editDataset.Name.Split(new char[] { '_' });
                    string str3 = strArray[strArray.Length - 1];
                    string name = UtilFactory.GetConfigOpt().GetConfigValue(this.mEditKind2 + "DatasetName2");
                    if (name != "")
                    {
                        pfw.OpenFeatureDataset(name);
                    }
                    str2 = UtilFactory.GetConfigOpt().GetConfigValue(this.mEditKind2 + "Layer") + "_" + str3;
                }
                else
                {
                    editDataset = this.m_EditLayer.FeatureClass as IDataset;
                    str2 = editDataset.Name;
                    editDataset = this.m_EditLayer.FeatureClass.FeatureDataset;
                }
                IEnumDataset subsets = editDataset.Subsets;
                editDataset = subsets.Next();
                while (editDataset != null)
                {
                    if (str2 == editDataset.Name)
                    {
                        this.m_EditFeatureClass = editDataset as IFeatureClass;
                        break;
                    }
                    editDataset = subsets.Next();
                }
                this.groupControl.Height = 100;
                this.cListBoxY.Items.Clear();
                this.radioGroupY.Properties.Items.Clear();
                this.mLayerList = new ArrayList();
                string configValue = UtilFactory.GetConfigOpt().GetConfigValue(this.mEditKind2 + "Layer");
                if (this.m_EditFeatureClass != null)
                {
                    string str6 = editDataset.Name.Substring(configValue.Length + 1, (str2.Length - configValue.Length) - 1) + "年";
                    this.cListBoxY.Items.Add(str6, false);
                    this.radioGroupY.Properties.Items.AddRange(new RadioGroupItem[] { new RadioGroupItem(null, str6) });
                    this.mLayerList.Add(this.m_EditFeatureClass);
                }
            Label_0301:
                str7 = UtilFactory.GetConfigOpt().GetConfigValue(this.mEditKind2 + "DatasetName");
                configValue = UtilFactory.GetConfigOpt().GetConfigValue(this.mEditKind2 + "Layer");
                IFeatureDataset dataset3 = pfw.OpenFeatureDataset(str7) as IFeatureDataset;
                IEnumDataset dataset4 = dataset3.Subsets;
                IDataset dataset5 = dataset4.Next();
                IFeatureClass class2 = null;
                while (dataset5 != null)
                {
                    if (dataset5.Type == esriDatasetType.esriDTFeatureClass)
                    {
                        class2 = dataset5 as IFeatureClass;
                        if (((dataset5.Name.Contains(configValue) && (dataset5.Name.Length > configValue.Length)) && (((this.m_EditFeatureClass as IDataset).Name != dataset5.Name) && !dataset5.Name.Contains("_Templ"))) && (dataset5.Name.Contains(configValue) && !dataset5.Name.Contains("task")))
                        {
                            string str8 = dataset5.Name.Substring(configValue.Length + 1, (dataset5.Name.Length - configValue.Length) - 1) + "年";
                            if (str8.Length == 5)
                            {
                                this.cListBoxY.Items.Add(str8, false);
                                this.radioGroupY.Properties.Items.AddRange(new RadioGroupItem[] { new RadioGroupItem(null, str8) });
                                this.mLayerList.Add(class2);
                            }
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
                            string str9 = this.cListBoxY.Items[j].Value.ToString().Replace("年", "");
                            if (layer2.Name.Contains(str9))
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
                this.mErrOpt.ErrorOperate(this.mSubSysName, "QueryAnalysic.UserControlQueryYear2", "InitialValue", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
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

