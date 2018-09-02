using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using td.db.mid.forest;
using td.db.orm;
using td.logic.sys;
using LDZY_ZTZZ.tj;

namespace td.forest.ldzy.tj
{
    /// <summary>
    /// 征占用的底层类
    /// </summary>
    public class ZDZYTJBase
    {

        protected int m_digits = 2;
        protected MetaDataManager MDM
        {
            get
            {
                return DBServiceFactory<MetaDataManager>.Service;
            }
        }
        public virtual DataTable GetTableByXianXiangCun(List<ZT_LDZZ_2016_Mid> xbLst)
        {
            return null;
        }

        public virtual System.Data.DataTable FromMid2Table()
        {

            return null;
        }

        /// <summary>
        /// 计算县乡的底层类
        /// </summary>
        /// <param name="lst"></param>
        /// <returns></returns>
        public virtual DataTable ComputeXianXiang(IEnumerable<ZT_LDZZ_2016_Mid> lst)
        {
            string xian = "";
            string xiang = "";
            string cun = "";
            string xiaobanhao = "";
            string xiban = "";
            string tuquanshu = "";
            string qiyuan = "";
            string linzhong = "";
            string linmuquanshu = "";
            string shuzhong = "";
            string lindileixing = "";
            string beizhu = "";

            DataTable resultTable = this.MakeTable();

            //因为没有造林类别为112，因此直接返回
            if (lst.Count() < 1) return resultTable;

            //按县统计
            var xianGrps = lst.GroupBy(p => p.XIAN);
            foreach (var x in xianGrps)
            {
                xian = MDM.FindXianName(x.Key);

                //按乡统计
                var xiangGrps = x.GroupBy(p => p.XIANG);
                ////MakeRow(lst, lst.First().XIAN, lst, tuquanshu, qiyuan, linzhong, shuzhong, lindileixing, linmuquanshu, beizhu);
                foreach (var xiagrp in xiangGrps)
                {
                    xiang = MDM.FindXiangName(xiagrp.Key);

                    //按村统计
                    var cunGrp = xiagrp.GroupBy(p => p.CUN);
                    foreach (var cGrp in cunGrp)
                    {
                        cun = MDM.FindCunName(cGrp.Key);

                        //按土地权属统计
                        var tdqsGrps = cGrp.GroupBy(p => p.LD_QS);
                        foreach (var tdqs in tdqsGrps)
                        {
                            tuquanshu = MDM.FindName("LD_QS", tdqs.Key);

                            //按小班号统计
                            var xiaobanGrps = tdqs.GroupBy(p => p.XIAO_BAN);
                            foreach (var xbh in xiaobanGrps)
                            {
                                xiaobanhao = MDM.FindName("XIAO_BAN", xbh.Key);

                                //按细斑统计
                                var xibanGrps = xbh.GroupBy(p => p.XI_BAN);
                                foreach (var xb in xibanGrps)
                                {
                                    xiban = MDM.FindName("XI_BAN", xb.Key);

                                    //按起源统计
                                    var qyGrps = xb.GroupBy(p => p.QI_YUAN);
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
                                            foreach (var ldlx in ldlxGrps)
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

                                                        //按备注统计
                                                        var bzGrps = sz.GroupBy(p => p.BZ);
                                                        foreach (var bz in bzGrps)
                                                        {
                                                            beizhu = MDM.FindName("BZ", bz.Key);
                                                            //test：此处将lst改为x。查看效果
                                                            //将第二个参数lst.First().CUN改为cun。因为源代码只能返回第一个村庄
                                                            MakeRow(x, cun, xiban,tuquanshu, qiyuan, linzhong, shuzhong, lindileixing, linmuquanshu, beizhu);
                                                            string c = cun;
                                                            string s = MDM.FindXQName(lst.First().CUN);
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
            ///下句代码有毛病。如果加入此转换，数据就只剩下第一列数据了。
            ////resultTable = this.ConvertTableFldValueZeroToNull(resultTable, 1);
            return resultTable;
        }

        protected virtual DataTable MakeTable()
        {
            return null;
        }

        protected virtual void MakeRow(IEnumerable<ZT_LDZZ_2016_Mid> lst1, string key,string xiban, string tudiquanshu, string s1, string s2, string s3, string s4, string s5, string s6)
        {

        }

        public object[,] Compute2ObjAry(DataTable table)
        {
            object[,] objArray = null;
            if ((table != null) && (table.Rows.Count > 0))
            {

                objArray = new object[table.Rows.Count, table.Columns.Count];
                for (int row = 0; row < table.Rows.Count; row++)
                {
                    for (int col = 0; col < table.Columns.Count; col++)
                    {
                        objArray[row, col] = table.Rows[row][col];
                    }
                }
                table = null;
            }
            return objArray;
        }


        protected DataTable ConvertTableFldValueZeroToNull(DataTable ResultTable, int startcolnum)
        {
            for (int i = 0; i < ResultTable.Rows.Count; i++)
            {
                for (int j = startcolnum; j < ResultTable.Columns.Count; j++)
                {
                    string str = ResultTable.Rows[i][j].ToString().Trim();
                    ResultTable.Rows[i][j] = DBNull.Value;
                    ////if ((str.Length > 0) && (Convert.ToDouble(str) == 0.0))
                    ////{
                    ////    ResultTable.Rows[i][j] = DBNull.Value;
                    ////}
                }
            }
            return ResultTable;
        }
    }
}
