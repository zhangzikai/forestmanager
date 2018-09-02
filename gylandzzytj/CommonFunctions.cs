namespace gylandzzytj
{
    using Microsoft.Office.Interop.Excel;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.Diagnostics;
    using System.IO;
    using System.Reflection;
    using System.Windows.Forms;
    using Utilities;
    using td.db.orm;
    using td.logic.sys;
    using System.Data.SQLite;
    using ConSQLServerInfo;

    /// <summary>
    /// 命令的实现函数类：（主要处理导出查询的数据）
    /// </summary>
    internal class CommonFunctions
    {
        string sqlitepath = UtilFactory.GetConfigOpt().RootPath + "Data\\forest_142326_2016.db";
        public System.Data.SQLite.SQLiteConnection cnn;
        /// <summary>
        /// 导出数据至Excel文件
        /// </summary>
        /// <param name="srcPath"></param>
        /// <param name="destPath"></param>
        /// <param name="sheets"></param>
        /// <param name="tables"></param>
        /// <param name="starts"></param>
        /// <param name="cols"></param>
        /// <returns></returns>
        public static bool ExportDataToExcelFile(string srcPath, string destPath, List<string> sheets, List<System.Data.DataTable> tables, List<int> starts, List<int> cols)
        {
            try
            {
                File.Copy(srcPath, destPath, true);
                Microsoft.Office.Interop.Excel.Application application = new ApplicationClass();
                object updateLinks = Missing.Value;
                Workbook workbook = application.Workbooks.Open(destPath, updateLinks, updateLinks, updateLinks, updateLinks, updateLinks, updateLinks, updateLinks, updateLinks, updateLinks, updateLinks, updateLinks, updateLinks, updateLinks, updateLinks);
                int num = 0;
                foreach (string str in sheets)
                {
                    ExportGridToXlsUseTemp(tables[num], workbook, str, starts[num], cols[num]);
                    num++;
                }
                workbook.Save();
                application.Visible = true;
            }
            catch (Exception exception)
            {
                MessageBox.Show("统计过程中出现错误：" + exception.Message, "CommonFunctions::ExportDataToExcelFile", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                new Process();
                Process[] processesByName = Process.GetProcessesByName("Excel");
                try
                {
                    foreach (Process process in processesByName)
                    {
                        IntPtr mainWindowHandle = process.MainWindowHandle;
                        if (string.IsNullOrEmpty(process.MainWindowTitle))
                        {
                            process.Kill();
                        }
                    }
                }
                catch
                {
                }
                GC.Collect();
            }
            return true;
        }

        /// <summary>
        /// 导出Grid表格中的数据至使用的模板
        /// </summary>
        /// <param name="mydatatable"></param>
        /// <param name="workbook"></param>
        /// <param name="sheetName"></param>
        /// <param name="start"></param>
        /// <param name="col"></param>
        private static void ExportGridToXlsUseTemp(System.Data.DataTable mydatatable, Workbook workbook, string sheetName, int start, int col)
        {
            int count = mydatatable.Rows.Count;
            int num2 = mydatatable.Columns.Count;
            object[,] objArray = new object[count, num2];
            for (int i = 0; i < count; i++)
            {
                for (int j = 0; j < num2; j++)
                {
                    objArray[i, j] = mydatatable.Rows[i][j];
                }
            }
            Worksheet worksheet = workbook.Sheets[sheetName] as Worksheet;
            int num5 = worksheet.UsedRange.Rows.Count;
            object shift = Missing.Value;
            worksheet.get_Range(worksheet.Cells[start, 1], worksheet.Cells[num5 + start, col]).EntireRow.Delete(shift);
            int num6 = count + (start - 1);
            worksheet.get_Range(worksheet.Cells[start, 1], worksheet.Cells[num6, num2]).Value2 = objArray;
            worksheet.get_Range(worksheet.Cells[start, 1], worksheet.Cells[num6, num2]).Borders.LineStyle = 1;
        }

        public static bool ExportLDZZMonthDataToExcel(string srcPath, string destPath, string xlstitle, System.Data.DataTable mydatatable)
        {
            try
            {
                File.Copy(srcPath, destPath, true);
                int count = mydatatable.Rows.Count;
                int num2 = mydatatable.Columns.Count;
                object[,] objArray = new object[count, num2];
                for (int i = 0; i < count; i++)
                {
                    for (int j = 0; j < num2; j++)
                    {
                        objArray[i, j] = mydatatable.Rows[i][j];
                    }
                }
                Microsoft.Office.Interop.Excel.Application application = new ApplicationClass();
                object updateLinks = Missing.Value;
                Workbook workbook = application.Workbooks.Open(destPath, updateLinks, updateLinks, updateLinks, updateLinks, updateLinks, updateLinks, updateLinks, updateLinks, updateLinks, updateLinks, updateLinks, updateLinks, updateLinks, updateLinks);
                Worksheet worksheet = workbook.Sheets[1] as Worksheet;
                int num1 = worksheet.UsedRange.Rows.Count;
                worksheet.get_Range("A1", "A1").Value2 = xlstitle;
                worksheet.get_Range(worksheet.Cells[7, 1], worksheet.Cells[11, 9]).ClearContents();
                worksheet.get_Range(worksheet.Cells[7, 1], worksheet.Cells[11, 8]).Value2 = objArray;
                workbook.Save();
                application.Visible = true;
            }
            catch (Exception exception)
            {
                MessageBox.Show("导出Excel出错，错误：" + exception.Message, "CommonFunctions::ExportLDZZMonthDataToExcel", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                new Process();
                Process[] processesByName = Process.GetProcessesByName("Excel");
                try
                {
                    foreach (Process process in processesByName)
                    {
                        IntPtr mainWindowHandle = process.MainWindowHandle;
                        if (string.IsNullOrEmpty(process.MainWindowTitle))
                        {
                            process.Kill();
                        }
                    }
                }
                catch
                {
                }
                GC.Collect();
            }
            return true;
        }

        //public static string GetConnectionString()
        //{
        //    string connectionString = "";
        //    try
        //    {
        //        IDBAccess dBAccess = UtilFactory.GetDBAccess("SqlServer");
        //        if (dBAccess != null)
        //        {
        //            connectionString = dBAccess.ConnectionString;
        //        }
        //    }
        //    catch (Exception exception)
        //    {
        //        MessageBox.Show("创建数据库连接字符串时发生错误：" + exception.Message, "CommonFunctions::GetConnectionString", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        //    }
        //    return connectionString;
        //}

        public static List<string> GetCunList(SqlConnection con, string table, string xiang, string condition)
        {
            List<string> list = new List<string>();
            try
            {
                string str = "select distinct(CUN) from ";
                str = ((str + table + " where left(CUN, ") +  xiang.Length + ") = '") + xiang + "'";
                if (!string.IsNullOrEmpty(condition))
                {
                    str = str + " and " + condition;
                }
                SqlDataReader reader = new SqlCommand(str + " order by CUN asc", con).ExecuteReader();
                while (reader.Read())
                {
                    list.Add(reader.GetValue(0).ToString());
                }
                reader.Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show("从数据库中检索数据时发生错误：" + exception.Message, "CommonFunctions::GetXiangList", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            return list;
        }

        public static string[] GetDiLeiDm(SqlConnection con, string[] name)
        {
            string[] strArray = new string[name.Length];
            try
            {
                string str = "select CCODE from T_SYS_META_CODE where CTYPE = '地类' and ";
                string str2 = "";
                foreach (string str3 in name)
                {
                    if (!string.IsNullOrEmpty(str2))
                    {
                        str2 = str2 + " or ";
                    }
                    str2 = (str2 + " CNAME = '") + str3 + "'";
                }
                str2 = str2.Insert(0, "(") + ")";
                SqlDataReader reader = new SqlCommand(str + str2, con).ExecuteReader();
                int num = 0;
                while (reader.Read())
                {
                    strArray[num++] = reader.GetValue(0).ToString();
                }
                reader.Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show("从数据库中检索数据时发生错误：" + exception.Message, "ldzzy_stat::GetDiLeiDm", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            return strArray;
        }

        /// <summary>
        /// 获取数据库中表
        /// </summary>
        /// <param name="cmdtxt"></param>
        /// <param name="tablename"></param>
        /// <returns></returns>
        public System.Data.DataTable GetTableInDB(string cmdtxt, string tablename)
        {
            System.Data.DataTable table2;
            ///连接的是SQLite数据库，而此处是对SQLServer的操作，因此报错
            ////cnn = new System.Data.SQLite.SQLiteConnection();
            ////cnn.ConnectionString = @"Data Source=" + sqlitepath + ";Version=3;";
            ////cnn.Open();

            ///SQLServer连接//SQLServer连接有误，缺少密码
            ////string connString = DBServiceFactory<MetaDataManager>.Service.ConnectionString;
            ////string connString = "Data Source=114.215.140.122;Initial Catalog=sde;User ID=sde;Password=sde;Persist Security Info=false;";
            string connString = ConnectionSQLServerString.Get_M_Str_ConnectionString();
            SqlConnection selectConnection = new SqlConnection(connString);
            System.Data.DataTable dataTable = null;
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter(cmdtxt, selectConnection);///SQLServer
                ////SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmdtxt,cnn);///SQLite

                dataTable = new System.Data.DataTable(tablename);
                adapter.Fill(dataTable);
                table2 = dataTable;
            }
            catch (Exception exception)
            {
                MessageBox.Show("错误：" + exception.Message, "错误提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Hand);
                table2 = null;
            }
            finally
            {
                if ((selectConnection != null) && (selectConnection.State == ConnectionState.Open))
                {
                    selectConnection.Close();
                    selectConnection.Dispose();
                }
            }
            return table2;
        }

        public static List<string> GetXiangList(SqlConnection con, string table, string xian, string conditon)
        {
            List<string> list = new List<string>();
            try
            {
                string str = "select distinct(XIANG) from ";
                str = ((str + table + " where left(XIANG, ") + xian.Length + ") = '") + xian + "'";
                if (!string.IsNullOrEmpty(conditon))
                {
                    str = str + " and " + conditon;
                }
                SqlDataReader reader = new SqlCommand(str + " order by XIANG asc", con).ExecuteReader();
                while (reader.Read())
                {
                    list.Add(reader.GetValue(0).ToString());
                }
                reader.Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show("从数据库中检索数据时发生错误：" + exception.Message, "CommonFunctions::GetXiangList", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            return list;
        }

        public static List<string> GetXianList(SqlConnection con, string table, string condition)
        {
            List<string> list = new List<string>();
            try
            {
                string str = "select distinct(XIAN) from ";
                str = str + table;
                if (!string.IsNullOrEmpty(condition))
                {
                    str = str + " where " + condition;
                }
                SqlDataReader reader = new SqlCommand(str + " order by XIAN asc", con).ExecuteReader();
                while (reader.Read())
                {
                    list.Add(reader.GetValue(0).ToString());
                }
                reader.Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show("从数据库中检索数据时发生错误：" + exception.Message, "CommonFunctions::GetXianList", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            return list;
        }
    }
}

