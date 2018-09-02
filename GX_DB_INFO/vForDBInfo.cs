namespace GX_DB_INFO
{
    using ESRI.ArcGIS.Carto;
    using GX_DB_INFO.Properties;
    using GX_DBUpdate.vPojo;
    using GX_DBUpdate.vUtils;
    using Microsoft.SqlServer.Management.Common;
    using Microsoft.SqlServer.Management.Smo;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.IO;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using Utilities;

    public class vForDBInfo
    {
        private Database _db;
        private string _dbName;
        private ServerConnection _serverConnection;
        private SqlConnection _sqlDbConnection;

        public event NatureUpdateMessageHandler OnNatureUpdate;

        public vForDBInfo(IDbConnection dbConn)
        {
            if (dbConn is SqlConnection)
            {
                this._sqlDbConnection = dbConn as SqlConnection;
                this._dbName = dbConn.Database;
                this._serverConnection = new ServerConnection(this._sqlDbConnection);
                Server server = new Server(this._serverConnection);
                this._db = server.Databases[this._dbName];
                this.initVersion(this._db);
            }
        }

        public vForDBInfo(string instance, string user, string passwd, string dbName)
        {
            this._serverConnection = new ServerConnection(instance, user, passwd);
            this._dbName = dbName;
            Server server = new Server(this._serverConnection);
            this._sqlDbConnection = this._serverConnection.SqlConnectionObject;
            this._db = server.Databases[this._dbName];
            this.initVersion(this._db);
        }

        private void _dbInfoTable_OnUpdateMessage(object sender, string msg, int step)
        {
            this.InvokeMessage(msg, step);
        }

        public string GetItemValue(string item)
        {
            string cmdText = "SELECT V_VALUE FROM T_SYS_DB_INFO WHERE V_ITEM='" + item.ToUpper() + "'";
            try
            {
                DataTable table = NatureUpdate.ExecuteCommandWithResults(cmdText, this._sqlDbConnection);
                if ((table == null) || (table.Rows.Count <= 0))
                {
                    return null;
                }
                return (table.Rows[0][0] as string);
            }
            catch (Exception)
            {
                return null;
            }
        }

        private int GetNatureStatus()
        {
            string cmdText = "SELECT V_VALUE FROM T_SYS_DB_INFO WHERE V_ITEM='NAUPDATE'";
            try
            {
                DataTable table = NatureUpdate.ExecuteCommandWithResults(cmdText, this._sqlDbConnection);
                if ((table == null) || (table.Rows.Count <= 0))
                {
                    return -1;
                }
                string s = table.Rows[0][0] as string;
                if (s == null)
                {
                    s = "0";
                }
                int result = -1;
                if (int.TryParse(s, out result))
                {
                    return result;
                }
                return 0;
            }
            catch (Exception)
            {
                return -1;
            }
        }

        private Table initVersion(Database db)
        {
            Table table = db.Tables[vDbInfoTable.TBNAME];
            if (table != null)
            {
                return table;
            }
            FileInfo versionFile = vPathUtil.GetVersionFile("V0TOV1");
            if (versionFile == null)
            {
                NatureUpdate.ExcuteCommandText(Resources.V0TOV1, this._sqlDbConnection);
            }
            else
            {
                NatureUpdate.ExcuteCommandText(versionFile.OpenText().ReadToEnd(), this._sqlDbConnection);
            }
            db.Refresh();
            return db.Tables[vDbInfoTable.TBNAME];
        }

        private void InvokeMessage(string message, int step)
        {
            if (this.OnNatureUpdate != null)
            {
                this.OnNatureUpdate(this, message, step);
            }
        }

        private bool IsItemExists(string item)
        {
            string cmdText = "SELECT COUNT(1) FROM T_SYS_DB_INFO WHERE V_ITEM='" + item.ToUpper() + "'";
            try
            {
                DataTable table = NatureUpdate.ExecuteCommandWithResults(cmdText, this._sqlDbConnection);
                if ((table == null) || (table.Rows.Count <= 0))
                {
                    return false;
                }
                int? nullable = table.Rows[0][0] as int?;
                return (nullable.Value >= 1);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool TryNatureUpdate(int year1, int year2, int yearDiff, bool force, out string message, IMap pMap)
        {
            message = "数据库连接为空，不能进行自然更新！";
            if (this._db == null)
            {
                this.InvokeMessage(message, 100);
                return false;
            }
            Table table = this.initVersion(this._db);
            message = "数据库版本信息不存在，不能进行自然更新！";
            if (table == null)
            {
                this.InvokeMessage(message, 100);
                return false;
            }
            message = "数据库版本信息不存在，不能进行自然更新！";
            try
            {
                DataTable table2 = NatureUpdate.ExecuteCommandWithResults("select count(*) from FOR_XIAOBAN_" + year2 + " where Q_MJ>0", this._sqlDbConnection);
                if ((table2 == null) || (table2.Rows.Count <= 0))
                {
                    message = "修改字段值失败！请检查数据库是否为最新版本。";
                    return false;
                }
                if (int.Parse(table2.Rows[0][0].ToString()) < 1)
                {
                    IList<string> list = Enumerable.ToList<string>(UtilFactory.GetConfigOpt().GetConfigValue2("AddFields", "FieldNames").Split(new char[] { ',' }));
                    IList<string> list2 = Enumerable.ToList<string>(UtilFactory.GetConfigOpt().GetConfigValue2("AddFields", "MatchFields").Split(new char[] { ',' }));
                    string cmdText = "update FOR_XIAOBAN_" + year2 + " set ";
                    string str6 = "";
                    for (int i = 0; i < list2.Count; i++)
                    {
                        string str7 = str6;
                        str6 = str7 + "," + list[i] + "=" + list2[i];
                    }
                    cmdText = cmdText + str6.Substring(1);
                    try
                    {
                        NatureUpdate.ExcuteCommandText(cmdText, this._sqlDbConnection);
                    }
                    catch
                    {
                        message = "修改字段值失败！请检查数据库是否为最新版本。";
                        return false;
                    }
                }
            }
            catch (Exception exception)
            {
                message = "异常：" + exception.Message;
                return false;
            }
            try
            {
                NatureUpdate.ExcuteCommandText("IF OBJECT_ID('NatureUpdate') IS NOT NULL DROP PROC NatureUpdate", this._sqlDbConnection);
                NatureUpdate.ExcuteCommandText(Resources.NAUPDATE, this._sqlDbConnection);
            }
            catch (Exception)
            {
                message = "创建自然更新存储过程失败，不能进行自然更新！";
                return false;
            }
            if (this._db.StoredProcedures["NatureUpdate"] == null)
            {
                return false;
            }
            try
            {
                message = "执行自然更新，请稍候!";
                this.InvokeMessage(message, 20);
                NatureUpdate.ExcuteCommandText(string.Concat(new object[] { "NatureUpdate '", year1, "','", year2, "',", yearDiff }), this._sqlDbConnection);
                this.InvokeMessage("更新伴生桉树...", 20);
                NatureUpdate update = new NatureUpdate();
                update.UpdateAsXJ_BS(pMap, this._sqlDbConnection, yearDiff);
                this.InvokeMessage("更新优势桉树...", 60);
                update.UpdateAsXJ_YS(pMap, this._sqlDbConnection, yearDiff);
                update.UpdateAsXJ(pMap, this._sqlDbConnection, yearDiff);
                this.InvokeMessage("模型更新完成...", 100);
            }
            catch (Exception exception2)
            {
                message = "异常：" + exception2.Message;
                return false;
            }
            return true;
        }

        public bool UpdateDbVersion()
        {
            if (this._serverConnection == null)
            {
                return false;
            }
            vDbInfoTable table = new vDbInfoTable(this._serverConnection);
            table.OnUpdateMessage += new vDbInfoTable.VersionUpdateMessageHandler(this._dbInfoTable_OnUpdateMessage);
            return table.UpdateVersion(this._dbName);
        }

        public bool UpdateItemValue(string item, string value, string comm)
        {
            string cmdText = string.Empty;
            if (this.IsItemExists(item))
            {
                cmdText = "UPDATE T_SYS_DB_INFO SET V_VALUE='" + value + "' WHERE  V_ITEM='" + item.ToUpper() + "'";
            }
            else
            {
                cmdText = "INSERT INTO T_SYS_DB_INFO (V_ITEM, V_VALUE,V_MEMO) VALUES ('" + item.ToUpper() + "', '" + value + "','" + (string.IsNullOrEmpty(comm) ? "" : comm) + "');";
            }
            try
            {
                NatureUpdate.ExcuteCommandText(cmdText, this._sqlDbConnection);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public delegate void NatureUpdateMessageHandler(object sender, string msg, int step);
    }
}

