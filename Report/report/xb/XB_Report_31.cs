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
    /// 小班报表31   林种面积蓄积变化统计表
    /// </summary>
    public class XB_Report_31 : XB_Report_Base
    {
        public XB_Report_31()
        {
            //  林种面积蓄积变化统计表
            SheetName = "31";
            m_firstRow = 6;
            m_firstColumn = 1;
            m_table = MakeTable();
        }
        public override DataTable FromMid2Table()
        {
            if (m_xb_dataList.Count < 1) { return m_table; }
            var QI_YUAN = m_xb_dataList.Where(p => !string.IsNullOrWhiteSpace(p.QI_YUAN));
            if (QI_YUAN.Count() < 1) { return m_table; }



            var xianGrp = QI_YUAN.GroupBy(p => p.XIAN);
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
            var Grp1 = data.GroupBy(p => p.QI_YUAN);
            foreach (var GP1 in Grp1)
            {
                string gp1Name = MDM.FindName("QI_YUAN", GP1.Key);

                //  var Grp2 = GP1.GroupBy(p => p.LIN_ZHONG);
                MakeRow(GP1, xzName, gp1Name);
                //foreach (var GP2 in Grp2)
                //{
                //    string gp2Name = MDM.FindName("LIN_ZHONG", GP2.Key);
                //    MakeRow(GP1, xzName, gp1Name, gp2Name);
                //    //var Grp3 = GP2.GroupBy(p => p.QI_YUAN);
                //    //foreach (var GP3 in Grp3)
                //    //{
                //    //    string gp3Name = MDM.FindName("QI_YUAN", GP3.Key);
                //    //    MakeRow(GP3, xzName, gp1Name, gp2Name, gp3Name);
                //    //}
                //}
            }
        }
        protected void MakeRow(IEnumerable<FOR_XIAOBAN_Mid> data, string xzName, string qiyuan)
        {
            DataRow row = m_table.NewRow();
            row["TJDW"] = xzName;
            row["tjnd"] = TJYear;
            row["qiyuan"] = qiyuan;


            double linzh1mj = data.Where(p => Convert.ToString(p.LIN_ZHONG) == "110").Sum(p => p.YXMJ)+data.Where(p => Convert.ToString(p.LIN_ZHONG) == "111").Sum(p => p.YXMJ)+data.Where(p => Convert.ToString(p.LIN_ZHONG) == "112").Sum(p => p.YXMJ)+data.Where(p => Convert.ToString(p.LIN_ZHONG) == "113").Sum(p => p.YXMJ)+data.Where(p => Convert.ToString(p.LIN_ZHONG) == "114").Sum(p => p.YXMJ)+data.Where(p => Convert.ToString(p.LIN_ZHONG) == "115").Sum(p => p.YXMJ)+data.Where(p => Convert.ToString(p.LIN_ZHONG) == "116").Sum(p => p.YXMJ)+data.Where(p => Convert.ToString(p.LIN_ZHONG) == "117").Sum(p => p.YXMJ);
            row["linzh1mj"] = linzh1mj;
            double linzh1xj = data.Where(p => Convert.ToString(p.LIN_ZHONG) == "110").Sum(p => p.ZXJ) + data.Where(p => Convert.ToString(p.LIN_ZHONG) == "111").Sum(p => p.ZXJ) + data.Where(p => Convert.ToString(p.LIN_ZHONG) == "112").Sum(p => p.ZXJ) + data.Where(p => Convert.ToString(p.LIN_ZHONG) == "113").Sum(p => p.ZXJ) + data.Where(p => Convert.ToString(p.LIN_ZHONG) == "114").Sum(p => p.ZXJ) + data.Where(p => Convert.ToString(p.LIN_ZHONG) == "115").Sum(p => p.ZXJ) + data.Where(p => Convert.ToString(p.LIN_ZHONG) == "116").Sum(p => p.ZXJ) + data.Where(p => Convert.ToString(p.LIN_ZHONG) == "117").Sum(p => p.ZXJ);
            row["linzh1xj"] = linzh1xj;

            double linzh2mj = data.Where(p => Convert.ToString(p.LIN_ZHONG) == "120").Sum(p => p.YXMJ) + data.Where(p => Convert.ToString(p.LIN_ZHONG) == "121").Sum(p => p.YXMJ) + data.Where(p => Convert.ToString(p.LIN_ZHONG) == "122").Sum(p => p.YXMJ) + data.Where(p => Convert.ToString(p.LIN_ZHONG) == "123").Sum(p => p.YXMJ) + data.Where(p => Convert.ToString(p.LIN_ZHONG) == "124").Sum(p => p.YXMJ) + data.Where(p => Convert.ToString(p.LIN_ZHONG) == "125").Sum(p => p.YXMJ) + data.Where(p => Convert.ToString(p.LIN_ZHONG) == "126").Sum(p => p.YXMJ) + data.Where(p => Convert.ToString(p.LIN_ZHONG) == "127").Sum(p => p.YXMJ);
            row["linzh2mj"] = linzh2mj;
            double linzh2xj = data.Where(p => Convert.ToString(p.LIN_ZHONG) == "120").Sum(p => p.ZXJ) + data.Where(p => Convert.ToString(p.LIN_ZHONG) == "121").Sum(p => p.ZXJ) + data.Where(p => Convert.ToString(p.LIN_ZHONG) == "122").Sum(p => p.ZXJ) + data.Where(p => Convert.ToString(p.LIN_ZHONG) == "123").Sum(p => p.ZXJ) + data.Where(p => Convert.ToString(p.LIN_ZHONG) == "124").Sum(p => p.ZXJ) + data.Where(p => Convert.ToString(p.LIN_ZHONG) == "125").Sum(p => p.ZXJ) + data.Where(p => Convert.ToString(p.LIN_ZHONG) == "126").Sum(p => p.ZXJ) + data.Where(p => Convert.ToString(p.LIN_ZHONG) == "127").Sum(p => p.ZXJ);
            row["linzh2xj"] = linzh2xj;


            double linzh3mj = data.Where(p => Convert.ToString(p.LIN_ZHONG) == "130").Sum(p => p.YXMJ) + data.Where(p => Convert.ToString(p.LIN_ZHONG) == "131").Sum(p => p.YXMJ) + data.Where(p => Convert.ToString(p.LIN_ZHONG) == "132").Sum(p => p.YXMJ) + data.Where(p => Convert.ToString(p.LIN_ZHONG) == "133").Sum(p => p.YXMJ);
            row["linzh3mj"] = linzh3mj;
            double linzh3xj = data.Where(p => Convert.ToString(p.LIN_ZHONG) == "130").Sum(p => p.ZXJ) + data.Where(p => Convert.ToString(p.LIN_ZHONG) == "131").Sum(p => p.ZXJ) + data.Where(p => Convert.ToString(p.LIN_ZHONG) == "132").Sum(p => p.ZXJ) + data.Where(p => Convert.ToString(p.LIN_ZHONG) == "133").Sum(p => p.ZXJ);
            row["linzh3xj"] = linzh3xj;

            double linzh4mj = data.Where(p => Convert.ToString(p.LIN_ZHONG) == "240").Sum(p => p.YXMJ);
            row["linzh4mj"] = linzh4mj;
            double linzh4xj = data.Where(p => Convert.ToString(p.LIN_ZHONG) == "240").Sum(p => p.ZXJ);
            row["linzh4xj"] = linzh4xj;

            double linzh5mj = data.Where(p => Convert.ToString(p.LIN_ZHONG) == "250").Sum(p => p.YXMJ)+data.Where(p => Convert.ToString(p.LIN_ZHONG) == "251").Sum(p => p.YXMJ)+data.Where(p => Convert.ToString(p.LIN_ZHONG) == "252").Sum(p => p.YXMJ)+data.Where(p => Convert.ToString(p.LIN_ZHONG) == "253").Sum(p => p.YXMJ)+data.Where(p => Convert.ToString(p.LIN_ZHONG) == "254").Sum(p => p.YXMJ)+data.Where(p => Convert.ToString(p.LIN_ZHONG) == "255").Sum(p => p.YXMJ);
            row["linzh5mj"] = linzh5mj;
            double linzh5xj = data.Where(p => Convert.ToString(p.LIN_ZHONG) == "250").Sum(p => p.ZXJ) + data.Where(p => Convert.ToString(p.LIN_ZHONG) == "251").Sum(p => p.ZXJ) + data.Where(p => Convert.ToString(p.LIN_ZHONG) == "252").Sum(p => p.ZXJ) + data.Where(p => Convert.ToString(p.LIN_ZHONG) == "253").Sum(p => p.ZXJ) + data.Where(p => Convert.ToString(p.LIN_ZHONG) == "254").Sum(p => p.ZXJ) + data.Where(p => Convert.ToString(p.LIN_ZHONG) == "255").Sum(p => p.ZXJ);
            row["linzh5xj"] = linzh5xj;

            row["hjmj"] = linzh1mj + linzh2mj + linzh3mj + linzh4mj+linzh5mj;
            row["hjxj"] = linzh1xj + linzh2xj + linzh3xj + linzh4xj+linzh5xj;

            m_table.Rows.Add(row);
        }
        protected override DataTable MakeTable()
        {
            DataTable table = new DataTable("ResultTable");

            table.Columns.Add("TJDW", typeof(string));
            table.Columns.Add("tjnd", typeof(string));
            table.Columns.Add("qiyuan", typeof(string));

            table.Columns.Add("hjmj", typeof(double));
            table.Columns.Add("hjxj", typeof(double));

            table.Columns.Add("linzh1mj", typeof(double));
            table.Columns.Add("linzh1xj", typeof(double));

            table.Columns.Add("linzh2mj", typeof(double));
            table.Columns.Add("linzh2xj", typeof(double));


            table.Columns.Add("linzh3mj", typeof(double));
            table.Columns.Add("linzh3xj", typeof(double));

            table.Columns.Add("linzh4mj", typeof(double));
            table.Columns.Add("linzh4xj", typeof(double));

            table.Columns.Add("linzh5mj", typeof(double));
            table.Columns.Add("linzh5xj", typeof(double));

            m_table = table;
            return m_table;
        }
    }
}
