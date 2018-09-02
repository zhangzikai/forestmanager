namespace VgsTiledMap.Ags
{
    using ESRI.ArcGIS.ADF.BaseClasses;
    using ESRI.ArcGIS.ADF.CATIDs;
    using ESRI.ArcGIS.ArcMapUI;
    using ESRI.ArcGIS.Framework;
    using System;
    using System.Runtime.InteropServices;
    using VgsTiledMap.Ags.VgsTile.Forms;

    [ProgId("MapOperate.CacheSetting"), ClassInterface(ClassInterfaceType.None), Guid("4DF3A785-E303-4f8f-B1F4-6D076F6309C5")]
    public sealed class CacheSetting : BaseCommand
    {
        private IApplication application;

        public CacheSetting()
        {
            base.m_category = "VgsTiledMap";
            base.m_caption = "缓存设置";
            base.m_message = "手工设置缓存";
            base.m_toolTip = base.m_message;
            base.m_name = "MapOperate.CacheSetting";
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
            new VgsFormTileCacheSetting().ShowDialog();
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

        [ComUnregisterFunction, ComVisible(false)]
        private static void UnregisterFunction(Type registerType)
        {
            ArcGISCategoryUnregistration(registerType);
        }
    }
}

