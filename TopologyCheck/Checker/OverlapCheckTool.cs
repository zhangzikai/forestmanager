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
    using System.Diagnostics;
    using System.Drawing;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;
    using TaskManage;
    using TopologyCheck.Base;
    using TopologyCheck.Error;
    using Utilities;

    /// <summary>
    /// 重叠检查工具类
    /// </summary>
    [ProgId("TopologyCheck.Checker.OverlapCheckTool"), ClassInterface(ClassInterfaceType.None), Guid("ff4d19f6-e5c0-43e2-8f6d-59554036293a")]
    public sealed class OverlapCheckTool : BaseCommand, ITool
    {
        private int _cursor;
        private OverLapChecker _olChecker;
        private IHookHelper m_hookHelper;
        private const string mClassName = "TopologyCheck.Checker.OverlapCheckTool";
        private ErrorOpt mErrOpt = UtilFactory.GetErrorOpt();
        private string mSubSysName = UtilFactory.GetConfigOpt().GetSystemName();

        /// <summary>
        /// 重叠检查工具类
        /// </summary>
        public OverlapCheckTool()
        {
            base.m_category = "Topo";
            base.m_caption = "重叠检查";
            base.m_message = "";
            base.m_toolTip = "重叠检查";
            base.m_name = "Topo_OverlapCheckTool";
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
                //this._cursor = TopologyCheck.Checker.ToolCursor.Validate;
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
                    IFeatureLayer targetLayer = Editor.UniqueInstance.TargetLayer;
                    if (targetLayer == null)
                    {
                        return;
                    }
                    IPoint pPoint = this.m_hookHelper.ActiveView.ScreenDisplay.DisplayTransformation.ToMapPoint(x, y);
                    ISpatialFilter queryFilter = new SpatialFilterClass();
                    queryFilter.GeometryField = targetLayer.FeatureClass.ShapeFieldName;
                    queryFilter.SubFields = targetLayer.FeatureClass.ShapeFieldName;
                    if (targetLayer.FeatureClass.ShapeType == esriGeometryType.esriGeometryPoint)
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
                    IFeature pFeature = targetLayer.Search(queryFilter, false).NextFeature();
                    if (pFeature == null)
                    {
                        return;
                    }
                    this._cursor = Cursors.WaitCursor.Handle.ToInt32();
                    object missing = System.Type.Missing;
                    this._olChecker = new OverLapChecker(targetLayer, 0);
                    if (this._olChecker.CheckFeature(pFeature, ref missing))
                    {
                        XtraMessageBox.Show("拓扑正确！");
                    }
                    else
                    {
                        XtraMessageBox.Show("拓扑错误！");
                        ErrManager.AddErrTopoElement(this.m_hookHelper.ActiveView, missing, pFeature);
                    }
                }
                catch (Exception exception)
                {
                    if (!Editor.UniqueInstance.IsBeingEdited)
                    {
                        Editor.UniqueInstance.StartEdit(Editor.UniqueInstance.Workspace, Editor.UniqueInstance.Map);
                    }
                    this.mErrOpt.ErrorOperate(this.mSubSysName, "TopologyCheck.Checker.OverlapCheckTool", "OnMouseUp", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                    XtraMessageBox.Show("拓扑检查遇到错误！");
                }
                //this._cursor = TopologyCheck.Checker.ToolCursor.Validate;
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

        [ComVisible(false), ComUnregisterFunction]
        private static void UnregisterFunction(System.Type registerType)
        {
            ArcGISCategoryUnregistration(registerType);
        }

        public int Cursor
        {
            get
            {
                return this._cursor;
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

