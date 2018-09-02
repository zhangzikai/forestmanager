namespace OperateLog
{
    using System;
    using System.Data;
    using System.Runtime.InteropServices;
    using System.Security.Cryptography;
    using System.Text;
    using Utilities;

    /// <summary>
    /// 用户管理类（主要用于登录）
    /// </summary>
    public class UserManage
    {
        public static string GetMD5Hash(string str)
        {
            MD5CryptoServiceProvider provider = new MD5CryptoServiceProvider();
            return BitConverter.ToString(provider.ComputeHash(Encoding.UTF8.GetBytes(str))).Replace("-", "");
        }
        

        /// <summary>
        /// 以下源代码被注销了
        /// </summary>
        /// <param name="sUserName"></param>
        /// <param name="sPasswrd"></param>
        /// <param name="sKind"></param>
        /// <param name="sResponse"></param>
        /// <returns></returns>
        //public static bool Login(string sUserName, string sPasswrd, string sKind, out string sResponse)
        //{
        //    sResponse = "";
        //    if (sUserName == "")
        //    {
        //        sResponse = "请输入用户名!";
        //        return false;
        //    }
        //    try
        //    {
        //        IDBAccess pDBAccess = null;
        //        pDBAccess = UtilFactory.GetDBAccess(UtilFactory.GetConfigOpt().GetConfigValue2("DataBase", "DBKey"));
        //        string sql = "";
        //        string str3 = "T_SYS_FLOW_USER";
        //        string str4 = "T_SYS_FLOW_AUTHOR";
        //        string str5 = "T_SYS_USER_AUTHOR";
        //        sql = "select USER_ID,USER_PASSWORD from " + str3 + " where USER_NAME='" + sUserName + "'";
        //        DataTable dataTable = pDBAccess.GetDataTable(pDBAccess, sql);
        //        if ((dataTable == null) || (dataTable.Rows.Count < 1))
        //        {
        //            sResponse = "此用户名不存在!";
        //            return false;
        //        }
        //        if (dataTable.Rows[0]["USER_PASSWORD"].ToString() != sPasswrd)
        //        {
        //            sResponse = "密码错误!";
        //            return false;
        //        }
        //        string str7 = dataTable.Rows[0]["USER_ID"].ToString();
        //        sql = "select t1.AUTHOR_NAME,t1.SYSTEM_ZT from " + str4 + " t1," + str5 + " t2 where t2.USER_ID=" + str7 + " and t1.AUTHOR_ID=t2.AUTHOR_ID";
        //        dataTable = pDBAccess.GetDataTable(pDBAccess, sql);
        //        if ((dataTable == null) || (dataTable.Rows.Count < 1))
        //        {
        //            sResponse = "用户没有进入所选系统的权限!";
        //            return false;
        //        }
        //        bool flag = false;
        //        bool flag2 = false;
        //        for (int i = 0; i < dataTable.Rows.Count; i++)
        //        {
        //            if (dataTable.Rows[i]["SYSTEM_ZT"].ToString() == sKind)
        //            {
        //                flag = true;
        //            }
        //            if (dataTable.Rows[i]["SYSTEM_ZT"].ToString() == "系统管理")
        //            {
        //                flag2 = true;
        //            }
        //        }
        //        if (!flag)
        //        {
        //            sResponse = "用户没有进入所选系统的权限!";
        //            return false;
        //        }
        //        UserInfo.UserID = str7;
        //        UserInfo.UserName = sUserName;
        //        UserInfo.IsManager = flag2;
        //        LogType.SystemType = sKind;
        //        new LogOperate().LogWriter(UserInfo.UserName, "登录系统", sKind, LogType.SystemType);
        //        return true;
        //    }
        //    catch
        //    {
        //        sResponse = "登录系统出错!";
        //        return false;
        //    }
        //}

        /// <summary>
        /// 以下源代码被注销
        /// </summary>
        /// <param name="sUserName"></param>
        /// <param name="sPasswrd"></param>
        /// <param name="sResponse"></param>
        /// <returns></returns>
        //public static string Login2(string sUserName, string sPasswrd, out string sResponse)
        //{
        //    sResponse = "";
        //    if (sUserName == "")
        //    {
        //        sResponse = "请输入用户名!";
        //        return "";
        //    }
        //    try
        //    {
        //        IDBAccess pDBAccess = null;
        //        pDBAccess = UtilFactory.GetDBAccess(UtilFactory.GetConfigOpt().GetConfigValue2("DataBase", "DBKey"));
        //        string sql = "";
        //        string str3 = "T_SYS_FLOW_USER";
        //        string str4 = "T_SYS_FLOW_AUTHOR";
        //        string str5 = "T_SYS_USER_AUTHOR";
        //        sql = "select USER_ID,USER_PASSWORD from " + str3 + " where USER_NAME='" + sUserName + "'";
        //        DataTable dataTable = pDBAccess.GetDataTable(pDBAccess, sql);
        //        if ((dataTable == null) || (dataTable.Rows.Count < 1))
        //        {
        //            sResponse = "此用户名不存在!";
        //            return "";
        //        }
        //        if (dataTable.Rows[0]["USER_PASSWORD"].ToString() != sPasswrd)
        //        {
        //            sResponse = "密码错误!";
        //            return "";
        //        }
        //        string str7 = dataTable.Rows[0]["USER_ID"].ToString();
        //        sql = "select t1.AUTHOR_NAME,t1.SYSTEM_ZT from " + str4 + " t1," + str5 + " t2 where t2.USER_ID=" + str7 + " and t1.AUTHOR_ID=t2.AUTHOR_ID";
        //        dataTable = pDBAccess.GetDataTable(pDBAccess, sql);
        //        if ((dataTable == null) || (dataTable.Rows.Count < 1))
        //        {
        //            sResponse = "用户没有进入所选系统的权限!";
        //            return "";
        //        }
        //        bool flag = false;
        //        string str8 = "";
        //        for (int i = 0; i < dataTable.Rows.Count; i++)
        //        {
        //            DataRow row = dataTable.Rows[i];
        //            if (str8 == "")
        //            {
        //                str8 = row["SYSTEM_ZT"].ToString();
        //            }
        //            else
        //            {
        //                str8 = str8 + "," + row["SYSTEM_ZT"].ToString();
        //            }
        //        }
        //        if (str8 == "")
        //        {
        //            sResponse = "用户没有进入所选系统的权限!";
        //            return "";
        //        }
        //        UserInfo.UserID = str7;
        //        UserInfo.UserName = sUserName;
        //        UserInfo.IsManager = flag;
        //        return str8;
        //    }
        //    catch
        //    {
        //        sResponse = "登录系统出错!";
        //        return "";
        //    }
        //}       
    }
}

