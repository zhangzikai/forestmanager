namespace OperateLog
{
    using System;
    using System.Data;
    using System.Data.Common;
    using Utilities;

    public class LogOperate
    {
        private IDBAccess m_Accesser;
        private string m_DBKey = "";
        private string m_TableName = "T_LOG";

        public LogOperate()
        {
            string sDBKey = UtilFactory.GetConfigOpt().GetConfigValue2("DataBase", "DBKey");
            this.m_Accesser = UtilFactory.GetDBAccess(sDBKey);
            this.m_DBKey = sDBKey;
        }
        /*
       public bool ClearLog()
       {
           if (this.m_Accesser == null)
           {
               return false;
           }
           string sCmdText = "";
           sCmdText = "delete from " + this.m_TableName;
           if (this.m_Accesser.ExecuteNonQuery(sCmdText) < 0)
           {
               return false;
           }
           return true;
       }
       
       public bool DeleteLog(DateTime pStartTime, DateTime pEndTime, string sType, string sSystemType)
       {
           if (this.m_Accesser == null)
           {
               return false;
           }
           try
           {
               string str = "";
               str = "where ";
               if (this.m_DBKey.ToLower() == "sqlserver")
               {
                   string str3 = str;
                   str = str3 + "log_time>='" + pStartTime.ToString("yyyy-MM-dd HH:mm:ss") + "' and log_time<'" + pEndTime.ToString("yyyy-MM-dd HH:mm:ss") + "'";
               }
               else
               {
                   object obj2 = str;
                   str = string.Concat(new object[] { obj2, "log_time>=#", pStartTime, "# and log_time<#", pEndTime, "#" });
               }
               if (sSystemType != "")
               {
                   str = str + " and system='" + sSystemType + "'";
               }
               if (sType != "")
               {
                   str = str + " and operate='" + sType + "'";
               }
               string sCmdText = "";
               sCmdText = "delete from " + this.m_TableName + " " + str;
               if (this.m_Accesser.ExecuteNonQuery(sCmdText) < 0)
               {
                   return false;
               }
               return true;
           }
           catch
           {
               return false;
           }
       }
         */
        /*
        public bool DeleteSingleLog(string sLogID)
        {
            if (this.m_Accesser == null)
            {
                return false;
            }
            string sCmdText = "";
            sCmdText = "delete from " + this.m_TableName + " where ID=" + sLogID;
            if (this.m_Accesser.ExecuteNonQuery(sCmdText) < 0)
            {
                return false;
            }
            return true;
        }
        */
        //private DataTable GetDataTable(IDBAccess pAccesser, string sSql)
        //{
        //    if (pAccesser == null)
        //    {
        //        return null;
        //    }
        //    try
        //    {
        //        DbDataAdapter dBDataAdapter = pAccesser.GetDBDataAdapter(sSql, false);
        //        DataSet dataSet = new DataSet();
        //        dBDataAdapter.Fill(dataSet);
        //        if (dataSet == null)
        //        {
        //            return null;
        //        }
        //        if (dataSet.Tables.Count < 1)
        //        {
        //            return null;
        //        }
        //        return dataSet.Tables[0];
        //    }
        //    catch
        //    {
        //        return null;
        //    }
        //}
        /*
        public DataTable GetLogs(DateTime pStartTime, DateTime pEndTime, string sType, string sSystem)
        {
            if (this.m_Accesser == null)
            {
                return null;
            }
            try
            {
                string str = "";
                str = "where ";
                if (this.m_DBKey.ToLower() == "sqlserver")
                {
                    string str3 = str;
                    str = str3 + "log_time>='" + pStartTime.ToString("yyyy-MM-dd HH:mm:ss") + "' and log_time<'" + pEndTime.ToString("yyyy-MM-dd HH:mm:ss") + "'";
                }
                else
                {
                    object obj2 = str;
                    str = string.Concat(new object[] { obj2, "log_time>=#", pStartTime, "# and log_time<#", pEndTime, "#" });
                }
                if (sSystem != "")
                {
                    str = str + " and system='" + sSystem + "'";
                }
                if (sType != "")
                {
                    str = str + " and operate='" + sType + "'";
                }
                string sSql = "";
                sSql = ("select id,user_name as 用户,operate as 操作,log_time as 时间,remark as 备注 from " + this.m_TableName) + " " + str + " order by log_time desc";
                return this.GetDataTable(this.m_Accesser, sSql);
            }
            catch
            {
                return null;
            }
        }*/

        //public DataTable GetOperateType()
        //{
        //    if (this.m_Accesser == null)
        //    {
        //        return null;
        //    }
        //    string sSql = "";
        //    sSql = "select distinct operate from " + this.m_TableName;
        //    return this.GetDataTable(this.m_Accesser, sSql);
        //}
        /*
        public bool LogWriter(string sUser, string sOperate, string sRemark, string sSystem)
        {
            if (this.m_Accesser == null)
            {
                return false;
            }
            try
            {
                DateTime now = DateTime.Now;
                string sCmdText = "insert into " + this.m_TableName + "(user_name,operate,log_time,remark,system) values('" + sUser + "','" + sOperate + "','" + now.ToString("yyyy-MM-dd HH:mm:ss") + "','" + sRemark + "','" + sSystem + "')";
                if (this.m_Accesser.ExecuteNonQuery(sCmdText) < 0)
                {
                    return false;
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
         */
    }
}

