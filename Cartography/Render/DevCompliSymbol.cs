namespace Cartography.Render
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
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Utilities;

    public class DevCompliSymbol : FormBase3
    {
        private ColorEdit ceBorderColor;
        private ColorEdit ceFillColor;
        private ColorEdit ceLineColor;
        private ColorEdit cePointColor;
        private CheckedListBoxControl checkedListBoxLayers;
        private ComboBoxEdit comboBoxType;
        private IContainer components;
        private GroupBox gbAreaSet;
        private GroupBox gbLineSet;
        private GroupBox gbPointSet;
        private GroupBox groupBox1;
        private GroupBox groupBox3;
        private ImageList imageList1;
        private ImageListBoxControl imageListBoxLayers;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label lbAngle;
        private Label lbFillColor;
        private Label lbOutLineColor;
        private Label lbOutLineWidth;
        private Label lbPointColor;
        private Label lbPointSize;
        private bool m_bCreate;
        private ISymbol m_SelectedSymbol;
        private ISymbol m_Symbol;
        private int m_SymbolType;
        private const string mClassName = "Cartography.Render.DevCompliSymbol";
        private ErrorOpt mErrOpt = UtilFactory.GetErrorOpt();
        private string mSubSysName = UtilFactory.GetConfigOpt().GetSystemName();
        private SpinEdit nudLineWidth;
        private SpinEdit nudOutLine;
        private SpinEdit nudPointAngle;
        private SpinEdit nudPointSize;
        private Panel panel1;
        private PanelControl panelControl1;
        private PanelControl panelControl2;
        private PanelControl panelControl3;
        private PanelControl panelControl4;
        private PanelControl panelControlType;
        private PanelControl panelSymbolList;
        private PictureEdit picturePreView;
        private SimpleButton simpleButtonAddlayer;
        private SimpleButton simpleButtonCancel;
        private SimpleButton simpleButtonDeleteLayer;
        private SimpleButton simpleButtonLine;
        private SimpleButton simpleButtonMarker;
        private SimpleButton simpleButtonMoveDown;
        private SimpleButton simpleButtonMoveUp;
        private SimpleButton simpleButtonOK;
        private SimpleButton simpleButtonOutline;

        public DevCompliSymbol()
        {
            this.InitializeComponent();
        }

        private void ceBorderColor_ColorChanged(object sender, EventArgs e)
        {
            IFillSymbol selectedSymbol = (IFillSymbol) this.m_SelectedSymbol;
            ESRI.ArcGIS.esriSystem.IPersist outline = selectedSymbol.Outline as ESRI.ArcGIS.esriSystem.IPersist;
            Guid pClassID = new Guid();
            outline.GetClassID(out pClassID);
            System.Type.GetTypeFromCLSID(pClassID);
            ILineSymbol symbol2 = selectedSymbol.Outline;
            IColor color = ColorService.NetColorToEsriColor(this.ceBorderColor.Color);
            symbol2.Color = color;
            selectedSymbol.Outline = symbol2;
            this.PreviewChildImage();
        }

        private void ceFillColor_ColorChanged(object sender, EventArgs e)
        {
            IFillSymbol selectedSymbol = (IFillSymbol) this.m_SelectedSymbol;
            IColor color = ColorService.NetColorToEsriColor(this.ceFillColor.Color);
            selectedSymbol.Color = color;
            this.PreviewChildImage();
        }

        private void ceLineColor_ColorChanged(object sender, EventArgs e)
        {
            ILineSymbol selectedSymbol = (ILineSymbol) this.m_SelectedSymbol;
            IColor color = ColorService.NetColorToEsriColor(this.ceLineColor.Color);
            selectedSymbol.Color = color;
            this.PreviewChildImage();
        }

        private void cePointColor_ColorChanged(object sender, EventArgs e)
        {
            IMarkerSymbol selectedSymbol = (IMarkerSymbol) this.m_SelectedSymbol;
            IColor color = ColorService.NetColorToEsriColor(this.cePointColor.Color);
            selectedSymbol.Color = color;
            this.PreviewChildImage();
        }

        private void comboBoxType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.m_bCreate && (this.imageListBoxLayers.SelectedIndex >= 0))
            {
                int selectedIndex = this.comboBoxType.SelectedIndex;
                if (this.m_SymbolType == 1)
                {
                    switch (selectedIndex)
                    {
                        case 0:
                            this.m_SelectedSymbol = this.CreateDefaultSymbol();
                            break;

                        case 1:
                            this.m_SelectedSymbol = this.CreateArrowSymbol();
                            break;
                    }
                }
                else if (this.m_SymbolType == 2)
                {
                    switch (selectedIndex)
                    {
                        case 0:
                            this.m_SelectedSymbol = this.CreateDefaultSymbol();
                            break;

                        case 1:
                            this.m_SelectedSymbol = this.CreateCartoLineSymbol();
                            break;

                        case 2:
                            this.m_SelectedSymbol = this.CreateMatkerLineSymbol();
                            break;
                    }
                }
                else if (this.m_SymbolType == 3)
                {
                    switch (selectedIndex)
                    {
                        case 0:
                            this.m_SelectedSymbol = this.CreateDefaultSymbol();
                            break;

                        case 1:
                            this.m_SelectedSymbol = this.CreateLineFillSymbol();
                            break;

                        case 2:
                            this.m_SelectedSymbol = this.CreateMatkerFillSymbol();
                            break;
                    }
                }
                this.RefreshSymbol();
                this.PreviewChildImage();
                this.RefreshProperty();
            }
        }

        private ISymbol CreateArrowSymbol()
        {
            IArrowMarkerSymbol symbol2 = new ArrowMarkerSymbolClass();
            symbol2.Color = this.GetRGBColor(60, 100, 50);
            symbol2.Length = 10.0;
            symbol2.Width = 8.0;
            symbol2.Style = esriArrowMarkerStyle.esriAMSPlain;
            return (ISymbol) symbol2;
        }

        private ISymbol CreateCartoLineSymbol()
        {
            ICartographicLineSymbol symbol2 = new CartographicLineSymbolClass();
            symbol2.Width = 2.0;
            symbol2.Color = this.GetRGBColor(60, 100, 50);
            return (ISymbol) symbol2;
        }

        private ISymbol CreateDefaultSymbol()
        {
            ISymbol symbol = null;
            if (this.m_SymbolType == 1)
            {
                return this.CreateSimpleMarkerSymbol();
            }
            if (this.m_SymbolType == 2)
            {
                return this.CreateSimpleLineSymbol();
            }
            if (this.m_SymbolType == 3)
            {
                symbol = this.CreateSimpleFillSymbol();
            }
            return symbol;
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

        private ISymbol CreateLineFillSymbol()
        {
            ILineFillSymbol symbol2 = new LineFillSymbolClass();
            symbol2.Color = this.GetRGBColor(60, 100, 50);
            symbol2.LineSymbol = this.CreateSimpleLineSymbol() as ILineSymbol;
            symbol2.Outline = this.CreateSimpleLineSymbol() as ILineSymbol;
            return (ISymbol) symbol2;
        }

        private ISymbol CreateMatkerFillSymbol()
        {
            IMarkerFillSymbol symbol2 = new MarkerFillSymbolClass();
            symbol2.Color = this.GetRGBColor(60, 100, 50);
            IMarkerSymbol symbol3 = this.CreateSimpleMarkerSymbol() as IMarkerSymbol;
            symbol2.MarkerSymbol = symbol3;
            ILineSymbol symbol4 = this.CreateSimpleLineSymbol() as ILineSymbol;
            symbol2.Outline = symbol4;
            symbol2.Style = esriMarkerFillStyle.esriMFSGrid;
            return (ISymbol) symbol2;
        }

        private ISymbol CreateMatkerLineSymbol()
        {
            IMarkerLineSymbol symbol2 = new MarkerLineSymbolClass();
            IMarkerSymbol symbol3 = this.CreateSimpleMarkerSymbol() as IMarkerSymbol;
            symbol2.MarkerSymbol = symbol3;
            symbol2.Color = this.GetRGBColor(60, 100, 50);
            return (ISymbol) symbol2;
        }

        private ISymbol CreateSimpleFillSymbol()
        {
            ISimpleLineSymbol symbol2 = new SimpleLineSymbolClass();
            symbol2.Style = esriSimpleLineStyle.esriSLSSolid;
            symbol2.Color = this.GetRGBColor(60, 100, 50);
            symbol2.Width = 1.0;
            ISimpleFillSymbol symbol3 = new SimpleFillSymbolClass();
            symbol3.Style = esriSimpleFillStyle.esriSFSSolid;
            IRgbColor color = new RgbColorClass();
            color.NullColor = true;
            symbol3.Color = color;
            symbol3.Outline = symbol2;
            return (ISymbol) symbol3;
        }

        private ISymbol CreateSimpleLineSymbol()
        {
            ISimpleLineSymbol symbol2 = new SimpleLineSymbolClass();
            symbol2.Style = esriSimpleLineStyle.esriSLSSolid;
            symbol2.Color = this.GetRGBColor(60, 100, 50);
            symbol2.Width = 1.0;
            return (ISymbol) symbol2;
        }

        private ISymbol CreateSimpleMarkerSymbol()
        {
            ISimpleMarkerSymbol symbol2 = new SimpleMarkerSymbolClass();
            symbol2.Style = esriSimpleMarkerStyle.esriSMSCross;
            symbol2.Color = this.GetRGBColor(60, 100, 50);
            symbol2.Angle = 60.0;
            symbol2.XOffset = 10.0;
            symbol2.YOffset = 10.0;
            return (ISymbol) symbol2;
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

        private void DevSymbolSelector_Load(object sender, EventArgs e)
        {
            this.m_bCreate = false;
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

        public ISymbol GetItem(esriGeometryType pGeometryType, ISymbol pSymbol)
        {
            this.m_Symbol = null;
            IClone clone = (IClone) pSymbol;
            ISymbol symbol = clone.Clone() as ISymbol;
            this.m_Symbol = symbol;
            if (pGeometryType == esriGeometryType.esriGeometryPoint)
            {
                this.m_SymbolType = 1;
            }
            else if ((pGeometryType != esriGeometryType.esriGeometryLine) && (pGeometryType != esriGeometryType.esriGeometryPolyline))
            {
                if (pGeometryType == esriGeometryType.esriGeometryPolygon)
                {
                    this.m_SymbolType = 3;
                }
            }
            else
            {
                this.m_SymbolType = 2;
            }
            this.comboBoxType.Properties.Items.Clear();
            if (this.m_SymbolType == 1)
            {
                this.comboBoxType.Properties.Items.Add("简单点符号");
            }
            else if (this.m_SymbolType == 2)
            {
                this.comboBoxType.Properties.Items.Add("简单线符号");
                this.comboBoxType.Properties.Items.Add("实心或虚线线符号");
                this.comboBoxType.Properties.Items.Add("点线符号");
            }
            else if (this.m_SymbolType == 3)
            {
                this.comboBoxType.Properties.Items.Add("简单填充符号");
                this.comboBoxType.Properties.Items.Add("包含线符号的填充符号");
                this.comboBoxType.Properties.Items.Add("包含点符号的填充符号");
            }
            this.m_bCreate = false;
            this.InitalControl(0);
            this.m_bCreate = true;
            base.ShowDialog();
            return this.m_Symbol;
        }

        private IRgbColor GetRGBColor(int red, int green, int blue)
        {
            IRgbColor color = new RgbColorClass();
            color.Red = red;
            color.Green = green;
            color.Blue = blue;
            return color;
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
                else if (!(pSymbol is ITextSymbol) && (pSymbol is IScaleBar))
                {
                    iWidth = Convert.ToInt32((double) (iWidth * 1.75));
                }
                Image image = null;
                if (symbol != null)
                {
                    image = this.CreateImageFromSymbol(symbol, iWidth, iHeight, pBackColor, iGap);
                }
                return image;
            }
            catch (Exception)
            {
                return null;
            }
        }

        private void imageListBoxLayers_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.simpleButtonMarker.Visible = false;
            this.simpleButtonLine.Visible = false;
            this.simpleButtonOutline.Visible = false;
            int selectedIndex = this.imageListBoxLayers.SelectedIndex;
            if (selectedIndex < 0)
            {
                this.m_SelectedSymbol = null;
            }
            else
            {
                this.m_bCreate = false;
                ISymbol symbol = null;
                if (this.m_SymbolType == 1)
                {
                    IMultiLayerMarkerSymbol symbol2 = (IMultiLayerMarkerSymbol) this.m_Symbol;
                    symbol = symbol2.get_Layer(selectedIndex) as ISymbol;
                }
                else if (this.m_SymbolType == 2)
                {
                    IMultiLayerLineSymbol symbol3 = (IMultiLayerLineSymbol) this.m_Symbol;
                    symbol = symbol3.get_Layer(selectedIndex) as ISymbol;
                }
                else if (this.m_SymbolType == 3)
                {
                    IMultiLayerFillSymbol symbol4 = (IMultiLayerFillSymbol) this.m_Symbol;
                    symbol = symbol4.get_Layer(selectedIndex) as ISymbol;
                }
                this.m_SelectedSymbol = symbol;
                if (symbol is SimpleMarkerSymbol)
                {
                    this.comboBoxType.SelectedIndex = 0;
                }
                else if (symbol is ArrowMarkerSymbol)
                {
                    this.comboBoxType.SelectedIndex = 1;
                }
                else if (symbol is SimpleLineSymbol)
                {
                    this.comboBoxType.SelectedIndex = 0;
                }
                else if (symbol is CartographicLineSymbol)
                {
                    this.comboBoxType.SelectedIndex = 1;
                }
                else if (symbol is MarkerLineSymbol)
                {
                    this.comboBoxType.SelectedIndex = 2;
                }
                else if (symbol is SimpleFillSymbol)
                {
                    this.comboBoxType.SelectedIndex = 0;
                }
                else if (symbol is LineFillSymbol)
                {
                    this.comboBoxType.SelectedIndex = 1;
                }
                else if (symbol is MarkerFillSymbol)
                {
                    this.comboBoxType.SelectedIndex = 2;
                }
                this.RefreshProperty();
                this.m_bCreate = true;
            }
        }

        private void InitalControl(int iSelectedIndex)
        {
            int iWidth = 0x80;
            int iHeight = 0x20;
            try
            {
                this.imageList1.Images.Clear();
                this.imageListBoxLayers.Items.Clear();
                if (this.m_SymbolType == 1)
                {
                    IMultiLayerMarkerSymbol symbol = (IMultiLayerMarkerSymbol) this.m_Symbol;
                    for (int i = 0; i < symbol.LayerCount; i++)
                    {
                        IMarkerSymbol pSymbol = symbol.get_Layer(i);
                        Image image = this.GetSymbolImage(pSymbol, iWidth, iHeight, Color.White, 1);
                        this.imageList1.Images.Add(image);
                        this.imageListBoxLayers.Items.Add("", i);
                    }
                }
                else if (this.m_SymbolType == 2)
                {
                    IMultiLayerLineSymbol symbol3 = (IMultiLayerLineSymbol) this.m_Symbol;
                    for (int j = 0; j < symbol3.LayerCount; j++)
                    {
                        ILineSymbol symbol4 = symbol3.get_Layer(j);
                        Image image2 = this.GetSymbolImage(symbol4, iWidth, iHeight, Color.White, 1);
                        this.imageList1.Images.Add(image2);
                        this.imageListBoxLayers.Items.Add("", j);
                    }
                }
                else
                {
                    if (this.m_SymbolType != 3)
                    {
                        return;
                    }
                    IMultiLayerFillSymbol symbol5 = (IMultiLayerFillSymbol) this.m_Symbol;
                    for (int k = 0; k < symbol5.LayerCount; k++)
                    {
                        IFillSymbol symbol6 = symbol5.get_Layer(k);
                        Image image3 = this.GetSymbolImage(symbol6, iWidth, iHeight, Color.White, 1);
                        this.imageList1.Images.Add(image3);
                        this.imageListBoxLayers.Items.Add("", k);
                    }
                }
                this.imageListBoxLayers.SelectedIndex = iSelectedIndex;
                this.PreviewImage(this.m_Symbol);
                if (this.m_SymbolType == 1)
                {
                    this.gbPointSet.Visible = true;
                    this.gbPointSet.BringToFront();
                    this.gbLineSet.Visible = false;
                    this.gbAreaSet.Visible = false;
                }
                else if (this.m_SymbolType == 2)
                {
                    this.gbLineSet.Visible = true;
                    this.gbLineSet.BringToFront();
                    this.gbPointSet.Visible = false;
                    this.gbAreaSet.Visible = false;
                }
                else if (this.m_SymbolType == 3)
                {
                    this.gbAreaSet.Visible = true;
                    this.gbAreaSet.BringToFront();
                    this.gbPointSet.Visible = false;
                    this.gbLineSet.Visible = false;
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "Cartography.Render.DevCompliSymbol", "InitalControl", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void InitializeComponent()
        {
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl4 = new DevExpress.XtraEditors.PanelControl();
            this.simpleButtonOutline = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.simpleButtonLine = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonMarker = new DevExpress.XtraEditors.SimpleButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.gbLineSet = new System.Windows.Forms.GroupBox();
            this.nudLineWidth = new DevExpress.XtraEditors.SpinEdit();
            this.ceLineColor = new DevExpress.XtraEditors.ColorEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.gbPointSet = new System.Windows.Forms.GroupBox();
            this.nudPointAngle = new DevExpress.XtraEditors.SpinEdit();
            this.nudPointSize = new DevExpress.XtraEditors.SpinEdit();
            this.cePointColor = new DevExpress.XtraEditors.ColorEdit();
            this.lbAngle = new System.Windows.Forms.Label();
            this.lbPointSize = new System.Windows.Forms.Label();
            this.lbPointColor = new System.Windows.Forms.Label();
            this.gbAreaSet = new System.Windows.Forms.GroupBox();
            this.ceBorderColor = new DevExpress.XtraEditors.ColorEdit();
            this.ceFillColor = new DevExpress.XtraEditors.ColorEdit();
            this.nudOutLine = new DevExpress.XtraEditors.SpinEdit();
            this.lbOutLineColor = new System.Windows.Forms.Label();
            this.lbOutLineWidth = new System.Windows.Forms.Label();
            this.lbFillColor = new System.Windows.Forms.Label();
            this.panelControlType = new DevExpress.XtraEditors.PanelControl();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxType = new DevExpress.XtraEditors.ComboBoxEdit();
            this.simpleButtonCancel = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonOK = new DevExpress.XtraEditors.SimpleButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.picturePreView = new DevExpress.XtraEditors.PictureEdit();
            this.panelSymbolList = new DevExpress.XtraEditors.PanelControl();
            this.imageListBoxLayers = new DevExpress.XtraEditors.ImageListBoxControl();
            this.imageList1 = new System.Windows.Forms.ImageList();
            this.checkedListBoxLayers = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.simpleButtonMoveDown = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonMoveUp = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonDeleteLayer = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonAddlayer = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).BeginInit();
            this.panelControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.gbLineSet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudLineWidth.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceLineColor.Properties)).BeginInit();
            this.gbPointSet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPointAngle.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPointSize.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cePointColor.Properties)).BeginInit();
            this.gbAreaSet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ceBorderColor.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceFillColor.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudOutLine.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControlType)).BeginInit();
            this.panelControlType.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxType.Properties)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picturePreView.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelSymbolList)).BeginInit();
            this.panelSymbolList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageListBoxLayers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkedListBoxLayers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.panelControl4);
            this.panelControl1.Controls.Add(this.panelControl3);
            this.panelControl1.Controls.Add(this.panel1);
            this.panelControl1.Controls.Add(this.panelControlType);
            this.panelControl1.Controls.Add(this.simpleButtonCancel);
            this.panelControl1.Controls.Add(this.simpleButtonOK);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelControl1.Location = new System.Drawing.Point(258, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Padding = new System.Windows.Forms.Padding(0, 6, 0, 6);
            this.panelControl1.Size = new System.Drawing.Size(219, 363);
            this.panelControl1.TabIndex = 0;
            // 
            // panelControl4
            // 
            this.panelControl4.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl4.Controls.Add(this.simpleButtonOutline);
            this.panelControl4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl4.Location = new System.Drawing.Point(0, 240);
            this.panelControl4.Name = "panelControl4";
            this.panelControl4.Padding = new System.Windows.Forms.Padding(12, 12, 0, 0);
            this.panelControl4.Size = new System.Drawing.Size(219, 44);
            this.panelControl4.TabIndex = 17;
            // 
            // simpleButtonOutline
            // 
            this.simpleButtonOutline.Dock = System.Windows.Forms.DockStyle.Left;
            this.simpleButtonOutline.Location = new System.Drawing.Point(12, 12);
            this.simpleButtonOutline.Name = "simpleButtonOutline";
            this.simpleButtonOutline.Size = new System.Drawing.Size(86, 32);
            this.simpleButtonOutline.TabIndex = 2;
            this.simpleButtonOutline.Text = "边框符号";
            this.simpleButtonOutline.Click += new System.EventHandler(this.simpleButtonOutline_Click);
            // 
            // panelControl3
            // 
            this.panelControl3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl3.Controls.Add(this.simpleButtonLine);
            this.panelControl3.Controls.Add(this.simpleButtonMarker);
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl3.Location = new System.Drawing.Point(0, 196);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Padding = new System.Windows.Forms.Padding(12, 12, 0, 0);
            this.panelControl3.Size = new System.Drawing.Size(219, 44);
            this.panelControl3.TabIndex = 14;
            // 
            // simpleButtonLine
            // 
            this.simpleButtonLine.Dock = System.Windows.Forms.DockStyle.Left;
            this.simpleButtonLine.Location = new System.Drawing.Point(69, 12);
            this.simpleButtonLine.Name = "simpleButtonLine";
            this.simpleButtonLine.Size = new System.Drawing.Size(57, 32);
            this.simpleButtonLine.TabIndex = 1;
            this.simpleButtonLine.Text = "线符号";
            this.simpleButtonLine.Click += new System.EventHandler(this.simpleButtonLine_Click);
            // 
            // simpleButtonMarker
            // 
            this.simpleButtonMarker.Dock = System.Windows.Forms.DockStyle.Left;
            this.simpleButtonMarker.Location = new System.Drawing.Point(12, 12);
            this.simpleButtonMarker.Name = "simpleButtonMarker";
            this.simpleButtonMarker.Size = new System.Drawing.Size(57, 32);
            this.simpleButtonMarker.TabIndex = 0;
            this.simpleButtonMarker.Text = "点符号";
            this.simpleButtonMarker.Click += new System.EventHandler(this.simpleButtonMarker_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.gbLineSet);
            this.panel1.Controls.Add(this.gbPointSet);
            this.panel1.Controls.Add(this.gbAreaSet);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 60);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(219, 136);
            this.panel1.TabIndex = 15;
            // 
            // gbLineSet
            // 
            this.gbLineSet.Controls.Add(this.nudLineWidth);
            this.gbLineSet.Controls.Add(this.ceLineColor);
            this.gbLineSet.Controls.Add(this.label3);
            this.gbLineSet.Controls.Add(this.label2);
            this.gbLineSet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbLineSet.Location = new System.Drawing.Point(0, 0);
            this.gbLineSet.Name = "gbLineSet";
            this.gbLineSet.Size = new System.Drawing.Size(219, 136);
            this.gbLineSet.TabIndex = 12;
            this.gbLineSet.TabStop = false;
            this.gbLineSet.Text = "设置";
            // 
            // nudLineWidth
            // 
            this.nudLineWidth.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudLineWidth.Location = new System.Drawing.Point(87, 70);
            this.nudLineWidth.Name = "nudLineWidth";
            this.nudLineWidth.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.nudLineWidth.Properties.MaxValue = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.nudLineWidth.Size = new System.Drawing.Size(87, 20);
            this.nudLineWidth.TabIndex = 41;
            this.nudLineWidth.ValueChanged += new System.EventHandler(this.nudLineWidth_ValueChanged);
            // 
            // ceLineColor
            // 
            this.ceLineColor.EditValue = System.Drawing.Color.Empty;
            this.ceLineColor.Location = new System.Drawing.Point(87, 36);
            this.ceLineColor.Name = "ceLineColor";
            this.ceLineColor.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ceLineColor.Properties.ColorAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.ceLineColor.Size = new System.Drawing.Size(87, 20);
            this.ceLineColor.TabIndex = 40;
            this.ceLineColor.ColorChanged += new System.EventHandler(this.ceLineColor_ColorChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 14);
            this.label3.TabIndex = 39;
            this.label3.Text = "宽度:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 40);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 14);
            this.label2.TabIndex = 38;
            this.label2.Text = "颜色:";
            // 
            // gbPointSet
            // 
            this.gbPointSet.Controls.Add(this.nudPointAngle);
            this.gbPointSet.Controls.Add(this.nudPointSize);
            this.gbPointSet.Controls.Add(this.cePointColor);
            this.gbPointSet.Controls.Add(this.lbAngle);
            this.gbPointSet.Controls.Add(this.lbPointSize);
            this.gbPointSet.Controls.Add(this.lbPointColor);
            this.gbPointSet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbPointSet.Location = new System.Drawing.Point(0, 0);
            this.gbPointSet.Name = "gbPointSet";
            this.gbPointSet.Size = new System.Drawing.Size(219, 136);
            this.gbPointSet.TabIndex = 11;
            this.gbPointSet.TabStop = false;
            this.gbPointSet.Text = "设置";
            this.gbPointSet.Visible = false;
            // 
            // nudPointAngle
            // 
            this.nudPointAngle.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudPointAngle.Location = new System.Drawing.Point(89, 87);
            this.nudPointAngle.Name = "nudPointAngle";
            this.nudPointAngle.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.nudPointAngle.Properties.MaxValue = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.nudPointAngle.Properties.MinValue = new decimal(new int[] {
            360,
            0,
            0,
            -2147483648});
            this.nudPointAngle.Size = new System.Drawing.Size(87, 20);
            this.nudPointAngle.TabIndex = 37;
            this.nudPointAngle.ValueChanged += new System.EventHandler(this.nudPointAngle_ValueChanged);
            // 
            // nudPointSize
            // 
            this.nudPointSize.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudPointSize.Location = new System.Drawing.Point(89, 56);
            this.nudPointSize.Name = "nudPointSize";
            this.nudPointSize.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.nudPointSize.Properties.MaxValue = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.nudPointSize.Size = new System.Drawing.Size(87, 20);
            this.nudPointSize.TabIndex = 36;
            this.nudPointSize.ValueChanged += new System.EventHandler(this.nudPointSize_ValueChanged);
            // 
            // cePointColor
            // 
            this.cePointColor.EditValue = System.Drawing.Color.Empty;
            this.cePointColor.Location = new System.Drawing.Point(89, 22);
            this.cePointColor.Name = "cePointColor";
            this.cePointColor.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cePointColor.Properties.ColorAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.cePointColor.Size = new System.Drawing.Size(87, 20);
            this.cePointColor.TabIndex = 35;
            this.cePointColor.ColorChanged += new System.EventHandler(this.cePointColor_ColorChanged);
            // 
            // lbAngle
            // 
            this.lbAngle.AutoSize = true;
            this.lbAngle.Location = new System.Drawing.Point(23, 91);
            this.lbAngle.Name = "lbAngle";
            this.lbAngle.Size = new System.Drawing.Size(35, 14);
            this.lbAngle.TabIndex = 18;
            this.lbAngle.Text = "角度:";
            // 
            // lbPointSize
            // 
            this.lbPointSize.AutoSize = true;
            this.lbPointSize.Location = new System.Drawing.Point(21, 59);
            this.lbPointSize.Name = "lbPointSize";
            this.lbPointSize.Size = new System.Drawing.Size(35, 14);
            this.lbPointSize.TabIndex = 15;
            this.lbPointSize.Text = "大小:";
            // 
            // lbPointColor
            // 
            this.lbPointColor.AutoSize = true;
            this.lbPointColor.Location = new System.Drawing.Point(21, 26);
            this.lbPointColor.Margin = new System.Windows.Forms.Padding(0);
            this.lbPointColor.Name = "lbPointColor";
            this.lbPointColor.Size = new System.Drawing.Size(35, 14);
            this.lbPointColor.TabIndex = 14;
            this.lbPointColor.Text = "颜色:";
            // 
            // gbAreaSet
            // 
            this.gbAreaSet.Controls.Add(this.ceBorderColor);
            this.gbAreaSet.Controls.Add(this.ceFillColor);
            this.gbAreaSet.Controls.Add(this.nudOutLine);
            this.gbAreaSet.Controls.Add(this.lbOutLineColor);
            this.gbAreaSet.Controls.Add(this.lbOutLineWidth);
            this.gbAreaSet.Controls.Add(this.lbFillColor);
            this.gbAreaSet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbAreaSet.Location = new System.Drawing.Point(0, 0);
            this.gbAreaSet.Name = "gbAreaSet";
            this.gbAreaSet.Size = new System.Drawing.Size(219, 136);
            this.gbAreaSet.TabIndex = 8;
            this.gbAreaSet.TabStop = false;
            this.gbAreaSet.Text = "设置";
            this.gbAreaSet.Visible = false;
            // 
            // ceBorderColor
            // 
            this.ceBorderColor.EditValue = System.Drawing.Color.Empty;
            this.ceBorderColor.Location = new System.Drawing.Point(90, 93);
            this.ceBorderColor.Name = "ceBorderColor";
            this.ceBorderColor.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ceBorderColor.Properties.ColorAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.ceBorderColor.Size = new System.Drawing.Size(87, 20);
            this.ceBorderColor.TabIndex = 35;
            this.ceBorderColor.ColorChanged += new System.EventHandler(this.ceBorderColor_ColorChanged);
            // 
            // ceFillColor
            // 
            this.ceFillColor.EditValue = System.Drawing.Color.Empty;
            this.ceFillColor.Location = new System.Drawing.Point(90, 28);
            this.ceFillColor.Name = "ceFillColor";
            this.ceFillColor.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ceFillColor.Properties.ColorAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.ceFillColor.Size = new System.Drawing.Size(87, 20);
            this.ceFillColor.TabIndex = 34;
            this.ceFillColor.ColorChanged += new System.EventHandler(this.ceFillColor_ColorChanged);
            // 
            // nudOutLine
            // 
            this.nudOutLine.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudOutLine.Location = new System.Drawing.Point(90, 61);
            this.nudOutLine.Name = "nudOutLine";
            this.nudOutLine.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.nudOutLine.Properties.MaxValue = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.nudOutLine.Size = new System.Drawing.Size(87, 20);
            this.nudOutLine.TabIndex = 33;
            this.nudOutLine.ValueChanged += new System.EventHandler(this.nudOutLine_ValueChanged);
            // 
            // lbOutLineColor
            // 
            this.lbOutLineColor.AutoSize = true;
            this.lbOutLineColor.Location = new System.Drawing.Point(22, 97);
            this.lbOutLineColor.Name = "lbOutLineColor";
            this.lbOutLineColor.Size = new System.Drawing.Size(59, 14);
            this.lbOutLineColor.TabIndex = 12;
            this.lbOutLineColor.Text = "边框颜色:";
            // 
            // lbOutLineWidth
            // 
            this.lbOutLineWidth.AutoSize = true;
            this.lbOutLineWidth.Location = new System.Drawing.Point(22, 65);
            this.lbOutLineWidth.Name = "lbOutLineWidth";
            this.lbOutLineWidth.Size = new System.Drawing.Size(59, 14);
            this.lbOutLineWidth.TabIndex = 9;
            this.lbOutLineWidth.Text = "边框宽度:";
            // 
            // lbFillColor
            // 
            this.lbFillColor.AutoSize = true;
            this.lbFillColor.Location = new System.Drawing.Point(22, 31);
            this.lbFillColor.Margin = new System.Windows.Forms.Padding(0);
            this.lbFillColor.Name = "lbFillColor";
            this.lbFillColor.Size = new System.Drawing.Size(47, 14);
            this.lbFillColor.TabIndex = 8;
            this.lbFillColor.Text = "填充色:";
            // 
            // panelControlType
            // 
            this.panelControlType.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControlType.Controls.Add(this.label1);
            this.panelControlType.Controls.Add(this.comboBoxType);
            this.panelControlType.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControlType.Location = new System.Drawing.Point(0, 6);
            this.panelControlType.Name = "panelControlType";
            this.panelControlType.Size = new System.Drawing.Size(219, 54);
            this.panelControlType.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 19);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 14);
            this.label1.TabIndex = 39;
            this.label1.Text = "类型:";
            // 
            // comboBoxType
            // 
            this.comboBoxType.Location = new System.Drawing.Point(52, 15);
            this.comboBoxType.Name = "comboBoxType";
            this.comboBoxType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxType.Size = new System.Drawing.Size(163, 20);
            this.comboBoxType.TabIndex = 0;
            this.comboBoxType.SelectedIndexChanged += new System.EventHandler(this.comboBoxType_SelectedIndexChanged);
            // 
            // simpleButtonCancel
            // 
            this.simpleButtonCancel.Location = new System.Drawing.Point(121, 316);
            this.simpleButtonCancel.Name = "simpleButtonCancel";
            this.simpleButtonCancel.Size = new System.Drawing.Size(70, 30);
            this.simpleButtonCancel.TabIndex = 1;
            this.simpleButtonCancel.Text = "取消";
            this.simpleButtonCancel.Click += new System.EventHandler(this.simpleButtonCancel_Click);
            // 
            // simpleButtonOK
            // 
            this.simpleButtonOK.Location = new System.Drawing.Point(27, 316);
            this.simpleButtonOK.Name = "simpleButtonOK";
            this.simpleButtonOK.Size = new System.Drawing.Size(70, 30);
            this.simpleButtonOK.TabIndex = 0;
            this.simpleButtonOK.Text = "确定";
            this.simpleButtonOK.Click += new System.EventHandler(this.simpleButtonOK_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.picturePreView);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 6);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(6, 3, 6, 6);
            this.groupBox1.Size = new System.Drawing.Size(240, 178);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "预览";
            // 
            // picturePreView
            // 
            this.picturePreView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picturePreView.Location = new System.Drawing.Point(6, 18);
            this.picturePreView.Name = "picturePreView";
            this.picturePreView.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.picturePreView.Properties.Appearance.Options.UseBackColor = true;
            this.picturePreView.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.picturePreView.Size = new System.Drawing.Size(228, 154);
            this.picturePreView.TabIndex = 0;
            // 
            // panelSymbolList
            // 
            this.panelSymbolList.AutoSize = true;
            this.panelSymbolList.Controls.Add(this.imageListBoxLayers);
            this.panelSymbolList.Controls.Add(this.checkedListBoxLayers);
            this.panelSymbolList.Location = new System.Drawing.Point(9, 24);
            this.panelSymbolList.Name = "panelSymbolList";
            this.panelSymbolList.Size = new System.Drawing.Size(178, 139);
            this.panelSymbolList.TabIndex = 0;
            // 
            // imageListBoxLayers
            // 
            this.imageListBoxLayers.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.imageListBoxLayers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imageListBoxLayers.ImageList = this.imageList1;
            this.imageListBoxLayers.ItemHeight = 32;
            this.imageListBoxLayers.Location = new System.Drawing.Point(25, 2);
            this.imageListBoxLayers.Name = "imageListBoxLayers";
            this.imageListBoxLayers.Padding = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.imageListBoxLayers.Size = new System.Drawing.Size(151, 135);
            this.imageListBoxLayers.TabIndex = 2;
            this.imageListBoxLayers.SelectedIndexChanged += new System.EventHandler(this.imageListBoxLayers_SelectedIndexChanged);
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(128, 32);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // checkedListBoxLayers
            // 
            this.checkedListBoxLayers.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.checkedListBoxLayers.Dock = System.Windows.Forms.DockStyle.Left;
            this.checkedListBoxLayers.ItemHeight = 32;
            this.checkedListBoxLayers.Location = new System.Drawing.Point(2, 2);
            this.checkedListBoxLayers.Name = "checkedListBoxLayers";
            this.checkedListBoxLayers.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.checkedListBoxLayers.Size = new System.Drawing.Size(23, 135);
            this.checkedListBoxLayers.TabIndex = 1;
            this.checkedListBoxLayers.Visible = false;
            // 
            // panelControl2
            // 
            this.panelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl2.Controls.Add(this.groupBox3);
            this.panelControl2.Controls.Add(this.groupBox1);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelControl2.Location = new System.Drawing.Point(6, 0);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Padding = new System.Windows.Forms.Padding(0, 6, 0, 6);
            this.panelControl2.Size = new System.Drawing.Size(240, 363);
            this.panelControl2.TabIndex = 1;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.simpleButtonMoveDown);
            this.groupBox3.Controls.Add(this.simpleButtonMoveUp);
            this.groupBox3.Controls.Add(this.panelSymbolList);
            this.groupBox3.Controls.Add(this.simpleButtonDeleteLayer);
            this.groupBox3.Controls.Add(this.simpleButtonAddlayer);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Location = new System.Drawing.Point(0, 184);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(240, 238);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "叠加要素";
            // 
            // simpleButtonMoveDown
            // 
            this.simpleButtonMoveDown.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.simpleButtonMoveDown.Appearance.Options.UseFont = true;
            this.simpleButtonMoveDown.Location = new System.Drawing.Point(201, 64);
            this.simpleButtonMoveDown.Name = "simpleButtonMoveDown";
            this.simpleButtonMoveDown.Size = new System.Drawing.Size(27, 29);
            this.simpleButtonMoveDown.TabIndex = 4;
            this.simpleButtonMoveDown.Text = "↓";
            this.simpleButtonMoveDown.Click += new System.EventHandler(this.simpleButtonMoveDown_Click);
            // 
            // simpleButtonMoveUp
            // 
            this.simpleButtonMoveUp.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.simpleButtonMoveUp.Appearance.ForeColor = System.Drawing.Color.Black;
            this.simpleButtonMoveUp.Appearance.Options.UseFont = true;
            this.simpleButtonMoveUp.Appearance.Options.UseForeColor = true;
            this.simpleButtonMoveUp.Location = new System.Drawing.Point(201, 28);
            this.simpleButtonMoveUp.Name = "simpleButtonMoveUp";
            this.simpleButtonMoveUp.Size = new System.Drawing.Size(27, 29);
            this.simpleButtonMoveUp.TabIndex = 3;
            this.simpleButtonMoveUp.Text = "↑";
            this.simpleButtonMoveUp.Click += new System.EventHandler(this.simpleButtonMoveUp_Click);
            // 
            // simpleButtonDeleteLayer
            // 
            this.simpleButtonDeleteLayer.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.simpleButtonDeleteLayer.Appearance.Options.UseFont = true;
            this.simpleButtonDeleteLayer.Location = new System.Drawing.Point(201, 135);
            this.simpleButtonDeleteLayer.Name = "simpleButtonDeleteLayer";
            this.simpleButtonDeleteLayer.Size = new System.Drawing.Size(27, 29);
            this.simpleButtonDeleteLayer.TabIndex = 2;
            this.simpleButtonDeleteLayer.Text = "X";
            this.simpleButtonDeleteLayer.Click += new System.EventHandler(this.simpleButtonDeleteLayer_Click);
            // 
            // simpleButtonAddlayer
            // 
            this.simpleButtonAddlayer.Appearance.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.simpleButtonAddlayer.Appearance.Options.UseFont = true;
            this.simpleButtonAddlayer.Location = new System.Drawing.Point(201, 99);
            this.simpleButtonAddlayer.Name = "simpleButtonAddlayer";
            this.simpleButtonAddlayer.Size = new System.Drawing.Size(27, 29);
            this.simpleButtonAddlayer.TabIndex = 1;
            this.simpleButtonAddlayer.Text = "+";
            this.simpleButtonAddlayer.Click += new System.EventHandler(this.simpleButtonAddlayer_Click);
            // 
            // DevCompliSymbol
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(483, 363);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.LookAndFeel.SkinName = "Blue";
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DevCompliSymbol";
            this.Padding = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "叠加符号";
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).EndInit();
            this.panelControl4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.gbLineSet.ResumeLayout(false);
            this.gbLineSet.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudLineWidth.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceLineColor.Properties)).EndInit();
            this.gbPointSet.ResumeLayout(false);
            this.gbPointSet.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPointAngle.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPointSize.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cePointColor.Properties)).EndInit();
            this.gbAreaSet.ResumeLayout(false);
            this.gbAreaSet.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ceBorderColor.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceFillColor.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudOutLine.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControlType)).EndInit();
            this.panelControlType.ResumeLayout(false);
            this.panelControlType.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxType.Properties)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picturePreView.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelSymbolList)).EndInit();
            this.panelSymbolList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imageListBoxLayers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkedListBoxLayers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        private void nudLineWidth_ValueChanged(object sender, EventArgs e)
        {
            ILineSymbol selectedSymbol = (ILineSymbol) this.m_SelectedSymbol;
            selectedSymbol.Width = Convert.ToDouble(this.nudLineWidth.Value);
            this.PreviewChildImage();
        }

        private void nudOutLine_ValueChanged(object sender, EventArgs e)
        {
            IFillSymbol selectedSymbol = (IFillSymbol) this.m_SelectedSymbol;
            ESRI.ArcGIS.esriSystem.IPersist outline = selectedSymbol.Outline as ESRI.ArcGIS.esriSystem.IPersist;
            Guid pClassID = new Guid();
            outline.GetClassID(out pClassID);
            System.Type.GetTypeFromCLSID(pClassID);
            ILineSymbol symbol2 = selectedSymbol.Outline;
            symbol2.Width = double.Parse(this.nudOutLine.Value.ToString());
            symbol2.Color = selectedSymbol.Outline.Color;
            selectedSymbol.Outline = symbol2;
            this.PreviewChildImage();
        }

        private void nudPointAngle_ValueChanged(object sender, EventArgs e)
        {
            IMarkerSymbol selectedSymbol = (IMarkerSymbol) this.m_SelectedSymbol;
            selectedSymbol.Angle = double.Parse(this.nudPointAngle.Value.ToString());
            this.PreviewChildImage();
        }

        private void nudPointSize_ValueChanged(object sender, EventArgs e)
        {
            IMarkerSymbol selectedSymbol = (IMarkerSymbol) this.m_SelectedSymbol;
            selectedSymbol.Size = double.Parse(this.nudPointSize.Value.ToString());
            this.PreviewChildImage();
        }

        private void PreviewChildImage()
        {
            ISymbol selectedSymbol = this.m_SelectedSymbol;
            Image image = this.GetSymbolImage(selectedSymbol, 0x80, 0x20, Color.White, 1);
            int selectedIndex = this.imageListBoxLayers.SelectedIndex;
            this.imageList1.Images[selectedIndex] = image;
            this.imageListBoxLayers.Refresh();
            this.PreviewImage(this.m_Symbol);
        }

        private void PreviewImage(ISymbol pSymbol)
        {
            Image image = this.GetSymbolImage(pSymbol, 0x80, 0x20, Color.White, 1);
            this.picturePreView.Image = image;
        }

        private void RefreshProperty()
        {
            if (this.imageListBoxLayers.SelectedIndex >= 0)
            {
                ISymbol selectedSymbol = this.m_SelectedSymbol;
                if (this.m_SymbolType == 1)
                {
                    IMarkerSymbol symbol2 = (IMarkerSymbol) selectedSymbol;
                    this.nudPointAngle.Value = Convert.ToDecimal(symbol2.Angle);
                    this.nudPointSize.Value = Convert.ToDecimal(symbol2.Size);
                    this.cePointColor.Color = ColorService.EsriColorToNetColor(symbol2.Color);
                }
                else if (this.m_SymbolType == 2)
                {
                    if (this.m_SelectedSymbol is MarkerLineSymbol)
                    {
                        this.simpleButtonMarker.Visible = true;
                    }
                    ILineSymbol symbol3 = (ILineSymbol) selectedSymbol;
                    this.nudLineWidth.Value = Convert.ToDecimal(symbol3.Width);
                    this.ceLineColor.Color = ColorService.EsriColorToNetColor(symbol3.Color);
                }
                else if (this.m_SymbolType == 3)
                {
                    if (this.m_SelectedSymbol is LineFillSymbol)
                    {
                        this.simpleButtonLine.Visible = true;
                        this.simpleButtonOutline.Visible = true;
                    }
                    else if (this.m_SelectedSymbol is MarkerFillSymbol)
                    {
                        this.simpleButtonMarker.Visible = true;
                        this.simpleButtonOutline.Visible = true;
                    }
                    IFillSymbol symbol4 = (IFillSymbol) selectedSymbol;
                    this.ceBorderColor.Color = ColorService.EsriColorToNetColor(symbol4.Outline.Color);
                    this.nudOutLine.Value = Convert.ToDecimal(symbol4.Outline.Width);
                    this.ceFillColor.Color = ColorService.EsriColorToNetColor(symbol4.Color);
                }
            }
        }

        private void RefreshSymbol()
        {
            try
            {
                int selectedIndex = this.imageListBoxLayers.SelectedIndex;
                if (selectedIndex >= 0)
                {
                    ISymbol selectedSymbol = this.m_SelectedSymbol;
                    if (this.m_SymbolType == 1)
                    {
                        IMultiLayerMarkerSymbol symbol2 = new MultiLayerMarkerSymbolClass();
                        IMultiLayerMarkerSymbol symbol = (IMultiLayerMarkerSymbol) this.m_Symbol;
                        IMarkerSymbol markerLayer = null;
                        for (int i = symbol.LayerCount - 1; i >= 0; i--)
                        {
                            if (i == selectedIndex)
                            {
                                markerLayer = (IMarkerSymbol) selectedSymbol;
                            }
                            else
                            {
                                markerLayer = symbol.get_Layer(i);
                            }
                            symbol2.AddLayer(markerLayer);
                        }
                        this.m_Symbol = (ISymbol) symbol2;
                    }
                    else if (this.m_SymbolType == 2)
                    {
                        IMultiLayerLineSymbol symbol5 = new MultiLayerLineSymbolClass();
                        IMultiLayerLineSymbol symbol6 = (IMultiLayerLineSymbol) this.m_Symbol;
                        ILineSymbol lineLayer = null;
                        for (int j = symbol6.LayerCount - 1; j >= 0; j--)
                        {
                            if (j == selectedIndex)
                            {
                                lineLayer = (ILineSymbol) selectedSymbol;
                            }
                            else
                            {
                                lineLayer = symbol6.get_Layer(j);
                            }
                            symbol5.AddLayer(lineLayer);
                        }
                        this.m_Symbol = (ISymbol) symbol5;
                    }
                    else if (this.m_SymbolType == 3)
                    {
                        IMultiLayerFillSymbol symbol8 = new MultiLayerFillSymbolClass();
                        IMultiLayerFillSymbol symbol9 = (IMultiLayerFillSymbol) this.m_Symbol;
                        IFillSymbol fillLayer = null;
                        for (int k = symbol9.LayerCount - 1; k >= 0; k--)
                        {
                            if (k == selectedIndex)
                            {
                                fillLayer = (IFillSymbol) selectedSymbol;
                            }
                            else
                            {
                                fillLayer = symbol9.get_Layer(k);
                            }
                            symbol8.AddLayer(fillLayer);
                        }
                        this.m_Symbol = (ISymbol) symbol8;
                    }
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "Cartography.Render.DevCompliSymbol", "RefreshSymbol", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void simpleButtonAddlayer_Click(object sender, EventArgs e)
        {
            if (this.m_SymbolType == 1)
            {
                IMultiLayerMarkerSymbol symbol = (IMultiLayerMarkerSymbol) this.m_Symbol;
                ISymbol symbol2 = this.CreateDefaultSymbol();
                symbol.AddLayer((IMarkerSymbol) symbol2);
            }
            else if (this.m_SymbolType == 2)
            {
                IMultiLayerLineSymbol symbol3 = (IMultiLayerLineSymbol) this.m_Symbol;
                ISymbol symbol4 = this.CreateDefaultSymbol();
                symbol3.AddLayer((ILineSymbol) symbol4);
            }
            else if (this.m_SymbolType == 3)
            {
                IMultiLayerFillSymbol symbol5 = (IMultiLayerFillSymbol) this.m_Symbol;
                ISymbol symbol6 = this.CreateDefaultSymbol();
                symbol5.AddLayer((IFillSymbol) symbol6);
            }
            this.InitalControl(0);
        }

        private void simpleButtonCancel_Click(object sender, EventArgs e)
        {
            this.m_Symbol = null;
            base.Close();
        }

        private void simpleButtonDeleteLayer_Click(object sender, EventArgs e)
        {
            if (this.m_SymbolType == 1)
            {
                ((IMultiLayerMarkerSymbol) this.m_Symbol).DeleteLayer((IMarkerSymbol) this.m_SelectedSymbol);
            }
            else if (this.m_SymbolType == 2)
            {
                ((IMultiLayerLineSymbol) this.m_Symbol).DeleteLayer((ILineSymbol) this.m_SelectedSymbol);
            }
            else if (this.m_SymbolType == 3)
            {
                ((IMultiLayerFillSymbol) this.m_Symbol).DeleteLayer((IFillSymbol) this.m_SelectedSymbol);
            }
            this.InitalControl(0);
        }

        private void simpleButtonLine_Click(object sender, EventArgs e)
        {
            int selectedIndex = this.imageListBoxLayers.SelectedIndex;
            if (selectedIndex >= 0)
            {
                try
                {
                    if ((this.m_SymbolType == 1) || (this.m_SymbolType == 2))
                    {
                        return;
                    }
                    if ((this.m_SymbolType == 3) && (this.m_SelectedSymbol is LineFillSymbol))
                    {
                        ILineFillSymbol selectedSymbol = (ILineFillSymbol) this.m_SelectedSymbol;
                        ILineSymbol lineSymbol = selectedSymbol.LineSymbol;
                        IStyleGalleryItem item = null;
                        DevSymbolSelector selector = new DevSymbolSelector();
                        item = selector.GetItem(lineSymbol as ISymbol);
                        selector.Dispose();
                        if (item == null)
                        {
                            return;
                        }
                        ISymbol symbol3 = (ISymbol) item.Item;
                        selectedSymbol.LineSymbol = (ILineSymbol) symbol3;
                        this.m_SelectedSymbol = (ISymbol) selectedSymbol;
                        this.RefreshSymbol();
                    }
                }
                catch
                {
                }
                this.InitalControl(selectedIndex);
            }
        }

        private void simpleButtonMarker_Click(object sender, EventArgs e)
        {
            int selectedIndex = this.imageListBoxLayers.SelectedIndex;
            if (selectedIndex >= 0)
            {
                try
                {
                    if (this.m_SymbolType == 1)
                    {
                        return;
                    }
                    if (this.m_SymbolType == 2)
                    {
                        if (this.m_SelectedSymbol is MarkerLineSymbol)
                        {
                            IMarkerLineSymbol selectedSymbol = (IMarkerLineSymbol) this.m_SelectedSymbol;
                            IMarkerSymbol markerSymbol = selectedSymbol.MarkerSymbol;
                            IStyleGalleryItem item = null;
                            DevSymbolSelector selector = new DevSymbolSelector();
                            item = selector.GetItem(markerSymbol as ISymbol);
                            selector.Dispose();
                            if (item == null)
                            {
                                return;
                            }
                            ISymbol symbol3 = (ISymbol) item.Item;
                            selectedSymbol.MarkerSymbol = (IMarkerSymbol) symbol3;
                            this.m_SelectedSymbol = (ISymbol) selectedSymbol;
                            this.RefreshSymbol();
                        }
                    }
                    else if ((this.m_SymbolType == 3) && (this.m_SelectedSymbol is MarkerFillSymbol))
                    {
                        IMarkerFillSymbol symbol4 = (IMarkerFillSymbol) this.m_SelectedSymbol;
                        IMarkerSymbol symbol5 = symbol4.MarkerSymbol;
                        IStyleGalleryItem item2 = null;
                        DevSymbolSelector selector2 = new DevSymbolSelector();
                        item2 = selector2.GetItem(symbol5 as ISymbol);
                        selector2.Dispose();
                        if (item2 == null)
                        {
                            return;
                        }
                        ISymbol symbol6 = (ISymbol) item2.Item;
                        symbol4.MarkerSymbol = (IMarkerSymbol) symbol6;
                        this.m_SelectedSymbol = (ISymbol) symbol4;
                        this.RefreshSymbol();
                    }
                }
                catch
                {
                }
                this.InitalControl(selectedIndex);
            }
        }

        private void simpleButtonMoveDown_Click(object sender, EventArgs e)
        {
            int selectedIndex = this.imageListBoxLayers.SelectedIndex;
            if (selectedIndex != (this.imageListBoxLayers.Items.Count - 1))
            {
                if (this.m_SymbolType == 1)
                {
                    ((IMultiLayerMarkerSymbol) this.m_Symbol).MoveLayer((IMarkerSymbol) this.m_SelectedSymbol, selectedIndex + 1);
                }
                else if (this.m_SymbolType == 2)
                {
                    ((IMultiLayerLineSymbol) this.m_Symbol).MoveLayer((ILineSymbol) this.m_SelectedSymbol, selectedIndex + 1);
                }
                else if (this.m_SymbolType == 3)
                {
                    ((IMultiLayerFillSymbol) this.m_Symbol).MoveLayer((IFillSymbol) this.m_SelectedSymbol, selectedIndex + 1);
                }
                this.InitalControl(selectedIndex + 1);
            }
        }

        private void simpleButtonMoveUp_Click(object sender, EventArgs e)
        {
            int selectedIndex = this.imageListBoxLayers.SelectedIndex;
            if (selectedIndex != 0)
            {
                if (this.m_SymbolType == 1)
                {
                    ((IMultiLayerMarkerSymbol) this.m_Symbol).MoveLayer((IMarkerSymbol) this.m_SelectedSymbol, selectedIndex - 1);
                }
                else if (this.m_SymbolType == 2)
                {
                    ((IMultiLayerLineSymbol) this.m_Symbol).MoveLayer((ILineSymbol) this.m_SelectedSymbol, selectedIndex - 1);
                }
                else if (this.m_SymbolType == 3)
                {
                    ((IMultiLayerFillSymbol) this.m_Symbol).MoveLayer((IFillSymbol) this.m_SelectedSymbol, selectedIndex - 1);
                }
                this.InitalControl(selectedIndex - 1);
            }
        }

        private void simpleButtonOK_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        private void simpleButtonOutline_Click(object sender, EventArgs e)
        {
            int selectedIndex = this.imageListBoxLayers.SelectedIndex;
            if (selectedIndex >= 0)
            {
                try
                {
                    if ((this.m_SymbolType == 1) || (this.m_SymbolType == 2))
                    {
                        return;
                    }
                    if (this.m_SymbolType == 3)
                    {
                        if (this.m_SelectedSymbol is LineFillSymbol)
                        {
                            ILineFillSymbol selectedSymbol = (ILineFillSymbol) this.m_SelectedSymbol;
                            ILineSymbol outline = selectedSymbol.Outline;
                            IStyleGalleryItem item = null;
                            DevSymbolSelector selector = new DevSymbolSelector();
                            item = selector.GetItem(outline as ISymbol);
                            selector.Dispose();
                            if (item == null)
                            {
                                return;
                            }
                            ISymbol symbol3 = (ISymbol) item.Item;
                            selectedSymbol.Outline = (ILineSymbol) symbol3;
                            this.m_SelectedSymbol = (ISymbol) selectedSymbol;
                            this.RefreshSymbol();
                        }
                        else if (this.m_SelectedSymbol is MarkerFillSymbol)
                        {
                            IMarkerFillSymbol symbol4 = (IMarkerFillSymbol) this.m_SelectedSymbol;
                            ILineSymbol symbol5 = symbol4.Outline;
                            IStyleGalleryItem item2 = null;
                            DevSymbolSelector selector2 = new DevSymbolSelector();
                            item2 = selector2.GetItem(symbol5 as ISymbol);
                            selector2.Dispose();
                            if (item2 == null)
                            {
                                return;
                            }
                            ISymbol symbol6 = (ISymbol) item2.Item;
                            symbol4.Outline = (ILineSymbol) symbol6;
                            this.m_SelectedSymbol = (ISymbol) symbol4;
                            this.RefreshSymbol();
                        }
                    }
                }
                catch
                {
                }
                this.InitalControl(selectedIndex);
            }
        }
    }
}

