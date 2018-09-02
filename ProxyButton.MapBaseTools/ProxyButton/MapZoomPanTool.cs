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

    public class MapZoomPanTool : BaseTool
    {
        private IHookHelper m_hookHelper;
        private const string mClassName = "ProxyButton.MapZoomPanTool";
        private ErrorOpt mErrOpt = UtilFactory.GetErrorOpt();
        private string mSubSysName = UtilFactory.GetConfigOpt().GetSystemName();
        private ICommand pCom;
        private ITool pTool;

        public MapZoomPanTool()
        {
            base.m_category = "地图浏览";
            base.m_caption = "缩放";
            base.m_message = "地图缩放";
            base.m_toolTip = "地图缩放";
            base.m_name = "MapZoomPanTool";
            try
            {
                base.m_bitmap = new Bitmap(this.GetType(), "zoominout.bmp");
                base.m_cursor = new Cursor(this.GetType(), "ZOOMINOUT.CUR");
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
                this.pTool = new ControlsMapZoomPanToolClass();
                this.pCom = (ICommand) this.pTool;
                this.pCom.OnCreate(RuntimeHelpers.GetObjectValue(hook));
            }
        }

        public override void OnMouseDown(int Button, int Shift, int X, int Y)
        {
            base.m_cursor = new Cursor(this.GetType(), "ZOOMINOUTMOVE.CUR");
            this.pTool.OnMouseDown(Button, Shift, X, Y);
        }

        public override void OnMouseMove(int Button, int Shift, int X, int Y)
        {
            base.m_cursor = new Cursor(this.GetType(), "ZOOMINOUT.CUR");
            this.pTool.OnMouseMove(Button, Shift, X, Y);
        }

        public override void OnMouseUp(int Button, int Shift, int X, int Y)
        {
            base.m_cursor = new Cursor(this.GetType(), "ZOOMINOUT.CUR");
            this.pTool.OnMouseUp(Button, Shift, X, Y);
        }
    }
}

