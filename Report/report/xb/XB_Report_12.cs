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
    /// 小班报表12   竹林统计表
    /// </summary>
    public class XB_Report_12 : XB_Report_Base
    {
        public XB_Report_12()
        {
            //竹林统计表
            SheetName = "12";
            m_firstRow = 7;
            m_firstColumn = 1;
            m_table = MakeTable();
        }
        public override DataTable FromMid2Table()
        {
            if (m_xb_dataList.Count < 1) { return m_table; }
            var qy = m_xb_dataList.Where(p => !string.IsNullOrWhiteSpace(p.QI_YUAN));
            if (qy.Count() < 1) { return m_table; }
            var linzh = m_xb_dataList.Where(p => !string.IsNullOrWhiteSpace(p.LIN_ZHONG));
            if (linzh.Count() < 1) { return m_table; }
            var yssz = linzh.Where(p => !string.IsNullOrWhiteSpace(p.YOU_SHI_SZ));
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
                var Grp2 = GP1.GroupBy(p => p.LIN_ZHONG);
                foreach (var GP2 in Grp2)
                {
                    string gp2Name = MDM.FindName("LIN_ZHONG", GP2.Key);
                    var Grp3 = GP2.GroupBy(p => p.YOU_SHI_SZ);
                    foreach (var GP3 in Grp3)
                    {
                        string gp3Name = MDM.FindName("SHU_ZHONG", GP3.Key);
                        MakeRow(GP3, xzName, gp1Name, gp2Name, gp3Name);
                    }
                }
            }
        }
        protected void MakeRow(IEnumerable<FOR_XIAOBAN_Mid> data, string xzName, string qy, string linzh, string YSSZ)
        {
            DataRow row = m_table.NewRow();
            row["TJDW"] = xzName;
            row["QY"] = qy;
            row["LINZH"] = linzh;

            string YSSZ_TQ = YSSZ.Substring(YSSZ.LastIndexOf(":")+1);
            row["YSSZ"] = YSSZ_TQ;


            double MZ1 = data.Where(p => Convert.ToInt32(p.LING_ZU) == 1).Sum(p => p.YXMJ);
            row["MZ1"] = MZ1;
            double MZ2 = data.Where(p => Convert.ToInt32(p.LING_ZU) == 2 || Convert.ToInt32(p.LING_ZU) == 3).Sum(p => p.YXMJ);
            row["MZ2"]= MZ2;
            double MZ3 = data.Where(p => Convert.ToInt32(p.LING_ZU) == 4 || Convert.ToInt32(p.LING_ZU) == 5).Sum(p => p.YXMJ);
            row["MZ3"] = MZ3;

            row["MZLXJ"]=MZ1+MZ2+MZ3;

            double ZZMJ = data.Where(p=>Convert.ToInt32(p.YOU_SHI_SZ)==410).Sum(p=>p.YXMJ);
            row["ZZMJ"] = ZZMJ;

            double ZZZS = data.Where(p => Convert.ToInt32(p.YOU_SHI_SZ) == 429).Sum(p => p.HUO_LMGQXJ);
            row["ZZZS"] = ZZZS;

            double SSZS = data.Where(p => Convert.ToInt32(p.YOU_SHI_SZ) == 411).Sum(p => p.HUO_LMGQXJ);
            row["SSZS"] = SSZS;
          
            row["HJMJ"]=ZZMJ;
            row["HJZS"] = MZ1 + MZ2 + MZ3 + ZZZS + SSZS;
            row["MZLMJ"] = ZZMJ;
            m_table.Rows.Add(row);
        }
        protected override DataTable MakeTable()
        {
            DataTable table = new DataTable("ResultTable");

            table.Columns.Add("TJDW", typeof(string));
            table.Columns.Add("QY", typeof(string));
            table.Columns.Add("LINZH", typeof(string));
            table.Columns.Add("YSSZ", typeof(string));

            table.Columns.Add("HJMJ", typeof(double));
            table.Columns.Add("HJZS", typeof(double));

            table.Columns.Add("MZLMJ", typeof(double));
            table.Columns.Add("MZLXJ", typeof(double));
            table.Columns.Add("MZ1", typeof(double));
            table.Columns.Add("MZ2", typeof(double));
            table.Columns.Add("MZ3", typeof(double));


            table.Columns.Add("ZZMJ", typeof(double));
            table.Columns.Add("ZZZS", typeof(double));
            table.Columns.Add("SSZS", typeof(double));
           
            m_table = table;
            return m_table;
        }
    }
}
