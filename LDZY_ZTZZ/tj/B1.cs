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
    public class B1 : ZDZYTJBase
    {
        private DataTable m_table;

        private string tudiquanshu;

        public B1()
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
            double num14 = 0.0;
            double num15 = 0.0;
            double num16 = 0.0;
            double num17 = 0.0;
            double num18 = 0.0;
            double num19 = 0.0;
            double num20 = 0.0;
            double num21 = 0.0;
            double num22 = 0.0;
            double num23 = 0.0;
            double num24 = 0.0;

            string xiabn_tq = xiban.Substring(xiban.LastIndexOf(":") + 1);

            num2 = data.Where(p=>p.XI_BAN == xiabn_tq).Sum(p => p.MIAN_JI);
            num3 = data.Where(p => p.XI_BAN == xiabn_tq).Sum(p => p.SLXJ);

            num4 = data.Where(p => p.LDLX == "1" && p.XI_BAN == xiabn_tq).Sum(p => p.MIAN_JI);
            num5 = data.Where(p => p.LDLX == "1" && p.DI_LEI == "1610" && p.XI_BAN == xiabn_tq).Sum(p => p.MIAN_JI);
            num6 = data.Where(p => p.LDLX == "1" && p.DI_LEI == "1310" && p.XI_BAN == xiabn_tq).Sum(p => p.MIAN_JI);
            num7 = data.Where(p => p.LDLX == "1" && p.XI_BAN == xiabn_tq).Sum(p => p.SLXJ);

            num8 = data.Where(p => p.LDLX == "2" && p.XI_BAN == xiabn_tq).Sum(p => p.MIAN_JI);
            num9 = data.Where(p => p.LDLX == "2" && p.DI_LEI == "1610" && p.XI_BAN == xiabn_tq).Sum(p => p.MIAN_JI);
            num10 = data.Where(p => p.LDLX == "2" && p.DI_LEI == "1310" && p.XI_BAN == xiabn_tq).Sum(p => p.MIAN_JI);
            num11 = data.Where(p => p.LDLX == "2" && p.XI_BAN == xiabn_tq).Sum(p => p.SLXJ);

            num12 = data.Where(p => p.LDLX == "3" && p.XI_BAN == xiabn_tq).Sum(p => p.MIAN_JI);
            num13 = data.Where(p => p.LDLX == "3" && p.DI_LEI == "1610" && p.XI_BAN == xiabn_tq).Sum(p => p.MIAN_JI);
            num14 = data.Where(p => p.LDLX == "3" && p.XI_BAN == xiabn_tq).Sum(p => p.SLXJ);

            num15 = data.Where(p => p.LDLX == "4" && p.XI_BAN == xiabn_tq).Sum(p => p.MIAN_JI);
            num16 = data.Where(p => p.LDLX == "4" && p.DI_LEI == "1610" && p.XI_BAN == xiabn_tq).Sum(p => p.MIAN_JI);
            num17 = data.Where(p => p.LDLX == "4" && p.XI_BAN == xiabn_tq).Sum(p => p.SLXJ);

            num18 = data.Where(p => p.LDLX == "5" && p.XI_BAN == xiabn_tq).Sum(p => p.MIAN_JI);
            num19 = data.Where(p => p.LDLX == "5" && p.DI_LEI == "1610" && p.XI_BAN == xiabn_tq).Sum(p => p.MIAN_JI);
            num20 = data.Where(p => p.LDLX == "5" && p.XI_BAN == xiabn_tq).Sum(p => p.SLXJ);

            num21 = data.Where(p => p.LDLX == "6" && p.XI_BAN == xiabn_tq).Sum(p => p.MIAN_JI);
            num22 = data.Where(p => p.LDLX == "6" && p.XI_BAN == xiabn_tq).Sum(p => p.SLXJ);

            num23 = data.Where(p => p.LDLX == "7" && p.XI_BAN == xiabn_tq).Sum(p => p.MIAN_JI);
            num24 = data.Where(p => p.LDLX == "7" && p.XI_BAN == xiabn_tq).Sum(p => p.SLXJ);

            DataRow row3 = m_table.NewRow();
            string s = MDM.FindXQName(key);
            row3["TJDW"] = MDM.FindXQName(key);

            string tudiquanshu_tq = tudiquanshu.Substring(tudiquanshu.LastIndexOf(":") + 1);
            row3["LDQS"] = tudiquanshu_tq;
            row3["MJHJ"] = Math.Round(num2, m_digits);
            row3["XJHJ"] = Math.Round(num3, m_digits);
            row3["FHLDMJ"] = Math.Round(num4, m_digits);
            row3["FHLDGJMJ"] = Math.Round(num5, m_digits);
            row3["FHLDCFMJ"] = Math.Round(num6, m_digits);
            row3["FHLDXJ"] = Math.Round(num7, m_digits);
            row3["TYLLDMJ"] = Math.Round(num8, m_digits);
            row3["TYLDGJMJ"] = Math.Round(num9, m_digits);
            row3["TYLDCFMJ"] = Math.Round(num10, m_digits);
            row3["TYLDXJ"] = Math.Round(num11, m_digits);
            row3["YCLMJ"] = Math.Round(num12, m_digits);

            row3["YCLCFJDMJ"] = Math.Round(num13, m_digits);
            row3["YCLXJ"] = Math.Round(num14, m_digits);
            row3["JJLMJ"] = Math.Round(num15, m_digits);
            row3["JJLCFJDMJ"] = Math.Round(num16, m_digits);
            row3["JJLXJ"] = Math.Round(num17, m_digits);
            row3["XTLMJ"] = Math.Round(num18, m_digits);
            row3["XTLCFJDMJ"] = Math.Round(num19, m_digits);
            row3["XTLXJ"] = Math.Round(num20, m_digits);
            row3["MPDMJ"] = Math.Round(num21, m_digits);
            row3["MPDXJ"] = Math.Round(num22, m_digits);
            row3["QTLDMJ"] = Math.Round(num23, m_digits);
            row3["QTLDXJ"] = Math.Round(num24, m_digits);
            m_table.Rows.Add(row3);
        }

        protected override DataTable MakeTable()
        {
            System.Data.DataTable table = new System.Data.DataTable("ResultTable");
            table.Columns.Add("TJDW", typeof(string));

            table.Columns.Add("LDQS", typeof(string));
            table.Columns.Add("MJHJ", typeof(double));
            table.Columns.Add("XJHJ", typeof(double));
            table.Columns.Add("FHLDMJ", typeof(double));

            table.Columns.Add("FHLDGJMJ", typeof(double));
            table.Columns.Add("FHLDCFMJ", typeof(double));
            table.Columns.Add("FHLDXJ", typeof(double));
            table.Columns.Add("TYLLDMJ", typeof(double));
            table.Columns.Add("TYLDGJMJ", typeof(double));
            table.Columns.Add("TYLDCFMJ", typeof(double));
            table.Columns.Add("TYLDXJ", typeof(double));
            table.Columns.Add("YCLMJ", typeof(double));
            table.Columns.Add("YCLCFJDMJ", typeof(double));
            table.Columns.Add("YCLXJ", typeof(double));

            table.Columns.Add("JJLMJ", typeof(double));
            table.Columns.Add("JJLCFJDMJ", typeof(double));
            table.Columns.Add("JJLXJ", typeof(double));
            table.Columns.Add("XTLMJ", typeof(double));
            table.Columns.Add("XTLCFJDMJ", typeof(double));
            table.Columns.Add("XTLXJ", typeof(double));
            table.Columns.Add("MPDMJ", typeof(double));
            table.Columns.Add("MPDXJ", typeof(double));
            table.Columns.Add("QTLDMJ", typeof(double));
            table.Columns.Add("QTLDXJ", typeof(double));
            m_table = table;
            return table;
        }
    }
}
