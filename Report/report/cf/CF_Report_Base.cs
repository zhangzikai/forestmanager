using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Report;
using td.db.mid.forest;

namespace td.forest.report.cf
{
    /// <summary>
    /// “采伐统计报表”的底层类
    /// </summary>
    public class CF_Report_Base : ReportEntity
    {
        protected List<T_ZT_HZ_INFO_Mid> m_hz_dataList;
        public override void InitialReport(ReportParamter pReportParamter)
        {
            base.InitialReport(pReportParamter);
      
            //需要获取的字段
            string subFields = "XIAN,XIANG,CUN,DIMING,QHSJ,PHSJ,TOTAL_MJ,YSL_MJ,RGL_MJ,LINFEN,SS_CL,SS_YL,SS_ZLMJ,SHANG_Q,SHANG_Z,SHANG_S,SS_MONEY,PU_RG,PU_CL,PU_QC,PU_FJ,PU_JF,SF_CL,CL_RS,CL_XSRS,HZYY,FIRE_NO,HZDJ,NL";
            int yue = Convert.ToInt32(pReportParamter.YueFen);
            int year = Convert.ToInt32(pReportParamter.Year);
            //得到获取的时间,得到全年的数据
            string startTime = string.Format("{0}-{1:00}-01 00:00:00", year, 1);
            if (yue < 12) { yue += 1; }
            else
            {
                yue = 1;
                year += 1;
            }
            string endTime = string.Format("{0}-{1:00}-31 23:59:59", year, 12);
            string whereSql = "QHSJ>'" + startTime + "' and QHSJ<'" + endTime + "'";
            m_hz_dataList = pReportParamter.FindFromTable.Find(subFields, whereSql, "Order by CUN");

        }
        protected int m_index = 1;
        protected virtual void MakeRow(DataTable table, IEnumerable<T_ZT_HZ_INFO_Mid> data, string xiangName)
        {
            DataRow row = table.NewRow();
            row["ID"] = m_index++;
            row["DMANME"] = xiangName;
            int num2 = data.Where(p => p.HZDJ_I == 1).Count();
            int num3 = data.Where(p => p.HZDJ_I == 2).Count();
            int num4 = data.Where(p => p.HZDJ_I == 3).Count();
            int num5 = data.Where(p => p.HZDJ_I == 4).Count();
            row["HZCSJ"] = num2 + num3 + num4 + num5;
            row["YBHZ"] = num2;
            row["JDHZ"] = num3;
            row["ZDHZ"] = num4;
            row["TDHZ"] = num5;
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
            table.Columns.Add("ID", typeof(int));
            table.Columns.Add("DMANME", typeof(string));
            //森林火灾次数
            table.Columns.Add("HZCSJ", typeof(int));
            //一般火灾
            table.Columns.Add("YBHZ", typeof(int));
            //较大火灾
            table.Columns.Add("JDHZ", typeof(int));
            //重大火灾
            table.Columns.Add("ZDHZ", typeof(int));
            //特大火灾
            table.Columns.Add("TDHZ", typeof(int));
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
