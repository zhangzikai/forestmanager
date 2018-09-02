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

    [ClassInterface(ClassInterfaceType.None), Guid("728E9224-2EB6-4dd6-8D61-85D31F65EB98"), ProgId("AddOsmTilesAtHomeLayerCommand")]
    public sealed class AddOsmTilesAtHomeLayerCommand : BaseCommand
    {
        private IApplication application;
        private IMap map;

        public AddOsmTilesAtHomeLayerCommand()
        {
            base.m_category = "VgsTiledMap";
            base.m_caption = "&Tiles@Home";
            base.m_message = "Add OpenStreetMap Tiles@Home Layer";
            base.m_toolTip = base.m_message;
            base.m_name = "AddOsmTilesAtHomeLayer";
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
                VgsArcTileLayer layer2 = new VgsArcTileLayer(this.application, EnumArcVgsTileLayer.OSMMapnik);
                layer2.Name = "OpenStreetMap Tiles@Home";
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

        public override bool Enabled
        {
            get
            {
                return true;
            }
        }
    }
}

