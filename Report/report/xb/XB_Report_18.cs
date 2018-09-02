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
    /// 小班报表18   林业工程面积蓄积统计表
    /// </summary>
    public class XB_Report_18 : XB_Report_Base
    {
        public XB_Report_18()
        {
            //林业工程面积蓄积统计表?
            SheetName = "18";
            m_firstRow =6;
            m_firstColumn = 1;
            m_table = MakeTable();
        }
        public override DataTable FromMid2Table()
        {
            if (m_xb_dataList.Count < 1) { return m_table; }
            var LIN_ZHONG = m_xb_dataList.Where(p => !string.IsNullOrWhiteSpace(p.LIN_ZHONG));
            if (LIN_ZHONG.Count() < 1) { return m_table; }
            var YOU_SHI_SZ = LIN_ZHONG.Where(p => !string.IsNullOrWhiteSpace(p.YOU_SHI_SZ));
            if (YOU_SHI_SZ.Count() < 1) { return m_table; }
            var qy = YOU_SHI_SZ.Where(p => !string.IsNullOrWhiteSpace(p.QI_YUAN));
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
            var Grp1 = data.GroupBy(p => p.LIN_ZHONG);
            foreach (var GP1 in Grp1)
            {
                string gp1Name = MDM.FindName("LIN_ZHONG", GP1.Key);
                var Grp2 = GP1.GroupBy(p => p.YOU_SHI_SZ);
                foreach (var GP2 in Grp2)
                {
                    string gp2Name = MDM.FindName("SHU_ZHONG", GP2.Key);                   
                    var Grp3 = GP2.GroupBy(p => p.QI_YUAN);
                    foreach (var GP3 in Grp3)
                    {
                        string gp3Name = MDM.FindName("QI_YUAN", GP3.Key);
                        MakeRow(GP3, xzName, gp1Name, gp2Name, gp3Name);
                    }
                }
            }
        }
        protected void MakeRow(IEnumerable<FOR_XIAOBAN_Mid> data, string xzName, string linzh,string YSSZ,string qy)
        {
            DataRow row = m_table.NewRow();
            row["TJDW"] = xzName;
            row["LINZHONG"] = linzh;
            string YSSZ_TQ = YSSZ.Substring(YSSZ.LastIndexOf(":")+1);
            row["YSSZ"] = YSSZ_TQ;
            row["QY"] = qy;

            double GCMJ1 = data.Where(p =>p.Q_GC_LB == "30").Sum(p => p.YXMJ);
            row["GCMJ1"] = GCMJ1;
            double GCXJ1 = data.Where(p => p.Q_GC_LB == "30").Sum(p => p.ZXJ);
            row["GCXJ1"] = GCXJ1;

            double GCMJ2 = data.Where(p => p.Q_GC_LB == "24").Sum(p => p.YXMJ);
            row["GCMJ2"] = GCMJ2;
            double GCXJ2 = data.Where(p => p.Q_GC_LB == "24").Sum(p => p.ZXJ);
            row["GCXJ2"] = GCXJ2;


            double GCMJ3 = data.Where(p => Convert.ToString(p.Q_GC_LB) == "50").Sum(p => p.YXMJ) + data.Where(p => Convert.ToString(p.Q_GC_LB) == "51").Sum(p => p.YXMJ) + data.Where(p => Convert.ToString(p.Q_GC_LB) == "52").Sum(p => p.YXMJ) + data.Where(p => Convert.ToString(p.Q_GC_LB) == "53").Sum(p => p.YXMJ) + data.Where(p => Convert.ToString(p.Q_GC_LB) == "54").Sum(p => p.YXMJ);
            row["GCMJ3"] = GCMJ3;
            double GCXJ3 = data.Where(p => Convert.ToString(p.Q_GC_LB) == "50").Sum(p => p.ZXJ) + data.Where(p => Convert.ToString(p.Q_GC_LB) == "51").Sum(p => p.ZXJ) + data.Where(p => Convert.ToString(p.Q_GC_LB) == "52").Sum(p => p.ZXJ) + data.Where(p => Convert.ToString(p.Q_GC_LB) == "53").Sum(p => p.ZXJ) + data.Where(p => Convert.ToString(p.Q_GC_LB) == "54").Sum(p => p.ZXJ);
            row["GCXJ3"] = GCXJ3;


            double GCMJ4 = data.Where(p => Convert.ToString(p.Q_GC_LB) == "60").Sum(p => p.YXMJ) + data.Where(p => Convert.ToString(p.Q_GC_LB) == "61").Sum(p => p.YXMJ) + data.Where(p => Convert.ToString(p.Q_GC_LB) == "62").Sum(p => p.YXMJ) + data.Where(p => Convert.ToString(p.Q_GC_LB) == "63").Sum(p => p.YXMJ);
            row["GCMJ4"] = GCMJ4;
            double GCXJ4 = data.Where(p => Convert.ToString(p.Q_GC_LB) == "60").Sum(p => p.ZXJ) + data.Where(p => Convert.ToString(p.Q_GC_LB) == "61").Sum(p => p.ZXJ) + data.Where(p => Convert.ToString(p.Q_GC_LB) == "62").Sum(p => p.ZXJ) + data.Where(p => Convert.ToString(p.Q_GC_LB) == "63").Sum(p => p.ZXJ);
            row["GCXJ4"] = GCXJ4;

            double GCMJ5= data.Where(p => p.Q_GC_LB == "70").Sum(p => p.YXMJ);
            row["GCMJ5"] = GCMJ5;
            double GCXJ5 = data.Where(p => p.Q_GC_LB == "70").Sum(p => p.ZXJ);
            row["GCXJ5"] = GCXJ5;



            double GCMJ6 = data.Where(p => p.Q_GC_LB == "42").Sum(p => p.YXMJ);
            row["GCMJ6"] = GCMJ6;
            double GCXJ6 = data.Where(p => p.Q_GC_LB == "42").Sum(p => p.ZXJ);
            row["GCXJ6"] = GCXJ6;

            double GCMJ7 = data.Where(p => Convert.ToString(p.Q_GC_LB) == "80").Sum(p => p.YXMJ) + data.Where(p => Convert.ToString(p.Q_GC_LB) == "81").Sum(p => p.YXMJ) + data.Where(p => Convert.ToString(p.Q_GC_LB) == "82").Sum(p => p.YXMJ) + data.Where(p => Convert.ToString(p.Q_GC_LB) == "83").Sum(p => p.YXMJ);
            row["GCMJ7"] = GCMJ7;
            double GCXJ7 = data.Where(p => Convert.ToString(p.Q_GC_LB) == "80").Sum(p => p.ZXJ) + data.Where(p => Convert.ToString(p.Q_GC_LB) == "81").Sum(p => p.ZXJ) + data.Where(p => Convert.ToString(p.Q_GC_LB) == "82").Sum(p => p.ZXJ) + data.Where(p => Convert.ToString(p.Q_GC_LB) == "83").Sum(p => p.ZXJ);
            row["GCXJ7"] = GCXJ7;



            double GCMJ8 = data.Where(p => p.Q_GC_LB == "96").Sum(p => p.YXMJ);
            row["GCMJ8"] = GCMJ8;
            double GCXJ8 = data.Where(p => p.Q_GC_LB == "96").Sum(p => p.ZXJ);
            row["GCXJ8"] = GCXJ8;

            row["HJMJ"] = GCMJ1 + GCMJ2 + GCMJ3 + GCMJ4 + GCMJ5 + GCMJ6 + GCMJ7 + GCMJ8;
            row["HJXJ"] = GCXJ1 + GCXJ2 + GCXJ3 + GCXJ4 + GCXJ5 + GCXJ6 + GCXJ7 + GCXJ8;
            m_table.Rows.Add(row);
        }
        protected override DataTable MakeTable()
        {
            DataTable table = new DataTable("ResultTable");

            table.Columns.Add("TJDW", typeof(string));
            table.Columns.Add("LINZHONG", typeof(string));
            table.Columns.Add("YSSZ", typeof(string));
            table.Columns.Add("QY", typeof(string));

            table.Columns.Add("HJMJ", typeof(double));
            table.Columns.Add("HJXJ", typeof(double));


            table.Columns.Add("GCMJ1", typeof(double));
            table.Columns.Add("GCXJ1", typeof(double));

            table.Columns.Add("GCMJ2", typeof(double));
            table.Columns.Add("GCXJ2", typeof(double));

            table.Columns.Add("GCMJ3", typeof(double));
            table.Columns.Add("GCXJ3", typeof(double));

            table.Columns.Add("GCMJ4", typeof(double));
            table.Columns.Add("GCXJ4", typeof(double));

            table.Columns.Add("GCMJ5", typeof(double));
            table.Columns.Add("GCXJ5", typeof(double));

            table.Columns.Add("GCMJ6", typeof(double));
            table.Columns.Add("GCXJ6", typeof(double));

            table.Columns.Add("GCMJ7", typeof(double));
            table.Columns.Add("GCXJ7", typeof(double));

            table.Columns.Add("GCMJ8", typeof(double));
            table.Columns.Add("GCXJ8", typeof(double));
            m_table = table;
            return m_table;
        }
    }
}
