namespace Cartography.Element
{
    using Cartography;
    using Cartography.Base;
    using DevExpress.XtraEditors;
    using DevExpress.XtraEditors.Controls;
    using ESRI.ArcGIS.Carto;
    using ESRI.ArcGIS.Controls;
    using ESRI.ArcGIS.Display;
    using FormBase;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Utilities;

    public class DevFrame : FormBase3
    {
        private IActiveView _activeView;
        private IMapFrame _mapFrame;
        private ISymbolBackground background;
        private ISymbolBorder border;
        private SimpleButton btBack;
        private SimpleButton btBorder;
        private SimpleButton btCancel;
        private SimpleButton btOK;
        private SimpleButton btShadow;
        private IContainer components;
        private GroupBox gbBack;
        private GroupBox gbBorder;
        private GroupBox gbDropShadow;
        private bool init;
        private LabelControl labelControl1;
        private LabelControl labelControl2;
        private LabelControl labelControl6;
        private LabelControl lbBackGap;
        private LabelControl lbBackRounding;
        private LabelControl lbBackSymbol;
        private LabelControl lbBackX;
        private Label lbBackXPts;
        private LabelControl lbBackY;
        private LabelControl lbBackYPts;
        private LabelControl lbBorderGap;
        private LabelControl lbBorderRounding;
        private LabelControl lbBorderSymbol;
        private LabelControl lbBorderX;
        private Label lbBorderXPts;
        private LabelControl lbBorderY;
        private LabelControl lbBorderYPts;
        private LabelControl lbShadowGap;
        private LabelControl lbShadowRounding;
        private LabelControl lbShadowSymbol;
        private LabelControl lbShadowX;
        private LabelControl lbShadowXPts;
        private LabelControl lbShadowY;
        private LabelControl lbShadowYPts;
        private const string mClassName = "Cartography.Element.DevFrame";
        private ErrorOpt mErrOpt = UtilFactory.GetErrorOpt();
        private string mSubSysName = UtilFactory.GetConfigOpt().GetSystemName();
        private SpinEdit nudBackRounding;
        private SpinEdit nudBackX;
        private SpinEdit nudBackY;
        private SpinEdit nudBorderRounding;
        private SpinEdit nudBorderX;
        private SpinEdit nudBorderY;
        private SpinEdit nudShadowRounding;
        private SpinEdit nudShadowX;
        private SpinEdit nudShadowY;
        private PictureEdit pbBack;
        private PictureEdit pbBorder;
        private PictureEdit pbShadow;
        private ISymbolShadow shadow;

        public DevFrame(IActiveView pActiveView)
        {
            this.InitializeComponent();
            this._activeView = pActiveView;
        }

        private void btBack_Click(object sender, EventArgs e)
        {
            if (this.background == null)
            {
                this.background = new SymbolBackgroundClass();
                IFillSymbol fillSymbol = this.background.FillSymbol;
                ILineSymbol symbol2 = new CartographicLineSymbolClass();
                symbol2.Width = 0.0;
                fillSymbol.Outline = symbol2;
                IColor color = fillSymbol.Color;
                color.NullColor = true;
                fillSymbol.Color = color;
                this.background.FillSymbol = fillSymbol;
            }
            FrameSymbolSelector selector = new FrameSymbolSelector();
            IStyleGalleryItem item = selector.GetItem(this.background, esriSymbologyStyleClass.esriStyleClassBackgrounds);
            if (selector.DialogResult == DialogResult.OK)
            {
                selector.Dispose();
                if (item != null)
                {
                    if (item.Name != "无")
                    {
                        this.background.FillSymbol = ((ISymbolBackground) item.Item).FillSymbol;
                        Bitmap bitmap = BitmapManager.GetSymbolBitMap(this.background, this.pbBack.Width, this.pbBack.Height);
                        bitmap.MakeTransparent(bitmap.GetPixel(1, 1));
                        this.pbBack.Image = bitmap;
                    }
                    else
                    {
                        this.pbBack.Image = null;
                        this.background = null;
                    }
                }
            }
        }

        private void btBorder_Click(object sender, EventArgs e)
        {
            if (this.border == null)
            {
                this.border = new SymbolBorderClass();
                ILineSymbol lineSymbol = this.border.LineSymbol;
                lineSymbol.Width = 0.0;
                this.border.LineSymbol = lineSymbol;
            }
            FrameSymbolSelector selector = new FrameSymbolSelector();
            IStyleGalleryItem item = selector.GetItem(this.border, esriSymbologyStyleClass.esriStyleClassBorders);
            if ((selector.DialogResult == DialogResult.OK) && (item != null))
            {
                if (item.Name != "无")
                {
                    this.border.LineSymbol = ((ISymbolBorder) item.Item).LineSymbol;
                    Bitmap bitmap = BitmapManager.GetSymbolBitMap(this.border, this.pbBorder.Width, this.pbBorder.Height);
                    this.pbBorder.Image = bitmap;
                }
                else
                {
                    this.pbBorder.Image = null;
                    this.border = null;
                }
            }
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        private void btOK_Click(object sender, EventArgs e)
        {
            this.preView();
            base.Close();
        }

        private void btPreview_Click(object sender, EventArgs e)
        {
            IFrameProperties properties = (IFrameProperties) this._mapFrame;
            properties.Background = this.background;
            properties.Border = this.border;
            properties.Shadow = this.shadow;
            this._activeView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, this._activeView.Extent);
        }

        private void btShadow_Click(object sender, EventArgs e)
        {
            if (this.shadow == null)
            {
                this.shadow = new SymbolShadowClass();
                IFillSymbol fillSymbol = this.shadow.FillSymbol;
                ILineSymbol symbol2 = new CartographicLineSymbolClass();
                symbol2.Width = 0.0;
                fillSymbol.Outline = symbol2;
                IColor color = fillSymbol.Color;
                color.NullColor = true;
                fillSymbol.Color = color;
                this.shadow.FillSymbol = fillSymbol;
            }
            FrameSymbolSelector selector = new FrameSymbolSelector();
            IStyleGalleryItem item = selector.GetItem(this.shadow, esriSymbologyStyleClass.esriStyleClassShadows);
            if (selector.DialogResult == DialogResult.OK)
            {
                selector.Dispose();
                if (item != null)
                {
                    if (item.Name != "无")
                    {
                        this.shadow.FillSymbol = ((ISymbolShadow) item.Item).FillSymbol;
                        Bitmap bitmap = BitmapManager.GetSymbolBitMap(this.shadow, this.pbShadow.Width, this.pbShadow.Height);
                        bitmap.MakeTransparent(bitmap.GetPixel(1, 1));
                        this.pbShadow.Image = bitmap;
                    }
                    else
                    {
                        this.pbShadow.Image = null;
                        this.shadow = null;
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

        private void Frame_Load(object sender, EventArgs e)
        {
            this.InitialControl();
        }

        private void InitialControl()
        {
            this.init = true;
            IFrameProperties properties = null;
            try
            {
                IGraphicsContainer container = this._activeView as IGraphicsContainer;
                this._mapFrame = container.FindFrame(this._activeView.FocusMap) as IMapFrame;
                properties = (IFrameProperties) this._mapFrame;
                ISymbolBorder pSourceObj = (ISymbolBorder) properties.Border;
                ISymbolBackground background = (ISymbolBackground) properties.Background;
                ISymbolShadow shadow = (ISymbolShadow) properties.Shadow;
                IFrameDecoration decoration = null;
                Bitmap bitmap = null;
                if (((pSourceObj != null) || (background != null)) || (shadow != null))
                {
                    this.btOK.Text = "更新";
                }
                if (pSourceObj != null)
                {
                    this.border = new SymbolBorderClass();
                    CloneService.Clone(pSourceObj, this.border);
                    decoration = (IFrameDecoration) pSourceObj;
                    bitmap = BitmapManager.GetSymbolBitMap(pSourceObj, this.pbBorder.Width, this.pbBorder.Height);
                    this.pbBorder.Image = bitmap;
                    this.nudBorderRounding.Value = decimal.Parse(decoration.CornerRounding.ToString());
                    this.nudBorderX.Value = decimal.Parse(decoration.HorizontalSpacing.ToString());
                    this.nudBorderY.Value = decimal.Parse(decoration.VerticalSpacing.ToString());
                }
                if (background != null)
                {
                    this.background = new SymbolBackgroundClass();
                    CloneService.Clone(background, this.background);
                    decoration = (IFrameDecoration) background;
                    bitmap = BitmapManager.GetSymbolBitMap(background, this.pbBack.Width, this.pbBack.Height);
                    bitmap.MakeTransparent(bitmap.GetPixel(1, 1));
                    this.pbBack.Image = bitmap;
                    this.nudBackRounding.Value = decimal.Parse(background.CornerRounding.ToString());
                    this.nudBackX.Value = decimal.Parse(decoration.HorizontalSpacing.ToString());
                    this.nudBackY.Value = decimal.Parse(decoration.VerticalSpacing.ToString());
                }
                if (shadow != null)
                {
                    this.shadow = new SymbolShadowClass();
                    CloneService.Clone(shadow, this.shadow);
                    decoration = (IFrameDecoration) shadow;
                    bitmap = BitmapManager.GetSymbolBitMap(shadow, this.pbShadow.Width, this.pbShadow.Height);
                    bitmap.MakeTransparent(bitmap.GetPixel(1, 1));
                    this.pbShadow.Image = bitmap;
                    this.nudShadowRounding.Value = decimal.Parse(this.shadow.CornerRounding.ToString());
                    this.nudShadowX.Value = decimal.Parse(decoration.HorizontalSpacing.ToString());
                    this.nudShadowY.Value = decimal.Parse(decoration.VerticalSpacing.ToString());
                }
                this.init = false;
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "Cartography.Element.DevFrame", "InitialControl", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void InitializeComponent()
        {
            this.gbDropShadow = new System.Windows.Forms.GroupBox();
            this.lbShadowYPts = new DevExpress.XtraEditors.LabelControl();
            this.nudShadowY = new DevExpress.XtraEditors.SpinEdit();
            this.lbShadowY = new DevExpress.XtraEditors.LabelControl();
            this.lbShadowXPts = new DevExpress.XtraEditors.LabelControl();
            this.nudShadowX = new DevExpress.XtraEditors.SpinEdit();
            this.lbShadowX = new DevExpress.XtraEditors.LabelControl();
            this.lbShadowGap = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.nudShadowRounding = new DevExpress.XtraEditors.SpinEdit();
            this.lbShadowRounding = new DevExpress.XtraEditors.LabelControl();
            this.btShadow = new DevExpress.XtraEditors.SimpleButton();
            this.lbShadowSymbol = new DevExpress.XtraEditors.LabelControl();
            this.gbBack = new System.Windows.Forms.GroupBox();
            this.nudBackY = new DevExpress.XtraEditors.SpinEdit();
            this.nudBackX = new DevExpress.XtraEditors.SpinEdit();
            this.lbBackYPts = new DevExpress.XtraEditors.LabelControl();
            this.lbBackY = new DevExpress.XtraEditors.LabelControl();
            this.lbBackX = new DevExpress.XtraEditors.LabelControl();
            this.lbBackGap = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.nudBackRounding = new DevExpress.XtraEditors.SpinEdit();
            this.lbBackRounding = new DevExpress.XtraEditors.LabelControl();
            this.btBack = new DevExpress.XtraEditors.SimpleButton();
            this.lbBackSymbol = new DevExpress.XtraEditors.LabelControl();
            this.lbBackXPts = new System.Windows.Forms.Label();
            this.gbBorder = new System.Windows.Forms.GroupBox();
            this.nudBorderY = new DevExpress.XtraEditors.SpinEdit();
            this.nudBorderX = new DevExpress.XtraEditors.SpinEdit();
            this.lbBorderYPts = new DevExpress.XtraEditors.LabelControl();
            this.lbBorderY = new DevExpress.XtraEditors.LabelControl();
            this.lbBorderX = new DevExpress.XtraEditors.LabelControl();
            this.lbBorderGap = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.nudBorderRounding = new DevExpress.XtraEditors.SpinEdit();
            this.lbBorderRounding = new DevExpress.XtraEditors.LabelControl();
            this.btBorder = new DevExpress.XtraEditors.SimpleButton();
            this.lbBorderSymbol = new DevExpress.XtraEditors.LabelControl();
            this.lbBorderXPts = new System.Windows.Forms.Label();
            this.pbBorder = new DevExpress.XtraEditors.PictureEdit();
            this.pbBack = new DevExpress.XtraEditors.PictureEdit();
            this.pbShadow = new DevExpress.XtraEditors.PictureEdit();
            this.btOK = new DevExpress.XtraEditors.SimpleButton();
            this.btCancel = new DevExpress.XtraEditors.SimpleButton();
            this.gbDropShadow.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudShadowY.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudShadowX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudShadowRounding.Properties)).BeginInit();
            this.gbBack.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudBackY.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBackX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBackRounding.Properties)).BeginInit();
            this.gbBorder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudBorderY.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBorderX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBorderRounding.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBorder.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBack.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbShadow.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gbDropShadow
            // 
            this.gbDropShadow.Controls.Add(this.lbShadowYPts);
            this.gbDropShadow.Controls.Add(this.nudShadowY);
            this.gbDropShadow.Controls.Add(this.lbShadowY);
            this.gbDropShadow.Controls.Add(this.lbShadowXPts);
            this.gbDropShadow.Controls.Add(this.nudShadowX);
            this.gbDropShadow.Controls.Add(this.lbShadowX);
            this.gbDropShadow.Controls.Add(this.lbShadowGap);
            this.gbDropShadow.Controls.Add(this.labelControl2);
            this.gbDropShadow.Controls.Add(this.nudShadowRounding);
            this.gbDropShadow.Controls.Add(this.lbShadowRounding);
            this.gbDropShadow.Controls.Add(this.btShadow);
            this.gbDropShadow.Controls.Add(this.lbShadowSymbol);
            this.gbDropShadow.Location = new System.Drawing.Point(17, 299);
            this.gbDropShadow.Name = "gbDropShadow";
            this.gbDropShadow.Size = new System.Drawing.Size(343, 129);
            this.gbDropShadow.TabIndex = 34;
            this.gbDropShadow.TabStop = false;
            this.gbDropShadow.Text = "阴影";
            // 
            // lbShadowYPts
            // 
            this.lbShadowYPts.Location = new System.Drawing.Point(296, 69);
            this.lbShadowYPts.Name = "lbShadowYPts";
            this.lbShadowYPts.Size = new System.Drawing.Size(24, 14);
            this.lbShadowYPts.TabIndex = 51;
            this.lbShadowYPts.Text = "像素";
            // 
            // nudShadowY
            // 
            this.nudShadowY.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudShadowY.Location = new System.Drawing.Point(241, 65);
            this.nudShadowY.Name = "nudShadowY";
            this.nudShadowY.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.nudShadowY.Size = new System.Drawing.Size(51, 20);
            this.nudShadowY.TabIndex = 50;
            this.nudShadowY.ValueChanged += new System.EventHandler(this.nudShadowY_ValueChanged);
            // 
            // lbShadowY
            // 
            this.lbShadowY.Location = new System.Drawing.Point(209, 69);
            this.lbShadowY.Name = "lbShadowY";
            this.lbShadowY.Size = new System.Drawing.Size(12, 14);
            this.lbShadowY.TabIndex = 49;
            this.lbShadowY.Text = "Y:";
            // 
            // lbShadowXPts
            // 
            this.lbShadowXPts.Location = new System.Drawing.Point(154, 69);
            this.lbShadowXPts.Name = "lbShadowXPts";
            this.lbShadowXPts.Size = new System.Drawing.Size(24, 14);
            this.lbShadowXPts.TabIndex = 48;
            this.lbShadowXPts.Text = "像素";
            // 
            // nudShadowX
            // 
            this.nudShadowX.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudShadowX.Location = new System.Drawing.Point(99, 65);
            this.nudShadowX.Name = "nudShadowX";
            this.nudShadowX.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.nudShadowX.Size = new System.Drawing.Size(51, 20);
            this.nudShadowX.TabIndex = 47;
            this.nudShadowX.ValueChanged += new System.EventHandler(this.nudShadowX_ValueChanged);
            // 
            // lbShadowX
            // 
            this.lbShadowX.Location = new System.Drawing.Point(68, 69);
            this.lbShadowX.Name = "lbShadowX";
            this.lbShadowX.Size = new System.Drawing.Size(11, 14);
            this.lbShadowX.TabIndex = 46;
            this.lbShadowX.Text = "X:";
            // 
            // lbShadowGap
            // 
            this.lbShadowGap.Location = new System.Drawing.Point(13, 69);
            this.lbShadowGap.Name = "lbShadowGap";
            this.lbShadowGap.Size = new System.Drawing.Size(28, 14);
            this.lbShadowGap.TabIndex = 45;
            this.lbShadowGap.Text = "边距:";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(303, 27);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(12, 14);
            this.labelControl2.TabIndex = 44;
            this.labelControl2.Text = "%";
            // 
            // nudShadowRounding
            // 
            this.nudShadowRounding.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudShadowRounding.Location = new System.Drawing.Point(241, 23);
            this.nudShadowRounding.Name = "nudShadowRounding";
            this.nudShadowRounding.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.nudShadowRounding.Size = new System.Drawing.Size(51, 20);
            this.nudShadowRounding.TabIndex = 43;
            this.nudShadowRounding.ValueChanged += new System.EventHandler(this.nudShadowRounding_ValueChanged);
            // 
            // lbShadowRounding
            // 
            this.lbShadowRounding.Location = new System.Drawing.Point(190, 27);
            this.lbShadowRounding.Name = "lbShadowRounding";
            this.lbShadowRounding.Size = new System.Drawing.Size(28, 14);
            this.lbShadowRounding.TabIndex = 42;
            this.lbShadowRounding.Text = "圆角:";
            // 
            // btShadow
            // 
            this.btShadow.Location = new System.Drawing.Point(79, 22);
            this.btShadow.Name = "btShadow";
            this.btShadow.Size = new System.Drawing.Size(87, 27);
            this.btShadow.TabIndex = 41;
            this.btShadow.Text = "设置";
            this.btShadow.Click += new System.EventHandler(this.btShadow_Click);
            // 
            // lbShadowSymbol
            // 
            this.lbShadowSymbol.Location = new System.Drawing.Point(13, 27);
            this.lbShadowSymbol.Name = "lbShadowSymbol";
            this.lbShadowSymbol.Size = new System.Drawing.Size(28, 14);
            this.lbShadowSymbol.TabIndex = 40;
            this.lbShadowSymbol.Text = "符号 ";
            // 
            // gbBack
            // 
            this.gbBack.Controls.Add(this.nudBackY);
            this.gbBack.Controls.Add(this.nudBackX);
            this.gbBack.Controls.Add(this.lbBackYPts);
            this.gbBack.Controls.Add(this.lbBackY);
            this.gbBack.Controls.Add(this.lbBackX);
            this.gbBack.Controls.Add(this.lbBackGap);
            this.gbBack.Controls.Add(this.labelControl6);
            this.gbBack.Controls.Add(this.nudBackRounding);
            this.gbBack.Controls.Add(this.lbBackRounding);
            this.gbBack.Controls.Add(this.btBack);
            this.gbBack.Controls.Add(this.lbBackSymbol);
            this.gbBack.Controls.Add(this.lbBackXPts);
            this.gbBack.Location = new System.Drawing.Point(17, 156);
            this.gbBack.Name = "gbBack";
            this.gbBack.Size = new System.Drawing.Size(343, 129);
            this.gbBack.TabIndex = 33;
            this.gbBack.TabStop = false;
            this.gbBack.Text = "背景";
            // 
            // nudBackY
            // 
            this.nudBackY.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudBackY.Location = new System.Drawing.Point(241, 76);
            this.nudBackY.Name = "nudBackY";
            this.nudBackY.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.nudBackY.Size = new System.Drawing.Size(51, 20);
            this.nudBackY.TabIndex = 39;
            this.nudBackY.ValueChanged += new System.EventHandler(this.nudBackY_ValueChanged);
            // 
            // nudBackX
            // 
            this.nudBackX.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudBackX.Location = new System.Drawing.Point(99, 76);
            this.nudBackX.Name = "nudBackX";
            this.nudBackX.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.nudBackX.Size = new System.Drawing.Size(51, 20);
            this.nudBackX.TabIndex = 38;
            this.nudBackX.ValueChanged += new System.EventHandler(this.nudBackX_ValueChanged);
            // 
            // lbBackYPts
            // 
            this.lbBackYPts.Location = new System.Drawing.Point(296, 79);
            this.lbBackYPts.Name = "lbBackYPts";
            this.lbBackYPts.Size = new System.Drawing.Size(24, 14);
            this.lbBackYPts.TabIndex = 37;
            this.lbBackYPts.Text = "像素";
            // 
            // lbBackY
            // 
            this.lbBackY.Location = new System.Drawing.Point(209, 79);
            this.lbBackY.Name = "lbBackY";
            this.lbBackY.Size = new System.Drawing.Size(12, 14);
            this.lbBackY.TabIndex = 36;
            this.lbBackY.Text = "Y:";
            // 
            // lbBackX
            // 
            this.lbBackX.Location = new System.Drawing.Point(68, 79);
            this.lbBackX.Name = "lbBackX";
            this.lbBackX.Size = new System.Drawing.Size(11, 14);
            this.lbBackX.TabIndex = 35;
            this.lbBackX.Text = "X:";
            // 
            // lbBackGap
            // 
            this.lbBackGap.Location = new System.Drawing.Point(13, 79);
            this.lbBackGap.Name = "lbBackGap";
            this.lbBackGap.Size = new System.Drawing.Size(28, 14);
            this.lbBackGap.TabIndex = 34;
            this.lbBackGap.Text = "边距:";
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(303, 30);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(12, 14);
            this.labelControl6.TabIndex = 33;
            this.labelControl6.Text = "%";
            // 
            // nudBackRounding
            // 
            this.nudBackRounding.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudBackRounding.Location = new System.Drawing.Point(243, 26);
            this.nudBackRounding.Name = "nudBackRounding";
            this.nudBackRounding.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.nudBackRounding.Size = new System.Drawing.Size(50, 20);
            this.nudBackRounding.TabIndex = 32;
            this.nudBackRounding.ValueChanged += new System.EventHandler(this.nudBackRounding_ValueChanged);
            // 
            // lbBackRounding
            // 
            this.lbBackRounding.Location = new System.Drawing.Point(190, 29);
            this.lbBackRounding.Name = "lbBackRounding";
            this.lbBackRounding.Size = new System.Drawing.Size(28, 14);
            this.lbBackRounding.TabIndex = 31;
            this.lbBackRounding.Text = "圆角:";
            // 
            // btBack
            // 
            this.btBack.Location = new System.Drawing.Point(79, 24);
            this.btBack.Name = "btBack";
            this.btBack.Size = new System.Drawing.Size(87, 27);
            this.btBack.TabIndex = 30;
            this.btBack.Text = "设置";
            this.btBack.Click += new System.EventHandler(this.btBack_Click);
            // 
            // lbBackSymbol
            // 
            this.lbBackSymbol.Location = new System.Drawing.Point(13, 29);
            this.lbBackSymbol.Name = "lbBackSymbol";
            this.lbBackSymbol.Size = new System.Drawing.Size(24, 14);
            this.lbBackSymbol.TabIndex = 29;
            this.lbBackSymbol.Text = "符号";
            // 
            // lbBackXPts
            // 
            this.lbBackXPts.AutoSize = true;
            this.lbBackXPts.Location = new System.Drawing.Point(150, 79);
            this.lbBackXPts.Name = "lbBackXPts";
            this.lbBackXPts.Size = new System.Drawing.Size(31, 14);
            this.lbBackXPts.TabIndex = 28;
            this.lbBackXPts.Text = "像素";
            // 
            // gbBorder
            // 
            this.gbBorder.Controls.Add(this.nudBorderY);
            this.gbBorder.Controls.Add(this.nudBorderX);
            this.gbBorder.Controls.Add(this.lbBorderYPts);
            this.gbBorder.Controls.Add(this.lbBorderY);
            this.gbBorder.Controls.Add(this.lbBorderX);
            this.gbBorder.Controls.Add(this.lbBorderGap);
            this.gbBorder.Controls.Add(this.labelControl1);
            this.gbBorder.Controls.Add(this.nudBorderRounding);
            this.gbBorder.Controls.Add(this.lbBorderRounding);
            this.gbBorder.Controls.Add(this.btBorder);
            this.gbBorder.Controls.Add(this.lbBorderSymbol);
            this.gbBorder.Controls.Add(this.lbBorderXPts);
            this.gbBorder.Location = new System.Drawing.Point(17, 14);
            this.gbBorder.Name = "gbBorder";
            this.gbBorder.Size = new System.Drawing.Size(343, 129);
            this.gbBorder.TabIndex = 32;
            this.gbBorder.TabStop = false;
            this.gbBorder.Text = "边框";
            // 
            // nudBorderY
            // 
            this.nudBorderY.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudBorderY.Location = new System.Drawing.Point(241, 69);
            this.nudBorderY.Name = "nudBorderY";
            this.nudBorderY.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.nudBorderY.Size = new System.Drawing.Size(51, 20);
            this.nudBorderY.TabIndex = 26;
            this.nudBorderY.ValueChanged += new System.EventHandler(this.nudBorderY_ValueChanged);
            // 
            // nudBorderX
            // 
            this.nudBorderX.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudBorderX.Location = new System.Drawing.Point(99, 69);
            this.nudBorderX.Name = "nudBorderX";
            this.nudBorderX.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.nudBorderX.Size = new System.Drawing.Size(51, 20);
            this.nudBorderX.TabIndex = 25;
            this.nudBorderX.ValueChanged += new System.EventHandler(this.nudBorderX_ValueChanged);
            // 
            // lbBorderYPts
            // 
            this.lbBorderYPts.Location = new System.Drawing.Point(296, 72);
            this.lbBorderYPts.Name = "lbBorderYPts";
            this.lbBorderYPts.Size = new System.Drawing.Size(24, 14);
            this.lbBorderYPts.TabIndex = 24;
            this.lbBorderYPts.Text = "像素";
            // 
            // lbBorderY
            // 
            this.lbBorderY.Location = new System.Drawing.Point(209, 72);
            this.lbBorderY.Name = "lbBorderY";
            this.lbBorderY.Size = new System.Drawing.Size(12, 14);
            this.lbBorderY.TabIndex = 23;
            this.lbBorderY.Text = "Y:";
            // 
            // lbBorderX
            // 
            this.lbBorderX.Location = new System.Drawing.Point(68, 72);
            this.lbBorderX.Name = "lbBorderX";
            this.lbBorderX.Size = new System.Drawing.Size(11, 14);
            this.lbBorderX.TabIndex = 22;
            this.lbBorderX.Text = "X:";
            // 
            // lbBorderGap
            // 
            this.lbBorderGap.Location = new System.Drawing.Point(13, 72);
            this.lbBorderGap.Name = "lbBorderGap";
            this.lbBorderGap.Size = new System.Drawing.Size(28, 14);
            this.lbBorderGap.TabIndex = 21;
            this.lbBorderGap.Text = "边距:";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(303, 23);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(12, 14);
            this.labelControl1.TabIndex = 20;
            this.labelControl1.Text = "%";
            // 
            // nudBorderRounding
            // 
            this.nudBorderRounding.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudBorderRounding.Location = new System.Drawing.Point(243, 19);
            this.nudBorderRounding.Name = "nudBorderRounding";
            this.nudBorderRounding.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.nudBorderRounding.Size = new System.Drawing.Size(50, 20);
            this.nudBorderRounding.TabIndex = 19;
            this.nudBorderRounding.ValueChanged += new System.EventHandler(this.nudBorderRounding_ValueChanged);
            // 
            // lbBorderRounding
            // 
            this.lbBorderRounding.Location = new System.Drawing.Point(190, 22);
            this.lbBorderRounding.Name = "lbBorderRounding";
            this.lbBorderRounding.Size = new System.Drawing.Size(28, 14);
            this.lbBorderRounding.TabIndex = 18;
            this.lbBorderRounding.Text = "圆角:";
            // 
            // btBorder
            // 
            this.btBorder.Location = new System.Drawing.Point(79, 17);
            this.btBorder.Name = "btBorder";
            this.btBorder.Size = new System.Drawing.Size(87, 27);
            this.btBorder.TabIndex = 17;
            this.btBorder.Text = "设置";
            this.btBorder.Click += new System.EventHandler(this.btBorder_Click);
            // 
            // lbBorderSymbol
            // 
            this.lbBorderSymbol.Location = new System.Drawing.Point(13, 22);
            this.lbBorderSymbol.Name = "lbBorderSymbol";
            this.lbBorderSymbol.Size = new System.Drawing.Size(24, 14);
            this.lbBorderSymbol.TabIndex = 16;
            this.lbBorderSymbol.Text = "符号";
            // 
            // lbBorderXPts
            // 
            this.lbBorderXPts.AutoSize = true;
            this.lbBorderXPts.Location = new System.Drawing.Point(150, 72);
            this.lbBorderXPts.Name = "lbBorderXPts";
            this.lbBorderXPts.Size = new System.Drawing.Size(31, 14);
            this.lbBorderXPts.TabIndex = 7;
            this.lbBorderXPts.Text = "像素";
            // 
            // pbBorder
            // 
            this.pbBorder.Location = new System.Drawing.Point(374, 23);
            this.pbBorder.Name = "pbBorder";
            this.pbBorder.Size = new System.Drawing.Size(176, 119);
            this.pbBorder.TabIndex = 41;
            // 
            // pbBack
            // 
            this.pbBack.Location = new System.Drawing.Point(374, 167);
            this.pbBack.Name = "pbBack";
            this.pbBack.Size = new System.Drawing.Size(176, 119);
            this.pbBack.TabIndex = 42;
            // 
            // pbShadow
            // 
            this.pbShadow.Location = new System.Drawing.Point(374, 309);
            this.pbShadow.Name = "pbShadow";
            this.pbShadow.Size = new System.Drawing.Size(176, 119);
            this.pbShadow.TabIndex = 43;
            // 
            // btOK
            // 
            this.btOK.Location = new System.Drawing.Point(178, 440);
            this.btOK.Name = "btOK";
            this.btOK.Size = new System.Drawing.Size(87, 27);
            this.btOK.TabIndex = 45;
            this.btOK.Text = "创建";
            this.btOK.Click += new System.EventHandler(this.btOK_Click);
            // 
            // btCancel
            // 
            this.btCancel.Location = new System.Drawing.Point(302, 440);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(87, 27);
            this.btCancel.TabIndex = 46;
            this.btCancel.Text = "关闭";
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // DevFrame
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.Appearance.BackColor2 = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(568, 482);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btOK);
            this.Controls.Add(this.pbShadow);
            this.Controls.Add(this.pbBack);
            this.Controls.Add(this.pbBorder);
            this.Controls.Add(this.gbDropShadow);
            this.Controls.Add(this.gbBack);
            this.Controls.Add(this.gbBorder);
            this.LookAndFeel.SkinName = "Blue";
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DevFrame";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "地图图框";
            this.Load += new System.EventHandler(this.Frame_Load);
            this.gbDropShadow.ResumeLayout(false);
            this.gbDropShadow.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudShadowY.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudShadowX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudShadowRounding.Properties)).EndInit();
            this.gbBack.ResumeLayout(false);
            this.gbBack.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudBackY.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBackX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBackRounding.Properties)).EndInit();
            this.gbBorder.ResumeLayout(false);
            this.gbBorder.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudBorderY.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBorderX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBorderRounding.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBorder.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBack.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbShadow.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        private void nudBackRounding_ValueChanged(object sender, EventArgs e)
        {
            if (!this.init && (this.background != null))
            {
                IFrameDecoration background = (IFrameDecoration) this.background;
                background.CornerRounding = short.Parse(this.nudBackRounding.Value.ToString());
                Bitmap bitmap = BitmapManager.GetSymbolBitMap(this.background, this.pbBack.Width, this.pbBack.Height);
                bitmap.MakeTransparent(bitmap.GetPixel(1, 1));
                this.pbBack.Image = bitmap;
            }
        }

        private void nudBackX_ValueChanged(object sender, EventArgs e)
        {
            if (!this.init && (this.background != null))
            {
                IFrameDecoration background = (IFrameDecoration) this.background;
                background.HorizontalSpacing = double.Parse(this.nudBackX.Value.ToString());
                Bitmap bitmap = BitmapManager.GetSymbolBitMap(this.background, this.pbBack.Width, this.pbBack.Height);
                bitmap.MakeTransparent(bitmap.GetPixel(1, 1));
                this.pbBack.Image = bitmap;
            }
        }

        private void nudBackY_ValueChanged(object sender, EventArgs e)
        {
            if (!this.init && (this.background != null))
            {
                IFrameDecoration background = (IFrameDecoration) this.background;
                background.VerticalSpacing = double.Parse(this.nudBackY.Value.ToString());
                Bitmap bitmap = BitmapManager.GetSymbolBitMap(this.background, this.pbBack.Width, this.pbBack.Height);
                bitmap.MakeTransparent(bitmap.GetPixel(1, 1));
                this.pbBack.Image = bitmap;
            }
        }

        private void nudBorderRounding_ValueChanged(object sender, EventArgs e)
        {
            if (!this.init && (this.border != null))
            {
                IFrameDecoration border = (IFrameDecoration) this.border;
                border.CornerRounding = short.Parse(this.nudBorderRounding.Value.ToString());
                Bitmap bitmap = BitmapManager.GetSymbolBitMap(this.border, this.pbBorder.Width, this.pbBorder.Height);
                this.pbBorder.Image = bitmap;
            }
        }

        private void nudBorderX_ValueChanged(object sender, EventArgs e)
        {
            if (!this.init && (this.border != null))
            {
                IFrameDecoration border = (IFrameDecoration) this.border;
                border.HorizontalSpacing = double.Parse(this.nudBorderX.Value.ToString());
                Bitmap bitmap = BitmapManager.GetSymbolBitMap(this.border, this.pbBorder.Width, this.pbBorder.Height);
                this.pbBorder.Image = bitmap;
            }
        }

        private void nudBorderY_ValueChanged(object sender, EventArgs e)
        {
            if (!this.init && (this.border != null))
            {
                IFrameDecoration border = (IFrameDecoration) this.border;
                border.VerticalSpacing = double.Parse(this.nudBorderY.Value.ToString());
                Bitmap bitmap = BitmapManager.GetSymbolBitMap(this.border, this.pbBorder.Width, this.pbBorder.Height);
                this.pbBorder.Image = bitmap;
            }
        }

        private void nudShadowRounding_ValueChanged(object sender, EventArgs e)
        {
            if (!this.init && (this.shadow != null))
            {
                IFrameDecoration shadow = (IFrameDecoration) this.shadow;
                shadow.CornerRounding = short.Parse(this.nudShadowRounding.Value.ToString());
                Bitmap bitmap = BitmapManager.GetSymbolBitMap(this.shadow, this.pbShadow.Width, this.pbShadow.Height);
                bitmap.MakeTransparent(bitmap.GetPixel(1, 1));
                this.pbShadow.Image = bitmap;
            }
        }

        private void nudShadowX_ValueChanged(object sender, EventArgs e)
        {
            if (!this.init && (this.shadow != null))
            {
                IFrameDecoration shadow = (IFrameDecoration) this.shadow;
                shadow.CornerRounding = short.Parse(this.nudShadowRounding.Value.ToString());
                Bitmap bitmap = BitmapManager.GetSymbolBitMap(this.shadow, this.pbShadow.Width, this.pbShadow.Height);
                bitmap.MakeTransparent(bitmap.GetPixel(1, 1));
                this.pbShadow.Image = bitmap;
            }
        }

        private void nudShadowY_ValueChanged(object sender, EventArgs e)
        {
            if (!this.init && (this.shadow != null))
            {
                IFrameDecoration shadow = (IFrameDecoration) this.shadow;
                shadow.VerticalSpacing = short.Parse(this.nudShadowY.Value.ToString());
                Bitmap bitmap = BitmapManager.GetSymbolBitMap(this.shadow, this.pbShadow.Width, this.pbShadow.Height);
                bitmap.MakeTransparent(bitmap.GetPixel(1, 1));
                this.pbShadow.Image = bitmap;
            }
        }

        private void preView()
        {
            IFrameProperties properties = (IFrameProperties) this._mapFrame;
            properties.Background = this.background;
            properties.Border = this.border;
            properties.Shadow = this.shadow;
            this._activeView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, this._activeView.Extent);
            this._activeView.Refresh();
        }
    }
}

