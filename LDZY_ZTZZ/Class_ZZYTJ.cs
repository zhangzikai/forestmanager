namespace LDZY_ZTZZ
{
    using Microsoft.Office.Interop.Excel;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Windows.Forms;

    /// <summary>
    /// 征占用统计的底层类：在此类中定义了对征占用查询的各种SQL语句
    /// </summary>
    internal class Class_ZZYTJ
    {
        private SqlCommand M_Com;
        private SqlConnection M_Con;
        /// <summary>
        /// 表示用于填充 System.Data.DataSet 和更新 SQL Server 数据库的一组数据命令和一个数据库连接。无法继承此类。
        /// </summary>
        private SqlDataAdapter M_Da;



        private DataSet M_Ds;
        private string myfjjl = " (LZ NOT LIKE '25%') AND ";
        private string myjjl = " (LZ LIKE '25%') AND ";
        private static string str_connectionstring;
        private static string str_xzdw_table;
        private static string str_zt_zzytable;
        private static string str_zt_zzyxmmc;
        public static string TABLE_BCFBZB = "T_SYS_META_LDZZBCBZB";

        private System.Data.DataTable B1()
        {
            System.Data.DataTable table = new System.Data.DataTable("ResultTable");
            DataColumn column = new DataColumn("TJDW", typeof(string));
            table.Columns.Add(column);
            column = new DataColumn("LDQS", typeof(string));
            table.Columns.Add(column);
            column = new DataColumn("MJHJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("XJHJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("FHLDMJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("FHLDGJMJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("FHLDCFMJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("FHLDXJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("TYLLDMJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("TYLDGJMJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("TYLDCFMJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("TYLDXJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("YCLMJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("YCLCFJDMJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("YCLXJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("JJLMJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("JJLCFJDMJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("JJLXJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("XTLMJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("XTLCFJDMJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("XTLXJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("MPDMJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("MPDXJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("QTLDMJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("QTLDXJ", typeof(double));
            table.Columns.Add(column);
            return table;
        }

        /// <summary>
        /// 表1按林地类型面积蓄积统计表 ：通过县乡村进行征占用统计
        /// </summary>
        /// <param name="ydzl"></param>
        /// <returns></returns>
        public System.Data.DataTable B1TJByXianXiangCun(string ydzl)
        {
            System.Data.DataTable table = new System.Data.DataTable("ResultTable");
            table = this.B1();
            System.Data.DataTable table2 = new System.Data.DataTable();
            string cmdtxt = "SELECT LTRIM(RTRIM(SHI)) AS SHI,LTRIM(RTRIM(XIAN)) AS XIAN,LTRIM(RTRIM(XIANG)) AS XIANG,LTRIM(RTRIM(CUN)) AS CUN,";
            string str2 = cmdtxt + "LTRIM(RTRIM(Q_LD_QS)) AS LDQS,LTRIM(RTRIM(Q_DI_LEI)) AS TDZL,LTRIM(RTRIM(LDLX)) AS LDLX,LTRIM(RTRIM(SHI_QUAN_D)) AS SQJ,";
            cmdtxt = (str2 + "SUM(MIAN_JI) AS MIAN_JI,SUM(SLXJ) AS SLXJ FROM " + TABLE_ZZYTableName + " WHERE (RTRIM(LTRIM(XMMC))='" + TABLE_ZZYXMMC + "') AND (RTRIM(LTRIM(YDZL))='" + ydzl + "')") + " GROUP BY SHI, XIAN, XIANG, CUN, Q_LD_QS, Q_DI_LEI, LDLX, SHI_QUAN_D ";
            ////string str2 = cmdtxt + "LTRIM(RTRIM(Q_LD_QS)) AS LDQS,LTRIM(RTRIM(Q_DI_LEI)) AS TDZL,LTRIM(RTRIM(LDLX)) AS LDLX,LTRIM(RTRIM(SHI_QUAN_D)) AS SQJ,";
            ////cmdtxt = (str2 + "SUM(MIAN_JI) AS MIAN_JI,SUM(SLXJ) AS SLXJ FROM " + TABLE_ZZYTableName + " WHERE (RTRIM(LTRIM(XMMC))='" + TABLE_ZZYXMMC + "') AND (RTRIM(LTRIM(YDZL))='" + ydzl + "')") + " GROUP BY SHI, XIAN, XIANG, CUN, Q_LD_QS, Q_DI_LEI, LDLX, SHI_QUAN_D ";
            table2 = this.GetTable(cmdtxt, TABLE_ZZYTableName);

            if (table2 == null)
            {
                MessageBox.Show(TABLE_ZZYTableName + " B1统计长期用地出错！", "信息", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return null;
            }
            //table2为全部数据
            if (table2.Rows.Count == 0)
            {
                return table;
            }
            List<short> list7 = new List<short>();
            List<string> list8 = new List<string>();
            new List<short>();
            for (int i = 0; i < table2.Rows.Count; i++)
            {
                string item = table2.Rows[i]["SHI"].ToString();
                if (!list8.Contains(item))
                {
                    list8.Add(item);
                }
                if (table2.Rows[i]["LDQS"].ToString().Trim().Length == 0)
                {
                    table2.Rows[i]["LDQS"] = 0;
                }
                short num47 = Convert.ToInt16(table2.Rows[i]["LDQS"].ToString());
                if (num47 >= 20)
                {
                    table2.Rows[i]["LDQS"] = "20";
                    ///可能的修改
                    ///table2.Rows[i]["LDQS"] = num47;
                    num47 = Convert.ToInt16(table2.Rows[i]["LDQS"].ToString());
                }
                if (!list7.Contains(num47))
                {
                    list7.Add(num47);
                }
            }
            //林地权属
            list7.Sort();
            //市
            list8.Sort();
            string expression = "SUM(MIAN_JI)";
            string str16 = "SUM(SLXJ)";
            string str19 = "LDLX='1'";
            string str12 = str19 + " AND SQJ='1'";
            string str20 = str19 + " AND TDZL='601'";
            string str21 = "LDLX='2'";
            string str22 = str21 + " AND SQJ='1'";
            string str23 = str21 + " AND TDZL='601'";
            string str17 = "LDLX='3'";
            string str24 = str17 + " AND TDZL='601'";
            string str15 = "LDLX='4'";
            string str25 = str15 + " AND TDZL='601'";
            string str26 = "LDLX='5'";
            string str27 = str15 + " AND TDZL='601'";
            string str4 = "LDLX='6'";
            string str8 = "LDLX='7'";
            System.Data.DataTable table7 = table2.Clone();
            List<short> list4 = new List<short>();
            List<string> list5 = new List<string>();
            System.Data.DataTable table5 = table2.Clone();
            List<short> list3 = new List<short>();
            System.Data.DataTable table9 = table.Clone();
            System.Data.DataTable table11 = table.Clone();
            for (int j = 0; j < list8.Count; j++)
            {
                short num6;
                table7.Clear();
                list4.Clear();
                string str29 = list8[j].ToString();
                foreach (DataRow row13 in table2.Select("SHI='" + str29 + "'"))
                {
                    table7.Rows.Add(row13.ItemArray);
                }
                list5.Clear();
                for (int n = 0; n < table7.Rows.Count; n++)
                {
                    if (table7.Rows[n]["LDQS"].ToString().Trim().Length == 0)
                    {
                        table7.Rows[n]["LDQS"] = 0;
                    }
                    string str30 = table7.Rows[n]["LDQS"].ToString().Trim();
                    if (str30.Length > 0)
                    {
                        short num8 = Convert.ToInt16(str30);
                        if (!list4.Contains(num8))
                        {
                            list4.Add(num8);
                        }
                    }
                    string str36 = table7.Rows[n]["XIAN"].ToString();
                    if (!list5.Contains(str36))
                    {
                        list5.Add(str36);
                    }
                }
                list4.Sort();
                list5.Sort();
                System.Data.DataTable table8 = table.Clone();
                for (int num15 = 0; num15 < list5.Count; num15++)
                {
                    table.Clear();
                    table5.Clear();
                    string str28 = list5[num15].ToString();
                    foreach (DataRow row16 in table7.Select("XIAN='" + str28 + "'"))
                    {
                        table5.Rows.Add(row16.ItemArray);
                    }
                    List<string> list2 = new List<string>();
                    for (int num4 = 0; num4 < table5.Rows.Count; num4++)
                    {
                        string str10 = table5.Rows[num4]["LDQS"].ToString().Trim();
                        if (str10.Length > 0)
                        {
                            short num13 = Convert.ToInt16(str10);
                            if (!list3.Contains(num13))
                            {
                                list3.Add(num13);
                            }
                        }
                        string str6 = table5.Rows[num4]["XIANG"].ToString();
                        if (!list2.Contains(str6))
                        {
                            list2.Add(str6);
                        }
                    }
                    list3.Sort();
                    list2.Sort();
                    System.Data.DataTable table6 = table2.Clone();
                    List<short> list9 = new List<short>();
                    System.Data.DataTable table10 = table.Clone();
                    System.Data.DataTable table3 = table.Clone();
                    List<string> list = new List<string>();
                    System.Data.DataTable table4 = table2.Clone();
                    List<short> list6 = new List<short>();
                    table.Clone();
                    System.Data.DataTable table13 = table.Clone();
                    for (int num11 = 0; num11 < list2.Count; num11++)
                    {
                        string str9 = list2[num11].ToString();
                        table3.Clear();
                        DataRow[] rowArray2 = table2.Select("XIANG='" + str9 + "'");
                        table6.Clear();
                        foreach (DataRow row7 in rowArray2)
                        {
                            table6.Rows.Add(row7.ItemArray);
                        }
                        list9.Clear();
                        for (int num19 = 0; num19 < table6.Rows.Count; num19++)
                        {
                            string str14 = table6.Rows[num19]["CUN"].ToString();
                            if (!list.Contains(str14))
                            {
                                list.Add(str14);
                            }
                            string str37 = table6.Rows[num19]["LDQS"].ToString().Trim();
                            if (str37.Length > 0)
                            {
                                short num48 = Convert.ToInt16(str37);
                                if (!list9.Contains(num48))
                                {
                                    list9.Add(num48);
                                }
                            }
                        }
                        list.Sort();
                        list9.Sort();
                        for (int num = 0; num < list.Count; num++)
                        {
                            table10.Clear();
                            string str13 = list[num].ToString();
                            DataRow[] rowArray6 = table6.Select("CUN='" + str13 + "'");
                            table4.Clear();
                            foreach (DataRow row5 in rowArray6)
                            {
                                table4.Rows.Add(row5.ItemArray);
                            }
                            list6.Clear();
                            for (int num23 = 0; num23 < table4.Rows.Count; num23++)
                            {
                                string s = table4.Rows[num23]["LDQS"].ToString().Trim();
                                if ((s.Length > 0) && (short.Parse(s) >= 0))
                                {
                                    short num22 = Convert.ToInt16(s);
                                    if (!list6.Contains(num22))
                                    {
                                        list6.Add(num22);
                                    }
                                }
                            }
                            list6.Sort();
                            table10.Clear();
                            System.Data.DataTable table12 = table.Clone();
                            for (int num24 = 0; num24 < list6.Count; num24++)
                            {
                                num6 = list6[num24];
                                string str32 = num6.ToString();
                                string str3 = "LDQS='" + str32 + "' AND ";
                                double num43 = 0.0;
                                double num44 = 0.0;
                                double num45 = 0.0;
                                double num18 = 0.0;
                                double num46 = 0.0;
                                double num30 = 0.0;
                                if (table4.Select(str3 + str19).Length > 0)
                                {
                                    if ((table4.Compute(expression, str3 + str19) == DBNull.Value))
                                    {
                                        num45 = Convert.ToDouble(0);
                                    }
                                    else
                                        num45 = Convert.ToDouble(table4.Compute(expression, str3 + str19));
                                }
                                if (table4.Select(str3 + str19).Length > 0)
                                {
                                    if ((table4.Compute(str16, str3 + str19) == DBNull.Value))
                                    {
                                        num30 = Convert.ToDouble(0);
                                    }
                                    else
                                        num30 = Convert.ToDouble(table4.Compute(str16, str3 + str19));
                                }
                                if (table4.Select(str3 + str12).Length > 0)
                                {
                                    if ((table4.Compute(expression, str3 + str12) == DBNull.Value))
                                    {
                                        num18 = Convert.ToDouble(0);
                                    }
                                    else
                                        num18 = Convert.ToDouble(table4.Compute(expression, str3 + str12));
                                }
                                if (table4.Select(str3 + str20).Length > 0)
                                {
                                    if ((table4.Compute(expression, str3 + str20) == DBNull.Value))
                                    {
                                        num46 = Convert.ToDouble(0);
                                    }
                                    else
                                        num46 = Convert.ToDouble(table4.Compute(expression, str3 + str20));
                                }
                                double num37 = 0.0;
                                double num38 = 0.0;
                                double num39 = 0.0;
                                double num31 = 0.0;
                                if (table4.Select(str3 + str21).Length > 0)
                                {
                                    if ((table4.Compute(expression, str3 + str21) == DBNull.Value))
                                    {
                                        num37 = Convert.ToDouble(0);
                                    }
                                    else
                                        num37 = Convert.ToDouble(table4.Compute(expression, str3 + str21));
                                }
                                if (table4.Select(str3 + str21).Length > 0)
                                {
                                    if ((table4.Compute(str16, str3 + str21) == DBNull.Value))
                                    {
                                        num31 = Convert.ToDouble(0);
                                    }
                                    else
                                        num31 = Convert.ToDouble(table4.Compute(str16, str3 + str21));
                                }
                                if (table4.Select(str3 + str22).Length > 0)
                                {
                                    if ((table4.Compute(expression, str3 + str22) == DBNull.Value))
                                    {
                                        num38 = Convert.ToDouble(0);
                                    }
                                    else
                                        num38 = Convert.ToDouble(table4.Compute(expression, str3 + str22));
                                }
                                if (table4.Select(str3 + str20).Length > 0)
                                {
                                    Object a = table4.Compute(expression, str3 + str23);
                                    if (a == DBNull.Value)
                                    {
                                        num39 = Convert.ToDouble(0);
                                    }
                                    else
                                        num39 = Convert.ToDouble(table4.Compute(expression, str3 + str23));
                                }
                                double num35 = 0.0;
                                double num36 = 0.0;
                                double num21 = 0.0;
                                if (table4.Select(str3 + str17).Length > 0)
                                {
                                    if ((table4.Compute(expression, str3 + str17) == DBNull.Value))
                                    {
                                        num35 = Convert.ToDouble(0);
                                    }
                                    else
                                        num35 = Convert.ToDouble(table4.Compute(expression, str3 + str17));
                                }
                                if (table4.Select(str3 + str17).Length > 0)
                                {
                                    if ((table4.Compute(str16, str3 + str17) == DBNull.Value))
                                    {
                                        num21 = Convert.ToDouble(0);
                                    }
                                    else
                                        num21 = Convert.ToDouble(table4.Compute(str16, str3 + str17));
                                }
                                if (table4.Select(str3 + str24).Length > 0)
                                {
                                    if ((table4.Compute(expression, str3 + str24) == DBNull.Value))
                                    {
                                        num36 = Convert.ToDouble(0);
                                    }
                                    else
                                        num36 = Convert.ToDouble(table4.Compute(expression, str3 + str24));
                                }
                                double num53 = 0.0;
                                double num49 = 0.0;
                                double num20 = 0.0;
                                if (table4.Select(str3 + str15).Length > 0)
                                {
                                    if ((table4.Compute(expression, str3 + str15) == DBNull.Value))
                                    {
                                        num53 = Convert.ToDouble(0);
                                    }
                                    else
                                        num53 = Convert.ToDouble(table4.Compute(expression, str3 + str15));
                                }
                                if (table4.Select(str3 + str15).Length > 0)
                                {
                                    if ((table4.Compute(str16, str3 + str15) == DBNull.Value))
                                    {
                                        num20 = Convert.ToDouble(0);
                                    }
                                    else
                                        num20 = Convert.ToDouble(table4.Compute(str16, str3 + str15));
                                }
                                if (table4.Select(str3 + str25).Length > 0)
                                {
                                    if ((table4.Compute(expression, str3 + str25) == DBNull.Value))
                                    {
                                        num49 = Convert.ToDouble(0);
                                    }
                                    else
                                        num49 = Convert.ToDouble(table4.Compute(expression, str3 + str25));
                                }
                                double num41 = 0.0;
                                double num42 = 0.0;
                                double num28 = 0.0;
                                if (table4.Select(str3 + str26).Length > 0)
                                {
                                    if ((table4.Compute(expression, str3 + str26) == DBNull.Value))
                                    {
                                        num41 = Convert.ToDouble(0);
                                    }
                                    else
                                        num41 = Convert.ToDouble(table4.Compute(expression, str3 + str26));
                                }
                                if (table4.Select(str3 + str26).Length > 0)
                                {
                                    if ((table4.Compute(str16, str3 + str26) == DBNull.Value))
                                    {
                                        num28 = Convert.ToDouble(0);
                                    }
                                    else
                                        num28 = Convert.ToDouble(table4.Compute(str16, str3 + str26));
                                }
                                ///奇怪：这里当执行第二次的时候莫名退出。原因未知。
                                ///因此这里只能它执行了一次
                                if (table4.Select(str3 + str24).Length > 0)
                                {

                                    Object a = table4.Compute(expression, str3 + str27);
                                    if (a == DBNull.Value)
                                    {
                                        num42 = Convert.ToDouble(0);
                                    }
                                    else
                                    {
                                        num42 = Convert.ToDouble(a);
                                    }

                                }
                                double num2 = 0.0;
                                double num3 = 0.0;
                                if (table4.Select(str3 + str4).Length > 0)
                                {
                                    if ((table4.Compute(expression, str3 + str4) == DBNull.Value))
                                    {
                                        num2 = Convert.ToDouble(0);
                                    }
                                    else
                                        num2 = Convert.ToDouble(table4.Compute(expression, str3 + str4));
                                }
                                if (table4.Select(str3 + str4).Length > 0)
                                {
                                    if ((table4.Compute(str16, str3 + str4) == DBNull.Value))
                                    {
                                        num3 = Convert.ToDouble(0);
                                    }
                                    else
                                        num3 = Convert.ToDouble(table4.Compute(str16, str3 + str4));
                                }
                                double num9 = 0.0;
                                double num10 = 0.0;
                                if (table4.Select(str3 + str8).Length > 0)
                                {
                                    if ((table4.Compute(expression, str3 + str8) == DBNull.Value))
                                    {
                                        num9 = Convert.ToDouble(0);
                                    }
                                    else
                                        num9 = Convert.ToDouble(table4.Compute(expression, str3 + str8));
                                }
                                if (table4.Select(str3 + str8).Length > 0)
                                {
                                    if ((table4.Compute(str16, str3 + str8) == DBNull.Value))
                                    {
                                        num10 = Convert.ToDouble(0);
                                    }
                                    else
                                        num10 = Convert.ToDouble(table4.Compute(str16, str3 + str8));
                                }
                                num43 = (((((num45 + num37) + num35) + num53) + num41) + num2) + num9;
                                num44 = (((((num30 + num31) + num21) + num20) + num28) + num3) + num10;
                                DataRow row15 = table10.NewRow();
                                row15["LDQS"] = str32;
                                row15["MJHJ"] = num43;
                                row15["XJHJ"] = num44;
                                row15["FHLDMJ"] = num45;
                                row15["FHLDGJMJ"] = num18;
                                row15["FHLDCFMJ"] = num46;
                                row15["FHLDXJ"] = num30;
                                row15["TYLLDMJ"] = num37;
                                row15["TYLDGJMJ"] = num38;
                                row15["TYLDCFMJ"] = num39;
                                row15["TYLDXJ"] = num31;
                                row15["YCLMJ"] = num35;
                                row15["YCLCFJDMJ"] = num36;
                                row15["YCLXJ"] = num21;
                                row15["JJLMJ"] = num53;
                                row15["JJLCFJDMJ"] = num49;
                                row15["JJLXJ"] = num20;
                                row15["XTLMJ"] = num41;
                                row15["XTLCFJDMJ"] = num42;
                                row15["XTLXJ"] = num28;
                                row15["MPDMJ"] = num2;
                                row15["MPDXJ"] = num3;
                                row15["QTLDMJ"] = num9;
                                row15["QTLDXJ"] = num10;
                                if ((num43 > 0.0) || (num44 > 0.0))
                                {
                                    table10.Rows.Add(row15);
                                    table12.Rows.Add(row15.ItemArray);
                                }
                            }
                            if (table10.Rows.Count > 0)
                            {
                                DataRow row4 = table10.NewRow();
                                row4[0] = str13;
                                row4[1] = "小计";
                                if (table10.Rows.Count > 0)
                                {
                                    for (int num33 = 2; num33 < table10.Columns.Count; num33++)
                                    {
                                        if (table12.Compute("SUM(" + table10.Columns[num33] + ")", null) == DBNull.Value)
                                        {
                                            row4[num33] = 0;
                                        }
                                        else
                                            row4[num33] = Convert.ToDouble(table12.Compute("SUM(" + table10.Columns[num33] + ")", null));
                                    }
                                    table10.Rows.InsertAt(row4, 0);
                                }
                            }
                            foreach (DataRow row2 in table10.Rows)
                            {
                                table3.ImportRow(row2);
                            }
                        }
                        if (table3.Rows.Count > 0)
                        {
                            DataRow row10 = table3.NewRow();
                            row10[0] = str9.Trim();
                            row10[1] = "小计";
                            System.Data.DataTable table14 = table10.Clone();
                            for (int num27 = list9.Count; num27 > 0; num27--)
                            {
                                num6 = list9[num27 - 1];
                                string str33 = num6.ToString();
                                DataRow row8 = table3.NewRow();
                                row8[1] = str33;
                                if (table3.Select("LDQS='" + str33 + "'").Length > 0)
                                {
                                    for (int num34 = 2; num34 < table.Columns.Count; num34++)
                                    {
                                        if (table3.Compute("SUM(" + table3.Columns[num34] + ")", "LDQS='" + str33 + "'") == DBNull.Value)
                                        {
                                            row8[num34] = 0;
                                        }
                                        else
                                            row8[num34] = Convert.ToDouble(table3.Compute("SUM(" + table3.Columns[num34] + ")", "LDQS='" + str33 + "'"));
                                    }
                                    table3.Rows.InsertAt(row8, 0);
                                    table14.Rows.Add(row8.ItemArray);
                                    table13.Rows.Add(row8.ItemArray);
                                }
                            }
                            for (int num29 = 2; num29 < table10.Columns.Count; num29++)
                            {
                                if ((table14.Compute("SUM(" + table14.Columns[num29] + ")", null)) == DBNull.Value)
                                {
                                    row10[num29] = 0;
                                }
                                else
                                    row10[num29] = Convert.ToDouble(table14.Compute("SUM(" + table14.Columns[num29] + ")", null));
                            }
                            table3.Rows.InsertAt(row10, 0);
                            foreach (DataRow row17 in table3.Rows)
                            {
                                table.ImportRow(row17);
                            }
                        }
                    }
                    for (int num5 = list3.Count; num5 > 0; num5--)
                    {
                        num6 = list3[num5 - 1];
                        string str7 = num6.ToString();
                        DataRow row = table.NewRow();
                        row[1] = str7;
                        for (int num7 = 2; num7 < table.Columns.Count; num7++)
                        {
                            if ((table13.Compute("SUM(" + table13.Columns[num7] + ")", "LDQS='" + str7 + "'")) == DBNull.Value)
                            {
                                row[num7] = 0;
                            }
                            else
                                row[num7] = Convert.ToDouble(table13.Compute("SUM(" + table13.Columns[num7] + ")", "LDQS='" + str7 + "'"));
                        }
                        table.Rows.InsertAt(row, 0);
                        table8.Rows.Add(row.ItemArray);
                        table11.Rows.Add(row.ItemArray);
                    }
                    DataRow row9 = table.NewRow();
                    row9[0] = str28;
                    row9[1] = "合计";
                    for (int num40 = 2; num40 < table.Columns.Count; num40++)
                    {
                        if (table13.Compute("SUM(" + table13.Columns[num40] + ")", null) == DBNull.Value)
                        {
                            row9[num40] = 0;
                        }
                        else
                            row9[num40] = Convert.ToDouble(table13.Compute("SUM(" + table13.Columns[num40] + ")", null));
                    }
                    table.Rows.InsertAt(row9, 0);
                    foreach (DataRow row14 in table.Rows)
                    {
                        table9.ImportRow(row14);
                    }
                }
                for (int num16 = list4.Count; num16 > 0; num16--)
                {
                    num6 = list4[num16 - 1];
                    string str11 = num6.ToString();
                    DataRow row3 = table9.NewRow();
                    row3[1] = str11;
                    for (int num17 = 2; num17 < table.Columns.Count; num17++)
                    {
                        if (table8.Compute("SUM(" + table8.Columns[num17] + ")", "LDQS='" + str11 + "'") == DBNull.Value)
                        {
                            row3[num17] = 0;
                        }
                        else
                            row3[num17] = Convert.ToDouble(table8.Compute("SUM(" + table8.Columns[num17] + ")", "LDQS='" + str11 + "'"));
                    }
                    table9.Rows.InsertAt(row3, 0);
                }
                DataRow row6 = table9.NewRow();
                row6[0] = str29;
                row6[1] = "合计";
                for (int num32 = 2; num32 < table.Columns.Count; num32++)
                {
                    if (table8.Compute("SUM(" + table8.Columns[num32] + ")", null) == DBNull.Value)
                    {
                        row6[num32] = 0;
                    }
                    else
                        row6[num32] = Convert.ToDouble(table8.Compute("SUM(" + table8.Columns[num32] + ")", null));
                }
                table9.Rows.InsertAt(row6, 0);
            }
            table7.Clear();
            table5.Clear();
            for (int k = list7.Count; k > 0; k--)
            {
                string str35 = list4[k - 1].ToString();
                DataRow row12 = table9.NewRow();
                row12[1] = str35;
                for (int num52 = 2; num52 < table.Columns.Count; num52++)
                {
                    if (table11.Compute("SUM(" + table11.Columns[num52] + ")", "LDQS='" + str35 + "'") == DBNull.Value)
                    {
                        row12[num52] = 0;
                    }
                    else
                        row12[num52] = Convert.ToDouble(table11.Compute("SUM(" + table11.Columns[num52] + ")", "LDQS='" + str35 + "'"));
                }
                table9.Rows.InsertAt(row12, 0);
            }
            DataRow row11 = table9.NewRow();
            row11[0] = "项目区";
            row11[1] = "合计";
            for (int m = 2; m < table.Columns.Count; m++)
            {
                if (table11.Compute("SUM(" + table11.Columns[m] + ")", null) == DBNull.Value)
                {
                    row11[m] = 0;
                }
                else
                    row11[m] = Convert.ToDouble(table11.Compute("SUM(" + table11.Columns[m] + ")", null));
            }
            table9.Rows.InsertAt(row11, 0);
            table9 = this.UpdateDWTableByJoin(table9);
            return this.UpdateTableLDQSByJoin(table9, " CINDEX='207'", "LDQS");
        }

        private System.Data.DataTable B2()
        {
            System.Data.DataTable table = new System.Data.DataTable("ResultTable");
            DataColumn column = new DataColumn("TJDW", typeof(string));
            table.Columns.Add(column);
            column = new DataColumn("LDQS", typeof(string));
            table.Columns.Add(column);
            column = new DataColumn("LDMJHJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("SLMJXJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("QMLMJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("HSLMJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("ZHULINMJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("SHULDMJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("GMLDMJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("WCLLDMJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("MPDMJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("WLMLDXJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("CFJDMJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("HSJDMJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("QTWLMMJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("YLDXJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("YLHSMJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("YLSHMJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("YLQTMJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("FZSCLDMJ", typeof(double));
            table.Columns.Add(column);
            return table;
        }

        public System.Data.DataTable B2TJByXianXiangCun(string ydzl)
        {
            System.Data.DataTable table = new System.Data.DataTable("ResultTable");
            table = this.B2();
            System.Data.DataTable table2 = new System.Data.DataTable();
            string cmdtxt = "SELECT LTRIM(RTRIM(SHI)) AS SHI,LTRIM(RTRIM(XIAN)) AS XIAN,LTRIM(RTRIM(XIANG)) AS XIANG,LTRIM(RTRIM(CUN)) AS CUN,";
            string str2 = cmdtxt + "LTRIM(RTRIM(Q_LD_QS)) AS LDQS,LTRIM(RTRIM(Q_DI_LEI)) AS TDZL,SUM(MIAN_JI) AS MIAN_JI  FROM " + TABLE_ZZYTableName;
            cmdtxt = (str2 + "  WHERE (RTRIM(LTRIM(XMMC))='" + TABLE_ZZYXMMC + "') AND (RTRIM(LTRIM(YDZL))='" + ydzl + "')") + " GROUP BY SHI, XIAN, XIANG,CUN, Q_LD_QS, Q_DI_LEI  ";
            table2 = this.GetTable(cmdtxt, TABLE_ZZYTableName);
            if (table2 == null)
            {
                MessageBox.Show(TABLE_ZZYTableName + " B2统计长期用地出错！", "信息", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return null;
            }
            if (table2.Rows.Count == 0)
            {
                return table;
            }
            List<short> list7 = new List<short>();
            List<string> list8 = new List<string>();
            new List<short>();
            for (int i = 0; i < table2.Rows.Count; i++)
            {
                string item = table2.Rows[i]["SHI"].ToString();
                if (!list8.Contains(item))
                {
                    list8.Add(item);
                }
                if (table2.Rows[i]["LDQS"].ToString().Trim().Length == 0)
                {
                    table2.Rows[i]["LDQS"] = 0;
                }
                short num50 = Convert.ToInt16(table2.Rows[i]["LDQS"].ToString());
                if (num50 >= 20)
                {
                    table2.Rows[i]["LDQS"] = "20";
                    num50 = Convert.ToInt16(table2.Rows[i]["LDQS"].ToString());
                }
                if (!list7.Contains(num50))
                {
                    list7.Add(num50);
                }
            }
            list7.Sort();
            list8.Sort();
            string expression = "SUM(MIAN_JI)";
            string str29 = " TDZL ='111'";
            string str11 = " TDZL ='112'";
            string str34 = " TDZL ='120'";
            string str33 = " TDZL ='130'";
            string str22 = " TDZL ='200'";
            string str23 = " TDZL ='301'";
            string str36 = " TDZL ='302'";
            string str27 = " TDZL LIKE '40%'";
            string str16 = " TDZL ='500'";
            string str35 = " TDZL ='601'";
            string str37 = " TDZL ='602'";
            string str15 = " TDZL LIKE '603%'";
            string str26 = " TDZL ='701'";
            string str28 = " TDZL ='702'";
            string str20 = " TDZL >='703' AND  TDZL <='706'";
            string str38 = " TDZL ='800'";
            System.Data.DataTable table12 = table2.Clone();
            List<short> list3 = new List<short>();
            List<string> list6 = new List<string>();
            System.Data.DataTable table5 = table2.Clone();
            List<short> list4 = new List<short>();
            System.Data.DataTable table10 = table.Clone();
            System.Data.DataTable table14 = table.Clone();
            for (int j = 0; j < list8.Count; j++)
            {
                short num27;
                table12.Clear();
                list3.Clear();
                string str9 = list8[j].ToString();
                foreach (DataRow row16 in table2.Select("SHI='" + str9 + "'"))
                {
                    table12.Rows.Add(row16.ItemArray);
                }
                list6.Clear();
                for (int k = 0; k < table12.Rows.Count; k++)
                {
                    string str24 = table12.Rows[k]["LDQS"].ToString().Trim();
                    if (str24.Length > 0)
                    {
                        short num45 = Convert.ToInt16(str24);
                        if (!list3.Contains(num45))
                        {
                            list3.Add(num45);
                        }
                    }
                    string str21 = table12.Rows[k]["XIAN"].ToString();
                    if (!list6.Contains(str21))
                    {
                        list6.Add(str21);
                    }
                }
                list3.Sort();
                list6.Sort();
                System.Data.DataTable table8 = table.Clone();
                for (int m = 0; m < list6.Count; m++)
                {
                    table.Clear();
                    table5.Clear();
                    string str19 = list6[m].ToString();
                    foreach (DataRow row17 in table12.Select("XIAN='" + str19 + "'"))
                    {
                        table5.Rows.Add(row17.ItemArray);
                    }
                    List<string> list = new List<string>();
                    for (int n = 0; n < table5.Rows.Count; n++)
                    {
                        string str8 = table5.Rows[n]["LDQS"].ToString().Trim();
                        if (str8.Length > 0)
                        {
                            short num31 = Convert.ToInt16(str8);
                            if (!list4.Contains(num31))
                            {
                                list4.Add(num31);
                            }
                        }
                        string str4 = table5.Rows[n]["XIANG"].ToString();
                        if (!list.Contains(str4))
                        {
                            list.Add(str4);
                        }
                    }
                    list4.Sort();
                    list.Sort();
                    System.Data.DataTable table9 = table2.Clone();
                    List<short> list9 = new List<short>();
                    System.Data.DataTable table3 = table.Clone();
                    System.Data.DataTable table7 = table.Clone();
                    List<string> list5 = new List<string>();
                    System.Data.DataTable table11 = table2.Clone();
                    List<short> list2 = new List<short>();
                    table.Clone();
                    System.Data.DataTable table6 = table.Clone();
                    for (int num24 = 0; num24 < list.Count; num24++)
                    {
                        string str6 = list[num24].ToString();
                        table7.Clear();
                        DataRow[] rowArray = table2.Select("XIANG='" + str6 + "'");
                        table9.Clear();
                        foreach (DataRow row11 in rowArray)
                        {
                            table9.Rows.Add(row11.ItemArray);
                        }
                        list9.Clear();
                        for (int num34 = 0; num34 < table9.Rows.Count; num34++)
                        {
                            string str14 = table9.Rows[num34]["CUN"].ToString();
                            if (!list5.Contains(str14))
                            {
                                list5.Add(str14);
                            }
                            string str31 = table9.Rows[num34]["LDQS"].ToString().Trim();
                            if (str31.Length > 0)
                            {
                                short num51 = Convert.ToInt16(str31);
                                if (!list9.Contains(num51))
                                {
                                    list9.Add(num51);
                                }
                            }
                        }
                        list5.Sort();
                        list9.Sort();
                        for (int num33 = 0; num33 < list5.Count; num33++)
                        {
                            table3.Clear();
                            string str13 = list5[num33].ToString();
                            DataRow[] rowArray4 = table9.Select("CUN='" + str13 + "'");
                            table11.Clear();
                            foreach (DataRow row13 in rowArray4)
                            {
                                table11.Rows.Add(row13.ItemArray);
                            }
                            list2.Clear();
                            for (int num35 = 0; num35 < table11.Rows.Count; num35++)
                            {
                                string s = table11.Rows[num35]["LDQS"].ToString().Trim();
                                if ((s.Length > 0) && (short.Parse(s) >= 0))
                                {
                                    short num42 = Convert.ToInt16(s);
                                    if (!list2.Contains(num42))
                                    {
                                        list2.Add(num42);
                                    }
                                }
                            }
                            list2.Sort();
                            table3.Clear();
                            System.Data.DataTable table4 = table.Clone();
                            for (int num23 = 0; num23 < list2.Count; num23++)
                            {
                                num27 = list2[num23];
                                string str3 = num27.ToString();
                                string str10 = "LDQS='" + str3 + "' AND ";
                                double num8 = 0.0;
                                double num9 = 0.0;
                                double num48 = 0.0;
                                double num32 = 0.0;
                                if (table11.Select(str10 + str29).Length > 0)
                                {
                                    if (table11.Compute(expression, str10 + str29) == DBNull.Value)
                                    {
                                        num48 = Convert.ToDouble(0);
                                    }
                                    else
                                        num48 = Convert.ToDouble(table11.Compute(expression, str10 + str29));
                                }
                                if (table11.Select(str10 + str11).Length > 0)
                                {
                                    if (table11.Compute(expression, str10 + str11) == DBNull.Value)
                                    {
                                        num32 = Convert.ToDouble(0);
                                    }
                                    else
                                        num32 = Convert.ToDouble(table11.Compute(expression, str10 + str11));
                                }
                                num9 = num48 + num32;
                                double num10 = 0.0;
                                if (table11.Select(str10 + str34).Length > 0)
                                {
                                    if (table11.Compute(expression, str10 + str34) == DBNull.Value)
                                    {
                                        num10 = Convert.ToDouble(0);
                                    }
                                    else
                                        num10 = Convert.ToDouble(table11.Compute(expression, str10 + str34));
                                }
                                double num11 = 0.0;
                                if (table11.Select(str10 + str33).Length > 0)
                                {
                                    if (table11.Compute(expression, str10 + str33) == DBNull.Value)
                                    {
                                        num11 = Convert.ToDouble(0);
                                    }
                                    else
                                        num11 = Convert.ToDouble(table11.Compute(expression, str10 + str33));
                                }
                                double num = (num9 + num10) + num11;
                                double num2 = 0.0;
                                if (table11.Select(str10 + str22).Length > 0)
                                {
                                    if (table11.Compute(expression, str10 + str22) == DBNull.Value)
                                    {
                                        num2 = Convert.ToDouble(0);
                                    }
                                    else
                                        num2 = Convert.ToDouble(table11.Compute(expression, str10 + str22));
                                }
                                double num3 = 0.0;
                                double num43 = 0.0;
                                if (table11.Select(str10 + str23).Length > 0)
                                {
                                    if (table11.Compute(expression, str10 + str23) == DBNull.Value)
                                    {
                                        num43 = Convert.ToDouble(0);
                                    }
                                    else
                                        num43 = Convert.ToDouble(table11.Compute(expression, str10 + str23));
                                }
                                double num47 = 0.0;
                                if (table11.Select(str10 + str36).Length > 0)
                                {
                                    if (table11.Compute(expression, str10 + str36) == DBNull.Value)
                                    {
                                        num47 = Convert.ToDouble(0);
                                    }
                                    else
                                        num47 = Convert.ToDouble(table11.Compute(expression, str10 + str36));
                                }
                                num3 = num43 + num47;
                                double num12 = 0.0;
                                if (table11.Select(str10 + str27).Length > 0)
                                {
                                    if (table11.Compute(expression, str10 + str27) == DBNull.Value)
                                    {
                                        num12 = Convert.ToDouble(0);
                                    }
                                    else
                                        num12 = Convert.ToDouble(table11.Compute(expression, str10 + str27));
                                }
                                double num4 = 0.0;
                                if (table11.Select(str10 + str16).Length > 0)
                                {
                                    if (table11.Compute(expression, str10 + str16) == DBNull.Value)
                                    {
                                        num4 = Convert.ToDouble(0);
                                    }
                                    else
                                        num4 = Convert.ToDouble(table11.Compute(expression, str10 + str16));
                                }
                                double num5 = 0.0;
                                double num13 = 0.0;
                                double num14 = 0.0;
                                double num15 = 0.0;
                                if (table11.Select(str10 + str35).Length > 0)
                                {
                                    if (table11.Compute(expression, str10 + str35) == DBNull.Value)
                                    {
                                        num13 = Convert.ToDouble(0);
                                    }
                                    else
                                        num13 = Convert.ToDouble(table11.Compute(expression, str10 + str35));
                                }
                                if (table11.Select(str10 + str37).Length > 0)
                                {
                                    if (table11.Compute(expression, str10 + str37) == DBNull.Value)
                                    {
                                        num14 = Convert.ToDouble(0);
                                    }
                                    else
                                        num14 = Convert.ToDouble(table11.Compute(expression, str10 + str37));
                                }
                                if (table11.Select(str10 + str15).Length > 0)
                                {
                                    if (table11.Compute(expression, str10 + str15) == DBNull.Value)
                                    {
                                        num15 = Convert.ToDouble(0);
                                    }
                                    else
                                        num15 = Convert.ToDouble(table11.Compute(expression, str10 + str15));
                                }
                                num5 = (num13 + num14) + num15;
                                double num6 = 0.0;
                                double num16 = 0.0;
                                double num17 = 0.0;
                                double num18 = 0.0;
                                if (table11.Select(str10 + str26).Length > 0)
                                {
                                    if (table11.Compute(expression, str10 + str26) == DBNull.Value)
                                    {
                                        num16 = Convert.ToDouble(0);
                                    }
                                    else
                                        num16 = Convert.ToDouble(table11.Compute(expression, str10 + str26));
                                }
                                if (table11.Select(str10 + str28).Length > 0)
                                {
                                    if (table11.Compute(expression, str10 + str28) == DBNull.Value)
                                    {
                                        num17 = Convert.ToDouble(0);
                                    }
                                    else
                                        num17 = Convert.ToDouble(table11.Compute(expression, str10 + str28));
                                }
                                if (table11.Select(str10 + str20).Length > 0)
                                {
                                    if (table11.Compute(expression, str10 + str20) == DBNull.Value)
                                    {
                                        num18 = Convert.ToDouble(0);
                                    }
                                    else
                                        num18 = Convert.ToDouble(table11.Compute(expression, str10 + str20));
                                }
                                num6 = (num16 + num17) + num18;
                                double num7 = 0.0;
                                if (table11.Select(str10 + str38).Length > 0)
                                {
                                    if (table11.Compute(expression, str10 + str38) == DBNull.Value)
                                    {
                                        num7 = Convert.ToDouble(0);
                                    }
                                    else
                                        num7 = Convert.ToDouble(table11.Compute(expression, str10 + str38));
                                }
                                num8 = (((((num + num2) + num3) + num4) + num5) + num6) + num7;
                                DataRow row = table3.NewRow();
                                row["LDQS"] = str3;
                                row["LDMJHJ"] = num8;
                                row["SLMJXJ"] = num;
                                row["QMLMJ"] = num9;
                                row["HSLMJ"] = num10;
                                row["ZHULINMJ"] = num11;
                                row["SHULDMJ"] = num2;
                                row["GMLDMJ"] = num3;
                                row["WCLLDMJ"] = num12;
                                row["MPDMJ"] = num4;
                                row["WLMLDXJ"] = num5;
                                row["CFJDMJ"] = num13;
                                row["HSJDMJ"] = num14;
                                row["QTWLMMJ"] = num15;
                                row["YLDXJ"] = num6;
                                row["YLHSMJ"] = num16;
                                row["YLSHMJ"] = num17;
                                row["YLQTMJ"] = num18;
                                row["FZSCLDMJ"] = num7;
                                if (num8 > 0.0)
                                {
                                    table3.Rows.Add(row);
                                    table4.Rows.Add(row.ItemArray);
                                }
                            }
                            if (table3.Rows.Count > 0)
                            {
                                DataRow row9 = table3.NewRow();
                                row9[0] = str13;
                                row9[1] = "小计";
                                if (table3.Rows.Count > 0)
                                {
                                    for (int num41 = 2; num41 < table3.Columns.Count; num41++)
                                    {
                                        if ((table4.Compute("SUM(" + table3.Columns[num41] + ")", null)) == DBNull.Value)
                                        {
                                            row9[num41] = Convert.ToDouble(0, null);
                                        }
                                        else
                                            row9[num41] = Convert.ToDouble(table4.Compute("SUM(" + table3.Columns[num41] + ")", null));
                                    }
                                    table3.Rows.InsertAt(row9, 0);
                                }
                                foreach (DataRow row15 in table3.Rows)
                                {
                                    table7.ImportRow(row15);
                                }
                            }
                        }
                        if (table7.Rows.Count > 0)
                        {
                            DataRow row12 = table7.NewRow();
                            row12[0] = str6.Trim();
                            row12[1] = "小计";
                            System.Data.DataTable table13 = table3.Clone();
                            for (int num46 = list9.Count; num46 > 0; num46--)
                            {
                                num27 = list9[num46 - 1];
                                string str5 = num27.ToString();
                                DataRow row3 = table7.NewRow();
                                row3[1] = str5;
                                if (table7.Select("LDQS='" + str5 + "'").Length > 0)
                                {
                                    for (int num21 = 2; num21 < table.Columns.Count; num21++)
                                    {
                                        if ((table7.Compute("SUM(" + table7.Columns[num21] + ")", "LDQS='" + str5 + "'")) == DBNull.Value)
                                        {
                                            row3[num21] = Convert.ToDouble(0, null);
                                        }
                                        else
                                            row3[num21] = Convert.ToDouble(table7.Compute("SUM(" + table7.Columns[num21] + ")", "LDQS='" + str5 + "'"));
                                    }
                                    table7.Rows.InsertAt(row3, 0);
                                    table13.Rows.Add(row3.ItemArray);
                                    table6.Rows.Add(row3.ItemArray);
                                }
                            }
                            for (int num49 = 2; num49 < table3.Columns.Count; num49++)
                            {
                                if (table13.Compute("SUM(" + table13.Columns[num49] + ")", null) == DBNull.Value)
                                {
                                    row12[num49] = Convert.ToDouble(0, null);
                                }
                                else
                                    row12[num49] = Convert.ToDouble(table13.Compute("SUM(" + table13.Columns[num49] + ")", null));
                            }
                            table7.Rows.InsertAt(row12, 0);
                            foreach (DataRow row7 in table7.Rows)
                            {
                                table.ImportRow(row7);
                            }
                        }
                    }
                    if (table6.Rows.Count > 0)
                    {
                        for (int num39 = list4.Count; num39 > 0; num39--)
                        {
                            num27 = list4[num39 - 1];
                            string str18 = num27.ToString();
                            DataRow row8 = table.NewRow();
                            row8[1] = str18;
                            for (int num40 = 2; num40 < (table.Columns.Count); num40++)
                            {
                                if ((table6.Compute("SUM(" + table6.Columns[num40] + ")", "LDQS='" + str18 + "'")) == DBNull.Value)
                                {
                                    row8[num40] = Convert.ToDouble(0, null);
                                }
                                else
                                    row8[num40] = Convert.ToDouble(table6.Compute("SUM(" + table6.Columns[num40] + ")", "LDQS='" + str18 + "'"));
                            }
                            table.Rows.InsertAt(row8, 0);
                            table8.Rows.Add(row8.ItemArray);
                        }
                        DataRow row2 = table.NewRow();
                        row2[0] = str19;
                        row2[1] = "合计";
                        for (int num20 = 2; num20 < table.Columns.Count; num20++)
                        {
                            if (table6.Compute("SUM(" + table6.Columns[num20] + ")", null) == DBNull.Value)
                            {
                                row2[num20] = Convert.ToDouble(0, null);
                            }
                            else
                                row2[num20] = Convert.ToDouble(table6.Compute("SUM(" + table6.Columns[num20] + ")", null));
                        }
                        table.Rows.InsertAt(row2, 0);
                        foreach (DataRow row10 in table.Rows)
                        {
                            table10.ImportRow(row10);
                        }
                    }
                }
                if (table8.Rows.Count > 0)
                {
                    for (int num26 = list3.Count; num26 > 0; num26--)
                    {
                        num27 = list3[num26 - 1];
                        string str7 = num27.ToString();
                        DataRow row5 = table10.NewRow();
                        row5[1] = str7;
                        for (int num28 = 2; num28 < table.Columns.Count; num28++)
                        {
                            if (table8.Compute("SUM(" + table8.Columns[num28] + ")", "LDQS='" + str7 + "'") == DBNull.Value)
                            {
                                row5[num28] = Convert.ToDouble(0, null);
                            }
                            else
                                row5[num28] = Convert.ToDouble(table8.Compute("SUM(" + table8.Columns[num28] + ")", "LDQS='" + str7 + "'"));
                        }
                        table10.Rows.InsertAt(row5, 0);
                        table14.Rows.Add(row5.ItemArray);
                    }
                    DataRow row4 = table10.NewRow();
                    row4[0] = str9;
                    row4[1] = "合计";
                    for (int num22 = 2; num22 < table.Columns.Count; num22++)
                    {
                        if (table8.Compute("SUM(" + table8.Columns[num22] + ")", null) == DBNull.Value)
                        {
                            row4[num22] = Convert.ToDouble(0, null);
                        }
                        else
                            row4[num22] = Convert.ToDouble(table8.Compute("SUM(" + table8.Columns[num22] + ")", null));
                    }
                    table10.Rows.InsertAt(row4, 0);
                }
            }
            table12.Clear();
            table5.Clear();
            if (table14.Rows.Count > 0)
            {
                for (int num29 = list7.Count; num29 > 0; num29--)
                {
                    string str32 = list3[num29 - 1].ToString();
                    DataRow row14 = table10.NewRow();
                    row14[1] = str32;
                    for (int num52 = 2; num52 < table.Columns.Count; num52++)
                    {
                        if (table14.Compute("SUM(" + table14.Columns[num52] + ")", "LDQS='" + str32 + "'") == DBNull.Value)
                        {
                            row14[num52] = Convert.ToDouble(0, null);
                        }
                        else
                            row14[num52] = Convert.ToDouble(table14.Compute("SUM(" + table14.Columns[num52] + ")", "LDQS='" + str32 + "'"));
                    }
                    table10.Rows.InsertAt(row14, 0);
                }
                DataRow row6 = table10.NewRow();
                row6[0] = "项目区";
                row6[1] = "合计";
                for (int num30 = 2; num30 < table.Columns.Count; num30++)
                {
                    if (table14.Compute("SUM(" + table14.Columns[num30] + ")", null) == DBNull.Value)
                    {
                        row6[num30] = Convert.ToDouble(0, null);
                    }
                    else
                        row6[num30] = Convert.ToDouble(table14.Compute("SUM(" + table14.Columns[num30] + ")", null));
                }
                table10.Rows.InsertAt(row6, 0);
            }
            table10 = this.UpdateDWTableByJoin(table10);
            return this.UpdateTableLDQSByJoin(table10, " CINDEX='207'", "LDQS");
        }

        private System.Data.DataTable B3()
        {
            System.Data.DataTable table = new System.Data.DataTable("ResultTable");
            DataColumn column = new DataColumn("TJDW", typeof(string));
            table.Columns.Add(column);
            column = new DataColumn("LDQS", typeof(string));
            table.Columns.Add(column);
            column = new DataColumn("QY", typeof(string));
            table.Columns.Add(column);
            column = new DataColumn("LZ", typeof(string));
            table.Columns.Add(column);
            column = new DataColumn("MJHJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("XJHJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("YLLMJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("YLLXJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("ZLLMJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("ZLLXJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("JSLMJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("JSLXJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("CSLMJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("CSLXJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("GSLMJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("GSLXJ", typeof(double));
            table.Columns.Add(column);
            return table;
        }

        private System.Data.DataTable B3_1()
        {
            System.Data.DataTable table = new System.Data.DataTable("ResultTable");
            DataColumn column = new DataColumn("TJDW", typeof(string));
            table.Columns.Add(column);
            column = new DataColumn("LMQS", typeof(string));
            table.Columns.Add(column);
            column = new DataColumn("QY", typeof(string));
            table.Columns.Add(column);
            column = new DataColumn("LZ", typeof(string));
            table.Columns.Add(column);
            column = new DataColumn("MJHJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("XJHJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("YLLMJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("YLLXJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("ZLLMJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("ZLLXJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("JSLMJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("JSLXJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("CSLMJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("CSLXJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("GSLMJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("GSLXJ", typeof(double));
            table.Columns.Add(column);
            return table;
        }

        public System.Data.DataTable B3_1TJByXianXiangCun(string ydzl)
        {
            System.Data.DataTable table = new System.Data.DataTable("ResultTable");
            table = this.B3_1();
            System.Data.DataTable mytjdt = new System.Data.DataTable();
            string cmdtxt = "SELECT LTRIM(RTRIM(SHI)) AS SHI,LTRIM(RTRIM(XIAN)) AS XIAN,LTRIM(RTRIM(XIANG)) AS XIANG,LTRIM(RTRIM(CUN)) AS CUN,LTRIM(RTRIM(LMSYQ)) AS LMQS,";
            string str2 = cmdtxt + "LTRIM(RTRIM(Q_LIN_ZHONG)) AS LZ,LTRIM(RTRIM(QI_YUAN)) AS QY,LTRIM(RTRIM(LING_ZU)) AS LING_ZU,LTRIM(RTRIM(JJLCQ)) AS JJLCQ,SUM(MIAN_JI) AS MIAN_JI,SUM(SLXJ) AS SLXJ FROM " + TABLE_ZZYTableName;
            cmdtxt = (str2 + "  WHERE (RTRIM(LTRIM(XMMC))='" + TABLE_ZZYXMMC + "') AND LEN(RTRIM(LTRIM(QI_YUAN)))>0 AND (RTRIM(LTRIM(YDZL))='" + ydzl + "')") + " GROUP BY SHI,XIAN,XIANG,CUN,LMSYQ,Q_LIN_ZHONG,QI_YUAN,LING_ZU,JJLCQ  ";
            mytjdt = this.GetTable(cmdtxt, TABLE_ZZYTableName);
            if (mytjdt == null)
            {
                MessageBox.Show(TABLE_ZZYTableName + " B3统计长期用地出错！", "信息", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return null;
            }
            if (mytjdt.Rows.Count == 0)
            {
                return table;
            }
            List<short> distXMQLMQSList = new List<short>();
            List<short> distXMQQYList = new List<short>();
            List<short> distXMQLZList = new List<short>();
            List<string> list11 = new List<string>();
            for (int i = 0; i < mytjdt.Rows.Count; i++)
            {
                string item = mytjdt.Rows[i]["SHI"].ToString();
                if (!list11.Contains(item))
                {
                    list11.Add(item);
                }
                string str20 = mytjdt.Rows[i]["LMQS"].ToString();
                if (str20.Trim().Length == 0)
                {
                    mytjdt.Rows[i]["LMQS"] = 0;
                    str20 = mytjdt.Rows[i]["LMQS"].ToString();
                }
                short num22 = Convert.ToInt16(str20);
                if (!distXMQLMQSList.Contains(num22))
                {
                    distXMQLMQSList.Add(num22);
                }
                if (mytjdt.Rows[i]["QY"].ToString().Trim().Length == 0)
                {
                    mytjdt.Rows[i]["QY"] = 0;
                }
                short num23 = Convert.ToInt16(mytjdt.Rows[i]["QY"].ToString());
                mytjdt.Rows[i]["QY"] = ((num23 / 10)).ToString() + "0";
                num23 = Convert.ToInt16(mytjdt.Rows[i]["QY"].ToString());
                if (!distXMQQYList.Contains(num23))
                {
                    distXMQQYList.Add(num23);
                }
                if (mytjdt.Rows[i]["LZ"].ToString().Trim().Length == 0)
                {
                    mytjdt.Rows[i]["LZ"] = 0;
                }
                short num10 = Convert.ToInt16(mytjdt.Rows[i]["LZ"].ToString());
                if (!distXMQLZList.Contains(num10))
                {
                    distXMQLZList.Add(num10);
                }
            }
            distXMQLMQSList.Sort();
            distXMQQYList.Sort();
            distXMQLZList.Sort();
            list11.Sort();
            System.Data.DataTable table5 = mytjdt.Clone();
            List<short> list8 = new List<short>();
            List<short> list9 = new List<short>();
            List<short> list10 = new List<short>();
            List<string> list12 = new List<string>();
            System.Data.DataTable table6 = mytjdt.Clone();
            List<short> list13 = new List<short>();
            List<short> list17 = new List<short>();
            List<short> list18 = new List<short>();
            table = this.B3_1TJTable("项目区", mytjdt, distXMQLZList, distXMQLMQSList, distXMQQYList);
            for (int j = 0; j < list11.Count; j++)
            {
                table5.Clear();
                list8.Clear();
                list9.Clear();
                list10.Clear();
                string tjdw = list11[j].ToString();
                foreach (DataRow row4 in mytjdt.Select("SHI='" + tjdw + "'"))
                {
                    table5.Rows.Add(row4.ItemArray);
                }
                list12.Clear();
                for (int k = 0; k < table5.Rows.Count; k++)
                {
                    string str6 = table5.Rows[k]["LMQS"].ToString().Trim();
                    if (str6.Length > 0)
                    {
                        short num12 = Convert.ToInt16(str6);
                        if (!list8.Contains(num12))
                        {
                            list8.Add(num12);
                        }
                    }
                    short num20 = Convert.ToInt16(table5.Rows[k]["QY"].ToString());
                    if (!list9.Contains(num20))
                    {
                        list9.Add(num20);
                    }
                    short num14 = Convert.ToInt16(table5.Rows[k]["LZ"].ToString());
                    if (!list10.Contains(num14))
                    {
                        list10.Add(num14);
                    }
                    string str9 = table5.Rows[k]["XIAN"].ToString();
                    if (!list12.Contains(str9))
                    {
                        list12.Add(str9);
                    }
                }
                list8.Sort();
                list9.Sort();
                list10.Sort();
                list12.Sort();
                System.Data.DataTable table7 = this.B3_1TJTable(tjdw, table5, list10, list8, list9);
                foreach (DataRow row8 in table7.Rows)
                {
                    table.ImportRow(row8);
                }
                for (int m = 0; m < list12.Count; m++)
                {
                    table6.Clear();
                    list13.Clear();
                    list17.Clear();
                    list18.Clear();
                    string str7 = list12[m].ToString();
                    foreach (DataRow row3 in table5.Select("XIAN='" + str7 + "'"))
                    {
                        table6.Rows.Add(row3.ItemArray);
                    }
                    List<string> list19 = new List<string>();
                    for (int n = 0; n < table6.Rows.Count; n++)
                    {
                        string str19 = table6.Rows[n]["LMQS"].ToString().Trim();
                        if (str19.Length > 0)
                        {
                            short num8 = Convert.ToInt16(str19);
                            if (!list13.Contains(num8))
                            {
                                list13.Add(num8);
                            }
                        }
                        short num26 = Convert.ToInt16(table6.Rows[n]["QY"].ToString());
                        if (!list17.Contains(num26))
                        {
                            list17.Add(num26);
                        }
                        short num16 = Convert.ToInt16(table6.Rows[n]["LZ"].ToString());
                        if (!list18.Contains(num16))
                        {
                            list18.Add(num16);
                        }
                        string str18 = table6.Rows[n]["XIANG"].ToString();
                        if (!list19.Contains(str18))
                        {
                            list19.Add(str18);
                        }
                    }
                    list13.Sort();
                    list17.Sort();
                    list18.Sort();
                    list19.Sort();
                    table7.Clear();
                    table7 = this.B3_1TJTable(str7, table6, list18, list13, list17);
                    foreach (DataRow row7 in table7.Rows)
                    {
                        table.ImportRow(row7);
                    }
                    System.Data.DataTable table3 = mytjdt.Clone();
                    List<short> list = new List<short>();
                    List<short> list2 = new List<short>();
                    List<short> list3 = new List<short>();
                    List<string> list4 = new List<string>();
                    System.Data.DataTable table4 = mytjdt.Clone();
                    List<short> list5 = new List<short>();
                    List<short> list6 = new List<short>();
                    List<short> list7 = new List<short>();
                    for (int num2 = 0; num2 < list19.Count; num2++)
                    {
                        string str17 = list19[num2].ToString();
                        DataRow[] rowArray4 = mytjdt.Select("XIANG='" + str17 + "'");
                        table3.Clear();
                        foreach (DataRow row2 in rowArray4)
                        {
                            table3.Rows.Add(row2.ItemArray);
                        }
                        list.Clear();
                        list2.Clear();
                        list3.Clear();
                        for (int num = 0; num < table3.Rows.Count; num++)
                        {
                            string str23 = table3.Rows[num]["CUN"].ToString();
                            if (!list4.Contains(str23))
                            {
                                list4.Add(str23);
                            }
                            string str8 = table3.Rows[num]["LMQS"].ToString().Trim();
                            if (str8.Length > 0)
                            {
                                short num13 = Convert.ToInt16(str8);
                                if (!list.Contains(num13))
                                {
                                    list.Add(num13);
                                }
                            }
                            short num25 = Convert.ToInt16(table3.Rows[num]["QY"].ToString());
                            if (!list2.Contains(num25))
                            {
                                list2.Add(num25);
                            }
                            short num6 = Convert.ToInt16(table3.Rows[num]["LZ"].ToString());
                            if (!list3.Contains(num6))
                            {
                                list3.Add(num6);
                            }
                        }
                        list4.Sort();
                        list.Sort();
                        list3.Sort();
                        list2.Sort();
                        table7.Clear();
                        table7 = this.B3_1TJTable(str17, table3, list3, list, list2);
                        foreach (DataRow row6 in table7.Rows)
                        {
                            table.ImportRow(row6);
                        }
                        for (int num17 = 0; num17 < list4.Count; num17++)
                        {
                            string str16 = list4[num17].ToString();
                            DataRow[] rowArray5 = table3.Select("CUN='" + str16 + "'");
                            table4.Clear();
                            foreach (DataRow row5 in rowArray5)
                            {
                                table4.Rows.Add(row5.ItemArray);
                            }
                            list5.Clear();
                            list7.Clear();
                            list6.Clear();
                            for (int num18 = 0; num18 < table4.Rows.Count; num18++)
                            {
                                string s = table4.Rows[num18]["LMQS"].ToString().Trim();
                                if ((s.Length > 0) && (short.Parse(s) >= 0))
                                {
                                    short num5 = Convert.ToInt16(s);
                                    if (!list5.Contains(num5))
                                    {
                                        list5.Add(num5);
                                    }
                                }
                                short num21 = Convert.ToInt16(table4.Rows[num18]["QY"].ToString());
                                if (!list6.Contains(num21))
                                {
                                    list6.Add(num21);
                                }
                                short num19 = Convert.ToInt16(table4.Rows[num18]["LZ"].ToString());
                                if (!list7.Contains(num19))
                                {
                                    list7.Add(num19);
                                }
                            }
                            list5.Sort();
                            list7.Sort();
                            list6.Sort();
                            table7.Clear();
                            table7 = this.B3_1TJTable(str16, table4, list7, list5, list6);
                            foreach (DataRow row in table7.Rows)
                            {
                                table.ImportRow(row);
                            }
                        }
                    }
                    table3.Clear();
                    table4.Clear();
                }
            }
            table5.Clear();
            table6.Clear();
            mytjdt.Clear();
            table = this.UpdateDWTableByJoin(table);
            return this.B3UpdateTableByJoin(table, "LMQS", "209");
        }

        private System.Data.DataTable B3_1TJTable(string tjdw, System.Data.DataTable mytjdt, List<short> DistXMQLZList, List<short> DistXMQLMQSList, List<short> DistXMQQYList)
        {
            System.Data.DataTable table = this.B3_1();
            string expression = "SUM(MIAN_JI)";
            string str2 = "SUM(SLXJ)";
            string str3 = " LING_ZU ='1'";
            string str4 = " LING_ZU ='2'";
            string str5 = " LING_ZU ='3'";
            string str6 = " LING_ZU ='4'";
            string str7 = " LING_ZU ='5'";
            string str8 = " JJLCQ ='1'";
            string str9 = " JJLCQ ='2'";
            string str10 = " JJLCQ ='3'";
            string str11 = " JJLCQ ='4'";
            double num = 0.0;
            double num2 = 0.0;
            double num3 = 0.0;
            double num4 = 0.0;
            double num5 = 0.0;
            double num6 = 0.0;
            double num7 = 0.0;
            double num8 = 0.0;
            double num9 = 0.0;
            double num10 = 0.0;
            double num11 = 0.0;
            double num12 = 0.0;
            DataRow row = table.NewRow();
            for (int i = 0; i < DistXMQLZList.Count; i++)
            {
                num = 0.0;
                num2 = 0.0;
                num3 = 0.0;
                num4 = 0.0;
                num5 = 0.0;
                num6 = 0.0;
                num7 = 0.0;
                num8 = 0.0;
                num9 = 0.0;
                num10 = 0.0;
                num11 = 0.0;
                num12 = 0.0;
                row = table.NewRow();
                string str13 = DistXMQLZList[i].ToString();
                string str14 = "LZ='" + str13 + "' AND ";
                if (mytjdt.Select(str14 + str3).Length > 0)
                {
                    num3 = Convert.ToDouble(mytjdt.Compute(expression, str14 + str3));
                    num8 = Convert.ToDouble(mytjdt.Compute(str2, str14 + str3));
                }
                if (mytjdt.Select(str14 + str4).Length > 0)
                {
                    num4 = Convert.ToDouble(mytjdt.Compute(expression, str14 + str4));
                    num9 = Convert.ToDouble(mytjdt.Compute(str2, str14 + str4));
                }
                if (mytjdt.Select(str14 + str5).Length > 0)
                {
                    num5 = Convert.ToDouble(mytjdt.Compute(expression, str14 + str5));
                    num10 = Convert.ToDouble(mytjdt.Compute(str2, str14 + str5));
                }
                if (mytjdt.Select(str14 + str6).Length > 0)
                {
                    num6 = Convert.ToDouble(mytjdt.Compute(expression, str14 + str6));
                    num11 = Convert.ToDouble(mytjdt.Compute(str2, str14 + str6));
                }
                if (mytjdt.Select(this.myfjjl + str14 + str7).Length > 0)
                {
                    num7 = Convert.ToDouble(mytjdt.Compute(expression, str14 + str7));
                    num12 = Convert.ToDouble(mytjdt.Compute(str2, str14 + str7));
                }
                if ((Convert.ToInt16(str13) / 10) == 0x19)
                {
                    if (mytjdt.Select(str14 + str8).Length > 0)
                    {
                        num3 = Convert.ToDouble(mytjdt.Compute(expression, str14 + str8));
                        num8 = Convert.ToDouble(mytjdt.Compute(str2, str14 + str8));
                    }
                    if (mytjdt.Select(str14 + str9).Length > 0)
                    {
                        num4 = Convert.ToDouble(mytjdt.Compute(expression, str14 + str9));
                        num9 = Convert.ToDouble(mytjdt.Compute(str2, str14 + str9));
                    }
                    if (mytjdt.Select(str14 + str10).Length > 0)
                    {
                        num6 = Convert.ToDouble(mytjdt.Compute(expression, str14 + str10));
                        num11 = Convert.ToDouble(mytjdt.Compute(str2, str14 + str10));
                    }
                    if (mytjdt.Select(str14 + str11).Length > 0)
                    {
                        num7 = Convert.ToDouble(mytjdt.Compute(expression, str14 + str11));
                        num12 = Convert.ToDouble(mytjdt.Compute(str2, str14 + str11));
                    }
                }
                num = (((num3 + num4) + num5) + num6) + num7;
                num2 = (((num8 + num9) + num10) + num11) + num12;
                row["LZ"] = str13;
                row["MJHJ"] = num;
                row["XJHJ"] = num2;
                row["YLLMJ"] = num3;
                row["YLLXJ"] = num8;
                row["ZLLMJ"] = num4;
                row["ZLLXJ"] = num9;
                row["JSLMJ"] = num5;
                row["JSLXJ"] = num10;
                row["CSLMJ"] = num6;
                row["CSLXJ"] = num11;
                row["GSLMJ"] = num7;
                row["GSLXJ"] = num12;
                if (num > 0.0)
                {
                    table.Rows.Add(row);
                }
            }
            row = table.NewRow();
            row["TJDW"] = tjdw;
            row["LZ"] = "合计";
            if (table.Rows.Count > 0)
            {
                for (int k = 4; k < table.Columns.Count; k++)
                {
                    row[k] = Convert.ToDouble(table.Compute("SUM(" + table.Columns[k] + ")", null));
                }
                table.Rows.InsertAt(row, 0);
            }
            for (int j = 0; j < DistXMQLMQSList.Count; j++)
            {
                string str16 = DistXMQLMQSList[j].ToString();
                string str15 = "LMQS='" + str16 + "' AND ";
                num = 0.0;
                num2 = 0.0;
                num3 = 0.0;
                num4 = 0.0;
                num5 = 0.0;
                num6 = 0.0;
                num7 = 0.0;
                num8 = 0.0;
                num9 = 0.0;
                num10 = 0.0;
                num11 = 0.0;
                num12 = 0.0;
                if (mytjdt.Select(this.myfjjl + str15 + str3).Length > 0)
                {
                    num3 = Convert.ToDouble(mytjdt.Compute(expression, this.myfjjl + str15 + str3));
                    num8 = Convert.ToDouble(mytjdt.Compute(str2, this.myfjjl + str15 + str3));
                }
                if (mytjdt.Select(this.myfjjl + str15 + str4).Length > 0)
                {
                    num4 = Convert.ToDouble(mytjdt.Compute(expression, this.myfjjl + str15 + str4));
                    num9 = Convert.ToDouble(mytjdt.Compute(str2, this.myfjjl + str15 + str4));
                }
                if (mytjdt.Select(this.myfjjl + str15 + str5).Length > 0)
                {
                    num5 = Convert.ToDouble(mytjdt.Compute(expression, this.myfjjl + str15 + str5));
                    num10 = Convert.ToDouble(mytjdt.Compute(str2, this.myfjjl + str15 + str5));
                }
                if (mytjdt.Select(this.myfjjl + str15 + str6).Length > 0)
                {
                    num6 = Convert.ToDouble(mytjdt.Compute(expression, this.myfjjl + str15 + str6));
                    num11 = Convert.ToDouble(mytjdt.Compute(str2, this.myfjjl + str15 + str6));
                }
                if (mytjdt.Select(this.myfjjl + str15 + str7).Length > 0)
                {
                    num7 = Convert.ToDouble(mytjdt.Compute(expression, this.myfjjl + str15 + str7));
                    num12 = Convert.ToDouble(mytjdt.Compute(str2, this.myfjjl + str15 + str7));
                }
                if (mytjdt.Select(this.myjjl + str15 + str8).Length > 0)
                {
                    num4 += Convert.ToDouble(mytjdt.Compute(expression, this.myjjl + str15 + str8));
                    num9 += Convert.ToDouble(mytjdt.Compute(str2, this.myjjl + str15 + str8));
                }
                if (mytjdt.Select(this.myjjl + str15 + str9).Length > 0)
                {
                    num5 += Convert.ToDouble(mytjdt.Compute(expression, this.myjjl + str15 + str9));
                    num10 += Convert.ToDouble(mytjdt.Compute(str2, this.myjjl + str15 + str9));
                }
                if (mytjdt.Select(this.myjjl + str15 + str10).Length > 0)
                {
                    num6 += Convert.ToDouble(mytjdt.Compute(expression, this.myjjl + str15 + str10));
                    num11 += Convert.ToDouble(mytjdt.Compute(str2, this.myjjl + str15 + str10));
                }
                if (mytjdt.Select(str15 + str11).Length > 0)
                {
                    num7 += Convert.ToDouble(mytjdt.Compute(expression, str15 + str11));
                    num12 += Convert.ToDouble(mytjdt.Compute(str2, str15 + str11));
                }
                num = (((num3 + num4) + num5) + num6) + num7;
                num2 = (((num8 + num9) + num10) + num11) + num12;
                DataRow row2 = table.NewRow();
                row2["LMQS"] = str16;
                row2["LZ"] = "小计";
                row2["MJHJ"] = num;
                row2["XJHJ"] = num2;
                row2["YLLMJ"] = num3;
                row2["YLLXJ"] = num8;
                row2["ZLLMJ"] = num4;
                row2["ZLLXJ"] = num9;
                row2["JSLMJ"] = num5;
                row2["JSLXJ"] = num10;
                row2["CSLMJ"] = num6;
                row2["CSLXJ"] = num11;
                row2["GSLMJ"] = num7;
                row2["GSLXJ"] = num12;
                if (num > 0.0)
                {
                    table.Rows.Add(row2);
                }
                for (int m = 0; m < DistXMQQYList.Count; m++)
                {
                    string str12 = DistXMQQYList[m].ToString();
                    str15 = "LMQS='" + str16 + "' AND QY='" + str12 + "' AND ";
                    num = 0.0;
                    num2 = 0.0;
                    num3 = 0.0;
                    num4 = 0.0;
                    num5 = 0.0;
                    num6 = 0.0;
                    num7 = 0.0;
                    num8 = 0.0;
                    num9 = 0.0;
                    num10 = 0.0;
                    num11 = 0.0;
                    num12 = 0.0;
                    if (mytjdt.Select(this.myfjjl + str15 + str3).Length > 0)
                    {
                        num3 = Convert.ToDouble(mytjdt.Compute(expression, this.myfjjl + str15 + str3));
                        num8 = Convert.ToDouble(mytjdt.Compute(str2, this.myfjjl + str15 + str3));
                    }
                    if (mytjdt.Select(this.myfjjl + str15 + str4).Length > 0)
                    {
                        num4 = Convert.ToDouble(mytjdt.Compute(expression, this.myfjjl + str15 + str4));
                        num9 = Convert.ToDouble(mytjdt.Compute(str2, this.myfjjl + str15 + str4));
                    }
                    if (mytjdt.Select(this.myfjjl + str15 + str5).Length > 0)
                    {
                        num5 = Convert.ToDouble(mytjdt.Compute(expression, this.myfjjl + str15 + str5));
                        num10 = Convert.ToDouble(mytjdt.Compute(str2, this.myfjjl + str15 + str5));
                    }
                    if (mytjdt.Select(this.myfjjl + str15 + str6).Length > 0)
                    {
                        num6 = Convert.ToDouble(mytjdt.Compute(expression, this.myfjjl + str15 + str6));
                        num11 = Convert.ToDouble(mytjdt.Compute(str2, this.myfjjl + str15 + str6));
                    }
                    if (mytjdt.Select(this.myfjjl + str15 + str7).Length > 0)
                    {
                        num7 = Convert.ToDouble(mytjdt.Compute(expression, this.myfjjl + str15 + str7));
                        num12 = Convert.ToDouble(mytjdt.Compute(str2, this.myfjjl + str15 + str7));
                    }
                    if (mytjdt.Select(this.myjjl + str15 + str8).Length > 0)
                    {
                        num4 += Convert.ToDouble(mytjdt.Compute(expression, this.myjjl + str15 + str8));
                        num9 += Convert.ToDouble(mytjdt.Compute(str2, this.myjjl + str15 + str8));
                    }
                    if (mytjdt.Select(this.myjjl + str15 + str9).Length > 0)
                    {
                        num5 += Convert.ToDouble(mytjdt.Compute(expression, this.myjjl + str15 + str9));
                        num10 += Convert.ToDouble(mytjdt.Compute(str2, this.myjjl + str15 + str9));
                    }
                    if (mytjdt.Select(str15 + str10).Length > 0)
                    {
                        num6 += Convert.ToDouble(mytjdt.Compute(expression, this.myjjl + str15 + str10));
                        num11 += Convert.ToDouble(mytjdt.Compute(str2, this.myjjl + str15 + str10));
                    }
                    if (mytjdt.Select(this.myjjl + str15 + str11).Length > 0)
                    {
                        num7 += Convert.ToDouble(mytjdt.Compute(expression, this.myjjl + str15 + str11));
                        num12 += Convert.ToDouble(mytjdt.Compute(str2, this.myjjl + str15 + str11));
                    }
                    num = (((num3 + num4) + num5) + num6) + num7;
                    num2 = (((num8 + num9) + num10) + num11) + num12;
                    row2 = table.NewRow();
                    row2["QY"] = str12;
                    row2["LZ"] = "计";
                    row2["MJHJ"] = num;
                    row2["XJHJ"] = num2;
                    row2["YLLMJ"] = num3;
                    row2["YLLXJ"] = num8;
                    row2["ZLLMJ"] = num4;
                    row2["ZLLXJ"] = num9;
                    row2["JSLMJ"] = num5;
                    row2["JSLXJ"] = num10;
                    row2["CSLMJ"] = num6;
                    row2["CSLXJ"] = num11;
                    row2["GSLMJ"] = num7;
                    row2["GSLXJ"] = num12;
                    if (num > 0.0)
                    {
                        table.Rows.Add(row2);
                    }
                    for (int n = 0; n < DistXMQLZList.Count; n++)
                    {
                        string str17 = DistXMQLZList[n].ToString();
                        str15 = "LMQS='" + str16 + "' AND QY='" + str12 + "' AND LZ='" + str17 + "' AND ";
                        num = 0.0;
                        num2 = 0.0;
                        num3 = 0.0;
                        num4 = 0.0;
                        num5 = 0.0;
                        num6 = 0.0;
                        num7 = 0.0;
                        num8 = 0.0;
                        num9 = 0.0;
                        num10 = 0.0;
                        num11 = 0.0;
                        num12 = 0.0;
                        if (mytjdt.Select(str15 + str3).Length > 0)
                        {
                            num3 = Convert.ToDouble(mytjdt.Compute(expression, str15 + str3));
                            num8 = Convert.ToDouble(mytjdt.Compute(str2, str15 + str3));
                        }
                        if (mytjdt.Select(str15 + str4).Length > 0)
                        {
                            num4 = Convert.ToDouble(mytjdt.Compute(expression, str15 + str4));
                            num9 = Convert.ToDouble(mytjdt.Compute(str2, str15 + str4));
                        }
                        if (mytjdt.Select(str15 + str5).Length > 0)
                        {
                            num5 = Convert.ToDouble(mytjdt.Compute(expression, str15 + str5));
                            num10 = Convert.ToDouble(mytjdt.Compute(str2, str15 + str5));
                        }
                        if (mytjdt.Select(str15 + str6).Length > 0)
                        {
                            num6 = Convert.ToDouble(mytjdt.Compute(expression, str15 + str6));
                            num11 = Convert.ToDouble(mytjdt.Compute(str2, str15 + str6));
                        }
                        if (mytjdt.Select(str15 + str7).Length > 0)
                        {
                            num7 = Convert.ToDouble(mytjdt.Compute(expression, str15 + str7));
                            num12 = Convert.ToDouble(mytjdt.Compute(str2, str15 + str7));
                        }
                        if ((Convert.ToInt16(str17) / 10) == 0x19)
                        {
                            if (mytjdt.Select(str15 + str8).Length > 0)
                            {
                                num3 = Convert.ToDouble(mytjdt.Compute(expression, str15 + str8));
                                num8 = Convert.ToDouble(mytjdt.Compute(str2, str15 + str8));
                            }
                            if (mytjdt.Select(str15 + str9).Length > 0)
                            {
                                num4 = Convert.ToDouble(mytjdt.Compute(expression, str15 + str9));
                                num9 = Convert.ToDouble(mytjdt.Compute(str2, str15 + str9));
                            }
                            if (mytjdt.Select(str15 + str10).Length > 0)
                            {
                                num6 = Convert.ToDouble(mytjdt.Compute(expression, str15 + str10));
                                num11 = Convert.ToDouble(mytjdt.Compute(str2, str15 + str10));
                            }
                            if (mytjdt.Select(str15 + str11).Length > 0)
                            {
                                num7 = Convert.ToDouble(mytjdt.Compute(expression, str15 + str11));
                                num12 = Convert.ToDouble(mytjdt.Compute(str2, str15 + str11));
                            }
                        }
                        num = (((num3 + num4) + num5) + num6) + num7;
                        num2 = (((num8 + num9) + num10) + num11) + num12;
                        row2 = table.NewRow();
                        row2["LZ"] = str17;
                        row2["MJHJ"] = num;
                        row2["XJHJ"] = num2;
                        row2["YLLMJ"] = num3;
                        row2["YLLXJ"] = num8;
                        row2["ZLLMJ"] = num4;
                        row2["ZLLXJ"] = num9;
                        row2["JSLMJ"] = num5;
                        row2["JSLXJ"] = num10;
                        row2["CSLMJ"] = num6;
                        row2["CSLXJ"] = num11;
                        row2["GSLMJ"] = num7;
                        row2["GSLXJ"] = num12;
                        if (num > 0.0)
                        {
                            table.Rows.Add(row2);
                        }
                    }
                }
            }
            return table;
        }

        public System.Data.DataTable B3TJByXianXiangCun(string ydzl)
        {
            System.Data.DataTable table = new System.Data.DataTable("ResultTable");
            table = this.B3();
            System.Data.DataTable mytjdt = new System.Data.DataTable();
            string cmdtxt = "SELECT LTRIM(RTRIM(SHI)) AS SHI,LTRIM(RTRIM(XIAN)) AS XIAN,LTRIM(RTRIM(XIANG)) AS XIANG,LTRIM(RTRIM(CUN)) AS CUN,LTRIM(RTRIM(Q_LD_QS)) AS LDQS,";
            string str2 = cmdtxt + "LTRIM(RTRIM(Q_LIN_ZHONG)) AS LZ,LTRIM(RTRIM(QI_YUAN)) AS QY,LTRIM(RTRIM(LING_ZU)) AS LING_ZU,LTRIM(RTRIM(JJLCQ)) AS JJLCQ,SUM(MIAN_JI) AS MIAN_JI,SUM(SLXJ) AS SLXJ FROM " + TABLE_ZZYTableName;
            cmdtxt = (str2 + "  WHERE (RTRIM(LTRIM(XMMC))='" + TABLE_ZZYXMMC + "') AND LEN(RTRIM(LTRIM(QI_YUAN)))>0 AND (RTRIM(LTRIM(YDZL))='" + ydzl + "')") + " GROUP BY SHI,XIAN,XIANG,CUN,Q_LD_QS,Q_LIN_ZHONG,QI_YUAN,LING_ZU,JJLCQ  ";
            mytjdt = this.GetTable(cmdtxt, TABLE_ZZYTableName);
            if (mytjdt == null)
            {
                MessageBox.Show(TABLE_ZZYTableName + " B3统计出错！", "信息", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return null;
            }
            if (mytjdt.Rows.Count == 0)
            {
                return table;
            }
            List<short> distXMQLDQSList = new List<short>();
            List<short> distXMQQYList = new List<short>();
            List<short> distXMQLZList = new List<short>();
            List<string> list13 = new List<string>();
            new List<short>();
            for (int i = 0; i < mytjdt.Rows.Count; i++)
            {
                string item = mytjdt.Rows[i]["SHI"].ToString();
                if (!list13.Contains(item))
                {
                    list13.Add(item);
                }
                if (mytjdt.Rows[i]["LDQS"].ToString().Trim().Length == 0)
                {
                    mytjdt.Rows[i]["LDQS"] = 0;
                }
                short num22 = Convert.ToInt16(mytjdt.Rows[i]["LDQS"].ToString());
                if (num22 >= 20)
                {
                    mytjdt.Rows[i]["LDQS"] = "20";
                    num22 = Convert.ToInt16(mytjdt.Rows[i]["LDQS"].ToString());
                }
                if (!distXMQLDQSList.Contains(num22))
                {
                    distXMQLDQSList.Add(num22);
                }
                if (mytjdt.Rows[i]["QY"].ToString().Trim().Length == 0)
                {
                    mytjdt.Rows[i]["QY"] = 0;
                }
                short num13 = Convert.ToInt16(mytjdt.Rows[i]["QY"].ToString());
                mytjdt.Rows[i]["QY"] = ((num13 / 10)).ToString() + "0";
                num13 = Convert.ToInt16(mytjdt.Rows[i]["QY"].ToString());
                if (!distXMQQYList.Contains(num13))
                {
                    distXMQQYList.Add(num13);
                }
                if (mytjdt.Rows[i]["LZ"].ToString().Trim().Length == 0)
                {
                    mytjdt.Rows[i]["LZ"] = 0;
                }
                short num15 = Convert.ToInt16(mytjdt.Rows[i]["LZ"].ToString());
                if (!distXMQLZList.Contains(num15))
                {
                    distXMQLZList.Add(num15);
                }
            }
            distXMQLDQSList.Sort();
            distXMQQYList.Sort();
            distXMQLZList.Sort();
            list13.Sort();
            System.Data.DataTable table4 = mytjdt.Clone();
            List<short> list10 = new List<short>();
            List<short> list11 = new List<short>();
            List<short> list12 = new List<short>();
            List<string> list3 = new List<string>();
            System.Data.DataTable table7 = mytjdt.Clone();
            List<short> list6 = new List<short>();
            List<short> list7 = new List<short>();
            List<short> list8 = new List<short>();
            table = this.B3TJTable("项目区", mytjdt, distXMQLZList, distXMQLDQSList, distXMQQYList);
            for (int j = 0; j < list13.Count; j++)
            {
                table4.Clear();
                list10.Clear();
                list11.Clear();
                list12.Clear();
                string tjdw = list13[j].ToString();
                foreach (DataRow row2 in mytjdt.Select("SHI='" + tjdw + "'"))
                {
                    table4.Rows.Add(row2.ItemArray);
                }
                list3.Clear();
                for (int k = 0; k < table4.Rows.Count; k++)
                {
                    string str10 = table4.Rows[k]["LDQS"].ToString().Trim();
                    if (str10.Length > 0)
                    {
                        short num11 = Convert.ToInt16(str10);
                        if (!list10.Contains(num11))
                        {
                            list10.Add(num11);
                        }
                    }
                    short num16 = Convert.ToInt16(table4.Rows[k]["QY"].ToString());
                    if (!list11.Contains(num16))
                    {
                        list11.Add(num16);
                    }
                    short num24 = Convert.ToInt16(table4.Rows[k]["LZ"].ToString());
                    if (!list12.Contains(num24))
                    {
                        list12.Add(num24);
                    }
                    string str22 = table4.Rows[k]["XIAN"].ToString();
                    if (!list3.Contains(str22))
                    {
                        list3.Add(str22);
                    }
                }
                list10.Sort();
                list11.Sort();
                list12.Sort();
                list3.Sort();
                System.Data.DataTable table6 = this.B3TJTable(tjdw, table4, list12, list10, list11);
                foreach (DataRow row3 in table6.Rows)
                {
                    table.ImportRow(row3);
                }
                for (int m = 0; m < list3.Count; m++)
                {
                    table7.Clear();
                    list6.Clear();
                    list7.Clear();
                    list8.Clear();
                    string str7 = list3[m].ToString();
                    foreach (DataRow row8 in table4.Select("XIAN='" + str7 + "'"))
                    {
                        table7.Rows.Add(row8.ItemArray);
                    }
                    List<string> list2 = new List<string>();
                    for (int n = 0; n < table7.Rows.Count; n++)
                    {
                        string str17 = table7.Rows[n]["LDQS"].ToString().Trim();
                        if (str17.Length > 0)
                        {
                            short num19 = Convert.ToInt16(str17);
                            if (!list6.Contains(num19))
                            {
                                list6.Add(num19);
                            }
                        }
                        short num26 = Convert.ToInt16(table7.Rows[n]["QY"].ToString());
                        if (!list7.Contains(num26))
                        {
                            list7.Add(num26);
                        }
                        short num21 = Convert.ToInt16(table7.Rows[n]["LZ"].ToString());
                        if (!list8.Contains(num21))
                        {
                            list8.Add(num21);
                        }
                        string str21 = table7.Rows[n]["XIANG"].ToString();
                        if (!list2.Contains(str21))
                        {
                            list2.Add(str21);
                        }
                    }
                    list6.Sort();
                    list7.Sort();
                    list8.Sort();
                    list2.Sort();
                    table6.Clear();
                    table6 = this.B3TJTable(str7, table7, list8, list6, list7);
                    foreach (DataRow row6 in table6.Rows)
                    {
                        table.ImportRow(row6);
                    }
                    System.Data.DataTable table3 = mytjdt.Clone();
                    List<short> list9 = new List<short>();
                    List<short> list18 = new List<short>();
                    List<short> list19 = new List<short>();
                    List<string> list17 = new List<string>();
                    System.Data.DataTable table5 = mytjdt.Clone();
                    List<short> list = new List<short>();
                    List<short> list5 = new List<short>();
                    List<short> list4 = new List<short>();
                    for (int num2 = 0; num2 < list2.Count; num2++)
                    {
                        string str4 = list2[num2].ToString();
                        DataRow[] rowArray = mytjdt.Select("XIANG='" + str4 + "'");
                        table3.Clear();
                        foreach (DataRow row7 in rowArray)
                        {
                            table3.Rows.Add(row7.ItemArray);
                        }
                        list9.Clear();
                        list18.Clear();
                        list19.Clear();
                        for (int num9 = 0; num9 < table3.Rows.Count; num9++)
                        {
                            string str13 = table3.Rows[num9]["CUN"].ToString();
                            if (!list17.Contains(str13))
                            {
                                list17.Add(str13);
                            }
                            string str8 = table3.Rows[num9]["LDQS"].ToString().Trim();
                            if (str8.Length > 0)
                            {
                                short num10 = Convert.ToInt16(str8);
                                if (!list9.Contains(num10))
                                {
                                    list9.Add(num10);
                                }
                            }
                            short num23 = Convert.ToInt16(table3.Rows[num9]["QY"].ToString());
                            if (!list18.Contains(num23))
                            {
                                list18.Add(num23);
                            }
                            short num25 = Convert.ToInt16(table3.Rows[num9]["LZ"].ToString());
                            if (!list19.Contains(num25))
                            {
                                list19.Add(num25);
                            }
                        }
                        list17.Sort();
                        list9.Sort();
                        list19.Sort();
                        list18.Sort();
                        table6.Clear();
                        table6 = this.B3TJTable(str4, table3, list19, list9, list18);
                        foreach (DataRow row5 in table6.Rows)
                        {
                            table.ImportRow(row5);
                        }
                        for (int num18 = 0; num18 < list17.Count; num18++)
                        {
                            string str6 = list17[num18].ToString();
                            DataRow[] rowArray5 = table3.Select("CUN='" + str6 + "'");
                            table5.Clear();
                            foreach (DataRow row4 in rowArray5)
                            {
                                table5.Rows.Add(row4.ItemArray);
                            }
                            list.Clear();
                            list4.Clear();
                            list5.Clear();
                            for (int num8 = 0; num8 < table5.Rows.Count; num8++)
                            {
                                string s = table5.Rows[num8]["LDQS"].ToString().Trim();
                                if ((s.Length > 0) && (short.Parse(s) >= 0))
                                {
                                    short num = Convert.ToInt16(s);
                                    if (!list.Contains(num))
                                    {
                                        list.Add(num);
                                    }
                                }
                                short num17 = Convert.ToInt16(table5.Rows[num8]["QY"].ToString());
                                if (!list5.Contains(num17))
                                {
                                    list5.Add(num17);
                                }
                                short num12 = Convert.ToInt16(table5.Rows[num8]["LZ"].ToString());
                                if (!list4.Contains(num12))
                                {
                                    list4.Add(num12);
                                }
                            }
                            list.Sort();
                            list4.Sort();
                            list5.Sort();
                            table6.Clear();
                            table6 = this.B3TJTable(str6, table5, list4, list, list5);
                            foreach (DataRow row in table6.Rows)
                            {
                                table.ImportRow(row);
                            }
                        }
                    }
                    table3.Clear();
                    table5.Clear();
                }
            }
            table4.Clear();
            table7.Clear();
            mytjdt.Clear();
            table = this.UpdateDWTableByJoin(table);
            return this.B3UpdateTableByJoin(table, "LDQS", "207");
        }

        private System.Data.DataTable B3TJTable(string tjdw, System.Data.DataTable mytjdt, List<short> DistXMQLZList, List<short> DistXMQLDQSList, List<short> DistXMQQYList)
        {
            System.Data.DataTable table = this.B3();
            string expression = "SUM(MIAN_JI)";
            string str2 = "SUM(SLXJ)";
            string str3 = " LING_ZU ='1'";
            string str4 = " LING_ZU ='2'";
            string str5 = " LING_ZU ='3'";
            string str6 = " LING_ZU ='4'";
            string str7 = " LING_ZU ='5'";
            string str8 = " JJLCQ ='1'";
            string str9 = " JJLCQ ='2'";
            string str10 = " JJLCQ ='3'";
            string str11 = " JJLCQ ='4'";
            double num = 0.0;
            double num2 = 0.0;
            double num3 = 0.0;
            double num4 = 0.0;
            double num5 = 0.0;
            double num6 = 0.0;
            double num7 = 0.0;
            double num8 = 0.0;
            double num9 = 0.0;
            double num10 = 0.0;
            double num11 = 0.0;
            double num12 = 0.0;
            DataRow row = table.NewRow();
            for (int i = 0; i < DistXMQLZList.Count; i++)
            {
                num = 0.0;
                num2 = 0.0;
                num3 = 0.0;
                num4 = 0.0;
                num5 = 0.0;
                num6 = 0.0;
                num7 = 0.0;
                num8 = 0.0;
                num9 = 0.0;
                num10 = 0.0;
                num11 = 0.0;
                num12 = 0.0;
                row = table.NewRow();
                string str13 = DistXMQLZList[i].ToString();
                string str14 = " LZ='" + str13 + "' AND ";
                if (mytjdt.Select(str14 + str3).Length > 0)
                {
                    num3 = Convert.ToDouble(mytjdt.Compute(expression, str14 + str3));
                    num8 = Convert.ToDouble(mytjdt.Compute(str2, str14 + str3));
                }
                if (mytjdt.Select(str14 + str4).Length > 0)
                {
                    num4 = Convert.ToDouble(mytjdt.Compute(expression, str14 + str4));
                    num9 = Convert.ToDouble(mytjdt.Compute(str2, str14 + str4));
                }
                if (mytjdt.Select(str14 + str5).Length > 0)
                {
                    num5 = Convert.ToDouble(mytjdt.Compute(expression, str14 + str5));
                    num10 = Convert.ToDouble(mytjdt.Compute(str2, str14 + str5));
                }
                if (mytjdt.Select(str14 + str6).Length > 0)
                {
                    num6 = Convert.ToDouble(mytjdt.Compute(expression, str14 + str6));
                    num11 = Convert.ToDouble(mytjdt.Compute(str2, str14 + str6));
                }
                if (mytjdt.Select(str14 + str7).Length > 0)
                {
                    num7 = Convert.ToDouble(mytjdt.Compute(expression, str14 + str7));
                    num12 = Convert.ToDouble(mytjdt.Compute(str2, str14 + str7));
                }
                if ((Convert.ToInt16(str13) / 10) == 0x19)
                {
                    if (mytjdt.Select(str14 + str8).Length > 0)
                    {
                        num3 = Convert.ToDouble(mytjdt.Compute(expression, str14 + str8));
                        num8 = Convert.ToDouble(mytjdt.Compute(str2, str14 + str8));
                    }
                    if (mytjdt.Select(str14 + str9).Length > 0)
                    {
                        num4 = Convert.ToDouble(mytjdt.Compute(expression, str14 + str9));
                        num9 = Convert.ToDouble(mytjdt.Compute(str2, str14 + str9));
                    }
                    if (mytjdt.Select(str14 + str10).Length > 0)
                    {
                        num6 = Convert.ToDouble(mytjdt.Compute(expression, str14 + str10));
                        num11 = Convert.ToDouble(mytjdt.Compute(str2, str14 + str10));
                    }
                    if (mytjdt.Select(str14 + str11).Length > 0)
                    {
                        num7 = Convert.ToDouble(mytjdt.Compute(expression, str14 + str11));
                        num12 = Convert.ToDouble(mytjdt.Compute(str2, str14 + str11));
                    }
                }
                num = (((num3 + num4) + num5) + num6) + num7;
                num2 = (((num8 + num9) + num10) + num11) + num12;
                row["LZ"] = str13;
                row["MJHJ"] = num;
                row["XJHJ"] = num2;
                row["YLLMJ"] = num3;
                row["YLLXJ"] = num8;
                row["ZLLMJ"] = num4;
                row["ZLLXJ"] = num9;
                row["JSLMJ"] = num5;
                row["JSLXJ"] = num10;
                row["CSLMJ"] = num6;
                row["CSLXJ"] = num11;
                row["GSLMJ"] = num7;
                row["GSLXJ"] = num12;
                if (num > 0.0)
                {
                    table.Rows.Add(row);
                }
            }
            row = table.NewRow();
            row["TJDW"] = tjdw;
            row["LZ"] = "合计";
            if (table.Rows.Count > 0)
            {
                for (int k = 4; k < table.Columns.Count; k++)
                {
                    row[k] = Convert.ToDouble(table.Compute("SUM(" + table.Columns[k] + ")", null));
                }
                table.Rows.InsertAt(row, 0);
            }
            for (int j = 0; j < DistXMQLDQSList.Count; j++)
            {
                string str16 = DistXMQLDQSList[j].ToString();
                string str15 = "LDQS='" + str16 + "' AND ";
                num = 0.0;
                num2 = 0.0;
                num3 = 0.0;
                num4 = 0.0;
                num5 = 0.0;
                num6 = 0.0;
                num7 = 0.0;
                num8 = 0.0;
                num9 = 0.0;
                num10 = 0.0;
                num11 = 0.0;
                num12 = 0.0;
                if (mytjdt.Select(this.myfjjl + str15 + str3).Length > 0)
                {
                    num3 = Convert.ToDouble(mytjdt.Compute(expression, this.myfjjl + str15 + str3));
                    num8 = Convert.ToDouble(mytjdt.Compute(str2, this.myfjjl + str15 + str3));
                }
                if (mytjdt.Select(this.myfjjl + str15 + str4).Length > 0)
                {
                    num4 = Convert.ToDouble(mytjdt.Compute(expression, this.myfjjl + str15 + str4));
                    num9 = Convert.ToDouble(mytjdt.Compute(str2, this.myfjjl + str15 + str4));
                }
                if (mytjdt.Select(this.myfjjl + str15 + str5).Length > 0)
                {
                    num5 = Convert.ToDouble(mytjdt.Compute(expression, this.myfjjl + str15 + str5));
                    num10 = Convert.ToDouble(mytjdt.Compute(str2, this.myfjjl + str15 + str5));
                }
                if (mytjdt.Select(this.myfjjl + str15 + str6).Length > 0)
                {
                    num6 = Convert.ToDouble(mytjdt.Compute(expression, this.myfjjl + str15 + str6));
                    num11 = Convert.ToDouble(mytjdt.Compute(str2, this.myfjjl + str15 + str6));
                }
                if (mytjdt.Select(this.myfjjl + str15 + str7).Length > 0)
                {
                    num7 = Convert.ToDouble(mytjdt.Compute(expression, this.myfjjl + str15 + str7));
                    num12 = Convert.ToDouble(mytjdt.Compute(str2, this.myfjjl + str15 + str7));
                }
                if (mytjdt.Select(this.myjjl + str15 + str8).Length > 0)
                {
                    num3 += Convert.ToDouble(mytjdt.Compute(expression, this.myjjl + str15 + str8));
                    num8 += Convert.ToDouble(mytjdt.Compute(str2, this.myjjl + str15 + str8));
                }
                if (mytjdt.Select(this.myjjl + str15 + str9).Length > 0)
                {
                    num4 += Convert.ToDouble(mytjdt.Compute(expression, this.myjjl + str15 + str9));
                    num9 += Convert.ToDouble(mytjdt.Compute(str2, this.myjjl + str15 + str9));
                }
                if (mytjdt.Select(this.myjjl + str15 + str10).Length > 0)
                {
                    num6 += Convert.ToDouble(mytjdt.Compute(expression, this.myjjl + str15 + str10));
                    num11 += Convert.ToDouble(mytjdt.Compute(str2, this.myjjl + str15 + str10));
                }
                if (mytjdt.Select(this.myjjl + str15 + str11).Length > 0)
                {
                    num7 += Convert.ToDouble(mytjdt.Compute(expression, this.myjjl + str15 + str11));
                    num12 += Convert.ToDouble(mytjdt.Compute(str2, this.myjjl + str15 + str11));
                }
                num = (((num3 + num4) + num5) + num6) + num7;
                num2 = (((num8 + num9) + num10) + num11) + num12;
                DataRow row2 = table.NewRow();
                row2["LDQS"] = str16;
                row2["LZ"] = "小计";
                row2["MJHJ"] = num;
                row2["XJHJ"] = num2;
                row2["YLLMJ"] = num3;
                row2["YLLXJ"] = num8;
                row2["ZLLMJ"] = num4;
                row2["ZLLXJ"] = num9;
                row2["JSLMJ"] = num5;
                row2["JSLXJ"] = num10;
                row2["CSLMJ"] = num6;
                row2["CSLXJ"] = num11;
                row2["GSLMJ"] = num7;
                row2["GSLXJ"] = num12;
                if (num > 0.0)
                {
                    table.Rows.Add(row2);
                }
                for (int m = 0; m < DistXMQQYList.Count; m++)
                {
                    string str12 = DistXMQQYList[m].ToString();
                    str15 = "LDQS='" + str16 + "' AND QY='" + str12 + "' AND ";
                    num = 0.0;
                    num2 = 0.0;
                    num3 = 0.0;
                    num4 = 0.0;
                    num5 = 0.0;
                    num6 = 0.0;
                    num7 = 0.0;
                    num8 = 0.0;
                    num9 = 0.0;
                    num10 = 0.0;
                    num11 = 0.0;
                    num12 = 0.0;
                    if (mytjdt.Select(this.myfjjl + str15 + str3).Length > 0)
                    {
                        num3 = Convert.ToDouble(mytjdt.Compute(expression, this.myfjjl + str15 + str3));
                        num8 = Convert.ToDouble(mytjdt.Compute(str2, this.myfjjl + str15 + str3));
                    }
                    if (mytjdt.Select(this.myfjjl + str15 + str4).Length > 0)
                    {
                        num4 = Convert.ToDouble(mytjdt.Compute(expression, this.myfjjl + str15 + str4));
                        num9 = Convert.ToDouble(mytjdt.Compute(str2, this.myfjjl + str15 + str4));
                    }
                    if (mytjdt.Select(this.myfjjl + str15 + str5).Length > 0)
                    {
                        num5 = Convert.ToDouble(mytjdt.Compute(expression, this.myfjjl + str15 + str5));
                        num10 = Convert.ToDouble(mytjdt.Compute(str2, this.myfjjl + str15 + str5));
                    }
                    if (mytjdt.Select(this.myfjjl + str15 + str6).Length > 0)
                    {
                        num6 = Convert.ToDouble(mytjdt.Compute(expression, this.myfjjl + str15 + str6));
                        num11 = Convert.ToDouble(mytjdt.Compute(str2, this.myfjjl + str15 + str6));
                    }
                    if (mytjdt.Select(this.myfjjl + str15 + str7).Length > 0)
                    {
                        num7 = Convert.ToDouble(mytjdt.Compute(expression, this.myfjjl + str15 + str7));
                        num12 = Convert.ToDouble(mytjdt.Compute(str2, this.myfjjl + str15 + str7));
                    }
                    if (mytjdt.Select(this.myjjl + str15 + str8).Length > 0)
                    {
                        num3 += Convert.ToDouble(mytjdt.Compute(expression, this.myjjl + str15 + str8));
                        num8 += Convert.ToDouble(mytjdt.Compute(str2, this.myjjl + str15 + str8));
                    }
                    if (mytjdt.Select(this.myjjl + str15 + str9).Length > 0)
                    {
                        num4 += Convert.ToDouble(mytjdt.Compute(expression, this.myjjl + str15 + str9));
                        num9 += Convert.ToDouble(mytjdt.Compute(str2, this.myjjl + str15 + str9));
                    }
                    if (mytjdt.Select(this.myjjl + str15 + str10).Length > 0)
                    {
                        num6 += Convert.ToDouble(mytjdt.Compute(expression, this.myjjl + str15 + str10));
                        num11 += Convert.ToDouble(mytjdt.Compute(str2, this.myjjl + str15 + str10));
                    }
                    if (mytjdt.Select(this.myjjl + str15 + str11).Length > 0)
                    {
                        num7 += Convert.ToDouble(mytjdt.Compute(expression, this.myjjl + str15 + str11));
                        num12 += Convert.ToDouble(mytjdt.Compute(str2, this.myjjl + str15 + str11));
                    }
                    num = (((num3 + num4) + num5) + num6) + num7;
                    num2 = (((num8 + num9) + num10) + num11) + num12;
                    row2 = table.NewRow();
                    row2["QY"] = str12;
                    row2["LZ"] = "计";
                    row2["MJHJ"] = num;
                    row2["XJHJ"] = num2;
                    row2["YLLMJ"] = num3;
                    row2["YLLXJ"] = num8;
                    row2["ZLLMJ"] = num4;
                    row2["ZLLXJ"] = num9;
                    row2["JSLMJ"] = num5;
                    row2["JSLXJ"] = num10;
                    row2["CSLMJ"] = num6;
                    row2["CSLXJ"] = num11;
                    row2["GSLMJ"] = num7;
                    row2["GSLXJ"] = num12;
                    if (num > 0.0)
                    {
                        table.Rows.Add(row2);
                    }
                    for (int n = 0; n < DistXMQLZList.Count; n++)
                    {
                        string str17 = DistXMQLZList[n].ToString();
                        str15 = "LDQS='" + str16 + "' AND QY='" + str12 + "' AND LZ='" + str17 + "' AND ";
                        num = 0.0;
                        num2 = 0.0;
                        num3 = 0.0;
                        num4 = 0.0;
                        num5 = 0.0;
                        num6 = 0.0;
                        num7 = 0.0;
                        num8 = 0.0;
                        num9 = 0.0;
                        num10 = 0.0;
                        num11 = 0.0;
                        num12 = 0.0;
                        if (mytjdt.Select(str15 + str3).Length > 0)
                        {
                            num3 = Convert.ToDouble(mytjdt.Compute(expression, str15 + str3));
                            num8 = Convert.ToDouble(mytjdt.Compute(str2, str15 + str3));
                        }
                        if (mytjdt.Select(str15 + str4).Length > 0)
                        {
                            num4 = Convert.ToDouble(mytjdt.Compute(expression, str15 + str4));
                            num9 = Convert.ToDouble(mytjdt.Compute(str2, str15 + str4));
                        }
                        if (mytjdt.Select(str15 + str5).Length > 0)
                        {
                            num5 = Convert.ToDouble(mytjdt.Compute(expression, str15 + str5));
                            num10 = Convert.ToDouble(mytjdt.Compute(str2, str15 + str5));
                        }
                        if (mytjdt.Select(str15 + str6).Length > 0)
                        {
                            num6 = Convert.ToDouble(mytjdt.Compute(expression, str15 + str6));
                            num11 = Convert.ToDouble(mytjdt.Compute(str2, str15 + str6));
                        }
                        if (mytjdt.Select(str15 + str7).Length > 0)
                        {
                            num7 = Convert.ToDouble(mytjdt.Compute(expression, str15 + str7));
                            num12 = Convert.ToDouble(mytjdt.Compute(str2, str15 + str7));
                        }
                        if ((Convert.ToInt16(str17) / 10) == 0x19)
                        {
                            if (mytjdt.Select(str15 + str8).Length > 0)
                            {
                                num3 = Convert.ToDouble(mytjdt.Compute(expression, str15 + str8));
                                num8 = Convert.ToDouble(mytjdt.Compute(str2, str15 + str8));
                            }
                            if (mytjdt.Select(str15 + str9).Length > 0)
                            {
                                num4 = Convert.ToDouble(mytjdt.Compute(expression, str15 + str9));
                                num9 = Convert.ToDouble(mytjdt.Compute(str2, str15 + str9));
                            }
                            if (mytjdt.Select(str15 + str10).Length > 0)
                            {
                                num6 = Convert.ToDouble(mytjdt.Compute(expression, str15 + str10));
                                num11 = Convert.ToDouble(mytjdt.Compute(str2, str15 + str10));
                            }
                            if (mytjdt.Select(str15 + str11).Length > 0)
                            {
                                num7 = Convert.ToDouble(mytjdt.Compute(expression, str15 + str11));
                                num12 = Convert.ToDouble(mytjdt.Compute(str2, str15 + str11));
                            }
                        }
                        num = (((num3 + num4) + num5) + num6) + num7;
                        num2 = (((num8 + num9) + num10) + num11) + num12;
                        row2 = table.NewRow();
                        row2["LZ"] = str17;
                        row2["MJHJ"] = num;
                        row2["XJHJ"] = num2;
                        row2["YLLMJ"] = num3;
                        row2["YLLXJ"] = num8;
                        row2["ZLLMJ"] = num4;
                        row2["ZLLXJ"] = num9;
                        row2["JSLMJ"] = num5;
                        row2["JSLXJ"] = num10;
                        row2["CSLMJ"] = num6;
                        row2["CSLXJ"] = num11;
                        row2["GSLMJ"] = num7;
                        row2["GSLXJ"] = num12;
                        if (num > 0.0)
                        {
                            table.Rows.Add(row2);
                        }
                    }
                }
            }
            return table;
        }

        private System.Data.DataTable B3UpdateTableByJoin(System.Data.DataTable dataTable_0, string qsname, string qsindex)
        {
            string cmdtxt = " SELECT CCODE,CSNAME FROM " + TABLE_XZDWTABLE + " WHERE (CINDEX = '" + qsindex + "') OR (CINDEX = '212')";
            System.Data.DataTable source = this.GetTable(cmdtxt, "xcdm");
            foreach (var type in Enumerable.Join(DataTableExtensions.AsEnumerable(dataTable_0), DataTableExtensions.AsEnumerable(source), delegate(DataRow dataRow_0)
            {
                return DataRowExtensions.Field<string>(dataRow_0, qsname);
            }, delegate(DataRow dataRow_0)
            {
                return DataRowExtensions.Field<string>(dataRow_0, "CCODE");
            }, delegate(DataRow dataRow_0, DataRow dataRow_1)
            {
                return new
                {
                    dt1row = dataRow_0,
                    dt2row = dataRow_1
                };
            }))
            {
                type.dt1row[qsname] = type.dt2row["CSNAME"].ToString().Substring(0, 2);
            }
            foreach (var type2 in Enumerable.Join(DataTableExtensions.AsEnumerable(dataTable_0), DataTableExtensions.AsEnumerable(source), delegate(DataRow dataRow_0)
            {
                return DataRowExtensions.Field<string>(dataRow_0, "LZ");
            }, delegate(DataRow dataRow_0)
            {
                return DataRowExtensions.Field<string>(dataRow_0, "CCODE");
            }, delegate(DataRow dataRow_0, DataRow dataRow_1)
            {
                return new
                {
                    dt1row = dataRow_0,
                    dt2row = dataRow_1
                };
            }))
            {
                type2.dt1row["LZ"] = type2.dt2row["CSNAME"];
            }
            System.Data.DataTable table2 = this.QYTable();
            foreach (var type3 in Enumerable.Join(DataTableExtensions.AsEnumerable(dataTable_0), DataTableExtensions.AsEnumerable(table2), delegate(DataRow dataRow_0)
            {
                return DataRowExtensions.Field<string>(dataRow_0, "QY");
            }, delegate(DataRow dataRow_0)
            {
                return DataRowExtensions.Field<string>(dataRow_0, "CCODE");
            }, delegate(DataRow dataRow_0, DataRow dataRow_1)
            {
                return new
                {
                    dt1row = dataRow_0,
                    dt2row = dataRow_1
                };
            }))
            {
                type3.dt1row["QY"] = type3.dt2row["CSNAME"];
            }
            return dataTable_0;
        }

        private System.Data.DataTable B4()
        {
            System.Data.DataTable table = new System.Data.DataTable("ResultTable");
            DataColumn column = new DataColumn("TJDW", typeof(string));
            table.Columns.Add(column);
            column = new DataColumn("LDQS", typeof(string));
            table.Columns.Add(column);
            column = new DataColumn("QY", typeof(string));
            table.Columns.Add(column);
            column = new DataColumn("YSSZ", typeof(string));
            table.Columns.Add(column);
            column = new DataColumn("MJHJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("XJHJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("YLLMJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("YLLXJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("ZLLMJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("ZLLXJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("JSLMJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("JSLXJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("CSLMJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("CSLXJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("GSLMJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("GSLXJ", typeof(double));
            table.Columns.Add(column);
            return table;
        }

        private System.Data.DataTable B4_1()
        {
            System.Data.DataTable table = new System.Data.DataTable("ResultTable");
            DataColumn column = new DataColumn("TJDW", typeof(string));
            table.Columns.Add(column);
            column = new DataColumn("LMQS", typeof(string));
            table.Columns.Add(column);
            column = new DataColumn("QY", typeof(string));
            table.Columns.Add(column);
            column = new DataColumn("YSSZ", typeof(string));
            table.Columns.Add(column);
            column = new DataColumn("MJHJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("XJHJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("YLLMJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("YLLXJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("ZLLMJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("ZLLXJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("JSLMJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("JSLXJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("CSLMJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("CSLXJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("GSLMJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("GSLXJ", typeof(double));
            table.Columns.Add(column);
            return table;
        }

        public System.Data.DataTable B4_1TJByXianXiangCun(string ydzl)
        {
            System.Data.DataTable table = new System.Data.DataTable("ResultTable");
            table = this.B4_1();
            System.Data.DataTable mytjdt = new System.Data.DataTable();
            string cmdtxt = "SELECT LTRIM(RTRIM(SHI)) AS SHI,LTRIM(RTRIM(XIAN)) AS XIAN,LTRIM(RTRIM(XIANG)) AS XIANG,LTRIM(RTRIM(CUN)) AS CUN,LTRIM(RTRIM(LMSYQ)) AS LMQS,";
            string str2 = cmdtxt + "LTRIM(RTRIM(YOU_SHI_SZ)) AS YSSZ,LTRIM(RTRIM(QI_YUAN)) AS QY,LTRIM(RTRIM(LING_ZU)) AS LING_ZU,LTRIM(RTRIM(JJLCQ)) AS JJLCQ,SUM(MIAN_JI) AS MIAN_JI,SUM(SLXJ) AS SLXJ FROM " + TABLE_ZZYTableName;
            cmdtxt = (str2 + "  WHERE (RTRIM(LTRIM(XMMC))='" + TABLE_ZZYXMMC + "') AND LEN(RTRIM(LTRIM(QI_YUAN)))>0 AND (RTRIM(LTRIM(YDZL))='" + ydzl + "')") + " GROUP BY SHI,XIAN,XIANG,CUN,LMSYQ,YOU_SHI_SZ,QI_YUAN,LING_ZU,JJLCQ  ";
            mytjdt = this.GetTable(cmdtxt, TABLE_ZZYTableName);
            if (mytjdt == null)
            {
                MessageBox.Show(TABLE_ZZYTableName + " B4-1统计长期用地出错！", "信息", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return null;
            }
            if (mytjdt.Rows.Count == 0)
            {
                return table;
            }
            List<int> distXMQLMQSList = new List<int>();
            List<int> distXMQQYList = new List<int>();
            List<int> distXMQSZList = new List<int>();
            List<string> list11 = new List<string>();
            for (int i = 0; i < mytjdt.Rows.Count; i++)
            {
                string item = mytjdt.Rows[i]["SHI"].ToString();
                if (!list11.Contains(item))
                {
                    list11.Add(item);
                }
                if (mytjdt.Rows[i]["LMQS"].ToString().Trim().Length == 0)
                {
                    mytjdt.Rows[i]["LMQS"] = 0;
                }
                short num22 = Convert.ToInt16(mytjdt.Rows[i]["LMQS"].ToString());
                if (!distXMQLMQSList.Contains(num22))
                {
                    distXMQLMQSList.Add(num22);
                }
                if (mytjdt.Rows[i]["QY"].ToString().Trim().Length == 0)
                {
                    mytjdt.Rows[i]["QY"] = 0;
                }
                short num23 = Convert.ToInt16(mytjdt.Rows[i]["QY"].ToString());
                mytjdt.Rows[i]["QY"] = ((num23 / 10)).ToString() + "0";
                num23 = Convert.ToInt16(mytjdt.Rows[i]["QY"].ToString());
                if (!distXMQQYList.Contains(num23))
                {
                    distXMQQYList.Add(num23);
                }
                if (mytjdt.Rows[i]["YSSZ"].ToString().Trim().Length == 0)
                {
                    mytjdt.Rows[i]["YSSZ"] = 0;
                }
                int num10 = Convert.ToInt32(mytjdt.Rows[i]["YSSZ"].ToString());
                if (!distXMQSZList.Contains(num10))
                {
                    distXMQSZList.Add(num10);
                }
            }
            distXMQLMQSList.Sort();
            distXMQQYList.Sort();
            distXMQSZList.Sort();
            list11.Sort();
            System.Data.DataTable table5 = mytjdt.Clone();
            List<int> list8 = new List<int>();
            List<int> list9 = new List<int>();
            List<int> list10 = new List<int>();
            List<string> list12 = new List<string>();
            System.Data.DataTable table6 = mytjdt.Clone();
            List<int> list13 = new List<int>();
            List<int> list17 = new List<int>();
            List<int> list18 = new List<int>();
            table = this.B4_1TJTable("项目区", mytjdt, distXMQLMQSList, distXMQQYList, distXMQSZList);
            for (int j = 0; j < list11.Count; j++)
            {
                table5.Clear();
                list8.Clear();
                list9.Clear();
                list10.Clear();
                string tjdw = list11[j].ToString();
                foreach (DataRow row4 in mytjdt.Select("SHI='" + tjdw + "'"))
                {
                    table5.Rows.Add(row4.ItemArray);
                }
                list12.Clear();
                for (int k = 0; k < table5.Rows.Count; k++)
                {
                    string str6 = table5.Rows[k]["LMQS"].ToString().Trim();
                    if (str6.Length > 0)
                    {
                        short num12 = Convert.ToInt16(str6);
                        if (!list8.Contains(num12))
                        {
                            list8.Add(num12);
                        }
                    }
                    short num20 = Convert.ToInt16(table5.Rows[k]["QY"].ToString());
                    if (!list9.Contains(num20))
                    {
                        list9.Add(num20);
                    }
                    int num14 = Convert.ToInt32(table5.Rows[k]["YSSZ"].ToString());
                    if (!list10.Contains(num14))
                    {
                        list10.Add(num14);
                    }
                    string str9 = table5.Rows[k]["XIAN"].ToString();
                    if (!list12.Contains(str9))
                    {
                        list12.Add(str9);
                    }
                }
                list8.Sort();
                list9.Sort();
                list10.Sort();
                list12.Sort();
                System.Data.DataTable table7 = this.B4_1TJTable(tjdw, table5, list8, list9, list10);
                foreach (DataRow row8 in table7.Rows)
                {
                    table.ImportRow(row8);
                }
                for (int m = 0; m < list12.Count; m++)
                {
                    table6.Clear();
                    list13.Clear();
                    list17.Clear();
                    list18.Clear();
                    string str7 = list12[m].ToString();
                    foreach (DataRow row3 in table5.Select("XIAN='" + str7 + "'"))
                    {
                        table6.Rows.Add(row3.ItemArray);
                    }
                    List<string> list19 = new List<string>();
                    for (int n = 0; n < table6.Rows.Count; n++)
                    {
                        string str19 = table6.Rows[n]["LMQS"].ToString().Trim();
                        if (str19.Length > 0)
                        {
                            short num8 = Convert.ToInt16(str19);
                            if (!list13.Contains(num8))
                            {
                                list13.Add(num8);
                            }
                        }
                        short num26 = Convert.ToInt16(table6.Rows[n]["QY"].ToString());
                        if (!list17.Contains(num26))
                        {
                            list17.Add(num26);
                        }
                        int num16 = Convert.ToInt32(table6.Rows[n]["YSSZ"].ToString());
                        if (!list18.Contains(num16))
                        {
                            list18.Add(num16);
                        }
                        string str18 = table6.Rows[n]["XIANG"].ToString();
                        if (!list19.Contains(str18))
                        {
                            list19.Add(str18);
                        }
                    }
                    list13.Sort();
                    list17.Sort();
                    list18.Sort();
                    list19.Sort();
                    table7.Clear();
                    table7 = this.B4_1TJTable(str7, table6, list13, list17, list18);
                    foreach (DataRow row7 in table7.Rows)
                    {
                        table.ImportRow(row7);
                    }
                    System.Data.DataTable table3 = mytjdt.Clone();
                    List<int> list = new List<int>();
                    List<int> list2 = new List<int>();
                    List<int> list3 = new List<int>();
                    List<string> list4 = new List<string>();
                    System.Data.DataTable table4 = mytjdt.Clone();
                    List<int> list5 = new List<int>();
                    List<int> list6 = new List<int>();
                    List<int> list7 = new List<int>();
                    for (int num2 = 0; num2 < list19.Count; num2++)
                    {
                        string str17 = list19[num2].ToString();
                        DataRow[] rowArray4 = mytjdt.Select("XIANG='" + str17 + "'");
                        table3.Clear();
                        foreach (DataRow row2 in rowArray4)
                        {
                            table3.Rows.Add(row2.ItemArray);
                        }
                        list.Clear();
                        list2.Clear();
                        list3.Clear();
                        for (int num = 0; num < table3.Rows.Count; num++)
                        {
                            string str23 = table3.Rows[num]["CUN"].ToString();
                            if (!list4.Contains(str23))
                            {
                                list4.Add(str23);
                            }
                            string str8 = table3.Rows[num]["LMQS"].ToString().Trim();
                            if (str8.Length > 0)
                            {
                                short num13 = Convert.ToInt16(str8);
                                if (!list.Contains(num13))
                                {
                                    list.Add(num13);
                                }
                            }
                            short num25 = Convert.ToInt16(table3.Rows[num]["QY"].ToString());
                            if (!list2.Contains(num25))
                            {
                                list2.Add(num25);
                            }
                            int num6 = Convert.ToInt32(table3.Rows[num]["YSSZ"].ToString());
                            if (!list3.Contains(num6))
                            {
                                list3.Add(num6);
                            }
                        }
                        list4.Sort();
                        list.Sort();
                        list3.Sort();
                        list2.Sort();
                        table7.Clear();
                        table7 = this.B4_1TJTable(str17, table3, list, list2, list3);
                        foreach (DataRow row6 in table7.Rows)
                        {
                            table.ImportRow(row6);
                        }
                        for (int num17 = 0; num17 < list4.Count; num17++)
                        {
                            string str16 = list4[num17].ToString();
                            DataRow[] rowArray5 = table3.Select("CUN='" + str16 + "'");
                            table4.Clear();
                            foreach (DataRow row5 in rowArray5)
                            {
                                table4.Rows.Add(row5.ItemArray);
                            }
                            list5.Clear();
                            list7.Clear();
                            list6.Clear();
                            for (int num18 = 0; num18 < table4.Rows.Count; num18++)
                            {
                                string s = table4.Rows[num18]["LMQS"].ToString().Trim();
                                if ((s.Length > 0) && (short.Parse(s) >= 0))
                                {
                                    short num5 = Convert.ToInt16(s);
                                    if (!list5.Contains(num5))
                                    {
                                        list5.Add(num5);
                                    }
                                }
                                short num21 = Convert.ToInt16(table4.Rows[num18]["QY"].ToString());
                                if (!list6.Contains(num21))
                                {
                                    list6.Add(num21);
                                }
                                int num19 = Convert.ToInt32(table4.Rows[num18]["YSSZ"].ToString());
                                if (!list7.Contains(num19))
                                {
                                    list7.Add(num19);
                                }
                            }
                            list5.Sort();
                            list7.Sort();
                            list6.Sort();
                            table7.Clear();
                            table7 = this.B4_1TJTable(str16, table4, list5, list6, list7);
                            foreach (DataRow row in table7.Rows)
                            {
                                table.ImportRow(row);
                            }
                        }
                    }
                    table3.Clear();
                    table4.Clear();
                }
            }
            table5.Clear();
            table6.Clear();
            mytjdt.Clear();
            table = this.UpdateDWTableByJoin(table);
            return this.B4UpdateTableByJoin(table, "LMQS", "209");
        }

        private System.Data.DataTable B4_1TJTable(string tjdw, System.Data.DataTable mytjdt, List<int> DistXMQLMQSList, List<int> DistXMQQYList, List<int> DistXMQSZList)
        {
            System.Data.DataTable table = this.B4_1();
            string expression = "SUM(MIAN_JI)";
            string str2 = "SUM(SLXJ)";
            string str3 = " LING_ZU ='1'";
            string str4 = " LING_ZU ='2'";
            string str5 = " LING_ZU ='3'";
            string str6 = " LING_ZU ='4'";
            string str7 = " LING_ZU ='5'";
            string str8 = " JJLCQ ='1'";
            string str9 = " JJLCQ ='2'";
            string str10 = " JJLCQ ='3'";
            string str11 = " JJLCQ ='4'";
            double num = 0.0;
            double num2 = 0.0;
            double num3 = 0.0;
            double num4 = 0.0;
            double num5 = 0.0;
            double num6 = 0.0;
            double num7 = 0.0;
            double num8 = 0.0;
            double num9 = 0.0;
            double num10 = 0.0;
            double num11 = 0.0;
            double num12 = 0.0;
            DataRow row = table.NewRow();
            for (int i = 0; i < DistXMQSZList.Count; i++)
            {
                num = 0.0;
                num2 = 0.0;
                num3 = 0.0;
                num4 = 0.0;
                num5 = 0.0;
                num6 = 0.0;
                num7 = 0.0;
                num8 = 0.0;
                num9 = 0.0;
                num10 = 0.0;
                num11 = 0.0;
                num12 = 0.0;
                row = table.NewRow();
                string str15 = DistXMQSZList[i].ToString();
                string str14 = "YSSZ='" + str15 + "' AND ";
                if (mytjdt.Select(str14 + str3).Length > 0)
                {
                    num3 = Convert.ToDouble(mytjdt.Compute(expression, str14 + str3));
                    num8 = Convert.ToDouble(mytjdt.Compute(str2, str14 + str3));
                }
                if (mytjdt.Select(str14 + str4).Length > 0)
                {
                    num4 = Convert.ToDouble(mytjdt.Compute(expression, str14 + str4));
                    num9 = Convert.ToDouble(mytjdt.Compute(str2, str14 + str4));
                }
                if (mytjdt.Select(str14 + str5).Length > 0)
                {
                    num5 = Convert.ToDouble(mytjdt.Compute(expression, str14 + str5));
                    num10 = Convert.ToDouble(mytjdt.Compute(str2, str14 + str5));
                }
                if (mytjdt.Select(str14 + str6).Length > 0)
                {
                    num6 = Convert.ToDouble(mytjdt.Compute(expression, str14 + str6));
                    num11 = Convert.ToDouble(mytjdt.Compute(str2, str14 + str6));
                }
                if (mytjdt.Select(str14 + str7).Length > 0)
                {
                    num7 = Convert.ToDouble(mytjdt.Compute(expression, str14 + str7));
                    num12 = Convert.ToDouble(mytjdt.Compute(str2, str14 + str7));
                }
                if (mytjdt.Select(str14 + str8).Length > 0)
                {
                    num3 = Convert.ToDouble(mytjdt.Compute(expression, str14 + str8));
                    num8 = Convert.ToDouble(mytjdt.Compute(str2, str14 + str8));
                }
                if (mytjdt.Select(str14 + str9).Length > 0)
                {
                    num4 = Convert.ToDouble(mytjdt.Compute(expression, str14 + str9));
                    num9 = Convert.ToDouble(mytjdt.Compute(str2, str14 + str9));
                }
                if (mytjdt.Select(str14 + str10).Length > 0)
                {
                    num6 = Convert.ToDouble(mytjdt.Compute(expression, str14 + str10));
                    num11 = Convert.ToDouble(mytjdt.Compute(str2, str14 + str10));
                }
                if (mytjdt.Select(str14 + str11).Length > 0)
                {
                    num7 = Convert.ToDouble(mytjdt.Compute(expression, str14 + str11));
                    num12 = Convert.ToDouble(mytjdt.Compute(str2, str14 + str11));
                }
                num = (((num3 + num4) + num5) + num6) + num7;
                num2 = (((num8 + num9) + num10) + num11) + num12;
                row["YSSZ"] = str15;
                row["MJHJ"] = num;
                row["XJHJ"] = num2;
                row["YLLMJ"] = num3;
                row["YLLXJ"] = num8;
                row["ZLLMJ"] = num4;
                row["ZLLXJ"] = num9;
                row["JSLMJ"] = num5;
                row["JSLXJ"] = num10;
                row["CSLMJ"] = num6;
                row["CSLXJ"] = num11;
                row["GSLMJ"] = num7;
                row["GSLXJ"] = num12;
                if (num > 0.0)
                {
                    table.Rows.Add(row);
                }
            }
            row = table.NewRow();
            row["TJDW"] = tjdw;
            row["YSSZ"] = "合计";
            if (table.Rows.Count > 0)
            {
                for (int k = 4; k < table.Columns.Count; k++)
                {
                    row[k] = Convert.ToDouble(table.Compute("SUM(" + table.Columns[k] + ")", null));
                }
                table.Rows.InsertAt(row, 0);
            }
            for (int j = 0; j < DistXMQLMQSList.Count; j++)
            {
                string str16 = DistXMQLMQSList[j].ToString();
                string str13 = "LMQS='" + str16 + "' AND ";
                num = 0.0;
                num2 = 0.0;
                num3 = 0.0;
                num4 = 0.0;
                num5 = 0.0;
                num6 = 0.0;
                num7 = 0.0;
                num8 = 0.0;
                num9 = 0.0;
                num10 = 0.0;
                num11 = 0.0;
                num12 = 0.0;
                if (mytjdt.Select(str13 + str3).Length > 0)
                {
                    num3 = Convert.ToDouble(mytjdt.Compute(expression, str13 + str3));
                    num8 = Convert.ToDouble(mytjdt.Compute(str2, str13 + str3));
                }
                if (mytjdt.Select(str13 + str4).Length > 0)
                {
                    num4 = Convert.ToDouble(mytjdt.Compute(expression, str13 + str4));
                    num9 = Convert.ToDouble(mytjdt.Compute(str2, str13 + str4));
                }
                if (mytjdt.Select(str13 + str5).Length > 0)
                {
                    num5 = Convert.ToDouble(mytjdt.Compute(expression, str13 + str5));
                    num10 = Convert.ToDouble(mytjdt.Compute(str2, str13 + str5));
                }
                if (mytjdt.Select(str13 + str6).Length > 0)
                {
                    num6 = Convert.ToDouble(mytjdt.Compute(expression, str13 + str6));
                    num11 = Convert.ToDouble(mytjdt.Compute(str2, str13 + str6));
                }
                if (mytjdt.Select(str13 + str7).Length > 0)
                {
                    num7 = Convert.ToDouble(mytjdt.Compute(expression, str13 + str7));
                    num12 = Convert.ToDouble(mytjdt.Compute(str2, str13 + str7));
                }
                if (mytjdt.Select(str13 + str8).Length > 0)
                {
                    num3 += Convert.ToDouble(mytjdt.Compute(expression, str13 + str8));
                    num8 += Convert.ToDouble(mytjdt.Compute(str2, str13 + str8));
                }
                if (mytjdt.Select(str13 + str9).Length > 0)
                {
                    num4 += Convert.ToDouble(mytjdt.Compute(expression, str13 + str9));
                    num9 += Convert.ToDouble(mytjdt.Compute(str2, str13 + str9));
                }
                if (mytjdt.Select(str13 + str10).Length > 0)
                {
                    num6 += Convert.ToDouble(mytjdt.Compute(expression, str13 + str10));
                    num11 += Convert.ToDouble(mytjdt.Compute(str2, str13 + str10));
                }
                if (mytjdt.Select(str13 + str11).Length > 0)
                {
                    num7 += Convert.ToDouble(mytjdt.Compute(expression, str13 + str11));
                    num12 += Convert.ToDouble(mytjdt.Compute(str2, str13 + str11));
                }
                num = (((num3 + num4) + num5) + num6) + num7;
                num2 = (((num8 + num9) + num10) + num11) + num12;
                DataRow row2 = table.NewRow();
                row2["LMQS"] = str16;
                row2["YSSZ"] = "小计";
                row2["MJHJ"] = num;
                row2["XJHJ"] = num2;
                row2["YLLMJ"] = num3;
                row2["YLLXJ"] = num8;
                row2["ZLLMJ"] = num4;
                row2["ZLLXJ"] = num9;
                row2["JSLMJ"] = num5;
                row2["JSLXJ"] = num10;
                row2["CSLMJ"] = num6;
                row2["CSLXJ"] = num11;
                row2["GSLMJ"] = num7;
                row2["GSLXJ"] = num12;
                if (num > 0.0)
                {
                    table.Rows.Add(row2);
                }
                for (int m = 0; m < DistXMQQYList.Count; m++)
                {
                    string str12 = DistXMQQYList[m].ToString();
                    str13 = "LMQS='" + str16 + "' AND QY='" + str12 + "' AND ";
                    num = 0.0;
                    num2 = 0.0;
                    num3 = 0.0;
                    num4 = 0.0;
                    num5 = 0.0;
                    num6 = 0.0;
                    num7 = 0.0;
                    num8 = 0.0;
                    num9 = 0.0;
                    num10 = 0.0;
                    num11 = 0.0;
                    num12 = 0.0;
                    if (mytjdt.Select(str13 + str3).Length > 0)
                    {
                        num3 = Convert.ToDouble(mytjdt.Compute(expression, str13 + str3));
                        num8 = Convert.ToDouble(mytjdt.Compute(str2, str13 + str3));
                    }
                    if (mytjdt.Select(str13 + str4).Length > 0)
                    {
                        num4 = Convert.ToDouble(mytjdt.Compute(expression, str13 + str4));
                        num9 = Convert.ToDouble(mytjdt.Compute(str2, str13 + str4));
                    }
                    if (mytjdt.Select(str13 + str5).Length > 0)
                    {
                        num5 = Convert.ToDouble(mytjdt.Compute(expression, str13 + str5));
                        num10 = Convert.ToDouble(mytjdt.Compute(str2, str13 + str5));
                    }
                    if (mytjdt.Select(str13 + str6).Length > 0)
                    {
                        num6 = Convert.ToDouble(mytjdt.Compute(expression, str13 + str6));
                        num11 = Convert.ToDouble(mytjdt.Compute(str2, str13 + str6));
                    }
                    if (mytjdt.Select(str13 + str7).Length > 0)
                    {
                        num7 = Convert.ToDouble(mytjdt.Compute(expression, str13 + str7));
                        num12 = Convert.ToDouble(mytjdt.Compute(str2, str13 + str7));
                    }
                    if (mytjdt.Select(str13 + str8).Length > 0)
                    {
                        num3 += Convert.ToDouble(mytjdt.Compute(expression, str13 + str8));
                        num8 += Convert.ToDouble(mytjdt.Compute(str2, str13 + str8));
                    }
                    if (mytjdt.Select(str13 + str9).Length > 0)
                    {
                        num4 += Convert.ToDouble(mytjdt.Compute(expression, str13 + str9));
                        num9 += Convert.ToDouble(mytjdt.Compute(str2, str13 + str9));
                    }
                    if (mytjdt.Select(str13 + str10).Length > 0)
                    {
                        num6 += Convert.ToDouble(mytjdt.Compute(expression, str13 + str10));
                        num11 += Convert.ToDouble(mytjdt.Compute(str2, str13 + str10));
                    }
                    if (mytjdt.Select(str13 + str11).Length > 0)
                    {
                        num7 += Convert.ToDouble(mytjdt.Compute(expression, str13 + str11));
                        num12 += Convert.ToDouble(mytjdt.Compute(str2, str13 + str11));
                    }
                    num = (((num3 + num4) + num5) + num6) + num7;
                    num2 = (((num8 + num9) + num10) + num11) + num12;
                    row2 = table.NewRow();
                    row2["QY"] = str12;
                    row2["YSSZ"] = "计";
                    row2["MJHJ"] = num;
                    row2["XJHJ"] = num2;
                    row2["YLLMJ"] = num3;
                    row2["YLLXJ"] = num8;
                    row2["ZLLMJ"] = num4;
                    row2["ZLLXJ"] = num9;
                    row2["JSLMJ"] = num5;
                    row2["JSLXJ"] = num10;
                    row2["CSLMJ"] = num6;
                    row2["CSLXJ"] = num11;
                    row2["GSLMJ"] = num7;
                    row2["GSLXJ"] = num12;
                    if (num > 0.0)
                    {
                        table.Rows.Add(row2);
                    }
                    for (int n = 0; n < DistXMQSZList.Count; n++)
                    {
                        string str17 = DistXMQSZList[n].ToString();
                        str13 = "LMQS='" + str16 + "' AND QY='" + str12 + "' AND YSSZ='" + str17 + "' AND ";
                        num = 0.0;
                        num2 = 0.0;
                        num3 = 0.0;
                        num4 = 0.0;
                        num5 = 0.0;
                        num6 = 0.0;
                        num7 = 0.0;
                        num8 = 0.0;
                        num9 = 0.0;
                        num10 = 0.0;
                        num11 = 0.0;
                        num12 = 0.0;
                        if (mytjdt.Select(str13 + str3).Length > 0)
                        {
                            num3 = Convert.ToDouble(mytjdt.Compute(expression, str13 + str3));
                            num8 = Convert.ToDouble(mytjdt.Compute(str2, str13 + str3));
                        }
                        if (mytjdt.Select(str13 + str4).Length > 0)
                        {
                            num4 = Convert.ToDouble(mytjdt.Compute(expression, str13 + str4));
                            num9 = Convert.ToDouble(mytjdt.Compute(str2, str13 + str4));
                        }
                        if (mytjdt.Select(str13 + str5).Length > 0)
                        {
                            num5 = Convert.ToDouble(mytjdt.Compute(expression, str13 + str5));
                            num10 = Convert.ToDouble(mytjdt.Compute(str2, str13 + str5));
                        }
                        if (mytjdt.Select(str13 + str6).Length > 0)
                        {
                            num6 = Convert.ToDouble(mytjdt.Compute(expression, str13 + str6));
                            num11 = Convert.ToDouble(mytjdt.Compute(str2, str13 + str6));
                        }
                        if (mytjdt.Select(str13 + str7).Length > 0)
                        {
                            num7 = Convert.ToDouble(mytjdt.Compute(expression, str13 + str7));
                            num12 = Convert.ToDouble(mytjdt.Compute(str2, str13 + str7));
                        }
                        if (mytjdt.Select(str13 + str8).Length > 0)
                        {
                            num3 = Convert.ToDouble(mytjdt.Compute(expression, str13 + str8));
                            num8 = Convert.ToDouble(mytjdt.Compute(str2, str13 + str8));
                        }
                        if (mytjdt.Select(str13 + str9).Length > 0)
                        {
                            num4 = Convert.ToDouble(mytjdt.Compute(expression, str13 + str9));
                            num9 = Convert.ToDouble(mytjdt.Compute(str2, str13 + str9));
                        }
                        if (mytjdt.Select(str13 + str10).Length > 0)
                        {
                            num6 = Convert.ToDouble(mytjdt.Compute(expression, str13 + str10));
                            num11 = Convert.ToDouble(mytjdt.Compute(str2, str13 + str10));
                        }
                        if (mytjdt.Select(str13 + str11).Length > 0)
                        {
                            num7 = Convert.ToDouble(mytjdt.Compute(expression, str13 + str11));
                            num12 = Convert.ToDouble(mytjdt.Compute(str2, str13 + str11));
                        }
                        num = (((num3 + num4) + num5) + num6) + num7;
                        num2 = (((num8 + num9) + num10) + num11) + num12;
                        row2 = table.NewRow();
                        row2["YSSZ"] = str17;
                        row2["MJHJ"] = num;
                        row2["XJHJ"] = num2;
                        row2["YLLMJ"] = num3;
                        row2["YLLXJ"] = num8;
                        row2["ZLLMJ"] = num4;
                        row2["ZLLXJ"] = num9;
                        row2["JSLMJ"] = num5;
                        row2["JSLXJ"] = num10;
                        row2["CSLMJ"] = num6;
                        row2["CSLXJ"] = num11;
                        row2["GSLMJ"] = num7;
                        row2["GSLXJ"] = num12;
                        if (num > 0.0)
                        {
                            table.Rows.Add(row2);
                        }
                    }
                }
            }
            return table;
        }

        public System.Data.DataTable B4TJByXianXiangCun(string ydzl)
        {
            System.Data.DataTable table = new System.Data.DataTable("ResultTable");
            table = this.B4();
            System.Data.DataTable mytjdt = new System.Data.DataTable();
            string cmdtxt = "SELECT LTRIM(RTRIM(SHI)) AS SHI,LTRIM(RTRIM(XIAN)) AS XIAN,LTRIM(RTRIM(XIANG)) AS XIANG,LTRIM(RTRIM(CUN)) AS CUN,LTRIM(RTRIM(Q_LD_QS)) AS LDQS,";
            string str2 = cmdtxt + "LTRIM(RTRIM(YOU_SHI_SZ)) AS YSSZ,LTRIM(RTRIM(QI_YUAN)) AS QY,LTRIM(RTRIM(LING_ZU)) AS LING_ZU,LTRIM(RTRIM(JJLCQ)) AS JJLCQ,SUM(MIAN_JI) AS MIAN_JI,SUM(SLXJ) AS SLXJ FROM " + TABLE_ZZYTableName;
            cmdtxt = (str2 + "  WHERE (RTRIM(LTRIM(XMMC))='" + TABLE_ZZYXMMC + "') AND LEN(RTRIM(LTRIM(QI_YUAN)))>0 AND (RTRIM(LTRIM(YDZL))='" + ydzl + "')") + " GROUP BY SHI,XIAN,XIANG,CUN,Q_LD_QS,YOU_SHI_SZ,QI_YUAN,LING_ZU,JJLCQ  ";
            mytjdt = this.GetTable(cmdtxt, TABLE_ZZYTableName);
            if (mytjdt == null)
            {
                MessageBox.Show(TABLE_ZZYTableName + " B4统计长期用地出错！", "信息", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return null;
            }
            if (mytjdt.Rows.Count == 0)
            {
                return table;
            }
            List<short> distXMQLDQSList = new List<short>();
            List<short> distXMQQYList = new List<short>();
            List<int> distXMQSZList = new List<int>();
            List<string> list13 = new List<string>();
            for (int i = 0; i < mytjdt.Rows.Count; i++)
            {
                string item = mytjdt.Rows[i]["SHI"].ToString();
                if (!list13.Contains(item))
                {
                    list13.Add(item);
                }
                if (mytjdt.Rows[i]["LDQS"].ToString().Trim().Length == 0)
                {
                    mytjdt.Rows[i]["LDQS"] = 0;
                }
                short num22 = Convert.ToInt16(mytjdt.Rows[i]["LDQS"].ToString());
                if (num22 >= 20)
                {
                    mytjdt.Rows[i]["LDQS"] = "20";
                    num22 = Convert.ToInt16(mytjdt.Rows[i]["LDQS"].ToString());
                }
                if (!distXMQLDQSList.Contains(num22))
                {
                    distXMQLDQSList.Add(num22);
                }
                if (mytjdt.Rows[i]["QY"].ToString().Trim().Length == 0)
                {
                    mytjdt.Rows[i]["QY"] = 0;
                }
                short num13 = Convert.ToInt16(mytjdt.Rows[i]["QY"].ToString());
                mytjdt.Rows[i]["QY"] = ((num13 / 10)).ToString() + "0";
                num13 = Convert.ToInt16(mytjdt.Rows[i]["QY"].ToString());
                if (!distXMQQYList.Contains(num13))
                {
                    distXMQQYList.Add(num13);
                }
                if (mytjdt.Rows[i]["YSSZ"].ToString().Trim().Length == 0)
                {
                    mytjdt.Rows[i]["YSSZ"] = 0;
                }
                int num15 = Convert.ToInt32(mytjdt.Rows[i]["YSSZ"].ToString());
                ///short num15 = Convert.ToInt16(mytjdt.Rows[i]["YSSZ"].ToString());//内存溢出，强制转换失败
                if (!distXMQSZList.Contains(num15))
                {
                    distXMQSZList.Add(num15);
                }
            }
            distXMQLDQSList.Sort();
            distXMQQYList.Sort();
            distXMQSZList.Sort();
            list13.Sort();
            System.Data.DataTable table4 = mytjdt.Clone();
            List<short> list10 = new List<short>();
            List<short> list11 = new List<short>();
            List<int> list12 = new List<int>();
            List<string> list3 = new List<string>();
            System.Data.DataTable table7 = mytjdt.Clone();
            List<short> list6 = new List<short>();
            List<short> list7 = new List<short>();
            List<int> list8 = new List<int>();
            table = this.B4TJTable("项目区", mytjdt, distXMQLDQSList, distXMQQYList, distXMQSZList);
            for (int j = 0; j < list13.Count; j++)
            {
                table4.Clear();
                list10.Clear();
                list11.Clear();
                list12.Clear();
                string tjdw = list13[j].ToString();
                foreach (DataRow row2 in mytjdt.Select("SHI='" + tjdw + "'"))
                {
                    table4.Rows.Add(row2.ItemArray);
                }
                list3.Clear();
                for (int k = 0; k < table4.Rows.Count; k++)
                {
                    string str10 = table4.Rows[k]["LDQS"].ToString().Trim();
                    if (str10.Length > 0)
                    {
                        short num11 = Convert.ToInt16(str10);
                        if (!list10.Contains(num11))
                        {
                            list10.Add(num11);
                        }
                    }
                    short num16 = Convert.ToInt16(table4.Rows[k]["QY"].ToString());
                    if (!list11.Contains(num16))
                    {
                        list11.Add(num16);
                    }
                    ///short num24 = Convert.ToInt16(table4.Rows[k]["YSSZ"].ToString());//内存溢出，强制转换失败
                    int num24 = Convert.ToInt32(table4.Rows[k]["YSSZ"].ToString());
                    if (!list12.Contains(num24))
                    {
                        list12.Add(num24);
                    }
                    string str22 = table4.Rows[k]["XIAN"].ToString();
                    if (!list3.Contains(str22))
                    {
                        list3.Add(str22);
                    }
                }
                list10.Sort();
                list11.Sort();
                list12.Sort();
                list3.Sort();
                System.Data.DataTable table6 = this.B4TJTable(tjdw, table4, list10, list11, list12);
                foreach (DataRow row3 in table6.Rows)
                {
                    table.ImportRow(row3);
                }
                for (int m = 0; m < list3.Count; m++)
                {
                    table7.Clear();
                    list6.Clear();
                    list7.Clear();
                    list8.Clear();
                    string str7 = list3[m].ToString();
                    foreach (DataRow row8 in table4.Select("XIAN='" + str7 + "'"))
                    {
                        table7.Rows.Add(row8.ItemArray);
                    }
                    List<string> list2 = new List<string>();
                    for (int n = 0; n < table7.Rows.Count; n++)
                    {
                        string str17 = table7.Rows[n]["LDQS"].ToString().Trim();
                        if (str17.Length > 0)
                        {
                            short num19 = Convert.ToInt16(str17);
                            if (!list6.Contains(num19))
                            {
                                list6.Add(num19);
                            }
                        }
                        short num26 = Convert.ToInt16(table7.Rows[n]["QY"].ToString());
                        if (!list7.Contains(num26))
                        {
                            list7.Add(num26);
                        }
                        int num21 = Convert.ToInt32(table7.Rows[n]["YSSZ"].ToString());
                        if (!list8.Contains(num21))
                        {
                            list8.Add(num21);
                        }
                        string str21 = table7.Rows[n]["XIANG"].ToString();
                        if (!list2.Contains(str21))
                        {
                            list2.Add(str21);
                        }
                    }
                    list6.Sort();
                    list7.Sort();
                    list8.Sort();
                    list2.Sort();
                    table6.Clear();
                    table6 = this.B4TJTable(str7, table7, list6, list7, list8);
                    foreach (DataRow row6 in table6.Rows)
                    {
                        table.ImportRow(row6);
                    }
                    System.Data.DataTable table3 = mytjdt.Clone();
                    List<short> list9 = new List<short>();
                    List<short> list18 = new List<short>();
                    List<int> list19 = new List<int>();
                    List<string> list17 = new List<string>();
                    System.Data.DataTable table5 = mytjdt.Clone();
                    List<short> list = new List<short>();
                    List<short> list5 = new List<short>();
                    List<int> list4 = new List<int>();
                    for (int num2 = 0; num2 < list2.Count; num2++)
                    {
                        string str4 = list2[num2].ToString();
                        DataRow[] rowArray = mytjdt.Select("XIANG='" + str4 + "'");
                        table3.Clear();
                        foreach (DataRow row7 in rowArray)
                        {
                            table3.Rows.Add(row7.ItemArray);
                        }
                        list9.Clear();
                        list18.Clear();
                        list19.Clear();
                        for (int num9 = 0; num9 < table3.Rows.Count; num9++)
                        {
                            string str13 = table3.Rows[num9]["CUN"].ToString();
                            if (!list17.Contains(str13))
                            {
                                list17.Add(str13);
                            }
                            string str8 = table3.Rows[num9]["LDQS"].ToString().Trim();
                            if (str8.Length > 0)
                            {
                                short num10 = Convert.ToInt16(str8);
                                if (!list9.Contains(num10))
                                {
                                    list9.Add(num10);
                                }
                            }
                            short num23 = Convert.ToInt16(table3.Rows[num9]["QY"].ToString());
                            if (!list18.Contains(num23))
                            {
                                list18.Add(num23);
                            }
                            ///short num25 = Convert.ToInt16(table3.Rows[num9]["YSSZ"].ToString());///1强制转换失败，内存溢出
                            int num25 = Convert.ToInt32(table3.Rows[num9]["YSSZ"].ToString());
                            if (!list19.Contains(num25))
                            {
                                list19.Add(num25);
                            }
                        }
                        list17.Sort();
                        list9.Sort();
                        list19.Sort();
                        list18.Sort();
                        table6.Clear();
                        table6 = this.B4TJTable(str4, table3, list9, list18, list19);
                        foreach (DataRow row5 in table6.Rows)
                        {
                            table.ImportRow(row5);
                        }
                        for (int num18 = 0; num18 < list17.Count; num18++)
                        {
                            string str6 = list17[num18].ToString();
                            DataRow[] rowArray5 = table3.Select("CUN='" + str6 + "'");
                            table5.Clear();
                            foreach (DataRow row4 in rowArray5)
                            {
                                table5.Rows.Add(row4.ItemArray);
                            }
                            list.Clear();
                            list4.Clear();
                            list5.Clear();
                            for (int num8 = 0; num8 < table5.Rows.Count; num8++)
                            {
                                string s = table5.Rows[num8]["LDQS"].ToString().Trim();
                                if ((s.Length > 0) && (short.Parse(s) >= 0))
                                {
                                    short num = Convert.ToInt16(s);
                                    if (!list.Contains(num))
                                    {
                                        list.Add(num);
                                    }
                                }
                                short num17 = Convert.ToInt16(table5.Rows[num8]["QY"].ToString());
                                if (!list5.Contains(num17))
                                {
                                    list5.Add(num17);
                                }
                                ///short num12 = Convert.ToInt16(table5.Rows[num8]["YSSZ"].ToString());///1强制转换失败，内存溢出
                                int num12 = Convert.ToInt32(table5.Rows[num8]["YSSZ"].ToString());
                                if (!list4.Contains(num12))
                                {
                                    list4.Add(num12);
                                }
                            }
                            list.Sort();
                            list4.Sort();
                            list5.Sort();
                            table6.Clear();
                            table6 = this.B4TJTable(str6, table5, list, list5, list4);
                            foreach (DataRow row in table6.Rows)
                            {
                                table.ImportRow(row);
                            }
                        }
                    }
                    table3.Clear();
                    table5.Clear();
                }
            }
            table4.Clear();
            table7.Clear();
            mytjdt.Clear();
            table = this.UpdateDWTableByJoin(table);
            return this.B4UpdateTableByJoin(table, "LDQS", "207");
        }

        private System.Data.DataTable B4TJTable(string tjdw, System.Data.DataTable mytjdt, List<short> DistXMQLDQSList, List<short> DistXMQQYList, List<int> DistXMQSZList)
        {
            System.Data.DataTable table = this.B4();
            string expression = "SUM(MIAN_JI)";
            string str2 = "SUM(SLXJ)";
            string str3 = " LING_ZU ='1'";
            string str4 = " LING_ZU ='2'";
            string str5 = " LING_ZU ='3'";
            string str6 = " LING_ZU ='4'";
            string str7 = " LING_ZU ='5'";
            string str8 = " JJLCQ ='1'";
            string str9 = " JJLCQ ='2'";
            string str10 = " JJLCQ ='3'";
            string str11 = " JJLCQ ='4'";
            double num = 0.0;
            double num2 = 0.0;
            double num3 = 0.0;
            double num4 = 0.0;
            double num5 = 0.0;
            double num6 = 0.0;
            double num7 = 0.0;
            double num8 = 0.0;
            double num9 = 0.0;
            double num10 = 0.0;
            double num11 = 0.0;
            double num12 = 0.0;
            DataRow row = table.NewRow();
            for (int i = 0; i < DistXMQSZList.Count; i++)
            {
                num = 0.0;
                num2 = 0.0;
                num3 = 0.0;
                num4 = 0.0;
                num5 = 0.0;
                num6 = 0.0;
                num7 = 0.0;
                num8 = 0.0;
                num9 = 0.0;
                num10 = 0.0;
                num11 = 0.0;
                num12 = 0.0;
                row = table.NewRow();
                string str15 = DistXMQSZList[i].ToString();
                string str14 = "YSSZ='" + str15 + "' AND ";
                if (mytjdt.Select(str14 + str3).Length > 0)
                {
                    num3 = Convert.ToDouble(mytjdt.Compute(expression, str14 + str3));
                    num8 = Convert.ToDouble(mytjdt.Compute(str2, str14 + str3));
                }
                if (mytjdt.Select(str14 + str4).Length > 0)
                {
                    num4 = Convert.ToDouble(mytjdt.Compute(expression, str14 + str4));
                    num9 = Convert.ToDouble(mytjdt.Compute(str2, str14 + str4));
                }
                if (mytjdt.Select(str14 + str5).Length > 0)
                {
                    num5 = Convert.ToDouble(mytjdt.Compute(expression, str14 + str5));
                    num10 = Convert.ToDouble(mytjdt.Compute(str2, str14 + str5));
                }
                if (mytjdt.Select(str14 + str6).Length > 0)
                {
                    num6 = Convert.ToDouble(mytjdt.Compute(expression, str14 + str6));
                    num11 = Convert.ToDouble(mytjdt.Compute(str2, str14 + str6));
                }
                if (mytjdt.Select(str14 + str7).Length > 0)
                {
                    num7 = Convert.ToDouble(mytjdt.Compute(expression, str14 + str7));
                    num12 = Convert.ToDouble(mytjdt.Compute(str2, str14 + str7));
                }
                if (mytjdt.Select(str14 + str8).Length > 0)
                {
                    num3 = Convert.ToDouble(mytjdt.Compute(expression, str14 + str8));
                    num8 = Convert.ToDouble(mytjdt.Compute(str2, str14 + str8));
                }
                if (mytjdt.Select(str14 + str9).Length > 0)
                {
                    num4 = Convert.ToDouble(mytjdt.Compute(expression, str14 + str9));
                    num9 = Convert.ToDouble(mytjdt.Compute(str2, str14 + str9));
                }
                if (mytjdt.Select(str14 + str10).Length > 0)
                {
                    num6 = Convert.ToDouble(mytjdt.Compute(expression, str14 + str10));
                    num11 = Convert.ToDouble(mytjdt.Compute(str2, str14 + str10));
                }
                if (mytjdt.Select(str14 + str11).Length > 0)
                {
                    num7 = Convert.ToDouble(mytjdt.Compute(expression, str14 + str11));
                    num12 = Convert.ToDouble(mytjdt.Compute(str2, str14 + str11));
                }
                num = (((num3 + num4) + num5) + num6) + num7;
                num2 = (((num8 + num9) + num10) + num11) + num12;
                row["YSSZ"] = str15;
                row["MJHJ"] = num;
                row["XJHJ"] = num2;
                row["YLLMJ"] = num3;
                row["YLLXJ"] = num8;
                row["ZLLMJ"] = num4;
                row["ZLLXJ"] = num9;
                row["JSLMJ"] = num5;
                row["JSLXJ"] = num10;
                row["CSLMJ"] = num6;
                row["CSLXJ"] = num11;
                row["GSLMJ"] = num7;
                row["GSLXJ"] = num12;
                if (num > 0.0)
                {
                    table.Rows.Add(row);
                }
            }
            row = table.NewRow();
            row["TJDW"] = tjdw;
            row["YSSZ"] = "合计";
            if (table.Rows.Count > 0)
            {
                for (int k = 4; k < table.Columns.Count; k++)
                {
                    row[k] = Convert.ToDouble(table.Compute("SUM(" + table.Columns[k] + ")", null));
                }
                table.Rows.InsertAt(row, 0);
            }
            for (int j = 0; j < DistXMQLDQSList.Count; j++)
            {
                string str16 = DistXMQLDQSList[j].ToString();
                string str13 = "LDQS='" + str16 + "' AND ";
                num = 0.0;
                num2 = 0.0;
                num3 = 0.0;
                num4 = 0.0;
                num5 = 0.0;
                num6 = 0.0;
                num7 = 0.0;
                num8 = 0.0;
                num9 = 0.0;
                num10 = 0.0;
                num11 = 0.0;
                num12 = 0.0;
                if (mytjdt.Select(str13 + str3).Length > 0)
                {
                    num3 = Convert.ToDouble(mytjdt.Compute(expression, str13 + str3));
                    num8 = Convert.ToDouble(mytjdt.Compute(str2, str13 + str3));
                }
                if (mytjdt.Select(str13 + str4).Length > 0)
                {
                    num4 = Convert.ToDouble(mytjdt.Compute(expression, str13 + str4));
                    num9 = Convert.ToDouble(mytjdt.Compute(str2, str13 + str4));
                }
                if (mytjdt.Select(str13 + str5).Length > 0)
                {
                    num5 = Convert.ToDouble(mytjdt.Compute(expression, str13 + str5));
                    num10 = Convert.ToDouble(mytjdt.Compute(str2, str13 + str5));
                }
                if (mytjdt.Select(str13 + str6).Length > 0)
                {
                    num6 = Convert.ToDouble(mytjdt.Compute(expression, str13 + str6));
                    num11 = Convert.ToDouble(mytjdt.Compute(str2, str13 + str6));
                }
                if (mytjdt.Select(str13 + str7).Length > 0)
                {
                    num7 = Convert.ToDouble(mytjdt.Compute(expression, str13 + str7));
                    num12 = Convert.ToDouble(mytjdt.Compute(str2, str13 + str7));
                }
                if (mytjdt.Select(str13 + str8).Length > 0)
                {
                    num3 += Convert.ToDouble(mytjdt.Compute(expression, str13 + str8));
                    num8 += Convert.ToDouble(mytjdt.Compute(str2, str13 + str8));
                }
                if (mytjdt.Select(str13 + str9).Length > 0)
                {
                    num4 += Convert.ToDouble(mytjdt.Compute(expression, str13 + str9));
                    num9 += Convert.ToDouble(mytjdt.Compute(str2, str13 + str9));
                }
                if (mytjdt.Select(str13 + str10).Length > 0)
                {
                    num6 += Convert.ToDouble(mytjdt.Compute(expression, str13 + str10));
                    num11 += Convert.ToDouble(mytjdt.Compute(str2, str13 + str10));
                }
                if (mytjdt.Select(str13 + str11).Length > 0)
                {
                    num7 += Convert.ToDouble(mytjdt.Compute(expression, str13 + str11));
                    num12 += Convert.ToDouble(mytjdt.Compute(str2, str13 + str11));
                }
                num = (((num3 + num4) + num5) + num6) + num7;
                num2 = (((num8 + num9) + num10) + num11) + num12;
                DataRow row2 = table.NewRow();
                row2["LDQS"] = str16;
                row2["YSSZ"] = "小计";
                row2["MJHJ"] = num;
                row2["XJHJ"] = num2;
                row2["YLLMJ"] = num3;
                row2["YLLXJ"] = num8;
                row2["ZLLMJ"] = num4;
                row2["ZLLXJ"] = num9;
                row2["JSLMJ"] = num5;
                row2["JSLXJ"] = num10;
                row2["CSLMJ"] = num6;
                row2["CSLXJ"] = num11;
                row2["GSLMJ"] = num7;
                row2["GSLXJ"] = num12;
                if (num > 0.0)
                {
                    table.Rows.Add(row2);
                }
                for (int m = 0; m < DistXMQQYList.Count; m++)
                {
                    string str12 = DistXMQQYList[m].ToString();
                    str13 = "LDQS='" + str16 + "' AND QY='" + str12 + "' AND ";
                    num = 0.0;
                    num2 = 0.0;
                    num3 = 0.0;
                    num4 = 0.0;
                    num5 = 0.0;
                    num6 = 0.0;
                    num7 = 0.0;
                    num8 = 0.0;
                    num9 = 0.0;
                    num10 = 0.0;
                    num11 = 0.0;
                    num12 = 0.0;
                    if (mytjdt.Select(str13 + str3).Length > 0)
                    {
                        num3 = Convert.ToDouble(mytjdt.Compute(expression, str13 + str3));
                        num8 = Convert.ToDouble(mytjdt.Compute(str2, str13 + str3));
                    }
                    if (mytjdt.Select(str13 + str4).Length > 0)
                    {
                        num4 = Convert.ToDouble(mytjdt.Compute(expression, str13 + str4));
                        num9 = Convert.ToDouble(mytjdt.Compute(str2, str13 + str4));
                    }
                    if (mytjdt.Select(str13 + str5).Length > 0)
                    {
                        num5 = Convert.ToDouble(mytjdt.Compute(expression, str13 + str5));
                        num10 = Convert.ToDouble(mytjdt.Compute(str2, str13 + str5));
                    }
                    if (mytjdt.Select(str13 + str6).Length > 0)
                    {
                        num6 = Convert.ToDouble(mytjdt.Compute(expression, str13 + str6));
                        num11 = Convert.ToDouble(mytjdt.Compute(str2, str13 + str6));
                    }
                    if (mytjdt.Select(str13 + str7).Length > 0)
                    {
                        num7 = Convert.ToDouble(mytjdt.Compute(expression, str13 + str7));
                        num12 = Convert.ToDouble(mytjdt.Compute(str2, str13 + str7));
                    }
                    if (mytjdt.Select(str13 + str8).Length > 0)
                    {
                        num3 += Convert.ToDouble(mytjdt.Compute(expression, str13 + str8));
                        num8 += Convert.ToDouble(mytjdt.Compute(str2, str13 + str8));
                    }
                    if (mytjdt.Select(str13 + str9).Length > 0)
                    {
                        num4 += Convert.ToDouble(mytjdt.Compute(expression, str13 + str9));
                        num9 += Convert.ToDouble(mytjdt.Compute(str2, str13 + str9));
                    }
                    if (mytjdt.Select(str13 + str10).Length > 0)
                    {
                        num6 += Convert.ToDouble(mytjdt.Compute(expression, str13 + str10));
                        num11 += Convert.ToDouble(mytjdt.Compute(str2, str13 + str10));
                    }
                    if (mytjdt.Select(str13 + str11).Length > 0)
                    {
                        num7 += Convert.ToDouble(mytjdt.Compute(expression, str13 + str11));
                        num12 += Convert.ToDouble(mytjdt.Compute(str2, str13 + str11));
                    }
                    num = (((num3 + num4) + num5) + num6) + num7;
                    num2 = (((num8 + num9) + num10) + num11) + num12;
                    row2 = table.NewRow();
                    row2["QY"] = str12;
                    row2["YSSZ"] = "计";
                    row2["MJHJ"] = num;
                    row2["XJHJ"] = num2;
                    row2["YLLMJ"] = num3;
                    row2["YLLXJ"] = num8;
                    row2["ZLLMJ"] = num4;
                    row2["ZLLXJ"] = num9;
                    row2["JSLMJ"] = num5;
                    row2["JSLXJ"] = num10;
                    row2["CSLMJ"] = num6;
                    row2["CSLXJ"] = num11;
                    row2["GSLMJ"] = num7;
                    row2["GSLXJ"] = num12;
                    if (num > 0.0)
                    {
                        table.Rows.Add(row2);
                    }
                    for (int n = 0; n < DistXMQSZList.Count; n++)
                    {
                        string str17 = DistXMQSZList[n].ToString();
                        str13 = "LDQS='" + str16 + "' AND QY='" + str12 + "' AND YSSZ='" + str17 + "' AND ";
                        num = 0.0;
                        num2 = 0.0;
                        num3 = 0.0;
                        num4 = 0.0;
                        num5 = 0.0;
                        num6 = 0.0;
                        num7 = 0.0;
                        num8 = 0.0;
                        num9 = 0.0;
                        num10 = 0.0;
                        num11 = 0.0;
                        num12 = 0.0;
                        if (mytjdt.Select(str13 + str3).Length > 0)
                        {
                            num3 = Convert.ToDouble(mytjdt.Compute(expression, str13 + str3));
                            num8 = Convert.ToDouble(mytjdt.Compute(str2, str13 + str3));
                        }
                        if (mytjdt.Select(str13 + str4).Length > 0)
                        {
                            num4 = Convert.ToDouble(mytjdt.Compute(expression, str13 + str4));
                            num9 = Convert.ToDouble(mytjdt.Compute(str2, str13 + str4));
                        }
                        if (mytjdt.Select(str13 + str5).Length > 0)
                        {
                            num5 = Convert.ToDouble(mytjdt.Compute(expression, str13 + str5));
                            num10 = Convert.ToDouble(mytjdt.Compute(str2, str13 + str5));
                        }
                        if (mytjdt.Select(str13 + str6).Length > 0)
                        {
                            num6 = Convert.ToDouble(mytjdt.Compute(expression, str13 + str6));
                            num11 = Convert.ToDouble(mytjdt.Compute(str2, str13 + str6));
                        }
                        if (mytjdt.Select(str13 + str7).Length > 0)
                        {
                            num7 = Convert.ToDouble(mytjdt.Compute(expression, str13 + str7));
                            num12 = Convert.ToDouble(mytjdt.Compute(str2, str13 + str7));
                        }
                        if (mytjdt.Select(str13 + str8).Length > 0)
                        {
                            num3 = Convert.ToDouble(mytjdt.Compute(expression, str13 + str8));
                            num8 = Convert.ToDouble(mytjdt.Compute(str2, str13 + str8));
                        }
                        if (mytjdt.Select(str13 + str9).Length > 0)
                        {
                            num4 = Convert.ToDouble(mytjdt.Compute(expression, str13 + str9));
                            num9 = Convert.ToDouble(mytjdt.Compute(str2, str13 + str9));
                        }
                        if (mytjdt.Select(str13 + str10).Length > 0)
                        {
                            num6 = Convert.ToDouble(mytjdt.Compute(expression, str13 + str10));
                            num11 = Convert.ToDouble(mytjdt.Compute(str2, str13 + str10));
                        }
                        if (mytjdt.Select(str13 + str11).Length > 0)
                        {
                            num7 = Convert.ToDouble(mytjdt.Compute(expression, str13 + str11));
                            num12 = Convert.ToDouble(mytjdt.Compute(str2, str13 + str11));
                        }
                        num = (((num3 + num4) + num5) + num6) + num7;
                        num2 = (((num8 + num9) + num10) + num11) + num12;
                        row2 = table.NewRow();
                        row2["YSSZ"] = str17;
                        row2["MJHJ"] = num;
                        row2["XJHJ"] = num2;
                        row2["YLLMJ"] = num3;
                        row2["YLLXJ"] = num8;
                        row2["ZLLMJ"] = num4;
                        row2["ZLLXJ"] = num9;
                        row2["JSLMJ"] = num5;
                        row2["JSLXJ"] = num10;
                        row2["CSLMJ"] = num6;
                        row2["CSLXJ"] = num11;
                        row2["GSLMJ"] = num7;
                        row2["GSLXJ"] = num12;
                        if (num > 0.0)
                        {
                            table.Rows.Add(row2);
                        }
                    }
                }
            }
            return table;
        }

        private System.Data.DataTable B4UpdateTableByJoin(System.Data.DataTable dataTable_0, string qsname, string qsindex)
        {
            string cmdtxt = " SELECT CCODE,CSNAME FROM " + TABLE_XZDWTABLE + " WHERE (CINDEX = '" + qsindex + "') OR (CINDEX = '219')";
            System.Data.DataTable source = this.GetTable(cmdtxt, "xcdm");
            foreach (var type in Enumerable.Join(DataTableExtensions.AsEnumerable(dataTable_0), DataTableExtensions.AsEnumerable(source), delegate(DataRow dataRow_0)
            {
                return DataRowExtensions.Field<string>(dataRow_0, qsname);
            }, delegate(DataRow dataRow_0)
            {
                return DataRowExtensions.Field<string>(dataRow_0, "CCODE");
            }, delegate(DataRow dataRow_0, DataRow dataRow_1)
            {
                return new
                {
                    dt1row = dataRow_0,
                    dt2row = dataRow_1
                };
            }))
            {
                type.dt1row[qsname] = type.dt2row["CSNAME"].ToString().Substring(0, 2);
            }
            foreach (var type2 in Enumerable.Join(DataTableExtensions.AsEnumerable(dataTable_0), DataTableExtensions.AsEnumerable(source), delegate(DataRow dataRow_0)
            {
                return DataRowExtensions.Field<string>(dataRow_0, "YSSZ");
            }, delegate(DataRow dataRow_0)
            {
                return DataRowExtensions.Field<string>(dataRow_0, "CCODE");
            }, delegate(DataRow dataRow_0, DataRow dataRow_1)
            {
                return new
                {
                    dt1row = dataRow_0,
                    dt2row = dataRow_1
                };
            }))
            {
                type2.dt1row["YSSZ"] = type2.dt2row["CSNAME"];
            }
            System.Data.DataTable table2 = this.QYTable();
            foreach (var type3 in Enumerable.Join(DataTableExtensions.AsEnumerable(dataTable_0), DataTableExtensions.AsEnumerable(table2), delegate(DataRow dataRow_0)
            {
                return DataRowExtensions.Field<string>(dataRow_0, "QY");
            }, delegate(DataRow dataRow_0)
            {
                return DataRowExtensions.Field<string>(dataRow_0, "CCODE");
            }, delegate(DataRow dataRow_0, DataRow dataRow_1)
            {
                return new
                {
                    dt1row = dataRow_0,
                    dt2row = dataRow_1
                };
            }))
            {
                type3.dt1row["QY"] = type3.dt2row["CSNAME"];
            }
            return dataTable_0;
        }

        private System.Data.DataTable B5()
        {
            System.Data.DataTable table = new System.Data.DataTable("ResultTable");
            DataColumn column = new DataColumn("TJDW", typeof(string));
            table.Columns.Add(column);
            column = new DataColumn("LDQS", typeof(string));
            table.Columns.Add(column);
            column = new DataColumn("YSSZ", typeof(string));
            table.Columns.Add(column);
            column = new DataColumn("MJHJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("CQQMJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("CCQMJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("SCQMJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("MCQMJ", typeof(double));
            table.Columns.Add(column);
            return table;
        }

        private System.Data.DataTable B5_1()
        {
            System.Data.DataTable table = new System.Data.DataTable("ResultTable");
            DataColumn column = new DataColumn("TJDW", typeof(string));
            table.Columns.Add(column);
            column = new DataColumn("LMQS", typeof(string));
            table.Columns.Add(column);
            column = new DataColumn("YSSZ", typeof(string));
            table.Columns.Add(column);
            column = new DataColumn("MJHJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("CQQMJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("CCQMJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("SCQMJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("MCQMJ", typeof(double));
            table.Columns.Add(column);
            return table;
        }

        public System.Data.DataTable B5_1TJByXianXiangCun(string ydzl)
        {
            System.Data.DataTable table = new System.Data.DataTable("ResultTable");
            table = this.B5_1();
            System.Data.DataTable mytjdt = new System.Data.DataTable();
            string cmdtxt = "SELECT LTRIM(RTRIM(SHI)) AS SHI,LTRIM(RTRIM(XIAN)) AS XIAN,LTRIM(RTRIM(XIANG)) AS XIANG,LTRIM(RTRIM(CUN)) AS CUN,LTRIM(RTRIM(LMSYQ)) AS LMQS,";
            string str2 = cmdtxt + "LTRIM(RTRIM(YOU_SHI_SZ)) AS YSSZ,LTRIM(RTRIM(JJLCQ)) AS JJLCQ,SUM(MIAN_JI) AS MIAN_JI,SUM(SLXJ) AS SLXJ FROM " + TABLE_ZZYTableName;
            ///ZT_LDZZ_2016 属性表中并没有Q_LIN_ZHONG，因此为LIN_ZHONG
            ///cmdtxt = (str2 + "  WHERE (RTRIM(LTRIM(XMMC))='" + TABLE_ZZYXMMC + "') AND RTRIM(LTRIM(Q_LIN_ZHONG)) LIKE '25%' AND (RTRIM(LTRIM(YDZL))='" + ydzl + "')") + " GROUP BY SHI,XIAN,XIANG,CUN,LMSYQ,YOU_SHI_SZ,JJLCQ  ";
            cmdtxt = (str2 + "  WHERE (RTRIM(LTRIM(XMMC))='" + TABLE_ZZYXMMC + "') AND RTRIM(LTRIM(LIN_ZHONG)) LIKE '25%' AND (RTRIM(LTRIM(YDZL))='" + ydzl + "')") + " GROUP BY SHI,XIAN,XIANG,CUN,LMSYQ,YOU_SHI_SZ,JJLCQ  ";
            mytjdt = this.GetTable(cmdtxt, TABLE_ZZYTableName);
            if (mytjdt == null)
            {
                MessageBox.Show(TABLE_ZZYTableName + " B5-1统计长期用地出错！", "信息", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return null;
            }
            if (mytjdt.Rows.Count == 0)
            {
                return table;
            }
            List<short> distXMQLMQSList = new List<short>();
            List<int> distXMQSZList = new List<int>();
            List<string> list11 = new List<string>();
            for (int i = 0; i < mytjdt.Rows.Count; i++)
            {
                string item = mytjdt.Rows[i]["SHI"].ToString();
                if (!list11.Contains(item))
                {
                    list11.Add(item);
                }
                if (mytjdt.Rows[i]["LMQS"].ToString().Trim().Length == 0)
                {
                    mytjdt.Rows[i]["LMQS"] = 0;
                }
                short num19 = Convert.ToInt16(mytjdt.Rows[i]["LMQS"].ToString());
                if (!distXMQLMQSList.Contains(num19))
                {
                    distXMQLMQSList.Add(num19);
                }
                if (mytjdt.Rows[i]["YSSZ"].ToString().Trim().Length == 0)
                {
                    mytjdt.Rows[i]["YSSZ"] = 0;
                }
                int num16 = Convert.ToInt32(mytjdt.Rows[i]["YSSZ"].ToString());
                if (!distXMQSZList.Contains(num16))
                {
                    distXMQSZList.Add(num16);
                }
            }
            distXMQLMQSList.Sort();
            distXMQSZList.Sort();
            list11.Sort();
            System.Data.DataTable table6 = mytjdt.Clone();
            List<short> list7 = new List<short>();
            List<int> list10 = new List<int>();
            List<string> list5 = new List<string>();
            System.Data.DataTable table7 = mytjdt.Clone();
            List<short> list9 = new List<short>();
            List<int> list12 = new List<int>();
            table = this.B5_1TJTable("项目区", mytjdt, distXMQLMQSList, distXMQSZList);
            for (int j = 0; j < list11.Count; j++)
            {
                table6.Clear();
                list7.Clear();
                list10.Clear();
                string tjdw = list11[j].ToString();
                foreach (DataRow row4 in mytjdt.Select("SHI='" + tjdw + "'"))
                {
                    table6.Rows.Add(row4.ItemArray);
                }
                list5.Clear();
                for (int k = 0; k < table6.Rows.Count; k++)
                {
                    string str6 = table6.Rows[k]["LMQS"].ToString().Trim();
                    if (str6.Length > 0)
                    {
                        short num6 = Convert.ToInt16(str6);
                        if (!list7.Contains(num6))
                        {
                            list7.Add(num6);
                        }
                    }
                    int  num14 = Convert.ToInt32(table6.Rows[k]["YSSZ"].ToString());
                    if (!list10.Contains(num14))
                    {
                        list10.Add(num14);
                    }
                    string str17 = table6.Rows[k]["XIAN"].ToString();
                    if (!list5.Contains(str17))
                    {
                        list5.Add(str17);
                    }
                }
                list7.Sort();
                list10.Sort();
                list5.Sort();
                System.Data.DataTable table4 = this.B5_1TJTable(tjdw, table6, list7, list10);
                foreach (DataRow row8 in table4.Rows)
                {
                    table.ImportRow(row8);
                }
                for (int m = 0; m < list5.Count; m++)
                {
                    table7.Clear();
                    list9.Clear();
                    list12.Clear();
                    string str9 = list5[m].ToString();
                    foreach (DataRow row2 in table6.Select("XIAN='" + str9 + "'"))
                    {
                        table7.Rows.Add(row2.ItemArray);
                    }
                    List<string> list4 = new List<string>();
                    for (int n = 0; n < table7.Rows.Count; n++)
                    {
                        string str18 = table7.Rows[n]["LMQS"].ToString().Trim();
                        if (str18.Length > 0)
                        {
                            short num10 = Convert.ToInt16(str18);
                            if (!list9.Contains(num10))
                            {
                                list9.Add(num10);
                            }
                        }
                        int num18 = Convert.ToInt32(table7.Rows[n]["YSSZ"].ToString());
                        if (!list12.Contains(num18))
                        {
                            list12.Add(num18);
                        }
                        string str15 = table7.Rows[n]["XIANG"].ToString();
                        if (!list4.Contains(str15))
                        {
                            list4.Add(str15);
                        }
                    }
                    list9.Sort();
                    list12.Sort();
                    list4.Sort();
                    table4.Clear();
                    table4 = this.B5_1TJTable(str9, table7, list9, list12);
                    foreach (DataRow row7 in table4.Rows)
                    {
                        table.ImportRow(row7);
                    }
                    System.Data.DataTable table3 = mytjdt.Clone();
                    List<short> list2 = new List<short>();
                    List<int> list3 = new List<int>();
                    List<string> list = new List<string>();
                    System.Data.DataTable table5 = mytjdt.Clone();
                    List<short> list6 = new List<short>();
                    List<int> list8 = new List<int>();
                    for (int num2 = 0; num2 < list4.Count; num2++)
                    {
                        string str3 = list4[num2].ToString();
                        DataRow[] rowArray = mytjdt.Select("XIANG='" + str3 + "'");
                        table3.Clear();
                        foreach (DataRow row3 in rowArray)
                        {
                            table3.Rows.Add(row3.ItemArray);
                        }
                        list2.Clear();
                        list3.Clear();
                        for (int num = 0; num < table3.Rows.Count; num++)
                        {
                            string str14 = table3.Rows[num]["CUN"].ToString();
                            if (!list.Contains(str14))
                            {
                                list.Add(str14);
                            }
                            string str12 = table3.Rows[num]["LMQS"].ToString().Trim();
                            if (str12.Length > 0)
                            {
                                short num13 = Convert.ToInt16(str12);
                                if (!list2.Contains(num13))
                                {
                                    list2.Add(num13);
                                }
                            }
                            int num20 = Convert.ToInt32(table3.Rows[num]["YSSZ"].ToString());
                            if (!list3.Contains(num20))
                            {
                                list3.Add(num20);
                            }
                        }
                        list.Sort();
                        list2.Sort();
                        list3.Sort();
                        table4.Clear();
                        table4 = this.B5_1TJTable(str3, table3, list2, list3);
                        foreach (DataRow row6 in table4.Rows)
                        {
                            table.ImportRow(row6);
                        }
                        for (int num15 = 0; num15 < list.Count; num15++)
                        {
                            string str4 = list[num15].ToString();
                            DataRow[] rowArray4 = table3.Select("CUN='" + str4 + "'");
                            table5.Clear();
                            foreach (DataRow row5 in rowArray4)
                            {
                                table5.Rows.Add(row5.ItemArray);
                            }
                            list6.Clear();
                            list8.Clear();
                            for (int num7 = 0; num7 < table5.Rows.Count; num7++)
                            {
                                string s = table5.Rows[num7]["LMQS"].ToString().Trim();
                                if ((s.Length > 0) && (short.Parse(s) >= 0))
                                {
                                    short num5 = Convert.ToInt16(s);
                                    if (!list6.Contains(num5))
                                    {
                                        list6.Add(num5);
                                    }
                                }
                                int num17 = Convert.ToInt32(table5.Rows[num7]["YSSZ"].ToString());
                                if (!list8.Contains(num17))
                                {
                                    list8.Add(num17);
                                }
                            }
                            list6.Sort();
                            list8.Sort();
                            table4.Clear();
                            table4 = this.B5_1TJTable(str4, table5, list6, list8);
                            foreach (DataRow row in table4.Rows)
                            {
                                table.ImportRow(row);
                            }
                        }
                    }
                    table3.Clear();
                    table5.Clear();
                }
            }
            table6.Clear();
            table7.Clear();
            mytjdt.Clear();
            table = this.UpdateDWTableByJoin(table);
            return this.B5UpdateTableByJoin(table, "LMQS", "209");
        }

        private System.Data.DataTable B5_1TJTable(string tjdw, System.Data.DataTable mytjdt, List<short> DistXMQLMQSList, List<int> DistXMQSZList)
        {
            System.Data.DataTable table = this.B5_1();
            string expression = "SUM(MIAN_JI)";
            string str2 = " JJLCQ ='1'";
            string str3 = " JJLCQ ='2'";
            string str4 = " JJLCQ ='3'";
            string str5 = " JJLCQ ='4'";
            double num = 0.0;
            double num2 = 0.0;
            double num3 = 0.0;
            double num4 = 0.0;
            double num5 = 0.0;
            DataRow row = table.NewRow();
            for (int i = 0; i < DistXMQSZList.Count; i++)
            {
                num = 0.0;
                num2 = 0.0;
                num3 = 0.0;
                num4 = 0.0;
                num5 = 0.0;
                row = table.NewRow();
                string str7 = DistXMQSZList[i].ToString();
                string str10 = "YSSZ='" + str7 + "' AND ";
                if (mytjdt.Select(str10 + str2).Length > 0)
                {
                    num2 = Convert.ToDouble(mytjdt.Compute(expression, str10 + str2));
                }
                if (mytjdt.Select(str10 + str3).Length > 0)
                {
                    num3 = Convert.ToDouble(mytjdt.Compute(expression, str10 + str3));
                }
                if (mytjdt.Select(str10 + str4).Length > 0)
                {
                    num4 = Convert.ToDouble(mytjdt.Compute(expression, str10 + str4));
                }
                if (mytjdt.Select(str10 + str5).Length > 0)
                {
                    num5 = Convert.ToDouble(mytjdt.Compute(expression, str10 + str5));
                }
                num = ((num2 + num3) + num4) + num5;
                row["YSSZ"] = str7;
                row["MJHJ"] = num;
                row["CQQMJ"] = num2;
                row["CCQMJ"] = num3;
                row["SCQMJ"] = num4;
                row["MCQMJ"] = num5;
                if (num > 0.0)
                {
                    table.Rows.Add(row);
                }
            }
            row = table.NewRow();
            row["TJDW"] = tjdw;
            row["YSSZ"] = "合计";
            if (table.Rows.Count > 0)
            {
                for (int k = 3; k < table.Columns.Count; k++)
                {
                    row[k] = Convert.ToDouble(table.Compute("SUM(" + table.Columns[k] + ")", null));
                }
                table.Rows.InsertAt(row, 0);
            }
            for (int j = 0; j < DistXMQLMQSList.Count; j++)
            {
                string str9 = DistXMQLMQSList[j].ToString();
                string str6 = "LMQS='" + str9 + "' AND ";
                num = 0.0;
                num = 0.0;
                num2 = 0.0;
                num3 = 0.0;
                num4 = 0.0;
                num5 = 0.0;
                row = table.NewRow();
                if (mytjdt.Select(str6 + str2).Length > 0)
                {
                    num2 = Convert.ToDouble(mytjdt.Compute(expression, str6 + str2));
                }
                if (mytjdt.Select(str6 + str3).Length > 0)
                {
                    num3 = Convert.ToDouble(mytjdt.Compute(expression, str6 + str3));
                }
                if (mytjdt.Select(str6 + str4).Length > 0)
                {
                    num4 = Convert.ToDouble(mytjdt.Compute(expression, str6 + str4));
                }
                if (mytjdt.Select(str6 + str5).Length > 0)
                {
                    num5 = Convert.ToDouble(mytjdt.Compute(expression, str6 + str5));
                }
                num = ((num2 + num3) + num4) + num5;
                row["LMQS"] = str9;
                row["YSSZ"] = "小计";
                row["MJHJ"] = num;
                row["CQQMJ"] = num2;
                row["CCQMJ"] = num3;
                row["SCQMJ"] = num4;
                row["MCQMJ"] = num5;
                if (num > 0.0)
                {
                    table.Rows.Add(row);
                }
                for (int m = 0; m < DistXMQSZList.Count; m++)
                {
                    string str8 = DistXMQSZList[m].ToString();
                    str6 = "LMQS='" + str9 + "' AND YSSZ='" + str8 + "' AND ";
                    num = 0.0;
                    num2 = 0.0;
                    num3 = 0.0;
                    num4 = 0.0;
                    num5 = 0.0;
                    row = table.NewRow();
                    if (mytjdt.Select(str6 + str2).Length > 0)
                    {
                        num2 = Convert.ToDouble(mytjdt.Compute(expression, str6 + str2));
                    }
                    if (mytjdt.Select(str6 + str3).Length > 0)
                    {
                        num2 = Convert.ToDouble(mytjdt.Compute(expression, str6 + str3));
                    }
                    if (mytjdt.Select(str6 + str4).Length > 0)
                    {
                        num2 = Convert.ToDouble(mytjdt.Compute(expression, str6 + str4));
                    }
                    if (mytjdt.Select(str6 + str5).Length > 0)
                    {
                        num2 = Convert.ToDouble(mytjdt.Compute(expression, str6 + str5));
                    }
                    num = ((num2 + num3) + num4) + num5;
                    row["LMQS"] = str9;
                    row["YSSZ"] = str8;
                    row["MJHJ"] = num;
                    row["CQQMJ"] = num2;
                    row["CCQMJ"] = num3;
                    row["SCQMJ"] = num4;
                    row["MCQMJ"] = num5;
                    if (num > 0.0)
                    {
                        table.Rows.Add(row);
                    }
                }
            }
            return table;
        }

        public System.Data.DataTable B5TJByXianXiangCun(string ydzl)
        {
            System.Data.DataTable table = new System.Data.DataTable("ResultTable");
            table = this.B5();
            System.Data.DataTable mytjdt = new System.Data.DataTable();
            string cmdtxt = "SELECT LTRIM(RTRIM(SHI)) AS SHI,LTRIM(RTRIM(XIAN)) AS XIAN,LTRIM(RTRIM(XIANG)) AS XIANG,LTRIM(RTRIM(CUN)) AS CUN,LTRIM(RTRIM(Q_LD_QS)) AS LDQS,";
            string str2 = cmdtxt + "LTRIM(RTRIM(YOU_SHI_SZ)) AS YSSZ,LTRIM(RTRIM(JJLCQ)) AS JJLCQ,SUM(MIAN_JI) AS MIAN_JI,SUM(SLXJ) AS SLXJ FROM " + TABLE_ZZYTableName;
            ///ZT_LDZZ_2016 属性表中并没有Q_LIN_ZHONG，因此为LIN_ZHONG
            ///cmdtxt = (str2 + "  WHERE (RTRIM(LTRIM(XMMC))='" + TABLE_ZZYXMMC + "') AND RTRIM(LTRIM(Q_LIN_ZHONG)) LIKE '25%' AND (RTRIM(LTRIM(YDZL))='" + ydzl + "')") + " GROUP BY SHI,XIAN,XIANG,CUN,Q_LD_QS,YOU_SHI_SZ,JJLCQ  ";
            cmdtxt = (str2 + "  WHERE (RTRIM(LTRIM(XMMC))='" + TABLE_ZZYXMMC + "') AND RTRIM(LTRIM(LIN_ZHONG)) LIKE '25%' AND (RTRIM(LTRIM(YDZL))='" + ydzl + "')") + " GROUP BY SHI,XIAN,XIANG,CUN,Q_LD_QS,YOU_SHI_SZ,JJLCQ  ";
            mytjdt = this.GetTable(cmdtxt, TABLE_ZZYTableName);
            if (mytjdt == null)
            {
                MessageBox.Show(TABLE_ZZYTableName + " B5统计长期用地出错！", "信息", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return null;
            }
            if (mytjdt.Rows.Count == 0)
            {
                return table;
            }
            List<short> distXMQLMQSList = new List<short>();
            List<int> distXMQSZList = new List<int>();
            List<string> list8 = new List<string>();
            for (int i = 0; i < mytjdt.Rows.Count; i++)
            {
                string item = mytjdt.Rows[i]["SHI"].ToString();
                if (!list8.Contains(item))
                {
                    list8.Add(item);
                }
                if (mytjdt.Rows[i]["LDQS"].ToString().Trim().Length == 0)
                {
                    mytjdt.Rows[i]["LDQS"] = 0;
                }
                short num18 = Convert.ToInt16(mytjdt.Rows[i]["LDQS"].ToString());
                if (num18 >= 20)
                {
                    mytjdt.Rows[i]["LDQS"] = "20";
                    num18 = Convert.ToInt16(mytjdt.Rows[i]["LDQS"].ToString());
                }
                if (!distXMQLMQSList.Contains(num18))
                {
                    distXMQLMQSList.Add(num18);
                }
                if (mytjdt.Rows[i]["YSSZ"].ToString().Trim().Length == 0)
                {
                    mytjdt.Rows[i]["YSSZ"] = 0;
                }
                int num11 = Convert.ToInt32(mytjdt.Rows[i]["YSSZ"].ToString());
                if (!distXMQSZList.Contains(num11))
                {
                    distXMQSZList.Add(num11);
                }
            }
            distXMQLMQSList.Sort();
            distXMQSZList.Sort();
            list8.Sort();
            System.Data.DataTable table6 = mytjdt.Clone();
            List<short> list6 = new List<short>();
            List<int> list7 = new List<int>();
            List<string> list9 = new List<string>();
            System.Data.DataTable table7 = mytjdt.Clone();
            List<short> list10 = new List<short>();
            List<int> list13 = new List<int>();
            table = this.B5TJTable("项目区", mytjdt, distXMQLMQSList, distXMQSZList);
            for (int j = 0; j < list8.Count; j++)
            {
                table6.Clear();
                list6.Clear();
                list7.Clear();
                string tjdw = list8[j].ToString();
                foreach (DataRow row4 in mytjdt.Select("SHI='" + tjdw + "'"))
                {
                    table6.Rows.Add(row4.ItemArray);
                }
                list9.Clear();
                for (int k = 0; k < table6.Rows.Count; k++)
                {
                    string str8 = table6.Rows[k]["LDQS"].ToString().Trim();
                    if (str8.Length > 0)
                    {
                        short num13 = Convert.ToInt16(str8);
                        if (!list6.Contains(num13))
                        {
                            list6.Add(num13);
                        }
                    }
                    int num16 = Convert.ToInt32(table6.Rows[k]["YSSZ"].ToString());
                    if (!list7.Contains(num16))
                    {
                        list7.Add(num16);
                    }
                    string str15 = table6.Rows[k]["XIAN"].ToString();
                    if (!list9.Contains(str15))
                    {
                        list9.Add(str15);
                    }
                }
                list6.Sort();
                list7.Sort();
                list9.Sort();
                System.Data.DataTable table4 = this.B5TJTable(tjdw, table6, list6, list7);
                foreach (DataRow row7 in table4.Rows)
                {
                    table.ImportRow(row7);
                }
                for (int m = 0; m < list9.Count; m++)
                {
                    table7.Clear();
                    list10.Clear();
                    list13.Clear();
                    string str9 = list9[m].ToString();
                    foreach (DataRow row3 in table6.Select("XIAN='" + str9 + "'"))
                    {
                        table7.Rows.Add(row3.ItemArray);
                    }
                    List<string> list14 = new List<string>();
                    for (int n = 0; n < table7.Rows.Count; n++)
                    {
                        string str6 = table7.Rows[n]["LDQS"].ToString().Trim();
                        if (str6.Length > 0)
                        {
                            short num9 = Convert.ToInt16(str6);
                            if (!list10.Contains(num9))
                            {
                                list10.Add(num9);
                            }
                        }
                        int num19 = Convert.ToInt32(table7.Rows[n]["YSSZ"].ToString());
                        if (!list13.Contains(num19))
                        {
                            list13.Add(num19);
                        }
                        string str12 = table7.Rows[n]["XIANG"].ToString();
                        if (!list14.Contains(str12))
                        {
                            list14.Add(str12);
                        }
                    }
                    list10.Sort();
                    list13.Sort();
                    list14.Sort();
                    table4.Clear();
                    table4 = this.B5TJTable(str9, table7, list10, list13);
                    foreach (DataRow row6 in table4.Rows)
                    {
                        table.ImportRow(row6);
                    }
                    System.Data.DataTable table3 = mytjdt.Clone();
                    List<short> list2 = new List<short>();
                    List<int> list3 = new List<int>();
                    List<string> list = new List<string>();
                    System.Data.DataTable table5 = mytjdt.Clone();
                    List<short> list4 = new List<short>();
                    List<int> list5 = new List<int>();
                    for (int num2 = 0; num2 < list14.Count; num2++)
                    {
                        string str3 = list14[num2].ToString();
                        DataRow[] rowArray5 = mytjdt.Select("XIANG='" + str3 + "'");
                        table3.Clear();
                        foreach (DataRow row in rowArray5)
                        {
                            table3.Rows.Add(row.ItemArray);
                        }
                        list2.Clear();
                        list3.Clear();
                        for (int num = 0; num < table3.Rows.Count; num++)
                        {
                            string str17 = table3.Rows[num]["CUN"].ToString();
                            if (!list.Contains(str17))
                            {
                                list.Add(str17);
                            }
                            string str10 = table3.Rows[num]["LDQS"].ToString().Trim();
                            if (str10.Length > 0)
                            {
                                short num14 = Convert.ToInt16(str10);
                                if (!list2.Contains(num14))
                                {
                                    list2.Add(num14);
                                }
                            }
                            int num20 = Convert.ToInt32(table3.Rows[num]["YSSZ"].ToString());
                            if (!list3.Contains(num20))
                            {
                                list3.Add(num20);
                            }
                        }
                        list.Sort();
                        list2.Sort();
                        list3.Sort();
                        table4.Clear();
                        table4 = this.B5TJTable(str3, table3, list2, list3);
                        foreach (DataRow row5 in table4.Rows)
                        {
                            table.ImportRow(row5);
                        }
                        for (int num15 = 0; num15 < list.Count; num15++)
                        {
                            string str5 = list[num15].ToString();
                            DataRow[] rowArray4 = table3.Select("CUN='" + str5 + "'");
                            table5.Clear();
                            foreach (DataRow row8 in rowArray4)
                            {
                                table5.Rows.Add(row8.ItemArray);
                            }
                            list4.Clear();
                            list5.Clear();
                            for (int num6 = 0; num6 < table5.Rows.Count; num6++)
                            {
                                string s = table5.Rows[num6]["LDQS"].ToString().Trim();
                                if ((s.Length > 0) && (short.Parse(s) >= 0))
                                {
                                    short num5 = Convert.ToInt16(s);
                                    if (!list4.Contains(num5))
                                    {
                                        list4.Add(num5);
                                    }
                                }
                                int num17 = Convert.ToInt32(table5.Rows[num6]["YSSZ"].ToString());
                                if (!list5.Contains(num17))
                                {
                                    list5.Add(num17);
                                }
                            }
                            list4.Sort();
                            list5.Sort();
                            table4.Clear();
                            table4 = this.B5TJTable(str5, table5, list4, list5);
                            foreach (DataRow row2 in table4.Rows)
                            {
                                table.ImportRow(row2);
                            }
                        }
                    }
                    table3.Clear();
                    table5.Clear();
                }
            }
            table6.Clear();
            table7.Clear();
            mytjdt.Clear();
            table = this.UpdateDWTableByJoin(table);
            return this.B5UpdateTableByJoin(table, "LDQS", "207");
        }

        private System.Data.DataTable B5TJTable(string tjdw, System.Data.DataTable mytjdt, List<short> DistXMQLMQSList, List<int> DistXMQSZList)
        {
            System.Data.DataTable table = this.B5();
            string expression = "SUM(MIAN_JI)";
            string str2 = " JJLCQ ='1'";
            string str3 = " JJLCQ ='2'";
            string str4 = " JJLCQ ='3'";
            string str5 = " JJLCQ ='4'";
            double num = 0.0;
            double num2 = 0.0;
            double num3 = 0.0;
            double num4 = 0.0;
            double num5 = 0.0;
            DataRow row = table.NewRow();
            for (int i = 0; i < DistXMQSZList.Count; i++)
            {
                num = 0.0;
                num2 = 0.0;
                num3 = 0.0;
                num4 = 0.0;
                num5 = 0.0;
                row = table.NewRow();
                string str7 = DistXMQSZList[i].ToString();
                string str10 = "YSSZ='" + str7 + "' AND ";
                if (mytjdt.Select(str10 + str2).Length > 0)
                {
                    num2 = Convert.ToDouble(mytjdt.Compute(expression, str10 + str2));
                }
                if (mytjdt.Select(str10 + str3).Length > 0)
                {
                    num3 = Convert.ToDouble(mytjdt.Compute(expression, str10 + str3));
                }
                if (mytjdt.Select(str10 + str4).Length > 0)
                {
                    num4 = Convert.ToDouble(mytjdt.Compute(expression, str10 + str4));
                }
                if (mytjdt.Select(str10 + str5).Length > 0)
                {
                    num5 = Convert.ToDouble(mytjdt.Compute(expression, str10 + str5));
                }
                num = ((num2 + num3) + num4) + num5;
                row["YSSZ"] = str7;
                row["MJHJ"] = num;
                row["CQQMJ"] = num2;
                row["CCQMJ"] = num3;
                row["SCQMJ"] = num4;
                row["MCQMJ"] = num5;
                if (num > 0.0)
                {
                    table.Rows.Add(row);
                }
            }
            row = table.NewRow();
            row["TJDW"] = tjdw;
            row["YSSZ"] = "合计";
            if (table.Rows.Count > 0)
            {
                for (int k = 3; k < table.Columns.Count; k++)
                {
                    row[k] = Convert.ToDouble(table.Compute("SUM(" + table.Columns[k] + ")", null));
                }
                table.Rows.InsertAt(row, 0);
            }
            for (int j = 0; j < DistXMQLMQSList.Count; j++)
            {
                string str9 = DistXMQLMQSList[j].ToString();
                string str6 = "LDQS='" + str9 + "' AND ";
                num = 0.0;
                num = 0.0;
                num2 = 0.0;
                num3 = 0.0;
                num4 = 0.0;
                num5 = 0.0;
                row = table.NewRow();
                if (mytjdt.Select(str6 + str2).Length > 0)
                {
                    num2 = Convert.ToDouble(mytjdt.Compute(expression, str6 + str2));
                }
                if (mytjdt.Select(str6 + str3).Length > 0)
                {
                    num3 = Convert.ToDouble(mytjdt.Compute(expression, str6 + str3));
                }
                if (mytjdt.Select(str6 + str4).Length > 0)
                {
                    num4 = Convert.ToDouble(mytjdt.Compute(expression, str6 + str4));
                }
                if (mytjdt.Select(str6 + str5).Length > 0)
                {
                    num5 = Convert.ToDouble(mytjdt.Compute(expression, str6 + str5));
                }
                num = ((num2 + num3) + num4) + num5;
                row["LDQS"] = str9;
                row["YSSZ"] = "小计";
                row["MJHJ"] = num;
                row["CQQMJ"] = num2;
                row["CCQMJ"] = num3;
                row["SCQMJ"] = num4;
                row["MCQMJ"] = num5;
                if (num > 0.0)
                {
                    table.Rows.Add(row);
                }
                for (int m = 0; m < DistXMQSZList.Count; m++)
                {
                    string str8 = DistXMQSZList[m].ToString();
                    str6 = "LDQS='" + str9 + "' AND YSSZ='" + str8 + "' AND ";
                    num = 0.0;
                    num2 = 0.0;
                    num3 = 0.0;
                    num4 = 0.0;
                    num5 = 0.0;
                    row = table.NewRow();
                    if (mytjdt.Select(str6 + str2).Length > 0)
                    {
                        num2 = Convert.ToDouble(mytjdt.Compute(expression, str6 + str2));
                    }
                    if (mytjdt.Select(str6 + str3).Length > 0)
                    {
                        num2 = Convert.ToDouble(mytjdt.Compute(expression, str6 + str3));
                    }
                    if (mytjdt.Select(str6 + str4).Length > 0)
                    {
                        num2 = Convert.ToDouble(mytjdt.Compute(expression, str6 + str4));
                    }
                    if (mytjdt.Select(str6 + str5).Length > 0)
                    {
                        num2 = Convert.ToDouble(mytjdt.Compute(expression, str6 + str5));
                    }
                    num = ((num2 + num3) + num4) + num5;
                    row["LDQS"] = str9;
                    row["YSSZ"] = str8;
                    row["MJHJ"] = num;
                    row["CQQMJ"] = num2;
                    row["CCQMJ"] = num3;
                    row["SCQMJ"] = num4;
                    row["MCQMJ"] = num5;
                    if (num > 0.0)
                    {
                        table.Rows.Add(row);
                    }
                }
            }
            return table;
        }

        private System.Data.DataTable B5UpdateTableByJoin(System.Data.DataTable dataTable_0, string qsname, string qsindex)
        {
            string cmdtxt = " SELECT CCODE,CSNAME FROM " + TABLE_XZDWTABLE + " WHERE (CINDEX = '" + qsindex + "') OR (CINDEX = '219')";
            System.Data.DataTable source = this.GetTable(cmdtxt, "xcdm");
            foreach (var type in Enumerable.Join(DataTableExtensions.AsEnumerable(dataTable_0), DataTableExtensions.AsEnumerable(source), delegate(DataRow dataRow_0)
            {
                return DataRowExtensions.Field<string>(dataRow_0, qsname);
            }, delegate(DataRow dataRow_0)
            {
                return DataRowExtensions.Field<string>(dataRow_0, "CCODE");
            }, delegate(DataRow dataRow_0, DataRow dataRow_1)
            {
                return new
                {
                    dt1row = dataRow_0,
                    dt2row = dataRow_1
                };
            }))
            {
                type.dt1row[qsname] = type.dt2row["CSNAME"].ToString().Substring(0, 2);
            }
            foreach (var type2 in Enumerable.Join(DataTableExtensions.AsEnumerable(dataTable_0), DataTableExtensions.AsEnumerable(source), delegate(DataRow dataRow_0)
            {
                return DataRowExtensions.Field<string>(dataRow_0, "YSSZ");
            }, delegate(DataRow dataRow_0)
            {
                return DataRowExtensions.Field<string>(dataRow_0, "CCODE");
            }, delegate(DataRow dataRow_0, DataRow dataRow_1)
            {
                return new
                {
                    dt1row = dataRow_0,
                    dt2row = dataRow_1
                };
            }))
            {
                type2.dt1row["YSSZ"] = type2.dt2row["CSNAME"];
            }
            return dataTable_0;
        }

        private System.Data.DataTable B6()
        {
            System.Data.DataTable table = new System.Data.DataTable("ResultTable");
            DataColumn column = new DataColumn("TJDW", typeof(string));
            table.Columns.Add(column);
            column = new DataColumn("LDLX", typeof(string));
            table.Columns.Add(column);
            column = new DataColumn("LDLXSub", typeof(string));
            table.Columns.Add(column);
            column = new DataColumn("LDQS", typeof(string));
            table.Columns.Add(column);
            column = new DataColumn("MJHJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("XJHJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("ZZSFHJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("FCSYDMJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("FCSYDXJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("FCSYDZSBZ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("FCSYDZSFY", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("CSYDMJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("CSYDXJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("CSYDZSBZ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("CSYDZSFY", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("BZ", typeof(string));
            table.Columns.Add(column);
            return table;
        }

        private System.Data.DataTable B6MetaTable()
        {
            System.Data.DataTable table = new System.Data.DataTable("B6MetaTable");
            DataColumn column = new DataColumn("BH", typeof(short));
            table.Columns.Add(column);
            column = new DataColumn("LDLX", typeof(string));
            table.Columns.Add(column);
            column = new DataColumn("LDLXSub", typeof(string));
            table.Columns.Add(column);
            column = new DataColumn("TJBDS", typeof(string));
            table.Columns.Add(column);
            string str = "LDLX='1' ";
            string str2 = str + " AND SQJ<>'10' ";
            string str3 = str + " AND SQJ='10' ";
            string str4 = str + " AND TDZL='601' ";
            string str5 = "LDLX='2'";
            string str6 = str5 + " AND SQJ<>'10'";
            string str7 = str5 + " AND SQJ='10'";
            string str8 = str5 + " AND TDZL='601'";
            string str9 = "LDLX='3'";
            string str10 = str9 + " AND TDZL='601'";
            string str11 = "LDLX='4' ";
            string str12 = str11 + " AND TDZL='601'";
            string str13 = "LDLX='5' ";
            string str14 = str11 + " AND TDZL='601'";
            string str15 = "LDLX='6' ";
            string str16 = "LDLX='7' ";
            string str17 = str16 + " AND TDZL='200'";
            string str18 = str16 + " AND TDZL LIKE '30%'";
            string str19 = str16 + " AND TDZL LIKE '40%'";
            string str20 = str16 + " AND TDZL = '602'";
            string str21 = str16 + " AND TDZL LIKE '603%'";
            string str22 = str16 + " AND TDZL LIKE '70%'";
            string str23 = str16 + " AND TDZL ='800'";
            DataRow row = table.NewRow();
            row[0] = 1;
            row[1] = "1";
            row[2] = "一般防护林林地";
            row[3] = str2;
            table.Rows.Add(row);
            row = table.NewRow();
            row[0] = 2;
            row[1] = "1";
            row[2] = "国家重点防护林林地";
            row[3] = str3;
            table.Rows.Add(row);
            row = table.NewRow();
            row[0] = 3;
            row[1] = "1";
            row[2] = "采伐迹地";
            row[3] = str4;
            table.Rows.Add(row);
            row = table.NewRow();
            row[0] = 4;
            row[1] = "2";
            row[2] = "一般特种用途林林地";
            row[3] = str6;
            table.Rows.Add(row);
            row = table.NewRow();
            row[0] = 5;
            row[1] = "2";
            row[2] = "国家重点特种用途林林地";
            row[3] = str7;
            table.Rows.Add(row);
            row = table.NewRow();
            row[0] = 6;
            row[1] = "2";
            row[2] = "采伐迹地";
            row[3] = str8;
            table.Rows.Add(row);
            row = table.NewRow();
            row[0] = 7;
            row[1] = "3";
            row[2] = "用材林林地";
            row[3] = str9;
            table.Rows.Add(row);
            row = table.NewRow();
            row[0] = 8;
            row[1] = "3";
            row[2] = "采伐迹地";
            row[3] = str10;
            table.Rows.Add(row);
            row = table.NewRow();
            row[0] = 9;
            row[1] = "4";
            row[2] = "经济林林地";
            row[3] = str11;
            table.Rows.Add(row);
            row = table.NewRow();
            row[0] = 10;
            row[1] = "4";
            row[2] = "采伐迹地";
            row[3] = str12;
            table.Rows.Add(row);
            row = table.NewRow();
            row[0] = 11;
            row[1] = "5";
            row[2] = "薪炭林地";
            row[3] = str13;
            table.Rows.Add(row);
            row = table.NewRow();
            row[0] = 12;
            row[1] = "5";
            row[2] = "采伐迹地";
            row[3] = str14;
            table.Rows.Add(row);
            row = table.NewRow();
            row[0] = 13;
            row[1] = "6";
            row[2] = "苗圃地";
            row[3] = str15;
            table.Rows.Add(row);
            row = table.NewRow();
            row[0] = 14;
            row[1] = "7";
            row[2] = "疏林地";
            row[3] = str17;
            table.Rows.Add(row);
            row = table.NewRow();
            row[0] = 15;
            row[1] = "7";
            row[2] = "灌木林地";
            row[3] = str18;
            table.Rows.Add(row);
            row = table.NewRow();
            row[0] = 0x10;
            row[1] = "7";
            row[2] = "未成林造林地";
            row[3] = str19;
            table.Rows.Add(row);
            row = table.NewRow();
            row[0] = 0x11;
            row[1] = "7";
            row[2] = "火烧迹地";
            row[3] = str20;
            table.Rows.Add(row);
            row = table.NewRow();
            row[0] = 0x12;
            row[1] = "7";
            row[2] = "其它无立木林地";
            row[3] = str21;
            table.Rows.Add(row);
            row = table.NewRow();
            row[0] = 0x13;
            row[1] = "7";
            row[2] = "宜林地";
            row[3] = str22;
            table.Rows.Add(row);
            row = table.NewRow();
            row[0] = 20;
            row[1] = "7";
            row[2] = "辅助生产林地";
            row[3] = str23;
            table.Rows.Add(row);
            return table;
        }

        public System.Data.DataTable B6TJByXianXiangCun(string ydzl)
        {
            System.Data.DataTable table = this.B6();
            System.Data.DataTable mytjdt = new System.Data.DataTable();
            string cmdtxt = "SELECT LTRIM(RTRIM(SHI)) AS SHI,LTRIM(RTRIM(XIAN)) AS XIAN,LTRIM(RTRIM(XIANG)) AS XIANG,LTRIM(RTRIM(CUN)) AS CUN,LTRIM(RTRIM(Q_LD_QS)) AS LDQS,";
            string str2 = cmdtxt + "LTRIM(RTRIM(Q_DI_LEI)) AS TDZL,LTRIM(RTRIM(SHI_QUAN_D)) AS SQJ,LTRIM(RTRIM(LDLX)) AS LDLX,LTRIM(RTRIM(YDFW)) AS YDFW,MIAN_JI,SLXJ,ZBHFDJ,ZBHFF FROM " + TABLE_ZZYTableName;
            cmdtxt = str2 + "  WHERE (RTRIM(LTRIM(XMMC))='" + TABLE_ZZYXMMC + "') AND (RTRIM(LTRIM(YDZL))='" + ydzl + "')";
            mytjdt = this.GetTable(cmdtxt, TABLE_ZZYTableName);
            if (mytjdt == null)
            {
                MessageBox.Show(TABLE_ZZYTableName + " B6统计出错！", "信息", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return null;
            }
            if (mytjdt.Rows.Count == 0)
            {
                MessageBox.Show(TABLE_ZZYXMMC + " 该项目没有有效数据，请检查！", "信息", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return table;
            }
            foreach (DataRow row4 in mytjdt.Rows)
            {
                if (row4["ZBHFF"] == DBNull.Value)
                {
                    row4["ZBHFF"] = 0;
                }
            }
            List<short> distXMQLDQSList = new List<short>();
            List<string> list5 = new List<string>();
            for (int i = 0; i < mytjdt.Rows.Count; i++)
            {
                string item = mytjdt.Rows[i]["SHI"].ToString();
                if (!list5.Contains(item))
                {
                    list5.Add(item);
                }
                if (mytjdt.Rows[i]["LDQS"].ToString().Trim().Length == 0)
                {
                    mytjdt.Rows[i]["LDQS"] = 0;
                }
                short num5 = Convert.ToInt16(mytjdt.Rows[i]["LDQS"].ToString());
                if (num5 >= 20)
                {
                    mytjdt.Rows[i]["LDQS"] = "20";
                    num5 = Convert.ToInt16(mytjdt.Rows[i]["LDQS"].ToString());
                }
                if (!distXMQLDQSList.Contains(num5))
                {
                    distXMQLDQSList.Add(num5);
                }
            }
            distXMQLDQSList.Sort();
            list5.Sort();
            table = this.B6TJTable("项目区", mytjdt, distXMQLDQSList, false);
            System.Data.DataTable table3 = mytjdt.Clone();
            List<short> list2 = new List<short>();
            List<string> list3 = new List<string>();
            System.Data.DataTable table5 = mytjdt.Clone();
            List<short> list6 = new List<short>();
            for (int j = 0; j < list5.Count; j++)
            {
                table3.Clear();
                list2.Clear();
                string tjdw = list5[j].ToString();
                foreach (DataRow row3 in mytjdt.Select("SHI='" + tjdw + "'"))
                {
                    table3.Rows.Add(row3.ItemArray);
                }
                list3.Clear();
                for (int k = 0; k < table3.Rows.Count; k++)
                {
                    string str6 = table3.Rows[k]["LDQS"].ToString().Trim();
                    if (str6.Length > 0)
                    {
                        short num9 = Convert.ToInt16(str6);
                        if (!list2.Contains(num9))
                        {
                            list2.Add(num9);
                        }
                    }
                    string str8 = table3.Rows[k]["XIAN"].ToString();
                    if (!list3.Contains(str8))
                    {
                        list3.Add(str8);
                    }
                }
                list2.Sort();
                list3.Sort();
                System.Data.DataTable table4 = this.B6TJTable(tjdw, table3, list2, false);
                foreach (DataRow row5 in table4.Rows)
                {
                    table.ImportRow(row5);
                }
                for (int m = 0; m < list3.Count; m++)
                {
                    table5.Clear();
                    list6.Clear();
                    string str9 = list3[m].ToString();
                    foreach (DataRow row in table3.Select("XIAN='" + str9 + "'"))
                    {
                        table5.Rows.Add(row.ItemArray);
                    }
                    List<string> list = new List<string>();
                    for (int n = 0; n < table5.Rows.Count; n++)
                    {
                        string str10 = table5.Rows[n]["LDQS"].ToString().Trim();
                        if (str10.Length > 0)
                        {
                            short num10 = Convert.ToInt16(str10);
                            if (!list6.Contains(num10))
                            {
                                list6.Add(num10);
                            }
                        }
                        string str7 = table5.Rows[n]["XIANG"].ToString();
                        if (!list.Contains(str7))
                        {
                            list.Add(str7);
                        }
                    }
                    list6.Sort();
                    list.Sort();
                    table4.Clear();
                    table4 = this.B6TJTable(str9, table5, list6, true);
                    foreach (DataRow row2 in table4.Rows)
                    {
                        table.ImportRow(row2);
                    }
                }
            }
            return this.B6UpdateDWTableByJoin(table);
        }

        private System.Data.DataTable B6TJTable(string tjdw, System.Data.DataTable mytjdt, List<short> DistXMQLDQSList, bool IsFillDJ)
        {
            System.Data.DataTable table = this.B6();
            System.Data.DataTable table2 = this.B6MetaTable();
            string expression = "SUM(MIAN_JI)";
            string str2 = "SUM(SLXJ)";
            string str3 = "SUM(ZBHFF)";
            string str4 = "YDFW='1' ";
            string str5 = "YDFW='2' ";
            double num = 0.0;
            double num2 = 0.0;
            double num3 = 0.0;
            double num4 = 0.0;
            double num5 = 0.0;
            double num6 = 0.0;
            double num7 = 0.0;
            double num8 = 0.0;
            double num9 = 0.0;
            DataRow row = table.NewRow();
            string str6 = "";
            for (int i = 0; i < table2.Rows.Count; i++)
            {
                row = table.NewRow();
                row["TJDW"] = tjdw;
                string str7 = table2.Rows[i]["LDLX"].ToString();
                string str8 = table2.Rows[i]["LDLXSub"].ToString();
                string str9 = table2.Rows[i]["TJBDS"].ToString();
                if (str6 != str7)
                {
                    str6 = str7;
                    row["LDLX"] = str7;
                    row["LDLXSub"] = "小计";
                    string filterExpression = "LDLX='" + str7 + "'";
                    if (mytjdt.Select(filterExpression).Length > 0)
                    {
                        num = Convert.ToDouble(mytjdt.Compute(expression, filterExpression)) * 10000.0;
                        num2 = Convert.ToDouble(mytjdt.Compute(str2, filterExpression));
                        num3 = Convert.ToDouble(mytjdt.Compute(str3, filterExpression));
                    }
                    filterExpression = "LDLX='" + str7 + "' AND " + str5;
                    if (mytjdt.Select(filterExpression).Length > 0)
                    {
                        num4 = Convert.ToDouble(mytjdt.Compute(expression, filterExpression)) * 10000.0;
                        num5 = Convert.ToDouble(mytjdt.Compute(str2, filterExpression));
                        num6 = Convert.ToDouble(mytjdt.Compute(str3, filterExpression));
                    }
                    filterExpression = "LDLX='" + str7 + "' AND " + str4;
                    if (mytjdt.Select(filterExpression).Length > 0)
                    {
                        num7 = Convert.ToDouble(mytjdt.Compute(expression, filterExpression)) * 10000.0;
                        num8 = Convert.ToDouble(mytjdt.Compute(str2, filterExpression));
                        num9 = Convert.ToDouble(mytjdt.Compute(str3, filterExpression));
                    }
                    row["MJHJ"] = num;
                    row["XJHJ"] = num2;
                    row["ZZSFHJ"] = num3;
                    row["FCSYDMJ"] = num4;
                    row["FCSYDXJ"] = num5;
                    row["FCSYDZSFY"] = num6;
                    row["CSYDMJ"] = num7;
                    row["CSYDXJ"] = num8;
                    row["CSYDZSFY"] = num9;
                    table.Rows.Add(row);
                }
                System.Data.DataTable table3 = table.Clone();
                for (int n = 0; n < DistXMQLDQSList.Count; n++)
                {
                    num = 0.0;
                    num2 = 0.0;
                    num3 = 0.0;
                    num4 = 0.0;
                    num5 = 0.0;
                    num6 = 0.0;
                    num7 = 0.0;
                    num8 = 0.0;
                    num9 = 0.0;
                    double num13 = 0.0;
                    double num16 = 0.0;
                    row = table.NewRow();
                    string str11 = DistXMQLDQSList[n].ToString();
                    string str12 = "LDQS='" + str11 + "' AND " + str9;
                    if (mytjdt.Select(str12).Length > 0)
                    {
                        row["LDQS"] = str11;
                        num = Convert.ToDouble(mytjdt.Compute(expression, str12)) * 10000.0;
                        num2 = Convert.ToDouble(mytjdt.Compute(str2, str12));
                        num3 = Convert.ToDouble(mytjdt.Compute(str3, str12));
                    }
                    str12 = "LDQS='" + str11 + "' AND " + str9 + " AND " + str5;
                    if (mytjdt.Select(str12).Length > 0)
                    {
                        num4 = Convert.ToDouble(mytjdt.Compute(expression, str12)) * 10000.0;
                        num5 = Convert.ToDouble(mytjdt.Compute(str2, str12));
                        num6 = Convert.ToDouble(mytjdt.Compute(str3, str12));
                        DataRow[] rowArray2 = mytjdt.Select(str12 + " AND ZBHFDJ>0");
                        if (rowArray2.Length > 0)
                        {
                            num13 = Convert.ToDouble(rowArray2[0]["ZBHFDJ"]);
                        }
                    }
                    str12 = "LDQS='" + str11 + "' AND " + str9 + " AND " + str4;
                    if (mytjdt.Select(str12).Length > 0)
                    {
                        num7 = Convert.ToDouble(mytjdt.Compute(expression, str12)) * 10000.0;
                        num8 = Convert.ToDouble(mytjdt.Compute(str2, str12));
                        num9 = Convert.ToDouble(mytjdt.Compute(str3, str12));
                        DataRow[] rowArray6 = mytjdt.Select(str12 + " AND ZBHFDJ>0");
                        if (rowArray6.Length > 0)
                        {
                            num16 = Convert.ToDouble(rowArray6[0]["ZBHFDJ"]);
                        }
                    }
                    row["TJDW"] = tjdw;
                    row["LDLX"] = str7;
                    row["LDLXSub"] = str8;
                    row["MJHJ"] = num;
                    row["XJHJ"] = num2;
                    row["ZZSFHJ"] = num3;
                    row["FCSYDMJ"] = num4;
                    row["FCSYDXJ"] = num5;
                    row["FCSYDZSFY"] = num6;
                    row["CSYDMJ"] = num7;
                    row["CSYDXJ"] = num8;
                    row["CSYDZSFY"] = num9;
                    if (IsFillDJ)
                    {
                        if (num4 > 0.0)
                        {
                            row["FCSYDZSBZ"] = num13;
                        }
                        else
                        {
                            row["FCSYDZSBZ"] = num16 / 2.0;
                        }
                        if (num7 > 0.0)
                        {
                            row["CSYDZSBZ"] = num16;
                        }
                        else
                        {
                            row["CSYDZSBZ"] = num13 * 2.0;
                        }
                    }
                    table3.Rows.Add(row.ItemArray);
                }
                DataRow[] rowArray7 = table3.Select("MJHJ>0", null);
                if (rowArray7.Length > 0)
                {
                    foreach (DataRow row2 in rowArray7)
                    {
                        table.Rows.Add(row2.ItemArray);
                    }
                }
                else if (str7 != "6")
                {
                    table.Rows.Add(table3.Rows[0].ItemArray);
                }
                table3.Clear();
            }
            System.Data.DataTable table4 = table.Clone();
            for (int j = DistXMQLDQSList.Count; j > 0; j--)
            {
                num = 0.0;
                num2 = 0.0;
                num3 = 0.0;
                num4 = 0.0;
                num5 = 0.0;
                num6 = 0.0;
                num7 = 0.0;
                num8 = 0.0;
                num9 = 0.0;
                string str13 = DistXMQLDQSList[j - 1].ToString();
                string str14 = "LDQS='" + str13 + "'";
                DataRow row4 = table.NewRow();
                row4[0] = tjdw;
                row4["LDQS"] = str13;
                if (mytjdt.Select(str14).Length > 0)
                {
                    num = Convert.ToDouble(mytjdt.Compute(expression, str14)) * 10000.0;
                    num2 = Convert.ToDouble(mytjdt.Compute(str2, str14));
                    num3 = Convert.ToDouble(mytjdt.Compute(str3, str14));
                }
                str14 = "LDQS='" + str13 + "' AND " + str5;
                if (mytjdt.Select(str14).Length > 0)
                {
                    num4 = Convert.ToDouble(mytjdt.Compute(expression, str14)) * 10000.0;
                    num5 = Convert.ToDouble(mytjdt.Compute(str2, str14));
                    num6 = Convert.ToDouble(mytjdt.Compute(str3, str14));
                }
                str14 = "LDQS='" + str13 + "' AND " + str4;
                if (mytjdt.Select(str14).Length > 0)
                {
                    num7 = Convert.ToDouble(mytjdt.Compute(expression, str14)) * 10000.0;
                    num8 = Convert.ToDouble(mytjdt.Compute(str2, str14));
                    num9 = Convert.ToDouble(mytjdt.Compute(str3, str14));
                }
                row4[1] = "合计";
                row4["MJHJ"] = num;
                row4["XJHJ"] = num2;
                row4["ZZSFHJ"] = num3;
                row4["FCSYDMJ"] = num4;
                row4["FCSYDXJ"] = num5;
                row4["FCSYDZSFY"] = num6;
                row4["CSYDMJ"] = num7;
                row4["CSYDXJ"] = num8;
                row4["CSYDZSFY"] = num9;
                table.Rows.InsertAt(row4, 0);
                table4.Rows.Add(row4.ItemArray);
            }
            DataRow row3 = table.NewRow();
            row3[0] = tjdw;
            row3[1] = "合计";
            for (int k = 4; k < 9; k++)
            {
                row3[k] = Convert.ToDouble(table4.Compute("SUM(" + table4.Columns[k] + ")", null));
            }
            for (int m = 10; m < 13; m++)
            {
                row3[m] = Convert.ToDouble(table4.Compute("SUM(" + table4.Columns[m] + ")", null));
            }
            row3[14] = Convert.ToDouble(table4.Compute("SUM(" + table4.Columns[14] + ")", null));
            table.Rows.InsertAt(row3, 0);
            return table;
        }

        private System.Data.DataTable B6UpdateDWTableByJoin(System.Data.DataTable dataTable_0)
        {
            string cmdtxt = " SELECT CCODE,CNAME,CSNAME,CINDEX FROM " + TABLE_XZDWTABLE + " WHERE (CINDEX > '101') AND (CINDEX < '106') OR (CINDEX = '207')";
            System.Data.DataTable table = this.GetTable(cmdtxt, "xcdm");
            System.Data.DataTable dataTabeBySelRows = this.GetDataTabeBySelRows(table, "CINDEX > '101' AND CINDEX < '106'");
            foreach (var type in Enumerable.Join(DataTableExtensions.AsEnumerable(dataTable_0), DataTableExtensions.AsEnumerable(dataTabeBySelRows), delegate(DataRow dataRow_0)
            {
                return DataRowExtensions.Field<string>(dataRow_0, "tjdw");
            }, delegate(DataRow dataRow_0)
            {
                return DataRowExtensions.Field<string>(dataRow_0, "CCODE");
            }, delegate(DataRow dataRow_0, DataRow dataRow_1)
            {
                return new
                {
                    dt1row = dataRow_0,
                    dt2row = dataRow_1
                };
            }))
            {
                type.dt1row["tjdw"] = type.dt2row["CNAME"];
            }
            dataTabeBySelRows = this.GetDataTabeBySelRows(table, "CINDEX = '207'");
            foreach (var type2 in Enumerable.Join(DataTableExtensions.AsEnumerable(dataTable_0), DataTableExtensions.AsEnumerable(dataTabeBySelRows), delegate(DataRow dataRow_0)
            {
                return DataRowExtensions.Field<string>(dataRow_0, "LDQS");
            }, delegate(DataRow dataRow_0)
            {
                return DataRowExtensions.Field<string>(dataRow_0, "CCODE");
            }, delegate(DataRow dataRow_0, DataRow dataRow_1)
            {
                return new
                {
                    dt1row = dataRow_0,
                    dt2row = dataRow_1
                };
            }))
            {
                type2.dt1row["LDQS"] = type2.dt2row["CSNAME"].ToString().Substring(0, 2);
            }
            dataTabeBySelRows = this.LDLXTable();
            foreach (var type3 in Enumerable.Join(DataTableExtensions.AsEnumerable(dataTable_0), DataTableExtensions.AsEnumerable(dataTabeBySelRows), delegate(DataRow dataRow_0)
            {
                return DataRowExtensions.Field<string>(dataRow_0, "LDLX");
            }, delegate(DataRow dataRow_0)
            {
                return DataRowExtensions.Field<string>(dataRow_0, "DM");
            }, delegate(DataRow dataRow_0, DataRow dataRow_1)
            {
                return new
                {
                    dt1row = dataRow_0,
                    dt2row = dataRow_1
                };
            }))
            {
                type3.dt1row["LDLX"] = type3.dt2row["MC"];
            }
            return dataTable_0;
        }

        private System.Data.DataTable B7()
        {
            System.Data.DataTable table = new System.Data.DataTable("ResultTable");
            DataColumn column = new DataColumn("XIAN", typeof(string));
            table.Columns.Add(column);
            column = new DataColumn("XIANG", typeof(string));
            table.Columns.Add(column);
            column = new DataColumn("CUN", typeof(string));
            table.Columns.Add(column);
            column = new DataColumn("LINBAN", typeof(string));
            table.Columns.Add(column);
            column = new DataColumn("XIAOBAN", typeof(string));
            table.Columns.Add(column);
            column = new DataColumn("LDQS", typeof(string));
            table.Columns.Add(column);
            column = new DataColumn("LMQS", typeof(string));
            table.Columns.Add(column);
            column = new DataColumn("LDLX", typeof(string));
            table.Columns.Add(column);
            column = new DataColumn("TDZL", typeof(string));
            table.Columns.Add(column);
            column = new DataColumn("LZ", typeof(string));
            table.Columns.Add(column);
            column = new DataColumn("YSSZ", typeof(string));
            table.Columns.Add(column);
            column = new DataColumn("MJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("XJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("SLLB", typeof(string));
            table.Columns.Add(column);
            column = new DataColumn("SQJ", typeof(string));
            table.Columns.Add(column);
            column = new DataColumn("BZ", typeof(string));
            table.Columns.Add(column);
            column = new DataColumn("QYLX", typeof(string));
            table.Columns.Add(column);
            return table;
        }

        private System.Data.DataTable B7UpdateXBTableByJoin(System.Data.DataTable dataTable_0)
        {
            string cmdtxt = (" SELECT CCODE,CNAME,CSNAME,CINDEX FROM " + TABLE_XZDWTABLE + " WHERE (CINDEX = '102') OR (CINDEX = '103') OR (CINDEX = '104') OR (CINDEX = '105') ") + " OR (CINDEX = '209') OR (CINDEX = '211') OR (CINDEX = '212') OR (CINDEX = '214') OR (CINDEX = '215') OR (CINDEX = '219') " + " OR (CINDEX = '223') OR (CINDEX = '225') OR (CINDEX = '226') OR (CINDEX = '227') OR (CINDEX = '258')";
            System.Data.DataTable table = this.GetTable(cmdtxt, "xcdm");
            System.Data.DataTable dataTabeBySelRows = this.GetDataTabeBySelRows(table, "CINDEX='103'");
            string pcode = "CCODE";
            string str2 = "CNAME";
            foreach (var type in Enumerable.Join(DataTableExtensions.AsEnumerable(dataTable_0), DataTableExtensions.AsEnumerable(dataTabeBySelRows), delegate(DataRow dataRow_0)
            {
                return DataRowExtensions.Field<string>(dataRow_0, "XIAN");
            }, delegate(DataRow dataRow_0)
            {
                return DataRowExtensions.Field<string>(dataRow_0, pcode);
            }, delegate(DataRow dataRow_0, DataRow dataRow_1)
            {
                return new
                {
                    dt1row = dataRow_0,
                    dt2row = dataRow_1
                };
            }))
            {
                type.dt1row["XIAN"] = type.dt2row[str2];
            }
            dataTabeBySelRows = this.GetDataTabeBySelRows(table, "CINDEX='104'");
            foreach (var type2 in Enumerable.Join(DataTableExtensions.AsEnumerable(dataTable_0), DataTableExtensions.AsEnumerable(dataTabeBySelRows), delegate(DataRow dataRow_0)
            {
                return DataRowExtensions.Field<string>(dataRow_0, "XIANG");
            }, delegate(DataRow dataRow_0)
            {
                return DataRowExtensions.Field<string>(dataRow_0, pcode);
            }, delegate(DataRow dataRow_0, DataRow dataRow_1)
            {
                return new
                {
                    dt1row = dataRow_0,
                    dt2row = dataRow_1
                };
            }))
            {
                type2.dt1row["XIANG"] = type2.dt2row[str2];
            }
            dataTabeBySelRows = this.GetDataTabeBySelRows(table, "CINDEX='105'");
            foreach (var type3 in Enumerable.Join(DataTableExtensions.AsEnumerable(dataTable_0), DataTableExtensions.AsEnumerable(dataTabeBySelRows), delegate(DataRow dataRow_0)
            {
                return DataRowExtensions.Field<string>(dataRow_0, "CUN");
            }, delegate(DataRow dataRow_0)
            {
                return DataRowExtensions.Field<string>(dataRow_0, pcode);
            }, delegate(DataRow dataRow_0, DataRow dataRow_1)
            {
                return new
                {
                    dt1row = dataRow_0,
                    dt2row = dataRow_1
                };
            }))
            {
                type3.dt1row["CUN"] = type3.dt2row[str2];
            }
            dataTabeBySelRows = this.GetDataTabeBySelRows(table, "CINDEX='209'");
            string tname = "LMSYQ";
            str2 = "CSNAME";
            foreach (var type4 in Enumerable.Join(DataTableExtensions.AsEnumerable(dataTable_0), DataTableExtensions.AsEnumerable(dataTabeBySelRows), delegate(DataRow dataRow_0)
            {
                return DataRowExtensions.Field<string>(dataRow_0, tname);
            }, delegate(DataRow dataRow_0)
            {
                return DataRowExtensions.Field<string>(dataRow_0, pcode);
            }, delegate(DataRow dataRow_0, DataRow dataRow_1)
            {
                return new
                {
                    dt1row = dataRow_0,
                    dt2row = dataRow_1
                };
            }))
            {
                type4.dt1row[tname] = type4.dt2row[str2];
            }
            dataTabeBySelRows = this.GetDataTabeBySelRows(table, "CINDEX='211'");
            tname = "TDZL";
            foreach (var type5 in Enumerable.Join(DataTableExtensions.AsEnumerable(dataTable_0), DataTableExtensions.AsEnumerable(dataTabeBySelRows), delegate(DataRow dataRow_0)
            {
                return DataRowExtensions.Field<string>(dataRow_0, tname);
            }, delegate(DataRow dataRow_0)
            {
                return DataRowExtensions.Field<string>(dataRow_0, pcode);
            }, delegate(DataRow dataRow_0, DataRow dataRow_1)
            {
                return new
                {
                    dt1row = dataRow_0,
                    dt2row = dataRow_1
                };
            }))
            {
                type5.dt1row[tname] = type5.dt2row[str2];
            }
            dataTabeBySelRows = this.GetDataTabeBySelRows(table, "CINDEX='212'");
            tname = "LIN_ZHONG";
            foreach (var type6 in Enumerable.Join(DataTableExtensions.AsEnumerable(dataTable_0), DataTableExtensions.AsEnumerable(dataTabeBySelRows), delegate(DataRow dataRow_0)
            {
                return DataRowExtensions.Field<string>(dataRow_0, tname);
            }, delegate(DataRow dataRow_0)
            {
                return DataRowExtensions.Field<string>(dataRow_0, pcode);
            }, delegate(DataRow dataRow_0, DataRow dataRow_1)
            {
                return new
                {
                    dt1row = dataRow_0,
                    dt2row = dataRow_1
                };
            }))
            {
                type6.dt1row[tname] = type6.dt2row[str2];
            }
            dataTabeBySelRows = this.GetDataTabeBySelRows(table, "CINDEX='214'");
            tname = "SLLB";
            foreach (var type7 in Enumerable.Join(DataTableExtensions.AsEnumerable(dataTable_0), DataTableExtensions.AsEnumerable(dataTabeBySelRows), delegate(DataRow dataRow_0)
            {
                return DataRowExtensions.Field<string>(dataRow_0, tname);
            }, delegate(DataRow dataRow_0)
            {
                return DataRowExtensions.Field<string>(dataRow_0, pcode);
            }, delegate(DataRow dataRow_0, DataRow dataRow_1)
            {
                return new
                {
                    dt1row = dataRow_0,
                    dt2row = dataRow_1
                };
            }))
            {
                type7.dt1row[tname] = type7.dt2row[str2];
            }
            dataTabeBySelRows = this.GetDataTabeBySelRows(table, "CINDEX='215'");
            tname = "SQJ";
            foreach (var type8 in Enumerable.Join(DataTableExtensions.AsEnumerable(dataTable_0), DataTableExtensions.AsEnumerable(dataTabeBySelRows), delegate(DataRow dataRow_0)
            {
                return DataRowExtensions.Field<string>(dataRow_0, tname);
            }, delegate(DataRow dataRow_0)
            {
                return DataRowExtensions.Field<string>(dataRow_0, pcode);
            }, delegate(DataRow dataRow_0, DataRow dataRow_1)
            {
                return new
                {
                    dt1row = dataRow_0,
                    dt2row = dataRow_1
                };
            }))
            {
                type8.dt1row[tname] = type8.dt2row[str2];
            }
            dataTabeBySelRows = this.GetDataTabeBySelRows(table, "CINDEX='219'");
            tname = "YOU_SHI_SZ";
            str2 = "CNAME";
            foreach (var type9 in Enumerable.Join(DataTableExtensions.AsEnumerable(dataTable_0), DataTableExtensions.AsEnumerable(dataTabeBySelRows), delegate(DataRow dataRow_0)
            {
                return DataRowExtensions.Field<string>(dataRow_0, tname);
            }, delegate(DataRow dataRow_0)
            {
                return DataRowExtensions.Field<string>(dataRow_0, pcode);
            }, delegate(DataRow dataRow_0, DataRow dataRow_1)
            {
                return new
                {
                    dt1row = dataRow_0,
                    dt2row = dataRow_1
                };
            }))
            {
                type9.dt1row[tname] = type9.dt2row[str2];
            }
            dataTabeBySelRows = this.GetDataTabeBySelRows(table, "CINDEX='258'");
            tname = "LDLX";
            foreach (var type10 in Enumerable.Join(DataTableExtensions.AsEnumerable(dataTable_0), DataTableExtensions.AsEnumerable(dataTabeBySelRows), delegate(DataRow dataRow_0)
            {
                return DataRowExtensions.Field<string>(dataRow_0, tname);
            }, delegate(DataRow dataRow_0)
            {
                return DataRowExtensions.Field<string>(dataRow_0, pcode);
            }, delegate(DataRow dataRow_0, DataRow dataRow_1)
            {
                return new
                {
                    dt1row = dataRow_0,
                    dt2row = dataRow_1
                };
            }))
            {
                type10.dt1row[tname] = type10.dt2row[str2];
            }
            dataTabeBySelRows = this.GetDataTabeBySelRows(table, "CINDEX='223'");
            tname = "ZLDJ";
            foreach (var type11 in Enumerable.Join(DataTableExtensions.AsEnumerable(dataTable_0), DataTableExtensions.AsEnumerable(dataTabeBySelRows), delegate(DataRow dataRow_0)
            {
                return DataRowExtensions.Field<string>(dataRow_0, tname);
            }, delegate(DataRow dataRow_0)
            {
                return DataRowExtensions.Field<string>(dataRow_0, pcode);
            }, delegate(DataRow dataRow_0, DataRow dataRow_1)
            {
                return new
                {
                    dt1row = dataRow_0,
                    dt2row = dataRow_1
                };
            }))
            {
                type11.dt1row[tname] = type11.dt2row[str2];
            }
            dataTabeBySelRows = this.GetDataTabeBySelRows(table, "CINDEX='225'");
            tname = "BHDJ";
            foreach (var type12 in Enumerable.Join(DataTableExtensions.AsEnumerable(dataTable_0), DataTableExtensions.AsEnumerable(dataTabeBySelRows), delegate(DataRow dataRow_0)
            {
                return DataRowExtensions.Field<string>(dataRow_0, tname);
            }, delegate(DataRow dataRow_0)
            {
                return DataRowExtensions.Field<string>(dataRow_0, pcode);
            }, delegate(DataRow dataRow_0, DataRow dataRow_1)
            {
                return new
                {
                    dt1row = dataRow_0,
                    dt2row = dataRow_1
                };
            }))
            {
                type12.dt1row[tname] = type12.dt2row[str2];
            }
            dataTabeBySelRows = this.GetDataTabeBySelRows(table, "CINDEX='226'");
            tname = "LYFQ";
            foreach (var type13 in Enumerable.Join(DataTableExtensions.AsEnumerable(dataTable_0), DataTableExtensions.AsEnumerable(dataTabeBySelRows), delegate(DataRow dataRow_0)
            {
                return DataRowExtensions.Field<string>(dataRow_0, tname);
            }, delegate(DataRow dataRow_0)
            {
                return DataRowExtensions.Field<string>(dataRow_0, pcode);
            }, delegate(DataRow dataRow_0, DataRow dataRow_1)
            {
                return new
                {
                    dt1row = dataRow_0,
                    dt2row = dataRow_1
                };
            }))
            {
                type13.dt1row[tname] = type13.dt2row[str2];
            }
            dataTabeBySelRows = this.GetDataTabeBySelRows(table, "CINDEX='227'");
            tname = "QYKZ";
            foreach (var type14 in Enumerable.Join(DataTableExtensions.AsEnumerable(dataTable_0), DataTableExtensions.AsEnumerable(dataTabeBySelRows), delegate(DataRow dataRow_0)
            {
                return DataRowExtensions.Field<string>(dataRow_0, tname);
            }, delegate(DataRow dataRow_0)
            {
                return DataRowExtensions.Field<string>(dataRow_0, pcode);
            }, delegate(DataRow dataRow_0, DataRow dataRow_1)
            {
                return new
                {
                    dt1row = dataRow_0,
                    dt2row = dataRow_1
                };
            }))
            {
                type14.dt1row[tname] = type14.dt2row[str2];
            }
            return dataTable_0;
        }

        public System.Data.DataTable B7XMXBTable(string ydzl)
        {
            System.Data.DataTable table = new System.Data.DataTable();
            string cmdtxt = "SELECT LTRIM(RTRIM(XIAN)) AS XIAN,LTRIM(RTRIM(XIANG)) AS XIANG,LTRIM(RTRIM(CUN)) AS CUN,LEFT(LTRIM(RTRIM(LIN_BAN)),2) AS LIN_BAN,RIGHT(LTRIM(RTRIM(LIN_BAN)),2) AS JYBAN,LTRIM(RTRIM(XIAO_BAN)) AS XIAO_BAN,";
            string str2 = cmdtxt + "LTRIM(RTRIM(Q_LD_QS)) AS LDQS,LTRIM(RTRIM(LMSYQ)) AS LMSYQ,LTRIM(RTRIM(LDLX)) AS LDLX,LTRIM(RTRIM(Q_DI_LEI)) AS TDZL,LTRIM(RTRIM(Q_LIN_ZHONG)) AS LIN_ZHONG,LTRIM(RTRIM(YOU_SHI_SZ)) AS YOU_SHI_SZ,MIAN_JI,SLXJ, " + "LTRIM(RTRIM(Q_SEN_LB)) AS SLLB,LTRIM(RTRIM(SHI_QUAN_D)) AS SQJ,LTRIM(RTRIM(BZ)) AS BZ,LTRIM(RTRIM(YDFW)) AS YDFW,LTRIM(RTRIM(QYKZ)) AS QYKZ,LTRIM(RTRIM(LYFQ)) AS LYFQ,LTRIM(RTRIM(BH_DJ)) AS BHDJ,";
            cmdtxt = str2 + "LTRIM(RTRIM(ZL_DJ)) AS ZLDJ FROM " + TABLE_ZZYTableName + "  WHERE (RTRIM(LTRIM(XMMC))='" + TABLE_ZZYXMMC + "')  AND (RTRIM(LTRIM(YDZL))='" + ydzl + "')";
            table = this.GetTable(cmdtxt, TABLE_ZZYTableName);
            if (table == null)
            {
                MessageBox.Show(TABLE_ZZYTableName + " B7读取数据库出错！", "信息", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return null;
            }
            if (table.Rows.Count == 0)
            {
                MessageBox.Show(TABLE_ZZYXMMC + " 该项目没有有效数据，请检查！", "信息", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return table;
            }
            for (int i = 0; i < table.Rows.Count; i++)
            {
                string str3 = table.Rows[i]["LDQS"].ToString().Trim();
                if (str3.Length > 0)
                {
                    if (str3.Substring(0, 1) == "1")
                    {
                        table.Rows[i]["LDQS"] = "国有";
                    }
                    if (str3.Substring(0, 1) == "2")
                    {
                        table.Rows[i]["LDQS"] = "集体";
                    }
                }
                string str4 = table.Rows[i]["YDFW"].ToString().Trim();
                if (str4.Length > 0)
                {
                    if (str4.Substring(0, 1) == "1")
                    {
                        table.Rows[i]["YDFW"] = "城市用地";
                    }
                    if (str4.Substring(0, 1) == "2")
                    {
                        table.Rows[i]["YDFW"] = "非城市用地";
                    }
                }
            }
            return this.B7UpdateXBTableByJoin(table);
        }

        public System.Data.DataTable BHDJTJTableXianXiangCun(string ydzl)
        {
            System.Data.DataTable table = new System.Data.DataTable("tjtable");
            table.Columns.Add("TJDW", typeof(string));
            table.Columns.Add("MJHJ", typeof(double));
            table.Columns.Add("XJHJ", typeof(double));
            for (int i = 1; i < 6; i++)
            {
                table.Columns.Add("C" + i.ToString() + "MJ", typeof(double));
                table.Columns.Add("C" + i.ToString() + "XJ", typeof(double));
            }
            try
            {
                System.Data.DataTable mytjdt = new System.Data.DataTable();
                string cmdtxt = "SELECT LTRIM(RTRIM(SHI)) AS SHI,LTRIM(RTRIM(XIAN)) AS XIAN,LTRIM(RTRIM(XIANG)) AS XIANG,LTRIM(RTRIM(CUN)) AS CUN,LTRIM(RTRIM(BH_DJ)) AS zldj,MIAN_JI,SLXJ FROM " + TABLE_ZZYTableName + " WHERE (RTRIM(LTRIM(XMMC))='" + TABLE_ZZYXMMC + "') AND LTRIM(RTRIM(YDZL))='" + ydzl + "'";
                mytjdt = this.GetTable(cmdtxt, TABLE_ZZYTableName);
                if (mytjdt == null)
                {
                    MessageBox.Show(TABLE_ZZYTableName + " 林地保护等级数据读取出错！", "信息", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return null;
                }
                if (mytjdt.Rows.Count == 0)
                {
                    return table;
                }
                List<string> list4 = new List<string>();
                List<string> list2 = new List<string>();
                for (int j = 0; j < mytjdt.Rows.Count; j++)
                {
                    string item = mytjdt.Rows[j]["SHI"].ToString().Trim();
                    if (!list4.Contains(item))
                    {
                        list4.Add(item);
                    }
                }
                list4.Sort();
                System.Data.DataTable table7 = new System.Data.DataTable("tjdt");
                table7 = this.ZLDJSimpleTJTable("项目区", mytjdt);
                foreach (DataRow row4 in table7.Rows)
                {
                    table.ImportRow(row4);
                }
                System.Data.DataTable table6 = mytjdt.Clone();
                for (int k = 0; k < list4.Count; k++)
                {
                    table6.Clear();
                    string tjdw = list4[k].ToString();
                    foreach (DataRow row2 in mytjdt.Select("SHI='" + tjdw + "'"))
                    {
                        table6.Rows.Add(row2.ItemArray);
                    }
                    list2.Clear();
                    for (int m = 0; m < table6.Rows.Count; m++)
                    {
                        string str3 = table6.Rows[m]["XIAN"].ToString();
                        if (!list2.Contains(str3))
                        {
                            list2.Add(str3);
                        }
                    }
                    list2.Sort();
                    table7.Clear();
                    table7 = this.ZLDJSimpleTJTable(tjdw, table6);
                    foreach (DataRow row6 in table7.Rows)
                    {
                        table.ImportRow(row6);
                    }
                    System.Data.DataTable table4 = new System.Data.DataTable("xian");
                    table4 = mytjdt.Clone();
                    for (int n = 0; n < list2.Count; n++)
                    {
                        table4.Clear();
                        string str5 = list2[n].ToString();
                        foreach (DataRow row3 in table6.Select("XIAN='" + str5 + "'"))
                        {
                            table4.Rows.Add(row3.ItemArray);
                        }
                        table7.Clear();
                        table7 = this.ZLDJSimpleTJTable(str5, table4);
                        foreach (DataRow row8 in table7.Rows)
                        {
                            table.ImportRow(row8);
                        }
                        List<string> list = new List<string>();
                        list.Clear();
                        for (int num2 = 0; num2 < table4.Rows.Count; num2++)
                        {
                            string str4 = table4.Rows[num2]["XIANG"].ToString();
                            if (!list.Contains(str4))
                            {
                                list.Add(str4);
                            }
                        }
                        list.Sort();
                        System.Data.DataTable table5 = mytjdt.Clone();
                        for (int num3 = 0; num3 < list.Count; num3++)
                        {
                            table5.Clear();
                            string str9 = list[num3].ToString();
                            foreach (DataRow row5 in table4.Select("XIANG='" + str9 + "'"))
                            {
                                table5.Rows.Add(row5.ItemArray);
                            }
                            table7.Clear();
                            table7 = this.ZLDJSimpleTJTable(str9, table5);
                            foreach (DataRow row in table7.Rows)
                            {
                                table.ImportRow(row);
                            }
                            List<string> list3 = new List<string>();
                            list3.Clear();
                            for (int num9 = 0; num9 < table5.Rows.Count; num9++)
                            {
                                string str7 = table5.Rows[num9]["CUN"].ToString();
                                if (!list3.Contains(str7))
                                {
                                    list3.Add(str7);
                                }
                            }
                            list3.Sort();
                            System.Data.DataTable dataTabeBySelRows = mytjdt.Clone();
                            for (int num8 = 0; num8 < list3.Count; num8++)
                            {
                                dataTabeBySelRows.Clear();
                                string str8 = list3[num8].ToString();
                                dataTabeBySelRows = this.GetDataTabeBySelRows(table5, "CUN='" + str8 + "'");
                                table7.Clear();
                                table7 = this.ZLDJSimpleTJTable(str8, dataTabeBySelRows);
                                foreach (DataRow row7 in table7.Rows)
                                {
                                    table.ImportRow(row7);
                                }
                            }
                        }
                    }
                }
                table7.Clear();
                table6.Clear();
                mytjdt.Clear();
                table = this.UpdateDWTableByJoin(table);
            }
            catch (Exception exception)
            {
                MessageBox.Show("林地保护等级统计出错，错误:" + exception.ToString() + "\n\r请与程序提供者联系！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            return table;
        }

        public void BindComboBox(System.Data.DataTable mytable, ComboBox cbxname, string bindmember)
        {
            cbxname.BeginUpdate();
            cbxname.DataSource = mytable;
            cbxname.DisplayMember = bindmember;
            cbxname.ValueMember = bindmember;
            cbxname.EndUpdate();
        }

        public void BindToolBarComboBox(System.Data.DataTable pTable, ToolStripComboBox cbxname, string bindmember)
        {
            cbxname.BeginUpdate();
            cbxname.ComboBox.DataSource = pTable;
            cbxname.ComboBox.DisplayMember = bindmember;
            cbxname.ComboBox.ValueMember = bindmember;
            cbxname.EndUpdate();
        }

        private System.Data.DataTable ConvertGNFQTableColName(System.Data.DataTable ResultTable)
        {
            string cmdtxt = " SELECT CCODE,CSNAME FROM " + TABLE_XZDWTABLE + " WHERE (CINDEX = '226')";
            try
            {
                System.Data.DataTable table = this.GetTable(cmdtxt, "lyfq");
                if (table == null)
                {
                    return ResultTable;
                }
                int num = 2;
                for (int i = 3; i < ResultTable.Columns.Count; i++)
                {
                    DataRow[] rowArray = table.Select("CCODE='" + ResultTable.Columns[i].ToString().Split(new char[] { '_' })[1] + "'");
                    if (rowArray.Length > 0)
                    {
                        int num3 = (2 * num) - 1;
                        int num4 = 2 * num;
                        ResultTable.Columns[num3].ColumnName = rowArray[0]["CSNAME"].ToString().Trim() + "_mj";
                        ResultTable.Columns[num4].ColumnName = rowArray[0]["CSNAME"].ToString().Trim() + "_xj";
                    }
                    num++;
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("功能区名称转化出错，错误：" + exception.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            return ResultTable;
        }

        public void ExportDataGridview(DataGridView gridView)
        {
            try
            {
                object[] objArray = new object[gridView.ColumnCount - 1];
                for (int i = 0; i < (gridView.ColumnCount - 1); i++)
                {
                    objArray[i] = gridView.Columns[i + 1].Name;
                }
                int rowCount = gridView.RowCount;
                int num5 = gridView.ColumnCount - 1;
                object[,] objArray2 = new object[rowCount, num5];
                for (int j = 0; j < rowCount; j++)
                {
                    for (int k = 0; k < num5; k++)
                    {
                        objArray2[j, k] = gridView[k + 1, j].Value.ToString();
                    }
                }
                Microsoft.Office.Interop.Excel.Application application = new ApplicationClass();
                if (application == null)
                {
                    MessageBox.Show("不能建立EXCEL对象，请在机器上安装Office!", "信息", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
                else
                {
                    application.Visible = false;
                    application.Workbooks.Add(true);
                    Worksheet worksheet = application.Sheets[1] as Worksheet;
                    application.Visible = false;
                    worksheet.get_Range(worksheet.Cells[1, 1], worksheet.Cells[1, num5]).Value2 = objArray;
                    worksheet.get_Range(worksheet.Cells[2, 1], worksheet.Cells[rowCount + 1, num5]).Value2 = objArray2;
                    worksheet.get_Range(worksheet.Cells[1, 1], worksheet.Cells[rowCount + 1, num5]).Font.Name = "Arial";
                    worksheet.get_Range(worksheet.Cells[1, 1], worksheet.Cells[rowCount + 1, num5]).Font.Size = 10;
                    worksheet.get_Range(worksheet.Cells[1, 1], worksheet.Cells[rowCount + 1, num5]).Columns.AutoFit();
                    worksheet.get_Range(worksheet.Cells[1, 1], worksheet.Cells[rowCount + 1, num5]).Borders.LineStyle = 1;
                    application.ActiveWindow.DisplayZeros = false;
                    application.Visible = true;
                    worksheet = null;
                    MessageBox.Show("数据导出Excel完成!", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message.ToString(), "导出错误", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            finally
            {
                GC.Collect();
            }
        }

        public System.Data.DataTable ExportXBBCFTable()
        {
            try
            {
                string str2 = ("SELECT GXSJ,XMMC,XIAN,XIANG,CUN,LIN_BAN,XIAO_BAN,XI_BAN,Q_LD_QS,TDJYQ,LMSYQ,LMJYQ,MIAN_JI,Q_DI_LEI," + "LDLX,YDZL,YDFW,Q_SEN_LB,SHI_QUAN_D,GJGYL_BHDJ, BH_DJ,LYFQ,ZL_DJ,QYKZ,Q_LIN_ZHONG,YU_BI_DU,") + "JJLCQ,YOU_SHI_SZ,QI_YUAN,PINGJUN_NL,PINGJUN_XJ,PINGJUN_SG, PINGJUN_DM,MEI_GQ_ZS,LING_ZU," + "SLXJ,SFTGD,XZWZL,XZWCD,XZWKD,XZWMJ,BZ,LDBCDJ,LDBCF,LDAZFDJ,LDAZF,LMBCDJ,LMBCF,BCFHJ,ZBHFDJ,ZBHFF,ZFYHJ,";
                string cmdtxt = str2 + "'' AS 县名,'' AS 乡镇名,'' AS 村名 FROM " + TABLE_ZZYTableName + " WHERE LTRIM(RTRIM(XMMC))='" + TABLE_ZZYXMMC + "' ORDER BY CUN,LIN_BAN,XIAO_BAN";
                System.Data.DataTable source = this.GetTable(cmdtxt, "xbdt");
                if (source == null)
                {
                    return null;
                }
                if (source.Rows.Count != 0)
                {
                    string str3 = " SELECT CCODE,CNAME FROM " + TABLE_XZDWTABLE + " WHERE (CINDEX > '101') AND (CINDEX < '106')";
                    System.Data.DataTable table = this.GetTable(str3, "xcdm");
                    foreach (var type in Enumerable.Join(DataTableExtensions.AsEnumerable(source), DataTableExtensions.AsEnumerable(table), delegate(DataRow dataRow_0)
                    {
                        return DataRowExtensions.Field<string>(dataRow_0, "XIAN");
                    }, delegate(DataRow dataRow_0)
                    {
                        return DataRowExtensions.Field<string>(dataRow_0, "CCODE");
                    }, delegate(DataRow dataRow_0, DataRow dataRow_1)
                    {
                        return new
                        {
                            dt1row = dataRow_0,
                            dt2row = dataRow_1
                        };
                    }))
                    {
                        type.dt1row["县名"] = type.dt2row["CNAME"];
                    }
                    foreach (var type2 in Enumerable.Join(DataTableExtensions.AsEnumerable(source), DataTableExtensions.AsEnumerable(table), delegate(DataRow dataRow_0)
                    {
                        return DataRowExtensions.Field<string>(dataRow_0, "XIANG");
                    }, delegate(DataRow dataRow_0)
                    {
                        return DataRowExtensions.Field<string>(dataRow_0, "CCODE");
                    }, delegate(DataRow dataRow_0, DataRow dataRow_1)
                    {
                        return new
                        {
                            dt1row = dataRow_0,
                            dt2row = dataRow_1
                        };
                    }))
                    {
                        type2.dt1row["乡镇名"] = type2.dt2row["CNAME"];
                    }
                    foreach (var type3 in Enumerable.Join(DataTableExtensions.AsEnumerable(source), DataTableExtensions.AsEnumerable(table), delegate(DataRow dataRow_0)
                    {
                        return DataRowExtensions.Field<string>(dataRow_0, "CUN");
                    }, delegate(DataRow dataRow_0)
                    {
                        return DataRowExtensions.Field<string>(dataRow_0, "CCODE");
                    }, delegate(DataRow dataRow_0, DataRow dataRow_1)
                    {
                        return new
                        {
                            dt1row = dataRow_0,
                            dt2row = dataRow_1
                        };
                    }))
                    {
                        type3.dt1row["村名"] = type3.dt2row["CNAME"];
                    }
                }
                return source;
            }
            catch (Exception exception)
            {
                MessageBox.Show("导出小班补偿费用表出错，错误:" + exception.ToString() + "\n\r请与程序提供者联系！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return null;
            }
        }

        private SqlConnection GetCon()
        {
            if (M_Str_ConnectionString == null)
            {
                MessageBox.Show("请先进行数据库连接！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return null;
            }
            this.M_Con = new SqlConnection(M_Str_ConnectionString);
            try
            {
                this.M_Con.Open();
                return this.M_Con;
                ///SQLite retnull;

            }
            catch (Exception exception)
            {
                MessageBox.Show("打开数据库连接出错，错误：" + exception.Message, "连接错误", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return null;
            }
        }

        public System.Data.DataTable GetDataTabeBySelRows(System.Data.DataTable dataTable_0, string string_0)
        {
            if (dataTable_0 == null)
            {
                return null;
            }
            System.Data.DataTable table = dataTable_0.Clone();
            DataRow[] rowArray2 = dataTable_0.Select(string_0);
            if (rowArray2.Length < 0)
            {
                return null;
            }
            foreach (DataRow row in rowArray2)
            {
                table.Rows.Add(row.ItemArray);
            }
            return table;
        }

        public bool GetExecute(string cmdtxt)
        {
            bool flag;
            if (M_Str_ConnectionString == null)
            {
                return false;
            }
            this.M_Com = new SqlCommand(cmdtxt, this.GetCon());
            try
            {
                this.M_Com.ExecuteNonQuery();
                flag = true;
            }
            catch (Exception exception)
            {
                MessageBox.Show("错误：" + exception.Message, "错误提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Hand);
                flag = false;
            }
            finally
            {
                if (this.GetCon().State == ConnectionState.Open)
                {
                    this.GetCon().Close();
                    this.GetCon().Dispose();
                }
            }
            return flag;
        }

        /// <summary>
        /// 此处在查询关系数据库中的指定数据
        /// </summary>
        /// <param name="cmdtxt"></param>
        /// <param name="tablename"></param>
        /// <returns></returns>
        public System.Data.DataTable GetTable(string cmdtxt, string tablename)
        {
            System.Data.DataTable dataTable = null;
            System.Data.DataTable table2;
            try
            {
                ///注销使用 System.Data.SqlClient.SqlDataAdapter.SelectCommand 和 System.Data.SqlClient.SqlConnection
                ///    对象初始化 System.Data.SqlClient.SqlDataAdapter 类的一个新实例。
                ///    因为没有建立连接
                this.M_Da = new SqlDataAdapter(cmdtxt, this.GetCon());
                dataTable = new System.Data.DataTable(tablename);
                ///在 System.Data.DataSet 的指定范围中添加或刷新行，以与使用 System.Data.DataTable 名称的数据源中的行匹配。
                this.M_Da.Fill(dataTable);///注销此代码
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

        public int intRecordsInTable(string Sql)
        {
            int count;
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter(Sql, this.GetCon());
                System.Data.DataTable dataTable = new System.Data.DataTable();
                adapter.Fill(dataTable);
                count = dataTable.Rows.Count;
            }
            catch (Exception exception)
            {
                MessageBox.Show("错误：" + exception.Message, "错误提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Hand);
                count = 0;
            }
            finally
            {
                if (this.GetCon().State == ConnectionState.Open)
                {
                    this.GetCon().Close();
                    this.GetCon().Dispose();
                }
            }
            return count;
        }

        public void JSBCFYCol(string pselxmmc)
        {
            if (pselxmmc.Trim().Length > 0)
            {
                System.Data.DataTable table = null;
                string str2 = " SELECT XMMC,BCLXCODE,BCLXNAME,BCDJ,TJBDS FROM " + TABLE_BCFBZB + " WHERE LTRIM(RTRIM(BCLXCODE))=4 AND (LTRIM(RTRIM(XMMC))='') ";
                string cmdtxt = str2 + " UNION ALL SELECT XMMC,BCLXCODE,BCLXNAME, BCDJ, TJBDS FROM " + TABLE_BCFBZB + " WHERE (LTRIM(RTRIM(XMMC))='" + pselxmmc + "')";
                table = this.GetTable(cmdtxt, "jsdt");
                if (table == null)
                {
                    MessageBox.Show("读取补偿标准表数据出错，请与管理员联系！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
                else if (table.Rows.Count > 0)
                {
                    string str5 = " UPDATE " + TABLE_ZZYTableName + " SET ";
                    string str6 = " LTRIM(RTRIM(XMMC))='" + pselxmmc + "' AND ";
                    SqlConnection connection = new SqlConnection(M_Str_ConnectionString);
                    connection.Open();
                    foreach (DataRow row in table.Rows)
                    {
                        string str3 = row["BCLXCODE"].ToString().Trim();
                        double num = Convert.ToDouble(row["bcdj"]);
                        string str4 = row["tjbds"].ToString().Trim();
                        switch (str3)
                        {
                            case "1":
                                new SqlCommand(string.Concat(new object[] { str5, " LDBCDJ =", num, ",LDBCF=", num, "*15*MIAN_JI WHERE ", str6, str4 }), connection).ExecuteNonQuery();
                                break;

                            case "2":
                                new SqlCommand(string.Concat(new object[] { str5, " LDAZFDJ =", num, ",LDAZF=", num, "*15*MIAN_JI WHERE ", str6, str4 }), connection).ExecuteNonQuery();
                                break;

                            case "3":
                                new SqlCommand(string.Concat(new object[] { str5, " LMBCDJ =", num, ",LMBCF=", num, "*15*MIAN_JI WHERE ", str6, str4 }), connection).ExecuteNonQuery();
                                break;

                            case "4":
                                {
                                    SqlCommand command4 = new SqlCommand(string.Concat(new object[] { str5, " ZBHFDJ =", num * 2.0, ",ZBHFF=", num * 2.0, "*10000*MIAN_JI WHERE ", str6, " (LTRIM(RTRIM(YDFW))='1') AND ", str4 }), connection);
                                    command4.ExecuteNonQuery();
                                    new SqlCommand(string.Concat(new object[] { str5, " ZBHFDJ =", num, ",ZBHFF=", num, "*10000*MIAN_JI WHERE ", str6, " (LTRIM(RTRIM(YDFW))='2') AND ", str4 }), connection).ExecuteNonQuery();
                                    break;
                                }
                        }
                    }
                    new SqlCommand(str5 + " BCFHJ =LDBCF+LDAZF+LMBCF,ZFYHJ=LDBCF+LDAZF+LMBCF+ZBHFF WHERE LTRIM(RTRIM(XMMC))='" + pselxmmc + "'", connection).ExecuteNonQuery();
                    connection.Close();
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ydzl"></param>
        /// <returns></returns>
        public System.Data.DataTable JSSXFYJSB(string ydzl)
        {
            System.Data.DataTable source = new System.Data.DataTable("tjtable");
            source = this.SXFYJSTABLE();
            string cmdtxt = "SELECT LTRIM(RTRIM(SHI)) AS SHI,LTRIM(RTRIM(XIAN)) AS XIAN,LTRIM(RTRIM(XIANG)) AS XIANG,LTRIM(RTRIM(CUN)) AS CUN,LIN_BAN,XIAO_BAN,LDLX,Q_DI_LEI AS DI_LEI,Q_LIN_ZHONG AS LIN_ZHONG,";
            string str2 = cmdtxt + "YOU_SHI_SZ,YU_BI_DU,LING_ZU,JJLCQ,MIAN_JI AS MJ,LDBCDJ,LDBCF,LDAZFDJ,LDAZF,LMBCDJ,LMBCF,BCFHJ,ZBHFF,ZFYHJ FROM " + TABLE_ZZYTableName;
            cmdtxt = str2 + " WHERE (LTRIM(RTRIM(XMMC))='" + TABLE_ZZYXMMC + "') AND (LTRIM(RTRIM(YDZL))='" + ydzl + "')";
            System.Data.DataTable table = this.GetTable(cmdtxt, "xbdata");
            table = this.GetTable(cmdtxt, TABLE_ZZYTableName);
            if (table == null)
            {
                MessageBox.Show(TABLE_ZZYTableName + " 四项补偿费用数据读取出错！", "信息", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return null;
            }
            if (table.Rows.Count != 0)
            {
                table.Columns.Add("PTDZL", typeof(string));
                table.Columns.Add("PLINGZU", typeof(string));
                table.Columns.Add("PXBID", typeof(string));
                foreach (DataRow row in table.Rows)
                {
                    string str6 = row["CUN"].ToString().Trim() + row["LIN_BAN"].ToString().Trim() + row["XIAO_BAN"].ToString().Trim().PadLeft(6);
                    row["PXBID"] = str6;
                    string str5 = row["DI_LEI"].ToString().Trim();
                    row["PTDZL"] = str5;
                    switch (str5)
                    {
                        case "111":
                        case "112":
                            str5 = "110";
                            row["PTDZL"] = str5;
                            break;
                    }
                    string str4 = row["LING_ZU"].ToString().Trim();
                    row["PLINGZU"] = str4;
                    string str3 = row["JJLCQ"].ToString().Trim();
                    if (str3.Length > 0)
                    {
                        if (str3 == "1")
                        {
                            str3 = "6";
                        }
                        else if (str3 == "2")
                        {
                            str3 = "7";
                        }
                        else if (str3 == "3")
                        {
                            str3 = "8";
                        }
                        else if (str3 == "4")
                        {
                            str3 = "9";
                        }
                        row["PLINGZU"] = str3;
                    }
                }
                DataRow row2 = this.SXFYTJRow(0, "项目区", table, "null");
                source.Rows.Add(row2.ItemArray);
                List<string> list = new List<string>();
                List<string> list2 = new List<string>();
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    string item = table.Rows[i]["SHI"].ToString().Trim();
                    if (!list.Contains(item))
                    {
                        list.Add(item);
                    }
                }
                list.Sort();
                System.Data.DataTable mytjdt = table.Clone();
                for (int j = 0; j < list.Count; j++)
                {
                    mytjdt.Clear();
                    string tjdw = list[j].ToString();
                    mytjdt = this.GetDataTabeBySelRows(table, "SHI='" + tjdw + "'");
                    row2 = this.SXFYTJRow(1, tjdw, mytjdt, "SHI='" + tjdw + "'");
                    source.Rows.Add(row2.ItemArray);
                    list2.Clear();
                    for (int k = 0; k < mytjdt.Rows.Count; k++)
                    {
                        string str9 = mytjdt.Rows[k]["XIAN"].ToString();
                        if (!list2.Contains(str9))
                        {
                            list2.Add(str9);
                        }
                    }
                    list2.Sort();
                    for (int m = 0; m < list2.Count; m++)
                    {
                        string str10 = list2[m].ToString();
                        System.Data.DataTable table4 = this.GetDataTabeBySelRows(mytjdt, "XIAN='" + str10 + "'");
                        row2 = this.SXFYTJRow(2, str10, table4, "XIAN='" + str10 + "'");
                        source.Rows.Add(row2.ItemArray);
                        List<string> list3 = new List<string>();
                        list3.Clear();
                        for (int n = 0; n < table4.Rows.Count; n++)
                        {
                            string str11 = table4.Rows[n]["XIANG"].ToString();
                            if (!list3.Contains(str11))
                            {
                                list3.Add(str11);
                            }
                        }
                        list3.Sort();
                        for (int num6 = 0; num6 < list3.Count; num6++)
                        {
                            string str12 = list3[num6].ToString();
                            System.Data.DataTable table5 = this.GetDataTabeBySelRows(table4, "XIANG='" + str12 + "'");
                            row2 = this.SXFYTJRow(3, str12, table5, "XIANG='" + str12 + "'");
                            source.Rows.Add(row2.ItemArray);
                            List<string> list4 = new List<string>();
                            list4.Clear();
                            for (int num7 = 0; num7 < table5.Rows.Count; num7++)
                            {
                                string str13 = table5.Rows[num7]["CUN"].ToString();
                                if (!list4.Contains(str13))
                                {
                                    list4.Add(str13);
                                }
                            }
                            list4.Sort();
                            for (int num8 = 0; num8 < list4.Count; num8++)
                            {
                                string str14 = list4[num8].ToString();
                                System.Data.DataTable table6 = this.GetDataTabeBySelRows(table5, "CUN='" + str14 + "'");
                                row2 = this.SXFYTJRow(4, str14, table6, "CUN='" + str14 + "'");
                                source.Rows.Add(row2.ItemArray);
                                table6.DefaultView.Sort = "PXBID,LDLX,PTDZL,LIN_ZHONG,YOU_SHI_SZ,PLINGZU";
                                foreach (DataRow row3 in table6.Rows)
                                {
                                    DataRow row4 = source.NewRow();
                                    source.Rows.Add(row4);
                                    row4["XIAN"] = row3["XIAN"];
                                    row4["XIANG"] = row3["XIANG"];
                                    row4["CUN"] = row3["CUN"];
                                    row4["LDLX"] = row3["LDLX"];
                                    row4["TDZL"] = row3["PTDZL"];
                                    row4["LINZHONG"] = row3["LIN_ZHONG"];
                                    row4["SHUZHONG"] = row3["YOU_SHI_SZ"];
                                    row4["YBD"] = row3["YU_BI_DU"];
                                    row4["LINGZU"] = row3["PLINGZU"];
                                    row4["MJ"] = row3["MJ"];
                                    row4["LDBCBZ"] = row3["LDBCDJ"];
                                    row4["LDBCF"] = row3["LDBCF"];
                                    row4["LDAZBZ"] = row3["LDAZFDJ"];
                                    row4["LDAZF"] = row3["LDAZF"];
                                    row4["LMBCBZ"] = row3["LMBCDJ"];
                                    row4["LMBCF"] = row3["LMBCF"];
                                    row4["SXFYHJ"] = row3["BCFHJ"];
                                    row4["ZBHFF"] = row3["ZBHFF"];
                                    row4["ZFYHJ"] = row3["ZFYHJ"];
                                }
                            }
                        }
                    }
                }
                foreach (DataRow row5 in source.Rows)
                {
                    if (row5["TDZL"].ToString().Trim() == "110")
                    {
                        string str16 = "乔木林";
                        row5["TDZL"] = str16;
                    }
                    string str15 = row5["LINGZU"].ToString().Trim();
                    row5["LINGZU"] = str15;
                    switch (str15)
                    {
                        case "1":
                            str15 = "幼龄林";
                            break;

                        case "2":
                            str15 = "中龄林";
                            break;

                        case "3":
                            str15 = "近熟林";
                            break;

                        case "4":
                            str15 = "成熟林";
                            break;

                        case "5":
                            str15 = "过熟林";
                            break;

                        case "6":
                            str15 = "产前期";
                            break;

                        case "7":
                            str15 = "初产期";
                            break;

                        case "8":
                            str15 = "盛产期";
                            break;

                        case "9":
                            str15 = "衰产期";
                            break;
                    }
                    row5["LINGZU"] = str15;
                }
                string str17 = " SELECT CCODE,CNAME,CINDEX FROM " + TABLE_XZDWTABLE + " WHERE (CINDEX > '101') AND (CINDEX < '106') OR CINDEX='211' OR CINDEX='212' OR CINDEX='219' OR CINDEX='258'";
                System.Data.DataTable table7 = this.GetTable(str17, "xcdm");
                System.Data.DataTable dataTabeBySelRows = this.GetDataTabeBySelRows(table7, "CINDEX > '101' AND CINDEX < '106'");
                foreach (var type in Enumerable.Join(DataTableExtensions.AsEnumerable(source), DataTableExtensions.AsEnumerable(dataTabeBySelRows), delegate(DataRow dataRow_0)
                {
                    return DataRowExtensions.Field<string>(dataRow_0, "XIAN");
                }, delegate(DataRow dataRow_0)
                {
                    return DataRowExtensions.Field<string>(dataRow_0, "CCODE");
                }, delegate(DataRow dataRow_0, DataRow dataRow_1)
                {
                    return new
                    {
                        dt1row = dataRow_0,
                        dt2row = dataRow_1
                    };
                }))
                {
                    type.dt1row["XIAN"] = type.dt2row["CNAME"];
                }
                foreach (var type2 in Enumerable.Join(DataTableExtensions.AsEnumerable(source), DataTableExtensions.AsEnumerable(dataTabeBySelRows), delegate(DataRow dataRow_0)
                {
                    return DataRowExtensions.Field<string>(dataRow_0, "XIANG");
                }, delegate(DataRow dataRow_0)
                {
                    return DataRowExtensions.Field<string>(dataRow_0, "CCODE");
                }, delegate(DataRow dataRow_0, DataRow dataRow_1)
                {
                    return new
                    {
                        dt1row = dataRow_0,
                        dt2row = dataRow_1
                    };
                }))
                {
                    type2.dt1row["XIANG"] = type2.dt2row["CNAME"];
                }
                foreach (var type3 in Enumerable.Join(DataTableExtensions.AsEnumerable(source), DataTableExtensions.AsEnumerable(dataTabeBySelRows), delegate(DataRow dataRow_0)
                {
                    return DataRowExtensions.Field<string>(dataRow_0, "CUN");
                }, delegate(DataRow dataRow_0)
                {
                    return DataRowExtensions.Field<string>(dataRow_0, "CCODE");
                }, delegate(DataRow dataRow_0, DataRow dataRow_1)
                {
                    return new
                    {
                        dt1row = dataRow_0,
                        dt2row = dataRow_1
                    };
                }))
                {
                    type3.dt1row["CUN"] = type3.dt2row["CNAME"];
                }
                dataTabeBySelRows = this.GetDataTabeBySelRows(table7, "CINDEX = '258'");
                foreach (var type4 in Enumerable.Join(DataTableExtensions.AsEnumerable(source), DataTableExtensions.AsEnumerable(dataTabeBySelRows), delegate(DataRow dataRow_0)
                {
                    return DataRowExtensions.Field<string>(dataRow_0, "LDLX");
                }, delegate(DataRow dataRow_0)
                {
                    return DataRowExtensions.Field<string>(dataRow_0, "CCODE");
                }, delegate(DataRow dataRow_0, DataRow dataRow_1)
                {
                    return new
                    {
                        dt1row = dataRow_0,
                        dt2row = dataRow_1
                    };
                }))
                {
                    type4.dt1row["LDLX"] = type4.dt2row["CNAME"];
                }
                dataTabeBySelRows = this.GetDataTabeBySelRows(table7, "CINDEX = '211'");
                foreach (var type5 in Enumerable.Join(DataTableExtensions.AsEnumerable(source), DataTableExtensions.AsEnumerable(dataTabeBySelRows), delegate(DataRow dataRow_0)
                {
                    return DataRowExtensions.Field<string>(dataRow_0, "TDZL");
                }, delegate(DataRow dataRow_0)
                {
                    return DataRowExtensions.Field<string>(dataRow_0, "CCODE");
                }, delegate(DataRow dataRow_0, DataRow dataRow_1)
                {
                    return new
                    {
                        dt1row = dataRow_0,
                        dt2row = dataRow_1
                    };
                }))
                {
                    type5.dt1row["TDZL"] = type5.dt2row["CNAME"];
                }
                dataTabeBySelRows = this.GetDataTabeBySelRows(table7, "CINDEX = '212'");
                foreach (var type6 in Enumerable.Join(DataTableExtensions.AsEnumerable(source), DataTableExtensions.AsEnumerable(dataTabeBySelRows), delegate(DataRow dataRow_0)
                {
                    return DataRowExtensions.Field<string>(dataRow_0, "LINZHONG");
                }, delegate(DataRow dataRow_0)
                {
                    return DataRowExtensions.Field<string>(dataRow_0, "CCODE");
                }, delegate(DataRow dataRow_0, DataRow dataRow_1)
                {
                    return new
                    {
                        dt1row = dataRow_0,
                        dt2row = dataRow_1
                    };
                }))
                {
                    type6.dt1row["LINZHONG"] = type6.dt2row["CNAME"];
                }
                dataTabeBySelRows = this.GetDataTabeBySelRows(table7, "CINDEX = '219'");
                foreach (var type7 in Enumerable.Join(DataTableExtensions.AsEnumerable(source), DataTableExtensions.AsEnumerable(dataTabeBySelRows), delegate(DataRow dataRow_0)
                {
                    return DataRowExtensions.Field<string>(dataRow_0, "SHUZHONG");
                }, delegate(DataRow dataRow_0)
                {
                    return DataRowExtensions.Field<string>(dataRow_0, "CCODE");
                }, delegate(DataRow dataRow_0, DataRow dataRow_1)
                {
                    return new
                    {
                        dt1row = dataRow_0,
                        dt2row = dataRow_1
                    };
                }))
                {
                    type7.dt1row["SHUZHONG"] = type7.dt2row["CNAME"];
                }
            }
            return source;
        }

        private System.Data.DataTable LDGNFQSimpleTJTable(string tjdw, System.Data.DataTable mytjdt)
        {
            System.Data.DataTable table = new System.Data.DataTable("tjtable");
            table.Columns.Add("TJDW", typeof(string));
            table.Columns.Add("MJHJ", typeof(double));
            table.Columns.Add("XJHJ", typeof(double));
            return table;
        }

        public System.Data.DataTable LDGNFQTJTable(string ydzl)
        {
            System.Data.DataTable resultTable = new System.Data.DataTable("tjtable");
            resultTable.Columns.Add("TJDW", typeof(string));
            resultTable.Columns.Add("MJHJ", typeof(double));
            resultTable.Columns.Add("XJHJ", typeof(double));
            try
            {
                System.Data.DataTable table = new System.Data.DataTable();
                string cmdtxt = "SELECT LTRIM(RTRIM(SHI)) AS SHI,LTRIM(RTRIM(XIAN)) AS XIAN,LTRIM(RTRIM(XIANG)) AS XIANG,LTRIM(RTRIM(CUN)) AS CUN,LTRIM(RTRIM(LYFQ)) AS LYFQ,MIAN_JI,SLXJ FROM " + TABLE_ZZYTableName + " WHERE (RTRIM(LTRIM(XMMC))='" + TABLE_ZZYXMMC + "') AND LTRIM(RTRIM(YDZL))='" + ydzl + "'";
                table = this.GetTable(cmdtxt, TABLE_ZZYTableName);
                if (table == null)
                {
                    MessageBox.Show(TABLE_ZZYTableName + " 林地功能分区数据读取出错！", "信息", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return null;
                }
                if (table.Rows.Count == 0)
                {
                    return resultTable;
                }
                List<string> list5 = new List<string>();
                List<string> list2 = new List<string>();
                List<string> list = new List<string>();
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    string item = table.Rows[i]["SHI"].ToString().Trim();
                    if (!list5.Contains(item))
                    {
                        list5.Add(item);
                    }
                    string str10 = table.Rows[i]["lyfq"].ToString().Trim();
                    if (!list.Contains(str10))
                    {
                        list.Add(str10);
                    }
                }
                list5.Sort();
                list.Sort();
                for (int j = 0; j < list.Count; j++)
                {
                    DataColumn column = new DataColumn("C_" + list[j].ToString() + "_mj", typeof(double));
                    resultTable.Columns.Add(column);
                    column = new DataColumn("C_" + list[j].ToString() + "_xj", typeof(double));
                    resultTable.Columns.Add(column);
                }
                string expression = "SUM(MIAN_JI)";
                string str9 = "SUM(SLXJ)";
                System.Data.DataTable table7 = resultTable.Clone();
                System.Data.DataTable table12 = resultTable.Clone();
                for (int k = 0; k < list5.Count; k++)
                {
                    table7.Clear();
                    string str3 = list5[k];
                    list2.Clear();
                    System.Data.DataTable dataTabeBySelRows = this.GetDataTabeBySelRows(table, "SHI='" + str3 + "'");
                    for (int n = 0; n < dataTabeBySelRows.Rows.Count; n++)
                    {
                        string str11 = dataTabeBySelRows.Rows[n]["XIAN"].ToString().Trim();
                        if (!list2.Contains(str11))
                        {
                            list2.Add(str11);
                        }
                    }
                    list2.Sort();
                    System.Data.DataTable table9 = resultTable.Clone();
                    System.Data.DataTable table6 = table.Clone();
                    for (int num3 = 0; num3 < list2.Count; num3++)
                    {
                        table6.Clear();
                        string str2 = list2[num3].ToString();
                        foreach (DataRow row6 in table.Select("XIAN='" + str2 + "'"))
                        {
                            table6.Rows.Add(row6.ItemArray);
                        }
                        List<string> list4 = new List<string>();
                        for (int num8 = 0; num8 < table6.Rows.Count; num8++)
                        {
                            string str5 = table6.Rows[num8]["XIANG"].ToString().Trim();
                            if (!list4.Contains(str5))
                            {
                                list4.Add(str5);
                            }
                        }
                        list4.Sort();
                        System.Data.DataTable table8 = table.Clone();
                        System.Data.DataTable table5 = resultTable.Clone();
                        System.Data.DataTable table4 = resultTable.Clone();
                        System.Data.DataTable table13 = resultTable.Clone();
                        List<string> list3 = new List<string>();
                        System.Data.DataTable table14 = table.Clone();
                        System.Data.DataTable table11 = resultTable.Clone();
                        for (int num11 = 0; num11 < list4.Count; num11++)
                        {
                            string str7 = list4[num11].ToString();
                            table4.Clear();
                            DataRow[] rowArray3 = table6.Select("XIANG='" + str7 + "'");
                            table8.Clear();
                            foreach (DataRow row11 in rowArray3)
                            {
                                table8.Rows.Add(row11.ItemArray);
                            }
                            for (int num6 = 0; num6 < table8.Rows.Count; num6++)
                            {
                                string str4 = table8.Rows[num6]["CUN"].ToString().Trim();
                                if (!list3.Contains(str4))
                                {
                                    list3.Add(str4);
                                }
                            }
                            list3.Sort();
                            for (int num7 = 0; num7 < list3.Count; num7++)
                            {
                                table5.Clear();
                                string str12 = list3[num7].ToString();
                                DataRow[] rowArray4 = table8.Select("CUN='" + str12 + "'");
                                table14.Clear();
                                foreach (DataRow row8 in rowArray4)
                                {
                                    table14.Rows.Add(row8.ItemArray);
                                }
                                double num15 = 0.0;
                                double num14 = 0.0;
                                DataRow row4 = table5.NewRow();
                                row4["tjdw"] = str12.Trim();
                                for (int num16 = 0; num16 < list.Count; num16++)
                                {
                                    string str6 = list[num16];
                                    string filterExpression = "lyfq='" + str6 + "'";
                                    if (table14.Select(filterExpression).Length > 0)
                                    {
                                        row4["C_" + str6 + "_mj"] = Convert.ToDouble(table14.Compute(expression, filterExpression));
                                        row4["C_" + str6 + "_xj"] = Convert.ToDouble(table14.Compute(str9, filterExpression));
                                    }
                                    else
                                    {
                                        row4["C_" + str6 + "_mj"] = 0;
                                        row4["C_" + str6 + "_xj"] = 0;
                                    }
                                    num15 += Convert.ToDouble(row4["C_" + str6 + "_mj"]);
                                    num14 += Convert.ToDouble(row4["C_" + str6 + "_xj"]);
                                }
                                row4["MJHJ"] = num15;
                                row4["XJHJ"] = num14;
                                if ((num15 > 0.0) || (num14 > 0.0))
                                {
                                    table5.Rows.Add(row4);
                                }
                                foreach (DataRow row9 in table5.Rows)
                                {
                                    table4.Rows.Add(row9.ItemArray);
                                }
                            }
                            if (table4.Rows.Count > 0)
                            {
                                DataRow row = table4.NewRow();
                                row[0] = str7.Trim();
                                for (int num2 = 1; num2 < table5.Columns.Count; num2++)
                                {
                                    row[num2] = Convert.ToDouble(table4.Compute("SUM(" + table5.Columns[num2] + ")", null));
                                }
                                table4.Rows.InsertAt(row, 0);
                                table13.Rows.Add(row.ItemArray);
                            }
                            foreach (DataRow row7 in table4.Rows)
                            {
                                table11.Rows.Add(row7.ItemArray);
                            }
                        }
                        DataRow row3 = table11.NewRow();
                        row3[0] = str2.Trim();
                        for (int num10 = 1; num10 < resultTable.Columns.Count; num10++)
                        {
                            row3[num10] = Convert.ToDouble(table13.Compute("SUM(" + table13.Columns[num10] + ")", null));
                        }
                        table11.Rows.InsertAt(row3, 0);
                        table9.Rows.Add(row3.ItemArray);
                        foreach (DataRow row10 in table11.Rows)
                        {
                            table7.Rows.Add(row10.ItemArray);
                        }
                    }
                    DataRow row2 = table7.NewRow();
                    row2[0] = str3;
                    for (int num5 = 1; num5 < resultTable.Columns.Count; num5++)
                    {
                        row2[num5] = Convert.ToDouble(table9.Compute("SUM(" + table9.Columns[num5] + ")", null));
                    }
                    table7.Rows.InsertAt(row2, 0);
                    table12.Rows.Add(row2.ItemArray);
                    foreach (DataRow row5 in table7.Rows)
                    {
                        resultTable.Rows.Add(row5.ItemArray);
                    }
                }
                table7.Clear();
                DataRow row12 = resultTable.NewRow();
                row12[0] = "项目区";
                for (int m = 1; m < resultTable.Columns.Count; m++)
                {
                    row12[m] = Convert.ToDouble(table12.Compute("SUM(" + table12.Columns[m] + ")", null));
                }
                resultTable.Rows.InsertAt(row12, 0);
                this.ConvertGNFQTableColName(resultTable);
                resultTable = this.UpdateDWTableByJoin(resultTable);
            }
            catch (Exception exception)
            {
                MessageBox.Show("林地功能分区统计出错，错误:" + exception.ToString() + "\n\r请与程序提供者联系！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            return resultTable;
        }

        private System.Data.DataTable LDLXTable()
        {
            System.Data.DataTable table = new System.Data.DataTable("DMTable");
            DataColumn column = new DataColumn("DM", typeof(string));
            table.Columns.Add(column);
            column = new DataColumn("MC", typeof(string));
            table.Columns.Add(column);
            DataRow row = table.NewRow();
            row[0] = "1";
            row[1] = "防护林林地";
            table.Rows.Add(row);
            row = table.NewRow();
            row[0] = "2";
            row[1] = "特种用途林林地";
            table.Rows.Add(row);
            row = table.NewRow();
            row[0] = "3";
            row[1] = "用材林林地";
            table.Rows.Add(row);
            row = table.NewRow();
            row[0] = "4";
            row[1] = "经济林林地";
            table.Rows.Add(row);
            row = table.NewRow();
            row[0] = "5";
            row[1] = "薪炭林地";
            table.Rows.Add(row);
            row = table.NewRow();
            row[0] = "6";
            row[1] = "苗圃地";
            table.Rows.Add(row);
            row = table.NewRow();
            row[0] = "7";
            row[1] = "其它林地";
            table.Rows.Add(row);
            return table;
        }

        public string pGetReaderStr(string cmdtxt)
        {
            string str;
            this.M_Com = new SqlCommand(cmdtxt, this.GetCon());
            SqlDataReader reader = null;
            try
            {
                reader = this.M_Com.ExecuteReader();
                reader.Read();
                str = reader[0].ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("获取数据出错！", "错误", MessageBoxButtons.OKCancel, MessageBoxIcon.Hand);
                str = "0";
            }
            finally
            {
                reader.Close();
                if (this.GetCon().State == ConnectionState.Open)
                {
                    this.GetCon().Close();
                    this.GetCon().Dispose();
                }
            }
            return str;
        }

        private System.Data.DataTable QYTable()
        {
            System.Data.DataTable table = new System.Data.DataTable("DMTable");
            DataColumn column = new DataColumn("CCODE", typeof(string));
            table.Columns.Add(column);
            column = new DataColumn("CSNAME", typeof(string));
            table.Columns.Add(column);
            DataRow row = table.NewRow();
            row[0] = "10";
            row[1] = "天然";
            table.Rows.Add(row);
            row = table.NewRow();
            row[0] = "20";
            row[1] = "人工";
            table.Rows.Add(row);
            return table;
        }

        public void SaveSXFYXBTABLE(string xmmc, DataSet tjds, string xlsModelPath, string xlsTargetPath)
        {
            if (!File.Exists(xlsModelPath))
            {
                MessageBox.Show("统计模板文件 " + xlsModelPath + " 不存在，请检查!", "错误", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else
            {
                System.Data.DataTable table = new System.Data.DataTable("xlsxh");
                table.Columns.Add("sheetname", typeof(string));
                table.Columns.Add("sheetindex", typeof(int));
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
                        Worksheet worksheet2 = null;
                        for (int i = 1; i < (application.Sheets.Count + 1); i++)
                        {
                            Worksheet worksheet = application.Sheets[i] as Worksheet;
                            DataRow row = table.NewRow();
                            row[0] = worksheet.Name;
                            row[1] = i;
                            table.Rows.Add(row);
                        }
                        for (int j = 0; j < tjds.Tables.Count; j++)
                        {
                            System.Data.DataTable table2 = tjds.Tables[j];
                            string tableName = table2.TableName;
                            int count = table2.Rows.Count;
                            int num4 = table2.Columns.Count;
                            object[,] objArray = new object[count, num4];
                            for (int k = 0; k < count; k++)
                            {
                                for (int m = 0; m < num4; m++)
                                {
                                    objArray[k, m] = table2.Rows[k][m];
                                }
                            }
                            if ((objArray != null) && (objArray.GetLength(0) > 0))
                            {
                                worksheet2 = application.Sheets[1] as Worksheet;
                                int num6 = worksheet2.UsedRange.Rows.Count;
                                int num8 = (count + 4) - 1;
                                worksheet2.get_Range(worksheet2.Cells[4, 1], worksheet2.Cells[num6 + 3, num4]).EntireRow.Delete(updateLinks);
                                worksheet2.get_Range(worksheet2.Cells[4, 1], worksheet2.Cells[num8, num4]).Value2 = objArray;
                                worksheet2.get_Range(worksheet2.Cells[4, 1], worksheet2.Cells[num8, num4]).Font.Name = "Arial Narrow";
                                worksheet2.get_Range(worksheet2.Cells[4, 1], worksheet2.Cells[num8, num4]).Font.Size = 10;
                                worksheet2.get_Range(worksheet2.Cells[4, 1], worksheet2.Cells[num8, 9]).HorizontalAlignment = XlHAlign.xlHAlignCenter;
                                worksheet2.get_Range(worksheet2.Cells[4, 1], worksheet2.Cells[num8, 9]).VerticalAlignment = XlVAlign.xlVAlignCenter;
                                worksheet2.get_Range(worksheet2.Cells[4, 1], worksheet2.Cells[num8, num4]).Borders.LineStyle = 1;
                                worksheet2.Select(updateLinks);
                                worksheet2.get_Range("A1", "A1").Select();
                            }
                        }
                        application.ActiveWindow.DisplayZeros = false;
                        worksheet2 = null;
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

        public void SaveSYLDLXTABLE(DataSet tjds, string xlsModelPath, string xlsTargetPath)
        {
            if (!File.Exists(xlsModelPath))
            {
                MessageBox.Show("统计模板文件 " + xlsModelPath + " 不存在，请检查!", "错误", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else
            {
                System.Data.DataTable table = new System.Data.DataTable("xlsxh");
                table.Columns.Add("sheetname", typeof(string));
                table.Columns.Add("sheetindex", typeof(int));
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
                        Worksheet worksheet2 = null;
                        for (int i = 1; i < (application.Sheets.Count + 1); i++)
                        {
                            Worksheet worksheet = application.Sheets[i] as Worksheet;
                            DataRow row = table.NewRow();
                            row[0] = worksheet.Name;
                            row[1] = i;
                            table.Rows.Add(row);
                        }
                        for (int j = 0; j < tjds.Tables.Count; j++)
                        {
                            System.Data.DataTable table2 = tjds.Tables[j];
                            string tableName = table2.TableName;
                            int count = table2.Rows.Count;
                            int num4 = table2.Columns.Count;
                            object[,] objArray = new object[count, num4];
                            for (int k = 0; k < count; k++)
                            {
                                for (int m = 0; m < num4; m++)
                                {
                                    objArray[k, m] = table2.Rows[k][m];
                                }
                            }
                            if ((objArray != null) && (objArray.GetLength(0) > 0))
                            {
                                worksheet2 = application.Sheets[1] as Worksheet;
                                int num6 = worksheet2.UsedRange.Rows.Count;
                                int num8 = (count + 6) - 1;
                                worksheet2.get_Range(worksheet2.Cells[6, 1], worksheet2.Cells[num6 + 5, num4]).EntireRow.Delete(updateLinks);
                                worksheet2.get_Range(worksheet2.Cells[6, 1], worksheet2.Cells[num8, num4]).Value2 = objArray;
                                worksheet2.get_Range(worksheet2.Cells[6, 1], worksheet2.Cells[num8, num4]).Font.Name = "Arial Narrow";
                                worksheet2.get_Range(worksheet2.Cells[6, 1], worksheet2.Cells[num8, num4]).Font.Size = 10;
                                worksheet2.get_Range(worksheet2.Cells[6, 1], worksheet2.Cells[num8, num4]).Borders.LineStyle = 1;
                                worksheet2.Select(updateLinks);
                                worksheet2.get_Range("A1", "A1").Select();
                            }
                        }
                        application.ActiveWindow.DisplayZeros = false;
                        worksheet2 = null;
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

        /// <summary>
        /// 将按规定查询的数据写入响应的Excel表格中，并保存
        /// </summary>
        /// <param name="xmmc"></param>
        /// <param name="tjds"></param>
        /// <param name="xlsModelPath"></param>
        /// <param name="xlsTargetPath"></param>
        public void SaveTJB(string xmmc, DataSet tjds, string xlsModelPath, string xlsTargetPath)
        {
            if (!File.Exists(xlsModelPath))
            {
                MessageBox.Show("统计模板文件 " + xlsModelPath + " 不存在，请检查!", "错误", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else
            {
                System.Data.DataTable table = new System.Data.DataTable("xlsxh");
                table.Columns.Add("sheetname", typeof(string));
                table.Columns.Add("sheetindex", typeof(int));
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
                        for (int i = 1; i < (application.Sheets.Count + 1); i++)
                        {
                            Worksheet worksheet2 = application.Sheets[i] as Worksheet;
                            DataRow row = table.NewRow();
                            row[0] = worksheet2.Name;
                            row[1] = i;
                            table.Rows.Add(row);
                        }
                        for (int j = 0; j < tjds.Tables.Count; j++)
                        {
                            System.Data.DataTable table2 = tjds.Tables[j];
                            string tableName = table2.TableName;
                            int count = table2.Rows.Count;
                            int num6 = table2.Columns.Count;
                            object[,] objArray = new object[count, num6];
                            for (int k = 0; k < count; k++)
                            {
                                for (int m = 0; m < num6; m++)
                                {
                                    objArray[k, m] = table2.Rows[k][m];
                                }
                            }
                            string[] strArray4 = new string[] { "合计", "防护林", "特种用途林", "用材林", "经济林", "薪炭林", "苗圃地", "其它林地" };
                            if ((objArray != null) && (objArray.GetLength(0) > 0))
                            {
                                if (tableName.Trim().ToUpper() == "B1")
                                {
                                    DataRow[] rowArray = table.Select("sheetname='表1'");
                                    if (rowArray.Length > 0)
                                    {
                                        int num = Convert.ToInt32(rowArray[0][1].ToString());
                                        worksheet = application.Sheets[num] as Worksheet;
                                    }
                                    else
                                    {
                                        object after = application.Sheets[application.Sheets.Count] as Worksheet;
                                        application.Sheets.Add(updateLinks, after, 1, updateLinks);
                                        worksheet = application.Sheets[application.Sheets.Count] as Worksheet;
                                        worksheet.Name = "表1";
                                        worksheet.get_Range("A1", "A1").Value2 = "项目占用征用林地按林地类型面积蓄积统计表";
                                        worksheet.get_Range("C2", "C2").Value2 = "单位：公顷、立方米";
                                    }
                                    int num11 = worksheet.UsedRange.Rows.Count;
                                    int num12 = (count + 5) - 1;
                                    worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num11 + 4, num6]).EntireRow.Delete(updateLinks);
                                    worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num12, num6]).Value2 = objArray;
                                    worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num12, num6]).Font.Name = "Arial Narrow";
                                    worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num12, num6]).Font.Size = 10;
                                    worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num12, 1]).HorizontalAlignment = XlHAlign.xlHAlignCenter;
                                    worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num12, 1]).VerticalAlignment = XlVAlign.xlVAlignCenter;
                                    worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num12, num6]).Borders.LineStyle = 1;
                                    worksheet.Select(updateLinks);
                                    worksheet.get_Range("A1", "A1").Select();
                                }
                                else if (tableName.Trim().ToUpper() == "B2")
                                {
                                    DataRow[] rowArray10 = table.Select("sheetname='表2'");
                                    if (rowArray10.Length > 0)
                                    {
                                        int num37 = Convert.ToInt32(rowArray10[0][1].ToString());
                                        worksheet = application.Sheets[num37] as Worksheet;
                                    }
                                    else
                                    {
                                        object obj12 = application.Sheets[application.Sheets.Count] as Worksheet;
                                        application.Sheets.Add(updateLinks, obj12, 1, updateLinks);
                                        worksheet = application.Sheets[application.Sheets.Count] as Worksheet;
                                        worksheet.Name = "表2";
                                        worksheet.get_Range("A1", "A1").Value2 = "项目占用征用林地按权属各地类面积统计表";
                                        worksheet.get_Range("C2", "C2").Value2 = "单位：公顷";
                                    }
                                    int num17 = worksheet.UsedRange.Rows.Count;
                                    int num18 = (count + 6) - 1;
                                    int num19 = (num17 + 6) - 1;
                                    worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num19, num6]).EntireRow.Delete(updateLinks);
                                    worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num18, num6]).Value2 = objArray;
                                    worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num18, num6]).Font.Name = "Arial Narrow";
                                    worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num18, num6]).Font.Size = 10;
                                    worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num18, 1]).HorizontalAlignment = XlHAlign.xlHAlignCenter;
                                    worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num18, 1]).VerticalAlignment = XlVAlign.xlVAlignCenter;
                                    worksheet.get_Range(worksheet.Cells[6, 1], worksheet.Cells[num18, num6]).Borders.LineStyle = 1;
                                    worksheet.Select(updateLinks);
                                    worksheet.get_Range("A1", "A1").Select();
                                }
                                else if (tableName.Trim().ToUpper() == "B3")
                                {
                                    DataRow[] rowArray3 = table.Select("sheetname='表3'");
                                    if (rowArray3.Length > 0)
                                    {
                                        int num13 = Convert.ToInt32(rowArray3[0][1].ToString());
                                        worksheet = application.Sheets[num13] as Worksheet;
                                    }
                                    else
                                    {
                                        object obj16 = application.Sheets[application.Sheets.Count] as Worksheet;
                                        application.Sheets.Add(updateLinks, obj16, 1, updateLinks);
                                        worksheet = application.Sheets[application.Sheets.Count] as Worksheet;
                                        worksheet.Name = "表3";
                                        worksheet.get_Range("A1", "A1").Value2 = "项目占用征用林地按土地权属、起源、林种各龄组面积蓄积统计表";
                                        worksheet.get_Range("C2", "C2").Value2 = "单位：公顷、立方米";
                                    }
                                    int num21 = worksheet.UsedRange.Rows.Count;
                                    int num22 = (count + 5) - 1;
                                    int num23 = (num21 + 5) - 1;
                                    worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num23, num6]).EntireRow.Delete(updateLinks);
                                    worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num22, num6]).Value2 = objArray;
                                    worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num22, num6]).Font.Name = "Arial Narrow";
                                    worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num22, num6]).Font.Size = 10;
                                    worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num22, 1]).HorizontalAlignment = XlHAlign.xlHAlignCenter;
                                    worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num22, 1]).VerticalAlignment = XlVAlign.xlVAlignCenter;
                                    worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num22, num6]).Borders.LineStyle = 1;
                                    worksheet.Select(updateLinks);
                                    worksheet.get_Range("A1", "A1").Select();
                                }
                                else if (tableName.Trim().ToUpper() == "B3_1")
                                {
                                    DataRow[] rowArray8 = table.Select("sheetname='表3-lq'");
                                    if (rowArray8.Length > 0)
                                    {
                                        int num30 = Convert.ToInt32(rowArray8[0][1].ToString());
                                        worksheet = application.Sheets[num30] as Worksheet;
                                    }
                                    else
                                    {
                                        object obj5 = application.Sheets[application.Sheets.Count] as Worksheet;
                                        application.Sheets.Add(updateLinks, obj5, 1, updateLinks);
                                        worksheet = application.Sheets[application.Sheets.Count] as Worksheet;
                                        worksheet.Name = "表3-lq";
                                        worksheet.get_Range("A1", "A1").Value2 = "项目占用征用林地按土地权属、起源、优势树种（组）各龄组面积蓄积统计表";
                                        worksheet.get_Range("C2", "C2").Value2 = "单位：公顷、立方米";
                                    }
                                    int num71 = worksheet.UsedRange.Rows.Count;
                                    int num72 = (count + 5) - 1;
                                    int num73 = (num71 + 5) - 1;
                                    worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num73, num6]).EntireRow.Delete(updateLinks);
                                    worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num72, num6]).Value2 = objArray;
                                    worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num72, num6]).Font.Name = "Arial Narrow";
                                    worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num72, num6]).Font.Size = 10;
                                    worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num72, 1]).HorizontalAlignment = XlHAlign.xlHAlignCenter;
                                    worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num72, 1]).VerticalAlignment = XlVAlign.xlVAlignCenter;
                                    worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num72, num6]).Borders.LineStyle = 1;
                                    worksheet.Select(updateLinks);
                                    worksheet.get_Range("A1", "A1").Select();
                                }
                                else if (tableName.Trim().ToUpper() == "B4")
                                {
                                    DataRow[] rowArray6 = table.Select("sheetname='表4'");
                                    if (rowArray6.Length > 0)
                                    {
                                        int num76 = Convert.ToInt32(rowArray6[0][1].ToString());
                                        worksheet = application.Sheets[num76] as Worksheet;
                                    }
                                    else
                                    {
                                        object obj7 = application.Sheets[application.Sheets.Count] as Worksheet;
                                        application.Sheets.Add(updateLinks, obj7, 1, updateLinks);
                                        worksheet = application.Sheets[application.Sheets.Count] as Worksheet;
                                        worksheet.Name = "表4";
                                        worksheet.get_Range("A1", "A1").Value2 = "项目占用征用林地按土地权属、起源、优势树种（组）各龄组面积蓄积统计表";
                                        worksheet.get_Range("C2", "C2").Value2 = "单位：公顷、立方米";
                                    }
                                    int num57 = worksheet.UsedRange.Rows.Count;
                                    int num58 = (count + 5) - 1;
                                    int num59 = (num57 + 5) - 1;
                                    worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num59, num6]).EntireRow.Delete(updateLinks);
                                    worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num58, num6]).Value2 = objArray;
                                    worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num58, num6]).Font.Name = "Arial Narrow";
                                    worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num58, num6]).Font.Size = 10;
                                    worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num58, 1]).HorizontalAlignment = XlHAlign.xlHAlignCenter;
                                    worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num58, 1]).VerticalAlignment = XlVAlign.xlVAlignCenter;
                                    worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num58, num6]).Borders.LineStyle = 1;
                                    worksheet.Select(updateLinks);
                                    worksheet.get_Range("A1", "A1").Select();
                                }
                                else if (tableName.Trim().ToUpper() == "B4_1")
                                {
                                    DataRow[] rowArray9 = table.Select("sheetname='表4-lq'");
                                    if (rowArray9.Length > 0)
                                    {
                                        int num26 = Convert.ToInt32(rowArray9[0][1].ToString());
                                        worksheet = application.Sheets[num26] as Worksheet;
                                    }
                                    else
                                    {
                                        object obj4 = application.Sheets[application.Sheets.Count] as Worksheet;
                                        application.Sheets.Add(updateLinks, obj4, 1, updateLinks);
                                        worksheet = application.Sheets[application.Sheets.Count] as Worksheet;
                                        worksheet.Name = "表4-lq";
                                        worksheet.get_Range("A1", "A1").Value2 = "项目占用征用林地按林木权属、起源、优势树种（组）各龄组面积蓄积统计表";
                                        worksheet.get_Range("C2", "C2").Value2 = "单位：公顷、立方米";
                                    }
                                    int num14 = worksheet.UsedRange.Rows.Count;
                                    int num15 = (count + 5) - 1;
                                    int num16 = (num14 + 5) - 1;
                                    worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num16, num6]).EntireRow.Delete(updateLinks);
                                    worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num15, num6]).Value2 = objArray;
                                    worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num15, num6]).Font.Name = "Arial Narrow";
                                    worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num15, num6]).Font.Size = 10;
                                    worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num15, 1]).HorizontalAlignment = XlHAlign.xlHAlignCenter;
                                    worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num15, 1]).VerticalAlignment = XlVAlign.xlVAlignCenter;
                                    worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num15, num6]).Borders.LineStyle = 1;
                                    worksheet.Select(updateLinks);
                                    worksheet.get_Range("A1", "A1").Select();
                                }
                                else if (tableName.Trim().ToUpper() == "B5")
                                {
                                    DataRow[] rowArray13 = table.Select("sheetname='表5'");
                                    if (rowArray13.Length > 0)
                                    {
                                        int num42 = Convert.ToInt32(rowArray13[0][1].ToString());
                                        worksheet = application.Sheets[num42] as Worksheet;
                                    }
                                    else
                                    {
                                        object obj3 = application.Sheets[application.Sheets.Count] as Worksheet;
                                        application.Sheets.Add(updateLinks, obj3, 1, updateLinks);
                                        worksheet = application.Sheets[application.Sheets.Count] as Worksheet;
                                        worksheet.Name = "表5";
                                        worksheet.get_Range("A1", "A1").Value2 = "项目占用征用林地经济林按土地权属、产期面积统计表";
                                        worksheet.get_Range("C2", "C2").Value2 = "单位：公顷";
                                    }
                                    int num47 = worksheet.UsedRange.Rows.Count;
                                    int num48 = (count + 4) - 1;
                                    int num49 = (num47 + 4) - 1;
                                    worksheet.get_Range(worksheet.Cells[4, 1], worksheet.Cells[num49, num6]).EntireRow.Delete(updateLinks);
                                    worksheet.get_Range(worksheet.Cells[4, 1], worksheet.Cells[num48, num6]).Value2 = objArray;
                                    worksheet.get_Range(worksheet.Cells[4, 1], worksheet.Cells[num48, num6]).Font.Name = "Arial Narrow";
                                    worksheet.get_Range(worksheet.Cells[4, 1], worksheet.Cells[num48, num6]).Font.Size = 10;
                                    worksheet.get_Range(worksheet.Cells[4, 1], worksheet.Cells[num48, 1]).HorizontalAlignment = XlHAlign.xlHAlignCenter;
                                    worksheet.get_Range(worksheet.Cells[4, 1], worksheet.Cells[num48, 1]).VerticalAlignment = XlVAlign.xlVAlignCenter;
                                    worksheet.get_Range(worksheet.Cells[4, 1], worksheet.Cells[num48, num6]).Borders.LineStyle = 1;
                                    worksheet.Select(updateLinks);
                                    worksheet.get_Range("A1", "A1").Select();
                                }
                                else if (tableName.Trim().ToUpper() == "B5_1")
                                {
                                    DataRow[] rowArray12 = table.Select("sheetname='表5-lq'");
                                    if (rowArray12.Length > 0)
                                    {
                                        int num43 = Convert.ToInt32(rowArray12[0][1].ToString());
                                        worksheet = application.Sheets[num43] as Worksheet;
                                    }
                                    else
                                    {
                                        object obj6 = application.Sheets[application.Sheets.Count] as Worksheet;
                                        application.Sheets.Add(updateLinks, obj6, 1, updateLinks);
                                        worksheet = application.Sheets[application.Sheets.Count] as Worksheet;
                                        worksheet.Name = "表5-lq";
                                        worksheet.get_Range("A1", "A1").Value2 = "项目占用征用林地经济林按林木权属、产期面积统计表";
                                        worksheet.get_Range("C2", "C2").Value2 = "单位：公顷";
                                    }
                                    int num44 = worksheet.UsedRange.Rows.Count;
                                    int num45 = (count + 4) - 1;
                                    int num46 = (num44 + 4) - 1;
                                    worksheet.get_Range(worksheet.Cells[4, 1], worksheet.Cells[num46, num6]).EntireRow.Delete(updateLinks);
                                    worksheet.get_Range(worksheet.Cells[4, 1], worksheet.Cells[num45, num6]).Value2 = objArray;
                                    worksheet.get_Range(worksheet.Cells[4, 1], worksheet.Cells[num45, num6]).Font.Name = "Arial Narrow";
                                    worksheet.get_Range(worksheet.Cells[4, 1], worksheet.Cells[num45, num6]).Font.Size = 10;
                                    worksheet.get_Range(worksheet.Cells[4, 1], worksheet.Cells[num45, 1]).HorizontalAlignment = XlHAlign.xlHAlignCenter;
                                    worksheet.get_Range(worksheet.Cells[4, 1], worksheet.Cells[num45, 1]).VerticalAlignment = XlVAlign.xlVAlignCenter;
                                    worksheet.get_Range(worksheet.Cells[4, 1], worksheet.Cells[num45, num6]).Borders.LineStyle = 1;
                                    worksheet.Select(updateLinks);
                                    worksheet.get_Range("A1", "A1").Select();
                                }
                                else if (tableName.Trim().ToUpper() == "B6")
                                {
                                    DataRow[] rowArray16 = table.Select("sheetname='表6'");
                                    if (rowArray16.Length > 0)
                                    {
                                        int num56 = Convert.ToInt32(rowArray16[0][1].ToString());
                                        worksheet = application.Sheets[num56] as Worksheet;
                                    }
                                    else
                                    {
                                        object obj15 = application.Sheets[application.Sheets.Count] as Worksheet;
                                        application.Sheets.Add(updateLinks, obj15, 1, updateLinks);
                                        worksheet = application.Sheets[application.Sheets.Count] as Worksheet;
                                        worksheet.Name = "表6";
                                        worksheet.get_Range("A1", "A1").Value2 = "项目占用征用林地植被恢复费统计计算结果表";
                                        worksheet.get_Range("C2", "C2").Value2 = "单位：平方米、立方米、元/平方米、元";
                                    }
                                    int num54 = worksheet.UsedRange.Rows.Count;
                                    int num35 = 5;
                                    int num36 = (count + 5) - 1;
                                    int num55 = (num54 + 5) - 1;
                                    worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num55, num6]).EntireRow.Delete(updateLinks);
                                    worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num36, num6]).Value2 = objArray;
                                    System.Data.DataTable table3 = table2.DefaultView.ToTable(true, new string[] { table2.Columns[0].ColumnName });
                                    int num38 = 5;
                                    for (int n = 0; n < table3.Rows.Count; n++)
                                    {
                                        string str4 = table3.Rows[n][0].ToString();
                                        string str5 = table2.Columns[0].ColumnName + "='" + str4 + "'";
                                        System.Data.DataTable dataTabeBySelRows = this.GetDataTabeBySelRows(table2, str5);
                                        dataTabeBySelRows.DefaultView.ToTable(true, new string[] { table2.Columns[1].ColumnName });
                                        DataRow[] rowArray14 = table2.Select(table2.Columns[0].ColumnName + "='" + str4 + "'");
                                        int num40 = 0;
                                        foreach (string str2 in strArray4)
                                        {
                                            DataRow[] rowArray11 = dataTabeBySelRows.Select(table2.Columns[1].ColumnName + " LIKE '" + str2 + "%'");
                                            if (str2 == "合计")
                                            {
                                                int num39 = (num38 + rowArray11.Length) - 1;
                                                worksheet.get_Range(worksheet.Cells[num38, 2], worksheet.Cells[num39, 3]).MergeCells = true;
                                                num40 = num38 + rowArray11.Length;
                                            }
                                            else
                                            {
                                                int num41 = (num40 + rowArray11.Length) - 1;
                                                worksheet.get_Range(worksheet.Cells[num40, 2], worksheet.Cells[num41, 2]).MergeCells = true;
                                                num40 += rowArray11.Length;
                                            }
                                        }
                                        int num50 = (num38 + rowArray14.Length) - 1;
                                        worksheet.get_Range(worksheet.Cells[num38 + 1, 1], worksheet.Cells[num50, 1]).Value2 = "";
                                        worksheet.get_Range(worksheet.Cells[num38, 1], worksheet.Cells[num50, 1]).MergeCells = true;
                                        num38 += rowArray14.Length;
                                    }
                                    worksheet.get_Range(worksheet.Cells[num35, 1], worksheet.Cells[num36, num6]).Font.Name = "Arial Narrow";
                                    worksheet.get_Range(worksheet.Cells[num35, 1], worksheet.Cells[num36, num6]).Font.Size = 10;
                                    worksheet.get_Range(worksheet.Cells[num35, 1], worksheet.Cells[num36, 1]).HorizontalAlignment = XlHAlign.xlHAlignCenter;
                                    worksheet.get_Range(worksheet.Cells[num35, 1], worksheet.Cells[num36, 1]).VerticalAlignment = XlVAlign.xlVAlignCenter;
                                    worksheet.get_Range(worksheet.Cells[num35, 1], worksheet.Cells[num36, num6]).Borders.LineStyle = 1;
                                    worksheet.Select(updateLinks);
                                    worksheet.get_Range("A1", "A1").Select();
                                }
                                else if (tableName.Trim().ToUpper() == "B7")
                                {
                                    DataRow[] rowArray5 = table.Select("sheetname='表7'");
                                    if (rowArray5.Length > 0)
                                    {
                                        int num69 = Convert.ToInt32(rowArray5[0][1].ToString());
                                        worksheet = application.Sheets[num69] as Worksheet;
                                    }
                                    else
                                    {
                                        object obj13 = application.Sheets[application.Sheets.Count] as Worksheet;
                                        application.Sheets.Add(updateLinks, obj13, 1, updateLinks);
                                        worksheet = application.Sheets[application.Sheets.Count] as Worksheet;
                                        worksheet.Name = "表7";
                                        worksheet.get_Range("A1", "A1").Value2 = "项目占用征用林地小班一览表";
                                        worksheet.get_Range("C2", "C2").Value2 = "单位：公顷、立方米";
                                    }
                                    int num51 = worksheet.UsedRange.Rows.Count;
                                    int num52 = (count + 5) - 1;
                                    int num53 = (num51 + 5) - 1;
                                    worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num53, num6]).EntireRow.Delete(updateLinks);
                                    worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num52, num6]).Value2 = objArray;
                                    worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num52, num6]).Font.Name = "Arial Narrow";
                                    worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num52, num6]).Font.Size = 10;
                                    worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num52, num6]).Borders.LineStyle = 1;
                                    worksheet.Select(updateLinks);
                                    worksheet.get_Range("A1", "A1").Select();
                                }
                                else if (tableName.Trim().ToUpper() == "B8")
                                {
                                    DataRow[] rowArray2 = table.Select("sheetname='主体功能区'");
                                    if (rowArray2.Length > 0)
                                    {
                                        int num66 = Convert.ToInt32(rowArray2[0][1].ToString());
                                        worksheet = application.Sheets[num66] as Worksheet;
                                    }
                                    else
                                    {
                                        object obj11 = application.Sheets[application.Sheets.Count] as Worksheet;
                                        application.Sheets.Add(updateLinks, obj11, 1, updateLinks);
                                        worksheet = application.Sheets[application.Sheets.Count] as Worksheet;
                                        worksheet.Name = "主体功能区";
                                        worksheet.get_Range("A1", "A1").Value2 = "项目占用征用林地按主体功能区面积蓄积统计表";
                                        worksheet.get_Range("C2", "C2").Value2 = "单位：公顷、立方米";
                                    }
                                    int num63 = worksheet.UsedRange.Rows.Count;
                                    int num64 = (count + 5) - 1;
                                    int num65 = (num63 + 5) - 1;
                                    worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num65, num6]).EntireRow.Delete(updateLinks);
                                    worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num64, num6]).Value2 = objArray;
                                    worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num64, num6]).Font.Name = "Arial Narrow";
                                    worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num64, num6]).Font.Size = 10;
                                    worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num64, num6]).Borders.LineStyle = 1;
                                    worksheet.get_Range(worksheet.Cells[1, 1], worksheet.Cells[num64, num6]).HorizontalAlignment = XlHAlign.xlHAlignCenter;
                                    worksheet.get_Range(worksheet.Cells[1, 1], worksheet.Cells[num64, num6]).VerticalAlignment = XlVAlign.xlVAlignCenter;
                                    worksheet.Select(updateLinks);
                                    worksheet.get_Range("A1", "A1").Select();
                                    application.ActiveWindow.DisplayZeros = false;
                                }
                                else if (tableName.Trim().ToUpper() == "B9")
                                {
                                    List<string> list = new List<string>();
                                    for (int num31 = 3; num31 < num6; num31++)
                                    {
                                        string[] strArray2 = table2.Columns[num31].ToString().Split(new char[] { '_' });
                                        if (!list.Contains(strArray2[0]))
                                        {
                                            list.Add(strArray2[0]);
                                        }
                                    }
                                    object[] objArray2 = new object[table2.Columns.Count - 3];
                                    for (int num20 = 3; num20 < table2.Columns.Count; num20++)
                                    {
                                        string[] strArray5 = table2.Columns[num20].ToString().Split(new char[] { '_' });
                                        objArray2[num20 - 3] = strArray5[0];
                                    }
                                    DataRow[] rowArray7 = table.Select("sheetname='功能区'");
                                    if (rowArray7.Length > 0)
                                    {
                                        int num68 = Convert.ToInt32(rowArray7[0][1].ToString());
                                        worksheet = application.Sheets[num68] as Worksheet;
                                    }
                                    else
                                    {
                                        object obj10 = application.Sheets[application.Sheets.Count] as Worksheet;
                                        application.Sheets.Add(updateLinks, obj10, 1, updateLinks);
                                        worksheet = application.Sheets[application.Sheets.Count] as Worksheet;
                                        worksheet.Name = "功能区";
                                        worksheet.get_Range("A1", "A1").Value2 = "项目占用征用林地按林地功能分区面积蓄积统计表";
                                        worksheet.get_Range("C2", "C2").Value2 = "单位：公顷、立方米";
                                    }
                                    int num74 = worksheet.UsedRange.Rows.Count;
                                    int num4 = 5;
                                    int num5 = (count + 5) - 1;
                                    int num75 = (num74 + 5) - 1;
                                    worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num75, num6]).EntireRow.Delete(updateLinks);
                                    worksheet.get_Range("D2", "D2").Value2 = "";
                                    worksheet.get_Range(worksheet.Cells[3, 4], worksheet.Cells[3, (objArray2.Length - 1) + 4]).Value2 = objArray2;
                                    int num27 = 2;
                                    for (int num3 = 0; num3 < list.Count; num3++)
                                    {
                                        string local1 = list[num3];
                                        int num28 = 2 * num27;
                                        int num29 = (2 * num27) + 1;
                                        worksheet.get_Range(worksheet.Cells[4, num28], worksheet.Cells[4, num28]).Value2 = "面积";
                                        worksheet.get_Range(worksheet.Cells[4, num29], worksheet.Cells[4, num29]).Value2 = "蓄积";
                                        worksheet.get_Range(worksheet.Cells[3, num28], worksheet.Cells[3, num29]).Merge(updateLinks);
                                        num27++;
                                    }
                                    worksheet.get_Range(worksheet.Cells[num4, 1], worksheet.Cells[num5, num6]).Value2 = objArray;
                                    worksheet.get_Range(worksheet.Cells[1, 1], worksheet.Cells[1, (list.Count * 2) + 3]).Merge(updateLinks);
                                    worksheet.get_Range(worksheet.Cells[2, (list.Count * 2) + 2], worksheet.Cells[2, (list.Count * 2) + 2]).Value2 = "单位：公顷、立方米";
                                    worksheet.get_Range(worksheet.Cells[num4, 1], worksheet.Cells[num5, num6]).Font.Name = "Arial Narrow";
                                    worksheet.get_Range(worksheet.Cells[num4, 1], worksheet.Cells[num5, num6]).Font.Size = 10;
                                    worksheet.get_Range(worksheet.Cells[1, 1], worksheet.Cells[num5, num6]).HorizontalAlignment = XlHAlign.xlHAlignCenter;
                                    worksheet.get_Range(worksheet.Cells[1, 1], worksheet.Cells[num5, num6]).VerticalAlignment = XlVAlign.xlVAlignCenter;
                                    worksheet.get_Range(worksheet.Cells[num4, 1], worksheet.Cells[num5, num6]).Borders.LineStyle = 1;
                                    worksheet.Select(updateLinks);
                                    worksheet.get_Range("A1", "A1").Select();
                                    application.ActiveWindow.DisplayZeros = false;
                                }
                                else if (tableName.Trim().ToUpper() == "B10")
                                {
                                    DataRow[] rowArray4 = table.Select("sheetname='质量等级'");
                                    if (rowArray4.Length > 0)
                                    {
                                        int num70 = Convert.ToInt32(rowArray4[0][1].ToString());
                                        worksheet = application.Sheets[num70] as Worksheet;
                                    }
                                    else
                                    {
                                        object obj8 = application.Sheets[application.Sheets.Count] as Worksheet;
                                        application.Sheets.Add(updateLinks, obj8, 1, updateLinks);
                                        worksheet = application.Sheets[application.Sheets.Count] as Worksheet;
                                        worksheet.Name = "质量等级";
                                        worksheet.get_Range("A1", "A1").Value2 = "项目占用征用林地按质量等级组面积蓄积统计表";
                                        worksheet.get_Range("C2", "C2").Value2 = "单位：公顷、立方米";
                                    }
                                    int num60 = worksheet.UsedRange.Rows.Count;
                                    int num61 = (count + 5) - 1;
                                    int num62 = (num60 + 5) - 1;
                                    worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num62, num6]).EntireRow.Delete(updateLinks);
                                    worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num61, num6]).Value2 = objArray;
                                    worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num61, num6]).Font.Name = "Arial Narrow";
                                    worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num61, num6]).Font.Size = 10;
                                    worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num61, num6]).Borders.LineStyle = 1;
                                    worksheet.get_Range(worksheet.Cells[1, 1], worksheet.Cells[num61, num6]).HorizontalAlignment = XlHAlign.xlHAlignCenter;
                                    worksheet.get_Range(worksheet.Cells[1, 1], worksheet.Cells[num61, num6]).VerticalAlignment = XlVAlign.xlVAlignCenter;
                                    worksheet.Select(updateLinks);
                                    worksheet.get_Range("A1", "A1").Select();
                                    application.ActiveWindow.DisplayZeros = false;
                                }
                                else if (tableName.Trim().ToUpper() == "B11")
                                {
                                    DataRow[] rowArray15 = table.Select("sheetname='保护等级'");
                                    if (rowArray15.Length > 0)
                                    {
                                        int num67 = Convert.ToInt32(rowArray15[0][1].ToString());
                                        worksheet = application.Sheets[num67] as Worksheet;
                                    }
                                    else
                                    {
                                        object obj14 = application.Sheets[application.Sheets.Count] as Worksheet;
                                        application.Sheets.Add(updateLinks, obj14, 1, updateLinks);
                                        worksheet = application.Sheets[application.Sheets.Count] as Worksheet;
                                        worksheet.Name = "保护等级";
                                        worksheet.get_Range("A1", "A1").Value2 = "项目占用征用林地按保护等级面积蓄积统计表";
                                        worksheet.get_Range("C2", "C2").Value2 = "单位：公顷、立方米";
                                    }
                                    int num7 = worksheet.UsedRange.Rows.Count;
                                    int num9 = (count + 5) - 1;
                                    int num10 = (num7 + 5) - 1;
                                    worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num10, num6]).EntireRow.Delete(updateLinks);
                                    worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num9, num6]).Value2 = objArray;
                                    worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num9, num6]).Font.Name = "Arial Narrow";
                                    worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num9, num6]).Font.Size = 10;
                                    worksheet.get_Range(worksheet.Cells[5, 1], worksheet.Cells[num9, num6]).Borders.LineStyle = 1;
                                    worksheet.get_Range(worksheet.Cells[1, 1], worksheet.Cells[num9, num6]).HorizontalAlignment = XlHAlign.xlHAlignCenter;
                                    worksheet.get_Range(worksheet.Cells[1, 1], worksheet.Cells[num9, num6]).VerticalAlignment = XlVAlign.xlVAlignCenter;
                                    worksheet.Select(updateLinks);
                                    worksheet.get_Range("A1", "A1").Select();
                                    application.ActiveWindow.DisplayZeros = false;
                                }
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

        private System.Data.DataTable SLLBTable()
        {
            System.Data.DataTable table = new System.Data.DataTable("DMTable");
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

        /// <summary>
        /// 构建征占地DataTable表
        /// </summary>
        /// <returns></returns>
        private System.Data.DataTable SXFYJSTABLE()
        {
            System.Data.DataTable table = new System.Data.DataTable("ResultTable");
            DataColumn column = new DataColumn("XIAN", typeof(string));
            table.Columns.Add(column);
            column = new DataColumn("XIANG", typeof(string));
            table.Columns.Add(column);
            column = new DataColumn("CUN", typeof(string));
            table.Columns.Add(column);
            column = new DataColumn("LDLX", typeof(string));
            table.Columns.Add(column);
            column = new DataColumn("TDZL", typeof(string));
            table.Columns.Add(column);
            column = new DataColumn("LINZHONG", typeof(string));
            table.Columns.Add(column);
            column = new DataColumn("SHUZHONG", typeof(string));
            table.Columns.Add(column);
            column = new DataColumn("YBD", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("LINGZU", typeof(string));
            table.Columns.Add(column);
            column = new DataColumn("MJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("LDBCBZ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("LDBCF", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("LDAZBZ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("LDAZF", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("LMBCBZ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("LMBCF", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("SXFYHJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("ZBHFF", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("ZFYHJ", typeof(double));
            table.Columns.Add(column);
            return table;
        }

        private DataRow SXFYTJRow(int tjtype, string tjdw, System.Data.DataTable mytjdt, string whereclause)
        {
            DataRow row = this.SXFYJSTABLE().NewRow();
            mytjdt.Rows[0]["SHI"].ToString();
            string str = mytjdt.Rows[0]["XIAN"].ToString();
            string str2 = mytjdt.Rows[0]["XIANG"].ToString();
            if (tjtype < 3)
            {
                row[0] = tjdw;
            }
            else if (tjtype == 3)
            {
                row[0] = str;
                row[1] = tjdw;
            }
            else if (tjtype == 4)
            {
                row[0] = str;
                row[1] = str2;
                row[2] = tjdw;
            }
            row["MJ"] = Convert.ToDouble(mytjdt.Compute("SUM(MJ)", null));
            row["LDBCF"] = Convert.ToDouble(mytjdt.Compute("SUM(LDBCF)", null));
            row["LDAZF"] = Convert.ToDouble(mytjdt.Compute("SUM(LDAZF)", null));
            row["LMBCF"] = Convert.ToDouble(mytjdt.Compute("SUM(LMBCF)", null));
            row["SXFYHJ"] = Convert.ToDouble(mytjdt.Compute("SUM(BCFHJ)", null));
            row["ZBHFF"] = Convert.ToDouble(mytjdt.Compute("SUM(ZBHFF)", null));
            row["ZFYHJ"] = Convert.ToDouble(mytjdt.Compute("SUM(ZFYHJ)", null));
            return row;
        }

        private System.Data.DataTable SYLDLXTABLE()
        {
            System.Data.DataTable table = new System.Data.DataTable("ResultTable");
            DataColumn column = new DataColumn("YDZL", typeof(string));
            table.Columns.Add(column);
            column = new DataColumn("NR", typeof(string));
            table.Columns.Add(column);
            column = new DataColumn("XIAN", typeof(string));
            table.Columns.Add(column);
            column = new DataColumn("XIANG", typeof(string));
            table.Columns.Add(column);
            column = new DataColumn("CUN", typeof(string));
            table.Columns.Add(column);
            column = new DataColumn("SLFL", typeof(string));
            table.Columns.Add(column);
            column = new DataColumn("LINBAN", typeof(string));
            table.Columns.Add(column);
            column = new DataColumn("JYBAN", typeof(string));
            table.Columns.Add(column);
            column = new DataColumn("XIAOBAN", typeof(string));
            table.Columns.Add(column);
            column = new DataColumn("XIBAN", typeof(string));
            table.Columns.Add(column);
            column = new DataColumn("SHUZHONG", typeof(string));
            table.Columns.Add(column);
            column = new DataColumn("MJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("XJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("ZBHFF", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("FHLMJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("FHLXJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("FHLZBHFF", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("TYLMJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("TYLXJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("TYLZBHFF", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("YCLMJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("YCLXJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("YCLZBHFF", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("JJLMJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("JJLXJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("JJLZBHFF", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("XTLMJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("XTLZBHFF", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("MPDMJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("MPDZBHFF", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("QTLDMJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("QTLDZBHFF", typeof(double));
            table.Columns.Add(column);
            return table;
        }

        private DataRow SYLDLXTJRow(System.Data.DataTable mytjdt)
        {
            string filterExpression = " LDLX='1' ";
            string str2 = " LDLX='2' ";
            string str3 = " LDLX='3' ";
            string str4 = " LDLX='4' ";
            string str5 = " LDLX='5' ";
            string str6 = " LDLX='6' ";
            string str7 = " LDLX='7' ";
            string expression = "SUM(MJ)";
            string str9 = "SUM(XJ)";
            string str10 = "SUM(ZBHFF)";
            System.Data.DataTable table = this.SYLDLXTABLE();
            DataRow row = table.NewRow();
            for (int i = 10; i < table.Columns.Count; i++)
            {
                row[i] = 0;
            }
            row["MJ"] = Convert.ToDouble(mytjdt.Compute(expression, null));
            row["XJ"] = Convert.ToDouble(mytjdt.Compute(str9, null));
            row["ZBHFF"] = Convert.ToDouble(mytjdt.Compute(str10, null));
            if (mytjdt.Select(filterExpression).Length > 0)
            {
                row["FHLMJ"] = Convert.ToDouble(mytjdt.Compute(expression, filterExpression));
                row["FHLXJ"] = Convert.ToDouble(mytjdt.Compute(str9, filterExpression));
                row["FHLZBHFF"] = Convert.ToDouble(mytjdt.Compute(str10, filterExpression));
            }
            if (mytjdt.Select(str2).Length > 0)
            {
                row["TYLMJ"] = Convert.ToDouble(mytjdt.Compute(expression, str2));
                row["TYLXJ"] = Convert.ToDouble(mytjdt.Compute(str9, str2));
                row["TYLZBHFF"] = Convert.ToDouble(mytjdt.Compute(str10, str2));
            }
            if (mytjdt.Select(str3).Length > 0)
            {
                row["YCLMJ"] = Convert.ToDouble(mytjdt.Compute(expression, str3));
                row["YCLXJ"] = Convert.ToDouble(mytjdt.Compute(str9, str3));
                row["YCLZBHFF"] = Convert.ToDouble(mytjdt.Compute(str10, str3));
            }
            if (mytjdt.Select(str4).Length > 0)
            {
                row["JJLMJ"] = Convert.ToDouble(mytjdt.Compute(expression, str4));
                row["JJLXJ"] = Convert.ToDouble(mytjdt.Compute(str9, str4));
                row["JJLZBHFF"] = Convert.ToDouble(mytjdt.Compute(str10, str4));
            }
            if (mytjdt.Select(str5).Length > 0)
            {
                row["XTLMJ"] = Convert.ToDouble(mytjdt.Compute(expression, str5));
                row["XTLZBHFF"] = Convert.ToDouble(mytjdt.Compute(str10, str5));
            }
            if (mytjdt.Select(str6).Length > 0)
            {
                row["MPDMJ"] = Convert.ToDouble(mytjdt.Compute(expression, str6));
                row["MPDZBHFF"] = Convert.ToDouble(mytjdt.Compute(str10, str6));
            }
            if (mytjdt.Select(str7).Length > 0)
            {
                row["QTLDMJ"] = Convert.ToDouble(mytjdt.Compute(str9, str7));
                row["QTLDZBHFF"] = Convert.ToDouble(mytjdt.Compute(str10, str7));
            }
            return row;
        }

        public System.Data.DataTable SYLDLXTJTable()
        {
            System.Data.DataTable source = this.SYLDLXTABLE();
            string cmdtxt = "SELECT LTRIM(RTRIM(XIAN)) AS XIAN,LTRIM(RTRIM(XIANG)) AS XIANG,LTRIM(RTRIM(CUN)) AS CUN,LIN_BAN,XIAO_BAN,XI_BAN,LDLX,Q_DI_LEI AS DI_LEI,Q_SEN_LB AS SEN_LIN_LB,";
            string str2 = cmdtxt;
            cmdtxt = str2 + "YOU_SHI_SZ,MIAN_JI AS MJ,SLXJ AS XJ,ZBHFF,YDZL FROM " + TABLE_ZZYTableName + " WHERE (LTRIM(RTRIM(XMMC))='" + TABLE_ZZYXMMC + "')";
            System.Data.DataTable table = this.GetTable(cmdtxt, "xbdata");
            table = this.GetTable(cmdtxt, TABLE_ZZYTableName);
            if (table == null)
            {
                MessageBox.Show(TABLE_ZZYTableName + " 数据读取出错！", "使用林地类型表统计", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return null;
            }
            if (table.Rows.Count != 0)
            {
                table.Columns.Add("PTDZL", typeof(string));
                table.Columns.Add("PSLLB", typeof(string));
                table.Columns.Add("PXBID", typeof(string));
                List<string> xianDistList = new List<string>();
                foreach (DataRow row in table.Rows)
                {
                    string str5 = row["CUN"].ToString().Trim() + row["LIN_BAN"].ToString().Trim() + row["XIAO_BAN"].ToString().Trim().PadLeft(6);
                    row["PXBID"] = str5;
                    string str3 = row["DI_LEI"].ToString().Trim();
                    row["PTDZL"] = str3;
                    if ((str3 != "111") && (str3 != "112"))
                    {
                        if (((str3 != "401") && (str3 != "402")) && ((str3 != "403") && (str3 != "404")))
                        {
                            if ((str3.Length == 3) && (str3.Substring(0, 2) == "70"))
                            {
                                str3 = "700";
                                row["PTDZL"] = str3;
                            }
                        }
                        else
                        {
                            str3 = "400";
                            row["PTDZL"] = str3;
                        }
                    }
                    else
                    {
                        str3 = "110";
                        row["PTDZL"] = str3;
                    }
                    string str4 = row["SEN_LIN_LB"].ToString().Trim();
                    row["PSLLB"] = str4;
                    if ((str4 != "11") && (str3 != "12"))
                    {
                        if ((str3 == "21") || (str3 == "22"))
                        {
                            str3 = "20";
                            row["PTDZL"] = str3;
                        }
                    }
                    else
                    {
                        str4 = "10";
                        row["PSLLB"] = str4;
                    }
                }
                table.DefaultView.Sort = "PXBID";
                DataView defaultView = table.DefaultView.ToTable(true, new string[] { "YDZL" }).DefaultView;
                defaultView.Sort = "YDZL DESC";
                foreach (DataRowView view2 in defaultView)
                {
                    string pydzl = view2[0].ToString().Trim();
                    System.Data.DataTable mytjdt = this.GetDataTabeBySelRows(table, "YDZL='" + pydzl + "'");
                    xianDistList.Clear();
                    foreach (DataRow row2 in mytjdt.Rows)
                    {
                        string item = row2["XIAN"].ToString();
                        if (!xianDistList.Contains(item))
                        {
                            xianDistList.Add(item);
                        }
                    }
                    xianDistList.Sort();
                    switch (pydzl)
                    {
                        case "2":
                            foreach (DataRow row3 in this.SYLDLXTJTableByYDZL(mytjdt, xianDistList, pydzl).Rows)
                            {
                                source.Rows.Add(row3.ItemArray);
                            }
                            break;

                        case "1":
                            foreach (DataRow row4 in this.SYLDLXTJTableByYDZL(mytjdt, xianDistList, pydzl).Rows)
                            {
                                source.Rows.Add(row4.ItemArray);
                            }
                            break;
                    }
                }
                foreach (DataRow row5 in source.Rows)
                {
                    string str8 = row5["XIAN"].ToString().Trim();
                    if (str8 == "200")
                    {
                        str8 = "疏林地";
                        row5["XIAN"] = str8;
                    }
                    else if (str8 == "302")
                    {
                        str8 = "一般灌";
                        row5["XIAN"] = str8;
                    }
                    else if (str8 == "400")
                    {
                        str8 = "未成林";
                        row5["XIAN"] = str8;
                    }
                    else if (str8 == "601")
                    {
                        str8 = "采伐迹地";
                        row5["XIAN"] = str8;
                    }
                    else if (str8 == "602")
                    {
                        str8 = "火烧迹地";
                        row5["XIAN"] = str8;
                    }
                    else if (str8.IndexOf("603") > -1)
                    {
                        str8 = "其它无立木";
                        row5["XIAN"] = str8;
                    }
                    else if (str8 == "700")
                    {
                        str8 = "宜林地";
                        row5["XIAN"] = str8;
                    }
                    else if (str8 == "800")
                    {
                        str8 = "辅助地";
                        row5["XIAN"] = str8;
                    }
                    string str10 = row5["SLFL"].ToString().Trim();
                    switch (str10)
                    {
                        case "10":
                            str10 = "公益林区";
                            row5["SLFL"] = str10;
                            break;

                        case "20":
                            str10 = "商品林区";
                            row5["SLFL"] = str10;
                            break;
                    }
                    string str9 = row5["YDZL"].ToString().Trim();
                    if (str9 == "2")
                    {
                        str9 = "长期用地";
                        row5["YDZL"] = str9;
                    }
                    else if (str9 == "1")
                    {
                        str9 = "临时用地";
                        row5["YDZL"] = str9;
                    }
                }
                string str11 = " SELECT CCODE,CNAME,CINDEX FROM " + TABLE_XZDWTABLE + " WHERE (CINDEX > '101') AND (CINDEX < '106') OR (CINDEX = '219')";
                System.Data.DataTable table7 = this.GetTable(str11, "xcdm");
                System.Data.DataTable dataTabeBySelRows = this.GetDataTabeBySelRows(table7, "CINDEX > '101' AND CINDEX < '106'");
                foreach (var type in Enumerable.Join(DataTableExtensions.AsEnumerable(source), DataTableExtensions.AsEnumerable(dataTabeBySelRows), delegate(DataRow dataRow_0)
                {
                    return DataRowExtensions.Field<string>(dataRow_0, "XIAN");
                }, delegate(DataRow dataRow_0)
                {
                    return DataRowExtensions.Field<string>(dataRow_0, "CCODE");
                }, delegate(DataRow dataRow_0, DataRow dataRow_1)
                {
                    return new
                    {
                        dt1row = dataRow_0,
                        dt2row = dataRow_1
                    };
                }))
                {
                    type.dt1row["XIAN"] = type.dt2row["CNAME"];
                }
                foreach (var type2 in Enumerable.Join(DataTableExtensions.AsEnumerable(source), DataTableExtensions.AsEnumerable(dataTabeBySelRows), delegate(DataRow dataRow_0)
                {
                    return DataRowExtensions.Field<string>(dataRow_0, "XIANG");
                }, delegate(DataRow dataRow_0)
                {
                    return DataRowExtensions.Field<string>(dataRow_0, "CCODE");
                }, delegate(DataRow dataRow_0, DataRow dataRow_1)
                {
                    return new
                    {
                        dt1row = dataRow_0,
                        dt2row = dataRow_1
                    };
                }))
                {
                    type2.dt1row["XIANG"] = type2.dt2row["CNAME"];
                }
                foreach (var type3 in Enumerable.Join(DataTableExtensions.AsEnumerable(source), DataTableExtensions.AsEnumerable(dataTabeBySelRows), delegate(DataRow dataRow_0)
                {
                    return DataRowExtensions.Field<string>(dataRow_0, "CUN");
                }, delegate(DataRow dataRow_0)
                {
                    return DataRowExtensions.Field<string>(dataRow_0, "CCODE");
                }, delegate(DataRow dataRow_0, DataRow dataRow_1)
                {
                    return new
                    {
                        dt1row = dataRow_0,
                        dt2row = dataRow_1
                    };
                }))
                {
                    type3.dt1row["CUN"] = type3.dt2row["CNAME"];
                }
                dataTabeBySelRows = this.GetDataTabeBySelRows(table7, "CINDEX = '219'");
                foreach (var type4 in Enumerable.Join(DataTableExtensions.AsEnumerable(source), DataTableExtensions.AsEnumerable(dataTabeBySelRows), delegate(DataRow dataRow_0)
                {
                    return DataRowExtensions.Field<string>(dataRow_0, "SHUZHONG");
                }, delegate(DataRow dataRow_0)
                {
                    return DataRowExtensions.Field<string>(dataRow_0, "CCODE");
                }, delegate(DataRow dataRow_0, DataRow dataRow_1)
                {
                    return new
                    {
                        dt1row = dataRow_0,
                        dt2row = dataRow_1
                    };
                }))
                {
                    type4.dt1row["SHUZHONG"] = type4.dt2row["CNAME"];
                }
            }
            return source;
        }

        private System.Data.DataTable SYLDLXTJTableByYDZL(System.Data.DataTable mytjdt, List<string> XianDistList, string pydzl)
        {
            System.Data.DataTable table = this.SYLDLXTABLE();
            System.Data.DataTable dataTabeBySelRows = this.GetDataTabeBySelRows(mytjdt, "YDZL='" + pydzl + "'");
            System.Data.DataTable table3 = this.GetDataTabeBySelRows(mytjdt, "PTDZL='200' OR PTDZL='302' OR PTDZL='400' OR PTDZL='601' OR PTDZL='602' OR PTDZL LIKE '603%' OR PTDZL='700' OR PTDZL='800'");
            table3.DefaultView.Sort = "PTDZL";
            System.Data.DataTable table4 = table3.DefaultView.ToTable(true, new string[] { "PTDZL" });
            DataRow row = this.SYLDLXTJRow(dataTabeBySelRows);
            row[0] = pydzl;
            row[2] = "合 计";
            table.Rows.Add(row.ItemArray);
            foreach (DataRow row3 in table4.Rows)
            {
                string str5 = row3[0].ToString().Trim();
                System.Data.DataTable table9 = this.GetDataTabeBySelRows(mytjdt, "PTDZL='" + str5 + "'");
                row = this.SYLDLXTJRow(table9);
                row[0] = pydzl;
                row[1] = "其中";
                row[2] = str5;
                table.Rows.Add(row.ItemArray);
            }
            for (int i = 0; i < XianDistList.Count; i++)
            {
                string str2 = XianDistList[i].ToString();
                System.Data.DataTable table7 = this.GetDataTabeBySelRows(mytjdt, "XIAN='" + str2 + "'");
                row = this.SYLDLXTJRow(table7);
                row[0] = pydzl;
                row[2] = str2;
                row[3] = "合计";
                table.Rows.Add(row.ItemArray);
                table3 = this.GetDataTabeBySelRows(table7, "PTDZL='200' OR PTDZL='302' OR PTDZL='400' OR PTDZL='601' OR PTDZL='602' OR PTDZL LIKE '603%' OR PTDZL='700' OR PTDZL='800'");
                table3.DefaultView.Sort = "PTDZL";
                foreach (DataRow row4 in table3.DefaultView.ToTable(true, new string[] { "PTDZL" }).Rows)
                {
                    string str6 = row4[0].ToString().Trim();
                    System.Data.DataTable table10 = this.GetDataTabeBySelRows(table7, "PTDZL='" + str6 + "'");
                    row = this.SYLDLXTJRow(table10);
                    row[0] = pydzl;
                    row[1] = "其中";
                    row[2] = str6;
                    table.Rows.Add(row.ItemArray);
                }
                List<string> list2 = new List<string>();
                list2.Clear();
                for (int j = 0; j < table7.Rows.Count; j++)
                {
                    string item = table7.Rows[j]["XIANG"].ToString();
                    if (!list2.Contains(item))
                    {
                        list2.Add(item);
                    }
                }
                list2.Sort();
                for (int k = 0; k < list2.Count; k++)
                {
                    string str3 = list2[k].ToString();
                    System.Data.DataTable table5 = this.GetDataTabeBySelRows(table7, "XIANG='" + str3 + "'");
                    row = this.SYLDLXTJRow(table5);
                    row[0] = pydzl;
                    row[2] = str2;
                    row[3] = str3;
                    row[4] = "合计";
                    table.Rows.Add(row.ItemArray);
                    List<string> list = new List<string>();
                    list.Clear();
                    for (int m = 0; m < table5.Rows.Count; m++)
                    {
                        string str4 = table5.Rows[m]["CUN"].ToString();
                        if (!list.Contains(str4))
                        {
                            list.Add(str4);
                        }
                    }
                    list.Sort();
                    for (int n = 0; n < list.Count; n++)
                    {
                        string str = list[n].ToString();
                        System.Data.DataTable table6 = this.GetDataTabeBySelRows(table5, "CUN='" + str + "'");
                        row = this.SYLDLXTJRow(table6);
                        row[0] = pydzl;
                        row[2] = str2;
                        row[3] = str3;
                        row[4] = str;
                        row[5] = "合计";
                        table.Rows.Add(row.ItemArray);
                        table6.DefaultView.Sort = "PXBID";
                        foreach (DataRow row2 in table6.Rows)
                        {
                            System.Data.DataTable table8 = mytjdt.Clone();
                            table8.Rows.Add(row2.ItemArray);
                            row = this.SYLDLXTJRow(table8);
                            row[0] = pydzl;
                            row[2] = str2;
                            row[3] = str3;
                            row[4] = str;
                            row[5] = row2["PSLLB"];
                            row["LINBAN"] = row2["LIN_BAN"].ToString().Substring(0, 2).TrimStart(new char[] { '0' });
                            row["JYBAN"] = row2["LIN_BAN"].ToString().Substring(2, 2).TrimStart(new char[] { '0' });
                            row["XIAOBAN"] = row2["XIAO_BAN"];
                            row["SHUZHONG"] = row2["YOU_SHI_SZ"];
                            table.Rows.Add(row.ItemArray);
                        }
                    }
                }
            }
            return table;
        }

        private System.Data.DataTable UpdateDWTableByJoin(System.Data.DataTable dataTable_0)
        {
            string cmdtxt = " SELECT CCODE,CNAME FROM " + TABLE_XZDWTABLE + " WHERE (CINDEX > '101') AND (CINDEX < '106')";
            System.Data.DataTable source = this.GetTable(cmdtxt, "xcdm");
            foreach (var type in Enumerable.Join(DataTableExtensions.AsEnumerable(dataTable_0), DataTableExtensions.AsEnumerable(source), delegate(DataRow dataRow_0)
            {
                return DataRowExtensions.Field<string>(dataRow_0, "tjdw");
            }, delegate(DataRow dataRow_0)
            {
                return DataRowExtensions.Field<string>(dataRow_0, "CCODE");
            }, delegate(DataRow dataRow_0, DataRow dataRow_1)
            {
                return new
                {
                    dt1row = dataRow_0,
                    dt2row = dataRow_1
                };
            }))
            {
                type.dt1row["tjdw"] = type.dt2row["CNAME"];
            }
            return dataTable_0;
        }

        private System.Data.DataTable UpdateTableLDQSByJoin(System.Data.DataTable dataTable_0, string whereclause, string joincolname1)
        {
            System.Data.DataTable source = this.GetTable(" SELECT CCODE,CSNAME FROM " + TABLE_XZDWTABLE + " WHERE " + whereclause, "metadt");
            foreach (var type in Enumerable.Join(DataTableExtensions.AsEnumerable(dataTable_0), DataTableExtensions.AsEnumerable(source), delegate(DataRow dataRow_0)
            {
                return DataRowExtensions.Field<string>(dataRow_0, joincolname1);
            }, delegate(DataRow dataRow_0)
            {
                return DataRowExtensions.Field<string>(dataRow_0, "CCODE");
            }, delegate(DataRow dataRow_0, DataRow dataRow_1)
            {
                return new
                {
                    dt1row = dataRow_0,
                    dt2row = dataRow_1
                };
            }))
            {
                type.dt1row[joincolname1] = type.dt2row["CSNAME"].ToString().Substring(0, 2);
            }
            return dataTable_0;
        }

        private System.Data.DataTable YDFWTable()
        {
            System.Data.DataTable table = new System.Data.DataTable("DMTable");
            DataColumn column = new DataColumn("CCODE", typeof(string));
            table.Columns.Add(column);
            column = new DataColumn("CSNAME", typeof(string));
            table.Columns.Add(column);
            DataRow row = table.NewRow();
            row[0] = "1";
            row[1] = "城市用地";
            table.Rows.Add(row);
            row = table.NewRow();
            row[0] = "2";
            row[1] = "非城市用地";
            table.Rows.Add(row);
            return table;
        }

        private System.Data.DataTable ZLDJSimpleTJTable(string tjdw, System.Data.DataTable mytjdt)
        {
            System.Data.DataTable table = new System.Data.DataTable("tjtable");
            table.Columns.Add("TJDW", typeof(string));
            table.Columns.Add("MJHJ", typeof(double));
            table.Columns.Add("XJHJ", typeof(double));
            for (int i = 1; i < 6; i++)
            {
                table.Columns.Add("C" + i.ToString() + "MJ", typeof(double));
                table.Columns.Add("C" + i.ToString() + "XJ", typeof(double));
            }
            string expression = "SUM(MIAN_JI)";
            string str3 = "SUM(SLXJ)";
            string filterExpression = "zldj='1'";
            string str6 = "zldj='2'";
            string str7 = "zldj='3'";
            string str4 = "zldj='4'";
            string str = "zldj='5'";
            double num10 = 0.0;
            double num13 = 0.0;
            double num6 = 0.0;
            double num7 = 0.0;
            double num8 = 0.0;
            double num11 = 0.0;
            double num9 = 0.0;
            double num12 = 0.0;
            double num4 = 0.0;
            double num5 = 0.0;
            double num2 = 0.0;
            double num3 = 0.0;
            if (mytjdt.Select(filterExpression).Length > 0)
            {
                num6 = Convert.ToDouble(mytjdt.Compute(expression, filterExpression));
                num7 = Convert.ToDouble(mytjdt.Compute(str3, filterExpression));
            }
            if (mytjdt.Select(str6).Length > 0)
            {
                num8 = Convert.ToDouble(mytjdt.Compute(expression, str6));
                num11 = Convert.ToDouble(mytjdt.Compute(str3, str6));
            }
            if (mytjdt.Select(str7).Length > 0)
            {
                num9 = Convert.ToDouble(mytjdt.Compute(expression, str7));
                num12 = Convert.ToDouble(mytjdt.Compute(str3, str7));
            }
            if (mytjdt.Select(str4).Length > 0)
            {
                num4 = Convert.ToDouble(mytjdt.Compute(expression, str4));
                num5 = Convert.ToDouble(mytjdt.Compute(str3, str4));
            }
            if (mytjdt.Select(str).Length > 0)
            {
                num2 = Convert.ToDouble(mytjdt.Compute(expression, str));
                num3 = Convert.ToDouble(mytjdt.Compute(str3, str));
            }
            num10 = (((num6 + num8) + num9) + num4) + num2;
            num13 = (((num7 + num11) + num12) + num5) + num3;
            DataRow row = table.NewRow();
            row["tjdw"] = tjdw;
            row["MJHJ"] = num10;
            row["XJHJ"] = num13;
            row["C1MJ"] = num6;
            row["C1XJ"] = num7;
            row["C2MJ"] = num8;
            row["C2XJ"] = num11;
            row["C3MJ"] = num9;
            row["C3XJ"] = num12;
            row["C4MJ"] = num4;
            row["C4XJ"] = num5;
            row["C5MJ"] = num2;
            row["C5XJ"] = num3;
            if ((num10 > 0.0) || (num13 > 0.0))
            {
                table.Rows.Add(row);
            }
            return table;
        }

        public System.Data.DataTable ZLDJTJTableXianXiangCun(string ydzl)
        {
            System.Data.DataTable table = new System.Data.DataTable("tjtable");
            table.Columns.Add("TJDW", typeof(string));
            table.Columns.Add("MJHJ", typeof(double));
            table.Columns.Add("XJHJ", typeof(double));
            for (int i = 1; i < 6; i++)
            {
                table.Columns.Add("C" + i.ToString() + "MJ", typeof(double));
                table.Columns.Add("C" + i.ToString() + "XJ", typeof(double));
            }
            try
            {
                System.Data.DataTable mytjdt = new System.Data.DataTable();
                string cmdtxt = "SELECT LTRIM(RTRIM(SHI)) AS SHI,LTRIM(RTRIM(XIAN)) AS XIAN,LTRIM(RTRIM(XIANG)) AS XIANG,LTRIM(RTRIM(CUN)) AS CUN,LTRIM(RTRIM(zl_dj)) AS zldj,MIAN_JI,SLXJ FROM " + TABLE_ZZYTableName + " WHERE (RTRIM(LTRIM(XMMC))='" + TABLE_ZZYXMMC + "') AND LTRIM(RTRIM(YDZL))='" + ydzl + "'";
                mytjdt = this.GetTable(cmdtxt, TABLE_ZZYTableName);
                if (mytjdt == null)
                {
                    MessageBox.Show(TABLE_ZZYTableName + " 林地质量等级数据读取出错！", "信息", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return null;
                }
                if (mytjdt.Rows.Count == 0)
                {
                    return table;
                }
                List<string> list4 = new List<string>();
                List<string> list2 = new List<string>();
                for (int j = 0; j < mytjdt.Rows.Count; j++)
                {
                    string item = mytjdt.Rows[j]["SHI"].ToString().Trim();
                    if (!list4.Contains(item))
                    {
                        list4.Add(item);
                    }
                }
                list4.Sort();
                System.Data.DataTable table7 = new System.Data.DataTable("tjdt");
                table7 = this.ZLDJSimpleTJTable("项目区", mytjdt);
                foreach (DataRow row4 in table7.Rows)
                {
                    table.ImportRow(row4);
                }
                System.Data.DataTable table6 = mytjdt.Clone();
                for (int k = 0; k < list4.Count; k++)
                {
                    table6.Clear();
                    string tjdw = list4[k].ToString();
                    foreach (DataRow row2 in mytjdt.Select("SHI='" + tjdw + "'"))
                    {
                        table6.Rows.Add(row2.ItemArray);
                    }
                    list2.Clear();
                    for (int m = 0; m < table6.Rows.Count; m++)
                    {
                        string str3 = table6.Rows[m]["XIAN"].ToString();
                        if (!list2.Contains(str3))
                        {
                            list2.Add(str3);
                        }
                    }
                    list2.Sort();
                    table7.Clear();
                    table7 = this.ZLDJSimpleTJTable(tjdw, table6);
                    foreach (DataRow row6 in table7.Rows)
                    {
                        table.ImportRow(row6);
                    }
                    System.Data.DataTable table4 = new System.Data.DataTable("xian");
                    table4 = mytjdt.Clone();
                    for (int n = 0; n < list2.Count; n++)
                    {
                        table4.Clear();
                        string str5 = list2[n].ToString();
                        foreach (DataRow row3 in table6.Select("XIAN='" + str5 + "'"))
                        {
                            table4.Rows.Add(row3.ItemArray);
                        }
                        table7.Clear();
                        table7 = this.ZLDJSimpleTJTable(str5, table4);
                        foreach (DataRow row8 in table7.Rows)
                        {
                            table.ImportRow(row8);
                        }
                        List<string> list = new List<string>();
                        list.Clear();
                        for (int num2 = 0; num2 < table4.Rows.Count; num2++)
                        {
                            string str4 = table4.Rows[num2]["XIANG"].ToString();
                            if (!list.Contains(str4))
                            {
                                list.Add(str4);
                            }
                        }
                        list.Sort();
                        System.Data.DataTable table5 = mytjdt.Clone();
                        for (int num3 = 0; num3 < list.Count; num3++)
                        {
                            table5.Clear();
                            string str9 = list[num3].ToString();
                            foreach (DataRow row5 in table4.Select("XIANG='" + str9 + "'"))
                            {
                                table5.Rows.Add(row5.ItemArray);
                            }
                            table7.Clear();
                            table7 = this.ZLDJSimpleTJTable(str9, table5);
                            foreach (DataRow row in table7.Rows)
                            {
                                table.ImportRow(row);
                            }
                            List<string> list3 = new List<string>();
                            list3.Clear();
                            for (int num9 = 0; num9 < table5.Rows.Count; num9++)
                            {
                                string str7 = table5.Rows[num9]["CUN"].ToString();
                                if (!list3.Contains(str7))
                                {
                                    list3.Add(str7);
                                }
                            }
                            list3.Sort();
                            System.Data.DataTable dataTabeBySelRows = mytjdt.Clone();
                            for (int num8 = 0; num8 < list3.Count; num8++)
                            {
                                dataTabeBySelRows.Clear();
                                string str8 = list3[num8].ToString();
                                dataTabeBySelRows = this.GetDataTabeBySelRows(table5, "CUN='" + str8 + "'");
                                table7.Clear();
                                table7 = this.ZLDJSimpleTJTable(str8, dataTabeBySelRows);
                                foreach (DataRow row7 in table7.Rows)
                                {
                                    table.ImportRow(row7);
                                }
                            }
                        }
                    }
                }
                table7.Clear();
                table6.Clear();
                mytjdt.Clear();
                table = this.UpdateDWTableByJoin(table);
            }
            catch (Exception exception)
            {
                MessageBox.Show("林地质量等级统计出错，错误:" + exception.ToString() + "\n\r请与程序提供者联系！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            return table;
        }

        private System.Data.DataTable ZTGNQSimpleTJTable(string tjdw, System.Data.DataTable mytjdt)
        {
            System.Data.DataTable table = new System.Data.DataTable("tjtable");
            table.Columns.Add("TJDW", typeof(string));
            table.Columns.Add("MJHJ", typeof(double));
            table.Columns.Add("XJHJ", typeof(double));
            for (int i = 1; i < 5; i++)
            {
                table.Columns.Add("C" + i.ToString() + "MJ", typeof(double));
                table.Columns.Add("C" + i.ToString() + "XJ", typeof(double));
            }
            string expression = "SUM(MIAN_JI)";
            string str3 = "SUM(SLXJ)";
            string filterExpression = "zldj='1'";
            string str5 = "zldj='2'";
            string str = "zldj='3'";
            string str6 = "zldj='4'";
            double num6 = 0.0;
            double num7 = 0.0;
            double num4 = 0.0;
            double num5 = 0.0;
            double num8 = 0.0;
            double num9 = 0.0;
            double num2 = 0.0;
            double num3 = 0.0;
            double num10 = 0.0;
            double num11 = 0.0;
            if (mytjdt.Select(filterExpression).Length > 0)
            {
                num4 = Convert.ToDouble(mytjdt.Compute(expression, filterExpression));
                num5 = Convert.ToDouble(mytjdt.Compute(str3, filterExpression));
            }
            if (mytjdt.Select(str5).Length > 0)
            {
                num8 = Convert.ToDouble(mytjdt.Compute(expression, str5));
                num9 = Convert.ToDouble(mytjdt.Compute(str3, str5));
            }
            if (mytjdt.Select(str).Length > 0)
            {
                num2 = Convert.ToDouble(mytjdt.Compute(expression, str));
                num3 = Convert.ToDouble(mytjdt.Compute(str3, str));
            }
            if (mytjdt.Select(str6).Length > 0)
            {
                num10 = Convert.ToDouble(mytjdt.Compute(expression, str6));
                num11 = Convert.ToDouble(mytjdt.Compute(str3, str6));
            }
            num6 = ((num4 + num8) + num2) + num10;
            num7 = ((num5 + num9) + num3) + num11;
            DataRow row = table.NewRow();
            row["tjdw"] = tjdw;
            row["MJHJ"] = num6;
            row["XJHJ"] = num7;
            row["C1MJ"] = num4;
            row["C1XJ"] = num5;
            row["C2MJ"] = num8;
            row["C2XJ"] = num9;
            row["C3MJ"] = num2;
            row["C3XJ"] = num3;
            row["C4MJ"] = num10;
            row["C4XJ"] = num11;
            if ((num6 > 0.0) || (num7 > 0.0))
            {
                table.Rows.Add(row);
            }
            return table;
        }

        public System.Data.DataTable ZTGNQTJTableXianXiangCun(string ydzl)
        {
            System.Data.DataTable table = new System.Data.DataTable("tjtable");
            table.Columns.Add("TJDW", typeof(string));
            table.Columns.Add("MJHJ", typeof(double));
            table.Columns.Add("XJHJ", typeof(double));
            for (int i = 1; i < 5; i++)
            {
                table.Columns.Add("C" + i.ToString() + "MJ", typeof(double));
                table.Columns.Add("C" + i.ToString() + "XJ", typeof(double));
            }
            try
            {
                System.Data.DataTable mytjdt = new System.Data.DataTable();
                string cmdtxt = "SELECT LTRIM(RTRIM(SHI)) AS SHI,LTRIM(RTRIM(XIAN)) AS XIAN,LTRIM(RTRIM(XIANG)) AS XIANG,LTRIM(RTRIM(CUN)) AS CUN,LTRIM(RTRIM(QYKZ)) AS zldj,MIAN_JI,SLXJ FROM " + TABLE_ZZYTableName + " WHERE (RTRIM(LTRIM(XMMC))='" + TABLE_ZZYXMMC + "') AND LTRIM(RTRIM(YDZL))='" + ydzl + "'";
                mytjdt = this.GetTable(cmdtxt, TABLE_ZZYTableName);
                if (mytjdt == null)
                {
                    MessageBox.Show(TABLE_ZZYTableName + " 林地主体功能区数据读取出错！", "信息", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return null;
                }
                if (mytjdt.Rows.Count == 0)
                {
                    return table;
                }
                List<string> list4 = new List<string>();
                List<string> list2 = new List<string>();
                for (int j = 0; j < mytjdt.Rows.Count; j++)
                {
                    string item = mytjdt.Rows[j]["SHI"].ToString().Trim();
                    if (!list4.Contains(item))
                    {
                        list4.Add(item);
                    }
                }
                list4.Sort();
                System.Data.DataTable table7 = new System.Data.DataTable("tjdt");
                table7 = this.ZTGNQSimpleTJTable("项目区", mytjdt);
                foreach (DataRow row4 in table7.Rows)
                {
                    table.ImportRow(row4);
                }
                System.Data.DataTable table6 = mytjdt.Clone();
                for (int k = 0; k < list4.Count; k++)
                {
                    table6.Clear();
                    string tjdw = list4[k].ToString();
                    foreach (DataRow row2 in mytjdt.Select("SHI='" + tjdw + "'"))
                    {
                        table6.Rows.Add(row2.ItemArray);
                    }
                    list2.Clear();
                    for (int m = 0; m < table6.Rows.Count; m++)
                    {
                        string str3 = table6.Rows[m]["XIAN"].ToString();
                        if (!list2.Contains(str3))
                        {
                            list2.Add(str3);
                        }
                    }
                    list2.Sort();
                    table7.Clear();
                    table7 = this.ZTGNQSimpleTJTable(tjdw, table6);
                    foreach (DataRow row6 in table7.Rows)
                    {
                        table.ImportRow(row6);
                    }
                    System.Data.DataTable table4 = new System.Data.DataTable("xian");
                    table4 = mytjdt.Clone();
                    for (int n = 0; n < list2.Count; n++)
                    {
                        table4.Clear();
                        string str5 = list2[n].ToString();
                        foreach (DataRow row3 in table6.Select("XIAN='" + str5 + "'"))
                        {
                            table4.Rows.Add(row3.ItemArray);
                        }
                        table7.Clear();
                        table7 = this.ZTGNQSimpleTJTable(str5, table4);
                        foreach (DataRow row8 in table7.Rows)
                        {
                            table.ImportRow(row8);
                        }
                        List<string> list = new List<string>();
                        list.Clear();
                        for (int num2 = 0; num2 < table4.Rows.Count; num2++)
                        {
                            string str4 = table4.Rows[num2]["XIANG"].ToString();
                            if (!list.Contains(str4))
                            {
                                list.Add(str4);
                            }
                        }
                        list.Sort();
                        System.Data.DataTable table5 = mytjdt.Clone();
                        for (int num3 = 0; num3 < list.Count; num3++)
                        {
                            table5.Clear();
                            string str9 = list[num3].ToString();
                            foreach (DataRow row5 in table4.Select("XIANG='" + str9 + "'"))
                            {
                                table5.Rows.Add(row5.ItemArray);
                            }
                            table7.Clear();
                            table7 = this.ZTGNQSimpleTJTable(str9, table5);
                            foreach (DataRow row in table7.Rows)
                            {
                                table.ImportRow(row);
                            }
                            List<string> list3 = new List<string>();
                            list3.Clear();
                            for (int num9 = 0; num9 < table5.Rows.Count; num9++)
                            {
                                string str7 = table5.Rows[num9]["CUN"].ToString();
                                if (!list3.Contains(str7))
                                {
                                    list3.Add(str7);
                                }
                            }
                            list3.Sort();
                            System.Data.DataTable dataTabeBySelRows = mytjdt.Clone();
                            for (int num8 = 0; num8 < list3.Count; num8++)
                            {
                                dataTabeBySelRows.Clear();
                                string str8 = list3[num8].ToString();
                                dataTabeBySelRows = this.GetDataTabeBySelRows(table5, "CUN='" + str8 + "'");
                                table7.Clear();
                                table7 = this.ZTGNQSimpleTJTable(str8, dataTabeBySelRows);
                                foreach (DataRow row7 in table7.Rows)
                                {
                                    table.ImportRow(row7);
                                }
                            }
                        }
                    }
                }
                table7.Clear();
                table6.Clear();
                mytjdt.Clear();
                table = this.UpdateDWTableByJoin(table);
            }
            catch (Exception exception)
            {
                MessageBox.Show("林地主体功能区统计出错，错误:" + exception.ToString() + "\n\r请与程序提供者联系！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            return table;
        }

        /// <summary>
        /// 数据库连接信息
        /// </summary>
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

        /// <summary>
        /// 获取和设置  单位表格
        /// </summary>
        public static string TABLE_XZDWTABLE
        {
            get
            {
                return str_xzdw_table;
            }
            set
            {
                str_xzdw_table = value;
            }
        }

        /// <summary>
        /// 获取和设置征占用表名
        /// </summary>
        public static string TABLE_ZZYTableName
        {
            get
            {
                return str_zt_zzytable;
            }
            set
            {
                str_zt_zzytable = value;
            }
        }

        /// <summary>
        /// 获取和设置征占用工程项目
        /// </summary>
        public static string TABLE_ZZYXMMC
        {
            get
            {
                return str_zt_zzyxmmc;
            }
            set
            {
                str_zt_zzyxmmc = value;
            }
        }
    }
}

