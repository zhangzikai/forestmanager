namespace VgsTiledMap.Ags
{
    using ESRI.ArcGIS.ADF.BaseClasses;
    using ESRI.ArcGIS.ADF.CATIDs;
    using ESRI.ArcGIS.ArcMapUI;
    using ESRI.ArcGIS.Framework;
    using System;
    using System.Runtime.InteropServices;

    [ClassInterface(ClassInterfaceType.None), Guid("46FD98CD-6BBA-4914-8CDF-A80DD71EE82E"), ProgId("MapOperate.TiledMap")]
    public sealed class TiledMap : BaseCommand
    {
        private IApplication application;

        public TiledMap()
        {
            base.m_category = "VgsTiledMap";
            base.m_caption = "切图";
            base.m_message = "将选定范围的选定图层进行切图";
            base.m_toolTip = base.m_message;
            base.m_name = "MapOperate.TiledMap";
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
            new VgsTiledMapAboutBox().ShowDialog(new ArcMapWindow(this.application));
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

