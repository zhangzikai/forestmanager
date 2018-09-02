namespace Cartography.Business
{
    using ESRI.ArcGIS.ADF.BaseClasses;
    using ESRI.ArcGIS.ADF.CATIDs;
    using ESRI.ArcGIS.Carto;
    using ESRI.ArcGIS.Controls;
    using System;
    using System.Runtime.InteropServices;
    using TaskManage;

    [Guid("1f1b500c-0180-4449-913b-59488c803633"), ClassInterface(ClassInterfaceType.None), ProgId("Cartography.Business.RemoveLayerMenu")]
    public sealed class RemoveLayerMenu : BaseCommand
    {
        private object m_Hook;

        public RemoveLayerMenu()
        {
            base.m_category = "LayerControl";
            base.m_caption = "移除图层";
            base.m_message = "移除图层";
            base.m_toolTip = "移除图层";
            base.m_name = "LayerControl_RemoveLayer";
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
                ITOCControl2 hook = this.m_Hook as ITOCControl2;
                ILayer customProperty = hook.CustomProperty as ILayer;
                hook.ActiveView.FocusMap.DeleteLayer(customProperty);
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
                for (int i = 0; i < EditTask.LayerList.Count; i++)
                {
                    ILayer layer2 = EditTask.LayerList[i] as ILayer;
                    if (customProperty == layer2)
                    {
                        return false;
                    }
                }
                return true;
            }
        }
    }
}

