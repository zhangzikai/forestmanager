namespace QueryCommon
{
    using ESRI.ArcGIS.ADF.BaseClasses;
    using ESRI.ArcGIS.ADF.CATIDs;
    using ESRI.ArcGIS.Carto;
    using ESRI.ArcGIS.Controls;
    using ESRI.ArcGIS.Geodatabase;
    using ESRI.ArcGIS.Geometry;
    using ESRI.ArcGIS.SystemUI;
    using FunFactory;
    using System;
    using System.Runtime.InteropServices;
    using Utilities;

    [ClassInterface(ClassInterfaceType.None), ProgId("QueryCommon.LocationCounty"), Guid("277e39d2-1728-4937-9792-9f1953963992")]
    public sealed class LocationCounty : BaseCommand
    {
        private ICommand _command;
        private IHookHelper m_HookHelper;
        private IFeatureLayer m_pCLayer;
        private const string mClassName = "QueryCommon.LocationCounty";
        private ErrorOpt mErrOpt = UtilFactory.GetErrorOpt();
        private string mSubSysName = UtilFactory.GetConfigOpt().GetSystemName();
        private const string myClassName = "全图";

        public LocationCounty()
        {
            base.m_category = "FullMap";
            base.m_caption = "全图";
            base.m_message = "全图";
            base.m_toolTip = "全图";
            base.m_name = "FullMap";
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
            string configValue = UtilFactory.GetConfigOpt().GetConfigValue("CountyLayerName");
            this.m_pCLayer = GISFunFactory.LayerFun.FindFeatureLayer(this.m_HookHelper.FocusMap as IBasicMap, configValue, true);
            if (this.m_pCLayer != null)
            {
                IFeature pFeature = this.m_pCLayer.Search(null, false).NextFeature();
                if (pFeature != null)
                {
                    if (!this.m_pCLayer.Visible)
                    {
                        this.m_pCLayer.Visible = true;
                        this.m_HookHelper.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewAll, this.m_pCLayer, this.m_HookHelper.ActiveView.Extent);
                        for (int i = 0; i < 0x2710; i++)
                        {
                        }
                    }
                    this.SelectFeature(this.m_pCLayer, pFeature);
                    this.ZoomToFeature(this.m_HookHelper.FocusMap, pFeature);
                }
            }
        }

        public override void OnCreate(object hook)
        {
            if (hook != null)
            {
                if (this.m_HookHelper == null)
                {
                    this.m_HookHelper = new HookHelperClass();
                }
                this.m_HookHelper.Hook = hook;
            }
        }

        [ComRegisterFunction, ComVisible(false)]
        private static void RegisterFunction(Type registerType)
        {
            ArcGISCategoryRegistration(registerType);
        }

        private void SelectFeature(IFeatureLayer pFLayer, IFeature pFeature)
        {
            (pFLayer as IFeatureSelection).Clear();
            if ((pFLayer != null) && (pFeature != null))
            {
                this.m_HookHelper.FocusMap.SelectFeature(pFLayer, pFeature);
            }
        }

        [ComVisible(false), ComUnregisterFunction]
        private static void UnregisterFunction(Type registerType)
        {
            ArcGISCategoryUnregistration(registerType);
        }

        private void ZoomToFeature(IMap pMap, IFeature pFeature)
        {
            try
            {
                if ((pMap != null) && (pFeature != null))
                {
                    IGeometry shape = null;
                    IActiveView view = null;
                    IEnvelope envelope = null;
                    shape = pFeature.Shape;
                    if (shape.SpatialReference != pMap.SpatialReference)
                    {
                        shape.Project(pMap.SpatialReference);
                        shape.SpatialReference = pMap.SpatialReference;
                    }
                    envelope = new EnvelopeClass();
                    envelope = shape.Envelope;
                    view = pMap as IActiveView;
                    if (shape.GeometryType == esriGeometryType.esriGeometryPoint)
                    {
                        double num = 0.0;
                        double num2 = 0.0;
                        num = view.FullExtent.Width / 38.0;
                        num2 = view.FullExtent.Height / 38.0;
                        IPoint p = null;
                        p = shape as IPoint;
                        if ((num == 0.0) | (num2 == 0.0))
                        {
                            return;
                        }
                        envelope.Width = num;
                        envelope.Height = num2;
                        envelope.CenterAt(p);
                    }
                    else
                    {
                        envelope.Expand(1.2, 1.2, true);
                    }
                    if ((view.Extent.Width != envelope.Width) && (view.Extent.Height != envelope.Height))
                    {
                        view.FullExtent = envelope;
                        view.Refresh();
                        for (int i = 0; i < 0x2710; i++)
                        {
                        }
                    }
                    else
                    {
                        IMapControl2 hook = (IMapControl2) this.m_HookHelper.Hook;
                        if (hook != null)
                        {
                            hook.FlashShape(pFeature.Shape, 3, 300, null);
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "QueryCommon.LocationCounty", "ZoomToFeature", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void ZoomToGeometry(IMap pMap, IGeometry pGeometry)
        {
            try
            {
                if ((pMap != null) && (pGeometry != null))
                {
                    IActiveView view = null;
                    IEnvelope envelope = null;
                    envelope = new EnvelopeClass();
                    envelope = pGeometry.Envelope;
                    view = pMap as IActiveView;
                    if (pGeometry.GeometryType == esriGeometryType.esriGeometryPoint)
                    {
                        double num = 0.0;
                        double num2 = 0.0;
                        num = view.FullExtent.Width / 38.0;
                        num2 = view.FullExtent.Height / 38.0;
                        IPoint p = null;
                        p = pGeometry as IPoint;
                        if ((num == 0.0) | (num2 == 0.0))
                        {
                            return;
                        }
                        envelope.Width = num;
                        envelope.Height = num2;
                        envelope.CenterAt(p);
                    }
                    else
                    {
                        envelope.Expand(1.25, 1.25, true);
                    }
                    view.Extent = envelope;
                    view.Refresh();
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "QueryCommon.LocationCounty", "ZoomToGeometry", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        public override bool Enabled
        {
            get
            {
                return (this.m_HookHelper.FocusMap != null);
            }
        }
    }
}

