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
    public class B5_1 : ZDZYTJBase
    {
        private DataTable m_table;
        private string tudiquanshu;
        private string qiyuan;
        private string linzhong;

        public B5_1()
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

            string xiabn_tq = xiban.Substring(xiban.LastIndexOf(":") + 1);

            double mpd = data.Where(p => p.LDLX == "6" && p.XI_BAN == xiabn_tq).Sum(p => p.MIAN_JI);
            double zmj = data.Where(p => p.XI_BAN == xiabn_tq).Sum(p => p.MIAN_JI);

            double zxj = data.Where(p => p.XI_BAN == xiabn_tq).Sum(p => p.SLXJ);

            num2 = zmj;
            num3 = data.Where(p => p.JJLCQ == "1" && p.XI_BAN == xiabn_tq).Sum(p => p.MIAN_JI);

            num4 = data.Where(p => p.JJLCQ == "2" && p.XI_BAN == xiabn_tq).Sum(p => p.MIAN_JI);
            num5 = data.Where(p => p.JJLCQ == "3" && p.XI_BAN == xiabn_tq).Sum(p => p.MIAN_JI);
            num6 = data.Where(p => p.JJLCQ == "4" && p.XI_BAN == xiabn_tq).Sum(p => p.MIAN_JI);

            DataRow row3 = m_table.NewRow();
            row3["TJDW"] = MDM.FindXQName(key);
            string lmqs_tq = lmqs.Substring(lmqs.LastIndexOf(":") + 1);
            row3["LDQS"] = lmqs_tq;
            string shuzhong_tq = shuzhong.Substring(shuzhong.LastIndexOf(":") + 1);
            row3["YSSZ"] = shuzhong_tq;
            row3["MJHJ"] = Math.Round(num2, m_digits);
            row3["CQQMJ"] = Math.Round(num3, m_digits);
            row3["CCQMJ"] = Math.Round(num4, m_digits);
            row3["SCQMJ"] = Math.Round(num5, m_digits);
            row3["MCQMJ"] = Math.Round(num6, m_digits);

            m_table.Rows.Add(row3);
        }

        protected override DataTable MakeTable()
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
            m_table = table;
            return table;
        }
    }
}
