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
     public class GNQ: ZDZYTJBase
    {
         private DataTable m_table;
         public GNQ()
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

            string xiabn_tq = xiban.Substring(xiban.LastIndexOf(":") + 1);

            num2 = data.Where(p => p.XI_BAN == xiabn_tq).Sum(p => p.MIAN_JI);
            num3 = data.Where(p => p.XI_BAN == xiabn_tq).Sum(p => p.SLXJ);

            num4 = data.Where(p => p.LYFQ == "14805" && p.XI_BAN == xiabn_tq).Sum(p => p.MIAN_JI);
            num5 = data.Where(p => p.LYFQ == "14805" && p.XI_BAN == xiabn_tq).Sum(p => p.SLXJ);


            DataRow row3 = m_table.NewRow();
            row3["TJDW"] = MDM.FindXQName(key);

            row3["MJHJ"] = Math.Round(num2, m_digits);
            row3["XJHJ"] = Math.Round(num3, m_digits);
            row3["FQMJ"] = Math.Round(num4, m_digits);
            row3["FQXJ"] = Math.Round(num5, m_digits);


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
            column = new DataColumn("FQMJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("FQXJ", typeof(double));
            table.Columns.Add(column);
            m_table = table;
            return table;
        }
    }
}
