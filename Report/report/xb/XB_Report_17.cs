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
    /// 小班报表17   低效经济林面积蓄积统计表
    /// </summary>
    public class XB_Report_17 : XB_Report_Base
    {
        public XB_Report_17()
        {
            //低效经济林面积统计表?
            SheetName = "17";
            m_firstRow = 6;
            m_firstColumn = 1;
            m_table = MakeTable();
        }
        public override DataTable FromMid2Table()
        {
            if (m_xb_dataList.Count < 1) { return m_table; }
            var YOU_SHI_SZ = m_xb_dataList.Where(p => !string.IsNullOrWhiteSpace(p.YOU_SHI_SZ));
            if (YOU_SHI_SZ.Count() < 1) { return m_table; }
            //var qy = m_xb_dataList.Where(p => !string.IsNullOrWhiteSpace(p.QI_YUAN));
            //if (qy.Count() < 1) { return m_table; }

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
                MakeRow(data, xzName, gp1Name);
                //var Grp2 = GP1.GroupBy(p => p.QI_YUAN);
                //foreach (var GP2 in Grp2)
                //{
                //    string gp2Name = MDM.FindName("QI_YUAN", GP2.Key);
                //    MakeRow(GP2, xzName, gp1Name, gp2Name,);
                //    //var Grp3 = GP2.GroupBy(p => p.YOU_SHI_SZ);
                //    //foreach (var GP3 in Grp3)
                //    //{
                //    //    string gp3Name = MDM.FindName("SHU_ZHONG", GP3.Key);
                //    //    MakeRow(GP3, xzName, gp1Name, gp2Name, gp3Name);
                //    //}
                //}
            }
        }
        protected void MakeRow(IEnumerable<FOR_XIAOBAN_Mid> data, string xzName, string YSSZ)
        {
            DataRow row = m_table.NewRow();
            row["TJDW"] = xzName;
            row["YLZ"] = "";
            string YSSZ_TQ = YSSZ.Substring(YSSZ.LastIndexOf(":")+1);
            row["YSSZ"] = YSSZ_TQ;


            double CQ1 = data.Where(p => Convert.ToString(p.JJLCQ) == "1").Sum(p => p.YXMJ);
            row["CQ1"] = CQ1;

            double CQ2 = data.Where(p => Convert.ToString(p.JJLCQ) == "2").Sum(p => p.YXMJ);
            row["CQ2"] = CQ2;

            double CQ3 = data.Where(p => Convert.ToString(p.JJLCQ) == "3").Sum(p => p.YXMJ);
            row["CQ3"] = CQ3;

            double CQ4 = data.Where(p => Convert.ToString(p.JJLCQ) == "4").Sum(p => p.YXMJ);
            row["CQ4"] = CQ4;



            row["HJ"] = CQ1 + CQ2 + CQ3 + CQ4;
          

            m_table.Rows.Add(row);
        }
        protected override DataTable MakeTable()
        {
            DataTable table = new DataTable("ResultTable");

            table.Columns.Add("TJDW", typeof(string));
            table.Columns.Add("YLZ", typeof(string));
            table.Columns.Add("YSSZ", typeof(string));

            table.Columns.Add("HJ", typeof(double));
            table.Columns.Add("CQ1", typeof(double));
            table.Columns.Add("CQ2", typeof(double));
            table.Columns.Add("CQ3", typeof(double));
            table.Columns.Add("CQ4", typeof(double));


            m_table = table;
            return m_table;
        }
    }
}
