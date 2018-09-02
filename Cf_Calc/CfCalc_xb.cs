namespace Cf_Calc
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Windows.Forms;
    using Utilities;

    public class CfCalc_xb
    {
        private DataTable _CfDataTable = null;
        private DataTable _CfDataTableFsz = null;
        private double _CFMJ = 0.0;
        private string[] _ColName = new string[] { "采伐蓄积", "采伐株数", "出材量", "规格材出材量", "非规格材出材量", "出材率", "采伐木平均高", "采伐木平均胸径", "采伐木公顷蓄积", "采伐木公顷株数", "保留木平均高", "保留木平均胸径", "保留木公顷株数", "保留木公顷蓄积" };
        private string _CUN = "";
        private string _DCXB = "";
        private string _LB = "";
        private List<string> _TreeList = new List<string>();
        private string _ZYXB = "";
       

        public CfCalc_xb(string cun, string lb, string dcxb, string zyxb, double cfmj)
        {
            this._CUN = cun;
            this._LB = lb;
            this._DCXB = dcxb;
            this._ZYXB = zyxb;
            this._CFMJ = cfmj;
        }

        private void Calc()
        {
            try
            {
                this.CrateDataTable();
                if (string.IsNullOrEmpty(this._CUN))
                {
                    MessageBox.Show("村号不能为空", "提示", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
                else if (string.IsNullOrEmpty(this._LB))
                {
                    MessageBox.Show("林班号不能为空", "提示", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
                else if (string.IsNullOrEmpty(this._DCXB))
                {
                    MessageBox.Show("调查小班号不能为空", "提示", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
                else if (string.IsNullOrEmpty(this._ZYXB))
                {
                    MessageBox.Show("作业小班号不能为空", "提示", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
                else
                {
                    string sql = "select BZDH as 标准地号, JCSZ as 检尺树种, BZDMJ as 标准地面积, (select CNAME from T_SYS_META_CODE where CCODE = JCLX and CTYPE = '检尺类型' ) as 检尺类型, sum(ZSHJ) as 株数合计, sum(YCXJ + BYCXJ + XCXJ) as 蓄积, sum(GGCCCL) as 规格材出材量, sum(XCCCL) as 小材出材量, SUM(DMJ) as 断面积之和 from T_ZT_CF_MMJC ";
                    sql = ((((sql + " where CUN = '" + this._CUN) + "' and LIN_BAN = '" + this._LB) + "' and DCXB = '" + this._DCXB) + "' and ZYXB = '" + this._ZYXB) + "'" + " group by BZDH, JCSZ, BZDMJ, JCLX order by BZDH";
                    string sDBKey = UtilFactory.GetConfigOpt().GetConfigValue2("DataBase", "DBKey");

                    DataTable dataTable = null;// this.m_DBAccess.GetDataTable(this.m_DBAccess, sql);
                    if (dataTable.Rows.Count >= 1)
                    {
                        DataRow row2;
                        double num3;
                        double num4;
                        double num5;
                        double num6;
                        DataRow row3;
                        double num10;
                        double num11;
                        double num12;
                        double num13;
                        DataTable dt = new DataTable();
                        string[] strArray = new string[] { "检尺类型", "株数合计", "加权平均蓄积量之和", "加权规格材出材量之和", "加权小材出材量之和", "面积之和", "断面积合计" };
                        foreach (string str3 in strArray)
                        {
                            dt.Columns.Add(str3);
                        }
                        double num = 0.0;
                        List<string> list = new List<string>();
                        foreach (DataRow row in dataTable.Rows)
                        {
                            string item = row["标准地号"].ToString().Replace(" ", "");
                            if (list.IndexOf(item) == -1)
                            {
                                list.Add(item);
                            }
                        }
                        double result = 0.0;
                        foreach (string str5 in list)
                        {
                            foreach (DataRow row in dataTable.Rows)
                            {
                                if (row["标准地号"].ToString().Replace(" ", "") == str5)
                                {
                                    double.TryParse(row["标准地面积"].ToString(), out result);
                                    num += result;
                                    break;
                                }
                            }
                        }
                        foreach (DataRow row in dataTable.Rows)
                        {
                            row2 = this.FindRow(dt, row["检尺类型"].ToString());
                            if (row2 != null)
                            {
                                num3 = 0.0;
                                double.TryParse(row["标准地面积"].ToString(), out num3);
                                num4 = 0.0;
                                num5 = 0.0;
                                double.TryParse(row2["株数合计"].ToString(), out num4);
                                double.TryParse(row["株数合计"].ToString(), out num5);
                                num4 += num5;
                                row2["株数合计"] = num4;
                                double.TryParse(row2["加权平均蓄积量之和"].ToString(), out num4);
                                double.TryParse(row["蓄积"].ToString(), out num5);
                                if (!(num5 == 0.0))
                                {
                                    num4 += (num5 * num3) / (num3 / 10000.0);
                                }
                                row2["加权平均蓄积量之和"] = num4;
                                double.TryParse(row2["加权规格材出材量之和"].ToString(), out num4);
                                double.TryParse(row["规格材出材量"].ToString(), out num5);
                                if (!(num5 == 0.0))
                                {
                                    num4 += (num5 * num3) / (num3 / 10000.0);
                                }
                                row2["加权规格材出材量之和"] = num4;
                                double.TryParse(row2["加权小材出材量之和"].ToString(), out num4);
                                double.TryParse(row["小材出材量"].ToString(), out num5);
                                if (!(num5 == 0.0))
                                {
                                    num4 += (num5 * num3) / (num3 / 10000.0);
                                }
                                row2["加权小材出材量之和"] = num4;
                                double.TryParse(row2["断面积合计"].ToString(), out num4);
                                double.TryParse(row["断面积之和"].ToString(), out num5);
                                num4 += num5;
                                row2["断面积合计"] = num4;
                            }
                            else
                            {
                                row2 = dt.NewRow();
                                row2["检尺类型"] = row["检尺类型"];
                                num3 = 0.0;
                                double.TryParse(row["标准地面积"].ToString(), out num3);
                                num6 = 0.0;
                                double.TryParse(row["株数合计"].ToString(), out num6);
                                row2["株数合计"] = num6;
                                num6 = 0.0;
                                double.TryParse(row["蓄积"].ToString(), out num6);
                                if (!(num6 == 0.0))
                                {
                                    row2["加权平均蓄积量之和"] = (num6 * num3) / (num3 / 10000.0);
                                }
                                else
                                {
                                    row2["加权平均蓄积量之和"] = 0;
                                }
                                num6 = 0.0;
                                double.TryParse(row["规格材出材量"].ToString(), out num6);
                                if (!(num6 == 0.0))
                                {
                                    row2["加权规格材出材量之和"] = Math.Round((double) ((num6 * num3) / (num3 / 10000.0)), 0);
                                }
                                else
                                {
                                    row2["加权规格材出材量之和"] = 0;
                                }
                                num6 = 0.0;
                                double.TryParse(row["小材出材量"].ToString(), out num6);
                                if (!(num6 == 0.0))
                                {
                                    row2["加权小材出材量之和"] = Math.Round((double) ((num6 * num3) / (num3 / 10000.0)), 0);
                                }
                                else
                                {
                                    row2["加权小材出材量之和"] = 0;
                                }
                                row2["面积之和"] = num3;
                                num6 = 0.0;
                                double.TryParse(row["断面积之和"].ToString(), out num6);
                                row2["断面积合计"] = num6;
                                dt.Rows.Add(row2);
                            }
                        }
                        foreach (DataRow row in dt.Rows)
                        {
                            num3 = num;
                            double.TryParse(row["加权平均蓄积量之和"].ToString(), out num4);
                            if (!(num4 == 0.0))
                            {
                                num4 /= num3;
                            }
                            row["加权平均蓄积量之和"] = num4;
                            double.TryParse(row["加权规格材出材量之和"].ToString(), out num4);
                            if (!(num4 == 0.0))
                            {
                                num4 /= num3;
                            }
                            row["加权规格材出材量之和"] = num4;
                            double.TryParse(row["加权小材出材量之和"].ToString(), out num4);
                            if (!(num4 == 0.0))
                            {
                                num4 /= num3;
                            }
                            row["加权小材出材量之和"] = num4;
                        }
                        double num7 = 0.0;
                        double num8 = 0.0;
                        foreach (DataRow row in dt.Rows)
                        {
                            double num9;
                            if (row["检尺类型"].ToString().Replace(" ", "") == "采伐")
                            {
                                double.TryParse(row["断面积合计"].ToString(), out num7);
                                double.TryParse(row["株数合计"].ToString(), out num8);
                                num9 = 0.0;
                                row3 = null;
                                if ((num7 != 0.0) && (num8 != 0.0))
                                {
                                    num9 = (Math.Pow((num7 / num8) / 3.14159, 0.5) * 2.0) * 100.0;
                                    this.FindRow("采伐木平均胸径")["Value"] = Math.Round(num9, 1);
                                    this.FindRow("采伐木平均高")["Value"] = Math.Round(this.Calc_pjg(num9, "采伐"), 1);
                                }
                                else
                                {
                                    this.FindRow("采伐木平均胸径")["Value"] = 0;
                                    this.FindRow("采伐木平均高")["Value"] = 0;
                                }
                                double.TryParse(row["株数合计"].ToString(), out num7);
                                num8 = num;
                                if ((num7 != 0.0) && (num8 != 0.0))
                                {
                                    this.FindRow("采伐株数")["Value"] = Math.Round((double) ((num7 / num8) * this._CFMJ), 0);
                                    this.FindRow("采伐木公顷株数")["Value"] = Math.Round((double) ((num7 / num8) * 10000.0), 0);
                                }
                                else
                                {
                                    this.FindRow("采伐株数")["Value"] = 0;
                                    this.FindRow("采伐木公顷株数")["Value"] = 0;
                                }
                                double.TryParse(row["加权平均蓄积量之和"].ToString(), out num7);
                                if (num7 > 0.0)
                                {
                                    this.FindRow("采伐木公顷蓄积")["Value"] = Math.Round(num7, 1);
                                }
                                else
                                {
                                    this.FindRow("采伐木公顷蓄积")["Value"] = 0;
                                }
                                num10 = 0.0;
                                row3 = this.FindRow("采伐蓄积");
                                double.TryParse(row["加权平均蓄积量之和"].ToString(), out num7);
                                if (!(num7 == 0.0))
                                {
                                    num10 = num7 * (this._CFMJ / 10000.0);
                                }
                                row3["Value"] = Math.Round(num10, 0);
                                num11 = 0.0;
                                row3 = this.FindRow("规格材出材量");
                                double.TryParse(row["加权规格材出材量之和"].ToString(), out num7);
                                if (!(num7 == 0.0))
                                {
                                    num11 = num7 * (this._CFMJ / 10000.0);
                                }
                                row3["Value"] = Math.Round(num11, 0);
                                num12 = 0.0;
                                row3 = this.FindRow("非规格材出材量");
                                double.TryParse(row["加权小材出材量之和"].ToString(), out num7);
                                if (!(num7 == 0.0))
                                {
                                    num12 = num7 * (this._CFMJ / 10000.0);
                                }
                                row3["Value"] = Math.Round(num12, 0);
                                this.FindRow("出材量")["Value"] = Math.Round((double) (num11 + num12), 0);
                                row3 = this.FindRow("出材率");
                                num13 = num11 + num12;
                                if ((num13 != 0.0) && (num10 != 0.0))
                                {
                                    row3["Value"] = Math.Round((double) ((num13 / num10) * 100.0), 0);
                                }
                                else
                                {
                                    row3["Value"] = 0;
                                }
                            }
                            else
                            {
                                double.TryParse(row["断面积合计"].ToString(), out num7);
                                double.TryParse(row["株数合计"].ToString(), out num8);
                                num9 = 0.0;
                                row3 = null;
                                if ((num7 != 0.0) && (num8 != 0.0))
                                {
                                    num9 = (Math.Pow((num7 / num8) / 3.14159, 0.5) * 2.0) * 100.0;
                                    this.FindRow("保留木平均胸径")["Value"] = Math.Round(num9, 1);
                                    this.FindRow("保留木平均高")["Value"] = Math.Round(this.Calc_pjg(num9, "保留"), 1);
                                }
                                else
                                {
                                    this.FindRow("保留木平均胸径")["Value"] = 0;
                                    this.FindRow("保留木平均高")["Value"] = 0;
                                }
                                num3 = num;
                                row3 = this.FindRow("保留木公顷株数");
                                double.TryParse(row["株数合计"].ToString(), out num7);
                                if (!(num7 == 0.0))
                                {
                                    row3["Value"] = Math.Round((double) (num7 / (num3 / 10000.0)), 0);
                                }
                                else
                                {
                                    row3["Value"] = 0;
                                }
                                row3 = this.FindRow("保留木公顷蓄积");
                                double.TryParse(row["加权平均蓄积量之和"].ToString(), out num7);
                                if (!(num7 == 0.0))
                                {
                                    row3["Value"] = Math.Round(num7, 1);
                                }
                                else
                                {
                                    row3["Value"] = 0;
                                }
                            }
                        }
                        DataTable table3 = dt.Clone();
                        table3.Columns.Add("检尺树种");
                        List<string> jcszList = this.GetJcszList(dataTable);
                        foreach (DataRow row in dataTable.Rows)
                        {
                            row2 = this.FindRow(table3, row["检尺类型"].ToString(), row["检尺树种"].ToString());
                            if (row2 != null)
                            {
                                num3 = 0.0;
                                double.TryParse(row["标准地面积"].ToString(), out num3);
                                num4 = 0.0;
                                num5 = 0.0;
                                double.TryParse(row2["株数合计"].ToString(), out num4);
                                double.TryParse(row["株数合计"].ToString(), out num5);
                                num4 += num5;
                                row2["株数合计"] = num4;
                                double.TryParse(row2["加权平均蓄积量之和"].ToString(), out num4);
                                double.TryParse(row["蓄积"].ToString(), out num5);
                                if (!(num5 == 0.0))
                                {
                                    num4 += (num5 * num3) / (num3 / 10000.0);
                                }
                                row2["加权平均蓄积量之和"] = num4;
                                double.TryParse(row2["加权规格材出材量之和"].ToString(), out num4);
                                double.TryParse(row["规格材出材量"].ToString(), out num5);
                                if (!(num5 == 0.0))
                                {
                                    num4 += (num5 * num3) / (num3 / 10000.0);
                                }
                                row2["加权规格材出材量之和"] = num4;
                                double.TryParse(row2["加权小材出材量之和"].ToString(), out num4);
                                double.TryParse(row["小材出材量"].ToString(), out num5);
                                if (!(num5 == 0.0))
                                {
                                    num4 += (num5 * num3) / (num3 / 10000.0);
                                }
                                row2["加权小材出材量之和"] = num4;
                                double.TryParse(row2["断面积合计"].ToString(), out num4);
                                double.TryParse(row["断面积之和"].ToString(), out num5);
                                num4 += num5;
                                row2["断面积合计"] = num4;
                            }
                            else
                            {
                                row2 = table3.NewRow();
                                row2["检尺类型"] = row["检尺类型"];
                                row2["检尺树种"] = row["检尺树种"];
                                num3 = 0.0;
                                double.TryParse(row["标准地面积"].ToString(), out num3);
                                num6 = 0.0;
                                double.TryParse(row["株数合计"].ToString(), out num6);
                                row2["株数合计"] = num6;
                                num6 = 0.0;
                                double.TryParse(row["蓄积"].ToString(), out num6);
                                if (!(num6 == 0.0))
                                {
                                    row2["加权平均蓄积量之和"] = (num6 * num3) / (num3 / 10000.0);
                                }
                                else
                                {
                                    row2["加权平均蓄积量之和"] = 0;
                                }
                                num6 = 0.0;
                                double.TryParse(row["规格材出材量"].ToString(), out num6);
                                if (!(num6 == 0.0))
                                {
                                    row2["加权规格材出材量之和"] = Math.Round((double) ((num6 * num3) / (num3 / 10000.0)), 0);
                                }
                                else
                                {
                                    row2["加权规格材出材量之和"] = 0;
                                }
                                num6 = 0.0;
                                double.TryParse(row["小材出材量"].ToString(), out num6);
                                if (!(num6 == 0.0))
                                {
                                    row2["加权小材出材量之和"] = Math.Round((double) ((num6 * num3) / (num3 / 10000.0)), 0);
                                }
                                else
                                {
                                    row2["加权小材出材量之和"] = 0;
                                }
                                row2["面积之和"] = num3;
                                num6 = 0.0;
                                double.TryParse(row["断面积之和"].ToString(), out num6);
                                row2["断面积合计"] = num6;
                                table3.Rows.Add(row2);
                            }
                        }
                        foreach (DataRow row in table3.Rows)
                        {
                            num3 = num;
                            double.TryParse(row["加权平均蓄积量之和"].ToString(), out num4);
                            if (!(num4 == 0.0))
                            {
                                num4 /= num3;
                            }
                            row["加权平均蓄积量之和"] = num4;
                            double.TryParse(row["加权规格材出材量之和"].ToString(), out num4);
                            if (!(num4 == 0.0))
                            {
                                num4 /= num3;
                            }
                            row["加权规格材出材量之和"] = num4;
                            double.TryParse(row["加权小材出材量之和"].ToString(), out num4);
                            if (!(num4 == 0.0))
                            {
                                num4 /= num3;
                            }
                            row["加权小材出材量之和"] = num4;
                        }
                        this._CfDataTableFsz = new DataTable();
                        this._CfDataTableFsz.Columns.Add("Tree");
                        this._CfDataTableFsz.Columns.Add("Name");
                        this._CfDataTableFsz.Columns.Add("Value");
                        foreach (string str3 in jcszList)
                        {
                            DataRow row4 = this._CfDataTableFsz.NewRow();
                            row4["Tree"] = str3;
                            row4["Name"] = "采伐蓄积";
                            row4["Value"] = 0;
                            this._CfDataTableFsz.Rows.Add(row4);
                            row4 = this._CfDataTableFsz.NewRow();
                            row4["Tree"] = str3;
                            row4["Name"] = "出材量";
                            row4["Value"] = 0;
                            this._CfDataTableFsz.Rows.Add(row4);
                            row4 = this._CfDataTableFsz.NewRow();
                            row4["Tree"] = str3;
                            row4["Name"] = "规格材出材量";
                            row4["Value"] = 0;
                            this._CfDataTableFsz.Rows.Add(row4);
                            row4 = this._CfDataTableFsz.NewRow();
                            row4["Tree"] = str3;
                            row4["Name"] = "非规格材出材量";
                            row4["Value"] = 0;
                            this._CfDataTableFsz.Rows.Add(row4);
                            row4 = this._CfDataTableFsz.NewRow();
                            row4["Tree"] = str3;
                            row4["Name"] = "出材率";
                            row4["Value"] = 0;
                            this._CfDataTableFsz.Rows.Add(row4);
                        }
                        foreach (DataRow row in table3.Rows)
                        {
                            if (row["检尺类型"].ToString().Replace(" ", "") == "采伐")
                            {
                                row3 = null;
                                num10 = 0.0;
                                row3 = this.FindRowInValueTable(this._CfDataTableFsz, "采伐蓄积", row["检尺树种"].ToString());
                                double.TryParse(row["加权平均蓄积量之和"].ToString(), out num7);
                                if (!(num7 == 0.0))
                                {
                                    num10 = num7 * (this._CFMJ / 10000.0);
                                }
                                row3["Value"] = Math.Round(num10, 0);
                                num11 = 0.0;
                                row3 = this.FindRowInValueTable(this._CfDataTableFsz, "规格材出材量", row["检尺树种"].ToString());
                                double.TryParse(row["加权规格材出材量之和"].ToString(), out num7);
                                if (!(num7 == 0.0))
                                {
                                    num11 = num7 * (this._CFMJ / 10000.0);
                                }
                                row3["Value"] = Math.Round(num11, 0);
                                num12 = 0.0;
                                row3 = this.FindRowInValueTable(this._CfDataTableFsz, "非规格材出材量", row["检尺树种"].ToString());
                                double.TryParse(row["加权小材出材量之和"].ToString(), out num7);
                                if (!(num7 == 0.0))
                                {
                                    num12 = num7 * (this._CFMJ / 10000.0);
                                }
                                row3["Value"] = Math.Round(num12, 0);
                                this.FindRowInValueTable(this._CfDataTableFsz, "出材量", row["检尺树种"].ToString())["Value"] = Math.Round((double) (num11 + num12), 0);
                                row3 = this.FindRowInValueTable(this._CfDataTableFsz, "出材率", row["检尺树种"].ToString());
                                num13 = num11 + num12;
                                if (!(num13 == 0.0))
                                {
                                    row3["Value"] = Math.Round((double) ((num13 / num10) * 100.0), 0);
                                }
                                else
                                {
                                    row3["Value"] = 0;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("计算采伐数据时发生错误: " + exception.Message, "CfCalc_xb::Calc", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private double Calc_pjg(double pjd, string type)
        {
            string sql = "select D1 as 胸径1, H1 as 树高1, D2 as 胸径2, H2 as 树高2, D3 as 胸径3, H3 as 树高3 from ";
            sql = ((((((sql + "T_ZT_CF_MMJC") + " where CUN = '" + this._CUN) + "' and LIN_BAN = '" + this._LB) + "' and DCXB = '" + this._DCXB) + "' and ZYXB = '" + this._ZYXB) + "' and JCLX = (select CCODE from T_SYS_META_CODE where CNAME = '" + type) + "' and CTYPE = '检尺类型' )" + " order by BZDH";
            DataTable dataTable = null;// this.m_DBAccess.GetDataTable(this.m_DBAccess, sql);
            DataTable table2 = new DataTable();
            table2.Columns.Add("D");
            table2.Columns.Add("H");
            double result = 0.0;
            double num3 = 0.0;
            string[] strArray = new string[] { "胸径1", "胸径2", "胸径3" };
            string[] strArray2 = new string[] { "树高1", "树高2", "树高3" };
            foreach (DataRow row in dataTable.Rows)
            {
                int num4 = 0;
                foreach (string str2 in strArray)
                {
                    object obj2 = row[str2];
                    object obj3 = row[strArray2[num4++]];
                    double.TryParse(obj2.ToString(), out result);
                    double.TryParse(obj3.ToString(), out num3);
                    if ((result > 0.0) || (num3 > 0.0))
                    {
                        DataRow row2 = table2.NewRow();
                        row2["D"] = obj2;
                        row2["H"] = obj3;
                        table2.Rows.Add(row2);
                    }
                }
            }
            double count = table2.Rows.Count;
            if (count < 20.0)
            {
                return Calc_Pjg_xy20(dataTable);
            }
            double num6 = 0.0;
            double num7 = 0.0;
            double num8 = 0.0;
            double num9 = 0.0;
            double num10 = 0.0;
            for (int i = 0; i < count; i++)
            {
                double num12 = 0.0;
                object obj4 = table2.Rows[i]["H"];
                double.TryParse(obj4.ToString(), out num12);
                double num13 = 0.0;
                double.TryParse(table2.Rows[i]["D"].ToString(), out num13);
                double num14 = num12;
                double num15 = num13 * num13;
                num7 += num15;
                num6 += num14;
                num9 += num15 * num15;
                num8 += num14 * num14;
                num10 += num15 * num14;
            }
            double num16 = num9 - ((num7 * num7) / count);
            double num17 = num8 - ((num6 * num6) / count);
            double num18 = num10 - ((num7 * num6) / count);
            double num19 = num18 / num16;
            double num20 = (num6 / count) - ((num19 * num7) / count);
            return (num20 + (num19 * Math.Pow(pjd, 2.0)));
        }

        private static double Calc_Pjg_xy20(DataTable dt)
        {
            double num = 0.0;
            double num2 = 0.0;
            double num3 = 0.0;
            double num4 = 0.0;
            double num5 = 0.0;
            double num6 = 0.0;
            int num7 = 0;
            int num8 = 0;
            int num9 = 0;
            double result = 0.0;
            int num11 = 0;
            foreach (DataRow row in dt.Rows)
            {
                object obj2 = row["树高1"];
                double.TryParse(obj2.ToString(), out result);
                num4 += result;
                if (!(result == 0.0))
                {
                    num7++;
                }
                obj2 = row["树高2"];
                double.TryParse(obj2.ToString(), out result);
                num5 += result;
                if (!(result == 0.0))
                {
                    num8++;
                }
                double.TryParse(row["树高3"].ToString(), out result);
                num6 += result;
                if (!(result == 0.0))
                {
                    num9++;
                }
            }
            if ((num4 > 0.0) && (num7 > 0))
            {
                num = num4 / ((double) num7);
                num11++;
            }
            if ((num5 > 0.0) && (num8 > 0))
            {
                num2 = num5 / ((double) num8);
                num11++;
            }
            if ((num6 > 0.0) && (num9 > 0))
            {
                num3 = num6 / ((double) num9);
                num11++;
            }
            double num12 = 0.0;
            num12 = (num + num2) + num3;
            if ((num12 > 0.0) && (num11 > 0))
            {
                return (num12 / ((double) num11));
            }
            return 0.0;
        }

        private void CrateDataTable()
        {
            this._CfDataTable = null;
            this._CfDataTable = new DataTable();
            this._CfDataTable.Columns.Add("Name");
            this._CfDataTable.Columns.Add("Value");
            foreach (string str in this._ColName)
            {
                DataRow row = this._CfDataTable.NewRow();
                row["Name"] = str;
                row["Value"] = 0;
                this._CfDataTable.Rows.Add(row);
            }
        }

        private DataRow FindRow(string type)
        {
            foreach (DataRow row2 in this._CfDataTable.Rows)
            {
                if (row2["Name"].ToString() == type)
                {
                    return row2;
                }
            }
            return null;
        }

        private DataRow FindRow(DataTable dt, string type)
        {
            foreach (DataRow row2 in dt.Rows)
            {
                if (row2["检尺类型"].ToString() == type)
                {
                    return row2;
                }
            }
            return null;
        }

        private DataRow FindRow(DataTable dt, string type, string sz)
        {
            foreach (DataRow row2 in dt.Rows)
            {
                if ((row2["检尺类型"].ToString() == type) && (row2["检尺树种"].ToString() == sz))
                {
                    return row2;
                }
            }
            return null;
        }

        private DataRow FindRowInValueTable(DataTable dt, string vtype, string sz)
        {
            foreach (DataRow row2 in dt.Rows)
            {
                if ((row2["Name"].ToString() == vtype) && (row2["Tree"].ToString() == sz))
                {
                    return row2;
                }
            }
            return null;
        }

        private List<string> GetJcszList(DataTable dt)
        {
            this._TreeList.Clear();
            List<string> list = new List<string>();
            foreach (DataRow row in dt.Rows)
            {
                string item = row["检尺树种"].ToString();
                if (list.IndexOf(item) == -1)
                {
                    list.Add(item);
                    this._TreeList.Add(item);
                }
            }
            return list;
        }

        public double GetValue(Calc_ValueType type)
        {
            if (this._CfDataTable == null)
            {
                this.Calc();
            }
            return this.GetValueByName(type.ToString());
        }

        private double GetValueByName(string name)
        {
            double result = 0.0;
            foreach (DataRow row in this._CfDataTable.Rows)
            {
                result = 0.0;
                if (row["Name"].ToString() == name)
                {
                    double.TryParse(row["Value"].ToString(), out result);
                    return result;
                }
            }
            return result;
        }

        private double GetValueByNameInTree(string name, string sz)
        {
            double result = 0.0;
            foreach (DataRow row in this._CfDataTableFsz.Rows)
            {
                result = 0.0;
                if ((row["Name"].ToString() == name) && (row["Tree"].ToString() == sz))
                {
                    double.TryParse(row["Value"].ToString(), out result);
                    return result;
                }
            }
            return result;
        }

        public double GetValueByTree(Calc_ValueTypeByTree type, string sz)
        {
            if (this._CfDataTable == null)
            {
                this.Calc();
            }
            if (this._CfDataTableFsz == null)
            {
                return 0.0;
            }
            return this.GetValueByNameInTree(type.ToString(), sz);
        }

        public enum Calc_ValueType
        {
            采伐蓄积,
            采伐株数,
            出材量,
            规格材出材量,
            非规格材出材量,
            出材率,
            采伐木平均高,
            采伐木平均胸径,
            采伐木公顷蓄积,
            采伐木公顷株数,
            保留木平均高,
            保留木平均胸径,
            保留木公顷株数,
            保留木公顷蓄积
        }

        public enum Calc_ValueTypeByTree
        {
            采伐蓄积,
            出材量,
            规格材出材量,
            非规格材出材量,
            出材率
        }
    }
}

