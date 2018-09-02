namespace AttributesEdit
{
    using ESRI.ArcGIS.ADF.BaseClasses;
    using ESRI.ArcGIS.ADF.CATIDs;
    using ESRI.ArcGIS.Carto;
    using ESRI.ArcGIS.Controls;
    using ESRI.ArcGIS.Geodatabase;
    using ESRI.ArcGIS.Geometry;
    using FunFactory;
    using System;
    using System.Diagnostics;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;

    [ClassInterface(ClassInterfaceType.None), ProgId("AttributesEdit.ToolHSEdit"), Guid("ca9c3957-a397-42b7-825c-006da4ca6dfd")]
    public sealed class ToolHSEdit : BaseTool
    {
        private IHookHelper m_hookHelper;
        private UserControl m_UserControl;

        public ToolHSEdit(UserControl pUserControl)
        {
            base.m_category = "";
            base.m_caption = "";
            base.m_message = "";
            base.m_toolTip = "遥感核实属性";
            base.m_name = "";
            try
            {
                base.m_cursor = new System.Windows.Forms.Cursor(base.GetType(), "ToolAttributesEdit.cur");
            }
            catch (Exception exception)
            {
                Trace.WriteLine(exception.Message, "Invalid Bitmap");
            }
            this.m_UserControl = pUserControl;
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
        }

        public override void OnCreate(object hook)
        {
            if (this.m_hookHelper == null)
            {
                this.m_hookHelper = new HookHelperClass();
            }
            this.m_hookHelper.Hook = hook;
        }

        public override void OnMouseDown(int Button, int Shift, int X, int Y)
        {
        }

        public override void OnMouseMove(int Button, int Shift, int X, int Y)
        {
        }

        public override void OnMouseUp(int Button, int Shift, int X, int Y)
        {
            if ((this.m_hookHelper.ActiveView != null) && (Button == Keys.LButton.GetHashCode()))
            {
                IPoint pPoint = null;
                pPoint = this.m_hookHelper.ActiveView.ScreenDisplay.DisplayTransformation.ToMapPoint(X, Y);
                IEnvelope searchEnvelope = DataFuncs.GetSearchEnvelope(this.m_hookHelper.ActiveView, pPoint);
                if (searchEnvelope != null)
                {
                    IFeature feature = null;
                    IFeatureLayer pFLayer = GISFunFactory.LayerFun.FindFeatureLayer(this.m_hookHelper.FocusMap as IBasicMap, "遥感判断", true);
                    if (pFLayer != null)
                    {
                        feature = DataFuncs.SearchFeature(pFLayer, searchEnvelope, esriSpatialRelEnum.esriSpatialRelIntersects);
                    }
                    IActiveView activeView = this.m_hookHelper.ActiveView;
                    IFeatureSelection selection = pFLayer as IFeatureSelection;
                    selection.Clear();
                    if (feature != null)
                    {
                        selection.Add(feature);
                    }
                    activeView.PartialRefresh(esriViewDrawPhase.esriViewGeoSelection | esriViewDrawPhase.esriViewGeography, null, null);
                    activeView.Refresh();
                    UserControlAttrEdit userControl = this.m_UserControl as UserControlAttrEdit;
                    if (userControl != null)
                    {
                        userControl.Visible = true;
                        userControl.EditHSAttributes(feature, this.m_hookHelper.Hook);
                    }
                }
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
    }
}

