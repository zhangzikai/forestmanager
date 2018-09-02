namespace Measure
{
    using ESRI.ArcGIS.Carto;
    using ESRI.ArcGIS.Display;
    using ESRI.ArcGIS.esriSystem;
    using ESRI.ArcGIS.Geometry;
    using FunFactory;
    using Microsoft.VisualBasic;
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Drawing;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;
    using Utilities;

    public class FormMeasureMarker : Form
    {
        private static List<WeakReference> __ENCList = new List<WeakReference>();
      //  [AccessedThroughProperty("_ButtonExit")]
        private Button _ButtonExit;
     //   [AccessedThroughProperty("_ButtonTransfer")]
        private Button _ButtonTransfer;
     //   [AccessedThroughProperty("_ComBoxUnitX")]
        private ComboBox _ComBoxUnitX;
       // [AccessedThroughProperty("_ComBoxUnitY")]
        private ComboBox _ComBoxUnitY;
    //    [AccessedThroughProperty("_GroupBoxMeasure")]
        private GroupBox _GroupBoxMeasure;
    //    [AccessedThroughProperty("_LabelX")]
        private Label _LabelX;
    //    [AccessedThroughProperty("_LabelY")]
        private Label _LabelY;
     //   [AccessedThroughProperty("_TextX")]
        private TextBox _TextX;
     //   [AccessedThroughProperty("_TextY")]
        private TextBox _TextY;
        private IContainer components;
        private IActiveView mActiveView;
        private const string mClassName = "Measure.FormMeasureMarker";
        private IElement mElement;
        private ErrorOpt mErrOpt;
        private GISFunFactory mFunFactory;
        private IGeometry mGeometry;
        private IMarkerSymbol mMarkerSymbol;
        private string mSubSysName;
        private double mX;
        private double mY;

        public FormMeasureMarker()
        {
            List<WeakReference> list = __ENCList;
            lock (list)
            {
                __ENCList.Add(new WeakReference(this));
            }
            this.mSubSysName = UtilFactory.GetConfigOpt().GetSystemName();
            this.mErrOpt = UtilFactory.GetErrorOpt();
            this.InitializeComponent();
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
                            element = new MarkerElementClass();
                            element.Geometry = this.mGeometry;
                            if (this.mMarkerSymbol != null)
                            {
                                IMarkerElement element2 = (IMarkerElement) element;
                                element2.Symbol = this.mMarkerSymbol;
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
                this.mErrOpt.ErrorOperate(this.mSubSysName, "Measure.FormMeasureMarker", "ButtonTransfer_Click", Conversions.ToString(Information.Err().Number), Information.Err().Source, Information.Err().Description, "", "", "");
                ProjectData.ClearProjectError();
            }
        }

        private void ComBoxUnitX_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                esriUnits esriDecimalDegrees = esriUnits.esriDecimalDegrees;
                switch (this._ComBoxUnitX.Text)
                {
                    case "度分秒":
                        esriDecimalDegrees = esriUnits.esriUnknownUnits;
                        break;

                    case "度":
                        esriDecimalDegrees = esriUnits.esriDecimalDegrees;
                        break;

                    case "公里":
                        esriDecimalDegrees = esriUnits.esriKilometers;
                        break;

                    case "米":
                        esriDecimalDegrees = esriUnits.esriMeters;
                        break;
                }
                if (esriDecimalDegrees == esriUnits.esriUnknownUnits)
                {
                    this._TextX.Text = GISFunFactory.FormatFun.FormatMapCoordinate(this.mX, this.mActiveView.FocusMap.MapUnits);
                }
                else
                {
                    this._TextX.Text = GISFunFactory.UnitFun.ConvertESRIUnits(this.mX, this.mActiveView.FocusMap.MapUnits, esriDecimalDegrees).ToString();
                }
            }
            catch (Exception exception1)
            {
                ProjectData.SetProjectError(exception1);
                Exception exception = exception1;
                this.mErrOpt.ErrorOperate(this.mSubSysName, "Measure.FormMeasureMarker", "ComBoxUnitX_SelectedIndexChanged", Conversions.ToString(Information.Err().Number), Information.Err().Source, Information.Err().Description, "", "", "");
                ProjectData.ClearProjectError();
            }
        }

        private void ComBoxUnitY_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                esriUnits esriDecimalDegrees = esriUnits.esriDecimalDegrees;
                switch (this._ComBoxUnitY.Text)
                {
                    case "度分秒":
                        esriDecimalDegrees = esriUnits.esriUnknownUnits;
                        break;

                    case "度":
                        esriDecimalDegrees = esriUnits.esriDecimalDegrees;
                        break;

                    case "公里":
                        esriDecimalDegrees = esriUnits.esriKilometers;
                        break;

                    case "米":
                        esriDecimalDegrees = esriUnits.esriMeters;
                        break;
                }
                if (esriDecimalDegrees == esriUnits.esriUnknownUnits)
                {
                    this._TextY.Text = GISFunFactory.FormatFun.FormatMapCoordinate(this.mY, this.mActiveView.FocusMap.MapUnits);
                }
                else
                {
                    this._TextY.Text = GISFunFactory.UnitFun.ConvertESRIUnits(this.mY, this.mActiveView.FocusMap.MapUnits, esriDecimalDegrees).ToString();
                }
            }
            catch (Exception exception1)
            {
                ProjectData.SetProjectError(exception1);
                Exception exception = exception1;
                this.mErrOpt.ErrorOperate(this.mSubSysName, "Measure.FormMeasureMarker", "ComBoxUnitY_SelectedIndexChanged", Conversions.ToString(Information.Err().Number), Information.Err().Source, Information.Err().Description, "", "", "");
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
            this._LabelX = new Label();
            this._LabelY = new Label();
            this._GroupBoxMeasure = new GroupBox();
            this._ComBoxUnitY = new ComboBox();
            this._ComBoxUnitX = new ComboBox();
            this._TextY = new TextBox();
            this._TextX = new TextBox();
            this._ButtonExit = new Button();
            this._ButtonTransfer = new Button();
            this._GroupBoxMeasure.SuspendLayout();
            this.SuspendLayout();
            System.Drawing.Point  point = new System.Drawing.Point(8, 0x13);
            this._LabelX.Location = point;
            this._LabelX.Name = "_LabelX";
            Size  size = new Size(0x29, 14);
            this._LabelX.Size = size;
            this._LabelX.TabIndex = 0;
            this._LabelX.Text = "经度:";
            System.Drawing.Point point1 = new System.Drawing.Point(8, 0x33);
            this._LabelY.Location = point1;
            this._LabelY.Name = "_LabelY";
            Size size2 = new Size(0x29, 14);
            this._LabelY.Size = size2;
            this._LabelY.TabIndex = 3;
            this._LabelY.Text = "纬度:";
            this._GroupBoxMeasure.Controls.Add(this._ComBoxUnitY);
            this._GroupBoxMeasure.Controls.Add(this._ComBoxUnitX);
            this._GroupBoxMeasure.Controls.Add(this._TextY);
            this._GroupBoxMeasure.Controls.Add(this._TextX);
            this._GroupBoxMeasure.Controls.Add(this._LabelY);
            this._GroupBoxMeasure.Controls.Add(this._LabelX);
            System.Drawing.Point point2 = new System.Drawing.Point(8, 0);
            this._GroupBoxMeasure.Location = point2;
            this._GroupBoxMeasure.Name = "_GroupBoxMeasure";
            Size size1 = new Size(0x128, 80);
            this._GroupBoxMeasure.Size = size1;
            this._GroupBoxMeasure.TabIndex = 0;
            this._GroupBoxMeasure.TabStop = false;
            this._ComBoxUnitY.DropDownStyle = ComboBoxStyle.DropDownList;
            this._ComBoxUnitY.Items.AddRange(new object[] { "度分秒", "度", "公里", "米" });
            System.Drawing.Point point3 = new System.Drawing.Point(0xd0, 0x30);
            this._ComBoxUnitY.Location = point3;
            this._ComBoxUnitY.Name = "_ComBoxUnitY";
            Size size3 = new Size(80, 20);
            this._ComBoxUnitY.Size = size3;
            this._ComBoxUnitY.TabIndex = 5;
            this._ComBoxUnitX.DropDownStyle = ComboBoxStyle.DropDownList;
            this._ComBoxUnitX.Items.AddRange(new object[] { "度分秒", "度", "公里", "米" });
            System.Drawing.Point point4 = new System.Drawing.Point(0xd0, 0x10);
            this._ComBoxUnitX.Location = point4;
            this._ComBoxUnitX.Name = "_ComBoxUnitX";
            Size size4 = new Size(80, 20);
            this._ComBoxUnitX.Size = size4;
            this._ComBoxUnitX.TabIndex = 2;
            this._TextY.BackColor = Color.White;
            this._TextY.ForeColor = Color.Black;
            System.Drawing.Point point5 = new System.Drawing.Point(0x38, 0x30);
            this._TextY.Location = point5;
            this._TextY.Name = "_TextY";
            this._TextY.ReadOnly = true;
            Size size5 = new Size(0x98, 0x15);
            this._TextY.Size = size5;
            this._TextY.TabIndex = 4;
            this._TextY.Text = "";
            this._TextX.BackColor = Color.White;
            this._TextX.ForeColor = Color.Black;
            System.Drawing.Point point6 = new System.Drawing.Point(0x38, 0x10);
            this._TextX.Location = point6;
            this._TextX.Name = "_TextX";
            this._TextX.ReadOnly = true;
            Size size6 = new Size(0x98, 0x15);
            this._TextX.Size = size6;
            this._TextX.TabIndex = 1;
            this._TextX.Text = "";
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
            Size size9 = new Size(6, 14);
            this.AutoScaleBaseSize = size9;
            Size size10 = new Size(0x13a, 0x77);
            this.ClientSize = size10;
            this.Controls.Add(this._ButtonExit);
            this.Controls.Add(this._ButtonTransfer);
            this.Controls.Add(this._GroupBoxMeasure);
//            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormMeasureMarker";
            this.ShowInTaskbar = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "位置测量";
            this._GroupBoxMeasure.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        public void SetMeasureResult(IActiveView pActiveView, IElement pElement, IGeometry pGeometry, IMarkerSymbol pMarkerSymbol)
        {
            try
            {
                this._TextX.Text = "";
                this._TextY.Text = "";
                this._ButtonTransfer.Enabled = false;
                this.mActiveView = pActiveView;
                this.mElement = pElement;
                this.mGeometry = pGeometry;
                this.mMarkerSymbol = pMarkerSymbol;
                if (this.mGeometry != null)
                {
                    string configValue = UtilFactory.GetConfigOpt().GetConfigValue("Project");
                    ISpatialReference reference = GISFunFactory.GeometryFun.CreateSpatialReferencePCS(configValue);
                    IPoint  point = (IPoint) pGeometry;
                    this.mX = point.X;
                    this.mY = point.Y;
                    reference = null;
                    if (this.mActiveView != null)
                    {
                        ILayer basicGraphicsLayer = (ILayer) this.mActiveView.FocusMap.BasicGraphicsLayer;
                        if ((basicGraphicsLayer != null) & basicGraphicsLayer.Visible)
                        {
                            if (this.mElement != null)
                            {
                                this._ButtonTransfer.Enabled = true;
                            }
                            else if ((this.mGeometry != null) & (this.mMarkerSymbol != null))
                            {
                                this._ButtonTransfer.Enabled = true;
                            }
                        }
                    }
                    this._TextX.Text = GISFunFactory.FormatFun.FormatMapCoordinate(this.mX, this.mActiveView.FocusMap.MapUnits);
                    this._TextY.Text = GISFunFactory.FormatFun.FormatMapCoordinate(this.mY, this.mActiveView.FocusMap.MapUnits);
                    this._ComBoxUnitX.Text = "度分秒";
                    this._ComBoxUnitY.Text = "度分秒";
                }
            }
            catch (Exception exception1)
            {
                ProjectData.SetProjectError(exception1);
                Exception exception = exception1;
                this.mErrOpt.ErrorOperate(this.mSubSysName, "Measure.FormMeasureMarker", "SetMeasureResult", Conversions.ToString(Information.Err().Number), Information.Err().Source, Information.Err().Description, "", "", "");
                ProjectData.ClearProjectError();
            }
        }

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

        //internal virtual ComboBox _ComBoxUnitX
        //{
        //    [DebuggerNonUserCode]
        //    get
        //    {
        //        return this._ComBoxUnitX;
        //    }
        //    [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
        //    set
        //    {
        //        EventHandler handler = new EventHandler(this.ComBoxUnitX_SelectedIndexChanged);
        //        if (this._ComBoxUnitX != null)
        //        {
        //            this._ComBoxUnitX.SelectedIndexChanged -= handler;
        //        }
        //        this._ComBoxUnitX = value;
        //        if (this._ComBoxUnitX != null)
        //        {
        //            this._ComBoxUnitX.SelectedIndexChanged += handler;
        //        }
        //    }
        //}

        //internal virtual ComboBox _ComBoxUnitY
        //{
        //    [DebuggerNonUserCode]
        //    get
        //    {
        //        return this._ComBoxUnitY;
        //    }
        //    [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
        //    set
        //    {
        //        EventHandler handler = new EventHandler(this.ComBoxUnitY_SelectedIndexChanged);
        //        if (this._ComBoxUnitY != null)
        //        {
        //            this._ComBoxUnitY.SelectedIndexChanged -= handler;
        //        }
        //        this._ComBoxUnitY = value;
        //        if (this._ComBoxUnitY != null)
        //        {
        //            this._ComBoxUnitY.SelectedIndexChanged += handler;
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

        //internal virtual Label _LabelX
        //{
        //    [DebuggerNonUserCode]
        //    get
        //    {
        //        return this._LabelX;
        //    }
        //    [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
        //    set
        //    {
        //        this._LabelX = value;
        //    }
        //}

        //internal virtual Label _LabelY
        //{
        //    [DebuggerNonUserCode]
        //    get
        //    {
        //        return this._LabelY;
        //    }
        //    [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
        //    set
        //    {
        //        this._LabelY = value;
        //    }
        //}

        //internal virtual TextBox _TextX
        //{
        //    [DebuggerNonUserCode]
        //    get
        //    {
        //        return this._TextX;
        //    }
        //    [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
        //    set
        //    {
        //        this._TextX = value;
        //    }
        //}

        //internal virtual TextBox _TextY
        //{
        //    [DebuggerNonUserCode]
        //    get
        //    {
        //        return this._TextY;
        //    }
        //    [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
        //    set
        //    {
        //        this._TextY = value;
        //    }
        //}
    }
}

