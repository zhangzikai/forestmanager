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
    /// 小班报表35   用材林单位面积蓄积变化统计表
    /// </summary>
    public class XB_Report_35 : XB_Report_Base
    {
        public XB_Report_35()
        {
            //  乔木林单位面积蓄积变化统计表
            SheetName = "35";
            m_firstRow = 6;
            m_firstColumn = 1;
            m_table = MakeTable();
        }
        public override DataTable FromMid2Table()
        {
            if (m_xb_dataList.Count < 1) { return m_table; }

            var YOU_SHI_SZ = m_xb_dataList.Where(p => !string.IsNullOrWhiteSpace(p.YOU_SHI_SZ));
            if (YOU_SHI_SZ.Count() < 1) { return m_table; }

            var xianGrp = YOU_SHI_SZ.GroupBy(p => p.XIAN);
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
            var Grp1 = data.GroupBy(p => p.YOU_SHI_SZ);
            foreach (var GP1 in Grp1)
            {
                string gp1Name = MDM.FindName("SHU_ZHONG", GP1.Key);
                MakeRow(GP1, xzName, gp1Name);
                //var Grp2 = GP1.GroupBy(p => p.YOU_SHI_SZ);

                //foreach (var GP2 in Grp2)
                //{
                //    string gp2Name = MDM.FindName("SHU_ZHONG", GP2.Key);
                //    MakeRow(GP1, xzName, gp1Name, gp2Name);
                //    //var Grp3 = GP2.GroupBy(p => p.QI_YUAN);
                //    //foreach (var GP3 in Grp3)
                //    //{
                //    //    string gp3Name = MDM.FindName("QI_YUAN", GP3.Key);
                //    //    MakeRow(GP3, xzName, gp1Name, gp2Name, gp3Name);
                //    //}
                //}
            }
        }
        protected void MakeRow(IEnumerable<FOR_XIAOBAN_Mid> data, string xzName, string yssz)
        {
            DataRow row = m_table.NewRow();
            row["TJDW"] = xzName;
           

            string yssz_tq = yssz.Substring(yssz.LastIndexOf(":")+1);
            row["yssz"] = yssz_tq;


            double q1 = data.Where(p => p.LING_ZU == "1").Sum(p => p.ZXJ);
            row["q1"] = q1;
            double h1 = data.Where(p => p.LING_ZU == "1").Sum(p => p.ZXJ);
            row["h1"] = h1;

            double q2 = data.Where(p => p.LING_ZU == "2").Sum(p => p.YXMJ);
            row["q2"] = q2;
            double h2 = data.Where(p => p.LING_ZU == "2").Sum(p => p.ZXJ);
            row["h2"] = h2;


            double q3 = data.Where(p => p.LING_ZU == "3").Sum(p => p.YXMJ);
            row["q3"] = q3;
            double h3 = data.Where(p => p.LING_ZU == "3").Sum(p => p.ZXJ);
            row["h3"] = h3;

            double q4 = data.Where(p => p.LING_ZU == "4").Sum(p => p.YXMJ);
            row["q4"] = q4;
            double h4 = data.Where(p => p.LING_ZU == "4").Sum(p => p.ZXJ);
            row["h4"] = h4;

            double q5 = data.Where(p => p.LING_ZU == "5").Sum(p => p.YXMJ);
            row["q5"] = q5;
            double h5 = data.Where(p => p.LING_ZU == "5").Sum(p => p.ZXJ);
            row["h5"] = h5;

            row["qzpj"] = (q1 + q2 + q3 + q4 + q5) / 5;
            row["hzpj"] = (h1 + h2 + h3 + h4 + h5) / 5;

            m_table.Rows.Add(row);
        }
        protected override DataTable MakeTable()
        {
            DataTable table = new DataTable("ResultTable");

            table.Columns.Add("TJDW", typeof(string));
            table.Columns.Add("yssz", typeof(string));

            table.Columns.Add("qzpj", typeof(double));
            table.Columns.Add("q1", typeof(double));
            table.Columns.Add("q2", typeof(double));
            table.Columns.Add("q3", typeof(double));
            table.Columns.Add("q4", typeof(double));
            table.Columns.Add("q5", typeof(double));

            table.Columns.Add("hzpj", typeof(double));
            table.Columns.Add("h1", typeof(double));
            table.Columns.Add("h2", typeof(double));
            table.Columns.Add("h3", typeof(double));
            table.Columns.Add("h4", typeof(double));
            table.Columns.Add("h5", typeof(double));

            m_table = table;
            return m_table;
        }
    }
}
