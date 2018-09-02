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
    /// 小班报表11   经济林统计表
    /// </summary>
    public class XB_Report_11 : XB_Report_Base
    {
        public XB_Report_11()
        {
            //经济林统计表
            SheetName = "11";
            m_firstRow = 7;
            m_firstColumn = 1;
            m_table = MakeTable();
        }
        public override DataTable FromMid2Table()
        {
            if (m_xb_dataList.Count < 1) { return m_table; }
            ////var lmsyq = m_xb_dataList.Where(p => !string.IsNullOrWhiteSpace(p.LMSYQ));
            ////if (lmsyq.Count() < 1) { return m_table; }

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
        protected void MakeRow(IEnumerable<FOR_XIAOBAN_Mid> data, string xzName, string lmqs, string YSSZ)
        {
            DataRow row = m_table.NewRow();
            row["TJDW"] = xzName;
            string lmsyq_tq = lmqs.Substring(lmqs.LastIndexOf(":") + 1);
            row["LMSYQ"] = lmsyq_tq;
            

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
            double CQXJ = CQ1 + CQ2 + CQ3 + CQ4;
            row["CQXJ"] = CQXJ;


            double JY1 = data.Where(p => Convert.ToString(p.JYCSLX) == "13").Sum(p => p.YXMJ);
            row["JY1"] = JY1;
            double JY2 = data.Where(p => Convert.ToString(p.JYCSLX) == "10").Sum(p => p.YXMJ);
            row["JY2"] = JY2;
            double JY3 = data.Where(p => Convert.ToString(p.JYCSLX) == "11").Sum(p => p.YXMJ);
            row["JY3"] = JY3;
            double JY4 = data.Where(p => Convert.ToString(p.JYCSLX) == "12").Sum(p => p.YXMJ);
            row["JY4"] = JY4;
            //判断未完全
            double JY5 = data.Where(p => Convert.ToString(p.JYCSLX) == "13" || Convert.ToString(p.JYCSLX) == "1").Sum(p => p.YXMJ);
            row["JY5"] = JY5;
            double JYCSXJ = JY1 + JY2 + JY3 + JY4 + JY5;
            row["JYCSXJ"] = JYCSXJ;

            row["HJ"] = CQXJ + JYCSXJ;
            m_table.Rows.Add(row);
        }
        protected override DataTable MakeTable()
        {
            DataTable table = new DataTable("ResultTable");

            table.Columns.Add("TJDW", typeof(string));
            table.Columns.Add("LMSYQ", typeof(string));
            table.Columns.Add("YSSZ", typeof(string));

            table.Columns.Add("HJ", typeof(double));
                

            table.Columns.Add("CQXJ", typeof(double));
            table.Columns.Add("CQ1", typeof(double));
            table.Columns.Add("CQ2", typeof(double));
            table.Columns.Add("CQ3", typeof(double));
            table.Columns.Add("CQ4", typeof(double));


            table.Columns.Add("JYCSXJ", typeof(double));
            table.Columns.Add("JY1", typeof(double));
            table.Columns.Add("JY2", typeof(double));
            table.Columns.Add("JY3", typeof(double));
            table.Columns.Add("JY4", typeof(double));
            table.Columns.Add("JY5", typeof(double));

            m_table = table;
            return m_table;
        }
    }
}
