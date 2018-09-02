using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using td.db.mid.forest;
using td.logic.forest;



namespace td.forest.report.xb
{
    /// <summary>
    /// 小班报表28   土地面积变化统计表
    /// </summary>
    public class XB_Report_28 : XB_Report_Base
    {
        public XB_Report_28()
        {
            // 土地面积变化统计表  ,森林覆盖率%,林木绿化率%
            SheetName = "28";
            m_firstRow = 8;
            m_firstColumn = 1;
            m_table = MakeTable();
        }
        public override DataTable FromMid2Table()
        {
            if (m_xb_dataList.Count < 1) { return m_table; }
            var yssz = m_xb_dataList.Where(p => !string.IsNullOrWhiteSpace(p.YOU_SHI_SZ));
            if (yssz.Count() < 1) { return m_table; }

            var linzh = m_xb_dataList.Where(p => !string.IsNullOrWhiteSpace(p.LIN_ZHONG));
            if (linzh.Count() < 1) { return m_table; }

            var xianGrp = linzh.GroupBy(p => p.XIAN);
            foreach (var xian in xianGrp)
            {
                string xianName = MDM.FindXQName(xian.Key);
                MakeRow(xian, xianName);
                //按乡统计
                var xiangGrps = xian.GroupBy(p => p.XIANG);
                foreach (var xg in xiangGrps)
                {
                    string xiangName = MDM.FindXQName(xg.Key);
                    MakeRow(xian, xianName);
                }
            }
            return m_table;
        }

        protected void MakeRow(IEnumerable<FOR_XIAOBAN_Mid> data, string xzName)
        {
            DataRow row = m_table.NewRow();
            row["TJDW"] = xzName;
            row["tjnd"] = TJYear;

            double yld1 = data.Where(p => p.DI_LEI == "1111" || p.DI_LEI == "1112").Sum(p => p.YXMJ);
            row["yld1"] = yld1;
            double yld2 = data.Where(p => p.DI_LEI == "1120").Sum(p => p.YXMJ);
            row["yld2"] = yld2;
            double yld3 = data.Where(p => p.DI_LEI == "1130").Sum(p => p.YXMJ);
            row["yld3"] = yld3;
            double yldxj = yld1 + yld2 + yld3;
            row["yldxj"] = yldxj;


            double sld = data.Where(p => p.DI_LEI == "1200").Sum(p => p.YXMJ);
            row["sld"] = sld;

            //double s1 = data.Where(p => p.g == "1").Sum(p => p.YXMJ);
            //row["s1"] = s1;
            //double L1xj = data.Where(p => p.LING_ZU == "1").Sum(p => p.ZXJ);
            //row["L1xj"] = L1xj;

            //double s1 = data.Where(p => p.g == "1").Sum(p => p.YXMJ);
            //row["s1"] = s1;
            //double L1xj = data.Where(p => p.LING_ZU == "1").Sum(p => p.ZXJ);
            //row["L1xj"] = L1xj;


            double gm1 = data.Where(p => p.DI_LEI == "1310").Sum(p => p.YXMJ);
            row["gm1"] = gm1;
            double gm2 = data.Where(p => p.DI_LEI == "1320").Sum(p => p.YXMJ);
            row["gm2"] = gm2;
            double gmxj = gm1 + gm2;
            row["gmxj"] = gmxj;


            double wcz = data.Where(p => p.DI_LEI == "1410" || p.DI_LEI == "1420").Sum(p => p.YXMJ);
            row["wcz"] = wcz;

            double mpd = data.Where(p => p.DI_LEI == "1500").Sum(p => p.YXMJ);
            row["mpd"] = mpd;

            double wlm1 = data.Where(p => p.DI_LEI == "1610").Sum(p => p.YXMJ);
            row["wlm1"] = wlm1;
            double wlm2 = data.Where(p => p.DI_LEI == "1620").Sum(p => p.YXMJ);
            row["wlm2"] = wlm2;
            double wlm3 = data.Where(p => p.DI_LEI == "1631").Sum(p => p.YXMJ);
            row["wlm3"] = wlm3;
            double wlmxj = wlm1 + wlm2 + wlm3;
            row["wlmxj"] = wlmxj;

            double yld = data.Where(p => p.DI_LEI.Substring(0, 2) == "17").Sum(p => p.YXMJ);
            row["yld"] = yld;

            double fzsc = data.Where(p => p.DI_LEI == "1800").Sum(p => p.YXMJ);
            row["fzsc"] = fzsc;

            double bzd = data.Where(p => p.DI_LEI == "1632").Sum(p => p.YXMJ);
            row["bzd"] = bzd;

            double zmj = yldxj + sld + gmxj + wcz + mpd + wlmxj + yld + fzsc + bzd;
            row["zmj"] = zmj;

            double fld = data.Where(p => p.DI_LEI.Substring(0, 1) == "2").Sum(p => p.YXMJ);
            row["fld"] = fld;

            double ldhj = yld1 + yld2 + yld3 + sld + gm1 + gm2 + wcz + mpd + wlm1 + wlm2 + wlm3 + yld + fzsc + bzd;
            row["ldhj"] = ldhj;

            double slfgl = ldhj / zmj * 100;
            double lmlhl = ldhj / zmj * 100;
            row["slfgl"] = slfgl;
            row["lmlhl"] = lmlhl;
            m_table.Rows.Add(row);
        }
        protected override DataTable MakeTable()
        {
            DataTable table = new DataTable("ResultTable");

            table.Columns.Add("TJDW", typeof(string));
            table.Columns.Add("tjnd", typeof(string));
            table.Columns.Add("zmj", typeof(double));

            table.Columns.Add("ldhj", typeof(double));

            table.Columns.Add("yldxj", typeof(double));
            table.Columns.Add("yld1", typeof(double));
            table.Columns.Add("yld2", typeof(double));
            table.Columns.Add("yld3", typeof(double));

            table.Columns.Add("sld", typeof(double));
            table.Columns.Add("gmxj", typeof(double));
            table.Columns.Add("gm1", typeof(double));
            table.Columns.Add("gm2", typeof(double));

            table.Columns.Add("wcz", typeof(double));
            table.Columns.Add("mpd", typeof(double));

            table.Columns.Add("wlmxj", typeof(double));
            table.Columns.Add("wlm1", typeof(double));
            table.Columns.Add("wlm2", typeof(double));
            table.Columns.Add("wlm3", typeof(double));

            table.Columns.Add("yld", typeof(double));
            table.Columns.Add("fzsc", typeof(double));
            table.Columns.Add("bzd", typeof(double));

            table.Columns.Add("fld", typeof(double));
            table.Columns.Add("slfgl", typeof(double));
            table.Columns.Add("lmlhl", typeof(double));
            m_table = table;
            return m_table;
        }
    }
}
