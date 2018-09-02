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

    [Guid("EC1AEFC8-F17A-49bc-BB5A-F392FA4589A0"), ProgId("AddServicesCommand"), ClassInterface(ClassInterfaceType.None)]
    public sealed class AddServicesCommand : BaseCommand
    {
        private IApplication application;

        public AddServicesCommand()
        {
            base.m_category = "VgsTiledMap";
            base.m_caption = "(&A)添加TMS服务...";
            base.m_message = "添加TMS服务...";
            base.m_toolTip = base.m_caption;
            base.m_name = "ServicesCommand";
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
                AddServicesForm form = new AddServicesForm();
                if (form.ShowDialog(new ArcMapWindow(this.application)) == DialogResult.OK)
                {
                    TileMap selectedService = form.SelectedService;
                    TileMapService selectedTileMapService = form.SelectedTileMapService;
                    selectedService.Href = selectedService.Href.Replace("1.0.0/1.0.0", "1.0.0").Trim();
                    EnumArcVgsTileLayer tMS = EnumArcVgsTileLayer.TMS;
                    if ((selectedService.Type != null) && (selectedService.Type == "InvertedTMS"))
                    {
                        tMS = EnumArcVgsTileLayer.InvertedTMS;
                    }
                    VgsArcTileLayer layer3 = new VgsArcTileLayer(this.application, tMS, selectedService.Href, selectedService.OverwriteUrls);
                    layer3.Name = selectedService.Title;
                    layer3.Visible = true;
                    VgsArcTileLayer layer = layer3;
                    focusMap.AddLayer(layer);
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

