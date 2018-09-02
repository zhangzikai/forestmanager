using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using td.db.orm;
using td.logic.sys;
using td.forest.ldzy.tj;
using td.db.mid.forest;

namespace LDZY_ZTZZ.tj
{
    public class B7 : ZDZYTJBase
    {
        private DataTable m_table;

        public B7()
        {
        }

        /// <summary>
        /// 返回计算的县乡
        /// </summary>
        /// <param name="lst"></param>
        /// <returns></returns>
        public override DataTable ComputeXianXiang(IEnumerable<ZT_LDZZ_2016_Mid> lst)
        {
            string xian = "";
            string xiang = "";
            string cun = "";
            string xiban = "";
            string linbanhao = "";
            string jingyinban = "";
            string xiaobanhao = "";
            string tudizhonglei = "";
            string senlinleibie = "";
            string shiquandengji = "";
            string quyuleixing = "";
           
            string lindigongnengfenqu = "";
            string lindibaohudengji = "";
            string lindizhiliangdengji = "";
            string tudiquanshu = "";
            string qiyuan = "";
            string linzhong = "";
            string linmuquanshu = "";
            string shuzhong = "";
            string lindileixing = "";
            string beizhu = "";
            string zhutigongnengqu="";
            DataTable resultTable = this.MakeTable();

            //因为没有造林类别为112，因此直接返回
            if (lst.Count() < 1) return resultTable;

            var xiangGrps = lst.GroupBy(p => p.XIANG);
            ////MakeRow(lst, resultTable, lst.First().XIAN, xian,xiang,cun,linbanhao,jingyinban,xiaobanhao,tudiquanshu, linmuquanshu, lindileixing,tudizhonglei, linzhong, shuzhong, senlinleibie, shiquandengji, beizhu,quyuleixing,zhutigongnengqu,lindigongnengfenqu,lindibaohudengji,lindizhiliangdengji);

            //按县统计
            var xianGrps = lst.GroupBy(p => p.XIAN);
            foreach (var xGrp in xianGrps)
            {
                xian = MDM.FindXianName(xGrp.Key);

                //按乡统计
                var xiGrps = xGrp.GroupBy(p => p.XIANG);
                foreach (var grp in xiGrps)
                {
                    xiang = MDM.FindXiangName(grp.Key);

                    //按村统计
                    var cunGrp = grp.GroupBy(p => p.CUN);
                    foreach (var cGrp in cunGrp)
                    {
                        cun = MDM.FindCunName(cGrp.Key);

                        //按林班号统计
                        var linbanGrps = cGrp.GroupBy(p => p.LIN_BAN);
                        foreach (var lb in linbanGrps)
                        {
                            linbanhao = MDM.FindName("LIN_BAN", lb.Key);

                            //按小班号统计
                            var xbGrps = lb.GroupBy(p => p.XIAO_BAN);
                            foreach (var xbh in xbGrps)
                            {
                                xiaobanhao = MDM.FindName("XIAO_BAN", xbh.Key);

                                //按细斑统计
                                var xibanGrps = xbh.GroupBy(p=>p.XI_BAN);
                                foreach (var xb in xibanGrps)
                                {
                                    xiban = MDM.FindName("XI_BAN", xb.Key);    
                                

                                //按土地权属统计
                                    var tdqsGrps = xb.GroupBy(p => p.LD_QS);                              
                                foreach (var tdqs in tdqsGrps)
                                {
                                    tudiquanshu = MDM.FindName("LD_QS", tdqs.Key);

                                    //按起源统计
                                    var qyGrps = tdqs.GroupBy(p => p.QI_YUAN);                                   
                                    foreach (var qy in qyGrps)
                                    {
                                        qiyuan = MDM.FindName("QI_YUAN", qy.Key);

                                        //按林种统计
                                        var lzGrps = qy.GroupBy(p => p.LIN_ZHONG);                                     
                                        foreach (var lz in lzGrps)
                                        {
                                            linzhong = MDM.FindName("LIN_ZHONG", lz.Key);

                                            //按林地类型统计
                                            var ldlxGrps = lz.GroupBy(p => p.LDLX);                                        
                                            foreach (var ldlx in lzGrps)
                                            {
                                                lindileixing = MDM.FindName("LDLX", ldlx.Key);

                                                //按林木权属统计
                                                var lmqsGrps = ldlx.GroupBy(p => p.LMSYQ);                                              
                                                foreach (var lmqs in lmqsGrps)
                                                {
                                                    linmuquanshu = MDM.FindName("LMSYQ", lmqs.Key);

                                                    //按优势树种统计
                                                    var szGrps = lmqs.GroupBy(p => p.YOU_SHI_SZ);                                                  
                                                    foreach (var sz in szGrps)
                                                    {
                                                        shuzhong = MDM.FindName("YOU_SHI_SZ", sz.Key);

                                                        //按森林类别统计
                                                        var sllbGrps = sz.GroupBy(p => p.SEN_LIN_LB);
                                                        foreach (var sllb in sllbGrps)
                                                        {
                                                            senlinleibie = MDM.FindName("SEN_LIN_LB", sllb.Key);

                                                            //按事权等级统计
                                                            var sqdjGrps = sllb.GroupBy(p => p.SHI_QUAN_D);
                                                            foreach (var sqdj in sqdjGrps)
                                                            {
                                                                shiquandengji = MDM.FindName("SHI_QUAN_D", sqdj.Key);

                                                                //按主体功能开发区统计
                                                                var ztgnqGrps = sqdj.GroupBy(p => p.QYKZ);
                                                                foreach (var ztgnq in ztgnqGrps)
                                                                {
                                                                    zhutigongnengqu = MDM.FindName("QYKZ", ztgnq.Key);

                                                                    //按林地功能分区统计
                                                                    var ldgnfqGrps = ztgnq.GroupBy(p => p.LYFQ);
                                                                    foreach (var ldgnfq in ldgnfqGrps)
                                                                    {
                                                                        lindigongnengfenqu = MDM.FindName("LYFQ", ldgnfq.Key);

                                                                        //按林地保护等级统计
                                                                        var ldbhdjGrps = ldgnfq.GroupBy(p => p.BH_DJ);
                                                                        foreach (var ldbhdj in ldbhdjGrps)
                                                                        {
                                                                            lindibaohudengji = MDM.FindName("BH_DJ", ldbhdj.Key);

                                                                            //按林地质量等级统计
                                                                            var ldzldjGrps = ldbhdj.GroupBy(p => p.ZL_DJ);
                                                                            foreach (var ldzldj in ldzldjGrps)
                                                                            {
                                                                                lindizhiliangdengji = MDM.FindName("ZL_DJ", ldzldj.Key);

                                                                                //按备注统计
                                                                                var bzGrps = ldzldj.GroupBy(p => p.BZ);
                                                                                foreach (var bz in bzGrps)
                                                                                {
                                                                                    beizhu = MDM.FindName("BZ", bz.Key);
                                                                                    MakeRow(lst, lst.First().CUN, xian, xiang, cun, xiban,linbanhao, jingyinban, xiaobanhao, tudiquanshu, linmuquanshu, lindileixing, tudizhonglei, linzhong, shuzhong, senlinleibie, shiquandengji, beizhu, quyuleixing, zhutigongnengqu, lindigongnengfenqu, lindibaohudengji, lindizhiliangdengji);
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
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            if (resultTable.Rows.Count <= 0)
            {
                return resultTable;
            }

            ////resultTable = this.ConvertTableFldValueZeroToNull(resultTable, 1);
            return resultTable;
        }


        protected void MakeRow(IEnumerable<ZT_LDZZ_2016_Mid> data, string key, string xian, string xiang, string cun, string xiban, string linbanhao, string jingyinban, string xiaobanhao, string tudiquanshu, string linmuquanshu, string lindileixing, string tudizhonglei, string linzhong, string shuzhong, string senlinleibie, string shiquandengji, string beizhu, string quyuleixing, string zhutigongnengqu, string lindigongnengfenqu, string lindibaohudengji, string lindizhiliangdengji)
        {

            double num2 = 0.0;
            double num3 = 0.0;
            string xiabn_tq = xiban.Substring(xiban.LastIndexOf(":") + 1);

            num2 = data.Where(p => p.XI_BAN == xiabn_tq).Sum(p => p.MIAN_JI);
            num3 = data.Where(p => p.XI_BAN == xiabn_tq).Sum(p => p.SLXJ);


            DataRow row3 = m_table.NewRow();
            row3["XIAN"] = xian;
            row3["XIANG"] = xiang;
            row3["CUN"] = cun;
            string linbanhao_tq = linbanhao.Substring(linbanhao.LastIndexOf(":") + 1);
            row3["LINBAN"] = linbanhao_tq;
            string jingyinban_tq = jingyinban.Substring(jingyinban.LastIndexOf(":") + 1);
            row3["JINGYINGBAN"] = jingyinban_tq;
            string xiaobanhao_tq = xiaobanhao.Substring(xiaobanhao.LastIndexOf(":") + 1);
            row3["XIAOBAN"] = xiaobanhao_tq;
            string tudiquanshu_tq = tudiquanshu.Substring(tudiquanshu.LastIndexOf(":") + 1);
            row3["LDQS"] = tudiquanshu_tq;
            string linmuquanshu_tq = linmuquanshu.Substring(linmuquanshu.LastIndexOf(":") + 1);
            row3["LMQS"] = linmuquanshu_tq;
            string lindileixing_tq = lindileixing.Substring(lindileixing.LastIndexOf(":") + 1);
            row3["LDLX"] = lindileixing_tq;
            string tudizhonglei_tq = tudizhonglei.Substring(tudizhonglei.LastIndexOf(":") + 1);
            row3["TDZL"] = tudizhonglei_tq;
            string linzhong_tq = linzhong.Substring(linzhong.LastIndexOf(":") + 1);
            row3["LZ"] = linzhong_tq;
            string shuzhong_tq = shuzhong.Substring(shuzhong.LastIndexOf(":") + 1);
            row3["YSSZ"] = shuzhong_tq;
            row3["MJ"] = num2;
            row3["XJ"] = num3;
            string senlinleibie_tq = senlinleibie.Substring(senlinleibie.LastIndexOf(":") + 1);
            row3["SLLB"] = senlinleibie_tq;
            string shiquandengji_tq = shiquandengji.Substring(shiquandengji.LastIndexOf(":") + 1);
            row3["SQJ"] = shiquandengji_tq;
            string beizhu_tq = beizhu.Substring(beizhu.LastIndexOf(":") + 1);
            row3["BZ"] = beizhu_tq;
            string quyuleixing_tq = quyuleixing.Substring(quyuleixing.LastIndexOf(":") + 1);
            row3["QYLX"] = quyuleixing_tq;
            string zhutigongnengqu_tq = zhutigongnengqu.Substring(zhutigongnengqu.LastIndexOf(":") + 1);
            row3["ZTGNQ"] = zhutigongnengqu_tq;
            string lindigongnengfenqu_tq = lindigongnengfenqu.Substring(lindigongnengfenqu.LastIndexOf(":") + 1);
            row3["LDGNFQ"] = lindigongnengfenqu_tq;
            string lindibaohudengji_tq = lindibaohudengji.Substring(lindibaohudengji.LastIndexOf(":") + 1);
            row3["LDBHDJ"] = lindibaohudengji_tq;
            string lindizhiliangdengji_tq = lindizhiliangdengji.Substring(lindizhiliangdengji.LastIndexOf(":") + 1);
            row3["LDZLDJ"] = lindizhiliangdengji_tq;

            m_table.Rows.Add(row3);
        }

        protected override DataTable MakeTable()
        {
            System.Data.DataTable table = new System.Data.DataTable("ResultTable");
            DataColumn column = new DataColumn("XIAN", typeof(string));
            table.Columns.Add(column);
            column = new DataColumn("XIANG", typeof(string));
            table.Columns.Add(column);
            column = new DataColumn("CUN", typeof(string));
            table.Columns.Add(column);
            column = new DataColumn("LINBAN", typeof(string));
            table.Columns.Add(column);
            column = new DataColumn("JINGYINGBAN", typeof(string));
            table.Columns.Add(column);
            column = new DataColumn("XIAOBAN", typeof(string));
            table.Columns.Add(column);
            column = new DataColumn("LDQS", typeof(string));
            table.Columns.Add(column);
            column = new DataColumn("LMQS", typeof(string));
            table.Columns.Add(column);
            column = new DataColumn("LDLX", typeof(string));
            table.Columns.Add(column);
            column = new DataColumn("TDZL", typeof(string));
            table.Columns.Add(column);
            column = new DataColumn("LZ", typeof(string));
            table.Columns.Add(column);
            column = new DataColumn("YSSZ", typeof(string));
            table.Columns.Add(column);
            column = new DataColumn("MJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("XJ", typeof(double));
            table.Columns.Add(column);
            column = new DataColumn("SLLB", typeof(string));
            table.Columns.Add(column);
            column = new DataColumn("SQJ", typeof(string));
            table.Columns.Add(column);
            column = new DataColumn("BZ", typeof(string));
            table.Columns.Add(column);
            column = new DataColumn("QYLX", typeof(string));
            table.Columns.Add(column);
            column = new DataColumn("ZTGNQ", typeof(string));
            table.Columns.Add(column);
            column = new DataColumn("LDGNFQ", typeof(string));
            table.Columns.Add(column);
            column = new DataColumn("LDBHDJ", typeof(string));
            table.Columns.Add(column);
            column = new DataColumn("LDZLDJ", typeof(string));
            table.Columns.Add(column);
            m_table = table;
            return table;
        }
    }
}
