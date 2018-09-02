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
    /// 小班报表29   各类森林、林木面积蓄积变化统计表
    /// </summary>
    public class XB_Report_29 : XB_Report_Base
    {
        public XB_Report_29()
        {
            // 高保护价值森林统计表  ,未完成 没有高保护森林类型
            SheetName = "29";
            m_firstRow = 8;
            m_firstColumn = 1;
            m_table = MakeTable();
        }
        public override DataTable FromMid2Table()
        {
            if (m_xb_dataList.Count < 1) { return m_table; }
            var LMSYQ = m_xb_dataList.Where(p => !string.IsNullOrWhiteSpace(p.LMSYQ));
            if (LMSYQ.Count() < 1) { return m_table; }



            var xianGrp = LMSYQ.GroupBy(p => p.XIAN);
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

              //  var Grp2 = GP1.GroupBy(p => p.LIN_ZHONG);
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
        protected void MakeRow(IEnumerable<FOR_XIAOBAN_Mid> data, string xzName, string lmsyq)
        {
            DataRow row = m_table.NewRow();
            row["TJDW"] = xzName;
            row["tjnd"] = TJYear;
            row["lmsyq"] = lmsyq;


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

            row["yldmj"] = qmlmj+hslmj + zlmj + slmj;

            double spsxj = data.Sum(p => p.SSXJ);
            row["spsxj"] = spsxj;

            double fmj = 0;
            row["fmj"] = fmj;
            double fxj = 0;
            row["fxj"] = fxj;

            row["xjlhj"] = qmlxj+slxj + spsxj + fxj;
            m_table.Rows.Add(row);
        }
        protected override DataTable MakeTable()
        {
            DataTable table = new DataTable("ResultTable");

            table.Columns.Add("TJDW", typeof(string));
            table.Columns.Add("tjnd", typeof(string));
            table.Columns.Add("lmsyq", typeof(string));

            table.Columns.Add("xjlhj", typeof(double));

            table.Columns.Add("yldmj", typeof(double));
            table.Columns.Add("qmlmj", typeof(double));
            table.Columns.Add("qmlxj", typeof(double));

            table.Columns.Add("hslmj", typeof(double));
            table.Columns.Add("zlmj", typeof(double));

            table.Columns.Add("slmj", typeof(double));
            table.Columns.Add("slxj", typeof(double));

            table.Columns.Add("spsxj", typeof(double));

            table.Columns.Add("fmj", typeof(double));
            table.Columns.Add("fxj", typeof(double));
            m_table = table;
            return m_table;
        }
    }
}
