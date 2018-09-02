namespace Cartography.Element
{
    using Cartography;
    using Cartography.Base;
    using DevExpress.XtraEditors;
    using DevExpress.XtraEditors.Controls;
    using DevExpress.XtraTab;
    using ESRI.ArcGIS.Carto;
    using ESRI.ArcGIS.Controls;
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
    using System.Runtime.InteropServices;
    using System.Windows.Forms;
    using Utilities;

    /// <summary>
    /// “制图-文本”：窗体
    /// </summary>
    public class DevText : FormBase3
    {
        private IPageLayoutControl _control;

        private IActiveView _activeview;
        private ITextElement _preElement;
        private ITextSymbol _preTextSymbol;
        private ITextElement _txtElement;
        private SimpleButton btCancel;
        private SimpleButton btnSymbol;
        private SimpleButton btOk;
        private CheckEdit cbLte;
        private IContainer components;
        private GroupBox gbCase;
        private GroupBox gbHAlign;
        private GroupBox gbPosition;
        private GroupBox gbVAlign;
        private bool init;
        private LabelControl labelControl1;
        private LabelControl lbAngle;
        private LabelControl lbCharSpace;
        private LabelControl lbCharWidth;
        private LabelControl lbFlipAngle;
        private LabelControl lbLeading;
        private LabelControl lbTxt;
        private LabelControl lbWSpace;
        private LabelControl lbXo;
        private LabelControl lbYo;
        private IPoint m_Point;
        private const string mClassName = "Cartography.Element.DevText";
        private ErrorOpt mErrOpt = UtilFactory.GetErrorOpt();
        private string mSubSysName = UtilFactory.GetConfigOpt().GetSystemName();
        private SpinEdit nud;
        private SpinEdit nudAngle;
        private SpinEdit nudCharSpa;
        private SpinEdit nudFlipAngle;
        private SpinEdit nudLeading;
        private SpinEdit nudXo;
        private SpinEdit nudYo;
        private SpinEdit numericUpDown6;
        private Panel panel1;
        private RadioGroup rgCase;
        private RadioGroup rgHAlign;
        private RadioGroup rgTextPos;
        private RadioGroup rgVAlign;
        private TextBox txtFont;
        private TextBox txtTitle;
        private XtraTabControl xtcMapTitle;
        private XtraTabPage xtpFormat;
        private XtraTabPage xtpNormal;

        /// <summary>
        /// “制图-文本”：构造器
        /// </summary>
        public DevText()
        {
            this.InitializeComponent();
            this._txtElement = new TextElementClass();
            this._txtElement.Text = "请输入文本";
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            base.DialogResult = DialogResult.Cancel;
            base.Close();
        }

        private void btnSymbol_Click(object sender, EventArgs e)
        {
            ISymbol symbol = (ISymbol) this._txtElement.Symbol;
            frmTextSymbol symbol2 = new frmTextSymbol();
            symbol2.SymbolSource = symbol;
            if (symbol2.ShowDialog() == DialogResult.OK)
            {
                ISymbol symbolSelected = (ISymbol) symbol2.SymbolSelected;
                this._txtElement.Symbol = (ITextSymbol) symbolSelected;
                this.txtFont.Text = this._txtElement.Symbol.Font.Name + " " + Convert.ToInt32(this._txtElement.Symbol.Font.Size);
                symbol2 = null;
            }
        }

        /// <summary>
        /// 创建的响应事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btOk_Click(object sender, EventArgs e)
        {
            if ((this._preElement == null) && (this._preTextSymbol == null))
            {
                ///如果已经存在图例应该首先删除，再创建
                ///经典啊
                IElement pDeletElement = this._control.FindElementByName("MapTitle");
                if (pDeletElement != null)
                {
                    IGraphicsContainer pGraphicsContainer = this._control.GraphicsContainer;
                    pGraphicsContainer.DeleteElement(pDeletElement);
                }

                this.CreateMapTitle();
            }
            else
            {
                if (this._preElement != null)
                {
                    this._preElement.Symbol = this._txtElement.Symbol;
                    this._preElement.Text = this._txtElement.Text;
                }
                this._preTextSymbol = this._txtElement.Symbol;
            }
            this._activeview.PartialRefresh(esriViewDrawPhase.esriViewGraphics, this._preElement, this._activeview.Extent);
            base.DialogResult = DialogResult.OK;
            base.Close();
        }

        private void btPreview_Click(object sender, EventArgs e)
        {
            if (this._preElement == null)
            {
                IPageLayout layout = (IPageLayout) this._activeview;
                (layout as IGraphicsContainer).DeleteElement((IElement) this._txtElement);
                this.CreateMapTitle();
            }
            else
            {
                this._preElement.Symbol = this._txtElement.Symbol;
            }
            this._activeview.PartialRefresh(esriViewDrawPhase.esriViewGraphics, this._preElement, this._activeview.Extent);
        }

        private void cbbold_Click(object sender, EventArgs e)
        {
            stdole.IFontDisp font = this._txtElement.Symbol.Font;
            font.Bold = !font.Bold;
            ITextSymbol symbol = this._txtElement.Symbol;
            symbol.Font = font;
            this._txtElement.Symbol = symbol;
        }

        private void cbItaliy_Click(object sender, EventArgs e)
        {
            stdole.IFontDisp font = this._txtElement.Symbol.Font;
            font.Italic = !font.Italic;
            ITextSymbol symbol = this._txtElement.Symbol;
            symbol.Font = font;
            this._txtElement.Symbol = symbol;
        }

        private void cbLte_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.init)
            {
                IFormattedTextSymbol symbol = (IFormattedTextSymbol) this._txtElement.Symbol;
                symbol.Kerning = !symbol.Kerning;
                this._txtElement.Symbol = symbol;
            }
        }

        private void cbStrikeThrough_Click(object sender, EventArgs e)
        {
            stdole.IFontDisp font = this._txtElement.Symbol.Font;
            font.Strikethrough = !font.Strikethrough;
            ITextSymbol symbol = this._txtElement.Symbol;
            symbol.Font = font;
            this._txtElement.Symbol = symbol;
        }

        private void cbUnderLine_Click(object sender, EventArgs e)
        {
            stdole.IFontDisp font = this._txtElement.Symbol.Font;
            font.Underline = !font.Underline;
            ITextSymbol symbol = this._txtElement.Symbol;
            symbol.Font = font;
            this._txtElement.Symbol = symbol;
        }

        /// <summary>
        /// 创建地图标题
        /// </summary>
        public void CreateMapTitle()
        {
            try
            {
                IPageLayout layout = (IPageLayout) this._activeview;
                IGraphicsContainer container = layout as IGraphicsContainer;
                IElement element = (IElement) this._txtElement;
                IEnvelope envelope = new EnvelopeClass();
                if (this.m_Point == null)
                {
                    ////double xMin = this._activeview.Extent.XMin + (this._activeview.Extent.Width / 2.0);
                    ////double yMin = this._activeview.Extent.YMax - (this._activeview.Extent.Height / 8.0);
                    ////double xMax = xMin + 1.0;
                    ////double yMax = yMin + 1.0;
                    double xMin = this._activeview.Extent.XMin + (this._activeview.Extent.Width / 2.0);
                    double yMin = this._activeview.Extent.YMax - (this._activeview.Extent.Height / 6.0);
                    double xMax = xMin + 1.0;
                    double yMax = yMin + 1.0;
                    envelope.PutCoords(xMin, yMin, xMax, yMax);
                }
                else
                {
                    envelope.PutCoords(this.m_Point.X, this.m_Point.Y - 0.5, this.m_Point.X + 1.0, this.m_Point.Y + 0.5);
                }
                element.Geometry = envelope;
                container.AddElement(element, 0);
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "Cartography.Element.DevText", "CreateMapTitle", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
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

        private void FillFamily()
        {
            InstalledFontCollection fonts = new InstalledFontCollection();
            FontFamily[] families = fonts.Families;
            for (int i = 0; i < families.Length; i++)
            {
            }
        }

        private void FillSymbol()
        {
            try
            {
                IStyleGalleryClass class3;
                IEnumStyleGalleryItem item;
                IStyleGallery o = new ServerStyleGalleryClass();
                IStyleGalleryStorage storage = (IStyleGalleryStorage) o;
                ImageList list = new ImageList();
                string path = "";
                try
                {
                    path = ElementService.StyleGalleryFile1;
                }
                catch (FileNotFoundException exception)
                {
                    XtraMessageBox.Show(exception.Message, "提示", MessageBoxButtons.OK);
                    return;
                }
                storage.AddFile(path);
                IStyleGalleryClass pStyleGalleryClass = null;
                for (int i = 0; i < o.ClassCount; i++)
                {
                    class3 = o.get_Class(i);
                    if (class3.Name == "Text Symbols")
                    {
                        goto Label_0079;
                    }
                }
                goto Label_007D;
            Label_0079:
                pStyleGalleryClass = class3;
            Label_007D:
                item = o.get_Items("Text Symbols", path, "Default");
                item.Reset();
                IStyleGalleryItem item2 = null;
                while ((item2 = item.Next()) != null)
                {
                    Bitmap bitmap = BitmapManager.GetBitMapFromItem(pStyleGalleryClass, item2.Item, 10, 10);
                    list.Images.Add(bitmap);
                }
                if ((this._preElement != null) || (this._preTextSymbol != null))
                {
                    IStyleGalleryItem item3 = new ServerStyleGalleryItemClass();
                    item3.Name = "默认符号";
                    if (this._preElement != null)
                    {
                        item3.Item = this._preElement.Symbol;
                    }
                    else
                    {
                        item3.Item = this._preTextSymbol;
                    }
                    Bitmap bitmap2 = BitmapManager.GetBitMapFromItem(pStyleGalleryClass, item3.Item, 10, 10);
                    list.Images.Add(bitmap2);
                }
                int num2 = 0;
                goto Label_014C;
            Label_013B:
                if (num2 > 0)
                {
                    goto Label_014C;
                }
                return;
            Label_0142:
                num2 = Marshal.ReleaseComObject(o);
                goto Label_013B;
            Label_014C:
                if (o == null)
                {
                    goto Label_013B;
                }
                goto Label_0142;
            }
            catch (Exception exception2)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "Cartography.Element.DevText", "FillSymbol", exception2.GetHashCode().ToString(), exception2.Source, exception2.Message, "", "", "");
            }
        }

        private void InitializeComponent()
        {
            this.xtcMapTitle = new DevExpress.XtraTab.XtraTabControl();
            this.xtpNormal = new DevExpress.XtraTab.XtraTabPage();
            this.btnSymbol = new DevExpress.XtraEditors.SimpleButton();
            this.txtFont = new System.Windows.Forms.TextBox();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.nudYo = new DevExpress.XtraEditors.SpinEdit();
            this.lbYo = new DevExpress.XtraEditors.LabelControl();
            this.nudXo = new DevExpress.XtraEditors.SpinEdit();
            this.lbXo = new DevExpress.XtraEditors.LabelControl();
            this.nudAngle = new DevExpress.XtraEditors.SpinEdit();
            this.lbAngle = new DevExpress.XtraEditors.LabelControl();
            this.lbTxt = new DevExpress.XtraEditors.LabelControl();
            this.gbVAlign = new System.Windows.Forms.GroupBox();
            this.rgVAlign = new DevExpress.XtraEditors.RadioGroup();
            this.gbHAlign = new System.Windows.Forms.GroupBox();
            this.rgHAlign = new DevExpress.XtraEditors.RadioGroup();
            this.xtpFormat = new DevExpress.XtraTab.XtraTabPage();
            this.cbLte = new DevExpress.XtraEditors.CheckEdit();
            this.numericUpDown6 = new DevExpress.XtraEditors.SpinEdit();
            this.lbWSpace = new DevExpress.XtraEditors.LabelControl();
            this.nud = new DevExpress.XtraEditors.SpinEdit();
            this.lbCharWidth = new DevExpress.XtraEditors.LabelControl();
            this.nudFlipAngle = new DevExpress.XtraEditors.SpinEdit();
            this.lbFlipAngle = new DevExpress.XtraEditors.LabelControl();
            this.nudLeading = new DevExpress.XtraEditors.SpinEdit();
            this.lbLeading = new DevExpress.XtraEditors.LabelControl();
            this.nudCharSpa = new DevExpress.XtraEditors.SpinEdit();
            this.lbCharSpace = new DevExpress.XtraEditors.LabelControl();
            this.gbCase = new System.Windows.Forms.GroupBox();
            this.rgCase = new DevExpress.XtraEditors.RadioGroup();
            this.gbPosition = new System.Windows.Forms.GroupBox();
            this.rgTextPos = new DevExpress.XtraEditors.RadioGroup();
            this.btOk = new DevExpress.XtraEditors.SimpleButton();
            this.btCancel = new DevExpress.XtraEditors.SimpleButton();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.xtcMapTitle)).BeginInit();
            this.xtcMapTitle.SuspendLayout();
            this.xtpNormal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudYo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudXo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAngle.Properties)).BeginInit();
            this.gbVAlign.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rgVAlign.Properties)).BeginInit();
            this.gbHAlign.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rgHAlign.Properties)).BeginInit();
            this.xtpFormat.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbLte.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown6.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFlipAngle.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLeading.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCharSpa.Properties)).BeginInit();
            this.gbCase.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rgCase.Properties)).BeginInit();
            this.gbPosition.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rgTextPos.Properties)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // xtcMapTitle
            // 
            this.xtcMapTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.xtcMapTitle.Location = new System.Drawing.Point(0, 0);
            this.xtcMapTitle.Name = "xtcMapTitle";
            this.xtcMapTitle.SelectedTabPage = this.xtpNormal;
            this.xtcMapTitle.Size = new System.Drawing.Size(411, 393);
            this.xtcMapTitle.TabIndex = 0;
            this.xtcMapTitle.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtpNormal,
            this.xtpFormat});
            // 
            // xtpNormal
            // 
            this.xtpNormal.Controls.Add(this.btnSymbol);
            this.xtpNormal.Controls.Add(this.txtFont);
            this.xtpNormal.Controls.Add(this.labelControl1);
            this.xtpNormal.Controls.Add(this.txtTitle);
            this.xtpNormal.Controls.Add(this.nudYo);
            this.xtpNormal.Controls.Add(this.lbYo);
            this.xtpNormal.Controls.Add(this.nudXo);
            this.xtpNormal.Controls.Add(this.lbXo);
            this.xtpNormal.Controls.Add(this.nudAngle);
            this.xtpNormal.Controls.Add(this.lbAngle);
            this.xtpNormal.Controls.Add(this.lbTxt);
            this.xtpNormal.Controls.Add(this.gbVAlign);
            this.xtpNormal.Controls.Add(this.gbHAlign);
            this.xtpNormal.Name = "xtpNormal";
            this.xtpNormal.Size = new System.Drawing.Size(405, 364);
            this.xtpNormal.Text = "普通";
            // 
            // btnSymbol
            // 
            this.btnSymbol.Location = new System.Drawing.Point(288, 152);
            this.btnSymbol.Name = "btnSymbol";
            this.btnSymbol.Size = new System.Drawing.Size(87, 27);
            this.btnSymbol.TabIndex = 85;
            this.btnSymbol.Text = "文本符号";
            this.btnSymbol.Click += new System.EventHandler(this.btnSymbol_Click);
            // 
            // txtFont
            // 
            this.txtFont.Location = new System.Drawing.Point(62, 152);
            this.txtFont.Multiline = true;
            this.txtFont.Name = "txtFont";
            this.txtFont.ReadOnly = true;
            this.txtFont.Size = new System.Drawing.Size(198, 24);
            this.txtFont.TabIndex = 84;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(22, 154);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(28, 14);
            this.labelControl1.TabIndex = 83;
            this.labelControl1.Text = "字体:";
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(22, 40);
            this.txtTitle.Multiline = true;
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(353, 91);
            this.txtTitle.TabIndex = 82;
            this.txtTitle.TextChanged += new System.EventHandler(this.txtTitle_TextChanged);
            // 
            // nudYo
            // 
            this.nudYo.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudYo.Location = new System.Drawing.Point(267, 224);
            this.nudYo.Name = "nudYo";
            this.nudYo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.nudYo.Size = new System.Drawing.Size(97, 20);
            this.nudYo.TabIndex = 80;
            this.nudYo.ValueChanged += new System.EventHandler(this.nudYo_ValueChanged);
            // 
            // lbYo
            // 
            this.lbYo.Location = new System.Drawing.Point(204, 226);
            this.lbYo.Name = "lbYo";
            this.lbYo.Size = new System.Drawing.Size(48, 14);
            this.lbYo.TabIndex = 79;
            this.lbYo.Text = "Y偏移量:";
            // 
            // nudXo
            // 
            this.nudXo.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudXo.Location = new System.Drawing.Point(84, 224);
            this.nudXo.Name = "nudXo";
            this.nudXo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.nudXo.Size = new System.Drawing.Size(97, 20);
            this.nudXo.TabIndex = 71;
            this.nudXo.ValueChanged += new System.EventHandler(this.nudXo_ValueChanged);
            // 
            // lbXo
            // 
            this.lbXo.Location = new System.Drawing.Point(22, 226);
            this.lbXo.Name = "lbXo";
            this.lbXo.Size = new System.Drawing.Size(47, 14);
            this.lbXo.TabIndex = 70;
            this.lbXo.Text = "X偏移量:";
            // 
            // nudAngle
            // 
            this.nudAngle.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudAngle.Location = new System.Drawing.Point(62, 188);
            this.nudAngle.Name = "nudAngle";
            this.nudAngle.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.nudAngle.Size = new System.Drawing.Size(112, 20);
            this.nudAngle.TabIndex = 69;
            this.nudAngle.ValueChanged += new System.EventHandler(this.nudAngle_ValueChanged);
            // 
            // lbAngle
            // 
            this.lbAngle.Location = new System.Drawing.Point(22, 188);
            this.lbAngle.Name = "lbAngle";
            this.lbAngle.Size = new System.Drawing.Size(28, 14);
            this.lbAngle.TabIndex = 68;
            this.lbAngle.Text = "倾角:";
            // 
            // lbTxt
            // 
            this.lbTxt.Location = new System.Drawing.Point(22, 16);
            this.lbTxt.Name = "lbTxt";
            this.lbTxt.Size = new System.Drawing.Size(28, 14);
            this.lbTxt.TabIndex = 60;
            this.lbTxt.Text = "文本:";
            // 
            // gbVAlign
            // 
            this.gbVAlign.Controls.Add(this.rgVAlign);
            this.gbVAlign.Location = new System.Drawing.Point(209, 273);
            this.gbVAlign.Name = "gbVAlign";
            this.gbVAlign.Size = new System.Drawing.Size(155, 78);
            this.gbVAlign.TabIndex = 52;
            this.gbVAlign.TabStop = false;
            this.gbVAlign.Text = "垂直对齐";
            // 
            // rgVAlign
            // 
            this.rgVAlign.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rgVAlign.Location = new System.Drawing.Point(3, 18);
            this.rgVAlign.Name = "rgVAlign";
            this.rgVAlign.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.rgVAlign.Properties.Appearance.Options.UseBackColor = true;
            this.rgVAlign.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.rgVAlign.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "顶端"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "底端"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "居中"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "基线")});
            this.rgVAlign.Size = new System.Drawing.Size(149, 57);
            this.rgVAlign.TabIndex = 0;
            this.rgVAlign.SelectedIndexChanged += new System.EventHandler(this.rgVAlign_SelectedIndexChanged);
            // 
            // gbHAlign
            // 
            this.gbHAlign.Controls.Add(this.rgHAlign);
            this.gbHAlign.Location = new System.Drawing.Point(22, 273);
            this.gbHAlign.Name = "gbHAlign";
            this.gbHAlign.Size = new System.Drawing.Size(159, 78);
            this.gbHAlign.TabIndex = 51;
            this.gbHAlign.TabStop = false;
            this.gbHAlign.Text = "水平对齐";
            // 
            // rgHAlign
            // 
            this.rgHAlign.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rgHAlign.Location = new System.Drawing.Point(3, 18);
            this.rgHAlign.Name = "rgHAlign";
            this.rgHAlign.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.rgHAlign.Properties.Appearance.Options.UseBackColor = true;
            this.rgHAlign.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.rgHAlign.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "靠左"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "靠右"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "居中"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "分散")});
            this.rgHAlign.Size = new System.Drawing.Size(153, 57);
            this.rgHAlign.TabIndex = 0;
            this.rgHAlign.SelectedIndexChanged += new System.EventHandler(this.rgHAlign_SelectedIndexChanged);
            // 
            // xtpFormat
            // 
            this.xtpFormat.Controls.Add(this.cbLte);
            this.xtpFormat.Controls.Add(this.numericUpDown6);
            this.xtpFormat.Controls.Add(this.lbWSpace);
            this.xtpFormat.Controls.Add(this.nud);
            this.xtpFormat.Controls.Add(this.lbCharWidth);
            this.xtpFormat.Controls.Add(this.nudFlipAngle);
            this.xtpFormat.Controls.Add(this.lbFlipAngle);
            this.xtpFormat.Controls.Add(this.nudLeading);
            this.xtpFormat.Controls.Add(this.lbLeading);
            this.xtpFormat.Controls.Add(this.nudCharSpa);
            this.xtpFormat.Controls.Add(this.lbCharSpace);
            this.xtpFormat.Controls.Add(this.gbCase);
            this.xtpFormat.Controls.Add(this.gbPosition);
            this.xtpFormat.Name = "xtpFormat";
            this.xtpFormat.Size = new System.Drawing.Size(405, 364);
            this.xtpFormat.Text = "格式化文本";
            // 
            // cbLte
            // 
            this.cbLte.Location = new System.Drawing.Point(194, 254);
            this.cbLte.Name = "cbLte";
            this.cbLte.Properties.Caption = "字距调整";
            this.cbLte.Size = new System.Drawing.Size(87, 19);
            this.cbLte.TabIndex = 36;
            this.cbLte.CheckedChanged += new System.EventHandler(this.cbLte_CheckedChanged);
            // 
            // numericUpDown6
            // 
            this.numericUpDown6.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.numericUpDown6.Location = new System.Drawing.Point(253, 195);
            this.numericUpDown6.Name = "numericUpDown6";
            this.numericUpDown6.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.numericUpDown6.Size = new System.Drawing.Size(126, 20);
            this.numericUpDown6.TabIndex = 35;
            this.numericUpDown6.ValueChanged += new System.EventHandler(this.numericUpDown6_ValueChanged);
            // 
            // lbWSpace
            // 
            this.lbWSpace.Location = new System.Drawing.Point(196, 198);
            this.lbWSpace.Name = "lbWSpace";
            this.lbWSpace.Size = new System.Drawing.Size(40, 14);
            this.lbWSpace.TabIndex = 34;
            this.lbWSpace.Text = "词间距:";
            // 
            // nud
            // 
            this.nud.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nud.Location = new System.Drawing.Point(253, 149);
            this.nud.Name = "nud";
            this.nud.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.nud.Size = new System.Drawing.Size(126, 20);
            this.nud.TabIndex = 33;
            this.nud.ValueChanged += new System.EventHandler(this.nud_ValueChanged);
            // 
            // lbCharWidth
            // 
            this.lbCharWidth.Location = new System.Drawing.Point(182, 154);
            this.lbCharWidth.Name = "lbCharWidth";
            this.lbCharWidth.Size = new System.Drawing.Size(52, 14);
            this.lbCharWidth.TabIndex = 32;
            this.lbCharWidth.Text = "字符宽度:";
            // 
            // nudFlipAngle
            // 
            this.nudFlipAngle.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudFlipAngle.Location = new System.Drawing.Point(253, 104);
            this.nudFlipAngle.Name = "nudFlipAngle";
            this.nudFlipAngle.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.nudFlipAngle.Size = new System.Drawing.Size(126, 20);
            this.nudFlipAngle.TabIndex = 31;
            this.nudFlipAngle.ValueChanged += new System.EventHandler(this.nudFlipAngle_ValueChanged);
            // 
            // lbFlipAngle
            // 
            this.lbFlipAngle.Location = new System.Drawing.Point(196, 103);
            this.lbFlipAngle.Name = "lbFlipAngle";
            this.lbFlipAngle.Size = new System.Drawing.Size(40, 14);
            this.lbFlipAngle.TabIndex = 30;
            this.lbFlipAngle.Text = "偏转角:";
            // 
            // nudLeading
            // 
            this.nudLeading.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudLeading.Location = new System.Drawing.Point(253, 58);
            this.nudLeading.Name = "nudLeading";
            this.nudLeading.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.nudLeading.Size = new System.Drawing.Size(126, 20);
            this.nudLeading.TabIndex = 29;
            this.nudLeading.ValueChanged += new System.EventHandler(this.nudLeading_ValueChanged);
            // 
            // lbLeading
            // 
            this.lbLeading.Location = new System.Drawing.Point(210, 58);
            this.lbLeading.Name = "lbLeading";
            this.lbLeading.Size = new System.Drawing.Size(28, 14);
            this.lbLeading.TabIndex = 28;
            this.lbLeading.Text = "行距:";
            // 
            // nudCharSpa
            // 
            this.nudCharSpa.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudCharSpa.Location = new System.Drawing.Point(253, 13);
            this.nudCharSpa.Name = "nudCharSpa";
            this.nudCharSpa.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.nudCharSpa.Size = new System.Drawing.Size(126, 20);
            this.nudCharSpa.TabIndex = 27;
            this.nudCharSpa.ValueChanged += new System.EventHandler(this.nudCharSpa_ValueChanged);
            // 
            // lbCharSpace
            // 
            this.lbCharSpace.Location = new System.Drawing.Point(182, 16);
            this.lbCharSpace.Name = "lbCharSpace";
            this.lbCharSpace.Size = new System.Drawing.Size(52, 14);
            this.lbCharSpace.TabIndex = 26;
            this.lbCharSpace.Text = "字符间距:";
            // 
            // gbCase
            // 
            this.gbCase.Controls.Add(this.rgCase);
            this.gbCase.Location = new System.Drawing.Point(3, 163);
            this.gbCase.Name = "gbCase";
            this.gbCase.Size = new System.Drawing.Size(152, 117);
            this.gbCase.TabIndex = 14;
            this.gbCase.TabStop = false;
            this.gbCase.Text = "文本大小写";
            // 
            // rgCase
            // 
            this.rgCase.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rgCase.Location = new System.Drawing.Point(3, 18);
            this.rgCase.Name = "rgCase";
            this.rgCase.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.rgCase.Properties.Appearance.Options.UseBackColor = true;
            this.rgCase.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.rgCase.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "规则"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "全部大写"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "小型大写字母")});
            this.rgCase.Size = new System.Drawing.Size(146, 96);
            this.rgCase.TabIndex = 0;
            this.rgCase.SelectedIndexChanged += new System.EventHandler(this.rgCase_SelectedIndexChanged);
            // 
            // gbPosition
            // 
            this.gbPosition.Controls.Add(this.rgTextPos);
            this.gbPosition.Location = new System.Drawing.Point(10, 16);
            this.gbPosition.Name = "gbPosition";
            this.gbPosition.Size = new System.Drawing.Size(152, 117);
            this.gbPosition.TabIndex = 13;
            this.gbPosition.TabStop = false;
            this.gbPosition.Text = "文本位置";
            // 
            // rgTextPos
            // 
            this.rgTextPos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rgTextPos.Location = new System.Drawing.Point(3, 18);
            this.rgTextPos.Name = "rgTextPos";
            this.rgTextPos.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.rgTextPos.Properties.Appearance.Options.UseBackColor = true;
            this.rgTextPos.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.rgTextPos.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "规则"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "上标"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "下标")});
            this.rgTextPos.Size = new System.Drawing.Size(146, 96);
            this.rgTextPos.TabIndex = 0;
            this.rgTextPos.SelectedIndexChanged += new System.EventHandler(this.rgTextPos_SelectedIndexChanged);
            // 
            // btOk
            // 
            this.btOk.Location = new System.Drawing.Point(97, 12);
            this.btOk.Name = "btOk";
            this.btOk.Size = new System.Drawing.Size(87, 27);
            this.btOk.TabIndex = 2;
            this.btOk.Text = "确定";
            this.btOk.Click += new System.EventHandler(this.btOk_Click);
            // 
            // btCancel
            // 
            this.btCancel.Location = new System.Drawing.Point(216, 12);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(87, 27);
            this.btCancel.TabIndex = 3;
            this.btCancel.Text = "取消";
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btOk);
            this.panel1.Controls.Add(this.btCancel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 393);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(411, 64);
            this.panel1.TabIndex = 4;
            // 
            // DevText
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.Appearance.BackColor2 = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.ClientSize = new System.Drawing.Size(411, 457);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.xtcMapTitle);
            this.LookAndFeel.SkinName = "Blue";
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DevText";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "文本";
            this.Load += new System.EventHandler(this.MapTitle_Load);
            ((System.ComponentModel.ISupportInitialize)(this.xtcMapTitle)).EndInit();
            this.xtcMapTitle.ResumeLayout(false);
            this.xtpNormal.ResumeLayout(false);
            this.xtpNormal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudYo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudXo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAngle.Properties)).EndInit();
            this.gbVAlign.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rgVAlign.Properties)).EndInit();
            this.gbHAlign.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rgHAlign.Properties)).EndInit();
            this.xtpFormat.ResumeLayout(false);
            this.xtpFormat.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbLte.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown6.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFlipAngle.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLeading.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCharSpa.Properties)).EndInit();
            this.gbCase.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rgCase.Properties)).EndInit();
            this.gbPosition.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rgTextPos.Properties)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private void MapTitle_Load(object sender, EventArgs e)
        {
            this.init = true;
            try
            {
                stdole.IFontDisp font = this._txtElement.Symbol.Font;
                IFormattedTextSymbol symbol = (IFormattedTextSymbol) this._txtElement.Symbol;
                ISimpleTextSymbol symbol2 = (ISimpleTextSymbol) this._txtElement.Symbol;
                this.FillSymbol();
                this.FillFamily();
                this.txtTitle.Text = this._txtElement.Symbol.Text;
                this.txtFont.Text = this._txtElement.Symbol.Font.Name + " " + this._txtElement.Symbol.Font.Size;
                this.nudAngle.Value = decimal.Parse(this._txtElement.Symbol.Angle.ToString());
                this.nudXo.Value = decimal.Parse(symbol2.XOffset.ToString());
                this.nudYo.Value = decimal.Parse(symbol2.YOffset.ToString());
                switch (symbol.HorizontalAlignment)
                {
                    case esriTextHorizontalAlignment.esriTHALeft:
                        this.rgHAlign.SelectedIndex = 0;
                        break;

                    case esriTextHorizontalAlignment.esriTHACenter:
                        this.rgHAlign.SelectedIndex = 2;
                        break;

                    case esriTextHorizontalAlignment.esriTHARight:
                        this.rgHAlign.SelectedIndex = 1;
                        break;

                    case esriTextHorizontalAlignment.esriTHAFull:
                        this.rgHAlign.SelectedIndex = 3;
                        break;
                }
                switch (symbol.VerticalAlignment)
                {
                    case esriTextVerticalAlignment.esriTVATop:
                        this.rgVAlign.SelectedIndex = 0;
                        break;

                    case esriTextVerticalAlignment.esriTVACenter:
                        this.rgVAlign.SelectedIndex = 2;
                        break;

                    case esriTextVerticalAlignment.esriTVABaseline:
                        this.rgVAlign.SelectedIndex = 3;
                        break;

                    case esriTextVerticalAlignment.esriTVABottom:
                        this.rgVAlign.SelectedIndex = 1;
                        break;
                }
                switch (symbol.Position)
                {
                    case esriTextPosition.esriTPNormal:
                        this.rgTextPos.SelectedIndex = 0;
                        break;

                    case esriTextPosition.esriTPSuperscript:
                        this.rgTextPos.SelectedIndex = 2;
                        break;

                    case esriTextPosition.esriTPSubscript:
                        this.rgTextPos.SelectedIndex = 1;
                        break;
                }
                switch (symbol.Case)
                {
                    case esriTextCase.esriTCNormal:
                        this.rgCase.SelectedIndex = 0;
                        break;

                    case esriTextCase.esriTCAllCaps:
                        this.rgCase.SelectedIndex = 1;
                        break;

                    case esriTextCase.esriTCSmallCaps:
                        this.rgCase.SelectedIndex = 2;
                        break;
                }
                this.nudCharSpa.Value = decimal.Parse(symbol.CharacterSpacing.ToString());
                this.nudLeading.Value = decimal.Parse(symbol.Leading.ToString());
                this.nudFlipAngle.Value = decimal.Parse(symbol.FlipAngle.ToString());
                this.nud.Value = decimal.Parse(symbol.CharacterWidth.ToString());
                this.numericUpDown6.Value = decimal.Parse(symbol.WordSpacing.ToString());
                if (symbol.Kerning)
                {
                    this.cbLte.Checked = true;
                }
                this.init = false;
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "Cartography.Element.DevText", "MapTitle_Load", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void nud_ValueChanged(object sender, EventArgs e)
        {
            if (!this.init)
            {
                IFormattedTextSymbol symbol = (IFormattedTextSymbol) this._txtElement.Symbol;
                symbol.CharacterWidth = double.Parse(this.nud.Value.ToString());
                this._txtElement.Symbol = symbol;
            }
        }

        private void nudAngle_ValueChanged(object sender, EventArgs e)
        {
            if (!this.init)
            {
                ITextSymbol symbol = this._txtElement.Symbol;
                symbol.Angle = double.Parse(this.nudAngle.Value.ToString());
                this._txtElement.Symbol = symbol;
            }
        }

        private void nudCharSpa_ValueChanged(object sender, EventArgs e)
        {
            if (!this.init)
            {
                IFormattedTextSymbol symbol = (IFormattedTextSymbol) this._txtElement.Symbol;
                symbol.CharacterSpacing = double.Parse(this.nudCharSpa.Value.ToString());
                this._txtElement.Symbol = symbol;
            }
        }

        private void nudFlipAngle_ValueChanged(object sender, EventArgs e)
        {
            if (!this.init)
            {
                IFormattedTextSymbol symbol = (IFormattedTextSymbol) this._txtElement.Symbol;
                symbol.FlipAngle = double.Parse(this.nudFlipAngle.Value.ToString());
                this._txtElement.Symbol = symbol;
            }
        }

        private void nudLeading_ValueChanged(object sender, EventArgs e)
        {
            if (!this.init)
            {
                IFormattedTextSymbol symbol = (IFormattedTextSymbol) this._txtElement.Symbol;
                symbol.Leading = double.Parse(this.nudLeading.Value.ToString());
                this._txtElement.Symbol = symbol;
            }
        }

        private void nudXo_ValueChanged(object sender, EventArgs e)
        {
            if (!this.init)
            {
                ISimpleTextSymbol symbol = (ISimpleTextSymbol) this._txtElement.Symbol;
                symbol.XOffset = double.Parse(this.nudXo.Value.ToString());
                this._txtElement.Symbol = symbol;
            }
        }

        private void nudYo_ValueChanged(object sender, EventArgs e)
        {
            if (!this.init)
            {
                ISimpleTextSymbol symbol = (ISimpleTextSymbol) this._txtElement.Symbol;
                symbol.YOffset = double.Parse(this.nudYo.Value.ToString());
                this._txtElement.Symbol = symbol;
            }
        }

        private void numericUpDown6_ValueChanged(object sender, EventArgs e)
        {
            if (!this.init)
            {
                IFormattedTextSymbol symbol = (IFormattedTextSymbol) this._txtElement.Symbol;
                symbol.WordSpacing = double.Parse(this.numericUpDown6.Value.ToString());
                this._txtElement.Symbol = symbol;
            }
        }

        private void rgCase_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this.init)
            {
                IFormattedTextSymbol symbol = null;
                switch (this.rgCase.SelectedIndex)
                {
                    case 0:
                        symbol = (IFormattedTextSymbol) this._txtElement.Symbol;
                        symbol.Case = esriTextCase.esriTCNormal;
                        this._txtElement.Symbol = symbol;
                        return;

                    case 1:
                        symbol = (IFormattedTextSymbol) this._txtElement.Symbol;
                        symbol.Case = esriTextCase.esriTCAllCaps;
                        this._txtElement.Symbol = symbol;
                        return;

                    case 2:
                        symbol = (IFormattedTextSymbol) this._txtElement.Symbol;
                        symbol.Case = esriTextCase.esriTCSmallCaps;
                        this._txtElement.Symbol = symbol;
                        return;
                }
            }
        }

        private void rgHAlign_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this.init)
            {
                IFormattedTextSymbol symbol = null;
                switch (this.rgHAlign.SelectedIndex)
                {
                    case 0:
                        symbol = (IFormattedTextSymbol) this._txtElement.Symbol;
                        symbol.HorizontalAlignment = esriTextHorizontalAlignment.esriTHALeft;
                        this._txtElement.Symbol = symbol;
                        return;

                    case 1:
                        symbol = (IFormattedTextSymbol) this._txtElement.Symbol;
                        symbol.HorizontalAlignment = esriTextHorizontalAlignment.esriTHARight;
                        this._txtElement.Symbol = symbol;
                        return;

                    case 2:
                        symbol = (IFormattedTextSymbol) this._txtElement.Symbol;
                        symbol.HorizontalAlignment = esriTextHorizontalAlignment.esriTHACenter;
                        this._txtElement.Symbol = symbol;
                        return;

                    case 3:
                        symbol = (IFormattedTextSymbol) this._txtElement.Symbol;
                        symbol.HorizontalAlignment = esriTextHorizontalAlignment.esriTHAFull;
                        this._txtElement.Symbol = symbol;
                        return;
                }
            }
        }

        private void rgTextPos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this.init)
            {
                IFormattedTextSymbol symbol = null;
                switch (this.rgTextPos.SelectedIndex)
                {
                    case 0:
                        symbol = (IFormattedTextSymbol) this._txtElement.Symbol;
                        symbol.Position = esriTextPosition.esriTPNormal;
                        this._txtElement.Symbol = symbol;
                        return;

                    case 1:
                        symbol = (IFormattedTextSymbol) this._txtElement.Symbol;
                        symbol.Position = esriTextPosition.esriTPSuperscript;
                        this._txtElement.Symbol = symbol;
                        return;

                    case 2:
                        symbol = (IFormattedTextSymbol) this._txtElement.Symbol;
                        symbol.Position = esriTextPosition.esriTPSubscript;
                        this._txtElement.Symbol = symbol;
                        return;
                }
            }
        }

        private void rgVAlign_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this.init)
            {
                IFormattedTextSymbol symbol = null;
                switch (this.rgVAlign.SelectedIndex)
                {
                    case 0:
                        symbol = (IFormattedTextSymbol) this._txtElement.Symbol;
                        symbol.VerticalAlignment = esriTextVerticalAlignment.esriTVATop;
                        this._txtElement.Symbol = symbol;
                        return;

                    case 1:
                        symbol = (IFormattedTextSymbol) this._txtElement.Symbol;
                        symbol.VerticalAlignment = esriTextVerticalAlignment.esriTVABottom;
                        this._txtElement.Symbol = symbol;
                        return;

                    case 2:
                        symbol = (IFormattedTextSymbol) this._txtElement.Symbol;
                        symbol.VerticalAlignment = esriTextVerticalAlignment.esriTVACenter;
                        this._txtElement.Symbol = symbol;
                        return;

                    case 3:
                        symbol = (IFormattedTextSymbol) this._txtElement.Symbol;
                        symbol.VerticalAlignment = esriTextVerticalAlignment.esriTVABaseline;
                        this._txtElement.Symbol = symbol;
                        return;
                }
            }
        }

        private void txtTitle_TextChanged(object sender, EventArgs e)
        {
            if (!this.init)
            {
                this._txtElement.Text = this.txtTitle.Text;
            }
        }

        public IActiveView ActiveView
        {
            set
            {
                this._activeview = value;
            }
        }

        public IPoint Point
        {
            set
            {
                this.m_Point = value;
            }
        }

        public ITextElement PreElement
        {
            set
            {
                this._preElement = value;
                CloneService.Clone(this._preElement, this._txtElement);
            }
        }

        public ITextSymbol PreTextSymbol
        {
            get
            {
                return this._txtElement.Symbol;
            }
            set
            {
                this._preTextSymbol = value;
                object pTargetObj = new TextSymbolClass();
                CloneService.Clone(this._preTextSymbol, pTargetObj);
                ITextSymbol symbol = (ITextSymbol) pTargetObj;
                this._txtElement.Text = symbol.Text;
                this._txtElement.Symbol = symbol;
            }
        }
        
        /// <summary>
        /// 设置IPageLayoutControl的值。
        /// IPageLayoutControl接口提供对控制PageLayoutControl的成员的访问。IPageLayoutControl接口是与PageLayoutControl相关的任何任务的起点，例如设置一般外观，设置页面和显示属性，添加和查找元素，加载地图文档和打印。
        /// </summary>
        public IPageLayoutControl PageLayoutControl
        {
            set
            {
                this._control = value;
            }
        }
    }
}

