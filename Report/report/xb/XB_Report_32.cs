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
    /// 小班报表32   乔木林面积蓄积变化统计表
    /// </summary>
    public class XB_Report_32 : XB_Report_Base
    {
        public XB_Report_32()
        {
            //  乔木林面积蓄积变化统计表
            SheetName = "32";
            m_firstRow = 6;
            m_firstColumn = 1;
            m_table = MakeTable();
        }
        public override DataTable FromMid2Table()
        {
            if (m_xb_dataList.Count < 1) { return m_table; }
            var QI_YUAN = m_xb_dataList.Where(p => !string.IsNullOrWhiteSpace(p.QI_YUAN));
            if (QI_YUAN.Count() < 1) { return m_table; }

            var YOU_SHI_SZ = m_xb_dataList.Where(p => !string.IsNullOrWhiteSpace(p.YOU_SHI_SZ));
            if (YOU_SHI_SZ.Count() < 1) { return m_table; }

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
            var Grp1 = data.GroupBy(p => p.QI_YUAN);
            foreach (var GP1 in Grp1)
            {
                string gp1Name = MDM.FindName("QI_YUAN", GP1.Key);

                  var Grp2 = GP1.GroupBy(p => p.YOU_SHI_SZ);
             
                foreach (var GP2 in Grp2)
                {
                    string gp2Name = MDM.FindName("SHU_ZHONG", GP2.Key);
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
        protected void MakeRow(IEnumerable<FOR_XIAOBAN_Mid> data, string xzName, string qiyuan,string yssz)
        {
            DataRow row = m_table.NewRow();
            row["TJDW"] = xzName;
            row["tjnd"] = TJYear;
            row["qiyuan"] = qiyuan;

            string yssz_tq = yssz.Substring(yssz.LastIndexOf(":") + 1);
            row["yssz"] = yssz_tq;

            double linzh1mj = data.Where(p =>p.LING_ZU=="1").Sum(p => p.YXMJ);
            row["linzh1mj"] = linzh1mj;
            double linzh1xj = data.Where(p => p.LING_ZU == "1").Sum(p => p.ZXJ);
            row["linzh1xj"] = linzh1xj;

            double linzh2mj = data.Where(p => p.LING_ZU == "2").Sum(p => p.YXMJ);
            row["linzh2mj"] = linzh2mj;
            double linzh2xj = data.Where(p => p.LING_ZU == "2").Sum(p => p.ZXJ);
            row["linzh2xj"] = linzh2xj;


            double linzh3mj = data.Where(p => p.LING_ZU == "3").Sum(p => p.YXMJ);
            row["linzh3mj"] = linzh3mj;
            double linzh3xj = data.Where(p => p.LING_ZU == "3").Sum(p => p.ZXJ);
            row["linzh3xj"] = linzh3xj;

            double linzh4mj = data.Where(p => p.LING_ZU == "4").Sum(p => p.YXMJ);
            row["linzh4mj"] = linzh4mj;
            double linzh4xj = data.Where(p => p.LING_ZU == "4").Sum(p => p.ZXJ);
            row["linzh4xj"] = linzh4xj;

            double linzh5mj = data.Where(p => p.LING_ZU == "5").Sum(p => p.YXMJ);
            row["linzh5mj"] = linzh5mj;
            double linzh5xj = data.Where(p => p.LING_ZU == "5").Sum(p => p.ZXJ);
            row["linzh5xj"] = linzh5xj;

            row["hjmj"] = linzh1mj + linzh2mj + linzh3mj + linzh4mj + linzh5mj;
            row["hjxj"] = linzh1xj + linzh2xj + linzh3xj + linzh4xj + linzh5xj;

            m_table.Rows.Add(row);
        }
        protected override DataTable MakeTable()
        {
            DataTable table = new DataTable("ResultTable");

            table.Columns.Add("TJDW", typeof(string));
            table.Columns.Add("tjnd", typeof(string));
            table.Columns.Add("qiyuan", typeof(string));
            table.Columns.Add("yssz", typeof(string));

            table.Columns.Add("hjmj", typeof(double));
            table.Columns.Add("hjxj", typeof(double));

            table.Columns.Add("linzh1mj", typeof(double));
            table.Columns.Add("linzh1xj", typeof(double));

            table.Columns.Add("linzh2mj", typeof(double));
            table.Columns.Add("linzh2xj", typeof(double));


            table.Columns.Add("linzh3mj", typeof(double));
            table.Columns.Add("linzh3xj", typeof(double));

            table.Columns.Add("linzh4mj", typeof(double));
            table.Columns.Add("linzh4xj", typeof(double));

            table.Columns.Add("linzh5mj", typeof(double));
            table.Columns.Add("linzh5xj", typeof(double));

            m_table = table;
            return m_table;
        }
    }
}
