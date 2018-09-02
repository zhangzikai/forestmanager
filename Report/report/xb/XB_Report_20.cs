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
    /// 小班报表20   石漠化土地统计表
    /// </summary>
    public class XB_Report_20 : XB_Report_Base
    {
        public XB_Report_20()
        {
            // 石漠化土地统计表
            SheetName = "20";
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

            double qian = data.Where(p => p.SMHCD == "2").Sum(p => p.YXMJ);
            row["qian"] = qian;

            double sm1 = data.Where(p => p.SMHCD == "3").Sum(p => p.YXMJ);
            row["sm1"] = sm1;
            double sm2 = data.Where(p => p.SMHCD == "4").Sum(p => p.YXMJ);
            row["sm2"] = sm2;
            double sm3 = data.Where(p => p.SMHCD == "5").Sum(p => p.YXMJ);
            row["sm3"] = sm3;
            double sm4 = data.Where(p => p.SMHCD == "6").Sum(p => p.YXMJ);
            row["sm4"] = sm4;

            row["xiaoji"] = sm1 + sm2 + sm3+sm4;
            row["HJMJ"] = qian + sm1 + sm2 + sm3 + sm4;

            m_table.Rows.Add(row);
        }
        protected override DataTable MakeTable()
        {
            DataTable table = new DataTable("ResultTable");

            table.Columns.Add("TJDW", typeof(string));
            table.Columns.Add("TDSYQ", typeof(string));


            table.Columns.Add("HJMJ", typeof(double));

            table.Columns.Add("qian", typeof(double));
            table.Columns.Add("xiaoji", typeof(double));
            table.Columns.Add("sm1", typeof(double));
            table.Columns.Add("sm2", typeof(double));

            table.Columns.Add("sm3", typeof(double));
            table.Columns.Add("sm4", typeof(double));
           
            m_table = table;
            return m_table;
        }
    }
}
