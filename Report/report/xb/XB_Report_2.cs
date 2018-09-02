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
    /// 小班报表2   各类森林、林木面积蓄积统计表
    /// </summary>
    public class XB_Report_2 : XB_Report_Base
    {
        public XB_Report_2()
        {
            //各类林地按保护等级面积统计表
            SheetName = "2";
            m_firstRow = 8;
            m_firstColumn = 1;
            m_table = MakeTable();
        }  
        public override DataTable FromMid2Table()
        {
            if (m_xb_dataList.Count < 1) { return m_table; }
            var lmjyq = m_xb_dataList.Where(p => !string.IsNullOrWhiteSpace(p.LMJYQ));

            if (lmjyq.Count() < 1) { return m_table; }
            //本月整体统计
            string xianName = MDM.FindXQName(m_xb_dataList[0].SHI);
            MakeRowByLMSYQ(lmjyq, xianName);
            //按乡统计
            var xiangGrps = lmjyq.GroupBy(p => p.XIAN);
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
            return m_table;
        }
        private void MakeRowByLMSYQ(IEnumerable<FOR_XIAOBAN_Mid> data, string xzName)
        {
            var jyqGrps = data.GroupBy(p => p.LMJYQ);
            foreach (var xg in jyqGrps)
            {
                string bhdj = MDM.FindName("LMSYQ", xg.Key);
                MakeRow(xg, xzName, bhdj);
            }
        }
        protected void MakeRow(IEnumerable<FOR_XIAOBAN_Mid> data, string xzName, string lmsyq)
        {
            DataRow row = m_table.NewRow();
            row["TJDW"] = xzName;
            row["LMSYQ"] = lmsyq;
            double zxj = data.Sum(p => p.ZXJ);
            row["HLMZXJ"] = zxj;

            double QMLDCLMJ = data.Where(p => p.DI_LEI == "1111").Sum(p => p.YXMJ);
            double QMLDHJLMJ = data.Where(p => p.DI_LEI == "1112").Sum(p => p.YXMJ);
            double QMLDCLXJ = data.Where(p => p.DI_LEI == "1111").Sum(p => p.ZXJ);
            double QMLDHJLXJ = data.Where(p => p.DI_LEI == "1112").Sum(p => p.ZXJ);

            row["QMLDCLMJ"] = QMLDCLMJ;
            row["QMLDHJLMJ"] = QMLDHJLMJ;
            row["QMLDCLXJ"] = QMLDCLXJ;
            row["QMLDHJLXJ"] = QMLDHJLXJ;

            row["QMLDMJXJ"] = QMLDCLMJ + QMLDCLMJ;
            row["QMLDXJXJ"] = QMLDCLXJ + QMLDHJLXJ;
            double YLDHSLMJ = data.Where(p => p.DI_LEI == "1120").Sum(p => p.YXMJ);
            double YLDZLMJ = data.Where(p => p.DI_LEI == "1130").Sum(p => p.YXMJ);
            double YLDZLZS = 0;//data.Where(p => p.DI_LEI == "1130").Sum(p => p.GXGQZS);
            row["YLDHSLMJ"] = YLDZLMJ;
            row["YLDZLMJ"] = YLDZLMJ;
            row["YLDZLZS"] = YLDZLZS;

            double YLDMJXJ = QMLDCLMJ + QMLDHJLMJ + YLDHSLMJ + YLDZLMJ;
            row["YLDMJXJ"] = YLDMJXJ;

            double SLDMJ = data.Where(p => p.DI_LEI == "1200").Sum(p => p.YXMJ);
            double SLDXJ = data.Where(p => p.DI_LEI == "1200").Sum(p => p.ZXJ);
            row["SLDMJ"] = SLDMJ;
            row["SLDXJ"] = SLDXJ;

            double SPSZS = 0;
            double SPSXJ = data.Sum(p => p.SSXJ);
            row["SPSZS"] = SPSZS;
            row["SPSXJ"] = SPSXJ;

            double SSMZS = 0;
            double SSMXJ = data.Sum(p => p.SSXJ);
            row["SSMZS"] = SSMZS;
            row["SSMXJ"] = SSMXJ;

            double FLDMJ = data.Where(p => p.DI_LEI.Substring(0, 1) == "2").Sum(p => p.YXMJ);
            double FLDXJ = data.Where(p => p.DI_LEI.Substring(0,1) == "2").Sum(p => p.ZXJ);
            row["FLDMJ"] = FLDMJ;
            row["FLDXJ"] = FLDXJ;
            m_table.Rows.Add(row);
        }
        protected override DataTable MakeTable()
        {
            DataTable table = new DataTable("ResultTable");

            table.Columns.Add("TJDW", typeof(string));
            table.Columns.Add("LMSYQ", typeof(string));

            table.Columns.Add("HLMZXJ", typeof(double));

            table.Columns.Add("YLDMJXJ", typeof(double));
            table.Columns.Add("QMLDMJXJ", typeof(double));
            table.Columns.Add("QMLDXJXJ", typeof(double));
            table.Columns.Add("QMLDCLMJ", typeof(double));
            table.Columns.Add("QMLDCLXJ", typeof(double));
            table.Columns.Add("QMLDHJLMJ", typeof(double));
            table.Columns.Add("QMLDHJLXJ", typeof(double));

            table.Columns.Add("YLDHSLMJ", typeof(double));
            table.Columns.Add("YLDZLMJ", typeof(double));
            table.Columns.Add("YLDZLZS", typeof(double));

            table.Columns.Add("SLDMJ", typeof(double));
            table.Columns.Add("SLDXJ", typeof(double));

            table.Columns.Add("SPSZS", typeof(double));
            table.Columns.Add("SPSXJ", typeof(double));


            table.Columns.Add("SSMZS", typeof(double));
            table.Columns.Add("SSMXJ", typeof(double));

            table.Columns.Add("FLDMJ", typeof(double));
            table.Columns.Add("FLDXJ", typeof(double));
            m_table = table;
            return m_table;
        }
    }
}
