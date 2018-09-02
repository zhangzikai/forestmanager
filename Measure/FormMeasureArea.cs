namespace Measure
{
    using ESRI.ArcGIS.Carto;
    using ESRI.ArcGIS.Display;
    using ESRI.ArcGIS.esriSystem;
    using ESRI.ArcGIS.Geometry;
    using FunFactory;
    using Microsoft.VisualBasic;
    using Microsoft.VisualBasic.CompilerServices;
    using stdole;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Drawing;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;
    using Utilities;

    public class FormMeasureArea : Form
    {
        private static List<WeakReference> __ENCList = new List<WeakReference>();
       // [AccessedThroughProperty("_ButtonDrawText")]
        private Button _ButtonDrawText;
      //  [AccessedThroughProperty("_ButtonExit")]
        private Button _ButtonExit;
      //  [AccessedThroughProperty("_ButtonTransfer")]
        private Button _ButtonTransfer;
      //  [AccessedThroughProperty("_ComBoxUnitArea")]
        private ComboBox _ComBoxUnitArea;
       // [AccessedThroughProperty("_ComBoxUnitLength")]
        private ComboBox _ComBoxUnitLength;
      //  [AccessedThroughProperty("_GroupBoxMeasure")]
        private GroupBox _GroupBoxMeasure;
      //  [AccessedThroughProperty("_LabelArea")]
        private Label _LabelArea;
      //  [AccessedThroughProperty("_LabelLength")]
        private Label _LabelLength;
     //   [AccessedThroughProperty("_TextArea")]
        private TextBox _TextArea;
    //    [AccessedThroughProperty("_TextLength")]
        private TextBox _TextLength;
        private IContainer components;
        private IActiveView mActiveView;
        private double mArea;
        private double mAreaSqMeterFactor;
        private const string mClassName = "Measure.FormMeasureArea";
        private IElement mElement;
        private ErrorOpt mErrOpt;
        private IFillSymbol mFillSymbol;
        private GISFunFactory mFunFactory;
        private IGeometry mGeometry;
        private double mLength;
        private double mLengthMeterFactor;
        private string mSubSysName;

        public FormMeasureArea()
        {
            List<WeakReference> list = __ENCList;
            lock (list)
            {
                __ENCList.Add(new WeakReference(this));
            }
            this.mSubSysName = UtilFactory.GetConfigOpt().GetSystemName();
            this.mErrOpt = UtilFactory.GetErrorOpt();
            this.mLengthMeterFactor = 1.0;
            this.mAreaSqMeterFactor = 1.0;
            this.InitializeComponent();
        }

        private void ButtonDrawText_Click(object sender, EventArgs e)
        {
            try
            {
                if (((this.mActiveView != null) && (this.mGeometry != null)) && !this.mGeometry.IsEmpty)
                {
                    ILayer basicGraphicsLayer = (ILayer) this.mActiveView.FocusMap.BasicGraphicsLayer;
                    if (!((basicGraphicsLayer == null) | !basicGraphicsLayer.Visible) && (Conversions.ToString(this.mLength) != ""))
                    {
                        ITextElement element2 = new TextElementClass();
                        IElement pElement = (IElement) element2;
                        IPoint point = new PointClass();
                        point.PutCoords(this.mGeometry.Envelope.XMin + (this.mGeometry.Envelope.Width / 2.0), this.mGeometry.Envelope.YMin + (this.mGeometry.Envelope.Height / 2.0));
                        pElement.Geometry = point;
                        element2.Text = "面积:" + this._TextArea.Text + this._ComBoxUnitArea.Text + ",\r周长:" + this._TextLength.Text + this._ComBoxUnitLength.Text;
                        element2.Symbol = GISFunFactory.SymbolFun.DefaultTextSymbol;
                        ITextPath path = new SimpleTextPathClass();
                        ISimpleTextSymbol symbol = new TextSymbolClass();
                        symbol.Color = GISFunFactory.ColorFun.GetRGBColor(0xff, 0, 0, false);
                        stdole.Font font = (stdole.Font) symbol.Font;
                        font.Name = "宋体";
                        font.Bold = true;
                        font.Size = 12M;
                        symbol.Font = (stdole.IFontDisp) font;
                        symbol.HorizontalAlignment = esriTextHorizontalAlignment.esriTHACenter;
                        symbol.XOffset = 0.0;
                        symbol.YOffset = 3.0;
                        element2.Symbol = symbol;
                        element2.ScaleText = false;
                        element2.Symbol = symbol;
                        GISFunFactory.ElementFun.AddElement(this.mActiveView, pElement, true, false);
                        this.mActiveView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, null);
                    }
                }
            }
            catch (Exception exception1)
            {
                ProjectData.SetProjectError(exception1);
                Exception exception = exception1;
                ProjectData.ClearProjectError();
            }
        }

        private void ButtonTransfer_Click(object sender, EventArgs e)
        {
            try
            {
                if ((this.mActiveView != null) && (this.mGeometry != null))
                {
                    ILayer basicGraphicsLayer = (ILayer) this.mActiveView.FocusMap.BasicGraphicsLayer;
                    if (!((basicGraphicsLayer == null) | !basicGraphicsLayer.Visible))
                    {
                        IElement element;
                        if (this.mElement != null)
                        {
                            element = (IElement) GISFunFactory.SystemFun.CloneObejct((IClone) this.mElement);
                        }
                        else
                        {
                            element = new PolygonElementClass();
                            element.Geometry = this.mGeometry;
                            if (this.mFillSymbol != null)
                            {
                                IFillShapeElement element2 = (IFillShapeElement) element;
                                element2.Symbol = this.mFillSymbol;
                            }
                        }
                        GISFunFactory.ElementFun.AddElement(this.mActiveView, element, true, false);
                        if (this.mElement != null)
                        {
                            this.mActiveView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, this.mElement, null);
                            GISFunFactory.ElementFun.DeleteElement(this.mActiveView, this.mElement);
                        }
                        this.mActiveView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, element, null);
                        this._ButtonTransfer.Enabled = false;
                    }
                }
            }
            catch (Exception exception1)
            {
                ProjectData.SetProjectError(exception1);
                Exception exception = exception1;
                this.mErrOpt.ErrorOperate(this.mSubSysName, "Measure.FormMeasureArea", "ButtonTransfer_Click", Conversions.ToString(Information.Err().Number), Information.Err().Source, Information.Err().Description, "", "", "");
                ProjectData.ClearProjectError();
            }
        }

        private void ComBoxUnitArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                double mAreaSqMeterFactor = 0.0;
                switch (this._ComBoxUnitArea.Text)
                {
                    case "平方公里":
                        mAreaSqMeterFactor = this.mAreaSqMeterFactor * 1E-06;
                        break;

                    case "公顷":
                        mAreaSqMeterFactor = this.mAreaSqMeterFactor * 0.0001;
                        break;

                    case "亩":
                        mAreaSqMeterFactor = this.mAreaSqMeterFactor * 0.0015;
                        break;

                    case "平方米":
                        mAreaSqMeterFactor = this.mAreaSqMeterFactor;
                        break;
                }
                this._TextArea.Text = Conversions.ToString((double) (this.mArea * mAreaSqMeterFactor));
            }
            catch (Exception exception1)
            {
                ProjectData.SetProjectError(exception1);
                Exception exception = exception1;
                this.mErrOpt.ErrorOperate(this.mSubSysName, "Measure.FormMeasureArea", "ComBoxUnitArea_SelectedIndexChanged", Conversions.ToString(Information.Err().Number), Information.Err().Source, Information.Err().Description, "", "", "");
                ProjectData.ClearProjectError();
            }
        }

        private void ComBoxUnitLength_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                double mLengthMeterFactor = 0.0;
                switch (this._ComBoxUnitLength.Text)
                {
                    case "公里":
                        mLengthMeterFactor = this.mLengthMeterFactor * 0.001;
                        break;

                    case "米":
                        mLengthMeterFactor = this.mLengthMeterFactor;
                        break;
                }
                this._TextLength.Text = Conversions.ToString((double) (this.mLength * mLengthMeterFactor));
            }
            catch (Exception exception1)
            {
                ProjectData.SetProjectError(exception1);
                Exception exception = exception1;
                this.mErrOpt.ErrorOperate(this.mSubSysName, "Measure.FormMeasureArea", "ComBoxUnitLength_SelectedIndexChanged", Conversions.ToString(Information.Err().Number), Information.Err().Source, Information.Err().Description, "", "", "");
                ProjectData.ClearProjectError();
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

        [DebuggerStepThrough]
        private void InitializeComponent()
        {
            this._LabelArea = new Label();
            this._LabelLength = new Label();
            this._GroupBoxMeasure = new GroupBox();
            this._ComBoxUnitLength = new ComboBox();
            this._ComBoxUnitArea = new ComboBox();
            this._TextLength = new TextBox();
            this._TextArea = new TextBox();
            this._ButtonExit = new Button();
            this._ButtonTransfer = new Button();
            this._ButtonDrawText = new Button();
            this._GroupBoxMeasure.SuspendLayout();
            this.SuspendLayout();
            System.Drawing.Point point = new System.Drawing.Point(8, 0x13);
            this._LabelArea.Location = point;
            this._LabelArea.Name = "_LabelArea";
            Size  size = new Size(0x29, 14);
            this._LabelArea.Size = size;
            this._LabelArea.TabIndex = 0;
            this._LabelArea.Text = "面积:";
           System.Drawing.Point point1 = new System.Drawing.Point(8, 0x33);
           this._LabelLength.Location = point1;
            this._LabelLength.Name = "_LabelLength";
            Size size1 = new Size(0x29, 14);
            this._LabelLength.Size = size1;
            this._LabelLength.TabIndex = 3;
            this._LabelLength.Text = "周长:";
            this._GroupBoxMeasure.Controls.Add(this._ComBoxUnitLength);
            this._GroupBoxMeasure.Controls.Add(this._ComBoxUnitArea);
            this._GroupBoxMeasure.Controls.Add(this._TextLength);
            this._GroupBoxMeasure.Controls.Add(this._TextArea);
            this._GroupBoxMeasure.Controls.Add(this._LabelLength);
            this._GroupBoxMeasure.Controls.Add(this._LabelArea);
           System.Drawing.Point point2 = new System.Drawing.Point(8, 0);
           this._GroupBoxMeasure.Location = point2;
            this._GroupBoxMeasure.Name = "_GroupBoxMeasure";
            Size size2 = new Size(0x128, 80);
            this._GroupBoxMeasure.Size = size2;
            this._GroupBoxMeasure.TabIndex = 0;
            this._GroupBoxMeasure.TabStop = false;
            this._ComBoxUnitLength.DropDownStyle = ComboBoxStyle.DropDownList;
            this._ComBoxUnitLength.Items.AddRange(new object[] { "公里", "米" });
           System.Drawing.Point point3 = new System.Drawing.Point(0xd0, 0x30);
           this._ComBoxUnitLength.Location = point3;
            this._ComBoxUnitLength.Name = "_ComBoxUnitLength";
            Size size3 = new Size(80, 20);
            this._ComBoxUnitLength.Size = size3;
            this._ComBoxUnitLength.TabIndex = 5;
            this._ComBoxUnitArea.DropDownStyle = ComboBoxStyle.DropDownList;
            this._ComBoxUnitArea.Items.AddRange(new object[] { "平方公里", "公顷", "亩", "平方米" });
           System.Drawing.Point point4 = new System.Drawing.Point(0xd0, 0x10);
           this._ComBoxUnitArea.Location = point4;
            this._ComBoxUnitArea.Name = "_ComBoxUnitArea";
            Size size4 = new Size(80, 20);
            this._ComBoxUnitArea.Size = size4;
            this._ComBoxUnitArea.TabIndex = 2;
            this._TextLength.BackColor = Color.White;
            this._TextLength.ForeColor = Color.Black;
           System.Drawing.Point point5 = new System.Drawing.Point(0x38, 0x30);
           this._TextLength.Location = point5;
            this._TextLength.Name = "_TextLength";
            this._TextLength.ReadOnly = true;
            Size size5 = new Size(0x98, 0x15);
            this._TextLength.Size = size5;
            this._TextLength.TabIndex = 4;
            this._TextArea.BackColor = Color.White;
            this._TextArea.ForeColor = Color.Black;
           System.Drawing.Point point6 = new System.Drawing.Point(0x38, 0x10);
           this._TextArea.Location = point6;
            this._TextArea.Name = "_TextArea";
            this._TextArea.ReadOnly = true;
            Size size6 = new Size(0x98, 0x15);
            this._TextArea.Size = size6;
            this._TextArea.TabIndex = 1;
//            this._ButtonExit.DialogResult = DialogResult.Cancel;
           System.Drawing.Point point7 = new System.Drawing.Point(0xe0, 0x58);
           this._ButtonExit.Location = point7;
            this._ButtonExit.Name = "_ButtonExit";
            Size size7 = new Size(0x4b, 0x16);
            this._ButtonExit.Size = size7;
            this._ButtonExit.TabIndex = 2;
            this._ButtonExit.Text = "关闭";
           System.Drawing.Point point8 = new System.Drawing.Point(0x90, 0x58);
           this._ButtonTransfer.Location = point8;
            this._ButtonTransfer.Name = "_ButtonTransfer";
            Size size8 = new Size(0x4b, 0x16);
            this._ButtonTransfer.Size = size8;
            this._ButtonTransfer.TabIndex = 1;
            this._ButtonTransfer.Text = "转为元素";
           System.Drawing.Point point9 = new System.Drawing.Point(0x40, 0x58);
           this._ButtonDrawText.Location = point9;
            this._ButtonDrawText.Name = "_ButtonDrawText";
            Size size9 = new Size(0x4a, 0x16);
            this._ButtonDrawText.Size = size9;
            this._ButtonDrawText.TabIndex = 3;
            this._ButtonDrawText.Tag = "";
            this._ButtonDrawText.Text = "标注结果";
            this._ButtonDrawText.UseVisualStyleBackColor = true;
            Size size10 = new Size(6, 14);
            this.AutoScaleBaseSize = size10;
            Size size11 = new Size(0x13a, 0x77);
            this.ClientSize = size11;
            this.Controls.Add(this._ButtonDrawText);
            this.Controls.Add(this._ButtonExit);
            this.Controls.Add(this._ButtonTransfer);
            this.Controls.Add(this._GroupBoxMeasure);
//            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormMeasureArea";
            this.ShowInTaskbar = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "面积量算";
            this._GroupBoxMeasure.ResumeLayout(false);
            this._GroupBoxMeasure.PerformLayout();
            this.ResumeLayout(false);
        }

        public void SetMeasureResult(IActiveView pActiveView, IElement pElement, IGeometry pGeometry, IFillSymbol pFillSymbol)
        {
            try
            {
                this._TextArea.Text = "";
                this._TextLength.Text = "";
                this._ButtonTransfer.Enabled = false;
                this.mActiveView = pActiveView;
                this.mElement = pElement;
                this.mGeometry = pGeometry;
                this.mFillSymbol = pFillSymbol;
                if (this.mGeometry != null)
                {
                    string configValue = UtilFactory.GetConfigOpt().GetConfigValue("Project");
                    ISpatialReference pProject = GISFunFactory.GeometryFun.CreateSpatialReferencePCS(configValue);
                    this.mLengthMeterFactor = Conversions.ToDouble(UtilFactory.GetConfigOpt().GetConfigValue("LengthMeterFactor"));
                    this.mAreaSqMeterFactor = Conversions.ToDouble(UtilFactory.GetConfigOpt().GetConfigValue("AreaSqMeterFactor"));
                    this.mArea = GISFunFactory.GeometryFun.MeasureArea(pGeometry, this.mActiveView.FocusMap.SpatialReference, pProject);
                    this.mLength = GISFunFactory.GeometryFun.MeasureLength(pGeometry, this.mActiveView.FocusMap.SpatialReference, pProject);
                    pProject = null;
                    if (this.mActiveView != null)
                    {
                        ILayer basicGraphicsLayer = (ILayer) this.mActiveView.FocusMap.BasicGraphicsLayer;
                        if ((basicGraphicsLayer != null) & basicGraphicsLayer.Visible)
                        {
                            if (this.mElement != null)
                            {
                                this._ButtonTransfer.Enabled = true;
                            }
                            else if ((this.mGeometry != null) & (this.mFillSymbol != null))
                            {
                                this._ButtonTransfer.Enabled = true;
                            }
                        }
                    }
                    this._TextArea.Text = Conversions.ToString((double) ((this.mArea * this.mAreaSqMeterFactor) * 1E-06));
                    this._TextLength.Text = Conversions.ToString((double) ((this.mLength * this.mLengthMeterFactor) * 0.001));
                    this._ComBoxUnitArea.Text = "平方公里";
                    this._ComBoxUnitLength.Text = "公里";
                }
            }
            catch (Exception exception1)
            {
                ProjectData.SetProjectError(exception1);
                Exception exception = exception1;
                this.mErrOpt.ErrorOperate(this.mSubSysName, "Measure.FormMeasureArea", "SetMeasureResult", Conversions.ToString(Information.Err().Number), Information.Err().Source, Information.Err().Description, "", "", "");
                ProjectData.ClearProjectError();
            }
        }

        //internal virtual Button _ButtonDrawText
        //{
        //    [DebuggerNonUserCode]
        //    get
        //    {
        //        return this._ButtonDrawText;
        //    }
        //    [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
        //    set
        //    {
        //        EventHandler handler = new EventHandler(this.ButtonDrawText_Click);
        //        if (this._ButtonDrawText != null)
        //        {
        //            this._ButtonDrawText.Click -= handler;
        //        }
        //        this._ButtonDrawText = value;
        //        if (this._ButtonDrawText != null)
        //        {
        //            this._ButtonDrawText.Click += handler;
        //        }
        //    }
        //}

        //internal virtual Button _ButtonExit
        //{
        //    [DebuggerNonUserCode]
        //    get
        //    {
        //        return this._ButtonExit;
        //    }
        //    [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
        //    set
        //    {
        //        this._ButtonExit = value;
        //    }
        //}

        //internal virtual Button _ButtonTransfer
        //{
        //    [DebuggerNonUserCode]
        //    get
        //    {
        //        return this._ButtonTransfer;
        //    }
        //    [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
        //    set
        //    {
        //        EventHandler handler = new EventHandler(this.ButtonTransfer_Click);
        //        if (this._ButtonTransfer != null)
        //        {
        //            this._ButtonTransfer.Click -= handler;
        //        }
        //        this._ButtonTransfer = value;
        //        if (this._ButtonTransfer != null)
        //        {
        //            this._ButtonTransfer.Click += handler;
        //        }
        //    }
        //}

        //internal virtual ComboBox _ComBoxUnitArea
        //{
        //    [DebuggerNonUserCode]
        //    get
        //    {
        //        return this._ComBoxUnitArea;
        //    }
        //    [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
        //    set
        //    {
        //        EventHandler handler = new EventHandler(this.ComBoxUnitArea_SelectedIndexChanged);
        //        if (this._ComBoxUnitArea != null)
        //        {
        //            this._ComBoxUnitArea.SelectedIndexChanged -= handler;
        //        }
        //        this._ComBoxUnitArea = value;
        //        if (this._ComBoxUnitArea != null)
        //        {
        //            this._ComBoxUnitArea.SelectedIndexChanged += handler;
        //        }
        //    }
        //}

        //internal virtual ComboBox _ComBoxUnitLength
        //{
        //    [DebuggerNonUserCode]
        //    get
        //    {
        //        return this._ComBoxUnitLength;
        //    }
        //    [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
        //    set
        //    {
        //        EventHandler handler = new EventHandler(this.ComBoxUnitLength_SelectedIndexChanged);
        //        if (this._ComBoxUnitLength != null)
        //        {
        //            this._ComBoxUnitLength.SelectedIndexChanged -= handler;
        //        }
        //        this._ComBoxUnitLength = value;
        //        if (this._ComBoxUnitLength != null)
        //        {
        //            this._ComBoxUnitLength.SelectedIndexChanged += handler;
        //        }
        //    }
        //}

        //internal virtual GroupBox _GroupBoxMeasure
        //{
        //    [DebuggerNonUserCode]
        //    get
        //    {
        //        return this._GroupBoxMeasure;
        //    }
        //    [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
        //    set
        //    {
        //        this._GroupBoxMeasure = value;
        //    }
        //}

        //internal virtual Label _LabelArea
        //{
        //    [DebuggerNonUserCode]
        //    get
        //    {
        //        return this._LabelArea;
        //    }
        //    [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
        //    set
        //    {
        //        this._LabelArea = value;
        //    }
        //}

        //internal virtual Label _LabelLength
        //{
        //    [DebuggerNonUserCode]
        //    get
        //    {
        //        return this._LabelLength;
        //    }
        //    [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
        //    set
        //    {
        //        this._LabelLength = value;
        //    }
        //}

        //internal virtual TextBox _TextArea
        //{
        //    [DebuggerNonUserCode]
        //    get
        //    {
        //        return this._TextArea;
        //    }
        //    [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
        //    set
        //    {
        //        this._TextArea = value;
        //    }
        //}

        //internal virtual TextBox _TextLength
        //{
        //    [DebuggerNonUserCode]
        //    get
        //    {
        //        return this._TextLength;
        //    }
        //    [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
        //    set
        //    {
        //        this._TextLength = value;
        //    }
        //}
    }
}

