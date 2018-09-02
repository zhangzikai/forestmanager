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
    using System.Diagnostics;
    using System.Drawing;
    using System.Runtime.InteropServices;
    using TaskManage;
    using TopologyCheck.Error;
    using TopologyCheck.Properties;
    using Utilities;

    [ProgId("TopologyCheck.Checker.SelfIntersectCheckTool"), Guid("4317c2f2-270d-47a2-9f01-78f1f7c3e507"), ClassInterface(ClassInterfaceType.None)]
    public sealed class SelfIntersectCheckTool : BaseCommand, ITool
    {
        private IFeatureLayer _layer;
        private SelfIntersectChecker _sc;
        private Dictionary<int, List<IElement>> elements = new Dictionary<int, List<IElement>>();
        private IHookHelper m_hookHelper;
        private const string mClassName = "TopologyCheck.Checker.PointRepeatCheckTool";
        private ErrorOpt mErrOpt = UtilFactory.GetErrorOpt();
        private string mSubSysName = UtilFactory.GetConfigOpt().GetSystemName();

        public SelfIntersectCheckTool(IFeatureLayer pLayer)
        {
            base.m_category = "Topo";
            base.m_caption = "自相交检查";
            base.m_message = "";
            base.m_toolTip = "自相交检查";
            base.m_name = "Topo_SelfIntersectCheckTool";
            this._layer = pLayer;
            this._sc = new SelfIntersectChecker(pLayer);
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
                    IPoint point = this.m_hookHelper.ActiveView.ScreenDisplay.DisplayTransformation.ToMapPoint(x, y);
                    ISpatialFilter queryFilter = new SpatialFilterClass();
                    queryFilter.Geometry = point;
                    queryFilter.GeometryField = this._layer.FeatureClass.ShapeFieldName;
                    queryFilter.SubFields = this._layer.FeatureClass.ShapeFieldName;
                    queryFilter.SpatialRel = esriSpatialRelEnum.esriSpatialRelWithin;
                    IFeature pFeature = this._layer.Search(queryFilter, false).NextFeature();
                    if (pFeature != null)
                    {
                        List<double[]> list = new List<double[]>();
                        object pErrFeatureInf = list;
                        IGraphicsContainer focusMap = this.m_hookHelper.ActiveView.FocusMap as IGraphicsContainer;
                        if (!this._sc.CheckFeature(pFeature, ref pErrFeatureInf))
                        {
                            XtraMessageBox.Show("拓扑错误！");
                            if (this.elements.ContainsKey(pFeature.OID))
                            {
                                List<IElement> list2 = this.elements[pFeature.OID];
                                foreach (IElement element in list2)
                                {
                                    focusMap.DeleteElement(element);
                                }
                                this.elements[pFeature.OID].Clear();
                            }
                            else
                            {
                                List<IElement> list3 = new List<IElement>();
                                this.elements.Add(pFeature.OID, list3);
                            }
                            foreach (double[] numArray in list)
                            {
                                double pX = numArray[0];
                                double pY = numArray[1];
                                IElement item = ErrManager.CreateMarkerElement(this.m_hookHelper.ActiveView, pX, pY, Resources.Err, (this._layer.FeatureClass as IGeoDataset).SpatialReference);
                                this.elements[pFeature.OID].Add(item);
                                focusMap.AddElement(item, 0);
                            }
                            this.m_hookHelper.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, this.m_hookHelper.ActiveView.Extent);
                        }
                        else
                        {
                            if (this.elements.ContainsKey(pFeature.OID))
                            {
                                List<IElement> list4 = this.elements[pFeature.OID];
                                foreach (IElement element3 in list4)
                                {
                                    focusMap.DeleteElement(element3);
                                }
                                this.elements.Remove(pFeature.OID);
                                this.m_hookHelper.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, this.m_hookHelper.ActiveView.Extent);
                            }
                            XtraMessageBox.Show("拓扑正确！");
                        }
                    }
                }
                catch (Exception exception)
                {
                    this.mErrOpt.ErrorOperate(this.mSubSysName, "TopologyCheck.Checker.PointRepeatCheckTool", "OnMouseDown", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                    XtraMessageBox.Show(exception.Message);
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
                if (EditTask.EditLayer == null)
                {
                    return false;
                }
                return (EditTask.EditLayer.FeatureClass.ShapeType == esriGeometryType.esriGeometryPolygon);
            }
        }
    }
}

