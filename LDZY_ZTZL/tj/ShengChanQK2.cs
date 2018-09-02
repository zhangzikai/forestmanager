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
    /// 造林统计--林业生产情况二
    /// </summary>
    public class ShengChanQK2 : ZaoLinTJBase
    {
        /// <summary>
        /// 造林统计--林业生产情况二:构造器
        /// </summary>
        public ShengChanQK2()
        {
        }

        /// <summary>
        /// 返回计算的乡村
        /// </summary>
        /// <param name="lst"></param>
        /// <param name="xiang"></param>
        /// <returns></returns>
        public override DataTable ComputeXiangCun(IEnumerable<Forst_ZL_Mid> lst, string xiang)
        {
            var lst2 = lst.Where(p => p.ZAO_LIN_LB_I < 127);
            return base.ComputeXiangCun(lst2, xiang);
        }

        /// <summary>
        ///  返回计算的县乡
        /// </summary>
        /// <param name="lst"></param>
        /// <returns></returns>
        public override DataTable ComputeXianXiang(IEnumerable<Forst_ZL_Mid> lst)
        {
            var lst2 = lst.Where(p => p.ZAO_LIN_LB_I < 127);
            return base.ComputeXianXiang(lst2);
        }
        /// <summary>
        /// 返回计算的县乡村
        /// </summary>
        /// <param name="lst"></param>
        /// <returns></returns>
        public override DataTable ComputeXianXiangCun(IEnumerable<Forst_ZL_Mid> lst)
        {
            var lst2 = lst.Where(p => p.ZAO_LIN_LB_I < 127);
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
            double num17 = 0.0;
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
            double num28 = 0.0;
            double num29 = 0.0;
            double num30 = 0.0;
            double num31 = 0.0;
            double num32 = 0.0;
            double num33 = 0.0;
            //HSZLZJ
            num2 = grp.Where(p => p.linguanxiazaolin).Sum(p => p.MIAN_JI);
            num3 = grp.Where(p => p.feibolinb2).Sum(p => p.MIAN_JI);
            num4 = grp.Where(p => p.youlindixinfeng).Sum(p => p.MIAN_JI);

            num5 = (num2 + num3) + num4;

            num6 = grp.Where(p => p.gengxinzaolin && p.jidisql).Sum(p => p.MIAN_JI);
            num7 = grp.Where(p => p.zhulin && p.jidisql).Sum(p => p.MIAN_JI);
            num8 = grp.Where(p => p.rengongcujingengxin).Sum(p => p.MIAN_JI);
            num9 = num6 + num8;
            num10 = grp.Where(p => p.guoyoujjzaolin && p.gengxinzaolin2 && p.jidisql).Sum(p => p.MIAN_JI);
            num11 = grp.Where(p => p.jitijjzaolin && p.gengxinzaolin2 && p.jidisql).Sum(p => p.MIAN_JI);
            num12 = num10 + num11;


            num13 = grp.Where(p => p.feigongjjzaolin && p.gengxinzaolin2 && p.jidisql).Sum(p => p.MIAN_JI);
            num14 = grp.Where(p => p.shamu && p.jidisql).Sum(p => p.MIAN_JI);
            num15 = grp.Where(p => p.songlei && p.jidisql).Sum(p => p.MIAN_JI);
            num16 = grp.Where(p => p.anshu && p.jidisql).Sum(p => p.MIAN_JI);
            num17 = grp.Where(p => p.xiangsi && p.jidisql).Sum(p => p.MIAN_JI);
            num18 = grp.Where(p => p.yclqita && p.jidisql).Sum(p => p.MIAN_JI);
            num19 = grp.Where(p => p.sushengfcl && p.jidisql).Sum(p => p.MIAN_JI);

            num20 = (((num14 + num15) + num16) + num17) + num18;

            num21 = grp.Where(p => p.youcha && p.jidisql).Sum(p => p.MIAN_JI);
            num22 = grp.Where(p => p.youtong && p.jidisql).Sum(p => p.MIAN_JI);
            num23 = grp.Where(p => p.bajiao && p.jidisql).Sum(p => p.MIAN_JI);

            num24 = grp.Where(p => p.yugui && p.jidisql).Sum(p => p.MIAN_JI);
            num25 = grp.Where(p => p.hetao && p.jidisql).Sum(p => p.MIAN_JI);
            num26 = grp.Where(p => p.banli && p.jidisql).Sum(p => p.MIAN_JI);
            num27 = grp.Where(p => p.yinxing && p.jidisql).Sum(p => p.MIAN_JI);
            num28 = grp.Where(p => p.guoshu && p.jidisql).Sum(p => p.MIAN_JI);

            num29 = grp.Where(p => p.jjlqita && p.jidisql).Sum(p => p.MIAN_JI);
            num30 = (((((((num21 + num22) + num23) + num24) + num25) + num26) + num27) + num28) + num29;
            num31 = grp.Where(p => p.fanghulin && p.jidisql).Sum(p => p.MIAN_JI);

            num32 = grp.Where(p => p.xintanlin && p.jidisql).Sum(p => p.MIAN_JI);
            num33 = grp.Where(p => p.teyonglin && p.jidisql).Sum(p => p.MIAN_JI);
            num9 = num12 + num13;

            DataRow row3 = resultTable.NewRow();
            row3["TJDW"] = MDM.FindXQName(key);
            row3["YLDZLZJ"] = Math.Round(num5, m_digits);
            row3["LGXZL"] = Math.Round(num2, m_digits);
            row3["FBYL"] = Math.Round(num3, m_digits);
            row3["YLDXF"] = Math.Round(num4, m_digits);
            row3["JDGXZJ"] = Math.Round(num9, m_digits);
            row3["GXZLZMJ"] = Math.Round(num6, m_digits);
            row3["JDGXZLMJ"] = Math.Round(num7, m_digits);
            row3["RGCJGXMJ"] = Math.Round(num8, m_digits);
            row3["JDGXGYJJZLZJ"] = Math.Round(num12, m_digits);
            row3["JDGXGYJJZL"] = Math.Round(num10, m_digits);
            row3["JDGXJTJJZL"] = Math.Round(num11, m_digits);
            row3["JDGXFGYJJZL"] = Math.Round(num13, m_digits);
            row3["YCLZJ"] = Math.Round(num20, m_digits);
            row3["ShaMu"] = Math.Round(num14, m_digits);
            row3["SongShu"] = Math.Round(num15, m_digits);
            row3["AnShu"] = Math.Round(num16, m_digits);
            row3["XiangSi"] = Math.Round(num17, m_digits);
            row3["YCLQT"] = Math.Round(num18, m_digits);
            row3["SSFCL"] = Math.Round(num19, m_digits);
            row3["JJLZJ"] = Math.Round(num30, m_digits);
            row3["YouCha"] = Math.Round(num21, m_digits);
            row3["YouTong"] = Math.Round(num22, m_digits);
            row3["BaJiao"] = Math.Round(num23, m_digits);
            row3["YuGui"] = Math.Round(num24, m_digits);
            row3["HeTao"] = Math.Round(num25, m_digits);
            row3["BanLi"] = Math.Round(num26, m_digits);
            row3["YinXing"] = Math.Round(num27, m_digits);
            row3["GuoShu"] = Math.Round(num28, m_digits);
            row3["JJLQT"] = Math.Round(num29, m_digits);
            row3["FHLMJ"] = Math.Round(num31, m_digits);
            row3["XTLMJ"] = Math.Round(num32, m_digits);
            row3["TZYTLMJ"] = Math.Round(num33, m_digits);
            resultTable.Rows.Add(row3);

        }

        protected override DataTable MakeTable()
        {
            DataTable table = new DataTable("ResultTable");
            table.Columns.Add("TJDW", typeof(string));
            table.Columns.Add("YLDZLZJ", typeof(double));
            table.Columns.Add("LGXZL", typeof(double));
            table.Columns.Add("FBYL", typeof(double));
            table.Columns.Add("YLDXF", typeof(double));
            table.Columns.Add("JDGXZJ", typeof(double));
            table.Columns.Add("GXZLZMJ", typeof(double));
            table.Columns.Add("JDGXZLMJ", typeof(double));
            table.Columns.Add("RGCJGXMJ", typeof(double));
            table.Columns.Add("JDGXGYJJZLZJ", typeof(double));
            table.Columns.Add("JDGXGYJJZL", typeof(double));
            table.Columns.Add("JDGXJTJJZL", typeof(double));
            table.Columns.Add("JDGXFGYJJZL", typeof(double));
            table.Columns.Add("YCLZJ", typeof(double));
            table.Columns.Add("ShaMu", typeof(double));
            table.Columns.Add("SongShu", typeof(double));
            table.Columns.Add("AnShu", typeof(double));
            table.Columns.Add("XiangSi", typeof(double));
            table.Columns.Add("YCLQT", typeof(double));
            table.Columns.Add("SSFCL", typeof(double));
            table.Columns.Add("JJLZJ", typeof(double));
            table.Columns.Add("YouCha", typeof(double));
            table.Columns.Add("YouTong", typeof(double));
            table.Columns.Add("BaJiao", typeof(double));
            table.Columns.Add("YuGui", typeof(double));
            table.Columns.Add("HeTao", typeof(double));
            table.Columns.Add("BanLi", typeof(double));
            table.Columns.Add("YinXing", typeof(double));
            table.Columns.Add("GuoShu", typeof(double));
            table.Columns.Add("JJLQT", typeof(double));
            table.Columns.Add("FHLMJ", typeof(double));
            table.Columns.Add("XTLMJ", typeof(double));
            table.Columns.Add("TZYTLMJ", typeof(double));
            return table;
        }
    }
}
