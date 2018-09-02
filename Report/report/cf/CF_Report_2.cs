namespace Report
{
    using DevExpress.XtraEditors;
    using Microsoft.Office.Interop.Excel;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Windows.Forms;
    using td.db.mid.forest;

    /// <summary>
    /// 采伐统计表--林木每公顷蓄积量和出材量统计表
    /// </summary>
    internal class CF_Report_2 : ReportEntity
    {
        protected List<ZT_CF_Mid> m_dataList;

        private System.Data.DataTable m_table;

        /// <summary>
        /// 采伐统计表--林木每公顷蓄积量和出材量统计表:构造器
        /// </summary>
        public CF_Report_2()
        {
            base.ReportID = "2";
            base.Theme = "CF";
            this.StartIndex = "8";
            this.DataTableColIndex = 0;
            MergeColIndex = "1";
            m_dataList = null;
        }

        /// <summary>
        /// 初始化报表字段：获取需要的字段
        /// </summary>
        /// <param name="pReportParamter"></param>
        public override void InitialReport(ReportParamter pReportParamter)
        {
            base.InitialReport(pReportParamter);
            //需要获取的字段
            string subFields = "SHI,XIAN,XIANG,CUN,XIAO_BAN,LIN_ZHONG,YOU_SHI_SZ,LIN_BAN,QI_YUAN,PINGJUN_NL,YU_BI_DU,PINGJUN_SG,PINGJUN_XJ,HUO_LMGQXJ,GXFS,CFMJ,CFXJ,CFZS,CCLV,MIAN_JI,DI_LEI,GXDJ";////"+MIAN_JI,DI_LEI,AJLX,XWZT,SSLDMJ,SSLMXJ,SSMZZS,SSYSMMZS,FSRQ,JLRQ"
            //第一个报表在此出现为初始化异常：原因：没有加载指定图层

            m_dataList = pReportParamter.FindFromLayer_CF.Find(subFields, pReportParamter.BK, "Order by CUN");
        }

        /// <summary>
        /// 将查询到的数据写入虚拟Excel表中：此时还未真正导入Excel表的数据
        /// </summary>
        /// <returns></returns>
        public override System.Data.DataTable FromMid2Table()
        {
            m_table = MakeTable();

            if (m_dataList.Count < 1)
            {

                return m_table;
            }

            string linban = "";
            string xiaoban = "";
            string linzhong = "";
            string shuzhong = "";
            string qiyaun = "";
            string linling = "";
            string gengxindengji = "";
            ////var cffs = m_dataList.Where(p => !string.IsNullOrWhiteSpace(p.CFFS));
            ////if (cffs.Count() < 1)
            ////{
            ////    return table;
            ////}

            var xianGrp = m_dataList.GroupBy(p => p.XIAN);
            foreach (var xian in xianGrp)
            {
                string xianName = MDM.FindXiangName(xian.Key);

                //按乡统计
                var xiangGrps = xian.GroupBy(p => p.XIANG);
                foreach (var xg in xiangGrps)
                {
                    string xiangName = MDM.FindXiangName(xg.Key);

                    //按村统计
                    var cunGrps = xg.GroupBy(p => p.CUN);
                    foreach (var cGrp in cunGrps)
                    {
                        string cunName = MDM.FindCunName(cGrp.Key);

                        //按林班统计
                        var linbanGrps = cGrp.GroupBy(p => p.LIN_BAN);
                        if (linbanGrps.Count() < 1)
                        {
                            MakeRow(cGrp, xianName, xiangName, cunName, linban, xiaoban, linzhong, shuzhong, qiyaun, linling, gengxindengji);
                            return m_table;
                        }
                        foreach (var lbGrp in linbanGrps)
                        {
                            linban = MDM.FindName("LIN_BAN", lbGrp.Key);
                            if (lbGrp.Count() < 1)
                            {
                                return m_table;
                            }

                            //按小班统计
                            var xiaobanGrps = lbGrp.GroupBy(p => p.XIAO_BAN);
                            if (xiaobanGrps.Count() < 1)
                            {
                                MakeRow(cGrp, xianName, xiangName, cunName, linban, xiaoban, linzhong, shuzhong, qiyaun, linling, gengxindengji);
                                return m_table;
                            }
                            foreach (var xbGrp in xiaobanGrps)
                            {
                                xiaoban = MDM.FindName("XIAO_BAN", xbGrp.Key);
                                if (xbGrp.Count() < 1)
                                {
                                    return m_table;
                                }

                                //按林种统计
                                var linzhongGrp = xbGrp.GroupBy(p => p.LIN_ZHONG);

                                if (linzhongGrp.Count() < 1)
                                {
                                    MakeRow(cGrp, xianName, xiangName, cunName, linban, xiaoban, linzhong, shuzhong, qiyaun, linling, gengxindengji);
                                    return m_table;
                                }

                                foreach (var lzGrp in linzhongGrp)
                                {
                                    linzhong = MDM.FindName("LIN_ZHONG", lzGrp.Key);
                                    if (lzGrp.Count() < 1)
                                    {
                                        return m_table;
                                    }

                                    //按树种统计
                                    var shuzhongGrp = lzGrp.GroupBy(p => p.YOU_SHI_SZ);
                                    if (shuzhongGrp.Count() < 1)
                                    {
                                        MakeRow(cGrp, xianName, xiangName, cunName, linban, xiaoban, linzhong, shuzhong, qiyaun, linling, gengxindengji);
                                        return m_table;
                                    }
                                    foreach (var szGrp in shuzhongGrp)
                                    {
                                        shuzhong = MDM.FindName("YOU_SHI_SZ", szGrp.Key);
                                        if (szGrp.Count() < 1)
                                        {
                                            return m_table;
                                        }

                                        //按起源统计
                                        var qiyuanGrp = szGrp.GroupBy(p => p.QI_YUAN);
                                        if (qiyuanGrp.Count() < 1)
                                        {
                                            MakeRow(cGrp, xianName, xiangName, cunName, linban, xiaoban, linzhong, shuzhong, qiyaun, linling, gengxindengji);
                                            return m_table;
                                        }
                                        foreach (var qyGrp in qiyuanGrp)
                                        {
                                            qiyaun = MDM.FindName("QI_YUAN", qyGrp.Key);
                                            if (qyGrp.Count() < 1)
                                            {
                                                return m_table;
                                            }

                                            //按林龄统计
                                            var linlingGrp = qyGrp.GroupBy(p => p.PINGJUN_NL);
                                            if (linlingGrp.Count() < 1)
                                            {
                                                MakeRow(cGrp, xianName, xiangName, cunName, linban, xiaoban, linzhong, shuzhong, qiyaun, linling, gengxindengji);
                                                return m_table;
                                            }
                                            foreach (var llGrp in linlingGrp)
                                            {
                                                linling = MDM.FindName("PINGJUN_NL", qyGrp.Key);
                                                if (llGrp.Count() < 1)
                                                {
                                                    return m_table;
                                                }

                                                //按郁闭度统计
                                                var ybdGrp = llGrp.GroupBy(p => p.YU_BI_DU);
                                                if (ybdGrp.Count() < 1)
                                                {
                                                    MakeRow(cGrp, xianName, xiangName, cunName, linban, xiaoban, linzhong, shuzhong, qiyaun, linling, gengxindengji);
                                                    return m_table;
                                                }
                                                foreach (var ybd in ybdGrp)
                                                {
                                                    gengxindengji = MDM.FindName("YU_BI_DU", qyGrp.Key);
                                                    if (ybd.Count() < 1)
                                                    {
                                                        return m_table;
                                                    }

                                                    //按更新等级统计
                                                    var gxdjGrp = ybd.GroupBy(p => p.GXDJ);
                                                    if (gxdjGrp.Count() < 1)
                                                    {
                                                        MakeRow(cGrp, xianName, xiangName, cunName, linban, xiaoban, linzhong, shuzhong, qiyaun, linling, gengxindengji);
                                                        return m_table;
                                                    }
                                                    foreach (var gxdj in gxdjGrp)
                                                    {
                                                        gengxindengji = MDM.FindName("GXDJ", gxdj.Key);
                                                        MakeRow(cGrp, xianName, xiangName, cunName, linban, xiaoban, linzhong, shuzhong, qiyaun, linling, gengxindengji);
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return m_table;
        }

        private void MakeRow(IGrouping<string, ZT_CF_Mid> data, string xianName, string xiangName, string cunName, string linban, string xiaoban, string linzhong, string shuzhong, string qiyaun, string linling, string dengxingdengji)
        {
            DataRow row = m_table.NewRow();

            string shuzhong_tq = shuzhong.Substring(shuzhong.LastIndexOf(":") + 1);
            row["YOU_SHI_SZ"] = shuzhong_tq;

            row["JINGJIE"] = "";
            row["JCLX"] = "";

            double pingjunzhijing = data.Where(p => Convert.ToInt32(p.CFFS) == 11).Sum(p => p.PINGJUN_XJ);
            row["PJXJ"] = pingjunzhijing;
            double pingjunshugao = data.Where(p => Convert.ToInt32(p.CFFS) == 11).Sum(p => p.PINGJUN_SG);
            row["PJSG"] = pingjunshugao;

            row["JCMZSHJ"] = 0;
            row["JCMZSYCS"] = 0;
            row["JCMZSBYCS"] = 0;
            row["JCMZSXCS"] = 0;

            row["XJLHJ"] = 0;
            row["XJLYCS"] = 0;
            row["XJLBYCS"] = 0;
            row["XJLXCS"] = 0;

            double cclv = data.Where(p => Convert.ToInt32(p.CFFS) == 11).Sum(p => p.CCLV) + data.Where(p => Convert.ToInt32(p.CFFS) == 12).Sum(p => p.CCLV) + data.Where(p => Convert.ToInt32(p.CFFS) == 13).Sum(p => p.CCLV) + data.Where(p => Convert.ToInt32(p.CFFS) == 21).Sum(p => p.CCLV) + data.Where(p => Convert.ToInt32(p.CFFS) == 22).Sum(p => p.CCLV) + data.Where(p => Convert.ToInt32(p.CFFS) == 23).Sum(p => p.CCLV) + data.Where(p => Convert.ToInt32(p.CFFS) == 31).Sum(p => p.CCLV) + data.Where(p => Convert.ToInt32(p.CFFS) == 32).Sum(p => p.CCLV) + data.Where(p => Convert.ToInt32(p.CFFS) == 41).Sum(p => p.CCLV);
            double cfzs = data.Where(p => Convert.ToInt32(p.CFFS) == 11).Sum(p => p.CFZS) + data.Where(p => Convert.ToInt32(p.CFFS) == 12).Sum(p => p.CFZS) + data.Where(p => Convert.ToInt32(p.CFFS) == 13).Sum(p => p.CFZS) + data.Where(p => Convert.ToInt32(p.CFFS) == 21).Sum(p => p.CFZS) + data.Where(p => Convert.ToInt32(p.CFFS) == 22).Sum(p => p.CFZS) + data.Where(p => Convert.ToInt32(p.CFFS) == 23).Sum(p => p.CFZS) + data.Where(p => Convert.ToInt32(p.CFFS) == 31).Sum(p => p.CFZS) + data.Where(p => Convert.ToInt32(p.CFFS) == 32).Sum(p => p.CFZS) + data.Where(p => Convert.ToInt32(p.CFFS) == 41).Sum(p => p.CFZS);
            row["CCLV"] = cclv;
            double ccliang = cfzs * cclv;
            row["CCLIANG"] = ccliang;
            m_table.Rows.Add(row);
        }

        /// <summary>
        /// 操作并生成各行数据
        /// </summary>
        /// <param name="cGrp"></param>
        /// <param name="xianName"></param>
        /// <param name="xiangName"></param>
        /// <param name="cunName"></param>
        private void MakeRow(IEnumerable<FOR_XIAOBAN_Mid> data, string xianName, string xiangName, string cunName)
        {

        }

        /// <summary>
        /// 根据需要重写父类的表。
        /// </summary>
        /// <returns></returns>
        protected override System.Data.DataTable MakeTable()
        {
            System.Data.DataTable table = new System.Data.DataTable("ResultTable");

            table.Columns.Add("YOU_SHI_SZ", typeof(string));

            table.Columns.Add("JINGJIE", typeof(string));

            table.Columns.Add("JCLX", typeof(string));

            table.Columns.Add("PJXJ", typeof(double));

            table.Columns.Add("PJSG", typeof(double));

            table.Columns.Add("JCMZSHJ", typeof(double));

            table.Columns.Add("JCMZSYCS", typeof(double));

            table.Columns.Add("JCMZSBYCS", typeof(double));

            table.Columns.Add("JCMZSXCS", typeof(double));

            table.Columns.Add("XJLHJ", typeof(double));

            table.Columns.Add("XJLYCS", typeof(double));

            table.Columns.Add("XJLBYCS", typeof(double));

            table.Columns.Add("XJLXCS", typeof(double));
            table.Columns.Add("CCLV", typeof(double));
            table.Columns.Add("CCLIANG", typeof(double));

            m_table = table;
            return table;
        }


        public IEnumerable<object> ybdGrp { get; set; }

        protected override void WriteExcel(System.Data.DataTable pDt, Workbook pWorkbook)
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
                        int num6 = int.Parse(pDt.Compute("Count(PARAMS)", "PARAMS=3").ToString());
                        for (int j = 2; j <= num6; j++)
                        {
                            after.Copy(System.Type.Missing, after);
                            after = (Worksheet) pWorkbook.Worksheets[pWorkbook.Worksheets.Count];
                            after.Name = base.ReportName + "(" + j.ToString() + ")";
                        }
                        int count = pDt.Columns.Count;
                        int dataTableColIndex = base.DataTableColIndex;
                        for (int k = 0; k < pDt.Rows.Count; k++)
                        {
                            int num9 = 1;
                            DataRow row = pDt.Rows[k];
                            object obj3 = row[pDt.Columns.Count - 1];
                            if (obj3.ToString() == "3")
                            {
                                num5 = int.Parse(base.StartIndex);
                                after = (Worksheet) pWorkbook.Worksheets[num3];
                                num3++;
                                if (!string.IsNullOrEmpty(base.GroupIndex))
                                {
                                    foreach (string str2 in base.GroupIndex.Split(new char[] { ';' }))
                                    {
                                        if (str2.Trim() != "")
                                        {
                                            string[] strArray2 = str2.Split(new char[] { ',' });
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
                                            Microsoft.Office.Interop.Excel.Range range = after.Cells[num10, num11] as Microsoft.Office.Interop.Excel.Range;
                                            if (range != null)
                                            {
                                                if (bool.Parse(range.MergeCells.ToString()))
                                                {
                                                    Microsoft.Office.Interop.Excel.Range range2 = after.Cells[range.MergeArea.Row, range.MergeArea.Column] as Microsoft.Office.Interop.Excel.Range;
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
                            }
                            else
                            {
                                for (int m = base.DataTableColIndex; m < (pDt.Columns.Count - 1); m++)
                                {
                                    Microsoft.Office.Interop.Excel.Range range3 = after.Cells[num5, num9] as Microsoft.Office.Interop.Excel.Range;
                                    range3.Borders.LineStyle = 1;
                                    range3.Value2 = row[m];
                                    num9++;
                                }
                                num5++;
                            }
                            System.Windows.Forms.Application.DoEvents();
                        }
                        pWorkbook.Saved = true;
                        pWorkbook.Save();
                    }
                }
            }
        }

        ///此方法让表无法正常输出，故注销
        ////protected override void WriteExcel2(System.Data.DataTable pDt, Workbook pWorkbook)
        ////{
        ////    if ((pDt != null) && (pDt.Rows.Count != 0))
        ////    {
        ////        long num = 0xffffL;
        ////        if (pDt.Rows.Count > (num * (0xff - pWorkbook.Worksheets.Count)))
        ////        {
        ////            XtraMessageBox.Show("数据过多，无法保存在一个Excel文件中！");
        ////        }
        ////        else
        ////        {
        ////            Worksheet after = null;
        ////            int num3 = -1;
        ////            for (int i = 1; i <= pWorkbook.Worksheets.Count; i++)
        ////            {
        ////                after = (Worksheet) pWorkbook.Worksheets[i];
        ////                if (after.Name == base.ReportName)
        ////                {
        ////                    num3 = i;
        ////                    break;
        ////                }
        ////            }
        ////            if (pWorkbook != null)
        ////            {
        ////                int num5 = int.Parse(base.StartIndex);
        ////                int num6 = int.Parse(pDt.Compute("Count(PARAMS)", "PARAMS=3").ToString());
        ////                for (int j = 2; j <= num6; j++)
        ////                {
        ////                    after.Copy(System.Type.Missing, after);
        ////                    after = (Worksheet) pWorkbook.Worksheets[(num3 + j) - 1];
        ////                    after.Name = base.ReportName + "(" + j.ToString() + ")";
        ////                }
        ////                int num8 = ((pDt.Columns.Count - 1) - base.DataTableColIndex) + 1;
        ////                List<object[]> list = new List<object[]>();
        ////                num5 = int.Parse(base.StartIndex);
        ////                int num9 = 0;
        ////                for (int k = 0; k < pDt.Rows.Count; k++)
        ////                {
        ////                    DataRow row = pDt.Rows[k];
        ////                    object obj3 = row[pDt.Columns.Count - 1];
        ////                    if (obj3.ToString() == "3")
        ////                    {
        ////                        if (list.Count > 0)
        ////                        {
        ////                            object[,] objArray = new object[list.Count, num8];
        ////                            Microsoft.Office.Interop.Excel.Range range = after.get_Range(after.Cells[num5, 1], after.Cells[num5, num8 - 1]);
        ////                            for (int m = 0; m < list.Count; m++)
        ////                            {
        ////                                for (int n = 0; n < num8; n++)
        ////                                {
        ////                                    objArray[m, n] = list[m][n];
        ////                                }
        ////                                range.Insert(XlInsertShiftDirection.xlShiftDown, System.Type.Missing);
        ////                            }
        ////                            range = after.get_Range(after.Cells[num5, 1], after.Cells[(num5 + num9) - 1, num8 - 1]);
        ////                            range.Value2 = objArray;
        ////                            range.Borders.LineStyle = 1;
        ////                            list.Clear();
        ////                        }
        ////                        num9 = 0;
        ////                        after = (Worksheet) pWorkbook.Worksheets[num3];
        ////                        num3++;
        ////                        if (!string.IsNullOrEmpty(base.GroupIndex))
        ////                        {
        ////                            foreach (string str2 in base.GroupIndex.Split(new char[] { ';' }))
        ////                            {
        ////                                if (str2.Trim() != "")
        ////                                {
        ////                                    string[] strArray2 = str2.Split(new char[] { ',' });
        ////                                    string s = strArray2[0].Trim();
        ////                                    int num13 = 0;
        ////                                    if (s != "")
        ////                                    {
        ////                                        num13 = int.Parse(s);
        ////                                    }
        ////                                    s = strArray2[1].Trim();
        ////                                    int num14 = 0;
        ////                                    if (s != "")
        ////                                    {
        ////                                        num14 = int.Parse(s);
        ////                                    }
        ////                                    s = strArray2[2].Trim();
        ////                                    Microsoft.Office.Interop.Excel.Range range2 = after.Cells[num13, num14] as Microsoft.Office.Interop.Excel.Range;
        ////                                    if (range2 != null)
        ////                                    {
        ////                                        if (bool.Parse(range2.MergeCells.ToString()))
        ////                                        {
        ////                                            Microsoft.Office.Interop.Excel.Range range3 = after.Cells[range2.MergeArea.Row, range2.MergeArea.Column] as Microsoft.Office.Interop.Excel.Range;
        ////                                            if (s != "")
        ////                                            {
        ////                                                range3.Value2 = row[s];
        ////                                            }
        ////                                        }
        ////                                        else if (s != "")
        ////                                        {
        ////                                            range2.Value2 = row[s];
        ////                                        }
        ////                                    }
        ////                                }
        ////                            }
        ////                        }
        ////                    }
        ////                    else
        ////                    {
        ////                        int index = 0;
        ////                        object[] item = new object[num8];
        ////                        for (int num16 = base.DataTableColIndex; num16 < (pDt.Columns.Count - 1); num16++)
        ////                        {
        ////                            item[index] = row[num16];
        ////                            index++;
        ////                        }
        ////                        num9++;
        ////                        list.Add(item);
        ////                    }
        ////                    System.Windows.Forms.Application.DoEvents();
        ////                }
        ////                if (list.Count > 0)
        ////                {
        ////                    object[,] objArray3 = new object[list.Count, num8];
        ////                    Microsoft.Office.Interop.Excel.Range range4 = after.get_Range(after.Cells[num5, 1], after.Cells[num5, num8 - 1]);
        ////                    for (int num17 = 0; num17 < list.Count; num17++)
        ////                    {
        ////                        for (int num18 = 0; num18 < num8; num18++)
        ////                        {
        ////                            objArray3[num17, num18] = list[num17][num18];
        ////                        }
        ////                        range4.Insert(XlInsertShiftDirection.xlShiftDown, System.Type.Missing);
        ////                    }
        ////                    range4 = after.get_Range(after.Cells[num5, 1], after.Cells[(num5 + num9) - 1, num8 - 1]);
        ////                    range4.Value2 = objArray3;
        ////                    range4.Borders.LineStyle = 1;
        ////                    range4.HorizontalAlignment = XlHAlign.xlHAlignCenter;
        ////                    range4.VerticalAlignment = XlVAlign.xlVAlignCenter;
        ////                    list.Clear();
        ////                }
        ////                pWorkbook.Saved = true;
        ////                pWorkbook.Save();
        ////            }
        ////        }
        ////    }
        ////}
    }
}

