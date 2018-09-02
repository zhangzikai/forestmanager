namespace GeoDataIE
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
            }
            else
            {
                DataSet set = new DataSet("resultds");
                for (int i = 0; i < tjds.Tables.Count; i++)
                {
                    string tableName = tjds.Tables[i].TableName;
                    System.Data.DataTable table = tjds.Tables[i];
                    if ((table != null) && (table.Rows.Count > 0))
                    {
                        System.Data.DataTable table2 = new System.Data.DataTable("mytable");
                        if (tableName.Trim().ToUpper() == "B1")
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
                                for (int j = 2; j < table.Columns.Count; j++)
                                {
                                    if (row[j] != DBNull.Value)
                                    {
                                        string str4 = row[j].ToString();
                                        if (str4.IndexOf('.') < 0)
                                        {
                                            str4 = str4 + ".0";
                                        }
                                        if (Convert.ToDouble(row[j]) > 1000.0)
                                        {
                                            int num3 = ((int) Convert.ToDouble(row[j])) / 0x3e8;
                                            string str5 = Convert.ToString(num3);
                                            string str6 = str4.Substring(str5.Length, str4.Length - str5.Length);
                                            row2[j] = str5 + "\n\r" + str6;
                                        }
                                        else
                                        {
                                            row2[j] = "\n\r" + str4;
                                        }
                                    }
                                }
                                table2.Rows.Add(row2);
                            }
                        }
                        else if (tableName.Trim().ToUpper() == "B2")
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
                                for (int k = 2; k < table.Columns.Count; k++)
                                {
                                    if (row3[k] != DBNull.Value)
                                    {
                                        string str9 = row3[k].ToString();
                                        if (Convert.ToDouble(row3[k]) > 10000.0)
                                        {
                                            int num5 = ((int) Convert.ToDouble(row3[k])) / 0x2710;
                                            string str10 = Convert.ToString(num5);
                                            string str11 = str9.Substring(str10.Length, str9.Length - str10.Length);
                                            row4[k] = str10 + "\n\r" + str11;
                                        }
                                        else
                                        {
                                            row4[k] = "\n\r" + str9;
                                        }
                                    }
                                }
                                table2.Rows.Add(row4);
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
                                for (int m = 2; m < table.Columns.Count; m++)
                                {
                                    if (row5[m] != DBNull.Value)
                                    {
                                        string str14 = row5[m].ToString();
                                        if (Convert.ToDouble(row5[m]) > 10000.0)
                                        {
                                            int num7 = ((int) Convert.ToDouble(row5[m])) / 0x2710;
                                            string str15 = Convert.ToString(num7);
                                            string str16 = str14.Substring(str15.Length, str14.Length - str15.Length);
                                            row6[m] = str15 + "\n\r" + str16;
                                        }
                                        else
                                        {
                                            row6[m] = "\n\r" + str14;
                                        }
                                    }
                                }
                                table2.Rows.Add(row6);
                            }
                        }
                        else if (tableName.Trim().ToUpper() == "B4")
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
                        else if (tableName.Trim().ToUpper() == "B5")
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
                }
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
                        for (int n = 0; n < set.Tables.Count; n++)
                        {
                            System.Data.DataTable table3 = set.Tables[n];
                            string str24 = table3.TableName;
                            int count = table3.Rows.Count;
                            int num10 = table3.Columns.Count;
                            object[,] objArray = new object[count, num10];
                            for (int num11 = 0; num11 < count; num11++)
                            {
                                for (int num12 = 0; num12 < num10; num12++)
                                {
                                    objArray[num11, num12] = table3.Rows[num11][num12];
                                }
                            }
                            if (str24.Trim().ToUpper() == "B1")
                            {
                                worksheet = application.Sheets[1] as Worksheet;
                                int num13 = worksheet.UsedRange.Rows.Count;
                                worksheet.get_Range("B2", "B2").Value2 = tjdwmc;
                                int num14 = 7;
                                int num15 = (count + num14) - 1;
                                worksheet.get_Range(worksheet.Cells[num14, 1], worksheet.Cells[num13 + 6, num10]).EntireRow.Delete(updateLinks);
                                worksheet.get_Range(worksheet.Cells[num14, 1], worksheet.Cells[num15, num10]).Value2 = objArray;
                                worksheet.get_Range(worksheet.Cells[num14, 1], worksheet.Cells[num15, num10]).RowHeight = 0x1c;
                                worksheet.get_Range(worksheet.Cells[num14, 1], worksheet.Cells[num15, num10]).Font.Size = 9;
                                worksheet.get_Range(worksheet.Cells[num14, 1], worksheet.Cells[num15, 1]).WrapText = true;
                                worksheet.get_Range(worksheet.Cells[num14, 1], worksheet.Cells[num15, 2]).HorizontalAlignment = XlHAlign.xlHAlignCenter;
                                worksheet.get_Range(worksheet.Cells[num14, 1], worksheet.Cells[num15, 2]).VerticalAlignment = XlVAlign.xlVAlignCenter;
                                worksheet.get_Range(worksheet.Cells[num14, 3], worksheet.Cells[num15, num10 - 2]).HorizontalAlignment = XlHAlign.xlHAlignRight;
                                worksheet.get_Range(worksheet.Cells[num14, num10 - 2], worksheet.Cells[num15, num10]).HorizontalAlignment = XlHAlign.xlHAlignCenter;
                                worksheet.get_Range(worksheet.Cells[num14, 1], worksheet.Cells[num15, num10]).Borders.LineStyle = 1;
                                worksheet.Select(updateLinks);
                                worksheet.get_Range("A1", "A1").Select();
                            }
                            else if (str24.Trim().ToUpper() == "B2")
                            {
                                worksheet = application.Sheets[2] as Worksheet;
                                int num16 = worksheet.UsedRange.Rows.Count;
                                int num17 = 7;
                                int num18 = (count + num17) - 1;
                                worksheet.get_Range("B2", "B2").Value2 = tjdwmc;
                                worksheet.get_Range(worksheet.Cells[num17, 1], worksheet.Cells[num18, num10]).EntireRow.Delete(updateLinks);
                                worksheet.get_Range(worksheet.Cells[num17, 1], worksheet.Cells[num18, num10]).Value2 = objArray;
                                worksheet.get_Range(worksheet.Cells[num17, 1], worksheet.Cells[num18, num10]).Font.Size = 9;
                                worksheet.get_Range(worksheet.Cells[num17, 1], worksheet.Cells[num18, 1]).RowHeight = 0x1c;
                                worksheet.get_Range(worksheet.Cells[num17, 1], worksheet.Cells[num18, 1]).WrapText = true;
                                worksheet.get_Range(worksheet.Cells[num17, 1], worksheet.Cells[num18, 2]).HorizontalAlignment = 3;
                                worksheet.get_Range(worksheet.Cells[num17, 1], worksheet.Cells[num18, 2]).VerticalAlignment = 2;
                                worksheet.get_Range(worksheet.Cells[num17, 3], worksheet.Cells[num18, num10]).HorizontalAlignment = XlHAlign.xlHAlignRight;
                                worksheet.get_Range(worksheet.Cells[num17, 1], worksheet.Cells[num18, num10]).Borders.LineStyle = 1;
                                worksheet.Select(updateLinks);
                                worksheet.get_Range("A1", "A1").Select();
                            }
                            else if (str24.Trim().ToUpper() == "B3")
                            {
                                worksheet = application.Sheets[3] as Worksheet;
                                int num19 = worksheet.UsedRange.Rows.Count;
                                int num20 = 5;
                                int num21 = (count + num20) - 1;
                                worksheet.get_Range("B2", "B2").Value2 = tjdwmc;
                                worksheet.get_Range(worksheet.Cells[num20, 1], worksheet.Cells[num21, num10]).EntireRow.Delete(updateLinks);
                                worksheet.get_Range(worksheet.Cells[num20, 1], worksheet.Cells[num21, num10]).Value2 = objArray;
                                worksheet.get_Range(worksheet.Cells[num20, 1], worksheet.Cells[num21, num10]).RowHeight = 0x1c;
                                worksheet.get_Range(worksheet.Cells[num20, 1], worksheet.Cells[num21, num10]).Font.Size = 9;
                                worksheet.get_Range(worksheet.Cells[num20, 1], worksheet.Cells[num21, 1]).WrapText = true;
                                worksheet.get_Range(worksheet.Cells[num20, 1], worksheet.Cells[num21, 2]).HorizontalAlignment = XlHAlign.xlHAlignCenter;
                                worksheet.get_Range(worksheet.Cells[num20, 3], worksheet.Cells[num21, num10]).HorizontalAlignment = XlHAlign.xlHAlignRight;
                                worksheet.get_Range(worksheet.Cells[num20, 1], worksheet.Cells[num21, num10]).Borders.LineStyle = 1;
                                worksheet.Select(updateLinks);
                                worksheet.get_Range("A1", "A1").Select();
                            }
                            else if (str24.Trim().ToUpper() == "B4")
                            {
                                worksheet = application.Sheets[4] as Worksheet;
                                int num22 = worksheet.UsedRange.Rows.Count;
                                int num23 = 5;
                                int num24 = (count + num23) - 1;
                                worksheet.get_Range("B2", "B2").Value2 = tjdwmc;
                                worksheet.get_Range(worksheet.Cells[num23, 1], worksheet.Cells[num24, num10]).EntireRow.Delete(updateLinks);
                                worksheet.get_Range(worksheet.Cells[num23, 1], worksheet.Cells[num24, num10]).Value2 = objArray;
                                worksheet.get_Range(worksheet.Cells[num23, 1], worksheet.Cells[num24, num10]).Font.Size = 10;
                                worksheet.get_Range(worksheet.Cells[num23, 1], worksheet.Cells[num24, 1]).RowHeight = 0x15;
                                worksheet.get_Range(worksheet.Cells[num23, 1], worksheet.Cells[num24, 1]).WrapText = true;
                                worksheet.get_Range(worksheet.Cells[num23, 1], worksheet.Cells[num24, 2]).HorizontalAlignment = 3;
                                worksheet.get_Range(worksheet.Cells[num23, 1], worksheet.Cells[num24, 2]).VerticalAlignment = 2;
                                worksheet.get_Range(worksheet.Cells[num23, 3], worksheet.Cells[num24, num10]).HorizontalAlignment = XlHAlign.xlHAlignRight;
                                worksheet.get_Range(worksheet.Cells[num23, 1], worksheet.Cells[num24, num10]).Borders.LineStyle = 1;
                                worksheet.Select(updateLinks);
                                worksheet.get_Range("A1", "A1").Select();
                            }
                            else if (str24.Trim().ToUpper() == "B5")
                            {
                                worksheet = application.Sheets[5] as Worksheet;
                                int num25 = worksheet.UsedRange.Rows.Count;
                                int num26 = 5;
                                int num27 = (count + num26) - 1;
                                worksheet.get_Range("B2", "B2").Value2 = tjdwmc;
                                worksheet.get_Range(worksheet.Cells[num26, 1], worksheet.Cells[num27, num10]).EntireRow.Delete(updateLinks);
                                worksheet.get_Range(worksheet.Cells[num26, 1], worksheet.Cells[num27, num10]).Value2 = objArray;
                                worksheet.get_Range(worksheet.Cells[num26, 1], worksheet.Cells[num27, num10]).RowHeight = 0x19;
                                worksheet.get_Range(worksheet.Cells[num26, 1], worksheet.Cells[num27, num10]).Font.Size = 10;
                                worksheet.get_Range(worksheet.Cells[num26, 1], worksheet.Cells[num27, 1]).WrapText = true;
                                worksheet.get_Range(worksheet.Cells[num26, 1], worksheet.Cells[num27, 3]).HorizontalAlignment = 3;
                                worksheet.get_Range(worksheet.Cells[num26, 4], worksheet.Cells[num27, num10]).HorizontalAlignment = XlHAlign.xlHAlignRight;
                                worksheet.get_Range(worksheet.Cells[num26, 1], worksheet.Cells[num27, num10]).Borders.LineStyle = 1;
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
                                int num7 = 8;
                                int num8 = (count + num7) - 1;
                                worksheet.get_Range(worksheet.Cells[num7, 1], worksheet.Cells[num6 + 7, num3]).EntireRow.Delete(updateLinks);
                                worksheet.get_Range(worksheet.Cells[num7, 1], worksheet.Cells[num8, num3]).Value2 = objArray;
                                worksheet.get_Range(worksheet.Cells[num7, 1], worksheet.Cells[num8, num3]).Font.Size = 10;
                                worksheet.get_Range(worksheet.Cells[num7, 1], worksheet.Cells[num8, num3]).Columns.AutoFit();
                                worksheet.get_Range(worksheet.Cells[num7, 1], worksheet.Cells[num8, 2]).VerticalAlignment = XlVAlign.xlVAlignCenter;
                                worksheet.get_Range(worksheet.Cells[num7, 1], worksheet.Cells[num8, num3]).Borders.LineStyle = 1;
                                worksheet.Select(updateLinks);
                                worksheet.get_Range("A1", "A1").Select();
                            }
                            else if (tableName.Trim().ToUpper() == "B2")
                            {
                                worksheet = application.Sheets[2] as Worksheet;
                                int num9 = worksheet.UsedRange.Rows.Count;
                                int num10 = 8;
                                int num11 = (count + num10) - 1;
                                worksheet.get_Range("B2", "B2").Value2 = tjdwmc;
                                worksheet.get_Range(worksheet.Cells[num10, 1], worksheet.Cells[num11, num3]).EntireRow.Delete(updateLinks);
                                worksheet.get_Range(worksheet.Cells[num10, 1], worksheet.Cells[num11, num3]).Value2 = objArray;
                                worksheet.get_Range(worksheet.Cells[num10, 1], worksheet.Cells[num11, num3]).Font.Size = 10;
                                worksheet.get_Range(worksheet.Cells[num10, 1], worksheet.Cells[num11, num3]).Columns.AutoFit();
                                worksheet.get_Range(worksheet.Cells[num10, 1], worksheet.Cells[num11, 2]).HorizontalAlignment = 3;
                                worksheet.get_Range(worksheet.Cells[num10, 1], worksheet.Cells[num11, 2]).VerticalAlignment = 2;
                                worksheet.get_Range(worksheet.Cells[num10, 1], worksheet.Cells[num11, num3]).Borders.LineStyle = 1;
                                worksheet.Select(updateLinks);
                                worksheet.get_Range("A1", "A1").Select();
                            }
                            else if (tableName.Trim().ToUpper() == "B3")
                            {
                                worksheet = application.Sheets[3] as Worksheet;
                                int num12 = worksheet.UsedRange.Rows.Count;
                                int num13 = 6;
                                int num14 = (count + num13) - 1;
                                worksheet.get_Range("B2", "B2").Value2 = tjdwmc;
                                worksheet.get_Range(worksheet.Cells[num13, 1], worksheet.Cells[num14, num3]).EntireRow.Delete(updateLinks);
                                worksheet.get_Range(worksheet.Cells[num13, 1], worksheet.Cells[num14, num3]).Value2 = objArray;
                                worksheet.get_Range(worksheet.Cells[num13, 1], worksheet.Cells[num14, num3]).Font.Size = 10;
                                worksheet.get_Range(worksheet.Cells[num13, 1], worksheet.Cells[num14, num3]).Columns.AutoFit();
                                worksheet.get_Range(worksheet.Cells[num13, 1], worksheet.Cells[num14, 2]).HorizontalAlignment = XlHAlign.xlHAlignCenter;
                                worksheet.get_Range(worksheet.Cells[num13, 1], worksheet.Cells[num14, num3]).Borders.LineStyle = 1;
                                worksheet.Select(updateLinks);
                                worksheet.get_Range("A1", "A1").Select();
                            }
                            else if (tableName.Trim().ToUpper() == "B4")
                            {
                                worksheet = application.Sheets[4] as Worksheet;
                                int num15 = worksheet.UsedRange.Rows.Count;
                                int num16 = 6;
                                int num17 = (count + num16) - 1;
                                worksheet.get_Range("B2", "B2").Value2 = tjdwmc;
                                worksheet.get_Range(worksheet.Cells[num16, 1], worksheet.Cells[num17, num3]).EntireRow.Delete(updateLinks);
                                worksheet.get_Range(worksheet.Cells[num16, 1], worksheet.Cells[num17, num3]).Value2 = objArray;
                                worksheet.get_Range(worksheet.Cells[num16, 1], worksheet.Cells[num17, num3]).Font.Size = 10;
                                worksheet.get_Range(worksheet.Cells[num16, 1], worksheet.Cells[num17, num3]).Columns.AutoFit();
                                worksheet.get_Range(worksheet.Cells[num16, 1], worksheet.Cells[num17, 5]).HorizontalAlignment = 3;
                                worksheet.get_Range(worksheet.Cells[num16, 1], worksheet.Cells[num17, 5]).VerticalAlignment = 2;
                                worksheet.get_Range(worksheet.Cells[num16, 1], worksheet.Cells[num17, num3]).Borders.LineStyle = 1;
                                worksheet.Select(updateLinks);
                                worksheet.get_Range("A1", "A1").Select();
                            }
                            else if (tableName.Trim().ToUpper() == "B5")
                            {
                                worksheet = application.Sheets[5] as Worksheet;
                                int num18 = worksheet.UsedRange.Rows.Count;
                                int num19 = 6;
                                int num20 = (count + num19) - 1;
                                worksheet.get_Range("B2", "B2").Value2 = tjdwmc;
                                worksheet.get_Range(worksheet.Cells[num19, 1], worksheet.Cells[num20, num3]).EntireRow.Delete(updateLinks);
                                worksheet.get_Range(worksheet.Cells[num19, 1], worksheet.Cells[num20, num3]).Value2 = objArray;
                                worksheet.get_Range(worksheet.Cells[num19, 1], worksheet.Cells[num20, num3]).Font.Size = 10;
                                worksheet.get_Range(worksheet.Cells[num19, 1], worksheet.Cells[num20, num3]).Columns.AutoFit();
                                worksheet.get_Range(worksheet.Cells[num19, 1], worksheet.Cells[num20, 4]).HorizontalAlignment = 3;
                                worksheet.get_Range(worksheet.Cells[num19, 1], worksheet.Cells[num20, num3]).Borders.LineStyle = 1;
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

        public void SaveZYBHTJB(string tjdwmc, DataSet tjds, string xlsModelPath, string xlsTargetPath)
        {
            if (!File.Exists(xlsModelPath))
            {
                MessageBox.Show(xlsModelPath + " 不存在，请检查!", "错误", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else
            {
                DataSet set = new DataSet("resultds");
                for (int i = 0; i < tjds.Tables.Count; i++)
                {
                    string tableName = tjds.Tables[i].TableName;
                    System.Data.DataTable table = tjds.Tables[i];
                    if ((table != null) && (table.Rows.Count > 0))
                    {
                        System.Data.DataTable table2 = new System.Data.DataTable("mytable");
                        if (tableName.Trim().ToUpper() == "B1")
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
                                for (int j = 2; j < table.Columns.Count; j++)
                                {
                                    if (row[j] != DBNull.Value)
                                    {
                                        string str4 = row[j].ToString();
                                        if (str4.IndexOf('.') < 0)
                                        {
                                            str4 = str4 + ".0";
                                        }
                                        if (Convert.ToDouble(row[j]) > 1000.0)
                                        {
                                            int num3 = ((int) Convert.ToDouble(row[j])) / 0x3e8;
                                            string str5 = Convert.ToString(num3);
                                            string str6 = str4.Substring(str5.Length, str4.Length - str5.Length);
                                            row2[j] = str5 + "\n\r" + str6;
                                        }
                                        else
                                        {
                                            row2[j] = "\n\r" + str4;
                                        }
                                    }
                                }
                                table2.Rows.Add(row2);
                            }
                        }
                        else if (tableName.Trim().ToUpper() == "B2")
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
                                for (int k = 2; k < table.Columns.Count; k++)
                                {
                                    if (row3[k] != DBNull.Value)
                                    {
                                        string str9 = row3[k].ToString();
                                        if (Convert.ToDouble(row3[k]) > 10000.0)
                                        {
                                            int num5 = ((int) Convert.ToDouble(row3[k])) / 0x2710;
                                            string str10 = Convert.ToString(num5);
                                            string str11 = str9.Substring(str10.Length, str9.Length - str10.Length);
                                            row4[k] = str10 + "\n\r" + str11;
                                        }
                                        else
                                        {
                                            row4[k] = "\n\r" + str9;
                                        }
                                    }
                                }
                                table2.Rows.Add(row4);
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
                                for (int m = 2; m < table.Columns.Count; m++)
                                {
                                    if (row5[m] != DBNull.Value)
                                    {
                                        string str14 = row5[m].ToString();
                                        if (Convert.ToDouble(row5[m]) > 10000.0)
                                        {
                                            int num7 = ((int) Convert.ToDouble(row5[m])) / 0x2710;
                                            string str15 = Convert.ToString(num7);
                                            string str16 = str14.Substring(str15.Length, str14.Length - str15.Length);
                                            row6[m] = str15 + "\n\r" + str16;
                                        }
                                        else
                                        {
                                            row6[m] = "\n\r" + str14;
                                        }
                                    }
                                }
                                table2.Rows.Add(row6);
                            }
                        }
                        else if (tableName.Trim().ToUpper() == "B4")
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
                        else if (tableName.Trim().ToUpper() == "B5")
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
                }
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
                        for (int n = 0; n < set.Tables.Count; n++)
                        {
                            System.Data.DataTable table3 = set.Tables[n];
                            string str24 = table3.TableName;
                            int count = table3.Rows.Count;
                            int num10 = table3.Columns.Count;
                            object[,] objArray = new object[count, num10];
                            for (int num11 = 0; num11 < count; num11++)
                            {
                                for (int num12 = 0; num12 < num10; num12++)
                                {
                                    objArray[num11, num12] = table3.Rows[num11][num12];
                                }
                            }
                            if (str24.Trim().ToUpper() == "B1")
                            {
                                worksheet = application.Sheets[1] as Worksheet;
                                int num13 = worksheet.UsedRange.Rows.Count;
                                worksheet.get_Range("B2", "B2").Value2 = tjdwmc;
                                int num14 = 7;
                                int num15 = (count + num14) - 1;
                                worksheet.get_Range(worksheet.Cells[num14, 1], worksheet.Cells[num13 + 6, num10]).EntireRow.Delete(updateLinks);
                                worksheet.get_Range(worksheet.Cells[num14, 1], worksheet.Cells[num15, num10]).Value2 = objArray;
                                worksheet.get_Range(worksheet.Cells[num14, 1], worksheet.Cells[num15, num10]).RowHeight = 0x1c;
                                worksheet.get_Range(worksheet.Cells[num14, 1], worksheet.Cells[num15, num10]).Font.Size = 9;
                                worksheet.get_Range(worksheet.Cells[num14, 1], worksheet.Cells[num15, 1]).WrapText = true;
                                worksheet.get_Range(worksheet.Cells[num14, 1], worksheet.Cells[num15, 2]).HorizontalAlignment = XlHAlign.xlHAlignCenter;
                                worksheet.get_Range(worksheet.Cells[num14, 1], worksheet.Cells[num15, 2]).VerticalAlignment = XlVAlign.xlVAlignCenter;
                                worksheet.get_Range(worksheet.Cells[num14, 3], worksheet.Cells[num15, num10 - 2]).HorizontalAlignment = XlHAlign.xlHAlignRight;
                                worksheet.get_Range(worksheet.Cells[num14, num10 - 2], worksheet.Cells[num15, num10]).HorizontalAlignment = XlHAlign.xlHAlignCenter;
                                worksheet.get_Range(worksheet.Cells[num14, 1], worksheet.Cells[num15, num10]).Borders.LineStyle = 1;
                                worksheet.Select(updateLinks);
                                worksheet.get_Range("A1", "A1").Select();
                            }
                            else if (str24.Trim().ToUpper() == "B2")
                            {
                                worksheet = application.Sheets[2] as Worksheet;
                                int num16 = worksheet.UsedRange.Rows.Count;
                                int num17 = 7;
                                int num18 = (count + num17) - 1;
                                worksheet.get_Range("B2", "B2").Value2 = tjdwmc;
                                worksheet.get_Range(worksheet.Cells[num17, 1], worksheet.Cells[num18, num10]).EntireRow.Delete(updateLinks);
                                worksheet.get_Range(worksheet.Cells[num17, 1], worksheet.Cells[num18, num10]).Value2 = objArray;
                                worksheet.get_Range(worksheet.Cells[num17, 1], worksheet.Cells[num18, num10]).Font.Size = 9;
                                worksheet.get_Range(worksheet.Cells[num17, 1], worksheet.Cells[num18, 1]).RowHeight = 0x1c;
                                worksheet.get_Range(worksheet.Cells[num17, 1], worksheet.Cells[num18, 1]).WrapText = true;
                                worksheet.get_Range(worksheet.Cells[num17, 1], worksheet.Cells[num18, 2]).HorizontalAlignment = 3;
                                worksheet.get_Range(worksheet.Cells[num17, 1], worksheet.Cells[num18, 2]).VerticalAlignment = 2;
                                worksheet.get_Range(worksheet.Cells[num17, 3], worksheet.Cells[num18, num10]).HorizontalAlignment = XlHAlign.xlHAlignRight;
                                worksheet.get_Range(worksheet.Cells[num17, 1], worksheet.Cells[num18, num10]).Borders.LineStyle = 1;
                                worksheet.Select(updateLinks);
                                worksheet.get_Range("A1", "A1").Select();
                            }
                            else if (str24.Trim().ToUpper() == "B3")
                            {
                                worksheet = application.Sheets[3] as Worksheet;
                                int num19 = worksheet.UsedRange.Rows.Count;
                                int num20 = 5;
                                int num21 = (count + num20) - 1;
                                worksheet.get_Range("B2", "B2").Value2 = tjdwmc;
                                worksheet.get_Range(worksheet.Cells[num20, 1], worksheet.Cells[num21, num10]).EntireRow.Delete(updateLinks);
                                worksheet.get_Range(worksheet.Cells[num20, 1], worksheet.Cells[num21, num10]).Value2 = objArray;
                                worksheet.get_Range(worksheet.Cells[num20, 1], worksheet.Cells[num21, num10]).RowHeight = 0x1c;
                                worksheet.get_Range(worksheet.Cells[num20, 1], worksheet.Cells[num21, num10]).Font.Size = 9;
                                worksheet.get_Range(worksheet.Cells[num20, 1], worksheet.Cells[num21, 1]).WrapText = true;
                                worksheet.get_Range(worksheet.Cells[num20, 1], worksheet.Cells[num21, 2]).HorizontalAlignment = XlHAlign.xlHAlignCenter;
                                worksheet.get_Range(worksheet.Cells[num20, 3], worksheet.Cells[num21, num10]).HorizontalAlignment = XlHAlign.xlHAlignRight;
                                worksheet.get_Range(worksheet.Cells[num20, 1], worksheet.Cells[num21, num10]).Borders.LineStyle = 1;
                                worksheet.Select(updateLinks);
                                worksheet.get_Range("A1", "A1").Select();
                            }
                            else if (str24.Trim().ToUpper() == "B4")
                            {
                                worksheet = application.Sheets[4] as Worksheet;
                                int num22 = worksheet.UsedRange.Rows.Count;
                                int num23 = 5;
                                int num24 = (count + num23) - 1;
                                worksheet.get_Range("B2", "B2").Value2 = tjdwmc;
                                worksheet.get_Range(worksheet.Cells[num23, 1], worksheet.Cells[num24, num10]).EntireRow.Delete(updateLinks);
                                worksheet.get_Range(worksheet.Cells[num23, 1], worksheet.Cells[num24, num10]).Value2 = objArray;
                                worksheet.get_Range(worksheet.Cells[num23, 1], worksheet.Cells[num24, num10]).Font.Size = 10;
                                worksheet.get_Range(worksheet.Cells[num23, 1], worksheet.Cells[num24, 1]).RowHeight = 0x15;
                                worksheet.get_Range(worksheet.Cells[num23, 1], worksheet.Cells[num24, 1]).WrapText = true;
                                worksheet.get_Range(worksheet.Cells[num23, 1], worksheet.Cells[num24, 2]).HorizontalAlignment = 3;
                                worksheet.get_Range(worksheet.Cells[num23, 1], worksheet.Cells[num24, 2]).VerticalAlignment = 2;
                                worksheet.get_Range(worksheet.Cells[num23, 3], worksheet.Cells[num24, num10]).HorizontalAlignment = XlHAlign.xlHAlignRight;
                                worksheet.get_Range(worksheet.Cells[num23, 1], worksheet.Cells[num24, num10]).Borders.LineStyle = 1;
                                worksheet.Select(updateLinks);
                                worksheet.get_Range("A1", "A1").Select();
                            }
                            else if (str24.Trim().ToUpper() == "B5")
                            {
                                worksheet = application.Sheets[5] as Worksheet;
                                int num25 = worksheet.UsedRange.Rows.Count;
                                int num26 = 5;
                                int num27 = (count + num26) - 1;
                                worksheet.get_Range("B2", "B2").Value2 = tjdwmc;
                                worksheet.get_Range(worksheet.Cells[num26, 1], worksheet.Cells[num27, num10]).EntireRow.Delete(updateLinks);
                                worksheet.get_Range(worksheet.Cells[num26, 1], worksheet.Cells[num27, num10]).Value2 = objArray;
                                worksheet.get_Range(worksheet.Cells[num26, 1], worksheet.Cells[num27, num10]).RowHeight = 0x19;
                                worksheet.get_Range(worksheet.Cells[num26, 1], worksheet.Cells[num27, num10]).Font.Size = 10;
                                worksheet.get_Range(worksheet.Cells[num26, 1], worksheet.Cells[num27, 1]).WrapText = true;
                                worksheet.get_Range(worksheet.Cells[num26, 1], worksheet.Cells[num27, 3]).HorizontalAlignment = 3;
                                worksheet.get_Range(worksheet.Cells[num26, 4], worksheet.Cells[num27, num10]).HorizontalAlignment = XlHAlign.xlHAlignRight;
                                worksheet.get_Range(worksheet.Cells[num26, 1], worksheet.Cells[num27, num10]).Borders.LineStyle = 1;
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
    }
}

