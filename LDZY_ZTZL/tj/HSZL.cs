using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using td.db.gis;
using td.db.orm;
using td.logic.sys;
namespace td.forest.zl.tj
{
    /// <summary>
    /// 本年度检查验收合格荒山荒地造林面积统计
    /// </summary>
    public class HSZL : ZaoLinTJBase
    {
        /// <summary>
        /// 本年度检查验收合格荒山荒地造林面积统计:构造器
        /// </summary>
        public HSZL() { }
        public override DataTable ComputeXianXiang(IEnumerable<Forst_ZL_Mid> lst)
        {
            var lst2 = lst.Where(p => (p.ZAO_LIN_LB_I >= 110 && p.ZAO_LIN_LB_I <= 114&&p.huangshandi) || p.ZAO_LIN_LB_I == 130 || p.ZAO_LIN_LB_I == 116 || p.ZAO_LIN_LB_I == 119);
            return base.ComputeXianXiang(lst2);
        }
        public override DataTable ComputeXiangCun(IEnumerable<Forst_ZL_Mid> lst, string xiang)
        {
            var lst2 = lst.Where(p => (p.ZAO_LIN_LB_I >= 110 && p.ZAO_LIN_LB_I <= 114 && p.huangshandi) || p.ZAO_LIN_LB_I == 130 || p.ZAO_LIN_LB_I == 116 || p.ZAO_LIN_LB_I == 119);

            return base.ComputeXiangCun(lst2, xiang);
        }
        public override DataTable ComputeXianXiangCun(IEnumerable<Forst_ZL_Mid> lst)
        {
            var lst2 = lst.Where(p => (p.ZAO_LIN_LB_I >= 110 && p.ZAO_LIN_LB_I <= 114 && p.huangshandi) || p.ZAO_LIN_LB_I == 130 || p.ZAO_LIN_LB_I == 116 || p.ZAO_LIN_LB_I == 119);

            return base.ComputeXianXiangCun(lst2);
        }
        protected override void MakeRow(DataTable resultTable, string key, IEnumerable<Forst_ZL_Mid> grp)
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

            double num18 = 0.0;
            double num19 = 0.0;
            double num20 = 0.0;
            double num21 = 0.0;
            double num22 = 0.0;
            double num23 = 0.0;
            double num24 = 0.0;
            double num25 = 0.0;
            double num26 = 0.0;
            double num27 = 0.0;

            num2 = grp.Sum(p => p.MIAN_JI);
            num3 = grp.Where(p => p.tgdzlgclb).Sum(p => p.MIAN_JI);
            num4 = grp.Where(p => p.tgpthszl).Sum(p => p.MIAN_JI);
            num5 = num3 + num4;
            num6 = grp.Where(p => p.haifanglin).Sum(p => p.MIAN_JI);
            num7 = grp.Where(p => p.haifanglin && p.zytzwc).Sum(p => p.MIAN_JI);
            num8 = grp.Where(p => p.zhufanglin).Sum(p => p.MIAN_JI);
            num9 = grp.Where(p => p.zhufanglin && p.zytzwc).Sum(p => p.MIAN_JI);
            num10 = grp.Where(p => p.pingyuanlh).Sum(p => p.MIAN_JI);
            num11 = grp.Where(p => p.pingyuanlh && p.zytzwc).Sum(p => p.MIAN_JI);
            num12 = grp.Where(p => p.ssfcycl).Sum(p => p.MIAN_JI);

            num13 = grp.Where(p => p.ssfcycl && p.zytzwc).Sum(p => p.MIAN_JI);
            num14 = grp.Where(p => p.zhongcao).Sum(p => p.MIAN_JI);
            num15 = (((num5 + num6) + num8) + num10) + num12;
            num16 =  num2 - num15;

            int num17=1;
            if (num2 > 0.0)
            {
                DataRow row5 = resultTable.NewRow();
                num17 = 1;
                while (num17 < resultTable.Columns.Count)
                {
                    row5[num17] = 0;
                    num17++;
                }
                row5["TJDW"] = MDM.FindXQName(key); ;
                row5["NDZLHJ"] = Math.Round(num2, m_digits);
                row5["LYZDGCHJ"] = Math.Round(num18, m_digits);
                row5["TRLZYBHGC"] = Math.Round(num19, m_digits);
                row5["TGHLGCHJ"] = Math.Round(num5, m_digits);
                row5["TGDZL"] = Math.Round(num3, m_digits);
                row5["TGPTHSHDZL"] = Math.Round(num4, m_digits);
                row5["JJFSYZLGCMJ"] = Math.Round(num20, m_digits);
                row5["SBCJZLGCHJ"] = Math.Round(num21, m_digits);
                row5["SBFHGCHJ"] = Math.Round(num22, m_digits);
                row5["SBFHGCZYTZWCMJ"] = Math.Round(num23, m_digits);

                row5["CJLYFHLHJ"] = Math.Round(num24, m_digits);
                row5["CJLYFHLZYTZWCHJ"] = Math.Round(num25, m_digits);

                row5["YHFHLGCHJ"] = Math.Round(num6, m_digits);
                row5["YHFHLZYTZWCMJ"] = Math.Round(num7, m_digits);
                row5["ZJLYFHLHJ"] = Math.Round(num8, m_digits);
                row5["ZJLYFHLZYTZWCMJ"] = Math.Round(num9, m_digits);
                row5["THSLHHJ"] = Math.Round(num26, m_digits);
                row5["THSLHZYTZWWCMJ"] = Math.Round(num27, m_digits);
                row5["PYLHHJ"] = Math.Round(num10, m_digits);
                row5["PYLHZYTZWWCMJ"] = Math.Round(num11, m_digits);
                row5["SSFCYCLHJ"] = Math.Round(num12, m_digits);
                row5["SSFCYCLZYTZWCMJ"] = Math.Round(num13, m_digits);
                row5["TGHLZYCMJ"] = Math.Round(num14, m_digits);
                row5["YBZLMJ"] = Math.Round(num16, m_digits);
                resultTable.Rows.Add(row5);
            }
        }
        protected override DataTable MakeTable()
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
    }
}
