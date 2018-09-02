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
    public class B2 : ZDZYTJBase
    {
        private DataTable m_table;
        private string tudiquanshu;

        public B2()
        {
            tudiquanshu = "";
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

        protected override void MakeRow(IEnumerable<ZT_LDZZ_2016_Mid> data, string key, string xiban,string tudiquanshu, string qiyuan,string linzhong,string shuzhong, string ldlx,string lmqs,string bz)
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
            double num14 = 0.0;
            double num15 = 0.0;
            double num16 = 0.0;
            double num17 = 0.0;
            double num18 = 0.0;
            double num19 = 0.0;

            string xiabn_tq = xiban.Substring(xiban.LastIndexOf(":") + 1);

            double mpd = data.Where(p => p.LDLX == "6" && p.XI_BAN == xiabn_tq).Sum(p => p.MIAN_JI);
            double zmj = data.Where(p => p.XI_BAN == xiabn_tq).Sum(p => p.MIAN_JI);

            num2 = zmj - mpd;
            num3 = num4 + num5 + num6;

            num4 = data.Where(p => p.DI_LEI == "1111" && p.XI_BAN == xiabn_tq).Sum(p => p.MIAN_JI);
            num5 = data.Where(p => p.DI_LEI == "1120" && p.XI_BAN == xiabn_tq).Sum(p => p.MIAN_JI);
            num6 = data.Where(p => p.DI_LEI == "1130" && p.XI_BAN == xiabn_tq).Sum(p => p.MIAN_JI);

            num7 = data.Where(p => p.DI_LEI == "1200" && p.XI_BAN == xiabn_tq).Sum(p => p.MIAN_JI);
            num8 = data.Where(p => p.DI_LEI == "1310" && p.XI_BAN == xiabn_tq).Sum(p => p.MIAN_JI) + data.Where(p => p.DI_LEI == "1320" && p.XI_BAN == xiabn_tq).Sum(p => p.MIAN_JI);
            num9 = data.Where(p => p.DI_LEI == "1410" && p.XI_BAN == xiabn_tq).Sum(p => p.MIAN_JI);
            num10 = data.Where(p => p.LDLX == "2" && p.DI_LEI == "1310" && p.XI_BAN == xiabn_tq).Sum(p => p.MIAN_JI);
            
            num11 = num12+num13+num14;

            num12 = data.Where(p => p.DI_LEI == "1610" && p.XI_BAN == xiabn_tq).Sum(p => p.MIAN_JI);
            num13 = data.Where(p => p.DI_LEI == "1620" && p.XI_BAN == xiabn_tq).Sum(p => p.MIAN_JI);
            num14 = data.Where(p => p.DI_LEI == "1631" && p.XI_BAN == xiabn_tq).Sum(p => p.SLXJ);

            num15 = num16+num17+num18;
            num16 = data.Where(p => p.DI_LEI == "1710" && p.XI_BAN == xiabn_tq).Sum(p => p.MIAN_JI);
            num17 = data.Where(p => p.DI_LEI == "1720" && p.XI_BAN == xiabn_tq).Sum(p => p.SLXJ);

            num18 = data.Where(p => p.DI_LEI == "1730" && p.XI_BAN == xiabn_tq).Sum(p => p.MIAN_JI);
            num19 = data.Where(p => p.DI_LEI == "2540" && p.XI_BAN == xiabn_tq).Sum(p => p.MIAN_JI);

            DataRow row3 = m_table.NewRow();
            row3["TJDW"] = MDM.FindXQName(key);
            string tudiquanshu_tq = tudiquanshu.Substring(tudiquanshu.LastIndexOf(":") + 1);
            row3["LDQS"] = tudiquanshu_tq;
            row3["LDMJHJ"] = Math.Round(num2, m_digits);
            row3["SLMJXJ"] = Math.Round(num3, m_digits);
            row3["QMLMJ"] = Math.Round(num4, m_digits);
            row3["HSLMJ"] = Math.Round(num5, m_digits);
            row3["ZHULINMJ"] = Math.Round(num6, m_digits);
            row3["SHULDMJ"] = Math.Round(num7, m_digits);
            row3["GMLDMJ"] = Math.Round(num8, m_digits);
            row3["WCLLDMJ"] = Math.Round(num9, m_digits);
            row3["MPDMJ"] = Math.Round(mpd, m_digits);
            row3["WLMLDXJ"] = Math.Round(num11, m_digits);
            row3["CFJDMJ"] = Math.Round(num12, m_digits);

            row3["HSJDMJ"] = Math.Round(num13, m_digits);
            row3["QTWLMMJ"] = Math.Round(num14, m_digits);
            row3["YLDXJ"] = Math.Round(num15, m_digits);
            row3["YLHSMJ"] = Math.Round(num16, m_digits);
            row3["YLSHMJ"] = Math.Round(num17, m_digits);
            row3["YLQTMJ"] = Math.Round(num18, m_digits);
            row3["FZSCLDMJ"] = Math.Round(num19, m_digits);

            m_table.Rows.Add(row3);
        }

        protected override DataTable MakeTable()
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
            m_table = table;
            return table;
        }
    }
}
