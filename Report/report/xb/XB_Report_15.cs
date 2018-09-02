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
    /// 小班报表15   低效用材林薪炭林面积蓄积统计表
    /// </summary>
    public class XB_Report_15 : XB_Report_Base
    {
        public XB_Report_15()
        {
            //亚林种是那个?
            SheetName = "15";
            m_firstRow = 6;
            m_firstColumn = 1;
            m_table = MakeTable();
        }
        public override DataTable FromMid2Table()
        {
            if (m_xb_dataList.Count < 1) { return m_table; }
            var YOU_SHI_SZ = m_xb_dataList.Where(p => !string.IsNullOrWhiteSpace(p.YOU_SHI_SZ));
            if (YOU_SHI_SZ.Count() < 1) { return m_table; }
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
            var Grp1 = data.GroupBy(p => p.YOU_SHI_SZ);
            foreach (var GP1 in Grp1)
            {
                string gp1Name = MDM.FindName("SHU_ZHONG", GP1.Key);
                var Grp2 = GP1.GroupBy(p => p.QI_YUAN);
                foreach (var GP2 in Grp2)
                {
                    string gp2Name = MDM.FindName("QI_YUAN", GP2.Key);
                    MakeRow(GP2, xzName, gp1Name, gp2Name);
                    //var Grp3 = GP2.GroupBy(p => p.YOU_SHI_SZ);
                    //foreach (var GP3 in Grp3)
                    //{
                    //    string gp3Name = MDM.FindName("SHU_ZHONG", GP3.Key);
                    //    MakeRow(GP3, xzName, gp1Name, gp2Name, gp3Name);
                    //}
                }
            }
        }
        protected void MakeRow(IEnumerable<FOR_XIAOBAN_Mid> data, string xzName, string YSSZ, string qy)
        {
            DataRow row = m_table.NewRow();
            row["TJDW"] = xzName;
            row["QY"] = qy;

            string YSSZ_TQ = YSSZ.Substring(YSSZ.LastIndexOf(":")+1);
            row["YSSZ"] = YSSZ_TQ;
            row["YLZ"] = "";

            double LMJ1 = data.Where(p => Convert.ToString(p.LING_ZU) == "1").Sum(p => p.YXMJ);
            row["LMJ1"] = LMJ1;
            double LXJ1 = data.Where(p => Convert.ToString(p.LING_ZU) == "1").Sum(p => p.ZXJ);
            row["LXJ1"] = LXJ1;

            double LMJ2 = data.Where(p => Convert.ToString(p.LING_ZU) == "2").Sum(p => p.YXMJ);
            row["LMJ2"] = LMJ2;
            double LXJ2 = data.Where(p => Convert.ToString(p.LING_ZU) == "2").Sum(p => p.ZXJ);
            row["LXJ2"] = LXJ2;

            double LMJ3 = data.Where(p => Convert.ToString(p.LING_ZU) == "3").Sum(p => p.YXMJ);
            row["LMJ3"] = LMJ3;
            double LXJ3 = data.Where(p => Convert.ToString(p.LING_ZU) == "3").Sum(p => p.ZXJ);
            row["LXJ3"] = LXJ3;

            double LMJ4 = data.Where(p => Convert.ToString(p.LING_ZU) == "4").Sum(p => p.YXMJ);
            row["LMJ4"] = LMJ4;
            double LXJ4 = data.Where(p => Convert.ToString(p.LING_ZU) == "4").Sum(p => p.ZXJ);
            row["LXJ4"] = LXJ4;

            double LMJ5 = data.Where(p => Convert.ToString(p.LING_ZU) == "5").Sum(p => p.YXMJ);
            row["LMJ5"] = LMJ5;
            double LXJ5 = data.Where(p => Convert.ToString(p.LING_ZU) == "5").Sum(p => p.ZXJ);
            row["LXJ5"] = LXJ5;

            row["XJMJ"] = LMJ1 + LMJ2 + LMJ3 + LMJ4 + LMJ5;
            row["XJXJ"] = LXJ1 + LXJ2 + LXJ3 + LXJ4 + LXJ5;

            m_table.Rows.Add(row);
        }
        protected override DataTable MakeTable()
        {
            DataTable table = new DataTable("ResultTable");

            table.Columns.Add("TJDW", typeof(string));
            table.Columns.Add("YLZ", typeof(string));
            table.Columns.Add("YSSZ", typeof(string));
            table.Columns.Add("QY", typeof(string));


            table.Columns.Add("XJMJ", typeof(double));
            table.Columns.Add("XJXJ", typeof(double));

            table.Columns.Add("LMJ1", typeof(double));
            table.Columns.Add("LXJ1", typeof(double));

            table.Columns.Add("LMJ2", typeof(double));
            table.Columns.Add("LXJ2", typeof(double));

            table.Columns.Add("LMJ3", typeof(double));
            table.Columns.Add("LXJ3", typeof(double));

            table.Columns.Add("LMJ4", typeof(double));
            table.Columns.Add("LXJ4", typeof(double));

            table.Columns.Add("LMJ5", typeof(double));
            table.Columns.Add("LXJ5", typeof(double));

            m_table = table;
            return m_table;
        }
    }
}
