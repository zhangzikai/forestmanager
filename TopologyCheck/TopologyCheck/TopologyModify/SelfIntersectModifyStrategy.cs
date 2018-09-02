namespace TopologyCheck.TopologyModify
{
    using ESRI.ArcGIS.Controls;
    using ShapeEdit;
    using System;
    using System.Collections.Generic;
    using ESRI.ArcGIS.SystemUI;

    internal class SelfIntersectModifyStrategy : TopoModifyStrategy, ITopoModifyStrategy
    {
        public SelfIntersectModifyStrategy()
        {
        }

        public SelfIntersectModifyStrategy(IMapControl4 pControl) : base(pControl)
        {
            base._strategyNames = new string[] { "简化", "编辑节点" };
            base._tools = new List<ITool>();
            base._tools.Add(ToolFactory.GetSimplifyTool());
            base._tools.Add(ToolFactory.GetEditTool());
        }
    }
}

