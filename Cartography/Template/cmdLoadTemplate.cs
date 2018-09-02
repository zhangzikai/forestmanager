namespace Cartography.Template
{
    using ESRI.ArcGIS.ADF.BaseClasses;
    using ESRI.ArcGIS.ADF.CATIDs;
    using ESRI.ArcGIS.Carto;
    using ESRI.ArcGIS.Controls;
    using System;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;

    [Guid("fce85832-3f3b-4993-bc1c-06faa9567c4e"), ClassInterface(ClassInterfaceType.None), ProgId("Cartography.Template.cmdLoadTemplate")]
    public sealed class cmdLoadTemplate : BaseCommand
    {
        private IHookHelper m_hookHelper;

        public cmdLoadTemplate()
        {
            base.m_category = "";
            base.m_caption = "";
            base.m_message = "";
            base.m_toolTip = "";
            base.m_name = "";
        }

        private static void ArcGISCategoryRegistration(System.Type registerType)
        {
            ControlsCommands.Register(string.Format(@"HKEY_CLASSES_ROOT\CLSID\{{{0}}}", registerType.GUID));
        }

        private static void ArcGISCategoryUnregistration(System.Type registerType)
        {
            ControlsCommands.Unregister(string.Format(@"HKEY_CLASSES_ROOT\CLSID\{{{0}}}", registerType.GUID));
        }

        public override void OnClick()
        {
            try
            {
                if (this.m_hookHelper.Hook is IPageLayoutControl3)
                {
                    IMap focusMap = this.m_hookHelper.FocusMap;
                    frmLoadTemplate template = new frmLoadTemplate();
                    if (template.ShowDialog() == DialogResult.OK)
                    {
                        string templateFile = template.TemplateFile;
                        if ((templateFile != null) && (templateFile != ""))
                        {
                            IPageLayoutControl3 hook = this.m_hookHelper.Hook as IPageLayoutControl3;
                            new TemplateCarto().Carto(hook, templateFile);
                        }
                    }
                }
            }
            catch (Exception)
            {
            }
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
                if (this.m_hookHelper == null)
                {
                    return false;
                }
                if (this.m_hookHelper.PageLayout == null)
                {
                    return false;
                }
                return base.Enabled;
            }
        }
    }
}

