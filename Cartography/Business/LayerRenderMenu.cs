namespace Cartography.Business
{
    using Cartography.Render;
    using ESRI.ArcGIS.ADF.BaseClasses;
    using ESRI.ArcGIS.ADF.CATIDs;
    using ESRI.ArcGIS.Carto;
    using ESRI.ArcGIS.Controls;
    using System;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;

    [ProgId("Cartography.Business.LayerRenderMenu"), ClassInterface(ClassInterfaceType.None), Guid("485e46e3-36ee-48da-a5a6-a0a7a8900fea")]
    public sealed class LayerRenderMenu : BaseCommand
    {
        private object m_hook;

        public LayerRenderMenu()
        {
            base.m_category = "LayerControl";
            base.m_caption = "栅格符号渲染";
            base.m_message = "栅格符号渲染";
            base.m_toolTip = "栅格符号渲染";
            base.m_name = "LayerControl_LayerRenderMenu";
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
            ITOCControl2 hook = this.m_hook as ITOCControl2;
            ILayer customProperty = hook.CustomProperty as ILayer;
            DevLayerRender render = new DevLayerRender();
            render.RenderLayer = customProperty;
            if (render.ShowDialog() == DialogResult.OK)
            {
                hook.ActiveView.Refresh();
                hook.Update();
            }
            render = null;
        }

        public override void OnCreate(object hook)
        {
            if (hook != null)
            {
                this.m_hook = hook;
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

        public override bool Enabled
        {
            get
            {
                if (this.m_hook == null)
                {
                    return false;
                }
                ITOCControl2 hook = this.m_hook as ITOCControl2;
                if (hook == null)
                {
                    return false;
                }
                ILayer customProperty = hook.CustomProperty as ILayer;
                if (customProperty == null)
                {
                    return false;
                }
                return (customProperty is IRasterLayer);
            }
        }
    }
}

