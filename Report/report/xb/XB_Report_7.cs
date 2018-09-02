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
    /// 小班报表7   用材林面积蓄积按龄级统计表。因为林木所有权为null因此无法输出报表
    /// </summary>
    public class XB_Report_7 : XB_Report_Base
    {
        public XB_Report_7()
        {
            // 红树林资源统计表
            SheetName = "7";
            m_firstRow = 6;
            m_firstColumn = 1;
            m_table = MakeTable();
        }
        public override DataTable FromMid2Table()
        {
            if (m_xb_dataList.Count < 1) { return m_table; }
            ////var lmsyq = m_xb_dataList.Where(p => !string.IsNullOrWhiteSpace(p.LMSYQ));
            ////if (lmsyq.Count() < 1) { return m_table; }
            //////var qljg = m_xb_dataList.Where(p => !string.IsNullOrWhiteSpace(p.JJLCQ));
            //////if (qljg.Count() < 1) { return m_table; }
            var yssz = m_xb_dataList.Where(p => !string.IsNullOrWhiteSpace(p.YOU_SHI_SZ));
            if (yssz.Count() < 1) { return m_table; }

            var xianGrp = yssz.GroupBy(p => p.XIAN);
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
            var Grp1 = data.GroupBy(p => p.LMSYQ);
            foreach (var GP1 in Grp1)
            {
                string gp1Name = MDM.FindName("LMSYQ", GP1.Key);
                var Grp2 = GP1.GroupBy(p => p.YOU_SHI_SZ);
                foreach (var GP2 in Grp2)
                {
                 //   var Grp3 = GP1.GroupBy(p =>p.YOU_SHI_SZ);
                    string gp2Name = MDM.FindName("SHU_ZHONG", GP2.Key);
                    MakeRow(GP2, xzName, gp1Name, gp2Name);
                    //foreach (var GP3 in Grp3)
                    //{
                    //    string gp3Name = MDM.FindName("QI_YUAN", GP3.Key);
                    //    MakeRow(GP3, xzName, gp1Name, gp2Name, gp3Name);
                    //}
                }
            }
        }
        protected void MakeRow(IEnumerable<FOR_XIAOBAN_Mid> data, string xzName, string LMSYQ, string YSSZ)
        {
            DataRow row = m_table.NewRow();
            row["TJDW"] = xzName;
            string LMSYQ_TQ = LMSYQ.Substring(LMSYQ.LastIndexOf(":") + 1);
            row["LMSYQ"] = LMSYQ_TQ;
            row["YLZ"] = "";

            string YSSZ_TQ = YSSZ.Substring(YSSZ.LastIndexOf(":")+1);
            row["YSSZ"] = YSSZ_TQ;

            double ONEMJ = data.Where(p => Convert.ToString(p.LJ) == "1").Sum(p => p.YXMJ);
            row["ONEMJ"] = ONEMJ;
            double ONEXJ = data.Where(p => Convert.ToString(p.LJ) == "1").Sum(p => p.ZXJ);
            row["ONEXJ"] = ONEMJ;

            double TWOMJ = data.Where(p => Convert.ToString(p.LJ) == "2").Sum(p => p.YXMJ);
            row["TWOMJ"] = TWOMJ;
            double TWOXJ = data.Where(p => Convert.ToString(p.LJ) == "2").Sum(p => p.ZXJ);
            row["TWOXJ"] = TWOXJ;

            double THREEMJ = data.Where(p => Convert.ToString(p.LJ) == "3").Sum(p => p.YXMJ);
            row["THREEMJ"] = THREEMJ;
            double THREXJ = data.Where(p => Convert.ToString(p.LJ) == "3").Sum(p => p.ZXJ);
            row["THREXJ"] = THREXJ;

            double FOURMJ = data.Where(p => Convert.ToString(p.LJ) == "4").Sum(p => p.YXMJ);
            row["FOURMJ"] = FOURMJ;
            double FOURXJ = data.Where(p => Convert.ToString(p.LJ) == "4").Sum(p => p.ZXJ);
            row["FOURXJ"] = FOURXJ;

            double FIVEMJ = data.Where(p => Convert.ToString(p.LJ) == "5").Sum(p => p.YXMJ);
            row["FIVEMJ"] = FIVEMJ;
            double FIVEXJ = data.Where(p => Convert.ToString(p.LJ) == "5").Sum(p => p.ZXJ);
            row["FIVEXJ"] = FIVEXJ;

            double SIXMJ = data.Where(p => Convert.ToString(p.LJ) == "6").Sum(p => p.YXMJ);
            row["SIXMJ"] = SIXMJ;
            double SIXXJ = data.Where(p => Convert.ToString(p.LJ) == "6").Sum(p => p.ZXJ);
            row["SIXXJ"] = SIXXJ;


            double SEVENMJ = data.Where(p => Convert.ToString(p.LJ) == "7").Sum(p => p.YXMJ);
            row["SEVENMJ"] = SEVENMJ;
            double SEVENXJ = data.Where(p => Convert.ToString(p.LJ) == "7").Sum(p => p.ZXJ);
            row["SEVENXJ"] = SEVENXJ;

            double EIGHTMJ = data.Where(p => Convert.ToString(p.LJ) == "8").Sum(p => p.YXMJ);
            row["EIGHTMJ"] = EIGHTMJ;
            double EIGHTXJ = data.Where(p => Convert.ToString(p.LJ) == "8").Sum(p => p.ZXJ);
            row["EIGHTXJ"] = EIGHTXJ;

            row["HJMJ"] = ONEMJ + TWOMJ + THREEMJ + FOURMJ + FIVEMJ + SIXMJ + SEVENMJ + EIGHTMJ;
            row["HJXJ"] = ONEXJ + TWOXJ + THREXJ + FOURXJ + FIVEXJ + SIXXJ + SEVENXJ + EIGHTXJ;

            m_table.Rows.Add(row);
        }
        protected override DataTable MakeTable()
        {
            DataTable table = new DataTable("ResultTable");

            table.Columns.Add("TJDW", typeof(string));
            table.Columns.Add("LMSYQ", typeof(string));
            table.Columns.Add("YLZ", typeof(string));
            table.Columns.Add("YSSZ", typeof(string));

            table.Columns.Add("HJMJ", typeof(double));
            table.Columns.Add("HJXJ", typeof(double));

            table.Columns.Add("ONEMJ", typeof(double));
            table.Columns.Add("ONEXJ", typeof(double));

            table.Columns.Add("TWOMJ", typeof(double));
            table.Columns.Add("TWOXJ", typeof(double));

            table.Columns.Add("THREEMJ", typeof(double));
            table.Columns.Add("THREXJ", typeof(double));

            table.Columns.Add("FOURMJ", typeof(double));
            table.Columns.Add("FOURXJ", typeof(double));

            table.Columns.Add("FIVEMJ", typeof(double));
            table.Columns.Add("FIVEXJ", typeof(double));

            table.Columns.Add("SIXMJ", typeof(double));
            table.Columns.Add("SIXXJ", typeof(double));

            table.Columns.Add("SEVENMJ", typeof(double));
            table.Columns.Add("SEVENXJ", typeof(double));

            table.Columns.Add("EIGHTMJ", typeof(double));
            table.Columns.Add("EIGHTXJ", typeof(double));

            m_table = table;
            return m_table;
        }
    }
}
