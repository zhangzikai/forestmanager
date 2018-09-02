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
    public class ZTGNQ : ZDZYTJBase
    {
        private DataTable m_table;
        public ZTGNQ()
        {
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

            string xiabn_tq = xiban.Substring(xiban.LastIndexOf(":") + 1);

            num2 = data.Where(p => p.XI_BAN == xiabn_tq).Sum(p => p.MIAN_JI);
            num3 = data.Where(p => p.XI_BAN == xiabn_tq).Sum(p => p.SLXJ);

            num4 = data.Where(p => p.QYKZ == "1" && p.XI_BAN == xiabn_tq).Sum(p => p.MIAN_JI);
            num5 = data.Where(p => p.QYKZ == "1" && p.XI_BAN == xiabn_tq).Sum(p => p.SLXJ);
            num6 = data.Where(p => p.QYKZ == "2" && p.XI_BAN == xiabn_tq).Sum(p => p.MIAN_JI);
            num7 = data.Where(p => p.QYKZ == "2" && p.XI_BAN == xiabn_tq).Sum(p => p.SLXJ);

            num8 = data.Where(p => p.QYKZ == "3" && p.XI_BAN == xiabn_tq).Sum(p => p.MIAN_JI);
            num9 = data.Where(p => p.QYKZ == "3" && p.XI_BAN == xiabn_tq).Sum(p => p.SLXJ);
            num10 = data.Where(p => p.QYKZ == "4" && p.XI_BAN == xiabn_tq).Sum(p => p.MIAN_JI);
            num11 = data.Where(p => p.QYKZ == "4" && p.XI_BAN == xiabn_tq).Sum(p => p.SLXJ);

            DataRow row3 = m_table.NewRow();
            row3["TJDW"] = MDM.FindXQName(key);

            row3["MJHJ"] = Math.Round(num2, m_digits);
            row3["XJHJ"] = Math.Round(num3, m_digits);
            row3["YXKFQMJ"] = Math.Round(num4, m_digits);
            row3["YXKFQXJ"] = Math.Round(num5, m_digits);
            row3["ZDKFQMJ"] = Math.Round(num6, m_digits);
            row3["ZDKFQXJ"] = Math.Round(num7, m_digits);
            row3["XZKFQMJ"] = Math.Round(num8, m_digits);
            row3["XZKFQXJ"] = Math.Round(num9, m_digits);
            row3["JZKFQMJ"] = Math.Round(num10, m_digits);
            row3["JZKFQXJ"] = Math.Round(num11, m_digits);

            m_table.Rows.Add(row3);
        }

        protected override DataTable MakeTable()
        {
            System.Data.DataTable table = new System.Data.DataTable("ResultTable");
            DataColumn column = new DataColumn("TJDW", typeof(string));
            table.Columns.Add(column);
            column = new DataColumn("MJHJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("XJHJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("YXKFQMJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("YXKFQXJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("ZDKFQMJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("ZDKFQXJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("XZKFQMJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("XZKFQXJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("JZKFQMJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("JZKFQXJ", typeof(double));
            table.Columns.Add(column);
            m_table = table;
            return table;
        }
    }
}
