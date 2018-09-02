using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using td.db.mid.forest;
using td.forest.report.sf;


namespace Report
{

    internal class SF_Report_3 : SF_Report_Base
    {
        public SF_Report_3()
        {
            base.ReportID = "3";
            base.Theme = "SF";
            //设置写入Excel的位置
            this.StartIndex = "4";
            this.DataTableColIndex = 0;
            MergeColIndex = "1";
        }
        public override DataTable FromMid2Table()
        {
            DataTable table = MakeTable();
            if (m_hz_dataList.Count < 1) { return table; }
            //全年合计
            MakeRow(table, m_hz_dataList, "全年合计", "合计");
            var djGrps=m_hz_dataList.GroupBy(p => p.HZDJ_I).OrderBy(p=>p.Key);
            foreach(var dgGrp in djGrps)
            {
                MakeRow(table, dgGrp, "全年合计", dgGrp.Key + "级");
            }        
            //按月统计
            var mongGrps = m_hz_dataList.GroupBy(p => p.Month);
            foreach (var xg in mongGrps)
            {
                MakeRow(table, xg, xg.Key+"月", "合计");
                var djGrps2 = xg.GroupBy(p => p.HZDJ_I).OrderBy(p => p.Key);
                foreach (var dgGrp in djGrps2)
                {
                    MakeRow(table, dgGrp, xg.Key + "月", dgGrp.Key + "级");
                }                       
            }
            return table;
        }
        protected  void MakeRow(DataTable table, IEnumerable<T_ZT_HZ_INFO_Mid> data, string firstName,string jibie)
        {
            DataRow row = table.NewRow();
            row["DNAME"] = firstName;
            row["JIBIE"] = jibie;    
            row["HZCSJ"] = data.Count();    
            row["HCZMJ"] = Math.Round(data.Sum(p => p.TOTAL_MJ), m_digits);
            double num8 = Math.Round(data.Sum(p => p.YSL_MJ), m_digits);
            double num9 = Math.Round(data.Sum(p => p.RGL_MJ), m_digits);
            row["SHMJJ"] = Math.Round(num9 + num8, m_digits);
            row["YSL"] = Math.Round(num8, m_digits);
            row["RGL"] = Math.Round(num9, m_digits);
            row["CLXJ"] = Math.Round(data.Sum(p => p.SS_CL), m_digits);
            row["YLZS"] = data.Sum(p => p.SS_YL);

            int num13 = data.Sum(p => p.SHANG_Q);
            int num14 = data.Sum(p => p.SHANG_Z);
            int num15 = data.Sum(p => p.SHANG_S);
            row["QS"] = num13;
            row["ZS"] = num14;
            row["SW"] = num15;
            row["RYSWJ"] = num13 + num14 + num15;

            row["QTSS"] = Math.Round(data.Sum(p => p.SS_MONEY), m_digits);
            row["PHRG"] = data.Sum(p => p.PU_RG);
            row["CLJ"] = data.Sum(p => p.PU_CL);
            row["QC"] = row["CLJ"];
            row["FJ"] = data.Sum(p => p.PU_FJ);
            row["JF"] = Math.Round(data.Sum(p => p.PU_JF), m_digits);

            table.Rows.Add(row);
        }
        protected override DataTable MakeTable()
        {
            DataTable table = new DataTable("ResultTable");
           
            table.Columns.Add("DNAME", typeof(string));

            table.Columns.Add("JIBIE", typeof(string));
            //森林火灾次数
            table.Columns.Add("HZCSJ", typeof(int));
      
            //火场总面积
            table.Columns.Add("HCZMJ", typeof(double));
            //受害森林面积
            table.Columns.Add("SHMJJ", typeof(double));
            //原始林
            table.Columns.Add("YSL", typeof(double));
            //人工林
            table.Columns.Add("RGL", typeof(double));
            //成林蓄积
            table.Columns.Add("CLXJ", typeof(double));
            //幼林株数
            table.Columns.Add("YLZS", typeof(double));
            //人员伤亡
            table.Columns.Add("RYSWJ", typeof(int));
            //轻伤
            table.Columns.Add("QS", typeof(int));
            //重伤
            table.Columns.Add("ZS", typeof(int));
            //死亡
            table.Columns.Add("SW", typeof(int));
            //其他损失
            table.Columns.Add("QTSS", typeof(double));
            //扑火人工
            table.Columns.Add("PHRG", typeof(int));
            //出动车辆计
            table.Columns.Add("CLJ", typeof(int));
            //汽车
            table.Columns.Add("QC", typeof(int));
            //飞机
            table.Columns.Add("FJ", typeof(int));
            //经费 
            table.Columns.Add("JF", typeof(double));
            return table;
        }
    }
}

