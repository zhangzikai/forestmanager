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
    /// 小班报表8   用材林近成过熟林面积蓄积按可及度出材率等级统计表
    /// </summary>
    public class XB_Report_8 : XB_Report_Base
    {
        public XB_Report_8()
        {
            // 红树林资源统计表
            SheetName = "8";
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
                var Grp2 = GP1.GroupBy(p => p.YOU_SHI_SZ);
                foreach (var GP2 in Grp2)
                {
                 //   var Grp3 = GP1.GroupBy(p => p.YOU_SHI_SZ);
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
        protected void MakeRow(IEnumerable<FOR_XIAOBAN_Mid> data, string xzName, string qiyuan, string YSSZ)
        {
            DataRow row = m_table.NewRow();
            row["TJDW"] = xzName;
            row["QIYUAN"] = qiyuan;

            string YSSZ_TQ = YSSZ.Substring(YSSZ.LastIndexOf(":")+1);
            row["YSSZ"] = YSSZ_TQ;

            double KDJ1MJ = data.Where(p => Convert.ToInt32(p.KE_JI_DU) == 1).Sum(p => p.YXMJ);
            row["KDJ1MJ"] = KDJ1MJ;
            double KDJ1XJ = data.Where(p => Convert.ToInt32(p.KE_JI_DU) == 1).Sum(p => p.ZXJ);
            row["KDJ1XJ"] = KDJ1XJ;

            double KDJ2MJ = data.Where(p => Convert.ToInt32(p.KE_JI_DU) == 2).Sum(p => p.YXMJ);
            row["KDJ2MJ"] = KDJ2MJ;
            double KDJ2XJ = data.Where(p => Convert.ToInt32(p.KE_JI_DU) == 2).Sum(p => p.ZXJ);
            row["KDJ2XJ"] = KDJ2XJ;

            double KDJ3MJ = data.Where(p => Convert.ToInt32(p.KE_JI_DU) == 3).Sum(p => p.YXMJ);
            row["KDJ3MJ"] = KDJ3MJ;
            double KDJ3XJ = data.Where(p => Convert.ToInt32(p.KE_JI_DU) == 3).Sum(p => p.ZXJ);
            row["KDJ3XJ"] = KDJ3XJ;

            row["KJDMJHJ"] = KDJ1MJ+KDJ2MJ + KDJ3MJ;
            row["KJDXJHJ"] = KDJ1XJ + KDJ2XJ + KDJ3XJ;

            ////double CCDJ1MJ = data.Where(p => Convert.ToInt32(p.CCLDJ) == 1).Sum(p => p.YXMJ);
            ////row["CCDJ1MJ"] = CCDJ1MJ;
            ////double CCDJ1XJ = data.Where(p => Convert.ToInt32(p.CCLDJ) == 1).Sum(p => p.ZXJ);
            ////row["CCDJ1XJ"] = CCDJ1XJ;

            ////double CCDJ2MJ = data.Where(p => Convert.ToInt32(p.CCLDJ) == 2).Sum(p => p.YXMJ);
            ////row["CCDJ2MJ"] = CCDJ2MJ;
            ////double CCDJ2XJ = data.Where(p => Convert.ToInt32(p.CCLDJ) == 2).Sum(p => p.ZXJ);
            ////row["CCDJ2XJ"] = CCDJ2XJ;

            ////double CCDJ3MJ = data.Where(p => Convert.ToInt32(p.CCLDJ) == 3).Sum(p => p.YXMJ);
            ////row["CCDJ3MJ"] = CCDJ3MJ;
            ////double CCDJ3XJ = data.Where(p => Convert.ToInt32(p.CCLDJ) == 3).Sum(p => p.ZXJ);
            ////row["CCDJ3XJ"] = CCDJ3XJ;

            //修改代码如下：
            double CCDJ1MJ = data.Where(p => Convert.ToString(p.CCLDJ) == "null").Sum(p => p.YXMJ);
            row["CCDJ1MJ"] = CCDJ1MJ;
            double CCDJ1XJ = data.Where(p => Convert.ToString(p.CCLDJ) == "null").Sum(p => p.ZXJ);
            row["CCDJ1XJ"] = CCDJ1XJ;

            double CCDJ2MJ = data.Where(p => Convert.ToString(p.CCLDJ) == "null").Sum(p => p.YXMJ);
            row["CCDJ2MJ"] = CCDJ2MJ;
            double CCDJ2XJ = data.Where(p => Convert.ToString(p.CCLDJ) == "null").Sum(p => p.ZXJ);
            row["CCDJ2XJ"] = CCDJ2XJ;

            double CCDJ3MJ = data.Where(p => Convert.ToString(p.CCLDJ) == "null").Sum(p => p.YXMJ);
            row["CCDJ3MJ"] = CCDJ3MJ;
            double CCDJ3XJ = data.Where(p => Convert.ToString(p.CCLDJ) == "null").Sum(p => p.ZXJ);
            row["CCDJ3XJ"] = CCDJ3XJ;

            row["CCDJMJHJ"] = CCDJ1MJ + CCDJ2MJ + CCDJ3MJ;
            row["CCDJXJHJ"] = CCDJ1XJ + CCDJ2XJ + CCDJ3XJ;


            m_table.Rows.Add(row);
        }
        protected override DataTable MakeTable()
        {
            DataTable table = new DataTable("ResultTable");

            table.Columns.Add("TJDW", typeof(string));
            table.Columns.Add("QIYUAN", typeof(string));        
            table.Columns.Add("YSSZ", typeof(string));

            table.Columns.Add("KJDMJHJ", typeof(double));
            table.Columns.Add("KJDXJHJ", typeof(double));

            table.Columns.Add("KDJ1MJ", typeof(double));
            table.Columns.Add("KDJ1XJ", typeof(double));

            table.Columns.Add("KDJ2MJ", typeof(double));
            table.Columns.Add("KDJ2XJ", typeof(double));

            table.Columns.Add("KDJ3MJ", typeof(double));
            table.Columns.Add("KDJ3XJ", typeof(double));

            table.Columns.Add("CCDJMJHJ", typeof(double));
            table.Columns.Add("CCDJXJHJ", typeof(double));

            table.Columns.Add("CCDJ1MJ", typeof(double));
            table.Columns.Add("CCDJ1XJ", typeof(double));

            table.Columns.Add("CCDJ2MJ", typeof(double));
            table.Columns.Add("CCDJ2XJ", typeof(double));

            table.Columns.Add("CCDJ3MJ", typeof(double));
            table.Columns.Add("CCDJ3XJ", typeof(double));

            m_table = table;
            return m_table;
        }
    }
}
