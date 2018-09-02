namespace Tj
{
    using System;
    using System.ComponentModel;
    using System.Data;
    using System.Data.SqlClient;
    using System.Diagnostics;
    using System.Windows.Forms;
    using TJ_DLL;

    public class ExportZYBHTable
    {
        private int pLastND;
        private int pNowND;
        private string pTable_Code;
        private string pTable_OriXB_last;
        private string pTable_OriXB_now;
        private string pTable_slszhb;
        private string pTable_XB_last;
        private string pTable_XB_now;
        private string pTable_yclszhb;

        private void Export(string pConnecting, string pDataBaseName, string pXLSFileName)
        {
            string xlsModelPath = Application.StartupPath + @"\森林资源动态统计表表头.xls";
            SqlConnection connection = this.SQLDataConfig(pConnecting, pDataBaseName);
            connection.Open();
            this.pNowND = int.Parse(pDataBaseName.Substring(pDataBaseName.Length - 4, 4));
            this.pLastND = this.pNowND - 1;
            this.pTable_OriXB_now = string.Concat(new object[] { "[", pDataBaseName, "].[dbo].[FOR_XIAOBAN_", this.pNowND, "]" });
            this.pTable_OriXB_last = string.Concat(new object[] { "[", pDataBaseName, "].[dbo].[FOR_XIAOBAN_", this.pLastND, "]" });
            this.pTable_XB_now = "[" + pDataBaseName + "].[dbo].[XBSZMERGE_NOW]";
            this.pTable_XB_last = "[" + pDataBaseName + "].[dbo].[XBSZMERGE_LAST]";
            this.pTable_Code = "[" + pDataBaseName + "].[dbo].[T_SYS_META_CODE]";
            this.pTable_slszhb = "[" + pDataBaseName + "].[dbo].[T_SYS_META_SLSZHB]";
            this.pTable_yclszhb = "[" + pDataBaseName + "].[dbo].[T_SYS_META_YCLSZHB]";
            SqlCommand selectCommand = new SqlCommand("select top 1 * from " + this.pTable_OriXB_now, connection);
            selectCommand.CommandTimeout = 60;
            SqlDataAdapter adapter = new SqlDataAdapter(selectCommand);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            string str3 = "";
            for (int i = 0; i < dataTable.Columns.Count; i++)
            {
                string columnName = dataTable.Columns[i].ColumnName;
                if (columnName.ToLower().ToString().Trim() != "shape")
                {
                    str3 = str3 + columnName + ",";
                }
            }
            selectCommand = new SqlCommand(" use " + pDataBaseName + " if not exists (select name from sysobjects where [name] = 'XBSZMERGE_NOW' and xtype='U') begin select " + str3.TrimEnd(new char[] { ',' }) + " into " + this.pTable_XB_now + " from " + this.pTable_OriXB_now + " alter table " + this.pTable_XB_now + " add szmerge varchar(10) alter table " + this.pTable_XB_now + " add szmerge_xj varchar(10) end else begin drop table " + this.pTable_XB_now + " select " + str3.TrimEnd(new char[] { ',' }) + " into " + this.pTable_XB_now + " from " + this.pTable_OriXB_now + " alter table " + this.pTable_XB_now + " add szmerge varchar(10) alter table " + this.pTable_XB_now + " add szmerge_xj varchar(10) end", connection);
            selectCommand.CommandTimeout = 60;
            adapter = new SqlDataAdapter(selectCommand);
            DataTable table2 = new DataTable();
            adapter.Fill(table2);
            selectCommand = new SqlCommand(" use " + pDataBaseName + " if not exists (select name from sysobjects where [name] = 'XBSZMERGE_LAST' and xtype='U') begin select " + str3.TrimEnd(new char[] { ',' }) + " into " + this.pTable_XB_last + " from " + this.pTable_OriXB_last + " alter table " + this.pTable_XB_last + " add szmerge varchar(10) alter table " + this.pTable_XB_last + " add szmerge_xj varchar(10) end else begin drop table " + this.pTable_XB_last + " select " + str3.TrimEnd(new char[] { ',' }) + " into " + this.pTable_XB_last + " from " + this.pTable_OriXB_last + " alter table " + this.pTable_XB_last + " add szmerge varchar(10) alter table " + this.pTable_XB_last + " add szmerge_xj varchar(10) end", connection);
            selectCommand.CommandTimeout = 60;
            adapter = new SqlDataAdapter(selectCommand);
            table2 = new DataTable();
            adapter.Fill(table2);
            selectCommand = new SqlCommand("update " + this.pTable_XB_last + " set mian_ji = convert(decimal(18,1),MIAN_JI),yxmj = convert(decimal(18,1),yxmj),xzwmj = convert(decimal(18,1),xzwmj)", connection);
            selectCommand.CommandTimeout = 60;
            adapter = new SqlDataAdapter(selectCommand);
            table2 = new DataTable();
            adapter.Fill(table2);
            selectCommand = new SqlCommand("update " + this.pTable_XB_now + " set mian_ji = convert(decimal(18,1),MIAN_JI),yxmj = convert(decimal(18,1),yxmj),xzwmj = convert(decimal(18,1),xzwmj)", connection);
            selectCommand.CommandTimeout = 60;
            adapter = new SqlDataAdapter(selectCommand);
            table2 = new DataTable();
            adapter.Fill(table2);
            selectCommand = new SqlCommand(" select cname from " + this.pTable_Code + " where ccode='" + pDataBaseName.Substring(8, 6) + "' and CTYPE = '县'", connection);
            selectCommand.CommandTimeout = 60;
            adapter = new SqlDataAdapter(selectCommand);
            connection.Close();
            table2 = new DataTable();
            adapter.Fill(table2);
            string tjdwmc = table2.Rows[0][0].ToString();
            DataSet tjds = new DataSet("tjds");
            try
            {
                double num26;
                string str6;
                selectCommand = new SqlCommand(this.pSQL_ZYBH_B1_GLTDMJBHB(), connection);
                selectCommand.CommandTimeout = 60;
                adapter = new SqlDataAdapter(selectCommand);
                connection.Close();
                table2 = new DataTable();
                adapter.Fill(table2);
                if (table2.Columns.CanRemove(table2.Columns["tjdw"]))
                {
                    table2.Columns.Remove(table2.Columns["tjdw"]);
                }
                table2.TableName = "b1";
                table2.Columns.Add("id");
                DataTable table = new DataTable();
                table = table2.Copy();
                table.Clear();
                DataTable table4 = new DataTable();
                table4 = table2.Copy();
                table4.Clear();
                int num2 = 0;
            Label_0658:
                if (num2 >= table2.Rows.Count)
                {
                    goto Label_0C77;
                }
                double d = num2;
                d /= 2.0;
                table2.Rows[num2]["id"] = ((Math.Floor(d) * 2.0) + num2) + 1.0;
                if (((num2 + 1) % 2) != 0)
                {
                    goto Label_0C61;
                }
                DataRow row = table.NewRow();
                DataRow row2 = table4.NewRow();
                int num4 = 0;
            Label_06DA:
                if (num4 < table2.Columns.Count)
                {
                    try
                    {
                        switch (num4)
                        {
                            case 0:
                                row[num4] = table2.Rows[num2][num4].ToString();
                                row2[num4] = table2.Rows[num2][num4].ToString();
                                goto Label_0C6C;

                            case 1:
                                row[num4] = "变化量";
                                row2[num4] = "变化率(%)";
                                goto Label_0C6C;
                        }
                        if (table2.Columns[num4].ColumnName == "森林覆盖率")
                        {
                            num26 = Convert.ToDouble(table2.Rows[num2]["森林覆盖率"]) - Convert.ToDouble(table2.Rows[num2 - 1]["森林覆盖率"]);
                            row[num4] = num26.ToString("f2");
                            num26 = (Convert.ToDouble(table2.Rows[num2]["森林覆盖率"]) - Convert.ToDouble(table2.Rows[num2 - 1]["森林覆盖率"])) / Convert.ToDouble(table2.Rows[num2 - 1]["森林覆盖率"]);
                            row2[num4] = num26.ToString("f2");
                        }
                        else if (table2.Columns[num4].ColumnName == "林木覆盖率")
                        {
                            num26 = Convert.ToDouble(table2.Rows[num2]["林木覆盖率"]) - Convert.ToDouble(table2.Rows[num2 - 1]["林木覆盖率"]);
                            row[num4] = num26.ToString("f2");
                            num26 = (Convert.ToDouble(table2.Rows[num2]["林木覆盖率"]) - Convert.ToDouble(table2.Rows[num2 - 1]["林木覆盖率"])) / Convert.ToDouble(table2.Rows[num2 - 1]["林木覆盖率"]);
                            row2[num4] = num26.ToString("f2");
                        }
                        else if (((num4 + 1) % 2) == 0)
                        {
                            row[num4] = Convert.ToDouble((double) (double.Parse(table2.Rows[num2][num4].ToString()) - double.Parse(table2.Rows[num2 - 1][num4].ToString()))).ToString("f1");
                            if (double.Parse(table2.Rows[num2 - 1][num4].ToString()) != 0.0)
                            {
                                try
                                {
                                    num26 = Convert.ToDouble((double) ((double.Parse(table2.Rows[num2][num4].ToString()) - double.Parse(table2.Rows[num2 - 1][num4].ToString())) / double.Parse(table2.Rows[num2 - 1][num4].ToString()))) * 100.0;
                                    row2[num4] = num26.ToString("f1");
                                }
                                catch
                                {
                                    row2[num4] = 0;
                                }
                            }
                            else
                            {
                                row2[num4] = 0;
                            }
                        }
                        else
                        {
                            row[num4] = Convert.ToDouble((double) (double.Parse(table2.Rows[num2][num4].ToString()) - double.Parse(table2.Rows[num2 - 1][num4].ToString()))).ToString("f1");
                            if (double.Parse(table2.Rows[num2 - 1][num4].ToString()) != 0.0)
                            {
                                try
                                {
                                    num26 = Convert.ToDouble((double) ((double.Parse(table2.Rows[num2][num4].ToString()) - double.Parse(table2.Rows[num2 - 1][num4].ToString())) / double.Parse(table2.Rows[num2 - 1][num4].ToString()))) * 100.0;
                                    row2[num4] = num26.ToString("f1");
                                }
                                catch
                                {
                                    row2[num4] = 0;
                                }
                            }
                            else
                            {
                                row2[num4] = 0;
                            }
                        }
                    }
                    catch
                    {
                    }
                    goto Label_0C6C;
                }
                row["id"] = (((Math.Floor(d) * 2.0) + num2) + 1.0) + 1.0;
                row2["id"] = (((Math.Floor(d) * 2.0) + num2) + 1.0) + 2.0;
                table.Rows.Add(row);
                table4.Rows.Add(row2);
            Label_0C61:
                num2++;
                goto Label_0658;
            Label_0C6C:
                num4++;
                goto Label_06DA;
            Label_0C77:
                table2.Merge(table);
                table2.Merge(table4);
                table2.Columns.Add("Sortid", typeof(double));
                foreach (DataRow row3 in table2.Rows)
                {
                    row3["Sortid"] = Convert.ToDouble(row3["id"]);
                }
                DataView view = new DataView(table2);
                view.Sort = "Sortid";
                DataTable table5 = new DataTable();
                table2 = view.ToTable();
                table2.Columns.Remove("id");
                table2.Columns.Remove("Sortid");
                for (int j = 0; j < table2.Rows.Count; j++)
                {
                    for (int num6 = 0; num6 < table2.Columns.Count; num6++)
                    {
                        if (((table2.Rows[j][num6].ToString().Trim() == "0.00") || (table2.Rows[j][num6].ToString().Trim() == "0.0")) || (table2.Rows[j][num6].ToString().Trim() == "0"))
                        {
                            table2.Rows[j][num6] = DBNull.Value;
                        }
                    }
                }
                tjds.Tables.Add(table2);
                string cmdText = this.pSQL_ZYBH_B2_GLSLLMMJXJBHB();
                connection.Open();
                selectCommand = new SqlCommand(cmdText, connection);
                selectCommand.CommandTimeout = 60;
                adapter = new SqlDataAdapter(selectCommand);
                connection.Close();
                table2 = new DataTable();
                table2.TableName = "b2";
                adapter.Fill(table2);
                if (table2.Columns.CanRemove(table2.Columns["tjdw"]))
                {
                    table2.Columns.Remove(table2.Columns["tjdw"]);
                }
                table2.Columns.Add("id");
                table = new DataTable();
                table = table2.Copy();
                table.Clear();
                table4 = new DataTable();
                table4 = table2.Copy();
                table4.Clear();
                int num7 = 0;
            Label_0F03:
                if (num7 >= table2.Rows.Count)
                {
                    goto Label_1885;
                }
                double num8 = num7;
                num8 /= 2.0;
                table2.Rows[num7]["id"] = ((Math.Floor(num8) * 2.0) + num7) + 1.0;
                if (((num7 + 1) % 2) != 0)
                {
                    goto Label_186F;
                }
                DataRow row4 = table.NewRow();
                DataRow row5 = table4.NewRow();
                int num9 = 0;
            Label_0F85:
                if (num9 < table2.Columns.Count)
                {
                    try
                    {
                        switch (num9)
                        {
                            case 0:
                                row4[num9] = table2.Rows[num7][num9].ToString();
                                row5[num9] = table2.Rows[num7][num9].ToString();
                                goto Label_187A;

                            case 1:
                                row4[num9] = "变化量";
                                row5[num9] = "变化率(%)";
                                goto Label_187A;
                        }
                        if ((table2.Columns[num9].ColumnName != "森林覆盖率") && (table2.Columns[num9].ColumnName != "林木覆盖率"))
                        {
                            if (num9 <= 10)
                            {
                                if (((num9 + 1) % 2) == 0)
                                {
                                    if (num9 == 3)
                                    {
                                        row4[num9] = Convert.ToDouble((double) (double.Parse(table2.Rows[num7][num9].ToString()) - double.Parse(table2.Rows[num7 - 1][num9].ToString()))).ToString("f1");
                                        try
                                        {
                                            num26 = Convert.ToDouble((double) ((double.Parse(table2.Rows[num7][num9].ToString()) - double.Parse(table2.Rows[num7 - 1][num9].ToString())) / double.Parse(table2.Rows[num7 - 1][num9].ToString()))) * 100.0;
                                            row5[num9] = num26.ToString("f1");
                                        }
                                        catch
                                        {
                                            row5[num9] = 0;
                                        }
                                    }
                                    else
                                    {
                                        row4[num9] = Convert.ToDouble((double) (double.Parse(table2.Rows[num7][num9].ToString()) - double.Parse(table2.Rows[num7 - 1][num9].ToString()))).ToString("f0");
                                        try
                                        {
                                            num26 = Convert.ToDouble((double) ((double.Parse(table2.Rows[num7][num9].ToString()) - double.Parse(table2.Rows[num7 - 1][num9].ToString())) / double.Parse(table2.Rows[num7 - 1][num9].ToString()))) * 100.0;
                                            row5[num9] = num26.ToString("f1");
                                        }
                                        catch
                                        {
                                            row5[num9] = 0;
                                        }
                                    }
                                }
                                else if (num9 == 2)
                                {
                                    row4[num9] = Convert.ToDouble((double) (double.Parse(table2.Rows[num7][num9].ToString()) - double.Parse(table2.Rows[num7 - 1][num9].ToString()))).ToString("f0");
                                    try
                                    {
                                        num26 = Convert.ToDouble((double) ((double.Parse(table2.Rows[num7][num9].ToString()) - double.Parse(table2.Rows[num7 - 1][num9].ToString())) / double.Parse(table2.Rows[num7 - 1][num9].ToString()))) * 100.0;
                                        row5[num9] = num26.ToString("f1");
                                    }
                                    catch
                                    {
                                        row5[num9] = 0;
                                    }
                                }
                                else
                                {
                                    row4[num9] = Convert.ToDouble((double) (double.Parse(table2.Rows[num7][num9].ToString()) - double.Parse(table2.Rows[num7 - 1][num9].ToString()))).ToString("f1");
                                    try
                                    {
                                        num26 = Convert.ToDouble((double) ((double.Parse(table2.Rows[num7][num9].ToString()) - double.Parse(table2.Rows[num7 - 1][num9].ToString())) / double.Parse(table2.Rows[num7 - 1][num9].ToString()))) * 100.0;
                                        row5[num9] = num26.ToString("f1");
                                    }
                                    catch
                                    {
                                        row5[num9] = 0;
                                    }
                                }
                            }
                            else if (((num9 + 1) % 2) == 0)
                            {
                                switch (num9)
                                {
                                    case 15:
                                    case 0x11:
                                        row4[num9] = Convert.ToDouble((double) (double.Parse(table2.Rows[num7][num9].ToString()) - double.Parse(table2.Rows[num7 - 1][num9].ToString()))).ToString("f2");
                                        try
                                        {
                                            num26 = Convert.ToDouble((double) ((double.Parse(table2.Rows[num7][num9].ToString()) - double.Parse(table2.Rows[num7 - 1][num9].ToString())) / double.Parse(table2.Rows[num7 - 1][num9].ToString()))) * 100.0;
                                            row5[num9] = num26.ToString("f2");
                                        }
                                        catch
                                        {
                                            row5[num9] = 0;
                                        }
                                        goto Label_187A;
                                }
                                row4[num9] = Convert.ToDouble((double) (double.Parse(table2.Rows[num7][num9].ToString()) - double.Parse(table2.Rows[num7 - 1][num9].ToString()))).ToString("f1");
                                try
                                {
                                    num26 = Convert.ToDouble((double) ((double.Parse(table2.Rows[num7][num9].ToString()) - double.Parse(table2.Rows[num7 - 1][num9].ToString())) / double.Parse(table2.Rows[num7 - 1][num9].ToString()))) * 100.0;
                                    row5[num9] = num26.ToString("f0");
                                }
                                catch
                                {
                                    row5[num9] = 0;
                                }
                            }
                            else
                            {
                                row4[num9] = Convert.ToDouble((double) (double.Parse(table2.Rows[num7][num9].ToString()) - double.Parse(table2.Rows[num7 - 1][num9].ToString()))).ToString("f0");
                                try
                                {
                                    num26 = Convert.ToDouble((double) ((double.Parse(table2.Rows[num7][num9].ToString()) - double.Parse(table2.Rows[num7 - 1][num9].ToString())) / double.Parse(table2.Rows[num7 - 1][num9].ToString()))) * 100.0;
                                    row5[num9] = num26.ToString("f0");
                                }
                                catch
                                {
                                    row5[num9] = 0;
                                }
                            }
                        }
                        else
                        {
                            row4[num9] = table2.Rows[num7][num9].ToString();
                            row5[num9] = table2.Rows[num7][num9].ToString();
                        }
                        goto Label_187A;
                    }
                    catch
                    {
                        goto Label_187A;
                    }
                }
                row4["id"] = (((Math.Floor(num8) * 2.0) + num7) + 1.0) + 1.0;
                row5["id"] = (((Math.Floor(num8) * 2.0) + num7) + 1.0) + 2.0;
                table.Rows.Add(row4);
                table4.Rows.Add(row5);
            Label_186F:
                num7++;
                goto Label_0F03;
            Label_187A:
                num9++;
                goto Label_0F85;
            Label_1885:
                table2.Merge(table);
                table2.Merge(table4);
                table2.Columns.Add("Sortid", typeof(double));
                foreach (DataRow row6 in table2.Rows)
                {
                    row6["Sortid"] = Convert.ToDouble(row6["id"]);
                }
                view = new DataView(table2);
                view.Sort = "Sortid";
                table5 = new DataTable();
                table2 = view.ToTable();
                if (table2.Columns.CanRemove(table2.Columns["id"]))
                {
                    table2.Columns.Remove("id");
                }
                if (table2.Columns.CanRemove(table2.Columns["Sortid"]))
                {
                    table2.Columns.Remove("Sortid");
                }
                for (int k = 0; k < table2.Rows.Count; k++)
                {
                    for (int num11 = 0; num11 < table2.Columns.Count; num11++)
                    {
                        if (((table2.Rows[k][num11].ToString().Trim() == "0.00") || (table2.Rows[k][num11].ToString().Trim() == "0.0")) || (table2.Rows[k][num11].ToString().Trim() == "0"))
                        {
                            table2.Rows[k][num11] = DBNull.Value;
                        }
                    }
                }
                tjds.Tables.Add(table2);
                cmdText = this.pSQL_ZYBH_B3_GLZMJXJBHB();
                connection.Open();
                selectCommand = new SqlCommand(cmdText, connection);
                selectCommand.CommandTimeout = 60;
                adapter = new SqlDataAdapter(selectCommand);
                connection.Close();
                table2 = new DataTable();
                table2.TableName = "b3";
                adapter.Fill(table2);
                table2.Columns.Add("id");
                table = new DataTable();
                table = table2.Copy();
                table.Clear();
                table4 = new DataTable();
                table4 = table2.Copy();
                table4.Clear();
                int num12 = 0;
            Label_1B13:
                if (num12 >= table2.Rows.Count)
                {
                    goto Label_1F75;
                }
                double num13 = num12;
                num13 /= 2.0;
                table2.Rows[num12]["id"] = ((Math.Floor(num13) * 2.0) + num12) + 1.0;
                if (((num12 + 1) % 2) != 0)
                {
                    goto Label_1F5F;
                }
                DataRow row7 = table.NewRow();
                DataRow row8 = table4.NewRow();
                int num14 = 0;
            Label_1B95:
                if (num14 < table2.Columns.Count)
                {
                    try
                    {
                        switch (num14)
                        {
                            case 0:
                                row7[num14] = table2.Rows[num12][num14].ToString();
                                row8[num14] = table2.Rows[num12][num14].ToString();
                                goto Label_1F6A;

                            case 1:
                                row7[num14] = "变化量";
                                row8[num14] = "变化率(%)";
                                goto Label_1F6A;
                        }
                        if ((table2.Columns[num14].ColumnName != "森林覆盖率") && (table2.Columns[num14].ColumnName != "林木覆盖率"))
                        {
                            if (((num14 + 1) % 2) == 0)
                            {
                                row7[num14] = Convert.ToDouble((double) (double.Parse(table2.Rows[num12][num14].ToString()) - double.Parse(table2.Rows[num12 - 1][num14].ToString()))).ToString("f0");
                                try
                                {
                                    num26 = Convert.ToDouble((double) ((double.Parse(table2.Rows[num12][num14].ToString()) - double.Parse(table2.Rows[num12 - 1][num14].ToString())) / double.Parse(table2.Rows[num12 - 1][num14].ToString()))) * 100.0;
                                    row8[num14] = num26.ToString("f1");
                                }
                                catch
                                {
                                    row8[num14] = 0;
                                }
                            }
                            else
                            {
                                row7[num14] = Convert.ToDouble((double) (double.Parse(table2.Rows[num12][num14].ToString()) - double.Parse(table2.Rows[num12 - 1][num14].ToString()))).ToString("f1");
                                try
                                {
                                    num26 = Convert.ToDouble((double) ((double.Parse(table2.Rows[num12][num14].ToString()) - double.Parse(table2.Rows[num12 - 1][num14].ToString())) / double.Parse(table2.Rows[num12 - 1][num14].ToString()))) * 100.0;
                                    row8[num14] = num26.ToString("f1");
                                }
                                catch
                                {
                                    row8[num14] = 0;
                                }
                            }
                        }
                        else
                        {
                            row7[num14] = table2.Rows[num12][num14].ToString();
                            row8[num14] = table2.Rows[num12][num14].ToString();
                        }
                        goto Label_1F6A;
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show("3" + exception.Message);
                        goto Label_1F6A;
                    }
                }
                row7["id"] = (((Math.Floor(num13) * 2.0) + num12) + 1.0) + 1.0;
                row8["id"] = (((Math.Floor(num13) * 2.0) + num12) + 1.0) + 2.0;
                table.Rows.Add(row7);
                table4.Rows.Add(row8);
            Label_1F5F:
                num12++;
                goto Label_1B13;
            Label_1F6A:
                num14++;
                goto Label_1B95;
            Label_1F75:
                table2.Merge(table);
                table2.Merge(table4);
                table2.Columns.Add("Sortid", typeof(double));
                foreach (DataRow row9 in table2.Rows)
                {
                    row9["Sortid"] = Convert.ToDouble(row9["id"]);
                }
                view = new DataView(table2);
                view.Sort = "Sortid";
                table5 = new DataTable();
                table2 = view.ToTable();
                if (table2.Columns.CanRemove(table2.Columns["id"]))
                {
                    table2.Columns.Remove("id");
                }
                if (table2.Columns.CanRemove(table2.Columns["Sortid"]))
                {
                    table2.Columns.Remove("Sortid");
                }
                for (int m = 0; m < table2.Rows.Count; m++)
                {
                    for (int num16 = 0; num16 < table2.Columns.Count; num16++)
                    {
                        if (((table2.Rows[m][num16].ToString().Trim() == "0.00") || (table2.Rows[m][num16].ToString().Trim() == "0.0")) || (table2.Rows[m][num16].ToString().Trim() == "0"))
                        {
                            table2.Rows[m][num16] = DBNull.Value;
                        }
                    }
                }
                tjds.Tables.Add(table2);
                connection.Open();
                selectCommand = new SqlCommand("update " + this.pTable_XB_last + " set SZMERGE ='' update " + this.pTable_XB_now + " set SZMERGE ='' select * from " + this.pTable_slszhb, connection);
                adapter = new SqlDataAdapter(selectCommand);
                table2 = new DataTable();
                adapter.Fill(table2);
                for (int n = 0; n < table2.Rows.Count; n++)
                {
                    str6 = "update " + this.pTable_XB_last + " set SZMERGE = '" + table2.Rows[n]["cname"].ToString().Trim() + "' where " + table2.Rows[n]["mergerule"].ToString().Trim();
                    selectCommand = new SqlCommand(str6 + " update " + this.pTable_XB_now + " set SZMERGE = '" + table2.Rows[n]["cname"].ToString().Trim() + "' where " + table2.Rows[n]["mergerule"].ToString().Trim(), connection);
                    adapter = new SqlDataAdapter(selectCommand);
                    DataTable table6 = new DataTable();
                    adapter.Fill(table6);
                }
                selectCommand = new SqlCommand(this.pSQL_ZYBH_B4_ZYSZMJXJBHB(), connection);
                selectCommand.CommandTimeout = 60;
                adapter = new SqlDataAdapter(selectCommand);
                connection.Close();
                table2 = new DataTable();
                table2.TableName = "b4";
                adapter.Fill(table2);
                table2.Columns.Remove("统计");
                for (int num18 = 0; num18 < table2.Rows.Count; num18++)
                {
                    for (int num19 = 0; num19 < table2.Columns.Count; num19++)
                    {
                        if (((table2.Rows[num18][num19].ToString().Trim() == "0.00") || (table2.Rows[num18][num19].ToString().Trim() == "0.0")) || (table2.Rows[num18][num19].ToString().Trim() == "0"))
                        {
                            table2.Rows[num18][num19] = DBNull.Value;
                        }
                    }
                }
                tjds.Tables.Add(table2);
                connection.Open();
                selectCommand = new SqlCommand("update " + this.pTable_XB_last + " set SZMERGE ='' update " + this.pTable_XB_now + " set SZMERGE =''  select * from " + this.pTable_yclszhb, connection);
                adapter = new SqlDataAdapter(selectCommand);
                table2 = new DataTable();
                adapter.Fill(table2);
                for (int num20 = 0; num20 < table2.Rows.Count; num20++)
                {
                    str6 = "update " + this.pTable_XB_last + " set SZMERGE = '" + table2.Rows[num20]["cname"].ToString().Trim() + "' where " + table2.Rows[num20]["mergerule"].ToString().Trim();
                    selectCommand = new SqlCommand(str6 + " update " + this.pTable_XB_now + " set SZMERGE = '" + table2.Rows[num20]["cname"].ToString().Trim() + "' where " + table2.Rows[num20]["mergerule"].ToString().Trim(), connection);
                    adapter = new SqlDataAdapter(selectCommand);
                    DataTable table7 = new DataTable();
                    adapter.Fill(table7);
                }
                selectCommand = new SqlCommand(this.pSQL_ZYBH_B5_YCLMJXJBHB(), connection);
                selectCommand.CommandTimeout = 60;
                adapter = new SqlDataAdapter(selectCommand);
                connection.Close();
                table2 = new DataTable();
                table2.TableName = "b5";
                adapter.Fill(table2);
                table2.Columns.Add("id");
                table = new DataTable();
                table = table2.Copy();
                table.Clear();
                table4 = new DataTable();
                table4 = table2.Copy();
                table4.Clear();
                int num21 = 0;
            Label_26B5:
                if (num21 >= table2.Rows.Count)
                {
                    goto Label_2B27;
                }
                double num22 = num21;
                num22 /= 2.0;
                table2.Rows[num21]["id"] = ((Math.Floor(num22) * 2.0) + num21) + 1.0;
                if (((num21 + 1) % 2) != 0)
                {
                    goto Label_2B11;
                }
                DataRow row10 = table.NewRow();
                DataRow row11 = table4.NewRow();
                int num23 = 0;
            Label_2737:
                if (num23 < table2.Columns.Count)
                {
                    try
                    {
                        switch (num23)
                        {
                            case 0:
                            case 1:
                                row10[num23] = table2.Rows[num21][num23].ToString();
                                row11[num23] = table2.Rows[num21][num23].ToString();
                                goto Label_2B1C;

                            case 2:
                                row10[num23] = "变化量";
                                row11[num23] = "变化率(%)";
                                goto Label_2B1C;
                        }
                        if ((table2.Columns[num23].ColumnName != "森林覆盖率") && (table2.Columns[num23].ColumnName != "林木覆盖率"))
                        {
                            if (((num23 + 1) % 2) == 0)
                            {
                                row10[num23] = Convert.ToDouble((double) (double.Parse(table2.Rows[num21][num23].ToString()) - double.Parse(table2.Rows[num21 - 1][num23].ToString()))).ToString("f1");
                                try
                                {
                                    num26 = Convert.ToDouble((double) ((double.Parse(table2.Rows[num21][num23].ToString()) - double.Parse(table2.Rows[num21 - 1][num23].ToString())) / double.Parse(table2.Rows[num21 - 1][num23].ToString()))) * 100.0;
                                    row11[num23] = num26.ToString("f1");
                                }
                                catch
                                {
                                    row11[num23] = 0;
                                }
                            }
                            else
                            {
                                row10[num23] = Convert.ToDouble((double) (double.Parse(table2.Rows[num21][num23].ToString()) - double.Parse(table2.Rows[num21 - 1][num23].ToString()))).ToString("f1");
                                try
                                {
                                    row11[num23] = (Convert.ToDouble((double) ((double.Parse(table2.Rows[num21][num23].ToString()) - double.Parse(table2.Rows[num21 - 1][num23].ToString())) / double.Parse(table2.Rows[num21 - 1][num23].ToString()))) * 100.0).ToString("f1");
                                }
                                catch
                                {
                                    row11[num23] = 0;
                                }
                            }
                        }
                        else
                        {
                            row10[num23] = table2.Rows[num21][num23].ToString();
                            row11[num23] = table2.Rows[num21][num23].ToString();
                        }
                        goto Label_2B1C;
                    }
                    catch (Exception exception2)
                    {
                        MessageBox.Show("5" + exception2.Message);
                        goto Label_2B1C;
                    }
                }
                row10["id"] = (((Math.Floor(num22) * 2.0) + num21) + 1.0) + 1.0;
                row11["id"] = (((Math.Floor(num22) * 2.0) + num21) + 1.0) + 2.0;
                table.Rows.Add(row10);
                table4.Rows.Add(row11);
            Label_2B11:
                num21++;
                goto Label_26B5;
            Label_2B1C:
                num23++;
                goto Label_2737;
            Label_2B27:
                table2.Merge(table);
                table2.Merge(table4);
                table2.Columns.Add("Sortid", typeof(double));
                foreach (DataRow row12 in table2.Rows)
                {
                    row12["Sortid"] = Convert.ToDouble(row12["id"]);
                }
                view = new DataView(table2);
                view.Sort = "Sortid";
                table5 = new DataTable();
                table2 = view.ToTable();
                if (table2.Columns.CanRemove(table2.Columns["id"]))
                {
                    table2.Columns.Remove("id");
                }
                if (table2.Columns.CanRemove(table2.Columns["Sortid"]))
                {
                    table2.Columns.Remove("Sortid");
                }
                for (int num24 = 0; num24 < table2.Rows.Count; num24++)
                {
                    for (int num25 = 0; num25 < table2.Columns.Count; num25++)
                    {
                        if (((table2.Rows[num24][num25].ToString().Trim() == "0.00") || (table2.Rows[num24][num25].ToString().Trim() == "0.0")) || (table2.Rows[num24][num25].ToString().Trim() == "0"))
                        {
                            table2.Rows[num24][num25] = DBNull.Value;
                        }
                    }
                }
                tjds.Tables.Add(table2);
            }
            catch
            {
                MessageBox.Show("导出数据出错了");
            }
            finally
            {
                GC.Collect();
            }
            new PrintZYDCTJBClass().SaveZYBHTJB(tjdwmc, tjds, xlsModelPath, pXLSFileName);
            Process.Start(pXLSFileName);
        }

        public void Export_process(string pConnecting, string pDataBaseName)
        {
            string fileName = "";
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Title = "请为输出的Excel表选择一个存储位置";
            dialog.Filter = "Excel表(*.xls)|*.xls";
            dialog.InitialDirectory = Application.StartupPath;
            dialog.RestoreDirectory = true;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                fileName = dialog.FileName;
                BackgroundWorker backgroundWorker = new BackgroundWorker();
                backgroundWorker.WorkerReportsProgress = true;
                backgroundWorker.WorkerSupportsCancellation = true;
                backgroundWorker.DoWork += new DoWorkEventHandler(this.pBackgroundWorker_DoWork);
                backgroundWorker.RunWorkerAsync(pConnecting + "#" + pDataBaseName + "#" + fileName);
                new frmWaiting(backgroundWorker).ShowDialog();
            }
        }

        private void pBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            string[] strArray = e.Argument.ToString().Trim().Split(new char[] { '#' });
            string pConnecting = strArray[0];
            string pDataBaseName = strArray[1];
            string pXLSFileName = strArray[2];
            this.Export(pConnecting, pDataBaseName, pXLSFileName);
        }

        private string pSQL_ZYBH_B1_GLTDMJBHB()
        {
            return string.Concat(new object[] { 
                " select xb_Merge.* from ( select '[统计单位]' = case when code.CNAME IS NULL and (xb_cube.tjdw = '' or xb_cube.tjdw IS NULL) then '合  计' when code.CNAME IS NULL and (xb_cube.tjdw <> '' and xb_cube.tjdw IS NOT NULL) then xb_cube.tjdw else code.CNAME end, xb_cube.* from ( Select 'tjdw'= xiang, case when (GROUPING (tjnd) = 1) then '合  计' else ISNULL(tjnd,'null') end as 统计年度, SUM(cld_mj + hjld_mj + hsld_mj + zld_mj + sld_mj + gmld_gg_mj + gmld_qt_mj + wcld_zl_mj + wcld_fy_mj + mpd_mj + wlmld_cf_mj + wlmld_hs_mj + wlmld_qt_mj + yilind_hshd + yilind_shd + yilind_qt + fzd_mj1 + fzd_mj2 + fld1 + fld2 + fld3 + ndgmjjld + ndqmld + ndzld + bzd_mj) as 总面积, SUM(cld_mj + hjld_mj + hsld_mj + zld_mj + sld_mj + gmld_gg_mj + gmld_qt_mj + wcld_zl_mj + wcld_fy_mj + mpd_mj + wlmld_cf_mj + wlmld_hs_mj + wlmld_qt_mj + yilind_hshd + yilind_shd + yilind_qt + fzd_mj1 + fzd_mj2 + bzd_mj) as 林地, SUM(cld_mj + hjld_mj + hsld_mj + zld_mj) as 有林地, sum(cld_mj + hjld_mj) as 乔木林, SUM(cld_mj) as 纯林地, SUM(hjld_mj) as 混交林地, sum(hsld_mj) as 红树林, sum(zld_mj) as 竹林, SUM(sld_mj) as 疏林地, SUM(gmld_gg_mj + gmld_qt_mj) as 灌木林地小计, sum(gmld_gg_mj) as 国家灌, sum(gmld_gg_jjl_mj) as 国家灌木经济林, SUM(gmld_qt_mj)as 其它灌, SUM(wcld_zl_mj + wcld_fy_mj) as 未成林地, SUM(wcld_zl_mj) as 未成林造林地, SUM(wcld_fy_mj) as 未成林封育地, SUM(mpd_mj)as 苗圃地, SUM(wlmld_cf_mj + wlmld_hs_mj + wlmld_qt_mj)as 无立木林地, SUM(wlmld_cf_mj)as 采伐迹地, SUM(wlmld_hs_mj)as 火烧迹地, SUM(wlmld_qt_mj)as 其它无立木林地, SUM(yilind_hshd + yilind_shd + yilind_qt) as 宜林地, SUM(yilind_hshd) as 宜林荒山荒地, SUM(yilind_shd + yilind_qt) as 其它宜林地, SUM(fzd_mj1 + fzd_mj2)as 辅助地, SUM(bzd_mj)as 被占地, SUM(fld1 + fld2 + fld3 + ndgmjjld + ndqmld + ndzld) as 非林地, SUM(ndqmld) as 农地乔木林, SUM(ndgmjjld) as 农地经济林, SUM(ndzld) as 农地竹林, SUM(spsmj) as 四旁树面积, cast(isnull((cast((sum(spsmj) + sum(ndgmjjld)+ sum(ndqmld) + sum(ndzld) + sum(gmld_gg_mj) + sum(cld_mj + hjld_mj + zld_mj)) as float) /cast(sum(nullif(cld_mj + hjld_mj + hsld_mj + zld_mj + sld_mj + gmld_gg_mj + gmld_qt_mj + wcld_zl_mj + wcld_fy_mj + mpd_mj + wlmld_cf_mj + wlmld_hs_mj + wlmld_qt_mj + yilind_hshd + yilind_shd + yilind_qt + fzd_mj1 + fzd_mj2 + fld1 + fld2 + fld3 + ndgmjjld + ndqmld + ndzld + bzd_mj,0)) as float)) * 100,0) as decimal(18,2)) as 森林覆盖率, cast(isnull((cast((sum(spsmj) + sum(ndgmjjld)+ sum(ndqmld) + sum(ndzld) + sum(gmld_gg_mj) + SUM(gmld_qt_mj) + sum(cld_mj + hjld_mj + hsld_mj + zld_mj)) as float) /cast(sum(nullif((cld_mj + hjld_mj + hsld_mj + zld_mj + sld_mj + gmld_gg_mj + gmld_qt_mj + wcld_zl_mj + wcld_fy_mj + mpd_mj + wlmld_cf_mj + wlmld_hs_mj + wlmld_qt_mj + yilind_hshd + yilind_shd + yilind_qt + fzd_mj1 + fzd_mj2 + fld1 + fld2 + fld3 + ndgmjjld + ndqmld + ndzld + bzd_mj),0)) as float) * 100),0) as decimal(18,2)) as 林木覆盖率 FROM( select 'XIANG' = XIANG, 'tjnd' = '", this.pLastND, "', SUM (case when [DI_LEI] = '111' then convert(decimal(18,1),[YXMJ]) else 0 end) as cld_mj, SUM (case when [DI_LEI] = '112' then convert(decimal(18,1),[YXMJ]) else 0 end) as hjld_mj, SUM (case when [DI_LEI] = '120' then convert(decimal(18,1),[YXMJ]) else 0 end) as hsld_mj, SUM (case when [DI_LEI] = '130' then convert(decimal(18,1),[YXMJ]) else 0 end) as zld_mj, SUM (case when [DI_LEI] = '200' then convert(decimal(18,1),[YXMJ]) else 0 end) as sld_mj, SUM (case when [DI_LEI] = '301' then convert(decimal(18,1),[YXMJ]) else 0 end) as gmld_gg_mj, SUM (case when [DI_LEI] = '301' and [LIN_ZHONG] like '25%' then convert(decimal(18,1),[YXMJ]) else 0 end) as gmld_gg_jjl_mj, SUM (case when [DI_LEI] = '302' then convert(decimal(18,1),[YXMJ]) else 0 end) as gmld_qt_mj, SUM (case when [DI_LEI] = '401' OR [DI_LEI] = '403' then convert(decimal(18,1),[YXMJ]) else 0 end) as wcld_zl_mj, SUM (case when [DI_LEI] = '402' OR [DI_LEI] = '404' then convert(decimal(18,1),[YXMJ]) else 0 end) as wcld_fy_mj, SUM (case when [DI_LEI] = '500' then convert(decimal(18,1),[YXMJ]) else 0 end) as mpd_mj, SUM (case when [DI_LEI] = '601' then convert(decimal(18,1),[YXMJ]) else 0 end) as wlmld_cf_mj, SUM (case when [DI_LEI] = '602' then convert(decimal(18,1),[YXMJ]) else 0 end) as wlmld_hs_mj, SUM (case when [DI_LEI] like '603%' then convert(decimal(18,1),[YXMJ]) else 0 end) as wlmld_qt_mj, SUM (case when [DI_LEI] = '701' then convert(decimal(18,1),[YXMJ]) else 0 end ) as yilind_hshd, SUM (case when [DI_LEI] = '702' then convert(decimal(18,1),[YXMJ]) else 0 end ) as yilind_shd, SUM (case when [DI_LEI] like '7%' and [DI_LEI] <> '701' and [DI_LEI] <> '702' then convert(decimal(18,1),[YXMJ]) else 0 end ) as yilind_qt, SUM (case when [DI_LEI] = '800' then convert(decimal(18,1),[YXMJ]) else 0 end) as fzd_mj1, SUM (0) as bzd_mj, sum (case when [DI_LEI] like '9%' and [DI_LEI] not like '96%' then convert(decimal(18,1),[YXMJ]) else 0 end ) as fld1, sum (case when [DI_LEI] = '961' then convert(decimal(18,1),[YXMJ]) else 0 end ) as ndqmld, sum (case when [DI_LEI] = '962' then convert(decimal(18,1),[YXMJ]) else 0 end ) as ndgmjjld, sum (case when [DI_LEI] = '963' then convert(decimal(18,1),[YXMJ]) else 0 end ) as ndzld, sum (case when [SSLX] = '2' then round(cast([SSZZS] as float)/cast(1650 as float),1) else 0 end ) as spsmj, sum (case when ([XZWZL] = '11' or [XZWZL] = '12' or [XZWZL] = '41' or [XZWZL] = '42') then convert(decimal(18,1),[XZWMJ]) else 0 end ) as fzd_mj2, sum (case when ([XZWZL] = '13' or [XZWZL] = '14' or [XZWZL] = '23' or [XZWZL] = '31' or [XZWZL] = '32') then convert(decimal(18,1),[XZWMJ]) else 0 end ) as fld2, sum (case when ([XZWZL] = '21' or [XZWZL] = '22') then convert(decimal(18,1),[XZWMJ]) else 0 end ) as fld3 FROM ", this.pTable_XB_last, " where TDJYQ not like '7%' group by XIANG union all /*除线状物外的其它被占地类面积*/ select 'XIANG' = XIANG, 'tjnd' = '", this.pLastND, "', SUM (0) as cld_mj, SUM (0) as hjld_mj, SUM (0) as hsld_mj, SUM (0) as zld_mj, SUM (0) as sld_mj, SUM (0) as gmld_gg_mj, SUM (0) as gmld_gg_jjl_mj, SUM (0) as gmld_qt_mj, SUM (0) as wcld_zl_mj, SUM (0) as wcld_fy_mj, SUM (0) as mpd_mj, SUM (0) as wlmld_cf_mj, SUM (0) as wlmld_hs_mj, SUM (0) as wlmld_qt_mj, SUM (0) as yilind_hshd, SUM (0) as yilind_shd, SUM (0) as yilind_qt, SUM (0) as fzd_mj1, SUM (case when [TDJYQ] like '7%' then convert(decimal(18,1),[YXMJ]) else 0 end) as bzd_mj, sum (0) as fld1, sum (0) as ndqmld, sum (0) as ndgmjjld, sum (0) as ndzld, sum (0) as spsmj, sum (case when ([XZWZL] = '11' or [XZWZL] = '12') then convert(decimal(18,1),[XZWMJ]) else 0 end ) as fzd_mj2, sum (case when ([XZWZL] = '13' or [XZWZL] = '14' or [XZWZL] = '23' or [XZWZL] = '31' or [XZWZL] = '32') then convert(decimal(18,1),[XZWMJ]) else 0 end ) as fld2, sum (case when ([XZWZL] = '21' or [XZWZL] = '22') then convert(decimal(18,1),[XZWMJ]) else 0 end ) as fld3 FROM   ", this.pTable_XB_last, " where TDJYQ like '7%' group by XIANG /*线状物的被占面积*/ union all select 'XIANG' = XIANG, 'tjnd' = '", this.pLastND, "', SUM (0) as cld_mj, SUM (0) as hjld_mj, SUM (0) as hsld_mj, SUM (0) as zld_mj, SUM (0) as sld_mj, SUM (0) as gmld_gg_mj, SUM (0) as gmld_gg_jjl_mj, SUM (0) as gmld_qt_mj, SUM (0) as wcld_zl_mj, SUM (0) as wcld_fy_mj, SUM (0) as mpd_mj, SUM (0) as wlmld_cf_mj, SUM (0) as wlmld_hs_mj, SUM (0) as wlmld_qt_mj, SUM (0) as yilind_hshd, SUM (0) as yilind_shd, SUM (0) as yilind_qt, SUM (0) as fzd_mj1, SUM (case when ([XZWZL] = '41' or [XZWZL] = '42') then convert(decimal(18,1),[XZWMJ]) else 0 end ) as bzd_mj, sum (0) as fld1, sum (0) as ndqmld, sum (0) as ndgmjjld, sum (0) as ndzld, sum (0) as spsmj, sum (0) as fzd_mj2, sum (0) as fld2, sum (0) as fld3 FROM   ", this.pTable_XB_last, " where TDJYQ like '7%' group by XIANG  union all  select 'XIANG' = XIANG, 'tjnd' = '", this.pNowND, "', SUM (case when [DI_LEI] = '111' then convert(decimal(18,1),[YXMJ]) else 0 end) as cld_mj, SUM (case when [DI_LEI] = '112' then convert(decimal(18,1),[YXMJ]) else 0 end) as hjld_mj, SUM (case when [DI_LEI] = '120' then convert(decimal(18,1),[YXMJ]) else 0 end) as hsld_mj, SUM (case when [DI_LEI] = '130' then convert(decimal(18,1),[YXMJ]) else 0 end) as zld_mj, SUM (case when [DI_LEI] = '200' then convert(decimal(18,1),[YXMJ]) else 0 end) as sld_mj, SUM (case when [DI_LEI] = '301' then convert(decimal(18,1),[YXMJ]) else 0 end) as gmld_gg_mj, SUM (case when [DI_LEI] = '301' and [LIN_ZHONG] like '25%' then convert(decimal(18,1),[YXMJ]) else 0 end) as gmld_gg_jjl_mj, SUM (case when [DI_LEI] = '302' then convert(decimal(18,1),[YXMJ]) else 0 end) as gmld_qt_mj, SUM (case when [DI_LEI] = '401' OR [DI_LEI] = '403' then convert(decimal(18,1),[YXMJ]) else 0 end) as wcld_zl_mj, SUM (case when [DI_LEI] = '402' OR [DI_LEI] = '404' then convert(decimal(18,1),[YXMJ]) else 0 end) as wcld_fy_mj, SUM (case when [DI_LEI] = '500' then convert(decimal(18,1),[YXMJ]) else 0 end) as mpd_mj, SUM (case when [DI_LEI] = '601' then convert(decimal(18,1),[YXMJ]) else 0 end) as wlmld_cf_mj, SUM (case when [DI_LEI] = '602' then convert(decimal(18,1),[YXMJ]) else 0 end) as wlmld_hs_mj, SUM (case when [DI_LEI] like '603%' then convert(decimal(18,1),[YXMJ]) else 0 end) as wlmld_qt_mj, SUM (case when [DI_LEI] = '701' then convert(decimal(18,1),[YXMJ]) else 0 end ) as yilind_hshd, SUM (case when [DI_LEI] = '702' then convert(decimal(18,1),[YXMJ]) else 0 end ) as yilind_shd, SUM (case when [DI_LEI] like '7%' and [DI_LEI] <> '701' and [DI_LEI] <> '702' then convert(decimal(18,1),[YXMJ]) else 0 end ) as yilind_qt, SUM (case when [DI_LEI] = '800' then convert(decimal(18,1),[YXMJ]) else 0 end) as fzd_mj1, SUM (0) as bzd_mj, sum (case when [DI_LEI] like '9%' and [DI_LEI] not like '96%' then convert(decimal(18,1),[YXMJ]) else 0 end ) as fld1, sum (case when [DI_LEI] = '961' then convert(decimal(18,1),[YXMJ]) else 0 end ) as ndqmld, sum (case when [DI_LEI] = '962' then convert(decimal(18,1),[YXMJ]) else 0 end ) as ndgmjjld, sum (case when [DI_LEI] = '963' then convert(decimal(18,1),[YXMJ]) else 0 end ) as ndzld, sum (case when [SSLX] = '2' then round(cast([SSZZS] as float)/cast(1650 as float),1) else 0 end ) as spsmj, sum (case when ([XZWZL] = '11' or [XZWZL] = '12' or [XZWZL] = '41' or [XZWZL] = '42') then convert(decimal(18,1),[XZWMJ]) else 0 end ) as fzd_mj2, sum (case when ([XZWZL] = '13' or [XZWZL] = '14' or [XZWZL] = '23' or [XZWZL] = '31' or [XZWZL] = '32') then convert(decimal(18,1),[XZWMJ]) else 0 end ) as fld2, sum (case when ([XZWZL] = '21' or [XZWZL] = '22') then convert(decimal(18,1),[XZWMJ]) else 0 end ) as fld3 FROM   ", this.pTable_XB_now,
                " where TDJYQ not like '7%' group by XIANG union all /*除线状物外的其它被占地类面积*/ select 'XIANG' = XIANG, 'tjnd' = '", this.pNowND, "', SUM (0) as cld_mj, SUM (0) as hjld_mj, SUM (0) as hsld_mj, SUM (0) as zld_mj, SUM (0) as sld_mj, SUM (0) as gmld_gg_mj, SUM (0) as gmld_gg_jjl_mj, SUM (0) as gmld_qt_mj, SUM (0) as wcld_zl_mj, SUM (0) as wcld_fy_mj, SUM (0) as mpd_mj, SUM (0) as wlmld_cf_mj, SUM (0) as wlmld_hs_mj, SUM (0) as wlmld_qt_mj, SUM (0) as yilind_hshd, SUM (0) as yilind_shd, SUM (0) as yilind_qt, SUM (0) as fzd_mj1, SUM (case when [TDJYQ] like '7%' then convert(decimal(18,1),[YXMJ]) else 0 end) as bzd_mj, sum (0) as fld1, sum (0) as ndqmld, sum (0) as ndgmjjld, sum (0) as ndzld, sum (0) as spsmj, sum (case when ([XZWZL] = '11' or [XZWZL] = '12') then convert(decimal(18,1),[XZWMJ]) else 0 end ) as fzd_mj2, sum (case when ([XZWZL] = '13' or [XZWZL] = '14' or [XZWZL] = '23' or [XZWZL] = '31' or [XZWZL] = '32') then convert(decimal(18,1),[XZWMJ]) else 0 end ) as fld2, sum (case when ([XZWZL] = '21' or [XZWZL] = '22') then convert(decimal(18,1),[XZWMJ]) else 0 end ) as fld3 FROM   ", this.pTable_XB_now, " where TDJYQ like '7%' group by XIANG /*线状物的被占面积*/ union all select 'XIANG' = XIANG, 'tjnd' = '", this.pNowND, "', SUM (0) as cld_mj, SUM (0) as hjld_mj, SUM (0) as hsld_mj, SUM (0) as zld_mj, SUM (0) as sld_mj, SUM (0) as gmld_gg_mj, SUM (0) as gmld_gg_jjl_mj, SUM (0) as gmld_qt_mj, SUM (0) as wcld_zl_mj, SUM (0) as wcld_fy_mj, SUM (0) as mpd_mj, SUM (0) as wlmld_cf_mj, SUM (0) as wlmld_hs_mj, SUM (0) as wlmld_qt_mj, SUM (0) as yilind_hshd, SUM (0) as yilind_shd, SUM (0) as yilind_qt, SUM (0) as fzd_mj1, SUM (case when ([XZWZL] = '41' or [XZWZL] = '42') then convert(decimal(18,1),[XZWMJ]) else 0 end ) as bzd_mj, sum (0) as fld1, sum (0) as ndqmld, sum (0) as ndgmjjld, sum (0) as ndzld, sum (0) as spsmj, sum (0) as fzd_mj2, sum (0) as fld2, sum (0) as fld3 FROM   ", this.pTable_XB_now, " where TDJYQ like '7%' group by XIANG ) as xb group by cube(XIANG),tjnd ) as xb_cube left join ", this.pTable_Code, " as code on xb_cube.tjdw = code.CCODE and code.CTYPE = '乡' ) as xb_Merge order by xb_Merge.tjdw,统计年度"
            });
        }

        private string pSQL_ZYBH_B2_GLSLLMMJXJBHB()
        {
            return string.Concat(new object[] { " select xb_Merge.* from ( select '[统计单位]' = case when code.CNAME IS NULL and (xb_cube.tjdw = '' or xb_cube.tjdw IS NULL) then '合  计' when code.CNAME IS NULL and (xb_cube.tjdw <> '' and xb_cube.tjdw IS NOT NULL) then xb_cube.tjdw else code.CNAME end, xb_cube.* from ( select 'tjdw' = xiang, 'tjnd' = '", this.pLastND, "', SUM(cld_xj + hjld_xj + sld_xj + sps_xj + ss_xj + fql_xj) as 总蓄积量, SUM(cld_mj + hjld_mj + hsld_mj + zld_mj) as 有林地面积, sum(cld_mj + hjld_mj) as 乔木林面积, SUM(cld_xj + hjld_xj) as 乔木林蓄积, SUM(cld_mj) as 纯林地面积, SUM(cld_xj) as 纯林地蓄积, SUM(hjld_mj) as 混交林地面积, SUM(hjld_xj) as 混交林地蓄积, sum(hsld_mj) as 红树林面积, sum(zld_mj) as 竹林面积, cast(SUM(zld_zs)/cast(10000 as float) as decimal(8,2)) as 竹林株数, SUM(sld_mj) as 疏林地面积, SUM(sld_xj) as 疏林地蓄积, cast(SUM(sps_zs)/cast(10000 as float) as decimal(8,2)) as 四旁树株数, SUM (sps_xj) as 四旁树蓄积, cast(SUM(ss_zs)/cast(10000 as float) as decimal(8,2)) as 散生树株数, SUM (ss_xj) as 散生树蓄积, SUM(fql_mj) as 非乔林面积, SUM(fql_xj) as 非乔林蓄积 FROM( select 'xiang' = xiang, SUM (case when [DI_LEI] = '111' then convert(decimal(18,1),[YXMJ]) else 0 end) as cld_mj, SUM (case when [DI_LEI] = '111' then convert(decimal(18,0),[SLXJ]) else 0 end) as cld_xj, SUM (case when [DI_LEI] = '112' then convert(decimal(18,1),[YXMJ]) else 0 end) as hjld_mj, SUM (case when [DI_LEI] = '112' then convert(decimal(18,0),[SLXJ]) else 0 end) as hjld_xj, SUM (case when [DI_LEI] = '120' then convert(decimal(18,1),[YXMJ]) else 0 end) as hsld_mj, SUM (case when [DI_LEI] = '130' then convert(decimal(18,1),[YXMJ]) else 0 end) as zld_mj, SUM (case when [DI_LEI] = '130' then cast(convert(decimal(18,1),[YXMJ]) * MEI_GQ_ZS as float) else 0 end) as zld_zs, SUM (case when [DI_LEI] = '200' then convert(decimal(18,1),[YXMJ]) else 0 end) as sld_mj, SUM (case when [DI_LEI] = '200' then convert(decimal(18,0),[SLXJ]) else 0 end) as sld_xj, SUM (0) as sps_zs, SUM (0) as sps_xj, SUM (0) as ss_zs, SUM (0) as ss_xj, SUM (case when [DI_LEI] = '961' then convert(decimal(18,1),[YXMJ]) else 0 end) as fql_mj, SUM (case when [DI_LEI] = '961' then convert(decimal(18,0),[SLXJ]) else 0 end) as fql_xj FROM  ", this.pTable_XB_last, " as xb where DI_LEI in ('111','112','120','130','200','961') group by xiang  union all select xiang, SUM (0) as cld_mj, SUM (0) as cld_xj, SUM (0) as hjld_mj, SUM (0) as hjld_xj, SUM (0) as hsld_mj, SUM (0) as zld_mj, SUM (0) as zld_zs, SUM (0) as sld_mj, SUM (0) as sld_xj, SUM (case when [SSLX] = '2' then SSZZS else 0 end ) as sps_zs, SUM (case when [SSLX] = '2' then [SSXJ] else 0 end ) as sps_xj, SUM (case when [SSLX] = '1' then SSZZS else 0 end ) as ss_zs, SUM (case when [SSLX] = '1' then [SSXJ] else 0 end ) as ss_xj, SUM (0) as fql_mj, SUM (0) as fql_xj FROM  ", this.pTable_XB_last, " as xb where sslx <> '' group by xiang )as xb group by cube(xb.xiang)  union all  Select 'tjdw' = xiang, 'tjnd' = '", this.pNowND, "', SUM(cld_xj + hjld_xj + sld_xj + sps_xj + ss_xj + fql_xj) as 总蓄积量, SUM(cld_mj + hjld_mj + hsld_mj + zld_mj) as 有林地面积, sum(cld_mj + hjld_mj) as 乔木林面积, SUM(cld_xj + hjld_xj) as 乔木林蓄积, SUM(cld_mj) as 纯林地面积, SUM(cld_xj) as 纯林地蓄积, SUM(hjld_mj) as 混交林地面积, SUM(hjld_xj) as 混交林地蓄积, sum(hsld_mj) as 红树林面积, sum(zld_mj) as 竹林面积, cast(SUM(zld_zs)/cast(10000 as float) as decimal(8,2)) as 竹林株数, SUM(sld_mj) as 疏林地面积, SUM(sld_xj) as 疏林地蓄积, cast(SUM(sps_zs)/cast(10000 as float) as decimal(8,2)) as 四旁树株数, SUM (sps_xj) as 四旁树蓄积, cast(SUM(ss_zs)/cast(10000 as float) as decimal(8,2)) as 散生树株数, SUM (ss_xj) as 散生树蓄积, SUM(fql_mj) as 非乔林面积, SUM(fql_xj) as 非乔林蓄积 FROM( select xiang, SUM (case when [DI_LEI] = '111' then convert(decimal(18,1),[YXMJ]) else 0 end) as cld_mj, SUM (case when [DI_LEI] = '111' then convert(decimal(18,0),[SLXJ]) else 0 end) as cld_xj, SUM (case when [DI_LEI] = '112' then convert(decimal(18,1),[YXMJ]) else 0 end) as hjld_mj, SUM (case when [DI_LEI] = '112' then convert(decimal(18,0),[SLXJ]) else 0 end) as hjld_xj, SUM (case when [DI_LEI] = '120' then convert(decimal(18,1),[YXMJ]) else 0 end) as hsld_mj, SUM (case when [DI_LEI] = '130' then convert(decimal(18,1),[YXMJ]) else 0 end) as zld_mj, SUM (case when [DI_LEI] = '130' then cast(convert(decimal(18,1),[YXMJ]) * MEI_GQ_ZS as float) else 0 end) as zld_zs, SUM (case when [DI_LEI] = '200' then convert(decimal(18,1),[YXMJ]) else 0 end) as sld_mj, SUM (case when [DI_LEI] = '200' then convert(decimal(18,0),[SLXJ]) else 0 end) as sld_xj, SUM (0) as sps_zs, SUM (0) as sps_xj, SUM (0) as ss_zs, SUM (0) as ss_xj, SUM (case when [DI_LEI] = '961' then convert(decimal(18,1),[YXMJ]) else 0 end) as fql_mj, SUM (case when [DI_LEI] = '961' then convert(decimal(18,0),[SLXJ]) else 0 end) as fql_xj FROM  ", this.pTable_XB_now, " as xb where DI_LEI in ('111','112','120','130','200','961') group by xiang  union all  select xiang, SUM (0) as cld_mj, SUM (0) as cld_xj, SUM (0) as hjld_mj, SUM (0) as hjld_xj, SUM (0) as hsld_mj, SUM (0) as zld_mj, SUM (0) as zld_zs, SUM (0) as sld_mj, SUM (0) as sld_xj, SUM (case when [SSLX] = '2' then SSZZS else 0 end ) as sps_zs, SUM (case when [SSLX] = '2' then [SSXJ] else 0 end ) as sps_xj, SUM (case when [SSLX] = '1' then SSZZS else 0 end ) as ss_zs, SUM (case when [SSLX] = '1' then [SSXJ] else 0 end ) as ss_xj, SUM (0) as fql_mj, SUM (0) as fql_xj FROM  ", this.pTable_XB_now, " as xb where sslx <> '' group by xiang )as xb group by cube(xb.xiang) ) as xb_cube LEFT JOIN ", this.pTable_Code, " as code on xb_cube.tjdw = code.CCODE and code.CTYPE = '乡' ) as xb_Merge order by xb_Merge.tjdw,tjnd" });
        }

        private string pSQL_ZYBH_B3_GLZMJXJBHB()
        {
            return string.Concat(new object[] { " Select case when (GROUPING (code.CNAME) = 1) then '合计' else ISNULL(code.CNAME,'null') end as 统计单位, case when (GROUPING (nd) = 1) then '合计' else ISNULL(nd,'null') end as 年度, SUM(fhl_mj + tyl_mj + ycl_mj + xtl_mj + jjl_mj) as 总面积, SUM(fhl_xj + tyl_xj + ycl_xj + xtl_xj + jjl_xj) as 总蓄积, SUM(fhl_mj) as 防护林面积, SUM(fhl_xj) as 防护林蓄积, SUM(tyl_mj) as 特用林面积, SUM(tyl_xj) as 特用林蓄积, SUM(ycl_mj) as 用材林面积, SUM(ycl_xj) as 用材林蓄积, SUM(xtl_mj) as 薪炭林面积, SUM(xtl_xj) as 薪炭林蓄积, SUM(jjl_mj) as 经济林面积, SUM(jjl_xj) as 经济林蓄积 FROM( select [XIANG] as tjdw, 'nd' = '", this.pLastND, "年', SUM (case when [LIN_ZHONG] like '11%' then convert(decimal(18,1),[YXMJ]) else 0 end) as fhl_mj, SUM (case when [LIN_ZHONG] like '11%' then convert(decimal(18,0),[SLXJ]) else 0 end) as fhl_xj, SUM (case when [LIN_ZHONG] like '12%' then convert(decimal(18,1),[YXMJ]) else 0 end) as tyl_mj, SUM (case when [LIN_ZHONG] like '12%' then convert(decimal(18,0),[SLXJ]) else 0 end) as tyl_xj, SUM (case when [LIN_ZHONG] like '23%' then convert(decimal(18,1),[YXMJ]) else 0 end) as ycl_mj, SUM (case when [LIN_ZHONG] like '23%' then convert(decimal(18,0),[SLXJ]) else 0 end) as ycl_xj, SUM (case when [LIN_ZHONG] = '240' then convert(decimal(18,1),[YXMJ]) else 0 end) as xtl_mj, SUM (case when [LIN_ZHONG] = '240' then convert(decimal(18,0),[SLXJ]) else 0 end) as xtl_xj, SUM (case when [LIN_ZHONG] like '25%' then convert(decimal(18,1),[YXMJ]) else 0 end) as jjl_mj, SUM (case when [LIN_ZHONG] like '25%' then convert(decimal(18,0),[SLXJ]) else 0 end ) as jjl_xj FROM ", this.pTable_XB_last, " where convert(decimal(18,0),[DI_LEI]) < 400 group by XIANG  union all  select [XIANG] as tjdw, 'nd' = '", this.pNowND, "年', SUM (case when [LIN_ZHONG] like '11%' then convert(decimal(18,1),[YXMJ]) else 0 end) as fhl_mj, SUM (case when [LIN_ZHONG] like '11%' then convert(decimal(18,0),[SLXJ]) else 0 end) as fhl_xj, SUM (case when [LIN_ZHONG] like '12%' then convert(decimal(18,1),[YXMJ]) else 0 end) as tyl_mj, SUM (case when [LIN_ZHONG] like '12%' then convert(decimal(18,0),[SLXJ]) else 0 end) as tyl_xj, SUM (case when [LIN_ZHONG] like '23%' then convert(decimal(18,1),[YXMJ]) else 0 end) as ycl_mj, SUM (case when [LIN_ZHONG] like '23%' then convert(decimal(18,0),[SLXJ]) else 0 end) as ycl_xj, SUM (case when [LIN_ZHONG] = '240' then convert(decimal(18,1),[YXMJ]) else 0 end) as xtl_mj, SUM (case when [LIN_ZHONG] = '240' then convert(decimal(18,0),[SLXJ]) else 0 end) as xtl_xj, SUM (case when [LIN_ZHONG] like '25%' then convert(decimal(18,1),[YXMJ]) else 0 end) as jjl_mj, SUM (case when [LIN_ZHONG] like '25%' then convert(decimal(18,0),[SLXJ]) else 0 end ) as jjl_xj FROM ", this.pTable_XB_now, " where convert(decimal(18,0),[DI_LEI]) < 400 group by XIANG  ) as xb LEFT JOIN ", this.pTable_Code, " as code on xb.tjdw = code.CCODE and code.CTYPE = '乡' group by cube(code.CNAME),nd order by min(code.CCODE),code.CNAME,nd" });
        }

        private string pSQL_ZYBH_B4_ZYSZMJXJBHB()
        {
            return ("select '统计单位' = case when Table_code.CNAME IS NULL and Table_order.统计 = '合计' then '合计' else Table_code.CNAME end , Table_order.* FROM ( Select case when (GROUPING (Table_now.tjdw) = 1) then '合计' else ISNULL(Table_now.tjdw,'null') end as 统计, case when (GROUPING (Table_now.sz) = 1) then '合计' else ISNULL(Table_now.sz,'null') end as 优势树种, 'last_mj' = SUM(isnull(Table_last.last_mj,0.0)),'last_xj' = SUM(isnull(Table_last.last_xj,0)), SUM(Table_now.now_mj) as 'now_mj',SUM(Table_now.now_xj) as 'now_xj', 'bhl_mj' = convert(decimal(18,1),SUM(Table_now.now_mj - isnull(Table_last.last_mj,0.0))), 'bhl_xj' = convert(decimal(18,1),SUM(Table_now.now_xj - isnull(Table_last.last_xj,0.0))), 'bhlv_mj' = case when SUM(Table_now.now_mj) > 0 and SUM(isnull(Table_last.last_mj,0)) = 0 then 100 else convert(decimal(18,1),SUM(Table_now.now_mj - isnull(Table_last.last_mj,0.0))/SUM(nullif(isnull(Table_last.last_mj,0.0),0.0)) * 100) end, 'bhlv_xj' = case when SUM(Table_now.now_xj) > 0 and SUM(isnull(Table_last.last_xj,0)) = 0 then 100 when SUM(isnull(Table_last.last_xj,0)) = 0 then 0 else convert(decimal(18,1),SUM(Table_now.now_xj - isnull(Table_last.last_xj,0.0))/SUM(nullif(isnull(Table_last.last_xj,0.0),0.0)) * 100) end FROM ( select case when (GROUPING (XIANG) = 1) then '合计' else ISNULL(XIANG,'null') end as 'tjdw', case when (GROUPING (szmerge) = 1) then '合计' else ISNULL(szmerge,'null') end as 'sz', SUM(convert(decimal(18,1),[YXMJ])) as 'now_mj', SUM(convert(decimal(18,0),[SLXJ])) as 'now_xj' FROM " + this.pTable_XB_now + " as xb LEFT JOIN " + this.pTable_Code + " as code on xb.XIANG = code.CCODE and code.CTYPE = '乡' where [szmerge] <> '' group by cube([szmerge],XIANG) ) as Table_now LEFT JOIN ( select case when (GROUPING (XIANG) = 1) then '合计' else ISNULL(XIANG,'null') end as 'tjdw', case when (GROUPING (szmerge) = 1) then '合计' else ISNULL(szmerge,'null') end as 'sz', SUM(convert(decimal(18,1),[YXMJ])) as 'last_mj', SUM(convert(decimal(18,0),[SLXJ])) as 'last_xj' FROM " + this.pTable_XB_last + " as xb LEFT JOIN " + this.pTable_Code + " as code on xb.XIANG = code.CCODE and code.CTYPE = '乡' where [szmerge] <> '' group by cube([szmerge],XIANG) ) as Table_last ON Table_now.sz = Table_last.sz and Table_now.tjdw = Table_last.tjdw group by Table_now.sz,Table_now.tjdw ) as Table_order LEFT JOIN " + this.pTable_Code + " as Table_code on Table_order.统计 = Table_code.CCODE and Table_code.CTYPE = '乡' LEFT JOIN " + this.pTable_slszhb + " as Table_slszhb on Table_order.优势树种 = Table_slszhb.CNAME order by Table_code.CCODE,Table_slszhb.SORTID");
        }

        private string pSQL_ZYBH_B5_YCLMJXJBHB()
        {
            return string.Concat(new object[] { " Select case when (GROUPING (code.CNAME) = 1) then '合计' else ISNULL(code.CNAME,'合计') end as 统计单位, case when (GROUPING (sz) = 1) then '合计' else ISNULL(sz,'合计') end as 优势树种, case when (GROUPING (nd) = 1) then '合计' else ISNULL(nd,'null') end as 年度, SUM(yll_mj + zll_mj + jsl_mj + csl_mj + gsl_mj) as 总面积, SUM(yll_xj + zll_xj + jsl_xj + csl_xj + gsl_xj) as 总蓄积, SUM(yll_mj) as 幼龄林面积, SUM(yll_xj) as 幼龄林蓄积, SUM(zll_mj) as 中龄林面积, SUM(zll_xj) as 中龄林蓄积, SUM(jsl_mj) as 近熟林面积, SUM(jsl_xj) as 近熟林蓄积, SUM(csl_mj) as 成熟林面积, SUM(csl_xj) as 成熟林蓄积, SUM(gsl_mj) as 过熟林面积, SUM(gsl_xj) as 过熟林蓄积 FROM( select 'tjdw' = case when tjdw IS null then tjdw_now else tjdw end, 'sz' = case when sz IS null then sz_now else sz end, 'nd' ='", this.pLastND, "年', 'yll_mj' = case when yll_mj IS null then 0 else yll_mj end, 'yll_xj' = case when yll_xj IS null then 0 else yll_xj end, 'zll_mj' = case when zll_mj IS null then 0 else zll_mj end, 'zll_xj' = case when zll_xj IS null then 0 else zll_xj end, 'jsl_mj' = case when jsl_mj IS null then 0 else jsl_mj end, 'jsl_xj' = case when jsl_xj IS null then 0 else jsl_xj end, 'csl_mj' = case when csl_mj IS null then 0 else csl_mj end, 'csl_xj' = case when csl_xj IS null then 0 else csl_xj end, 'gsl_mj' = case when gsl_mj IS null then 0 else gsl_mj end, 'gsl_xj' = case when gsl_xj IS null then 0 else gsl_xj end from ( select [XIANG] as 'tjdw', [szmerge] as 'sz', SUM (case when [LING_ZU] = '1' then convert(decimal(18,1),[YXMJ]) else 0 end) as yll_mj, SUM (case when [LING_ZU] = '1' then convert(decimal(18,0),[SLXJ]) else 0 end) as yll_xj, SUM (case when [LING_ZU] = '2' then convert(decimal(18,1),[YXMJ]) else 0 end) as zll_mj, SUM (case when [LING_ZU] = '2' then convert(decimal(18,0),[SLXJ]) else 0 end) as zll_xj, SUM (case when [LING_ZU] = '3' then convert(decimal(18,1),[YXMJ]) else 0 end) as jsl_mj, SUM (case when [LING_ZU] = '3' then convert(decimal(18,0),[SLXJ]) else 0 end) as jsl_xj, SUM (case when [LING_ZU] = '4' then convert(decimal(18,1),[YXMJ]) else 0 end) as csl_mj, SUM (case when [LING_ZU] = '4' then convert(decimal(18,0),[SLXJ]) else 0 end) as csl_xj, SUM (case when [LING_ZU] = '5' then convert(decimal(18,1),[YXMJ]) else 0 end) as gsl_mj, SUM (case when [LING_ZU] = '5' then convert(decimal(18,0),[SLXJ]) else 0 end) as gsl_xj FROM ", this.pTable_XB_last, " where convert(decimal(18,0),[DI_LEI]) <= 200 and DI_LEI <> '130' and DI_LEI <> '120' and LIN_ZHONG like '23%' group by cube(XIANG,[szmerge]) )as aa  full outer join ( select [XIANG] as 'tjdw_now', [szmerge] as 'sz_now', SUM (case when [LING_ZU] = '1' then convert(decimal(18,1),[YXMJ]) else 0 end) as yll_mj_last, SUM (case when [LING_ZU] = '1' then convert(decimal(18,0),[SLXJ]) else 0 end) as yll_xj_last, SUM (case when [LING_ZU] = '2' then convert(decimal(18,1),[YXMJ]) else 0 end) as zll_mj_last, SUM (case when [LING_ZU] = '2' then convert(decimal(18,0),[SLXJ]) else 0 end) as zll_xj_last, SUM (case when [LING_ZU] = '3' then convert(decimal(18,1),[YXMJ]) else 0 end) as jsl_mj_last, SUM (case when [LING_ZU] = '3' then convert(decimal(18,0),[SLXJ]) else 0 end) as jsl_xj_last, SUM (case when [LING_ZU] = '4' then convert(decimal(18,1),[YXMJ]) else 0 end) as csl_mj_last, SUM (case when [LING_ZU] = '4' then convert(decimal(18,0),[SLXJ]) else 0 end) as csl_xj_last, SUM (case when [LING_ZU] = '5' then convert(decimal(18,1),[YXMJ]) else 0 end) as gsl_mj_last, SUM (case when [LING_ZU] = '5' then convert(decimal(18,0),[SLXJ]) else 0 end) as gsl_xj_last FROM ", this.pTable_XB_now, " where convert(decimal(18,0),[DI_LEI]) <= 200 and DI_LEI <> '130' and DI_LEI <> '120' and LIN_ZHONG like '23%' group by cube(XIANG,[szmerge]) ) as bb on aa.tjdw = bb.tjdw_now and aa.sz = bb.sz_now  union all  select 'tjdw' = case when tjdw IS null then tjdw_last else tjdw end, 'sz' = case when sz IS null then sz_last else sz end, 'nd' = '", this.pNowND, "年', 'yll_mj' = case when yll_mj IS null then 0 else yll_mj end, 'yll_xj' = case when yll_xj IS null then 0 else yll_xj end, 'zll_mj' = case when zll_mj IS null then 0 else zll_mj end, 'zll_xj' = case when zll_xj IS null then 0 else zll_xj end, 'jsl_mj' = case when jsl_mj IS null then 0 else jsl_mj end, 'jsl_xj' = case when jsl_xj IS null then 0 else jsl_xj end, 'csl_mj' = case when csl_mj IS null then 0 else csl_mj end, 'csl_xj' = case when csl_xj IS null then 0 else csl_xj end, 'gsl_mj' = case when gsl_mj IS null then 0 else gsl_mj end, 'gsl_xj' = case when gsl_xj IS null then 0 else gsl_xj end from ( select [XIANG] as 'tjdw', [szmerge] as 'sz', SUM (case when [LING_ZU] = '1' then convert(decimal(18,1),[YXMJ]) else 0 end) as yll_mj, SUM (case when [LING_ZU] = '1' then convert(decimal(18,0),[SLXJ]) else 0 end) as yll_xj, SUM (case when [LING_ZU] = '2' then convert(decimal(18,1),[YXMJ]) else 0 end) as zll_mj, SUM (case when [LING_ZU] = '2' then convert(decimal(18,0),[SLXJ]) else 0 end) as zll_xj, SUM (case when [LING_ZU] = '3' then convert(decimal(18,1),[YXMJ]) else 0 end) as jsl_mj, SUM (case when [LING_ZU] = '3' then convert(decimal(18,0),[SLXJ]) else 0 end) as jsl_xj, SUM (case when [LING_ZU] = '4' then convert(decimal(18,1),[YXMJ]) else 0 end) as csl_mj, SUM (case when [LING_ZU] = '4' then convert(decimal(18,0),[SLXJ]) else 0 end) as csl_xj, SUM (case when [LING_ZU] = '5' then convert(decimal(18,1),[YXMJ]) else 0 end) as gsl_mj, SUM (case when [LING_ZU] = '5' then convert(decimal(18,0),[SLXJ]) else 0 end) as gsl_xj FROM ", this.pTable_XB_now, " where convert(decimal(18,0),[DI_LEI]) <= 200 and DI_LEI <> '130' and DI_LEI <> '120' and LIN_ZHONG like '23%' group by cube(XIANG,[szmerge]) )as aa  full outer join ( select [XIANG] as 'tjdw_last', [szmerge] as 'sz_last', SUM (case when [LING_ZU] = '1' then convert(decimal(18,1),[YXMJ]) else 0 end) as yll_mj_last, SUM (case when [LING_ZU] = '1' then convert(decimal(18,0),[SLXJ]) else 0 end) as yll_xj_last, SUM (case when [LING_ZU] = '2' then convert(decimal(18,1),[YXMJ]) else 0 end) as zll_mj_last, SUM (case when [LING_ZU] = '2' then convert(decimal(18,0),[SLXJ]) else 0 end) as zll_xj_last, SUM (case when [LING_ZU] = '3' then convert(decimal(18,1),[YXMJ]) else 0 end) as jsl_mj_last, SUM (case when [LING_ZU] = '3' then convert(decimal(18,0),[SLXJ]) else 0 end) as jsl_xj_last, SUM (case when [LING_ZU] = '4' then convert(decimal(18,1),[YXMJ]) else 0 end) as csl_mj_last, SUM (case when [LING_ZU] = '4' then convert(decimal(18,0),[SLXJ]) else 0 end) as csl_xj_last, SUM (case when [LING_ZU] = '5' then convert(decimal(18,1),[YXMJ]) else 0 end) as gsl_mj_last, SUM (case when [LING_ZU] = '5' then convert(decimal(18,0),[SLXJ]) else 0 end) as gsl_xj_last FROM ", this.pTable_XB_last, " where convert(decimal(18,0),[DI_LEI]) <= 200 and DI_LEI <> '130' and DI_LEI <> '120' and LIN_ZHONG like '23%' group by cube(XIANG,[szmerge]) ) as bb on aa.tjdw = bb.tjdw_last and aa.sz = bb.sz_last ) as xb LEFT JOIN ", this.pTable_Code, " as code on xb.tjdw = code.CCODE and code.CTYPE = '乡' group by code.CNAME,sz,nd order by min(code.ccode),code.CNAME,sz,nd" });
        }

        private SqlConnection SQLDataConfig(string pConnecting, string pDataBaseName)
        {
            SqlConnection connection = new SqlConnection();
            string str = pConnecting;
            connection.ConnectionString = str;
            return connection;
        }
    }
}

