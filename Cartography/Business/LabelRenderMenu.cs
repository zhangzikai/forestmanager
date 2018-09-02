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

    [ProgId("Cartography.Business.LabelRender"), Guid("1f1b500c-0180-4449-913b-59488c803634"), ClassInterface(ClassInterfaceType.None)]
    public sealed class LabelRenderMenu : BaseCommand
    {
        private object m_Hook;

        public LabelRenderMenu()
        {
            base.m_category = "LayerControl";
            base.m_caption = "标注";
            base.m_message = "设置图层标注";
            base.m_toolTip = "图层标注";
            base.m_name = "LayerControl_LabelRender";
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
            ITOCControl2 hook = this.m_Hook as ITOCControl2;
            ILayer customProperty = hook.CustomProperty as ILayer;
            DevLabelRender render = new DevLabelRender(customProperty);
            if (render.ShowDialog() == DialogResult.OK)
            {
                hook.Update();
                hook.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeography, customProperty, hook.ActiveView.Extent);
            }
            render.Dispose();
            render = null;
        }

        public override void OnCreate(object hook)
        {
            if (hook != null)
            {
                this.m_Hook = hook;
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
                if (this.m_Hook == null)
                {
                    return false;
                }
                ITOCControl2 hook = this.m_Hook as ITOCControl2;
                if (hook == null)
                {
                    return false;
                }
                ILayer customProperty = hook.CustomProperty as ILayer;
                if (!(customProperty is IFeatureLayer))
                {
                    return false;
                }
                if (customProperty.Name.Contains("扫描图"))
                {
                    return false;
                }
                return true;
            }
        }
    }
}

