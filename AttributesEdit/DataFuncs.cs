namespace AttributesEdit
{
    using ESRI.ArcGIS.Carto;
    using ESRI.ArcGIS.Display;
    using ESRI.ArcGIS.esriSystem;
    using ESRI.ArcGIS.Geodatabase;
    using ESRI.ArcGIS.Geometry;
    using FunFactory;
    using System;
    using System.Data;
    using System.Linq;
    using System.Runtime.InteropServices;
    using Utilities;

    public class DataFuncs
    {
        private static void AddError(DataTable pErrorTable, string sDesc)
        {
            DataRow row = pErrorTable.NewRow();
            row[0] = sDesc;
            pErrorTable.Rows.Add(row);
        }

        public static DataTable CheckField(IFeatureClass pFClass, IFeatureClass pTemplateFClass)
        {
            try
            {
                DataTable pErrorTable = new DataTable();
                DataColumn column = null;
                column = new DataColumn {
                    ColumnName = "错误描述",
                    DataType = Type.GetType("System.String"),
                    MaxLength = 60
                };
                pErrorTable.Columns.Add(column);
                IFields fields = pFClass.Fields;
                IFields fields2 = pTemplateFClass.Fields;
                for (int i = 0; i < fields.FieldCount; i++)
                {
                    IField field = fields.get_Field(i);
                    if (field.Editable && (field.Type != esriFieldType.esriFieldTypeGeometry))
                    {
                        string name = field.Name;
                        if (!name.ToLower().Contains("objectid") && !name.ToLower().Contains("shape"))
                        {
                            int index = fields2.FindField(name);
                            if (index >= 0)
                            {
                                IField field2 = fields2.get_Field(index);
                                if (field.Type != field2.Type)
                                {
                                    AddError(pErrorTable, "字段" + name + "字段类型与模板不匹配，应为" + field2.Type.ToString());
                                }
                                else if ((field.Type == esriFieldType.esriFieldTypeString) && (field.Length != field2.Length))
                                {
                                    AddError(pErrorTable, "字段" + name + "字段长度与模板不匹配，应为" + field2.Length.ToString());
                                }
                            }
                        }
                    }
                }
                if (pErrorTable.Rows.Count <= 0)
                {
                    string[] source = new string[] { "Q_MJ", "Q_SZ", "Q_YBD", "Q_PJNL", "Q_PJXJ", "Q_PJSG", "Q_PJDM", "Q_ZXJ", "Q_BSSZPJXJ", "Q_BSSZNL", "Q_BSSZSG", "Q_BSSZGQDM", "Q_YSSZXJ", "Q_BSSZXJ", "Q_SSXJ" };
                    UtilFactory.GetConfigOpt().GetConfigValue2("DataBase", "MapDBkey");
                    for (int j = 0; j < fields2.FieldCount; j++)
                    {
                        IField field3 = fields2.get_Field(j);
                        string str2 = field3.Name;
                        if (fields.FindField(str2) < 0)
                        {
                            if ((!str2.ToLower().Contains("objectid") && !str2.ToLower().Contains("shape")) && !source.Contains<string>(str2))
                            {
                                AddError(pErrorTable, "导入数据中缺少字段" + str2);
                            }
                        }
                        else
                        {
                            ITable table2 = (ITable) pFClass;
                            IDomain domain = field3.Domain;
                            if ((domain != null) && (domain is ICodedValueAttributes))
                            {
                                ICodedValueDomain domain2 = (ICodedValueDomain) domain;
                                if (domain2 != null)
                                {
                                    string str3 = "";
                                    for (int k = 0; k < domain2.CodeCount; k++)
                                    {
                                        str3 = str3 + "," + domain2.get_Value(k);
                                    }
                                    if (str3.Length > 1)
                                    {
                                        str3 = str3.Substring(1) + ",''";
                                        string str4 = str2 + " not in (" + str3 + ") and " + str2 + " is not null";
                                        IQueryFilter2 queryFilter = new QueryFilterClass {
                                            WhereClause = str4
                                        };
                                        ICursor o = table2.Search(queryFilter, false);
                                        IRow row = null;
                                        while ((row = o.NextRow()) != null)
                                        {
                                            AddError(pErrorTable, string.Concat(new object[] { "要素", row.OID, "的字段", str2, "其值超出代码范围" }));
                                        }
                                        Marshal.ReleaseComObject(o);
                                    }
                                }
                            }
                        }
                    }
                }
                return pErrorTable;
            }
            catch
            {
                return null;
            }
        }

        public static void CopyGeoObject(IObject pSrcObj, IObject pTargObj)
        {
            if ((pSrcObj != null) && (pTargObj != null))
            {
                string sFieldName = "";
                IFields fields = pTargObj.Fields;
                try
                {
                    for (int i = 0; i < fields.FieldCount; i++)
                    {
                        IField field = fields.get_Field(i);
                        if ((field.Type != esriFieldType.esriFieldTypeGeometry) && field.Editable)
                        {
                            sFieldName = field.Name;
                            object fieldValue = GetFieldValue(pSrcObj, sFieldName);
                            pTargObj.set_Value(i, fieldValue);
                        }
                    }
                    pTargObj.Store();
                }
                catch
                {
                }
            }
        }

        public static double GetArea(ISpatialReference pSrf, IGeometry pGeo)
        {
            if (pGeo == null)
            {
                return 0.0;
            }
            try
            {
                pGeo = GISFunFactory.UnitFun.ConvertPoject(pGeo, pSrf);
                return ((IArea) pGeo).Area;
            }
            catch
            {
                return 0.0;
            }
        }

        public static object GetFieldValue(IObject pObj, string sFieldName)
        {
            try
            {
                int index = pObj.Fields.FindField(sFieldName);
                if (index < 0)
                {
                    return null;
                }
                return pObj.get_Value(index);
            }
            catch
            {
                return null;
            }
        }

        public static string GetFieldValue2(IObject pObj, string sFieldName)
        {
            int index = pObj.Fields.FindField(sFieldName);
            if (index >= 0)
            {
                IField field = pObj.Fields.get_Field(index);
                string str = pObj.get_Value(index).ToString();
                IDomain domain = field.Domain;
                if (str == "<null>")
                {
                    return "";
                }
                if (domain == null)
                {
                    return str;
                }
                if (!(domain is ICodedValueDomain))
                {
                    return str;
                }
                ICodedValueDomain domain2 = domain as ICodedValueDomain;
                for (int i = 0; i < domain2.CodeCount; i++)
                {
                    string str2 = domain2.get_Name(i);
                    if (str == domain2.get_Value(i).ToString())
                    {
                        return str2;
                    }
                }
            }
            return "";
        }

        public static IEnvelope GetSearchEnvelope(IActiveView pActiveView, IPoint pPoint)
        {
            try
            {
                double num = 6.0;
                IEnvelope visibleBounds = null;
                if (pActiveView != null)
                {
                    IDisplayTransformation displayTransformation = pActiveView.ScreenDisplay.DisplayTransformation;
                    visibleBounds = displayTransformation.VisibleBounds;
                    tagRECT deviceFrame = displayTransformation.get_DeviceFrame();
                    double height = 0.0;
                    long num3 = 0L;
                    height = visibleBounds.Height;
                    num3 = deviceFrame.bottom - deviceFrame.top;
                    double num4 = 0.0;
                    num4 = height / ((double) num3);
                    num *= num4;
                }
                if (pPoint == null)
                {
                    return null;
                }
                visibleBounds = pPoint.Envelope;
                visibleBounds.Width = num;
                visibleBounds.Height = num;
                visibleBounds.CenterAt(pPoint);
                return visibleBounds;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static IFeature SearchFeature(IFeatureLayer pFLayer, IGeometry pFilterGeometry, esriSpatialRelEnum enumSpatialRel)
        {
            IFeatureCursor cursor = SearchFeatures(pFLayer, pFilterGeometry, enumSpatialRel);
            if (cursor == null)
            {
                return null;
            }
            IFeature feature = cursor.NextFeature();
            IFeature feature2 = null;
            if (feature != null)
            {
                feature2 = pFLayer.FeatureClass.GetFeature(feature.OID);
            }
            return feature2;
        }

        public static IFeatureCursor SearchFeatures(IFeatureLayer pFLayer, IGeometry pFilterGeometry, esriSpatialRelEnum enumSpatialRel)
        {
            if (pFLayer == null)
            {
                return null;
            }
            IFeatureClass featureClass = pFLayer.FeatureClass;
            if (featureClass == null)
            {
                return null;
            }
            try
            {
                ISpatialFilter queryFilter = null;
                if (pFilterGeometry == null)
                {
                    return null;
                }
                queryFilter = new SpatialFilterClass {
                    Geometry = pFilterGeometry,
                    GeometryField = featureClass.ShapeFieldName,
                    SpatialRel = enumSpatialRel
                };
                return pFLayer.Search(queryFilter, false);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static bool UpdateField(IObject pObject, string sFieldName, object pFieldValue)
        {
            try
            {
                int index = pObject.Fields.FindField(sFieldName);
                if (index > 0)
                {
                    pObject.set_Value(index, pFieldValue);
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }
    }
}

