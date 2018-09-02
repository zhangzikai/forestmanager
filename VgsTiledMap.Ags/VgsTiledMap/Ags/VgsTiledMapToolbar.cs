namespace VgsTiledMap.Ags
{
    using ESRI.ArcGIS.ADF.BaseClasses;
    using ESRI.ArcGIS.ADF.CATIDs;
    using log4net;
    using log4net.Config;
    using System;
    using System.Configuration;
    using System.IO;
    using System.Reflection;
    using System.Runtime.InteropServices;

    [ClassInterface(ClassInterfaceType.None), ProgId("VgsTiledMapToolbar"), Guid("617680D0-F176-4a4d-B903-2829D41AD904")]
    public sealed class VgsTiledMapToolbar : BaseToolbar
    {
        private static readonly ILog logger = LogManager.GetLogger("VgsMapTileAgsSystemLogger");

        public VgsTiledMapToolbar()
        {
            XmlConfigurator.Configure(new FileInfo(Assembly.GetExecutingAssembly().Location + ".config"));
            try
            {
                base.BeginGroup();
                base.AddItem("MapOperate.GeoCoding");
                base.BeginGroup();
                System.Configuration.Configuration config = ConfigurationHelper.GetConfig();
                if ((config.AppSettings.Settings["useGoogle"] != null) && Convert.ToBoolean(config.AppSettings.Settings["useGoogle"].Value))
                {
                    base.AddItem("VgsTiledMap.Ags.GoogleMenuDef");
                }
                base.AddItem("VgsTiledMap.Ags.SOSOMenuDef");
                base.AddItem("VgsTiledMap.Ags.MenuDef.VgsTileServiceMenuDef");
                base.AddItem("VgsTiledMap.Ags.VgsTile.MenuDef.TiandiTuMenuDef");
                base.BeginGroup();
                base.AddItem("MapOperate.CacheSetting");
                base.BeginGroup();
                base.AddItem("AboutVgsTiledMapCommand");
            }
            catch (Exception exception)
            {
                logger.Error(exception.ToString());
            }
        }

        private static void ArcGISCategoryRegistration(Type registerType)
        {
            MxCommandBars.Register(string.Format(@"HKEY_CLASSES_ROOT\CLSID\{{{0}}}", registerType.GUID));
        }

        private static void ArcGISCategoryUnregistration(Type registerType)
        {
            MxCommandBars.Unregister(string.Format(@"HKEY_CLASSES_ROOT\CLSID\{{{0}}}", registerType.GUID));
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

        public override string Caption
        {
            get
            {
                return "林地一张图数据管理";
            }
        }

        public override string Name
        {
            get
            {
                return "VgsTiledMap ToolBar";
            }
        }
    }
}

