namespace TopologyCheck.TopologyModify
{
    using System;
    using System.Collections.Generic;
    using ESRI.ArcGIS.SystemUI;

    public interface ITopoModifyStrategy
    {
        int StrategyIndex { set; }

        string[] StrategyNames { get; }

        List<ITool> Tools { get; set; }
    }
}

