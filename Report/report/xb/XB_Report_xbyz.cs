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
    /// 小班报表：小班主要调查因子一览表
    /// </summary>
    public class XB_Report_xbyz : XB_Report_Base
    {
        public XB_Report_xbyz()
        {
            //  乔木林单位面积蓄积变化统计表
            SheetName = "小班因子表";
            m_firstRow = 8;
            m_firstColumn = 1;
            m_table = MakeTable();
        }
        public override DataTable FromMid2Table()
        {
            if (m_xb_dataList.Count < 1) { return m_table; }

            var YOU_SHI_SZ = m_xb_dataList.Where(p => !string.IsNullOrWhiteSpace(p.YOU_SHI_SZ));
            if (YOU_SHI_SZ.Count() < 1) { return m_table; }

            var xianGrp = YOU_SHI_SZ.GroupBy(p => p.XIAN);
            foreach (var xian in xianGrp)
            {
                string xianName = MDM.FindXQName(xian.Key);              
                //按乡统计
                var xiangGrps = xian.GroupBy(p => p.XIANG);
                foreach (var xg in xiangGrps)
                {
                    string xiangName = MDM.FindXQName(xg.Key);
                    var cunGrps=xg.GroupBy(p => p.CUN);
                    foreach(var cGrp in cunGrps)
                    {
                        string cunName = MDM.FindXQName(xg.Key);
                        MakeRow(cGrp, xianName, xiangName, cunName);
                    }
                }
            }
            return m_table;
        }
 
        protected void MakeRow(IEnumerable<FOR_XIAOBAN_Mid> data, string xian, string xiang,string cun)
        {
            foreach (var mid in data)
            {
                DataRow row = m_table.NewRow();
                row["xian"] = xian;
                row["xiang"] = xiang;
                row["cun"] = cun;
                row["lbh"] = mid.LIN_BAN;
                row["xbh"] = mid.XIAO_BAN;


               row["tdqs"] = MDM.FindName("LD_QS",mid.LD_QS);
               row["tdsyq"] = MDM.FindName("TDJYQ", mid.TDJYQ);
               row["lmsuoyouqan"] = MDM.FindName("LMSYQ", mid.LMSYQ);
               row["lmsyq"] = MDM.FindName("LMJYQ", mid.LMJYQ);
               row["tdzl"] = MDM.FindName("DI_LEI", mid.DI_LEI);

               row["zmj"] = mid.MIAN_JI;
               row["yxmj"] = mid.YXMJ;
               row["xbxj"] = mid.ZXJ;

               row["shuzhong"] = MDM.FindName("SHU_ZHONG", mid.YOU_SHI_SZ);
               row["qiyuan"] = MDM.FindName("QI_YUAN", mid.QI_YUAN);
               row["nianling"] = mid.PINGJUN_NL;

               row["lingzu"] = MDM.FindName("LING_ZU", mid.LING_ZU);
               row["pjzj"] = mid.PINGJUN_XJ;
               row["pjsg"] = mid.PINGJUN_SG;

               row["gqdm"] = mid.PINGJUN_DM;
               row["gqxj"] = mid.HUO_LMGQXJ;
               row["gqzs"] = mid.MEI_GQ_ZS;

               row["ybd"] = mid.YU_BI_DU;
               row["linzhong"] = MDM.FindName("LIN_ZHONG", mid.LIN_ZHONG);
               row["gaobaohu"] = "";
 
               row["senlinleibie"] = MDM.FindName("SEN_LIN_LB", mid.SEN_LIN_LB);
               row["gylshiquanji"] = MDM.FindName("SHI_QUAN_D", mid.SHI_QUAN_D);
               row["gylshiquandengji"] = MDM.FindName("GJGYL_BHDJ", mid.GJGYL_BHDJ);

               row["lindibhdj"] = MDM.FindName("BH_DJ", mid.BH_DJ);
               row["jingygllx"] = MDM.FindName("JYCSLX", mid.JYCSLX);

               //源代码抛出数组越界异常
               row["jingyleixing"] = MDM.FindName("JYLX", mid.JYLX);

              
               //源代码抛出数组越界异常，故注销：“System.OutOfMemoryException”类型的异常在 mscorlib.dll 中发生，但未在用户代码中进行处理
               row["jingyingcuoslx"] = MDM.FindName("JYCSLX", mid.JYCSLX);

               row["dimaoleixing"] = MDM.FindName("DI_MAO", mid.DI_MAO);
               row["haiba"] = mid.HBG;
               row["px"] = MDM.FindName("PO_XIANG", mid.PO_XIANG);
               row["pw"] = MDM.FindName("PO_WEI", mid.PO_WEI);

               row["pd"] = mid.PO_DU;

               row["fzzh"] = mid.FZCH;
               row["tchd"] = mid.TU_CENG_HD;
               row["lshl"] = mid.SLHL ;
               row["ctmy"] = MDM.FindName("CTMY", mid.CTMY);

               row["trzl"] = MDM.FindName("TU_RANG_LX", mid.TU_RANG_LX);

                m_table.Rows.Add(row);
            }
        }
        protected override DataTable MakeTable()
        {
            DataTable table = new DataTable("ResultTable");

            table.Columns.Add("xian", typeof(string));
            table.Columns.Add("xiang", typeof(string));
            table.Columns.Add("cun", typeof(string));
            table.Columns.Add("lbh", typeof(string));
            table.Columns.Add("xbh", typeof(string));

            table.Columns.Add("tdqs", typeof(string));
            table.Columns.Add("tdsyq", typeof(string));
            table.Columns.Add("lmsuoyouqan", typeof(string));
            table.Columns.Add("lmsyq", typeof(string));
            table.Columns.Add("tdzl", typeof(string));

            table.Columns.Add("zmj", typeof(double));
            table.Columns.Add("yxmj", typeof(double));
            table.Columns.Add("xbxj", typeof(double));


            table.Columns.Add("shuzhong", typeof(string));
            table.Columns.Add("qiyuan", typeof(string));
            table.Columns.Add("nianling", typeof(string));
            table.Columns.Add("lingzu", typeof(string));
            table.Columns.Add("pjzj", typeof(double));
            table.Columns.Add("pjsg", typeof(double));
            table.Columns.Add("gqdm", typeof(double));
            table.Columns.Add("gqxj", typeof(double));
            table.Columns.Add("gqzs", typeof(double));


            table.Columns.Add("ybd", typeof(double));
            table.Columns.Add("linzhong", typeof(string));
            table.Columns.Add("gaobaohu", typeof(string));


            table.Columns.Add("senlinleibie", typeof(string));
            table.Columns.Add("gylshiquanji", typeof(string));
            table.Columns.Add("gylshiquandengji", typeof(string));


            table.Columns.Add("lindibhdj", typeof(string));
            table.Columns.Add("jingygllx", typeof(string));

            table.Columns.Add("jingyleixing", typeof(string));
            ////数组越界异常
            table.Columns.Add("jingyingcuoslx", typeof(string));


            table.Columns.Add("dimaoleixing", typeof(string));
            table.Columns.Add("haiba", typeof(double));
            table.Columns.Add("px", typeof(string));
            table.Columns.Add("pw", typeof(string));
            ////“pd”未能初始化
            table.Columns.Add("pd", typeof(double));

            table.Columns.Add("fzzh", typeof(double));
            table.Columns.Add("tchd", typeof(double));
            table.Columns.Add("lshl", typeof(double));

            table.Columns.Add("ctmy", typeof(string));
            table.Columns.Add("trzl", typeof(string));
            m_table = table;
            return m_table;
        }
    }
}
