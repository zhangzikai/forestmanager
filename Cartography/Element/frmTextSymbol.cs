namespace Cartography.Element
{
    using Cartography;
    using DevExpress.Utils;
    using DevExpress.XtraEditors;
    using DevExpress.XtraEditors.Controls;
    using ESRI.ArcGIS.Carto;
    using ESRI.ArcGIS.Display;
    using ESRI.ArcGIS.esriSystem;
    using ESRI.ArcGIS.Geometry;
    using FormBase;
    using stdole;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Drawing.Text;
    using System.IO;
    using System.Windows.Forms;
    using Utilities;

    public class frmTextSymbol : FormBase3
    {
        private Button buttonCancel;
        private Button buttonOK;
        private CheckEdit ceBold;
        private CheckEdit ceDeleteLine;
        private ComboBoxEdit ceFont;
        private CheckEdit ceItalic;
        private ComboBoxEdit ceSize;
        private ColorEdit ceTextColor;
        private CheckEdit ceUnderLine;
        private System.Windows.Forms.ComboBox comboCategory;
        private IContainer components;
        private GroupBox groupBoxOptions;
        private GroupBox groupBoxPreview;
        private ImageList imageListSymbol;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private ListView listViewSymbol;
        private bool m_bChanged = true;
        private bool mAllowNoneSymbol;
        private string[] mCategoryArray;
        private string mCustomStyleFile = "";
        private string mDefaultStyleFile = "";
        private int mHeight = 0x20;
        private bool mListCategoryLocked;
        private bool mListSymbolLocked;
        private string[] mStyleFileArray;
        private IStyleGalleryClass mStyleGalleryClass;
        protected IArray mSymbolArray;
        private string mSymbolCategory = "";
        private string mSymbolClass = "";
        private object mSymbolCurrent;
        private object mSymbolSource;
        private string mSysStylePath = "";
        private int mWidth = 0x20;
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private Panel panel4;
        private PictureBox pictureBoxPreview;

        public frmTextSymbol()
        {
            this.InitializeComponent();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            base.DialogResult = DialogResult.Cancel;
            base.Close();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if ((this.mSymbolCurrent == null) & !this.mAllowNoneSymbol)
            {
                MessageBox.Show("请先选择一个符号样式。");
            }
            else
            {
                base.DialogResult = DialogResult.OK;
                base.Close();
            }
        }

        private void ceBold_CheckedChanged(object sender, EventArgs e)
        {
            this.ChangeSymbol();
        }

        private void ceDeleteLine_CheckedChanged(object sender, EventArgs e)
        {
            this.ChangeSymbol();
        }

        private void ceFont_EditValueChanged(object sender, EventArgs e)
        {
            this.ChangeSymbol();
        }

        private void ceItalic_CheckedChanged(object sender, EventArgs e)
        {
            this.ChangeSymbol();
        }

        private void ceSize_EditValueChanged(object sender, EventArgs e)
        {
            this.ChangeSymbol();
        }

        private void ceTextColor_ColorChanged(object sender, EventArgs e)
        {
            this.ChangeSymbol();
        }

        private void ceUnderLine_CheckedChanged(object sender, EventArgs e)
        {
            this.ChangeSymbol();
        }

        private void ChangeSymbol()
        {
            if (!this.m_bChanged)
            {
                try
                {
                    ITextSymbol mSymbolCurrent = (ITextSymbol) this.mSymbolCurrent;
                    mSymbolCurrent.Color = this.ConvertToESRIColor(this.ceTextColor.Color);
                    stdole.IFontDisp font = mSymbolCurrent.Font;
                    font.Name = this.ceFont.Text;
                    font.Bold = this.ceBold.Checked;
                    font.Italic = this.ceItalic.Checked;
                    font.Underline = this.ceUnderLine.Checked;
                    font.Strikethrough = this.ceDeleteLine.Checked;
                    font.Size = Convert.ToDecimal(this.ceSize.Text);
                    mSymbolCurrent.Font = font;
                }
                catch
                {
                }
                this.PreViewSymbol();
            }
        }

        private void comboCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (!this.mListCategoryLocked)
                {
                    string sCategory = null;
                    sCategory = this.comboCategory.Text.Trim();
                    if (sCategory == "- 全部 -")
                    {
                        sCategory = "";
                    }
                    if (this.mSymbolCategory != sCategory)
                    {
                        this.Cursor = Cursors.WaitCursor;
                        this.LoadSymbolListView(sCategory);
                        this.Cursor = Cursors.Default;
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        private Color ConvertToColor(IColor pColor)
        {
            IRgbColor color = (IRgbColor) pColor;
            return Color.FromArgb(color.Red, color.Green, color.Blue);
        }

        private IColor ConvertToESRIColor(Color pColor)
        {
            IRgbColor color = new RgbColorClass();
            color.Red = pColor.R;
            color.Green = pColor.G;
            color.Blue = pColor.B;
            IColor color2 = color;
            if (pColor.Name.ToLower() == "transparent")
            {
                color2.NullColor = true;
            }
            return color2;
        }

        private Image CreateImageFromStyleGalleryClass(IStyleGalleryClass pStyleGalleryClass, object pSymbol, int iWidth, int iHeight, Color pBackColor)
        {
            try
            {
                tagRECT grect;
                if (pStyleGalleryClass == null)
                {
                    return null;
                }
                if (pSymbol == null)
                {
                    return null;
                }
                if (iWidth <= 0)
                {
                    iWidth = 0x20;
                }
                if (iHeight <= 0)
                {
                    iHeight = 0x20;
                }
                Bitmap image = null;
                image = new Bitmap(iWidth, iHeight);
                Graphics graphics = null;
                graphics = Graphics.FromImage(image);
                if (!pBackColor.IsEmpty)
                {
                    SolidBrush brush = new SolidBrush(pBackColor);
                    graphics.FillRectangle(brush, 0, 0, iWidth, iHeight);
                }
                IntPtr hdc = new IntPtr();
                hdc = graphics.GetHdc();
                if (hdc.ToInt64() == 0L)
                {
                    return null;
                }
                grect.left = 0;
                grect.top = 0;
                grect.right = iWidth;
                grect.bottom = iHeight;
                try
                {
                    pStyleGalleryClass.Preview(pSymbol, hdc.ToInt32(), ref grect);
                }
                catch (Exception)
                {
                }
                graphics.ReleaseHdc(hdc);
                return image;
            }
            catch (Exception)
            {
                return null;
            }
        }

        private Image CreateImageFromSymbol(ISymbol pSymbol, int iWidth, int iHeight, Color pBackColor, int iGap)
        {
            try
            {
                if (pSymbol != null)
                {
                    if (iWidth == 0)
                    {
                        return null;
                    }
                    if (iHeight == 0)
                    {
                        return null;
                    }
                    Bitmap image = new Bitmap(iWidth, iHeight);
                    Graphics graphics = Graphics.FromImage(image);
                    if (!pBackColor.IsEmpty)
                    {
                        SolidBrush brush = new SolidBrush(pBackColor);
                        graphics.FillRectangle(brush, 0, 0, iWidth, iHeight);
                    }
                    long lDpi = 0L;
                    lDpi = Convert.ToInt64(graphics.DpiX);
                    IntPtr hDC = new IntPtr();
                    hDC = graphics.GetHdc();
                    if (hDC.ToInt64() == 0L)
                    {
                        return null;
                    }
                    bool flag = false;
                    flag = this.DrawSymbolToDC(hDC, pSymbol, iWidth, iHeight, lDpi, iGap);
                    graphics.ReleaseHdc(hDC);
                    if (flag)
                    {
                        return image;
                    }
                }
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }

        private IGeometry CreateSymbolShape(ISymbol pSymbol, IEnvelope pEnvelope)
        {
            try
            {
                if (pSymbol == null)
                {
                    return null;
                }
                if (pEnvelope == null)
                {
                    return null;
                }
                if (pSymbol is IMarkerSymbol)
                {
                    IArea area = (IArea) pEnvelope;
                    return area.Centroid;
                }
                if ((pSymbol is ILineSymbol) | (pSymbol is ITextSymbol))
                {
                    IPoint point = new PointClass();
                    point.PutCoords(pEnvelope.XMin, pEnvelope.YMax - (pEnvelope.Height / 2.0));
                    IPoint point2 = new PointClass();
                    point2.PutCoords(pEnvelope.XMax, pEnvelope.YMax - (pEnvelope.Height / 2.0));
                    IPolyline polyline = new PolylineClass();
                    polyline.FromPoint = point;
                    polyline.ToPoint = point2;
                    return polyline;
                }
                return pEnvelope;
            }
            catch (Exception)
            {
                return null;
            }
        }

        private unsafe ITransformation CreateTransFromDC(int iWidth, int iHeight, long lDpi)
        {
            try
            {
                tagRECT grect;
                if (iWidth == 0)
                {
                    return null;
                }
                if (iHeight == 0)
                {
                    return null;
                }
                if (lDpi == 0L)
                {
                    return null;
                }
                IEnvelope envelope = new EnvelopeClass();
                envelope.PutCoords(0.0, 0.0, (double) iWidth, (double) iHeight);
                grect.left = 0;
                grect.top = 0;
                grect.right = iWidth;
                grect.bottom = iHeight;
                IDisplayTransformation transformation = new DisplayTransformationClass();
                transformation.Bounds = envelope;
                transformation.set_DeviceFrame(ref grect);
                transformation.Resolution = lDpi;
                return transformation;
            }
            catch (Exception)
            {
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

        private bool DrawSymbolToDC(IntPtr hDC, ISymbol pSymbol, int iWidth, int iHeight, long lDpi, int iGap)
        {
            try
            {
                if (hDC.ToInt64() == 0L)
                {
                    return false;
                }
                if (pSymbol == null)
                {
                    return false;
                }
                if (iWidth == 0)
                {
                    return false;
                }
                if (iHeight == 0)
                {
                    return false;
                }
                if (lDpi == 0L)
                {
                    return false;
                }
                IEnvelope pEnvelope = new EnvelopeClass();
                pEnvelope.PutCoords((double) iGap, (double) iGap, (double) (iWidth - iGap), (double) (iHeight - iGap));
                IGeometry geometry = this.CreateSymbolShape(pSymbol, pEnvelope);
                if (geometry == null)
                {
                    return false;
                }
                ITransformation transformation = this.CreateTransFromDC(iWidth, iHeight, lDpi);
                if (transformation == null)
                {
                    return false;
                }
                pSymbol.SetupDC(hDC.ToInt32(), transformation);
                bool flag = false;
                try
                {
                    pSymbol.Draw(geometry);
                    flag = true;
                }
                catch (Exception)
                {
                    flag = false;
                }
                pSymbol.ResetDC();
                return flag;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private void frmGraphicSymbol_Load(object sender, EventArgs e)
        {
            try
            {
                if (base.Visible)
                {
                    this.Cursor = Cursors.WaitCursor;
                    InstalledFontCollection fonts = new InstalledFontCollection();
                    FontFamily[] families = fonts.Families;
                    int index = 0;
                    for (index = 0; index < families.Length; index++)
                    {
                        this.ceFont.Properties.Items.Add(families[index].Name);
                    }
                    this.ceFont.SelectedIndex = -1;
                    for (index = 5; index <= 0x48; index++)
                    {
                        this.ceSize.Properties.Items.Add(index);
                    }
                    this.ceSize.SelectedItem = -1;
                    bool flag = false;
                    if (flag = this.InitSelector())
                    {
                        this.PreViewSymbol();
                        this.SetCurrentControl();
                    }
                    this.Cursor = Cursors.Default;
                    this.buttonOK.Enabled = flag;
                }
            }
            catch (Exception)
            {
            }
        }

        private Image GetSymbolImage(object pSymbol, int iWidth, int iHeight, Color pBackColor, int iGap)
        {
            try
            {
                if (pSymbol == null)
                {
                    return null;
                }
                if (iWidth <= 0)
                {
                    iWidth = 0x20;
                }
                if (iHeight <= 0)
                {
                    iHeight = 0x20;
                }
                ISymbol symbol = null;
                if (pSymbol is IFillSymbol)
                {
                    symbol = (ISymbol) pSymbol;
                }
                else if (pSymbol is ILineSymbol)
                {
                    symbol = (ISymbol) pSymbol;
                }
                else if (pSymbol is IMarkerSymbol)
                {
                    symbol = (ISymbol) pSymbol;
                }
                else if (pSymbol is ITextSymbol)
                {
                    ITextSymbol symbol2 = (ITextSymbol) pSymbol;
                    if (symbol2.Text == "中文 Aa 12")
                    {
                        symbol2.Text = ((ITextSymbol) this.mSymbolSource).Text;
                    }
                    if (symbol2.Text == "")
                    {
                        symbol2.Text = "中文 Aa 12";
                    }
                    symbol = (ISymbol) symbol2;
                }
                else if (pSymbol is IScaleBar)
                {
                    iWidth = Convert.ToInt32((double) (iWidth * 1.75));
                }
                Image image = null;
                if (symbol != null)
                {
                    image = this.CreateImageFromSymbol(symbol, iWidth, iHeight, pBackColor, iGap);
                }
                else if (this.mStyleGalleryClass != null)
                {
                    image = this.CreateImageFromStyleGalleryClass(this.mStyleGalleryClass, pSymbol, iWidth, iHeight, pBackColor);
                }
                if ((image != null) && (pSymbol is IScaleBar))
                {
                    Rectangle rect = new Rectangle(0, 0, Convert.ToInt32((double) (((double) iWidth) / 1.75)), iHeight);
                    Bitmap bitmap = (Bitmap) image;
                    image = bitmap.Clone(rect, bitmap.PixelFormat);
                }
                return image;
            }
            catch (Exception)
            {
                return null;
            }
        }

        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.comboCategory = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.listViewSymbol = new System.Windows.Forms.ListView();
            this.imageListSymbol = new System.Windows.Forms.ImageList();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBoxPreview = new System.Windows.Forms.GroupBox();
            this.pictureBoxPreview = new System.Windows.Forms.PictureBox();
            this.groupBoxOptions = new System.Windows.Forms.GroupBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.ceDeleteLine = new DevExpress.XtraEditors.CheckEdit();
            this.ceUnderLine = new DevExpress.XtraEditors.CheckEdit();
            this.ceItalic = new DevExpress.XtraEditors.CheckEdit();
            this.ceBold = new DevExpress.XtraEditors.CheckEdit();
            this.ceSize = new DevExpress.XtraEditors.ComboBoxEdit();
            this.label4 = new System.Windows.Forms.Label();
            this.ceFont = new DevExpress.XtraEditors.ComboBoxEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.ceTextColor = new DevExpress.XtraEditors.ColorEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBoxPreview.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPreview)).BeginInit();
            this.groupBoxOptions.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ceDeleteLine.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceUnderLine.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceItalic.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceBold.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceSize.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceFont.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceTextColor.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(5, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 33);
            this.label1.TabIndex = 0;
            this.label1.Text = "类别";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // comboCategory
            // 
            this.comboCategory.FormattingEnabled = true;
            this.comboCategory.Location = new System.Drawing.Point(51, 9);
            this.comboCategory.Name = "comboCategory";
            this.comboCategory.Size = new System.Drawing.Size(340, 22);
            this.comboCategory.TabIndex = 1;
            this.comboCategory.SelectedIndexChanged += new System.EventHandler(this.comboCategory_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.listViewSymbol);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(2, 1);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.panel1.Size = new System.Drawing.Size(398, 364);
            this.panel1.TabIndex = 2;
            // 
            // listViewSymbol
            // 
            this.listViewSymbol.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewSymbol.LargeImageList = this.imageListSymbol;
            this.listViewSymbol.Location = new System.Drawing.Point(2, 42);
            this.listViewSymbol.Name = "listViewSymbol";
            this.listViewSymbol.Size = new System.Drawing.Size(396, 322);
            this.listViewSymbol.SmallImageList = this.imageListSymbol;
            this.listViewSymbol.StateImageList = this.imageListSymbol;
            this.listViewSymbol.TabIndex = 4;
            this.listViewSymbol.UseCompatibleStateImageBehavior = false;
            this.listViewSymbol.SelectedIndexChanged += new System.EventHandler(this.listViewSymbol_SelectedIndexChanged);
            // 
            // imageListSymbol
            // 
            this.imageListSymbol.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageListSymbol.ImageSize = new System.Drawing.Size(16, 16);
            this.imageListSymbol.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.comboCategory);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(2, 0);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(0, 9, 0, 0);
            this.panel2.Size = new System.Drawing.Size(396, 42);
            this.panel2.TabIndex = 3;
            // 
            // groupBoxPreview
            // 
            this.groupBoxPreview.Controls.Add(this.pictureBoxPreview);
            this.groupBoxPreview.ForeColor = System.Drawing.Color.Blue;
            this.groupBoxPreview.Location = new System.Drawing.Point(407, 10);
            this.groupBoxPreview.Name = "groupBoxPreview";
            this.groupBoxPreview.Size = new System.Drawing.Size(184, 117);
            this.groupBoxPreview.TabIndex = 3;
            this.groupBoxPreview.TabStop = false;
            this.groupBoxPreview.Text = "预览";
            // 
            // pictureBoxPreview
            // 
            this.pictureBoxPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxPreview.Location = new System.Drawing.Point(3, 18);
            this.pictureBoxPreview.Name = "pictureBoxPreview";
            this.pictureBoxPreview.Size = new System.Drawing.Size(178, 96);
            this.pictureBoxPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBoxPreview.TabIndex = 0;
            this.pictureBoxPreview.TabStop = false;
            // 
            // groupBoxOptions
            // 
            this.groupBoxOptions.Controls.Add(this.panel3);
            this.groupBoxOptions.ForeColor = System.Drawing.Color.Blue;
            this.groupBoxOptions.Location = new System.Drawing.Point(407, 134);
            this.groupBoxOptions.Name = "groupBoxOptions";
            this.groupBoxOptions.Size = new System.Drawing.Size(184, 182);
            this.groupBoxOptions.TabIndex = 4;
            this.groupBoxOptions.TabStop = false;
            this.groupBoxOptions.Text = "设置";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Controls.Add(this.ceSize);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.ceFont);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.ceTextColor);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 18);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(178, 161);
            this.panel3.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.ceDeleteLine);
            this.panel4.Controls.Add(this.ceUnderLine);
            this.panel4.Controls.Add(this.ceItalic);
            this.panel4.Controls.Add(this.ceBold);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 128);
            this.panel4.Name = "panel4";
            this.panel4.Padding = new System.Windows.Forms.Padding(6);
            this.panel4.Size = new System.Drawing.Size(178, 33);
            this.panel4.TabIndex = 19;
            // 
            // ceDeleteLine
            // 
            this.ceDeleteLine.Dock = System.Windows.Forms.DockStyle.Left;
            this.ceDeleteLine.Location = new System.Drawing.Point(120, 6);
            this.ceDeleteLine.Name = "ceDeleteLine";
            this.ceDeleteLine.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Strikeout, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ceDeleteLine.Properties.Appearance.Options.UseFont = true;
            this.ceDeleteLine.Properties.Caption = "ST";
            this.ceDeleteLine.Size = new System.Drawing.Size(47, 19);
            this.ceDeleteLine.TabIndex = 19;
            this.ceDeleteLine.ToolTip = "删除线";
            this.ceDeleteLine.CheckedChanged += new System.EventHandler(this.ceDeleteLine_CheckedChanged);
            // 
            // ceUnderLine
            // 
            this.ceUnderLine.Dock = System.Windows.Forms.DockStyle.Left;
            this.ceUnderLine.Location = new System.Drawing.Point(82, 6);
            this.ceUnderLine.Name = "ceUnderLine";
            this.ceUnderLine.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ceUnderLine.Properties.Appearance.Options.UseFont = true;
            this.ceUnderLine.Properties.Caption = "U";
            this.ceUnderLine.Size = new System.Drawing.Size(38, 19);
            this.ceUnderLine.TabIndex = 18;
            this.ceUnderLine.ToolTip = "下划线";
            this.ceUnderLine.CheckedChanged += new System.EventHandler(this.ceUnderLine_CheckedChanged);
            // 
            // ceItalic
            // 
            this.ceItalic.Dock = System.Windows.Forms.DockStyle.Left;
            this.ceItalic.Location = new System.Drawing.Point(44, 6);
            this.ceItalic.Name = "ceItalic";
            this.ceItalic.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ceItalic.Properties.Appearance.Options.UseFont = true;
            this.ceItalic.Properties.Caption = "I";
            this.ceItalic.Size = new System.Drawing.Size(38, 19);
            this.ceItalic.TabIndex = 17;
            this.ceItalic.ToolTip = "斜体";
            this.ceItalic.CheckedChanged += new System.EventHandler(this.ceItalic_CheckedChanged);
            // 
            // ceBold
            // 
            this.ceBold.Dock = System.Windows.Forms.DockStyle.Left;
            this.ceBold.Location = new System.Drawing.Point(6, 6);
            this.ceBold.Name = "ceBold";
            this.ceBold.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ceBold.Properties.Appearance.Options.UseFont = true;
            this.ceBold.Properties.Caption = "B";
            this.ceBold.Size = new System.Drawing.Size(38, 19);
            this.ceBold.TabIndex = 11;
            this.ceBold.ToolTip = "粗体";
            this.ceBold.CheckedChanged += new System.EventHandler(this.ceBold_CheckedChanged);
            // 
            // ceSize
            // 
            this.ceSize.Location = new System.Drawing.Point(47, 91);
            this.ceSize.Name = "ceSize";
            this.ceSize.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ceSize.Size = new System.Drawing.Size(117, 20);
            this.ceSize.TabIndex = 18;
            this.ceSize.EditValueChanged += new System.EventHandler(this.ceSize_EditValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(7, 94);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 14);
            this.label4.TabIndex = 17;
            this.label4.Text = "字号";
            // 
            // ceFont
            // 
            this.ceFont.Location = new System.Drawing.Point(47, 49);
            this.ceFont.Name = "ceFont";
            this.ceFont.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ceFont.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.ceFont.Size = new System.Drawing.Size(117, 20);
            this.ceFont.TabIndex = 16;
            this.ceFont.EditValueChanged += new System.EventHandler(this.ceFont_EditValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(7, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 14);
            this.label3.TabIndex = 15;
            this.label3.Text = "字体";
            // 
            // ceTextColor
            // 
            this.ceTextColor.EditValue = System.Drawing.Color.White;
            this.ceTextColor.Location = new System.Drawing.Point(48, 12);
            this.ceTextColor.Name = "ceTextColor";
            this.ceTextColor.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ceTextColor.Properties.ColorAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.ceTextColor.Properties.Mask.ShowPlaceHolders = false;
            this.ceTextColor.Size = new System.Drawing.Size(70, 20);
            this.ceTextColor.TabIndex = 9;
            this.ceTextColor.ColorChanged += new System.EventHandler(this.ceTextColor_ColorChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(7, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 14);
            this.label2.TabIndex = 8;
            this.label2.Text = "颜色";
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(419, 338);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(73, 27);
            this.buttonOK.TabIndex = 7;
            this.buttonOK.Text = "确定";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(514, 338);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(73, 27);
            this.buttonCancel.TabIndex = 8;
            this.buttonCancel.Text = "取消";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // frmTextSymbol
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.Appearance.Options.UseBackColor = true;
            this.ClientSize = new System.Drawing.Size(600, 384);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.groupBoxOptions);
            this.Controls.Add(this.groupBoxPreview);
            this.Controls.Add(this.panel1);
            this.LookAndFeel.SkinName = "Blue";
            this.Name = "frmTextSymbol";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "文本符号";
            this.Load += new System.EventHandler(this.frmGraphicSymbol_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.groupBoxPreview.ResumeLayout(false);
            this.groupBoxPreview.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPreview)).EndInit();
            this.groupBoxOptions.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ceDeleteLine.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceUnderLine.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceItalic.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceBold.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceSize.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceFont.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceTextColor.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        private bool InitSelector()
        {
            try
            {
                if (this.mSymbolSource == null)
                {
                    MessageBox.Show("初始样式不可为空。");
                    return false;
                }
                string sSymbolClass = null;
                sSymbolClass = "Text Symbols";
                return this.InitSelector(sSymbolClass, this.mSymbolCategory, this.mSymbolSource, false);
            }
            catch (Exception)
            {
                return false;
            }
        }

        private bool InitSelector(string sSymbolClass, string sSymbolCategory, object pSymbolSource, bool bAllowNoneSymbol)
        {
            try
            {
                if (!string.IsNullOrEmpty(this.mSymbolClass))
                {
                    return false;
                }
                if (string.IsNullOrEmpty(sSymbolClass))
                {
                    return false;
                }
                this.mSymbolClass = sSymbolClass;
                this.mSymbolCategory = sSymbolCategory;
                this.mAllowNoneSymbol = bAllowNoneSymbol;
                UtilFactory.GetConfigOpt();
                this.mDefaultStyleFile = ElementService.StyleGalleryFile;
                if (!this.InitSymbolProp())
                {
                    return false;
                }
                if (this.mSymbolSource == null)
                {
                    this.mSymbolCurrent = null;
                }
                else
                {
                    this.mSymbolCurrent = ((IClone) this.mSymbolSource).Clone();
                }
                this.SetSelector();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private bool InitSymbolProp()
        {
            try
            {
                if (string.IsNullOrEmpty(this.mSymbolClass))
                {
                    return false;
                }
                this.mWidth = 0x80;
                this.mHeight = 0x20;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private void listViewSymbol_DoubleClick(object sender, EventArgs e)
        {
        }

        private void listViewSymbol_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if ((!this.mListSymbolLocked && (this.mSymbolArray != null)) && (this.listViewSymbol.SelectedItems.Count > 0))
                {
                    int index = 0;
                    index = (int) this.listViewSymbol.SelectedItems[0].Tag;
                    IStyleGalleryItem item = (IStyleGalleryItem) this.mSymbolArray.get_Element(index);
                    this.mSymbolCurrent = ((IClone) item.Item).Clone();
                    this.PreViewSymbol();
                    this.SetCurrentControl();
                }
            }
            catch (Exception)
            {
            }
        }

        private bool LoadCategoryComboBox()
        {
            try
            {
                this.mListCategoryLocked = true;
                this.comboCategory.Enabled = false;
                this.comboCategory.Items.Clear();
                this.comboCategory.Items.Add("- 全部 -");
                System.Array.Sort<string>(this.mCategoryArray);
                bool flag = false;
                string str = null;
                string str2 = "";
                for (int i = 0; i < this.mCategoryArray.Length; i++)
                {
                    str = this.mCategoryArray[i];
                    str = str.Trim();
                    if (!string.IsNullOrEmpty(str) && (str != str2))
                    {
                        str2 = str;
                        this.comboCategory.Items.Add(str);
                        if (!string.IsNullOrEmpty(this.mSymbolCategory) & (str == this.mSymbolCategory))
                        {
                            flag = true;
                        }
                    }
                }
                if (flag)
                {
                    this.comboCategory.Text = this.mSymbolCategory;
                }
                else
                {
                    this.mSymbolCategory = "";
                    this.comboCategory.Text = "- 全部 -";
                }
                this.comboCategory.Enabled = true;
                this.mListCategoryLocked = false;
                return true;
            }
            catch (Exception)
            {
                this.comboCategory.Enabled = true;
                this.mListCategoryLocked = false;
                return false;
            }
        }

        private bool LoadStyleGallery()
        {
            try
            {
                if (string.IsNullOrEmpty(this.mSymbolClass))
                {
                    return false;
                }
                IStyleGallery gallery = new ServerStyleGalleryClass();
                IStyleGalleryStorage storage = (IStyleGalleryStorage) gallery;
                int index = 0;
                for (index = storage.FileCount - 1; index >= 0; index += -1)
                {
                    storage.RemoveFile(storage.get_File(index));
                }
                if (File.Exists(this.mDefaultStyleFile))
                {
                    try
                    {
                        storage.AddFile(this.mDefaultStyleFile);
                    }
                    catch (Exception)
                    {
                    }
                }
                if (File.Exists(this.mCustomStyleFile))
                {
                    try
                    {
                        storage.AddFile(this.mCustomStyleFile);
                    }
                    catch (Exception)
                    {
                    }
                }
                if ((this.mStyleFileArray != null) && (this.mStyleFileArray.Length > 0))
                {
                    string str = null;
                    index = 0;
                    while (index < this.mStyleFileArray.Length)
                    {
                        try
                        {
                            str = this.mStyleFileArray[index];
                            str = str.Trim();
                            if (((!string.IsNullOrEmpty(str) & (str != this.mDefaultStyleFile)) & (str != this.mCustomStyleFile)) && File.Exists(str))
                            {
                                storage.AddFile(str);
                            }
                        }
                        catch (Exception)
                        {
                        }
                        index++;
                    }
                }
                if (storage.FileCount <= 0)
                {
                    return false;
                }
                this.mStyleGalleryClass = null;
                for (index = 0; index <= (gallery.ClassCount - 1); index++)
                {
                    if (gallery.get_Class(index).Name == this.mSymbolClass)
                    {
                        this.mStyleGalleryClass = gallery.get_Class(index);
                    }
                }
                if (this.mSymbolArray != null)
                {
                    this.mSymbolArray.RemoveAll();
                }
                this.mSymbolArray = new ArrayClass();
                IEnumStyleGalleryItem item = gallery.get_Items(this.mSymbolClass, "", "");
                item.Reset();
                IStyleGalleryItem unk = item.Next();
                while (unk != null)
                {
                    this.mSymbolArray.Add(unk);
                    unk = item.Next();
                }
                storage = null;
                if (this.mAllowNoneSymbol)
                {
                    unk = new ServerStyleGalleryItemClass();
                    unk.Category = "";
                    unk.Name = "<空>";
                    this.mSymbolArray.Add(unk);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private bool LoadStyleGalleryItem()
        {
            try
            {
                System.Array.Resize<string>(ref this.mCategoryArray, 1);
                this.mCategoryArray[0] = "";
                this.imageListSymbol.Images.Clear();
                this.imageListSymbol.ImageSize = new Size(this.mWidth, this.mHeight);
                this.imageListSymbol.ColorDepth = ColorDepth.Depth32Bit;
                if (this.mSymbolArray == null)
                {
                    return false;
                }
                if (this.mSymbolArray.Count > 0)
                {
                    Image image = null;
                    image = new Bitmap(this.mWidth, this.mHeight);
                    int index = 0;
                    string category = null;
                    object pSymbol = null;
                    Image image2 = null;
                    for (index = 0; index <= (this.mSymbolArray.Count - 1); index++)
                    {
                        IStyleGalleryItem item = (IStyleGalleryItem) this.mSymbolArray.get_Element(index);
                        category = item.Category;
                        pSymbol = item.Item;
                        System.Array.Resize<string>(ref this.mCategoryArray, index + 2);
                        this.mCategoryArray[index + 1] = category;
                        image2 = this.GetSymbolImage(pSymbol, this.mWidth, this.mHeight, Color.White, 1);
                        if (image2 != null)
                        {
                            this.imageListSymbol.Images.Add(image2);
                        }
                        else
                        {
                            this.imageListSymbol.Images.Add(image);
                        }
                    }
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private bool LoadSymbolListView(string sCategory)
        {
            try
            {
                if (this.mSymbolArray == null)
                {
                    return false;
                }
                this.mListSymbolLocked = true;
                this.listViewSymbol.Enabled = false;
                this.listViewSymbol.Items.Clear();
                if (this.mSymbolArray.Count <= 0)
                {
                    this.listViewSymbol.Enabled = true;
                    this.mListSymbolLocked = false;
                    return true;
                }
                int index = 0;
                ListViewItem item2 = null;
                for (index = 0; index <= (this.mSymbolArray.Count - 1); index++)
                {
                    IStyleGalleryItem item = (IStyleGalleryItem) this.mSymbolArray.get_Element(index);
                    if (string.IsNullOrEmpty(sCategory) | (item.Category == sCategory))
                    {
                        item2 = new ListViewItem();
                        item2.Text = item.Name;
                        item2.ImageIndex = index;
                        item2.Tag = index;
                        this.listViewSymbol.Items.Add(item2);
                    }
                }
                this.listViewSymbol.Sort();
                this.listViewSymbol.Enabled = true;
                this.mListSymbolLocked = false;
                this.mSymbolCategory = sCategory;
                return true;
            }
            catch (Exception)
            {
                this.listViewSymbol.Enabled = true;
                this.mListSymbolLocked = false;
                return false;
            }
        }

        private bool PreViewSymbol()
        {
            try
            {
                Image image = null;
                image = this.GetSymbolImage(this.mSymbolCurrent, this.pictureBoxPreview.Width, this.pictureBoxPreview.Height, this.pictureBoxPreview.BackColor, 2);
                this.pictureBoxPreview.Image = image;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private void SetCurrentControl()
        {
            this.m_bChanged = true;
            ITextSymbol mSymbolCurrent = (ITextSymbol) this.mSymbolCurrent;
            stdole.IFontDisp font = mSymbolCurrent.Font;
            string name = font.Name;
            int num = 0;
            int num2 = -1;
            for (num = 0; num < this.ceFont.Properties.Items.Count; num++)
            {
                if (this.ceFont.Properties.Items[num].ToString() == name)
                {
                    num2 = num;
                    break;
                }
            }
            if (num2 == -1)
            {
                this.ceFont.Text = name;
            }
            else
            {
                this.ceFont.SelectedIndex = num2;
            }
            this.ceSize.Text = Convert.ToInt32(font.Size).ToString();
            this.ceBold.Checked = font.Bold;
            this.ceItalic.Checked = font.Italic;
            this.ceUnderLine.Checked = font.Underline;
            this.ceDeleteLine.Checked = font.Strikethrough;
            this.ceTextColor.Color = this.ConvertToColor(mSymbolCurrent.Color);
            this.m_bChanged = false;
        }

        private bool SetSelector()
        {
            try
            {
                if (string.IsNullOrEmpty(this.mSymbolClass))
                {
                    return false;
                }
                if (!this.LoadStyleGallery())
                {
                    return false;
                }
                if (!this.LoadStyleGalleryItem())
                {
                    return false;
                }
                this.LoadCategoryComboBox();
                this.LoadSymbolListView(this.mSymbolCategory);
                if ((this.mSymbolCurrent == null) & !this.mAllowNoneSymbol)
                {
                    if (this.listViewSymbol.Items.Count > 0)
                    {
                        this.listViewSymbol.Items[0].Selected = true;
                    }
                    else if ((this.mSymbolArray != null) && (this.mSymbolArray.Count > 0))
                    {
                        IStyleGalleryItem item = (IStyleGalleryItem) this.mSymbolArray.get_Element(0);
                        this.mSymbolCurrent = ((IClone) item.Item).Clone();
                    }
                }
                this.groupBoxPreview.Select();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public string SymbolCategory
        {
            get
            {
                return this.mSymbolCategory;
            }
        }

        public string SymbolClass
        {
            get
            {
                return this.mSymbolClass;
            }
        }

        public object SymbolSelected
        {
            get
            {
                IClone mSymbolCurrent = (IClone) this.mSymbolCurrent;
                return mSymbolCurrent.Clone();
            }
        }

        public object SymbolSource
        {
            set
            {
                this.mSymbolSource = value;
            }
        }
    }
}

