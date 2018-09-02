namespace ProxyButton
{
    using ESRI.ArcGIS.ADF.BaseClasses;
    using ESRI.ArcGIS.Controls;
    using System;
    using System.Diagnostics;

    public sealed class Refresh : BaseCommand
    {
        private IHookHelper m_hookHelper = null;

        public Refresh()
        {
            base.m_category = "";
            base.m_caption = "";
            base.m_message = "";
            base.m_toolTip = "刷新";
            base.m_name = "Refresh";
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
            this.m_hookHelper.ActiveView.Refresh();
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
        }

        public override bool Enabled
        {
            get
            {
                return ((this.m_hookHelper != null) && (this.m_hookHelper.Hook is IPageLayoutControl));
            }
        }
    }
}

