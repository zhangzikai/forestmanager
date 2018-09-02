namespace Measure
{
    using ESRI.ArcGIS.ADF.BaseClasses;
    using ESRI.ArcGIS.Carto;
    using ESRI.ArcGIS.Controls;
    using ESRI.ArcGIS.Geometry;
    using FunFactory;
    using Microsoft.VisualBasic;
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Drawing;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;
    using Utilities;

    public class MeasureElementTool : BaseTool
    {
        private const string mClassName = "Measure.MeasureElementTool";
        private ErrorOpt mErrOpt = UtilFactory.GetErrorOpt();
        private GISFunFactory mFunFactory;
        private IHookHelper mHookHelper;
        private string mSubSysName = UtilFactory.GetConfigOpt().GetSystemName();

        public MeasureElementTool()
        {
            base.m_category = "量算";
            base.m_caption = "元素量算";
            base.m_message = "元素量算工具";
            base.m_toolTip = "元素量算工具";
            base.m_name = "MeasureElementTool";
            try
            {
                base.m_bitmap = new Bitmap(this.GetType(), "MeasureElement.bmp");
                base.m_cursor = new Cursor(this.GetType(), "MeasureElement.cur");
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
        //        //base.Finalize();
        //    }
        //    catch (Exception exception1)
        //    {
        //        ProjectData.SetProjectError(exception1);
        //        Exception exception = exception1;
        //        this.mErrOpt.ErrorOperate(this.mSubSysName, "Measure.MeasureElementTool", "Finalize", Conversions.ToString(Information.Err().Number), Information.Err().Source, Information.Err().Description, "", "", "");
        //        ProjectData.ClearProjectError();
        //    }
        //}
        ~MeasureElementTool()
        {
            try
            {
                this.mHookHelper = null;
                //base.Finalize();
            }
            catch (Exception exception1)
            {
                ProjectData.SetProjectError(exception1);
                Exception exception = exception1;
                this.mErrOpt.ErrorOperate(this.mSubSysName, "Measure.MeasureElementTool", "Finalize", Conversions.ToString(Information.Err().Number), Information.Err().Source, Information.Err().Description, "", "", "");
                ProjectData.ClearProjectError();
            }
        }


        private void MeasureElement(IElement pElement, string sTpye)
        {
            try
            {
                if (pElement != null)
                {
                    IActiveView activeView = this.mHookHelper.ActiveView;
                    GISFunFactory.FlashFun.FlashElement(this.mHookHelper.FocusMap, pElement, 200L, false);
                    IGeometry pGeometry = pElement.Geometry;
                    if (sTpye == "Marker")
                    {
                        FormMeasureMarker marker = new FormMeasureMarker();
                        marker.SetMeasureResult(activeView, pElement, pGeometry, null);
                        marker.ShowDialog();
                        marker = null;
                    }
                    else if (sTpye == "Polyline")
                    {
                        FormMeasureDistance distance = new FormMeasureDistance();
                        distance.SetMeasureResult(activeView, pElement, pGeometry, null);
                        distance.ShowDialog();
                        distance = null;
                    }
                    else if (sTpye == "Polygon")
                    {
                        FormMeasureArea area = new FormMeasureArea();
                        area.SetMeasureResult(activeView, pElement, pGeometry, null);
                        area.ShowDialog();
                        area = null;
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
                            if (!element.Locked && ((element.Geometry != null) && !element.Geometry.IsEmpty))
                            {
                                if (element is IMarkerElement)
                                {
                                    this.MeasureElement(element, "Marker");
                                    return;
                                }
                                if (element is ILineElement)
                                {
                                    this.MeasureElement(element, "Polyline");
                                    return;
                                }
                                if (element is IFillShapeElement)
                                {
                                    this.MeasureElement(element, "Polygon");
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

