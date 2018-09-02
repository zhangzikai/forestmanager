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
    /// 小班报表27   高保护价值森林统计表
    /// </summary>
    public class XB_Report_27 : XB_Report_Base
    {
        public XB_Report_27()
        {
            // 高保护价值森林统计表  ,未完成 没有高保护森林类型
            SheetName = "27";
            m_firstRow = 6;
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
               
                var Grp2 = GP1.GroupBy(p => p.LIN_ZHONG);
                foreach (var GP2 in Grp2)
                {
                    string gp2Name = MDM.FindName("LIN_ZHONG", GP2.Key);
                    MakeRow(GP1, xzName, gp1Name, gp2Name);
                    //var Grp3 = GP2.GroupBy(p => p.QI_YUAN);
                    //foreach (var GP3 in Grp3)
                    //{
                    //    string gp3Name = MDM.FindName("QI_YUAN", GP3.Key);
                    //    MakeRow(GP3, xzName, gp1Name, gp2Name, gp3Name);
                    //}
                }
            }
        }
        protected void MakeRow(IEnumerable<FOR_XIAOBAN_Mid> data, string xzName, string yssz,string linzh)
        {
            DataRow row = m_table.NewRow();
            row["TJDW"] = xzName;

            string yssz_tq = yssz.Substring(yssz.LastIndexOf(":")+1);
            row["yssz"] = yssz_tq;
            row["linzh"] = linzh;


            //double s1 = data.Where(p => p.g == "1").Sum(p => p.YXMJ);
            //row["s1"] = s1;
            //double L1xj = data.Where(p => p.LING_ZU == "1").Sum(p => p.ZXJ);
            //row["L1xj"] = L1xj;

            //double L2mj = qml.Where(p => p.LING_ZU == "2").Sum(p => p.YXMJ);
            //row["L2mj"] = L2mj;
            //double L2xj = data.Where(p => p.LING_ZU == "2").Sum(p => p.ZXJ);
            //row["L2xj"] = L2xj;

            //double L3mj = qml.Where(p => p.LING_ZU == "3").Sum(p => p.YXMJ);
            //row["L3mj"] = L3mj;
            //double L3xj = data.Where(p => p.LING_ZU == "3").Sum(p => p.ZXJ);
            //row["L3xj"] = L3xj;

            //double L4mj = qml.Where(p => p.LING_ZU == "4").Sum(p => p.YXMJ);
            //row["L4mj"] = L4mj;
            //double L4xj = data.Where(p => p.LING_ZU == "4").Sum(p => p.ZXJ);
            //row["L4xj"] = L4xj;

            //double L5mj = qml.Where(p => p.LING_ZU == "5").Sum(p => p.YXMJ);
            //row["L5mj"] = L5mj;
            //double L5xj = data.Where(p => p.LING_ZU == "6").Sum(p => p.ZXJ);
            //row["L5xj"] = L5xj;

            //row["qmmj"] = L1mj + L2mj + L3mj + L4mj + L5mj;
            //row["qmxj"] = L1xj + L2xj + L3xj + L4xj + L5xj;

            //row["hjmj"] = L1mj + L2mj + L3mj + L4mj + L5mj;
            //row["hjxj"] = L1xj + L2xj + L3xj + L4xj + L5xj;

            m_table.Rows.Add(row);
        }
        protected override DataTable MakeTable()
        {
            DataTable table = new DataTable("ResultTable");

            table.Columns.Add("TJDW", typeof(string));
            table.Columns.Add("yssz", typeof(string));
            table.Columns.Add("linzh", typeof(string));

            table.Columns.Add("hj", typeof(double));
         
            table.Columns.Add("s1", typeof(double));
            table.Columns.Add("s2", typeof(double));

            table.Columns.Add("s3", typeof(double));
            table.Columns.Add("s4", typeof(double));

            table.Columns.Add("s5", typeof(double));
            table.Columns.Add("s6", typeof(double));
            m_table = table;
            return m_table;
        }
    }
}
