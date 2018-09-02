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
    /// 小班报表30   林种面积蓄积按类型变化统计表
    /// </summary>
    public class XB_Report_30 : XB_Report_Base
    {
        public XB_Report_30()
        {
            // 林种面积蓄积按类型变化统计表
            SheetName = "30";
            m_firstRow = 8;
            m_firstColumn = 1;
            m_table = MakeTable();
        }
        public override DataTable FromMid2Table()
        {
            if (m_xb_dataList.Count < 1) { return m_table; }
            var LIN_ZHONG = m_xb_dataList.Where(p => !string.IsNullOrWhiteSpace(p.LIN_ZHONG));
            if (LIN_ZHONG.Count() < 1) { return m_table; }



            var xianGrp = LIN_ZHONG.GroupBy(p => p.XIAN);
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

                //var Grp2 = GP1.GroupBy(p => p.LIN_ZHONG);
                MakeRow(GP1, xzName, gp1Name);
                //foreach (var GP2 in Grp2)
                //{
                //    string gp2Name = MDM.FindName("LIN_ZHONG", GP2.Key);
                //    MakeRow(GP1, xzName, gp1Name, gp2Name);
                //    //var Grp3 = GP2.GroupBy(p => p.QI_YUAN);
                //    //foreach (var GP3 in Grp3)
                //    //{
                //    //    string gp3Name = MDM.FindName("QI_YUAN", GP3.Key);
                //    //    MakeRow(GP3, xzName, gp1Name, gp2Name, gp3Name);
                //    //}
                //}
            }
        }
        protected void MakeRow(IEnumerable<FOR_XIAOBAN_Mid> data, string xzName,string linzhong)
        {
            DataRow row = m_table.NewRow();
            row["TJDW"] = xzName;
            row["tjnd"] = TJYear;
            row["linzhong"] = linzhong;


            double qmlmj = data.Where(p => p.DI_LEI == "1111" || p.DI_LEI == "1112").Sum(p => p.YXMJ);
            row["qmlmj"] = qmlmj;
            double qmlxj = data.Where(p => p.DI_LEI == "1111" || p.DI_LEI == "1112").Sum(p => p.ZXJ);
            row["qmlxj"] = qmlxj;

            double hslmj = data.Where(p => p.DI_LEI == "1120").Sum(p => p.YXMJ);
            row["hslmj"] = hslmj;
            double zlmj = data.Where(p => p.DI_LEI == "1130").Sum(p => p.YXMJ);
            row["zlmj"] = zlmj;

            double slmj = data.Where(p => p.DI_LEI == "1200").Sum(p => p.YXMJ);
            row["slmj"] = slmj;

            double slxj = data.Where(p => p.DI_LEI == "1200").Sum(p => p.ZXJ);
            row["slxj"] = slxj;

            row["yldmj"] = qmlmj + hslmj + zlmj + slmj;

            double gm1 = data.Where(p => p.DI_LEI == "1310").Sum(p => p.YXMJ);
            row["gm1"] = gm1;
            double gm2 = data.Where(p => p.DI_LEI == "1320").Sum(p => p.YXMJ);
            row["gm2"] = gm2;
            row["gmmjxj"] = gm1+gm2;

            row["zxj"] = qmlxj + slxj ;
            m_table.Rows.Add(row);
        }
        protected override DataTable MakeTable()
        {
            DataTable table = new DataTable("ResultTable");

            table.Columns.Add("TJDW", typeof(string));
            table.Columns.Add("tjnd", typeof(string));
            table.Columns.Add("linzhong", typeof(string));

            table.Columns.Add("zxj", typeof(double));

            table.Columns.Add("yldmj", typeof(double));
            table.Columns.Add("qmlmj", typeof(double));
            table.Columns.Add("qmlxj", typeof(double));

            table.Columns.Add("hslmj", typeof(double));
            table.Columns.Add("zlmj", typeof(double));

            table.Columns.Add("slmj", typeof(double));
            table.Columns.Add("slxj", typeof(double));

            table.Columns.Add("gmmjxj", typeof(double));
            table.Columns.Add("gm1", typeof(double));
            table.Columns.Add("gm2", typeof(double));
            m_table = table;
            return m_table;
        }
    }
}
