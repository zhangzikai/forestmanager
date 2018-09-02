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
    /// 小班报表23   森林灾害统计表
    /// </summary>
    public class XB_Report_23 : XB_Report_Base
    {
        public XB_Report_23()
        {
            // 湿地统计表
            SheetName = "23";
            m_firstRow = 6;
            m_firstColumn = 1;
            m_table = MakeTable();
        }
        public override DataTable FromMid2Table()
        {
            if (m_xb_dataList.Count < 1) { return m_table; }
            var TDJYQ = m_xb_dataList.Where(p => !string.IsNullOrWhiteSpace(p.TDJYQ));

            if (TDJYQ.Count() < 1) { return m_table; }

            var xianGrp = TDJYQ.GroupBy(p => p.XIAN);
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
            var Grp1 = data.GroupBy(p => p.TDJYQ);
            foreach (var GP1 in Grp1)
            {
                string gp1Name = MDM.FindName("TDJYQ", GP1.Key);
                MakeRow(GP1, xzName, gp1Name);
                //var Grp2 = GP1.GroupBy(p => p.YOU_SHI_SZ);
                //foreach (var GP2 in Grp2)
                //{
                //    string gp2Name = MDM.FindName("SHU_ZHONG", GP2.Key);
                //    var Grp3 = GP2.GroupBy(p => p.QI_YUAN);
                //    foreach (var GP3 in Grp3)
                //    {
                //        string gp3Name = MDM.FindName("QI_YUAN", GP3.Key);
                //        MakeRow(GP3, xzName, gp1Name, gp2Name, gp3Name);
                //    }
                //}
            }
        }
        protected void MakeRow(IEnumerable<FOR_XIAOBAN_Mid> data, string xzName, string tdsyq)
        {
            DataRow row = m_table.NewRow();
            row["TJDW"] = xzName;
            row["TDSYQ"] = tdsyq;

            double bc1 = data.Where(p => p.DISPE=="11").Sum(p => p.YXMJ);
            row["bc1"] = bc1;
            double bc2 = data.Where(p => p.DISPE == "12").Sum(p => p.YXMJ);
            row["bc2"] = bc2;
            row["bchxj"] = bc1+bc2;


            double hz = data.Where(p => p.DISPE == "20").Sum(p => p.YXMJ);
            row["hz"] = hz;
            double qh1 = data.Where(p => p.DISPE == "31").Sum(p => p.YXMJ);
            row["qh1"] = qh1;
            double qh2 = data.Where(p => p.DISPE == "33").Sum(p => p.YXMJ);
            row["qh2"] = qh2;
            double qh3 = data.Where(p => p.DISPE == "32" || p.DISPE == "34").Sum(p => p.YXMJ);
            row["qh3"] = qh3;

            row["qhxj"] = qh1 + qh2 + qh3;



            double qt = data.Where(p => p.DISPE == "40").Sum(p => p.YXMJ);
            row["qt"] = qt;


            row["HJMJ"] =bc1+bc2+ qh1 + qh2 + qh3 + qt;

            m_table.Rows.Add(row);
        }
        protected override DataTable MakeTable()
        {
            DataTable table = new DataTable("ResultTable");

            table.Columns.Add("TJDW", typeof(string));
            table.Columns.Add("TDSYQ", typeof(string));


            table.Columns.Add("HJMJ", typeof(double));

            table.Columns.Add("bchxj", typeof(double));

            table.Columns.Add("bc1", typeof(double));
            table.Columns.Add("bc2", typeof(double));

            table.Columns.Add("hz", typeof(double));
            table.Columns.Add("qhxj", typeof(double));
            table.Columns.Add("qh1", typeof(double));
            table.Columns.Add("qh2", typeof(double));
            table.Columns.Add("qh3", typeof(double));
            table.Columns.Add("qt", typeof(double));
            m_table = table;
            return m_table;
        }
    }
}
