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
    /// 小班报表13   灌木林统计表
    /// </summary>
    public class XB_Report_13 : XB_Report_Base
    {
        public XB_Report_13()
        {
            //灌木林统计表 疏中密字段是那个?
            SheetName = "13";
            m_firstRow = 6;
            m_firstColumn = 1;
            m_table = MakeTable();
        }
        public override DataTable FromMid2Table()
        {
            if (m_xb_dataList.Count < 1) { return m_table; }
            var lmsyq = m_xb_dataList.Where(p => !string.IsNullOrWhiteSpace(p.LMSYQ));
            if (lmsyq.Count() < 1) { return m_table; }
            var qy = m_xb_dataList.Where(p => !string.IsNullOrWhiteSpace(p.QI_YUAN));
            if (qy.Count() < 1) { return m_table; }
            var yssz = qy.Where(p => !string.IsNullOrWhiteSpace(p.YOU_SHI_SZ));
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
            var Grp1 = data.GroupBy(p => p.QI_YUAN);
            foreach (var GP1 in Grp1)
            {
                string gp1Name = MDM.FindName("QI_YUAN", GP1.Key);
                var Grp2 = GP1.GroupBy(p => p.LMSYQ);
                foreach (var GP2 in Grp2)
                {
                    string gp2Name = MDM.FindName("LMSYQ", GP2.Key);
                    var Grp3 = GP2.GroupBy(p => p.YOU_SHI_SZ);
                    foreach (var GP3 in Grp3)
                    {
                        string gp3Name = MDM.FindName("SHU_ZHONG", GP3.Key);
                        MakeRow(GP3, xzName, gp1Name, gp2Name, gp3Name);
                    }
                }
            }
        }
        protected void MakeRow(IEnumerable<FOR_XIAOBAN_Mid> data, string xzName, string qy, string LMSYQ, string YSSZ)
        {
            DataRow row = m_table.NewRow();
            row["TJDW"] = xzName;

            string LMSYQ_TQ = LMSYQ.Substring(LMSYQ.LastIndexOf(":") + 1);
            row["LMSYQ"] = LMSYQ_TQ;
           
            row["QY"] = qy;

            string YSSZ_TQ = YSSZ.Substring(YSSZ.LastIndexOf(":")+1);
            row["YSSZ"] = YSSZ_TQ;


            double TB1 = data.Where(p => Convert.ToInt32(p.LING_ZU) == 1).Sum(p => p.YXMJ);
            row["TB1"] = TB1;
            double TB2 = data.Where(p => Convert.ToInt32(p.LING_ZU) == 2 || Convert.ToInt32(p.LING_ZU) == 3).Sum(p => p.YXMJ);
            row["TB2"] = TB2;
            double TB3 = data.Where(p => Convert.ToInt32(p.LING_ZU) == 4 || Convert.ToInt32(p.LING_ZU) == 5).Sum(p => p.YXMJ);
            row["TB3"] = TB3;
            row["TBXJ"] = TB1 + TB2 + TB3;

            double QTXJ = data.Where(p => Convert.ToInt32(p.YOU_SHI_SZ) == 800 || Convert.ToInt32(p.YOU_SHI_SZ) == 811 || Convert.ToInt32(p.YOU_SHI_SZ) == 812).Sum(p => p.YXMJ);
            row["QTXJ"] = QTXJ;
            //    row["HJMJ"] = MZ1 + MZ2 + MZ3;



            m_table.Rows.Add(row);
        }
        protected override DataTable MakeTable()
        {
            DataTable table = new DataTable("ResultTable");

            table.Columns.Add("TJDW", typeof(string));
            table.Columns.Add("LMSYQ", typeof(string));
            table.Columns.Add("QY", typeof(string));         
            table.Columns.Add("YSSZ", typeof(string));

            table.Columns.Add("HJMJ", typeof(string));
            table.Columns.Add("HJS", typeof(string));
            table.Columns.Add("HJZ", typeof(string));
            table.Columns.Add("HJM", typeof(string));

            table.Columns.Add("TBXJ", typeof(string));
            table.Columns.Add("TB1", typeof(string));
            table.Columns.Add("TB2", typeof(string));
            table.Columns.Add("TB3", typeof(string));

            table.Columns.Add("QTXJ", typeof(string));
            table.Columns.Add("QT1", typeof(string));
            table.Columns.Add("QT2", typeof(string));
            table.Columns.Add("QT3", typeof(string));
            m_table = table;
            return m_table;
        }
    }
}
