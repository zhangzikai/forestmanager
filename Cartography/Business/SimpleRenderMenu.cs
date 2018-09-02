namespace Cartography.Business
{
    using Cartography;
    using Cartography.Render;
    using ESRI.ArcGIS.ADF.BaseClasses;
    using ESRI.ArcGIS.ADF.CATIDs;
    using ESRI.ArcGIS.Carto;
    using ESRI.ArcGIS.Controls;
    using ESRI.ArcGIS.Display;
    using ESRI.ArcGIS.Geodatabase;
    using ESRI.ArcGIS.Geometry;
    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;

    [ProgId("Cartography.Business.SimpleRender"), ClassInterface(ClassInterfaceType.None), Guid("11f6f56d-7920-4c3d-9fcf-282374951099")]
    public sealed class SimpleRenderMenu : BaseCommand
    {
        private object _hook;

        public SimpleRenderMenu()
        {
            base.m_category = "";
            base.m_caption = "单一符号";
            base.m_message = "";
            base.m_toolTip = "";
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
            ITOCControl2 control = this._hook as ITOCControl2;
            IFeatureLayer customProperty = control.CustomProperty as IFeatureLayer;
            DevSymbolSelector selector = new DevSymbolSelector();
            List<ISymbol> featureLayerSymbol = RenderService.GetFeatureLayerSymbol(customProperty);
            IStyleGalleryItem item = null;
            item = selector.GetItem(customProperty.FeatureClass.ShapeType, featureLayerSymbol, 0);
            selector.Dispose();
            if (item != null)
            {
                SingleSymbolCarto.SetSimpleRenderSymbol(customProperty, item.Item as ISymbol);
                IFeatureClass featureClass = customProperty.FeatureClass;
                control.ActiveView.Refresh();
                control.Update();
            }
        }

        public override void OnCreate(object hook)
        {
            if (hook != null)
            {
                this._hook = hook;
            }
        }

        [ComVisible(false), ComRegisterFunction]
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

