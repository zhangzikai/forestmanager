namespace Cartography.Element
{
    using Cartography;
    using Cartography.Base;
    using Cartography.Render;
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
    using System.Runtime.InteropServices;
    using System.Windows.Forms;
    using Utilities;

    /// <summary>
    /// 制图--比例尺：窗体
    /// </summary>
    public class DevScaleBar : FormBase3
    {
        private IActiveView _activeView;
        private IMapSurroundFrame _mapSurroundFrame;
        private IMapSurroundFrame _preMapsurroundFrame;
        private IScaleBar _scaleBar;
        private ISymbolBackground background;
        private Dictionary<IStyleGalleryItem, Bitmap> bitmapItem;
        private ISymbolBorder border;
        private SimpleButton btBack;
        private SimpleButton btBorder;
        private SimpleButton btBSymbolF;
        private SimpleButton btBSymbolS;
        private SimpleButton btCancel;
        private SimpleButton btNSymbol;
        private SimpleButton btOk;
        private SimpleButton btSDSymbol;
        private SimpleButton btShadow;
        private SimpleButton btSymbol;
        private SimpleButton btUSymbol;
        private ComboBoxEdit cbAdjustW;
        private ComboBoxEdit cbMPos;
        private ComboBoxEdit cbMStyle;
        private ComboBoxEdit cbNPos;
        private CheckEdit cbPad;
        private CheckEdit cbPlug;
        private CheckEdit cbThou;
        private ComboBoxEdit cbUnit;
        private ComboBoxEdit cbUPos;
        private CheckEdit cbZero;
        private ComboBoxEdit comboBox1;
        private IContainer components;
        private GroupBox gbBack;
        private GroupBox gbBorder;
        private GroupBox gbDropShadow;
        private GroupBox gbMark;
        private GroupBox gbNAlign;
        private GroupBox gbNRounding;
        private GroupBox gbNumber;
        private GroupBox gbScale;
        private GroupBox gbUnit;
        private GroupBox groupBox1;
        private ImageListBoxControl ilbcScale;
        private ImageList imageList;
        private bool init;
        private LabelControl labelControl1;
        private LabelControl labelControl2;
        private LabelControl labelControl6;
        private LabelControl lbAdjusW;
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
        private LabelControl lbChar;
        private LabelControl lbDHeight;
        private LabelControl lbDivUnit;
        private LabelControl lbDn;
        private LabelControl lbDUnit;
        private LabelControl lbDValue;
        private LabelControl lbFre;
        private LabelControl lbLabel;
        private LabelControl lbMPos;
        private LabelControl lbMStyle;
        private LabelControl lbNGap;
        private LabelControl lbNPos;
        private LabelControl lbSDHeight;
        private LabelControl lbShadowGap;
        private LabelControl lbShadowRounding;
        private LabelControl lbShadowSymbol;
        private LabelControl lbShadowX;
        private LabelControl lbShadowXPts;
        private LabelControl lbShadowY;
        private LabelControl lbShadowYPts;
        private LabelControl lbSub;
        private LabelControl lbUGap;
        private LabelControl lbUPos;
        private IPoint m_Point;
        private const string mClassName = "Cartography.Element.DevScaleBar";
        private ErrorOpt mErrOpt = UtilFactory.GetErrorOpt();
        private string mSubSysName = UtilFactory.GetConfigOpt().GetSystemName();
        private SpinEdit nudAlign;
        private SpinEdit nudBackRounding;
        private SpinEdit nudBackX;
        private SpinEdit nudBackY;
        private SpinEdit nudBorderRounding;
        private SpinEdit nudBorderX;
        private SpinEdit nudBorderY;
        private SpinEdit nudD;
        private SpinEdit nudDHeight;
        private SpinEdit nudNGap;
        private SpinEdit nudRounding;
        private SpinEdit nudSD;
        private SpinEdit nudShadowRounding;
        private SpinEdit nudShadowX;
        private SpinEdit nudShadowY;
        private SpinEdit nudUGap;
        private SpinEdit numericUpDown5;
        private PictureEdit pbBack;
        private PictureEdit pbBorder;
        private PictureEdit pbShadow;
        private RadioGroup rgAlignment;
        private RadioGroup rgRound;
        private ISymbolShadow shadow;
        private TextEdit tbDValue;
        private TextEdit txtUCon;
        private XtraTabControl xtcScale;
        private XtraTabPage xtpDataTick;
        private XtraTabPage xtpFrame;
        private XtraTabPage xtpSBar;
        private XtraTabPage xtpSUnit;
        private XtraTabPage xtpSymbol;

        /// <summary>
        /// 制图--比例尺：构造器
        /// </summary>
        public DevScaleBar()
        {
            this.InitializeComponent();
            this.bitmapItem = BitmapManager.GetBitMapText("Scale Bars", 0xe1, 30);
            foreach (KeyValuePair<IStyleGalleryItem, Bitmap> pair in this.bitmapItem)
            {
                this.imageList.Images.Add(pair.Key.Name, pair.Value);
            }
            base.Load += new EventHandler(this.DevScaleBar_Load);
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

        private void btBSymbolF_Click(object sender, EventArgs e)
        {
            DevSymbolSelector selector = new DevSymbolSelector();
            IStyleGalleryItem item = null;
            if (this._scaleBar is IScaleLine)
            {
                item = selector.GetItem(esriGeometryType.esriGeometryPolyline, null, -1);
                if (item == null)
                {
                    return;
                }
                IScaleLine line = (IScaleLine) this._scaleBar;
                line.LineSymbol = (ILineSymbol) item.Item;
            }
            else
            {
                item = selector.GetItem(esriGeometryType.esriGeometryPolygon, null, -1);
                if (item == null)
                {
                    return;
                }
                if (this._scaleBar is IDoubleFillScaleBar)
                {
                    IDoubleFillScaleBar bar = (IDoubleFillScaleBar) this._scaleBar;
                    bar.FillSymbol1 = (IFillSymbol) item.Item;
                }
            }
            selector.Dispose();
        }

        private void btBSymbolS_Click(object sender, EventArgs e)
        {
            DevSymbolSelector selector = new DevSymbolSelector();
            IStyleGalleryItem item = selector.GetItem(esriGeometryType.esriGeometryPolygon, null, -1);
            selector.Dispose();
            if (item != null)
            {
                IDoubleFillScaleBar bar = (IDoubleFillScaleBar) this._scaleBar;
                bar.FillSymbol2 = (IFillSymbol) item.Item;
            }
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        private void btNSymbol_Click(object sender, EventArgs e)
        {
            DevText text = new DevText();
            text.Text = "文本符号";
            text.ActiveView = this._activeView;
            text.PreTextSymbol = this._scaleBar.LabelSymbol;
            text.ShowDialog();
            this._scaleBar.LabelSymbol = text.PreTextSymbol;
            text.Dispose();
        }

        private void btOk_Click(object sender, EventArgs e)
        {
            this.Create();
            base.Close();
        }

        private void btSDSymbol_Click(object sender, EventArgs e)
        {
            IScaleMarks marks = (IScaleMarks) this._scaleBar;
            DevSymbolSelector selector = new DevSymbolSelector();
            IStyleGalleryItem item = selector.GetItem(esriGeometryType.esriGeometryPolyline, null, -1);
            selector.Dispose();
            if (item != null)
            {
                marks.SubdivisionMarkSymbol = (ILineSymbol) item.Item;
            }
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

        private void btSymbol_Click(object sender, EventArgs e)
        {
            IScaleMarks marks = (IScaleMarks) this._scaleBar;
            DevSymbolSelector selector = new DevSymbolSelector();
            IStyleGalleryItem item = selector.GetItem(esriGeometryType.esriGeometryPolyline, null, -1);
            selector.Dispose();
            if (item != null)
            {
                marks.DivisionMarkSymbol = (ILineSymbol) item.Item;
            }
        }

        private void btUSymbol_Click(object sender, EventArgs e)
        {
            frmTextSymbol symbol = new frmTextSymbol();
            ISymbol unitLabelSymbol = (ISymbol) this._scaleBar.UnitLabelSymbol;
            symbol.SymbolSource = unitLabelSymbol;
            if (symbol.ShowDialog() == DialogResult.OK)
            {
                ISymbol symbolSelected = (ISymbol) symbol.SymbolSelected;
                this._scaleBar.UnitLabelSymbol = (ITextSymbol) symbolSelected;
                symbol.Dispose();
            }
        }

        private void cbAdjustW_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this.init)
            {
                switch (this.cbAdjustW.SelectedIndex)
                {
                    case 0:
                        this.tbDValue.Enabled = true;
                        this.nudD.Enabled = true;
                        this._scaleBar.ResizeHint = esriScaleBarResizeHint.esriScaleBarFixed;
                        return;

                    case 1:
                        this.tbDValue.Enabled = false;
                        this.nudD.Enabled = true;
                        this._scaleBar.ResizeHint = esriScaleBarResizeHint.esriScaleBarAutoDivision;
                        return;

                    case 2:
                        this.tbDValue.Enabled = true;
                        this.nudD.Enabled = false;
                        this._scaleBar.ResizeHint = esriScaleBarResizeHint.esriScaleBarAutoDivisions;
                        return;
                }
            }
        }

        private void cbMPos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this.init)
            {
                IScaleMarks marks = (IScaleMarks) this._scaleBar;
                switch (this.cbMPos.SelectedIndex)
                {
                    case 0:
                        marks.MarkPosition = esriVertPosEnum.esriAbove;
                        return;

                    case 1:
                        marks.MarkPosition = esriVertPosEnum.esriTop;
                        return;

                    case 2:
                        marks.MarkPosition = esriVertPosEnum.esriOn;
                        return;

                    case 3:
                        marks.MarkPosition = esriVertPosEnum.esriBottom;
                        return;

                    case 4:
                        marks.MarkPosition = esriVertPosEnum.esriBelow;
                        return;
                }
            }
        }

        private void cbMStyle_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this.init)
            {
                IScaleMarks marks = (IScaleMarks) this._scaleBar;
                switch (this.cbMStyle.SelectedIndex)
                {
                    case 0:
                        marks.MarkFrequency = esriScaleBarFrequency.esriScaleBarNone;
                        this.MControlCheck(false);
                        return;

                    case 1:
                        marks.MarkFrequency = esriScaleBarFrequency.esriScaleBarOne;
                        this.MControlCheck(true);
                        return;

                    case 2:
                        marks.MarkFrequency = esriScaleBarFrequency.esriScaleBarMajorDivisions;
                        this.MControlCheck(true);
                        return;

                    case 3:
                        marks.MarkFrequency = esriScaleBarFrequency.esriScaleBarDivisions;
                        this.MControlCheck(true);
                        return;

                    case 4:
                        marks.MarkFrequency = esriScaleBarFrequency.esriScaleBarDivisionsAndFirstMidpoint;
                        this.MControlCheck(true);
                        return;

                    case 5:
                        marks.MarkFrequency = esriScaleBarFrequency.esriScaleBarDivisionsAndFirstSubdivisions;
                        this.MControlCheck(true);
                        return;

                    case 6:
                        marks.MarkFrequency = esriScaleBarFrequency.esriScaleBarDivisionsAndSubdivisions;
                        this.MControlCheck(true);
                        return;
                }
            }
        }

        private void cbNPos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this.init)
            {
                switch (this.cbNPos.SelectedIndex)
                {
                    case 0:
                        this._scaleBar.LabelPosition = esriVertPosEnum.esriAbove;
                        return;

                    case 1:
                        this._scaleBar.LabelPosition = esriVertPosEnum.esriTop;
                        return;

                    case 2:
                        this._scaleBar.LabelPosition = esriVertPosEnum.esriOn;
                        return;

                    case 3:
                        this._scaleBar.LabelPosition = esriVertPosEnum.esriBottom;
                        return;

                    case 4:
                        this._scaleBar.LabelPosition = esriVertPosEnum.esriBelow;
                        return;
                }
            }
        }

        private void cbPad_Click(object sender, EventArgs e)
        {
            INumericFormat numberFormat = (INumericFormat) this._scaleBar.NumberFormat;
            numberFormat.ZeroPad = this.cbPad.Checked;
            this._scaleBar.NumberFormat = (INumberFormat) numberFormat;
        }

        private void cbPlug_Click(object sender, EventArgs e)
        {
            INumericFormat numberFormat = (INumericFormat) this._scaleBar.NumberFormat;
            numberFormat.ShowPlusSign = this.cbPlug.Checked;
            this._scaleBar.NumberFormat = (INumberFormat) numberFormat;
        }

        private void cbThou_Click(object sender, EventArgs e)
        {
            INumericFormat numberFormat = (INumericFormat) this._scaleBar.NumberFormat;
            numberFormat.UseSeparator = this.cbThou.Checked;
            this._scaleBar.NumberFormat = (INumberFormat) numberFormat;
        }

        private void cbUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this.init)
            {
                this._scaleBar.Units = UnitService.GetUnitFromChineseUnitESRI(this.cbUnit.Text);
                this._scaleBar.UnitLabel = this.cbUnit.Text;
                this.txtUCon.Text = this.cbUnit.Text;
            }
        }

        private void cbUPos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this.init)
            {
                switch (this.cbUPos.SelectedIndex)
                {
                    case 0:
                        this._scaleBar.UnitLabelPosition = esriScaleBarPos.esriScaleBarBeforeLabels;
                        return;

                    case 1:
                        this._scaleBar.UnitLabelPosition = esriScaleBarPos.esriScaleBarAfterLabels;
                        return;

                    case 2:
                        this._scaleBar.UnitLabelPosition = esriScaleBarPos.esriScaleBarBeforeBar;
                        return;

                    case 3:
                        this._scaleBar.UnitLabelPosition = esriScaleBarPos.esriScaleBarAfterBar;
                        return;

                    case 4:
                        this._scaleBar.UnitLabelPosition = esriScaleBarPos.esriScaleBarAbove;
                        return;

                    case 5:
                        this._scaleBar.UnitLabelPosition = esriScaleBarPos.esriScaleBarBelow;
                        return;
                }
            }
        }

        private void cbZero_Click(object sender, EventArgs e)
        {
            if (!this.init)
            {
                if (this.cbZero.Checked)
                {
                    this._scaleBar.DivisionsBeforeZero = 1;
                }
                else
                {
                    this._scaleBar.DivisionsBeforeZero = 0;
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this.init)
            {
                switch (this.comboBox1.SelectedIndex)
                {
                    case 0:
                        this._scaleBar.LabelFrequency = esriScaleBarFrequency.esriScaleBarNone;
                        this.NControlChecked(false);
                        return;

                    case 1:
                        this._scaleBar.LabelFrequency = esriScaleBarFrequency.esriScaleBarOne;
                        this.NControlChecked(true);
                        return;

                    case 2:
                        this._scaleBar.LabelFrequency = esriScaleBarFrequency.esriScaleBarMajorDivisions;
                        this.NControlChecked(true);
                        return;

                    case 3:
                        this._scaleBar.LabelFrequency = esriScaleBarFrequency.esriScaleBarDivisions;
                        this.NControlChecked(true);
                        return;

                    case 4:
                        this._scaleBar.LabelFrequency = esriScaleBarFrequency.esriScaleBarDivisionsAndFirstMidpoint;
                        this.NControlChecked(true);
                        return;

                    case 5:
                        this._scaleBar.LabelFrequency = esriScaleBarFrequency.esriScaleBarDivisionsAndFirstSubdivisions;
                        this.NControlChecked(true);
                        return;

                    case 6:
                        this._scaleBar.LabelFrequency = esriScaleBarFrequency.esriScaleBarDivisionsAndSubdivisions;
                        this.NControlChecked(true);
                        return;
                }
            }
        }

        private void Create()
        {
            try
            {
                ElementService service = new ElementService();
                IPageLayout layout = this._activeView as IPageLayout;
                this._scaleBar.Refresh();
                IFrameProperties properties = null;
                object data = null;
                if (this._preMapsurroundFrame == null)
                {
                    double num;
                    double num2;
                    layout.Page.QuerySize(out num, out num2);
                    IEnvelope pEnvelope = new EnvelopeClass();
                    if (this.m_Point == null)
                    {
                        ////pEnvelope.XMin = num / 2.0;
                        ////pEnvelope.XMax = pEnvelope.XMin + 3.0;
                        ////pEnvelope.YMin = 2.0;
                        ////pEnvelope.YMax = pEnvelope.YMin + 0.4;
                        pEnvelope.XMin = num / 1.8;
                        pEnvelope.XMax = pEnvelope.XMin + 3.0;
                        pEnvelope.YMin = 1;
                        pEnvelope.YMax = pEnvelope.YMin + 0.4;
                    }
                    else
                    {
                        pEnvelope.PutCoords(this.m_Point.X, this.m_Point.Y, this.m_Point.X + 3.0, this.m_Point.Y + 0.2);
                    }
                    this._mapSurroundFrame = service.CreateMapsurround((IPageLayout) this._activeView, this._activeView.FocusMap, this._scaleBar, pEnvelope);
                    properties = (IFrameProperties) this._mapSurroundFrame;
                    data = this._mapSurroundFrame;
                }
                else
                {
                    this._preMapsurroundFrame.MapSurround = null;
                    this._preMapsurroundFrame.MapSurround = this._scaleBar;
                    IElement element = this._preMapsurroundFrame as IElement;
                    IEnvelope envelope = element.Geometry.Envelope;
                    IEnvelope oldBounds = new EnvelopeClass();
                    oldBounds.PutCoords(envelope.XMin, envelope.YMin, envelope.XMax, envelope.YMax);
                    this._scaleBar.QueryBounds(this._activeView.ScreenDisplay, oldBounds, oldBounds);
                    Marshal.ReleaseComObject(element.Geometry);
                    element.Geometry = oldBounds;
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
                this.mErrOpt.ErrorOperate(this.mSubSysName, "Cartography.Element.DevScaleBar", "Create", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void DevScaleBar_Load(object sender, EventArgs e)
        {
            try
            {
                if (this._preMapsurroundFrame == null)
                {
                    this._scaleBar = new AlternatingScaleBarClass();
                    this._scaleBar.Map = this._activeView.FocusMap;
                    this._scaleBar.Name = "Alternating Scale Bar 1";
                    this._scaleBar.Units = this._scaleBar.Map.MapUnits;
                    this._scaleBar.UnitLabel = UnitService.GetUnitFromESRIUnitChinese(this._scaleBar.Units);
                }
                else
                {
                    if (this._preMapsurroundFrame.MapSurround is AlternatingScaleBar)
                    {
                        this._scaleBar = new AlternatingScaleBarClass();
                    }
                    else if (this._preMapsurroundFrame.MapSurround is DoubleAlternatingScaleBar)
                    {
                        this._scaleBar = new DoubleAlternatingScaleBarClass();
                    }
                    else if (this._preMapsurroundFrame.MapSurround is HollowScaleBar)
                    {
                        this._scaleBar = new HollowScaleBarClass();
                    }
                    else if (this._preMapsurroundFrame.MapSurround is SteppedScaleLine)
                    {
                        this._scaleBar = new SteppedScaleLineClass();
                    }
                    else if (this._preMapsurroundFrame.MapSurround is SingleDivisionScaleBar)
                    {
                        this._scaleBar = new SingleDivisionScaleBarClass();
                    }
                    else
                    {
                        this._scaleBar = new ScaleLineClass();
                    }
                    this._scaleBar = (this._preMapsurroundFrame.MapSurround as IClone).Clone() as IScaleBar;
                }
                this.InitialControl();
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "Cartography.Element.DevScaleBar", "DevScaleBar_Load", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
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

        /// <summary>
        /// 符号选择 改变的响应事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ilbcScale_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this.init && (this.ilbcScale.Items.Count > 0))
            {
                double divisions = this._scaleBar.Divisions;
                esriScaleBarResizeHint resizeHint = this._scaleBar.ResizeHint;
                short subdivisions = this._scaleBar.Subdivisions;
                short divisionsBeforeZero = this._scaleBar.DivisionsBeforeZero;
                esriUnits units = this._scaleBar.Units;
                string unitLabel = this._scaleBar.UnitLabel;
                esriScaleBarPos unitLabelPosition = this._scaleBar.UnitLabelPosition;
                ITextSymbol unitLabelSymbol = this._scaleBar.UnitLabelSymbol;
                double unitLabelGap = this._scaleBar.UnitLabelGap;
                esriScaleBarFrequency labelFrequency = this._scaleBar.LabelFrequency;
                esriVertPosEnum labelPosition = this._scaleBar.LabelPosition;
                double labelGap = this._scaleBar.LabelGap;
                ITextSymbol labelSymbol = this._scaleBar.LabelSymbol;
                IScaleMarks marks = (IScaleMarks) this._scaleBar;
                esriScaleBarFrequency markFrequency = marks.MarkFrequency;
                esriVertPosEnum markPosition = marks.MarkPosition;
                double divisionMarkHeight = marks.DivisionMarkHeight;
                ILineSymbol divisionMarkSymbol = marks.DivisionMarkSymbol;
                double subdivisionMarkHeight = marks.SubdivisionMarkHeight;
                ILineSymbol subdivisionMarkSymbol = marks.SubdivisionMarkSymbol;
                INumberFormat numberFormat = this._scaleBar.NumberFormat;
                ILineSymbol lineSymbol = null;
                IFillSymbol symbol6 = null;
                IFillSymbol symbol7 = null;
                if (this._scaleBar is IScaleLine)
                {
                    lineSymbol = ((IScaleLine) this._scaleBar).LineSymbol;
                }
                if (this._scaleBar is IDoubleFillScaleBar)
                {
                    IDoubleFillScaleBar bar = this._scaleBar as IDoubleFillScaleBar;
                    symbol6 = bar.FillSymbol1;
                    symbol7 = bar.FillSymbol2;
                }
                string pItemName = this.ilbcScale.GetItemValue(this.ilbcScale.SelectedIndex).ToString();
                this._scaleBar = (IScaleBar) this.GetItem(pItemName).Item;
                this._scaleBar.Name = pItemName;
                this._scaleBar.Division = divisions;
                this._scaleBar.ResizeHint = resizeHint;
                this._scaleBar.Subdivisions = subdivisions;
                this._scaleBar.DivisionsBeforeZero = divisionsBeforeZero;
                this._scaleBar.Units = units;
                this._scaleBar.UnitLabel = unitLabel;
                this._scaleBar.UnitLabelPosition = unitLabelPosition;
                this._scaleBar.UnitLabelSymbol = unitLabelSymbol;
                this._scaleBar.UnitLabelGap = unitLabelGap;
                this._scaleBar.LabelFrequency = labelFrequency;
                this._scaleBar.LabelPosition = labelPosition;
                this._scaleBar.LabelGap = labelGap;
                this._scaleBar.LabelSymbol = labelSymbol;
                marks = (IScaleMarks) this._scaleBar;
                marks.MarkFrequency = markFrequency;
                marks.MarkPosition = markPosition;
                marks.DivisionMarkHeight = divisionMarkHeight;
                marks.DivisionMarkSymbol = divisionMarkSymbol;
                marks.SubdivisionMarkHeight = subdivisionMarkHeight;
                marks.SubdivisionMarkSymbol = subdivisionMarkSymbol;
                this._scaleBar.NumberFormat = numberFormat;
                if ((this._scaleBar is IScaleLine) && (lineSymbol != null))
                {
                    ((IScaleLine) this._scaleBar).LineSymbol = lineSymbol;
                }
                if (this._scaleBar is IDoubleFillScaleBar)
                {
                    IDoubleFillScaleBar bar2 = this._scaleBar as IDoubleFillScaleBar;
                    if (symbol6 != null)
                    {
                        bar2.FillSymbol1 = symbol6;
                    }
                    if (symbol7 != null)
                    {
                        bar2.FillSymbol2 = symbol7;
                    }
                }
                if (this._scaleBar is ISingleFillScaleBar)
                {
                    ISingleFillScaleBar bar3 = this._scaleBar as ISingleFillScaleBar;
                    if (symbol6 != null)
                    {
                        bar3.FillSymbol = symbol6;
                    }
                }
            }
        }

        private void InitialControl()
        {
            this.init = true;
            if (this._preMapsurroundFrame != null)
            {
                this.btOk.Text = "更新";
            }
            for (int i = 0; i < this.imageList.Images.Count; i++)
            {
                string str = this.imageList.Images.Keys[i];
                this.ilbcScale.Items.Add(str, i);
                if (this._scaleBar.Name == str)
                {
                    this.ilbcScale.SelectedItem = this.ilbcScale.Items[i];
                }
            }
            switch (this._scaleBar.ResizeHint)
            {
                case esriScaleBarResizeHint.esriScaleBarFixed:
                    this.tbDValue.Enabled = true;
                    this.nudD.Enabled = true;
                    this.cbAdjustW.Text = this.cbAdjustW.Properties.Items[0].ToString();
                    break;

                case esriScaleBarResizeHint.esriScaleBarAutoDivision:
                    this.tbDValue.Enabled = false;
                    this.nudD.Enabled = true;
                    this.cbAdjustW.Text = this.cbAdjustW.Properties.Items[1].ToString();
                    this.tbDValue.Text = "自动";
                    break;

                case esriScaleBarResizeHint.esriScaleBarAutoDivisions:
                    this.tbDValue.Enabled = true;
                    this.nudD.Enabled = false;
                    this.cbAdjustW.Text = this.cbAdjustW.Properties.Items[2].ToString();
                    break;
            }
            this.nudD.Value = decimal.Parse(this._scaleBar.Divisions.ToString());
            this.nudSD.Value = decimal.Parse(this._scaleBar.Subdivisions.ToString());
            this.tbDValue.Text = this._scaleBar.Division.ToString();
            if (this._scaleBar.DivisionsBeforeZero == 0)
            {
                this.cbZero.Checked = true;
            }
            this.cbUnit.Text = this._scaleBar.UnitLabel;
            switch (this._scaleBar.UnitLabelPosition)
            {
                case esriScaleBarPos.esriScaleBarAbove:
                    this.cbUPos.Text = this.cbUPos.Properties.Items[4].ToString();
                    break;

                case esriScaleBarPos.esriScaleBarBeforeLabels:
                    this.cbUPos.Text = this.cbUPos.Properties.Items[0].ToString();
                    break;

                case esriScaleBarPos.esriScaleBarAfterLabels:
                    this.cbUPos.Text = this.cbUPos.Properties.Items[1].ToString();
                    break;

                case esriScaleBarPos.esriScaleBarBeforeBar:
                    this.cbUPos.Text = this.cbUPos.Properties.Items[2].ToString();
                    break;

                case esriScaleBarPos.esriScaleBarAfterBar:
                    this.cbUPos.Text = this.cbUPos.Properties.Items[3].ToString();
                    break;

                case esriScaleBarPos.esriScaleBarBelow:
                    this.cbUPos.Text = this.cbUPos.Properties.Items[5].ToString();
                    break;
            }
            this.txtUCon.Text = this._scaleBar.UnitLabel;
            this.nudUGap.Value = decimal.Parse(this._scaleBar.UnitLabelGap.ToString());
            switch (this._scaleBar.LabelFrequency)
            {
                case esriScaleBarFrequency.esriScaleBarNone:
                    this.comboBox1.Text = this.comboBox1.Properties.Items[0].ToString();
                    break;

                case esriScaleBarFrequency.esriScaleBarOne:
                    this.comboBox1.Text = this.comboBox1.Properties.Items[1].ToString();
                    break;

                case esriScaleBarFrequency.esriScaleBarMajorDivisions:
                    this.comboBox1.Text = this.comboBox1.Properties.Items[2].ToString();
                    break;

                case esriScaleBarFrequency.esriScaleBarDivisions:
                    this.comboBox1.Text = this.comboBox1.Properties.Items[3].ToString();
                    break;

                case esriScaleBarFrequency.esriScaleBarDivisionsAndFirstMidpoint:
                    this.comboBox1.Text = this.comboBox1.Properties.Items[4].ToString();
                    break;

                case esriScaleBarFrequency.esriScaleBarDivisionsAndFirstSubdivisions:
                    this.comboBox1.Text = this.comboBox1.Properties.Items[5].ToString();
                    break;

                case esriScaleBarFrequency.esriScaleBarDivisionsAndSubdivisions:
                    this.comboBox1.Text = this.comboBox1.Properties.Items[6].ToString();
                    break;
            }
            switch (this._scaleBar.LabelPosition)
            {
                case esriVertPosEnum.esriAbove:
                    this.cbNPos.Text = this.cbNPos.Properties.Items[0].ToString();
                    break;

                case esriVertPosEnum.esriTop:
                    this.cbNPos.Text = this.cbNPos.Properties.Items[1].ToString();
                    break;

                case esriVertPosEnum.esriOn:
                    this.cbNPos.Text = this.cbNPos.Properties.Items[2].ToString();
                    break;

                case esriVertPosEnum.esriBottom:
                    this.cbNPos.Text = this.cbNPos.Properties.Items[3].ToString();
                    break;

                case esriVertPosEnum.esriBelow:
                    this.cbNPos.Text = this.cbNPos.Properties.Items[4].ToString();
                    break;
            }
            this.nudUGap.Value = decimal.Parse(this._scaleBar.LabelGap.ToString());
            IScaleMarks marks = (IScaleMarks) this._scaleBar;
            switch (marks.MarkFrequency)
            {
                case esriScaleBarFrequency.esriScaleBarNone:
                    this.cbMStyle.Text = this.cbMStyle.Properties.Items[0].ToString();
                    break;

                case esriScaleBarFrequency.esriScaleBarOne:
                    this.cbMStyle.Text = this.cbMStyle.Properties.Items[1].ToString();
                    break;

                case esriScaleBarFrequency.esriScaleBarMajorDivisions:
                    this.cbMStyle.Text = this.cbMStyle.Properties.Items[2].ToString();
                    break;

                case esriScaleBarFrequency.esriScaleBarDivisions:
                    this.cbMStyle.Text = this.cbMStyle.Properties.Items[3].ToString();
                    break;

                case esriScaleBarFrequency.esriScaleBarDivisionsAndFirstMidpoint:
                    this.cbMStyle.Text = this.cbMStyle.Properties.Items[4].ToString();
                    break;

                case esriScaleBarFrequency.esriScaleBarDivisionsAndFirstSubdivisions:
                    this.cbMStyle.Text = this.cbMStyle.Properties.Items[5].ToString();
                    break;

                case esriScaleBarFrequency.esriScaleBarDivisionsAndSubdivisions:
                    this.cbMStyle.Text = this.cbMStyle.Properties.Items[6].ToString();
                    break;
            }
            switch (marks.MarkPosition)
            {
                case esriVertPosEnum.esriAbove:
                    this.cbMPos.Text = this.cbMPos.Properties.Items[0].ToString();
                    break;

                case esriVertPosEnum.esriTop:
                    this.cbMPos.Text = this.cbMPos.Properties.Items[1].ToString();
                    break;

                case esriVertPosEnum.esriOn:
                    this.cbMPos.Text = this.cbMPos.Properties.Items[2].ToString();
                    break;

                case esriVertPosEnum.esriBottom:
                    this.cbMPos.Text = this.cbMPos.Properties.Items[3].ToString();
                    break;

                case esriVertPosEnum.esriBelow:
                    this.cbMPos.Text = this.cbMPos.Properties.Items[4].ToString();
                    break;
            }
            this.nudDHeight.Value = decimal.Parse(marks.DivisionMarkHeight.ToString());
            this.numericUpDown5.Value = decimal.Parse(marks.SubdivisionMarkHeight.ToString());
            INumericFormat numberFormat = (INumericFormat) this._scaleBar.NumberFormat;
            switch (numberFormat.RoundingOption)
            {
                case esriRoundingOptionEnum.esriRoundNumberOfDecimals:
                    this.rgRound.SelectedIndex = 0;
                    this.nudAlign.Enabled = false;
                    break;

                case esriRoundingOptionEnum.esriRoundNumberOfSignificantDigits:
                    this.rgRound.SelectedIndex = 1;
                    break;
            }
            this.nudRounding.Value = decimal.Parse(numberFormat.RoundingValue.ToString());
            switch (numberFormat.AlignmentOption)
            {
                case esriNumericAlignmentEnum.esriAlignRight:
                    this.rgAlignment.SelectedIndex = 1;
                    break;

                case esriNumericAlignmentEnum.esriAlignLeft:
                    this.rgAlignment.SelectedIndex = 0;
                    break;
            }
            this.nudAlign.Value = decimal.Parse(numberFormat.AlignmentWidth.ToString());
            this.cbThou.Checked = numberFormat.UseSeparator;
            this.cbPad.Checked = numberFormat.ZeroPad;
            this.cbPlug.Checked = numberFormat.ShowPlusSign;
            IFrameProperties properties = null;
            if (this._preMapsurroundFrame != null)
            {
                properties = (IFrameProperties) this._preMapsurroundFrame;
                ISymbolBorder pSourceObj = (ISymbolBorder) properties.Border;
                ISymbolBackground background = (ISymbolBackground) properties.Background;
                ISymbolShadow shadow = (ISymbolShadow) properties.Shadow;
                IFrameDecoration decoration = null;
                Bitmap bitmap = null;
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

        private void InitializeComponent()
        {
            this.imageList = new System.Windows.Forms.ImageList();
            this.btOk = new DevExpress.XtraEditors.SimpleButton();
            this.btCancel = new DevExpress.XtraEditors.SimpleButton();
            this.xtpFrame = new DevExpress.XtraTab.XtraTabPage();
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
            this.xtpSBar = new DevExpress.XtraTab.XtraTabPage();
            this.xtpDataTick = new DevExpress.XtraTab.XtraTabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btBSymbolF = new DevExpress.XtraEditors.SimpleButton();
            this.btBSymbolS = new DevExpress.XtraEditors.SimpleButton();
            this.gbMark = new System.Windows.Forms.GroupBox();
            this.btSDSymbol = new DevExpress.XtraEditors.SimpleButton();
            this.numericUpDown5 = new DevExpress.XtraEditors.SpinEdit();
            this.btSymbol = new DevExpress.XtraEditors.SimpleButton();
            this.nudDHeight = new DevExpress.XtraEditors.SpinEdit();
            this.cbMPos = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cbMStyle = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lbSDHeight = new DevExpress.XtraEditors.LabelControl();
            this.lbDHeight = new DevExpress.XtraEditors.LabelControl();
            this.lbMPos = new DevExpress.XtraEditors.LabelControl();
            this.lbMStyle = new DevExpress.XtraEditors.LabelControl();
            this.gbNumber = new System.Windows.Forms.GroupBox();
            this.cbPlug = new DevExpress.XtraEditors.CheckEdit();
            this.cbPad = new DevExpress.XtraEditors.CheckEdit();
            this.cbThou = new DevExpress.XtraEditors.CheckEdit();
            this.btNSymbol = new DevExpress.XtraEditors.SimpleButton();
            this.nudNGap = new DevExpress.XtraEditors.SpinEdit();
            this.cbNPos = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lbNGap = new DevExpress.XtraEditors.LabelControl();
            this.lbNPos = new DevExpress.XtraEditors.LabelControl();
            this.comboBox1 = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lbFre = new DevExpress.XtraEditors.LabelControl();
            this.gbNAlign = new System.Windows.Forms.GroupBox();
            this.lbChar = new DevExpress.XtraEditors.LabelControl();
            this.nudAlign = new DevExpress.XtraEditors.SpinEdit();
            this.rgAlignment = new DevExpress.XtraEditors.RadioGroup();
            this.gbNRounding = new System.Windows.Forms.GroupBox();
            this.nudRounding = new DevExpress.XtraEditors.SpinEdit();
            this.rgRound = new DevExpress.XtraEditors.RadioGroup();
            this.xtpSUnit = new DevExpress.XtraTab.XtraTabPage();
            this.gbUnit = new System.Windows.Forms.GroupBox();
            this.nudUGap = new DevExpress.XtraEditors.SpinEdit();
            this.btUSymbol = new DevExpress.XtraEditors.SimpleButton();
            this.txtUCon = new DevExpress.XtraEditors.TextEdit();
            this.cbUPos = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cbUnit = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lbUGap = new DevExpress.XtraEditors.LabelControl();
            this.lbLabel = new DevExpress.XtraEditors.LabelControl();
            this.lbUPos = new DevExpress.XtraEditors.LabelControl();
            this.lbDUnit = new DevExpress.XtraEditors.LabelControl();
            this.gbScale = new System.Windows.Forms.GroupBox();
            this.cbZero = new DevExpress.XtraEditors.CheckEdit();
            this.cbAdjustW = new DevExpress.XtraEditors.ComboBoxEdit();
            this.nudSD = new DevExpress.XtraEditors.SpinEdit();
            this.nudD = new DevExpress.XtraEditors.SpinEdit();
            this.tbDValue = new DevExpress.XtraEditors.TextEdit();
            this.lbDivUnit = new DevExpress.XtraEditors.LabelControl();
            this.lbAdjusW = new DevExpress.XtraEditors.LabelControl();
            this.lbSub = new DevExpress.XtraEditors.LabelControl();
            this.lbDn = new DevExpress.XtraEditors.LabelControl();
            this.lbDValue = new DevExpress.XtraEditors.LabelControl();
            this.xtpSymbol = new DevExpress.XtraTab.XtraTabPage();
            this.ilbcScale = new DevExpress.XtraEditors.ImageListBoxControl();
            this.xtcScale = new DevExpress.XtraTab.XtraTabControl();
            this.xtpFrame.SuspendLayout();
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
            this.xtpDataTick.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.gbMark.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown5.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDHeight.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbMPos.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbMStyle.Properties)).BeginInit();
            this.gbNumber.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbPlug.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbPad.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbThou.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNGap.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbNPos.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBox1.Properties)).BeginInit();
            this.gbNAlign.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAlign.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgAlignment.Properties)).BeginInit();
            this.gbNRounding.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudRounding.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgRound.Properties)).BeginInit();
            this.xtpSUnit.SuspendLayout();
            this.gbUnit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudUGap.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUCon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbUPos.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbUnit.Properties)).BeginInit();
            this.gbScale.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbZero.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbAdjustW.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSD.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudD.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbDValue.Properties)).BeginInit();
            this.xtpSymbol.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ilbcScale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtcScale)).BeginInit();
            this.xtcScale.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageList
            // 
            this.imageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList.ImageSize = new System.Drawing.Size(256, 30);
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // btOk
            // 
            this.btOk.Location = new System.Drawing.Point(196, 464);
            this.btOk.Name = "btOk";
            this.btOk.Size = new System.Drawing.Size(87, 27);
            this.btOk.TabIndex = 2;
            this.btOk.Text = "创建";
            this.btOk.Click += new System.EventHandler(this.btOk_Click);
            // 
            // btCancel
            // 
            this.btCancel.Location = new System.Drawing.Point(303, 464);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(87, 27);
            this.btCancel.TabIndex = 3;
            this.btCancel.Text = "取消";
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // xtpFrame
            // 
            this.xtpFrame.Controls.Add(this.pbShadow);
            this.xtpFrame.Controls.Add(this.pbBack);
            this.xtpFrame.Controls.Add(this.pbBorder);
            this.xtpFrame.Controls.Add(this.gbDropShadow);
            this.xtpFrame.Controls.Add(this.gbBack);
            this.xtpFrame.Controls.Add(this.gbBorder);
            this.xtpFrame.Name = "xtpFrame";
            this.xtpFrame.Size = new System.Drawing.Size(581, 428);
            this.xtpFrame.Text = "图框";
            // 
            // pbShadow
            // 
            this.pbShadow.Location = new System.Drawing.Point(379, 299);
            this.pbShadow.Name = "pbShadow";
            this.pbShadow.Size = new System.Drawing.Size(176, 119);
            this.pbShadow.TabIndex = 55;
            // 
            // pbBack
            // 
            this.pbBack.Location = new System.Drawing.Point(379, 156);
            this.pbBack.Name = "pbBack";
            this.pbBack.Size = new System.Drawing.Size(176, 119);
            this.pbBack.TabIndex = 54;
            // 
            // pbBorder
            // 
            this.pbBorder.Location = new System.Drawing.Point(379, 13);
            this.pbBorder.Name = "pbBorder";
            this.pbBorder.Size = new System.Drawing.Size(176, 119);
            this.pbBorder.TabIndex = 53;
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
            this.gbDropShadow.Location = new System.Drawing.Point(22, 288);
            this.gbDropShadow.Name = "gbDropShadow";
            this.gbDropShadow.Size = new System.Drawing.Size(343, 129);
            this.gbDropShadow.TabIndex = 52;
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
            this.gbBack.Location = new System.Drawing.Point(22, 146);
            this.gbBack.Name = "gbBack";
            this.gbBack.Size = new System.Drawing.Size(343, 129);
            this.gbBack.TabIndex = 51;
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
            this.gbBorder.Location = new System.Drawing.Point(22, 3);
            this.gbBorder.Name = "gbBorder";
            this.gbBorder.Size = new System.Drawing.Size(343, 129);
            this.gbBorder.TabIndex = 50;
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
            // xtpSBar
            // 
            this.xtpSBar.Name = "xtpSBar";
            this.xtpSBar.PageVisible = false;
            this.xtpSBar.Size = new System.Drawing.Size(581, 428);
            this.xtpSBar.Text = "比例栏";
            // 
            // xtpDataTick
            // 
            this.xtpDataTick.Controls.Add(this.groupBox1);
            this.xtpDataTick.Controls.Add(this.gbMark);
            this.xtpDataTick.Controls.Add(this.gbNumber);
            this.xtpDataTick.Name = "xtpDataTick";
            this.xtpDataTick.Size = new System.Drawing.Size(581, 428);
            this.xtpDataTick.Text = "数字和刻度线";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btBSymbolF);
            this.groupBox1.Controls.Add(this.btBSymbolS);
            this.groupBox1.Location = new System.Drawing.Point(338, 217);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(227, 114);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "比例尺符号样式";
            // 
            // btBSymbolF
            // 
            this.btBSymbolF.Location = new System.Drawing.Point(59, 33);
            this.btBSymbolF.Name = "btBSymbolF";
            this.btBSymbolF.Size = new System.Drawing.Size(87, 27);
            this.btBSymbolF.TabIndex = 11;
            this.btBSymbolF.Text = "符号一";
            this.btBSymbolF.Click += new System.EventHandler(this.btBSymbolF_Click);
            // 
            // btBSymbolS
            // 
            this.btBSymbolS.Location = new System.Drawing.Point(59, 70);
            this.btBSymbolS.Name = "btBSymbolS";
            this.btBSymbolS.Size = new System.Drawing.Size(87, 27);
            this.btBSymbolS.TabIndex = 12;
            this.btBSymbolS.Text = "符号二";
            this.btBSymbolS.Click += new System.EventHandler(this.btBSymbolS_Click);
            // 
            // gbMark
            // 
            this.gbMark.Controls.Add(this.btSDSymbol);
            this.gbMark.Controls.Add(this.numericUpDown5);
            this.gbMark.Controls.Add(this.btSymbol);
            this.gbMark.Controls.Add(this.nudDHeight);
            this.gbMark.Controls.Add(this.cbMPos);
            this.gbMark.Controls.Add(this.cbMStyle);
            this.gbMark.Controls.Add(this.lbSDHeight);
            this.gbMark.Controls.Add(this.lbDHeight);
            this.gbMark.Controls.Add(this.lbMPos);
            this.gbMark.Controls.Add(this.lbMStyle);
            this.gbMark.Location = new System.Drawing.Point(338, 0);
            this.gbMark.Name = "gbMark";
            this.gbMark.Size = new System.Drawing.Size(227, 210);
            this.gbMark.TabIndex = 3;
            this.gbMark.TabStop = false;
            this.gbMark.Text = "刻度线";
            // 
            // btSDSymbol
            // 
            this.btSDSymbol.Location = new System.Drawing.Point(146, 148);
            this.btSDSymbol.Name = "btSDSymbol";
            this.btSDSymbol.Size = new System.Drawing.Size(68, 27);
            this.btSDSymbol.TabIndex = 19;
            this.btSDSymbol.Text = "符号";
            this.btSDSymbol.Click += new System.EventHandler(this.btSDSymbol_Click);
            // 
            // numericUpDown5
            // 
            this.numericUpDown5.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.numericUpDown5.Location = new System.Drawing.Point(73, 149);
            this.numericUpDown5.Name = "numericUpDown5";
            this.numericUpDown5.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.numericUpDown5.Size = new System.Drawing.Size(49, 20);
            this.numericUpDown5.TabIndex = 18;
            this.numericUpDown5.ValueChanged += new System.EventHandler(this.numericUpDown5_ValueChanged);
            // 
            // btSymbol
            // 
            this.btSymbol.Location = new System.Drawing.Point(146, 105);
            this.btSymbol.Name = "btSymbol";
            this.btSymbol.Size = new System.Drawing.Size(68, 27);
            this.btSymbol.TabIndex = 17;
            this.btSymbol.Text = "符号";
            this.btSymbol.Click += new System.EventHandler(this.btSymbol_Click);
            // 
            // nudDHeight
            // 
            this.nudDHeight.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudDHeight.Location = new System.Drawing.Point(73, 106);
            this.nudDHeight.Name = "nudDHeight";
            this.nudDHeight.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.nudDHeight.Size = new System.Drawing.Size(47, 20);
            this.nudDHeight.TabIndex = 16;
            this.nudDHeight.ValueChanged += new System.EventHandler(this.nudDHeight_ValueChanged);
            // 
            // cbMPos
            // 
            this.cbMPos.Location = new System.Drawing.Point(73, 63);
            this.cbMPos.Name = "cbMPos";
            this.cbMPos.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbMPos.Properties.Items.AddRange(new object[] {
            "比例栏之上",
            "与比例栏顶部对齐",
            "比例栏中央",
            "与比例栏底端对齐",
            "比例栏下面"});
            this.cbMPos.Size = new System.Drawing.Size(140, 20);
            this.cbMPos.TabIndex = 15;
            this.cbMPos.SelectedIndexChanged += new System.EventHandler(this.cbMPos_SelectedIndexChanged);
            // 
            // cbMStyle
            // 
            this.cbMStyle.Location = new System.Drawing.Point(73, 20);
            this.cbMStyle.Name = "cbMStyle";
            this.cbMStyle.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbMStyle.Properties.Items.AddRange(new object[] {
            "无刻度线",
            "一个刻度线",
            "零值和末尾处各一个刻度线",
            "所有分划",
            "所有分划和第一个分划的中点",
            "所有分划和第一个细分划",
            "所有分划和细分划"});
            this.cbMStyle.Size = new System.Drawing.Size(140, 20);
            this.cbMStyle.TabIndex = 14;
            this.cbMStyle.SelectedIndexChanged += new System.EventHandler(this.cbMStyle_SelectedIndexChanged);
            // 
            // lbSDHeight
            // 
            this.lbSDHeight.Location = new System.Drawing.Point(7, 153);
            this.lbSDHeight.Name = "lbSDHeight";
            this.lbSDHeight.Size = new System.Drawing.Size(52, 14);
            this.lbSDHeight.TabIndex = 13;
            this.lbSDHeight.Text = "细分高度:";
            // 
            // lbDHeight
            // 
            this.lbDHeight.Location = new System.Drawing.Point(7, 110);
            this.lbDHeight.Name = "lbDHeight";
            this.lbDHeight.Size = new System.Drawing.Size(52, 14);
            this.lbDHeight.TabIndex = 12;
            this.lbDHeight.Text = "分划高度:";
            // 
            // lbMPos
            // 
            this.lbMPos.Location = new System.Drawing.Point(7, 66);
            this.lbMPos.Name = "lbMPos";
            this.lbMPos.Size = new System.Drawing.Size(52, 14);
            this.lbMPos.TabIndex = 11;
            this.lbMPos.Text = "标注位置:";
            // 
            // lbMStyle
            // 
            this.lbMStyle.Location = new System.Drawing.Point(7, 23);
            this.lbMStyle.Name = "lbMStyle";
            this.lbMStyle.Size = new System.Drawing.Size(52, 14);
            this.lbMStyle.TabIndex = 10;
            this.lbMStyle.Text = "标注风格:";
            // 
            // gbNumber
            // 
            this.gbNumber.Controls.Add(this.cbPlug);
            this.gbNumber.Controls.Add(this.cbPad);
            this.gbNumber.Controls.Add(this.cbThou);
            this.gbNumber.Controls.Add(this.btNSymbol);
            this.gbNumber.Controls.Add(this.nudNGap);
            this.gbNumber.Controls.Add(this.cbNPos);
            this.gbNumber.Controls.Add(this.lbNGap);
            this.gbNumber.Controls.Add(this.lbNPos);
            this.gbNumber.Controls.Add(this.comboBox1);
            this.gbNumber.Controls.Add(this.lbFre);
            this.gbNumber.Controls.Add(this.gbNAlign);
            this.gbNumber.Controls.Add(this.gbNRounding);
            this.gbNumber.Location = new System.Drawing.Point(12, 0);
            this.gbNumber.Name = "gbNumber";
            this.gbNumber.Size = new System.Drawing.Size(306, 421);
            this.gbNumber.TabIndex = 2;
            this.gbNumber.TabStop = false;
            this.gbNumber.Text = "数字";
            // 
            // cbPlug
            // 
            this.cbPlug.Location = new System.Drawing.Point(10, 385);
            this.cbPlug.Name = "cbPlug";
            this.cbPlug.Properties.Caption = "显示加号";
            this.cbPlug.Size = new System.Drawing.Size(87, 19);
            this.cbPlug.TabIndex = 23;
            this.cbPlug.Click += new System.EventHandler(this.cbPlug_Click);
            // 
            // cbPad
            // 
            this.cbPad.Location = new System.Drawing.Point(167, 343);
            this.cbPad.Name = "cbPad";
            this.cbPad.Properties.Caption = "加零";
            this.cbPad.Size = new System.Drawing.Size(57, 19);
            this.cbPad.TabIndex = 22;
            this.cbPad.Click += new System.EventHandler(this.cbPad_Click);
            // 
            // cbThou
            // 
            this.cbThou.Location = new System.Drawing.Point(8, 343);
            this.cbThou.Name = "cbThou";
            this.cbThou.Properties.Caption = "显示千分位分隔符";
            this.cbThou.Size = new System.Drawing.Size(150, 19);
            this.cbThou.TabIndex = 21;
            this.cbThou.Click += new System.EventHandler(this.cbThou_Click);
            // 
            // btNSymbol
            // 
            this.btNSymbol.Location = new System.Drawing.Point(197, 100);
            this.btNSymbol.Name = "btNSymbol";
            this.btNSymbol.Size = new System.Drawing.Size(87, 27);
            this.btNSymbol.TabIndex = 20;
            this.btNSymbol.Text = "符号";
            this.btNSymbol.Click += new System.EventHandler(this.btNSymbol_Click);
            // 
            // nudNGap
            // 
            this.nudNGap.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudNGap.Location = new System.Drawing.Point(72, 103);
            this.nudNGap.Name = "nudNGap";
            this.nudNGap.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.nudNGap.Size = new System.Drawing.Size(117, 20);
            this.nudNGap.TabIndex = 19;
            this.nudNGap.ValueChanged += new System.EventHandler(this.nudNGap_ValueChanged);
            // 
            // cbNPos
            // 
            this.cbNPos.Location = new System.Drawing.Point(72, 65);
            this.cbNPos.Name = "cbNPos";
            this.cbNPos.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbNPos.Properties.Items.AddRange(new object[] {
            "比例栏的上面",
            "与比例栏顶部对齐",
            "比例栏的中央",
            "与比例栏底部对齐",
            "比例栏的下面"});
            this.cbNPos.Size = new System.Drawing.Size(212, 20);
            this.cbNPos.TabIndex = 18;
            this.cbNPos.SelectedIndexChanged += new System.EventHandler(this.cbNPos_SelectedIndexChanged);
            // 
            // lbNGap
            // 
            this.lbNGap.Location = new System.Drawing.Point(8, 106);
            this.lbNGap.Name = "lbNGap";
            this.lbNGap.Size = new System.Drawing.Size(52, 14);
            this.lbNGap.TabIndex = 17;
            this.lbNGap.Text = "距比例栏:";
            // 
            // lbNPos
            // 
            this.lbNPos.Location = new System.Drawing.Point(8, 65);
            this.lbNPos.Name = "lbNPos";
            this.lbNPos.Size = new System.Drawing.Size(52, 14);
            this.lbNPos.TabIndex = 16;
            this.lbNPos.Text = "标注位置:";
            // 
            // comboBox1
            // 
            this.comboBox1.Location = new System.Drawing.Point(72, 23);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBox1.Properties.Items.AddRange(new object[] {
            "无标注",
            "一个标注",
            "零刻度和末尾标注",
            "一个分划一个标注",
            "一个分划一个标注及第一分划中点处标注",
            "一个分划一个标注及第一细分处标注",
            "一个分划一个标注及所有细分处标注"});
            this.comboBox1.Size = new System.Drawing.Size(212, 20);
            this.comboBox1.TabIndex = 15;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // lbFre
            // 
            this.lbFre.Location = new System.Drawing.Point(8, 27);
            this.lbFre.Name = "lbFre";
            this.lbFre.Size = new System.Drawing.Size(52, 14);
            this.lbFre.TabIndex = 14;
            this.lbFre.Text = "标注风格:";
            // 
            // gbNAlign
            // 
            this.gbNAlign.Controls.Add(this.lbChar);
            this.gbNAlign.Controls.Add(this.nudAlign);
            this.gbNAlign.Controls.Add(this.rgAlignment);
            this.gbNAlign.Location = new System.Drawing.Point(8, 250);
            this.gbNAlign.Name = "gbNAlign";
            this.gbNAlign.Size = new System.Drawing.Size(281, 82);
            this.gbNAlign.TabIndex = 9;
            this.gbNAlign.TabStop = false;
            this.gbNAlign.Text = "对齐";
            // 
            // lbChar
            // 
            this.lbChar.Location = new System.Drawing.Point(188, 37);
            this.lbChar.Name = "lbChar";
            this.lbChar.Size = new System.Drawing.Size(24, 14);
            this.lbChar.TabIndex = 8;
            this.lbChar.Text = "字符";
            // 
            // nudAlign
            // 
            this.nudAlign.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudAlign.Location = new System.Drawing.Point(104, 34);
            this.nudAlign.Name = "nudAlign";
            this.nudAlign.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.nudAlign.Size = new System.Drawing.Size(77, 20);
            this.nudAlign.TabIndex = 7;
            this.nudAlign.ValueChanged += new System.EventHandler(this.nudAlign_ValueChanged);
            // 
            // rgAlignment
            // 
            this.rgAlignment.Location = new System.Drawing.Point(8, 17);
            this.rgAlignment.Name = "rgAlignment";
            this.rgAlignment.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.rgAlignment.Properties.Appearance.Options.UseBackColor = true;
            this.rgAlignment.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.rgAlignment.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "左对齐"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "右对齐")});
            this.rgAlignment.Size = new System.Drawing.Size(76, 57);
            this.rgAlignment.TabIndex = 6;
            this.rgAlignment.SelectedIndexChanged += new System.EventHandler(this.rgAlignment_SelectedIndexChanged);
            // 
            // gbNRounding
            // 
            this.gbNRounding.Controls.Add(this.nudRounding);
            this.gbNRounding.Controls.Add(this.rgRound);
            this.gbNRounding.Location = new System.Drawing.Point(8, 154);
            this.gbNRounding.Name = "gbNRounding";
            this.gbNRounding.Size = new System.Drawing.Size(281, 89);
            this.gbNRounding.TabIndex = 8;
            this.gbNRounding.TabStop = false;
            this.gbNRounding.Text = "舍入";
            this.gbNRounding.UseCompatibleTextRendering = true;
            // 
            // nudRounding
            // 
            this.nudRounding.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudRounding.Location = new System.Drawing.Point(104, 43);
            this.nudRounding.Name = "nudRounding";
            this.nudRounding.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.nudRounding.Size = new System.Drawing.Size(77, 20);
            this.nudRounding.TabIndex = 4;
            this.nudRounding.ValueChanged += new System.EventHandler(this.nudRounding_ValueChanged);
            // 
            // rgRound
            // 
            this.rgRound.Location = new System.Drawing.Point(8, 23);
            this.rgRound.Name = "rgRound";
            this.rgRound.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.rgRound.Properties.Appearance.Options.UseBackColor = true;
            this.rgRound.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.rgRound.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "小数位数"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "有效位数")});
            this.rgRound.Size = new System.Drawing.Size(89, 58);
            this.rgRound.TabIndex = 3;
            this.rgRound.SelectedIndexChanged += new System.EventHandler(this.rgRound_SelectedIndexChanged);
            // 
            // xtpSUnit
            // 
            this.xtpSUnit.Controls.Add(this.gbUnit);
            this.xtpSUnit.Controls.Add(this.gbScale);
            this.xtpSUnit.Name = "xtpSUnit";
            this.xtpSUnit.Size = new System.Drawing.Size(581, 428);
            this.xtpSUnit.Text = "比例尺和单位";
            // 
            // gbUnit
            // 
            this.gbUnit.Controls.Add(this.nudUGap);
            this.gbUnit.Controls.Add(this.btUSymbol);
            this.gbUnit.Controls.Add(this.txtUCon);
            this.gbUnit.Controls.Add(this.cbUPos);
            this.gbUnit.Controls.Add(this.cbUnit);
            this.gbUnit.Controls.Add(this.lbUGap);
            this.gbUnit.Controls.Add(this.lbLabel);
            this.gbUnit.Controls.Add(this.lbUPos);
            this.gbUnit.Controls.Add(this.lbDUnit);
            this.gbUnit.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbUnit.Location = new System.Drawing.Point(0, 224);
            this.gbUnit.Name = "gbUnit";
            this.gbUnit.Size = new System.Drawing.Size(581, 184);
            this.gbUnit.TabIndex = 3;
            this.gbUnit.TabStop = false;
            this.gbUnit.Text = "单位";
            // 
            // nudUGap
            // 
            this.nudUGap.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudUGap.Location = new System.Drawing.Point(128, 147);
            this.nudUGap.Name = "nudUGap";
            this.nudUGap.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.nudUGap.Size = new System.Drawing.Size(147, 20);
            this.nudUGap.TabIndex = 17;
            this.nudUGap.ValueChanged += new System.EventHandler(this.nudUGap_ValueChanged);
            // 
            // btUSymbol
            // 
            this.btUSymbol.Location = new System.Drawing.Point(259, 104);
            this.btUSymbol.Name = "btUSymbol";
            this.btUSymbol.Size = new System.Drawing.Size(87, 27);
            this.btUSymbol.TabIndex = 16;
            this.btUSymbol.Text = "符号";
            this.btUSymbol.Click += new System.EventHandler(this.btUSymbol_Click);
            // 
            // txtUCon
            // 
            this.txtUCon.Location = new System.Drawing.Point(106, 105);
            this.txtUCon.Name = "txtUCon";
            this.txtUCon.Size = new System.Drawing.Size(146, 20);
            this.txtUCon.TabIndex = 15;
            this.txtUCon.Leave += new System.EventHandler(this.txtUCon_Leave);
            // 
            // cbUPos
            // 
            this.cbUPos.Location = new System.Drawing.Point(105, 63);
            this.cbUPos.Name = "cbUPos";
            this.cbUPos.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbUPos.Properties.Items.AddRange(new object[] {
            "数字标注前面",
            "数字标注后面",
            "比例栏前面",
            "比例栏后面",
            "比例栏上面",
            "比例栏下面"});
            this.cbUPos.Size = new System.Drawing.Size(147, 20);
            this.cbUPos.TabIndex = 14;
            this.cbUPos.SelectedIndexChanged += new System.EventHandler(this.cbUPos_SelectedIndexChanged);
            // 
            // cbUnit
            // 
            this.cbUnit.Location = new System.Drawing.Point(105, 21);
            this.cbUnit.Name = "cbUnit";
            this.cbUnit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbUnit.Properties.Items.AddRange(new object[] {
            "英寸",
            "像素",
            "英尺",
            "码",
            "英里",
            "海里",
            "毫米",
            "厘米",
            "米",
            "千米",
            "十进制度",
            "分米",
            "未知单位"});
            this.cbUnit.Size = new System.Drawing.Size(147, 20);
            this.cbUnit.TabIndex = 13;
            this.cbUnit.SelectedIndexChanged += new System.EventHandler(this.cbUnit_SelectedIndexChanged);
            // 
            // lbUGap
            // 
            this.lbUGap.Location = new System.Drawing.Point(5, 150);
            this.lbUGap.Name = "lbUGap";
            this.lbUGap.Size = new System.Drawing.Size(100, 14);
            this.lbUGap.TabIndex = 12;
            this.lbUGap.Text = "与比例尺图形距离:";
            // 
            // lbLabel
            // 
            this.lbLabel.Location = new System.Drawing.Point(65, 108);
            this.lbLabel.Name = "lbLabel";
            this.lbLabel.Size = new System.Drawing.Size(28, 14);
            this.lbLabel.TabIndex = 11;
            this.lbLabel.Text = "标记:";
            // 
            // lbUPos
            // 
            this.lbUPos.Location = new System.Drawing.Point(37, 66);
            this.lbUPos.Name = "lbUPos";
            this.lbUPos.Size = new System.Drawing.Size(52, 14);
            this.lbUPos.TabIndex = 10;
            this.lbUPos.Text = "标记位置:";
            // 
            // lbDUnit
            // 
            this.lbDUnit.Location = new System.Drawing.Point(37, 24);
            this.lbDUnit.Name = "lbDUnit";
            this.lbDUnit.Size = new System.Drawing.Size(52, 14);
            this.lbDUnit.TabIndex = 9;
            this.lbDUnit.Text = "分划单位:";
            // 
            // gbScale
            // 
            this.gbScale.Controls.Add(this.cbZero);
            this.gbScale.Controls.Add(this.cbAdjustW);
            this.gbScale.Controls.Add(this.nudSD);
            this.gbScale.Controls.Add(this.nudD);
            this.gbScale.Controls.Add(this.tbDValue);
            this.gbScale.Controls.Add(this.lbDivUnit);
            this.gbScale.Controls.Add(this.lbAdjusW);
            this.gbScale.Controls.Add(this.lbSub);
            this.gbScale.Controls.Add(this.lbDn);
            this.gbScale.Controls.Add(this.lbDValue);
            this.gbScale.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbScale.Location = new System.Drawing.Point(0, 0);
            this.gbScale.Name = "gbScale";
            this.gbScale.Size = new System.Drawing.Size(581, 224);
            this.gbScale.TabIndex = 2;
            this.gbScale.TabStop = false;
            this.gbScale.Text = "比例尺";
            // 
            // cbZero
            // 
            this.cbZero.Location = new System.Drawing.Point(104, 199);
            this.cbZero.Name = "cbZero";
            this.cbZero.Properties.Caption = "在零刻度前显示一个分划";
            this.cbZero.Size = new System.Drawing.Size(185, 19);
            this.cbZero.TabIndex = 20;
            this.cbZero.Click += new System.EventHandler(this.cbZero_Click);
            // 
            // cbAdjustW
            // 
            this.cbAdjustW.Location = new System.Drawing.Point(106, 168);
            this.cbAdjustW.Name = "cbAdjustW";
            this.cbAdjustW.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbAdjustW.Properties.Items.AddRange(new object[] {
            "指定分划宽度",
            "分划值等比例变化",
            "改变分划数量"});
            this.cbAdjustW.Size = new System.Drawing.Size(146, 20);
            this.cbAdjustW.TabIndex = 19;
            this.cbAdjustW.SelectedIndexChanged += new System.EventHandler(this.cbAdjustW_SelectedIndexChanged);
            // 
            // nudSD
            // 
            this.nudSD.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudSD.Location = new System.Drawing.Point(105, 100);
            this.nudSD.Name = "nudSD";
            this.nudSD.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.nudSD.Size = new System.Drawing.Size(147, 20);
            this.nudSD.TabIndex = 18;
            this.nudSD.ValueChanged += new System.EventHandler(this.nudSD_ValueChanged);
            // 
            // nudD
            // 
            this.nudD.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudD.Location = new System.Drawing.Point(105, 63);
            this.nudD.Name = "nudD";
            this.nudD.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.nudD.Size = new System.Drawing.Size(147, 20);
            this.nudD.TabIndex = 17;
            this.nudD.ValueChanged += new System.EventHandler(this.nudD_ValueChanged);
            // 
            // tbDValue
            // 
            this.tbDValue.Location = new System.Drawing.Point(105, 24);
            this.tbDValue.Name = "tbDValue";
            this.tbDValue.Size = new System.Drawing.Size(147, 20);
            this.tbDValue.TabIndex = 16;
            this.tbDValue.TextChanged += new System.EventHandler(this.tbDValue_TextChanged);
            // 
            // lbDivUnit
            // 
            this.lbDivUnit.Location = new System.Drawing.Point(259, 29);
            this.lbDivUnit.Name = "lbDivUnit";
            this.lbDivUnit.Size = new System.Drawing.Size(14, 14);
            this.lbDivUnit.TabIndex = 15;
            this.lbDivUnit.Text = "dd";
            // 
            // lbAdjusW
            // 
            this.lbAdjusW.Location = new System.Drawing.Point(23, 142);
            this.lbAdjusW.Name = "lbAdjusW";
            this.lbAdjusW.Size = new System.Drawing.Size(184, 14);
            this.lbAdjusW.TabIndex = 14;
            this.lbAdjusW.Text = "分划如何随比例尺宽度变化而变化:";
            // 
            // lbSub
            // 
            this.lbSub.Location = new System.Drawing.Point(37, 100);
            this.lbSub.Name = "lbSub";
            this.lbSub.Size = new System.Drawing.Size(52, 14);
            this.lbSub.TabIndex = 13;
            this.lbSub.Text = "细分数量:";
            // 
            // lbDn
            // 
            this.lbDn.Location = new System.Drawing.Point(37, 63);
            this.lbDn.Name = "lbDn";
            this.lbDn.Size = new System.Drawing.Size(52, 14);
            this.lbDn.TabIndex = 12;
            this.lbDn.Text = "分划数量:";
            // 
            // lbDValue
            // 
            this.lbDValue.Location = new System.Drawing.Point(23, 29);
            this.lbDValue.Name = "lbDValue";
            this.lbDValue.Size = new System.Drawing.Size(64, 14);
            this.lbDValue.TabIndex = 11;
            this.lbDValue.Text = "单位分化值:";
            // 
            // xtpSymbol
            // 
            this.xtpSymbol.Controls.Add(this.ilbcScale);
            this.xtpSymbol.Name = "xtpSymbol";
            this.xtpSymbol.Size = new System.Drawing.Size(581, 428);
            this.xtpSymbol.Text = "符号";
            // 
            // ilbcScale
            // 
            this.ilbcScale.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ilbcScale.ImageList = this.imageList;
            this.ilbcScale.Location = new System.Drawing.Point(0, 0);
            this.ilbcScale.Name = "ilbcScale";
            this.ilbcScale.Size = new System.Drawing.Size(581, 428);
            this.ilbcScale.TabIndex = 0;
            this.ilbcScale.SelectedIndexChanged += new System.EventHandler(this.ilbcScale_SelectedIndexChanged);
            // 
            // xtcScale
            // 
            this.xtcScale.Dock = System.Windows.Forms.DockStyle.Top;
            this.xtcScale.Location = new System.Drawing.Point(0, 0);
            this.xtcScale.Name = "xtcScale";
            this.xtcScale.SelectedTabPage = this.xtpSymbol;
            this.xtcScale.Size = new System.Drawing.Size(587, 457);
            this.xtcScale.TabIndex = 0;
            this.xtcScale.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtpSymbol,
            this.xtpSUnit,
            this.xtpDataTick,
            this.xtpSBar,
            this.xtpFrame});
            this.xtcScale.SelectedPageChanged += new DevExpress.XtraTab.TabPageChangedEventHandler(this.xtcScale_SelectedPageChanged);
            // 
            // DevScaleBar
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.Appearance.BackColor2 = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(587, 505);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btOk);
            this.Controls.Add(this.xtcScale);
            this.LookAndFeel.SkinName = "Blue";
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DevScaleBar";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "比例尺";
            this.xtpFrame.ResumeLayout(false);
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
            this.xtpDataTick.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.gbMark.ResumeLayout(false);
            this.gbMark.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown5.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDHeight.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbMPos.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbMStyle.Properties)).EndInit();
            this.gbNumber.ResumeLayout(false);
            this.gbNumber.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbPlug.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbPad.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbThou.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNGap.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbNPos.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBox1.Properties)).EndInit();
            this.gbNAlign.ResumeLayout(false);
            this.gbNAlign.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAlign.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgAlignment.Properties)).EndInit();
            this.gbNRounding.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudRounding.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgRound.Properties)).EndInit();
            this.xtpSUnit.ResumeLayout(false);
            this.gbUnit.ResumeLayout(false);
            this.gbUnit.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudUGap.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUCon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbUPos.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbUnit.Properties)).EndInit();
            this.gbScale.ResumeLayout(false);
            this.gbScale.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbZero.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbAdjustW.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSD.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudD.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbDValue.Properties)).EndInit();
            this.xtpSymbol.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ilbcScale)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtcScale)).EndInit();
            this.xtcScale.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private void MControlCheck(bool pEnable)
        {
            this.cbMPos.Enabled = pEnable;
            this.nudDHeight.Enabled = pEnable;
            this.numericUpDown5.Enabled = pEnable;
            this.btSymbol.Enabled = pEnable;
            this.btSDSymbol.Enabled = pEnable;
        }

        private void NControlChecked(bool pEnable)
        {
            this.cbNPos.Enabled = pEnable;
            this.nudNGap.Enabled = pEnable;
            this.btNSymbol.Enabled = pEnable;
            this.gbNRounding.Enabled = pEnable;
            this.gbNAlign.Enabled = pEnable;
            this.cbThou.Enabled = pEnable;
            this.cbPad.Enabled = pEnable;
            this.cbPlug.Enabled = pEnable;
        }

        private void nudAlign_ValueChanged(object sender, EventArgs e)
        {
            if (!this.init)
            {
                INumericFormat numberFormat = (INumericFormat) this._scaleBar.NumberFormat;
                numberFormat.AlignmentWidth = int.Parse(this.nudAlign.Value.ToString());
                this._scaleBar.NumberFormat = (INumberFormat) numberFormat;
            }
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
                border.CornerRounding = short.Parse(this.nudBorderX.Value.ToString());
                Bitmap bitmap = BitmapManager.GetSymbolBitMap(this.border, this.pbBorder.Width, this.pbBorder.Height);
                this.pbBorder.Image = bitmap;
            }
        }

        private void nudBorderY_ValueChanged(object sender, EventArgs e)
        {
            if (!this.init && (this.border != null))
            {
                IFrameDecoration border = (IFrameDecoration) this.border;
                border.CornerRounding = short.Parse(this.nudBorderX.Value.ToString());
                Bitmap bitmap = BitmapManager.GetSymbolBitMap(this.border, this.pbBorder.Width, this.pbBorder.Height);
                this.pbBorder.Image = bitmap;
            }
        }

        private void nudD_ValueChanged(object sender, EventArgs e)
        {
            if (!this.init)
            {
                this._scaleBar.Divisions = short.Parse(this.nudD.Value.ToString());
            }
        }

        private void nudDHeight_ValueChanged(object sender, EventArgs e)
        {
            if (!this.init)
            {
                IScaleMarks marks = (IScaleMarks) this._scaleBar;
                marks.DivisionMarkHeight = double.Parse(this.nudDHeight.Value.ToString());
            }
        }

        private void nudNGap_ValueChanged(object sender, EventArgs e)
        {
            if (!this.init)
            {
                this._scaleBar.LabelGap = double.Parse(this.nudNGap.Value.ToString());
            }
        }

        private void nudRounding_ValueChanged(object sender, EventArgs e)
        {
            if (!this.init)
            {
                INumericFormat numberFormat = (INumericFormat) this._scaleBar.NumberFormat;
                numberFormat.RoundingValue = int.Parse(this.nudRounding.Value.ToString());
                this._scaleBar.NumberFormat = (INumberFormat) numberFormat;
            }
        }

        private void nudSD_ValueChanged(object sender, EventArgs e)
        {
            if (!this.init)
            {
                this._scaleBar.Subdivisions = short.Parse(this.nudSD.Value.ToString());
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
                shadow.HorizontalSpacing = short.Parse(this.nudShadowX.Value.ToString());
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

        private void nudUGap_ValueChanged(object sender, EventArgs e)
        {
            if (!this.init)
            {
                this._scaleBar.UnitLabelGap = double.Parse(this.nudUGap.Value.ToString());
            }
        }

        private void numericUpDown5_ValueChanged(object sender, EventArgs e)
        {
            if (!this.init)
            {
                IScaleMarks marks = (IScaleMarks) this._scaleBar;
                marks.SubdivisionMarkHeight = double.Parse(this.numericUpDown5.Value.ToString());
            }
        }

        private void rgAlignment_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this.init)
            {
                if (this.rgAlignment.SelectedIndex == 0)
                {
                    INumericFormat numberFormat = (INumericFormat) this._scaleBar.NumberFormat;
                    numberFormat.AlignmentOption = esriNumericAlignmentEnum.esriAlignLeft;
                    this.nudAlign.Enabled = false;
                    this._scaleBar.NumberFormat = (INumberFormat) numberFormat;
                }
                else
                {
                    INumericFormat format2 = (INumericFormat) this._scaleBar.NumberFormat;
                    format2.AlignmentOption = esriNumericAlignmentEnum.esriAlignRight;
                    this.nudAlign.Enabled = true;
                    this._scaleBar.NumberFormat = (INumberFormat) format2;
                }
            }
        }

        private void rgRound_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this.init)
            {
                if (this.rgRound.SelectedIndex == 0)
                {
                    INumericFormat numberFormat = (INumericFormat) this._scaleBar.NumberFormat;
                    numberFormat.RoundingOption = esriRoundingOptionEnum.esriRoundNumberOfDecimals;
                    this._scaleBar.NumberFormat = (INumberFormat) numberFormat;
                }
                else
                {
                    INumericFormat format2 = (INumericFormat) this._scaleBar.NumberFormat;
                    format2.RoundingOption = esriRoundingOptionEnum.esriRoundNumberOfSignificantDigits;
                    this._scaleBar.NumberFormat = (INumberFormat) format2;
                }
            }
        }

        private void tbDValue_TextChanged(object sender, EventArgs e)
        {
            if (!this.init && (this.tbDValue.Text != "自动"))
            {
                this._scaleBar.Division = double.Parse(this.tbDValue.Text);
            }
        }

        private void txtUCon_Leave(object sender, EventArgs e)
        {
            if (!this.init)
            {
                this._scaleBar.UnitLabel = this.txtUCon.Text;
                this.cbUnit.Text = this.txtUCon.Text;
            }
        }

        private void xtcScale_SelectedPageChanged(object sender, TabPageChangedEventArgs e)
        {
            if (!this.init && !(this._scaleBar is IDoubleFillScaleBar))
            {
                this.btBSymbolS.Enabled = false;
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

