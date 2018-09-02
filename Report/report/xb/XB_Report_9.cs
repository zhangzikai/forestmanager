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
    /// 小班报表9   用材林近成过熟林各树种株数、材积按径级组统计表
    /// </summary>
    public class XB_Report_9:XB_Report_Base
    {
        public XB_Report_9()
        {
            //用材林近成过熟林各树种株数、蓄积按径级组统计表
            SheetName = "9";
            m_firstRow = 7;
            m_firstColumn = 1;
            m_table = MakeTable();
        }
        public override DataTable FromMid2Table()
        {
            if (m_xb_dataList.Count < 1) { return m_table; }
            var qy = m_xb_dataList.Where(p => !string.IsNullOrWhiteSpace(p.QI_YUAN));
            if (qy.Count() < 1) { return m_table; }

            var yssz = qy.Where(p => !string.IsNullOrWhiteSpace(p.YOU_SHI_SZ));
            if (yssz.Count() < 1) { return m_table; }

            var lz = qy.Where(p => !string.IsNullOrWhiteSpace(p.LING_ZU));
            if (lz.Count() < 1) { return m_table; }

            var xianGrp = lz.GroupBy(p => p.XIAN);
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
                var Grp2 = GP1.GroupBy(p => p.YOU_SHI_SZ);
                foreach (var GP2 in Grp2)
                {
                    var Grp3 = GP1.GroupBy(p => p.LING_ZU);
                    string gp2Name = MDM.FindName("SHU_ZHONG", GP2.Key);                
                    foreach (var GP3 in Grp3)
                    {
                        string gp3Name = MDM.FindName("LING_ZU", GP3.Key);
                        MakeRow(GP3, xzName, gp1Name, gp2Name, gp3Name);
                    }
                }
            }
        }
        protected void MakeRow(IEnumerable<FOR_XIAOBAN_Mid> data, string xzName, string qiyuan, string YSSZ, string LINGZU)
        {
            DataRow row = m_table.NewRow();
            row["TJDW"] = xzName;
            row["QIYUAN"] = qiyuan;

            string YSSZ_TQ = YSSZ.Substring(YSSZ.LastIndexOf(":")+1);
            row["YSSZ"] = YSSZ_TQ;
            row["LINGZU"] = LINGZU;

            //未找到株树
            double JZ1MJ = data.Where(p => Convert.ToInt32(p.KE_JI_DU) == 1).Sum(p => p.MEI_GQ_ZS);
            row["JZ1MJ"] = JZ1MJ;
            double JZ1XJ = data.Where(p => Convert.ToInt32(p.KE_JI_DU) == 1).Sum(p => p.ZXJ);
            row["JZ1XJ"] = JZ1XJ;

            
            double JZ2MJ = data.Where(p => Convert.ToInt32(p.KE_JI_DU) == 2).Sum(p => p.MEI_GQ_ZS);
            row["JZ2MJ"] = JZ2MJ;
            double JZ2XJ = data.Where(p => Convert.ToInt32(p.KE_JI_DU) == 2).Sum(p => p.ZXJ);
            row["JZ2XJ"] = JZ2XJ;

            double JZ3MJ = data.Where(p => Convert.ToInt32(p.KE_JI_DU) == 3).Sum(p => p.MEI_GQ_ZS);
            row["JZ3MJ"] = JZ3MJ;
            double JZ3XJ = data.Where(p => Convert.ToInt32(p.KE_JI_DU) == 3).Sum(p => p.ZXJ);
            row["JZ3XJ"] = JZ3XJ;

            double JZ4MJ = data.Where(p => Convert.ToInt32(p.KE_JI_DU) == 4).Sum(p => p.MEI_GQ_ZS);
            row["JZ4MJ"] = JZ4MJ;
            double JZ4XJ = data.Where(p => Convert.ToInt32(p.KE_JI_DU) == 4).Sum(p => p.ZXJ);
            row["JZ4XJ"] = JZ4XJ;

            row["JJZMJHJ"] = JZ1MJ + JZ2MJ + JZ3MJ + JZ4MJ;
            row["JJZXJHJ"] = JZ1XJ + JZ2XJ + JZ3XJ + JZ4XJ;

            m_table.Rows.Add(row);
        }
        protected override DataTable MakeTable()
        {
            DataTable table = new DataTable("ResultTable");

            table.Columns.Add("TJDW", typeof(string));
            table.Columns.Add("QIYUAN", typeof(string));
            table.Columns.Add("YSSZ", typeof(string));
            table.Columns.Add("LINGZU", typeof(string));

            table.Columns.Add("JJZMJHJ", typeof(double));
            table.Columns.Add("JJZXJHJ", typeof(double));

            table.Columns.Add("JZ1MJ", typeof(double));
            table.Columns.Add("JZ1XJ", typeof(double));

            table.Columns.Add("JZ2MJ", typeof(double));
            table.Columns.Add("JZ2XJ", typeof(double));

            table.Columns.Add("JZ3MJ", typeof(double));
            table.Columns.Add("JZ3XJ", typeof(double));


            table.Columns.Add("JZ4MJ", typeof(double));
            table.Columns.Add("JZ4XJ", typeof(double));

            m_table = table;
            return m_table;
        }
    }
}
