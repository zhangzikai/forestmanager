namespace LDZY_ZTZL
{
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Windows.Forms;

    /// <summary>
    /// 统计造林的类
    /// </summary>
    internal class ClassTongJiZL
    {
        private string anshu = "(YOU_SHI_SZ>='280' AND YOU_SHI_SZ<'308')";
        private string bajiao = "(YOU_SHI_SZ ='663')";
        private string banli = "(YOU_SHI_SZ='617')";
        private string chenglin = " (ZAO_LIN_LB ='124')";
        private string digaizaolin = "ZAO_LIN_LB='122'";
        private string fanghulin = " (LIN_ZHONG>='110' AND LIN_ZHONG<='117')";
        private string feibolinb2 = "(ZAO_LIN_LB='115') AND (Q_DI_LEI='111' OR Q_DI_LEI ='112' OR Q_DI_LEI='120' OR Q_DI_LEI='130')";
        private string feibozaolin = "ZAO_LIN_LB='115'";
        private string feigongjjzaolin = "(TDJYQ>='5')";
        private string fengshanyulin = "(ZAO_LIN_LB='116' OR ZAO_LIN_LB='119') ";
        private string fsyltgd = "(G_CHENG_LB >'30' AND G_CHENG_LB < '33')";
        private string gengxinzaolin = "(ZAO_LIN_LB='120') ";
        private string gengxinzaolin2 = "(ZAO_LIN_LB='120' OR ZAO_LIN_LB='121' OR ZAO_LIN_LB='125' OR ZAO_LIN_LB='126') ";
        private string gongyilin = "(SEN_LIN_LB>'10' AND SEN_LIN_LB<'13')";
        private string guoshu = "(YOU_SHI_SZ>='610' AND YOU_SHI_SZ<'647') AND (YOU_SHI_SZ<>'617' AND YOU_SHI_SZ<>'639')";
        private string guoyoujjzaolin = "(TDJYQ='1' OR TDJYQ='3')";
        private string haifanglin = "(G_CHENG_LB='24')";
        private string hetao = "(YOU_SHI_SZ='639')";
        private string huangshandi = " AND (Q_DI_LEI LIKE '17%')";
        private string jidisql = " (Q_DI_LEI='601' OR Q_DI_LEI ='602' OR Q_DI_LEI ='6031') ";
        private string jingjilin = " (LIN_ZHONG>='250' AND LIN_ZHONG<='255')";
        private string jitijjzaolin = "(TDJYQ='2' OR TDJYQ='4')";
        private string jjlqita = "(YOU_SHI_SZ>='660' AND YOU_SHI_SZ<'705') AND (YOU_SHI_SZ<>'661' AND YOU_SHI_SZ<>'663' AND YOU_SHI_SZ<>'681' AND YOU_SHI_SZ<>'688' AND YOU_SHI_SZ<>'691')";
        private string linguanxiazaolin = "(ZAO_LIN_LB='117')";
        private SqlCommand M_Com;
        private SqlConnection M_Con;
        private SqlDataAdapter M_Da;
        private DataSet M_Ds;
        private string ndzl = "Q_DI_LEI='910' AND DI_LEI>'960' AND DI_LEI<'964' AND ZAO_LIN_LB='140'";
        private string pingyuanlh = "(G_CHENG_LB='27')";
        private string rengongcujingengxin = "(ZAO_LIN_LB='125' OR ZAO_LIN_LB='126')";
        private string rgzl = "(ZAO_LIN_LB>='110' AND ZAO_LIN_LB<'114')";
        private string shamu = "(YOU_SHI_SZ >='120' AND YOU_SHI_SZ <'124')";
        private string songlei = "(YOU_SHI_SZ >='130' AND YOU_SHI_SZ <'133') OR (YOU_SHI_SZ >='110' AND YOU_SHI_SZ <'115') OR (YOU_SHI_SZ >='140' AND YOU_SHI_SZ <'164')";
        private string spszs = "(SSZZS>0)";
        private string ssfcycl = "(G_CHENG_LB LIKE '6%')";
        private static string str_connectionstring;
        private static string str_xzdw_table;
        private static string str_zt_zltable;
        private string sushengfcl = "LIN_ZHONG='232'";
        private string teyonglin = " (LIN_ZHONG>='120' AND LIN_ZHONG<='127')";
        private string tgdzl = "(ZAO_LIN_LB='114')";
        private string tgdzlgclb = "(G_CHENG_LB='31')";
        private string tgpthszl = "(G_CHENG_LB='32')";
        private string wulinxinfeng = "ZAO_LIN_LB='116'";
        private string xiangsi = "(YOU_SHI_SZ>='310' AND YOU_SHI_SZ<'321') OR (YOU_SHI_SZ ='331')";
        private string xintanlin = " (LIN_ZHONG ='240')";
        private string yclqita = "(YOU_SHI_SZ>='200' AND YOU_SHI_SZ<'274') OR (YOU_SHI_SZ ='330') OR (YOU_SHI_SZ>='332' AND YOU_SHI_SZ<'352')";
        private string yinxing = "(YOU_SHI_SZ='691')";
        private string yongcailin = " (LIN_ZHONG>'230' AND LIN_ZHONG<'234')";
        private string youcha = "(YOU_SHI_SZ='661')";
        private string youlindixinfeng = "(ZAO_LIN_LB='119')";
        private string youlinfuyu = " (ZAO_LIN_LB ='123')";
        private string youtong = "(YOU_SHI_SZ='688')";
        private string youzhonglin = "(LING_ZU='1' OR LING_ZU='2')";
        private string yugui = "(YOU_SHI_SZ='681')";
        private string zbghsql = "(ZAO_LIN_LB='118')";
        private string zhongcao = "(ZAO_LIN_LB='130')";
        private string zhufanglin = "(G_CHENG_LB='25')";
        private string zhulin = "(YOU_SHI_SZ>='400' AND YOU_SHI_SZ<'430')";
        private string zytzwc = "(ZJLY='71')";

        public void BindComboBox(DataTable mytable, ComboBox cbxname, string bindmember)
        {
            cbxname.BeginUpdate();
            cbxname.DataSource = mytable;
            cbxname.DisplayMember = bindmember;
            cbxname.ValueMember = bindmember;
            cbxname.EndUpdate();
        }

        private DataTable ConvertTableFldValueZeroToNull(DataTable ResultTable, int startcolnum)
        {
            for (int i = 0; i < ResultTable.Rows.Count; i++)
            {
                for (int j = startcolnum; j < ResultTable.Columns.Count; j++)
                {
                    string str = ResultTable.Rows[i][j].ToString().Trim();
                    if ((str.Length > 0) && (Convert.ToDouble(str) == 0.0))
                    {
                        ResultTable.Rows[i][j] = DBNull.Value;
                    }
                }
            }
            return ResultTable;
        }

        public DataTable ConvertTJTableDWCodeCol(DataTable ResultTable, int ConvertType)
        {
            string str = "";
            if (ConvertType == 1)
            {
                str = "  WHERE (CTYPE = '县') OR (CTYPE = '乡')";
            }
            else if (ConvertType == 2)
            {
                str = "  WHERE (PCODE > '45')";
            }
            string cmdtxt = " SELECT CCODE,CNAME FROM " + TABLE_XZDWTABLE + str;
            try
            {
                DataTable table = this.GetTable(cmdtxt, "xcdm");
                for (int i = 0; i < ResultTable.Rows.Count; i++)
                {
                    DataRow[] rowArray = table.Select("CCODE='" + ResultTable.Rows[i][0].ToString().Trim() + "'");
                    if (rowArray.Length > 0)
                    {
                        ResultTable.Rows[i][0] = rowArray[0]["CNAME"].ToString().Trim();
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("单位名称转化出错，错误：" + exception.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            return ResultTable;
        }

        private SqlConnection GetCon()
        {
            try
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
            catch (Exception)
            {
                MessageBox.Show("创建数据库连接出错！", "创建连接", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return null;
            }
        }

        private DataTable GetDataTabeBySelRows(DataTable dt, string sel)
        {
            DataTable table = dt.Clone();
            DataRow[] rowArray = dt.Select(sel);
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

        public DataTable GetTable(string cmdtxt, string tablename)
        {
            DataTable dataTable = null;
            DataTable table2;
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

        public DataTable TJB5ByXiangCun(string gxnd, string xiangcode)
        {
            int digits = 2;
            DataTable resultTable = this.TJTableB5HSHDZLMJ();
            string str = "SELECT CUN,MIAN_JI,Q_DI_LEI,LIN_ZHONG,ZAO_LIN_LB,G_CHENG_LB FROM " + TABLE_ZLDATATABLE + " WHERE LEFT(GXSJ,6)" + gxnd;
            string str2 = " AND (ZAO_LIN_LB>='110' AND ZAO_LIN_LB<'120') ";
            string str3 = " AND (XIANG='" + xiangcode + "') ";
            DataTable table = this.GetTable(str + str3 + str2 + " UNION ALL " + str + str3 + " AND " + this.zhongcao, "tjtable");
            DataTable dt = table.Clone();
            DataTable table4 = resultTable.Clone();
            table4.Clear();
            table.DefaultView.Sort = "CUN";
            DataTable table5 = table.DefaultView.ToTable(true, new string[] { "CUN" });
            foreach (DataRow row in table5.Rows)
            {
                int num17;
                dt.Clear();
                string str4 = row["CUN"].ToString();
                DataRow[] rowArray = table.Select("CUN='" + str4 + "'");
                foreach (DataRow row2 in rowArray)
                {
                    dt.Rows.Add(row2.ItemArray);
                }
                DataTable dataTabeBySelRows = this.GetDataTabeBySelRows(dt, "(ZAO_LIN_LB>='110' AND ZAO_LIN_LB<'114') " + this.huangshandi);
                DataTable table7 = this.GetDataTabeBySelRows(dt, "(ZAO_LIN_LB='114')");
                DataTable table8 = this.GetDataTabeBySelRows(dt, "(ZAO_LIN_LB='116' OR ZAO_LIN_LB='119')");
                foreach (DataRow row3 in table7.Rows)
                {
                    dataTabeBySelRows.Rows.Add(row3.ItemArray);
                }
                foreach (DataRow row4 in table8.Rows)
                {
                    dataTabeBySelRows.Rows.Add(row4.ItemArray);
                }
                if (dataTabeBySelRows.Rows.Count > 0)
                {
                    double num2 = 0.0;
                    num2 = Convert.ToDouble(dataTabeBySelRows.Compute("SUM(MIAN_JI)", null));
                    double num3 = 0.0;
                    if (dataTabeBySelRows.Select(this.tgdzlgclb).Length > 0)
                    {
                        num3 = Convert.ToDouble(dataTabeBySelRows.Compute("SUM(MIAN_JI)", this.tgdzlgclb));
                    }
                    double num4 = 0.0;
                    if (dataTabeBySelRows.Select(this.tgpthszl).Length > 0)
                    {
                        num4 = Convert.ToDouble(dataTabeBySelRows.Compute("SUM(MIAN_JI)", this.tgpthszl));
                    }
                    double num5 = num3 + num4;
                    double num6 = 0.0;
                    if (dataTabeBySelRows.Select(this.haifanglin).Length > 0)
                    {
                        num6 = Convert.ToDouble(dataTabeBySelRows.Compute("SUM(MIAN_JI)", this.haifanglin));
                    }
                    double num7 = 0.0;
                    if (dataTabeBySelRows.Select(this.haifanglin + " AND " + this.zytzwc).Length > 0)
                    {
                        num7 = Convert.ToDouble(dataTabeBySelRows.Compute("SUM(MIAN_JI)", this.haifanglin + " AND " + this.zytzwc));
                    }
                    double num8 = 0.0;
                    if (dataTabeBySelRows.Select(this.zhufanglin).Length > 0)
                    {
                        num8 = Convert.ToDouble(dataTabeBySelRows.Compute("SUM(MIAN_JI)", this.zhufanglin));
                    }
                    double num9 = 0.0;
                    if (dataTabeBySelRows.Select(this.zhufanglin + " AND " + this.zytzwc).Length > 0)
                    {
                        num9 = Convert.ToDouble(dataTabeBySelRows.Compute("SUM(MIAN_JI)", this.zhufanglin + " AND " + this.zytzwc));
                    }
                    double num10 = 0.0;
                    if (dataTabeBySelRows.Select(this.pingyuanlh).Length > 0)
                    {
                        num10 = Convert.ToDouble(dataTabeBySelRows.Compute("SUM(MIAN_JI)", this.pingyuanlh));
                    }
                    double num11 = 0.0;
                    if (dataTabeBySelRows.Select(this.pingyuanlh + " AND " + this.zytzwc).Length > 0)
                    {
                        num11 = Convert.ToDouble(dataTabeBySelRows.Compute("SUM(MIAN_JI)", this.pingyuanlh + " AND " + this.zytzwc));
                    }
                    double num12 = 0.0;
                    if (dataTabeBySelRows.Select(this.ssfcycl).Length > 0)
                    {
                        num12 = Convert.ToDouble(dataTabeBySelRows.Compute("SUM(MIAN_JI)", this.ssfcycl));
                    }
                    double num13 = 0.0;
                    if (dataTabeBySelRows.Select(this.ssfcycl + " AND " + this.zytzwc).Length > 0)
                    {
                        num13 = Convert.ToDouble(dataTabeBySelRows.Compute("SUM(MIAN_JI)", this.ssfcycl + " AND " + this.zytzwc));
                    }
                    double num14 = 0.0;
                    if (dt.Select(this.zhongcao).Length > 0)
                    {
                        num14 = Convert.ToDouble(dt.Compute("SUM(MIAN_JI)", this.zhongcao));
                    }
                    double num15 = 0.0;
                    num15 = (((num5 + num6) + num8) + num10) + num12;
                    double num16 = num2 - num15;
                    if (num2 > 0.0)
                    {
                        DataRow row5 = table4.NewRow();
                        row5["TJDW"] = str4;
                        num17 = 1;
                        while (num17 < table4.Columns.Count)
                        {
                            row5[num17] = 0;
                            num17++;
                        }
                        row5["NDZLHJ"] = Math.Round(num2, digits);
                        row5["LYZDGCHJ"] = Math.Round(num15, digits);
                        row5["TGHLGCHJ"] = Math.Round(num5, digits);
                        row5["TGDZL"] = Math.Round(num3, digits);
                        row5["TGPTHSHDZL"] = Math.Round(num4, digits);
                        row5["YHFHLGCHJ"] = Math.Round(num6, digits);
                        row5["YHFHLZYTZWCMJ"] = Math.Round(num7, digits);
                        row5["ZJLYFHLHJ"] = Math.Round(num8, digits);
                        row5["ZJLYFHLZYTZWCMJ"] = Math.Round(num9, digits);
                        row5["PYLHHJ"] = Math.Round(num10, digits);
                        row5["PYLHZYTZWWCMJ"] = Math.Round(num11, digits);
                        row5["SSFCYCLHJ"] = Math.Round(num12, digits);
                        row5["SSFCYCLZYTZWCMJ"] = Math.Round(num13, digits);
                        row5["TGHLZYCMJ"] = Math.Round(num14, digits);
                        row5["YBZLMJ"] = Math.Round(num16, digits);
                        table4.Rows.Add(row5);
                    }
                }
                if (table4.Rows.Count > 0)
                {
                    DataRow row6 = table4.NewRow();
                    row6[0] = xiangcode;
                    for (num17 = 1; num17 < table4.Columns.Count; num17++)
                    {
                        row6[num17] = Math.Round(Convert.ToDouble(table4.Compute("SUM(" + table4.Columns[num17] + ")", null)), digits);
                    }
                    table4.Rows.InsertAt(row6, 0);
                    foreach (DataRow row7 in table4.Rows)
                    {
                        resultTable.Rows.Add(row7.ItemArray);
                    }
                    resultTable = this.ConvertTableFldValueZeroToNull(resultTable, 1);
                    resultTable = this.ConvertTJTableDWCodeCol(resultTable, 2);
                }
            }
            return resultTable;
        }

        public DataTable TJB5ByXianXiang(string gxnd)
        {
            int num17;
            int digits = 2;
            DataTable resultTable = this.TJTableB5HSHDZLMJ();
            string str = "SELECT XIANG,MIAN_JI,Q_DI_LEI,LIN_ZHONG,ZAO_LIN_LB,G_CHENG_LB,ZJLY FROM " + TABLE_ZLDATATABLE + " WHERE LEFT(GXSJ,6)" + gxnd;
            string str2 = " AND (ZAO_LIN_LB>='110' AND ZAO_LIN_LB<'120') ";
            //  private string zhongcao = "(ZAO_LIN_LB='130')";
            DataTable table = this.GetTable(str + str2 + " UNION ALL " + str + " AND " + this.zhongcao, "tjtable");
            table.DefaultView.Sort = "XIANG";
            DataTable table3 = table.DefaultView.ToTable(true, new string[] { "XIANG" });
            foreach (DataRow row in table3.Rows)
            {
                string str3 = row[0].ToString();
                DataTable dt = table.Clone();
                DataRow[] rowArray = table.Select("XIANG='" + str3 + "'");
                foreach (DataRow row2 in rowArray)
                {
                    dt.Rows.Add(row2.ItemArray);
                }
                DataTable dataTabeBySelRows = this.GetDataTabeBySelRows(dt, "(ZAO_LIN_LB>='110' AND ZAO_LIN_LB<'114') " + this.huangshandi);
                DataTable table6 = this.GetDataTabeBySelRows(dt, "(ZAO_LIN_LB='114')");
                DataTable table7 = this.GetDataTabeBySelRows(dt, "(ZAO_LIN_LB='116' OR ZAO_LIN_LB='119')");
                foreach (DataRow row3 in table6.Rows)
                {
                    dataTabeBySelRows.Rows.Add(row3.ItemArray);
                }
                foreach (DataRow row4 in table7.Rows)
                {
                    dataTabeBySelRows.Rows.Add(row4.ItemArray);
                }
                if (dataTabeBySelRows.Rows.Count > 0)
                {
                    double num2 = 0.0;
                    num2 = Convert.ToDouble(dataTabeBySelRows.Compute("SUM(MIAN_JI)", null));
                    double num3 = 0.0;
                    if (dataTabeBySelRows.Select(this.tgdzlgclb).Length > 0)
                    {
                        num3 = Convert.ToDouble(dataTabeBySelRows.Compute("SUM(MIAN_JI)", this.tgdzlgclb));
                    }
                    double num4 = 0.0;
                    if (dataTabeBySelRows.Select(this.tgpthszl).Length > 0)
                    {
                        num4 = Convert.ToDouble(dataTabeBySelRows.Compute("SUM(MIAN_JI)", this.tgpthszl));
                    }
                    double num5 = num3 + num4;
                    double num6 = 0.0;
                    if (dataTabeBySelRows.Select(this.haifanglin).Length > 0)
                    {
                        num6 = Convert.ToDouble(dataTabeBySelRows.Compute("SUM(MIAN_JI)", this.haifanglin));
                    }
                    double num7 = 0.0;
                    if (dataTabeBySelRows.Select(this.haifanglin + " AND " + this.zytzwc).Length > 0)
                    {
                        num7 = Convert.ToDouble(dataTabeBySelRows.Compute("SUM(MIAN_JI)", this.haifanglin + " AND " + this.zytzwc));
                    }
                    double num8 = 0.0;
                    if (dataTabeBySelRows.Select(this.zhufanglin).Length > 0)
                    {
                        num8 = Convert.ToDouble(dataTabeBySelRows.Compute("SUM(MIAN_JI)", this.zhufanglin));
                    }
                    double num9 = 0.0;
                    if (dataTabeBySelRows.Select(this.zhufanglin + " AND " + this.zytzwc).Length > 0)
                    {
                        num9 = Convert.ToDouble(dataTabeBySelRows.Compute("SUM(MIAN_JI)", this.zhufanglin + " AND " + this.zytzwc));
                    }
                    double num10 = 0.0;
                    if (dataTabeBySelRows.Select(this.pingyuanlh).Length > 0)
                    {
                        num10 = Convert.ToDouble(dataTabeBySelRows.Compute("SUM(MIAN_JI)", this.pingyuanlh));
                    }
                    double num11 = 0.0;
                    if (dataTabeBySelRows.Select(this.pingyuanlh + " AND " + this.zytzwc).Length > 0)
                    {
                        num11 = Convert.ToDouble(dataTabeBySelRows.Compute("SUM(MIAN_JI)", this.pingyuanlh + " AND " + this.zytzwc));
                    }
                    double num12 = 0.0;
                    if (dataTabeBySelRows.Select(this.ssfcycl).Length > 0)
                    {
                        num12 = Convert.ToDouble(dataTabeBySelRows.Compute("SUM(MIAN_JI)", this.ssfcycl));
                    }
                    double num13 = 0.0;
                    if (dataTabeBySelRows.Select(this.ssfcycl + " AND " + this.zytzwc).Length > 0)
                    {
                        num13 = Convert.ToDouble(dataTabeBySelRows.Compute("SUM(MIAN_JI)", this.ssfcycl + " AND " + this.zytzwc));
                    }
                    double num14 = 0.0;
                    if (dt.Select(this.zhongcao).Length > 0)
                    {
                        num14 = Convert.ToDouble(dt.Compute("SUM(MIAN_JI)", this.zhongcao));
                    }
                    double num15 = 0.0;
                    num15 = (((num5 + num6) + num8) + num10) + num12;
                    double num16 = num2 - num15;
                    if (num2 > 0.0)
                    {
                        DataRow row5 = resultTable.NewRow();
                        row5["TJDW"] = str3;
                        num17 = 1;
                        while (num17 < resultTable.Columns.Count)
                        {
                            row5[num17] = 0;
                            num17++;
                        }
                        row5["NDZLHJ"] = Math.Round(num2, digits);
                        row5["LYZDGCHJ"] = Math.Round(num15, digits);
                        row5["TGHLGCHJ"] = Math.Round(num5, digits);
                        row5["TGDZL"] = Math.Round(num3, digits);
                        row5["TGPTHSHDZL"] = Math.Round(num4, digits);
                        row5["YHFHLGCHJ"] = Math.Round(num6, digits);
                        row5["YHFHLZYTZWCMJ"] = Math.Round(num7, digits);
                        row5["ZJLYFHLHJ"] = Math.Round(num8, digits);
                        row5["ZJLYFHLZYTZWCMJ"] = Math.Round(num9, digits);
                        row5["PYLHHJ"] = Math.Round(num10, digits);
                        row5["PYLHZYTZWWCMJ"] = Math.Round(num11, digits);
                        row5["SSFCYCLHJ"] = Math.Round(num12, digits);
                        row5["SSFCYCLZYTZWCMJ"] = Math.Round(num13, digits);
                        row5["TGHLZYCMJ"] = Math.Round(num14, digits);
                        row5["YBZLMJ"] = Math.Round(num16, digits);
                        resultTable.Rows.Add(row5);
                    }
                }
            }
            if (resultTable.Rows.Count <= 0)
            {
                return resultTable;
            }
            string str4 = resultTable.Rows[0][0].ToString().Trim().Substring(0, 6);
            DataRow row6 = resultTable.NewRow();
            row6[0] = str4;
            for (num17 = 1; num17 < resultTable.Columns.Count; num17++)
            {
                row6[num17] = Math.Round(Convert.ToDouble(resultTable.Compute("SUM(" + resultTable.Columns[num17] + ")", null)), digits);
            }
            resultTable.Rows.InsertAt(row6, 0);
            resultTable = this.ConvertTableFldValueZeroToNull(resultTable, 1);
            return this.ConvertTJTableDWCodeCol(resultTable, 1);
        }

        public DataTable TJB5ByXianXiangCun(string gxnd)
        {
            int num17;
            int digits = 2;
            DataTable resultTable = this.TJTableB5HSHDZLMJ();
            string str = "SELECT XIANG,CUN,MIAN_JI,Q_DI_LEI,LIN_ZHONG,ZAO_LIN_LB,G_CHENG_LB FROM " + TABLE_ZLDATATABLE + " WHERE LEFT(GXSJ,6)" + gxnd;
            string str2 = " AND (ZAO_LIN_LB>='110' AND ZAO_LIN_LB<'120') ";
            DataTable table = this.GetTable(str + str2 + " UNION ALL " + str + " AND " + this.zhongcao, "tjtable");
            table.DefaultView.Sort = "XIANG";
            DataTable table3 = table.DefaultView.ToTable(true, new string[] { "XIANG" });
            DataTable table4 = table.Clone();
            DataTable dt = table.Clone();
            DataTable table6 = resultTable.Clone();
            DataTable table7 = resultTable.Clone();
            foreach (DataRow row in table3.Rows)
            {
                table4.Clear();
                string str3 = row[0].ToString();
                DataRow[] rowArray = table.Select("XIANG='" + str3 + "'");
                foreach (DataRow row2 in rowArray)
                {
                    table4.Rows.Add(row2.ItemArray);
                }
                table7.Clear();
                table4.DefaultView.Sort = "CUN";
                DataTable table8 = table4.DefaultView.ToTable(true, new string[] { "CUN" });
                foreach (DataRow row3 in table8.Rows)
                {
                    dt.Clear();
                    string str4 = row3["CUN"].ToString();
                    DataRow[] rowArray2 = table4.Select("CUN='" + str4 + "'");
                    foreach (DataRow row4 in rowArray2)
                    {
                        dt.Rows.Add(row4.ItemArray);
                    }
                    DataTable dataTabeBySelRows = this.GetDataTabeBySelRows(dt, "(ZAO_LIN_LB>='110' AND ZAO_LIN_LB<'114') " + this.huangshandi);
                    DataTable table10 = this.GetDataTabeBySelRows(dt, "(ZAO_LIN_LB='114')");
                    DataTable table11 = this.GetDataTabeBySelRows(dt, "(ZAO_LIN_LB='116' OR ZAO_LIN_LB='119')");
                    foreach (DataRow row5 in table10.Rows)
                    {
                        dataTabeBySelRows.Rows.Add(row5.ItemArray);
                    }
                    foreach (DataRow row6 in table11.Rows)
                    {
                        dataTabeBySelRows.Rows.Add(row6.ItemArray);
                    }
                    if (dataTabeBySelRows.Rows.Count > 0)
                    {
                        double num2 = 0.0;
                        num2 = Convert.ToDouble(dataTabeBySelRows.Compute("SUM(MIAN_JI)", null));
                        double num3 = 0.0;
                        if (dataTabeBySelRows.Select(this.tgdzlgclb).Length > 0)
                        {
                            num3 = Convert.ToDouble(dataTabeBySelRows.Compute("SUM(MIAN_JI)", this.tgdzlgclb));
                        }
                        double num4 = 0.0;
                        if (dataTabeBySelRows.Select(this.tgpthszl).Length > 0)
                        {
                            num4 = Convert.ToDouble(dataTabeBySelRows.Compute("SUM(MIAN_JI)", this.tgpthszl));
                        }
                        double num5 = num3 + num4;
                        double num6 = 0.0;
                        if (dataTabeBySelRows.Select(this.haifanglin).Length > 0)
                        {
                            num6 = Convert.ToDouble(dataTabeBySelRows.Compute("SUM(MIAN_JI)", this.haifanglin));
                        }
                        double num7 = 0.0;
                        if (dataTabeBySelRows.Select(this.haifanglin + " AND " + this.zytzwc).Length > 0)
                        {
                            num7 = Convert.ToDouble(dataTabeBySelRows.Compute("SUM(MIAN_JI)", this.haifanglin + " AND " + this.zytzwc));
                        }
                        double num8 = 0.0;
                        if (dataTabeBySelRows.Select(this.zhufanglin).Length > 0)
                        {
                            num8 = Convert.ToDouble(dataTabeBySelRows.Compute("SUM(MIAN_JI)", this.zhufanglin));
                        }
                        double num9 = 0.0;
                        if (dataTabeBySelRows.Select(this.zhufanglin + " AND " + this.zytzwc).Length > 0)
                        {
                            num9 = Convert.ToDouble(dataTabeBySelRows.Compute("SUM(MIAN_JI)", this.zhufanglin + " AND " + this.zytzwc));
                        }
                        double num10 = 0.0;
                        if (dataTabeBySelRows.Select(this.pingyuanlh).Length > 0)
                        {
                            num10 = Convert.ToDouble(dataTabeBySelRows.Compute("SUM(MIAN_JI)", this.pingyuanlh));
                        }
                        double num11 = 0.0;
                        if (dataTabeBySelRows.Select(this.pingyuanlh + " AND " + this.zytzwc).Length > 0)
                        {
                            num11 = Convert.ToDouble(dataTabeBySelRows.Compute("SUM(MIAN_JI)", this.pingyuanlh + " AND " + this.zytzwc));
                        }
                        double num12 = 0.0;
                        if (dataTabeBySelRows.Select(this.ssfcycl).Length > 0)
                        {
                            num12 = Convert.ToDouble(dataTabeBySelRows.Compute("SUM(MIAN_JI)", this.ssfcycl));
                        }
                        double num13 = 0.0;
                        if (dataTabeBySelRows.Select(this.ssfcycl + " AND " + this.zytzwc).Length > 0)
                        {
                            num13 = Convert.ToDouble(dataTabeBySelRows.Compute("SUM(MIAN_JI)", this.ssfcycl + " AND " + this.zytzwc));
                        }
                        double num14 = 0.0;
                        if (dt.Select(this.zhongcao).Length > 0)
                        {
                            num14 = Convert.ToDouble(dt.Compute("SUM(MIAN_JI)", this.zhongcao));
                        }
                        double num15 = 0.0;
                        num15 = (((num5 + num6) + num8) + num10) + num12;
                        double num16 = num2 - num15;
                        if (num2 > 0.0)
                        {
                            DataRow row7 = table7.NewRow();
                            row7["TJDW"] = str4;
                            num17 = 1;
                            while (num17 < table7.Columns.Count)
                            {
                                row7[num17] = 0;
                                num17++;
                            }
                            row7["NDZLHJ"] = Math.Round(num2, digits);
                            row7["LYZDGCHJ"] = Math.Round(num15, digits);
                            row7["TGHLGCHJ"] = Math.Round(num5, digits);
                            row7["TGDZL"] = Math.Round(num3, digits);
                            row7["TGPTHSHDZL"] = Math.Round(num4, digits);
                            row7["YHFHLGCHJ"] = Math.Round(num6, digits);
                            row7["YHFHLZYTZWCMJ"] = Math.Round(num7, digits);
                            row7["ZJLYFHLHJ"] = Math.Round(num8, digits);
                            row7["ZJLYFHLZYTZWCMJ"] = Math.Round(num9, digits);
                            row7["PYLHHJ"] = Math.Round(num10, digits);
                            row7["PYLHZYTZWWCMJ"] = Math.Round(num11, digits);
                            row7["SSFCYCLHJ"] = Math.Round(num12, digits);
                            row7["SSFCYCLZYTZWCMJ"] = Math.Round(num13, digits);
                            row7["TGHLZYCMJ"] = Math.Round(num14, digits);
                            row7["YBZLMJ"] = Math.Round(num16, digits);
                            table7.Rows.Add(row7);
                        }
                    }
                }
                if (table7.Rows.Count > 0)
                {
                    DataRow row8 = table7.NewRow();
                    row8[0] = str3;
                    num17 = 1;
                    while (num17 < table7.Columns.Count)
                    {
                        row8[num17] = Math.Round(Convert.ToDouble(table7.Compute("SUM(" + table7.Columns[num17] + ")", null)), digits);
                        num17++;
                    }
                    table7.Rows.InsertAt(row8, 0);
                    table6.Rows.Add(row8.ItemArray);
                    foreach (DataRow row9 in table7.Rows)
                    {
                        resultTable.Rows.Add(row9.ItemArray);
                    }
                }
            }
            if (resultTable.Rows.Count <= 0)
            {
                return resultTable;
            }
            string str5 = resultTable.Rows[0][0].ToString().Trim().Substring(0, 6);
            DataRow row10 = resultTable.NewRow();
            row10[0] = str5;
            for (num17 = 1; num17 < resultTable.Columns.Count; num17++)
            {
                row10[num17] = Math.Round(Convert.ToDouble(table6.Compute("SUM(" + table6.Columns[num17] + ")", null)), digits);
            }
            resultTable.Rows.InsertAt(row10, 0);
            resultTable = this.ConvertTableFldValueZeroToNull(resultTable, 1);
            return this.ConvertTJTableDWCodeCol(resultTable, 2);
        }

        public DataTable TJB6ByXiangCun(string gxnd, string xiangcode)
        {
            int num16;
            int digits = 2;
            DataTable resultTable = this.TJTableB6NBZLMJ();
            string cmdtxt = "SELECT CUN,MIAN_JI,Q_DI_LEI,DI_LEI,LIN_ZHONG,SEN_LIN_LB,ZAO_LIN_LB,G_CHENG_LB,SSZZS FROM " + TABLE_ZLDATATABLE + " WHERE (LEFT(GXSJ,6)" + gxnd + ") AND (XIANG='" + xiangcode + "')";
            DataTable table = this.GetTable(cmdtxt, "tjtable");
            DataTable table3 = table.Clone();
            DataTable table4 = resultTable.Clone();
            table4.Clear();
            table.DefaultView.Sort = "CUN";
            DataTable table5 = table.DefaultView.ToTable(true, new string[] { "CUN" });
            foreach (DataRow row in table5.Rows)
            {
                table3.Clear();
                string str2 = row["CUN"].ToString();
                DataRow[] rowArray = table.Select("CUN='" + str2 + "'");
                foreach (DataRow row2 in rowArray)
                {
                    table3.Rows.Add(row2.ItemArray);
                }
                double num2 = 0.0;
                if (table3.Select(this.rgzl + this.huangshandi).Length > 0)
                {
                    num2 = Convert.ToDouble(table3.Compute("SUM(MIAN_JI)", this.rgzl + this.huangshandi));
                }
                double num3 = 0.0;
                if (table3.Select(this.tgdzl).Length > 0)
                {
                    num3 = Convert.ToDouble(table3.Compute("SUM(MIAN_JI)", this.tgdzl));
                }
                double num4 = 0.0;
                if (table3.Select(this.rgzl + " AND " + this.zhufanglin).Length > 0)
                {
                    num4 = Convert.ToDouble(table3.Compute("SUM(MIAN_JI)", this.rgzl + " AND " + this.zhufanglin));
                }
                double num5 = 0.0;
                if (table3.Select(this.rgzl + " AND " + this.haifanglin).Length > 0)
                {
                    num5 = Convert.ToDouble(table3.Compute("SUM(MIAN_JI)", this.rgzl + " AND " + this.haifanglin));
                }
                double num6 = 0.0;
                if (table3.Select(this.gengxinzaolin + " AND " + this.jidisql).Length > 0)
                {
                    num6 = Convert.ToDouble(table3.Compute("SUM(MIAN_JI)", this.gengxinzaolin + " AND " + this.jidisql));
                }
                double num7 = 0.0;
                if (table3.Select(this.digaizaolin).Length > 0)
                {
                    num7 = Convert.ToDouble(table3.Compute("SUM(MIAN_JI)", this.digaizaolin));
                }
                double num8 = 0.0;
                if (table3.Select(this.ndzl).Length > 0)
                {
                    num8 = Convert.ToDouble(table3.Compute("SUM(MIAN_JI)", this.ndzl));
                }
                double num9 = 0.0;
                num9 = ((num2 + num6) + num7) + num8;
                double num10 = 0.0;
                if (table3.Select(this.fengshanyulin).Length > 0)
                {
                    num10 = Convert.ToDouble(table3.Compute("SUM(MIAN_JI)", this.fengshanyulin));
                }
                DataTable table6 = table.Clone();
                DataRow[] rowArray3 = table3.Select(this.fengshanyulin);
                if (rowArray3.Length > 0)
                {
                    foreach (DataRow row3 in rowArray3)
                    {
                        table6.Rows.Add(row3.ItemArray);
                    }
                }
                double num11 = 0.0;
                double num12 = 0.0;
                if ((table6 != null) && (table6.Rows.Count > 0))
                {
                    if (table6.Select(this.zhufanglin).Length > 0)
                    {
                        num11 = Convert.ToDouble(table6.Compute("SUM(MIAN_JI)", this.zhufanglin));
                    }
                    if (table6.Select(this.fsyltgd).Length > 0)
                    {
                        num12 = Convert.ToDouble(table6.Compute("SUM(MIAN_JI)", this.fsyltgd));
                    }
                }
                double num13 = 0.0;
                if (table3.Select(this.sushengfcl).Length > 0)
                {
                    num13 = Convert.ToDouble(table3.Compute("SUM(MIAN_JI)", this.sushengfcl));
                }
                double num14 = 0.0;
                if (table3.Select(this.spszs).Length > 0)
                {
                }
                double num15 = 0.0;
                if (table3.Select(this.gongyilin).Length > 0)
                {
                }
                DataRow row4 = table4.NewRow();
                row4["TJDW"] = str2;
                num16 = 1;
                while (num16 < resultTable.Columns.Count)
                {
                    row4[num16] = 0;
                    num16++;
                }
                row4["ZZLMJ"] = Math.Round(num9, digits);
                row4["RGZLMJHJ"] = Math.Round(num2, digits);
                row4["RGZLTGMJ"] = Math.Round(num3, digits);
                row4["RGZLZFMJ"] = Math.Round(num4, digits);
                row4["RGZLHFMJ"] = Math.Round(num5, digits);
                row4["JDGXMJ"] = Math.Round(num6, digits);
                row4["DGMJ"] = Math.Round(num7, digits);
                row4["FSYLMJ"] = Math.Round(num10, digits);
                row4["FSYLZFL"] = Math.Round(num11, digits);
                row4["FSYLTG"] = Math.Round(num12, digits);
                row4["SFLMJ"] = Math.Round(num13, digits);
                row4["YWZSZS"] = num14;
                row4["STBCMJ"] = Math.Round(num15, digits);
                row4["NDZLMJ"] = Math.Round(num8, digits);
                if (num9 > 0.0)
                {
                    table4.Rows.Add(row4);
                }
            }
            if (table4.Rows.Count <= 0)
            {
                return resultTable;
            }
            DataRow row5 = table4.NewRow();
            row5[0] = xiangcode;
            for (num16 = 1; num16 < table4.Columns.Count; num16++)
            {
                row5[num16] = Math.Round(Convert.ToDouble(table4.Compute("SUM(" + table4.Columns[num16] + ")", null)), digits);
            }
            table4.Rows.InsertAt(row5, 0);
            foreach (DataRow row6 in table4.Rows)
            {
                resultTable.Rows.Add(row6.ItemArray);
            }
            resultTable = this.ConvertTableFldValueZeroToNull(resultTable, 1);
            return this.ConvertTJTableDWCodeCol(resultTable, 2);
        }

        public DataTable TJB6ByXianXiang(string gxnd)
        {
            int num16;
            int digits = 2;
            DataTable resultTable = this.TJTableB6NBZLMJ();
            string cmdtxt = "SELECT XIANG,MIAN_JI,Q_DI_LEI,DI_LEI,LIN_ZHONG,SEN_LIN_LB,ZAO_LIN_LB,G_CHENG_LB,SSZZS FROM " + TABLE_ZLDATATABLE + " WHERE LEFT(GXSJ,6)" + gxnd + " AND (XIANG>'45') ";
            DataTable table = this.GetTable(cmdtxt, "tjtable");
            table.DefaultView.Sort = "XIANG";
            DataTable table3 = table.DefaultView.ToTable(true, new string[] { "XIANG" });
            foreach (DataRow row in table3.Rows)
            {
                string str2 = row[0].ToString();
                DataTable table4 = table.Clone();
                DataRow[] rowArray = table.Select("XIANG='" + str2 + "'");
                foreach (DataRow row2 in rowArray)
                {
                    table4.Rows.Add(row2.ItemArray);
                }
                double num2 = 0.0;
                if (table4.Select(this.rgzl + this.huangshandi).Length > 0)
                {
                    num2 = Convert.ToDouble(table4.Compute("SUM(MIAN_JI)", this.rgzl + this.huangshandi));
                }
                double num3 = 0.0;
                if (table4.Select(this.tgdzl).Length > 0)
                {
                    num3 = Convert.ToDouble(table4.Compute("SUM(MIAN_JI)", this.tgdzl));
                }
                double num4 = 0.0;
                if (table4.Select(this.rgzl + " AND " + this.zhufanglin).Length > 0)
                {
                    num4 = Convert.ToDouble(table4.Compute("SUM(MIAN_JI)", this.rgzl + " AND " + this.zhufanglin));
                }
                double num5 = 0.0;
                if (table4.Select(this.rgzl + " AND " + this.haifanglin).Length > 0)
                {
                    num5 = Convert.ToDouble(table4.Compute("SUM(MIAN_JI)", this.rgzl + " AND " + this.haifanglin));
                }
                double num6 = 0.0;
                if (table4.Select(this.gengxinzaolin2 + " AND " + this.jidisql).Length > 0)
                {
                    num6 = Convert.ToDouble(table4.Compute("SUM(MIAN_JI)", this.gengxinzaolin2 + " AND " + this.jidisql));
                }
                double num7 = 0.0;
                if (table4.Select(this.digaizaolin).Length > 0)
                {
                    num7 = Convert.ToDouble(table4.Compute("SUM(MIAN_JI)", this.digaizaolin));
                }
                double num8 = 0.0;
                if (table4.Select(this.ndzl).Length > 0)
                {
                    num8 = Convert.ToDouble(table4.Compute("SUM(MIAN_JI)", this.ndzl));
                }
                double num9 = 0.0;
                num9 = ((num2 + num6) + num7) + num8;
                double num10 = 0.0;
                if (table4.Select(this.fengshanyulin).Length > 0)
                {
                    num10 = Convert.ToDouble(table4.Compute("SUM(MIAN_JI)", this.fengshanyulin));
                }
                DataTable table5 = table.Clone();
                DataRow[] rowArray3 = table4.Select(this.fengshanyulin);
                if (rowArray3.Length > 0)
                {
                    foreach (DataRow row3 in rowArray3)
                    {
                        table5.Rows.Add(row3.ItemArray);
                    }
                }
                double num11 = 0.0;
                double num12 = 0.0;
                if ((table5 != null) && (table5.Rows.Count > 0))
                {
                    if (table5.Select(this.zhufanglin).Length > 0)
                    {
                        num11 = Convert.ToDouble(table5.Compute("SUM(MIAN_JI)", this.zhufanglin));
                    }
                    if (table5.Select(this.fsyltgd).Length > 0)
                    {
                        num12 = Convert.ToDouble(table5.Compute("SUM(MIAN_JI)", this.fsyltgd));
                    }
                }
                double num13 = 0.0;
                if (table4.Select(this.sushengfcl).Length > 0)
                {
                    num13 = Convert.ToDouble(table4.Compute("SUM(MIAN_JI)", this.sushengfcl));
                }
                double num14 = 0.0;
                if (table4.Select(this.spszs).Length > 0)
                {
                }
                double num15 = 0.0;
                if (table4.Select(this.gongyilin).Length > 0)
                {
                }
                DataRow row4 = resultTable.NewRow();
                row4["TJDW"] = str2;
                num16 = 1;
                while (num16 < resultTable.Columns.Count)
                {
                    row4[num16] = 0;
                    num16++;
                }
                row4["ZZLMJ"] = Math.Round(num9, digits);
                row4["RGZLMJHJ"] = Math.Round(num2, digits);
                row4["RGZLTGMJ"] = Math.Round(num3, digits);
                row4["RGZLZFMJ"] = Math.Round(num4, digits);
                row4["RGZLHFMJ"] = Math.Round(num5, digits);
                row4["JDGXMJ"] = Math.Round(num6, digits);
                row4["DGMJ"] = Math.Round(num7, digits);
                row4["FSYLMJ"] = Math.Round(num10, digits);
                row4["FSYLZFL"] = Math.Round(num11, digits);
                row4["FSYLTG"] = Math.Round(num12, digits);
                row4["SFLMJ"] = Math.Round(num13, digits);
                row4["YWZSZS"] = num14;
                row4["STBCMJ"] = Math.Round(num15, digits);
                row4["NDZLMJ"] = Math.Round(num8, digits);
                if (num9 > 0.0)
                {
                    resultTable.Rows.Add(row4);
                }
            }
            if (resultTable.Rows.Count <= 0)
            {
                return resultTable;
            }
            string str3 = resultTable.Rows[0][0].ToString().Trim().Substring(0, 6);
            DataRow row5 = resultTable.NewRow();
            row5[0] = str3;
            for (num16 = 1; num16 < resultTable.Columns.Count; num16++)
            {
                row5[num16] = Math.Round(Convert.ToDouble(resultTable.Compute("SUM(" + resultTable.Columns[num16] + ")", null)), digits);
            }
            resultTable.Rows.InsertAt(row5, 0);
            resultTable = this.ConvertTableFldValueZeroToNull(resultTable, 1);
            return this.ConvertTJTableDWCodeCol(resultTable, 1);
        }

        public DataTable TJB6ByXianXiangCun(string gxnd)
        {
            int num16;
            int digits = 2;
            DataTable resultTable = this.TJTableB6NBZLMJ();
            string cmdtxt = "SELECT XIANG,CUN,MIAN_JI,Q_DI_LEI,DI_LEI,LIN_ZHONG,SEN_LIN_LB,ZAO_LIN_LB,G_CHENG_LB,SSZZS FROM " + TABLE_ZLDATATABLE + " WHERE LEFT(GXSJ,6)" + gxnd + " AND (XIANG>'45')";
            DataTable table = this.GetTable(cmdtxt, "tjtable");
            table.DefaultView.Sort = "XIANG";
            DataTable table3 = table.DefaultView.ToTable(true, new string[] { "XIANG" });
            DataTable table4 = table.Clone();
            DataTable table5 = table.Clone();
            DataTable table6 = resultTable.Clone();
            DataTable table7 = resultTable.Clone();
            foreach (DataRow row in table3.Rows)
            {
                table4.Clear();
                string str2 = row[0].ToString();
                DataRow[] rowArray = table.Select("XIANG='" + str2 + "'");
                foreach (DataRow row2 in rowArray)
                {
                    table4.Rows.Add(row2.ItemArray);
                }
                table7.Clear();
                table4.DefaultView.Sort = "CUN";
                DataTable table8 = table4.DefaultView.ToTable(true, new string[] { "CUN" });
                foreach (DataRow row3 in table8.Rows)
                {
                    table5.Clear();
                    string str3 = row3["CUN"].ToString();
                    DataRow[] rowArray2 = table4.Select("CUN='" + str3 + "'");
                    foreach (DataRow row4 in rowArray2)
                    {
                        table5.Rows.Add(row4.ItemArray);
                    }
                    double num2 = 0.0;
                    if (table5.Select(this.rgzl + this.huangshandi).Length > 0)
                    {
                        num2 = Convert.ToDouble(table5.Compute("SUM(MIAN_JI)", this.rgzl + this.huangshandi));
                    }
                    double num3 = 0.0;
                    if (table5.Select(this.tgdzl).Length > 0)
                    {
                        num3 = Convert.ToDouble(table5.Compute("SUM(MIAN_JI)", this.tgdzl));
                    }
                    double num4 = 0.0;
                    if (table5.Select(this.rgzl + " AND " + this.zhufanglin).Length > 0)
                    {
                        num4 = Convert.ToDouble(table5.Compute("SUM(MIAN_JI)", this.rgzl + " AND " + this.zhufanglin));
                    }
                    double num5 = 0.0;
                    if (table5.Select(this.rgzl + " AND " + this.haifanglin).Length > 0)
                    {
                        num5 = Convert.ToDouble(table5.Compute("SUM(MIAN_JI)", this.rgzl + " AND " + this.haifanglin));
                    }
                    double num6 = 0.0;
                    if (table5.Select(this.gengxinzaolin + " AND " + this.jidisql).Length > 0)
                    {
                        num6 = Convert.ToDouble(table5.Compute("SUM(MIAN_JI)", this.gengxinzaolin + " AND " + this.jidisql));
                    }
                    double num7 = 0.0;
                    if (table5.Select(this.digaizaolin).Length > 0)
                    {
                        num7 = Convert.ToDouble(table5.Compute("SUM(MIAN_JI)", this.digaizaolin));
                    }
                    double num8 = 0.0;
                    if (table5.Select(this.ndzl).Length > 0)
                    {
                        num8 = Convert.ToDouble(table5.Compute("SUM(MIAN_JI)", this.ndzl));
                    }
                    double num9 = 0.0;
                    num9 = ((num2 + num6) + num7) + num8;
                    double num10 = 0.0;
                    if (table5.Select(this.fengshanyulin).Length > 0)
                    {
                        num10 = Convert.ToDouble(table5.Compute("SUM(MIAN_JI)", this.fengshanyulin));
                    }
                    DataTable table9 = table.Clone();
                    DataRow[] rowArray4 = table5.Select(this.fengshanyulin);
                    if (rowArray4.Length > 0)
                    {
                        foreach (DataRow row5 in rowArray4)
                        {
                            table9.Rows.Add(row5.ItemArray);
                        }
                    }
                    double num11 = 0.0;
                    double num12 = 0.0;
                    if ((table9 != null) && (table9.Rows.Count > 0))
                    {
                        if (table9.Select(this.zhufanglin).Length > 0)
                        {
                            num11 = Convert.ToDouble(table9.Compute("SUM(MIAN_JI)", this.zhufanglin));
                        }
                        if (table9.Select(this.fsyltgd).Length > 0)
                        {
                            num12 = Convert.ToDouble(table9.Compute("SUM(MIAN_JI)", this.fsyltgd));
                        }
                    }
                    double num13 = 0.0;
                    if (table5.Select(this.sushengfcl).Length > 0)
                    {
                        num13 = Convert.ToDouble(table5.Compute("SUM(MIAN_JI)", this.sushengfcl));
                    }
                    double num14 = 0.0;
                    if (table4.Select(this.spszs).Length > 0)
                    {
                    }
                    double num15 = 0.0;
                    if (table5.Select(this.gongyilin).Length > 0)
                    {
                    }
                    DataRow row6 = table7.NewRow();
                    row6["TJDW"] = str3;
                    num16 = 1;
                    while (num16 < resultTable.Columns.Count)
                    {
                        row6[num16] = 0;
                        num16++;
                    }
                    row6["ZZLMJ"] = Math.Round(num9, digits);
                    row6["RGZLMJHJ"] = Math.Round(num2, digits);
                    row6["RGZLTGMJ"] = Math.Round(num3, digits);
                    row6["RGZLZFMJ"] = Math.Round(num4, digits);
                    row6["RGZLHFMJ"] = Math.Round(num5, digits);
                    row6["JDGXMJ"] = Math.Round(num6, digits);
                    row6["DGMJ"] = Math.Round(num7, digits);
                    row6["FSYLMJ"] = Math.Round(num10, digits);
                    row6["FSYLZFL"] = Math.Round(num11, digits);
                    row6["FSYLTG"] = Math.Round(num12, digits);
                    row6["SFLMJ"] = Math.Round(num13, digits);
                    row6["YWZSZS"] = num14;
                    row6["STBCMJ"] = Math.Round(num15, digits);
                    row6["NDZLMJ"] = Math.Round(num8, digits);
                    if (num9 > 0.0)
                    {
                        table7.Rows.Add(row6);
                    }
                }
                if (table7.Rows.Count > 0)
                {
                    DataRow row7 = table7.NewRow();
                    row7[0] = str2;
                    num16 = 1;
                    while (num16 < table7.Columns.Count)
                    {
                        row7[num16] = Math.Round(Convert.ToDouble(table7.Compute("SUM(" + table7.Columns[num16] + ")", null)), digits);
                        num16++;
                    }
                    table7.Rows.InsertAt(row7, 0);
                    table6.Rows.Add(row7.ItemArray);
                    foreach (DataRow row8 in table7.Rows)
                    {
                        resultTable.Rows.Add(row8.ItemArray);
                    }
                }
            }
            if (resultTable.Rows.Count <= 0)
            {
                return resultTable;
            }
            string str4 = resultTable.Rows[0][0].ToString().Trim().Substring(0, 6);
            DataRow row9 = resultTable.NewRow();
            row9[0] = str4;
            for (num16 = 1; num16 < resultTable.Columns.Count; num16++)
            {
                row9[num16] = Math.Round(Convert.ToDouble(table6.Compute("SUM(" + table6.Columns[num16] + ")", null)), digits);
            }
            resultTable.Rows.InsertAt(row9, 0);
            resultTable = this.ConvertTableFldValueZeroToNull(resultTable, 1);
            return this.ConvertTJTableDWCodeCol(resultTable, 2);
        }

        private DataSet TJFHLJDByXianXiang(string gxnd)
        {
            DataSet set = new DataSet("tjds");
            DataTable table = this.TJTableZFLZLMJ();
            DataTable table2 = this.TJTableHFLZLMJ();
            DataTable table3 = this.TJTableSMHZLMJ();
            set.Tables.Add(table);
            set.Tables.Add(table2);
            set.Tables.Add(table3);
            return set;
        }

        public DataTable TJHFLJDByXiangCun(string gxnd, string xiangcode)
        {
            int num7;
            int digits = 2;
            DataTable table = this.TJTableHFLZLMJ();
            string cmdtxt = ("SELECT XIANG,CUN,MIAN_JI,ZAO_LIN_LB,ZJLY,ZYTZJF,DFTZJF FROM " + TABLE_ZLDATATABLE + " WHERE LEFT(GXSJ,6) " + gxnd) + " AND (XIANG='" + xiangcode + "') AND LTRIM(RTRIM(G_CHENG_LB))='24'";
            DataTable table2 = this.GetTable(cmdtxt, "tjtable");
            DataTable table3 = table.Clone();
            DataTable table4 = table2.Clone();
            table2.DefaultView.Sort = "CUN";
            DataTable table5 = table2.DefaultView.ToTable(true, new string[] { "CUN" });
            table3.Clear();
            foreach (DataRow row in table5.Rows)
            {
                table4.Clear();
                DataRow[] rowArray = table2.Select("CUN='" + row["CUN"].ToString() + "'");
                foreach (DataRow row2 in rowArray)
                {
                    if (row2["ZYTZJF"] == DBNull.Value)
                    {
                        row2["ZYTZJF"] = 0;
                    }
                    if (row2["DFTZJF"] == DBNull.Value)
                    {
                        row2["DFTZJF"] = 0;
                    }
                    table4.Rows.Add(row2.ItemArray);
                }
                double num2 = 0.0;
                double num3 = 0.0;
                num2 = Convert.ToDouble(table4.Compute("SUM(ZYTZJF)", null)) / 10000.0;
                num3 = Convert.ToDouble(table4.Compute("SUM(DFTZJF)", null)) / 10000.0;
                double num4 = 0.0;
                if (table4.Select(this.rgzl).Length > 0)
                {
                    num4 = Math.Round(Convert.ToDouble(table4.Compute("SUM(MIAN_JI)", this.rgzl)), digits);
                }
                double num5 = 0.0;
                if (table4.Select(this.fengshanyulin).Length > 0)
                {
                    num5 = Math.Round(Convert.ToDouble(table4.Compute("SUM(MIAN_JI)", this.fengshanyulin)), digits);
                }
                double num6 = 0.0;
                num6 = num4 + num5;
                DataRow row3 = table3.NewRow();
                num7 = 1;
                while (num7 < table.Columns.Count)
                {
                    row3[num7] = 0;
                    num7++;
                }
                row3["TJDW"] = xiangcode;
                row3["ZYYWC"] = num2;
                row3["DFYWC"] = num3;
                row3["WCMJ"] = num6;
                row3["WCRG"] = num4;
                row3["WCFY"] = num5;
                table3.Rows.Add(row3);
            }
            if (table3.Rows.Count > 0)
            {
                DataRow row4 = table3.NewRow();
                row4[0] = xiangcode;
                for (num7 = 1; num7 < (table3.Columns.Count - 1); num7++)
                {
                    row4[num7] = Math.Round(Convert.ToDouble(table3.Compute("SUM(" + table3.Columns[num7] + ")", null)), digits);
                }
                table3.Rows.InsertAt(row4, 0);
                foreach (DataRow row5 in table3.Rows)
                {
                    table.Rows.Add(row5.ItemArray);
                }
            }
            return table;
        }

        public DataTable TJHFLJDByXianXiang(string gxnd)
        {
            int num7;
            int digits = 2;
            DataTable resultTable = this.TJTableHFLZLMJ();
            string cmdtxt = ("SELECT XIANG,MIAN_JI,ZAO_LIN_LB,ZJLY,ZYTZJF,DFTZJF FROM " + TABLE_ZLDATATABLE + " WHERE LEFT(GXSJ,6) " + gxnd) + "  AND LTRIM(RTRIM(G_CHENG_LB))='24'";
            DataTable table = this.GetTable(cmdtxt, "tjtable");
            table.DefaultView.Sort = "XIANG";
            DataTable table3 = table.DefaultView.ToTable(true, new string[] { "XIANG" });
            foreach (DataRow row in table3.Rows)
            {
                string str2 = row[0].ToString();
                DataTable table4 = table.Clone();
                DataRow[] rowArray = table.Select("XIANG='" + str2 + "'");
                foreach (DataRow row2 in rowArray)
                {
                    if (row2["ZYTZJF"] == DBNull.Value)
                    {
                        row2["ZYTZJF"] = 0;
                    }
                    if (row2["DFTZJF"] == DBNull.Value)
                    {
                        row2["DFTZJF"] = 0;
                    }
                    table4.Rows.Add(row2.ItemArray);
                }
                double num2 = 0.0;
                double num3 = 0.0;
                num2 = Convert.ToDouble(table4.Compute("SUM(ZYTZJF)", null)) / 10000.0;
                num3 = Convert.ToDouble(table4.Compute("SUM(DFTZJF)", null)) / 10000.0;
                double num4 = 0.0;
                if (table4.Select(this.rgzl).Length > 0)
                {
                    num4 = Math.Round(Convert.ToDouble(table4.Compute("SUM(MIAN_JI)", this.rgzl)), digits);
                }
                double num5 = 0.0;
                if (table4.Select(this.fengshanyulin).Length > 0)
                {
                    num5 = Math.Round(Convert.ToDouble(table4.Compute("SUM(MIAN_JI)", this.fengshanyulin)), digits);
                }
                double num6 = 0.0;
                num6 = num4 + num5;
                DataRow row3 = resultTable.NewRow();
                num7 = 1;
                while (num7 < resultTable.Columns.Count)
                {
                    row3[num7] = 0;
                    num7++;
                }
                row3["TJDW"] = str2;
                row3["ZYYWC"] = num2;
                row3["DFYWC"] = num3;
                row3["WCMJ"] = num6;
                row3["WCRG"] = num4;
                row3["WCFY"] = num5;
                resultTable.Rows.Add(row3);
            }
            if (resultTable.Rows.Count <= 0)
            {
                return resultTable;
            }
            string str3 = resultTable.Rows[0][0].ToString().Trim().Substring(0, 6);
            DataRow row4 = resultTable.NewRow();
            row4[0] = str3;
            for (num7 = 1; num7 < (resultTable.Columns.Count - 1); num7++)
            {
                row4[num7] = Math.Round(Convert.ToDouble(resultTable.Compute("SUM(" + resultTable.Columns[num7] + ")", null)), digits);
            }
            resultTable.Rows.InsertAt(row4, 0);
            resultTable = this.ConvertTableFldValueZeroToNull(resultTable, 1);
            return this.ConvertTJTableDWCodeCol(resultTable, 1);
        }

        public DataTable TJHFLJDByXianXiangCun(string gxnd)
        {
            int num7;
            int digits = 2;
            DataTable resultTable = this.TJTableHFLZLMJ();
            string cmdtxt = ("SELECT XIANG,CUN,MIAN_JI,ZAO_LIN_LB,ZJLY,ZYTZJF,DFTZJF FROM " + TABLE_ZLDATATABLE + " WHERE LEFT(GXSJ,6) " + gxnd) + "  AND LTRIM(RTRIM(G_CHENG_LB))='25'";
            DataTable table = this.GetTable(cmdtxt, "tjtable");
            table.DefaultView.Sort = "XIANG";
            DataTable table3 = table.DefaultView.ToTable(true, new string[] { "XIANG" });
            DataTable table4 = resultTable.Clone();
            DataTable table5 = resultTable.Clone();
            foreach (DataRow row in table3.Rows)
            {
                string str2 = row[0].ToString();
                DataTable table6 = table.Clone();
                DataRow[] rowArray = table.Select("XIANG='" + str2 + "'");
                foreach (DataRow row2 in rowArray)
                {
                    if (row2["ZYTZJF"] == DBNull.Value)
                    {
                        row2["ZYTZJF"] = 0;
                    }
                    if (row2["DFTZJF"] == DBNull.Value)
                    {
                        row2["DFTZJF"] = 0;
                    }
                    table6.Rows.Add(row2.ItemArray);
                }
                DataTable table7 = table.Clone();
                table6.DefaultView.Sort = "CUN";
                DataTable table8 = table6.DefaultView.ToTable(true, new string[] { "CUN" });
                table5.Clear();
                foreach (DataRow row3 in table8.Rows)
                {
                    table7.Clear();
                    DataRow[] rowArray2 = table6.Select("CUN='" + row3["CUN"].ToString() + "'");
                    foreach (DataRow row4 in rowArray2)
                    {
                        table7.Rows.Add(row4.ItemArray);
                    }
                    double num2 = 0.0;
                    double num3 = 0.0;
                    num2 = Convert.ToDouble(table7.Compute("SUM(ZYTZJF)", null)) / 10000.0;
                    num3 = Convert.ToDouble(table7.Compute("SUM(DFTZJF)", null)) / 10000.0;
                    double num4 = 0.0;
                    if (table7.Select(this.rgzl).Length > 0)
                    {
                        num4 = Math.Round(Convert.ToDouble(table7.Compute("SUM(MIAN_JI)", this.rgzl)), digits);
                    }
                    double num5 = 0.0;
                    if (table7.Select(this.fengshanyulin).Length > 0)
                    {
                        num5 = Math.Round(Convert.ToDouble(table7.Compute("SUM(MIAN_JI)", this.fengshanyulin)), digits);
                    }
                    double num6 = 0.0;
                    num6 = num4 + num5;
                    DataRow row5 = table5.NewRow();
                    num7 = 1;
                    while (num7 < resultTable.Columns.Count)
                    {
                        row5[num7] = 0;
                        num7++;
                    }
                    row5["TJDW"] = str2;
                    row5["ZYYWC"] = num2;
                    row5["DFYWC"] = num3;
                    row5["WCMJ"] = num6;
                    row5["WCRG"] = num4;
                    row5["WCFY"] = num5;
                    table5.Rows.Add(row5);
                }
                if (table5.Rows.Count > 0)
                {
                    DataRow row6 = table5.NewRow();
                    row6[0] = str2;
                    num7 = 1;
                    while (num7 < (table5.Columns.Count - 1))
                    {
                        row6[num7] = Math.Round(Convert.ToDouble(table5.Compute("SUM(" + table5.Columns[num7] + ")", null)), digits);
                        num7++;
                    }
                    table5.Rows.InsertAt(row6, 0);
                    table4.Rows.Add(row6.ItemArray);
                    foreach (DataRow row7 in table5.Rows)
                    {
                        resultTable.Rows.Add(row7.ItemArray);
                    }
                }
            }
            if (resultTable.Rows.Count <= 0)
            {
                return resultTable;
            }
            string str4 = resultTable.Rows[0][0].ToString().Trim().Substring(0, 6);
            DataRow row8 = resultTable.NewRow();
            row8[0] = str4;
            for (num7 = 1; num7 < (resultTable.Columns.Count - 1); num7++)
            {
                row8[num7] = Math.Round(Convert.ToDouble(table4.Compute("SUM(" + table4.Columns[num7] + ")", null)), digits);
            }
            resultTable.Rows.InsertAt(row8, 0);
            resultTable = this.ConvertTableFldValueZeroToNull(resultTable, 1);
            return this.ConvertTJTableDWCodeCol(resultTable, 1);
        }

        public DataTable TJKYSCQK1ByXiangCun(string gxnd, string xiangcode)
        {
            int digits = 2;
            DataTable resultTable = this.TJTableKYSCQK1();
            string cmdtxt = ("SELECT XIANG,CUN,LD_QS,TDJYQ,LMSYQ,Q_DI_LEI,MIAN_JI,LIN_ZHONG,YOU_SHI_SZ,ZAO_LIN_LB FROM " + TABLE_ZLDATATABLE + " WHERE LEFT(GXSJ,6)" + gxnd) + " AND (XIANG='" + xiangcode + "')  AND (ZAO_LIN_LB>='110' AND ZAO_LIN_LB<'117')";
            DataTable table = this.GetTable(cmdtxt, "tjtable");
            DataTable dt = table.Clone();
            DataTable table4 = resultTable.Clone();
            table.DefaultView.Sort = "CUN";
            DataTable table5 = table.DefaultView.ToTable(true, new string[] { "CUN" });
            foreach (DataRow row in table5.Rows)
            {
                dt.Clear();
                string str2 = row["CUN"].ToString();
                DataRow[] rowArray = table.Select("CUN='" + str2 + "'");
                foreach (DataRow row2 in rowArray)
                {
                    dt.Rows.Add(row2.ItemArray);
                }
                double num2 = 0.0;
                if (dt.Select(this.rgzl).Length > 0)
                {
                    num2 = Convert.ToDouble(dt.Compute("SUM(MIAN_JI)", this.rgzl));
                }
                double num3 = 0.0;
                if (dt.Select(this.tgdzl).Length > 0)
                {
                    num3 = Convert.ToDouble(dt.Compute("SUM(MIAN_JI)", this.tgdzl));
                }
                double num4 = 0.0;
                if (dt.Select(this.zhulin).Length > 0)
                {
                    num4 = Convert.ToDouble(dt.Compute("SUM(MIAN_JI)", this.zhulin + this.huangshandi));
                }
                double num5 = 0.0;
                if (dt.Select(this.feibozaolin).Length > 0)
                {
                    num5 = Convert.ToDouble(dt.Compute("SUM(MIAN_JI)", this.feibozaolin + this.huangshandi));
                }
                double num6 = 0.0;
                if (dt.Select(this.wulinxinfeng).Length > 0)
                {
                    num6 = Convert.ToDouble(dt.Compute("SUM(MIAN_JI)", this.wulinxinfeng));
                }
                double num7 = 0.0;
                if (dt.Select(this.guoyoujjzaolin + this.huangshandi).Length > 0)
                {
                    num7 = Convert.ToDouble(dt.Compute("SUM(MIAN_JI)", this.guoyoujjzaolin + this.huangshandi));
                }
                double num8 = 0.0;
                if (dt.Select(this.jitijjzaolin + this.huangshandi).Length > 0)
                {
                    num8 = Convert.ToDouble(dt.Compute("SUM(MIAN_JI)", this.jitijjzaolin + this.huangshandi));
                }
                double num9 = num7 + num8;
                double num10 = 0.0;
                if (dt.Select(this.feigongjjzaolin + this.huangshandi).Length > 0)
                {
                    num10 = Convert.ToDouble(dt.Compute("SUM(MIAN_JI)", this.feigongjjzaolin + this.huangshandi));
                }
                double num11 = 0.0;
                num11 = num9 + num10;
                double num12 = 0.0;
                double num13 = 0.0;
                double num14 = 0.0;
                double num15 = 0.0;
                double num16 = 0.0;
                double num17 = 0.0;
                double num18 = 0.0;
                DataTable dataTabeBySelRows = this.GetDataTabeBySelRows(dt, this.yongcailin);
                if (dataTabeBySelRows.Rows.Count > 0)
                {
                    if (dataTabeBySelRows.Select(this.shamu + this.huangshandi).Length > 0)
                    {
                        num12 = Convert.ToDouble(dataTabeBySelRows.Compute("SUM(MIAN_JI)", this.shamu + this.huangshandi));
                    }
                    if (dataTabeBySelRows.Select(this.songlei + this.huangshandi).Length > 0)
                    {
                        num13 = Convert.ToDouble(dataTabeBySelRows.Compute("SUM(MIAN_JI)", this.songlei + this.huangshandi));
                    }
                    if (dataTabeBySelRows.Select(this.anshu + this.huangshandi).Length > 0)
                    {
                        num14 = Convert.ToDouble(dataTabeBySelRows.Compute("SUM(MIAN_JI)", this.anshu + this.huangshandi));
                    }
                    if (dataTabeBySelRows.Select(this.xiangsi + this.huangshandi).Length > 0)
                    {
                        num15 = Convert.ToDouble(dataTabeBySelRows.Compute("SUM(MIAN_JI)", this.xiangsi + this.huangshandi));
                    }
                    if (dataTabeBySelRows.Select(this.yclqita + this.huangshandi).Length > 0)
                    {
                        num16 = Convert.ToDouble(dataTabeBySelRows.Compute("SUM(MIAN_JI)", this.yclqita + this.huangshandi));
                    }
                    if (dataTabeBySelRows.Select(this.sushengfcl + this.huangshandi).Length > 0)
                    {
                        num17 = Convert.ToDouble(dataTabeBySelRows.Compute("SUM(MIAN_JI)", this.sushengfcl + this.huangshandi));
                    }
                    num18 = (((num12 + num13) + num14) + num15) + num16;
                }
                double num19 = 0.0;
                double num20 = 0.0;
                double num21 = 0.0;
                double num22 = 0.0;
                double num23 = 0.0;
                double num24 = 0.0;
                double num25 = 0.0;
                double num26 = 0.0;
                double num27 = 0.0;
                double num28 = 0.0;
                DataTable table7 = this.GetDataTabeBySelRows(dt, this.jingjilin);
                if (table7.Rows.Count > 0)
                {
                    if (table7.Select(this.youcha + this.huangshandi).Length > 0)
                    {
                        num19 = Convert.ToDouble(table7.Compute("SUM(MIAN_JI)", this.youcha + this.huangshandi));
                    }
                    if (table7.Select(this.youtong + this.huangshandi).Length > 0)
                    {
                        num20 = Convert.ToDouble(table7.Compute("SUM(MIAN_JI)", this.youtong + this.huangshandi));
                    }
                    if (table7.Select(this.bajiao + this.huangshandi).Length > 0)
                    {
                        num21 = Convert.ToDouble(table7.Compute("SUM(MIAN_JI)", this.bajiao + this.huangshandi));
                    }
                    if (table7.Select(this.yugui + this.huangshandi).Length > 0)
                    {
                        num22 = Convert.ToDouble(table7.Compute("SUM(MIAN_JI)", this.yugui + this.huangshandi));
                    }
                    if (table7.Select(this.hetao + this.huangshandi).Length > 0)
                    {
                        num23 = Convert.ToDouble(table7.Compute("SUM(MIAN_JI)", this.hetao + this.huangshandi));
                    }
                    if (table7.Select(this.banli + this.huangshandi).Length > 0)
                    {
                        num24 = Convert.ToDouble(table7.Compute("SUM(MIAN_JI)", this.banli + this.huangshandi));
                    }
                    if (table7.Select(this.yinxing + this.huangshandi).Length > 0)
                    {
                        num25 = Convert.ToDouble(table7.Compute("SUM(MIAN_JI)", this.yinxing + this.huangshandi));
                    }
                    if (table7.Select(this.guoshu + this.huangshandi).Length > 0)
                    {
                        num26 = Convert.ToDouble(table7.Compute("SUM(MIAN_JI)", this.guoshu + this.huangshandi));
                    }
                    if (table7.Select(this.jjlqita + this.huangshandi).Length > 0)
                    {
                        num27 = Convert.ToDouble(table7.Compute("SUM(MIAN_JI)", this.jjlqita + this.huangshandi));
                    }
                    num28 = (((((((num19 + num20) + num21) + num22) + num23) + num24) + num25) + num26) + num27;
                }
                double num29 = 0.0;
                if (dt.Select(this.fanghulin + this.huangshandi).Length > 0)
                {
                    num29 = Convert.ToDouble(dt.Compute("SUM(MIAN_JI)", this.fanghulin + this.huangshandi));
                }
                double num30 = 0.0;
                if (dt.Select(this.xintanlin + this.huangshandi).Length > 0)
                {
                    num30 = Convert.ToDouble(dt.Compute("SUM(MIAN_JI)", this.xintanlin + this.huangshandi));
                }
                double num31 = 0.0;
                if (dt.Select(this.teyonglin + this.huangshandi).Length > 0)
                {
                    num31 = Convert.ToDouble(dt.Compute("SUM(MIAN_JI)", this.teyonglin + this.huangshandi));
                }
                if (num11 > 0.0)
                {
                    DataRow row3 = table4.NewRow();
                    row3["TJDW"] = str2;
                    row3["HSZLZJ"] = Math.Round(num11, digits);
                    row3["RGZLZJ"] = Math.Round(num2, digits);
                    row3["TGDZL"] = Math.Round(num3, digits);
                    row3["ZLMJ"] = Math.Round(num4, digits);
                    row3["FBZL"] = Math.Round(num5, digits);
                    row3["WLDSLDXF"] = Math.Round(num6, digits);
                    row3["GYJJZLZJ"] = Math.Round(num9, digits);
                    row3["GYJJZL"] = Math.Round(num7, digits);
                    row3["JTJJZL"] = Math.Round(num8, digits);
                    row3["FGYJJZL"] = Math.Round(num10, digits);
                    row3["YCLZJ"] = Math.Round(num18, digits);
                    row3["ShaMu"] = Math.Round(num12, digits);
                    row3["SongShu"] = Math.Round(num13, digits);
                    row3["AnShu"] = Math.Round(num14, digits);
                    row3["XiangSi"] = Math.Round(num15, digits);
                    row3["YCLQT"] = Math.Round(num16, digits);
                    row3["SSFCL"] = Math.Round(num17, digits);
                    row3["JJLZJ"] = Math.Round(num28, digits);
                    row3["YouCha"] = Math.Round(num19, digits);
                    row3["YouTong"] = Math.Round(num20, digits);
                    row3["BaJiao"] = Math.Round(num21, digits);
                    row3["YuGui"] = Math.Round(num22, digits);
                    row3["HeTao"] = Math.Round(num23, digits);
                    row3["BanLi"] = Math.Round(num24, digits);
                    row3["YinXing"] = Math.Round(num25, digits);
                    row3["GuoShu"] = Math.Round(num26, digits);
                    row3["JJLQT"] = Math.Round(num27, digits);
                    row3["FHLMJ"] = Math.Round(num29, digits);
                    row3["XTLMJ"] = Math.Round(num30, digits);
                    row3["TZYTLMJ"] = Math.Round(num31, digits);
                    table4.Rows.Add(row3);
                }
            }
            if (table4.Rows.Count <= 0)
            {
                return resultTable;
            }
            DataRow row4 = table4.NewRow();
            row4[0] = xiangcode;
            for (int i = 1; i < table4.Columns.Count; i++)
            {
                row4[i] = Math.Round(Convert.ToDouble(table4.Compute("SUM(" + table4.Columns[i] + ")", null)), digits);
            }
            table4.Rows.InsertAt(row4, 0);
            foreach (DataRow row5 in table4.Rows)
            {
                resultTable.Rows.Add(row5.ItemArray);
            }
            resultTable = this.ConvertTableFldValueZeroToNull(resultTable, 1);
            return this.ConvertTJTableDWCodeCol(resultTable, 2);
        }
        /// <summary>
        /// 通过县乡统计生产情况表1
        /// </summary>
        /// <param name="gxnd"></param>
        /// <returns></returns>
        public DataTable TJKYSCQK1ByXianXiang(string gxnd)
        {
            int digits = 2;
            DataTable resultTable = this.TJTableKYSCQK1();
            string cmdtxt = ("SELECT XIANG,LD_QS,TDJYQ,LMSYQ,Q_DI_LEI,MIAN_JI,LIN_ZHONG,YOU_SHI_SZ,ZAO_LIN_LB FROM " + TABLE_ZLDATATABLE + " WHERE LEFT(GXSJ,6) " + gxnd) + "  AND (ZAO_LIN_LB>='110' AND ZAO_LIN_LB<'117')";
            DataTable table = this.GetTable(cmdtxt, "tjtable");
            table.DefaultView.Sort = "XIANG";
            DataTable table3 = table.DefaultView.ToTable(true, new string[] { "XIANG" });
            foreach (DataRow row in table3.Rows)
            {
                string str2 = row[0].ToString();
                DataTable dt = table.Clone();
                DataRow[] rowArray = table.Select("XIANG='" + str2 + "'");
                foreach (DataRow row2 in rowArray)
                {
                    dt.Rows.Add(row2.ItemArray);
                }
                double num2 = 0.0;
                if (dt.Select(this.rgzl + this.huangshandi).Length > 0)
                {
                    num2 = Math.Round(Convert.ToDouble(dt.Compute("SUM(MIAN_JI)", this.rgzl + this.huangshandi)), 2);
                }
                double num3 = 0.0;
                if (dt.Select(this.tgdzl + this.huangshandi).Length > 0)
                {
                    num3 = Math.Round(Convert.ToDouble(dt.Compute("SUM(MIAN_JI)", this.tgdzl + this.huangshandi)), 2);
                }
                double num4 = 0.0;
                if (dt.Select(this.zhulin + this.huangshandi).Length > 0)
                {
                    num4 = Math.Round(Convert.ToDouble(dt.Compute("SUM(MIAN_JI)", this.zhulin + this.huangshandi)), 2);
                }
                double num5 = 0.0;
                if (dt.Select(this.feibozaolin + this.huangshandi).Length > 0)
                {
                    num5 = Math.Round(Convert.ToDouble(dt.Compute("SUM(MIAN_JI)", this.feibozaolin + this.huangshandi)), 2);
                }
                double num6 = 0.0;
                if (dt.Select(this.wulinxinfeng).Length > 0)
                {
                    num6 = Math.Round(Convert.ToDouble(dt.Compute("SUM(MIAN_JI)", this.wulinxinfeng)), 2);
                }
                double num7 = 0.0;
                if (dt.Select(this.guoyoujjzaolin + this.huangshandi).Length > 0)
                {
                    num7 = Convert.ToDouble(dt.Compute("SUM(MIAN_JI)", this.guoyoujjzaolin + this.huangshandi));
                }
                double num8 = 0.0;
                if (dt.Select(this.jitijjzaolin + this.huangshandi).Length > 0)
                {
                    num8 = Convert.ToDouble(dt.Compute("SUM(MIAN_JI)", this.jitijjzaolin + this.huangshandi));
                }
                double num9 = num7 + num8;
                double num10 = 0.0;
                if (dt.Select(this.feigongjjzaolin + this.huangshandi).Length > 0)
                {
                    num10 = Convert.ToDouble(dt.Compute("SUM(MIAN_JI)", this.feigongjjzaolin + this.huangshandi));
                }
                double num11 = 0.0;
                num11 = num9 + num10;
                double num12 = 0.0;
                double num13 = 0.0;
                double num14 = 0.0;
                double num15 = 0.0;
                double num16 = 0.0;
                double num17 = 0.0;
                double num18 = 0.0;
                DataTable dataTabeBySelRows = this.GetDataTabeBySelRows(dt, this.yongcailin);
                if (dataTabeBySelRows.Rows.Count > 0)
                {
                    if (dataTabeBySelRows.Select(this.shamu + this.huangshandi).Length > 0)
                    {
                        num12 = Convert.ToDouble(dataTabeBySelRows.Compute("SUM(MIAN_JI)", this.shamu + this.huangshandi));
                    }
                    if (dataTabeBySelRows.Select(this.yongcailin + " AND " + this.songlei + this.huangshandi).Length > 0)
                    {
                        num13 = Convert.ToDouble(dataTabeBySelRows.Compute("SUM(MIAN_JI)", this.songlei + this.huangshandi));
                    }
                    if (dataTabeBySelRows.Select(this.yongcailin + " AND " + this.anshu + this.huangshandi).Length > 0)
                    {
                        num14 = Convert.ToDouble(dataTabeBySelRows.Compute("SUM(MIAN_JI)", this.anshu + this.huangshandi));
                    }
                    if (dataTabeBySelRows.Select(this.yongcailin + " AND " + this.xiangsi + this.huangshandi).Length > 0)
                    {
                        num15 = Convert.ToDouble(dataTabeBySelRows.Compute("SUM(MIAN_JI)", this.xiangsi + this.huangshandi));
                    }
                    if (dataTabeBySelRows.Select(this.yongcailin + " AND " + this.yclqita + this.huangshandi).Length > 0)
                    {
                        num16 = Convert.ToDouble(dataTabeBySelRows.Compute("SUM(MIAN_JI)", this.yclqita + this.huangshandi));
                    }
                    if (dataTabeBySelRows.Select(this.sushengfcl + this.huangshandi).Length > 0)
                    {
                        num17 = Convert.ToDouble(dataTabeBySelRows.Compute("SUM(MIAN_JI)", this.sushengfcl + this.huangshandi));
                    }
                    num18 = (((num12 + num13) + num14) + num15) + num16;
                }
                double num19 = 0.0;
                double num20 = 0.0;
                double num21 = 0.0;
                double num22 = 0.0;
                double num23 = 0.0;
                double num24 = 0.0;
                double num25 = 0.0;
                double num26 = 0.0;
                double num27 = 0.0;
                double num28 = 0.0;
                DataTable table6 = this.GetDataTabeBySelRows(dt, this.jingjilin);
                if (table6.Rows.Count > 0)
                {
                    if (table6.Select(this.youcha + this.huangshandi).Length > 0)
                    {
                        num19 = Convert.ToDouble(table6.Compute("SUM(MIAN_JI)", this.youcha + this.huangshandi));
                    }
                    if (table6.Select(this.youtong + this.huangshandi).Length > 0)
                    {
                        num20 = Convert.ToDouble(table6.Compute("SUM(MIAN_JI)", this.youtong + this.huangshandi));
                    }
                    if (table6.Select(this.bajiao + this.huangshandi).Length > 0)
                    {
                        num21 = Convert.ToDouble(table6.Compute("SUM(MIAN_JI)", this.bajiao + this.huangshandi));
                    }
                    if (table6.Select(this.yugui + this.huangshandi).Length > 0)
                    {
                        num22 = Convert.ToDouble(table6.Compute("SUM(MIAN_JI)", this.yugui + this.huangshandi));
                    }
                    if (table6.Select(this.hetao + this.huangshandi).Length > 0)
                    {
                        num23 = Convert.ToDouble(table6.Compute("SUM(MIAN_JI)", this.hetao + this.huangshandi));
                    }
                    if (table6.Select(this.banli + this.huangshandi).Length > 0)
                    {
                        num24 = Convert.ToDouble(table6.Compute("SUM(MIAN_JI)", this.banli + this.huangshandi));
                    }
                    if (table6.Select(this.yinxing + this.huangshandi).Length > 0)
                    {
                        num25 = Convert.ToDouble(table6.Compute("SUM(MIAN_JI)", this.yinxing + this.huangshandi));
                    }
                    if (table6.Select(this.guoshu + this.huangshandi).Length > 0)
                    {
                        num26 = Convert.ToDouble(table6.Compute("SUM(MIAN_JI)", this.guoshu + this.huangshandi));
                    }
                    if (table6.Select(this.jjlqita + this.huangshandi).Length > 0)
                    {
                        num27 = Convert.ToDouble(table6.Compute("SUM(MIAN_JI)", this.jjlqita + this.huangshandi));
                    }
                    num28 = (((((((num19 + num20) + num21) + num22) + num23) + num24) + num25) + num26) + num27;
                }
                double num29 = 0.0;
                if (dt.Select(this.fanghulin + this.huangshandi).Length > 0)
                {
                    num29 = Convert.ToDouble(dt.Compute("SUM(MIAN_JI)", this.fanghulin + this.huangshandi));
                }
                double num30 = 0.0;
                if (dt.Select(this.xintanlin + this.huangshandi).Length > 0)
                {
                    num30 = Convert.ToDouble(dt.Compute("SUM(MIAN_JI)", this.xintanlin + this.huangshandi));
                }
                double num31 = 0.0;
                if (dt.Select(this.teyonglin + this.huangshandi).Length > 0)
                {
                    num31 = Convert.ToDouble(dt.Compute("SUM(MIAN_JI)", this.teyonglin + this.huangshandi));
                }
                if (num11 > 0.0)
                {
                    DataRow row3 = resultTable.NewRow();
                    row3["TJDW"] = str2;
                    row3["HSZLZJ"] = Math.Round(num11, digits);
                    row3["RGZLZJ"] = Math.Round(num2, digits);
                    row3["TGDZL"] = Math.Round(num3, digits);
                    row3["ZLMJ"] = Math.Round(num4, digits);
                    row3["FBZL"] = Math.Round(num5, digits);
                    row3["WLDSLDXF"] = Math.Round(num6, digits);
                    row3["GYJJZLZJ"] = Math.Round(num9, digits);
                    row3["GYJJZL"] = Math.Round(num7, digits);
                    row3["JTJJZL"] = Math.Round(num8, digits);
                    row3["FGYJJZL"] = Math.Round(num10, digits);
                    row3["YCLZJ"] = Math.Round(num18, digits);
                    row3["ShaMu"] = Math.Round(num12, digits);
                    row3["SongShu"] = Math.Round(num13, digits);
                    row3["AnShu"] = Math.Round(num14, digits);
                    row3["XiangSi"] = Math.Round(num15, digits);
                    row3["YCLQT"] = Math.Round(num16, digits);
                    row3["SSFCL"] = Math.Round(num17, digits);
                    row3["JJLZJ"] = Math.Round(num28, digits);
                    row3["YouCha"] = Math.Round(num19, digits);
                    row3["YouTong"] = Math.Round(num20, digits);
                    row3["BaJiao"] = Math.Round(num21, digits);
                    row3["YuGui"] = Math.Round(num22, digits);
                    row3["HeTao"] = Math.Round(num23, digits);
                    row3["BanLi"] = Math.Round(num24, digits);
                    row3["YinXing"] = Math.Round(num25, digits);
                    row3["GuoShu"] = Math.Round(num26, digits);
                    row3["JJLQT"] = Math.Round(num27, digits);
                    row3["FHLMJ"] = Math.Round(num29, digits);
                    row3["XTLMJ"] = Math.Round(num30, digits);
                    row3["TZYTLMJ"] = Math.Round(num31, digits);
                    resultTable.Rows.Add(row3);
                }
            }
            if (resultTable.Rows.Count <= 0)
            {
                return resultTable;
            }
            string str3 = resultTable.Rows[0][0].ToString().Trim().Substring(0, 6);
            DataRow row4 = resultTable.NewRow();
            row4[0] = str3;
            for (int i = 1; i < resultTable.Columns.Count; i++)
            {
                row4[i] = Math.Round(Convert.ToDouble(resultTable.Compute("SUM(" + resultTable.Columns[i] + ")", null)), digits);
            }
            resultTable.Rows.InsertAt(row4, 0);
            resultTable = this.ConvertTableFldValueZeroToNull(resultTable, digits);
            return this.ConvertTJTableDWCodeCol(resultTable, digits);
        }

        public DataTable TJKYSCQK1ByXianXiangCun(string gxnd)
        {
            int num32;
            int digits = 2;
            DataTable resultTable = this.TJTableKYSCQK1();
            string cmdtxt = ("SELECT XIANG,CUN,LD_QS,TDJYQ,LMSYQ,Q_DI_LEI,MIAN_JI,LIN_ZHONG,YOU_SHI_SZ,ZAO_LIN_LB FROM " + TABLE_ZLDATATABLE + " WHERE LEFT(GXSJ,6)" + gxnd) + " AND (ZAO_LIN_LB>='110' AND ZAO_LIN_LB<'117')";
                             
            DataTable table = this.GetTable(cmdtxt, "tjtable");
            DataTable table3 = table.Clone();
            DataTable dt = table.Clone();
            table.DefaultView.Sort = "XIANG";
            DataTable table5 = table.DefaultView.ToTable(true, new string[] { "XIANG" });
            DataTable table6 = resultTable.Clone();
            DataTable table7 = resultTable.Clone();
            foreach (DataRow row in table5.Rows)
            {
                table3.Clear();
                string str2 = row[0].ToString();
                DataRow[] rowArray = table.Select("XIANG='" + str2 + "'");
                foreach (DataRow row2 in rowArray)
                {
                    table3.Rows.Add(row2.ItemArray);
                }
                table7.Clear();
                table3.DefaultView.Sort = "CUN";
                DataTable table8 = table3.DefaultView.ToTable(true, new string[] { "CUN" });
                foreach (DataRow row3 in table8.Rows)
                {
                    dt.Clear();
                    string str3 = row3["CUN"].ToString();
                    DataRow[] rowArray2 = table3.Select("CUN='" + str3 + "'");
                    foreach (DataRow row4 in rowArray2)
                    {
                        dt.Rows.Add(row4.ItemArray);
                    }
                    double num2 = 0.0;
                    if (dt.Select(this.rgzl + this.huangshandi).Length > 0)
                    {
                        num2 = Convert.ToDouble(dt.Compute("SUM(MIAN_JI)", this.rgzl + this.huangshandi));
                    }
                    double num3 = 0.0;
                    if (dt.Select(this.tgdzl + this.huangshandi).Length > 0)
                    {
                        num3 = Convert.ToDouble(dt.Compute("SUM(MIAN_JI)", this.tgdzl + this.huangshandi));
                    }
                    double num4 = 0.0;
                    if (dt.Select(this.zhulin + this.huangshandi).Length > 0)
                    {
                        num4 = Convert.ToDouble(dt.Compute("SUM(MIAN_JI)", this.zhulin + this.huangshandi));
                    }
                    double num5 = 0.0;
                    if (dt.Select(this.feibozaolin + this.huangshandi).Length > 0)
                    {
                        num5 = Convert.ToDouble(dt.Compute("SUM(MIAN_JI)", this.feibozaolin + this.huangshandi));
                    }
                    double num6 = 0.0;
                    if (dt.Select(this.wulinxinfeng).Length > 0)
                    {
                        num6 = Convert.ToDouble(dt.Compute("SUM(MIAN_JI)", this.wulinxinfeng));
                    }
                    double num7 = 0.0;
                    if (dt.Select(this.guoyoujjzaolin + this.huangshandi).Length > 0)
                    {
                        num7 = Convert.ToDouble(dt.Compute("SUM(MIAN_JI)", this.guoyoujjzaolin + this.huangshandi));
                    }
                    double num8 = 0.0;
                    if (dt.Select(this.jitijjzaolin + this.huangshandi).Length > 0)
                    {
                        num8 = Convert.ToDouble(dt.Compute("SUM(MIAN_JI)", this.jitijjzaolin + this.huangshandi));
                    }
                    double num9 = num7 + num8;
                    double num10 = 0.0;
                    if (dt.Select(this.feigongjjzaolin + this.huangshandi).Length > 0)
                    {
                        num10 = Convert.ToDouble(dt.Compute("SUM(MIAN_JI)", this.feigongjjzaolin + this.huangshandi));
                    }
                    double num11 = 0.0;
                    num11 = num9 + num10;
                    double num12 = 0.0;
                    double num13 = 0.0;
                    double num14 = 0.0;
                    double num15 = 0.0;
                    double num16 = 0.0;
                    double num17 = 0.0;
                    double num18 = 0.0;
                    DataTable dataTabeBySelRows = this.GetDataTabeBySelRows(dt, this.yongcailin);
                    if (dataTabeBySelRows.Rows.Count > 0)
                    {
                        if (dataTabeBySelRows.Select(this.shamu + this.huangshandi).Length > 0)
                        {
                            num12 = Convert.ToDouble(dataTabeBySelRows.Compute("SUM(MIAN_JI)", this.shamu + this.huangshandi));
                        }
                        if (dataTabeBySelRows.Select(this.songlei + this.huangshandi).Length > 0)
                        {
                            num13 = Convert.ToDouble(dataTabeBySelRows.Compute("SUM(MIAN_JI)", this.songlei + this.huangshandi));
                        }
                        if (dataTabeBySelRows.Select(this.anshu + this.huangshandi).Length > 0)
                        {
                            num14 = Convert.ToDouble(dataTabeBySelRows.Compute("SUM(MIAN_JI)", this.anshu + this.huangshandi));
                        }
                        if (dataTabeBySelRows.Select(this.xiangsi + this.huangshandi).Length > 0)
                        {
                            num15 = Convert.ToDouble(dataTabeBySelRows.Compute("SUM(MIAN_JI)", this.xiangsi + this.huangshandi));
                        }
                        if (dataTabeBySelRows.Select(this.yclqita + this.huangshandi).Length > 0)
                        {
                            num16 = Convert.ToDouble(dataTabeBySelRows.Compute("SUM(MIAN_JI)", this.yclqita + this.huangshandi));
                        }
                        if (dataTabeBySelRows.Select(this.sushengfcl + this.huangshandi).Length > 0)
                        {
                            num17 = Convert.ToDouble(dataTabeBySelRows.Compute("SUM(MIAN_JI)", this.sushengfcl + this.huangshandi));
                        }
                        num18 = (((num12 + num13) + num14) + num15) + num16;
                    }
                    double num19 = 0.0;
                    double num20 = 0.0;
                    double num21 = 0.0;
                    double num22 = 0.0;
                    double num23 = 0.0;
                    double num24 = 0.0;
                    double num25 = 0.0;
                    double num26 = 0.0;
                    double num27 = 0.0;
                    double num28 = 0.0;
                    DataTable table10 = this.GetDataTabeBySelRows(dt, this.jingjilin);
                    if (table10.Rows.Count > 0)
                    {
                        if (table10.Select(this.youcha + this.huangshandi).Length > 0)
                        {
                            num19 = Convert.ToDouble(table10.Compute("SUM(MIAN_JI)", this.youcha + this.huangshandi));
                        }
                        if (table10.Select(this.youtong + this.huangshandi).Length > 0)
                        {
                            num20 = Convert.ToDouble(table10.Compute("SUM(MIAN_JI)", this.youtong + this.huangshandi));
                        }
                        if (table10.Select(this.bajiao + this.huangshandi).Length > 0)
                        {
                            num21 = Convert.ToDouble(table10.Compute("SUM(MIAN_JI)", this.bajiao + this.huangshandi));
                        }
                        if (table10.Select(this.yugui + this.huangshandi).Length > 0)
                        {
                            num22 = Convert.ToDouble(table10.Compute("SUM(MIAN_JI)", this.yugui + this.huangshandi));
                        }
                        if (table10.Select(this.hetao + this.huangshandi).Length > 0)
                        {
                            num23 = Convert.ToDouble(table10.Compute("SUM(MIAN_JI)", this.hetao + this.huangshandi));
                        }
                        if (table10.Select(this.banli + this.huangshandi).Length > 0)
                        {
                            num24 = Convert.ToDouble(table10.Compute("SUM(MIAN_JI)", this.banli + this.huangshandi));
                        }
                        if (table10.Select(this.yinxing + this.huangshandi).Length > 0)
                        {
                            num25 = Convert.ToDouble(table10.Compute("SUM(MIAN_JI)", this.yinxing + this.huangshandi));
                        }
                        if (table10.Select(this.guoshu + this.huangshandi).Length > 0)
                        {
                            num26 = Convert.ToDouble(table10.Compute("SUM(MIAN_JI)", this.guoshu + this.huangshandi));
                        }
                        if (table10.Select(this.jjlqita + this.huangshandi).Length > 0)
                        {
                            num27 = Convert.ToDouble(table10.Compute("SUM(MIAN_JI)", this.jjlqita + this.huangshandi));
                        }
                        num28 = (((((((num19 + num20) + num21) + num22) + num23) + num24) + num25) + num26) + num27;
                    }
                    double num29 = 0.0;
                    if (dt.Select(this.fanghulin + this.huangshandi).Length > 0)
                    {
                        num29 = Convert.ToDouble(dt.Compute("SUM(MIAN_JI)", this.fanghulin + this.huangshandi));
                    }
                    double num30 = 0.0;
                    if (dt.Select(this.xintanlin + this.huangshandi).Length > 0)
                    {
                        num30 = Convert.ToDouble(dt.Compute("SUM(MIAN_JI)", this.xintanlin + this.huangshandi));
                    }
                    double num31 = 0.0;
                    if (dt.Select(this.teyonglin + this.huangshandi).Length > 0)
                    {
                        num31 = Convert.ToDouble(dt.Compute("SUM(MIAN_JI)", this.teyonglin + this.huangshandi));
                    }
                    if (num11 > 0.0)
                    {
                        DataRow row5 = table7.NewRow();
                        row5["TJDW"] = str3;
                        row5["HSZLZJ"] = Math.Round(num11, digits);
                        row5["RGZLZJ"] = Math.Round(num2, digits);
                        row5["TGDZL"] = Math.Round(num3, digits);
                        row5["ZLMJ"] = Math.Round(num4, digits);
                        row5["FBZL"] = Math.Round(num5, digits);
                        row5["WLDSLDXF"] = Math.Round(num6, digits);
                        row5["GYJJZLZJ"] = Math.Round(num9, digits);
                        row5["GYJJZL"] = Math.Round(num7, digits);
                        row5["JTJJZL"] = Math.Round(num8, digits);
                        row5["FGYJJZL"] = Math.Round(num10, digits);
                        row5["YCLZJ"] = Math.Round(num18, digits);
                        row5["ShaMu"] = Math.Round(num12, digits);
                        row5["SongShu"] = Math.Round(num13, digits);
                        row5["AnShu"] = Math.Round(num14, digits);
                        row5["XiangSi"] = Math.Round(num15, digits);
                        row5["YCLQT"] = Math.Round(num16, digits);
                        row5["SSFCL"] = Math.Round(num17, digits);
                        row5["JJLZJ"] = Math.Round(num28, digits);
                        row5["YouCha"] = Math.Round(num19, digits);
                        row5["YouTong"] = Math.Round(num20, digits);
                        row5["BaJiao"] = Math.Round(num21, digits);
                        row5["YuGui"] = Math.Round(num22, digits);
                        row5["HeTao"] = Math.Round(num23, digits);
                        row5["BanLi"] = Math.Round(num24, digits);
                        row5["YinXing"] = Math.Round(num25, digits);
                        row5["GuoShu"] = Math.Round(num26, digits);
                        row5["JJLQT"] = Math.Round(num27, digits);
                        row5["FHLMJ"] = Math.Round(num29, digits);
                        row5["XTLMJ"] = Math.Round(num30, digits);
                        row5["TZYTLMJ"] = Math.Round(num31, digits);
                        table7.Rows.Add(row5);
                    }
                }
                if (table7.Rows.Count > 0)
                {
                    DataRow row6 = table7.NewRow();
                    row6[0] = str2;
                    num32 = 1;
                    while (num32 < table7.Columns.Count)
                    {
                        row6[num32] = Math.Round(Convert.ToDouble(table7.Compute("SUM(" + table7.Columns[num32] + ")", null)), digits);
                        num32++;
                    }
                    table7.Rows.InsertAt(row6, 0);
                    table6.Rows.Add(row6.ItemArray);
                    foreach (DataRow row7 in table7.Rows)
                    {
                        resultTable.Rows.Add(row7.ItemArray);
                    }
                }
            }
            if (resultTable.Rows.Count <= 0)
            {
                return resultTable;
            }
            string str4 = resultTable.Rows[0][0].ToString().Trim().Substring(0, 6);
            DataRow row8 = resultTable.NewRow();
            row8[0] = str4;
            for (num32 = 1; num32 < resultTable.Columns.Count; num32++)
            {
                row8[num32] = Math.Round(Convert.ToDouble(table6.Compute("SUM(" + table6.Columns[num32] + ")", null)), digits);
            }
            resultTable.Rows.InsertAt(row8, 0);
            resultTable = this.ConvertTableFldValueZeroToNull(resultTable, 1);
            return this.ConvertTJTableDWCodeCol(resultTable, 2);
        }

        public DataTable TJKYSCQK2ByXiangCun(string gxnd, string xiangcode)
        {
            int digits = 2;
            DataTable resultTable = this.TJTableKYSCQK2();
            string cmdtxt = ("SELECT XIANG,CUN,LD_QS,TDJYQ,LMSYQ,Q_DI_LEI,MIAN_JI,LIN_ZHONG,YOU_SHI_SZ,ZAO_LIN_LB FROM " + TABLE_ZLDATATABLE + " WHERE LEFT(GXSJ,6)" + gxnd) + " AND (XIANG='" + xiangcode + "')  AND (ZAO_LIN_LB<'127')";
            DataTable table = this.GetTable(cmdtxt, "tjtable");
            DataTable dt = table.Clone();
            DataTable table4 = resultTable.Clone();
            table.DefaultView.Sort = "CUN";
            DataTable table5 = table.DefaultView.ToTable(true, new string[] { "CUN" });
            foreach (DataRow row in table5.Rows)
            {
                dt.Clear();
                string str2 = row["CUN"].ToString();
                DataRow[] rowArray = table.Select("CUN='" + str2 + "'");
                foreach (DataRow row2 in rowArray)
                {
                    dt.Rows.Add(row2.ItemArray);
                }
                double num2 = 0.0;
                if (dt.Select(this.linguanxiazaolin).Length > 0)
                {
                    num2 = Convert.ToDouble(dt.Compute("SUM(MIAN_JI)", this.linguanxiazaolin));
                }
                double num3 = 0.0;
                if (dt.Select(this.feibolinb2).Length > 0)
                {
                    num3 = Convert.ToDouble(dt.Compute("SUM(MIAN_JI)", this.feibolinb2));
                }
                double num4 = 0.0;
                if (dt.Select(this.youlindixinfeng).Length > 0)
                {
                    num4 = Convert.ToDouble(dt.Compute("SUM(MIAN_JI)", this.youlindixinfeng));
                }
                double num5 = 0.0;
                num5 = (num2 + num3) + num4;
                double num6 = 0.0;
                if (dt.Select(this.gengxinzaolin + " AND " + this.jidisql).Length > 0)
                {
                    num6 = Convert.ToDouble(dt.Compute("SUM(MIAN_JI)", this.gengxinzaolin + " AND " + this.jidisql));
                }
                double num7 = 0.0;
                if (dt.Select(this.zhulin + " AND " + this.jidisql).Length > 0)
                {
                    num7 = Convert.ToDouble(dt.Compute("SUM(MIAN_JI)", this.zhulin + " AND " + this.jidisql));
                }
                double num8 = 0.0;
                if (dt.Select(this.rengongcujingengxin).Length > 0)
                {
                    num8 = Convert.ToDouble(dt.Compute("SUM(MIAN_JI)", this.rengongcujingengxin));
                }
                double num9 = 0.0;
                num9 = num6 + num8;
                double num10 = 0.0;
                if (dt.Select(this.guoyoujjzaolin + " AND " + this.gengxinzaolin2 + " AND " + this.jidisql).Length > 0)
                {
                    num10 = Convert.ToDouble(dt.Compute("SUM(MIAN_JI)", this.guoyoujjzaolin + " AND " + this.gengxinzaolin2 + " AND " + this.jidisql));
                }
                double num11 = 0.0;
                if (dt.Select(this.jitijjzaolin + " AND " + this.gengxinzaolin2 + " AND " + this.jidisql).Length > 0)
                {
                    num11 = Convert.ToDouble(dt.Compute("SUM(MIAN_JI)", this.jitijjzaolin + " AND " + this.gengxinzaolin2 + " AND " + this.jidisql));
                }
                double num12 = num10 + num11;
                double num13 = 0.0;
                if (dt.Select(this.feigongjjzaolin + " AND " + this.gengxinzaolin2 + " AND " + this.jidisql).Length > 0)
                {
                    num13 = Convert.ToDouble(dt.Compute("SUM(MIAN_JI)", this.feigongjjzaolin + " AND " + this.gengxinzaolin2 + " AND " + this.jidisql));
                }
                double num14 = 0.0;
                double num15 = 0.0;
                double num16 = 0.0;
                double num17 = 0.0;
                double num18 = 0.0;
                double num19 = 0.0;
                double num20 = 0.0;
                DataTable dataTabeBySelRows = this.GetDataTabeBySelRows(dt, this.yongcailin);
                if (dataTabeBySelRows.Rows.Count > 0)
                {
                    if (dataTabeBySelRows.Select(this.shamu + " AND " + this.jidisql).Length > 0)
                    {
                        num14 = Convert.ToDouble(dataTabeBySelRows.Compute("SUM(MIAN_JI)", this.shamu + " AND " + this.jidisql));
                    }
                    if (dataTabeBySelRows.Select(this.songlei + " AND " + this.jidisql).Length > 0)
                    {
                        num15 = Convert.ToDouble(dataTabeBySelRows.Compute("SUM(MIAN_JI)", this.songlei + " AND " + this.jidisql));
                    }
                    if (dataTabeBySelRows.Select(this.anshu + " AND " + this.jidisql).Length > 0)
                    {
                        num16 = Convert.ToDouble(dataTabeBySelRows.Compute("SUM(MIAN_JI)", this.anshu + " AND " + this.jidisql));
                    }
                    if (dataTabeBySelRows.Select(this.xiangsi + " AND " + this.jidisql).Length > 0)
                    {
                        num17 = Convert.ToDouble(dataTabeBySelRows.Compute("SUM(MIAN_JI)", this.xiangsi + " AND " + this.jidisql));
                    }
                    if (dataTabeBySelRows.Select(this.yclqita + " AND " + this.jidisql).Length > 0)
                    {
                        num18 = Convert.ToDouble(dataTabeBySelRows.Compute("SUM(MIAN_JI)", this.yclqita + " AND " + this.jidisql));
                    }
                    if (dataTabeBySelRows.Select(this.sushengfcl + " AND " + this.jidisql).Length > 0)
                    {
                        num19 = Convert.ToDouble(dataTabeBySelRows.Compute("SUM(MIAN_JI)", this.sushengfcl + " AND " + this.jidisql));
                    }
                    num20 = (((num14 + num15) + num16) + num17) + num18;
                }
                double num21 = 0.0;
                double num22 = 0.0;
                double num23 = 0.0;
                double num24 = 0.0;
                double num25 = 0.0;
                double num26 = 0.0;
                double num27 = 0.0;
                double num28 = 0.0;
                double num29 = 0.0;
                double num30 = 0.0;
                DataTable table7 = this.GetDataTabeBySelRows(dt, this.jingjilin);
                if (table7.Rows.Count > 0)
                {
                    if (table7.Select(this.youcha + " AND " + this.jidisql).Length > 0)
                    {
                        num21 = Convert.ToDouble(table7.Compute("SUM(MIAN_JI)", this.youcha + " AND " + this.jidisql));
                    }
                    if (table7.Select(this.youtong + " AND " + this.jidisql).Length > 0)
                    {
                        num22 = Convert.ToDouble(table7.Compute("SUM(MIAN_JI)", this.youtong + " AND " + this.jidisql));
                    }
                    if (table7.Select(this.bajiao + " AND " + this.jidisql).Length > 0)
                    {
                        num23 = Convert.ToDouble(table7.Compute("SUM(MIAN_JI)", this.bajiao + " AND " + this.jidisql));
                    }
                    if (table7.Select(this.yugui + " AND " + this.jidisql).Length > 0)
                    {
                        num24 = Convert.ToDouble(table7.Compute("SUM(MIAN_JI)", this.yugui + " AND " + this.jidisql));
                    }
                    if (table7.Select(this.hetao + " AND " + this.jidisql).Length > 0)
                    {
                        num25 = Convert.ToDouble(table7.Compute("SUM(MIAN_JI)", this.hetao + " AND " + this.jidisql));
                    }
                    if (table7.Select(this.banli + " AND " + this.jidisql).Length > 0)
                    {
                        num26 = Convert.ToDouble(table7.Compute("SUM(MIAN_JI)", this.banli + " AND " + this.jidisql));
                    }
                    if (table7.Select(this.yinxing + " AND " + this.jidisql).Length > 0)
                    {
                        num27 = Convert.ToDouble(table7.Compute("SUM(MIAN_JI)", this.yinxing + " AND " + this.jidisql));
                    }
                    if (table7.Select(this.guoshu + " AND " + this.jidisql).Length > 0)
                    {
                        num28 = Convert.ToDouble(table7.Compute("SUM(MIAN_JI)", this.guoshu + " AND " + this.jidisql));
                    }
                    if (table7.Select(this.jjlqita + " AND " + this.jidisql).Length > 0)
                    {
                        num29 = Convert.ToDouble(table7.Compute("SUM(MIAN_JI)", this.jjlqita + " AND " + this.jidisql));
                    }
                    num30 = (((((((num21 + num22) + num23) + num24) + num25) + num26) + num27) + num28) + num29;
                }
                double num31 = 0.0;
                if (dt.Select(this.fanghulin + " AND " + this.jidisql).Length > 0)
                {
                    num31 = Convert.ToDouble(dt.Compute("SUM(MIAN_JI)", this.fanghulin + " AND " + this.jidisql));
                }
                double num32 = 0.0;
                if (dt.Select(this.xintanlin + " AND " + this.jidisql).Length > 0)
                {
                    num32 = Convert.ToDouble(dt.Compute("SUM(MIAN_JI)", this.xintanlin + " AND " + this.jidisql));
                }
                double num33 = 0.0;
                if (dt.Select(this.teyonglin + " AND " + this.jidisql).Length > 0)
                {
                    num33 = Convert.ToDouble(dt.Compute("SUM(MIAN_JI)", this.teyonglin + " AND " + this.jidisql));
                }
                num9 = num12 + num13;
                if ((num5 > 0.0) || (num9 > 0.0))
                {
                    DataRow row3 = table4.NewRow();
                    row3["TJDW"] = str2;
                    row3["YLDZLZJ"] = Math.Round(num5, digits);
                    row3["LGXZL"] = Math.Round(num2, digits);
                    row3["FBYL"] = Math.Round(num3, digits);
                    row3["YLDXF"] = Math.Round(num4, digits);
                    row3["JDGXZJ"] = Math.Round(num9, digits);
                    row3["GXZLZMJ"] = Math.Round(num6, digits);
                    row3["JDGXZLMJ"] = Math.Round(num7, digits);
                    row3["RGCJGXMJ"] = Math.Round(num8, digits);
                    row3["JDGXGYJJZLZJ"] = Math.Round(num12, digits);
                    row3["JDGXGYJJZL"] = Math.Round(num10, digits);
                    row3["JDGXJTJJZL"] = Math.Round(num11, digits);
                    row3["JDGXFGYJJZL"] = Math.Round(num13, digits);
                    row3["YCLZJ"] = Math.Round(num20, digits);
                    row3["ShaMu"] = Math.Round(num14, digits);
                    row3["SongShu"] = Math.Round(num15, digits);
                    row3["AnShu"] = Math.Round(num16, digits);
                    row3["XiangSi"] = Math.Round(num17, digits);
                    row3["YCLQT"] = Math.Round(num18, digits);
                    row3["SSFCL"] = Math.Round(num19, digits);
                    row3["JJLZJ"] = Math.Round(num30, digits);
                    row3["YouCha"] = Math.Round(num21, digits);
                    row3["YouTong"] = Math.Round(num22, digits);
                    row3["BaJiao"] = Math.Round(num23, digits);
                    row3["YuGui"] = Math.Round(num24, digits);
                    row3["HeTao"] = Math.Round(num25, digits);
                    row3["BanLi"] = Math.Round(num26, digits);
                    row3["YinXing"] = Math.Round(num27, digits);
                    row3["GuoShu"] = Math.Round(num28, digits);
                    row3["JJLQT"] = Math.Round(num29, digits);
                    row3["FHLMJ"] = Math.Round(num31, digits);
                    row3["XTLMJ"] = Math.Round(num32, digits);
                    row3["TZYTLMJ"] = Math.Round(num33, digits);
                    table4.Rows.Add(row3);
                }
            }
            if (table4.Rows.Count <= 0)
            {
                return resultTable;
            }
            DataRow row4 = table4.NewRow();
            row4[0] = xiangcode;
            for (int i = 1; i < table4.Columns.Count; i++)
            {
                row4[i] = Math.Round(Convert.ToDouble(table4.Compute("SUM(" + table4.Columns[i] + ")", null)), digits);
            }
            table4.Rows.InsertAt(row4, 0);
            foreach (DataRow row5 in table4.Rows)
            {
                resultTable.Rows.Add(row5.ItemArray);
            }
            resultTable = this.ConvertTableFldValueZeroToNull(resultTable, 1);
            return this.ConvertTJTableDWCodeCol(resultTable, 2);
        }

        public DataTable TJKYSCQK2ByXianXiang(string gxnd)
        {
            int digits = 2;
            DataTable resultTable = this.TJTableKYSCQK2();
            string cmdtxt = ("SELECT XIANG,LD_QS,TDJYQ,LMSYQ,Q_DI_LEI,MIAN_JI,LIN_ZHONG,YOU_SHI_SZ,ZAO_LIN_LB FROM " + TABLE_ZLDATATABLE + " WHERE LEFT(GXSJ,6)" + gxnd) + " AND (ZAO_LIN_LB<'127') ";
            DataTable table = this.GetTable(cmdtxt, "tjtable");
            table.DefaultView.Sort = "XIANG";
            DataTable table3 = table.DefaultView.ToTable(true, new string[] { "XIANG" });
            foreach (DataRow row in table3.Rows)
            {
                string str2 = row[0].ToString();
                DataTable dt = table.Clone();
                DataRow[] rowArray = table.Select("XIANG='" + str2 + "'");
                foreach (DataRow row2 in rowArray)
                {
                    dt.Rows.Add(row2.ItemArray);
                }
                double num2 = 0.0;
                if (dt.Select(this.linguanxiazaolin).Length > 0)
                {
                    num2 = Convert.ToDouble(dt.Compute("SUM(MIAN_JI)", this.linguanxiazaolin));
                }
                double num3 = 0.0;
                if (dt.Select(this.feibolinb2).Length > 0)
                {
                    num3 = Convert.ToDouble(dt.Compute("SUM(MIAN_JI)", this.feibolinb2));
                }
                double num4 = 0.0;
                if (dt.Select(this.youlindixinfeng).Length > 0)
                {
                    num4 = Convert.ToDouble(dt.Compute("SUM(MIAN_JI)", this.youlindixinfeng));
                }
                double num5 = 0.0;
                num5 = (num2 + num3) + num4;
                double num6 = 0.0;
                if (dt.Select(this.gengxinzaolin + " AND " + this.jidisql).Length > 0)
                {
                    num6 = Convert.ToDouble(dt.Compute("SUM(MIAN_JI)", this.gengxinzaolin + " AND " + this.jidisql));
                }
                double num7 = 0.0;
                if (dt.Select(this.zhulin + " AND " + this.jidisql).Length > 0)
                {
                    num7 = Convert.ToDouble(dt.Compute("SUM(MIAN_JI)", this.zhulin + " AND " + this.gengxinzaolin + " AND " + this.jidisql));
                }
                double num8 = 0.0;
                if (dt.Select(this.rengongcujingengxin).Length > 0)
                {
                    num8 = Convert.ToDouble(dt.Compute("SUM(MIAN_JI)", this.rengongcujingengxin));
                }
                double num9 = 0.0;
                double num10 = 0.0;
                if (dt.Select(this.guoyoujjzaolin + " AND " + this.gengxinzaolin2 + " AND " + this.jidisql).Length > 0)
                {
                    num10 = Convert.ToDouble(dt.Compute("SUM(MIAN_JI)", this.guoyoujjzaolin + " AND " + this.gengxinzaolin2 + " AND " + this.jidisql));
                }
                double num11 = 0.0;
                if (dt.Select(this.jitijjzaolin + " AND " + this.gengxinzaolin2 + " AND " + this.jidisql).Length > 0)
                {
                    num11 = Convert.ToDouble(dt.Compute("SUM(MIAN_JI)", this.jitijjzaolin + " AND " + this.gengxinzaolin2 + " AND " + this.jidisql));
                }
                double num12 = num10 + num11;
                double num13 = 0.0;
                if (dt.Select(this.feigongjjzaolin + " AND " + this.gengxinzaolin2 + " AND " + this.jidisql).Length > 0)
                {
                    num13 = Convert.ToDouble(dt.Compute("SUM(MIAN_JI)", this.feigongjjzaolin + " AND " + this.gengxinzaolin2 + " AND " + this.jidisql));
                }
                double num14 = 0.0;
                double num15 = 0.0;
                double num16 = 0.0;
                double num17 = 0.0;
                double num18 = 0.0;
                double num19 = 0.0;
                double num20 = 0.0;
                DataTable dataTabeBySelRows = this.GetDataTabeBySelRows(dt, this.yongcailin);
                if (dataTabeBySelRows.Rows.Count > 0)
                {
                    if (dataTabeBySelRows.Select(this.shamu + " AND " + this.jidisql).Length > 0)
                    {
                        num14 = Convert.ToDouble(dataTabeBySelRows.Compute("SUM(MIAN_JI)", this.shamu + " AND " + this.jidisql));
                    }
                    if (dataTabeBySelRows.Select(this.songlei + " AND " + this.jidisql).Length > 0)
                    {
                        num15 = Convert.ToDouble(dataTabeBySelRows.Compute("SUM(MIAN_JI)", this.songlei + " AND " + this.jidisql));
                    }
                    if (dataTabeBySelRows.Select(this.anshu + " AND " + this.jidisql).Length > 0)
                    {
                        num16 = Convert.ToDouble(dataTabeBySelRows.Compute("SUM(MIAN_JI)", this.anshu + " AND " + this.jidisql));
                    }
                    if (dataTabeBySelRows.Select(this.xiangsi + " AND " + this.jidisql).Length > 0)
                    {
                        num17 = Convert.ToDouble(dataTabeBySelRows.Compute("SUM(MIAN_JI)", this.xiangsi + " AND " + this.jidisql));
                    }
                    if (dataTabeBySelRows.Select(this.yclqita + " AND " + this.jidisql).Length > 0)
                    {
                        num18 = Convert.ToDouble(dataTabeBySelRows.Compute("SUM(MIAN_JI)", this.yclqita + " AND " + this.jidisql));
                    }
                    if (dataTabeBySelRows.Select(this.sushengfcl + " AND " + this.jidisql).Length > 0)
                    {
                        num19 = Convert.ToDouble(dataTabeBySelRows.Compute("SUM(MIAN_JI)", this.sushengfcl + " AND " + this.jidisql));
                    }
                    num20 = (((num14 + num15) + num16) + num17) + num18;
                }
                double num21 = 0.0;
                double num22 = 0.0;
                double num23 = 0.0;
                double num24 = 0.0;
                double num25 = 0.0;
                double num26 = 0.0;
                double num27 = 0.0;
                double num28 = 0.0;
                double num29 = 0.0;
                double num30 = 0.0;
                DataTable table6 = this.GetDataTabeBySelRows(dt, this.jingjilin);
                if (table6.Rows.Count > 0)
                {
                    if (table6.Select(this.youcha + " AND " + this.jidisql).Length > 0)
                    {
                        num21 = Convert.ToDouble(table6.Compute("SUM(MIAN_JI)", this.youcha + " AND " + this.jidisql));
                    }
                    if (table6.Select(this.youtong + " AND " + this.jidisql).Length > 0)
                    {
                        num22 = Convert.ToDouble(table6.Compute("SUM(MIAN_JI)", this.youtong + " AND " + this.jidisql));
                    }
                    if (table6.Select(this.bajiao + " AND " + this.jidisql).Length > 0)
                    {
                        num23 = Convert.ToDouble(table6.Compute("SUM(MIAN_JI)", this.bajiao + " AND " + this.jidisql));
                    }
                    if (table6.Select(this.yugui + " AND " + this.jidisql).Length > 0)
                    {
                        num24 = Convert.ToDouble(table6.Compute("SUM(MIAN_JI)", this.yugui + " AND " + this.jidisql));
                    }
                    if (table6.Select(this.hetao + " AND " + this.jidisql).Length > 0)
                    {
                        num25 = Convert.ToDouble(table6.Compute("SUM(MIAN_JI)", this.hetao + " AND " + this.jidisql));
                    }
                    if (table6.Select(this.banli + " AND " + this.jidisql).Length > 0)
                    {
                        num26 = Convert.ToDouble(table6.Compute("SUM(MIAN_JI)", this.banli + " AND " + this.jidisql));
                    }
                    if (table6.Select(this.yinxing + " AND " + this.jidisql).Length > 0)
                    {
                        num27 = Convert.ToDouble(table6.Compute("SUM(MIAN_JI)", this.yinxing + " AND " + this.jidisql));
                    }
                    if (table6.Select(this.guoshu + " AND " + this.jidisql).Length > 0)
                    {
                        num28 = Convert.ToDouble(table6.Compute("SUM(MIAN_JI)", this.guoshu + " AND " + this.jidisql));
                    }
                    if (table6.Select(this.jjlqita + " AND " + this.jidisql).Length > 0)
                    {
                        num29 = Convert.ToDouble(table6.Compute("SUM(MIAN_JI)", this.jjlqita + " AND " + this.jidisql));
                    }
                    num30 = (((((((num21 + num22) + num23) + num24) + num25) + num26) + num27) + num28) + num29;
                }
                double num31 = 0.0;
                if (dt.Select(this.fanghulin + " AND " + this.jidisql).Length > 0)
                {
                    num31 = Convert.ToDouble(dt.Compute("SUM(MIAN_JI)", this.fanghulin + " AND " + this.jidisql));
                }
                double num32 = 0.0;
                if (dt.Select(this.xintanlin + " AND " + this.jidisql).Length > 0)
                {
                    num32 = Convert.ToDouble(dt.Compute("SUM(MIAN_JI)", this.xintanlin + " AND " + this.jidisql));
                }
                double num33 = 0.0;
                if (dt.Select(this.teyonglin + " AND " + this.jidisql).Length > 0)
                {
                    num33 = Convert.ToDouble(dt.Compute("SUM(MIAN_JI)", this.teyonglin + " AND " + this.jidisql));
                }
                num9 = num12 + num13;
                if ((num5 > 0.0) || (num9 > 0.0))
                {
                    DataRow row3 = resultTable.NewRow();
                    row3["TJDW"] = str2;
                    row3["YLDZLZJ"] = Math.Round(num5, digits);
                    row3["LGXZL"] = Math.Round(num2, digits);
                    row3["FBYL"] = Math.Round(num3, digits);
                    row3["YLDXF"] = Math.Round(num4, digits);
                    row3["JDGXZJ"] = Math.Round(num9, digits);
                    row3["GXZLZMJ"] = Math.Round(num6, digits);
                    row3["JDGXZLMJ"] = Math.Round(num7, digits);
                    row3["RGCJGXMJ"] = Math.Round(num8, digits);
                    row3["JDGXGYJJZLZJ"] = Math.Round(num12, digits);
                    row3["JDGXGYJJZL"] = Math.Round(num10, digits);
                    row3["JDGXJTJJZL"] = Math.Round(num11, digits);
                    row3["JDGXFGYJJZL"] = Math.Round(num13, digits);
                    row3["YCLZJ"] = Math.Round(num20, digits);
                    row3["ShaMu"] = Math.Round(num14, digits);
                    row3["SongShu"] = Math.Round(num15, digits);
                    row3["AnShu"] = Math.Round(num16, digits);
                    row3["XiangSi"] = Math.Round(num17, digits);
                    row3["YCLQT"] = Math.Round(num18, digits);
                    row3["SSFCL"] = Math.Round(num19, digits);
                    row3["JJLZJ"] = Math.Round(num30, digits);
                    row3["YouCha"] = Math.Round(num21, digits);
                    row3["YouTong"] = Math.Round(num22, digits);
                    row3["BaJiao"] = Math.Round(num23, digits);
                    row3["YuGui"] = Math.Round(num24, digits);
                    row3["HeTao"] = Math.Round(num25, digits);
                    row3["BanLi"] = Math.Round(num26, digits);
                    row3["YinXing"] = Math.Round(num27, digits);
                    row3["GuoShu"] = Math.Round(num28, digits);
                    row3["JJLQT"] = Math.Round(num29, digits);
                    row3["FHLMJ"] = Math.Round(num31, digits);
                    row3["XTLMJ"] = Math.Round(num32, digits);
                    row3["TZYTLMJ"] = Math.Round(num33, digits);
                    resultTable.Rows.Add(row3);
                }
            }
            if (resultTable.Rows.Count <= 0)
            {
                return resultTable;
            }
            string str3 = resultTable.Rows[0][0].ToString().Trim().Substring(0, 6);
            DataRow row4 = resultTable.NewRow();
            row4[0] = str3;
            for (int i = 1; i < resultTable.Columns.Count; i++)
            {
                row4[i] = Math.Round(Convert.ToDouble(resultTable.Compute("SUM(" + resultTable.Columns[i] + ")", null)), digits);
            }
            resultTable.Rows.InsertAt(row4, 0);
            resultTable = this.ConvertTableFldValueZeroToNull(resultTable, 1);
            return this.ConvertTJTableDWCodeCol(resultTable, 1);
        }

        public DataTable TJKYSCQK2ByXianXiangCun(string gxnd)
        {
            int num34;
            int digits = 2;
            DataTable resultTable = this.TJTableKYSCQK2();
            string cmdtxt = ("SELECT XIANG,CUN,LD_QS,TDJYQ,LMSYQ,Q_DI_LEI,MIAN_JI,LIN_ZHONG,YOU_SHI_SZ,ZAO_LIN_LB FROM " + TABLE_ZLDATATABLE + " WHERE LEFT(GXSJ,6)" + gxnd) + " AND (ZAO_LIN_LB<'127')";
            DataTable table = this.GetTable(cmdtxt, "tjtable");
            DataTable table3 = table.Clone();
            DataTable dt = table.Clone();
            table.DefaultView.Sort = "XIANG";
            DataTable table5 = table.DefaultView.ToTable(true, new string[] { "XIANG" });
            DataTable table6 = resultTable.Clone();
            DataTable table7 = resultTable.Clone();
            foreach (DataRow row in table5.Rows)
            {
                table3.Clear();
                string str2 = row[0].ToString();
                DataRow[] rowArray = table.Select("XIANG='" + str2 + "'");
                foreach (DataRow row2 in rowArray)
                {
                    table3.Rows.Add(row2.ItemArray);
                }
                table7.Clear();
                table3.DefaultView.Sort = "CUN";
                DataTable table8 = table3.DefaultView.ToTable(true, new string[] { "CUN" });
                foreach (DataRow row3 in table8.Rows)
                {
                    dt.Clear();
                    string str3 = row3["CUN"].ToString();
                    DataRow[] rowArray2 = table3.Select("CUN='" + str3 + "'");
                    foreach (DataRow row4 in rowArray2)
                    {
                        dt.Rows.Add(row4.ItemArray);
                    }
                    double num2 = 0.0;
                    if (dt.Select(this.linguanxiazaolin).Length > 0)
                    {
                        num2 = Convert.ToDouble(dt.Compute("SUM(MIAN_JI)", this.linguanxiazaolin));
                    }
                    double num3 = 0.0;
                    if (dt.Select(this.feibolinb2).Length > 0)
                    {
                        num3 = Convert.ToDouble(dt.Compute("SUM(MIAN_JI)", this.feibolinb2));
                    }
                    double num4 = 0.0;
                    if (dt.Select(this.youlindixinfeng).Length > 0)
                    {
                        num4 = Convert.ToDouble(dt.Compute("SUM(MIAN_JI)", this.youlindixinfeng));
                    }
                    double num5 = 0.0;
                    num5 = (num2 + num3) + num4;
                    double num6 = 0.0;
                    if (dt.Select(this.gengxinzaolin + " AND " + this.jidisql).Length > 0)
                    {
                        num6 = Convert.ToDouble(dt.Compute("SUM(MIAN_JI)", this.gengxinzaolin + " AND " + this.jidisql));
                    }
                    double num7 = 0.0;
                    if (dt.Select(this.zhulin + " AND " + this.jidisql).Length > 0)
                    {
                        num7 = Convert.ToDouble(dt.Compute("SUM(MIAN_JI)", this.zhulin + " AND " + this.jidisql));
                    }
                    double num8 = 0.0;
                    if (dt.Select(this.rengongcujingengxin).Length > 0)
                    {
                        num8 = Convert.ToDouble(dt.Compute("SUM(MIAN_JI)", this.rengongcujingengxin));
                    }
                    double num9 = 0.0;
                    num9 = num6 + num8;
                    double num10 = 0.0;
                    if (dt.Select(this.guoyoujjzaolin + " AND " + this.gengxinzaolin2 + " AND " + this.jidisql).Length > 0)
                    {
                        num10 = Convert.ToDouble(dt.Compute("SUM(MIAN_JI)", this.guoyoujjzaolin + " AND " + this.gengxinzaolin2 + " AND " + this.jidisql));
                    }
                    double num11 = 0.0;
                    if (dt.Select(this.jitijjzaolin + " AND " + this.gengxinzaolin2 + " AND " + this.jidisql).Length > 0)
                    {
                        num11 = Convert.ToDouble(dt.Compute("SUM(MIAN_JI)", this.jitijjzaolin + " AND " + this.gengxinzaolin2 + " AND " + this.jidisql));
                    }
                    double num12 = num10 + num11;
                    double num13 = 0.0;
                    if (dt.Select(this.feigongjjzaolin + " AND " + this.gengxinzaolin2 + " AND " + this.jidisql).Length > 0)
                    {
                        num13 = Convert.ToDouble(dt.Compute("SUM(MIAN_JI)", this.feigongjjzaolin + " AND " + this.gengxinzaolin2 + " AND " + this.jidisql));
                    }
                    double num14 = 0.0;
                    double num15 = 0.0;
                    double num16 = 0.0;
                    double num17 = 0.0;
                    double num18 = 0.0;
                    double num19 = 0.0;
                    double num20 = 0.0;
                    DataTable dataTabeBySelRows = this.GetDataTabeBySelRows(dt, this.yongcailin);
                    if (dataTabeBySelRows.Rows.Count > 0)
                    {
                        if (dataTabeBySelRows.Select(this.shamu + " AND " + this.jidisql).Length > 0)
                        {
                            num14 = Convert.ToDouble(dataTabeBySelRows.Compute("SUM(MIAN_JI)", this.shamu + " AND " + this.jidisql));
                        }
                        if (dataTabeBySelRows.Select(this.songlei + " AND " + this.jidisql).Length > 0)
                        {
                            num15 = Convert.ToDouble(dataTabeBySelRows.Compute("SUM(MIAN_JI)", this.songlei + " AND " + this.jidisql));
                        }
                        if (dataTabeBySelRows.Select(this.anshu + " AND " + this.jidisql).Length > 0)
                        {
                            num16 = Convert.ToDouble(dataTabeBySelRows.Compute("SUM(MIAN_JI)", this.anshu + " AND " + this.jidisql));
                        }
                        if (dataTabeBySelRows.Select(this.xiangsi + " AND " + this.jidisql).Length > 0)
                        {
                            num17 = Convert.ToDouble(dataTabeBySelRows.Compute("SUM(MIAN_JI)", this.xiangsi + " AND " + this.jidisql));
                        }
                        if (dataTabeBySelRows.Select(this.yclqita + " AND " + this.jidisql).Length > 0)
                        {
                            num18 = Convert.ToDouble(dataTabeBySelRows.Compute("SUM(MIAN_JI)", this.yclqita + " AND " + this.jidisql));
                        }
                        if (dataTabeBySelRows.Select(this.sushengfcl + " AND " + this.jidisql).Length > 0)
                        {
                            num19 = Convert.ToDouble(dataTabeBySelRows.Compute("SUM(MIAN_JI)", this.sushengfcl + " AND " + this.jidisql));
                        }
                        num20 = (((num14 + num15) + num16) + num17) + num18;
                    }
                    double num21 = 0.0;
                    double num22 = 0.0;
                    double num23 = 0.0;
                    double num24 = 0.0;
                    double num25 = 0.0;
                    double num26 = 0.0;
                    double num27 = 0.0;
                    double num28 = 0.0;
                    double num29 = 0.0;
                    double num30 = 0.0;
                    DataTable table10 = this.GetDataTabeBySelRows(dt, this.jingjilin);
                    if (table10.Rows.Count > 0)
                    {
                        if (table10.Select(this.youcha + " AND " + this.jidisql).Length > 0)
                        {
                            num21 = Convert.ToDouble(table10.Compute("SUM(MIAN_JI)", this.youcha + " AND " + this.jidisql));
                        }
                        if (table10.Select(this.youtong + " AND " + this.jidisql).Length > 0)
                        {
                            num22 = Convert.ToDouble(table10.Compute("SUM(MIAN_JI)", this.youtong + " AND " + this.jidisql));
                        }
                        if (table10.Select(this.bajiao + " AND " + this.jidisql).Length > 0)
                        {
                            num23 = Convert.ToDouble(table10.Compute("SUM(MIAN_JI)", this.bajiao + " AND " + this.jidisql));
                        }
                        if (table10.Select(this.yugui + " AND " + this.jidisql).Length > 0)
                        {
                            num24 = Convert.ToDouble(table10.Compute("SUM(MIAN_JI)", this.yugui + " AND " + this.jidisql));
                        }
                        if (table10.Select(this.hetao + " AND " + this.jidisql).Length > 0)
                        {
                            num25 = Convert.ToDouble(table10.Compute("SUM(MIAN_JI)", this.hetao + " AND " + this.jidisql));
                        }
                        if (table10.Select(this.banli + " AND " + this.jidisql).Length > 0)
                        {
                            num26 = Convert.ToDouble(table10.Compute("SUM(MIAN_JI)", this.banli + " AND " + this.jidisql));
                        }
                        if (table10.Select(this.yinxing + " AND " + this.jidisql).Length > 0)
                        {
                            num27 = Convert.ToDouble(table10.Compute("SUM(MIAN_JI)", this.yinxing + " AND " + this.jidisql));
                        }
                        if (table10.Select(this.guoshu + " AND " + this.jidisql).Length > 0)
                        {
                            num28 = Convert.ToDouble(table10.Compute("SUM(MIAN_JI)", this.guoshu + " AND " + this.jidisql));
                        }
                        if (table10.Select(this.jjlqita + " AND " + this.jidisql).Length > 0)
                        {
                            num29 = Convert.ToDouble(table10.Compute("SUM(MIAN_JI)", this.jjlqita));
                        }
                        num30 = (((((((num21 + num22) + num23) + num24) + num25) + num26) + num27) + num28) + num29;
                    }
                    double num31 = 0.0;
                    if (dt.Select(this.fanghulin + " AND " + this.jidisql).Length > 0)
                    {
                        num31 = Convert.ToDouble(dt.Compute("SUM(MIAN_JI)", this.fanghulin + " AND " + this.jidisql));
                    }
                    double num32 = 0.0;
                    if (dt.Select(this.xintanlin + " AND " + this.jidisql).Length > 0)
                    {
                        num32 = Convert.ToDouble(dt.Compute("SUM(MIAN_JI)", this.xintanlin + " AND " + this.jidisql));
                    }
                    double num33 = 0.0;
                    if (dt.Select(this.teyonglin + " AND " + this.jidisql).Length > 0)
                    {
                        num33 = Convert.ToDouble(dt.Compute("SUM(MIAN_JI)", this.teyonglin + " AND " + this.jidisql));
                    }
                    num9 = num12 + num13;
                    if ((num5 > 0.0) || (num9 > 0.0))
                    {
                        DataRow row5 = table7.NewRow();
                        row5["TJDW"] = str3;
                        row5["YLDZLZJ"] = num5;
                        row5["LGXZL"] = num2;
                        row5["FBYL"] = num3;
                        row5["YLDXF"] = num4;
                        row5["JDGXZJ"] = num9;
                        row5["GXZLZMJ"] = num6;
                        row5["JDGXZLMJ"] = num7;
                        row5["RGCJGXMJ"] = num8;
                        row5["JDGXGYJJZLZJ"] = num12;
                        row5["JDGXGYJJZL"] = num10;
                        row5["JDGXJTJJZL"] = num11;
                        row5["JDGXFGYJJZL"] = num13;
                        row5["YCLZJ"] = num20;
                        row5["ShaMu"] = num14;
                        row5["SongShu"] = num15;
                        row5["AnShu"] = num16;
                        row5["XiangSi"] = num17;
                        row5["YCLQT"] = num18;
                        row5["SSFCL"] = num19;
                        row5["JJLZJ"] = num30;
                        row5["YouCha"] = num21;
                        row5["YouTong"] = num22;
                        row5["BaJiao"] = num23;
                        row5["YuGui"] = num24;
                        row5["HeTao"] = num25;
                        row5["BanLi"] = num26;
                        row5["YinXing"] = num27;
                        row5["GuoShu"] = num28;
                        row5["JJLQT"] = num29;
                        row5["FHLMJ"] = num31;
                        row5["XTLMJ"] = num32;
                        row5["TZYTLMJ"] = num33;
                        table7.Rows.Add(row5);
                    }
                }
                if (table7.Rows.Count > 0)
                {
                    DataRow row6 = table7.NewRow();
                    row6[0] = str2;
                    num34 = 1;
                    while (num34 < table7.Columns.Count)
                    {
                        row6[num34] = Math.Round(Convert.ToDouble(table7.Compute("SUM(" + table7.Columns[num34] + ")", null)), digits);
                        num34++;
                    }
                    table7.Rows.InsertAt(row6, 0);
                    table6.Rows.Add(row6.ItemArray);
                    foreach (DataRow row7 in table7.Rows)
                    {
                        resultTable.Rows.Add(row7.ItemArray);
                    }
                }
            }
            if (resultTable.Rows.Count <= 0)
            {
                return resultTable;
            }
            string str4 = resultTable.Rows[0][0].ToString().Trim().Substring(0, 6);
            DataRow row8 = resultTable.NewRow();
            row8[0] = str4;
            for (num34 = 1; num34 < resultTable.Columns.Count; num34++)
            {
                row8[num34] = Math.Round(Convert.ToDouble(table6.Compute("SUM(" + table6.Columns[num34] + ")", null)), digits);
            }
            resultTable.Rows.InsertAt(row8, 0);
            resultTable = this.ConvertTableFldValueZeroToNull(resultTable, 1);
            return this.ConvertTJTableDWCodeCol(resultTable, 2);
        }

        public DataTable TJKYSCQK3ByXiangCun(string gxnd, string xiangcode)
        {
            int digits = 2;
            DataTable resultTable = this.TJTableKYSCQK3();
            string cmdtxt = ("SELECT XIANG,CUN,LD_QS,TDJYQ,LMSYQ,DI_LEI,MIAN_JI,LIN_ZHONG,YOU_SHI_SZ,ZAO_LIN_LB FROM " + TABLE_ZLDATATABLE + " WHERE LEFT(GXSJ,6)" + gxnd) + " AND (XIANG='" + xiangcode + "')  AND (ZAO_LIN_LB='122')";
            DataTable table = this.GetTable(cmdtxt, "tjtable");
            DataTable dt = table.Clone();
            DataTable table4 = resultTable.Clone();
            table.DefaultView.Sort = "CUN";
            DataTable table5 = table.DefaultView.ToTable(true, new string[] { "CUN" });
            foreach (DataRow row in table5.Rows)
            {
                dt.Clear();
                string str2 = row["CUN"].ToString();
                DataRow[] rowArray = table.Select("CUN='" + str2 + "'");
                foreach (DataRow row2 in rowArray)
                {
                    dt.Rows.Add(row2.ItemArray);
                }
                double num2 = 0.0;
                num2 = Convert.ToDouble(dt.Compute("SUM(MIAN_JI)", null));
                double num3 = 0.0;
                if (dt.Select(this.zhulin).Length > 0)
                {
                    num3 = Convert.ToDouble(dt.Compute("SUM(MIAN_JI)", this.zhulin));
                }
                double num4 = 0.0;
                if (dt.Select(this.guoyoujjzaolin).Length > 0)
                {
                    num4 = Convert.ToDouble(dt.Compute("SUM(MIAN_JI)", this.guoyoujjzaolin));
                }
                double num5 = 0.0;
                if (dt.Select(this.jitijjzaolin).Length > 0)
                {
                    num5 = Convert.ToDouble(dt.Compute("SUM(MIAN_JI)", this.jitijjzaolin));
                }
                double num6 = num4 + num5;
                double num7 = 0.0;
                if (dt.Select(this.feigongjjzaolin).Length > 0)
                {
                    num7 = Convert.ToDouble(dt.Compute("SUM(MIAN_JI)", this.feigongjjzaolin));
                }
                double num8 = 0.0;
                num8 = num6 + num7;
                double num9 = 0.0;
                double num10 = 0.0;
                double num11 = 0.0;
                double num12 = 0.0;
                double num13 = 0.0;
                double num14 = 0.0;
                double num15 = 0.0;
                DataTable dataTabeBySelRows = this.GetDataTabeBySelRows(dt, this.yongcailin);
                if (dataTabeBySelRows.Rows.Count > 0)
                {
                    if (dataTabeBySelRows.Select(this.shamu).Length > 0)
                    {
                        num9 = Convert.ToDouble(dataTabeBySelRows.Compute("SUM(MIAN_JI)", this.shamu));
                    }
                    if (dataTabeBySelRows.Select(this.songlei).Length > 0)
                    {
                        num10 = Convert.ToDouble(dataTabeBySelRows.Compute("SUM(MIAN_JI)", this.songlei));
                    }
                    if (dataTabeBySelRows.Select(this.anshu).Length > 0)
                    {
                        num11 = Convert.ToDouble(dataTabeBySelRows.Compute("SUM(MIAN_JI)", this.anshu));
                    }
                    if (dataTabeBySelRows.Select(this.xiangsi).Length > 0)
                    {
                        num12 = Convert.ToDouble(dataTabeBySelRows.Compute("SUM(MIAN_JI)", this.xiangsi));
                    }
                    if (dataTabeBySelRows.Select(this.yclqita).Length > 0)
                    {
                        num13 = Convert.ToDouble(dataTabeBySelRows.Compute("SUM(MIAN_JI)", this.yclqita));
                    }
                    if (dataTabeBySelRows.Select(this.sushengfcl).Length > 0)
                    {
                        num14 = Convert.ToDouble(dataTabeBySelRows.Compute("SUM(MIAN_JI)", this.sushengfcl));
                    }
                    num15 = (((num9 + num10) + num11) + num12) + num13;
                }
                double num16 = 0.0;
                double num17 = 0.0;
                double num18 = 0.0;
                double num19 = 0.0;
                double num20 = 0.0;
                double num21 = 0.0;
                double num22 = 0.0;
                double num23 = 0.0;
                double num24 = 0.0;
                double num25 = 0.0;
                DataTable table7 = this.GetDataTabeBySelRows(dt, this.jingjilin);
                if (table7.Rows.Count > 0)
                {
                    if (table7.Select(this.youcha).Length > 0)
                    {
                        num16 = Convert.ToDouble(table7.Compute("SUM(MIAN_JI)", this.youcha));
                    }
                    if (table7.Select(this.youtong).Length > 0)
                    {
                        num17 = Convert.ToDouble(table7.Compute("SUM(MIAN_JI)", this.youtong));
                    }
                    if (table7.Select(this.bajiao).Length > 0)
                    {
                        num18 = Convert.ToDouble(table7.Compute("SUM(MIAN_JI)", this.bajiao));
                    }
                    if (table7.Select(this.yugui).Length > 0)
                    {
                        num19 = Convert.ToDouble(table7.Compute("SUM(MIAN_JI)", this.yugui));
                    }
                    if (table7.Select(this.hetao).Length > 0)
                    {
                        num20 = Convert.ToDouble(table7.Compute("SUM(MIAN_JI)", this.hetao));
                    }
                    if (table7.Select(this.banli).Length > 0)
                    {
                        num21 = Convert.ToDouble(table7.Compute("SUM(MIAN_JI)", this.banli));
                    }
                    if (table7.Select(this.yinxing).Length > 0)
                    {
                        num22 = Convert.ToDouble(table7.Compute("SUM(MIAN_JI)", this.yinxing));
                    }
                    if (table7.Select(this.guoshu).Length > 0)
                    {
                        num23 = Convert.ToDouble(table7.Compute("SUM(MIAN_JI)", this.guoshu));
                    }
                    if (table7.Select(this.jjlqita).Length > 0)
                    {
                        num24 = Convert.ToDouble(table7.Compute("SUM(MIAN_JI)", this.jjlqita));
                    }
                    num25 = (((((((num16 + num17) + num18) + num19) + num20) + num21) + num22) + num23) + num24;
                }
                double num26 = 0.0;
                if (dt.Select(this.fanghulin).Length > 0)
                {
                    num26 = Convert.ToDouble(dt.Compute("SUM(MIAN_JI)", this.fanghulin));
                }
                double num27 = 0.0;
                if (dt.Select(this.xintanlin).Length > 0)
                {
                    num27 = Convert.ToDouble(dt.Compute("SUM(MIAN_JI)", this.xintanlin));
                }
                double num28 = 0.0;
                if (dt.Select(this.teyonglin).Length > 0)
                {
                    num28 = Convert.ToDouble(dt.Compute("SUM(MIAN_JI)", this.teyonglin));
                }
                DataRow row3 = table4.NewRow();
                row3["TJDW"] = str2;
                row3["ZLZJ"] = Math.Round(num8, digits);
                row3["DCDXLMJ"] = Math.Round(num2, digits);
                row3["ZhuLin"] = Math.Round(num3, digits);
                row3["DCDXGYJJZLZJ"] = Math.Round(num6, digits);
                row3["DCDXGYJJZL"] = Math.Round(num4, digits);
                row3["DCDXJTJJZL"] = Math.Round(num5, digits);
                row3["DCDXFGYJJZL"] = Math.Round(num7, digits);
                row3["YCLZJ"] = Math.Round(num15, digits);
                row3["ShaMu"] = Math.Round(num9, digits);
                row3["SongShu"] = Math.Round(num10, digits);
                row3["AnShu"] = Math.Round(num11, digits);
                row3["XiangSi"] = Math.Round(num12, digits);
                row3["YCLQT"] = Math.Round(num13, digits);
                row3["SSFCL"] = Math.Round(num14, digits);
                row3["JJLZJ"] = Math.Round(num25, digits);
                row3["YouCha"] = Math.Round(num16, digits);
                row3["YouTong"] = Math.Round(num17, digits);
                row3["BaJiao"] = Math.Round(num18, digits);
                row3["YuGui"] = Math.Round(num19, digits);
                row3["HeTao"] = Math.Round(num20, digits);
                row3["BanLi"] = Math.Round(num21, digits);
                row3["YinXing"] = Math.Round(num22, digits);
                row3["GuoShu"] = Math.Round(num23, digits);
                row3["JJLQT"] = Math.Round(num24, digits);
                row3["FHLMJ"] = Math.Round(num26, digits);
                row3["XTLMJ"] = Math.Round(num27, digits);
                row3["TZYTLMJ"] = Math.Round(num28, digits);
                table4.Rows.Add(row3);
            }
            if (table4.Rows.Count <= 0)
            {
                return resultTable;
            }
            DataRow row4 = table4.NewRow();
            row4[0] = xiangcode;
            for (int i = 1; i < table4.Columns.Count; i++)
            {
                row4[i] = Math.Round(Convert.ToDouble(table4.Compute("SUM(" + table4.Columns[i] + ")", null)), digits);
            }
            table4.Rows.InsertAt(row4, 0);
            foreach (DataRow row5 in table4.Rows)
            {
                resultTable.Rows.Add(row5.ItemArray);
            }
            resultTable = this.ConvertTableFldValueZeroToNull(resultTable, 1);
            return this.ConvertTJTableDWCodeCol(resultTable, 2);
        }

        public DataTable TJKYSCQK3ByXianXiang(string gxnd)
        {
            int digits = 2;
            DataTable resultTable = this.TJTableKYSCQK3();
            string cmdtxt = ("SELECT XIANG,LD_QS,TDJYQ,LMSYQ,DI_LEI,MIAN_JI,LIN_ZHONG,YOU_SHI_SZ,ZAO_LIN_LB FROM " + TABLE_ZLDATATABLE + " WHERE LEFT(GXSJ,6)" + gxnd) + " AND (LTRIM(RTRIM(ZAO_LIN_LB))='122')";
            DataTable table = this.GetTable(cmdtxt, "tjtable");
            table.DefaultView.Sort = "XIANG";
            DataTable table3 = table.DefaultView.ToTable(true, new string[] { "XIANG" });
            foreach (DataRow row in table3.Rows)
            {
                string str2 = row[0].ToString();
                DataTable dt = table.Clone();
                DataRow[] rowArray = table.Select("XIANG='" + str2 + "'");
                foreach (DataRow row2 in rowArray)
                {
                    dt.Rows.Add(row2.ItemArray);
                }
                double num2 = 0.0;
                num2 = Convert.ToDouble(dt.Compute("SUM(MIAN_JI)", null));
                double num3 = 0.0;
                if (dt.Select(this.zhulin).Length > 0)
                {
                    num3 = Convert.ToDouble(dt.Compute("SUM(MIAN_JI)", this.zhulin));
                }
                double num4 = 0.0;
                if (dt.Select(this.guoyoujjzaolin).Length > 0)
                {
                    num4 = Convert.ToDouble(dt.Compute("SUM(MIAN_JI)", this.guoyoujjzaolin));
                }
                double num5 = 0.0;
                if (dt.Select(this.jitijjzaolin).Length > 0)
                {
                    num5 = Convert.ToDouble(dt.Compute("SUM(MIAN_JI)", this.jitijjzaolin));
                }
                double num6 = num4 + num5;
                double num7 = 0.0;
                if (dt.Select(this.feigongjjzaolin).Length > 0)
                {
                    num7 = Convert.ToDouble(dt.Compute("SUM(MIAN_JI)", this.feigongjjzaolin));
                }
                double num8 = num6 + num7;
                double num9 = 0.0;
                double num10 = 0.0;
                double num11 = 0.0;
                double num12 = 0.0;
                double num13 = 0.0;
                double num14 = 0.0;
                double num15 = 0.0;
                DataTable dataTabeBySelRows = this.GetDataTabeBySelRows(dt, this.yongcailin);
                if (dataTabeBySelRows.Rows.Count > 0)
                {
                    if (dataTabeBySelRows.Select(this.shamu).Length > 0)
                    {
                        num9 = Convert.ToDouble(dataTabeBySelRows.Compute("SUM(MIAN_JI)", this.shamu));
                    }
                    if (dataTabeBySelRows.Select(this.songlei).Length > 0)
                    {
                        num10 = Convert.ToDouble(dataTabeBySelRows.Compute("SUM(MIAN_JI)", this.songlei));
                    }
                    if (dataTabeBySelRows.Select(this.anshu).Length > 0)
                    {
                        num11 = Convert.ToDouble(dataTabeBySelRows.Compute("SUM(MIAN_JI)", this.anshu));
                    }
                    if (dataTabeBySelRows.Select(this.xiangsi).Length > 0)
                    {
                        num12 = Convert.ToDouble(dataTabeBySelRows.Compute("SUM(MIAN_JI)", this.xiangsi));
                    }
                    if (dataTabeBySelRows.Select(this.yclqita).Length > 0)
                    {
                        num13 = Convert.ToDouble(dataTabeBySelRows.Compute("SUM(MIAN_JI)", this.yclqita));
                    }
                    if (dataTabeBySelRows.Select(this.yongcailin + " AND " + this.sushengfcl).Length > 0)
                    {
                        num14 = Convert.ToDouble(dataTabeBySelRows.Compute("SUM(MIAN_JI)", this.sushengfcl));
                    }
                    num15 = (((num9 + num10) + num11) + num12) + num13;
                }
                double num16 = 0.0;
                double num17 = 0.0;
                double num18 = 0.0;
                double num19 = 0.0;
                double num20 = 0.0;
                double num21 = 0.0;
                double num22 = 0.0;
                double num23 = 0.0;
                double num24 = 0.0;
                double num25 = 0.0;
                DataTable table6 = this.GetDataTabeBySelRows(dt, this.jingjilin);
                if (table6.Rows.Count > 0)
                {
                    if (table6.Select(this.youcha).Length > 0)
                    {
                        num16 = Convert.ToDouble(table6.Compute("SUM(MIAN_JI)", this.youcha));
                    }
                    if (table6.Select(this.youtong).Length > 0)
                    {
                        num17 = Convert.ToDouble(table6.Compute("SUM(MIAN_JI)", this.youtong));
                    }
                    if (table6.Select(this.bajiao).Length > 0)
                    {
                        num18 = Convert.ToDouble(table6.Compute("SUM(MIAN_JI)", this.bajiao));
                    }
                    if (table6.Select(this.yugui).Length > 0)
                    {
                        num19 = Convert.ToDouble(table6.Compute("SUM(MIAN_JI)", this.yugui));
                    }
                    if (table6.Select(this.hetao).Length > 0)
                    {
                        num20 = Convert.ToDouble(table6.Compute("SUM(MIAN_JI)", this.hetao));
                    }
                    if (table6.Select(this.banli).Length > 0)
                    {
                        num21 = Convert.ToDouble(table6.Compute("SUM(MIAN_JI)", this.banli));
                    }
                    if (table6.Select(this.yinxing).Length > 0)
                    {
                        num22 = Convert.ToDouble(table6.Compute("SUM(MIAN_JI)", this.yinxing));
                    }
                    if (table6.Select(this.guoshu).Length > 0)
                    {
                        num23 = Convert.ToDouble(table6.Compute("SUM(MIAN_JI)", this.guoshu));
                    }
                    if (table6.Select(this.jjlqita).Length > 0)
                    {
                        num24 = Convert.ToDouble(table6.Compute("SUM(MIAN_JI)", this.jjlqita));
                    }
                    num25 = (((((((num16 + num17) + num18) + num19) + num20) + num21) + num22) + num23) + num24;
                }
                double num26 = 0.0;
                if (dt.Select(this.fanghulin).Length > 0)
                {
                    num26 = Convert.ToDouble(dt.Compute("SUM(MIAN_JI)", this.fanghulin));
                }
                double num27 = 0.0;
                if (dt.Select(this.xintanlin).Length > 0)
                {
                    num27 = Convert.ToDouble(dt.Compute("SUM(MIAN_JI)", this.xintanlin));
                }
                double num28 = 0.0;
                if (dt.Select(this.teyonglin).Length > 0)
                {
                    num28 = Convert.ToDouble(dt.Compute("SUM(MIAN_JI)", this.teyonglin));
                }
                if (num2 > 0.0)
                {
                    DataRow row3 = resultTable.NewRow();
                    row3["TJDW"] = str2;
                    row3["ZLZJ"] = Math.Round(num8, digits);
                    row3["DCDXLMJ"] = Math.Round(num2, digits);
                    row3["ZhuLin"] = Math.Round(num3, digits);
                    row3["DCDXGYJJZLZJ"] = Math.Round(num6, digits);
                    row3["DCDXGYJJZL"] = Math.Round(num4, digits);
                    row3["DCDXJTJJZL"] = Math.Round(num5, digits);
                    row3["DCDXFGYJJZL"] = Math.Round(num7, digits);
                    row3["YCLZJ"] = Math.Round(num15, digits);
                    row3["ShaMu"] = Math.Round(num9, digits);
                    row3["SongShu"] = Math.Round(num10, digits);
                    row3["AnShu"] = Math.Round(num11, digits);
                    row3["XiangSi"] = Math.Round(num12, digits);
                    row3["YCLQT"] = Math.Round(num13, digits);
                    row3["SSFCL"] = Math.Round(num14, digits);
                    row3["JJLZJ"] = Math.Round(num25, digits);
                    row3["YouCha"] = Math.Round(num16, digits);
                    row3["YouTong"] = Math.Round(num17, digits);
                    row3["BaJiao"] = Math.Round(num18, digits);
                    row3["YuGui"] = Math.Round(num19, digits);
                    row3["HeTao"] = Math.Round(num20, digits);
                    row3["BanLi"] = Math.Round(num21, digits);
                    row3["YinXing"] = Math.Round(num22, digits);
                    row3["GuoShu"] = Math.Round(num23, digits);
                    row3["JJLQT"] = Math.Round(num24, digits);
                    row3["FHLMJ"] = Math.Round(num26, digits);
                    row3["XTLMJ"] = Math.Round(num27, digits);
                    row3["TZYTLMJ"] = Math.Round(num28, digits);
                    resultTable.Rows.Add(row3);
                }
            }
            if (resultTable.Rows.Count <= 0)
            {
                return resultTable;
            }
            string str3 = resultTable.Rows[0][0].ToString().Trim().Substring(0, 6);
            DataRow row4 = resultTable.NewRow();
            row4[0] = str3;
            for (int i = 1; i < resultTable.Columns.Count; i++)
            {
                row4[i] = Math.Round(Convert.ToDouble(resultTable.Compute("SUM(" + resultTable.Columns[i] + ")", null)), digits);
            }
            resultTable.Rows.InsertAt(row4, 0);
            resultTable = this.ConvertTableFldValueZeroToNull(resultTable, 1);
            return this.ConvertTJTableDWCodeCol(resultTable, 1);
        }

        public DataTable TJKYSCQK3ByXianXiangCun(string gxnd)
        {
            int num29;
            int digits = 2;
            DataTable resultTable = this.TJTableKYSCQK3();
            string cmdtxt = ("SELECT XIANG,CUN,LD_QS,TDJYQ,LMSYQ,DI_LEI,MIAN_JI,LIN_ZHONG,YOU_SHI_SZ,ZAO_LIN_LB FROM " + TABLE_ZLDATATABLE + " WHERE LEFT(GXSJ,6)" + gxnd) + " AND (ZAO_LIN_LB='122')";
            DataTable table = this.GetTable(cmdtxt, "tjtable");
            DataTable table3 = table.Clone();
            DataTable dt = table.Clone();
            table.DefaultView.Sort = "XIANG";
            DataTable table5 = table.DefaultView.ToTable(true, new string[] { "XIANG" });
            DataTable table6 = resultTable.Clone();
            DataTable table7 = resultTable.Clone();
            foreach (DataRow row in table5.Rows)
            {
                table3.Clear();
                string str2 = row[0].ToString();
                DataRow[] rowArray = table.Select("XIANG='" + str2 + "'");
                foreach (DataRow row2 in rowArray)
                {
                    table3.Rows.Add(row2.ItemArray);
                }
                table7.Clear();
                table3.DefaultView.Sort = "CUN";
                DataTable table8 = table3.DefaultView.ToTable(true, new string[] { "CUN" });
                foreach (DataRow row3 in table8.Rows)
                {
                    dt.Clear();
                    string str3 = row3["CUN"].ToString();
                    DataRow[] rowArray2 = table3.Select("CUN='" + str3 + "'");
                    foreach (DataRow row4 in rowArray2)
                    {
                        dt.Rows.Add(row4.ItemArray);
                    }
                    double num2 = 0.0;
                    num2 = Convert.ToDouble(dt.Compute("SUM(MIAN_JI)", null));
                    double num3 = 0.0;
                    if (dt.Select(this.zhulin).Length > 0)
                    {
                        num3 = Convert.ToDouble(dt.Compute("SUM(MIAN_JI)", this.zhulin));
                    }
                    double num4 = 0.0;
                    if (dt.Select(this.guoyoujjzaolin).Length > 0)
                    {
                        num4 = Convert.ToDouble(dt.Compute("SUM(MIAN_JI)", this.guoyoujjzaolin));
                    }
                    double num5 = 0.0;
                    if (dt.Select(this.jitijjzaolin).Length > 0)
                    {
                        num5 = Convert.ToDouble(dt.Compute("SUM(MIAN_JI)", this.jitijjzaolin));
                    }
                    double num6 = num4 + num5;
                    double num7 = 0.0;
                    if (dt.Select(this.feigongjjzaolin).Length > 0)
                    {
                        num7 = Convert.ToDouble(dt.Compute("SUM(MIAN_JI)", this.feigongjjzaolin));
                    }
                    double num8 = 0.0;
                    num8 = num6 + num7;
                    double num9 = 0.0;
                    double num10 = 0.0;
                    double num11 = 0.0;
                    double num12 = 0.0;
                    double num13 = 0.0;
                    double num14 = 0.0;
                    double num15 = 0.0;
                    DataTable dataTabeBySelRows = this.GetDataTabeBySelRows(dt, this.yongcailin);
                    if (dataTabeBySelRows.Rows.Count > 0)
                    {
                        if (dataTabeBySelRows.Select(this.shamu).Length > 0)
                        {
                            num9 = Convert.ToDouble(dataTabeBySelRows.Compute("SUM(MIAN_JI)", this.shamu));
                        }
                        if (dataTabeBySelRows.Select(this.songlei).Length > 0)
                        {
                            num10 = Convert.ToDouble(dataTabeBySelRows.Compute("SUM(MIAN_JI)", this.songlei));
                        }
                        if (dataTabeBySelRows.Select(this.anshu).Length > 0)
                        {
                            num11 = Convert.ToDouble(dataTabeBySelRows.Compute("SUM(MIAN_JI)", this.anshu));
                        }
                        if (dataTabeBySelRows.Select(this.xiangsi).Length > 0)
                        {
                            num12 = Convert.ToDouble(dataTabeBySelRows.Compute("SUM(MIAN_JI)", this.xiangsi));
                        }
                        if (dataTabeBySelRows.Select(this.yclqita).Length > 0)
                        {
                            num13 = Convert.ToDouble(dataTabeBySelRows.Compute("SUM(MIAN_JI)", this.yclqita));
                        }
                        if (dataTabeBySelRows.Select(this.sushengfcl).Length > 0)
                        {
                            num14 = Convert.ToDouble(dataTabeBySelRows.Compute("SUM(MIAN_JI)", this.sushengfcl));
                        }
                        num15 = (((num9 + num10) + num11) + num12) + num13;
                    }
                    double num16 = 0.0;
                    double num17 = 0.0;
                    double num18 = 0.0;
                    double num19 = 0.0;
                    double num20 = 0.0;
                    double num21 = 0.0;
                    double num22 = 0.0;
                    double num23 = 0.0;
                    double num24 = 0.0;
                    double num25 = 0.0;
                    DataTable table10 = this.GetDataTabeBySelRows(dt, this.jingjilin);
                    if (table10.Rows.Count > 0)
                    {
                        if (table10.Select(this.youcha).Length > 0)
                        {
                            num16 = Convert.ToDouble(table10.Compute("SUM(MIAN_JI)", this.youcha));
                        }
                        if (table10.Select(this.youtong).Length > 0)
                        {
                            num17 = Convert.ToDouble(table10.Compute("SUM(MIAN_JI)", this.youtong));
                        }
                        if (table10.Select(this.bajiao).Length > 0)
                        {
                            num18 = Convert.ToDouble(table10.Compute("SUM(MIAN_JI)", this.bajiao));
                        }
                        if (table10.Select(this.yugui).Length > 0)
                        {
                            num19 = Convert.ToDouble(table10.Compute("SUM(MIAN_JI)", this.yugui));
                        }
                        if (table10.Select(this.hetao).Length > 0)
                        {
                            num20 = Convert.ToDouble(table10.Compute("SUM(MIAN_JI)", this.hetao));
                        }
                        if (table10.Select(this.banli).Length > 0)
                        {
                            num21 = Convert.ToDouble(table10.Compute("SUM(MIAN_JI)", this.banli));
                        }
                        if (table10.Select(this.yinxing).Length > 0)
                        {
                            num22 = Convert.ToDouble(table10.Compute("SUM(MIAN_JI)", this.yinxing));
                        }
                        if (table10.Select(this.guoshu).Length > 0)
                        {
                            num23 = Convert.ToDouble(table10.Compute("SUM(MIAN_JI)", this.guoshu));
                        }
                        if (table10.Select(this.jjlqita).Length > 0)
                        {
                            num24 = Convert.ToDouble(table10.Compute("SUM(MIAN_JI)", this.jjlqita));
                        }
                        num25 = (((((((num16 + num17) + num18) + num19) + num20) + num21) + num22) + num23) + num24;
                    }
                    double num26 = 0.0;
                    if (dt.Select(this.fanghulin).Length > 0)
                    {
                        num26 = Convert.ToDouble(dt.Compute("SUM(MIAN_JI)", this.fanghulin));
                    }
                    double num27 = 0.0;
                    if (dt.Select(this.xintanlin).Length > 0)
                    {
                        num27 = Convert.ToDouble(dt.Compute("SUM(MIAN_JI)", this.xintanlin));
                    }
                    double num28 = 0.0;
                    if (dt.Select(this.teyonglin).Length > 0)
                    {
                        num28 = Convert.ToDouble(dt.Compute("SUM(MIAN_JI)", this.teyonglin));
                    }
                    if (num2 > 0.0)
                    {
                        DataRow row5 = table7.NewRow();
                        row5["TJDW"] = str3;
                        row5["ZLZJ"] = Math.Round(num8, digits);
                        row5["DCDXLMJ"] = Math.Round(num2, digits);
                        row5["ZhuLin"] = Math.Round(num3, digits);
                        row5["DCDXGYJJZLZJ"] = Math.Round(num6, digits);
                        row5["DCDXGYJJZL"] = Math.Round(num4, digits);
                        row5["DCDXJTJJZL"] = Math.Round(num5, digits);
                        row5["DCDXFGYJJZL"] = Math.Round(num7, digits);
                        row5["YCLZJ"] = Math.Round(num15, digits);
                        row5["ShaMu"] = Math.Round(num9, digits);
                        row5["SongShu"] = Math.Round(num10, digits);
                        row5["AnShu"] = Math.Round(num11, digits);
                        row5["XiangSi"] = Math.Round(num12, digits);
                        row5["YCLQT"] = Math.Round(num13, digits);
                        row5["SSFCL"] = Math.Round(num14, digits);
                        row5["JJLZJ"] = Math.Round(num25, digits);
                        row5["YouCha"] = Math.Round(num16, digits);
                        row5["YouTong"] = Math.Round(num17, digits);
                        row5["BaJiao"] = Math.Round(num18, digits);
                        row5["YuGui"] = Math.Round(num19, digits);
                        row5["HeTao"] = Math.Round(num20, digits);
                        row5["BanLi"] = Math.Round(num21, digits);
                        row5["YinXing"] = Math.Round(num22, digits);
                        row5["GuoShu"] = Math.Round(num23, digits);
                        row5["JJLQT"] = Math.Round(num24, digits);
                        row5["FHLMJ"] = Math.Round(num26, digits);
                        row5["XTLMJ"] = Math.Round(num27, digits);
                        row5["TZYTLMJ"] = Math.Round(num28, digits);
                        table7.Rows.Add(row5);
                    }
                }
                if (table7.Rows.Count > 0)
                {
                    DataRow row6 = table7.NewRow();
                    row6[0] = str2;
                    num29 = 1;
                    while (num29 < table7.Columns.Count)
                    {
                        row6[num29] = Math.Round(Convert.ToDouble(table7.Compute("SUM(" + table7.Columns[num29] + ")", null)), digits);
                        num29++;
                    }
                    table7.Rows.InsertAt(row6, 0);
                    table6.Rows.Add(row6.ItemArray);
                    foreach (DataRow row7 in table7.Rows)
                    {
                        resultTable.Rows.Add(row7.ItemArray);
                    }
                }
            }
            if (resultTable.Rows.Count <= 0)
            {
                return resultTable;
            }
            string str4 = resultTable.Rows[0][0].ToString().Trim().Substring(0, 6);
            DataRow row8 = resultTable.NewRow();
            row8[0] = str4;
            for (num29 = 1; num29 < resultTable.Columns.Count; num29++)
            {
                row8[num29] = Math.Round(Convert.ToDouble(table6.Compute("SUM(" + table6.Columns[num29] + ")", null)), digits);
            }
            resultTable.Rows.InsertAt(row8, 0);
            resultTable = this.ConvertTableFldValueZeroToNull(resultTable, 1);
            return this.ConvertTJTableDWCodeCol(resultTable, 2);
        }

        public DataTable TJKYSCQK4ByXiangCun(string gxnd, string xiangcode)
        {
            int num6;
            int digits = 2;
            DataTable resultTable = this.TJTableKYSCQK4();
            string cmdtxt = "SELECT CUN,MIAN_JI,YOU_SHI_SZ,ZAO_LIN_LB,SSZZS FROM " + TABLE_ZLDATATABLE + " WHERE LEFT(GXSJ,6)" + gxnd + " AND (XIANG='" + xiangcode + "')";
            DataTable table = this.GetTable(cmdtxt, "tjtable");
            DataTable table3 = table.Clone();
            DataTable table4 = resultTable.Clone();
            table4.Clear();
            table.DefaultView.Sort = "CUN";
            DataTable table5 = table.DefaultView.ToTable(true, new string[] { "CUN" });
            foreach (DataRow row in table5.Rows)
            {
                table3.Clear();
                string str2 = row["CUN"].ToString();
                DataRow[] rowArray = table.Select("CUN='" + str2 + "'");
                foreach (DataRow row2 in rowArray)
                {
                    table3.Rows.Add(row2.ItemArray);
                }
                if (table3.Select(this.spszs).Length > 0)
                {
                }
                double num3 = 0.0;
                if (table3.Select(this.youlinfuyu).Length > 0)
                {
                    num3 = Convert.ToDouble(table3.Compute("SUM(MIAN_JI)", this.youlinfuyu));
                }
                double num4 = 0.0;
                if (table3.Select(this.chenglin).Length > 0)
                {
                    num4 = Convert.ToDouble(table3.Compute("SUM(MIAN_JI)", this.chenglin));
                }
                double num5 = 0.0;
                DataRow row3 = table4.NewRow();
                row3["TJDW"] = str2;
                num6 = 1;
                while (num6 < table4.Columns.Count)
                {
                    row3[num6] = 0;
                    num6++;
                }
                row3["YLFYSJMJ"] = Math.Round(num3, digits);
                row3["CLFYMJZJ"] = Math.Round(num4, digits);
                row3["ZYLFYMJ"] = Math.Round(num5, digits);
                if ((num4 > 0.0) || (num3 > 0.0))
                {
                    table4.Rows.Add(row3);
                }
            }
            if (table4.Rows.Count <= 0)
            {
                return resultTable;
            }
            DataRow row4 = table4.NewRow();
            row4[0] = xiangcode;
            for (num6 = 1; num6 < table4.Columns.Count; num6++)
            {
                row4[num6] = Math.Round(Convert.ToDouble(table4.Compute("SUM(" + table4.Columns[num6] + ")", null)), digits);
            }
            table4.Rows.InsertAt(row4, 0);
            foreach (DataRow row5 in table4.Rows)
            {
                resultTable.Rows.Add(row5.ItemArray);
            }
            resultTable = this.ConvertTableFldValueZeroToNull(resultTable, 1);
            return this.ConvertTJTableDWCodeCol(resultTable, 2);
        }

        public DataTable TJKYSCQK4ByXianXiang(string gxnd)
        {
            int num6;
            int digits = 2;
            DataTable resultTable = this.TJTableKYSCQK4();
            string cmdtxt = "SELECT XIANG,MIAN_JI,YOU_SHI_SZ,ZAO_LIN_LB,SSZZS FROM " + TABLE_ZLDATATABLE + " WHERE LEFT(GXSJ,6)" + gxnd;
            DataTable table = this.GetTable(cmdtxt, "tjtable");
            table.DefaultView.Sort = "XIANG";
            DataTable table3 = table.DefaultView.ToTable(true, new string[] { "XIANG" });
            foreach (DataRow row in table3.Rows)
            {
                string str2 = row[0].ToString();
                DataTable table4 = table.Clone();
                DataRow[] rowArray = table.Select("XIANG='" + str2 + "'");
                foreach (DataRow row2 in rowArray)
                {
                    table4.Rows.Add(row2.ItemArray);
                }
                if (table4.Select(this.spszs).Length > 0)
                {
                }
                double num3 = 0.0;
                if (table4.Select(this.youlinfuyu).Length > 0)
                {
                    num3 = Convert.ToDouble(table4.Compute("SUM(MIAN_JI)", this.youlinfuyu));
                }
                double num4 = 0.0;
                if (table4.Select(this.chenglin).Length > 0)
                {
                    num4 = Convert.ToDouble(table4.Compute("SUM(MIAN_JI)", this.chenglin));
                }
                double num5 = 0.0;
                DataRow row3 = resultTable.NewRow();
                row3["TJDW"] = str2;
                num6 = 1;
                while (num6 < resultTable.Columns.Count)
                {
                    row3[num6] = 0;
                    num6++;
                }
                row3["YLFYSJMJ"] = Math.Round(num3, digits);
                row3["CLFYMJZJ"] = Math.Round(num4, digits);
                row3["ZYLFYMJ"] = Math.Round(num5, digits);
                if ((num4 > 0.0) || (num3 > 0.0))
                {
                    resultTable.Rows.Add(row3);
                }
            }
            if (resultTable.Rows.Count <= 0)
            {
                return resultTable;
            }
            string str3 = resultTable.Rows[0][0].ToString().Trim().Substring(0, 6);
            DataRow row4 = resultTable.NewRow();
            row4[0] = str3;
            for (num6 = 1; num6 < resultTable.Columns.Count; num6++)
            {
                row4[num6] = Math.Round(Convert.ToDouble(resultTable.Compute("SUM(" + resultTable.Columns[num6] + ")", null)), digits);
            }
            resultTable.Rows.InsertAt(row4, 0);
            resultTable = this.ConvertTableFldValueZeroToNull(resultTable, 1);
            return this.ConvertTJTableDWCodeCol(resultTable, 1);
        }

        public DataTable TJKYSCQK4ByXianXiangCun(string gxnd)
        {
            int num6;
            int digits = 2;
            DataTable resultTable = this.TJTableKYSCQK4();
            string cmdtxt = "SELECT XIANG,CUN,MIAN_JI,YOU_SHI_SZ,ZAO_LIN_LB,SSZZS FROM " + TABLE_ZLDATATABLE + " WHERE LEFT(GXSJ,6)" + gxnd;
            DataTable table = this.GetTable(cmdtxt, "tjtable");
            table.DefaultView.Sort = "XIANG";
            DataTable table3 = table.DefaultView.ToTable(true, new string[] { "XIANG" });
            DataTable table4 = table.Clone();
            DataTable table5 = table.Clone();
            DataTable table6 = resultTable.Clone();
            DataTable table7 = resultTable.Clone();
            foreach (DataRow row in table3.Rows)
            {
                table4.Clear();
                string str2 = row[0].ToString();
                DataRow[] rowArray = table.Select("XIANG='" + str2 + "'");
                foreach (DataRow row2 in rowArray)
                {
                    table4.Rows.Add(row2.ItemArray);
                }
                table7.Clear();
                table4.DefaultView.Sort = "CUN";
                DataTable table8 = table4.DefaultView.ToTable(true, new string[] { "CUN" });
                foreach (DataRow row3 in table8.Rows)
                {
                    table5.Clear();
                    string str3 = row3["CUN"].ToString();
                    DataRow[] rowArray2 = table4.Select("CUN='" + str3 + "'");
                    foreach (DataRow row4 in rowArray2)
                    {
                        table5.Rows.Add(row4.ItemArray);
                    }
                    if (table4.Select(this.spszs).Length > 0)
                    {
                    }
                    double num3 = 0.0;
                    if (table5.Select(this.youlinfuyu).Length > 0)
                    {
                        num3 = Convert.ToDouble(table5.Compute("SUM(MIAN_JI)", this.youlinfuyu));
                    }
                    double num4 = 0.0;
                    if (table5.Select(this.chenglin).Length > 0)
                    {
                        num4 = Convert.ToDouble(table5.Compute("SUM(MIAN_JI)", this.chenglin));
                    }
                    double num5 = 0.0;
                    DataRow row5 = table7.NewRow();
                    row5["TJDW"] = str3;
                    num6 = 1;
                    while (num6 < table7.Columns.Count)
                    {
                        row5[num6] = 0;
                        num6++;
                    }
                    row5["YLFYSJMJ"] = Math.Round(num3, digits);
                    row5["CLFYMJZJ"] = Math.Round(num4, digits);
                    row5["ZYLFYMJ"] = Math.Round(num5, digits);
                    if ((num4 > 0.0) || (num3 > 0.0))
                    {
                        table7.Rows.Add(row5);
                    }
                }
                if (table7.Rows.Count > 0)
                {
                    DataRow row6 = table7.NewRow();
                    row6[0] = str2;
                    num6 = 1;
                    while (num6 < table7.Columns.Count)
                    {
                        row6[num6] = Math.Round(Convert.ToDouble(table7.Compute("SUM(" + table7.Columns[num6] + ")", null)), digits);
                        num6++;
                    }
                    table7.Rows.InsertAt(row6, 0);
                    table6.Rows.Add(row6.ItemArray);
                    foreach (DataRow row7 in table7.Rows)
                    {
                        resultTable.Rows.Add(row7.ItemArray);
                    }
                }
            }
            if (resultTable.Rows.Count <= 0)
            {
                return resultTable;
            }
            string str4 = resultTable.Rows[0][0].ToString().Trim().Substring(0, 6);
            DataRow row8 = resultTable.NewRow();
            row8[0] = str4;
            for (num6 = 1; num6 < resultTable.Columns.Count; num6++)
            {
                row8[num6] = Math.Round(Convert.ToDouble(table6.Compute("SUM(" + table6.Columns[num6] + ")", null)), digits);
            }
            resultTable.Rows.InsertAt(row8, 0);
            resultTable = this.ConvertTableFldValueZeroToNull(resultTable, 1);
            return this.ConvertTJTableDWCodeCol(resultTable, 2);
        }

        public DataTable TJSMHJDByXiangCun(string gxnd, string xiangcode)
        {
            int num8;
            int digits = 2;
            DataTable table = this.TJTableSMHZLMJ();
            string cmdtxt = ("SELECT XIANG,CUN,MIAN_JI,ZAO_LIN_LB,ZJLY,ZYTZJF,DFTZJF FROM " + TABLE_ZLDATATABLE + " WHERE LEFT(GXSJ,6) " + gxnd) + " AND (XIANG='" + xiangcode + "') AND LTRIM(RTRIM(G_CHENG_LB))='42'";
            DataTable table2 = this.GetTable(cmdtxt, "tjtable");
            DataTable table3 = table.Clone();
            DataTable table4 = table2.Clone();
            table2.DefaultView.Sort = "CUN";
            DataTable table5 = table2.DefaultView.ToTable(true, new string[] { "CUN" });
            table3.Clear();
            foreach (DataRow row in table5.Rows)
            {
                table4.Clear();
                DataRow[] rowArray = table2.Select("CUN='" + row["CUN"].ToString() + "'");
                foreach (DataRow row2 in rowArray)
                {
                    if (row2["ZYTZJF"] == DBNull.Value)
                    {
                        row2["ZYTZJF"] = 0;
                    }
                    if (row2["DFTZJF"] == DBNull.Value)
                    {
                        row2["DFTZJF"] = 0;
                    }
                    table4.Rows.Add(row2.ItemArray);
                }
                double num2 = 0.0;
                double num3 = 0.0;
                num2 = Convert.ToDouble(table4.Compute("SUM(ZYTZJF)", null)) / 10000.0;
                num3 = Convert.ToDouble(table4.Compute("SUM(DFTZJF)", null)) / 10000.0;
                double num4 = 0.0;
                if (table4.Select(this.rgzl).Length > 0)
                {
                    num4 = Math.Round(Convert.ToDouble(table4.Compute("SUM(MIAN_JI)", this.rgzl)), digits);
                }
                double num5 = 0.0;
                if (table4.Select(this.fengshanyulin).Length > 0)
                {
                    num5 = Math.Round(Convert.ToDouble(table4.Compute("SUM(MIAN_JI)", this.fengshanyulin)), digits);
                }
                double num6 = 0.0;
                if (table4.Select(this.zbghsql).Length > 0)
                {
                    num6 = Math.Round(Convert.ToDouble(table4.Compute("SUM(MIAN_JI)", this.zbghsql)), digits);
                }
                double num7 = 0.0;
                num7 = (num4 + num5) + num6;
                DataRow row3 = table3.NewRow();
                num8 = 1;
                while (num8 < table.Columns.Count)
                {
                    row3[num8] = 0;
                    num8++;
                }
                row3["TJDW"] = xiangcode;
                row3["ZYYWC"] = num2;
                row3["DFYWC"] = num3;
                row3["WCMJ"] = num7;
                row3["WCRG"] = num4;
                row3["WCFY"] = num5;
                row3["WCZBGHMJ"] = num6;
                table3.Rows.Add(row3);
            }
            if (table3.Rows.Count > 0)
            {
                DataRow row4 = table3.NewRow();
                row4[0] = xiangcode;
                for (num8 = 1; num8 < (table3.Columns.Count - 1); num8++)
                {
                    row4[num8] = Math.Round(Convert.ToDouble(table3.Compute("SUM(" + table3.Columns[num8] + ")", null)), digits);
                }
                table3.Rows.InsertAt(row4, 0);
                foreach (DataRow row5 in table3.Rows)
                {
                    table.Rows.Add(row5.ItemArray);
                }
            }
            return table;
        }

        public DataTable TJSMHJDByXianXiang(string gxnd)
        {
            int num8;
            int digits = 2;
            DataTable resultTable = this.TJTableSMHZLMJ();
            string cmdtxt = ("SELECT XIANG,MIAN_JI,ZAO_LIN_LB,ZJLY,ZYTZJF,DFTZJF FROM " + TABLE_ZLDATATABLE + " WHERE LEFT(GXSJ,6) " + gxnd) + "  AND LTRIM(RTRIM(G_CHENG_LB))='42'";
            DataTable table = this.GetTable(cmdtxt, "tjtable");
            table.DefaultView.Sort = "XIANG";
            DataTable table3 = table.DefaultView.ToTable(true, new string[] { "XIANG" });
            foreach (DataRow row in table3.Rows)
            {
                string str2 = row[0].ToString();
                DataTable table4 = table.Clone();
                DataRow[] rowArray = table.Select("XIANG='" + str2 + "'");
                foreach (DataRow row2 in rowArray)
                {
                    if (row2["ZYTZJF"] == DBNull.Value)
                    {
                        row2["ZYTZJF"] = 0;
                    }
                    if (row2["DFTZJF"] == DBNull.Value)
                    {
                        row2["DFTZJF"] = 0;
                    }
                    table4.Rows.Add(row2.ItemArray);
                }
                double num2 = 0.0;
                double num3 = 0.0;
                num2 = Convert.ToDouble(table4.Compute("SUM(ZYTZJF)", null)) / 10000.0;
                num3 = Convert.ToDouble(table4.Compute("SUM(DFTZJF)", null)) / 10000.0;
                double num4 = 0.0;
                if (table4.Select(this.rgzl).Length > 0)
                {
                    num4 = Math.Round(Convert.ToDouble(table4.Compute("SUM(MIAN_JI)", this.rgzl)), digits);
                }
                double num5 = 0.0;
                if (table4.Select(this.fengshanyulin).Length > 0)
                {
                    num5 = Math.Round(Convert.ToDouble(table4.Compute("SUM(MIAN_JI)", this.fengshanyulin)), digits);
                }
                double num6 = 0.0;
                if (table4.Select(this.zbghsql).Length > 0)
                {
                    num6 = Math.Round(Convert.ToDouble(table4.Compute("SUM(MIAN_JI)", this.zbghsql)), digits);
                }
                double num7 = 0.0;
                num7 = (num4 + num5) + num6;
                DataRow row3 = resultTable.NewRow();
                num8 = 1;
                while (num8 < resultTable.Columns.Count)
                {
                    row3[num8] = 0;
                    num8++;
                }
                row3["TJDW"] = str2;
                row3["ZYYWC"] = num2;
                row3["DFYWC"] = num3;
                row3["WCMJ"] = num7;
                row3["WCRG"] = num4;
                row3["WCFY"] = num5;
                row3["WCZBGHMJ"] = num6;
                resultTable.Rows.Add(row3);
            }
            if (resultTable.Rows.Count <= 0)
            {
                return resultTable;
            }
            string str3 = resultTable.Rows[0][0].ToString().Trim().Substring(0, 6);
            DataRow row4 = resultTable.NewRow();
            row4[0] = str3;
            for (num8 = 1; num8 < (resultTable.Columns.Count - 1); num8++)
            {
                row4[num8] = Math.Round(Convert.ToDouble(resultTable.Compute("SUM(" + resultTable.Columns[num8] + ")", null)), digits);
            }
            resultTable.Rows.InsertAt(row4, 0);
            resultTable = this.ConvertTableFldValueZeroToNull(resultTable, 1);
            return this.ConvertTJTableDWCodeCol(resultTable, 1);
        }

        public DataTable TJSMHJDByXianXiangCun(string gxnd)
        {
            int num8;
            int digits = 2;
            DataTable resultTable = this.TJTableSMHZLMJ();
            string cmdtxt = ("SELECT XIANG,CUN,MIAN_JI,ZAO_LIN_LB,ZJLY,ZYTZJF,DFTZJF FROM " + TABLE_ZLDATATABLE + " WHERE LEFT(GXSJ,6) " + gxnd) + "  AND LTRIM(RTRIM(G_CHENG_LB))='42'";
            DataTable table = this.GetTable(cmdtxt, "tjtable");
            table.DefaultView.Sort = "XIANG";
            DataTable table3 = table.DefaultView.ToTable(true, new string[] { "XIANG" });
            DataTable table4 = resultTable.Clone();
            DataTable table5 = resultTable.Clone();
            foreach (DataRow row in table3.Rows)
            {
                string str2 = row[0].ToString();
                DataTable table6 = table.Clone();
                DataRow[] rowArray = table.Select("XIANG='" + str2 + "'");
                foreach (DataRow row2 in rowArray)
                {
                    if (row2["ZYTZJF"] == DBNull.Value)
                    {
                        row2["ZYTZJF"] = 0;
                    }
                    if (row2["DFTZJF"] == DBNull.Value)
                    {
                        row2["DFTZJF"] = 0;
                    }
                    table6.Rows.Add(row2.ItemArray);
                }
                DataTable table7 = table.Clone();
                table6.DefaultView.Sort = "CUN";
                DataTable table8 = table6.DefaultView.ToTable(true, new string[] { "CUN" });
                table5.Clear();
                foreach (DataRow row3 in table8.Rows)
                {
                    table7.Clear();
                    DataRow[] rowArray2 = table6.Select("CUN='" + row3["CUN"].ToString() + "'");
                    foreach (DataRow row4 in rowArray2)
                    {
                        table7.Rows.Add(row4.ItemArray);
                    }
                    double num2 = 0.0;
                    double num3 = 0.0;
                    num2 = Convert.ToDouble(table7.Compute("SUM(ZYTZJF)", null)) / 10000.0;
                    num3 = Convert.ToDouble(table7.Compute("SUM(DFTZJF)", null)) / 10000.0;
                    double num4 = 0.0;
                    if (table7.Select(this.rgzl).Length > 0)
                    {
                        num4 = Math.Round(Convert.ToDouble(table7.Compute("SUM(MIAN_JI)", this.rgzl)), digits);
                    }
                    double num5 = 0.0;
                    if (table7.Select(this.fengshanyulin).Length > 0)
                    {
                        num5 = Math.Round(Convert.ToDouble(table7.Compute("SUM(MIAN_JI)", this.fengshanyulin)), digits);
                    }
                    double num6 = 0.0;
                    if (table7.Select(this.zbghsql).Length > 0)
                    {
                        num6 = Math.Round(Convert.ToDouble(table7.Compute("SUM(MIAN_JI)", this.zbghsql)), digits);
                    }
                    double num7 = 0.0;
                    num7 = (num4 + num5) + num6;
                    DataRow row5 = table5.NewRow();
                    num8 = 1;
                    while (num8 < resultTable.Columns.Count)
                    {
                        row5[num8] = 0;
                        num8++;
                    }
                    row5["TJDW"] = str2;
                    row5["ZYYWC"] = num2;
                    row5["DFYWC"] = num3;
                    row5["WCMJ"] = num7;
                    row5["WCRG"] = num4;
                    row5["WCFY"] = num5;
                    row5["WCZBGHMJ"] = num6;
                    table5.Rows.Add(row5);
                }
                if (table5.Rows.Count > 0)
                {
                    DataRow row6 = table5.NewRow();
                    row6[0] = str2;
                    num8 = 1;
                    while (num8 < (table5.Columns.Count - 1))
                    {
                        row6[num8] = Math.Round(Convert.ToDouble(table5.Compute("SUM(" + table5.Columns[num8] + ")", null)), digits);
                        num8++;
                    }
                    table5.Rows.InsertAt(row6, 0);
                    table4.Rows.Add(row6.ItemArray);
                    foreach (DataRow row7 in table5.Rows)
                    {
                        resultTable.Rows.Add(row7.ItemArray);
                    }
                }
            }
            if (resultTable.Rows.Count <= 0)
            {
                return resultTable;
            }
            string str4 = resultTable.Rows[0][0].ToString().Trim().Substring(0, 6);
            DataRow row8 = resultTable.NewRow();
            row8[0] = str4;
            for (num8 = 1; num8 < (resultTable.Columns.Count - 1); num8++)
            {
                row8[num8] = Math.Round(Convert.ToDouble(table4.Compute("SUM(" + table4.Columns[num8] + ")", null)), digits);
            }
            resultTable.Rows.InsertAt(row8, 0);
            resultTable = this.ConvertTableFldValueZeroToNull(resultTable, 1);
            return this.ConvertTJTableDWCodeCol(resultTable, 1);
        }

        private DataTable TJTableB5HSHDZLMJ()
        {
            DataTable table = new DataTable("ResultTable");
            table.Columns.Add("TJDW", typeof(string));
            table.Columns.Add("NDZLHJ", typeof(double));
            table.Columns.Add("LYZDGCHJ", typeof(double));
            table.Columns.Add("TRLZYBHGC", typeof(double));
            table.Columns.Add("TGHLGCHJ", typeof(double));
            table.Columns.Add("TGDZL", typeof(double));
            table.Columns.Add("TGPTHSHDZL", typeof(double));
            table.Columns.Add("JJFSYZLGCMJ", typeof(double));
            table.Columns.Add("SBCJZLGCHJ", typeof(double));
            table.Columns.Add("SBFHGCHJ", typeof(double));
            table.Columns.Add("SBFHGCZYTZWCMJ", typeof(double));
            table.Columns.Add("CJLYFHLHJ", typeof(double));
            table.Columns.Add("CJLYFHLZYTZWCHJ", typeof(double));
            table.Columns.Add("YHFHLGCHJ", typeof(double));
            table.Columns.Add("YHFHLZYTZWCMJ", typeof(double));
            table.Columns.Add("ZJLYFHLHJ", typeof(double));
            table.Columns.Add("ZJLYFHLZYTZWCMJ", typeof(double));
            table.Columns.Add("THSLHHJ", typeof(double));
            table.Columns.Add("THSLHZYTZWWCMJ", typeof(double));
            table.Columns.Add("PYLHHJ", typeof(double));
            table.Columns.Add("PYLHZYTZWWCMJ", typeof(double));
            table.Columns.Add("SSFCYCLHJ", typeof(double));
            table.Columns.Add("SSFCYCLZYTZWCMJ", typeof(double));
            table.Columns.Add("TGHLZYCMJ", typeof(double));
            table.Columns.Add("YBZLMJ", typeof(double));
            return table;
        }

        private DataTable TJTableB6NBZLMJ()
        {
            DataTable table = new DataTable("ResultTable");
            table.Columns.Add("TJDW", typeof(string));
            table.Columns.Add("ZZLMJ", typeof(double));
            table.Columns.Add("RGZLMJHJ", typeof(double));
            table.Columns.Add("RGZLTGMJ", typeof(double));
            table.Columns.Add("RGZLZFMJ", typeof(double));
            table.Columns.Add("RGZLHFMJ", typeof(double));
            table.Columns.Add("JDGXMJ", typeof(double));
            table.Columns.Add("DGMJ", typeof(double));
            table.Columns.Add("FSYLMJ", typeof(double));
            table.Columns.Add("FSYLZFL", typeof(double));
            table.Columns.Add("FSYLTG", typeof(double));
            table.Columns.Add("SFLMJ", typeof(double));
            table.Columns.Add("YWZSZS", typeof(double));
            table.Columns.Add("STBCMJ", typeof(double));
            table.Columns.Add("NDZLMJ", typeof(double));
            return table;
        }

        private DataTable TJTableHFLZLMJ()
        {
            DataTable table = new DataTable("ResultTable");
            table.Columns.Add("TJDW", typeof(string));
            table.Columns.Add("ZYJH", typeof(double));
            table.Columns.Add("ZYYDW", typeof(double));
            table.Columns.Add("ZYYWC", typeof(double));
            table.Columns.Add("DFJH", typeof(double));
            table.Columns.Add("DFYDW", typeof(double));
            table.Columns.Add("DFYWC", typeof(double));
            table.Columns.Add("JHMJ", typeof(double));
            table.Columns.Add("JHRGMJ", typeof(double));
            table.Columns.Add("JHFYMJ", typeof(double));
            table.Columns.Add("WCMJ", typeof(double));
            table.Columns.Add("WCRG", typeof(double));
            table.Columns.Add("WCFY", typeof(double));
            table.Columns.Add("WCQK", typeof(string));
            return table;
        }

        private DataTable TJTableKYSCQK1()
        {
            DataTable table = new DataTable("ResultTable");
            table.Columns.Add("TJDW", typeof(string));
            table.Columns.Add("HSZLZJ", typeof(double));
            table.Columns.Add("RGZLZJ", typeof(double));
            table.Columns.Add("TGDZL", typeof(double));
            table.Columns.Add("ZLMJ", typeof(double));
            table.Columns.Add("FBZL", typeof(double));
            table.Columns.Add("WLDSLDXF", typeof(double));
            table.Columns.Add("GYJJZLZJ", typeof(double));
            table.Columns.Add("GYJJZL", typeof(double));
            table.Columns.Add("JTJJZL", typeof(double));
            table.Columns.Add("FGYJJZL", typeof(double));
            table.Columns.Add("YCLZJ", typeof(double));
            table.Columns.Add("ShaMu", typeof(double));
            table.Columns.Add("SongShu", typeof(double));
            table.Columns.Add("AnShu", typeof(double));
            table.Columns.Add("XiangSi", typeof(double));
            table.Columns.Add("YCLQT", typeof(double));
            table.Columns.Add("SSFCL", typeof(double));
            table.Columns.Add("JJLZJ", typeof(double));
            table.Columns.Add("YouCha", typeof(double));
            table.Columns.Add("YouTong", typeof(double));
            table.Columns.Add("BaJiao", typeof(double));
            table.Columns.Add("YuGui", typeof(double));
            table.Columns.Add("HeTao", typeof(double));
            table.Columns.Add("BanLi", typeof(double));
            table.Columns.Add("YinXing", typeof(double));
            table.Columns.Add("GuoShu", typeof(double));
            table.Columns.Add("JJLQT", typeof(double));
            table.Columns.Add("FHLMJ", typeof(double));
            table.Columns.Add("XTLMJ", typeof(double));
            table.Columns.Add("TZYTLMJ", typeof(double));
            return table;
        }

        private DataTable TJTableKYSCQK2()
        {
            DataTable table = new DataTable("ResultTable");
            table.Columns.Add("TJDW", typeof(string));
            table.Columns.Add("YLDZLZJ", typeof(double));
            table.Columns.Add("LGXZL", typeof(double));
            table.Columns.Add("FBYL", typeof(double));
            table.Columns.Add("YLDXF", typeof(double));
            table.Columns.Add("JDGXZJ", typeof(double));
            table.Columns.Add("GXZLZMJ", typeof(double));
            table.Columns.Add("JDGXZLMJ", typeof(double));
            table.Columns.Add("RGCJGXMJ", typeof(double));
            table.Columns.Add("JDGXGYJJZLZJ", typeof(double));
            table.Columns.Add("JDGXGYJJZL", typeof(double));
            table.Columns.Add("JDGXJTJJZL", typeof(double));
            table.Columns.Add("JDGXFGYJJZL", typeof(double));
            table.Columns.Add("YCLZJ", typeof(double));
            table.Columns.Add("ShaMu", typeof(double));
            table.Columns.Add("SongShu", typeof(double));
            table.Columns.Add("AnShu", typeof(double));
            table.Columns.Add("XiangSi", typeof(double));
            table.Columns.Add("YCLQT", typeof(double));
            table.Columns.Add("SSFCL", typeof(double));
            table.Columns.Add("JJLZJ", typeof(double));
            table.Columns.Add("YouCha", typeof(double));
            table.Columns.Add("YouTong", typeof(double));
            table.Columns.Add("BaJiao", typeof(double));
            table.Columns.Add("YuGui", typeof(double));
            table.Columns.Add("HeTao", typeof(double));
            table.Columns.Add("BanLi", typeof(double));
            table.Columns.Add("YinXing", typeof(double));
            table.Columns.Add("GuoShu", typeof(double));
            table.Columns.Add("JJLQT", typeof(double));
            table.Columns.Add("FHLMJ", typeof(double));
            table.Columns.Add("XTLMJ", typeof(double));
            table.Columns.Add("TZYTLMJ", typeof(double));
            return table;
        }

        private DataTable TJTableKYSCQK3()
        {
            DataTable table = new DataTable("ResultTable");
            table.Columns.Add("TJDW", typeof(string));
            table.Columns.Add("ZLZJ", typeof(double));
            table.Columns.Add("DCDXLMJ", typeof(double));
            table.Columns.Add("ZhuLin", typeof(double));
            table.Columns.Add("DCDXGYJJZLZJ", typeof(double));
            table.Columns.Add("DCDXGYJJZL", typeof(double));
            table.Columns.Add("DCDXJTJJZL", typeof(double));
            table.Columns.Add("DCDXFGYJJZL", typeof(double));
            table.Columns.Add("YCLZJ", typeof(double));
            table.Columns.Add("ShaMu", typeof(double));
            table.Columns.Add("SongShu", typeof(double));
            table.Columns.Add("AnShu", typeof(double));
            table.Columns.Add("XiangSi", typeof(double));
            table.Columns.Add("YCLQT", typeof(double));
            table.Columns.Add("SSFCL", typeof(double));
            table.Columns.Add("JJLZJ", typeof(double));
            table.Columns.Add("YouCha", typeof(double));
            table.Columns.Add("YouTong", typeof(double));
            table.Columns.Add("BaJiao", typeof(double));
            table.Columns.Add("YuGui", typeof(double));
            table.Columns.Add("HeTao", typeof(double));
            table.Columns.Add("BanLi", typeof(double));
            table.Columns.Add("YinXing", typeof(double));
            table.Columns.Add("GuoShu", typeof(double));
            table.Columns.Add("JJLQT", typeof(double));
            table.Columns.Add("FHLMJ", typeof(double));
            table.Columns.Add("XTLMJ", typeof(double));
            table.Columns.Add("TZYTLMJ", typeof(double));
            return table;
        }

        private DataTable TJTableKYSCQK4()
        {
            DataTable table = new DataTable("ResultTable");
            table.Columns.Add("TJDW", typeof(string));
            table.Columns.Add("SPZS", typeof(double));
            table.Columns.Add("NMSYFYMJ", typeof(double));
            table.Columns.Add("YLFYZYMJ", typeof(double));
            table.Columns.Add("YLFYSJMJ", typeof(double));
            table.Columns.Add("CLFYMJZJ", typeof(double));
            table.Columns.Add("ZYLFYMJ", typeof(double));
            table.Columns.Add("FYGZCCLZJ", typeof(double));
            table.Columns.Add("ZYLFYGZCCL", typeof(double));
            table.Columns.Add("LMZZCJL", typeof(double));
            table.Columns.Add("YMMJHJ", typeof(double));
            table.Columns.Add("BNXZYMMJ", typeof(double));
            table.Columns.Add("DNMMCL", typeof(double));
            table.Columns.Add("NMSYMSLMJ", typeof(double));
            table.Columns.Add("NMSYZZYMJ", typeof(double));
            table.Columns.Add("DNZFMJ", typeof(double));
            table.Columns.Add("DNDCLGZFMJ", typeof(double));
            table.Columns.Add("DNFYJFMJ", typeof(double));
            table.Columns.Add("DNLCYLJDZLMJ", typeof(double));
            return table;
        }

        private DataTable TJTableSMHZLMJ()
        {
            DataTable table = new DataTable("ResultTable");
            table.Columns.Add("TJDW", typeof(string));
            table.Columns.Add("ZYJH", typeof(double));
            table.Columns.Add("ZYYDW", typeof(double));
            table.Columns.Add("ZYYWC", typeof(double));
            table.Columns.Add("DFJH", typeof(double));
            table.Columns.Add("DFYDW", typeof(double));
            table.Columns.Add("DFYWC", typeof(double));
            table.Columns.Add("JHMJ", typeof(double));
            table.Columns.Add("JHRGMJ", typeof(double));
            table.Columns.Add("JHFYMJ", typeof(double));
            table.Columns.Add("JHZBGHMJ", typeof(double));
            table.Columns.Add("WCMJ", typeof(double));
            table.Columns.Add("WCRG", typeof(double));
            table.Columns.Add("WCFY", typeof(double));
            table.Columns.Add("WCZBGHMJ", typeof(double));
            table.Columns.Add("WCQK", typeof(string));
            return table;
        }

        /// <summary>
        /// 造林面积
        /// </summary>
        /// <returns></returns>
        private DataTable TJTableZFLZLMJ()
        {
            DataTable table = new DataTable("ResultTable");
            table.Columns.Add("TJDW", typeof(string));
            table.Columns.Add("ZYJH", typeof(double));
            table.Columns.Add("ZYYDW", typeof(double));
            table.Columns.Add("ZYYWC", typeof(double));
            table.Columns.Add("DFJH", typeof(double));
            table.Columns.Add("DFYDW", typeof(double));
            table.Columns.Add("DFYWC", typeof(double));
            table.Columns.Add("JHMJ", typeof(double));
            table.Columns.Add("JHRGMJ", typeof(double));
            table.Columns.Add("JHFYMJ", typeof(double));
            table.Columns.Add("WCMJ", typeof(double));
            table.Columns.Add("WCRG", typeof(double));
            table.Columns.Add("WCFY", typeof(double));
            table.Columns.Add("WCQK", typeof(string));
            return table;
        }

        public DataTable TJZFLJDByXiangCun(string gxnd, string xiangcode)
        {
            int num7;
            int digits = 2;
            DataTable table = this.TJTableZFLZLMJ();
            string cmdtxt = ("SELECT XIANG,CUN,MIAN_JI,ZAO_LIN_LB,ZJLY,ZYTZJF,DFTZJF FROM " + TABLE_ZLDATATABLE + " WHERE LEFT(GXSJ,6) " + gxnd) + " AND (XIANG='" + xiangcode + "') AND LTRIM(RTRIM(G_CHENG_LB))='25'";
            DataTable table2 = this.GetTable(cmdtxt, "tjtable");
            DataTable table3 = table.Clone();
            DataTable table4 = table2.Clone();
            table2.DefaultView.Sort = "CUN";
            DataTable table5 = table2.DefaultView.ToTable(true, new string[] { "CUN" });
            table3.Clear();
            foreach (DataRow row in table5.Rows)
            {
                table4.Clear();
                DataRow[] rowArray = table2.Select("CUN='" + row["CUN"].ToString() + "'");
                foreach (DataRow row2 in rowArray)
                {
                    if (row2["ZYTZJF"] == DBNull.Value)
                    {
                        row2["ZYTZJF"] = 0;
                    }
                    if (row2["DFTZJF"] == DBNull.Value)
                    {
                        row2["DFTZJF"] = 0;
                    }
                    table4.Rows.Add(row2.ItemArray);
                }
                double num2 = 0.0;
                double num3 = 0.0;
                num2 = Convert.ToDouble(table4.Compute("SUM(ZYTZJF)", null)) / 10000.0;
                num3 = Convert.ToDouble(table4.Compute("SUM(DFTZJF)", null)) / 10000.0;
                double num4 = 0.0;
                if (table4.Select(this.rgzl).Length > 0)
                {
                    num4 = Math.Round(Convert.ToDouble(table4.Compute("SUM(MIAN_JI)", this.rgzl)), digits);
                }
                double num5 = 0.0;
                if (table4.Select(this.fengshanyulin).Length > 0)
                {
                    num5 = Math.Round(Convert.ToDouble(table4.Compute("SUM(MIAN_JI)", this.fengshanyulin)), digits);
                }
                double num6 = 0.0;
                num6 = num4 + num5;
                DataRow row3 = table3.NewRow();
                num7 = 1;
                while (num7 < table.Columns.Count)
                {
                    row3[num7] = 0;
                    num7++;
                }
                row3["TJDW"] = xiangcode;
                row3["ZYYWC"] = num2;
                row3["DFYWC"] = num3;
                row3["WCMJ"] = num6;
                row3["WCRG"] = num4;
                row3["WCFY"] = num5;
                table3.Rows.Add(row3);
            }
            if (table3.Rows.Count > 0)
            {
                DataRow row4 = table3.NewRow();
                row4[0] = xiangcode;
                for (num7 = 1; num7 < (table3.Columns.Count - 1); num7++)
                {
                    row4[num7] = Math.Round(Convert.ToDouble(table3.Compute("SUM(" + table3.Columns[num7] + ")", null)), digits);
                }
                table3.Rows.InsertAt(row4, 0);
                foreach (DataRow row5 in table3.Rows)
                {
                    table.Rows.Add(row5.ItemArray);
                }
            }
            return table;
        }

        /// <summary>
        /// 通过
        /// </summary>
        /// <param name="gxnd"></param>
        /// <returns></returns>
        public DataTable TJZFLJDByXianXiang(string gxnd)
        {
            int num7;
            int digits = 2;
            DataTable resultTable = this.TJTableZFLZLMJ();
            string cmdtxt = ("SELECT XIANG,MIAN_JI,ZAO_LIN_LB,ZJLY,ZYTZJF,DFTZJF FROM " + TABLE_ZLDATATABLE + " WHERE LEFT(GXSJ,6) " + gxnd) + "  AND LTRIM(RTRIM(G_CHENG_LB))='25'";
            DataTable table = this.GetTable(cmdtxt, "tjtable");
            table.DefaultView.Sort = "XIANG";
            DataTable table3 = table.DefaultView.ToTable(true, new string[] { "XIANG" });
            foreach (DataRow row in table3.Rows)
            {
                string str2 = row[0].ToString();
                DataTable table4 = table.Clone();
                DataRow[] rowArray = table.Select("XIANG='" + str2 + "'");
                foreach (DataRow row2 in rowArray)
                {
                    if (row2["ZYTZJF"] == DBNull.Value)
                    {
                        row2["ZYTZJF"] = 0;
                    }
                    if (row2["DFTZJF"] == DBNull.Value)
                    {
                        row2["DFTZJF"] = 0;
                    }
                    table4.Rows.Add(row2.ItemArray);
                }
                double num2 = 0.0;
                double num3 = 0.0;
                num2 = Convert.ToDouble(table4.Compute("SUM(ZYTZJF)", null)) / 10000.0;
                num3 = Convert.ToDouble(table4.Compute("SUM(DFTZJF)", null)) / 10000.0;
                double num4 = 0.0;
                if (table4.Select(this.rgzl).Length > 0)
                {
                    num4 = Math.Round(Convert.ToDouble(table4.Compute("SUM(MIAN_JI)", this.rgzl)), digits);
                }
                double num5 = 0.0;
                if (table4.Select(this.fengshanyulin).Length > 0)
                {
                    num5 = Math.Round(Convert.ToDouble(table4.Compute("SUM(MIAN_JI)", this.fengshanyulin)), digits);
                }
                double num6 = 0.0;
                num6 = num4 + num5;
                DataRow row3 = resultTable.NewRow();
                num7 = 1;
                while (num7 < resultTable.Columns.Count)
                {
                    row3[num7] = 0;
                    num7++;
                }
                row3["TJDW"] = str2;
                row3["ZYYWC"] = num2;
                row3["DFYWC"] = num3;
                row3["WCMJ"] = num6;
                row3["WCRG"] = num4;
                row3["WCFY"] = num5;
                resultTable.Rows.Add(row3);
            }
            if (resultTable.Rows.Count <= 0)
            {
                return resultTable;
            }
            string str3 = resultTable.Rows[0][0].ToString().Trim().Substring(0, 6);
            DataRow row4 = resultTable.NewRow();
            row4[0] = str3;
            for (num7 = 1; num7 < (resultTable.Columns.Count - 1); num7++)
            {
                row4[num7] = Math.Round(Convert.ToDouble(resultTable.Compute("SUM(" + resultTable.Columns[num7] + ")", null)), digits);
            }
            resultTable.Rows.InsertAt(row4, 0);
            resultTable = this.ConvertTableFldValueZeroToNull(resultTable, 1);
            return this.ConvertTJTableDWCodeCol(resultTable, 1);
        }

        public DataTable TJZFLJDByXianXiangCun(string gxnd)
        {
            int num7;
            int digits = 2;
            DataTable resultTable = this.TJTableZFLZLMJ();
            string cmdtxt = ("SELECT XIANG,CUN,MIAN_JI,ZAO_LIN_LB,ZJLY,ZYTZJF,DFTZJF FROM " + TABLE_ZLDATATABLE + " WHERE LEFT(GXSJ,6) " + gxnd) + "  AND LTRIM(RTRIM(G_CHENG_LB))='25'";
            DataTable table = this.GetTable(cmdtxt, "tjtable");
            table.DefaultView.Sort = "XIANG";
            DataTable table3 = table.DefaultView.ToTable(true, new string[] { "XIANG" });
            DataTable table4 = resultTable.Clone();
            DataTable table5 = resultTable.Clone();
            foreach (DataRow row in table3.Rows)
            {
                string str2 = row[0].ToString();
                DataTable table6 = table.Clone();
                DataRow[] rowArray = table.Select("XIANG='" + str2 + "'");
                foreach (DataRow row2 in rowArray)
                {
                    if (row2["ZYTZJF"] == DBNull.Value)
                    {
                        row2["ZYTZJF"] = 0;
                    }
                    if (row2["DFTZJF"] == DBNull.Value)
                    {
                        row2["DFTZJF"] = 0;
                    }
                    table6.Rows.Add(row2.ItemArray);
                }
                DataTable table7 = table.Clone();
                table6.DefaultView.Sort = "CUN";
                DataTable table8 = table6.DefaultView.ToTable(true, new string[] { "CUN" });
                table5.Clear();
                foreach (DataRow row3 in table8.Rows)
                {
                    table7.Clear();
                    DataRow[] rowArray2 = table6.Select("CUN='" + row3["CUN"].ToString() + "'");
                    foreach (DataRow row4 in rowArray2)
                    {
                        table7.Rows.Add(row4.ItemArray);
                    }
                    double num2 = 0.0;
                    double num3 = 0.0;
                    num2 = Convert.ToDouble(table7.Compute("SUM(ZYTZJF)", null)) / 10000.0;
                    num3 = Convert.ToDouble(table7.Compute("SUM(DFTZJF)", null)) / 10000.0;
                    double num4 = 0.0;
                    if (table7.Select(this.rgzl).Length > 0)
                    {
                        num4 = Math.Round(Convert.ToDouble(table7.Compute("SUM(MIAN_JI)", this.rgzl)), digits);
                    }
                    double num5 = 0.0;
                    if (table7.Select(this.fengshanyulin).Length > 0)
                    {
                        num5 = Math.Round(Convert.ToDouble(table7.Compute("SUM(MIAN_JI)", this.fengshanyulin)), digits);
                    }
                    double num6 = 0.0;
                    num6 = num4 + num5;
                    DataRow row5 = table5.NewRow();
                    num7 = 1;
                    while (num7 < resultTable.Columns.Count)
                    {
                        row5[num7] = 0;
                        num7++;
                    }
                    row5["TJDW"] = str2;
                    row5["ZYYWC"] = num2;
                    row5["DFYWC"] = num3;
                    row5["WCMJ"] = num6;
                    row5["WCRG"] = num4;
                    row5["WCFY"] = num5;
                    table5.Rows.Add(row5);
                }
                if (table5.Rows.Count > 0)
                {
                    DataRow row6 = table5.NewRow();
                    row6[0] = str2;
                    num7 = 1;
                    while (num7 < (table5.Columns.Count - 1))
                    {
                        row6[num7] = Math.Round(Convert.ToDouble(table5.Compute("SUM(" + table5.Columns[num7] + ")", null)), digits);
                        num7++;
                    }
                    table5.Rows.InsertAt(row6, 0);
                    table4.Rows.Add(row6.ItemArray);
                    foreach (DataRow row7 in table5.Rows)
                    {
                        resultTable.Rows.Add(row7.ItemArray);
                    }
                }
            }
            if (resultTable.Rows.Count <= 0)
            {
                return resultTable;
            }
            string str4 = resultTable.Rows[0][0].ToString().Trim().Substring(0, 6);
            DataRow row8 = resultTable.NewRow();
            row8[0] = str4;
            for (num7 = 1; num7 < (resultTable.Columns.Count - 1); num7++)
            {
                row8[num7] = Math.Round(Convert.ToDouble(table4.Compute("SUM(" + table4.Columns[num7] + ")", null)), digits);
            }
            resultTable.Rows.InsertAt(row8, 0);
            resultTable = this.ConvertTableFldValueZeroToNull(resultTable, 1);
            return this.ConvertTJTableDWCodeCol(resultTable, 1);
        }

        public string xianname(string xiancode)
        {
            try
            {
                DataTable table = this.GetTable("SELECT CNAME FROM " + TABLE_XZDWTABLE + " WHERE (CCODE='" + xiancode + "') AND (CINDEX ='103') ", "xcdm");
                if ((table != null) && (table.Rows.Count > 0))
                {
                    xiancode = table.Rows[0][0].ToString().Trim();
                }
                return xiancode;
            }
            catch (Exception exception)
            {
                MessageBox.Show("转换县名称出错，错误：" + exception.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return xiancode;
            }
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

        public static string TABLE_ZLDATATABLE
        {
            get
            {
                return str_zt_zltable;
            }
            set
            {
                str_zt_zltable = value;
            }
        }
    }
}

