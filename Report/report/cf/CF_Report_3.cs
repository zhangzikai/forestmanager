namespace Report
{
    using DevExpress.XtraEditors;
    using Microsoft.Office.Interop.Excel;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Windows.Forms;
    using Utilities;

    internal class CF_Report_3 : ReportEntity
    {
        public CF_Report_3()
        {
            base.ReportID = "3";
            base.Theme = "CF";
        }

        public override void InitialReport(ReportParamter pReportParamter)
        {
            base.TaskID = pReportParamter.TaskID;
            base.SysType = pReportParamter.SysType;
            base.BK = pReportParamter.BK;
          //  IDBAccess dBAccess = UtilFactory.GetDBAccess(UtilFactory.GetConfigOpt().GetConfigValue2("DataBase", "DBKey"));
            DataRow row = null;// dBAccess.GetDataTable(dBAccess, "select * from T_STAT_REPORT where ReportID=" + base.ReportID + " and Theme='" + base.Theme + "'").Rows[0];
            object obj2 = row["ReportName"];
            if (obj2 != null)
            {
                base.ReportName = obj2.ToString();
            }
            obj2 = row["StoredProcedure"];
            //if (obj2 != null)
            //{
            //    base.StoredProcedure = obj2.ToString();
            //}
            //obj2 = row["StoredProcedureSql"];
            //if (obj2 != null)
            //{
            //    base.StoredProcedureSql = obj2.ToString();
            //}
            obj2 = row["DataTable"];
            if (obj2 != null)
            {
                base.DataTableName = obj2.ToString();
            }
            obj2 = row["StaticSQL"];
            if (obj2 != null)
            {
                string str2 = "";
                if (!string.IsNullOrEmpty(pReportParamter.DistCode))
                {
                    if (pReportParamter.DistCode.Length == 6)
                    {
                        str2 = " where xian=" + pReportParamter.DistCode + " ";
                    }
                    else if (pReportParamter.DistCode.Length == 9)
                    {
                        str2 = " where xiang=" + pReportParamter.DistCode + " ";
                    }
                    else if (pReportParamter.DistCode.Length == 12)
                    {
                        str2 = " where cun=" + pReportParamter.DistCode + " ";
                    }
                }
                string str3 = obj2.ToString();
                int index = str3.IndexOf("order");
                //if (index == -1)
                //{
                //    base.StaticSql = str3 + str2;
                //}
                //else
                //{
                //    base.StaticSql = str3.Insert(index, str2);
                //}
            }
            obj2 = row["StartIndex"];
            if (obj2 != null)
            {
                base.StartIndex = obj2.ToString();
            }
            obj2 = row["GroupIndex"];
            if (obj2 != null)
            {
                base.GroupIndex = obj2.ToString();
            }
            obj2 = row["DtColIndex"];
            if ((obj2 != null) && (obj2.ToString().Trim() != ""))
            {
                base.DataTableColIndex = int.Parse(obj2.ToString());
            }
            //obj2 = row["UseStoredProcedure"];
            //if (obj2 != null)
            //{
            //    base.UseStoreProcedure = obj2.ToString();
            //}
            obj2 = row["reportyear"];
            if (obj2 != null)
            {
                base.NianFen = obj2.ToString();
            }
            base.YueFen = pReportParamter.YueFen;
            //base.StaticSql = base.StaticSql.Replace("@yuefen", base.YueFen);
            //base.StaticSql = string.Format(base.StaticSql, base.NianFen, base.BK);
            //obj2 = row["MergeColIndex"];
            if (obj2 != null)
            {
                base.MergeColIndex = obj2.ToString();
            }
        }

        protected override void WriteExcel2(System.Data.DataTable pDt, Workbook pWorkbook)
        {
            if ((pDt != null) && (pDt.Rows.Count != 0))
            {
                long num = 0xffffL;
                if (pDt.Rows.Count > (num * (0xff - pWorkbook.Worksheets.Count)))
                {
                    XtraMessageBox.Show("数据过多，无法保存在一个Excel文件中！");
                }
                else
                {
                    Worksheet after = null;
                    int num3 = -1;
                    for (int i = 1; i <= pWorkbook.Worksheets.Count; i++)
                    {
                        after = (Worksheet) pWorkbook.Worksheets[i];
                        if (after.Name == base.ReportName)
                        {
                            num3 = i;
                            break;
                        }
                    }
                    if (pWorkbook != null)
                    {
                        int num5 = int.Parse(base.StartIndex);
                        int num6 = int.Parse(pDt.Compute("Count(jj)", "jj=10000").ToString());
                        for (int j = 2; j <= num6; j++)
                        {
                            after.Copy(System.Type.Missing, after);
                            after = (Worksheet) pWorkbook.Worksheets[(num3 + j) - 1];
                            after.Name = base.ReportName + "(" + j.ToString() + ")";
                        }
                        int num8 = ((pDt.Columns.Count - 1) - base.DataTableColIndex) + 1;
                        List<object[]> list = new List<object[]>();
                        num5 = int.Parse(base.StartIndex);
                        int num9 = 0;
                        for (int k = 0; k < pDt.Rows.Count; k++)
                        {
                            DataRow row = pDt.Rows[k];
                            bool flag = false;
                            int index = 0;
                            object[] item = new object[num8];
                            for (int m = base.DataTableColIndex; m < pDt.Columns.Count; m++)
                            {
                                string str = row[m].ToString();
                                if (str == "稓稓稓稓")
                                {
                                    item[index] = "";
                                    flag = true;
                                }
                                else if (str == "10000")
                                {
                                    item[index] = "合计";
                                }
                                else
                                {
                                    item[index] = str;
                                }
                                index++;
                            }
                            num9++;
                            list.Add(item);
                            if (flag)
                            {
                                after = (Worksheet) pWorkbook.Worksheets[num3];
                                num3++;
                                if (list.Count > 0)
                                {
                                    object[,] objArray2 = new object[list.Count, num8];
                                    Microsoft.Office.Interop.Excel.Range range = after.get_Range(after.Cells[num5, 1], after.Cells[num5, num8]);
                                    for (int n = 0; n < list.Count; n++)
                                    {
                                        for (int num14 = 0; num14 < num8; num14++)
                                        {
                                            objArray2[n, num14] = list[n][num14];
                                        }
                                        range.Insert(XlInsertShiftDirection.xlShiftDown, System.Type.Missing);
                                    }
                                    range = after.get_Range(after.Cells[num5, 1], after.Cells[(num5 + num9) - 1, num8]);
                                    range.Value2 = objArray2;
                                    range.Borders.LineStyle = 1;
                                    list.Clear();
                                }
                                num9 = 0;
                                row = pDt.Rows[k - 1];
                                if (!string.IsNullOrEmpty(base.GroupIndex))
                                {
                                    foreach (string str2 in base.GroupIndex.Split(new char[] { ';' }))
                                    {
                                        if (str2.Trim() != "")
                                        {
                                            string[] strArray2 = str2.Split(new char[] { ',' });
                                            string s = strArray2[0].Trim();
                                            int num15 = 0;
                                            if (s != "")
                                            {
                                                num15 = int.Parse(s);
                                            }
                                            s = strArray2[1].Trim();
                                            int num16 = 0;
                                            if (s != "")
                                            {
                                                num16 = int.Parse(s);
                                            }
                                            s = strArray2[2].Trim();
                                            Microsoft.Office.Interop.Excel.Range range2 = after.Cells[num15, num16] as Microsoft.Office.Interop.Excel.Range;
                                            if (range2 != null)
                                            {
                                                if (bool.Parse(range2.MergeCells.ToString()))
                                                {
                                                    Microsoft.Office.Interop.Excel.Range range3 = after.Cells[range2.MergeArea.Row, range2.MergeArea.Column] as Microsoft.Office.Interop.Excel.Range;
                                                    if (s != "")
                                                    {
                                                        range3.Value2 = row[s];
                                                    }
                                                }
                                                else if (s != "")
                                                {
                                                    range2.Value2 = row[s];
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                            System.Windows.Forms.Application.DoEvents();
                        }
                        if (list.Count > 0)
                        {
                            object[,] objArray3 = new object[list.Count, num8];
                            Microsoft.Office.Interop.Excel.Range range4 = after.get_Range(after.Cells[num5, 1], after.Cells[num5, num8]);
                            for (int num17 = 0; num17 < list.Count; num17++)
                            {
                                for (int num18 = 0; num18 < num8; num18++)
                                {
                                    objArray3[num17, num18] = list[num17][num18];
                                }
                                range4.Insert(XlInsertShiftDirection.xlShiftDown, System.Type.Missing);
                            }
                            range4 = after.get_Range(after.Cells[num5, 1], after.Cells[(num5 + num9) - 1, num8]);
                            range4.Value2 = objArray3;
                            range4.Borders.LineStyle = 1;
                            range4.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                            range4.VerticalAlignment = XlVAlign.xlVAlignCenter;
                            list.Clear();
                        }
                        pWorkbook.Saved = true;
                        pWorkbook.Save();
                    }
                }
            }
        }
    }
}

