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
    using VgsTiledMap.Ags.Properties;

    [Guid("6C303E60-37BF-4ec7-9DA1-3F851FBCB11A"), ClassInterface(ClassInterfaceType.None), ProgId("AddOsmLayerCommand")]
    public sealed class AddOsmLayerCommand : BaseCommand
    {
        private IApplication application;
        private IMap map;

        public AddOsmLayerCommand()
        {
            base.m_category = "VgsTiledMap";
            base.m_caption = "&Mapnik";
            base.m_message = "Add OpenStreetMap Layer";
            base.m_toolTip = base.m_message;
            base.m_name = "AddOsmLayer";
            base.m_bitmap = Resources.osm_logo;
        }

        private static void ArcGISCategoryRegistration(System.Type registerType)
        {
            MxCommands.Register(string.Format(@"HKEY_CLASSES_ROOT\CLSID\{{{0}}}", registerType.GUID));
        }

        private static void ArcGISCategoryUnregistration(System.Type registerType)
        {
            MxCommands.Unregister(string.Format(@"HKEY_CLASSES_ROOT\CLSID\{{{0}}}", registerType.GUID));
        }

        public override void OnClick()
        {
            try
            {
                IMxDocument document = (IMxDocument) this.application.Document;
                this.map = document.FocusMap;
                VgsArcTileLayer layer2 = new VgsArcTileLayer(this.application, EnumArcVgsTileLayer.OSM);
                layer2.Name = "OpenStreetMap Mapnik";
                layer2.Visible = true;
                VgsArcTileLayer layer = layer2;
                this.map.AddLayer(layer);
                VgsTiledMap.Ags.Util.SetVgsTiledMapPropertyPage(this.application, layer);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.ToString() + ", " + exception.StackTrace);
            }
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
        private static void RegisterFunction(System.Type registerType)
        {
            ArcGISCategoryRegistration(registerType);
        }

        [ComVisible(false), ComUnregisterFunction]
        private static void UnregisterFunction(System.Type registerType)
        {
            ArcGISCategoryUnregistration(registerType);
        }

        public override bool Enabled
        {
            get
            {
                return true;
            }
        }
    }
}

