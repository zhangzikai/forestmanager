namespace Utilities
{
    using System;
    using System.Data;
    using System.Windows.Forms;

    public class DBOpt
    {
        private const string mClassName = "Utilities.DBOpt";

        internal DBOpt()
        {
        }

        //public string GetDepartName(IDBAccess pDBAccess, string sDepartID)
        //{
        //    try
        //    {
        //        if (pDBAccess == null)
        //        {
        //            return "";
        //        }
        //        if (!pDBAccess.Enabled)
        //        {
        //            return "";
        //        }
        //        if (string.IsNullOrEmpty(sDepartID))
        //        {
        //            return "";
        //        }
        //        object obj2 = null;
        //        obj2 = pDBAccess.ExecuteScalar("SELECT department_name FROM t_department WHERE department_id = '" + sDepartID + "'");
        //        if (obj2 == null)
        //        {
        //            return "";
        //        }
        //        return (string) obj2;
        //    }
        //    catch (Exception exception)
        //    {
        //        MessageBox.Show(exception.Message, "Utilities.DBOpt\n错误出处 : Function GetDepartName\n错误来源 : " + exception.Source + "\n错误描述 : " + exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        //        return null;
        //    }
        //}

        //public int GetMaxID(IDBAccess pDBAccess, string sIDType)
        //{
        //    try
        //    {
        //        if (pDBAccess == null)
        //        {
        //            return 0;
        //        }
        //        if (string.IsNullOrEmpty(sIDType))
        //        {
        //            return 0;
        //        }
        //        string sCmdText = null;
        //        object obj2 = null;
        //        int num = 0;
        //        if (pDBAccess.DBMS == "Oracle")
        //        {
        //            sCmdText = "SELECT SEQ_" + sIDType.ToUpper() + ".NEXTVAL FROM DUAL";
        //            obj2 = pDBAccess.ExecuteScalar(sCmdText);
        //            if (obj2 != null)
        //            {
        //                num = (int)obj2;
        //                if (num < 0)
        //                {
        //                    num = 0;
        //                }
        //            }
        //            if (num > 0)
        //            {
        //                return num;
        //            }
        //        }
        //        sCmdText = "SELECT max_id FROM sys_max_id WHERE max_type='" + sIDType.ToUpper() + "'";
        //        obj2 = pDBAccess.ExecuteScalar(sCmdText);
        //        if (obj2 == null)
        //        {
        //            num = 0;
        //        }
        //        else
        //        {
        //            num = (int)obj2;
        //        }
        //        if (num < 0)
        //        {
        //            num = 0;
        //        }
        //        num++;
        //        sCmdText = "UPDATE sys_max_id SET max_id = " + num.ToString() + " WHERE max_type='" + sIDType.ToUpper() + "'";
        //        pDBAccess.ExecuteNonQuery(sCmdText);
        //        return num;
        //    }
        //    catch (Exception exception)
        //    {
        //        MessageBox.Show(exception.Message, "Utilities.DBOpt\n错误出处 : Function GetMaxID\n错误来源 : " + exception.Source + "\n错误描述 : " + exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        //        return -1;
        //    }
        //}

        //public string GetRandName(IDBAccess pDBAccess, int iRandID)
        //{
        //    try
        //    {
        //        if (pDBAccess == null)
        //        {
        //            return "";
        //        }
        //        if (!pDBAccess.Enabled)
        //        {
        //            return "";
        //        }
        //        if (iRandID < 0)
        //        {
        //            return "";
        //        }
        //        object obj2 = null;
        //        obj2 = pDBAccess.ExecuteScalar("SELECT rand_name FROM sys_rand WHERE rand_id = " + iRandID.ToString());
        //        if (obj2 == null)
        //        {
        //            return "";
        //        }
        //        return (string)obj2;
        //    }
        //    catch (Exception exception)
        //    {
        //        MessageBox.Show(exception.Message, "Utilities.DBOpt\n错误出处 : Function GetRandName\n错误来源 : " + exception.Source + "\n错误描述 : " + exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        //        return null;
        //    }
        //}

        //public DateTime GetSysDate(IDBAccess pDBAccess)
        //{
        //    try
        //    {
        //        if (pDBAccess == null)
        //        {
        //            return DateTime.Now;
        //        }
        //        string sCmdText = null;
        //        object obj2 = null;
        //        DateTime now = new DateTime();
        //        if (pDBAccess.DBMS == "Oracle")
        //        {
        //            sCmdText = "SELECT sysdate FROM DUAL";
        //            obj2 = pDBAccess.ExecuteScalar(sCmdText);
        //            if (obj2 == null)
        //            {
        //                return DateTime.Now;
        //            }
        //            now = (DateTime) obj2;
        //        }
        //        else if (pDBAccess.DBMS == "SqlServer")
        //        {
        //            now = DateTime.Now;
        //        }
        //        else
        //        {
        //            now = DateTime.Now;
        //        }
        //        return now;
        //    }
        //    catch (Exception exception)
        //    {
        //        MessageBox.Show(exception.Message, "Utilities.DBOpt\n错误出处 : Function GetSysDate\n错误来源 : " + exception.Source + "\n错误描述 : " + exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        //        return DateTime.Now;
        //    }
        //}

        public DataRow[] SearchTableAllRow(DataTable pDataTable, string sFilterExp)
        {
            try
            {
                if (pDataTable == null)
                {
                    return null;
                }
                if (pDataTable.Rows == null)
                {
                    return null;
                }
                DataRow[] rowArray = null;
                rowArray = pDataTable.Select(sFilterExp);
                if (rowArray == null)
                {
                    return null;
                }
                if (rowArray.Length <= 0)
                {
                    return null;
                }
                return rowArray;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Utilities.DBOpt\n错误出处 : Function SearchTableAllRow\n错误来源 : " + exception.Source + "\n错误描述 : " + exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
            }
        }

        public DataRow SearchTableOneRow(DataTable pDataTable, string sFilterExp)
        {
            try
            {
                if (pDataTable == null)
                {
                    return null;
                }
                if (pDataTable.Rows == null)
                {
                    return null;
                }
                DataRow[] rowArray = null;
                rowArray = pDataTable.Select(sFilterExp);
                if (rowArray == null)
                {
                    return null;
                }
                if (rowArray.Length <= 0)
                {
                    return null;
                }
                return rowArray[0];
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Utilities.DBOpt\n错误出处 : Function SearchTableOneRow\n错误来源 : " + exception.Source + "\n错误描述 : " + exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
            }
        }
    }
}

