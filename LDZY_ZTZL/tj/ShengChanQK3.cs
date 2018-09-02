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
    /// 造林统计--林业生产情况三
    /// </summary>
    public class ShengChanQK3 : ZaoLinTJBase
    {
        /// <summary>
        /// 造林统计--林业生产情况三:构造器
        /// </summary>
        public ShengChanQK3()
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
            var lst2 = lst.Where(p => p.ZAO_LIN_LB_I == 122&&p.XIAN==xiang);
            return base.ComputeXiangCun(lst2, xiang);
        }
        /// <summary>
        /// 返回计算的县乡
        /// </summary>
        /// <param name="lst"></param>
        /// <returns></returns>
        public override DataTable ComputeXianXiang(IEnumerable<Forst_ZL_Mid> lst)
        {
            var lst2 = lst.Where(p => p.ZAO_LIN_LB_I == 122);
            return base.ComputeXianXiang(lst2);
        }

        /// <summary>
        /// 返回计算的县乡村
        /// </summary>
        /// <param name="lst"></param>
        /// <returns></returns>
        public override DataTable ComputeXianXiangCun(IEnumerable<Forst_ZL_Mid> lst)
        {
            var lst2 = lst.Where(p => p.ZAO_LIN_LB_I == 122);
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
            num2 = grp.Sum(p => p.MIAN_JI);
            num3 = grp.Where(p => p.tgdzl).Sum(p => p.MIAN_JI);
            num4 = grp.Where(p => p.guoyoujjzaolin).Sum(p => p.MIAN_JI);
            num5 = grp.Where(p => p.jitijjzaolin).Sum(p => p.MIAN_JI);
            num6 = num4 + num5;
            num7 = grp.Where(p => p.feigongjjzaolin).Sum(p => p.MIAN_JI);
            num8 = num6 + num7;

            var yongLst = grp.Where(p => p.yongcailin);

            num9 = yongLst.Where(p => p.shamu).Sum(p => p.MIAN_JI);
            num10 = yongLst.Where(p => p.songlei).Sum(p => p.MIAN_JI);
            num11 = yongLst.Where(p => p.anshu).Sum(p => p.MIAN_JI);
            num12 = yongLst.Where(p => p.xiangsi).Sum(p => p.MIAN_JI);
            num13 = yongLst.Where(p => p.yclqita).Sum(p => p.MIAN_JI);
            num14 = yongLst.Where(p => p.sushengfcl).Sum(p => p.MIAN_JI);
            num15 = (((num9 + num10) + num11) + num12) + num13;
            var jjlLst = grp.Where(p => p.jingjilin);

            num16 = jjlLst.Where(p => p.youcha).Sum(p => p.MIAN_JI);

            num17 = jjlLst.Where(p => p.youtong).Sum(p => p.MIAN_JI);
            num18 = jjlLst.Where(p => p.bajiao).Sum(p => p.MIAN_JI);
            num19 = jjlLst.Where(p => p.yugui).Sum(p => p.MIAN_JI);
            num20 = jjlLst.Where(p => p.hetao).Sum(p => p.MIAN_JI);
            num21 = jjlLst.Where(p => p.banli).Sum(p => p.MIAN_JI);
            num22 = jjlLst.Where(p => p.yinxing).Sum(p => p.MIAN_JI);
            num23 = jjlLst.Where(p => p.guoshu).Sum(p => p.MIAN_JI);
            num24 = jjlLst.Where(p => p.jjlqita).Sum(p => p.MIAN_JI);
            num25 = (((((((num16 + num17) + num18) + num19) + num20) + num21) + num22) + num23) + num24;


            num26 = grp.Where(p => p.fanghulin).Sum(p => p.MIAN_JI);
            num27 = grp.Where(p => p.xintanlin).Sum(p => p.MIAN_JI);
            num28 = grp.Where(p => p.teyonglin).Sum(p => p.MIAN_JI);

            DataRow row3 = resultTable.NewRow();
            row3["TJDW"] = MDM.FindXQName(key);
            row3["ZLZJ"] = Math.Round(num8, m_digits);
            row3["DCDXLMJ"] = Math.Round(num2, m_digits);
            row3["ZhuLin"] = Math.Round(num3, m_digits);
            row3["DCDXGYJJZLZJ"] = Math.Round(num6, m_digits);
            row3["DCDXGYJJZL"] = Math.Round(num4, m_digits);
            row3["DCDXJTJJZL"] = Math.Round(num5, m_digits);
            row3["DCDXFGYJJZL"] = Math.Round(num7, m_digits);
            row3["YCLZJ"] = Math.Round(num15, m_digits);
            row3["ShaMu"] = Math.Round(num9, m_digits);
            row3["SongShu"] = Math.Round(num10, m_digits);
            row3["AnShu"] = Math.Round(num11, m_digits);
            row3["XiangSi"] = Math.Round(num12, m_digits);
            row3["YCLQT"] = Math.Round(num13, m_digits);
            row3["SSFCL"] = Math.Round(num14, m_digits);
            row3["JJLZJ"] = Math.Round(num25, m_digits);
            row3["YouCha"] = Math.Round(num16, m_digits);
            row3["YouTong"] = Math.Round(num17, m_digits);
            row3["BaJiao"] = Math.Round(num18, m_digits);
            row3["YuGui"] = Math.Round(num19, m_digits);
            row3["HeTao"] = Math.Round(num20, m_digits);
            row3["BanLi"] = Math.Round(num21, m_digits);
            row3["YinXing"] = Math.Round(num22, m_digits);
            row3["GuoShu"] = Math.Round(num23, m_digits);
            row3["JJLQT"] = Math.Round(num24, m_digits);
            row3["FHLMJ"] = Math.Round(num26, m_digits);
            row3["XTLMJ"] = Math.Round(num27, m_digits);
            row3["TZYTLMJ"] = Math.Round(num28, m_digits);
            resultTable.Rows.Add(row3);

        }

        protected override DataTable MakeTable()
        {
            DataTable table = new DataTable("ResultTable");
            table.Columns.Add("TJDW", typeof(string));
            table.Columns.Add("ZLZJ", typeof(double));
            table.Columns.Add("DCDXLMJ", typeof(double));
            table.Columns.Add("ZhuLin", typeof(double));
            table.Columns.Add("DCDXGYJJZLZJ", typeof(double));
            table.Columns.Add("DCDXGYJJZL", typeof(double));
            table.Columns.Add("DCDXJTJJZL", typeof(double));
            table.Columns.Add("DCDXFGYJJZL", typeof(double));
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
