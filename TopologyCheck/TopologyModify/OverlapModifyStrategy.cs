namespace TopologyCheck.TopologyModify
{
    using ESRI.ArcGIS.Controls;
    using System;
    using System.Collections.Generic;
    using ESRI.ArcGIS.Geodatabase;

    internal class OverlapModifyStrategy : TopoModifyStrategy, ITopoModifyStrategy
    {
        public OverlapModifyStrategy()
        {
        }

        public OverlapModifyStrategy(IMapControl4 pControl, IList<IFeature> pFeatures) : base(pControl)
        {
            int count = pFeatures.Count;
            if (count == 1)
            {
                base._strategyNames = new string[] { "删除重叠部分" };
            }
            else
            {
                base._strategyNames = new string[count + 2];
                for (int i = 0; i < count; i++)
                {
                    IFeature local1 = pFeatures[i];
                    base._strategyNames[i] = "重叠部分保留到班块" + pFeatures[i].OID;
                }
                base._strategyNames[count] = "删除重叠部分";
                base._strategyNames[count + 1] = "重叠部分转化为独立班块";
            }
        }
    }
}

