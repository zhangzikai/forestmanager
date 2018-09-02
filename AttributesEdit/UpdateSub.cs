namespace AttributesEdit
{
    using ESRI.ArcGIS.AnalysisTools;
    using ESRI.ArcGIS.esriSystem;
    using ESRI.ArcGIS.Geodatabase;
    using ESRI.ArcGIS.Geometry;
    using ESRI.ArcGIS.Geoprocessing;
    using ESRI.ArcGIS.Geoprocessor;
    using ShapeEdit;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Common;
    using System.IO;
    using System.Linq;
    using System.Runtime.InteropServices;
    using Utilities;
    using ESRI.ArcGIS.Carto;
    using td.logic.sys;
    using td.db.orm;

    public class UpdateSub
    {
      
        private static void ClearZTOverlap(MetaDataManager pAccess, string sTableName)
        {
            try
            {
                string sCmdText = "";
                sCmdText = "delete from " + sTableName;
                pAccess.UpdateDB(sCmdText);
            }
            catch (Exception)
            {
            }
        }

        private static double ConvertToDouble(object pObj)
        {
            if (pObj == null)
            {
                return 0.0;
            }
            try
            {
                return Convert.ToDouble(pObj);
            }
            catch
            {
                return 0.0;
            }
        }

        private static void FindOverlapFeature(IFeature pFeature, int index, IList<IFeatureLayer> pLayerList, string sTableName)
        {
            try
            {
                for (int i = 0; i < pLayerList.Count; i++)
                {
                    if (i > index)
                    {
                        try
                        {
                            IFeatureClass featureClass = pLayerList[i].FeatureClass;
                            if (featureClass != null)
                            {
                                IList<IFeature> list = new List<IFeature>();
                                ISpatialFilter filter = new SpatialFilterClass {
                                    Geometry = pFeature.ShapeCopy,
                                    GeometryField = featureClass.ShapeFieldName,
                                    SpatialRel = esriSpatialRelEnum.esriSpatialRelOverlaps
                                };
                                IFeatureCursor o = featureClass.Search(filter, false);
                                IFeature item = o.NextFeature();
                                if (item != null)
                                {
                                    while (item != null)
                                    {
                                        list.Add(item);
                                        item = o.NextFeature();
                                    }
                                    Marshal.ReleaseComObject(o);
                                }
                                filter.SpatialRel = esriSpatialRelEnum.esriSpatialRelContains;
                                o = featureClass.Search(filter, false);
                                item = o.NextFeature();
                                if (item != null)
                                {
                                    while (item != null)
                                    {
                                        list.Add(item);
                                        item = o.NextFeature();
                                    }
                                    Marshal.ReleaseComObject(o);
                                }
                                else
                                {
                                    filter.SpatialRel = esriSpatialRelEnum.esriSpatialRelWithin;
                                    o = featureClass.Search(filter, false);
                                    item = o.NextFeature();
                                    if (item != null)
                                    {
                                        while (item != null)
                                        {
                                            list.Add(item);
                                            item = o.NextFeature();
                                        }
                                        Marshal.ReleaseComObject(o);
                                    }
                                }
                                if (list.Count >= 1)
                                {
                                  
                                    string name = pLayerList[index].Name;
                                    int oID = pFeature.OID;
                                    InsertOverlapRecord(DBServiceFactory<MetaDataManager>.Service, sTableName, oID, name);
                                    for (int j = 0; j < list.Count; j++)
                                    {
                                        name = pLayerList[i].Name;
                                        oID = list[j].OID;
                                        InsertOverlapRecord(DBServiceFactory<MetaDataManager>.Service, sTableName, oID, name);
                                    }
                                    Marshal.ReleaseComObject(o);
                                }
                            }
                        }
                        catch
                        {
                        }
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        private static void FindOverlapFeature2(IFeatureClass pFClass0, int index, IList<IFeatureLayer> pLayerList, MetaDataManager pAccess, string sTableName)
        {
            try
            {
                string sFile = (UtilFactory.GetConfigOpt().RootPath + @"\" + UtilFactory.GetConfigOpt().GetConfigValue("TempPath")) + @"\ztintersect.shp";
                string name = pLayerList[index].Name;
                for (int i = 0; i < pLayerList.Count; i++)
                {
                    if (i > index)
                    {
                        IFeatureClass featureClass = pLayerList[i].FeatureClass;
                        if (featureClass != null)
                        {
                            IList<IFeatureClass> pFCList = null;
                            pFCList = new List<IFeatureClass> {
                                pFClass0,
                                featureClass
                            };
                            IFeatureClass class3 = Intersect(pFCList, sFile);
                            if (class3 != null)
                            {
                                IFeatureCursor o = class3.Search(null, false);
                                if (o != null)
                                {
                                    IFeature feature = o.NextFeature();
                                    if (feature != null)
                                    {
                                        string str4 = ((IDataset) pFClass0).Name;
                                        string str5 = ((IDataset) featureClass).Name;
                                        str4 = "FID_" + str4.Substring(str4.LastIndexOf(".") + 1);
                                        str5 = "FID_" + str5.Substring(str5.LastIndexOf(".") + 1);
                                        if (str4.Length > 10)
                                        {
                                            str4 = str4.Substring(0, 10);
                                        }
                                        if (str5.Length > 10)
                                        {
                                            str5 = str5.Substring(0, 10);
                                        }
                                        int num2 = class3.Fields.FindField(str4);
                                        int num3 = class3.Fields.FindField(str5);
                                        string sLayerName = pLayerList[i].Name;                                      
                                        string sFID = "";
                                        while (feature != null)
                                        {
                                         
                                            if (num2 > -1)
                                            {
                                                sFID = feature.get_Value(num2).ToString();
                                                InsertOverlapRecord2(pAccess, sTableName, sFID, name);
                                            }
                                            if (num3 > -1)
                                            {
                                                sFID = feature.get_Value(num3).ToString();
                                                InsertOverlapRecord2(pAccess, sTableName, sFID, sLayerName);
                                            }
                                            feature = o.NextFeature();
                                        }
                                        Marshal.ReleaseComObject(o);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch
            {
                throw new Exception("计算专题图层重叠冲突出错");
            }
        }

        public static void FindZTOverlap(IList<IFeatureLayer> pLayerList)
        {          
                      
                string sTableName = UtilFactory.GetConfigOpt().GetConfigValue2("Sub", "OverlapTable");

                ClearZTOverlap(DBServiceFactory<MetaDataManager>.Service, sTableName);
                for (int i = 0; i < pLayerList.Count; i++)
                {
                    try
                    {
                        IFeatureClass featureClass = pLayerList[i].FeatureClass;
                        if (featureClass != null)
                        {
                            int num2 = 0;
                            IFeatureCursor o = featureClass.Search(null, false);
                            for (IFeature feature = o.NextFeature(); feature != null; feature = o.NextFeature())
                            {
                                num2++;
                                FindOverlapFeature(feature, i, pLayerList, sTableName);
                                if ((num2 % 50) == 0)
                                {
                                    GC.Collect();
                                }
                            }
                            Marshal.ReleaseComObject(o);
                            GC.Collect();
                        }
                    }
                    catch
                    {
                    }
                }
            
        }

        public static void FindZTOverlap2(IList<IFeatureLayer> pLayerList)
        {
        
                string sTableName = UtilFactory.GetConfigOpt().GetConfigValue2("Sub", "OverlapTable");
                ClearZTOverlap(DBServiceFactory<MetaDataManager>.Service, sTableName);
                for (int i = 0; i < pLayerList.Count; i++)
                {
                    try
                    {
                        IFeatureClass featureClass = pLayerList[i].FeatureClass;
                        if (featureClass != null)
                        {
                            FindOverlapFeature2(featureClass, i, pLayerList, DBServiceFactory<MetaDataManager>.Service, sTableName);
                        }
                    }
                    catch
                    {
                    }
                }
            
        }

        //private static int GetMaxOverlap(IDBAccess pAccess, string sTableName)
        //{
        //    try
        //    {
        //        string sCmdText = "select max(Overlap_ID) from " + sTableName;
        //        DbDataAdapter dBDataAdapter = pAccess.GetDBDataAdapter(sCmdText, false);
        //        DataSet dataSet = new DataSet();
        //        dBDataAdapter.Fill(dataSet);
        //        if (dataSet == null)
        //        {
        //            return 0;
        //        }
        //        if (dataSet.Tables.Count < 1)
        //        {
        //            return 0;
        //        }
        //        DataTable table = dataSet.Tables[0];
        //        string str2 = table.Rows[0][0].ToString();
        //        if (str2 == "")
        //        {
        //            return 0;
        //        }
        //        return Convert.ToInt32(str2);
        //    }
        //    catch
        //    {
        //        return 0;
        //    }
        //}

        private static string GetNode(string sKindCode)
        {
            if (sKindCode == "01")
            {
                return "Afforest";
            }
            if (sKindCode == "02")
            {
                return "Harvest";
            }
            if (sKindCode == "05")
            {
                return "Disaster";
            }
            if (sKindCode == "07")
            {
                return "ForestCase";
            }
            if (sKindCode == "04")
            {
                return "Expropriation";
            }
            if (sKindCode == "03")
            {
                return "Fire";
            }
            if (sKindCode == "08")
            {
                return "Sub";
            }
            return "Other";
        }

        private static IFeature GetOverlapFeature(IFeatureClass pFClass, IGeometry pGeo)
        {
            try
            {
                ISpatialFilter filter = new SpatialFilterClass {
                    Geometry = pGeo,
                    GeometryField = pFClass.ShapeFieldName,
                    SpatialRel = esriSpatialRelEnum.esriSpatialRelIntersects
                };
                IFeatureCursor cursor = pFClass.Search(filter, false);
                if (cursor == null)
                {
                    return null;
                }
                IFeature feature = cursor.NextFeature();
                if (feature == null)
                {
                    return null;
                }
                ITopologicalOperator2 @operator = pGeo as ITopologicalOperator2;
                @operator.IsKnownSimple_2 = false;
                @operator.Simplify();
                double num = 0.0;
                IFeature feature2 = null;
                while (feature != null)
                {
                    IGeometry geometry = @operator.Intersect(feature.ShapeCopy, esriGeometryDimension.esriGeometry2Dimension);
                    if (geometry.IsEmpty)
                    {
                        feature = cursor.NextFeature();
                    }
                    else
                    {
                        IArea area = geometry as IArea;
                        double num2 = area.Area;
                        if (num2 > num)
                        {
                            num = num2;
                            feature2 = feature;
                        }
                        feature = cursor.NextFeature();
                    }
                }
                return feature2;
            }
            catch
            {
                return null;
            }
        }

        public static bool ImportZTFeature(string sZTType, IFeature pFeature, IFeatureClass pChangeFClass, IFeatureClass pSubFClass, ISpatialReference pSrf)
        {
            Editor.UniqueInstance.StartEditOperation();
            try
            {
                IFeature pObject = pChangeFClass.CreateFeature();
                pObject.Shape = pFeature.ShapeCopy;
                pObject.Store();
                try
                {
                    IGeometry shapeCopy = pFeature.ShapeCopy;
                    IFeature overlapFeature = GetOverlapFeature(pSubFClass, shapeCopy);
                    string node = GetNode(sZTType);
                    IList<string> list = UtilFactory.GetConfigOpt().GetConfigValue2(node, "GXFields").Split(new char[] { ',' }).ToList<string>();
                    IList<string> list2 = UtilFactory.GetConfigOpt().GetConfigValue2(node, "GXMatchFields").Split(new char[] { ',' }).ToList<string>();
                    IList<string> list3 = UtilFactory.GetConfigOpt().GetConfigValue2("EditData", "ZTImportFields").Split(new char[] { ',' }).ToList<string>();
                    IList<string> list4 = UtilFactory.GetConfigOpt().GetConfigValue2("EditData", "SubImportFields").Split(new char[] { ',' }).ToList<string>();
                    IFields fields = pChangeFClass.Fields;
                    for (int i = 0; i < fields.FieldCount; i++)
                    {
                        IField field = fields.get_Field(i);
                        if ((field.Type != esriFieldType.esriFieldTypeGeometry) && field.Editable)
                        {
                            string name = field.Name;
                            if (list4.Contains(name))
                            {
                                object fieldValue = DataFuncs.GetFieldValue(overlapFeature, name);
                                DataFuncs.UpdateField(pObject, name, fieldValue);
                            }
                            else if (list3.Contains(name))
                            {
                                int index = list.IndexOf(name);
                                if (index >= 0)
                                {
                                    object obj3 = DataFuncs.GetFieldValue(pFeature, list2[index]);
                                    DataFuncs.UpdateField(pObject, name, obj3);
                                }
                            }
                            else
                            {
                                int num3 = list.IndexOf(name);
                                if (num3 >= 0)
                                {
                                    object obj4 = DataFuncs.GetFieldValue(pFeature, list2[num3]);
                                    if ((obj4 == null) || (obj4.ToString() == ""))
                                    {
                                        obj4 = DataFuncs.GetFieldValue(overlapFeature, name);
                                        DataFuncs.UpdateField(pObject, name, obj4);
                                    }
                                    else
                                    {
                                        DataFuncs.UpdateField(pObject, name, obj4);
                                    }
                                }
                                else
                                {
                                    object obj5 = DataFuncs.GetFieldValue(overlapFeature, name);
                                    DataFuncs.UpdateField(pObject, name, obj5);
                                }
                            }
                        }
                    }
                    double pFieldValue = Math.Round(Math.Abs((double) (DataFuncs.GetArea(pSrf, shapeCopy) / 10000.0)), 2);
                    DataFuncs.UpdateField(pObject, "MIAN_JI", pFieldValue);
                    if (sZTType != "01")
                    {
                        IList<string> list5 = UtilFactory.GetConfigOpt().GetConfigValue2("EditData", "ClearFields").Split(new char[] { ',' }).ToList<string>();
                        for (int j = 0; j < list5.Count; j++)
                        {
                            int num6 = pSubFClass.FindField(list5[j]);
                            if (num6 >= 0)
                            {
                                pObject.set_Value(num6, DBNull.Value);
                            }
                        }
                    }
                    string sFieldName = "DT_SRC";
                    DataFuncs.UpdateField(pObject, sFieldName, sZTType);
                    pObject.Store();
                }
                catch
                {
                }
                Editor.UniqueInstance.StopEditOperation();
                return true;
            }
            catch
            {
                Editor.UniqueInstance.AbortEditOperation();
                return false;
            }
        }

        private static void InsertOverlapRecord(MetaDataManager pAccess, string sTableName, int iFID, string sLayerName)
        {
            try
            {
                string sCmdText = "";
                sCmdText = string.Concat(new object[] { "insert into ", sTableName, " (Layer_Name,Feature_ID) values ('", sLayerName, "',", iFID, ")" });
                pAccess.UpdateDB(sCmdText);
            }
            catch (Exception)
            {
            }
        }

        private static void InsertOverlapRecord2(MetaDataManager pAccess, string sTableName, string sFID, string sLayerName)
        {
            try
            {
                string sCmdText = "";
                sCmdText = string.Concat(new object[] { "insert into ", sTableName, " (Layer_Name,Feature_ID) values ("+"'"+ sLayerName, "',", sFID, ")" });
                pAccess.UpdateDB(sCmdText);
            }
            catch (Exception)
            {
            }
        }

        private static IFeatureClass Intersect(IList<IFeatureClass> pFCList, string sFile)
        {
            try
            {
                IFeatureClass class2;
                IQueryFilter filter;
                if ((pFCList == null) || (pFCList.Count < 1))
                {
                    return null;
                }
                IGpValueTableObject obj2 = new GpValueTableObjectClass();
                obj2.SetColumns(1);
                object row = null;
                for (int i = 0; i < pFCList.Count; i++)
                {
                    row = pFCList[i];
                    obj2.AddRow(ref row);
                }
                if (!Directory.Exists(System.IO.Path.GetDirectoryName(sFile)) || (".shp" != System.IO.Path.GetExtension(sFile)))
                {
                    return null;
                }
                ESRI.ArcGIS.Geoprocessor.Geoprocessor geoprocessor = new ESRI.ArcGIS.Geoprocessor.Geoprocessor {
                    OverwriteOutput = true
                };
                ESRI.ArcGIS.AnalysisTools.Intersect process = new ESRI.ArcGIS.AnalysisTools.Intersect(obj2, sFile);
                IGeoProcessorResult result = (IGeoProcessorResult) geoprocessor.Execute(process, null);
                if (result.Status != esriJobStatus.esriJobSucceeded)
                {
                    return null;
                }
                IGPUtilities utilities = new GPUtilitiesClass();
                utilities.DecodeFeatureLayer(result.GetOutput(0), out class2, out filter);
                return class2;
            }
            catch
            {
                return null;
            }
        }
    }
}

