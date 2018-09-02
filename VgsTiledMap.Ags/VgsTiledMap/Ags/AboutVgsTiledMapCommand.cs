namespace VgsTiledMap.Ags
{
    using ESRI.ArcGIS.ADF.BaseClasses;
    using ESRI.ArcGIS.ADF.CATIDs;
    using ESRI.ArcGIS.ArcMapUI;
    using ESRI.ArcGIS.Framework;
    using System;
    using System.Runtime.InteropServices;

    [Guid("DE4DCE74-7159-4d20-808E-45E7F8D7C1C0"), ProgId("AboutVgsTiledMapCommand"), ClassInterface(ClassInterfaceType.None)]
    public sealed class AboutVgsTiledMapCommand : BaseCommand
    {
        private IApplication application;

        public AboutVgsTiledMapCommand()
        {
            base.m_category = "VgsTiledMap";
            base.m_caption = "关于(&A)";
            base.m_message = "关于VgsTiledMap...";
            base.m_toolTip = base.m_caption;
            base.m_name = "AboutVgsTiledMapCommand";
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

        [ComUnregisterFunction, ComVisible(false)]
        private static void UnregisterFunction(Type registerType)
        {
            ArcGISCategoryUnregistration(registerType);
        }
    }
}

