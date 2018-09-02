
using System;
using System.Data;
using System.Linq;
using td.forest.report.sf;
namespace Report
{
 

    internal class SF_Report_1 : SF_Report_Base
    {
        public SF_Report_1()
        {
            base.ReportID = "1";
            base.Theme = "SF";
            //设置写入Excel的位置
            this.StartIndex = "8";
            this.DataTableColIndex = 1;
        }
        public override DataTable FromMid2Table()
        {
            DataTable table = MakeTable();
            if (m_hz_dataList.Count < 1) { return table; }
            //本月整体统计
            MakeRow(table, m_hz_dataList, "全年累计");
            //按乡统计
            var xiangGrps = m_hz_dataList.GroupBy(p => p.Month);
            foreach (var xg in xiangGrps)
            {
                string yueName = xg.Key + "月";
                MakeRow(table, xg, yueName);
            }
            return table;
        }
    }
}

