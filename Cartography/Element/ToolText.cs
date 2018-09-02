namespace Cartography.Element
{
    using ESRI.ArcGIS.ADF.BaseClasses;
    using ESRI.ArcGIS.ADF.CATIDs;
    using ESRI.ArcGIS.Controls;
    using ESRI.ArcGIS.Geometry;
    using System;
    using System.Diagnostics;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;

    [ProgId("Cartography.Element.ToolText"), ClassInterface(ClassInterfaceType.None), Guid("b1f2603b-6b13-4d94-923f-c2f3d8355779")]
    public sealed class ToolText : BaseTool
    {
        private IHookHelper m_hookHelper;

        public ToolText()
        {
            base.m_category = "";
            base.m_caption = "";
            base.m_message = "";
            base.m_toolTip = "";
            base.m_name = "";
            try
            {
                base.m_cursor = new Cursor(base.GetType(), "Annotate.cur");
            }
            catch (Exception exception)
            {
                Trace.WriteLine(exception.Message, "Invalid Bitmap");
            }
        }

        private static void ArcGISCategoryRegistration(System.Type registerType)
        {
            ControlsCommands.Register(string.Format(@"HKEY_CLASSES_ROOT\CLSID\{{{0}}}", registerType.GUID));
        }

        private static void ArcGISCategoryUnregistration(System.Type registerType)
        {
            ControlsCommands.Unregister(string.Format(@"HKEY_CLASSES_ROOT\CLSID\{{{0}}}", registerType.GUID));
        }

        public override void OnClick()
        {
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

        public override void OnMouseDown(int Button, int Shift, int X, int Y)
        {
        }

        public override void OnMouseMove(int Button, int Shift, int X, int Y)
        {
        }

        public override void OnMouseUp(int Button, int Shift, int X, int Y)
        {
            if (Button == 1)
            {
                try
                {
                    IPoint point = this.m_hookHelper.ActiveView.ScreenDisplay.DisplayTransformation.ToMapPoint(X, Y);
                    DevText text = new DevText();
                    text.ActiveView = this.m_hookHelper.ActiveView;
                    text.Point = point;
                    text.ShowDialog();
                    text = null;
                }
                catch
                {
                }
            }
        }

        [ComVisible(false), ComRegisterFunction]
        private static void RegisterFunction(System.Type registerType)
        {
            ArcGISCategoryRegistration(registerType);
        }

        [ComVisible(false), ComUnregisterFunction]
        private static void UnregisterFunction(System.Type registerType)
        {
            ArcGISCategoryUnregistration(registerType);
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

