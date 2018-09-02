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
    /// 小班报表1：各类土地面积统计表
    /// </summary>
    public class XB_Report_1 : XB_Report_Base
    {
        /// <summary>
        /// 小小班报表1：各类土地面积统计表：构造器
        /// </summary>
        public XB_Report_1()
        {
            SheetName = "1";
            m_firstRow = 7;
            m_firstColumn = 1;
            m_table = MakeTable();
        }

        /// <summary>
        /// 初始化报表
        /// </summary>
        /// <param name="midLayer"></param>
        /// <returns></returns>
        public override List<FOR_XIAOBAN_Mid> InitialReport(FindMidFromLayer<FOR_XIAOBAN_Mid> midLayer)
        {

            //需要获取的字段
            m_midLayer = midLayer;
            //字段：“县|乡|村||”
            //表1的字段有着特殊的意义,因为所有数据表将以此为基础字段进行字段的属性查询。因为将在此字段中进行查询所有有关字段，如果没有定义查询到特定字段时输出为null，因此就会无法输出数据至excel表格。
            ////string subFields = "XIAN,XIANG,CUN,TDJYQ,LD_QS,DI_LEI,SEN_LIN_LB,LIN_ZHONG,BH_DJ,LMJYQ,YOU_SHI_SZ,LING_ZU,YXMJ,ZXJ,SSXJ";
            string subFields = "SHI,XIAN,XIANG,CUN,TDJYQ,LD_QS,DI_LEI,SEN_LIN_LB,LJ,LIN_ZHONG,BH_DJ,LMJYQ,YOU_SHI_SZ,LING_ZU,YXMJ,ZXJ,SSXJ,QI_YUAN,G_CHENG_LB,SHI_QUAN_D,GJGYL_BHDJ,JJLCQ,QLJG,KE_JI_DU,CCLDJ,LMSYQ,Q_GC_LB,SHLX,SMHCD,SDLX,QSLX,DISPE,JKZK,JYLX,LIN_BAN,XIAO_BAN,MIAN_JI,PINGJUN_NL,PINGJUN_XJ,PINGJUN_SG,PINGJUN_DM,HUO_LMGQXJ,MEI_GQ_ZS,YU_BI_DU,JYCSLX,DI_MAO,PO_XIANG,PO_WEI,PO_DU,FZCH,TU_CENG_HD,SLHL,CTMY,TU_RANG_LX";
            m_xb_dataList = m_midLayer.Find(subFields, "", "Order by CUN");

            return m_xb_dataList;
        }
        public override DataTable FromMid2Table()
        {

            if (m_xb_dataList.Count < 1) { return m_table; }
            var dlLst = m_xb_dataList.Where(p => p.DI_LEI.Length > 2);//地类长度大于2
            if (dlLst.Count() < 1) { return m_table; }
            //本月整体统计
            string xianName = MDM.FindXQName(m_xb_dataList[0].SHI);
            MakeRowByQS(dlLst, xianName);
            //按乡统计
            var xiangGrps = dlLst.GroupBy(p => p.XIAN);
            foreach (var xg in xiangGrps)
            {
                string xiangName = MDM.FindXQName(xg.Key);
                MakeRowByQS(xg, xiangName);
                var cunGroup = xg.GroupBy(p => p.XIANG);
                foreach (var cg in cunGroup) {
                    string cunName = MDM.FindXQName(cg.Key);
                    MakeRowByQS(cg, cunName);
                }
               
            }
            return m_table;
        }
        private void MakeRowByQS(IEnumerable<FOR_XIAOBAN_Mid> data, string xzName)
        {
            var jyqGrps = data.GroupBy(p => p.LD_QS);//通过林地权属排序
            foreach (var xg in jyqGrps)
            {
                string jyqName = MDM.FindName("LD_QS", xg.Key);
                MakeRow(xg, xzName, jyqName);
            }
        }
        protected void MakeRow(IEnumerable<FOR_XIAOBAN_Mid> data, string xzName, string syq)
        {
            DataRow row = m_table.NewRow();
            row["TJDW"] = xzName;//统计单位->县
            row["TDSYQ"] = syq;//
            double zmj = data.Sum(p => p.YXMJ);
            row["TDZMJ"] = zmj;

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
            row["LDFZSCLD"] = data.Where(p => p.DI_LEI == "1800").Sum(p => p.YXMJ);

            row["FLDXJ"] = data.Where(p => p.DI_LEI.Substring(0, 1) == "2").Sum(p => p.YXMJ);

            row["LDHJ"] = yldxj + QMLDCL + QMLDHJL + WLMLDCF + WLMLDHS + WLMLDQT + YLDHS + YLDSH + YLDQT + WLMLDCF + WLMLDHS + WLMLDQT;

            row["GMLDXJ"] = GMJJL + QTGML;
            row["FLDNDQML"] = "0";
            row["FLDNDJJL"] = "0";
            row["FLDNDZL"] = "0";
            row["FLDSPS"] = "0";

            row["SLFGL"] = (QMLDCL + QMLDHJL + YLDZL + GMJJL) / zmj * 100;
            row["LMLHL"] = (QMLDCL + QMLDHJL + YLDZL + GMJJL) / zmj * 100;
            m_table.Rows.Add(row);
        }
        protected override DataTable MakeTable()
        {
            DataTable table = new DataTable("ResultTable");

            table.Columns.Add("TJDW", typeof(string));

            table.Columns.Add("TDSYQ", typeof(string));
            table.Columns.Add("TDZMJ", typeof(double));
            table.Columns.Add("LDHJ", typeof(double));
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

            table.Columns.Add("LDFZSCLD", typeof(double));


            table.Columns.Add("FLDXJ", typeof(double));
            table.Columns.Add("FLDNDQML", typeof(double));
            table.Columns.Add("FLDNDJJL", typeof(double));
            table.Columns.Add("FLDNDZL", typeof(double));
            table.Columns.Add("FLDSPS", typeof(double));

            table.Columns.Add("SLFGL", typeof(double));
            table.Columns.Add("LMLHL", typeof(double));
            m_table = table;
            return m_table;
        }
    }
}
