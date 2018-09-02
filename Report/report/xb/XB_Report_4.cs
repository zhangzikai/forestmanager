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
    /// 小班报表4   乔木林面积蓄积按龄组统计表
    /// </summary>
    public class XB_Report_4 : XB_Report_Base
    {
        public XB_Report_4()
        {
            //乔木林面积蓄积按龄组统计表
            SheetName = "4";
            m_firstRow =6;
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
                var qiyuan = lz.GroupBy(p=>p.QI_YUAN);
                foreach (var qy in qiyuan)
                {
                    string qiy = MDM.FindName("QI_YUAN",qy.Key);
                    MakeRow(lz, xzName, lzName, qiy);
                }
            }
        }
        protected void MakeRow(IEnumerable<FOR_XIAOBAN_Mid> data, string xzName, string lz,string qiyuan)
        {
            DataRow row = m_table.NewRow();
            row["TJDW"] = xzName;
            row["LINZHONG"] = lz;
            row["YLZ"] = "";

            if (qiyuan.Contains("QI_YUAN:"))
            {
                row["QIYUAN"] = "无";
            }
            else
            {
                row["QIYUAN"] = qiyuan;
            }
            
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

            m_table.Rows.Add(row);
        }
        protected override DataTable MakeTable()
        {
            DataTable table = new DataTable("ResultTable");

            table.Columns.Add("TJDW", typeof(string));
            table.Columns.Add("LINZHONG", typeof(string));
            table.Columns.Add("YLZ", typeof(string));
            table.Columns.Add("QIYUAN", typeof(string));  

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

            m_table = table;
            return m_table;
        }
    }
}
