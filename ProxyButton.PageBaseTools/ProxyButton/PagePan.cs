namespace ProxyButton
{
    using ESRI.ArcGIS.ADF.BaseClasses;
    using ESRI.ArcGIS.Controls;
    using ESRI.ArcGIS.SystemUI;
    using System;
    using System.Diagnostics;
    using System.Windows.Forms;

    public sealed class PagePan : BaseTool
    {
        private ICommand _command;
        private ITool _tool;
        private IHookHelper m_hookHelper = null;

        public PagePan()
        {
            base.m_category = "";
            base.m_caption = "";
            base.m_message = "";
            base.m_toolTip = "页面漫游";
            base.m_name = "PagePan";
            try
            {
                base.m_cursor = new Cursor(base.GetType(), "ProxyButton.Resources.PagePan.cur");
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
            this._command = new ControlsPagePanToolClass();
            this._tool = (ITool) this._command;
            this._command.OnCreate(hook);
        }

        public override void OnMouseDown(int Button, int Shift, int X, int Y)
        {
            this._tool.OnMouseDown(Button, Shift, X, Y);
        }

        public override void OnMouseMove(int Button, int Shift, int X, int Y)
        {
            this._tool.OnMouseMove(Button, Shift, X, Y);
        }

        public override void OnMouseUp(int Button, int Shift, int X, int Y)
        {
            this._tool.OnMouseUp(Button, Shift, X, Y);
        }
    }
}

