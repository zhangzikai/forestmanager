namespace Measure
{
    using ESRI.ArcGIS.ADF.BaseClasses;
    using ESRI.ArcGIS.Carto;
    using ESRI.ArcGIS.Controls;
    using ESRI.ArcGIS.esriSystem;
    using FunFactory;
    using Microsoft.VisualBasic;
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Diagnostics;
    using System.Drawing;
    using System.Runtime.CompilerServices;
    using Utilities;

    public class ConvertElementCommand : BaseCommand
    {
        private const string mClassName = "Measure.ConvertElementCommand";
        private ErrorOpt mErrOpt = UtilFactory.GetErrorOpt();
        private GISFunFactory mFunFactory;
        private IHookHelper mHookHelper;
        private IGraphicsLayer mMeasureGLayer;
        private string mSubSysName = UtilFactory.GetConfigOpt().GetSystemName();

        public ConvertElementCommand()
        {
            base.m_category = "量算";
            base.m_caption = "转为元素";
            base.m_message = "转为元素";
            base.m_toolTip = "转为元素";
            base.m_name = "ConvertElementCommand";
            try
            {
                base.m_bitmap = new Bitmap(this.GetType(), "ConvertDx.bmp");
            }
            catch (Exception exception1)
            {
                ProjectData.SetProjectError(exception1);
                Exception exception = exception1;
                Trace.WriteLine(exception.Message, "Invalid Bitmap");
                ProjectData.ClearProjectError();
            }
            this.mHookHelper = new HookHelperClass();
        }

        public override void OnClick()
        {
            try
            {
                IActiveView activeView = this.mHookHelper.ActiveView;
                if (activeView != null)
                {
                    ILayer basicGraphicsLayer = (ILayer) activeView.FocusMap.BasicGraphicsLayer;
                    if (!((basicGraphicsLayer == null) | !basicGraphicsLayer.Visible))
                    {
                        IGraphicsLayer layer2 = GISFunFactory.LayerFun.FindGraphicsLayer((IBasicMap) this.mHookHelper.FocusMap, "<Measure>");
                        if (layer2 != null)
                        {
                            ((IGraphicsContainerSelect) activeView).UnselectAllElements();
                            IGraphicsContainer container = (IGraphicsContainer) layer2;
                            container.Reset();
                            for (IElement element = container.Next(); element != null; element = container.Next())
                            {
                                IElement pElement = (IElement) GISFunFactory.SystemFun.CloneObejct((IClone) element);
                                if (Measures.OperationStack == null)
                                {
                                    GISFunFactory.ElementFun.AddElement(activeView, pElement, true, true);
                                }
                                activeView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, element, null);
                                GISFunFactory.ElementFun.DeleteElement(activeView, element);
                                container.Reset();
                            }
                            activeView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, null);
                        }
                    }
                }
            }
            catch (Exception exception1)
            {
                ProjectData.SetProjectError(exception1);
                Exception exception = exception1;
                this.mErrOpt.ErrorOperate(this.mSubSysName, "Measure.ConvertElementCommand", "OnClick", Conversions.ToString(Information.Err().Number), Information.Err().Source, Information.Err().Description, "", "", "");
                ProjectData.ClearProjectError();
            }
        }

        public override void OnCreate(object hook)
        {
            try
            {
                this.mHookHelper.Hook = RuntimeHelpers.GetObjectValue(hook);
                this.mMeasureGLayer = GISFunFactory.LayerFun.FindGraphicsLayer((IBasicMap) this.mHookHelper.FocusMap, "<Measure>");
            }
            catch (Exception exception1)
            {
                ProjectData.SetProjectError(exception1);
                Exception exception = exception1;
                this.mErrOpt.ErrorOperate(this.mSubSysName, "Measure.ConvertElementCommand", "OnCreate", Conversions.ToString(Information.Err().Number), Information.Err().Source, Information.Err().Description, "", "", "");
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
                    if (this.mMeasureGLayer == null)
                    {
                        return false;
                    }
                    ILayer basicGraphicsLayer = (ILayer) this.mHookHelper.ActiveView.FocusMap.BasicGraphicsLayer;
                    if ((basicGraphicsLayer != null) & basicGraphicsLayer.Visible)
                    {
                        return true;
                    }
                    flag = false;
                }
                catch (Exception exception1)
                {
                    ProjectData.SetProjectError(exception1);
                    Exception exception = exception1;
                    this.mErrOpt.ErrorOperate(this.mSubSysName, "Measure.ConvertElementCommand", "Enabled", Conversions.ToString(Information.Err().Number), Information.Err().Source, Information.Err().Description, "", "", "");
                    ProjectData.ClearProjectError();
                }
                return flag;
            }
        }
    }
}

