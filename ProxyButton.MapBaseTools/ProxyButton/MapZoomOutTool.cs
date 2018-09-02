﻿namespace ProxyButton
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

    public class MapZoomOutTool : BaseTool
    {
        private IHookHelper m_hookHelper;
        private const string mClassName = "ProxyButton.MapZoomOutTool";
        private ErrorOpt mErrOpt = UtilFactory.GetErrorOpt();
        private string mSubSysName = UtilFactory.GetConfigOpt().GetSystemName();
        private ICommand pCom;
        private ITool pTool;

        public MapZoomOutTool()
        {
            base.m_category = "地图浏览";
            base.m_caption = "缩小";
            base.m_message = "地图缩小";
            base.m_toolTip = "地图缩小";
            base.m_name = "MapZoomOutTool";
            try
            {
                base.m_bitmap = new Bitmap(this.GetType(), "ProxyButton.ZoomOut.bmp");
                base.m_cursor = new Cursor(this.GetType(), "ProxyButton.ZoomOut.cur");
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
                this.pTool = new ControlsMapZoomOutToolClass();
                this.pCom = (ICommand) this.pTool;
                this.pCom.OnCreate(RuntimeHelpers.GetObjectValue(hook));
            }
        }

        public override void OnMouseDown(int Button, int Shift, int X, int Y)
        {
            this.pTool.OnMouseDown(Button, Shift, X, Y);
        }

        public override void OnMouseMove(int Button, int Shift, int X, int Y)
        {
            this.pTool.OnMouseMove(Button, Shift, X, Y);
        }

        public override void OnMouseUp(int Button, int Shift, int X, int Y)
        {
            this.pTool.OnMouseUp(Button, Shift, X, Y);
        }
    }
}
