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

    public class MeasureDistanceTool : BaseTool
    {
        private const string mClassName = "Measure.MeasureDistanceTool";
        private ErrorOpt mErrOpt = UtilFactory.GetErrorOpt();
        private INewLineFeedback mFeedback;
        private GISFunFactory mFunFactory;
        private IHookHelper mHookHelper;
        private bool mInUsing;
        private string mSubSysName = UtilFactory.GetConfigOpt().GetSystemName();

        public MeasureDistanceTool()
        {
            base.m_category = "量算";
            base.m_caption = "距离量算";
            base.m_message = "距离量算工具";
            base.m_toolTip = "距离量算工具";
            base.m_name = "MeasureDistanceTool";
            try
            {
                base.m_bitmap = new Bitmap(this.GetType(), "MeasureDistance.bmp");
                base.m_cursor = new Cursor(this.GetType(), "MeasureDistance.cur");
            }
            catch (Exception exception1)
            {
                ProjectData.SetProjectError(exception1);
                Exception exception = exception1;
                this.mErrOpt.ErrorOperate(this.mSubSysName, "Measure.MeasureDistanceTool", "New", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
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
                this.mErrOpt.ErrorOperate(this.mSubSysName, "Measure.MeasureDistanceTool", "Deactivate", Conversions.ToString(Information.Err().Number), Information.Err().Source, Information.Err().Description, "", "", "");
                ProjectData.ClearProjectError();
            }
            return flag;
        }

        //protected override void Finalize()
        //{
        //    try
        //    {
        //        this.mHookHelper = null;
        //       // base.Finalize();
        //    }
        //    catch (Exception exception1)
        //    {
        //        ProjectData.SetProjectError(exception1);
        //        Exception exception = exception1;
        //        this.mErrOpt.ErrorOperate(this.mSubSysName, "Measure.MeasureDistanceTool", "Finalize", Conversions.ToString(Information.Err().Number), Information.Err().Source, Information.Err().Description, "", "", "");
        //        ProjectData.ClearProjectError();
        //    }
        //}
        ~MeasureDistanceTool() {
            try
            {
                this.mHookHelper = null;
                // base.Finalize();
            }
            catch (Exception exception1)
            {
                ProjectData.SetProjectError(exception1);
                Exception exception = exception1;
                this.mErrOpt.ErrorOperate(this.mSubSysName, "Measure.MeasureDistanceTool", "Finalize", Conversions.ToString(Information.Err().Number), Information.Err().Source, Information.Err().Description, "", "", "");
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
                this.mErrOpt.ErrorOperate(this.mSubSysName, "Measure.MeasureDistanceTool", "OnClick", Conversions.ToString(Information.Err().Number), Information.Err().Source, Information.Err().Description, "", "", "");
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
                this.mErrOpt.ErrorOperate(this.mSubSysName, "Measure.MeasureDistanceTool", "OnCreate", Conversions.ToString(Information.Err().Number), Information.Err().Source, Information.Err().Description, "", "", "");
                ProjectData.ClearProjectError();
            }
        }

        public override void OnDblClick()
        {
            try
            {
                if (this.mInUsing && (this.mFeedback != null))
                {
                    IGeometry polyline = this.mFeedback.Stop();
                    this.ResetTool();
                    if ((polyline != null) && !polyline.IsEmpty)
                    {
                        IRgbColor color = new RgbColorClass();
                        color.Red = 0xff;
                        color.Green = 0;
                        color.Blue = 0;
                        ILineSymbol pLineSymbol = new SimpleLineSymbolClass();
                        pLineSymbol.Color = color;
                        pLineSymbol.Width = 2.0;
                        IActiveView activeView = this.mHookHelper.ActiveView;
                        IGraphicsLayer pGraphicsLayer = GISFunFactory.LayerFun.FindGraphicsLayer((IBasicMap) this.mHookHelper.FocusMap, "<Measure>");
                        IElement pElement = null;
                        ILineElement element2 = null;
                        if (pGraphicsLayer == null)
                        {
                            activeView.ScreenDisplay.StartDrawing(0, -1);
                            activeView.ScreenDisplay.SetSymbol((ISymbol) pLineSymbol);
                            activeView.ScreenDisplay.DrawPolyline(polyline);
                            activeView.ScreenDisplay.FinishDrawing();
                        }
                        else
                        {
                            pElement = new LineElementClass();
                            pElement.Geometry = polyline;
                            element2 = (ILineElement) pElement;
                            element2.Symbol = pLineSymbol;
                            GISFunFactory.ElementFun.AddElement(pGraphicsLayer, pElement, true, true);
                            activeView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, pElement, null);
                        }
                        FormMeasureDistance distance = new FormMeasureDistance();
                        distance.SetMeasureResult(activeView, pElement, polyline, pLineSymbol);
                        distance.ShowDialog();
                        distance = null;
                        this.mHookHelper.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewForeground, null, null);
                    }
                }
            }
            catch (Exception exception1)
            {
                ProjectData.SetProjectError(exception1);
                Exception exception = exception1;
                this.mErrOpt.ErrorOperate(this.mSubSysName, "Measure.MeasureDistanceTool", "OnDblClick", Conversions.ToString(Information.Err().Number), Information.Err().Source, Information.Err().Description, "", "", "");
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
                this.mErrOpt.ErrorOperate(this.mSubSysName, "Measure.MeasureDistanceTool", "OnKeyDown", Conversions.ToString(Information.Err().Number), Information.Err().Source, Information.Err().Description, "", "", "");
                ProjectData.ClearProjectError();
            }
        }

        public override void OnMouseDown(int button, int shift, int x, int y)
        {
            try
            {
                if (this.mHookHelper.ActiveView != null)
                {
                    if (button == 2)
                    {
                        if (this.mInUsing && (this.mFeedback != null))
                        {
                            IGeometry polyline = this.mFeedback.Stop();
                            this.ResetTool();
                            if ((polyline != null) && !polyline.IsEmpty)
                            {
                                IRgbColor color = new RgbColorClass();
                                color.Red = 0xff;
                                color.Green = 0;
                                color.Blue = 0;
                                ILineSymbol pLineSymbol = new SimpleLineSymbolClass();
                                pLineSymbol.Color = color;
                                pLineSymbol.Width = 2.0;
                                IActiveView activeView = this.mHookHelper.ActiveView;
                                IGraphicsLayer pGraphicsLayer = GISFunFactory.LayerFun.FindGraphicsLayer((IBasicMap) this.mHookHelper.FocusMap, "<Measure>");
                                IElement pElement = null;
                                ILineElement element2 = null;
                                if (pGraphicsLayer == null)
                                {
                                    activeView.ScreenDisplay.StartDrawing(0, -1);
                                    activeView.ScreenDisplay.SetSymbol((ISymbol) pLineSymbol);
                                    activeView.ScreenDisplay.DrawPolyline(polyline);
                                    activeView.ScreenDisplay.FinishDrawing();
                                }
                                else
                                {
                                    pElement = new LineElementClass();
                                    pElement.Geometry = polyline;
                                    element2 = (ILineElement) pElement;
                                    element2.Symbol = pLineSymbol;
                                    GISFunFactory.ElementFun.AddElement(pGraphicsLayer, pElement, true, true);
                                    activeView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, pElement, null);
                                }
                                FormMeasureDistance distance = new FormMeasureDistance();
                                distance.SetMeasureResult(activeView, pElement, polyline, pLineSymbol);
                                distance.ShowDialog();
                                distance = null;
                                this.mHookHelper.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewForeground, null, null);
                            }
                        }
                    }
                    else if (button == 1)
                    {
                        IPoint point = this.mHookHelper.ActiveView.ScreenDisplay.DisplayTransformation.ToMapPoint(x, y);
                        if (this.mFeedback == null)
                        {
                            this.mFeedback = new NewLineFeedbackClass();
                            ISimpleLineSymbol symbol = (ISimpleLineSymbol) this.mFeedback.Symbol;
                            IRgbColor color2 = new RgbColorClass();
                            color2.Red = 0xff;
                            color2.Green = 0;
                            color2.Blue = 0;
                            symbol.Color = color2;
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
                }
            }
            catch (Exception exception1)
            {
                ProjectData.SetProjectError(exception1);
                Exception exception = exception1;
                this.mErrOpt.ErrorOperate(this.mSubSysName, "Measure.MeasureDistanceTool", "OnMouseDown", Conversions.ToString(Information.Err().Number), Information.Err().Source, Information.Err().Description, "", "", "");
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
                this.mErrOpt.ErrorOperate(this.mSubSysName, "Measure.MeasureDistanceTool", "OnMouseMove", Conversions.ToString(Information.Err().Number), Information.Err().Source, Information.Err().Description, "", "", "");
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
                this.mErrOpt.ErrorOperate(this.mSubSysName, "Measure.MeasureDistanceTool", "Refresh", Conversions.ToString(Information.Err().Number), Information.Err().Source, Information.Err().Description, "", "", "");
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
                this.mErrOpt.ErrorOperate(this.mSubSysName, "Measure.MeasureDistanceTool", "ResetTool", Conversions.ToString(Information.Err().Number), Information.Err().Source, Information.Err().Description, "", "", "");
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
                    this.mErrOpt.ErrorOperate(this.mSubSysName, "Measure.MeasureDistanceTool", "Enabled", Conversions.ToString(Information.Err().Number), Information.Err().Source, Information.Err().Description, "", "", "");
                    ProjectData.ClearProjectError();
                }
                return flag;
            }
        }
    }
}

