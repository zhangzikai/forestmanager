namespace TopologyCheck.TopologyModify
{
    using ESRI.ArcGIS.Controls;
    using ShapeEdit;
    using System;
    using System.Collections.Generic;
    using ESRI.ArcGIS.SystemUI;

    internal class PointModifyStrategy : TopoModifyStrategy, ITopoModifyStrategy
    {
        public PointModifyStrategy()
        {
        }

        public PointModifyStrategy(IMapControl4 pControl) : base(pControl)
        {
            base._strategyNames = new string[] { "删除重复点", "编辑节点工具" };
            base._tools = new List<ITool>();
            base._tools.Add(ToolFactory.GetRPointDeleteExTool());
            base._tools.Add(ToolFactory.GetEditTool());
            base._strategyNames = new string[] { "编辑节点", "删除重复点" };
            base._tools = new List<ITool>();
            base._tools.Add(ToolFactory.GetEditTool());
        }
    }
}

