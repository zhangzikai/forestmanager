namespace Cartography.Business
{
    using Cartography.Render;
    using ESRI.ArcGIS.ADF.BaseClasses;
    using ESRI.ArcGIS.ADF.CATIDs;
    using ESRI.ArcGIS.Carto;
    using ESRI.ArcGIS.Controls;
    using ESRI.ArcGIS.Geodatabase;
    using ESRI.ArcGIS.Geometry;
    using System;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;

    [ClassInterface(ClassInterfaceType.None), ProgId("Cartography.Business.UniqueValueRenderMenu"), Guid("97ba2bd5-c356-4f8f-a13c-1c59d823c7db")]
    public sealed class UniqueValueRenderMenu : BaseCommand
    {
        private object _hook;

        public UniqueValueRenderMenu()
        {
            base.m_category = "";
            base.m_caption = "唯一值单字段";
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
            ITOCControl2 control = this._hook as ITOCControl2;
            IFeatureLayer customProperty = control.CustomProperty as IFeatureLayer;
            UniqueRender render = new UniqueRender(customProperty);
            if (render.ShowDialog() == DialogResult.OK)
            {
                IFeatureClass featureClass = customProperty.FeatureClass;
                control.ActiveView.Refresh();
                control.Update();
            }
            render.Dispose();
            render = null;
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

        [ComUnregisterFunction, ComVisible(false)]
        private static void UnregisterFunction(System.Type registerType)
        {
            ArcGISCategoryUnregistration(registerType);
        }

        public override bool Enabled
        {
            get
            {
                if (this._hook == null)
                {
                    return false;
                }
                ITOCControl2 control = this._hook as ITOCControl2;
                if (control == null)
                {
                    return false;
                }
                IFeatureLayer customProperty = control.CustomProperty as IFeatureLayer;
                if (((customProperty == null) || (customProperty.FeatureClass == null)) || (((customProperty.FeatureClass.ShapeType != esriGeometryType.esriGeometryPoint) && (customProperty.FeatureClass.ShapeType != esriGeometryType.esriGeometryPolygon)) && (customProperty.FeatureClass.ShapeType != esriGeometryType.esriGeometryPolyline)))
                {
                    return false;
                }
                return true;
            }
        }
    }
}

