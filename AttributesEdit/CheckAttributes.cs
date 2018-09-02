namespace AttributesEdit
{
    using ESRI.ArcGIS.Carto;
    using ESRI.ArcGIS.Geodatabase;
    using System;
    using System.Collections;
    using System.Data;
    using System.Runtime.InteropServices;
    using TaskManage;
    using Utilities;

    public class CheckAttributes
    {
        public static DataTable CheckAttr(ArrayList pOList, DataTable pRuleTable, string sSubField, string sDatasetName)
        {
            if (pOList == null)
            {
                return null;
            }
            DataTable table = new DataTable();
            DataColumn column = new DataColumn {
                Caption = "OID",
                ColumnName = "OID",
                DataType = typeof(string),
                MaxLength = 4
            };
            DataColumn column2 = new DataColumn {
                Caption = "班号",
                ColumnName = "班号",
                DataType = typeof(string),
                MaxLength = 20
            };
            DataColumn column3 = new DataColumn {
                Caption = "规则",
                ColumnName = "规则",
                DataType = Type.GetType("System.String"),
                MaxLength = 350
            };
            table.Columns.AddRange(new DataColumn[] { column, column2, column3 });
            try
            {
                ArrayList list;
                DataRow[] rowArray = pRuleTable.Select("CHECK_TYPE='UNIQUE'");
                ArrayList list2 = new ArrayList();
                ArrayList list3 = new ArrayList();
                if (rowArray.Length > 0)
                {
                    for (int j = 0; j < rowArray.Length; j++)
                    {
                        list = CheckUnique(pOList, rowArray[j]["CHECK_FIELD"].ToString());
                        if ((list != null) & (list.Count > 0))
                        {
                            list2.Add(rowArray[j]["CHECK_FIELD"].ToString());
                            list3.Add(list);
                        }
                    }
                }
                rowArray = pRuleTable.Select("CHECK_TYPE='INCODE'");
                ArrayList list4 = new ArrayList();
                ArrayList list5 = new ArrayList();
                if (rowArray.Length > 0)
                {
                  //  IDBAccess dBAccess = UtilFactory.GetDBAccess(UtilFactory.GetConfigOpt().GetConfigValue2("DataBase", "DBkey"));
                    string str2 = "";
                    string str3 = "T_SYS_META_CODE";
                    for (int k = 0; k < rowArray.Length; k++)
                    {
                        string str4 = rowArray[k]["CHECK_FIELD"].ToString();
                        string str5 = rowArray[k]["CHECK_RULE"].ToString();
                        string sql = "select OBJECTID from " + str2 + " where (" + str4 + "<>'') and (" + str4 + " is not null) and (" + str4 + " not in (select CCODE from " + str3 + " where CTYPE='" + str5 + "'))";
                        DataTable dataTable = null;// dBAccess.GetDataTable(dBAccess, sql);
                        if ((dataTable != null) && (dataTable.Rows.Count >= 1))
                        {
                            string str7 = rowArray[k]["FIELD_ALIAS"] + rowArray[k]["ERROR_DESCRIP"].ToString();
                            for (int m = 0; m < dataTable.Rows.Count; m++)
                            {
                                string item = dataTable.Rows[m][0].ToString();
                                if (list4.Contains(item))
                                {
                                    int index = list4.IndexOf(item);
                                    list5[index] = list5[index] + "," + str7;
                                }
                                else
                                {
                                    list4.Add(item);
                                    list5.Add(str7);
                                }
                            }
                        }
                    }
                }
                string str11 = "";
                for (int i = 0; i < pOList.Count; i++)
                {
                    try
                    {
                        str11 = "";
                        IObject pObj = pOList[i] as IObject;
                        IQueryFilter queryFilter = new QueryFilterClass();
                        ICursor cursor = null;
                        for (int n = 0; n < pRuleTable.Rows.Count; n++)
                        {
                            DataRow row = pRuleTable.Rows[n];
                            string name = row["CHECK_FIELD"].ToString();
                            string str10 = row["CHECK_TYPE"].ToString();
                            string str12 = row["CHECK_RULE"].ToString();
                            string str13 = row["FIELD_ALIAS"] + row["ERROR_DESCRIP"].ToString();
                            int num5 = -1;
                            num5 = pObj.Fields.FindField(name);
                            if (num5 >= 0)
                            {
                                pObj.Fields.get_Field(num5);
                                object obj2 = pObj.get_Value(num5);
                                if (str10.ToLower() == "unique")
                                {
                                    for (int num8 = 0; num8 < list2.Count; num8++)
                                    {
                                        if (name == list2[num8].ToString())
                                        {
                                            list = list3[num8] as ArrayList;
                                            if (list.Contains(obj2))
                                            {
                                                str11 = str11 + "," + str13;
                                            }
                                        }
                                    }
                                }
                                else if (str10.ToLower() == "incode")
                                {
                                    if (list4.Contains(pObj.OID.ToString()))
                                    {
                                        int num9 = list4.IndexOf(pObj.OID.ToString());
                                        str11 = str11 + "," + list5[num9].ToString();
                                    }
                                }
                                else
                                {
                                    bool flag1 = str10.ToLower() != "notnull";
                                    queryFilter.WhereClause = string.Concat(new object[] { "(", str12, ") and ", pObj.Class.OIDFieldName, "=", pObj.OID });
                                    cursor = pObj.Table.Search(queryFilter, false);
                                    if ((cursor != null) && (cursor.NextRow() != null))
                                    {
                                        str11 = str11 + "," + str13;
                                    }
                                }
                            }
                        }
                        if (str11 != "")
                        {
                            DataRow row3 = table.NewRow();
                            row3[0] = pObj.OID;
                            row3[1] = DataFuncs.GetFieldValue(pObj, sSubField);
                            row3[2] = str11.Substring(1);
                            table.Rows.Add(row3);
                        }
                    }
                    catch
                    {
                    }
                }
                return table;
            }
            catch
            {
                return table;
            }
        }

        public static string CheckFeatureAttr(IFeatureLayer pFLayer, IFeature pFeature)
        {
            string sql = "";
            string str2 = EditTask.KindCode.Substring(0, 2);
            string str3 = "T_Logic_Check";
            sql = "select * from " + str3 + " where design_kind like '" + str2 + "%' and enabled=true order by CHECK_ID,ID";
          //  IDBAccess dBAccess = UtilFactory.GetDBAccess("Access");
            DataTable dataTable = null;// dBAccess.GetDataTable(dBAccess, sql);
            if ((dataTable == null) || (dataTable.Rows.Count < 1))
            {
                return "";
            }
            try
            {
                IFeatureClass featureClass = pFLayer.FeatureClass;
                string definitionExpression = "";
                if (EditTask.KindCode.Length > 4)
                {
                    IFeatureLayerDefinition definition = pFLayer as IFeatureLayerDefinition;
                    definitionExpression = definition.DefinitionExpression;
                }
                DataRow[] rowArray = dataTable.Select("CHECK_TYPE='UNIQUE'");
                ArrayList list = new ArrayList();
                IQueryFilter filter = new QueryFilterClass();
                if (rowArray.Length > 0)
                {
                    for (int j = 0; j < rowArray.Length; j++)
                    {
                        string str5 = rowArray[j]["CHECK_FIELD"].ToString().Replace(" ", "");
                        string[] strArray = str5.Split(new char[] { '+' });
                        string str6 = definitionExpression;
                        for (int k = 0; k < strArray.Length; k++)
                        {
                            string name = strArray[k];
                            int index = featureClass.Fields.FindField(name);
                            if (index >= 0)
                            {
                                object obj2 = pFeature.get_Value(index);
                                if (featureClass.Fields.get_Field(index).Type == esriFieldType.esriFieldTypeString)
                                {
                                    string str8 = obj2.ToString();
                                    str6 = str6 + " and " + strArray[k] + "='" + str8 + "'";
                                }
                                else if ((obj2 == null) || (obj2 == DBNull.Value))
                                {
                                    str6 = str6 + " and " + strArray[k] + " is null";
                                }
                                else
                                {
                                    str6 = str6 + " and " + strArray[k] + "=" + obj2.ToString();
                                }
                            }
                        }
                        if (definitionExpression == "")
                        {
                            filter.WhereClause = str6.Substring(5);
                        }
                        else
                        {
                            filter.WhereClause = str6;
                        }
                        IFeatureCursor o = featureClass.Search(filter, false);
                        IFeature feature = o.NextFeature();
                        while (feature != null)
                        {
                            if (feature.OID == pFeature.OID)
                            {
                                feature = o.NextFeature();
                            }
                            else
                            {
                                list.Add(str5);
                                break;
                            }
                        }
                        Marshal.ReleaseComObject(o);
                    }
                }
                string str11 = "";
                IObject obj3 = pFeature;
                IQueryFilter queryFilter = new QueryFilterClass();
                ICursor cursor2 = null;
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    DataRow row = dataTable.Rows[i];
                    string str9 = row["CHECK_FIELD"].ToString();
                    string str10 = row["CHECK_TYPE"].ToString();
                    string str12 = row["CHECK_RULE"].ToString();
                    string str13 = row["FIELD_ALIAS"] + row["ERROR_DESCRIP"].ToString();
                    if (str10.ToLower() == "unique")
                    {
                        for (int m = 0; m < list.Count; m++)
                        {
                            if (str9.Replace(" ", "") == list[m].ToString())
                            {
                                str11 = str11 + ",\r\n" + str13;
                            }
                        }
                    }
                    else if (str10.ToLower() == "incode")
                    {
                        int num7 = obj3.Fields.FindField(str9);
                        if (num7 >= 0)
                        {
                            object obj4 = obj3.get_Value(num7);
                            if ((obj4 != null) && (obj4.ToString() != ""))
                            {
                                string str14 = obj4.ToString();
                                IDomain domain = obj3.Fields.get_Field(num7).Domain;
                                if (domain != null)
                                {
                                    ICodedValueDomain domain2 = (ICodedValueDomain) domain;
                                    bool flag = false;
                                    for (int n = 0; n < domain2.CodeCount; n++)
                                    {
                                        if (domain2.get_Value(n).ToString() == str14)
                                        {
                                            flag = true;
                                        }
                                    }
                                    if (!flag)
                                    {
                                        str11 = str11 + ",\r\n" + str13;
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        int num4 = -1;
                        num4 = obj3.Fields.FindField(str9);
                        if (num4 >= 0)
                        {
                            obj3.Fields.get_Field(num4);
                            obj3.get_Value(num4);
                            bool flag1 = str10.ToLower() != "notnull";
                            queryFilter.WhereClause = string.Concat(new object[] { "(", str12, ") and ", obj3.Class.OIDFieldName, "=", obj3.OID });
                            cursor2 = obj3.Table.Search(queryFilter, false);
                            if ((cursor2 != null) && (cursor2.NextRow() != null))
                            {
                                str11 = str11 + ",\r\n" + str13;
                            }
                        }
                    }
                }
                if (str11 != "")
                {
                    str11 = str11.Substring(3);
                }
                return str11;
            }
            catch
            {
                return "";
            }
        }

        public static string CheckFeatureAttr2(IFeatureLayer pFLayer, IFeature pFeature)
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
            string oIDFieldName = featureClass.OIDFieldName;
            IDataset dataset = (IDataset) featureClass;
            string name = dataset.Name;
            string str3 = EditTask.KindCode.Substring(0, 2);
            string str4 = "T_Logic_Check";
            string sql = "select * from " + str4 + " where design_kind like '" + str3 + "%' and enabled=true order by CHECK_ID,ID";
          //  IDBAccess dBAccess = UtilFactory.GetDBAccess("Access");
            DataTable dataTable = null;// dBAccess.GetDataTable(dBAccess, sql);
            if ((dataTable == null) || (dataTable.Rows.Count < 1))
            {
                return "";
            }
            try
            {
                string str6 = "";
                string str7 = oIDFieldName + "=" + pFeature.OID;
                string str8 = "";
                string str9 = "";
                int count = dataTable.Rows.Count;
                for (int i = 0; i < count; i++)
                {
                    GC.Collect();
                    DataRow row = dataTable.Rows[i];
                    str8 = row["CHECK_FIELD"].ToString().Replace(" ", "");
                    str9 = row["CHECK_TYPE"].ToString();
                    string str10 = row["CHECK_RULE"].ToString();
                    string str11 = row["FIELD_ALIAS"] + row["ERROR_DESCRIP"].ToString();
                    string str12 = "";
                    if (str9.ToLower() == "unique")
                    {
                        str12 = "select " + oIDFieldName + " from " + name + " where (" + str8 + " in (select " + str8 + " from " + name + " group by " + str8 + " having count(*)>1))";
                        if (str7 != "")
                        {
                            str12 = str12 + " and (" + str7 + ")";
                        }
                    }
                    else if (str9.ToLower() == "incode")
                    {
                        string str13 = "T_SYS_META_CODE";
                        string text1 = "select " + oIDFieldName + " from " + name + " where (" + str8 + "<>'') and (" + str8 + " is not null) and (" + str8 + " not in (select CCODE from " + str13 + " where CTYPE='" + str10 + "'))";
                        if (str7 != "")
                        {
                            str12 = str12 + " and (" + str7 + ")";
                        }
                    }
                    else
                    {
                        str12 = "select " + oIDFieldName + " from " + name + " where (" + str10 + ")";
                        if (str7 != "")
                        {
                            str12 = str12 + " and (" + str7 + ")";
                        }
                    }
               //     IDBAccess pDBAccess = UtilFactory.GetDBAccess(UtilFactory.GetConfigOpt().GetConfigValue2("DataBase", "MapDBkey"));
                    DataTable table2 = null;// pDBAccess.GetDataTable(pDBAccess, str12);
                    if ((table2 != null) && (table2.Rows.Count >= 1))
                    {
                        for (int j = 0; j < table2.Rows.Count; j++)
                        {
                            str6 = str6 + "\r\n" + str11 + "。";
                        }
                    }
                }
                return str6;
            }
            catch (Exception)
            {
                return "";
            }
        }

        private static ArrayList CheckUnique(ArrayList pList, string sFieldName)
        {
            if (pList == null)
            {
                return null;
            }
            ArrayList list = new ArrayList();
            ArrayList list2 = new ArrayList();
            for (int i = 0; i < pList.Count; i++)
            {
                IObject pObj = pList[i] as IObject;
                object fieldValue = DataFuncs.GetFieldValue(pObj, sFieldName);
                if (list2.Contains(fieldValue))
                {
                    list.Add(fieldValue);
                }
                else
                {
                    list2.Add(fieldValue);
                }
            }
            return list;
        }
    }
}

