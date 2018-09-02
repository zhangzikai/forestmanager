namespace VgsTiledMap.Ags
{
    using ESRI.ArcGIS.ADF.BaseClasses;
    using ESRI.ArcGIS.ADF.CATIDs;
    using ESRI.ArcGIS.ArcMapUI;
    using ESRI.ArcGIS.Framework;
    using System;
    using System.Runtime.InteropServices;

    [Guid("A232640A-7ADE-4923-BC06-5B1F889DCC3D"), ProgId("ExportCommand"), ClassInterface(ClassInterfaceType.None)]
    public sealed class ExportCommand : BaseCommand
    {
        private IApplication application;

        public ExportCommand()
        {
            base.m_category = "VgsTiledMap";
            base.m_caption = "&导出";
            base.m_message = "导出";
            base.m_toolTip = base.m_caption;
            base.m_name = "ExportCommand";
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

        [ComVisible(false), ComRegisterFunction]
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

