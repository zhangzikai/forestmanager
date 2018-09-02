namespace VgsTiledMap.Ags.VgsTile.AgsCommands.Vgs
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
    using VgsTiledMap.Ags.VgsTile.Forms;

    [ProgId("AddVgsSatelliteCommand"), ClassInterface(ClassInterfaceType.None), Guid("CBCBB6B8-4BFC-4017-90F7-47637007C6DB")]
    public sealed class AddVgsSatelliteCommand : BaseCommand
    {
        private IApplication application;
        private IHookHelper m_hookHelper;

        public AddVgsSatelliteCommand()
        {
            base.m_category = "VgsTiledMap";
            base.m_caption = "林地一张图影像服务";
            base.m_message = "添加林地一张图服务地图数据";
            base.m_toolTip = base.m_caption;
            base.m_name = "AddVgsSatelliteCommand";
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
                AddLindiServiceForm form = new AddLindiServiceForm();
                form.ArcMap = focusMap;
                form.ArcApplication = this.application;
                form.LayerType = EnumArcVgsTileLayer.EviaTiledSatellite;
                form.Show(new ArcMapWindow(this.application));
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

        [ComVisible(false), ComUnregisterFunction]
        private static void UnregisterFunction(System.Type registerType)
        {
            ArcGISCategoryUnregistration(registerType);
        }
    }
}

