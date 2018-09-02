namespace Cf_Calc
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Windows.Forms;
    using Utilities;

    public static class CfCalc_mmjc
    {
        private static JJCJ_RenderCollection _Cj_Collection = new JJCJ_RenderCollection();
        private static string _Cun = "";
        private static string _dcxb = "";
        private static DataTable _dtDatas = null;
        private static string _Lin_Ban = "";
        private static string _zyxb = "";
     
        private const string TableName = "T_ZT_CF_MMJC";

        private static void Calc_Ccl(IDbConnection pConn, IDbTransaction pTran)
        {
            foreach (DataRow row in _dtDatas.Rows)
            {
                string thsz = "";
                string jcsz = "";
                object obj2 = row["出材树种名称"];
                if (!Convert.IsDBNull(obj2))
                {
                    thsz = obj2.ToString().Replace(" ", "");
                }
                obj2 = row["检尺树种"];
                if (!Convert.IsDBNull(obj2))
                {
                    jcsz = obj2.ToString().Replace(" ", "");
                }
                thsz = sz_PreDeal(jcsz, thsz);
                if (!string.IsNullOrEmpty(thsz))
                {
                    if (thsz == "一般桉")
                    {
                        thsz = "桉树";
                    }
                    int result = 0;
                    double num2 = 0.0;
                    double num3 = 0.0;
                    int.TryParse(row["径阶"].ToString(), out result);
                    object[] objArray = null;
                  
                        objArray = GetSqlFiledValues(pConn, pTran, "T_ZT_CF_CCLB", new string[] { "HJ", "DX" }, "replace(SZ, ' ', '') = '" + thsz.Replace(" ", "") + "' and JJ = " + result.ToString());
                    
                    if (objArray != null)
                    {
                        row["规格材出材率"] = objArray[0];
                        row["小材出材率"] = objArray[1];
                        double.TryParse(row["用材蓄积"].ToString(), out num2);
                        double.TryParse(row["半用材蓄积"].ToString(), out num3);
                        double num4 = num2 + (num3 * 0.5);
                        double num5 = 0.0;
                        double.TryParse(objArray[0].ToString(), out num5);
                        if (!(num5 == 0.0))
                        {
                            row["规格材出材量"] = Math.Round((double) ((num4 * num5) / 100.0), 4);
                        }
                        else
                        {
                            row["规格材出材量"] = 0;
                        }
                        num5 = 0.0;
                        double.TryParse(objArray[1].ToString(), out num5);
                        if (!(num5 == 0.0))
                        {
                            row["小材出材量"] = Math.Round((double) ((num4 * num5) / 100.0), 4);
                        }
                        else
                        {
                            row["小材出材量"] = 0;
                        }
                    }
                }
            }
        }

        private static void Calc_Cj()
        {
            foreach (DataRow row in _dtDatas.Rows)
            {
                double result = 0.0;
                double num2 = 0.0;
                string thsz = "";
                string jcsz = "";
                object obj2 = row["材积树种名称"];
                if (!Convert.IsDBNull(obj2))
                {
                    thsz = obj2.ToString().Replace(" ", "");
                }
                obj2 = row["检尺树种"];
                if (!Convert.IsDBNull(obj2))
                {
                    jcsz = obj2.ToString().Replace(" ", "");
                }
                obj2 = row["平均直径"];
                double.TryParse(obj2.ToString(), out result);
                double.TryParse(row["平均高"].ToString(), out num2);
                thsz = sz_PreDeal(jcsz, thsz);
                if (!string.IsNullOrEmpty(thsz))
                {
                    if ((thsz == "一般桉") || (thsz == "桉树"))
                    {
                        int num3 = 0;
                        int.TryParse(row["径阶"].ToString(), out num3);
                        if (num3 <= 8)
                        {
                            thsz = "桉树1";
                        }
                        else
                        {
                            thsz = "桉树2";
                        }
                    }
                    JJCJ_Render render = _Cj_Collection[thsz];
                    if (render != null)
                    {
                        row["材积"] = Math.Round(render.Calc(result, num2), 4);
                    }
                }
            }
        }

        private static void Calc_Dmj()
        {
            foreach (DataRow row in _dtDatas.Rows)
            {
                int result = 0;
                int.TryParse(row["径阶"].ToString(), out result);
                int num2 = 0;
                int.TryParse(row["株数合计"].ToString(), out num2);
                if ((result != 0) && (num2 != 0))
                {
                    row["断面积"] = Math.Round((double) (((3.14159 * Math.Pow((double) result, 2.0)) / 40000.0) * num2), 4);
                }
                else
                {
                    row["断面积"] = 0;
                }
            }
        }

        public static bool Calc_jcsj(string cun, string lb, string dcxb, string zyxb)
        {
            if (string.IsNullOrEmpty(cun))
            {
                MessageBox.Show("村号不能为空", "提示", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return false;
            }
            if (string.IsNullOrEmpty(lb))
            {
                MessageBox.Show("林班号不能为空", "提示", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return false;
            }
            if (string.IsNullOrEmpty(dcxb))
            {
                MessageBox.Show("调查小班号不能为空", "提示", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return false;
            }
            if (string.IsNullOrEmpty(zyxb))
            {
                MessageBox.Show("作业小班号不能为空", "提示", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return false;
            }
            _Cun = cun;
            _Lin_Ban = lb;
            _dcxb = dcxb;
            _zyxb = zyxb;
            bool flag = false;
            try
            {
                //IDBAccess dBAccess = UtilFactory.GetDBAccess(UtilFactory.GetConfigOpt().GetConfigValue2("DataBase", "DBKey"));
                //if (dBAccess == null)
                //{
                //    MessageBox.Show("数据库连接无效！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                //    return false;
                //}
                //m_DBAccess = dBAccess;
                //IDbConnection pConn = m_DBAccess.Connection;
                //if (pConn.State != ConnectionState.Open)
                //{
                //    pConn.Open();
                //}
               // IDbTransaction tran = pConn.BeginTransaction();
                try
                {
                    string str4;
                    List<string> list = new List<string>();
                    string str2 = "T_ZT_CF_MMJC";
                    str2 = ((((str2 + " as mmjc where CUN = '") + _Cun + "' and LIN_BAN = '") + _Lin_Ban + "' and DCXB = '") + _dcxb + "' and ZYXB = '") + _zyxb + "'";
                    string sCmdText = "select distinct JCLX as 检尺类型 from ";
                    sCmdText = sCmdText + str2;
                    IDbCommand dBCommand = null;// dBAccess.GetDBCommand(pConn, sCmdText);
                   // dBCommand.Transaction = tran;
                    IDataReader reader = dBCommand.ExecuteReader();
                    while (reader.Read())
                    {
                        str4 = reader.GetValue(0).ToString();
                        if (!string.IsNullOrEmpty(str4))
                        {
                            list.Add(str4);
                        }
                    }
                    reader.Close();
                    List<string> list2 = new List<string>();
                    foreach (string str5 in list)
                    {
                        sCmdText = "select distinct JCSZ as 检尺类型 from ";
                        sCmdText = (sCmdText + str2 + " and JCLX = '") + str5 + "'";
                        list2.Clear();
                        dBCommand.CommandText = sCmdText;
                        reader = dBCommand.ExecuteReader();
                        while (reader.Read())
                        {
                            str4 = reader.GetValue(0).ToString();
                            if (!string.IsNullOrEmpty(str4))
                            {
                                list2.Add(str4);
                            }
                        }
                        reader.Close();
                        foreach (string str6 in list2)
                        {
                        //    GetDataTable(pConn, tran, str5, str6);
                            if ((_dtDatas != null) && (_dtDatas.Rows.Count > 0))
                            {
                                Calc_Zshj();
                                Calc_Dmj();
                                Calc_Pjd();
                                Calc_Pjg();
                                Calc_Cj();
                                Calc_Xj();
                            //    Calc_Ccl(pConn, tran);
                             //   UpdateDatas(pConn, tran);
                            }
                        }
                    }
                 //   tran.Commit();
                    flag = true;
                }
                catch (Exception exception)
                {
                  //  tran.Rollback();
                    MessageBox.Show("计算作业小班中间数据时发生错误:" + exception.Message, "CfCalc::Calc_jcsj", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                 //   pConn.Close();
                    return false;
                }
            //    pConn.Close();
            }
            catch (Exception exception2)
            {
                MessageBox.Show("计算作业小班中间数据时发生错误:" + exception2.Message, "CfCalc::Calc_jcsj", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return false;
            }
            return flag;
        }

        private static void Calc_Pjd()
        {
            foreach (DataRow row in _dtDatas.Rows)
            {
                row["平均直径"] = row["径阶"];
            }
        }

        private static void Calc_Pjg()
        {
            DataTable table = new DataTable();
            table.Columns.Add("D");
            table.Columns.Add("H");
            string[] strArray = new string[] { "胸径1", "胸径2", "胸径3" };
            string[] strArray2 = new string[] { "树高1", "树高2", "树高3" };
            double result = 0.0;
            double num2 = 0.0;
            foreach (DataRow row in _dtDatas.Rows)
            {
                int num3 = 0;
                foreach (string str in strArray)
                {
                    object obj2 = row[str];
                    object obj3 = row[strArray2[num3++]];
                    double.TryParse(obj2.ToString(), out result);
                    double.TryParse(obj3.ToString(), out num2);
                    if ((result > 0.0) || (num2 > 0.0))
                    {
                        DataRow row2 = table.NewRow();
                        row2["D"] = result;
                        row2["H"] = num2;
                        table.Rows.Add(row2);
                    }
                }
            }
            double count = table.Rows.Count;
            if (count < 20.0)
            {
                Calc_Pjg_xy20();
            }
            else
            {
                double num5 = 0.0;
                double num6 = 0.0;
                double num7 = 0.0;
                double num8 = 0.0;
                double num9 = 0.0;
                for (int i = 0; i < count; i++)
                {
                    double num11 = 0.0;
                    object obj4 = table.Rows[i]["H"];
                    double.TryParse(obj4.ToString(), out num11);
                    double num12 = 0.0;
                    obj4 = table.Rows[i]["D"];
                    double.TryParse(obj4.ToString(), out num12);
                    double num13 = num11;
                    double num14 = num12 * num12;
                    num6 += num14;
                    num5 += num13;
                    num8 += num14 * num14;
                    num7 += num13 * num13;
                    num9 += num14 * num13;
                }
                double num15 = num8 - ((num6 * num6) / count);
                double num16 = num7 - ((num5 * num5) / count);
                double num17 = num9 - ((num6 * num5) / count);
                double num18 = num17 / num15;
                double num19 = (num5 / count) - ((num18 * num6) / count);
                foreach (DataRow row in _dtDatas.Rows)
                {
                    int num20 = 0;
                    int.TryParse(row["径阶"].ToString(), out num20);
                    double num21 = 0.0;
                    if (num20 != 0)
                    {
                        num21 = num19 + (num18 * Math.Pow((double) num20, 2.0));
                    }
                    row["平均高"] = Math.Round(num21, 1);
                }
            }
        }

        private static void Calc_Pjg_xy20()
        {
            foreach (DataRow row in _dtDatas.Rows)
            {
                int num = 0;
                double result = 0.0;
                double num3 = 0.0;
                double num4 = 0.0;
                double num5 = 0.0;
                object obj2 = row["树高1"];
                double.TryParse(obj2.ToString(), out result);
                if (result > 0.0)
                {
                    num++;
                }
                obj2 = row["树高2"];
                double.TryParse(obj2.ToString(), out num3);
                if (num3 > 0.0)
                {
                    num++;
                }
                double.TryParse(row["树高3"].ToString(), out num4);
                if (num4 > 0.0)
                {
                    num++;
                }
                num5 = (result + num3) + num4;
                if ((num > 0) && (num5 > 0.0))
                {
                    row["平均高"] = Math.Round((double) (num5 / ((double) num)), 1);
                }
                else
                {
                    row["平均高"] = 0;
                }
            }
        }

        private static void Calc_Xj()
        {
            foreach (DataRow row in _dtDatas.Rows)
            {
                int result = 0;
                double num2 = 0.0;
                string[] strArray = new string[] { "用材株数", "半用材株数", "薪材株数" };
                string[] strArray2 = new string[] { "用材蓄积", "半用材蓄积", "薪材蓄积" };
                int num3 = 0;
                double.TryParse(row["材积"].ToString(), out num2);
                foreach (string str in strArray)
                {
                    int.TryParse(row[str].ToString(), out result);
                    row[strArray2[num3++]] = Math.Round((double) (result * num2), 4);
                }
            }
        }

        private static void Calc_Zshj()
        {
            foreach (DataRow row in _dtDatas.Rows)
            {
                int result = 0;
                int num2 = 0;
                int num3 = 0;
                object obj2 = row["用材株数"];
                if (!Convert.IsDBNull(obj2))
                {
                    int.TryParse(obj2.ToString(), out result);
                }
                obj2 = row["半用材株数"];
                if (!Convert.IsDBNull(obj2))
                {
                    int.TryParse(obj2.ToString(), out num2);
                }
                obj2 = row["薪材株数"];
                if (!Convert.IsDBNull(obj2))
                {
                    int.TryParse(obj2.ToString(), out num3);
                }
                row["株数合计"] = (result + num2) + num3;
            }
        }

        private static void GetDataTable(IDbConnection con, IDbTransaction tran, string jclx, string jcsz)
        {
            string sCmdText = "select BZDH as 标准地号, BZDMJ as 标准地面积, JCSZ as 检尺树种, (select CJSZ from T_ZT_CF_SZ_JC_TO_CZ as jtz where jtz.JCSZ = (select CNAME from T_SYS_META_CODE where CCODE = mmjc.JCSZ and CTYPE = '树种' )) as 材积树种名称, (select CCSZ from T_ZT_CF_SZ_JC_TO_CC as jtc where jtc.JCSZ = (select CNAME from T_SYS_META_CODE where CCODE = mmjc.JCSZ and CTYPE = '树种' )) as 出材树种名称, JCLX as 检尺类型, (select CNAME from T_SYS_META_CODE where CCODE = JCLX and CTYPE = '检尺类型' ) as 检尺类型名称, JJ as 径阶, YCZS as 用材株数, BYCZS as 半用材株数, XCZS as 薪材株数, ZSHJ as 株数合计, D1 as 胸径1, H1 as 树高1, D2 as 胸径2, H2 as 树高2, D3 as 胸径3, H3 as 树高3, PJG as 平均高, PJZJ as 平均直径, CJ as 材积, YCXJ as 用材蓄积, BYCXJ as 半用材蓄积, XCXJ as 薪材蓄积, GGCCCLV as 规格材出材率, XCCCLV as 小材出材率, GGCCCL as 规格材出材量, XCCCL as 小材出材量, DMJ as 断面积 from ";
            sCmdText = (((((((sCmdText + "T_ZT_CF_MMJC") + " as mmjc where CUN = '" + _Cun) + "' and LIN_BAN = '" + _Lin_Ban) + "' and DCXB = '" + _dcxb) + "' and ZYXB = '" + _zyxb) + "' and JCLX = '" + jclx) + "' and JCSZ = '" + jcsz) + "'" + " order by BZDH";
            IDbCommand dBCommand = null;// m_DBAccess.GetDBCommand(con, sCmdText);
            dBCommand.Transaction = tran;
            IDataReader reader = dBCommand.ExecuteReader();
            bool flag = false;
            _dtDatas = null;
            while (reader.Read())
            {
                int num;
                if (!flag)
                {
                    _dtDatas = new DataTable();
                    num = 0;
                    while (num < reader.FieldCount)
                    {
                        _dtDatas.Columns.Add(reader.GetName(num));
                        num++;
                    }
                    flag = true;
                }
                DataRow row = _dtDatas.NewRow();
                for (num = 0; num < reader.FieldCount; num++)
                {
                    row[num] = reader.GetValue(num);
                }
                _dtDatas.Rows.Add(row);
            }
            reader.Close();
        }

        private static object[] GetSqlFiledValues(IDbConnection pConn, IDbTransaction pTran, string table, string[] filed, string condition)
        {
            object dBNull = Convert.DBNull;
            condition = condition.Replace("where", " ");
            condition = condition.Replace("WHERE", " ");
            string sCmdText = "select ";
            foreach (string str2 in filed)
            {
                sCmdText = sCmdText + str2 + ", ";
            }
            sCmdText = ((sCmdText + ")").Replace(", )", " from ") + table) + " where " + condition;
            object[] values = null;
            IDbCommand dBCommand = null;// m_DBAccess.GetDBCommand(pConn, sCmdText);
            dBCommand.Transaction = pTran;
            IDataReader reader = dBCommand.ExecuteReader();
            if (reader.Read())
            {
                values = new object[filed.Length];
                reader.GetValues(values);
            }
            reader.Close();
            return values;
        }

        private static string sz_PreDeal(string jcsz, string thsz)
        {
            if (string.IsNullOrEmpty(thsz))
            {
                switch (jcsz)
                {
                    case "280":
                        return "一般桉";

                    case "285":
                        return "一般桉";

                    case "200":
                        return "阔叶树";

                    case "210":
                        return "阔叶树";

                    case "226":
                        return "栎类";

                    case "123":
                        return "杉木";

                    case "130":
                        return "马尾松";

                    case "132":
                        return "马尾松";

                    case "140":
                        return "云南松";

                    case "142":
                        return "云南松";

                    case "150":
                        return "马尾松";

                    case "212":
                        return "阔叶树";

                    case "255":
                        return "阔叶树";

                    case "270":
                        return "阔叶树";

                    case "271":
                        return "阔叶树";

                    case "272":
                        return "阔叶树";

                    case "273":
                        return "阔叶树";
                }
                if (jcsz.Substring(0, 2) == "15")
                {
                    return "马尾松";
                }
                return thsz;
            }
            return thsz;
        }

        private static void UpdateDatas(IDbConnection con, IDbTransaction tran)
        {
            string[] strArray = new string[] { "ZSHJ", "PJG", "PJZJ", "CJ", "YCXJ", "BYCXJ", "XCXJ", "GGCCCLV", "XCCCLV", "GGCCCL", "XCCCL", "DMJ" };
            string[] strArray2 = new string[] { "株数合计", "平均高", "平均直径", "材积", "用材蓄积", "半用材蓄积", "薪材蓄积", "规格材出材率", "小材出材率", "规格材出材量", "小材出材量", "断面积" };
            string sCmdText = "";
            IDbCommand dBCommand = null;// m_DBAccess.GetDBCommand(con, sCmdText);
            dBCommand.Transaction = tran;
            foreach (DataRow row in _dtDatas.Rows)
            {
                bool flag = false;
                sCmdText = "update ";
                sCmdText = sCmdText + "T_ZT_CF_MMJC" + " set ";
                for (int i = 0; i < strArray.Length; i++)
                {
                    object obj2 = row[strArray2[i]];
                    if (!Convert.IsDBNull(obj2))
                    {
                        sCmdText = (sCmdText + strArray[i] + " = ") + obj2.ToString() + ", ";
                        flag = true;
                    }
                }
                if (flag)
                {
                    sCmdText = ((((((((sCmdText + ")").Replace(", )", " ") + " where CUN = '" + _Cun) + "' and LIN_BAN = '" + _Lin_Ban) + "' and DCXB = '" + _dcxb) + "' and ZYXB = '" + _zyxb) + "' and BZDH = '" + row["标准地号"].ToString()) + "' and JCLX = '" + row["检尺类型"].ToString()) + "' and JCSZ = '" + row["检尺树种"].ToString()) + "' and JJ = " + row["径阶"].ToString();
                    dBCommand.CommandText = sCmdText;
                    dBCommand.ExecuteNonQuery();
                }
            }
        }
    }
}

