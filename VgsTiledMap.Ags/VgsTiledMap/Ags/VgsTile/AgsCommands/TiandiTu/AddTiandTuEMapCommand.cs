namespace VgsTiledMap.Ags.VgsTile.AgsCommands.TiandiTu
{
    using ESRI.ArcGIS.ADF.BaseClasses;
    using ESRI.ArcGIS.ADF.CATIDs;
    using ESRI.ArcGIS.ArcMapUI;
    using ESRI.ArcGIS.Carto;
    using ESRI.ArcGIS.Controls;
    using ESRI.ArcGIS.Framework;
    using System;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;
    using VgsTiledMap.Ags;
    using VgsTiledMap.Ags.VgsTile.Configs;

    [ClassInterface(ClassInterfaceType.None), Guid("6FBAB3E6-8592-408b-8A70-247D15ED57EE"), ProgId("AddTiandTuEMapCommand")]
    public sealed class AddTiandTuEMapCommand : BaseCommand
    {
        private IApplication application;
        private IHookHelper m_hookHelper;

        public AddTiandTuEMapCommand()
        {
            base.m_category = "VgsTiledMap";
            base.m_caption = "天地图电子地图";
            base.m_message = "添加天地图电子地图";
            base.m_toolTip = base.m_caption;
            base.m_name = "AddTiandTuEMapCommand";
        }

        private static void ArcGISCategoryRegistration(System.Type registerType)
        {
            string cLSID = string.Format(@"HKEY_CLASSES_ROOT\CLSID\{{{0}}}", registerType.GUID);
            MxCommands.Register(cLSID);
            ControlsCommands.Register(cLSID);
        }

        private static void ArcGISCategoryUnregistration(System.Type registerType)
        {
            string cLSID = string.Format(@"HKEY_CLASSES_ROOT\CLSID\{{{0}}}", registerType.GUID);
            MxCommands.Unregister(cLSID);
            ControlsCommands.Unregister(cLSID);
        }

        public override void OnClick()
        {
            try
            {
                if (this.application == null)
                {
                    MessageBox.Show("程序错误，只支持通过ArcDesktop来调用!");
                }
                else
                {
                    IMxDocument document = (IMxDocument) this.application.Document;
                    IMap focusMap = document.FocusMap;
                    IConfig config = new ConfigTiandiTu(EnumArcVgsTileLayer.TiandiTu);
                    VgsArcTileLayer layer2 = new VgsArcTileLayer(this.application, config);
                    layer2.Name = "天地图电子地图";
                    layer2.Visible = true;
                    VgsArcTileLayer layer = layer2;
                    focusMap.AddLayer(layer);
                    VgsTiledMap.Ags.Util.SetVgsTiledMapPropertyPage(this.application, layer);
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.ToString());
            }
        }

        public override void OnCreate(object hook)
        {
            if (hook != null)
            {
                this.application = hook as IApplication;
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
    }
}

