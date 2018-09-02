namespace GDB.SQLServerExpress.vTasks.vExpress
{
    using ESRI.ArcGIS.DataSourcesGDB;
    using ESRI.ArcGIS.esriSystem;
    using GDB.SQLServerExpress.Forest;
    using Microsoft.SqlServer.Management.Common;
    using Microsoft.SqlServer.Management.Smo;
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Runtime.InteropServices;

    public class ForestMDFManager
    {
        private ForestGDBInfo _GdbInfo;
        protected IDataServerManagerAdmin _GeoMDFAdmin;
        protected ServerConnection _SqlServerConn;

        public ForestMDFManager(ForestGDBInfo gdbInfo)
        {
            this._GdbInfo = gdbInfo;
            this.initDSAdmin(this._GdbInfo.GDBServer);
        }

        private static SqlConnection CreateConnection(string server, string uid, string pwd, string dbName)
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder {
                DataSource = server,
                InitialCatalog = dbName,
                UserID = uid,
                Password = pwd
            };
            string connectionString = builder.ConnectionString;
            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(connectionString);
            }
            catch (Exception)
            {
                return null;
            }
            return connection;
        }

        private void CreateSysTable(string dbName)
        {
            if (((this._GdbInfo != null) && (this._GdbInfo.UpdateMetaInfos != null)) && (this._GdbInfo.UpdateMetaInfos.Count > 0))
            {
                using (SqlConnection connection = CreateConnection(this._GdbInfo.ServerName, this._GdbInfo.UserName, this._GdbInfo.UserPass, dbName))
                {
                    connection.Open();
                    string sql = "CREATE TABLE SYS_MAX_ID(MAX_TYPE nvarchar(20),MAX_ID int,TYPE_NAME nvarchar(20))";
                    this.ExcuteSql(connection, sql);
                    sql = "CREATE TABLE T_LOG(USER_NAME nvarchar(50) ,OPERATE nvarchar(50) ,LOG_TIME datetime2(7) ,REMARK nvarchar(255) ,SYSTEM nvarchar(50) ,ID int NOT NULL)";
                    this.ExcuteSql(connection, sql);
                    string str2 = string.Format("DELETE FROM T_SYS_META_CODE WHERE LEN(PCODE)>0 AND LEFT(CCODE,6) <> '{0}'", this._GdbInfo.GBCode);
                    this.ExcuteSql(connection, str2);
                    str2 = string.Format("DELETE FROM T_SYS_LD_ADMIN_CODES WHERE LEFT(CCODE,6) <> '{0}'", this._GdbInfo.GBCode);
                    this.ExcuteSql(connection, str2);
                    try
                    {
                        connection.Close();
                        connection.Dispose();
                    }
                    catch (Exception)
                    {
                    }
                }
                this.DropObjectIdField(new string[] { "T_DesignKind", "T_EditTask_ZT", "SYS_MAX_ID", "T_LOG", "T_SYS_USER_AUTHOR", "T_MapLayer", "T_EditTask", "T_SYS_FLOW_AUTHOR", "T_SYS_FLOW_DEPT", "T_SYS_FLOW_USER", "T_Logic_Check", "T_AutoUpdate_Feature", "T_ZT_Overlap" }, dbName);
            }
        }

        private void DropObjectIdField(string[] tables, string dbName)
        {
            if (this._SqlServerConn == null)
            {
                this._SqlServerConn = new ServerConnection(this._GdbInfo.GDBServer, this._GdbInfo.UserName, this._GdbInfo.UserPass);
            }
            if ((this._SqlServerConn != null) && this._SqlServerConn.IsOpen)
            {
                Server server = new Server(this._SqlServerConn);
                Database database = server.Databases[dbName];
                foreach (string str in tables)
                {
                    Table table = database.Tables[str];
                    if (table != null)
                    {
                        try
                        {
                            IndexCollection indexes = table.Indexes;
                            int count = indexes.Count;
                            for (int i = 0; i < count; i++)
                            {
                                Index index = null;
                                index = indexes[i];
                                if ((index != null) && index.Name.Contains("SDE_ROWID"))
                                {
                                    index.Drop();
                                }
                            }
                        }
                        catch (Exception)
                        {
                        }
                        try
                        {
                            Column column = table.Columns["OBJECTID"];
                            if (column != null)
                            {
                                column.Drop();
                            }
                        }
                        catch (Exception)
                        {
                        }
                    }
                }
            }
        }

        private void ExcuteSql(SqlConnection conn, string sql)
        {
            try
            {
                SqlCommand command = conn.CreateCommand();
                command.CommandText = sql;
                command.ExecuteNonQuery();
                command.Dispose();
                command = null;
            }
            catch (Exception)
            {
            }
        }

        ~ForestMDFManager()
        {
            if (this._GeoMDFAdmin != null)
            {
                Marshal.ReleaseComObject(this._GeoMDFAdmin);
                this._GeoMDFAdmin = null;
            }
            if (this._SqlServerConn != null)
            {
                this._SqlServerConn.Disconnect();
                this._SqlServerConn = null;
            }
        }

        protected void initDSAdmin(string gdbIntance)
        {
            if (!string.IsNullOrEmpty(gdbIntance))
            {
                try
                {
                    IDataServerManager manager = new DataServerManagerClass {
                        ServerName = gdbIntance
                    };
                    manager.Connect();
                    this._GeoMDFAdmin = (IDataServerManagerAdmin) manager;
                }
                catch (Exception)
                {
                    this._GeoMDFAdmin = null;
                }
            }
        }

        public List<string> QueryAllDBNames()
        {
            if (this._GeoMDFAdmin == null)
            {
                return null;
            }
            try
            {
                List<string> list = new List<string>();
                IEnumBSTR geodatabaseNames = this._GeoMDFAdmin.GetGeodatabaseNames();
                for (string str = geodatabaseNames.Next(); !string.IsNullOrEmpty(str); str = geodatabaseNames.Next())
                {
                    list.Add(str);
                }
                if (geodatabaseNames != null)
                {
                    Marshal.ReleaseComObject(geodatabaseNames);
                    geodatabaseNames = null;
                }
                return list;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public void UpdateForestGeoMDF(string dbName)
        {
            if (string.IsNullOrEmpty(dbName))
            {
                foreach (string str in this.QueryAllDBNames())
                {
                    this.UpdateGDBToForest(string.Empty, str);
                    this.CreateSysTable(str);
                }
            }
            else
            {
                this.UpdateGDBToForest(string.Empty, dbName);
                this.CreateSysTable(dbName);
            }
        }

        protected bool UpdateGDBToForest(string keyText, string dbName)
        {
            string serverName = this._GdbInfo.ServerName;
            if (string.IsNullOrEmpty(serverName))
            {
                return false;
            }
            using (SqlConnection connection = CreateConnection(serverName, this._GdbInfo.UserName, this._GdbInfo.UserPass, dbName))
            {
                connection.Open();
                string str2 = string.Format("UPDATE [{0}].[dbo].[SDE_dbtune] SET config_string='GEOMETRY' WHERE KEYWORD='DEFAULTS' AND PARAMETER_NAME='GEOMETRY_STORAGE'", this._GdbInfo.DBName);
                SqlCommand command = connection.CreateCommand();
                command.CommandText = str2;
                command.ExecuteNonQuery();
                command.Dispose();
                command = null;
                if (string.IsNullOrEmpty(keyText))
                {
                    keyText = "sdeworkgroup,100,sdeworkgroup,01-jan-2030,IE7XTNBJ3Y4JYJT15089";
                }
                string str3 = string.Format("UPDATE [{0}].[dbo].[SDE_server_config] set char_prop_value='{1}' WHERE prop_name='AUTH_KEY'", this._GdbInfo.DBName, keyText);
                SqlCommand command2 = connection.CreateCommand();
                command2.CommandText = str3;
                command2.ExecuteNonQuery();
                command2.Dispose();
                command2 = null;
                try
                {
                    connection.Close();
                    connection.Dispose();
                }
                catch (Exception)
                {
                }
                return true;
            }
        }
    }
}

