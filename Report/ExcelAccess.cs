namespace Report
{
    using Microsoft.Office.Interop.Excel;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.OleDb;
    using System.Diagnostics;
    using System.Reflection;
    using System.Runtime.InteropServices;
    using System.Text;

    /// <summary>
    /// 数据库的报表
    /// </summary>
    public class ExcelAccess
    {
        private OleDbConnectionStringBuilder _builder = new OleDbConnectionStringBuilder();
        private string _dataSource;
        private bool _isHeading;

        /// <summary>
        /// 数据库的报表:构造器
        /// </summary>
        /// <param name="pDataSource"></param>
        /// <param name="pIsHead"></param>
        public ExcelAccess(string pDataSource, bool pIsHead)
        {
            this._builder["Provider"] = "Microsoft.ACE.OLEDB.12.0";
            this._builder["Data Source"] = pDataSource;
            if (pIsHead)
            {
                this._builder["Extended Properties"] = "Excel 12.0;HDR=YES";
            }
            else
            {
                this._builder["Extended Properties"] = "Excel 12.0;HDR=NO";
            }
        }

        public System.Data.DataTable GetDataTable(string pSql)
        {
            OleDbConnection connection = new OleDbConnection(this._builder.ConnectionString);
            OleDbDataAdapter adapter = new OleDbDataAdapter(pSql, this._builder.ConnectionString);
            System.Data.DataTable dataTable = new System.Data.DataTable();
            try
            {
                connection.Open();
                adapter.Fill(dataTable);
            }
            catch (Exception)
            {
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
            return dataTable;
        }

        public System.Data.DataTable GetExcelAllTableContentsApp()
        {
            Application application = new ApplicationClass();
            Workbook workbook = application.Workbooks.Open(this._builder.DataSource, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
            if (workbook.Worksheets.Count == 0)
            {
                workbook = null;
                if (application != null)
                {
                    application.Workbooks.Close();
                    application.Quit();
                    int generation = GC.GetGeneration(application);
                    Marshal.ReleaseComObject(application);
                    application = null;
                    GC.Collect(generation);
                }
                GC.Collect();
                Process[] processesByName = Process.GetProcessesByName("EXCEL");
                DateTime startTime = new DateTime();
                int index = 0;
                for (int i = 0; i < processesByName.Length; i++)
                {
                    if (startTime < processesByName[i].StartTime)
                    {
                        startTime = processesByName[i].StartTime;
                        index = i;
                    }
                }
                if (!processesByName[index].HasExited)
                {
                    processesByName[index].Kill();
                }
                return null;
            }
            OleDbConnection connection = new OleDbConnection(this._builder.ConnectionString);
            System.Data.DataTable dataTable = new System.Data.DataTable();
            try
            {
                connection.Open();
                if (connection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null).Rows.Count == 0)
                {
                    return null;
                }
                StringBuilder builder = new StringBuilder();
                for (int j = 1; j <= workbook.Worksheets.Count; j++)
                {
                    Worksheet worksheet = (Worksheet) workbook.Worksheets[j];
                    Microsoft.Office.Interop.Excel.Range usedRange = worksheet.UsedRange;
                    if (usedRange.Rows.Count > 1)
                    {
                        builder.Append("select ");
                        for (int k = 1; k <= usedRange.Columns.Count; k++)
                        {
                            object obj2 = (worksheet.Cells[1, k] as Microsoft.Office.Interop.Excel.Range).Value2;
                            if (obj2 != null)
                            {
                                builder.Append("[");
                                builder.Append(obj2.ToString());
                                builder.Append("]");
                                builder.Append(",");
                            }
                        }
                        builder.Remove(builder.Length - 1, 1);
                        builder.Append(" from ");
                        builder.Append("[");
                        builder.Append(worksheet.Name);
                        builder.Append("$]");
                        builder.Append(" union all ");
                    }
                }
                builder.Remove(builder.Length - 11, 11);
                new OleDbDataAdapter(builder.ToString(), this._builder.ConnectionString).Fill(dataTable);
            }
            catch (Exception)
            {
            }
            finally
            {
                workbook = null;
                if (application != null)
                {
                    application.Workbooks.Close();
                    application.Quit();
                    int num6 = GC.GetGeneration(application);
                    Marshal.ReleaseComObject(application);
                    application = null;
                    GC.Collect(num6);
                }
                GC.Collect();
                KillExcelEx();
                connection.Close();
                connection.Dispose();
            }
            return dataTable;
        }

        public System.Data.DataTable GetExcelAllTableContentsSql()
        {
            OleDbConnection connection = new OleDbConnection(this._builder.ConnectionString);
            System.Data.DataTable oleDbSchemaTable = null;
            try
            {
                connection.Open();
                object[] restrictions = new object[4];
                restrictions[3] = "TABLE";
                oleDbSchemaTable = connection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, restrictions);
                if (oleDbSchemaTable.Rows.Count == 0)
                {
                    return oleDbSchemaTable;
                }
                StringBuilder builder = new StringBuilder();
                List<string> list = new List<string>();
                List<string> list2 = new List<string>();
                List<string> list3 = new List<string>();
                foreach (DataRow row in oleDbSchemaTable.Rows)
                {
                    string item = row["Table_Name"].ToString();
                    if ((item.EndsWith("$'") && item.StartsWith("'")) || item.EndsWith("$"))
                    {
                        list3.Add(item);
                    }
                }
                if (list3.Count == 0)
                {
                    return null;
                }
                object[] objArray2 = new object[4];
                objArray2[2] = list3[0];
                foreach (DataRow row2 in connection.GetOleDbSchemaTable(OleDbSchemaGuid.Columns, objArray2).Select(null, "ORDINAL_POSITION ASC"))
                {
                    string str2 = row2["Column_Name"].ToString();
                    list.Add(str2);
                }
                List<string> list4 = new List<string>();
                for (int i = 1; i < list3.Count; i++)
                {
                    object[] objArray3 = new object[4];
                    objArray3[2] = list3[i];
                    foreach (DataRow row3 in connection.GetOleDbSchemaTable(OleDbSchemaGuid.Columns, objArray3).Select(null, "ORDINAL_POSITION ASC"))
                    {
                        string str3 = row3["Column_Name"].ToString();
                        if (list.Contains(str3))
                        {
                            list2.Add(str3);
                        }
                    }
                    if (list2.Count == 0)
                    {
                        list4.Add(list3[i]);
                    }
                    else
                    {
                        list = list2;
                        list2 = new List<string>();
                    }
                }
                foreach (string str4 in list4)
                {
                    list3.Remove(str4);
                }
                foreach (string str5 in list3)
                {
                    string str6 = str5;
                    if (str5.EndsWith("$"))
                    {
                        str6 = str5.Insert(0, "[");
                        str6 = str6.Insert(str6.Length, "]");
                    }
                    else
                    {
                        str6 = str5.Remove(0, 1);
                        str6 = str6.Remove(str6.Length - 1, 1).Insert(0, "[").Insert(str5.Length - 1, "]");
                    }
                    builder.Append("select ");
                    foreach (string str7 in list)
                    {
                        builder.Append("[");
                        builder.Append(str7);
                        builder.Append("]");
                        builder.Append(",");
                    }
                    builder.Remove(builder.Length - 1, 1);
                    builder.Append(" from ");
                    builder.Append(str6);
                    builder.Append(" union all ");
                }
                builder.Remove(builder.Length - 11, 11);
                OleDbDataAdapter adapter = new OleDbDataAdapter(builder.ToString(), this._builder.ConnectionString);
                System.Data.DataTable dataTable = new System.Data.DataTable();
                adapter.Fill(dataTable);
                return dataTable;
            }
            catch (Exception)
            {
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
            return null;
        }

        public System.Data.DataTable GetExcelTableName()
        {
            System.Data.DataTable oleDbSchemaTable = null;
            OleDbConnection connection = new OleDbConnection(this._builder.ConnectionString);
            try
            {
                connection.Open();
                oleDbSchemaTable = connection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                connection.Close();
                return oleDbSchemaTable;
            }
            catch (Exception)
            {
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
            return oleDbSchemaTable;
        }

        public static void KillExcel()
        {
            string processName = "Excel";
            new Process();
            try
            {
                foreach (Process process in Process.GetProcessesByName(processName))
                {
                    if (ProcessInfo.CheckParentProcess(process.Id))
                    {
                        process.Kill();
                    }
                }
            }
            catch (Exception exception)
            {
                throw new Exception("", exception);
            }
        }

        /// <summary>
        /// 停止写入Excel的进程
        /// </summary>
        public static void KillExcelEx()
        {
            Process[] processesByName = Process.GetProcessesByName("EXCEL");
            DateTime startTime = new DateTime();
            int index = 0;
            for (int i = 0; i < processesByName.Length; i++)
            {
                if (startTime < processesByName[i].StartTime)
                {
                    startTime = processesByName[i].StartTime;
                    index = i;
                }
            }
            if (processesByName.Length > 0)
            {
                while (!processesByName[index].HasExited)
                {
                    processesByName[index].Kill();
                }
            }
        }

        public string DataSource
        {
            get
            {
                return this._dataSource;
            }
            set
            {
                this._dataSource = value;
                this._builder["Data Source"] = this._dataSource;
            }
        }

        public bool Heading
        {
            get
            {
                return this._isHeading;
            }
            set
            {
                this._isHeading = value;
                if (!this._isHeading)
                {
                    this._builder["Extended Properties"] = "Excel 12.0;HDR=NO";
                }
                else
                {
                    this._builder["Extended Properties"] = "Excel 12.0;HDR=YES";
                }
            }
        }
    }
}

