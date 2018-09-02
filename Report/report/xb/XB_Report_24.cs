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
    /// 小班报表24   森林健康状况统计表
    /// </summary>
    public class XB_Report_24 : XB_Report_Base
    {
        public XB_Report_24()
        {
            // 森林健康状况统计表
            SheetName = "24";
            m_firstRow = 5;
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

            double jk1 = data.Where(p => p.JKZK == "1").Sum(p => p.YXMJ);
            row["jk1"] = jk1;
            double jk2 = data.Where(p => p.JKZK == "2").Sum(p => p.YXMJ);
            row["jk2"] = jk2;

            double jk3= data.Where(p => p.JKZK == "3").Sum(p => p.YXMJ);
            row["jk3"] = jk3;

            double jk4 = data.Where(p => p.JKZK == "4").Sum(p => p.YXMJ);
            row["jk4"] = jk4;


            row["HJMJ"] = jk1 + jk2 + jk3 + jk4;

            m_table.Rows.Add(row);
        }
        protected override DataTable MakeTable()
        {
            DataTable table = new DataTable("ResultTable");

            table.Columns.Add("TJDW", typeof(string));
            table.Columns.Add("TDSYQ", typeof(string));


            table.Columns.Add("HJMJ", typeof(double));

            table.Columns.Add("jk1", typeof(double));

            table.Columns.Add("jk2", typeof(double));
            table.Columns.Add("jk3", typeof(double));
            table.Columns.Add("jk4", typeof(double));
           
            m_table = table;
            return m_table;
        }
    }
}
