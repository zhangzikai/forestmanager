namespace Report
{
    using DevExpress.XtraEditors;
    using Microsoft.Office.Interop.Excel;
    using System;
    using System.Data;
    using System.Drawing;
    using System.Windows.Forms;

    internal class SF_Report_4 : ReportEntity
    {
        public SF_Report_4()
        {
            base.ReportID = "4";
            base.Theme = "SF";
        }

        protected override void WriteExcel3(System.Data.DataTable pDt, Workbook pWorkbook)
        {
            if ((pDt != null) && (pDt.Rows.Count != 0))
            {
                long count = pDt.Rows.Count;
                if (count > (0xffffL * (0xff - pWorkbook.Worksheets.Count)))
                {
                    XtraMessageBox.Show("数据过多，无法保存在一个Excel文件中！");
                }
                else
                {
                    Worksheet worksheet;
                    Microsoft.Office.Interop.Excel.Range range;
                    long num2 = 0L;
                    long num3 = 1L;
                    if (count > 0xffffL)
                    {
                        num3 = Convert.ToInt64((long) (count / 0xffffL));
                    }
                    long num4 = 0L;
                    int num5 = 1;
                    int num6 = -1;
                    while (num5 <= pWorkbook.Worksheets.Count)
                    {
                        worksheet = (Worksheet) pWorkbook.Worksheets[num5];
                        if (worksheet.Name == base.ReportName)
                        {
                            range = worksheet.Cells[1, 1] as Microsoft.Office.Interop.Excel.Range;
                            if (range != null)
                            {
                                Microsoft.Office.Interop.Excel.Range range2 = worksheet.Cells[range.MergeArea.Row, range.MergeArea.Column] as Microsoft.Office.Interop.Excel.Range;
                                range2.Value2 = base.NianFen + " 年 森 林 火 灾 统 计 报 表";
                            }
                            DataRow row = pDt.Rows[0];
                            if (!string.IsNullOrEmpty(base.GroupIndex))
                            {
                                foreach (string str in base.GroupIndex.Split(new char[] { ';' }))
                                {
                                    if (str.Trim() != "")
                                    {
                                        string[] strArray2 = str.Split(new char[] { ',' });
                                        string s = strArray2[0].Trim();
                                        int num7 = 0;
                                        if (s != "")
                                        {
                                            num7 = int.Parse(s);
                                        }
                                        s = strArray2[1].Trim();
                                        int num8 = 0;
                                        if (s != "")
                                        {
                                            num8 = int.Parse(s);
                                        }
                                        s = strArray2[2].Trim();
                                        range = worksheet.Cells[num7, num8] as Microsoft.Office.Interop.Excel.Range;
                                        if (range != null)
                                        {
                                            if (bool.Parse(range.MergeCells.ToString()))
                                            {
                                                Microsoft.Office.Interop.Excel.Range range3 = worksheet.Cells[range.MergeArea.Row, range.MergeArea.Column] as Microsoft.Office.Interop.Excel.Range;
                                                if (s != "")
                                                {
                                                    range3.Value2 = row[s];
                                                }
                                            }
                                            else if (s != "")
                                            {
                                                range.Value2 = row[s];
                                            }
                                        }
                                    }
                                }
                            }
                            num6 = num5;
                            for (long i = num3 - 1L; i > 0L; i -= 1L)
                            {
                                worksheet.Copy(System.Type.Missing, worksheet);
                            }
                            break;
                        }
                        num5++;
                    }
                    int num10 = 1;
                    int num11 = int.Parse(base.StartIndex);
                    while (num6 <= ((num5 + num3) - 1L))
                    {
                        worksheet = (Worksheet) pWorkbook.Worksheets[num6];
                        range = worksheet.get_Range(worksheet.Cells[num11, 1], worksheet.Cells[num11, pDt.Columns.Count - base.DataTableColIndex]);
                        num4 = num10 * 0xffffL;
                        if (num4 > count)
                        {
                            num4 = count;
                        }
                        object[,] objArray = new object[num4, pDt.Columns.Count];
                        for (int j = Convert.ToInt32((long) (0xffffL * (num3 - 1L))); j < num4; j++)
                        {
                            int num13 = 0;
                            for (int k = base.DataTableColIndex; k < pDt.Columns.Count; k++)
                            {
                                objArray[j, num13] = pDt.Rows[j][k];
                                num13++;
                            }
                            num2 += 1L;
                            float single1 = ((float) (100L * num2)) / ((float) count);
                            range.Insert(XlInsertShiftDirection.xlShiftDown, System.Type.Missing);
                            System.Windows.Forms.Application.DoEvents();
                        }
                        range = worksheet.get_Range(worksheet.Cells[num11, 1], worksheet.Cells[(num11 + pDt.Rows.Count) - 1, pDt.Columns.Count - base.DataTableColIndex]);
                        range.Value2 = objArray;
                        range.Interior.Color = ColorTranslator.ToOle(Color.White);
                        range.Borders.LineStyle = 1;
                        range = worksheet.get_Range(worksheet.Cells[(num11 + pDt.Rows.Count) - 1, 2], worksheet.Cells[(num11 + pDt.Rows.Count) - 1, 5]);
                        range.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                        range.VerticalAlignment = XlVAlign.xlVAlignCenter;
                        range.Merge(false);
                        num10++;
                        num6++;
                    }
                    pWorkbook.Saved = true;
                    pWorkbook.Save();
                }
            }
        }
    }
}

