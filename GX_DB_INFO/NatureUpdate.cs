namespace GX_DB_INFO
{
    using ESRI.ArcGIS.Carto;
    using ESRI.ArcGIS.Geodatabase;
    using GX_DB_INFO.Properties;
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Windows.Forms;
    using TaskManage;

    public class NatureUpdate
    {
        public static string ExcuteCommandText(string cmdText, SqlConnection sqlDbConnection)
        {
            try
            {
                SqlCommand command = sqlDbConnection.CreateCommand();
                command.CommandText = cmdText;
                command.CommandTimeout = 0;
                command.ExecuteNonQuery();
                command.Dispose();
                return string.Empty;
            }
            catch (SqlException exception)
            {
                string text = string.Format("错误编号:{0}\n\r错误源:{1}\n\r错误原因:{2}\n\r错误消息：{3}", new object[] { exception.ErrorCode, exception.Source, exception.InnerException, exception.Message });
                MessageBox.Show(text, "提示", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return text;
            }
        }

        public static DataTable ExecuteCommandWithResults(string cmdText, SqlConnection sqlDbConnection)
        {
            SqlDataAdapter adapter = new SqlDataAdapter(cmdText, sqlDbConnection);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            return dataTable;
        }

        private double ParseDoubleValue(object pValue)
        {
            try
            {
                string s = (pValue == null) ? "" : pValue.ToString().Trim();
                return ((s == "") ? 0.0 : double.Parse(s));
            }
            catch
            {
                return 0.0;
            }
        }

        private string ParseValue(object pValue)
        {
            if (pValue != null)
            {
                return pValue.ToString();
            }
            return "";
        }

        public void UpdateAsXJ(IMap pMap, SqlConnection pDbConn, int iYearD)
        {
            DataTable table = ExecuteCommandWithResults("SELECT COUNT(1) FROM dbo.sysobjects WHERE ID = object_id('T_SYS_DB_INFO')", pDbConn);
            if (this.ParseDoubleValue(table.Rows[0][0]) >= 1.0)
            {
                ExcuteCommandText("UPDATE T_SYS_DB_INFO SET V_VALUE='1' WHERE V_ITEM='NAUPDATE'" + Environment.NewLine, pDbConn);
                string cmdText = "UPDATE T_SYS_DB_INFO SET V_VALUE=convert(varchar(8),getdate(),112) WHERE V_ITEM='NADATE'";
                ExcuteCommandText(cmdText, pDbConn);
            }
        }

        public void UpdateAsXJ_BS(IMap pMap, SqlConnection pDb, int iYearD)
        {
            string name = (EditTask.EditLayer.FeatureClass as IDataset).Name;
            string cmdText = "IF OBJECT_ID('FOR_BSANXJ_PROC')IS NOT NULL DROP PROC FOR_BSANXJ_PROC";
            ExcuteCommandText(cmdText, pDb);
            ExcuteCommandText(Resources.UPBSANXJ, pDb);
            ExcuteCommandText(string.Format("FOR_BSANXJ_PROC '{0}',{1}", name, iYearD), pDb);
            string format = "SELECT DISTINCT CUN,BSSZNL FROM {0} WHERE (BHYY IS NULL OR BHYY >'90' OR LEN(RTRIM(LTRIM(BHYY)))<2 OR BHYY='80') AND (BSSZ>='290' AND BSSZ<='320') ORDER BY CUN,BSSZNL";
            DataTable table = ExecuteCommandWithResults(string.Format(format, name), pDb);
            if ((table != null) && (table.Rows.Count >= 1))
            {
                foreach (DataRow row in table.Rows)
                {
                    if ((row["CUN"] != DBNull.Value) && (row["BSSZNL"] != DBNull.Value))
                    {
                        string str5 = row["CUN"] as string;
                        int num = Convert.ToInt32(row["BSSZNL"]);
                        DataTable table2 = ExecuteCommandWithResults(string.Format("SELECT Q_BSSZPJXJ, Q_BSSZSG, Q_BSSZGQDM FROM FOR_ANBS_VIEW WHERE CUN='{0}' AND Q_BSSZNL={1}", str5, num), pDb);
                        double num2 = -1.0;
                        double num3 = -1.0;
                        double num4 = -1.0;
                        if ((table2 == null) || (table2.Rows.Count <= 0))
                        {
                            table2 = ExecuteCommandWithResults(string.Format("SELECT Q_BSSZPJXJ, Q_BSSZSG, Q_BSSZGQDM FROM FOR_ANBS_VIEW WHERE XIANG='{0}' AND Q_BSSZNL={1} AND CUN='合计'", str5.Substring(0, 9), num), pDb);
                            if ((table2 == null) || (table2.Rows.Count <= 0))
                            {
                                table2 = ExecuteCommandWithResults(string.Format("SELECT Q_BSSZPJXJ, Q_BSSZSG, Q_BSSZGQDM FROM FOR_ANBS_VIEW WHERE XIAN='{0}' AND Q_BSSZNL={1} AND CUN='合计' AND XIANG='合计'", str5.Substring(0, 6), num), pDb);
                                if ((table2 != null) && (table2.Rows.Count >= 1))
                                {
                                    DataRow row2 = table2.Rows[0];
                                    num2 = Convert.ToDouble(row2["Q_BSSZPJXJ"]);
                                    num3 = Convert.ToDouble(row2["Q_BSSZSG"]);
                                    num4 = Convert.ToDouble(row2["Q_BSSZGQDM"]);
                                }
                            }
                            else
                            {
                                DataRow row3 = table2.Rows[0];
                                num2 = Convert.ToDouble(row3["Q_BSSZPJXJ"]);
                                num3 = Convert.ToDouble(row3["Q_BSSZSG"]);
                                num4 = Convert.ToDouble(row3["Q_BSSZGQDM"]);
                            }
                        }
                        else
                        {
                            DataRow row4 = table2.Rows[0];
                            num2 = Convert.ToDouble(row4["Q_BSSZPJXJ"]);
                            num3 = Convert.ToDouble(row4["Q_BSSZSG"]);
                            num4 = Convert.ToDouble(row4["Q_BSSZGQDM"]);
                        }
                        if (((num2 > 0.0) && (num3 > 0.0)) && (num4 > 0.0))
                        {
                            ExcuteCommandText(string.Format("UPDATE {0} SET BSSZPJXJ={1},BSSZSG={2},BSSZGQDM={3} WHERE CUN={4} AND BSSZNL={5} AND (BHYY IS NULL OR BHYY >'90' OR LEN(RTRIM(LTRIM(BHYY)))<2 OR BHYY='80') AND (BSSZ>='290' AND BSSZ<='320')", new object[] { name, num2, num3, num4, str5, num }), pDb);
                        }
                    }
                }
            }
        }

        public void UpdateAsXJ_YS(IMap pMap, SqlConnection pDb, int iYearD)
        {
            string name = (EditTask.EditLayer.FeatureClass as IDataset).Name;
            string cmdText = "IF OBJECT_ID('FOR_ANXJ_PROC')IS NOT NULL DROP PROC FOR_ANXJ_PROC ";
            ExcuteCommandText(cmdText, pDb);
            ExcuteCommandText(Resources.UPANSXJ, pDb);
            ExcuteCommandText(string.Format("FOR_ANXJ_PROC '{0}',{1}", name, iYearD), pDb);
            string format = "SELECT DISTINCT CUN,PINGJUN_NL FROM {0} WHERE (BHYY IS NULL OR BHYY >'90' OR LEN(RTRIM(LTRIM(BHYY)))<2 OR BHYY='80') AND (YOU_SHI_SZ>='290' AND YOU_SHI_SZ<='320') ORDER BY CUN,PINGJUN_NL";
            DataTable table = ExecuteCommandWithResults(string.Format(format, name), pDb);
            if ((table != null) && (table.Rows.Count >= 1))
            {
                foreach (DataRow row in table.Rows)
                {
                    if ((row["CUN"] != DBNull.Value) && (row["PINGJUN_NL"] != DBNull.Value))
                    {
                        string str5 = row["CUN"] as string;
                        int num = Convert.ToInt32(row["PINGJUN_NL"]);
                        DataTable table2 = ExecuteCommandWithResults(string.Format("SELECT Q_PJXJ, Q_PJSG, Q_PJDM FROM FOR_ANXJ_VIEW WHERE CUN='{0}' AND Q_PJNL={1} AND XIAN<>'合计' AND XIANG<>'合计'", str5, num), pDb);
                        double num2 = -1.0;
                        double num3 = -1.0;
                        double num4 = -1.0;
                        if ((table2 == null) || (table2.Rows.Count <= 0))
                        {
                            table2 = ExecuteCommandWithResults(string.Format("SELECT Q_PJXJ, Q_PJSG, Q_PJDM FROM FOR_ANXJ_VIEW WHERE XIANG='{0}' AND Q_PJNL={1} AND CUN='合计' AND XIAN<>'合计'", str5.Substring(0, 9), num), pDb);
                            if ((table2 == null) || (table2.Rows.Count <= 0))
                            {
                                table2 = ExecuteCommandWithResults(string.Format("SELECT Q_PJXJ, Q_PJSG, Q_PJDM FROM FOR_ANXJ_VIEW WHERE XIAN='{0}' AND Q_PJNL={1} AND CUN='合计' AND XIANG='合计'", str5.Substring(0, 6), num), pDb);
                                if ((table2 != null) && (table2.Rows.Count >= 1))
                                {
                                    DataRow row2 = table2.Rows[0];
                                    num2 = Convert.ToDouble(row2["Q_PJXJ"]);
                                    num3 = Convert.ToDouble(row2["Q_PJSG"]);
                                    num4 = Convert.ToDouble(row2["Q_PJDM"]);
                                }
                            }
                            else
                            {
                                DataRow row3 = table2.Rows[0];
                                num2 = Convert.ToDouble(row3["Q_PJXJ"]);
                                num3 = Convert.ToDouble(row3["Q_PJSG"]);
                                num4 = Convert.ToDouble(row3["Q_PJDM"]);
                            }
                        }
                        else
                        {
                            DataRow row4 = table2.Rows[0];
                            num2 = Convert.ToDouble(row4["Q_PJXJ"]);
                            num3 = Convert.ToDouble(row4["Q_PJSG"]);
                            num4 = Convert.ToDouble(row4["Q_PJDM"]);
                        }
                        if (((num2 > 0.0) && (num3 > 0.0)) && (num4 > 0.0))
                        {
                            ExcuteCommandText(string.Format("UPDATE {0} SET PINGJUN_XJ={1},PINGJUN_SG={2},PINGJUN_DM={3} WHERE CUN={4} AND PINGJUN_NL={5} AND (BHYY IS NULL OR BHYY >'90' OR LEN(RTRIM(LTRIM(BHYY)))<2 OR BHYY='80') AND (YOU_SHI_SZ>='290' AND YOU_SHI_SZ<='320')", new object[] { name, num2, num3, num4, str5, num }), pDb);
                        }
                    }
                }
            }
            ExcuteCommandText(string.Format("UPDATE {0} SET BHYY='80' WHERE (BHYY IS NULL OR LEN(RTRIM(LTRIM(BHYY)))<2)  AND (YOU_SHI_SZ>='290' AND YOU_SHI_SZ<='320')", name), pDb);
        }
    }
}

