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
    /// 小班报表3   林种面积蓄积统计表
    /// </summary>
    public class XB_Report_3 : XB_Report_Base
    {
        public XB_Report_3()
        {
            //林种面积蓄积统计表
            SheetName = "3";
            m_firstRow = 8;
            m_firstColumn = 1;
            m_table = MakeTable();
        }
        public override DataTable FromMid2Table()
        {
            if (m_xb_dataList.Count < 1) { return m_table; }
            var linzh = m_xb_dataList.Where(p => !string.IsNullOrWhiteSpace(p.LIN_ZHONG));           

            var xianGrp = linzh.GroupBy(p => p.SHI);
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
            var lzGrp = data.GroupBy(p => p.LIN_ZHONG);
            foreach (var lz in lzGrp)
            {
                string lzName = MDM.FindName("LIN_ZHONG", lz.Key);               
                MakeRow(lz, xzName, lzName);
                
            }
        }
        protected void MakeRow(IEnumerable<FOR_XIAOBAN_Mid> data, string xzName, string lz)
        {
            DataRow row = m_table.NewRow();
            row["TJDW"] = xzName;
            row["LINZHONG"] = lz;
            row["ZMJ"] = data.Sum(p=>p.YXMJ);
            double zxj = data.Sum(p => p.ZXJ);
            row["ZXJL"] = zxj;

            var qmld = data.Where(p => p.DI_LEI.Substring(0, 3) == "111");
            double QMLDMJXJ = qmld.Sum(p => p.YXMJ);
            double QMLDXJXJ = qmld.Sum(p => p.ZXJ);

            row["QMLDMJXJ"] = QMLDMJXJ;
            row["QMLDXJXJ"] = QMLDXJXJ;


            double QMLDYLLMJ = qmld.Where(p => p.LING_ZU == "1").Sum(p => p.YXMJ);
            double QMLDYLLXJ = qmld.Where(p => p.LING_ZU == "1").Sum(p => p.ZXJ);
            row["QMLDYLLMJ"] = QMLDYLLMJ;
            row["QMLDYLLXJ"] = QMLDYLLXJ;

            double QMLDZLLMJ = qmld.Where(p => p.LING_ZU == "2").Sum(p => p.YXMJ);
            double QMLDZLLXJ = qmld.Where(p => p.LING_ZU == "2").Sum(p => p.ZXJ);
            row["QMLDZLLMJ"] = QMLDZLLMJ;
            row["QMLDZLLXJ"] = QMLDZLLXJ;

            double QMLDJSLMJ = qmld.Where(p => p.LING_ZU == "3").Sum(p => p.YXMJ);
            double QMLDJSLXJ = qmld.Where(p => p.LING_ZU == "3").Sum(p => p.ZXJ);
            row["QMLDJSLMJ"] = QMLDJSLMJ;
            row["QMLDJSLXJ"] = QMLDJSLXJ;

            double QMLDCSLMJ = qmld.Where(p => p.LING_ZU == "4").Sum(p => p.YXMJ);
            double QMLDCSLXJ = qmld.Where(p => p.LING_ZU == "4").Sum(p => p.ZXJ);
            row["QMLDCSLMJ"] = QMLDCSLMJ;
            row["QMLDCSLXJ"] = QMLDCSLXJ;


            double QMLDGSLMJ = qmld.Where(p => p.LING_ZU == "5").Sum(p => p.YXMJ);
            double QMLDGSLXJ = qmld.Where(p => p.LING_ZU == "5").Sum(p => p.ZXJ);
            row["QMLDGSLMJ"] = QMLDGSLMJ;
            row["QMLDGSLXJ"] = QMLDGSLXJ;

            double HSLMJ = data.Where(p => p.DI_LEI == "1120").Sum(p => p.YXMJ);
            row["HSLMJ"] = HSLMJ;


            double ZLMJ = data.Where(p => p.DI_LEI == "1130").Sum(p => p.YXMJ);
            double ZLZS = 0;//data.Where(p => p.DI_LEI == "1130").Sum(p => p.GXGQZS);
            row["ZLMJ"] = ZLMJ;
            row["ZLZS"] = ZLZS;

            double SLMJ = data.Where(p => p.DI_LEI == "1200").Sum(p => p.YXMJ);
            double SLXJ = data.Where(p => p.DI_LEI == "1200").Sum(p => p.ZXJ);
            row["SLMJ"] = SLMJ;
            row["SLXJ"] = SLXJ;


            double GJTBGMLMJ = data.Where(p => p.DI_LEI== "1310").Sum(p => p.YXMJ);
            row["GJTBGMLMJ"] = GJTBGMLMJ;

            double QTGMLMJ = data.Where(p => p.DI_LEI == "1320").Sum(p => p.YXMJ);
            row["QTGMLMJ"] = QTGMLMJ;
            row["GMLMJXJ"] = GJTBGMLMJ + QTGMLMJ;

            row["YLDMJXJ"] = QMLDMJXJ + HSLMJ + ZLMJ;
         
            m_table.Rows.Add(row);
        }
        protected override DataTable MakeTable()
        {
            DataTable table = new DataTable("ResultTable");

            table.Columns.Add("TJDW", typeof(string));
            table.Columns.Add("LINZHONG", typeof(string));
            table.Columns.Add("ZMJ", typeof(string));
            table.Columns.Add("ZXJL", typeof(double));

            table.Columns.Add("YLDMJXJ", typeof(double));

            table.Columns.Add("QMLDMJXJ", typeof(double));
            table.Columns.Add("QMLDXJXJ", typeof(double));

            table.Columns.Add("QMLDYLLMJ", typeof(double));
            table.Columns.Add("QMLDYLLXJ", typeof(double));

            table.Columns.Add("QMLDZLLMJ", typeof(double));
            table.Columns.Add("QMLDZLLXJ", typeof(double));

            table.Columns.Add("QMLDJSLMJ", typeof(double));
            table.Columns.Add("QMLDJSLXJ", typeof(double));

            table.Columns.Add("QMLDCSLMJ", typeof(double));
            table.Columns.Add("QMLDCSLXJ", typeof(double));

            table.Columns.Add("QMLDGSLMJ", typeof(double));
            table.Columns.Add("QMLDGSLXJ", typeof(double));


    

            table.Columns.Add("HSLMJ", typeof(double));
            table.Columns.Add("ZLMJ", typeof(double));
            table.Columns.Add("ZLZS", typeof(double));

            table.Columns.Add("SLMJ", typeof(double));
            table.Columns.Add("SLXJ", typeof(double));


            table.Columns.Add("GMLMJXJ", typeof(double));
            table.Columns.Add("GJTBGMLMJ", typeof(double));
            table.Columns.Add("QTGMLMJ", typeof(double));
            m_table = table;
            return m_table;
        }
    }
}
