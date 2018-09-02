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
    using ShapeEdit;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Drawing;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;
    using TaskManage;
    using TopologyCheck.Error;
    using TopologyCheck.Properties;
    using Utilities;

    [Guid("3969803c-ec42-4f99-9192-b26862b1054b"), ClassInterface(ClassInterfaceType.None), ProgId("TopologyCheck.Checker.AngleCheckTool")]
    public sealed class AngleCheckTool : BaseCommand, ITool
    {
        private AngleChecker _ac;
        private IFeatureLayer _Layer;
        private IWin32Window _win;
        private IHookHelper m_hookHelper;
        private const string mClassName = "TopologyCheck.Checker.AngleCheckTool";
        private ErrorOpt mErrOpt = UtilFactory.GetErrorOpt();
        private string mSubSysName = UtilFactory.GetConfigOpt().GetSystemName();

        public AngleCheckTool(IFeatureLayer pLayer, IWin32Window pWin)
        {
            base.m_category = "Topo";
            base.m_caption = "锐角检查";
            base.m_message = "检查多边形角度是否小于指定的角度";
            base.m_toolTip = "锐角检查";
            base.m_name = "Topo_AngleCheck";
            this._Layer = pLayer;
            this._win = pWin;
            this._ac = new AngleChecker();
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
                    string configValue = UtilFactory.GetConfigOpt().GetConfigValue("AngleValue");
                    if (string.IsNullOrEmpty(configValue))
                    {
                        XtraMessageBox.Show("请先在规则设置中设置最小角度！");
                    }
                    else
                    {
                        this._ac.CosAngle = double.Parse(configValue);
                        IPoint pPoint = this.m_hookHelper.ActiveView.ScreenDisplay.DisplayTransformation.ToMapPoint(x, y);
                        IEnvelope searchEnvelope = FeatureFuncs.GetSearchEnvelope(this.m_hookHelper.ActiveView, pPoint);
                        IFeature pFeature = FeatureFuncs.SearchFeatures(this._Layer, searchEnvelope, esriSpatialRelEnum.esriSpatialRelIntersects).NextFeature();
                        if (pFeature != null)
                        {
                            List<double[]> list = new List<double[]>();
                            object pErrFeatureInf = list;
                            IGraphicsContainer focusMap = this.m_hookHelper.ActiveView.FocusMap as IGraphicsContainer;
                            if (!this._ac.CheckFeature(pFeature, ref pErrFeatureInf))
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
                                    IElement item = ErrManager.CreateMarkerElement(this.m_hookHelper.ActiveView, pX, pY, TopologyCheck.Properties.Resources.Err, (this._Layer.FeatureClass as IGeoDataset).SpatialReference);
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
                }
                catch (Exception exception)
                {
                    this.mErrOpt.ErrorOperate(this.mSubSysName, "TopologyCheck.Checker.AngleCheckTool", "OnMouseDown", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                    XtraMessageBox.Show(exception.Message);
                }
            }
        }

        public void Refresh(int hdc)
        {
        }

        [ComVisible(false), ComRegisterFunction]
        private static void RegisterFunction(System.Type registerType)
        {
            ArcGISCategoryRegistration(registerType);
        }

        [ComUnregisterFunction, ComVisible(false)]
        private static void UnregisterFunction(System.Type registerType)
        {
            ArcGISCategoryUnregistration(registerType);
        }

        public int Cursor
        {
            get
            {
                return TopologyCheck.Checker.ToolCursor.Validate;
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

