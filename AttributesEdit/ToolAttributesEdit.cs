namespace AttributesEdit
{
    using ESRI.ArcGIS.ADF.BaseClasses;
    using ESRI.ArcGIS.Carto;
    using ESRI.ArcGIS.Controls;
    using ESRI.ArcGIS.Geodatabase;
    using ESRI.ArcGIS.Geometry;
    using jn.isos.log;
    using ShapeEdit;
    using System;
    using System.Diagnostics;
    using System.Windows.Forms;
    using TaskManage;

    /// <summary>
    /// 属性编辑工具类
    /// </summary>
    public class ToolAttributesEdit : BaseTool
    {
        private IHookHelper m_hookHelper;
        private UserControl m_UserControl;
        private Logger m_log;

        /// <summary>
        /// 属性编辑工具类
        /// </summary>
        /// <param name="pUserControl"></param>
        public ToolAttributesEdit(UserControl pUserControl)
        {
            m_log = LoggerManager.CreateLogger("UI", typeof(ToolAttributesEdit));
            base.m_category = "";
            base.m_caption = "";
            base.m_message = "";
            base.m_toolTip = "属性编辑";
            base.m_name = "ToolAttributesEdit";
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

        public override void OnClick()
        {
        }

        public override void OnCreate(object hook)
        {
            try
            {
                this.m_hookHelper = new HookHelperClass();
                this.m_hookHelper.Hook = hook;
                if (this.m_hookHelper.ActiveView == null)
                {
                    this.m_hookHelper = null;
                }
            }
            catch
            {
                this.m_hookHelper = null;
            }
            if (this.m_hookHelper == null)
            {
                base.m_enabled = false;
            }
            else
            {
                base.m_enabled = true;
            }
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
                    IFeatureLayer editLayer = EditTask.EditLayer;
                    if (editLayer != null)
                    {
                        feature = DataFuncs.SearchFeature(editLayer, searchEnvelope, esriSpatialRelEnum.esriSpatialRelIntersects);
                    }
                    IActiveView activeView = this.m_hookHelper.ActiveView;
                    IFeatureSelection selection = editLayer as IFeatureSelection;
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
                        m_log.Warn("start show");
                        userControl.EditAttributes(feature, this.m_hookHelper.Hook);
                        m_log.Warn("end show");
                    }
                }
            }
        }

        public override bool Enabled
        {
            get
            {
                if (!Editor.UniqueInstance.IsBeingEdited)
                {
                    return false;
                }
                return ((Editor.UniqueInstance.TargetLayer != null) && (Editor.UniqueInstance.TargetLayer.FeatureClass != null));
            }
        }
    }
}

