namespace Cartography.Business
{
    using ESRI.ArcGIS.ADF.BaseClasses;
    using ESRI.ArcGIS.ADF.CATIDs;
    using ESRI.ArcGIS.Carto;
    using ESRI.ArcGIS.Controls;
    using ESRI.ArcGIS.Geodatabase;
    using ESRI.ArcGIS.Geometry;
    using System;
    using System.Runtime.InteropServices;

    [ClassInterface(ClassInterfaceType.None), Guid("1f1b500c-0180-4449-913b-59488c803635"), ProgId("Cartography.Business.ZoomToLayerMenu")]
    public sealed class ZoomToLayerMenu : BaseCommand
    {
        private object m_Hook;

        public ZoomToLayerMenu()
        {
            base.m_category = "LayerControl";
            base.m_caption = "缩放到";
            base.m_message = "缩放到图层";
            base.m_toolTip = "缩放到图层范围";
            base.m_name = "LayerControl_ZoomToLayer";
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
            try
            {
                IEnvelope areaOfInterest = null;
                ITOCControl2 hook = this.m_Hook as ITOCControl2;
                ILayer customProperty = hook.CustomProperty as ILayer;
                if (customProperty is IFeatureLayer)
                {
                    IFeatureLayer layer2 = customProperty as IFeatureLayer;
                    areaOfInterest = layer2.AreaOfInterest;
                }
                else
                {
                    IDataset dataset = customProperty as IDataset;
                    IGeoDataset dataset2 = dataset as IGeoDataset;
                    areaOfInterest = dataset2.Extent;
                }
                hook.ActiveView.FullExtent = areaOfInterest;
                hook.ActiveView.Refresh();
            }
            catch (Exception)
            {
            }
        }

        public override void OnCreate(object hook)
        {
            if (hook != null)
            {
                this.m_Hook = hook;
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
                if (customProperty is IFeatureLayer)
                {
                    if (customProperty.Name.Contains("扫描图"))
                    {
                        return false;
                    }
                    return true;
                }
                return (customProperty is IRasterLayer);
            }
        }
    }
}

