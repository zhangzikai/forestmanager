namespace TopologyCheck.TopologyModify
{
    using ESRI.ArcGIS.Controls;
    using ESRI.ArcGIS.Geodatabase;
    using ESRI.ArcGIS.SystemUI;
    using ShapeEdit;
    using System;
    using System.Collections.Generic;

    public class TopoModifyStrategyFactory
    {
        private static ITopoModifyStrategy _angleMs;
        private static ITopoModifyStrategy _areaMs;
        private static ITopoModifyStrategy _bbMs;
        private static ITopoModifyStrategy _gapMs;
        private static ITopoModifyStrategy _olMs;
        private static ITopoModifyStrategy _pointMs;
        private static ITopoModifyStrategy _siMs;

        public static ITopoModifyStrategy GetAngleModifyStrategy(IMapControl4 pControl)
        {
            if (_angleMs == null)
            {
                _angleMs = new AngleModifyStrategy(pControl);
            }
            return _angleMs;
        }

        public static ITopoModifyStrategy GetAreaModifyStrategy(IMapControl4 pControl, IFeature pFeature)
        {
            if (_areaMs == null)
            {
                _areaMs = new AreaModifyStrategy(pControl);
            }
            foreach (ITool tool in _areaMs.Tools)
            {
                if (tool is IFeatureTool)
                {
                    IFeatureTool tool2 = tool as IFeatureTool;
                    tool2.Feature = pFeature;
                }
            }
            return _areaMs;
        }

        public static ITopoModifyStrategy GetBoundaryModifyStartegy(IMapControl4 pControl, IFeature pFeature)
        {
            if (_bbMs == null)
            {
                _bbMs = new BoundaryBeyondStrategy(pControl);
            }
            foreach (ITool tool in _bbMs.Tools)
            {
                if (tool is IFeatureTool)
                {
                    IFeatureTool tool2 = tool as IFeatureTool;
                    tool2.Feature = pFeature;
                }
            }
            return _bbMs;
        }

        public static ITopoModifyStrategy GetGapModifyStrategy(IMapControl4 pControl)
        {
            if (_gapMs == null)
            {
                _gapMs = new GapModifyStrategy(pControl);
            }
            return _gapMs;
        }

        public static ITopoModifyStrategy GetOverlapModifyStrategy(IMapControl4 pControl, IList<IFeature> pFeatures)
        {
            _olMs = new OverlapModifyStrategy(pControl, pFeatures);
            return _olMs;
        }

        public static ITopoModifyStrategy GetPointModifyStrategy(IMapControl4 pControl)
        {
            if (_pointMs == null)
            {
                _pointMs = new PointModifyStrategy(pControl);
            }
            return _pointMs;
        }

        public static ITopoModifyStrategy GetSelfIntersectModifyStrategy(IMapControl4 pControl)
        {
            if (_siMs == null)
            {
                _siMs = new SelfIntersectModifyStrategy(pControl);
            }
            return _siMs;
        }
    }
}

