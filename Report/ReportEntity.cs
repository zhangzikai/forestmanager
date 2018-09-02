namespace Report
{
    using DevExpress.XtraEditors;
    using Microsoft.Office.Interop.Excel;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.Windows.Forms;
    using TaskManage;
    using td.db.mid.forest;
    using td.db.mid.sys;
    using td.db.orm;
    using td.forest.report.cf;
    using td.logic.sys;
    using Utilities;

    /// <summary>
    /// 报表的实体类
    /// </summary>
    public class ReportEntity
    {
        private string _bk;
        private string _dataTable;
        private string _dataTableName;
        private int _dtColIndex;
        private string _groupIndex;
        private string _mergeColIndex;
        private string _nianFen;
        private string _reportID;
        private string _reportName;
        private string _startIndex;
        private SystemType _sysType;
        private string _taskID;
        private string _theme;     
        private string _yueFen;

        public ReportEntity()
        {
        }

        /// <summary>
        /// 报表实体类。参数（pID ）：通过pID来执行不同的查询数据写入Excel表格中
        /// </summary>
        /// <param name="pID"></param>
        public ReportEntity(string pID)
        {
            this._reportID = pID;
        }

       /// <summary>
       /// 初始化报表
       /// </summary>
       /// <param name="pReportParamter"></param>
        public virtual void InitialReport(ReportParamter pReportParamter)
        {
            this._taskID = pReportParamter.TaskID;
            this._sysType = pReportParamter.SysType;
            this._bk = pReportParamter.BK;
            T_STAT_REPORT_Mid mid= MDM.FindReport(_theme, _reportID);  
            this._reportName = mid.ReportName;
            this.NianFen = pReportParamter.Year;
            this.YueFen = pReportParamter.YueFen;
        }

        protected virtual void MergeCell(Worksheet pSheet, int pStartIndex, long pRowCount)
        {
            if (!string.IsNullOrEmpty(this._mergeColIndex))
            {
                string[] strArray = this._mergeColIndex.Split(new char[] { ',' });
                List<int> list = new List<int>();
                int num = 0;
                list.Add(0);
                foreach (string str in strArray)
                {
                    int num2 = int.Parse(str);
                    int num3 = pStartIndex;
                    long num4 = pStartIndex + pRowCount;
                    int item = 1;
                    for (int i = pStartIndex + 1; i < num4; i++)
                    {
                        if (num == 0)
                        {
                            list.Add(item);
                        }
                        else if ((num > 0) && (list[item] == -1))
                        {
                            item++;
                            continue;
                        }
                        num3 = i - 1;
                        Microsoft.Office.Interop.Excel.Range range = pSheet.Cells[num3, num2] as Microsoft.Office.Interop.Excel.Range;
                        Microsoft.Office.Interop.Excel.Range range2 = pSheet.Cells[i, num2] as Microsoft.Office.Interop.Excel.Range;
                        if (range.MergeCells.Equals(true))
                        {
                            object[,] objArray = range.MergeArea.Value2 as object[,];
                            object obj2 = objArray[1, 1];
                            if (((obj2 != null) && (range2.Value2 != null)) && obj2.Equals(range2.Value2))
                            {
                                pSheet.get_Range(range, range2).Merge(false);
                            }
                            else if ((obj2 == null) && (range2.Value2 == null))
                            {
                                pSheet.get_Range(range, range2).Merge(false);
                            }
                            else
                            {
                                list[item] = -1;
                            }
                        }
                        else if (((range.Value2 != null) && (range2.Value2 != null)) && range.Value2.Equals(range2.Value2))
                        {
                            pSheet.get_Range(range, range2).Merge(false);
                        }
                        else if ((range.Value2 == null) && (range.Value2 == null))
                        {
                            pSheet.get_Range(range, range2).Merge(false);
                        }
                        else
                        {
                            list[item] = -1;
                        }
                        item++;
                    }
                    num++;
                }
            }
        }

        public virtual string Static(Workbook pWorkbook)
        {
            string str2 = null;
            if (this._theme == "CF")
            {               
                //此处未往数据表中导入数据。因此查询的数据为null
                System.Data.DataTable pDt = FromMid2Table(); //dBAccess.GetDataTable(dBAccess, this._staticSql);
                if ((pDt == null) || (pDt.Rows.Count == 0))
                {
                    return (str2 + this._reportName + ",");
                }
                this.WriteExcel2(pDt, pWorkbook);
                return str2;
            }
            System.Data.DataTable dataTable = FromMid2Table();
            if ((dataTable == null) || (dataTable.Rows.Count == 0))
            {
                return (str2 + this._reportName + ",");
            }
            this.WriteExcel3(dataTable, pWorkbook);
            return "";
        }
        protected MetaDataManager MDM
        { get { return DBServiceFactory<MetaDataManager>.Service; } }
        protected int m_digits = 2;
        public virtual System.Data.DataTable FromMid2Table() { return null; }
        /// <summary>
        /// 父类的制作表方法为null，因此需要子类根据需要重写
        /// </summary>
        /// <returns></returns>
        protected virtual System.Data.DataTable MakeTable() { return null; }
        /// <summary>
        /// 将查询的数据写入Excel表格的方法1
        /// </summary>
        /// <param name="pDt"></param>
        /// <param name="pWorkbook"></param>
        protected virtual void WriteExcel(System.Data.DataTable pDt, Workbook pWorkbook)
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
                        if (worksheet.Name == this.ReportName)
                        {
                            num6 = num5;
                            for (long i = num3 - 1L; i > 0L; i -= 1L)
                            {
                                worksheet.Copy(System.Type.Missing, worksheet);
                            }
                            break;
                        }
                        num5++;
                    }
                    DataRow row = pDt.Rows[0];
                    int num8 = 1;
                    int num9 = int.Parse(this.StartIndex);
                    while (num6 <= ((num5 + num3) - 1L))
                    {
                        worksheet = (Worksheet) pWorkbook.Worksheets[num6];
                        if (!string.IsNullOrEmpty(this.GroupIndex))
                        {
                            foreach (string str in this.GroupIndex.Split(new char[] { ';' }))
                            {
                                if (str.Trim() != "")
                                {
                                    string[] strArray2 = str.Split(new char[] { ',' });
                                    string s = strArray2[0].Trim();
                                    int num10 = 0;
                                    if (s != "")
                                    {
                                        num10 = int.Parse(s);
                                    }
                                    s = strArray2[1].Trim();
                                    int num11 = 0;
                                    if (s != "")
                                    {
                                        num11 = int.Parse(s);
                                    }
                                    s = strArray2[2].Trim();
                                    Microsoft.Office.Interop.Excel.Range range = worksheet.Cells[num10, num11] as Microsoft.Office.Interop.Excel.Range;
                                    if (range != null)
                                    {
                                        if (bool.Parse(range.MergeCells.ToString()))
                                        {
                                            Microsoft.Office.Interop.Excel.Range range2 = worksheet.Cells[range.MergeArea.Row, range.MergeArea.Column] as Microsoft.Office.Interop.Excel.Range;
                                            if (s != "")
                                            {
                                                range2.Value2 = row[s];
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
                        num4 = num8 * 0xffffL;
                        if (num4 > count)
                        {
                            num4 = count;
                        }
                        for (int j = Convert.ToInt32((long) (0xffffL * (num3 - 1L))); j < num4; j++)
                        {
                            int num13 = 1;
                            for (int k = this._dtColIndex; k < pDt.Columns.Count; k++)
                            {
                                object obj2 = pDt.Rows[j][k];
                                Microsoft.Office.Interop.Excel.Range range3 = worksheet.Cells[num9, num13] as Microsoft.Office.Interop.Excel.Range;
                                range3.Borders.LineStyle = 1;
                                range3.Value2 = obj2;
                                num13++;
                            }
                            num9++;
                            num2 += 1L;
                            float single1 = ((float) (100L * num2)) / ((float) count);
                            System.Windows.Forms.Application.DoEvents();
                        }
                        num8++;
                        num6++;
                    }
                    pWorkbook.Saved = true;
                    pWorkbook.Save();
                }
            }
        }

        /// <summary>
        /// 将查询的数据写入Excel表格的方法2
        /// </summary>
        /// <param name="pDt"></param>
        /// <param name="pWorkbook"></param>
        protected virtual void WriteExcel2(System.Data.DataTable pDt, Workbook pWorkbook)
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
                        if (worksheet.Name == this.ReportName)
                        {
                            DataRow row = pDt.Rows[0];
                            if (!string.IsNullOrEmpty(this.GroupIndex))
                            {
                                foreach (string str in this.GroupIndex.Split(new char[] { ';' }))
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
                                        Microsoft.Office.Interop.Excel.Range range = worksheet.Cells[num7, num8] as Microsoft.Office.Interop.Excel.Range;
                                        if (range != null)
                                        {
                                            if (bool.Parse(range.MergeCells.ToString()))
                                            {
                                                Microsoft.Office.Interop.Excel.Range range2 = worksheet.Cells[range.MergeArea.Row, range.MergeArea.Column] as Microsoft.Office.Interop.Excel.Range;
                                                if (s != "")
                                                {
                                                    range2.Value2 = row[s];
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
                    int num11 = int.Parse(this.StartIndex);
                    while (num6 <= ((num5 + num3) - 1L))
                    {
                        worksheet = (Worksheet) pWorkbook.Worksheets[num6];
                        num4 = num10 * 0xffffL;
                        if (num4 > count)
                        {
                            num4 = count;
                        }
                        int num12 = (pDt.Columns.Count - this._dtColIndex) + 1;
                        object[,] objArray = new object[num4, num12];
                        Microsoft.Office.Interop.Excel.Range range3 = worksheet.get_Range(worksheet.Cells[num11, 1], worksheet.Cells[num11, pDt.Columns.Count - this._dtColIndex]);
                        for (int j = Convert.ToInt32((long) (0xffffL * (num3 - 1L))); j < num4; j++)
                        {
                            int num14 = 0;
                            for (int k = this._dtColIndex; k < pDt.Columns.Count; k++)
                            {
                                objArray[j, num14] = pDt.Rows[j][k];
                                num14++;
                            }
                            num2 += 1L;
                            float single1 = ((float) (100L * num2)) / ((float) count);
                            range3.Insert(XlInsertShiftDirection.xlShiftDown, System.Type.Missing);
                            System.Windows.Forms.Application.DoEvents();
                        }
                        range3 = worksheet.get_Range(worksheet.Cells[num11, 1], worksheet.Cells[(num11 + num4) - 1L, num12 - 1]);
                        range3.Value2 = objArray;
                        range3.Borders.LineStyle = 1;
                        range3.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                        range3.VerticalAlignment = XlVAlign.xlVAlignCenter;
                        num10++;
                        num6++;
                    }
                    pWorkbook.Saved = true;
                    pWorkbook.Save();
                }
            }
        }

        protected virtual void WriteExcel3(System.Data.DataTable pDt, Workbook pWorkbook)
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
                        if (worksheet.Name == this.ReportName)
                        {
                            range = worksheet.Cells[1, 1] as Microsoft.Office.Interop.Excel.Range;
                            if (range != null)
                            {
                                if ((this._theme == "SF") && (this._reportID == "0"))
                                {
                                    Microsoft.Office.Interop.Excel.Range range2 = worksheet.Cells[range.MergeArea.Row, range.MergeArea.Column] as Microsoft.Office.Interop.Excel.Range;
                                    range2.Value2 = this.NianFen + " 年 " + this.YueFen + " 月 森 林 火 灾 统 计 报 表";
                                }
                                else if ((this._theme == "ZH") && (this._reportID == "0"))
                                {
                                    Microsoft.Office.Interop.Excel.Range range3 = worksheet.Cells[range.MergeArea.Row, range.MergeArea.Column] as Microsoft.Office.Interop.Excel.Range;
                                    range3.Value2 = this.NianFen + " 年 林 业 病 虫 害 按 区 域 统 计 年 报 表";
                                }
                            }
                            DataRow row = pDt.Rows[0];
                            if (!string.IsNullOrEmpty(this.GroupIndex))
                            {
                                foreach (string str in this.GroupIndex.Split(new char[] { ';' }))
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
                                                Microsoft.Office.Interop.Excel.Range range4 = worksheet.Cells[range.MergeArea.Row, range.MergeArea.Column] as Microsoft.Office.Interop.Excel.Range;
                                                if (s != "")
                                                {
                                                    range4.Value2 = row[s];
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
                    int num11 = int.Parse(this.StartIndex);
                    while (num6 <= ((num5 + num3) - 1L))
                    {
                        worksheet = (Worksheet) pWorkbook.Worksheets[num6];
                        range = worksheet.get_Range(worksheet.Cells[num11, 1], worksheet.Cells[num11, pDt.Columns.Count - this._dtColIndex]);
                        num4 = num10 * 0xffffL;
                        if (num4 > count)
                        {
                            num4 = count;
                        }
                        object[,] objArray = new object[num4, pDt.Columns.Count];
                        for (int j = Convert.ToInt32((long) (0xffffL * (num3 - 1L))); j < num4; j++)
                        {
                            int num13 = 0;
                            for (int k = this._dtColIndex; k < pDt.Columns.Count; k++)
                            {
                                objArray[j, num13] = pDt.Rows[j][k];
                                num13++;
                            }
                            num2 += 1L;
                            float single1 = ((float) (100L * num2)) / ((float) count);
                            range.Insert(XlInsertShiftDirection.xlShiftDown, System.Type.Missing);
                            System.Windows.Forms.Application.DoEvents();
                        }
                        range = worksheet.get_Range(worksheet.Cells[num11, 1], worksheet.Cells[(num11 + pDt.Rows.Count) - 1, pDt.Columns.Count - this._dtColIndex]);
                        range.Value2 = objArray;
                        range.Borders.LineStyle = 1;
                        range.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                        range.VerticalAlignment = XlVAlign.xlVAlignCenter;
                        num10++;
                        num6++;
                    }
                    pWorkbook.Saved = true;
                    pWorkbook.Save();
                }
            }
        }

        public string BK
        {
            get
            {
                return this._bk;
            }
            set
            {
                this._bk = value;
            }
        }

        public string DataTable
        {
            get
            {
                return this._dataTable;
            }
            set
            {
                this._dataTable = value;
            }
        }

        public int DataTableColIndex
        {
            get
            {
                return this._dtColIndex;
            }
            set
            {
                this._dtColIndex = value;
            }
        }

        protected string DataTableName
        {
            get
            {
                return this._dataTableName;
            }
            set
            {
                this._dataTableName = value;
            }
        }

        public string GroupIndex
        {
            get
            {
                return this._groupIndex;
            }
            set
            {
                this._groupIndex = value;
            }
        }

        public string MergeColIndex
        {
            get
            {
                return this._mergeColIndex;
            }
            set
            {
                this._mergeColIndex = value;
            }
        }

        public string NianFen
        {
            get
            {
                return this._nianFen;
            }
            set
            {
                this._nianFen = value;
            }
        }

        public string ReportID
        {
            get
            {
                return this._reportID;
            }
            set
            {
                this._reportID = value;
            }
        }

        public string ReportName
        {
            get
            {
                return this._reportName;
            }
            set
            {
                this._reportName = value;
            }
        }

        public string StartIndex
        {
            get
            {
                return this._startIndex;
            }
            set
            {
                this._startIndex = value;
            }
        }







        public SystemType SysType
        {
            get
            {
                return this._sysType;
            }
            set
            {
                this._sysType = value;
            }
        }

        public string TaskID
        {
            get
            {
                return this._taskID;
            }
            set
            {
                this._taskID = value;
            }
        }

        public string Theme
        {
            get
            {
                return this._theme;
            }
            set
            {
                this._theme = value;
            }
        }


        public string YueFen
        {
            get
            {
                return this._yueFen;
            }
            set
            {
                this._yueFen = value;
            }
        }
    }
}

