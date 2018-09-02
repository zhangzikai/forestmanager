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

    [ClassInterface(ClassInterfaceType.None), ProgId("Cartography.Business.QueryDefinitionMenu"),Guid("0B01530F-6D01-41F0-AF52-B110F586FC0C")]
    public sealed class QueryDefinitionMenu : BaseCommand
    {
        private object _hook;

        public QueryDefinitionMenu()
        {
            base.m_category = "";
            base.m_caption = "定义查询";
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
            QueryDefinetion render = new QueryDefinetion(customProperty as IFeatureLayerDefinition);
            if (render.ShowDialog() == DialogResult.OK)
            {
                control.ActiveView.Refresh();
                //control.Update();
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
                if (((customProperty == null) || (customProperty.FeatureClass == null)) )
                {
                    return false;
                }
                return true;
            }
        }
    }
}


