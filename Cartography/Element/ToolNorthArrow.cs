namespace Cartography.Element
{
    using ESRI.ArcGIS.ADF.BaseClasses;
    using ESRI.ArcGIS.ADF.CATIDs;
    using ESRI.ArcGIS.Carto;
    using ESRI.ArcGIS.Controls;
    using ESRI.ArcGIS.Display;
    using ESRI.ArcGIS.Geometry;
    using System;
    using System.Diagnostics;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;

    [ClassInterface(ClassInterfaceType.None), Guid("564b5d5d-afbf-4b05-9779-5e7dff439404"), ProgId("Cartography.Element.ToolNorthArrow")]
    public sealed class ToolNorthArrow : BaseTool
    {
        private IHookHelper m_hookHelper;
        private INewBezierCurveFeedback mFeedback;
        private bool mInUsing;
        private IPoint mStartPoint;

        public ToolNorthArrow()
        {
            base.m_category = "Cartography";
            base.m_caption = "指北针";
            base.m_message = "指北针";
            base.m_toolTip = "指北针";
            base.m_name = "Cartography_Element_ToolNorthArrow";
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
                    DevNorthArrowSelector selector = new DevNorthArrowSelector();
                    selector.ActiveView = this.m_hookHelper.PageLayout as IActiveView;
                    selector.Point = point;
                    selector.ShowDialog();
                    selector = null;
                    this.mStartPoint = null;
                }
                catch
                {
                }
            }
        }

        [ComRegisterFunction, ComVisible(false)]
        private static void RegisterFunction(System.Type registerType)
        {
            ArcGISCategoryRegistration(registerType);
        }

        [ComUnregisterFunction, ComVisible(false)]
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

