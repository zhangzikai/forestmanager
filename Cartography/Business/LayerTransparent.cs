namespace Cartography.Business
{
    using ESRI.ArcGIS.ADF.BaseClasses;
    using ESRI.ArcGIS.ADF.CATIDs;
    using ESRI.ArcGIS.Carto;
    using ESRI.ArcGIS.Controls;
    using System;
    using System.Diagnostics;
    using System.Drawing;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;

    [ProgId("Cartography.Business.LayerTransparent"), Guid("7d69d1d1-6c34-49d8-beea-3abc0dd14815"), ClassInterface(ClassInterfaceType.None)]
    public sealed class LayerTransparent : BaseCommand
    {
        private object _hook;

        public LayerTransparent()
        {
            base.m_category = "LayerControl";
            base.m_caption = "透明度与显示比例";
            base.m_message = "设置图层透明度";
            base.m_toolTip = "图层透明度";
            base.m_name = "LayerControl_LayerTransparent";
            try
            {
                string resource = base.GetType().Name + ".bmp";
                base.m_bitmap = new Bitmap(base.GetType(), resource);
            }
            catch (Exception exception)
            {
                Trace.WriteLine(exception.Message, "Invalid Bitmap");
            }
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
            ITOCControl2 control = this._hook as ITOCControl2;
            ILayer customProperty = control.CustomProperty as ILayer;
            Transparent transparent = new Transparent(customProperty);
            if (transparent.ShowDialog() == DialogResult.OK)
            {
                control.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeography, customProperty, control.ActiveView.Extent);
            }
            transparent = null;
        }

        public override void OnCreate(object hook)
        {
            if (hook != null)
            {
                this._hook = hook;
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
                if (this._hook != null)
                {
                    ITOCControl2 control = this._hook as ITOCControl2;
                    if (control == null)
                    {
                        return false;
                    }
                    if (control.CustomProperty is ILayerEffects)
                    {
                        return true;
                    }
                }
                return false;
            }
        }
    }
}

