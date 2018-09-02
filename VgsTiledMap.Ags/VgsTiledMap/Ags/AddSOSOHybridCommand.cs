namespace VgsTiledMap.Ags
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

    [ProgId("AddSOSOHybridCommand"), ClassInterface(ClassInterfaceType.None), Guid("247AD311-1559-4242-81B0-E73C4BB1E838")]
    public sealed class AddSOSOHybridCommand : BaseCommand
    {
        private IApplication application;
        private IHookHelper m_hookHelper;

        public AddSOSOHybridCommand()
        {
            base.m_category = "VgsTiledMap";
            base.m_caption = "混合图(&H)";
            base.m_message = "添加腾讯混合图";
            base.m_toolTip = base.m_caption;
            base.m_name = "AddSOSOHybridCommand";
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
                IMxDocument document = (IMxDocument) this.application.Document;
                IMap focusMap = document.FocusMap;
                VgsArcTileLayer layer2 = new VgsArcTileLayer(this.application, EnumArcVgsTileLayer.SOSOSatellite);
                layer2.Name = "腾讯卫星图";
                layer2.Visible = true;
                VgsArcTileLayer layer = layer2;
                focusMap.AddLayer(layer);
                VgsTiledMap.Ags.Util.SetVgsTiledMapPropertyPage(this.application, layer);
                VgsArcTileLayer layer3 = new VgsArcTileLayer(this.application, EnumArcVgsTileLayer.SOSOLabels);
                layer3.Name = "腾讯标注图";
                layer3.Visible = true;
                layer = layer3;
                focusMap.AddLayer(layer);
                VgsTiledMap.Ags.Util.SetVgsTiledMapPropertyPage(this.application, layer);
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
    }
}

