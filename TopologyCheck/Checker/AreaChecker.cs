namespace TopologyCheck.Checker
{
    using ESRI.ArcGIS.Carto;
    using ESRI.ArcGIS.Geodatabase;
    using ESRI.ArcGIS.Geometry;
    using FunFactory;
    using System;
    using System.Collections.Generic;
    using TopologyCheck.Error;

    internal class AreaChecker : ITopologyChecker
    {
        private IActiveView _activeView;
        private double _area;
        private IFeatureLayer _layer;
        private int m_CheckType;

        public AreaChecker(IActiveView pActiveView)
        {
            this._activeView = pActiveView;
        }

        public AreaChecker(double pArea)
        {
            this._area = pArea;
        }

        public AreaChecker(IActiveView pActiveView, IFeatureLayer pLayer, double pArea)
        {
            this._activeView = pActiveView;
            this._layer = pLayer;
            this._area = pArea;
        }

        public AreaChecker(IActiveView pActiveView, IFeatureLayer pLayer, double pArea, int iCheckType)
        {
            this._activeView = pActiveView;
            this._layer = pLayer;
            this._area = pArea;
            this.m_CheckType = iCheckType;
        }

        protected virtual IFeatureCursor AreaCheck(IFeatureLayer pLayer, double criticalArea, int iCheckType)
        {
            IField areaField = pLayer.FeatureClass.AreaField;
            if (areaField == null)
            {
                return null;
            }
            string name = areaField.Name;
            if (string.IsNullOrEmpty(name))
            {
                return null;
            }
            string str2 = name + "<" + criticalArea.ToString();
            IQueryFilter filter = new QueryFilterClass();
            filter.WhereClause = str2;
            filter.SubFields = pLayer.FeatureClass.OIDFieldName;
            if (iCheckType == 0)
            {
                return pLayer.FeatureClass.Search(filter, false);
            }
            return pLayer.Search(filter, false);
        }

        public bool Check()
        {
            IQueryFilter filter = null;
            IFeatureCursor cursor;
            filter = new QueryFilterClass();
            filter.SubFields = this._layer.FeatureClass.OIDFieldName + "," + this._layer.FeatureClass.ShapeFieldName;
            if (this.m_CheckType == 0)
            {
                cursor = this._layer.FeatureClass.Search(filter, false);
            }
            else
            {
                cursor = this._layer.Search(filter, true);
            }
            List<ErrorEntity> pErrEntity = new List<ErrorEntity>();
            IFeature feature = null;
            while ((feature = cursor.NextFeature()) != null)
            {
                IGeometry shapeCopy = feature.ShapeCopy;
                if (shapeCopy.IsEmpty)
                {
                    pErrEntity.Add(new ErrorEntity(feature.OID.ToString(), "图形为空", "", ErrType.Area));
                }
                else
                {
                    IArea area = (IArea) GISFunFactory.UnitFun.ConvertPoject(shapeCopy, this._activeView.FocusMap.SpatialReference);
                    if (area.Area < this._area)
                    {
                        pErrEntity.Add(new ErrorEntity(feature.OID.ToString(), "面积过小", "", ErrType.Area));
                    }
                }
            }
            new ErrorTable().AddErr(pErrEntity, ErrType.Area);
            return true;
        }

        public bool CheckFeature(IFeature pFeature, ref object pErrFeatureInf)
        {
            if (pFeature.HasOID)
            {
                pErrFeatureInf = pFeature.OID;
            }
            IGeometry shapeCopy = pFeature.ShapeCopy;
            IArea area = GISFunFactory.UnitFun.ConvertPoject(shapeCopy, this._activeView.FocusMap.SpatialReference) as IArea;
            if (area.Area < this._area)
            {
                return false;
            }
            return true;
        }

        public double Area
        {
            set
            {
                this._area = value;
            }
        }
    }
}

