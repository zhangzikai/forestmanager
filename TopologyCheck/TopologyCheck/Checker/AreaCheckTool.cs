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
    using System.Windows.Forms;
    using TaskManage;
    using TopologyCheck.Error;
    using Utilities;

    [ProgId("TopologyCheck.Checker.AreaCheckTool"), ClassInterface(ClassInterfaceType.None), Guid("7a7d621d-94c2-403d-9322-b7ce2a1e73b4")]
    public sealed class AreaCheckTool : BaseCommand, ITool
    {
        private AreaChecker _ac;
        private IFeatureLayer _layer;
        private IWin32Window _win;
        private IHookHelper m_hookHelper;
        private const string mClassName = "TopologyCheck.Checker.AreaCheckTool";
        private ErrorOpt mErrOpt = UtilFactory.GetErrorOpt();
        private string mSubSysName = UtilFactory.GetConfigOpt().GetSystemName();

        public AreaCheckTool(IFeatureLayer pLayer, IWin32Window pWin)
        {
            base.m_category = "Topo";
            base.m_caption = "面积检查";
            base.m_message = "检查多边形面积是否小于指定的面积";
            base.m_toolTip = "面积检查";
            base.m_name = "Topo_AreaCheckTool";
            this._layer = pLayer;
            this._win = pWin;
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
                this._ac = new AreaChecker(this.m_hookHelper.ActiveView);
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
                    string configValue = UtilFactory.GetConfigOpt().GetConfigValue("AreaValue");
                    if (string.IsNullOrEmpty(configValue))
                    {
                        XtraMessageBox.Show("请先在规则设置中设置最小面积！");
                    }
                    else
                    {
                        this._ac.Area = double.Parse(configValue);
                        IPoint point = this.m_hookHelper.ActiveView.ScreenDisplay.DisplayTransformation.ToMapPoint(x, y);
                        ISpatialFilter queryFilter = new SpatialFilterClass();
                        queryFilter.Geometry = point;
                        queryFilter.GeometryField = this._layer.FeatureClass.ShapeFieldName;
                        queryFilter.SubFields = this._layer.FeatureClass.ShapeFieldName;
                        queryFilter.SpatialRel = esriSpatialRelEnum.esriSpatialRelWithin;
                        IFeature pFeature = this._layer.Search(queryFilter, false).NextFeature();
                        if (pFeature != null)
                        {
                            object missing = System.Type.Missing;
                            IGraphicsContainer activeView = this.m_hookHelper.ActiveView as IGraphicsContainer;
                            if (!this._ac.CheckFeature(pFeature, ref missing))
                            {
                                XtraMessageBox.Show("拓扑错误！");
                                List<IElement> list = null;
                                if (ErrManager.ErrElements.ContainsKey(pFeature.OID))
                                {
                                    list = ErrManager.ErrElements[pFeature.OID];
                                    foreach (IElement element in list)
                                    {
                                        activeView.DeleteElement(element);
                                    }
                                    list.Clear();
                                }
                                else
                                {
                                    list = new List<IElement>();
                                    ErrManager.ErrElements.Add(pFeature.OID, list);
                                }
                                ErrManager.AddErrAreaElement(this.m_hookHelper.ActiveView, pFeature, ref list);
                            }
                            else
                            {
                                if (ErrManager.ErrElements.ContainsKey(pFeature.OID))
                                {
                                    List<IElement> list2 = ErrManager.ErrElements[pFeature.OID];
                                    foreach (IElement element2 in list2)
                                    {
                                        activeView.DeleteElement(element2);
                                    }
                                    list2.Clear();
                                    ErrManager.ErrElements.Remove(pFeature.OID);
                                    this.m_hookHelper.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, this.m_hookHelper.ActiveView.Extent);
                                }
                                XtraMessageBox.Show("拓扑正确！");
                            }
                        }
                    }
                }
                catch (Exception exception)
                {
                    this.mErrOpt.ErrorOperate(this.mSubSysName, "TopologyCheck.Checker.AreaCheckTool", "OnMouseDown", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                    XtraMessageBox.Show(exception.Message);
                }
            }
        }

        public void Refresh(int hdc)
        {
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

