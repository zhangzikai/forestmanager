namespace Cartography.Element
{
    using Cartography;
    using DevExpress.Utils;
    using DevExpress.XtraEditors;
    using DevExpress.XtraEditors.Controls;
    using ESRI.ArcGIS.Carto;
    using ESRI.ArcGIS.Controls;
    using ESRI.ArcGIS.Display;
    using ESRI.ArcGIS.esriSystem;
    using FormBase;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.IO;
    using System.Windows.Forms;

    public class FrameSymbolSelector : FormBase3
    {
        private AxSymbologyControl axSymbologyControl1;
        private ColorEdit btBackFillColor;
        private ColorEdit btBackOutLineColor;
        private SimpleButton btCancel;
        private ColorEdit btColor;
        private SimpleButton btOk;
        private ColorEdit btShadowFillColor;
        private ColorEdit btShadowOutLineColor;
        private IContainer components;
        private GroupBox gbBack;
        private GroupBox gbBorder;
        private GroupBox gbShadow;
        private GroupBox groupBox1;
        private bool hasSelected;
        private LabelControl labelControl2;
        private LabelControl labelControl3;
        private LabelControl lbFillColor;
        private LabelControl lbOutLineColor;
        private LabelControl lbOutLineWidth;
        private LabelControl lbShadowColor;
        private LabelControl lbShadowOLColor;
        private LabelControl lbShadowWidth;
        public IStyleGalleryItem m_styleGalleryItem;
        private SpinEdit nudBackOutLine;
        private SpinEdit nudShadowOutLine;
        private SpinEdit numericUpDown1;
        private PictureEdit pictureBox1;
        private IColor selectColor;
        private string visibeState;

        public FrameSymbolSelector()
        {
            this.InitializeComponent();
        }

        private void axSymbologyControl1_OnItemSelected(object sender, ISymbologyControlEvents_OnItemSelectedEvent e)
        {
            IStyleGalleryItem styleGalleryItem = (IStyleGalleryItem) e.styleGalleryItem;
            IObjectCopy copy = new ObjectCopyClass();
            object pInObject = copy.Copy(styleGalleryItem);
            object pOverwriteObject = this.m_styleGalleryItem;
            copy.Overwrite(pInObject, ref pOverwriteObject);
            this.InitialControl();
            this.PreviewImage();
        }

        private void btBackFillColor_ColorChanged(object sender, EventArgs e)
        {
            ISymbolBackground item = (ISymbolBackground) this.m_styleGalleryItem.Item;
            IFillSymbol fillSymbol = item.FillSymbol;
            fillSymbol.Color = ColorService.NetColorToEsriColor(this.btBackFillColor.Color);
            item.FillSymbol = fillSymbol;
            this.PreviewImage();
        }

        private void btBackOutLineColor_ColorChanged(object sender, EventArgs e)
        {
            ISymbolBackground item = (ISymbolBackground) this.m_styleGalleryItem.Item;
            IFillSymbol fillSymbol = item.FillSymbol;
            ILineSymbol outline = fillSymbol.Outline;
            outline.Color = ColorService.NetColorToEsriColor(this.btBackOutLineColor.Color);
            fillSymbol.Outline = outline;
            item.FillSymbol = fillSymbol;
            this.PreviewImage();
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            base.DialogResult = DialogResult.Cancel;
            this.m_styleGalleryItem = null;
            base.Close();
        }

        private void btColor_ColorChanged(object sender, EventArgs e)
        {
            ISymbolBorder item = (ISymbolBorder) this.m_styleGalleryItem.Item;
            ILineSymbol lineSymbol = item.LineSymbol;
            lineSymbol.Color = ColorService.NetColorToEsriColor(this.btColor.Color);
            item.LineSymbol = lineSymbol;
            this.PreviewImage();
        }

        private void btOk_Click(object sender, EventArgs e)
        {
            base.DialogResult = DialogResult.OK;
            this.hasSelected = true;
            base.Close();
        }

        private void btShadowFillColor_ColorChanged(object sender, EventArgs e)
        {
            ISymbolShadow item = (ISymbolShadow) this.m_styleGalleryItem.Item;
            IFillSymbol fillSymbol = item.FillSymbol;
            fillSymbol.Color = ColorService.NetColorToEsriColor(this.btShadowFillColor.Color);
            item.FillSymbol = fillSymbol;
            this.PreviewImage();
        }

        private void btShadowOutLineColor_ColorChanged(object sender, EventArgs e)
        {
            ISymbolShadow item = (ISymbolShadow) this.m_styleGalleryItem.Item;
            IFillSymbol fillSymbol = item.FillSymbol;
            ILineSymbol outline = fillSymbol.Outline;
            outline.Color = ColorService.NetColorToEsriColor(this.btShadowOutLineColor.Color);
            fillSymbol.Outline = outline;
            item.FillSymbol = fillSymbol;
            this.PreviewImage();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void FrameSymbolSelector_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!this.hasSelected)
            {
                base.DialogResult = DialogResult.Cancel;
            }
        }

        private void FrameSymbolSelector_Load(object sender, EventArgs e)
        {
            string fileName = "";
            try
            {
                fileName = ElementService.StyleGalleryFile;
            }
            catch (FileNotFoundException exception)
            {
                XtraMessageBox.Show(exception.Message, "提示", MessageBoxButtons.OK);
                return;
            }
            this.axSymbologyControl1.LoadStyleFile(fileName);
            this.PreviewImage();
        }

        public IStyleGalleryItem GetItem(object pFramePro, esriSymbologyStyleClass pStyleClass)
        {
            ISymbolBorder border = null;
            ISymbolBackground background = null;
            ISymbolShadow shadow = null;
            ISymbol lineSymbol = null;
            if (pFramePro is ISymbolBorder)
            {
                border = (ISymbolBorder) pFramePro;
                lineSymbol = (ISymbol) border.LineSymbol;
            }
            if (pFramePro is ISymbolBackground)
            {
                background = (ISymbolBackground) pFramePro;
                lineSymbol = (ISymbol) background.FillSymbol;
            }
            if (pFramePro is ISymbolShadow)
            {
                shadow = (ISymbolShadow) pFramePro;
                lineSymbol = (ISymbol) shadow.FillSymbol;
            }
            this.axSymbologyControl1.StyleClass = pStyleClass;
            IStyleGalleryItem item = new ServerStyleGalleryItemClass();
            item.Name = "无";
            switch (pStyleClass)
            {
                case esriSymbologyStyleClass.esriStyleClassBorders:
                {
                    this.gbBorder.Visible = true;
                    this.gbShadow.Visible = false;
                    this.gbBack.Visible = false;
                    this.visibeState = "2";
                    item.Item = new SymbolBorderClass();
                    ISymbolBorder border2 = (ISymbolBorder) item.Item;
                    ILineSymbol symbol3 = border2.LineSymbol;
                    symbol3.Width = 0.0;
                    border2.LineSymbol = symbol3;
                    break;
                }
                case esriSymbologyStyleClass.esriStyleClassBackgrounds:
                {
                    this.gbBack.Visible = true;
                    this.gbBorder.Visible = false;
                    this.gbShadow.Visible = false;
                    this.visibeState = "3";
                    item.Item = new SymbolBackgroundClass();
                    ISymbolBackground background2 = (ISymbolBackground) item.Item;
                    IFillSymbol fillSymbol = background2.FillSymbol;
                    this.MakeNoneSymbol(fillSymbol);
                    background2.FillSymbol = fillSymbol;
                    break;
                }
                case esriSymbologyStyleClass.esriStyleClassShadows:
                {
                    this.gbShadow.Visible = true;
                    this.gbBorder.Visible = false;
                    this.gbBack.Visible = false;
                    this.visibeState = "1";
                    item.Item = new SymbolShadowClass();
                    ISymbolShadow shadow2 = (ISymbolShadow) item.Item;
                    IFillSymbol pFillSymbol = shadow2.FillSymbol;
                    this.MakeNoneSymbol(pFillSymbol);
                    shadow2.FillSymbol = pFillSymbol;
                    break;
                }
            }
            this.axSymbologyControl1.GetStyleClass(this.axSymbologyControl1.StyleClass).AddItem(item, 0);
            this.m_styleGalleryItem = new ServerStyleGalleryItemClass();
            if (lineSymbol != null)
            {
                this.m_styleGalleryItem.Item = pFramePro;
                this.InitialControl();
            }
            base.ShowDialog();
            return this.m_styleGalleryItem;
        }

        private void InitialControl()
        {
            if (this.visibeState == "3")
            {
                ISymbolBackground item = (ISymbolBackground) this.m_styleGalleryItem.Item;
                this.btBackFillColor.Color = ColorService.EsriColorToNetColor(item.FillSymbol.Color);
                this.btBackOutLineColor.Color = ColorService.EsriColorToNetColor(item.FillSymbol.Outline.Color);
                this.nudBackOutLine.Value = decimal.Parse(item.FillSymbol.Outline.Width.ToString());
            }
            else if (this.visibeState == "2")
            {
                ISymbolBorder border = (ISymbolBorder) this.m_styleGalleryItem.Item;
                this.btColor.Color = ColorService.EsriColorToNetColor(border.LineSymbol.Color);
                this.numericUpDown1.Value = decimal.Parse(border.LineSymbol.Width.ToString());
            }
            else
            {
                ISymbolShadow shadow = (ISymbolShadow) this.m_styleGalleryItem.Item;
                this.btShadowFillColor.Color = ColorService.EsriColorToNetColor(shadow.FillSymbol.Color);
                this.btShadowOutLineColor.Color = ColorService.EsriColorToNetColor(shadow.FillSymbol.Outline.Color);
                this.nudShadowOutLine.Value = decimal.Parse(shadow.FillSymbol.Outline.Width.ToString());
            }
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrameSymbolSelector));
            this.axSymbologyControl1 = new ESRI.ArcGIS.Controls.AxSymbologyControl();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new DevExpress.XtraEditors.PictureEdit();
            this.gbShadow = new System.Windows.Forms.GroupBox();
            this.btShadowOutLineColor = new DevExpress.XtraEditors.ColorEdit();
            this.btShadowFillColor = new DevExpress.XtraEditors.ColorEdit();
            this.nudShadowOutLine = new DevExpress.XtraEditors.SpinEdit();
            this.lbShadowOLColor = new DevExpress.XtraEditors.LabelControl();
            this.lbShadowWidth = new DevExpress.XtraEditors.LabelControl();
            this.lbShadowColor = new DevExpress.XtraEditors.LabelControl();
            this.gbBack = new System.Windows.Forms.GroupBox();
            this.btBackOutLineColor = new DevExpress.XtraEditors.ColorEdit();
            this.btBackFillColor = new DevExpress.XtraEditors.ColorEdit();
            this.nudBackOutLine = new DevExpress.XtraEditors.SpinEdit();
            this.lbOutLineColor = new DevExpress.XtraEditors.LabelControl();
            this.lbOutLineWidth = new DevExpress.XtraEditors.LabelControl();
            this.lbFillColor = new DevExpress.XtraEditors.LabelControl();
            this.gbBorder = new System.Windows.Forms.GroupBox();
            this.btColor = new DevExpress.XtraEditors.ColorEdit();
            this.numericUpDown1 = new DevExpress.XtraEditors.SpinEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.btOk = new DevExpress.XtraEditors.SimpleButton();
            this.btCancel = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.axSymbologyControl1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1.Properties)).BeginInit();
            this.gbShadow.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btShadowOutLineColor.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btShadowFillColor.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudShadowOutLine.Properties)).BeginInit();
            this.gbBack.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btBackOutLineColor.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btBackFillColor.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBackOutLine.Properties)).BeginInit();
            this.gbBorder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btColor.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // axSymbologyControl1
            // 
            this.axSymbologyControl1.Location = new System.Drawing.Point(12, 10);
            this.axSymbologyControl1.Name = "axSymbologyControl1";
            this.axSymbologyControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axSymbologyControl1.OcxState")));
            this.axSymbologyControl1.Size = new System.Drawing.Size(305, 419);
            this.axSymbologyControl1.TabIndex = 12;
            this.axSymbologyControl1.OnItemSelected += new ESRI.ArcGIS.Controls.ISymbologyControlEvents_Ax_OnItemSelectedEventHandler(this.axSymbologyControl1_OnItemSelected);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Location = new System.Drawing.Point(380, 12);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(6, 3, 6, 6);
            this.groupBox1.Size = new System.Drawing.Size(196, 146);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "预览";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(3, 21);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Properties.Appearance.Options.UseBackColor = true;
            this.pictureBox1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pictureBox1.Size = new System.Drawing.Size(189, 121);
            this.pictureBox1.TabIndex = 0;
            // 
            // gbShadow
            // 
            this.gbShadow.Controls.Add(this.btShadowOutLineColor);
            this.gbShadow.Controls.Add(this.btShadowFillColor);
            this.gbShadow.Controls.Add(this.nudShadowOutLine);
            this.gbShadow.Controls.Add(this.lbShadowOLColor);
            this.gbShadow.Controls.Add(this.lbShadowWidth);
            this.gbShadow.Controls.Add(this.lbShadowColor);
            this.gbShadow.Location = new System.Drawing.Point(380, 175);
            this.gbShadow.Name = "gbShadow";
            this.gbShadow.Size = new System.Drawing.Size(196, 132);
            this.gbShadow.TabIndex = 18;
            this.gbShadow.TabStop = false;
            this.gbShadow.Text = "设置";
            this.gbShadow.Visible = false;
            // 
            // btShadowOutLineColor
            // 
            this.btShadowOutLineColor.EditValue = System.Drawing.Color.Empty;
            this.btShadowOutLineColor.Location = new System.Drawing.Point(91, 91);
            this.btShadowOutLineColor.Name = "btShadowOutLineColor";
            this.btShadowOutLineColor.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.btShadowOutLineColor.Properties.ColorAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.btShadowOutLineColor.Size = new System.Drawing.Size(70, 20);
            this.btShadowOutLineColor.TabIndex = 22;
            this.btShadowOutLineColor.ColorChanged += new System.EventHandler(this.btShadowOutLineColor_ColorChanged);
            // 
            // btShadowFillColor
            // 
            this.btShadowFillColor.EditValue = System.Drawing.Color.Empty;
            this.btShadowFillColor.Location = new System.Drawing.Point(91, 26);
            this.btShadowFillColor.Name = "btShadowFillColor";
            this.btShadowFillColor.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.btShadowFillColor.Properties.ColorAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.btShadowFillColor.Size = new System.Drawing.Size(70, 20);
            this.btShadowFillColor.TabIndex = 21;
            this.btShadowFillColor.ColorChanged += new System.EventHandler(this.btShadowFillColor_ColorChanged);
            // 
            // nudShadowOutLine
            // 
            this.nudShadowOutLine.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudShadowOutLine.Location = new System.Drawing.Point(91, 57);
            this.nudShadowOutLine.Name = "nudShadowOutLine";
            this.nudShadowOutLine.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.nudShadowOutLine.Size = new System.Drawing.Size(70, 20);
            this.nudShadowOutLine.TabIndex = 19;
            this.nudShadowOutLine.ValueChanged += new System.EventHandler(this.nudShadowOutLine_ValueChanged);
            // 
            // lbShadowOLColor
            // 
            this.lbShadowOLColor.Location = new System.Drawing.Point(22, 91);
            this.lbShadowOLColor.Name = "lbShadowOLColor";
            this.lbShadowOLColor.Size = new System.Drawing.Size(52, 14);
            this.lbShadowOLColor.TabIndex = 18;
            this.lbShadowOLColor.Text = "边框颜色:";
            // 
            // lbShadowWidth
            // 
            this.lbShadowWidth.Location = new System.Drawing.Point(22, 61);
            this.lbShadowWidth.Name = "lbShadowWidth";
            this.lbShadowWidth.Size = new System.Drawing.Size(52, 14);
            this.lbShadowWidth.TabIndex = 17;
            this.lbShadowWidth.Text = "边框宽度:";
            // 
            // lbShadowColor
            // 
            this.lbShadowColor.Location = new System.Drawing.Point(36, 30);
            this.lbShadowColor.Name = "lbShadowColor";
            this.lbShadowColor.Size = new System.Drawing.Size(40, 14);
            this.lbShadowColor.TabIndex = 15;
            this.lbShadowColor.Text = "填充色:";
            // 
            // gbBack
            // 
            this.gbBack.Controls.Add(this.btBackOutLineColor);
            this.gbBack.Controls.Add(this.btBackFillColor);
            this.gbBack.Controls.Add(this.nudBackOutLine);
            this.gbBack.Controls.Add(this.lbOutLineColor);
            this.gbBack.Controls.Add(this.lbOutLineWidth);
            this.gbBack.Controls.Add(this.lbFillColor);
            this.gbBack.Location = new System.Drawing.Point(380, 175);
            this.gbBack.Name = "gbBack";
            this.gbBack.Size = new System.Drawing.Size(196, 132);
            this.gbBack.TabIndex = 19;
            this.gbBack.TabStop = false;
            this.gbBack.Text = "设置";
            this.gbBack.Visible = false;
            // 
            // btBackOutLineColor
            // 
            this.btBackOutLineColor.EditValue = System.Drawing.Color.Empty;
            this.btBackOutLineColor.Location = new System.Drawing.Point(90, 92);
            this.btBackOutLineColor.Name = "btBackOutLineColor";
            this.btBackOutLineColor.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.btBackOutLineColor.Properties.ColorAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.btBackOutLineColor.Size = new System.Drawing.Size(70, 20);
            this.btBackOutLineColor.TabIndex = 22;
            this.btBackOutLineColor.ColorChanged += new System.EventHandler(this.btBackOutLineColor_ColorChanged);
            // 
            // btBackFillColor
            // 
            this.btBackFillColor.EditValue = System.Drawing.Color.Empty;
            this.btBackFillColor.Location = new System.Drawing.Point(91, 22);
            this.btBackFillColor.Name = "btBackFillColor";
            this.btBackFillColor.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.btBackFillColor.Properties.ColorAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.btBackFillColor.Size = new System.Drawing.Size(70, 20);
            this.btBackFillColor.TabIndex = 21;
            this.btBackFillColor.ColorChanged += new System.EventHandler(this.btBackFillColor_ColorChanged);
            // 
            // nudBackOutLine
            // 
            this.nudBackOutLine.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudBackOutLine.Location = new System.Drawing.Point(91, 57);
            this.nudBackOutLine.Name = "nudBackOutLine";
            this.nudBackOutLine.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.nudBackOutLine.Size = new System.Drawing.Size(70, 20);
            this.nudBackOutLine.TabIndex = 19;
            this.nudBackOutLine.ValueChanged += new System.EventHandler(this.nudBackOutLine_ValueChanged);
            // 
            // lbOutLineColor
            // 
            this.lbOutLineColor.Location = new System.Drawing.Point(22, 91);
            this.lbOutLineColor.Name = "lbOutLineColor";
            this.lbOutLineColor.Size = new System.Drawing.Size(52, 14);
            this.lbOutLineColor.TabIndex = 18;
            this.lbOutLineColor.Text = "边框颜色:";
            // 
            // lbOutLineWidth
            // 
            this.lbOutLineWidth.Location = new System.Drawing.Point(22, 61);
            this.lbOutLineWidth.Name = "lbOutLineWidth";
            this.lbOutLineWidth.Size = new System.Drawing.Size(52, 14);
            this.lbOutLineWidth.TabIndex = 17;
            this.lbOutLineWidth.Text = "边框宽度:";
            // 
            // lbFillColor
            // 
            this.lbFillColor.Location = new System.Drawing.Point(36, 30);
            this.lbFillColor.Name = "lbFillColor";
            this.lbFillColor.Size = new System.Drawing.Size(40, 14);
            this.lbFillColor.TabIndex = 15;
            this.lbFillColor.Text = "填充色:";
            // 
            // gbBorder
            // 
            this.gbBorder.Controls.Add(this.btColor);
            this.gbBorder.Controls.Add(this.numericUpDown1);
            this.gbBorder.Controls.Add(this.labelControl2);
            this.gbBorder.Controls.Add(this.labelControl3);
            this.gbBorder.Location = new System.Drawing.Point(380, 175);
            this.gbBorder.Name = "gbBorder";
            this.gbBorder.Size = new System.Drawing.Size(196, 96);
            this.gbBorder.TabIndex = 20;
            this.gbBorder.TabStop = false;
            this.gbBorder.Text = "设置";
            this.gbBorder.Visible = false;
            // 
            // btColor
            // 
            this.btColor.EditValue = System.Drawing.Color.Empty;
            this.btColor.Location = new System.Drawing.Point(91, 26);
            this.btColor.Name = "btColor";
            this.btColor.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.btColor.Properties.ColorAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.btColor.Size = new System.Drawing.Size(70, 20);
            this.btColor.TabIndex = 20;
            this.btColor.ColorChanged += new System.EventHandler(this.btColor_ColorChanged);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.numericUpDown1.Location = new System.Drawing.Point(91, 61);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.numericUpDown1.Size = new System.Drawing.Size(70, 20);
            this.numericUpDown1.TabIndex = 19;
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(36, 65);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(28, 14);
            this.labelControl2.TabIndex = 17;
            this.labelControl2.Text = "宽度:";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(36, 30);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(28, 14);
            this.labelControl3.TabIndex = 15;
            this.labelControl3.Text = "颜色:";
            // 
            // btOk
            // 
            this.btOk.Location = new System.Drawing.Point(402, 362);
            this.btOk.Name = "btOk";
            this.btOk.Size = new System.Drawing.Size(76, 27);
            this.btOk.TabIndex = 21;
            this.btOk.Text = "确定";
            this.btOk.Click += new System.EventHandler(this.btOk_Click);
            // 
            // btCancel
            // 
            this.btCancel.Location = new System.Drawing.Point(497, 362);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(76, 27);
            this.btCancel.TabIndex = 22;
            this.btCancel.Text = "取消";
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // FrameSymbolSelector
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.Appearance.BackColor2 = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(587, 514);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btOk);
            this.Controls.Add(this.gbBorder);
            this.Controls.Add(this.gbBack);
            this.Controls.Add(this.gbShadow);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.axSymbologyControl1);
            this.LookAndFeel.SkinName = "Blue";
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrameSymbolSelector";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "符号选择";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrameSymbolSelector_FormClosed);
            this.Load += new System.EventHandler(this.FrameSymbolSelector_Load);
            ((System.ComponentModel.ISupportInitialize)(this.axSymbologyControl1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1.Properties)).EndInit();
            this.gbShadow.ResumeLayout(false);
            this.gbShadow.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btShadowOutLineColor.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btShadowFillColor.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudShadowOutLine.Properties)).EndInit();
            this.gbBack.ResumeLayout(false);
            this.gbBack.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btBackOutLineColor.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btBackFillColor.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBackOutLine.Properties)).EndInit();
            this.gbBorder.ResumeLayout(false);
            this.gbBorder.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btColor.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        private void MakeNoneSymbol(IFillSymbol pFillSymbol)
        {
            ILineSymbol symbol = new CartographicLineSymbolClass();
            symbol.Width = 0.0;
            pFillSymbol.Outline = symbol;
            IColor color = pFillSymbol.Color;
            color.NullColor = true;
            pFillSymbol.Color = color;
        }

        private void nudBackOutLine_ValueChanged(object sender, EventArgs e)
        {
            ISymbolBackground item = (ISymbolBackground) this.m_styleGalleryItem.Item;
            IFillSymbol fillSymbol = item.FillSymbol;
            ILineSymbol outline = fillSymbol.Outline;
            outline.Width = double.Parse(this.nudBackOutLine.Value.ToString());
            outline.Color = fillSymbol.Outline.Color;
            fillSymbol.Outline = outline;
            item.FillSymbol = fillSymbol;
            this.PreviewImage();
        }

        private void nudShadowOutLine_ValueChanged(object sender, EventArgs e)
        {
            ISymbolShadow item = (ISymbolShadow) this.m_styleGalleryItem.Item;
            IFillSymbol fillSymbol = item.FillSymbol;
            ILineSymbol outline = fillSymbol.Outline;
            outline.Width = double.Parse(this.nudShadowOutLine.Value.ToString());
            outline.Color = fillSymbol.Outline.Color;
            fillSymbol.Outline = outline;
            item.FillSymbol = fillSymbol;
            this.PreviewImage();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            ISymbolBorder item = (ISymbolBorder) this.m_styleGalleryItem.Item;
            ILineSymbol lineSymbol = item.LineSymbol;
            lineSymbol.Width = double.Parse(this.numericUpDown1.Value.ToString());
            item.LineSymbol = lineSymbol;
            this.PreviewImage();
        }

        private void PreviewImage()
        {
            if (this.m_styleGalleryItem.Item != null)
            {
                Image image = Image.FromHbitmap(new IntPtr(this.axSymbologyControl1.GetStyleClass(this.axSymbologyControl1.StyleClass).PreviewItem(this.m_styleGalleryItem, this.pictureBox1.Width, this.pictureBox1.Height).Handle));
                this.pictureBox1.Image = image;
            }
        }
    }
}

