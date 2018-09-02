namespace SZMODEL_GXYSSZXJ
{
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Windows.Forms;

    public class GXYSSZXJ
    {
        public bool blnExecuteSZMODEL_GXXJByALL(string str_dbconn, string zyxbtablename)
        {
            bool flag;
            if ((str_dbconn == null) || (str_dbconn == string.Empty))
            {
                MessageBox.Show("请先进行数据库连接！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return false;
            }
            DataTable table = new DataTable("aa");
            table.Columns.Add("rows");
            table.Columns.Add("bds");
            string str = "BHYY='88' AND ";
            string[] strArray = new string[] { str + " (DI_LEI = '111') AND ", str + " (DI_LEI = '112') AND ", str + " (DI_LEI = '200') AND " };
            DataTable dt = new DataTable("modeltable");
            dt = this.GetTable(str_dbconn, "SELECT MODELBH,XIANCODE,XIANNAME,JLSJ,MODELTYPE,SZZNAME,SZZGBBDS,PJHGS,PJDGS,MGQXJJSGS,SSXJXS FROM T_SYS_META_GROWTHMODEL WHERE MODELTYPE=1 ORDER BY JLSJ DESC");
            if ((dt == null) || (dt.Rows.Count == 0))
            {
                MessageBox.Show("生长模型数据库没有有效数据，请先录入！", "信息", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return false;
            }
            DataTable dataTabeBySelRows = this.GetDataTabeBySelRows(dt, "JLSJ='" + dt.DefaultView.ToTable(true, new string[] { "JLSJ" }).Rows[0]["JLSJ"].ToString() + "'");
            string str3 = " UPDATE " + zyxbtablename + " SET ";
            SqlConnection pSqlConnection = null;
            SqlTransaction transaction = null;
            try
            {
                pSqlConnection = new SqlConnection(str_dbconn);
                pSqlConnection.Open();
                SqlCommand command = pSqlConnection.CreateCommand();
                transaction = pSqlConnection.BeginTransaction("pTransaction");
                command.Connection = pSqlConnection;
                command.Transaction = transaction;
                int num = 0;
                command.CommandText = " UPDATE " + zyxbtablename + " SET PINGJUN_NL=(CASE WHEN LTRIM(RTRIM(YOU_SHI_SZ))<>'' THEN PINGJUN_NL+1 END),BSSZNL=(CASE WHEN LTRIM(RTRIM(BSSZ))<>'' THEN BSSZNL+1 END),BHYY='88' WHERE (BHYY IS NULL OR BHYY='') ";
                num = command.ExecuteNonQuery();
                foreach (string str4 in strArray)
                {
                    foreach (DataRow row in dataTabeBySelRows.Rows)
                    {
                        string str5 = row["SZZGBBDS"].ToString().Trim();
                        string str6 = row["PJHGS"].ToString().Trim();
                        string str7 = row["PJDGS"].ToString().Trim();
                        string str8 = row["MGQXJJSGS"].ToString().Trim();
                        string str9 = str6.Replace("PINGJUN_NL", "(PINGJUN_NL-1)");
                        string str10 = str3 + " PINGJUN_SG = (CASE WHEN (PINGJUN_NL>1 AND PINGJUN_SG>0) THEN CONVERT(decimal(6, 1),PINGJUN_SG+(PINGJUN_SG*(2*(" + str6 + "-" + str9 + ")))/(" + str9 + "+" + str6 + ")) WHEN (PINGJUN_NL=1) THEN CONVERT(decimal(6, 1)," + str6 + ") END) WHERE " + str4 + str5 + ";";
                        command.CommandText = str10;
                        num = command.ExecuteNonQuery();
                        string str11 = str7.Replace("PINGJUN_NL", "(PINGJUN_NL-1)");
                        string str12 = str3 + " PINGJUN_XJ = (CASE WHEN (PINGJUN_NL>1) THEN CONVERT(decimal(6, 1),PINGJUN_XJ+(PINGJUN_XJ*(2*(" + str7 + "-" + str11 + ")))/(" + str11 + "+" + str7 + ")) WHEN (PINGJUN_NL=1) THEN CONVERT(decimal(6, 1)," + str7 + ") END) WHERE " + str4 + str5 + ";";
                        command.CommandText = str12;
                        num = command.ExecuteNonQuery();
                        string str13 = str8.Replace("PINGJUN_NL", "(PINGJUN_NL-1)");
                        string str14 = str3 + " YSSZXJ = CONVERT(decimal(10, 0),YSSZXJ+(YSSZXJ*(2*(" + str8 + "-" + str13 + ")))/(" + str13 + "+" + str8 + ")) WHERE " + str4 + str5 + " AND (PINGJUN_XJ>=5);";
                        command.CommandText = str14;
                        num = command.ExecuteNonQuery();
                        str9 = str6.Replace("PINGJUN_NL", "(BSSZNL-1)");
                        str10 = str3 + " BSSZSG = (CASE WHEN (BSSZNL>1) THEN CONVERT(decimal(6, 1),BSSZSG+(BSSZSG*(2*(" + str6.Replace("PINGJUN_NL", "BSSZNL") + "-" + str9 + ")))/(" + str9 + "+" + str6.Replace("PINGJUN_NL", "BSSZNL") + ")) WHEN (BSSZNL=1) THEN CONVERT(decimal(6, 1)," + str6.Replace("PINGJUN_NL", "BSSZNL") + ") END)  WHERE " + str4 + str5.Replace("YOU_SHI_SZ", "BSSZ").Replace("PINGJUN_NL", "BSSZNL") + ";";
                        command.CommandText = str10;
                        num = command.ExecuteNonQuery();
                        str11 = str7.Replace("PINGJUN_NL", "(BSSZNL-1)");
                        str12 = str3 + " BSSZPJXJ = (CASE WHEN (BSSZNL>1) THEN CONVERT(decimal(6, 1),BSSZPJXJ+(BSSZPJXJ*(2*( " + str7.Replace("PINGJUN_NL", "BSSZNL") + "-" + str11 + ")))/(" + str11 + "+" + str7.Replace("PINGJUN_NL", "BSSZNL") + ")) WHEN (BSSZNL=1) THEN CONVERT(decimal(6, 1)," + str7.Replace("PINGJUN_NL", "BSSZNL") + ") END) WHERE " + str4 + str5.Replace("YOU_SHI_SZ", "BSSZ").Replace("PINGJUN_NL", "BSSZNL") + ";";
                        command.CommandText = str12;
                        num = command.ExecuteNonQuery();
                        str13 = str8.Replace("PINGJUN_NL", "(BSSZNL-1)");
                        str14 = str3 + " BSSZXJ = CONVERT(decimal(10, 0),BSSZXJ+(BSSZXJ*(2*(" + str8.Replace("PINGJUN_NL", "BSSZNL") + "-" + str13 + ")))/(" + str13 + "+" + str8.Replace("PINGJUN_NL", "BSSZNL") + ")) WHERE " + str4 + str5.Replace("YOU_SHI_SZ", "BSSZ").Replace("PINGJUN_NL", "BSSZNL") + " AND (BSSZPJXJ>=5);";
                        command.CommandText = str14;
                        num = command.ExecuteNonQuery();
                    }
                }
                string str15 = " WHERE " + str + " (SSZYSZ>='290' AND SSZYSZ<'308') OR (SSZYSZ>='310' AND SSZYSZ<'321') AND (SSXJ > 0) ";
                string str16 = " WHERE  " + str + " (SSZYSZ >='100' AND SSZYSZ <'286') OR (SSZYSZ >='330' AND  SSZYSZ <'352') AND (SSXJ > 0) ";
                string str17 = "  UPDATE " + zyxbtablename + " SET SSXJ = ROUND(SSXJ * 1.1,0) " + str15;
                string str18 = "  UPDATE " + zyxbtablename + " SET SSXJ = ROUND(SSXJ* 1.04,0) " + str16;
                command.CommandText = str17;
                command.ExecuteNonQuery();
                command.CommandText = str18;
                command.ExecuteNonQuery();
                string str19 = "  UPDATE " + zyxbtablename + " SET SLXJ= YSSZXJ+BSSZXJ,ZXJ= YSSZXJ+BSSZXJ+SSXJ WHERE (BHYY='88')";
                string str20 = "  UPDATE " + zyxbtablename + " SET HUO_LMGQXJ= ROUND(ZXJ/MIAN_JI,2),BHYY='83' WHERE (BHYY='88')";
                command.CommandText = str19;
                int num2 = command.ExecuteNonQuery();
                command.CommandText = str20;
                num2 = command.ExecuteNonQuery();
                transaction.Commit();
                this.HFLJLZJJLCQ(pSqlConnection, zyxbtablename);
                flag = true;
            }
            catch (Exception exception)
            {
                try
                {
                    transaction.Rollback();
                }
                catch (Exception exception2)
                {
                    MessageBox.Show("撤销蓄积更新操作出错，错误：" + exception2.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
                MessageBox.Show("生长模型更新自然生长小班蓄积出错，错误：" + exception.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                flag = false;
            }
            finally
            {
                if ((pSqlConnection != null) && (pSqlConnection.State == ConnectionState.Open))
                {
                    pSqlConnection.Close();
                    pSqlConnection.Dispose();
                }
            }
            return flag;
        }

        public bool blnExecuteSZMODEL_GXXJByOne(string str_dbconn, string zyxbtablename, string cun, string lin_ban, string xiao_ban, string xi_ban)
        {
            bool flag;
            if ((str_dbconn == null) || (str_dbconn == string.Empty))
            {
                MessageBox.Show("请先进行数据库连接！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return false;
            }
            string xbkjwzwhere = " AND (CUN='" + cun + "' AND lin_ban='" + lin_ban + "' AND xiao_ban ='" + xiao_ban + "' AND ";
            if (xi_ban == null)
            {
                xbkjwzwhere = xbkjwzwhere + " xi_ban IS NULL)";
            }
            else
            {
                xbkjwzwhere = xbkjwzwhere + " xi_ban ='" + xi_ban + "')";
            }
            DataTable table = new DataTable("xbtable");
            string str2 = this.GetTable(str_dbconn, "SELECT CUN,lin_ban,xiao_ban,xi_ban,DI_LEI FROM " + zyxbtablename + " WHERE " + xbkjwzwhere.Remove(0, 4)).Rows[0]["DI_LEI"].ToString();
            string str3 = " (BHYY='83') AND ";
            DataTable dt = new DataTable("modeltable");
            dt = this.GetTable(str_dbconn, "SELECT MODELBH,XIANCODE,XIANNAME,JLSJ,MODELTYPE,SZZNAME,SZZGBBDS,PJHGS,PJDGS,MGQXJJSGS,SSXJXS FROM T_SYS_META_GROWTHMODEL WHERE MODELTYPE=1 ORDER BY JLSJ DESC");
            if ((dt == null) || (dt.Rows.Count == 0))
            {
                MessageBox.Show("生长数据库没有有效数据，请先录入！", "信息", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return false;
            }
            string cmdText = " UPDATE " + zyxbtablename + " SET PINGJUN_NL=(CASE WHEN LTRIM(RTRIM(YOU_SHI_SZ))<>'' THEN PINGJUN_NL+1 END),BSSZNL=(CASE WHEN LTRIM(RTRIM(BSSZ))<>'' THEN BSSZNL+1 END) , BHYY='83' WHERE (BHYY IS NULL OR BHYY='') " + xbkjwzwhere;
            DataTable dataTabeBySelRows = this.GetDataTabeBySelRows(dt, "JLSJ='" + dt.DefaultView.ToTable(true, new string[] { "JLSJ" }).Rows[0]["JLSJ"].ToString() + "'");
            string str6 = " UPDATE " + zyxbtablename + " SET ";
            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(str_dbconn);
                connection.Open();
                SqlCommand command = new SqlCommand(cmdText, connection);
                command.ExecuteNonQuery();
                this.HFLJLZJJLCQByOne(connection, zyxbtablename, xbkjwzwhere);
                if (((str2.Trim() == "111") || (str2.Trim() == "112")) || (str2.Trim() == "200"))
                {
                    foreach (DataRow row in dataTabeBySelRows.Rows)
                    {
                        string str7 = row["SZZGBBDS"].ToString().Trim();
                        string str8 = row["PJHGS"].ToString().Trim();
                        string str9 = row["PJDGS"].ToString().Trim();
                        string str10 = row["MGQXJJSGS"].ToString().Trim();
                        command = new SqlCommand(str6 + " PINGJUN_SG = (CASE WHEN (PINGJUN_NL>1 AND PINGJUN_SG>0) THEN CONVERT(decimal(6, 1),PINGJUN_SG+(PINGJUN_SG*(2*(" + str8 + "-" + str8.Replace("PINGJUN_NL", "(PINGJUN_NL-1)") + ")))/(" + str8 + "+" + str8.Replace("PINGJUN_NL", "(PINGJUN_NL-1)") + ")) WHEN (PINGJUN_NL=1) THEN CONVERT(decimal(6, 1)," + str8 + ") END) WHERE " + str3 + str7 + xbkjwzwhere + ";", connection);
                        command.ExecuteNonQuery();
                        command = new SqlCommand(str6 + " PINGJUN_XJ = (CASE WHEN (PINGJUN_NL>1) THEN CONVERT(decimal(6, 1),PINGJUN_XJ+(PINGJUN_XJ*(2*(" + str9 + "-" + str9.Replace("PINGJUN_NL", "(PINGJUN_NL-1)") + ")))/(" + str9 + "+" + str9.Replace("PINGJUN_NL", "(PINGJUN_NL-1)") + ")) WHEN (PINGJUN_NL=1) THEN CONVERT(decimal(6, 1)," + str9 + ") END)  WHERE " + str3 + str7 + xbkjwzwhere + ";", connection);
                        command.ExecuteNonQuery();
                        command = new SqlCommand(str6 + " YSSZXJ = CONVERT(decimal(10, 0),YSSZXJ+(YSSZXJ*(2*(" + str10 + "-" + str10.Replace("PINGJUN_NL", "(PINGJUN_NL-1)") + ")))/(" + str10 + "+" + str10.Replace("PINGJUN_NL", "(PINGJUN_NL-1)") + ")) WHERE " + str3 + str7 + " AND (PINGJUN_XJ>=5) " + xbkjwzwhere + ";", connection);
                        command.ExecuteNonQuery();
                        command = new SqlCommand(str6 + " BSSZSG =(CASE WHEN (BSSZNL>1 AND BSSZSG >0) THEN CONVERT(decimal(6, 1),BSSZSG+(BSSZSG*(2*(" + str8.Replace("PINGJUN_NL", "BSSZNL") + "-" + str8.Replace("PINGJUN_NL", "(BSSZNL-1)") + ")))/(" + str8.Replace("PINGJUN_NL", "BSSZNL") + "+" + str8.Replace("PINGJUN_NL", "(BSSZNL-1)") + ")) WHEN (PINGJUN_NL=1) THEN CONVERT(decimal(6, 1)," + str8.Replace("PINGJUN_NL", "BSSZNL") + ") END) WHERE " + str3 + str7.Replace("YOU_SHI_SZ", "BSSZ").Replace("PINGJUN_NL", "BSSZNL") + xbkjwzwhere + ";", connection);
                        command.ExecuteNonQuery();
                        command = new SqlCommand(str6 + " BSSZPJXJ = (CASE WHEN (BSSZNL>1) THEN CONVERT(decimal(6, 1),BSSZPJXJ+(BSSZPJXJ*(2*( " + str9.Replace("PINGJUN_NL", "BSSZNL") + "-" + str9.Replace("PINGJUN_NL", "(BSSZNL-1)") + ")))/(" + str9.Replace("PINGJUN_NL", "BSSZNL") + "+" + str9.Replace("PINGJUN_NL", "(BSSZNL-1)") + ")) WHEN (PINGJUN_NL=1) THEN CONVERT(decimal(6, 1)," + str9.Replace("PINGJUN_NL", "BSSZNL") + ") END) WHERE " + str3 + str7.Replace("YOU_SHI_SZ", "BSSZ").Replace("PINGJUN_NL", "BSSZNL") + xbkjwzwhere + ";", connection);
                        command.ExecuteNonQuery();
                        new SqlCommand(str6 + " BSSZXJ = CONVERT(decimal(10, 0),BSSZXJ+(BSSZXJ*(2*(" + str10.Replace("PINGJUN_NL", "BSSZNL") + "-" + str10.Replace("PINGJUN_NL", "(BSSZNL-1)") + ")))/(" + str10.Replace("PINGJUN_NL", "BSSZNL") + "+" + str10.Replace("PINGJUN_NL", "(BSSZNL-1)") + ")) WHERE " + str3 + str7.Replace("YOU_SHI_SZ", "BSSZ").Replace("PINGJUN_NL", "BSSZNL") + " AND (BSSZPJXJ>=5) " + xbkjwzwhere + ";", connection).ExecuteNonQuery();
                    }
                }
                string str14 = " WHERE " + str3 + " (SSZYSZ>='290' AND SSZYSZ<'308') OR (SSZYSZ>='310' AND SSZYSZ<'321') AND (SSXJ > 0) ";
                string str15 = " WHERE  " + str3 + " (SSZYSZ >='100' AND SSZYSZ <'286') OR (SSZYSZ >='330' AND  SSZYSZ <'352') AND (SSXJ > 0) ";
                string str16 = "  UPDATE " + zyxbtablename + " SET SSXJ = ROUND(SSXJ * 1.1,0) " + str14 + xbkjwzwhere;
                string str17 = "  UPDATE " + zyxbtablename + " SET SSXJ = ROUND(SSXJ* 1.04,0) " + str3 + str15 + xbkjwzwhere;
                new SqlCommand(str16, connection).ExecuteNonQuery();
                new SqlCommand(str17, connection).ExecuteNonQuery();
                string str18 = "  UPDATE " + zyxbtablename + " SET SLXJ= YSSZXJ+BSSZXJ,ZXJ= YSSZXJ+BSSZXJ+SSXJ WHERE (BHYY='83') " + xbkjwzwhere;
                string str19 = "  UPDATE " + zyxbtablename + " SET HUO_LMGQXJ= ROUND(ZXJ/MIAN_JI,2) WHERE (BHYY='83') " + xbkjwzwhere;
                new SqlCommand(str18, connection).ExecuteNonQuery();
                new SqlCommand(str19, connection).ExecuteNonQuery();
                this.HFLJLZJJLCQByOne(connection, zyxbtablename, xbkjwzwhere);
                flag = true;
            }
            catch (Exception exception)
            {
                MessageBox.Show("生长模型更新自然生长小班蓄积出错，错误：" + exception.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                flag = false;
            }
            finally
            {
                if ((connection != null) && (connection.State == ConnectionState.Open))
                {
                    connection.Close();
                    connection.Dispose();
                }
            }
            return flag;
        }

        private DataTable GetDataTabeBySelRows(DataTable dt, string sel)
        {
            DataTable table = dt.Clone();
            DataRow[] rowArray = dt.Select(sel);
            if (rowArray.Length < 0)
            {
                return null;
            }
            foreach (DataRow row in rowArray)
            {
                table.Rows.Add(row.ItemArray);
            }
            return table;
        }

        private DataTable GetTable(string str_dbconn, string cmdtxt)
        {
            SqlConnection selectConnection = null;
            DataTable table2;
            try
            {
                selectConnection = new SqlConnection(str_dbconn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmdtxt, selectConnection);
                DataTable dataTable = new DataTable("sqldt");
                adapter.Fill(dataTable);
                table2 = dataTable;
            }
            catch (Exception exception)
            {
                MessageBox.Show("错误：" + exception.Message, "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                table2 = null;
            }
            finally
            {
                if (selectConnection.State == ConnectionState.Open)
                {
                    selectConnection.Close();
                    selectConnection.Dispose();
                }
            }
            return table2;
        }

        private void HFLJLZJJLCQ(SqlConnection pSqlConnection, string xbtablename)
        {
            int num;
            string cmdText = "select * from [T_SYS_META_LJLZ]";
            SqlCommand selectCommand = new SqlCommand(cmdText, pSqlConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(selectCommand);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            for (num = 0; num < dataTable.Rows.Count; num++)
            {
                selectCommand = new SqlCommand(string.Concat(new object[] { " update ", xbtablename, " set lj = (case when CEILING(PINGJUN_NL/", int.Parse(dataTable.Rows[num]["ljqx"].ToString().Trim()), ") >= 8 then 8 else CEILING(PINGJUN_NL/", int.Parse(dataTable.Rows[num]["ljqx"].ToString().Trim()), " + 1) end) where ", dataTable.Rows[num]["lin_zhong"].ToString().Trim(), " and ", dataTable.Rows[num]["qi_yuan"].ToString().Trim(), " and ", dataTable.Rows[num]["di_lei"].ToString().Trim(), " and ", dataTable.Rows[num]["you_shi_sz"].ToString().Trim() }), pSqlConnection);
                selectCommand.ExecuteNonQuery();
                new SqlCommand(string.Concat(new object[] { 
                    " update ", xbtablename, " set LING_ZU = (case when PINGJUN_NL >= ", int.Parse(dataTable.Rows[num]["a1"].ToString().Trim()), " and  PINGJUN_NL <= ", int.Parse(dataTable.Rows[num]["a2"].ToString().Trim()), " then 1  when PINGJUN_NL >= ", int.Parse(dataTable.Rows[num]["b1"].ToString().Trim()), " and  PINGJUN_NL <= ", int.Parse(dataTable.Rows[num]["b2"].ToString().Trim()), " then 2  when PINGJUN_NL >= ", int.Parse(dataTable.Rows[num]["c1"].ToString().Trim()), " and  PINGJUN_NL <= ", int.Parse(dataTable.Rows[num]["c2"].ToString().Trim()), " then 3  when PINGJUN_NL >= ", int.Parse(dataTable.Rows[num]["d1"].ToString().Trim()),
                    " and  PINGJUN_NL <= ", int.Parse(dataTable.Rows[num]["d2"].ToString().Trim()), " then 4  when PINGJUN_NL >= ", int.Parse(dataTable.Rows[num]["e"].ToString().Trim()), " then 5  end ) where ", dataTable.Rows[num]["lin_zhong"].ToString().Trim(), " and ", dataTable.Rows[num]["qi_yuan"].ToString().Trim(), " and ", dataTable.Rows[num]["di_lei"].ToString().Trim(), " and ", dataTable.Rows[num]["you_shi_sz"].ToString().Trim()
                }), pSqlConnection).ExecuteNonQuery();
            }
            cmdText = "select * from [T_SYS_META_JJLCQ]";
            selectCommand = new SqlCommand(cmdText, pSqlConnection);
            adapter = new SqlDataAdapter(selectCommand);
            dataTable = new DataTable();
            adapter.Fill(dataTable);
            for (num = 0; num < dataTable.Rows.Count; num++)
            {
                new SqlCommand(string.Concat(new object[] { 
                    "update ", xbtablename, " set JJLCQ = (case when PINGJUN_NL >= ", int.Parse(dataTable.Rows[num]["a1"].ToString().Trim()), " and  PINGJUN_NL <= ", int.Parse(dataTable.Rows[num]["a2"].ToString().Trim()), " then 1  when PINGJUN_NL >= ", int.Parse(dataTable.Rows[num]["b1"].ToString().Trim()), " and  PINGJUN_NL <= ", int.Parse(dataTable.Rows[num]["b2"].ToString().Trim()), " then 2  when PINGJUN_NL >= ", int.Parse(dataTable.Rows[num]["c1"].ToString().Trim()), " and  PINGJUN_NL <= ", int.Parse(dataTable.Rows[num]["c2"].ToString().Trim()), " then 3  when PINGJUN_NL > ", int.Parse(dataTable.Rows[num]["d"].ToString().Trim()),
                    " then 4  end ) where LIN_ZHONG like '25%' and YOU_SHI_SZ ='", dataTable.Rows[num]["YOU_SHI_SZ"].ToString().Trim(), "'"
                }), pSqlConnection).ExecuteNonQuery();
            }
        }

        private void HFLJLZJJLCQByOne(SqlConnection pSqlConnection, string xbtablename, string xbkjwzwhere)
        {
            int num;
            SqlCommand selectCommand = new SqlCommand("SELECT * FROM " + xbtablename + " WHERE " + xbkjwzwhere.Remove(0, 4), pSqlConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(selectCommand);
            DataTable dataTable = new DataTable("XB");
            adapter.Fill(dataTable);
            string cmdText = "select * from [T_SYS_META_LJLZ]";
            selectCommand = new SqlCommand(cmdText, pSqlConnection);
            adapter = new SqlDataAdapter(selectCommand);
            DataTable table2 = new DataTable();
            adapter.Fill(table2);
            for (num = 0; num < table2.Rows.Count; num++)
            {
                selectCommand = new SqlCommand(string.Concat(new object[] { " update ", xbtablename, " set lj = (case when CEILING(PINGJUN_NL/", int.Parse(table2.Rows[num]["ljqx"].ToString().Trim()), ") >= 8 then 8 else CEILING(PINGJUN_NL/", int.Parse(table2.Rows[num]["ljqx"].ToString().Trim()), " + 1) end) where ", table2.Rows[num]["lin_zhong"].ToString().Trim(), " and ", table2.Rows[num]["qi_yuan"].ToString().Trim(), " and ", table2.Rows[num]["di_lei"].ToString().Trim(), " and ", table2.Rows[num]["you_shi_sz"].ToString().Trim(), xbkjwzwhere }), pSqlConnection);
                selectCommand.ExecuteNonQuery();
                selectCommand = new SqlCommand(string.Concat(new object[] { 
                    " update ", xbtablename, " set LING_ZU = (case when PINGJUN_NL >= ", int.Parse(table2.Rows[num]["a1"].ToString().Trim()), " and  PINGJUN_NL <= ", int.Parse(table2.Rows[num]["a2"].ToString().Trim()), " then 1  when PINGJUN_NL >= ", int.Parse(table2.Rows[num]["b1"].ToString().Trim()), " and  PINGJUN_NL <= ", int.Parse(table2.Rows[num]["b2"].ToString().Trim()), " then 2  when PINGJUN_NL >= ", int.Parse(table2.Rows[num]["c1"].ToString().Trim()), " and  PINGJUN_NL <= ", int.Parse(table2.Rows[num]["c2"].ToString().Trim()), " then 3  when PINGJUN_NL >= ", int.Parse(table2.Rows[num]["d1"].ToString().Trim()),
                    " and  PINGJUN_NL <= ", int.Parse(table2.Rows[num]["d2"].ToString().Trim()), " then 4  when PINGJUN_NL >= ", int.Parse(table2.Rows[num]["e"].ToString().Trim()), " then 5  end ) where ", table2.Rows[num]["lin_zhong"].ToString().Trim(), " and ", table2.Rows[num]["qi_yuan"].ToString().Trim(), " and ", table2.Rows[num]["di_lei"].ToString().Trim(), " and ", table2.Rows[num]["you_shi_sz"].ToString().Trim(), xbkjwzwhere
                }), pSqlConnection);
                selectCommand.ExecuteNonQuery();
            }
            if (dataTable.Rows[0]["YOU_SHI_SZ"].ToString().Trim().IndexOf("25") > 0)
            {
                selectCommand = new SqlCommand("select * from [T_SYS_META_JJLCQ] WHERE YOU_SHI_SZ='" + dataTable.Rows[0]["YOU_SHI_SZ"].ToString() + "'", pSqlConnection);
                adapter = new SqlDataAdapter(selectCommand);
                table2 = new DataTable();
                adapter.Fill(table2);
                for (num = 0; num < table2.Rows.Count; num++)
                {
                    new SqlCommand(string.Concat(new object[] { 
                        "update ", xbtablename, " set JJLCQ = (case when PINGJUN_NL >= ", int.Parse(table2.Rows[num]["a1"].ToString().Trim()), " and  PINGJUN_NL <= ", int.Parse(table2.Rows[num]["a2"].ToString().Trim()), " then 1  when PINGJUN_NL >= ", int.Parse(table2.Rows[num]["b1"].ToString().Trim()), " and  PINGJUN_NL <= ", int.Parse(table2.Rows[num]["b2"].ToString().Trim()), " then 2  when PINGJUN_NL >= ", int.Parse(table2.Rows[num]["c1"].ToString().Trim()), " and  PINGJUN_NL <= ", int.Parse(table2.Rows[num]["c2"].ToString().Trim()), " then 3  when PINGJUN_NL > ", int.Parse(table2.Rows[num]["d"].ToString().Trim()),
                        " then 4  end ) where LIN_ZHONG like '25%' and YOU_SHI_SZ ='", table2.Rows[num]["YOU_SHI_SZ"].ToString().Trim(), "' ", xbkjwzwhere
                    }), pSqlConnection).ExecuteNonQuery();
                }
            }
        }
    }
}

