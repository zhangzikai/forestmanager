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
    /// 造林统计--林业生产情况一
    /// </summary>
    public class ShengChanQK1 : ZaoLinTJBase
    {
        /// <summary>
        /// 造林统计--林业生产情况一:构造器
        /// </summary>
        public ShengChanQK1()
        {
        }

        /// <summary>
        /// 返回计算的乡村
        /// </summary>
        /// <param name="lst"></param>
        /// <param name="xiang"></param>
        /// <returns></returns>
        public override DataTable ComputeXiangCun(IEnumerable<Forst_ZL_Mid> lst, string xiang)
        {//返回转换为数字后的造林林班数据
            var lst2 = lst.Where(p => p.ZAO_LIN_LB_I > 110 && p.ZAO_LIN_LB_I < 117);
            return base.ComputeXiangCun(lst2, xiang);
        }
        /// <summary>
        /// 返回计算的县乡
        /// </summary>
        /// <param name="lst"></param>
        /// <returns></returns>
        public override DataTable ComputeXianXiang(IEnumerable<Forst_ZL_Mid> lst)
        {
            var lst2 = lst.Where(p => p.ZAO_LIN_LB_I > 110 && p.ZAO_LIN_LB_I < 117);
            return base.ComputeXianXiang(lst2);
        }
        /// <summary>
        /// 返回计算的县乡村
        /// </summary>
        /// <param name="lst"></param>
        /// <returns></returns>
        public override DataTable ComputeXianXiangCun(IEnumerable<Forst_ZL_Mid> lst)
        {
            var lst2 = lst.Where(p => p.ZAO_LIN_LB_I > 110 && p.ZAO_LIN_LB_I < 117);
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

            num2 = grp.Where(p => p.rgzl && p.huangshandi).Sum(p => p.MIAN_JI);
            num3 = grp.Where(p => p.tgdzl && p.huangshandi).Sum(p => p.MIAN_JI);
            num4 = grp.Where(p => p.zhulin && p.huangshandi).Sum(p => p.MIAN_JI);
            num5 = grp.Where(p => p.feibozaolin && p.huangshandi).Sum(p => p.MIAN_JI);
            num6 = grp.Where(p => p.wulinxinfeng && p.huangshandi).Sum(p => p.MIAN_JI);
            num7 = grp.Where(p => p.guoyoujjzaolin && p.huangshandi).Sum(p => p.MIAN_JI);
            num8 = grp.Where(p => p.jitijjzaolin && p.huangshandi).Sum(p => p.MIAN_JI);
            num9 = num7 + num8;
            num10 = grp.Where(p => p.feigongjjzaolin && p.huangshandi).Sum(p => p.MIAN_JI);
            num11 = num9 + num10;

            num12 = grp.Where(p => p.shamu && p.huangshandi).Sum(p => p.MIAN_JI);
            num13 = grp.Where(p => p.songlei && p.huangshandi).Sum(p => p.MIAN_JI);
            num14 = grp.Where(p => p.anshu && p.huangshandi).Sum(p => p.MIAN_JI);
            num15 = grp.Where(p => p.xiangsi && p.huangshandi).Sum(p => p.MIAN_JI);
            num16 = grp.Where(p => p.yclqita && p.huangshandi).Sum(p => p.MIAN_JI);
            num17 = grp.Where(p => p.sushengfcl && p.huangshandi).Sum(p => p.MIAN_JI);
            num18 = (((num12 + num13) + num14) + num15) + num16;

            num19 = grp.Where(p => p.youcha && p.huangshandi).Sum(p => p.MIAN_JI);
            num20 = grp.Where(p => p.youtong && p.huangshandi).Sum(p => p.MIAN_JI);
            num21 = grp.Where(p => p.bajiao && p.huangshandi).Sum(p => p.MIAN_JI);
            num22 = grp.Where(p => p.yugui && p.huangshandi).Sum(p => p.MIAN_JI);
            num23 = grp.Where(p => p.hetao && p.huangshandi).Sum(p => p.MIAN_JI);
            num24 = grp.Where(p => p.banli && p.huangshandi).Sum(p => p.MIAN_JI);
            num25 = grp.Where(p => p.yinxing && p.huangshandi).Sum(p => p.MIAN_JI);
            num26 = grp.Where(p => p.guoshu && p.huangshandi).Sum(p => p.MIAN_JI);
            num27 = grp.Where(p => p.jjlqita && p.huangshandi).Sum(p => p.MIAN_JI);
            num28 = (((((((num19 + num20) + num21) + num22) + num23) + num24) + num25) + num26) + num27;

            num29 = grp.Where(p => p.fanghulin && p.huangshandi).Sum(p => p.MIAN_JI);
            num30 = grp.Where(p => p.xintanlin && p.huangshandi).Sum(p => p.MIAN_JI);
            num31 = grp.Where(p => p.teyonglin && p.huangshandi).Sum(p => p.MIAN_JI);
            if (num11 > 0.0)
            {
                DataRow row3 = resultTable.NewRow();
                row3["TJDW"] = MDM.FindXQName(key);
                row3["HSZLZJ"] = Math.Round(num11, m_digits);
                row3["RGZLZJ"] = Math.Round(num2, m_digits);
                row3["TGDZL"] = Math.Round(num3, m_digits);
                row3["ZLMJ"] = Math.Round(num4, m_digits);
                row3["FBZL"] = Math.Round(num5, m_digits);
                row3["WLDSLDXF"] = Math.Round(num6, m_digits);
                row3["GYJJZLZJ"] = Math.Round(num9, m_digits);
                row3["GYJJZL"] = Math.Round(num7, m_digits);
                row3["JTJJZL"] = Math.Round(num8, m_digits);
                row3["FGYJJZL"] = Math.Round(num10, m_digits);
                row3["YCLZJ"] = Math.Round(num18, m_digits);
                row3["ShaMu"] = Math.Round(num12, m_digits);
                row3["SongShu"] = Math.Round(num13, m_digits);
                row3["AnShu"] = Math.Round(num14, m_digits);
                row3["XiangSi"] = Math.Round(num15, m_digits);
                row3["YCLQT"] = Math.Round(num16, m_digits);
                row3["SSFCL"] = Math.Round(num17, m_digits);
                row3["JJLZJ"] = Math.Round(num28, m_digits);
                row3["YouCha"] = Math.Round(num19, m_digits);
                row3["YouTong"] = Math.Round(num20, m_digits);
                row3["BaJiao"] = Math.Round(num21, m_digits);
                row3["YuGui"] = Math.Round(num22, m_digits);
                row3["HeTao"] = Math.Round(num23, m_digits);
                row3["BanLi"] = Math.Round(num24, m_digits);
                row3["YinXing"] = Math.Round(num25, m_digits);
                row3["GuoShu"] = Math.Round(num26, m_digits);
                row3["JJLQT"] = Math.Round(num27, m_digits);
                row3["FHLMJ"] = Math.Round(num29, m_digits);
                row3["XTLMJ"] = Math.Round(num30, m_digits);
                row3["TZYTLMJ"] = Math.Round(num31, m_digits);
                resultTable.Rows.Add(row3);
            }
        }

        protected override DataTable MakeTable()
        {
            DataTable table = new DataTable("ResultTable");
            table.Columns.Add("TJDW", typeof(string));
            table.Columns.Add("HSZLZJ", typeof(double));
            table.Columns.Add("RGZLZJ", typeof(double));
            table.Columns.Add("TGDZL", typeof(double));
            table.Columns.Add("ZLMJ", typeof(double));
            table.Columns.Add("FBZL", typeof(double));
            table.Columns.Add("WLDSLDXF", typeof(double));
            table.Columns.Add("GYJJZLZJ", typeof(double));
            table.Columns.Add("GYJJZL", typeof(double));
            table.Columns.Add("JTJJZL", typeof(double));
            table.Columns.Add("FGYJJZL", typeof(double));
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
