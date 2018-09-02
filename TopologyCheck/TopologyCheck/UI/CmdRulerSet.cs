namespace TopologyCheck.UI
{
    using ESRI.ArcGIS.ADF.BaseClasses;
    using ESRI.ArcGIS.ADF.CATIDs;
    using ESRI.ArcGIS.Carto;
    using ESRI.ArcGIS.Controls;
    using ESRI.ArcGIS.Geometry;
    using System;
    using System.Diagnostics;
    using System.Drawing;
    using System.Runtime.InteropServices;
    using TaskManage;

    [Guid("03ef3a55-0c0c-4660-b05b-c9102f875842"), ProgId("TopologyCheck.UI.CmdRulerSet"), ClassInterface(ClassInterfaceType.None)]
    public sealed class CmdRulerSet : BaseCommand
    {
        private IHookHelper m_hookHelper;

        public CmdRulerSet()
        {
            base.m_category = "";
            base.m_caption = "";
            base.m_message = "";
            base.m_toolTip = "";
            base.m_name = "";
            try
            {
                string resource = base.GetType().Name + ".bmp";
                base.m_bitmap = new Bitmap(base.GetType(), resource);
            }
            catch (Exception exception)
            {
                Trace.WriteLine(exception.Message, "Invalid Bitmap");
            }
        }

        private static void ArcGISCategoryRegistration(Type registerType)
        {
            ControlsCommands.Register(string.Format(@"HKEY_CLASSES_ROOT\CLSID\{{{0}}}", registerType.GUID));
        }

        private static void ArcGISCategoryUnregistration(Type registerType)
        {
            ControlsCommands.Unregister(string.Format(@"HKEY_CLASSES_ROOT\CLSID\{{{0}}}", registerType.GUID));
        }

        public override void OnClick()
        {
            RulerSet set = new RulerSet();
            set.ShowDialog();
            set.Dispose();
            set = null;
        }

        public override void OnCreate(object hook)
        {
            if (hook != null)
            {
                if (this.m_hookHelper == null)
                {
                    this.m_hookHelper = new HookHelperClass();
                }
                this.m_hookHelper.Hook = hook;
            }
        }

        [ComVisible(false), ComRegisterFunction]
        private static void RegisterFunction(Type registerType)
        {
            ArcGISCategoryRegistration(registerType);
        }

        [ComUnregisterFunction, ComVisible(false)]
        private static void UnregisterFunction(Type registerType)
        {
            ArcGISCategoryUnregistration(registerType);
        }

        public override bool Enabled
        {
            get
            {
                IFeatureLayer editLayer = EditTask.EditLayer;
                if (editLayer.FeatureClass == null)
                {
                    return false;
                }
                return (((editLayer.FeatureClass.ShapeType != esriGeometryType.esriGeometryPoint) && (editLayer.FeatureClass.ShapeType != esriGeometryType.esriGeometryPolyline)) && base.Enabled);
            }
        }
    }
}

