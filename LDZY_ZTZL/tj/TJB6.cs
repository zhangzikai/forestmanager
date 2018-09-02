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
    /// 造林统计的年报表
    /// </summary>
    public class TJB6 : ZaoLinTJBase
    {
        /// <summary>
        /// 造林统计的年报表：构造器
        /// </summary>
        public TJB6()
        {        

        } 
        protected override void MakeRow(DataTable resultTable, string key, IEnumerable<Forst_ZL_Mid> grp)
        {
            double num1 = 0.0;
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

            num1 = grp.Sum(p => p.MIAN_JI);
            num2 = num3 + num4 + num5;
            ///num2 = grp.Where(p => p.rgzl && p.huangshandi).Sum(p => p.MIAN_JI);
            num3 = grp.Where(p => p.tgdzl).Sum(p => p.MIAN_JI);
            num4 = grp.Where(p => p.zhufanglin && p.rgzl).Sum(p => p.MIAN_JI);
            num5 = grp.Where(p => p.rgzl && p.haifanglin).Sum(p => p.MIAN_JI);
            num6 = grp.Where(p => p.gengxinzaolin2 && p.jidisql).Sum(p => p.MIAN_JI);
            num7 = grp.Where(p => p.jidisql).Sum(p=>p.MIAN_JI); ;
            num8 = grp.Where(p => p.digaizaolin).Sum(p => p.MIAN_JI);
            ////num8 = grp.Where(p => p.zhufanglin).Sum(p => p.MIAN_JI);
            num9 = grp.Where(p => p.zhufanglin && p.zytzwc).Sum(p => p.MIAN_JI);
            num10 = grp.Where(p => p.tgdzlgclb).Sum(p => p.MIAN_JI);
            num18 = num9 + num10;

            ///num11 = grp.Where(p => p.pingyuanlh && p.zytzwc).Sum(p => p.MIAN_JI);
            num12 = grp.Where(p => p.ssfcycl).Sum(p => p.MIAN_JI);

            num13 = grp.Where(p => p.ssfcycl && p.zytzwc).Sum(p => p.MIAN_JI);
            num14 = grp.Where(p => p.zhongcao).Sum(p => p.MIAN_JI);
            num15 = (((num5 + num6) + num8) + num10) + num12;
            num16 = num2 - num15;

            num19 = grp.Where(p => p.nongdizaolin).Sum(p=>p.MIAN_JI);

            int num17=1;
            ///源代码判断有误 if (num2 > 0.0)
            if (!(num2 > 0.0))
            {
                DataRow row5 = resultTable.NewRow();
                num17 = 1;           
                while (num17 < resultTable.Columns.Count)
                {
                    row5[num17] = 0;
                    num17++;
                }
                row5["TJDW"] = MDM.FindXQName(key); ;
                row5["ZZLMJ"] = Math.Round(num1, m_digits);
                row5["RGZLMJHJ"] = Math.Round(num2, m_digits);
                row5["RGZLTGMJ"] = Math.Round(num3, m_digits);
                row5["RGZLZFMJ"] = Math.Round(num4, m_digits);
                row5["RGZLHFMJ"] = Math.Round(num5, m_digits);
                row5["JDGXMJ"] = Math.Round(num7, m_digits);
                row5["DGMJ"] = Math.Round(num8, m_digits);
                row5["FSYLMJ"] = Math.Round(num18, m_digits);
                row5["FSYLZFL"] = Math.Round(num9, m_digits);
                row5["FSYLTG"] = Math.Round(num10, m_digits);
                row5["SFLMJ"] = Math.Round(num12, m_digits);
                row5["YWZSZS"] = Math.Round(num13, m_digits);
                row5["STBCMJ"] = Math.Round(num16, m_digits);
                row5["NDZLMJ"] = Math.Round(num19, m_digits);
                resultTable.Rows.Add(row5);
            }
        }
        protected override DataTable MakeTable()
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
            table.Columns.Add("NDZLMJ", typeof(double));//源代码有误
            return table;
        }
    }
}
