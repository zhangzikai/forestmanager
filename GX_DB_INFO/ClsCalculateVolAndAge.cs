namespace GX_DB_INFO
{
    using System;
    using System.Data;
    using System.Data.Common;
    using System.Data.SqlClient;
    using System.Windows.Forms;
    using Utilities;

    public class ClsCalculateVolAndAge
    {
        public string CalculateLJLZ(string pXBTableName, SqlConnection pSqlConnection)
        {
            string str2;
            try
            {
                if (pSqlConnection == null)
                {
                    return "数据库连接无效，不能进行蓄积计算!";
                }
                if (pSqlConnection.State != ConnectionState.Open)
                {
                    pSqlConnection.Open();
                }
                //if (pDBAccess == null)
                //{
                //    return "数据库连接无效，无法划分龄级龄组!";
                //}
                string sql = "SELECT * FROM T_LJLZ";
                DataTable dataBySql = null;// this.GetDataBySql(sql, pDBAccess);
                SqlCommand command = new SqlCommand(sql, pSqlConnection);
                for (int i = 0; i < dataBySql.Rows.Count; i++)
                {
                    command = new SqlCommand("update " + pXBTableName + " set LJ = (case when CEILING(cast(PINGJUN_NL as decimal)/" + dataBySql.Rows[i]["ljqx"].ToString().Trim() + ") >= 8 then 8 else CEILING(cast(PINGJUN_NL as decimal)/" + dataBySql.Rows[i]["ljqx"].ToString().Trim() + ") end) where " + dataBySql.Rows[i]["lin_zhong"].ToString().Trim() + " and " + dataBySql.Rows[i]["qi_yuan"].ToString().Trim() + " and " + dataBySql.Rows[i]["di_lei"].ToString().Trim() + " and " + dataBySql.Rows[i]["you_shi_sz"].ToString().Trim(), pSqlConnection);
                    command.ExecuteNonQuery();
                    command.Dispose();
                }
                for (int j = 0; j < dataBySql.Rows.Count; j++)
                {
                    command = new SqlCommand("update " + pXBTableName + " set LING_ZU = (case when PINGJUN_NL > " + dataBySql.Rows[j]["a1"].ToString().Trim() + " and  PINGJUN_NL <= " + dataBySql.Rows[j]["a2"].ToString().Trim() + " then 1  when PINGJUN_NL >= " + dataBySql.Rows[j]["b1"].ToString().Trim() + " and  PINGJUN_NL <= " + dataBySql.Rows[j]["b2"].ToString().Trim() + " then 2  when PINGJUN_NL >= " + dataBySql.Rows[j]["c1"].ToString().Trim() + " and  PINGJUN_NL <= " + dataBySql.Rows[j]["c2"].ToString().Trim() + " then 3  when PINGJUN_NL >= " + dataBySql.Rows[j]["d1"].ToString().Trim() + " and  PINGJUN_NL <= " + dataBySql.Rows[j]["d2"].ToString().Trim() + " then 4  when PINGJUN_NL >= " + dataBySql.Rows[j]["e"].ToString().Trim() + " then 5  end ) where " + dataBySql.Rows[j]["lin_zhong"].ToString().Trim() + " and " + dataBySql.Rows[j]["qi_yuan"].ToString().Trim() + " and " + dataBySql.Rows[j]["di_lei"].ToString().Trim() + " and " + dataBySql.Rows[j]["you_shi_sz"].ToString().Trim(), pSqlConnection);
                    command.ExecuteNonQuery();
                    command.Dispose();
                }
                sql = "select * from T_JJLCQ";
                dataBySql = new DataTable();
               // dataBySql = this.GetDataBySql(sql, pDBAccess);
                for (int k = 0; k < dataBySql.Rows.Count; k++)
                {
                    command = new SqlCommand("update " + pXBTableName + " set JJLCQ = (case when PINGJUN_NL >= " + dataBySql.Rows[k]["a1"].ToString().Trim() + " and  PINGJUN_NL <= " + dataBySql.Rows[k]["a2"].ToString().Trim() + " then 1  when PINGJUN_NL >= " + dataBySql.Rows[k]["b1"].ToString().Trim() + " and  PINGJUN_NL <= " + dataBySql.Rows[k]["b2"].ToString().Trim() + " then 2  when PINGJUN_NL >= " + dataBySql.Rows[k]["c1"].ToString().Trim() + " and  PINGJUN_NL <= " + dataBySql.Rows[k]["c2"].ToString().Trim() + " then 3  when PINGJUN_NL > " + dataBySql.Rows[k]["d"].ToString().Trim() + " then 4  end ) where you_shi_sz = '" + dataBySql.Rows[k]["you_shi_sz"].ToString().Trim() + "'", pSqlConnection);
                    command.ExecuteNonQuery();
                    command.Dispose();
                }
                str2 = "";
            }
            catch (Exception exception)
            {
                str2 = "方法CalculateLJLZ划分小班龄级龄组出错，可能的原因：" + exception.Message;
            }
            finally
            {
                GC.Collect();
            }
            return str2;
        }

        public string CalculateXJ_All(string pXBTableName, SqlConnection pSqlConnection)
        {
            string str2;
            try
            {
                if (pSqlConnection == null)
                {
                    return "数据库连接无效，不能进行蓄积计算!";
                }
                if (pSqlConnection.State != ConnectionState.Open)
                {
                    pSqlConnection.Open();
                }
                SqlCommand command = new SqlCommand("update " + pXBTableName + " set ysszxj = 0 where ysszxj is null", pSqlConnection);
                command.ExecuteNonQuery();
                command.Dispose();
                command = new SqlCommand("update " + pXBTableName + " set bsszxj = 0 where bsszxj is null", pSqlConnection);
                command.ExecuteNonQuery();
                command.Dispose();
                command = new SqlCommand("update " + pXBTableName + " set ssxj = 0 where ssxj is null", pSqlConnection);
                command.ExecuteNonQuery();
                command.Dispose();
                command = new SqlCommand("update " + pXBTableName + " set slxj = ysszxj + bsszxj", pSqlConnection);
                command.ExecuteNonQuery();
                command.Dispose();
                command = new SqlCommand("update " + pXBTableName + " set zxj = slxj + ssxj", pSqlConnection);
                command.ExecuteNonQuery();
                command.Dispose();
                str2 = "";
            }
            catch (Exception exception)
            {
                str2 = "方法CalculateXJ_All计算所有小班蓄积出错，可能的原因：" + exception.Message;
            }
            finally
            {
                GC.Collect();
            }
            return str2;
        }

        public string CalculateXJ_ANSHU(string tabName, SqlConnection pSqlConnection)
        {
            string str2;
            try
            {
                if (pSqlConnection == null)
                {
                    return "数据库连接无效，不能进行蓄积计算!";
                }
                if (pSqlConnection.State != ConnectionState.Open)
                {
                    pSqlConnection.Open();
                }
                SqlCommand command = new SqlCommand(string.Format("update {0} set bsszxj = isnull(cast(floor(([BSSZGQDM]*[BSSZSG]*0.97670866*Power(cast(nullif([BSSZPJXJ],0) as numeric(18,8)),-0.068428604)*Power(cast(nullif([BSSZSG],0) as numeric(18,8)),-0.18596012)*10+0.5))/10 * [YXMJ] as decimal),0) where BHYY='80'  AND (BSSZ>='290' AND BSSZ<='320') AND BSSZPJXJ>=5", tabName), pSqlConnection);
                command.ExecuteNonQuery();
                command.Dispose();
                command = new SqlCommand(string.Format("update {0} set ysszxj = isnull(cast(floor(([PINGJUN_DM]*[PINGJUN_SG]*0.97670866*Power(cast(nullif([PINGJUN_XJ],0) as numeric(18,8)),-0.068428604)*Power(cast(nullif([PINGJUN_SG],0) as numeric(18,8)),-0.18596012)*10+0.5))/10 * [YXMJ] as decimal),0) where BHYY='80'  AND (YOU_SHI_SZ>='290' AND YOU_SHI_SZ<='320') AND PINGJUN_XJ>=5", tabName), pSqlConnection);
                command.ExecuteNonQuery();
                command.Dispose();
                str2 = "";
            }
            catch (Exception exception)
            {
                str2 = "方法CalculateXJ_ANSHU计算桉树小班蓄积出错，可能的原因：" + exception.Message;
            }
            finally
            {
                GC.Collect();
            }
            return str2;
        }

        public string CalculateXJ_BHYY(string pXBTableName, IDbConnection sqldbConn)
        {
            string str2;
            try
            {
                SqlConnection connection = null;
                if (sqldbConn is SqlConnection)
                {
                    connection = sqldbConn as SqlConnection;
                }
                if (connection == null)
                {
                    return "数据库连接无效，不能进行蓄积计算!";
                }
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
                SqlCommand command = new SqlCommand("update " + pXBTableName + " set ssxj = floor(0.65671*POWER(cast(10 as numeric(18,8)),-4)*power(cast([SSPJXJ] as numeric(18,8)),1.769412)*POWER(cast([SSPJGD] as numeric(18,8)),1.069769)*[SSZZS]+0.5)  where sszysz >=120 and sszysz <=123 and ((sspjxj >= 5 and (LEN(RTRIM(LTRIM(BHYY)))=2 or bhyy is not null) and ltrim(rtrim(bhyy)) <> '80') or (sspjxj >= 5 and ssxj = 0))", connection);
                command.ExecuteNonQuery();
                command.Dispose();
                command = new SqlCommand("update " + pXBTableName + " set ssxj = floor(0.714265437*POWER(cast(10 as numeric(18,8)),-4)*POWER(cast([SSPJXJ] as numeric(18,8)),1.867008)*POWER(cast([SSPJGD] as numeric(18,8)),0.9014632)*[SSZZS]+0.5)  where ((sszysz >=100 and sszysz <=114) or (sszysz >=130 and sszysz <=132) or (sszysz >=150 and sszysz <=162)) and ((sspjxj >= 5 and (LEN(RTRIM(LTRIM(BHYY)))=2 or bhyy is not null) and ltrim(rtrim(bhyy)) <> '80') or (sspjxj >= 5 and ssxj = 0))", connection);
                command.ExecuteNonQuery();
                command.Dispose();
                command = new SqlCommand("update " + pXBTableName + " set ssxj = floor(0.50440*POWER(cast(10 as numeric(18,8)),-4)*POWER(cast([SSPJXJ] as numeric(18,8)),1.943725)*POWER(cast([SSPJGD] as numeric(18,8)),0.977397)*[SSZZS]+0.5)  where sszysz >=140 and sszysz <=142 and ((sspjxj >= 5 and (LEN(RTRIM(LTRIM(BHYY)))=2 or bhyy is not null) and ltrim(rtrim(bhyy)) <> '80') or (sspjxj >= 5 and ssxj = 0))", connection);
                command.ExecuteNonQuery();
                command.Dispose();
                command = new SqlCommand("update " + pXBTableName + " set ssxj = floor((0.043785-6.75245*POWER(cast(10 as numeric(18,8)),-3)*[SSPJXJ]+2.73652*POWER(cast(10 as numeric(18,8)),-4)*POWER(cast([SSPJXJ] as numeric(18,8)),2)+5.02044*POWER(cast(10 as numeric(18,8)),-4)*[SSPJXJ]*[SSPJGD]+1.54609*POWER(cast(10 as numeric(18,8)),-5)*POWER(cast([SSPJXJ] as numeric(18,8)),2)*[SSPJGD]-3.35291*POWER(cast(10 as numeric(18,8)),-3)*[SSPJGD])*[SSZZS]+0.5)  where ((sszysz >=280 and sszysz <=285) or (sszysz >=310 and sszysz <=320)) and ((sspjxj >= 5 and (LEN(RTRIM(LTRIM(BHYY)))=2 or bhyy is not null) and ltrim(rtrim(bhyy)) <> '80') or (sspjxj >= 5 and ssxj = 0))", connection);
                command.ExecuteNonQuery();
                command.Dispose();
                command = new SqlCommand("update " + pXBTableName + " set ssxj = floor(1.09154150*POWER(cast(10 as numeric(18,8)),-4)*POWER(cast([SSPJXJ] as numeric(18,8)),1.87892370-5.69185503*POWER(cast(10 as numeric(18,8)),-3)*([SSPJXJ]+[SSPJGD]))*POWER(cast([SSPJGD] as numeric(18,8)),0.65259805+7.84753507*POWER(cast(10 as numeric(18,8)),-3)*([SSPJXJ]+[SSPJGD]))*[SSZZS]+0.5)  where sszysz >=290 and sszysz <=307  and ((sspjxj >= 5 and (LEN(RTRIM(LTRIM(BHYY)))=2 or bhyy is not null) and ltrim(rtrim(bhyy)) <> '80') or (sspjxj >= 5 and ssxj = 0))", connection);
                command.ExecuteNonQuery();
                command.Dispose();
                command = new SqlCommand("update " + pXBTableName + " set ssxj = floor(0.667054*POWER(cast(10 as numeric(18,8)),-4)*POWER(cast([SSPJXJ] as numeric(18,8)),1.84795450)*POWER(cast([SSPJGD] as numeric(18,8)),0.96657509)*[SSZZS]+0.5)  where ((sszysz >=200 and sszysz <=273) or (sszysz >=330 and sszysz <=351) or sszysz='617' or (sszysz >=635 and sszysz <=703 and sszysz not in('636','638','644','661','662','671','673','687','698','702','703'))) and ((sspjxj >= 5 and (LEN(RTRIM(LTRIM(BHYY)))=2 or bhyy is not null) and ltrim(rtrim(bhyy)) <> '80') or (sspjxj >= 5 and ssxj = 0))", connection);
                command.ExecuteNonQuery();
                command.Dispose();
                command = new SqlCommand("update " + pXBTableName + " set ysszxj = cast(floor((0.45225+1.31334/([PINGJUN_SG]+2))*[PINGJUN_SG]*[PINGJUN_DM]*10+0.5)/10*[YXMJ] as decimal) where you_shi_sz >=120 and you_shi_sz <=123  and ((pingjun_xj >= 5 and (LEN(RTRIM(LTRIM(BHYY)))=2 or bhyy is not null) and ltrim(rtrim(bhyy)) <> '80') or (pingjun_xj >= 5 and ysszxj = 0))", connection);
                command.ExecuteNonQuery();
                command.Dispose();
                command = new SqlCommand("update " + pXBTableName + " set ysszxj = cast(floor(((0.36445+1.94272/([PINGJUN_SG]+2))*[PINGJUN_SG]*[PINGJUN_DM]*10+0.5))/10*[YXMJ] as decimal)  where ((you_shi_sz >=100 and you_shi_sz <=114) or (you_shi_sz >=130 and you_shi_sz <=132) or (you_shi_sz >=150 and you_shi_sz <=162)) and ((pingjun_xj >= 5 and (LEN(RTRIM(LTRIM(BHYY)))=2 or bhyy is not null) and ltrim(rtrim(bhyy)) <> '80') or (pingjun_xj >= 5 and ysszxj = 0))", connection);
                command.ExecuteNonQuery();
                command.Dispose();
                command = new SqlCommand("update " + pXBTableName + " set ysszxj = isnull(cast(floor(((0.43853+1.15672/nullif(([PINGJUN_SG]-1),0))*[PINGJUN_SG]*[PINGJUN_DM]*10+0.5))/10*[YXMJ] as decimal),0)  where you_shi_sz >=140 and you_shi_sz <=142 and ((pingjun_xj >= 5 and (LEN(RTRIM(LTRIM(BHYY)))=2 or bhyy is not null) and ltrim(rtrim(bhyy)) <> '80') or (pingjun_xj >= 5 and ysszxj = 0))", connection);
                command.ExecuteNonQuery();
                command.Dispose();
                command = new SqlCommand("update " + pXBTableName + " set ysszxj = cast(floor(((0.37970+1.00761/nullif([PINGJUN_SG],0))*[PINGJUN_SG]*[PINGJUN_DM]*10+0.5))/10* [YXMJ] as decimal)  where ((you_shi_sz >=280 and you_shi_sz <=285) or (you_shi_sz >=310 and you_shi_sz <=320)) and ((pingjun_xj >= 5 and (LEN(RTRIM(LTRIM(BHYY)))=2 or bhyy is not null) and ltrim(rtrim(bhyy)) <> '80') or (pingjun_xj >= 5 and ysszxj = 0))", connection);
                command.ExecuteNonQuery();
                command.Dispose();
                command = new SqlCommand("update " + pXBTableName + " set ysszxj = isnull(cast(floor(([PINGJUN_DM]*[PINGJUN_SG]*0.97670866*Power(cast(nullif([PINGJUN_XJ],0) as numeric(18,8)),-0.068428604)*Power(cast(nullif([PINGJUN_SG],0) as numeric(18,8)),-0.18596012)*10+0.5))/10 * [YXMJ] as decimal),0)  where you_shi_sz >=290 and you_shi_sz <=307 and ((pingjun_xj >= 5 and (LEN(RTRIM(LTRIM(BHYY)))=2 or bhyy is not null) and ltrim(rtrim(bhyy)) <> '80') or (pingjun_xj >= 5 and ysszxj = 0))", connection);
                command.ExecuteNonQuery();
                command.Dispose();
                command = new SqlCommand("update " + pXBTableName + " set ysszxj = cast(floor(([PINGJUN_DM]*0.386*([PINGJUN_SG]+3)*10+0.5))/10 * [YXMJ] as decimal)  where you_shi_sz >=220 and you_shi_sz <=230 and ((pingjun_xj >= 5 and (LEN(RTRIM(LTRIM(BHYY)))=2 or bhyy is not null) and ltrim(rtrim(bhyy)) <> '80') or (pingjun_xj >= 5 and ysszxj = 0))", connection);
                command.ExecuteNonQuery();
                command.Dispose();
                command = new SqlCommand("update " + pXBTableName + " set ysszxj = cast(floor(((0.40489+3.37866/([PINGJUN_SG]+20))*[PINGJUN_SG]*[PINGJUN_DM]*10+0.5))/10 * [YXMJ] as decimal)  where ((you_shi_sz='211' or you_shi_sz='212' or you_shi_sz >=240 and you_shi_sz <=273) or (you_shi_sz >=330 and you_shi_sz <=351) or you_shi_sz='617' or (you_shi_sz >=635 and you_shi_sz <=703 and you_shi_sz not in('636','638','644','661','662','671','673','687','698','702','703'))) and ((pingjun_xj >= 5 and (LEN(RTRIM(LTRIM(BHYY)))=2 or bhyy is not null) and ltrim(rtrim(bhyy)) <> '80') or (pingjun_xj >= 5 and ysszxj = 0))", connection);
                command.ExecuteNonQuery();
                command.Dispose();
                command = new SqlCommand("update " + pXBTableName + " set bsszxj = cast(floor((0.45225+1.31334/([BSSZSG]+2))*[BSSZSG]*[BSSZGQDM]*10+0.5)/10*[YXMJ] as decimal) where bssz >=120 and bssz <=123 and ((BSSZPJXJ >= 5 and (LEN(RTRIM(LTRIM(BHYY)))=2 or bhyy is not null) and ltrim(rtrim(bhyy)) <> '80') or (BSSZPJXJ  >= 5 and bsszxj = 0))", connection);
                command.ExecuteNonQuery();
                command.Dispose();
                command = new SqlCommand("update " + pXBTableName + " set bsszxj = cast(floor(((0.36445+1.94272/([BSSZSG]+2))*[BSSZSG]*[BSSZGQDM]*10+0.5))/10*[YXMJ] as decimal)  where ((bssz >=100 and bssz <=114) or (bssz >=130 and bssz <=132) or (bssz >=150 and bssz <=162)) and ((BSSZPJXJ >= 5 and (LEN(RTRIM(LTRIM(BHYY)))=2 or bhyy is not null) and ltrim(rtrim(bhyy)) <> '80') or (BSSZPJXJ  >= 5 and bsszxj = 0))", connection);
                command.ExecuteNonQuery();
                command.Dispose();
                command = new SqlCommand("update " + pXBTableName + " set bsszxj = isnull(cast(floor(((0.43853+1.15672/nullif(([BSSZSG]-1),0))*[BSSZSG]*[BSSZGQDM]*10+0.5))/10*[YXMJ] as decimal),0)  where bssz >=140 and bssz <=142 and ((BSSZPJXJ >= 5 and (LEN(RTRIM(LTRIM(BHYY)))=2 or bhyy is not null) and ltrim(rtrim(bhyy)) <> '80') or (BSSZPJXJ  >= 5 and bsszxj = 0))", connection);
                command.ExecuteNonQuery();
                command.Dispose();
                command = new SqlCommand("update " + pXBTableName + " set bsszxj = isnull(cast(floor(((0.37970+1.00761/nullif([BSSZSG],0))*[BSSZSG]*[BSSZGQDM]*10+0.5))/10* [YXMJ] as decimal),0)  where ((bssz >=280 and bssz <=285) or (bssz >=310 and bssz <=320)) and ((BSSZPJXJ >= 5 and (LEN(RTRIM(LTRIM(BHYY)))=2 or bhyy is not null) and ltrim(rtrim(bhyy)) <> '80') or (BSSZPJXJ  >= 5 and bsszxj = 0))", connection);
                command.ExecuteNonQuery();
                command.Dispose();
                command = new SqlCommand("update " + pXBTableName + " set bsszxj = isnull(cast(floor(([BSSZGQDM]*[BSSZSG]*0.97670866*Power(cast(nullif([BSSZPJXJ],0) as numeric(18,8)),-0.068428604)*Power(cast(nullif([BSSZSG],0) as numeric(18,8)),-0.18596012)*10+0.5))/10 * [YXMJ] as decimal),0)  where bssz >=290 and bssz <=307 and ((BSSZPJXJ >= 5 and (LEN(RTRIM(LTRIM(BHYY)))=2 or bhyy is not null) and ltrim(rtrim(bhyy)) <> '80') or (BSSZPJXJ  >= 5 and bsszxj = 0))", connection);
                command.ExecuteNonQuery();
                command.Dispose();
                command = new SqlCommand("update " + pXBTableName + " set bsszxj = cast(floor(([BSSZGQDM]*0.386*([BSSZSG]+3)*10+0.5))/10 * [YXMJ] as decimal)  where bssz >=220 and bssz <=230 and ((BSSZPJXJ >= 5 and (LEN(RTRIM(LTRIM(BHYY)))=2 or bhyy is not null) and ltrim(rtrim(bhyy)) <> '80') or (BSSZPJXJ  >= 5 and bsszxj = 0))", connection);
                command.ExecuteNonQuery();
                command.Dispose();
                command = new SqlCommand("update " + pXBTableName + " set bsszxj = cast(floor(((0.40489+3.37866/([BSSZSG]+20))*[BSSZSG]*[BSSZGQDM]*10+0.5))/10 * [YXMJ] as decimal)  where ((bssz='211' or bssz='212' or bssz >=240 and bssz <=273) or (bssz >=330 and bssz <=351) or bssz='617' or (bssz >=635 and bssz <=703 and bssz not in('636','638','644','661','662','671','673','687','698','702','703'))) and ((BSSZPJXJ >= 5 and (LEN(RTRIM(LTRIM(BHYY)))=2 or bhyy is not null) and ltrim(rtrim(bhyy)) <> '80') or (BSSZPJXJ  >= 5 and bsszxj = 0))", connection);
                command.ExecuteNonQuery();
                command.Dispose();
                str2 = "";
            }
            catch (Exception exception)
            {
                str2 = "方法CalculateXJ_BHYY计算有变化原因小班蓄积出错，可能的原因：" + exception.Message;
            }
            finally
            {
                GC.Collect();
            }
            return str2;
        }

        private DataTable GetDataBySql(string sql)
        {
            DataTable table = null; ;
            try
            {
                //if (pDBAccess.Connection == null)
                //{
                //    MessageBox.Show("本地数据库连接无效，无法查询数据！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //}
                //if (pDBAccess.Connection.State != ConnectionState.Open)
                //{
                //    pDBAccess.Connection.Open();
                //}
                //DbDataAdapter dBDataAdapter = pDBAccess.GetDBDataAdapter(sql, false);
                //DataSet dataSet = new DataSet();
                //dBDataAdapter.Fill(dataSet);
                //table = dataSet.Tables[0];
            }
            catch (Exception exception)
            {
                MessageBox.Show("方法GetDataBySql查询数据出错，可能的原因：" + exception.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                table = null;
            }
            finally
            {
                GC.Collect();
            }
            return table;
        }
    }
}

