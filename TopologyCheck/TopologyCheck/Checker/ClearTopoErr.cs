namespace TopologyCheck.Checker
{
    using ESRI.ArcGIS.ADF.BaseClasses;
    using ESRI.ArcGIS.Carto;
    using ESRI.ArcGIS.Controls;
    using ESRI.ArcGIS.Geometry;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Drawing;
    using TaskManage;
    using TopologyCheck.Error;

    public class ClearTopoErr : BaseCommand
    {
        private IHookHelper m_hookHelper;

        public ClearTopoErr()
        {
            base.m_category = "Topo";
            base.m_caption = "清空拓扑错误";
            base.m_message = "";
            base.m_toolTip = "清空拓扑错误";
            base.m_name = "Topo_ClearErrElement";
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

        public override void OnClick()
        {
            IGraphicsContainer focusMap = this.m_hookHelper.ActiveView.FocusMap as IGraphicsContainer;
            Dictionary<int, List<IElement>> errElements = ErrManager.ErrElements;
            foreach (KeyValuePair<int, List<IElement>> pair in errElements)
            {
                List<IElement> list = pair.Value;
                foreach (IElement element in list)
                {
                    focusMap.DeleteElement(element);
                }
                list.Clear();
            }
            errElements.Clear();
            this.m_hookHelper.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, this.m_hookHelper.ActiveView.Extent);
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

        public override bool Enabled
        {
            get
            {
                IFeatureLayer editLayer = EditTask.EditLayer;
                if (editLayer.FeatureClass == null)
                {
                    return false;
                }
                if (editLayer.FeatureClass.ShapeType == esriGeometryType.esriGeometryPolyline)
                {
                    return false;
                }
                return base.Enabled;
            }
        }
    }
}

