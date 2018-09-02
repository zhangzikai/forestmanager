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
    /// 小班报表10   用材林中幼龄林应抚育间伐面积蓄积统计表
    /// </summary>
    public class XB_Report_10 : XB_Report_Base
    {
        public XB_Report_10()
        {
            //用材林近成过熟林各树种株数、蓄积按径级组统计表
            SheetName = "10";
            m_firstRow = 6;
            m_firstColumn = 1;
            m_table = MakeTable();
        }
        public override DataTable FromMid2Table()
        {
            if (m_xb_dataList.Count < 1) { return m_table; }
            //林木使用权为空，故注销
            ////var lmsyq = m_xb_dataList.Where(p => !string.IsNullOrWhiteSpace(p.LMSYQ));
            ////if (lmsyq.Count() < 1) { return m_table; }

            var yssz = m_xb_dataList.Where(p => !string.IsNullOrWhiteSpace(p.YOU_SHI_SZ));
            if (yssz.Count() < 1) { return m_table; }

            var qy = yssz.Where(p => !string.IsNullOrWhiteSpace(p.QI_YUAN));
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
            var Grp1 = data.GroupBy(p => p.LMSYQ);
            foreach (var GP1 in Grp1)
            {
                string gp1Name = MDM.FindName("LMSYQ", GP1.Key);
                var Grp2 = GP1.GroupBy(p => p.YOU_SHI_SZ);
                foreach (var GP2 in Grp2)
                {
                    var Grp3 = GP1.GroupBy(p => p.QI_YUAN);
                    string gp2Name = MDM.FindName("SHU_ZHONG", GP2.Key);
                    foreach (var GP3 in Grp3)
                    {
                        string gp3Name = MDM.FindName("QI_YUAN", GP3.Key);
                        MakeRow(GP3, xzName,gp1Name, gp2Name, gp3Name);
                    }
                }
            }
        }
        protected void MakeRow(IEnumerable<FOR_XIAOBAN_Mid> data, string xzName, string lmsyq,string YSSZ, string qiyuan)
        {
            DataRow row = m_table.NewRow();
            row["TJDW"] = xzName;
            string lmsyq_tq = lmsyq.Substring(lmsyq.LastIndexOf(":") + 1);
            row["LMSYQ"] = lmsyq_tq;

            string YSSZ_TQ = YSSZ.Substring(YSSZ.LastIndexOf(":")+1);
            row["YSSZ"] = YSSZ_TQ;

            row["QIYUAN"] = qiyuan;

            double YC1MJ = data.Where(p => Convert.ToInt32(p.LIN_ZHONG) == 231).Sum(p => p.YXMJ);
            row["YC1MJ"] = YC1MJ;
            double YC1XJ = data.Where(p => Convert.ToInt32(p.LIN_ZHONG) == 231).Sum(p => p.ZXJ);
            row["YC1XJ"] = YC1XJ;

            double YC2MJ = data.Where(p => Convert.ToInt32(p.LIN_ZHONG) == 232).Sum(p => p.YXMJ);
            row["YC2MJ"] = YC2MJ;
            double YC2XJ = data.Where(p => Convert.ToInt32(p.LIN_ZHONG) == 232).Sum(p => p.ZXJ);
            row["YC2XJ"] = YC2XJ;

            double YC3MJ = data.Where(p => Convert.ToInt32(p.LIN_ZHONG) == 233).Sum(p => p.YXMJ);
            row["YC3MJ"] = YC3MJ;
            double YC3XJ = data.Where(p => Convert.ToInt32(p.LIN_ZHONG) == 233).Sum(p => p.ZXJ);
            row["YC3XJ"] = YC3XJ;

            row["MJHJ"] = YC1MJ + YC2MJ + YC3MJ;
            row["XJHJ"] = YC1XJ + YC2XJ + YC3XJ;


            m_table.Rows.Add(row);
        }
        protected override DataTable MakeTable()
        {
            DataTable table = new DataTable("ResultTable");

            table.Columns.Add("TJDW", typeof(string));
            table.Columns.Add("LMSYQ", typeof(string));
            table.Columns.Add("YSSZ", typeof(string));
            table.Columns.Add("QIYUAN", typeof(string));

            table.Columns.Add("MJHJ", typeof(double));
            table.Columns.Add("XJHJ", typeof(double));

            table.Columns.Add("YC1MJ", typeof(double));
            table.Columns.Add("YC1XJ", typeof(double));


            table.Columns.Add("YC2MJ", typeof(double));
            table.Columns.Add("YC2XJ", typeof(double));


            table.Columns.Add("YC3MJ", typeof(double));
            table.Columns.Add("YC3XJ", typeof(double));

            m_table = table;
            return m_table;
        }
    }
}
