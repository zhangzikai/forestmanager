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
    using System.Windows.Forms;
    using Utilities;

    public class MeasureElementTool2 : BaseTool
    {
        private const string mClassName = "Measure.MeasureElementTool";
        private ErrorOpt mErrOpt = UtilFactory.GetErrorOpt();
        private FormMeasure mFormMeasure;
        private GISFunFactory mFunFactory;
        private IHookHelper mHookHelper;
        private string mSubSysName = UtilFactory.GetConfigOpt().GetSystemName();

        public MeasureElementTool2(FormMeasure form)
        {
            base.m_category = "量算";
            base.m_caption = "元素量算";
            base.m_message = "元素量算工具";
            base.m_toolTip = "元素量算工具";
            base.m_name = "MeasureElementTool2";
            this.mFormMeasure = form;
            try
            {
                base.m_bitmap = new Bitmap(this.GetType(), "Measure.MeasureElement.bmp");
                base.m_cursor = new Cursor(this.GetType(), "Measure.MeasureElement.cur");
            }
            catch (Exception exception1)
            {
                ProjectData.SetProjectError(exception1);
                Exception exception = exception1;
                this.mErrOpt.ErrorOperate(this.mSubSysName, "Measure.MeasureElementTool", "New", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                ProjectData.ClearProjectError();
            }
            this.mHookHelper = new HookHelperClass();
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
        //        this.mErrOpt.ErrorOperate(this.mSubSysName, "Measure.MeasureElementTool", "Finalize", Conversions.ToString(Information.Err().Number), Information.Err().Source, Information.Err().Description, "", "", "");
        //        ProjectData.ClearProjectError();
        //    }
        //}
        ~MeasureElementTool2() {
            try
            {
                this.mHookHelper = null;
                // base.Finalize();
            }
            catch (Exception exception1)
            {
                ProjectData.SetProjectError(exception1);
                Exception exception = exception1;
                this.mErrOpt.ErrorOperate(this.mSubSysName, "Measure.MeasureElementTool", "Finalize", Conversions.ToString(Information.Err().Number), Information.Err().Source, Information.Err().Description, "", "", "");
                ProjectData.ClearProjectError();
            }
        }

        private void MeasureElement(IElement pElement, string sTpye, ISymbol pSymbol)
        {
            try
            {
                if (pElement != null)
                {
                    IActiveView activeView = this.mHookHelper.ActiveView;
                    GISFunFactory.FlashFun.FlashElement(this.mHookHelper.FocusMap, pElement, 20L, false);
                    IGeometry pGeometry = pElement.Geometry;
                    if (sTpye == "Marker")
                    {
                        this.mFormMeasure.SetMeasureResult(activeView, null, pGeometry, (IMarkerSymbol) pSymbol);
                    }
                    else if (sTpye == "Polyline")
                    {
                        this.mFormMeasure.SetMeasureResult(activeView, null, pGeometry, (ILineSymbol) pSymbol);
                    }
                    else if (sTpye == "Polygon")
                    {
                        this.mFormMeasure.SetMeasureResult(activeView, null, pGeometry, (IFillSymbol) pSymbol);
                    }
                }
            }
            catch (Exception exception1)
            {
                ProjectData.SetProjectError(exception1);
                Exception exception = exception1;
                this.mErrOpt.ErrorOperate(this.mSubSysName, "Measure.MeasureElementTool", "MeasureElement", Conversions.ToString(Information.Err().Number), Information.Err().Source, Information.Err().Description, "", "", "");
                ProjectData.ClearProjectError();
            }
        }

        public override void OnClick()
        {
            try
            {
            }
            catch (Exception exception1)
            {
                ProjectData.SetProjectError(exception1);
                Exception exception = exception1;
                this.mErrOpt.ErrorOperate(this.mSubSysName, "Measure.MeasureElementTool", "OnClick", Conversions.ToString(Information.Err().Number), Information.Err().Source, Information.Err().Description, "", "", "");
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
                this.mErrOpt.ErrorOperate(this.mSubSysName, "Measure.MeasureElementTool", "OnCreate", Conversions.ToString(Information.Err().Number), Information.Err().Source, Information.Err().Description, "", "", "");
                ProjectData.ClearProjectError();
            }
        }

        public override void OnMouseDown(int button, int shift, int x, int y)
        {
            try
            {
                if ((this.mHookHelper.ActiveView != null) && (button == 1))
                {
                    IActiveView activeView = this.mHookHelper.ActiveView;
                    IPoint point = activeView.ScreenDisplay.DisplayTransformation.ToMapPoint(x, y);
                    double dPixelUnits = 3.0;
                    dPixelUnits = GISFunFactory.UnitFun.ConvertPixelsToMapUnits(activeView, dPixelUnits, false);
                    IEnumElement element2 = ((IGraphicsContainer) activeView).LocateElements(point, dPixelUnits);
                    if (element2 != null)
                    {
                        element2.Reset();
                        for (IElement element = element2.Next(); element != null; element = element2.Next())
                        {
                            if ((!element.Locked && (element.Geometry != null)) && !element.Geometry.IsEmpty)
                            {
                                ISymbol symbol;
                                if (element is IMarkerElement)
                                {
                                    symbol = (ISymbol) ((IMarkerElement) element).Symbol;
                                    this.MeasureElement(element, "Marker", symbol);
                                    return;
                                }
                                if (element is ILineElement)
                                {
                                    symbol = (ISymbol) ((ILineElement) element).Symbol;
                                    this.MeasureElement(element, "Polyline", symbol);
                                    return;
                                }
                                if (element is IFillShapeElement)
                                {
                                    symbol = (ISymbol) ((IFillShapeElement) element).Symbol;
                                    this.MeasureElement(element, "Polygon", symbol);
                                    return;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception exception1)
            {
                ProjectData.SetProjectError(exception1);
                Exception exception = exception1;
                this.mErrOpt.ErrorOperate(this.mSubSysName, "Measure.MeasureElementTool", "OnMouseDown", Conversions.ToString(Information.Err().Number), Information.Err().Source, Information.Err().Description, "", "", "");
                ProjectData.ClearProjectError();
            }
        }

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
                    this.mErrOpt.ErrorOperate(this.mSubSysName, "Measure.MeasureElementTool", "Enabled", Conversions.ToString(Information.Err().Number), Information.Err().Source, Information.Err().Description, "", "", "");
                    ProjectData.ClearProjectError();
                }
                return flag;
            }
        }
    }
}

