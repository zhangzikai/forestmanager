namespace VgsTiledMap.Ags
{
    using ESRI.ArcGIS.ADF.BaseClasses;
    using ESRI.ArcGIS.ADF.CATIDs;
    using ESRI.ArcGIS.ArcMapUI;
    using ESRI.ArcGIS.Carto;
    using ESRI.ArcGIS.Framework;
    using System;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;

    [Guid("2B129B18-EDA5-452d-9ECC-EBC7D00FAB85"), ClassInterface(ClassInterfaceType.None), ProgId("AddGoogleChinaHybridCommand")]
    public sealed class AddGoogleChinaHybridCommand : BaseCommand
    {
        private IApplication m_application;

        public AddGoogleChinaHybridCommand()
        {
            base.m_category = "VgsTiledMap";
            base.m_caption = "Google中国混合图(&H)";
            base.m_message = "添加Google中国混合图";
            base.m_toolTip = base.m_caption;
            base.m_name = "AddGoogleChinaHybridCommand";
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
                IMxDocument document = (IMxDocument) this.m_application.Document;
                IMap focusMap = document.FocusMap;
                VgsArcTileLayer layer2 = new VgsArcTileLayer(this.m_application, EnumArcVgsTileLayer.GoogleChinaSatellite);
                layer2.Name = "google中国卫星图";
                layer2.Visible = true;
                VgsArcTileLayer layer = layer2;
                focusMap.AddLayer(layer);
                VgsTiledMap.Ags.Util.SetVgsTiledMapPropertyPage(this.m_application, layer);
                VgsArcTileLayer layer3 = new VgsArcTileLayer(this.m_application, EnumArcVgsTileLayer.GoogleLabels);
                layer3.Name = "google中国标签图";
                layer3.Visible = true;
                layer = layer3;
                focusMap.AddLayer(layer);
                VgsTiledMap.Ags.Util.SetVgsTiledMapPropertyPage(this.m_application, layer);
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
                this.m_application = hook as IApplication;
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
        private static void RegisterFunction(System.Type registerType)
        {
            ArcGISCategoryRegistration(registerType);
        }

        [ComVisible(false), ComUnregisterFunction]
        private static void UnregisterFunction(System.Type registerType)
        {
            ArcGISCategoryUnregistration(registerType);
        }
    }
}

