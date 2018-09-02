namespace TopologyCheck.TopologyModify
{
    using ESRI.ArcGIS.Controls;
    using ShapeEdit;
    using System;
    using System.Collections.Generic;
    using ESRI.ArcGIS.SystemUI;

    internal class AreaModifyStrategy : TopoModifyStrategy, ITopoModifyStrategy
    {
        public AreaModifyStrategy()
        {
        }

        public AreaModifyStrategy(IMapControl4 pControl) : base(pControl)
        {
            base._strategyNames = new string[] { "删除班块" };
            base._tools = new List<ITool>();
            base._tools.Add(ToolFactory.GetDeleteExTool());
        }
    }
}

