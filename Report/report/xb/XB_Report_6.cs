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
    /// 小班报表6   红树林资源统计表.因为土地使用权为null。因此无法输出报表
    /// </summary>
    public class XB_Report_6 : XB_Report_Base
    {
        public XB_Report_6()
        {
            // 红树林资源统计表
            SheetName = "6";
            m_firstRow = 8;
            m_firstColumn = 1;
            m_table = MakeTable();
        }
        public override DataTable FromMid2Table()
        {
            if (m_xb_dataList.Count < 1) { return m_table; }
            ////var tdjyq = m_xb_dataList.Where(p => !string.IsNullOrWhiteSpace(p.TDJYQ));
            ////if (tdjyq.Count() < 1) { return m_table; }
            ////var qljg = tdjyq.Where(p => !string.IsNullOrWhiteSpace(p.JJLCQ));
            ////if (qljg.Count() < 1) { return m_table; }
            var qy = m_xb_dataList.Where(p => !string.IsNullOrWhiteSpace(p.QI_YUAN));
            if (qy.Count() < 1) { return m_table; }

            var xianGrp = qy.GroupBy(p => p.XIAN);
            foreach (var xian in xianGrp)
            {
                string xianName = MDM.FindXQName(xian.Key);
                MakeRowBySub(xian, xianName);
                //按乡统计
                var xiangGrps = xian.GroupBy(p => p.XIANG);
                foreach (var xg in xiangGrps)
                {
                    string xiangName = MDM.FindXQName(xg.Key);
                    MakeRowBySub(xg, xiangName);
                }
            }
            return m_table;
        }
        private void MakeRowBySub(IEnumerable<FOR_XIAOBAN_Mid> data, string xzName)
        {
            var Grp1 = data.GroupBy(p => p.LMJYQ);
            foreach (var GP1 in Grp1)
            {
                string gp1Name = MDM.FindName("LMJYQ", GP1.Key);
                var Grp2 = GP1.GroupBy(p => p.QLJG);
                foreach (var GP2 in Grp2)
                {
                    var Grp3 = GP1.GroupBy(p => p.QI_YUAN);
                    string gp2Name = MDM.FindName("QLJG", GP2.Key);
                    foreach (var GP3 in Grp3)
                    {
                        string gp3Name = MDM.FindName("QI_YUAN", GP3.Key);
                        MakeRow(GP3, xzName, gp1Name, gp2Name, gp3Name);
                    }
                }

            }
        }
        protected void MakeRow(IEnumerable<FOR_XIAOBAN_Mid> data, string xzName, string ldsyq, string qllx, string qy)
        {
            DataRow row = m_table.NewRow();
            row["TJDW"] = xzName;

            string ldsyq_tq = ldsyq.Substring(ldsyq.LastIndexOf(":")+1);
            row["TDJYQ"] = ldsyq_tq;
            string qllx_tq = qllx.Substring(qllx.LastIndexOf(":") + 1);
            row["QLJG"] = qllx_tq;

            row["QIYUAN"] = qy;

            double YLDHJ = data.Where(p=>Convert.ToInt32(p.DI_LEI)<1200).Sum(p => p.YXMJ);
            row["YLDHJ"] = YLDHJ;

            double WCZRG = data.Where(p => Convert.ToInt32(p.DI_LEI) == 1410).Sum(p => p.YXMJ);
            row["WCZRG"] = WCZRG;
            double WCZFY = data.Where(p => Convert.ToInt32(p.DI_LEI) == 1420).Sum(p => p.YXMJ);
            row["WCZFY"] = WCZFY;
            row["WCZXJ"] = WCZFY + WCZRG;

            row["DILEIHJ"] = WCZFY + WCZRG + YLDHJ;

            double LZZRBHQ = data.Where(p => p.LIN_ZHONG == "127").Sum(p => p.YXMJ);
            row["LZZRBHQ"] = LZZRBHQ;
            double LZHAN = data.Where(p => p.LIN_ZHONG == "115").Sum(p => p.YXMJ);
            row["LZHAN"] = LZHAN;
            double LZQITA = data.Where(p => p.LIN_ZHONG == "117").Sum(p => p.YXMJ);
            row["LZQITA"] = LZQITA;
            row["LINZHONGHJ"] = LZZRBHQ+LZHAN + LZQITA;

            double MI7 = data.Where(p => p.YU_BI_DU >= 0.7).Sum(p => p.YXMJ);
            row["MI7"] = MI7;
            double MI46 = data.Where(p => p.YU_BI_DU >= 0.4 && p.YU_BI_DU <= 0.69).Sum(p => p.YXMJ);
            row["MI46"] = MI46;
            double MI239 = data.Where(p => p.YU_BI_DU >= 0.2 && p.YU_BI_DU <= 0.39).Sum(p => p.YXMJ);
            row["MI239"] = MI239;

            row["YBDDJHJ"] = MI239 + MI46 + MI7;

            m_table.Rows.Add(row);
        }
        protected override DataTable MakeTable()
        {
            DataTable table = new DataTable("ResultTable");

            table.Columns.Add("TJDW", typeof(string));
            table.Columns.Add("TDJYQ", typeof(string));
            table.Columns.Add("QLJG", typeof(string));
            table.Columns.Add("QIYUAN", typeof(string));

            table.Columns.Add("DILEIHJ", typeof(double));
            table.Columns.Add("YLDHJ", typeof(double));

            table.Columns.Add("WCZXJ", typeof(double));
            table.Columns.Add("WCZRG", typeof(double));
            table.Columns.Add("WCZFY", typeof(double));

            table.Columns.Add("LINZHONGHJ", typeof(double));
            table.Columns.Add("LZZRBHQ", typeof(double));
            table.Columns.Add("LZHAN", typeof(double));
            table.Columns.Add("LZQITA", typeof(double));

            table.Columns.Add("YBDDJHJ", typeof(double));
            table.Columns.Add("MI7", typeof(double));
            table.Columns.Add("MI46", typeof(double));
            table.Columns.Add("MI239", typeof(double));
         
            m_table = table;
            return m_table;
        }
    }
}
