using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using td.db.mid.forest;


namespace Report
{
    
    /// <summary>
    /// 灾害
    /// </summary>
    internal class ZH_Report_0 : ReportEntity
    {
        public ZH_Report_0()
        {
            base.ReportID = "0";
            base.Theme = "ZH";
            //设置写入Excel的位置
            this.StartIndex = "7";
            this.DataTableColIndex = 0;
            MergeColIndex = "1";
            m_zh_dataList = null;
        }
        protected List<ZT_ZH_Mid> m_zh_dataList;
        public override void InitialReport(ReportParamter pReportParamter)
        {
            base.InitialReport(pReportParamter);
            //需要获取的字段
            string subFields = "SHI,XIAN,XIANG,CUN,MIAN_JI,SSMJ,DISPE,DISASTER_C,SSZS,FXRQ";
            int yue = Convert.ToInt32(pReportParamter.YueFen);
            int year = Convert.ToInt32(pReportParamter.Year);
            //得到获取的时间,得到全年的数据
            string startTime = string.Format("{0}{1:00}01", year, 1);
            if (yue < 12) { yue += 1; }
            else
            {
                yue = 1;
                year += 1;
            }
            string endTime = string.Format("{0}{1:00}31", year, 12);
            string whereSql = "FXRQ>'" + startTime + "' and FXRQ<'" + endTime + "'";
            m_zh_dataList = pReportParamter.FindFromLayer_ZH.Find(subFields, whereSql, "Order by CUN");

        }
        public override DataTable FromMid2Table()
        {
            DataTable table = MakeTable();
            if (m_zh_dataList.Count < 1) { return table; }
            //本年整体统计
            MakeRow(table, m_zh_dataList, "全县累计", "全县");
            var lxGrps = m_zh_dataList.GroupBy(p => p.DISPE);
            foreach (var lx in lxGrps)
            {
                string ajName = this.MDM.FindName("DISPE", lx.Key);
                MakeRow(table, lx, "全县累计", ajName);
            }
            //按乡统计
            var mongGrps = m_zh_dataList.GroupBy(p => p.XIANG).OrderBy(p => p.Key);
            foreach (var xg in mongGrps)
            {
                string yueName = MDM.FindXQName(xg.Key);
                lxGrps = m_zh_dataList.GroupBy(p => p.DISPE);
                foreach (var lx in lxGrps)
                {
                    string ajName = this.MDM.FindName("DISPE", lx.Key);
                    MakeRow(table, xg, yueName, ajName);
                }

            }
            return table;
        }
        protected int m_index = 1;
        protected virtual void MakeRow(DataTable table, IEnumerable<ZT_ZH_Mid> data, string xzqName, string clsName)
        {
            DataRow row = table.NewRow();
          
            row["XZQYNAME"] = xzqName;
          
            
            row["XM"] = clsName;
          

            double qing = data.Where(p => p.DISASTER_C == "1").Sum(p => p.MIAN_JI);
            double zhong = data.Where(p => p.DISASTER_C == "2").Sum(p => p.MIAN_JI);
            double zzhong = data.Where(p => p.DISASTER_C == "3").Sum(p => p.MIAN_JI);
            double fsmj = qing + zhong + zzhong;
            row["QJ"] = Math.Round(qing, m_digits);
            row["ZJ"] = Math.Round(zhong, m_digits);
            row["ZZJ"] = Math.Round(zzhong, m_digits);
            row["FSMJHJ"] = Math.Round(fsmj, m_digits);

            double qing2 = data.Where(p => p.DISASTER_C == "1").Sum(p => p.SSMJ);
            double zhong2 = data.Where(p => p.DISASTER_C == "2").Sum(p => p.SSMJ);
            double zzhong2 = data.Where(p => p.DISASTER_C == "3").Sum(p => p.SSMJ);
            double czmj = qing2 + zhong2 + zzhong2;

            row["CZQJ"] = Math.Round(qing2, m_digits);
            row["CZZJ"] = Math.Round(zhong2, m_digits);
            row["CZZZJ"] = Math.Round(zzhong2, m_digits);
            row["CZHJ"] = Math.Round(czmj, m_digits);
            double czl=Math.Round((czmj / fsmj * 100), m_digits);
            row["CZL"] = czl + "%";
            row["SWZS"] = data.Sum(p => p.SSZS);
            table.Rows.Add(row);
        }

        protected override DataTable MakeTable()
        {
            DataTable table = new DataTable("ResultTable");
          
            //行政区名称
            table.Columns.Add("XZQYNAME", typeof(string));           
         
            //项目
            table.Columns.Add("XM", typeof(string));
            //发生总面积
            table.Columns.Add("FSMJHJ", typeof(double));
            //轻级
            table.Columns.Add("QJ", typeof(double));
            //中级
            table.Columns.Add("ZJ", typeof(double));
            //重级
            table.Columns.Add("ZZJ", typeof(double));
            //成灾合计
            table.Columns.Add("CZHJ", typeof(double));
            //成灾轻级
            table.Columns.Add("CZQJ", typeof(double));
            //成灾中级
            table.Columns.Add("CZZJ", typeof(double));
            //成灾重级
            table.Columns.Add("CZZZJ", typeof(double));
         
            //成灾率
            table.Columns.Add("CZL", typeof(string));
            //死树株数
            table.Columns.Add("SWZS", typeof(int));

            return table;
        }
    }
}

