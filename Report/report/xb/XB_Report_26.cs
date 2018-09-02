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
    /// 小班报表26   森林经营类型按类型及乔木林龄组统计表
    /// </summary>
    public class XB_Report_26 : XB_Report_Base
    {
        public XB_Report_26()
        {
            // 森林经营类型按立地质量统计表,未完成，无立地质量
            SheetName = "26";
            m_firstRow = 7;
            m_firstColumn = 1;
            m_table = MakeTable();
        }
        public override DataTable FromMid2Table()
        {
            if (m_xb_dataList.Count < 1) { return m_table; }
            ////var JYLX = m_xb_dataList.Where(p => !string.IsNullOrWhiteSpace(p.JYLX));

            ////if (JYLX.Count() < 1) { return m_table; }

            var xianGrp = m_xb_dataList.GroupBy(p => p.XIAN);
            foreach (var xian in xianGrp)
            {
                string xianName = MDM.FindXQName(xian.Key);
                MakeRowBySub(xian, xianName);
                //按乡统计
                var xiangGrps = xian.GroupBy(p => p.XIANG);
                foreach (var xg in xiangGrps)
                {
                    string xiangName = MDM.FindXQName(xg.Key);
                    MakeRowBySub(xg, xiangName);
                }
            }
            return m_table;
        }
        private void MakeRowBySub(IEnumerable<FOR_XIAOBAN_Mid> data, string xzName)
        {
            var Grp1 = data.GroupBy(p => p.JYLX);
            foreach (var GP1 in Grp1)
            {
                string gp1Name = MDM.FindName("JYLX", GP1.Key);
                MakeRow(GP1, xzName, gp1Name);
                //var Grp2 = GP1.GroupBy(p => p.YOU_SHI_SZ);
                //foreach (var GP2 in Grp2)
                //{
                //    string gp2Name = MDM.FindName("SHU_ZHONG", GP2.Key);
                //    var Grp3 = GP2.GroupBy(p => p.QI_YUAN);
                //    foreach (var GP3 in Grp3)
                //    {
                //        string gp3Name = MDM.FindName("QI_YUAN", GP3.Key);
                //        MakeRow(GP3, xzName, gp1Name, gp2Name, gp3Name);
                //    }
                //}
            }
        }
        protected void MakeRow(IEnumerable<FOR_XIAOBAN_Mid> data, string xzName, string tdsyq)
        {
            DataRow row = m_table.NewRow();
            row["TJDW"] = xzName;
            string JYLX_TQ = tdsyq.Substring(tdsyq.LastIndexOf(":") + 1);
            row["TDSYQ"] = JYLX_TQ;

            var qml=data.Where(p=>p.DI_LEI=="1111"||p.DI_LEI=="1111");
            double L1mj = qml.Where(p => p.LING_ZU == "1").Sum(p => p.YXMJ);
            row["L1mj"] = L1mj;
            double L1xj = data.Where(p => p.LING_ZU == "1").Sum(p => p.ZXJ);
            row["L1xj"] = L1xj;

            double L2mj = qml.Where(p => p.LING_ZU == "2").Sum(p => p.YXMJ);
            row["L2mj"] = L2mj;
            double L2xj = data.Where(p => p.LING_ZU == "2").Sum(p => p.ZXJ);
            row["L2xj"] = L2xj;

            double L3mj = qml.Where(p => p.LING_ZU == "3").Sum(p => p.YXMJ);
            row["L3mj"] = L3mj;
            double L3xj = data.Where(p => p.LING_ZU == "3").Sum(p => p.ZXJ);
            row["L3xj"] = L3xj;

            double L4mj = qml.Where(p => p.LING_ZU == "4").Sum(p => p.YXMJ);
            row["L4mj"] = L4mj;
            double L4xj = data.Where(p => p.LING_ZU == "4").Sum(p => p.ZXJ);
            row["L4xj"] = L4xj;

            double L5mj = qml.Where(p => p.LING_ZU == "5").Sum(p => p.YXMJ);
            row["L5mj"] = L5mj;
            double L5xj = data.Where(p => p.LING_ZU == "6").Sum(p => p.ZXJ);
            row["L5xj"] = L5xj;

            row["qmmj"] = L1mj + L2mj + L3mj + L4mj + L5mj;
            row["qmxj"] = L1xj + L2xj + L3xj + L4xj + L5xj;

            row["hjmj"] = L1mj + L2mj + L3mj + L4mj + L5mj;
            row["hjxj"] = L1xj + L2xj + L3xj + L4xj + L5xj;

            m_table.Rows.Add(row);
        }
        protected override DataTable MakeTable()
        {
            DataTable table = new DataTable("ResultTable");

            table.Columns.Add("TJDW", typeof(string));
            table.Columns.Add("TDSYQ", typeof(string));


            table.Columns.Add("hjmj", typeof(double));
            table.Columns.Add("hjxj", typeof(double));

            table.Columns.Add("qmmj", typeof(double));
            table.Columns.Add("qmxj", typeof(double));

            table.Columns.Add("L1mj", typeof(double));
            table.Columns.Add("L1xj", typeof(double));

            table.Columns.Add("L2mj", typeof(double));
            table.Columns.Add("L2xj", typeof(double));

            table.Columns.Add("L3mj", typeof(double));
            table.Columns.Add("L3xj", typeof(double));

            table.Columns.Add("L4mj", typeof(double));
            table.Columns.Add("L4xj", typeof(double));

            table.Columns.Add("L5mj", typeof(double));
            table.Columns.Add("L5xj", typeof(double));

            m_table = table;
            return m_table;
        }
    }
}
