namespace TopologyCheck.Checker
{
    using DevExpress.XtraEditors;
    using ESRI.ArcGIS.ADF.BaseClasses;
    using ESRI.ArcGIS.ADF.CATIDs;
    using ESRI.ArcGIS.Carto;
    using ESRI.ArcGIS.Controls;
    using ESRI.ArcGIS.Geodatabase;
    using ESRI.ArcGIS.Geometry;
    using ESRI.ArcGIS.SystemUI;
    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    using TaskManage;
    using TopologyCheck.Base;
    using TopologyCheck.Error;
    using TopologyCheck.Properties;
    using Utilities;

    [ProgId("TopologyCheck.Checker.BoundaryBeyondCheckTool"), Guid("657da7d3-6a5c-427d-a47a-dc08c46ab0f2"), ClassInterface(ClassInterfaceType.None)]
    public sealed class BoundaryBeyondCheckTool : BaseCommand, ITool
    {
        private IGeometry _geo;
        private IHookHelper m_hookHelper;
        private const string mClassName = "TopologyCheck.Checker.BoundaryBeyondCheckTool";
        private ErrorOpt mErrOpt = UtilFactory.GetErrorOpt();
        private string mSubSysName = UtilFactory.GetConfigOpt().GetSystemName();

        public BoundaryBeyondCheckTool(IGeometry pGeo)
        {
            base.m_category = "Topo";
            base.m_caption = "边界检查";
            base.m_message = "检查多边形是否超出行政边界";
            base.m_toolTip = "边界检查";
            base.m_name = "Topo_BoundaryBeyondCheckTool";
            this._geo = pGeo;
        }

        private static void ArcGISCategoryRegistration(Type registerType)
        {
            ControlsCommands.Register(string.Format(@"HKEY_CLASSES_ROOT\CLSID\{{{0}}}", registerType.GUID));
        }

        private static void ArcGISCategoryUnregistration(Type registerType)
        {
            ControlsCommands.Unregister(string.Format(@"HKEY_CLASSES_ROOT\CLSID\{{{0}}}", registerType.GUID));
        }

        public bool Deactivate()
        {
            return true;
        }

        public override void OnClick()
        {
        }

        public bool OnContextMenu(int x, int y)
        {
            return false;
        }

        public override void OnCreate(object hook)
        {
            if (hook != null)
            {
                if (this.m_hookHelper == null)
                {
                    this.m_hookHelper = new HookHelperClass();
                }
                this.m_hookHelper.Hook = hook;
            }
        }

        public void OnDblClick()
        {
        }

        public void OnKeyDown(int keyCode, int shift)
        {
        }

        public void OnKeyUp(int keyCode, int shift)
        {
        }

        public void OnMouseDown(int button, int shift, int x, int y)
        {
        }

        public void OnMouseMove(int button, int shift, int x, int y)
        {
        }

        public void OnMouseUp(int button, int shift, int x, int y)
        {
            if (button != 2)
            {
                try
                {
                    IPoint pPoint = this.m_hookHelper.ActiveView.ScreenDisplay.DisplayTransformation.ToMapPoint(x, y);
                    IFeatureLayer editLayer = EditTask.EditLayer;
                    ISpatialFilter queryFilter = new SpatialFilterClass();
                    queryFilter.GeometryField = editLayer.FeatureClass.ShapeFieldName;
                    queryFilter.SubFields = editLayer.FeatureClass.ShapeFieldName;
                    if (editLayer.FeatureClass.ShapeType == esriGeometryType.esriGeometryPoint)
                    {
                        IEnvelope searchEnvelope = SpatialAnalysis.GetSearchEnvelope(this.m_hookHelper.ActiveView, pPoint);
                        if (searchEnvelope == null)
                        {
                            return;
                        }
                        queryFilter.Geometry = searchEnvelope;
                        queryFilter.SpatialRel = esriSpatialRelEnum.esriSpatialRelIntersects;
                    }
                    else
                    {
                        queryFilter.Geometry = pPoint;
                        queryFilter.SpatialRel = esriSpatialRelEnum.esriSpatialRelWithin;
                    }
                    IFeature pFeature = editLayer.Search(queryFilter, false).NextFeature();
                    if (pFeature != null)
                    {
                        List<double[]> list = new List<double[]>();
                        object pErrInfo = list;
                        IGraphicsContainer focusMap = this.m_hookHelper.ActiveView.FocusMap as IGraphicsContainer;
                        BoundaryBeyondChecker checker = new BoundaryBeyondChecker(EditTask.EditLayer, this._geo);
                        if (!checker.CheckFeature(pFeature, ref pErrInfo))
                        {
                            XtraMessageBox.Show("拓扑错误！");
                            List<IElement> list2 = null;
                            if (ErrManager.ErrElements.ContainsKey(pFeature.OID))
                            {
                                list2 = ErrManager.ErrElements[pFeature.OID];
                                foreach (IElement element in list2)
                                {
                                    focusMap.DeleteElement(element);
                                }
                                list2.Clear();
                            }
                            else
                            {
                                list2 = new List<IElement>();
                                ErrManager.ErrElements.Add(pFeature.OID, list2);
                            }
                            foreach (double[] numArray in list)
                            {
                                double pX = numArray[0];
                                double pY = numArray[1];
                                IElement item = ErrManager.CreateMarkerElement(this.m_hookHelper.ActiveView, pX, pY, Resources.Err, (editLayer.FeatureClass as IGeoDataset).SpatialReference);
                                list2.Add(item);
                                focusMap.AddElement(item, 0);
                            }
                            this.m_hookHelper.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, this.m_hookHelper.ActiveView.Extent);
                        }
                        else
                        {
                            if (ErrManager.ErrElements.ContainsKey(pFeature.OID))
                            {
                                List<IElement> list3 = ErrManager.ErrElements[pFeature.OID];
                                foreach (IElement element3 in list3)
                                {
                                    focusMap.DeleteElement(element3);
                                }
                                list3.Clear();
                                ErrManager.ErrElements.Remove(pFeature.OID);
                                this.m_hookHelper.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, this.m_hookHelper.ActiveView.Extent);
                            }
                            XtraMessageBox.Show("拓扑正确！");
                        }
                    }
                }
                catch (Exception exception)
                {
                    this.mErrOpt.ErrorOperate(this.mSubSysName, "TopologyCheck.Checker.BoundaryBeyondCheckTool", "OnMouseUp", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                }
            }
        }

        public void Refresh(int hdc)
        {
        }

        [ComRegisterFunction, ComVisible(false)]
        private static void RegisterFunction(Type registerType)
        {
            ArcGISCategoryRegistration(registerType);
        }

        [ComUnregisterFunction, ComVisible(false)]
        private static void UnregisterFunction(Type registerType)
        {
            ArcGISCategoryUnregistration(registerType);
        }

        public int Cursor
        {
            get
            {
                return ToolCursor.Validate;
            }
        }

        public override bool Enabled
        {
            get
            {
                if (!(this.m_hookHelper.Hook is IMapControl4))
                {
                    return false;
                }
                if (this._geo == null)
                {
                    return false;
                }
                IFeatureLayer editLayer = EditTask.EditLayer;
                if (editLayer.FeatureClass == null)
                {
                    return false;
                }
                if (editLayer.FeatureClass.ShapeType == esriGeometryType.esriGeometryPolyline)
                {
                    return false;
                }
                return true;
            }
        }
    }
}

