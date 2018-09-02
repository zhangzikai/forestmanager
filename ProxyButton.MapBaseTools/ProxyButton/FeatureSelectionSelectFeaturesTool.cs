namespace ProxyButton
{
    using ESRI.ArcGIS.ADF.BaseClasses;
    using ESRI.ArcGIS.Controls;
    using ESRI.ArcGIS.SystemUI;
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.Diagnostics;
    using System.Drawing;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;
    using Utilities;

    public class FeatureSelectionSelectFeaturesTool : BaseTool
    {
        private IHookHelper m_hookHelper;
        private const string mClassName = "ProxyButton.FeatureSelectionSelectFeaturesTool";
        private ErrorOpt mErrOpt = UtilFactory.GetErrorOpt();
        private string mSubSysName = UtilFactory.GetConfigOpt().GetSystemName();
        private ICommand pCom;
        private ITool pTool;

        public FeatureSelectionSelectFeaturesTool()
        {
            base.m_category = "要素选择";
            base.m_caption = "选择要素";
            base.m_message = "通过点击或拉框选择要素";
            base.m_toolTip = "选择要素";
            base.m_name = "SelectFeaturesTool";
            try
            {
                base.m_bitmap = new Bitmap(this.GetType(), "ProxyButton.SelectFeatures.bmp");
                base.m_cursor = new Cursor(this.GetType(), "ProxyButton.SelectFeatures.cur");
            }
            catch (Exception exception1)
            {
                ProjectData.SetProjectError(exception1);
                Exception exception = exception1;
                Trace.WriteLine(exception.Message, "Invalid Bitmap");
                ProjectData.ClearProjectError();
            }
        }

        public override void OnClick()
        {
            this.pCom.OnClick();
        }

        public override void OnCreate(object hook)
        {
            if (this.m_hookHelper == null)
            {
                this.m_hookHelper = new HookHelperClass();
            }
            if (hook != null)
            {
                try
                {
                    this.m_hookHelper.Hook = RuntimeHelpers.GetObjectValue(hook);
                    if (this.m_hookHelper.ActiveView == null)
                    {
                        this.m_hookHelper = null;
                    }
                }
                catch (Exception exception1)
                {
                    ProjectData.SetProjectError(exception1);
                    this.m_hookHelper = null;
                    ProjectData.ClearProjectError();
                }
                if (this.m_hookHelper == null)
                {
                    base.m_enabled = false;
                }
                else
                {
                    base.m_enabled = true;
                }
                this.pTool = new ControlsSelectFeaturesToolClass();
                this.pCom = (ICommand) this.pTool;
                this.pCom.OnCreate(RuntimeHelpers.GetObjectValue(hook));
            }
        }

        public override void OnMouseDown(int Button, int Shift, int X, int Y)
        {
            base.m_cursor = new Cursor(this.GetType(), "ProxyButton.SelectFeaturesMDown.cur");
            this.pTool.OnMouseDown(Button, Shift, X, Y);
        }

        public override void OnMouseMove(int Button, int Shift, int X, int Y)
        {
            this.pTool.OnMouseMove(Button, Shift, X, Y);
        }

        public override void OnMouseUp(int Button, int Shift, int X, int Y)
        {
            base.m_cursor = new Cursor(this.GetType(), "ProxyButton.SelectFeatures.cur");
            this.pTool.OnMouseUp(Button, Shift, X, Y);
        }
    }
}

