namespace Measure
{
    using ESRI.ArcGIS.ADF.BaseClasses;
    using ESRI.ArcGIS.Controls;
    using ESRI.ArcGIS.Display;
    using FunFactory;
    using Microsoft.VisualBasic;
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Drawing;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;
    using Utilities;

    public class MeasureTool : BaseTool
    {
        private static List<WeakReference> __ENCList = new List<WeakReference>();
        [AccessedThroughProperty("pFormMeasure")]
        private FormMeasure _pFormMeasure;
        private const string mClassName = "Measure.MeasureTool";
        private ErrorOpt mErrOpt;
        private INewLineFeedback mFeedback;
        private GISFunFactory mFunFactory;
        private IHookHelper mHookHelper;
        private bool mInUsing;
        private string mSubSysName;

        public MeasureTool()
        {
            List<WeakReference> list = __ENCList;
            lock (list)
            {
                __ENCList.Add(new WeakReference(this));
            }
            this.mSubSysName = UtilFactory.GetConfigOpt().GetSystemName();
            this.mErrOpt = UtilFactory.GetErrorOpt();
            base.m_category = "量算";
            base.m_caption = "量算工具";
            base.m_message = "量算工具";
            base.m_toolTip = "量算工具";
            base.m_name = "MeasureTool";
            try
            {
                base.m_bitmap = new Bitmap(this.GetType(), "MeasureDistance.bmp");
                base.m_cursor = new Cursor(this.GetType(), "MeasureDistance.cur");
            }
            catch (Exception exception1)
            {
                ProjectData.SetProjectError(exception1);
                Exception exception = exception1;
                this.mErrOpt.ErrorOperate(this.mSubSysName, "Measure.MeasureTool", "New", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                ProjectData.ClearProjectError();
            }
            this.mHookHelper = new HookHelperClass();
        }

        public override bool Deactivate()
        {
            bool flag = false ;
            try
            {
                flag = true;
            }
            catch (Exception exception1)
            {
                ProjectData.SetProjectError(exception1);
                Exception exception = exception1;
                this.mErrOpt.ErrorOperate(this.mSubSysName, "Measure.MeasureTool", "Deactivate", Conversions.ToString(Information.Err().Number), Information.Err().Source, Information.Err().Description, "", "", "");
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
        //        this.mErrOpt.ErrorOperate(this.mSubSysName, "Measure.MeasureTool", "Finalize", Conversions.ToString(Information.Err().Number), Information.Err().Source, Information.Err().Description, "", "", "");
        //        ProjectData.ClearProjectError();
        //    }
        //}
        ~MeasureTool() {
            try
            {
                this.mHookHelper = null;
                // base.Finalize();
            }
            catch (Exception exception1)
            {
                ProjectData.SetProjectError(exception1);
                Exception exception = exception1;
                this.mErrOpt.ErrorOperate(this.mSubSysName, "Measure.MeasureTool", "Finalize", Conversions.ToString(Information.Err().Number), Information.Err().Source, Information.Err().Description, "", "", "");
                ProjectData.ClearProjectError();
            }
        }

        [DllImport("user32", CharSet=CharSet.Ansi, SetLastError=true, ExactSpelling=true)]
        private static extern int GetCapture();
        public override void OnClick()
        {
            try
            {
                if (this.pFormMeasure == null)
                {
                    this.pFormMeasure = new FormMeasure();
                    this.pFormMeasure.Hook = RuntimeHelpers.GetObjectValue(this.mHookHelper.Hook);
                    this.pFormMeasure.InitialControls();
                }
                this.pFormMeasure.TopLevel = true;
                this.pFormMeasure.TopMost = true;
                this.pFormMeasure.Show();
            }
            catch (Exception exception1)
            {
                ProjectData.SetProjectError(exception1);
                Exception exception = exception1;
                this.mErrOpt.ErrorOperate(this.mSubSysName, "Measure.MeasureTool", "OnClick", Conversions.ToString(Information.Err().Number), Information.Err().Source, Information.Err().Description, "", "", "");
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
                this.mErrOpt.ErrorOperate(this.mSubSysName, "Measure.MeasureTool", "OnCreate", Conversions.ToString(Information.Err().Number), Information.Err().Source, Information.Err().Description, "", "", "");
                ProjectData.ClearProjectError();
            }
        }

        private void pFormMeasure_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.pFormMeasure = null;
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
                this.mErrOpt.ErrorOperate(this.mSubSysName, "Measure.MeasureTool", "Refresh", Conversions.ToString(Information.Err().Number), Information.Err().Source, Information.Err().Description, "", "", "");
                ProjectData.ClearProjectError();
            }
        }

        [DllImport("user32", CharSet=CharSet.Ansi, SetLastError=true, ExactSpelling=true)]
        private static extern int ReleaseCapture();
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
                    this.mErrOpt.ErrorOperate(this.mSubSysName, "Measure.MeasureTool", "Enabled", Conversions.ToString(Information.Err().Number), Information.Err().Source, Information.Err().Description, "", "", "");
                    ProjectData.ClearProjectError();
                }
                return flag;
            }
        }

        private FormMeasure pFormMeasure
        {
            [DebuggerNonUserCode]
            get
            {
                return this._pFormMeasure;
            }
            [MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
            set
            {
                FormClosedEventHandler handler = new FormClosedEventHandler(this.pFormMeasure_FormClosed);
                if (this._pFormMeasure != null)
                {
                    this._pFormMeasure.FormClosed -= handler;
                }
                this._pFormMeasure = value;
                if (this._pFormMeasure != null)
                {
                    this._pFormMeasure.FormClosed += handler;
                }
            }
        }
    }
}

