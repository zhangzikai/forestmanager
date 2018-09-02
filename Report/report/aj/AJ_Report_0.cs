using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Report;
using td.db.mid.forest;
namespace Report
{    

    internal class AJ_Report_0 : ReportEntity
    {
        public AJ_Report_0()
        {
            base.ReportID = "0";
            base.Theme = "AJ";
            //设置写入Excel的位置
            this.StartIndex = "7";
            this.DataTableColIndex = 0;
            MergeColIndex = "1";
            m_aj_dataList = null;
        }
        protected List<ZT_LYAJ_Mid> m_aj_dataList;
        public override void InitialReport(ReportParamter pReportParamter)
        {
            base.InitialReport(pReportParamter);
            //需要获取的字段
            string subFields = "SHI,XIAN,XIANG,CUN,MIAN_JI,DI_LEI,AJLX,XWZT,SSLDMJ,SSLMXJ,SSMZZS,SSYSMMZS,FSRQ,JLRQ";
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
            string whereSql = "FSRQ>'" + startTime + "' and FSRQ<'" + endTime + "'";
            m_aj_dataList = pReportParamter.FindFromLayer_AJ.Find(subFields, whereSql, "Order by CUN");

        }
        public override DataTable FromMid2Table()
        {
            DataTable table = MakeTable();
            if (m_aj_dataList.Count < 1) { return table; }
            //本年整体统计
            MakeRow(table, m_aj_dataList, "全年累计","全部");
            var lxGrps = m_aj_dataList.GroupBy(p=>p.AJLX);
            foreach(var lx in lxGrps)
            {
                string ajName = this.MDM.FindName("AJLX", lx.Key);
                MakeRow(table, lx, "全年累计", ajName);
            }
            //按月统计
            var mongGrps = m_aj_dataList.GroupBy(p => p.Month).OrderBy(p=>p.Key);
            foreach (var xg in mongGrps)
            {
                string yueName = xg.Key + "月";
                lxGrps = xg.GroupBy(p => p.AJLX);
                foreach (var lx in lxGrps)
                {
                    string ajName = this.MDM.FindName("AJLX", lx.Key);
                    MakeRow(table, xg, yueName, ajName);
                }
                
            }
            return table;
        }
        protected int m_index = 1;
        protected virtual void MakeRow(DataTable table, IEnumerable<ZT_LYAJ_Mid> data, string timeName,string ajName)
        {
            DataRow row = table.NewRow();
           
            row["YFNAME"] = timeName;
            row["AJMC"] = ajName;         
            row["FSZS"] = data.Count() ;
            row["ZF"] = data.Where(p => p.XWZT=="1").Count();
            row["QY"] = data.Where(p => p.XWZT == "2").Count();
            row["GM"] = data.Where(p => p.XWZT == "3").Count();
            row["QTZZ"] = data.Where(p => p.XWZT == "4").Count();

            row["LD"] = data.Sum(p => p.SSLDMJ);
            row["LM"] = data.Sum(p => p.SSLMXJ);
            row["ZZ"] = data.Sum(p => p.SSMZZS);
            row["YSMM"] = data.Sum(p => p.SSYSMMZS);
            table.Rows.Add(row);
        }

        protected override DataTable MakeTable()
        {
            DataTable table = new DataTable("ResultTable");
          
            table.Columns.Add("YFNAME", typeof(string));
            //案件名称
            table.Columns.Add("AJMC", typeof(string));
          
            //发生总数
            table.Columns.Add("FSZS", typeof(int));
            //政府
            table.Columns.Add("ZF", typeof(int));
            //企业
            table.Columns.Add("QY", typeof(int));
            //公民
            table.Columns.Add("GM", typeof(int));
            //其他主体
            table.Columns.Add("QTZZ", typeof(int));
            //林地
            table.Columns.Add("LD", typeof(int));
            //林木
            table.Columns.Add("LM", typeof(int));
            //竹子
            table.Columns.Add("ZZ", typeof(int));
            //幼树或苗木
            table.Columns.Add("YSMM", typeof(int));
         
            return table;
        }
    }
}

