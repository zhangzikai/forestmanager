namespace Report
{
    using System;
    using System.Data;
    using System.Data.OleDb;
    using Utilities;

    internal class ReportInit
    {
        public static string Init(ReportParamter pReportParamter)
        {
          //  string sDBKey = UtilFactory.GetConfigOpt().GetConfigValue2("DataBase", "DBKey");
           // IDBAccess dBAccess = UtilFactory.GetDBAccess(sDBKey);
            //DataTable dataTable = null; //dBAccess.GetDataTable(dBAccess, "select DataTable,TableSql,StoredProcedure,StoredProcedureSql,UseStoredProcedure from T_STAT_REPORT where theme='" + pReportParamter.Theme.ToString() + "'");
            //dBAccess.ExecuteNonQuery("update T_STAT_REPORT set isshow=1 where theme='CF' and reportid=3");
            string year = UtilFactory.GetConfigOpt().GetConfigValue("EditYear");
            //string year = DateTime.Now.Year.ToString();
            //try
            //{
            //    if (dataTable == null)
            //    {
            //        return year;
            //    }
            //    object obj2 = null;
            //    foreach (DataRow row in dataTable.Rows)
            //    {
            //        obj2 = row["UseStoredProcedure"];
            //        if ((obj2 != null) && (obj2.ToString() != "0"))
            //        {
            //            object obj3 = null;
            //            obj2 = row["TableSql"];
            //            if ((obj2 != null) && (obj2.ToString().Trim() != ""))
            //            {
            //                if (sDBKey.ToLower() == "access")
            //                {
            //                    obj3 = "0";
            //                    object[] restrictions = new object[4];
            //                    restrictions[3] = "TABLE";
            //                    DataTable oleDbSchemaTable = ((OleDbConnection) dBAccess.Connection).GetOleDbSchemaTable(OleDbSchemaGuid.Tables, restrictions);
            //                    for (int i = 0; i < oleDbSchemaTable.Rows.Count; i++)
            //                    {
            //                        if (oleDbSchemaTable.Rows[i].ItemArray[2].ToString() == row["DataTable"].ToString().Replace(" ", ""))
            //                        {
            //                            obj3 = "1";
            //                            break;
            //                        }
            //                    }
            //                }
            //                else
            //                {
            //                    obj3 = dBAccess.ExecuteScalar("select count(*) from sysobjects where id = object_id('" + row["DataTable"].ToString() + "')");
            //                }
            //                if ((obj3 != null) && (int.Parse(obj3.ToString()) == 0))
            //                {
            //                    dBAccess.ExecuteNonQuery(obj2.ToString());
            //                }
            //            }
            //            if (sDBKey.ToLower() != "access")
            //            {
            //                obj2 = row["StoredProcedureSql"];
            //                if ((obj2 != null) && (obj2.ToString().Trim() != ""))
            //                {
            //                    if (sDBKey.ToLower() == "access")
            //                    {
            //                        obj3 = "0";
            //                        DataTable table3 = ((OleDbConnection) dBAccess.Connection).GetOleDbSchemaTable(OleDbSchemaGuid.Procedures, new object[4]);
            //                        for (int j = 0; j < table3.Rows.Count; j++)
            //                        {
            //                            if (table3.Rows[j].ItemArray[2].ToString() == row["StoredProcedure"].ToString())
            //                            {
            //                                obj3 = "1";
            //                                break;
            //                            }
            //                        }
            //                    }
            //                    else
            //                    {
            //                        obj3 = dBAccess.ExecuteScalar("select count(*) from sysobjects where id = object_id('" + row["StoredProcedure"].ToString() + "')");
            //                    }
            //                    if ((obj3 != null) && (int.Parse(obj3.ToString()) == 0))
            //                    {
            //                        dBAccess.ExecuteNonQuery(obj2.ToString());
            //                    }
            //                }
            //            }
            //        }
            //    }
            //    if (pReportParamter.SysType == SystemType.ZYGL)
            //    {
            //        obj2 = dBAccess.ExecuteScalar("select dbname = case when dbid = 0 then null when dbid <> 0 then db_name(dbid) end from master..sysprocesses where spid=@@spid");
            //        if (obj2 != null)
            //        {
            //            string str3 = obj2.ToString();
            //            string str4 = str3.Substring(str3.Length - 4);
            //            year = str4;
            //            if (dBAccess.ExecuteNonQuery("update T_STAT_REPORT set reportyear='" + str4 + "'") <= 0)
            //            {
            //                year = "0";
            //            }
            //        }
            //        return year;
            //    }
            //    year = pReportParamter.Year;
            //    if (dBAccess.ExecuteNonQuery("update T_STAT_REPORT set reportyear='" + pReportParamter.Year + "'") <= 0)
            //    {
            //        year = "0";
            //    }
            //}
            //catch
            //{
            //    year = "0";
            //}
            return year;
        }
    }
}

