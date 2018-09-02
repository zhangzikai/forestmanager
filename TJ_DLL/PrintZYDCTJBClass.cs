namespace Tj
{
    using Microsoft.Office.Interop.Excel;
    using System;
    using System.Data;
    using System.Diagnostics;
    using System.IO;
    using System.Reflection;
    using System.Windows.Forms;

    internal class PrintZYDCTJBClass
    {
        public void BatchPrintZYBHTJB(string tjdwmc, DataSet tjds, string xlsModelPath, int printcount)
        {
            if (!File.Exists(xlsModelPath))
            {
                MessageBox.Show(xlsModelPath + " 不存在，请检查!", "错误", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
            DataSet set = new DataSet("resultds");
            int num = 0;
        Label_002F:
            if (num >= tjds.Tables.Count)
            {
                tjds.Clear();
                tjds = null;
                Microsoft.Office.Interop.Excel.Application application = new ApplicationClass();
                try
                {
                    if (application == null)
                    {
                        MessageBox.Show("不能建立EXCEL对象，请在机器上安装MS Office软件！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    }
                    else
                    {
                        object updateLinks = Missing.Value;
                        string filename = xlsModelPath;
                        application.Workbooks.Open(filename, updateLinks, updateLinks, updateLinks, updateLinks, updateLinks, updateLinks, updateLinks, updateLinks, updateLinks, updateLinks, updateLinks, updateLinks, updateLinks, updateLinks);
                        application.Visible = false;
                        application.DisplayAlerts = false;
                        Worksheet worksheet = null;
                        for (int i = 0; i < set.Tables.Count; i++)
                        {
                            System.Data.DataTable table3 = set.Tables[i];
                            string tableName = table3.TableName;
                            int count = table3.Rows.Count;
                            int num10 = table3.Columns.Count;
                            object[,] objArray = new object[count, num10];
                            for (int j = 0; j < count; j++)
                            {
                                for (int k = 0; k < num10; k++)
                                {
                                    objArray[j, k] = table3.Rows[j][k];
                                }
                            }
                            if (tableName.Trim().ToUpper() == "B1")
                            {
                                worksheet = application.Sheets[1] as Worksheet;
                                int num13 = worksheet.UsedRange.Rows.Count;
                                worksheet.get_Range("B2", "B2").Value2 = tjdwmc;
                                int num15 = (count + 7) - 1;
                                worksheet.get_Range(worksheet.Cells[7, 1], worksheet.Cells[num13 + 6, num10]).EntireRow.Delete(updateLinks);
                                worksheet.get_Range(worksheet.Cells[7, 1], worksheet.Cells[num15, num10]).Value2 = objArray;
                                worksheet.get_Range(worksheet.Cells[7, 1], worksheet.Cells[num15, num10]).RowHeight = 0x1c;
                                worksheet.get_Range(worksheet.Cells[7, 1], worksheet.Cells[num15, num10]).Font.Size = 9;
                                worksheet.get_Range(worksheet.Cells[7, 1], worksheet.Cells[num15, 1]).WrapText = true;
                                worksheet.get_Range(worksheet.Cells[7, 1], worksheet.Cells[num15, 2]).HorizontalAlignment = XlHAlign.xlHAlignCenter;
                                worksheet.get_Range(worksheet.Cells[7, 1], worksheet.Cells[num15, 2]).VerticalAlignment = XlVAlign.xlVAlignCenter;
                                worksheet.get_Range(worksheet.Cells[7, 3], worksheet.Cells[num15, num10 - 2]).HorizontalAlignment = XlHAlign.xlHAlignRight;
                                worksheet.get_Range(worksheet.Cells[7, num10 - 2], worksheet.Cells[num15, num10]).HorizontalAlignment = XlHAlign.xlHAlignCenter;
                                worksheet.get_Range(worksheet.Cells[7, 1], worksheet.Cells[num15, num10]).Borders.LineStyle = 1;
                                worksheet.Select(updateLinks);
                                worksheet.get_Range("A1", "A1").Select();
                            }
                            else if (tableName.Trim().ToUpper() == "B2")
                            {
                                worksheet = application.Sheets[2] as Worksheet;
                                int num1 = worksheet.UsedRange.Rows.Count;
                                int num18 = (count + 7) - 1;
                                worksheet.get_Range("B2", "B2").Value2 = tjdwmc;
                                worksheet.get_Range(worksheet.Cells[7, 1], worksheet.Cells[num18, num10]).EntireRow.Delete(updateLinks);
                                worksheet.get_Range(worksheet.Cells[7, 1], worksheet.Cells[num18, num10]).Value2 = objArray;
                                worksheet.get_Range(worksheet.Cells[7, 1], worksheet.Cells[num18, num10]).Font.Size = 9;
                                worksheet.get_Range(worksheet.Cells[7, 1], worksheet.Cells[num18, 1]).RowHeight = 0x1c;
                                worksheet.get_Range(worksheet.Cells[7, 1], worksheet.Cells[num18, 1]).WrapText = true;
                                worksheet.get_Range(worksheet.Cells[7, 1], worksheet.Cells[num18, 2]).HorizontalAlignment = 3;
                                worksheet.get_Range(worksheet.Cells[7, 1], worksheet.Cells[num18, 2]).VerticalAlignment = 2;
                                worksheet.get_Range(worksheet.Cells[7, 3], worksheet.Cells[num18, num10]).HorizontalAlignment = XlHAlign.xlHAlignRight;
                                worksheet.get_Range(worksheet.Cells[7, 1], worksheet.Cells[num18, num10]).Borders.LineStyle = 1;
                                worksheet.Select(updateLinks);
                                worksheet.get_Range("A1", "A1").Select();
                            }
                            else if (tableName.Trim().ToUpper() == "B3")
                            {
                                worksheet = application.Sheets[3] as Worksheet;
                                int num29 = worksheet.UsedRange.Rows.Count;
                                int num21 = (count + 5) - 1;
                                worksheet.get_Range("B2", "B2").Value2 = tjdwmc;
                                worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num21, num10]).EntireRow.Delete(updateLinks);
                                worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num21, num10]).Value2 = objArray;
                                worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num21, num10]).RowHeight = 0x1c;
                                worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num21, num10]).Font.Size = 9;
                                worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num21, 1]).WrapText = true;
                                worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num21, 2]).HorizontalAlignment = XlHAlign.xlHAlignCenter;
                                worksheet.get_Range(worksheet.Cells[5, 3], worksheet.Cells[num21, num10]).HorizontalAlignment = XlHAlign.xlHAlignRight;
                                worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num21, num10]).Borders.LineStyle = 1;
                                worksheet.Select(updateLinks);
                                worksheet.get_Range("A1", "A1").Select();
                            }
                            else if (tableName.Trim().ToUpper() == "B4")
                            {
                                worksheet = application.Sheets[4] as Worksheet;
                                int num30 = worksheet.UsedRange.Rows.Count;
                                int num24 = (count + 5) - 1;
                                worksheet.get_Range("B2", "B2").Value2 = tjdwmc;
                                worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num24, num10]).EntireRow.Delete(updateLinks);
                                worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num24, num10]).Value2 = objArray;
                                worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num24, num10]).Font.Size = 10;
                                worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num24, 1]).RowHeight = 0x15;
                                worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num24, 1]).WrapText = true;
                                worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num24, 2]).HorizontalAlignment = 3;
                                worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num24, 2]).VerticalAlignment = 2;
                                worksheet.get_Range(worksheet.Cells[5, 3], worksheet.Cells[num24, num10]).HorizontalAlignment = XlHAlign.xlHAlignRight;
                                worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num24, num10]).Borders.LineStyle = 1;
                                worksheet.Select(updateLinks);
                                worksheet.get_Range("A1", "A1").Select();
                            }
                            else if (tableName.Trim().ToUpper() == "B5")
                            {
                                worksheet = application.Sheets[5] as Worksheet;
                                int num31 = worksheet.UsedRange.Rows.Count;
                                int num27 = (count + 5) - 1;
                                worksheet.get_Range("B2", "B2").Value2 = tjdwmc;
                                worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num27, num10]).EntireRow.Delete(updateLinks);
                                worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num27, num10]).Value2 = objArray;
                                worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num27, num10]).RowHeight = 0x19;
                                worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num27, num10]).Font.Size = 10;
                                worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num27, 1]).WrapText = true;
                                worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num27, 3]).HorizontalAlignment = 3;
                                worksheet.get_Range(worksheet.Cells[5, 4], worksheet.Cells[num27, num10]).HorizontalAlignment = XlHAlign.xlHAlignRight;
                                worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num27, num10]).Borders.LineStyle = 1;
                                worksheet.Select(updateLinks);
                                worksheet.get_Range("A1", "A1").Select();
                            }
                            object to = application.ExecuteExcel4Macro("GET.DOCUMENT(50)");
                            worksheet.PrintOut(1, to, printcount, updateLinks, updateLinks, updateLinks, updateLinks, updateLinks);
                        }
                        worksheet = null;
                    }
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message.ToString(), "导出EXCEL错误", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
                finally
                {
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
                    catch (Exception exception2)
                    {
                        exception2.ToString();
                    }
                    GC.Collect();
                }
            }
            else
            {
                string str = tjds.Tables[num].TableName;
                System.Data.DataTable table = tjds.Tables[num];
                if ((table != null) && (table.Rows.Count > 0))
                {
                    System.Data.DataTable table2 = new System.Data.DataTable("mytable");
                    if (str.Trim().ToUpper() == "B1")
                    {
                        table2.TableName = "B1";
                        foreach (DataColumn column in table.Columns)
                        {
                            DataColumn column2 = new DataColumn(column.ColumnName, typeof(string));
                            table2.Columns.Add(column2);
                        }
                        string str2 = "";
                        foreach (DataRow row in table.Rows)
                        {
                            DataRow row2 = table2.NewRow();
                            string str3 = row[0].ToString();
                            row2[0] = row[0];
                            if (str2 != str3)
                            {
                                str2 = str3;
                            }
                            else
                            {
                                row2[0] = "";
                            }
                            row2[1] = row[1];
                            for (int m = 2; m < table.Columns.Count; m++)
                            {
                                if (row[m] != DBNull.Value)
                                {
                                    string str4 = row[m].ToString();
                                    if (str4.IndexOf('.') < 0)
                                    {
                                        str4 = str4 + ".0";
                                    }
                                    if (Convert.ToDouble(row[m]) > 1000.0)
                                    {
                                        int num3 = ((int) Convert.ToDouble(row[m])) / 0x3e8;
                                        string str5 = Convert.ToString(num3);
                                        string str6 = str4.Substring(str5.Length, str4.Length - str5.Length);
                                        row2[m] = str5 + "\n\r" + str6;
                                    }
                                    else
                                    {
                                        row2[m] = "\n\r" + str4;
                                    }
                                }
                            }
                            table2.Rows.Add(row2);
                        }
                    }
                    else if (str.Trim().ToUpper() == "B2")
                    {
                        table2.TableName = "B2";
                        foreach (DataColumn column3 in table.Columns)
                        {
                            DataColumn column4 = new DataColumn(column3.ColumnName, typeof(string));
                            table2.Columns.Add(column4);
                        }
                        string str7 = "";
                        foreach (DataRow row3 in table.Rows)
                        {
                            DataRow row4 = table2.NewRow();
                            row4[0] = row3[0];
                            string str8 = row3[0].ToString();
                            if (str7 != str8)
                            {
                                str7 = str8;
                            }
                            else
                            {
                                row4[0] = "";
                            }
                            row4[1] = row3[1];
                            for (int n = 2; n < table.Columns.Count; n++)
                            {
                                if (row3[n] != DBNull.Value)
                                {
                                    string str9 = row3[n].ToString();
                                    if (Convert.ToDouble(row3[n]) > 10000.0)
                                    {
                                        int num5 = ((int) Convert.ToDouble(row3[n])) / 0x2710;
                                        string str10 = Convert.ToString(num5);
                                        string str11 = str9.Substring(str10.Length, str9.Length - str10.Length);
                                        row4[n] = str10 + "\n\r" + str11;
                                    }
                                    else
                                    {
                                        row4[n] = "\n\r" + str9;
                                    }
                                }
                            }
                            table2.Rows.Add(row4);
                        }
                    }
                    else if (str.Trim().ToUpper() == "B3")
                    {
                        table2.TableName = "B3";
                        foreach (DataColumn column5 in table.Columns)
                        {
                            DataColumn column6 = new DataColumn(column5.ColumnName, typeof(string));
                            table2.Columns.Add(column6);
                        }
                        string str12 = "";
                        foreach (DataRow row5 in table.Rows)
                        {
                            DataRow row6 = table2.NewRow();
                            row6[0] = row5[0];
                            string str13 = row5[0].ToString();
                            if (str12 != str13)
                            {
                                str12 = str13;
                            }
                            else
                            {
                                row6[0] = "";
                            }
                            row6[1] = row5[1];
                            for (int num6 = 2; num6 < table.Columns.Count; num6++)
                            {
                                if (row5[num6] != DBNull.Value)
                                {
                                    string str14 = row5[num6].ToString();
                                    if (Convert.ToDouble(row5[num6]) > 10000.0)
                                    {
                                        int num7 = ((int) Convert.ToDouble(row5[num6])) / 0x2710;
                                        string str15 = Convert.ToString(num7);
                                        string str16 = str14.Substring(str15.Length, str14.Length - str15.Length);
                                        row6[num6] = str15 + "\n\r" + str16;
                                    }
                                    else
                                    {
                                        row6[num6] = "\n\r" + str14;
                                    }
                                }
                            }
                            table2.Rows.Add(row6);
                        }
                    }
                    else if (str.Trim().ToUpper() == "B4")
                    {
                        table2 = table.Copy();
                        table2.TableName = "B4";
                        string str17 = "";
                        foreach (DataRow row7 in table2.Rows)
                        {
                            string str18 = row7[0].ToString();
                            if (str17 != str18)
                            {
                                str17 = str18;
                            }
                            else
                            {
                                row7[0] = "";
                            }
                        }
                    }
                    else if (str.Trim().ToUpper() == "B5")
                    {
                        table2 = table.Copy();
                        table2.TableName = "B5";
                        string str19 = "";
                        string str20 = "";
                        foreach (DataRow row8 in table2.Rows)
                        {
                            string str21 = row8[0].ToString();
                            if (str19 != str21)
                            {
                                str19 = str21;
                            }
                            else
                            {
                                row8[0] = "";
                            }
                            string str22 = row8[1].ToString();
                            if (str20 != str22)
                            {
                                str20 = str22;
                            }
                            else
                            {
                                row8[1] = "";
                            }
                        }
                    }
                    set.Tables.Add(table2);
                }
                num++;
                goto Label_002F;
            }
        }

        public void BatchPrintZYDCTJB(string tjdwmc, string tjnd, DataSet tjds, string xlsPath, int printcount)
        {
            if (!File.Exists(xlsPath))
            {
                MessageBox.Show(xlsPath + " 不存在，请检查!", "错误", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
            printcount = int.Parse(printcount.ToString());
            if (printcount <= 0)
            {
                MessageBox.Show("打印份数不正确，只能输入整数，请检查!", "错误", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
            DataSet set = new DataSet("resultds");
            int num = 0;
        Label_0058:
            if (num >= tjds.Tables.Count)
            {
                tjds.Clear();
                tjds = null;
                Microsoft.Office.Interop.Excel.Application application = new ApplicationClass();
                try
                {
                    if (application == null)
                    {
                        MessageBox.Show("不能建立Microsoft.Office.Interop.Excel对象，请在机器上安装MS Office软件！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    }
                    else
                    {
                        object updateLinks = Missing.Value;
                        string filename = xlsPath;
                        application.Workbooks.Open(filename, updateLinks, updateLinks, updateLinks, updateLinks, updateLinks, updateLinks, updateLinks, updateLinks, updateLinks, updateLinks, updateLinks, updateLinks, updateLinks, updateLinks);
                        application.Visible = false;
                        Worksheet worksheet = null;
                        application.ActiveWindow.DisplayZeros = false;
                        for (int i = 0; i < set.Tables.Count; i++)
                        {
                            System.Data.DataTable table3 = set.Tables[i];
                            string tableName = table3.TableName;
                            int count = table3.Rows.Count;
                            int num16 = table3.Columns.Count;
                            object[,] objArray = new object[count, num16];
                            for (int j = 0; j < count; j++)
                            {
                                for (int k = 0; k < num16; k++)
                                {
                                    objArray[j, k] = table3.Rows[j][k];
                                }
                            }
                            table3.DefaultView.ToTable(true, new string[] { table3.Columns[0].ColumnName });
                            if (tableName.Trim().ToUpper() == "B1")
                            {
                                worksheet = application.Sheets[2] as Worksheet;
                                int num19 = worksheet.UsedRange.Rows.Count;
                                worksheet.get_Range("B2", "B2").Value2 = tjdwmc;
                                worksheet.get_Range("G2", "G2").Value2 = "统计年度：" + tjnd;
                                int num21 = (count + 7) - 1;
                                worksheet.get_Range(worksheet.Cells[7, 1], worksheet.Cells[num19 + 6, num16]).EntireRow.Delete(updateLinks);
                                worksheet.get_Range(worksheet.Cells[7, 1], worksheet.Cells[num21, num16]).Value2 = objArray;
                                worksheet.get_Range(worksheet.Cells[7, 1], worksheet.Cells[num21, num16]).RowHeight = 0x1c;
                                worksheet.get_Range(worksheet.Cells[7, 1], worksheet.Cells[num21, num16]).Font.Size = 9;
                                worksheet.get_Range(worksheet.Cells[7, 1], worksheet.Cells[num21, 2]).HorizontalAlignment = XlHAlign.xlHAlignCenter;
                                worksheet.get_Range(worksheet.Cells[7, 1], worksheet.Cells[num21, 2]).VerticalAlignment = XlVAlign.xlVAlignCenter;
                                worksheet.get_Range(worksheet.Cells[7, 3], worksheet.Cells[num21, num16 - 1]).HorizontalAlignment = XlHAlign.xlHAlignRight;
                                worksheet.get_Range(worksheet.Cells[7, num16], worksheet.Cells[num21, num16]).HorizontalAlignment = XlHAlign.xlHAlignCenter;
                                worksheet.get_Range(worksheet.Cells[7, 1], worksheet.Cells[num21, num16]).Borders.LineStyle = 1;
                                worksheet.Select(updateLinks);
                                worksheet.get_Range("A1", "A1").Select();
                            }
                            else if (tableName.Trim().ToUpper() == "B1-1")
                            {
                                worksheet = application.Sheets[3] as Worksheet;
                                int num22 = worksheet.UsedRange.Rows.Count;
                                worksheet.get_Range("B2", "B2").Value2 = tjdwmc;
                                worksheet.get_Range("G2", "G2").Value2 = "统计年度：" + tjnd;
                                int num24 = (count + 6) - 1;
                                int num25 = (num22 + 6) - 1;
                                worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num25, num16]).EntireRow.Delete(updateLinks);
                                worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num24, num16]).Value2 = objArray;
                                worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num24, num16]).Font.Size = 10;
                                worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num24, num16]).RowHeight = 30;
                                worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num24, 1]).HorizontalAlignment = XlHAlign.xlHAlignCenter;
                                worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num24, 1]).VerticalAlignment = XlVAlign.xlVAlignCenter;
                                worksheet.get_Range(worksheet.Cells[6, 2], worksheet.Cells[num24, num16 - 1]).HorizontalAlignment = XlHAlign.xlHAlignRight;
                                worksheet.get_Range(worksheet.Cells[6, num16], worksheet.Cells[num24, num16]).HorizontalAlignment = XlHAlign.xlHAlignCenter;
                                worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num24, num16]).Borders.LineStyle = 1;
                                worksheet.Select(updateLinks);
                                worksheet.get_Range("A1", "A1").Select();
                            }
                            else if (tableName.Trim().ToUpper() == "B2")
                            {
                                worksheet = application.Sheets[4] as Worksheet;
                                int num1 = worksheet.UsedRange.Rows.Count;
                                int num28 = (count + 7) - 1;
                                worksheet.get_Range("B2", "B2").Value2 = tjdwmc;
                                worksheet.get_Range("G2", "G2").Value2 = "统计年度：" + tjnd;
                                worksheet.get_Range(worksheet.Cells[7, 1], worksheet.Cells[num28, num16]).EntireRow.Delete(updateLinks);
                                worksheet.get_Range(worksheet.Cells[7, 1], worksheet.Cells[num28, num16]).Value2 = objArray;
                                worksheet.get_Range(worksheet.Cells[7, 1], worksheet.Cells[num28, num16]).Font.Size = 9;
                                application.DisplayAlerts = false;
                                worksheet.get_Range(worksheet.Cells[7, 1], worksheet.Cells[num28, 1]).RowHeight = 0x15;
                                worksheet.get_Range(worksheet.Cells[7, 1], worksheet.Cells[num28, 2]).HorizontalAlignment = 3;
                                worksheet.get_Range(worksheet.Cells[7, 1], worksheet.Cells[num28, 2]).VerticalAlignment = 2;
                                worksheet.get_Range(worksheet.Cells[7, 1], worksheet.Cells[num28, num16]).Borders.LineStyle = 1;
                                worksheet.Select(updateLinks);
                                worksheet.get_Range("A1", "A1").Select();
                            }
                            else if (tableName.Trim().ToUpper() == "B2-1")
                            {
                                worksheet = application.Sheets[5] as Worksheet;
                                int num120 = worksheet.UsedRange.Rows.Count;
                                int num31 = (count + 6) - 1;
                                worksheet.get_Range("B2", "B2").Value2 = tjdwmc;
                                worksheet.get_Range("G2", "G2").Value2 = "统计年度：" + tjnd;
                                worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num31, num16]).EntireRow.Delete(updateLinks);
                                worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num31, num16]).Value2 = objArray;
                                worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num31, num16]).RowHeight = 0x1c;
                                worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num31, num16]).Font.Size = 9;
                                worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num31, 3]).HorizontalAlignment = 3;
                                worksheet.get_Range(worksheet.Cells[6, 4], worksheet.Cells[num31, num16]).HorizontalAlignment = XlHAlign.xlHAlignRight;
                                worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num31, num16]).Borders.LineStyle = 1;
                                worksheet.Select(updateLinks);
                                worksheet.get_Range("A1", "A1").Select();
                            }
                            else if (tableName.Trim().ToUpper() == "B3")
                            {
                                worksheet = application.Sheets[6] as Worksheet;
                                int num121 = worksheet.UsedRange.Rows.Count;
                                int num34 = (count + 8) - 1;
                                worksheet.get_Range("B2", "B2").Value2 = tjdwmc;
                                worksheet.get_Range("G2", "G2").Value2 = "统计年度：" + tjnd;
                                worksheet.get_Range(worksheet.Cells[8, 1], worksheet.Cells[num34, num16]).EntireRow.Delete(updateLinks);
                                worksheet.get_Range(worksheet.Cells[8, 1], worksheet.Cells[num34, num16]).Value2 = objArray;
                                worksheet.get_Range(worksheet.Cells[8, 1], worksheet.Cells[num34, num16]).RowHeight = 0x1c;
                                worksheet.get_Range(worksheet.Cells[8, 1], worksheet.Cells[num34, num16]).Font.Size = 9;
                                worksheet.get_Range(worksheet.Cells[8, 1], worksheet.Cells[num34, 2]).HorizontalAlignment = XlHAlign.xlHAlignCenter;
                                worksheet.get_Range(worksheet.Cells[8, 3], worksheet.Cells[num34, num16]).HorizontalAlignment = XlHAlign.xlHAlignRight;
                                worksheet.get_Range(worksheet.Cells[8, 1], worksheet.Cells[num34, num16]).Borders.LineStyle = 1;
                                worksheet.Select(updateLinks);
                                worksheet.get_Range("A1", "A1").Select();
                            }
                            else if (tableName.Trim().ToUpper() == "B4")
                            {
                                worksheet = application.Sheets[7] as Worksheet;
                                int num122 = worksheet.UsedRange.Rows.Count;
                                int num37 = (count + 5) - 1;
                                worksheet.get_Range("B2", "B2").Value2 = tjdwmc;
                                worksheet.get_Range("F2", "F2").Value2 = "统计年度：" + tjnd;
                                worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num37, num16]).EntireRow.Delete(updateLinks);
                                worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num37, num16]).Value2 = objArray;
                                worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num37, num16]).Font.Size = 10;
                                worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num37, 1]).RowHeight = 0x15;
                                worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num37, 5]).HorizontalAlignment = 3;
                                worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num37, 5]).VerticalAlignment = 2;
                                worksheet.get_Range(worksheet.Cells[5, 6], worksheet.Cells[num37, num16]).HorizontalAlignment = XlHAlign.xlHAlignRight;
                                worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num37, num16]).Borders.LineStyle = 1;
                                worksheet.Select(updateLinks);
                                worksheet.get_Range("A1", "A1").Select();
                            }
                            else if (tableName.Trim().ToUpper() == "B5")
                            {
                                worksheet = application.Sheets[8] as Worksheet;
                                int num123 = worksheet.UsedRange.Rows.Count;
                                int num40 = (count + 7) - 1;
                                worksheet.get_Range("B2", "B2").Value2 = tjdwmc;
                                worksheet.get_Range("G2", "G2").Value2 = "统计年度：" + tjnd;
                                worksheet.get_Range(worksheet.Cells[7, 1], worksheet.Cells[num40, num16]).EntireRow.Delete(updateLinks);
                                worksheet.get_Range(worksheet.Cells[7, 1], worksheet.Cells[num40, num16]).Value2 = objArray;
                                worksheet.get_Range(worksheet.Cells[7, 1], worksheet.Cells[num40, num16]).RowHeight = 30;
                                worksheet.get_Range(worksheet.Cells[7, 1], worksheet.Cells[num40, num16]).Font.Size = 10;
                                worksheet.get_Range(worksheet.Cells[7, 1], worksheet.Cells[num40, 4]).HorizontalAlignment = 3;
                                worksheet.get_Range(worksheet.Cells[7, 5], worksheet.Cells[num40, num16]).HorizontalAlignment = XlHAlign.xlHAlignRight;
                                worksheet.get_Range(worksheet.Cells[7, 1], worksheet.Cells[num40, num16]).Borders.LineStyle = 1;
                                worksheet.Select(updateLinks);
                                worksheet.get_Range("A1", "A1").Select();
                            }
                            else if (tableName.Trim().ToUpper() == "B6")
                            {
                                worksheet = application.Sheets[9] as Worksheet;
                                int num124 = worksheet.UsedRange.Rows.Count;
                                int num43 = (count + 8) - 1;
                                worksheet.get_Range("B2", "B2").Value2 = tjdwmc;
                                worksheet.get_Range("F2", "F2").Value2 = "统计年度：" + tjnd;
                                worksheet.get_Range(worksheet.Cells[8, 1], worksheet.Cells[num43, num16]).EntireRow.Delete(updateLinks);
                                worksheet.get_Range(worksheet.Cells[8, 1], worksheet.Cells[num43, num16]).Value2 = objArray;
                                worksheet.get_Range(worksheet.Cells[8, 1], worksheet.Cells[num43, num16]).Font.Size = 10;
                                worksheet.get_Range(worksheet.Cells[8, 1], worksheet.Cells[num43, 1]).RowHeight = 0x15;
                                worksheet.get_Range(worksheet.Cells[8, 1], worksheet.Cells[num43, 3]).HorizontalAlignment = 3;
                                worksheet.get_Range(worksheet.Cells[8, 1], worksheet.Cells[num43, 3]).VerticalAlignment = 2;
                                worksheet.get_Range(worksheet.Cells[8, 1], worksheet.Cells[num43, num16]).Borders.LineStyle = 1;
                                worksheet.Select(updateLinks);
                                worksheet.get_Range("A1", "A1").Select();
                            }
                            else if (tableName.Trim().ToUpper() == "B7")
                            {
                                worksheet = application.Sheets[10] as Worksheet;
                                int num125 = worksheet.UsedRange.Rows.Count;
                                int num46 = (count + 5) - 1;
                                worksheet.get_Range("B2", "B2").Value2 = tjdwmc;
                                worksheet.get_Range("G2", "G2").Value2 = "统计年度：" + tjnd;
                                worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num46, num16]).EntireRow.Delete(updateLinks);
                                worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num46, num16]).Value2 = objArray;
                                worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num46, num16]).Font.Size = 9;
                                worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num46, 1]).RowHeight = 0x15;
                                worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num46, 3]).VerticalAlignment = 2;
                                worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num46, 3]).HorizontalAlignment = 3;
                                worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num46, num16]).Borders.LineStyle = 1;
                                worksheet.Select(updateLinks);
                                worksheet.get_Range("A1", "A1").Select();
                            }
                            else if (tableName.Trim().ToUpper() == "B8")
                            {
                                worksheet = application.Sheets[11] as Worksheet;
                                int num126 = worksheet.UsedRange.Rows.Count;
                                int num49 = (count + 6) - 1;
                                worksheet.get_Range("B2", "B2").Value2 = tjdwmc;
                                worksheet.get_Range("G2", "G2").Value2 = "统计年度：" + tjnd;
                                worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num49, num16]).EntireRow.Delete(updateLinks);
                                worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num49, num16]).Value2 = objArray;
                                worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num49, num16]).Font.Size = 9;
                                worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num49, 1]).RowHeight = 0x15;
                                worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num49, 3]).HorizontalAlignment = 3;
                                worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num49, 3]).VerticalAlignment = 2;
                                worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num49, num16]).Borders.LineStyle = 1;
                                worksheet.Select(updateLinks);
                                worksheet.get_Range("A1", "A1").Select();
                            }
                            else if (tableName.Trim().ToUpper() == "B9")
                            {
                                worksheet = application.Sheets[12] as Worksheet;
                                int num127 = worksheet.UsedRange.Rows.Count;
                                int num52 = (count + 6) - 1;
                                worksheet.get_Range("B2", "B2").Value2 = tjdwmc;
                                worksheet.get_Range("F2", "F2").Value2 = "统计年度：" + tjnd;
                                worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num52, num16]).EntireRow.Delete(updateLinks);
                                worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num52, num16]).Value2 = objArray;
                                worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num52, num16]).Font.Size = 10;
                                worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num52, 1]).RowHeight = 0x15;
                                worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num52, 4]).HorizontalAlignment = 3;
                                worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num52, 4]).VerticalAlignment = 2;
                                worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num52, num16]).Borders.LineStyle = 1;
                                worksheet.Select(updateLinks);
                                worksheet.get_Range("A1", "A1").Select();
                            }
                            else if (tableName.Trim().ToUpper() == "B10")
                            {
                                worksheet = application.Sheets[13] as Worksheet;
                                int num128 = worksheet.UsedRange.Rows.Count;
                                int num55 = (count + 5) - 1;
                                worksheet.get_Range("B2", "B2").Value2 = tjdwmc;
                                worksheet.get_Range("F2", "F2").Value2 = "统计年度：" + tjnd;
                                worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num55, num16]).EntireRow.Delete(updateLinks);
                                worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num55, num16]).Value2 = objArray;
                                worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num55, num16]).Font.Size = 10;
                                worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num55, 1]).RowHeight = 0x15;
                                worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num55, 4]).VerticalAlignment = 2;
                                worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num55, 4]).HorizontalAlignment = 3;
                                worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num55, num16]).Borders.LineStyle = 1;
                                worksheet.Select(updateLinks);
                                worksheet.get_Range("A1", "A1").Select();
                            }
                            else if (tableName.Trim().ToUpper() == "B11")
                            {
                                worksheet = application.Sheets[14] as Worksheet;
                                int num129 = worksheet.UsedRange.Rows.Count;
                                int num58 = (count + 6) - 1;
                                worksheet.get_Range("B2", "B2").Value2 = tjdwmc;
                                worksheet.get_Range("F2", "F2").Value2 = "统计年度：" + tjnd;
                                worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num58, num16]).EntireRow.Delete(updateLinks);
                                worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num58, num16]).Value2 = objArray;
                                worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num58, num16]).Font.Size = 10;
                                worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num58, 1]).RowHeight = 0x15;
                                worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num58, 3]).VerticalAlignment = 2;
                                worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num58, 3]).HorizontalAlignment = 3;
                                worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num58, num16]).Borders.LineStyle = 1;
                                worksheet.Select(updateLinks);
                                worksheet.get_Range("A1", "A1").Select();
                            }
                            else if (tableName.Trim().ToUpper() == "B11-1")
                            {
                                worksheet = application.Sheets[15] as Worksheet;
                                int num130 = worksheet.UsedRange.Rows.Count;
                                int num61 = (count + 5) - 1;
                                worksheet.get_Range("B2", "B2").Value2 = tjdwmc;
                                worksheet.get_Range("G2", "G2").Value2 = "统计年度：" + tjnd;
                                worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num61, num16]).EntireRow.Delete(updateLinks);
                                worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num61, num16]).Value2 = objArray;
                                worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num61, num16]).Font.Size = 10;
                                worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num61, 1]).RowHeight = 0x15;
                                worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num61, 2]).VerticalAlignment = 2;
                                worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num61, 2]).HorizontalAlignment = 3;
                                worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num61, num16]).Borders.LineStyle = 1;
                                worksheet.Select(updateLinks);
                                worksheet.get_Range("A1", "A1").Select();
                            }
                            else if (tableName.Trim().ToUpper() == "B12")
                            {
                                worksheet = application.Sheets[0x10] as Worksheet;
                                int num131 = worksheet.UsedRange.Rows.Count;
                                int num64 = (count + 6) - 1;
                                worksheet.get_Range("B2", "B2").Value2 = tjdwmc;
                                worksheet.get_Range("F2", "F2").Value2 = "统计年度：" + tjnd;
                                worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num64, num16]).EntireRow.Delete(updateLinks);
                                worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num64, num16]).Value2 = objArray;
                                worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num64, num16]).Font.Size = 10;
                                worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num64, 1]).RowHeight = 0x15;
                                worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num64, 3]).VerticalAlignment = 2;
                                worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num64, 3]).HorizontalAlignment = 3;
                                worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num64, num16]).Borders.LineStyle = 1;
                                worksheet.Select(updateLinks);
                                worksheet.get_Range("A1", "A1").Select();
                            }
                            else if (tableName.Trim().ToUpper() == "B13")
                            {
                                worksheet = application.Sheets[0x11] as Worksheet;
                                int num132 = worksheet.UsedRange.Rows.Count;
                                int num67 = (count + 5) - 1;
                                worksheet.get_Range("B2", "B2").Value2 = tjdwmc;
                                worksheet.get_Range("F2", "F2").Value2 = "统计年度：" + tjnd;
                                worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num67, num16]).EntireRow.Delete(updateLinks);
                                worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num67, num16]).Value2 = objArray;
                                worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num67, num16]).Font.Size = 10;
                                application.DisplayAlerts = false;
                                worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num67, 1]).RowHeight = 0x15;
                                worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num67, 4]).HorizontalAlignment = 3;
                                worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num67, 4]).VerticalAlignment = 2;
                                worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num67, num16]).Borders.LineStyle = 1;
                                worksheet.Select(updateLinks);
                                worksheet.get_Range("A1", "A1").Select();
                            }
                            else if (tableName.Trim().ToUpper() == "B14")
                            {
                                worksheet = application.Sheets[0x12] as Worksheet;
                                int num133 = worksheet.UsedRange.Rows.Count;
                                int num70 = (count + 5) - 1;
                                worksheet.get_Range("B2", "B2").Value2 = tjdwmc;
                                worksheet.get_Range("F2", "F2").Value2 = "统计年度：" + tjnd;
                                worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num70, num16]).EntireRow.Delete(updateLinks);
                                worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num70, num16]).Value2 = objArray;
                                worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num70, num16]).Font.Size = 10;
                                worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num70, 1]).RowHeight = 0x15;
                                worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num70, 3]).HorizontalAlignment = 3;
                                worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num70, 3]).VerticalAlignment = 2;
                                worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num70, num16]).Borders.LineStyle = 1;
                                worksheet.Select(updateLinks);
                                worksheet.get_Range("A1", "A1").Select();
                            }
                            else if (tableName.Trim().ToUpper() == "B15")
                            {
                                worksheet = application.Sheets[0x13] as Worksheet;
                                int num134 = worksheet.UsedRange.Rows.Count;
                                int num73 = (count + 5) - 1;
                                worksheet.get_Range("B2", "B2").Value2 = tjdwmc;
                                worksheet.get_Range("E2", "E2").Value2 = "统计年度：" + tjnd;
                                worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num73, num16]).EntireRow.Delete(updateLinks);
                                worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num73, num16]).Value2 = objArray;
                                worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num73, num16]).Font.Size = 10;
                                worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num73, 1]).RowHeight = 0x15;
                                worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num73, 4]).HorizontalAlignment = 3;
                                worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num73, 4]).VerticalAlignment = 2;
                                worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num73, num16]).Borders.LineStyle = 1;
                                worksheet.Select(updateLinks);
                                worksheet.get_Range("A1", "A1").Select();
                            }
                            else if (tableName.Trim().ToUpper() == "B16")
                            {
                                worksheet = application.Sheets[20] as Worksheet;
                                int num135 = worksheet.UsedRange.Rows.Count;
                                int num76 = (count + 5) - 1;
                                worksheet.get_Range("B2", "B2").Value2 = tjdwmc;
                                worksheet.get_Range("F2", "F2").Value2 = "统计年度：" + tjnd;
                                worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num76, num16]).EntireRow.Delete(updateLinks);
                                worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num76, num16]).Value2 = objArray;
                                worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num76, num16]).Font.Size = 10;
                                worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num76, 1]).RowHeight = 0x15;
                                worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num76, 4]).HorizontalAlignment = 3;
                                worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num76, 4]).VerticalAlignment = 2;
                                worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num76, num16]).Borders.LineStyle = 1;
                                worksheet.Select(updateLinks);
                                worksheet.get_Range("A1", "A1").Select();
                            }
                            else if (tableName.Trim().ToUpper() == "B17")
                            {
                                worksheet = application.Sheets[0x15] as Worksheet;
                                int num136 = worksheet.UsedRange.Rows.Count;
                                int num79 = (count + 5) - 1;
                                worksheet.get_Range("B2", "B2").Value2 = tjdwmc;
                                worksheet.get_Range("E2", "E2").Value2 = "统计年度：" + tjnd;
                                worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num79, num16]).EntireRow.Delete(updateLinks);
                                worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num79, num16]).Value2 = objArray;
                                worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num79, num16]).Font.Size = 10;
                                worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num79, 1]).RowHeight = 0x15;
                                worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num79, 2]).HorizontalAlignment = 3;
                                worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num79, 2]).VerticalAlignment = 2;
                                worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num79, num16]).Borders.LineStyle = 1;
                                worksheet.Select(updateLinks);
                                worksheet.get_Range("A1", "A1").Select();
                            }
                            else if (tableName.Trim().ToUpper() == "B18")
                            {
                                worksheet = application.Sheets[0x16] as Worksheet;
                                int num137 = worksheet.UsedRange.Rows.Count;
                                int num82 = (count + 5) - 1;
                                worksheet.get_Range("B2", "B2").Value2 = tjdwmc;
                                worksheet.get_Range("E2", "E2").Value2 = "统计年度：" + tjnd;
                                worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num82, num16]).EntireRow.Delete(updateLinks);
                                worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num82, num16]).Value2 = objArray;
                                worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num82, num16]).Font.Size = 10;
                                worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num82, 1]).RowHeight = 0x15;
                                worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num82, 2]).HorizontalAlignment = 3;
                                worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num82, 2]).VerticalAlignment = 2;
                                worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num82, num16]).Borders.LineStyle = 1;
                                worksheet.Select(updateLinks);
                                worksheet.get_Range("A1", "A1").Select();
                            }
                            else if (tableName.Trim().ToUpper() == "B19")
                            {
                                worksheet = application.Sheets[0x17] as Worksheet;
                                int num138 = worksheet.UsedRange.Rows.Count;
                                int num85 = (count + 4) - 1;
                                worksheet.get_Range("B2", "B2").Value2 = tjdwmc;
                                worksheet.get_Range("D2", "D2").Value2 = "统计年度：" + tjnd;
                                worksheet.get_Range(worksheet.Cells[4, 1], worksheet.Cells[num85, num16]).EntireRow.Delete(updateLinks);
                                worksheet.get_Range(worksheet.Cells[4, 1], worksheet.Cells[num85, num16]).Value2 = objArray;
                                worksheet.get_Range(worksheet.Cells[4, 1], worksheet.Cells[num85, num16]).Font.Size = 10;
                                worksheet.get_Range(worksheet.Cells[4, 1], worksheet.Cells[num85, 1]).RowHeight = 0x15;
                                worksheet.get_Range(worksheet.Cells[4, 1], worksheet.Cells[num85, 2]).HorizontalAlignment = 3;
                                worksheet.get_Range(worksheet.Cells[4, 1], worksheet.Cells[num85, 2]).VerticalAlignment = 2;
                                worksheet.get_Range(worksheet.Cells[4, 1], worksheet.Cells[num85, num16]).Borders.LineStyle = 1;
                                worksheet.Select(updateLinks);
                                worksheet.get_Range("A1", "A1").Select();
                            }
                            else if (tableName.Trim().ToUpper() == "B20")
                            {
                                worksheet = application.Sheets[0x18] as Worksheet;
                                int num139 = worksheet.UsedRange.Rows.Count;
                                int num88 = (count + 5) - 1;
                                worksheet.get_Range("B2", "B2").Value2 = tjdwmc;
                                worksheet.get_Range("D2", "D2").Value2 = "统计年度：" + tjnd;
                                worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num88, num16]).EntireRow.Delete(updateLinks);
                                worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num88, num16]).Value2 = objArray;
                                worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num88, num16]).Font.Size = 10;
                                worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num88, 1]).RowHeight = 0x15;
                                worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num88, 2]).HorizontalAlignment = 3;
                                worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num88, 2]).VerticalAlignment = 2;
                                worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num88, num16]).Borders.LineStyle = 1;
                                worksheet.Select(updateLinks);
                                worksheet.get_Range("A1", "A1").Select();
                            }
                            else if (tableName.Trim().ToUpper() == "B21")
                            {
                                worksheet = application.Sheets[0x19] as Worksheet;
                                int num140 = worksheet.UsedRange.Rows.Count;
                                int num91 = (count + 5) - 1;
                                worksheet.get_Range("B2", "B2").Value2 = tjdwmc;
                                worksheet.get_Range("E2", "E2").Value2 = "统计年度：" + tjnd;
                                worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num91, num16]).EntireRow.Delete(updateLinks);
                                worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num91, num16]).Value2 = objArray;
                                worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num91, num16]).Font.Size = 10;
                                worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num91, 1]).RowHeight = 0x15;
                                worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num91, 2]).HorizontalAlignment = 3;
                                worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num91, 2]).VerticalAlignment = 2;
                                worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num91, num16]).Borders.LineStyle = 1;
                                worksheet.Select(updateLinks);
                                worksheet.get_Range("A1", "A1").Select();
                            }
                            else if (tableName.Trim().ToUpper() == "B22")
                            {
                                worksheet = application.Sheets[0x1a] as Worksheet;
                                int num141 = worksheet.UsedRange.Rows.Count;
                                int num94 = (count + 4) - 1;
                                worksheet.get_Range("B2", "B2").Value2 = tjdwmc;
                                worksheet.get_Range("D2", "D2").Value2 = "统计年度：" + tjnd;
                                worksheet.get_Range(worksheet.Cells[4, 1], worksheet.Cells[num94, num16]).EntireRow.Delete(updateLinks);
                                worksheet.get_Range(worksheet.Cells[4, 1], worksheet.Cells[num94, num16]).Value2 = objArray;
                                worksheet.get_Range(worksheet.Cells[4, 1], worksheet.Cells[num94, num16]).Font.Size = 10;
                                application.DisplayAlerts = false;
                                worksheet.get_Range(worksheet.Cells[4, 1], worksheet.Cells[num94, 1]).RowHeight = 0x15;
                                worksheet.get_Range(worksheet.Cells[4, 1], worksheet.Cells[num94, 2]).HorizontalAlignment = 3;
                                worksheet.get_Range(worksheet.Cells[4, 1], worksheet.Cells[num94, 2]).VerticalAlignment = 2;
                                worksheet.get_Range(worksheet.Cells[4, 1], worksheet.Cells[num94, num16]).Borders.LineStyle = 1;
                                worksheet.Select(updateLinks);
                                worksheet.get_Range("A1", "A1").Select();
                            }
                            else if (tableName.Trim().ToUpper() == "B23")
                            {
                                worksheet = application.Sheets[0x1b] as Worksheet;
                                int num142 = worksheet.UsedRange.Rows.Count;
                                int num97 = (count + 7) - 1;
                                worksheet.get_Range("B2", "B2").Value2 = tjdwmc;
                                worksheet.get_Range(worksheet.Cells[7, 1], worksheet.Cells[num97, num16]).EntireRow.Delete(updateLinks);
                                worksheet.get_Range(worksheet.Cells[7, 1], worksheet.Cells[num97, num16]).Value2 = objArray;
                                worksheet.get_Range(worksheet.Cells[7, 1], worksheet.Cells[num97, num16]).Font.Size = 10;
                                worksheet.get_Range(worksheet.Cells[7, 1], worksheet.Cells[num97, 2]).RowHeight = 30;
                                worksheet.get_Range(worksheet.Cells[7, 1], worksheet.Cells[num97, 2]).HorizontalAlignment = 3;
                                worksheet.get_Range(worksheet.Cells[7, 1], worksheet.Cells[num97, 2]).VerticalAlignment = 2;
                                worksheet.get_Range(worksheet.Cells[7, num16 - 1], worksheet.Cells[num97, num16]).HorizontalAlignment = 3;
                                worksheet.get_Range(worksheet.Cells[7, num16 - 1], worksheet.Cells[num97, num16]).VerticalAlignment = 2;
                                worksheet.get_Range(worksheet.Cells[7, 1], worksheet.Cells[num97, num16]).Borders.LineStyle = 1;
                                worksheet.get_Range(worksheet.Cells[num97 + 1, 1], worksheet.Cells[num97 + 1, 1]).Value2 = "注：本表数字分二行表示，其中第一行为千位（含千位）以上数字，第二行为百位（含百位）以下数字。";
                                worksheet.get_Range(worksheet.Cells[num97 + 1, 1], worksheet.Cells[num97 + 1, 1]).Font.Size = 9;
                                worksheet.Select(updateLinks);
                                worksheet.get_Range("A1", "A1").Select();
                            }
                            else if (tableName.Trim().ToUpper() == "B24")
                            {
                                worksheet = application.Sheets[0x1c] as Worksheet;
                                int num143 = worksheet.UsedRange.Rows.Count;
                                int num100 = (count + 7) - 1;
                                worksheet.get_Range("B2", "B2").Value2 = tjdwmc;
                                worksheet.get_Range(worksheet.Cells[7, 1], worksheet.Cells[num100, num16]).EntireRow.Delete(updateLinks);
                                worksheet.get_Range(worksheet.Cells[7, 1], worksheet.Cells[num100, num16]).Value2 = objArray;
                                worksheet.get_Range(worksheet.Cells[7, 1], worksheet.Cells[num100, num16]).Font.Size = 10;
                                worksheet.get_Range(worksheet.Cells[7, 1], worksheet.Cells[num100, 1]).RowHeight = 0x15;
                                worksheet.get_Range(worksheet.Cells[7, 1], worksheet.Cells[num100, 3]).HorizontalAlignment = 3;
                                worksheet.get_Range(worksheet.Cells[7, 1], worksheet.Cells[num100, 3]).VerticalAlignment = 2;
                                worksheet.get_Range(worksheet.Cells[7, 1], worksheet.Cells[num100, num16]).Borders.LineStyle = 1;
                                worksheet.Select(updateLinks);
                                worksheet.get_Range("A1", "A1").Select();
                            }
                            else if (tableName.Trim().ToUpper() == "B25")
                            {
                                worksheet = application.Sheets[0x1d] as Worksheet;
                                int num144 = worksheet.UsedRange.Rows.Count;
                                int num103 = (count + 7) - 1;
                                worksheet.get_Range("B2", "B2").Value2 = tjdwmc;
                                worksheet.get_Range(worksheet.Cells[7, 1], worksheet.Cells[num103, num16]).EntireRow.Delete(updateLinks);
                                worksheet.get_Range(worksheet.Cells[7, 1], worksheet.Cells[num103, num16]).Value2 = objArray;
                                worksheet.get_Range(worksheet.Cells[7, 1], worksheet.Cells[num103, num16]).Font.Size = 10;
                                worksheet.get_Range(worksheet.Cells[7, 1], worksheet.Cells[num103, 1]).RowHeight = 0x15;
                                worksheet.get_Range(worksheet.Cells[7, 1], worksheet.Cells[num103, 3]).HorizontalAlignment = 3;
                                worksheet.get_Range(worksheet.Cells[7, 1], worksheet.Cells[num103, 3]).VerticalAlignment = 2;
                                worksheet.get_Range(worksheet.Cells[7, 1], worksheet.Cells[num103, num16]).Borders.LineStyle = 1;
                                worksheet.Select(updateLinks);
                                worksheet.get_Range("A1", "A1").Select();
                            }
                            else if (tableName.Trim().ToUpper() == "B26")
                            {
                                worksheet = application.Sheets[30] as Worksheet;
                                int num145 = worksheet.UsedRange.Rows.Count;
                                int num106 = (count + 5) - 1;
                                worksheet.get_Range("B2", "B2").Value2 = tjdwmc;
                                worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num106, num16]).EntireRow.Delete(updateLinks);
                                worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num106, num16]).Value2 = objArray;
                                worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num106, num16]).Font.Size = 10;
                                worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num106, 1]).RowHeight = 0x15;
                                worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num106, 3]).HorizontalAlignment = 3;
                                worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num106, 3]).VerticalAlignment = 2;
                                worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num106, num16]).Borders.LineStyle = 1;
                                worksheet.Select(updateLinks);
                                worksheet.get_Range("A1", "A1").Select();
                            }
                            else if (tableName.Trim().ToUpper() == "B27")
                            {
                                worksheet = application.Sheets[0x1f] as Worksheet;
                                int num146 = worksheet.UsedRange.Rows.Count;
                                int num109 = (count + 5) - 1;
                                worksheet.get_Range("B2", "B2").Value2 = tjdwmc;
                                worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num109, num16]).EntireRow.Delete(updateLinks);
                                worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num109, num16]).Value2 = objArray;
                                worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num109, num16]).Font.Size = 10;
                                worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num109, 1]).RowHeight = 0x15;
                                worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num109, 4]).HorizontalAlignment = 3;
                                worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num109, 4]).VerticalAlignment = 2;
                                worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num109, num16]).Borders.LineStyle = 1;
                                worksheet.Select(updateLinks);
                                worksheet.get_Range("A1", "A1").Select();
                            }
                            else if (tableName.Trim().ToUpper() == "B28")
                            {
                                worksheet = application.Sheets[0x20] as Worksheet;
                                int num147 = worksheet.UsedRange.Rows.Count;
                                int num112 = (count + 5) - 1;
                                worksheet.get_Range("B2", "B2").Value2 = tjdwmc;
                                worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num112, num16]).EntireRow.Delete(updateLinks);
                                worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num112, num16]).Value2 = objArray;
                                worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num112, num16]).Font.Size = 10;
                                worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num112, 1]).RowHeight = 0x15;
                                worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num112, 4]).HorizontalAlignment = 3;
                                worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num112, 4]).VerticalAlignment = 2;
                                worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num112, num16]).Borders.LineStyle = 1;
                                worksheet.Select(updateLinks);
                                worksheet.get_Range("A1", "A1").Select();
                            }
                            else if (tableName.Trim().ToUpper() == "B29")
                            {
                                worksheet = application.Sheets[0x21] as Worksheet;
                                int num148 = worksheet.UsedRange.Rows.Count;
                                int num115 = (count + 5) - 1;
                                worksheet.get_Range("B2", "B2").Value2 = tjdwmc;
                                worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num115, num16]).EntireRow.Delete(updateLinks);
                                worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num115, num16]).Value2 = objArray;
                                worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num115, num16]).Font.Size = 10;
                                worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num115, 1]).RowHeight = 0x15;
                                worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num115, 3]).HorizontalAlignment = 3;
                                worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num115, 3]).VerticalAlignment = 2;
                                worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num115, num16]).Borders.LineStyle = 1;
                                worksheet.Select(updateLinks);
                                worksheet.get_Range("A1", "A1").Select();
                            }
                            else if (tableName.Trim().ToUpper() == "B30")
                            {
                                worksheet = application.Sheets[0x22] as Worksheet;
                                int num149 = worksheet.UsedRange.Rows.Count;
                                int num118 = (count + 5) - 1;
                                worksheet.get_Range("B2", "B2").Value2 = tjdwmc;
                                worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num118, num16]).EntireRow.Delete(updateLinks);
                                worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num118, num16]).Value2 = objArray;
                                worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num118, num16]).Font.Size = 10;
                                worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num118, 1]).RowHeight = 0x15;
                                worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num118, 3]).HorizontalAlignment = 3;
                                worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num118, 3]).VerticalAlignment = 2;
                                worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num118, num16]).Borders.LineStyle = 1;
                                worksheet.Select(updateLinks);
                                worksheet.get_Range("A1", "A1").Select();
                            }
                            object to = application.ExecuteExcel4Macro("GET.DOCUMENT(50)");
                            worksheet.PrintOut(1, to, printcount, updateLinks, updateLinks, updateLinks, updateLinks, updateLinks);
                        }
                        worksheet = null;
                    }
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message.ToString(), "导出Microsoft.Office.Interop.Excel错误", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
                finally
                {
                    new Process();
                    Process[] processesByName = Process.GetProcessesByName("Microsoft.Office.Interop.Excel");
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
                    catch (Exception exception2)
                    {
                        exception2.ToString();
                    }
                    GC.Collect();
                }
            }
            else
            {
                string str = tjds.Tables[num].TableName;
                System.Data.DataTable table = tjds.Tables[num];
                if ((table != null) && (table.Rows.Count > 0))
                {
                    System.Data.DataTable table2 = new System.Data.DataTable("mytable");
                    if (str.Trim().ToUpper() == "B1")
                    {
                        table2.TableName = "B1";
                        foreach (DataColumn column in table.Columns)
                        {
                            DataColumn column2 = new DataColumn(column.ColumnName, typeof(string));
                            table2.Columns.Add(column2);
                        }
                        string str2 = "";
                        foreach (DataRow row in table.Rows)
                        {
                            DataRow row2 = table2.NewRow();
                            string str3 = row[0].ToString();
                            row2[0] = row[0];
                            if (str2 != str3)
                            {
                                str2 = str3;
                            }
                            else
                            {
                                row2[0] = "";
                            }
                            row2[1] = row[1];
                            for (int m = 2; m < (table.Columns.Count - 2); m++)
                            {
                                if (row[m] != DBNull.Value)
                                {
                                    string str4 = row[m].ToString();
                                    if (str4.IndexOf('.') < 0)
                                    {
                                        str4 = str4 + ".0";
                                    }
                                    if (Convert.ToDouble(row[m]) > 1000.0)
                                    {
                                        int num3 = ((int) Convert.ToDouble(row[m])) / 0x3e8;
                                        string str5 = Convert.ToString(num3);
                                        string str6 = str4.Substring(str5.Length, str4.Length - str5.Length);
                                        row2[m] = str5 + "\n\r" + str6;
                                    }
                                    else
                                    {
                                        row2[m] = "\n\r" + str4;
                                    }
                                }
                            }
                            row2[table.Columns.Count - 2] = row[table.Columns.Count - 2].ToString() + "\n\r" + row[table.Columns.Count - 1].ToString();
                            table2.Rows.Add(row2);
                        }
                        table2.Columns.RemoveAt(table2.Columns.Count - 1);
                    }
                    else if (str.Trim().ToUpper() == "B1-1")
                    {
                        table2.TableName = "B1-1";
                        foreach (DataColumn column3 in table.Columns)
                        {
                            DataColumn column4 = new DataColumn(column3.ColumnName, typeof(string));
                            table2.Columns.Add(column4);
                        }
                        string str7 = "";
                        foreach (DataRow row3 in table.Rows)
                        {
                            DataRow row4 = table2.NewRow();
                            string str8 = row3[0].ToString();
                            row4[0] = row3[0];
                            if (str7 != str8)
                            {
                                str7 = str8;
                            }
                            else
                            {
                                row4[0] = "";
                            }
                            for (int n = 1; n < (table.Columns.Count - 1); n++)
                            {
                                if (row3[n] != DBNull.Value)
                                {
                                    string str9 = row3[n].ToString();
                                    if (str9.IndexOf('.') < 0)
                                    {
                                        str9 = str9 + ".0";
                                    }
                                    if (Convert.ToDouble(row3[n]) > 1000.0)
                                    {
                                        int num5 = ((int) Convert.ToDouble(row3[n])) / 0x3e8;
                                        string str10 = Convert.ToString(num5);
                                        string str11 = str9.Substring(str10.Length, str9.Length - str10.Length);
                                        row4[n] = str10 + "\n\r" + str11;
                                    }
                                    else
                                    {
                                        row4[n] = "\n\r" + str9;
                                    }
                                }
                            }
                            row4[table.Columns.Count - 1] = row3[table.Columns.Count - 1].ToString();
                            table2.Rows.Add(row4);
                        }
                    }
                    else if (str.Trim().ToUpper() == "B2")
                    {
                        table2 = table.Copy();
                        table2.TableName = "B2";
                        string str12 = "";
                        foreach (DataRow row5 in table2.Rows)
                        {
                            string str13 = row5[0].ToString();
                            if (str12 != str13)
                            {
                                str12 = str13;
                            }
                            else
                            {
                                row5[0] = "";
                            }
                        }
                    }
                    else if (str.Trim().ToUpper() == "B2-1")
                    {
                        table2.TableName = "B2-1";
                        foreach (DataColumn column5 in table.Columns)
                        {
                            DataColumn column6 = new DataColumn(column5.ColumnName, typeof(string));
                            table2.Columns.Add(column6);
                        }
                        string str14 = "";
                        foreach (DataRow row6 in table.Rows)
                        {
                            DataRow row7 = table2.NewRow();
                            row7[0] = row6[0];
                            string str15 = row6[0].ToString();
                            if (str14 != str15)
                            {
                                str14 = str15;
                            }
                            else
                            {
                                row7[0] = "";
                            }
                            row7[1] = row6[1];
                            row7[2] = row6[2];
                            for (int num6 = 3; num6 < table.Columns.Count; num6++)
                            {
                                if (row6[num6] != DBNull.Value)
                                {
                                    string str16 = row6[num6].ToString();
                                    if (Convert.ToDouble(row6[num6]) > 10000.0)
                                    {
                                        int num7 = ((int) Convert.ToDouble(row6[num6])) / 0x2710;
                                        string str17 = Convert.ToString(num7);
                                        string str18 = str16.Substring(str17.Length, str16.Length - str17.Length);
                                        row7[num6] = str17 + "\n\r" + str18;
                                    }
                                    else
                                    {
                                        row7[num6] = "\n\r" + str16;
                                    }
                                }
                            }
                            table2.Rows.Add(row7);
                        }
                    }
                    else if (str.Trim().ToUpper() == "B3")
                    {
                        table2.TableName = "B3";
                        foreach (DataColumn column7 in table.Columns)
                        {
                            DataColumn column8 = new DataColumn(column7.ColumnName, typeof(string));
                            table2.Columns.Add(column8);
                        }
                        string str19 = "";
                        foreach (DataRow row8 in table.Rows)
                        {
                            DataRow row9 = table2.NewRow();
                            row9[0] = row8[0];
                            string str20 = row8[0].ToString();
                            if (str19 != str20)
                            {
                                str19 = str20;
                            }
                            else
                            {
                                row9[0] = "";
                            }
                            row9[1] = row8[1];
                            row9[2] = row8[2];
                            for (int num8 = 2; num8 < table.Columns.Count; num8++)
                            {
                                if (row8[num8] != DBNull.Value)
                                {
                                    string str21 = row8[num8].ToString();
                                    if (Convert.ToDouble(row8[num8]) > 10000.0)
                                    {
                                        int num9 = ((int) Convert.ToDouble(row8[num8])) / 0x2710;
                                        string str22 = Convert.ToString(num9);
                                        string str23 = str21.Substring(str22.Length, str21.Length - str22.Length);
                                        row9[num8] = str22 + "\n\r" + str23;
                                    }
                                    else
                                    {
                                        row9[num8] = "\n\r" + str21;
                                    }
                                }
                            }
                            table2.Rows.Add(row9);
                        }
                    }
                    else if (str.Trim().ToUpper() == "B4")
                    {
                        table2 = table.Copy();
                        table2.TableName = "B4";
                        string str24 = "";
                        foreach (DataRow row10 in table2.Rows)
                        {
                            string str25 = row10[0].ToString();
                            if (str24 != str25)
                            {
                                str24 = str25;
                            }
                            else
                            {
                                row10[0] = "";
                            }
                        }
                    }
                    else if (str.Trim().ToUpper() == "B5")
                    {
                        table2.TableName = "B5";
                        foreach (DataColumn column9 in table.Columns)
                        {
                            DataColumn column10 = new DataColumn(column9.ColumnName, typeof(string));
                            table2.Columns.Add(column10);
                        }
                        string str26 = "";
                        foreach (DataRow row11 in table.Rows)
                        {
                            DataRow row12 = table2.NewRow();
                            row12[0] = row11[0];
                            string str27 = row11[0].ToString();
                            if (str26 != str27)
                            {
                                str26 = str27;
                            }
                            else
                            {
                                row12[0] = "";
                            }
                            row12[1] = row11[1];
                            row12[2] = row11[2];
                            row12[3] = row11[3];
                            for (int num10 = 4; num10 < table.Columns.Count; num10++)
                            {
                                if (row11[num10] != DBNull.Value)
                                {
                                    string str28 = row11[num10].ToString();
                                    if (str28.IndexOf('.') < 0)
                                    {
                                        str28 = str28 + ".0";
                                    }
                                    if (Convert.ToDouble(row11[num10]) > 1000.0)
                                    {
                                        int num11 = ((int) Convert.ToDouble(row11[num10])) / 0x3e8;
                                        string str29 = Convert.ToString(num11);
                                        string str30 = str28.Substring(str29.Length, str28.Length - str29.Length);
                                        row12[num10] = str29 + "\n\r" + str30;
                                    }
                                    else
                                    {
                                        row12[num10] = "\n\r" + str28;
                                    }
                                }
                            }
                            table2.Rows.Add(row12);
                        }
                    }
                    else if (str.Trim().ToUpper() == "B6")
                    {
                        table2 = table.Copy();
                        table2.TableName = "B6";
                        string str31 = "";
                        foreach (DataRow row13 in table2.Rows)
                        {
                            string str32 = row13[0].ToString();
                            if (str31 != str32)
                            {
                                str31 = str32;
                            }
                            else
                            {
                                row13[0] = "";
                            }
                        }
                    }
                    else if (str.Trim().ToUpper() == "B7")
                    {
                        table2 = table.Copy();
                        table2.TableName = "B7";
                        string str33 = "";
                        foreach (DataRow row14 in table2.Rows)
                        {
                            string str34 = row14[0].ToString();
                            if (str33 != str34)
                            {
                                str33 = str34;
                            }
                            else
                            {
                                row14[0] = "";
                            }
                        }
                    }
                    else if (str.Trim().ToUpper() == "B8")
                    {
                        table2 = table.Copy();
                        table2.TableName = "B8";
                        string str35 = "";
                        foreach (DataRow row15 in table2.Rows)
                        {
                            string str36 = row15[0].ToString();
                            if (str35 != str36)
                            {
                                str35 = str36;
                            }
                            else
                            {
                                row15[0] = "";
                            }
                        }
                    }
                    else if (str.Trim().ToUpper() == "B9")
                    {
                        table2 = table.Copy();
                        table2.TableName = "B9";
                        string str37 = "";
                        foreach (DataRow row16 in table2.Rows)
                        {
                            string str38 = row16[0].ToString();
                            if (str37 != str38)
                            {
                                str37 = str38;
                            }
                            else
                            {
                                row16[0] = "";
                            }
                        }
                    }
                    else if (str.Trim().ToUpper() == "B10")
                    {
                        table2 = table.Copy();
                        table2.TableName = "B10";
                        string str39 = "";
                        foreach (DataRow row17 in table2.Rows)
                        {
                            string str40 = row17[0].ToString();
                            if (str39 != str40)
                            {
                                str39 = str40;
                            }
                            else
                            {
                                row17[0] = "";
                            }
                        }
                    }
                    else if (str.Trim().ToUpper() == "B11")
                    {
                        table2 = table.Copy();
                        table2.TableName = "B11";
                        string str41 = "";
                        foreach (DataRow row18 in table2.Rows)
                        {
                            string str42 = row18[0].ToString();
                            if (str41 != str42)
                            {
                                str41 = str42;
                            }
                            else
                            {
                                row18[0] = "";
                            }
                        }
                    }
                    else if (str.Trim().ToUpper() == "B11-1")
                    {
                        table2 = table.Copy();
                        table2.TableName = "B11-1";
                        string str43 = "";
                        foreach (DataRow row19 in table2.Rows)
                        {
                            string str44 = row19[0].ToString();
                            if (str43 != str44)
                            {
                                str43 = str44;
                            }
                            else
                            {
                                row19[0] = "";
                            }
                        }
                    }
                    else if (str.Trim().ToUpper() == "B12")
                    {
                        table2 = table.Copy();
                        table2.TableName = "B12";
                        string str45 = "";
                        foreach (DataRow row20 in table2.Rows)
                        {
                            string str46 = row20[0].ToString();
                            if (str45 != str46)
                            {
                                str45 = str46;
                            }
                            else
                            {
                                row20[0] = "";
                            }
                        }
                    }
                    else if (str.Trim().ToUpper() == "B13")
                    {
                        table2 = table.Copy();
                        table2.TableName = "B13";
                        string str47 = "";
                        foreach (DataRow row21 in table2.Rows)
                        {
                            string str48 = row21[0].ToString();
                            if (str47 != str48)
                            {
                                str47 = str48;
                            }
                            else
                            {
                                row21[0] = "";
                            }
                        }
                    }
                    else if (str.Trim().ToUpper() == "B14")
                    {
                        table2 = table.Copy();
                        table2.TableName = "B14";
                        string str49 = "";
                        foreach (DataRow row22 in table2.Rows)
                        {
                            string str50 = row22[0].ToString();
                            if (str49 != str50)
                            {
                                str49 = str50;
                            }
                            else
                            {
                                row22[0] = "";
                            }
                        }
                    }
                    else if (str.Trim().ToUpper() == "B15")
                    {
                        table2 = table.Copy();
                        table2.TableName = "B15";
                        string str51 = "";
                        foreach (DataRow row23 in table2.Rows)
                        {
                            string str52 = row23[0].ToString();
                            if (str51 != str52)
                            {
                                str51 = str52;
                            }
                            else
                            {
                                row23[0] = "";
                            }
                        }
                    }
                    else if (str.Trim().ToUpper() == "B16")
                    {
                        table2 = table.Copy();
                        table2.TableName = "B16";
                        string str53 = "";
                        foreach (DataRow row24 in table2.Rows)
                        {
                            string str54 = row24[0].ToString();
                            if (str53 != str54)
                            {
                                str53 = str54;
                            }
                            else
                            {
                                row24[0] = "";
                            }
                        }
                    }
                    else if (str.Trim().ToUpper() == "B17")
                    {
                        table2 = table.Copy();
                        table2.TableName = "B17";
                        string str55 = "";
                        foreach (DataRow row25 in table2.Rows)
                        {
                            string str56 = row25[0].ToString();
                            if (str55 != str56)
                            {
                                str55 = str56;
                            }
                            else
                            {
                                row25[0] = "";
                            }
                        }
                    }
                    else if (str.Trim().ToUpper() == "B18")
                    {
                        table2 = table.Copy();
                        table2.TableName = "B18";
                        string str57 = "";
                        foreach (DataRow row26 in table2.Rows)
                        {
                            string str58 = row26[0].ToString();
                            if (str57 != str58)
                            {
                                str57 = str58;
                            }
                            else
                            {
                                row26[0] = "";
                            }
                        }
                    }
                    else if (str.Trim().ToUpper() == "B19")
                    {
                        table2 = table.Copy();
                        table2.TableName = "B19";
                        string str59 = "";
                        foreach (DataRow row27 in table2.Rows)
                        {
                            string str60 = row27[0].ToString();
                            if (str59 != str60)
                            {
                                str59 = str60;
                            }
                            else
                            {
                                row27[0] = "";
                            }
                        }
                    }
                    else if (str.Trim().ToUpper() == "B20")
                    {
                        table2 = table.Copy();
                        table2.TableName = "B20";
                        string str61 = "";
                        foreach (DataRow row28 in table2.Rows)
                        {
                            string str62 = row28[0].ToString();
                            if (str61 != str62)
                            {
                                str61 = str62;
                            }
                            else
                            {
                                row28[0] = "";
                            }
                        }
                    }
                    else if (str.Trim().ToUpper() == "B21")
                    {
                        table2 = table.Copy();
                        table2.TableName = "B21";
                        string str63 = "";
                        foreach (DataRow row29 in table2.Rows)
                        {
                            string str64 = row29[0].ToString();
                            if (str63 != str64)
                            {
                                str63 = str64;
                            }
                            else
                            {
                                row29[0] = "";
                            }
                        }
                    }
                    else if (str.Trim().ToUpper() == "B22")
                    {
                        table2 = table.Copy();
                        table2.TableName = "B22";
                        string str65 = "";
                        foreach (DataRow row30 in table2.Rows)
                        {
                            string str66 = row30[0].ToString();
                            if (str65 != str66)
                            {
                                str65 = str66;
                            }
                            else
                            {
                                row30[0] = "";
                            }
                        }
                    }
                    else if (str.Trim().ToUpper() == "B23")
                    {
                        table2.TableName = "B23";
                        foreach (DataColumn column11 in table.Columns)
                        {
                            DataColumn column12 = new DataColumn(column11.ColumnName, typeof(string));
                            table2.Columns.Add(column12);
                        }
                        string str67 = "";
                        foreach (DataRow row31 in table.Rows)
                        {
                            DataRow row32 = table2.NewRow();
                            string str68 = row31[0].ToString();
                            row32[0] = row31[0];
                            if (str67 != str68)
                            {
                                str67 = str68;
                            }
                            else
                            {
                                row32[0] = "";
                            }
                            row32[1] = row31[1];
                            for (int num12 = 2; num12 < (table.Columns.Count - 2); num12++)
                            {
                                if (row31[num12] != DBNull.Value)
                                {
                                    string str69 = row31[num12].ToString();
                                    if (str69.IndexOf('.') < 0)
                                    {
                                        str69 = str69 + ".0";
                                    }
                                    if (Convert.ToDouble(row31[num12]) > 1000.0)
                                    {
                                        int num13 = ((int) Convert.ToDouble(row31[num12])) / 0x3e8;
                                        string str70 = Convert.ToString(num13);
                                        string str71 = str69.Substring(str70.Length, str69.Length - str70.Length);
                                        row32[num12] = str70 + "\n\r" + str71;
                                    }
                                    else
                                    {
                                        row32[num12] = "\n\r" + str69;
                                    }
                                }
                            }
                            row32[table.Columns.Count - 1] = row31[table.Columns.Count - 1];
                            row32[table.Columns.Count - 2] = row31[table.Columns.Count - 2];
                            table2.Rows.Add(row32);
                        }
                    }
                    else if (str.Trim().ToUpper() == "B24")
                    {
                        table2 = table.Copy();
                        table2.TableName = "B24";
                        string str72 = "";
                        foreach (DataRow row33 in table2.Rows)
                        {
                            string str73 = row33[0].ToString();
                            if (str72 != str73)
                            {
                                str72 = str73;
                            }
                            else
                            {
                                row33[0] = "";
                            }
                        }
                    }
                    else if (str.Trim().ToUpper() == "B25")
                    {
                        table2 = table.Copy();
                        table2.TableName = "B25";
                        string str74 = "";
                        foreach (DataRow row34 in table2.Rows)
                        {
                            string str75 = row34[0].ToString();
                            if (str74 != str75)
                            {
                                str74 = str75;
                            }
                            else
                            {
                                row34[0] = "";
                            }
                        }
                    }
                    else if (str.Trim().ToUpper() == "B26")
                    {
                        table2 = table.Copy();
                        table2.TableName = "B26";
                        string str76 = "";
                        foreach (DataRow row35 in table2.Rows)
                        {
                            string str77 = row35[0].ToString();
                            if (str76 != str77)
                            {
                                str76 = str77;
                            }
                            else
                            {
                                row35[0] = "";
                            }
                        }
                    }
                    else if (str.Trim().ToUpper() == "B27")
                    {
                        table2 = table.Copy();
                        table2.TableName = "B27";
                        string str78 = "";
                        foreach (DataRow row36 in table2.Rows)
                        {
                            string str79 = row36[0].ToString();
                            if (str78 != str79)
                            {
                                str78 = str79;
                            }
                            else
                            {
                                row36[0] = "";
                            }
                        }
                    }
                    else if (str.Trim().ToUpper() == "B28")
                    {
                        table2 = table.Copy();
                        table2.TableName = "B28";
                        string str80 = "";
                        foreach (DataRow row37 in table2.Rows)
                        {
                            string str81 = row37[0].ToString();
                            if (str80 != str81)
                            {
                                str80 = str81;
                            }
                            else
                            {
                                row37[0] = "";
                            }
                        }
                    }
                    else if (str.Trim().ToUpper() == "B29")
                    {
                        table2 = table.Copy();
                        table2.TableName = "B29";
                        string str82 = "";
                        foreach (DataRow row38 in table2.Rows)
                        {
                            string str83 = row38[0].ToString();
                            if (str82 != str83)
                            {
                                str82 = str83;
                            }
                            else
                            {
                                row38[0] = "";
                            }
                        }
                    }
                    else if (str.Trim().ToUpper() == "B30")
                    {
                        table2 = table.Copy();
                        table2.TableName = "B30";
                        string str84 = "";
                        foreach (DataRow row39 in table2.Rows)
                        {
                            string str85 = row39[0].ToString();
                            if (str84 != str85)
                            {
                                str84 = str85;
                            }
                            else
                            {
                                row39[0] = "";
                            }
                        }
                    }
                    set.Tables.Add(table2);
                }
                num++;
                goto Label_0058;
            }
        }

        public void ExportGJBHTJB(string tjdwmc, string tjnd, DataSet tjds, string xlsModelPath, string xlsTargetPath)
        {
            if (!File.Exists(xlsModelPath))
            {
                MessageBox.Show(xlsModelPath + " 不存在，请检查!", "错误", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else
            {
                int num = 0;
                while (true)
                {
                    if (num >= tjds.Tables.Count)
                    {
                        break;
                    }
                    System.Data.DataTable table = tjds.Tables[num];
                    string tableName = table.TableName;
                    if (tableName.Trim().ToUpper() == "B1")
                    {
                        string str2 = "";
                        string str3 = "";
                        foreach (DataRow row in table.Rows)
                        {
                            string str4 = row[0].ToString();
                            if (str2 != str4)
                            {
                                str2 = str4;
                            }
                            else
                            {
                                row[0] = "";
                            }
                            string str5 = row[1].ToString();
                            if (str3 != str5)
                            {
                                str3 = str5;
                            }
                            else
                            {
                                row[1] = "";
                            }
                        }
                    }
                    else if (tableName.Trim().ToUpper() == "B2")
                    {
                        string str6 = "";
                        foreach (DataRow row2 in table.Rows)
                        {
                            string str7 = row2[0].ToString();
                            if (str6 != str7)
                            {
                                str6 = str7;
                            }
                            else
                            {
                                row2[0] = "";
                            }
                        }
                    }
                    else if (tableName.Trim().ToUpper() == "B3")
                    {
                        string str8 = "";
                        foreach (DataRow row3 in table.Rows)
                        {
                            string str9 = row3[0].ToString();
                            if (str8 != str9)
                            {
                                str8 = str9;
                            }
                            else
                            {
                                row3[0] = "";
                            }
                        }
                    }
                    else if (tableName.Trim().ToUpper() == "B4")
                    {
                        string str10 = "";
                        foreach (DataRow row4 in table.Rows)
                        {
                            string str11 = row4[0].ToString();
                            if (str10 != str11)
                            {
                                str10 = str11;
                            }
                            else
                            {
                                row4[0] = "";
                            }
                        }
                    }
                    else if (tableName.Trim().ToUpper() == "B5")
                    {
                        string str12 = "";
                        string str13 = "";
                        foreach (DataRow row5 in table.Rows)
                        {
                            string str14 = row5[0].ToString();
                            if (str12 != str14)
                            {
                                str12 = str14;
                            }
                            else
                            {
                                row5[0] = "";
                            }
                            string str15 = row5[1].ToString();
                            if (str13 != str15)
                            {
                                str13 = str15;
                            }
                            else
                            {
                                row5[1] = "";
                            }
                        }
                    }
                    num++;
                }
                File.Copy(xlsModelPath, xlsTargetPath, true);
                Microsoft.Office.Interop.Excel.Application application = new ApplicationClass();
                try
                {
                    if (application == null)
                    {
                        MessageBox.Show("不能建立EXCEL对象，请在机器上安装MS Office软件！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    }
                    else
                    {
                        object updateLinks = Missing.Value;
                        string filename = xlsTargetPath;
                        Workbook workbook = application.Workbooks.Open(filename, updateLinks, updateLinks, updateLinks, updateLinks, updateLinks, updateLinks, updateLinks, updateLinks, updateLinks, updateLinks, updateLinks, updateLinks, updateLinks, updateLinks);
                        application.Visible = false;
                        application.DisplayAlerts = false;
                        Worksheet worksheet = null;
                        application.ActiveWindow.DisplayZeros = false;
                        for (int i = 0; i < tjds.Tables.Count; i++)
                        {
                            System.Data.DataTable table2 = tjds.Tables[i];
                            string str17 = table2.TableName;
                            int count = table2.Rows.Count;
                            int num4 = table2.Columns.Count;
                            object[,] objArray = new object[count, num4];
                            for (int j = 0; j < count; j++)
                            {
                                for (int k = 0; k < num4; k++)
                                {
                                    objArray[j, k] = table2.Rows[j][k];
                                }
                            }
                            if (str17.Trim().ToUpper() == "B1")
                            {
                                worksheet = application.Sheets[1] as Worksheet;
                                int num7 = worksheet.UsedRange.Rows.Count;
                                worksheet.get_Range("A2", "A2").Value2 = tjnd + "年";
                                worksheet.get_Range("B2", "B2").Value2 = "广西壮族自治区";
                                worksheet.get_Range("D2", "D2").Value2 = tjdwmc + "林业局";
                                int num9 = (count + 8) - 1;
                                worksheet.get_Range(worksheet.Cells[8, 1], worksheet.Cells[num7 + 7, num4]).EntireRow.Delete(updateLinks);
                                worksheet.get_Range(worksheet.Cells[8, 1], worksheet.Cells[num9, num4]).Value2 = objArray;
                                worksheet.get_Range(worksheet.Cells[8, 1], worksheet.Cells[num9, num4]).Font.Size = 10;
                                worksheet.get_Range(worksheet.Cells[8, 1], worksheet.Cells[num9, num4]).RowHeight = 0x12;
                                worksheet.get_Range(worksheet.Cells[8, 1], worksheet.Cells[num9, 2]).VerticalAlignment = XlVAlign.xlVAlignCenter;
                                worksheet.get_Range(worksheet.Cells[8, 1], worksheet.Cells[num9, num4]).Borders.LineStyle = 1;
                                worksheet.Select(updateLinks);
                                worksheet.get_Range("A1", "A1").Select();
                            }
                            else if (str17.Trim().ToUpper() == "B2")
                            {
                                worksheet = application.Sheets[2] as Worksheet;
                                int num1 = worksheet.UsedRange.Rows.Count;
                                int num12 = (count + 8) - 1;
                                worksheet.get_Range("A2", "A2").Value2 = tjnd + "年";
                                worksheet.get_Range("B2", "B2").Value2 = "广西壮族自治区";
                                worksheet.get_Range("D2", "D2").Value2 = tjdwmc + "林业局";
                                worksheet.get_Range(worksheet.Cells[8, 1], worksheet.Cells[num12, num4]).EntireRow.Delete(updateLinks);
                                worksheet.get_Range(worksheet.Cells[8, 1], worksheet.Cells[num12, num4]).Value2 = objArray;
                                worksheet.get_Range(worksheet.Cells[8, 1], worksheet.Cells[num12, num4]).Font.Size = 10;
                                application.DisplayAlerts = false;
                                worksheet.get_Range(worksheet.Cells[8, 1], worksheet.Cells[num12, 2]).HorizontalAlignment = 3;
                                worksheet.get_Range(worksheet.Cells[8, 1], worksheet.Cells[num12, 2]).VerticalAlignment = 2;
                                worksheet.get_Range(worksheet.Cells[8, 1], worksheet.Cells[num12, num4]).Borders.LineStyle = 1;
                                worksheet.Select(updateLinks);
                                worksheet.get_Range("A1", "A1").Select();
                            }
                            else if (str17.Trim().ToUpper() == "B3")
                            {
                                worksheet = application.Sheets[3] as Worksheet;
                                int num23 = worksheet.UsedRange.Rows.Count;
                                int num15 = (count + 8) - 1;
                                worksheet.get_Range("A2", "A2").Value2 = tjnd + "年";
                                worksheet.get_Range("B2", "B2").Value2 = "广西壮族自治区";
                                worksheet.get_Range("D2", "D2").Value2 = tjdwmc + "林业局";
                                worksheet.get_Range(worksheet.Cells[8, 1], worksheet.Cells[num15, num4]).EntireRow.Delete(updateLinks);
                                worksheet.get_Range(worksheet.Cells[8, 1], worksheet.Cells[num15, num4]).Value2 = objArray;
                                worksheet.get_Range(worksheet.Cells[8, 1], worksheet.Cells[num15, num4]).Font.Size = 10;
                                worksheet.get_Range(worksheet.Cells[8, 1], worksheet.Cells[num15, 2]).HorizontalAlignment = XlHAlign.xlHAlignCenter;
                                worksheet.get_Range(worksheet.Cells[8, 1], worksheet.Cells[num15, num4]).Borders.LineStyle = 1;
                                worksheet.Select(updateLinks);
                                worksheet.get_Range("A1", "A1").Select();
                            }
                            else if (str17.Trim().ToUpper() == "B4")
                            {
                                worksheet = application.Sheets[4] as Worksheet;
                                int num24 = worksheet.UsedRange.Rows.Count;
                                int num18 = (count + 5) - 1;
                                worksheet.get_Range("A2", "A2").Value2 = "广西壮族自治区";
                                worksheet.get_Range("C2", "C2").Value2 = tjdwmc + "林业局";
                                worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num18, num4]).EntireRow.Delete(updateLinks);
                                worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num18, num4]).Value2 = objArray;
                                worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num18, num4]).Font.Size = 10;
                                worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num18, 5]).HorizontalAlignment = 3;
                                worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num18, 5]).VerticalAlignment = 2;
                                worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num18, num4]).Borders.LineStyle = 1;
                                worksheet.Select(updateLinks);
                                worksheet.get_Range("A1", "A1").Select();
                            }
                            else if (str17.Trim().ToUpper() == "B5")
                            {
                                worksheet = application.Sheets[5] as Worksheet;
                                int num25 = worksheet.UsedRange.Rows.Count;
                                int num21 = (count + 6) - 1;
                                worksheet.get_Range("A2", "A2").Value2 = "广西壮族自治区";
                                worksheet.get_Range("C2", "C2").Value2 = tjdwmc + "林业局";
                                worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num21, num4]).EntireRow.Delete(updateLinks);
                                worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num21, num4]).Value2 = objArray;
                                worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num21, num4]).Font.Size = 10;
                                worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num21, 3]).WrapText = true;
                                worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num21, 4]).HorizontalAlignment = 3;
                                worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num21, num4]).Borders.LineStyle = 1;
                                worksheet.Select(updateLinks);
                                worksheet.get_Range("A1", "A1").Select();
                            }
                        }
                        worksheet = null;
                        workbook.Save();
                        workbook.Close(false, xlsTargetPath, false);
                        workbook = null;
                    }
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message.ToString(), "导出EXCEL错误", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
                finally
                {
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
                    catch (Exception exception2)
                    {
                        exception2.ToString();
                    }
                    GC.Collect();
                }
            }
        }

        public void ExportZYBHTJB(string tjdwmc, DataSet tjds, string xlsModelPath, string xlsTargetPath)
        {
            if (!File.Exists(xlsModelPath))
            {
                MessageBox.Show(xlsModelPath + " 不存在，请检查!", "错误", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else
            {
                File.Copy(xlsModelPath, xlsTargetPath, true);
                Microsoft.Office.Interop.Excel.Application application = new ApplicationClass();
                try
                {
                    if (application == null)
                    {
                        MessageBox.Show("不能建立EXCEL对象，请在机器上安装MS Office软件！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    }
                    else
                    {
                        object updateLinks = Missing.Value;
                        string filename = xlsTargetPath;
                        Workbook workbook = application.Workbooks.Open(filename, updateLinks, updateLinks, updateLinks, updateLinks, updateLinks, updateLinks, updateLinks, updateLinks, updateLinks, updateLinks, updateLinks, updateLinks, updateLinks, updateLinks);
                        application.Visible = false;
                        application.DisplayAlerts = false;
                        Worksheet worksheet = null;
                        application.ActiveWindow.DisplayZeros = false;
                        for (int i = 0; i < tjds.Tables.Count; i++)
                        {
                            System.Data.DataTable table = tjds.Tables[i];
                            string tableName = table.TableName;
                            int count = table.Rows.Count;
                            int num3 = table.Columns.Count;
                            object[,] objArray = new object[count, num3];
                            for (int j = 0; j < count; j++)
                            {
                                for (int k = 0; k < num3; k++)
                                {
                                    objArray[j, k] = table.Rows[j][k];
                                }
                            }
                            if (tableName.Trim().ToUpper() == "B1")
                            {
                                worksheet = application.Sheets[1] as Worksheet;
                                int num6 = worksheet.UsedRange.Rows.Count;
                                worksheet.get_Range("B2", "B2").Value2 = tjdwmc;
                                int num8 = (count + 8) - 1;
                                worksheet.get_Range(worksheet.Cells[8, 1], worksheet.Cells[num6 + 7, num3]).EntireRow.Delete(updateLinks);
                                worksheet.get_Range(worksheet.Cells[8, 1], worksheet.Cells[num8, num3]).Value2 = objArray;
                                worksheet.get_Range(worksheet.Cells[8, 1], worksheet.Cells[num8, num3]).Font.Size = 10;
                                worksheet.get_Range(worksheet.Cells[8, 1], worksheet.Cells[num8, num3]).Columns.AutoFit();
                                worksheet.get_Range(worksheet.Cells[8, 1], worksheet.Cells[num8, 2]).VerticalAlignment = XlVAlign.xlVAlignCenter;
                                worksheet.get_Range(worksheet.Cells[8, 1], worksheet.Cells[num8, num3]).Borders.LineStyle = 1;
                                worksheet.Select(updateLinks);
                                worksheet.get_Range("A1", "A1").Select();
                            }
                            else if (tableName.Trim().ToUpper() == "B2")
                            {
                                worksheet = application.Sheets[2] as Worksheet;
                                int num1 = worksheet.UsedRange.Rows.Count;
                                int num11 = (count + 8) - 1;
                                worksheet.get_Range("B2", "B2").Value2 = tjdwmc;
                                worksheet.get_Range(worksheet.Cells[8, 1], worksheet.Cells[num11, num3]).EntireRow.Delete(updateLinks);
                                worksheet.get_Range(worksheet.Cells[8, 1], worksheet.Cells[num11, num3]).Value2 = objArray;
                                worksheet.get_Range(worksheet.Cells[8, 1], worksheet.Cells[num11, num3]).Font.Size = 10;
                                worksheet.get_Range(worksheet.Cells[8, 1], worksheet.Cells[num11, num3]).Columns.AutoFit();
                                worksheet.get_Range(worksheet.Cells[8, 1], worksheet.Cells[num11, 2]).HorizontalAlignment = 3;
                                worksheet.get_Range(worksheet.Cells[8, 1], worksheet.Cells[num11, 2]).VerticalAlignment = 2;
                                worksheet.get_Range(worksheet.Cells[8, 1], worksheet.Cells[num11, num3]).Borders.LineStyle = 1;
                                worksheet.Select(updateLinks);
                                worksheet.get_Range("A1", "A1").Select();
                            }
                            else if (tableName.Trim().ToUpper() == "B3")
                            {
                                worksheet = application.Sheets[3] as Worksheet;
                                int num22 = worksheet.UsedRange.Rows.Count;
                                int num14 = (count + 6) - 1;
                                worksheet.get_Range("B2", "B2").Value2 = tjdwmc;
                                worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num14, num3]).EntireRow.Delete(updateLinks);
                                worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num14, num3]).Value2 = objArray;
                                worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num14, num3]).Font.Size = 10;
                                worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num14, num3]).Columns.AutoFit();
                                worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num14, 2]).HorizontalAlignment = XlHAlign.xlHAlignCenter;
                                worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num14, num3]).Borders.LineStyle = 1;
                                worksheet.Select(updateLinks);
                                worksheet.get_Range("A1", "A1").Select();
                            }
                            else if (tableName.Trim().ToUpper() == "B4")
                            {
                                worksheet = application.Sheets[4] as Worksheet;
                                int num23 = worksheet.UsedRange.Rows.Count;
                                int num17 = (count + 6) - 1;
                                worksheet.get_Range("B2", "B2").Value2 = tjdwmc;
                                worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num17, num3]).EntireRow.Delete(updateLinks);
                                worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num17, num3]).Value2 = objArray;
                                worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num17, num3]).Font.Size = 10;
                                worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num17, num3]).Columns.AutoFit();
                                worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num17, 5]).HorizontalAlignment = 3;
                                worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num17, 5]).VerticalAlignment = 2;
                                worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num17, num3]).Borders.LineStyle = 1;
                                worksheet.Select(updateLinks);
                                worksheet.get_Range("A1", "A1").Select();
                            }
                            else if (tableName.Trim().ToUpper() == "B5")
                            {
                                worksheet = application.Sheets[5] as Worksheet;
                                int num24 = worksheet.UsedRange.Rows.Count;
                                int num20 = (count + 6) - 1;
                                worksheet.get_Range("B2", "B2").Value2 = tjdwmc;
                                worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num20, num3]).EntireRow.Delete(updateLinks);
                                worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num20, num3]).Value2 = objArray;
                                worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num20, num3]).Font.Size = 10;
                                worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num20, num3]).Columns.AutoFit();
                                worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num20, 4]).HorizontalAlignment = 3;
                                worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num20, num3]).Borders.LineStyle = 1;
                                worksheet.Select(updateLinks);
                                worksheet.get_Range("A1", "A1").Select();
                            }
                        }
                        worksheet = null;
                        workbook.Save();
                        workbook.Close(false, xlsTargetPath, false);
                        workbook = null;
                    }
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message.ToString(), "导出EXCEL错误", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
                finally
                {
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
                    catch (Exception exception2)
                    {
                        exception2.ToString();
                    }
                    GC.Collect();
                }
            }
        }

        public void ExportZYDCTJB(string tjdwmc, string tjnd, DataSet tjds, string xlsModelPath, string xlsTargetPath)
        {
            if (!File.Exists(xlsModelPath))
            {
                MessageBox.Show(xlsModelPath + " 不存在，请检查!", "错误", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else
            {
                File.Copy(xlsModelPath, xlsTargetPath, true);
                Microsoft.Office.Interop.Excel.Application application = new ApplicationClass();
                try
                {
                    int num2;
                    if (application == null)
                    {
                        MessageBox.Show("不能建立Microsoft.Office.Interop.Excel对象，请在机器上安装MS Office软件！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        return;
                    }
                    object updateLinks = Missing.Value;
                    string filename = xlsTargetPath;
                    Workbook workbook = application.Workbooks.Open(filename, updateLinks, updateLinks, updateLinks, updateLinks, updateLinks, updateLinks, updateLinks, updateLinks, updateLinks, updateLinks, updateLinks, updateLinks, updateLinks, updateLinks);
                    application.Visible = false;
                    application.DisplayAlerts = false;
                    Worksheet worksheet = null;
                    application.ActiveWindow.DisplayZeros = false;
                    new DataSet("resultds");
                    int num = 0;
                Label_009E:
                    if (num >= tjds.Tables.Count)
                    {
                        goto Label_21F7;
                    }
                    string tableName = tjds.Tables[num].TableName;
                    System.Data.DataTable table = tjds.Tables[num];
                    if ((table == null) || (table.Rows.Count <= 0))
                    {
                        goto Label_21DB;
                    }
                    if (tableName.Trim().ToUpper() == "B1")
                    {
                        string str3 = "";
                        foreach (DataRow row in table.Rows)
                        {
                            string str4 = row[0].ToString();
                            if (str3 != str4)
                            {
                                str3 = str4;
                            }
                            else
                            {
                                row[0] = "";
                            }
                        }
                    }
                    else if (tableName.Trim().ToUpper() == "B1-1")
                    {
                        string str5 = "";
                        string str6 = "";
                        foreach (DataRow row2 in table.Rows)
                        {
                            string str7 = row2[0].ToString();
                            if (str5 != str7)
                            {
                                str5 = str7;
                            }
                            else
                            {
                                row2[0] = "";
                            }
                            string str8 = row2[1].ToString();
                            if (str6 != str8)
                            {
                                str6 = str8;
                            }
                            else
                            {
                                row2[1] = "";
                            }
                        }
                    }
                    else if (tableName.Trim().ToUpper() == "B1-2")
                    {
                        string str9 = "";
                        foreach (DataRow row3 in table.Rows)
                        {
                            string str10 = row3[0].ToString();
                            if (str9 != str10)
                            {
                                str9 = str10;
                            }
                            else
                            {
                                row3[0] = "";
                            }
                        }
                    }
                    else if (tableName.Trim().ToUpper() == "B1-3")
                    {
                        string str11 = "";
                        foreach (DataRow row4 in table.Rows)
                        {
                            string str12 = row4[0].ToString();
                            if (str11 != str12)
                            {
                                str11 = str12;
                            }
                            else
                            {
                                row4[0] = "";
                            }
                        }
                    }
                    else if (tableName.Trim().ToUpper() == "B2")
                    {
                        string str13 = "";
                        foreach (DataRow row5 in table.Rows)
                        {
                            string str14 = row5[0].ToString();
                            if (str13 != str14)
                            {
                                str13 = str14;
                            }
                            else
                            {
                                row5[0] = "";
                            }
                        }
                    }
                    else if (tableName.Trim().ToUpper() == "B2-1")
                    {
                        string str15 = "";
                        string str16 = "";
                        foreach (DataRow row6 in table.Rows)
                        {
                            string str17 = row6[0].ToString();
                            if (str15 != str17)
                            {
                                str15 = str17;
                            }
                            else
                            {
                                row6[0] = "";
                            }
                            string str18 = row6[1].ToString();
                            if (str16 != str18)
                            {
                                str16 = str18;
                            }
                            else
                            {
                                row6[1] = "";
                            }
                        }
                    }
                    else if (tableName.Trim().ToUpper() == "B3")
                    {
                        string str19 = "";
                        string str20 = "";
                        foreach (DataRow row7 in table.Rows)
                        {
                            string str21 = row7[0].ToString();
                            if (str19 != str21)
                            {
                                str19 = str21;
                            }
                            else
                            {
                                row7[0] = "";
                            }
                            string str22 = row7[1].ToString();
                            if (str20 != str22)
                            {
                                str20 = str22;
                            }
                            else
                            {
                                row7[1] = "";
                            }
                        }
                    }
                    else if (tableName.Trim().ToUpper() == "B4")
                    {
                        string str23 = "";
                        string str24 = "";
                        string str25 = "";
                        foreach (DataRow row8 in table.Rows)
                        {
                            string str26 = row8[0].ToString();
                            if (str23 != str26)
                            {
                                str23 = str26;
                            }
                            else
                            {
                                row8[0] = "";
                            }
                            string str27 = row8[1].ToString();
                            if (str24 != str27)
                            {
                                str24 = str27;
                            }
                            else
                            {
                                row8[1] = "";
                            }
                            string str28 = row8[2].ToString();
                            if (str25 != str28)
                            {
                                str25 = str28;
                            }
                            else
                            {
                                row8[2] = "";
                            }
                        }
                    }
                    else if (tableName.Trim().ToUpper() == "B5")
                    {
                        string str29 = "";
                        string str30 = "";
                        string str31 = "";
                        foreach (DataRow row9 in table.Rows)
                        {
                            string str32 = row9[0].ToString();
                            if (str29 != str32)
                            {
                                str29 = str32;
                            }
                            else
                            {
                                row9[0] = "";
                            }
                            string str33 = row9[1].ToString();
                            if (str30 != str33)
                            {
                                str30 = str33;
                            }
                            else
                            {
                                row9[1] = "";
                            }
                            string str34 = row9[2].ToString();
                            if (str31 != str34)
                            {
                                str31 = str34;
                            }
                            else
                            {
                                row9[2] = "";
                            }
                        }
                    }
                    else if (tableName.Trim().ToUpper() == "B6")
                    {
                        string str35 = "";
                        string str36 = "";
                        string str37 = "";
                        foreach (DataRow row10 in table.Rows)
                        {
                            string str38 = row10[0].ToString();
                            if (str35 != str38)
                            {
                                str35 = str38;
                            }
                            else
                            {
                                row10[0] = "";
                            }
                            string str39 = row10[1].ToString();
                            if (str36 != str39)
                            {
                                str36 = str39;
                            }
                            else
                            {
                                row10[1] = "";
                            }
                            string str40 = row10[2].ToString();
                            if (str37 != str40)
                            {
                                str37 = str40;
                            }
                            else
                            {
                                row10[2] = "";
                            }
                        }
                    }
                    else if (tableName.Trim().ToUpper() == "B7")
                    {
                        string str41 = "";
                        string str42 = "";
                        string str43 = "";
                        foreach (DataRow row11 in table.Rows)
                        {
                            string str44 = row11[0].ToString();
                            if (str41 != str44)
                            {
                                str41 = str44;
                            }
                            else
                            {
                                row11[0] = "";
                            }
                            string str45 = row11[1].ToString();
                            if (str42 != str45)
                            {
                                str42 = str45;
                            }
                            else
                            {
                                row11[1] = "";
                            }
                            string str46 = row11[2].ToString();
                            if (str43 != str46)
                            {
                                str43 = str46;
                            }
                            else
                            {
                                row11[2] = "";
                            }
                        }
                    }
                    else if (tableName.Trim().ToUpper() == "B8")
                    {
                        string str47 = "";
                        string str48 = "";
                        foreach (DataRow row12 in table.Rows)
                        {
                            string str49 = row12[0].ToString();
                            if (str47 != str49)
                            {
                                str47 = str49;
                            }
                            else
                            {
                                row12[0] = "";
                            }
                            string str50 = row12[1].ToString();
                            if (str48 != str50)
                            {
                                str48 = str50;
                            }
                            else
                            {
                                row12[1] = "";
                            }
                        }
                    }
                    else if (tableName.Trim().ToUpper() == "B9")
                    {
                        string str51 = "";
                        string str52 = "";
                        string str53 = "";
                        foreach (DataRow row13 in table.Rows)
                        {
                            string str54 = row13[0].ToString();
                            if (str51 != str54)
                            {
                                str51 = str54;
                            }
                            else
                            {
                                row13[0] = "";
                            }
                            string str55 = row13[1].ToString();
                            if (str52 != str55)
                            {
                                str52 = str55;
                            }
                            else
                            {
                                row13[1] = "";
                            }
                            string str56 = row13[2].ToString();
                            if (str53 != str56)
                            {
                                str53 = str56;
                            }
                            else
                            {
                                row13[2] = "";
                            }
                        }
                    }
                    else if (tableName.Trim().ToUpper() == "B10")
                    {
                        string str57 = "";
                        string str58 = "";
                        string str59 = "";
                        foreach (DataRow row14 in table.Rows)
                        {
                            string str60 = row14[0].ToString();
                            if (str57 != str60)
                            {
                                str57 = str60;
                            }
                            else
                            {
                                row14[0] = "";
                            }
                            string str61 = row14[1].ToString();
                            if (str58 != str61)
                            {
                                str58 = str61;
                            }
                            else
                            {
                                row14[1] = "";
                            }
                            string str62 = row14[2].ToString();
                            if (str59 != str62)
                            {
                                str59 = str62;
                            }
                            else
                            {
                                row14[2] = "";
                            }
                        }
                    }
                    else if (tableName.Trim().ToUpper() == "B11")
                    {
                        string str63 = "";
                        string str64 = "";
                        foreach (DataRow row15 in table.Rows)
                        {
                            string str65 = row15[0].ToString();
                            if (str63 != str65)
                            {
                                str63 = str65;
                            }
                            else
                            {
                                row15[0] = "";
                            }
                            string str66 = row15[1].ToString();
                            if (str64 != str66)
                            {
                                str64 = str66;
                            }
                            else
                            {
                                row15[1] = "";
                            }
                        }
                    }
                    else if (tableName.Trim().ToUpper() == "B12")
                    {
                        string str67 = "";
                        string str68 = "";
                        string str69 = "";
                        foreach (DataRow row16 in table.Rows)
                        {
                            string str70 = row16[0].ToString();
                            if (str67 != str70)
                            {
                                str67 = str70;
                            }
                            else
                            {
                                row16[0] = "";
                            }
                            string str71 = row16[1].ToString();
                            if (str68 != str71)
                            {
                                str68 = str71;
                            }
                            else
                            {
                                row16[1] = "";
                            }
                            string str72 = row16[2].ToString();
                            if (str69 != str72)
                            {
                                str69 = str72;
                            }
                            else
                            {
                                row16[2] = "";
                            }
                        }
                    }
                    else if (tableName.Trim().ToUpper() == "B13")
                    {
                        string str73 = "";
                        string str74 = "";
                        string str75 = "";
                        foreach (DataRow row17 in table.Rows)
                        {
                            string str76 = row17[0].ToString();
                            if (str73 != str76)
                            {
                                str73 = str76;
                            }
                            else
                            {
                                row17[0] = "";
                            }
                            string str77 = row17[1].ToString();
                            if (str74 != str77)
                            {
                                str74 = str77;
                            }
                            else
                            {
                                row17[1] = "";
                            }
                            string str78 = row17[2].ToString();
                            if (str75 != str78)
                            {
                                str75 = str78;
                            }
                            else
                            {
                                row17[2] = "";
                            }
                        }
                    }
                    else if (tableName.Trim().ToUpper() == "B14")
                    {
                        string str79 = "";
                        string str80 = "";
                        foreach (DataRow row18 in table.Rows)
                        {
                            string str81 = row18[0].ToString();
                            if (str79 != str81)
                            {
                                str79 = str81;
                            }
                            else
                            {
                                row18[0] = "";
                            }
                            string str82 = row18[1].ToString();
                            if (str80 != str82)
                            {
                                str80 = str82;
                            }
                            else
                            {
                                row18[1] = "";
                            }
                        }
                    }
                    else if (tableName.Trim().ToUpper() == "B15")
                    {
                        string str83 = "";
                        string str84 = "";
                        string str85 = "";
                        foreach (DataRow row19 in table.Rows)
                        {
                            string str86 = row19[0].ToString();
                            if (str83 != str86)
                            {
                                str83 = str86;
                            }
                            else
                            {
                                row19[0] = "";
                            }
                            string str87 = row19[1].ToString();
                            if (str84 != str87)
                            {
                                str84 = str87;
                            }
                            else
                            {
                                row19[1] = "";
                            }
                            string str88 = row19[2].ToString();
                            if (str85 != str88)
                            {
                                str85 = str88;
                            }
                            else
                            {
                                row19[2] = "";
                            }
                        }
                    }
                    else if (tableName.Trim().ToUpper() == "B16")
                    {
                        string str89 = "";
                        string str90 = "";
                        string str91 = "";
                        foreach (DataRow row20 in table.Rows)
                        {
                            string str92 = row20[0].ToString();
                            if (str89 != str92)
                            {
                                str89 = str92;
                            }
                            else
                            {
                                row20[0] = "";
                            }
                            string str93 = row20[1].ToString();
                            if (str90 != str93)
                            {
                                str90 = str93;
                            }
                            else
                            {
                                row20[1] = "";
                            }
                            string str94 = row20[2].ToString();
                            if (str91 != str94)
                            {
                                str91 = str94;
                            }
                            else
                            {
                                row20[2] = "";
                            }
                        }
                    }
                    else if (tableName.Trim().ToUpper() == "B17")
                    {
                        string str95 = "";
                        string str96 = "";
                        foreach (DataRow row21 in table.Rows)
                        {
                            string str97 = row21[0].ToString();
                            if (str95 != str97)
                            {
                                str95 = str97;
                            }
                            else
                            {
                                row21[0] = "";
                            }
                            string str98 = row21[1].ToString();
                            if (str96 != str98)
                            {
                                str96 = str98;
                            }
                            else
                            {
                                row21[1] = "";
                            }
                        }
                    }
                    else if (tableName.Trim().ToUpper() == "B18")
                    {
                        string str99 = "";
                        string str100 = "";
                        string str101 = "";
                        foreach (DataRow row22 in table.Rows)
                        {
                            string str102 = row22[0].ToString();
                            if (str99 != str102)
                            {
                                str99 = str102;
                            }
                            else
                            {
                                row22[0] = "";
                            }
                            string str103 = row22[1].ToString();
                            if (str100 != str103)
                            {
                                str100 = str103;
                            }
                            else
                            {
                                row22[1] = "";
                            }
                            string str104 = row22[2].ToString();
                            if (str101 != str104)
                            {
                                str101 = str104;
                            }
                            else
                            {
                                row22[2] = "";
                            }
                        }
                    }
                    else if (tableName.Trim().ToUpper() == "B19")
                    {
                        string str105 = "";
                        foreach (DataRow row23 in table.Rows)
                        {
                            string str106 = row23[0].ToString();
                            if (str105 != str106)
                            {
                                str105 = str106;
                            }
                            else
                            {
                                row23[0] = "";
                            }
                        }
                    }
                    else if (tableName.Trim().ToUpper() == "B20")
                    {
                        string str107 = "";
                        foreach (DataRow row24 in table.Rows)
                        {
                            string str108 = row24[0].ToString();
                            if (str107 != str108)
                            {
                                str107 = str108;
                            }
                            else
                            {
                                row24[0] = "";
                            }
                        }
                    }
                    else if (tableName.Trim().ToUpper() == "B21")
                    {
                        string str109 = "";
                        foreach (DataRow row25 in table.Rows)
                        {
                            string str110 = row25[0].ToString();
                            if (str109 != str110)
                            {
                                str109 = str110;
                            }
                            else
                            {
                                row25[0] = "";
                            }
                        }
                    }
                    else if (tableName.Trim().ToUpper() == "B22")
                    {
                        string str111 = "";
                        foreach (DataRow row26 in table.Rows)
                        {
                            string str112 = row26[0].ToString();
                            if (str111 != str112)
                            {
                                str111 = str112;
                            }
                            else
                            {
                                row26[0] = "";
                            }
                        }
                    }
                    else if (tableName.Trim().ToUpper() == "B23")
                    {
                        string str113 = "";
                        foreach (DataRow row27 in table.Rows)
                        {
                            string str114 = row27[0].ToString();
                            if (str113 != str114)
                            {
                                str113 = str114;
                            }
                            else
                            {
                                row27[0] = "";
                            }
                        }
                    }
                    else if (tableName.Trim().ToUpper() == "B24")
                    {
                        string str115 = "";
                        foreach (DataRow row28 in table.Rows)
                        {
                            string str116 = row28[0].ToString();
                            if (str115 != str116)
                            {
                                str115 = str116;
                            }
                            else
                            {
                                row28[0] = "";
                            }
                        }
                    }
                    else if (tableName.Trim().ToUpper() == "B25")
                    {
                        string str117 = "";
                        foreach (DataRow row29 in table.Rows)
                        {
                            string str118 = row29[0].ToString();
                            if (str117 != str118)
                            {
                                str117 = str118;
                            }
                            else
                            {
                                row29[0] = "";
                            }
                        }
                    }
                    else if (tableName.Trim().ToUpper() == "B26")
                    {
                        string str119 = "";
                        foreach (DataRow row30 in table.Rows)
                        {
                            string str120 = row30[0].ToString();
                            if (str119 != str120)
                            {
                                str119 = str120;
                            }
                            else
                            {
                                row30[0] = "";
                            }
                        }
                    }
                    else if (tableName.Trim().ToUpper() == "B27")
                    {
                        string str121 = "";
                        string str122 = "";
                        foreach (DataRow row31 in table.Rows)
                        {
                            string str123 = row31[0].ToString();
                            if (str121 != str123)
                            {
                                str121 = str123;
                            }
                            else
                            {
                                row31[0] = "";
                            }
                            string str124 = row31[1].ToString();
                            if (str122 != str124)
                            {
                                str122 = str124;
                            }
                            else
                            {
                                row31[1] = "";
                            }
                        }
                    }
                    else if (tableName.Trim().ToUpper() == "B28")
                    {
                        string str125 = "";
                        string str126 = "";
                        foreach (DataRow row32 in table.Rows)
                        {
                            string str127 = row32[0].ToString();
                            if (str125 != str127)
                            {
                                str125 = str127;
                            }
                            else
                            {
                                row32[0] = "";
                            }
                            string str128 = row32[1].ToString();
                            if (str126 != str128)
                            {
                                str126 = str128;
                            }
                            else
                            {
                                row32[1] = "";
                            }
                        }
                    }
                    else if (tableName.Trim().ToUpper() == "B29")
                    {
                        string str129 = "";
                        string str130 = "";
                        foreach (DataRow row33 in table.Rows)
                        {
                            string str131 = row33[0].ToString();
                            if (str129 != str131)
                            {
                                str129 = str131;
                            }
                            else
                            {
                                row33[0] = "";
                            }
                            string str132 = row33[1].ToString();
                            if (str130 != str132)
                            {
                                str130 = str132;
                            }
                            else
                            {
                                row33[1] = "";
                            }
                        }
                    }
                    else if (tableName.Trim().ToUpper() == "B30")
                    {
                        string str133 = "";
                        string str134 = "";
                        foreach (DataRow row34 in table.Rows)
                        {
                            string str135 = row34[0].ToString();
                            if (str133 != str135)
                            {
                                str133 = str135;
                            }
                            else
                            {
                                row34[0] = "";
                            }
                            string str136 = row34[1].ToString();
                            if (str134 != str136)
                            {
                                str134 = str136;
                            }
                            else
                            {
                                row34[1] = "";
                            }
                        }
                    }
                    else if (tableName.Trim().ToUpper() == "B31")
                    {
                        string str137 = "";
                        string str138 = "";
                        foreach (DataRow row35 in table.Rows)
                        {
                            string str139 = row35[0].ToString();
                            if (str137 != str139)
                            {
                                str137 = str139;
                            }
                            else
                            {
                                row35[0] = "";
                            }
                            string str140 = row35[1].ToString();
                            if (str138 != str140)
                            {
                                str138 = str140;
                            }
                            else
                            {
                                row35[1] = "";
                            }
                        }
                    }
                    else if (tableName.Trim().ToUpper() == "B32")
                    {
                        string str141 = "";
                        string str142 = "";
                        string str143 = "";
                        foreach (DataRow row36 in table.Rows)
                        {
                            string str144 = row36[0].ToString();
                            if (str141 != str144)
                            {
                                str141 = str144;
                            }
                            else
                            {
                                row36[0] = "";
                            }
                            string str145 = row36[1].ToString();
                            if (str142 != str145)
                            {
                                str142 = str145;
                            }
                            else
                            {
                                row36[1] = "";
                            }
                            string str146 = row36[2].ToString();
                            if (str143 != str146)
                            {
                                str143 = str146;
                            }
                            else
                            {
                                row36[2] = "";
                            }
                        }
                    }
                    else if (tableName.Trim().ToUpper() == "B33")
                    {
                        string str147 = "";
                        string str148 = "";
                        string str149 = "";
                        string str150 = "";
                        foreach (DataRow row37 in table.Rows)
                        {
                            string str151 = row37[0].ToString();
                            if (str147 != str151)
                            {
                                str147 = str151;
                            }
                            else
                            {
                                row37[0] = "";
                            }
                            string str152 = row37[1].ToString();
                            if (str148 != str152)
                            {
                                str148 = str152;
                            }
                            else
                            {
                                row37[1] = "";
                            }
                            string str153 = row37[2].ToString();
                            if (str149 != str153)
                            {
                                str149 = str153;
                            }
                            else
                            {
                                row37[2] = "";
                            }
                            string str154 = row37[3].ToString();
                            if (str150 != str154)
                            {
                                str150 = str154;
                            }
                            else
                            {
                                row37[3] = "";
                            }
                        }
                    }
                    else if (tableName.Trim().ToUpper() == "B34")
                    {
                        string str155 = "";
                        string str156 = "";
                        foreach (DataRow row38 in table.Rows)
                        {
                            string str157 = row38[0].ToString();
                            if (str155 != str157)
                            {
                                str155 = str157;
                            }
                            else
                            {
                                row38[0] = "";
                            }
                            string str158 = row38[1].ToString();
                            if (str156 != str158)
                            {
                                str156 = str158;
                            }
                            else
                            {
                                row38[1] = "";
                            }
                        }
                    }
                    else if (tableName.Trim().ToUpper() == "B35")
                    {
                        string str159 = "";
                        foreach (DataRow row39 in table.Rows)
                        {
                            string str160 = row39[0].ToString();
                            if (str159 != str160)
                            {
                                str159 = str160;
                            }
                            else
                            {
                                row39[0] = "";
                            }
                        }
                    }
                    goto Label_21E6;
                Label_2190:
                    if ((tableName.Trim().ToUpper() != "B40") && (tableName.Trim().ToUpper() != "B41"))
                    {
                        table.Rows[0][0] = tjdwmc;
                        table.AcceptChanges();
                    }
                Label_21DB:
                    num++;
                    goto Label_009E;
                Label_21E6:
                    if (table.Rows.Count <= 0)
                    {
                        goto Label_21DB;
                    }
                    goto Label_2190;
                Label_21F7:
                    num2 = 0;
                    while (num2 < tjds.Tables.Count)
                    {
                        System.Data.DataTable table2 = tjds.Tables[num2];
                        string str161 = table2.TableName;
                        int count = table2.Rows.Count;
                        int num4 = table2.Columns.Count;
                        object[,] objArray = new object[count, num4];
                        for (int i = 0; i < count; i++)
                        {
                            for (int j = 0; j < num4; j++)
                            {
                                objArray[i, j] = table2.Rows[i][j];
                            }
                        }
                        if (str161.Trim().ToUpper() == "B1")
                        {
                            worksheet = application.Sheets[2] as Worksheet;
                            int num7 = worksheet.UsedRange.Rows.Count;
                            worksheet.get_Range("B2", "B2").Value2 = tjdwmc;
                            worksheet.get_Range("G2", "G2").Value2 = "统计年度：" + tjnd;
                            int num9 = (count + 8) - 1;
                            worksheet.get_Range(worksheet.Cells[8, 1], worksheet.Cells[num7 + 7, num4]).EntireRow.Delete(updateLinks);
                            worksheet.get_Range(worksheet.Cells[8, 1], worksheet.Cells[num9, num4]).Value2 = objArray;
                            worksheet.get_Range(worksheet.Cells[8, 1], worksheet.Cells[num9, num4]).Font.Size = 10;
                            worksheet.get_Range(worksheet.Cells[8, 1], worksheet.Cells[num9, num4]).Columns.AutoFit();
                            worksheet.get_Range(worksheet.Cells[8, 1], worksheet.Cells[num9, 2]).VerticalAlignment = XlVAlign.xlVAlignCenter;
                            worksheet.get_Range(worksheet.Cells[8, 1], worksheet.Cells[num9, num4]).Borders.LineStyle = 1;
                            worksheet.Select(updateLinks);
                            worksheet.get_Range("A1", "A1").Select();
                        }
                        else if (str161.Trim().ToUpper() == "B1-1")
                        {
                            worksheet = application.Sheets[3] as Worksheet;
                            int num10 = worksheet.UsedRange.Rows.Count;
                            worksheet.get_Range("B2", "B2").Value2 = tjdwmc;
                            worksheet.get_Range("G2", "G2").Value2 = "统计年度：" + tjnd;
                            int num12 = (count + 7) - 1;
                            int num13 = (num10 + 7) - 1;
                            worksheet.get_Range(worksheet.Cells[7, 1], worksheet.Cells[num13, num4]).EntireRow.Delete(updateLinks);
                            worksheet.get_Range(worksheet.Cells[7, 1], worksheet.Cells[num12, num4]).Value2 = objArray;
                            worksheet.get_Range(worksheet.Cells[7, 1], worksheet.Cells[num12, num4]).Font.Size = 10;
                            worksheet.get_Range(worksheet.Cells[7, 1], worksheet.Cells[num12, num4]).Columns.AutoFit();
                            worksheet.get_Range(worksheet.Cells[7, 1], worksheet.Cells[num12, 1]).HorizontalAlignment = XlHAlign.xlHAlignCenter;
                            worksheet.get_Range(worksheet.Cells[7, 1], worksheet.Cells[num12, 1]).VerticalAlignment = XlVAlign.xlVAlignCenter;
                            worksheet.get_Range(worksheet.Cells[7, 1], worksheet.Cells[num12, num4]).Borders.LineStyle = 1;
                            worksheet.Select(updateLinks);
                            worksheet.get_Range("A1", "A1").Select();
                        }
                        else if (str161.Trim().ToUpper() == "B1-2")
                        {
                            worksheet = application.Sheets[4] as Worksheet;
                            int num14 = worksheet.UsedRange.Rows.Count;
                            worksheet.get_Range("B2", "B2").Value2 = tjdwmc;
                            worksheet.get_Range("F2", "F2").Value2 = "统计年度：" + tjnd;
                            int num16 = (count + 7) - 1;
                            worksheet.get_Range(worksheet.Cells[7, 1], worksheet.Cells[num14 + 7, num4]).EntireRow.Delete(updateLinks);
                            worksheet.get_Range(worksheet.Cells[7, 1], worksheet.Cells[num16, num4]).Value2 = objArray;
                            worksheet.get_Range(worksheet.Cells[7, 1], worksheet.Cells[num16, num4]).Font.Size = 10;
                            worksheet.get_Range(worksheet.Cells[7, 1], worksheet.Cells[num16, num4]).Columns.AutoFit();
                            worksheet.get_Range(worksheet.Cells[7, 1], worksheet.Cells[num16, 2]).VerticalAlignment = XlVAlign.xlVAlignCenter;
                            worksheet.get_Range(worksheet.Cells[7, 1], worksheet.Cells[num16, num4]).Borders.LineStyle = 1;
                            worksheet.Select(updateLinks);
                            worksheet.get_Range("A1", "A1").Select();
                        }
                        else if (str161.Trim().ToUpper() == "B1-3")
                        {
                            worksheet = application.Sheets[5] as Worksheet;
                            int num17 = worksheet.UsedRange.Rows.Count;
                            worksheet.get_Range("B2", "B2").Value2 = tjdwmc;
                            worksheet.get_Range("E2", "E2").Value2 = "统计年度：" + tjnd;
                            int num19 = (count + 7) - 1;
                            worksheet.get_Range(worksheet.Cells[7, 1], worksheet.Cells[num17 + 7, num4]).EntireRow.Delete(updateLinks);
                            worksheet.get_Range(worksheet.Cells[7, 1], worksheet.Cells[num19, num4]).Value2 = objArray;
                            worksheet.get_Range(worksheet.Cells[7, 1], worksheet.Cells[num19, num4]).Font.Size = 10;
                            worksheet.get_Range(worksheet.Cells[7, 1], worksheet.Cells[num19, num4]).Columns.AutoFit();
                            worksheet.get_Range(worksheet.Cells[7, 1], worksheet.Cells[num19, 2]).VerticalAlignment = XlVAlign.xlVAlignCenter;
                            worksheet.get_Range(worksheet.Cells[7, 1], worksheet.Cells[num19, num4]).Borders.LineStyle = 1;
                            worksheet.Select(updateLinks);
                            worksheet.get_Range("A1", "A1").Select();
                        }
                        else if (str161.Trim().ToUpper() == "B2")
                        {
                            worksheet = application.Sheets[6] as Worksheet;
                            int num1 = worksheet.UsedRange.Rows.Count;
                            int num22 = (count + 8) - 1;
                            worksheet.get_Range("B2", "B2").Value2 = tjdwmc;
                            worksheet.get_Range("G2", "G2").Value2 = "统计年度：" + tjnd;
                            worksheet.get_Range(worksheet.Cells[8, 1], worksheet.Cells[num22, num4]).EntireRow.Delete(updateLinks);
                            worksheet.get_Range(worksheet.Cells[8, 1], worksheet.Cells[num22, num4]).Value2 = objArray;
                            worksheet.get_Range(worksheet.Cells[8, 1], worksheet.Cells[num22, num4]).Font.Size = 10;
                            worksheet.get_Range(worksheet.Cells[8, 1], worksheet.Cells[num22, num4]).Columns.AutoFit();
                            worksheet.get_Range(worksheet.Cells[8, 1], worksheet.Cells[num22, 2]).HorizontalAlignment = 3;
                            worksheet.get_Range(worksheet.Cells[8, 1], worksheet.Cells[num22, 2]).VerticalAlignment = 2;
                            worksheet.get_Range(worksheet.Cells[8, 1], worksheet.Cells[num22, num4]).Borders.LineStyle = 1;
                            worksheet.Select(updateLinks);
                            worksheet.get_Range("A1", "A1").Select();
                        }
                        else if (str161.Trim().ToUpper() == "B2-1")
                        {
                            worksheet = application.Sheets[7] as Worksheet;
                            int num132 = worksheet.UsedRange.Rows.Count;
                            int num25 = (count + 7) - 1;
                            worksheet.get_Range("B2", "B2").Value2 = tjdwmc;
                            worksheet.get_Range("G2", "G2").Value2 = "统计年度：" + tjnd;
                            worksheet.get_Range(worksheet.Cells[7, 1], worksheet.Cells[num25, num4]).EntireRow.Delete(updateLinks);
                            worksheet.get_Range(worksheet.Cells[7, 1], worksheet.Cells[num25, num4]).Value2 = objArray;
                            worksheet.get_Range(worksheet.Cells[7, 1], worksheet.Cells[num25, num4]).Font.Size = 10;
                            worksheet.get_Range(worksheet.Cells[7, 1], worksheet.Cells[num25, num4]).Columns.AutoFit();
                            worksheet.get_Range(worksheet.Cells[7, 1], worksheet.Cells[num25, 3]).HorizontalAlignment = 3;
                            worksheet.get_Range(worksheet.Cells[7, 1], worksheet.Cells[num25, num4]).Borders.LineStyle = 1;
                            worksheet.Select(updateLinks);
                            worksheet.get_Range("A1", "A1").Select();
                        }
                        else if (str161.Trim().ToUpper() == "B3")
                        {
                            worksheet = application.Sheets[8] as Worksheet;
                            int num133 = worksheet.UsedRange.Rows.Count;
                            int num28 = (count + 9) - 1;
                            worksheet.get_Range("B2", "B2").Value2 = tjdwmc;
                            worksheet.get_Range("G2", "G2").Value2 = "统计年度：" + tjnd;
                            worksheet.get_Range(worksheet.Cells[9, 1], worksheet.Cells[num28, num4]).EntireRow.Delete(updateLinks);
                            worksheet.get_Range(worksheet.Cells[9, 1], worksheet.Cells[num28, num4]).Value2 = objArray;
                            worksheet.get_Range(worksheet.Cells[9, 1], worksheet.Cells[num28, num4]).Font.Size = 10;
                            worksheet.get_Range(worksheet.Cells[9, 1], worksheet.Cells[num28, num4]).Columns.AutoFit();
                            worksheet.get_Range(worksheet.Cells[9, 1], worksheet.Cells[num28, 2]).HorizontalAlignment = XlHAlign.xlHAlignCenter;
                            worksheet.get_Range(worksheet.Cells[9, 1], worksheet.Cells[num28, num4]).Borders.LineStyle = 1;
                            worksheet.Select(updateLinks);
                            worksheet.get_Range("A1", "A1").Select();
                        }
                        else if (str161.Trim().ToUpper() == "B4")
                        {
                            worksheet = application.Sheets[9] as Worksheet;
                            int num134 = worksheet.UsedRange.Rows.Count;
                            int num31 = (count + 6) - 1;
                            worksheet.get_Range("B2", "B2").Value2 = tjdwmc;
                            worksheet.get_Range("F2", "F2").Value2 = "统计年度：" + tjnd;
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num31, num4]).EntireRow.Delete(updateLinks);
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num31, num4]).Value2 = objArray;
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num31, num4]).Font.Size = 10;
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num31, num4]).Columns.AutoFit();
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num31, 5]).HorizontalAlignment = 3;
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num31, 5]).VerticalAlignment = 2;
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num31, num4]).Borders.LineStyle = 1;
                            worksheet.Select(updateLinks);
                            worksheet.get_Range("A1", "A1").Select();
                        }
                        else if (str161.Trim().ToUpper() == "B5")
                        {
                            worksheet = application.Sheets[10] as Worksheet;
                            int num135 = worksheet.UsedRange.Rows.Count;
                            int num34 = (count + 8) - 1;
                            worksheet.get_Range("B2", "B2").Value2 = tjdwmc;
                            worksheet.get_Range("G2", "G2").Value2 = "统计年度：" + tjnd;
                            worksheet.get_Range(worksheet.Cells[8, 1], worksheet.Cells[num34, num4]).EntireRow.Delete(updateLinks);
                            worksheet.get_Range(worksheet.Cells[8, 1], worksheet.Cells[num34, num4]).Value2 = objArray;
                            worksheet.get_Range(worksheet.Cells[8, 1], worksheet.Cells[num34, num4]).Font.Size = 10;
                            worksheet.get_Range(worksheet.Cells[8, 1], worksheet.Cells[num34, num4]).Columns.AutoFit();
                            worksheet.get_Range(worksheet.Cells[8, 1], worksheet.Cells[num34, 4]).HorizontalAlignment = 3;
                            worksheet.get_Range(worksheet.Cells[8, 1], worksheet.Cells[num34, num4]).Borders.LineStyle = 1;
                            worksheet.Select(updateLinks);
                            worksheet.get_Range("A1", "A1").Select();
                        }
                        else if (str161.Trim().ToUpper() == "B6")
                        {
                            worksheet = application.Sheets[11] as Worksheet;
                            int num136 = worksheet.UsedRange.Rows.Count;
                            int num37 = (count + 9) - 1;
                            worksheet.get_Range("B2", "B2").Value2 = tjdwmc;
                            worksheet.get_Range("F2", "F2").Value2 = "统计年度：" + tjnd;
                            worksheet.get_Range(worksheet.Cells[9, 1], worksheet.Cells[num37, num4]).EntireRow.Delete(updateLinks);
                            worksheet.get_Range(worksheet.Cells[9, 1], worksheet.Cells[num37, num4]).Value2 = objArray;
                            worksheet.get_Range(worksheet.Cells[9, 1], worksheet.Cells[num37, num4]).Font.Size = 10;
                            worksheet.get_Range(worksheet.Cells[9, 1], worksheet.Cells[num37, num4]).Columns.AutoFit();
                            worksheet.get_Range(worksheet.Cells[9, 1], worksheet.Cells[num37, 3]).HorizontalAlignment = 3;
                            worksheet.get_Range(worksheet.Cells[9, 1], worksheet.Cells[num37, 3]).VerticalAlignment = 2;
                            worksheet.get_Range(worksheet.Cells[9, 1], worksheet.Cells[num37, num4]).Borders.LineStyle = 1;
                            worksheet.Select(updateLinks);
                            worksheet.get_Range("A1", "A1").Select();
                        }
                        else if (str161.Trim().ToUpper() == "B7")
                        {
                            worksheet = application.Sheets[12] as Worksheet;
                            int num137 = worksheet.UsedRange.Rows.Count;
                            int num40 = (count + 6) - 1;
                            worksheet.get_Range("B2", "B2").Value2 = tjdwmc;
                            worksheet.get_Range("G2", "G2").Value2 = "统计年度：" + tjnd;
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num40, num4]).EntireRow.Delete(updateLinks);
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num40, num4]).Value2 = objArray;
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num40, num4]).Font.Size = 10;
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num40, num4]).Columns.AutoFit();
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num40, 3]).VerticalAlignment = 2;
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num40, 3]).HorizontalAlignment = 3;
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num40, num4]).Borders.LineStyle = 1;
                            worksheet.Select(updateLinks);
                            worksheet.get_Range("A1", "A1").Select();
                        }
                        else if (str161.Trim().ToUpper() == "B8")
                        {
                            worksheet = application.Sheets[13] as Worksheet;
                            int num138 = worksheet.UsedRange.Rows.Count;
                            int num43 = (count + 7) - 1;
                            worksheet.get_Range("B2", "B2").Value2 = tjdwmc;
                            worksheet.get_Range("G2", "G2").Value2 = "统计年度：" + tjnd;
                            worksheet.get_Range(worksheet.Cells[7, 1], worksheet.Cells[num43, num4]).EntireRow.Delete(updateLinks);
                            worksheet.get_Range(worksheet.Cells[7, 1], worksheet.Cells[num43, num4]).Value2 = objArray;
                            worksheet.get_Range(worksheet.Cells[7, 1], worksheet.Cells[num43, num4]).Font.Size = 10;
                            worksheet.get_Range(worksheet.Cells[7, 1], worksheet.Cells[num43, num4]).Columns.AutoFit();
                            worksheet.get_Range(worksheet.Cells[7, 1], worksheet.Cells[num43, 3]).HorizontalAlignment = 3;
                            worksheet.get_Range(worksheet.Cells[7, 1], worksheet.Cells[num43, 3]).VerticalAlignment = 2;
                            worksheet.get_Range(worksheet.Cells[7, 1], worksheet.Cells[num43, num4]).Borders.LineStyle = 1;
                            worksheet.Select(updateLinks);
                            worksheet.get_Range("A1", "A1").Select();
                        }
                        else if (str161.Trim().ToUpper() == "B9")
                        {
                            worksheet = application.Sheets[14] as Worksheet;
                            int num139 = worksheet.UsedRange.Rows.Count;
                            int num46 = (count + 7) - 1;
                            worksheet.get_Range("B2", "B2").Value2 = tjdwmc;
                            worksheet.get_Range("F2", "F2").Value2 = "统计年度：" + tjnd;
                            worksheet.get_Range(worksheet.Cells[7, 1], worksheet.Cells[num46, num4]).EntireRow.Delete(updateLinks);
                            worksheet.get_Range(worksheet.Cells[7, 1], worksheet.Cells[num46, num4]).Value2 = objArray;
                            worksheet.get_Range(worksheet.Cells[7, 1], worksheet.Cells[num46, num4]).Font.Size = 10;
                            worksheet.get_Range(worksheet.Cells[7, 1], worksheet.Cells[num46, num4]).Columns.AutoFit();
                            worksheet.get_Range(worksheet.Cells[7, 1], worksheet.Cells[num46, 3]).HorizontalAlignment = 3;
                            worksheet.get_Range(worksheet.Cells[7, 1], worksheet.Cells[num46, 3]).VerticalAlignment = 2;
                            worksheet.get_Range(worksheet.Cells[7, 1], worksheet.Cells[num46, num4]).Borders.LineStyle = 1;
                            worksheet.Select(updateLinks);
                            worksheet.get_Range("A1", "A1").Select();
                        }
                        else if (str161.Trim().ToUpper() == "B10")
                        {
                            worksheet = application.Sheets[15] as Worksheet;
                            int num140 = worksheet.UsedRange.Rows.Count;
                            int num49 = (count + 6) - 1;
                            worksheet.get_Range("B2", "B2").Value2 = tjdwmc;
                            worksheet.get_Range("F2", "F2").Value2 = "统计年度：" + tjnd;
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num49, num4]).EntireRow.Delete(updateLinks);
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num49, num4]).Value2 = objArray;
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num49, num4]).Font.Size = 10;
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num49, num4]).Columns.AutoFit();
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num49, 4]).VerticalAlignment = 2;
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num49, 4]).HorizontalAlignment = 3;
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num49, num4]).Borders.LineStyle = 1;
                            worksheet.Select(updateLinks);
                            worksheet.get_Range("A1", "A1").Select();
                        }
                        else if (str161.Trim().ToUpper() == "B11")
                        {
                            worksheet = application.Sheets[0x10] as Worksheet;
                            int num141 = worksheet.UsedRange.Rows.Count;
                            int num52 = (count + 7) - 1;
                            worksheet.get_Range("B2", "B2").Value2 = tjdwmc;
                            worksheet.get_Range("F2", "F2").Value2 = "统计年度：" + tjnd;
                            worksheet.get_Range(worksheet.Cells[7, 1], worksheet.Cells[num52, num4]).EntireRow.Delete(updateLinks);
                            worksheet.get_Range(worksheet.Cells[7, 1], worksheet.Cells[num52, num4]).Value2 = objArray;
                            worksheet.get_Range(worksheet.Cells[7, 1], worksheet.Cells[num52, num4]).Font.Size = 10;
                            worksheet.get_Range(worksheet.Cells[7, 1], worksheet.Cells[num52, num4]).Columns.AutoFit();
                            worksheet.get_Range(worksheet.Cells[7, 1], worksheet.Cells[num52, 3]).VerticalAlignment = 2;
                            worksheet.get_Range(worksheet.Cells[7, 1], worksheet.Cells[num52, 3]).HorizontalAlignment = 3;
                            worksheet.get_Range(worksheet.Cells[7, 1], worksheet.Cells[num52, num4]).Borders.LineStyle = 1;
                            worksheet.Select(updateLinks);
                            worksheet.get_Range("A1", "A1").Select();
                        }
                        else if (str161.Trim().ToUpper() == "B12")
                        {
                            worksheet = application.Sheets[0x11] as Worksheet;
                            int num142 = worksheet.UsedRange.Rows.Count;
                            int num55 = (count + 7) - 1;
                            worksheet.get_Range("B2", "B2").Value2 = tjdwmc;
                            worksheet.get_Range("F2", "F2").Value2 = "统计年度：" + tjnd;
                            worksheet.get_Range(worksheet.Cells[7, 1], worksheet.Cells[num55, num4]).EntireRow.Delete(updateLinks);
                            worksheet.get_Range(worksheet.Cells[7, 1], worksheet.Cells[num55, num4]).Value2 = objArray;
                            worksheet.get_Range(worksheet.Cells[7, 1], worksheet.Cells[num55, num4]).Font.Size = 10;
                            worksheet.get_Range(worksheet.Cells[7, 1], worksheet.Cells[num55, num4]).Columns.AutoFit();
                            worksheet.get_Range(worksheet.Cells[7, 1], worksheet.Cells[num55, 2]).VerticalAlignment = 2;
                            worksheet.get_Range(worksheet.Cells[7, 1], worksheet.Cells[num55, 2]).HorizontalAlignment = 3;
                            worksheet.get_Range(worksheet.Cells[7, 1], worksheet.Cells[num55, num4]).Borders.LineStyle = 1;
                            worksheet.Select(updateLinks);
                            worksheet.get_Range("A1", "A1").Select();
                        }
                        else if (str161.Trim().ToUpper() == "B13")
                        {
                            worksheet = application.Sheets[0x12] as Worksheet;
                            int num143 = worksheet.UsedRange.Rows.Count;
                            int num58 = (count + 6) - 1;
                            worksheet.get_Range("B2", "B2").Value2 = tjdwmc;
                            worksheet.get_Range("F2", "F2").Value2 = "统计年度：" + tjnd;
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num58, num4]).EntireRow.Delete(updateLinks);
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num58, num4]).Value2 = objArray;
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num58, num4]).Font.Size = 10;
                            application.DisplayAlerts = false;
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num58, num4]).Columns.AutoFit();
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num58, 4]).HorizontalAlignment = 3;
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num58, 4]).VerticalAlignment = 2;
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num58, num4]).Borders.LineStyle = 1;
                            worksheet.Select(updateLinks);
                            worksheet.get_Range("A1", "A1").Select();
                        }
                        else if (str161.Trim().ToUpper() == "B14")
                        {
                            worksheet = application.Sheets[0x13] as Worksheet;
                            int num144 = worksheet.UsedRange.Rows.Count;
                            int num61 = (count + 6) - 1;
                            worksheet.get_Range("B2", "B2").Value2 = tjdwmc;
                            worksheet.get_Range("F2", "F2").Value2 = "统计年度：" + tjnd;
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num61, num4]).EntireRow.Delete(updateLinks);
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num61, num4]).Value2 = objArray;
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num61, num4]).Font.Size = 10;
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num61, num4]).Columns.AutoFit();
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num61, 3]).HorizontalAlignment = 3;
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num61, 3]).VerticalAlignment = 2;
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num61, num4]).Borders.LineStyle = 1;
                            worksheet.Select(updateLinks);
                            worksheet.get_Range("A1", "A1").Select();
                        }
                        else if (str161.Trim().ToUpper() == "B15")
                        {
                            worksheet = application.Sheets[20] as Worksheet;
                            int num145 = worksheet.UsedRange.Rows.Count;
                            int num64 = (count + 6) - 1;
                            worksheet.get_Range("B2", "B2").Value2 = tjdwmc;
                            worksheet.get_Range("E2", "E2").Value2 = "统计年度：" + tjnd;
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num64, num4]).EntireRow.Delete(updateLinks);
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num64, num4]).Value2 = objArray;
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num64, num4]).Font.Size = 10;
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num64, num4]).Columns.AutoFit();
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num64, 4]).HorizontalAlignment = 3;
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num64, 4]).VerticalAlignment = 2;
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num64, num4]).Borders.LineStyle = 1;
                            worksheet.Select(updateLinks);
                            worksheet.get_Range("A1", "A1").Select();
                        }
                        else if (str161.Trim().ToUpper() == "B16")
                        {
                            worksheet = application.Sheets[0x15] as Worksheet;
                            int num146 = worksheet.UsedRange.Rows.Count;
                            int num67 = (count + 6) - 1;
                            worksheet.get_Range("B2", "B2").Value2 = tjdwmc;
                            worksheet.get_Range("E2", "E2").Value2 = "统计年度：" + tjnd;
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num67, num4]).EntireRow.Delete(updateLinks);
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num67, num4]).Value2 = objArray;
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num67, num4]).Font.Size = 10;
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num67, num4]).Columns.AutoFit();
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num67, 4]).HorizontalAlignment = 3;
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num67, 4]).VerticalAlignment = 2;
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num67, num4]).Borders.LineStyle = 1;
                            worksheet.Select(updateLinks);
                            worksheet.get_Range("A1", "A1").Select();
                        }
                        else if (str161.Trim().ToUpper() == "B17")
                        {
                            worksheet = application.Sheets[0x16] as Worksheet;
                            int num147 = worksheet.UsedRange.Rows.Count;
                            int num70 = (count + 6) - 1;
                            worksheet.get_Range("B2", "B2").Value2 = tjdwmc;
                            worksheet.get_Range("D2", "D2").Value2 = "统计年度：" + tjnd;
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num70, num4]).EntireRow.Delete(updateLinks);
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num70, num4]).Value2 = objArray;
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num70, num4]).Font.Size = 10;
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num70, num4]).Columns.AutoFit();
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num70, 4]).HorizontalAlignment = 3;
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num70, 4]).VerticalAlignment = 2;
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num70, num4]).Borders.LineStyle = 1;
                            worksheet.Select(updateLinks);
                            worksheet.get_Range("A1", "A1").Select();
                        }
                        else if (str161.Trim().ToUpper() == "B18")
                        {
                            worksheet = application.Sheets[0x17] as Worksheet;
                            int num148 = worksheet.UsedRange.Rows.Count;
                            int num73 = (count + 6) - 1;
                            worksheet.get_Range("B2", "B2").Value2 = tjdwmc;
                            worksheet.get_Range("F2", "F2").Value2 = "统计年度：" + tjnd;
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num73, num4]).EntireRow.Delete(updateLinks);
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num73, num4]).Value2 = objArray;
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num73, num4]).Font.Size = 10;
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num73, num4]).Columns.AutoFit();
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num73, 4]).HorizontalAlignment = 3;
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num73, 4]).VerticalAlignment = 2;
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num73, num4]).Borders.LineStyle = 1;
                            worksheet.Select(updateLinks);
                            worksheet.get_Range("A1", "A1").Select();
                        }
                        else if (str161.Trim().ToUpper() == "B19")
                        {
                            worksheet = application.Sheets[0x18] as Worksheet;
                            int num149 = worksheet.UsedRange.Rows.Count;
                            int num76 = (count + 6) - 1;
                            worksheet.get_Range("B2", "B2").Value2 = tjdwmc;
                            worksheet.get_Range("E2", "E2").Value2 = "统计年度：" + tjnd;
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num76, num4]).EntireRow.Delete(updateLinks);
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num76, num4]).Value2 = objArray;
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num76, num4]).Font.Size = 10;
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num76, 1]).RowHeight = 0x15;
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num76, num4]).Columns.AutoFit();
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num76, 2]).HorizontalAlignment = 3;
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num76, 2]).VerticalAlignment = 2;
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num76, num4]).Borders.LineStyle = 1;
                            worksheet.Select(updateLinks);
                            worksheet.get_Range("A1", "A1").Select();
                        }
                        else if (str161.Trim().ToUpper() == "B20")
                        {
                            worksheet = application.Sheets[0x19] as Worksheet;
                            int num150 = worksheet.UsedRange.Rows.Count;
                            int num79 = (count + 6) - 1;
                            worksheet.get_Range("B2", "B2").Value2 = tjdwmc;
                            worksheet.get_Range("E2", "E2").Value2 = "统计年度：" + tjnd;
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num79, num4]).EntireRow.Delete(updateLinks);
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num79, num4]).Value2 = objArray;
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num79, num4]).Font.Size = 10;
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num79, num4]).Columns.AutoFit();
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num79, 2]).HorizontalAlignment = 3;
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num79, 2]).VerticalAlignment = 2;
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num79, num4]).Borders.LineStyle = 1;
                            worksheet.Select(updateLinks);
                            worksheet.get_Range("A1", "A1").Select();
                        }
                        else if (str161.Trim().ToUpper() == "B21")
                        {
                            worksheet = application.Sheets[0x1a] as Worksheet;
                            int num151 = worksheet.UsedRange.Rows.Count;
                            int num82 = (count + 5) - 1;
                            worksheet.get_Range("B2", "B2").Value2 = tjdwmc;
                            worksheet.get_Range("D2", "D2").Value2 = "统计年度：" + tjnd;
                            worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num82, num4]).EntireRow.Delete(updateLinks);
                            worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num82, num4]).Value2 = objArray;
                            worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num82, num4]).Font.Size = 10;
                            worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num82, num4]).Columns.AutoFit();
                            worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num82, 2]).HorizontalAlignment = 3;
                            worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num82, 2]).VerticalAlignment = 2;
                            worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num82, num4]).Borders.LineStyle = 1;
                            worksheet.Select(updateLinks);
                            worksheet.get_Range("A1", "A1").Select();
                        }
                        else if (str161.Trim().ToUpper() == "B22")
                        {
                            worksheet = application.Sheets[0x1b] as Worksheet;
                            int num152 = worksheet.UsedRange.Rows.Count;
                            int num85 = (count + 6) - 1;
                            worksheet.get_Range("B2", "B2").Value2 = tjdwmc;
                            worksheet.get_Range("D2", "D2").Value2 = "统计年度：" + tjnd;
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num85, num4]).EntireRow.Delete(updateLinks);
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num85, num4]).Value2 = objArray;
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num85, num4]).Font.Size = 10;
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num85, num4]).Columns.AutoFit();
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num85, 2]).HorizontalAlignment = 3;
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num85, 2]).VerticalAlignment = 2;
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num85, num4]).Borders.LineStyle = 1;
                            worksheet.Select(updateLinks);
                            worksheet.get_Range("A1", "A1").Select();
                        }
                        else if (str161.Trim().ToUpper() == "B23")
                        {
                            worksheet = application.Sheets[0x1c] as Worksheet;
                            int num153 = worksheet.UsedRange.Rows.Count;
                            int num88 = (count + 6) - 1;
                            worksheet.get_Range("B2", "B2").Value2 = tjdwmc;
                            worksheet.get_Range("E2", "E2").Value2 = "统计年度：" + tjnd;
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num88, num4]).EntireRow.Delete(updateLinks);
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num88, num4]).Value2 = objArray;
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num88, num4]).Font.Size = 10;
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num88, num4]).Columns.AutoFit();
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num88, 2]).HorizontalAlignment = 3;
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num88, 2]).VerticalAlignment = 2;
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num88, num4]).Borders.LineStyle = 1;
                            worksheet.Select(updateLinks);
                            worksheet.get_Range("A1", "A1").Select();
                        }
                        else if (str161.Trim().ToUpper() == "B24")
                        {
                            worksheet = application.Sheets[0x1d] as Worksheet;
                            int num154 = worksheet.UsedRange.Rows.Count;
                            int num91 = (count + 5) - 1;
                            worksheet.get_Range("B2", "B2").Value2 = tjdwmc;
                            worksheet.get_Range("D2", "D2").Value2 = "统计年度：" + tjnd;
                            worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num91, num4]).EntireRow.Delete(updateLinks);
                            worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num91, num4]).Value2 = objArray;
                            worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num91, num4]).Font.Size = 10;
                            application.DisplayAlerts = false;
                            worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num91, num4]).Columns.AutoFit();
                            worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num91, 2]).HorizontalAlignment = 3;
                            worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num91, 2]).VerticalAlignment = 2;
                            worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num91, num4]).Borders.LineStyle = 1;
                            worksheet.Select(updateLinks);
                            worksheet.get_Range("A1", "A1").Select();
                        }
                        else if (str161.Trim().ToUpper() == "B25")
                        {
                            worksheet = application.Sheets[30] as Worksheet;
                            int num155 = worksheet.UsedRange.Rows.Count;
                            int num94 = (count + 6) - 1;
                            worksheet.get_Range("B2", "B2").Value2 = tjdwmc;
                            worksheet.get_Range("E2", "E2").Value2 = "统计年度：" + tjnd;
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num94, num4]).EntireRow.Delete(updateLinks);
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num94, num4]).Value2 = objArray;
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num94, num4]).Font.Size = 10;
                            application.DisplayAlerts = false;
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num94, num4]).Columns.AutoFit();
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num94, 2]).HorizontalAlignment = 3;
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num94, 2]).VerticalAlignment = 2;
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num94, num4]).Borders.LineStyle = 1;
                            worksheet.Select(updateLinks);
                            worksheet.get_Range("A1", "A1").Select();
                        }
                        else if (str161.Trim().ToUpper() == "B26")
                        {
                            worksheet = application.Sheets[0x1f] as Worksheet;
                            int num156 = worksheet.UsedRange.Rows.Count;
                            int num97 = (count + 7) - 1;
                            worksheet.get_Range("B2", "B2").Value2 = tjdwmc;
                            worksheet.get_Range("E2", "E2").Value2 = "统计年度：" + tjnd;
                            worksheet.get_Range(worksheet.Cells[7, 1], worksheet.Cells[num97, num4]).EntireRow.Delete(updateLinks);
                            worksheet.get_Range(worksheet.Cells[7, 1], worksheet.Cells[num97, num4]).Value2 = objArray;
                            worksheet.get_Range(worksheet.Cells[7, 1], worksheet.Cells[num97, num4]).Font.Size = 10;
                            application.DisplayAlerts = false;
                            worksheet.get_Range(worksheet.Cells[7, 1], worksheet.Cells[num97, num4]).Columns.AutoFit();
                            worksheet.get_Range(worksheet.Cells[7, 1], worksheet.Cells[num97, 2]).HorizontalAlignment = 3;
                            worksheet.get_Range(worksheet.Cells[7, 1], worksheet.Cells[num97, 2]).VerticalAlignment = 2;
                            worksheet.get_Range(worksheet.Cells[7, 1], worksheet.Cells[num97, num4]).Borders.LineStyle = 1;
                            worksheet.Select(updateLinks);
                            worksheet.get_Range("A1", "A1").Select();
                        }
                        else if (str161.Trim().ToUpper() == "B27")
                        {
                            worksheet = application.Sheets[0x20] as Worksheet;
                            int num157 = worksheet.UsedRange.Rows.Count;
                            int num100 = (count + 6) - 1;
                            worksheet.get_Range("B2", "B2").Value2 = tjdwmc;
                            worksheet.get_Range("D2", "D2").Value2 = "统计年度：" + tjnd;
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num100, num4]).EntireRow.Delete(updateLinks);
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num100, num4]).Value2 = objArray;
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num100, num4]).Font.Size = 10;
                            application.DisplayAlerts = false;
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num100, num4]).Columns.AutoFit();
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num100, 2]).HorizontalAlignment = 3;
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num100, 2]).VerticalAlignment = 2;
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num100, num4]).Borders.LineStyle = 1;
                            worksheet.Select(updateLinks);
                            worksheet.get_Range("A1", "A1").Select();
                        }
                        else if (str161.Trim().ToUpper() == "B28")
                        {
                            worksheet = application.Sheets[0x21] as Worksheet;
                            int num158 = worksheet.UsedRange.Rows.Count;
                            int num103 = (count + 8) - 1;
                            worksheet.get_Range("B2", "B2").Value2 = tjdwmc;
                            worksheet.get_Range(worksheet.Cells[8, 1], worksheet.Cells[num103, num4]).EntireRow.Delete(updateLinks);
                            worksheet.get_Range(worksheet.Cells[8, 1], worksheet.Cells[num103, num4]).Value2 = objArray;
                            worksheet.get_Range(worksheet.Cells[8, 1], worksheet.Cells[num103, num4]).Font.Size = 10;
                            worksheet.get_Range(worksheet.Cells[8, 1], worksheet.Cells[num103, num4]).Columns.AutoFit();
                            worksheet.get_Range(worksheet.Cells[8, 1], worksheet.Cells[num103, 2]).HorizontalAlignment = 3;
                            worksheet.get_Range(worksheet.Cells[8, 1], worksheet.Cells[num103, 2]).VerticalAlignment = 2;
                            worksheet.get_Range(worksheet.Cells[8, 1], worksheet.Cells[num103, num4]).Borders.LineStyle = 1;
                            worksheet.Select(updateLinks);
                            worksheet.get_Range("A1", "A1").Select();
                        }
                        else if (str161.Trim().ToUpper() == "B29")
                        {
                            worksheet = application.Sheets[0x22] as Worksheet;
                            int num159 = worksheet.UsedRange.Rows.Count;
                            int num106 = (count + 8) - 1;
                            worksheet.get_Range("B2", "B2").Value2 = tjdwmc;
                            worksheet.get_Range(worksheet.Cells[8, 1], worksheet.Cells[num106, num4]).EntireRow.Delete(updateLinks);
                            worksheet.get_Range(worksheet.Cells[8, 1], worksheet.Cells[num106, num4]).Value2 = objArray;
                            worksheet.get_Range(worksheet.Cells[8, 1], worksheet.Cells[num106, num4]).Font.Size = 10;
                            worksheet.get_Range(worksheet.Cells[8, 1], worksheet.Cells[num106, num4]).Columns.AutoFit();
                            worksheet.get_Range(worksheet.Cells[8, 1], worksheet.Cells[num106, 3]).HorizontalAlignment = 3;
                            worksheet.get_Range(worksheet.Cells[8, 1], worksheet.Cells[num106, 3]).VerticalAlignment = 2;
                            worksheet.get_Range(worksheet.Cells[8, 1], worksheet.Cells[num106, num4]).Borders.LineStyle = 1;
                            worksheet.Select(updateLinks);
                            worksheet.get_Range("A1", "A1").Select();
                        }
                        else if (str161.Trim().ToUpper() == "B30")
                        {
                            worksheet = application.Sheets[0x23] as Worksheet;
                            int num160 = worksheet.UsedRange.Rows.Count;
                            int num109 = (count + 8) - 1;
                            worksheet.get_Range("B2", "B2").Value2 = tjdwmc;
                            worksheet.get_Range(worksheet.Cells[8, 1], worksheet.Cells[num109, num4]).EntireRow.Delete(updateLinks);
                            worksheet.get_Range(worksheet.Cells[8, 1], worksheet.Cells[num109, num4]).Value2 = objArray;
                            worksheet.get_Range(worksheet.Cells[8, 1], worksheet.Cells[num109, num4]).Font.Size = 10;
                            worksheet.get_Range(worksheet.Cells[8, 1], worksheet.Cells[num109, num4]).Columns.AutoFit();
                            worksheet.get_Range(worksheet.Cells[8, 1], worksheet.Cells[num109, 3]).HorizontalAlignment = 3;
                            worksheet.get_Range(worksheet.Cells[8, 1], worksheet.Cells[num109, 3]).VerticalAlignment = 2;
                            worksheet.get_Range(worksheet.Cells[8, 1], worksheet.Cells[num109, num4]).Borders.LineStyle = 1;
                            worksheet.Select(updateLinks);
                            worksheet.get_Range("A1", "A1").Select();
                        }
                        else if (str161.Trim().ToUpper() == "B31")
                        {
                            worksheet = application.Sheets[0x24] as Worksheet;
                            int num161 = worksheet.UsedRange.Rows.Count;
                            int num112 = (count + 6) - 1;
                            worksheet.get_Range("B2", "B2").Value2 = tjdwmc;
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num112, num4]).EntireRow.Delete(updateLinks);
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num112, num4]).Value2 = objArray;
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num112, num4]).Font.Size = 10;
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num112, num4]).Columns.AutoFit();
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num112, 3]).HorizontalAlignment = 3;
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num112, 3]).VerticalAlignment = 2;
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num112, num4]).Borders.LineStyle = 1;
                            worksheet.Select(updateLinks);
                            worksheet.get_Range("A1", "A1").Select();
                        }
                        else if (str161.Trim().ToUpper() == "B32")
                        {
                            worksheet = application.Sheets[0x25] as Worksheet;
                            int num162 = worksheet.UsedRange.Rows.Count;
                            int num115 = (count + 6) - 1;
                            worksheet.get_Range("B2", "B2").Value2 = tjdwmc;
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num115, num4]).EntireRow.Delete(updateLinks);
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num115, num4]).Value2 = objArray;
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num115, num4]).Font.Size = 10;
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num115, num4]).Columns.AutoFit();
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num115, 4]).HorizontalAlignment = 3;
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num115, 4]).VerticalAlignment = 2;
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num115, num4]).Borders.LineStyle = 1;
                            worksheet.Select(updateLinks);
                            worksheet.get_Range("A1", "A1").Select();
                        }
                        else if (str161.Trim().ToUpper() == "B33")
                        {
                            worksheet = application.Sheets[0x26] as Worksheet;
                            int num163 = worksheet.UsedRange.Rows.Count;
                            int num118 = (count + 6) - 1;
                            worksheet.get_Range("B2", "B2").Value2 = tjdwmc;
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num118, num4]).EntireRow.Delete(updateLinks);
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num118, num4]).Value2 = objArray;
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num118, num4]).Font.Size = 10;
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num118, num4]).Columns.AutoFit();
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num118, 4]).HorizontalAlignment = 3;
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num118, 4]).VerticalAlignment = 2;
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num118, num4]).Borders.LineStyle = 1;
                            worksheet.Select(updateLinks);
                            worksheet.get_Range("A1", "A1").Select();
                        }
                        else if (str161.Trim().ToUpper() == "B34")
                        {
                            worksheet = application.Sheets[0x27] as Worksheet;
                            int num164 = worksheet.UsedRange.Rows.Count;
                            int num121 = (count + 6) - 1;
                            worksheet.get_Range("B2", "B2").Value2 = tjdwmc;
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num121, num4]).EntireRow.Delete(updateLinks);
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num121, num4]).Value2 = objArray;
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num121, num4]).Font.Size = 10;
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num121, num4]).Columns.AutoFit();
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num121, 3]).HorizontalAlignment = 3;
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num121, 3]).VerticalAlignment = 2;
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num121, num4]).Borders.LineStyle = 1;
                            worksheet.Select(updateLinks);
                            worksheet.get_Range("A1", "A1").Select();
                        }
                        else if (str161.Trim().ToUpper() == "B35")
                        {
                            worksheet = application.Sheets[40] as Worksheet;
                            int num165 = worksheet.UsedRange.Rows.Count;
                            int num124 = (count + 6) - 1;
                            worksheet.get_Range("B2", "B2").Value2 = tjdwmc;
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num124, num4]).EntireRow.Delete(updateLinks);
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num124, num4]).Value2 = objArray;
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num124, num4]).Font.Size = 10;
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num124, num4]).Columns.AutoFit();
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num124, 3]).HorizontalAlignment = 3;
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num124, 3]).VerticalAlignment = 2;
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num124, num4]).Borders.LineStyle = 1;
                            worksheet.Select(updateLinks);
                            worksheet.get_Range("A1", "A1").Select();
                        }
                        else if (str161.Trim().ToUpper() == "B40")
                        {
                            worksheet = application.Sheets[0x29] as Worksheet;
                            int num166 = worksheet.UsedRange.Rows.Count;
                            int num127 = (count + 6) - 1;
                            worksheet.get_Range("B2", "B2").Value2 = tjdwmc;
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num127, num4]).EntireRow.Delete(updateLinks);
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num127, num4]).Value2 = objArray;
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num127, num4]).Font.Size = 10;
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num127, num4]).Columns.AutoFit();
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num127, 3]).HorizontalAlignment = 3;
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num127, 3]).VerticalAlignment = 2;
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num127, num4]).Borders.LineStyle = 1;
                            worksheet.Select(updateLinks);
                            worksheet.get_Range("A1", "A1").Select();
                        }
                        else if (str161.Trim().ToUpper() == "B41")
                        {
                            worksheet = application.Sheets[0x2a] as Worksheet;
                            int num167 = worksheet.UsedRange.Rows.Count;
                            int num130 = (count + 6) - 1;
                            worksheet.get_Range("B2", "B2").Value2 = tjdwmc;
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num130, num4]).EntireRow.Delete(updateLinks);
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num130, num4]).Value2 = objArray;
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num130, num4]).Font.Size = 10;
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num130, num4]).Columns.AutoFit();
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num130, 3]).HorizontalAlignment = 3;
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num130, 3]).VerticalAlignment = 2;
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num130, num4]).Borders.LineStyle = 1;
                            worksheet.Select(updateLinks);
                            worksheet.get_Range("A1", "A1").Select();
                        }
                        num2++;
                    }
                    worksheet = null;
                    workbook.Save();
                    workbook.Close(false, xlsTargetPath, false);
                    workbook = null;
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message.ToString(), "导出Microsoft.Office.Interop.Excel错误", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
                finally
                {
                    new Process();
                    Process[] processesByName = Process.GetProcessesByName("Microsoft.Office.Interop.Excel");
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
                    catch (Exception exception2)
                    {
                        exception2.ToString();
                    }
                    GC.Collect();
                }
            }
        }

        public void SaveZYBHTJB(string tjdwmc, DataSet tjds, string xlsModelPath, string xlsTargetPath)
        {
            if (!File.Exists(xlsModelPath))
            {
                MessageBox.Show(xlsModelPath + " 不存在，请检查!", "错误", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
            DataSet set = new DataSet("resultds");
            int num = 0;
        Label_002F:
            if (num >= tjds.Tables.Count)
            {
                tjds.Clear();
                tjds = null;
                File.Copy(xlsModelPath, xlsTargetPath, true);
                Microsoft.Office.Interop.Excel.Application application = new ApplicationClass();
                try
                {
                    if (application == null)
                    {
                        MessageBox.Show("不能建立EXCEL对象，请在机器上安装MS Office软件！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    }
                    else
                    {
                        object updateLinks = Missing.Value;
                        string filename = xlsTargetPath;
                        Workbook workbook = application.Workbooks.Open(filename, updateLinks, updateLinks, updateLinks, updateLinks, updateLinks, updateLinks, updateLinks, updateLinks, updateLinks, updateLinks, updateLinks, updateLinks, updateLinks, updateLinks);
                        application.Visible = false;
                        application.DisplayAlerts = false;
                        Worksheet worksheet = null;
                        for (int i = 0; i < set.Tables.Count; i++)
                        {
                            System.Data.DataTable table3 = set.Tables[i];
                            string tableName = table3.TableName;
                            int count = table3.Rows.Count;
                            int num10 = table3.Columns.Count;
                            object[,] objArray = new object[count, num10];
                            for (int j = 0; j < count; j++)
                            {
                                for (int k = 0; k < num10; k++)
                                {
                                    objArray[j, k] = table3.Rows[j][k];
                                }
                            }
                            if (tableName.Trim().ToUpper() == "B1")
                            {
                                worksheet = application.Sheets[1] as Worksheet;
                                int num13 = worksheet.UsedRange.Rows.Count;
                                worksheet.get_Range("B2", "B2").Value2 = tjdwmc;
                                int num15 = (count + 7) - 1;
                                worksheet.get_Range(worksheet.Cells[7, 1], worksheet.Cells[num13 + 6, num10]).EntireRow.Delete(updateLinks);
                                worksheet.get_Range(worksheet.Cells[7, 1], worksheet.Cells[num15, num10]).Value2 = objArray;
                                worksheet.get_Range(worksheet.Cells[7, 1], worksheet.Cells[num15, num10]).RowHeight = 0x1c;
                                worksheet.get_Range(worksheet.Cells[7, 1], worksheet.Cells[num15, num10]).Font.Size = 9;
                                worksheet.get_Range(worksheet.Cells[7, 1], worksheet.Cells[num15, 1]).WrapText = true;
                                worksheet.get_Range(worksheet.Cells[7, 1], worksheet.Cells[num15, 2]).HorizontalAlignment = XlHAlign.xlHAlignCenter;
                                worksheet.get_Range(worksheet.Cells[7, 1], worksheet.Cells[num15, 2]).VerticalAlignment = XlVAlign.xlVAlignCenter;
                                worksheet.get_Range(worksheet.Cells[7, 3], worksheet.Cells[num15, num10 - 2]).HorizontalAlignment = XlHAlign.xlHAlignRight;
                                worksheet.get_Range(worksheet.Cells[7, num10 - 2], worksheet.Cells[num15, num10]).HorizontalAlignment = XlHAlign.xlHAlignCenter;
                                worksheet.get_Range(worksheet.Cells[7, 1], worksheet.Cells[num15, num10]).Borders.LineStyle = 1;
                                worksheet.Select(updateLinks);
                                worksheet.get_Range("A1", "A1").Select();
                            }
                            else if (tableName.Trim().ToUpper() == "B2")
                            {
                                worksheet = application.Sheets[2] as Worksheet;
                                int num1 = worksheet.UsedRange.Rows.Count;
                                int num18 = (count + 7) - 1;
                                worksheet.get_Range("B2", "B2").Value2 = tjdwmc;
                                worksheet.get_Range(worksheet.Cells[7, 1], worksheet.Cells[num18, num10]).EntireRow.Delete(updateLinks);
                                worksheet.get_Range(worksheet.Cells[7, 1], worksheet.Cells[num18, num10]).Value2 = objArray;
                                worksheet.get_Range(worksheet.Cells[7, 1], worksheet.Cells[num18, num10]).Font.Size = 9;
                                worksheet.get_Range(worksheet.Cells[7, 1], worksheet.Cells[num18, 1]).RowHeight = 0x1c;
                                worksheet.get_Range(worksheet.Cells[7, 1], worksheet.Cells[num18, 1]).WrapText = true;
                                worksheet.get_Range(worksheet.Cells[7, 1], worksheet.Cells[num18, 2]).HorizontalAlignment = 3;
                                worksheet.get_Range(worksheet.Cells[7, 1], worksheet.Cells[num18, 2]).VerticalAlignment = 2;
                                worksheet.get_Range(worksheet.Cells[7, 3], worksheet.Cells[num18, num10]).HorizontalAlignment = XlHAlign.xlHAlignRight;
                                worksheet.get_Range(worksheet.Cells[7, 1], worksheet.Cells[num18, num10]).Borders.LineStyle = 1;
                                worksheet.Select(updateLinks);
                                worksheet.get_Range("A1", "A1").Select();
                            }
                            else if (tableName.Trim().ToUpper() == "B3")
                            {
                                worksheet = application.Sheets[3] as Worksheet;
                                int num29 = worksheet.UsedRange.Rows.Count;
                                int num21 = (count + 5) - 1;
                                worksheet.get_Range("B2", "B2").Value2 = tjdwmc;
                                worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num21, num10]).EntireRow.Delete(updateLinks);
                                worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num21, num10]).Value2 = objArray;
                                worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num21, num10]).RowHeight = 0x1c;
                                worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num21, num10]).Font.Size = 9;
                                worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num21, 1]).WrapText = true;
                                worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num21, 2]).HorizontalAlignment = XlHAlign.xlHAlignCenter;
                                worksheet.get_Range(worksheet.Cells[5, 3], worksheet.Cells[num21, num10]).HorizontalAlignment = XlHAlign.xlHAlignRight;
                                worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num21, num10]).Borders.LineStyle = 1;
                                worksheet.Select(updateLinks);
                                worksheet.get_Range("A1", "A1").Select();
                            }
                            else if (tableName.Trim().ToUpper() == "B4")
                            {
                                worksheet = application.Sheets[4] as Worksheet;
                                int num30 = worksheet.UsedRange.Rows.Count;
                                int num24 = (count + 5) - 1;
                                worksheet.get_Range("B2", "B2").Value2 = tjdwmc;
                                worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num24, num10]).EntireRow.Delete(updateLinks);
                                worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num24, num10]).Value2 = objArray;
                                worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num24, num10]).Font.Size = 10;
                                worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num24, 1]).RowHeight = 0x15;
                                worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num24, 1]).WrapText = true;
                                worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num24, 2]).HorizontalAlignment = 3;
                                worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num24, 2]).VerticalAlignment = 2;
                                worksheet.get_Range(worksheet.Cells[5, 3], worksheet.Cells[num24, num10]).HorizontalAlignment = XlHAlign.xlHAlignRight;
                                worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num24, num10]).Borders.LineStyle = 1;
                                worksheet.Select(updateLinks);
                                worksheet.get_Range("A1", "A1").Select();
                            }
                            else if (tableName.Trim().ToUpper() == "B5")
                            {
                                worksheet = application.Sheets[5] as Worksheet;
                                int num31 = worksheet.UsedRange.Rows.Count;
                                int num27 = (count + 5) - 1;
                                worksheet.get_Range("B2", "B2").Value2 = tjdwmc;
                                worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num27, num10]).EntireRow.Delete(updateLinks);
                                worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num27, num10]).Value2 = objArray;
                                worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num27, num10]).RowHeight = 0x19;
                                worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num27, num10]).Font.Size = 10;
                                worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num27, 1]).WrapText = true;
                                worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num27, 3]).HorizontalAlignment = 3;
                                worksheet.get_Range(worksheet.Cells[5, 4], worksheet.Cells[num27, num10]).HorizontalAlignment = XlHAlign.xlHAlignRight;
                                worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num27, num10]).Borders.LineStyle = 1;
                                worksheet.Select(updateLinks);
                                worksheet.get_Range("A1", "A1").Select();
                            }
                        }
                        worksheet = null;
                        workbook.Save();
                        workbook.Close(false, xlsTargetPath, false);
                        workbook = null;
                    }
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message.ToString(), "导出EXCEL错误", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
                finally
                {
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
                    catch (Exception exception2)
                    {
                        exception2.ToString();
                    }
                    GC.Collect();
                }
            }
            else
            {
                string str = tjds.Tables[num].TableName;
                System.Data.DataTable table = tjds.Tables[num];
                if ((table != null) && (table.Rows.Count > 0))
                {
                    System.Data.DataTable table2 = new System.Data.DataTable("mytable");
                    if (str.Trim().ToUpper() == "B1")
                    {
                        table2.TableName = "B1";
                        foreach (DataColumn column in table.Columns)
                        {
                            DataColumn column2 = new DataColumn(column.ColumnName, typeof(string));
                            table2.Columns.Add(column2);
                        }
                        string str2 = "";
                        foreach (DataRow row in table.Rows)
                        {
                            DataRow row2 = table2.NewRow();
                            string str3 = row[0].ToString();
                            row2[0] = row[0];
                            if (str2 != str3)
                            {
                                str2 = str3;
                            }
                            else
                            {
                                row2[0] = "";
                            }
                            row2[1] = row[1];
                            for (int m = 2; m < table.Columns.Count; m++)
                            {
                                if (row[m] != DBNull.Value)
                                {
                                    string str4 = row[m].ToString();
                                    if (str4.IndexOf('.') < 0)
                                    {
                                        str4 = str4 + ".0";
                                    }
                                    if (Convert.ToDouble(row[m]) > 1000.0)
                                    {
                                        int num3 = ((int) Convert.ToDouble(row[m])) / 0x3e8;
                                        string str5 = Convert.ToString(num3);
                                        string str6 = str4.Substring(str5.Length, str4.Length - str5.Length);
                                        row2[m] = str5 + "\n\r" + str6;
                                    }
                                    else
                                    {
                                        row2[m] = "\n\r" + str4;
                                    }
                                }
                            }
                            table2.Rows.Add(row2);
                        }
                    }
                    else if (str.Trim().ToUpper() == "B2")
                    {
                        table2.TableName = "B2";
                        foreach (DataColumn column3 in table.Columns)
                        {
                            DataColumn column4 = new DataColumn(column3.ColumnName, typeof(string));
                            table2.Columns.Add(column4);
                        }
                        string str7 = "";
                        foreach (DataRow row3 in table.Rows)
                        {
                            DataRow row4 = table2.NewRow();
                            row4[0] = row3[0];
                            string str8 = row3[0].ToString();
                            if (str7 != str8)
                            {
                                str7 = str8;
                            }
                            else
                            {
                                row4[0] = "";
                            }
                            row4[1] = row3[1];
                            for (int n = 2; n < table.Columns.Count; n++)
                            {
                                if (row3[n] != DBNull.Value)
                                {
                                    string str9 = row3[n].ToString();
                                    if (Convert.ToDouble(row3[n]) > 10000.0)
                                    {
                                        int num5 = ((int) Convert.ToDouble(row3[n])) / 0x2710;
                                        string str10 = Convert.ToString(num5);
                                        string str11 = str9.Substring(str10.Length, str9.Length - str10.Length);
                                        row4[n] = str10 + "\n\r" + str11;
                                    }
                                    else
                                    {
                                        row4[n] = "\n\r" + str9;
                                    }
                                }
                            }
                            table2.Rows.Add(row4);
                        }
                    }
                    else if (str.Trim().ToUpper() == "B3")
                    {
                        table2.TableName = "B3";
                        foreach (DataColumn column5 in table.Columns)
                        {
                            DataColumn column6 = new DataColumn(column5.ColumnName, typeof(string));
                            table2.Columns.Add(column6);
                        }
                        string str12 = "";
                        foreach (DataRow row5 in table.Rows)
                        {
                            DataRow row6 = table2.NewRow();
                            row6[0] = row5[0];
                            string str13 = row5[0].ToString();
                            if (str12 != str13)
                            {
                                str12 = str13;
                            }
                            else
                            {
                                row6[0] = "";
                            }
                            row6[1] = row5[1];
                            for (int num6 = 2; num6 < table.Columns.Count; num6++)
                            {
                                if (row5[num6] != DBNull.Value)
                                {
                                    string str14 = row5[num6].ToString();
                                    if (Convert.ToDouble(row5[num6]) > 10000.0)
                                    {
                                        int num7 = ((int) Convert.ToDouble(row5[num6])) / 0x2710;
                                        string str15 = Convert.ToString(num7);
                                        string str16 = str14.Substring(str15.Length, str14.Length - str15.Length);
                                        row6[num6] = str15 + "\n\r" + str16;
                                    }
                                    else
                                    {
                                        row6[num6] = "\n\r" + str14;
                                    }
                                }
                            }
                            table2.Rows.Add(row6);
                        }
                    }
                    else if (str.Trim().ToUpper() == "B4")
                    {
                        table2 = table.Copy();
                        table2.TableName = "B4";
                        string str17 = "";
                        foreach (DataRow row7 in table2.Rows)
                        {
                            string str18 = row7[0].ToString();
                            if (str17 != str18)
                            {
                                str17 = str18;
                            }
                            else
                            {
                                row7[0] = "";
                            }
                        }
                    }
                    else if (str.Trim().ToUpper() == "B5")
                    {
                        table2 = table.Copy();
                        table2.TableName = "B5";
                        string str19 = "";
                        string str20 = "";
                        foreach (DataRow row8 in table2.Rows)
                        {
                            string str21 = row8[0].ToString();
                            if (str19 != str21)
                            {
                                str19 = str21;
                            }
                            else
                            {
                                row8[0] = "";
                            }
                            string str22 = row8[1].ToString();
                            if (str20 != str22)
                            {
                                str20 = str22;
                            }
                            else
                            {
                                row8[1] = "";
                            }
                        }
                    }
                    set.Tables.Add(table2);
                }
                num++;
                goto Label_002F;
            }
        }

        public void SaveZYDCTJB(string tjdwmc, string tjnd, DataSet tjds, string xlsModelPath, string xlsTargetPath)
        {
            if (!File.Exists(xlsModelPath))
            {
                MessageBox.Show(xlsModelPath + " 不存在，请检查!", "错误", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else
            {
                File.Copy(xlsModelPath, xlsTargetPath, true);
                Microsoft.Office.Interop.Excel.Application application = new ApplicationClass();
                try
                {
                    int num12;
                    if (application == null)
                    {
                        MessageBox.Show("不能建立Microsoft.Office.Interop.Excel对象，请在机器上安装MS Office软件！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        return;
                    }
                    object updateLinks = Missing.Value;
                    string filename = xlsTargetPath;
                    Workbook workbook = application.Workbooks.Open(filename, updateLinks, updateLinks, updateLinks, updateLinks, updateLinks, updateLinks, updateLinks, updateLinks, updateLinks, updateLinks, updateLinks, updateLinks, updateLinks, updateLinks);
                    application.Visible = false;
                    application.DisplayAlerts = false;
                    Worksheet worksheet = null;
                    application.ActiveWindow.DisplayZeros = false;
                    DataSet set = new DataSet("resultds");
                    int num = 0;
                Label_009F:
                    if (num >= tjds.Tables.Count)
                    {
                        goto Label_2E0F;
                    }
                    string tableName = tjds.Tables[num].TableName;
                    System.Data.DataTable table = tjds.Tables[num];
                    if ((table == null) || (table.Rows.Count <= 0))
                    {
                        goto Label_2DF3;
                    }
                    System.Data.DataTable table2 = new System.Data.DataTable("mytable");
                    if (tableName.Trim().ToUpper() == "B1")
                    {
                        table2.TableName = "B1";
                        foreach (DataColumn column in table.Columns)
                        {
                            DataColumn column2 = new DataColumn(column.ColumnName, typeof(string));
                            table2.Columns.Add(column2);
                        }
                        string str3 = "";
                        foreach (DataRow row in table.Rows)
                        {
                            DataRow row2 = table2.NewRow();
                            string str4 = row[0].ToString();
                            row2[0] = row[0];
                            if (str3 != str4)
                            {
                                str3 = str4;
                            }
                            else
                            {
                                row2[0] = "";
                            }
                            row2[1] = row[1];
                            for (int i = 2; i < (table.Columns.Count - 2); i++)
                            {
                                if (row[i] != DBNull.Value)
                                {
                                    string str5 = row[i].ToString();
                                    if (Convert.ToDouble(row[i]) > 1000.0)
                                    {
                                        int num3 = ((int) Convert.ToDouble(row[i])) / 0x3e8;
                                        string str6 = Convert.ToString(num3);
                                        string str7 = str5.Substring(str6.Length, str5.Length - str6.Length);
                                        row2[i] = str6 + "\n\r" + str7;
                                    }
                                    else
                                    {
                                        row2[i] = "\n\r" + str5;
                                    }
                                }
                            }
                            row2[table.Columns.Count - 2] = row[table.Columns.Count - 2].ToString() + "\n\r" + row[table.Columns.Count - 1].ToString();
                            table2.Rows.Add(row2);
                        }
                        table2.Columns.RemoveAt(table2.Columns.Count - 1);
                    }
                    else if (tableName.Trim().ToUpper() == "B1-1")
                    {
                        table2 = table.Copy();
                        table2.TableName = "B1-1";
                        string str8 = "";
                        string str9 = "";
                        foreach (DataRow row3 in table2.Rows)
                        {
                            string str10 = row3[0].ToString();
                            if (str8 != str10)
                            {
                                str8 = str10;
                            }
                            else
                            {
                                row3[0] = "";
                            }
                            string str11 = row3[1].ToString();
                            if (str9 != str11)
                            {
                                str9 = str11;
                            }
                            else
                            {
                                row3[1] = "";
                            }
                        }
                    }
                    else if (tableName.Trim().ToUpper() == "B1-2")
                    {
                        table2 = table.Copy();
                        table2.TableName = "B1-2";
                        string str12 = "";
                        foreach (DataRow row4 in table2.Rows)
                        {
                            string str13 = row4[0].ToString();
                            if (str12 != str13)
                            {
                                str12 = str13;
                            }
                            else
                            {
                                row4[0] = "";
                            }
                        }
                    }
                    else if (tableName.Trim().ToUpper() == "B1-3")
                    {
                        table2 = table.Copy();
                        table2.TableName = "B1-3";
                        string str14 = "";
                        foreach (DataRow row5 in table2.Rows)
                        {
                            string str15 = row5[0].ToString();
                            if (str14 != str15)
                            {
                                str14 = str15;
                            }
                            else
                            {
                                row5[0] = "";
                            }
                        }
                    }
                    else if (tableName.Trim().ToUpper() == "B2")
                    {
                        table2 = table.Copy();
                        table2.TableName = "B2";
                        string str16 = "";
                        foreach (DataRow row6 in table2.Rows)
                        {
                            string str17 = row6[0].ToString();
                            if (str16 != str17)
                            {
                                str16 = str17;
                            }
                            else
                            {
                                row6[0] = "";
                            }
                        }
                    }
                    else if (tableName.Trim().ToUpper() == "B2-1")
                    {
                        table2.TableName = "B2-1";
                        foreach (DataColumn column3 in table.Columns)
                        {
                            DataColumn column4 = new DataColumn(column3.ColumnName, typeof(string));
                            table2.Columns.Add(column4);
                        }
                        string str18 = "";
                        string str19 = "";
                        foreach (DataRow row7 in table.Rows)
                        {
                            DataRow row8 = table2.NewRow();
                            string str20 = row7[0].ToString();
                            row8[0] = row7[0];
                            if (str18 != str20)
                            {
                                str18 = str20;
                            }
                            else
                            {
                                row8[0] = "";
                            }
                            string str21 = row7[1].ToString();
                            row8[1] = row7[1];
                            if (str19 != str21)
                            {
                                str19 = str21;
                            }
                            else
                            {
                                row8[1] = "";
                            }
                            row8[2] = row7[2];
                            for (int j = 3; j < table.Columns.Count; j++)
                            {
                                if (row7[j] != DBNull.Value)
                                {
                                    string str22 = row7[j].ToString();
                                    if (Convert.ToDouble(row7[j]) > 1000.0)
                                    {
                                        int num5 = ((int) Convert.ToDouble(row7[j])) / 0x3e8;
                                        string str23 = Convert.ToString(num5);
                                        string str24 = str22.Substring(str23.Length, str22.Length - str23.Length);
                                        row8[j] = str23 + "\n\r" + str24;
                                    }
                                    else
                                    {
                                        row8[j] = "\n\r" + str22;
                                    }
                                }
                            }
                            table2.Rows.Add(row8);
                        }
                    }
                    else if (tableName.Trim().ToUpper() == "B3")
                    {
                        table2.TableName = "B3";
                        foreach (DataColumn column5 in table.Columns)
                        {
                            DataColumn column6 = new DataColumn(column5.ColumnName, typeof(string));
                            table2.Columns.Add(column6);
                        }
                        string str25 = "";
                        string str26 = "";
                        foreach (DataRow row9 in table.Rows)
                        {
                            DataRow row10 = table2.NewRow();
                            string str27 = row9[0].ToString();
                            row10[0] = row9[0];
                            if (str25 != str27)
                            {
                                str25 = str27;
                            }
                            else
                            {
                                row10[0] = "";
                            }
                            string str28 = row9[1].ToString();
                            row10[1] = row9[1];
                            if (str26 != str28)
                            {
                                str26 = str28;
                            }
                            else
                            {
                                row10[1] = "";
                            }
                            row10[2] = row9[2];
                            for (int k = 3; k < table.Columns.Count; k++)
                            {
                                if (row9[k] != DBNull.Value)
                                {
                                    string str29 = row9[k].ToString();
                                    if (Convert.ToDouble(row9[k]) > 1000.0)
                                    {
                                        int num7 = ((int) Convert.ToDouble(row9[k])) / 0x3e8;
                                        string str30 = Convert.ToString(num7);
                                        string str31 = str29.Substring(str30.Length, str29.Length - str30.Length);
                                        row10[k] = str30 + "\n\r" + str31;
                                    }
                                    else
                                    {
                                        row10[k] = "\n\r" + str29;
                                    }
                                }
                            }
                            table2.Rows.Add(row10);
                        }
                    }
                    else if (tableName.Trim().ToUpper() == "B4")
                    {
                        table2 = table.Copy();
                        table2.TableName = "B4";
                        string str32 = "";
                        string str33 = "";
                        string str34 = "";
                        foreach (DataRow row11 in table2.Rows)
                        {
                            string str35 = row11[0].ToString();
                            if (str32 != str35)
                            {
                                str32 = str35;
                            }
                            else
                            {
                                row11[0] = "";
                            }
                            string str36 = row11[1].ToString();
                            if (str33 != str36)
                            {
                                str33 = str36;
                            }
                            else
                            {
                                row11[1] = "";
                            }
                            string str37 = row11[2].ToString();
                            if (str34 != str37)
                            {
                                str34 = str37;
                            }
                            else
                            {
                                row11[2] = "";
                            }
                        }
                    }
                    else if (tableName.Trim().ToUpper() == "B5")
                    {
                        table2.TableName = "B5";
                        foreach (DataColumn column7 in table.Columns)
                        {
                            DataColumn column8 = new DataColumn(column7.ColumnName, typeof(string));
                            table2.Columns.Add(column8);
                        }
                        string str38 = "";
                        string str39 = "";
                        string str40 = "";
                        foreach (DataRow row12 in table.Rows)
                        {
                            DataRow row13 = table2.NewRow();
                            string str41 = row12[0].ToString();
                            row13[0] = row12[0];
                            if (str38 != str41)
                            {
                                str38 = str41;
                            }
                            else
                            {
                                row13[0] = "";
                            }
                            string str42 = row12[1].ToString();
                            row13[1] = row12[1];
                            if (str39 != str42)
                            {
                                str39 = str42;
                            }
                            else
                            {
                                row13[1] = "";
                            }
                            string str43 = row12[2].ToString();
                            row13[2] = row12[2];
                            if (str40 != str43)
                            {
                                str40 = str43;
                            }
                            else
                            {
                                row13[2] = "";
                            }
                            row13[3] = row12[3];
                            for (int m = 4; m < table.Columns.Count; m++)
                            {
                                if (row12[m] != DBNull.Value)
                                {
                                    string str44 = row12[m].ToString();
                                    if (Convert.ToDouble(row12[m]) > 1000.0)
                                    {
                                        int num9 = ((int) Convert.ToDouble(row12[m])) / 0x3e8;
                                        string str45 = Convert.ToString(num9);
                                        string str46 = str44.Substring(str45.Length, str44.Length - str45.Length);
                                        row13[m] = str45 + "\n\r" + str46;
                                    }
                                    else
                                    {
                                        row13[m] = "\n\r" + str44;
                                    }
                                }
                            }
                            table2.Rows.Add(row13);
                        }
                    }
                    else if (tableName.Trim().ToUpper() == "B6")
                    {
                        table2 = table.Copy();
                        table2.TableName = "B6";
                        string str47 = "";
                        string str48 = "";
                        string str49 = "";
                        foreach (DataRow row14 in table2.Rows)
                        {
                            string str50 = row14[0].ToString();
                            if (str47 != str50)
                            {
                                str47 = str50;
                            }
                            else
                            {
                                row14[0] = "";
                            }
                            string str51 = row14[1].ToString();
                            if (str48 != str51)
                            {
                                str48 = str51;
                            }
                            else
                            {
                                row14[1] = "";
                            }
                            string str52 = row14[2].ToString();
                            if (str49 != str52)
                            {
                                str49 = str52;
                            }
                            else
                            {
                                row14[2] = "";
                            }
                        }
                    }
                    else if (tableName.Trim().ToUpper() == "B7")
                    {
                        table2 = table.Copy();
                        table2.TableName = "B7";
                        string str53 = "";
                        string str54 = "";
                        string str55 = "";
                        foreach (DataRow row15 in table2.Rows)
                        {
                            string str56 = row15[0].ToString();
                            if (str53 != str56)
                            {
                                str53 = str56;
                            }
                            else
                            {
                                row15[0] = "";
                            }
                            string str57 = row15[1].ToString();
                            if (str54 != str57)
                            {
                                str54 = str57;
                            }
                            else
                            {
                                row15[1] = "";
                            }
                            string str58 = row15[2].ToString();
                            if (str55 != str58)
                            {
                                str55 = str58;
                            }
                            else
                            {
                                row15[2] = "";
                            }
                        }
                    }
                    else if (tableName.Trim().ToUpper() == "B8")
                    {
                        table2 = table.Copy();
                        table2.TableName = "B8";
                        string str59 = "";
                        string str60 = "";
                        foreach (DataRow row16 in table2.Rows)
                        {
                            string str61 = row16[0].ToString();
                            if (str59 != str61)
                            {
                                str59 = str61;
                            }
                            else
                            {
                                row16[0] = "";
                            }
                            string str62 = row16[1].ToString();
                            if (str60 != str62)
                            {
                                str60 = str62;
                            }
                            else
                            {
                                row16[1] = "";
                            }
                        }
                    }
                    else if (tableName.Trim().ToUpper() == "B9")
                    {
                        table2 = table.Copy();
                        table2.TableName = "B9";
                        string str63 = "";
                        string str64 = "";
                        string str65 = "";
                        foreach (DataRow row17 in table2.Rows)
                        {
                            string str66 = row17[0].ToString();
                            if (str63 != str66)
                            {
                                str63 = str66;
                            }
                            else
                            {
                                row17[0] = "";
                            }
                            string str67 = row17[1].ToString();
                            if (str64 != str67)
                            {
                                str64 = str67;
                            }
                            else
                            {
                                row17[1] = "";
                            }
                            string str68 = row17[2].ToString();
                            if (str65 != str68)
                            {
                                str65 = str68;
                            }
                            else
                            {
                                row17[2] = "";
                            }
                        }
                    }
                    else if (tableName.Trim().ToUpper() == "B10")
                    {
                        table2 = table.Copy();
                        table2.TableName = "B10";
                        string str69 = "";
                        string str70 = "";
                        string str71 = "";
                        foreach (DataRow row18 in table2.Rows)
                        {
                            string str72 = row18[0].ToString();
                            if (str69 != str72)
                            {
                                str69 = str72;
                            }
                            else
                            {
                                row18[0] = "";
                            }
                            string str73 = row18[1].ToString();
                            if (str70 != str73)
                            {
                                str70 = str73;
                            }
                            else
                            {
                                row18[1] = "";
                            }
                            string str74 = row18[2].ToString();
                            if (str71 != str74)
                            {
                                str71 = str74;
                            }
                            else
                            {
                                row18[2] = "";
                            }
                        }
                    }
                    else if (tableName.Trim().ToUpper() == "B11")
                    {
                        table2 = table.Copy();
                        table2.TableName = "B11";
                        string str75 = "";
                        string str76 = "";
                        foreach (DataRow row19 in table2.Rows)
                        {
                            string str77 = row19[0].ToString();
                            if (str75 != str77)
                            {
                                str75 = str77;
                            }
                            else
                            {
                                row19[0] = "";
                            }
                            string str78 = row19[1].ToString();
                            if (str76 != str78)
                            {
                                str76 = str78;
                            }
                            else
                            {
                                row19[1] = "";
                            }
                        }
                    }
                    else if (tableName.Trim().ToUpper() == "B12")
                    {
                        table2 = table.Copy();
                        table2.TableName = "B12";
                        string str79 = "";
                        string str80 = "";
                        string str81 = "";
                        foreach (DataRow row20 in table2.Rows)
                        {
                            string str82 = row20[0].ToString();
                            if (str79 != str82)
                            {
                                str79 = str82;
                            }
                            else
                            {
                                row20[0] = "";
                            }
                            string str83 = row20[1].ToString();
                            if (str80 != str83)
                            {
                                str80 = str83;
                            }
                            else
                            {
                                row20[1] = "";
                            }
                            string str84 = row20[2].ToString();
                            if (str81 != str84)
                            {
                                str81 = str84;
                            }
                            else
                            {
                                row20[2] = "";
                            }
                        }
                    }
                    else if (tableName.Trim().ToUpper() == "B13")
                    {
                        table2 = table.Copy();
                        table2.TableName = "B13";
                        string str85 = "";
                        string str86 = "";
                        string str87 = "";
                        foreach (DataRow row21 in table2.Rows)
                        {
                            string str88 = row21[0].ToString();
                            if (str85 != str88)
                            {
                                str85 = str88;
                            }
                            else
                            {
                                row21[0] = "";
                            }
                            string str89 = row21[1].ToString();
                            if (str86 != str89)
                            {
                                str86 = str89;
                            }
                            else
                            {
                                row21[1] = "";
                            }
                            string str90 = row21[2].ToString();
                            if (str87 != str90)
                            {
                                str87 = str90;
                            }
                            else
                            {
                                row21[2] = "";
                            }
                        }
                    }
                    else if (tableName.Trim().ToUpper() == "B14")
                    {
                        table2 = table.Copy();
                        table2.TableName = "B14";
                        string str91 = "";
                        string str92 = "";
                        foreach (DataRow row22 in table2.Rows)
                        {
                            string str93 = row22[0].ToString();
                            if (str91 != str93)
                            {
                                str91 = str93;
                            }
                            else
                            {
                                row22[0] = "";
                            }
                            string str94 = row22[1].ToString();
                            if (str92 != str94)
                            {
                                str92 = str94;
                            }
                            else
                            {
                                row22[1] = "";
                            }
                        }
                    }
                    else if (tableName.Trim().ToUpper() == "B15")
                    {
                        table2 = table.Copy();
                        table2.TableName = "B15";
                        string str95 = "";
                        string str96 = "";
                        string str97 = "";
                        foreach (DataRow row23 in table2.Rows)
                        {
                            string str98 = row23[0].ToString();
                            if (str95 != str98)
                            {
                                str95 = str98;
                            }
                            else
                            {
                                row23[0] = "";
                            }
                            string str99 = row23[1].ToString();
                            if (str96 != str99)
                            {
                                str96 = str99;
                            }
                            else
                            {
                                row23[1] = "";
                            }
                            string str100 = row23[2].ToString();
                            if (str97 != str100)
                            {
                                str97 = str100;
                            }
                            else
                            {
                                row23[2] = "";
                            }
                        }
                    }
                    else if (tableName.Trim().ToUpper() == "B16")
                    {
                        table2 = table.Copy();
                        table2.TableName = "B16";
                        string str101 = "";
                        string str102 = "";
                        string str103 = "";
                        foreach (DataRow row24 in table2.Rows)
                        {
                            string str104 = row24[0].ToString();
                            if (str101 != str104)
                            {
                                str101 = str104;
                            }
                            else
                            {
                                row24[0] = "";
                            }
                            string str105 = row24[1].ToString();
                            if (str102 != str105)
                            {
                                str102 = str105;
                            }
                            else
                            {
                                row24[1] = "";
                            }
                            string str106 = row24[2].ToString();
                            if (str103 != str106)
                            {
                                str103 = str106;
                            }
                            else
                            {
                                row24[2] = "";
                            }
                        }
                    }
                    else if (tableName.Trim().ToUpper() == "B17")
                    {
                        table2 = table.Copy();
                        table2.TableName = "B17";
                        string str107 = "";
                        string str108 = "";
                        foreach (DataRow row25 in table2.Rows)
                        {
                            string str109 = row25[0].ToString();
                            if (str107 != str109)
                            {
                                str107 = str109;
                            }
                            else
                            {
                                row25[0] = "";
                            }
                            string str110 = row25[1].ToString();
                            if (str108 != str110)
                            {
                                str108 = str110;
                            }
                            else
                            {
                                row25[1] = "";
                            }
                        }
                    }
                    else if (tableName.Trim().ToUpper() == "B18")
                    {
                        table2 = table.Copy();
                        table2.TableName = "B18";
                        string str111 = "";
                        string str112 = "";
                        string str113 = "";
                        foreach (DataRow row26 in table2.Rows)
                        {
                            string str114 = row26[0].ToString();
                            if (str111 != str114)
                            {
                                str111 = str114;
                            }
                            else
                            {
                                row26[0] = "";
                            }
                            string str115 = row26[1].ToString();
                            if (str112 != str115)
                            {
                                str112 = str115;
                            }
                            else
                            {
                                row26[1] = "";
                            }
                            string str116 = row26[2].ToString();
                            if (str113 != str116)
                            {
                                str113 = str116;
                            }
                            else
                            {
                                row26[2] = "";
                            }
                        }
                    }
                    else if (tableName.Trim().ToUpper() == "B19")
                    {
                        table2 = table.Copy();
                        table2.TableName = "B19";
                        string str117 = "";
                        foreach (DataRow row27 in table2.Rows)
                        {
                            string str118 = row27[0].ToString();
                            if (str117 != str118)
                            {
                                str117 = str118;
                            }
                            else
                            {
                                row27[0] = "";
                            }
                        }
                    }
                    else if (tableName.Trim().ToUpper() == "B20")
                    {
                        table2 = table.Copy();
                        table2.TableName = "B20";
                        string str119 = "";
                        foreach (DataRow row28 in table2.Rows)
                        {
                            string str120 = row28[0].ToString();
                            if (str119 != str120)
                            {
                                str119 = str120;
                            }
                            else
                            {
                                row28[0] = "";
                            }
                        }
                    }
                    else if (tableName.Trim().ToUpper() == "B21")
                    {
                        table2 = table.Copy();
                        table2.TableName = "B21";
                        string str121 = "";
                        foreach (DataRow row29 in table2.Rows)
                        {
                            string str122 = row29[0].ToString();
                            if (str121 != str122)
                            {
                                str121 = str122;
                            }
                            else
                            {
                                row29[0] = "";
                            }
                        }
                    }
                    else if (tableName.Trim().ToUpper() == "B22")
                    {
                        table2 = table.Copy();
                        table2.TableName = "B22";
                        string str123 = "";
                        foreach (DataRow row30 in table2.Rows)
                        {
                            string str124 = row30[0].ToString();
                            if (str123 != str124)
                            {
                                str123 = str124;
                            }
                            else
                            {
                                row30[0] = "";
                            }
                        }
                    }
                    else if (tableName.Trim().ToUpper() == "B23")
                    {
                        table2 = table.Copy();
                        table2.TableName = "B23";
                        string str125 = "";
                        foreach (DataRow row31 in table2.Rows)
                        {
                            string str126 = row31[0].ToString();
                            if (str125 != str126)
                            {
                                str125 = str126;
                            }
                            else
                            {
                                row31[0] = "";
                            }
                        }
                    }
                    else if (tableName.Trim().ToUpper() == "B24")
                    {
                        table2 = table.Copy();
                        table2.TableName = "B24";
                        string str127 = "";
                        foreach (DataRow row32 in table2.Rows)
                        {
                            string str128 = row32[0].ToString();
                            if (str127 != str128)
                            {
                                str127 = str128;
                            }
                            else
                            {
                                row32[0] = "";
                            }
                        }
                    }
                    else if (tableName.Trim().ToUpper() == "B25")
                    {
                        table2 = table.Copy();
                        table2.TableName = "B25";
                        string str129 = "";
                        foreach (DataRow row33 in table2.Rows)
                        {
                            string str130 = row33[0].ToString();
                            if (str129 != str130)
                            {
                                str129 = str130;
                            }
                            else
                            {
                                row33[0] = "";
                            }
                        }
                    }
                    else if (tableName.Trim().ToUpper() == "B26")
                    {
                        table2 = table.Copy();
                        table2.TableName = "B26";
                        string str131 = "";
                        foreach (DataRow row34 in table2.Rows)
                        {
                            string str132 = row34[0].ToString();
                            if (str131 != str132)
                            {
                                str131 = str132;
                            }
                            else
                            {
                                row34[0] = "";
                            }
                        }
                    }
                    else if (tableName.Trim().ToUpper() == "B27")
                    {
                        table2 = table.Copy();
                        table2.TableName = "B27";
                        string str133 = "";
                        string str134 = "";
                        foreach (DataRow row35 in table2.Rows)
                        {
                            string str135 = row35[0].ToString();
                            if (str133 != str135)
                            {
                                str133 = str135;
                            }
                            else
                            {
                                row35[0] = "";
                            }
                            string str136 = row35[1].ToString();
                            if (str134 != str136)
                            {
                                str134 = str136;
                            }
                            else
                            {
                                row35[1] = "";
                            }
                        }
                    }
                    else if (tableName.Trim().ToUpper() == "B28")
                    {
                        table2.TableName = "B28";
                        foreach (DataColumn column9 in table.Columns)
                        {
                            DataColumn column10 = new DataColumn(column9.ColumnName, typeof(string));
                            table2.Columns.Add(column10);
                        }
                        foreach (DataRow row36 in table.Rows)
                        {
                            DataRow row37 = table2.NewRow();
                            row37[0] = row36[0];
                            row37[1] = row36[1];
                            for (int n = 2; n < table.Columns.Count; n++)
                            {
                                if (row36[n] != DBNull.Value)
                                {
                                    string str137 = row36[n].ToString();
                                    if (Convert.ToDouble(row36[n]) > 1000.0)
                                    {
                                        int num11 = ((int) Convert.ToDouble(row36[n])) / 0x3e8;
                                        string str138 = Convert.ToString(num11);
                                        string str139 = str137.Substring(str138.Length, str137.Length - str138.Length);
                                        row37[n] = str138 + "\n\r" + str139;
                                    }
                                    else
                                    {
                                        row37[n] = "\n\r" + str137;
                                    }
                                }
                            }
                            table2.Rows.Add(row37);
                        }
                    }
                    else if (tableName.Trim().ToUpper() == "B29")
                    {
                        table2 = table.Copy();
                        table2.TableName = "B29";
                        string str140 = "";
                        string str141 = "";
                        foreach (DataRow row38 in table2.Rows)
                        {
                            string str142 = row38[0].ToString();
                            if (str140 != str142)
                            {
                                str140 = str142;
                            }
                            else
                            {
                                row38[0] = "";
                            }
                            string str143 = row38[1].ToString();
                            if (str141 != str143)
                            {
                                str141 = str143;
                            }
                            else if (row38[2].ToString() != "合  计")
                            {
                                row38[1] = "";
                            }
                            else
                            {
                                str141 = str143;
                            }
                        }
                    }
                    else if (tableName.Trim().ToUpper() == "B30")
                    {
                        table2 = table.Copy();
                        table2.TableName = "B30";
                        string str144 = "";
                        string str145 = "";
                        foreach (DataRow row39 in table2.Rows)
                        {
                            string str146 = row39[0].ToString();
                            if (str144 != str146)
                            {
                                str144 = str146;
                            }
                            else
                            {
                                row39[0] = "";
                            }
                            string str147 = row39[1].ToString();
                            if (str145 != str147)
                            {
                                str145 = str147;
                            }
                            else if (row39[2].ToString() != "合  计")
                            {
                                row39[1] = "";
                            }
                            else
                            {
                                str145 = str147;
                            }
                        }
                    }
                    else if (tableName.Trim().ToUpper() == "B31")
                    {
                        table2 = table.Copy();
                        table2.TableName = "B31";
                        string str148 = "";
                        string str149 = "";
                        foreach (DataRow row40 in table2.Rows)
                        {
                            string str150 = row40[0].ToString();
                            if (str148 != str150)
                            {
                                str148 = str150;
                            }
                            else
                            {
                                row40[0] = "";
                            }
                            string str151 = row40[1].ToString();
                            if (str149 != str151)
                            {
                                str149 = str151;
                            }
                            else if (row40[2].ToString() != "合  计")
                            {
                                row40[1] = "";
                            }
                            else
                            {
                                str149 = str151;
                            }
                        }
                    }
                    else if (tableName.Trim().ToUpper() == "B32")
                    {
                        table2 = table.Copy();
                        table2.TableName = "B32";
                        string str152 = "";
                        string str153 = "";
                        string str154 = "";
                        foreach (DataRow row41 in table2.Rows)
                        {
                            string str155 = row41[0].ToString();
                            if (str152 != str155)
                            {
                                str152 = str155;
                            }
                            else
                            {
                                row41[0] = "";
                            }
                            string str156 = row41[1].ToString();
                            if (str153 != str156)
                            {
                                str153 = str156;
                            }
                            else if ((row41[2].ToString() == "合  计") && (row41[3].ToString() == "合  计"))
                            {
                                str153 = str156;
                            }
                            else
                            {
                                row41[1] = "";
                            }
                            string str157 = row41[2].ToString();
                            if (str154 != str157)
                            {
                                str154 = str157;
                            }
                            else
                            {
                                row41[2] = "";
                            }
                        }
                    }
                    else if (tableName.Trim().ToUpper() == "B33")
                    {
                        table2 = table.Copy();
                        table2.TableName = "B33";
                        string str158 = "";
                        string str159 = "";
                        string str160 = "";
                        string str161 = "";
                        foreach (DataRow row42 in table2.Rows)
                        {
                            string str162 = row42[0].ToString();
                            if (str158 != str162)
                            {
                                str158 = str162;
                            }
                            else
                            {
                                row42[0] = "";
                            }
                            string str163 = row42[1].ToString();
                            if (str159 != str163)
                            {
                                str159 = str163;
                            }
                            else if (((row42[2].ToString() == "合  计") && (row42[3].ToString() == "合  计")) && (row42[4].ToString() == "合  计"))
                            {
                                str159 = str163;
                            }
                            else
                            {
                                row42[1] = "";
                            }
                            string str164 = row42[2].ToString();
                            if (str160 != str164)
                            {
                                str160 = str164;
                            }
                            else
                            {
                                row42[2] = "";
                            }
                            string str165 = row42[3].ToString();
                            if (str161 != str165)
                            {
                                str161 = str165;
                            }
                            else
                            {
                                row42[3] = "";
                            }
                        }
                    }
                    else if (tableName.Trim().ToUpper() == "B34")
                    {
                        table2 = table.Copy();
                        table2.TableName = "B34";
                        string str166 = "";
                        string str167 = "";
                        foreach (DataRow row43 in table2.Rows)
                        {
                            string str168 = row43[0].ToString();
                            if (str166 != str168)
                            {
                                str166 = str168;
                            }
                            else
                            {
                                row43[0] = "";
                            }
                            string str169 = row43[1].ToString();
                            if (str167 != str169)
                            {
                                str167 = str169;
                            }
                            else
                            {
                                row43[1] = "";
                            }
                        }
                    }
                    else if (tableName.Trim().ToUpper() == "B35")
                    {
                        table2 = table.Copy();
                        table2.TableName = "B35";
                        string str170 = "";
                        foreach (DataRow row44 in table2.Rows)
                        {
                            string str171 = row44[0].ToString();
                            if (str170 != str171)
                            {
                                str170 = str171;
                            }
                            else
                            {
                                row44[0] = "";
                            }
                        }
                    }
                    else if (tableName.Trim().ToUpper() == "B40")
                    {
                        table2 = table.Copy();
                        table2.TableName = "B40";
                    }
                    else if (tableName.Trim().ToUpper() == "B41")
                    {
                        table2 = table.Copy();
                        table2.TableName = "B41";
                    }
                    goto Label_2DFE;
                Label_2DA4:
                    if ((table2.TableName != "B40") && (table2.TableName != "B41"))
                    {
                        table2.Rows[0][0] = tjdwmc;
                    }
                Label_2DDE:
                    table2.AcceptChanges();
                    set.Tables.Add(table2);
                Label_2DF3:
                    num++;
                    goto Label_009F;
                Label_2DFE:
                    if (table2.Rows.Count <= 0)
                    {
                        goto Label_2DDE;
                    }
                    goto Label_2DA4;
                Label_2E0F:
                    num12 = 0;
                    while (num12 < set.Tables.Count)
                    {
                        System.Data.DataTable table3 = set.Tables[num12];
                        string str172 = table3.TableName;
                        int count = table3.Rows.Count;
                        int num14 = table3.Columns.Count;
                        object[,] objArray = new object[count, num14];
                        for (int num15 = 0; num15 < count; num15++)
                        {
                            for (int num16 = 0; num16 < num14; num16++)
                            {
                                objArray[num15, num16] = table3.Rows[num15][num16].ToString().Trim();
                            }
                        }
                        if (str172.Trim().ToUpper() == "B1")
                        {
                            worksheet = application.Sheets[2] as Worksheet;
                            int num17 = worksheet.UsedRange.Rows.Count;
                            worksheet.get_Range("B2", "B2").Value2 = tjdwmc;
                            worksheet.get_Range("G2", "G2").Value2 = "统计年度：" + tjnd;
                            int num19 = (count + 7) - 1;
                            worksheet.get_Range(worksheet.Cells[7, 1], worksheet.Cells[num17 + 6, num14]).EntireRow.Delete(updateLinks);
                            worksheet.get_Range(worksheet.Cells[7, 1], worksheet.Cells[num19, num14]).RowHeight = 0x19;
                            worksheet.get_Range(worksheet.Cells[7, 1], worksheet.Cells[num19, num14]).NumberFormatLocal = "@";
                            worksheet.get_Range(worksheet.Cells[7, 1], worksheet.Cells[num19, num14]).Value2 = objArray;
                            worksheet.get_Range(worksheet.Cells[7, 1], worksheet.Cells[num19, num14]).Font.Size = 9;
                            worksheet.get_Range(worksheet.Cells[7, 1], worksheet.Cells[num19, 2]).HorizontalAlignment = XlHAlign.xlHAlignCenter;
                            worksheet.get_Range(worksheet.Cells[7, 1], worksheet.Cells[num19, 2]).VerticalAlignment = XlVAlign.xlVAlignCenter;
                            worksheet.get_Range(worksheet.Cells[7, 3], worksheet.Cells[num19, num14]).HorizontalAlignment = XlHAlign.xlHAlignRight;
                            worksheet.get_Range(worksheet.Cells[7, 3], worksheet.Cells[num19, num14]).VerticalAlignment = XlVAlign.xlVAlignBottom;
                            worksheet.get_Range(worksheet.Cells[7, 1], worksheet.Cells[num19, num14]).Borders.LineStyle = XlLineStyle.xlContinuous;
                            worksheet.get_Range(worksheet.Cells[7, 1], worksheet.Cells[num19, num14]).Borders.Weight = XlBorderWeight.xlHairline;
                            worksheet.Select(updateLinks);
                            worksheet.get_Range("A1", "A1").Select();
                        }
                        else if (str172.Trim().ToUpper() == "B1-1")
                        {
                            worksheet = application.Sheets[3] as Worksheet;
                            int num20 = worksheet.UsedRange.Rows.Count;
                            worksheet.get_Range("B2", "B2").Value2 = tjdwmc;
                            worksheet.get_Range("G2", "G2").Value2 = "统计年度：" + tjnd;
                            int num22 = (count + 6) - 1;
                            int num23 = (num20 + 6) - 1;
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num23, num14]).EntireRow.Delete(updateLinks);
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num22, num14]).NumberFormatLocal = "@";
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num22, num14]).Value2 = objArray;
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num22, num14]).Font.Size = 10;
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num22, num14]).RowHeight = 20;
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num22, 1]).HorizontalAlignment = XlHAlign.xlHAlignCenter;
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num22, 1]).VerticalAlignment = XlVAlign.xlVAlignCenter;
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num22, num14]).Borders.LineStyle = XlLineStyle.xlContinuous;
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num22, num14]).Borders.Weight = XlBorderWeight.xlHairline;
                            worksheet.Select(updateLinks);
                            worksheet.get_Range("A1", "A1").Select();
                        }
                        else if (str172.Trim().ToUpper() == "B1-2")
                        {
                            worksheet = application.Sheets[4] as Worksheet;
                            int num24 = worksheet.UsedRange.Rows.Count;
                            worksheet.get_Range("B2", "B2").Value2 = tjdwmc;
                            worksheet.get_Range("F2", "F2").Value2 = "统计年度：" + tjnd;
                            int num26 = (count + 6) - 1;
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num24 + 7, num14]).EntireRow.Delete(updateLinks);
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num26, num14]).NumberFormatLocal = "@";
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num26, num14]).Value2 = objArray;
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num26, num14]).Font.Size = 10;
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num26, num14]).RowHeight = 20;
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num26, 2]).HorizontalAlignment = XlHAlign.xlHAlignCenter;
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num26, 2]).VerticalAlignment = XlVAlign.xlVAlignCenter;
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num26, num14]).Borders.LineStyle = XlLineStyle.xlContinuous;
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num26, num14]).Borders.Weight = XlBorderWeight.xlHairline;
                            worksheet.Select(updateLinks);
                            worksheet.get_Range("A1", "A1").Select();
                        }
                        else if (str172.Trim().ToUpper() == "B1-3")
                        {
                            worksheet = application.Sheets[5] as Worksheet;
                            int num27 = worksheet.UsedRange.Rows.Count;
                            worksheet.get_Range("B2", "B2").Value2 = tjdwmc;
                            worksheet.get_Range("E2", "E2").Value2 = "统计年度：" + tjnd;
                            int num29 = (count + 6) - 1;
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num27 + 7, num14]).EntireRow.Delete(updateLinks);
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num29, num14]).NumberFormatLocal = "@";
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num29, num14]).Value2 = objArray;
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num29, num14]).Font.Size = 10;
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num29, num14]).RowHeight = 20;
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num29, 2]).HorizontalAlignment = XlHAlign.xlHAlignCenter;
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num29, 2]).VerticalAlignment = XlVAlign.xlVAlignCenter;
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num29, num14]).Borders.LineStyle = XlLineStyle.xlContinuous;
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num29, num14]).Borders.Weight = XlBorderWeight.xlHairline;
                            worksheet.Select(updateLinks);
                            worksheet.get_Range("A1", "A1").Select();
                        }
                        else if (str172.Trim().ToUpper() == "B2")
                        {
                            worksheet = application.Sheets[6] as Worksheet;
                            int num1 = worksheet.UsedRange.Rows.Count;
                            int num32 = (count + 7) - 1;
                            worksheet.get_Range("B2", "B2").Value2 = tjdwmc;
                            worksheet.get_Range("G2", "G2").Value2 = "统计年度：" + tjnd;
                            worksheet.get_Range(worksheet.Cells[7, 1], worksheet.Cells[num32, num14]).EntireRow.Delete(updateLinks);
                            worksheet.get_Range(worksheet.Cells[7, 1], worksheet.Cells[num32, num14]).NumberFormatLocal = "@";
                            worksheet.get_Range(worksheet.Cells[7, 1], worksheet.Cells[num32, num14]).Value2 = objArray;
                            worksheet.get_Range(worksheet.Cells[7, 1], worksheet.Cells[num32, num14]).Font.Size = 10;
                            worksheet.get_Range(worksheet.Cells[7, 1], worksheet.Cells[num32, num14]).RowHeight = 20;
                            worksheet.get_Range(worksheet.Cells[7, 1], worksheet.Cells[num32, 2]).HorizontalAlignment = 3;
                            worksheet.get_Range(worksheet.Cells[7, 1], worksheet.Cells[num32, 2]).VerticalAlignment = 2;
                            worksheet.get_Range(worksheet.Cells[7, 1], worksheet.Cells[num32, num14]).Borders.LineStyle = XlLineStyle.xlContinuous;
                            worksheet.get_Range(worksheet.Cells[7, 1], worksheet.Cells[num32, num14]).Borders.Weight = XlBorderWeight.xlHairline;
                            worksheet.Select(updateLinks);
                            worksheet.get_Range("A1", "A1").Select();
                        }
                        else if (str172.Trim().ToUpper() == "B2-1")
                        {
                            worksheet = application.Sheets[7] as Worksheet;
                            int num142 = worksheet.UsedRange.Rows.Count;
                            int num35 = (count + 6) - 1;
                            worksheet.get_Range("B2", "B2").Value2 = tjdwmc;
                            worksheet.get_Range("G2", "G2").Value2 = "统计年度：" + tjnd;
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num35, num14]).EntireRow.Delete(updateLinks);
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num35, num14]).RowHeight = 0x19;
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num35, num14]).NumberFormatLocal = "@";
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num35, num14]).Value2 = objArray;
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num35, num14]).Font.Size = 10;
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num35, 3]).HorizontalAlignment = 3;
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num35, 3]).VerticalAlignment = XlVAlign.xlVAlignCenter;
                            worksheet.get_Range(worksheet.Cells[6, 4], worksheet.Cells[num35, num14]).VerticalAlignment = XlVAlign.xlVAlignBottom;
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num35, num14]).Borders.LineStyle = XlLineStyle.xlContinuous;
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num35, num14]).Borders.Weight = XlBorderWeight.xlHairline;
                            worksheet.Select(updateLinks);
                            worksheet.get_Range("A1", "A1").Select();
                        }
                        else if (str172.Trim().ToUpper() == "B3")
                        {
                            worksheet = application.Sheets[8] as Worksheet;
                            int num143 = worksheet.UsedRange.Rows.Count;
                            int num38 = (count + 8) - 1;
                            worksheet.get_Range("B2", "B2").Value2 = tjdwmc;
                            worksheet.get_Range("G2", "G2").Value2 = "统计年度：" + tjnd;
                            worksheet.get_Range(worksheet.Cells[8, 1], worksheet.Cells[num38, num14]).EntireRow.Delete(updateLinks);
                            worksheet.get_Range(worksheet.Cells[8, 1], worksheet.Cells[num38, num14]).RowHeight = 0x19;
                            worksheet.get_Range(worksheet.Cells[8, 1], worksheet.Cells[num38, num14]).NumberFormatLocal = "@";
                            worksheet.get_Range(worksheet.Cells[8, 1], worksheet.Cells[num38, num14]).Value2 = objArray;
                            worksheet.get_Range(worksheet.Cells[8, 1], worksheet.Cells[num38, num14]).Font.Size = 10;
                            worksheet.get_Range(worksheet.Cells[8, 1], worksheet.Cells[num38, 2]).HorizontalAlignment = XlHAlign.xlHAlignCenter;
                            worksheet.get_Range(worksheet.Cells[8, 1], worksheet.Cells[num38, 2]).VerticalAlignment = XlVAlign.xlVAlignCenter;
                            worksheet.get_Range(worksheet.Cells[8, 3], worksheet.Cells[num38, num14]).VerticalAlignment = XlVAlign.xlVAlignBottom;
                            worksheet.get_Range(worksheet.Cells[8, 1], worksheet.Cells[num38, num14]).Borders.LineStyle = XlLineStyle.xlContinuous;
                            worksheet.get_Range(worksheet.Cells[8, 1], worksheet.Cells[num38, num14]).Borders.Weight = XlBorderWeight.xlHairline;
                            worksheet.Select(updateLinks);
                            worksheet.get_Range("A1", "A1").Select();
                        }
                        else if (str172.Trim().ToUpper() == "B4")
                        {
                            worksheet = application.Sheets[9] as Worksheet;
                            int num144 = worksheet.UsedRange.Rows.Count;
                            int num41 = (count + 5) - 1;
                            worksheet.get_Range("B2", "B2").Value2 = tjdwmc;
                            worksheet.get_Range("F2", "F2").Value2 = "统计年度：" + tjnd;
                            worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num41, num14]).EntireRow.Delete(updateLinks);
                            worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num41, num14]).NumberFormatLocal = "@";
                            worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num41, num14]).Value2 = objArray;
                            worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num41, num14]).Font.Size = 10;
                            worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num41, num14]).RowHeight = 20;
                            worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num41, 4]).HorizontalAlignment = 3;
                            worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num41, 4]).VerticalAlignment = 2;
                            worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num41, num14]).Borders.LineStyle = XlLineStyle.xlContinuous;
                            worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num41, num14]).Borders.Weight = XlBorderWeight.xlHairline;
                            worksheet.Select(updateLinks);
                            worksheet.get_Range("A1", "A1").Select();
                        }
                        else if (str172.Trim().ToUpper() == "B5")
                        {
                            worksheet = application.Sheets[10] as Worksheet;
                            int num145 = worksheet.UsedRange.Rows.Count;
                            int num44 = (count + 6) - 1;
                            worksheet.get_Range("B2", "B2").Value2 = tjdwmc;
                            worksheet.get_Range("G2", "G2").Value2 = "统计年度：" + tjnd;
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num44, num14]).EntireRow.Delete(updateLinks);
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num44, num14]).RowHeight = 0x19;
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num44, num14]).NumberFormatLocal = "@";
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num44, num14]).Value2 = objArray;
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num44, num14]).Font.Size = 10;
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num44, 4]).HorizontalAlignment = 3;
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num44, 4]).VerticalAlignment = XlVAlign.xlVAlignCenter;
                            worksheet.get_Range(worksheet.Cells[6, 5], worksheet.Cells[num44, num14]).VerticalAlignment = XlVAlign.xlVAlignBottom;
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num44, num14]).Borders.LineStyle = XlLineStyle.xlContinuous;
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num44, num14]).Borders.Weight = XlBorderWeight.xlHairline;
                            worksheet.Select(updateLinks);
                            worksheet.get_Range("A1", "A1").Select();
                        }
                        else if (str172.Trim().ToUpper() == "B6")
                        {
                            worksheet = application.Sheets[11] as Worksheet;
                            int num146 = worksheet.UsedRange.Rows.Count;
                            int num47 = (count + 8) - 1;
                            worksheet.get_Range("B2", "B2").Value2 = tjdwmc;
                            worksheet.get_Range("F2", "F2").Value2 = "统计年度：" + tjnd;
                            worksheet.get_Range(worksheet.Cells[8, 1], worksheet.Cells[num47, num14]).EntireRow.Delete(updateLinks);
                            worksheet.get_Range(worksheet.Cells[8, 1], worksheet.Cells[num47, num14]).NumberFormatLocal = "@";
                            worksheet.get_Range(worksheet.Cells[8, 1], worksheet.Cells[num47, num14]).Value2 = objArray;
                            worksheet.get_Range(worksheet.Cells[8, 1], worksheet.Cells[num47, num14]).Font.Size = 10;
                            worksheet.get_Range(worksheet.Cells[8, 1], worksheet.Cells[num47, num14]).RowHeight = 20;
                            worksheet.get_Range(worksheet.Cells[8, 1], worksheet.Cells[num47, 3]).HorizontalAlignment = 3;
                            worksheet.get_Range(worksheet.Cells[8, 1], worksheet.Cells[num47, 3]).VerticalAlignment = 2;
                            worksheet.get_Range(worksheet.Cells[8, 1], worksheet.Cells[num47, num14]).Borders.LineStyle = XlLineStyle.xlContinuous;
                            worksheet.get_Range(worksheet.Cells[8, 1], worksheet.Cells[num47, num14]).Borders.Weight = XlBorderWeight.xlHairline;
                            worksheet.Select(updateLinks);
                            worksheet.get_Range("A1", "A1").Select();
                        }
                        else if (str172.Trim().ToUpper() == "B7")
                        {
                            worksheet = application.Sheets[12] as Worksheet;
                            int num147 = worksheet.UsedRange.Rows.Count;
                            int num50 = (count + 5) - 1;
                            worksheet.get_Range("B2", "B2").Value2 = tjdwmc;
                            worksheet.get_Range("G2", "G2").Value2 = "统计年度：" + tjnd;
                            worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num50, num14]).EntireRow.Delete(updateLinks);
                            worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num50, num14]).NumberFormatLocal = "@";
                            worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num50, num14]).Value2 = objArray;
                            worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num50, num14]).Font.Size = 10;
                            worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num50, num14]).RowHeight = 20;
                            worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num50, 3]).VerticalAlignment = 2;
                            worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num50, 3]).HorizontalAlignment = 3;
                            worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num50, num14]).Borders.LineStyle = XlLineStyle.xlContinuous;
                            worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num50, num14]).Borders.Weight = XlBorderWeight.xlHairline;
                            worksheet.Select(updateLinks);
                            worksheet.get_Range("A1", "A1").Select();
                        }
                        else if (str172.Trim().ToUpper() == "B8")
                        {
                            worksheet = application.Sheets[13] as Worksheet;
                            int num148 = worksheet.UsedRange.Rows.Count;
                            int num53 = (count + 6) - 1;
                            worksheet.get_Range("B2", "B2").Value2 = tjdwmc;
                            worksheet.get_Range("G2", "G2").Value2 = "统计年度：" + tjnd;
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num53, num14]).EntireRow.Delete(updateLinks);
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num53, num14]).NumberFormatLocal = "@";
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num53, num14]).Value2 = objArray;
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num53, num14]).Font.Size = 10;
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num53, num14]).RowHeight = 20;
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num53, 3]).HorizontalAlignment = 3;
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num53, 3]).VerticalAlignment = 2;
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num53, num14]).Borders.LineStyle = XlLineStyle.xlContinuous;
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num53, num14]).Borders.Weight = XlBorderWeight.xlHairline;
                            worksheet.Select(updateLinks);
                            worksheet.get_Range("A1", "A1").Select();
                        }
                        else if (str172.Trim().ToUpper() == "B9")
                        {
                            worksheet = application.Sheets[14] as Worksheet;
                            int num149 = worksheet.UsedRange.Rows.Count;
                            int num56 = (count + 6) - 1;
                            worksheet.get_Range("B2", "B2").Value2 = tjdwmc;
                            worksheet.get_Range("F2", "F2").Value2 = "统计年度：" + tjnd;
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num56, num14]).EntireRow.Delete(updateLinks);
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num56, num14]).NumberFormatLocal = "@";
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num56, num14]).Value2 = objArray;
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num56, num14]).Font.Size = 10;
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num56, num14]).RowHeight = 20;
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num56, 3]).HorizontalAlignment = 3;
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num56, 3]).VerticalAlignment = 2;
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num56, num14]).Borders.LineStyle = XlLineStyle.xlContinuous;
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num56, num14]).Borders.Weight = XlBorderWeight.xlHairline;
                            worksheet.Select(updateLinks);
                            worksheet.get_Range("A1", "A1").Select();
                        }
                        else if (str172.Trim().ToUpper() == "B10")
                        {
                            worksheet = application.Sheets[15] as Worksheet;
                            int num150 = worksheet.UsedRange.Rows.Count;
                            int num59 = (count + 5) - 1;
                            worksheet.get_Range("B2", "B2").Value2 = tjdwmc;
                            worksheet.get_Range("F2", "F2").Value2 = "统计年度：" + tjnd;
                            worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num59, num14]).EntireRow.Delete(updateLinks);
                            worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num59, num14]).NumberFormatLocal = "@";
                            worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num59, num14]).Value2 = objArray;
                            worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num59, num14]).Font.Size = 10;
                            worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num59, num14]).RowHeight = 20;
                            worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num59, 4]).VerticalAlignment = 2;
                            worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num59, 4]).HorizontalAlignment = 3;
                            worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num59, num14]).Borders.LineStyle = XlLineStyle.xlContinuous;
                            worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num59, num14]).Borders.Weight = XlBorderWeight.xlHairline;
                            worksheet.Select(updateLinks);
                            worksheet.get_Range("A1", "A1").Select();
                        }
                        else if (str172.Trim().ToUpper() == "B11")
                        {
                            worksheet = application.Sheets[0x10] as Worksheet;
                            int num151 = worksheet.UsedRange.Rows.Count;
                            int num62 = (count + 6) - 1;
                            worksheet.get_Range("B2", "B2").Value2 = tjdwmc;
                            worksheet.get_Range("F2", "F2").Value2 = "统计年度：" + tjnd;
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num62, num14]).EntireRow.Delete(updateLinks);
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num62, num14]).NumberFormatLocal = "@";
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num62, num14]).Value2 = objArray;
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num62, num14]).Font.Size = 10;
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num62, num14]).RowHeight = 20;
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num62, 3]).VerticalAlignment = 2;
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num62, 3]).HorizontalAlignment = 3;
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num62, num14]).Borders.LineStyle = XlLineStyle.xlContinuous;
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num62, num14]).Borders.Weight = XlBorderWeight.xlHairline;
                            worksheet.Select(updateLinks);
                            worksheet.get_Range("A1", "A1").Select();
                        }
                        else if (str172.Trim().ToUpper() == "B12")
                        {
                            worksheet = application.Sheets[0x11] as Worksheet;
                            int num152 = worksheet.UsedRange.Rows.Count;
                            int num65 = (count + 6) - 1;
                            worksheet.get_Range("B2", "B2").Value2 = tjdwmc;
                            worksheet.get_Range("F2", "F2").Value2 = "统计年度：" + tjnd;
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num65, num14]).EntireRow.Delete(updateLinks);
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num65, num14]).NumberFormatLocal = "@";
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num65, num14]).Value2 = objArray;
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num65, num14]).Font.Size = 10;
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num65, num14]).RowHeight = 20;
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num65, 2]).VerticalAlignment = 2;
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num65, 2]).HorizontalAlignment = 3;
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num65, num14]).Borders.LineStyle = XlLineStyle.xlContinuous;
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num65, num14]).Borders.Weight = XlBorderWeight.xlHairline;
                            worksheet.Select(updateLinks);
                            worksheet.get_Range("A1", "A1").Select();
                        }
                        else if (str172.Trim().ToUpper() == "B13")
                        {
                            worksheet = application.Sheets[0x12] as Worksheet;
                            int num153 = worksheet.UsedRange.Rows.Count;
                            int num68 = (count + 5) - 1;
                            worksheet.get_Range("B2", "B2").Value2 = tjdwmc;
                            worksheet.get_Range("F2", "F2").Value2 = "统计年度：" + tjnd;
                            worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num68, num14]).EntireRow.Delete(updateLinks);
                            worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num68, num14]).NumberFormatLocal = "@";
                            worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num68, num14]).Value2 = objArray;
                            worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num68, num14]).RowHeight = 20;
                            worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num68, num14]).Font.Size = 10;
                            application.DisplayAlerts = false;
                            worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num68, 4]).HorizontalAlignment = 3;
                            worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num68, 4]).VerticalAlignment = 2;
                            worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num68, num14]).Borders.LineStyle = XlLineStyle.xlContinuous;
                            worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num68, num14]).Borders.Weight = XlBorderWeight.xlHairline;
                            worksheet.Select(updateLinks);
                            worksheet.get_Range("A1", "A1").Select();
                        }
                        else if (str172.Trim().ToUpper() == "B14")
                        {
                            worksheet = application.Sheets[0x13] as Worksheet;
                            int num154 = worksheet.UsedRange.Rows.Count;
                            int num71 = (count + 5) - 1;
                            worksheet.get_Range("B2", "B2").Value2 = tjdwmc;
                            worksheet.get_Range("F2", "F2").Value2 = "统计年度：" + tjnd;
                            worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num71, num14]).EntireRow.Delete(updateLinks);
                            worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num71, num14]).NumberFormatLocal = "@";
                            worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num71, num14]).Value2 = objArray;
                            worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num71, num14]).Font.Size = 10;
                            worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num71, num14]).RowHeight = 20;
                            worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num71, 3]).HorizontalAlignment = 3;
                            worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num71, 3]).VerticalAlignment = 2;
                            worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num71, num14]).Borders.LineStyle = XlLineStyle.xlContinuous;
                            worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num71, num14]).Borders.Weight = XlBorderWeight.xlHairline;
                            worksheet.Select(updateLinks);
                            worksheet.get_Range("A1", "A1").Select();
                        }
                        else if (str172.Trim().ToUpper() == "B15")
                        {
                            worksheet = application.Sheets[20] as Worksheet;
                            int num155 = worksheet.UsedRange.Rows.Count;
                            int num74 = (count + 5) - 1;
                            worksheet.get_Range("B2", "B2").Value2 = tjdwmc;
                            worksheet.get_Range("E2", "E2").Value2 = "统计年度：" + tjnd;
                            worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num74, num14]).EntireRow.Delete(updateLinks);
                            worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num74, num14]).NumberFormatLocal = "@";
                            worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num74, num14]).Value2 = objArray;
                            worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num74, num14]).Font.Size = 10;
                            worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num74, num14]).RowHeight = 20;
                            worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num74, 4]).HorizontalAlignment = 3;
                            worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num74, 4]).VerticalAlignment = 2;
                            worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num74, num14]).Borders.LineStyle = XlLineStyle.xlContinuous;
                            worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num74, num14]).Borders.Weight = XlBorderWeight.xlHairline;
                            worksheet.Select(updateLinks);
                            worksheet.get_Range("A1", "A1").Select();
                        }
                        else if (str172.Trim().ToUpper() == "B16")
                        {
                            worksheet = application.Sheets[0x15] as Worksheet;
                            int num156 = worksheet.UsedRange.Rows.Count;
                            int num77 = (count + 5) - 1;
                            worksheet.get_Range("B2", "B2").Value2 = tjdwmc;
                            worksheet.get_Range("E2", "E2").Value2 = "统计年度：" + tjnd;
                            worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num77, num14]).EntireRow.Delete(updateLinks);
                            worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num77, num14]).NumberFormatLocal = "@";
                            worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num77, num14]).Value2 = objArray;
                            worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num77, num14]).Font.Size = 10;
                            worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num77, num14]).RowHeight = 20;
                            worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num77, 4]).HorizontalAlignment = 3;
                            worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num77, 4]).VerticalAlignment = 2;
                            worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num77, num14]).Borders.LineStyle = XlLineStyle.xlContinuous;
                            worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num77, num14]).Borders.Weight = XlBorderWeight.xlHairline;
                            worksheet.Select(updateLinks);
                            worksheet.get_Range("A1", "A1").Select();
                        }
                        else if (str172.Trim().ToUpper() == "B17")
                        {
                            worksheet = application.Sheets[0x16] as Worksheet;
                            int num157 = worksheet.UsedRange.Rows.Count;
                            int num80 = (count + 5) - 1;
                            worksheet.get_Range("B2", "B2").Value2 = tjdwmc;
                            worksheet.get_Range("D2", "D2").Value2 = "统计年度：" + tjnd;
                            worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num80, num14]).EntireRow.Delete(updateLinks);
                            worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num80, num14]).NumberFormatLocal = "@";
                            worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num80, num14]).Value2 = objArray;
                            worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num80, num14]).Font.Size = 10;
                            worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num80, num14]).RowHeight = 20;
                            worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num80, 3]).HorizontalAlignment = 3;
                            worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num80, 3]).VerticalAlignment = 2;
                            worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num80, num14]).Borders.LineStyle = XlLineStyle.xlContinuous;
                            worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num80, num14]).Borders.Weight = XlBorderWeight.xlHairline;
                            worksheet.Select(updateLinks);
                            worksheet.get_Range("A1", "A1").Select();
                        }
                        else if (str172.Trim().ToUpper() == "B18")
                        {
                            worksheet = application.Sheets[0x17] as Worksheet;
                            int num158 = worksheet.UsedRange.Rows.Count;
                            int num83 = (count + 5) - 1;
                            worksheet.get_Range("B2", "B2").Value2 = tjdwmc;
                            worksheet.get_Range("F2", "F2").Value2 = "统计年度：" + tjnd;
                            worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num83, num14]).EntireRow.Delete(updateLinks);
                            worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num83, num14]).NumberFormatLocal = "@";
                            worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num83, num14]).Value2 = objArray;
                            worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num83, num14]).Font.Size = 10;
                            worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num83, num14]).RowHeight = 20;
                            worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num83, 4]).HorizontalAlignment = 3;
                            worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num83, 4]).VerticalAlignment = 2;
                            worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num83, num14]).Borders.LineStyle = XlLineStyle.xlContinuous;
                            worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num83, num14]).Borders.Weight = XlBorderWeight.xlHairline;
                            worksheet.Select(updateLinks);
                            worksheet.get_Range("A1", "A1").Select();
                        }
                        else if (str172.Trim().ToUpper() == "B19")
                        {
                            worksheet = application.Sheets[0x18] as Worksheet;
                            int num159 = worksheet.UsedRange.Rows.Count;
                            int num86 = (count + 5) - 1;
                            worksheet.get_Range("B2", "B2").Value2 = tjdwmc;
                            worksheet.get_Range("E2", "E2").Value2 = "统计年度：" + tjnd;
                            worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num86, num14]).EntireRow.Delete(updateLinks);
                            worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num86, num14]).NumberFormatLocal = "@";
                            worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num86, num14]).Value2 = objArray;
                            worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num86, num14]).Font.Size = 10;
                            worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num86, num14]).RowHeight = 20;
                            worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num86, 1]).RowHeight = 0x15;
                            worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num86, 2]).HorizontalAlignment = 3;
                            worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num86, 2]).VerticalAlignment = 2;
                            worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num86, num14]).Borders.LineStyle = XlLineStyle.xlContinuous;
                            worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num86, num14]).Borders.Weight = XlBorderWeight.xlHairline;
                            worksheet.Select(updateLinks);
                            worksheet.get_Range("A1", "A1").Select();
                        }
                        else if (str172.Trim().ToUpper() == "B20")
                        {
                            worksheet = application.Sheets[0x19] as Worksheet;
                            int num160 = worksheet.UsedRange.Rows.Count;
                            int num89 = (count + 5) - 1;
                            worksheet.get_Range("B2", "B2").Value2 = tjdwmc;
                            worksheet.get_Range("E2", "E2").Value2 = "统计年度：" + tjnd;
                            worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num89, num14]).EntireRow.Delete(updateLinks);
                            worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num89, num14]).NumberFormatLocal = "@";
                            worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num89, num14]).Value2 = objArray;
                            worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num89, num14]).Font.Size = 10;
                            worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num89, num14]).RowHeight = 20;
                            worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num89, 2]).HorizontalAlignment = 3;
                            worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num89, 2]).VerticalAlignment = 2;
                            worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num89, num14]).Borders.LineStyle = XlLineStyle.xlContinuous;
                            worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num89, num14]).Borders.Weight = XlBorderWeight.xlHairline;
                            worksheet.Select(updateLinks);
                            worksheet.get_Range("A1", "A1").Select();
                        }
                        else if (str172.Trim().ToUpper() == "B21")
                        {
                            worksheet = application.Sheets[0x1a] as Worksheet;
                            int num161 = worksheet.UsedRange.Rows.Count;
                            int num92 = (count + 4) - 1;
                            worksheet.get_Range("B2", "B2").Value2 = tjdwmc;
                            worksheet.get_Range("D2", "D2").Value2 = "统计年度：" + tjnd;
                            worksheet.get_Range(worksheet.Cells[4, 1], worksheet.Cells[num92, num14]).EntireRow.Delete(updateLinks);
                            worksheet.get_Range(worksheet.Cells[4, 1], worksheet.Cells[num92, num14]).NumberFormatLocal = "@";
                            worksheet.get_Range(worksheet.Cells[4, 1], worksheet.Cells[num92, num14]).Value2 = objArray;
                            worksheet.get_Range(worksheet.Cells[4, 1], worksheet.Cells[num92, num14]).Font.Size = 10;
                            worksheet.get_Range(worksheet.Cells[4, 1], worksheet.Cells[num92, num14]).RowHeight = 20;
                            worksheet.get_Range(worksheet.Cells[4, 1], worksheet.Cells[num92, 2]).HorizontalAlignment = 3;
                            worksheet.get_Range(worksheet.Cells[4, 1], worksheet.Cells[num92, 2]).VerticalAlignment = 2;
                            worksheet.get_Range(worksheet.Cells[4, 1], worksheet.Cells[num92, num14]).Borders.LineStyle = XlLineStyle.xlContinuous;
                            worksheet.get_Range(worksheet.Cells[4, 1], worksheet.Cells[num92, num14]).Borders.Weight = XlBorderWeight.xlHairline;
                            worksheet.Select(updateLinks);
                            worksheet.get_Range("A1", "A1").Select();
                        }
                        else if (str172.Trim().ToUpper() == "B22")
                        {
                            worksheet = application.Sheets[0x1b] as Worksheet;
                            int num162 = worksheet.UsedRange.Rows.Count;
                            int num95 = (count + 5) - 1;
                            worksheet.get_Range("B2", "B2").Value2 = tjdwmc;
                            worksheet.get_Range("D2", "D2").Value2 = "统计年度：" + tjnd;
                            worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num95, num14]).EntireRow.Delete(updateLinks);
                            worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num95, num14]).NumberFormatLocal = "@";
                            worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num95, num14]).Value2 = objArray;
                            worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num95, num14]).Font.Size = 10;
                            worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num95, num14]).RowHeight = 20;
                            worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num95, 2]).HorizontalAlignment = 3;
                            worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num95, 2]).VerticalAlignment = 2;
                            worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num95, num14]).Borders.LineStyle = XlLineStyle.xlContinuous;
                            worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num95, num14]).Borders.Weight = XlBorderWeight.xlHairline;
                            worksheet.Select(updateLinks);
                            worksheet.get_Range("A1", "A1").Select();
                        }
                        else if (str172.Trim().ToUpper() == "B23")
                        {
                            worksheet = application.Sheets[0x1c] as Worksheet;
                            int num163 = worksheet.UsedRange.Rows.Count;
                            int num98 = (count + 5) - 1;
                            worksheet.get_Range("B2", "B2").Value2 = tjdwmc;
                            worksheet.get_Range("E2", "E2").Value2 = "统计年度：" + tjnd;
                            worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num98, num14]).EntireRow.Delete(updateLinks);
                            worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num98, num14]).NumberFormatLocal = "@";
                            worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num98, num14]).Value2 = objArray;
                            worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num98, num14]).Font.Size = 10;
                            worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num98, num14]).RowHeight = 20;
                            worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num98, 2]).HorizontalAlignment = 3;
                            worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num98, 2]).VerticalAlignment = 2;
                            worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num98, num14]).Borders.LineStyle = XlLineStyle.xlContinuous;
                            worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num98, num14]).Borders.Weight = XlBorderWeight.xlHairline;
                            worksheet.Select(updateLinks);
                            worksheet.get_Range("A1", "A1").Select();
                        }
                        else if (str172.Trim().ToUpper() == "B24")
                        {
                            worksheet = application.Sheets[0x1d] as Worksheet;
                            int num164 = worksheet.UsedRange.Rows.Count;
                            int num101 = (count + 4) - 1;
                            worksheet.get_Range("B2", "B2").Value2 = tjdwmc;
                            worksheet.get_Range("D2", "D2").Value2 = "统计年度：" + tjnd;
                            worksheet.get_Range(worksheet.Cells[4, 1], worksheet.Cells[num101, num14]).EntireRow.Delete(updateLinks);
                            worksheet.get_Range(worksheet.Cells[4, 1], worksheet.Cells[num101, num14]).NumberFormatLocal = "@";
                            worksheet.get_Range(worksheet.Cells[4, 1], worksheet.Cells[num101, num14]).Value2 = objArray;
                            worksheet.get_Range(worksheet.Cells[4, 1], worksheet.Cells[num101, num14]).Font.Size = 10;
                            application.DisplayAlerts = false;
                            worksheet.get_Range(worksheet.Cells[4, 1], worksheet.Cells[num101, num14]).RowHeight = 20;
                            worksheet.get_Range(worksheet.Cells[4, 1], worksheet.Cells[num101, 2]).HorizontalAlignment = 3;
                            worksheet.get_Range(worksheet.Cells[4, 1], worksheet.Cells[num101, 2]).VerticalAlignment = 2;
                            worksheet.get_Range(worksheet.Cells[4, 1], worksheet.Cells[num101, num14]).Borders.LineStyle = XlLineStyle.xlContinuous;
                            worksheet.get_Range(worksheet.Cells[4, 1], worksheet.Cells[num101, num14]).Borders.Weight = XlBorderWeight.xlHairline;
                            worksheet.Select(updateLinks);
                            worksheet.get_Range("A1", "A1").Select();
                        }
                        else if (str172.Trim().ToUpper() == "B25")
                        {
                            worksheet = application.Sheets[30] as Worksheet;
                            int num165 = worksheet.UsedRange.Rows.Count;
                            int num104 = (count + 5) - 1;
                            worksheet.get_Range("B2", "B2").Value2 = tjdwmc;
                            worksheet.get_Range("E2", "E2").Value2 = "统计年度：" + tjnd;
                            worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num104, num14]).EntireRow.Delete(updateLinks);
                            worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num104, num14]).NumberFormatLocal = "@";
                            worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num104, num14]).Value2 = objArray;
                            worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num104, num14]).RowHeight = 20;
                            worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num104, num14]).Font.Size = 10;
                            application.DisplayAlerts = false;
                            worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num104, 2]).HorizontalAlignment = 3;
                            worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num104, 2]).VerticalAlignment = 2;
                            worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num104, num14]).Borders.LineStyle = XlLineStyle.xlContinuous;
                            worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num104, num14]).Borders.Weight = XlBorderWeight.xlHairline;
                            worksheet.Select(updateLinks);
                            worksheet.get_Range("A1", "A1").Select();
                        }
                        else if (str172.Trim().ToUpper() == "B26")
                        {
                            worksheet = application.Sheets[0x1f] as Worksheet;
                            int num166 = worksheet.UsedRange.Rows.Count;
                            int num107 = (count + 6) - 1;
                            worksheet.get_Range("B2", "B2").Value2 = tjdwmc;
                            worksheet.get_Range("E2", "E2").Value2 = "统计年度：" + tjnd;
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num107, num14]).EntireRow.Delete(updateLinks);
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num107, num14]).NumberFormatLocal = "@";
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num107, num14]).Value2 = objArray;
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num107, num14]).RowHeight = 20;
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num107, num14]).Font.Size = 10;
                            application.DisplayAlerts = false;
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num107, 2]).HorizontalAlignment = 3;
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num107, 2]).VerticalAlignment = 2;
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num107, num14]).Borders.LineStyle = XlLineStyle.xlContinuous;
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num107, num14]).Borders.Weight = XlBorderWeight.xlHairline;
                            worksheet.Select(updateLinks);
                            worksheet.get_Range("A1", "A1").Select();
                        }
                        else if (str172.Trim().ToUpper() == "B27")
                        {
                            worksheet = application.Sheets[0x20] as Worksheet;
                            int num167 = worksheet.UsedRange.Rows.Count;
                            int num110 = (count + 5) - 1;
                            worksheet.get_Range("B2", "B2").Value2 = tjdwmc;
                            worksheet.get_Range("D2", "D2").Value2 = "统计年度：" + tjnd;
                            worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num110, num14]).EntireRow.Delete(updateLinks);
                            worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num110, num14]).NumberFormatLocal = "@";
                            worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num110, num14]).Value2 = objArray;
                            worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num110, num14]).RowHeight = 20;
                            worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num110, num14]).Font.Size = 10;
                            application.DisplayAlerts = false;
                            worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num110, 2]).HorizontalAlignment = 3;
                            worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num110, 2]).VerticalAlignment = 2;
                            worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num110, num14]).Borders.LineStyle = XlLineStyle.xlContinuous;
                            worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num110, num14]).Borders.Weight = XlBorderWeight.xlHairline;
                            worksheet.Select(updateLinks);
                            worksheet.get_Range("A1", "A1").Select();
                        }
                        else if (str172.Trim().ToUpper() == "B28")
                        {
                            worksheet = application.Sheets[0x21] as Worksheet;
                            int num168 = worksheet.UsedRange.Rows.Count;
                            int num113 = (count + 7) - 1;
                            worksheet.get_Range("B2", "B2").Value2 = tjdwmc;
                            worksheet.get_Range(worksheet.Cells[7, 1], worksheet.Cells[num113, num14]).EntireRow.Delete(updateLinks);
                            worksheet.get_Range(worksheet.Cells[7, 1], worksheet.Cells[num113, num14]).RowHeight = 0x19;
                            worksheet.get_Range(worksheet.Cells[7, 1], worksheet.Cells[num113, num14]).NumberFormatLocal = "@";
                            worksheet.get_Range(worksheet.Cells[7, 1], worksheet.Cells[num113, num14]).Value2 = objArray;
                            worksheet.get_Range(worksheet.Cells[7, 1], worksheet.Cells[num113, num14]).Font.Size = 10;
                            worksheet.get_Range(worksheet.Cells[7, 1], worksheet.Cells[num113, 2]).HorizontalAlignment = 3;
                            worksheet.get_Range(worksheet.Cells[7, 1], worksheet.Cells[num113, 2]).VerticalAlignment = XlVAlign.xlVAlignCenter;
                            worksheet.get_Range(worksheet.Cells[7, 3], worksheet.Cells[num113, num14]).VerticalAlignment = XlVAlign.xlVAlignBottom;
                            worksheet.get_Range(worksheet.Cells[7, 1], worksheet.Cells[num113, num14]).Borders.LineStyle = XlLineStyle.xlContinuous;
                            worksheet.get_Range(worksheet.Cells[7, 1], worksheet.Cells[num113, num14]).Borders.Weight = XlBorderWeight.xlHairline;
                            worksheet.Select(updateLinks);
                            worksheet.get_Range("A1", "A1").Select();
                        }
                        else if (str172.Trim().ToUpper() == "B29")
                        {
                            worksheet = application.Sheets[0x22] as Worksheet;
                            int num169 = worksheet.UsedRange.Rows.Count;
                            int num116 = (count + 6) - 1;
                            worksheet.get_Range("B2", "B2").Value2 = tjdwmc;
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num116, num14]).EntireRow.Delete(updateLinks);
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num116, num14]).NumberFormatLocal = "@";
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num116, num14]).Value2 = objArray;
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num116, num14]).RowHeight = 20;
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num116, num14]).Font.Size = 10;
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num116, 3]).HorizontalAlignment = 3;
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num116, 3]).VerticalAlignment = 2;
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num116, num14]).Borders.LineStyle = XlLineStyle.xlContinuous;
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num116, num14]).Borders.Weight = XlBorderWeight.xlHairline;
                            worksheet.Select(updateLinks);
                            worksheet.get_Range("A1", "A1").Select();
                        }
                        else if (str172.Trim().ToUpper() == "B30")
                        {
                            worksheet = application.Sheets[0x23] as Worksheet;
                            int num170 = worksheet.UsedRange.Rows.Count;
                            int num119 = (count + 6) - 1;
                            worksheet.get_Range("B2", "B2").Value2 = tjdwmc;
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num119, num14]).EntireRow.Delete(updateLinks);
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num119, num14]).NumberFormatLocal = "@";
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num119, num14]).Value2 = objArray;
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num119, num14]).Font.Size = 10;
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num119, num14]).RowHeight = 20;
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num119, 3]).HorizontalAlignment = 3;
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num119, 3]).VerticalAlignment = 2;
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num119, num14]).Borders.LineStyle = XlLineStyle.xlContinuous;
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num119, num14]).Borders.Weight = XlBorderWeight.xlHairline;
                            worksheet.Select(updateLinks);
                            worksheet.get_Range("A1", "A1").Select();
                        }
                        else if (str172.Trim().ToUpper() == "B31")
                        {
                            worksheet = application.Sheets[0x24] as Worksheet;
                            int num171 = worksheet.UsedRange.Rows.Count;
                            int num122 = (count + 5) - 1;
                            worksheet.get_Range("B2", "B2").Value2 = tjdwmc;
                            worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num122, num14]).EntireRow.Delete(updateLinks);
                            worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num122, num14]).NumberFormatLocal = "@";
                            worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num122, num14]).Value2 = objArray;
                            worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num122, num14]).Font.Size = 10;
                            worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num122, num14]).RowHeight = 20;
                            worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num122, 3]).HorizontalAlignment = 3;
                            worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num122, 3]).VerticalAlignment = 2;
                            worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num122, num14]).Borders.LineStyle = XlLineStyle.xlContinuous;
                            worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num122, num14]).Borders.Weight = XlBorderWeight.xlHairline;
                            worksheet.Select(updateLinks);
                            worksheet.get_Range("A1", "A1").Select();
                        }
                        else if (str172.Trim().ToUpper() == "B32")
                        {
                            worksheet = application.Sheets[0x25] as Worksheet;
                            int num172 = worksheet.UsedRange.Rows.Count;
                            int num125 = (count + 5) - 1;
                            worksheet.get_Range("B2", "B2").Value2 = tjdwmc;
                            worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num125, num14]).EntireRow.Delete(updateLinks);
                            worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num125, num14]).NumberFormatLocal = "@";
                            worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num125, num14]).Value2 = objArray;
                            worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num125, num14]).Font.Size = 10;
                            worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num125, num14]).RowHeight = 20;
                            worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num125, 4]).HorizontalAlignment = 3;
                            worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num125, 4]).VerticalAlignment = 2;
                            worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num125, num14]).Borders.LineStyle = XlLineStyle.xlContinuous;
                            worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num125, num14]).Borders.Weight = XlBorderWeight.xlHairline;
                            worksheet.Select(updateLinks);
                            worksheet.get_Range("A1", "A1").Select();
                        }
                        else if (str172.Trim().ToUpper() == "B33")
                        {
                            worksheet = application.Sheets[0x26] as Worksheet;
                            int num173 = worksheet.UsedRange.Rows.Count;
                            int num128 = (count + 5) - 1;
                            worksheet.get_Range("B2", "B2").Value2 = tjdwmc;
                            worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num128, num14]).EntireRow.Delete(updateLinks);
                            worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num128, num14]).NumberFormatLocal = "@";
                            worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num128, num14]).Value2 = objArray;
                            worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num128, num14]).Font.Size = 10;
                            worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num128, num14]).RowHeight = 20;
                            worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num128, 4]).HorizontalAlignment = 3;
                            worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num128, 4]).VerticalAlignment = 2;
                            worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num128, num14]).Borders.LineStyle = XlLineStyle.xlContinuous;
                            worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num128, num14]).Borders.Weight = XlBorderWeight.xlHairline;
                            worksheet.Select(updateLinks);
                            worksheet.get_Range("A1", "A1").Select();
                        }
                        else if (str172.Trim().ToUpper() == "B34")
                        {
                            worksheet = application.Sheets[0x27] as Worksheet;
                            int num174 = worksheet.UsedRange.Rows.Count;
                            int num131 = (count + 5) - 1;
                            worksheet.get_Range("B2", "B2").Value2 = tjdwmc;
                            worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num131, num14]).EntireRow.Delete(updateLinks);
                            worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num131, num14]).NumberFormatLocal = "@";
                            worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num131, num14]).Value2 = objArray;
                            worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num131, num14]).Font.Size = 10;
                            worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num131, num14]).RowHeight = 20;
                            worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num131, 3]).HorizontalAlignment = 3;
                            worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num131, 3]).VerticalAlignment = 2;
                            worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num131, num14]).Borders.LineStyle = XlLineStyle.xlContinuous;
                            worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num131, num14]).Borders.Weight = XlBorderWeight.xlHairline;
                            worksheet.Select(updateLinks);
                            worksheet.get_Range("A1", "A1").Select();
                        }
                        else if (str172.Trim().ToUpper() == "B35")
                        {
                            worksheet = application.Sheets[40] as Worksheet;
                            int num175 = worksheet.UsedRange.Rows.Count;
                            int num134 = (count + 5) - 1;
                            worksheet.get_Range("B2", "B2").Value2 = tjdwmc;
                            worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num134, num14]).EntireRow.Delete(updateLinks);
                            worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num134, num14]).NumberFormatLocal = "@";
                            worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num134, num14]).Value2 = objArray;
                            worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num134, num14]).Font.Size = 10;
                            worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num134, num14]).RowHeight = 20;
                            worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num134, 2]).HorizontalAlignment = 3;
                            worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num134, 3]).VerticalAlignment = 2;
                            worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num134, num14]).Borders.LineStyle = XlLineStyle.xlContinuous;
                            worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num134, num14]).Borders.Weight = XlBorderWeight.xlHairline;
                            worksheet.Select(updateLinks);
                            worksheet.get_Range("A1", "A1").Select();
                        }
                        else if (str172.Trim().ToUpper() == "B40")
                        {
                            worksheet = application.Sheets[0x29] as Worksheet;
                            int num176 = worksheet.UsedRange.Rows.Count;
                            int num137 = (count + 6) - 1;
                            worksheet.get_Range("B2", "B2").Value2 = tjdwmc;
                            worksheet.get_Range("B2", "B2").Font.Size = 10;
                            worksheet.get_Range("E2", "E2").Value2 = "统计年度：" + tjnd;
                            worksheet.get_Range("E2", "E2").Font.Size = 10;
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num137, num14]).EntireRow.Delete(updateLinks);
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num137, num14]).NumberFormatLocal = "@";
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num137, num14]).Value2 = objArray;
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num137, num14]).Font.Size = 10;
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num137, 3]).HorizontalAlignment = 3;
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num137, 3]).VerticalAlignment = 2;
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num137, num14]).Borders.LineStyle = XlLineStyle.xlContinuous;
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num137, num14]).Borders.Weight = XlBorderWeight.xlHairline;
                            worksheet.Select(updateLinks);
                            worksheet.get_Range("A1", "A1").Select();
                        }
                        else if (str172.Trim().ToUpper() == "B41")
                        {
                            worksheet = application.Sheets[0x2a] as Worksheet;
                            int num177 = worksheet.UsedRange.Rows.Count;
                            int num140 = (count + 6) - 1;
                            worksheet.get_Range("B2", "B2").Value2 = tjdwmc;
                            worksheet.get_Range("B2", "B2").Font.Size = 10;
                            worksheet.get_Range("E2", "E2").Value2 = "统计年度：" + tjnd;
                            worksheet.get_Range("E2", "E2").Font.Size = 10;
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num140, num14]).EntireRow.Delete(updateLinks);
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num140, num14]).NumberFormatLocal = "@";
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num140, num14]).Value2 = objArray;
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num140, num14]).Font.Size = 10;
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num140, 3]).HorizontalAlignment = 3;
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num140, 3]).VerticalAlignment = 2;
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num140, num14]).Borders.LineStyle = XlLineStyle.xlContinuous;
                            worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num140, num14]).Borders.Weight = XlBorderWeight.xlHairline;
                            worksheet.Select(updateLinks);
                            worksheet.get_Range("A1", "A1").Select();
                        }
                        num12++;
                    }
                    worksheet = null;
                    workbook.Save();
                    workbook.Close(false, xlsTargetPath, false);
                    workbook = null;
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message.ToString(), "导出Microsoft.Office.Interop.Excel错误", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
                finally
                {
                    new Process();
                    Process[] processesByName = Process.GetProcessesByName("Microsoft.Office.Interop.Excel");
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
                    catch (Exception exception2)
                    {
                        exception2.ToString();
                    }
                    GC.Collect();
                }
            }
        }
    }
}

