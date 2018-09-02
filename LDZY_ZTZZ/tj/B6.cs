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
    public class B6 : ZDZYTJBase
    {
        private DataTable m_table;

        private string tudiquanshu;
        private string qiyuan;
        private string linzhong;

        public B6()
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

            string xiabn_tq = xiban.Substring(xiban.LastIndexOf(":") + 1);

            double mpd = data.Where(p => p.LDLX == "6" && p.XI_BAN == xiabn_tq).Sum(p => p.MIAN_JI);
            double zmj = data.Where(p => p.XI_BAN == xiabn_tq).Sum(p => p.MIAN_JI);
            double zxj = data.Where(p => p.XI_BAN == xiabn_tq).Sum(p => p.SLXJ);

            num2 = zmj;
            num3 = zxj;

            num4 = data.Where(p => p.XI_BAN == xiabn_tq).Sum(p => p.ZFYHJ);

            num5 = data.Where(p => p.YDFW == "2" && p.XI_BAN == xiabn_tq).Sum(p => p.MIAN_JI);
            num6 = data.Where(p => p.YDFW == "2" && p.XI_BAN == xiabn_tq).Sum(p => p.SLXJ);

            num7 = data.Where(p => p.YDFW == "2" && p.XI_BAN == xiabn_tq).Sum(p => p.ZBHFDJ);
            num8 = data.Where(p => p.YDFW == "2" && p.XI_BAN == xiabn_tq).Sum(p => p.ZBHFF);

            num9 = data.Where(p => p.YDFW == "1" && p.XI_BAN == xiabn_tq).Sum(p => p.MIAN_JI);
            num10 = data.Where(p => p.YDFW == "1" && p.XI_BAN == xiabn_tq).Sum(p => p.SLXJ);
            num11 = data.Where(p => p.YDFW == "1" && p.XI_BAN == xiabn_tq).Sum(p => p.ZBHFDJ); ;
            num12 = data.Where(p => p.YDFW == "1" && p.XI_BAN == xiabn_tq).Sum(p => p.ZBHFF);
          
            

            DataRow row3 = m_table.NewRow();
            row3["TJDW"] = MDM.FindXQName(key);
            string ldlx_tq = ldlx.Substring(ldlx.LastIndexOf(":") + 1);
            row3["LDLX"] = ldlx_tq;
            string tudiquanshu_tq = tudiquanshu.Substring(tudiquanshu.LastIndexOf(":") + 1);
            row3["LDQS"] = tudiquanshu;

            row3["MJHJ"] = Math.Round(num2, m_digits);
            row3["XJHJ"] = Math.Round(num3, m_digits);
            row3["ZZSFHJ"] = Math.Round(num4, m_digits);
            row3["FCSYDMJ"] = Math.Round(num5, m_digits);
            row3["FCSYDXJ"] = Math.Round(num6, m_digits);
            row3["FCSYDZSBZ"] = Math.Round(num7, m_digits);
            row3["FCSYDZSFY"] = Math.Round(num8, m_digits);
            row3["CSYDMJ"] = Math.Round(num9, m_digits);
            row3["CSYDXJ"] = Math.Round(mpd, m_digits);
            row3["CSYDZSBZ"] = Math.Round(num11, m_digits);
            row3["CSYDZSFY"] = Math.Round(num12, m_digits);
            string bz_tq = bz.Substring(bz.LastIndexOf(":") + 1);

            row3["BZ"] = bz_tq;

            m_table.Rows.Add(row3);
        }

        protected override DataTable MakeTable()
        {
            System.Data.DataTable table = new System.Data.DataTable("ResultTable");
            DataColumn column = new DataColumn("TJDW", typeof(string));
            table.Columns.Add(column);
            column = new DataColumn("LDLX", typeof(string));
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
            m_table = table;
            return table;
        }
    }
}
