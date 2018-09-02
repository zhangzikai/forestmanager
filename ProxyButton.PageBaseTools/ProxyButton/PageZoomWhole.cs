namespace ProxyButton
{
    using ESRI.ArcGIS.ADF.BaseClasses;
    using ESRI.ArcGIS.Controls;
    using ESRI.ArcGIS.SystemUI;
    using System;
    using System.Diagnostics;

    public sealed class PageZoomWhole : BaseCommand
    {
        private ICommand _command;
        private IHookHelper m_hookHelper = null;

        public PageZoomWhole()
        {
            base.m_category = "";
            base.m_caption = "";
            base.m_message = "";
            base.m_toolTip = "显示整页";
            base.m_name = "PagewZoomWhole";
            try
            {
            }
            catch (Exception exception)
            {
                Trace.WriteLine(exception.Message, "Invalid Bitmap");
            }
        }

        public override void OnClick()
        {
            this._command.OnClick();
        }

        public override void OnCreate(object hook)
        {
            try
            {
                this.m_hookHelper = new HookHelperClass();
                this.m_hookHelper.Hook = hook;
                if (this.m_hookHelper.ActiveView == null)
                {
                    this.m_hookHelper = null;
                }
            }
            catch
            {
                this.m_hookHelper = null;
            }
            if (this.m_hookHelper == null)
            {
                base.m_enabled = false;
            }
            else
            {
                base.m_enabled = true;
            }
            this._command = new ControlsPageZoomWholePageCommandClass();
            this._command.OnCreate(hook);
        }
    }
}

