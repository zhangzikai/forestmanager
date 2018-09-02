using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using td.db.orm;
using td.logic.sys;
using td.forest.ldzy.tj;
using td.db.mid.forest;

namespace LDZY_ZTZZ.tj
{
    public class B3_1 : ZDZYTJBase
    {
        private DataTable m_table;
        private string tudiquanshu;
        private string qiyuan;
        private string linzhong;

        public B3_1()
        {
            tudiquanshu = "";
            qiyuan = "";
            linzhong = "";
        }

        /// <summary>
        /// 返回计算的县乡
        /// </summary>
        /// <param name="lst"></param>
        /// <returns></returns>
        public override DataTable ComputeXianXiang(IEnumerable<ZT_LDZZ_2016_Mid> lst)
        {
            var lst2 = lst;
            return base.ComputeXianXiang(lst2);
        }


        protected override void MakeRow(IEnumerable<ZT_LDZZ_2016_Mid> data, string key, string xiban, string tudiquanshu, string qiyuan, string linzhong, string shuzhong, string ldlx, string lmqs, string bz)
        {

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
            double num13 = 0.0;

            string xiabn_tq = xiban.Substring(xiban.LastIndexOf(":") + 1);

            double mpd = data.Where(p => p.LDLX == "6" && p.XI_BAN == xiabn_tq).Sum(p => p.MIAN_JI);
            double zmj = data.Where(p => p.XI_BAN == xiabn_tq).Sum(p => p.MIAN_JI);

            double zxj = data.Where(p => p.XI_BAN == xiabn_tq).Sum(p => p.SLXJ);

            num2 = zmj;
            num3 = zxj;

            num4 = data.Where(p => p.LING_ZU == "1" && p.XI_BAN == xiabn_tq).Sum(p => p.MIAN_JI);
            num5 = data.Where(p => p.LING_ZU == "1" && p.XI_BAN == xiabn_tq).Sum(p => p.SLXJ);

            num6 = data.Where(p => p.LING_ZU == "2" && p.XI_BAN == xiabn_tq).Sum(p => p.MIAN_JI);

            num7 = data.Where(p => p.LING_ZU == "2" && p.XI_BAN == xiabn_tq).Sum(p => p.SLXJ);
            num8 = data.Where(p => p.LING_ZU == "3" && p.XI_BAN == xiabn_tq).Sum(p => p.MIAN_JI);
            num9 = data.Where(p => p.LING_ZU == "3" && p.XI_BAN == xiabn_tq).Sum(p => p.SLXJ);
            num10 = data.Where(p => p.LING_ZU == "4" && p.XI_BAN == xiabn_tq).Sum(p => p.MIAN_JI);

            num11 = data.Where(p => p.LING_ZU == "4" && p.XI_BAN == xiabn_tq).Sum(p => p.SLXJ); ;

            num12 = data.Where(p => p.LING_ZU == "5" && p.XI_BAN == xiabn_tq).Sum(p => p.MIAN_JI);
            num13 = data.Where(p => p.LING_ZU == "5" && p.XI_BAN == xiabn_tq).Sum(p => p.SLXJ);

            DataRow row3 = m_table.NewRow();
            row3["TJDW"] = MDM.FindXQName(key);
            string lmqs_tq = lmqs.Substring(lmqs.LastIndexOf(":") + 1);
            row3["LMQS"] = lmqs_tq;
            string qiyuan_tq = qiyuan.Substring(qiyuan.LastIndexOf(":") + 1);
            row3["QY"] = qiyuan_tq;
            string linzhong_tq = linzhong.Substring(linzhong.LastIndexOf(":") + 1);
            row3["LZ"] = linzhong_tq;
            row3["MJHJ"] = Math.Round(num2, m_digits);
            row3["XJHJ"] = Math.Round(num3, m_digits);
            row3["YLLMJ"] = Math.Round(num4, m_digits);
            row3["YLLXJ"] = Math.Round(num5, m_digits);
            row3["ZLLMJ"] = Math.Round(num6, m_digits);
            row3["ZLLXJ"] = Math.Round(num7, m_digits);
            row3["JSLMJ"] = Math.Round(num8, m_digits);
            row3["JSLXJ"] = Math.Round(num9, m_digits);
            row3["CSLMJ"] = Math.Round(mpd, m_digits);
            row3["CSLXJ"] = Math.Round(num11, m_digits);
            row3["GSLMJ"] = Math.Round(num12, m_digits);
            row3["GSLXJ"] = Math.Round(num13, m_digits);

            m_table.Rows.Add(row3);
        }

        protected override DataTable MakeTable()
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
            m_table = table;
            return table;
        }
    }
}
