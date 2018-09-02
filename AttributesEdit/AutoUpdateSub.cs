namespace AttributesEdit
{
    using ESRI.ArcGIS.Carto;
    using ESRI.ArcGIS.esriSystem;
    using ESRI.ArcGIS.Geodatabase;
    using ESRI.ArcGIS.Geometry;
    using FunFactory;
    using ShapeEdit;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.Diagnostics;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;
    using TaskManage;
    using Utilities;
    using td.logic.sys;
    using td.db.orm;

    public class AutoUpdateSub
    {
        
        private double m_BHMinArea;
        private string m_CntyField = "";
        private List<string> m_HFieldList;
        private string m_LBField = "";
        private IMap m_Map;
        private double m_MinArea;
        private List<string> m_QFieldList;
        private string m_SaveTableName = "";
        private string m_TownField = "";
        private string m_VillField = "";
        private string m_XiaoBField = "";
        private string m_XiBField = "";
        private const string mClassName = "AttributesEdit.AutoUpdateSub";
        private ErrorOpt mErrOpt = UtilFactory.GetErrorOpt();
        private string mSubSysName = UtilFactory.GetConfigOpt().GetSystemName();

        public AutoUpdateSub(IMap pMap)
        {
            this.m_Map = pMap;
          
            this.m_SaveTableName = UtilFactory.GetConfigOpt().GetConfigValue2("Sub", "Updatetable");
        }

        public bool AutoUpdate(IFeatureLayer pSubLayer, IFeatureLayer pChangeLayer, Label pLabel)
        {
           
            try
            {
                string sCmdText = "";
                sCmdText = "delete from " + this.m_SaveTableName;
                this.ExecuteNonQuery(sCmdText);
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "AttributesEdit.AutoUpdateSub", "AutoUpdate", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                return false;
            }
            IFeatureClass featureClass = pSubLayer.FeatureClass;
            if (featureClass == null)
            {
                return false;
            }
            IFeatureClass class3 = pChangeLayer.FeatureClass;
            if (class3 == null)
            {
                return false;
            }
            string name = ((IDataset) featureClass).Name;
            if (!this.PreUpdate(name, "", pLabel))
            {
                return false;
            }
            ConfigOpt configOpt = UtilFactory.GetConfigOpt();
            this.m_CntyField = configOpt.GetConfigValue2("Sub", "CntyField");
            if (this.m_CntyField == "")
            {
                return false;
            }
            this.m_TownField = configOpt.GetConfigValue2("Sub", "TownField");
            if (this.m_TownField == "")
            {
                return false;
            }
            this.m_VillField = configOpt.GetConfigValue2("Sub", "VillField");
            if (this.m_VillField == "")
            {
                return false;
            }
            this.m_LBField = configOpt.GetConfigValue2("Sub", "LBField");
            if (this.m_LBField == "")
            {
                return false;
            }
            this.m_XiaoBField = configOpt.GetConfigValue2("Sub", "XBField");
            if (this.m_XiaoBField == "")
            {
                return false;
            }
            this.m_XiBField = configOpt.GetConfigValue2("Sub", "XibanField");
            if (this.m_XiBField == "")
            {
                return false;
            }
            this.m_MinArea = Convert.ToDouble(configOpt.GetConfigValue2("Sub", "MinArea"));
            this.m_BHMinArea = 0.067;
            try
            {
                IWorkspaceEdit workspace = (IWorkspaceEdit) Editor.UniqueInstance.Workspace;
                int index = 0;
                bool flag = true;
                string str3 = ((IDataset) class3).Name;
                string sql = "select distinct XIANG from " + str3 + " order by XIANG";
                //IDBAccess dBAccess = UtilFactory.GetDBAccess("SqlServer");
                DataTable dataTable = null;// dBAccess.GetDataTable(dBAccess, sql);
                if ((dataTable == null) || (dataTable.Rows.Count < 1))
                {
                    MessageBox.Show("无变化班块，无法进行自动更新！", "自动更新");
                    return false;
                }
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    string str5 = "";
                    if (dataTable.Rows[i][0] == DBNull.Value)
                    {
                        str5 = "XIANG is null";
                    }
                    else
                    {
                        str5 = "XIANG='" + dataTable.Rows[i][0].ToString() + "'";
                    }
                    IList<IFeature> pFList = new List<IFeature>();
                    IQueryFilter filter = new QueryFilterClass {
                        WhereClause = str5
                    };
                    IFeatureCursor o = class3.Search(filter, false);
                    for (IFeature feature = o.NextFeature(); feature != null; feature = o.NextFeature())
                    {
                        pFList.Add(feature);
                    }
                    Marshal.ReleaseComObject(o);
                    if (pFList.Count >= 1)
                    {
                        if (!this.UpdateTownFeature(workspace, featureClass, pFList, index, pLabel, ""))
                        {
                            flag = false;
                            break;
                        }
                        index += pFList.Count;
                    }
                }
                if (index < 1)
                {
                    MessageBox.Show("无变化班块，无法进行自动更新！", "自动更新");
                    return false;
                }
                return flag;
            }
            catch (Exception exception2)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "AttributesEdit.AutoUpdateSub", "AutoUpdate", exception2.GetHashCode().ToString(), exception2.Source, exception2.Message, "", "", "");
                return false;
            }
        }

        public bool AutoUpdatePoint(IFeatureLayer pSubLayer, IFeatureLayer pPointLayer)
        {
            if ((pSubLayer == null) || (pPointLayer == null))
            {
                return false;
            }
            IFeatureClass featureClass = pPointLayer.FeatureClass;
            if (featureClass == null)
            {
                return false;
            }
            IFeatureClass class3 = pSubLayer.FeatureClass;
            if (class3 == null)
            {
                return false;
            }
            bool flag = false;
            if (!Editor.UniqueInstance.IsBeingEdited)
            {
                Editor.UniqueInstance.StartEdit(Editor.UniqueInstance.Workspace, Editor.UniqueInstance.Map);
            }
            Editor.UniqueInstance.StartEditOperation();
            try
            {
                IFeatureCursor o = featureClass.Search(null, false);
                IFeature pZTFeature = null;
                while ((pZTFeature = o.NextFeature()) != null)
                {
                    ISpatialFilter filter = new SpatialFilterClass {
                        GeometryField = class3.ShapeFieldName,
                        SpatialRel = esriSpatialRelEnum.esriSpatialRelWithin,
                        Geometry = pZTFeature.ShapeCopy
                    };
                    IFeatureCursor cursor2 = class3.Search(filter, false);
                    IFeature pSubFeature = cursor2.NextFeature();
                    if (pSubFeature != null)
                    {
                        Marshal.ReleaseComObject(cursor2);
                        this.UpdateAttributes(pZTFeature, pSubFeature, null);
                        string sFieldName = UtilFactory.GetConfigOpt().GetConfigValue2("Sub", "YSSZXJField");
                        double num = this.ConvertToDouble(DataFuncs.GetFieldValue(pSubFeature, sFieldName));
                        double num2 = this.ConvertToDouble(DataFuncs.GetFieldValue(pZTFeature, "SLXJ"));
                        double a = num - num2;
                        DataFuncs.UpdateField(pSubFeature, sFieldName, Math.Round(a));
                        string str2 = UtilFactory.GetConfigOpt().GetConfigValue2("Sub", "BSXJField");
                        string str3 = UtilFactory.GetConfigOpt().GetConfigValue2("Sub", "SLXJField");
                        double num4 = a + this.ConvertToDouble(DataFuncs.GetFieldValue(pSubFeature, str2));
                        DataFuncs.UpdateField(pSubFeature, str3, Math.Round(num4));
                        string str4 = UtilFactory.GetConfigOpt().GetConfigValue2("Sub", "SSXJField");
                        string str5 = UtilFactory.GetConfigOpt().GetConfigValue2("Sub", "ZXJField");
                        double num5 = num4 + this.ConvertToDouble(DataFuncs.GetFieldValue(pSubFeature, str4));
                        DataFuncs.UpdateField(pSubFeature, str5, Math.Round(num5));
                        this.SaveOperateRecord(pSubFeature.OID, "2");
                    }
                }
                Marshal.ReleaseComObject(o);
                Editor.UniqueInstance.StopEditOperation("updatePoint");
                flag = true;
            }
            catch
            {
                Editor.UniqueInstance.AbortEditOperation();
                flag = false;
            }
            GC.Collect();
            if (Editor.UniqueInstance.IsBeingEdited)
            {
                Editor.UniqueInstance.StopEdit();
            }
            return flag;
        }

        private void ClearMemory()
        {
            try
            {
                Process process = new Process();
                ProcessStartInfo info = new ProcessStartInfo(Application.StartupPath + @"\MemoryClean.exe");
                process.StartInfo = info;
                process.StartInfo.UseShellExecute = false;
                process.Start();
            }
            catch
            {
            }
        }

        private double ConvertToDouble(object pObj)
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

        private int ConvertToInt(string str)
        {
            try
            {
                return int.Parse(str);
            }
            catch
            {
                return 0;
            }
        }

        private int ExecuteNonQuery(string sSql)
        {
            try
            {
                return MDM.UpdateDB(sSql) ? 1 : -1;
            }
            catch
            {
                return -1;
            }
        }

        private double GetArea(IGeometry pGeo)
        {
            double num = 0.0;
            if (pGeo == null)
            {
                return num;
            }
            IClone clone = (IClone) pGeo;
            IGeometry pGeometry = (IGeometry) clone.Clone();
            return Math.Round(Math.Abs((double) (((IArea) GISFunFactory.UnitFun.ConvertPoject(pGeometry, this.m_Map.SpatialReference)).Area / 10000.0)), 2);
        }

        private IList<IGeometry> GetGeometrys(IGeometry pGeo)
        {
            IList<IGeometry> list = new List<IGeometry>();
            try
            {
                IPolygon4 polygon = pGeo as IPolygon4;
                if (polygon.ExteriorRingCount < 2)
                {
                    list.Add(pGeo);
                    return list;
                }
                IEnumGeometry exteriorRingBag = polygon.ExteriorRingBag as IEnumGeometry;
                exteriorRingBag.Reset();
                for (IRing ring = exteriorRingBag.Next() as IRing; ring != null; ring = exteriorRingBag.Next() as IRing)
                {
                    IGeometryBag bag2 = polygon.get_InteriorRingBag(ring);
                    object missing = System.Type.Missing;
                    IGeometryCollection geometrys = null;
                    geometrys = new PolygonClass();
                    geometrys.AddGeometry(ring, ref missing, ref missing);
                    IPolygon item = geometrys as IPolygon;
                    item.SpatialReference = pGeo.SpatialReference;
                    ITopologicalOperator2 @operator = (ITopologicalOperator2) item;
                    @operator.IsKnownSimple_2 = false;
                    @operator.Simplify();
                    if (!bag2.IsEmpty)
                    {
                        IGeometryCollection geometrys2 = new PolygonClass();
                        IEnumGeometry geometry2 = bag2 as IEnumGeometry;
                        geometry2.Reset();
                        for (IRing ring2 = geometry2.Next() as IRing; ring2 != null; ring2 = geometry2.Next() as IRing)
                        {
                            geometrys2.AddGeometry(ring2, ref missing, ref missing);
                        }
                        IPolygon other = geometrys2 as IPolygon;
                        other.SpatialReference = pGeo.SpatialReference;
                        ITopologicalOperator2 operator2 = (ITopologicalOperator2) other;
                        operator2.IsKnownSimple_2 = false;
                        operator2.Simplify();
                        IGeometry geometry3 = @operator.Difference(other);
                        list.Add(geometry3);
                    }
                    else
                    {
                        list.Add(item);
                    }
                }
            }
            catch
            {
                return null;
            }
            return list;
        }

        private int GetMaxXBH(IFeatureClass pSubFClass, IGeometry pGeo, ref IFeature pNewFeature)
        {
            int num = 0;
            try
            {
                IDataset dataset = (IDataset) pSubFClass;
                IWorkspace workspace = dataset.Workspace;
                string configValue = UtilFactory.GetConfigOpt().GetConfigValue("LinbanClassName");
                IFeatureClass class2 = ((IFeatureWorkspace) workspace).OpenFeatureClass(configValue);
                if (class2 == null)
                {
                    return num;
                }
                ISpatialFilter filter = new SpatialFilterClass {
                    Geometry = pGeo,
                    GeometryField = class2.ShapeFieldName,
                    SpatialRel = esriSpatialRelEnum.esriSpatialRelWithin
                };
                IFeatureCursor o = class2.Search(filter, false);
                IFeature feature = o.NextFeature();
                Marshal.ReleaseComObject(o);
                if (feature == null)
                {
                    return num;
                }
                string name = UtilFactory.GetConfigOpt().GetConfigValue2("LinBan", "VillField");
                int index = feature.Fields.FindField(name);
                if (index < 0)
                {
                    return 0;
                }
                string str3 = feature.get_Value(index).ToString();
                pNewFeature.set_Value(index, str3);
                name = UtilFactory.GetConfigOpt().GetConfigValue2("LinBan", "LBField");
                index = feature.Fields.FindField(name);
                if (index < 0)
                {
                    return 0;
                }
                string str4 = feature.get_Value(index).ToString();
                pNewFeature.set_Value(index, str4);
                name = UtilFactory.GetConfigOpt().GetConfigValue2("Other", "CntyField");
                index = feature.Fields.FindField(name);
                if (index < 0)
                {
                    return 0;
                }
                string str5 = feature.get_Value(index).ToString();
                pNewFeature.set_Value(index, str5);
                name = UtilFactory.GetConfigOpt().GetConfigValue2("Other", "TownField");
                index = feature.Fields.FindField(name);
                if (index < 0)
                {
                    return 0;
                }
                str5 = feature.get_Value(index).ToString();
                pNewFeature.set_Value(index, str5);
                string str6 = "";
                str6 = UtilFactory.GetConfigOpt().GetConfigValue2("Sub", "VillField") + "='" + str3 + "'";
                string str8 = UtilFactory.GetConfigOpt().GetConfigValue2("Sub", "LBField");
                string str10 = str6;
                str6 = str10 + " and " + str8 + "='" + str4 + "'";
                IQueryFilter filter2 = new QueryFilterClass {
                    WhereClause = str6
                };
                IFeatureCursor cursor2 = pSubFClass.Search(filter2, false);
                IFeature feature2 = cursor2.NextFeature();
                string str9 = UtilFactory.GetConfigOpt().GetConfigValue2("Sub", "XBField");
                int num3 = pSubFClass.Fields.FindField(str9);
                while (feature2 != null)
                {
                    int num4 = Convert.ToInt16(feature2.get_Value(num3));
                    if (num4 > num)
                    {
                        num = num4;
                    }
                    feature2 = cursor2.NextFeature();
                }
                Marshal.ReleaseComObject(cursor2);
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "AttributesEdit.AutoUpdateSub", "GetMaxXBH", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
            return num;
        }

        private int GetMaxXBH2(IFeatureClass pSubFClass, IFeature pSubFeature, ref IFeature pNewFeature)
        {
            int num = 0;
            try
            {
                if (pSubFeature == null)
                {
                    return num;
                }
                IFeature feature = pSubFeature;
                string name = UtilFactory.GetConfigOpt().GetConfigValue2("Sub", "VillField");
                int index = feature.Fields.FindField(name);
                if (index < 0)
                {
                    return 0;
                }
                string str2 = feature.get_Value(index).ToString();
                pNewFeature.set_Value(index, str2);
                name = UtilFactory.GetConfigOpt().GetConfigValue2("Sub", "LBField");
                index = feature.Fields.FindField(name);
                if (index < 0)
                {
                    return 0;
                }
                string str3 = feature.get_Value(index).ToString();
                pNewFeature.set_Value(index, str3);
                name = UtilFactory.GetConfigOpt().GetConfigValue2("Other", "CntyField");
                index = feature.Fields.FindField(name);
                if (index < 0)
                {
                    return 0;
                }
                string str4 = feature.get_Value(index).ToString();
                pNewFeature.set_Value(index, str4);
                name = UtilFactory.GetConfigOpt().GetConfigValue2("Other", "TownField");
                index = feature.Fields.FindField(name);
                if (index < 0)
                {
                    return 0;
                }
                str4 = feature.get_Value(index).ToString();
                pNewFeature.set_Value(index, str4);
                pNewFeature.Store();
                string str5 = "";
                str5 = UtilFactory.GetConfigOpt().GetConfigValue2("Sub", "VillField") + "='" + str2 + "'";
                string str7 = UtilFactory.GetConfigOpt().GetConfigValue2("Sub", "LBField");
                string str9 = str5;
                str5 = str9 + " and " + str7 + "='" + str3 + "'";
                IQueryFilter filter = new QueryFilterClass {
                    WhereClause = str5
                };
                IFeatureCursor o = pSubFClass.Search(filter, false);
                IFeature feature2 = o.NextFeature();
                string str8 = UtilFactory.GetConfigOpt().GetConfigValue2("Sub", "XBField");
                int num3 = pSubFClass.Fields.FindField(str8);
                while (feature2 != null)
                {
                    int num4 = 0;
                    try
                    {
                        num4 = Convert.ToInt16(Convert.ToDouble(feature2.get_Value(num3).ToString()));
                    }
                    catch
                    {
                    }
                    if (num4 > num)
                    {
                        num = num4;
                    }
                    feature2 = o.NextFeature();
                }
                Marshal.ReleaseComObject(o);
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "AttributesEdit.AutoUpdateSub", "GetMaxXBH2", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
            return num;
        }

        private IList<IGeometry> GetStayGeometrys(IGeometry pOperateGeo, ref IGeometry pOtherGeo, double dMinArea)
        {
            try
            {
                IList<IGeometry> geometrys = this.GetGeometrys(pOperateGeo);
                if (geometrys == null)
                {
                    return null;
                }
                IList<IGeometry> list2 = new List<IGeometry>();
                ITopologicalOperator2 @operator = null;
                double num = 0.0;
                for (int i = 0; i < geometrys.Count; i++)
                {
                    IGeometry pGeo = geometrys[i];
                    double area = this.GetArea(pGeo);
                    if (area <= dMinArea)
                    {
                        @operator = (ITopologicalOperator2) pOtherGeo;
                         @operator.IsKnownSimple_2 = false;
                        @operator.Simplify();
                        ITopologicalOperator2 operator2 = pGeo as ITopologicalOperator2;
                        operator2.IsKnownSimple_2 = false;
                        operator2.Simplify();
                        pGeo.SnapToSpatialReference();
                        pOtherGeo = @operator.Union(pGeo);
                    }
                    else if (area > num)
                    {
                        list2.Insert(0, pGeo);
                        num = area;
                    }
                    else
                    {
                        list2.Add(pGeo);
                    }
                }
                return list2;
            }
            catch
            {
                return null;
            }
        }

        private IList<IGeometry> GetStayGeometrys1(IGeometry pOperateGeo, out IList<IGeometry> pMinStayList, double dMinArea)
        {
            pMinStayList = new List<IGeometry>();
            try
            {
                IList<IGeometry> geometrys = this.GetGeometrys(pOperateGeo);
                if (geometrys == null)
                {
                    return null;
                }
                IList<IGeometry> list2 = new List<IGeometry>();
                double num = 0.0;
                for (int i = 0; i < geometrys.Count; i++)
                {
                    IGeometry pGeo = geometrys[i];
                    double area = this.GetArea(pGeo);
                    if (area <= dMinArea)
                    {
                        pMinStayList.Add(pGeo);
                    }
                    else if (area > num)
                    {
                        list2.Insert(0, pGeo);
                        num = area;
                    }
                    else
                    {
                        list2.Add(pGeo);
                    }
                }
                return list2;
            }
            catch
            {
                return null;
            }
        }

        private bool IsSampleGeometry(IGeometry pSGeo0, IGeometry pTGeo0)
        {
            if (this.m_Map == null)
            {
                return false;
            }
            try
            {
                IClone clone = pSGeo0 as IClone;
                IGeometry pGeometry = clone.Clone() as IGeometry;
                clone = pTGeo0 as IClone;
                IGeometry geometry2 = clone.Clone() as IGeometry;
                pGeometry = GISFunFactory.UnitFun.ConvertPoject(pGeometry, this.m_Map.SpatialReference);
                geometry2 = GISFunFactory.UnitFun.ConvertPoject(geometry2, this.m_Map.SpatialReference);
                Convert.ToDouble(UtilFactory.GetConfigOpt().GetConfigValue2("Sub", "TolIntersect"));
                IGeometry geometry3 = ((ITopologicalOperator2) pGeometry).Intersect(geometry2, esriGeometryDimension.esriGeometry2Dimension);
                IArea area = pGeometry as IArea;
                double num = Math.Abs(area.Area);
                area = geometry2 as IArea;
                double num2 = Math.Abs(area.Area);
                area = geometry3 as IArea;
                double num3 = Math.Abs(area.Area);
                double num4 = num;
                if (num2 > num)
                {
                    num4 = num2;
                }
                return ((num3 / num4) >= 0.95);
            }
            catch
            {
                return false;
            }
        }

        private bool IsSampleGeometry0(IGeometry pSGeo0, IGeometry pTGeo0)
        {
            if (this.m_Map == null)
            {
                return false;
            }
            try
            {
                IClone clone = pSGeo0 as IClone;
                IGeometry pGeometry = clone.Clone() as IGeometry;
                clone = pTGeo0 as IClone;
                IGeometry geometry2 = clone.Clone() as IGeometry;
                pGeometry = GISFunFactory.UnitFun.ConvertPoject(pGeometry, this.m_Map.SpatialReference);
                geometry2 = GISFunFactory.UnitFun.ConvertPoject(geometry2, this.m_Map.SpatialReference);
                ConfigOpt configOpt = UtilFactory.GetConfigOpt();
                double num = Convert.ToDouble(configOpt.GetConfigValue2("Sub", "TolCentroidDistance"));
                IArea area = pGeometry as IArea;
                IArea area2 = geometry2 as IArea;
                IPoint centroid = area.Centroid;
                IPoint point2 = area2.Centroid;
                double x = centroid.X;
                double y = centroid.Y;
                double num4 = point2.X;
                double num5 = point2.Y;
                double num6 = Math.Pow(num4 - x, 2.0);
                double num7 = Math.Pow(num5 - y, 2.0);
                if (Math.Sqrt(num6 + num7) <= num)
                {
                    return true;
                }
                double num9 = Convert.ToDouble(configOpt.GetConfigValue2("Sub", "TolArea"));
                double num10 = Math.Abs(area.Area);
                double num11 = Math.Abs(area2.Area);
                return (Math.Abs((double) (num10 - num11)) <= num9);
            }
            catch
            {
                return false;
            }
        }

        private bool IsSmallGeometry(IGeometry pGeo, double dMinArea)
        {
            return (this.GetArea(pGeo) <= dMinArea);
        }
        public MetaDataManager MDM
        {
            get
            {
                return DBServiceFactory<MetaDataManager>.Service;
            }
        }
        public bool PreUpdate(string sTableName, string sFilter, Label pLabel)
        {
            string str = (Convert.ToInt16(EditTask.TaskYear) - 1).ToString();
            string str2 = sTableName.Substring(0, sTableName.Length - 4) + str;
            try
            {
                pLabel.Text = "     正在清空变化原因、更新时间、细班……";
                pLabel.Refresh();
               // IDBAccess dBAccess = UtilFactory.GetDBAccess("SqlServer");
                string sSql = "update " + sTableName + " set BHYY=NULL,GXSJ=NULL,XI_BAN=NULL,DT_SRC=NULL";
                if (sFilter != "")
                {
                    sSql = sSql + " where " + sFilter;
                }
                if (this.ExecuteNonQuery(sSql) < 0)
                {
                    this.mErrOpt.ErrorOperate(this.mSubSysName, "AttributesEdit.AutoUpdateSub", "PreUpdate", "0", "", "清空变化原因与时间出错", "", "", "");
                    return false;
                }
                pLabel.Text = "     正在清空前期蓄积等字段……";
                pLabel.Refresh();
                IList<string> list = UtilFactory.GetConfigOpt().GetConfigValue2("AddFields", "FieldNames").Split(new char[] { ',' }).ToList<string>();
                IList<string> list2 = UtilFactory.GetConfigOpt().GetConfigValue2("AddFields", "MatchFields").Split(new char[] { ',' }).ToList<string>();
                sSql = "update " + sTableName + " set ";
                string str6 = "";
                for (int i = 0; i < list2.Count; i++)
                {
                    str6 = str6 + "," + list[i] + "=null";
                }
                sSql = sSql + str6.Substring(1);
                if (sFilter != "")
                {
                    sSql = sSql + " where " + sFilter;
                }
                if (this.ExecuteNonQuery(sSql) < 0)
                {
                    this.mErrOpt.ErrorOperate(this.mSubSysName, "AttributesEdit.AutoUpdateSub", "PreUpdate", "0", "", "清空前期蓄积等字段出错", "", "", "");
                    return false;
                }
                pLabel.Text = "     正在修改前期字段值……";
                pLabel.Refresh();
                string str7 = UtilFactory.GetConfigOpt().GetConfigValue2("EditData", "QFields");
                this.m_QFieldList = str7.Split(new char[] { ',' }).ToList<string>();
                string str8 = UtilFactory.GetConfigOpt().GetConfigValue2("EditData", "HFields");
                this.m_HFieldList = str8.Split(new char[] { ',' }).ToList<string>();
                for (int j = 0; j < this.m_QFieldList.Count; j++)
                {
                    string sCmdText = "select * from syscolumns where id=object_id('" + sTableName + "') and name='" + this.m_QFieldList[j] + "'";
                    if (ExecuteNonQuery(sCmdText)<0)
                    {
                        this.mErrOpt.ErrorOperate(this.mSubSysName, "AttributesEdit.AutoUpdateSub", "PreUpdate", "0", "", "修改新增的前期字段时出错", "", "", "");
                        MessageBox.Show("前期字段" + this.m_QFieldList[j] + "不存在，请至数据管理中升级数据库版本为最新！", "自动更新");
                        return false;
                    }
                }
                sSql = "update " + sTableName + " set ";
                string str10 = "";
                for (int k = 0; k < this.m_QFieldList.Count; k++)
                {
                    string str11 = str10;
                    str10 = str11 + "," + this.m_HFieldList[k] + "=t1." + this.m_HFieldList[k] + "," + this.m_QFieldList[k] + "=t1." + this.m_HFieldList[k];
                }
                sSql = ((((sSql + str10.Substring(1)) + " from " + str2 + " t1") + " where " + sTableName + ".CUN=t1.CUN") + " and " + sTableName + ".LIN_BAN=t1.LIN_BAN") + " and " + sTableName + ".XIAO_BAN=t1.XIAO_BAN";
                if (sFilter != "")
                {
                    sSql = sSql + " and " + sTableName + "." + sFilter;
                }
                if (this.ExecuteNonQuery(sSql) < 0)
                {
                    this.mErrOpt.ErrorOperate(this.mSubSysName, "AttributesEdit.AutoUpdateSub", "PreUpdate", "0", "", "修改前期字段时出错", "", "", "");
                    return false;
                }
                return true;
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "AttributesEdit.AutoUpdateSub", "AutoUpdate", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                MessageBox.Show("修改字段值失败！请检查数据库是否为最新版本。", "自动更新");
                return false;
            }
        }

        private void SaveOperateRecord(int oid, string sOperate)
        {
        
                try
                {
                    string str = DateTime.Now.ToString("yyyyMMdd");
                    string sCmdText = "";
                    sCmdText = string.Concat(new object[] { "insert into ", this.m_SaveTableName, " (Feature_ID,Update_Type,Update_Time) values (", oid, ",'", sOperate, "','", str, "')" });
                    this.ExecuteNonQuery(sCmdText);
                }
                catch
                {
                }
            
        }

        public bool SetDataDtsrc(string sTableName1, string sTableName2)
        {
            string str = "备份统计数据";
            try
            {
                //IDBAccess dBAccess = UtilFactory.GetDBAccess("SqlServer");
                //if (dBAccess == null)
                //{
                //    MessageBox.Show("数据库连接失败！", "提示");
                //    return false;
                //}
                //string str2 = "BAK2";
                //string sCmdText = "update " + sTableName2 + " set " + str2 + "=0";
                //if (dBAccess.ExecuteNonQuery(sCmdText) < 0)
                //{
                //    MessageBox.Show(str + "出错！", "提示");
                //    return false;
                //}
                //sCmdText = ("update t2 set t2." + str2 + "=12 from " + sTableName2 + " t2") + " where (t2.Q_DI_LEI in('111','112','120','130','301','961','962','963')) and (t2.DI_LEI in('111','112','120','130','301','961','962','963')) and (t2.BHYY in('11','12','13'))";
                //if (dBAccess.ExecuteNonQuery(sCmdText) < 0)
                //{
                //    MessageBox.Show(str + "出错！", "提示");
                //    return false;
                //}
                //str2 = "BAK1";
                //sCmdText = "update " + sTableName2 + " set " + str2 + "=0";
                //if (dBAccess.ExecuteNonQuery(sCmdText) < 0)
                //{
                //    MessageBox.Show(str + "出错！", "提示");
                //    return false;
                //}
                //sCmdText = ("update t2 set t2." + str2 + "=round(t2.MIAN_JI/t1.MIAN_JI*t1.SSZZS,0) from " + sTableName1 + " t1," + sTableName2 + " t2") + " where t1.SSLX='2' and t1.CUN=t2.CUN and t1.LIN_BAN=t2.LIN_BAN and t1.XIAO_BAN=right(t2.XI_BAN,len(t2.XI_BAN)-charindex('-',t2.XI_BAN))";
                //if (dBAccess.ExecuteNonQuery(sCmdText) < 0)
                //{
                //    MessageBox.Show(str + "出错！", "提示");
                //    return false;
                //}
                //sCmdText = ("update t2 set t2." + str2 + "=round(t2.MIAN_JI/t1.MIAN_JI*t1.SSZZS,0) from " + sTableName1 + " t1," + sTableName2 + " t2") + " where t1.SSLX='2' and t1.CUN=t2.CUN and t1.LIN_BAN=t2.LIN_BAN and t1.XIAO_BAN=t2.XIAO_BAN";
                //if (dBAccess.ExecuteNonQuery(sCmdText) < 0)
                //{
                //    MessageBox.Show(str + "出错！", "提示");
                //    return false;
                //}
                return true;
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "AttributesEdit.AutoUpdateSub", "SetDataDtsrc", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                MessageBox.Show(str + "出错！", "提示");
                return false;
            }
        }

        private void SetXBID(IFeature pFeature, string sXB)
        {
            try
            {
                ConfigOpt configOpt = UtilFactory.GetConfigOpt();
                string sFieldName = configOpt.GetConfigValue2("Sub", "VillField");
                string str2 = configOpt.GetConfigValue2("Sub", "LBField");
                string str3 = "XBID";
                string pFieldValue = DataFuncs.GetFieldValue(pFeature, sFieldName).ToString() + DataFuncs.GetFieldValue(pFeature, str2).ToString() + sXB;
                DataFuncs.UpdateField(pFeature, str3, pFieldValue);
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "AttributesEdit.AutoUpdateSub", "SetXBID", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private void UpdateAttributes(IFeature pZTFeature, IFeature pSubFeature, IList<string> pIgnores)
        {
            try
            {
                IFields fields = pZTFeature.Fields;
                for (int i = 0; i < fields.FieldCount; i++)
                {
                    IField field = fields.get_Field(i);
                    if (((field.Type != esriFieldType.esriFieldTypeOID) && (field.Type != esriFieldType.esriFieldTypeGeometry)) && field.Editable)
                    {
                        string name = field.Name;
                        if (((pIgnores == null) || !pIgnores.Contains(name)) && (name.IndexOf("Q_") != 0))
                        {
                            object obj2 = pZTFeature.get_Value(i);
                            int index = pSubFeature.Fields.FindField(name);
                            if (index > 0)
                            {
                                pSubFeature.set_Value(index, obj2);
                            }
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "AttributesEdit.AutoUpdateSub", "UpdateAttributes", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }
        //private MetaDataManager MDM
        //{
        //    get { return DBServiceFactory<MetaDataManager>.Service; }
        //}
        //private bool ExecuteNonQuery(string sql)
        //{
        //    return MDM.UpdateDB(sql);
        //}
        public bool UpdateDist(IFeatureLayer pSubLayer, IFeatureLayer pChangeLayer, object pDist, string sDistName, Label pLabel)
        {
            try
            {
                string sCmdText = "";
                sCmdText = "delete from " + this.m_SaveTableName;
                this.ExecuteNonQuery(sCmdText);
                string sFilter = "";
                if (pDist == DBNull.Value)
                {
                    sFilter = "XIANG is null";
                }
                else
                {
                    sFilter = "XIANG='" + pDist.ToString() + "'";
                }
                IFeatureClass featureClass = pSubLayer.FeatureClass;
                if (featureClass == null)
                {
                    return false;
                }
                IFeatureClass class3 = pChangeLayer.FeatureClass;
                if (class3 == null)
                {
                    return false;
                }
                string name = ((IDataset) featureClass).Name;
                if (!this.PreUpdate(name, sFilter, pLabel))
                {
                    return false;
                }
                ConfigOpt configOpt = UtilFactory.GetConfigOpt();
                this.m_CntyField = configOpt.GetConfigValue2("Sub", "CntyField");
                if (this.m_CntyField == "")
                {
                    return false;
                }
                this.m_TownField = configOpt.GetConfigValue2("Sub", "TownField");
                if (this.m_TownField == "")
                {
                    return false;
                }
                this.m_VillField = configOpt.GetConfigValue2("Sub", "VillField");
                if (this.m_VillField == "")
                {
                    return false;
                }
                this.m_LBField = configOpt.GetConfigValue2("Sub", "LBField");
                if (this.m_LBField == "")
                {
                    return false;
                }
                this.m_XiaoBField = configOpt.GetConfigValue2("Sub", "XBField");
                if (this.m_XiaoBField == "")
                {
                    return false;
                }
                this.m_XiBField = configOpt.GetConfigValue2("Sub", "XibanField");
                if (this.m_XiBField == "")
                {
                    return false;
                }
                this.m_MinArea = Convert.ToDouble(configOpt.GetConfigValue2("Sub", "MinArea"));
                this.m_BHMinArea = 0.067;
                IWorkspaceEdit workspace = (IWorkspaceEdit) Editor.UniqueInstance.Workspace;
                int index = 0;
                IList<IFeature> pFList = new List<IFeature>();
                IQueryFilter filter = new QueryFilterClass {
                    WhereClause = sFilter
                };
                IFeatureCursor o = class3.Search(filter, false);
                for (IFeature feature = o.NextFeature(); feature != null; feature = o.NextFeature())
                {
                    pFList.Add(feature);
                }
                Marshal.ReleaseComObject(o);
                if ((pFList.Count >= 1) && !this.UpdateTownFeature(workspace, featureClass, pFList, index, pLabel, sDistName))
                {
                    return false;
                }
                return true;
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "AttributesEdit.AutoUpdateSub", "UpdateDist", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                return false;
            }
        }

        private bool UpdateFeature(IFeatureClass pSubFClass, IFeature pFeature, IGeometry pNewGeo)
        {
            if (pNewGeo == null)
            {
                pNewGeo = pFeature.ShapeCopy;
            }
            try
            {
                IList<IGeometry> geometrys = this.GetGeometrys(pNewGeo);
                for (int i = 0; i < geometrys.Count; i++)
                {
                    IGeometry geometry = geometrys[i];
                    if (!geometry.IsEmpty)
                    {
                        ISpatialFilter filter = new SpatialFilterClass {
                            GeometryField = pSubFClass.ShapeFieldName,
                            SpatialRel = esriSpatialRelEnum.esriSpatialRelIntersects,
                            Geometry = geometry
                        };
                        IFeatureCursor pSubCursor = pSubFClass.Search(filter, false);
                        int num2 = this.UpdateFeature(pSubFClass, pSubCursor, pFeature, geometry);
                        Marshal.ReleaseComObject(pSubCursor);
                        if (num2 == 0)
                        {
                            return false;
                        }
                        if ((num2 == 2) && (this.UpdateFeature(pSubFClass, null, pFeature, geometry) == 0))
                        {
                            return false;
                        }
                    }
                }
                return true;
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "AttributesEdit.AutoUpdateSub", "UpdateFeature0", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                return false;
            }
        }

        private int UpdateFeature(IFeatureClass pSubFClass, IFeatureCursor pSubCursor, IFeature pFeature, IGeometry pNewGeo)
        {
            try
            {
                int index = pSubFClass.Fields.FindField(this.m_XiaoBField);
                int num2 = pSubFClass.Fields.FindField(this.m_XiBField);
                IList<string> pIgnores = new List<string> {
                    this.m_XiaoBField,
                    this.m_XiBField,
                    this.m_LBField,
                    this.m_VillField,
                    this.m_TownField,
                    this.m_CntyField
                };
                if (pSubCursor == null)
                {
                    IFeature pSubFeature = pSubFClass.CreateFeature();
                    pSubFeature.Shape = pNewGeo;
                    this.UpdateAttributes(pFeature, pSubFeature, null);
                    pSubFeature.Store();
                    this.SaveOperateRecord(pSubFeature.OID, "3");
                    return 1;
                }
                IFeature item = pSubCursor.NextFeature();
                if (item == null)
                {
                    return 2;
                }
                IList<IFeature> list2 = new List<IFeature>();
                while (item != null)
                {
                    if (list2.Count < 1)
                    {
                        list2.Add(item);
                    }
                    else
                    {
                        IArea shapeCopy = item.ShapeCopy as IArea;
                        int num3 = 0;
                        for (int j = 0; j < list2.Count; j++)
                        {
                            IFeature feature3 = list2[0];
                            IArea area2 = feature3.ShapeCopy as IArea;
                            if (shapeCopy.Area > area2.Area)
                            {
                                num3 = j;
                                break;
                            }
                            num3 = j + 1;
                        }
                        list2.Insert(num3, item);
                    }
                    item = pSubCursor.NextFeature();
                }
                string str = UtilFactory.GetConfigOpt().GetConfigValue2("Sub", "AreaField");
                pIgnores.Add(str);
                double num5 = 0.0;
                double area = 0.0;
                this.GetArea(pNewGeo);
                ITopologicalOperator2 @operator = pNewGeo as ITopologicalOperator2;
                 @operator.IsKnownSimple_2 = false;
                @operator.Simplify();
                for (int i = 0; i < list2.Count; i++)
                {
                    item = list2[i];
                    string str2 = item.get_Value(index).ToString();
                    string str3 = str2;
                    string str4 = item.get_Value(num2).ToString();
                    int num8 = str4.IndexOf("-");
                    if (num8 > 0)
                    {
                        str3 = str4.Substring(num8 + 1);
                    }
                    IGeometry pGeo = item.ShapeCopy;
                    area = this.GetArea(pGeo);
                    num5 = this.ConvertToDouble(DataFuncs.GetFieldValue(item, str));
                    if (num5 == 0.0)
                    {
                        num5 = area;
                    }
                    if (this.IsSampleGeometry(pNewGeo, pGeo))
                    {
                        this.UpdateAttributes(pFeature, item, pIgnores);
                        DataFuncs.UpdateField(item, str, Math.Round(num5, 2));
                        item.set_Value(num2, str2 + "-" + str3);
                        item.Store();
                        this.SaveOperateRecord(item.OID, "2");
                        return 1;
                    }
                    double dMinArea = 0.0;
                    string sFieldName = "DI_LEI";
                    string str6 = "Q_DI_LEI";
                    string str7 = DataFuncs.GetFieldValue(pFeature, str6).ToString().Trim();
                    string str8 = DataFuncs.GetFieldValue(pFeature, sFieldName).ToString().Trim();
                    if (((str7 != "") && (str8 != "")) && (((this.ConvertToInt(str7.Substring(0, 1)) + this.ConvertToInt(str8.Substring(0, 1))) >= 10) && ((this.ConvertToInt(str7.Substring(0, 1)) + this.ConvertToInt(str8.Substring(0, 1))) < 0x12)))
                    {
                        dMinArea = this.m_BHMinArea;
                    }
                    else
                    {
                        dMinArea = this.m_MinArea;
                    }
                    ITopologicalOperator2 operator2 = (ITopologicalOperator2) pGeo;
                    operator2.IsKnownSimple_2 = false;
                    operator2.Simplify();
                    IGeometry geometry2 = operator2.Intersect(pNewGeo, esriGeometryDimension.esriGeometry2Dimension);
                    if (((geometry2 != null) && !geometry2.IsEmpty) && !this.IsSmallGeometry(geometry2, dMinArea))
                    {
                        IGeometry pOtherGeo = operator2.Difference(pNewGeo);
                        if (pOtherGeo.IsEmpty)
                        {
                            this.UpdateAttributes(pFeature, item, pIgnores);
                            DataFuncs.UpdateField(item, str, Math.Round(num5, 2));
                            item.set_Value(num2, str2 + "-" + str3);
                            item.Store();
                            this.SaveOperateRecord(item.OID, "2");
                        }
                        else
                        {
                            IList<IGeometry> list3 = this.GetStayGeometrys(geometry2, ref pOtherGeo, dMinArea);
                            if ((list3 != null) && (list3.Count != 0))
                            {
                                IList<IGeometry> pMinStayList = null;
                                IList<IGeometry> list5 = this.GetStayGeometrys1(pOtherGeo, out pMinStayList, dMinArea);
                                if (list5 != null)
                                {
                                    if (list5.Count == 0)
                                    {
                                        this.UpdateAttributes(pFeature, item, pIgnores);
                                        DataFuncs.UpdateField(item, str, Math.Round(num5, 2));
                                        item.set_Value(num2, str2 + "-" + str3);
                                        item.Store();
                                        this.SaveOperateRecord(item.OID, "2");
                                    }
                                    else
                                    {
                                        int num44;
                                        if (pMinStayList.Count > 0)
                                        {
                                            for (int n = 0; n < pMinStayList.Count; n++)
                                            {
                                                IGeometry other = pMinStayList[n];
                                                IRelationalOperator2 operator3 = (IRelationalOperator2) other;
                                                for (int num11 = 0; num11 < list3.Count; num11++)
                                                {
                                                    IGeometry geometry5 = list3[num11];
                                                    if (operator3.Touches(geometry5))
                                                    {
                                                        list3[num11] = ((ITopologicalOperator2) geometry5).Union(other);
                                                        break;
                                                    }
                                                }
                                            }
                                        }
                                        string str9 = "SSZZS";
                                        double num12 = this.ConvertToDouble(DataFuncs.GetFieldValue(item, str9));
                                        string str10 = UtilFactory.GetConfigOpt().GetConfigValue2("Sub", "BSXJField");
                                        double num13 = this.ConvertToDouble(DataFuncs.GetFieldValue(item, str10));
                                        string str11 = UtilFactory.GetConfigOpt().GetConfigValue2("Sub", "SSXJField");
                                        double num14 = this.ConvertToDouble(DataFuncs.GetFieldValue(item, str11));
                                        string str12 = UtilFactory.GetConfigOpt().GetConfigValue2("Sub", "YSSZXJField");
                                        string str13 = UtilFactory.GetConfigOpt().GetConfigValue2("Sub", "SLXJField");
                                        string str14 = UtilFactory.GetConfigOpt().GetConfigValue2("Sub", "ZXJField");
                                        string str15 = "HUO_LMGQXJ";
                                        double num15 = this.ConvertToDouble(DataFuncs.GetFieldValue(item, str15));
                                        string str16 = "SSLX";
                                        for (int k = 0; k < list5.Count; k++)
                                        {
                                            IGeometry geometry6 = list5[k];
                                            double num17 = this.GetArea(geometry6);
                                            double num18 = (num17 / area) * num5;
                                            IFeature pStayFeature = null;
                                            string str17 = "";
                                            if (k == 0)
                                            {
                                                pStayFeature = item;
                                                str17 = str2;
                                            }
                                            else
                                            {
                                                pStayFeature = pSubFClass.CreateFeature();
                                                this.UpdateStayAttributes(item, pStayFeature, null);
                                                num44 = this.GetMaxXBH2(pSubFClass, item, ref pStayFeature) + 1;
                                                str17 = num44.ToString().PadLeft(4, '0');
                                            }
                                            pStayFeature.Shape = geometry6;
                                            pStayFeature.set_Value(index, str17);
                                            pStayFeature.set_Value(num2, str17 + "-" + str3);
                                            DataFuncs.UpdateField(pStayFeature, str, Math.Round(num18, 2));
                                            this.SetXBID(pStayFeature, str17);
                                            if (num12 > 0.0)
                                            {
                                                double num20 = Math.Round((double) ((num17 / area) * num12));
                                                DataFuncs.UpdateField(pStayFeature, str9, num20);
                                            }
                                            double pFieldValue = 0.0;
                                            if (num15 > 0.0)
                                            {
                                                pFieldValue = Math.Round((double) (num15 * num18));
                                                DataFuncs.UpdateField(pStayFeature, str12, pFieldValue);
                                            }
                                            else
                                            {
                                                pFieldValue = this.ConvertToDouble(DataFuncs.GetFieldValue(pStayFeature, str12));
                                            }
                                            double num22 = Math.Round((double) ((num13 / num5) * num18));
                                            DataFuncs.UpdateField(pStayFeature, str10, num22);
                                            double num23 = Math.Round((double) (pFieldValue + num22));
                                            DataFuncs.UpdateField(pStayFeature, str13, num23);
                                            string str18 = DataFuncs.GetFieldValue(item, str16).ToString();
                                            double num24 = 0.0;
                                            if (str18 == "1")
                                            {
                                                num24 = 0.0;
                                                DataFuncs.UpdateField(pStayFeature, str11, num24);
                                                string[] strArray = new string[] { "SSLX", "SSZYSZ", "SSZZS", "SSPJXJ", "SSPJGD", "SSXJ" };
                                                for (int num25 = 0; num25 < strArray.Length; num25++)
                                                {
                                                    DataFuncs.UpdateField(pStayFeature, strArray[num25], DBNull.Value);
                                                }
                                            }
                                            else
                                            {
                                                num24 = Math.Round((double) ((num14 / num5) * num18));
                                                DataFuncs.UpdateField(pStayFeature, str11, num24);
                                            }
                                            double num26 = Math.Round((double) (num23 + num24));
                                            DataFuncs.UpdateField(pStayFeature, str14, num26);
                                            pStayFeature.Store();
                                            this.SaveOperateRecord(item.OID, "1");
                                        }
                                        for (int m = 0; m < list3.Count; m++)
                                        {
                                            IGeometry geometry7 = list3[m];
                                            double num28 = this.GetArea(geometry7);
                                            double num29 = 0.0;
                                            num29 = (num28 / area) * num5;
                                            IFeature pTargObj = pSubFClass.CreateFeature();
                                            pTargObj.Shape = geometry7;
                                            DataFuncs.CopyGeoObject(item, pTargObj);
                                            this.UpdateAttributes(pFeature, pTargObj, pIgnores);
                                            DataFuncs.UpdateField(pTargObj, str, Math.Round(num29, 2));
                                            num44 = this.GetMaxXBH2(pSubFClass, item, ref pTargObj) + 1;
                                            string str19 = num44.ToString().PadLeft(4, '0');
                                            pTargObj.set_Value(index, str19);
                                            pTargObj.set_Value(num2, str19 + "-" + str3);
                                            this.SetXBID(pTargObj, str19);
                                            double num31 = this.GetArea(pFeature.ShapeCopy);
                                            double num32 = this.ConvertToDouble(DataFuncs.GetFieldValue(pFeature, str9));
                                            if (num32 > 0.0)
                                            {
                                                double num33 = Math.Round((double) ((num28 / num31) * num32));
                                                DataFuncs.UpdateField(pTargObj, str9, num33);
                                            }
                                            double num34 = this.ConvertToDouble(DataFuncs.GetFieldValue(pFeature, str15));
                                            double num35 = 0.0;
                                            if (num34 > 0.0)
                                            {
                                                num35 = Math.Round((double) (num34 * num29));
                                                DataFuncs.UpdateField(pTargObj, str12, num35);
                                            }
                                            else
                                            {
                                                num35 = this.ConvertToDouble(DataFuncs.GetFieldValue(pTargObj, str12));
                                            }
                                            double num37 = Math.Round((double) ((this.ConvertToDouble(DataFuncs.GetFieldValue(pFeature, str10)) / num31) * num29));
                                            DataFuncs.UpdateField(pTargObj, str10, num37);
                                            double num38 = Math.Round((double) (num35 + num37));
                                            DataFuncs.UpdateField(pTargObj, str13, num38);
                                            string str20 = DataFuncs.GetFieldValue(pFeature, str16).ToString();
                                            double num39 = 0.0;
                                            if (str20 == "1")
                                            {
                                                num39 = 0.0;
                                                DataFuncs.UpdateField(pTargObj, str11, num39);
                                                string[] strArray2 = new string[] { "SSLX", "SSZYSZ", "SSZZS", "SSPJXJ", "SSPJGD", "SSXJ" };
                                                for (int num40 = 0; num40 < strArray2.Length; num40++)
                                                {
                                                    DataFuncs.UpdateField(pTargObj, strArray2[num40], DBNull.Value);
                                                }
                                            }
                                            else
                                            {
                                                num39 = Math.Round((double) ((this.ConvertToDouble(DataFuncs.GetFieldValue(pFeature, str11)) / num31) * num29));
                                                DataFuncs.UpdateField(pTargObj, str11, num39);
                                            }
                                            double num42 = Math.Round((double) (num38 + num39));
                                            DataFuncs.UpdateField(pTargObj, str14, num42);
                                            pTargObj.Store();
                                            this.SaveOperateRecord(pTargObj.OID, "1");
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                return 1;
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "AttributesEdit.AutoUpdateSub", "UpdateFeature", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                return 0;
            }
        }

        private bool UpdateIDFeature(IWorkspaceEdit pWsEdit, IFeatureClass pChangeFClass, IFeatureClass pSubFClass, DataTable pTable, Label pLabel)
        {
            bool flag = false;
            pWsEdit.StartEditing(false);
            pWsEdit.StartEditOperation();
            try
            {
                for (int i = 0; i < pTable.Rows.Count; i++)
                {
                    pLabel.Text = "     正在处理第 " + (i + 1) + " 个班块……";
                    pLabel.Refresh();
                    int iD = Convert.ToInt32(pTable.Rows[i][0].ToString());
                    IFeature pFeature = pChangeFClass.GetFeature(iD);
                    this.UpdateFeature(pSubFClass, pFeature, null);
                    if ((i > 0) && ((i % 100) == 0))
                    {
                        GC.Collect();
                        pWsEdit.StopEditOperation();
                        pWsEdit.StopEditing(true);
                        pWsEdit.StartEditing(false);
                        pWsEdit.StartEditOperation();
                    }
                }
                pWsEdit.StopEditOperation();
                flag = true;
            }
            catch (Exception exception)
            {
                pWsEdit.AbortEditOperation();
                flag = false;
                this.mErrOpt.ErrorOperate(this.mSubSysName, "AttributesEdit.AutoUpdateSub", "UpdateTownFeature", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
            finally
            {
                GC.Collect();
                pWsEdit.StopEditing(true);
            }
            return flag;
        }

        private void UpdateStayAttributes(IFeature pSubFeature, IFeature pStayFeature, IList<string> pIgnores)
        {
            try
            {
                IFields fields = pSubFeature.Fields;
                for (int i = 0; i < fields.FieldCount; i++)
                {
                    IField field = fields.get_Field(i);
                    if (((field.Type != esriFieldType.esriFieldTypeOID) && (field.Type != esriFieldType.esriFieldTypeGeometry)) && field.Editable)
                    {
                        string name = field.Name;
                        if ((pIgnores == null) || !pIgnores.Contains(name))
                        {
                            object obj2 = pSubFeature.get_Value(i);
                            int index = pStayFeature.Fields.FindField(name);
                            if (index > 0)
                            {
                                pStayFeature.set_Value(index, obj2);
                            }
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "AttributesEdit.AutoUpdateSub", "UpdateStayAttributes", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        }

        private bool UpdateTownFeature(IWorkspaceEdit pWsEdit, IFeatureClass pSubFClass, IList<IFeature> pFList, int index, Label pLabel, string sLabel0)
        {
            bool flag = false;
            pWsEdit.StartEditing(false);
            pWsEdit.StartEditOperation();
            try
            {
                for (int i = 0; i < pFList.Count; i++)
                {
                    Application.DoEvents();
                    if (sLabel0 != "")
                    {
                        pLabel.Text = string.Concat(new object[] { "     正在处理", sLabel0, "：第 ", (index + i) + 1, " 个班块……" });
                    }
                    else
                    {
                        pLabel.Text = "     正在处理第 " + ((index + i) + 1) + " 个班块……";
                    }
                    pLabel.Refresh();
                    IFeature pFeature = pFList[i];
                    if (!this.UpdateFeature(pSubFClass, pFeature, null))
                    {
                        pWsEdit.AbortEditOperation();
                        flag = false;
                        goto Label_0153;
                    }
                    if ((i > 0) && ((i % 80) == 0))
                    {
                        GC.Collect();
                        pWsEdit.StopEditOperation();
                        pWsEdit.StopEditing(true);
                        this.ClearMemory();
                        pWsEdit.StartEditing(false);
                        pWsEdit.StartEditOperation();
                    }
                }
                pWsEdit.StopEditOperation();
                flag = true;
            }
            catch (Exception exception)
            {
                pWsEdit.AbortEditOperation();
                flag = false;
                this.mErrOpt.ErrorOperate(this.mSubSysName, "AttributesEdit.AutoUpdateSub", "UpdateTownFeature", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
        Label_0153:
            GC.Collect();
            pWsEdit.StopEditing(true);
            return flag;
        }

        public bool UpdateXJ(IFeatureLayer pSubLayer)
        {
            try
            {
                IFeatureClass featureClass = pSubLayer.FeatureClass;
                if (featureClass == null)
                {
                    return false;
                }
                string name = ((IDataset) featureClass).Name;
                string sSql = "update " + name + " set huo_lmgqxj=zxj/mian_ji where mian_ji>0";
               // IDBAccess dBAccess = UtilFactory.GetDBAccess("SqlServer");
                //if (this.ExecuteNonQuery((SqlConnection) dBAccess.Connection, sSql) < 0)
                //{
                //    this.mErrOpt.ErrorOperate(this.mSubSysName, "AttributesEdit.AutoUpdateSub", "UpdateXJ", "0", "", "更新公顷蓄积出错", "", "", "");
                //    return false;
                //}
                return true;
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this.mSubSysName, "AttributesEdit.AutoUpdateSub", "UpdateXJ", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
                return false;
            }
        }
    }
}

