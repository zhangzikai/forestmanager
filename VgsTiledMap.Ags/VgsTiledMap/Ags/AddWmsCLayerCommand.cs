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

    [ProgId("AddWmsCLayerCommand"), ClassInterface(ClassInterfaceType.None), Guid("F694195D-8B0A-49c4-A4E1-12CDFF39CA8B")]
    public sealed class AddWmsCLayerCommand : BaseCommand
    {
        private IApplication application;
        private IMap map;

        public AddWmsCLayerCommand()
        {
            base.m_category = "VgsTiledMap";
            base.m_caption = "Add &WMS-C服务...";
            base.m_message = "Add WMS-C图层复合WMS-C规范...";
            base.m_toolTip = base.m_message;
            base.m_name = "AddWmsCLayer";
            base.m_bitmap = Resources.WMS_icon;
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
                AddWmsCForm form = new AddWmsCForm();
                if (form.ShowDialog(new ArcMapWindow(this.application)) == DialogResult.OK)
                {
                    IConfig config = new ConfigWmsC(form.SelectedTileSource);
                    VgsArcTileLayer layer2 = new VgsArcTileLayer(this.application, config);
                    layer2.Name = config.CreateTileSource().Schema.Name;
                    layer2.Visible = true;
                    VgsArcTileLayer layer = layer2;
                    this.map.AddLayer(layer);
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

