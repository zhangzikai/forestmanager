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

    [ProgId("AddSpatialCloudLayerCommand"), Guid("0784EB7B-8534-4007-A07F-7C3FE0E9776E"), ClassInterface(ClassInterfaceType.None)]
    public sealed class AddSpatialCloudLayerCommand : BaseCommand
    {
        private IApplication application;
        private IMap map;

        public AddSpatialCloudLayerCommand()
        {
            base.m_category = "VgsTiledMap";
            base.m_caption = "&SpatialCloud";
            base.m_message = "Add SpatialCloud Layer";
            base.m_toolTip = base.m_message;
            base.m_name = "AddSpatialCloudLayer";
            base.m_bitmap = Resources.SpatialCloud;
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
                VgsArcTileLayer layer2 = new VgsArcTileLayer(this.application, EnumArcVgsTileLayer.SpatialCloud);
                layer2.Name = "SpatialCloud";
                layer2.Visible = true;
                VgsArcTileLayer layer = layer2;
                this.map.AddLayer(layer);
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

