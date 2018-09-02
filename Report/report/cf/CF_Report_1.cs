﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using td.db.mid.forest;
using td.logic.forest;

namespace Report
{
    /// <summary>
    /// 采伐统计表--择伐、渐伐、抚育采伐伐区调查设计汇总表
    /// </summary>
    internal class CF_Report_1 : ReportEntity
    {
        protected List<ZT_CF_Mid> m_dataList;

        private DataTable m_table;

        /// <summary>
        /// 采伐统计表--择伐、渐伐、抚育采伐伐区调查设计汇总表：构造器
        /// </summary>
        public CF_Report_1()
        {
            base.ReportID = "1";
            base.Theme = "CF";

            //设置写入Excel的位置
            this.StartIndex = "8";
            this.DataTableColIndex = 0;
            MergeColIndex = "1";
            m_dataList = null;
        }

        /// <summary>
        /// 初始化报表字段：获取需要的字段
        /// </summary>
        /// <param name="pReportParamter"></param>
        public override void InitialReport(ReportParamter pReportParamter)
        {
            base.InitialReport(pReportParamter);
            //需要获取的字段

            string subFields = "SHI,XIAN,XIANG,CUN,XIAO_BAN,LIN_ZHONG,YOU_SHI_SZ,LIN_BAN,QI_YUAN,PINGJUN_NL,YU_BI_DU,PINGJUN_SG,PINGJUN_XJ,HUO_LMGQXJ,GXFS,CFMJ,CFXJ,CFZS,CCLV,MIAN_JI,DI_LEI,GXDJ,BLMGQXJ,MEI_GQ_ZS,BLMGQZS,CFQD";
            //第一个报表在此出现为初始化异常：原因：没有加载指定图层

            m_dataList = pReportParamter.FindFromLayer_CF.Find(subFields, pReportParamter.BK, "Order by CUN");
        }

        /// <summary>
        /// 将查询到的数据写入虚拟Excel表中：此时还未真正导入Excel表的数据
        /// </summary>
        /// <returns></returns>
        public override DataTable FromMid2Table()
        {
            m_table = MakeTable();

            if (m_dataList.Count < 1)
            {

                return m_table;
            }

            string linban = "";
            string xiaoban = "";
            string linzhong = "";
            string shuzhong = "";
            string qiyaun = "";
            string linling = "";
            string gengxindengji = "";
            ////var cffs = m_dataList.Where(p => !string.IsNullOrWhiteSpace(p.CFFS));
            ////if (cffs.Count() < 1)
            ////{
            ////    return table;
            ////}

            //按县统计
            var xianGrp = m_dataList.GroupBy(p => p.XIAN);
            foreach (var xian in xianGrp)
            {
                string xianName = MDM.FindXiangName(xian.Key);

                //按乡统计
                var xiangGrps = xian.GroupBy(p => p.XIANG);
                foreach (var xg in xiangGrps)
                {
                    string xiangName = MDM.FindXiangName(xg.Key);

                    //按村统计
                    var cunGrps = xg.GroupBy(p => p.CUN);
                    foreach (var cGrp in cunGrps)
                    {
                        string cunName = MDM.FindCunName(cGrp.Key);

                        //按林班统计
                        var linbanGrps = cGrp.GroupBy(p => p.LIN_BAN);
                        if (linbanGrps.Count() < 1)
                        {
                            MakeRow(cGrp, xianName, xiangName, cunName, linban, xiaoban, linzhong, shuzhong, qiyaun, linling, gengxindengji);
                            return m_table;
                        }
                        foreach (var lbGrp in linbanGrps)
                        {
                            linban = MDM.FindName("LIN_BAN", lbGrp.Key);
                            if (lbGrp.Count() < 1)
                            {
                                return m_table;
                            }

                            //按小班统计
                            var xiaobanGrps = lbGrp.GroupBy(p => p.XIAO_BAN);
                            if (xiaobanGrps.Count() < 1)
                            {
                                MakeRow(cGrp, xianName, xiangName, cunName, linban, xiaoban, linzhong, shuzhong, qiyaun, linling, gengxindengji);
                                return m_table;
                            }
                            foreach (var xbGrp in xiaobanGrps)
                            {
                                xiaoban = MDM.FindName("XIAO_BAN", xbGrp.Key);
                                if (xbGrp.Count() < 1)
                                {
                                    return m_table;
                                }

                                //按林种统计
                                var linzhongGrp = xbGrp.GroupBy(p => p.LIN_ZHONG);

                                if (linzhongGrp.Count() < 1)
                                {
                                    MakeRow(cGrp, xianName, xiangName, cunName, linban, xiaoban, linzhong, shuzhong, qiyaun, linling, gengxindengji);
                                    return m_table;
                                }

                                foreach (var lzGrp in linzhongGrp)
                                {
                                    linzhong = MDM.FindName("LIN_ZHONG", lzGrp.Key);
                                    if (lzGrp.Count() < 1)
                                    {
                                        return m_table;
                                    }

                                    //按树种统计
                                    var shuzhongGrp = lzGrp.GroupBy(p => p.YOU_SHI_SZ);
                                    if (shuzhongGrp.Count() < 1)
                                    {
                                        MakeRow(cGrp, xianName, xiangName, cunName, linban, xiaoban, linzhong, shuzhong, qiyaun, linling, gengxindengji);
                                        return m_table;
                                    }
                                    foreach (var szGrp in shuzhongGrp)
                                    {
                                        shuzhong = MDM.FindName("YOU_SHI_SZ", szGrp.Key);
                                        if (szGrp.Count() < 1)
                                        {
                                            return m_table;
                                        }

                                        //按起源统计
                                        var qiyuanGrp = szGrp.GroupBy(p => p.QI_YUAN);
                                        if (qiyuanGrp.Count() < 1)
                                        {
                                            MakeRow(cGrp, xianName, xiangName, cunName, linban, xiaoban, linzhong, shuzhong, qiyaun, linling, gengxindengji);
                                            return m_table;
                                        }
                                        foreach (var qyGrp in qiyuanGrp)
                                        {
                                            qiyaun = MDM.FindName("QI_YUAN", qyGrp.Key);
                                            if (qyGrp.Count() < 1)
                                            {
                                                return m_table;
                                            }

                                            //按林龄统计
                                            var linlingGrp = qyGrp.GroupBy(p => p.PINGJUN_NL);
                                            if (linlingGrp.Count() < 1)
                                            {
                                                MakeRow(cGrp, xianName, xiangName, cunName, linban, xiaoban, linzhong, shuzhong, qiyaun, linling, gengxindengji);
                                                return m_table;
                                            }
                                            foreach (var llGrp in linlingGrp)
                                            {
                                                linling = MDM.FindName("PINGJUN_NL", qyGrp.Key);
                                                if (llGrp.Count() < 1)
                                                {
                                                    return m_table;
                                                }

                                                //按郁闭度统计
                                                var ybdGrp = llGrp.GroupBy(p => p.YU_BI_DU);
                                                if (ybdGrp.Count() < 1)
                                                {
                                                    MakeRow(cGrp, xianName, xiangName, cunName, linban, xiaoban, linzhong, shuzhong, qiyaun, linling, gengxindengji);
                                                    return m_table;
                                                }
                                                foreach (var ybd in ybdGrp)
                                                {
                                                    gengxindengji = MDM.FindName("YU_BI_DU", qyGrp.Key);
                                                    if (ybd.Count() < 1)
                                                    {
                                                        return m_table;
                                                    }

                                                    //按更新等级统计
                                                    var gxdjGrp = ybd.GroupBy(p => p.GXDJ);
                                                    if (gxdjGrp.Count() < 1)
                                                    {
                                                        MakeRow(cGrp, xianName, xiangName, cunName, linban, xiaoban, linzhong, shuzhong, qiyaun, linling, gengxindengji);
                                                        return m_table;
                                                    }
                                                    foreach (var gxdj in gxdjGrp)
                                                    {
                                                        gengxindengji = MDM.FindName("GXDJ", gxdj.Key);
                                                        MakeRow(cGrp, xianName, xiangName, cunName, linban, xiaoban, linzhong, shuzhong, qiyaun, linling, gengxindengji);
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return m_table;
        }

        private void MakeRow(IGrouping<string, ZT_CF_Mid> data, string xianName, string xiangName, string cunName, string linban, string xiaoban, string linzhong, string shuzhong, string qiyaun, string linling, string dengxingdengji)
        {
            DataRow row = m_table.NewRow();

            row["XIANG"] = xiangName;
            row["CUN"] = cunName;
            string linban_tq = linban.Substring(linban.LastIndexOf(":") + 1);
            row["LINB_BAN"] = linban_tq;
            string xiaoban_tq = xiaoban.Substring(xiaoban.LastIndexOf(":") + 1);
            row["XIAO_BAN"] = xiaoban_tq;
            string linzhong_tq = linzhong.Substring(linzhong.LastIndexOf(":") + 1);
            row["LIN_ZHONG"] = linzhong_tq;
            string shuzhong_tq = shuzhong.Substring(shuzhong.LastIndexOf(":") + 1);
            row["YOU_SHI_SZ"] = shuzhong_tq;
            string qiyaun_tq = qiyaun.Substring(qiyaun.LastIndexOf(":") + 1);
            row["QIYUAN"] = qiyaun_tq;

            double linling1 = data.Where(p => Convert.ToInt32(p.CFFS) == 12).Sum(p => p.PINGJUN_NL) + data.Where(p => Convert.ToInt32(p.CFFS) == 13).Sum(p => p.PINGJUN_NL);
            row["LINLING"] = linling1;
            double yubidu1 = data.Where(p => Convert.ToInt32(p.CFFS) == 12).Sum(p => p.YU_BI_DU) + data.Where(p => Convert.ToInt32(p.CFFS) == 13).Sum(p => p.YU_BI_DU); 
            row["YUBIDU"] = yubidu1;

            double pingjunzhijing = data.Where(p => Convert.ToInt32(p.CFFS) == 12).Sum(p => p.PINGJUN_XJ) + data.Where(p => Convert.ToInt32(p.CFFS) == 13).Sum(p => p.PINGJUN_XJ);
            row["PJZHIJING"] = pingjunzhijing;
            double pingjunshugao = data.Where(p => Convert.ToInt32(p.CFFS) == 12).Sum(p => p.PINGJUN_SG) + data.Where(p => Convert.ToInt32(p.CFFS) == 13).Sum(p => p.PINGJUN_SG);
            row["PJSHUGAO"] = pingjunshugao;

            string dengxingdengji_tq = dengxingdengji.Substring(dengxingdengji.LastIndexOf(":") + 1);
            row["TRGXDJ"] = dengxingdengji_tq;

            double mgqxjcf = data.Where(p => Convert.ToInt32(p.CFFS) == 12).Sum(p => p.HUO_LMGQXJ)+ data.Where(p => Convert.ToInt32(p.CFFS) == 13).Sum(p => p.HUO_LMGQXJ);
            row["MGQXJCF"] = mgqxjcf;
            double mgqxjbl = data.Where(p => Convert.ToInt32(p.CFFS) == 12).Sum(p => p.BLMGQXJ) + data.Where(p => Convert.ToInt32(p.CFFS) == 13).Sum(p => p.BLMGQXJ);
            row["MGQXJBL"] = mgqxjbl;
            double mgqzscf = data.Where(p => Convert.ToInt32(p.CFFS) == 12).Sum(p => p.MEI_GQ_ZS) + data.Where(p => Convert.ToInt32(p.CFFS) == 13).Sum(p => p.MEI_GQ_ZS);
            row["MGQZSCF"] = mgqzscf;
            double mgqzsbl = data.Where(p => Convert.ToInt32(p.CFFS) == 12).Sum(p => p.BLMGQZS) + data.Where(p => Convert.ToInt32(p.CFFS) == 13).Sum(p => p.BLMGQZS);
            row["MGQZSBL"] = mgqzsbl;

            double cfqdxj = data.Where(p => Convert.ToInt32(p.CFFS) == 12).Sum(p => p.CFQD) + data.Where(p => Convert.ToInt32(p.CFFS) == 13).Sum(p => p.CFQD);
            row["CFQDXJ"] = cfqdxj;
            row["CFQDZS"] = cfqdxj;
            double cfmj = data.Where(p => Convert.ToInt32(p.CFFS) == 12).Sum(p => p.CFMJ) + data.Where(p => Convert.ToInt32(p.CFFS) == 13).Sum(p => p.CFMJ);
            row["CFMJ"] = cfmj;
            double cfxj = data.Where(p => Convert.ToInt32(p.CFFS) == 12).Sum(p => p.CFXJ) + data.Where(p => Convert.ToInt32(p.CFFS) == 13).Sum(p => p.CFXJ);
            row["CFXJ"] = cfxj;
            double cfzs = data.Where(p => Convert.ToInt32(p.CFFS) == 12).Sum(p => p.CFZS) + data.Where(p => Convert.ToInt32(p.CFFS) == 13).Sum(p => p.CFZS);
            row["CFZS"] = cfzs;
            double cfcc = data.Where(p => Convert.ToInt32(p.CFFS) == 12).Sum(p => p.CCLV) + data.Where(p => Convert.ToInt32(p.CFFS) == 13).Sum(p => p.CCLV);
            row["CFCC"] = cfcc;

            m_table.Rows.Add(row);
        }

        /// <summary>
        /// 操作并生成各行数据
        /// </summary>
        /// <param name="cGrp"></param>
        /// <param name="xianName"></param>
        /// <param name="xiangName"></param>
        /// <param name="cunName"></param>
        private void MakeRow(IEnumerable<FOR_XIAOBAN_Mid> data, string xianName, string xiangName, string cunName)
        {

        }

        /// <summary>
        /// 根据需要重写父类的表。
        /// </summary>
        /// <returns></returns>
        protected override DataTable MakeTable()
        {
            DataTable table = new DataTable("ResultTable");

            table.Columns.Add("XIANG", typeof(string));

            table.Columns.Add("CUN", typeof(string));

            table.Columns.Add("LINB_BAN", typeof(string));

            table.Columns.Add("XIAO_BAN", typeof(string));

            table.Columns.Add("LIN_ZHONG", typeof(string));

            table.Columns.Add("YOU_SHI_SZ", typeof(string));

            table.Columns.Add("QIYUAN", typeof(string));

            table.Columns.Add("LINLING", typeof(double));

            table.Columns.Add("YUBIDU", typeof(double));

            table.Columns.Add("PJZHIJING", typeof(double));

            table.Columns.Add("PJSHUGAO", typeof(double));

            table.Columns.Add("TRGXDJ", typeof(string));

            table.Columns.Add("MGQXJCF", typeof(double));

            table.Columns.Add("MGQXJBL", typeof(double));

            table.Columns.Add("MGQZSCF", typeof(double));

            table.Columns.Add("MGQZSBL", typeof(double));

            table.Columns.Add("CFQDXJ", typeof(double));

            table.Columns.Add("CFQDZS", typeof(double));

            table.Columns.Add("CFMJ", typeof(double));
            table.Columns.Add("CFXJ", typeof(double));
            table.Columns.Add("CFZS", typeof(double));
            table.Columns.Add("CFCC", typeof(double));

            m_table = table;
            return table;
        }


        public IEnumerable<object> ybdGrp { get; set; }
    }
}
