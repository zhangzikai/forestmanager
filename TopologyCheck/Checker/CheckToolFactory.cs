namespace TopologyCheck.Checker
{
    using ESRI.ArcGIS.Carto;
    using ESRI.ArcGIS.Geometry;
    using ESRI.ArcGIS.SystemUI;
    using System;
    using System.Windows.Forms;

    public class CheckToolFactory
    {
        private static ITool _angleCheckTool;
        private static ITool _areaCheckTool;
        private static ITool _boundaryBeyondCheckTool;
        private static ITool _gapsCheckTool;
        private static ITool _overlapCheckMlTool;
        private static ITool _overlapCheckTool;
        private static ITool _pointRepeatCheckTool;
        private static ITool _selfIntersectCheckTool;

        public static ITool CreateAngleCheckTool(IFeatureLayer pLayer, IWin32Window pWin)
        {
            if (_angleCheckTool == null)
            {
                _angleCheckTool = new TopologyCheck.Checker.AngleCheckTool(pLayer, pWin);
            }
            return _angleCheckTool;
        }

        public static ITool CreateAreaCheckTool(IFeatureLayer pLayer, IWin32Window pWin)
        {
            if (_areaCheckTool == null)
            {
                _areaCheckTool = new TopologyCheck.Checker.AreaCheckTool(pLayer, pWin);
            }
            return _areaCheckTool;
        }

        public static ITool CreateBoundaryBeyondCheckTool(IGeometry pGeo)
        {
            if (_boundaryBeyondCheckTool == null)
            {
                _boundaryBeyondCheckTool = new TopologyCheck.Checker.BoundaryBeyondCheckTool(pGeo);
            }
            return _boundaryBeyondCheckTool;
        }

        public static ITool CreateGapsCheckTool()
        {
            if (_gapsCheckTool == null)
            {
                _gapsCheckTool = new TopologyCheck.Checker.GapsCheckTool();
            }
            return _gapsCheckTool;
        }

        public static ITool CreateOverlapCheckMlTool(string pPrjName)
        {
            return null;
        }

        public static ITool CreateOverlapCheckTool()
        {
            if (_overlapCheckTool == null)
            {
                _overlapCheckTool = new TopologyCheck.Checker.OverlapCheckTool();
            }
            return _overlapCheckTool;
        }

        public static ITool CreatePointRepeatCheckTool(IFeatureLayer pLayer)
        {
            if (_pointRepeatCheckTool == null)
            {
                _pointRepeatCheckTool = new TopologyCheck.Checker.PointRepeatCheckTool(pLayer);
            }
            return _pointRepeatCheckTool;
        }

        public static ITool CreateSelfIntersectCheckTool(IFeatureLayer pLayer)
        {
            if (_selfIntersectCheckTool == null)
            {
                _selfIntersectCheckTool = new TopologyCheck.Checker.SelfIntersectCheckTool(pLayer);
            }
            return _selfIntersectCheckTool;
        }

        public static ITool AngleCheckTool
        {
            get
            {
                return _angleCheckTool;
            }
        }

        public static ITool AreaCheckTool
        {
            get
            {
                return _areaCheckTool;
            }
        }

        public static ITool BoundaryBeyondCheckTool
        {
            get
            {
                return _boundaryBeyondCheckTool;
            }
        }

        public static ITool GapsCheckTool
        {
            get
            {
                return _gapsCheckTool;
            }
        }

        public static ITool OverlapCheckMlTool
        {
            get
            {
                return _overlapCheckMlTool;
            }
        }

        public static ITool OverlapCheckTool
        {
            get
            {
                return _overlapCheckTool;
            }
        }

        public static ITool PointRepeatCheckTool
        {
            get
            {
                return _pointRepeatCheckTool;
            }
        }

        public static ITool SelfIntersectCheckTool
        {
            get
            {
                return _selfIntersectCheckTool;
            }
        }
    }
}

