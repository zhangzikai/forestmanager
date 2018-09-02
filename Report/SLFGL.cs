namespace Report
{
    using Properties;
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using Utilities;

    public class SLFGL
    {
        private const string _mClassName = "Report.SLFGL";
        private string _mSubSysName = UtilFactory.GetConfigOpt().GetSystemName();
        private ErrorOpt mErrOpt = UtilFactory.GetErrorOpt();

        public DataTable Static(string pYear)
        {
            try
            {
                return null;
            //    IDBAccess dBAccess = UtilFactory.GetDBAccess("SqlServer");
            //    if (dBAccess.GetDataTable(dBAccess, "SELECT COUNT(1) FROM dbo.sysobjects WHERE ID = object_id('SLFGL')").Rows[0][0].ToString() == "1")
            //    {
            //        dBAccess.ExecuteNonQuery("DROP PROCEDURE SLFGL");
            //    }
            //    dBAccess.ExecuteNonQuery(Resources.SLFGL);
            //    IDbCommand command = dBAccess.Connection.CreateCommand();
            //    command.CommandText = "SLFGL";
            //    command.CommandType = CommandType.StoredProcedure;
            //    int num = int.Parse(pYear) - 1;
            //    SqlParameter parameter = new SqlParameter("@SNTABLENAME", "FOR_XIAOBAN_" + num);
            //    command.Parameters.Add(parameter);
            //    SqlParameter parameter2 = new SqlParameter("@BNTABLENAME", "FOR_XIAOBAN_" + pYear);
            //    command.Parameters.Add(parameter2);
            //    command.ExecuteNonQuery();
            //    return dBAccess.GetDataTable(dBAccess, "SELECT [XIANGNAME],[DILEINAME],SUM([SQDLMJ]),SUM([SQSLFGL]),SUM([ZJHJ]),SUM([YLDZL]),SUM([JDGX]),SUM([WCLDZH]),SUM([NDZL]),SUM([SPZS]),SUM([ZJQT]),SUM([JSHJ]),SUM([JFGZ]),SUM([HZCZ]),SUM([DFLF]),SUM([ZYZSLD]),SUM([KFSPS]),SUM([JSQT]),SUM([BNDLMJ]),SUM([BNSLFGL]),SUM([SLFGLZJ])  FROM [T_STAT_SLFGL] GROUP BY [XIANG],[XIANGNAME],[DILEI],[DILEINAME] ORDER BY CASE WHEN [XIANG] IS NULL THEN '9999999999' ELSE [XIANG] END,CASE WHEN [DILEI] IS NULL THEN '99999' ELSE DILEI END");
            //
            }
            catch (Exception exception)
            {
                this.mErrOpt.ErrorOperate(this._mSubSysName, "Report.SLFGL", "StaticExcute", exception.GetHashCode().ToString(), exception.Source, exception.Message, "", "", "");
            }
            return null;
        }
    }
}

