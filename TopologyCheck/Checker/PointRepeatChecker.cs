namespace TopologyCheck.Checker
{
    using ESRI.ArcGIS.Carto;
    using ESRI.ArcGIS.Geodatabase;
    using ESRI.ArcGIS.Geometry;
    using System;
    using System.Collections.Generic;
    using TopologyCheck.Error;

    internal class PointRepeatChecker : ITopologyChecker
    {
        private IFeatureLayer _layer;
        private int m_CheckType;

        public PointRepeatChecker()
        {
        }

        public PointRepeatChecker(IFeatureLayer pLayer)
        {
            this._layer = pLayer;
        }

        public PointRepeatChecker(IFeatureLayer pLayer, int iCheckType)
        {
            this._layer = pLayer;
            this.m_CheckType = iCheckType;
        }

        private List<ErrorEntity> AreaPointRepeat(IFeatureLayer pLayer, int iCheckType)
        {
            IFeatureCursor cursor;
            IQueryFilter filter = new QueryFilterClass();
            filter.SubFields = pLayer.FeatureClass.OIDFieldName + "," + pLayer.FeatureClass.ShapeFieldName;
            if (iCheckType == 0)
            {
                cursor = pLayer.FeatureClass.Search(filter, true);
            }
            else
            {
                cursor = pLayer.Search(filter, true);
            }
            IFeature feature = null;
            List<ErrorEntity> list = new List<ErrorEntity>();
            List<string> list2 = new List<string>();
            List<string> list3 = new List<string>();
            while ((feature = cursor.NextFeature()) != null)
            {
                IGeometry shapeCopy = feature.ShapeCopy;
                if (shapeCopy.GeometryType == esriGeometryType.esriGeometryPoint)
                {
                    IPoint point = shapeCopy as IPoint;
                    string item = string.Format("{0:F6},{1:F6}", point.X, point.Y);
                    if (list2.Contains(item))
                    {
                        if (list3.Contains(item))
                        {
                            int index = list3.IndexOf(item);
                            string errMsg = list[index].ErrMsg;
                            list[index].ErrMsg = "点重复:" + ((int.Parse(errMsg.Substring(errMsg.IndexOf(':') + 1)) + 1)).ToString();
                        }
                        else
                        {
                            ErrorEntity entity = new ErrorEntity(feature.OID.ToString(), "点重复:1", point.X.ToString() + "," + point.Y.ToString(), ErrType.ReportPoint);
                            list.Add(entity);
                            list3.Add(item);
                        }
                    }
                    else
                    {
                        list2.Add(item);
                    }
                }
                else
                {
                    IGeometryCollection geometrys = shapeCopy as IGeometryCollection;
                    int geometryCount = geometrys.GeometryCount;
                    for (int i = 0; i < geometryCount; i++)
                    {
                        list2.Clear();
                        IGeometry geometry2 = geometrys.get_Geometry(i);
                        int num5 = 0;
                        if ((geometry2.GeometryType == esriGeometryType.esriGeometryPolygon) || (geometry2.GeometryType == esriGeometryType.esriGeometryRing))
                        {
                            IRing ring = geometry2 as IRing;
                            if (ring.IsClosed)
                            {
                                num5 = 1;
                            }
                        }
                        IPointCollection points = geometry2 as IPointCollection;
                        int pointCount = points.PointCount;
                        for (int j = num5; j < pointCount; j++)
                        {
                            IPoint point2 = points.get_Point(j);
                            string str3 = string.Format("{0:F6},{1:F6}", point2.X, point2.Y);
                            if (list2.Contains(str3))
                            {
                                if (list3.Contains(str3))
                                {
                                    int num8 = list3.IndexOf(str3);
                                    string str4 = list[num8].ErrMsg;
                                    list[num8].ErrMsg = "点重复:" + ((int.Parse(str4.Substring(str4.IndexOf(':') + 1)) + 1)).ToString();
                                }
                                else
                                {
                                    ErrorEntity entity2 = new ErrorEntity(feature.OID.ToString(), "点重复:1", point2.X.ToString() + "," + point2.Y.ToString(), ErrType.ReportPoint);
                                    list.Add(entity2);
                                    list3.Add(str3);
                                }
                            }
                            else
                            {
                                list2.Add(str3);
                            }
                        }
                    }
                }
            }
            return list;
        }

        public bool Check()
        {
            List<ErrorEntity> pErrEntity = this.AreaPointRepeat(this._layer, this.m_CheckType);
            new ErrorTable().AddErr(pErrEntity, ErrType.ReportPoint);
            return (pErrEntity.Count == 0);
        }

        public bool CheckFeature(IFeature pFeature, ref object pErrFeatureInf)
        {
            IGeometryCollection shape = pFeature.Shape as IGeometryCollection;
            int geometryCount = shape.GeometryCount;
            List<string> list = new List<string>();
            List<string> list2 = new List<string>();
            List<double[]> list3 = pErrFeatureInf as List<double[]>;
            bool flag = true;
            for (int i = 0; i < geometryCount; i++)
            {
                list.Clear();
                IGeometry geometry = shape.get_Geometry(i);
                int num3 = 0;
                if ((geometry.GeometryType == esriGeometryType.esriGeometryPolygon) || (geometry.GeometryType == esriGeometryType.esriGeometryRing))
                {
                    IRing ring = geometry as IRing;
                    if (ring.IsClosed)
                    {
                        num3 = 1;
                    }
                }
                IPointCollection points = geometry as IPointCollection;
                int pointCount = points.PointCount;
                for (int j = num3; j < pointCount; j++)
                {
                    IPoint point = points.get_Point(j);
                    string item = string.Format("{0:F6},{1:F6}", point.X, point.Y);
                    if (list.Contains(item))
                    {
                        if (!list2.Contains(item))
                        {
                            list2.Add(item);
                            list3.Add(new double[] { point.X, point.Y });
                            flag = false;
                        }
                    }
                    else
                    {
                        list.Add(item);
                    }
                }
            }
            return flag;
        }
    }
}

