namespace GDB.SQLServerExpress.vTasks.vExpress
{
    using GDB.SQLServerExpress.vTasks.Forest;
    using GDB.SQLServerExpress.vTasks.Properties;
    using Microsoft.SqlServer.Management.Common;
    using Microsoft.SqlServer.Management.Smo;
    using System;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.Data;

    public class GeoMDFManager
    {
        private ForestDBServerInfo _dbServerInfo;
        private ServerConnection _SqlServerConn;
        private string SYDBS = "MASTER,MODEL,MSDB,TEMPDB";

        public GeoMDFManager(ForestDBServerInfo dbServerInfo)
        {
            this._dbServerInfo = dbServerInfo;
            this.initConn();
        }

        public void AttachDB(string dbName, string dbFilePath, string dbLogPath)
        {
            if (this._dbServerInfo != null)
            {
                if (this._SqlServerConn == null)
                {
                    this.initConn();
                }
                Server server = new Server(this._SqlServerConn);
                StringCollection files = new StringCollection {
                    dbFilePath,
                    dbLogPath
                };
                try
                {
                    server.AttachDatabase(dbName, files);
                }
                catch (Exception)
                {
                }
            }
        }

        public void CreateLdView(List<string> dbNames)
        {
            if (((dbNames != null) && (dbNames.Count > 0)) && (this._dbServerInfo != null))
            {
                if (this._SqlServerConn == null)
                {
                    this.initConn();
                }
                Server server = new Server(this._SqlServerConn);
                foreach (string str in dbNames)
                {
                    Database database = server.Databases[str];
                    string dbYear = this.GetDbYear(str);
                    if ((database != null) && !string.IsNullOrEmpty(dbYear))
                    {
                        try
                        {
                            string sqlCommand = string.Format(Resources.CREATE_VIEW, dbYear);
                            database.ExecuteNonQuery(sqlCommand);
                        }
                        catch (Exception)
                        {
                        }
                    }
                }
            }
        }

        public void DeleteIndxes(List<string> dbNames)
        {
            if (((dbNames != null) && (dbNames.Count > 0)) && (this._dbServerInfo != null))
            {
                if (this._SqlServerConn == null)
                {
                    this.initConn();
                }
                Server server = new Server(this._SqlServerConn);
                foreach (string str in dbNames)
                {
                    Database db = server.Databases[str];
                    string gbCode = this.GetGbCode(str);
                    if ((db != null) && !string.IsNullOrEmpty(gbCode))
                    {
                        try
                        {
                            if (this.GetGeoAminCount(db) > 0)
                            {
                                db.ExecuteNonQuery(Resources.DELE_INDX);
                            }
                        }
                        catch (Exception)
                        {
                        }
                    }
                }
            }
        }

        public void DeleteTableGbCode(List<string> dbNames)
        {
            if (((dbNames != null) && (dbNames.Count > 0)) && (this._dbServerInfo != null))
            {
                if (this._SqlServerConn == null)
                {
                    this.initConn();
                }
                Server server = new Server(this._SqlServerConn);
                foreach (string str in dbNames)
                {
                    Database database = server.Databases[str];
                    string gbCode = this.GetGbCode(str);
                    if ((database != null) && !string.IsNullOrEmpty(gbCode))
                    {
                        try
                        {
                            string sqlCommand = string.Format("DELETE FROM T_SYS_META_CODE WHERE LEN(PCODE)>0 AND LEFT(CCODE,6) <> '{0}'", gbCode);
                            string str4 = string.Format("DELETE FROM T_SYS_LD_ADMIN_CODES WHERE LEFT(CCODE,6) <> '{0}'", gbCode);
                            database.ExecuteNonQuery(sqlCommand);
                            database.ExecuteNonQuery(str4);
                        }
                        catch (Exception)
                        {
                        }
                    }
                }
            }
        }

        public void DetachGeoDB(List<string> dbNames)
        {
            if (this._dbServerInfo != null)
            {
                if (this._SqlServerConn == null)
                {
                    this.initConn();
                }
                Server server = new Server(this._SqlServerConn);
                foreach (string str in dbNames)
                {
                    Database database = server.Databases[str];
                    try
                    {
                        if (database != null)
                        {
                            database = null;
                            server.DetachDatabase(str, true);
                        }
                    }
                    catch (Exception exception)
                    {
                        Console.WriteLine(exception.Message);
                    }
                }
            }
        }

        public List<string> GetAllDBNames()
        {
            if (this._SqlServerConn == null)
            {
                return new List<string>();
            }
            Server server = new Server(this._SqlServerConn);
            List<string> list = new List<string>();
            DatabaseCollection databases = server.Databases;
            if ((databases != null) && (databases.Count >= 1))
            {
                foreach (Database database in databases)
                {
                    string str = database.Name.ToUpper();
                    if (!this.SYDBS.Contains(str))
                    {
                        list.Add(str);
                    }
                }
            }
            return list;
        }

        private string GetDbYear(string dbName)
        {
            if (!dbName.Contains("MODULE"))
            {
                string[] strArray = dbName.Split(new char[] { '_' });
                if (strArray.Length < 3)
                {
                    return string.Empty;
                }
                string s = strArray[2];
                int result = 0;
                if (int.TryParse(s, out result))
                {
                    return s;
                }
            }
            return string.Empty;
        }

        private string GetGbCode(string dbName)
        {
            if (!dbName.Contains("MODULE"))
            {
                string[] strArray = dbName.Split(new char[] { '_' });
                if (strArray.Length < 2)
                {
                    return string.Empty;
                }
                string s = strArray[1];
                int result = 0;
                if (int.TryParse(s, out result))
                {
                    return s;
                }
            }
            return string.Empty;
        }

        private int GetGeoAminCount(Database db)
        {
            if (db != null)
            {
                DataSet set = db.ExecuteWithResults(Resources.XIAN_ADMIN_COUNT);
                if (((set == null) || (set.Tables == null)) || (set.Tables.Count <= 0))
                {
                    return -1;
                }
                DataTable table = set.Tables[0];
                if (((table != null) && (table.Rows != null)) && (table.Rows.Count >= 1))
                {
                    DataRow row = table.Rows[0];
                    string s = row[0] as string;
                    int result = -1;
                    int.TryParse(s, out result);
                    return result;
                }
            }
            return -1;
        }

        public Dictionary<string, string> GetGeoMDFKeys(List<string> dbNames)
        {
            if ((dbNames == null) || (dbNames.Count <= 0))
            {
                dbNames = this.GetAllDBNames();
            }
            if (this._SqlServerConn == null)
            {
                this.initConn();
            }
            Server server = new Server(this._SqlServerConn);
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            foreach (string str in dbNames)
            {
                string sqlCommand = string.Format("SELECT char_prop_value FROM [{0}].[dbo].[SDE_server_config]  WHERE prop_name='AUTH_KEY'", str);
                Database database = server.Databases[str];
                if (database != null)
                {
                    DataSet set = database.ExecuteWithResults(sqlCommand);
                    if ((set != null) && (set.Tables.Count > 0))
                    {
                        DataTable table = set.Tables[0];
                        if (((table != null) && (table.Rows != null)) && (table.Rows.Count >= 1))
                        {
                            DataRow row = table.Rows[0];
                            string str3 = row["char_prop_value"] as string;
                            if (!string.IsNullOrEmpty(str3))
                            {
                                dictionary.Add(str, str3);
                            }
                        }
                        set.Clear();
                        set = null;
                    }
                }
            }
            return dictionary;
        }

        public Dictionary<string, string> GetMDFGeoTypes(List<string> dbNames)
        {
            if ((dbNames == null) || (dbNames.Count <= 0))
            {
                dbNames = this.GetAllDBNames();
            }
            if (this._SqlServerConn == null)
            {
                this.initConn();
            }
            Server server = new Server(this._SqlServerConn);
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            foreach (string str in dbNames)
            {
                string sqlCommand = string.Format("SELECT config_string FROM [{0}].[dbo].[SDE_dbtune] WHERE KEYWORD='DEFAULTS' AND PARAMETER_NAME='GEOMETRY_STORAGE'", str);
                Database database = server.Databases[str];
                if (database != null)
                {
                    DataSet set = database.ExecuteWithResults(sqlCommand);
                    if ((set != null) && (set.Tables.Count > 0))
                    {
                        DataTable table = set.Tables[0];
                        if (((table != null) && (table.Rows != null)) && (table.Rows.Count >= 1))
                        {
                            DataRow row = table.Rows[0];
                            string str3 = row["config_string"] as string;
                            if (!string.IsNullOrEmpty(str3))
                            {
                                dictionary.Add(str, str3);
                            }
                        }
                        set.Clear();
                        set = null;
                    }
                }
            }
            return dictionary;
        }

        private void initConn()
        {
            string serverInstance = string.Format(@"{0}\{1}", this._dbServerInfo.ServerName, this._dbServerInfo.InstanceName);
            this._SqlServerConn = new ServerConnection(serverInstance, this._dbServerInfo.UserName, this._dbServerInfo.UserPass);
            this._SqlServerConn.Connect();
        }

        public void ShutDown()
        {
            if (this._SqlServerConn != null)
            {
                this._SqlServerConn.Disconnect();
                this._SqlServerConn = null;
            }
        }

        public int UpdateGeoDbKey(List<string> dbNames, string key)
        {
            if (this._dbServerInfo == null)
            {
                return -1;
            }
            if (this._SqlServerConn == null)
            {
                this.initConn();
            }
            int num = 0;
            Server server = new Server(this._SqlServerConn);
            foreach (string str in dbNames)
            {
                Database database = server.Databases[str];
                if (database != null)
                {
                    string sqlCommand = string.Format("UPDATE [{0}].[dbo].[SDE_server_config] set char_prop_value='{1}' WHERE prop_name='AUTH_KEY'", str, key);
                    try
                    {
                        database.ExecuteNonQuery(sqlCommand);
                        num++;
                    }
                    catch (Exception)
                    {
                    }
                }
            }
            return num;
        }

        public int UpdateGeoDbType(List<string> dbNames)
        {
            if (this._dbServerInfo == null)
            {
                return -1;
            }
            if (this._SqlServerConn == null)
            {
                this.initConn();
            }
            int num = 0;
            Server server = new Server(this._SqlServerConn);
            foreach (string str in dbNames)
            {
                Database database = server.Databases[str];
                if (database != null)
                {
                    string sqlCommand = string.Format("UPDATE [{0}].[dbo].[SDE_dbtune] SET config_string='GEOMETRY' WHERE KEYWORD='DEFAULTS' AND PARAMETER_NAME='GEOMETRY_STORAGE'", str);
                    try
                    {
                        database.ExecuteNonQuery(sqlCommand);
                        num++;
                    }
                    catch (Exception)
                    {
                    }
                    database = null;
                }
            }
            return num;
        }

        public ServerConnection SqlServerConnection
        {
            get
            {
                return this._SqlServerConn;
            }
        }
    }
}

