
using System;
using System.Data;
using System.Linq;
using td.forest.report.sf;
namespace Report
{
  
    /// <summary>
    /// 按地区统计
    /// </summary>
    internal class SF_Report_2 : SF_Report_Base
    {
        public SF_Report_2()
        {
            base.ReportID = "2";
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
            var xiangGrps = m_hz_dataList.GroupBy(p => p.XIANG);
            foreach (var xg in xiangGrps)
            {
                string xiangName = MDM.FindXQName(xg.Key);
                MakeRow(table, xg, xiangName);
            }
            return table;
        }
    }
}

