
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using td.db.mid.forest;
using td.forest.report.sf;
namespace Report
{

    /// <summary>
    /// 火灾
    /// </summary>
    internal class SF_Report_0 : SF_Report_Base
    {
        
        public SF_Report_0()
        {
            base.ReportID = "0";
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
            MakeRow(table, m_hz_dataList, "自年初至本月合计");
            //本月整体统计
            int yue = Convert.ToInt32(this.YueFen);
            var benYueData = m_hz_dataList.Where(p => p.Month == yue);
            MakeRow(table, benYueData, "本月合计");
            //按乡统计
            var xiangGrps = benYueData.GroupBy(p => p.XIANG);
            foreach(var xg in xiangGrps)
            {
                string xiangName = MDM.FindXQName(xg.Key);
                MakeRow(table, xg, xiangName);
            }
            return table;
        }
      
    }
}

