namespace VgsTiledMap.Ags
{
    using ESRI.ArcGIS.ADF.BaseClasses;
    using ESRI.ArcGIS.ADF.CATIDs;
    using ESRI.ArcGIS.ArcMapUI;
    using ESRI.ArcGIS.Framework;
    using System;
    using System.Runtime.InteropServices;
    using VgsTiledMap.Ags.forms;

    [ProgId("MapOperate.GeoCoding"), Guid("F1C01E4E-A2E7-45cf-A495-E37CCCDA228B"), ClassInterface(ClassInterfaceType.None)]
    public sealed class GeoCoding : BaseCommand
    {
        private IApplication application;

        public GeoCoding()
        {
            base.m_category = "VgsTiledMap";
            base.m_caption = "查找地名";
            base.m_message = "根据地名查找";
            base.m_toolTip = base.m_message;
            base.m_name = "MapOperate.GeoCoding";
        }

        private static void ArcGISCategoryRegistration(Type registerType)
        {
            MxCommands.Register(string.Format(@"HKEY_CLASSES_ROOT\CLSID\{{{0}}}", registerType.GUID));
        }

        private static void ArcGISCategoryUnregistration(Type registerType)
        {
            MxCommands.Unregister(string.Format(@"HKEY_CLASSES_ROOT\CLSID\{{{0}}}", registerType.GUID));
        }

        public override void OnClick()
        {
            new FormGeoCoding(this.application).Show(new ArcMapWindow(this.application));
        }

        public override void OnCreate(object hook)
        {
            if (hook != null)
            {
                this.application = hook as IApplication;
                if (hook is IMxApplication)
                {
                    base.m_enabled = true;
                }
                else
                {
                    base.m_enabled = false;
                }
            }
        }

        [ComRegisterFunction, ComVisible(false)]
        private static void RegisterFunction(Type registerType)
        {
            ArcGISCategoryRegistration(registerType);
        }

        [ComVisible(false), ComUnregisterFunction]
        private static void UnregisterFunction(Type registerType)
        {
            ArcGISCategoryUnregistration(registerType);
        }
    }
}

