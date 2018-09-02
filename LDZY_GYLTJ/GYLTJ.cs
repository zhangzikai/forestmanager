namespace LDZY_GYLTJ
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.Data.SQLite;
    using System.Linq;
    using System.Windows.Forms;

    /// <summary>
    /// 公益林统计的底层类
    /// </summary>
    public class GYLTJ
    {
        /// SQLite
        ////public System.Data.SQLite.SQLiteConnection M_Con;
        ////private SQLiteDataAdapter M_Da;

        /// SQLServer
        private SqlConnection M_Con;
        private SqlDataAdapter M_Da;
        private static string str_connectionstring;
        private static string str_xbtable;

        private DataTable B1()
        {
            DataTable table = new DataTable("ResultTable");
            DataColumn column = new DataColumn("TJDW", typeof(string));
            table.Columns.Add(column);
            column = new DataColumn("TDZL", typeof(string));
            table.Columns.Add(column);
            column = new DataColumn("MJHJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("FHLDMJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("SYHYLMJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("STBCLMJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("FFGSLMJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("NTMCFHLMJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("HALMJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("HSLMJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("QTFHLMJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("TYLMJXJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("GFLMJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("SYLMJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("MSLMJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("HJBHLMJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("FJLMJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("MSGJLMJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("ZRBHQLMJ", typeof(double));
            table.Columns.Add(column);
            return table;
        }

        public DataTable B1TJByXianXiangCun(bool blnTJCun)
        {
            DataTable table = new DataTable("ResultTable");
            table = this.B1();
            DataTable mytjdt = new DataTable();
            string cmdtxt = "SELECT LTRIM(RTRIM(SHI)) AS SHI, LTRIM(RTRIM(XIAN)) AS XIAN,LTRIM(RTRIM(XIANG)) AS XIANG,LTRIM(RTRIM(CUN)) AS CUN,";
            cmdtxt = (cmdtxt + "LTRIM(RTRIM(DI_LEI)) AS TDZL,LIN_ZHONG AS LZ,SUM(MIAN_JI) AS MIAN_JI FROM " + TABLE_XBTableName + " WHERE (RTRIM(LTRIM(SEN_LIN_LB))='011') ") + " AND (RTRIM(LTRIM(SHI_QUAN_D))<'22') AND (RTRIM(LTRIM(LIN_ZHONG))<'230') AND (RTRIM(LTRIM(DI_LEI))>'109') AND (RTRIM(LTRIM(DI_LEI))<'801') GROUP BY SHI,XIAN, XIANG,CUN,DI_LEI,LIN_ZHONG";
            mytjdt = this.GetTable(cmdtxt, TABLE_XBTableName);
            if (mytjdt == null)
            {
                MessageBox.Show(TABLE_XBTableName + " B1公益林按地类统计出错！", "信息", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return null;
            }
            if (mytjdt.Rows.Count == 0)
            {
                return table;
            }
            List<short> distTDZLList = new List<short>();
            List<string> list4 = new List<string>();
            List<string> list5 = new List<string>();
            mytjdt.Columns.Add("PTDZL", typeof(string));
            string tjdw = mytjdt.Rows[0]["SHI"].ToString().Trim();

            for (int i = 0; i < mytjdt.Rows.Count; i++)
            {
                if (mytjdt.Rows[i]["TDZL"].ToString().Trim().Length == 0)
                {
                    mytjdt.Rows[i]["TDZL"] = 0;
                }
                string str3 = mytjdt.Rows[i]["TDZL"].ToString();

                switch (str3)
                {
                    case "111":
                    case "112":
                    case "120":
                    case "130":
                        mytjdt.Rows[i]["PTDZL"] = "110";
                        break;

                    case "200":
                        mytjdt.Rows[i]["PTDZL"] = "200";
                        break;

                    case "301":
                    case "302":
                        mytjdt.Rows[i]["PTDZL"] = "300";
                        break;

                    case "401":
                    case "402":
                    case "403":
                    case "404":
                        mytjdt.Rows[i]["PTDZL"] = "400";
                        break;

                    default:
                        if (str3 == "500")
                        {
                            mytjdt.Rows[i]["PTDZL"] = "500";
                        }
                        else if (str3.Trim().IndexOf("60") > -1)
                        {
                            mytjdt.Rows[i]["PTDZL"] = "600";
                        }
                        else if ((((str3 == "701") || (str3 == "702")) || ((str3 == "703") || (str3 == "704"))) || ((str3 == "705") || (str3 == "706")))
                        {
                            mytjdt.Rows[i]["PTDZL"] = "700";
                        }
                        else if (str3 == "800")
                        {
                            mytjdt.Rows[i]["PTDZL"] = "800";
                        }
                        else if (str3=="1410")
                        {
                            mytjdt.Rows[i]["PTDZL"] = "1410";
                        }
                        else if (str3 == "1111")
                        {
                            mytjdt.Rows[i]["PTDZL"] = "1111";
                        }
                        else if (str3 == "1320")
                        {
                            mytjdt.Rows[i]["PTDZL"] = "1320";
                        }
                        else if (str3 == "1112")
                        {
                            mytjdt.Rows[i]["PTDZL"] = "1112";
                        }
                        else if (str3 == "1200")
                        {
                            mytjdt.Rows[i]["PTDZL"] = "1200";
                        }
                        else if (str3 == "1730")
                        {
                            mytjdt.Rows[i]["PTDZL"] = "1730";
                        }
                        else if (str3 == "1710")
                        {
                            mytjdt.Rows[i]["PTDZL"] = "1710";
                        }
                        else if (str3 == "1631")
                        {
                            mytjdt.Rows[i]["PTDZL"] = "1631";
                        }
                        break;
                }
                short item = Convert.ToInt16(mytjdt.Rows[i]["PTDZL"].ToString());
                if (!distTDZLList.Contains(item))
                {
                    distTDZLList.Add(item);
                }
                string str5 = mytjdt.Rows[i]["XIAN"].ToString();
                if (!list4.Contains(str5))
                {
                    list4.Add(str5);
                }
            }
            distTDZLList.Sort();
            list4.Sort();
            table.Clear();

            DataTable table4 = this.B1TJTable(tjdw, "合计", mytjdt, distTDZLList);
            foreach (DataRow row2 in table4.Rows)
            {
                table.ImportRow(row2);
            }
            DataTable dataTabeBySelRows1 = mytjdt.Clone();
            List<short> list41 = new List<short>();
            for(int l=0;l<list4.Count;l++){
                dataTabeBySelRows1.Clear();
                list41.Clear();
                string str42 = list4[l].ToString();
                dataTabeBySelRows1 = this.GetDataTabeBySelRows(mytjdt, "XIAN='" + str42 + "'");
                for (int z = 0; z < dataTabeBySelRows1.Rows.Count; z++) {
                    string str43 = dataTabeBySelRows1.Rows[z]["PTDZL"].ToString().Trim();
                    if (str43.Length > 0) {
                        short num43 = Convert.ToInt16(str43);
                        if (!list41.Contains(num43)) {
                            list41.Add(num43);
                        }
                    }
                }
                table4.Clear();
                table4 = this.B1TJTable(str42, "合计", dataTabeBySelRows1, list41);
                foreach (DataRow row in table4.Rows) {
                    table.ImportRow(row);
                }
            if(blnTJCun){
            DataTable dataTabeBySelRows = mytjdt.Clone();
            List<short> list = new List<short>();
            List<string> list33 = new List<string>();
            for (int m = 0; m < dataTabeBySelRows1.Rows.Count; m++)
            {
                string str6 = dataTabeBySelRows1.Rows[m]["XIANG"].ToString().Trim();
                if (!list33.Contains(str6))
                {
                    list33.Add(str6);
                }
            }
            for (int j = 0; j < list33.Count; j++)
            {
                dataTabeBySelRows.Clear();
                list.Clear();
                string str2 = list33[j].ToString();
                dataTabeBySelRows = this.GetDataTabeBySelRows(dataTabeBySelRows1, "XIANG='" + str2 + "'");
                for (int k = 0; k < dataTabeBySelRows.Rows.Count; k++)
                {
                    string str9 = dataTabeBySelRows.Rows[k]["PTDZL"].ToString().Trim();
                    if (str9.Length > 0)
                    {
                        short num7 = Convert.ToInt16(str9);
                        if (!list.Contains(num7))
                        {
                            list.Add(num7);
                        }
                    }
                }
                table4.Clear();
                table4 = this.B1TJTable(str2, "合计", dataTabeBySelRows, list);
                foreach (DataRow row in table4.Rows)
                {
                    table.ImportRow(row);
                }
                if (blnTJCun)
                {
                    List<string> list3 = new List<string>();
                    DataTable table5 = mytjdt.Clone();
                    List<short> list2 = new List<short>();
                    for (int m = 0; m < dataTabeBySelRows.Rows.Count; m++)
                    {
                        string str6 = dataTabeBySelRows.Rows[m]["CUN"].ToString().Trim();
                        if (!list3.Contains(str6))
                        {
                            list3.Add(str6);
                        }
                    }
                    list3.Sort();
                    for (int n = 0; n < list3.Count; n++)
                    {
                        table5.Clear();
                        list2.Clear();
                        string str4 = list3[n].ToString();
                        table5 = this.GetDataTabeBySelRows(dataTabeBySelRows, "CUN='" + str4 + "'");
                        for (int num5 = 0; num5 < table5.Rows.Count; num5++)
                        {
                            string str7 = table5.Rows[num5]["PTDZL"].ToString().Trim();
                            if (str7.Length > 0)
                            {
                                short num9 = Convert.ToInt16(str7);
                                if (!list2.Contains(num9))
                                {
                                    list2.Add(num9);
                                }
                            }
                        }
                        table4.Clear();
                        table4 = this.B1TJTable(str4, "合计", table5, list2);
                        foreach (DataRow row3 in table4.Rows)
                        {
                            table.ImportRow(row3);
                        }
                    }
                }
            }
                }
                }
            mytjdt.Clear();
            table = this.UpdateDWTableByJoin(table);
            return this.UpdateTableZero(table, 3);
        }

        private DataTable B1TJTable(string tjdw, string hjcolname, DataTable mytjdt, List<short> DistTDZLList)
        {
            DataTable table = new DataTable("ResultTable");
            table = this.B1();
            string expression = "SUM(MIAN_JI)";
            string str2 = " LZ ='111'";
            string str3 = "LZ ='112'";
            string str4 = "LZ ='113'";
            string str5 = "LZ ='114'";
            string str6 = "LZ ='115'";
            string str7 = "LZ ='116'";
            string str8 = "LZ ='117'";
            string str9 = " LZ ='121'";
            string str10 = "LZ ='122'";
            string str11 = "LZ ='123'";
            string str12 = "LZ ='124'";
            string str13 = "LZ ='125'";
            string str14 = "LZ ='126'";
            string str15 = "LZ ='127'";
            for (int i = 0; i < DistTDZLList.Count; i++)
            {
                string str16 = DistTDZLList[i].ToString();
                string str17 = "PTDZL='" + str16 + "' AND ";
                double num3 = 0.0;
                double num4 = 0.0;
                double num12 = 0.0;
                double num5 = 0.0;
                double num6 = 0.0;
                double num7 = 0.0;
                double num8 = 0.0;
                double num9 = 0.0;
                double num10 = 0.0;
                double num11 = 0.0;
                double num13 = 0.0;
                double num14 = 0.0;
                double num15 = 0.0;
                double num16 = 0.0;
                double num17 = 0.0;
                double num18 = 0.0;
                double num19 = 0.0;
                if (mytjdt.Select(str17 + str2).Length > 0)
                {
                    num5 = Convert.ToDouble(mytjdt.Compute(expression, str17 + str2));
                }
                if (mytjdt.Select(str17 + str3).Length > 0)
                {
                    num6 = Convert.ToDouble(mytjdt.Compute(expression, str17 + str3));
                }
                if (mytjdt.Select(str17 + str4).Length > 0)
                {
                    num7 = Convert.ToDouble(mytjdt.Compute(expression, str17 + str4));
                }
                if (mytjdt.Select(str17 + str5).Length > 0)
                {
                    num8 = Convert.ToDouble(mytjdt.Compute(expression, str17 + str5));
                }
                if (mytjdt.Select(str17 + str6).Length > 0)
                {
                    num9 = Convert.ToDouble(mytjdt.Compute(expression, str17 + str6));
                }
                if (mytjdt.Select(str17 + str7).Length > 0)
                {
                    num10 = Convert.ToDouble(mytjdt.Compute(expression, str17 + str7));
                }
                if (mytjdt.Select(str17 + str8).Length > 0)
                {
                    num11 = Convert.ToDouble(mytjdt.Compute(expression, str17 + str8));
                }
                num4 = (((((num5 + num6) + num7) + num8) + num9) + num10) + num11;
                if (mytjdt.Select(str17 + str9).Length > 0)
                {
                    num13 = Convert.ToDouble(mytjdt.Compute(expression, str17 + str9));
                }
                if (mytjdt.Select(str17 + str10).Length > 0)
                {
                    num14 = Convert.ToDouble(mytjdt.Compute(expression, str17 + str10));
                }
                if (mytjdt.Select(str17 + str11).Length > 0)
                {
                    num15 = Convert.ToDouble(mytjdt.Compute(expression, str17 + str11));
                }
                if (mytjdt.Select(str17 + str12).Length > 0)
                {
                    num16 = Convert.ToDouble(mytjdt.Compute(expression, str17 + str12));
                }
                if (mytjdt.Select(str17 + str13).Length > 0)
                {
                    num17 = Convert.ToDouble(mytjdt.Compute(expression, str17 + str13));
                }
                if (mytjdt.Select(str17 + str14).Length > 0)
                {
                    num18 = Convert.ToDouble(mytjdt.Compute(expression, str17 + str14));
                }
                if (mytjdt.Select(str17 + str15).Length > 0)
                {
                    num19 = Convert.ToDouble(mytjdt.Compute(expression, str17 + str15));
                }
                num12 = (((((num13 + num14) + num15) + num16) + num17) + num18) + num19;
                num3 = num4 + num12;
                DataRow row = table.NewRow();
                if (str16 == "110")
                {
                    str16 = "有林地";
                }
                else if (str16 == "200")
                {
                    str16 = "疏林地";
                }
                else if (str16 == "300")
                {
                    str16 = "灌木林地";
                }
                else if (str16 == "400")
                {
                    str16 = "未成林地";
                }
                else if (str16 == "500")
                {
                    str16 = "苗圃地";
                }
                else if (str16 == "600")
                {
                    str16 = "无立木林地";
                }
                else if (str16 == "700")
                {
                    str16 = "宜林地";
                }
                else if (str16 == "800")
                {
                    str16 = "辅助生产地";
                }
                row["TDZL"] = str16;
                row["MJHJ"] = Math.Round(num3, 1);
                row["FHLDMJ"] = Math.Round(num4, 1);
                row["SYHYLMJ"] = Math.Round(num5, 1);
                row["STBCLMJ"] = Math.Round(num6, 1);
                row["FFGSLMJ"] = Math.Round(num7, 1);
                row["NTMCFHLMJ"] = Math.Round(num8, 1);
                row["HALMJ"] = Math.Round(num9, 1);
                row["HSLMJ"] = Math.Round(num10, 1);
                row["QTFHLMJ"] = Math.Round(num11, 1);
                row["TYLMJXJ"] = Math.Round(num12, 1);
                row["GFLMJ"] = Math.Round(num13, 1);
                row["SYLMJ"] = Math.Round(num14, 1);
                row["MSLMJ"] = Math.Round(num15, 1);
                row["HJBHLMJ"] = Math.Round(num16, 1);
                row["FJLMJ"] = Math.Round(num17, 1);
                row["MSGJLMJ"] = Math.Round(num18, 1);
                row["ZRBHQLMJ"] = Math.Round(num19, 1);
                if (num3 > 0.0)
                {
                    table.Rows.Add(row);
                }
            }
            if (table.Rows.Count > 0)
            {
                DataRow row2 = table.NewRow();
                row2[0] = tjdw;
                row2[1] = hjcolname;
                if (table.Rows.Count <= 0)
                {
                    return table;
                }
                for (int j = 2; j < table.Columns.Count; j++)
                {
                    row2[j] = Convert.ToDouble(table.Compute("SUM(" + table.Columns[j] + ")", null).ToString());
                }
                table.Rows.InsertAt(row2, 0);
            }
            return table;
        }

        private DataTable B2()
        {
            DataTable table = new DataTable("ResultTable");
            DataColumn column = new DataColumn("TJDW", typeof(string));
            table.Columns.Add(column);
            column = new DataColumn("LDQS", typeof(string));
            table.Columns.Add(column);
            column = new DataColumn("MJHJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("LZMJXJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("SYHYLMJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("STBCLMJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("FFGSLMJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("HALMJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("ZRBHQLMJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("GFLMJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("QTFHLMJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("DLMJXJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("YLDMJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("SHULDMJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("GMLDMJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("WCLLDMJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("MPDMJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("WLMLDMJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("YILDMJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("FZSCLDMJ", typeof(double));
            table.Columns.Add(column);
            return table;
        }

        public DataTable B2TJByXianXiangCun(bool blnTJCun)
        {
            DataTable table = new DataTable("ResultTable");
            table = this.B2();
            DataTable mytjdt = new DataTable();
            string cmdtxt = "SELECT LTRIM(RTRIM(SHI)) AS SHI,LTRIM(RTRIM(XIAN)) AS XIAN,LTRIM(RTRIM(XIANG)) AS XIANG,LTRIM(RTRIM(CUN)) AS CUN,LTRIM(RTRIM(LD_QS)) AS LDQS,";
            cmdtxt = (cmdtxt + "LTRIM(RTRIM(DI_LEI)) AS TDZL,LIN_ZHONG AS LZ,SUM(MIAN_JI) AS MIAN_JI FROM " + TABLE_XBTableName + " WHERE (RTRIM(LTRIM(SEN_LIN_LB))='011') ") + " AND (RTRIM(LTRIM(SHI_QUAN_D))<'22') AND (RTRIM(LTRIM(LIN_ZHONG))<'230') AND (RTRIM(LTRIM(DI_LEI))>'109') AND (RTRIM(LTRIM(DI_LEI))<'801') GROUP BY SHI,XIAN, XIANG,CUN,DI_LEI,LIN_ZHONG,LD_QS ";
            mytjdt = this.GetTable(cmdtxt, TABLE_XBTableName);
            if (mytjdt == null)
            {
                MessageBox.Show(TABLE_XBTableName + " B2公益林按权属统计出错！", "信息", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return null;
            }
            if (mytjdt.Rows.Count == 0)
            {
                return table;
            }
            List<short> distLDQSList = new List<short>();
            List<string> list2 = new List<string>();
            mytjdt.Columns.Add("PTDZL", typeof(string));
            string tjdw = mytjdt.Rows[0]["SHI"].ToString().Trim();
            for (int i = 0; i < mytjdt.Rows.Count; i++)
            {
                if (mytjdt.Rows[i]["LDQS"].ToString().Trim().Length == 0)
                {
                    mytjdt.Rows[i]["LDQS"] = 0;
                }
                short item = Convert.ToInt16(mytjdt.Rows[i]["LDQS"].ToString().Trim());
                if (item >= 20)
                {
                    mytjdt.Rows[i]["LDQS"] = "20";
                    item = Convert.ToInt16(mytjdt.Rows[i]["LDQS"].ToString());
                }
                if (!distLDQSList.Contains(item))
                {
                    distLDQSList.Add(item);
                }
                if (mytjdt.Rows[i]["TDZL"].ToString().Trim().Length == 0)
                {
                    mytjdt.Rows[i]["TDZL"] = 0;
                }
                string str3 = mytjdt.Rows[i]["TDZL"].ToString();
                switch (str3)
                {
                    case "111":
                    case "112":
                    case "120":
                    case "130":
                        mytjdt.Rows[i]["PTDZL"] = "110";
                        break;

                    case "200":
                        mytjdt.Rows[i]["PTDZL"] = "200";
                        break;

                    case "301":
                    case "302":
                        mytjdt.Rows[i]["PTDZL"] = "300";
                        break;

                    case "401":
                    case "402":
                    case "403":
                    case "404":
                        mytjdt.Rows[i]["PTDZL"] = "400";
                        break;

                    default:
                        if (str3 == "500")
                        {
                            mytjdt.Rows[i]["PTDZL"] = "500";
                        }
                        else if (str3.Trim().IndexOf("60") > -1)
                        {
                            mytjdt.Rows[i]["PTDZL"] = "600";
                        }
                        else if ((((str3 == "701") || (str3 == "702")) || ((str3 == "703") || (str3 == "704"))) || ((str3 == "705") || (str3 == "706")))
                        {
                            mytjdt.Rows[i]["PTDZL"] = "700";
                        }
                        else if (str3 == "800")
                        {
                            mytjdt.Rows[i]["PTDZL"] = "800";
                        }
                        break;
                }
                string str5 = mytjdt.Rows[i]["XIAN"].ToString();
                if (!list2.Contains(str5))
                {
                    list2.Add(str5);
                }
            }
            distLDQSList.Sort();
            list2.Sort();
            table.Clear();
            //table.Clear();
            DataTable table3 = this.B2TJTable(tjdw, "合计", mytjdt, distLDQSList);
            foreach (DataRow row2 in table3.Rows)
            {
                table.ImportRow(row2);
            }
            DataTable dataTabeBySelRows1 = mytjdt.Clone();
            List<short> list41 = new List<short>();
            for (int l = 0; l < list2.Count; l++)
            {
                dataTabeBySelRows1.Clear();
                list41.Clear();
                string str42 = list2[l].ToString();
                dataTabeBySelRows1 = this.GetDataTabeBySelRows(mytjdt, "XIAN='" + str42 + "'");
                for (int z = 0; z < dataTabeBySelRows1.Rows.Count; z++)
                {
                    string str43 = dataTabeBySelRows1.Rows[z]["PTDZL"].ToString().Trim();
                    if (str43.Length > 0)
                    {
                        short num43 = Convert.ToInt16(str43);
                        if (!list41.Contains(num43))
                        {
                            list41.Add(num43);
                        }
                    }
                }
                table3.Clear();
                table3 = this.B1TJTable(str42, "合计", dataTabeBySelRows1, list41);
                foreach (DataRow row in table3.Rows)
                {
                    table.ImportRow(row);
                }
                if (blnTJCun)
                {
                    DataTable dataTabeBySelRows = mytjdt.Clone();
                    List<short> list3 = new List<short>();
                    List<string> list33 = new List<string>();
                    for (int m = 0; m < dataTabeBySelRows1.Rows.Count; m++)
                    {
                        string str6 = dataTabeBySelRows1.Rows[m]["XIANG"].ToString().Trim();
                        if (!list33.Contains(str6))
                        {
                            list33.Add(str6);
                        }
                    }
                    for (int j = 0; j < list33.Count; j++)
                    {
                        dataTabeBySelRows.Clear();
                        list3.Clear();
                        string str7 = list33[j].ToString();
                        dataTabeBySelRows = this.GetDataTabeBySelRows(dataTabeBySelRows1, "XIANG='" + str7 + "'");
                        for (int k = 0; k < dataTabeBySelRows.Rows.Count; k++)
                        {
                            string str4 = dataTabeBySelRows.Rows[k]["LDQS"].ToString().Trim();
                            if (str4.Length > 0)
                            {
                                short num6 = Convert.ToInt16(str4);
                                if (!list3.Contains(num6))
                                {
                                    list3.Add(num6);
                                }
                            }
                        }
                        list3.Sort();
                        table3.Clear();
                        table3 = this.B2TJTable(str7, "合计", dataTabeBySelRows, list3);
                        foreach (DataRow row3 in table3.Rows)
                        {
                            table.ImportRow(row3);
                        }
                        if (blnTJCun)
                        {
                            List<string> list4 = new List<string>();
                            DataTable table5 = mytjdt.Clone();
                            List<short> list5 = new List<short>();
                            for (int m = 0; m < dataTabeBySelRows.Rows.Count; m++)
                            {
                                string str6 = dataTabeBySelRows.Rows[m]["CUN"].ToString().Trim();
                                if (!list4.Contains(str6))
                                {
                                    list4.Add(str6);
                                }
                            }
                            list4.Sort();
                            for (int n = 0; n < list4.Count; n++)
                            {
                                table5.Clear();
                                list5.Clear();
                                string str9 = list4[n].ToString();
                                table5 = this.GetDataTabeBySelRows(dataTabeBySelRows, "CUN='" + str9 + "'");
                                for (int num5 = 0; num5 < table5.Rows.Count; num5++)
                                {
                                    string str8 = table5.Rows[num5]["LDQS"].ToString().Trim();
                                    if (str8.Length > 0)
                                    {
                                        short num9 = Convert.ToInt16(str8);
                                        if (!list5.Contains(num9))
                                        {
                                            list5.Add(num9);
                                        }
                                    }
                                }
                                list5.Sort();
                                table3.Clear();
                                table3 = this.B2TJTable(str9, "合计", table5, list5);
                                foreach (DataRow row in table3.Rows)
                                {
                                    table.ImportRow(row);
                                }
                            }
                        }
                    }
                }
            }
            mytjdt.Clear();
            table = this.UpdateDWTableByJoin(table);
            return this.UpdateTableZero(table, 3);
        }

        private DataTable B2TJTable(string tjdw, string hjcolname, DataTable mytjdt, List<short> DistLDQSList)
        {
            DataTable table = new DataTable("ResultTable");
            table = this.B2();
            string expression = "SUM(MIAN_JI)";
            string str2 = " LZ ='111'";
            string str3 = "LZ ='112'";
            string str4 = "LZ ='113'";
            string str5 = "LZ ='114'";
            string str6 = "LZ ='115'";
            string str7 = "LZ ='116'";
            string str8 = "LZ ='117'";
            string str9 = " LZ ='121'";
            string str10 = "LZ ='122'";
            string str11 = "LZ ='123'";
            string str12 = "LZ ='124'";
            string str13 = "LZ ='125'";
            string str14 = "LZ ='126'";
            string str15 = "LZ ='127'";
            string str16 = " PTDZL ='110'";
            string str17 = " PTDZL ='200'";
            string str18 = " PTDZL ='300'";
            string str19 = " PTDZL ='400'";
            string str20 = " PTDZL ='500'";
            string str21 = " PTDZL ='600'";
            string str22 = " PTDZL ='700' ";
            string str23 = " PTDZL ='800'";
            for (int i = 0; i < DistLDQSList.Count; i++)
            {
                string str25 = DistLDQSList[i].ToString();
                string str24 = "LDQS='" + str25 + "' AND ";
                double num10 = 0.0;
                double num11 = 0.0;
                double num12 = 0.0;
                double num13 = 0.0;
                double num14 = 0.0;
                double num15 = 0.0;
                double num16 = 0.0;
                double num17 = 0.0;
                double num5 = 0.0;
                double num7 = 0.0;
                double num18 = 0.0;
                double num19 = 0.0;
                double num20 = 0.0;
                double num21 = 0.0;
                double num8 = 0.0;
                double num22 = 0.0;
                double num23 = 0.0;
                double num24 = 0.0;
                double num25 = 0.0;
                double num4 = 0.0;
                double num26 = 0.0;
                double num27 = 0.0;
                double num28 = 0.0;
                double num3 = 0.0;
                double num29 = 0.0;
                if (mytjdt.Select(str24 + str2).Length > 0)
                {
                    num12 = Convert.ToDouble(mytjdt.Compute(expression, str24 + str2));
                }
                if (mytjdt.Select(str24 + str3).Length > 0)
                {
                    num13 = Convert.ToDouble(mytjdt.Compute(expression, str24 + str3));
                }
                if (mytjdt.Select(str24 + str4).Length > 0)
                {
                    num14 = Convert.ToDouble(mytjdt.Compute(expression, str24 + str4));
                }
                if (mytjdt.Select(str24 + str5).Length > 0)
                {
                    num15 = Convert.ToDouble(mytjdt.Compute(expression, str24 + str5));
                }
                if (mytjdt.Select(str24 + str6).Length > 0)
                {
                    num16 = Convert.ToDouble(mytjdt.Compute(expression, str24 + str6));
                }
                if (mytjdt.Select(str24 + str7).Length > 0)
                {
                    num17 = Convert.ToDouble(mytjdt.Compute(expression, str24 + str7));
                }
                if (mytjdt.Select(str24 + str8).Length > 0)
                {
                    num5 = Convert.ToDouble(mytjdt.Compute(expression, str24 + str8));
                }
                if (mytjdt.Select(str24 + str9).Length > 0)
                {
                    num7 = Convert.ToDouble(mytjdt.Compute(expression, str24 + str9));
                }
                if (mytjdt.Select(str24 + str10).Length > 0)
                {
                    num18 = Convert.ToDouble(mytjdt.Compute(expression, str24 + str10));
                }
                if (mytjdt.Select(str24 + str11).Length > 0)
                {
                    num19 = Convert.ToDouble(mytjdt.Compute(expression, str24 + str11));
                }
                if (mytjdt.Select(str24 + str12).Length > 0)
                {
                    num20 = Convert.ToDouble(mytjdt.Compute(expression, str24 + str12));
                }
                if (mytjdt.Select(str24 + str13).Length > 0)
                {
                    num21 = Convert.ToDouble(mytjdt.Compute(expression, str24 + str13));
                }
                if (mytjdt.Select(str24 + str14).Length > 0)
                {
                    num8 = Convert.ToDouble(mytjdt.Compute(expression, str24 + str14));
                }
                if (mytjdt.Select(str24 + str15).Length > 0)
                {
                    num22 = Convert.ToDouble(mytjdt.Compute(expression, str24 + str15));
                }
                double num30 = ((((((num15 + num17) + num5) + num18) + num19) + num20) + num21) + num8;
                num11 = (((((num12 + num13) + num14) + num16) + num22) + num7) + num30;
                str24 = "LDQS='" + str25 + "' AND ";
                if (mytjdt.Select(str24 + str16).Length > 0)
                {
                    num24 = Convert.ToDouble(mytjdt.Compute(expression, str24 + str16));
                }
                if (mytjdt.Select(str24 + str17).Length > 0)
                {
                    num25 = Convert.ToDouble(mytjdt.Compute(expression, str24 + str17));
                }
                if (mytjdt.Select(str24 + str18).Length > 0)
                {
                    num4 = Convert.ToDouble(mytjdt.Compute(expression, str24 + str18));
                }
                if (mytjdt.Select(str24 + str19).Length > 0)
                {
                    num26 = Convert.ToDouble(mytjdt.Compute(expression, str24 + str19));
                }
                if (mytjdt.Select(str24 + str20).Length > 0)
                {
                    num27 = Convert.ToDouble(mytjdt.Compute(expression, str24 + str20));
                }
                if (mytjdt.Select(str24 + str21).Length > 0)
                {
                    num28 = Convert.ToDouble(mytjdt.Compute(expression, str24 + str21));
                }
                if (mytjdt.Select(str24 + str22).Length > 0)
                {
                    num3 = Convert.ToDouble(mytjdt.Compute(expression, str24 + str22));
                }
                if (mytjdt.Select(str24 + str23).Length > 0)
                {
                    num29 = Convert.ToDouble(mytjdt.Compute(expression, str24 + str23));
                }
                num23 = ((((((num24 + num25) + num4) + num26) + num27) + num28) + num3) + num29;
                num10 = Convert.ToDouble(mytjdt.Compute(expression, "LDQS='" + str25 + "'"));
                DataRow row2 = table.NewRow();
                if (str25 == "10")
                {
                    str25 = "国有";
                }
                else if (str25 == "20")
                {
                    str25 = "集体";
                }
                row2["LDQS"] = str25;
                row2["MJHJ"] = Math.Round(num10, 1);
                row2["LZMJXJ"] = Math.Round(num11, 1);
                row2["SYHYLMJ"] = Math.Round(num12, 1);
                row2["STBCLMJ"] = Math.Round(num13, 1);
                row2["FFGSLMJ"] = Math.Round(num14, 1);
                row2["HALMJ"] = Math.Round(num16, 1);
                row2["ZRBHQLMJ"] = Math.Round(num22, 1);
                row2["GFLMJ"] = Math.Round(num7, 1);
                row2["QTFHLMJ"] = Math.Round(num5, 1);
                row2["DLMJXJ"] = Math.Round(num23, 1);
                row2["YLDMJ"] = Math.Round(num24, 1);
                row2["SHULDMJ"] = Math.Round(num25, 1);
                row2["GMLDMJ"] = Math.Round(num4, 1);
                row2["WCLLDMJ"] = Math.Round(num28, 1);
                row2["MPDMJ"] = Math.Round(num27, 1);
                row2["WLMLDMJ"] = Math.Round(num28, 1);
                row2["YILDMJ"] = Math.Round(num3, 1);
                row2["FZSCLDMJ"] = Math.Round(num29, 1);
                if (num10 > 0.0)
                {
                    table.Rows.Add(row2);
                }
            }
            if (table.Rows.Count > 0)
            {
                DataRow row = table.NewRow();
                row[0] = tjdw;
                row[1] = hjcolname;
                if (table.Rows.Count <= 0)
                {
                    return table;
                }
                for (int j = 2; j < table.Columns.Count; j++)
                {
                    row[j] = Convert.ToDouble(table.Compute("SUM(" + table.Columns[j] + ")", null).ToString());
                }
                table.Rows.InsertAt(row, 0);
            }
            return table;
        }

        private DataTable B3()
        {
            DataTable table = new DataTable("ResultTable");
            DataColumn column = new DataColumn("TJDW", typeof(string));
            table.Columns.Add(column);
            column = new DataColumn("SQJ", typeof(string));
            table.Columns.Add(column);
            column = new DataColumn("MJHJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("LZMJXJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("SYHYLMJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("STBCLMJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("FFGSLMJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("HALMJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("ZRBHQLMJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("GFLMJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("QTFHLMJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("DLMJXJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("YLDMJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("SHULDMJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("GMLDMJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("WCLLDMJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("MPDMJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("WLMLDMJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("YILDMJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("FZSCLDMJ", typeof(double));
            table.Columns.Add(column);
            return table;
        }

        public DataTable B3TJByXianXiangCun(bool blnTJCun)
        {
            DataTable table = new DataTable("ResultTable");
            table = this.B3();
            DataTable mytjdt = new DataTable();
            string cmdtxt = "SELECT LTRIM(RTRIM(SHI)) AS SHI, LTRIM(RTRIM(XIAN)) AS XIAN,LTRIM(RTRIM(XIANG)) AS XIANG,LTRIM(RTRIM(CUN)) AS CUN,LTRIM(RTRIM(SHI_QUAN_D)) AS SQJ,";
            cmdtxt = (cmdtxt + "LTRIM(RTRIM(DI_LEI)) AS TDZL,LIN_ZHONG AS LZ,SUM(MIAN_JI) AS MIAN_JI FROM " + TABLE_XBTableName + " WHERE (RTRIM(LTRIM(SEN_LIN_LB))='011') ") + " AND (RTRIM(LTRIM(SHI_QUAN_D))<'22') AND (RTRIM(LTRIM(LIN_ZHONG))<'230') AND (RTRIM(LTRIM(DI_LEI))>'109') AND (RTRIM(LTRIM(DI_LEI))<'801') GROUP BY SHI,XIAN, XIANG,CUN,DI_LEI,LIN_ZHONG,SHI_QUAN_D ";
            mytjdt = this.GetTable(cmdtxt, TABLE_XBTableName);
            if (mytjdt == null)
            {
                MessageBox.Show(TABLE_XBTableName + " B3公益林按事权级统计出错！", "信息", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return null;
            }
            if (mytjdt.Rows.Count == 0)
            {
                return table;
            }
            List<string> distSQJList = new List<string>();
            List<string> list3 = new List<string>();
            mytjdt.Columns.Add("PTDZL", typeof(string));
            string tjdw = mytjdt.Rows[0]["SHI"].ToString().Trim();
            for (int i = 0; i < mytjdt.Rows.Count; i++)
            {
                string item = mytjdt.Rows[i]["SQJ"].ToString();
                if (((item.Trim() == "10") || (item == "20")) || (item == "21"))
                {
                    if (item == "21")
                    {
                        mytjdt.Rows[i]["SQJ"] = "20";
                    }
                    item = mytjdt.Rows[i]["SQJ"].ToString();
                    if (!distSQJList.Contains(item))
                    {
                        distSQJList.Add(item);
                    }
                }
                if (mytjdt.Rows[i]["TDZL"].ToString().Trim().Length == 0)
                {
                    mytjdt.Rows[i]["TDZL"] = 0;
                }
                string str4 = mytjdt.Rows[i]["TDZL"].ToString();
                switch (str4)
                {
                    case "111":
                    case "112":
                    case "120":
                    case "130":
                        mytjdt.Rows[i]["PTDZL"] = "110";
                        break;

                    case "200":
                        mytjdt.Rows[i]["PTDZL"] = "200";
                        break;

                    case "301":
                    case "302":
                        mytjdt.Rows[i]["PTDZL"] = "300";
                        break;

                    case "401":
                    case "402":
                    case "403":
                    case "404":
                        mytjdt.Rows[i]["PTDZL"] = "400";
                        break;

                    default:
                        if (str4 == "500")
                        {
                            mytjdt.Rows[i]["PTDZL"] = "500";
                        }
                        else if (str4.Trim().IndexOf("60") > -1)
                        {
                            mytjdt.Rows[i]["PTDZL"] = "600";
                        }
                        else if ((((str4 == "701") || (str4 == "702")) || ((str4 == "703") || (str4 == "704"))) || ((str4 == "705") || (str4 == "706")))
                        {
                            mytjdt.Rows[i]["PTDZL"] = "700";
                        }
                        else if (str4 == "800")
                        {
                            mytjdt.Rows[i]["PTDZL"] = "800";
                        }
                        break;
                }
                string str5 = mytjdt.Rows[i]["XIAN"].ToString();
                if (!list3.Contains(str5))
                {
                    list3.Add(str5);
                }
            }
            distSQJList.Sort();
            list3.Sort();
            table.Clear();
            //table.Clear();
            DataTable table4 = this.B3TJTable(tjdw, "合计", mytjdt, distSQJList);
            foreach (DataRow row2 in table4.Rows)
            {
                table.ImportRow(row2);
            }
             DataTable dataTabeBySelRows1 = mytjdt.Clone();
            List<short> list41 = new List<short>();
            for (int l = 0; l < list3.Count; l++)
            {
                dataTabeBySelRows1.Clear();
                list41.Clear();
                string str42 = list3[l].ToString();
                dataTabeBySelRows1 = this.GetDataTabeBySelRows(mytjdt, "XIAN='" + str42 + "'");
                for (int z = 0; z < dataTabeBySelRows1.Rows.Count; z++)
                {
                    string str43 = dataTabeBySelRows1.Rows[z]["PTDZL"].ToString().Trim();
                    if (str43.Length > 0)
                    {
                        short num43 = Convert.ToInt16(str43);
                        if (!list41.Contains(num43))
                        {
                            list41.Add(num43);
                        }
                    }
                }
                table4.Clear();
                table4 = this.B1TJTable(str42, "合计", dataTabeBySelRows1, list41);
                foreach (DataRow row in table4.Rows)
                {
                    table.ImportRow(row);
                }
                if (blnTJCun)
                {
                    DataTable dataTabeBySelRows = mytjdt.Clone();
                    List<string> list5 = new List<string>();
                    List<string> list33 = new List<string>();
                    for (int m = 0; m < dataTabeBySelRows1.Rows.Count; m++)
                    {
                        string str6 = dataTabeBySelRows1.Rows[m]["XIANG"].ToString().Trim();
                        if (!list33.Contains(str6))
                        {
                            list33.Add(str6);
                        }
                    }
                    for (int j = 0; j < list33.Count; j++)
                    {
                        dataTabeBySelRows.Clear();
                        list5.Clear();
                        string str9 = list33[j].ToString();
                        dataTabeBySelRows = this.GetDataTabeBySelRows(mytjdt, "XIANG='" + str9 + "'");
                        for (int k = 0; k < dataTabeBySelRows.Rows.Count; k++)
                        {
                            string str7 = dataTabeBySelRows.Rows[k]["SQJ"].ToString().Trim();
                            if (((str7 == "10") || (str7 == "20")) && !list5.Contains(str7))
                            {
                                list5.Add(str7);
                            }
                        }
                        list5.Sort();
                        table4.Clear();
                        table4 = this.B3TJTable(str9, "合计", dataTabeBySelRows, list5);
                        foreach (DataRow row3 in table4.Rows)
                        {
                            table.ImportRow(row3);
                        }
                        if (blnTJCun)
                        {
                            List<string> list2 = new List<string>();
                            DataTable table3 = mytjdt.Clone();
                            List<string> list = new List<string>();
                            for (int m = 0; m < dataTabeBySelRows.Rows.Count; m++)
                            {
                                string str10 = dataTabeBySelRows.Rows[m]["CUN"].ToString().Trim();
                                if (!list2.Contains(str10))
                                {
                                    list2.Add(str10);
                                }
                            }
                            list2.Sort();
                            for (int n = 0; n < list2.Count; n++)
                            {
                                table3.Clear();
                                list.Clear();
                                string str2 = list2[n].ToString();
                                table3 = this.GetDataTabeBySelRows(dataTabeBySelRows, "CUN='" + str2 + "'");
                                for (int num3 = 0; num3 < table3.Rows.Count; num3++)
                                {
                                    string str3 = table3.Rows[num3]["SQJ"].ToString().Trim();
                                    if (((str3 == "10") || (str3 == "20")) && !list.Contains(str3))
                                    {
                                        list.Add(str3);
                                    }
                                }
                                list.Sort();
                                table4.Clear();
                                table4 = this.B3TJTable(str2, "合计", table3, list);
                                foreach (DataRow row2 in table4.Rows)
                                {
                                    table.ImportRow(row2);
                                }
                            }
                        }
                    }
                }
            }
            mytjdt.Clear();
            table = this.UpdateDWTableByJoin(table);
            return this.UpdateTableZero(table, 3);
        }

        private DataTable B3TJTable(string tjdw, string hjcolname, DataTable mytjdt, List<string> DistSQJList)
        {
            DataTable table = new DataTable("ResultTable");
            table = this.B3();
            string expression = "SUM(MIAN_JI)";
            string str2 = " LZ ='111'";
            string str3 = "LZ ='112'";
            string str4 = "LZ ='113'";
            string str5 = "LZ ='114'";
            string str6 = "LZ ='115'";
            string str7 = "LZ ='116'";
            string str8 = "LZ ='117'";
            string str9 = " LZ ='121'";
            string str10 = "LZ ='122'";
            string str11 = "LZ ='123'";
            string str12 = "LZ ='124'";
            string str13 = "LZ ='125'";
            string str14 = "LZ ='126'";
            string str15 = "LZ ='127'";
            string str16 = " PTDZL ='110'";
            string str17 = " PTDZL ='200'";
            string str18 = " PTDZL ='300'";
            string str19 = " PTDZL ='400'";
            string str20 = " PTDZL ='500'";
            string str21 = " PTDZL ='600'";
            string str22 = " PTDZL ='700' ";
            string str23 = " PTDZL ='800'";
            for (int i = 0; i < DistSQJList.Count; i++)
            {
                string str25 = DistSQJList[i].ToString();
                string str24 = "SQJ='" + str25 + "' AND ";
                double num9 = 0.0;
                double num10 = 0.0;
                double num11 = 0.0;
                double num12 = 0.0;
                double num13 = 0.0;
                double num14 = 0.0;
                double num15 = 0.0;
                double num16 = 0.0;
                double num5 = 0.0;
                double num7 = 0.0;
                double num17 = 0.0;
                double num18 = 0.0;
                double num19 = 0.0;
                double num20 = 0.0;
                double num8 = 0.0;
                double num21 = 0.0;
                double num22 = 0.0;
                double num23 = 0.0;
                double num24 = 0.0;
                double num4 = 0.0;
                double num25 = 0.0;
                double num26 = 0.0;
                double num27 = 0.0;
                double num3 = 0.0;
                double num28 = 0.0;
                if (mytjdt.Select(str24 + str2).Length > 0)
                {
                    num11 = Convert.ToDouble(mytjdt.Compute(expression, str24 + str2));
                }
                if (mytjdt.Select(str24 + str3).Length > 0)
                {
                    num12 = Convert.ToDouble(mytjdt.Compute(expression, str24 + str3));
                }
                if (mytjdt.Select(str24 + str4).Length > 0)
                {
                    num13 = Convert.ToDouble(mytjdt.Compute(expression, str24 + str4));
                }
                if (mytjdt.Select(str24 + str5).Length > 0)
                {
                    num14 = Convert.ToDouble(mytjdt.Compute(expression, str24 + str5));
                }
                if (mytjdt.Select(str24 + str6).Length > 0)
                {
                    num15 = Convert.ToDouble(mytjdt.Compute(expression, str24 + str6));
                }
                if (mytjdt.Select(str24 + str7).Length > 0)
                {
                    num16 = Convert.ToDouble(mytjdt.Compute(expression, str24 + str7));
                }
                if (mytjdt.Select(str24 + str8).Length > 0)
                {
                    num5 = Convert.ToDouble(mytjdt.Compute(expression, str24 + str8));
                }
                if (mytjdt.Select(str24 + str9).Length > 0)
                {
                    num7 = Convert.ToDouble(mytjdt.Compute(expression, str24 + str9));
                }
                if (mytjdt.Select(str24 + str10).Length > 0)
                {
                    num17 = Convert.ToDouble(mytjdt.Compute(expression, str24 + str10));
                }
                if (mytjdt.Select(str24 + str11).Length > 0)
                {
                    num18 = Convert.ToDouble(mytjdt.Compute(expression, str24 + str11));
                }
                if (mytjdt.Select(str24 + str12).Length > 0)
                {
                    num19 = Convert.ToDouble(mytjdt.Compute(expression, str24 + str12));
                }
                if (mytjdt.Select(str24 + str13).Length > 0)
                {
                    num20 = Convert.ToDouble(mytjdt.Compute(expression, str24 + str13));
                }
                if (mytjdt.Select(str24 + str14).Length > 0)
                {
                    num8 = Convert.ToDouble(mytjdt.Compute(expression, str24 + str14));
                }
                if (mytjdt.Select(str24 + str15).Length > 0)
                {
                    num21 = Convert.ToDouble(mytjdt.Compute(expression, str24 + str15));
                }
                double num29 = ((((((num14 + num16) + num5) + num17) + num18) + num19) + num20) + num8;
                num10 = (((((num11 + num12) + num13) + num15) + num21) + num7) + num29;
                str24 = "SQJ='" + str25 + "' AND ";
                if (mytjdt.Select(str24 + str16).Length > 0)
                {
                    num23 = Convert.ToDouble(mytjdt.Compute(expression, str24 + str16));
                }
                if (mytjdt.Select(str24 + str17).Length > 0)
                {
                    num24 = Convert.ToDouble(mytjdt.Compute(expression, str24 + str17));
                }
                if (mytjdt.Select(str24 + str18).Length > 0)
                {
                    num4 = Convert.ToDouble(mytjdt.Compute(expression, str24 + str18));
                }
                if (mytjdt.Select(str24 + str19).Length > 0)
                {
                    num25 = Convert.ToDouble(mytjdt.Compute(expression, str24 + str19));
                }
                if (mytjdt.Select(str24 + str20).Length > 0)
                {
                    num26 = Convert.ToDouble(mytjdt.Compute(expression, str24 + str20));
                }
                if (mytjdt.Select(str24 + str21).Length > 0)
                {
                    num27 = Convert.ToDouble(mytjdt.Compute(expression, str24 + str21));
                }
                if (mytjdt.Select(str24 + str22).Length > 0)
                {
                    num3 = Convert.ToDouble(mytjdt.Compute(expression, str24 + str22));
                }
                if (mytjdt.Select(str24 + str23).Length > 0)
                {
                    num28 = Convert.ToDouble(mytjdt.Compute(expression, str24 + str23));
                }
                num22 = ((((((num23 + num24) + num4) + num25) + num26) + num27) + num3) + num28;
                num9 = Convert.ToDouble(mytjdt.Compute(expression, "SQJ='" + str25 + "'"));
                DataRow row2 = table.NewRow();
                if (str25 == "10")
                {
                    str25 = "国家级重点公益林";
                }
                else if (str25 == "20")
                {
                    str25 = "自治区级重点公益林";
                }
                row2["SQJ"] = str25;
                row2["MJHJ"] = Math.Round(num9, 1);
                row2["LZMJXJ"] = Math.Round(num10, 1);
                row2["SYHYLMJ"] = Math.Round(num11, 1);
                row2["STBCLMJ"] = Math.Round(num12, 1);
                row2["FFGSLMJ"] = Math.Round(num13, 1);
                row2["HALMJ"] = Math.Round(num15, 1);
                row2["ZRBHQLMJ"] = Math.Round(num21, 1);
                row2["GFLMJ"] = Math.Round(num7, 1);
                row2["QTFHLMJ"] = Math.Round(num5, 1);
                row2["DLMJXJ"] = Math.Round(num22, 1);
                row2["YLDMJ"] = Math.Round(num23, 1);
                row2["SHULDMJ"] = Math.Round(num24, 1);
                row2["GMLDMJ"] = Math.Round(num4, 1);
                row2["WCLLDMJ"] = Math.Round(num27, 1);
                row2["MPDMJ"] = Math.Round(num26, 1);
                row2["WLMLDMJ"] = Math.Round(num27, 1);
                row2["YILDMJ"] = Math.Round(num3, 1);
                row2["FZSCLDMJ"] = Math.Round(num28, 1);
                if (num9 > 0.0)
                {
                    table.Rows.Add(row2);
                }
            }
            if (table.Rows.Count > 0)
            {
                DataRow row = table.NewRow();
                row[0] = tjdw;
                row[1] = hjcolname;
                if (table.Rows.Count <= 0)
                {
                    return table;
                }
                for (int j = 2; j < table.Columns.Count; j++)
                {
                    row[j] = Convert.ToDouble(table.Compute("SUM(" + table.Columns[j] + ")", null).ToString());
                }
                table.Rows.InsertAt(row, 0);
            }
            return table;
        }

        private DataTable B4()
        {
            DataTable table = new DataTable("ResultTable");
            DataColumn column = new DataColumn("TJDW", typeof(string));
            table.Columns.Add(column);
            column = new DataColumn("STQW", typeof(string));
            table.Columns.Add(column);
            column = new DataColumn("QWMC", typeof(string));
            table.Columns.Add(column);
            column = new DataColumn("MJHJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("LZMJXJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("SYHYLMJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("STBCLMJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("FFGSLMJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("HALMJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("ZRBHQLMJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("GFLMJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("QTFHLMJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("DLMJXJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("YLDMJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("SHULDMJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("GMLDMJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("WCLLDMJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("MPDMJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("WLMLDMJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("YILDMJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("FZSCLDMJ", typeof(double));
            table.Columns.Add(column);
            return table;
        }

        public DataTable B4TJByXianXiangCun()
        {
            DataTable table = new DataTable("ResultTable");
            table = this.B4();
            DataTable table2 = new DataTable();
            string cmdtxt = "SELECT  LTRIM(RTRIM(SHI)) AS SHI,LTRIM(RTRIM(XIAN)) AS XIAN,LTRIM(RTRIM(STQW)) AS STQW,LTRIM(RTRIM(DI_LEI)) AS TDZL,LIN_ZHONG AS LZ,";
            cmdtxt = (cmdtxt + "SUM(MIAN_JI) AS MIAN_JI FROM " + TABLE_XBTableName + " WHERE (RTRIM(LTRIM(SEN_LIN_LB))='011') AND (RTRIM(LTRIM(SHI_QUAN_D))<'22') ") + " AND (RTRIM(LTRIM(LIN_ZHONG))<'230') AND (RTRIM(LTRIM(DI_LEI))>'109') AND (RTRIM(LTRIM(DI_LEI))<'801') AND LEN(RTRIM(LTRIM(STQW)))>0 GROUP BY SHI,XIAN, XIANG,CUN,DI_LEI,LIN_ZHONG,STQW ";
            table2 = this.GetTable(cmdtxt, TABLE_XBTableName);
            if (table2 == null)
            {
                MessageBox.Show(TABLE_XBTableName + " B4公益林按生态区位统计出错！", "信息", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return null;
            }
            if (table2.Rows.Count == 0)
            {
                return table;
            }
            table2.Columns.Add("PTDZL", typeof(string));
            table2.Columns.Add("PSTQWMC", typeof(string));
            string str14 = table2.Rows[0]["SHI"].ToString().Trim();
            List<string> list = new List<string>();
            for (int i = 0; i < table2.Rows.Count; i++)
            {
                if (table2.Rows[i]["TDZL"].ToString().Trim().Length == 0)
                {
                    table2.Rows[i]["TDZL"] = 0;
                }
                string str7 = table2.Rows[i]["TDZL"].ToString();
                switch (str7)
                {
                    case "111":
                    case "112":
                    case "120":
                    case "130":
                        table2.Rows[i]["PTDZL"] = "110";
                        break;

                    case "200":
                        table2.Rows[i]["PTDZL"] = "200";
                        break;

                    case "301":
                    case "302":
                        table2.Rows[i]["PTDZL"] = "300";
                        break;

                    case "401":
                    case "402":
                    case "403":
                    case "404":
                        table2.Rows[i]["PTDZL"] = "400";
                        break;

                    default:
                        if (str7 == "500")
                        {
                            table2.Rows[i]["PTDZL"] = "500";
                        }
                        else if (str7.Trim().IndexOf("60") > -1)
                        {
                            table2.Rows[i]["PTDZL"] = "600";
                        }
                        else if ((((str7 == "701") || (str7 == "702")) || ((str7 == "703") || (str7 == "704"))) || ((str7 == "705") || (str7 == "706")))
                        {
                            table2.Rows[i]["PTDZL"] = "700";
                        }
                        else if (str7 == "800")
                        {
                            table2.Rows[i]["PTDZL"] = "800";
                        }
                        break;
                }
                string item = table2.Rows[i]["STQW"].ToString();
                if (!list.Contains(item))
                {
                    list.Add(item);
                }
            }
            string expression = "SUM(MIAN_JI)";
            string str10 = " LZ ='111'";
            string str16 = "LZ ='112'";
            string str8 = "LZ ='113'";
            string str17 = "LZ ='114'";
            string str18 = "LZ ='115'";
            string str19 = "LZ ='116'";
            string str13 = "LZ ='117'";
            string str20 = " LZ ='121'";
            string str21 = "LZ ='122'";
            string str22 = "LZ ='123'";
            string str23 = "LZ ='124'";
            string str24 = "LZ ='125'";
            string str11 = "LZ ='126'";
            string str25 = "LZ ='127'";
            string str6 = " PTDZL ='110'";
            string str3 = " PTDZL ='200'";
            string str26 = " PTDZL ='300'";
            string str27 = " PTDZL ='400'";
            string str28 = " PTDZL ='500'";
            string str29 = " PTDZL ='600'";
            string str30 = " PTDZL ='700' ";
            string str12 = " PTDZL ='800'";
            for (int j = 0; j < list.Count; j++)
            {
                string str5 = list[j].ToString();
                string str2 = "STQW='" + str5 + "' AND ";
                double num24 = 0.0;
                double num19 = 0.0;
                double num13 = 0.0;
                double num14 = 0.0;
                double num15 = 0.0;
                double num4 = 0.0;
                double num16 = 0.0;
                double num5 = 0.0;
                double num6 = 0.0;
                double num18 = 0.0;
                double num7 = 0.0;
                double num8 = 0.0;
                double num9 = 0.0;
                double num10 = 0.0;
                double num11 = 0.0;
                double num17 = 0.0;
                double num25 = 0.0;
                double num20 = 0.0;
                double num2 = 0.0;
                double num26 = 0.0;
                double num27 = 0.0;
                double num28 = 0.0;
                double num29 = 0.0;
                double num30 = 0.0;
                double num31 = 0.0;
                if (table2.Select(str2 + str10).Length > 0)
                {
                    num13 = Convert.ToDouble(table2.Compute(expression, str2 + str10));
                }
                if (table2.Select(str2 + str16).Length > 0)
                {
                    num14 = Convert.ToDouble(table2.Compute(expression, str2 + str16));
                }
                if (table2.Select(str2 + str8).Length > 0)
                {
                    num15 = Convert.ToDouble(table2.Compute(expression, str2 + str8));
                }
                if (table2.Select(str2 + str17).Length > 0)
                {
                    num4 = Convert.ToDouble(table2.Compute(expression, str2 + str17));
                }
                if (table2.Select(str2 + str18).Length > 0)
                {
                    num16 = Convert.ToDouble(table2.Compute(expression, str2 + str18));
                }
                if (table2.Select(str2 + str19).Length > 0)
                {
                    num5 = Convert.ToDouble(table2.Compute(expression, str2 + str19));
                }
                if (table2.Select(str2 + str13).Length > 0)
                {
                    num6 = Convert.ToDouble(table2.Compute(expression, str2 + str13));
                }
                if (table2.Select(str2 + str20).Length > 0)
                {
                    num18 = Convert.ToDouble(table2.Compute(expression, str2 + str20));
                }
                if (table2.Select(str2 + str21).Length > 0)
                {
                    num7 = Convert.ToDouble(table2.Compute(expression, str2 + str21));
                }
                if (table2.Select(str2 + str22).Length > 0)
                {
                    num8 = Convert.ToDouble(table2.Compute(expression, str2 + str22));
                }
                if (table2.Select(str2 + str23).Length > 0)
                {
                    num9 = Convert.ToDouble(table2.Compute(expression, str2 + str23));
                }
                if (table2.Select(str2 + str24).Length > 0)
                {
                    num10 = Convert.ToDouble(table2.Compute(expression, str2 + str24));
                }
                if (table2.Select(str2 + str11).Length > 0)
                {
                    num11 = Convert.ToDouble(table2.Compute(expression, str2 + str11));
                }
                if (table2.Select(str2 + str25).Length > 0)
                {
                    num17 = Convert.ToDouble(table2.Compute(expression, str2 + str25));
                }
                double num12 = ((((((num4 + num5) + num6) + num7) + num8) + num9) + num10) + num11;
                num19 = (((((num13 + num14) + num15) + num16) + num17) + num18) + num12;
                str2 = "STQW='" + str5 + "' AND ";
                if (table2.Select(str2 + str6).Length > 0)
                {
                    num20 = Convert.ToDouble(table2.Compute(expression, str2 + str6));
                }
                if (table2.Select(str2 + str3).Length > 0)
                {
                    num2 = Convert.ToDouble(table2.Compute(expression, str2 + str3));
                }
                if (table2.Select(str2 + str26).Length > 0)
                {
                    num26 = Convert.ToDouble(table2.Compute(expression, str2 + str26));
                }
                if (table2.Select(str2 + str27).Length > 0)
                {
                    num27 = Convert.ToDouble(table2.Compute(expression, str2 + str27));
                }
                if (table2.Select(str2 + str28).Length > 0)
                {
                    num28 = Convert.ToDouble(table2.Compute(expression, str2 + str28));
                }
                if (table2.Select(str2 + str29).Length > 0)
                {
                    num29 = Convert.ToDouble(table2.Compute(expression, str2 + str29));
                }
                if (table2.Select(str2 + str30).Length > 0)
                {
                    num30 = Convert.ToDouble(table2.Compute(expression, str2 + str30));
                }
                if (table2.Select(str2 + str12).Length > 0)
                {
                    num31 = Convert.ToDouble(table2.Compute(expression, str2 + str12));
                }
                num25 = ((((((num20 + num2) + num26) + num27) + num28) + num29) + num30) + num31;
                num24 = Convert.ToDouble(table2.Compute(expression, "STQW='" + str5 + "'"));
                DataRow row4 = table.NewRow();
                row4["QWMC"] = str5;
                row4["MJHJ"] = Math.Round(num24, 1);
                row4["LZMJXJ"] = Math.Round(num19, 1);
                row4["SYHYLMJ"] = Math.Round(num13, 1);
                row4["STBCLMJ"] = Math.Round(num14, 1);
                row4["FFGSLMJ"] = Math.Round(num15, 1);
                row4["HALMJ"] = Math.Round(num16, 1);
                row4["ZRBHQLMJ"] = Math.Round(num17, 1);
                row4["GFLMJ"] = Math.Round(num18, 1);
                row4["QTFHLMJ"] = Math.Round(num6, 1);
                row4["DLMJXJ"] = Math.Round(num25, 1);
                row4["YLDMJ"] = Math.Round(num20, 1);
                row4["SHULDMJ"] = Math.Round(num2, 1);
                row4["GMLDMJ"] = Math.Round(num26, 1);
                row4["WCLLDMJ"] = Math.Round(num29, 1);
                row4["MPDMJ"] = Math.Round(num28, 1);
                row4["WLMLDMJ"] = Math.Round(num29, 1);
                row4["YILDMJ"] = Math.Round(num30, 1);
                row4["FZSCLDMJ"] = Math.Round(num31, 1);
                if (num24 > 0.0)
                {
                    table.Rows.Add(row4);
                }
            }
            DataTable table4 = this.GetTable("SELECT XH,DM,STQW,MC FROM T_SYS_META_GYLQW", "dt");
            table.Columns.Add("PXH", typeof(short));
            foreach (DataRow row2 in table.Rows)
            {
                DataRow[] rowArray4 = table4.Select("DM='" + row2["QWMC"].ToString() + "'");
                if (rowArray4.Length > 0)
                {
                    row2["STQW"] = rowArray4[0]["STQW"].ToString().Trim();
                    row2["QWMC"] = rowArray4[0]["MC"].ToString().Trim();
                    row2["PXH"] = rowArray4[0]["XH"];
                }
            }
            DataRow[] rowArray2 = table.Select(null, "pxh");
            DataTable resultTable = table.Clone();
            foreach (DataRow row3 in rowArray2)
            {
                resultTable.Rows.Add(row3.ItemArray);
            }
            resultTable.Columns.Remove("PXH");
            if (resultTable.Rows.Count > 0)
            {
                DataRow row = resultTable.NewRow();
                row[0] = str14;
                row[2] = "合计";
                if (resultTable.Rows.Count > 0)
                {
                    for (int k = 3; k < resultTable.Columns.Count; k++)
                    {
                        row[k] = Convert.ToDouble(resultTable.Compute("SUM(" + resultTable.Columns[k] + ")", null).ToString());
                    }
                    resultTable.Rows.InsertAt(row, 0);
                }
            }
            resultTable = this.UpdateTableZero(resultTable, 3);
            return this.UpdateDWTableByJoin(resultTable);
        }

        private DataTable B5()
        {
            DataTable table = new DataTable("ResultTable");
            DataColumn column = new DataColumn("TJDW", typeof(string));
            table.Columns.Add(column);
            column = new DataColumn("BHDJ", typeof(string));
            table.Columns.Add(column);
            column = new DataColumn("MJHJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("LZMJXJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("SYHYLMJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("STBCLMJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("FFGSLMJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("HALMJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("ZRBHQLMJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("GFLMJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("QTFHLMJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("DLMJXJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("YLDMJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("SHULDMJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("GMLDMJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("WCLLDMJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("MPDMJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("WLMLDMJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("YILDMJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("FZSCLDMJ", typeof(double));
            table.Columns.Add(column);
            return table;
        }

        public DataTable B5TJByXianXiangCun(bool blnTJCun)
        {
            DataTable table = new DataTable("ResultTable");
            table = this.B5();
            DataTable mytjdt = new DataTable();
            string cmdtxt = "SELECT LTRIM(RTRIM(SHI)) AS SHI, LTRIM(RTRIM(XIAN)) AS XIAN,LTRIM(RTRIM(XIANG)) AS XIANG,LTRIM(RTRIM(CUN)) AS CUN,LTRIM(RTRIM(GJGYL_BHDJ)) AS BHDJ,";
            cmdtxt = (cmdtxt + "LTRIM(RTRIM(DI_LEI)) AS TDZL,LIN_ZHONG AS LZ,SUM(MIAN_JI) AS MIAN_JI FROM " + TABLE_XBTableName + " WHERE  LEN(RTRIM(LTRIM(GJGYL_BHDJ)))>0 AND (RTRIM(LTRIM(SEN_LIN_LB))='011') ") + " AND (RTRIM(LTRIM(SHI_QUAN_D))>='10') AND (RTRIM(LTRIM(SHI_QUAN_D))<'22') AND (RTRIM(LTRIM(LIN_ZHONG))<'230') AND (RTRIM(LTRIM(DI_LEI))>'109') AND (RTRIM(LTRIM(DI_LEI))<'801') GROUP BY  SHI, XIAN, XIANG,CUN,DI_LEI,LIN_ZHONG,GJGYL_BHDJ ";
            mytjdt = this.GetTable(cmdtxt, TABLE_XBTableName);
            if (mytjdt == null)
            {
                MessageBox.Show(TABLE_XBTableName + " B5公益林按保护等级统计出错！", "信息", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return null;
            }
            if (mytjdt.Rows.Count == 0)
            {
                return table;
            }
            List<string> distBHDJList = new List<string>();
            List<string> list5 = new List<string>();
            mytjdt.Columns.Add("PTDZL", typeof(string));
            string tjdw = mytjdt.Rows[0]["SHI"].ToString().Trim();
            for (int i = 0; i < mytjdt.Rows.Count; i++)
            {
                string item = mytjdt.Rows[i]["BHDJ"].ToString();
                if ((item.Trim().Length > 0) && !distBHDJList.Contains(item))
                {
                    distBHDJList.Add(item);
                }
                if (mytjdt.Rows[i]["TDZL"].ToString().Trim().Length == 0)
                {
                    mytjdt.Rows[i]["TDZL"] = 0;
                }
                string str2 = mytjdt.Rows[i]["TDZL"].ToString();

                switch (str2)
                {
                    case "111":
                    case "112":
                    case "120":
                    case "130":
                        mytjdt.Rows[i]["PTDZL"] = "110";
                        break;

                    case "200":
                        mytjdt.Rows[i]["PTDZL"] = "200";
                        break;

                    case "301":
                    case "302":
                        mytjdt.Rows[i]["PTDZL"] = "300";
                        break;

                    case "401":
                    case "402":
                    case "403":
                    case "404":
                        mytjdt.Rows[i]["PTDZL"] = "400";
                        break;

                    default:
                        if (str2 == "500")
                        {
                            mytjdt.Rows[i]["PTDZL"] = "500";
                        }
                        else if (str2.Trim().IndexOf("60") > -1)
                        {
                            mytjdt.Rows[i]["PTDZL"] = "600";
                        }
                        else if ((((str2 == "701") || (str2 == "702")) || ((str2 == "703") || (str2 == "704"))) || ((str2 == "705") || (str2 == "706")))
                        {
                            mytjdt.Rows[i]["PTDZL"] = "700";
                        }
                        else if (str2 == "800")
                        {
                            mytjdt.Rows[i]["PTDZL"] = "800";
                        }
                        else if (str2 == "1410")
                        {
                            mytjdt.Rows[i]["PTDZL"] = "1410";
                        }
                        else if (str2 == "1111")
                        {
                            mytjdt.Rows[i]["PTDZL"] = "1111";
                        }
                        else if (str2 == "1320")
                        {
                            mytjdt.Rows[i]["PTDZL"] = "1320";
                        }
                        else if (str2 == "1112")
                        {
                            mytjdt.Rows[i]["PTDZL"] = "1112";
                        }
                        else if (str2 == "1200")
                        {
                            mytjdt.Rows[i]["PTDZL"] = "1200";
                        }
                        else if (str2 == "1730")
                        {
                            mytjdt.Rows[i]["PTDZL"] = "1730";
                        }
                        else if (str2 == "1710")
                        {
                            mytjdt.Rows[i]["PTDZL"] = "1710";
                        }
                        else if (str2 == "1631")
                        {
                            mytjdt.Rows[i]["PTDZL"] = "1631";
                        }
                        break;
                }
                string str8 = mytjdt.Rows[i]["XIAN"].ToString();
                if (!list5.Contains(str8))
                {
                    list5.Add(str8);
                }
            }
            distBHDJList.Sort();
            list5.Sort();
            table.Clear();
            //table.Clear();
            DataTable table4 = this.B5TJTable(tjdw, "合计", mytjdt, distBHDJList);
            foreach (DataRow row2 in table4.Rows)
            {
                table.ImportRow(row2);
            }
             DataTable dataTabeBySelRows1 = mytjdt.Clone();
            List<short> list41 = new List<short>();
            for (int l = 0; l < list5.Count; l++)
            {
                dataTabeBySelRows1.Clear();
                list41.Clear();
                string str42 = list5[l].ToString();
                dataTabeBySelRows1 = this.GetDataTabeBySelRows(mytjdt, "XIAN='" + str42 + "'");
                for (int z = 0; z < dataTabeBySelRows1.Rows.Count; z++)
                {
                    string str43 = dataTabeBySelRows1.Rows[z]["PTDZL"].ToString().Trim();
                    if (str43.Length > 0)
                    {
                        short num43 = Convert.ToInt16(str43);
                        if (!list41.Contains(num43))
                        {
                            list41.Add(num43);
                        }
                    }
                }
                table4.Clear();
                table4 = this.B1TJTable(str42, "合计", dataTabeBySelRows1, list41);
                foreach (DataRow row in table4.Rows)
                {
                    table.ImportRow(row);
                }
                if (blnTJCun)
                {
                    DataTable dataTabeBySelRows = mytjdt.Clone();
                    List<string> list4 = new List<string>();
                    List<string> list33 = new List<string>();
                    for (int m = 0; m < dataTabeBySelRows1.Rows.Count; m++)
                    {
                        string str6 = dataTabeBySelRows1.Rows[m]["XIANG"].ToString().Trim();
                        if (!list33.Contains(str6))
                        {
                            list33.Add(str6);
                        }
                    }
                    for (int j = 0; j < list33.Count; j++)
                    {
                        dataTabeBySelRows.Clear();
                        list4.Clear();
                        string str3 = list33[j].ToString();
                        dataTabeBySelRows = this.GetDataTabeBySelRows(dataTabeBySelRows1, "XIANG='" + str3 + "'");
                        for (int k = 0; k < dataTabeBySelRows.Rows.Count; k++)
                        {
                            string str5 = dataTabeBySelRows.Rows[k]["BHDJ"].ToString().Trim();
                            if ((str5.Length > 0) && !list4.Contains(str5))
                            {
                                list4.Add(str5);
                            }
                        }
                        list4.Sort();
                        table4.Clear();
                        table4 = this.B5TJTable(str3, "合计", dataTabeBySelRows, list4);
                        foreach (DataRow row3 in table4.Rows)
                        {
                            table.ImportRow(row3);
                        }
                        if (blnTJCun)
                        {
                            List<string> list3 = new List<string>();
                            DataTable table5 = mytjdt.Clone();
                            List<string> list2 = new List<string>();
                            for (int m = 0; m < dataTabeBySelRows.Rows.Count; m++)
                            {
                                string str10 = dataTabeBySelRows.Rows[m]["CUN"].ToString().Trim();
                                if (!list3.Contains(str10))
                                {
                                    list3.Add(str10);
                                }
                            }
                            list3.Sort();
                            for (int n = 0; n < list3.Count; n++)
                            {
                                table5.Clear();
                                list2.Clear();
                                string str4 = list3[n].ToString();
                                table5 = this.GetDataTabeBySelRows(dataTabeBySelRows, "CUN='" + str4 + "'");
                                for (int num5 = 0; num5 < table5.Rows.Count; num5++)
                                {
                                    string str7 = table5.Rows[num5]["BHDJ"].ToString().Trim();
                                    if ((str7.Length > 0) && !list2.Contains(str7))
                                    {
                                        list2.Add(str7);
                                    }
                                }
                                list2.Sort();
                                table4.Clear();
                                table4 = this.B5TJTable(str4, "合计", table5, list2);
                                foreach (DataRow row in table4.Rows)
                                {
                                    table.ImportRow(row);
                                }
                            }
                        }
                    }
                }
            }
            mytjdt.Clear();
            table = this.UpdateDWTableByJoin(table);
            return this.UpdateTableZero(table, 3);
        }

        private DataTable B5TJTable(string tjdw, string hjcolname, DataTable mytjdt, List<string> DistBHDJList)
        {
            DataTable table = new DataTable("ResultTable");
            table = this.B5();
            string expression = "SUM(MIAN_JI)";
            string str2 = " LZ ='111'";
            string str3 = "LZ ='112'";
            string str4 = "LZ ='113'";
            string str5 = "LZ ='114'";
            string str6 = "LZ ='115'";
            string str7 = "LZ ='116'";
            string str8 = "LZ ='117'";
            string str9 = " LZ ='121'";
            string str10 = "LZ ='122'";
            string str11 = "LZ ='123'";
            string str12 = "LZ ='124'";
            string str13 = "LZ ='125'";
            string str14 = "LZ ='126'";
            string str15 = "LZ ='127'";
            string str16 = " PTDZL ='110'";
            string str17 = " PTDZL ='200'";
            string str18 = " PTDZL ='300'";
            string str19 = " PTDZL ='400'";
            string str20 = " PTDZL ='500'";
            string str21 = " PTDZL ='600'";
            string str22 = " PTDZL ='700' ";
            string str23 = " PTDZL ='800'";
            for (int i = 0; i < DistBHDJList.Count; i++)
            {
                string str24 = DistBHDJList[i].ToString();
                string str25 = "BHDJ='" + str24 + "' AND ";
                double num12 = 0.0;
                double num11 = 0.0;
                double num15 = 0.0;
                double num16 = 0.0;
                double num17 = 0.0;
                double num18 = 0.0;
                double num19 = 0.0;
                double num13 = 0.0;
                double num20 = 0.0;
                double num21 = 0.0;
                double num22 = 0.0;
                double num23 = 0.0;
                double num24 = 0.0;
                double num25 = 0.0;
                double num26 = 0.0;
                double num27 = 0.0;
                double num28 = 0.0;
                double num3 = 0.0;
                double num4 = 0.0;
                double num5 = 0.0;
                double num6 = 0.0;
                double num7 = 0.0;
                double num8 = 0.0;
                double num9 = 0.0;
                double num10 = 0.0;
                if (mytjdt.Select(str25 + str2).Length > 0)
                {
                    num16 = Convert.ToDouble(mytjdt.Compute(expression, str25 + str2));
                }
                if (mytjdt.Select(str25 + str3).Length > 0)
                {
                    num17 = Convert.ToDouble(mytjdt.Compute(expression, str25 + str3));
                }
                if (mytjdt.Select(str25 + str4).Length > 0)
                {
                    num18 = Convert.ToDouble(mytjdt.Compute(expression, str25 + str4));
                }
                if (mytjdt.Select(str25 + str5).Length > 0)
                {
                    num19 = Convert.ToDouble(mytjdt.Compute(expression, str25 + str5));
                }
                if (mytjdt.Select(str25 + str6).Length > 0)
                {
                    num13 = Convert.ToDouble(mytjdt.Compute(expression, str25 + str6));
                }
                if (mytjdt.Select(str25 + str7).Length > 0)
                {
                    num20 = Convert.ToDouble(mytjdt.Compute(expression, str25 + str7));
                }
                if (mytjdt.Select(str25 + str8).Length > 0)
                {
                    num21 = Convert.ToDouble(mytjdt.Compute(expression, str25 + str8));
                }
                if (mytjdt.Select(str25 + str9).Length > 0)
                {
                    num22 = Convert.ToDouble(mytjdt.Compute(expression, str25 + str9));
                }
                if (mytjdt.Select(str25 + str10).Length > 0)
                {
                    num23 = Convert.ToDouble(mytjdt.Compute(expression, str25 + str10));
                }
                if (mytjdt.Select(str25 + str11).Length > 0)
                {
                    num24 = Convert.ToDouble(mytjdt.Compute(expression, str25 + str11));
                }
                if (mytjdt.Select(str25 + str12).Length > 0)
                {
                    num25 = Convert.ToDouble(mytjdt.Compute(expression, str25 + str12));
                }
                if (mytjdt.Select(str25 + str13).Length > 0)
                {
                    num26 = Convert.ToDouble(mytjdt.Compute(expression, str25 + str13));
                }
                if (mytjdt.Select(str25 + str14).Length > 0)
                {
                    num27 = Convert.ToDouble(mytjdt.Compute(expression, str25 + str14));
                }
                if (mytjdt.Select(str25 + str15).Length > 0)
                {
                    num28 = Convert.ToDouble(mytjdt.Compute(expression, str25 + str15));
                }
                double num29 = ((((((num19 + num20) + num21) + num23) + num24) + num25) + num26) + num27;
                num15 = (((((num16 + num17) + num18) + num13) + num28) + num22) + num29;
                str25 = "BHDJ='" + str24 + "' AND ";
                if (mytjdt.Select(str25 + str16).Length > 0)
                {
                    num3 = Convert.ToDouble(mytjdt.Compute(expression, str25 + str16));
                }
                if (mytjdt.Select(str25 + str17).Length > 0)
                {
                    num4 = Convert.ToDouble(mytjdt.Compute(expression, str25 + str17));
                }
                if (mytjdt.Select(str25 + str18).Length > 0)
                {
                    num5 = Convert.ToDouble(mytjdt.Compute(expression, str25 + str18));
                }
                if (mytjdt.Select(str25 + str19).Length > 0)
                {
                    num6 = Convert.ToDouble(mytjdt.Compute(expression, str25 + str19));
                }
                if (mytjdt.Select(str25 + str20).Length > 0)
                {
                    num7 = Convert.ToDouble(mytjdt.Compute(expression, str25 + str20));
                }
                if (mytjdt.Select(str25 + str21).Length > 0)
                {
                    num8 = Convert.ToDouble(mytjdt.Compute(expression, str25 + str21));
                }
                if (mytjdt.Select(str25 + str22).Length > 0)
                {
                    num9 = Convert.ToDouble(mytjdt.Compute(expression, str25 + str22));
                }
                if (mytjdt.Select(str25 + str23).Length > 0)
                {
                    num10 = Convert.ToDouble(mytjdt.Compute(expression, str25 + str23));
                }
                num11 = ((((((num3 + num4) + num5) + num6) + num7) + num8) + num9) + num10;
                num12 = Convert.ToDouble(mytjdt.Compute(expression, "BHDJ='" + str24 + "'"));
                DataRow row = table.NewRow();
                if (str24 == "1")
                {
                    str24 = "I级";
                }
                else if (str24 == "2")
                {
                    str24 = "II级";
                }
                else if (str24 == "3")
                {
                    str24 = "III级";
                }
                else if (str24 == "4")
                {
                    str24 = "IV级";
                }
                else if (str24 == "5")
                {
                    str24 = "Ⅴ级";
                }
                str24 = str24 + "保护";
                row["BHDJ"] = str24;
                row["MJHJ"] = Math.Round(num12, 1);
                row["LZMJXJ"] = Math.Round(num15, 1);
                row["SYHYLMJ"] = Math.Round(num16, 1);
                row["STBCLMJ"] = Math.Round(num17, 1);
                row["FFGSLMJ"] = Math.Round(num18, 1);
                row["HALMJ"] = Math.Round(num13, 1);
                row["ZRBHQLMJ"] = Math.Round(num28, 1);
                row["GFLMJ"] = Math.Round(num22, 1);
                row["QTFHLMJ"] = Math.Round(num21, 1);
                row["DLMJXJ"] = Math.Round(num11, 1);
                row["YLDMJ"] = Math.Round(num3, 1);
                row["SHULDMJ"] = Math.Round(num4, 1);
                row["GMLDMJ"] = Math.Round(num5, 1);
                row["WCLLDMJ"] = Math.Round(num8, 1);
                row["MPDMJ"] = Math.Round(num7, 1);
                row["WLMLDMJ"] = Math.Round(num8, 1);
                row["YILDMJ"] = Math.Round(num9, 1);
                row["FZSCLDMJ"] = Math.Round(num10, 1);
                if (num12 > 0.0)
                {
                    table.Rows.Add(row);
                }
            }
            if (table.Rows.Count > 0)
            {
                DataRow row2 = table.NewRow();
                row2[0] = tjdw;
                row2[1] = hjcolname;
                if (table.Rows.Count <= 0)
                {
                    return table;
                }
                for (int j = 2; j < table.Columns.Count; j++)
                {
                    row2[j] = Convert.ToDouble(table.Compute("SUM(" + table.Columns[j] + ")", null).ToString());
                }
                table.Rows.InsertAt(row2, 0);
            }
            return table;
        }

        private SqlConnection GetCon()
        {
            if (M_Str_ConnectionString == null)
            {
                MessageBox.Show("请先进行数据库连接！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return null;
            }
            this.M_Con = new SqlConnection(M_Str_ConnectionString);
            this.M_Con.Open();
            return this.M_Con;
        }

        private DataTable GetDataTabeBySelRows(DataTable dataTable_0, string string_0)
        {
            DataTable table = dataTable_0.Clone();
            DataRow[] rowArray = dataTable_0.Select(string_0);
            if (rowArray.Length < 0)
            {
                return null;
            }
            foreach (DataRow row in rowArray)
            {
                table.Rows.Add(row.ItemArray);
            }
            return table;
        }

        private DataTable GetTable(string cmdtxt, string tablename)
        {
            DataTable table2;
            DataTable dataTable = null;
            try
            {
                this.M_Da = new SqlDataAdapter(cmdtxt, this.GetCon());
                dataTable = new DataTable(tablename);
                this.M_Da.Fill(dataTable);
                table2 = dataTable;
            }
            catch (Exception exception)
            {
                MessageBox.Show("错误：" + exception.Message, "错误提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Hand);
                table2 = null;
            }
            finally
            {
                if ((this.GetCon() != null) && (this.GetCon().State == ConnectionState.Open))
                {
                    this.GetCon().Close();
                    this.GetCon().Dispose();
                }
            }
            return table2;
        }

        private DataTable SLLBTable()
        {
            DataTable table = new DataTable("DMTable");
            DataColumn column = new DataColumn("CCODE", typeof(string));
            table.Columns.Add(column);
            column = new DataColumn("CSNAME", typeof(string));
            table.Columns.Add(column);
            DataRow row = table.NewRow();
            row[0] = "10";
            row[1] = "公益林区";
            table.Rows.Add(row);
            row = table.NewRow();
            row[0] = "20";
            row[1] = "商品林区";
            table.Rows.Add(row);
            return table;
        }

        private DataTable UpdateDWTableByJoin(DataTable dataTable_0)
        {
            string cmdtxt = " SELECT CCODE,CNAME FROM T_SYS_META_CODE WHERE (CINDEX > '101') AND (CINDEX < '106')";
            DataTable source = this.GetTable(cmdtxt, "xcdm");
            foreach (var type in Enumerable.Join(DataTableExtensions.AsEnumerable(dataTable_0), DataTableExtensions.AsEnumerable(source), delegate (DataRow dataRow_0) {
                return DataRowExtensions.Field<string>(dataRow_0, "tjdw");
            }, delegate (DataRow dataRow_0) {
                return DataRowExtensions.Field<string>(dataRow_0, "CCODE");
            }, delegate (DataRow dataRow_0, DataRow dataRow_1) {
                return new { 
                    dt1row = dataRow_0,
                    dt2row = dataRow_1
                };
            }))
            {
                type.dt1row["tjdw"] = type.dt2row["CNAME"];
            }
            return dataTable_0;
        }

        private DataTable UpdateTableZero(DataTable ResultTable, int startcol)
        {
            for (int i = startcol; i < ResultTable.Columns.Count; i++)
            {
                for (int j = 0; j < ResultTable.Rows.Count; j++)
                {
                    string str = ResultTable.Rows[j][i].ToString().Trim();
                    if ((str.Length > 0) && (Convert.ToDouble(str) == 0.0))
                    {
                        ResultTable.Rows[j][i] = DBNull.Value;
                    }
                }
            }
            return ResultTable;
        }

        public static string M_Str_ConnectionString
        {
            get
            {
                return str_connectionstring;
            }
            set
            {
                str_connectionstring = value;
            }
        }

        public static string TABLE_XBTableName
        {
            get
            {
                return str_xbtable;
            }
            set
            {
                str_xbtable = value;
            }
        }
    }
}

