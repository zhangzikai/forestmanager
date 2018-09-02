namespace EarthBusiness
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.Runtime.CompilerServices;
    using System.Text;
    using System.Windows.Forms;

    public class ClsDbHandler
    {
        [CompilerGenerated]
     
        private SqlDataAdapter m_adapter;
        private SqlCommand m_cmd;
        private SqlConnection m_conn;
        private string m_connString = string.Empty;
        private SqlDataReader m_reader;
        private string m_sql = string.Empty;

        private void CloseConnection()
        {
            if ((this.m_reader != null) && !this.m_reader.IsClosed)
            {
                this.m_reader.Close();
            }
            if (this.m_adapter != null)
            {
                this.m_adapter.Dispose();
            }
            if ((this.m_conn != null) && (this.m_conn.State != ConnectionState.Closed))
            {
                this.m_conn.Close();
            }
        }

        private DataTable ConvertDataTable(DataTable dt)
        {
            if ((dt == null) || (dt.Rows.Count <= 0))
            {
                return null;
            }
            dt.Columns.Add(new DataColumn("面积变化值（公顷）"));
            dt.Columns.Add(new DataColumn("面积变化率%"));
            dt.Columns.Add(new DataColumn("蓄积变化值（立方米）"));
            dt.Columns.Add(new DataColumn("蓄积变化率%"));
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if ((dt.Rows[i][4] == DBNull.Value) || (dt.Rows[i][1] == DBNull.Value))
                {
                    return null;
                }
                dt.Rows[i][6] = Math.Round((double) (Convert.ToDouble(dt.Rows[i][4]) - Convert.ToDouble(dt.Rows[i][1])), 1);
                if ((dt.Rows[i][1] != DBNull.Value) && (Convert.ToDouble(dt.Rows[i][1]) > 0.0))
                {
                    dt.Rows[i][7] = Math.Round((double) ((Convert.ToDouble(dt.Rows[i][6]) * 100.0) / Convert.ToDouble(dt.Rows[i][1])), 2);
                }
                else
                {
                    dt.Rows[i][7] = 100;
                }
                dt.Rows[i][8] = Math.Round((double) (Convert.ToDouble(dt.Rows[i][5]) - Convert.ToDouble(dt.Rows[i][2])), 1);
                if (Convert.ToDouble(dt.Rows[i][2]) > 0.0)
                {
                    dt.Rows[i][9] = Math.Round((double) ((Convert.ToDouble(dt.Rows[i][8]) * 100.0) / Convert.ToDouble(dt.Rows[i][2])), 2);
                }
                else
                {
                    dt.Rows[i][9] = 100;
                }
            }
            DataTable table = new DataTable();
            DataRow row = null;
            table.Columns.Add(new DataColumn("内容"));
            table.Columns.Add(new DataColumn("结果"));
            for (int j = 0; j < dt.Columns.Count; j++)
            {
                row = table.NewRow();
                row["内容"] = dt.Columns[j].Caption;
                row["结果"] = dt.Rows[0][j];
                table.Rows.Add(row);
            }
            return table;
        }

        private DataTable ConvertForestStatisTable(DataTable dt)
        {
            try
            {
                if ((dt != null) && (dt.Rows.Count > 0))
                {
                    DataTable table = new DataTable();
                    DataRow row = null;
                    string columnName = "统计分类";
                    string str2 = dt.Rows[0][0].ToString();
                    string str3 = dt.Rows[1][0].ToString();
                    string str4 = "变化值";
                    string str5 = "变化率%";
                    table.Columns.Add(new DataColumn(columnName, typeof(string)));
                    table.Columns.Add(new DataColumn(str2, typeof(decimal)));
                    table.Columns.Add(new DataColumn(str3, typeof(decimal)));
                    table.Columns.Add(new DataColumn(str4, typeof(decimal)));
                    table.Columns.Add(new DataColumn(str5, typeof(decimal)));
                    for (int i = 1; i < dt.Columns.Count; i++)
                    {
                        object obj2 = null;
                        object obj3 = null;
                        if (dt.Rows[0][i] != DBNull.Value)
                        {
                            obj2 = dt.Rows[0][i];
                        }
                        if (dt.Rows[1][i] != DBNull.Value)
                        {
                            obj3 = dt.Rows[1][i];
                        }
                        if ((Convert.ToDouble(obj2) > 0.0) || (Convert.ToDouble(obj3) > 0.0))
                        {
                            row = table.NewRow();
                            row[columnName] = dt.Columns[i].Caption;
                            row[str2] = Convert.ToDouble(obj2);
                            row[str3] = Convert.ToDouble(obj3);
                            row[str4] = Math.Round((double) (Convert.ToDouble(obj3) - Convert.ToDouble(obj2)), 1);
                            if (Convert.ToDouble(obj2) == 0.0)
                            {
                                row[str5] = 100;
                            }
                            else
                            {
                                row[str5] = Math.Round((double) (((Convert.ToDouble(obj3) - Convert.ToDouble(obj2)) * 100.0) / Convert.ToDouble(obj2)), 2);
                            }
                            table.Rows.Add(row);
                        }
                    }
                    return table;
                }
                return null;
            }
            catch (Exception exception)
            {
                MessageBox.Show("方法ConvertForestStatisTable转换森林资源统计表出错，可能的原因：" + exception.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return null;
            }
        }

        private DataTable ConvertLindTotalDataTable(DataTable dt, string count)
        {
            try
            {
                if (((dt != null) && (dt.Rows.Count == 1)) && !string.IsNullOrEmpty(count))
                {
                    DataTable table = new DataTable();
                    dt.Columns.Add(new DataColumn("斑块数"));
                    for (int i = 0; i < dt.Columns.Count; i++)
                    {
                        table.Columns.Add(new DataColumn(dt.Columns[i].Caption));
                    }
                    table.Columns.Add(new DataColumn("林地净增"));
                    table.Rows[0][0] = count;
                    table.Rows[0][1] = dt.Rows[0][1];
                    table.Rows[0][2] = dt.Rows[0][2];
                    if ((dt.Rows[0][1] != DBNull.Value) && (dt.Rows[0][2] != DBNull.Value))
                    {
                        table.Rows[0][3] = Math.Round((double) (Convert.ToDouble(dt.Rows[0][1]) - Convert.ToDouble(dt.Rows[0][2])), 2);
                    }
                    return table;
                }
                return null;
            }
            catch (Exception exception)
            {
                MessageBox.Show("方法ConvertLindTotalDataTable转换林地概要信息出错，可能的原因：" + exception.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
            }
        }

        private DataTable ConvertXBTable(DataTable dt, SqlConnection conn, string tableName)
        {
            try
            {
                if (dt == null)
                {
                    return null;
                }
                if (conn == null)
                {
                    conn = new SqlConnection(this.SqlConnectionString);
                }
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                if (!string.IsNullOrEmpty(tableName))
                {
                    dt.Columns.Add(new DataColumn("表名"));
                }
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dt.Rows[i][1] = this.GetNameByAdminCode(conn, dt.Rows[i][1].ToString());
                    dt.Rows[i][2] = this.GetNameByAdminCode(conn, dt.Rows[i][2].ToString());
                    if (!string.IsNullOrEmpty(tableName))
                    {
                        dt.Rows[i][4] = tableName;
                    }
                }
                return dt;
            }
            catch (Exception exception)
            {
                MessageBox.Show("方法ConvertXBTable转换小班信息出错，可能的原因：" + exception.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return null;
            }
        }

        private ForestStatisInfo DoFGLStatis(string whereClause)
        {
            ForestStatisInfo info2;
            try
            {
                this.OpenConnection();
                ForestStatisInfo info = new ForestStatisInfo();
                DataTable dt = new DataTable();
                DataTable dataTable = new DataTable();
                int num = Convert.ToInt32(this.UpdateYear) - 1;
                this.m_sql = "select " + num.ToString() + " as 年份,sum(case when LEFT(DI_LEI,2) = '11' then CONVERT(decimal(18,1),MIAN_JI) else 0 end) as 乔木林面积,sum(case when DI_LEI = '120' then CONVERT(decimal(18,1),MIAN_JI) else 0 end) as 红树林面积,sum(case when DI_LEI = '130' then CONVERT(decimal(18,1),MIAN_JI) else 0 end) as 竹林面积,sum(case when DI_LEI = '301' then CONVERT(decimal(18,1),MIAN_JI) else 0 end) as 国特灌面积,round(sum(sszzs)/1650,1) as 四旁树折算面积,sum(case when DI_LEI = '961' then CONVERT(decimal(18,1),MIAN_JI) else 0 end) as 农地乔木林面积,sum(case when DI_LEI = '962' or DI_LEI = '963' then CONVERT(decimal(18,1),MIAN_JI) else 0 end) as 农地经济林面积,sum(case when DI_LEI = '964' then CONVERT(decimal(18,1),MIAN_JI) else 0 end) as 农地竹林面积,sum(CONVERT(decimal(18,1),MIAN_JI)) as 土地总面积 from FOR_XIAOBAN_" + num.ToString() + whereClause;
                this.m_cmd = new SqlCommand(this.m_sql, this.m_conn);
                this.m_adapter = new SqlDataAdapter();
                this.m_adapter.SelectCommand = this.m_cmd;
                this.m_adapter.Fill(dataTable);
                dt.Merge(dataTable);
                dataTable.Clear();
                this.m_sql = "select " + this.UpdateYear + " as 年份,sum(case when LEFT(DI_LEI,2) = '11' then CONVERT(decimal(18,1),MIAN_JI) else 0 end) as 乔木林面积,sum(case when DI_LEI = '120' then CONVERT(decimal(18,1),MIAN_JI) else 0 end) as 红树林面积,sum(case when DI_LEI = '130' then CONVERT(decimal(18,1),MIAN_JI) else 0 end) as 竹林面积,sum(case when DI_LEI = '301' then CONVERT(decimal(18,1),MIAN_JI) else 0 end) as 国特灌面积,round(sum(sszzs)/1650,1) as 四旁树折算面积,sum(case when DI_LEI = '961' then CONVERT(decimal(18,1),MIAN_JI) else 0 end) as 农地乔木林面积,sum(case when DI_LEI = '962' or DI_LEI = '963' then CONVERT(decimal(18,1),MIAN_JI) else 0 end) as 农地经济林面积,sum(case when DI_LEI = '964' then CONVERT(decimal(18,1),MIAN_JI) else 0 end) as 农地竹林面积,sum(CONVERT(decimal(18,1),MIAN_JI)) as 土地总面积 from FOR_XIAOBAN_" + this.UpdateYear + whereClause;
                this.m_cmd = new SqlCommand(this.m_sql, this.m_conn);
                this.m_adapter = new SqlDataAdapter();
                this.m_adapter.SelectCommand = this.m_cmd;
                this.m_adapter.Fill(dataTable);
                dt.Merge(dataTable);
                dataTable.Clear();
                info.Bar = this.ConvertForestStatisTable(dt);
                info.Smemo = this.GetFGLSmemo(info.Bar);
                info2 = info;
            }
            catch (Exception exception)
            {
                MessageBox.Show("方法DoFGLStatis统计森林覆盖率出错，可能的原因：" + exception.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                info2 = null;
            }
            finally
            {
                this.CloseConnection();
                GC.Collect();
            }
            return info2;
        }

        private ForestStatisInfo DoLDStatis(string whereClause)
        {
            ForestStatisInfo info2;
            try
            {
                this.OpenConnection();
                ForestStatisInfo info = new ForestStatisInfo();
                DataTable dt = new DataTable();
                DataTable dataTable = new DataTable();
                int num = Convert.ToInt32(this.UpdateYear) - 1;
                this.m_sql = "select " + num.ToString() + " as 年份,sum(case when LEFT(DI_LEI,2) = '11' then CONVERT(decimal(18,1),YXMJ) else 0 end) as 乔木林,sum(case when DI_LEI = '120' then CONVERT(decimal(18,1),YXMJ) else 0 end) as 红树林,sum(case when DI_LEI = '130' then CONVERT(decimal(18,1),YXMJ) else 0 end) as 竹林,sum(case when DI_LEI = '200' then CONVERT(decimal(18,1),YXMJ) else 0 end) as 疏林地,sum(case when LEFT(DI_LEI,1) = '3' then CONVERT(decimal(18,1),YXMJ) else 0 end) as 灌木林地,sum(case when LEFT(DI_LEI,1)= '4' then CONVERT(decimal(18,1),YXMJ) else 0 end) as 未成林地,sum(case when DI_LEI = '500' then CONVERT(decimal(18,1),MIAN_JI) else 0 end) as 苗圃,sum(case when LEFT(DI_LEI,1)= '6' then CONVERT(decimal(18,1),YXMJ) else 0 end) as 无立木林地,sum(case when LEFT(DI_LEI,1)= '7' then CONVERT(decimal(18,1),YXMJ) else 0 end) as 宜林地,sum(case when DI_LEI = '800' then CONVERT(decimal(18,1),YXMJ) else 0 end) as 林业辅助用地,sum(case when LEFT(DI_LEI,1)= '9' then CONVERT(decimal(18,1),YXMJ) else 0 end) as 非林地,sum(case when LEFT(DI_LEI,1) <> '9' then CONVERT(decimal(18,1),YXMJ) else 0 end) as 林地,sum(case when LEFT(DI_LEI,1) = '1' then CONVERT(decimal(18,1),YXMJ) else 0 end) as 有林地,sum(CONVERT(decimal(18,1),YXMJ)) as 土地总面积 from FOR_XIAOBAN_" + num.ToString() + whereClause;
                this.m_cmd = new SqlCommand(this.m_sql, this.m_conn);
                this.m_adapter = new SqlDataAdapter();
                this.m_adapter.SelectCommand = this.m_cmd;
                this.m_adapter.Fill(dataTable);
                dt.Merge(dataTable);
                dataTable.Clear();
                this.m_sql = "select " + this.UpdateYear + " as 年份,sum(case when LEFT(DI_LEI,2) = '11' then CONVERT(decimal(18,1),YXMJ) else 0 end) as 乔木林,sum(case when DI_LEI = '120' then CONVERT(decimal(18,1),YXMJ) else 0 end) as 红树林,sum(case when DI_LEI = '130' then CONVERT(decimal(18,1),YXMJ) else 0 end) as 竹林,sum(case when DI_LEI = '200' then CONVERT(decimal(18,1),YXMJ) else 0 end) as 疏林地,sum(case when LEFT(DI_LEI,1) = '3' then CONVERT(decimal(18,1),YXMJ) else 0 end) as 灌木林地,sum(case when LEFT(DI_LEI,1)= '4' then CONVERT(decimal(18,1),YXMJ) else 0 end) as 未成林地,sum(case when DI_LEI = '500' then CONVERT(decimal(18,1),YXMJ) else 0 end) as 苗圃,sum(case when LEFT(DI_LEI,1)= '6' then CONVERT(decimal(18,1),YXMJ) else 0 end) as 无立木林地,sum(case when LEFT(DI_LEI,1)= '7' then CONVERT(decimal(18,1),YXMJ) else 0 end) as 宜林地,sum(case when DI_LEI = '800' then CONVERT(decimal(18,1),YXMJ) else 0 end) as 林业辅助用地,sum(case when LEFT(DI_LEI,1)= '9' then CONVERT(decimal(18,1),YXMJ) else 0 end) as 非林地,sum(case when LEFT(DI_LEI,1) <> '9' then CONVERT(decimal(18,1),YXMJ) else 0 end) as 林地,sum(case when LEFT(DI_LEI,1) = '1' then CONVERT(decimal(18,1),YXMJ) else 0 end) as 有林地,sum(CONVERT(decimal(18,1),YXMJ)) as 土地总面积 from FOR_XIAOBAN_" + this.UpdateYear + whereClause;
                this.m_cmd = new SqlCommand(this.m_sql, this.m_conn);
                this.m_adapter = new SqlDataAdapter();
                this.m_adapter.SelectCommand = this.m_cmd;
                this.m_adapter.Fill(dataTable);
                dt.Merge(dataTable);
                dataTable.Clear();
                info.Bar = this.ConvertForestStatisTable(dt);
                info.Smemo = this.GetLDStatisSmemo(info.Bar);
                info2 = info;
            }
            catch (Exception exception)
            {
                MessageBox.Show("方法DoLDStatis统计林地面积出错，可能的原因：" + exception.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                info2 = null;
            }
            finally
            {
                this.CloseConnection();
                GC.Collect();
            }
            return info2;
        }

        private ForestStatisInfo DoXJStatis(string whereClause)
        {
            ForestStatisInfo info2;
            try
            {
                this.OpenConnection();
                ForestStatisInfo info = new ForestStatisInfo();
                DataTable dt = new DataTable();
                DataTable dataTable = new DataTable();
                int num = Convert.ToInt32(this.UpdateYear) - 1;
                this.m_sql = "select " + num.ToString() + " as 年份,sum(case when (LEFT(YOU_SHI_SZ,2)='11') or (YOU_SHI_SZ>'130' and YOU_SHI_SZ<'200') then CONVERT(decimal(18,0),zxj) else 0 end) as 松类蓄积,sum(case when (LEFT(YOU_SHI_SZ,2)='12') then CONVERT(decimal(18,0),zxj) else 0 end) as 杉类蓄积,sum(case when YOU_SHI_SZ>='280' and YOU_SHI_SZ<='307' then CONVERT(decimal(18,0),zxj) else 0 end) as 桉类蓄积,sum(case when (YOU_SHI_SZ>='200' and YOU_SHI_SZ<'280') or (YOU_SHI_SZ>='310' and YOU_SHI_SZ<'400') or (YOU_SHI_SZ>'600' and YOU_SHI_SZ<'800') then CONVERT(decimal(18,0),zxj) else 0 end) as 阔叶树蓄积,sum(case when LEFT(YOU_SHI_SZ,1)='4' then CONVERT(decimal(18,0),zxj) else 0 end) as 竹林蓄积,sum(case when LEFT(YOU_SHI_SZ,1) = '5' or YOU_SHI_SZ='' or YOU_SHI_SZ=null then CONVERT(decimal(18,0),zxj) else 0 end) as 其他树种蓄积,sum(CONVERT(decimal(18,0),zxj)) as 总蓄积 from FOR_XIAOBAN_" + num.ToString() + whereClause;
                this.m_cmd = new SqlCommand(this.m_sql, this.m_conn);
                this.m_adapter = new SqlDataAdapter();
                this.m_adapter.SelectCommand = this.m_cmd;
                this.m_adapter.Fill(dataTable);
                dt.Merge(dataTable);
                dataTable.Clear();
                this.m_sql = "select " + this.UpdateYear + " as 年份,sum(case when (LEFT(YOU_SHI_SZ,2)='11') or (YOU_SHI_SZ>'130' and YOU_SHI_SZ<'200') then CONVERT(decimal(18,0),zxj) else 0 end) as 松类蓄积,sum(case when (LEFT(YOU_SHI_SZ,2)='12') then CONVERT(decimal(18,0),zxj) else 0 end) as 杉类蓄积,sum(case when YOU_SHI_SZ>='280' and YOU_SHI_SZ<='307' then CONVERT(decimal(18,0),zxj) else 0 end) as 桉类蓄积,sum(case when (YOU_SHI_SZ>='200' and YOU_SHI_SZ<'280') or (YOU_SHI_SZ>='310' and YOU_SHI_SZ<'400') or (YOU_SHI_SZ>'600' and YOU_SHI_SZ<'800') then CONVERT(decimal(18,0),zxj) else 0 end) as 阔叶树蓄积,sum(case when LEFT(YOU_SHI_SZ,1)='4' then CONVERT(decimal(18,0),zxj) else 0 end) as 竹林蓄积,sum(case when LEFT(YOU_SHI_SZ,1) = '5' or YOU_SHI_SZ='' or YOU_SHI_SZ=null then CONVERT(decimal(18,0),zxj) else 0 end) as 其他树种蓄积,sum(CONVERT(decimal(18,0),zxj)) as 总蓄积 from FOR_XIAOBAN_" + this.UpdateYear + whereClause;
                this.m_cmd = new SqlCommand(this.m_sql, this.m_conn);
                this.m_adapter = new SqlDataAdapter();
                this.m_adapter.SelectCommand = this.m_cmd;
                this.m_adapter.Fill(dataTable);
                dt.Merge(dataTable);
                dataTable.Clear();
                info.Bar = this.ConvertForestStatisTable(dt);
                info.Smemo = this.GetXJStatisSmemo(info.Bar);
                info2 = info;
            }
            catch (Exception exception)
            {
                MessageBox.Show("方法DoXJStatis统计活立木蓄积量出错，可能的原因：" + exception.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                info2 = null;
            }
            finally
            {
                this.CloseConnection();
                GC.Collect();
            }
            return info2;
        }

        public DataTable GetAdminComboSource(string pcode)
        {
            DataTable table2;
            try
            {
                DataTable dataTable = new DataTable();
                this.OpenConnection();
                if (string.IsNullOrEmpty(pcode))
                {
                    this.m_sql = "select CCODE,CNAME from T_SYS_LD_ADMIN_CODES where len(CCODE)=6";
                }
                else
                {
                    this.m_sql = "select CCODE,CNAME from T_SYS_LD_ADMIN_CODES where PCODE='" + pcode + "'";
                }
                this.m_cmd = new SqlCommand(this.m_sql, this.m_conn);
                this.m_adapter = new SqlDataAdapter();
                this.m_adapter.SelectCommand = this.m_cmd;
                this.m_adapter.Fill(dataTable);
                table2 = dataTable;
            }
            catch (Exception exception)
            {
                MessageBox.Show("方法GetAdminComboSource出错，可能的原因：" + exception.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                table2 = null;
            }
            finally
            {
                this.CloseConnection();
                GC.Collect();
            }
            return table2;
        }

        public AdminLocateStatisInfo GetAdminLocateStaticInfo(string code, string text)
        {
            AdminLocateStatisInfo info2;
            try
            {
                this.OpenConnection();
                AdminLocateStatisInfo info = new AdminLocateStatisInfo();
                this.m_sql = "select SHAPE.STAsText() from ";
                string str = string.Empty;
                if (code.Length == 6)
                {
                    this.m_sql = this.m_sql + "BASE_P_XIAN_10K";
                    str = str + " XIAN='" + code + "'";
                }
                else if (code.Length == 9)
                {
                    this.m_sql = this.m_sql + "BASE_P_XIANG_10K where XIANG='" + code + "'";
                    str = str + " XIANG='" + code + "'";
                }
                else
                {
                    this.m_sql = this.m_sql + "BASE_P_CUN_10K where CUN='" + code + "'";
                    str = str + " CUN='" + code + "'";
                }
                this.m_cmd = new SqlCommand(this.m_sql, this.m_conn);
                this.m_reader = this.m_cmd.ExecuteReader();
                while (this.m_reader.Read())
                {
                    if (this.m_reader.GetValue(0) != DBNull.Value)
                    {
                        info.GeoString = Convert.ToString(this.m_reader.GetValue(0));
                    }
                }
                this.m_reader.Close();
                this.m_sql = "select sum(case when LEFT(DI_LEI,1) <> '9' then CONVERT(decimal(18,1),MIAN_JI) else 0 end) as 林地面积,sum(CONVERT(decimal(18,0),zxj)) as 活立木总蓄积,sum(case when LEFT(DI_LEI,1) = '1' or DI_LEI='301' or LEFT(DI_LEI,2)='96' then CONVERT(decimal(18,1),MIAN_JI) else 0 end)as 森林面积,round(sum(sszzs)/1650,1) as 四旁树折算面积,sum(CONVERT(decimal(18,1),MIAN_JI)) as 总面积 from FOR_XIAOBAN_" + this.UpdateYear + " where " + str;
                StringBuilder builder = new StringBuilder();
                this.m_cmd = new SqlCommand(this.m_sql, this.m_conn);
                this.m_reader = this.m_cmd.ExecuteReader();
                double num = 0.0;
                double num2 = 0.0;
                double num3 = 0.0;
                while (this.m_reader.Read())
                {
                    if (this.m_reader.GetValue(0) != DBNull.Value)
                    {
                        builder.Append("林地面积：").Append(Convert.ToString(this.m_reader.GetValue(0))).Append("公顷，");
                    }
                    if (this.m_reader.GetValue(1) != DBNull.Value)
                    {
                        builder.Append("活立木蓄积：").Append(Convert.ToString(this.m_reader.GetValue(1))).Append("立方米，");
                    }
                    if (this.m_reader.GetValue(2) != DBNull.Value)
                    {
                        num = Convert.ToDouble(this.m_reader.GetValue(2));
                    }
                    if (this.m_reader.GetValue(3) != DBNull.Value)
                    {
                        num2 = Convert.ToDouble(this.m_reader.GetValue(3));
                    }
                    if (this.m_reader.GetValue(4) != DBNull.Value)
                    {
                        num3 = Convert.ToDouble(this.m_reader.GetValue(4));
                    }
                }
                if (num3 > 0.0)
                {
                    builder.Append("森林覆盖率：").Append(Math.Round((double) (((num + num2) * 100.0) / num3), 2)).Append("%。");
                }
                info.ForestInfo = builder.ToString();
                info2 = info;
            }
            catch (Exception exception)
            {
                MessageBox.Show("方法GetAdminLocateGeoString查询定位信息出错，可能的原因" + exception.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                info2 = null;
            }
            finally
            {
                this.CloseConnection();
                GC.Collect();
            }
            return info2;
        }

        public List<CodeName> GetAdminLocateTreeData(string pcode)
        {
            List<CodeName> list2;
            try
            {
                List<CodeName> list = new List<CodeName>();
                this.OpenConnection();
                if (string.IsNullOrEmpty(pcode))
                {
                    this.m_sql = "select CCODE,CNAME from T_SYS_LD_ADMIN_CODES where len(CCODE)=6";
                }
                else
                {
                    this.m_sql = "select CCODE,CNAME from T_SYS_LD_ADMIN_CODES where PCODE='" + pcode + "'";
                }
                this.m_cmd = new SqlCommand(this.m_sql, this.m_conn);
                this.m_reader = this.m_cmd.ExecuteReader();
                while (this.m_reader.Read())
                {
                    if ((this.m_reader.GetValue(0) != DBNull.Value) && (this.m_reader.GetValue(1) != DBNull.Value))
                    {
                        CodeName item = new CodeName();
                        item.Code = Convert.ToString(this.m_reader.GetValue(0));
                        item.Name = Convert.ToString(this.m_reader.GetValue(1));
                        list.Add(item);
                    }
                }
                this.m_reader.Close();
                list2 = list;
            }
            catch (Exception exception)
            {
                MessageBox.Show("方法GetAdminLocateInfo出错，可能的原因：" + exception.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                list2 = null;
            }
            finally
            {
                GC.Collect();
            }
            return list2;
        }

        public LindQueryResult GetBusinessQueryResult(string tableName)
        {
            LindQueryResult result2;
            try
            {
                LindQueryResult result = new LindQueryResult();
                StringBuilder builder = new StringBuilder();
                builder.Append("select count(*) as 斑块数").Append(", sum(convert(decimal(18,1),MIAN_JI)) as 总面积").Append(" from ").Append(tableName);
                this.OpenConnection();
                DataTable dataTable = new DataTable();
                this.m_cmd = new SqlCommand(builder.ToString(), this.m_conn);
                this.m_adapter = new SqlDataAdapter();
                this.m_adapter.SelectCommand = this.m_cmd;
                this.m_adapter.Fill(dataTable);
                result.CountArea = dataTable;
                builder = new StringBuilder();
                builder.Append("select OBJECTID as 编号,XIANG as 乡名,CUN as 村名,LIN_BAN as 林班,SHAPE.STCentroid().STAsText() as POINT from ").Append(tableName);
                DataTable table2 = new DataTable();
                this.m_cmd = new SqlCommand(builder.ToString(), this.m_conn);
                this.m_adapter = new SqlDataAdapter();
                this.m_adapter.SelectCommand = this.m_cmd;
                this.m_adapter.Fill(table2);
                result.XB = this.ConvertXBTable(this.GetXbInfoFromDataTable(table2), this.m_conn, tableName);
                result.Points = this.GetLabelXbInfoFromDataTable(table2, tableName);
                result2 = result;
            }
            catch (Exception exception)
            {
                MessageBox.Show("方法GetBusinessQueryResult查询业务数据出错，可能的原因" + exception.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                result2 = null;
            }
            finally
            {
                this.CloseConnection();
                GC.Collect();
            }
            return result2;
        }

        public DataTable GetDataBySQL(string sql)
        {
            DataTable table2;
            try
            {
                DataTable dataTable = new DataTable();
                this.OpenConnection();
                this.m_cmd = new SqlCommand(sql, this.m_conn);
                this.m_adapter = new SqlDataAdapter();
                this.m_adapter.SelectCommand = this.m_cmd;
                this.m_adapter.Fill(dataTable);
                table2 = dataTable;
            }
            catch (Exception exception)
            {
                MessageBox.Show("方法GetDataBySQL查询数据出错，可能的原因：" + exception.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                table2 = null;
            }
            finally
            {
                this.CloseConnection();
                GC.Collect();
            }
            return table2;
        }

        private string GetFGLSmemo(DataTable dt)
        {
            try
            {
                if ((dt != null) && (dt.Rows.Count > 0))
                {
                    string str = string.Empty;
                    double num = 0.0;
                    double num2 = 0.0;
                    double num3 = 0.0;
                    double num4 = 0.0;
                    double num5 = 0.0;
                    StringBuilder builder = new StringBuilder();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        str = dt.Rows[i][0].ToString();
                        if (str.Equals("土地总面积"))
                        {
                            num3 = Convert.ToDouble(dt.Rows[i][2]);
                        }
                        else
                        {
                            num2 = Convert.ToDouble(dt.Rows[i][1]);
                            num = Convert.ToDouble(dt.Rows[i][2]);
                            num4 += num;
                            num5 += num2;
                            builder.Append(str).Append("为：").Append(num).Append("公顷；");
                        }
                    }
                    StringBuilder builder2 = new StringBuilder();
                    builder2.Append(dt.Columns[2].Caption);
                    builder2.Append("年森林覆盖率为：").Append(Math.Round((double) ((num4 * 100.0) / num3), 2)).Append("%，森林面积为：");
                    builder2.Append(num4).Append("公顷，").Append(builder.ToString());
                    builder2.Append("比上一年度的森林覆盖率");
                    if ((num4 - num5) > 0.0)
                    {
                        builder2.Append("增加了");
                    }
                    else
                    {
                        builder2.Append("减少了");
                    }
                    builder2.Append(Math.Round((double) ((Math.Abs((double) (num4 - num5)) * 100.0) / num3), 2)).Append("%。");
                    return builder2.ToString();
                }
                return string.Empty;
            }
            catch (Exception exception)
            {
                MessageBox.Show("方法GetFGLSmemo生成森林覆盖率的统计说明出错，可能的原因：" + exception.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return string.Empty;
            }
        }

        public DataTable GetFirstBHYY()
        {
            DataTable table2;
            try
            {
                DataTable dataTable = new DataTable();
                this.m_sql = "select CCODE,CNAME from T_SYS_META_CODE where CTYPE='变化原因' and right(CCODE,1)='0' and left(CCODE,1) in (select distinct left(bhyy,1) from V_LD_ZT_" + this.UpdateYear + ")";
                this.m_cmd = new SqlCommand(this.m_sql, this.m_conn);
                this.m_adapter = new SqlDataAdapter();
                this.m_adapter.SelectCommand = this.m_cmd;
                this.m_adapter.Fill(dataTable);
                table2 = dataTable;
            }
            catch (Exception exception)
            {
                MessageBox.Show("方法GetFirstBHYY获取一级变化原因出错，可能的原因" + exception.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                table2 = null;
            }
            finally
            {
                this.CloseConnection();
                GC.Collect();
            }
            return table2;
        }

        public ForestQueryInfo GetForestThemQueryResult(string pcode, string whereClause)
        {
            ForestQueryInfo info2;
            try
            {
                ForestQueryInfo info = new ForestQueryInfo();
                string str = string.Empty;
                switch (pcode.Length)
                {
                    case 6:
                        if (!whereClause.Contains("where"))
                        {
                            str = " where " + whereClause;
                        }
                        break;

                    case 9:
                        if (!whereClause.Contains("where"))
                        {
                            str = " where XIANG='" + pcode + "' and (" + whereClause + ")";
                        }
                        else
                        {
                            str = whereClause + " and XIANG='" + pcode + "'";
                        }
                        break;

                    case 12:
                        if (!whereClause.Contains("where"))
                        {
                            str = " where CUN='" + pcode + "' and (" + whereClause + ")";
                        }
                        else
                        {
                            str = whereClause + " and CUN='" + pcode + "'";
                        }
                        break;
                }
                StringBuilder builder = new StringBuilder();
                int num = Convert.ToInt32(this.UpdateYear) - 1;
                builder.Append("select * from(");
                StringBuilder introduced11 = builder.Append("select count(*) as 斑块数").Append(num.ToString()).Append(", sum(convert(decimal(18,1),YXMJ)) as 面积");
                StringBuilder introduced12 = introduced11.Append(num.ToString()).Append(",sum(convert(decimal(18,1),ZXJ)) as 蓄积");
                StringBuilder introduced13 = introduced12.Append(num.ToString()).Append(" from FOR_XIAOBAN_");
                introduced13.Append(num.ToString()).Append(str);
                builder.Append(")a cross join(");
                builder.Append("select count(*) as 斑块数").Append(this.UpdateYear).Append(", sum(convert(decimal(18,1),YXMJ)) as 面积").Append(this.UpdateYear).Append(",sum(convert(decimal(18,1),ZXJ)) as 蓄积").Append(this.UpdateYear).Append(" from FOR_XIAOBAN_").Append(this.UpdateYear).Append(str);
                builder.Append(")b");
                this.OpenConnection();
                DataTable dataTable = new DataTable();
                this.m_cmd = new SqlCommand(builder.ToString(), this.m_conn);
                this.m_adapter = new SqlDataAdapter();
                this.m_adapter.SelectCommand = this.m_cmd;
                this.m_adapter.Fill(dataTable);
                info.Total = this.ConvertDataTable(dataTable);
                DataTable table2 = new DataTable();
                builder = new StringBuilder();
                builder.Append("select OBJECTID as 编号,XIANG as 乡名,CUN as 村名,LIN_BAN as 林班 from FOR_XIAOBAN_").Append(this.UpdateYear).Append(str);
                builder.Append(" order by CUN");
                this.m_cmd = new SqlCommand(builder.ToString(), this.m_conn);
                this.m_adapter = new SqlDataAdapter();
                this.m_adapter.SelectCommand = this.m_cmd;
                this.m_adapter.Fill(table2);
                info.XB = this.ConvertXBTable(table2, this.m_conn, "FOR_XIAOBAN_" + this.UpdateYear);
                info2 = info;
            }
            catch (Exception exception)
            {
                MessageBox.Show("方法GetForestThemQueryResult查询森林资源专题信息出错，可能的原因：" + exception.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                info2 = null;
            }
            finally
            {
                this.CloseConnection();
                GC.Collect();
            }
            return info2;
        }

        public ForestStatisInfo GetForStatisData(int content, string pCode)
        {
            string whereClause = string.Empty;
            if (pCode.Length == 6)
            {
                whereClause = whereClause + " where XIAN='" + pCode + "'";
            }
            if (pCode.Length == 9)
            {
                whereClause = whereClause + " where XIANG='" + pCode + "'";
            }
            if (pCode.Length == 12)
            {
                whereClause = whereClause + " where CUN='" + pCode + "'";
            }
            switch (content)
            {
                case 1:
                    return this.DoLDStatis(whereClause);

                case 2:
                    return this.DoXJStatis(whereClause);

                case 3:
                    return this.DoFGLStatis(whereClause);
            }
            return null;
        }

        private List<PointLabel> GetLabelXbInfoFromDataTable(DataTable dt, string tableName)
        {
            if (((dt == null) || (dt.Columns.Count <= 0)) || (dt.Rows.Count <= 0))
            {
                return null;
            }
            DataTable table = dt.Copy();
            List<PointLabel> list = new List<PointLabel>();
            for (int i = 0; i < table.Rows.Count; i++)
            {
                PointLabel item = new PointLabel();
                if (table.Rows[i][0] != DBNull.Value)
                {
                    item.OID = Convert.ToInt32(table.Rows[i][0].ToString());
                }
                if (string.IsNullOrEmpty(tableName))
                {
                    item.TableName = table.Rows[i][5].ToString();
                }
                else
                {
                    item.TableName = tableName;
                }
                if (table.Rows[i][4] != DBNull.Value)
                {
                    string str = table.Rows[i][4].ToString();
                    string str2 = str.Substring(7, str.LastIndexOf(" ") - 7);
                    item.X = Convert.ToDouble(str2);
                    string str3 = str.Substring(str.LastIndexOf(" ") + 1, (str.Length - str.LastIndexOf(" ")) - 2);
                    item.Y = Convert.ToDouble(str3);
                }
                list.Add(item);
            }
            return list;
        }

        private string GetLDStatisSmemo(DataTable dt)
        {
            try
            {
                if ((dt != null) && (dt.Rows.Count > 0))
                {
                    string str = string.Empty;
                    double num = 0.0;
                    double num2 = 0.0;
                    double num3 = 0.0;
                    double num4 = 0.0;
                    double num5 = 0.0;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        str = dt.Rows[i][0].ToString();
                        if (str.Equals("有林地"))
                        {
                            num3 = Convert.ToDouble(dt.Rows[i][2]);
                            num5 = Convert.ToDouble(dt.Rows[i][3]);
                        }
                        else if (str.Equals("林地"))
                        {
                            num2 = Convert.ToDouble(dt.Rows[i][2]);
                            num4 = Convert.ToDouble(dt.Rows[i][3]);
                        }
                        else if (str.Equals("土地总面积"))
                        {
                            num = Convert.ToDouble(dt.Rows[i][2]);
                        }
                    }
                    StringBuilder builder = new StringBuilder();
                    builder.Append(dt.Columns[2].Caption);
                    builder.Append("年土地总面积为：").Append(num).Append("公顷，林地面积为：").Append(num2).Append("公顷，占");
                    builder.Append(Math.Round((double) ((num2 * 100.0) / num), 2)).Append("%，比上年度");
                    if (num4 > 0.0)
                    {
                        builder.Append("增加了");
                    }
                    else
                    {
                        builder.Append("减少了");
                    }
                    builder.Append(Math.Abs(num4)).Append("公顷；有林地面积为：").Append(num3).Append("公顷，占");
                    builder.Append(Math.Round((double) ((num3 * 100.0) / num), 2)).Append("%，比上年度");
                    if (num5 > 0.0)
                    {
                        builder.Append("增加了");
                    }
                    else
                    {
                        builder.Append("减少了");
                    }
                    builder.Append(Math.Abs(num5)).Append("公顷。");
                    return builder.ToString();
                }
                return string.Empty;
            }
            catch (Exception exception)
            {
                MessageBox.Show("方法GetLDStatisSmemo生成林地面积统计说明出错，可能的原因：" + exception.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return string.Empty;
            }
        }

        public DataTable GetLinBanComboSource(string cun, string lb)
        {
            DataTable table2;
            try
            {
                if (string.IsNullOrEmpty(cun))
                {
                    return null;
                }
                this.OpenConnection();
                if (string.IsNullOrEmpty(lb))
                {
                    this.m_sql = "select distinct LIN_BAN from FOR_XIAOBAN_" + this.UpdateYear + " where CUN='" + cun + "' order by LIN_BAN";
                }
                else
                {
                    this.m_sql = "select XIAO_BAN from FOR_XIAOBAN_" + this.UpdateYear + " where CUN='" + cun + "' and LIN_BAN='" + lb + "' order by XIAO_BAN";
                }
                this.m_cmd = new SqlCommand(this.m_sql, this.m_conn);
                this.m_adapter = new SqlDataAdapter();
                this.m_adapter.SelectCommand = this.m_cmd;
                DataTable dataTable = new DataTable();
                this.m_adapter.Fill(dataTable);
                table2 = dataTable;
            }
            catch (Exception exception)
            {
                MessageBox.Show("方法GetLinBanComboSource查询林班号出错，可能的原因" + exception.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                table2 = null;
            }
            finally
            {
                this.CloseConnection();
                GC.Collect();
            }
            return table2;
        }

        public LindResultQuery GetLindUpdateResult()
        {
            LindResultQuery query2;
            try
            {
                LindResultQuery query = new LindResultQuery();
                StringBuilder builder = new StringBuilder();
                builder.Append("林地变更斑块数为：");
                this.m_sql = "SELECT COUNT(*) AS 斑块数 FROM FOR_XIAOBAN_" + this.UpdateYear + " WHERE LEFT(BHYY,1)='1' OR LEFT(BHYY,1)='3' OR BHYY = '41'";
                this.OpenConnection();
                this.m_cmd = new SqlCommand(this.m_sql, this.m_conn);
                this.m_reader = this.m_cmd.ExecuteReader();
                while (this.m_reader.Read())
                {
                    if (this.m_reader.GetValue(0) == DBNull.Value)
                    {
                        builder.Append("0。");
                    }
                    else
                    {
                        builder.Append(this.m_reader.GetValue(0).ToString()).Append("个。");
                    }
                }
                this.m_reader.Close();
                this.m_sql = "SELECT SUM(CASE WHEN (LEFT(BHYY,1)='1' OR LEFT(BHYY,1)='3') AND (LEFT(Q_DI_LEI,1)='9' AND LEFT(DI_LEI,1)<>'9') THEN CONVERT(DECIMAL(18,2),MIAN_JI) ELSE 0 END) AS 新增林地,SUM(CASE WHEN BHYY='41' AND (LEFT(Q_DI_LEI,1)<>'9' AND LEFT(DI_LEI,1)='9') THEN CONVERT(DECIMAL(18,2),MIAN_JI) ELSE 0 END) AS 减少林地 FROM FOR_XIAOBAN_" + this.UpdateYear;
                this.m_cmd = new SqlCommand(this.m_sql, this.m_conn);
                this.m_reader = this.m_cmd.ExecuteReader();
                builder.Append("新增林地面积为：");
                while (this.m_reader.Read())
                {
                    if (this.m_reader.GetValue(0) == DBNull.Value)
                    {
                        builder.Append("0，");
                    }
                    else
                    {
                        builder.Append(this.m_reader.GetValue(0).ToString()).Append("公顷，");
                    }
                    builder.Append("减少林地面积为：");
                    if (this.m_reader.GetValue(1) == DBNull.Value)
                    {
                        builder.Append("0。");
                    }
                    else
                    {
                        builder.Append(this.m_reader.GetValue(1).ToString()).Append("公顷。");
                    }
                }
                query.TotalInfor = builder.ToString();
                this.m_reader.Close();
                this.m_sql = "SELECT OBJECTID AS 编号,XIANG AS 乡名,CUN AS 村名,LIN_BAN AS 林班,SHAPE.STCentroid().STAsText() AS POINT FROM FOR_XIAOBAN_" + this.UpdateYear + " WHERE (LEFT(BHYY,1)='1' OR LEFT(BHYY,1)='3') AND (LEFT(Q_DI_LEI,1)='9' AND LEFT(DI_LEI,1)<>'9')";
                DataTable dataTable = new DataTable();
                this.m_cmd = new SqlCommand(this.m_sql, this.m_conn);
                this.m_adapter = new SqlDataAdapter();
                this.m_adapter.SelectCommand = this.m_cmd;
                this.m_adapter.Fill(dataTable);
                query.XBAdd = this.ConvertXBTable(this.GetXbInfoFromDataTable(dataTable), this.m_conn, "FOR_XIAOBAN_2013");
                query.PointsAdd = this.GetLabelXbInfoFromDataTable(dataTable, "FOR_XIAOBAN_2013");
                this.m_sql = "SELECT OBJECTID AS 编号,XIANG AS 乡名,CUN AS 村名,LIN_BAN AS 林班,SHAPE.STCentroid().STAsText() AS POINT FROM FOR_XIAOBAN_" + this.UpdateYear + " WHERE BHYY='41' AND (LEFT(Q_DI_LEI,1)<>'9' AND LEFT(DI_LEI,1)='9')";
                DataTable table2 = new DataTable();
                this.m_cmd = new SqlCommand(this.m_sql, this.m_conn);
                this.m_adapter = new SqlDataAdapter();
                this.m_adapter.SelectCommand = this.m_cmd;
                this.m_adapter.Fill(table2);
                query.XBPlus = this.ConvertXBTable(this.GetXbInfoFromDataTable(table2), this.m_conn, "FOR_XIAOBAN_2013");
                query.PointsPlus = this.GetLabelXbInfoFromDataTable(table2, "FOR_XIAOBAN_2013");
                query2 = query;
            }
            catch (Exception exception)
            {
                MessageBox.Show("方法GetLindUpdateResult查询林地变更概要信息出错，可能的原因：" + exception.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                query2 = null;
            }
            finally
            {
                this.CloseConnection();
            }
            return query2;
        }

        public XbIdentifyInfo GetLocateGeoStringByCode(string code)
        {
            XbIdentifyInfo info2;
            try
            {
                this.OpenConnection();
                XbIdentifyInfo info = new XbIdentifyInfo();
                this.m_sql = "select SHAPE.STAsText() from ";
                string str = string.Empty;
                if (code.Length == 9)
                {
                    this.m_sql = this.m_sql + "BASE_P_XIANG_10K where XIANG='" + code + "'";
                    str = str + " where XIANG='" + code + "'";
                }
                else if (code.Length == 12)
                {
                    this.m_sql = this.m_sql + "BASE_P_CUN_10K where CUN='" + code + "'";
                    str = str + " where CUN='" + code + "'";
                }
                else if (code.Length == 0x10)
                {
                    string sql = this.m_sql;
                    this.m_sql = sql + "BASE_P_LINBAN_10K where CUN='" + code.Substring(0, 12) + "' and LIN_BAN='" + code.Substring(12) + "'";
                }
                this.m_cmd = new SqlCommand(this.m_sql, this.m_conn);
                this.m_reader = this.m_cmd.ExecuteReader();
                while (this.m_reader.Read())
                {
                    if (this.m_reader.GetValue(0) != DBNull.Value)
                    {
                        info.GeoString = Convert.ToString(this.m_reader.GetValue(0));
                    }
                }
                this.m_reader.Close();
                info2 = info;
            }
            catch (Exception exception)
            {
                MessageBox.Show("方法GetLocateGeoStringByCode查询定位信息出错，可能的原因" + exception.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                info2 = null;
            }
            finally
            {
                this.CloseConnection();
                GC.Collect();
            }
            return info2;
        }

        private object GetNameByAdminCode(SqlConnection conn, string code)
        {
            try
            {
                SqlDataReader reader = null;
                object obj2 = null;
                if (conn == null)
                {
                    conn = new SqlConnection(this.SqlConnectionString);
                }
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                reader = new SqlCommand("select CNAME from T_SYS_LD_ADMIN_CODES where CCODE='" + code + "'", conn).ExecuteReader();
                while (reader.Read())
                {
                    if (reader.GetValue(0) != DBNull.Value)
                    {
                        obj2 = reader.GetValue(0);
                    }
                }
                reader.Close();
                return obj2;
            }
            catch (Exception exception)
            {
                MessageBox.Show("方法GetNameByAdminCode查询行政单位名称出错，可能的原因" + exception.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return null;
            }
        }

        public DataTable GetSecondBHYY(string bhyy)
        {
            DataTable table2;
            try
            {
                DataTable dataTable = new DataTable();
                this.m_sql = "select CCODE,CNAME from T_SYS_META_CODE where CTYPE='变化原因' and CCODE in (select distinct BHYY from V_LD_ZT_" + this.UpdateYear + " where left(bhyy,1)='" + bhyy + "')";
                this.m_cmd = new SqlCommand(this.m_sql, this.m_conn);
                this.m_adapter = new SqlDataAdapter();
                this.m_adapter.SelectCommand = this.m_cmd;
                this.m_adapter.Fill(dataTable);
                table2 = dataTable;
            }
            catch (Exception exception)
            {
                MessageBox.Show("方法GetSecondBHYY获取二级变化原因出错，可能的原因" + exception.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                table2 = null;
            }
            finally
            {
                this.CloseConnection();
                GC.Collect();
            }
            return table2;
        }

        public string GetThemAreaXJString(string whereClause)
        {
            string str3;
            try
            {
                if (string.IsNullOrEmpty(whereClause))
                {
                    return string.Empty;
                }
                StringBuilder builder = new StringBuilder();
                builder.Append("SELECT SUM(CONVERT(DECIMAL(18,1),YXMJ)) AS MJ, SUM(CONVERT(DECIMAL(18,1),ZXJ)) AS XJ FROM FOR_XIAOBAN_");
                builder.Append(this.UpdateYear).Append(" WHERE ").Append(whereClause);
                this.OpenConnection();
                this.m_cmd = new SqlCommand(builder.ToString(), this.m_conn);
                this.m_reader = this.m_cmd.ExecuteReader();
                string str = "0";
                string str2 = "0";
                while (this.m_reader.Read())
                {
                    if (this.m_reader.GetValue(0) != DBNull.Value)
                    {
                        str = Convert.ToString(this.m_reader.GetValue(0));
                    }
                    if (this.m_reader.GetValue(1) != DBNull.Value)
                    {
                        str2 = Convert.ToString(this.m_reader.GetValue(1));
                    }
                }
                builder = new StringBuilder();
                builder.Append("面积为：").Append(str).Append("公顷；").Append("蓄积为：").Append(str2).Append("立方米");
                str3 = builder.ToString();
            }
            catch (Exception exception)
            {
                MessageBox.Show("方法GetThemAreaXJString查询森林资源专题信息出错，可能的原因：" + exception.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                str3 = null;
            }
            finally
            {
                this.CloseConnection();
                GC.Collect();
            }
            return str3;
        }

        public XbIdentifyInfo GetXbInfoByLonLatOrXbid(double lon, double lat, string xbid)
        {
            XbIdentifyInfo info;
            try
            {
                if (string.IsNullOrEmpty(this.UpdateYear))
                {
                    MessageBox.Show("请先设置数据年度再进行小班查询", "提示", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return null;
                }
                this.OpenConnection();
                StringBuilder builder = new StringBuilder();
                builder.Append("select ");
                this.m_sql = "select fiel_na from T_SYS_META_FIELDS where tab_id = (select tab_id from T_SYS_META_TABLE where tab_name='FOR_XIAOBAN_" + this.UpdateYear + "')";
                this.m_cmd = new SqlCommand(this.m_sql, this.m_conn);
                this.m_reader = this.m_cmd.ExecuteReader();
                while (this.m_reader.Read())
                {
                    if (this.m_reader.GetValue(0) != DBNull.Value)
                    {
                        builder.Append(this.m_reader.GetValue(0).ToString());
                        builder.Append(",");
                    }
                }
                this.m_reader.Close();
                builder.Append("SHAPE.STAsText() as GEOSTRING");
                builder.Append(" from FOR_XIAOBAN_").Append(this.UpdateYear);
                if (string.IsNullOrEmpty(xbid))
                {
                    builder.Append(" where SHAPE.STIntersects(geometry :: STPointFromText('POINT(").Append(lon).Append(" ").Append(lat).Append(")',4610))=1");
                }
                else
                {
                    builder.Append(" where CUN='").Append(xbid.Substring(0, 12)).Append("' and LIN_BAN='").Append(xbid.Substring(12, 4)).Append("' and XIAO_BAN='").Append(xbid.Substring(0x10)).Append("'");
                }
                this.m_sql = builder.ToString();
                this.m_cmd = new SqlCommand(this.m_sql, this.m_conn);
                this.m_adapter = new SqlDataAdapter();
                this.m_adapter.SelectCommand = this.m_cmd;
                DataTable dataTable = new DataTable();
                this.m_adapter.Fill(dataTable);
                info = this.TranslateXbInfo(dataTable, "FOR_XIAOBAN_" + this.UpdateYear);
            }
            catch (Exception exception)
            {
                MessageBox.Show("方法GetXbInfoByLonLat点击查询小班信息出错，可能的原因" + exception.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                info = null;
            }
            finally
            {
                this.CloseConnection();
                GC.Collect();
            }
            return info;
        }

        private DataTable GetXbInfoFromDataTable(DataTable dt)
        {
            if (((dt != null) && (dt.Rows.Count > 0)) && (dt.Columns.Count > 0))
            {
                DataTable table = dt.Copy();
                table.Columns.Remove("POINT");
                return table;
            }
            return null;
        }

        private string GetXJStatisSmemo(DataTable dt)
        {
            try
            {
                if ((dt != null) && (dt.Rows.Count > 0))
                {
                    string str = string.Empty;
                    double num = 0.0;
                    double num2 = 0.0;
                    double num3 = 0.0;
                    StringBuilder builder = new StringBuilder();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        str = dt.Rows[i][0].ToString();
                        num = Convert.ToDouble(dt.Rows[i][2]);
                        if (str.Equals("总蓄积"))
                        {
                            num2 = Convert.ToDouble(dt.Rows[i][2]);
                            num3 = Convert.ToDouble(dt.Rows[i][3]);
                        }
                        else
                        {
                            builder.Append(str).Append("为：").Append(num).Append("立方米；");
                        }
                    }
                    StringBuilder builder2 = new StringBuilder();
                    builder2.Append(dt.Columns[2].Caption);
                    builder2.Append("年活立木总蓄积为：").Append(num2).Append("立方米，其中：").Append(builder.ToString());
                    builder2.Append("对比上一年度，活立木总蓄积");
                    if (num3 > 0.0)
                    {
                        builder2.Append("增加了");
                    }
                    else
                    {
                        builder2.Append("减少了");
                    }
                    builder2.Append(Math.Abs(num3)).Append("立方米。");
                    return builder2.ToString();
                }
                return string.Empty;
            }
            catch (Exception exception)
            {
                MessageBox.Show("方法GetXJStatisSmemo生成活立木蓄积量的统计说明出错，可能的原因：" + exception.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return string.Empty;
            }
        }

        public XbIdentifyInfo GetZTXbInfoByOid(int oid, string tableName)
        {
            XbIdentifyInfo info;
            try
            {
                if ((oid < 0) || string.IsNullOrEmpty(tableName))
                {
                    return null;
                }
                this.OpenConnection();
                StringBuilder builder = new StringBuilder();
                builder.Append("select ");
                this.m_sql = "select fiel_na from T_SYS_META_FIELDS where tab_id = (select tab_id from T_SYS_META_TABLE where tab_name='" + tableName + "')";
                this.m_cmd = new SqlCommand(this.m_sql, this.m_conn);
                this.m_reader = this.m_cmd.ExecuteReader();
                while (this.m_reader.Read())
                {
                    if (this.m_reader.GetValue(0) != DBNull.Value)
                    {
                        builder.Append(this.m_reader.GetValue(0).ToString());
                        builder.Append(",");
                    }
                }
                this.m_reader.Close();
                builder.Append("SHAPE.STAsText() as GEOSTRING from ").Append(tableName);
                builder.Append(" where objectid=").Append(oid);
                this.m_sql = builder.ToString();
                this.m_cmd = new SqlCommand(this.m_sql, this.m_conn);
                this.m_adapter = new SqlDataAdapter();
                this.m_adapter.SelectCommand = this.m_cmd;
                DataTable dataTable = new DataTable();
                this.m_adapter.Fill(dataTable);
                info = this.TranslateXbInfo(dataTable, tableName);
            }
            catch (Exception exception)
            {
                MessageBox.Show("方法GetZYXbInfoByOid查询专题小班信息出错，可能的原因" + exception.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                info = null;
            }
            finally
            {
                this.CloseConnection();
                GC.Collect();
            }
            return info;
        }

        private void OpenConnection()
        {
            if (this.m_conn == null)
            {
                this.m_conn = new SqlConnection(this.SqlConnectionString);
            }
            if (this.m_conn.State != ConnectionState.Open)
            {
                this.m_conn.Open();
            }
        }

        private string QueryFieldAlias(SqlConnection conn, string tableId, string fieldName)
        {
            SqlDataReader reader = null;
            try
            {
                if (conn == null)
                {
                    conn = new SqlConnection(this.SqlConnectionString);
                }
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                string str = string.Empty;
                reader = new SqlCommand("select FIEL_AL from T_SYS_META_FIELDS where TAB_ID='" + tableId + "' and FIEL_NA='" + fieldName + "'", conn).ExecuteReader();
                while (reader.Read())
                {
                    if (reader.GetValue(0) != DBNull.Value)
                    {
                        str = reader.GetValue(0).ToString();
                    }
                }
                reader.Close();
                return str;
            }
            catch (Exception exception)
            {
                MessageBox.Show("方法QueryFieldAlias查询小班表字段别名出错，可能的原因" + exception.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return null;
            }
        }

        private object QueryFieldValue(SqlConnection conn, string tabId, string fieldName, object fieldValue)
        {
            SqlDataReader reader = null;
            try
            {
                if (conn == null)
                {
                    conn = new SqlConnection(this.SqlConnectionString);
                }
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                reader = new SqlCommand("select CODE_IND,FIEL_TY from T_SYS_META_FIELDS where TAB_ID='" + tabId + "' and FIEL_NA='" + fieldName + "'", conn).ExecuteReader();
                string str2 = string.Empty;
                string str3 = string.Empty;
                while (reader.Read())
                {
                    if (reader.GetValue(0) != DBNull.Value)
                    {
                        str2 = reader.GetValue(0).ToString();
                    }
                    if (reader.GetValue(1) != DBNull.Value)
                    {
                        str3 = reader.GetValue(1).ToString();
                    }
                }
                reader.Close();
                if (string.IsNullOrEmpty(str2))
                {
                    if (!string.IsNullOrEmpty(str3))
                    {
                        double num;
                        if (str3.ToLower().Contains("varchar"))
                        {
                            return fieldValue;
                        }
                        if (fieldValue == DBNull.Value)
                        {
                            return fieldValue;
                        }
                        if (double.TryParse(fieldValue.ToString(), out num))
                        {
                            return Math.Round(num, 2);
                        }
                    }
                    return fieldValue;
                }
                string str4 = string.Empty;
                reader = new SqlCommand(string.Concat(new object[] { "select CNAME from T_SYS_META_CODE where CINDEX='", str2, "' and CCODE='", fieldValue, "'" }), conn).ExecuteReader();
                while (reader.Read())
                {
                    if (reader.GetValue(0) != DBNull.Value)
                    {
                        str4 = reader.GetValue(0).ToString();
                    }
                }
                reader.Close();
                return str4;
            }
            catch (Exception exception)
            {
                MessageBox.Show("方法QueryFieldValue查询小班表字段值出错，可能的原因" + exception.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return null;
            }
        }

        public LindQueryResult QueryLindByBhyy(string where)
        {
            LindQueryResult result2;
            try
            {
                this.OpenConnection();
                LindQueryResult result = new LindQueryResult();
                new List<PointLabel>();
                string str = string.Empty;
                if (!where.Contains("where"))
                {
                    str = str + " where ";
                }
                str = str + where;
                this.m_sql = "select count(*) as 变化斑块数,sum(convert(decimal(18,2),MIAN_JI)) as 变化总面积 from V_LD_ZT_" + this.UpdateYear + str;
                DataTable dataTable = new DataTable();
                this.m_cmd = new SqlCommand(this.m_sql, this.m_conn);
                this.m_adapter = new SqlDataAdapter();
                this.m_adapter.SelectCommand = this.m_cmd;
                this.m_adapter.Fill(dataTable);
                result.CountArea = dataTable;
                this.m_sql = "select OBJECTID as 编号,XIANG as 乡名,CUN as 村名,LIN_BAN as 林班,SHAPE.STCentroid().STAsText() as POINT,tablename as 表名 from V_LD_ZT_" + this.UpdateYear + str;
                DataTable table2 = new DataTable();
                this.m_cmd = new SqlCommand(this.m_sql, this.m_conn);
                this.m_adapter = new SqlDataAdapter();
                this.m_adapter.SelectCommand = this.m_cmd;
                this.m_adapter.Fill(table2);
                result.XB = this.ConvertXBTable(this.GetXbInfoFromDataTable(table2), this.m_conn, string.Empty);
                result.Points = this.GetLabelXbInfoFromDataTable(table2, string.Empty);
                result2 = result;
            }
            catch (Exception exception)
            {
                MessageBox.Show("方法QueryLindByBhyy查询林地变更信息出错，可能的原因" + exception.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                result2 = null;
            }
            finally
            {
                this.CloseConnection();
                GC.Collect();
            }
            return result2;
        }

        private XbIdentifyInfo TranslateXbInfo(DataTable dt, string tableName)
        {
            XbIdentifyInfo info2;
            try
            {
                this.OpenConnection();
                XbIdentifyInfo info = new XbIdentifyInfo();
                this.m_sql = "select TAB_ID from T_SYS_META_TABLE where TAB_NAME='" + tableName + "'";
                this.m_cmd = new SqlCommand(this.m_sql, this.m_conn);
                this.m_reader = this.m_cmd.ExecuteReader();
                string str = string.Empty;
                while (this.m_reader.Read())
                {
                    if (this.m_reader.GetValue(0) != DBNull.Value)
                    {
                        str = Convert.ToString(this.m_reader.GetValue(0));
                    }
                }
                this.m_reader.Close();
                if (string.IsNullOrEmpty(str))
                {
                    return null;
                }
                DataTable table = new DataTable();
                table.Columns.Add(new DataColumn("调查因子"));
                table.Columns.Add(new DataColumn("调查值"));
                DataRow row = null;
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    string fieldName = dt.Columns[i].Caption.ToUpper();
                    object fieldValue = dt.Rows[0][i];
                    if (fieldName.Contains("GEOSTRING"))
                    {
                        info.GeoString = fieldValue.ToString();
                    }
                    else
                    {
                        row = table.NewRow();
                        row["调查因子"] = this.QueryFieldAlias(this.m_conn, str, fieldName);
                        row["调查值"] = this.QueryFieldValue(this.m_conn, str, fieldName, fieldValue);
                        table.Rows.Add(row);
                    }
                }
                info.XbInfoTable = table;
                info2 = info;
            }
            catch (Exception exception)
            {
                MessageBox.Show("方法TranslateXbInfo汉化小班信息出错，可能的原因" + exception.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                info2 = null;
            }
            finally
            {
                this.CloseConnection();
                GC.Collect();
            }
            return info2;
        }

        public string SqlConnectionString
        {
            get
            {
                return this.m_connString;
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    this.m_connString = value;
                    this.OpenConnection();
                }
            }
        }

        public string UpdateYear
        {
            get;
            set;
        }
    }
}

