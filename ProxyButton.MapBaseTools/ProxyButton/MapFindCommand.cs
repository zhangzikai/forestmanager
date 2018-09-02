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
    using Utilities;

    public class MapFindCommand : BaseCommand
    {
        private IHookHelper m_hookHelper;
        private const string mClassName = "ProxyButton.MapFindCommand";
        private ErrorOpt mErrOpt = UtilFactory.GetErrorOpt();
        private string mSubSysName = UtilFactory.GetConfigOpt().GetSystemName();
        private ICommand pCom;
        private ITool pTool;

        public MapFindCommand()
        {
            base.m_category = "地图浏览";
            base.m_caption = "查找";
            base.m_message = "地图查找";
            base.m_toolTip = "地图查找";
            base.m_name = "MapFindCommand";
            try
            {
                base.m_bitmap = new Bitmap(this.GetType(), "Find.bmp");
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
                this.pCom = new ControlsMapFindCommandClass();
                this.pCom.OnCreate(RuntimeHelpers.GetObjectValue(hook));
            }
        }
    }
}
