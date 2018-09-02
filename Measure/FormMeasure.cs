namespace Measure
{
    using DevExpress.XtraEditors;
    using DevExpress.XtraEditors.Controls;
    using ESRI.ArcGIS.ADF.BaseClasses;
    using ESRI.ArcGIS.Carto;
    using ESRI.ArcGIS.Controls;
    using ESRI.ArcGIS.Display;
    using ESRI.ArcGIS.esriSystem;
    using ESRI.ArcGIS.Geometry;
    using ESRI.ArcGIS.SystemUI;
    using FormBase;
    using FunFactory;
    using Microsoft.VisualBasic;
    using Microsoft.VisualBasic.CompilerServices;
    using stdole;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Diagnostics;
    using System.Drawing;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;
    using Utilities;

    [DesignerGenerated]
    public class FormMeasure : FormBase2
    {
        private static List<WeakReference> __ENCList = new List<WeakReference>();
     //   [AccessedThroughProperty("_AxToolbarControl")]
        private ESRI.ArcGIS.Controls.AxToolbarControl _AxToolbarControl;
    //    [AccessedThroughProperty("_butClose")]
        private SimpleButton _butClose;
    //    [AccessedThroughProperty("_ButtonDrawText")]
        private SimpleButton _ButtonDrawText;
     //   [AccessedThroughProperty("_ButtonTransfer")]
        private SimpleButton _ButtonTransfer;
     //   [AccessedThroughProperty("_CheckButton1")]
        private CheckButton _CheckButton1;
      //  [AccessedThroughProperty("_comAreaUnit")]
        private ComboBoxEdit _comAreaUnit;
     //   [AccessedThroughProperty("_comLineUnit")]
        private ComboBoxEdit _comLineUnit;
     //   [AccessedThroughProperty("_Label1")]
        private Label _Label1;
     //   [AccessedThroughProperty("_Label2")]
        private Label _Label2;
      //  [AccessedThroughProperty("mActiveViewEvents")]
        private IActiveViewEvents_Event _mActiveViewEvents;
     //   [AccessedThroughProperty("_PanelControl1")]
        private PanelControl _PanelControl1;
     //   [AccessedThroughProperty("_PanelUnit")]
        private PanelControl _PanelUnit;
       
        private TextBox _txtResult;
        private IContainer components;
        private IActiveView mActiveView;
        private double mArea;
        private double mAreaSqMeterFactor;
        private const string mClassName = "Measure.FormMeasure";
        private DataRow[] mCodeRow;
        private DataTable mCodeTable;
       // private IDBAccess mDBAccess;
        private IElement mElement;
        private ErrorOpt mErrOpt;
        private IFillSymbol mFillSymbol;
        private IGeometry mGeometry;
        private IHookHelper mHookHelper;
        private double mLength;
        private double mLengthMeterFactor;
        private ILineSymbol mLineSymbol;
        private IMap mMap;
        public AxMapControl mMapControl;
        private IMarkerSymbol mMarkerSymbol;
        private string mSubSysName;
        private double mX;
        private double mY;

        public FormMeasure()
        {
            List<WeakReference> list = __ENCList;
            lock (list)
            {
                __ENCList.Add(new WeakReference(this));
            }
            this.mSubSysName = UtilFactory.GetConfigOpt().GetSystemName();
            this.mErrOpt = UtilFactory.GetErrorOpt();
            this.mAreaSqMeterFactor = 1.0;
            this.mLengthMeterFactor = 1.0;
            this.InitializeComponent();
        }

        private void butClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ButtonDrawText_Click(object sender, EventArgs e)
        {
            try
            {
                if (((this.mActiveView != null) && (this.mGeometry != null)) && !this.mGeometry.IsEmpty)
                {
                    ILayer basicGraphicsLayer = (ILayer) this.mActiveView.FocusMap.BasicGraphicsLayer;
                    if (!((basicGraphicsLayer == null) | !basicGraphicsLayer.Visible) && (this.mLength != 0.0))
                    {
                        ICurve mGeometry=null;
                        string text = this._txtResult.Text;
                        string[] strArray = Strings.Split(this._txtResult.Text, "\r\n", -1, CompareMethod.Binary);
                        if (strArray.Length > 2)
                        {
                            text = strArray[strArray.Length - 2] + "\r\n" + strArray[strArray.Length - 1];
                        }
                        else
                        {
                            text = strArray[strArray.Length - 1];
                        }
                        ITextElement element2 = new TextElementClass();
                        
                        if ((this.mGeometry.GeometryType == esriGeometryType.esriGeometryPolygon) | (this.mGeometry.GeometryType == esriGeometryType.esriGeometryPolyline))
                        {
                            mGeometry = (ICurve) this.mGeometry;
                        }
                        IElement pElement = (IElement) element2;
                        ITextPath path = new SimpleTextPathClass();
                        if (mGeometry == null)
                        {
                            pElement.Geometry = this.mGeometry;
                        }
                        else
                        {
                            pElement.Geometry = mGeometry;
                            path.Geometry = mGeometry;
                        }
                        ISimpleTextSymbol symbol = new TextSymbolClass();
                        symbol.Color = GISFunFactory.ColorFun.GetRGBColor(0xff, 0, 0, false);
                        symbol.Size = 10.0;
                        stdole.Font font = (stdole.Font) symbol.Font;
                        font.Name = "宋体";
                        font.Bold = false;
                        font.Size = 12M;
                        symbol.Font = (stdole.IFontDisp) font;
                        symbol.HorizontalAlignment = esriTextHorizontalAlignment.esriTHACenter;
                        symbol.XOffset = 0.0;
                        symbol.YOffset = Convert.ToDouble(decimal.Negate(decimal.Add(font.Size, 6M)));
                        element2.Symbol = symbol;
                        if (path.Geometry != null)
                        {
                            symbol.TextPath = path;
                        }
                        element2.ScaleText = false;
                        element2.Symbol = symbol;
                        element2.Text = text;
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
                        IElement element=null;
                        if (this.mElement != null)
                        {
                            element = (IElement) GISFunFactory.SystemFun.CloneObejct((IClone) this.mElement);
                        }
                        else if (this.mGeometry.GeometryType == esriGeometryType.esriGeometryPolyline)
                        {
                            element = new LineElementClass();
                            element.Geometry = this.mGeometry;
                            if (this.mLineSymbol != null)
                            {
                                ILineElement element2 = (ILineElement) element;
                                element2.Symbol = this.mLineSymbol;
                            }
                        }
                        else if (this.mGeometry.GeometryType == esriGeometryType.esriGeometryPolygon)
                        {
                            element = new PolygonElementClass();
                            element.Geometry = this.mGeometry;
                            if (this.mFillSymbol != null)
                            {
                                IFillShapeElement element3 = (IFillShapeElement) element;
                                element3.Symbol = this.mFillSymbol;
                            }
                        }
                        else if (this.mGeometry.GeometryType == esriGeometryType.esriGeometryPoint)
                        {
                            element = new MarkerElementClass();
                            element.Geometry = this.mGeometry;
                            if (this.mLineSymbol != null)
                            {
                                IMarkerElement element4 = (IMarkerElement) element;
                                element4.Symbol = this.mMarkerSymbol;
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
                this.mErrOpt.ErrorOperate(this.mSubSysName, "Measure.FormMeasure", "ButtonTransfer_Click", Conversions.ToString(Information.Err().Number), Information.Err().Source, Information.Err().Description, "", "", "");
                ProjectData.ClearProjectError();
            }
        }

        private void CheckButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (this._CheckButton1.Checked)
            {
                this._PanelUnit.Visible = true;
            }
            else
            {
                this._PanelUnit.Visible = false;
            }
        }

        private void comAreaUnit_TextChanged(object sender, EventArgs e)
        {
        }

        private void comLineUnit_TextChanged(object sender, EventArgs e)
        {
        }

        [DebuggerNonUserCode]
        protected override void Dispose(bool disposing)
        {
            try
            {
                if (disposing && (this.components != null))
                {
                    this.components.Dispose();
                }
            }
            finally
            {
                base.Dispose(disposing);
            }
        }

        private void InitCommand(ref BaseCommand pCommand, [Optional, DefaultParameterValue(true)] bool bGroup)
        {
            try
            {
                if (pCommand != null)
                {
                    this._AxToolbarControl.AddItem(pCommand, 0, -1, bGroup, 0, esriCommandStyles.esriCommandStyleIconOnly);
                    pCommand.OnCreate(RuntimeHelpers.GetObjectValue(this.mHookHelper.Hook));
                }
            }
            catch (Exception exception1)
            {
                ProjectData.SetProjectError(exception1);
                Exception exception = exception1;
                Interaction.MsgBox("Err InitCommand", MsgBoxStyle.ApplicationModal, null);
                ProjectData.ClearProjectError();
            }
        }

        public void InitialControls()
        {
            this.InitialMeasureTools();
        }

        [DebuggerStepThrough]
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMeasure));
            this._AxToolbarControl = new ESRI.ArcGIS.Controls.AxToolbarControl();
            this._PanelControl1 = new DevExpress.XtraEditors.PanelControl();
            this._PanelUnit = new DevExpress.XtraEditors.PanelControl();
            this._Label2 = new System.Windows.Forms.Label();
            this._Label1 = new System.Windows.Forms.Label();
            this._comLineUnit = new DevExpress.XtraEditors.ComboBoxEdit();
            this._comAreaUnit = new DevExpress.XtraEditors.ComboBoxEdit();
            this._txtResult = new System.Windows.Forms.TextBox();
            this._ButtonTransfer = new DevExpress.XtraEditors.SimpleButton();
            this._ButtonDrawText = new DevExpress.XtraEditors.SimpleButton();
            this._CheckButton1 = new DevExpress.XtraEditors.CheckButton();
            this._butClose = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this._AxToolbarControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._PanelControl1)).BeginInit();
            this._PanelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._PanelUnit)).BeginInit();
            this._PanelUnit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._comLineUnit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._comAreaUnit.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // sButOk
            // 
            this.sButOk.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.sButOk.Location = new System.Drawing.Point(255, 185);
            this.sButOk.Text = "关闭";
            // 
            // _AxToolbarControl
            // 
            this._AxToolbarControl.Dock = System.Windows.Forms.DockStyle.Top;
            this._AxToolbarControl.Location = new System.Drawing.Point(2, 2);
            this._AxToolbarControl.Name = "_AxToolbarControl";
            this._AxToolbarControl.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_AxToolbarControl.OcxState")));
            this._AxToolbarControl.Size = new System.Drawing.Size(313, 28);
            this._AxToolbarControl.TabIndex = 1;
            // 
            // _PanelControl1
            // 
            this._PanelControl1.Appearance.BackColor = System.Drawing.Color.White;
            this._PanelControl1.Appearance.Options.UseBackColor = true;
            this._PanelControl1.Controls.Add(this._PanelUnit);
            this._PanelControl1.Controls.Add(this._txtResult);
            this._PanelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this._PanelControl1.Location = new System.Drawing.Point(2, 30);
            this._PanelControl1.Name = "_PanelControl1";
            this._PanelControl1.Size = new System.Drawing.Size(313, 150);
            this._PanelControl1.TabIndex = 2;
            // 
            // _PanelUnit
            // 
            this._PanelUnit.Controls.Add(this._Label2);
            this._PanelUnit.Controls.Add(this._Label1);
            this._PanelUnit.Controls.Add(this._comLineUnit);
            this._PanelUnit.Controls.Add(this._comAreaUnit);
            this._PanelUnit.Location = new System.Drawing.Point(188, 3);
            this._PanelUnit.Name = "_PanelUnit";
            this._PanelUnit.Size = new System.Drawing.Size(122, 64);
            this._PanelUnit.TabIndex = 7;
            this._PanelUnit.Visible = false;
            // 
            // _Label2
            // 
            this._Label2.AutoSize = true;
            this._Label2.Location = new System.Drawing.Point(5, 35);
            this._Label2.Name = "_Label2";
            this._Label2.Size = new System.Drawing.Size(35, 14);
            this._Label2.TabIndex = 8;
            this._Label2.Text = "面积:";
            // 
            // _Label1
            // 
            this._Label1.AutoSize = true;
            this._Label1.Location = new System.Drawing.Point(4, 8);
            this._Label1.Name = "_Label1";
            this._Label1.Size = new System.Drawing.Size(35, 14);
            this._Label1.TabIndex = 7;
            this._Label1.Text = "距离:";
            // 
            // _comLineUnit
            // 
            this._comLineUnit.EditValue = "公里";
            this._comLineUnit.Location = new System.Drawing.Point(45, 5);
            this._comLineUnit.Name = "_comLineUnit";
            this._comLineUnit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this._comLineUnit.Properties.Items.AddRange(new object[] {
            "公里",
            "米"});
            this._comLineUnit.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this._comLineUnit.Size = new System.Drawing.Size(68, 20);
            this._comLineUnit.TabIndex = 6;
            // 
            // _comAreaUnit
            // 
            this._comAreaUnit.EditValue = "平方公里";
            this._comAreaUnit.Location = new System.Drawing.Point(45, 32);
            this._comAreaUnit.Name = "_comAreaUnit";
            this._comAreaUnit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this._comAreaUnit.Properties.Items.AddRange(new object[] {
            "平方公里",
            "公顷",
            "亩",
            "平方米"});
            this._comAreaUnit.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this._comAreaUnit.Size = new System.Drawing.Size(68, 20);
            this._comAreaUnit.TabIndex = 5;
            // 
            // _txtResult
            // 
            this._txtResult.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._txtResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this._txtResult.Location = new System.Drawing.Point(2, 2);
            this._txtResult.Multiline = true;
            this._txtResult.Name = "_txtResult";
            this._txtResult.Size = new System.Drawing.Size(309, 146);
            this._txtResult.TabIndex = 0;
            // 
            // _ButtonTransfer
            // 
            this._ButtonTransfer.Location = new System.Drawing.Point(189, 185);
            this._ButtonTransfer.Name = "_ButtonTransfer";
            this._ButtonTransfer.Size = new System.Drawing.Size(60, 23);
            this._ButtonTransfer.TabIndex = 3;
            this._ButtonTransfer.Text = "转为元素";
            // 
            // _ButtonDrawText
            // 
            this._ButtonDrawText.Location = new System.Drawing.Point(123, 185);
            this._ButtonDrawText.Name = "_ButtonDrawText";
            this._ButtonDrawText.Size = new System.Drawing.Size(60, 23);
            this._ButtonDrawText.TabIndex = 4;
            this._ButtonDrawText.Text = "标注结果";
            this._ButtonDrawText.ToolTip = "标注量算结果";
            // 
            // _CheckButton1
            // 
            this._CheckButton1.Location = new System.Drawing.Point(247, 3);
            this._CheckButton1.Name = "_CheckButton1";
            this._CheckButton1.Size = new System.Drawing.Size(65, 23);
            this._CheckButton1.TabIndex = 6;
            this._CheckButton1.Text = "单位设置";
            this._CheckButton1.CheckedChanged += new System.EventHandler(this.CheckButton1_CheckedChanged);
            // 
            // _butClose
            // 
            this._butClose.Location = new System.Drawing.Point(255, 185);
            this._butClose.Name = "_butClose";
            this._butClose.Size = new System.Drawing.Size(60, 23);
            this._butClose.TabIndex = 7;
            this._butClose.Text = "关闭";
            this._butClose.ToolTip = "关闭窗口";
            this._butClose.Click += new System.EventHandler(this.butClose_Click);
            // 
            // FormMeasure
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.Appearance.Options.UseBackColor = true;
            this.CancelButton = this.sButOk;
            this.ClientSize = new System.Drawing.Size(317, 211);
            this.Controls.Add(this._butClose);
            this.Controls.Add(this._CheckButton1);
            this.Controls.Add(this._ButtonDrawText);
            this.Controls.Add(this._ButtonTransfer);
            this.Controls.Add(this._PanelControl1);
            this.Controls.Add(this._AxToolbarControl);
            this.LookAndFeel.SkinName = "Blue";
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormMeasure";
            this.Padding = new System.Windows.Forms.Padding(2);
            this.Text = "地图量算";
            this.TopMost = true;
            this.Controls.SetChildIndex(this._AxToolbarControl, 0);
            this.Controls.SetChildIndex(this.sButOk, 0);
            this.Controls.SetChildIndex(this._PanelControl1, 0);
            this.Controls.SetChildIndex(this._ButtonTransfer, 0);
            this.Controls.SetChildIndex(this._ButtonDrawText, 0);
            this.Controls.SetChildIndex(this._CheckButton1, 0);
            this.Controls.SetChildIndex(this._butClose, 0);
            ((System.ComponentModel.ISupportInitialize)(this._AxToolbarControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._PanelControl1)).EndInit();
            this._PanelControl1.ResumeLayout(false);
            this._PanelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._PanelUnit)).EndInit();
            this._PanelUnit.ResumeLayout(false);
            this._PanelUnit.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._comLineUnit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._comAreaUnit.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        private void InitialMeasureTools()
        {
            try
            {
                this._AxToolbarControl.RemoveAll();
                IMapControl2 hook = (IMapControl2) this.mHookHelper.Hook;
                BaseTool tool = new MeasureDistanceTool2(this);
                BaseCommand pCommand = tool;
                this.InitCommand(ref pCommand, false);
                hook.CurrentTool = tool;
                tool = new MeasureAreaTool2(this);
                pCommand = tool;
                this.InitCommand(ref pCommand, false);
                tool = new MeasureFeatureTool2(this);
                pCommand = tool;
                this.InitCommand(ref pCommand, true);
                tool = new MeasureElementTool2(this);
                pCommand = tool;
                this.InitCommand(ref pCommand, true);
                pCommand = new ClearMeasureCommand();
                this.InitCommand(ref pCommand, true);
                this._AxToolbarControl.SetBuddyControl(RuntimeHelpers.GetObjectValue(this.mHookHelper.Hook));
            }
            catch (Exception exception1)
            {
                ProjectData.SetProjectError(exception1);
                Exception exception = exception1;
                ProjectData.ClearProjectError();
            }
        }

        public void SetMeasureResult(IActiveView pActiveView, IElement pElement, IGeometry pGeometry, IFillSymbol pFillSymbol)
        {
            try
            {
                this._txtResult.Text = "";
                this._ButtonTransfer.Enabled = false;
                this.mActiveView = pActiveView;
                this.mElement = pElement;
                this.mGeometry = pGeometry;
                this.mFillSymbol = pFillSymbol;
                if (this.mGeometry != null)
                {
                    string configValue = UtilFactory.GetConfigOpt().GetConfigValue("Project");
                    ISpatialReference pProject = GISFunFactory.GeometryFun.CreateSpatialReferencePCS(configValue);
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
                    double num2 = 1.0;
                    if (this._comLineUnit.Text == "公里")
                    {
                        num2 = 0.001;
                    }
                    else if (this._comLineUnit.Text == "米")
                    {
                        num2 = 1.0;
                    }
                    double num = 1.0;
                    if (this._comAreaUnit.Text == "平方公里")
                    {
                        num = 1E-06;
                    }
                    else if (this._comAreaUnit.Text == "公顷")
                    {
                        num = 0.0001;
                    }
                    else if (this._comAreaUnit.Text == "亩")
                    {
                        num = 0.0015;
                    }
                    else if (this._comAreaUnit.Text == "平方米")
                    {
                        num = 1.0;
                    }
                    this._txtResult.Text = "面";
                    this._txtResult.Text = this._txtResult.Text + "\r\n面积:" + Conversions.ToString((double) ((this.mArea * this.mAreaSqMeterFactor) * num)) + this._comAreaUnit.Text;
                    this._txtResult.Text = this._txtResult.Text + "\r\n周长:" + Conversions.ToString((double) ((this.mLength * this.mLengthMeterFactor) * num2)) + this._comLineUnit.Text;
                    this._txtResult.Refresh();
                }
            }
            catch (Exception exception1)
            {
                ProjectData.SetProjectError(exception1);
                Exception exception = exception1;
                this.mErrOpt.ErrorOperate(this.mSubSysName, "Measure.FormMeasure", "SetMeasureResult", Conversions.ToString(Information.Err().Number), Information.Err().Source, Information.Err().Description, "", "", "");
                ProjectData.ClearProjectError();
            }
        }

        public void SetMeasureResult(IActiveView pActiveView, IElement pElement, IGeometry pGeometry, ILineSymbol pLineSymbol)
        {
            try
            {
                this._txtResult.Text = "";
                this._ButtonTransfer.Enabled = false;
                this.mActiveView = pActiveView;
                this.mElement = pElement;
                this.mGeometry = pGeometry;
                this.mLineSymbol = pLineSymbol;
                if (this.mGeometry != null)
                {
                    string configValue = UtilFactory.GetConfigOpt().GetConfigValue("Project");
                    ISpatialReference pProject = GISFunFactory.GeometryFun.CreateSpatialReferencePCS(configValue);
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
                            else if ((this.mGeometry != null) & (this.mLineSymbol != null))
                            {
                                this._ButtonTransfer.Enabled = true;
                            }
                        }
                    }
                    double num2 = 1.0;
                    if (this._comLineUnit.Text == "公里")
                    {
                        num2 = 0.001;
                    }
                    else if (this._comLineUnit.Text == "米")
                    {
                        num2 = 1.0;
                    }
                    if (((this._comAreaUnit.Text != "平方公里") && (this._comAreaUnit.Text != "公顷")) && ((this._comAreaUnit.Text != "亩") && (this._comAreaUnit.Text == "平方米")))
                    {
                    }
                    this._txtResult.Text = "线";
                    this._txtResult.Text = this._txtResult.Text + "\r\n全长" + Conversions.ToString((double) ((this.mLength * this.mLengthMeterFactor) * num2)) + this._comLineUnit.Text;
                }
            }
            catch (Exception exception1)
            {
                ProjectData.SetProjectError(exception1);
                Exception exception = exception1;
                this.mErrOpt.ErrorOperate(this.mSubSysName, "Measure.FormMeasure", "SetMeasureResult", Conversions.ToString(Information.Err().Number), Information.Err().Source, Information.Err().Description, "", "", "");
                ProjectData.ClearProjectError();
            }
        }

        public void SetMeasureResult(IActiveView pActiveView, IElement pElement, IGeometry pGeometry, IMarkerSymbol pMarkerSymbol)
        {
            try
            {
                this._txtResult.Text = "";
                this._ButtonTransfer.Enabled = false;
                this.mActiveView = pActiveView;
                this.mElement = pElement;
                this.mGeometry = pGeometry;
                this.mMarkerSymbol = pMarkerSymbol;
                if (this.mGeometry != null)
                {
                    string configValue = UtilFactory.GetConfigOpt().GetConfigValue("Project");
                    ISpatialReference reference = GISFunFactory.GeometryFun.CreateSpatialReferencePCS(configValue);
                    IPoint point = (IPoint) pGeometry;
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
                    this._txtResult.Text = "点";
                    this._txtResult.Text = this._txtResult.Text + "\r\nX:" + GISFunFactory.FormatFun.FormatMapCoordinate(this.mX, this.mActiveView.FocusMap.MapUnits);
                    this._txtResult.Text = this._txtResult.Text + "\r\nY:" + GISFunFactory.FormatFun.FormatMapCoordinate(this.mY, this.mActiveView.FocusMap.MapUnits);
                }
            }
            catch (Exception exception1)
            {
                ProjectData.SetProjectError(exception1);
                Exception exception = exception1;
                this.mErrOpt.ErrorOperate(this.mSubSysName, "Measure.FormMeasure", "SetMeasureResult", Conversions.ToString(Information.Err().Number), Information.Err().Source, Information.Err().Description, "", "", "");
                ProjectData.ClearProjectError();
            }
        }

        //internal virtual ESRI.ArcGIS.Controls._AxToolbarControl _AxToolbarControl
        //{
        //    [DebuggerNonUserCode]
        //    get
        //    {
        //        return this._AxToolbarControl;
        //    }
        //    [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
        //    set
        //    {
        //        this._AxToolbarControl = value;
        //    }
        //}

        //internal virtual SimpleButton _butClose
        //{
        //    [DebuggerNonUserCode]
        //    get
        //    {
        //        return this._butClose;
        //    }
        //    [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
        //    set
        //    {
        //        EventHandler handler = new EventHandler(this.butClose_Click);
        //        if (this._butClose != null)
        //        {
        //            this._butClose.Click -= handler;
        //        }
        //        this._butClose = value;
        //        if (this._butClose != null)
        //        {
        //            this._butClose.Click += handler;
        //        }
        //    }
        //}

        //internal virtual SimpleButton _ButtonDrawText
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

        //internal virtual SimpleButton _ButtonTransfer
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

        //internal virtual CheckButton _CheckButton1
        //{
        //    [DebuggerNonUserCode]
        //    get
        //    {
        //        return this._CheckButton1;
        //    }
        //    [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
        //    set
        //    {
        //        EventHandler handler = new EventHandler(this.CheckButton1_CheckedChanged);
        //        if (this._CheckButton1 != null)
        //        {
        //            this._CheckButton1.CheckedChanged -= handler;
        //        }
        //        this._CheckButton1 = value;
        //        if (this._CheckButton1 != null)
        //        {
        //            this._CheckButton1.CheckedChanged += handler;
        //        }
        //    }
        //}

        //internal virtual ComboBoxEdit _comAreaUnit
        //{
        //    [DebuggerNonUserCode]
        //    get
        //    {
        //        return this._comAreaUnit;
        //    }
        //    [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
        //    set
        //    {
        //        EventHandler handler = new EventHandler(this.comAreaUnit_TextChanged);
        //        if (this._comAreaUnit != null)
        //        {
        //            this._comAreaUnit.TextChanged -= handler;
        //        }
        //        this._comAreaUnit = value;
        //        if (this._comAreaUnit != null)
        //        {
        //            this._comAreaUnit.TextChanged += handler;
        //        }
        //    }
        //}

        //internal virtual ComboBoxEdit _comLineUnit
        //{
        //    [DebuggerNonUserCode]
        //    get
        //    {
        //        return this._comLineUnit;
        //    }
        //    [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
        //    set
        //    {
        //        EventHandler handler = new EventHandler(this.comLineUnit_TextChanged);
        //        if (this._comLineUnit != null)
        //        {
        //            this._comLineUnit.TextChanged -= handler;
        //        }
        //        this._comLineUnit = value;
        //        if (this._comLineUnit != null)
        //        {
        //            this._comLineUnit.TextChanged += handler;
        //        }
        //    }
        //}

        public object Hook
        {
            get
            {
                object hook;
                try
                {
                    if (this.mHookHelper == null)
                    {
                        this.mHookHelper = new HookHelperClass();
                    }
                    hook = this.mHookHelper.Hook;
                }
                catch (Exception exception1)
                {
                    ProjectData.SetProjectError(exception1);
                    Exception exception = exception1;
                    hook = null;
                    ProjectData.ClearProjectError();
                    return hook;
                    ProjectData.ClearProjectError();
                }
                return hook;
            }
            set
            {
                try
                {
                    if (value != null)
                    {
                        this.mHookHelper = new HookHelperClass();
                        this.mHookHelper.Hook = RuntimeHelpers.GetObjectValue(value);
                    }
                }
                catch (Exception exception1)
                {
                    ProjectData.SetProjectError(exception1);
                    Exception exception = exception1;
                    ProjectData.ClearProjectError();
                }
            }
        }

        //internal virtual Label _Label1
        //{
        //    [DebuggerNonUserCode]
        //    get
        //    {
        //        return this._Label1;
        //    }
        //    [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
        //    set
        //    {
        //        this._Label1 = value;
        //    }
        //}

        //internal virtual Label _Label2
        //{
        //    [DebuggerNonUserCode]
        //    get
        //    {
        //        return this._Label2;
        //    }
        //    [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
        //    set
        //    {
        //        this._Label2 = value;
        //    }
        //}

        //private IActiveViewEvents_Event mActiveViewEvents
        //{
        //    [DebuggerNonUserCode]
        //    get
        //    {
        //        return this._mActiveViewEvents;
        //    }
        //    [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
        //    set
        //    {
        //        this._mActiveViewEvents = value;
        //    }
        //}

        //internal virtual PanelControl _PanelControl1
        //{
        //    [DebuggerNonUserCode]
        //    get
        //    {
        //        return this._PanelControl1;
        //    }
        //    [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
        //    set
        //    {
        //        this._PanelControl1 = value;
        //    }
        //}

        //internal virtual PanelControl _PanelUnit
        //{
        //    [DebuggerNonUserCode]
        //    get
        //    {
        //        return this._PanelUnit;
        //    }
        //    [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
        //    set
        //    {
        //        this._PanelUnit = value;
        //    }
        //}

        //private TextBox _txtResult
        //{
           
        //    get
        //    {
        //        return this._txtResult;
        //    }           
        //    set
        //    {
        //        this._txtResult = value;
        //    }
        //}
    }
}

