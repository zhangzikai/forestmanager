namespace GeoDataIE
{
    using ESRI.ArcGIS.ADF.BaseClasses;
    using ESRI.ArcGIS.ADF.CATIDs;
    using ESRI.ArcGIS.Controls;
    using System;
    using System.Runtime.InteropServices;

    [ProgId("GeoDataIE.CmdExportZT"), ClassInterface(ClassInterfaceType.None), Guid("7bf19ec2-76fc-48ab-9fa5-00ba8e232b4b")]
    public sealed class CmdExportZT : BaseCommand
    {
        private IHookHelper m_hookHelper;

        public CmdExportZT()
        {
            base.m_category = "";
            base.m_caption = "";
            base.m_message = "";
            base.m_toolTip = "导出专题数据";
            base.m_name = "";
        }

        private static void ArcGISCategoryRegistration(Type registerType)
        {
            ControlsCommands.Register(string.Format(@"HKEY_CLASSES_ROOT\CLSID\{{{0}}}", registerType.GUID));
        }

        private static void ArcGISCategoryUnregistration(Type registerType)
        {
            ControlsCommands.Unregister(string.Format(@"HKEY_CLASSES_ROOT\CLSID\{{{0}}}", registerType.GUID));
        }

        public override void OnClick()
        {
            FormExportZT tzt = new FormExportZT();
            tzt.Hook = this.m_hookHelper.Hook;
            tzt.ShowDialog();
        }

        public override void OnCreate(object hook)
        {
            if (hook != null)
            {
                if (this.m_hookHelper == null)
                {
                    this.m_hookHelper = new HookHelperClass();
                }
                this.m_hookHelper.Hook = hook;
            }
        }

        [ComRegisterFunction, ComVisible(false)]
        private static void RegisterFunction(Type registerType)
        {
            ArcGISCategoryRegistration(registerType);
        }

        [ComVisible(false), ComUnregisterFunction]
        private static void UnregisterFunction(Type registerType)
        {
            ArcGISCategoryUnregistration(registerType);
        }
    }
}

