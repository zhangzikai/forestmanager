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
    /// 小班报表5   公益林(地)统计表
    /// </summary>
    public class XB_Report_5 : XB_Report_Base
    {
        public XB_Report_5()
        {
            //公益林(地)统计表
            SheetName = "5";
            m_firstRow = 8;
            m_firstColumn = 1;
            m_table = MakeTable();
        }
        public override DataTable FromMid2Table()
        {
            if (m_xb_dataList.Count < 1) { return m_table; }
            var gclb = m_xb_dataList.Where(p => !string.IsNullOrWhiteSpace(p.G_CHENG_LB));
            if (gclb.Count() < 1) { return m_table; }
            var qgdj = gclb.Where(p => !string.IsNullOrWhiteSpace(p.SHI_QUAN_D));
            if (qgdj.Count() < 1) { return m_table; }
            var bhdj = qgdj.Where(p => !string.IsNullOrWhiteSpace(p.GJGYL_BHDJ));
            if (bhdj.Count() < 1) { return m_table; }

            var xianGrp = bhdj.GroupBy(p => p.SHI);
            foreach (var xian in xianGrp)
            {
                string xianName = MDM.FindXQName(xian.Key);
                MakeRowByLMSYQ(xian, xianName);
                //按乡统计
                var xiangGrps = xian.GroupBy(p => p.XIAN);
                foreach (var xg in xiangGrps)
                {
                    string xiangName = MDM.FindXQName(xg.Key);
                    MakeRowByLMSYQ(xg, xiangName);
                    var cunGroup = xg.GroupBy(p => p.XIANG);
                    foreach (var cg in cunGroup)
                    {
                        string cunName = MDM.FindXQName(cg.Key);
                        MakeRowByLMSYQ(cg, cunName);
                    }
                }
            }
            return m_table;
        }
        private void MakeRowByLMSYQ(IEnumerable<FOR_XIAOBAN_Mid> data, string xzName)
        {
            var Grp1 = data.GroupBy(p => p.G_CHENG_LB);
            foreach (var GP1 in Grp1)
            {
                string gp1Name = MDM.FindName("G_CHENG_LB", GP1.Key);
                var Grp2 = GP1.GroupBy(p => p.SHI_QUAN_D);
                foreach (var GP2 in Grp2)
                {
                    var Grp3 = GP1.GroupBy(p => p.SHI_QUAN_D);
                    string gp2Name = MDM.FindName("SHI_QUAN_D", GP2.Key);
                    foreach (var GP3 in Grp3)
                    {
                        string gp3Name = MDM.FindName("GJGYL_BHDJ", GP3.Key);
                        MakeRow(GP3, xzName, gp1Name, gp2Name, gp3Name);
                    }
                }

            }
        }
        protected void MakeRow(IEnumerable<FOR_XIAOBAN_Mid> data, string xzName, string gclb, string sqdj, string bhdj)
        {
            DataRow row = m_table.NewRow();
            row["TJDW"] = xzName;
            ////if (gclb.Equals("G_CHENG_LB:21"))
            ////{
            ////    string gclb_tq = gclb.Substring(gclb.LastIndexOf(":" + 1));
            ////    row["GCLB"] = gclb_tq;
            ////}
            ////else
            ////{
            row["GCLB"] = gclb;

            row["SQDJ"] = sqdj;

            string bhdj_tq = bhdj.Substring(bhdj.LastIndexOf(":") + 1);
            row["BHDJ"] = bhdj_tq;

            row["ZMJ"] = data.Sum(p => p.YXMJ);


            double CHUNLINMJ = data.Where(p => p.DI_LEI == "1111").Sum(p => p.YXMJ);
            double HUNJIAOLINMJ = data.Where(p => p.DI_LEI == "1111").Sum(p => p.YXMJ);

            row["CHUNLINMJ"] = CHUNLINMJ;
            row["HUNJIAOLINMJ"] = HUNJIAOLINMJ;
            row["QMLDMJXJ"] = HUNJIAOLINMJ + CHUNLINMJ;

            double HSLMJ = data.Where(p => p.DI_LEI == "1120").Sum(p => p.YXMJ);
            row["HSLMJ"] = HSLMJ;
            double ZLMJ = data.Where(p => p.DI_LEI == "1130").Sum(p => p.YXMJ);
            row["ZLMJ"] = ZLMJ;

            row["YLDMJXJ"] = HUNJIAOLINMJ + CHUNLINMJ + HSLMJ + ZLMJ;

            double SLDMJ = data.Where(p => p.DI_LEI == "1200").Sum(p => p.YXMJ);
            row["SLDMJ"] = SLDMJ;


            double GGMJ = data.Where(p => p.DI_LEI == "1310").Sum(p => p.YXMJ);
            double TSGMMJ = data.Where(p => p.DI_LEI == "1320").Sum(p => p.YXMJ);
            row["GGMJ"] = GGMJ;
            row["TSGMMJ"] = TSGMMJ;
            row["GMLDMJXJ"] = GGMJ + TSGMMJ;

            double WCZRGMJ = data.Where(p => p.DI_LEI == "1410").Sum(p => p.YXMJ);
            double WCZFYJM = data.Where(p => p.DI_LEI == "1410").Sum(p => p.YXMJ);
            row["WCZRGMJ"] = WCZRGMJ;
            row["WCZFYJM"] = WCZFYJM;
            row["WCZMJXJ"] = WCZRGMJ + WCZFYJM;

            double MPDMJ = data.Where(p => p.DI_LEI == "1500").Sum(p => p.YXMJ);
            row["MPDMJ"] = MPDMJ;

            double CFJDMJ = data.Where(p => p.DI_LEI == "1610").Sum(p => p.YXMJ);
            double HSJDMJ = data.Where(p => p.DI_LEI == "1620").Sum(p => p.YXMJ);
            double QTWLMLD = data.Where(p => p.DI_LEI == "1631").Sum(p => p.YXMJ);
            row["CFJDMJ"] = WCZRGMJ;
            row["HSJDMJ"] = HSJDMJ;
            row["QTWLMLD"] = QTWLMLD;
            row["WMMLDMJXJ"] = WCZRGMJ + WCZFYJM + QTWLMLD;



            double YDLHSMJ = data.Where(p => p.DI_LEI == "1710").Sum(p => p.YXMJ);
            double YLDSHMJ = data.Where(p => p.DI_LEI == "1720").Sum(p => p.YXMJ);
            double YLDQT = data.Where(p => p.DI_LEI == "1730").Sum(p => p.YXMJ);
            row["YDLHSMJ"] = YDLHSMJ;
            row["YLDSHMJ"] = YLDSHMJ;
            row["YLDQT"] = YLDQT;

            row["YILDMJXJ"] = YDLHSMJ + YLDSHMJ + YLDQT;


            double FZDMJ = data.Where(p => p.DI_LEI == "1800").Sum(p => p.YXMJ);
            row["FZDMJ"] = FZDMJ;

            m_table.Rows.Add(row);
        }
        protected override DataTable MakeTable()
        {
            DataTable table = new DataTable("ResultTable");

            table.Columns.Add("TJDW", typeof(string));
            table.Columns.Add("GCLB", typeof(string));
            table.Columns.Add("SQDJ", typeof(string));
            table.Columns.Add("BHDJ", typeof(string));

            table.Columns.Add("ZMJ", typeof(double));
            table.Columns.Add("YLDMJXJ", typeof(double));

            table.Columns.Add("QMLDMJXJ", typeof(double));


            table.Columns.Add("CHUNLINMJ", typeof(double));
            table.Columns.Add("HUNJIAOLINMJ", typeof(double));

            table.Columns.Add("HSLMJ", typeof(double));
            table.Columns.Add("ZLMJ", typeof(double));
            table.Columns.Add("SLDMJ", typeof(double));

            table.Columns.Add("GMLDMJXJ", typeof(double));
            table.Columns.Add("GGMJ", typeof(double));
            table.Columns.Add("TSGMMJ", typeof(double));


            table.Columns.Add("WCZMJXJ", typeof(double));
            table.Columns.Add("WCZRGMJ", typeof(double));
            table.Columns.Add("WCZFYJM", typeof(double));

            table.Columns.Add("MPDMJ", typeof(double));

            table.Columns.Add("WMMLDMJXJ", typeof(double));
            table.Columns.Add("CFJDMJ", typeof(double));
            table.Columns.Add("HSJDMJ", typeof(double));
            table.Columns.Add("QTWLMLD", typeof(double));

            table.Columns.Add("YILDMJXJ", typeof(double));
            table.Columns.Add("YDLHSMJ", typeof(double));
            table.Columns.Add("YLDSHMJ", typeof(double));
            table.Columns.Add("YLDQT", typeof(double));

            table.Columns.Add("FZDMJ", typeof(double));
            m_table = table;
            return m_table;
        }
    }
}
