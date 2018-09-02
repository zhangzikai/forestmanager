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

    [Guid("A92DA332-AB49-451a-979A-6BE5770EBD3A"), ClassInterface(ClassInterfaceType.None), ProgId("AddBingRoadLayerCommand")]
    public sealed class AddBingRoadLayerCommand : BaseCommand
    {
        private IApplication application;

        public AddBingRoadLayerCommand()
        {
            base.m_category = "VgsTiledMap";
            base.m_caption = "&Roads";
            base.m_message = "Add Bing Road Layer";
            base.m_toolTip = base.m_message;
            base.m_name = "AddBingLayer";
            base.m_bitmap = Resources.bing;
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
                IMap focusMap = document.FocusMap;
                VgsArcTileLayer layer2 = new VgsArcTileLayer(this.application, EnumArcVgsTileLayer.BingRoad);
                layer2.Name = "Bing Road";
                layer2.Visible = true;
                VgsArcTileLayer layer = layer2;
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

