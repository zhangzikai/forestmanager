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
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Utilities;

    public class ScaleText : FormBase3
    {
        private IActiveView _activeView;
        private IMapSurroundFrame _mapSurroundFrame;
        private IMapSurroundFrame _preMapsurroundFrame;
        private IScaleText2 _scaleText;
        private ISymbolBackground background;
        private Dictionary<IStyleGalleryItem, Bitmap> bitmapItem;
        private Dictionary<string, Bitmap> bitMaptext = new Dictionary<string, Bitmap>();
        private ISymbolBorder border;
        private SimpleButton btBack;
        private SimpleButton btBorder;
        private SimpleButton btCancel;
        private SimpleButton btNumberFormat;
        private SimpleButton btOK;
        private SimpleButton btShadow;
        private SimpleButton btTextFormat;
        private ComboBoxEdit cbeMapUnit;
        private ComboBoxEdit cbePageUnit;
        private IContainer components;
        private GroupBox gbBack;
        private GroupBox gbBorder;
        private GroupBox gbDropShadow;
        private GroupBox gbFormat;
        private GroupBox gbPreview;
        private GroupBox gbStyle;
        private ImageListBoxControl ilbcScale;
        private ImageList imageList;
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
        private LabelControl lbDistanceFormat;
        private LabelControl lbMapUnit;
        private LabelControl lbMapUnitLabel;
        private LabelControl lbPageUnit;
        private LabelControl lbPageUnitLabel;
        private LabelControl lbPreview;
        private LabelControl lbSeperator;
        private LabelControl lbShadowGap;
        private LabelControl lbShadowRounding;
        private LabelControl lbShadowSymbol;
        private LabelControl lbShadowX;
        private LabelControl lbShadowXPts;
        private LabelControl lbShadowY;
        private LabelControl lbShadowYPts;
        private LabelControl lbTextFormat;
        private IPoint m_Point;
        private const string mClassName = "Cartography.Element.ScaleText";
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
        private PictureEdit pePreview;
        private RadioGroup rgStyle;
        private ISymbolShadow shadow;
        private XtraTabControl tc;
        private TextEdit teMapUnitLabel;
        private TextEdit tePageUnitLabel;
        private TextEdit teSperator;
        private XtraTabPage xtraTabPage1;
        private XtraTabPage xtraTabPage2;
        private XtraTabPage xtraTabPage3;

        public ScaleText()
        {
            this.InitializeComponent();
            this.bitmapItem = BitmapManager.GetBitMapText("Scale Texts", 0xe1, 30);
            foreach (KeyValuePair<IStyleGalleryItem, Bitmap> pair in this.bitmapItem)
            {
                this.imageList.Images.Add(pair.Key.Name, pair.Value);
            }
        }

        private void btBack_Click(object sender, EventArgs e)
        {
            try
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
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "Cartography.Element.ScaleText", "btBack_Click", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void btBorder_Click(object sender, EventArgs e)
        {
            try
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
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "Cartography.Element.ScaleText", "btBorder_Click", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        private void btNumberFormat_Click(object sender, EventArgs e)
        {
            DevDigtal digtal = new DevDigtal(this._scaleText.NumberFormat);
            digtal.ShowDialog();
            this._scaleText.NumberFormat = digtal.Formmat;
            digtal.Dispose();
            digtal = null;
            Bitmap bitmap = BitmapManager.GetSymbolBitMap(this._scaleText, this.pePreview.Width, this.pePreview.Height);
            this.pePreview.Image = bitmap;
        }

        private void btOK_Click(object sender, EventArgs e)
        {
            this.Create();
            base.Close();
        }

        private void btShadow_Click(object sender, EventArgs e)
        {
            try
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
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "Cartography.Element.ScaleText", "btShadow_Click", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void btTextFormat_Click(object sender, EventArgs e)
        {
            frmTextSymbol symbol = new frmTextSymbol();
            ISymbol symbol2 = (ISymbol) this._scaleText.Symbol;
            symbol.SymbolSource = symbol2;
            if (symbol.ShowDialog() == DialogResult.OK)
            {
                ISymbol symbolSelected = (ISymbol) symbol.SymbolSelected;
                this._scaleText.Symbol = (ITextSymbol) symbolSelected;
                symbol.Dispose();
                Bitmap bitmap = BitmapManager.GetSymbolBitMap(this._scaleText, this.pePreview.Width, this.pePreview.Height);
                this.pePreview.Image = bitmap;
            }
        }

        private void cbeMapUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this.init)
            {
                esriUnits unitFromChineseUnitESRI = UnitService.GetUnitFromChineseUnitESRI(this.cbeMapUnit.Text);
                this._scaleText.MapUnits = unitFromChineseUnitESRI;
                Bitmap bitmap = BitmapManager.GetSymbolBitMap(this._scaleText, this.pePreview.Width, this.pePreview.Height);
                this.pePreview.Image = bitmap;
            }
        }

        private void cbePageUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this.init)
            {
                esriUnits unitFromChineseUnitESRI = UnitService.GetUnitFromChineseUnitESRI(this.cbePageUnit.Text);
                this._scaleText.PageUnits = unitFromChineseUnitESRI;
                Bitmap bitmap = BitmapManager.GetSymbolBitMap(this._scaleText, this.pePreview.Width, this.pePreview.Height);
                this.pePreview.Image = bitmap;
            }
        }

        private void Create()
        {
            try
            {
                ElementService service = new ElementService();
                IPageLayout layout = this._activeView as IPageLayout;
                this._scaleText.Refresh();
                IFrameProperties properties = null;
                object data = null;
                if (this._preMapsurroundFrame == null)
                {
                    IEnvelope pEnvelope = null;
                    if (this.m_Point == null)
                    {
                        double num;
                        double num2;
                        layout.Page.QuerySize(out num, out num2);
                        IPoint point = new PointClass();
                        point.X = num / 2.0;
                        point.Y = 1.0;
                        pEnvelope = point.Envelope;
                    }
                    else
                    {
                        pEnvelope = new EnvelopeClass();
                        pEnvelope.PutCoords(this.m_Point.X, this.m_Point.Y, this.m_Point.X, this.m_Point.Y);
                    }
                    this._mapSurroundFrame = service.CreateMapsurround((IPageLayout) this._activeView, this._activeView.FocusMap, this._scaleText, pEnvelope);
                    properties = (IFrameProperties) this._mapSurroundFrame;
                    data = this._mapSurroundFrame;
                }
                else
                {
                    this._preMapsurroundFrame.MapSurround = null;
                    this._preMapsurroundFrame.MapSurround = this._scaleText;
                    properties = (IFrameProperties) this._preMapsurroundFrame;
                    data = this._preMapsurroundFrame;
                }
                properties.Background = this.background;
                properties.Border = this.border;
                properties.Shadow = this.shadow;
                this._activeView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, data, this._activeView.Extent);
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "Cartography.Element.ScaleText", "Create", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
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

        private IStyleGalleryItem GetItem(string pItemName)
        {
            foreach (KeyValuePair<IStyleGalleryItem, Bitmap> pair in this.bitmapItem)
            {
                if (pair.Key.Name == pItemName)
                {
                    return pair.Key;
                }
            }
            return null;
        }

        private void ilbcScale_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this.init && (this.ilbcScale.Items.Count > 0))
            {
                INumberFormat numberFormat = this._scaleText.NumberFormat;
                ITextSymbol symbol = this._scaleText.Symbol;
                esriScaleTextStyleEnum style = this._scaleText.Style;
                string pItemName = this.ilbcScale.GetItemValue(this.ilbcScale.SelectedIndex).ToString();
                this._scaleText = (IScaleText2) this.GetItem(pItemName).Item;
                this._scaleText.Name = pItemName;
                this._scaleText.Map = this._activeView.FocusMap;
                this._scaleText.NumberFormat = numberFormat;
                this._scaleText.Symbol = symbol;
                if (this.ilbcScale.SelectedIndex == 0)
                {
                    this._scaleText.Style = esriScaleTextStyleEnum.esriScaleTextAbsolute;
                    this.rgStyle.SelectedIndex = 0;
                    this.cbePageUnit.Enabled = false;
                    this.tePageUnitLabel.Enabled = false;
                    this.cbeMapUnit.Enabled = false;
                    this.teMapUnitLabel.Enabled = false;
                }
                else
                {
                    this._scaleText.Style = esriScaleTextStyleEnum.esriScaleTextRelative;
                    this.rgStyle.SelectedIndex = 1;
                    this.cbePageUnit.Enabled = true;
                    this.tePageUnitLabel.Enabled = true;
                    this.cbeMapUnit.Enabled = true;
                    this.teMapUnitLabel.Enabled = true;
                }
                this.teSperator.Text = this._scaleText.Separator;
                this.cbePageUnit.Text = UnitService.GetUnitFromESRIUnitChinese(this._scaleText.PageUnits);
                this.tePageUnitLabel.Text = this.cbePageUnit.Text;
                this.cbeMapUnit.Text = UnitService.GetUnitFromESRIUnitChinese(this._scaleText.MapUnits);
                this.teMapUnitLabel.Text = this.cbeMapUnit.Text;
                Bitmap bitmap = BitmapManager.GetSymbolBitMap(this._scaleText, this.pePreview.Width, this.pePreview.Height);
                this.pePreview.Image = bitmap;
            }
        }

        private void InitialControl()
        {
            try
            {
                this.init = true;
                IFrameProperties properties = null;
                if (this._preMapsurroundFrame != null)
                {
                    this.btOK.Text = "更新";
                    properties = (IFrameProperties) this._preMapsurroundFrame;
                }
                for (int i = 0; i < this.imageList.Images.Count; i++)
                {
                    string str = this.imageList.Images.Keys[i];
                    this.ilbcScale.Items.Add(str, i);
                    if (this._scaleText.Name == str)
                    {
                        this.ilbcScale.SelectedItem = this.ilbcScale.Items[i];
                    }
                }
                switch (this._scaleText.Style)
                {
                    case esriScaleTextStyleEnum.esriScaleTextAbsolute:
                        this.rgStyle.SelectedIndex = 0;
                        break;

                    case esriScaleTextStyleEnum.esriScaleTextRelative:
                        this.rgStyle.SelectedIndex = 1;
                        break;
                }
                if (this.cbePageUnit.Properties.Items.Contains(this._scaleText.PageUnitLabel))
                {
                    this.cbePageUnit.Text = UnitService.GetUnitFromESRIUnitChinese(this._scaleText.PageUnits);
                    this.tePageUnitLabel.Text = this._scaleText.PageUnitLabel;
                }
                else
                {
                    this._scaleText.PageUnits = esriUnits.esriCentimeters;
                    this._scaleText.PageUnitLabel = "厘米";
                    this.cbePageUnit.Text = "厘米";
                    this.tePageUnitLabel.Text = "厘米";
                }
                this.cbeMapUnit.Text = UnitService.GetUnitFromESRIUnitChinese(this._scaleText.MapUnits);
                this.teMapUnitLabel.Text = this._scaleText.MapUnitLabel;
                this.teSperator.Text = this._scaleText.Separator;
                Bitmap bitmap = BitmapManager.GetSymbolBitMap(this._scaleText, this.pePreview.Width, this.pePreview.Height);
                this.pePreview.Image = bitmap;
                if (this._preMapsurroundFrame != null)
                {
                    ISymbolBorder pSourceObj = (ISymbolBorder) properties.Border;
                    ISymbolBackground background = (ISymbolBackground) properties.Background;
                    ISymbolShadow shadow = (ISymbolShadow) properties.Shadow;
                    IFrameDecoration decoration = null;
                    if (pSourceObj != null)
                    {
                        this.border = new SymbolBorderClass();
                        CloneService.Clone(pSourceObj, this.border);
                        decoration = (IFrameDecoration) pSourceObj;
                        bitmap = BitmapManager.GetSymbolBitMap(pSourceObj, this.pbBorder.Width, this.pbBorder.Height);
                        this.pbBorder.Image = bitmap;
                        this.nudBorderRounding.Value = decimal.Parse(this.border.CornerRounding.ToString());
                        this.nudBackX.Value = decimal.Parse(decoration.HorizontalSpacing.ToString());
                        this.nudBackY.Value = decimal.Parse(decoration.VerticalSpacing.ToString());
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
                }
                this.init = false;
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "Cartography.Element.ScaleText", "InitialControl", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void InitializeComponent()
        {
            this.tc = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.ilbcScale = new DevExpress.XtraEditors.ImageListBoxControl();
            this.imageList = new System.Windows.Forms.ImageList();
            this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
            this.lbPreview = new DevExpress.XtraEditors.LabelControl();
            this.gbFormat = new System.Windows.Forms.GroupBox();
            this.teMapUnitLabel = new DevExpress.XtraEditors.TextEdit();
            this.tePageUnitLabel = new DevExpress.XtraEditors.TextEdit();
            this.lbMapUnitLabel = new DevExpress.XtraEditors.LabelControl();
            this.cbeMapUnit = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lbPageUnitLabel = new DevExpress.XtraEditors.LabelControl();
            this.lbMapUnit = new DevExpress.XtraEditors.LabelControl();
            this.cbePageUnit = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lbPageUnit = new DevExpress.XtraEditors.LabelControl();
            this.teSperator = new DevExpress.XtraEditors.TextEdit();
            this.lbSeperator = new DevExpress.XtraEditors.LabelControl();
            this.btTextFormat = new DevExpress.XtraEditors.SimpleButton();
            this.lbTextFormat = new DevExpress.XtraEditors.LabelControl();
            this.btNumberFormat = new DevExpress.XtraEditors.SimpleButton();
            this.lbDistanceFormat = new DevExpress.XtraEditors.LabelControl();
            this.gbStyle = new System.Windows.Forms.GroupBox();
            this.rgStyle = new DevExpress.XtraEditors.RadioGroup();
            this.gbPreview = new System.Windows.Forms.GroupBox();
            this.pePreview = new DevExpress.XtraEditors.PictureEdit();
            this.xtraTabPage3 = new DevExpress.XtraTab.XtraTabPage();
            this.pbShadow = new DevExpress.XtraEditors.PictureEdit();
            this.pbBack = new DevExpress.XtraEditors.PictureEdit();
            this.pbBorder = new DevExpress.XtraEditors.PictureEdit();
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
            this.btOK = new DevExpress.XtraEditors.SimpleButton();
            this.btCancel = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.tc)).BeginInit();
            this.tc.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ilbcScale)).BeginInit();
            this.xtraTabPage2.SuspendLayout();
            this.gbFormat.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.teMapUnitLabel.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tePageUnitLabel.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbeMapUnit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbePageUnit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teSperator.Properties)).BeginInit();
            this.gbStyle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rgStyle.Properties)).BeginInit();
            this.gbPreview.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pePreview.Properties)).BeginInit();
            this.xtraTabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbShadow.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBack.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBorder.Properties)).BeginInit();
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
            this.SuspendLayout();
            // 
            // tc
            // 
            this.tc.Dock = System.Windows.Forms.DockStyle.Top;
            this.tc.Location = new System.Drawing.Point(0, 0);
            this.tc.Name = "tc";
            this.tc.SelectedTabPage = this.xtraTabPage1;
            this.tc.Size = new System.Drawing.Size(610, 463);
            this.tc.TabIndex = 0;
            this.tc.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1,
            this.xtraTabPage2,
            this.xtraTabPage3});
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Controls.Add(this.ilbcScale);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(604, 434);
            this.xtraTabPage1.Text = "符号";
            // 
            // ilbcScale
            // 
            this.ilbcScale.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ilbcScale.ImageList = this.imageList;
            this.ilbcScale.Location = new System.Drawing.Point(0, 0);
            this.ilbcScale.Name = "ilbcScale";
            this.ilbcScale.Size = new System.Drawing.Size(604, 434);
            this.ilbcScale.TabIndex = 1;
            this.ilbcScale.SelectedIndexChanged += new System.EventHandler(this.ilbcScale_SelectedIndexChanged);
            // 
            // imageList
            // 
            this.imageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList.ImageSize = new System.Drawing.Size(200, 30);
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // xtraTabPage2
            // 
            this.xtraTabPage2.Controls.Add(this.lbPreview);
            this.xtraTabPage2.Controls.Add(this.gbFormat);
            this.xtraTabPage2.Controls.Add(this.gbStyle);
            this.xtraTabPage2.Controls.Add(this.gbPreview);
            this.xtraTabPage2.Name = "xtraTabPage2";
            this.xtraTabPage2.Size = new System.Drawing.Size(604, 434);
            this.xtraTabPage2.Text = "比例文本";
            // 
            // lbPreview
            // 
            this.lbPreview.Location = new System.Drawing.Point(78, -15);
            this.lbPreview.Name = "lbPreview";
            this.lbPreview.Size = new System.Drawing.Size(0, 14);
            this.lbPreview.TabIndex = 0;
            // 
            // gbFormat
            // 
            this.gbFormat.Controls.Add(this.teMapUnitLabel);
            this.gbFormat.Controls.Add(this.tePageUnitLabel);
            this.gbFormat.Controls.Add(this.lbMapUnitLabel);
            this.gbFormat.Controls.Add(this.cbeMapUnit);
            this.gbFormat.Controls.Add(this.lbPageUnitLabel);
            this.gbFormat.Controls.Add(this.lbMapUnit);
            this.gbFormat.Controls.Add(this.cbePageUnit);
            this.gbFormat.Controls.Add(this.lbPageUnit);
            this.gbFormat.Controls.Add(this.teSperator);
            this.gbFormat.Controls.Add(this.lbSeperator);
            this.gbFormat.Controls.Add(this.btTextFormat);
            this.gbFormat.Controls.Add(this.lbTextFormat);
            this.gbFormat.Controls.Add(this.btNumberFormat);
            this.gbFormat.Controls.Add(this.lbDistanceFormat);
            this.gbFormat.Location = new System.Drawing.Point(10, 164);
            this.gbFormat.Name = "gbFormat";
            this.gbFormat.Size = new System.Drawing.Size(314, 259);
            this.gbFormat.TabIndex = 10;
            this.gbFormat.TabStop = false;
            this.gbFormat.Text = "格式";
            // 
            // teMapUnitLabel
            // 
            this.teMapUnitLabel.Location = new System.Drawing.Point(161, 104);
            this.teMapUnitLabel.Name = "teMapUnitLabel";
            this.teMapUnitLabel.Size = new System.Drawing.Size(117, 20);
            this.teMapUnitLabel.TabIndex = 22;
            this.teMapUnitLabel.TextChanged += new System.EventHandler(this.teMapUnitLabel_TextChanged);
            // 
            // tePageUnitLabel
            // 
            this.tePageUnitLabel.Location = new System.Drawing.Point(161, 48);
            this.tePageUnitLabel.Name = "tePageUnitLabel";
            this.tePageUnitLabel.Size = new System.Drawing.Size(117, 20);
            this.tePageUnitLabel.TabIndex = 21;
            this.tePageUnitLabel.TextChanged += new System.EventHandler(this.tePageUnitLabel_TextChanged);
            // 
            // lbMapUnitLabel
            // 
            this.lbMapUnitLabel.Location = new System.Drawing.Point(161, 80);
            this.lbMapUnitLabel.Name = "lbMapUnitLabel";
            this.lbMapUnitLabel.Size = new System.Drawing.Size(28, 14);
            this.lbMapUnitLabel.TabIndex = 20;
            this.lbMapUnitLabel.Text = "标签:";
            // 
            // cbeMapUnit
            // 
            this.cbeMapUnit.Location = new System.Drawing.Point(9, 104);
            this.cbeMapUnit.Name = "cbeMapUnit";
            this.cbeMapUnit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbeMapUnit.Properties.Items.AddRange(new object[] {
            "厘米",
            "十进制度数",
            "分米",
            "英尺",
            "英寸",
            "千米",
            "米",
            "英里",
            "毫米",
            "海里",
            "点",
            "内部使用单位",
            "未知",
            "码"});
            this.cbeMapUnit.Size = new System.Drawing.Size(117, 20);
            this.cbeMapUnit.TabIndex = 19;
            this.cbeMapUnit.SelectedIndexChanged += new System.EventHandler(this.cbeMapUnit_SelectedIndexChanged);
            // 
            // lbPageUnitLabel
            // 
            this.lbPageUnitLabel.Location = new System.Drawing.Point(161, 26);
            this.lbPageUnitLabel.Name = "lbPageUnitLabel";
            this.lbPageUnitLabel.Size = new System.Drawing.Size(28, 14);
            this.lbPageUnitLabel.TabIndex = 17;
            this.lbPageUnitLabel.Text = "标签:";
            // 
            // lbMapUnit
            // 
            this.lbMapUnit.Location = new System.Drawing.Point(8, 79);
            this.lbMapUnit.Name = "lbMapUnit";
            this.lbMapUnit.Size = new System.Drawing.Size(52, 14);
            this.lbMapUnit.TabIndex = 16;
            this.lbMapUnit.Text = "地图单位:";
            // 
            // cbePageUnit
            // 
            this.cbePageUnit.Location = new System.Drawing.Point(9, 48);
            this.cbePageUnit.Name = "cbePageUnit";
            this.cbePageUnit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbePageUnit.Properties.Items.AddRange(new object[] {
            "厘米",
            "英寸",
            "点"});
            this.cbePageUnit.Size = new System.Drawing.Size(117, 20);
            this.cbePageUnit.TabIndex = 15;
            this.cbePageUnit.SelectedIndexChanged += new System.EventHandler(this.cbePageUnit_SelectedIndexChanged);
            // 
            // lbPageUnit
            // 
            this.lbPageUnit.Location = new System.Drawing.Point(8, 26);
            this.lbPageUnit.Name = "lbPageUnit";
            this.lbPageUnit.Size = new System.Drawing.Size(52, 14);
            this.lbPageUnit.TabIndex = 14;
            this.lbPageUnit.Text = "页面单位:";
            // 
            // teSperator
            // 
            this.teSperator.Location = new System.Drawing.Point(80, 229);
            this.teSperator.Name = "teSperator";
            this.teSperator.Size = new System.Drawing.Size(187, 20);
            this.teSperator.TabIndex = 13;
            this.teSperator.TextChanged += new System.EventHandler(this.teSperator_TextChanged);
            // 
            // lbSeperator
            // 
            this.lbSeperator.Location = new System.Drawing.Point(27, 232);
            this.lbSeperator.Name = "lbSeperator";
            this.lbSeperator.Size = new System.Drawing.Size(40, 14);
            this.lbSeperator.TabIndex = 12;
            this.lbSeperator.Text = "分隔符:";
            // 
            // btTextFormat
            // 
            this.btTextFormat.Location = new System.Drawing.Point(80, 187);
            this.btTextFormat.Name = "btTextFormat";
            this.btTextFormat.Size = new System.Drawing.Size(87, 27);
            this.btTextFormat.TabIndex = 11;
            this.btTextFormat.Text = "文本...";
            this.btTextFormat.Click += new System.EventHandler(this.btTextFormat_Click);
            // 
            // lbTextFormat
            // 
            this.lbTextFormat.Location = new System.Drawing.Point(13, 191);
            this.lbTextFormat.Name = "lbTextFormat";
            this.lbTextFormat.Size = new System.Drawing.Size(52, 14);
            this.lbTextFormat.TabIndex = 10;
            this.lbTextFormat.Text = "文本格式:";
            // 
            // btNumberFormat
            // 
            this.btNumberFormat.Location = new System.Drawing.Point(80, 149);
            this.btNumberFormat.Name = "btNumberFormat";
            this.btNumberFormat.Size = new System.Drawing.Size(87, 27);
            this.btNumberFormat.TabIndex = 9;
            this.btNumberFormat.Text = "数字...";
            this.btNumberFormat.Click += new System.EventHandler(this.btNumberFormat_Click);
            // 
            // lbDistanceFormat
            // 
            this.lbDistanceFormat.Location = new System.Drawing.Point(13, 154);
            this.lbDistanceFormat.Name = "lbDistanceFormat";
            this.lbDistanceFormat.Size = new System.Drawing.Size(52, 14);
            this.lbDistanceFormat.TabIndex = 8;
            this.lbDistanceFormat.Text = "距离格式:";
            // 
            // gbStyle
            // 
            this.gbStyle.Controls.Add(this.rgStyle);
            this.gbStyle.Location = new System.Drawing.Point(10, 59);
            this.gbStyle.Name = "gbStyle";
            this.gbStyle.Size = new System.Drawing.Size(314, 101);
            this.gbStyle.TabIndex = 8;
            this.gbStyle.TabStop = false;
            this.gbStyle.Text = "风格";
            // 
            // rgStyle
            // 
            this.rgStyle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rgStyle.Location = new System.Drawing.Point(3, 18);
            this.rgStyle.Name = "rgStyle";
            this.rgStyle.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.rgStyle.Properties.Appearance.Options.UseBackColor = true;
            this.rgStyle.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.rgStyle.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "绝对(如:1:24,000)"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "相对(如:1 inch equals 200 miles)")});
            this.rgStyle.Size = new System.Drawing.Size(308, 80);
            this.rgStyle.TabIndex = 0;
            this.rgStyle.SelectedIndexChanged += new System.EventHandler(this.rgStyle_SelectedIndexChanged);
            // 
            // gbPreview
            // 
            this.gbPreview.Controls.Add(this.pePreview);
            this.gbPreview.Location = new System.Drawing.Point(10, 3);
            this.gbPreview.Name = "gbPreview";
            this.gbPreview.Size = new System.Drawing.Size(314, 49);
            this.gbPreview.TabIndex = 9;
            this.gbPreview.TabStop = false;
            this.gbPreview.Text = "预览";
            // 
            // pePreview
            // 
            this.pePreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pePreview.Location = new System.Drawing.Point(3, 18);
            this.pePreview.Name = "pePreview";
            this.pePreview.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.pePreview.Properties.Appearance.Options.UseBackColor = true;
            this.pePreview.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pePreview.Properties.ReadOnly = true;
            this.pePreview.Size = new System.Drawing.Size(308, 28);
            this.pePreview.TabIndex = 0;
            // 
            // xtraTabPage3
            // 
            this.xtraTabPage3.Controls.Add(this.pbShadow);
            this.xtraTabPage3.Controls.Add(this.pbBack);
            this.xtraTabPage3.Controls.Add(this.pbBorder);
            this.xtraTabPage3.Controls.Add(this.gbDropShadow);
            this.xtraTabPage3.Controls.Add(this.gbBack);
            this.xtraTabPage3.Controls.Add(this.gbBorder);
            this.xtraTabPage3.Name = "xtraTabPage3";
            this.xtraTabPage3.Size = new System.Drawing.Size(604, 434);
            this.xtraTabPage3.Text = "框架";
            // 
            // pbShadow
            // 
            this.pbShadow.Location = new System.Drawing.Point(366, 296);
            this.pbShadow.Name = "pbShadow";
            this.pbShadow.Size = new System.Drawing.Size(176, 119);
            this.pbShadow.TabIndex = 61;
            // 
            // pbBack
            // 
            this.pbBack.Location = new System.Drawing.Point(366, 154);
            this.pbBack.Name = "pbBack";
            this.pbBack.Size = new System.Drawing.Size(176, 119);
            this.pbBack.TabIndex = 60;
            // 
            // pbBorder
            // 
            this.pbBorder.Location = new System.Drawing.Point(366, 10);
            this.pbBorder.Name = "pbBorder";
            this.pbBorder.Size = new System.Drawing.Size(176, 119);
            this.pbBorder.TabIndex = 59;
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
            this.gbDropShadow.Location = new System.Drawing.Point(9, 286);
            this.gbDropShadow.Name = "gbDropShadow";
            this.gbDropShadow.Size = new System.Drawing.Size(343, 129);
            this.gbDropShadow.TabIndex = 58;
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
            this.gbBack.Location = new System.Drawing.Point(9, 143);
            this.gbBack.Name = "gbBack";
            this.gbBack.Size = new System.Drawing.Size(343, 129);
            this.gbBack.TabIndex = 57;
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
            this.gbBorder.Location = new System.Drawing.Point(9, 1);
            this.gbBorder.Name = "gbBorder";
            this.gbBorder.Size = new System.Drawing.Size(343, 129);
            this.gbBorder.TabIndex = 56;
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
            // btOK
            // 
            this.btOK.Location = new System.Drawing.Point(213, 470);
            this.btOK.Name = "btOK";
            this.btOK.Size = new System.Drawing.Size(87, 27);
            this.btOK.TabIndex = 2;
            this.btOK.Text = "创建";
            this.btOK.Click += new System.EventHandler(this.btOK_Click);
            // 
            // btCancel
            // 
            this.btCancel.Location = new System.Drawing.Point(308, 470);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(87, 27);
            this.btCancel.TabIndex = 3;
            this.btCancel.Text = "取消";
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // ScaleText
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.Appearance.BackColor2 = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(610, 505);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btOK);
            this.Controls.Add(this.tc);
            this.LookAndFeel.SkinName = "Blue";
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ScaleText";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "比例文本";
            this.Load += new System.EventHandler(this.ScaleText_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tc)).EndInit();
            this.tc.ResumeLayout(false);
            this.xtraTabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ilbcScale)).EndInit();
            this.xtraTabPage2.ResumeLayout(false);
            this.xtraTabPage2.PerformLayout();
            this.gbFormat.ResumeLayout(false);
            this.gbFormat.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.teMapUnitLabel.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tePageUnitLabel.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbeMapUnit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbePageUnit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teSperator.Properties)).EndInit();
            this.gbStyle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rgStyle.Properties)).EndInit();
            this.gbPreview.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pePreview.Properties)).EndInit();
            this.xtraTabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbShadow.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBack.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBorder.Properties)).EndInit();
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
            this.ResumeLayout(false);

        }

        private void nudBackRounding_ValueChanged(object sender, EventArgs e)
        {
            if (this.background != null)
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
            if (this.background != null)
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
            if (this.background != null)
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
            if (this.border != null)
            {
                IFrameDecoration border = (IFrameDecoration) this.border;
                border.CornerRounding = short.Parse(this.nudBorderRounding.Value.ToString());
                Bitmap bitmap = BitmapManager.GetSymbolBitMap(this.border, this.pbBorder.Width, this.pbBorder.Height);
                this.pbBorder.Image = bitmap;
            }
        }

        private void nudBorderX_ValueChanged(object sender, EventArgs e)
        {
            if (this.border != null)
            {
                IFrameDecoration border = (IFrameDecoration) this.border;
                border.CornerRounding = short.Parse(this.nudBorderX.Value.ToString());
                Bitmap bitmap = BitmapManager.GetSymbolBitMap(this.border, this.pbBorder.Width, this.pbBorder.Height);
                this.pbBorder.Image = bitmap;
            }
        }

        private void nudBorderY_ValueChanged(object sender, EventArgs e)
        {
            if (this.border != null)
            {
                IFrameDecoration border = (IFrameDecoration) this.border;
                border.CornerRounding = short.Parse(this.nudBorderX.Value.ToString());
                Bitmap bitmap = BitmapManager.GetSymbolBitMap(this.border, this.pbBorder.Width, this.pbBorder.Height);
                this.pbBorder.Image = bitmap;
            }
        }

        private void nudShadowRounding_ValueChanged(object sender, EventArgs e)
        {
            if (this.shadow != null)
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
            if (this.shadow != null)
            {
                IFrameDecoration shadow = (IFrameDecoration) this.shadow;
                shadow.HorizontalSpacing = short.Parse(this.nudShadowX.Value.ToString());
                Bitmap bitmap = BitmapManager.GetSymbolBitMap(this.shadow, this.pbShadow.Width, this.pbShadow.Height);
                bitmap.MakeTransparent(bitmap.GetPixel(1, 1));
                this.pbShadow.Image = bitmap;
            }
        }

        private void nudShadowY_ValueChanged(object sender, EventArgs e)
        {
            if (this.shadow != null)
            {
                IFrameDecoration shadow = (IFrameDecoration) this.shadow;
                shadow.VerticalSpacing = short.Parse(this.nudShadowY.Value.ToString());
                Bitmap bitmap = BitmapManager.GetSymbolBitMap(this.shadow, this.pbShadow.Width, this.pbShadow.Height);
                bitmap.MakeTransparent(bitmap.GetPixel(1, 1));
                this.pbShadow.Image = bitmap;
            }
        }

        private void rgStyle_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this.init)
            {
                if (this.rgStyle.SelectedIndex == 0)
                {
                    this._scaleText.Style = esriScaleTextStyleEnum.esriScaleTextAbsolute;
                    this.cbePageUnit.Enabled = false;
                    this.tePageUnitLabel.Enabled = false;
                    this.cbeMapUnit.Enabled = false;
                    this.teMapUnitLabel.Enabled = false;
                }
                else
                {
                    this._scaleText.Style = esriScaleTextStyleEnum.esriScaleTextRelative;
                    this.cbePageUnit.Enabled = true;
                    this.tePageUnitLabel.Enabled = true;
                    this.cbeMapUnit.Enabled = true;
                    this.teMapUnitLabel.Enabled = true;
                }
                Bitmap bitmap = BitmapManager.GetSymbolBitMap(this._scaleText, this.pePreview.Width, this.pePreview.Height);
                this.pePreview.Image = bitmap;
            }
        }

        private void ScaleText_Load(object sender, EventArgs e)
        {
            if (this._preMapsurroundFrame != null)
            {
                this._scaleText = (this._preMapsurroundFrame.MapSurround as IClone).Clone() as IScaleText2;
            }
            else
            {
                this._scaleText = new ScaleTextClass();
                this._scaleText.Map = this._activeView.FocusMap;
                this._scaleText.Style = esriScaleTextStyleEnum.esriScaleTextAbsolute;
                this._scaleText.MapUnits = this._activeView.FocusMap.MapUnits;
                this._scaleText.MapUnitLabel = UnitService.GetUnitFromESRIUnitChinese(this._scaleText.MapUnits);
                this._scaleText.PageUnits = ((IPageLayout) this._activeView).Page.Units;
                this._scaleText.PageUnitLabel = UnitService.GetUnitFromESRIUnitChinese(this._scaleText.PageUnits);
                this._scaleText.Separator = ":";
            }
            this.InitialControl();
        }

        private void teMapUnitLabel_TextChanged(object sender, EventArgs e)
        {
            if (!this.init)
            {
                this._scaleText.MapUnitLabel = this.teMapUnitLabel.Text;
                Bitmap bitmap = BitmapManager.GetSymbolBitMap(this._scaleText, this.pePreview.Width, this.pePreview.Height);
                this.pePreview.Image = bitmap;
            }
        }

        private void tePageUnitLabel_TextChanged(object sender, EventArgs e)
        {
            if (!this.init)
            {
                this._scaleText.PageUnitLabel = this.tePageUnitLabel.Text;
                Bitmap bitmap = BitmapManager.GetSymbolBitMap(this._scaleText, this.pePreview.Width, this.pePreview.Height);
                this.pePreview.Image = bitmap;
            }
        }

        private void teSperator_TextChanged(object sender, EventArgs e)
        {
            if (!this.init)
            {
                this._scaleText.Separator = this.teSperator.Text;
                Bitmap bitmap = BitmapManager.GetSymbolBitMap(this._scaleText, this.pePreview.Width, this.pePreview.Height);
                this.pePreview.Image = bitmap;
            }
        }

        public IActiveView ActiveView
        {
            set
            {
                this._activeView = value;
            }
        }

        public IPoint Point
        {
            set
            {
                this.m_Point = value;
            }
        }

        public IMapSurroundFrame PreMapsurroundFrame
        {
            set
            {
                this._preMapsurroundFrame = value;
            }
        }
    }
}

