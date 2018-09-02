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
    /// 造林统计--林业生产情况四
    /// </summary>
    public class ShengChanQK4 : ZaoLinTJBase
    {
        /// <summary>
        /// 造林统计--林业生产情况四：构造器
        /// </summary>
        public ShengChanQK4()
        {

        }

        protected override void MakeRow(DataTable resultTable, string key, IEnumerable<Forst_ZL_Mid> grp)
        {
            double num1 = 0.0;
            double num2 = 0.0;
            double num3 = 0.0;
            double num4 = 0.0;
            double num5 = 0.0;
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
            int num6;
            num1 = 0;
            num2 = 0; 
           
            num3 = grp.Where(p => p.youlinfuyu).Sum(p => p.MIAN_JI);
            num4 = grp.Where(p => p.youlinfuyu).Sum(p => p.HSMJ);

            num5 = grp.Where(p => p.chenglin).Sum(p => p.MIAN_JI);
            num7 = grp.Where(p => p.chenglin).Sum(p => p.MIAN_JI);

            num8 = 0.0;
            num9 = 0.0;
            num10 = 0.0;
            num11 = 0.0;
            num12 = 0.0;
            num13 = 0.0;
            num14 = grp.Sum(p => p.MIAN_JI);
            num15 = grp.Sum(p => p.MIAN_JI);
            num16 = grp.Sum(p => p.MIAN_JI);
            num17 = grp.Where(p => p.digaizaolin).Sum(p => p.MIAN_JI);
            num18 = grp.Where(p => p.chenglin).Sum(p => p.MIAN_JI);
            num19 = 0;
            ////num5 = grp.Where(p => p.jitijjzaolin).Sum(p => p.MIAN_JI);

            DataRow row3 = resultTable.NewRow();
            ////num6 = 1;//为每行遍历赋予0
            ////while (num6 < resultTable.Columns.Count)
            ////{
            ////    row3[num6] = 0;
            ////    num6++;
            ////}
            row3["TJDW"] = MDM.FindXQName(key);

            row3["SPZS"] = Math.Round(num1, m_digits);
            row3["NMSYFYMJ"] = Math.Round(num2, m_digits);
            row3["YLFYZYMJ"] = Math.Round(num3, m_digits);

            row3["YLFYSJMJ"] = Math.Round(num4, m_digits);
            row3["CLFYMJZJ"] = Math.Round(num5, m_digits);
            row3["ZYLFYMJ"] = Math.Round(num7, m_digits);

            row3["FYGZCCLZJ"] = Math.Round(num8, m_digits);
            row3["ZYLFYGZCCL"] = Math.Round(num9, m_digits);
            row3["LMZZCJL"] = Math.Round(num10, m_digits);
            row3["YMMJHJ"] = Math.Round(num11, m_digits);
            row3["BNXZYMMJ"] = Math.Round(num12, m_digits);
            row3["DNMMCL"] = Math.Round(num13, m_digits);
            row3["NMSYMSLMJ"] = Math.Round(num14, m_digits);
            row3["NMSYZZYMJ"] = Math.Round(num15, m_digits);
            row3["DNZFMJ"] = Math.Round(num16, m_digits);
            row3["DNDCLGZFMJ"] = Math.Round(num17, m_digits);
            row3["DNFYJFMJ"] = Math.Round(num18, m_digits);
            row3["DNLCGYQYYLJD"] = Math.Round(num19, m_digits);

            #region 源代码中的判断导致表单无法输出
            ////if ((num4 > 0.0) || (num3 > 0.0))
            ////{
            ////    resultTable.Rows.Add(row3);
            ////}
            #endregion
            resultTable.Rows.Add(row3);
        }
        protected override DataTable MakeTable()
        {
            DataTable table = new DataTable("ResultTable");
            table.Columns.Add("TJDW", typeof(string));
            table.Columns.Add("SPZS", typeof(double));
            table.Columns.Add("NMSYFYMJ", typeof(double));
            table.Columns.Add("YLFYZYMJ", typeof(double));
            table.Columns.Add("YLFYSJMJ", typeof(double));
            table.Columns.Add("CLFYMJZJ", typeof(double));
            table.Columns.Add("ZYLFYMJ", typeof(double));
            table.Columns.Add("FYGZCCLZJ", typeof(double));
            table.Columns.Add("ZYLFYGZCCL", typeof(double));
            table.Columns.Add("LMZZCJL", typeof(double));
            table.Columns.Add("YMMJHJ", typeof(double));
            table.Columns.Add("BNXZYMMJ", typeof(double));
            table.Columns.Add("DNMMCL", typeof(double));
            table.Columns.Add("NMSYMSLMJ", typeof(double));
            table.Columns.Add("NMSYZZYMJ", typeof(double));
            table.Columns.Add("DNZFMJ", typeof(double));
            table.Columns.Add("DNDCLGZFMJ", typeof(double));
            table.Columns.Add("DNFYJFMJ", typeof(double));
            table.Columns.Add("DNLCGYQYYLJD", typeof(double));
            return table;
        }
    }
}
