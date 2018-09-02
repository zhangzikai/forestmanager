namespace Measure
{
    using ESRI.ArcGIS.ADF.BaseClasses;
    using ESRI.ArcGIS.Carto;
    using ESRI.ArcGIS.Controls;
    using ESRI.ArcGIS.Display;
    using ESRI.ArcGIS.Geometry;
    using FunFactory;
    using Microsoft.VisualBasic;
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Drawing;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;
    using Utilities;

    public class MeasureAreaTool : BaseTool
    {
        private const string mClassName = "Measure.MeasureAreaTool";
        private ErrorOpt mErrOpt = UtilFactory.GetErrorOpt();
        private INewPolygonFeedback mFeedback;
        private GISFunFactory mFunFactory;
        private IHookHelper mHookHelper;
        private bool mInUsing;
        private string mSubSysName = UtilFactory.GetConfigOpt().GetSystemName();

        public MeasureAreaTool()
        {
            base.m_category = "量算";
            base.m_caption = "面积量算";
            base.m_message = "面积量算工具";
            base.m_toolTip = "面积量算工具";
            base.m_name = "MeasureAreaTool";
            try
            {
                base.m_bitmap = new Bitmap(this.GetType(), "MeasureArea.bmp");
                base.m_cursor = new Cursor(this.GetType(), "MeasureArea.cur");
            }
            catch (Exception exception1)
            {
                ProjectData.SetProjectError(exception1);
                Exception exception = exception1;
                this.mErrOpt.ErrorOperate(this.mSubSysName, "Measure.MeasureAreaTool", "New", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                ProjectData.ClearProjectError();
            }
            this.mHookHelper = new HookHelperClass();
        }

        public override bool Deactivate()
        {
            bool flag = false;
            try
            {
                this.ResetTool();
                flag = true;
            }
            catch (Exception exception1)
            {
                ProjectData.SetProjectError(exception1);
                Exception exception = exception1;
                this.mErrOpt.ErrorOperate(this.mSubSysName, "Measure.MeasureAreaTool", "Deactivate", Conversions.ToString(Information.Err().Number), Information.Err().Source, Information.Err().Description, "", "", "");
                ProjectData.ClearProjectError();
            }
            return flag;
        }

        //protected override void Finalize()
        //{
        //    try
        //    {
        //        this.mHookHelper = null;              
        //    }
        //    catch (Exception exception1)
        //    {
        //        ProjectData.SetProjectError(exception1);
        //        Exception exception = exception1;
        //        this.mErrOpt.ErrorOperate(this.mSubSysName, "Measure.MeasureAreaTool", "Finalize", Conversions.ToString(Information.Err().Number), Information.Err().Source, Information.Err().Description, "", "", "");
        //        ProjectData.ClearProjectError();
        //    }
        //}
        ~MeasureAreaTool() {
            try
            {
                this.mHookHelper = null;
            }
            catch (Exception exception1)
            {
                ProjectData.SetProjectError(exception1);
                Exception exception = exception1;
                this.mErrOpt.ErrorOperate(this.mSubSysName, "Measure.MeasureAreaTool", "Finalize", Conversions.ToString(Information.Err().Number), Information.Err().Source, Information.Err().Description, "", "", "");
                ProjectData.ClearProjectError();
            }
        }

        [DllImport("user32", CharSet=CharSet.Ansi, SetLastError=true, ExactSpelling=true)]
        private static extern int GetCapture();
        public override void OnClick()
        {
            try
            {
            }
            catch (Exception exception1)
            {
                ProjectData.SetProjectError(exception1);
                Exception exception = exception1;
                this.mErrOpt.ErrorOperate(this.mSubSysName, "Measure.MeasureAreaTool", "OnClick", Conversions.ToString(Information.Err().Number), Information.Err().Source, Information.Err().Description, "", "", "");
                ProjectData.ClearProjectError();
            }
        }

        public override void OnCreate(object hook)
        {
            try
            {
                this.mHookHelper.Hook = RuntimeHelpers.GetObjectValue(hook);
            }
            catch (Exception exception1)
            {
                ProjectData.SetProjectError(exception1);
                Exception exception = exception1;
                this.mErrOpt.ErrorOperate(this.mSubSysName, "Measure.MeasureAreaTool", "OnCreate", Conversions.ToString(Information.Err().Number), Information.Err().Source, Information.Err().Description, "", "", "");
                ProjectData.ClearProjectError();
            }
        }

        public override void OnDblClick()
        {
            try
            {
                if (this.mInUsing && (this.mFeedback != null))
                {
                    IGeometry polygon = this.mFeedback.Stop();
                    this.ResetTool();
                    if ((polygon != null) && !polygon.IsEmpty)
                    {
                        IRgbColor color2 = new RgbColorClass();
                        color2.Red = 0xff;
                        color2.Green = 0;
                        color2.Blue = 0;
                        color2.Transparency = 0xff;
                        ILineSymbol symbol2 = new SimpleLineSymbolClass();
                        symbol2.Color = color2;
                        symbol2.Width = 2.0;
                        IRgbColor color = new RgbColorClass();
                        color.Red = 0xff;
                        color.Green = 0;
                        color.Blue = 0;
                        color.Transparency = 0xff;
                        ISimpleFillSymbol pFillSymbol = new SimpleFillSymbolClass();
                        pFillSymbol.Color = color;
                        pFillSymbol.Outline = symbol2;
                        pFillSymbol.Style = esriSimpleFillStyle.esriSFSForwardDiagonal;
                        IActiveView activeView = this.mHookHelper.ActiveView;
                        IGraphicsLayer pGraphicsLayer = GISFunFactory.LayerFun.FindGraphicsLayer((IBasicMap) this.mHookHelper.FocusMap, "<Measure>");
                        IElement pElement = null;
                        IFillShapeElement element2 = null;
                        if (pGraphicsLayer == null)
                        {
                            activeView.ScreenDisplay.StartDrawing(0, -1);
                            activeView.ScreenDisplay.SetSymbol((ISymbol) pFillSymbol);
                            activeView.ScreenDisplay.DrawPolygon(polygon);
                            activeView.ScreenDisplay.FinishDrawing();
                        }
                        else
                        {
                            pElement = new PolygonElementClass();
                            pElement.Geometry = polygon;
                            element2 = (IFillShapeElement) pElement;
                            element2.Symbol = pFillSymbol;
                            GISFunFactory.ElementFun.AddElement(pGraphicsLayer, pElement, true, true);
                            activeView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, pElement, null);
                        }
                        FormMeasureArea area = new FormMeasureArea();
                        area.SetMeasureResult(activeView, pElement, polygon, pFillSymbol);
                        area.ShowDialog();
                        area = null;
                        this.mHookHelper.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewForeground, null, null);
                    }
                }
            }
            catch (Exception exception1)
            {
                ProjectData.SetProjectError(exception1);
                Exception exception = exception1;
                this.mErrOpt.ErrorOperate(this.mSubSysName, "Measure.MeasureAreaTool", "OnDblClick", Conversions.ToString(Information.Err().Number), Information.Err().Source, Information.Err().Description, "", "", "");
                ProjectData.ClearProjectError();
            }
        }

        public override void OnKeyDown(int keyCode, int shift)
        {
            try
            {
                if (keyCode == 0x1b)
                {
                    this.ResetTool();
                }
            }
            catch (Exception exception1)
            {
                ProjectData.SetProjectError(exception1);
                Exception exception = exception1;
                this.mErrOpt.ErrorOperate(this.mSubSysName, "Measure.MeasureAreaTool", "OnKeyDown", Conversions.ToString(Information.Err().Number), Information.Err().Source, Information.Err().Description, "", "", "");
                ProjectData.ClearProjectError();
            }
        }

        public override void OnMouseDown(int button, int shift, int x, int y)
        {
            try
            {
                if (this.mHookHelper.ActiveView != null)
                {
                    if (button == 1)
                    {
                        IPoint point = this.mHookHelper.ActiveView.ScreenDisplay.DisplayTransformation.ToMapPoint(x, y);
                        if (this.mFeedback == null)
                        {
                            this.mFeedback = new NewPolygonFeedbackClass();
                            ISimpleLineSymbol symbol = (ISimpleLineSymbol) this.mFeedback.Symbol;
                            IRgbColor color = new RgbColorClass();
                            color.Red = 0xff;
                            color.Green = 0;
                            color.Blue = 0;
                            symbol.Color = color;
                            symbol.Style = esriSimpleLineStyle.esriSLSSolid;
                            symbol.Width = 2.0;
                            this.mFeedback.Display = this.mHookHelper.ActiveView.ScreenDisplay;
                            this.mFeedback.Start(point);
                        }
                        else
                        {
                            this.mFeedback.AddPoint(point);
                        }
                        this.mInUsing = true;
                        SetCapture(this.mHookHelper.ActiveView.ScreenDisplay.WindowDC);
                    }
                    else if (this.mInUsing && (this.mFeedback != null))
                    {
                        IGeometry polygon = this.mFeedback.Stop();
                        this.ResetTool();
                        if ((polygon != null) && !polygon.IsEmpty)
                        {
                            IRgbColor color3 = new RgbColorClass();
                            color3.Red = 0xff;
                            color3.Green = 0;
                            color3.Blue = 0;
                            color3.Transparency = 0xff;
                            ILineSymbol symbol3 = new SimpleLineSymbolClass();
                            symbol3.Color = color3;
                            symbol3.Width = 2.0;
                            IRgbColor color2 = new RgbColorClass();
                            color2.Red = 0xff;
                            color2.Green = 0;
                            color2.Blue = 0;
                            color2.Transparency = 0xff;
                            ISimpleFillSymbol pFillSymbol = new SimpleFillSymbolClass();
                            pFillSymbol.Color = color2;
                            pFillSymbol.Outline = symbol3;
                            pFillSymbol.Style = esriSimpleFillStyle.esriSFSForwardDiagonal;
                            IActiveView activeView = this.mHookHelper.ActiveView;
                            IGraphicsLayer pGraphicsLayer = GISFunFactory.LayerFun.FindGraphicsLayer((IBasicMap) this.mHookHelper.FocusMap, "<Measure>");
                            IElement pElement = null;
                            IFillShapeElement element2 = null;
                            if (pGraphicsLayer == null)
                            {
                                activeView.ScreenDisplay.StartDrawing(0, -1);
                                activeView.ScreenDisplay.SetSymbol((ISymbol) pFillSymbol);
                                activeView.ScreenDisplay.DrawPolygon(polygon);
                                activeView.ScreenDisplay.FinishDrawing();
                            }
                            else
                            {
                                pElement = new PolygonElementClass();
                                pElement.Geometry = polygon;
                                element2 = (IFillShapeElement) pElement;
                                element2.Symbol = pFillSymbol;
                                GISFunFactory.ElementFun.AddElement(pGraphicsLayer, pElement, true, true);
                                activeView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, pElement, null);
                            }
                            FormMeasureArea area = new FormMeasureArea();
                            area.SetMeasureResult(activeView, pElement, polygon, pFillSymbol);
                            area.ShowDialog();
                            area = null;
                            this.mHookHelper.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewForeground, null, null);
                        }
                    }
                }
            }
            catch (Exception exception1)
            {
                ProjectData.SetProjectError(exception1);
                Exception exception = exception1;
                this.mErrOpt.ErrorOperate(this.mSubSysName, "Measure.MeasureAreaTool", "OnMouseDown", Conversions.ToString(Information.Err().Number), Information.Err().Source, Information.Err().Description, "", "", "");
                ProjectData.ClearProjectError();
            }
        }

        public override void OnMouseMove(int button, int shift, int x, int y)
        {
            try
            {
                if (this.mInUsing)
                {
                    if (this.mFeedback != null)
                    {
                        this.mFeedback.MoveTo(this.mHookHelper.ActiveView.ScreenDisplay.DisplayTransformation.ToMapPoint(x, y));
                    }
                    else
                    {
                        this.mInUsing = false;
                    }
                }
            }
            catch (Exception exception1)
            {
                ProjectData.SetProjectError(exception1);
                Exception exception = exception1;
                this.mErrOpt.ErrorOperate(this.mSubSysName, "Measure.MeasureAreaTool", "OnMouseMove", Conversions.ToString(Information.Err().Number), Information.Err().Source, Information.Err().Description, "", "", "");
                ProjectData.ClearProjectError();
            }
        }

        public override void Refresh(int hdc)
        {
            try
            {
                if (this.mFeedback != null)
                {
                    this.mFeedback.Refresh(hdc);
                }
            }
            catch (Exception exception1)
            {
                ProjectData.SetProjectError(exception1);
                Exception exception = exception1;
                this.mErrOpt.ErrorOperate(this.mSubSysName, "Measure.MeasureAreaTool", "Refresh", Conversions.ToString(Information.Err().Number), Information.Err().Source, Information.Err().Description, "", "", "");
                ProjectData.ClearProjectError();
            }
        }

        [DllImport("user32", CharSet=CharSet.Ansi, SetLastError=true, ExactSpelling=true)]
        private static extern int ReleaseCapture();
        private void ResetTool()
        {
            try
            {
                if (this.mHookHelper.ActiveView.ScreenDisplay.WindowDC == GetCapture())
                {
                    ReleaseCapture();
                }
                if (this.mFeedback != null)
                {
                    this.mFeedback.Stop();
                }
                this.mFeedback = null;
                this.mInUsing = false;
                this.mHookHelper.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewForeground, null, null);
            }
            catch (Exception exception1)
            {
                ProjectData.SetProjectError(exception1);
                Exception exception = exception1;
                this.mErrOpt.ErrorOperate(this.mSubSysName, "Measure.MeasureAreaTool", "ResetTool", Conversions.ToString(Information.Err().Number), Information.Err().Source, Information.Err().Description, "", "", "");
                ProjectData.ClearProjectError();
            }
        }

        [DllImport("user32", CharSet=CharSet.Ansi, SetLastError=true, ExactSpelling=true)]
        private static extern int SetCapture(int hWnd);

        public override bool Enabled
        {
            get
            {
                bool flag = false;
                try
                {
                    if (this.mHookHelper.ActiveView == null)
                    {
                        return false;
                    }
                    flag = true;
                }
                catch (Exception exception1)
                {
                    ProjectData.SetProjectError(exception1);
                    Exception exception = exception1;
                    this.mErrOpt.ErrorOperate(this.mSubSysName, "Measure.MeasureAreaTool", "Enabled", Conversions.ToString(Information.Err().Number), Information.Err().Source, Information.Err().Description, "", "", "");
                    ProjectData.ClearProjectError();
                }
                return flag;
            }
        }
    }
}

