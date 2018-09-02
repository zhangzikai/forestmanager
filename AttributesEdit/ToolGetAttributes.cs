namespace AttributesEdit
{
    using ESRI.ArcGIS.ADF.BaseClasses;
    using ESRI.ArcGIS.ADF.CATIDs;
    using ESRI.ArcGIS.Controls;
    using ESRI.ArcGIS.Geometry;
    using System;
    using System.Diagnostics;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;

    [ProgId("AttributesEdit.ToolAutoUpdateAttributes"), ClassInterface(ClassInterfaceType.None), Guid("32e7a225-b869-4d3e-bacd-ee6dc98c130e")]
    public sealed class ToolGetAttributes : BaseTool
    {
        private IHookHelper m_hookHelper;
        private object m_Usercontrol;

        public ToolGetAttributes()
        {
            base.m_category = "获取属性";
            base.m_caption = "";
            base.m_message = "";
            base.m_toolTip = "获取属性";
            base.m_name = "";
            try
            {
                base.m_cursor = new Cursor(base.GetType(), base.GetType().Name + ".cur");
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
            if (this.m_hookHelper == null)
            {
                this.m_hookHelper = new HookHelperClass();
            }
            this.m_hookHelper.Hook = hook;
        }

        public override void OnMouseDown(int Button, int Shift, int X, int Y)
        {
        }

        public override void OnMouseMove(int Button, int Shift, int X, int Y)
        {
        }

        public override void OnMouseUp(int Button, int Shift, int X, int Y)
        {
            try
            {
                if ((this.m_hookHelper.ActiveView != null) && (Button == Keys.LButton.GetHashCode()))
                {
                    IPoint point = null;
                    point = this.m_hookHelper.ActiveView.ScreenDisplay.DisplayTransformation.ToMapPoint(X, Y);
                    (this.m_Usercontrol as UserControlSubAttr).PointLocation = point;
                }
            }
            catch (Exception)
            {
            }
        }

        [ComVisible(false), ComRegisterFunction]
        private static void RegisterFunction(System.Type registerType)
        {
            ArcGISCategoryRegistration(registerType);
        }

        [ComUnregisterFunction, ComVisible(false)]
        private static void UnregisterFunction(System.Type registerType)
        {
            ArcGISCategoryUnregistration(registerType);
        }

        public object ParentUsercontrol
        {
            set
            {
                this.m_Usercontrol = value;
            }
        }
    }
}

