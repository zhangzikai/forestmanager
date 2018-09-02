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
    /// 小班报表21   湿地统计表
    /// </summary>
    public class XB_Report_21 : XB_Report_Base
    {
        public XB_Report_21()
        {
            // 湿地统计表
            SheetName = "21";
            m_firstRow = 5;
            m_firstColumn = 1;
            m_table = MakeTable();
        }
        public override DataTable FromMid2Table()
        {
            if (m_xb_dataList.Count < 1) { return m_table; }
            var TDJYQ = m_xb_dataList.Where(p => !string.IsNullOrWhiteSpace(p.TDJYQ));

            if (TDJYQ.Count() < 1) { return m_table; }

            var xianGrp = TDJYQ.GroupBy(p => p.XIAN);
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
            var Grp1 = data.GroupBy(p => p.TDJYQ);
            foreach (var GP1 in Grp1)
            {
                string gp1Name = MDM.FindName("TDJYQ", GP1.Key);
                MakeRow(GP1, xzName, gp1Name);
                //var Grp2 = GP1.GroupBy(p => p.YOU_SHI_SZ);
                //foreach (var GP2 in Grp2)
                //{
                //    string gp2Name = MDM.FindName("SHU_ZHONG", GP2.Key);
                //    var Grp3 = GP2.GroupBy(p => p.QI_YUAN);
                //    foreach (var GP3 in Grp3)
                //    {
                //        string gp3Name = MDM.FindName("QI_YUAN", GP3.Key);
                //        MakeRow(GP3, xzName, gp1Name, gp2Name, gp3Name);
                //    }
                //}
            }
        }
        protected void MakeRow(IEnumerable<FOR_XIAOBAN_Mid> data, string xzName, string tdsyq)
        {
            DataRow row = m_table.NewRow();
            row["TJDW"] = xzName;
            row["TDSYQ"] = tdsyq;

            //湿地类型为null
            double JHJHASD = data.Where(p => Convert.ToString(p.SDLX) == "11").Sum(p => p.YXMJ) + data.Where(p => Convert.ToString(p.SDLX) == "12").Sum(p => p.YXMJ) + data.Where(p => Convert.ToString(p.SDLX) == "13").Sum(p => p.YXMJ) + data.Where(p => Convert.ToString(p.SDLX) == "14").Sum(p => p.YXMJ) + data.Where(p => Convert.ToString(p.SDLX) == "15").Sum(p => p.YXMJ) + data.Where(p => Convert.ToString(p.SDLX) == "16").Sum(p => p.YXMJ) + data.Where(p => Convert.ToString(p.SDLX) == "17").Sum(p => p.YXMJ) + data.Where(p => Convert.ToString(p.SDLX) == "18").Sum(p => p.YXMJ) + data.Where(p => Convert.ToString(p.SDLX) == "19").Sum(p => p.YXMJ);
            row["JHJHASD"] = JHJHASD;

            double HLSD = data.Where(p => Convert.ToString(p.SDLX) == "20").Sum(p => p.YXMJ)+data.Where(p => Convert.ToString(p.SDLX) == "21").Sum(p => p.YXMJ)+data.Where(p => Convert.ToString(p.SDLX) == "31").Sum(p => p.YXMJ)+data.Where(p => Convert.ToString(p.SDLX) == "32").Sum(p => p.YXMJ);
            row["HLSD"] = HLSD;

            double HPSD = data.Where(p => Convert.ToString(p.SDLX) == "20").Sum(p => p.YXMJ) + data.Where(p => Convert.ToString(p.SDLX) == "41").Sum(p => p.YXMJ) + data.Where(p => Convert.ToString(p.SDLX) == "42").Sum(p => p.YXMJ);
            row["HPSD"] = HPSD;

            double ZZSD = data.Where(p => Convert.ToString(p.SDLX) == "51").Sum(p => p.YXMJ) + data.Where(p => Convert.ToString(p.SDLX) == "52").Sum(p => p.YXMJ) + data.Where(p => Convert.ToString(p.SDLX) == "53").Sum(p => p.YXMJ) + data.Where(p => Convert.ToString(p.SDLX) == "54").Sum(p => p.YXMJ);
            row["ZZSD"] = ZZSD;

            double RGSD = data.Where(p => Convert.ToString(p.SDLX) == "61").Sum(p => p.YXMJ) + data.Where(p => Convert.ToString(p.SDLX) == "62").Sum(p => p.YXMJ) + data.Where(p => Convert.ToString(p.SDLX) == "63").Sum(p => p.YXMJ) + data.Where(p => Convert.ToString(p.SDLX) == "64").Sum(p => p.YXMJ) + data.Where(p => Convert.ToString(p.SDLX) == "65").Sum(p => p.YXMJ) + data.Where(p => Convert.ToString(p.SDLX) == "66").Sum(p => p.YXMJ) + data.Where(p => Convert.ToString(p.SDLX) == "67").Sum(p => p.YXMJ) + data.Where(p => Convert.ToString(p.SDLX) == "68").Sum(p => p.YXMJ) + data.Where(p => Convert.ToString(p.SDLX) == "69").Sum(p => p.YXMJ) + data.Where(p => Convert.ToString(p.SDLX) == "70").Sum(p => p.YXMJ) + data.Where(p => Convert.ToString(p.SDLX) == "71").Sum(p => p.YXMJ);
            row["RGSD"] = RGSD;

            row["HJMJ"] = JHJHASD + HLSD + HPSD + ZZSD + RGSD;

            m_table.Rows.Add(row);
        }
        protected override DataTable MakeTable()
        {
            DataTable table = new DataTable("ResultTable");

            table.Columns.Add("TJDW", typeof(string));
            table.Columns.Add("TDSYQ", typeof(string));


            table.Columns.Add("HJMJ", typeof(double));

            table.Columns.Add("JHJHASD", typeof(double));
            table.Columns.Add("HLSD", typeof(double));
            table.Columns.Add("HPSD", typeof(double));

            table.Columns.Add("ZZSD", typeof(double));
            table.Columns.Add("RGSD", typeof(double));

            m_table = table;
            return m_table;
        }
    }
}
