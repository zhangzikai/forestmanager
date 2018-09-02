namespace Measure
{
    using ESRI.ArcGIS.ADF.BaseClasses;
    using ESRI.ArcGIS.Carto;
    using ESRI.ArcGIS.Controls;
    using FunFactory;
    using Microsoft.VisualBasic;
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Diagnostics;
    using System.Drawing;
    using System.Runtime.CompilerServices;
    using Utilities;

    public class ClearMeasureCommand : BaseCommand
    {
        private const string mClassName = "Measure.ClearMeasureCommand";
        private ErrorOpt mErrOpt = UtilFactory.GetErrorOpt();
        private GISFunFactory mFunFactory;
        private IHookHelper mHookHelper;
        private IGraphicsLayer mMeasureGLayer;
        private string mSubSysName = UtilFactory.GetConfigOpt().GetSystemName();

        public ClearMeasureCommand()
        {
            base.m_category = "量算";
            base.m_caption = "清除量算";
            base.m_message = "清除量算结果";
            base.m_toolTip = "清除量算结果";
            base.m_name = "SelectFeaturesTool";
            try
            {
                base.m_bitmap = new Bitmap(this.GetType(), "Measure.ClearMeasure.bmp");
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
        //        this.mErrOpt.ErrorOperate(this.mSubSysName, "Measure.ClearMeasureCommand", "Finalize", Conversions.ToString(Information.Err().Number), Information.Err().Source, Information.Err().Description, "", "", "");
        //        ProjectData.ClearProjectError();
        //    }
        //}
        ~ClearMeasureCommand() {
            try
            {
                this.mHookHelper = null;
                //base.Finalize();
            }
            catch (Exception exception1)
            {
                ProjectData.SetProjectError(exception1);
                Exception exception = exception1;
                this.mErrOpt.ErrorOperate(this.mSubSysName, "Measure.ClearMeasureCommand", "Finalize", Conversions.ToString(Information.Err().Number), Information.Err().Source, Information.Err().Description, "", "", "");
                ProjectData.ClearProjectError();
            }
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
                        IGraphicsLayer mMeasureGLayer;
                        if (this.mMeasureGLayer == null)
                        {
                            mMeasureGLayer = GISFunFactory.LayerFun.FindGraphicsLayer((IBasicMap) this.mHookHelper.FocusMap, "<Measure>");
                            if (mMeasureGLayer == null)
                            {
                                return;
                            }
                        }
                        else
                        {
                            mMeasureGLayer = this.mMeasureGLayer;
                        }
                        ((IGraphicsContainerSelect) activeView).UnselectAllElements();
                        IGraphicsContainer container = (IGraphicsContainer) mMeasureGLayer;
                        container.Reset();
                        for (IElement element = container.Next(); element != null; element = container.Next())
                        {
                            activeView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, element, null);
                            GISFunFactory.ElementFun.DeleteElement(activeView, element);
                        }
                        activeView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, null);
                    }
                }
            }
            catch (Exception exception1)
            {
                ProjectData.SetProjectError(exception1);
                Exception exception = exception1;
                this.mErrOpt.ErrorOperate(this.mSubSysName, "Measure.ClearMeasureCommand", "OnClick", Conversions.ToString(Information.Err().Number), Information.Err().Source, Information.Err().Description, "", "", "");
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
                this.mErrOpt.ErrorOperate(this.mSubSysName, "Measure.ClearMeasureCommand", "OnCreate", Conversions.ToString(Information.Err().Number), Information.Err().Source, Information.Err().Description, "", "", "");
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
                    this.mMeasureGLayer = GISFunFactory.LayerFun.FindGraphicsLayer((IBasicMap) this.mHookHelper.FocusMap, "<Measure>");
                    if (this.mMeasureGLayer == null)
                    {
                        this.mMeasureGLayer = GISFunFactory.LayerFun.FindGraphicsLayer((IBasicMap) this.mHookHelper.FocusMap, "<Default>");
                        if (this.mMeasureGLayer == null)
                        {
                            return false;
                        }
                    }
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
                    this.mErrOpt.ErrorOperate(this.mSubSysName, "Measure.ClearMeasureCommand", "Enabled", Conversions.ToString(Information.Err().Number), Information.Err().Source, Information.Err().Description, "", "", "");
                    ProjectData.ClearProjectError();
                }
                return flag;
            }
        }
    }
}

