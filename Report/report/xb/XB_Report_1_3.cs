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
    /// 小班报表1-3： 各类林地按保护等级面积统计表
    /// </summary>
    public class XB_Report_1_3 : XB_Report_Base
    {
        public XB_Report_1_3()
        {
            //各类林地按保护等级面积统计表
            SheetName = "1-3";
            m_firstRow = 7;
            m_firstColumn = 1;
            m_table = MakeTable();
        }
        public override List<FOR_XIAOBAN_Mid> InitialReport(FindMidFromLayer<FOR_XIAOBAN_Mid> midLayer)
        {
            //需要获取的字段
            m_midLayer = midLayer;
            string subFields = "SHI,XIAN,XIANG,CUN,TDJYQ,LD_QS,DI_LEI,SEN_LIN_LB,LIN_ZHONG,BH_DJ,YXMJ";
            m_xb_dataList = m_midLayer.Find(subFields, "", "Order by CUN");
            return m_xb_dataList;
        }
        public override DataTable FromMid2Table()
        {
            if (m_xb_dataList.Count < 1) { return m_table; }
            var bhdj = m_xb_dataList.Where(p => !string.IsNullOrWhiteSpace(p.BH_DJ));

            if (bhdj.Count() < 1) { return m_table; }
            //本月整体统计
            string xianName = MDM.FindXQName(m_xb_dataList[0].SHI);
            MakeRowByBHDJ(bhdj, xianName);
            //按乡统计
            var xiangGrps = bhdj.GroupBy(p => p.XIAN);
            foreach (var xg in xiangGrps)
            {
                string xiangName = MDM.FindXQName(xg.Key);
                MakeRowByBHDJ(xg, xiangName);
                var cunGroup = xg.GroupBy(p => p.XIANG);
                foreach (var cg in cunGroup)
                {
                    string cunName = MDM.FindXQName(cg.Key);
                    MakeRowByBHDJ(cg, cunName);
                }
            }
            return m_table;
        }
        private void MakeRowByBHDJ(IEnumerable<FOR_XIAOBAN_Mid> data, string xzName)
        {
            var jyqGrps = data.GroupBy(p => p.SEN_LIN_LB);
            foreach (var xg in jyqGrps)
            {
                string bhdj = MDM.FindName("BH_DJ", xg.Key);
                MakeRow(xg, xzName, bhdj);
            }
        }
        protected void MakeRow(IEnumerable<FOR_XIAOBAN_Mid> data, string xzName, string bhdj)
        {
            DataRow row = m_table.NewRow();
            row["TJDW"] = xzName;

            string bhdj_tq = bhdj.Substring(bhdj.LastIndexOf(":") + 1);
            row["BHDJ"] = bhdj_tq;


            double zmj = data.Sum(p => p.YXMJ);
            row["LDZMJ"] = zmj;

            double QMLDCL = data.Where(p => p.DI_LEI == "1111").Sum(p => p.YXMJ);
            double QMLDHJL = data.Where(p => p.DI_LEI == "1112").Sum(p => p.YXMJ);
            row["QMLDCL"] = QMLDCL;
            row["QMLDHJL"] = QMLDHJL;
            row["QMLDXJ"] = QMLDCL + QMLDHJL;
            double YLDHSL = data.Where(p => p.DI_LEI == "1120").Sum(p => p.YXMJ);
            double YLDZL = data.Where(p => p.DI_LEI == "1130").Sum(p => p.YXMJ);
            row["YLDHSL"] = YLDHSL;
            row["YLDZL"] = YLDZL;

            double yldxj = QMLDCL + QMLDHJL + YLDHSL + YLDZL;
            row["YLDXJ"] = yldxj;

            double LDSLD = data.Where(p => p.DI_LEI == "1200").Sum(p => p.YXMJ);
            row["LDSLD"] = LDSLD;

            double GMJJL = data.Where(p => p.DI_LEI == "1310").Sum(p => p.YXMJ);
            row["GMJJL"] = GMJJL;
            row["GJTGJ"] = GMJJL;
            row["GMJJL"] = GMJJL;
            double QTGML = data.Where(p => p.DI_LEI == "1320").Sum(p => p.YXMJ);
            row["QTGML"] = QTGML;
            row["GMLDXJ"] = GMJJL + QTGML;

            double WCZRG = data.Where(p => p.DI_LEI == "1410").Sum(p => p.YXMJ);
            double WCZFY = data.Where(p => p.DI_LEI == "1420").Sum(p => p.YXMJ);
            row["WCZRG"] = WCZRG;
            row["WCZFY"] = WCZFY;
            row["WLCZLDXJ"] = WCZFY + WCZRG;

            double LDMPD = data.Where(p => p.DI_LEI == "1500").Sum(p => p.YXMJ);
            row["LDMPD"] = LDMPD;


            double WLMLDCF = data.Where(p => p.DI_LEI == "1610").Sum(p => p.YXMJ);
            double WLMLDHS = data.Where(p => p.DI_LEI == "1620").Sum(p => p.YXMJ);
            double WLMLDQT = data.Where(p => p.DI_LEI.Substring(0, 3) == "163").Sum(p => p.YXMJ);

            row["WLMLDCF"] = WLMLDCF;
            row["WLMLDHS"] = WLMLDHS;
            row["WLMLDQT"] = WLMLDQT;
            row["WLMLDXJ"] = WLMLDCF + WLMLDHS + WLMLDQT;


            double YLDHS = data.Where(p => p.DI_LEI == "1710").Sum(p => p.YXMJ);
            double YLDSH = data.Where(p => p.DI_LEI == "1720").Sum(p => p.YXMJ);
            double YLDQT = data.Where(p => p.DI_LEI == "1730").Sum(p => p.YXMJ);

            row["YLDHS"] = YLDHS;
            row["YLDSH"] = YLDSH;
            row["YLDQT"] = YLDQT;
            row["YILDXJ"] = YLDHS + YLDSH + YLDQT;


            double FZSCLD = data.Where(p => p.DI_LEI == "1800").Sum(p => p.YXMJ);
            row["FZSCLD"] = FZSCLD;

            m_table.Rows.Add(row);
        }
        protected override DataTable MakeTable()
        {
            DataTable table = new DataTable("ResultTable");

            table.Columns.Add("TJDW", typeof(string));
            table.Columns.Add("BHDJ", typeof(string));

            table.Columns.Add("LDZMJ", typeof(double));

            table.Columns.Add("YLDXJ", typeof(double));
            table.Columns.Add("QMLDXJ", typeof(double));
            table.Columns.Add("QMLDCL", typeof(double));
            table.Columns.Add("QMLDHJL", typeof(double));

            table.Columns.Add("YLDHSL", typeof(double));
            table.Columns.Add("YLDZL", typeof(double));

            table.Columns.Add("LDSLD", typeof(double));

            table.Columns.Add("GMLDXJ", typeof(double));
            table.Columns.Add("GJTGJ", typeof(double));
            table.Columns.Add("GMJJL", typeof(double));
            table.Columns.Add("QTGML", typeof(double));

            table.Columns.Add("WLCZLDXJ", typeof(double));
            table.Columns.Add("WCZRG", typeof(double));
            table.Columns.Add("WCZFY", typeof(double));

            table.Columns.Add("LDMPD", typeof(double));

            table.Columns.Add("WLMLDXJ", typeof(double));
            table.Columns.Add("WLMLDCF", typeof(double));
            table.Columns.Add("WLMLDHS", typeof(double));
            table.Columns.Add("WLMLDQT", typeof(double));



            table.Columns.Add("YILDXJ", typeof(double));
            table.Columns.Add("YLDHS", typeof(double));
            table.Columns.Add("YLDSH", typeof(double));
            table.Columns.Add("YLDQT", typeof(double));

            table.Columns.Add("FZSCLD", typeof(double));

            m_table = table;
            return m_table;
        }
    }
}
